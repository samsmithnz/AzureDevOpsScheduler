using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AzureDevOpsSchedule.Core.Schedule;
using AzureDevOpsSchedule.Core.Schedule.Monthly;

namespace AzureDevOpsScheduler.Tests.Schedule
{
    [TestClass]
    public class MonthlyScheduleTests
    {
        [TestMethod]
        public void TestEveryThirdDayOfOneMonths()
        {
            //Arrange
            ScheduleItem item = new ScheduleItem
            {
                RecurrenceType = ScheduleItem.RecurrenceTypeEnum.Monthly,
                MonthlyEveryNMonthsSelected = true,
                MonthlyDayOfMonth = 3,
                MonthlyEveryNMonths = 1,
                RecurrenceStartDate = new System.DateTime(2019, 1, 3),
                RecurrenceEndAfterNSelected = true,
                RecurrenceEndAfterNOccurences = 10
            };
            DateTime lastDate = item.NormalizeDate(item.RecurrenceStartDate.AddMonths(item.MonthlyEveryNMonths * item.RecurrenceEndAfterNOccurences - item.MonthlyEveryNMonths));

            //Act
            item.ProcessFutureDates();

            //Assert
            Assert.AreEqual(item.Name, "Monthly on the " + item.MonthlyDayOfMonth + " day of the month every " + item.MonthlyEveryNMonths + " months for a total of " + item.RecurrenceEndAfterNOccurences + " FutureDates");
            DateTime[] dates = item.FutureDates.ToArray();
            Assert.AreEqual(lastDate, dates[dates.Length - 1]);
        }


        [TestMethod]
        public void TestEvery22ndDayFor3Months()
        {
            //Arrange
            ScheduleItem item = new ScheduleItem
            {
                RecurrenceType = ScheduleItem.RecurrenceTypeEnum.Monthly,
                MonthlyEveryNMonthsSelected = true,
                MonthlyDayOfMonth = 22,
                MonthlyEveryNMonths = 3,
                RecurrenceStartDate = new System.DateTime(2019, 1, 22),
                RecurrenceEndAfterNSelected = true,
                RecurrenceEndAfterNOccurences = 10
            };
            DateTime lastDate = item.NormalizeDate(item.RecurrenceStartDate.AddMonths(item.MonthlyEveryNMonths * item.RecurrenceEndAfterNOccurences - item.MonthlyEveryNMonths));

            //Act
            item.ProcessFutureDates();

            //Assert
            Assert.AreEqual(item.Name, "Monthly on the " + item.MonthlyDayOfMonth + " day of the month every " + item.MonthlyEveryNMonths + " months for a total of " + item.RecurrenceEndAfterNOccurences + " FutureDates");
            DateTime[] dates = item.FutureDates.ToArray();
            Assert.AreEqual(lastDate, dates[dates.Length - 1]);
        }

        [TestMethod]
        public void TestEverySecondMondayFor3Months()
        {
            //Arrange
            ScheduleItem item = new ScheduleItem
            {
                RecurrenceType = ScheduleItem.RecurrenceTypeEnum.Monthly,
                MonthlyTheNDaySelected = true,
                MonthlyTheNOccurrence = ScheduleItem.MonthlyTheNOccurrenceEnum.Second,
                MonthlyTheNDayOfWeek = DayOfWeek.Monday,
                MonthlyTheNDayDayMonth = 1,
                RecurrenceStartDate = new System.DateTime(2019, 2, 11),
                RecurrenceEndAfterNSelected = true,
                RecurrenceEndAfterNOccurences = 3
            };
            DateTime lastDate = item.NormalizeDate(new DateTime(2019, 4, 8)); //item.NormalizeDate(item.RecurrenceStartDate.AddMonths(item.MonthlyEveryNMonths * item.RecurrenceEndAfterNOccurences - item.MonthlyEveryNMonths));

            //Act
            item.ProcessFutureDates();

            //Assert
            Assert.AreEqual(item.Name, "Monthly the " + item.GetMonthlyTheNOccurrenceText() + " " + item.GetMonthlyTheNDayOfWeekText() + " of every " + item.MonthlyTheNDayDayMonth + " months for a total of " + item.RecurrenceEndAfterNOccurences + " FutureDates");
            DateTime[] dates = item.FutureDates.ToArray();
            Assert.AreEqual(lastDate, dates[dates.Length - 1]);
        }



        [TestMethod]
        public void TestEveryLastFridayFor3Months()
        {
            //Arrange
            ScheduleItem item = new ScheduleItem
            {
                RecurrenceType = ScheduleItem.RecurrenceTypeEnum.Monthly,
                MonthlyTheNDaySelected = true,
                MonthlyTheNOccurrence = ScheduleItem.MonthlyTheNOccurrenceEnum.Last,
                MonthlyTheNDayOfWeek = DayOfWeek.Friday,
                MonthlyTheNDayDayMonth = 1,
                RecurrenceStartDate = new System.DateTime(2019, 1, 25),
                RecurrenceEndAfterNSelected = true,
                RecurrenceEndAfterNOccurences = 3
            };
            DateTime lastDate = item.NormalizeDate(new DateTime(2019, 3, 29)); //item.NormalizeDate(item.RecurrenceStartDate.AddMonths(item.MonthlyEveryNMonths * item.RecurrenceEndAfterNOccurences - item.MonthlyEveryNMonths));

            //Act
            item.ProcessFutureDates();

            //Assert
            Assert.AreEqual(item.Name, "Monthly the " + item.GetMonthlyTheNOccurrenceText() + " " + item.GetMonthlyTheNDayOfWeekText() + " of every " + item.MonthlyTheNDayDayMonth + " months for a total of " + item.RecurrenceEndAfterNOccurences + " FutureDates");
            DateTime[] dates = item.FutureDates.ToArray();
            Assert.AreEqual(lastDate, dates[dates.Length - 1]);
        }

        [TestMethod]
        public void TestEverySecondFirstFridayFor6Months()
        {
            //Arrange
            ScheduleItem item = new ScheduleItem
            {
                RecurrenceType = ScheduleItem.RecurrenceTypeEnum.Monthly,
                MonthlyTheNDaySelected = true,
                MonthlyTheNOccurrence = ScheduleItem.MonthlyTheNOccurrenceEnum.First,
                MonthlyTheNDayOfWeek = DayOfWeek.Friday,
                MonthlyTheNDayDayMonth = 2,
                RecurrenceStartDate = new System.DateTime(2019, 1, 4),
                RecurrenceEndAfterNSelected = true,
                RecurrenceEndAfterNOccurences = 3
            };
            DateTime lastDate = item.NormalizeDate(new DateTime(2019, 5, 3)); //item.NormalizeDate(item.RecurrenceStartDate.AddMonths(item.MonthlyEveryNMonths * item.RecurrenceEndAfterNOccurences - item.MonthlyEveryNMonths));

            //Act
            item.ProcessFutureDates();

            //Assert
            Assert.AreEqual(item.Name, "Monthly the " + item.GetMonthlyTheNOccurrenceText() + " " + item.GetMonthlyTheNDayOfWeekText() + " of every " + item.MonthlyTheNDayDayMonth + " months for a total of " + item.RecurrenceEndAfterNOccurences + " FutureDates");
            DateTime[] dates = item.FutureDates.ToArray();
            Assert.AreEqual(lastDate, dates[dates.Length - 1]);
        }

        [TestMethod]
        public void TestDayOfWeek()
        {
            //Arrange
            ScheduleItem itemMon = new ScheduleItem
            {
                MonthlyTheNDayOfWeek = DayOfWeek.Monday
            };
            ScheduleItem itemTue = new ScheduleItem
            {
                MonthlyTheNDayOfWeek = DayOfWeek.Tuesday
            };
            ScheduleItem itemWed = new ScheduleItem
            {
                MonthlyTheNDayOfWeek = DayOfWeek.Wednesday
            };
            ScheduleItem itemThu = new ScheduleItem
            {
                MonthlyTheNDayOfWeek = DayOfWeek.Thursday
            };
            ScheduleItem itemFri = new ScheduleItem
            {
                MonthlyTheNDayOfWeek = DayOfWeek.Friday
            };
            ScheduleItem itemSat = new ScheduleItem
            {
                MonthlyTheNDayOfWeek = DayOfWeek.Saturday
            };
            ScheduleItem itemSun = new ScheduleItem
            {
                MonthlyTheNDayOfWeek = DayOfWeek.Sunday
            };

            //Act

            //Assert
            Assert.AreEqual(itemMon.GetMonthlyTheNDayOfWeekText(), "Monday");
            Assert.AreEqual(itemTue.GetMonthlyTheNDayOfWeekText(), "Tuesday");
            Assert.AreEqual(itemWed.GetMonthlyTheNDayOfWeekText(), "Wednesday");
            Assert.AreEqual(itemThu.GetMonthlyTheNDayOfWeekText(), "Thursday");
            Assert.AreEqual(itemFri.GetMonthlyTheNDayOfWeekText(), "Friday");
            Assert.AreEqual(itemSat.GetMonthlyTheNDayOfWeekText(), "Saturday");
            Assert.AreEqual(itemSun.GetMonthlyTheNDayOfWeekText(), "Sunday");
        }

        [TestMethod]
        public void TestOccurrence()
        {
            //Arrange
            ScheduleItem itemFirst = new ScheduleItem
            {
                MonthlyTheNOccurrence = ScheduleItem.MonthlyTheNOccurrenceEnum.First
            };
            ScheduleItem itemSecond = new ScheduleItem
            {
                MonthlyTheNOccurrence = ScheduleItem.MonthlyTheNOccurrenceEnum.Second
            };
            ScheduleItem itemThird = new ScheduleItem
            {
                MonthlyTheNOccurrence = ScheduleItem.MonthlyTheNOccurrenceEnum.Third
            };
            ScheduleItem itemFourth = new ScheduleItem
            {
                MonthlyTheNOccurrence = ScheduleItem.MonthlyTheNOccurrenceEnum.Fourth
            };
            ScheduleItem itemLast = new ScheduleItem
            {
                MonthlyTheNOccurrence = ScheduleItem.MonthlyTheNOccurrenceEnum.Last
            };

            //Act

            //Assert
            Assert.AreEqual(itemFirst.GetMonthlyTheNOccurrenceText(), "first");
            Assert.AreEqual(itemSecond.GetMonthlyTheNOccurrenceText(), "second");
            Assert.AreEqual(itemThird.GetMonthlyTheNOccurrenceText(), "third");
            Assert.AreEqual(itemFourth.GetMonthlyTheNOccurrenceText(), "fourth");
            Assert.AreEqual(itemLast.GetMonthlyTheNOccurrenceText(), "last");
        }


    }
}
