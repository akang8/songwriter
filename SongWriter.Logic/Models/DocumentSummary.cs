using SongWriter.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.Models
{
    public class DocumentSummary : INamedIdentifiable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SummaryText { get; set; }
    }
}
