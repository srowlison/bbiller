using System;

namespace DC.PaymentProvider.DTO.WalPay
{
    [Serializable]
    public class DiamondCircleEuro : IMerchantInfo
    {
        public String MerchantName { get { return "diamondcircle_eur"; } }

        public String MerchantPIN { get { return "wXO!OrzyAc?5BTrY2J@F"; } }

        public Uri NotificationURL { get; set; }

        public Uri RedirectURL { get; set; }

        public override string ToString()
        {
            return String.Format("<MerchantInfo><MerchantName>{0}</MerchantName><MerchantPIN>{1}</MerchantPIN></MerchantInfo>><NotificationURL>https://diamondcircle.net/IPN.aspx</NotificationURL><RedirectURL>https://diamondcircle.net</RedirectURL></MerchantInfo>", this.MerchantName, this.MerchantPIN);
        }
    }
}
