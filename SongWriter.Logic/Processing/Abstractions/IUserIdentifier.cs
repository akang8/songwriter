using SongWriter.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.Processing.Abstractions
{
    public interface IUserIdentifier
    {
        string Identify();
    }
}
