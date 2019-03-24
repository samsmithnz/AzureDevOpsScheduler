using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AzureDevOpsScheduler.Core.Schedule;
using AzureDevOpsScheduler.Core.Schedule.MonthlyExtensions;

namespace AzureDevOpsScheduler.Tests.Schedule
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [TestClass]
    public class MonthlyScheduleTests
    {
        [TestMethod]
        public void TestEveryThirdDayOfOneMonths()
        {
            //Arrange
            MonthlySchedule item = new MonthlySchedule
            {
                RecurrenceType = MonthlySchedule.RecurrenceTypeEnum.Monthly,
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
            MonthlySchedule item = new MonthlySchedule
            {
                RecurrenceType = MonthlySchedule.RecurrenceTypeEnum.Monthly,
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
            MonthlySchedule item = new MonthlySchedule
            {
                RecurrenceType = MonthlySchedule.RecurrenceTypeEnum.Monthly,
                MonthlyTheNDaySelected = true,
                MonthlyTheNOccurrence = MonthlySchedule.MonthlyTheNOccurrenceEnum.Second,
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
            MonthlySchedule item = new MonthlySchedule
            {
                RecurrenceType = MonthlySchedule.RecurrenceTypeEnum.Monthly,
                MonthlyTheNDaySelected = true,
                MonthlyTheNOccurrence = MonthlySchedule.MonthlyTheNOccurrenceEnum.Last,
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
            MonthlySchedule item = new MonthlySchedule
            {
                RecurrenceType = MonthlySchedule.RecurrenceTypeEnum.Monthly,
                MonthlyTheNDaySelected = true,
                MonthlyTheNOccurrence = MonthlySchedule.MonthlyTheNOccurrenceEnum.First,
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
            MonthlySchedule itemMon = new MonthlySchedule
            {
                MonthlyTheNDayOfWeek = DayOfWeek.Monday
            };
            MonthlySchedule itemTue = new MonthlySchedule
            {
                MonthlyTheNDayOfWeek = DayOfWeek.Tuesday
            };
            MonthlySchedule itemWed = new MonthlySchedule
            {
                MonthlyTheNDayOfWeek = DayOfWeek.Wednesday
            };
            MonthlySchedule itemThu = new MonthlySchedule
            {
                MonthlyTheNDayOfWeek = DayOfWeek.Thursday
            };
            MonthlySchedule itemFri = new MonthlySchedule
            {
                MonthlyTheNDayOfWeek = DayOfWeek.Friday
            };
            MonthlySchedule itemSat = new MonthlySchedule
            {
                MonthlyTheNDayOfWeek = DayOfWeek.Saturday
            };
            MonthlySchedule itemSun = new MonthlySchedule
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
            MonthlySchedule itemFirst = new MonthlySchedule
            {
                MonthlyTheNOccurrence = MonthlySchedule.MonthlyTheNOccurrenceEnum.First
            };
            MonthlySchedule itemSecond = new MonthlySchedule
            {
                MonthlyTheNOccurrence = MonthlySchedule.MonthlyTheNOccurrenceEnum.Second
            };
            MonthlySchedule itemThird = new MonthlySchedule
            {
                MonthlyTheNOccurrence = MonthlySchedule.MonthlyTheNOccurrenceEnum.Third
            };
            MonthlySchedule itemFourth = new MonthlySchedule
            {
                MonthlyTheNOccurrence = MonthlySchedule.MonthlyTheNOccurrenceEnum.Fourth
            };
            MonthlySchedule itemLast = new MonthlySchedule
            {
                MonthlyTheNOccurrence = MonthlySchedule.MonthlyTheNOccurrenceEnum.Last
            };

            //Act

            //Assert
            Assert.AreEqual(itemFirst.GetMonthlyTheNOccurrenceText(), "first");
            Assert.AreEqual(itemSecond.GetMonthlyTheNOccurrenceText(), "second");
            Assert.AreEqual(itemThird.GetMonthlyTheNOccurrenceText(), "third");
            Assert.AreEqual(itemFourth.GetMonthlyTheNOccurrenceText(), "fourth");
            Assert.AreEqual(itemLast.GetMonthlyTheNOccurrenceText(), "last");
        }

        [TestMethod]
        public void TestNullGetMonthlyTheNDayOfWeekText()
        {
            try
            {

                //Arrange
                MonthlySchedule month = new MonthlySchedule
                {
                    MonthlyTheNDayOfWeek = (DayOfWeek)100
                };

                //Act
                string result = month.GetMonthlyTheNDayOfWeekText();

                //Assert
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "No day of the week found");
            }
        }

        [TestMethod]
        public void TestNullGetMonthlyTheNOccurrenceText()
        {
            try
            {

                //Arrange
                MonthlySchedule month = new MonthlySchedule
                {
                    MonthlyTheNOccurrence = (MonthlySchedule.MonthlyTheNOccurrenceEnum)100
                };

                //Act
                string result = month.GetMonthlyTheNOccurrenceText();

                //Assert
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "No monthly occurrence found");
            }
        }

    }
}
