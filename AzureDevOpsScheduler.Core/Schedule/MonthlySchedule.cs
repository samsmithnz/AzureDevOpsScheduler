using AzureDevOpsScheduler.Core.Schedule.MonthlyExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevOpsScheduler.Core.Schedule
{
    public class MonthlySchedule : BaseSchedule
    {

        public string Name
        {
            get
            {
                string name = "";

                name += "Monthly ";
                if (MonthlyEveryNMonthsSelected == true)
                {
                    name += "on the " + MonthlyDayOfMonth + " day of the month ";
                    name += "every " + MonthlyEveryNMonths + " months ";
                }
                else if (MonthlyTheNDaySelected == true)
                {
                    //the second monday of every 1 months
                    name += "the " + GetMonthlyTheNOccurrenceText();
                    name += " " + GetMonthlyTheNDayOfWeekText();
                    name += " of every " + MonthlyTheNDayDayMonth + " months ";
                }
                name += "for a total of " + FutureDates.Count + " FutureDates";

                return name;
            }
        }

        public bool MonthlyEveryNMonthsSelected { get; set; }
        public int MonthlyDayOfMonth { get; set; }
        public int MonthlyEveryNMonths { get; set; }

        /// <summary>
        /// >>THE second wednesday of every one months
        /// </summary>
        public bool MonthlyTheNDaySelected { get; set; }
        public enum MonthlyTheNOccurrenceEnum
        {
            First,
            Second,
            Third,
            Fourth,
            Last
        }
        /// <summary>
        /// the >>SECOND wednesday of every one months
        /// </summary>
        public MonthlyTheNOccurrenceEnum MonthlyTheNOccurrence { get; set; }
        public string GetMonthlyTheNOccurrenceText()
        {
            switch (MonthlyTheNOccurrence)
            {
                case MonthlyTheNOccurrenceEnum.First:
                    return "first";
                case MonthlyTheNOccurrenceEnum.Second:
                    return "second";
                case MonthlyTheNOccurrenceEnum.Third:
                    return "third";
                case MonthlyTheNOccurrenceEnum.Fourth:
                    return "fourth";
                case MonthlyTheNOccurrenceEnum.Last:
                    return "last";
                default:
                    throw new Exception("No monthly occurrence found");
            }
        }
        /// <summary>
        /// the second >>WEDNESDAY of every one months
        /// </summary>
        public DayOfWeek MonthlyTheNDayOfWeek { get; set; }
        public string GetMonthlyTheNDayOfWeekText()
        {
            switch (MonthlyTheNDayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "Monday";
                case DayOfWeek.Tuesday:
                    return "Tuesday";
                case DayOfWeek.Wednesday:
                    return "Wednesday";
                case DayOfWeek.Thursday:
                    return "Thursday";
                case DayOfWeek.Friday:
                    return "Friday";
                case DayOfWeek.Saturday:
                    return "Saturday";
                case DayOfWeek.Sunday:
                    return "Sunday";
                default:
                    throw new Exception("No day of the week found");
            }
        }
        /// <summary>
        /// the second wednesday of every >>ONE months
        /// </summary>
        public int MonthlyTheNDayDayMonth { get; set; }


        public bool ProcessFutureDates()
        {
            DateTime startDate = RecurrenceStartDate;
            //DateTime endDate;
            //if (RecurrenceEndAfterNSelected == true)
            //{
            //    //endDate = RecurrenceEndByDate;
            //}
            //else
            //{
            //    throw new Exception("Recurrence end date else issue");
            //}
            int counter = 0;

            //public bool MonthlyEveryNMonthsSelected;
            //public int MonthlyDayOfMonth;
            //public int MonthlyEveryNMonths;

            if (MonthlyEveryNMonthsSelected == true)
            {
                //Get the next day that matches this in the current month
                //DateTime currentMonthlyDate;
                //if (RecurrenceStartDate.Day > MonthlyDayOfMonth)
                //{
                //    currentMonthlyDate = new DateTime(RecurrenceStartDate.Year, RecurrenceStartDate.Month + 1, MonthlyDayOfMonth);
                //}
                //else
                //{
                //    currentMonthlyDate = new DateTime(RecurrenceStartDate.Year, RecurrenceStartDate.Month, MonthlyDayOfMonth);
                //}

                int monthyMonthCounter = 0;
                while (counter < RecurrenceEndAfterNOccurences)
                {
                    FutureDatesEnqueue(startDate.AddMonths(monthyMonthCounter));
                    monthyMonthCounter += MonthlyEveryNMonths;
                    counter++;
                }
            }
            else if (MonthlyTheNDaySelected == true)
            {
                //int monthlyWeekCounter = (int)MonthlyTheNOccurrence + 1;
                //DayOfWeek monthlyCountCounter = MonthlyTheNDayOfWeek;
                int monthyMonthCounter = 0;
                while (counter < RecurrenceEndAfterNOccurences)
                {
                    DateTime monthDate = startDate.AddMonths(monthyMonthCounter);
                    DateTime firstDayOfMonth = new DateTime(monthDate.Year, monthDate.Month, 1);
                    int daysInMonth = DateTime.DaysInMonth(monthDate.Year, monthDate.Month);
                    MonthDayCollection dayCollection = new MonthDayCollection();
                    for (int i = 1; i <= daysInMonth; i++)
                    {
                        //Create month  for each day
                        MonthDay day = new MonthDay
                        {
                            DayOfWeek = firstDayOfMonth.AddDays(i - 1).DayOfWeek,
                            Count = dayCollection.CountDayOfWeek(firstDayOfMonth.AddDays(i - 1).DayOfWeek) + 1,
                            Date = firstDayOfMonth.AddDays(i - 1)
                        };
                        //Add what day it is, and the occurenace of each day
                        dayCollection.Days.Add(day);
                    }
                    FutureDatesEnqueue(dayCollection.FindDayOfWeek(MonthlyTheNDayOfWeek, MonthlyTheNOccurrence).Date);

                    monthyMonthCounter += MonthlyTheNDayDayMonth;
                    counter++;
                }

            }

            return true;
        }


    }
}
