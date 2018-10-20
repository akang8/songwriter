﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SongWriter.TestSupport
{
    /// <summary>
    /// Generates random values and strings for test purposes
    /// </summary>
    public static class RandomValueGenerator
    {
        private static Random Random = new Random();

        public static int Integer(int min, int max)
        {
            return Random.Next(min, max);
        }

        public static string @String(int minLength, int maxLength)
        {
            var characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            var length = Integer(minLength, maxLength);
            var result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[Random.Next(characters.Length)]);
            }
            return result.ToString();
        }


        public static T RandomItem<T>(this IEnumerable<T> enumerable)
        {
            var index = Integer(0, enumerable.Count());

            return enumerable.ElementAt(index);
        }

    }
}
