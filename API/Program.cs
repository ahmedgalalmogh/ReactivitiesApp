using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Presistence;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host= CreateHostBuilder(args).Build();
           using var scope=host.Services.CreateScope();
           var services=scope.ServiceProvider;
        try
        {
            services.GetRequiredService<DataContext>().Database.Migrate();

        }
        catch (Exception ex)
        {
            var logger=services.GetRequiredService<Logger<Program>>();
            logger.LogError(ex,"error in migration");
        
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
