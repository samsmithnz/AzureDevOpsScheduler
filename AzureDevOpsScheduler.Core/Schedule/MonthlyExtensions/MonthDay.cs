using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevOpsScheduler.Core.Schedule.MonthlyExtensions
{
    public class MonthDay
    {
        public DayOfWeek DayOfWeek { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
    }
}
