using SongWriter.Logic.Models;
using SongWriter.Logic.Processing.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.Tests.Integration
{
    /// <summary>
    /// Simple, dumb identifier. Returns the Name set in the class
    /// </summary>
    public class SimpleUserIdentifier : IUserIdentifier
    {
        public string Name { get; set; }

        public string Identify()
        {
            return this.Name;
        }
    }
}
