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

        public Int16 Confirmations
        {
            get; set;
        }

        public async void GetBalance(String publicKey)
        {
            try
            {
                if (!String.IsNullOrEmpty(publicKey))
                {
                    this.Balance = await atmClient.GetBalanceAsync("bitcoin://" + publicKey, this.Confirmations);
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
