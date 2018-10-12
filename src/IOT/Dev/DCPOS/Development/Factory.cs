using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCPOS
{
    internal class Factory
    {
    

        internal static INFC GetNFC()
        {
            return new btcnfcfunctions();
            //return new Fakes.MockNFC();
        }
    }
}
