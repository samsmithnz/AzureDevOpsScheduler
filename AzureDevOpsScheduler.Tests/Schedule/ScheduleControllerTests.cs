using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AzureDevOpsScheduler.Core.Schedule;

namespace AzureDevOpsScheduler.Tests.Schedule
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [TestClass]
    public class ScheduleControllerTests
    {
        [TestMethod]
        public void TestControllerJSONGenerationForDay()
        {
            //Arrange
            int numberOfRecurrences = 10;
            DailySchedule item = new DailySchedule
            {
                RecurrenceType = DailySchedule.RecurrenceTypeEnum.Daily,
                DailyEveryNDaysSelected = true,
                DailyEveryNDays = 1,
                RecurrenceStartDate = DateTime.Now,
                RecurrenceEndAfterNSelected = true,
                RecurrenceEndAfterNOccurences = numberOfRecurrences
            };
            ScheduleItem scheduleItem = new ScheduleItem
            {
                DailySchedule = item
            };
            ScheduleItemController controller = new ScheduleItemController();

            //Act
            item.ProcessFutureDates();
            string json = controller.CreateJSON(scheduleItem);
            ScheduleItem processedItem = controller.ProcessJSON(json);

            //Assert
            Assert.IsTrue(json != null);
            Assert.AreEqual(processedItem.ScheduleItemType, "Daily");
            Assert.IsTrue(processedItem.DailySchedule != null);
            Assert.IsTrue(processedItem.WeeklySchedule == null);
            Assert.IsTrue(processedItem.MonthlySchedule == null);
            Assert.IsTrue(processedItem.YearlySchedule == null);
        }
        [TestMethod]
        public void TestControllerJSONGenerationForWeek()
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
            ScheduleItem scheduleItem = new ScheduleItem
            {
                WeeklySchedule = item
            };
            ScheduleItemController controller = new ScheduleItemController();

            //Act
            item.ProcessFutureDates();
            string json = controller.CreateJSON(scheduleItem);
            ScheduleItem processedItem = controller.ProcessJSON(json);

            //Assert
            Assert.IsTrue(json != null);
            Assert.AreEqual(processedItem.ScheduleItemType, "Weekly");
            Assert.IsTrue(processedItem.DailySchedule == null);
            Assert.IsTrue(processedItem.WeeklySchedule != null);
            Assert.IsTrue(processedItem.MonthlySchedule == null);
            Assert.IsTrue(processedItem.YearlySchedule == null);
        }

        [TestMethod]
        public void TestControllerJSONGenerationForMonth()
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
                RecurrenceEndAfterNOccurences = 100
            };
            ScheduleItem scheduleItem = new ScheduleItem
            {
                MonthlySchedule = item
            };
            ScheduleItemController controller = new ScheduleItemController();

            //Act
            item.ProcessFutureDates();
            string json = controller.CreateJSON(scheduleItem);
            ScheduleItem processedItem = controller.ProcessJSON(json);

            //Assert
            Assert.IsTrue(json != null);
            Assert.AreEqual(processedItem.ScheduleItemType, "Monthly");
            Assert.IsTrue(processedItem.DailySchedule == null);
            Assert.IsTrue(processedItem.WeeklySchedule == null);
            Assert.IsTrue(processedItem.MonthlySchedule != null);
            Assert.IsTrue(processedItem.YearlySchedule == null);
        }

        [TestMethod]
        public void TestControllerJSONGenerationForYear()
        {
            //Arrange
            int numberOfRecurrences = 10;
            YearlySchedule item = new YearlySchedule
            {
                RecurrenceType = YearlySchedule.RecurrenceTypeEnum.Yearly,
                YearlyEveryNYearsSelected = true,
                YearlyEveryNYears = 1,
                RecurrenceStartDate = DateTime.Now,
                RecurrenceEndAfterNSelected = true,
                RecurrenceEndAfterNOccurences = numberOfRecurrences
            };
            ScheduleItem scheduleItem = new ScheduleItem
            {
                YearlySchedule = item
            };
            ScheduleItemController controller = new ScheduleItemController();

            //Act
            item.ProcessFutureDates();
            string json = controller.CreateJSON(scheduleItem);
            ScheduleItem processedItem = controller.ProcessJSON(json);

            //Assert
            Assert.IsTrue(json != null);
            Assert.AreEqual(processedItem.ScheduleItemType, "Yearly");
            Assert.IsTrue(processedItem.DailySchedule == null);
            Assert.IsTrue(processedItem.WeeklySchedule == null);
            Assert.IsTrue(processedItem.MonthlySchedule == null);
            Assert.IsTrue(processedItem.YearlySchedule != null);
        }

        [TestMethod]
        public void TestControllerJSONGenerationForMultipleSchedules()
        {
            try
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
                    RecurrenceEndAfterNOccurences = 100
                };
                YearlySchedule item2 = new YearlySchedule
                {
                    RecurrenceType = YearlySchedule.RecurrenceTypeEnum.Yearly,
                    YearlyEveryNYearsSelected = true,
                    YearlyEveryNYears = 1,
                    RecurrenceStartDate = DateTime.Now,
                    RecurrenceEndAfterNSelected = true,
                    RecurrenceEndAfterNOccurences = 10
                };
                ScheduleItem scheduleItem = new ScheduleItem
                {
                    MonthlySchedule = item,
                    YearlySchedule = item2
                };
                ScheduleItemController controller = new ScheduleItemController();

                //Act
                item.ProcessFutureDates();
                string json = controller.CreateJSON(scheduleItem);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.InnerException.Message == "object has multiple types and cannot be processed");
            }
        }

        [TestMethod]
        public void TestControllerJSONGenerationForNoSchedules()
        {
            try
            {
                //Arrange
                ScheduleItem scheduleItem = new ScheduleItem();
                ScheduleItemController controller = new ScheduleItemController();

                //Act
                string json = controller.CreateJSON(scheduleItem);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.InnerException.Message == "object has no types and cannot be processed");
            }
        }

    }
}
