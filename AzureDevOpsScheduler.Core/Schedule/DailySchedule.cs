using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevOpsScheduler.Core.Schedule
{
    public class DailySchedule : BaseSchedule
    {

        public bool DailyEveryNDaysSelected { get; set; }
        public int DailyEveryNDays { get; set; }
        //public bool DailyEveryWeekDaySelected { get; set; }

        public string Name
        {
            get
            {
                string name = "";
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

                return name;
            }
        }

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

            return true;
        }



    }
}
