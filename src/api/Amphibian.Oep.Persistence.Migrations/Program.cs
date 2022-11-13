using System;
using System.Reflection;
using System.IO;

using DbUp;
using DbUp.SqlServer;

using Amphibian.Oep.Configuration;
using Microsoft.Extensions.Configuration;

namespace Amphibian.Oep.Persistence.Migrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            var configurations = OepApiConfiguration.LoadFromJsonConfig(null,Path.Combine(Directory.GetCurrentDirectory(), "../../../../Amphibian.Oep.Api"));

            var configuration = configurations.Item2;

            if (configuration.Database.MigrateSchema)
            {
                var result = MigrationRunner.RunMigrations(configuration.Database.ConnectionString, configuration.Database.MigrateInitialData, configuration.Database.MigrateTestData);

                if (!result.Successful)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(result.Error);
                    Console.ResetColor();
                    Console.ReadLine();
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Migrating Schema is Disabled in Configuration");
            }
        }

        
    }
}