using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AtomicSeller.Helpers;
using AtomicSeller.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AtomicSeller.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [LocalizedDisplayName("EmailAdress")]
        public string Login { get; set; }
        [Required]
        [LocalizedDisplayName("Password")]
        public string Password { get; set; }
        public string ReturnView { get; set; }
        public string ReturnControler { get; set; }

    }

    public class TenantsVM
    {
     //   public List<Tenant> TenantsList { get; set; }
    }

    public class LicenceVM
    {
       // public Licence Licence { get; set; }
       // public Offer Offer { get; set; }

    }


    public class ClientVM
    {
        //public AtomicClient AtomicClient { get; set; }
        //public Tenant Tenant { get; set; }
        public List<UserVM> UsersVMList { get; set; }
        public List<LicenceVM> LicenceVMs { get; set; }
        public C_UserProfiles UserProfilesList { get; set; }

        public string ContactName { get; set; }
        public string FirstUser { get; set; }
        public string FirstUserPassword { get; set; }
        public string FirstUserEmail { get; set; }
        public DateTime CreationDate { get; set; }
        public int ClientType { get; set; }
        public string IP { get; set; }
        public string IPInfo { get; set; }
        
        public ClientVM()
        {
            //UserProfilesList = new C_UserProfiles();
            //FirstUserVM = new ViewModels.UserVM();
        }

    }

    public class UserVM
    {
        public int UserID { get; set; }
        public int TenantID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string CompanyName { get; set; }
        public string UserProfileLib { get; set; }
        public C_UserProfiles UserProfilesList{ get; set; }
        public string UserProfileValue { get; set; }
        public UserVM()
        {
            UserProfilesList = new C_UserProfiles();
            UserProfileValue = UserProfilesList.SelectedProfile;
        }
    }

    public class C_UserProfiles
    {
        public C_UserProfiles()
        {
            //UserProfilesListSL = new DA_LD().GetProfilesList();
            //SelectedProfile = UserProfilesListSL.First().Value;
        }
        public IEnumerable<SelectListItem> UserProfilesListSL { get; set; }
        public string SelectedProfile { get; set; }
    }

    public class ResetPasswordVM
    {
        public string ReturnToken { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string UserEmail { get; set; }
        public ResetPasswordVM()
        {
        }
    }

    public enum TargetTenantEnvironment : int
    {
        Test = 1,
        Prod = 2,
        Dev = 3,
        Sandbox = 4,
        Qualif = 5
    }
    /*
    public enum LicenceType : int
    {
        EcommerceStart = 1,
        EcommerceLevel1 = 2,
        EcommerceLevel2 = 3,
        EcommerceLevel3 = 4,
        EcommerceLevel4 = 5,
        LogisticsStart = 6,
        LogisticsLevel1 = 7,
        LogisticsLevel2 = 8,
        LogisticsLevel3 = 9,
        LogisticsLevel4 = 10,
    }
    */
    public enum ClientType : int
    {
        Logistics = 1,
        Specific = 2,
        Ecommerce = 3,
    }

    public enum UserProfileLevel : int
    {
        SuperAdministrator = 1,
        ClientAdministrator = 2,
        WarehouseUser = 3,
        EMerchant = 4,
        ReadOnlyUser = 5,
        }


    public class TenantVM
    {
        public List<DB> DBs { get; set; }
        public DB SourceDB { get; set; }
        public DB TargetDB { get; set; }
        public int TargetTenantEnvironment { get; set; }
        public string TenantDirectory { get; set; }
        public string TenantCompany { get; set; }
        public string TenantUser { get; set; }
        public string TenantPassword { get; set; }
        public int TenantLicence { get; set; }
        //public Tenant Tenant { get; set; }
    }

    public class DB
    {
        public string DBName { get; set; }
        public string DBType { get; set; }
        public DB()
        {
            DBType = "TEST";
        }

    }

    public class CheckoutVM
    {
        public List<CheckoutProduct> CheckoutProducts { get; set; }

        public decimal TotalExlTax { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalInclTax { get; set; }
        public string Currency{ get; set; }    
        public bool IsConnected { get; set; }
        public string UserName { get; set; }
        public string Company { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ReturnView { get; set; }
        public string ReturnControler { get; set; }
    //    public AtomicClient AtomicClient { get; set; }
        public ClientVM ClientVM { get; set; }
    }

    public class CheckoutProduct
    {        
        public int ProductID { get; set; }
        public string OfferSKU { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal PriceExlTax { get; set; }
        public decimal Tax { get; set; }
        public decimal PriceInclTax { get; set; }
    }

    public class AccountVM
    {
        public ClientVM ClientVM { get; set; }


    }


}