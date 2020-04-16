using AzureDevOpsScheduler.Core.Schedule;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureDevOpsScheduler.Core.Schedule
{
    public class ScheduleItemController
    {
        public ScheduleItem ProcessJSON(string json)
        {
            ScheduleItem item = JsonConvert.DeserializeObject<ScheduleItem>(json);

            return item;
        }

        public string CreateJSON(ScheduleItem item)
        {
            string json = JsonConvert.SerializeObject(item);

            return json;
        }
    }
}
