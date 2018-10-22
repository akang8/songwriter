using SongWriter.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.TestSupport
{
    public static class ModelGenerator
    {
        public static Document Document()
        {
            return new Document()
            {
                Name = RandomValueGenerator.AlphaNumericText(10, 40),
                Text = RandomValueGenerator.AlphaNumericText(100, 500)
            };
        }
    }
}
