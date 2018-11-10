using SongWriter.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.Models
{
    /// <summary>
    /// Represents a document
    /// </summary>
    public class Document : INamedIdentifiable, IText
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public int FolderId { get; set; }

        public string FolderName { get; set; }
    }
}
