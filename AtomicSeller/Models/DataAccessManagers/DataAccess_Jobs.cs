using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using AtomicSeller.Models;
using AtomicSeller.ViewModels;
using AtomicSeller.Controllers;
using AtomicSeller.Helpers;
using AtomicJs.Models;
using AtomicJs.Models.ASTJL;

namespace AtomicSeller
{

    public class DA_JL
    {
        public List<AtomicJob> GetAllJobs()
        {            
            using (ASTJLContext _context = new ASTJLContext())
            {
                var AtomicJob = _context.AtomicJobs;
                return AtomicJob.ToList();
            }
        }
    }
}