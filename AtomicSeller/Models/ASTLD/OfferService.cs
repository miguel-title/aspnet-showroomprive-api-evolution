using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicJs.Models.ASTLD
{
    public partial class OfferService
    {
        public int OfferServiceId { get; set; }
        public int? OfferId { get; set; }
        public string Sku { get; set; }
        public string Periodicity { get; set; }
        public string Active { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Category { get; set; }
        public string AmountExclVat { get; set; }
        public string Vatfr { get; set; }
        public string Currency { get; set; }
    }
}
