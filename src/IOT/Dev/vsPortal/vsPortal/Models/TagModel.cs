using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;
using Portal.Classes;
using DC.Data;

namespace Portal.Models
{
    public class TagModel
    {
        [Required]
        [CheckTagExist]
        [Display(Name = "Tag Id")]
        public string CardId { get; set; }
        public Customer customer;
    }
}