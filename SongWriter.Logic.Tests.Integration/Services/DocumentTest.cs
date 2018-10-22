﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SongWriter.Logic.Models;
using SongWriter.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SongWriter.Logic.Tests.Integration.Services
{
    [TestClass]
    public class DocumentTest
    {
        [TestMethod]
        public void CanAccessDocumentService()
        {
            var context = Provider.GetContext();

            Assert.IsNotNull(context.Documents);
        }

        [TestMethod]
        public void CanCallAddDocument()
        {
            var context = Provider.GetContext();

            var document = ModelGenerator.Document();

            var newId = context.Documents.Add(document);

            Assert.AreNotEqual(0, newId);
        }

        [TestMethod]
        public void CanCallGetDocument()
        {
            var context = Provider.GetContext();

            // Add random document and add to get its DB id
            var document = ModelGenerator.Document();
            var newId = context.Documents.Add(document);

            // See if that id will return an object
            var savedDocument = context.Documents.GetItem(newId);

            Assert.IsNotNull(savedDocument);
        }

        [TestMethod]
        public void CanCorrectlyAddDocument()
        {
            var context = Provider.GetContext();

            // Add random document and add to get its DB id
            var document = ModelGenerator.Document();
            document.Id = context.Documents.Add(document);

            // See if saved document's values are correct
            var savedDocument = context.Documents.GetItem(document.Id);
            ModelAssert.AreEqual(document, savedDocument);
        }

        [TestMethod]
        public void CanCallGetAllDocuments()
        {
            var context = Provider.GetContext();
            var documents = context.Documents.GetAll();

            Assert.IsNotNull(documents);
        }

        [TestMethod]
        public void CanGetAllDocuments()
        {
            var context = Provider.GetContext();

            var previousItemsCount = context.Documents.GetAll().Count();
            var newItemsCount = RandomValueGenerator.Integer(5, 10);

            // Add random document and add to get its DB id
            var newDocuments = new List<Document>();
            for (var i = 0; i < newItemsCount; i++)
            {
                var document = ModelGenerator.Document();
                document.Id = context.Documents.Add(document);

                newDocuments.Add(document);
            }

            var savedItems = context.Documents.GetAll();

            var currentItemsCount = savedItems.Count();

            // Check to see if number of items retrieved matches
            Assert.AreEqual(previousItemsCount + newItemsCount, currentItemsCount);

            // Check if items retreived have correct values
            foreach(var newDocument in newDocuments)
            {
                var savedItem = savedItems.Where(i => i.Id == newDocument.Id).SingleOrDefault();

                Assert.IsNotNull(savedItems);

                ModelAssert.AreEqual(newDocument, savedItem);
            }
        }


        [TestMethod]
        public void CanCallSaveDocument()
        {
            var context = Provider.GetContext();

            // Get existing item
            var newId = context.Documents.Add(ModelGenerator.Document());
            var document = context.Documents.GetItem(newId);

            // Save it
            context.Documents.Save(document);
        }

        [TestMethod]
        public void CanSaveDocumentName()
        {
            var context = Provider.GetContext();

            var newId = context.Documents.Add(ModelGenerator.Document());

            // Edit existing document name and save
            var document = context.Documents.GetItem(newId);
            document.Name = RandomValueGenerator.AlphaNumericText(10, 200);
            context.Documents.Save(document);

            // Get saved document and check values
            var savedDocument = context.Documents.GetItem(newId);

            ModelAssert.AreEqual(document, savedDocument);
        }

        [TestMethod]
        public void CanSaveDocumentText()
        {
            var context = Provider.GetContext();

            var newId = context.Documents.Add(ModelGenerator.Document());

            // Edit existing document name and save
            var document = context.Documents.GetItem(newId);
            document.Text = RandomValueGenerator.AlphaNumericText(200, 2000);
            context.Documents.Save(document);

            // Get saved document and check values
            var savedDocument = context.Documents.GetItem(newId);

            ModelAssert.AreEqual(document, savedDocument);
        }

        [TestMethod]
        public void CanCallRemoveDocument()
        {
            var context = Provider.GetContext();

            var newId = context.Documents.Add(ModelGenerator.Document());

            context.Documents.Remove(newId);
        }

        [TestMethod]
        public void CanRemoveDocument()
        {
            var context = Provider.GetContext();

            // Ensure at least one item exists
            context.Documents.Add(ModelGenerator.Document());

            // Get items
            var items = context.Documents.GetAll().ToList(); // Call ToList to ensure query runs now

            // Remove one of those
            var itemToRemove = items.RandomItem();
            context.Documents.Remove(itemToRemove.Id);

            var savedDocument = context.Documents.GetItem(itemToRemove.Id);
            var savedItems = context.Documents.GetAll().ToList();

            Assert.IsNull(savedDocument);
            // Ensure one item has been removed
            Assert.AreEqual(items.Count() - 1, savedItems.Count());
        }
    }
}
