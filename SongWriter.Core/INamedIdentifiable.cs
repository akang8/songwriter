using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Core
{
    public interface INamedIdentifiable : IIdentifiable
    {
        string Name { get; set; }
    }
}
