using System;
using System.Threading;
using System.Web;
using AtomicJs.Models.ASTLD;
using AtomicSeller.Helpers;
using AtomicSeller.Helpers.Security.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RedirectToRouteResult = AtomicSeller.Helpers.Security.Routing.RedirectToRouteResult;

namespace AtomicSeller.Controllers
{
    public class BaseController : Controller
    {
        public const string SessionKey = "sessionBag";
        public int? TenantId { get; }
        public long? ImpersonatorUserId { get; }
        public int? ImpersonatorTenantId { get; }

        public int? UserId { get; set; }
        public string ConnectionString { get; set; }
        public string TenantDirectory { get; set; }
        public int TenantID { get; set; }
        public int ClientID { get; set; }
        public string CheminLogo => "/Resources/img/logo.png";

        //public static class CacheKeys
        //{
        //    public static string ErrorList { get; set; }
        //    public static string RestErrors { get; set; }
        //}

        //public static IMemoryCache _cache;
        //public BaseController(IMemoryCache memoryCache)
        //{
        //    _cache = memoryCache;
        //}


        //public static string ErrorList
        //{
        //    get
        //    {
        //        string result;

        //        // Look for cache key.
        //        if (!_cache.TryGetValue(CacheKeys.ErrorList, out result))
        //        {

        //        }

        //        return result;
        //    }
        //    set
        //    {
        //        // Set cache options.
        //        var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(60));

        //        // Save data in cache.
        //        _cache.Set(CacheKeys.ErrorList, value, cacheEntryOptions);
        //    }
        //}

        //public static string RestErrorsList
        //{
        //    get
        //    {
        //        string result;

        //        // Look for cache key.
        //        if (!_cache.TryGetValue(CacheKeys.RestErrors, out result))
        //        {

        //        }

        //        return result;
        //    }
        //    set
        //    {
        //        // Set cache options.
        //        var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(60));

        //        // Save data in cache.
        //        _cache.Set(CacheKeys.RestErrors, value, cacheEntryOptions);
        //    }
        //}

        public string GetSession(string sessionKey)
        {
            return HttpContext.Session.GetString(sessionKey);
        }

        public bool CreateNew(string sessionKey, string sessionValue)
        {
            if (GetSession(sessionKey) == null)
            {
                HttpContext.Session.SetString(sessionKey, sessionValue);
                return false;
            }
            else
                return true;
        }

        public string Exists(string sessionKey)
        {
            if (GetSession(sessionKey) != null)
            {
                return GetSession(sessionKey);
            }
            return null;
        }

        public void Destroy(string sessionKey)
        {
            HttpContext.Session.Clear();
        }

        public bool setSessionBagInitData(User user = null, Tenant tenant = null)
        {
            var sessionBag = GetSession(SessionKey);
            if (user == null || user.UserId == 0)
            {
                try
                {
                    user = new User();

                    tenant = new Tenant();
                }
                catch (Exception)
                {
                    return false;
                }
            }

/*
            if (tenant.ConnectionString == null && tenant.Status == "Pending")
            {
                return false;
            }
*/
            ConnectionString = ""; // tenant.ConnectionString;
            TenantDirectory = ""; // tenant.TenantDirectory;
            TenantID = 1;

            
                Tools.ErrorHandler("Connects to : " + ConnectionString, null, false, true, false);
            
            return true;

        }

        public void Flash(FlashMessage flashMessage)
        {
            FlashMessage.Flash(TempData, flashMessage);
        }

        /// <summary>Effectue une redirection vers l'action spécifiée à l'aide du nom d'action et des valeurs d'itinéraire.</summary>
        /// <returns>Objet résultat de la redirection.</returns>
        /// <param name="actionName">Nom de l'action.</param>
        /// <param name="routeValues">Paramètres d'un itinéraire.</param>
        protected internal new RedirectToRouteResult RedirectToAction(string actionName, object routeValues)
        {
            return this.RedirectToAction(actionName, TypeHelper.ObjectToDictionary(routeValues));
        }

        /// <summary>Effectue une redirection vers l'action spécifiée à l'aide du nom d'action et du dictionnaire d'itinéraires.</summary>
        /// <returns>Objet résultat de la redirection.</returns>
        /// <param name="actionName">Nom de l'action.</param>
        /// <param name="routeValues">Paramètres d'un itinéraire.</param>
        protected internal new RedirectToRouteResult RedirectToAction(string actionName, RouteValueDictionary routeValues)
        {
            return this.RedirectToAction(actionName, (string)null, routeValues);
        }

        /// <summary>Effectue une redirection vers l'action spécifiée à l'aide du nom d'action et du nom de contrôleur.</summary>
        /// <returns>Objet résultat de la redirection.</returns>
        /// <param name="actionName">Nom de l'action.</param>
        /// <param name="controllerName">Nom du contrôleur.</param>
        protected internal new RedirectToRouteResult RedirectToAction(string actionName, string controllerName)
        {
            return this.RedirectToAction(actionName, controllerName, (RouteValueDictionary)null);
        }

        /// <summary>Effectue une redirection vers l'action spécifiée à l'aide du nom d'action, du nom de contrôleur et du dictionnaire d'itinéraires.</summary>
        /// <returns>Objet résultat de la redirection.</returns>
        /// <param name="actionName">Nom de l'action.</param>
        /// <param name="controllerName">Nom du contrôleur.</param>
        /// <param name="routeValues">Paramètres d'un itinéraire.</param>
        protected internal new RedirectToRouteResult RedirectToAction(string actionName, string controllerName, object routeValues)
        {
            return this.RedirectToAction(actionName, controllerName, TypeHelper.ObjectToDictionary(routeValues));
        }

        /// <summary>Effectue une redirection vers l'action spécifiée à l'aide du nom d'action, du nom de contrôleur et des valeurs d'itinéraire.</summary>
        /// <returns>Objet résultat de la redirection.</returns>
        /// <param name="actionName">Nom de l'action.</param>
        /// <param name="controllerName">Nom du contrôleur.</param>
        /// <param name="routeValues">Paramètres d'un itinéraire.</param>
        protected internal new virtual RedirectToRouteResult RedirectToAction(string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            return new RedirectToRouteResult(this.RouteData != null ? RouteValuesHelpers.MergeRouteValues(actionName, controllerName, this.RouteData.Values, routeValues, true) : RouteValuesHelpers.MergeRouteValues(actionName, controllerName, (RouteValueDictionary)null, routeValues, true));
        }

        /// <summary>Retourne une instance de la classe <see cref="T:System.Web.Mvc.RedirectResult" /> avec la valeur true attribuée à la propriété Permanent à l'aide du nom d'action et des valeurs d'itinéraire spécifiés.</summary>
        /// <returns>Instance de la classe <see cref="T:System.Web.Mvc.RedirectResult" /> avec la valeur true attribuée à la propriété Permanent à l'aide du nom d'action et des valeurs d'itinéraire spécifiés.</returns>
        /// <param name="actionName">Nom de l'action.</param>
        /// <param name="routeValues">Valeurs d'itinéraire.</param>
        protected internal new RedirectToRouteResult RedirectToActionPermanent(string actionName, object routeValues)
        {
            return this.RedirectToActionPermanent(actionName, TypeHelper.ObjectToDictionary(routeValues));
        }

        /// <summary>Retourne une instance de la classe <see cref="T:System.Web.Mvc.RedirectResult" /> avec la valeur true attribuée à la propriété Permanent à l'aide du nom d'action et des valeurs d'itinéraire spécifiés.</summary>
        /// <returns>Instance de la classe <see cref="T:System.Web.Mvc.RedirectResult" /> avec la valeur true attribuée à la propriété Permanent à l'aide du nom d'action et des valeurs d'itinéraire spécifiés.</returns>
        /// <param name="actionName">Nom de l'action.</param>
        /// <param name="routeValues">Valeurs d'itinéraire.</param>
        protected internal new RedirectToRouteResult RedirectToActionPermanent(string actionName, RouteValueDictionary routeValues)
        {
            return this.RedirectToActionPermanent(actionName, (string)null, routeValues);
        }

        /// <summary>Effectue une redirection vers l'action spécifiée à l'aide du nom d'action et du nom de contrôleur.</summary>
        /// <returns>Objet résultat de la redirection.</returns>
        /// <param name="actionName">Nom de l'action.</param>
        /// <param name="controllerName">Nom du contrôleur.</param>
        protected internal new RedirectToRouteResult RedirectToActionPermanent(string actionName, string controllerName)
        {
            return this.RedirectToActionPermanent(actionName, controllerName, (RouteValueDictionary)null);
        }

        /// <summary>Retourne une instance de la classe <see cref="T:System.Web.Mvc.RedirectResult" /> avec la valeur true attribuée à la propriété Permanent à l'aide du nom d'action, du nom de contrôleur et des valeurs d'itinéraire spécifiés.</summary>
        /// <returns>Instance de la classe <see cref="T:System.Web.Mvc.RedirectResult" /> avec la valeur true attribuée à la propriété Permanent à l'aide du nom d'action, du nom de contrôleur et des valeurs d'itinéraire spécifiés.</returns>
        /// <param name="actionName">Nom de l'action.</param>
        /// <param name="controllerName">Nom du contrôleur.</param>
        /// <param name="routeValues">Valeurs d'itinéraire.</param>
        protected internal new RedirectToRouteResult RedirectToActionPermanent(string actionName, string controllerName, object routeValues)
        {
            return this.RedirectToActionPermanent(actionName, controllerName, TypeHelper.ObjectToDictionary(routeValues));
        }

        /// <summary>Retourne une instance de la classe <see cref="T:System.Web.Mvc.RedirectResult" /> avec la valeur true attribuée à la propriété Permanent à l'aide du nom d'action, du nom de contrôleur et des valeurs d'itinéraire spécifiés.</summary>
        /// <returns>Instance de la classe <see cref="T:System.Web.Mvc.RedirectResult" /> avec la valeur true attribuée à la propriété Permanent à l'aide du nom d'action, du nom de contrôleur et des valeurs d'itinéraire spécifiés.</returns>
        /// <param name="actionName">Nom de l'action.</param>
        /// <param name="controllerName">Nom du contrôleur.</param>
        /// <param name="routeValues">Valeurs d'itinéraire.</param>
        protected internal new virtual RedirectToRouteResult RedirectToActionPermanent(string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            RouteValueDictionary implicitRouteValues = this.RouteData != null ? this.RouteData.Values : (RouteValueDictionary)null;
            //return new RedirectToRouteResult((string)null, RouteValuesHelpers.MergeRouteValues(actionName, controllerName, implicitRouteValues, routeValues, true), true);
            return new RedirectToRouteResult((string)null, RouteValuesHelpers.MergeRouteValues(actionName, controllerName, implicitRouteValues, routeValues, true), true);
        }

    }
}
