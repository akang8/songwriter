using SongWriter.Data;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace SongWriter.Logic
{
    public class AppLogicContext
    {

        private readonly IServiceProvider services;
        public AppLogicContext(IServiceProvider services)
        {
            this.services = services;
        }

        internal AppDbContext AppData
        {
            get
            {
                return this.services.GetService<AppDbContext>();
            }
        }
    }
}
