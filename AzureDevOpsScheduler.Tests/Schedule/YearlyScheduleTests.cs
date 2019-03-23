using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AzureDevOpsSchedule.Core.Schedule;

namespace AzureDevOpsScheduler.Tests.Schedule
{
    [TestClass]
    public class YearlyScheduleTests
    {
        [TestMethod]
        public void TestEveryOneDayInYearForTenOccurences()
        {
            //Arrange
            int numberOfRecurrences = 10;
            ScheduleItem item = new ScheduleItem
            {
                RecurrenceType = ScheduleItem.RecurrenceTypeEnum.Yearly,
                YearlyEveryNYearsSelected = true,
                YearlyEveryNYears = 1,
                RecurrenceStartDate = DateTime.Now,
                RecurrenceEndAfterNSelected = true,
                RecurrenceEndAfterNOccurences = numberOfRecurrences
            };
            DateTime lastDate = item.NormalizeDate(item.RecurrenceStartDate.AddYears((numberOfRecurrences *item.YearlyEveryNYears) - item.YearlyEveryNYears));

            //Act
            item.ProcessFutureDates();

            //Assert
            Assert.AreEqual(item.Name, "Yearly every "+item.YearlyEveryNYears +" years for a total of " + numberOfRecurrences + " FutureDates");
            DateTime[] dates = item.FutureDates.ToArray();
            Assert.AreEqual(lastDate, dates[dates.Length - 1]);
        }

        [TestMethod]
        public void TestEveryOneDayInThreeYearForFiveOccurences()
        {
            //Arrange
            int numberOfRecurrences = 5;
            ScheduleItem item = new ScheduleItem
            {
                RecurrenceType = ScheduleItem.RecurrenceTypeEnum.Yearly,
                YearlyEveryNYearsSelected = true,
                YearlyEveryNYears = 5,
                RecurrenceStartDate = DateTime.Now,
                RecurrenceEndAfterNSelected = true,
                RecurrenceEndAfterNOccurences = numberOfRecurrences
            };
            DateTime lastDate = item.NormalizeDate(item.RecurrenceStartDate.AddYears((numberOfRecurrences * item.YearlyEveryNYears) - item.YearlyEveryNYears));

            //Act
            item.ProcessFutureDates();

            //Assert
            Assert.AreEqual(item.Name, "Yearly every " + item.YearlyEveryNYears + " years for a total of " + numberOfRecurrences + " FutureDates");
            DateTime[] dates = item.FutureDates.ToArray();
            Assert.AreEqual(lastDate, dates[dates.Length - 1]);
        }
        
    }
}
