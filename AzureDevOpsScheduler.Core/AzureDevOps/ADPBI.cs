using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevOpsSchedule.Core.AzureDevOps
{
    public class ADPBI
    {
        public ADPBI()
        {
            Tags = new List<string>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }

    }
}
