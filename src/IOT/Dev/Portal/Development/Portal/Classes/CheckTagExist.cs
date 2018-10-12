using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DC.Data;

namespace Portal.Classes
{
    public class CheckTagExist : ValidationAttribute
    {
        public CheckTagExist()
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string data = (string)value;

                using (DiamondCircle_dbEntities db = new DiamondCircle_dbEntities())
                {
                    if (db.Cards.Where(s => s.CardId == data).Count() == 0)
                    {
                        return new ValidationResult("Tag Id does not exist.");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
