using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // get use in memory database configuration
            bool useInMemoryDatabase = Convert.ToBoolean(configuration.GetSection("UseInMemoryDatabase").Value);

            // set db context
            if (useInMemoryDatabase == true)
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                // set connection string string
                // and server version
                var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
                var serverVersion = ServerVersion.AutoDetect(connectionString);

                // get environment
                string? env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                bool isInDevMode = env == "Development" || env == "Staging";

                // set db context depending on mode
                if (isInDevMode == true)
                {
                    // add db context
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseMySql(
                            connectionString,
                            serverVersion,
                           b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                        // The following three options help with debugging, but should
                        // be changed or removed for production.
                        .LogTo(Console.WriteLine, LogLevel.Information)
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors());
                }
                else
                {
                    // add db context
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseMySql(
                            connectionString,
                            serverVersion,
                           b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
                }
            }
        }
    }
}
