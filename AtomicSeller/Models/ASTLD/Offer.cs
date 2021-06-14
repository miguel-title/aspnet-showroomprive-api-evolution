using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicJs.Models.ASTLD
{
    public partial class Offer
    {
        public int OfferId { get; set; }
        public string OfferSku { get; set; }
        public string CustomerType { get; set; }
        public string DisplayGroup { get; set; }
        public string OfferName { get; set; }
        public int? NbUsersMax { get; set; }
        public int? NbShippingMax { get; set; }
        public int? NbStoresMax { get; set; }
        public int? NbLabelsMax { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? DisplayOrder { get; set; }
        public int? UpgradeId { get; set; }
        public int? DownGradeId { get; set; }
    }
}
