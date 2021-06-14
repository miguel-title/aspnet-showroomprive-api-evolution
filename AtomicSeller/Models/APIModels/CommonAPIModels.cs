using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AtomicAPI.Helpers;
using AtomicSeller.ViewModels;

namespace AtomicCommonAPI.Models
{
    public class RequestHeader
    {
        [CustomRequiredFieldValidator(ErrorCodes.RequiredToken)]
        [CustomStringLengthValidator(Lengths.Token, ErrorCodes.LengthToken)]
        public string Token { get; set; }
        public string Option { get; set; }
    }

    public class ResponseHeader
    {
        public string StatusCode { get; set; }
        public string ReasonPhrase { get; set; }
        public string RequestStatus { get; set; }
        public string ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
        public string LanguageCode { get; set; }
    }



    public class APIAddress
    {
        [CustomStringLengthValidator(Lengths.SenderLanguageCode, ErrorCodes.LengthSenderLanguageCode)]
        public string LanguageCode { get; set; }

        //[CustomRequiredFieldValidator(ErrorCodes.RequiredSendercompanyName)]
        [CustomStringLengthValidator(Lengths.SendercompanyName, ErrorCodes.LengthSendercompanyName)]
        public string CompanyName { get; set; }

        [CustomStringLengthValidator(Lengths.SenderCompanyCode, ErrorCodes.LengthSenderCompanyCode)]
        public string CompanyCode { get; set; }

        [CustomStringLengthValidator(Lengths.SenderfirstName, ErrorCodes.LengthSenderfirstName)]
        public string FirstName { get; set; }
        [CustomStringLengthValidator(Lengths.SenderlastName, ErrorCodes.LengthSenderlastName)]
        public string LastName { get; set; }
        
        [CustomStringLengthValidator(Lengths.SenderAdr0, ErrorCodes.LengthSenderAdr0)]
        public string Addr0 { get; set; }

        [CustomStringLengthValidator(Lengths.SenderAdr1, ErrorCodes.LengthSenderAdr1)]
        public string Addr1 { get; set; }

        [CustomRequiredFieldValidator(ErrorCodes.RequiredSenderAdr2)]
        [CustomStringLengthValidator(Lengths.SenderAdr2, ErrorCodes.LengthSenderAdr2)]
        public string Addr2 { get; set; }

        [CustomStringLengthValidator(Lengths.SenderAdr3, ErrorCodes.LengthSenderAdr3)]
        public string Addr3 { get; set; }

        public string StreetNumber { get; set; }
        public string StreeetName { get; set; }

        //[CustomRequiredFieldValidator(ErrorCodes.RequiredSendercountryCode)]
        [CustomStringLengthValidator(Lengths.SendercountryCode, ErrorCodes.LengthSendercountryCode)]
        public string CountryCode { get; set; }

        [CustomStringLengthValidator(Lengths.SendercountryLib, ErrorCodes.LengthSendercountryLib)]
        public string CountryName { get; set; }

        //[CustomRequiredFieldValidator(ErrorCodes.RequiredSendercity)]
        [CustomStringLengthValidator(Lengths.Sendercity, ErrorCodes.LengthSendercity)]
        public string City { get; set; }

        //[CustomRequiredFieldValidator(ErrorCodes.RequiredSenderzipCode)]
        [CustomStringLengthValidator(Lengths.SenderzipCode, ErrorCodes.LengthSenderzipCode)]
        public string ZipCode { get; set; }

        [CustomStringLengthValidator(Lengths.SenderphoneNumber, ErrorCodes.LengthSenderphoneNumber)]
        public string PhoneNumber { get; set; }

        [CustomStringLengthValidator(Lengths.SenderMobileNumber, ErrorCodes.LengthSenderMobileNumber)]
        public string MobileNumber { get; set; }

        [CustomStringLengthValidator(Lengths.SenderDoorCode1, ErrorCodes.LengthSenderDoorCode1)]
        public string DoorCode1 { get; set; }

        [CustomStringLengthValidator(Lengths.SenderCode2, ErrorCodes.LengthSenderCode2)]
        public string DoorCode2 { get; set; }

        [CustomStringLengthValidator(Lengths.Senderemail, ErrorCodes.LengthSenderemail)]
        [CustomRegularExpressionValidator(ErrorCodes.InvalidSenderEmailFormat, FormatExpressions.EmailFormat)]
        [EmailAddress]
        public string Email { get; set; }

        [CustomStringLengthValidator(Lengths.SenderRelayNumber, ErrorCodes.LengthSenderRelayNumber)]
        public string RelayNumber { get; set; }

        [CustomStringLengthValidator(Lengths.SenderRelayCountry, ErrorCodes.LengthSenderRelayCountry)]
        public string RelayCountry { get; set; }

    }


}