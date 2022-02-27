using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Store.Dominio.Entidades;
using Store.Persistencia;
using Store.Persistencia.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Store.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Modificacion para que al iniciar mi proyecto se ejecuten mis migraciones
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {

                var services = scope.ServiceProvider;
                var loggerfactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    await context.Database.MigrateAsync();
                    await DatosSemilla.CargarData(context, loggerfactory);

                    var userManager = services.GetRequiredService<UserManager<Usuario>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    var IdentityContext = services.GetRequiredService<SeguridadDbContext>();
                    await IdentityContext.Database.MigrateAsync();
                    await SeguridadDatoSemilla.seguridadatosemilla(userManager,roleManager);


                }
                catch (Exception ex)
                {
                    var logger = loggerfactory.CreateLogger<Program>();
                    logger.LogError(ex, "Error en el proceso de migración");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
