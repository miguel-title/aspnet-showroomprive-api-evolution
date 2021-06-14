using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AtomicAPI.Helpers
{
    public class CustomStringLengthValidator : StringLengthAttribute
    {
        public CustomStringLengthValidator(int maximumLength)
            : base(maximumLength)
        { }

        public CustomStringLengthValidator(int maximumLength, string responseCode)
            : base(maximumLength)
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