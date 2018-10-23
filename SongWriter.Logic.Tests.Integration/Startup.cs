using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SongWriter.Core;
using SongWriter.Logic.Processing;
using SongWriter.Logic.Processing.Abstractions;
using SongWriter.Logic.Startup;
using SongWriter.TestSupport;
using System;
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
            string currentDirectory = GetTestDirectory();

            var configuration = new ConfigurationBuilder()
                                            .SetBasePath(currentDirectory)
                                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                            .Build();

            services.Configure<AppConfiguration>(configuration)
                .AddOptions();


            // Set initial identity
            var userIdentifier = new SimpleUserIdentifier();
            services.AddSingleton<IUserIdentifier>(userIdentifier);

            // Data initialization
            var provider = services.BuildServiceProvider();
            var dataInitializer = provider.GetService<CoreDataInitializer>();

            dataInitializer.Initialize();
            Provider.Setup(provider, userIdentifier);
        }

        private static string GetTestDirectory()
        {
            // This is a bit of a hack but we walk up the directories until we get where we want
            var currentDirectory = Directory.GetCurrentDirectory();
            while (!currentDirectory.EndsWith("SongWriter.Logic.Tests.Integration"))
            {
                currentDirectory = Directory.GetParent(currentDirectory).FullName;
            }

            return currentDirectory;
        }

        [TestMethod]
        public void SmokeTest()
        {
            var context = Provider.GetContext();

            Assert.IsNotNull(context);
            Assert.IsNotNull(context.Documents);
        }
    }
}
