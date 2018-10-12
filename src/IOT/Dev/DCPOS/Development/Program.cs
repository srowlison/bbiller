using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCPOS
{
    
    public static class Program     {
        /// <summary>
        /// The main entry point for the application.
        /// 
        /// </summary>
        /// 

        public static String Pin { get; set; }
        public static String MerchantCardId { get; set; } 
        public static String MerchantEncryptedPrivateKey { get; set; }
        public static String MerchantPublicKey { get; set; }
        
        
        static void Main()
        {
            MerchantCardId = DCPOS.Properties.Settings.Default.CardId;
            MerchantEncryptedPrivateKey = DCPOS.Properties.Settings.Default.EncryptedPrivateKey;
            MerchantPublicKey = DCPOS.Properties.Settings.Default.PublicKey;

            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFormForm());
            
        }
    }
}
