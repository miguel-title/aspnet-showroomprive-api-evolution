using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AtomicAPI.Helpers;
using AtomicSeller.Models;
using AtomicCommonAPI.Models;

namespace ScheduleAPI.Models
{
    public class ScheduleRequest
    {
        public RequestHeader Header { get; set; }
        public ScheduleData Request { get; set; }
    }

    public class ScheduleData
    {
        public string StoreKey { get; set; }
        public string Action { get; set; }
        public string TenantID { get; set; }
        public string Option { get; set; }
        public string LanguageCode { get; set; }
        public string UpdatedFromTime { get; set; }
    }
    
    public class ScheduleResponse
    {
        public ResponseHeader Header { get; set; }
        public ScheduleResponseData Response { get; set; }
    }
    
    public class ScheduleResponseData
    {
    }
    
}