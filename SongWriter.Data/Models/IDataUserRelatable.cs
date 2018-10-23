using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Data.Models
{
    public interface IDataUserRelatable
    {
        /// <summary>
        /// The user that owns the item
        /// </summary>
        User User { get; set; }

        int UserId { get; set; }
    }
}
