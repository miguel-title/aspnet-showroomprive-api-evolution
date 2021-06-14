using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AtomicAPI.Helpers;
using AtomicCommonAPI.Models;

namespace AtomicDeliveryAPI.Models
{

    /// ////////////////////////////////////////////////

    public class PutDeliveryInfoRequest
    {
        public RequestHeader Header { get; set; }
        public DeliveryInfoRequest Request { get; set; }

    }

    public class DeliveryInfoRequest
    {
        public string StoreKey { get; set; }
        public string OrderKey { get; set; }
        public string OrderID { get; set; }
        public string OrderID_Ext { get; set; }
        public string RecipEmail { get; set; }
        public string RecipFirstName { get; set; }
        public string RecipLastName { get; set; }
        public string RecipZipCode { get; set; }
        public string DeliveryStatus { get; set; }
        public string TrackingNumber { get; set; }
        public string TrackingProviderKey { get; set; }
        public string TrackingProviderName { get; set; }
        public string Option { get; set; }
        public string ShipmentDate { get; set; }
        public string CustomerCode { get; set; }
        public string DeliveryKey { get; set; }
        //public Order Order { get; set; }
        //public Delivery Delivery { get; set; }
        //public List<AtomicSeller.Models.DeliveryProduct> Products { get; set; }

    }

    public class APIDeliveryProduct
    {
        [CustomStringLengthValidator(Lengths.SKU, ErrorCodes.LengthSKU)]
        public string SKU { get; set; }
        [CustomStringLengthValidator(Lengths.ProductName, ErrorCodes.LengthProductName)]
        public string ProductName { get; set; }
        public float PriceExclTax { get; set; }
        public float Weight { get; set; }
        [CustomStringLengthValidator(Lengths.CN23Category, ErrorCodes.LengthCN23Category)]
        public string CN23Category { get; set; }
        public int Quantity { get; set; }
        public float VAT { get; set; }
        public string HSCode { get; set; }
    }

    public class PutDeliveryInfoResponse
    {
        public ResponseHeader Header { get; set; }
        public DeliveryResponse Response { get; set; }
    }
    public class GetDeliveriesResponse
    {
        public ResponseHeader Header { get; set; }
        public DeliveryResponse Response { get; set; }
    }

    public class DeliveryResponse
    {
        public List<APIDelivery> Deliveries { get; set; }
    }
    public class APIDelivery
    {
        //public AtomicSeller.Models.Delivery Delivery { get; set; }
        //public List<AtomicSeller.Models.DeliveryProduct> DeliveryProducts { get; set; }
    }


    public class GetDeliveriesRequest
    {
        public RequestHeader Header { get; set; }
        public DeliveriesRequest Request { get; set; }

    }

    public class DeliveriesRequest
    {
        public string StoreKey { get; set; }
        public string OrderKey { get; set; }
        public string OrderID { get; set; }
        public string ShipmentDate { get; set; }
        public string DeliveryKey { get; set; }
        public string LanguageCode { get; set; }
        public string CreatedFromTime { get; set; }
        public string UpdatedFromTime { get; set; }
        public string Limit { get; set; }

    }

}
