using Microsoft.EntityFrameworkCore;
using SongWriter.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Document> Documents { get; set; }
    }
}
