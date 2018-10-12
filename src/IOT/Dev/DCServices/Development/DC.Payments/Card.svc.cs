using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DCPaymentService;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using DC.Data;
using DC.Common.Models;
using DC.Providers;
using DC.Cards;

namespace DC.Payment
{
    public class Card : ICard
    {
       

        public ChargeResult ChargeCreditCard(string CCNumber, Int32 Amount, string FirstName, string LastName, string Address, string City, string Zip, string State, string Country, string Telephone, string DOB, string EmailAddress, string CardHolderName, string ExpiryMonth, string ExpiryYear, string CVC2, string Currency)
        {
            Stripe StripeGateway = new Stripe();

            ChargeResult chargeresult = StripeGateway.DoPayment(CCNumber, Amount, FirstName, LastName, Address, City, Zip, State, Country, Telephone, DOB, EmailAddress, CardHolderName, ExpiryMonth, ExpiryYear, CVC2, Currency);
            return chargeresult;
        

        }
        public RefundResult RefundCreditCard(String id)
        {
            Stripe StripeGateway = new Stripe();
            RefundResult refundresult = StripeGateway.DoRefund(id);
            return refundresult;
        

        }
        public void AddCard(string CardId, string PublicKey, string Password, string FirstName, string LastName, string Address, string City, string Zip, string State, string Country, string Telephone, string DOB, string EmailAddress, string CardHolderName, string CardNumber, string ExpiryMonth, string ExpiryYear, string CVC2)
        {
            // Depreciated

            //if (CountryId == 0)
            //{
            //    using (DiamondCircle_dbEntities db = new DiamondCircle_dbEntities())
            //    {
            //        var matchedCountryId = db.countries.Where(c => c.name == Country).FirstOrDefault().Id;
            //        CountryId = matchedCountryId;
            //    }
            //}

            //Save customer details
            //var customerId = CreateCustomer(FirstName, LastName, Address, City, Zip, State, CountryId, Telephone, DOB, EmailAddress);

            AddCardWithPIN(CardId, PublicKey, Password, "");

            //Save ccDetails
            CreateCreditCard(CardId, FirstName, LastName, Address, City, Zip, State, Country, Telephone, DOB, EmailAddress, CardHolderName, CardNumber, ExpiryMonth, ExpiryYear, CVC2);


        }

        
        public void AddCardWithPinLimit(string CardId, string PublicKey, string Password, string FirstName, string LastName, string Address, string City, string Zip, string State, string Country, string Telephone, string DOB, string EmailAddress, string CardHolderName, string CardNumber, string ExpiryMonth, string ExpiryYear, string CVC2, string PIN, string CurrencyCode, decimal Limit, bool Topup, Decimal TopupAmount)
        {

            //if (CountryId == 0)
            //{
            //    using (DiamondCircle_dbEntities db = new DiamondCircle_dbEntities())
            //    {
            //        var matchedCountryId = db.countries.Where(c => c.name == Country).FirstOrDefault().Id;
            //        CountryId = matchedCountryId;
            //    }
            //}

            //Save customer details
            //var customerId = CreateCustomer(FirstName, LastName, Address, City, Zip, State, CountryId, Telephone, DOB, EmailAddress);

            AddCardWithPINL(CardId, PublicKey, Password, PIN, CurrencyCode, Limit, Topup, TopupAmount);

            //Save ccDetails
            CreateCreditCard(CardId, FirstName, LastName, Address, City, Zip, State, Country, Telephone, DOB, EmailAddress, CardHolderName, CardNumber, ExpiryMonth, ExpiryYear, CVC2);


        }



        private decimal CreateCustomer(string firstName, string lastName, string address, string city, string zip, string state, int countryId, string telephone, DateTime dob, string emailAddress)
        {
            using(DiamondCircle_dbEntities db = new DiamondCircle_dbEntities())
            {

                var newAddress = new DC.Data.Address() { AddressLine1 = address, Suburb = city, Postcode = zip, CountryId = countryId, State = state, Mobile = telephone, AddressTypeId = 2 };
                var customer = new Customer() { CreateDate = DateTime.Today, FirstName = firstName, DOB = dob, EmailAddress = emailAddress };
                customer.Addresses.Add(newAddress);
                db.Customers.Add(customer);
                
                db.SaveChanges();
                //Check if the customerId is returned on save
                var customerId = customer.CustomerId;
                return customerId;
            }
        }

        private void AddCreditCardDetails(string cardId, string firstName, string lastName, string address, string city, string zip, string state, string countryName, string telephone, string dob, string emailAddress, string cardHolderName, string cardNumber, string expiryMonth, string expiryYear, string cvc2)
        {
            //Add a billing address
            //var billingAddress = new DC.Data.Address() { AddressLine1 = address, Suburb = city, Postcode = zip, State = state, Mobile = telephone, CountryId = countryId, AddressTypeId = 1 };
            //CC details including the billing address
            var crediCardId = Guid.NewGuid();

            var creditCard = new CreditCard() {  CreditCardId = crediCardId, Active = true, CardHolderName = cardHolderName, CardNumber = cardNumber, ExpiryMonth = expiryMonth, ExpiryYear = expiryYear, CVC2 = cvc2, AddressLine1 = address, Suburb = city, Postcode = zip, State = state, CountryName = countryName, Telephone = telephone, FirstName = firstName, LastName = lastName, DOB = dob, EmailAddress = emailAddress };
             
            using(DC.Data.DiamondCircle_dbEntities db = new Data.DiamondCircle_dbEntities())
            {
                var card = db.Cards.Where(c => c.CardId == cardId).FirstOrDefault();

                if (card == null)
                {
                    throw new InvalidOperationException("The card entered does not exist");
                }
                card.CreditCardId = crediCardId;
                db.CreditCards.Add(creditCard);
                db.SaveChanges();
            }           

        }

        private void CreateCreditCard(string cardId, string firstName, string lastName, string address, string city, string zip, string state, string countryName, string telephone, string dob, string emailAddress, string cardHolderName, string cardNumber, string expiryMonth, string expiryYear, string cvc2)
        {
            var crediCardId = Guid.NewGuid();

            var creditCard = new CreditCard() { CreditCardId = crediCardId, Active = true, CardHolderName = cardHolderName, CardNumber = cardNumber, ExpiryMonth = expiryMonth, ExpiryYear = expiryYear, CVC2 = cvc2, AddressLine1 = address, Suburb = city, Postcode = zip, State = state, CountryName = countryName, Telephone = telephone, FirstName = firstName, LastName = lastName, DOB = dob, EmailAddress = emailAddress };

            using (DC.Data.DiamondCircle_dbEntities db = new Data.DiamondCircle_dbEntities())
            {
                var card = db.Cards.Where(c => c.CardId == cardId).FirstOrDefault();

                if (card == null)
                {
                    throw new InvalidOperationException("The card entered does not exist");
                }
                card.CreditCardId = crediCardId;
                db.CreditCards.Add(creditCard);
                db.SaveChanges();
            }
        }


        public CCInfo GetCustomerCC(string CardId)
        {
            
            using (DiamondCircle_dbEntities db = new DiamondCircle_dbEntities())
            {
                var card = db.Cards.Where(c => c.CardId == CardId).FirstOrDefault();

                if(card == null)
                {
                    throw new InvalidOperationException("The card entered does not exist");
                }

                var creditCard = db.CreditCards.Where(cc => cc.CreditCardId == card.CreditCardId).FirstOrDefault();
                if (creditCard == null)
                {
                    throw new InvalidOperationException("This card does not have credit card details related to it.");
                }

                CCInfo ccDetails = new CCInfo()
                {
                    Address = creditCard.AddressLine1,
                    CardHolderName = creditCard.CardHolderName,
                    CardNumber = creditCard.CardNumber,
                    City = creditCard.Suburb,
                    CountryName = creditCard.CountryName,
                    CVC2 = creditCard.CVC2,
                    EmailAddress = creditCard.EmailAddress,
                    FirstName = creditCard.FirstName,
                    LastName = creditCard.LastName,
                    State = creditCard.State,
                    Telephone = creditCard.Telephone,
                    Zip = creditCard.Postcode,
                    DOB = creditCard.DOB
                };

                if (creditCard.ExpiryDate.HasValue) ccDetails.ExpiryDate = (DateTime)creditCard.ExpiryDate;

                return ccDetails;
            }


        }


        private void AddCardWithCustomerId(string CardId, string PublicKey, string Password, string PIN, decimal customerId)
        {
           using (DC.Data.DiamondCircle_dbEntities ef = new Data.DiamondCircle_dbEntities())
            {
                ef.Cards.Add(new DC.Data.Card() { CardId = CardId, PublicKey = PublicKey, Password = Password, Pin = PIN, DateIssued = DateTime.Now, CustomerID = customerId });
                ef.SaveChanges();
            }
        }

        public void AddCardWithPIN(string CardId, string PublicKey, string Password, string PIN)
            // Depreciated
        {
            using (DC.Data.DiamondCircle_dbEntities ef = new Data.DiamondCircle_dbEntities())
            {
                
                ef.Cards.Add(new DC.Data.Card() { CardId = CardId, PublicKey = PublicKey, Password = Password, Pin = PIN, DateIssued = DateTime.Now });
                ef.SaveChanges();
            }
        }
        
        
        public void AddCardWithPINL(string CardId, string PublicKey, string Password, string PIN, string CurrencyCode, decimal Limit, bool Topup, Decimal TopupAmount)
        {
                // Untested - Fields not added to database.
            using (DC.Data.DiamondCircle_dbEntities ef = new Data.DiamondCircle_dbEntities())
            {
                                
                 ef.Cards.Add(new DC.Data.Card() { CardId = CardId, PublicKey = PublicKey, Password = Password, Pin = PIN, DateIssued = DateTime.Now, CurrencyCode = CurrencyCode, Limit = Limit, Topup = Topup, TopupAmount = TopupAmount });
                ef.SaveChanges();
            }
        }
        public String GetHotWalletAddress()
        {
            String Address = System.Configuration.ConfigurationManager.AppSettings["HotWalletAddress"];
            if (DC.Common.BitcoinHelper.IsValidAddress(Address))
            {
                return Address;
            }
            else
            {
                throw new Exception("Web.config value is invalid");
            }
        }

        /// <summary>
        /// Get an address to sell or send to
        /// </summary>
        /// <returns></returns>
        public String GetColdStorageAddress()
        {
            using(DC.Data.DiamondCircle_dbEntities ef = new Data.DiamondCircle_dbEntities())
            {
                DC.Data.ColdStorage address = ef.ColdStorages.Single();
                return address.BitcoinAddress;
            }
        }

        public bool IsCardOnFile(string CardId)
        {
            using (DC.Data.DiamondCircle_dbEntities ef = new Data.DiamondCircle_dbEntities())
            {
                DC.Data.Card card = ef.Cards.SingleOrDefault(c => c.CardId == CardId);
                return (card != null);
            }
        }

        public bool CreateaPayment(string PaymentProvider)
        {
            // The user has just purchased a NFC wallet (from the ATM)
            // They swiped or typed in their card number
            // The mandatory fields need to be populated in the PayPal payments Object
            // The ATM is expecting an Approval that the payment was accepted.

            //  Please build out the code to suppport this feature. Keep it generic.
            if (PaymentProvider == "PayPal")
            {
                // https://developer.paypal.com/webapps/developer/docs/api/#create-a-payment

                return true;

            }
            return false;
        }

        public Decimal WriteTransaction(string CardId, string TransType, Int32 TerminalId, string NumuratorCurrency, string DenominatorCurrency, decimal Amount, decimal Price, string Reference, int TransactionID)
        {
            using (DC.Data.DiamondCircle_dbEntities ef = new Data.DiamondCircle_dbEntities())
            {
                Data.Transaction transaction = new Data.Transaction()
                {
                    CardId = CardId,
                    TransType = TransType,
                    TerminalId = TerminalId.ToString(),
                    NumuratorCurrency = NumuratorCurrency,
                    DeominatorCurrency = DenominatorCurrency,
                    Amount = Amount,
                    Price = Price,
                    Reference = Reference,
                    DateTime = DateTime.UtcNow

                };
                ef.Transactions.Add(transaction);
                ef.SaveChanges();
                return transaction.Id;
            }
        }

        public Common.Models.OnlineAccount AddOnlineAccount()
        {
            DCPaymentServiceModel model = new DCPaymentServiceModel();
            var result = model.CreateOnlineAccount();
            return result;
        }

        public bool MakeFiatPayment(string cardId, string currency, decimal amount, int terminalId)
        {
            DC.Data.CreditCard creditCard;
            //Get the card
            using (DC.Data.DiamondCircle_dbEntities ef = new Data.DiamondCircle_dbEntities())
            {
                var card = ef.Cards.Include("Card.CreditCard").FirstOrDefault(c => c.CardId == cardId);
                if (card == null) throw new InvalidOperationException("Bitcoin card ID is invalid");
                if (card.CreditCard == null) throw new InvalidOperationException("There is no credit card related to this Bitcoin card");

                creditCard = card.CreditCard;
                return (card != null);
            }

            var result = ChargeCreditCard(creditCard.CardNumber, (int)amount * 100, creditCard.FirstName, creditCard.LastName, creditCard.AddressLine1, creditCard.Suburb, creditCard.Postcode, creditCard.State, creditCard.CountryName, creditCard.Telephone, creditCard.DOB, creditCard.EmailAddress, creditCard.CardHolderName, creditCard.ExpiryMonth, creditCard.ExpiryYear, creditCard.CVC2, currency);

            return (string.IsNullOrEmpty(result.failure_code));


        }

        /// <summary>
        /// Charges the FiatAmount to the customer's credit card, 
        /// then buys the Bitcoin amount,
        /// the records the transaction.
        /// //TODO: Store a log of the transaction steps so that refunds or rollback can occur since proper transactions are impossible here
        /// </summary>
        /// <param name="CardId"></param>
        /// <param name="BitcoinAmount"></param>
        /// <param name="Currency"></param>
        /// <param name="Amount"></param>
        /// <param name="TerminalId"></param>
        /// <returns></returns>
        public bool PayForAndBuyBitcoin(string CardId, string ToCardPublicAddress, decimal BitcoinAmount, string Currency, decimal FiatAmount, int TerminalId)
        {
            if (MakeFiatPayment(CardId, Currency, FiatAmount, TerminalId))
            {
                if (ToCardPublicAddress !="")
                {
                    DC.Data.Card card;
                    using (var db = new DiamondCircle_dbEntities())
                    {
                        card = db.Cards.Where(c => c.CardId == CardId).ToList().First();
                        ToCardPublicAddress = card.PublicKey;
                    }

                }
                
                DC.Node.atm atmsvc = new Node.atm();
                                
                var order = atmsvc.CreateOrder(ToCardPublicAddress, BitcoinAmount);

                WriteTransaction(CardId, "BUY", TerminalId, Currency, "Bitcoin", BitcoinAmount, FiatAmount, order.Txn.ToString(), 1);
                
                return true;
            }
            else
            {
                return false;
            }
                
        }


    }
}
