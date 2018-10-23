using SongWriter.Data;
using System;
using Microsoft.Extensions.DependencyInjection;
using SongWriter.Logic.Services.Abstractions;
using SongWriter.Logic.Processing.Abstractions;

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

        public IUserIdentifier Identifier
        {
            get
            {
                var identifier = this.services.GetService<IUserIdentifier>();

                return identifier;
            }
        }

        public string UserName
        {
            get
            {
                return this.Identifier.Identify()?.Name;
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
                return this.services.GetService<IUserService>();
            }
        }
    }
}
