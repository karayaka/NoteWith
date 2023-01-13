using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NoteWith.Persistence.NoteDataContexts
{
	public class DesignTimeDbContextFactory: IDesignTimeDbContextFactory<NoteDataContext>
    {
		public DesignTimeDbContextFactory()
		{
		}

        public NoteDataContext CreateDbContext(string[] args)
        {
            //connectişon stringler burdan yönetilecek
            var serverVersion = new MySqlServerVersion(new Version(10, 3, 35));
            var builder = new DbContextOptionsBuilder<NoteDataContext>();
            var connectionString = "server=213.238.183.40;port=3306;database=cagnazco_noteWith;user=cagnazco_noteWith;password=1I05rv@r3";//server
            //update database yapılacak
            builder.UseMySql(
                connectionString,
                serverVersion,
                options => options.EnableRetryOnFailure()
                );
            return new NoteDataContext(builder.Options);
        }
    }
}

