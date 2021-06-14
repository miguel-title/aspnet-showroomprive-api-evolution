using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AtomicAPI.Helpers
{
    public class CustomRequiredFieldValidator : RequiredAttribute
    {
        string ClassName = "CustomRequiredFieldValidator";

        public CustomRequiredFieldValidator()
            : base()
        {
        }

        public CustomRequiredFieldValidator(string responseCode)
            : base()
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