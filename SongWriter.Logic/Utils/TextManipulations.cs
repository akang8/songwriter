using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SongWriter.Logic.Utils
{
    public static class TextManipulations
    {
        public static int SummaryLength = 200;

        public static string Summarize(this string value)
        {
            var cleanedValue = CleanFormatting(value);

            return ShortenText(cleanedValue, SummaryLength);
        }

        private static string CleanFormatting(string value)
        {
            // Replace annotations and chords
            var lines = value.Split('\n');
            var cleanedValue = new StringBuilder();
            string[] prefixes = { "!", "@" };

            foreach (var line in lines)
            {
                // Only add text or lyric lines
                if (!prefixes.Any(p => line.StartsWith(p)))
                {
                    if (line.StartsWith("#"))
                    {
                        // If its a lyric line, remove marker
                        cleanedValue.AppendLine(line.Substring(1));
                    }
                    else
                    {
                        // If text, add it
                        cleanedValue.AppendLine(line);
                    }
                }
            }

            return cleanedValue.ToString();
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
