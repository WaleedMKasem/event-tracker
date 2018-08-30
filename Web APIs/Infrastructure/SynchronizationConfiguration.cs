
using System.Collections.Generic;

namespace Z2data.Web.APIs.Infrastructure
{
    public class SynchronizationConfiguration
    {
        public double StabilityDuration { get; set; }
        public int JobExecutionInterval { get; set; }
        public long SystemUserID { get; set; }
        public List<int> VisitStatusesList { get; set; }
        public List<int> VisitClassificationIDs { get; set; }

        public SynchronizationConfiguration()
        {
            //StabilityDuration = double.Parse(Configuration.GetConfig("StabilityDuration"));
            //JobExecutionInterval = int.Parse(Configuration.GetConfig("JobExecutionInterval"));
            //SystemUserID = long.Parse(Configuration.GetConfig("SystemUserID"));
            //VisitStatusesList = Configuration.GetConfig("VisitStatusesList").Split(',').Select(Int32.Parse).ToList();
            //VisitClassificationIDs = Configuration.GetConfig("VisitClassificationIDs").Split(',').Select(Int32.Parse).ToList();
        }
    }
}