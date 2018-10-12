using System;
using System.ServiceModel;

namespace DC.Payment
{
    [ServiceContract(Namespace = "https://payment.diamondcircle.net/v1")]
    interface IDiagnostic
    {
        [OperationContract]
        String HeartBeat(Int32 TerminalId, string IPAddress);

        [OperationContract]
        bool ServiceError(Int32 TerminalId, string Category, System.Diagnostics.TraceEventType Severity, string ErrorCondition);

        [OperationContract]
        Common.Models.TerminalSettings GetSettings(Int32 TerminalId);
    }
}
