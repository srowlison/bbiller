using System;
namespace DC.PaymentProvider.DTO.WalPay
{
    public interface IMerchantInfo
    {
        string MerchantName { get; }
        string MerchantPIN { get; }
        Uri NotificationURL { get; set; }
        Uri RedirectURL { get; set; }
        string ToString();
    }
}
