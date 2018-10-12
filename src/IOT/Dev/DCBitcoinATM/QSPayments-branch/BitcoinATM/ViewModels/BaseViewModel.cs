using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinATM.ViewModels
{
    public abstract class BaseViewModel
    {
        internal void  RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) 
            { 
                PropertyChanged(this, new  PropertyChangedEventArgs(prop)); 
            }
        }

        public event  PropertyChangedEventHandler PropertyChanged;
    }
}
