using DC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {            
            DiamondCircle_dbEntities db = new DiamondCircle_dbEntities();

            Console.Write("Enter email or enter to skip: ");
            String email = Console.ReadLine();

            Decimal? CustomerId = null;

            if (!String.IsNullOrEmpty(email))
            {
                UserDetail profile = db.UserDetails.First(p => p.Email == email);

                String userId = profile.UserId.ToString();
                Customer customer = db.Customers.First(c => c.UserId == userId);
                CustomerId = customer.CustomerId;
            }

            Console.Write("Enter card id to add to database: ");
            String cardId = Console.ReadLine();

            DC.AtmService.AtmClient client = new DC.AtmService.AtmClient();
            DC.AtmService.Keys newKey = client.CreatePublicEncryptedPrivateKey();

            Card card = new Card()
            {
                CardId = cardId,
                PublicKey = newKey.PublicKey,
                Password = Convert.ToBase64String(newKey.Password),
                CustomerID = CustomerId,
                DateIssued = DateTime.UtcNow
                //Password =  newKey.Password
            };



            db.Cards.Add(card);
            db.SaveChanges();

            Console.Write("All done.  The bitcoin address is {0}", card.PublicKey);
            Console.ReadKey();
        }
    }
}
