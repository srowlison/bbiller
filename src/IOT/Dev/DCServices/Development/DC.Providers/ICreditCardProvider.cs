using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DC.Cards;



namespace DC.Providers
{
    public interface ICreditCardProvider
    {
        ChargeResult DoPayment(string CCNumber, Int32 Amount, string FirstName, string LastName, string Address, string City, string Zip, string State, string Country, string Telephone, string DOB, string EmailAddress, string CardHolderName, string ExpiryMonth, string ExpiryYear, string CVC2, String Currency);

        RefundResult DoRefund(string Id);

       

    }

   
}
