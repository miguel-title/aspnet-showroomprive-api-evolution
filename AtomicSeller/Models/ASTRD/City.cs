using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicJs.Models.ASTRD
{
    public partial class City
    {
        public int Id { get; set; }
        public string DepartmentCode { get; set; }
        public string InseeCode { get; set; }
        public string ZipCode { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string GpsLat { get; set; }
        public string GpsLng { get; set; }
        public string IsocountryCode { get; set; }
    }
}
