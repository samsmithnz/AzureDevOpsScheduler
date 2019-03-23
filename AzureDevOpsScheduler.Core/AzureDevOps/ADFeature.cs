using AzureDevOpsSchedule.Core.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevOpsSchedule.Core.AzureDevOps
{
    public class ADFeature
    {
        public ADFeature()
        {
            Tags = new List<string>();
            PBIs = new List<ADPBI>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public List<ADPBI> PBIs { get; set; }
        public DateTime TargetDate { get; set; }
        public ScheduleItem RecurringScheduleItem { get; set; }



    }
}
