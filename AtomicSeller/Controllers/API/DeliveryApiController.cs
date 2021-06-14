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
using Microsoft.AspNetCore.Mvc;


// This is the target API 
// PutDelivery

namespace AtomicSeller.Controllers.API
{
    public class DeliveryController : ControllerBase
    {

        [HttpPost]
        public PutDeliveryInfoResponse PutDeliveryInfo([FromBody] PutDeliveryInfoRequest Request)
        {
            PutDeliveryInfoResponse _PutDeliveryInfoResponse = new PutDeliveryInfoResponse();

            try
            {
                if (!new AtomicAPI.Helpers.APIHelper().ValidateToken(Request.Header.Token))
                {
                    _PutDeliveryInfoResponse.Header = new ResponseHeader
                    {
                        LanguageCode = "En",
                        RequestStatus = "Error",
                        StatusCode = "401",
                        ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("401"),
                        ReturnCode = "AS00XX",
                        ReturnMessage = "Invalid token"
                    };
                    return _PutDeliveryInfoResponse;
                }



                //////////////////////

                try
                {
                    _PutDeliveryInfoResponse.Response = null;

                    string OrderKey = Request.Request.OrderKey;
                    string OrderID = Request.Request.OrderID;
                    string OrderID_Ext = Request.Request.OrderID_Ext;
                    string StoreKey = Request.Request.StoreKey;
                    string TrackingNumber = Request.Request.TrackingNumber;
                    string DeliveryStatus = Request.Request.DeliveryStatus;
                    string Option = Request.Request.Option;
                    string TrackingProviderKey = Request.Request.TrackingProviderKey;
                    string TrackingProviderName = Request.Request.TrackingProviderName;
                    string ShipmentDate = Request.Request.ShipmentDate;
                    string CustomerCode = Request.Request.CustomerCode;
                    string DeliveryKey = Request.Request.DeliveryKey;

                    string DeliveryID = "";
                    // Put Delivery Info (Status and tracking number)
                    if (_PutDeliveryInfoResponse.Header == null)
                        _PutDeliveryInfoResponse.Header = new ResponseHeader
                        {
                            LanguageCode = "En",
                            RequestStatus = "Ok",
                            StatusCode = "200",
                            ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("200"),
                            ReturnCode = "AS0000",
                            ReturnMessage = ""
                        };

                    string JSON = JsonConvert.SerializeObject(Request);
                    Tools.ErrorHandler(" PutDeliveryInfo Request OK" + JSON, null, false, true, false);

                    return _PutDeliveryInfoResponse;
                }
                catch (Exception ex)
                {
                    string JSON = JsonConvert.SerializeObject(Request);
                    Tools.ErrorHandler(AtomicAPI.Helpers.ErrorCodes.Internal, ex, false, true, true);
                    Tools.ErrorHandler(JSON, null, false, true, false);

                    _PutDeliveryInfoResponse.Header = new ResponseHeader
                    {
                        LanguageCode = "En",
                        RequestStatus = "Error",
                        StatusCode = "500",
                        ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("500"),
                        ReturnCode = AtomicAPI.Helpers.ErrorCodes.Internal,
                        //ReturnCode = ModelState.Values.FirstOrDefault().Errors[0].ErrorMessage,
                        ReturnMessage = ex.Message + " " + ex.StackTrace
                    };

                    return _PutDeliveryInfoResponse;

                }

                //////////////////////
            }
            catch (Exception ex)
            {
                _PutDeliveryInfoResponse.Header = new ResponseHeader
                {
                    LanguageCode = "En",
                    RequestStatus = "Error",
                    StatusCode = "500",
                    ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("500"),
                    ReturnCode = "AS00XX",
                    ReturnMessage = "Please check request syntax " + ex.Message + " " + ex.StackTrace
                };
                //Tools.ErrorHandler("Request: " + Request.ToString(), null, false, true, false);
                Tools.ErrorHandler("Please check request syntax", ex, false, true, true);
            }

            return _PutDeliveryInfoResponse;
        }


        [HttpPost]
        public GetDeliveriesResponse GetDeliveries([FromBody] GetDeliveriesRequest Request)
        {
            GetDeliveriesResponse _GetDeliveriesResponse = new GetDeliveriesResponse();

            try
            {
                if (!new AtomicAPI.Helpers.APIHelper().ValidateToken(Request.Header.Token))
                {
                    _GetDeliveriesResponse.Header = new ResponseHeader
                    {
                        LanguageCode = "En",
                        RequestStatus = "Error",
                        StatusCode = "401",
                        ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("401"),
                        ReturnCode = "AS00XX",
                        ReturnMessage = "Invalid token"
                    };
                    return _GetDeliveriesResponse;
                }




                try
                {
                    _GetDeliveriesResponse.Response = new AtomicDeliveryAPI.Models.DeliveryResponse();

                    string CreatedFromTime = Request.Request.CreatedFromTime;
                    string UpdatedFromTime = Request.Request.UpdatedFromTime;
                    string StoreKey = Request.Request.StoreKey;

                    // Get new deliveries
                    DeliveryResponse _Deliveries = null;
                   

                    _GetDeliveriesResponse.Response = _Deliveries;

                    /*
                    if (_Deliveries != null)
                        foreach (AtomicOrderAPI.Models.Order _Order in _GetDeliveriesResponse.Response.Orders)
                        {
                            if (_Order.Status == "Error")
                            {
                                _GetDeliveriesResponse.Header = new ResponseHeader
                                {
                                    LanguageCode = "En",
                                    RequestStatus = "Error",
                    StatusCode = "400",
                    ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("400"),
                                    ReturnCode = "ASxxxx",
                                    ReturnMessage = _Order.OrderKey
                                };

                                _GetDeliveriesResponse.Response.Orders = null;
                            }
                        }
                        */
                    int _nbOrders = 0;
                    try { _nbOrders = _GetDeliveriesResponse.Response.Deliveries.Count; } catch { }
                    if (_GetDeliveriesResponse.Header == null)
                        _GetDeliveriesResponse.Header = new ResponseHeader
                        {
                            LanguageCode = "En",
                            RequestStatus = "Ok",
                            StatusCode = "200",
                            ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("200"),
                            ReturnCode = "AS0000",
                            ReturnMessage = _nbOrders.ToString() + " delivery(ies) found"
                        };

                    string JSON = JsonConvert.SerializeObject(Request);
                    Tools.ErrorHandler(" GetDeliveries request OK" + JSON, null, false, true, false);

                    return _GetDeliveriesResponse;
                }
                catch (Exception ex)
                {
                    string JSON = JsonConvert.SerializeObject(Request);
                    Tools.ErrorHandler(AtomicAPI.Helpers.ErrorCodes.Internal, ex, false, true, true);
                    Tools.ErrorHandler(JSON, null, false, true, false);

                    return new GetDeliveriesResponse()
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
                _GetDeliveriesResponse.Header = new ResponseHeader
                {
                    LanguageCode = "En",
                    RequestStatus = "Error",
                    StatusCode = "500",
                    ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("500"),
                    ReturnCode = "AS00XX",
                    ReturnMessage = "Please check request syntax " + ex.Message + " " + ex.StackTrace
                };
                //Tools.ErrorHandler("Request: " + Request.ToString(), null, false, true, false);
                Tools.ErrorHandler("Please check request syntax", ex, false, true, true);
            }

            return _GetDeliveriesResponse;
        }



    }
}