﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.33440
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestHarness.atm {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Keys", Namespace="http://schemas.datacontract.org/2004/07/dcweb.Models")]
    [System.SerializableAttribute()]
    public partial class Keys : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PrivateKeyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PublicKeyField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PrivateKey {
            get {
                return this.PrivateKeyField;
            }
            set {
                if ((object.ReferenceEquals(this.PrivateKeyField, value) != true)) {
                    this.PrivateKeyField = value;
                    this.RaisePropertyChanged("PrivateKey");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PublicKey {
            get {
                return this.PublicKeyField;
            }
            set {
                if ((object.ReferenceEquals(this.PublicKeyField, value) != true)) {
                    this.PublicKeyField = value;
                    this.RaisePropertyChanged("PublicKey");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Order", Namespace="http://schemas.datacontract.org/2004/07/dcweb.Models")]
    [System.SerializableAttribute()]
    public partial class Order : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string Addressk__BackingFieldField;
        
        private decimal BTCk__BackingFieldField;
        
        private System.Guid Idk__BackingFieldField;
        
        private string PrivateKeyk__BackingFieldField;
        
        private string Txnk__BackingFieldField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Address>k__BackingField", IsRequired=true)]
        public string Addressk__BackingField {
            get {
                return this.Addressk__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.Addressk__BackingFieldField, value) != true)) {
                    this.Addressk__BackingFieldField = value;
                    this.RaisePropertyChanged("Addressk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<BTC>k__BackingField", IsRequired=true)]
        public decimal BTCk__BackingField {
            get {
                return this.BTCk__BackingFieldField;
            }
            set {
                if ((this.BTCk__BackingFieldField.Equals(value) != true)) {
                    this.BTCk__BackingFieldField = value;
                    this.RaisePropertyChanged("BTCk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Id>k__BackingField", IsRequired=true)]
        public System.Guid Idk__BackingField {
            get {
                return this.Idk__BackingFieldField;
            }
            set {
                if ((this.Idk__BackingFieldField.Equals(value) != true)) {
                    this.Idk__BackingFieldField = value;
                    this.RaisePropertyChanged("Idk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<PrivateKey>k__BackingField", IsRequired=true)]
        public string PrivateKeyk__BackingField {
            get {
                return this.PrivateKeyk__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.PrivateKeyk__BackingFieldField, value) != true)) {
                    this.PrivateKeyk__BackingFieldField = value;
                    this.RaisePropertyChanged("PrivateKeyk__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<Txn>k__BackingField", IsRequired=true)]
        public string Txnk__BackingField {
            get {
                return this.Txnk__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.Txnk__BackingFieldField, value) != true)) {
                    this.Txnk__BackingFieldField = value;
                    this.RaisePropertyChanged("Txnk__BackingField");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="atm.IAtm")]
    public interface IAtm {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/CreatePublicEncryptedPrivateKey", ReplyAction="http://tempuri.org/IAtm/CreatePublicEncryptedPrivateKeyResponse")]
        TestHarness.atm.Keys CreatePublicEncryptedPrivateKey();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/CreatePublicEncryptedPrivateKey", ReplyAction="http://tempuri.org/IAtm/CreatePublicEncryptedPrivateKeyResponse")]
        System.Threading.Tasks.Task<TestHarness.atm.Keys> CreatePublicEncryptedPrivateKeyAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/CreateOrder", ReplyAction="http://tempuri.org/IAtm/CreateOrderResponse")]
        TestHarness.atm.Order CreateOrder(string publicKey, decimal btc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/CreateOrder", ReplyAction="http://tempuri.org/IAtm/CreateOrderResponse")]
        System.Threading.Tasks.Task<TestHarness.atm.Order> CreateOrderAsync(string publicKey, decimal btc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/SendBitcoins", ReplyAction="http://tempuri.org/IAtm/SendBitcoinsResponse")]
        string SendBitcoins(decimal amount, string bitcoinAddress);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/SendBitcoins", ReplyAction="http://tempuri.org/IAtm/SendBitcoinsResponse")]
        System.Threading.Tasks.Task<string> SendBitcoinsAsync(decimal amount, string bitcoinAddress);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/GetBitcoinAmount", ReplyAction="http://tempuri.org/IAtm/GetBitcoinAmountResponse")]
        decimal GetBitcoinAmount(decimal value, string currencyCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/GetBitcoinAmount", ReplyAction="http://tempuri.org/IAtm/GetBitcoinAmountResponse")]
        System.Threading.Tasks.Task<decimal> GetBitcoinAmountAsync(decimal value, string currencyCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/GetBalance", ReplyAction="http://tempuri.org/IAtm/GetBalanceResponse")]
        decimal GetBalance(string address, short confirmations);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/GetBalance", ReplyAction="http://tempuri.org/IAtm/GetBalanceResponse")]
        System.Threading.Tasks.Task<decimal> GetBalanceAsync(string address, short confirmations);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/AddCard", ReplyAction="http://tempuri.org/IAtm/AddCardResponse")]
        bool AddCard(string CardId, string PublicKey, string Password, string PinNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/AddCard", ReplyAction="http://tempuri.org/IAtm/AddCardResponse")]
        System.Threading.Tasks.Task<bool> AddCardAsync(string CardId, string PublicKey, string Password, string PinNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/isCardOnFile", ReplyAction="http://tempuri.org/IAtm/isCardOnFileResponse")]
        bool isCardOnFile(string CardId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/isCardOnFile", ReplyAction="http://tempuri.org/IAtm/isCardOnFileResponse")]
        System.Threading.Tasks.Task<bool> isCardOnFileAsync(string CardId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/WriteTransaction", ReplyAction="http://tempuri.org/IAtm/WriteTransactionResponse")]
        TestHarness.atm.WriteTransactionResponse WriteTransaction(TestHarness.atm.WriteTransactionRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/WriteTransaction", ReplyAction="http://tempuri.org/IAtm/WriteTransactionResponse")]
        System.Threading.Tasks.Task<TestHarness.atm.WriteTransactionResponse> WriteTransactionAsync(TestHarness.atm.WriteTransactionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/CreateaPayment", ReplyAction="http://tempuri.org/IAtm/CreateaPaymentResponse")]
        bool CreateaPayment(string PaymentProvider);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/CreateaPayment", ReplyAction="http://tempuri.org/IAtm/CreateaPaymentResponse")]
        System.Threading.Tasks.Task<bool> CreateaPaymentAsync(string PaymentProvider);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/GetMargin", ReplyAction="http://tempuri.org/IAtm/GetMarginResponse")]
        TestHarness.atm.GetMarginResponse GetMargin(TestHarness.atm.GetMarginRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/GetMargin", ReplyAction="http://tempuri.org/IAtm/GetMarginResponse")]
        System.Threading.Tasks.Task<TestHarness.atm.GetMarginResponse> GetMarginAsync(TestHarness.atm.GetMarginRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/CreateOnlineAccount", ReplyAction="http://tempuri.org/IAtm/CreateOnlineAccountResponse")]
        TestHarness.atm.CreateOnlineAccountResponse CreateOnlineAccount(TestHarness.atm.CreateOnlineAccountRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAtm/CreateOnlineAccount", ReplyAction="http://tempuri.org/IAtm/CreateOnlineAccountResponse")]
        System.Threading.Tasks.Task<TestHarness.atm.CreateOnlineAccountResponse> CreateOnlineAccountAsync(TestHarness.atm.CreateOnlineAccountRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WriteTransaction", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class WriteTransactionRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string CardId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string TransType;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string TerminalId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public string NumuratorCurrency;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=4)]
        public string DenominatorCurrency;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=5)]
        public decimal Amount;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=6)]
        public decimal Price;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=7)]
        public string Reference;
        
        public WriteTransactionRequest() {
        }
        
        public WriteTransactionRequest(string CardId, string TransType, string TerminalId, string NumuratorCurrency, string DenominatorCurrency, decimal Amount, decimal Price, string Reference) {
            this.CardId = CardId;
            this.TransType = TransType;
            this.TerminalId = TerminalId;
            this.NumuratorCurrency = NumuratorCurrency;
            this.DenominatorCurrency = DenominatorCurrency;
            this.Amount = Amount;
            this.Price = Price;
            this.Reference = Reference;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="WriteTransactionResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class WriteTransactionResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public bool WriteTransactionResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public int TransactionID;
        
        public WriteTransactionResponse() {
        }
        
        public WriteTransactionResponse(bool WriteTransactionResult, int TransactionID) {
            this.WriteTransactionResult = WriteTransactionResult;
            this.TransactionID = TransactionID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetMargin", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetMarginRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string TerminalId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string Currency;
        
        public GetMarginRequest() {
        }
        
        public GetMarginRequest(string TerminalId, string Currency) {
            this.TerminalId = TerminalId;
            this.Currency = Currency;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetMarginResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetMarginResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public bool GetMarginResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public decimal BuyMargin;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public decimal SellMargin;
        
        public GetMarginResponse() {
        }
        
        public GetMarginResponse(bool GetMarginResult, decimal BuyMargin, decimal SellMargin) {
            this.GetMarginResult = GetMarginResult;
            this.BuyMargin = BuyMargin;
            this.SellMargin = SellMargin;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CreateOnlineAccount", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class CreateOnlineAccountRequest {
        
        public CreateOnlineAccountRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CreateOnlineAccountResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class CreateOnlineAccountResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public bool CreateOnlineAccountResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string Username;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string Password;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public string ConfirmToken;
        
        public CreateOnlineAccountResponse() {
        }
        
        public CreateOnlineAccountResponse(bool CreateOnlineAccountResult, string Username, string Password, string ConfirmToken) {
            this.CreateOnlineAccountResult = CreateOnlineAccountResult;
            this.Username = Username;
            this.Password = Password;
            this.ConfirmToken = ConfirmToken;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAtmChannel : TestHarness.atm.IAtm, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AtmClient : System.ServiceModel.ClientBase<TestHarness.atm.IAtm>, TestHarness.atm.IAtm {
        
        public AtmClient() {
        }
        
        public AtmClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AtmClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AtmClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AtmClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TestHarness.atm.Keys CreatePublicEncryptedPrivateKey() {
            return base.Channel.CreatePublicEncryptedPrivateKey();
        }
        
        public System.Threading.Tasks.Task<TestHarness.atm.Keys> CreatePublicEncryptedPrivateKeyAsync() {
            return base.Channel.CreatePublicEncryptedPrivateKeyAsync();
        }
        
        public TestHarness.atm.Order CreateOrder(string publicKey, decimal btc) {
            return base.Channel.CreateOrder(publicKey, btc);
        }
        
        public System.Threading.Tasks.Task<TestHarness.atm.Order> CreateOrderAsync(string publicKey, decimal btc) {
            return base.Channel.CreateOrderAsync(publicKey, btc);
        }
        
        public string SendBitcoins(decimal amount, string bitcoinAddress) {
            return base.Channel.SendBitcoins(amount, bitcoinAddress);
        }
        
        public System.Threading.Tasks.Task<string> SendBitcoinsAsync(decimal amount, string bitcoinAddress) {
            return base.Channel.SendBitcoinsAsync(amount, bitcoinAddress);
        }
        
        public decimal GetBitcoinAmount(decimal value, string currencyCode) {
            return base.Channel.GetBitcoinAmount(value, currencyCode);
        }
        
        public System.Threading.Tasks.Task<decimal> GetBitcoinAmountAsync(decimal value, string currencyCode) {
            return base.Channel.GetBitcoinAmountAsync(value, currencyCode);
        }
        
        public decimal GetBalance(string address, short confirmations) {
            return base.Channel.GetBalance(address, confirmations);
        }
        
        public System.Threading.Tasks.Task<decimal> GetBalanceAsync(string address, short confirmations) {
            return base.Channel.GetBalanceAsync(address, confirmations);
        }
        
        public bool AddCard(string CardId, string PublicKey, string Password, string PinNumber) {
            return base.Channel.AddCard(CardId, PublicKey, Password, PinNumber);
        }
        
        public System.Threading.Tasks.Task<bool> AddCardAsync(string CardId, string PublicKey, string Password, string PinNumber) {
            return base.Channel.AddCardAsync(CardId, PublicKey, Password, PinNumber);
        }
        
        public bool isCardOnFile(string CardId) {
            return base.Channel.isCardOnFile(CardId);
        }
        
        public System.Threading.Tasks.Task<bool> isCardOnFileAsync(string CardId) {
            return base.Channel.isCardOnFileAsync(CardId);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TestHarness.atm.WriteTransactionResponse TestHarness.atm.IAtm.WriteTransaction(TestHarness.atm.WriteTransactionRequest request) {
            return base.Channel.WriteTransaction(request);
        }
        
        public bool WriteTransaction(string CardId, string TransType, string TerminalId, string NumuratorCurrency, string DenominatorCurrency, decimal Amount, decimal Price, string Reference, out int TransactionID) {
            TestHarness.atm.WriteTransactionRequest inValue = new TestHarness.atm.WriteTransactionRequest();
            inValue.CardId = CardId;
            inValue.TransType = TransType;
            inValue.TerminalId = TerminalId;
            inValue.NumuratorCurrency = NumuratorCurrency;
            inValue.DenominatorCurrency = DenominatorCurrency;
            inValue.Amount = Amount;
            inValue.Price = Price;
            inValue.Reference = Reference;
            TestHarness.atm.WriteTransactionResponse retVal = ((TestHarness.atm.IAtm)(this)).WriteTransaction(inValue);
            TransactionID = retVal.TransactionID;
            return retVal.WriteTransactionResult;
        }
        
        public System.Threading.Tasks.Task<TestHarness.atm.WriteTransactionResponse> WriteTransactionAsync(TestHarness.atm.WriteTransactionRequest request) {
            return base.Channel.WriteTransactionAsync(request);
        }
        
        public bool CreateaPayment(string PaymentProvider) {
            return base.Channel.CreateaPayment(PaymentProvider);
        }
        
        public System.Threading.Tasks.Task<bool> CreateaPaymentAsync(string PaymentProvider) {
            return base.Channel.CreateaPaymentAsync(PaymentProvider);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TestHarness.atm.GetMarginResponse TestHarness.atm.IAtm.GetMargin(TestHarness.atm.GetMarginRequest request) {
            return base.Channel.GetMargin(request);
        }
        
        public bool GetMargin(string TerminalId, string Currency, out decimal BuyMargin, out decimal SellMargin) {
            TestHarness.atm.GetMarginRequest inValue = new TestHarness.atm.GetMarginRequest();
            inValue.TerminalId = TerminalId;
            inValue.Currency = Currency;
            TestHarness.atm.GetMarginResponse retVal = ((TestHarness.atm.IAtm)(this)).GetMargin(inValue);
            BuyMargin = retVal.BuyMargin;
            SellMargin = retVal.SellMargin;
            return retVal.GetMarginResult;
        }
        
        public System.Threading.Tasks.Task<TestHarness.atm.GetMarginResponse> GetMarginAsync(TestHarness.atm.GetMarginRequest request) {
            return base.Channel.GetMarginAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TestHarness.atm.CreateOnlineAccountResponse TestHarness.atm.IAtm.CreateOnlineAccount(TestHarness.atm.CreateOnlineAccountRequest request) {
            return base.Channel.CreateOnlineAccount(request);
        }
        
        public bool CreateOnlineAccount(out string Username, out string Password, out string ConfirmToken) {
            TestHarness.atm.CreateOnlineAccountRequest inValue = new TestHarness.atm.CreateOnlineAccountRequest();
            TestHarness.atm.CreateOnlineAccountResponse retVal = ((TestHarness.atm.IAtm)(this)).CreateOnlineAccount(inValue);
            Username = retVal.Username;
            Password = retVal.Password;
            ConfirmToken = retVal.ConfirmToken;
            return retVal.CreateOnlineAccountResult;
        }
        
        public System.Threading.Tasks.Task<TestHarness.atm.CreateOnlineAccountResponse> CreateOnlineAccountAsync(TestHarness.atm.CreateOnlineAccountRequest request) {
            return base.Channel.CreateOnlineAccountAsync(request);
        }
    }
}
