using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AtomicSeller.Models.Data;
using AtomicSeller.Models;
using System.Security.Authentication;
using System.Net;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using AtomicJs.Models.ASTJL;

// https://codeburst.io/schedule-background-jobs-using-hangfire-in-net-core-2d98eb64b196

namespace AtomicSeller
{

    public interface IRecurringJob
    {
        void RecurringJob();
    }

    public class HangFireJob : IRecurringJob
    {
        public void RecurringJob()
        {
            //Console.WriteLine($"Hanfire recurring job!");

            //var JobList = new DA_JL().GetAllJobs();

            try
            {
                using (ASTJLContext _context = new ASTJLContext())
                {

                    TimeSpan? TOD = DateTime.Now.TimeOfDay;

                    //JobPeriod

                    var DBJobs = _context.AtomicJobs.Where(j =>
                        j.DailyStartTime < TOD &&
                        j.DailyEndTime > TOD &&
                        j.Enabled.ToUpper().Trim() == "TRUE");

                    //DBJobs = DBJobs.Where(j => (j.LastExecutionTime==null || (j.JobPeriod!=null && j.LastExecutionTime.Value.Add ((TimeSpan)j.JobPeriod) > DateTime.Now)));

                    List<AtomicJob> _Jobs = DBJobs.ToList();

                    foreach (AtomicJob _Job in _Jobs)
                    {
                        DateTime toto = DateTime.Now;

                        if (_Job.LastExecutionTime != null)
                            toto = _Job.LastExecutionTime.Value.Add((TimeSpan)_Job.JobPeriod);

                        if (_Job.LastExecutionTime != null &&
                            _Job.LastExecutionTime.Value.Add((TimeSpan)_Job.JobPeriod) > DateTime.Now)
                            continue;

                        // repeat = false && Si le timespan de la date de derniere execution > dailystardtime 
                        if (_Job.LastExecutionTime != null &&
                            _Job.Repeat.ToUpper().Trim() != "YES" &&
                            _Job.Repeat.ToUpper().Trim() != "TRUE" &&
                            _Job.LastExecutionTime.Value.TimeOfDay > _Job.DailyStartTime &&
                            _Job.LastExecutionTime.Value.Date != DateTime.Today)
                            continue;

                        _Job.LastExecutionTime = DateTime.Now;
                        _context.SaveChanges();

                        switch (_Job.Category.ToUpper())
                        {
                            case "GETORDERS":
                            case "PUTDELIVERYINFO":
                            case "GETPRODUCTS":
                            case "PUTPRODUCTSINFO":
                            case "REPORTING":
                            case "SYNCHRONIZESTOCK":
                                new JobTasks().LogisticsSchedule(_Job);
                                break;
                            case "EMAILREPORTING":
                                new JobTasks().EmailReporting(_Job);
                                break;
                            default:
                                Email.SendMail("Unknown Job - " + _Job.Category + " " + DateTime.Today.ToString(), "", "atomicseller702@gmail.com");
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Tools.ErrorHandler("MainJob Severe Error ", ex);
            }
        }


        public class JobTasks
        {
            public async Task LogisticsSchedule(AtomicJob _Job)
            {

                string returnCode = "";
                string errorMSg = "";

                string url = "https://logistics.atomicseller.com/Api/Scheduler/Schedule";
                string Json = string.Empty;
                string WebserviceToken = "TEST";
                string TenantID = "";
                string Action = "";
                try
                {
                    string StoreKey = "";
                    StoreKey = _Job.WebserviceStoreKey;
                    TenantID = _Job.TenantId.ToString();

                    switch (_Job.Category.ToUpper())
                    {
                        case "GETORDERS":
                            Action = "GetOrders";
                            break;
                        case "PUTDELIVERYINFO":
                            Action = "PutDeliveryInfo";
                            Email.SendMail(_Job.JobName + " " + DateTime.Now.ToString() + " - AtomicSeller Job",
                                url + "</br>" + Json + "</br>\n</br>" + errorMSg,"support@atomicseller.com");
                            break;
                        case "GETPRODUCTS":
                            Action = "GetProducts";
                            break;
                        case "PUTPRODUCTSINFO":
                            Action = "PutProductsInfo";
                            break;
                        case "REPORTING":
                            Action = "Reporting";
                            break;
                        case "AWAKE":
                            Action = "Awake";
                            break;
                    }

                    if (string.IsNullOrEmpty(Action) == false)
                        Json = @"{ ""Header"": {
                    ""Token"": """ + WebserviceToken + @"""}, ""Request"": {""StoreKey"": """ +
                            StoreKey + @""", ""Action"": """ + Action + @""", ""TenantID"": """ + TenantID + @""" }}";
                    else Json = "";

                }
                catch (Exception ex)
                {
                    returnCode = "false";
                    errorMSg = ex.Message;
                }

                using (ASTJLContext _context = new ASTJLContext())
                {
                    AtomicJobslog _jobslog = new AtomicJobslog();

                    _jobslog.DateStart = _Job.LastExecutionTime;
                    _jobslog.JobId = _Job.JobId;
                    _jobslog.ReturnCode = returnCode;
                    _jobslog.ErrorMessage = errorMSg;
                    _jobslog.JobName = _Job.JobName;
                    _jobslog.DateEnd = DateTime.Now;

                    _context.AtomicJobslogs.Add(_jobslog);
                    _context.SaveChanges();
                }

/*
                Email.SendMail(
                        _Job.JobName + " " + DateTime.Now.ToString() + " - AtomicSeller Job", 
                        url + "</br>" + Json + "</br>\n</br>" + errorMSg, 
                        "support@atomicseller.com");
*/

                string Return = new JobTasks().SendPostHttpRequest(url, Json, "", "", "", "");

                returnCode = "Ok";
                errorMSg = "Schedule Action=" + Action + " job :" + _Job.JobName + " " + Return;

            }

            public async Task jsSchedule(AtomicJob _Job)
            {

                string returnCode = "";
                string errorMSg = "";

                string url = "https://js.atomicseller.com/Api/Scheduler/Schedule";
                string Json = string.Empty;
                string WebserviceToken = "TEST";
                string TenantID = "";
                string Action = "";
                try
                {
                    string StoreKey = "";
                    StoreKey = _Job.WebserviceStoreKey;
                    TenantID = _Job.TenantId.ToString();

                    Action = "AwakeJS";

                    if (string.IsNullOrEmpty(Action) == false)
                        Json = @"{ ""Header"": {
                    ""Token"": """ + WebserviceToken + @"""}, ""Request"": {""StoreKey"": """ +
                            StoreKey + @""", ""Action"": """ + Action + @""", ""TenantID"": """ + TenantID + @""" }}";
                    else Json = "";

                }
                catch (Exception ex)
                {
                    returnCode = "false";
                    errorMSg = ex.Message;
                }

                using (ASTJLContext _context = new ASTJLContext())
                {
                    AtomicJobslog _jobslog = new AtomicJobslog();

                    _jobslog.DateStart = _Job.LastExecutionTime;
                    _jobslog.JobId = _Job.JobId;
                    _jobslog.ReturnCode = returnCode;
                    _jobslog.ErrorMessage = errorMSg;
                    _jobslog.JobName = _Job.JobName;
                    _jobslog.DateEnd = DateTime.Now;

                    _context.AtomicJobslogs.Add(_jobslog);
                    _context.SaveChanges();
                }

                /*
                                Email.SendMail(
                                        _Job.JobName + " " + DateTime.Now.ToString() + " - AtomicSeller Job", 
                                        url + "</br>" + Json + "</br>\n</br>" + errorMSg, 
                                        "support@atomicseller.com");
                */

                string Return = new JobTasks().SendPostHttpRequest(url, Json, "", "", "", "");

                returnCode = "Ok";
                errorMSg = "Schedule Action=" + Action + " job :" + _Job.JobName + " " + Return;

            }


            public async Task EmailReporting(AtomicJob _Job)
            {
                string returnCode = "";
                string errorMSg = "";

                try
                {
                    returnCode = "Ok";
                    errorMSg = "GetProducts job  success" + _Job.JobName;
                }
                catch (Exception ex)
                {
                    returnCode = "false";
                    errorMSg = ex.Message;
                }

                Email.SendMail("AtomicSeller Job - " + _Job.Category + " " + DateTime.Now.ToString(), "", "support@atomicseller.fr");

                using (ASTJLContext _context = new ASTJLContext())
                {
                    AtomicJobslog _jobslog = new AtomicJobslog();
                    _jobslog.JobId = _Job.JobId;
                    _jobslog.DateStart = _Job.LastExecutionTime;

                    _jobslog.ReturnCode = returnCode;
                    _jobslog.ErrorMessage = errorMSg;
                    _jobslog.JobName = _Job.JobName;

                    //TimeSpan period = _Job.JobPeriod ?? TimeSpan.Parse("00:00:00");
                    //_jobslog.DateEnd = JobStart.DateTime.Add(period);
                    _jobslog.DateEnd = DateTime.Now;

                    _context.AtomicJobslogs.Add(_jobslog);
                    _context.SaveChanges();
                }

            }

            public string SendGetHttpRequest(String url, String token, string _APIKey = null, string _APISecret = null, string ContentType = null)
            {
                //const SslProtocols _Tls12 = (SslProtocols)0x00000C00; ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                if (string.IsNullOrEmpty(ContentType))
                    httpWebRequest.ContentType = "application/json";
                else
                    httpWebRequest.ContentType = ContentType;
                //httpWebRequest.ContentType = "x-www-form-urlencoded";

                httpWebRequest.Method = "GET";
                httpWebRequest.PreAuthenticate = true;
                httpWebRequest.Accept = "application/json";

                if (!string.IsNullOrEmpty(token))
                {
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
                    // Add OAuth headers
                    httpWebRequest.Headers["Authorization"] = token;
                }
                if (!string.IsNullOrEmpty(_APIKey) || !string.IsNullOrEmpty(_APISecret))
                    httpWebRequest.Credentials = new NetworkCredential(_APIKey, _APISecret);

                string result = "";
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

            public string SendPostHttpRequest(String url, String jsonParam, String token, string _APIKey = null, string _APISecret = null, string ContentType = null)
            {
                //const SslProtocols _Tls12 = (SslProtocols)0x00000C00; ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                if (string.IsNullOrEmpty(ContentType))
                    httpWebRequest.ContentType = "application/json";
                else
                    httpWebRequest.ContentType = ContentType;
                //httpWebRequest.ContentType = "x-www-form-urlencoded";

                httpWebRequest.Method = "POST";
                httpWebRequest.PreAuthenticate = true;
                httpWebRequest.Accept = "application/json";

                // Add OAuth headers
                if (string.IsNullOrEmpty(token) == false)
                {
                    httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
                    // Add OAuth headers
                    httpWebRequest.Headers["Authorization"] = token;
                }

                if (string.IsNullOrEmpty(_APIKey) == false)
                    httpWebRequest.Credentials = new NetworkCredential(_APIKey, _APISecret);

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = jsonParam;
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var result = "";
                try
                {
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

        }
    }
}
