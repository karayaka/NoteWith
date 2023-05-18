using System;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using NoteWith.Application.Repositorys;
using NoteWith.Application.Services;
using NoteWith.Infrastructure.Repositorys;
using NoteWith.Infrastructure.Services;
using Microsoft.IdentityModel.Tokens;

namespace NoteWith.Infrastructure.InfrastructureRegistirations
{
	public static class InfrastructureRegistiration
	{
		public static void AddMapper(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
		}

		public static void AddServices(this IServiceCollection services)
		{
			services.AddScoped<IEmailService, EmailService>();
			services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();
            services.AddScoped<INotificationServices, NotificationServices>();
        }
		public static void AddRepositorys(this IServiceCollection services)
		{
			services.AddScoped<ISecurityRepository, SecurityRepository>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

		public static void AddJWTAuthentication(this IServiceCollection services,string secretToken)
		{
            var key = Encoding.ASCII.GetBytes(secretToken);
            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,

                };

            });
        }
    }
}

