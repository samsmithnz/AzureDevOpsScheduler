using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevOpsScheduler.Core.Schedule
{
    public class WeeklySchedule : BaseSchedule
    {

        public string Name
        {
            get
            {
                string name = "";
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

                return name;
            }
        }

        public int WeeklyEveryNWeeks { get; set; }
        public bool WeeklyDayOfWeekSunday { get; set; }
        public bool WeeklyDayOfWeekMonday { get; set; }
        public bool WeeklyDayOfWeekTuesday { get; set; }
        public bool WeeklyDayOfWeekWednesday { get; set; }
        public bool WeeklyDayOfWeekThursday { get; set; }
        public bool WeeklyDayOfWeekFriday { get; set; }
        public bool WeeklyDayOfWeekSaturday { get; set; }

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

            return true;
        }

    }
}
