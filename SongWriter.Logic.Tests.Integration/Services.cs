using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace SongWriter.Logic.Tests.Integration
{
    /// <summary>
    /// Encapsulates global service provider
    /// </summary>
    public static class Services
    {
        public static IServiceProvider ServiceProvider;

        public static void SetServiceProvider(IServiceProvider provider)
        {
            // Need to set things after configuing DI
            ServiceProvider = provider;
        }

        /// <summary>
        /// Convenience method to save a navigation property
        /// </summary>
        public static T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }
    }
}
