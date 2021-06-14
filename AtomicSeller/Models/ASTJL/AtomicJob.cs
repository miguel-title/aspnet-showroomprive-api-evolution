using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicJs.Models.ASTJL
{
    public partial class AtomicJob
    {
        public int JobId { get; set; }
        public string JobName { get; set; }
        public TimeSpan? DailyStartTime { get; set; }
        public TimeSpan? DailyEndTime { get; set; }
        public DateTime? LastExecutionTime { get; set; }
        public TimeSpan? JobPeriod { get; set; }
        public string Repeat { get; set; }
        public string Enabled { get; set; }
        public string Category { get; set; }
        public int? TenantId { get; set; }
        public string WebserviceKey { get; set; }
        public string WebserviceStoreKey { get; set; }
        public string WebserviceCarrierServiceKey { get; set; }
        public string WebserviceWmskey { get; set; }
        public string WebserviceReportingKey { get; set; }
        public string WebServiceOutput { get; set; }
    }
}
