﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kiss.Server.Einwohnerregister.OmegaDeRegistService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://stzh.ch/O13/eCH-0020/2.3", ConfigurationName="OmegaDeRegistService.SI_O13_deRegist_sync_ob")]
    public interface SI_O13_deRegist_sync_ob {
        
        // CODEGEN: Generating message contract since the operation SI_O13_deRegist_sync_ob is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://sap.com/xi/WebService/soap1.1", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Kiss.Server.Einwohnerregister.OmegaDeRegistService.SI_O13_deRegist_sync_obResponse SI_O13_deRegist_sync_ob(Kiss.Server.Einwohnerregister.OmegaDeRegistService.SI_O13_deRegist_sync_obRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.zuerich.ch/xmlns/eZH-0020/3")]
    public partial class deregistrationRequest : object, System.ComponentModel.INotifyPropertyChanged {
        
        private deregistrationRequestDeregistrationHeader deregistrationHeaderField;
        
        private deregistrationRequestDeregistrationBody deregistrationBodyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public deregistrationRequestDeregistrationHeader deregistrationHeader {
            get {
                return this.deregistrationHeaderField;
            }
            set {
                this.deregistrationHeaderField = value;
                this.RaisePropertyChanged("deregistrationHeader");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public deregistrationRequestDeregistrationBody deregistrationBody {
            get {
                return this.deregistrationBodyField;
            }
            set {
                this.deregistrationBodyField = value;
                this.RaisePropertyChanged("deregistrationBody");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.zuerich.ch/xmlns/eZH-0020/3")]
    public partial class deregistrationRequestDeregistrationHeader : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string techuserIdField;
        
        private string enduserIdField;
        
        private string enduserNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string techuserId {
            get {
                return this.techuserIdField;
            }
            set {
                this.techuserIdField = value;
                this.RaisePropertyChanged("techuserId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string enduserId {
            get {
                return this.enduserIdField;
            }
            set {
                this.enduserIdField = value;
                this.RaisePropertyChanged("enduserId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string enduserName {
            get {
                return this.enduserNameField;
            }
            set {
                this.enduserNameField = value;
                this.RaisePropertyChanged("enduserName");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.ech.ch/xmlns/eCH-0078/2")]
    public partial class infoType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string codeField;
        
        private string textEnglishField;
        
        private string textGermanField;
        
        private string textFrenchField;
        
        private string textItalianField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
                this.RaisePropertyChanged("code");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string textEnglish {
            get {
                return this.textEnglishField;
            }
            set {
                this.textEnglishField = value;
                this.RaisePropertyChanged("textEnglish");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string textGerman {
            get {
                return this.textGermanField;
            }
            set {
                this.textGermanField = value;
                this.RaisePropertyChanged("textGerman");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string textFrench {
            get {
                return this.textFrenchField;
            }
            set {
                this.textFrenchField = value;
                this.RaisePropertyChanged("textFrench");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string textItalian {
            get {
                return this.textItalianField;
            }
            set {
                this.textItalianField = value;
                this.RaisePropertyChanged("textItalian");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.zuerich.ch/xmlns/eZH-0020/3")]
    public partial class deregistrationPersonType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string personIdField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="token", Order=0)]
        public string personId {
            get {
                return this.personIdField;
            }
            set {
                this.personIdField = value;
                this.RaisePropertyChanged("personId");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.zuerich.ch/xmlns/eZH-0020/3")]
    public partial class deregistrationRequestDeregistrationBody : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string recipientIdField;
        
        private object[] itemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string recipientId {
            get {
                return this.recipientIdField;
            }
            set {
                this.recipientIdField = value;
                this.RaisePropertyChanged("recipientId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("person", typeof(deregistrationPersonType), Order=1)]
        [System.Xml.Serialization.XmlElementAttribute("personAll", typeof(yesNoType), Order=1)]
        public object[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
                this.RaisePropertyChanged("Items");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.ech.ch/xmlns/eCH-0011/4")]
    public enum yesNoType {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("0")]
        Item0,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SI_O13_deRegist_sync_obRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.zuerich.ch/xmlns/eZH-0020/3", Order=0)]
        public Kiss.Server.Einwohnerregister.OmegaDeRegistService.deregistrationRequest deregistrationRequest;
        
        public SI_O13_deRegist_sync_obRequest() {
        }
        
        public SI_O13_deRegist_sync_obRequest(Kiss.Server.Einwohnerregister.OmegaDeRegistService.deregistrationRequest deregistrationRequest) {
            this.deregistrationRequest = deregistrationRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SI_O13_deRegist_sync_obResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.zuerich.ch/xmlns/eZH-0020/3", Order=0)]
        [System.Xml.Serialization.XmlArrayItemAttribute("messages", IsNullable=false)]
        public Kiss.Server.Einwohnerregister.OmegaDeRegistService.infoType[] deregistrationResponse;
        
        public SI_O13_deRegist_sync_obResponse() {
        }
        
        public SI_O13_deRegist_sync_obResponse(Kiss.Server.Einwohnerregister.OmegaDeRegistService.infoType[] deregistrationResponse) {
            this.deregistrationResponse = deregistrationResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SI_O13_deRegist_sync_obChannel : Kiss.Server.Einwohnerregister.OmegaDeRegistService.SI_O13_deRegist_sync_ob, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SI_O13_deRegist_sync_obClient : System.ServiceModel.ClientBase<Kiss.Server.Einwohnerregister.OmegaDeRegistService.SI_O13_deRegist_sync_ob>, Kiss.Server.Einwohnerregister.OmegaDeRegistService.SI_O13_deRegist_sync_ob {
        
        public SI_O13_deRegist_sync_obClient() {
        }
        
        public SI_O13_deRegist_sync_obClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SI_O13_deRegist_sync_obClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SI_O13_deRegist_sync_obClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SI_O13_deRegist_sync_obClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Kiss.Server.Einwohnerregister.OmegaDeRegistService.SI_O13_deRegist_sync_obResponse Kiss.Server.Einwohnerregister.OmegaDeRegistService.SI_O13_deRegist_sync_ob.SI_O13_deRegist_sync_ob(Kiss.Server.Einwohnerregister.OmegaDeRegistService.SI_O13_deRegist_sync_obRequest request) {
            return base.Channel.SI_O13_deRegist_sync_ob(request);
        }
        
        public Kiss.Server.Einwohnerregister.OmegaDeRegistService.infoType[] SI_O13_deRegist_sync_ob(Kiss.Server.Einwohnerregister.OmegaDeRegistService.deregistrationRequest deregistrationRequest) {
            Kiss.Server.Einwohnerregister.OmegaDeRegistService.SI_O13_deRegist_sync_obRequest inValue = new Kiss.Server.Einwohnerregister.OmegaDeRegistService.SI_O13_deRegist_sync_obRequest();
            inValue.deregistrationRequest = deregistrationRequest;
            Kiss.Server.Einwohnerregister.OmegaDeRegistService.SI_O13_deRegist_sync_obResponse retVal = ((Kiss.Server.Einwohnerregister.OmegaDeRegistService.SI_O13_deRegist_sync_ob)(this)).SI_O13_deRegist_sync_ob(inValue);
            return retVal.deregistrationResponse;
        }
    }
}