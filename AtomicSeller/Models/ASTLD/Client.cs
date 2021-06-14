using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicJs.Models.ASTLD
{
    public partial class Client
    {
        public int ClientId { get; set; }
        public string ClientKey { get; set; }
        public int? ClientLicenceProfileId { get; set; }
        public string CompanyName { get; set; }
        public string Adr1 { get; set; }
        public string Adr2 { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? ContractType { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? UserMax { get; set; }
        public string TenantDirectory { get; set; }
        public string TenantDatabase { get; set; }
        public string ConnectionString { get; set; }
        public string Token { get; set; }
        public DateTime? CreationDate { get; set; }
        public string ReportingEmails { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public int? ClientType { get; set; }
    }
}
