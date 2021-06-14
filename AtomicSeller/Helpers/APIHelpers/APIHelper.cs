using AtomicSeller;
using AtomicSeller.Helpers;
using AtomicSeller.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using AtomicSeller.Controllers;
using AtomicJs.Models.ASTLD;

namespace AtomicAPI.Helpers
{
    public class APIHelper : BaseController
    {
        public bool ValidateToken(string Token, string ForcedTenant = null)
        {
            bool result = false;
            if (Token.Length > Lengths.Token)
            {
                result =  false;
            }
            else
            {
                //result = ApplicationWrapper.TokenList.Exists(x => x.Equals(Token));
                result = CheckToken(Token, ForcedTenant);
            }

            return result;
        }

        private bool CheckToken(string Token, string ForcedTenant=null)
        {

            User user = null;
            Tenant Tenant = null;

            try
            {
                    //Client = db.Tenant.FirstOrDefault(c => c.Token == Token); 
                    //user = db.User.FirstOrDefault(u => u.TenantID == Client.TenantID);

                    user = new User(); // db.User.FirstOrDefault(u => u.APIToken == Token);

                if (string.IsNullOrEmpty(ForcedTenant))
                    Tenant = new Tenant(); // db.Tenant.FirstOrDefault(c => c.TenantID == user.TenantID);
                    else
                    {
                        int TenantID = 1; // new Tools().ConvertStringToInt(ForcedTenant);
                    Tenant = new Tenant(); // db.Tenant.FirstOrDefault(c => c.TenantID == TenantID);
                    }
                    if (Tenant==null) return false;
            }
            catch (Exception ex)
            {
                Tools.ErrorHandler(ex.Message + " " + ex.InnerException + "\n" + ex.StackTrace, null, false, true, false);
                return false;
            }

            // Authentification fail
            if (user == null)
            {
                Tools.ErrorHandler("Token not found", null, false, true, false);
                return false;
            }
            else
            {
                //System.Web.SessionState.HttpSessionState session = HttpContext.Current.Session;

                //var sessionBag = SessionBag.Instance;

                //sessionBag = new SessionBag().CreateNew(session);

                CreateNew("sessionBag", HttpContext.Session.ToString());

                ConnectionString = Tenant.ConnectionString;
                TenantDirectory = Tenant.TenantDirectory;

                Tools.ErrorHandler("API " + Tenant.CompanyName + " "+  user.UserName + " connects to : " + Tenant.TenantDirectory, null, false, true, false);

                return true;
            }

        }

        public string SendGetHttpRequest(String url, String token, string _APIKey=null, string _APISecret=null, string ContentType=null)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            if (!string.IsNullOrEmpty (ContentType))
                httpWebRequest.ContentType = ContentType;
            else
                httpWebRequest.ContentType = "application/json";

            //httpWebRequest.ContentType = "x-www-form-urlencoded";

            httpWebRequest.Method = "GET";
            httpWebRequest.PreAuthenticate = true;
            httpWebRequest.Accept = "application/json";

            if (!string.IsNullOrEmpty(_APIKey) || !string.IsNullOrEmpty(_APISecret))
                httpWebRequest.Credentials = new NetworkCredential(_APIKey, _APISecret);
            else
            {
                httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
                // Add OAuth headers
                //httpWebRequest.Headers["Authorization"] = token; // Check etsy 
            }

            var result = "";
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        private string ShopifySendGetHttpRequestOLD(String url, String token, string _APIKey = null, string _APISecret = null, string ContentType = null)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            if (string.IsNullOrEmpty(ContentType))
                httpWebRequest.ContentType = "application/json";
            else
                httpWebRequest.ContentType = ContentType;

            httpWebRequest.Method = "GET";
            httpWebRequest.PreAuthenticate = true;
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            httpWebRequest.Accept = "application/json";

            if (!string.IsNullOrEmpty(_APIKey) || !string.IsNullOrEmpty(_APISecret))
                httpWebRequest.Credentials = new NetworkCredential(_APIKey, _APISecret);

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string result = "";
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }

            return result;
        }


        // Send Post Request to specific Url via params & token.
        public string SendPostHttpRequest(String url, String jsonParam, String token, string _APIKey = null, string _APISecret = null, string ContentType = null)
        {

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            if (string.IsNullOrEmpty(ContentType))
                httpWebRequest.ContentType = "application/json";
            else
                httpWebRequest.ContentType = ContentType;

            httpWebRequest.Method = "POST";

            httpWebRequest.PreAuthenticate = true;

            // httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            httpWebRequest.Accept = "application/json";

            if (!string.IsNullOrEmpty(_APIKey) || !string.IsNullOrEmpty(_APISecret))
                httpWebRequest.Credentials = new NetworkCredential(_APIKey, _APISecret);

            httpWebRequest.ContentType = "x-www-form-urlencoded";

            // Add OAuth headers
            httpWebRequest.Headers["Authorization"] = token;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = jsonParam;
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var result = "";
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
        // Send Post Request to specific Url via params & token.
        private string SendPostHttpRequestEtsy(String url, String jsonParam, String token, string _APIKey = null, string _APISecret = null, string ContentType = null)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.PreAuthenticate = true;
            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Credentials = new NetworkCredential(_APIKey, _APISecret);

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = jsonParam;
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var result = "";
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }


    }

    public static class APIHelper3
    {
        //public static byte[] ReadAllBytes(this BinaryReader reader)
        public static byte[] ReadAllBytes(this BinaryReader reader)
        {
            const int bufferSize = 4096;
            using (var ms = new MemoryStream())
            {
                byte[] buffer = new byte[bufferSize];
                int count;
                while ((count = reader.Read(buffer, 0, buffer.Length)) != 0)
                    ms.Write(buffer, 0, count);
                return ms.ToArray();
            }

        }

    }

}