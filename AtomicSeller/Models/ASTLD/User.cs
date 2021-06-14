using System;
using System.Collections.Generic;

#nullable disable

namespace AtomicJs.Models.ASTLD
{
    public partial class User
    {
        public int UserId { get; set; }
        public int? TenantId { get; set; }
        public int? ClientId { get; set; }
        public int? UserProfileId { get; set; }
        public int? ProfileId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserEmail { get; set; }
        public string PwResetToken { get; set; }
        public DateTime? PwResetTokenValidity { get; set; }
        public string MerchantKey { get; set; }
        public string Apitoken { get; set; }
    }
}
