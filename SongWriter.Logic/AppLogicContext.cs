using SongWriter.Data;
using System;
using Microsoft.Extensions.DependencyInjection;
using SongWriter.Logic.Services.Abstractions;

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

        public IDocumentService Documents
        {
            get
            {
                return this.services.GetService<IDocumentService>();
            }
        }
    }
}
