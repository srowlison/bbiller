using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portal.Models
{
    public class TransferModel
    {
        [Required]
        [MaxLength(16)]
        [Display(Name = "Card Id")]
        public string CardId { get; set; }

        [Required]
        [MaxLength(88)]
        [Display(Name = "Private Key")]
        //TODO is there regex or similar to validate this or a service call?
        public string PrivateKey { get; set; }

        [Required]
        [Display(Name = "Amount to transfer (BTC)")]
        [CustomValidation(typeof(TransferModel), "ValidateAmountToTransferInBtc")]
        //TODO validate amount is not greater than balance
        public decimal AmountToTransferInBtc { get; set; }

        [Required]
        [MaxLength(88)]
        [Display(Name = "Destination Address")]
        //TODO is there regex or similar to validate this or a service call?
        public string DestinationAddress { get; set; }

        public static ValidationResult ValidateAmountToTransferInBtc(decimal amount, ValidationContext validationContext)
        {
            if (amount <= 0)
                return new ValidationResult("Amount must be greater than 0", new List<string> { "AmountToTransferInBtc" });
            return ValidationResult.Success;
        }

    }
}