using System;

namespace DC.PrintingServices
{
    public interface IPrinter
    {
        int ProductID { get; }
        int VendorID { get; }
        bool Initialised { get; }

        LibUsbDotNet.Main.ErrorCode GetDeviceStatus();
        void Initialise();
        
        LibUsbDotNet.Main.ErrorCode PrintText(string data);
    }
}
