using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using SongWriter.Logic.Models;
using SongWriter.Logic.Processing;

namespace SongWriter.Logic.Tests.Integration
{
    /// <summary>
    /// Encapsulates global service provider
    /// </summary>
    public static class Provider
    {
        private static IServiceProvider ServiceProvider;

        private static SimpleUserIdentifier UserIdentifier;

        public static void Setup(IServiceProvider provider, SimpleUserIdentifier userIdentifier)
        {
            // Need to set things after configuing DI
            ServiceProvider = provider;
            UserIdentifier = userIdentifier;
        }

        public static AppLogicContext GetContext()
        {
            return ServiceProvider.GetService<AppLogicContext>();
        }

        public static void SimulateLogin(User user)
        {
            SimulateLogin(user.Id, user.Name);
        }

        public static void SimulateLogin(int id, string userName)
        {
            UserIdentifier.Id = id;
            UserIdentifier.Name = userName;
        }
    }
}
