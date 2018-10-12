using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;

namespace DC.TransactionWorker
{
    public class WorkerRole : RoleEntryPoint
    {
        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.TraceInformation("DC.TransactionWorker entry point called");

            DC.Providers.IAddress address = new DC.Providers.BlockExplorer();

            while (true)
            {
                using (DC.Data.DiamondCircle_dbEntities ef = new Data.DiamondCircle_dbEntities())
                {
                    var transactions = ef.UnconfirmedTransactions.Where(t => t.Confirmations <= 6);
                    {
                        foreach(DC.Data.UnconfirmedTransaction u in transactions)
                        {
                            if (u.BTCAmount == address.GetBalance(u.Address, 6))
                            {
                                u.Confirmations = 6;
                            }
                        }
                    }

                    //ef.UnconfirmedTransactions.Add(transaction);
                }

                Thread.Sleep(10000);
                Trace.TraceInformation("Working");
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }
    }
}
