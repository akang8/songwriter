using SongWriter.Logic.Processing.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.Processing
{
    /// <summary>
    /// This is a VERY bad implentation of IHasher, currently doesn't hash anything,
    /// don't use in production
    /// </summary>
    /// <remarks>
    /// Just a placeholder for now, replace with better implementation
    /// </remarks>
    public class NonHasher : IHasher
    {
        public bool AreEqual(string hashedSource, string text)
        {
            if (hashedSource.Equals(text))
            {
                return true;
            }

            return false;
        }

        public string Hash(string text)
        {
            return text;
        }
    }
}
