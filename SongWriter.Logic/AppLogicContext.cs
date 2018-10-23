using SongWriter.Data;
using System;
using Microsoft.Extensions.DependencyInjection;
using SongWriter.Logic.Services.Abstractions;

namespace SongWriter.Logic
{
    /// <summary>
    /// Convenient way to access various services
    /// </summary>
    /// <remarks>
    /// Analogous to existing pattern for EF DbSets in a DbContext, in this case
    /// middle-tier serviecs are contained within a "logic" context.
    /// </remarks>
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

        public IUserService Users
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
