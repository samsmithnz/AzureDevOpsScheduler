using System;
using System.Collections.Generic;
using System.Text;

namespace AzureDevOpsScheduler.Core.Schedule
{
    public class BaseSchedule
    {
        public BaseSchedule()
        {
            FutureDates = new Queue<DateTime>();
        }

        public enum RecurrenceTypeEnum
        {
            Daily,
            Weekly,
            Monthly,
            Yearly
        }
        public RecurrenceTypeEnum RecurrenceType { get; set; } //daily, weekly, monthly, yearly

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

        public void FutureDatesEnqueue(DateTime date)
        {
            //Normalize the date and Enqueue it
            FutureDates.Enqueue(NormalizeDate(date));

        }

        public DateTime NormalizeDate(DateTime date)
        {
            //Normalize the date to return the a date at 6am in the morning
            return new DateTime(date.Year, date.Month, date.Day, 6, 0, 0);
        }

    }
}
