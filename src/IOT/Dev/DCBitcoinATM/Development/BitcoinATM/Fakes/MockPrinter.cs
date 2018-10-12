using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinATM.Fakes
{
    public class MockPrinter : DC.PrintingServices.IPrinter
    {
        public int ProductID
        {
            get { return 1; }
        }

        public int VendorID
        {
            get { return 1; }
        }

        public bool Initialised
        {
            get { return true; }
        }

        public LibUsbDotNet.Main.ErrorCode GetDeviceStatus()
        {
            throw new NotImplementedException();
        }

        public void Initialise()
        {
        }

        public LibUsbDotNet.Main.ErrorCode PrintText(string data)
        {
            throw new NotImplementedException();
        }
    }
}
