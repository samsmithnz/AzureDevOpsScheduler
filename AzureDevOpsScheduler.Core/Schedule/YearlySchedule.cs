using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevOpsScheduler.Core.Schedule
{
    public class YearlySchedule : BaseSchedule
    {


        public string Name
        {
            get
            {
                string name = "";

                name += "Yearly ";
                if (YearlyEveryNYearsSelected == true)
                {
                    name += "every " + YearlyEveryNYears + " years ";
                }
                name += "for a total of " + FutureDates.Count + " FutureDates";

                return name;
            }
        }



        public bool YearlyEveryNYearsSelected { get; set; }
        public int YearlyEveryNYears { get; set; }




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

            return true;
        }


    }
}
