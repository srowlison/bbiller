﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestConsole.srLocal {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Keys", Namespace="http://schemas.datacontract.org/2004/07/DC.Common.Models")]
    [System.SerializableAttribute()]
    public partial class Keys : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] EncryptedWIFPrivateKeyField;
        
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
        public byte[] EncryptedWIFPrivateKey {
            get {
                return this.EncryptedWIFPrivateKeyField;
            }
            set {
                if ((object.ReferenceEquals(this.EncryptedWIFPrivateKeyField, value) != true)) {
                    this.EncryptedWIFPrivateKeyField = value;
                    this.RaisePropertyChanged("EncryptedWIFPrivateKey");
                }
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Order", Namespace="http://schemas.datacontract.org/2004/07/DC.Common.Models")]
    [System.SerializableAttribute()]
    public partial class Order : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string Addressk__BackingFieldField;
        
        private decimal BTCk__BackingFieldField;
        
        private System.Guid Idk__BackingFieldField;
        
        private string PrivateKeyAsBase64k__BackingFieldField;
        
        private byte[] PrivateKeyAsByteArrayk__BackingFieldField;
        
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
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<PrivateKeyAsBase64>k__BackingField", IsRequired=true)]
        public string PrivateKeyAsBase64k__BackingField {
            get {
                return this.PrivateKeyAsBase64k__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.PrivateKeyAsBase64k__BackingFieldField, value) != true)) {
                    this.PrivateKeyAsBase64k__BackingFieldField = value;
                    this.RaisePropertyChanged("PrivateKeyAsBase64k__BackingField");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Name="<PrivateKeyAsByteArray>k__BackingField", IsRequired=true)]
        public byte[] PrivateKeyAsByteArrayk__BackingField {
            get {
                return this.PrivateKeyAsByteArrayk__BackingFieldField;
            }
            set {
                if ((object.ReferenceEquals(this.PrivateKeyAsByteArrayk__BackingFieldField, value) != true)) {
                    this.PrivateKeyAsByteArrayk__BackingFieldField = value;
                    this.RaisePropertyChanged("PrivateKeyAsByteArrayk__BackingField");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="https://node.diamondcircle.net", ConfigurationName="srLocal.IAtm")]
    public interface IAtm {
        
        [System.ServiceModel.OperationContractAttribute(Action="https://node.diamondcircle.net/IAtm/CreatePublicEncryptedPrivateKey", ReplyAction="https://node.diamondcircle.net/IAtm/CreatePublicEncryptedPrivateKeyResponse")]
        TestConsole.srLocal.Keys CreatePublicEncryptedPrivateKey();
        
        [System.ServiceModel.OperationContractAttribute(Action="https://node.diamondcircle.net/IAtm/CreatePublicEncryptedPrivateKey", ReplyAction="https://node.diamondcircle.net/IAtm/CreatePublicEncryptedPrivateKeyResponse")]
        System.Threading.Tasks.Task<TestConsole.srLocal.Keys> CreatePublicEncryptedPrivateKeyAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="https://node.diamondcircle.net/IAtm/CreateOrder", ReplyAction="https://node.diamondcircle.net/IAtm/CreateOrderResponse")]
        TestConsole.srLocal.Order CreateOrder(string publicKey, decimal btc);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://node.diamondcircle.net/IAtm/CreateOrder", ReplyAction="https://node.diamondcircle.net/IAtm/CreateOrderResponse")]
        System.Threading.Tasks.Task<TestConsole.srLocal.Order> CreateOrderAsync(string publicKey, decimal btc);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://node.diamondcircle.net/IAtm/SendBitcoins", ReplyAction="https://node.diamondcircle.net/IAtm/SendBitcoinsResponse")]
        string SendBitcoins(decimal amount, string bitcoinAddress);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://node.diamondcircle.net/IAtm/SendBitcoins", ReplyAction="https://node.diamondcircle.net/IAtm/SendBitcoinsResponse")]
        System.Threading.Tasks.Task<string> SendBitcoinsAsync(decimal amount, string bitcoinAddress);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://node.diamondcircle.net/IAtm/SendBitcoins2", ReplyAction="https://node.diamondcircle.net/IAtm/SendBitcoins2Response")]
        void SendBitcoins2(string privateKey, string destinationAddress, decimal amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://node.diamondcircle.net/IAtm/SendBitcoins2", ReplyAction="https://node.diamondcircle.net/IAtm/SendBitcoins2Response")]
        System.Threading.Tasks.Task SendBitcoins2Async(string privateKey, string destinationAddress, decimal amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://node.diamondcircle.net/IAtm/GetBitcoinAmount", ReplyAction="https://node.diamondcircle.net/IAtm/GetBitcoinAmountResponse")]
        decimal GetBitcoinAmount(decimal value, string currencyCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://node.diamondcircle.net/IAtm/GetBitcoinAmount", ReplyAction="https://node.diamondcircle.net/IAtm/GetBitcoinAmountResponse")]
        System.Threading.Tasks.Task<decimal> GetBitcoinAmountAsync(decimal value, string currencyCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://node.diamondcircle.net/IAtm/GetBalance", ReplyAction="https://node.diamondcircle.net/IAtm/GetBalanceResponse")]
        decimal GetBalance(string bitcoinAddress, short confirmations);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://node.diamondcircle.net/IAtm/GetBalance", ReplyAction="https://node.diamondcircle.net/IAtm/GetBalanceResponse")]
        System.Threading.Tasks.Task<decimal> GetBalanceAsync(string bitcoinAddress, short confirmations);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAtmChannel : TestConsole.srLocal.IAtm, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AtmClient : System.ServiceModel.ClientBase<TestConsole.srLocal.IAtm>, TestConsole.srLocal.IAtm {
        
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
        
        public TestConsole.srLocal.Keys CreatePublicEncryptedPrivateKey() {
            return base.Channel.CreatePublicEncryptedPrivateKey();
        }
        
        public System.Threading.Tasks.Task<TestConsole.srLocal.Keys> CreatePublicEncryptedPrivateKeyAsync() {
            return base.Channel.CreatePublicEncryptedPrivateKeyAsync();
        }
        
        public TestConsole.srLocal.Order CreateOrder(string publicKey, decimal btc) {
            return base.Channel.CreateOrder(publicKey, btc);
        }
        
        public System.Threading.Tasks.Task<TestConsole.srLocal.Order> CreateOrderAsync(string publicKey, decimal btc) {
            return base.Channel.CreateOrderAsync(publicKey, btc);
        }
        
        public string SendBitcoins(decimal amount, string bitcoinAddress) {
            return base.Channel.SendBitcoins(amount, bitcoinAddress);
        }
        
        public System.Threading.Tasks.Task<string> SendBitcoinsAsync(decimal amount, string bitcoinAddress) {
            return base.Channel.SendBitcoinsAsync(amount, bitcoinAddress);
        }
        
        public void SendBitcoins2(string privateKey, string destinationAddress, decimal amount) {
            base.Channel.SendBitcoins2(privateKey, destinationAddress, amount);
        }
        
        public System.Threading.Tasks.Task SendBitcoins2Async(string privateKey, string destinationAddress, decimal amount) {
            return base.Channel.SendBitcoins2Async(privateKey, destinationAddress, amount);
        }
        
        public decimal GetBitcoinAmount(decimal value, string currencyCode) {
            return base.Channel.GetBitcoinAmount(value, currencyCode);
        }
        
        public System.Threading.Tasks.Task<decimal> GetBitcoinAmountAsync(decimal value, string currencyCode) {
            return base.Channel.GetBitcoinAmountAsync(value, currencyCode);
        }
        
        public decimal GetBalance(string bitcoinAddress, short confirmations) {
            return base.Channel.GetBalance(bitcoinAddress, confirmations);
        }
        
        public System.Threading.Tasks.Task<decimal> GetBalanceAsync(string bitcoinAddress, short confirmations) {
            return base.Channel.GetBalanceAsync(bitcoinAddress, confirmations);
        }
    }
}
