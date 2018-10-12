using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using LibUsbDotNet;
using LibUsbDotNet.Main;
using LibUsbDotNet.LudnMonoLibUsb;

namespace DC.PrintingServices
{
    /// <summary>
    /// Provides functionality for printing to the TG2480 receipt printer.
    /// </summary>
    public class TG2480Printer : DC.PrintingServices.IPrinter
    {
        #region Fields
        private UsbDeviceFinder _deviceFinder; // The USB device finder used to locate the printer.
        private UsbDevice _printer; // The printer.
        private IUsbDevice _printerUSBDevice; // The interface used to communicate with the printer.
        private UsbEndpointWriter _writer; // The writer used for sending commands and dat a to the printer.

        private int _vendorID; // The vendor ID of the printer USB device.
        private int _productID; // The product ID of the printer USB device.
        private bool _initialised = false; // Whether the printer is ready for printing.
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of TG2480Printer.
        /// </summary>
        /// <param name="vendorID">The vendor ID of the printer USB device.</param>
        /// <param name="productID">The product ID of the printer USB device.</param>
        public TG2480Printer(int vendorID, int productID)
        {
            _vendorID = vendorID;
            _productID = productID;
        }
        #endregion

        #region Properties

        #region Vendor ID
        /// <summary>
        /// Gets the vendor ID of the printer USB device.
        /// </summary>
        public int VendorID
        {
            get
            {
                return _vendorID;
            }
        }
        #endregion

        #region Product ID
        /// <summary>
        /// Gets the product ID of the printer USB device.
        /// </summary>
        public int ProductID
        {
            get
            {
                return _productID;
            }
        }
        #endregion

        #region Initialised
        /// <summary>
        /// Gets whether the printer is ready for printing.
        /// </summary>
        public bool Initialised
        {
            get
            {
                return _initialised;
            }
        }
        #endregion

        #endregion

        #region Methods

        #region Initialise
        /// <summary>
        /// Performs initialisation tasks required before enabling printing.
        /// </summary>
        /// <exception cref="DC.PrintingServices.PrinterNotFoundException">No printer can be found with the specified vendor id and product id.</exception>
        public void Initialise()
        {
            // Create a USB device finder for finding the printer.
            _deviceFinder = new UsbDeviceFinder(this.VendorID, this.ProductID);

            // Find and open a connection to the printer.
            _printer = UsbDevice.OpenUsbDevice(_deviceFinder);

            _printerUSBDevice = _printer as IUsbDevice;

            if (_printerUSBDevice != null)
            {
                // ANDREW LING [28 Feburary 2014]: Make the configuration and interface settings configurable.
                _printerUSBDevice.SetConfiguration(1);
                _printerUSBDevice.ClaimInterface(0);
            }
            else
            {
                // The printer cannot be located. 

                // ANDREW LING [28 February 2014]: TODO: Log when the printer cannot be located.
                // ANDREW LING [28 February 2014]: TODO: Display an error message on screen when the printer cannot be located.

                throw new PrinterNotFoundException(this.VendorID, this.ProductID);
            }

            // ANDREW LING [28 February 2014]: TODO: Make the write end point ID configurable.
            _writer = _printerUSBDevice.OpenEndpointWriter(WriteEndpointID.Ep02);

            // Mark that the initialisation tasks have been completed.
            _initialised = true;
        }
        #endregion

        #region Print Text
        /// <summary>
        /// Prints the specified text.
        /// </summary>
        /// <param name="data">The text to print.</param>
        /// <exception cref="System.ArgumentException">
        ///     <paramref name="data" /> is null or empty.
        /// </exception>
        public ErrorCode PrintText(string data)
        {
            if (String.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentException("Data cannot be null or empty.", "data");
            }

            // Write the data to the printer.
            List<byte> buffer = new List<byte>();
            buffer.AddRange(Encoding.ASCII.GetBytes(data));
            buffer.Add(0x0A);

            byte[] bufferArray = buffer.ToArray();

            int bytesWritten;
            int totalBytesWritten = 0;

            while (totalBytesWritten < bufferArray.Length)
            {
                ErrorCode writeErrorCode = _writer.Write(bufferArray, totalBytesWritten, (bufferArray.Length - totalBytesWritten), 10000, out bytesWritten);

                totalBytesWritten += bytesWritten;

                if(writeErrorCode != ErrorCode.None)
                {
                    //TODO: Log the error.
                    return writeErrorCode;
                }
            }

            return ErrorCode.None;
        }
        #endregion

        #endregion
        #region Diagnostics
        public ErrorCode GetDeviceStatus()
        {

            // Refer to page 8 of user manual
           
            // Real Time Status Transmission
            // Format - 10 04 hex
            // Range - n = 20 - Full Status
            // 
            // Write the data to the printer.

            // Return the Status Code......
            
            // This code has never been tested.

            List<byte> buffer = new List<byte>();
            buffer.Add(0x10);
            buffer.Add(0x04);
            buffer.Add(0x20);

            byte[] bufferArray = buffer.ToArray();

            int bytesWritten;
            int totalBytesWritten = 0;

            while (totalBytesWritten < bufferArray.Length)
            {
                // ANDREW LING [28 February 2014]: TODO: Make the timeout user configurable.
                ErrorCode writeErrorCode = _writer.Write(bufferArray, totalBytesWritten, (bufferArray.Length - totalBytesWritten), 10000, out bytesWritten);

                totalBytesWritten += bytesWritten;

                if (writeErrorCode != ErrorCode.None)
                {
                    // ANDREW LING [28 February 2014]: TODO: Log the error.
                    return writeErrorCode;
                }
            }

            return ErrorCode.None;





        }


        #endregion
    }
}