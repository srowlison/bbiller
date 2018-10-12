using System;
using System.Collections.Generic;
using System.Linq;

namespace DC.Providers
{

    public interface IFiat
    {
        bool MakePayment(decimal Amount, string Currency, string FirstName, string LastName, string Address, string City, string Zip, string State, string Country, string Telephone, string DOB, string EmailAddress, string CardHolderName, string CardNumber, string ExpiryMonth, string ExpiryYear, string CVC2);
        
        bool GiveRefund(decimal Amount, string Currency, string FirstName, string LastName, string Address, string City, string Zip, string State, string Country, string Telephone, string DOB, string EmailAddress, string CardHolderName, string CardNumber, string ExpiryMonth, string ExpiryYear, string CVC2);
    }
}
