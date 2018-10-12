using DC.Providers.PaypalSandboxSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.Cards;


namespace DC.Providers
{
    class PayPal : ICreditCardProvider
    {
    

        public ChargeResult DoPayment(string CCNumber, Int32 Amount, string FirstName, string LastName, string Address, string City, string Zip, string State, string Country, string Telephone, string DOB, string EmailAddress, string CardHolderName, string ExpiryMonth, string ExpiryYear, string CVC2, String Currency)
        {
            // CreditCardDetailsType cardDetails = MapCardDetails(CCNumber, FirstName, LastName, Address, City, Zip, State, Country, Telephone, DOB, EmailAddress, CardHolderName, ExpiryMonth, ExpiryYear, CVC2);
            DoDirectPaymentResponseType result;
            using (var _client = new PayPalAPIAAInterfaceClient())
            {
                DoDirectPaymentRequestType pp_Request = new DoDirectPaymentRequestType();
                pp_Request.Version = "TODO set Version";
                pp_Request.DoDirectPaymentRequestDetails = new DoDirectPaymentRequestDetailsType();
                pp_Request.DoDirectPaymentRequestDetails.IPAddress = "115.187.229.184";
               //  pp_Request.DoDirectPaymentRequestDetails.CreditCard = cardDetails;

                // NOTE: The only currency supported by the Direct Payment API at this time is US dollars (USD)..
                pp_Request.DoDirectPaymentRequestDetails.PaymentDetails.OrderTotal.currencyID = CurrencyCodeType.USD;
                pp_Request.DoDirectPaymentRequestDetails.PaymentDetails.OrderTotal.Value = Amount.ToString();

                var dp = new DoDirectPaymentReq
                {
                    DoDirectPaymentRequest = pp_Request
                };

                var credentials = new CustomSecurityHeaderType
                {
                    Credentials = new UserIdPasswordType
                    {
                        Username = "username",
                        Password = "password",
                        Signature = "signature",
                        AppId = "ApiId"
                    }
                };

                result = _client.DoDirectPayment(ref credentials, dp);
            }
            var chargeResult = new ChargeResult();

            if (result != null && result.Errors.Count() > 0)
            {
                chargeResult.failure_code = result.Errors[0].ErrorCode;
                chargeResult.failure_message = result.Errors[0].ShortMessage;
            }

            chargeResult.Id = result.TransactionID;
            
            return chargeResult; 
        }

        private CreditCardDetailsType MapCardDetails(string CCNumber, string FirstName, string LastName, string Address, string City, string Zip, string State, string Country, string Telephone, string DOB, string EmailAddress, string CardHolderName, string ExpiryMonth, string ExpiryYear, string CVC2)
        {
            var details = new CreditCardDetailsType();            
            var payerInfo = new PayerInfoType();
            var address = new AddressType();
            var personalNameType = new PersonNameType();

            // var cardType = MapCardType(CardType);

            personalNameType.FirstName = FirstName;
            personalNameType.LastName = LastName;
            
            payerInfo.Address = address;
            payerInfo.ContactPhone = Telephone;
            payerInfo.PayerName = personalNameType;

            details.CardOwner = payerInfo;
            details.CreditCardNumber = CCNumber;
      //      details.CreditCardType = cardType;
            details.CVV2 = CVC2;
            details.ExpMonth = int.Parse(ExpiryMonth);
            details.ExpYear = int.Parse(ExpiryYear);

            return details;
        }

        private CreditCardTypeType MapCardType(string CardType)
        {
            switch(CardType)
            {
                case "Visa":
                    return CreditCardTypeType.Visa;

                case "Mastercard":
                    return CreditCardTypeType.MasterCard;

                default:
                    throw new NotSupportedException("This card type is not supported");
            }
        }


        public RefundResult DoRefund(string TransactionId)
        {
            throw new NotImplementedException();
        }
    }
}
