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
using ScheduleAPI.Models;
using AtomicCommonAPI.Models;
using Microsoft.AspNetCore.Mvc;

//             string url = "https://logistics.atomicseller.com/Api/Scheduler/Schedule";


namespace AtomicProductAPI.Controllers
{
    public class SchedulerController : BaseController
    {
      
        [HttpPost]
        public ScheduleResponse Schedule([FromBody] ScheduleRequest Request)
        {
            ScheduleResponse _ScheduleResponse = new ScheduleResponse();

            try
            {
                if (!new AtomicAPI.Helpers.APIHelper().ValidateToken(Request.Header.Token, Request.Request.TenantID))
                {
                    _ScheduleResponse.Header = new ResponseHeader
                    {
                        LanguageCode = "En",
                        RequestStatus = "Error",
                        StatusCode = "401",
                        ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("401"),
                        ReturnCode = "AS00XX",
                        ReturnMessage = "Invalid token"
                    };
                    return _ScheduleResponse;
                }

                string JSONRequest = JsonConvert.SerializeObject(Request);


                try
                {
                    //_GetProductsResponse = BuildProductsList(Request);
                    string Action = "";

                    try { Action = Request.Request.Action.ToUpper(); }
                    catch (Exception ex)
                    {
                        _ScheduleResponse.Header = new ResponseHeader
                        {
                            LanguageCode = "En",
                            RequestStatus = "Error",
                            StatusCode = "400",
                            ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("400"),
                            ReturnCode = "AS00XX",
                            ReturnMessage = "Invalid Action. Please check request syntax " + ex.Message + " " + ex.StackTrace
                        };
                        //Tools.ErrorHandler("Request: " + Request.ToString(), null, false, true, false);
                        Tools.ErrorHandler("Please check request syntax", ex, false, true, true);

                        return _ScheduleResponse;
                    }

                    switch (Action)
                    {
                        case "GETORDERS":
                            ScheduleGetOrders(Request);
                            break;
                        case "GETPRODUCTS":
                            ScheduleGetProducts(Request);
                            break;
                        case "PUTDELIVERYINFO":
                            SchedulePutDeliveryInfo(Request);
                            break;
                        case "PUTPRODUCTSINFO":
                        case "PUTPRODUCTINFO":
                            SchedulePutProductsInfo(Request);
                            break;
                        case "REPORTING":
                            ScheduleFReporting(Request);
                            break;
                        case "AWAKEJS":
                            ScheduleAwake(Request);
                            break;
                    }

                    if (_ScheduleResponse.Header==null)
                            _ScheduleResponse.Header = new ResponseHeader
                            {
                                LanguageCode = "En",
                                RequestStatus = "Ok",
                                StatusCode = "200",
                                ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("200"),
                                ReturnCode = "AS0000",
                                ReturnMessage = ""
                            };

                        string JSON = JsonConvert.SerializeObject(Request);
                        Tools.ErrorHandler("Request " + JSON, null, false, true, false);

                        return _ScheduleResponse;
                }
                catch (Exception ex)
                {
                    string JSON = JsonConvert.SerializeObject(Request);
                    Tools.ErrorHandler(AtomicAPI.Helpers.ErrorCodes.Internal, ex, false, true, true);
                    Tools.ErrorHandler(JSON, null, false, true, false);

                    return new ScheduleResponse()
                    {
                        Header = new ResponseHeader 
                        {
                            LanguageCode = Request.Request.LanguageCode,
                            RequestStatus = "Error",
                            StatusCode = "500",
                            ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("500"),
                            ReturnCode = AtomicAPI.Helpers.ErrorCodes.Internal,
                            //ReturnCode = ModelState.Values.FirstOrDefault().Errors[0].ErrorMessage,
                            ReturnMessage = ex.Message + " " + ex.StackTrace
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                _ScheduleResponse.Header = new ResponseHeader
                {
                    LanguageCode = "En",
                    RequestStatus = "Error",
                    StatusCode = "400",
                    ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("400"),
                    ReturnCode = "AS00XX",
                    ReturnMessage = "Please check request syntax " + ex.Message + " " + ex.StackTrace
                };
                //Tools.ErrorHandler("Request: " + Request.ToString(), null, false, true, false);
                Tools.ErrorHandler("Please check request syntax", ex, false, true, true);
            }

            return _ScheduleResponse;
        }

        public string ScheduleGetOrders(ScheduleRequest _ScheduleRequest)
        {
            string StoreKey = _ScheduleRequest.Request.StoreKey;
            string Action = _ScheduleRequest.Request.Action;
            string TenantID = _ScheduleRequest.Request.TenantID;
            string Option = _ScheduleRequest.Request.Option;
            string LanguageCode = _ScheduleRequest.Request.LanguageCode;
            string UpdatedFromTime = _ScheduleRequest.Request.UpdatedFromTime;

            return "";
        }

        public string ScheduleGetProducts(ScheduleRequest _ScheduleRequest)
        {
            string StoreKey = _ScheduleRequest.Request.StoreKey;
            string Action = _ScheduleRequest.Request.Action;
            string TenantID = _ScheduleRequest.Request.TenantID;
            string Option = _ScheduleRequest.Request.Option;
            string LanguageCode = _ScheduleRequest.Request.LanguageCode;
            string UpdatedFromTime = _ScheduleRequest.Request.UpdatedFromTime;

            return "";
        }

        public string SchedulePutDeliveryInfo(ScheduleRequest _ScheduleRequest)
        {
            string StoreKey = _ScheduleRequest.Request.StoreKey;
            string Action = _ScheduleRequest.Request.Action;
            string TenantID = _ScheduleRequest.Request.TenantID;
            string Option = _ScheduleRequest.Request.Option;
            string LanguageCode = _ScheduleRequest.Request.LanguageCode;
            string UpdatedFromTime = _ScheduleRequest.Request.UpdatedFromTime;

            return "";
        }

        public string SchedulePutProductsInfo(ScheduleRequest _ScheduleRequest)
        {
            string StoreKey = _ScheduleRequest.Request.StoreKey;
            string Action = _ScheduleRequest.Request.Action;
            string TenantID = _ScheduleRequest.Request.TenantID;
            string Option = _ScheduleRequest.Request.Option;
            string LanguageCode = _ScheduleRequest.Request.LanguageCode;
            string UpdatedFromTime = _ScheduleRequest.Request.UpdatedFromTime;

            return "";
        }

        public string ScheduleFReporting(ScheduleRequest _ScheduleRequest)
        {

            string StoreKey = _ScheduleRequest.Request.StoreKey;
            string Action = _ScheduleRequest.Request.Action;
            string TenantID = _ScheduleRequest.Request.TenantID;
            string Option = _ScheduleRequest.Request.Option;
            string LanguageCode = _ScheduleRequest.Request.LanguageCode;
            string UpdatedFromTime = _ScheduleRequest.Request.UpdatedFromTime;



            return "";
        }

        public string ScheduleAwake(ScheduleRequest _ScheduleRequest)
        {

            string StoreKey = _ScheduleRequest.Request.StoreKey;
            string Action = _ScheduleRequest.Request.Action;
            string TenantID = _ScheduleRequest.Request.TenantID;
            string Option = _ScheduleRequest.Request.Option;
            string LanguageCode = _ScheduleRequest.Request.LanguageCode;
            string UpdatedFromTime = _ScheduleRequest.Request.UpdatedFromTime;



            return "";
        }


    }
}
