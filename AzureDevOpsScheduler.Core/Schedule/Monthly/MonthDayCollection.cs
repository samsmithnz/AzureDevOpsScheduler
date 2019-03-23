using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevOpsSchedule.Core.Schedule.Monthly
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

        public MonthDay FindDayOfWeek(DayOfWeek dayOfWeek, ScheduleItem.MonthlyTheNOccurrenceEnum occurence)
        {
            if (occurence != ScheduleItem.MonthlyTheNOccurrenceEnum.Last)
            {
                //Loop through the days forwards, looking for the right day and occurence
                foreach (MonthDay item in Days)
                {
                    if (item.DayOfWeek == dayOfWeek && item.Count == (int)occurence + 1)
                    {
                        return item;
                    }
                }
            }
            else if (occurence == ScheduleItem.MonthlyTheNOccurrenceEnum.Last)
            {
                //Loop through the days backwards looking for the last day
                for (int i = Days.Count - 1; i >= 0; i--)
                {
                    if (Days[i].DayOfWeek == dayOfWeek)
                    {
                        return Days[i];
                    }
                }
            }
            return null;
        }

    }
}
