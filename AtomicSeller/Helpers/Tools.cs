using AtomicSeller.Controllers;
using AtomicSeller.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
//using Microsoft.Extensions.Logging;
//using NLog.Web;
using NLog;
using NLog.Targets;
using AtomicSeller.Models;
using System.Net;
using System.Net.Mail;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
//using NLog.Extensions.Logging;


namespace AtomicSeller
{
    public class Tools
    {
        public static string LabelFilesDirectory = "LabelFiles";
        public static string EDIFilesDirectory = "EDIFiles";
        public static string EDISentFilesDirectory = "Sent";
        public static string ExportFilesDirectory = "ExportFiles";
        //public static string AppdataDirectory = "Atomic";
        public static string InvoiceFilesDirectory = "Invoices";

        public static bool TaxManagement = false;


        static string AppData = string.Empty;


        
      
      
        public static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly TempDataDictionary tempData;


        private readonly IHttpContextAccessor _context;


        public string GetBaseURL()
        {
            //string url = string.Empty;
            string baseUrl = string.Empty;

            /*
            string toto = System.Web.HttpContext.Current.Server.MapPath("~");
            //System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(RefPath));
            string titi = System.Web.Hosting.HostingEnvironment.MapPath("~/");
            string tutu = HttpRuntime.AppDomainAppPath;
            */

            try
            {
                HttpRequest Request = _context.HttpContext.Request;
                //string toto = System.Net.Dns.GetHostName();
                //string titi = System.Net.Http.Headers. 
                baseUrl = Request.PathBase;

                //baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
            }
            catch (Exception ex)
            {
                baseUrl = System.Net.Dns.GetHostName();
                //baseUrl = ex.Message + "</br> " + ex.InnerException.Message + "</br> " + ex.StackTrace + "</br> ";
            }

            return baseUrl;
        }

        static readonly string PasswordHash = "P@@Sw0rd";
        static readonly string SaltKey = "S@LT&KEY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";

        public string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return "";

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, System.Text.Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;


            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        public string Decrypt(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText)) return string.Empty;

            byte[] cipherTextBytes;
            try
            {
                cipherTextBytes = Convert.FromBase64String(encryptedText);
            }
            catch
            {
                cipherTextBytes = Convert.FromBase64String("");
            }
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = 0;
            string returnVaue = string.Empty;
            try // In case of the first time converting from existing clear data to encrypted data
            {
                decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            }
            catch
            {
                returnVaue = string.Empty;
            }
            try
            {
                memoryStream.Close();
                cryptoStream.Close();
            }
            catch { }
            //M essageBox.Show(Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray()));
            returnVaue = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
            return returnVaue;
        }


        private static string ProdSetting = string.Empty;
        private static string DevSetting = string.Empty;
        private static string DemoSetting = string.Empty;
        private static string EcommerceSetting = string.Empty;

        public static void ErrorHandler(string Message, Exception ex = null, bool DisplayMessage = false, bool TraceLog = true, bool DisplayTrace = false, BaseController controller = null)
        {


        }


        public List<string> ExtractEmails(string textToScrape)
        {
            Regex reg = new Regex(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}", RegexOptions.IgnoreCase);
            Match match;

            List<string> results = new List<string>();
            for (match = reg.Match(textToScrape); match.Success; match = match.NextMatch())
            {
                if (!(results.Contains(match.Value)))
                    results.Add(match.Value);
            }

            return results;
        }


    }
}
