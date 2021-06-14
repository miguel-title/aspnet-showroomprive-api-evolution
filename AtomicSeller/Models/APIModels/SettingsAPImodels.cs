using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AtomicAPI.Helpers;
using AtomicSeller.Models;
using AtomicCommonAPI.Models;

namespace AtomicSettingsAPI.Models
{
    public class GetShippingServicesRequest
    {
        public RequestHeader Header { get; set; }
        public GetShippingServicesData Request { get; set; }

    }

    public class GetShippingServicesData
    {
        //public string CarrierServiceKey { get; set; }
        //public string DefaultProductCode { get; set; }
    }


    public class GetShippingServicesResponse
    {
        public ResponseHeader Header { get; set; }
        public GetShippingServicesResponseData Response { get; set; }
    }


    public class GetShippingServicesResponseData
    {
        public List<WSShippingService> ShippingServices { get; set; }
    }

    public class WSShippingService
    {
        
        //public int Product_ID { get; set; }
        public string CarrierServiceKey { get; set; }
        //public string ShippingServiceKey { get; set; }
        public string CarrierName { get; set; }
        public string CarrierServiceName { get; set; }
    //public Nullable<int> LabelTemplateId { get; set; }
    //public bool IsFavorite { get; set; }
    //public bool IsDefault { get; set; }
    //public string MerchantKey { get; set; }

    }

    
}