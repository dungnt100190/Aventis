﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.34209.
// 
#pragma warning disable 1591

namespace KiSSSvc.SAP.PSCD.WebServiceHelper.WebReferences.Async.MahnlaufStarten {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="MI_KISS_ANSTOSS_MAHN_SOAP_OUTBinding", Namespace="http://STZH")]
    public partial class MI_KISS_ANSTOSS_MAHN_SOAP_OUTService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback MI_KISS_ANSTOSS_MAHN_SOAP_OUTOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public MI_KISS_ANSTOSS_MAHN_SOAP_OUTService() {
            this.Url = global::KiSSSvc.SAP.PSCD.WebServiceHelper.Properties.Settings.Default.KiSSSvc_SAP_PSCD_WebServiceHelper_WebReferences_Async_MahnlaufStarten_MI_KISS_ANSTOSS_MAHN_SOAP_OUTService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event MI_KISS_ANSTOSS_MAHN_SOAP_OUTCompletedEventHandler MI_KISS_ANSTOSS_MAHN_SOAP_OUTCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://sap.com/xi/WebService/soap1.1", RequestElementName="_-STZH_-KISS_ANSTOSS_MAHN_IN", RequestNamespace="urn:sap-com:document:sap:rfc:functions", OneWay=true, Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void MI_KISS_ANSTOSS_MAHN_SOAP_OUT([System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)] _STZH_S_KISS_ANSTOSS_MAHNLAUF I_MAHNLAUF) {
            this.Invoke("MI_KISS_ANSTOSS_MAHN_SOAP_OUT", new object[] {
                        I_MAHNLAUF});
        }
        
        /// <remarks/>
        public void MI_KISS_ANSTOSS_MAHN_SOAP_OUTAsync(_STZH_S_KISS_ANSTOSS_MAHNLAUF I_MAHNLAUF) {
            this.MI_KISS_ANSTOSS_MAHN_SOAP_OUTAsync(I_MAHNLAUF, null);
        }
        
        /// <remarks/>
        public void MI_KISS_ANSTOSS_MAHN_SOAP_OUTAsync(_STZH_S_KISS_ANSTOSS_MAHNLAUF I_MAHNLAUF, object userState) {
            if ((this.MI_KISS_ANSTOSS_MAHN_SOAP_OUTOperationCompleted == null)) {
                this.MI_KISS_ANSTOSS_MAHN_SOAP_OUTOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMI_KISS_ANSTOSS_MAHN_SOAP_OUTOperationCompleted);
            }
            this.InvokeAsync("MI_KISS_ANSTOSS_MAHN_SOAP_OUT", new object[] {
                        I_MAHNLAUF}, this.MI_KISS_ANSTOSS_MAHN_SOAP_OUTOperationCompleted, userState);
        }
        
        private void OnMI_KISS_ANSTOSS_MAHN_SOAP_OUTOperationCompleted(object arg) {
            if ((this.MI_KISS_ANSTOSS_MAHN_SOAP_OUTCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MI_KISS_ANSTOSS_MAHN_SOAP_OUTCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="_-STZH_-S_KISS_ANSTOSS_MAHNLAUF", Namespace="urn:sap-com:document:sap:rfc:functions")]
    public partial class _STZH_S_KISS_ANSTOSS_MAHNLAUF {
        
        private string lAUFDField;
        
        private string lAUFIField;
        
        private _STZH_S_BELEGE[] bELEGEField;
        
        private string aUSDATField;
        
        private string zAHLBERBISField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LAUFD {
            get {
                return this.lAUFDField;
            }
            set {
                this.lAUFDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LAUFI {
            get {
                return this.lAUFIField;
            }
            set {
                this.lAUFIField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public _STZH_S_BELEGE[] BELEGE {
            get {
                return this.bELEGEField;
            }
            set {
                this.bELEGEField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string AUSDAT {
            get {
                return this.aUSDATField;
            }
            set {
                this.aUSDATField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ZAHLBERBIS {
            get {
                return this.zAHLBERBISField;
            }
            set {
                this.zAHLBERBISField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34234")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="_-STZH_-S_BELEGE", Namespace="urn:sap-com:document:sap:rfc:functions")]
    public partial class _STZH_S_BELEGE {
        
        private string oPBELField;
        
        private string oPUPWField;
        
        private string oPUPKField;
        
        private string oPUPZField;
        
        private string mAHNSField;
        
        private string mAHNS_OLDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string OPBEL {
            get {
                return this.oPBELField;
            }
            set {
                this.oPBELField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string OPUPW {
            get {
                return this.oPUPWField;
            }
            set {
                this.oPUPWField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string OPUPK {
            get {
                return this.oPUPKField;
            }
            set {
                this.oPUPKField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string OPUPZ {
            get {
                return this.oPUPZField;
            }
            set {
                this.oPUPZField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string MAHNS {
            get {
                return this.mAHNSField;
            }
            set {
                this.mAHNSField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string MAHNS_OLD {
            get {
                return this.mAHNS_OLDField;
            }
            set {
                this.mAHNS_OLDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void MI_KISS_ANSTOSS_MAHN_SOAP_OUTCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591