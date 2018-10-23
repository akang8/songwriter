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
        public int Id { get; set; }

        public string Name { get; set; }

        public User Identify()
        {
            return new User()
            {
                Id = this.Id,
                Name = this.Name
            };
        }
    }
}
