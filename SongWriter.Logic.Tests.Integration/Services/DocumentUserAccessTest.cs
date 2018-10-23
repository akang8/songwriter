using Microsoft.VisualStudio.TestTools.UnitTesting;
using SongWriter.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SongWriter.Logic.Tests.Integration.Services
{
    /// <summary>
    /// Tests to ensure isolation of songs by user
    /// </summary>
    /// <remarks>
    /// Put in separate test since the DocumentTest is setup to use a single login for the entire test
    /// </remarks>
    [TestClass]
    public class DocumentUserAccessTest
    {
        [TestMethod]
        public void CannotGetOthersSong()
        {
            var context = Provider.GetContext();

            // Login as random person
            var userName = RandomValueGenerator.AlphaNumericText(5, 10);
            var userId = context.Users.Register(userName, RandomValueGenerator.AlphaNumericText(10, 20));
            Provider.Login(userId, userName);

            // Add random document and add to get its DB id
            var document = ModelGenerator.Document();
            document.Id = context.Documents.Add(document);

            // Login as other person
            var otherUserName = RandomValueGenerator.AlphaNumericText(5, 10);
            var otherUserId = context.Users.Register(userName, RandomValueGenerator.AlphaNumericText(10, 20));
            Provider.Login(otherUserId, otherUserName);

            // See if saved document's values are correct
            var savedDocument = context.Documents.GetItem(document.Id);

            Assert.IsNull(savedDocument);
        }

        [TestMethod]
        public void CannotGetOthersSongsForGetAll()
        {
            var context = Provider.GetContext();

            // Login as random person
            var userName = RandomValueGenerator.AlphaNumericText(5, 10);
            var userId = context.Users.Register(userName, RandomValueGenerator.AlphaNumericText(10, 20));
            Provider.Login(userId, userName);

            // Add random document and add to get its DB id
            var document = ModelGenerator.Document();
            document.Id = context.Documents.Add(document);

            // Login as other person
            var otherUserName = RandomValueGenerator.AlphaNumericText(5, 10);
            var otherUserId = context.Users.Register(userName, RandomValueGenerator.AlphaNumericText(10, 20));
            Provider.Login(otherUserId, otherUserName);

            // See if saved document's values are correct
            var allDocuments = context.Documents.GetAll();

            var savedDocument = allDocuments.Where(d => d.Id == document.Id).FirstOrDefault();

            Assert.IsNull(savedDocument);
        }

    }
}
