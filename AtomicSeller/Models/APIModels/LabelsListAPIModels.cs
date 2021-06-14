using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AtomicCommonAPI.Models;

namespace AtomicParcelAPI.Models
{
    public class GetLabelsListRequest
    {
        public RequestHeader ParcelHeader { get; set; }
        public LabelsListRequest LabelsListRequest { get; set; }
    }

    public class LabelsListRequest
    {

        private string _StartDate;
            private string _EndDate;
            private string _Status;
            private string _TrackingNumber;

            public string StartDate
            {
                get
                { return _StartDate; }
                set
                { _StartDate = value; }
            }
            public string EndDate
            {
                get
                { return _EndDate; }
                set
                { _EndDate = value; }
            }
            public string Status
            {
                get
                { return _Status; }
                set
                { _Status = value; }
            }
            public string TrackingNumber
            {
                get
                { return _TrackingNumber; }
                set
                { _TrackingNumber = value; }
            }
        
    }

    public class GetLabelsListResponse
    {
        public ResponseHeader Header { get; set; }
        public List<LabelInfoResponse> Response { get; set; }
        public GetLabelsListResponse()
        {
        }


    }

    public class GetLabelInfoResponse
    {
        public ResponseHeader Header { get; set; }
        public LabelInfoResponse LabelInfoResponse { get; set; }

    }

    public class LabelInfoResponse
    {
        // this class will be used to reply message to the client application as response.

        public LabelInfoResponse()
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