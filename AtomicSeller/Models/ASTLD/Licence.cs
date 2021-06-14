using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicJs.Models.ASTLD
{
    public partial class Licence
    {
        public int LicenceId { get; set; }
        public int? OfferId { get; set; }
        public int? ClientId { get; set; }
        public string SerialKey { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PaymentPeriodicity { get; set; }
        public string LicenceStatus { get; set; }
    }
}
