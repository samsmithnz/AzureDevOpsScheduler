using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AzureDevOpsSchedule.Core.AzureDevOps;
using AzureDevOpsScheduler.Core.Schedule;

namespace AzureDevOpsScheduler.Tests.AzureDevOps
{
    [TestClass]
    public class FeatureTests
    {

        [TestMethod]
        public void TestFeature()
        {
            //Arrange
            ADFeature feature = new ADFeature
            {
                Title = "New feature",
                Description = "Description test",
                TargetDate = new DateTime(2019, 3, 23)

            };
            feature.Tags.Add("Test");
            ScheduleItem item = new ScheduleItem();
            feature.RecurringScheduleItem = item;
            ADPBI pbi = new ADPBI
            {
                Title = "child pbi"
            };
            feature.PBIs.Add(pbi);

            //Act

            //Assert
            Assert.AreEqual(feature.Title, "New feature");
            Assert.AreEqual(feature.Description, "Description test");
            Assert.AreEqual(feature.Tags[0], "Test");
            Assert.AreEqual(feature.TargetDate, new DateTime(2019, 3, 23));
            Assert.IsTrue(feature.RecurringScheduleItem != null);
            Assert.IsTrue(feature.PBIs.Count == 1);
            Assert.IsTrue(feature.PBIs[0].Title == "child pbi");
        }

    }
}
