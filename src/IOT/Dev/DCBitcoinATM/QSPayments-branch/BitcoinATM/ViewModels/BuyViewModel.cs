using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinATM.ViewModels
{
    public class BuyViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private ATM.AtmClient atmClient = new ATM.AtmClient();

        private Decimal _balance;
        public Decimal Balance 
        {
            get
            {
                return _balance;
            }
            set
            {
                if (_balance != value)
                {
                    _balance = value;
                    RaisePropertyChanged("Balance");
                }
            }
        }

        public async void GetBalance(String publicKey)
        {
            try
            {
                short confirmations = 0;
                if (!String.IsNullOrEmpty(publicKey))
                {
                    this.Balance = await atmClient.GetBalanceAsync("bitcoin://" + publicKey, confirmations);
                }
            }
            catch (Exception ex)
            {
                //GeneralExceptions("GetBalance", "High", ex);
                //ReturnToMainMenu();
            }
        }
    }
}
