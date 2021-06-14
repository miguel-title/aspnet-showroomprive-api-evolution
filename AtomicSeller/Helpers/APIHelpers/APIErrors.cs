using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AtomicParcelAPI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AtomicAPI.Helpers
{
    public class APIErrors
    {
        public static List<SelectListItem> GetErrors()
        {
            List<SelectListItem> _list = new List<SelectListItem>();

            SelectListItem item = new SelectListItem();

            #region Mandatory Field Errors
            item = new SelectListItem() { Text = "Mandatory data 'ShippingServiceProvider' is missing", Value = ErrorCodes.RequiredShippingServiceProvider };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'Token' is missing", Value = ErrorCodes.RequiredToken };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'LabelFileFormat' is missing", Value = ErrorCodes.RequiredLabelFileFormat };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'returnReceipt' is missing", Value = ErrorCodes.RequiredreturnReceipt };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'SendercompanyName' is missing", Value = ErrorCodes.RequiredSendercompanyName };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'SenderAddr2' is missing", Value = ErrorCodes.RequiredSenderAdr2 };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'SendercountryCode' is missing", Value = ErrorCodes.RequiredSendercountryCode };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'Sendercity' is missing", Value = ErrorCodes.RequiredSendercity };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'SenderzipCode' is missing", Value = ErrorCodes.RequiredSenderzipCode };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'SenderRelayCountry' is missing", Value = ErrorCodes.RequiredSenderRelayCountry };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'SenderRelayNumber' is missing", Value = ErrorCodes.RequiredSenderRelayNumber };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'RecipLanguageCode' is missing", Value = ErrorCodes.RequiredRecipLanguageCode };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'RecipCompanyName' is missing", Value = ErrorCodes.RequiredRecipCompanyName };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'RecipFirstName' is missing", Value = ErrorCodes.RequiredRecipFirstName };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'RecipLastName' is missing", Value = ErrorCodes.RequiredRecipLastName };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'RecipAdr0' is missing", Value = ErrorCodes.RequiredRecipAdr0 };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'RecipCountryCode' is missing", Value = ErrorCodes.RequiredRecipCountryCode };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'RecipCity' is missing", Value = ErrorCodes.RequiredRecipCity };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'RecipZipCode' is missing", Value = ErrorCodes.RequiredRecipZipCode };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'DeliveryRelayCountry' is missing", Value = ErrorCodes.RequiredDeliveryRelayCountry };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'DeliveryRelayNumber' is missing", Value = ErrorCodes.RequiredDeliveryRelayNumber };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'MerchantCode' is missing", Value = ErrorCodes.RequiredMerchantCode };
            _list.Add(item);
            item = new SelectListItem() { Text = "Mandatory data 'MerchantKey' is missing", Value = ErrorCodes.RequiredMerchantKey };
            _list.Add(item);
            #endregion

            #region Max Length Errors

            item = new SelectListItem() { Text = "The Field 'ShippingServiceProvider' must not be greater than " + Lengths.ShippingServiceProvider + " characters.", Value = ErrorCodes.LengthShippingServiceProvider };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'Token' must not be greater than " + Lengths.Token + " characters.", Value = ErrorCodes.LengthToken };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'ParcelID' must not be greater than " + Lengths.ParcelID + " characters.", Value = ErrorCodes.LengthParcelID };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'Warehouse' must not be greater than " + Lengths.Warehouse + " characters.", Value = ErrorCodes.LengthWarehouse };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'InsurranceYN' must not be greater than " + Lengths.InsurranceYN + " characters.", Value = ErrorCodes.LengthInsurranceYN };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'InsurranceCurrency' must not be greater than " + Lengths.InsurranceCurrency + " characters.", Value = ErrorCodes.LengthInsurranceCurrency };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'ParcelValueCurrency' must not be greater than " + Lengths.ParcelValueCurrency + " characters.", Value = ErrorCodes.LengthParcelValueCurrency };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'recommendationLevel' must not be greater than " + Lengths.recommendationLevel + " characters.", Value = ErrorCodes.LengthrecommendationLevel };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'ParcelSizeCode' must not be greater than " + Lengths.ParcelSizeCode + " characters.", Value = ErrorCodes.LengthParcelSizeCode };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'nonMachinable' must not be greater than " + Lengths.nonMachinable + " characters.", Value = ErrorCodes.LengthnonMachinable };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'returnReceipt' must not be greater than " + Lengths.returnReceipt + " characters.", Value = ErrorCodes.LengthreturnReceipt };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'DeliveryInstructions1' must not be greater than " + Lengths.DeliveryInstructions1 + " characters.", Value = ErrorCodes.LengthDeliveryInstructions1 };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'DeliveryInstructions2' must not be greater than " + Lengths.DeliveryInstructions2 + " characters.", Value = ErrorCodes.LengthDeliveryInstructions2 };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'DeliveryInstructions3' must not be greater than " + Lengths.DeliveryInstructions3 + " characters.", Value = ErrorCodes.LengthDeliveryInstructions3 };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'LabelFileFormat' must not be greater than " + Lengths.LabelFileFormat + " characters.", Value = ErrorCodes.LengthLabelFileFormat };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'SenderLanguageCode' must not be greater than " + Lengths.SenderLanguageCode + " characters.", Value = ErrorCodes.LengthSenderLanguageCode };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'SendercompanyName' must not be greater than " + Lengths.SendercompanyName + " characters.", Value = ErrorCodes.LengthSendercompanyName };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'SenderCompanyCode' must not be greater than " + Lengths.SenderCompanyCode + " characters.", Value = ErrorCodes.LengthSenderCompanyCode };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'SenderlastName' must not be greater than " + Lengths.SenderlastName + " characters.", Value = ErrorCodes.LengthSenderlastName };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'SenderfirstName' must not be greater than " + Lengths.SenderfirstName + " characters.", Value = ErrorCodes.LengthSenderfirstName };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'SenderAdr0' must not be greater than " + Lengths.SenderAdr0 + " characters.", Value = ErrorCodes.LengthSenderAdr0 };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'SenderAdr1' must not be greater than " + Lengths.SenderAdr1 + " characters.", Value = ErrorCodes.LengthSenderAdr1 };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'SenderAdr2' must not be greater than " + Lengths.SenderAdr2 + " characters.", Value = ErrorCodes.LengthSenderAdr2 };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'SenderAdr3' must not be greater than " + Lengths.SenderAdr3 + " characters.", Value = ErrorCodes.LengthSenderAdr3 };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'SendercountryCode' must not be greater than " + Lengths.SendercountryCode + " characters.", Value = ErrorCodes.LengthSendercountryCode };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'SendercountryLib' must not be greater than " + Lengths.ShippingServiceProvider + " characters.", Value = ErrorCodes.LengthShippingServiceProvider };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'Sendercity' must not be greater than " + Lengths.SendercountryLib + " characters.", Value = ErrorCodes.LengthSendercountryLib };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'SenderzipCode' must not be greater than " + Lengths.SenderzipCode + " characters.", Value = ErrorCodes.LengthSenderzipCode };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'SenderphoneNumber' must not be greater than " + Lengths.SenderphoneNumber + " characters.", Value = ErrorCodes.LengthSenderphoneNumber };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'SenderMobileNumber' must not be greater than " + Lengths.SenderMobileNumber + " characters.", Value = ErrorCodes.LengthSenderMobileNumber };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'SenderDoorCode1' must not be greater than " + Lengths.SenderDoorCode1 + " characters.", Value = ErrorCodes.LengthSenderDoorCode1 };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'SenderCode2' must not be greater than " + Lengths.SenderCode2 + " characters.", Value = ErrorCodes.LengthSenderCode2 };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'Senderemail' must not be greater than " + Lengths.Senderemail + " characters.", Value = ErrorCodes.LengthSenderemail };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'Senderintercom' must not be greater than " + Lengths.Senderintercom + " characters.", Value = ErrorCodes.LengthSenderintercom };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'SenderRelayCountry' must not be greater than " + Lengths.SenderRelayCountry + " characters.", Value = ErrorCodes.LengthSenderRelayCountry };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'SenderRelayNumber' must not be greater than " + Lengths.SenderRelayNumber + " characters.", Value = ErrorCodes.LengthSenderRelayNumber };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipLanguageCode' must not be greater than " + Lengths.RecipLanguageCode + " characters.", Value = ErrorCodes.LengthRecipLanguageCode };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipCompanyName' must not be greater than " + Lengths.RecipCompanyName + " characters.", Value = ErrorCodes.LengthRecipCompanyName };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipCompanyCode' must not be greater than " + Lengths.RecipCompanyCode + " characters.", Value = ErrorCodes.LengthRecipCompanyCode };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipCustomerCode' must not be greater than " + Lengths.RecipCustomerCode + " characters.", Value = ErrorCodes.LengthRecipCustomerCode };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipFirstName' must not be greater than " + Lengths.RecipFirstName + " characters.", Value = ErrorCodes.LengthRecipFirstName };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipLastName' must not be greater than " + Lengths.RecipLastName + " characters.", Value = ErrorCodes.LengthRecipLastName };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipAdr0' must not be greater than " + Lengths.RecipAdr0 + " characters.", Value = ErrorCodes.LengthRecipAdr0 };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipAdr1' must not be greater than " + Lengths.RecipAdr1 + " characters.", Value = ErrorCodes.LengthRecipAdr1 };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipAdr2' must not be greater than " + Lengths.RecipAdr2 + " characters.", Value = ErrorCodes.LengthRecipAdr2 };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipAdr3' must not be greater than " + Lengths.RecipAdr3 + " characters.", Value = ErrorCodes.LengthRecipAdr3 };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipCountryCode' must not be greater than " + Lengths.RecipCountryCode + " characters.", Value = ErrorCodes.LengthRecipCountryCode };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipCountryLib' must not be greater than " + Lengths.RecipCountryLib + " characters.", Value = ErrorCodes.LengthRecipCountryLib };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipCity' must not be greater than " + Lengths.RecipCity + " characters.", Value = ErrorCodes.LengthRecipCity };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipZipCode' must not be greater than " + Lengths.RecipZipCode + " characters.", Value = ErrorCodes.LengthRecipZipCode };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipPhoneNumber' must not be greater than " + Lengths.RecipPhoneNumber + " characters.", Value = ErrorCodes.LengthRecipPhoneNumber };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipMobileNumber' must not be greater than " + Lengths.RecipMobileNumber + " characters.", Value = ErrorCodes.LengthRecipMobileNumber };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipDoorCode1' must not be greater than " + Lengths.RecipDoorCode1 + " characters.", Value = ErrorCodes.LengthRecipDoorCode1 };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipDoorCode2' must not be greater than " + Lengths.RecipDoorCode2 + " characters.", Value = ErrorCodes.LengthRecipDoorCode2 };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'Recipemail' must not be greater than " + Lengths.Recipemail + " characters.", Value = ErrorCodes.LengthRecipemail };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipIntercom' must not be greater than " + Lengths.RecipIntercom + " characters.", Value = ErrorCodes.LengthRecipIntercom };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipStage' must not be greater than " + Lengths.RecipStage + " characters.", Value = ErrorCodes.LengthRecipStage };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipInhabitationType' must not be greater than " + Lengths.RecipInhabitationType + " characters.", Value = ErrorCodes.LengthRecipInhabitationType };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'RecipElevator' must not be greater than " + Lengths.RecipElevator + " characters.", Value = ErrorCodes.LengthRecipElevator };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'DeliveryRelayCountry' must not be greater than " + Lengths.DeliveryRelayCountry + " characters.", Value = ErrorCodes.LengthDeliveryRelayCountry };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'DeliveryRelayNumber' must not be greater than " + Lengths.DeliveryRelayNumber + " characters.", Value = ErrorCodes.LengthDeliveryRelayNumber };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'DeliveryAvisage' must not be greater than " + Lengths.DeliveryAvisage + " characters.", Value = ErrorCodes.LengthDeliveryAvisage };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'DeliveryReturn' must not be greater than " + Lengths.DeliveryReturn + " characters.", Value = ErrorCodes.LengthDeliveryReturn };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'DeliveryMontage' must not be greater than " + Lengths.DeliveryMontage + " characters.", Value = ErrorCodes.LengthDeliveryMontage };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'OrderID' must not be greater than " + Lengths.OrderID + " characters.", Value = ErrorCodes.LengthOrderID };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'Marketplace' must not be greater than " + Lengths.Marketplace + " characters.", Value = ErrorCodes.LengthMarketplace };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'StoreName' must not be greater than " + Lengths.StoreName + " characters.", Value = ErrorCodes.LengthStoreName };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'SKU' must not be greater than " + Lengths.SKU + " characters.", Value = ErrorCodes.LengthSKU };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'ProductName' must not be greater than " + Lengths.ProductName + " characters.", Value = ErrorCodes.LengthProductName };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'CN23Category' must not be greater than " + Lengths.CN23Category + " characters.", Value = ErrorCodes.LengthCN23Category };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'ProductCode' must not be greater than " + Lengths.ProductCode + " characters.", Value = ErrorCodes.LengthProductCode };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'CustomsDeclarations' must not be greater than " + Lengths.CustomsDeclarations + " character(s).", Value = ErrorCodes.LengthCustomsDeclarations };
            _list.Add(item);
            item = new SelectListItem() { Text = "The Field 'Invoice' must not be greater than " + Lengths.Invoice + " characters.", Value = ErrorCodes.LengthInvoice };
            _list.Add(item);
            item = new SelectListItem() { Text = "Invalid Merchant Key.", Value = ErrorCodes.InvalidStoreKey };
            _list.Add(item);
            item = new SelectListItem() { Text = "Invalid shipping service.", Value = ErrorCodes.InvalidShippingService };
            _list.Add(item);


            #endregion

            #region Regular Expressions
            item = new SelectListItem() { Text = "Invalid sender email format", Value = ErrorCodes.InvalidSenderEmailFormat };
            _list.Add(item);
            item = new SelectListItem() { Text = "Invalid recipient email format", Value = ErrorCodes.InvalidRecipientEmailFormat };
            _list.Add(item);
            #endregion

            #region Invalid Value Error
            item = new SelectListItem() { Text = "'Token' value is invalid.", Value = ErrorCodes.InvalidToken };
            _list.Add(item);
            #endregion

            return _list;

        }
        public static List<SelectListItem> GetRestErrors()
        {            
        return new List<SelectListItem> {
            new SelectListItem() { Value = "200", Text ="Ok"  },
            new SelectListItem() { Value = "201", Text ="Created"  },
            new SelectListItem() { Value = "204", Text ="No Content"  },
            new SelectListItem() { Value = "301", Text ="Moved Permanently"  },
            new SelectListItem() { Value = "302", Text ="Moved Temporarily"  },
            new SelectListItem() { Value = "400", Text ="Bad request"  },
            new SelectListItem() { Value = "401", Text ="Unauthorized"  },
            new SelectListItem() { Value = "403", Text ="Forbidden"  },
            new SelectListItem() { Value = "404", Text ="Not Found"  },
            new SelectListItem() { Value = "405", Text ="Method Not Allowed"  },
            new SelectListItem() { Value = "406", Text ="Not Acceptable"  },
            new SelectListItem() { Value = "415", Text ="Unsupported Media Type"  },
            new SelectListItem() { Value = "500", Text ="Internal Server Error"  },
            new SelectListItem() { Value = "501", Text ="Not Implemented"  },
            new SelectListItem() { Value = "503", Text ="Service Unavailable"  },
        };
        }
    }
}