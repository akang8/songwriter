using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.Processing.Abstractions
{
    public interface IHasher
    {
        string Hash(string text);

        bool AreEqual(string hashedSource, string text);
    }
}
