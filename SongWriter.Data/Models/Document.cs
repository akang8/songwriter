using SongWriter.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SongWriter.Data.Models
{
    /// <summary>
    /// Represents the data storage of a document
    /// </summary>
    public class Document : INamedIdentifiable, IText
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength]
        public string Text { get; set; }
    }
}
