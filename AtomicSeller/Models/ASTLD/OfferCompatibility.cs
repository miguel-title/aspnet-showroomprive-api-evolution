using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicJs.Models.ASTLD
{
    public partial class OfferCompatibility
    {
        public int OfferCompatibilityId { get; set; }
        public int? OfferOwnedId { get; set; }
        public int? OfferProposedId { get; set; }
        public string Compatibility { get; set; }
    }
}
