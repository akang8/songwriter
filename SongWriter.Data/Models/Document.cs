using SongWriter.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Data.Models
{
    public class Document : INamedIdentifiable, IText
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }
    }
}
