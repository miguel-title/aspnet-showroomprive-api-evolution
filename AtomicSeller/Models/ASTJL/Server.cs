using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicJs.Models.ASTJL
{
    public partial class Server
    {
        public string Id { get; set; }
        public string Data { get; set; }
        public DateTime LastHeartbeat { get; set; }
    }
}
