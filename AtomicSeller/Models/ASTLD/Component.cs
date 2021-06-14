using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicJs.Models.ASTLD
{
    public partial class Component
    {
        public int ComponentId { get; set; }
        public string ComponentKey { get; set; }
        public string ComponentName { get; set; }
        public string MaxLabelsTest { get; set; }
        public string MaxShippingsTest { get; set; }
        public string MaxStoresTest { get; set; }
        public string MaxUsersTest { get; set; }
    }
}
