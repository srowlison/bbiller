using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DC.Payment
{
    [ServiceContract(Namespace = "https://payment.diamondcircle.net/v1")]
    public interface IExchange
    {
        [OperationContract(IsOneWay = false)]
        Decimal GetSpotPrice(String currencyCode, Decimal amount, Int32 terminalId);

        [OperationContract(IsOneWay = false)]
        Common.Models.Margin GetMargin(String currencyCode, Int32 terminalId);
    }
}
