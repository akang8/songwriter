using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SongWriter.Logic.Utils
{
    public static class TextManipulations
    {
        public static int SummaryLength = 200;
        public static string AnnotationMarker = "!";
        public static string ChordMarker = "@";
        public static string LyricMarker = "#";
        public static string SectionNameStartMarker = "[";
        public static string SectionNameEndMarker = "]";

        public static string Summarize(this string value)
        {
            var cleanedValue = CleanFormatting(value);

            return ShortenText(cleanedValue, SummaryLength);
        }

        private static string CleanFormatting(string value)
        {
            // Clean sections
            value = Regex.Replace(value, @"\" + SectionNameStartMarker + @".*?\" + SectionNameEndMarker, string.Empty);

            // Replace annotations and chords
            var lines = value.Split('\n');
            var cleanedValue = new StringBuilder();
            string[] prefixes = { AnnotationMarker, ChordMarker };

            foreach (var line in lines)
            {
                // Only add text or lyric lines
                if (!prefixes.Any(p => line.StartsWith(p)))
                {
                    if (line.StartsWith(LyricMarker))
                    {
                        // If its a lyric line, remove marker
                        cleanedValue.AppendLine(line.Substring(1).Trim());
                    }
                    else
                    {
                        // If text, add it
                        cleanedValue.AppendLine(line.Trim());
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
                return $"{value.Substring(0, length)}...".Trim();
            }

            return $"{value.Substring(0, value.IndexOf(" ", length))}...".Trim();
        }
    }
}
