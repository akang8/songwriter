using SongWriter.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SongWriter.Data.Models
{
    /// <summary>
    /// Represents the data storage of a document
    /// </summary>
    public class Document : INamedIdentifiable, IText, IDataUserRelatable
    {
        public int Id { get; set; }

        [MaxLength(300)]
        public string Name { get; set; }

        [MaxLength]
        public string Text { get; set; }

        /// <summary>
        /// User that owns this document
        /// </summary>
        public User User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
