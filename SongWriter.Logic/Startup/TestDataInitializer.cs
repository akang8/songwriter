using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using SongWriter.Core;
using SongWriter.Data;
using SongWriter.Logic.Models;

namespace SongWriter.Logic.Startup
{
    public class TestDataInitializer : CoreDataInitializer
    {
        private readonly AppLogicContext context;

        public TestDataInitializer(AppLogicContext context, AppDbContext appData, IOptions<AppConfiguration> optionsConfiguration) 
            : base(appData, optionsConfiguration)
        {
        }

        protected override void SeedData()
        {
            context.Documents.Add(new Document()
            {
                Name = "Some Document",
                Text = "This is some initial text"
            });
        }
    }
}
