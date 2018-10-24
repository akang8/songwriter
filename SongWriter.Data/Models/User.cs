using SongWriter.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Password { get; set; }

        /// <summary>
        /// Documents owned by this user
        /// </summary>
        public IList<Document> Documents { get; set; }
    }
}
