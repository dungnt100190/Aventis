-- Insert Script for KBBilanz
-- MD5:0X09B451BD85B3F1292CFEEA5718B51D85_0X83EC8E54FE35A79FE7DE84F8F1DF98DB_0X8AEA1533D59132EDD531592BDABD4BF5
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'KBBilanz') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('KBBilanz', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'KBBilanz';
--SQLCHECK_IGNORE--
UPDATE QRY
SET QueryName =  N'KBBilanz' , UserText =  N'KB - Bilanz' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>de-CH</Localization>
///   <References>
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Drawing\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Configuration\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Data.SqlXml\v4.0_4.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Security\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.Utils.v6.2.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Forms\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Forms.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Accessibility\v4.0_4.0.0.0__b03f5f7f11d50a3a\Accessibility.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Deployment\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Deployment.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Core\v4.0_4.0.0.0__b77a5c561934e089\System.Core.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Numerics\v4.0_4.0.0.0__b77a5c561934e089\System.Numerics.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Serialization.Formatters.Soap\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Runtime.Serialization.Formatters.Soap.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Design\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Design.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Data\v4.0_4.0.0.0__b77a5c561934e089\System.Data.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Transactions\v4.0_4.0.0.0__b77a5c561934e089\System.Transactions.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.EnterpriseServices\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.EnterpriseServices.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.DirectoryServices\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Remoting\v4.0_4.0.0.0__b77a5c561934e089\System.Runtime.Remoting.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Web\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Framework\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Framework.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Xaml\v4.0_4.0.0.0__b77a5c561934e089\System.Xaml.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ComponentModel.DataAnnotations\v4.0_4.0.0.0__31bf3856ad364e35\System.ComponentModel.DataAnnotations.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Caching\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Runtime.Caching.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Web.ApplicationServices\v4.0_4.0.0.0__31bf3856ad364e35\System.Web.ApplicationServices.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Web.Services\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.Services.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Utilities.v4.0\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Utilities.v4.0.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.DirectoryServices.Protocols\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.Protocols.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Tasks.v4.0\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Tasks.v4.0.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceProcess\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.ServiceProcess.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Configuration.Install\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.Install.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Serialization\v4.0_4.0.0.0__b77a5c561934e089\System.Runtime.Serialization.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Internals\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Internals.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\SMDiagnostics\v4.0_4.0.0.0__b77a5c561934e089\SMDiagnostics.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Web.RegularExpressions\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.RegularExpressions.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Drawing.Design\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.Design.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Data.OracleClient\v4.0_4.0.0.0__b77a5c561934e089\System.Data.OracleClient.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.Data.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\KiSS4.DB.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\Kiss.Interfaces.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\FluentValidation.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Xml.Linq\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.Linq.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\log4net.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\SharpLibrary.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\Microsoft.Practices.Unity.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\Ionic.Zip.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\Kiss.BusinessLogic.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\Kiss.DbContext.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\EntityFramework.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.CSharp\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.CSharp.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Dynamic\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Dynamic.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\Kiss.DataAccess.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\HtmlAgilityPack.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\Kiss.BL.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\Kiss.Model.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel\v4.0_4.0.0.0__b77a5c561934e089\System.ServiceModel.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.DurableInstancing\v4.0_4.0.0.0__31bf3856ad364e35\System.Runtime.DurableInstancing.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Net.Http\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Net.Http.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.IdentityModel\v4.0_4.0.0.0__b77a5c561934e089\System.IdentityModel.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Messaging\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Messaging.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.IdentityModel.Selectors\v4.0_4.0.0.0__b77a5c561934e089\System.IdentityModel.Selectors.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Transactions.Bridge\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Transactions.Bridge.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Activation\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Activation.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Xaml.Hosting\v4.0_4.0.0.0__31bf3856ad364e35\System.Xaml.Hosting.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Activities\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Activities.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Activities\v4.0_4.0.0.0__31bf3856ad364e35\System.Activities.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\Microsoft.VisualBasic.Activities.Compiler\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualBasic.Activities.Compiler.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.VisualBasic\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualBasic.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Management\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Management.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.JScript\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.JScript.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Activities.DurableInstancing\v4.0_4.0.0.0__31bf3856ad364e35\System.Activities.DurableInstancing.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\KiSS.Common.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\Autofac.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\Common.Logging.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\Kiss.Database.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\WPFLocalizeExtension.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\XAMLMarkupExtensions.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel lblDTKontoNr;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel lblDTKontoName;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel lblRHDatumBis;
        private DevExpress.XtraReports.UI.XRLabel lblRHKlibu;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRLabel lblPHKonto;
        private DevExpress.XtraReports.UI.XRLabel lblPHUmsatz;
        private DevExpress.XtraReports.UI.XRLabel lblPHTotal;
        private DevExpress.XtraReports.UI.XRLabel lblPHBezeichnung;
        private DevExpress.XtraReports.UI.XRLabel lblPHBilanzEr;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAADAAAAAAAAAFBBRFBBRFATtE6kD" +
                        "3z42fTVBuuWAAAATQAAAAAAAACZAQAASGwAYgBsAEQAVABLAG8AbgB0AG8ATgBhAG0AZQAuAFMAYwByA" +
                        "GkAcAB0AHMALgBPAG4AQgBlAGYAbwByAGUAUAByAGkAbgB0AAAAAABEbABiAGwARABUAEsAbwBuAHQAb" +
                        "wBOAHIALgBTAGMAcgBpAHAAdABzAC4ATwBuAEIAZQBmAG8AcgBlAFAAcgBpAG4AdABMAQAAMnMAcQBsA" +
                        "FEAdQBlAHIAeQAxAC4AUwBlAGwAZQBjAHQAUwB0AGEAdABlAG0AZQBuAHQAkAIAAAHJAnByaXZhdGUgd" +
                        "m9pZCBPbkJlZm9yZVByaW50KG9iamVjdCBzZW5kZXIsIFN5c3RlbS5EcmF3aW5nLlByaW50aW5nLlBya" +
                        "W50RXZlbnRBcmdzIGUpIHsNCiAgIGlmKChib29sKUdldEN1cnJlbnRDb2x1bW5WYWx1ZSgiS29udG9nc" +
                        "nVwcGUiKSkNCiAgIHsNCiAgICAgIGxibERUS29udG9OYW1lLkZvbnQgICA9IG5ldyBGb250KGxibERUS" +
                        "29udG9OYW1lLkZvbnQsIEZvbnRTdHlsZS5Cb2xkKTsNCiAgIH0NCiAgIGVsc2UNCiAgIHsNCiAgICAgI" +
                        "GxibERUS29udG9OYW1lLkZvbnQgPSBuZXcgRm9udChsYmxEVEtvbnRvTmFtZS5Gb250LCBGb250U3R5b" +
                        "GUuUmVndWxhcik7DQogICB9DQp9AcECcHJpdmF0ZSB2b2lkIE9uQmVmb3JlUHJpbnQob2JqZWN0IHNlb" +
                        "mRlciwgU3lzdGVtLkRyYXdpbmcuUHJpbnRpbmcuUHJpbnRFdmVudEFyZ3MgZSkgew0KICAgaWYoKGJvb" +
                        "2wpR2V0Q3VycmVudENvbHVtblZhbHVlKCJLb250b2dydXBwZSIpKQ0KICAgew0KICAgICAgbGJsRFRLb" +
                        "250b05yLkZvbnQgICA9IG5ldyBGb250KGxibERUS29udG9Oci5Gb250LCBGb250U3R5bGUuQm9sZCk7D" +
                        "QogICB9DQogICBlbHNlDQogICB7DQogICAgICBsYmxEVEtvbnRvTnIuRm9udCA9IG5ldyBGb250KGxib" +
                        "ERUS29udG9Oci5Gb250LCBGb250U3R5bGUuUmVndWxhcik7DQogICB9DQp9AZIEREVDTEFSRSBAS2JQZ" +
                        "XJpb2RlSUQgICAgIGludCwNCiAgICAgICAgQERhdHVtVm9uICAgICAgICBkYXRldGltZSwNCiAgICAgI" +
                        "CAgQERhdHVtQmlzICAgICAgICBkYXRldGltZSwNCiAgICAgICAgQE51ck1pdEJ1Y2h1bmdlbiBiaXQsD" +
                        "QogICAgICAgIEBPaG5lS3RvR3J1cHBlbiAgYml0DQoNClNFVCBAS2JQZXJpb2RlSUQgICAgID0gbnVsb" +
                        "CAgICAgLS0zMC0tDQpTRVQgQERhdHVtVm9uICAgICAgICA9IG51bGwgICAgICAgIC0tJzIwMDgwNzAxJ" +
                        "y0tDQpTRVQgQERhdHVtQmlzICAgICAgICA9IG51bGwgICAgICAgIC0tJzIwMDgwNzAxJy0tDQpTRVQgQ" +
                        "E51ck1pdEJ1Y2h1bmdlbiA9IG51bGwgLS0xLS0NClNFVCBAT2huZUt0b0dydXBwZW4gID0gMCAtLVRPR" +
                        "E8hIGdlaHQgbmljaHQgd2VnZW4gU29ydGllcnVuZyEgbnVsbCAgLS0wLS0NCg0KDQoNCmV4ZWMgc3BLY" +
                        "kdldEJpbGFuekVyZm9sZyBAS2JQZXJpb2RlSUQsIEBEYXR1bVZvbiwgQERhdHVtQmlzLCBATnVyTWl0Q" +
                        "nVjaHVuZ2VuLCBAT2huZUt0b0dydXBwZW4sIDEgLS1CaWxhbno=";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.lblDTKontoNr = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDTKontoName = new DevExpress.XtraReports.UI.XRLabel();
            this.lblRHDatumBis = new DevExpress.XtraReports.UI.XRLabel();
            this.lblRHKlibu = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.lblPHBilanzEr = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHKonto = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHUmsatz = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHBezeichnung = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblDTKontoNr,
                        this.xrLabel5,
                        this.xrLabel8,
                        this.lblDTKontoName});
            this.Detail.Height = 25;
            this.Detail.Name = "Detail";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblRHDatumBis,
                        this.lblRHKlibu,
                        this.xrLabel2,
                        this.xrLabel4,
                        this.xrLabel3,
                        this.xrPanel1,
                        this.lblPHBilanzEr});
            this.PageHeader.Height = 127;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLine1,
                        this.xrLabel1,
                        this.xrPageInfo1});
            this.PageFooter.Height = 38;
            this.PageFooter.Name = "PageFooter";
            // 
            // lblDTKontoNr
            // 
            this.lblDTKontoNr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KontoNr", "")});
            this.lblDTKontoNr.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDTKontoNr.Location = new System.Drawing.Point(0, 0);
            this.lblDTKontoNr.Name = "lblDTKontoNr";
            this.lblDTKontoNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDTKontoNr.ParentStyleUsing.UseFont = false;
            this.lblDTKontoNr.Scripts.OnBeforePrint = resources.GetString("lblDTKontoNr.Scripts.OnBeforePrint");
            this.lblDTKontoNr.Size = new System.Drawing.Size(108, 17);
            this.lblDTKontoNr.StyleName = "xrControlStyle1";
            this.lblDTKontoNr.Text = "lblDTKontoNr";
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Total", "{0:n2}")});
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.Location = new System.Drawing.Point(783, 0);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(117, 17);
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Umsatz", "{0:n2}")});
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel8.Location = new System.Drawing.Point(650, 0);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.Size = new System.Drawing.Size(117, 17);
            this.xrLabel8.Text = "xrLabel8";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblDTKontoName
            // 
            this.lblDTKontoName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KontoName", "")});
            this.lblDTKontoName.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDTKontoName.Location = new System.Drawing.Point(142, 0);
            this.lblDTKontoName.Name = "lblDTKontoName";
            this.lblDTKontoName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDTKontoName.ParentStyleUsing.UseFont = false;
            this.lblDTKontoName.Scripts.OnBeforePrint = resources.GetString("lblDTKontoName.Scripts.OnBeforePrint");
            this.lblDTKontoName.Size = new System.Drawing.Size(508, 17);
            // 
            // lblRHDatumBis
            // 
            this.lblRHDatumBis.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Parameter", "")});
            this.lblRHDatumBis.Font = new System.Drawing.Font("Arial", 9F);
            this.lblRHDatumBis.Location = new System.Drawing.Point(542, 50);
            this.lblRHDatumBis.Name = "lblRHDatumBis";
            this.lblRHDatumBis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblRHDatumBis.ParentStyleUsing.UseFont = false;
            this.lblRHDatumBis.Size = new System.Drawing.Size(358, 25);
            this.lblRHDatumBis.Text = "lblRHDatumBis";
            this.lblRHDatumBis.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblRHKlibu
            // 
            this.lblRHKlibu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblRHKlibu.Location = new System.Drawing.Point(542, 0);
            this.lblRHKlibu.Name = "lblRHKlibu";
            this.lblRHKlibu.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblRHKlibu.ParentStyleUsing.UseFont = false;
            this.lblRHKlibu.Size = new System.Drawing.Size(358, 25);
            this.lblRHKlibu.Text = "Klientenbuchhaltung";
            this.lblRHKlibu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "InstName", "")});
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.Location = new System.Drawing.Point(0, 0);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(533, 25);
            this.xrLabel2.Text = "xrLabel2";
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "InstPLZOrt", "")});
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.Location = new System.Drawing.Point(0, 50);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(533, 25);
            this.xrLabel4.Text = "xrLabel4";
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "InstStrasse", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.Location = new System.Drawing.Point(0, 25);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(533, 25);
            this.xrLabel3.Text = "xrLabel3";
            // 
            // xrPanel1
            // 
            this.xrPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblPHKonto,
                        this.lblPHUmsatz,
                        this.lblPHTotal,
                        this.lblPHBezeichnung});
            this.xrPanel1.Location = new System.Drawing.Point(0, 92);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.ParentStyleUsing.UseBackColor = false;
            this.xrPanel1.ParentStyleUsing.UseBorders = false;
            this.xrPanel1.Size = new System.Drawing.Size(900, 33);
            // 
            // lblPHBilanzEr
            // 
            this.lblPHBilanzEr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BilanzER", "")});
            this.lblPHBilanzEr.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPHBilanzEr.Location = new System.Drawing.Point(542, 25);
            this.lblPHBilanzEr.Name = "lblPHBilanzEr";
            this.lblPHBilanzEr.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPHBilanzEr.ParentStyleUsing.UseFont = false;
            this.lblPHBilanzEr.Size = new System.Drawing.Size(358, 25);
            this.lblPHBilanzEr.Text = "[BilanzER]";
            this.lblPHBilanzEr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblPHKonto
            // 
            this.lblPHKonto.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblPHKonto.Location = new System.Drawing.Point(0, 0);
            this.lblPHKonto.Name = "lblPHKonto";
            this.lblPHKonto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPHKonto.ParentStyleUsing.UseBorders = false;
            this.lblPHKonto.ParentStyleUsing.UseFont = false;
            this.lblPHKonto.Size = new System.Drawing.Size(108, 25);
            this.lblPHKonto.Text = "Konto";
            // 
            // lblPHUmsatz
            // 
            this.lblPHUmsatz.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblPHUmsatz.Location = new System.Drawing.Point(650, 0);
            this.lblPHUmsatz.Name = "lblPHUmsatz";
            this.lblPHUmsatz.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPHUmsatz.ParentStyleUsing.UseBorders = false;
            this.lblPHUmsatz.ParentStyleUsing.UseFont = false;
            this.lblPHUmsatz.Size = new System.Drawing.Size(117, 25);
            this.lblPHUmsatz.Text = "Umsatz";
            this.lblPHUmsatz.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblPHTotal
            // 
            this.lblPHTotal.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblPHTotal.Location = new System.Drawing.Point(783, 0);
            this.lblPHTotal.Name = "lblPHTotal";
            this.lblPHTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPHTotal.ParentStyleUsing.UseBorders = false;
            this.lblPHTotal.ParentStyleUsing.UseFont = false;
            this.lblPHTotal.Size = new System.Drawing.Size(117, 25);
            this.lblPHTotal.Text = "Total";
            this.lblPHTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblPHBezeichnung
            // 
            this.lblPHBezeichnung.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblPHBezeichnung.Location = new System.Drawing.Point(142, 0);
            this.lblPHBezeichnung.Name = "lblPHBezeichnung";
            this.lblPHBezeichnung.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPHBezeichnung.ParentStyleUsing.UseBorders = false;
            this.lblPHBezeichnung.ParentStyleUsing.UseFont = false;
            this.lblPHBezeichnung.Size = new System.Drawing.Size(508, 25);
            this.lblPHBezeichnung.Text = "Bezeichnung";
            // 
            // xrLine1
            // 
            this.xrLine1.Location = new System.Drawing.Point(0, 0);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(900, 9);
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "DruckDatum", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.Location = new System.Drawing.Point(0, 18);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(400, 17);
            this.xrLabel1.Text = "xrLabel1";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8F);
            this.xrPageInfo1.Format = "Seite {0} von {1}";
            this.xrPageInfo1.Location = new System.Drawing.Point(800, 17);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(100, 17);
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail,
                        this.PageHeader,
                        this.PageFooter});
            this.DataSource = this.sqlQuery1;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 50, 50);
            this.Name = "Report";
            this.PageHeight = 850;
            this.PageWidth = 1100;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' , ParameterXML =  N'<?xml version="1.0" standalone="yes" ?>
<NewDataSet>
	<Table>
		<FieldName>label</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>KbPeriodeID:</DisplayText>
		<TabPosition>0</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
	<Table>
        	<FieldName>DatumVon</FieldName>
	        <FieldCode>5</FieldCode>
        	<DisplayText>Datum von</DisplayText>
	        <TabPosition>1</TabPosition>
	        <X>120</X>
	        <Y>90</Y>
	        <Height>25</Height>
	        <Width>100</Width>
	</Table>
	<Table>
        	<FieldName>DatumBis</FieldName>
	        <FieldCode>5</FieldCode>
        	<DisplayText>Datum bis</DisplayText>
	        <TabPosition>2</TabPosition>
	        <X>120</X>
	        <Y>120</Y>
	        <Height>25</Height>
	        <Width>100</Width>
	</Table>


	<Table>
		<FieldName>KbPeriodeID</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>KbPeriodeID</DisplayText>
		<TabPosition>20</TabPosition>
		<X>120</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
	<Table>
        	<FieldName>DatumVon</FieldName>
	        <FieldCode>5</FieldCode>
        	<DisplayText>Datum von</DisplayText>
	        <TabPosition>21</TabPosition>
	        <X>120</X>
        	<Y>90</Y>
	        <Height>25</Height>
        	<Width>100</Width>
	</Table>
	<Table>
        	<FieldName>DatumBis</FieldName>
	        <FieldCode>5</FieldCode>
        	<DisplayText>Datum bis</DisplayText>
	        <TabPosition>22</TabPosition>
	        <X>120</X>
        	<Y>120</Y>
	        <Height>25</Height>
        	<Width>100</Width>
	</Table>


	<Table>
        	<FieldName>NurMitBuchungen</FieldName>
	        <FieldCode>7</FieldCode>
        	<DisplayText>nur Konti mit Buchungen</DisplayText>
	        <TabPosition>23</TabPosition>
        	<X>120</X>
	        <Y>150</Y>
        	<Width>300</Width>
	        <Height>25</Height>
        	<Length>200</Length>
	</Table>
	<Table>
        	<FieldName>OhneKtoGruppen</FieldName>
	        <FieldCode>7</FieldCode>
        	<DisplayText>Ohne Kontogruppen</DisplayText>
	        <TabPosition>23</TabPosition>
        	<X>120</X>
	        <Y>180</Y>
        	<Width>300</Width>
	        <Height>25</Height>
        	<Length>200</Length>
	</Table>
</NewDataSet>' , SQLquery =  N'DECLARE @KbPeriodeID     int,
        @DatumVon        datetime,
        @DatumBis        datetime,
        @NurMitBuchungen bit,
        @OhneKtoGruppen  bit

SET @KbPeriodeID     = {kbPeriodeID}     --30--
SET @DatumVon        = {DatumVon}        --''20080701''--
SET @DatumBis        = {DatumBis}        --''20080701''--
SET @NurMitBuchungen = {NurMitBuchungen} --1--
SET @OhneKtoGruppen  = 0 --TODO! geht nicht wegen Sortierung! {OhneKtoGruppen}  --0--



exec spKbGetBilanzErfolg @KbPeriodeID, @DatumVon, @DatumBis, @NurMitBuchungen, @OhneKtoGruppen, 1 --Bilanz' , ContextForms =  N'CtlQueryKbBilanzErfolg' , ParentReportName =  null , ReportSortKey =  null , System =  0 
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'KBBilanz' ;


