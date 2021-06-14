using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtomicAPI.Helpers
{
    public class Constants
    {
        public static string GetErrorCode(string ResponseCode)
        {
            return ResponseCode;
        }

        public static string GetErrorDescription(string ResponseCode)
        {
            string Description = "";
            try
            {
                if (string.IsNullOrEmpty(ResponseCode))
                {
                    Description = " GetErroDescription: Unknown error code ";
                }
                else
                {
                    Description = ApplicationWrapper.ErrorList.Where(
                        x => x.Value == ResponseCode) == null 
                        ? "Error("+ ResponseCode+ ") message not found" 
                        : ApplicationWrapper.ErrorList.Where(x => x.Value == ResponseCode).FirstOrDefault().Text;
                }
            }
            catch (Exception ex)
            {
                //Description = ex.InnerException.StackTrace;
                Description = "Error message not found";
            }

            return Description;
        }

        public static string GetReasonPhrase(string StatusCode)
        {
            string Description = "";
            try
            {
                if (string.IsNullOrEmpty(StatusCode))
                {
                    Description = " GetErroDescription: Unknown error code ";
                }
                else
                {
                    Description = ApplicationWrapper.RestErrorsList.Where(
                        x => x.Value == StatusCode) == null
                        ? "Error(" + StatusCode + ") message not found"
                        : ApplicationWrapper.RestErrorsList.Where(x => x.Value == StatusCode).FirstOrDefault().Text;
                }
            }
            catch (Exception ex)
            {
                //Description = ex.InnerException.StackTrace;
                Description = "Error message not found";
            }

            return Description;
        }
    }

    public static class ErrorCodes
    {
        #region Length Validation Codes
        public const string LengthShippingServiceProvider = "AS0100";

        public const string LengthToken = "AS0101";

        public const string LengthParcelID = "AS0102";
        public const string LengthWarehouse = "AS0103";
        public const string LengthInsurranceYN = "AS0104";
        public const string LengthInsurranceCurrency = "AS0105";
        public const string LengthParcelValueCurrency = "AS0106";
        public const string LengthrecommendationLevel = "AS0107";
        public const string LengthParcelSizeCode = "AS0108";
        public const string LengthnonMachinable = "AS0109";
        public const string LengthreturnReceipt = "AS0110";
        public const string LengthDeliveryInstructions1 = "AS0111";
        public const string LengthDeliveryInstructions2 = "AS0112";
        public const string LengthDeliveryInstructions3 = "AS0113";
        public const string LengthProductCode = "AS0170";
        public const string LengthCustomsDeclarations = "AS0171";
        public const string LengthInvoice = "AS0172";


        public const string LengthLabelFileFormat = "AS0114";

        public const string LengthSenderLanguageCode = "AS0115";
        public const string LengthSendercompanyName = "AS0116";
        public const string LengthSenderCompanyCode = "AS0117";
        public const string LengthSenderlastName = "AS0118";
        public const string LengthSenderfirstName = "AS0119";
        public const string LengthSenderAdr0 = "AS0120";
        public const string LengthSenderAdr1 = "AS0121";
        public const string LengthSenderAdr2 = "AS0122";
        public const string LengthSenderAdr3 = "AS0123";
        public const string LengthSendercountryCode = "AS0124";
        public const string LengthSendercountryLib = "AS0125";
        public const string LengthSendercity = "AS0126";
        public const string LengthSenderzipCode = "AS0127";
        public const string LengthSenderphoneNumber = "AS0128";
        public const string LengthSenderMobileNumber = "AS0129";
        public const string LengthSenderDoorCode1 = "AS0130";
        public const string LengthSenderCode2 = "AS0131";
        public const string LengthSenderemail = "AS0132";
        public const string LengthSenderintercom = "AS0133";
        public const string LengthSenderRelayCountry = "AS0134";
        public const string LengthSenderRelayNumber = "AS0135";


        public const string LengthRecipLanguageCode = "AS0136";
        public const string LengthRecipCompanyName = "AS0137";
        public const string LengthRecipCompanyCode = "AS0138";
        public const string LengthRecipCustomerCode = "AS0139";
        public const string LengthRecipFirstName = "AS0140";
        public const string LengthRecipLastName = "AS0141";
        public const string LengthRecipAdr0 = "AS0142";
        public const string LengthRecipAdr1 = "AS0143";
        public const string LengthRecipAdr2 = "AS0144";
        public const string LengthRecipAdr3 = "AS0145";
        public const string LengthRecipCountryCode = "AS0146";
        public const string LengthRecipCountryLib = "AS0147";
        public const string LengthRecipCity = "AS0148";
        public const string LengthRecipZipCode = "AS0149";
        public const string LengthRecipPhoneNumber = "AS0150";
        public const string LengthRecipMobileNumber = "AS0151";
        public const string LengthRecipDoorCode1 = "AS0152";
        public const string LengthRecipDoorCode2 = "AS0153";
        public const string LengthRecipemail = "AS0154";
        public const string LengthRecipIntercom = "AS0155";
        public const string LengthRecipStage = "AS0156";
        public const string LengthRecipInhabitationType = "AS0157";
        public const string LengthRecipElevator = "AS0158";
        public const string LengthDeliveryRelayCountry = "AS0159";
        public const string LengthDeliveryRelayNumber = "AS0160";
        public const string LengthDeliveryAvisage = "AS0161";
        public const string LengthDeliveryReturn = "AS0162";
        public const string LengthDeliveryMontage = "AS0163";

        public const string LengthOrderID = "AS0164";
        public const string LengthOrderKey = "AS0164";
        public const string LengthMarketplace = "AS0165";
        public const string LengthStoreName = "AS0166";


        public const string LengthSKU = "AS0167";
        public const string LengthProductName = "AS0168";
        public const string LengthCN23Category = "AS0169";
        #endregion

        #region Mandatory Fields Codes
        public const string RequiredShippingServiceProvider = "AS0001";
        public const string RequiredMerchantCode = "AS0173";
        public const string RequiredMerchantKey = "AS0173";

        public const string RequiredToken = "AS0002";

        public const string RequiredLabelFileFormat = "AS0003";

        public const string RequiredreturnReceipt = "AS0004";

        public const string RequiredSendercompanyName = "AS0005";
        public const string RequiredSenderAdr2 = "AS0006";
        public const string RequiredSendercountryCode = "AS0007";
        public const string RequiredSendercity = "AS0008";
        public const string RequiredSenderzipCode = "AS0009";
        public const string RequiredSenderRelayCountry = "AS0010";
        public const string RequiredSenderRelayNumber = "AS0011";

        public const string RequiredRecipLanguageCode = "AS0012";
        public const string RequiredRecipCompanyName = "AS0013";
        public const string RequiredRecipFirstName = "AS0014";
        public const string RequiredRecipLastName = "AS0015";
        public const string RequiredRecipAdr0 = "AS0016";
        public const string RequiredRecipCountryCode = "AS0017";
        public const string RequiredRecipCity = "AS0018";
        public const string RequiredRecipZipCode = "AS0019";
        public const string RequiredDeliveryRelayCountry = "AS0020";
        public const string RequiredDeliveryRelayNumber = "AS0021"; 
        #endregion

        #region Invalid Values Validation

        public const string InvalidToken = "AS0022";

        #endregion

        #region Format Expressions
        public const string InvalidSenderEmailFormat = "AS00x1";
        public const string InvalidRecipientEmailFormat = "AS00x2";
        #endregion

        #region Other

        public const string Internal = "Internal error";

        public const string Rest = "Rest error";

        public const string InvalidStoreKey = "AS00174";

        public const string InvalidShippingService = "AS00175";

        public const string InvalidDate = "AS00176";
        #endregion

    }

    public static class FormatExpressions
    {
        public const string EmailFormat = @"\S+@\S+\.\S+";
    }

    public static class Lengths
    {
        public const int ShippingServiceProvider = 30;
        public const int MerchantCode = 20;
        public const int MerchantKey = 20;

        public const int Token = 1024;

        public const int ParcelID = 13;
        public const int Warehouse = 30;
        public const int InsurranceYN = 1;
        public const int InsurranceCurrency = 3;
        public const int ParcelValueCurrency = 3;
        public const int recommendationLevel = 2;
        public const int ParcelSizeCode = 3;
        public const int nonMachinable = 1;
        public const int returnReceipt = 1;
        public const int DeliveryInstructions1 = 160;
        public const int DeliveryInstructions2 = 160;
        public const int DeliveryInstructions3 = 160;
        public const int ProductCode = 5;
        public const int CustomsDeclarations = 1; 
        public const int Invoice = 1;
        
        public const int LabelFileFormat = 50;

        public const int SenderLanguageCode = 2;
        public const int SendercompanyName = 35;
        public const int SenderCompanyCode = 35;
        public const int SenderlastName = 35;
        public const int SenderfirstName = 29;
        public const int SenderAdr0 = 35;
        public const int SenderAdr1 = 35;
        public const int SenderAdr2 = 35;
        public const int SenderAdr3 = 35;
        public const int SendercountryCode = 2;
        public const int SendercountryLib = 35;
        public const int Sendercity = 35;
        public const int SenderzipCode = 10;
        public const int SenderphoneNumber = 20;
        public const int SenderMobileNumber = 20;
        public const int SenderDoorCode1 = 8;
        public const int SenderCode2 = 8;
        public const int Senderemail = 80;
        public const int Senderintercom = 30;
        public const int SenderRelayCountry = 50;
        public const int SenderRelayNumber = 6;

        public const int RecipLanguageCode = 35;
        public const int RecipCompanyName = 35;
        public const int RecipCompanyCode = 6;
        public const int RecipCustomerCode = 6;
        public const int RecipFirstName = 29;
        public const int RecipLastName = 35;
        public const int RecipAdr0 = 35;
        public const int RecipAdr1 = 35;
        public const int RecipAdr2 = 35;
        public const int RecipAdr3 = 35;
        public const int RecipCountryCode = 2;
        public const int RecipCountryLib = 35;
        public const int RecipCity = 35;
        public const int RecipZipCode = 10;
        public const int RecipPhoneNumber = 15;
        public const int RecipMobileNumber = 12;
        public const int RecipDoorCode1 = 8;
        public const int RecipDoorCode2 = 8;
        public const int Recipemail = 80;
        public const int RecipIntercom = 30;
        public const int RecipStage = 5;
        public const int RecipInhabitationType = 12;
        public const int RecipElevator = 5;
        public const int DeliveryRelayCountry = 2;
        public const int DeliveryRelayNumber = 6;
        public const int DeliveryAvisage = 1;
        public const int DeliveryReturn = 1;
        public const int DeliveryMontage = 1;

        public const int OrderID = 30;
        public const int OrderKey = 40;
        public const int Marketplace = 30;
        public const int StoreName = 30;


        public const int SKU = 80;
        public const int ProductName = 80;
        public const int CN23Category = 1;

    }


    public static class ApplicationWrapper
    {
        public static List<SelectListItem> ErrorList
        {
            get
            {
                //if (null != HttpContext.Current.Application["ErrorList"])
                //    return HttpContext.Current.Application["ErrorList"] as List<SelectListItem>;
                //else
                    return null;
            }
            set
            {
                //HttpContext.Current.Application["ErrorList"] = value;
            }
        }

        public static List<SelectListItem> RestErrorsList
        {
            get
            {
                //if (null != HttpContext.Current.Application["RestErrors"])
                //    return HttpContext.Current.Application["RestErrors"] as List<SelectListItem>;
                //else
                    return null;
            }
            set
            {
                //HttpContext.Current.Application["RestErrors"] = value;
            }
        }
    }
}