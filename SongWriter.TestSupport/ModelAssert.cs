using Microsoft.VisualStudio.TestTools.UnitTesting;
using SongWriter.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.TestSupport
{
    public static class ModelAssert
    {
        public static void AreEqual(Document expected, Document actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Text, actual.Text);
        }

        public static void AreEqual(Document expected, DocumentSummary actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
        }

        public static void AreEqual(Folder expected, Folder actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
        }

    }
}
