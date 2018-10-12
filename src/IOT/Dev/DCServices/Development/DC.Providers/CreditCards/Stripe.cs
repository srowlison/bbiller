using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.Cards;

namespace DC.Providers
{
    public class Stripe : ICreditCardProvider
    {
      

        public ChargeResult DoPayment(string CCNumber, Int32 Amount, string FirstName, string LastName, string Address, string City, string Zip, string State, string Country, string Telephone, string DOB, string EmailAddress, string CardHolderName, string ExpiryMonth, string ExpiryYear, string CVC2, string Currency)
        {

            // StripeConfiguration.SetApiKey("sk_test_tZluxZhcmbz0AfuvoYm60ic9");
             StripeConfiguration.SetApiKey("sk_live_J8Hzr3keqlfOtLn5zYAJp62S");

            
            var myCharge = new StripeChargeCreateOptions();

            // always set these properties
            myCharge.Amount = Amount;
            myCharge.Currency = Currency;

            // set this if you want to
            myCharge.Description = "";

            // set this property if using a token
            // myCharge.TokenId = *tokenId*;

            // set these properties if passing full card details
            // (do not set these properties if you have set a TokenId)
            myCharge.CardNumber = CCNumber;
            myCharge.CardExpirationYear = ExpiryYear;
            myCharge.CardExpirationMonth = ExpiryMonth;
            myCharge.CardAddressCountry = Country;               // optional
            myCharge.CardAddressLine1 = Address;    // optional
            myCharge.CardAddressLine2 = "";             // optional
            myCharge.CardAddressState = State;                 // optional
            myCharge.CardAddressZip = Zip;                // optional
            myCharge.CardName = CardHolderName;              // optional
            myCharge.CardCvc = CVC2;                        // optional

            // set this property if using a customer
            // myCharge.CustomerId = *customerId*;

            // if using a customer, you may also set this property to charge
            // a card other than the customer's default card
            // myCharge.Card = *cardId*;

            // set this if you have your own application fees (you must have your application configured first within Stripe)
            // myCharge.ApplicationFee = 25;

            // (not required) set this to false if you don't want to capture the charge yet - requires you call capture later
            myCharge.Capture = true;

            var chargeService = new StripeChargeService();
            StripeCharge stripeCharge = chargeService.Create(myCharge);
            ChargeResult chargeresult = new ChargeResult();
            chargeresult.Id = stripeCharge.Id;
            chargeresult.failure_code = stripeCharge.FailureCode;
            chargeresult.failure_message = stripeCharge.FailureMessage;
            return chargeresult;

        }
        public RefundResult DoRefund(String Id)
        {
            // StripeConfiguration.SetApiKey("sk_test_tZluxZhcmbz0AfuvoYm60ic9");
            StripeConfiguration.SetApiKey("sk_live_J8Hzr3keqlfOtLn5zYAJp62S");
            var chargeService = new StripeChargeService();
            StripeCharge striprefund = chargeService.Refund(Id);

            RefundResult refundresult = new RefundResult();
            refundresult.Id = striprefund.Id;
            return refundresult;
        }
        

    
    }
}
