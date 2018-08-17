-- Insert Script for ShMonatsbudgetGemeinde2013
-- MD5:0XD8AFCB07C9F4B775205AFAE3E4D10F21_0X01D9C08F26F7BCC5057FB105C25E009E_0X7643750D000182DAA6C57AAFAC6455A2
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'ShMonatsbudgetGemeinde2013') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('ShMonatsbudgetGemeinde2013', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'ShMonatsbudgetGemeinde2013';
--SQLCHECK_IGNORE--
UPDATE QRY
SET QueryName =  N'ShMonatsbudgetGemeinde2013' , UserText =  N'SH - Monatsbudget Gemeinde 2013 (mehrsprachig)' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>de-CH</Localization>
///   <References>
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraPrinting.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Drawing\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Configuration\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.SqlXml\v4.0_4.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Security\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.Utils.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Utils.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Forms\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Forms.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Accessibility\v4.0_4.0.0.0__b03f5f7f11d50a3a\Accessibility.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Deployment\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Deployment.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Core\v4.0_4.0.0.0__b77a5c561934e089\System.Core.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Numerics\v4.0_4.0.0.0__b77a5c561934e089\System.Numerics.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Serialization.Formatters.Soap\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Runtime.Serialization.Formatters.Soap.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Design\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Design.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Data\v4.0_4.0.0.0__b77a5c561934e089\System.Data.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Transactions\v4.0_4.0.0.0__b77a5c561934e089\System.Transactions.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.EnterpriseServices\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.EnterpriseServices.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.DirectoryServices\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Remoting\v4.0_4.0.0.0__b77a5c561934e089\System.Runtime.Remoting.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Web\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Framework\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Framework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xaml\v4.0_4.0.0.0__b77a5c561934e089\System.Xaml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ComponentModel.DataAnnotations\v4.0_4.0.0.0__31bf3856ad364e35\System.ComponentModel.DataAnnotations.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Caching\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Runtime.Caching.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Web.ApplicationServices\v4.0_4.0.0.0__31bf3856ad364e35\System.Web.ApplicationServices.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Web.Services\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.Services.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Utilities.v4.0\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Utilities.v4.0.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.DirectoryServices.Protocols\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.Protocols.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Tasks.v4.0\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Tasks.v4.0.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ServiceProcess\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.ServiceProcess.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Configuration.Install\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.Install.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Serialization\v4.0_4.0.0.0__b77a5c561934e089\System.Runtime.Serialization.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Internals\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Internals.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\SMDiagnostics\v4.0_4.0.0.0__b77a5c561934e089\SMDiagnostics.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Web.RegularExpressions\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.RegularExpressions.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Drawing.Design\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.Design.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Data.OracleClient\v4.0_4.0.0.0__b77a5c561934e089\System.Data.OracleClient.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraEditors.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.Data.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Data.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraBars.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraNavBar.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraCharts.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraRichTextEdit.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="C:\KiSS\KiSS4\KiSS4.DB.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.Interfaces.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\KiSS\KiSS4\FluentValidation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xml.Linq\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.Linq.dll" />
///     <Reference Path="C:\KiSS\KiSS4\log4net.dll" />
///     <Reference Path="C:\KiSS\KiSS4\SharpLibrary.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Microsoft.Practices.Unity.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Ionic.Zip.dll" />
///     <Reference Path="C:\KiSS\KiSS4\PdfSharp.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Microsoft.Practices.Unity.Configuration.dll" />
///     <Reference Path="C:\KiSS\KiSS4\C1.C1Zip.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.BusinessLogic.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.DbContext.dll" />
///     <Reference Path="C:\KiSS\KiSS4\EntityFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.CSharp\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.CSharp.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Dynamic\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Dynamic.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.DataAccess.dll" />
///     <Reference Path="C:\KiSS\KiSS4\HtmlAgilityPack.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.BL.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.Model.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel\v4.0_4.0.0.0__b77a5c561934e089\System.ServiceModel.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.DurableInstancing\v4.0_4.0.0.0__31bf3856ad364e35\System.Runtime.DurableInstancing.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Net.Http\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Net.Http.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.IdentityModel\v4.0_4.0.0.0__b77a5c561934e089\System.IdentityModel.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Messaging\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Messaging.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.IdentityModel.Selectors\v4.0_4.0.0.0__b77a5c561934e089\System.IdentityModel.Selectors.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Transactions.Bridge\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Transactions.Bridge.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Activation\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Activation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xaml.Hosting\v4.0_4.0.0.0__31bf3856ad364e35\System.Xaml.Hosting.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Activities\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Activities.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Activities\v4.0_4.0.0.0__31bf3856ad364e35\System.Activities.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\Microsoft.VisualBasic.Activities.Compiler\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualBasic.Activities.Compiler.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.VisualBasic\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualBasic.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Management\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Management.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.JScript\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.JScript.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Activities.DurableInstancing\v4.0_4.0.0.0__31bf3856ad364e35\System.Activities.DurableInstancing.dll" />
///     <Reference Path="C:\KiSS\KiSS4\KiSS.Common.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Autofac.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Common.Logging.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.Database.dll" />
///     <Reference Path="C:\KiSS\KiSS4\WPFLocalizeExtension.dll" />
///     <Reference Path="C:\KiSS\KiSS4\XAMLMarkupExtensions.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRPanel panAdresse_script;
        private DevExpress.XtraReports.UI.XRLabel lblStrasse;
        private DevExpress.XtraReports.UI.XRLabel lblOrt;
        private DevExpress.XtraReports.UI.XRLabel lblName;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.Subreport ShMonatsbudgetGemeinde2013_UnterstuetztePersonen;
        private DevExpress.XtraReports.UI.Subreport ShMonatsbudgetGemeinde2013_Detail;
        private DevExpress.XtraReports.UI.XRLabel lblOrgName;
        private DevExpress.XtraReports.UI.XRLabel lblOrgAdresse;
        private DevExpress.XtraReports.UI.XRLabel lblOrgOrt;
        private DevExpress.XtraReports.UI.XRLabel lblNameSar;
        private DevExpress.XtraReports.UI.XRLabel lblMonatsbudgetTitle;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel lblAbSeite2;
        private DevExpress.XtraReports.UI.XRPageInfo piOrgOrtDatum;
        private DevExpress.XtraReports.UI.XRLabel lblSeite;
        private DevExpress.XtraReports.UI.XRPageInfo piSeite;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAADAAAAAAAAAFBBRFBBRFCTNJGGE" +
                        "7ROpIjolzZTAAAAngAAAAAAAAChAQAATnAAYQBuAEEAZAByAGUAcwBzAGUAXwBzAGMAcgBpAHAAdAAuA" +
                        "FMAYwByAGkAcAB0AHMALgBPAG4AQgBlAGYAbwByAGUAUAByAGkAbgB0AAAAAABGcABpAE8AcgBnAE8Ac" +
                        "gB0AEQAYQB0AHUAbQAuAFMAYwByAGkAcAB0AHMALgBPAG4AQgBlAGYAbwByAGUAUAByAGkAbgB0ABwBA" +
                        "AAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdADuAQAAAZkCc" +
                        "HJpdmF0ZSB2b2lkIE9uQmVmb3JlUHJpbnQob2JqZWN0IHNlbmRlciwgU3lzdGVtLkRyYXdpbmcuUHJpb" +
                        "nRpbmcuUHJpbnRFdmVudEFyZ3MgZSkgDQp7DQogICAgaW50IHggPSBHZXRDdXJyZW50Q29sdW1uVmFsd" +
                        "WUoIkFkcmVzc2VMb2NhdGlvblgiKSBhcyBpbnQ/ID8/IDA7DQogICAgaW50IHkgPSBHZXRDdXJyZW50Q" +
                        "29sdW1uVmFsdWUoIkFkcmVzc2VMb2NhdGlvblkiKSBhcyBpbnQ/ID8/IDA7DQoNCiAgICBwYW5BZHJlc" +
                        "3NlX3NjcmlwdC5Mb2NhdGlvbiA9IG5ldyBQb2ludCh4LCB5KTsNCn0BzwFwcml2YXRlIHZvaWQgT25CZ" +
                        "WZvcmVQcmludChvYmplY3Qgc2VuZGVyLCBTeXN0ZW0uRHJhd2luZy5QcmludGluZy5QcmludEV2ZW50Q" +
                        "XJncyBlKSB7DQogIHBpT3JnT3J0RGF0dW0uRm9ybWF0ID0gcGlPcmdPcnREYXR1bS5Gb3JtYXQuUmVwb" +
                        "GFjZSgiPE9yZ09ydD4iLFJlcG9ydC5HZXRDdXJyZW50Q29sdW1uVmFsdWUoIk9yZ19PcnQiKS5Ub1N0c" +
                        "mluZygpKTsNCn0BtB9ERUNMQVJFIEBCZ0J1ZGdldElkIElOVDsNClNFVCBAQmdCdWRnZXRJZCA9IG51b" +
                        "Gw7DQoNCkRFQ0xBUkUgQExhbmd1YWdlQ29kZSBJTlQ7DQpERUNMQVJFIEBEYXR1bVZvbiBEQVRFVElNR" +
                        "TsNCkRFQ0xBUkUgQERhdHVtQmlzIERBVEVUSU1FOw0KDQotLSBTcHJhY2hjb2RlIGRlcyBLbGllbnRlb" +
                        "iB1bmQgRGF0dW1Wb24gZGVzIEJ1ZGdldHMgZXJ1aWVyZW4uDQpTRUxFQ1QgDQogIEBMYW5ndWFnZUNvZ" +
                        "GUgPSBJU05VTEwoUFJTLlZlcnN0YWVuZGlndW5nU3ByYWNoQ29kZSwgUFJTLlNwcmFjaENvZGUpLA0KI" +
                        "CBARGF0dW1Wb24gICAgID0gZGJvLmZuRGF0ZVNlcmlhbChCREcuSmFociwgQkRHLk1vbmF0LCAxKQ0KR" +
                        "lJPTSBkYm8uQmdCdWRnZXQgICAgICAgICAgICBCREcgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKQ0KIElOT" +
                        "kVSIEpPSU4gZGJvLkJnRmluYW56cGxhbiBGUEwgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKSBPTiBGUEwuQ" +
                        "mdGaW5hbnpwbGFuSUQgPSBCREcuQmdGaW5hbnpwbGFuSUQNCiBJTk5FUiBKT0lOIGRiby5GYUxlaXN0d" +
                        "W5nICAgTEVJIFdJVEggKFJFQURVTkNPTU1JVFRFRCkgT04gTEVJLkZhTGVpc3R1bmdJRCAgID0gRlBML" +
                        "kZhTGVpc3R1bmdJRA0KIElOTkVSIEpPSU4gZGJvLkJhUGVyc29uICAgICBQUlMgV0lUSCAoUkVBRFVOQ" +
                        "09NTUlUVEVEKSBPTiBQUlMuQmFQZXJzb25JRCAgICAgPSBMRUkuQmFQZXJzb25JRA0KV0hFUkUgQkRHL" +
                        "kJnQnVkZ2V0SUQgPSAgQEJnQnVkZ2V0SWQ7DQogDQotLSBEZWZhdWx0c3ByYWNoZSBERQ0KSUYgQExhb" +
                        "md1YWdlQ29kZSBJUyBOVUxMDQpCRUdJTg0KICBTRVQgQExhbmd1YWdlQ29kZSA9IDE7DQpFTkQ7DQoNC" +
                        "lNFTEVDVCBARGF0dW1CaXMgPSBkYm8uZm5MYXN0RGF5T2YoQERhdHVtVm9uKTsNCg0KLS0gUG9zaXRpb" +
                        "24gZGVyIEFkcmVzc2UgYXVzIENvbmZpZyBsZXNlbg0KREVDTEFSRSBAQWRyZXNzZUxvY2F0aW9uWCBJT" +
                        "lQ7DQpERUNMQVJFIEBBZHJlc3NlTG9jYXRpb25ZIElOVDsNCg0KU0VMRUNUIEBBZHJlc3NlTG9jYXRpb" +
                        "25YID0gQ09OVkVSVChJTlQsIFNwbGl0VmFsdWUpDQpGUk9NIGRiby5mblNwbGl0U3RyaW5nVG9WYWx1Z" +
                        "XMoQ09OVkVSVChWQVJDSEFSKE1BWCksIGRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlXFBvc2l0a" +
                        "W9uQXVmUmVwb3J0JywgR0VUREFURSgpKSksICcsJywgMCkgDQpXSEVSRSBPY2N1cmVuY2VJRCA9IDA7D" +
                        "QoNClNFTEVDVCBAQWRyZXNzZUxvY2F0aW9uWSA9IENPTlZFUlQoSU5ULCBTcGxpdFZhbHVlKQ0KRlJPT" +
                        "SBkYm8uZm5TcGxpdFN0cmluZ1RvVmFsdWVzKENPTlZFUlQoVkFSQ0hBUihNQVgpLCBkYm8uZm5YQ29uZ" +
                        "mlnKCdTeXN0ZW1cQWRyZXNzZVxQb3NpdGlvbkF1ZlJlcG9ydCcsIEdFVERBVEUoKSkpLCAnLCcsIDApI" +
                        "A0KV0hFUkUgT2NjdXJlbmNlSUQgPSAxOw0KDQpTRUxFQ1QNCiAgQWRyZXNzZUxvY2F0aW9uWCA9IEBBZ" +
                        "HJlc3NlTG9jYXRpb25YLA0KICBBZHJlc3NlTG9jYXRpb25ZID0gQEFkcmVzc2VMb2NhdGlvblksDQogI" +
                        "E9yZ19OYW1lICAgICAgPSBJU05VTEwoQ09OVkVSVCh2YXJjaGFyKDEwMDApLCBkYm8uZm5YQ29uZmlnK" +
                        "CdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxPcmdhbmlzYXRpb24nLCBHRVREQVRFKCkpKSwgJycpL" +
                        "A0KICBPcmdfQWRyZXNzZSAgID0gSVNOVUxMKENPTlZFUlQodmFyY2hhcigxMDAwKSwgZGJvLmZuWENvb" +
                        "mZpZygnU3lzdGVtXEFkcmVzc2VcU296aWFsaGlsZmVcQWRyZXNzZScsIEdFVERBVEUoKSkpLCAnJyksD" +
                        "QogIE9yZ19QTFogICAgICAgPSBJU05VTEwoQ09OVkVSVCh2YXJjaGFyKDEwMDApLCBkYm8uZm5YQ29uZ" +
                        "mlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxQTFonLCBHRVREQVRFKCkpKSwgJycpLA0KICBPc" +
                        "mdfT3J0ICAgICAgID0gSVNOVUxMKENPTlZFUlQodmFyY2hhcigxMDAwKSwgZGJvLmZuWENvbmZpZygnU" +
                        "3lzdGVtXEFkcmVzc2VcU296aWFsaGlsZmVcT3J0JywgR0VUREFURSgpKSksICcnKSwNCiAgT3JnX1BMW" +
                        "k9ydCAgICA9IElTTlVMTChDT05WRVJUKHZhcmNoYXIoMTAwMCksIGRiby5mblhDb25maWcoJ1N5c3Rlb" +
                        "VxBZHJlc3NlXFNvemlhbGhpbGZlXFBMWicsIEdFVERBVEUoKSkpICsgJyAnLCAnJykNCiAgICAgICAgI" +
                        "CAgICAgICAgICsgSVNOVUxMKENPTlZFUlQodmFyY2hhcigxMDAwKSwgZGJvLmZuWENvbmZpZygnU3lzd" +
                        "GVtXEFkcmVzc2VcU296aWFsaGlsZmVcT3J0JywgR0VUREFURSgpKSksICcnKSwgDQogIEJnQnVkZ2V0S" +
                        "UQgICAgPSBCREcuQmdCdWRnZXRJRCwgICAgICAgICAgICAgICAgICAgICAgICAgICAgIA0KICBUaXRlb" +
                        "CAgICAgICAgID0gUkVQTEFDRSgNCiAgICAgICAgICAgICAgICAgICAgUkVQTEFDRShkYm8uZm5HZXRNT" +
                        "FRleHRGcm9tTmFtZSgnU2hNb25hdHNidWRnZXRHZW1laW5kZTIwMTMnLCAnVGV4dFNrb3NCdWRnZXRWb" +
                        "20nLCBATGFuZ3VhZ2VDb2RlKSwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAnbnVsbCcsIA0KI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgIENPTlZFUlQoVkFSQ0hBUihNQVgpLCBARGF0dW1Wb24sI" +
                        "DEwNCkpLCANCiAgICAgICAgICAgICAgICAgICAgJ251bGwnLCANCiAgICAgICAgICAgICAgICAgICAgQ" +
                        "09OVkVSVChWQVJDSEFSKE1BWCksIEBEYXR1bUJpcywgMTA0KSksDQogIE5hbWUgICAgICAgICAgPSBkY" +
                        "m8uZm5HZXRFaGVwYWFyTmFtZShQUlMuQmFQZXJzb25JRCwgQkRHLkJnRmluYW56cGxhbklELCAxLCBAT" +
                        "GFuZ3VhZ2VDb2RlKSwNCiAgU3RyYXNzZSAgICAgICA9IFBSUy5Xb2huc2l0elN0cmFzc2VIYXVzTnIsD" +
                        "QogIE9ydCAgICAgICAgICAgPSBQUlMuV29obnNpdHpQTFpPcnQsDQogIFNhclp1c3RhZW5kaWcgPSBVU" +
                        "1IuVm9ybmFtZU5hbWUsDQogIEdlZHJ1Y2t0QW0gICAgPSBkYm8uZm5HZXRNTFRleHRGcm9tTmFtZSgnU" +
                        "2hNb25hdHNidWRnZXRHZW1laW5kZTIwMTMnLCAnVGV4dFBlcicsICAgQExhbmd1YWdlQ29kZSkgKyAnI" +
                        "CcgKyBDT05WRVJUKFZBUkNIQVIsIEdFVERBVEUoKSwgMTA0KSwgDQogIFRleHRTZWl0ZSAgICAgPSBkY" +
                        "m8uZm5HZXRNTFRleHRGcm9tTmFtZSgnU2hNb25hdHNidWRnZXRHZW1laW5kZTIwMTMnLCAnVGV4dFNla" +
                        "XRlJywgQExhbmd1YWdlQ29kZSksDQogIFRleHRBYlNlaXRlMiAgPSBkYm8uZm5HZXRFaGVwYWFyTmFtZ" +
                        "ShQUlMuQmFQZXJzb25JRCwgQkRHLkJnRmluYW56cGxhbklELCAwLCBATGFuZ3VhZ2VDb2RlKSArICcsI" +
                        "CcgKyBDT05WRVJUKFZBUkNIQVIoTUFYKSwgQERhdHVtVm9uLCAxMDQpICsgJyAtICcgKyBDT05WRVJUK" +
                        "FZBUkNIQVIoTUFYKSwgQERhdHVtQmlzLCAxMDQpICsgJywgJyArIGRiby5mbkdldE1MVGV4dEZyb21OY" +
                        "W1lKCdTaE1vbmF0c2J1ZGdldEdlbWVpbmRlMjAxMycsICdUZXh0U2VpdGUnLCBATGFuZ3VhZ2VDb2RlK" +
                        "SwNCiBCZW1lcmt1bmcgICAgID0gZGJvLmZuR2V0TUxUZXh0RnJvbU5hbWUoJ1NoTW9uYXRzYnVkZ2V0R" +
                        "2VtZWluZGUyMDEzJywgJ1RleHRCZW1lcmt1bmdlbicsIEBMYW5ndWFnZUNvZGUpICsgQ0hBUigxMykgK" +
                        "yBDSEFSKDEwKSArIEZQTC5CZW1lcmt1bmcNCkZST00gZGJvLkJnQnVkZ2V0ICAgICAgICAgICAgICBCR" +
                        "EcgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKQ0KICBJTk5FUiBKT0lOIGRiby5CZ0ZpbmFuenBsYW4gIEZQT" +
                        "CBXSVRIIChSRUFEVU5DT01NSVRURUQpIE9OIEZQTC5CZ0ZpbmFuenBsYW5JRCA9IEJERy5CZ0ZpbmFue" +
                        "nBsYW5JRA0KICBJTk5FUiBKT0lOIGRiby5GYUxlaXN0dW5nICAgIExFSSBXSVRIIChSRUFEVU5DT01NS" +
                        "VRURUQpIE9OIExFSS5GYUxlaXN0dW5nSUQgPSBGUEwuRmFMZWlzdHVuZ0lEDQogIElOTkVSIEpPSU4gZ" +
                        "GJvLnZ3UGVyc29uICAgICAgUFJTIFdJVEggKFJFQURVTkNPTU1JVFRFRCkgT04gUFJTLkJhUGVyc29uS" +
                        "UQgPSBMRUkuQmFQZXJzb25JRA0KICBJTk5FUiBKT0lOIGRiby52d1VzZXIgICAgICAgIFVTUiBXSVRII" +
                        "ChSRUFEVU5DT01NSVRURUQpIE9OIFVTUi5Vc2VySUQgPSBMRUkuVXNlcklEDQpXSEVSRSBMRUkuTW9kd" +
                        "WxJRCA9IDMNCiAgQU5EIEJERy5Nb25hdCBJUyBOT1QgTlVMTA0KICBBTkQgQkRHLkJnQnVkZ2V0SUQgP" +
                        "SBAQmdCdWRnZXRJZDs=";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.panAdresse_script = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.ShMonatsbudgetGemeinde2013_UnterstuetztePersonen = new DevExpress.XtraReports.UI.Subreport();
            this.ShMonatsbudgetGemeinde2013_Detail = new DevExpress.XtraReports.UI.Subreport();
            this.lblOrgName = new DevExpress.XtraReports.UI.XRLabel();
            this.lblOrgAdresse = new DevExpress.XtraReports.UI.XRLabel();
            this.lblOrgOrt = new DevExpress.XtraReports.UI.XRLabel();
            this.lblNameSar = new DevExpress.XtraReports.UI.XRLabel();
            this.lblMonatsbudgetTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.lblStrasse = new DevExpress.XtraReports.UI.XRLabel();
            this.lblOrt = new DevExpress.XtraReports.UI.XRLabel();
            this.lblName = new DevExpress.XtraReports.UI.XRLabel();
            this.lblAbSeite2 = new DevExpress.XtraReports.UI.XRLabel();
            this.piOrgOrtDatum = new DevExpress.XtraReports.UI.XRPageInfo();
            this.lblSeite = new DevExpress.XtraReports.UI.XRLabel();
            this.piSeite = new DevExpress.XtraReports.UI.XRPageInfo();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // PageHeader
            // 
            this.PageHeader.Height = 0;
            this.PageHeader.Name = "PageHeader";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel1,
                        this.panAdresse_script,
                        this.xrLine1,
                        this.ShMonatsbudgetGemeinde2013_UnterstuetztePersonen,
                        this.ShMonatsbudgetGemeinde2013_Detail,
                        this.lblOrgName,
                        this.lblOrgAdresse,
                        this.lblOrgOrt,
                        this.lblNameSar,
                        this.lblMonatsbudgetTitle});
            this.Detail.Height = 442;
            this.Detail.Name = "Detail";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblAbSeite2,
                        this.piOrgOrtDatum,
                        this.lblSeite,
                        this.piSeite});
            this.PageFooter.Height = 42;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bemerkung", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 11F);
            this.xrLabel1.Location = new System.Drawing.Point(8, 392);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(659, 50);
            this.xrLabel1.Text = "xrLabel1";
            // 
            // panAdresse_script
            // 
            this.panAdresse_script.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblStrasse,
                        this.lblOrt,
                        this.lblName});
            this.panAdresse_script.Location = new System.Drawing.Point(400, 100);
            this.panAdresse_script.Name = "panAdresse_script";
            this.panAdresse_script.Scripts.OnBeforePrint = resources.GetString("panAdresse_script.Scripts.OnBeforePrint");
            this.panAdresse_script.Size = new System.Drawing.Size(200, 50);
            // 
            // xrLine1
            // 
            this.xrLine1.Location = new System.Drawing.Point(8, 292);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(659, 8);
            // 
            // ShMonatsbudgetGemeinde2013_UnterstuetztePersonen
            // 
            this.ShMonatsbudgetGemeinde2013_UnterstuetztePersonen.Location = new System.Drawing.Point(8, 250);
            this.ShMonatsbudgetGemeinde2013_UnterstuetztePersonen.Name = "ShMonatsbudgetGemeinde2013_UnterstuetztePersonen";
            // 
            // ShMonatsbudgetGemeinde2013_Detail
            // 
            this.ShMonatsbudgetGemeinde2013_Detail.Location = new System.Drawing.Point(8, 342);
            this.ShMonatsbudgetGemeinde2013_Detail.Name = "ShMonatsbudgetGemeinde2013_Detail";
            // 
            // lblOrgName
            // 
            this.lblOrgName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Name", "")});
            this.lblOrgName.Font = new System.Drawing.Font("Arial", 11F);
            this.lblOrgName.ForeColor = System.Drawing.Color.Black;
            this.lblOrgName.Location = new System.Drawing.Point(8, 8);
            this.lblOrgName.Multiline = true;
            this.lblOrgName.Name = "lblOrgName";
            this.lblOrgName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblOrgName.ParentStyleUsing.UseBackColor = false;
            this.lblOrgName.ParentStyleUsing.UseBorderColor = false;
            this.lblOrgName.ParentStyleUsing.UseBorders = false;
            this.lblOrgName.ParentStyleUsing.UseBorderWidth = false;
            this.lblOrgName.ParentStyleUsing.UseFont = false;
            this.lblOrgName.ParentStyleUsing.UseForeColor = false;
            this.lblOrgName.Size = new System.Drawing.Size(325, 17);
            this.lblOrgName.Text = "lblOrgName";
            // 
            // lblOrgAdresse
            // 
            this.lblOrgAdresse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Adresse", "")});
            this.lblOrgAdresse.Font = new System.Drawing.Font("Arial", 11F);
            this.lblOrgAdresse.ForeColor = System.Drawing.Color.Black;
            this.lblOrgAdresse.Location = new System.Drawing.Point(8, 42);
            this.lblOrgAdresse.Multiline = true;
            this.lblOrgAdresse.Name = "lblOrgAdresse";
            this.lblOrgAdresse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblOrgAdresse.ParentStyleUsing.UseBackColor = false;
            this.lblOrgAdresse.ParentStyleUsing.UseBorderColor = false;
            this.lblOrgAdresse.ParentStyleUsing.UseBorders = false;
            this.lblOrgAdresse.ParentStyleUsing.UseBorderWidth = false;
            this.lblOrgAdresse.ParentStyleUsing.UseFont = false;
            this.lblOrgAdresse.ParentStyleUsing.UseForeColor = false;
            this.lblOrgAdresse.Size = new System.Drawing.Size(183, 15);
            this.lblOrgAdresse.Text = "lblOrgAdresse";
            // 
            // lblOrgOrt
            // 
            this.lblOrgOrt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_PLZOrt", "")});
            this.lblOrgOrt.Font = new System.Drawing.Font("Arial", 11F);
            this.lblOrgOrt.ForeColor = System.Drawing.Color.Black;
            this.lblOrgOrt.Location = new System.Drawing.Point(8, 58);
            this.lblOrgOrt.Multiline = true;
            this.lblOrgOrt.Name = "lblOrgOrt";
            this.lblOrgOrt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblOrgOrt.ParentStyleUsing.UseBackColor = false;
            this.lblOrgOrt.ParentStyleUsing.UseBorderColor = false;
            this.lblOrgOrt.ParentStyleUsing.UseBorders = false;
            this.lblOrgOrt.ParentStyleUsing.UseBorderWidth = false;
            this.lblOrgOrt.ParentStyleUsing.UseFont = false;
            this.lblOrgOrt.ParentStyleUsing.UseForeColor = false;
            this.lblOrgOrt.Size = new System.Drawing.Size(183, 15);
            this.lblOrgOrt.Text = "lblOrgOrt";
            // 
            // lblNameSar
            // 
            this.lblNameSar.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SarZustaendig", "")});
            this.lblNameSar.Font = new System.Drawing.Font("Arial", 11F);
            this.lblNameSar.ForeColor = System.Drawing.Color.Black;
            this.lblNameSar.Location = new System.Drawing.Point(8, 25);
            this.lblNameSar.Multiline = true;
            this.lblNameSar.Name = "lblNameSar";
            this.lblNameSar.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblNameSar.ParentStyleUsing.UseBackColor = false;
            this.lblNameSar.ParentStyleUsing.UseBorderColor = false;
            this.lblNameSar.ParentStyleUsing.UseBorders = false;
            this.lblNameSar.ParentStyleUsing.UseBorderWidth = false;
            this.lblNameSar.ParentStyleUsing.UseFont = false;
            this.lblNameSar.ParentStyleUsing.UseForeColor = false;
            this.lblNameSar.Size = new System.Drawing.Size(230, 15);
            this.lblNameSar.Text = "lblNameSar";
            // 
            // lblMonatsbudgetTitle
            // 
            this.lblMonatsbudgetTitle.CanShrink = true;
            this.lblMonatsbudgetTitle.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Titel", "")});
            this.lblMonatsbudgetTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonatsbudgetTitle.Location = new System.Drawing.Point(8, 308);
            this.lblMonatsbudgetTitle.Name = "lblMonatsbudgetTitle";
            this.lblMonatsbudgetTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblMonatsbudgetTitle.ParentStyleUsing.UseFont = false;
            this.lblMonatsbudgetTitle.Size = new System.Drawing.Size(659, 25);
            this.lblMonatsbudgetTitle.Text = "lblMonatsbudgetTitle";
            // 
            // lblStrasse
            // 
            this.lblStrasse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Strasse", "")});
            this.lblStrasse.Font = new System.Drawing.Font("Arial", 11F);
            this.lblStrasse.ForeColor = System.Drawing.Color.Black;
            this.lblStrasse.Location = new System.Drawing.Point(0, 17);
            this.lblStrasse.Multiline = true;
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblStrasse.ParentStyleUsing.UseBackColor = false;
            this.lblStrasse.ParentStyleUsing.UseBorderColor = false;
            this.lblStrasse.ParentStyleUsing.UseBorders = false;
            this.lblStrasse.ParentStyleUsing.UseBorderWidth = false;
            this.lblStrasse.ParentStyleUsing.UseFont = false;
            this.lblStrasse.ParentStyleUsing.UseForeColor = false;
            this.lblStrasse.Size = new System.Drawing.Size(195, 15);
            this.lblStrasse.Text = "lblStrasse";
            // 
            // lblOrt
            // 
            this.lblOrt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Ort", "")});
            this.lblOrt.Font = new System.Drawing.Font("Arial", 11F);
            this.lblOrt.ForeColor = System.Drawing.Color.Black;
            this.lblOrt.Location = new System.Drawing.Point(0, 33);
            this.lblOrt.Multiline = true;
            this.lblOrt.Name = "lblOrt";
            this.lblOrt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblOrt.ParentStyleUsing.UseBackColor = false;
            this.lblOrt.ParentStyleUsing.UseBorderColor = false;
            this.lblOrt.ParentStyleUsing.UseBorders = false;
            this.lblOrt.ParentStyleUsing.UseBorderWidth = false;
            this.lblOrt.ParentStyleUsing.UseFont = false;
            this.lblOrt.ParentStyleUsing.UseForeColor = false;
            this.lblOrt.Size = new System.Drawing.Size(195, 15);
            this.lblOrt.Text = "lblOrt";
            // 
            // lblName
            // 
            this.lblName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.lblName.Font = new System.Drawing.Font("Arial", 11F);
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Multiline = true;
            this.lblName.Name = "lblName";
            this.lblName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblName.ParentStyleUsing.UseBackColor = false;
            this.lblName.ParentStyleUsing.UseBorderColor = false;
            this.lblName.ParentStyleUsing.UseBorders = false;
            this.lblName.ParentStyleUsing.UseBorderWidth = false;
            this.lblName.ParentStyleUsing.UseFont = false;
            this.lblName.ParentStyleUsing.UseForeColor = false;
            this.lblName.Size = new System.Drawing.Size(195, 15);
            this.lblName.Text = "lblName";
            // 
            // lblAbSeite2
            // 
            this.lblAbSeite2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TextAbSeite2", "")});
            this.lblAbSeite2.Font = new System.Drawing.Font("Arial", 10F);
            this.lblAbSeite2.Location = new System.Drawing.Point(283, 8);
            this.lblAbSeite2.Name = "lblAbSeite2";
            this.lblAbSeite2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblAbSeite2.ParentStyleUsing.UseFont = false;
            this.lblAbSeite2.Size = new System.Drawing.Size(92, 20);
            this.lblAbSeite2.Text = "lblAbSeite2";
            this.lblAbSeite2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.lblAbSeite2.Visible = false;
            // 
            // piOrgOrtDatum
            // 
            this.piOrgOrtDatum.Font = new System.Drawing.Font("Arial", 9.75F);
            this.piOrgOrtDatum.Format = "<OrgOrt>, {0:dd.MM.yyyy}";
            this.piOrgOrtDatum.Location = new System.Drawing.Point(8, 8);
            this.piOrgOrtDatum.Name = "piOrgOrtDatum";
            this.piOrgOrtDatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.piOrgOrtDatum.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.piOrgOrtDatum.ParentStyleUsing.UseFont = false;
            this.piOrgOrtDatum.Scripts.OnBeforePrint = resources.GetString("piOrgOrtDatum.Scripts.OnBeforePrint");
            this.piOrgOrtDatum.Size = new System.Drawing.Size(192, 20);
            // 
            // lblSeite
            // 
            this.lblSeite.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TextSeite", "")});
            this.lblSeite.Font = new System.Drawing.Font("Arial", 10F);
            this.lblSeite.Location = new System.Drawing.Point(200, 8);
            this.lblSeite.Name = "lblSeite";
            this.lblSeite.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSeite.ParentStyleUsing.UseFont = false;
            this.lblSeite.Scripts.OnPrintOnPage = "private void OnPrintOnPage(object sender, DevExpress.XtraReports.UI.PrintOnPageEv" +
                "entArgs e) {\r\nif( e.PageIndex > 0 )\r\n\t{\r\n   \t    ((XRLabel)sender).Text = lblAbS" +
                "eite2.Text;\r\n\t}\r\n}";
            this.lblSeite.Size = new System.Drawing.Size(423, 20);
            this.lblSeite.Text = "lblSeite";
            this.lblSeite.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // piSeite
            // 
            this.piSeite.Font = new System.Drawing.Font("Arial", 10F);
            this.piSeite.Location = new System.Drawing.Point(633, 8);
            this.piSeite.Name = "piSeite";
            this.piSeite.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.piSeite.ParentStyleUsing.UseFont = false;
            this.piSeite.Size = new System.Drawing.Size(35, 20);
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.PageHeader,
                        this.Detail,
                        this.PageFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(100, 54, 100, 100);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' , ParameterXML =  N'<?xml version="1.0" standalone="yes" ?>
<NewDataSet>
	<Table>
		<FieldName>label</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Budget ID:</DisplayText>
		<TabPosition>0</TabPosition>
		<X>10</X>
		<Y>60</Y>
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
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>true</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>

	<Table>
		<FieldName>labelGbl</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Grundbedarf für UE:</DisplayText>
		<TabPosition>2</TabPosition>
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
		<FieldName>GBL</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>Grundbedarf für UE</DisplayText>
		<TabPosition>3</TabPosition>
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
</NewDataSet>' , SQLquery =  N'DECLARE @BgBudgetId INT;
SET @BgBudgetId = {BgBudgetID};

DECLARE @LanguageCode INT;
DECLARE @DatumVon DATETIME;
DECLARE @DatumBis DATETIME;

-- Sprachcode des Klienten und DatumVon des Budgets eruieren.
SELECT 
  @LanguageCode = ISNULL(PRS.VerstaendigungSprachCode, PRS.SprachCode),
  @DatumVon     = dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1)
FROM dbo.BgBudget            BDG WITH (READUNCOMMITTED)
 INNER JOIN dbo.BgFinanzplan FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
 INNER JOIN dbo.FaLeistung   LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID   = FPL.FaLeistungID
 INNER JOIN dbo.BaPerson     PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID     = LEI.BaPersonID
WHERE BDG.BgBudgetID =  @BgBudgetId;
 
-- Defaultsprache DE
IF @LanguageCode IS NULL
BEGIN
  SET @LanguageCode = 1;
END;

SELECT @DatumBis = dbo.fnLastDayOf(@DatumVon);

-- Position der Adresse aus Config lesen
DECLARE @AdresseLocationX INT;
DECLARE @AdresseLocationY INT;

SELECT @AdresseLocationX = CONVERT(INT, SplitValue)
FROM dbo.fnSplitStringToValues(CONVERT(VARCHAR(MAX), dbo.fnXConfig(''System\Adresse\PositionAufReport'', GETDATE())), '','', 0) 
WHERE OccurenceID = 0;

SELECT @AdresseLocationY = CONVERT(INT, SplitValue)
FROM dbo.fnSplitStringToValues(CONVERT(VARCHAR(MAX), dbo.fnXConfig(''System\Adresse\PositionAufReport'', GETDATE())), '','', 0) 
WHERE OccurenceID = 1;

SELECT
  AdresseLocationX = @AdresseLocationX,
  AdresseLocationY = @AdresseLocationY,
  Org_Name      = ISNULL(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Organisation'', GETDATE())), ''''),
  Org_Adresse   = ISNULL(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Adresse'', GETDATE())), ''''),
  Org_PLZ       = ISNULL(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', GETDATE())), ''''),
  Org_Ort       = ISNULL(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', GETDATE())), ''''),
  Org_PLZOrt    = ISNULL(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', GETDATE())) + '' '', '''')
                  + ISNULL(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', GETDATE())), ''''), 
  BgBudgetID    = BDG.BgBudgetID,                             
  Titel         = REPLACE(
                    REPLACE(dbo.fnGetMLTextFromName(''ShMonatsbudgetGemeinde2013'', ''TextSkosBudgetVom'', @LanguageCode),
                            ''{0}'', 
                            CONVERT(VARCHAR(MAX), @DatumVon, 104)), 
                    ''{1}'', 
                    CONVERT(VARCHAR(MAX), @DatumBis, 104)),
  Name          = dbo.fnGetEhepaarName(PRS.BaPersonID, BDG.BgFinanzplanID, 1, @LanguageCode),
  Strasse       = PRS.WohnsitzStrasseHausNr,
  Ort           = PRS.WohnsitzPLZOrt,
  SarZustaendig = USR.VornameName,
  GedrucktAm    = dbo.fnGetMLTextFromName(''ShMonatsbudgetGemeinde2013'', ''TextPer'',   @LanguageCode) + '' '' + CONVERT(VARCHAR, GETDATE(), 104), 
  TextSeite     = dbo.fnGetMLTextFromName(''ShMonatsbudgetGemeinde2013'', ''TextSeite'', @LanguageCode),
  TextAbSeite2  = dbo.fnGetEhepaarName(PRS.BaPersonID, BDG.BgFinanzplanID, 0, @LanguageCode) + '', '' + CONVERT(VARCHAR(MAX), @DatumVon, 104) + '' - '' + CONVERT(VARCHAR(MAX), @DatumBis, 104) + '', '' + dbo.fnGetMLTextFromName(''ShMonatsbudgetGemeinde2013'', ''TextSeite'', @LanguageCode),
 Bemerkung     = dbo.fnGetMLTextFromName(''ShMonatsbudgetGemeinde2013'', ''TextBemerkungen'', @LanguageCode) + CHAR(13) + CHAR(10) + FPL.Bemerkung
FROM dbo.BgBudget              BDG WITH (READUNCOMMITTED)
  INNER JOIN dbo.BgFinanzplan  FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
  INNER JOIN dbo.FaLeistung    LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
  INNER JOIN dbo.vwPerson      PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
  INNER JOIN dbo.vwUser        USR WITH (READUNCOMMITTED) ON USR.UserID = LEI.UserID
WHERE LEI.ModulID = 3
  AND BDG.Monat IS NOT NULL
  AND BDG.BgBudgetID = @BgBudgetId;' , ContextForms =  N'WhMonatsbudget' , ParentReportName =  null , ReportSortKey =  null , System =  1 
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'ShMonatsbudgetGemeinde2013' ;


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'ShMonatsbudgetGemeinde2013_Detail' ,  N'Detail' , 1,  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>de-CH</Localization>
///   <References>
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraPrinting.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Drawing\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Configuration\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.SqlXml\v4.0_4.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Security\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.Utils.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Utils.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Forms\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Forms.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Accessibility\v4.0_4.0.0.0__b03f5f7f11d50a3a\Accessibility.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Deployment\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Deployment.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Core\v4.0_4.0.0.0__b77a5c561934e089\System.Core.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Numerics\v4.0_4.0.0.0__b77a5c561934e089\System.Numerics.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Serialization.Formatters.Soap\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Runtime.Serialization.Formatters.Soap.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Design\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Design.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Data\v4.0_4.0.0.0__b77a5c561934e089\System.Data.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Transactions\v4.0_4.0.0.0__b77a5c561934e089\System.Transactions.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.EnterpriseServices\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.EnterpriseServices.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.DirectoryServices\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Remoting\v4.0_4.0.0.0__b77a5c561934e089\System.Runtime.Remoting.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Web\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Framework\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Framework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xaml\v4.0_4.0.0.0__b77a5c561934e089\System.Xaml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ComponentModel.DataAnnotations\v4.0_4.0.0.0__31bf3856ad364e35\System.ComponentModel.DataAnnotations.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Caching\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Runtime.Caching.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Web.ApplicationServices\v4.0_4.0.0.0__31bf3856ad364e35\System.Web.ApplicationServices.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Web.Services\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.Services.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Utilities.v4.0\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Utilities.v4.0.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.DirectoryServices.Protocols\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.Protocols.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Tasks.v4.0\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Tasks.v4.0.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ServiceProcess\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.ServiceProcess.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Configuration.Install\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.Install.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Serialization\v4.0_4.0.0.0__b77a5c561934e089\System.Runtime.Serialization.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Internals\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Internals.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\SMDiagnostics\v4.0_4.0.0.0__b77a5c561934e089\SMDiagnostics.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Web.RegularExpressions\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.RegularExpressions.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Drawing.Design\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.Design.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Data.OracleClient\v4.0_4.0.0.0__b77a5c561934e089\System.Data.OracleClient.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraEditors.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.Data.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Data.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraBars.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraNavBar.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraCharts.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraRichTextEdit.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="C:\KiSS\KiSS4\KiSS4.DB.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.Interfaces.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\KiSS\KiSS4\FluentValidation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xml.Linq\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.Linq.dll" />
///     <Reference Path="C:\KiSS\KiSS4\log4net.dll" />
///     <Reference Path="C:\KiSS\KiSS4\SharpLibrary.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Microsoft.Practices.Unity.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Ionic.Zip.dll" />
///     <Reference Path="C:\KiSS\KiSS4\PdfSharp.dll" />
///     <Reference Path="C:\KiSS\KiSS4\itextsharp.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Microsoft.Practices.Unity.Configuration.dll" />
///     <Reference Path="C:\KiSS\KiSS4\C1.C1Zip.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.BusinessLogic.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.DbContext.dll" />
///     <Reference Path="C:\KiSS\KiSS4\EntityFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.CSharp\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.CSharp.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Dynamic\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Dynamic.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.DataAccess.dll" />
///     <Reference Path="C:\KiSS\KiSS4\HtmlAgilityPack.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.BL.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.Model.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel\v4.0_4.0.0.0__b77a5c561934e089\System.ServiceModel.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.DurableInstancing\v4.0_4.0.0.0__31bf3856ad364e35\System.Runtime.DurableInstancing.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Net.Http\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Net.Http.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.IdentityModel\v4.0_4.0.0.0__b77a5c561934e089\System.IdentityModel.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Messaging\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Messaging.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.IdentityModel.Selectors\v4.0_4.0.0.0__b77a5c561934e089\System.IdentityModel.Selectors.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Transactions.Bridge\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Transactions.Bridge.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Activation\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Activation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xaml.Hosting\v4.0_4.0.0.0__31bf3856ad364e35\System.Xaml.Hosting.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Activities\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Activities.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Activities\v4.0_4.0.0.0__31bf3856ad364e35\System.Activities.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\Microsoft.VisualBasic.Activities.Compiler\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualBasic.Activities.Compiler.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.VisualBasic\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualBasic.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Management\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Management.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.JScript\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.JScript.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Activities.DurableInstancing\v4.0_4.0.0.0__31bf3856ad364e35\System.Activities.DurableInstancing.dll" />
///     <Reference Path="C:\KiSS\KiSS4\KiSS.Common.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Autofac.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Common.Logging.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.Database.dll" />
///     <Reference Path="C:\KiSS\KiSS4\WPFLocalizeExtension.dll" />
///     <Reference Path="C:\KiSS\KiSS4\XAMLMarkupExtensions.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail_script;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel lblBetrag;
        private DevExpress.XtraReports.UI.XRLabel lblText;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1_script;
        private DevExpress.XtraReports.UI.XRLabel lblGroupHeader1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader2;
        private DevExpress.XtraReports.UI.XRLabel lblGroupHeader2;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1_script;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel lblGroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel lblSumBetrag1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter2_script;
        private DevExpress.XtraReports.UI.XRLabel lblSumBetragDisplay2;
        private DevExpress.XtraReports.UI.XRLabel lblSumBetragKlient2;
        private DevExpress.XtraReports.UI.XRLabel lblSumBetrag2;
        private DevExpress.XtraReports.UI.XRLabel lblGroupFooter2;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter3_script;
        private DevExpress.XtraReports.UI.XRLabel lblSumBetrag3;
        private DevExpress.XtraReports.UI.XRLabel lblGroupFooter3;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter4;
        private DevExpress.XtraReports.UI.XRPanel xrPanel3;
        private DevExpress.XtraReports.UI.XRLabel lblbetragDirekteinnahmen;
        private DevExpress.XtraReports.UI.XRLabel lblDirekteinnahmen;
        private DevExpress.XtraReports.UI.XRPanel xrPanel2;
        private DevExpress.XtraReports.UI.XRLabel lblBetragDirektausgaben;
        private DevExpress.XtraReports.UI.XRLabel lblDirektausgaben;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRLabel lblAuszahlungAnKlient;
        private DevExpress.XtraReports.UI.XRLabel lblBetragAuszahlungKlient;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel lblKlient;
        private DevExpress.XtraReports.UI.XRLabel lblDritteSd;
        private DevExpress.XtraReports.UI.XRLabel lblBudget;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAAGAAAAAAAAAFBBRFBBRFATtE6kk" +
                        "V1HrTHIEjurNQNPaWNQVYg9Fm+nAQAAAAAAAFABAABLAAAA+QAAAKIAAADCAgAARkQAZQB0AGEAaQBsA" +
                        "F8AcwBjAHIAaQBwAHQALgBTAGMAcgBpAHAAdABzAC4ATwBuAEIAZQBmAG8AcgBlAFAAcgBpAG4AdAAAA" +
                        "AAAUkcAcgBvAHUAcABGAG8AbwB0AGUAcgAxAF8AcwBjAHIAaQBwAHQALgBTAGMAcgBpAHAAdABzAC4AT" +
                        "wBuAEIAZQBmAG8AcgBlAFAAcgBpAG4AdADUAAAAUkcAcgBvAHUAcABGAG8AbwB0AGUAcgAyAF8AcwBjA" +
                        "HIAaQBwAHQALgBTAGMAcgBpAHAAdABzAC4ATwBuAEIAZQBmAG8AcgBlAFAAcgBpAG4AdAAuAgAAUkcAc" +
                        "gBvAHUAcABGAG8AbwB0AGUAcgAzAF8AcwBjAHIAaQBwAHQALgBTAGMAcgBpAHAAdABzAC4ATwBuAEIAZ" +
                        "QBmAG8AcgBlAFAAcgBpAG4AdADOBAAAUkcAcgBvAHUAcABIAGUAYQBkAGUAcgAxAF8AcwBjAHIAaQBwA" +
                        "HQALgBTAGMAcgBpAHAAdABzAC4ATwBuAEIAZQBmAG8AcgBlAFAAcgBpAG4AdAAoBgAAMnMAcQBsAFEAd" +
                        "QBlAHIAeQAxAC4AUwBlAGwAZQBjAHQAUwB0AGEAdABlAG0AZQBuAHQAXAcAAAHRAXByaXZhdGUgdm9pZ" +
                        "CBPbkJlZm9yZVByaW50KG9iamVjdCBzZW5kZXIsIFN5c3RlbS5EcmF3aW5nLlByaW50aW5nLlByaW50R" +
                        "XZlbnRBcmdzIGUpIHsNCiAgICBib29sIHZpc2libGUgPSAhKEdldEN1cnJlbnRDb2x1bW5WYWx1ZSgiS" +
                        "GlkZUJldHJhZ0Rpc3BsYXlTRCIpIGFzIGJvb2w/ID8/IGZhbHNlKTsNCiAgICBsYmxCZXRyYWcuVmlza" +
                        "WJsZSA9IHZpc2libGU7DQp9AdcCcHJpdmF0ZSB2b2lkIE9uQmVmb3JlUHJpbnQob2JqZWN0IHNlbmRlc" +
                        "iwgU3lzdGVtLkRyYXdpbmcuUHJpbnRpbmcuUHJpbnRFdmVudEFyZ3MgZSkgew0KICAgIHN0cmluZyBnc" +
                        "m91cEZvb3RlcjEgPSBHZXRDdXJyZW50Q29sdW1uVmFsdWUoIkdyb3VwRm9vdGVyMSIpIGFzIHN0cmluZ" +
                        "zsNCiAgICBib29sIHZpc2libGUgPSAhc3RyaW5nLklzTnVsbE9yRW1wdHkoZ3JvdXBGb290ZXIxKTsNC" +
                        "iAgICBsYmxHcm91cEZvb3RlcjEuVmlzaWJsZSA9IHZpc2libGU7DQogICAgbGJsU3VtQmV0cmFnMS5Wa" +
                        "XNpYmxlID0gdmlzaWJsZTsNCiAgICBHcm91cEZvb3RlcjFfc2NyaXB0LlZpc2libGUgPSB2aXNpYmxlO" +
                        "w0KfQGdBXByaXZhdGUgdm9pZCBPbkJlZm9yZVByaW50KG9iamVjdCBzZW5kZXIsIFN5c3RlbS5EcmF3a" +
                        "W5nLlByaW50aW5nLlByaW50RXZlbnRBcmdzIGUpIHsNCiAgICBib29sIHZpc2libGUgPSAhKEdldEN1c" +
                        "nJlbnRDb2x1bW5WYWx1ZSgiSGlkZUJldHJhZ0Rpc3BsYXlTRCIpIGFzIGJvb2w/ID8/IGZhbHNlKTsNC" +
                        "iAgICBsYmxTdW1CZXRyYWcyLlZpc2libGUgPSB2aXNpYmxlOw0KDQogICAgdmlzaWJsZSA9ICEoR2V0Q" +
                        "3VycmVudENvbHVtblZhbHVlKCJIaWRlU3VtQmV0cmFnRGlzcGxheSIpIGFzIGJvb2w/ID8/IGZhbHNlK" +
                        "TsNCiAgICBsYmxTdW1CZXRyYWdEaXNwbGF5Mi5WaXNpYmxlID0gdmlzaWJsZTsNCg0KICAgIGJvb2wgY" +
                        "WRkUGFnZUJyZWFrID0gR2V0Q3VycmVudENvbHVtblZhbHVlKCJBZGRQYWdlQnJlYWtBZnRlckdyb3VwI" +
                        "ikgYXMgYm9vbD8gPz8gZmFsc2U7DQogICAgaWYgKGFkZFBhZ2VCcmVhaykNCiAgICB7DQogICAgICAgI" +
                        "Edyb3VwRm9vdGVyMl9zY3JpcHQuUGFnZUJyZWFrID0gRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5QY" +
                        "WdlQnJlYWsuQWZ0ZXJCYW5kOw0KICAgIH0NCiAgICBlbHNlDQogICAgew0KICAgICAgICBHcm91cEZvb" +
                        "3RlcjJfc2NyaXB0LlBhZ2VCcmVhayA9IERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuUGFnZUJyZWFrL" +
                        "k5vbmU7DQogICAgfQ0KfQHXAnByaXZhdGUgdm9pZCBPbkJlZm9yZVByaW50KG9iamVjdCBzZW5kZXIsI" +
                        "FN5c3RlbS5EcmF3aW5nLlByaW50aW5nLlByaW50RXZlbnRBcmdzIGUpIHsNCiAgICBzdHJpbmcgZ3Jvd" +
                        "XBGb290ZXIzID0gR2V0Q3VycmVudENvbHVtblZhbHVlKCJHcm91cEZvb3RlcjMiKSBhcyBzdHJpbmc7D" +
                        "QogICAgYm9vbCB2aXNpYmxlID0gIXN0cmluZy5Jc051bGxPckVtcHR5KGdyb3VwRm9vdGVyMyk7DQogI" +
                        "CAgbGJsR3JvdXBGb290ZXIzLlZpc2libGUgPSB2aXNpYmxlOw0KICAgIGxibFN1bUJldHJhZzMuVmlza" +
                        "WJsZSA9IHZpc2libGU7DQogICAgR3JvdXBGb290ZXIzX3NjcmlwdC5WaXNpYmxlID0gdmlzaWJsZTsNC" +
                        "n0BsQJwcml2YXRlIHZvaWQgT25CZWZvcmVQcmludChvYmplY3Qgc2VuZGVyLCBTeXN0ZW0uRHJhd2luZ" +
                        "y5QcmludGluZy5QcmludEV2ZW50QXJncyBlKSB7DQogICAgc3RyaW5nIGdyb3VwSGVhZGVyMSA9IEdld" +
                        "EN1cnJlbnRDb2x1bW5WYWx1ZSgiR3JvdXBIZWFkZXIxIikgYXMgc3RyaW5nOw0KICAgIGJvb2wgdmlza" +
                        "WJsZSA9ICFzdHJpbmcuSXNOdWxsT3JFbXB0eShncm91cEhlYWRlcjEpOw0KICAgIGxibEdyb3VwSGVhZ" +
                        "GVyMS5WaXNpYmxlID0gdmlzaWJsZTsNCiAgICBHcm91cEhlYWRlcjFfc2NyaXB0LlZpc2libGUgPSB2a" +
                        "XNpYmxlOw0KfQGdBkRFQ0xBUkUgQEJnQnVkZ2V0SWQgSU5UOw0KU0VUIEBCZ0J1ZGdldElkID0gbnVsb" +
                        "DsNCg0KREVDTEFSRSBAR0JMIE1PTkVZOw0KU0VUIEBHQkwgPSBudWxsOw0KDQpERUNMQVJFIEBMYW5nd" +
                        "WFnZUNvZGUgSU5UOw0KDQotLSBTcHJhY2hjb2RlIGRlcyBLbGllbnRlbiBlcnVpZXJlbi4NClNFTEVDV" +
                        "CBATGFuZ3VhZ2VDb2RlID0gSVNOVUxMKFBSUy5WZXJzdGFlbmRpZ3VuZ1NwcmFjaENvZGUsIFBSUy5Tc" +
                        "HJhY2hDb2RlKQ0KRlJPTSBkYm8uQmdCdWRnZXQgICAgICAgICAgICBCREcgV0lUSCAoUkVBRFVOQ09NT" +
                        "UlUVEVEKQ0KIElOTkVSIEpPSU4gZGJvLkJnRmluYW56cGxhbiBGUEwgV0lUSCAoUkVBRFVOQ09NTUlUV" +
                        "EVEKSBPTiBGUEwuQmdGaW5hbnpwbGFuSUQgPSBCREcuQmdGaW5hbnpwbGFuSUQNCiBJTk5FUiBKT0lOI" +
                        "GRiby5GYUxlaXN0dW5nICAgTEVJIFdJVEggKFJFQURVTkNPTU1JVFRFRCkgT04gTEVJLkZhTGVpc3R1b" +
                        "mdJRCAgID0gRlBMLkZhTGVpc3R1bmdJRA0KIElOTkVSIEpPSU4gZGJvLkJhUGVyc29uICAgICBQUlMgV" +
                        "0lUSCAoUkVBRFVOQ09NTUlUVEVEKSBPTiBQUlMuQmFQZXJzb25JRCAgICAgPSBMRUkuQmFQZXJzb25JR" +
                        "A0KV0hFUkUgQkRHLkJnQnVkZ2V0SUQgPSAgQEJnQnVkZ2V0SWQ7DQogDQotLSBEZWZhdWx0c3ByYWNoZ" +
                        "SBERQ0KSUYgQExhbmd1YWdlQ29kZSBJUyBOVUxMDQpCRUdJTg0KICBTRVQgQExhbmd1YWdlQ29kZSA9I" +
                        "DE7DQpFTkQ7DQoNCkVYRUMgZGJvLnNwUmVwb3J0V2hNb25hdHNidWRnZXRHZW1laW5kZTIwMTMgQEJnQ" +
                        "nVkZ2V0SUQsIEBHQkwsIEBMYW5ndWFnZUNvZGU7";
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
            DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary10 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary11 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail_script = new DevExpress.XtraReports.UI.DetailBand();
            this.GroupHeader1_script = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1_script = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter2_script = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter3_script = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter4 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.lblText = new DevExpress.XtraReports.UI.XRLabel();
            this.lblGroupHeader1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblGroupHeader2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblGroupFooter1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSumBetrag1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSumBetragDisplay2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSumBetragKlient2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSumBetrag2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblGroupFooter2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSumBetrag3 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblGroupFooter3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel3 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrPanel2 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.lblbetragDirekteinnahmen = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDirekteinnahmen = new DevExpress.XtraReports.UI.XRLabel();
            this.lblBetragDirektausgaben = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDirektausgaben = new DevExpress.XtraReports.UI.XRLabel();
            this.lblAuszahlungAnKlient = new DevExpress.XtraReports.UI.XRLabel();
            this.lblBetragAuszahlungKlient = new DevExpress.XtraReports.UI.XRLabel();
            this.lblKlient = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDritteSd = new DevExpress.XtraReports.UI.XRLabel();
            this.lblBudget = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail_script
            // 
            this.Detail_script.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel1,
                        this.lblBetrag,
                        this.lblText});
            this.Detail_script.Height = 20;
            this.Detail_script.KeepTogether = true;
            this.Detail_script.Name = "Detail_script";
            this.Detail_script.Scripts.OnBeforePrint = resources.GetString("Detail_script.Scripts.OnBeforePrint");
            // 
            // GroupHeader1_script
            // 
            this.GroupHeader1_script.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblGroupHeader1});
            this.GroupHeader1_script.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("SortKey1", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1_script.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WholePage;
            this.GroupHeader1_script.Height = 20;
            this.GroupHeader1_script.Name = "GroupHeader1_script";
            this.GroupHeader1_script.Scripts.OnBeforePrint = resources.GetString("GroupHeader1_script.Scripts.OnBeforePrint");
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblGroupHeader2});
            this.GroupHeader2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("SortKey2", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader2.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.GroupHeader2.Height = 20;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // GroupFooter1_script
            // 
            this.GroupFooter1_script.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel2,
                        this.lblGroupFooter1,
                        this.lblSumBetrag1});
            this.GroupFooter1_script.Height = 25;
            this.GroupFooter1_script.Name = "GroupFooter1_script";
            this.GroupFooter1_script.Scripts.OnBeforePrint = resources.GetString("GroupFooter1_script.Scripts.OnBeforePrint");
            // 
            // GroupFooter2_script
            // 
            this.GroupFooter2_script.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblSumBetragDisplay2,
                        this.lblSumBetragKlient2,
                        this.lblSumBetrag2,
                        this.lblGroupFooter2});
            this.GroupFooter2_script.Height = 46;
            this.GroupFooter2_script.Level = 1;
            this.GroupFooter2_script.Name = "GroupFooter2_script";
            this.GroupFooter2_script.Scripts.OnBeforePrint = resources.GetString("GroupFooter2_script.Scripts.OnBeforePrint");
            // 
            // GroupFooter3_script
            // 
            this.GroupFooter3_script.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblSumBetrag3,
                        this.lblGroupFooter3});
            this.GroupFooter3_script.Height = 34;
            this.GroupFooter3_script.Level = 2;
            this.GroupFooter3_script.Name = "GroupFooter3_script";
            this.GroupFooter3_script.ParentStyleUsing.UseFont = false;
            this.GroupFooter3_script.Scripts.OnBeforePrint = resources.GetString("GroupFooter3_script.Scripts.OnBeforePrint");
            // 
            // GroupFooter4
            // 
            this.GroupFooter4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPanel3,
                        this.xrPanel2,
                        this.xrPanel1});
            this.GroupFooter4.Height = 146;
            this.GroupFooter4.Level = 3;
            this.GroupFooter4.Name = "GroupFooter4";
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("SortKey3", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader3.Height = 0;
            this.GroupHeader3.Level = 2;
            this.GroupHeader3.Name = "GroupHeader3";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblKlient,
                        this.lblDritteSd,
                        this.lblBudget});
            this.PageHeader.Height = 25;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragDisplayKlient", "{0:n2}")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 11F);
            this.xrLabel1.Location = new System.Drawing.Point(458, 0);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(92, 20);
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblBetrag
            // 
            this.lblBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragDisplayDritteSD", "{0:n2}")});
            this.lblBetrag.Font = new System.Drawing.Font("Arial", 11F);
            this.lblBetrag.Location = new System.Drawing.Point(558, 0);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblBetrag.ParentStyleUsing.UseFont = false;
            this.lblBetrag.Size = new System.Drawing.Size(92, 20);
            this.lblBetrag.Text = "lblBetrag";
            this.lblBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblText
            // 
            this.lblText.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text", "")});
            this.lblText.Font = new System.Drawing.Font("Arial", 11F);
            this.lblText.Location = new System.Drawing.Point(0, 0);
            this.lblText.Name = "lblText";
            this.lblText.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblText.ParentStyleUsing.UseFont = false;
            this.lblText.Size = new System.Drawing.Size(450, 20);
            this.lblText.Text = "lblText";
            // 
            // lblGroupHeader1
            // 
            this.lblGroupHeader1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GroupHeader1", "")});
            this.lblGroupHeader1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblGroupHeader1.Location = new System.Drawing.Point(0, 0);
            this.lblGroupHeader1.Name = "lblGroupHeader1";
            this.lblGroupHeader1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblGroupHeader1.ParentStyleUsing.UseFont = false;
            this.lblGroupHeader1.Size = new System.Drawing.Size(450, 20);
            this.lblGroupHeader1.Text = "lblGroupHeader1";
            // 
            // lblGroupHeader2
            // 
            this.lblGroupHeader2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GroupHeader2", "")});
            this.lblGroupHeader2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblGroupHeader2.Location = new System.Drawing.Point(0, 0);
            this.lblGroupHeader2.Name = "lblGroupHeader2";
            this.lblGroupHeader2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblGroupHeader2.ParentStyleUsing.UseFont = false;
            this.lblGroupHeader2.Size = new System.Drawing.Size(450, 20);
            this.lblGroupHeader2.Text = "lblGroupHeader2";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragDisplayKlient", "")});
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.Location = new System.Drawing.Point(458, 0);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(92, 25);
            xrSummary1.FormatString = "{0:n2}";
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel2.Summary = xrSummary1;
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblGroupFooter1
            // 
            this.lblGroupFooter1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GroupFooter1", "")});
            this.lblGroupFooter1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblGroupFooter1.Location = new System.Drawing.Point(0, 0);
            this.lblGroupFooter1.Name = "lblGroupFooter1";
            this.lblGroupFooter1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblGroupFooter1.ParentStyleUsing.UseFont = false;
            this.lblGroupFooter1.Size = new System.Drawing.Size(450, 25);
            this.lblGroupFooter1.Text = "lblGroupFooter1";
            // 
            // lblSumBetrag1
            // 
            this.lblSumBetrag1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragDisplayDritteSD", "")});
            this.lblSumBetrag1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblSumBetrag1.Location = new System.Drawing.Point(558, 0);
            this.lblSumBetrag1.Name = "lblSumBetrag1";
            this.lblSumBetrag1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSumBetrag1.ParentStyleUsing.UseFont = false;
            this.lblSumBetrag1.Size = new System.Drawing.Size(92, 25);
            xrSummary2.FormatString = "{0:n2}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.lblSumBetrag1.Summary = xrSummary2;
            this.lblSumBetrag1.Text = "lblSumBetrag1";
            this.lblSumBetrag1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblSumBetragDisplay2
            // 
            this.lblSumBetragDisplay2.BackColor = System.Drawing.Color.LightGray;
            this.lblSumBetragDisplay2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragDisplay", "")});
            this.lblSumBetragDisplay2.Font = new System.Drawing.Font("Arial", 11F);
            this.lblSumBetragDisplay2.Location = new System.Drawing.Point(358, 0);
            this.lblSumBetragDisplay2.Name = "lblSumBetragDisplay2";
            this.lblSumBetragDisplay2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSumBetragDisplay2.ParentStyleUsing.UseBackColor = false;
            this.lblSumBetragDisplay2.ParentStyleUsing.UseFont = false;
            this.lblSumBetragDisplay2.Size = new System.Drawing.Size(92, 25);
            xrSummary3.FormatString = "{0:n2}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.lblSumBetragDisplay2.Summary = xrSummary3;
            this.lblSumBetragDisplay2.Text = "lblSumBetragDisplay2";
            this.lblSumBetragDisplay2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblSumBetragKlient2
            // 
            this.lblSumBetragKlient2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragDisplayKlient", "")});
            this.lblSumBetragKlient2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblSumBetragKlient2.Location = new System.Drawing.Point(458, 0);
            this.lblSumBetragKlient2.Name = "lblSumBetragKlient2";
            this.lblSumBetragKlient2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSumBetragKlient2.ParentStyleUsing.UseFont = false;
            this.lblSumBetragKlient2.Size = new System.Drawing.Size(92, 25);
            xrSummary4.FormatString = "{0:n2}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.lblSumBetragKlient2.Summary = xrSummary4;
            this.lblSumBetragKlient2.Text = "lblSumBetragKlient2";
            this.lblSumBetragKlient2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblSumBetrag2
            // 
            this.lblSumBetrag2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragDisplayDritteSD", "")});
            this.lblSumBetrag2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblSumBetrag2.Location = new System.Drawing.Point(558, 0);
            this.lblSumBetrag2.Name = "lblSumBetrag2";
            this.lblSumBetrag2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSumBetrag2.ParentStyleUsing.UseFont = false;
            this.lblSumBetrag2.Size = new System.Drawing.Size(92, 25);
            xrSummary5.FormatString = "{0:n2}";
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.lblSumBetrag2.Summary = xrSummary5;
            this.lblSumBetrag2.Text = "lblSumBetrag2";
            this.lblSumBetrag2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblGroupFooter2
            // 
            this.lblGroupFooter2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GroupFooter2", "")});
            this.lblGroupFooter2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblGroupFooter2.Location = new System.Drawing.Point(0, 0);
            this.lblGroupFooter2.Name = "lblGroupFooter2";
            this.lblGroupFooter2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblGroupFooter2.ParentStyleUsing.UseFont = false;
            this.lblGroupFooter2.Size = new System.Drawing.Size(350, 25);
            this.lblGroupFooter2.Text = "lblGroupFooter2";
            this.lblGroupFooter2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblSumBetrag3
            // 
            this.lblSumBetrag3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragKlient", "")});
            this.lblSumBetrag3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblSumBetrag3.Location = new System.Drawing.Point(458, 0);
            this.lblSumBetrag3.Name = "lblSumBetrag3";
            this.lblSumBetrag3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSumBetrag3.ParentStyleUsing.UseFont = false;
            this.lblSumBetrag3.Size = new System.Drawing.Size(92, 25);
            xrSummary6.FormatString = "{0:n2}";
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.lblSumBetrag3.Summary = xrSummary6;
            this.lblSumBetrag3.Text = "lblSumBetrag3";
            this.lblSumBetrag3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblGroupFooter3
            // 
            this.lblGroupFooter3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GroupFooter3", "")});
            this.lblGroupFooter3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblGroupFooter3.Location = new System.Drawing.Point(0, 0);
            this.lblGroupFooter3.Name = "lblGroupFooter3";
            this.lblGroupFooter3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblGroupFooter3.ParentStyleUsing.UseFont = false;
            this.lblGroupFooter3.Size = new System.Drawing.Size(450, 25);
            this.lblGroupFooter3.Text = "lblGroupFooter3";
            // 
            // xrPanel3
            // 
            this.xrPanel3.BackColor = System.Drawing.Color.LightGray;
            this.xrPanel3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblbetragDirekteinnahmen,
                        this.lblDirekteinnahmen});
            this.xrPanel3.Location = new System.Drawing.Point(0, 92);
            this.xrPanel3.Name = "xrPanel3";
            this.xrPanel3.ParentStyleUsing.UseBackColor = false;
            this.xrPanel3.ParentStyleUsing.UseBorders = false;
            this.xrPanel3.Size = new System.Drawing.Size(650, 25);
            // 
            // xrPanel2
            // 
            this.xrPanel2.BackColor = System.Drawing.Color.LightGray;
            this.xrPanel2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblBetragDirektausgaben,
                        this.lblDirektausgaben});
            this.xrPanel2.Location = new System.Drawing.Point(0, 61);
            this.xrPanel2.Name = "xrPanel2";
            this.xrPanel2.ParentStyleUsing.UseBackColor = false;
            this.xrPanel2.ParentStyleUsing.UseBorders = false;
            this.xrPanel2.Size = new System.Drawing.Size(550, 25);
            // 
            // xrPanel1
            // 
            this.xrPanel1.BackColor = System.Drawing.Color.LightGray;
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblAuszahlungAnKlient,
                        this.lblBetragAuszahlungKlient});
            this.xrPanel1.Location = new System.Drawing.Point(0, 0);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.ParentStyleUsing.UseBackColor = false;
            this.xrPanel1.ParentStyleUsing.UseBorders = false;
            this.xrPanel1.Size = new System.Drawing.Size(550, 25);
            // 
            // lblbetragDirekteinnahmen
            // 
            this.lblbetragDirekteinnahmen.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Direkteinnahmen", "")});
            this.lblbetragDirekteinnahmen.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblbetragDirekteinnahmen.Location = new System.Drawing.Point(558, 0);
            this.lblbetragDirekteinnahmen.Name = "lblbetragDirekteinnahmen";
            this.lblbetragDirekteinnahmen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblbetragDirekteinnahmen.ParentStyleUsing.UseFont = false;
            this.lblbetragDirekteinnahmen.Size = new System.Drawing.Size(92, 25);
            xrSummary7.FormatString = "{0:n2}";
            xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.lblbetragDirekteinnahmen.Summary = xrSummary7;
            this.lblbetragDirekteinnahmen.Text = "lblbetragDirekteinnahmen";
            this.lblbetragDirekteinnahmen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblDirekteinnahmen
            // 
            this.lblDirekteinnahmen.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TextDirekteinnahmen", "")});
            this.lblDirekteinnahmen.Font = new System.Drawing.Font("Arial", 11F);
            this.lblDirekteinnahmen.Location = new System.Drawing.Point(0, 0);
            this.lblDirekteinnahmen.Name = "lblDirekteinnahmen";
            this.lblDirekteinnahmen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDirekteinnahmen.ParentStyleUsing.UseFont = false;
            this.lblDirekteinnahmen.Size = new System.Drawing.Size(450, 25);
            this.lblDirekteinnahmen.Text = "lblDirekteinnahmen";
            this.lblDirekteinnahmen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblBetragDirektausgaben
            // 
            this.lblBetragDirektausgaben.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Direktausgaben", "")});
            this.lblBetragDirektausgaben.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblBetragDirektausgaben.Location = new System.Drawing.Point(458, 0);
            this.lblBetragDirektausgaben.Name = "lblBetragDirektausgaben";
            this.lblBetragDirektausgaben.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblBetragDirektausgaben.ParentStyleUsing.UseFont = false;
            this.lblBetragDirektausgaben.Size = new System.Drawing.Size(92, 25);
            xrSummary8.FormatString = "{0:n2}";
            xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.lblBetragDirektausgaben.Summary = xrSummary8;
            this.lblBetragDirektausgaben.Text = "lblBetragDirektausgaben";
            this.lblBetragDirektausgaben.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblDirektausgaben
            // 
            this.lblDirektausgaben.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TextDirektausgaben", "")});
            this.lblDirektausgaben.Font = new System.Drawing.Font("Arial", 11F);
            this.lblDirektausgaben.Location = new System.Drawing.Point(0, 0);
            this.lblDirektausgaben.Name = "lblDirektausgaben";
            this.lblDirektausgaben.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDirektausgaben.ParentStyleUsing.UseFont = false;
            this.lblDirektausgaben.Size = new System.Drawing.Size(450, 25);
            this.lblDirektausgaben.Text = "lblDirektausgaben";
            this.lblDirektausgaben.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblAuszahlungAnKlient
            // 
            this.lblAuszahlungAnKlient.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GroupFooter4", "")});
            this.lblAuszahlungAnKlient.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblAuszahlungAnKlient.Location = new System.Drawing.Point(0, 0);
            this.lblAuszahlungAnKlient.Name = "lblAuszahlungAnKlient";
            this.lblAuszahlungAnKlient.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblAuszahlungAnKlient.ParentStyleUsing.UseFont = false;
            this.lblAuszahlungAnKlient.Size = new System.Drawing.Size(450, 25);
            this.lblAuszahlungAnKlient.Text = "lblAuszahlungAnKlient";
            this.lblAuszahlungAnKlient.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblBetragAuszahlungKlient
            // 
            this.lblBetragAuszahlungKlient.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragKlient", "")});
            this.lblBetragAuszahlungKlient.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblBetragAuszahlungKlient.Location = new System.Drawing.Point(458, 0);
            this.lblBetragAuszahlungKlient.Name = "lblBetragAuszahlungKlient";
            this.lblBetragAuszahlungKlient.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblBetragAuszahlungKlient.ParentStyleUsing.UseFont = false;
            this.lblBetragAuszahlungKlient.Size = new System.Drawing.Size(92, 25);
            xrSummary9.FormatString = "{0:n2}";
            xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.lblBetragAuszahlungKlient.Summary = xrSummary9;
            this.lblBetragAuszahlungKlient.Text = "lblBetragAuszahlungKlient";
            this.lblBetragAuszahlungKlient.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblKlient
            // 
            this.lblKlient.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TextKlient", "")});
            this.lblKlient.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblKlient.Location = new System.Drawing.Point(458, 0);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblKlient.ParentStyleUsing.UseFont = false;
            this.lblKlient.Size = new System.Drawing.Size(92, 25);
            xrSummary10.FormatString = "{0:n2}";
            this.lblKlient.Summary = xrSummary10;
            this.lblKlient.Text = "lblKlient";
            this.lblKlient.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblDritteSd
            // 
            this.lblDritteSd.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TextDritteSD", "")});
            this.lblDritteSd.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblDritteSd.Location = new System.Drawing.Point(558, 0);
            this.lblDritteSd.Name = "lblDritteSd";
            this.lblDritteSd.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDritteSd.ParentStyleUsing.UseFont = false;
            this.lblDritteSd.Size = new System.Drawing.Size(92, 25);
            xrSummary11.FormatString = "{0:n2}";
            this.lblDritteSd.Summary = xrSummary11;
            this.lblDritteSd.Text = "lblDritteSd";
            this.lblDritteSd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblBudget
            // 
            this.lblBudget.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TextBudget", "")});
            this.lblBudget.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.lblBudget.Location = new System.Drawing.Point(0, 0);
            this.lblBudget.Name = "lblBudget";
            this.lblBudget.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblBudget.ParentStyleUsing.UseFont = false;
            this.lblBudget.Size = new System.Drawing.Size(450, 25);
            this.lblBudget.Text = "lblBudget";
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail_script,
                        this.GroupHeader1_script,
                        this.GroupHeader2,
                        this.GroupFooter1_script,
                        this.GroupFooter2_script,
                        this.GroupFooter3_script,
                        this.GroupFooter4,
                        this.GroupHeader3,
                        this.PageHeader});
            this.DataSource = this.sqlQuery1;
            this.Name = "Report";
            this.PageHeight = 1100;
            this.PageWidth = 850;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'DECLARE @BgBudgetId INT;
SET @BgBudgetId = {BgBudgetID};

DECLARE @GBL MONEY;
SET @GBL = {GBL};

DECLARE @LanguageCode INT;

-- Sprachcode des Klienten eruieren.
SELECT @LanguageCode = ISNULL(PRS.VerstaendigungSprachCode, PRS.SprachCode)
FROM dbo.BgBudget            BDG WITH (READUNCOMMITTED)
 INNER JOIN dbo.BgFinanzplan FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
 INNER JOIN dbo.FaLeistung   LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID   = FPL.FaLeistungID
 INNER JOIN dbo.BaPerson     PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID     = LEI.BaPersonID
WHERE BDG.BgBudgetID =  @BgBudgetId;
 
-- Defaultsprache DE
IF @LanguageCode IS NULL
BEGIN
  SET @LanguageCode = 1;
END;

EXEC dbo.spReportWhMonatsbudgetGemeinde2013 @BgBudgetID, @GBL, @LanguageCode;' ,  null ,  N'ShMonatsbudgetGemeinde2013' ,  null ,  1 );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'ShMonatsbudgetGemeinde2013_UnterstuetztePersonen' ,  N'Unterstützte Personen' , 1,  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>de-CH</Localization>
///   <References>
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraPrinting.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Drawing\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Configuration\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.SqlXml\v4.0_4.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Security\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.Utils.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Utils.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Forms\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Forms.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Accessibility\v4.0_4.0.0.0__b03f5f7f11d50a3a\Accessibility.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Serialization.Formatters.Soap\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Runtime.Serialization.Formatters.Soap.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Deployment\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Deployment.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Design\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Design.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Data\v4.0_4.0.0.0__b77a5c561934e089\System.Data.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.VisualC\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualC.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Transactions\v4.0_4.0.0.0__b77a5c561934e089\System.Transactions.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.EnterpriseServices\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.EnterpriseServices.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.DirectoryServices\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Remoting\v4.0_4.0.0.0__b77a5c561934e089\System.Runtime.Remoting.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Web\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Framework\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Framework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xaml\v4.0_4.0.0.0__b77a5c561934e089\System.Xaml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Caching\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Runtime.Caching.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Web.ApplicationServices\v4.0_4.0.0.0__31bf3856ad364e35\System.Web.ApplicationServices.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Core\v4.0_4.0.0.0__b77a5c561934e089\System.Core.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Numerics\v4.0_4.0.0.0__b77a5c561934e089\System.Numerics.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Web.Services\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.Services.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Utilities.v4.0\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Utilities.v4.0.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.DirectoryServices.Protocols\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.Protocols.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Tasks.v4.0\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Tasks.v4.0.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ServiceProcess\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.ServiceProcess.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Configuration.Install\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.Install.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Serialization\v4.0_4.0.0.0__b77a5c561934e089\System.Runtime.Serialization.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\SMDiagnostics\v4.0_4.0.0.0__b77a5c561934e089\SMDiagnostics.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.DurableInstancing\v4.0_4.0.0.0__31bf3856ad364e35\System.Runtime.DurableInstancing.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xml.Linq\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.Linq.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Web.RegularExpressions\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.RegularExpressions.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Drawing.Design\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.Design.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Data.OracleClient\v4.0_4.0.0.0__b77a5c561934e089\System.Data.OracleClient.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraEditors.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.Data.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Data.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraBars.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraNavBar.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraCharts.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraRichTextEdit.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="C:\KiSS\KiSS4\KiSS4.DB.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.Interfaces.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\KiSS\KiSS4\FluentValidation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Microsoft.Practices.Unity.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Ionic.Zip.dll" />
///     <Reference Path="C:\KiSS\KiSS4\log4net.dll" />
///     <Reference Path="C:\KiSS\KiSS4\SharpLibrary.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.BL.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.Model.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel\v4.0_4.0.0.0__b77a5c561934e089\System.ServiceModel.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.IdentityModel\v4.0_4.0.0.0__b77a5c561934e089\System.IdentityModel.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Messaging\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Messaging.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.IdentityModel.Selectors\v4.0_4.0.0.0__b77a5c561934e089\System.IdentityModel.Selectors.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Transactions.Bridge\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Transactions.Bridge.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Activation\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Activation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Activities\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Activities.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Activities\v4.0_4.0.0.0__31bf3856ad364e35\System.Activities.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\Microsoft.VisualBasic.Activities.Compiler\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualBasic.Activities.Compiler.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.VisualBasic\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualBasic.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Management\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Management.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.JScript\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.JScript.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Activities.DurableInstancing\v4.0_4.0.0.0__31bf3856ad364e35\System.Activities.DurableInstancing.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xaml.Hosting\v4.0_4.0.0.0__31bf3856ad364e35\System.Xaml.Hosting.dll" />
///     <Reference Path="C:\KiSS\KiSS4\KiSS.Common.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Autofac.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Common.Logging.dll" />
///     <Reference Path="C:\KiSS\KiSS4\HtmlAgilityPack.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.Database.dll" />
///     <Reference Path="C:\KiSS\KiSS4\WPFLocalizeExtension.dll" />
///     <Reference Path="C:\KiSS\KiSS4\XAMLMarkupExtensions.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = @"zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OSNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kAAAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAAAAAAZIFREVDTEFSRSBAQmdCdWRnZXRJZCBJTlQ7DQpTRVQgQEJnQnVkZ2V0SWQgPSBudWxsOw0KDQpTRUxFQ1QNCiAgUGVyc29uID0gUFJTLk5hbWVWb3JuYW1lICsgSVNOVUxMKCcsICcgKyBDT05WRVJUKFZBUkNIQVIoTUFYKSwgUFJTLkdlYnVydHNkYXR1bSwgMTA0KSwgJycpICsgSVNOVUxMKCcsICcgKyBQUlMuVmVyc2ljaGVydGVubnVtbWVyLCAnJykNCkZST00gZGJvLkJnQnVkZ2V0ICAgICAgICAgICAgICAgICAgICAgICBCREcgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKQ0KICBJTk5FUiBKT0lOIGRiby5CZ0ZpbmFuenBsYW4gICAgICAgICAgIEZQTCBXSVRIIChSRUFEVU5DT01NSVRURUQpIE9OIEZQTC5CZ0ZpbmFuenBsYW5JRCA9IEJERy5CZ0ZpbmFuenBsYW5JRA0KICBJTk5FUiBKT0lOIGRiby5CZ0ZpbmFuenBsYW5fQmFQZXJzb24gIEJGQiBXSVRIIChSRUFEVU5DT01NSVRURUQpIE9OIEJGQi5CZ0ZpbmFuenBsYW5JRCA9IEZQTC5CZ0ZpbmFuenBsYW5JRA0KICBJTk5FUiBKT0lOIGRiby52d1BlcnNvblNpbXBsZSAgICAgICAgIFBSUyBXSVRIIChSRUFEVU5DT01NSVRURUQpIE9OIFBSUy5CYVBlcnNvbklEID0gQkZCLkJhUGVyc29uSUQNCldIRVJFIEJERy5CZ0J1ZGdldElEID0gQEJnQnVkZ2V0SUQNCiAgQU5EIEJGQi5Jc3RVbnRlcnN0dWV0enQgPSAxOw==";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel1});
            this.Detail.Height = 20;
            this.Detail.Name = "Detail";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Person", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 11F);
            this.xrLabel1.Location = new System.Drawing.Point(0, 0);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(633, 20);
            this.xrLabel1.Text = "xrLabel1";
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
            this.Name = "Report";
            this.PageHeight = 1100;
            this.PageWidth = 850;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'DECLARE @BgBudgetId INT;
SET @BgBudgetId = {BgBudgetID};

SELECT
  Person = PRS.NameVorname + ISNULL('', '' + CONVERT(VARCHAR(MAX), PRS.Geburtsdatum, 104), '''') + ISNULL('', '' + PRS.Versichertennummer, '''')
FROM dbo.BgBudget                       BDG WITH (READUNCOMMITTED)
  INNER JOIN dbo.BgFinanzplan           FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
  INNER JOIN dbo.BgFinanzplan_BaPerson  BFB WITH (READUNCOMMITTED) ON BFB.BgFinanzplanID = FPL.BgFinanzplanID
  INNER JOIN dbo.vwPersonSimple         PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = BFB.BaPersonID
WHERE BDG.BgBudgetID = @BgBudgetID
  AND BFB.IstUnterstuetzt = 1;' ,  null ,  N'ShMonatsbudgetGemeinde2013' ,  null ,  1 );


