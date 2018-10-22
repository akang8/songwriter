using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.Utils
{
    public static class TextManipulations
    {
        public static int SummaryLength = 200;

        public static string ShortenTextForSummary(this string value)
        {
            return ShortenText(value, SummaryLength);
        }

        public static string ShortenText(this string value, int length)
        {
            // Based on: https://stackoverflow.com/a/1613918

            if (value == null || value.Length < length)
            {
                return value;
            }

            if (value.IndexOf(" ", length) == -1)
            {
                // Return truncated despite no spaces
                return $"{value.Substring(0, length)}...";
            }

            return $"{value.Substring(0, value.IndexOf(" ", length))}...";
        }
    }
}
