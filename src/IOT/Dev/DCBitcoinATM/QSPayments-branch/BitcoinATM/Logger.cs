using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BitcoinATM
{
    interface ILogger
    {
        void Debug(string text);

        void Warn(string text);

        void Error(string text);
        void Error(string text, Exception ex);
    }

    [Obsolete("User ent lib")]
    class EventLogger : ILogger
    {
        public void Debug(string text)
        {
            EventLog.WriteEntry(Process.GetCurrentProcess().ProcessName, text, EventLogEntryType.Information);
        }

        public void Warn(string text)
        {
            EventLog.WriteEntry(Process.GetCurrentProcess().ProcessName, text, EventLogEntryType.Warning);
        }

        public void Error(string text)
        {
            EventLog.WriteEntry(Process.GetCurrentProcess().ProcessName, text, EventLogEntryType.Error);
        }

        public void Error(string text, Exception ex)
        {
            Error(text);
            Error(ex.StackTrace);
        }
    }
}
