using SongWriter.Logic.Models;
using SongWriter.Logic.Processing.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.Tests.Integration
{
    /// <summary>
    /// Simple, dumb identifier. Returns the Id/Name set in the class
    /// </summary>
    public class SimpleUserIdentifier : IUserIdentifier
    {
        public User User { get; set; }

        public User Identify()
        {
            return this.User;
        }
    }
}
