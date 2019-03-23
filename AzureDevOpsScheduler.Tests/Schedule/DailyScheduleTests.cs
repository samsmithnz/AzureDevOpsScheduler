using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AzureDevOpsSchedule.Core.Schedule;

namespace AzureDevOpsScheduler.Tests.Schedule
{
    [TestClass]
    public class DailyScheduleTests
    {

        [TestMethod]
        public void TestEveryOneDayForTenOccurences()
        {
            //Arrange
            int numberOfRecurrences = 10;
            ScheduleItem item = new ScheduleItem
            {
                RecurrenceType = ScheduleItem.RecurrenceTypeEnum.Daily,
                DailyEveryNDaysSelected = true,
                DailyEveryNDays = 1,
                RecurrenceStartDate = DateTime.Now,
                RecurrenceEndAfterNSelected = true,
                RecurrenceEndAfterNOccurences = numberOfRecurrences
            };
            DateTime lastDate = item.NormalizeDate(item.RecurrenceStartDate.AddDays(numberOfRecurrences - item.DailyEveryNDays));

            //Act
            item.ProcessFutureDates();

            //Assert
            Assert.AreEqual(item.Name, "Daily every 1 days for a total of " + numberOfRecurrences + " FutureDates");
            DateTime[] dates = item.FutureDates.ToArray();
            Assert.AreEqual(lastDate, dates[dates.Length - 1]);
        }

        [TestMethod]
        public void TestEverySecondDayForTenOccurences()
        {
            //Arrange
            int numberOfRecurrences = 10;
            ScheduleItem item = new ScheduleItem
            {
                RecurrenceType = ScheduleItem.RecurrenceTypeEnum.Daily,
                DailyEveryNDaysSelected = true,
                DailyEveryNDays = 2,
                RecurrenceStartDate = DateTime.Now,
                RecurrenceEndAfterNSelected = true,
                RecurrenceEndAfterNOccurences = numberOfRecurrences
            };
            DateTime lastDate = item.NormalizeDate(item.RecurrenceStartDate.AddDays(numberOfRecurrences * item.DailyEveryNDays - item.DailyEveryNDays));

            //Act
            item.ProcessFutureDates();

            //Assert
            Assert.AreEqual(item.Name, "Daily every " + item.DailyEveryNDays + " days for a total of " + numberOfRecurrences + " FutureDates");
            DateTime[] dates = item.FutureDates.ToArray();
            Assert.AreEqual(lastDate, dates[dates.Length - 1]);
        }

        [TestMethod]
        public void TestEverySeventhDayForTenOccurences()
        {
            //Arrange
            int numberOfRecurrences = 3;
            ScheduleItem item = new ScheduleItem
            {
                RecurrenceType = ScheduleItem.RecurrenceTypeEnum.Daily,
                DailyEveryNDaysSelected = true,
                DailyEveryNDays = 7,
                RecurrenceStartDate = DateTime.Now,
                RecurrenceEndAfterNSelected = true,
                RecurrenceEndAfterNOccurences = numberOfRecurrences
            };
            DateTime lastDate = item.NormalizeDate(item.RecurrenceStartDate.AddDays(numberOfRecurrences * item.DailyEveryNDays - item.DailyEveryNDays));

            //Act
            item.ProcessFutureDates();

            //Assert
            Assert.AreEqual(item.Name, "Daily every " + item.DailyEveryNDays + " days for a total of " + numberOfRecurrences + " FutureDates");
            DateTime[] dates = item.FutureDates.ToArray();
            Assert.AreEqual(lastDate, dates[dates.Length - 1]);
        }

        
        //[TestMethod]
        //public void TestEveryWeekDay()
        //{
        //    //Arrange
        //    int numberOfRecurrences = 10;
        //    ScheduleItem item = new ScheduleItem
        //    {
        //        RecurrenceType = ScheduleItem.RecurrenceTypeEnum.Daily,
        //        DailyEveryWeekDaySelected = true,
        //        RecurrenceStartDate = DateTime.Now,
        //        RecurrenceEndAfterNSelected = true,
        //        RecurrenceEndAfterNOccurences = numberOfRecurrences
        //    };
        //    int daysToAdd = ((int)(numberOfRecurrences / 5) * 7) + (numberOfRecurrences % 5);
        //    DateTime lastDate = item.NormalizeDate(DateTime.Now.AddDays(daysToAdd));


        //    //Act
        //    item.ProcessFutureDates();

        //    //Assert
        //    Assert.AreEqual(item.Name, "Daily every weekday for a total of 10 FutureDates");
        //    DateTime[] dates = item.FutureDates.ToArray();
        //    Assert.AreEqual(lastDate, dates[dates.Length - 1]);
        //}
    }
}
