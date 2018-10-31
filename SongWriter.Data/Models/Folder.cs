using SongWriter.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Data.Models
{
    public class Folder : INamedIdentifiable
    {
        public Folder()
        {
            this.Documents = new List<Document>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Document> Documents { get; set; }
    }
}
