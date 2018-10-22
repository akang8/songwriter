﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            Assert.AreEqual(limit, newText.Length);
        }

        [TestMethod]
        public void CanShortenTextWithSpaces()
        {
            var limit = 50;
            var spacePosition = RandomValueGenerator.Integer(100, 200);
            var text = $"{RandomValueGenerator.AlphaNumericText(spacePosition)} {RandomValueGenerator.AlphaNumericText(100, 200)}";

            var newText = TextManipulations.ShortenText(text, limit);

            Assert.AreEqual(spacePosition, newText.Length);
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

    }
}
