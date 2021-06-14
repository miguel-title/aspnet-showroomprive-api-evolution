using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicJs.Models.ASTRD
{
    public partial class Log
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public string CallSite { get; set; }
        public string Logger { get; set; }
        public string Exception { get; set; }
        public string MachineName { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Thread { get; set; }
        public string Username { get; set; }
        public DateTime Date { get; set; }
    }
}
