using Microsoft.VisualStudio.TestTools.UnitTesting;
using SongWriter.Logic.Models;

namespace SongWriter.Logic.Tests
{
    [TestClass]
    public class SmokeTest
    {
        [TestMethod]
        public void CanConstructModel()
        {
            // TODO: just a temp test to ensure test harness works, remove later
            var document = new Document();

            Assert.IsNotNull(document);
        }
    }
}
