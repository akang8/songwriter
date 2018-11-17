using Microsoft.VisualStudio.TestTools.UnitTesting;
using SongWriter.Logic.Utils;
using SongWriter.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.Tests
{
    [TestClass]
    public class TextManipulationsTest
    {
        private static int EllipsisLength = 3;
        [TestMethod]
        public void CanCallShortenText()
        {
            TextManipulations.ShortenText(RandomValueGenerator.AlphaNumericText(100, 200), 50);
        }

        [TestMethod]
        public void CanShortenTextWithoutSpaces()
        {
            var limit = 50;
            var newText = TextManipulations.ShortenText(RandomValueGenerator.AlphaNumericText(100, 200), limit);

            Assert.AreEqual(limit + EllipsisLength, newText.Length);
        }

        [TestMethod]
        public void CanShortenTextWithSpaces()
        {
            var limit = 50;
            var spacePosition = RandomValueGenerator.Integer(100, 200);
            var text = $"{RandomValueGenerator.AlphaNumericText(spacePosition)} {RandomValueGenerator.AlphaNumericText(100, 200)}";

            var newText = TextManipulations.ShortenText(text, limit);

            Assert.AreEqual(spacePosition + EllipsisLength, newText.Length);
        }


        [TestMethod]
        public void CanShortenTextWithNull()
        {
            var newText = TextManipulations.ShortenText(null, 50);

            Assert.IsNull(newText);
        }

        [TestMethod]
        public void CanShortenTextByNotTruncatingShortText()
        {
            var limit = 50;
            var textLength = RandomValueGenerator.Integer(30, 40);
            var newText = TextManipulations.ShortenText(RandomValueGenerator.AlphaNumericText(textLength), limit);

            Assert.AreEqual(textLength, newText.Length);
        }

        [TestMethod]
        public void CanStripLyricMarkerWhenSummarizing()
        {
            var text = $"#{RandomValueGenerator.AlphaNumericTextWithSpaces(10, 20)}\n#{RandomValueGenerator.AlphaNumericTextWithSpaces(10, 20)}";
            var newText = TextManipulations.Summarize(text);

            Assert.IsFalse(newText.Contains('#'));
        }

        [TestMethod]
        public void CanStripChordsWhenSummarizing()
        {
            var chords = $"@{RandomValueGenerator.AlphaNumericTextWithSpaces(10, 20)}";
            var text = $"{chords}\n{RandomValueGenerator.AlphaNumericTextWithSpaces(10, 20)}";
            var newText = TextManipulations.Summarize(text);

            Assert.IsFalse(newText.Contains('@'));
            Assert.IsFalse(newText.Contains(chords.Substring(1)));
        }

        [TestMethod]
        public void CanStripAnnotationsWhenSummarizing()
        {
            var annotation = $"!{RandomValueGenerator.AlphaNumericTextWithSpaces(10, 20)}";
            var text = $"{annotation}\n{RandomValueGenerator.AlphaNumericTextWithSpaces(10, 20)}";
            var newText = TextManipulations.Summarize(text);

            Assert.IsFalse(newText.Contains('!'));
            Assert.IsFalse(newText.Contains(annotation.Substring(1)));
        }

    }
}
