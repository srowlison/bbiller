using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DC.Common.Models.BlockChainInfo
{
    [DataContract()]
    public class TransferResponse
    {
        [DataMember(Name="message")]
        public string Message { get; set; }

        [DataMember(Name="tx_hash")]
        public string TxHash { get; set; }
    }
}
