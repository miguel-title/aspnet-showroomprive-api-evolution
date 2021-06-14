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
using AtomicSettingsAPI.Models;
using AtomicCommonAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AtomicProductAPI.Controllers
{
    public class SettingsController : BaseController
    {
      
        [HttpPost]
        public GetShippingServicesResponse GetShippingServices([FromBody] GetShippingServicesRequest Request)
        {
            GetShippingServicesResponse _GetCarriersResponse = new GetShippingServicesResponse();

            try
            {
                if (!new AtomicAPI.Helpers.APIHelper().ValidateToken(Request.Header.Token))
                {
                    _GetCarriersResponse.Header = new ResponseHeader
                    {
                        LanguageCode = "En",
                        RequestStatus = "Error",
                        StatusCode = "401",
                        ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("401"),
                        ReturnCode = "AS00XX",
                        ReturnMessage = "Invalid token"
                    };
                    return _GetCarriersResponse;
                }


                try
                {
                        if (_GetCarriersResponse.Header==null)
                            _GetCarriersResponse.Header = new ResponseHeader
                            {
                                LanguageCode = "En",
                                RequestStatus = "Ok",
                                StatusCode = "200",
                                ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("200"),
                                ReturnCode = "AS0000",
                                ReturnMessage = ""
                            };

                    //string JSON = JsonConvert.SerializeObject(Request);
                    _GetCarriersResponse.Response = new GetShippingServicesResponseData();
                    _GetCarriersResponse.Response.ShippingServices = new List<WSShippingService>();

                    return _GetCarriersResponse;
                }
                catch (Exception ex)
                {
                    string JSON = JsonConvert.SerializeObject(Request);
                    Tools.ErrorHandler(AtomicAPI.Helpers.ErrorCodes.Internal, ex, false, true, true);
                    Tools.ErrorHandler(JSON, null, false, true, false);

                    return new GetShippingServicesResponse()
                    {
                        Header = new ResponseHeader 
                        {
                            LanguageCode = "En",
                            StatusCode = "500",
                            ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("500"),
                            RequestStatus = "Error",
                            ReturnCode = AtomicAPI.Helpers.ErrorCodes.Internal,
                            //ReturnCode = ModelState.Values.FirstOrDefault().Errors[0].ErrorMessage,
                            ReturnMessage = ex.Message + " " + ex.StackTrace
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                _GetCarriersResponse.Header = new ResponseHeader
                {
                    LanguageCode = "En",
                    RequestStatus = "Error",
                    ReturnCode = "AS00XX",
                    StatusCode = "400",
                    ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("400"),
                    ReturnMessage = "Please check request syntax " + ex.Message + " " + ex.StackTrace
                };
                //Tools.ErrorHandler("Request: " + Request.ToString(), null, false, true, false);
                Tools.ErrorHandler("Please check request syntax", ex, false, true, true);
            }

            return _GetCarriersResponse;
        }

    }
}
