using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Core
{
    /// <summary>
    /// Named item with an Id
    /// </summary>
    public interface INamedIdentifiable : IIdentifiable
    {
        string Name { get; set; }
    }
}
