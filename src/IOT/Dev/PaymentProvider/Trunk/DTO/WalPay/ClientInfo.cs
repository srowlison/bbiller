using System;
using System.ComponentModel.DataAnnotations;

namespace DC.PaymentProvider.DTO.WalPay
{
    [Serializable]
    public class ClientInfo
    {
        [StringLength(80)]
        [Required]
        public String AccountNumber { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Surname { get; set; }

        [Required]
        public String Address { get; set; }

        [Required]
        public String City { get; set; }

        [Required]
        public String Zip { get; set; }

        public String State { get; set; }

        [Required]
        public String Country { get; set; }

        [Required]
        public String Telephone { get; set; }

        [Required]
        //[RegularExpression]
        public String DOB { get; set; }

        public String ClientIP { get; set; }

        public override string ToString()
        {
            return "<ClientInfo><AccountNumber>hr385645</AccountNumber><Name>Bob</Name><Surname>Smith</Surname><Address>17 Main Street</Address><City>New York</City><State>NY</State><Zip>10348</Zip><Country>US</Country><Telephone>2122101938</Telephone><Email>bob.smith@test.com</Email><DOB>1986-08-12</DOB><ClientIP>215.45.81.1</ClientIP></ClientInfo>";
        }
    }
}
