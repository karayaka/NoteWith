using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NoteWith.Persistence.NoteDataContexts;

namespace NoteWith.Persistence.PersistenceRegistirations
{
	public static class PersistenceRegistiration
	{
        public static void AddNoteDbContext(this IServiceCollection services, string connectionString)
        {
            var serverVersion = new MySqlServerVersion(new Version(10, 3, 35));
            services.AddDbContext<NoteDataContext>(options =>
            {
                options.UseMySql(
                    connectionString,
                    serverVersion,
                    options => options.EnableRetryOnFailure());
            });
        }
    }
}

