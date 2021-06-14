using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.Entity;
using AtomicSeller.Models;
using AtomicSeller.ViewModels;
using AtomicSeller.Controllers;
using AtomicSeller.Helpers;
using AtomicSeller.Models.Data;
using AtomicJs.Models.ASTLD;
//using System.Web.Mvc;
//using AtomicSeller.AccessRights;

namespace AtomicSeller
{
    public class DA_LD  // Licencing data
    {
        
        public List<Tenant> GetTenants()
        {
            List<Tenant> _ClientsList = new List<Tenant>();

            using (ASTLDContext _context = new ASTLDContext())
                {
                _ClientsList = _context.Tenants.ToList();
                return _ClientsList;
            }
        }

        /*
        public string GetTenantDirectory()
        {
            string TD = string.Empty;

            try
            {
                TD = SessionBag.Instance.TenantDirectory;
            }
            catch
            {
                return "Null";
            }

            if (TD == null)
            {
                //using (var db = new AtomicLoginDataEntities())
                //{
                //    TD = db.User.FirstOrDefault(u => u.UserID == SessionBag.Instance.UserId).TenantDirectory;
                //}
                User user = null;
                Tenant Client = null;
                if (SessionBag.Instance.ClientID==0)
                {
                    int UserID = SessionBag.Instance.UserId;
                    try
                    {
                        using (ASTLDContext _context = new ASTLDContext())
                        {
                            user = _context.Users.FirstOrDefault(u => u.UserId == UserID);

                            if (user != null)
                                Client = _context.Tenants.FirstOrDefault(c => c.TenantId == user.TenantId);
                        }
                    }
                    catch
                    { }
                }
                else
                    using (ASTLDContext _context = new ASTLDContext())
                    {
                    Client = _context.Tenants.FirstOrDefault(c => c.TenantId == SessionBag.Instance.ClientID);
                }
                TD = Client.TenantDirectory;
                SessionBag.Instance.TenantDirectory = TD;
            }

            return TD;
        }
        */
        public Tenant GetReferenceTenant()
        {
            using (ASTLDContext _context = new ASTLDContext())
            {
                Tenant _Tenant = _context.Tenants.FirstOrDefault(t => t.Status.ToUpper() == "REFERENCE");

                return _Tenant;
            }
        }

        public void UpdateTenant(Tenant _Tenant)
        {
            using (ASTLDContext _context = new ASTLDContext())
            {
                Tenant _Tenant2 = _context.Tenants.FirstOrDefault(t => t.TenantId == _Tenant.TenantId);
                if (_Tenant2 != null)
                {
                    //db.Entry(_TenantDataBase).CurrentValues.SetValues(_Tenant);
                    _context.Entry(_Tenant2).CurrentValues.SetValues(_Tenant);

                    _context.SaveChanges();
                }
            }
        }
    
        /*
        public string GetCurrentUserLogin(string APIToken=null)
        {
            string CurrentUserName = string.Empty;

            if (string.IsNullOrEmpty(APIToken) == false)
            {
                // Logout

                // Login
                //CurrentUserName = new AccountController().ConnectUser("", "", APIToken);
                if (SessionBag.Instance == null) return "NullInstance";
                using (ASTLDContext _context = new ASTLDContext())
                {
                    User _User = _context.Users.FirstOrDefault(u => u.Apitoken == APIToken);
                    if (_User == null) 
                        CurrentUserName = "TOKEN NOT FOUND";
                    else
                        CurrentUserName = _User.UserName;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(CurrentUserName))
                {
                    if (SessionBag.Instance == null) return "NullInstance";

                    using (ASTLDContext _context = new ASTLDContext())
                    {
                        User _User = _context.Users.FirstOrDefault(u => u.UserId == SessionBag.Instance.UserId);
                        CurrentUserName = _User.UserName;
                    }
                }
            }
            return CurrentUserName;
        }
        */
        /*
        public User GetCurrentUser(int? UserID=null)
        {
            User _User = null;
            if (UserID == null) UserID = SessionBag.Instance.UserId;
                if (SessionBag.Instance == null) return null;

            using (ASTLDContext _context = new ASTLDContext())
            {
                    _User = _context.Users.FirstOrDefault(u => u.UserId == UserID);
                }
            return _User;
        }
        */
        public User GetUserFromEmail(string email)
        {
            User _User = null; 
            if (!string.IsNullOrEmpty(email))
            {
                using (ASTLDContext _context = new ASTLDContext())
                {
                    _User = _context.Users.FirstOrDefault(u => u.UserEmail == email);
                }

            }
            return _User;
        }
       
        public User GetUserFromToken(string Token)
        {
            User _User = null;
            if (!string.IsNullOrEmpty(Token))
            {
                using (ASTLDContext _context = new ASTLDContext())
                {
                    _User = _context.Users.FirstOrDefault(u => u.PwResetToken == Token);
                }
                if (_User == null) return null;

                if (_User.PwResetTokenValidity < DateTime.Now)
                    _User = null;
            }
            return _User;
        }

        public int CountNbUsers(int UserID)
        {
            using (ASTLDContext _context = new ASTLDContext())
            {

                User _User = _context.Users.FirstOrDefault(c => c.UserId  == UserID);

                int NbUsers = _context.Users.Where(c => c.TenantId == _User.TenantId).Count();
               
                return NbUsers;
            }
        }

        public string UpdatePassword(int UserID, string Password)
        {

            using (ASTLDContext _context = new ASTLDContext())
            {
                User _User = _context.Users.FirstOrDefault(c => c.UserId == UserID);
                _User.PwResetToken = "";
                _User.PwResetTokenValidity = DateTime.Now;
                _User.Password = new Tools().Encrypt(Password);

                _context.SaveChanges();
                return _User.PwResetToken;
            }
        }


        public bool CheckExistingUserName(string username)
        {
            using (ASTLDContext _context = new ASTLDContext())
            {
                User _User = _context.Users.FirstOrDefault(c => c.UserName == username);
                return _User != null;
            }
        }

        public bool CheckExistingEmail(string Email)
        {
            using (ASTLDContext _context = new ASTLDContext())
            {
                User _User = _context.Users.FirstOrDefault(c => c.UserEmail == Email);
                return _User != null;
            }
        }

        public string GetCurrentClientName(int ClientID)
        {
            string CurrentClientName = string.Empty;
            Tenant Client = null;

          
            try
            {
                using (ASTLDContext _context = new ASTLDContext())
                {
                    Client = _context.Tenants.FirstOrDefault(c => c.TenantId == ClientID);
                    CurrentClientName = Client.CompanyName;
                }
                //}
            }
            catch (Exception ex)
            {
                CurrentClientName = ex.InnerException.Message;
            }
            return CurrentClientName;
        }

/*        
        public int GetCurrentTenantID(SessionBag sessionBag)
        {

            if (sessionBag.TenantID > 0) return sessionBag.TenantID;

            int UserID = 0;

            if (sessionBag.UserId != null)
                UserID = sessionBag.UserId;
            else
                return 0;

            int TenantID = 0;

            using (ASTLDContext _context = new ASTLDContext())
            {
                var _User = _context.Users.FirstOrDefault(u => u.UserId == UserID);
                TenantID = (int)_User.TenantId;
            }
                
            return TenantID;
        }

        public Tenant GetTenant(int TenantID)
        {
            using (ASTLDContext _context = new ASTLDContext())
            {
                return _context.Tenants.FirstOrDefault(t => t.TenantId == TenantID);
            }

        }
*/
        
        public Tenant GetTenantByUserID(int UserID)
        {
            Tenant _Tenant = null;

            try
            {
                using (ASTLDContext _context = new ASTLDContext())
                {
                    User User = _context.Users.FirstOrDefault(u => u.UserId == UserID);
                    if (User == null) return null;
                    
                    int TenantID = (int)User.TenantId;
                    _Tenant = _context.Tenants.FirstOrDefault(c => c.TenantId == TenantID);

                    if (_Tenant.TenantType == null)
                    {
                        _Tenant.TenantType = (int)ClientType.Ecommerce;
                        _context.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                Tools.ErrorHandler("GetTenantByUserID error", ex);
                _Tenant = null;
            }

            return _Tenant;
        }

        /*
        public List<ProfileRight> GetProfileRights(string ProfileID, string ObjectType)
        {

            int _ProfileID = Convert.ToInt32(ProfileID);

            using (var db = new AtomicTenantEntities(SessionBag.Instance.ConnectionString))
            {
                return db.ProfileRight.Where(p =>
                (p.ProfileID == _ProfileID)
                &&
                (p.ObjectType == ObjectType)
                ).ToList();

            }
        }
        public bool ClearProfileRights(long ProfileID, string ObjectType)
        {
            using (var db = new AtomicTenantEntities(SessionBag.Instance.ConnectionString))
            {
                ProfileRight _ProfileRight = db.ProfileRight.FirstOrDefault(p =>
                    (p.ProfileID == ProfileID)
                    &&
                    (p.ObjectType == ObjectType)
                    );
                if (_ProfileRight != null)
                {
                    db.ProfileRight.Remove(_ProfileRight);
                    db.SaveChanges();
                }
            }
            return true;
        }
        public bool SetProfileRight(string FunctionName, long ProfileID, string ObjectType, string AccessRight)
        {
            ProfileRight _ProfileRight = new ProfileRight();
            //_ProfileRight.AccessID = 0;
            _ProfileRight.FunctionName = FunctionName;
            _ProfileRight.AccessRight = AccessRight;
            _ProfileRight.ProfileID = (int)ProfileID;
            _ProfileRight.ObjectType = ObjectType;
            _ProfileRight.CreationDate = DateTime.Now.ToString();
            _ProfileRight.LastModifiedDate = DateTime.Now.ToString();


            using (var db = new AtomicTenantEntities(SessionBag.Instance.ConnectionString))
            {
                db.ProfileRight.Add(_ProfileRight);
                db.SaveChanges();
                return true;
            }
        }

        public bool GetProfileRight(string FunctionName, int ProfileID, string ObjectType)
        {

            //////////////////
            using (var db = new AtomicTenantEntities(SessionBag.Instance.ConnectionString))
            {
                ProfileRight _ProfileRight = new ProfileRight();
                _ProfileRight = db.ProfileRight.FirstOrDefault(p =>
                    (p.ProfileID == ProfileID)
                    &&
                    (p.FunctionName == FunctionName)
                    );
                if (_ProfileRight != null)
                {
                    if (_ProfileRight.AccessRight == "Y")
                        return true;
                    else
                        return false;
                }
                else
                {
                    _ProfileRight.FunctionName = FunctionName;
                    _ProfileRight.AccessRight = "N";
                    _ProfileRight.ProfileID = ProfileID;
                    _ProfileRight.CreationDate = DateTime.Now.ToString();
                    _ProfileRight.LastModifiedDate = DateTime.Now.ToString();
                    db.ProfileRight.Add(_ProfileRight);
                    db.SaveChanges();
                    return false;
                }
            }
        }

        public List<SelectListItem> GetProfilesList()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            using (var db = new ASTLDEntities())
            {

                DbSet<UserProfile>  UserProfilesList = db.UserProfile;

                List<UserProfile> _UserProfilesList = new List<UserProfile>();

                if (UserProfilesList.Count() > 0)
                    _UserProfilesList = UserProfilesList.ToList();

                foreach (UserProfile _UP in _UserProfilesList)
                {
                    items.Add(new SelectListItem { Text = _UP.ProfileName, Value = _UP.UserProfileID.ToString(), Selected = false });
                }
            }
            return items;

        }

                */

        /*
        public List<Jobs> GetDailyJobs(int? ClientID= null, int? JobType = null, int? SettingID=null)
        {
            List<DailyJob> DailyJobsList= null;

            using (var db = new ASTLDEntities())
            {

                DailyJobsList = db.DailyJob.ToList();

                if (ClientID!=null)
                    DailyJobsList = DailyJobsList.Where(j => (j.ClientID == ClientID)).ToList();

                if (JobType != null)
                    DailyJobsList = DailyJobsList.Where(j => (j.JobType == JobType)).ToList();

                if (SettingID != null)
                    DailyJobsList = DailyJobsList.Where(j => (j.SettingID == SettingID)).ToList();

            }

            return DailyJobsList;
        }
        */

    }
}