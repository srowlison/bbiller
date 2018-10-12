using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondCircle.PrintingServices
{
    /// <summary>
    /// An exception raised when a printer cannot be found.
    /// </summary>
    /// <author email="andrew@acomit.com.au">Andrew Ling</author>
    /// <dateCreated>Friday 28 February 2014</dateCreated>
    public class PrinterNotFoundException : Exception
    {
        #region Fields
        private int _vendorID; // The vendor ID of the printer USB device.
        private int _productID; // The product ID of the printer USB device.
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of PrinterNotFoundException.
        /// </summary>
        /// <param name="vendorID">The vendor ID of the printer USB device.</param>
        /// <param name="productID">The product ID of the printer USB device.</param>
        public PrinterNotFoundException(int vendorID, int productID)
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

        #endregion

        #region Methods

        #endregion
    }
}