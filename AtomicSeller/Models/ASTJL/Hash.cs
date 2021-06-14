using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicJs.Models.ASTJL
{
    public partial class Hash
    {
        public string Key { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
        public DateTime? ExpireAt { get; set; }
    }
}
