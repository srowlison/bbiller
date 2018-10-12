using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC.Providers
{
    public interface ITransaction
    {
        DC.Common.Models.UnspentResponse  GetUnspentTxns(String address);
    }
}
