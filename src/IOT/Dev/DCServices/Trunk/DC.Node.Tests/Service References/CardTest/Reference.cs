﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dcweb.Tests.CardTest {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="https://payment.diamondcircle.net/v1", ConfigurationName="CardTest.ICard")]
    public interface ICard {
        
        [System.ServiceModel.OperationContractAttribute(Action="https://payment.diamondcircle.net/v1/ICard/AddCardWithPIN", ReplyAction="https://payment.diamondcircle.net/v1/ICard/AddCardWithPINResponse")]
        void AddCardWithPIN(string CardId, string PublicKey, string Password, string PIN);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://payment.diamondcircle.net/v1/ICard/AddCardWithPIN", ReplyAction="https://payment.diamondcircle.net/v1/ICard/AddCardWithPINResponse")]
        System.Threading.Tasks.Task AddCardWithPINAsync(string CardId, string PublicKey, string Password, string PIN);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://payment.diamondcircle.net/v1/ICard/AddCard", ReplyAction="https://payment.diamondcircle.net/v1/ICard/AddCardResponse")]
        void AddCard(
                    string CardId, 
                    string PublicKey, 
                    string Password, 
                    string FirstName, 
                    string LastName, 
                    string Address, 
                    string City, 
                    string Zip, 
                    string State, 
                    string Country, 
                    string Telephone, 
                    string DOB, 
                    string EmailAddress, 
                    string CardHolderName, 
                    string CardNumber, 
                    string ExpiryMonth, 
                    string ExpiryYear, 
                    string CVC2);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://payment.diamondcircle.net/v1/ICard/AddCard", ReplyAction="https://payment.diamondcircle.net/v1/ICard/AddCardResponse")]
        System.Threading.Tasks.Task AddCardAsync(
                    string CardId, 
                    string PublicKey, 
                    string Password, 
                    string FirstName, 
                    string LastName, 
                    string Address, 
                    string City, 
                    string Zip, 
                    string State, 
                    string Country, 
                    string Telephone, 
                    string DOB, 
                    string EmailAddress, 
                    string CardHolderName, 
                    string CardNumber, 
                    string ExpiryMonth, 
                    string ExpiryYear, 
                    string CVC2);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://payment.diamondcircle.net/v1/ICard/GetCustomerCC", ReplyAction="https://payment.diamondcircle.net/v1/ICard/GetCustomerCCResponse")]
        DC.Common.Models.CCInfo GetCustomerCC(string CardId);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://payment.diamondcircle.net/v1/ICard/GetCustomerCC", ReplyAction="https://payment.diamondcircle.net/v1/ICard/GetCustomerCCResponse")]
        System.Threading.Tasks.Task<DC.Common.Models.CCInfo> GetCustomerCCAsync(string CardId);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://payment.diamondcircle.net/v1/ICard/IsCardOnFile", ReplyAction="https://payment.diamondcircle.net/v1/ICard/IsCardOnFileResponse")]
        bool IsCardOnFile(string CardId);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://payment.diamondcircle.net/v1/ICard/IsCardOnFile", ReplyAction="https://payment.diamondcircle.net/v1/ICard/IsCardOnFileResponse")]
        System.Threading.Tasks.Task<bool> IsCardOnFileAsync(string CardId);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://payment.diamondcircle.net/v1/ICard/GetHotWalletAddress", ReplyAction="https://payment.diamondcircle.net/v1/ICard/GetHotWalletAddressResponse")]
        string GetHotWalletAddress();
        
        [System.ServiceModel.OperationContractAttribute(Action="https://payment.diamondcircle.net/v1/ICard/GetHotWalletAddress", ReplyAction="https://payment.diamondcircle.net/v1/ICard/GetHotWalletAddressResponse")]
        System.Threading.Tasks.Task<string> GetHotWalletAddressAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="https://payment.diamondcircle.net/v1/ICard/AddOnlineAccount", ReplyAction="https://payment.diamondcircle.net/v1/ICard/AddOnlineAccountResponse")]
        DC.Common.Models.OnlineAccount AddOnlineAccount();
        
        [System.ServiceModel.OperationContractAttribute(Action="https://payment.diamondcircle.net/v1/ICard/AddOnlineAccount", ReplyAction="https://payment.diamondcircle.net/v1/ICard/AddOnlineAccountResponse")]
        System.Threading.Tasks.Task<DC.Common.Models.OnlineAccount> AddOnlineAccountAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="https://payment.diamondcircle.net/v1/ICard/WriteTransaction", ReplyAction="https://payment.diamondcircle.net/v1/ICard/WriteTransactionResponse")]
        decimal WriteTransaction(string CardId, string TransType, int TerminalId, string NumuratorCurrency, string DenominatorCurrency, decimal Amount, decimal Price, string Reference, int TransactionID);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://payment.diamondcircle.net/v1/ICard/WriteTransaction", ReplyAction="https://payment.diamondcircle.net/v1/ICard/WriteTransactionResponse")]
        System.Threading.Tasks.Task<decimal> WriteTransactionAsync(string CardId, string TransType, int TerminalId, string NumuratorCurrency, string DenominatorCurrency, decimal Amount, decimal Price, string Reference, int TransactionID);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://payment.diamondcircle.net/v1/ICard/CreateaPayment", ReplyAction="https://payment.diamondcircle.net/v1/ICard/CreateaPaymentResponse")]
        bool CreateaPayment(string PaymentProvider);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://payment.diamondcircle.net/v1/ICard/CreateaPayment", ReplyAction="https://payment.diamondcircle.net/v1/ICard/CreateaPaymentResponse")]
        System.Threading.Tasks.Task<bool> CreateaPaymentAsync(string PaymentProvider);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICardChannel : dcweb.Tests.CardTest.ICard, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CardClient : System.ServiceModel.ClientBase<dcweb.Tests.CardTest.ICard>, dcweb.Tests.CardTest.ICard {
        
        public CardClient() {
        }
        
        public CardClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CardClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CardClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CardClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddCardWithPIN(string CardId, string PublicKey, string Password, string PIN) {
            base.Channel.AddCardWithPIN(CardId, PublicKey, Password, PIN);
        }
        
        public System.Threading.Tasks.Task AddCardWithPINAsync(string CardId, string PublicKey, string Password, string PIN) {
            return base.Channel.AddCardWithPINAsync(CardId, PublicKey, Password, PIN);
        }
        
        public void AddCard(
                    string CardId, 
                    string PublicKey, 
                    string Password, 
                    string FirstName, 
                    string LastName, 
                    string Address, 
                    string City, 
                    string Zip, 
                    string State, 
                    string Country, 
                    string Telephone, 
                    string DOB, 
                    string EmailAddress, 
                    string CardHolderName, 
                    string CardNumber, 
                    string ExpiryMonth, 
                    string ExpiryYear, 
                    string CVC2) {
            base.Channel.AddCard(CardId, PublicKey, Password, FirstName, LastName, Address, City, Zip, State, Country, Telephone, DOB, EmailAddress, CardHolderName, CardNumber, ExpiryMonth, ExpiryYear, CVC2);
        }
        
        public System.Threading.Tasks.Task AddCardAsync(
                    string CardId, 
                    string PublicKey, 
                    string Password, 
                    string FirstName, 
                    string LastName, 
                    string Address, 
                    string City, 
                    string Zip, 
                    string State, 
                    string Country, 
                    string Telephone, 
                    string DOB, 
                    string EmailAddress, 
                    string CardHolderName, 
                    string CardNumber, 
                    string ExpiryMonth, 
                    string ExpiryYear, 
                    string CVC2) {
            return base.Channel.AddCardAsync(CardId, PublicKey, Password, FirstName, LastName, Address, City, Zip, State, Country, Telephone, DOB, EmailAddress, CardHolderName, CardNumber, ExpiryMonth, ExpiryYear, CVC2);
        }
        
        public DC.Common.Models.CCInfo GetCustomerCC(string CardId) {
            return base.Channel.GetCustomerCC(CardId);
        }
        
        public System.Threading.Tasks.Task<DC.Common.Models.CCInfo> GetCustomerCCAsync(string CardId) {
            return base.Channel.GetCustomerCCAsync(CardId);
        }
        
        public bool IsCardOnFile(string CardId) {
            return base.Channel.IsCardOnFile(CardId);
        }
        
        public System.Threading.Tasks.Task<bool> IsCardOnFileAsync(string CardId) {
            return base.Channel.IsCardOnFileAsync(CardId);
        }
        
        public string GetHotWalletAddress() {
            return base.Channel.GetHotWalletAddress();
        }
        
        public System.Threading.Tasks.Task<string> GetHotWalletAddressAsync() {
            return base.Channel.GetHotWalletAddressAsync();
        }
        
        public DC.Common.Models.OnlineAccount AddOnlineAccount() {
            return base.Channel.AddOnlineAccount();
        }
        
        public System.Threading.Tasks.Task<DC.Common.Models.OnlineAccount> AddOnlineAccountAsync() {
            return base.Channel.AddOnlineAccountAsync();
        }
        
        public decimal WriteTransaction(string CardId, string TransType, int TerminalId, string NumuratorCurrency, string DenominatorCurrency, decimal Amount, decimal Price, string Reference, int TransactionID) {
            return base.Channel.WriteTransaction(CardId, TransType, TerminalId, NumuratorCurrency, DenominatorCurrency, Amount, Price, Reference, TransactionID);
        }
        
        public System.Threading.Tasks.Task<decimal> WriteTransactionAsync(string CardId, string TransType, int TerminalId, string NumuratorCurrency, string DenominatorCurrency, decimal Amount, decimal Price, string Reference, int TransactionID) {
            return base.Channel.WriteTransactionAsync(CardId, TransType, TerminalId, NumuratorCurrency, DenominatorCurrency, Amount, Price, Reference, TransactionID);
        }
        
        public bool CreateaPayment(string PaymentProvider) {
            return base.Channel.CreateaPayment(PaymentProvider);
        }
        
        public System.Threading.Tasks.Task<bool> CreateaPaymentAsync(string PaymentProvider) {
            return base.Channel.CreateaPaymentAsync(PaymentProvider);
        }
    }
}
