using Microsoft.Extensions.Options;
using SongWriter.Core;
using SongWriter.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.Startup
{
    public class CoreDataInitializer
    {
        protected readonly AppDbContext appData;
        private readonly IOptions<AppConfiguration> optionsConfiguration;

        public CoreDataInitializer(AppDbContext appData, IOptions<AppConfiguration> optionsConfiguration)
        {
            this.appData = appData;
            this.optionsConfiguration = optionsConfiguration;
        }

        public virtual void Initialize()
        {
            if (this.optionsConfiguration.Value.ResetData)
            {
                // Delete and create (drop/create)
                this.appData.Database.EnsureDeleted();
                this.appData.Database.EnsureCreated();

                this.SeedData();
            }
        }

        protected virtual void SeedData()
        {
            // Do nothing for core implementation
        }
    }
}
