using AzureDevOpsSchedule.Core.Schedule.Monthly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevOpsSchedule.Core.Schedule
{
    public class ScheduleItem
    {
        #region "Properties" 
        public ScheduleItem()
        {
            FutureDates = new Queue<DateTime>();
        }

        public string Name
        {
            get
            {
                string name = "";
                switch (RecurrenceType)
                {
                    case ScheduleItem.RecurrenceTypeEnum.Daily:
                        name += "Daily ";
                        if (DailyEveryNDaysSelected == true)
                        {
                            name += "every " + DailyEveryNDays + " days ";
                        }
                        //else if (DailyEveryWeekDaySelected == true)
                        //{
                        //    name += "every weekday ";
                        //}
                        name += "for a total of " + FutureDates.Count + " FutureDates";
                        break;
                    case ScheduleItem.RecurrenceTypeEnum.Weekly:
                        //"Weekly every 1 weeks, on Sundays, for a total of 10 FutureDates"
                        name += "Weekly ";
                        name += "every " + WeeklyEveryNWeeks + " weeks, on ";
                        if (WeeklyDayOfWeekSunday == true)
                        {
                            name += "Sundays, ";
                        }
                        if (WeeklyDayOfWeekMonday == true)
                        {
                            name += "Mondays, ";
                        }
                        if (WeeklyDayOfWeekTuesday == true)
                        {
                            name += "Tuesdays, ";
                        }
                        if (WeeklyDayOfWeekWednesday == true)
                        {
                            name += "Wednesdays, ";
                        }
                        if (WeeklyDayOfWeekThursday == true)
                        {
                            name += "Thursdays, ";
                        }
                        if (WeeklyDayOfWeekFriday == true)
                        {
                            name += "Fridays, ";
                        }
                        if (WeeklyDayOfWeekSaturday == true)
                        {
                            name += "Saturdays, ";
                        }
                        name += "for a total of " + FutureDates.Count + " FutureDates";
                        break;
                    case ScheduleItem.RecurrenceTypeEnum.Monthly:
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
                        break;
                    case ScheduleItem.RecurrenceTypeEnum.Yearly:
                        name += "Yearly ";
                        if (YearlyEveryNYearsSelected == true)
                        {
                            name += "every " + YearlyEveryNYears + " years ";
                        }
                        name += "for a total of " + FutureDates.Count + " FutureDates";
                        break;
                }
                return name;
            }
        }

        public enum RecurrenceTypeEnum
        {
            Daily,
            Weekly,
            Monthly,
            Yearly
        }
        public RecurrenceTypeEnum RecurrenceType { get; set; } //daily, weekly, monthly, yearly

        public bool DailyEveryNDaysSelected { get; set; }
        public int DailyEveryNDays { get; set; }
        //public bool DailyEveryWeekDaySelected { get; set; }

        public int WeeklyEveryNWeeks { get; set; }
        public bool WeeklyDayOfWeekSunday { get; set; }
        public bool WeeklyDayOfWeekMonday { get; set; }
        public bool WeeklyDayOfWeekTuesday { get; set; }
        public bool WeeklyDayOfWeekWednesday { get; set; }
        public bool WeeklyDayOfWeekThursday { get; set; }
        public bool WeeklyDayOfWeekFriday { get; set; }
        public bool WeeklyDayOfWeekSaturday { get; set; }

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

        public bool YearlyEveryNYearsSelected { get; set; }
        public int YearlyEveryNYears { get; set; }


        private DateTime _recurrenceStartDate;
        public DateTime RecurrenceStartDate
        {
            get
            {
                return _recurrenceStartDate;
            }
            set
            {
                _recurrenceStartDate = NormalizeDate(value);
            }
        }
        //public bool RecurrenceEndBySelected { get; set; }
        //private DateTime _recurrenceEndByDate;
        //public DateTime RecurrenceEndByDate
        //{
        //    get
        //    {
        //        return _recurrenceEndByDate;
        //    }
        //    set
        //    {
        //        _recurrenceEndByDate = NormalizeDate(value);
        //    }
        //}
        public bool RecurrenceEndAfterNSelected { get; set; }
        public int RecurrenceEndAfterNOccurences { get; set; }
        //public bool RecurrenceEndNoEndDateSelected;

        public Queue<DateTime> FutureDates { get; set; }

        #endregion


        #region "Functions" 
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
            switch (RecurrenceType)
            {
                case ScheduleItem.RecurrenceTypeEnum.Daily:
                    if (DailyEveryNDaysSelected == true)
                    {
                        int dailyDayCounter = 0;
                        while (counter < RecurrenceEndAfterNOccurences)
                        {
                            FutureDatesEnqueue(startDate.AddDays(dailyDayCounter));
                            dailyDayCounter += DailyEveryNDays;
                            counter++;
                        }
                    }
                    //else if (DailyEveryWeekDaySelected == true)
                    //{
                    //    int weekDayCounter = 0;
                    //    while (weekDayCounter < RecurrenceEndAfterNOccurences)
                    //    {
                    //        //Only add days if they are weekdays
                    //        switch (startDate.AddDays(counter).DayOfWeek)
                    //        {
                    //            case DayOfWeek.Monday:
                    //            case DayOfWeek.Tuesday:
                    //            case DayOfWeek.Wednesday:
                    //            case DayOfWeek.Thursday:
                    //            case DayOfWeek.Friday:
                    //                FutureDatesEnqueue(startDate.AddDays(counter));
                    //                weekDayCounter++;
                    //                break;
                    //        }
                    //        counter++;
                    //    }
                    //}
                    else
                    {
                        throw new Exception("Daily branch unexpectedly reached with no options selected");
                    }
                    break;
                case ScheduleItem.RecurrenceTypeEnum.Weekly:
                    int weekCounter = 0;
                    //int dayCounter = 0;// (int)startDate.DayOfWeek;
                    while (weekCounter < RecurrenceEndAfterNOccurences)
                    {
                        DateTime dateToCheck = startDate.AddDays(counter);
                        for (int i = 0; i < 7; i++)
                        {
                            if ((WeeklyDayOfWeekSunday == true && dateToCheck.AddDays(i).DayOfWeek == DayOfWeek.Sunday) ||
                                (WeeklyDayOfWeekMonday == true && dateToCheck.AddDays(i).DayOfWeek == DayOfWeek.Monday) ||
                                (WeeklyDayOfWeekTuesday == true && dateToCheck.AddDays(i).DayOfWeek == DayOfWeek.Tuesday) ||
                                (WeeklyDayOfWeekWednesday == true && dateToCheck.AddDays(i).DayOfWeek == DayOfWeek.Wednesday) ||
                                (WeeklyDayOfWeekThursday == true && dateToCheck.AddDays(i).DayOfWeek == DayOfWeek.Thursday) ||
                                (WeeklyDayOfWeekFriday == true && dateToCheck.AddDays(i).DayOfWeek == DayOfWeek.Friday) ||
                                (WeeklyDayOfWeekSaturday == true && dateToCheck.AddDays(i).DayOfWeek == DayOfWeek.Saturday))
                            {
                                FutureDatesEnqueue(dateToCheck.AddDays(i));
                            }
                            if (dateToCheck.AddDays(i).DayOfWeek == DayOfWeek.Saturday)
                            {
                                weekCounter++;
                                //dayCounter = 0;
                                counter += WeeklyEveryNWeeks * 7;
                            }
                        }

                    }
                    break;

                case ScheduleItem.RecurrenceTypeEnum.Monthly:
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
                    else
                    {
                        throw new Exception("Monthly branch unexpectedly reached with no options selected");
                    }

                    break;

                case ScheduleItem.RecurrenceTypeEnum.Yearly:
                    if (YearlyEveryNYearsSelected == true)
                    {
                        int yearlyCounter = 0;
                        while (counter < RecurrenceEndAfterNOccurences)
                        {
                            FutureDatesEnqueue(startDate.AddYears(yearlyCounter));
                            yearlyCounter += YearlyEveryNYears;
                            counter++;
                        }
                    }
                    else
                    {
                        throw new Exception("Yearly branch unexpectedly reached with no options selected");
                    }
                    break;
                default:
                    throw new Exception("Recurrence pattern " + RecurrenceType + " not found");
            }
            return true;
        }

        private void FutureDatesEnqueue(DateTime date)
        {
            //Normalize the date and Enqueue it
            FutureDates.Enqueue(NormalizeDate(date));

        }

        public DateTime NormalizeDate(DateTime date)
        {
            //Normalize the date to return the a date at 6am in the morning
            return new DateTime(date.Year, date.Month, date.Day, 6, 0, 0);
        }

        #endregion

    }
}
