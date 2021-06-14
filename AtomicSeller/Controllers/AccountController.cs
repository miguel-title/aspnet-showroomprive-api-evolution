using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using AtomicSeller.Helpers;
using AtomicSeller.ViewModels;
using AtomicSeller.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
//using WebMatrix.WebData;
//using System.Data.Entity.Core.EntityClient;

using AtomicSeller;
using AtomicJs.Models.ASTLD;

namespace AtomicSeller.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            //Test the DB Operation
            HangFireJob _job = new HangFireJob();
            _job.RecurringJob();

            // Si on est déjà authentifié, on redirige vers l'accueil
            if (User.Identity.IsAuthenticated)
            {
                //Flash(new FlashMessage("Vous avez été connecté automatiquement"));
                Flash(new FlashMessage(new Local().TranslatedMessage("ALREADYCONNECTED")));

                return RedirectToAction("Index", "Home");
            }

            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model, string returnUrl)
        {
            // Si l'une des infos n'est pas donnée
            if (!ModelState.IsValid)
            {
                //Flash(new FlashMessage("Veuillez remplir les champs", FlashMessageType.Error));
                Flash(new FlashMessage(new Local().TranslatedMessage("PLEASEFILLUPFILEDS"), FlashMessageType.Error));
                return View(model);
            }

            // Trim() de l'identifiant
            model.Login = model.Login.Trim();

            User user = null;
            Tenant Client = null;

            try {
                using (ASTLDContext _context = new ASTLDContext())
                {
                    user = _context.Users.FirstOrDefault(u => u.UserName == model.Login && u.Password == new Tools().Encrypt(model.Password));
                }
            }
            catch (Exception ex)
            {
                Flash(new FlashMessage(ex.Message + " " + ex.InnerException + "\n" + ex.StackTrace, FlashMessageType.Error));



            //Tools.ErrorHandler(ex.Message + " " + ex.InnerException + "\n" + ex.StackTrace, null, false, true, false);
                return View(model);
            }

            // Authentication fail
            if (user == null)
            {
                //Flash(new FlashMessage("Le nom d'utilisateur ou le mot de passe est incorrect.", FlashMessageType.Error));
                Flash(new FlashMessage(new Local().TranslatedMessage("WRONGUSERNAMEORPASSWORD"), FlashMessageType.Error));


                return View(model);
            }
            else
            {
                this.setSessionBagInitData(user, Client);

                var loginClaim = new Claim(ClaimTypes.Sid, user.UserId.ToString()); 
                var claims = new[] { loginClaim };
                var claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie");
                var authProperties = new AuthenticationProperties();

                HttpContext.SignInAsync(
                  CookieAuthenticationDefaults.AuthenticationScheme,
                  new ClaimsPrincipal(claimsIdentity),
                  authProperties);


                //var ctx = Request.GetOwinContext();
                //var authenticationManager = ctx.Authentication;
                //authenticationManager.SignIn(claimsIdentity);

                // 

                // Rediriger vers l'URL d'origine si existante
                if (Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);

                if (string.IsNullOrEmpty (model.ReturnView)==false && string.IsNullOrEmpty(model.ReturnControler) == false)
                   {
                    return RedirectToAction(model.ReturnView, model.ReturnControler);
                    }
                else
                    // Par défaut, redirection vers la page d'index
                    //return RedirectToAction("Index", "Home");
                    return Redirect("/Home/Index");
            }
        }



 
        [HttpGet]
        public IActionResult Logout(string ReturnView=null, string ReturnControler = null)
        {
            //var ctx = Request.GetOwinContext();
            //var authenticationManager = ctx.Authentication;
            //authenticationManager.SignOut();
            
            HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            //Destroy SessionBag
            //if (SessionBag.Instance != null && new SessionBag().Exists(Session))
            //    SessionBag.Instance.Destroy(Session);

            //Clear all session keys
            //Session.Clear();

            if (string.IsNullOrEmpty(ReturnView) == false && string.IsNullOrEmpty(ReturnControler) == false)
                return RedirectToAction(ReturnView, ReturnControler);
            else
                return RedirectToAction("Login");
        }

        [HttpPost]
        //[HttpGet]
        [AllowAnonymous]
        public IActionResult CreateAccount(ClientVM model)
        {
                return RedirectToAction("Index", "Home");
        }

        public ClientVM SetupClientVM(ClientVM model)
        {
            if (model == null)
            {
                model = new ViewModels.ClientVM();
                //model.ClientID = 0;
            }
            return model;
        }

        public bool CheckUserClientVM(ClientVM model)
        {
            if (model == null)
            {
                return false;
            }


            if (string.IsNullOrEmpty(model.FirstUser))
            {
                Flash(new FlashMessage("Please fillup User name", FlashMessageType.Warning));
                return false;
            }

            if (string.IsNullOrEmpty(model.FirstUserPassword))
            {
                Flash(new FlashMessage("Please fillup Password", FlashMessageType.Warning));
                return false;
            }
            if (string.IsNullOrEmpty(model.FirstUserEmail))
            {
                Flash(new FlashMessage("Please fillup email", FlashMessageType.Warning));
                return false;
            }



            return true;
        }

        public bool CheckClientClientVM(ClientVM model)
        {
            if (model == null)
            {
                return false;
            }
            return true;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult OpenAccount(ClientVM model, int? SubID)
        {
            if (model == null)
            {
                model = SetupClientVM(model);
            }


            model.CreationDate = DateTime.Now;

            return View(model);
        }        

        [HttpGet]
        public IActionResult UserProfile(int? UserID = null)
        {

            if (UserID == null)
            {
                if (UserID != null)
                    UserID = this.UserId;
                else return RedirectToAction("Index", "Home");
            }

            // Feed model
            UserVM model = new ViewModels.UserVM();

            var _User = new User();
                model.UserName = _User.UserName;
                //model.UserName = _User.UserName;


                //List<Models.UserProfiles> _UserProfiles = new List<Models.UserProfiles>();
                //model.UserProfilesList = db.UserProfiles.ToList();


            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult InputEmailRecoverPassword()
        {
            var model = new ResetPasswordVM();

            return View();
        }

        public void SendCheckValidEmaillink(string FirstUserEmail)
        {
            User _User = new User(); // DA_LD().GetUserFromEmail(FirstUserEmail);

            if (_User != null)
            {
                string To = FirstUserEmail;//, UserID, Password, SMTPPort, Host;
                //Tools.Generate_Token_User(_User.UserID); 
                string token = ""; // new Tools().Generate_Token_User(_User.UserID); //WebMatrix.WebData.WebSecurity.GeneratePasswordResetToken(_User.UserName);
                _User = new User(); // DA_LD().GetUserFromEmail(FirstUserEmail);
                if (token == null || _User.PwResetTokenValidity == null || _User.PwResetTokenValidity < DateTime.Now)
                {
                    Flash(new FlashMessage("Unknown email address"));
                    // If user does not exist or is not confirmed.  
                }
                else
                {
                    //Create URL with above token  
                    var lnkHref = "<a href='" + Url.Action("ConfirmEmail", "Account", new { email = FirstUserEmail, token = token }, "http") + "'>Reset Password</a>";


                    //Flash(new FlashMessage("Email confirmation link sent"));

                }

            }

        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SendRecoverPasswordLink(ResetPasswordVM model)
        {
            string UserEmail = model.UserEmail;

            User _User = new User(); // DA_LD().GetUserFromEmail(UserEmail); 

            if (_User!=null)
            {
                string To = UserEmail;//, UserID, Password, SMTPPort, Host;
                //Tools.Generate_Token_User(_User.UserID); 
                string token = "";//new Tools().Generate_Token_User(_User.UserID); //WebMatrix.WebData.WebSecurity.GeneratePasswordResetToken(_User.UserName);
                //_User = ""; // new DA_LD().GetUserFromEmail(UserEmail);
                if (token == null || _User.PwResetTokenValidity == null || _User.PwResetTokenValidity < DateTime.Now)
                {
                    Flash(new FlashMessage("Unknown email address"));
                    // If user does not exist or is not confirmed.  
                    return RedirectToAction("Login","Account");
                }
                else
                {
                    //Create URL with above token  
                    var lnkHref = "<a href='" + Url.Action("ResetPassword", "Account", new { email = UserEmail, token = token }, "http") + "'>Reset Password</a>";

                    //HTML Template for Send email  
                    string subject = "AtomicSeller password reset link";

                    string body = "<b>Please find the Password Reset Link. </b><br/>" + lnkHref;

                    //new Email().SendMail(subject, body, To);

                    Flash(new FlashMessage("Reset password link sent"));

                }

            }


            //string connectionStringName = "AtomicLoginDataEntities";
            /*
                        WebMatrix.WebData.WebSecurity.InitializeDatabaseConnection(connectionStringName,
                            "dbo.User",
                            "UserID",
                            "UserName",
                            true);

                        if (ModelState.IsValid && _User!=null)
                        {
                            if (WebMatrix.WebData.WebSecurity.UserExists(UserEmail))
                            {

                            }
                        }
                        */
            return RedirectToAction("Login", "Account");
            //return View();
        }

        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ConfirmEmail(string token, string email)
        {
            ResetPasswordVM model = new ResetPasswordVM();
            model.ReturnToken = token;
            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            ResetPasswordVM model = new ResetPasswordVM();
            model.ReturnToken = token;
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ResetPassword(ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                //bool resetResponse = WebMatrix.WebData.WebSecurity.ResetPassword(model.ReturnToken, model.Password);

                User _User = new User(); // DA_LD().GetUserFromToken(model.ReturnToken);

                if (_User!=null)
                {
                    //ViewBag.Message = "Your password was successfully changed.";
                    if (model.Password != model.PasswordConfirm)
                    {
                        Flash(new FlashMessage("Password does not match."));
                    }
                    else
                    {
                        Flash(new FlashMessage("Your password was successfully changed."));
                    }
                }
                else
                {
                    //ViewBag.Message = "Password not changed.";
                    Flash(new FlashMessage("Password not changed."));
                }
            }
            return RedirectToAction("Login", "Account");

            //return View(model);
        }

    }
}

