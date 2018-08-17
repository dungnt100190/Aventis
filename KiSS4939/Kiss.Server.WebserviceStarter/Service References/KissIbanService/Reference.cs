﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kiss.Server.WebserviceStarter.KissIbanService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="KissIbanService.IKissIbanService")]
    public interface IKissIbanService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKissIbanService/ConvertToIban", ReplyAction="http://tempuri.org/IKissIbanService/ConvertToIbanResponse")]
        string ConvertToIban(string kontoNr, string clearingNr);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKissIbanService/GetServerVersion", ReplyAction="http://tempuri.org/IKissIbanService/GetServerVersionResponse")]
        string GetServerVersion();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IKissIbanService/TestIbanWebservice", ReplyAction="http://tempuri.org/IKissIbanService/TestIbanWebserviceResponse")]
        string TestIbanWebservice(string kontoNr, string clearingNr);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IKissIbanServiceChannel : Kiss.Server.WebserviceStarter.KissIbanService.IKissIbanService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class KissIbanServiceClient : System.ServiceModel.ClientBase<Kiss.Server.WebserviceStarter.KissIbanService.IKissIbanService>, Kiss.Server.WebserviceStarter.KissIbanService.IKissIbanService {
        
        public KissIbanServiceClient() {
        }
        
        public KissIbanServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public KissIbanServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KissIbanServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KissIbanServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string ConvertToIban(string kontoNr, string clearingNr) {
            return base.Channel.ConvertToIban(kontoNr, clearingNr);
        }
        
        public string GetServerVersion() {
            return base.Channel.GetServerVersion();
        }
        
        public string TestIbanWebservice(string kontoNr, string clearingNr) {
            return base.Channel.TestIbanWebservice(kontoNr, clearingNr);
        }
    }
}
