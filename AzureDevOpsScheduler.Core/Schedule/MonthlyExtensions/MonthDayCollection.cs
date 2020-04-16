using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevOpsScheduler.Core.Schedule.MonthlyExtensions
{
    public class MonthDayCollection
    {
        public MonthDayCollection()
        {
            Days = new List<MonthDay>();
        }

        public List<MonthDay> Days { get; set; }

        public int CountDayOfWeek(DayOfWeek dayOfWeek)
        {
            int result = 0;
            foreach (MonthDay item in Days)
            {
                if (item.DayOfWeek == dayOfWeek)
                {
                    result++;
                }
            }
            return result;
        }

        public MonthDay FindDayOfWeek(DayOfWeek dayOfWeek, MonthlySchedule.MonthlyTheNOccurrenceEnum occurence)
        {
            MonthDay result = null;
            if (occurence != MonthlySchedule.MonthlyTheNOccurrenceEnum.Last)
            {
                //Loop through the days forwards, looking for the right day and occurence
                foreach (MonthDay item in Days)
                {
                    if (item.DayOfWeek == dayOfWeek && item.Count == (int)occurence + 1)
                    {
                        result = item;
                        break;
                    }
                }
            }
            else if (occurence == MonthlySchedule.MonthlyTheNOccurrenceEnum.Last)
            {
                //Loop through the days backwards looking for the last day
                for (int i = Days.Count - 1; i >= 0; i--)
                {
                    if (Days[i].DayOfWeek == dayOfWeek)
                    {
                        result = Days[i];
                        break;
                    }
                }
            }
            return result;
        }

    }
}
