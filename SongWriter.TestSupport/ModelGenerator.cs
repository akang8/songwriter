using SongWriter.Logic;
using SongWriter.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.TestSupport
{
    public static class ModelGenerator
    {
        public static Document Document(int folderId)
        {
            
            return new Document()
            {
                Name = RandomValueGenerator.AlphaNumericText(10, 40),
                FolderId = folderId,
                Text = RandomValueGenerator.AlphaNumericText(100, 500)
            };
        }

        public static Folder Folder()
        {
            return new Folder()
            {
                Name = RandomValueGenerator.AlphaNumericText(10, 40)
            };
        }

    }
}
