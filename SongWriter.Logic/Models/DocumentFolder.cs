using SongWriter.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.Models
{
    public class DocumentFolder : INamedIdentifiable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Document> Documents { get; set; }
    }
}
