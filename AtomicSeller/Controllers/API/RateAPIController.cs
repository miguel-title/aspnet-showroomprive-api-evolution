using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using AtomicSeller;
using AtomicSeller.Models;
using AtomicSeller.ViewModels;
using AtomicSeller.Controllers;
using AtomicSeller.Helpers;
using System.Security.Claims;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using AtomicDeliveryAPI.Models;
using AtomicAPI.Helpers;
using AtomicCommonAPI.Models;
using AtomicRateAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AtomicSeller.Controllers.API
{
    public class RateController : BaseController
    {

        [HttpPost]
        public GetRatesAPIResponse GetRates([FromBody] GetRatesRequest Request)
        {
            GetRatesAPIResponse _GetRatesResponse = new GetRatesAPIResponse();

            try
            {
                if (!new AtomicAPI.Helpers.APIHelper().ValidateToken(Request.Header.Token))
                {
                    _GetRatesResponse.Header = new ResponseHeader
                    {
                        LanguageCode = "En",
                        RequestStatus = "Error",
                        StatusCode = "401",
                        ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("401"),
                        ReturnCode = "AS00XX",
                        ReturnMessage = "Invalid token"
                    };
                    return _GetRatesResponse;
                }


                try
                {


                    _GetRatesResponse.Response = new GetRatesAPIResponseData();
                    _GetRatesResponse.Response.Rates = new List<RateAPIWM>();

                    return _GetRatesResponse;
                }
                catch (Exception ex)
                {
                    string JSON = JsonConvert.SerializeObject(Request);
                    Tools.ErrorHandler(AtomicAPI.Helpers.ErrorCodes.Internal, ex, false, true, true);
                    Tools.ErrorHandler(JSON, null, false, true, false);

                    return new GetRatesAPIResponse()
                    {
                        Header = new ResponseHeader
                        {
                            LanguageCode = Request.RatesRequest.LanguageCode,
                            RequestStatus = "Error",
                            StatusCode = "500",
                            ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("500"),
                            ReturnCode = AtomicAPI.Helpers.ErrorCodes.Internal,
                            ReturnMessage = ex.Message + " " + ex.StackTrace
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                _GetRatesResponse.Header = new ResponseHeader
                {
                    LanguageCode = "En",
                    RequestStatus = "Error",
                    StatusCode = "400",
                    ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("400"),
                    ReturnCode = "AS00XX",
                    ReturnMessage = "Please check request syntax " + ex.Message + " " + ex.StackTrace
                };
                Tools.ErrorHandler("Please check request syntax", ex);
            }

            return _GetRatesResponse;
        }

    }
}