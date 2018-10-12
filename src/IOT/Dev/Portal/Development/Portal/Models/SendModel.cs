using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Portal.Classes;
using System.ComponentModel.DataAnnotations;
using DC.Data;

namespace Portal.Models
{
    public class SendModel
    {
        public int Id { get; set; }
        public decimal CustomerId { get; set; }
        public string sender { get; set; }
         [CheckAmount]
        public string reciver { get; set; }
        public string status { get; set; }
        public System.DateTime date { get; set; }
        public bool confirm { get; set; }
        public decimal CurrentAmount { get; set; }
       
        public decimal BitAmount { get; set; }
        public decimal AUDAmount { get; set; }

        public virtual Customer Customer { get; set; }
    }
}