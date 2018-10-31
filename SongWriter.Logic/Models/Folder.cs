using SongWriter.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.Models
{
    public class Folder : INamedIdentifiable
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
