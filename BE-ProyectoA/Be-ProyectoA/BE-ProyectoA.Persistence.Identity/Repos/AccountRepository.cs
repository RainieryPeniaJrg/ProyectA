using BE_ProyectoA.Core.Application.Common.ValueObjectsValidators;
using BE_ProyectoA.Core.Application.DTOs.Request.Account;
using BE_ProyectoA.Core.Application.DTOs.Response;
using BE_ProyectoA.Core.Application.DTOs.Response.Account;
using BE_ProyectoA.Core.Application.Interfaces;
using BE_ProyectoA.Core.Domain.Entities.Authentication;
using BE_ProyectoA.Core.Domain.Entities.Coordinadores;
using BE_ProyectoA.Core.Domain.Entities.CoordinadorGeneral;
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

            if(user is null || role is null)return new GeneralResponse(false,"Model stato cannot be empty");

            if (await FindByRoleNameAsync(role.Name!) == null)
                await CreateRoleAsync(role.Adapt(new CreateRoleDTO()));

            IdentityResult result = await userManager.AddToRoleAsync(user, role.Name!);

            string error = CheckResponse(result);

            if (!string.IsNullOrEmpty(error))
                return new GeneralResponse(false, error);
            else
                return new GeneralResponse(true, $"{user.Nombre} assigned to {role.Name} role");

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

        public async Task<GeneralResponse> CreateAccountAsync(CreateAccountDTO model,CancellationToken cancellationToken= default)
        {
            try
            {

                if (await FindUserByEmailAsync(model.Email) != null)
                    return new GeneralResponse(false, "Lo sentimos, el usuario ya ha sido creado");

                var user = new ApplicationUser()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    Nombre = model.Nombre,
                    PasswordHash = model.Password
                };
                var result = await userManager.CreateAsync(user, model.Password);

                string error = CheckResponse(result);
                if (!string.IsNullOrEmpty(error)) return new GeneralResponse(false, error);

                var (flag,message) = await AssignUserToRole(user, new IdentityRole() { Name = model.Role });




                if (model.Role == "CoordinadorGeneral")
                {

                 

                    ValueObjectValidators.ValidarDatos(model.Cedula, model.NumeroTelefono, model.Provincia, model.Sector, model.casaElectoral);

                    var userRequest = await userManager.FindByEmailAsync(model.Email);
                    if(userRequest != null)
                    {
                        var requestId = userRequest.Id;

                       var coordinador = new CoordinadoresGenerales(
                       id: new CoordinadoresGeneralesId(Guid.Parse(requestId)),
                       nombre: model.Nombre,
                       apellido: model.Apellido,
                       cedula: Cedula.Create(model.Cedula)!,
                       numeroTelefono: NumeroTelefono.Create(model.NumeroTelefono)!,
                       activo: model.Activo,
                       direccion: Direccion.Create(model.Provincia, model.Sector, model.casaElectoral)!

                   );
                        await coordinadorGeneralRepository.AddAsync(coordinador, cancellationToken);
                        await unitOfWork.SaveChangesAsync(cancellationToken);

                    }


                }
                if(model.Role == "SubCoordinador")
                {
                    ValueObjectValidators.ValidarDatos(model.Cedula, model.NumeroTelefono, model.Provincia, model.Sector, model.casaElectoral);

                    var coordiadorGeneralId = new CoordinadoresGeneralesId(model.CoordinadorGeneralId);

                    if(!await coordinadorGeneralRepository.ExistsAsync(coordiadorGeneralId, cancellationToken))
                        return new GeneralResponse(false, "El coordinador general no existe");

                    var coordinador = await coordinadorGeneralRepository.GetByIdAsync(coordiadorGeneralId, cancellationToken);


                    var userRequest = await userManager.FindByEmailAsync(model.Email);
                    if (userRequest != null)
                    {
                        var requestId = userRequest.Id;
                        var subCoordinador = new SubCoordinadores
                        (id: new SubCoordinadoresId(Guid.Parse(requestId)),
                        nombre: model.Nombre,
                        apellido: model.Apellido,
                        cantidadVotos: model.CantidadVotantes,
                        numeroTelefono: NumeroTelefono.Create(model.NumeroTelefono)!,
                        cedula: Cedula.Create(model.Cedula)!,
                        activo: model.Activo,
                        direccion: Direccion.Create(model.Provincia, model.Sector, model.casaElectoral)!,
                        coordinadorsGeneralesId: coordiadorGeneralId,
                        coordinador!
                        );
                        await subCoordinadorRepository.AddAsync(subCoordinador, cancellationToken);

                        await unitOfWork.SaveChangesAsync(cancellationToken);
                    }
                       

                   
                }
                if(model.Role == "Dirigente")
                {
                    ValueObjectValidators.ValidarDatos(model.Cedula, model.NumeroTelefono, model.Provincia, model.Sector, model.casaElectoral);
                    var subCoordiadorId = new SubCoordinadoresId(model.SubCoordinadorId);
                    if(!await subCoordinadorRepository.ExistsAsync(subCoordiadorId, cancellationToken))
                        return new GeneralResponse(false, "El Subcoordinador  no existe");

                  var subCoordinador = await subCoordinadorRepository.GetByIdAsync(subCoordiadorId, cancellationToken);
                  var userRequest =  await userManager.FindByEmailAsync(model.Email);
                  if(userRequest != null)
                    {
                        var requestId = userRequest.Id;
                        var dirigente = new DirigentesMultiplicadores
                  (
                  id: new DirigentesMultiplicadoresId(Guid.Parse(requestId)),
                  cedula: Cedula.Create(model.Cedula)!,
                  numeroTelefono: NumeroTelefono.Create(model.NumeroTelefono)!,
                  nombre: model.Nombre,
                  apellido: model.Apellido,
                  activo: model.Activo,
                  direccion: Direccion.Create(model.Provincia, model.Sector, model.casaElectoral)!,
                  model.CantidadVotantes,
                  subCoordiadorId,
                  subCoordinador!
                
                 
               

                  );
                        await dirigenteMultiplicadorRepository.AddAsync(dirigente, cancellationToken);
                        await unitOfWork.SaveChangesAsync(cancellationToken);
                    }
              
                }

                 
                return new GeneralResponse(flag, message);
                

            }catch(Exception ex)
            {

                return new GeneralResponse(false, ex.Message);
            }
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

            if (allUser is null) return null;

            var List = new List<GetUsersWithRoleDTO>();

            foreach (var user in allUser)
            {
                var getUserRole = (await userManager.GetRolesAsync(user)).FirstOrDefault();
                var getRoleInfo = await roleManager.Roles.FirstOrDefaultAsync(r=>r.Name.ToLower() == getUserRole.ToLower());

                List.Add(new GetUsersWithRoleDTO()
                {
                    Name = user.Nombre,
                    Email = user.Email,
                    RoleId = getRoleInfo.Id,
                    RoleName = getRoleInfo.Name,
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
