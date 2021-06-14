using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using AtomicSeller.Helpers;
using AtomicSeller.ViewModels;
using AtomicSeller.Models;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Data.Entity.Migrations;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Mvc;
using AtomicJs.Models.ASTJL;
using AtomicJs.Models;
using Microsoft.AspNetCore.Http;

namespace AtomicSeller.Controllers
{
    public class JobsController : BaseController
    {

        [HttpGet]
        public ActionResult JobList()
        {
            using (ASTJLContext _context = new ASTJLContext())
            {

                JobVMs _JobVMs = new ViewModels.JobVMs();

                _JobVMs.AtomicJobs = (from AtomicJob  in _context.AtomicJobs select AtomicJob ).ToList();

                return View(_JobVMs);
            }
        }

        
        [HttpGet]
        public ActionResult JobEdit(int JobID)
        {
            using (ASTJLContext _context = new ASTJLContext())
            {

                JobVMs _JobVMs = new ViewModels.JobVMs();

                AtomicJob _Job = _context.AtomicJobs.FirstOrDefault (j=>j.JobId == JobID);

                return View(_Job);
            }
        }

        [HttpGet]
        public ActionResult JobLogEdit(int LogID)
        {
            using (ASTJLContext _context = new ASTJLContext())
            {

                JobLogVMs _JobLogVMs = new ViewModels.JobLogVMs();

                AtomicJobslog _JobLog = _context.AtomicJobslogs.FirstOrDefault(j => j.LogId == LogID);

                return View(_JobLog);
            }
        }

        [HttpPost]
//        public ActionResult Create([Bind(Include = "JobName, DailyStartTime, DailyEndTime, JobPeriod, Repeat, Enabled, Category, TenantID, JobKey, WebserviceURL, WebserviceToken, WebserviceKey,WebserviceStoreKey, WebserviceCarrierServiceKey, WebserviceWMSKey, WebserviceReportingKey, WebServiceOutput")]Jobs _job)
        public ActionResult Create(AtomicJob _job)
        {
            using (ASTJLContext _context = new ASTJLContext())
                try
                {
                if (ModelState.IsValid)
                {
                        //_job.JobPeriod = new TimeSpan(0, 0, 0, 0, 0);
                        _context.AtomicJobs.Add(_job);
                        _context.SaveChanges();

                    //new JobScheduler().StartJob(_job);

                    return RedirectToAction("JobList");
                }
            }
            catch (DataException dex)
            { 
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return RedirectToAction("JobList");
        }

        public async System.Threading.Tasks.Task<ActionResult> Save(int id)
        {

            if (id == null)
            {
                //Microsoft.AspNetCore.Mvc.
                return StatusCode(500);
            }

            using (ASTJLContext _context = new ASTJLContext())
            {
                AtomicJob jobToUpdate = _context.AtomicJobs.Find(id);
                //Jobs UpdatedJob = jobToUpdate;

                if (await TryUpdateModelAsync<AtomicJob>(jobToUpdate))
                {
                    try
                    {
                        _context.SaveChanges();

                        //new JobScheduler().StopJob(jobToUpdate);
                        //new JobScheduler().StartJob(UpdatedJob);
                        return RedirectToAction("JobList");
                    }
                    catch (RetryLimitExceededException) // dex 
                    {
                        //Log the error (uncomment dex variable name and add a line here to write a log.
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    }
                    catch (Exception ex)
                    {

                    }
                }
                return View(jobToUpdate);
            }

            return View();
        }

        public ActionResult Delete(int nJobID)
        {

            using (ASTJLContext _context = new ASTJLContext())
            {
                AtomicJob _Job = _context.AtomicJobs.Find(nJobID);
                _context.AtomicJobs.Remove(_Job);
                _context.SaveChanges();
            }
            return RedirectToAction("JobList");
        }

        // GET: JobsLog
        public ActionResult JobLogList()
        {

            using (ASTJLContext _context = new ASTJLContext())
            {
                JobLogVMs _JobLogVMs = new ViewModels.JobLogVMs();

                //_JobLogVMs.joblogs = (from Jobslog in entities.Jobslog select Jobslog).ToList();
                List<AtomicJob> Jobs = _context.AtomicJobs.ToList();
                List<AtomicJobslog> JobsLogs = _context.AtomicJobslogs.ToList();

                var IJobVMs = from j in Jobs
                                 join l in _context.AtomicJobslogs  on j.JobId equals l.JobId into table1
                                 from jl in table1.ToList()
                                 orderby jl.LogId descending
                                 select new JobVM
                                 {
                                     jobs = j,
                                     jobslog = jl
                                 };

                IJobVMs = IJobVMs.Take(50);

                var items = new List<AtomicJobslog>();
                foreach (JobVM _JobVM in IJobVMs)
                {
                    int nLogId = _JobVM.jobslog.LogId;
                    string strJobName = _JobVM.jobs.JobName;
                    int? nJobId = _JobVM.jobslog.JobId;
                    DateTime? dtStart = _JobVM.jobslog.DateStart;
                    DateTime? dtEnd = _JobVM.jobslog.DateEnd;
                    string strRetcod = _JobVM.jobslog.ReturnCode;
                    string strErrorMsg = _JobVM.jobslog.ErrorMessage;
                    int? nTenantID = _JobVM.jobs.TenantId;

                    AtomicJobslog oneitem = new AtomicJobslog { LogId = nLogId, JobName = strJobName, JobId = nJobId, DateStart = dtStart, DateEnd = dtEnd, ReturnCode = strRetcod, ErrorMessage = strErrorMsg, TenantId = nTenantID };
                    items.Add(oneitem);
                }

                _JobLogVMs.Atomicjoblogs = items;

                return View(_JobLogVMs);
            }
        }


        // GET: JobsRealTime
        public ActionResult Jobsrealtime()
        {
            string baseUrl = string.Empty;
            HttpRequest Request = HttpContext.Request;
            baseUrl = Request.PathBase; 
            return Redirect(baseUrl+"/hangfire");
        }



        public ActionResult RealTimeTableData()
        {

            JobsRealTimeVMs _JobLogVMs = new ViewModels.JobsRealTimeVMs();
            //_JobLogVMs = new JobScheduler().GetScheduledJobs();

            /*
            using (ASTJLEntities entities = new ASTJLEntities())
            {
                List<JobRealTime> items = new List<JobRealTime>();

                List<Jobs> Jobs = entities.Jobs.ToList();

                foreach (var item in Jobs)
                {
                    string strJobName = item.JobName;
                    int? nJobId = item.JobID;
                    TimeSpan? dtStart = item.DailyStartTime;
                    TimeSpan? dtEnd = item.DailyEndTime;
                    string strCategory = item.Category;
                    int? nTenantID = item.TenantID;
                    string Enabled = item.Enabled;
                    string JobKey = item.JobKey;

                    if (Enabled.ToUpper() == "TRUE" && JobKey != null && DateTime.Now.TimeOfDay >= dtStart && DateTime.Now.TimeOfDay <= dtEnd)
                    {
                        JobRealTime oneitem = new JobRealTime { JobID = nJobId, JobName = strJobName, DateStart = dtStart, DateEnd = dtEnd, Category = strCategory, TenantID = nTenantID , JobKey = JobKey };
                        items.Add(oneitem);
                    }

                }
                _JobLogVMs.jobsRealTime = items;
            }
                */
            return PartialView("RealTimeTableData", _JobLogVMs);
        }

        /* Supprimé car on y passe jamais
public ActionResult TableData()
{
    JobLogVMs JobLogVMS = new JobLogVMs();
    List<Jobslog> _JobLogs = new List<Jobslog>();

    ASTJLEntities entities = new ASTJLEntities();

    List<Jobs> Jobs = entities.Jobs.ToList();
    List<Jobslog> JobsLogs = entities.Jobslog.ToList();

    var IJobVMs = from j in Jobs
                     join l in entities.Jobslog on j.JobID equals l.JobID into table1
                     from jl in table1.ToList()
                     orderby jl.LogID descending
                  select new JobVM
                     {
                         jobs = j,
                         jobslog = jl
                     };

    IJobVMs = IJobVMs.Take(20);

    foreach (JobVM _JobVM in IJobVMs)
    {
        int nLogId = _JobVM.jobslog.LogID;
        string strJobName = _JobVM.jobs.JobName;
        int? nJobId = _JobVM.jobslog.JobID;
        DateTime? dtStart = _JobVM.jobslog.DateStart;
        DateTime? dtEnd = _JobVM.jobslog.DateEnd;
        string strRetcod = _JobVM.jobslog.ReturnCode;
        string strErrorMsg = _JobVM.jobslog.ErrorMessage;
        int? nTenantID = _JobVM.jobs.TenantID;

        Jobslog _JobLog = new Jobslog { LogID = nLogId, JobName = strJobName, JobID = nJobId, DateStart = dtStart, DateEnd = dtEnd, ReturnCode = strRetcod, ErrorMessage = strErrorMsg, TenantID = nTenantID };
        _JobLogs.Add(_JobLog);
    }

    JobLogVMS.joblogs = _JobLogs;
    return PartialView("TableData", JobLogVMS);
}
*/

    }
}
