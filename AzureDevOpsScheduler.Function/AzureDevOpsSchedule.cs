using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureDevOpsScheduler.Function
{
    public static class AzureDevOpsSchedule
    {
        [FunctionName("AzureDevOpsSchedule")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            //Look for items that need to be processed


            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
