using System;

namespace SongWriter.Core
{
    /// <summary>
    /// Identifiable by an int id
    /// </summary>
    public interface IIdentifiable
    {
        int Id { get; set; }
    }
}
