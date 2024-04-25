using BE_ProyectoA.Core.Application.Interfaces;
using BE_ProyectoA.Core.Domain.Entities.Authentication;
using BE_ProyectoA.Persistence.Identity.Context;
using BE_ProyectoA.Persistence.Identity.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BE_ProyectoA.Persistence.Identity.DependencyInjection
{
    public static class ServiceContainer
    {

        public static IServiceCollection AddInfraestructureIdentity(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<IdentityContext>(o => o.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));
            services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddSignInManager();

            services.AddAuthentication
                (opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }


                ).AddJwtBearer(opt =>
                {

                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))


                    };
                });

            services.AddAuthentication();
            services.AddAuthorization();
            services.AddCors
                (
                options =>
                {
                    options.AddPolicy("WebUi", builder =>
                    builder.WithOrigins("https://localhost:4000")
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .AllowAnyHeader()
                    );
                    
                });
            services.AddScoped<IAccount, AccountRepository>();
            return services;
            
        
        
        
        }

    }
}
