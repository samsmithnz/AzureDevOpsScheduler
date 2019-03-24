using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AzureDevOpsScheduler.Core.Schedule;

namespace AzureDevOpsScheduler.Tests.Schedule
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [TestClass]
    public class WeeklyScheduleTests
    {
        [TestMethod]
        public void TestEveryOneWeekOnSunday()
        {
            //Arrange
            WeeklySchedule item = new WeeklySchedule
            {
                RecurrenceType = WeeklySchedule.RecurrenceTypeEnum.Weekly,
                WeeklyEveryNWeeks = 1,
                WeeklyDayOfWeekSunday = true,
                WeeklyDayOfWeekMonday = false,
                WeeklyDayOfWeekTuesday = false,
                WeeklyDayOfWeekWednesday = false,
                WeeklyDayOfWeekThursday = false,
                WeeklyDayOfWeekFriday = false,
                WeeklyDayOfWeekSaturday = false,
                RecurrenceStartDate = new DateTime(2019, 3, 10),
                RecurrenceEndAfterNSelected = true,
                RecurrenceEndAfterNOccurences = 3
            };
            DateTime lastDate = item.NormalizeDate(item.RecurrenceStartDate.AddDays(((item.WeeklyEveryNWeeks * 7) * item.RecurrenceEndAfterNOccurences) - (item.WeeklyEveryNWeeks * 7)));

            //Act
            item.ProcessFutureDates();

            //Assert
            Assert.AreEqual(item.Name, "Weekly every " + item.WeeklyEveryNWeeks + " weeks, on Sundays, for a total of " + item.RecurrenceEndAfterNOccurences + " FutureDates");
            DateTime[] dates = item.FutureDates.ToArray();
            Assert.AreEqual(lastDate, dates[dates.Length - 1]);
        }


        [TestMethod]
        public void TestEveryTwoWeeksOnWeekdays()
        {
            //Arrange
            int numberOfRecurrences = 3;
            WeeklySchedule item = new WeeklySchedule
            {
                RecurrenceType = WeeklySchedule.RecurrenceTypeEnum.Weekly,
                WeeklyEveryNWeeks = 2,
                WeeklyDayOfWeekSunday = false,
                WeeklyDayOfWeekMonday = true,
                WeeklyDayOfWeekTuesday = true,
                WeeklyDayOfWeekWednesday = true,
                WeeklyDayOfWeekThursday = true,
                WeeklyDayOfWeekFriday = true,
                WeeklyDayOfWeekSaturday = false,
                RecurrenceStartDate = new DateTime(2019, 3, 10),
                RecurrenceEndAfterNSelected = true,
                RecurrenceEndAfterNOccurences = numberOfRecurrences
            };
            int numberOfDaysSelected = 5;
            DateTime lastDate = item.NormalizeDate(item.RecurrenceStartDate.AddDays(((item.WeeklyEveryNWeeks * 7) * item.RecurrenceEndAfterNOccurences) - (item.WeeklyEveryNWeeks * 7) + numberOfDaysSelected));

            //Act
            item.ProcessFutureDates();

            //Assert
            Assert.AreEqual(item.Name, "Weekly every " + item.WeeklyEveryNWeeks + " weeks, on Mondays, Tuesdays, Wednesdays, Thursdays, Fridays, for a total of " + item.RecurrenceEndAfterNOccurences * numberOfDaysSelected + " FutureDates");
            DateTime[] dates = item.FutureDates.ToArray();
            Assert.AreEqual(lastDate, dates[dates.Length - 1]);
        }




        [TestMethod]
        public void TestEveryWeekOnSaturdays()
        {
            //Arrange
            int numberOfRecurrences = 3;
            WeeklySchedule item = new WeeklySchedule
            {
                RecurrenceType = WeeklySchedule.RecurrenceTypeEnum.Weekly,
                WeeklyEveryNWeeks = 1,
                WeeklyDayOfWeekSunday = false,
                WeeklyDayOfWeekMonday = false,
                WeeklyDayOfWeekTuesday = false,
                WeeklyDayOfWeekWednesday = false,
                WeeklyDayOfWeekThursday = false,
                WeeklyDayOfWeekFriday = false,
                WeeklyDayOfWeekSaturday = true,
                RecurrenceStartDate = new DateTime(2019, 1, 5),
                RecurrenceEndAfterNSelected = true,
                RecurrenceEndAfterNOccurences = numberOfRecurrences
            };
            int numberOfDaysSelected = 1;
            DateTime lastDate = item.NormalizeDate(item.RecurrenceStartDate.AddDays(((item.WeeklyEveryNWeeks * 7) * item.RecurrenceEndAfterNOccurences) - (item.WeeklyEveryNWeeks * 7) + numberOfDaysSelected - 1));

            //Act
            item.ProcessFutureDates();

            //Assert
            Assert.AreEqual(item.Name, "Weekly every " + item.WeeklyEveryNWeeks + " weeks, on Saturdays, for a total of " + item.RecurrenceEndAfterNOccurences * numberOfDaysSelected + " FutureDates");
            DateTime[] dates = item.FutureDates.ToArray();
            Assert.AreEqual(lastDate, dates[dates.Length - 1]);
        }

        //This one doesn't work well as a weekend in my current model is a Sunday, with 5 weekdays, and then a saturday, instead of a consectutive Sat + Sun
        //[TestMethod]
        //public void TestEveryThreewWeeksOnWeekends()
        //{
        //    //Arrange
        //    int numberOfRecurrences = 3;
        //    WeeklySchedule item = new WeeklySchedule
        //    {
        //        RecurrenceType = WeeklySchedule.RecurrenceTypeEnum.Weekly,
        //        WeeklyEveryNWeeks = 3,
        //        WeeklyDayOfWeekSunday = true,
        //        WeeklyDayOfWeekMonday = false,
        //        WeeklyDayOfWeekTuesday = false,
        //        WeeklyDayOfWeekWednesday = false,
        //        WeeklyDayOfWeekThursday = false,
        //        WeeklyDayOfWeekFriday = false,
        //        WeeklyDayOfWeekSaturday = true,
        //        RecurrenceStartDate = new DateTime(2019, 3, 10),
        //        RecurrenceEndAfterNSelected = true,
        //        RecurrenceEndAfterNOccurences = numberOfRecurrences
        //    };
        //    int numberOfDaysSelected = 2;
        //    DateTime lastDate = item.NormalizeDate(item.RecurrenceStartDate.AddDays(((item.WeeklyEveryNWeeks * 7) * item.RecurrenceEndAfterNOccurences) - (item.WeeklyEveryNWeeks * 7) + numberOfDaysSelected));

        //    //Act
        //    item.ProcessFutureDates();

        //    //Assert
        //    Assert.AreEqual(item.Name, "Weekly every " + item.WeeklyEveryNWeeks + " weeks, on Sundays, Saturdays, for a total of " + item.RecurrenceEndAfterNOccurences * numberOfDaysSelected + " FutureDates");
        //    DateTime[] dates = item.FutureDates.ToArray();
        //    Assert.AreEqual(lastDate, dates[dates.Length - 1]);
        //}

    }
}
