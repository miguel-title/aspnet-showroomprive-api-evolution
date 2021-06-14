using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AtomicAPI.Helpers;
using AtomicSeller.Models;
using AtomicCommonAPI.Models;

namespace AtomicRateAPI.Models
{
    public class GetRatesRequest
    {
        public RequestHeader Header { get; set; }
        public GetRatesAPIRequestData RatesRequest { get; set; }

    }
    
    public class GetRatesAPIRequestData
    {
        public string CarrierServiceKey { get; set; }
        public string DepositDate { get; set; }
        public string LanguageCode { get; set; }
        public string Mode { get; set; }
        public APIAddress FromAddress { get; set; }
        public APIAddress ToAddress { get; set; }
        public AtomicParcelAPI.Models.APIParcel Parcel { get; set; }

    }


    public class GetRatesAPIResponse
    {
        public ResponseHeader Header { get; set; }
        public GetRatesAPIResponseData Response { get; set; }
    }
    
    public class GetRatesAPIResponseData
    {
        public List<RateAPIWM> Rates { get; set; }
    }
    
    public class RateAPIWM
    {
        public string CarrierServiceKey { get; set; }
        public string ShippingServiceName { get; set; }
        public string RateValue { get; set; }
        public string InsuranceCost { get; set; }
        public string InsuranceParcelValue { get; set; }
        public string RateCurrency { get; set; }
        public string ProvisionalDeliveryDays { get; set; }
        public string ProvisionalDeliveryDate { get; set; }
        public string DeliveryDateGuaranteed { get; set; }
        public string CarrierProductCode { get; set; }
        public string CreateDate { get; set; }
        public string Detail { get; set; }
    }

}