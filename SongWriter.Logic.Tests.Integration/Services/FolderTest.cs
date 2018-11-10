using Microsoft.VisualStudio.TestTools.UnitTesting;
using SongWriter.Logic.Models;
using SongWriter.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SongWriter.Logic.Tests.Integration.Services
{
    [TestClass]
    public class FolderTest
    {
        [TestMethod]
        public void CanAccessFolderService()
        {
            var context = Provider.GetContext();

            Assert.IsNotNull(context.Folders);
        }

        [TestMethod]
        public void CanCallAddFolder()
        {
            var context = Provider.GetContext();

            var folder = ModelGenerator.Folder();

            var newId = context.Folders.Add(folder);

            Assert.AreNotEqual(0, newId);
        }

        [TestMethod]
        public void CanCallGetFolder()
        {
            var context = Provider.GetContext();

            // Add random Folder and add to get its DB id
            var folder = ModelGenerator.Folder();
            var newId = context.Folders.Add(folder);

            // See if that id will return an object
            var savedFolder = context.Folders.GetItem(newId);

            Assert.IsNotNull(savedFolder);
        }

        [TestMethod]
        public void CanCorrectlyAddFolder()
        {
            var context = Provider.GetContext();

            // Add random Folder and add to get its DB id
            var folder = ModelGenerator.Folder();
            folder.Id = context.Folders.Add(folder);

            // See if saved Folder's values are correct
            var savedFolder = context.Folders.GetItem(folder.Id);
            ModelAssert.AreEqual(folder, savedFolder);
        }

        [TestMethod]
        public void CanCallGetAllFolders()
        {
            var context = Provider.GetContext();
            var folders = context.Folders.GetAll();

            Assert.IsNotNull(folders);
        }

        [TestMethod]
        public void CanGetAllFolders()
        {
            var context = Provider.GetContext();

            var previousItemsCount = context.Folders.GetAll().Count();
            var newItemsCount = RandomValueGenerator.Integer(5, 10);

            // Add random Folder and add to get its DB id
            var newFolders = new List<Folder>();
            for (var i = 0; i < newItemsCount; i++)
            {
                var folder = ModelGenerator.Folder();
                folder.Id = context.Folders.Add(folder);

                newFolders.Add(folder);
            }

            var savedItems = context.Folders.GetAll();

            var currentItemsCount = savedItems.Count();

            // Check to see if number of items retrieved matches
            Assert.AreEqual(previousItemsCount + newItemsCount, currentItemsCount);

            // Check if items retreived have correct values
            foreach (var newFolder in newFolders)
            {
                var savedItem = savedItems.Where(i => i.Id == newFolder.Id).SingleOrDefault();

                Assert.IsNotNull(savedItems);

                ModelAssert.AreEqual(newFolder, savedItem);
            }
        }


        [TestMethod]
        public void CanCallSaveFolder()
        {
            var context = Provider.GetContext();

            // Get existing item
            var newId = context.Folders.Add(ModelGenerator.Folder());
            var folder = context.Folders.GetItem(newId);

            // Save it
            context.Folders.Save(folder);
        }

        [TestMethod]
        public void CanSaveFolderName()
        {
            var context = Provider.GetContext();

            var newId = context.Folders.Add(ModelGenerator.Folder());

            // Edit existing Folder name and save
            var folder = context.Folders.GetItem(newId);
            folder.Name = RandomValueGenerator.AlphaNumericText(10, 200);
            context.Folders.Save(folder);

            // Get saved Folder and check values
            var savedFolder = context.Folders.GetItem(newId);

            ModelAssert.AreEqual(folder, savedFolder);
        }

        [TestMethod]
        public void CanCallRemoveFolder()
        {
            var context = Provider.GetContext();

            var newId = context.Folders.Add(ModelGenerator.Folder());

            context.Folders.Remove(newId);
        }

        [TestMethod]
        public void CanRemoveFolder()
        {
            var context = Provider.GetContext();

            // Ensure at least one item exists
            context.Folders.Add(ModelGenerator.Folder());

            // Get items
            var items = context.Folders.GetAll().ToList(); // Call ToList to ensure query runs now

            // Remove one of those
            var itemToRemove = items.RandomItem();
            context.Folders.Remove(itemToRemove.Id);

            var savedFolder = context.Folders.GetItem(itemToRemove.Id);
            var savedItems = context.Folders.GetAll().ToList();

            Assert.IsNull(savedFolder);
            // Ensure one item has been removed
            Assert.AreEqual(items.Count() - 1, savedItems.Count());
        }
    }
}
