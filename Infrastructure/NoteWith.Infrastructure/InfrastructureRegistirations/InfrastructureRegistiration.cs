using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NoteWith.Application.Repositorys;
using NoteWith.Application.Services;
using NoteWith.Infrastructure.Repositorys;
using NoteWith.Infrastructure.Services;

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
		}
		public static void AddRepositorys(this IServiceCollection services)
		{
			services.AddTransient<ISecurityRepository, SecurityRepository>();
		}
	}
}

