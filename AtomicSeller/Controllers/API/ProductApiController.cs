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
using AtomicProductAPI.Models;

using AtomicCommonAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AtomicProductAPI.Controllers
{
    public class ProductController : BaseController
    {
      
        [HttpPost]
        public ScheduleResponse GetProducts([FromBody] GetProductsRequest Request)
        {
            ScheduleResponse _GetProductsResponse = new ScheduleResponse();

            try
            {
                if (!new AtomicAPI.Helpers.APIHelper().ValidateToken(Request.Header.Token))
                {
                    _GetProductsResponse.Header = new ResponseHeader
                    {
                        LanguageCode = "En",
                        RequestStatus = "Error",
                        StatusCode = "401",
                        ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("401"),
                        ReturnCode = "AS00XX",
                        ReturnMessage = "Invalid token"
                    };
                    return _GetProductsResponse;
                }

                string UserLogin = "";
                string JSONRequest = JsonConvert.SerializeObject(Request);

                try
                {
                    //_GetProductsResponse.Response = new Models.Response();

                        if (_GetProductsResponse.Header==null)
                            _GetProductsResponse.Header = new ResponseHeader
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

                        return _GetProductsResponse;
                }
                catch (Exception ex)
                {
                    string JSON = JsonConvert.SerializeObject(Request);
                    Tools.ErrorHandler(AtomicAPI.Helpers.ErrorCodes.Internal, ex, false, true, true);
                    Tools.ErrorHandler(JSON, null, false, true, false);

                    return new Models.ScheduleResponse()
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
                _GetProductsResponse.Header = new ResponseHeader
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

            return _GetProductsResponse;
        }


        [HttpPost]
        public PutProductsResponse PutProducts([FromBody] PutProductsRequest Request)
        {

            PutProductsResponse _PutProductsResponse = new PutProductsResponse();

            try
            {
                if (!new AtomicAPI.Helpers.APIHelper().ValidateToken(Request.Header.Token))
                {
                    _PutProductsResponse.Header = new ResponseHeader
                    {
                        LanguageCode = "En",
                        RequestStatus = "Error",
                        StatusCode = "401",
                        ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("401"),
                        ReturnCode = "AS00XX",
                        ReturnMessage = "Invalid token"
                    };
                    return _PutProductsResponse;
                }

                try
                {
                    if (_PutProductsResponse.Header == null)
                        _PutProductsResponse.Header = new ResponseHeader
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

                    return _PutProductsResponse;
                }
                catch (Exception ex)
                {
                    string JSON = JsonConvert.SerializeObject(Request);
                    Tools.ErrorHandler(AtomicAPI.Helpers.ErrorCodes.Internal, ex, false, true, true);
                    Tools.ErrorHandler(JSON, null, false, true, false);

                    return new Models.PutProductsResponse()
                    {
                        Header = new ResponseHeader
                        {
                            LanguageCode = Request.Request.LanguageCode,
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
                _PutProductsResponse.Header = new ResponseHeader
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

            return _PutProductsResponse;
            return null;
        }


        [HttpPost]
        public ScheduleResponse GetProductsInfo([FromBody] GetProductsInfoRequest Request)
        {
            ScheduleResponse _GetProductsInfoResponse = new ScheduleResponse();

            try
            {
                if (!new AtomicAPI.Helpers.APIHelper().ValidateToken(Request.Header.Token))
                {
                    _GetProductsInfoResponse.Header = new ResponseHeader
                    {
                        LanguageCode = "En",
                        RequestStatus = "Error",
                        StatusCode = "401",
                        ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("401"),
                        ReturnCode = "AS00XX",
                        ReturnMessage = "Invalid token"
                    };
                    return _GetProductsInfoResponse;
                }


                try
                {
                    //_GetProductsResponse.Response = new Models.Response();

                    if (_GetProductsInfoResponse.Header == null)
                        _GetProductsInfoResponse.Header = new ResponseHeader
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

                    return _GetProductsInfoResponse;
                }
                catch (Exception ex)
                {
                    string JSON = JsonConvert.SerializeObject(Request);
                    Tools.ErrorHandler(AtomicAPI.Helpers.ErrorCodes.Internal, ex, false, true, true);
                    Tools.ErrorHandler(JSON, null, false, true, false);

                    return new Models.ScheduleResponse()
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
                _GetProductsInfoResponse.Header = new ResponseHeader
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

            return _GetProductsInfoResponse;

            return null;
        }

        PutProductsResponse PutAllProducts(PutProductsRequest Request)
        {
            string Option = Request.Request.Option;
            PutProductsResponse _PutProductsResponse = new PutProductsResponse();

            if (string.IsNullOrEmpty(Request.Request.StoreKey))
            {
                _PutProductsResponse.Header = new ResponseHeader
                {
                    LanguageCode = "En",
                    RequestStatus = "Error",
                    StatusCode = "400",
                    ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("400"),
                    ReturnCode = "AS00xx",
                    ReturnMessage = "Storekey missing"
                };
                return _PutProductsResponse;
            }



            return _PutProductsResponse;
        }


        [HttpPost]
        public PutProductsInfoResponse PutProductsInfo([FromBody] PutProductsInfoRequest Request)
        {

            PutProductsInfoResponse _PutProductInfoResponse = new PutProductsInfoResponse();

            // La suite c'est Proxipause

            // Envoie le niveau des stocks (Tred vers Proxi)
            try
            {
                if (!new AtomicAPI.Helpers.APIHelper().ValidateToken(Request.Header.Token))
                {
                    _PutProductInfoResponse.Header = new ResponseHeader
                    {
                        LanguageCode = "En",
                        RequestStatus = "Error",
                        StatusCode = "401",
                        ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("401"),
                        ReturnCode = "AS00XX",
                        ReturnMessage = "Invalid token"
                    };
                    return _PutProductInfoResponse;
                }


            }
            catch (Exception ex)
            {
                _PutProductInfoResponse.Header = new ResponseHeader
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

            return _PutProductInfoResponse;
        }

    }
}
