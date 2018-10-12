using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DC.Data;

namespace Portal.Classes
{
    public class CheckEmailNotExistcs:ValidationAttribute
    {
        public CheckEmailNotExistcs()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string data = (string)value;
                DiamondCircle_dbEntities db = new DiamondCircle_dbEntities();
                if (db.UserDetails.Where(s=>s.Email==data).Count()==0)
                {
                       
                    return new ValidationResult("Email does not  exist.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
