using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicJs.Models
{
    public partial class Jobslog
    {
        public int LogId { get; set; }
        public int? JobId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string ReturnCode { get; set; }
        public string ErrorMessage { get; set; }
        public string JobName { get; set; }
    }
}
