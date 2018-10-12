using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Security;
using System.ServiceModel;
using System.Text;
using DC.Common;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Security.Permissions;
using System.Net.Mail;


namespace DC.Node
{
    [ServiceBehavior(Namespace = "http://schema.diamondcircle.net/v1")]
    //[PrincipalPermission(SecurityAction.Demand, Role = "atmusers")]
    public class atm : IAtm
    {
        private const string WALLET_LABEL = "bitcoind";

        /// <summary>
        /// Transfer coins from DC hot wallet to users address
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="cardId">Users DC Card</param>
        /// <returns></returns>
        public String TransferCoinsToBuyer(String cardId, Decimal amount)
        {
            if (amount > 0)
            {
                if (!String.IsNullOrEmpty(cardId))
                {
                    using (DC.Data.DiamondCircle_dbEntities db = new Data.DiamondCircle_dbEntities())
                    {
                        DC.Data.Card card = db.Cards.First(c => c.CardId == cardId);

                        if (card != null)
                        {
                            Providers.IWallet wallet = Helpers.Factory.GetWallet();

                            String txn = wallet.Send(card.PublicKey, amount);
                            return txn;
                        }
                        else
                        {
                            throw new Exception(String.Format("No card found with card id {0}", cardId));
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid bitcoin address.");
                }
            }
            else
            {
                throw new ArgumentException("Amount must be greater than zero.");
            }
        }

        public Decimal GetBalance(String bitcoinAddress, Int16 confirmations = 1)
        {
            if (Common.BitcoinHelper.IsValidAddress(bitcoinAddress) && confirmations > 0)
            {
                Decimal result = Helpers.Factory.GetAddressProvider().GetBalance(bitcoinAddress, confirmations);

                return result;
            }
            else
            {
                throw new ArgumentException("Check address is valid and cofirmation count is greater than zero.");
            }
        }

        public DC.Common.Models.Keys CreatePublicEncryptedPrivateKey()
        {
            try
            {
                //D as hex 
                String privateKey = Helpers.Factory.GetRandomProvider().CreatePrivateKey(256);

                if (!String.IsNullOrEmpty(privateKey))
                {
                    //Wallet import 
                    String wif = DC.Common.BitcoinHelper.EncodeWif(privateKey);

                    Byte[] password = Helpers.Factory.GetPasswordProvider().CreatePassword();
                    Byte[] encryptedWif = Security.EncryptStringToBytes_Aes(wif, password, null, System.Security.Cryptography.CipherMode.ECB);

                    String publicKey = Security.ConvertPrivateKeyToPublicKey(privateKey);

                    if (!String.IsNullOrEmpty(publicKey))
                    {
                        Byte[] publicKeyAsBytes = DC.Common.StringHelper.HexStringToByte(publicKey);

                        DC.Common.Models.Keys keys = new DC.Common.Models.Keys()
                        {
                            PrivateKey = Convert.ToBase64String(encryptedWif),
                            PublicKey = DC.Common.BitcoinHelper.CreateAddress(publicKeyAsBytes),
                            Password = password,
                            EncryptedWIFPrivateKey = encryptedWif
                        };

                        return keys;
                    }
                    else
                    {
                        throw new ArgumentException("No public key generated.");
                    }
                }
                else
                {
                    throw new ArgumentException("No random private key was generated.");
                }
            }
            catch (Exception ex)
            {
                LogWriterFactory logWriterFactory = new LogWriterFactory();
                LogWriter logWriter = logWriterFactory.Create();
                logWriter.ShouldLog(new LogEntry() { Message = ex.Message});
                throw ex;
            }
        }

        /// <summary>
        /// ATM calls this service to send BTC
        /// </summary>
        /// <param name="address"></param>
        /// <param name="btcAmount"></param>
        /// <returns></returns>
        public DC.Common.Models.Order CreateOrder(String address, Decimal btcAmount)
        {
            if (btcAmount > 0 && BitcoinHelper.IsValidAddress(address))
            { 
                //Providers.IWallet wallet = Helpers.Factory.GetWallet();
                Providers.IWallet wallet = new Providers.BlockChainInfo() { MerchantId = "4ea10592-e7cb-4170-9b5b-6e94e3236bb1", Password = "LkWBJjsT7p" };//ADD YOUR BLOCK CHAIN INFO CREDS HERE!

                //Move to a factory to spit out order model.
                DC.Common.Models.Order order = new DC.Common.Models.Order()
                {
                    Address = address,
                    BTC = btcAmount
                };

                order.Txn = wallet.Send(address, btcAmount);
                return order;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Check the bitcoin address is valid and amount is greater than zero.");
            }
        }
        

        
        public String ReceiveCoins(String encryptedPrivateKey, String cardId, String destinationAddress, Decimal amount)
        {
            if (!String.IsNullOrEmpty(cardId))
            {
                using (DC.Data.DiamondCircle_dbEntities db = new Data.DiamondCircle_dbEntities())
                {
                    DC.Data.Card card = db.Cards.First(c => c.CardId == cardId);

                    if (card != null)
                    {
                        Byte[] encryptedPrivateKeyAsBytes = Convert.FromBase64String(encryptedPrivateKey);
                        Byte[] password = Convert.FromBase64String(card.Password);
                        String wif = DC.Common.Security.DecryptStringFromBytes_Aes(encryptedPrivateKeyAsBytes, password);

                        return SignAndTransfer(wif, destinationAddress, amount);
                    }
                    else
                    {
                        throw new Exception(String.Format("No card found with card id {0}", cardId));
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Card id must not be null.");
            }
        }

        public String SendBitcoins(String encryptedPrivateKey, String password, String destinationAddress, Decimal amount)
        {
            if (!String.IsNullOrEmpty(encryptedPrivateKey) && !String.IsNullOrEmpty(password))
            {
                Byte[] privateKeyAsBytes = Convert.FromBase64String(encryptedPrivateKey);
                Byte[] passwordAsBytes = Convert.FromBase64String(password);
                String decryptedWIFPrivateKey = DC.Common.Security.DecryptStringFromBytes_Aes(privateKeyAsBytes, passwordAsBytes);

                Org.BouncyCastle.Math.BigInteger key = DC.Common.BitcoinHelper.DecodeWif(decryptedWIFPrivateKey);

                return SignAndTransfer(key.ToString(), destinationAddress, amount);
            }
            else
            {
                throw new ArgumentException("Private Key or password cannot be null");
            }
        }

        public int GetConfirmations(string publicKey)
        {
            if (!String.IsNullOrEmpty(publicKey))
            {
                try
                {
                    DC.Common.Models.UnspentResponse utxoResponse = Helpers.Factory.GetTransactionProvider().GetUnspentTxns(publicKey);

                    //Get unspent txs, largest to smallest
                    IEnumerable<DC.Common.Models.UnspentOutput> outputs = (from u in utxoResponse.UnspentOutputs
                                                                           where u.Confirmations > 0
                                                                           select u).OrderByDescending(u => u.Value);
                    if (outputs.Count() > 0)
                    {
                        return outputs.First().Confirmations;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch 
                {
                    //Returns 
                    return 0;
                }
            }
            else
            {
                throw new ArgumentException("Public Key cannot be null");
            }
        }

        /// <summary>
        /// Returns the public based on the passed private key and password
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="password"></param>
        /// <returns>Empty string if unresolvable, otherwise public key</returns>
        public string ResolvePrivateKey(string encryptedPrivateKey, string password)
        {
            if (!String.IsNullOrEmpty(encryptedPrivateKey) && !String.IsNullOrEmpty(password))
            {

                Byte[] privateKeyAsBytes = Convert.FromBase64String(encryptedPrivateKey.Trim());
                Byte[] passwordAsBytes = Convert.FromBase64String(password.Trim());
                String decryptedWIFPrivateKey = DC.Common.Security.DecryptStringFromBytes_Aes(privateKeyAsBytes, passwordAsBytes);

                Org.BouncyCastle.Math.BigInteger key = DC.Common.BitcoinHelper.DecodeWif(decryptedWIFPrivateKey);

                var sourceAddress = new Common.Models.Address(key.ToString());

                return sourceAddress.BTCAddress;
            }
            else
            {
                throw new ArgumentException("Private Key or password cannot be null");
            }

        }

        /// <summary>
        /// Sign and send bitcoins using bitcoin core
        /// </summary>
        /// <param name="privateKey">Private key as decimal</param>
        /// <param name="sourceAddress">Bitcoin address to receive change</param>
        /// <param name="destinationAddress"></param>
        /// <param name="amount"></param>
        private String SignAndTransfer(String privateKey, String destinationAddress, Decimal amount)
        {
            DC.Common.Models.Address sourceAddress = new Common.Models.Address(privateKey);
            DC.Common.Models.UnspentResponse utxoResponse = Helpers.Factory.GetTransactionProvider().GetUnspentTxns
                (sourceAddress.BTCAddress);

            Decimal fee = Convert.ToDecimal(ConfigurationManager.AppSettings["fee"]);
            fee = 0.0001M;

            //Get unspent txs, largest to smallest
            IEnumerable<DC.Common.Models.UnspentOutput> outputs = (from u in utxoResponse.UnspentOutputs
                                                                   where u.Confirmations > 0
                                                                   select u).OrderByDescending(u => u.Value);

            //There needs to be sufficient balance for the amount plus the fee
            Int64 target = Convert.ToInt64((amount + fee) * DC.Common.Math.SATOSHI);
            if (outputs.Count() > 0)
            {
                bool sufficientFunds = false;
                IList<DC.Common.Models.UnspentOutput> outputsToSpend = new List<Common.Models.UnspentOutput>();
                foreach (DC.Common.Models.UnspentOutput output in outputs)
                {
                    outputsToSpend.Add(output);
                    Int64 i = outputsToSpend.Sum(o => o.Value);

                    if (i >= target)
                    {
                        sufficientFunds = true;
                        break;
                    }
                }

                if(!sufficientFunds)
                {   
                    string message;
                    if(outputsToSpend.Sum(o => o.Value) == amount * DC.Common.Math.SATOSHI)
                    {
                        message = "There are insufficient funds to cover the transaction amount plus the bitcoin miner fee of 0.0001 Bitcoin";
                    }
                    else
                    {
                        message = "There are insufficient funds to complete this transaction";
                    }
                    throw new InvalidOperationException(message);
                }

                DC.Providers.IAddress provider = new DC.Providers.BlockChainInfo();
                String destinationHash160 = provider.GetHash160(destinationAddress);

                Helpers.Transaction Transaction = new Helpers.Transaction(outputsToSpend, sourceAddress, destinationAddress, destinationHash160, amount, fee);
                Byte[] signedTransaction = Transaction.CreateAndSignTransaction(sourceAddress, destinationAddress, destinationHash160, amount, fee);

                String signature = DC.Common.StringHelper.ByteArrayToHexString(signedTransaction);

                //  Providers.IWallet wallet = Helpers.Factory.GetWallet();
                Providers.IWallet wallet = new Providers.BlockChainInfo() { MerchantId = "4ea10592-e7cb-4170-9b5b-6e94e3236bb1", Password = "LkWBJjsT7p" };//ADD YOUR BLOCK CHAIN INFO CREDS HERE!

                String txnHash = wallet.SendRawTransaction(signature);



                return txnHash;
            }
            else
            {
                throw new ArgumentException("The address does not have any unspent transactions");
            }
        }

        public void SendEmail(String toAddress, String subject, String body)       
        {
                //Create the msg object to be sent
                MailMessage msg = new MailMessage();

                //Add email address to the recipients
                msg.To.Add(toAddress);


                MailAddress address = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["EmailAddress"]);
                msg.From = address;

                msg.Subject = subject;

                msg.Body = body;

                //Configure an SmtpClient to send the mail.

                SmtpClient client = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["Server"].ToString(), 587);

                client.EnableSsl = true; //only enable this if your provider requires it

                NetworkCredential credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["EmailAddress"].ToString(), System.Configuration.ConfigurationManager.AppSettings["EmailPass"].ToString());
                client.Credentials = credentials;

                //Send the msg
                client.Send(msg);

        }
    }
}
