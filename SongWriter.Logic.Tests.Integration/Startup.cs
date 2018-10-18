using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SongWriter.Core;
using SongWriter.Logic.Startup;
using System.IO;

namespace SongWriter.Logic.Tests.Integration
{
    [TestClass]
    public class Startup
    {
        [AssemblyInitialize]
        public static void Initialize(TestContext testContext)
        {
            var services = new ServiceCollection();

            MappingInitializer.Initialize();

            // Set up general logic DI, and specific data initializer
            services.AddSongWriterLogic();
            services.AddScoped<CoreDataInitializer>();

            // Set up configuration
            var configuration = new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                            .Build();

            services.Configure<AppConfiguration>(configuration)
                .AddOptions();

            // Data initialization
            var provider = services.BuildServiceProvider();
            var dataInitializer = provider.GetService<CoreDataInitializer>();

            dataInitializer.Initialize();
        }
    }
}
