using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicJs.Models
{
    public partial class JobTrigger
    {
        public int JobId { get; set; }
        public int? ClientId { get; set; }
        public string JobType { get; set; }
        public string EmailRecipient { get; set; }
        public string DailyTime1 { get; set; }
        public string DailyTime2 { get; set; }
        public string DailyTime3 { get; set; }
        public string DailyTime4 { get; set; }
        public string DailyTime5 { get; set; }
        public string DailyTime6 { get; set; }
        public string DailyTime7 { get; set; }
        public string DailyTime8 { get; set; }
    }
}
