using BE_ProyectoA.Core.Application.DTOs.Request.Account;
using BE_ProyectoA.Core.Application.DTOs.Response;
using BE_ProyectoA.Core.Application.DTOs.Response.Account;
using BE_ProyectoA.Core.Application.Interfaces;
using BE_ProyectoA.Core.Domain.Entities.Authentication;
using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
using BE_ProyectoA.Core.Domain.Entities.Director;
using BE_ProyectoA.Core.Domain.Entities.DirigenteMultiplicador;
using BE_ProyectoA.Core.Domain.Primitivies;
using BE_ProyectoA.Core.Domain.ValueObjects;
using BE_ProyectoA.Persistence.Identity.Context;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Constant = BE_ProyectoA.Core.Application.Extensions.Constant;

namespace BE_ProyectoA.Persistence.Identity.Repos
{
    public class AccountRepository
        (
        RoleManager<IdentityRole> roleManager,
        UserManager<ApplicationUser> userManager, IConfiguration config,
        SignInManager<ApplicationUser> signInManager,
        IdentityContext context,
        ICoordinadorGeneralRepository coordinadorGeneralRepository,
        ISubCoordinadorRepository subCoordinadorRepository,
        IDirigenteMultiplicadorRepository dirigenteMultiplicadorRepository,
        IDirectoresRepository directorRepository,
        IUnitOfWork unitOfWork

        ) : IAccount
    {

        private async Task<ApplicationUser> FindUserByEmailAsync(string email) 
            => await userManager.FindByEmailAsync(email);

        private async Task<IdentityRole> FindByRoleNameAsync(string rolename)
            => await roleManager.FindByNameAsync(rolename);

        private static string GenerateRefreshToken()
            => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        private async Task<string> GenerateToken(ApplicationUser user)
        {
            try
            {

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:key"]!));
                var credentials =  new SigningCredentials (securityKey,SecurityAlgorithms.HmacSha256);
                var userClaims = new[]
                {
                    new Claim(ClaimTypes.Email,user.Email!),
                    new Claim(ClaimTypes.Name, user.Nombre!),
                    new Claim(ClaimTypes.Role, (await userManager.GetRolesAsync(user)).FirstOrDefault()!.ToString()),
                    new Claim ("FullName",user.Nombre!),
                };

                var token = new JwtSecurityToken
                    (
                     issuer: config["Jwt:Issuer"],
                     audience: config["Jwt:Audience"],
                     claims: userClaims,
                     expires: DateTime.Now.AddMinutes(30),
                     signingCredentials: credentials

                    );

                return new JwtSecurityTokenHandler().WriteToken(token);

            }
            catch
            {
                return null!;
            }
        }

        private async Task<GeneralResponse> AssignUserToRole(ApplicationUser user, IdentityRole role)
        {
            if (user is null || role is null)
                return new GeneralResponse(false, "El usuario o el rol no pueden ser nulos");

            // Verificar si el rol existe, si no, crearlo
            if (await FindByRoleNameAsync(role.Name!) == null)
                await CreateRoleAsync(role.Adapt(new CreateRoleDTO()));

            // Asignar el rol al usuario
            IdentityResult result = await userManager.AddToRoleAsync(user, role.Name!);

            string error = CheckResponse(result);
            if (!string.IsNullOrEmpty(error))
                return new GeneralResponse(false, error);
            else
                return new GeneralResponse(true, $"{user.Nombre} asignado al rol {role.Name}");
        }

        private static string CheckResponse(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(_ => _.Description);
                return string.Join(Environment.NewLine, errors);
            }
            return null!;
        }

        public async Task<GeneralResponse> ChangeUserRoleAsync(ChangeRoleRequestDTO model)
        {
            if (await FindByRoleNameAsync(model.RoleName) is null) return new GeneralResponse(false, "rol no encontrado");
            if (await FindUserByEmailAsync(model.UserEmail) is null) return new GeneralResponse(false, "Usuario no encontrado");

            var user = await FindUserByEmailAsync(model.UserEmail);
            var previousRole = (await userManager.GetRolesAsync(user)).FirstOrDefault();
            var removeRoleOldRole = await userManager.RemoveFromRoleAsync(user,previousRole);

            var error = CheckResponse(removeRoleOldRole);
            if (!string.IsNullOrEmpty(error)) return new GeneralResponse(false, error);

            var result = await userManager.AddToRoleAsync(user,model.RoleName);
            var response = CheckResponse(result);
            if (!string.IsNullOrEmpty(response)) return new GeneralResponse(false, response);
            else
                return new GeneralResponse(true, "Role cambiado");
    
        }

        public async Task<GeneralResponse> CreateAccountAsync(CreateAccountDTO model, CancellationToken cancellationToken = default)
        {
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                // Crear la cuenta de usuario en la base de datos Identity
                var user = await CreateUserAsync(model);

                // Validar las operaciones en los repositorios antes de crear el usuario
                switch (model.Role)
                {
                    case "CoordinadorGeneral":
                        // Crear Coordinador General y validar
                        await CreateCoordinadorGeneralAsync(model, user, cancellationToken);
                        break;

                    case "SubCoordinador":
                        // Crear SubCoordinador y validar
                        await CreateSubCoordinadorAsync(model, user, cancellationToken);
                        break;
                    case "Dirigente":
                        // Crear Dirigente y validar
                        await CreateDirigenteAsync(model, user, cancellationToken);
                        break;
                    case "Director":
                        await CreateDirectorAsync(model, user, cancellationToken);
                        break;
                    case "Admin":
                        await CreateDirectorAsync(model, user, cancellationToken);
                        break;
                    default:
                        return new GeneralResponse(false, "Rol de usuario no válido");
                }

                var role = new IdentityRole { Name = model.Role };
                var assignRoleResponse = await AssignUserToRole(user, role);
                if (!assignRoleResponse.Flag)
                    return assignRoleResponse;

                // Commit de la transacción si todo fue exitoso
                await transaction.CommitAsync(cancellationToken);

                return new GeneralResponse(true, "Usuario creado exitosamente");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                return new GeneralResponse(false, ex.Message);
            }
        }

        private async Task CreateDirectorAsync(CreateAccountDTO model, ApplicationUser user, CancellationToken cancellationToken)
        {
            // Crear Director General
            var director = new Directores (
                
                id: new DirectoresId(Guid.Parse(user.Id)),
                nombre: model.Nombre,
                apellido: model.Apellido,
                cantidadVotantes: CantidadVotos.Create(model.CantidadVotantes)!,
                cedula: Cedula.Create(model.Cedula)!,
                numeroTelefono: NumeroTelefono.Create(model.NumeroTelefono)!,
                activo: model.Activo
              
            );
            await directorRepository.AddAsync(director, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }


        private async Task CreateCoordinadorGeneralAsync(CreateAccountDTO model, ApplicationUser user, CancellationToken cancellationToken)
        {
            // Crear Coordinador General
            var coordinador = new CoordinadoresGenerales(
                id: new CoordinadoresGeneralesId(Guid.Parse(user.Id)),
                nombre: model.Nombre,
                apellido: model.Apellido,
                cedula: Cedula.Create(model.Cedula)!,
                numeroTelefono: NumeroTelefono.Create(model.NumeroTelefono)!,
                activo: model.Activo,
                cantidadVotantes: CantidadVotos.Create(model.CantidadVotantes)!,
                direccion: Direccion.Create(model.Provincia, model.Sector, model.CasaElectoral)!
            );
            await coordinadorGeneralRepository.AddAsync(coordinador, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        private async Task CreateSubCoordinadorAsync(CreateAccountDTO model, ApplicationUser user, CancellationToken cancellationToken)
        {
            // Crear SubCoordinador
            var coordinadorGeneralId = new CoordinadoresGeneralesId(model.CoordinadorGeneralId);
            var coordinador = await coordinadorGeneralRepository.GetByIdAsync2(coordinadorGeneralId, cancellationToken);
            var subCoordinador = new SubCoordinadores(
                id: new SubCoordinadoresId(Guid.Parse(user.Id)),
                nombre: model.Nombre,
                apellido: model.Apellido,
                cantidadVotos: CantidadVotos.Create(model.CantidadVotantes)!,
                numeroTelefono: NumeroTelefono.Create(model.NumeroTelefono)!,
                cedula: Cedula.Create(model.Cedula)!,
                activo: model.Activo,
                direccion: Direccion.Create(model.Provincia, model.Sector, model.CasaElectoral)!,
                coordinadorsGeneralesId: coordinadorGeneralId,
                coordinador!
            );
            await subCoordinadorRepository.AddAsync(subCoordinador, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        private async Task CreateDirigenteAsync(CreateAccountDTO model, ApplicationUser user, CancellationToken cancellationToken)
        {
            // Crear Dirigente
            var subCoordiadorId = new SubCoordinadoresId(model.SubCoordinadorId);
            if (!await subCoordinadorRepository.ExistsAsync(subCoordiadorId, cancellationToken))
                throw new Exception("El Subcoordinador no existe");
            var subCoordinador = await subCoordinadorRepository.GetByIdAsync2(subCoordiadorId, cancellationToken);
            var dirigente = new DirigentesMultiplicadores(
                id: new DirigentesMultiplicadoresId(Guid.Parse(user.Id)),
                cedula: Cedula.Create(model.Cedula)!,
                numeroTelefono: NumeroTelefono.Create(model.NumeroTelefono)!,
                nombre: model.Nombre,
                apellido: model.Apellido,
                activo: model.Activo,
                direccion: Direccion.Create(model.Provincia, model.Sector, model.CasaElectoral)!,
                cantidadVotantes: CantidadVotos.Create(model.CantidadVotantes)!,
                subCoordiadorId,
                subCoordinador!
            );
            await dirigenteMultiplicadorRepository.AddAsync(dirigente, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }

        private async Task<ApplicationUser> CreateUserAsync(CreateAccountDTO model)
        {
            // Crear la cuenta de usuario en la base de datos Identity
            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Email,
                Nombre = model.Nombre,
                PasswordHash = model.Password
            };
            var result = await userManager.CreateAsync(user, model.Password);
            string error = CheckResponse(result);
            if (!string.IsNullOrEmpty(error))
                throw new Exception(error);
            return user;
        }

        public async Task CreateAdmin()
        {
            try
            {
                if ((await FindUserByEmailAsync(Constant.Role.Admin)) != null) 
                    return;

                var admin = new CreateAccountDTO()
                {
                    Nombre = "Admin",
                    Password = "Admin@123",
                    Email = "admin@admin.com",
                    Role = Constant.Role.Admin
                };
                await CreateAccountAsync(admin);
            }catch { }
        }

        public async Task<GeneralResponse> CreateRoleAsync(CreateRoleDTO model)
        {
            try
            {
                if ((await FindByRoleNameAsync(model.Name) == null))
                {
                    var response = await roleManager.CreateAsync(new IdentityRole(model.Name)); 
                    var error = CheckResponse(response);
                    if (!string.IsNullOrEmpty(error))
                        throw new Exception(error);
                    else
                        return new GeneralResponse(true, $"{model.Name} Creado");
                }

                return new GeneralResponse(false, $"{model.Name} ya existe");

            }catch (
            Exception ex) 
            { throw new Exception(ex.Message); }
        }

        public async Task<IEnumerable<GetRoleDTO>> GetRolesAsync() =>(await roleManager.Roles.ToListAsync()).Adapt<IEnumerable<GetRoleDTO>>();
        public async Task<IEnumerable<GetUsersWithRoleDTO>> GetUsersWithRolesAsync()
        {
            var allUser = await userManager.Users.ToListAsync();

            if (allUser == null)
            {
                // Manejar el caso en el que no hay usuarios
                return Enumerable.Empty<GetUsersWithRoleDTO>();
            }

            var List = new List<GetUsersWithRoleDTO>();

            foreach (var user in allUser.AsEnumerable())
            {
                var getUserRole = (await userManager.GetRolesAsync(user)).FirstOrDefault();
                var getRoleInfo = await roleManager.Roles.FirstOrDefaultAsync(r => r.Name.ToLower() == getUserRole.ToLower());

                List.Add(new GetUsersWithRoleDTO()
                {
                    Name = user.Nombre,
                    Email = user.Email,
                    RoleId = getRoleInfo?.Id, // Asegúrate de manejar la posibilidad de que getRoleInfo sea nulo
                    RoleName = getRoleInfo?.Name, // Asegúrate de manejar la posibilidad de que getRoleInfo sea nulo
                });
            }
            return List;
        }

        public async Task<LoginResponse> LoginAccountAsync(LoginDTO model)
        {
            try
            {
                var user = await FindUserByEmailAsync(model.Email);

                if (user is null)
                    return new LoginResponse(false, "usuario no encontrado");

                SignInResult result;

                try
                {
                    result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                }
                catch
                {
                    return new LoginResponse(false, "Credenciales Erroneas, intente de nuevo");
                }
                if (!result.Succeeded)
                    return new LoginResponse(false, "Credenciales Erroneas, intente de nuevo");

                string jwtToken = await GenerateToken(user);
                string refreshToken = GenerateRefreshToken();

               if(string.IsNullOrEmpty(jwtToken) || string.IsNullOrEmpty(refreshToken))
                    {
                    return new LoginResponse(false, "Ha ocurrido un error al iniciar sesion, contacte con el administrador");
                     }
                else
                {
                    var SaveResult = await SaveRefreshToken(user.Id, refreshToken);
                    if (SaveResult.Flag)
                        return new LoginResponse(true, $"{user.Nombre} ha iniciado sesesion correctamente", jwtToken, refreshToken);
                    else
                        return new LoginResponse();
                }
            }
            catch (Exception ex)
            {
                return new LoginResponse(false,ex.Message);
            }
        }

        public async Task<LoginResponse> RefreshTokenAsync(RefreshTokenDTO model)
        {
            var token = await context.RefreshToken.FirstOrDefaultAsync(t => t.Token == model.Token);
            if (token == null) return new LoginResponse();

            var user = await userManager.FindByIdAsync(token.UserId!);
            string newToken = await GenerateToken(user!);
            string newRefreshToken = GenerateRefreshToken();

            var saveResult = await SaveRefreshToken(user.Id, newRefreshToken);

            if (saveResult.Flag)
                return new LoginResponse(true, $"{user.Nombre} ha iniciado sesesion correctamente", newToken, newRefreshToken);
            else
                return new LoginResponse();

        }

        private async Task<GeneralResponse>SaveRefreshToken(string userId,string token)
        {
            try
            {
                var user = await context.RefreshToken.FirstOrDefaultAsync(t => t.UserId == userId);

                if (user == null)
                    context.RefreshToken.Add(new RefreshToken() { UserId = userId, Token = token });
                else
                    user.Token = token;
                    return new GeneralResponse(true, null!);
                
            }
            catch (Exception ex) 
            {

                return new GeneralResponse(false, ex.Message);
            }
            
                
            
        }
    }
}
