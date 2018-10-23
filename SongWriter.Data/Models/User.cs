using SongWriter.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Data.Models
{
    public class User : INamedIdentifiable
    {
        public User()
        {
            this.Documents = new List<Document>();
        }

        public int Id { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// Documents owned by this user
        /// </summary>
        public IList<Document> Documents { get; set; }
    }
}
