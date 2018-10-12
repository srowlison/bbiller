using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using LibUsbDotNet;

using LibUsbDotNet.Main;
using LibUsbDotNet.LudnMonoLibUsb;

namespace RecieptPrinterTest
{
    /// <summary>
    /// A form for testing the Diamond Circle Receipt Printer.
    /// </summary>
    /// <author email="andrew@acomit.com.au">Andrew Ling</author>
    /// <dateCreated>Monday 24 February 2014</dateCreated>
    public partial class ReceiptPrinterTestForm : Form
    {
        #region Fields
        public static UsbDeviceFinder _printerFinder = new UsbDeviceFinder(0x0DD4, 0x01A8);
        public static UsbDevice _printer;
        public static IUsbDevice _printerUsbDevice;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of ReceiptPrinterTestForm.
        /// </summary>
        public ReceiptPrinterTestForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        #endregion

        #region Methods

        #region Print Button - Clicked
        private void btnPrint_Click(object sender, EventArgs e)
        {
            _printer = UsbDevice.OpenUsbDevice(_printerFinder);

            _printerUsbDevice = _printer as IUsbDevice;

            if (_printerUsbDevice != null)
            {
                // This is a "whole" USB device. Before it can be used, 
                // the desired configuration and interface must be selected.

                // Select config #1
                _printerUsbDevice.SetConfiguration(1);

                // Claim interface #0.
                _printerUsbDevice.ClaimInterface(0);
            }

            // open write endpoint 1.
            UsbEndpointWriter writer = _printer.OpenEndpointWriter(WriteEndpointID.Ep02);
            List<byte> writeBytesList = new List<byte>();
            writeBytesList.AddRange(Encoding.ASCII.GetBytes(txtTextToPrint.Text));
            writeBytesList.Add(0x0A);

            byte[] writeBuffer = writeBytesList.ToArray();

            int bytesWritten;
            ErrorCode writeErrorCode = writer.Write(writeBuffer, 10000, out bytesWritten);

            // open read endpoint 1.
            //UsbEndpointReader reader = printer.OpenEndpointReader(ReadEndpointID.Ep01);

            //ErrorCode readErrorCode = ErrorCode.None;

            //byte[] readBuffer = new byte[1024];

            //while (readErrorCode == ErrorCode.None)
            //{
            //    int bytesRead;

            //    // If the device hasn't sent data in the last 100 milliseconds,
            //    // a timeout error (ec = IoTimedOut) will occur. 
            //    readErrorCode = reader.Read(readBuffer, 10000, out bytesRead);

            //    if (bytesRead == 0)
            //    {
            //        break;
            //    }

            //    // Write that output to the console.
            //    MessageBox.Show(Encoding.ASCII.GetString(readBuffer, 0, bytesRead));
            //}
        }
        #endregion

        #endregion
    }
}