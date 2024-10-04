using Microsoft.EntityFrameworkCore;
using OneToMany.DataAccess;

namespace OneToMany.Server.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void ConfigureDatabase(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
            builder.Services.AddDbContext<MainContext>(options =>
              options.UseSqlServer(connectionString));
        }
    }
}
