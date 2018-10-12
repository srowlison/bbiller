using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.PaymentProvider
{
    public class Factory
    {
        public static IPaymentGateway GetPaymentGateway(Enums.Envoirnment environment)
        {
            IPaymentGateway gateway = new WalPayIntegration();
            return gateway;
        }

        public static DTO.WalPay.MerchantRequest GetMerchantRequest(String currencyCode)
        {
            return new DTO.WalPay.MerchantRequest();
        }
    }
}
