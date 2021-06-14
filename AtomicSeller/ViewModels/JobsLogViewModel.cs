using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AtomicJs.Models.ASTJL;
using AtomicSeller.Models;

namespace AtomicSeller.ViewModels
{
    public class JobsLogVM
    {
        public int LogID { get; set; }
        public string JobName { get; set; }
        public Nullable<int> JobID { get; set; }
        public Nullable<System.DateTime> DateStart { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
        public string ReturnCode { get; set; }
        public string ErrorMessage { get; set; }
        public int TenantID { get; set; }
    }

    public class JobVM
    {
        public AtomicJob jobs { get; set; }
        public AtomicJobslog jobslog { get; set; }

    }

    public class JobVMs
    {
        public List<AtomicJob> AtomicJobs { get; set; }

    }

    public class JobLogVMs
    {
        public List<AtomicJobslog> Atomicjoblogs { get; set; }

    }

}