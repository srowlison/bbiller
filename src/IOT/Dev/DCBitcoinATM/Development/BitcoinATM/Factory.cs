using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinATM
{
    internal class Factory
    {
        internal static ICardIssuer GetCardIssuer()
        {
            return new CardIssuer() { Ip = "192.168.50.254" };
        }

        internal static INFC GetNFC()
        {
            //return new btcnfcfunctions();
            return new Fakes.MockNFC();
        }

        private static DC.PrintingServices.IPrinter _printer;

        internal static DC.PrintingServices.IPrinter GetPrinter()
        {
            if (_printer == null)
            {
                _printer = new DC.PrintingServices.TG2480Printer(Properties.Settings.Default.PrinterVendorId, Properties.Settings.Default.PrinterProductId);
            }
            // 3540, 424 
            return _printer;
        }
    }
}
