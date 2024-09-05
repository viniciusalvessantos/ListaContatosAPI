using lista_de_contatos.Application.Commands.Delete.Contatos;
using lista_de_contatos.Application.Commands.Delete.Pessoas;
using lista_de_contatos.Application.Commands.Register.Contatos;
using lista_de_contatos.Application.Commands.Register.Pessoas;
using lista_de_contatos.Application.Commands.Register.Usuarios;
using lista_de_contatos.Application.Commands.Update.Contatos;
using lista_de_contatos.Application.Commands.Update.Pessoas;
using lista_de_contatos.Domain.Entities;
using lista_de_contatos.Domain.Interfaces;
using lista_de_contatos.Domain.Utilities;
using lista_de_contatos.Infrastructure.Repository;
using lista_de_contatos.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_de_contatos.Infrastructure.Startup {
   public static class ListaContatosModuleStartup {
        public static IServiceCollection AddListContModule(this IServiceCollection services, IConfiguration configuration) {


            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(RegisterUsuariosCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(RegisterPessoasCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(RegisterContatosCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(DeleteContatosCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(DeletePessoasCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateContatosCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdatePessoasCommand).Assembly);
                // Adiciona os handlers localizados no mesmo assembly que a classe Startup
            });
            services.AddDbContext<ApplicationDbContext>(x => {
                var connectionString = configuration["Modules:listModules:DbConnectionString"];
                x.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
            });
            services.AddIdentity<ApplicationUser, IdentityRole> (options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders(); ;

            services.Configure<IdentityOptions>(options => {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // AppUser settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt => {
                var key = Encoding.ASCII.GetBytes(configuration["Jwt:Secret"]!);
                var issuer = configuration["Jwt:Issuer"];
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidAudiences = new List<string>() { issuer! },
                    ValidateAudience = true,
                    RequireExpirationTime = false,
                    ValidateLifetime = true
                };
            });


            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            return services;

        }
    }
}
