using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtomicSeller
{
    public class DEALStatus
    {
        public string Token { get; set; }
        public string InternalStatus { get; set; }
        public string Active { get; set; }
        public string Label { get; set; }
        public string Lang { get; set; }
        public DEALStatus(string _Token, string _InternalStatus, string _Active, string _Label, string _Lang)
        {
            Token = _Token;
            InternalStatus = _InternalStatus;
            Active = _Active;
            Label = _Label;
            Lang = _Lang;
        }

    }

    public class DEALStatusVM
    {
        public string Code { get; set; }
        public string Label { get; set; }
        public DEALStatusVM(string _Code, string _Label)
        {
            Code = _Code;
            Label = _Label;
        }

    }

    public class DEALCarrierVM
    {
        public string Code { get; set; }
        public string Label { get; set; }
        public DEALCarrierVM(string _Code, string _Label)
        {
            Code = _Code;
            Label = _Label;
        }

    }

    
    public class ProductShippingCategoryVM
    {
        public string Code { get; set; }
        public string Label { get; set; }
        public ProductShippingCategoryVM(string _Code, string _Label)
        {
            Code = _Code;
            Label = _Label;
        }

    }

}