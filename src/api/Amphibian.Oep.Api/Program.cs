using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Serilog;
using Serilog.AspNetCore;
using Serilog.Events;
using Amphibian.Oep.Configuration;

namespace Amphibian.Oep.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PrintBanners();

            var builder = CreateHostBuilder(args);
            
            var host = builder.Build();
            host.Run();
        }

        public static void PrintBanners()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Patrol.Ski"));

            var env = OepApiConfiguration.Environment;
            if (env == "Local")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (env == "Development")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else if (env == "Test")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (env == "Production")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine(Figgle.FiggleFonts.SlantSmall.Render(env));


            Console.ForegroundColor = ConsoleColor.White;
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            

            var builder = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var configurations = OepApiConfiguration.LoadFromJsonConfig(config);

            }).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
                    .UseKestrel()
                    .UseStartup<Startup>();
            })
            .UseSerilog((hostingContext, loggerConfiguration) =>
            {
                loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration)
                .Enrich.FromLogContext();
            });

            return builder;
        }
    }
}
