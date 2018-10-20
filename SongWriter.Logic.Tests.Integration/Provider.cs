using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace SongWriter.Logic.Tests.Integration
{
    /// <summary>
    /// Encapsulates global service provider
    /// </summary>
    public static class Provider
    {
        public static IServiceProvider ServiceProvider;

        public static void SetServiceProvider(IServiceProvider provider)
        {
            // Need to set things after configuing DI
            ServiceProvider = provider;
        }

        public static AppLogicContext GetContext()
        {
            return ServiceProvider.GetService<AppLogicContext>();
        }
    }
}
