using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AtomicCommonAPI.Models;


namespace AtomicParcelAPI.Models
{
    public class GetParcelInfoRequest
    {
        public RequestHeader Header { get; set; }
        public ParcelInfoRequest Request { get; set; }

    }

    public class ParcelInfoRequest
    {
        public string TrackingNumber;
        public string CarrierServiceKey;
    }

    public class GetParcelInfoResponse
    {
        public ResponseHeader Header { get; set; }
        public GetLabelInfoResponse Response { get; set; }

    }

    public class ParcelInfoResponse
    {
        // this class will be used to reply message to the client application as response.

        public ParcelInfoResponse()
        {
        }

        String labelURL;

        public String LabelURL
        {
            get { return labelURL; }
            set { labelURL = value; }
        }

        String trackingNumber;
        public String TrackingNumber
        {
            get { return trackingNumber; }
            set { trackingNumber = value; }
        }

        String parcelStatus;
        public String ParcelStatus
        {
            get { return parcelStatus; }
            set { parcelStatus = value; }
        }


    }

}