using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AtomicAPI.Helpers;
using AtomicCommonAPI.Models;
using AtomicDeliveryAPI.Models;

namespace AtomicParcelAPI.Models
{

    public class PutParcelRequest
    {
        public RequestHeader ParcelHeader { get; set; }
        public ShippingService ShippingService { get; set; }

        public APIDelivery Delivery { get; set; }
        public APIOrder[] Orders { get; set; }
        public Options Options { get; set; } // Stockit
    }

    public class PutParcelResponse
    {
        public ResponseHeader Header { get; set; }
        public ParcelResponse Response { get; set; }
    }

    public class ParcelResponse
    {
        public string LabelURL { get; set; }
        public string LabelURL2 { get; set; }
        public string CN23DocURL { get; set; }
        public string TrackingNumber { get; set; }
        public string RelayCode { get; set; }
        public string RelayLib { get; set; }
        public string TrackingURL { get; set; }
        public string Debug { get; set; }
        public string parcelNumberPartner { get; set; }

    }

    public class ShippingService
    {

        //[CustomStringLengthValidator(Lengths.ShippingServiceProvider)]
        public string ShippingServiceProvider { get; set; } // Obsolete (V1)

        //[CustomStringLengthValidator(Lengths.MerchantCode)]
        //public string MerchantCode { get; set; } // Obsolete
        [CustomStringLengthValidator(Lengths.MerchantKey)]
        public string MerchantKey { get; set; }
        public string CarrierServiceKey { get; set; }
        public string ShippingServiceKey { get; set; } 
        public string depositDate { get; set; }

    }

    public class SenderAddress
    {
        [CustomStringLengthValidator(Lengths.SenderLanguageCode, ErrorCodes.LengthSenderLanguageCode)]
        public string SenderLanguageCode { get; set; }

        //[CustomRequiredFieldValidator(ErrorCodes.RequiredSendercompanyName)]
        [CustomStringLengthValidator(Lengths.SendercompanyName, ErrorCodes.LengthSendercompanyName)]
        public string SendercompanyName { get; set; }

        [CustomStringLengthValidator(Lengths.SenderCompanyCode, ErrorCodes.LengthSenderCompanyCode)]
        public string SenderCompanyCode { get; set; }

        [CustomStringLengthValidator(Lengths.SenderlastName, ErrorCodes.LengthSenderlastName)]
        public string SenderlastName { get; set; }

        [CustomStringLengthValidator(Lengths.SenderfirstName, ErrorCodes.LengthSenderfirstName)]
        public string SenderfirstName { get; set; }
        public string SenderAdr0 { get; set; }

        //[CustomRequiredFieldValidator(ErrorCodes.RequiredSenderAdr0)]
        [CustomStringLengthValidator(Lengths.SenderAdr0, ErrorCodes.LengthSenderAdr0)]
        public string SenderStreetNumber { get; set; }

        [CustomStringLengthValidator(Lengths.SenderAdr1, ErrorCodes.LengthSenderAdr1)]
        public string SenderAdr1 { get; set; }

        [CustomStringLengthValidator(Lengths.SenderAdr2, ErrorCodes.LengthSenderAdr2)]
        public string SenderAdr2 { get; set; }

        [CustomStringLengthValidator(Lengths.SenderAdr3, ErrorCodes.LengthSenderAdr3)]
        public string SenderAdr3 { get; set; }

        //[CustomRequiredFieldValidator(ErrorCodes.RequiredSendercountryCode)]
        [CustomStringLengthValidator(Lengths.SendercountryCode, ErrorCodes.LengthSendercountryCode)]
        public string SendercountryCode { get; set; }

        [CustomStringLengthValidator(Lengths.SendercountryLib, ErrorCodes.LengthSendercountryLib)]
        public string SendercountryLib { get; set; }

        //[CustomRequiredFieldValidator(ErrorCodes.RequiredSendercity)]
        [CustomStringLengthValidator(Lengths.Sendercity, ErrorCodes.LengthSendercity)]
        public string Sendercity { get; set; }

        //[CustomRequiredFieldValidator(ErrorCodes.RequiredSenderzipCode)]
        [CustomStringLengthValidator(Lengths.SenderzipCode, ErrorCodes.LengthSenderzipCode)]
        public string SenderzipCode { get; set; }

        [CustomStringLengthValidator(Lengths.SenderphoneNumber, ErrorCodes.LengthSenderphoneNumber)]
        public string SenderphoneNumber { get; set; }

        [CustomStringLengthValidator(Lengths.SenderMobileNumber, ErrorCodes.LengthSenderMobileNumber)]
        public string SenderMobileNumber { get; set; }

        [CustomStringLengthValidator(Lengths.SenderDoorCode1, ErrorCodes.LengthSenderDoorCode1)]
        public string SenderDoorCode1 { get; set; }

        [CustomStringLengthValidator(Lengths.SenderCode2, ErrorCodes.LengthSenderCode2)]
        public string SenderCode2 { get; set; }

        [CustomStringLengthValidator(Lengths.Senderemail, ErrorCodes.LengthSenderemail)]
        [CustomRegularExpressionValidator(ErrorCodes.InvalidSenderEmailFormat, FormatExpressions.EmailFormat)]
        [EmailAddress]
        public string Senderemail { get; set; }

        [CustomStringLengthValidator(Lengths.Senderintercom, ErrorCodes.LengthSenderintercom)]
        public string Senderintercom { get; set; }

        //[CustomRequiredFieldValidator(ErrorCodes.RequiredSenderRelayCountry)]
        [CustomStringLengthValidator(Lengths.SenderRelayCountry, ErrorCodes.LengthSenderRelayCountry)]
        public string SenderRelayCountry { get; set; }

        //[CustomRequiredFieldValidator(ErrorCodes.RequiredSenderRelayNumber)]
        [CustomStringLengthValidator(Lengths.SenderRelayNumber, ErrorCodes.LengthSenderRelayNumber)]
        public string SenderRelayNumber { get; set; }

    }

    public class RecipientAddress
    {
        [CustomRequiredFieldValidator(ErrorCodes.RequiredRecipLanguageCode)]
        [CustomStringLengthValidator(Lengths.RecipLanguageCode, ErrorCodes.LengthRecipLanguageCode)]
        public string RecipLanguageCode { get; set; }

        //[CustomRequiredFieldValidator(ErrorCodes.RequiredRecipCompanyName)]
        [CustomStringLengthValidator(Lengths.RecipCompanyName, ErrorCodes.LengthRecipCompanyName)]
        public string RecipCompanyName { get; set; }

        [CustomStringLengthValidator(Lengths.RecipCompanyCode, ErrorCodes.LengthRecipCompanyCode)]
        public string RecipCompanyCode { get; set; }

        [CustomStringLengthValidator(Lengths.RecipCustomerCode, ErrorCodes.LengthRecipCustomerCode)]
        public string RecipCustomerCode { get; set; }

        //[CustomRequiredFieldValidator(ErrorCodes.RequiredRecipFirstName)]
        [CustomStringLengthValidator(Lengths.RecipFirstName, ErrorCodes.LengthRecipFirstName)]
        public string RecipFirstName { get; set; }

        [CustomRequiredFieldValidator(ErrorCodes.RequiredRecipLastName)]
        [CustomStringLengthValidator(Lengths.RecipLastName, ErrorCodes.LengthRecipLastName)]
        public string RecipLastName { get; set; }
        public string RecipAdr0 { get; set; }

        //[CustomRequiredFieldValidator(ErrorCodes.RequiredRecipAdr0)]
        [CustomStringLengthValidator(Lengths.RecipAdr0, ErrorCodes.LengthRecipAdr0)]
        public string RecipStreetNumber { get; set; }

        [CustomStringLengthValidator(Lengths.RecipAdr1, ErrorCodes.LengthRecipAdr1)]
        public string RecipAdr1 { get; set; }

        [CustomStringLengthValidator(Lengths.RecipAdr2, ErrorCodes.LengthRecipAdr2)]
        public string RecipAdr2 { get; set; }

        [CustomStringLengthValidator(Lengths.RecipAdr3, ErrorCodes.LengthRecipAdr3)]
        public string RecipAdr3 { get; set; }

        [CustomRequiredFieldValidator(ErrorCodes.RequiredRecipCountryCode)]
        [CustomStringLengthValidator(Lengths.RecipCountryCode, ErrorCodes.LengthRecipCountryCode)]
        public string RecipCountryCode { get; set; }

        [CustomStringLengthValidator(Lengths.RecipCountryLib, ErrorCodes.LengthRecipCountryLib)]
        public string RecipCountryLib { get; set; }

        [CustomRequiredFieldValidator(ErrorCodes.RequiredRecipCity)]
        [CustomStringLengthValidator(Lengths.RecipCity, ErrorCodes.LengthRecipCity)]
        public string RecipCity { get; set; }

        [CustomRequiredFieldValidator(ErrorCodes.RequiredRecipZipCode)]
        [CustomStringLengthValidator(Lengths.RecipZipCode, ErrorCodes.LengthRecipZipCode)]
        public string RecipZipCode { get; set; }

        [CustomStringLengthValidator(Lengths.RecipPhoneNumber, ErrorCodes.LengthRecipPhoneNumber)]
        public string RecipPhoneNumber { get; set; }

        [CustomStringLengthValidator(Lengths.RecipMobileNumber, ErrorCodes.LengthRecipMobileNumber)]
        public string RecipMobileNumber { get; set; }

        [CustomStringLengthValidator(Lengths.RecipDoorCode1, ErrorCodes.LengthRecipDoorCode1)]
        public string RecipDoorCode1 { get; set; }

        [CustomStringLengthValidator(Lengths.RecipDoorCode2, ErrorCodes.LengthRecipDoorCode2)]
        public string RecipDoorCode2 { get; set; }

        [CustomStringLengthValidator(Lengths.Recipemail, ErrorCodes.LengthRecipemail)]
        [CustomRegularExpressionValidator(ErrorCodes.InvalidRecipientEmailFormat, FormatExpressions.EmailFormat)]
        [EmailAddress]
        public string Recipemail { get; set; }

        [CustomStringLengthValidator(Lengths.RecipIntercom, ErrorCodes.LengthRecipIntercom)]
        public string RecipIntercom { get; set; }

        [CustomStringLengthValidator(Lengths.RecipStage, ErrorCodes.LengthRecipStage)]
        public string RecipStage { get; set; }

        [CustomStringLengthValidator(Lengths.RecipInhabitationType, ErrorCodes.LengthRecipInhabitationType)]
        public string RecipInhabitationType { get; set; }

        [CustomStringLengthValidator(Lengths.RecipElevator, ErrorCodes.LengthRecipElevator)]
        public string RecipElevator { get; set; }

        //[CustomRequiredFieldValidator(ErrorCodes.RequiredDeliveryRelayCountry)]
        [CustomStringLengthValidator(Lengths.DeliveryRelayCountry, ErrorCodes.LengthDeliveryRelayCountry)]
        public string DeliveryRelayCountry { get; set; }

        //[CustomRequiredFieldValidator(ErrorCodes.RequiredDeliveryRelayNumber)]
        [CustomStringLengthValidator(Lengths.DeliveryRelayNumber, ErrorCodes.LengthDeliveryRelayNumber)]
        public string DeliveryRelayNumber { get; set; }

        [CustomStringLengthValidator(Lengths.DeliveryAvisage, ErrorCodes.LengthDeliveryAvisage)]
        public string DeliveryAvisage { get; set; }

        [CustomStringLengthValidator(Lengths.DeliveryReturn, ErrorCodes.LengthDeliveryReturn)]
        public string DeliveryReturn { get; set; }

        [CustomStringLengthValidator(Lengths.DeliveryMontage, ErrorCodes.LengthDeliveryMontage)]
        public string DeliveryMontage { get; set; }
    }

    public class APIParcel
    {
        [CustomStringLengthValidator(Lengths.ParcelID, ErrorCodes.LengthParcelID)]
        public string ParcelID { get; set; }
        public int ParcelNumber { get; set; }

        [CustomStringLengthValidator(Lengths.Warehouse, ErrorCodes.LengthWarehouse)]
        public string Warehouse { get; set; }
        [CustomStringLengthValidator(Lengths.InsurranceYN, ErrorCodes.LengthInsurranceYN)]
        public string InsurranceYN { get; set; }
        [CustomStringLengthValidator(Lengths.InsurranceCurrency, ErrorCodes.LengthInsurranceCurrency)]
        public string InsurranceCurrency { get; set; }
        public float ParcelInsuranceValue { get; set; }
        public float ParcelValue { get; set; }
        [CustomStringLengthValidator(Lengths.ParcelValueCurrency, ErrorCodes.LengthParcelValueCurrency)]
        public string ParcelValueCurrency { get; set; }
        [CustomStringLengthValidator(Lengths.recommendationLevel, ErrorCodes.LengthrecommendationLevel)]
        public string recommendationLevel { get; set; }
        public float ParcelWeight { get; set; } // Stockit
        public float ParcelLength { get; set; } // Stockit
        public float ParcelHeight { get; set; } // Stockit
        public float ParcelWidth { get; set; } // Stockit

        [CustomStringLengthValidator(Lengths.ParcelSizeCode, ErrorCodes.LengthParcelSizeCode)]
        public string ParcelSizeCode { get; set; }
        public float ParcelVolume { get; set; } // Stockit
        [CustomStringLengthValidator(Lengths.nonMachinable, ErrorCodes.LengthnonMachinable)]
        public string nonMachinable { get; set; }

        //[CustomRequiredFieldValidator(ErrorCodes.RequiredreturnReceipt)]
        [CustomStringLengthValidator(Lengths.returnReceipt, ErrorCodes.LengthreturnReceipt)]
        public string returnReceipt { get; set; }
        [CustomStringLengthValidator(Lengths.DeliveryInstructions1, ErrorCodes.LengthDeliveryInstructions1)]
        public string DeliveryInstructions1 { get; set; }
        [CustomStringLengthValidator(Lengths.DeliveryInstructions2, ErrorCodes.LengthDeliveryInstructions2)]
        public string DeliveryInstructions2 { get; set; }
        [CustomStringLengthValidator(Lengths.DeliveryInstructions3, ErrorCodes.LengthDeliveryInstructions3)]
        public string DeliveryInstructions3 { get; set; }

        [CustomStringLengthValidator(Lengths.ProductCode, ErrorCodes.LengthProductCode)]
        public string ProductCode { get; set; }

        [CustomStringLengthValidator(Lengths.CustomsDeclarations, ErrorCodes.LengthCustomsDeclarations)]
        public string CustomsDeclarations { get; set; }
        public string transportationAmount { get; set; }
        public string SpecialServiceTypeCode { get; set; }
        public Label Label { get; set; }
        public string Return { get; set; }
        public string EORINumber { get; set; }

    }

    public class APIOrder
    {
        [CustomStringLengthValidator(Lengths.OrderID, ErrorCodes.LengthOrderID)]
        public string OrderID { get; set; } // Obsolete

        [CustomStringLengthValidator(Lengths.OrderKey, ErrorCodes.LengthOrderKey)]
        public string OrderKey { get; set; } // Stockit

        [CustomStringLengthValidator(Lengths.Marketplace, ErrorCodes.LengthMarketplace)]
        public string Marketplace { get; set; } // Obsolete

        [CustomStringLengthValidator(Lengths.StoreName, ErrorCodes.LengthStoreName)]
        public string StoreName { get; set; } // Obsolete
        public string StoreKey { get; set; } // Stockit
        public APIDeliveryProduct[] Products { get; set; }

        [CustomStringLengthValidator(Lengths.Invoice, ErrorCodes.LengthInvoice)]
        public string Invoice { get; set; }
        public string InvoicePath { get; set; }
        public string InvoiceContentBase64 { get; set; }
        public string CustomContent { get; set; }
        public string NumberOfPieces { get; set; }

    }

    public class Label
    {
        [CustomRequiredFieldValidator(ErrorCodes.RequiredLabelFileFormat)]
        [CustomStringLengthValidator(Lengths.LabelFileFormat, ErrorCodes.LengthLabelFileFormat)]
        public string LabelFileFormat { get; set; }
        public int x { get; set; }
        public int y { get; set; }
    }

    public class Options
    {
    public string WMSKey { get; set; } // Stockit
    }

    public class APIDelivery // Shipping
    {
        public APIParcel Parcel { get; set; }
        public SenderAddress Sender { get; set; }
        public RecipientAddress recipient { get; set; }
        public APIAddress FromAddress { get; set; }
        public APIAddress ToAddress { get; set; }
    }

}