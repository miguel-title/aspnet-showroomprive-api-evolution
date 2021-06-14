using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicJs.Models.ASTRD
{
    public partial class Holiday
    {
        public int HolidayId { get; set; }
        public DateTime? Date { get; set; }
        public string ShippingService { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Lib { get; set; }
    }
}
