using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicJs.Models
{
    public partial class Subscribtion
    {
        public int SubscripbtionId { get; set; }
        public string CompanyName { get; set; }
        public string Adr1 { get; set; }
        public string Adr2 { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ContractType { get; set; }
        public int? ClientType { get; set; }
        public string UserName { get; set; }
        public string FirstUserPassword { get; set; }
        public string FirstUserEmail { get; set; }
        public string Ip { get; set; }
        public string Ipinfo { get; set; }
        public string Sku { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public string Vatnumber { get; set; }
    }
}
