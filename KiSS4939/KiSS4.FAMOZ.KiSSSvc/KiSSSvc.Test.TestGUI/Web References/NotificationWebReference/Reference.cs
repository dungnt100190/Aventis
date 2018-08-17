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

namespace KiSSSvc.Test.TestGUI.NotificationWebReference {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="NotificationSvcSoap", Namespace="http://www.born.ch/KiSS/FAMOZ/PSCD/")]
    public partial class NotificationSvc : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback NotifyAboutSAPDataReadyOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public NotificationSvc() {
            this.Url = global::KiSSSvc.Test.TestGUI.Properties.Settings.Default.KiSSSvc_Test_TestGUI_NotificationWebReference_NotificationSvc;
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
        public event NotifyAboutSAPDataReadyCompletedEventHandler NotifyAboutSAPDataReadyCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.born.ch/KiSS/FAMOZ/PSCD/NotifyAboutSAPDataReady", RequestNamespace="http://www.born.ch/KiSS/FAMOZ/PSCD/", ResponseNamespace="http://www.born.ch/KiSS/FAMOZ/PSCD/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string NotifyAboutSAPDataReady(string type, int id) {
            object[] results = this.Invoke("NotifyAboutSAPDataReady", new object[] {
                        type,
                        id});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void NotifyAboutSAPDataReadyAsync(string type, int id) {
            this.NotifyAboutSAPDataReadyAsync(type, id, null);
        }
        
        /// <remarks/>
        public void NotifyAboutSAPDataReadyAsync(string type, int id, object userState) {
            if ((this.NotifyAboutSAPDataReadyOperationCompleted == null)) {
                this.NotifyAboutSAPDataReadyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnNotifyAboutSAPDataReadyOperationCompleted);
            }
            this.InvokeAsync("NotifyAboutSAPDataReady", new object[] {
                        type,
                        id}, this.NotifyAboutSAPDataReadyOperationCompleted, userState);
        }
        
        private void OnNotifyAboutSAPDataReadyOperationCompleted(object arg) {
            if ((this.NotifyAboutSAPDataReadyCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.NotifyAboutSAPDataReadyCompleted(this, new NotifyAboutSAPDataReadyCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void NotifyAboutSAPDataReadyCompletedEventHandler(object sender, NotifyAboutSAPDataReadyCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class NotifyAboutSAPDataReadyCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal NotifyAboutSAPDataReadyCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591