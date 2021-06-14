using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicJs.Models.ASTRD
{
    public partial class Department
    {
        public double? Id { get; set; }
        public double? RegionCode { get; set; }
        public double? Code { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
