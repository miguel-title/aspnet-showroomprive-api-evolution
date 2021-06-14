using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicJs.Models.ASTLD
{
    public partial class Tenant
    {
        public int TenantId { get; set; }
        public int? AtomicClientId { get; set; }
        public string AtomicClientKey { get; set; }
        public int? TenantType { get; set; }
        public string Dbname { get; set; }
        public string ConnectionString { get; set; }
        public string Status { get; set; }
        public string CompanyName { get; set; }
        public string TenantDirectory { get; set; }
        public string Token { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ReportingEmails { get; set; }
    }
}
