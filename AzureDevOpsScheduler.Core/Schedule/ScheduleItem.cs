using AzureDevOpsScheduler.Core.Schedule;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureDevOpsScheduler.Core.Schedule
{
    public class ScheduleItem
    {
        public string ScheduleItemType
        {
            get
            {
                string scheduleItemTypeName = "";
                int objectCount = 0;
                if (DailySchedule != null)
                {
                    objectCount++;
                    scheduleItemTypeName = "Daily";
                }
                if (WeeklySchedule != null)
                {
                    objectCount++;
                    scheduleItemTypeName = "Weekly";
                }
                if (MonthlySchedule != null)
                {
                    objectCount++;
                    scheduleItemTypeName = "Monthly";
                }
                if (YearlySchedule != null)
                {
                    objectCount++;
                    scheduleItemTypeName = "Yearly";
                }

                if (objectCount == 1)
                {
                    return scheduleItemTypeName;
                }
                else if (objectCount == 0)
                {
                    throw new Exception("object has no types and cannot be processed");
                }
                else // count > 1
                {
                    throw new Exception("object has multiple types and cannot be processed");
                }
            }
        }
        public DailySchedule DailySchedule;
        public WeeklySchedule WeeklySchedule;
        public MonthlySchedule MonthlySchedule;
        public YearlySchedule YearlySchedule;
    }
}
