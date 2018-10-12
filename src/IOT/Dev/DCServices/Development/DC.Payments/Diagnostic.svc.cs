using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DC.Payment
{
    public class Diagnostics : IDiagnostic
    {
        public String HeartBeat(Int32 TerminalId, string IPAddress)
        {
            // It lives
            System.Diagnostics.TraceEventType Severity = System.Diagnostics.TraceEventType.Information;


            LogEntry log = new LogEntry()
            {
                Message = String.Format("Terminal {0} {1} {2}", TerminalId, IPAddress, "HeartBeat"),
                Severity = Severity};
            Logger.Write(log);
            return "OK";
        }

        public bool ServiceError(Int32 TerminalId, String Category, System.Diagnostics.TraceEventType Severity, string ErrorCondition)
        {
            LogEntry log = new LogEntry()
            {
                Message = String.Format("Terminal {0} {1} {2}", TerminalId, Category, ErrorCondition),
                Severity = Severity
            };
            Logger.Write(log);
            return true;
        }

        public Common.Models.TerminalSettings GetSettings(Int32 TerminalId)
        {
            using(DC.Data.DiamondCircle_dbEntities db = new Data.DiamondCircle_dbEntities())
            {
                DC.Data.Terminal terminal = db.Terminals.FirstOrDefault(t => t.Id == TerminalId);
                if (terminal != null)
                {
                    Common.Models.TerminalSettings settings = new Common.Models.TerminalSettings()
                    {
                        DefaultCryptoCurrency = terminal.DefaultCryptoCurrency,
                        DefaultFiatCurrency = terminal.DefaultFiatCurrency
                    };

                    return settings;
                }
                else
                {
                    throw new KeyNotFoundException("No terminal exists.");
                }
            }
        }
    }
}
