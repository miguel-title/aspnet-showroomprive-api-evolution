using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtomicSeller.ViewModels
{

    public class JobRealTime
    {
        public Nullable<int> JobID { get; set; }
        public string JobName { get; set; }
        public Nullable<System.TimeSpan> DateStart { get; set; }
        public Nullable<System.TimeSpan> DateEnd { get; set; }
        public string Category { get; set; }
        public Nullable<int> TenantID { get; set; }
        public string JobKey { get; set; }
        public Nullable<System.DateTime> nextFireTime { get; set; }
        public Nullable<System.DateTime> previousFireTime { get; set; }
        public string strnextFireTime { get; set; }
        public string strpreviousFireTime { get; set; }
    }

    public class JobsRealTimeVMs
    {
        public List<JobRealTime> jobsRealTime { get; set; }
    }
}