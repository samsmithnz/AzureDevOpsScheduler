using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AzureDevOpsSchedule.Core.AzureDevOps;

namespace AzureDevOpsScheduler.Tests.AzureDevOps
{
    [TestClass]
    public class PBITests
    {
        [TestMethod]
        public void TestPBI()
        {
            //Arrange
            ADPBI pbi = new ADPBI
            {
                Title = "New PBI",
                Description = "Description test"
            };
            pbi.Tags.Add("Test");

            //Act

            //Assert
            Assert.AreEqual(pbi.Title, "New PBI");
            Assert.AreEqual(pbi.Description, "Description test");
            Assert.AreEqual(pbi.Tags[0], "Test");
        }
    }
}
