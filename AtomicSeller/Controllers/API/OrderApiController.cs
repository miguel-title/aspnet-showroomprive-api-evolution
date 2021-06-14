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
//using AtomicParcelAPI.Models;
using AtomicSeller.Helpers;
using System.Security.Claims;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using AtomicOrderAPI.Models;

using AtomicCommonAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AtomicOrderAPI.Controllers
{
    public class OrderController : BaseController
    {     
        [HttpPost]
        public GetOrdersResponse GetOrders([FromBody] GetOrdersRequest Request)
        {

            string _LanguageCode = "";

            try { _LanguageCode = Request.Request.LanguageCode; }
            catch
            {
                _LanguageCode = "En";
            }

            GetOrdersResponse _GetOrdersResponse = new GetOrdersResponse();


            try
            {
                if (!new AtomicAPI.Helpers.APIHelper().ValidateToken(Request.Header.Token))
                {
                    _GetOrdersResponse.Header = new ResponseHeader
                    {
                        LanguageCode = _LanguageCode,
                        RequestStatus = "Error",
                        StatusCode = "401",
                        ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("401"),
                        ReturnCode = "AS00XX",
                        ReturnMessage = new Local().TranslatedMessage("INVALIDTOKEN", _LanguageCode)
                    };
                    return _GetOrdersResponse;
                }
            }catch { }
            return _GetOrdersResponse;
        }

        
        [HttpPost]
        public PutOrdersResponse PutOrders([FromBody] PutOrdersRequest Request)
        {//Proxi vers tred

            string _LanguageCode = "";

            try { _LanguageCode = Request.Request.LanguageCode; }
            catch
            {
                _LanguageCode = "En";
            }

            // PHP
            PutOrdersResponse _PutOrdersResponse = new PutOrdersResponse();

            try
            {
                if (!new AtomicAPI.Helpers.APIHelper().ValidateToken(Request.Header.Token))
                {
                    _PutOrdersResponse.Header = new ResponseHeader
                    {
                        LanguageCode = _LanguageCode,
                        RequestStatus = "Error",
                        StatusCode = "401",
                        ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("401"),
                        ReturnCode = "AS00XX",
                        ReturnMessage = "Invalid token"
                    };
                    return _PutOrdersResponse;
                }

                try
                {
                    _PutOrdersResponse.Response = new Models.OrdersResponse();
                    //_PutOrdersResponse.Response.Orders = BuildOrdersList(Request);

                    foreach (AtomicOrderAPI.Models.Order _Order in _PutOrdersResponse.Response.Orders)
                    {
                        if (_Order.Status == "Error")
                        {
                            _PutOrdersResponse.Header = new ResponseHeader
                            {
                                LanguageCode = _LanguageCode,
                                RequestStatus = "Error",
                                StatusCode = "400",
                                ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("400"),
                                ReturnCode = "ASxxxx",
                                ReturnMessage = _Order.OrderKey
                            };

                            _PutOrdersResponse.Response.Orders = null;
                        }
                    }
                    if (_PutOrdersResponse.Header == null)
                        _PutOrdersResponse.Header = new ResponseHeader
                        {
                            LanguageCode = _LanguageCode,
                            RequestStatus = "Ok",
                            StatusCode = "200",
                            ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("200"),
                            ReturnCode = "AS0000",
                            ReturnMessage = _PutOrdersResponse.Response.Orders.Count.ToString() + " orders found"
                        };

                    string JSON = JsonConvert.SerializeObject(Request);
                    Tools.ErrorHandler(" PutOrders Request OK" + JSON, null, false, true, false);

                    return _PutOrdersResponse;
                }
                catch (Exception ex)
                {
                    string JSON = JsonConvert.SerializeObject(Request);
                    Tools.ErrorHandler(AtomicAPI.Helpers.ErrorCodes.Internal, ex, false, true, true);
                    Tools.ErrorHandler(JSON, null, false, true, false);

                    return new PutOrdersResponse()
                    {
                        Header = new ResponseHeader
                        {
                            LanguageCode = _LanguageCode,
                            RequestStatus = "Error",
                            ReturnCode = AtomicAPI.Helpers.ErrorCodes.Internal,
                            StatusCode = "500",
                            ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("500"),
                            //ReturnCode = ModelState.Values.FirstOrDefault().Errors[0].ErrorMessage,
                            ReturnMessage = ex.Message + " " + ex.StackTrace
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                _PutOrdersResponse.Header = new ResponseHeader
                {
                    LanguageCode = _LanguageCode,
                    RequestStatus = "Error",
                    StatusCode = "400",
                    ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("400"),
                    ReturnCode = "AS00XX",
                    ReturnMessage = "Please check request syntax " + ex.Message + " " + ex.StackTrace
                };
                //Tools.ErrorHandler("Request: " + Request.ToString(), null, false, true, false);
                Tools.ErrorHandler("Please check request syntax", ex, false, true, true);
            }

            return _PutOrdersResponse;
        }

        [HttpPost]
        public GetOrderInfoResponse GetOrderInfo([FromBody] GetOrderInfoRequest Request)
        {//Proxi vers tred
            // PHP

            string _LanguageCode = "";

            try { _LanguageCode = Request.Request.LanguageCode; }
            catch
            {
                _LanguageCode = "En";
            }

            GetOrderInfoResponse _GetOrderInfoResponse = new GetOrderInfoResponse();

            try
            {
                if (!new AtomicAPI.Helpers.APIHelper().ValidateToken(Request.Header.Token))
                {
                    _GetOrderInfoResponse.Header = new ResponseHeader
                    {
                        LanguageCode = _LanguageCode,
                        RequestStatus = "Error",
                        StatusCode = "401",
                        ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("401"),
                        ReturnCode = "AS00XX",
                        ReturnMessage = "Invalid token"
                    };
                    return _GetOrderInfoResponse;
                }

                try
                {
                    _GetOrderInfoResponse.Response = new Models.OrdersInfoResponse();

                    //_GetOrderInfoResponse.Response.Orders = BuildOrdersList(Request);

                    foreach (AtomicOrderAPI.Models.Order _Order in _GetOrderInfoResponse.Response.Orders)
                    {
                        if (_Order.Status == "Error")
                        {
                            _GetOrderInfoResponse.Header = new ResponseHeader
                            {
                                LanguageCode = _LanguageCode,
                                RequestStatus = "Error",
                                StatusCode = "400",
                                ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("400"),
                                ReturnCode = "ASxxxx",
                                ReturnMessage = _Order.OrderKey
                            };

                            _GetOrderInfoResponse.Response.Orders = null;
                        }
                    }
                    if (_GetOrderInfoResponse.Header == null)
                        _GetOrderInfoResponse.Header = new ResponseHeader
                        {
                            LanguageCode = _LanguageCode,
                            RequestStatus = "Ok",
                            StatusCode = "200",
                            ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("200"),
                            ReturnCode = "AS0000",
                            ReturnMessage = _GetOrderInfoResponse.Response.Orders.Count.ToString() + " orders found"
                        };

                    string JSON = JsonConvert.SerializeObject(Request);
                    Tools.ErrorHandler(" GetOrderInfo Request OK" + JSON, null, false, true, false);

                    return _GetOrderInfoResponse;
                }
                catch (Exception ex)
                {
                    string JSON = JsonConvert.SerializeObject(Request);
                    Tools.ErrorHandler(AtomicAPI.Helpers.ErrorCodes.Internal, ex, false, true, true);
                    Tools.ErrorHandler(JSON, null, false, true, false);

                    return new Models.GetOrderInfoResponse ()
                    {
                        Header = new ResponseHeader
                        {
                            LanguageCode = _LanguageCode,
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
                _GetOrderInfoResponse.Header = new ResponseHeader
                {
                    LanguageCode = _LanguageCode,
                    RequestStatus = "Error",
                    StatusCode = "400",
                    ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("400"),
                    ReturnCode = "AS00XX",
                    ReturnMessage = "Please check request syntax " + ex.Message + " " + ex.StackTrace
                };
                //Tools.ErrorHandler("Request: " + Request.ToString(), null, false, true, false);
                Tools.ErrorHandler("Please check request syntax", ex, false, true, true);
            }

            return _GetOrderInfoResponse;
        }

        [HttpPost]
        public PutOrderInfoResponse PutOrderInfo([FromBody] PutOrderInfoRequest Request)
        {//Tred vers proxi

            string _LanguageCode = "";

            try { _LanguageCode = Request.Request.LanguageCode; }
            catch
            {
                _LanguageCode = "En";
            }

            PutOrderInfoResponse _PutOrderInfoResponse = new PutOrderInfoResponse();

            try
            {
                if (!new AtomicAPI.Helpers.APIHelper().ValidateToken(Request.Header.Token))
                {
                    _PutOrderInfoResponse.Header = new ResponseHeader
                    {
                        LanguageCode = _LanguageCode,
                        RequestStatus = "Error",
                        StatusCode = "401",
                        ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("401"),
                        ReturnCode = "AS00XX",
                        ReturnMessage = "Invalid token"
                    };
                    return _PutOrderInfoResponse;
                }

                try
                {
                    _PutOrderInfoResponse.Response = new Models.OrdersInfoResponse();
                    //_PutOrderInfoResponse.Response.Orders = BuildOrdersList(Request);

                    foreach (AtomicOrderAPI.Models.Order _Order in _PutOrderInfoResponse.Response.Orders)
                    {
                        if (_Order.Status == "Error")
                        {
                            _PutOrderInfoResponse.Header = new ResponseHeader
                            {
                                LanguageCode = _LanguageCode,
                                RequestStatus = "Error",
                                StatusCode = "400",
                                ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("400"),
                                ReturnCode = "ASxxxx",
                                ReturnMessage = _Order.OrderKey
                            };

                            _PutOrderInfoResponse.Response.Orders = null;
                        }
                    }
                    if (_PutOrderInfoResponse.Header == null)
                        _PutOrderInfoResponse.Header = new ResponseHeader
                        {
                            LanguageCode = _LanguageCode,
                            RequestStatus = "Ok",
                            StatusCode = "200",
                            ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("200"),
                            ReturnCode = "AS0000",
                            ReturnMessage = _PutOrderInfoResponse.Response.Orders.Count.ToString() + " orders found"
                        };

                    string JSON = JsonConvert.SerializeObject(Request);
                    Tools.ErrorHandler(" PutOrderInfo Request OK" + JSON, null, false, true, false);

                    return _PutOrderInfoResponse;
                }
                catch (Exception ex)
                {
                    string JSON = JsonConvert.SerializeObject(Request);
                    Tools.ErrorHandler(AtomicAPI.Helpers.ErrorCodes.Internal, ex, false, true, true);
                    Tools.ErrorHandler(JSON, null, false, true, false);

                    return new PutOrderInfoResponse ()
                    {
                        Header = new ResponseHeader
                        {
                            LanguageCode = _LanguageCode,
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
                _PutOrderInfoResponse.Header = new ResponseHeader
                {
                    LanguageCode = _LanguageCode,
                    RequestStatus = "Error",
                    StatusCode = "400",
                    ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("400"),
                    ReturnCode = "AS00XX",
                    ReturnMessage = "Please check request syntax " + ex.Message + " " + ex.StackTrace
                };
                //Tools.ErrorHandler("Request: " + Request.ToString(), null, false, true, false);
                Tools.ErrorHandler("Please check request syntax", ex, false, true, true);
            }

            return _PutOrderInfoResponse;

        }

        

    }

}
