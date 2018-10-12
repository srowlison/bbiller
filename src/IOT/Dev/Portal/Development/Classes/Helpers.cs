using DC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMatrix.WebData;

namespace Portal.Classes
{
    public static class Helpers
    {
        public static int GetLoggedInCustomerId(DiamondCircle_dbEntities db)
        {

            var userId = WebSecurity.CurrentUserId.ToString();
            var customer = db.Customers.Where(s => s.UserId == userId).SingleOrDefault();
            return (int)customer.CustomerId;
        }
    }
}
