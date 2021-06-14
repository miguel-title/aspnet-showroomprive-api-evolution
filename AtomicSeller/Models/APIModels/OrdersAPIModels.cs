using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AtomicAPI.Helpers;
using AtomicSeller.Models;
using AtomicCommonAPI.Models;

namespace AtomicOrderAPI.Models
{
    public class GetOrdersRequest
    {
        public RequestHeader Header { get; set; }
        public GetOrdersData Request { get; set; }
    }
    
    public class PutOrdersRequest
    {
        public RequestHeader Header { get; set; }
        public PutOrdersData Request { get; set; }

    }
    
    public class GetOrderInfoRequest
    {
        public RequestHeader Header { get; set; }
        public GetOrdersInfoData Request { get; set; }

    }
    
    public class PutOrderInfoRequest
    {
        public RequestHeader Header { get; set; }
        public PutOrderInfoData Request { get; set; }
    }


    /*
    public class Header
    {
        public string Token { get; set; }
    }
    */
    public class GetOrdersData
    {
        public string CreatedFromTime { get; set; }
        public string UpdatedFromTime { get; set; }
        public string LanguageCode { get; set; }
        public string StoreKey { get; set; }
        public string OrderId { get; set; }
        public string OrderStatus { get; set; }
        public string CountryCode { get; set; }
        public string RuleKey { get; set; }
        public string Limit { get; set; }
        public Options Options { get; set; } // Stockit

    }
    public class Options
    {
        public string WMSKey { get; set; } // Stockit
    }

    public class PutOrderInfoData
    {
        public string CreatedFromTime { get; set; }
        public string UpdatedFromTime { get; set; }
        public string LanguageCode { get; set; }
        public string StoreKey { get; set; }
        public string OrderId { get; set; }
        public string OrderStatus { get; set; }

    }

    public class GetOrdersInfoData
    {
        public string CreatedFromTime { get; set; }
        public string UpdatedFromTime { get; set; }
        public string LanguageCode { get; set; }
        public string StoreKey { get; set; }
        public string OrderId { get; set; }
        public string OrderStatus { get; set; }
        public string CountryCode { get; set; }


    }

    public class PutOrdersData
    {
        public string StoreKey { get; set; }
        public string LanguageCode { get; set; }
        public List<Order> Orders{ get; set; }

    }

    public class GetOrdersResponse
    {
        public ResponseHeader Header { get; set; }
        public OrdersResponse Response { get; set; }
    }
    
    public class PutOrdersResponse
    {
        public ResponseHeader Header { get; set; }
        public OrdersResponse Response { get; set; }
    }

    public class GetOrderInfoResponse
    {
        public ResponseHeader Header { get; set; }
        public OrdersInfoResponse Response { get; set; }
    }
    
    public class PutOrderInfoResponse
    {
        public ResponseHeader Header { get; set; }
        public OrdersInfoResponse Response { get; set; }
    }

    public class OrdersResponse
    {
        public List<Order> Orders { get; set; }
    }

    public class OrdersInfoResponse
    {
        public List<Order> Orders { get; set; }
    }

    public class Order
    {
        public string OrderID { get; set; }
        public string OrderKey { get; set; }
        public string CustomerKey { get; set; }
        public string Status { get; set; }
        public string Marketplace { get; set; }
        public string StoreName { get; set; }
        public string StoreKey { get; set; }
        public string OrderDate { get; set; }
        public string PaymentDate { get; set; }
        public string InvoicingDate { get; set; }
        public string ModificationDate { get; set; }
        public string PaymentInfo { get; set; }
        public string TotalPriceExclTax { get; set; }
        public string TotalTax { get; set; }  
        public string TotalInsurrancePrice { get; set; }
        public string Currency { get; set; }
        public string CheckoutMessage { get; set; }
        public List<Product> Products{ get; set; }
        public Delivery Delivery{ get; set; }
        public Invoice Invoice{ get; set; }
        
    }

    public class Product
    {
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string PriceExclTax { get; set; }
        public string Weight { get; set; }
        public string CN23Category { get; set; }
        public string Quantity { get; set; }
        public string VAT { get; set; }
        public string Currency { get; set; }
        public string EANCode { get; set; }
        public string Width { get; set; }
        public string Depth { get; set; }
        public string Length { get; set; }
        public string VariationID { get; set; }
        public string SubTotalPriceExclTax { get; set; }
        public string SubTotalTax { get; set; }
        public string ItemID { get; set; }
        public List<Bundle> Bundles { get; set; }
    }


    public class Bundle
    {
        public string SKU { get; set; }
        public string BundleID { get; set; }
    }

    public class Delivery
    {
        public Parcel Parcel { get; set; }
        public Sender Sender { get; set; }
        public Recipient Recipient { get; set; }
    }

    public class Invoice
    {
        public string InvoiceID { get; set; }
        public string InvoiceKey { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string BillingCompanyName { get; set; }
        public string BillingCompanyCode { get; set; }
        public string BillingLastName { get; set; }
        public string BillingFirstName { get; set; }
        public string BillingAdr0 { get; set; }
        public string BillingAdr1 { get; set; }
        public string BillingAdr2 { get; set; }
        public string BillingAdr3 { get; set; }
        public string BillingCountryCode { get; set; }
        public string BillingCountryLib { get; set; }
        public string BillingCity { get; set; }
        public string BillingZipCode { get; set; }
        public string TotalExcVAT { get; set; }
        public string TotalVAT { get; set; }
        public string Currency { get; set; }
        public string InvoicePath { get; set; }

    }

    public class Parcel
    {
        public string ShippingProviderCode { get; set; }
        public string ShippingProviderLib { get; set; }
        public string ShippingProviderProductCode { get; set; }
        public string InsurranceYN { get; set; }
        public string InsurranceCurrency { get; set; }
        public string ParcelInsuranceValue { get; set; }
        public string ParcelValue { get; set; }
        public string ParcelWeight { get; set; }
        public string ParcelValueCurrency { get; set; }
        public string ParcelShippingPriceExclTax { get; set; }
        public string ParcelShippingTax { get; set; }
        public string recommendationLevel { get; set; }
        public string returnReceipt { get; set; }
        public string DeliveryInstructions1 { get; set; }
        public string DeliveryInstructions2 { get; set; }
        public string DeliveryInstructions3 { get; set; }
        public string ShippingDate { get; set; }
        public string TrackingInfo { get; set; }
        public string TrackingNumber { get; set; }
    }

    public class Sender
    {
        public string SenderLanguageCode { get; set; }
    public string SendercompanyName { get; set; }
    public string SenderCompanyCode { get; set; }
    public string SenderlastName { get; set; }
    public string SenderfirstName { get; set; }
    public string SenderAdr0 { get; set; }
    public string SenderAdr1 { get; set; }
    public string SenderAdr2 { get; set; }
    public string SenderAdr3 { get; set; }
    public string SendercountryCode { get; set; }
    public string SendercountryLib { get; set; }
    public string Sendercity { get; set; }
    public string SenderzipCode { get; set; }
    public string SenderphoneNumber { get; set; }
    public string SenderMobileNumber { get; set; }
    public string SenderDoorCode1 { get; set; }
    public string SenderDoorCode2 { get; set; }
    public string Senderemail { get; set; }
    public string Senderintercom { get; set; }
    public string SenderRelayCountry { get; set; }
    public string SenderRelayNumber { get; set; }
    }

    public class Recipient
    {
        public string RecipLanguageCode { get; set; }
    public string RecipCompanyName { get; set; }
    public string RecipCompanyCode { get; set; }
    public string RecipCustomerCode { get; set; }
    public string RecipFirstName { get; set; }
    public string RecipLastName { get; set; }
    public string RecipAdr0 { get; set; }
    public string RecipAdr1 { get; set; }
    public string RecipAdr2 { get; set; }
    public string RecipAdr3 { get; set; }
    public string RecipCountryCode { get; set; }
    public string RecipCountryLib { get; set; }
    public string RecipCity { get; set; }
    public string RecipZipCode { get; set; }
    public string RecipPhoneNumber { get; set; }
    public string RecipMobileNumber { get; set; }
    public string RecipDoorCode1 { get; set; }
    public string RecipDoorCode2 { get; set; }
    public string Recipemail { get; set; }
    public string RecipIntercom { get; set; }
    public string RecipStage { get; set; }
    public string RecipInhabitationType { get; set; }
    public string RecipElevator { get; set; }
    public string DeliveryRelayCountry { get; set; }
    public string DeliveryRelayNumber { get; set; }
    public string DeliveryAvisage { get; set; }
    public string DeliveryReturn { get; set; }
    public string DeliveryMontage { get; set; }
    }
    

}