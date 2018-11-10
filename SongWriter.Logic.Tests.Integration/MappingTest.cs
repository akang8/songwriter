using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.Tests.Integration
{
    [TestClass]
    public class MappingTest
    {
        [TestMethod]
        public void MappingsAreValid()
        {
            Mapper.AssertConfigurationIsValid();
        }
    }
}
