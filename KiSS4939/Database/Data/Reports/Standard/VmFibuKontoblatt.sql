-- Insert Script for VmFibuKontoblatt
-- MD5:0XD17D262CC7F7B9839D8046914DA86AE9_0X23773A2FD6A73BAAA39DDD4BCBFE7016_0XFF4E1491744A428CC716DBF6216410BC
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'VmFibuKontoblatt') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('VmFibuKontoblatt', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'VmFibuKontoblatt';
--SQLCHECK_IGNORE--
UPDATE QRY
SET QueryName =  N'VmFibuKontoblatt' , UserText =  N'VM - Fibu Kontoblatt' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>de-CH</Localization>
///   <References>
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Drawing\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Configuration\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Data.SqlXml\v4.0_4.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Security\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\DevExpress.Utils.v6.2.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Forms\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Forms.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Accessibility\v4.0_4.0.0.0__b03f5f7f11d50a3a\Accessibility.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Serialization.Formatters.Soap\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Runtime.Serialization.Formatters.Soap.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Deployment\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Deployment.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Design\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Design.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Data\v4.0_4.0.0.0__b77a5c561934e089\System.Data.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.VisualC\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualC.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Transactions\v4.0_4.0.0.0__b77a5c561934e089\System.Transactions.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.EnterpriseServices\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.EnterpriseServices.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.DirectoryServices\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Remoting\v4.0_4.0.0.0__b77a5c561934e089\System.Runtime.Remoting.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Web\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Framework\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Framework.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Xaml\v4.0_4.0.0.0__b77a5c561934e089\System.Xaml.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Caching\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Runtime.Caching.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Web.ApplicationServices\v4.0_4.0.0.0__31bf3856ad364e35\System.Web.ApplicationServices.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Core\v4.0_4.0.0.0__b77a5c561934e089\System.Core.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Numerics\v4.0_4.0.0.0__b77a5c561934e089\System.Numerics.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Web.Services\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.Services.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Utilities.v4.0\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Utilities.v4.0.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.DirectoryServices.Protocols\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.Protocols.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Tasks.v4.0\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Tasks.v4.0.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceProcess\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.ServiceProcess.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Configuration.Install\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.Install.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Serialization\v4.0_4.0.0.0__b77a5c561934e089\System.Runtime.Serialization.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\SMDiagnostics\v4.0_4.0.0.0__b77a5c561934e089\SMDiagnostics.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.DurableInstancing\v4.0_4.0.0.0__31bf3856ad364e35\System.Runtime.DurableInstancing.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Xml.Linq\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.Linq.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Web.RegularExpressions\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.RegularExpressions.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Drawing.Design\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.Design.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Data.OracleClient\v4.0_4.0.0.0__b77a5c561934e089\System.Data.OracleClient.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\DevExpress.Data.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\KiSS4.DB.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Kiss.Interfaces.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\FluentValidation.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Microsoft.Practices.Unity.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Ionic.Zip.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\log4net.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\SharpLibrary.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Kiss.BL.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Kiss.Model.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel\v4.0_4.0.0.0__b77a5c561934e089\System.ServiceModel.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.IdentityModel\v4.0_4.0.0.0__b77a5c561934e089\System.IdentityModel.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Messaging\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Messaging.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.IdentityModel.Selectors\v4.0_4.0.0.0__b77a5c561934e089\System.IdentityModel.Selectors.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Transactions.Bridge\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Transactions.Bridge.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Activation\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Activation.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Activities\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Activities.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Activities\v4.0_4.0.0.0__31bf3856ad364e35\System.Activities.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\Microsoft.VisualBasic.Activities.Compiler\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualBasic.Activities.Compiler.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.VisualBasic\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualBasic.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Management\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Management.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.JScript\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.JScript.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Activities.DurableInstancing\v4.0_4.0.0.0__31bf3856ad364e35\System.Activities.DurableInstancing.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Xaml.Hosting\v4.0_4.0.0.0__31bf3856ad364e35\System.Xaml.Hosting.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\KiSS.Common.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Autofac.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Common.Logging.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\HtmlAgilityPack.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Kiss.Database.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\WPFLocalizeExtension.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\XAMLMarkupExtensions.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtBelegNr;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtSaldo;
        private DevExpress.XtraReports.UI.XRLabel txtBetragHaben;
        private DevExpress.XtraReports.UI.XRLabel txtBetragSoll;
        private DevExpress.XtraReports.UI.XRLabel txtGKtoNr;
        private DevExpress.XtraReports.UI.XRLabel txtText;
        private DevExpress.XtraReports.UI.XRLabel txtBuchungsDatum;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel txtGeburtsdatum;
        private DevExpress.XtraReports.UI.XRLabel txtKontoNrBereich;
        private DevExpress.XtraReports.UI.XRLabel txtDatumBereich;
        private DevExpress.XtraReports.UI.XRLabel TextBox12;
        private DevExpress.XtraReports.UI.XRLabel TextBox11;
        private DevExpress.XtraReports.UI.XRLabel TextBox10;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel TextBox8;
        private DevExpress.XtraReports.UI.XRLabel TextBox7;
        private DevExpress.XtraReports.UI.XRLabel TextBox6;
        private DevExpress.XtraReports.UI.XRLabel TextBox5;
        private DevExpress.XtraReports.UI.XRLabel TextBox4;
        private DevExpress.XtraReports.UI.XRLabel TextBox3;
        private DevExpress.XtraReports.UI.XRLabel TextBox2;
        private DevExpress.XtraReports.UI.XRLabel txtMandant;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel txtKtoName;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLine Line4;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLabel BetragHaben1;
        private DevExpress.XtraReports.UI.XRLabel BetragSoll1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLabel Label1;
        private DevExpress.XtraReports.UI.XRControlStyle Style1;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kA" +
                        "AAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAA" +
                        "AAAAbcKREVDTEFSRSBARmJQZXJpb2RlSUQgIGludCwNCiAgICAgICAgQEtvbnRvTnJWb24gICBpbnQsD" +
                        "QogICAgICAgIEBLb250b05yQmlzICAgaW50LA0KICAgICAgICBARGF0dW1Wb24gICAgIGRhdGV0aW1lL" +
                        "A0KICAgICAgICBARGF0dW1CaXMgICAgIGRhdGV0aW1lDQoNClNFTEVDVCBARmJQZXJpb2RlSUQgPSBud" +
                        "WxsLA0KICAgICAgIEBLb250b05yVm9uID0gbnVsbCwNCiAgICAgICBAS29udG9OckJpcyA9IG51bGwsD" +
                        "QogICAgICAgQERhdHVtVm9uID0gbnVsbCwNCiAgICAgICBARGF0dW1CaXMgPSBudWxsDQoNCkNSRUFUR" +
                        "SBUQUJMRSAjcmVzdWx0ICgNCiAgSUQgICAgICAgICAgICAgIGludCwNCiAgRmJCdWNodW5nSUQgICAgI" +
                        "GludCwNCiAgQnVjaHVuZ3NEYXR1bSAgIGRhdGV0aW1lLA0KICBUZXh0ICAgICAgICAgICAgdmFyY2hhc" +
                        "igyMDApLA0KICBLdG9OYW1lICAgICAgICAgdmFyY2hhcig2MCksDQogIEdLdG9OciAgICAgICAgICBpb" +
                        "nQsDQogIEJldHJhZ1NvbGwgICAgICBtb25leSwNCiAgQmV0cmFnSGFiZW4gICAgIG1vbmV5LA0KICBTY" +
                        "WxkbyAgICAgICAgICAgbW9uZXksDQogIEJlbGVnTnIgICAgICAgICB2YXJjaGFyKDE1KSwNCiAgS29ud" +
                        "G9OckJlcmVpY2ggIHZhcmNoYXIoMjApLA0KICBEYXR1bUJlcmVpY2ggICAgdmFyY2hhcigxMDApLA0KI" +
                        "CBHZWJ1cnRzZGF0dW0gICAgZGF0ZXRpbWUsDQogIE1hbmRhbnQgICAgICAgICB2YXJjaGFyKDIwMCkNC" +
                        "ikNCg0KDQpJTlNFUlQgSU5UTyAjcmVzdWx0DQpFWEVDVVRFIHNwX2V4ZWN1dGVzcWwgTidFWEVDIHNwR" +
                        "mJHZXRLb250b2JsYWV0dGVyIEBGYlBlcmlvZGVJRCwgQEtvbnRvTnJWb24sIEBLb250b05yQmlzLCBAR" +
                        "GF0dW1Wb24sIEBEYXR1bUJpcycsDQogIE4nQEZiUGVyaW9kZUlEIGludCwgQEtvbnRvTnJWb24gaW50L" +
                        "CBAS29udG9OckJpcyBpbnQsIEBEYXR1bVZvbiBkYXRldGltZSwgQERhdHVtQmlzIGRhdGV0aW1lJywNC" +
                        "iAgQEZiUGVyaW9kZUlELCBAS29udG9OclZvbiwgQEtvbnRvTnJCaXMsIEBEYXR1bVZvbiwgQERhdHVtQ" +
                        "mlzDQoNClVQREFURSBUTVANCiAgU0VUIEdlYnVydHNkYXR1bSA9IFBSUy5HZWJ1cnRzZGF0dW0sDQogI" +
                        "CAgTWFuZGFudCAgICAgICAgPSBQUlMuTmFtZSArIElzTnVsbCgnLCAnICsgUFJTLlZvcm5hbWUsJycpD" +
                        "QpGUk9NICNyZXN1bHQgICAgICAgICAgIFRNUA0KICBMRUZUIEpPSU4gRmJQZXJpb2RlICBQRVIgT04gU" +
                        "EVSLkZiUGVyaW9kZUlEID0gQEZiUGVyaW9kZUlEDQogIExFRlQgSk9JTiBCYVBlcnNvbiAgUFJTIE9OI" +
                        "FBSUy5CYVBlcnNvbklEID0gUEVSLkJhUGVyc29uSUQNCg0KDQpTRUxFQ1QgKiBGUk9NICNyZXN1bHQNC" +
                        "g0KRFJPUCBUQUJMRSAjcmVzdWx0";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.txtBelegNr = new DevExpress.XtraReports.UI.XRLabel();
            this.txtSaldo = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBetragHaben = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBetragSoll = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGKtoNr = new DevExpress.XtraReports.UI.XRLabel();
            this.txtText = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBuchungsDatum = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGeburtsdatum = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKontoNrBereich = new DevExpress.XtraReports.UI.XRLabel();
            this.txtDatumBereich = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox12 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox11 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox10 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.TextBox8 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox7 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox6 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox5 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox4 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox3 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox2 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtMandant = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKtoName = new DevExpress.XtraReports.UI.XRLabel();
            this.Line4 = new DevExpress.XtraReports.UI.XRLine();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.BetragHaben1 = new DevExpress.XtraReports.UI.XRLabel();
            this.BetragSoll1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.Label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            this.Style1 = new DevExpress.XtraReports.UI.XRControlStyle();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtBelegNr,
                        this.txtSaldo,
                        this.txtBetragHaben,
                        this.txtBetragSoll,
                        this.txtGKtoNr,
                        this.txtText,
                        this.txtBuchungsDatum});
            this.Detail.Height = 23;
            this.Detail.KeepTogether = true;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBackColor = false;
            this.Detail.ParentStyleUsing.UseBorderColor = false;
            this.Detail.ParentStyleUsing.UseBorders = false;
            this.Detail.ParentStyleUsing.UseBorderWidth = false;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.ParentStyleUsing.UseForeColor = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtGeburtsdatum,
                        this.txtKontoNrBereich,
                        this.txtDatumBereich,
                        this.TextBox12,
                        this.TextBox11,
                        this.TextBox10,
                        this.Label4,
                        this.Line1,
                        this.TextBox8,
                        this.TextBox7,
                        this.TextBox6,
                        this.TextBox5,
                        this.TextBox4,
                        this.TextBox3,
                        this.TextBox2,
                        this.txtMandant});
            this.PageHeader.Height = 148;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.ParentStyleUsing.UseBackColor = false;
            this.PageHeader.ParentStyleUsing.UseBorderColor = false;
            this.PageHeader.ParentStyleUsing.UseBorders = false;
            this.PageHeader.ParentStyleUsing.UseBorderWidth = false;
            this.PageHeader.ParentStyleUsing.UseFont = false;
            this.PageHeader.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtKtoName});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("KtoName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 25;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Line4,
                        this.Line3,
                        this.BetragHaben1,
                        this.BetragSoll1});
            this.GroupFooter1.Height = 40;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorders = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter1.ParentStyleUsing.UseFont = false;
            this.GroupFooter1.ParentStyleUsing.UseForeColor = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel1,
                        this.xrPageInfo2,
                        this.xrPageInfo1,
                        this.Label6,
                        this.Line2,
                        this.Label1});
            this.PageFooter.Height = 60;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // txtBelegNr
            // 
            this.txtBelegNr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BelegNr", "")});
            this.txtBelegNr.Font = new System.Drawing.Font("Arial", 8F);
            this.txtBelegNr.ForeColor = System.Drawing.Color.Black;
            this.txtBelegNr.Location = new System.Drawing.Point(68, 0);
            this.txtBelegNr.Multiline = true;
            this.txtBelegNr.Name = "txtBelegNr";
            this.txtBelegNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBelegNr.ParentStyleUsing.UseBackColor = false;
            this.txtBelegNr.ParentStyleUsing.UseBorderColor = false;
            this.txtBelegNr.ParentStyleUsing.UseBorders = false;
            this.txtBelegNr.ParentStyleUsing.UseBorderWidth = false;
            this.txtBelegNr.ParentStyleUsing.UseFont = false;
            this.txtBelegNr.ParentStyleUsing.UseForeColor = false;
            this.txtBelegNr.Size = new System.Drawing.Size(62, 18);
            this.txtBelegNr.Text = "BelegNr";
            // 
            // txtSaldo
            // 
            this.txtSaldo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Saldo", "{0:n2}")});
            this.txtSaldo.Font = new System.Drawing.Font("Arial", 8F);
            this.txtSaldo.ForeColor = System.Drawing.Color.Black;
            this.txtSaldo.Location = new System.Drawing.Point(617, 0);
            this.txtSaldo.Multiline = true;
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtSaldo.ParentStyleUsing.UseBackColor = false;
            this.txtSaldo.ParentStyleUsing.UseBorderColor = false;
            this.txtSaldo.ParentStyleUsing.UseBorders = false;
            this.txtSaldo.ParentStyleUsing.UseBorderWidth = false;
            this.txtSaldo.ParentStyleUsing.UseFont = false;
            this.txtSaldo.ParentStyleUsing.UseForeColor = false;
            this.txtSaldo.Size = new System.Drawing.Size(83, 18);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtSaldo.Summary = xrSummary1;
            this.txtSaldo.Text = "Saldo";
            this.txtSaldo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtBetragHaben
            // 
            this.txtBetragHaben.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragHaben", "{0:n2}")});
            this.txtBetragHaben.Font = new System.Drawing.Font("Arial", 8F);
            this.txtBetragHaben.ForeColor = System.Drawing.Color.Black;
            this.txtBetragHaben.Location = new System.Drawing.Point(531, 0);
            this.txtBetragHaben.Multiline = true;
            this.txtBetragHaben.Name = "txtBetragHaben";
            this.txtBetragHaben.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetragHaben.ParentStyleUsing.UseBackColor = false;
            this.txtBetragHaben.ParentStyleUsing.UseBorderColor = false;
            this.txtBetragHaben.ParentStyleUsing.UseBorders = false;
            this.txtBetragHaben.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetragHaben.ParentStyleUsing.UseFont = false;
            this.txtBetragHaben.ParentStyleUsing.UseForeColor = false;
            this.txtBetragHaben.Size = new System.Drawing.Size(83, 18);
            xrSummary2.FormatString = "{0:#,##0.00}";
            this.txtBetragHaben.Summary = xrSummary2;
            this.txtBetragHaben.Text = "BetragHaben";
            this.txtBetragHaben.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtBetragSoll
            // 
            this.txtBetragSoll.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragSoll", "{0:n2}")});
            this.txtBetragSoll.Font = new System.Drawing.Font("Arial", 8F);
            this.txtBetragSoll.ForeColor = System.Drawing.Color.Black;
            this.txtBetragSoll.Location = new System.Drawing.Point(444, 0);
            this.txtBetragSoll.Multiline = true;
            this.txtBetragSoll.Name = "txtBetragSoll";
            this.txtBetragSoll.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetragSoll.ParentStyleUsing.UseBackColor = false;
            this.txtBetragSoll.ParentStyleUsing.UseBorderColor = false;
            this.txtBetragSoll.ParentStyleUsing.UseBorders = false;
            this.txtBetragSoll.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetragSoll.ParentStyleUsing.UseFont = false;
            this.txtBetragSoll.ParentStyleUsing.UseForeColor = false;
            this.txtBetragSoll.Size = new System.Drawing.Size(83, 18);
            xrSummary3.FormatString = "{0:#,##0.00}";
            this.txtBetragSoll.Summary = xrSummary3;
            this.txtBetragSoll.Text = "BetragSoll";
            this.txtBetragSoll.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtGKtoNr
            // 
            this.txtGKtoNr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GKtoNr", "")});
            this.txtGKtoNr.Font = new System.Drawing.Font("Arial", 8F);
            this.txtGKtoNr.ForeColor = System.Drawing.Color.Black;
            this.txtGKtoNr.Location = new System.Drawing.Point(138, 0);
            this.txtGKtoNr.Multiline = true;
            this.txtGKtoNr.Name = "txtGKtoNr";
            this.txtGKtoNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGKtoNr.ParentStyleUsing.UseBackColor = false;
            this.txtGKtoNr.ParentStyleUsing.UseBorderColor = false;
            this.txtGKtoNr.ParentStyleUsing.UseBorders = false;
            this.txtGKtoNr.ParentStyleUsing.UseBorderWidth = false;
            this.txtGKtoNr.ParentStyleUsing.UseFont = false;
            this.txtGKtoNr.ParentStyleUsing.UseForeColor = false;
            this.txtGKtoNr.Size = new System.Drawing.Size(50, 18);
            this.txtGKtoNr.Text = "GKtoNr";
            // 
            // txtText
            // 
            this.txtText.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text", "")});
            this.txtText.Font = new System.Drawing.Font("Arial", 8F);
            this.txtText.ForeColor = System.Drawing.Color.Black;
            this.txtText.Location = new System.Drawing.Point(188, 0);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtText.ParentStyleUsing.UseBackColor = false;
            this.txtText.ParentStyleUsing.UseBorderColor = false;
            this.txtText.ParentStyleUsing.UseBorders = false;
            this.txtText.ParentStyleUsing.UseBorderWidth = false;
            this.txtText.ParentStyleUsing.UseFont = false;
            this.txtText.ParentStyleUsing.UseForeColor = false;
            this.txtText.Size = new System.Drawing.Size(253, 18);
            this.txtText.Text = "Text";
            // 
            // txtBuchungsDatum
            // 
            this.txtBuchungsDatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BuchungsDatum", "{0:dd.MM.yyyy}")});
            this.txtBuchungsDatum.Font = new System.Drawing.Font("Arial", 8F);
            this.txtBuchungsDatum.ForeColor = System.Drawing.Color.Black;
            this.txtBuchungsDatum.Location = new System.Drawing.Point(0, 0);
            this.txtBuchungsDatum.Multiline = true;
            this.txtBuchungsDatum.Name = "txtBuchungsDatum";
            this.txtBuchungsDatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBuchungsDatum.ParentStyleUsing.UseBackColor = false;
            this.txtBuchungsDatum.ParentStyleUsing.UseBorderColor = false;
            this.txtBuchungsDatum.ParentStyleUsing.UseBorders = false;
            this.txtBuchungsDatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtBuchungsDatum.ParentStyleUsing.UseFont = false;
            this.txtBuchungsDatum.ParentStyleUsing.UseForeColor = false;
            this.txtBuchungsDatum.Size = new System.Drawing.Size(66, 18);
            xrSummary4.FormatString = "{0:dd/MM/yyyy}";
            this.txtBuchungsDatum.Summary = xrSummary4;
            this.txtBuchungsDatum.Text = "BuchungsDatum";
            // 
            // txtGeburtsdatum
            // 
            this.txtGeburtsdatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Geburtsdatum", "{0:dd.MM.yyyy}")});
            this.txtGeburtsdatum.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.txtGeburtsdatum.ForeColor = System.Drawing.Color.Black;
            this.txtGeburtsdatum.Location = new System.Drawing.Point(544, 58);
            this.txtGeburtsdatum.Multiline = true;
            this.txtGeburtsdatum.Name = "txtGeburtsdatum";
            this.txtGeburtsdatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGeburtsdatum.ParentStyleUsing.UseBackColor = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorderColor = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorders = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseFont = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseForeColor = false;
            this.txtGeburtsdatum.Size = new System.Drawing.Size(100, 20);
            xrSummary5.FormatString = "{0:dd/MM/yyyy}";
            this.txtGeburtsdatum.Summary = xrSummary5;
            this.txtGeburtsdatum.Text = "Geburtsdatum";
            // 
            // txtKontoNrBereich
            // 
            this.txtKontoNrBereich.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KontoNrBereich", "")});
            this.txtKontoNrBereich.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.txtKontoNrBereich.ForeColor = System.Drawing.Color.Black;
            this.txtKontoNrBereich.Location = new System.Drawing.Point(64, 58);
            this.txtKontoNrBereich.Multiline = true;
            this.txtKontoNrBereich.Name = "txtKontoNrBereich";
            this.txtKontoNrBereich.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKontoNrBereich.ParentStyleUsing.UseBackColor = false;
            this.txtKontoNrBereich.ParentStyleUsing.UseBorderColor = false;
            this.txtKontoNrBereich.ParentStyleUsing.UseBorders = false;
            this.txtKontoNrBereich.ParentStyleUsing.UseBorderWidth = false;
            this.txtKontoNrBereich.ParentStyleUsing.UseFont = false;
            this.txtKontoNrBereich.ParentStyleUsing.UseForeColor = false;
            this.txtKontoNrBereich.Size = new System.Drawing.Size(100, 20);
            this.txtKontoNrBereich.Text = "KontoNrBereich";
            // 
            // txtDatumBereich
            // 
            this.txtDatumBereich.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "DatumBereich", "{0:dd.MM.yyyy}")});
            this.txtDatumBereich.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.txtDatumBereich.ForeColor = System.Drawing.Color.Black;
            this.txtDatumBereich.Location = new System.Drawing.Point(259, 58);
            this.txtDatumBereich.Multiline = true;
            this.txtDatumBereich.Name = "txtDatumBereich";
            this.txtDatumBereich.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtDatumBereich.ParentStyleUsing.UseBackColor = false;
            this.txtDatumBereich.ParentStyleUsing.UseBorderColor = false;
            this.txtDatumBereich.ParentStyleUsing.UseBorders = false;
            this.txtDatumBereich.ParentStyleUsing.UseBorderWidth = false;
            this.txtDatumBereich.ParentStyleUsing.UseFont = false;
            this.txtDatumBereich.ParentStyleUsing.UseForeColor = false;
            this.txtDatumBereich.Size = new System.Drawing.Size(196, 20);
            this.txtDatumBereich.Text = "DatumBereich";
            // 
            // TextBox12
            // 
            this.TextBox12.Font = new System.Drawing.Font("Arial", 9F);
            this.TextBox12.ForeColor = System.Drawing.Color.Black;
            this.TextBox12.Location = new System.Drawing.Point(467, 58);
            this.TextBox12.Multiline = true;
            this.TextBox12.Name = "TextBox12";
            this.TextBox12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox12.ParentStyleUsing.UseBackColor = false;
            this.TextBox12.ParentStyleUsing.UseBorderColor = false;
            this.TextBox12.ParentStyleUsing.UseBorders = false;
            this.TextBox12.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox12.ParentStyleUsing.UseFont = false;
            this.TextBox12.ParentStyleUsing.UseForeColor = false;
            this.TextBox12.Size = new System.Drawing.Size(70, 18);
            this.TextBox12.Text = "Geburtstag";
            // 
            // TextBox11
            // 
            this.TextBox11.Font = new System.Drawing.Font("Arial", 9F);
            this.TextBox11.ForeColor = System.Drawing.Color.Black;
            this.TextBox11.Location = new System.Drawing.Point(0, 58);
            this.TextBox11.Multiline = true;
            this.TextBox11.Name = "TextBox11";
            this.TextBox11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox11.ParentStyleUsing.UseBackColor = false;
            this.TextBox11.ParentStyleUsing.UseBorderColor = false;
            this.TextBox11.ParentStyleUsing.UseBorders = false;
            this.TextBox11.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox11.ParentStyleUsing.UseFont = false;
            this.TextBox11.ParentStyleUsing.UseForeColor = false;
            this.TextBox11.Size = new System.Drawing.Size(62, 18);
            this.TextBox11.Text = "Konto-Nr";
            // 
            // TextBox10
            // 
            this.TextBox10.Font = new System.Drawing.Font("Arial", 9F);
            this.TextBox10.ForeColor = System.Drawing.Color.Black;
            this.TextBox10.Location = new System.Drawing.Point(208, 58);
            this.TextBox10.Multiline = true;
            this.TextBox10.Name = "TextBox10";
            this.TextBox10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox10.ParentStyleUsing.UseBackColor = false;
            this.TextBox10.ParentStyleUsing.UseBorderColor = false;
            this.TextBox10.ParentStyleUsing.UseBorders = false;
            this.TextBox10.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox10.ParentStyleUsing.UseFont = false;
            this.TextBox10.ParentStyleUsing.UseForeColor = false;
            this.TextBox10.Size = new System.Drawing.Size(51, 18);
            this.TextBox10.Text = "Datum";
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial", 10F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(418, 0);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(281, 25);
            this.Label4.Text = "Buchhaltung - Kontoblätter";
            this.Label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.Location = new System.Drawing.Point(0, 125);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(706, 2);
            // 
            // TextBox8
            // 
            this.TextBox8.Font = new System.Drawing.Font("Arial", 8F);
            this.TextBox8.ForeColor = System.Drawing.Color.Black;
            this.TextBox8.Location = new System.Drawing.Point(188, 100);
            this.TextBox8.Multiline = true;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox8.ParentStyleUsing.UseBackColor = false;
            this.TextBox8.ParentStyleUsing.UseBorderColor = false;
            this.TextBox8.ParentStyleUsing.UseBorders = false;
            this.TextBox8.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox8.ParentStyleUsing.UseFont = false;
            this.TextBox8.ParentStyleUsing.UseForeColor = false;
            this.TextBox8.Size = new System.Drawing.Size(253, 18);
            this.TextBox8.Text = "Text";
            // 
            // TextBox7
            // 
            this.TextBox7.Font = new System.Drawing.Font("Arial", 8F);
            this.TextBox7.ForeColor = System.Drawing.Color.Black;
            this.TextBox7.Location = new System.Drawing.Point(617, 100);
            this.TextBox7.Multiline = true;
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox7.ParentStyleUsing.UseBackColor = false;
            this.TextBox7.ParentStyleUsing.UseBorderColor = false;
            this.TextBox7.ParentStyleUsing.UseBorders = false;
            this.TextBox7.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox7.ParentStyleUsing.UseFont = false;
            this.TextBox7.ParentStyleUsing.UseForeColor = false;
            this.TextBox7.Size = new System.Drawing.Size(83, 18);
            this.TextBox7.Text = "Saldo";
            this.TextBox7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox6
            // 
            this.TextBox6.Font = new System.Drawing.Font("Arial", 8F);
            this.TextBox6.ForeColor = System.Drawing.Color.Black;
            this.TextBox6.Location = new System.Drawing.Point(531, 100);
            this.TextBox6.Multiline = true;
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox6.ParentStyleUsing.UseBackColor = false;
            this.TextBox6.ParentStyleUsing.UseBorderColor = false;
            this.TextBox6.ParentStyleUsing.UseBorders = false;
            this.TextBox6.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox6.ParentStyleUsing.UseFont = false;
            this.TextBox6.ParentStyleUsing.UseForeColor = false;
            this.TextBox6.Size = new System.Drawing.Size(83, 18);
            this.TextBox6.Text = "Haben";
            this.TextBox6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox5
            // 
            this.TextBox5.Font = new System.Drawing.Font("Arial", 8F);
            this.TextBox5.ForeColor = System.Drawing.Color.Black;
            this.TextBox5.Location = new System.Drawing.Point(444, 100);
            this.TextBox5.Multiline = true;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox5.ParentStyleUsing.UseBackColor = false;
            this.TextBox5.ParentStyleUsing.UseBorderColor = false;
            this.TextBox5.ParentStyleUsing.UseBorders = false;
            this.TextBox5.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox5.ParentStyleUsing.UseFont = false;
            this.TextBox5.ParentStyleUsing.UseForeColor = false;
            this.TextBox5.Size = new System.Drawing.Size(83, 18);
            this.TextBox5.Text = "Soll";
            this.TextBox5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox4
            // 
            this.TextBox4.Font = new System.Drawing.Font("Arial", 8F);
            this.TextBox4.ForeColor = System.Drawing.Color.Black;
            this.TextBox4.Location = new System.Drawing.Point(138, 100);
            this.TextBox4.Multiline = true;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox4.ParentStyleUsing.UseBackColor = false;
            this.TextBox4.ParentStyleUsing.UseBorderColor = false;
            this.TextBox4.ParentStyleUsing.UseBorders = false;
            this.TextBox4.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox4.ParentStyleUsing.UseFont = false;
            this.TextBox4.ParentStyleUsing.UseForeColor = false;
            this.TextBox4.Size = new System.Drawing.Size(50, 18);
            this.TextBox4.Text = "GKto";
            // 
            // TextBox3
            // 
            this.TextBox3.Font = new System.Drawing.Font("Arial", 8F);
            this.TextBox3.ForeColor = System.Drawing.Color.Black;
            this.TextBox3.Location = new System.Drawing.Point(68, 100);
            this.TextBox3.Multiline = true;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox3.ParentStyleUsing.UseBackColor = false;
            this.TextBox3.ParentStyleUsing.UseBorderColor = false;
            this.TextBox3.ParentStyleUsing.UseBorders = false;
            this.TextBox3.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox3.ParentStyleUsing.UseFont = false;
            this.TextBox3.ParentStyleUsing.UseForeColor = false;
            this.TextBox3.Size = new System.Drawing.Size(62, 18);
            this.TextBox3.Text = "Beleg";
            // 
            // TextBox2
            // 
            this.TextBox2.Font = new System.Drawing.Font("Arial", 8F);
            this.TextBox2.ForeColor = System.Drawing.Color.Black;
            this.TextBox2.Location = new System.Drawing.Point(0, 100);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox2.ParentStyleUsing.UseBackColor = false;
            this.TextBox2.ParentStyleUsing.UseBorderColor = false;
            this.TextBox2.ParentStyleUsing.UseBorders = false;
            this.TextBox2.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox2.ParentStyleUsing.UseFont = false;
            this.TextBox2.ParentStyleUsing.UseForeColor = false;
            this.TextBox2.Size = new System.Drawing.Size(66, 18);
            this.TextBox2.Text = "Datum";
            // 
            // txtMandant
            // 
            this.txtMandant.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Mandant", "")});
            this.txtMandant.Font = new System.Drawing.Font("Arial", 16F);
            this.txtMandant.ForeColor = System.Drawing.Color.Black;
            this.txtMandant.Location = new System.Drawing.Point(0, 25);
            this.txtMandant.Multiline = true;
            this.txtMandant.Name = "txtMandant";
            this.txtMandant.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtMandant.ParentStyleUsing.UseBackColor = false;
            this.txtMandant.ParentStyleUsing.UseBorderColor = false;
            this.txtMandant.ParentStyleUsing.UseBorders = false;
            this.txtMandant.ParentStyleUsing.UseBorderWidth = false;
            this.txtMandant.ParentStyleUsing.UseFont = false;
            this.txtMandant.ParentStyleUsing.UseForeColor = false;
            this.txtMandant.Size = new System.Drawing.Size(696, 23);
            this.txtMandant.Text = "Mandant";
            // 
            // txtKtoName
            // 
            this.txtKtoName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KtoName", "")});
            this.txtKtoName.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.txtKtoName.ForeColor = System.Drawing.Color.Black;
            this.txtKtoName.Location = new System.Drawing.Point(0, 0);
            this.txtKtoName.Multiline = true;
            this.txtKtoName.Name = "txtKtoName";
            this.txtKtoName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKtoName.ParentStyleUsing.UseBackColor = false;
            this.txtKtoName.ParentStyleUsing.UseBorderColor = false;
            this.txtKtoName.ParentStyleUsing.UseBorders = false;
            this.txtKtoName.ParentStyleUsing.UseBorderWidth = false;
            this.txtKtoName.ParentStyleUsing.UseFont = false;
            this.txtKtoName.ParentStyleUsing.UseForeColor = false;
            this.txtKtoName.Size = new System.Drawing.Size(525, 18);
            this.txtKtoName.Text = "KtoName";
            // 
            // Line4
            // 
            this.Line4.ForeColor = System.Drawing.Color.Black;
            this.Line4.Location = new System.Drawing.Point(531, 6);
            this.Line4.Name = "Line4";
            this.Line4.ParentStyleUsing.UseBackColor = false;
            this.Line4.ParentStyleUsing.UseBorderColor = false;
            this.Line4.ParentStyleUsing.UseBorders = false;
            this.Line4.ParentStyleUsing.UseBorderWidth = false;
            this.Line4.ParentStyleUsing.UseFont = false;
            this.Line4.ParentStyleUsing.UseForeColor = false;
            this.Line4.Size = new System.Drawing.Size(83, 2);
            // 
            // Line3
            // 
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.Location = new System.Drawing.Point(444, 6);
            this.Line3.Name = "Line3";
            this.Line3.ParentStyleUsing.UseBackColor = false;
            this.Line3.ParentStyleUsing.UseBorderColor = false;
            this.Line3.ParentStyleUsing.UseBorders = false;
            this.Line3.ParentStyleUsing.UseBorderWidth = false;
            this.Line3.ParentStyleUsing.UseFont = false;
            this.Line3.ParentStyleUsing.UseForeColor = false;
            this.Line3.Size = new System.Drawing.Size(83, 2);
            // 
            // BetragHaben1
            // 
            this.BetragHaben1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragHaben", "{0:n2}")});
            this.BetragHaben1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.BetragHaben1.ForeColor = System.Drawing.Color.Black;
            this.BetragHaben1.Location = new System.Drawing.Point(531, 10);
            this.BetragHaben1.Multiline = true;
            this.BetragHaben1.Name = "BetragHaben1";
            this.BetragHaben1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.BetragHaben1.ParentStyleUsing.UseBackColor = false;
            this.BetragHaben1.ParentStyleUsing.UseBorderColor = false;
            this.BetragHaben1.ParentStyleUsing.UseBorders = false;
            this.BetragHaben1.ParentStyleUsing.UseBorderWidth = false;
            this.BetragHaben1.ParentStyleUsing.UseFont = false;
            this.BetragHaben1.ParentStyleUsing.UseForeColor = false;
            this.BetragHaben1.Size = new System.Drawing.Size(83, 18);
            xrSummary6.FormatString = "{0:#,##0.00}";
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.BetragHaben1.Summary = xrSummary6;
            this.BetragHaben1.Text = "BetragHaben";
            this.BetragHaben1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // BetragSoll1
            // 
            this.BetragSoll1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragSoll", "{0:n2}")});
            this.BetragSoll1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.BetragSoll1.ForeColor = System.Drawing.Color.Black;
            this.BetragSoll1.Location = new System.Drawing.Point(444, 10);
            this.BetragSoll1.Multiline = true;
            this.BetragSoll1.Name = "BetragSoll1";
            this.BetragSoll1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.BetragSoll1.ParentStyleUsing.UseBackColor = false;
            this.BetragSoll1.ParentStyleUsing.UseBorderColor = false;
            this.BetragSoll1.ParentStyleUsing.UseBorders = false;
            this.BetragSoll1.ParentStyleUsing.UseBorderWidth = false;
            this.BetragSoll1.ParentStyleUsing.UseFont = false;
            this.BetragSoll1.ParentStyleUsing.UseForeColor = false;
            this.BetragSoll1.Size = new System.Drawing.Size(83, 18);
            xrSummary7.FormatString = "{0:#,##0.00}";
            xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.BetragSoll1.Summary = xrSummary7;
            this.BetragSoll1.Text = "BetragSoll";
            this.BetragSoll1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel1.Location = new System.Drawing.Point(7, 9);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(67, 27);
            this.xrLabel1.Text = "Druckdatum:";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 8F);
            this.xrPageInfo2.Format = "{0:dd.MM.yyyy}";
            this.xrPageInfo2.Location = new System.Drawing.Point(80, 9);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            this.xrPageInfo2.Size = new System.Drawing.Size(100, 26);
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8F);
            this.xrPageInfo1.Location = new System.Drawing.Point(342, 9);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(100, 20);
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 8F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(649, 9);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(50, 25);
            this.Label6.Text = "KISS 4";
            this.Label6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.Location = new System.Drawing.Point(0, 6);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(700, 2);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 8F);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(306, 9);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(31, 18);
            this.Label1.Text = "Seite";
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Style1
            // 
            this.Style1.BackColor = System.Drawing.Color.Transparent;
            this.Style1.Name = "Style1";
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail,
                        this.PageHeader,
                        this.GroupHeader1,
                        this.GroupFooter1,
                        this.PageFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(60, 19, 60, 39);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
                        this.Style1});
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' , ParameterXML =  N'<NewDataSet>
    <Table>
        <FieldName>-</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Mandant / Periode</DisplayText>
        <TabPosition>1</TabPosition>
        <X>10</X>
        <Y>40</Y>
        <Height>25</Height>
        <LOVName>LOV Name</LOVName>
        <DefaultValue>DefaultValue1</DefaultValue>
        <Mandatory>true</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>-</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Konto-Nr von</DisplayText>
        <TabPosition>2</TabPosition>
        <X>10</X>
        <Y>70</Y>
        <Width>80</Width>
        <Height>25</Height>
        <Length>7</Length>
        <LOVName>LOV Name</LOVName>
        <DefaultValue>DefaultValue1</DefaultValue>
        <Mandatory>false</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>-</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Konto-Nr bis</DisplayText>
        <TabPosition>3</TabPosition>
        <X>10</X>
        <Y>100</Y>
        <Width>80</Width>
        <Height>25</Height>
        <Length>7</Length>
        <LOVName>LOV Name</LOVName>
        <DefaultValue>DefaultValue1</DefaultValue>
        <Mandatory>false</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>-</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Datum von</DisplayText>
        <TabPosition>4</TabPosition>
        <X>10</X>
        <Y>130</Y>
        <Width>80</Width>
        <Height>25</Height>
        <Length>7</Length>
        <LOVName>LOV Name</LOVName>
        <DefaultValue>DefaultValue1</DefaultValue>
        <Mandatory>false</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>-</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Datum bis</DisplayText>
        <TabPosition>5</TabPosition>
        <X>10</X>
        <Y>160</Y>
        <Width>80</Width>
        <Height>25</Height>
        <Length>7</Length>
        <LOVName>LOV Name</LOVName>
        <DefaultValue>DefaultValue1</DefaultValue>
        <Mandatory>false</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>FbPeriodeID</FieldName>
        <FieldCode>14</FieldCode>
        <DisplayText>Mandant / Periode</DisplayText>
        <TabPosition>21</TabPosition>
        <X>120</X>
        <Y>40</Y>
        <Width>350</Width>
        <Height>25</Height>
        <Length>10</Length>
        <Mandatory>false</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
        <SQL>
declare @Pattern varchar(200)

set @Pattern = {0} + ''%''
set @Pattern = replace(@Pattern,'','',''%'')
set @Pattern = replace(@Pattern,'' '',''%'')

select distinct 
       ID = PER.FbPeriodeID,
       [Mandant / Periode] = PRS.NameVorname + 
                 '' ('' + convert(varchar,PER.PeriodeVon,104) + '' - '' + convert(varchar,PER.PeriodeBis,104),
       Strasse   = PRS.WohnsitzStrasseHausNr,
       [PLZ/Ort] = PRS.WohnsitzPLZOrt, 
       FB        = IsNull(BEN.FirstName + '' '','''') + isNull(BEN.LastName,'''') + '' ('' + BEN.LogonName + '')''
from   FbPeriode PER 
       inner join vwPerson         PRS on PRS.BaPersonID = PER.BaPersonID 
       left  join FaLeistung       FAL on FAL.BaPersonID = PER.BaPersonID and 
                                          FAL.ModulID = 5 and 
                                          FAL.DatumVon  = (select max(DatumVon) 
                                                           from   FaLeistung 
                                                           where  BaPersonID = PER.BaPersonID and 
                                                                  FAL.ModulID = 5) 
       left  join XUser            BEN on BEN.UserID = FAL.UserID
where (PRS.Name + isNull('', '' + PRS.Vorname,'''') like @Pattern
or    (CONVERT(VARCHAR, PER.FbPeriodeID) like @Pattern))
order by [Mandant / Periode]
        </SQL>
    </Table>
    <Table>
        <FieldName>KontoNrVon</FieldName>
        <FieldCode>2</FieldCode>
        <DisplayText>Konto von</DisplayText>
        <TabPosition>22</TabPosition>
        <X>120</X>
        <Y>70</Y>
        <Width>80</Width>
        <Height>25</Height>
        <Length>10</Length>
        <LOVName>LOV Name</LOVName>
        <DefaultValue>
        </DefaultValue>
        <Mandatory>true</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>KontoNrBis</FieldName>
        <FieldCode>2</FieldCode>
        <DisplayText>Konto bis</DisplayText>
        <TabPosition>23</TabPosition>
        <X>120</X>
        <Y>100</Y>
        <Width>80</Width>
        <Height>25</Height>
        <Length>10</Length>
        <LOVName>LOV Name</LOVName>
        <DefaultValue>1</DefaultValue>
        <Mandatory>true</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>DatumVon</FieldName>
        <FieldCode>5</FieldCode>
        <DisplayText>Datum von</DisplayText>
        <TabPosition>24</TabPosition>
        <X>120</X>
        <Y>130</Y>
        <Width>80</Width>
        <Height>25</Height>
        <Length>10</Length>
        <LOVName>LOV Name</LOVName>
        <DefaultValue>1</DefaultValue>
        <Mandatory>true</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>DatumBis</FieldName>
        <FieldCode>5</FieldCode>
        <DisplayText>Datum bis</DisplayText>
        <TabPosition>25</TabPosition>
        <X>120</X>
        <Y>160</Y>
        <Width>80</Width>
        <Height>25</Height>
        <Length>10</Length>
        <LOVName>LOV Name</LOVName>
        <DefaultValue>1</DefaultValue>
        <Mandatory>true</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
    </Table>
</NewDataSet>' , SQLquery =  N'DECLARE @FbPeriodeID  int,
        @KontoNrVon   int,
        @KontoNrBis   int,
        @DatumVon     datetime,
        @DatumBis     datetime

SELECT @FbPeriodeID = {FbPeriodeID},
       @KontoNrVon = {KontoNrVon},
       @KontoNrBis = {KontoNrBis},
       @DatumVon = {DatumVon},
       @DatumBis = {DatumBis}

CREATE TABLE #result (
  ID              int,
  FbBuchungID     int,
  BuchungsDatum   datetime,
  Text            varchar(200),
  KtoName         varchar(60),
  GKtoNr          int,
  BetragSoll      money,
  BetragHaben     money,
  Saldo           money,
  BelegNr         varchar(15),
  KontoNrBereich  varchar(20),
  DatumBereich    varchar(100),
  Geburtsdatum    datetime,
  Mandant         varchar(200)
)


INSERT INTO #result
EXECUTE sp_executesql N''EXEC spFbGetKontoblaetter @FbPeriodeID, @KontoNrVon, @KontoNrBis, @DatumVon, @DatumBis'',
  N''@FbPeriodeID int, @KontoNrVon int, @KontoNrBis int, @DatumVon datetime, @DatumBis datetime'',
  @FbPeriodeID, @KontoNrVon, @KontoNrBis, @DatumVon, @DatumBis

UPDATE TMP
  SET Geburtsdatum = PRS.Geburtsdatum,
    Mandant        = PRS.Name + IsNull('', '' + PRS.Vorname,'''')
FROM #result           TMP
  LEFT JOIN FbPeriode  PER ON PER.FbPeriodeID = @FbPeriodeID
  LEFT JOIN BaPerson  PRS ON PRS.BaPersonID = PER.BaPersonID


SELECT * FROM #result

DROP TABLE #result' , ContextForms =  N'VmFibu,CtlFibuJournal,CtlFibuKontoblatt,CtlFibuKontoblatt2,CtlFibuBilanzErfolg' , ParentReportName =  null , ReportSortKey =  null 
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'VmFibuKontoblatt' ;


