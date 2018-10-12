using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Portal.Classes
{
    public class CheckAmount: ValidationAttribute
    {
        public CheckAmount()
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string data = (string)value;
                //NOTE:  THERE IS A REGEX TO CHECK THIS
                if (data.Length > 34 | data.Length <27 )
                {
                    return new ValidationResult("Address should be between 28 to 34 characters.");
                }

            }
            return ValidationResult.Success;
        }       
    }
}
