using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using SongWriter.Core;
using SongWriter.Data;
using SongWriter.Logic.Models;

namespace SongWriter.Logic.Startup
{
    public class TestDataInitializer : CoreDataInitializer
    {
        private readonly AppLogicContext context;

        public TestDataInitializer(AppLogicContext context, AppDbContext appData, IOptions<AppConfiguration> optionsConfiguration) 
            : base(appData, optionsConfiguration)
        {
            this.context = context;
        }

        protected override void SeedData()
        {
            var folderId = context.Folders.Add(new Folder()
            {
                Name = "Main"
            });

            context.Folders.Add(new Folder()
            {
                Name = "Red"
            });

            context.Folders.Add(new Folder()
            {
                Name = "Blue"
            });


            context.Documents.Add(new Document()
            {
                Name = "Mary Had A Little Lamb",
                FolderId = folderId,
                Text = @"Mary had a little lamb, little lamb, little lamb
Mary had a little lamb
Whose fleece was white as snow.

And everywhere that Mary went
Mary went,
                Mary went,
                Everywhere that Mary went
The lamb was sure to go."
            });

            context.Documents.Add(new Document()
            {
                Name = "Twinkle, Twinkle, Little Star",
                FolderId = folderId,
                Text = @"Twinkle, twinkle, little star,
How I wonder what you are!
Up above the world so high,
Like a diamond in the sky.

When this blazing sun is gone,
When he nothing shines upon,
Then you show your little light,
Twinkle, twinkle, through the night."
            });


            context.Documents.Add(new Document()
            {
                Name = "Peter Piper",
                FolderId = folderId,
                Text = @"Peter Piper picked a peck of pickled peppers.
A peck of pickled peppers Peter Piper picked.
If Peter Piper picked a peck of pickled peppers,
Where's the peck of pickled peppers Peter Piper picked?"
            });
        }
    }
}
