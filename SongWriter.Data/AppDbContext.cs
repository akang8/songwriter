using Microsoft.EntityFrameworkCore;
using SongWriter.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Document> Document { get; set; }
    }
}
