-- Insert Script for ShVerfuegungMonatsbudget
-- MD5:0X1DF826A194910AE223985724399E97C8_0X1183CE4EAAA618CE459DB6D10D332D1A_0X3A2947CD8A08BF345F1EACC757A967A9
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'ShVerfuegungMonatsbudget') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('ShVerfuegungMonatsbudget', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'ShVerfuegungMonatsbudget';
UPDATE QRY
SET QueryName =  N'ShVerfuegungMonatsbudget' , UserText =  N'SH - Verfügung Monatsbudget' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>C:\Windows\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>en-US</Localization>
///   <References>
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraPrinting.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Drawing\2.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System\2.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Configuration\2.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Xml\2.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Data.SqlXml\2.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Security\2.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.Utils.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Utils.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Windows.Forms\2.0.0.0__b77a5c561934e089\System.Windows.Forms.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\Accessibility\2.0.0.0__b03f5f7f11d50a3a\Accessibility.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Runtime.Serialization.Formatters.Soap\2.0.0.0__b03f5f7f11d50a3a\System.Runtime.Serialization.Formatters.Soap.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Deployment\2.0.0.0__b03f5f7f11d50a3a\System.Deployment.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Design\2.0.0.0__b03f5f7f11d50a3a\System.Design.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_32\System.Data\2.0.0.0__b77a5c561934e089\System.Data.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\Microsoft.VisualC\8.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualC.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_32\System.Transactions\2.0.0.0__b77a5c561934e089\System.Transactions.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_32\System.EnterpriseServices\2.0.0.0__b03f5f7f11d50a3a\System.EnterpriseServices.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.DirectoryServices\2.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Runtime.Remoting\2.0.0.0__b77a5c561934e089\System.Runtime.Remoting.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_32\System.Web\2.0.0.0__b03f5f7f11d50a3a\System.Web.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Web.Services\2.0.0.0__b03f5f7f11d50a3a\System.Web.Services.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.DirectoryServices.Protocols\2.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.Protocols.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.ServiceProcess\2.0.0.0__b03f5f7f11d50a3a\System.ServiceProcess.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Configuration.Install\2.0.0.0__b03f5f7f11d50a3a\System.Configuration.Install.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Web.RegularExpressions\2.0.0.0__b03f5f7f11d50a3a\System.Web.RegularExpressions.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Drawing.Design\2.0.0.0__b03f5f7f11d50a3a\System.Drawing.Design.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_32\System.Data.OracleClient\2.0.0.0__b77a5c561934e089\System.Data.OracleClient.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraEditors.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.Data.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Data.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraBars.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraNavBar.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraCharts.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraRichTextEdit.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="C:\Program Files\KiSS\4.2.07\KiSS4.DB.dll" />
///     <Reference Path="C:\Program Files\KiSS\4.2.07\log4net.dll" />
///     <Reference Path="C:\Program Files\KiSS\4.2.07\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRRichTextBox rtfRechsmittel;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.Subreport ShVerfuegungMonatsbudget_EinAus;
        private DevExpress.XtraReports.UI.Subreport ShVerfuegungMonatsbudget_Personen;
        private DevExpress.XtraReports.UI.XRRichTextBox xrRichTextBox1;
        private DevExpress.XtraReports.UI.XRLabel txtFehlbetrag;
        private DevExpress.XtraReports.UI.XRLabel Label25;
        private DevExpress.XtraReports.UI.XRLabel Label24;
        private DevExpress.XtraReports.UI.XRLabel Label23;
        private DevExpress.XtraReports.UI.XRLabel txtTotOut;
        private DevExpress.XtraReports.UI.XRLabel txtTotIn;
        private DevExpress.XtraReports.UI.XRLine Line13;
        private DevExpress.XtraReports.UI.XRLine Line12;
        private DevExpress.XtraReports.UI.XRLine Line11;
        private DevExpress.XtraReports.UI.XRLine Line10;
        private DevExpress.XtraReports.UI.XRLabel Label12;
        private DevExpress.XtraReports.UI.XRLabel Label11;
        private DevExpress.XtraReports.UI.XRLabel txtAnrede;
        private DevExpress.XtraReports.UI.XRLine Line8;
        private DevExpress.XtraReports.UI.XRLine Line7;
        private DevExpress.XtraReports.UI.XRLine Line6;
        private DevExpress.XtraReports.UI.XRLine Line4;
        private DevExpress.XtraReports.UI.XRLabel Label9;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLabel Label8;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.XRLabel Label5;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.XRLabel Label3;
        private DevExpress.XtraReports.UI.XRLabel Label2;
        private DevExpress.XtraReports.UI.XRLabel txtTitle;
        private DevExpress.XtraReports.UI.XRRichTextBox rtfHinweis;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAAEAAAAAQAAAIwBRGV2RXhwcmVzc" +
                        "y5YdHJhUmVwb3J0cy5VSS5TZXJpYWxpemFibGVTdHJpbmcsIERldkV4cHJlc3MuWHRyYVJlcG9ydHMud" +
                        "jYuMiwgVmVyc2lvbj02LjIuNi4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPTc5ODY4Y" +
                        "jgxNDdiNWVhZTRQE7ROpJW/u7pU4BDdUf5/AloAAACRAAAAKQAAAAAAAAAeAgAAJHIAdABmAEgAaQBuA" +
                        "HcAZQBpAHMALgBSAHQAZgBUAGUAeAB0AAAAAAAscgB0AGYAUgBlAGMAaABzAG0AaQB0AHQAZQBsAC4AU" +
                        "gB0AGYAVABlAHgAdABwAgAAMnMAcQBsAFEAdQBlAHIAeQAxAC4AUwBlAGwAZQBjAHQAUwB0AGEAdABlA" +
                        "G0AZQBuAHQA9QQAACx4AHIAUgBpAGMAaABUAGUAeAB0AEIAbwB4ADEALgBSAHQAZgBUAGUAeAB0AMcPA" +
                        "ABAAAEAAAD/////AQAAAAAAAAAMAgAAABtEZXZFeHByZXNzLlh0cmFSZXBvcnRzLnY2LjIFAQAAACxEZ" +
                        "XZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlNlcmlhbGl6YWJsZVN0cmluZwEAAAAFVmFsdWUBAgAAAAYDA" +
                        "AAA9AN7XHJ0ZjFcYW5zaVxhbnNpY3BnMTI1MlxkZWZmMFxkZWZsYW5nMjA1NXtcZm9udHRibHtcZjBcZ" +
                        "m5pbFxmY2hhcnNldDAgQXJpYWw7fXtcZjFcZm5pbFxmY2hhcnNldDAgTWljcm9zb2Z0IFNhbnMgU2Vya" +
                        "WY7fX0NClx2aWV3a2luZDRcdWMxXHBhcmRcZnMyMCBEYXMgQnVkZ2V0IGJhc2llcnQgYXVmIGRlbSBGa" +
                        "W5hbnpwbGFuIHZvbSBcezA6ZFx9IGRlciBuYWNoIGRlbiBTS09TLVJpY2h0bGluaWVuIGVyc3RlbGx0I" +
                        "Hd1cmRlLiBJbnRlZ3JhdGlvbnN6dWxhZ2VuIGdlbVwnZTRzcyBBcnQuIDhhIFNvemlhbGhpbGZldmVyb" +
                        "3JkbnVuZyAoU0hWKSBiencuIEVpbmtvbW1lbnNmcmVpYmV0clwnZTRnZSBnZW1cJ2U0c3MgQXJ0LiA4Y" +
                        "yBTSFYgd2VyZGVuIGF1c2dlcmljaHRldCwgZmFsbHMgZGllIHVudGVyc3RcJ2ZjdHp0ZShuKSBQZXJzb" +
                        "24oZW4pIGRpZSByZWNodGxpY2hlbiBWb3JhdXNzZXR6dW5nZW4gaW0gVm9ybW9uYXQgZXJmXCdmY2xsd" +
                        "CBoYWJlbi5cZjFcZnMxN1xwYXINCn0NCgtAAAEAAAD/////AQAAAAAAAAAMAgAAABtEZXZFeHByZXNzL" +
                        "lh0cmFSZXBvcnRzLnY2LjIFAQAAACxEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlNlcmlhbGl6YWJsZ" +
                        "VN0cmluZwEAAAAFVmFsdWUBAgAAAAYDAAAAiQR7XHJ0ZjFcYW5zaVxhbnNpY3BnMTI1MlxkZWZmMFxkZ" +
                        "WZsYW5nMjA1NXtcZm9udHRibHtcZjBcZm5pbFxmY2hhcnNldDAgQXJpYWw7fXtcZjFcZm5pbFxmY2hhc" +
                        "nNldDAgTWljcm9zb2Z0IFNhbnMgU2VyaWY7fX0NClx2aWV3a2luZDRcdWMxXHBhcmRcYlxmczE4IFJlY" +
                        "2h0c21pdHRlbGJlbGVocnVuZzpcYjAgIEdlbVwnZTRzcyBBcnQuIDUyIEFicy4gMSBkZXMgR2VzZXR6Z" +
                        "XMgXCdmY2JlciBkaWUgXCdmNmZmZW50bGljaGUgU296aWFsaGlsZmUgdm9tIDExLiBKdW5pIDIwMDEgd" +
                        "W5kIGdlbVwnZTRzcyBBcnQuIDY3IEFicy4gMSBkZXMgVlJQRyAoVmVyd2FsdHVuZ3NyZWNodHNwZmxlZ" +
                        "2VnZXNldHopIHZvbSAyMy41LjE5OTgga2FubiBpbm5lcnQgMzAgVGFnZW4gZ2VnZW4gZGllc2VuIEJlc" +
                        "2NobHVzcyBiZWltIFJlZ2llcnVuZ3NzdGF0dGhhbHRlcmFtdCBGcmF1YnJ1bm5lbiwgQmVybnN0cmFzc" +
                        "2UgNSwgMzMxMiBGcmF1YnJ1bm5lbiwgQmVzY2h3ZXJkZSBnZWZcJ2ZjaHJ0IHdlcmRlbi5cZjFcZnMxN" +
                        "1xwYXINCn0NCgsBzxUtLSBQYXJhbWV0ZXINCkRFQ0xBUkUgQEdldERhdGUgREFURVRJTUU7DQpTRVQgQ" +
                        "EdldERhdGUgPSBHRVREQVRFKCk7DQoNCkRFQ0xBUkUgQE5MIFZBUkNIQVIoMik7DQpTRVQgQE5MID0gQ" +
                        "0hBUigxMykgKyBDSEFSKDEwKTsNCg0KREVDTEFSRSBAVG90SW4gTU9ORVk7DQpERUNMQVJFIEBUb3RPd" +
                        "XQgTU9ORVk7DQoNCg0KU0VMRUNUIEBUb3RJbiA9IFNVTShCZXRyYWcpDQpGUk9NIGRiby5mbldoR2V0R" +
                        "mluYW56cGxhbihudWxsLCBAR2V0RGF0ZSkNCldIRVJFIEJnS2F0ZWdvcmllQ29kZSA9IDE7DQoNCg0KU" +
                        "0VMRUNUIEBUb3RPdXQgPSBTVU0oQmV0cmFnKQ0KRlJPTSBkYm8uZm5XaEdldEZpbmFuenBsYW4obnVsb" +
                        "CwgQEdldERhdGUpDQpXSEVSRSBCZ0thdGVnb3JpZUNvZGUgPSAyOw0KDQoNCkRFQ0xBUkUgQEJlbWVya" +
                        "3VuZyAgVkFSQ0hBUig4MDAwKTsNCkRFQ0xBUkUgQEl0ZW1UZXh0ICAgVkFSQ0hBUig4MDAwKTsNCg0KR" +
                        "EVDTEFSRSBjQmVtZXJrdW5nIENVUlNPUiBGQVNUX0ZPUldBUkQgRk9SDQogIFNFTEVDVCAnLSAnICsgW" +
                        "ExDLlRleHQgKyAnICgnICsgUFJTLk5hbWUgKyBJU05VTEwoJywgJyArIFBSUy5Wb3JuYW1lLCAnJykgK" +
                        "yAnKTogJyArDQogICAgQ09OVkVSVChWQVJDSEFSKDgwMDApLCBCUE8uQmVtZXJrdW5nKQ0KICBGUk9NI" +
                        "EJnUG9zaXRpb24gICAgICAgICAgICAgQlBPDQogICAgSU5ORVIgSk9JTiBCYVBlcnNvbiAgICAgICBQU" +
                        "lMgT04gUFJTLkJhUGVyc29uSUQgPSBCUE8uQmFQZXJzb25JRA0KICAgIElOTkVSIEpPSU4gV2hQb3Npd" +
                        "GlvbnNhcnQgU1BUIE9OIFNQVC5CZ1Bvc2l0aW9uc2FydElEID0gQlBPLkJnUG9zaXRpb25zYXJ0SUQNC" +
                        "iAgICBJTk5FUiBKT0lOIFhMT1ZDb2RlICAgICAgIFhMQyBPTiBYTEMuTE9WTmFtZSA9ICdCZ0dydXBwZ" +
                        "ScNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBYTEMuQ29kZSA9IFNQVC5CZ0dyd" +
                        "XBwZUNvZGUNCiAgV0hFUkUgQlBPLkJnQnVkZ2V0SUQgPSBudWxsDQogICAgQU5EIEJQTy5CZ1Bvc2l0a" +
                        "W9uc2FydElEIEJFVFdFRU4gMzkwMDAgQU5EIDM5OTk5DQogICAgQU5EIE5VTExJRihCUE8uQmVtZXJrd" +
                        "W5nLCAnJykgSVMgTk9UIE5VTEwNCiAgICBBTkQgR2V0RGF0ZSgpIEJFVFdFRU4gSVNOVUxMKEJQTy5EY" +
                        "XR1bVZvbiwgJzE5MDAwMTAxJykgQU5EIElTTlVMTChCUE8uRGF0dW1CaXMsIEdldERhdGUoKSkNCiAgT" +
                        "1JERVIgQlkgUFJTLk5hbWUsIFBSUy5Wb3JuYW1lOw0KDQpPUEVOIGNCZW1lcmt1bmc7DQpXSElMRSAoM" +
                        "SA9IDEpDQpCRUdJTg0KICBGRVRDSCBORVhUIEZST00gY0JlbWVya3VuZyBJTlRPIEBJdGVtVGV4dA0KI" +
                        "CBJRiAoQEBGRVRDSF9TVEFUVVMgPD4gMCkNCiAgICBCUkVBSzsNCg0KICBTRVQgQEJlbWVya3VuZyA9I" +
                        "ElTTlVMTChAQmVtZXJrdW5nICsgQE5MLCAnJykgKyBASXRlbVRleHQNCkVORA0KQ0xPU0UgY0JlbWVya" +
                        "3VuZw0KREVBTExPQ0FURSBjQmVtZXJrdW5nDQoNCg0KU0VMRUNUIEJCRy5CZ0J1ZGdldElELA0KICAgI" +
                        "CAgIFRpdGxlICAgICAgICAgICA9ICdWZXJmw7xndW5nOiBTb3ppYWxoaWxmZSAnICsgZGJvLmZuWE1vb" +
                        "mF0SmFocihkYm8uZm5EYXRlU2VyaWFsKEJCRy5KYWhyLCBCQkcuTW9uYXQsIDEpKSwNCiAgICAgICBBZ" +
                        "HJlc3NlICAgICAgICAgPSBJU05VTEwoQ0FTRSBQUlMuR2VzY2hsZWNodENvZGUNCiAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICBXSEVOIDEgVEhFTiAnSGVycicNCiAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICBXSEVOIDIgVEhFTiAnRnJhdScNCiAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgRU5EICsgQE5MLCAnJykgKw0KICAgICAgICAgICAgICAgICAgICAgICAgIFBSUy5Wb3JuY" +
                        "W1lTmFtZSArIEBOTCArDQogICAgICAgICAgICAgICAgICAgICAgICAgUFJTLldvaG5zaXR6U3RyYXNzZ" +
                        "UhhdXNOciArIEBOTCArDQogICAgICAgICAgICAgICAgICAgICAgICAgUFJTLldvaG5zaXR6UExaT3J0L" +
                        "A0KICAgICAgIERhdHVtRmluYW56cGxhbiA9IChTRUxFQ1QgTUFYKERhdHVtKQ0KICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICBGUk9NIEJnQmV3aWxsaWd1bmcgQkJXDQogICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgIFdIRVJFIEJCVy5CZ0ZpbmFuenBsYW5JRCA9IFNGUC5CZ0ZpbmFuenBsYW5JRCBBTkQgQkJXLkJnQ" +
                        "mV3aWxsaWd1bmdDb2RlID0gMiksDQogICAgICAgQmVtZXJrdW5nICAgICAgID0gSVNOVUxMKENPTlZFU" +
                        "lQoVkFSQ0hBUig4MDAwKSwgU0ZQLkJlbWVya3VuZykgKyBATkwsICcnKSArIElTTlVMTChAQmVtZXJrd" +
                        "W5nLCAnJyksDQogICAgICAgVG90SW4gICAgICAgICAgID0gQFRvdEluLA0KICAgICAgIFRvdE91dCAgI" +
                        "CAgICAgICA9IEBUb3RPdXQsDQogICAgICAgRmVobGJldHJhZyAgICAgID0gSVNOVUxMKEBUb3RPdXQsM" +
                        "CkgLSBJU05VTEwoQFRvdEluLDApDQpGUk9NIEJnQnVkZ2V0ICAgICAgICAgICAgIEJCRw0KICBJTk5FU" +
                        "iBKT0lOIEJnRmluYW56cGxhbiBTRlAgT04gU0ZQLkJnRmluYW56cGxhbklEID0gQkJHLkJnRmluYW56c" +
                        "GxhbklEDQogIElOTkVSIEpPSU4gRmFMZWlzdHVuZyAgIEZBTCBPTiBGQUwuRmFMZWlzdHVuZ0lEID0gU" +
                        "0ZQLkZhTGVpc3R1bmdJRA0KICBJTk5FUiBKT0lOIHZ3UGVyc29uICAgICBQUlMgT04gUFJTLkJhUGVyc" +
                        "29uSUQgPSBGQUwuQmFQZXJzb25JRA0KV0hFUkUgRkFMLk1vZHVsSUQgPSAzDQogIEFORCBCQkcuTWFzd" +
                        "GVyQnVkZ2V0ID0gMA0KICBBTkQgQkJHLkJnQmV3aWxsaWd1bmdTdGF0dXNDb2RlID0gNQ0KICBBTkQgQ" +
                        "kJHLkJnQnVkZ2V0SUQgPSBudWxsQAABAAAA/////wEAAAAAAAAADAIAAAAbRGV2RXhwcmVzcy5YdHJhU" +
                        "mVwb3J0cy52Ni4yBQEAAAAsRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5TZXJpYWxpemFibGVTdHJpb" +
                        "mcBAAAABVZhbHVlAQIAAAAGAwAAALABe1xydGYxXGFuc2lcYW5zaWNwZzEyNTJcZGVmZjBcZGVmbGFuZ" +
                        "zIwNTV7XGZvbnR0Ymx7XGYwXGZuaWxcZmNoYXJzZXQwIEFyaWFsO319DQpcdmlld2tpbmQ0XHVjMVxwY" +
                        "XJkXGZzMjAgU296aWFsZGllbnN0XHBhcg0KRmVsbGVuYmVyZ3N0ci4gOVxwYXINCjMwNTMgTVwnZmNuY" +
                        "2hlbmJ1Y2hzZWVccGFyDQp9DQoL";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.rtfRechsmittel = new DevExpress.XtraReports.UI.XRRichTextBox();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.ShVerfuegungMonatsbudget_EinAus = new DevExpress.XtraReports.UI.Subreport();
            this.ShVerfuegungMonatsbudget_Personen = new DevExpress.XtraReports.UI.Subreport();
            this.xrRichTextBox1 = new DevExpress.XtraReports.UI.XRRichTextBox();
            this.txtFehlbetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.Label25 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label24 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label23 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTotOut = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTotIn = new DevExpress.XtraReports.UI.XRLabel();
            this.Line13 = new DevExpress.XtraReports.UI.XRLine();
            this.Line12 = new DevExpress.XtraReports.UI.XRLine();
            this.Line11 = new DevExpress.XtraReports.UI.XRLine();
            this.Line10 = new DevExpress.XtraReports.UI.XRLine();
            this.Label12 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label11 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAnrede = new DevExpress.XtraReports.UI.XRLabel();
            this.Line8 = new DevExpress.XtraReports.UI.XRLine();
            this.Line7 = new DevExpress.XtraReports.UI.XRLine();
            this.Line6 = new DevExpress.XtraReports.UI.XRLine();
            this.Line4 = new DevExpress.XtraReports.UI.XRLine();
            this.Label9 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.Label8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.Label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.rtfHinweis = new DevExpress.XtraReports.UI.XRRichTextBox();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPanel1,
                        this.xrLabel2,
                        this.rtfRechsmittel,
                        this.xrLabel1,
                        this.xrLine1,
                        this.ShVerfuegungMonatsbudget_EinAus,
                        this.ShVerfuegungMonatsbudget_Personen,
                        this.xrRichTextBox1,
                        this.txtFehlbetrag,
                        this.Label25,
                        this.Label24,
                        this.Label23,
                        this.txtTotOut,
                        this.txtTotIn,
                        this.Line13,
                        this.Line12,
                        this.Line11,
                        this.Line10,
                        this.Label12,
                        this.Label11,
                        this.txtAnrede,
                        this.Line8,
                        this.Line7,
                        this.Line6,
                        this.Line4,
                        this.Label9,
                        this.Line3,
                        this.Label8,
                        this.Line2,
                        this.Label7,
                        this.Line1,
                        this.Label6,
                        this.Label5,
                        this.Label4,
                        this.Label3,
                        this.Label2,
                        this.txtTitle,
                        this.rtfHinweis});
            this.Detail.Dpi = 254F;
            this.Detail.Height = 1982;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBackColor = false;
            this.Detail.ParentStyleUsing.UseBorderColor = false;
            this.Detail.ParentStyleUsing.UseBorders = false;
            this.Detail.ParentStyleUsing.UseBorderWidth = false;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.ParentStyleUsing.UseForeColor = false;
            // 
            // xrPanel1
            // 
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageInfo1});
            this.xrPanel1.Dpi = 254F;
            this.xrPanel1.Location = new System.Drawing.Point(0, 1460);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.ParentStyleUsing.UseBorders = false;
            this.xrPanel1.Size = new System.Drawing.Size(550, 106);
            // 
            // xrLabel2
            // 
            this.xrLabel2.BackColor = System.Drawing.Color.Silver;
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.Location = new System.Drawing.Point(799, 1405);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.ParentStyleUsing.UseBackColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorders = false;
            this.xrLabel2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.ParentStyleUsing.UseForeColor = false;
            this.xrLabel2.Size = new System.Drawing.Size(373, 38);
            this.xrLabel2.Text = "Empfangsbestätigung";
            // 
            // rtfRechsmittel
            // 
            this.rtfRechsmittel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.rtfRechsmittel.BorderColor = System.Drawing.Color.Black;
            this.rtfRechsmittel.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.rtfRechsmittel.Dpi = 254F;
            this.rtfRechsmittel.Location = new System.Drawing.Point(0, 1775);
            this.rtfRechsmittel.Name = "rtfRechsmittel";
            this.rtfRechsmittel.ParentStyleUsing.UseBackColor = false;
            this.rtfRechsmittel.ParentStyleUsing.UseBorderColor = false;
            this.rtfRechsmittel.ParentStyleUsing.UseBorders = false;
            this.rtfRechsmittel.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("rtfRechsmittel.RtfText")));
            this.rtfRechsmittel.Size = new System.Drawing.Size(1863, 149);
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bemerkung", "")});
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel1.Location = new System.Drawing.Point(394, 1278);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(1458, 85);
            this.xrLabel1.Text = "xrLabel1";
            // 
            // xrLine1
            // 
            this.xrLine1.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.xrLine1.Dpi = 254F;
            this.xrLine1.ForeColor = System.Drawing.Color.Transparent;
            this.xrLine1.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine1.Location = new System.Drawing.Point(940, 715);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(5, 134);
            // 
            // ShVerfuegungMonatsbudget_EinAus
            // 
            this.ShVerfuegungMonatsbudget_EinAus.Dpi = 254F;
            this.ShVerfuegungMonatsbudget_EinAus.Location = new System.Drawing.Point(0, 660);
            this.ShVerfuegungMonatsbudget_EinAus.Name = "ShVerfuegungMonatsbudget_EinAus";
            // 
            // ShVerfuegungMonatsbudget_Personen
            // 
            this.ShVerfuegungMonatsbudget_Personen.Dpi = 254F;
            this.ShVerfuegungMonatsbudget_Personen.Location = new System.Drawing.Point(0, 429);
            this.ShVerfuegungMonatsbudget_Personen.Name = "ShVerfuegungMonatsbudget_Personen";
            // 
            // xrRichTextBox1
            // 
            this.xrRichTextBox1.CanShrink = true;
            this.xrRichTextBox1.Dpi = 254F;
            this.xrRichTextBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrRichTextBox1.ForeColor = System.Drawing.Color.Black;
            this.xrRichTextBox1.Location = new System.Drawing.Point(0, 21);
            this.xrRichTextBox1.Name = "xrRichTextBox1";
            this.xrRichTextBox1.ParentStyleUsing.UseBackColor = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorderColor = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorders = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorderWidth = false;
            this.xrRichTextBox1.ParentStyleUsing.UseFont = false;
            this.xrRichTextBox1.ParentStyleUsing.UseForeColor = false;
            this.xrRichTextBox1.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichTextBox1.RtfText")));
            this.xrRichTextBox1.Size = new System.Drawing.Size(529, 191);
            // 
            // txtFehlbetrag
            // 
            this.txtFehlbetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Fehlbetrag", "{0:n2}")});
            this.txtFehlbetrag.Dpi = 254F;
            this.txtFehlbetrag.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.txtFehlbetrag.ForeColor = System.Drawing.Color.Black;
            this.txtFehlbetrag.Location = new System.Drawing.Point(1588, 874);
            this.txtFehlbetrag.Multiline = true;
            this.txtFehlbetrag.Name = "txtFehlbetrag";
            this.txtFehlbetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtFehlbetrag.ParentStyleUsing.UseBackColor = false;
            this.txtFehlbetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtFehlbetrag.ParentStyleUsing.UseBorders = false;
            this.txtFehlbetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtFehlbetrag.ParentStyleUsing.UseFont = false;
            this.txtFehlbetrag.ParentStyleUsing.UseForeColor = false;
            this.txtFehlbetrag.Size = new System.Drawing.Size(254, 38);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtFehlbetrag.Summary = xrSummary1;
            this.txtFehlbetrag.Text = "Fehlbetrag";
            this.txtFehlbetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label25
            // 
            this.Label25.Dpi = 254F;
            this.Label25.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.Label25.ForeColor = System.Drawing.Color.Black;
            this.Label25.Location = new System.Drawing.Point(970, 874);
            this.Label25.Name = "Label25";
            this.Label25.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label25.ParentStyleUsing.UseBackColor = false;
            this.Label25.ParentStyleUsing.UseBorderColor = false;
            this.Label25.ParentStyleUsing.UseBorders = false;
            this.Label25.ParentStyleUsing.UseBorderWidth = false;
            this.Label25.ParentStyleUsing.UseFont = false;
            this.Label25.ParentStyleUsing.UseForeColor = false;
            this.Label25.Size = new System.Drawing.Size(612, 43);
            this.Label25.Text = "Fehlbetrag";
            this.Label25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label24
            // 
            this.Label24.Dpi = 254F;
            this.Label24.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label24.ForeColor = System.Drawing.Color.Black;
            this.Label24.Location = new System.Drawing.Point(970, 787);
            this.Label24.Name = "Label24";
            this.Label24.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label24.ParentStyleUsing.UseBackColor = false;
            this.Label24.ParentStyleUsing.UseBorderColor = false;
            this.Label24.ParentStyleUsing.UseBorders = false;
            this.Label24.ParentStyleUsing.UseBorderWidth = false;
            this.Label24.ParentStyleUsing.UseFont = false;
            this.Label24.ParentStyleUsing.UseForeColor = false;
            this.Label24.Size = new System.Drawing.Size(612, 39);
            this.Label24.Text = "Total Ausgaben";
            this.Label24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label23
            // 
            this.Label23.Dpi = 254F;
            this.Label23.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label23.ForeColor = System.Drawing.Color.Black;
            this.Label23.Location = new System.Drawing.Point(3, 787);
            this.Label23.Name = "Label23";
            this.Label23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label23.ParentStyleUsing.UseBackColor = false;
            this.Label23.ParentStyleUsing.UseBorderColor = false;
            this.Label23.ParentStyleUsing.UseBorders = false;
            this.Label23.ParentStyleUsing.UseBorderWidth = false;
            this.Label23.ParentStyleUsing.UseFont = false;
            this.Label23.ParentStyleUsing.UseForeColor = false;
            this.Label23.Size = new System.Drawing.Size(655, 39);
            this.Label23.Text = "Total Einnahmen";
            this.Label23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtTotOut
            // 
            this.txtTotOut.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TotOut", "{0:n2}")});
            this.txtTotOut.Dpi = 254F;
            this.txtTotOut.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtTotOut.ForeColor = System.Drawing.Color.Black;
            this.txtTotOut.Location = new System.Drawing.Point(1588, 787);
            this.txtTotOut.Multiline = true;
            this.txtTotOut.Name = "txtTotOut";
            this.txtTotOut.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtTotOut.ParentStyleUsing.UseBackColor = false;
            this.txtTotOut.ParentStyleUsing.UseBorderColor = false;
            this.txtTotOut.ParentStyleUsing.UseBorders = false;
            this.txtTotOut.ParentStyleUsing.UseBorderWidth = false;
            this.txtTotOut.ParentStyleUsing.UseFont = false;
            this.txtTotOut.ParentStyleUsing.UseForeColor = false;
            this.txtTotOut.Size = new System.Drawing.Size(254, 39);
            xrSummary2.FormatString = "{0:#,##0.00}";
            this.txtTotOut.Summary = xrSummary2;
            this.txtTotOut.Text = "TotOut";
            this.txtTotOut.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtTotIn
            // 
            this.txtTotIn.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TotIn", "{0:n2}")});
            this.txtTotIn.Dpi = 254F;
            this.txtTotIn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtTotIn.ForeColor = System.Drawing.Color.Black;
            this.txtTotIn.Location = new System.Drawing.Point(665, 787);
            this.txtTotIn.Multiline = true;
            this.txtTotIn.Name = "txtTotIn";
            this.txtTotIn.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtTotIn.ParentStyleUsing.UseBackColor = false;
            this.txtTotIn.ParentStyleUsing.UseBorderColor = false;
            this.txtTotIn.ParentStyleUsing.UseBorders = false;
            this.txtTotIn.ParentStyleUsing.UseBorderWidth = false;
            this.txtTotIn.ParentStyleUsing.UseFont = false;
            this.txtTotIn.ParentStyleUsing.UseForeColor = false;
            this.txtTotIn.Size = new System.Drawing.Size(254, 39);
            xrSummary3.FormatString = "{0:#,##0.00}";
            this.txtTotIn.Summary = xrSummary3;
            this.txtTotIn.Text = "TotIn";
            this.txtTotIn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line13
            // 
            this.Line13.Dpi = 254F;
            this.Line13.ForeColor = System.Drawing.Color.Black;
            this.Line13.LineWidth = 3;
            this.Line13.Location = new System.Drawing.Point(3, 843);
            this.Line13.Name = "Line13";
            this.Line13.ParentStyleUsing.UseBackColor = false;
            this.Line13.ParentStyleUsing.UseBorderColor = false;
            this.Line13.ParentStyleUsing.UseBorders = false;
            this.Line13.ParentStyleUsing.UseBorderWidth = false;
            this.Line13.ParentStyleUsing.UseFont = false;
            this.Line13.ParentStyleUsing.UseForeColor = false;
            this.Line13.Size = new System.Drawing.Size(1854, 5);
            // 
            // Line12
            // 
            this.Line12.Dpi = 254F;
            this.Line12.ForeColor = System.Drawing.Color.Black;
            this.Line12.LineWidth = 3;
            this.Line12.Location = new System.Drawing.Point(3, 767);
            this.Line12.Name = "Line12";
            this.Line12.ParentStyleUsing.UseBackColor = false;
            this.Line12.ParentStyleUsing.UseBorderColor = false;
            this.Line12.ParentStyleUsing.UseBorders = false;
            this.Line12.ParentStyleUsing.UseBorderWidth = false;
            this.Line12.ParentStyleUsing.UseFont = false;
            this.Line12.ParentStyleUsing.UseForeColor = false;
            this.Line12.Size = new System.Drawing.Size(1854, 5);
            // 
            // Line11
            // 
            this.Line11.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.Line11.Dpi = 254F;
            this.Line11.ForeColor = System.Drawing.Color.Transparent;
            this.Line11.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line11.Location = new System.Drawing.Point(940, 589);
            this.Line11.Name = "Line11";
            this.Line11.ParentStyleUsing.UseBackColor = false;
            this.Line11.ParentStyleUsing.UseBorderColor = false;
            this.Line11.ParentStyleUsing.UseBorders = false;
            this.Line11.ParentStyleUsing.UseBorderWidth = false;
            this.Line11.ParentStyleUsing.UseFont = false;
            this.Line11.ParentStyleUsing.UseForeColor = false;
            this.Line11.Size = new System.Drawing.Size(5, 88);
            // 
            // Line10
            // 
            this.Line10.Dpi = 254F;
            this.Line10.ForeColor = System.Drawing.Color.Black;
            this.Line10.LineWidth = 3;
            this.Line10.Location = new System.Drawing.Point(3, 640);
            this.Line10.Name = "Line10";
            this.Line10.ParentStyleUsing.UseBackColor = false;
            this.Line10.ParentStyleUsing.UseBorderColor = false;
            this.Line10.ParentStyleUsing.UseBorders = false;
            this.Line10.ParentStyleUsing.UseBorderWidth = false;
            this.Line10.ParentStyleUsing.UseFont = false;
            this.Line10.ParentStyleUsing.UseForeColor = false;
            this.Line10.Size = new System.Drawing.Size(1854, 5);
            // 
            // Label12
            // 
            this.Label12.Dpi = 254F;
            this.Label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(962, 589);
            this.Label12.Name = "Label12";
            this.Label12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label12.ParentStyleUsing.UseBackColor = false;
            this.Label12.ParentStyleUsing.UseBorderColor = false;
            this.Label12.ParentStyleUsing.UseBorders = false;
            this.Label12.ParentStyleUsing.UseBorderWidth = false;
            this.Label12.ParentStyleUsing.UseFont = false;
            this.Label12.ParentStyleUsing.UseForeColor = false;
            this.Label12.Size = new System.Drawing.Size(485, 38);
            this.Label12.Text = "Ausgaben";
            // 
            // Label11
            // 
            this.Label11.Dpi = 254F;
            this.Label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(3, 589);
            this.Label11.Name = "Label11";
            this.Label11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label11.ParentStyleUsing.UseBackColor = false;
            this.Label11.ParentStyleUsing.UseBorderColor = false;
            this.Label11.ParentStyleUsing.UseBorders = false;
            this.Label11.ParentStyleUsing.UseBorderWidth = false;
            this.Label11.ParentStyleUsing.UseFont = false;
            this.Label11.ParentStyleUsing.UseForeColor = false;
            this.Label11.Size = new System.Drawing.Size(668, 38);
            this.Label11.Text = "Einnahmen";
            // 
            // txtAnrede
            // 
            this.txtAnrede.CanGrow = false;
            this.txtAnrede.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Adresse", "")});
            this.txtAnrede.Dpi = 254F;
            this.txtAnrede.Font = new System.Drawing.Font("Arial", 11F);
            this.txtAnrede.ForeColor = System.Drawing.Color.Black;
            this.txtAnrede.Location = new System.Drawing.Point(1291, 21);
            this.txtAnrede.Multiline = true;
            this.txtAnrede.Name = "txtAnrede";
            this.txtAnrede.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtAnrede.ParentStyleUsing.UseBackColor = false;
            this.txtAnrede.ParentStyleUsing.UseBorderColor = false;
            this.txtAnrede.ParentStyleUsing.UseBorders = false;
            this.txtAnrede.ParentStyleUsing.UseBorderWidth = false;
            this.txtAnrede.ParentStyleUsing.UseFont = false;
            this.txtAnrede.ParentStyleUsing.UseForeColor = false;
            this.txtAnrede.Size = new System.Drawing.Size(540, 232);
            this.txtAnrede.Text = "Anrede";
            // 
            // Line8
            // 
            this.Line8.Dpi = 254F;
            this.Line8.ForeColor = System.Drawing.Color.Black;
            this.Line8.LineWidth = 3;
            this.Line8.Location = new System.Drawing.Point(3, 1381);
            this.Line8.Name = "Line8";
            this.Line8.ParentStyleUsing.UseBackColor = false;
            this.Line8.ParentStyleUsing.UseBorderColor = false;
            this.Line8.ParentStyleUsing.UseBorders = false;
            this.Line8.ParentStyleUsing.UseBorderWidth = false;
            this.Line8.ParentStyleUsing.UseFont = false;
            this.Line8.ParentStyleUsing.UseForeColor = false;
            this.Line8.Size = new System.Drawing.Size(1854, 6);
            // 
            // Line7
            // 
            this.Line7.Dpi = 254F;
            this.Line7.ForeColor = System.Drawing.Color.Black;
            this.Line7.LineWidth = 3;
            this.Line7.Location = new System.Drawing.Point(3, 1254);
            this.Line7.Name = "Line7";
            this.Line7.ParentStyleUsing.UseBackColor = false;
            this.Line7.ParentStyleUsing.UseBorderColor = false;
            this.Line7.ParentStyleUsing.UseBorders = false;
            this.Line7.ParentStyleUsing.UseBorderWidth = false;
            this.Line7.ParentStyleUsing.UseFont = false;
            this.Line7.ParentStyleUsing.UseForeColor = false;
            this.Line7.Size = new System.Drawing.Size(1854, 6);
            // 
            // Line6
            // 
            this.Line6.Dpi = 254F;
            this.Line6.ForeColor = System.Drawing.Color.Black;
            this.Line6.LineWidth = 3;
            this.Line6.Location = new System.Drawing.Point(3, 958);
            this.Line6.Name = "Line6";
            this.Line6.ParentStyleUsing.UseBackColor = false;
            this.Line6.ParentStyleUsing.UseBorderColor = false;
            this.Line6.ParentStyleUsing.UseBorders = false;
            this.Line6.ParentStyleUsing.UseBorderWidth = false;
            this.Line6.ParentStyleUsing.UseFont = false;
            this.Line6.ParentStyleUsing.UseForeColor = false;
            this.Line6.Size = new System.Drawing.Size(1854, 5);
            // 
            // Line4
            // 
            this.Line4.Dpi = 254F;
            this.Line4.ForeColor = System.Drawing.Color.Black;
            this.Line4.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.Line4.LineWidth = 3;
            this.Line4.Location = new System.Drawing.Point(799, 1680);
            this.Line4.Name = "Line4";
            this.Line4.ParentStyleUsing.UseBackColor = false;
            this.Line4.ParentStyleUsing.UseBorderColor = false;
            this.Line4.ParentStyleUsing.UseBorders = false;
            this.Line4.ParentStyleUsing.UseBorderWidth = false;
            this.Line4.ParentStyleUsing.UseFont = false;
            this.Line4.ParentStyleUsing.UseForeColor = false;
            this.Line4.Size = new System.Drawing.Size(620, 5);
            // 
            // Label9
            // 
            this.Label9.Dpi = 254F;
            this.Label9.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(799, 1699);
            this.Label9.Name = "Label9";
            this.Label9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label9.ParentStyleUsing.UseBackColor = false;
            this.Label9.ParentStyleUsing.UseBorderColor = false;
            this.Label9.ParentStyleUsing.UseBorders = false;
            this.Label9.ParentStyleUsing.UseBorderWidth = false;
            this.Label9.ParentStyleUsing.UseFont = false;
            this.Label9.ParentStyleUsing.UseForeColor = false;
            this.Label9.Size = new System.Drawing.Size(620, 38);
            this.Label9.Text = "Unterschrift";
            // 
            // Line3
            // 
            this.Line3.Dpi = 254F;
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.Line3.LineWidth = 3;
            this.Line3.Location = new System.Drawing.Point(799, 1553);
            this.Line3.Name = "Line3";
            this.Line3.ParentStyleUsing.UseBackColor = false;
            this.Line3.ParentStyleUsing.UseBorderColor = false;
            this.Line3.ParentStyleUsing.UseBorders = false;
            this.Line3.ParentStyleUsing.UseBorderWidth = false;
            this.Line3.ParentStyleUsing.UseFont = false;
            this.Line3.ParentStyleUsing.UseForeColor = false;
            this.Line3.Size = new System.Drawing.Size(620, 5);
            // 
            // Label8
            // 
            this.Label8.Dpi = 254F;
            this.Label8.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(799, 1572);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(620, 38);
            this.Label8.Text = "Ort und Datum";
            // 
            // Line2
            // 
            this.Line2.Dpi = 254F;
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.Line2.LineWidth = 3;
            this.Line2.Location = new System.Drawing.Point(3, 1680);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(620, 5);
            // 
            // Label7
            // 
            this.Label7.Dpi = 254F;
            this.Label7.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(3, 1699);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(620, 38);
            this.Label7.Text = "Für den Sozialdienst";
            // 
            // Line1
            // 
            this.Line1.Dpi = 254F;
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.Line1.LineWidth = 3;
            this.Line1.Location = new System.Drawing.Point(3, 1553);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(620, 5);
            // 
            // Label6
            // 
            this.Label6.Dpi = 254F;
            this.Label6.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(3, 1572);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(620, 38);
            this.Label6.Text = "Ort und Datum";
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.Color.Silver;
            this.Label5.Dpi = 254F;
            this.Label5.Font = new System.Drawing.Font("Arial", 10F);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(3, 1405);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(373, 38);
            this.Label5.Text = "Sozialhilfe bewilligt";
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Silver;
            this.Label4.Dpi = 254F;
            this.Label4.Font = new System.Drawing.Font("Arial", 10F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(3, 1278);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(373, 38);
            this.Label4.Text = "Bemerkungen";
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.Silver;
            this.Label3.Dpi = 254F;
            this.Label3.Font = new System.Drawing.Font("Arial", 10F);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(3, 974);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(373, 38);
            this.Label3.Text = "Hinweis";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Silver;
            this.Label2.Dpi = 254F;
            this.Label2.Font = new System.Drawing.Font("Arial", 10F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(3, 526);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(373, 38);
            this.Label2.Text = "Budgetübersicht";
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.Silver;
            this.txtTitle.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Title", "")});
            this.txtTitle.Dpi = 254F;
            this.txtTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txtTitle.ForeColor = System.Drawing.Color.Black;
            this.txtTitle.Location = new System.Drawing.Point(0, 325);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtTitle.ParentStyleUsing.UseBackColor = false;
            this.txtTitle.ParentStyleUsing.UseBorderColor = false;
            this.txtTitle.ParentStyleUsing.UseBorders = false;
            this.txtTitle.ParentStyleUsing.UseBorderWidth = false;
            this.txtTitle.ParentStyleUsing.UseFont = false;
            this.txtTitle.ParentStyleUsing.UseForeColor = false;
            this.txtTitle.Size = new System.Drawing.Size(1854, 59);
            this.txtTitle.Text = "Title";
            this.txtTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // rtfHinweis
            // 
            this.rtfHinweis.Dpi = 254F;
            this.rtfHinweis.ForeColor = System.Drawing.Color.Black;
            this.rtfHinweis.Location = new System.Drawing.Point(394, 974);
            this.rtfHinweis.Name = "rtfHinweis";
            this.rtfHinweis.ParentStyleUsing.UseBackColor = false;
            this.rtfHinweis.ParentStyleUsing.UseBorderColor = false;
            this.rtfHinweis.ParentStyleUsing.UseBorders = false;
            this.rtfHinweis.ParentStyleUsing.UseBorderWidth = false;
            this.rtfHinweis.ParentStyleUsing.UseFont = false;
            this.rtfHinweis.ParentStyleUsing.UseForeColor = false;
            this.rtfHinweis.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("rtfHinweis.RtfText")));
            this.rtfHinweis.Scripts.OnBeforePrint = "private void OnBeforePrint(object sender, System.Drawing.Printing.PrintEventArgs " +
                "e) {\r\n\trtfHinweis.Text = string.Format(rtfHinweis.Text, Report.GetCurrentColumnV" +
                "alue(\"DatumFinanzplan\"));\r\n}";
            this.rtfHinweis.Size = new System.Drawing.Size(1458, 275);
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 254F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 11F);
            this.xrPageInfo1.Format = "Münchenbuchsee, {0}";
            this.xrPageInfo1.KeepTogether = false;
            this.xrPageInfo1.Location = new System.Drawing.Point(0, 42);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(550, 51);
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail});
            this.DataSource = this.sqlQuery1;
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(140, 95, 203, 102);
            this.Name = "Report";
            this.PageHeight = 2969;
            this.PageWidth = 2101;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' , ParameterXML =  N'<?xml version="1.0" standalone="yes" ?>
<NewDataSet>
	<Table>	
		<FieldName>-</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Person</DisplayText>
		<TabPosition>1</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<DefaultValue></DefaultValue>
	</Table>
	<Table>	
		<FieldName>BaPersonID_Zusatz</FieldName>
		<FieldCode>14</FieldCode>
		<DisplayText>Person</DisplayText>
		<TabPosition>1</TabPosition>
		<X>120</X>
		<Y>60</Y>
		<Width>150</Width>
		<Height>25</Height>
		<Length>10</Length>
                <ParameterCount>1</ParameterCount>
                <Parameter0>BgBudgetID</Parameter0>
		<SQL>
SELECT
  ID   = PRS.BaPersonID,
  [Name] = PRS.NameVorname,
  PRS.Geburtsdatum,
  [Alter]      = dbo.fnGetAge(PRS.Geburtsdatum, IsNull(BFP.DatumVon, BFP.GeplantVon)),
  Beziehung = CASE WHEN PRS.BaPersonID = FLE.BaPersonID
                THEN ''Leistungsträger/-in''
                ELSE dbo.fnBaRelation(FLE.BaPersonID, PRS.BaPersonID)
              END
FROM BgFinanzplan_BaPerson    BFB
  INNER JOIN BgBudget         BDG ON BDG.BgFinanzplanID = BFB.BgFinanzplanID
  INNER JOIN vwPerson         PRS ON PRS.BaPersonID = BFB.BaPersonID
  INNER JOIN BgFinanzplan     BFP ON BFP.BgFinanzplanID = BFB.BgFinanzplanID
  INNER JOIN FaLeistung       FLE ON FLE.FaLeistungID = BFP.FaLeistungID
WHERE BDG.BgBudgetID = {BgBudgetID}
  AND PRS.BaPersonID != FLE.BaPersonID
		</SQL>
	</Table>
	<Table>
		<FieldName>label</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Budget ID:</DisplayText>
		<TabPosition>0</TabPosition>
		<X>10</X>
		<Y>90</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>BgBudgetID</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>Budget ID</DisplayText>
		<TabPosition>1</TabPosition>
		<X>120</X>
		<Y>90</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>true</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
</NewDataSet>' , SQLquery =  N'-- Parameter
DECLARE @GetDate DATETIME;
SET @GetDate = GETDATE();

DECLARE @NL VARCHAR(2);
SET @NL = CHAR(13) + CHAR(10);

DECLARE @TotIn MONEY;
DECLARE @TotOut MONEY;


SELECT @TotIn = SUM(Betrag)
FROM dbo.fnWhGetFinanzplan({BgBudgetID}, @GetDate)
WHERE BgKategorieCode = 1;


SELECT @TotOut = SUM(Betrag)
FROM dbo.fnWhGetFinanzplan({BgBudgetID}, @GetDate)
WHERE BgKategorieCode = 2;


DECLARE @Bemerkung  VARCHAR(8000);
DECLARE @ItemText   VARCHAR(8000);

DECLARE cBemerkung CURSOR FAST_FORWARD FOR
  SELECT ''- '' + XLC.Text + '' ('' + PRS.Name + ISNULL('', '' + PRS.Vorname, '''') + ''): '' +
    CONVERT(VARCHAR(8000), BPO.Bemerkung)
  FROM BgPosition             BPO
    INNER JOIN BaPerson       PRS ON PRS.BaPersonID = BPO.BaPersonID
    INNER JOIN WhPositionsart SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
    INNER JOIN XLOVCode       XLC ON XLC.LOVName = ''BgGruppe''
                                 AND XLC.Code = SPT.BgGruppeCode
  WHERE BPO.BgBudgetID = {BgBudgetID}
    AND SPT.BgPositionsartCode BETWEEN 39000 AND 39999
    AND NULLIF(BPO.Bemerkung, '''') IS NOT NULL
    AND GetDate() BETWEEN ISNULL(BPO.DatumVon, ''19000101'') AND ISNULL(BPO.DatumBis, GetDate())
  ORDER BY PRS.Name, PRS.Vorname;

OPEN cBemerkung;
WHILE (1 = 1)
BEGIN
  FETCH NEXT FROM cBemerkung INTO @ItemText
  IF (@@FETCH_STATUS <> 0)
    BREAK;

  SET @Bemerkung = ISNULL(@Bemerkung + @NL, '''') + @ItemText
END
CLOSE cBemerkung
DEALLOCATE cBemerkung


SELECT BBG.BgBudgetID,
       Title           = ''Verfügung: Sozialhilfe '' + dbo.fnXMonatJahr(dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)),
       Adresse         = ISNULL(CASE PRS.GeschlechtCode
                                  WHEN 1 THEN ''Herr''
                                  WHEN 2 THEN ''Frau''
                                END + @NL, '''') +
                         PRS.VornameName + @NL +
                         PRS.WohnsitzStrasseHausNr + @NL +
                         PRS.WohnsitzPLZOrt,
       DatumFinanzplan = (SELECT MAX(Datum)
                          FROM BgBewilligung BBW
                          WHERE BBW.BgFinanzplanID = SFP.BgFinanzplanID AND BBW.BgBewilligungCode = 2),
       Bemerkung       = ISNULL(CONVERT(VARCHAR(8000), SFP.Bemerkung) + @NL, '''') + ISNULL(@Bemerkung, ''''),
       TotIn           = @TotIn,
       TotOut          = @TotOut,
       Fehlbetrag      = ISNULL(@TotOut,0) - ISNULL(@TotIn,0)
FROM BgBudget             BBG
  INNER JOIN BgFinanzplan SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
  INNER JOIN FaLeistung   FAL ON FAL.FaLeistungID = SFP.FaLeistungID
  INNER JOIN vwPerson     PRS ON PRS.BaPersonID = FAL.BaPersonID
WHERE FAL.ModulID = 3
  AND BBG.MasterBudget = 0
  AND BBG.BgBewilligungStatusCode = 5
  AND BBG.BgBudgetID = {BgBudgetID}' , ContextForms =  N'WhMonatsbudget,SKOS2005' , ParentReportName =  null , ReportSortKey = 3
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'ShVerfuegungMonatsbudget' ;


INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShVerfuegungMonatsbudget_EinAus' ,  N'Einnahmen, Ausgaben' , 1,  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>C:\Windows\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>en-US</Localization>
///   <References>
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraPrinting.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Drawing\2.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System\2.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Configuration\2.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Xml\2.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Data.SqlXml\2.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Security\2.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.Utils.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Utils.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Windows.Forms\2.0.0.0__b77a5c561934e089\System.Windows.Forms.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\Accessibility\2.0.0.0__b03f5f7f11d50a3a\Accessibility.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Runtime.Serialization.Formatters.Soap\2.0.0.0__b03f5f7f11d50a3a\System.Runtime.Serialization.Formatters.Soap.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Deployment\2.0.0.0__b03f5f7f11d50a3a\System.Deployment.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Design\2.0.0.0__b03f5f7f11d50a3a\System.Design.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_32\System.Data\2.0.0.0__b77a5c561934e089\System.Data.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\Microsoft.VisualC\8.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualC.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_32\System.Transactions\2.0.0.0__b77a5c561934e089\System.Transactions.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_32\System.EnterpriseServices\2.0.0.0__b03f5f7f11d50a3a\System.EnterpriseServices.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.DirectoryServices\2.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Runtime.Remoting\2.0.0.0__b77a5c561934e089\System.Runtime.Remoting.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_32\System.Web\2.0.0.0__b03f5f7f11d50a3a\System.Web.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Web.Services\2.0.0.0__b03f5f7f11d50a3a\System.Web.Services.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.DirectoryServices.Protocols\2.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.Protocols.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.ServiceProcess\2.0.0.0__b03f5f7f11d50a3a\System.ServiceProcess.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Configuration.Install\2.0.0.0__b03f5f7f11d50a3a\System.Configuration.Install.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Web.RegularExpressions\2.0.0.0__b03f5f7f11d50a3a\System.Web.RegularExpressions.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Drawing.Design\2.0.0.0__b03f5f7f11d50a3a\System.Drawing.Design.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_32\System.Data.OracleClient\2.0.0.0__b77a5c561934e089\System.Data.OracleClient.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraEditors.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.Data.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Data.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraBars.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraNavBar.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraCharts.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraRichTextEdit.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="C:\Program Files\KiSS\Current Build\KiSS4.DB.dll" />
///     <Reference Path="C:\Program Files\KiSS\Current Build\log4net.dll" />
///     <Reference Path="C:\Program Files\KiSS\Current Build\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kA" +
                        "AAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAA" +
                        "AAAAakJREVDTEFSRSBAR2V0RGF0ZSBEQVRFVElNRTsNClNFVCBAR2V0RGF0ZSA9IEdFVERBVEUoKTsNC" +
                        "g0KDQpERUNMQVJFIEBFaW5uYWhtZW4gVEFCTEUgKElkIElOVCBJREVOVElUWSwgVGV4dCBWQVJDSEFSK" +
                        "DEwMCksIEJldHJhZyBNT05FWSk7DQpERUNMQVJFIEBBdXNnYWJlbiAgVEFCTEUgKElkIElOVCBJREVOV" +
                        "ElUWSwgVGV4dCBWQVJDSEFSKDEwMCksIEJldHJhZyBNT05FWSk7DQoNCi0tIEVpbm5haG1lbg0KSU5TR" +
                        "VJUIElOVE8gQEVpbm5haG1lbiAoVGV4dCwgQmV0cmFnKQ0KICBTRUxFQ1QgTFRSSU0oUlRSSU0oQmV6Z" +
                        "WljaG51bmcpKSwgQmV0cmFnDQogIEZST00gZGJvLmZuV2hHZXRGaW5hbnpwbGFuKG51bGwsIEBHZXREY" +
                        "XRlKQ0KICBXSEVSRSBCZ0thdGVnb3JpZUNvZGUgPSAxDQogICAgQU5EIChCZXRyYWcgPD4gJDAuMDAgT" +
                        "1IgKEJnS2F0ZWdvcmllQ29kZSA9IDEgQU5EIEJnR3J1cHBlQ29kZSBMSUtFICdbMC05XSUnKSk7DQoNC" +
                        "i0tIEF1c2dhYmVuIC8gS8O8cnp1bmdlbg0KSU5TRVJUIElOVE8gQEF1c2dhYmVuIChUZXh0LCBCZXRyY" +
                        "WcpDQogIFNFTEVDVA0KICAgIENBU0UNCiAgICAgIFdIRU4gQmV6ZWljaG51bmcgTElLRSAnTWVkLiBHc" +
                        "nVuZCUoS1ZHKScgVEhFTiAnS1ZHIFByw6RtaWVuJw0KICAgICAgV0hFTiBCZXplaWNobnVuZyBMSUtFI" +
                        "CdNZWQuIEdydW5kJShWVkcpJyBUSEVOICdWVkcgUHLDpG1pZW4nDQogICAgICBFTFNFIExUUklNKFJUU" +
                        "klNKEJlemVpY2hudW5nKSkNCiAgICBFTkQsDQogICAgQ0FTRQ0KICAgICAgV0hFTiBCZ0thdGVnb3JpZ" +
                        "UNvZGUgPSAyIFRIRU4gQmV0cmFnDQogICAgICBFTFNFIC1CZXRyYWcNCiAgICBFTkQNCiAgRlJPTSBkY" +
                        "m8uZm5XaEdldEZpbmFuenBsYW4obnVsbCwgQEdldERhdGUpDQogIFdIRVJFIEJnS2F0ZWdvcmllQ29kZ" +
                        "SBJTiAoMiwgNCkgLS0gQXVzZ2FiZW4gLyBLw7xyenVuZ2VuDQogICAgQU5EIChCZXRyYWcgPD4gJDAuM" +
                        "DAgT1IgKEJnS2F0ZWdvcmllQ29kZSA9IDIgQU5EIEJnR3J1cHBlQ29kZSBMSUtFICdbMC05XSUnKSk7D" +
                        "QoNClNFTEVDVA0KICBUZXh0RWluID0gRUlOLlRleHQsIEJldHJhZ0VpbiA9IEVJTi5CZXRyYWcsDQogI" +
                        "FRleHRBdXMgPSBBVVMuVGV4dCwgQmV0cmFnQXVzID0gQVVTLkJldHJhZw0KRlJPTSBARWlubmFobWVuI" +
                        "CAgICAgICBFSU4NCiAgRlVMTCBKT0lOIEBBdXNnYWJlbiAgQVVTIE9OIEFVUy5JZCA9IEVJTi5JZDs=";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel3,
                        this.xrLabel1,
                        this.xrLabel2,
                        this.xrLabel4});
            this.Detail.Dpi = 254F;
            this.Detail.Height = 46;
            this.Detail.Name = "Detail";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TextAus", "")});
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel3.Location = new System.Drawing.Point(940, 0);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(25, 5, 0, 0, 254F);
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(699, 46);
            this.xrLabel3.Text = "xrLabel1";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TextEin", "")});
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel1.Location = new System.Drawing.Point(8, 0);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(734, 46);
            this.xrLabel1.Text = "xrLabel1";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragEin", "{0:n2}")});
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel2.Location = new System.Drawing.Point(742, 0);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(180, 46);
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragAus", "{0:n2}")});
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel4.Location = new System.Drawing.Point(1662, 0);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(180, 45);
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel4.WordWrap = false;
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail});
            this.DataSource = this.sqlQuery1;
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(254, 25, 46, 254);
            this.Name = "Report";
            this.PageHeight = 2794;
            this.PageWidth = 2159;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'DECLARE @GetDate DATETIME;
SET @GetDate = GETDATE();


DECLARE @Einnahmen TABLE (Id INT IDENTITY, Text VARCHAR(100), Betrag MONEY);
DECLARE @Ausgaben  TABLE (Id INT IDENTITY, Text VARCHAR(100), Betrag MONEY);

-- Einnahmen
INSERT INTO @Einnahmen (Text, Betrag)
  SELECT LTRIM(RTRIM(Bezeichnung)), Betrag
  FROM dbo.fnWhGetFinanzplan({BgBudgetID}, @GetDate)
  WHERE BgKategorieCode = 1
    AND (Betrag <> $0.00 OR (BgKategorieCode = 1 AND BgGruppeCode LIKE ''[0-9]%''));

-- Ausgaben / Kürzungen
INSERT INTO @Ausgaben (Text, Betrag)
  SELECT
    CASE
      WHEN Bezeichnung LIKE ''Med. Grund%(KVG)'' THEN ''KVG Prämien''
      WHEN Bezeichnung LIKE ''Med. Grund%(VVG)'' THEN ''VVG Prämien''
      ELSE LTRIM(RTRIM(Bezeichnung))
    END,
    CASE
      WHEN BgKategorieCode = 2 THEN Betrag
      ELSE -Betrag
    END
  FROM dbo.fnWhGetFinanzplan({BgBudgetID}, @GetDate)
  WHERE BgKategorieCode IN (2, 4) -- Ausgaben / Kürzungen
    AND (Betrag <> $0.00 OR (BgKategorieCode = 2 AND BgGruppeCode LIKE ''[0-9]%''));

SELECT
  TextEin = EIN.Text, BetragEin = EIN.Betrag,
  TextAus = AUS.Text, BetragAus = AUS.Betrag
FROM @Einnahmen        EIN
  FULL JOIN @Ausgaben  AUS ON AUS.Id = EIN.Id;' ,  null ,  N'ShVerfuegungMonatsbudget' ,  null );


INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShVerfuegungMonatsbudget_Personen' ,  N'Personen' , 1,  N'<!--
AssemblyName=DevExpress%2EXtraReports%2C%20Version%3D1%2E7%2E10%2E0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4
AssemblyLocation=c:\windows\assembly\gac\devexpress.xtrareports\1.7.10.0__79868b8147b5eae4\devexpress.xtrareports.dll
TypeName=DevExpress.XtraReports.UI.XtraReport
Localization=de-DE
-->
<SOAP-ENV:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:SOAP-ENC="http://schemas.xmlsoap.org/soap/encoding/" xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/" xmlns:clr="http://schemas.microsoft.com/soap/encoding/clr/1.0" SOAP-ENV:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
<SOAP-ENV:Body>
<a1:ReportStorage id="ref-1" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<BandCount>3</BandCount>
<Band0 href="#ref-6"/>
<Band1 href="#ref-7"/>
<Band2 href="#ref-8"/>
<Visible>true</Visible>
<Tag id="ref-9"></Tag>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-10">Report</Name>
<Style_X_Font id="ref-11">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor id="ref-12">ControlText</Style_X_ForeColor>
<Style_X_BackColor id="ref-13">Transparent</Style_X_BackColor>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>true</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>true</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>true</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>true</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>true</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>true</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>100</width>
<height>23</height>
</Bounds>
<Text href="#ref-9"/>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>100</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<DataSource id="ref-14">dataSource</DataSource>
<UseDefaultPrinterSettings>false</UseDefaultPrinterSettings>
<ReportUnit xsi:type="a2:ReportUnit" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">HundredthsOfAnInch</ReportUnit>
<Landscape>false</Landscape>
<PaperKind xsi:type="a5:PaperKind" xmlns:a5="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Printing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">A4</PaperKind>
<PaperName href="#ref-9"/>
<Margins xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>100</x>
<y>100</y>
<width>5</width>
<height>100</height>
</Margins>
<HtmlCompressed>false</HtmlCompressed>
<PageSize xsi:type="a4:Size" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<width>827</width>
<height>1169</height>
</PageSize>
<StyleSheet_X_StyleCount>0</StyleSheet_X_StyleCount>
<ShowPreviewMarginLines>true</ShowPreviewMarginLines>
<ScriptLanguage xsi:type="a6:ScriptLanguage" xmlns:a6="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">CSharp</ScriptLanguage>
<Watermark_X_Text href="#ref-9"/>
<Watermark_X_Font id="ref-15">Verdana, 36pt</Watermark_X_Font>
<Watermark_X_ForeColor id="ref-16">Red</Watermark_X_ForeColor>
<Watermark_X_Transparency>50</Watermark_X_Transparency>
<Watermark_X_TextDirection xsi:type="a7:DirectionMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">ForwardDiagonal</Watermark_X_TextDirection>
<Watermark_X_Image xsi:type="xsd:anyType" xsi:null="1"/>
<Watermark_X_ImageAlign xsi:type="a4:ContentAlignment" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">MiddleCenter</Watermark_X_ImageAlign>
<Watermark_X_ImageViewMode xsi:type="a7:ImageViewMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Clip</Watermark_X_ImageViewMode>
<Watermark_X_ImageTiling>false</Watermark_X_ImageTiling>
<Watermark_X_PageRange href="#ref-9"/>
<Watermark_X_ShowBehind>true</Watermark_X_ShowBehind>
<DefaultPrinterSettingsUsing_X_UseMargins>false</DefaultPrinterSettingsUsing_X_UseMargins>
<DefaultPrinterSettingsUsing_X_UsePaperKind>false</DefaultPrinterSettingsUsing_X_UsePaperKind>
<DefaultPrinterSettingsUsing_X_UseLandscape>false</DefaultPrinterSettingsUsing_X_UseLandscape>
<ShrinkSubReportIconArea>true</ShrinkSubReportIconArea>
</a1:ReportStorage>
<a1:ObjectStorage id="ref-6" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName id="ref-17">DevExpress.XtraReports, Version=1.7.10.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</Type_X_AssemblyName>
<Type_X_TypeName id="ref-18">DevExpress.XtraReports.UI.DetailBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-19">Detail</Name>
<Style_X_Font id="ref-20">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-12"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>100</width>
<height>23</height>
</Bounds>
<Text href="#ref-9"/>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>18</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<PrintOnEmptyDataSource>true</PrintOnEmptyDataSource>
<MultiColumn_X_ColumnCount>1</MultiColumn_X_ColumnCount>
<MultiColumn_X_Direction xsi:type="a2:ColumnDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">DownThenAcross</MultiColumn_X_Direction>
<MultiColumn_X_ColumnWidth>0</MultiColumn_X_ColumnWidth>
<MultiColumn_X_ColumnSpacing>0</MultiColumn_X_ColumnSpacing>
<MultiColumn_X_Mode xsi:type="a2:MultiColumnMode" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">UseColumnCount</MultiColumn_X_Mode>
<RepeatCountOnEmptyDataSource>1</RepeatCountOnEmptyDataSource>
<ItemCount>3</ItemCount>
<Item0 href="#ref-21"/>
<Item1 href="#ref-22"/>
<Item2 href="#ref-23"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-7" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName id="ref-24">DevExpress.XtraReports.UI.ReportHeaderBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-25">ReportHeader</Name>
<Style_X_Font id="ref-26">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-12"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>100</width>
<height>23</height>
</Bounds>
<Text href="#ref-9"/>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>22</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>5</ItemCount>
<Item0 href="#ref-27"/>
<Item1 href="#ref-28"/>
<Item2 href="#ref-29"/>
<Item3 href="#ref-30"/>
<Item4 href="#ref-31"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-8" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName id="ref-32">DevExpress.XtraReports.UI.ReportFooterBand</Type_X_TypeName>
<Visible>false</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-33">ReportFooter</Name>
<Style_X_Font id="ref-34">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-12"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>100</width>
<height>23</height>
</Bounds>
<Text href="#ref-9"/>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>8</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<PrintAtBottom>false</PrintAtBottom>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-21" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName id="ref-35">DevExpress.XtraReports.UI.XRLabel</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-36">txtHeimatort</Name>
<Style_X_Font id="ref-37">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor id="ref-38">Black</Style_X_ForeColor>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-39">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-40">Nationalitaet</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-9"/>
<BindingItem0_X_DataSource href="#ref-14"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>572</x>
<y>0</y>
<width>152</width>
<height>15</height>
</Bounds>
<Text id="ref-41">Heimatort</Text>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>true</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-22" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-35"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-42">txtGebDat</Name>
<Style_X_Font id="ref-43">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-38"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName href="#ref-39"/>
<BindingItem0_X_DataMember id="ref-44">Geburtsdatum</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-45">{0:dd.MM.yyyy}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-14"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>464</x>
<y>0</y>
<width>109</width>
<height>15</height>
</Bounds>
<Text id="ref-46">GebDat</Text>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>true</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-47">{0:dd.MM.yyyy}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-23" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-35"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-48">txtName</Name>
<Style_X_Font id="ref-49">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-38"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName href="#ref-39"/>
<BindingItem0_X_DataMember id="ref-50">Name</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-9"/>
<BindingItem0_X_DataSource href="#ref-14"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>155</x>
<y>0</y>
<width>307</width>
<height>15</height>
</Bounds>
<Text id="ref-51">Name</Text>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>true</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-27" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-35"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-52">xrLabel4</Name>
<Style_X_Font id="ref-53">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-38"/>
<Style_X_BackColor id="ref-54">Silver</Style_X_BackColor>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>2</y>
<width>147</width>
<height>15</height>
</Bounds>
<Text id="ref-55">Unterstützte Personen</Text>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-28" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName id="ref-56">DevExpress.XtraReports.UI.XRLine</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-57">xrLine1</Name>
<Style_X_Font id="ref-58">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-38"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>155</x>
<y>16</y>
<width>570</width>
<height>2</height>
</Bounds>
<Text href="#ref-9"/>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-29" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-35"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-59">xrLabel3</Name>
<Style_X_Font id="ref-60">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-38"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>572</x>
<y>0</y>
<width>152</width>
<height>15</height>
</Bounds>
<Text id="ref-61">Nationalität</Text>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-30" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-35"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-62">xrLabel2</Name>
<Style_X_Font id="ref-63">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-38"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>464</x>
<y>0</y>
<width>101</width>
<height>15</height>
</Bounds>
<Text id="ref-64">Geburtsdatum</Text>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-31" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-35"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-65">xrLabel1</Name>
<Style_X_Font id="ref-66">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-38"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>155</x>
<y>0</y>
<width>307</width>
<height>15</height>
</Bounds>
<Text id="ref-67">Name</Text>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
</SOAP-ENV:Body>
</SOAP-ENV:Envelope>' ,  null ,  N'SELECT
  Name              = PRS.NameVorname,
  AHV               = IsNull(PRS.AHVNummer, ''''),
  PRS.Geburtsdatum,
  PRS.Nationalitaet
FROM BgBudget                       BBG
  INNER JOIN BgFinanzplan_BaPerson  SPP ON SPP.BgFinanzplanID = BBG.BgFinanzplanID
  INNER JOIN vwPerson               PRS ON PRS.BaPersonID = SPP.BaPersonID
WHERE BBG.BgBudgetID = {BgBudgetID} AND SPP.IstUnterstuetzt = 1' ,  null ,  N'ShVerfuegungMonatsbudget' ,  null );


