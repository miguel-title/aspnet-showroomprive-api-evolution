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
using AtomicParcelAPI.Models;
using AtomicSeller.Helpers;
using System.Security.Claims;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using AtomicAPI.Helpers;

using AtomicCommonAPI.Models;
using AtomicDeliveryAPI.Models;
using Microsoft.AspNetCore.Mvc;

// This API will become obsolete
// To be replaced by PutDelivery

namespace AtomicParcelAPI.Controllers
{

    public class ParcelController : BaseController
    {

        #region SendParcel
        [HttpPost]
        public PutParcelResponse SendParcel([FromBody]PutParcelRequest Request)
        {
            return _SendParcel(Request);
        }

        [HttpPost]
        public PutParcelResponse PutParcel([FromBody]PutParcelRequest Request)
        {
            return _SendParcel(Request);
        }

        public PutParcelResponse _SendParcel(PutParcelRequest Request)
        {
            return null;
        }
        

        PutParcelResponse ReturnTestingValue(PutParcelRequest _PutParcelRequest)
        {
            AtomicParcelAPI.Models.PutParcelResponse _ParcelResponse;

            _ParcelResponse = new AtomicParcelAPI.Models.PutParcelResponse()
            {
                Header = new ResponseHeader
                {
                    LanguageCode = "Fr",
                    RequestStatus = "Ok",
                    StatusCode = "200",
                    ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("200"),
                    ReturnCode = "AS0000",
                    ReturnMessage = "Ok"
                },
                Response = new AtomicParcelAPI.Models.ParcelResponse()
                {
                    LabelURL = "www.atomicseller.com/labelsample.pdf",
                    LabelURL2 = "",
                    CN23DocURL = "www.atomicseller.com/CN23sample.pdf",
                    TrackingNumber = "8567465",
                    RelayCode = "",
                    RelayLib = "",
                    TrackingURL = "",
                    Debug = "",
                    parcelNumberPartner = "85765646573574E"
                }

            };
            return _ParcelResponse;

        }

  
  
        private string MapURL(string path)
        {
            string appPath = HttpContext.Request.Path.ToString();
            //string appPath = HttpContext.Current.Server.MapPath("/").ToLower();
            return string.Format("{0}", path.ToLower().Replace(appPath, "").Replace("inetpub","").Replace("wwwroot", "").Replace(@"\", "/").Replace("d:/","").Replace("c:/", "").Replace("//", "/"));
        }

      
        
        #endregion //PutParcel

        #region GetParcelInfo
        /// ------------------------------
        /// GetParcelInfo
        /// ------------------------------

        [HttpPost]
        public GetParcelInfoResponse GetParcelInfo([FromBody]GetParcelInfoRequest _ParcelInfoRequest)
        {
            GetParcelInfoResponse _GetParcelInfoResponse = new GetParcelInfoResponse();

            bool RequestSyntaxError = false;

            if (_ParcelInfoRequest == null) RequestSyntaxError = true;

            if (!RequestSyntaxError)
                if (_ParcelInfoRequest.Header == null && _ParcelInfoRequest.Request == null)
                    RequestSyntaxError = true;

            if (RequestSyntaxError)
            {
                string RetMsg = "Invalid request. Example : {\"ParcelHeader\": {\"Token\": \"LIJIUGTIUY976R976F42UV087G07G0875RF9762OUYVO8GYP4GIE2P9G\"},\"ParcelInfoRequest\": {\"TrackingNumber\": \"1234\", \"CarrierServiceKey\": \"COLISSIMOKey1\" } }";

                _GetParcelInfoResponse.Header = new ResponseHeader
                {
                    LanguageCode = "En",
                    RequestStatus = "Error",
                    StatusCode = "400",
                    ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("400"),
                    ReturnCode = "AS0xxxx",
                    ReturnMessage = RetMsg

                };
                return _GetParcelInfoResponse;
            }

            try
            {
                if (!new AtomicAPI.Helpers.APIHelper().ValidateToken(_ParcelInfoRequest.Header.Token))
                {
                    _GetParcelInfoResponse.Header = new ResponseHeader
                    {
                        LanguageCode = "En",
                        RequestStatus = "Error",
                        StatusCode = "401",
                        ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("401"),
                        ReturnCode = AtomicAPI.Helpers.ErrorCodes.InvalidToken,
                        ReturnMessage = AtomicAPI.Helpers.Constants.GetErrorDescription(AtomicAPI.Helpers.ErrorCodes.InvalidToken)
                    };
                    return _GetParcelInfoResponse;
                }
                else
                {
                    // Token OK
                }


                _GetParcelInfoResponse.Header = new ResponseHeader
                {
                    LanguageCode = "En",
                    RequestStatus = "Ok",
                    StatusCode = "200",
                    ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("200"),
                    ReturnCode = "AS0000",
                    ReturnMessage = ""
                };
                return _GetParcelInfoResponse;

            }
            catch (Exception ex)
            {
                _GetParcelInfoResponse.Response = new GetLabelInfoResponse();

                _GetParcelInfoResponse.Header = new ResponseHeader
                {
                    LanguageCode = "En",
                    RequestStatus = "Error",
                    StatusCode = "500",
                    ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("500"),
                    ReturnCode = "AS0xxx",
                    ReturnMessage = ex.Message
                };
            }
            return _GetParcelInfoResponse;
        }

        #endregion 

        #region GetLabelsList
        /// ------------------------------
        /// GetLabelsList
        /// ------------------------------

        [HttpPost]
        public GetLabelsListResponse GetLabelsList([FromBody] GetLabelsListRequest Request)
        {
            GetLabelsListResponse _GetLabelsListResponse = new GetLabelsListResponse();

            _GetLabelsListResponse.Response = new List<LabelInfoResponse>();
            try
            {
                if (new AtomicAPI.Helpers.APIHelper().ValidateToken(Request.ParcelHeader.Token)==false)
                {
                    _GetLabelsListResponse.Header = new ResponseHeader
                    {
                        LanguageCode = "En",
                        RequestStatus = "Error",
                        StatusCode = "401",
                        ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("401"),
                        ReturnCode = "AS00XX",
                        ReturnMessage = "Invalid token"
                    };
                }
                else
                {
                    _GetLabelsListResponse.Header = new ResponseHeader
                    {
                        LanguageCode = "En",
                        RequestStatus = "Ok",
                        StatusCode = "200",
                        ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("200"),
                        ReturnCode = "AS0000",
                        ReturnMessage = ""
                    };


                }
            }
            catch (Exception ex)
            {
                _GetLabelsListResponse.Header = new ResponseHeader
                {
                    LanguageCode = "En",
                    RequestStatus = "Error",
                    StatusCode = "500",
                    ReasonPhrase = AtomicAPI.Helpers.Constants.GetReasonPhrase("500"),
                    ReturnCode = "AS00XX",
                    ReturnMessage = ex.Message
                };
            }

            return _GetLabelsListResponse;
        }

  
         #endregion
        
    }
}