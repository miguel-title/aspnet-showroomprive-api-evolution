using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace AtomicAPI.Helpers
{
    public class CustomRegularExpressionValidator : RegularExpressionAttribute
    {
        public CustomRegularExpressionValidator(string pattern)
            : base(pattern)
        {

        }

        public CustomRegularExpressionValidator(string responseCode, string pattern)
            : base(pattern)
        {
            try
            {
                string Message = responseCode;// Constants.GetErroMessage(responseCode);
                if (!string.IsNullOrEmpty(Message))
                {
                    base.ErrorMessage = Message;
                }
            }
            catch
            {

            }
        }



        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }


    }
}