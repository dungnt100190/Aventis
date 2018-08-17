-- Insert Script for ShFinanzplanverfuegung
-- MD5:0XBC8B0C41CAF2EAD0726AD2334373B429_0X542994E86FF96E2D18A96DA67ECFE2B7_0X305FCAD42A9CEEA92D43E8B414D0538F
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'ShFinanzplanverfuegung') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('ShFinanzplanverfuegung', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'ShFinanzplanverfuegung';
--SQLCHECK_IGNORE--
UPDATE QRY
SET QueryName =  N'ShFinanzplanverfuegung' , UserText =  N'SH - Finanzplanverfügung' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\KiSS\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\Kiss.Interfaces.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\FluentValidation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\log4net.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\Microsoft.Practices.Unity.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\Ionic.Zip.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\Kiss.BL.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\Kiss.Model.dll" />
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
///     <Reference Path="C:\KiSS\Build\Debug\KiSS.Common.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\Common.Logging.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\Autofac.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\Kiss.Database.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\HtmlAgilityPack.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\WPFLocalizeExtension.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\XAMLMarkupExtensions.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRRichText xrRichText2;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRRichText xrRichText1;
        private DevExpress.XtraReports.UI.XRRichText rtfHinweis;
        private DevExpress.XtraReports.UI.XRRichText xrRichTextBox1;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.Subreport ShFinanzplanverfuegung_EinAus;
        private DevExpress.XtraReports.UI.Subreport ShFinanzplanverfuegung_Personen;
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
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAAHAAAAAgAAAIwBRGV2RXhwcmVzc" +
                        "y5YdHJhUmVwb3J0cy5VSS5TZXJpYWxpemFibGVTdHJpbmcsIERldkV4cHJlc3MuWHRyYVJlcG9ydHMud" +
                        "jYuMiwgVmVyc2lvbj02LjIuNi4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPTc5ODY4Y" +
                        "jgxNDdiNWVhZTRoU3lzdGVtLkRyYXdpbmcuQml0bWFwLCBTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj00L" +
                        "jAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2ETtE6kg" +
                        "G2btpW/u7pR/n8CTgYgGt7P1jZDDrpRKQAAANIAAAAoAQAAAAAAAKcAAABgAAAA/QAAADUDAAAkcgB0A" +
                        "GYASABpAG4AdwBlAGkAcwAuAFIAdABmAFQAZQB4AHQAAAAAADJzAHEAbABRAHUAZQByAHkAMQAuAFMAZ" +
                        "QBsAGUAYwB0AFMAdABhAHQAZQBtAGUAbgB0AG4CAABCeAByAFAAYQBnAGUASQBuAGYAbwAyAC4AUwBjA" +
                        "HIAaQBwAHQAcwAuAE8AbgBQAHIAaQBuAHQATwBuAFAAYQBnAGUAxw4AACZ4AHIAUABpAGMAdAB1AHIAZ" +
                        "QBCAG8AeAAxAC4ASQBtAGEAZwBlALEPAAAmeAByAFIAaQBjAGgAVABlAHgAdAAxAC4AUgB0AGYAVABlA" +
                        "HgAdACaGwIAJngAcgBSAGkAYwBoAFQAZQB4AHQAMgAuAFIAdABmAFQAZQB4AHQAxxwCACx4AHIAUgBpA" +
                        "GMAaABUAGUAeAB0AEIAbwB4ADEALgBSAHQAZgBUAGUAeAB0ALkfAgBAAAEAAAD/////AQAAAAAAAAAMA" +
                        "gAAABtEZXZFeHByZXNzLlh0cmFSZXBvcnRzLnY2LjIFAQAAACxEZXZFeHByZXNzLlh0cmFSZXBvcnRzL" +
                        "lVJLlNlcmlhbGl6YWJsZVN0cmluZwEAAAAFVmFsdWUBAgAAAAYDAAAA8gN7XHJ0ZjFcYW5zaWNwZzEyN" +
                        "TINCnsNClxmb250dGJsDQp7XGYwIFRpbWVzIE5ldyBSb21hbjt9DQp7XGYxIEFyaWFsO30NCn0NCnsNC" +
                        "lxjb2xvcnRibA0KOw0KXHJlZDBcZ3JlZW4wXGJsdWUwOw0KfQ0Ke1xwYXJkXHBsYWlue1xmMVxmczE4X" +
                        "GNmMSBEYXMgQnVkZ2V0IGlzdCBuYWNoIFJpY2h0bGluaWVuIGRlciBTY2h3ZWl6LiBLb25mZXJlbnogZ" +
                        "lx1MjUy77+9ciBTb3ppYWxoaWxmZSBTS09TIGJlcmVjaG5ldC4gRXMgZ2lsdCBhbHMgUmFobWVuYnVkZ" +
                        "2V0LiBFaW5uYWhtZW4gdW5kIEF1c2dhYmVuIGtcdTI0Nu+/vW5uZW4gbW9uYXRsaWNoIFx1MjI477+9b" +
                        "mRlcm4uIERpZSBCZXpcdTI1Mu+/vWdlcmlubmVuIHVuZCBCZXpcdTI1Mu+/vWdlciBzaW5kIHZlcnBmb" +
                        "GljaHRldCwgXHUxOTbvv71uZGVydW5nZW4gZGVyIGZpbmFuemllbGxlbiBTaXR1YXRpb24gdW5hdWZnZ" +
                        "WZvcmRlcnQgdW5kIHVtZ2VoZW5kIGRlbiBTb3ppYWxkaWVuc3RlbiB6dSBtZWxkZW4ufVxwYXJ9DQp9D" +
                        "QoLAdYYREVDTEFSRSBAQmdCdWRnZXRJRCAgaW50LA0KICAgICAgICBAR2V0RGF0ZSAgICAgZGF0ZXRpb" +
                        "WUNClNFTEVDVCBAQmdCdWRnZXRJRCA9IEJnQnVkZ2V0SUQsIEBHZXREYXRlID0gR2V0RGF0ZSgpDQpGU" +
                        "k9NIEJnQnVkZ2V0DQpXSEVSRSBCZ0ZpbmFuelBsYW5JRCA9IG51bGwgQU5EIE1hc3RlckJ1ZGdldCA9I" +
                        "DENCg0KDQpERUNMQVJFIEBUb3RJbiBtb25leQ0KREVDTEFSRSBAVG90T3V0IG1vbmV5DQoNClNFTEVDV" +
                        "CBAVG90SW4gPSBTVU0oQmV0cmFnKQ0KRlJPTSBkYm8uZm5XaEdldEZpbmFuenBsYW4oQEJnQnVkZ2V0S" +
                        "UQsIEBHZXREYXRlKSAgVE1QDQogIElOTkVSIEpPSU4gWExPVkNvZGUgIFhQQyBPTiBYUEMuTE9WTmFtZ" +
                        "SA9ICdCZ0thdGVnb3JpZScgQU5EIFhQQy5Db2RlID0gVE1QLkJnS2F0ZWdvcmllQ29kZQ0KV0hFUkUgQ" +
                        "mdLYXRlZ29yaWVDb2RlID0gMQ0KDQpTRUxFQ1QgQFRvdE91dCA9IFNVTShDQVNFIFdIRU4gQmdLYXRlZ" +
                        "29yaWVDb2RlID0gMiBUSEVOIFRNUC5CZXRyYWcgRUxTRSAtVE1QLkJldHJhZyBFTkQpDQpGUk9NIGRib" +
                        "y5mbldoR2V0RmluYW56cGxhbihAQmdCdWRnZXRJRCwgQEdldERhdGUpICBUTVANCiAgSU5ORVIgSk9JT" +
                        "iBYTE9WQ29kZSAgWFBDIE9OIFhQQy5MT1ZOYW1lID0gJ0JnS2F0ZWdvcmllJyBBTkQgWFBDLkNvZGUgP" +
                        "SBUTVAuQmdLYXRlZ29yaWVDb2RlDQpXSEVSRSBCZ0thdGVnb3JpZUNvZGUgSU4gKDIsIDQpDQoNCg0KR" +
                        "EVDTEFSRSBAQmVtZXJrdW5nUlRGIHZhcmNoYXIoODAwMCksDQogICAgICAgIEBJdGVtVGV4dCAgICAgd" +
                        "mFyY2hhcig4MDAwKQ0KDQpERUNMQVJFIGNCZW1lcmt1bmdSVEYgQ1VSU09SIEZBU1RfRk9SV0FSRCBGT" +
                        "1INCiAgU0VMRUNUICctICcgKyBYTEMuVGV4dCArICcgKCcgKyBQUlMuTmFtZVZvcm5hbWUgKyAnKTogJ" +
                        "yArIENvbnZlcnQodmFyY2hhcigyMDAwKSwgQlBPLkJlbWVya3VuZykNCiAgRlJPTSBCZ1Bvc2l0aW9uI" +
                        "CAgICAgICAgICAgIEJQTw0KICAgIElOTkVSIEpPSU4gdndQZXJzb24gICAgICBQUlMgT04gUFJTLkJhU" +
                        "GVyc29uSUQgPSBCUE8uQmFQZXJzb25JRA0KICAgIElOTkVSIEpPSU4gQmdQb3NpdGlvbnNhcnQgIFNQV" +
                        "CBPTiBTUFQuQmdQb3NpdGlvbnNhcnRJRCA9IEJQTy5CZ1Bvc2l0aW9uc2FydElEDQogICAgSU5ORVIgS" +
                        "k9JTiBYTE9WQ29kZSAgICAgICBYTEMgT04gWExDLkxPVk5hbWUgPSAnQmdHcnVwcGUnIEFORCBYTEMuQ" +
                        "29kZSA9IFNQVC5CZ0dydXBwZUNvZGUNCiAgV0hFUkUgQlBPLkJnQnVkZ2V0SUQgPSBAQmdCdWRnZXRJR" +
                        "A0KICAgIEFORCBTUFQuQmdQb3NpdGlvbnNhcnRDb2RlIEJFVFdFRU4gMzkwMDAgQU5EIDM5OTk5DQogI" +
                        "CAgQU5EIE5PVCAoQlBPLkJlbWVya3VuZyBJUyBOVUxMIE9SIENvbnZlcnQodmFyY2hhciwgQlBPLkJlb" +
                        "WVya3VuZykgPSAnJykNCiAgICBBTkQgR2V0RGF0ZSgpIEJFVFdFRU4gSXNOdWxsKEJQTy5EYXR1bVZvb" +
                        "iwgJzE5MDAwMTAxJykgQU5EIElzTnVsbChCUE8uRGF0dW1CaXMsIEdldERhdGUoKSkNCiAgT1JERVIgQ" +
                        "lkgUFJTLk5hbWVWb3JuYW1lDQoNCk9QRU4gY0JlbWVya3VuZ1JURg0KV0hJTEUgKDEgPSAxKSBCRUdJT" +
                        "g0KICBGRVRDSCBORVhUIEZST00gY0JlbWVya3VuZ1JURiBJTlRPIEBJdGVtVGV4dA0KICBJRiBAQEZFV" +
                        "ENIX1NUQVRVUyAhPSAwIEJSRUFLDQoNCiAgU0VUIEBCZW1lcmt1bmdSVEYgPSBJc051bGwoQEJlbWVya" +
                        "3VuZ1JURiArIGNoYXIoMTApICsgY2hhcigxMyksICcnKSArIEBJdGVtVGV4dA0KRU5EDQpDTE9TRSBjQ" +
                        "mVtZXJrdW5nUlRGDQpERUFMTE9DQVRFIGNCZW1lcmt1bmdSVEYNCg0KDQoNClNFTEVDVCBCQkcuQmdCd" +
                        "WRnZXRJRCwNCiAgICAgICBUaXRsZSAgICAgICAgPSAnVmVyZsO8Z3VuZyB2b20gJyArIElzTnVsbChDT" +
                        "05WRVJUKHZhcmNoYXIsIChTRUxFQ1QgTUFYKERhdHVtKSBGUk9NIEJnQmV3aWxsaWd1bmcgQkJXDQogI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICBXSEVSRSBCQlcuQmdGaW5hbnpQbGFuSUQ9U0ZQLkJnRmluYW56UGxhbklEIEFORCBCQlcuQmdCZ" +
                        "XdpbGxpZ3VuZ0NvZGUgPSAyKSwgMTA0KSwgJz8/PycpICsNCiAgICAgICAgICAgICAgICAgICAgICAnO" +
                        "iBTb3ppYWxoaWxmZSB2b20gJyArIENPTlZFUlQodmFyY2hhciwgU0ZQLkRhdHVtVm9uLCAxMDQpICsgJ" +
                        "yBiaXMgJyArIENPTlZFUlQodmFyY2hhciwgU0ZQLkRhdHVtQmlzLCAxMDQpLA0KICAgICAgIEFkcmVzc" +
                        "2UgICAgICA9IElzTnVsbChDQVNFIFBSUy5HZXNjaGxlY2h0Q29kZSBXSEVOIDEgVEhFTiAnSGVycicgV" +
                        "0hFTiAyIFRIRU4gJ0ZyYXUnIEVORCArIGNoYXIoMTMpICsgY2hhcigxMCksJycpICsNCiAgICAgICAgI" +
                        "CAgICAgICAgICAgICBQUlMuVm9ybmFtZU5hbWUgKyBjaGFyKDEzKSArIGNoYXIoMTApICsNCiAgICAgI" +
                        "CAgICAgICAgICAgICAgICBQUlMuV29obnNpdHpTdHJhc3NlSGF1c05yICsgY2hhcigxMykgKyBjaGFyK" +
                        "DEwKSArDQogICAgICAgICAgICAgICAgICAgICAgUFJTLldvaG5zaXR6UExaT3J0LA0KICAgICAgIEJlb" +
                        "WVya3VuZ1JURiA9IElzTnVsbChDT05WRVJUKHZhcmNoYXIoODAwMCksIFNGUC5CZW1lcmt1bmcpICsgY" +
                        "2hhcigxMCkgKyBjaGFyKDEzKSwgJycpICsgSXNOdWxsKEBCZW1lcmt1bmdSVEYsICcnKSwNCiAgICAgI" +
                        "CBUb3RJbiAgICAgICAgPSBJc051bGwoQFRvdEluLCAkMC4wMCksDQogICAgICAgVG90T3V0ICAgICAgI" +
                        "D0gSXNOdWxsKEBUb3RPdXQsICQwLjAwKSwNCiAgICAgICBGZWhsYmV0cmFnICAgPSBJc051bGwoQFRvd" +
                        "E91dCwgJDAuMDApIC0gSXNOdWxsKEBUb3RJbiwgJDAuMDApDQpGUk9NICAgQmdCdWRnZXQgQkJHDQogI" +
                        "CAgICAgSU5ORVIgSk9JTiBCZ0ZpbmFuelBsYW4gIFNGUCBvbiBTRlAuQmdGaW5hbnpQbGFuSUQgPSBCQ" +
                        "kcuQmdGaW5hbnpQbGFuSUQNCiAgICAgICBJTk5FUiBKT0lOIEZhTGVpc3R1bmcgICAgRkFMIG9uIEZBT" +
                        "C5GYUxlaXN0dW5nSUQgPSBTRlAuRmFMZWlzdHVuZ0lEDQogICAgICAgSU5ORVIgSk9JTiB2d1BlcnNvb" +
                        "iAgICAgIFBSUyBvbiBQUlMuQmFQZXJzb25JRCA9IEZBTC5CYVBlcnNvbklEDQpXSEVSRSBGQUwuTW9kd" +
                        "WxJRCA9IDMgQU5EIEJCRy5CZ0J1ZGdldElEID0gQEJnQnVkZ2V0SUQNCiAgQU5EIFNGUC5CZ0Jld2lsb" +
                        "GlndW5nU3RhdHVzQ29kZSBpbiAoNSwgOSkgLS0gbnVyIGJld2lsbGlndGUB5wFwcml2YXRlIHZvaWQgT" +
                        "25QcmludE9uUGFnZShvYmplY3Qgc2VuZGVyLCBEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlByaW50T" +
                        "25QYWdlRXZlbnRBcmdzIGUpIA0Kew0KICAgWFJQYWdlSW5mbyB4clBhZ2VJbmZvID0gc2VuZGVyIGFzI" +
                        "FhSUGFnZUluZm87DQogICBpZih4clBhZ2VJbmZvICE9IG51bGwpDQogICB7DQogICAgIHhyUGFnZUluZ" +
                        "m8uVmlzaWJsZSA9IGUuUGFnZUNvdW50ID4gMTsNCiAgIH0NCn1BAAEAAAD/////AQAAAAAAAAAMAgAAA" +
                        "FFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tle" +
                        "VRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHA" +
                        "gIAAAAJAwAAAA8DAAAARgsCAAJCTUYLAgAAAAAANgQAACgAAAC3AQAALgEAAAEACAAAAAAAAAAAAFo3A" +
                        "ABaNwAAAAEAAAABAAAAAAD/AQEB/wICAv8DAwP/BAQE/wUFBf8GBgb/BwcH/wgICP8JCQn/CgoK/wsLC" +
                        "/8MDAz/DQ0N/w4ODv8PDw//EBAQ/xEREf8SEhL/ExMT/xQUFP8VFRX/FhYW/xcXF/8YGBj/GRkZ/xoaG" +
                        "v8bGxv/HBwc/x0dHf8eHh7/Hx8f/yAgIP8hISH/IiIi/yMjI/8kJCT/JSUl/yYmJv8nJyf/KCgo/ykpK" +
                        "f8qKir/Kysr/ywsLP8tLS3/Li4u/y8vL/8wMDD/MTEx/zIyMv8zMzP/NDQ0/zU1Nf82Njb/Nzc3/zg4O" +
                        "P85OTn/Ojo6/zs7O/88PDz/PT09/z4+Pv8/Pz//QEBA/0FBQf9CQkL/Q0ND/0RERP9FRUX/RkZG/0dHR" +
                        "/9ISEj/SUlJ/0pKSv9LS0v/TExM/01NTf9OTk7/T09P/1BQUP9RUVH/UlJS/1NTU/9UVFT/VVVV/1ZWV" +
                        "v9XV1f/WFhY/1lZWf9aWlr/W1tb/1xcXP9dXV3/Xl5e/19fX/9gYGD/YWFh/2JiYv9jY2P/ZGRk/2VlZ" +
                        "f9mZmb/Z2dn/2hoaP9paWn/ampq/2tra/9sbGz/bW1t/25ubv9vb2//cHBw/3Fxcf9ycnL/c3Nz/3R0d" +
                        "P91dXX/dnZ2/3d3d/94eHj/eXl5/3p6ev97e3v/fHx8/319ff9+fn7/f39//4CAgP+BgYH/goKC/4ODg" +
                        "/+EhIT/hYWF/4aGhv+Hh4f/iIiI/4mJif+Kior/i4uL/4yMjP+NjY3/jo6O/4+Pj/+QkJD/kZGR/5KSk" +
                        "v+Tk5P/lJSU/5WVlf+Wlpb/l5eX/5iYmP+ZmZn/mpqa/5ubm/+cnJz/nZ2d/56env+fn5//oKCg/6Gho" +
                        "f+ioqL/o6Oj/6SkpP+lpaX/pqam/6enp/+oqKj/qamp/6qqqv+rq6v/rKys/62trf+urq7/r6+v/7Cws" +
                        "P+xsbH/srKy/7Ozs/+0tLT/tbW1/7a2tv+3t7f/uLi4/7m5uf+6urr/u7u7/7y8vP+9vb3/vr6+/7+/v" +
                        "//AwMD/wcHB/8LCwv/Dw8P/xMTE/8XFxf/Gxsb/x8fH/8jIyP/Jycn/ysrK/8vLy//MzMz/zc3N/87Oz" +
                        "v/Pz8//0NDQ/9HR0f/S0tL/09PT/9TU1P/V1dX/1tbW/9fX1//Y2Nj/2dnZ/9ra2v/b29v/3Nzc/93d3" +
                        "f/e3t7/39/f/+Dg4P/h4eH/4uLi/+Pj4//k5OT/5eXl/+bm5v/n5+f/6Ojo/+np6f/q6ur/6+vr/+zs7" +
                        "P/t7e3/7u7u/+/v7//w8PD/8fHx//Ly8v/z8/P/9PT0//X19f/29vb/9/f3//j4+P/5+fn/+vr6//v7+" +
                        "//8/Pz//f39//7+/v///////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////77cukfmxeUUc4LCQdGA8PDw+H/////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////9dWkZzcRBAAAAAAAAAAAA" +
                        "AAAAAAAAH3//////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/7bjVgjCAAAAAAAAAAAAAAAAAAAAAAAAAAAf////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////9sB/QAwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB//////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////31YQlAQAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAH///////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////9Z4TikHAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAf////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////+7tiDgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB//////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////8Zg3AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAH///////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////KssAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAf////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///9qA6AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB//////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////5ZQwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAH///////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////5XgTAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAf////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////+JIcA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB9/////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////9c3AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAFCA4PD4f//////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////+nIQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAMI0Bce5mtus7V6/Dw9////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////////////WUQAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAUOLVuJu+T1/v///////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////eUw8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEgX42qzOn4/////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////xisAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "Bhlv/X//////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////4oJAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAElup7f///////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////+NQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAG3nl/////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////jKQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABQZ3t/////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////uToAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAfW77+/////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///8V4AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA7p/L//////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////+A+AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAApn/3//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////VKgAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAU+P//////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////////+" +
                        "TcAAAAAAAAAAAAAAAAAAAAAAAAAAAAAM7T//////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////9BTAAAAAAAAAAAAAAAAAAAAAAAAAAAANpD2/////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////+kDQAAAAAAAAAAAAAAAAAAAAAAAAAAB" +
                        "Hb2/////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////pAYAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAADG//////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////68GAAAAAAAAAAAAAAAAAAAAAAAAAABt7f///////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////4KQAAAAAAAAAAAAAAAAAAAAAAAAAJpv///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////91oAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAADZ3//////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////9c+AAAAAAAAAAAAAAAAAAAAAAAAAHPW/////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////nLQAAAAAAAAAAAAAAAAAAAAAAAA6h/////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////9EMAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAOvv///////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////97AAAAAAAAAAAAAAAAAAAAAAAAAJX//////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////5RcAAAAAAAAAAAAAAAAAAAAAAAST/////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////+NFAAAAAAAAAAAAA" +
                        "AAAAAAAAAAnrP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////uLwAAAAAAAAAAAAAAAAAAAAAAROn//////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////1wAAAAAAAAAAAAAAAAAAAAAACLu/////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////+ZAAAAAAAAAAAAAAAAA" +
                        "AAAAAADr////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////1REAAAAAAAAAAAAAAAAAAAAAAI3//////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////o+AAAAAAAAAAAAAAAAAAAAAAB8/////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////ngAAAAAAAAAAAAAAAAAAA" +
                        "AAJof///////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////+oiAAAAAAAAAAAAAAAAAAAAAJr//////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////YwAAAAAAAAAAAAAAAAAAAABn/////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////70CAAAAAAAAAAAAAAAAAAAAB" +
                        "tb//////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//5MAAAAAAAAAAAAAAAAAAAAACA/////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////3kAAAAAAAAAAAAAAAAAAAAAYvr//////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////+pAAAAAAAAAAAAAAAAAAAAAFj//" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////////9" +
                        "ywAAAAAAAAAAAAAAAAAAAAi6v///////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////BAAAAAAAAAAAAAAAAAAAAAq///////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////34AAAAAAAAAAAAAAAAAAABb/////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////////////////////XG" +
                        "AAAAAAAAAAAAAAAAAAABMf//////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////kYAAAAAAAAAAAAAAAAAAABv/////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////++AAAAAAAAAAAAAAAAAAAAH+r//////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////1IAA" +
                        "AAAAAAAAAAAAAAAAACd/////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////MBAAAAAAAAAAAAAAAAAAAN/v//////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////2MAAAAAAAAAAAAAAAAAAAC6/////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////////////////BCAAAA" +
                        "AAAAAAAAAAAAAAAdv///////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////1UAAAAAAAAAAAAAAAAAACLz/////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////ZCgAAAAAAAAAAAAAAAAAAgP///////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////4cAAAAAA" +
                        "AAAAAAAAAAAAAC5/////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////VQAAAAAAAAAAAAAAAAAAEez//////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////YmAAAAAAAAAAAAAAAAAAB9/////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////twAAAAAAA" +
                        "AAAAAAAAAAAIfX//////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////9iAAAAAAAAAAAAAAAAAAB5/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////8RcAAAAAAAAAAAAAAAAABtX//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////////////+2AAAAAAAAA" +
                        "AAAAAAAAABM/////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////2YAAAAAAAAAAAAAAAAAAKP//////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////qFwAAAAAAAAAAAAAAAAAw9f///////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////6cAAAAAAAAAA" +
                        "AAAAAAAAIX//////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////aQAAAAAAAAAAAAAAAAAF0f///////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////orAAAAAAAAAAAAAAAAADL8/////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////1AUAAAAAAAAAA" +
                        "AAAAAAAeP///////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////+KAAAAAAAAAAAAAAAAAAbQ/////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////1AAAAAAAAAAAAAAAAAAIfn//////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////////1HQAAAAAAAAAAA" +
                        "AAAAABA/v///////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////9EEAAAAAAAAAAAAAAAAAFz//////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////pQAAAAAAAAAAAAAAAAAAdP///////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////////94AAAAAAAAAAAAA" +
                        "AAAAACk/////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////14AAAAAAAAAAAAAAAAACuL//////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////TAAAAAAAAAAAAAAAAAAt+////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////////06AAAAAAAAAAAAA" +
                        "AAAAFb//////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////+CoAAAAAAAAAAAAAAAAAev///////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////1HAAAAAAAAAAAAAAAAACY/////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////90AAAAAAAAAAAAAA" +
                        "AAAAML//////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////4mdjY2NjY2NjY2NjY2No5////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A////////9PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8" +
                        "PDw8PDw8PDw8PDw8PDw8v/////////////////////////////////59PLw8PDx9Pb7/////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////9fDw8PDw8PDw8PDw8PD3/////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////9+PTy8PDw8fP2/f///////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////349PLw8PDw8/b6/////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD///////9SDw8PDw8PDw8PDw8PDw8PD" +
                        "w8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw84+P/////////////////////////nlW9WQ" +
                        "zAeFg8PDxMeJzVHZYfH+f////////////////////////////+4f39/f39/f39/f39/f7H//////////" +
                        "//7lX9/f39/f39/f39/f5X7//////////////tCDw8PDw8PDw8PDw8PD4f///////////////eHf39/f" +
                        "39/f39/f39/o///////////////////////mn9/f39/f39/f39/f39/gu7/////////////////////2" +
                        "JdvVDsrHxYPDw8THSU7TmiHx///////////////////////////////////uH9/f39/f39/f39/f3+x/" +
                        "/////////////////////////////////////zRk29POysfGA8PDxAcJTRDUWmHzfb//////////////" +
                        "////9t/f39/f39/f39/f39/o///////////////////////o39/f39/f39/f39/f47/////////AP///" +
                        "////0QAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACf4/////" +
                        "//////////////////FaR0AAAAAAAAAAAAAAAAAAAAAAAMvf9///////////////////////////2cAA" +
                        "AAAAAAAAAAAAAAAWP////////////gdAAAAAAAAAAAAAAAAHfj/////////////+CcAAAAAAAAAAAAAA" +
                        "AAAff//////////////7wAAAAAAAAAAAAAAAAA6/////////////////////9AAAAAAAAAAAAAAAAAAA" +
                        "AAp9///////////////////vkQJAAAAAAAAAAAAAAAAAAAAAAADS634/////////////////////////" +
                        "/////9nAAAAAAAAAAAAAAAAAFj///////////////////////////////////OOOQYAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAFJGep8v//////////////sgAAAAAAAAAAAAAAAAA6//////////////////////86AAAAA" +
                        "AAAAAAAAAAADv////////8A////////RwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAK/j///////////////////+/SwMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHqD+/" +
                        "///////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAAEf//////////////" +
                        "//////9RQAAAAAAAAAAAAAAAAAAAKn/////////////////xFQBAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "DCf/f///////////////////////////3EAAAAAAAAAAAAAAAAAY////////////////////////////" +
                        "/////+rNQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAokeT///////////+3AAAAAAAAAAAAAAAAAEf//" +
                        "////////////////////0cAAAAAAAAAAAAAAAAe/////////wD///////9HAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAr+P//////////////////kwMAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAEHK//////////////////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH////////////////APAAAAA" +
                        "AAAAAAAAAAAR////////////////////6AAAAAAAAAAAAAAAAAAAABc////////////////52YCAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA+zf//////////////////////////cQAAAAAAAAAAAAAAAABj/" +
                        "//////////////////////////////GRAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEnn8/////" +
                        "////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAAB7/////////AP///" +
                        "////0cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACv4/////" +
                        "///////////6WQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA2O/v///////////////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+CwAAAAAAAAAAAAAA" +
                        "AAAf///////////////8A8AAAAAAAAAAAAAAABH///////////////////nHAAAAAAAAAAAAAAAAAAAJ" +
                        "uv//////////////78mAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAez////////////////////" +
                        "/////9xAAAAAAAAAAAAAAAAAGP/////////////////////////////gwgAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAOP7/////////twAAAAAAAAAAAAAAAABH//////////////////////9HAAAAA" +
                        "AAAAAAAAAAAHv////////8A////////RwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAK/j//////////////5IiAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "ABQ+P//////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAAEf//////////////" +
                        "///7zsAAAAAAAAAAAAAAAAAACjY//////////////+YDwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAOcfD//////////////////////3EAAAAAAAAAAAAAAAAAY///////////////////////////4" +
                        "VEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABV//////////+3AAAAAAAAAAAAAAAAAEf//" +
                        "////////////////////0cAAAAAAAAAAAAAAAAe/////////wD///////9HAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAr+P////////////+AAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAABa+f////////////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH////////////////APAAAAA" +
                        "AAAAAAAAAAAR/////////////////90AAAAAAAAAAAAAAAAAAAHwv//////////////jAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAT/j/////////////////////cQAAAAAAAAAAAAAAAABj/" +
                        "////////////////////////+EvAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAGP//////" +
                        "////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAAB7/////////AP///" +
                        "////0cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACv4/////" +
                        "///////oQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABp/////////////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+CwAAAAAAAAAAAAAA" +
                        "AAAf///////////////8A8AAAAAAAAAAAAAAABH////////////////ywcAAAAAAAAAAAAAAAAAAIL//" +
                        "////////////54AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAZf///////////////" +
                        "/////9xAAAAAAAAAAAAAAAAAGP////////////////////////qMAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAcf//////////twAAAAAAAAAAAAAAAABH//////////////////////9HAAAAA" +
                        "AAAAAAAAAAAHv////////8A////////RwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAK/j///////////0tAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAACc////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAAEf//////////////" +
                        "/9eAAAAAAAAAAAAAAAAAAAj9//////////////ICwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAnv///////////////////3EAAAAAAAAAAAAAAAAAY///////////////////////+UcAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB///////////+3AAAAAAAAAAAAAAAAAEf//" +
                        "////////////////////0cAAAAAAAAAAAAAAAAe/////////wD///////9HAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAr+P//////////mQAAAAAAAAAAAAAAAAAAA" +
                        "AAACR4uKxIAAAAAAAAAAAAAAAAAAAAAABDZ//////////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH////////////////APAAAAA" +
                        "AAAAAAAAAAAR///////////////8RkAAAAAAAAAAAAAAAAAAH7/////////////8i8AAAAAAAAAAAAAA" +
                        "AAAAAAAAAgeLicOAAAAAAAAAAAAAAAAAAAAAAA0////////////////////cQAAAAAAAAAAAAAAAABj/" +
                        "/////////////////////95AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIr//////" +
                        "////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAAB7/////////AP///" +
                        "////0cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACf4/////" +
                        "////8wUAAAAAAAAAAAAAAAAAAACRpfY9Pn46KhqLwAAAAAAAAAAAAAAAAAAAEDu/////////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+CwAAAAAAAAAAAAAA" +
                        "AAAf///////////////8A8AAAAAAAAAAAAAAABH//////////////xnAAAAAAAAAAAAAAAAAABH7v///" +
                        "/////////9/AAAAAAAAAAAAAAAAAAAAHF2W1fT59ueraxoAAAAAAAAAAAAAAAAAAAKi/////////////" +
                        "/////9xAAAAAAAAAAAAAAAAAGP/////////////////////sAQAAAAAAAAAAAAAAAAAAAAoS2d8oLi4t" +
                        "7mqlX9tWTwTAAAAAAAAnv//////////twAAAAAAAAAAAAAAAABH//////////////////////9HAAAAA" +
                        "AAAAAAAAAAAHv////////8A////////RwAAAAAAAAAAAAAAAAAAAAAAEBAPDw8PDw8PDw8PDw8PDw8PD" +
                        "w8PDw8PDw8PDw8PDw8POPj////////3LAAAAAAAAAAAAAAAAAAAHbf////////////5jwQAAAAAAAAAA" +
                        "AAAAAAAAID/////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAAEf/////////////j" +
                        "AAAAAAAAAAAAAAAAAAANvX/////////////9BwAAAAAAAAAAAAAAAAAAC3m////////////2z4AAAAAA" +
                        "AAAAAAAAAAAAAzV/////////////////3EAAAAAAAAAAAAAAAAAY/////////////////////4yAAAAA" +
                        "AAAAAAAAAAAAAAjtvf//////////////////eupUQUAAACy//////////+3AAAAAAAAAAAAAAAAAEf//" +
                        "////////////////////0cAAAAAAAAAAAAAAAAe/////////wD///////9DAAAAAAAAAAAAAAAAAAAAA" +
                        "ACF8/Dw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDy/////////54AAAAAAAAAAAAAAAAAABHO/" +
                        "///////////////VAAAAAAAAAAAAAAAAAAAPv////////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH////////////////APAAAAA" +
                        "AAAAAAAAAAAR////////////9kQAAAAAAAAAAAAAAAAAAzN//////////////+oAAAAAAAAAAAAAAAAA" +
                        "AAPwf//////////////7zoAAAAAAAAAAAAAAAAAAGv/////////////////cQAAAAAAAAAAAAAAAABj/" +
                        "///////////////////xwQAAAAAAAAAAAAAAAAAXeb/////////////////////////zk8AALn//////" +
                        "////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAAB7/////////AP///" +
                        "////1wAAAAAAAAAAAAAAAAAAAAAABzs/////////////////////////////////////////////////" +
                        "//7NgAAAAAAAAAAAAAAAAABqP/////////////////XEQAAAAAAAAAAAAAAAAAQ5////////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+CwAAAAAAAAAAAAAA" +
                        "AAAf///////////////8A8AAAAAAAAAAAAAAABH////////////TwAAAAAAAAAAAAAAAAAAkf///////" +
                        "////////DsAAAAAAAAAAAAAAAAAAKL/////////////////3BYAAAAAAAAAAAAAAAAAEeb//////////" +
                        "/////9xAAAAAAAAAAAAAAAAAGP///////////////////9TAAAAAAAAAAAAAAAAAHP//////////////" +
                        "///////////////+nMGyf//////////twAAAAAAAAAAAAAAAABH//////////////////////9HAAAAA" +
                        "AAAAAAAAAAAHv////////8A////////0QcAAAAAAAAAAAAAAAAAAAAAAG3//////////////////////" +
                        "////////////////////////////8EAAAAAAAAAAAAAAAAAAFn///////////////////+OAAAAAAAAA" +
                        "AAAAAAAAACW////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAAEf//////////6gAA" +
                        "AAAAAAAAAAAAAAAAEz9///////////////IAgAAAAAAAAAAAAAAAABQ////////////////////mAAAA" +
                        "AAAAAAAAAAAAAAAk////////////////3EAAAAAAAAAAAAAAAAAY///////////////////0AMAAAAAA" +
                        "AAAAAAAAABn/////////////////////////////////7zi//////////+3AAAAAAAAAAAAAAAAAEf//" +
                        "////////////////////0cAAAAAAAAAAAAAAAAe/////////wD/////////bwAAAAAAAAAAAAAAAAAAA" +
                        "AAACM//////////////////////////////////////////////////aAAAAAAAAAAAAAAAAAAI0////" +
                        "/////////////////grAAAAAAAAAAAAAAAAAEH+//////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH////////////////APAAAAA" +
                        "AAAAAAAAAAAR//////////tIgAAAAAAAAAAAAAAAAAN3P///////////////3AAAAAAAAAAAAAAAAAAB" +
                        "dL////////////////////4LAAAAAAAAAAAAAAAAAA6/f//////////////cQAAAAAAAAAAAAAAAABj/" +
                        "/////////////////9zAAAAAAAAAAAAAAAAMfT//////////////////////////////////////////" +
                        "////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAAB7/////////AP///" +
                        "//////yQwAAAAAAAAAAAAAAAAAAAAAAUP///////////////////////////////////////////////" +
                        "+ITAAAAAAAAAAAAAAAAAEX//////////////////////6wAAAAAAAAAAAAAAAAABMT//////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+CwAAAAAAAAAAAAAA" +
                        "AAAf///////////////8A8AAAAAAAAAAAAAAABH////////9kYAAAAAAAAAAAAAAAAAAIf//////////" +
                        "//////pFwAAAAAAAAAAAAAAAABw//////////////////////+zAwAAAAAAAAAAAAAAAAK//////////" +
                        "/////9xAAAAAAAAAAAAAAAAAGP/////////////////3BEAAAAAAAAAAAAAAA7S/////////////////" +
                        "///////////////////////////////twAAAAAAAAAAAAAAAABH//////////////////////9HAAAAA" +
                        "AAAAAAAAAAAHv////////8A///////////SCAAAAAAAAAAAAAAAAAAAAAAM3f///////////////////" +
                        "///////////////////////////oQAAAAAAAAAAAAAAAAAAdf//////////////////////+ycAAAAAA" +
                        "AAAAAAAAAAAfv//////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAAEf///////+7AAAAA" +
                        "AAAAAAAAAAAAABB+f///////////////6oAAAAAAAAAAAAAAAAABdT///////////////////////keA" +
                        "AAAAAAAAAAAAAAAAHf//////////////3EAAAAAAAAAAAAAAAAAY/////////////////+UAAAAAAAAA" +
                        "AAAAAAAPP////////////////////////////////////////////////+3AAAAAAAAAAAAAAAAAEf//" +
                        "////////////////////0cAAAAAAAAAAAAAAAAe/////////wD///////////9tAAAAAAAAAAAAAAAAA" +
                        "AAAAABh//////////////////////////////////////////////91AAAAAAAAAAAAAAAAAACw/////" +
                        "///////////////////agAAAAAAAAAAAAAAAABG/v////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH////////////////APAAAAA" +
                        "AAAAAAAAAAAR////////10AAAAAAAAAAAAAAAAAFNn/////////////////cQAAAAAAAAAAAAAAAAA0/" +
                        "P///////////////////////kAAAAAAAAAAAAAAAAAAP/7/////////////cQAAAAAAAAAAAAAAAABj/" +
                        "////////////////1IAAAAAAAAAAAAAAABk/////////////////////////////////////////////" +
                        "////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAAB7/////////AP///" +
                        "////////+cXAAAAAAAAAAAAAAAAAAAAAATF/////////////////////////////////////////////" +
                        "1wAAAAAAAAAAAAAAAAAD+f///////////////////////+kAAAAAAAAAAAAAAAAABXv/////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+CwAAAAAAAAAAAAAA" +
                        "AAAf///////////////8A8AAAAAAAAAAAAAAABH//////+9AwAAAAAAAAAAAAAAAACg/////////////" +
                        "/////0/AAAAAAAAAAAAAAAAAHL/////////////////////////XAAAAAAAAAAAAAAAAAAQ6v///////" +
                        "/////9xAAAAAAAAAAAAAAAAAGP////////////////0GQAAAAAAAAAAAAAAAI3//////////////////" +
                        "///////////////////////////////twAAAAAAAAAAAAAAAABH//////////////////////9HAAAAA" +
                        "AAAAAAAAAAAHv////////8A/////////////4wAAAAAAAAAAAAAAAAAAAAAAET//////////////////" +
                        "///////////////////////////RgAAAAAAAAAAAAAAAAA8/v///////////////////////9gGAAAAA" +
                        "AAAAAAAAAAAA8r/////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAAEf/////+TAAAAAAA" +
                        "AAAAAAAAAAAWP//////////////////8hUAAAAAAAAAAAAAAAAApv////////////////////////92A" +
                        "AAAAAAAAAAAAAAAAALC/////////////3EAAAAAAAAAAAAAAAAAY////////////////8cCAAAAAAAAA" +
                        "AAAAAABwf////////////////////////////////////////////////+3AAAAAAAAAAAAAAAAAEf//" +
                        "////////////////////0cAAAAAAAAAAAAAAAAe/////////wD/////////////9CQAAAAAAAAAAAAAA" +
                        "AAAAAAAAJX///////////////////////////////////////////kwAAAAAAAAAAAAAAAAAG///////" +
                        "///////////////////+CUAAAAAAAAAAAAAAAAAnv////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH////////////////APAAAAA" +
                        "AAAAAAAAAAAR/////1wAAAAAAAAAAAAAAAAADvq///////////////////JAwAAAAAAAAAAAAAAAAfW/" +
                        "////////////////////////5wAAAAAAAAAAAAAAAAAAJX/////////////cQAAAAAAAAAAAAAAAABj/" +
                        "///////////////lAAAAAAAAAAAAAAAABLo/////////////////////////////////////////////" +
                        "////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAAB7/////////AP///" +
                        "///////////hwAAAAAAAAAAAAAAAAAAAAAAB8n/////////////////////////////////////////9" +
                        "BsAAAAAAAAAAAAAAAAAoP//////////////////////////VAAAAAAAAAAAAAAAAABy/////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+CwAAAAAAAAAAAAAA" +
                        "AAAf///////////////8A8AAAAAAAAAAAAAAABH////kwAAAAAAAAAAAAAAAAAo7P///////////////" +
                        "////58AAAAAAAAAAAAAAAAAGvX/////////////////////////zAUAAAAAAAAAAAAAAAAAdP///////" +
                        "/////9xAAAAAAAAAAAAAAAAAGP///////////////9lAAAAAAAAAAAAAAAAMfv//////////////////" +
                        "///////////////////////////////twAAAAAAAAAAAAAAAABH//////////////////////9HAAAAA" +
                        "AAAAAAAAAAAHv////////8A///////////////sIAAAAAAAAAAAAAAAAAAAAAAARf7//////////////" +
                        "//////////////////////////uDwAAAAAAAAAAAAAAAAG7//////////////////////////9yAAAAA" +
                        "AAAAAAAAAAAAFb/////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAAEf//+AVAAAAAAAAA" +
                        "AAAAAAAAKL/////////////////////hAAAAAAAAAAAAAAAAAAq+P/////////////////////////pD" +
                        "AAAAAAAAAAAAAAAAABp/////////////3EAAAAAAAAAAAAAAAAAY////////////////0YAAAAAAAAAA" +
                        "AAAAABG//////////////////////////////////////////////////+3AAAAAAAAAAAAAAAAAEf//" +
                        "////////////////////0cAAAAAAAAAAAAAAAAe/////////wD///////////////+cAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAr////////////////////////////////////////9cIAAAAAAAAAAAAAAAAB9L//////" +
                        "////////////////////4kAAAAAAAAAAAAAAAAARP////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH////////////////APAAAAA" +
                        "AAAAAAAAAAAR///WwAAAAAAAAAAAAAAAAAd7v////////////////////9tAAAAAAAAAAAAAAAAADX7/" +
                        "/////////////////////////YhAAAAAAAAAAAAAAAAAF3/////////////cQAAAAAAAAAAAAAAAABj/" +
                        "//////////////5LgAAAAAAAAAAAAAAAEz//////////////////////////////////////////////" +
                        "////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAAB7/////////AP///" +
                        "/////////////g1AAAAAAAAAAAAAAAAAAAAAABT////////////////////////////////////////x" +
                        "AMAAAAAAAAAAAAAAAAM6P//////////////////////////mgAAAAAAAAAAAAAAAAAv+f///////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+CwAAAAAAAAAAAAAA" +
                        "AAAf///////////////8A8AAAAAAAAAAAAAAABH/9kDAAAAAAAAAAAAAAAAAK7//////////////////" +
                        "////2AAAAAAAAAAAAAAAAAAPv3/////////////////////////+S8AAAAAAAAAAAAAAAAAVv///////" +
                        "/////9xAAAAAAAAAAAAAAAAAGP///////////////MaAAAAAAAAAAAAAAAAQLq4t7e3t7e3t7e3t7e3t" +
                        "7e3t7e3t7e3t7e3t7e3t7ez2///////twAAAAAAAAAAAAAAAABH//////////////////////9HAAAAA" +
                        "AAAAAAAAAAAHv////////8A/////////////////8MQAAAAAAAAAAAAAAAAAAAAABTY/////////////" +
                        "/////////////////////////+3AAAAAAAAAAAAAAAAABHy//////////////////////////+oAAAAA" +
                        "AAAAAAAAAAAACX2////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAAEj/cgAAAAAAAAAAA" +
                        "AAAAAB9////////////////////////SQAAAAAAAAAAAAAAAABH///////////////////////////+Q" +
                        "wAAAAAAAAAAAAAAAABO/////////////3EAAAAAAAAAAAAAAAAAY///////////////8Q4AAAAAAAAAA" +
                        "AAAAAABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB+//////+3AAAAAAAAAAAAAAAAAEf//" +
                        "////////////////////0cAAAAAAAAAAAAAAAAe/////////wD//////////////////5YAAAAAAAAAA" +
                        "AAAAAAAAAAAAD38/////////////////////////////////////60AAAAAAAAAAAAAAAAAKvj//////" +
                        "////////////////////7kAAAAAAAAAAAAAAAAAD/D///////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH////////////////APAAAAA" +
                        "AAAAAAAAAAAV6gBAAAAAAAAAAAAAAAAc/////////////////////////9HAAAAAAAAAAAAAAAAAEj//" +
                        "/////////////////////////9IAAAAAAAAAAAAAAAAAEb/////////////cQAAAAAAAAAAAAAAAABj/" +
                        "//////////////oDQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAH7//" +
                        "////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAAB7/////////AP///" +
                        "///////////////+TUAAAAAAAAAAAAAAAAAAAAAAKH/////////////////////////////////////m" +
                        "wAAAAAAAAAAAAAAAAAt+P//////////////////////////twAAAAAAAAAAAAAAAAAP8P///////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+CwAAAAAAAAAAAAAA" +
                        "AAAf///////////////8A8AAAAAAAAAAAAAAAAkHwAAAAAAAAAAAAAAADb0/////////////////////" +
                        "////0cAAAAAAAAAAAAAAAAAVP///////////////////////////0cAAAAAAAAAAAAAAAAAR////////" +
                        "/////9xAAAAAAAAAAAAAAAAAGP//////////////9IHAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAf///////twAAAAAAAAAAAAAAAABH//////////////////////9HAAAAA" +
                        "AAAAAAAAAAAHv////////8A////////////////////tgIAAAAAAAAAAAAAAAAAAAAAJPH//////////" +
                        "/////////////////////////+cAAAAAAAAAAAAAAAAACz4//////////////////////////+3AAAAA" +
                        "AAAAAAAAAAAAA/w////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AANzf//////////////////////////RwAAAAAAAAAAAAAAAABV////////////////////////////R" +
                        "wAAAAAAAAAAAAAAAABH/////////////3EAAAAAAAAAAAAAAAAAY///////////////5AwAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB///////+3AAAAAAAAAAAAAAAAAEf//" +
                        "////////////////////0cAAAAAAAAAAAAAAAAe/////////wD////////////////////9LgAAAAAAA" +
                        "AAAAAAAAAAAAAAAf////////////////////////////////////5sAAAAAAAAAAAAAAAAALfj//////" +
                        "////////////////////7cAAAAAAAAAAAAAAAAAD/D///////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH////////////////APAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAHz///////////////////////////9HAAAAAAAAAAAAAAAAAFT//" +
                        "/////////////////////////9HAAAAAAAAAAAAAAAAAEf/////////////cQAAAAAAAAAAAAAAAABj/" +
                        "//////////////yDwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAH7//" +
                        "////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAAB7/////////AP///" +
                        "/////////////////93AAAAAAAAAAAAAAAAAAAAAAAO2///////////////////////////////////r" +
                        "AAAAAAAAAAAAAAAAAAq+P//////////////////////////uQAAAAAAAAAAAAAAAAAQ8P///////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+CwAAAAAAAAAAAAAA" +
                        "AAAf///////////////8A8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR3P///////////////////////" +
                        "////0YAAAAAAAAAAAAAAAAASP///////////////////////////0gAAAAAAAAAAAAAAAAARv///////" +
                        "/////9xAAAAAAAAAAAAAAAAAGP///////////////AQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAhv//////twAAAAAAAAAAAAAAAABH//////////////////////9HAAAAA" +
                        "AAAAAAAAAAAHv////////8A/////////////////////+s5AAAAAAAAAAAAAAAAAAAAAAA48v///////" +
                        "/////////////////////////+3AAAAAAAAAAAAAAAAABHy//////////////////////////+pAAAAA" +
                        "AAAAAAAAAAAACb2////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "CDq////////////////////////////TAAAAAAAAAAAAAAAAABH///////////////////////////+Q" +
                        "wAAAAAAAAAAAAAAAABP/////////////3EAAAAAAAAAAAAAAAAAY///////////////9ycAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACP//////+3AAAAAAAAAAAAAAAAAEf//" +
                        "////////////////////0cAAAAAAAAAAAAAAAAe/////////wD//////////////////////8YDAAAAA" +
                        "AAAAAAAAAAAAAAAAACD/////////////////////////////////8cEAAAAAAAAAAAAAAAAC+X//////" +
                        "////////////////////5oAAAAAAAAAAAAAAAAANPr///////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH////////////////APAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAIj///////////////////////////9gAAAAAAAAAAAAAAAAAD79/" +
                        "/////////////////////////kvAAAAAAAAAAAAAAAAAFb/////////////cQAAAAAAAAAAAAAAAABj/" +
                        "//////////////+QAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAJf//" +
                        "////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAAB7/////////AP///" +
                        "////////////////////10AAAAAAAAAAAAAAAAAAAAAABXp////////////////////////////////3" +
                        "AkAAAAAAAAAAAAAAAAG0f//////////////////////////hgAAAAAAAAAAAAAAAABI/////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+CwAAAAAAAAAAAAAA" +
                        "AAAf///////////////8A8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEc3//////////////////////" +
                        "////3AAAAAAAAAAAAAAAAAANfv/////////////////////////9R0AAAAAAAAAAAAAAAAAYP///////" +
                        "/////9xAAAAAAAAAAAAAAAAAGP///////////////9cAAAAAAAAAAAAAAAAOJ2cnJycnJycnJycnJycn" +
                        "JycnJwrAAAAAAAAAAAAAAAAn///////twAAAAAAAAAAAAAAAABH//////////////////////9IAAAAA" +
                        "AAAAAAAAAAAHv////////8A////////////////////////2w4AAAAAAAAAAAAAAAAAAAAAAKz//////" +
                        "//////////////////////////xEQAAAAAAAAAAAAAAAAC3//////////////////////////9yAAAAA" +
                        "AAAAAAAAAAAAF7/////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAADY6AAAAAAAAAAAAA" +
                        "AAAK+7/////////////////////////iwAAAAAAAAAAAAAAAAAo9//////////////////////////pC" +
                        "wAAAAAAAAAAAAAAAABp/////////////3EAAAAAAAAAAAAAAAAAY////////////////3kAAAAAAAAAA" +
                        "AAAAABO/////////////////////////0wAAAAAAAAAAAAAAACr//////+3AAAAAAAAAAAAAAAAAEf//" +
                        "////////////////////UAAAAAAAAAAAAAAAAAe/////////wD/////////////////////////fwAAA" +
                        "AAAAAAAAAAAAAAAAAAAVf////////////////////////////////QfAAAAAAAAAAAAAAAAAJ7//////" +
                        "////////////////////1UAAAAAAAAAAAAAAAAAd/////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH////////////////APAAAAA" +
                        "AAAAAAAAAAAUtkTAAAAAAAAAAAAAAAAVv////////////////////////+lAAAAAAAAAAAAAAAAABr2/" +
                        "////////////////////////8sEAAAAAAAAAAAAAAAAAHf/////////////cQAAAAAAAAAAAAAAAABj/" +
                        "///////////////oAAAAAAAAAAAAAAAAEf////////////////////////9QAAAAAAAAAAAAAAAALj//" +
                        "////7cAAAAAAAAAAAAAAAAARv/////////////////////4LAAAAAAAAAAAAAAAAB7/////////AP///" +
                        "//////////////////////xNwAAAAAAAAAAAAAAAAAAAAACpP//////////////////////////////+" +
                        "jIAAAAAAAAAAAAAAAAAdP/////////////////////////5KgAAAAAAAAAAAAAAAACh/////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+CwAAAAAAAAAAAAAA" +
                        "AAAf///////////////8A8AAAAAAAAAAAAAAABH/5sAAAAAAAAAAAAAAAAAdPf//////////////////" +
                        "////8sDAAAAAAAAAAAAAAAACd//////////////////////////pAAAAAAAAAAAAAAAAAAAl////////" +
                        "/////9xAAAAAAAAAAAAAAAAAGP////////////////NBQAAAAAAAAAAAAAALfr//////////////////" +
                        "/////gpAAAAAAAAAAAAAAAEyv//////twAAAAAAAAAAAAAAAAA2+/////////////////////grAAAAA" +
                        "AAAAAAAAAAAHv////////8A///////////////////////////aDwAAAAAAAAAAAAAAAAAAAAAM1P///" +
                        "///////////////////////////TAAAAAAAAAAAAAAAAAA4/f///////////////////////9UGAAAAA" +
                        "AAAAAAAAAAABtf/////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAAEf//UoAAAAAAAAAA" +
                        "AAAAAAAZv//////////////////////9yEAAAAAAAAAAAAAAAAApP////////////////////////92A" +
                        "AAAAAAAAAAAAAAAAAPO/////////////3EAAAAAAAAAAAAAAAAAY/////////////////wxAAAAAAAAA" +
                        "AAAAAAL4///////////////////////7Q8AAAAAAAAAAAAAAArl//////+3AAAAAAAAAAAAAAAAACD3/" +
                        "///////////////////8xQAAAAAAAAAAAAAAAAe/////////wD///////////////////////////9yA" +
                        "AAAAAAAAAAAAAAAAAAAAABW//////////////////////////////9iAAAAAAAAAAAAAAAAAAvm/////" +
                        "///////////////////owAAAAAAAAAAAAAAAAAg9v////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH////////////////APAAAAA" +
                        "AAAAAAAAAAAR///4RkAAAAAAAAAAAAAAAAAyf//////////////////////UQAAAAAAAAAAAAAAAABu/" +
                        "////////////////////////1wAAAAAAAAAAAAAAAAAHPT/////////////cQAAAAAAAAAAAAAAAABj/" +
                        "////////////////2oAAAAAAAAAAAAAAAG6///////////////////////OBQAAAAAAAAAAAAAAIPb//" +
                        "////7cAAAAAAAAAAAAAAAAACuP////////////////////fCQAAAAAAAAAAAAAAAB7/////////AP///" +
                        "////////////////////////8AAAAAAAAAAAAAAAAAAAAAAAAK+/////////////////////////////" +
                        "4IAAAAAAAAAAAAAAAAAAKb///////////////////////9nAAAAAAAAAAAAAAAAAFT//////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+CwAAAAAAAAAAAAAA" +
                        "AAAf///////////////8A8AAAAAAAAAAAAAAABH////sQIAAAAAAAAAAAAAAABS/////////////////" +
                        "/////+GAAAAAAAAAAAAAAAAAC78///////////////////////+PQAAAAAAAAAAAAAAAABO/////////" +
                        "/////9xAAAAAAAAAAAAAAAAAGP/////////////////pwAAAAAAAAAAAAAAAIn//////////////////" +
                        "////6oAAAAAAAAAAAAAAABR////////twAAAAAAAAAAAAAAAAAAp////////////////////74BAAAAA" +
                        "AAAAAAAAAAAH/////////8A////////////////////////////9ywAAAAAAAAAAAAAAAAAAAAAADr7/" +
                        "///////////////////////////uQAAAAAAAAAAAAAAAAAAb///////////////////////9B8AAAAAA" +
                        "AAAAAAAAAAAkP//////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAAEf/////dQAAAAAAA" +
                        "AAAAAAAAACK/////////////////////8EAAAAAAAAAAAAAAAAABM7///////////////////////YbA" +
                        "AAAAAAAAAAAAAAAAIr//////////////3EAAAAAAAAAAAAAAAAAY//////////////////oEQAAAAAAA" +
                        "AAAAAAAZf//////////////////////eQAAAAAAAAAAAAAAAIb///////+3AAAAAAAAAAAAAAAAAABb/" +
                        "///////////////////jwAAAAAAAAAAAAAAAAAp/////////wD/////////////////////////////r" +
                        "wAAAAAAAAAAAAAAAAAAAAAAAJv////////////////////////////wFwAAAAAAAAAAAAAAAABH/////" +
                        "/////////////////+yAAAAAAAAAAAAAAAAAATS//////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH////////////////APAAAAA" +
                        "AAAAAAAAAAAR//////3PgAAAAAAAAAAAAAAAAa2////////////////////9h4AAAAAAAAAAAAAAAAAd" +
                        "v//////////////////////ugIAAAAAAAAAAAAAAAACzv//////////////cQAAAAAAAAAAAAAAAABj/" +
                        "/////////////////9UAAAAAAAAAAAAAABA//////////////////////8+AAAAAAAAAAAAAAAAwf///" +
                        "////7cAAAAAAAAAAAAAAAAAAA/f//////////////////9QAAAAAAAAAAAAAAAAADL/////////AP///" +
                        "///////////////////////////eAAAAAAAAAAAAAAAAAAAAAAAE93//////////////////////////" +
                        "/9+AAAAAAAAAAAAAAAAAAzN////////////////////8S8AAAAAAAAAAAAAAAAAUv7//////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+CwAAAAAAAAAAAAAA" +
                        "AAAf///////////////8A8AAAAAAAAAAAAAAABH///////oQgAAAAAAAAAAAAAAAA+k/////////////" +
                        "///////hwAAAAAAAAAAAAAAAAAQyv////////////////////IxAAAAAAAAAAAAAAAAAE/9/////////" +
                        "/////9xAAAAAAAAAAAAAAAAAGP//////////////////8gFAAAAAAAAAAAAAAvM/////////////////" +
                        "///uQQAAAAAAAAAAAAAADj4////////twAAAAAAAAAAAAAAAAAAAEH0////////////////wQkAAAAAA" +
                        "AAAAAAAAAAARv////////8A///////////////////////////////2KgAAAAAAAAAAAAAAAAAAAAAAl" +
                        "////////////////////////////+ALAAAAAAAAAAAAAAAAAEf///////////////////97AAAAAAAAA" +
                        "AAAAAAAAAG7////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAAEf///////+/AAAAA" +
                        "AAAAAAAAAAAAAnF///////////////////kEAAAAAAAAAAAAAAAAABA/v//////////////////hQAAA" +
                        "AAAAAAAAAAAAAAAtf///////////////3EAAAAAAAAAAAAAAAAAY////////////////////0wAAAAAA" +
                        "AAAAAAAAFL///////////////////5EAAAAAAAAAAAAAAAAjv////////+3AAAAAAAAAAAAAAAAAAAAA" +
                        "Gf///////////////9eAAAAAAAAAAAAAAAAAABa/////////wD//////////////////////////////" +
                        "/+pAAAAAAAAAAAAAAAAAAAAAAAw9////////////////////////////1oAAAAAAAAAAAAAAAAAAJP//" +
                        "///////////////yAkAAAAAAAAAAAAAAAAAIff///////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH////////////////APAAAAA" +
                        "AAAAAAAAAAAR/////////pJAAAAAAAAAAAAAAAAACXl//////////////////9lAAAAAAAAAAAAAAAAA" +
                        "ACM/////////////////8wMAAAAAAAAAAAAAAAAACz5////////////////cQAAAAAAAAAAAAAAAABj/" +
                        "///////////////////uQMAAAAAAAAAAAAAAq7/////////////////tgEAAAAAAAAAAAAAAAve/////" +
                        "////7cAAAAAAAAAAAAAAAAAAAAAAG/5////////////2hQAAAAAAAAAAAAAAAAAAG3/////////AP///" +
                        "/////////////////////////////5FAAAAAAAAAAAAAAAAAAAAAACS/////////////////////////" +
                        "///xwMAAAAAAAAAAAAAAAAAB7T///////////////9FAAAAAAAAAAAAAAAAAABS/////////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+CwAAAAAAAAAAAAAA" +
                        "AAAf///////////////8A8AAAAAAAAAAAAAAABH/////////94ZAAAAAAAAAAAAAAAAAGj//////////" +
                        "////////9IIAAAAAAAAAAAAAAAAAAav///////////////fKQAAAAAAAAAAAAAAAAAAnf///////////" +
                        "/////9yAAAAAAAAAAAAAAAAAGT////////////////////7KQAAAAAAAAAAAAAAGdn//////////////" +
                        "/9KAAAAAAAAAAAAAAAAV///////////twAAAAAAAAAAAAAAAAAAAAAAAEDW/////////rMiAAAAAAAAA" +
                        "AAAAAAAAAAAjf////////8A/////////////////////////////////8kGAAAAAAAAAAAAAAAAAAAAA" +
                        "Bjq////////////////////////////VgAAAAAAAAAAAAAAAAAACZb////////////1bwAAAAAAAAAAA" +
                        "AAAAAAAAKP/////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAAEf//////////7EAA" +
                        "AAAAAAAAAAAAAAAEt///////////////////zQAAAAAAAAAAAAAAAAAAB3X////////////zCcAAAAAA" +
                        "AAAAAAAAAAAACn3/////vj4+Pj4+Pj4+G4AAAAAAAAAAAAAAAAAYPj4+Pj4+Pj4+Pj+//////9jAAAAA" +
                        "AAAAAAAAAAALNT/////////////owUAAAAAAAAAAAAAAADH//////////+3AAAAAAAAAAAAAAAAAAAAA" +
                        "AAAABFgkrS6rodAAAAAAAAAAAAAAAAAAAAAAAHK/////////wD//////////////////////////////" +
                        "////2oAAAAAAAAAAAAAAAAAAAAAAGL8///////////////////////////aIgAAAAAAAAAAAAAAAAAAA" +
                        "FSvz+Xw7tq6kzMAAAAAAAAAAAAAAAAAAABU+/////////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH////////////////APAAAAA" +
                        "AAAAAAAAAAAR////////////4YEAAAAAAAAAAAAAAAAPd//////////////////lAAAAAAAAAAAAAAAA" +
                        "AAAABZ3sM7m8OnXvJIbAAAAAAAAAAAAAAAAAAAItf/////aMSosLCwsLCwtEwAAAAAAAAAAAAAAAAARL" +
                        "CwsLCwsLCwqOPL//////9AdAAAAAAAAAAAAAAAAG47a/P/////svnEDAAAAAAAAAAAAAAAAY////////" +
                        "////7cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAOPr/////////AP///" +
                        "///////////////////////////////1gMAAAAAAAAAAAAAAAAAAAAAAJf//////////////////////" +
                        "//////NCgAAAAAAAAAAAAAAAAAAAAAGDA8PCQAAAAAAAAAAAAAAAAAAAAAAOvb//////////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+CwAAAAAAAAAAAAAA" +
                        "AAAf///////////////8A8AAAAAAAAAAAAAAABH/////////////4kAAAAAAAAAAAAAAAAAKef//////" +
                        "///////////bQAAAAAAAAAAAAAAAAAAAAAABQ0PDggAAAAAAAAAAAAAAAAAAAAAAFb//////9IAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAI8P///////8YIAAAAAAAAAAAAAAAAAAk5Zn96SRQBA" +
                        "AAAAAAAAAAAAAAAAC/2////////////uQAAAAAAAAAAAAAAAA8zAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAACo//////////8A///////////////////////////////////+UAAAAAAAAAAAAAAAAAAAA" +
                        "AAAGun///////////////////////////9TAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAABbW////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAAEf//////////////" +
                        "U4AAAAAAAAAAAAAAAAATv3////////////////zNwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAPzv//////0wcAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA/w/////////44AA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAGwP////////////+pAAAAAAAAAAAAAAAAJpsAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAK/f//////////wD//////////////////////////////" +
                        "//////TCAAAAAAAAAAAAAAAAAAAAAAAdP///////////////////////////9YeAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAGtf////////////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH////////////////APAAAAA" +
                        "AAAAAAAAAAAR///////////////4xMAAAAAAAAAAAAAAAAAgP/////////////////dHgAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABq3////////TBwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAD/D//////////2UAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEP//////////" +
                        "////5oAAAAAAAAAAAAAAAAw5yAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACe////////////AP///" +
                        "/////////////////////////////////9zAAAAAAAAAAAAAAAAAAAAAAAL1P///////////////////" +
                        "////////9AeAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAKT//////////////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+CwAAAAAAAAAAAAAA" +
                        "AAAf///////////////8A8AAAAAAAAAAAAAAABH////////////////ZAAAAAAAAAAAAAAAAAAFuP///" +
                        "//////////////QHgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAWk/////////9MHAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP8P//////////+E8AAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAQw///////////////nAAAAAAAAAAAAAAAACz/rgAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAPfj///////////8A/////////////////////////////////////+otAAAAAAAAAAAAAAAAA" +
                        "AAAAABj/////////////////////////////9FJAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "A+A////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAAEf//////////////" +
                        "//dNAAAAAAAAAAAAAAAAAA08v/////////////////QLgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAxrP//////////0wcAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA/w////////////7" +
                        "1sAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAANL////////////////+bAAAAAAAAAAAAAAAAPv//j" +
                        "wwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACvV/////////////wD//////////////////////////////" +
                        "////////88IAAAAAAAAAAAAAAAAAAAAAA7f//////////////////////////////+xIQAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAABA0/////////////////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH////////////////APAAAAA" +
                        "AAAAAAAAAAAR//////////////////rJwAAAAAAAAAAAAAAAABR/f/////////////////tZwAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAU/b////////////TBwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAD/D//////////////3wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAG/1/////////////" +
                        "////4UAAAAAAAAAAAAAAABQ////uxYAAAAAAAAAAAAAAAAAAAAAAAAAAAAf6P//////////////AP///" +
                        "////////////////////////////////////20AAAAAAAAAAAAAAAAAAAAAAGn//////////////////" +
                        "//////////////ULwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAZj/v//////////////////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+CwAAAAAAAAAAAAAA" +
                        "AAAf///////////////8A8AAAAAAAAAAAAAAABH///////////////////ECAAAAAAAAAAAAAAAAACA/" +
                        "///////////////////sTEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAFYj4/////////////9MHAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP8P///////////////7crAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAyk////////////////////fQAAAAAAAAAAAAAAAGL/////0C0AAAAAAAAAAAAAAAAAAAAAA" +
                        "AAADa////////////////8A////////////////////////////////////////5xoAAAAAAAAAAAAAA" +
                        "AAAAAAAB83////////////////////////////////ykC0AAAAAAAAAAAAAAAAAAAAAAAAAAAABUN///" +
                        "///////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAAEf//////////////" +
                        "/////+KAAAAAAAAAAAAAAAAAASy////////////////////954rAAAAAAAAAAAAAAAAAAAAAAAAAAAAF" +
                        "nHc////////////////0wYAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA7w/////////////" +
                        "////+1/EgAAAAAAAAAAAAAAAAAAAAAAAAA7u/////////////////////9oAAAAAAAAAAAAAAAAbv///" +
                        "///6zwAAAAAAAAAAAAAAAAAAAAAAD3H/////////////////wD//////////////////////////////" +
                        "///////////ggAAAAAAAAAAAAAAAAAAAAAASP//////////////////////////////////9qpMBQAAA" +
                        "AAAAAAAAAAAAAAAAAAgaL7///////////////////////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////gqAAAAAAAAAAAAAAAAAH7///////////////APAAAAA" +
                        "AAAAAAAAAAAR/////////////////////1OAAAAAAAAAAAAAAAAAA3P/////////////////////+qCL" +
                        "wYAAAAAAAAAAAAAAAAAAAAAIYjl///////////////////RAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAABu/////////////////////UUgwAAAAAAAAAAAAAAAAAAAxSrv3//////////////////" +
                        "////0oAAAAAAAAAAAAAAAB7////////8oIgAAAAAAAAAAAAAAAAADSd+v//////////////////AP///" +
                        "//////////////////////////////////////LAAAAAAAAAAAAAAAAAAAAAAAArP///////////////" +
                        "//////////////////////OjV8zDwoHBQMDBggMFTp7vPL//////////////////////////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+C4CAwMDAwMDAwMDA" +
                        "wMCgP//////////////8A8AAAAAAAAAAAAAAABH/////////////////////+mcm5ycnJycnJycnJyck" +
                        "cb////////////////////////50ZNbIA4JBwUCBAcIDCBSf7ny/////////////////////+6empycn" +
                        "JycnJ1FAAAAAAAAAAAAAAAAADydnJycnJycnJqi+f//////////////////////35deJwwHBQMDBgkNI" +
                        "E2W4P//////////////////////////tpicnJycnJycnJycls3///////////CmYBsKBwQDBggNIFek+" +
                        "v////////////////////8A//////////////////////////////////////////1rAAAAAAAAAAAAA" +
                        "AAAAAAAAAAX1f////////////////////////////////////////rs3NPMxMbQ1+Tx/P///////////" +
                        "///////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////90MTFxcXFxcXFxcXFxcPi///////////////wDwAAAAAAAAAAAAAAAEf//////////////" +
                        "//////////////////////////////////////////////////////////06dvUzMTJ09fk9P///////" +
                        "////////////////////////////////3cAAAAAAAAAAAAAAAAAaf///////////////////////////" +
                        "//////////////25dTOxcbR2uj0/////////////////////////////////////////////////////" +
                        "///////////8d7TycXP1+f0/////////////////////////wD//////////////////////////////" +
                        "////////////+8gAAAAAAAAAAAAAAAAAAAAAABM/////////////////////////////////////////" +
                        "/////////////////////////////////////////////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////////////////////////////////////////APAAAAA" +
                        "AAAAAAAAAAAR////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////cQAAAAAAAAAAAAAAAABj/" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////50AAAAAAAAAAAAAAAAAAAAAAACz/////////////" +
                        "////////////////////////////////////////////////////////////////////////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj//////////////////////////////" +
                        "///////////////////8A8AAAAAAAAAAAAAAABH/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////9xAAAAAAAAAAAAAAAAAGP//////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A////////////////////////////////////////////+zoAAAAAAAAAA" +
                        "AAAAAAAAAAAAFT//////////////////////////////////////////////////////////////////" +
                        "///////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////////////45eHh6vr////////////////////wDwAAAAAAAAAAAAAAAEf//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////3EAAAAAAAAAAAAAAAAAY////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "///////////////vgAAAAAAAAAAAAAAAAAAAAAAGPH//////////////////////////////////////" +
                        "/////////////////////////////////////////////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////////////jVtJuUk5OVnbrp//////////////////APAAAAA" +
                        "AAAAAAAAAAAR////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////cQAAAAAAAAAAAAAAAABj/" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "///////////////////////////////////////////agAAAAAAAAAAAAAAAAAAAAAAcv///////////" +
                        "////////////////////////////////////////////////////////////////////////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj///////////////3To5OTk5OTk5OTk" +
                        "5W63/7/////////////8A8AAAAAAAAAAAAAAABH/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////9xAAAAAAAAAAAAAAAAAGP//////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A///////////////////////////////////////////////4NgAAAAAAA" +
                        "AAAAAAAAAAAAAAApv///////////////////////////////////////////////////////////////" +
                        "///////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////////4sZOTk5OTk5OTk5OTk5OTtPf////////////wDwAAAAAAAAAAAAAAAEf//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////3EAAAAAAAAAAAAAAAAAY////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "/////////////////+5AwAAAAAAAAAAAAAAAAAAAAAm8////////////////////////////////////" +
                        "/////////////////////////////////////////////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4////////////+rCTk5OTk5OTk5OTk5OTk5OTvf////////////APAAAAA" +
                        "AAAAAAAAAAAR////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////cQAAAAAAAAAAAAAAAABj/" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "/////////////////////////////////////////////0xAAAAAAAAAAAAAAAAAAAAAACH/////////" +
                        "////////////////////////////////////////////////////////////////////////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj///////////+/k5OTk5OTk5OTk5OTk" +
                        "5OTk5OX7v//////////8A8AAAAAAAAAAAAAAABH/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////9xAAAAAAAAAAAAAAAAAGP//////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////3cAAAAAA" +
                        "AAAAAAAAAAAAAAAABXh/////////////////////////////////////////////////////////////" +
                        "///////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "///////4ZOTk5OTk5OTk5OTk5OTk5OTk5Oy///////////wDwAAAAAAAAAAAAAAAEf//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////3EAAAAAAAAAAAAAAAAAZf///////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "///////////////////3hIAAAAAAAAAAAAAAAAAAAAAAGT//////////////////////////////////" +
                        "/////////////////////////////////////////////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4//////////2qk5OTk5OTk5OTk5OTk5OTk5OTk5Ph//////////APAAAAA" +
                        "AAAAAAAAAAAR////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////cQAAAAAAAAAAAAAAAABd/" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "///////////////////////////////////////////////vw0AAAAAAAAAAAAAAAAAAAAAA5///////" +
                        "////////////////////////////////////////////////////////////////////////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////2ZOTk5OTk5OTk5OTk5OTk" +
                        "5OTk5OTk6v9////////8A8AAAAAAAAAAAAAAABH/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////9xAAAAAAAAAAAAAAAAAB/v/////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////7eYnJycnJycnJycnJycnJycnJycnJycnJycnJycnJyjLAAAA" +
                        "AAAAAAAAAAAAAAAAAAAXf///////////////////////////////////////////////////////////" +
                        "///////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////Ak5OTk5OTk5OTk5OTk5OTk5OTk5OTk+r////////wDwAAAAAAAAAAAAAAAEf//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////3EAAAAAAAAAAAAAAAAAAJ///////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD/////////QAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABj/////////////////////////////////" +
                        "/////////////////////////////////////////////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4/////////7eTk5OTk5OTk5OTk5OTk5OTk5OTk5OT2f////////APAAAAA" +
                        "AAAAAAAAAAAR////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////fwAAAAAAAAAAAAAAAAAAT" +
                        "P///////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "/////9GAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAGP//////" +
                        "////////////////////////////////////////////////////////////////////////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////spOTk5OTk5OTk5OTk5OTk" +
                        "5OTk5OTk5PL////////8A8AAAAAAAAAAAAAAABH/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////+XAAAAAAAAAAAAAAAAAAAIrP///////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////0cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAY////////////////////////////////////////////////////////////" +
                        "///////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "/////+xk5OTk5OTk5OTk5OTk5OTk5OTk5OTk8j////////wDwAAAAAAAAAAAAAAAEf//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////8IAAAAAAAAAAAAAAAAAAAACa9j2/Pz59OKiyv///////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD/////////RwAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABj/////////////////////////////////" +
                        "/////////////////////////////////////////////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4/////////7STk5OTk5OTk5OTk5OTk5OTk5OTk5OT0v////////APAAAAA" +
                        "AAAAAAAAAAAR////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////9isAAAAAAAAAAAAAAAAAA" +
                        "AAACSU4Oi4dCwCN/////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "/////9HAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAGP//////" +
                        "////////////////////////////////////////////////////////////////////////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////vJOTk5OTk5OTk5OTk5OTk" +
                        "5OTk5OTk5Pj////////8A8AAAAAAAAAAAAAAABH/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////fAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAI7//////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////0cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAY////////////////////////////////////////////////////////////" +
                        "///////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "//////Jk5OTk5OTk5OTk5OTk5OTk5OTk5OTm/f////////wDwAAAAAAAAAAAAAAAEf//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////WCAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAiP///////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD/////////RwAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABj/////////////////////////////////" +
                        "/////////////////////////////////////////////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4/////////+eUk5OTk5OTk5OTk5OTk5OTk5OTk5O4//////////APAAAAA" +
                        "AAAAAAAAAAAR////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////9hAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAB//////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "/////9HAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAGP//////" +
                        "////////////////////////////////////////////////////////////////////////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj//////////rCTk5OTk5OTk5OTk5OTk" +
                        "5OTk5OTk+P/////////8A8AAAAAAAAAAAAAAABH/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////9wPAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHr//////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////0cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAY////////////////////////////////////////////////////////////" +
                        "///////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAAAAAAAAAAAAs+P///" +
                        "///////55yTk5OTk5OTk5OTk5OTk5OTk5O+///////////wDwAAAAAAAAAAAAAAAEf//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////6kTAAAAAAAAAAAAAAAAAAAAAAAAAAAAZf///////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD/////////RwAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABj/////////////////////////////////" +
                        "/////////////////////////////////////////////////9xAAAAAAAAAAAAAAAAAGP//////////" +
                        "//4LAAAAAAAAAAAAAAAACz4////////////5ZiTk5OTk5OTk5OTk5OTk5OTqP7///////////APAAAAA" +
                        "AAAAAAAAAAAR////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////80eAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAABY/////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "/////9FAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAGH//////" +
                        "////////////////////////////////////////////////////////////////////////////3EAA" +
                        "AAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////2ZaTk5OTk5OTk5OTk" +
                        "5OTk5nf////////////8A8AAAAAAAAAAAAAAABH/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////8MPAAAAAAAAAAAAAAAAAAAAAAAAAEf//////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////0wHBwcHBwcHBwcHBwcHBwcHBwcHBwcHBwcHBwcHBwcHBwcHB" +
                        "wcHBwcHBwcHBwcHBwcHZ////////////////////////////////////////////////////////////" +
                        "///////////////////////ZwAAAAAAAAAAAAAAAABY////////////+B0AAAAAAAAAAAAAAAAd+P///" +
                        "///////////4JmTk5OTk5OTk5OTk5Ok5f/////////////vAAAAAAAAAAAAAAAAADr//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////81LAQAAAAAAAAAAAAAAAAAAAAAANv7//////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD/////////4NLT09PT09PT09PT09PT0" +
                        "9PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09Lk/////////////////////////////////" +
                        "/////////////////////////////////////////////////+4f39/f39/f39/f39/f7H//////////" +
                        "//7lX9/f39/f39/f39/f5X7////////////////4aeTk5OTk5OTk5OXwPX///////////////eHf39/f" +
                        "39/f39/f39/o////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////////////++YxUAAAAAA" +
                        "AAAAAAAAAAACiaB/P///////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////Nq6n5iWl5miw" +
                        "O3//////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////5J5yTTMiDw8jLUJqjbXf9v///////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////68uzw9fv//////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////+vXw8PX4/////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////////7b09PT09PT09PT0" +
                        "9PT0/P//////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////+DIHBwcHBwcHBwcHBwcHuf///////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////2IwAAAAAAAAAAAAAAAAC2/////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////////QdAAAAAAAAAAAAA" +
                        "AAAALX//////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////9B8AAAAAAAAAAAAAAAADwv///////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////yFgAAAAAAAAAAAAAAAAfU/////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////////IPAAAAAAAAAAAAA" +
                        "AAAB9T//////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////4wsAAAAAAAAAAAAAAAAM6////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////CAgAAAAAAAAAAAAAAAB31/////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////68AAAAAAAAAAAAAA" +
                        "AAAL/n//////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////mAAAAAAAAAAAAAAAAABF/////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////98AAAAAAAAAAAAAAAAAFr//////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////14AAAAAAAAAAAAAA" +
                        "AAAdP///////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////9OQAAAAAAAAAAAAAAAACU/////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////+oNAAAAAAAAAAAAAAAAAb7//////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////xQMAAAAAAAAAAAAAA" +
                        "AAI3v///////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////+cAAAAAAAAAAAAAAAAAB31/////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////3IAAAAAAAAAAAAAAAAAQv7//////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////PwAAAAAAAAAAAAAAA" +
                        "ABo/////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////94MAAAAAAAAAAAAAAAAAKP//////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////owAAAAAAAAAAAAAAAAAG2f///////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////9qAAAAAAAAAAAAAAAAA" +
                        "CD2/////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////DEAAAAAAAAAAAAAAAAAVP///////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////aBwAAAAAAAAAAAAAAAACG/////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////48AAAAAAAAAAAAAAAAAB" +
                        "Mf//////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////7LgAAAAAAAAAAAAAAAAAg9////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////9AEAAAAAAAAAAAAAAAAAD39/////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////hwAAAAAAAAAAAAAAAAAAW" +
                        "v///////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////9cAAAAAAAAAAAAAAAAAAB9/////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////+y4AAAAAAAAAAAAAAAAABMP//////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////BAgAAAAAAAAAAAAAAAABB/" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////2gAAAAAAAAAAAAAAAAAAIr//////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////qFgAAAAAAAAAAAAAAAAAG1f///////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////5IAAAAAAAAAAAAAAAAAAEH//" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//8LwAAAAAAAAAAAAAAAAAAkP///////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////4wAAAAAAAAAAAAAAAAAACXv/////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////vGAAAAAAAAAAAAAAAAAAAgf///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "48AAAAAAAAAAAAAAAAAAAna/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////wIAAAAAAAAAAAAAAAAAAAUP///////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////48AAAAAAAAAAAAAAAAAAAC0/////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////////////////////oH" +
                        "gAAAAAAAAAAAAAAAAAAP/r//////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////5sAAAAAAAAAAAAAAAAAAACk/////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////4NAAAAAAAAAAAAAAAAAAABdn//////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////5QAA" +
                        "AAAAAAAAAAAAAAAAABF/P///////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////kFwAAAAAAAAAAAAAAAAAAALr//////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////2IAAAAAAAAAAAAAAAAAAABG/v///////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////////////////+AAAAAA" +
                        "AAAAAAAAAAAAAAAFtf//////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////uQAAAAAAAAAAAAAAAAAAAACK/////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////QoAAAAAAAAAAAAAAAAAAAAJvL//////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////sAAAAAAAA" +
                        "AAAAAAAAAAAAACi/////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////k6AAAAAAAAAAAAAAAAAAAAPfz//////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////1YwAAAAAAAAAAAAAAAAAAAACv/////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////VUAAAAAAAAAA" +
                        "AAAAAAAAAAAPvv//////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////9/AAAAAAAAAAAAAAAAAAAAAAnN/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////qwIAAAAAAAAAAAAAAAAAAAAAfP///////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////8sQAAAAAAAAAAAAA" +
                        "AAAAAAAAC3z/////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////vOAAAAAAAAAAAAAAAAAAAAAAdx////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////7kQAAAAAAAAAAAAAAAAAAAAADcb//////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////hJAAAAAAAAAAAAAAAAA" +
                        "AAAAAB8/////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////5WgAAAAAAAAAAAAAAAAAAAAAACNv//////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////91sAAAAAAAAAAAAAAAAAAAAAAACH/////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////9xAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAWP7//////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//vZQQAAAAAAAAAAAAAAAAAAAAAAG72/////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////4T4AAAAAAAAAAAAAAAAAAAAAAABX/////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////9EtAAAAAAAAAAAAAAAAAAAAAAAAO" +
                        "PD//////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////////////////////BG" +
                        "gAAAAAAAAAAAAAAAAAAAAAAABLd/////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////3R8AAAAAAAAAAAAAAAAAAAAAAAAAev///////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////8J8hAAAAAAAAAAAAAAAAAAAAAAAAAmv2/" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////8MsAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAej/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////+GBwAAAAAAAAAAAAAAAAAAAAAAAAAAmv///////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////fwAAAAAAAAAAAAAAAAAAAAAAAAAAAIv//////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////1EcAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAABT/////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////8osSAAAAAAAAAAAAAAAAAAAAAAAAAAAARu3//////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////94wjAAAAAAAAAAAAAAAAAAAAAAAAAAAAEJb2/////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////640AAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAB2+/////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////7dHAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAr0v///////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////+plAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADMv//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////d5/HAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAACXA/////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////4Xk9D" +
                        "QAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABiT6v///////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////3t18SAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA11f///////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////lhykAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAK+L//////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////t6aVhIAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAGHr/////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////31ZJACgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB+m/////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////z06dzMvKeHXyoIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAhk4" +
                        "P///////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////+m3uK2bnId7ZltIOB8OCgUAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAABEy////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////nQAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAjoP///////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////+bAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAc+f//////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////5wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAJqr//////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////nAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHYrv/////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////+cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACWrbs/////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////5wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAALW8T//////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////nAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAbedb//////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////+cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAecOD//////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////5wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAlPo" +
                        "+7//////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////nAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAANLU900v///////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////+cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA5BmOP4/////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////5wAAAAAAAAAAAAAAAAAAAAAAAAAAAAHN3Kn4/7//////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////nAAAAAAAAAAAAAAAAAAAA" +
                        "AAIIERvmdP7/////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////+XAAAAAAAABAoPHzRNaH+Xs9b0/////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////8Fxf46cprjL3fD0+v///////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////8A/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////wD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////AAtAA" +
                        "AEAAAD/////AQAAAAAAAAAMAgAAABtEZXZFeHByZXNzLlh0cmFSZXBvcnRzLnY2LjIFAQAAACxEZXZFe" +
                        "HByZXNzLlh0cmFSZXBvcnRzLlVJLlNlcmlhbGl6YWJsZVN0cmluZwEAAAAFVmFsdWUBAgAAAAYDAAAAs" +
                        "QF7XHJ0ZjFcYW5zaWNwZzEyNTINCnsNClxmb250dGJsDQp7XGYwIFRpbWVzIE5ldyBSb21hbjt9DQp7X" +
                        "GYxIE1pY3Jvc29mdCBTYW5zIFNlcmlmO30NCn0NCnsNClxjb2xvcnRibA0KOw0KXHJlZDBcZ3JlZW4wX" +
                        "GJsdWUwOw0KfQ0Ke1xwYXJkXHBsYWlue1xiXGYxXGZzMjhcY2YxIEdlbWVpbmRlfVxwYXJ9DQp9DQoLQ" +
                        "AABAAAA/////wEAAAAAAAAADAIAAAAbRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy52Ni4yBQEAAAAsRGV2R" +
                        "XhwcmVzcy5YdHJhUmVwb3J0cy5VSS5TZXJpYWxpemFibGVTdHJpbmcBAAAABVZhbHVlAQIAAAAGAwAAA" +
                        "PYEe1xydGYxXGFuc2lcYW5zaWNwZzEyNTJcZGVmZjB7XGZvbnR0Ymx7XGYwXGZuaWxcZmNoYXJzZXQwI" +
                        "EFyaWFsO317XGYxXGZuaWwgVGltZXMgTmV3IFJvbWFuO319DQp7XGNvbG9ydGJsIDtccmVkMFxncmVlb" +
                        "jBcYmx1ZTA7fQ0KXHZpZXdraW5kNFx1YzFccGFyZFxjZjFcbGFuZzIwNTVcZnMxOCBHZWdlbiBkaWVzZ" +
                        "SBWZXJmXCdmY2d1bmcga2FubiBpbm5lcnQgMzAgVGFnZW4gc2VpdCBkZXIgRXJcJ2Y2ZmZudW5nIGJla" +
                        "SBkZXIgUmVnaWVydW5nc3N0YXR0aGFsdGVyYW10IEJlcm4tTWl0dGVsbGFuZCwgUG9zdHN0cmFzc2UgM" +
                        "jUsIDMwNzEgT3N0ZXJtdW5kaWdlbiBWZXJ3YWx0dW5nc2Jlc2Nod2VyZGUgZ2VmXCdmY2hydCB3ZXJkZ" +
                        "W4uIERpZSBCZXNjaHdlcmRlIGlzdCBpbSBEb3BwZWwgZWluenVyZWljaGVuLCBtdXNzIGVpbmVuIEFud" +
                        "HJhZywgZGllIEFuZ2FiZW4gdm9uIFRhdHNhY2hlbiB1bmQgQmV3ZWlzbWl0dGVsbiwgZWluZSBCZWdyX" +
                        "CdmY25kdW5nIHNvd2llIGVpbmUgVW50ZXJzY2hyaWZ0IGVudGhhbHRlbi5cY2YwICBEaWUgYW5nZWZvY" +
                        "2h0ZW5lIFZlcmZcJ2ZjZ3VuZyB1bmQgYWxsZlwnZTRsbGlnZSBCZXdlaXNtaXR0ZWwgc2luZCBiZWl6d" +
                        "WxlZ2VuLlxsYW5nMTAzM1xmMVxmczI0XHBhcg0KfQ0KC0AAAQAAAP////8BAAAAAAAAAAwCAAAAG0Rld" +
                        "kV4cHJlc3MuWHRyYVJlcG9ydHMudjYuMgUBAAAALERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuU2Vya" +
                        "WFsaXphYmxlU3RyaW5nAQAAAAVWYWx1ZQECAAAABgMAAACcAntccnRmMVxhbnNpY3BnMTI1Mg0Kew0KX" +
                        "GZvbnR0YmwNCntcZjAgVGltZXMgTmV3IFJvbWFuO30NCntcZjEgTWljcm9zb2Z0IFNhbnMgU2VyaWY7f" +
                        "Q0KfQ0Kew0KXGNvbG9ydGJsDQo7DQpccmVkMFxncmVlbjBcYmx1ZTA7DQp9DQp7XHBhcmRccGxhaW57X" +
                        "GYxXGZzMThcY2YxIFNvemlhbGRpZW5zdCBab2xsaWtvZmVufVxwYXJccGFyZFxwbGFpbntcZjFcZnMxO" +
                        "FxjZjEgV2FobGFja2Vyc3RyYXNzZSAyNX1ccGFyXHBhcmRccGxhaW57XGYxXGZzMThcY2YxIDMwNTIgW" +
                        "m9sbGlrb2Zlbn1ccGFyfQ0KfQ0KCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
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
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrRichText2 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
            this.rtfHinweis = new DevExpress.XtraReports.UI.XRRichText();
            this.xrRichTextBox1 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.ShFinanzplanverfuegung_EinAus = new DevExpress.XtraReports.UI.Subreport();
            this.ShFinanzplanverfuegung_Personen = new DevExpress.XtraReports.UI.Subreport();
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
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtfHinweis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPictureBox1,
                        this.xrRichText2,
                        this.xrLine3,
                        this.xrLine2,
                        this.xrLabel3,
                        this.xrRichText1,
                        this.rtfHinweis,
                        this.xrRichTextBox1,
                        this.xrPanel1,
                        this.xrLabel2,
                        this.xrLabel1,
                        this.xrLine1,
                        this.ShFinanzplanverfuegung_EinAus,
                        this.ShFinanzplanverfuegung_Personen,
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
                        this.txtTitle});
            this.Detail.Height = 775;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBackColor = false;
            this.Detail.ParentStyleUsing.UseBorderColor = false;
            this.Detail.ParentStyleUsing.UseBorders = false;
            this.Detail.ParentStyleUsing.UseBorderWidth = false;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.ParentStyleUsing.UseForeColor = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageInfo2});
            this.PageFooter.Height = 21;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.Location = new System.Drawing.Point(108, 0);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.Size = new System.Drawing.Size(125, 83);
            // 
            // xrRichText2
            // 
            this.xrRichText2.BackColor = System.Drawing.Color.White;
            this.xrRichText2.Font = new System.Drawing.Font("Arial", 9F);
            this.xrRichText2.Location = new System.Drawing.Point(1, 708);
            this.xrRichText2.Name = "xrRichText2";
            this.xrRichText2.ParentStyleUsing.UseBackColor = false;
            this.xrRichText2.ParentStyleUsing.UseBorderColor = false;
            this.xrRichText2.ParentStyleUsing.UseBorders = false;
            this.xrRichText2.ParentStyleUsing.UseBorderWidth = false;
            this.xrRichText2.ParentStyleUsing.UseFont = false;
            this.xrRichText2.ParentStyleUsing.UseForeColor = false;
            this.xrRichText2.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichText2.RtfText")));
            this.xrRichText2.Size = new System.Drawing.Size(733, 59);
            // 
            // xrLine3
            // 
            this.xrLine3.ForeColor = System.Drawing.Color.Black;
            this.xrLine3.Location = new System.Drawing.Point(0, 758);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.ParentStyleUsing.UseBackColor = false;
            this.xrLine3.ParentStyleUsing.UseBorderColor = false;
            this.xrLine3.ParentStyleUsing.UseBorders = false;
            this.xrLine3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine3.ParentStyleUsing.UseFont = false;
            this.xrLine3.ParentStyleUsing.UseForeColor = false;
            this.xrLine3.Size = new System.Drawing.Size(730, 3);
            // 
            // xrLine2
            // 
            this.xrLine2.ForeColor = System.Drawing.Color.Black;
            this.xrLine2.Location = new System.Drawing.Point(0, 683);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.ParentStyleUsing.UseBackColor = false;
            this.xrLine2.ParentStyleUsing.UseBorderColor = false;
            this.xrLine2.ParentStyleUsing.UseBorders = false;
            this.xrLine2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine2.ParentStyleUsing.UseFont = false;
            this.xrLine2.ParentStyleUsing.UseForeColor = false;
            this.xrLine2.Size = new System.Drawing.Size(730, 3);
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(0, 692);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(183, 14);
            this.xrLabel3.Text = "Rechtsmittelbelehrung";
            // 
            // xrRichText1
            // 
            this.xrRichText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.xrRichText1.Location = new System.Drawing.Point(0, 33);
            this.xrRichText1.Name = "xrRichText1";
            this.xrRichText1.ParentStyleUsing.UseFont = false;
            this.xrRichText1.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichText1.RtfText")));
            this.xrRichText1.Size = new System.Drawing.Size(100, 25);
            // 
            // rtfHinweis
            // 
            this.rtfHinweis.BackColor = System.Drawing.Color.White;
            this.rtfHinweis.Font = new System.Drawing.Font("Arial", 9F);
            this.rtfHinweis.Location = new System.Drawing.Point(1, 433);
            this.rtfHinweis.Name = "rtfHinweis";
            this.rtfHinweis.ParentStyleUsing.UseBackColor = false;
            this.rtfHinweis.ParentStyleUsing.UseBorderColor = false;
            this.rtfHinweis.ParentStyleUsing.UseBorders = false;
            this.rtfHinweis.ParentStyleUsing.UseBorderWidth = false;
            this.rtfHinweis.ParentStyleUsing.UseFont = false;
            this.rtfHinweis.ParentStyleUsing.UseForeColor = false;
            this.rtfHinweis.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("rtfHinweis.RtfText")));
            this.rtfHinweis.Size = new System.Drawing.Size(733, 50);
            // 
            // xrRichTextBox1
            // 
            this.xrRichTextBox1.BackColor = System.Drawing.Color.White;
            this.xrRichTextBox1.CanShrink = true;
            this.xrRichTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrRichTextBox1.Location = new System.Drawing.Point(0, 92);
            this.xrRichTextBox1.Name = "xrRichTextBox1";
            this.xrRichTextBox1.ParentStyleUsing.UseBackColor = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorderColor = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorders = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorderWidth = false;
            this.xrRichTextBox1.ParentStyleUsing.UseFont = false;
            this.xrRichTextBox1.ParentStyleUsing.UseForeColor = false;
            this.xrRichTextBox1.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichTextBox1.RtfText")));
            this.xrRichTextBox1.Size = new System.Drawing.Size(213, 58);
            // 
            // xrPanel1
            // 
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageInfo1});
            this.xrPanel1.Location = new System.Drawing.Point(0, 575);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.ParentStyleUsing.UseBorders = false;
            this.xrPanel1.Size = new System.Drawing.Size(175, 42);
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.Location = new System.Drawing.Point(315, 550);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseBackColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorders = false;
            this.xrLabel2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.ParentStyleUsing.UseForeColor = false;
            this.xrLabel2.Size = new System.Drawing.Size(158, 15);
            this.xrLabel2.Text = "Empfangsbestätigung";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BemerkungRTF", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel1.Location = new System.Drawing.Point(1, 508);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 2, 100F);
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(729, 35);
            this.xrLabel1.Text = "xrLabel1";
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine1.Location = new System.Drawing.Point(369, 325);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(4, 53);
            // 
            // ShFinanzplanverfuegung_EinAus
            // 
            this.ShFinanzplanverfuegung_EinAus.Location = new System.Drawing.Point(0, 301);
            this.ShFinanzplanverfuegung_EinAus.Name = "ShFinanzplanverfuegung_EinAus";
            // 
            // ShFinanzplanverfuegung_Personen
            // 
            this.ShFinanzplanverfuegung_Personen.Location = new System.Drawing.Point(0, 208);
            this.ShFinanzplanverfuegung_Personen.Name = "ShFinanzplanverfuegung_Personen";
            // 
            // txtFehlbetrag
            // 
            this.txtFehlbetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Fehlbetrag", "{0:n2}")});
            this.txtFehlbetrag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.txtFehlbetrag.ForeColor = System.Drawing.Color.Black;
            this.txtFehlbetrag.Location = new System.Drawing.Point(625, 383);
            this.txtFehlbetrag.Multiline = true;
            this.txtFehlbetrag.Name = "txtFehlbetrag";
            this.txtFehlbetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtFehlbetrag.ParentStyleUsing.UseBackColor = false;
            this.txtFehlbetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtFehlbetrag.ParentStyleUsing.UseBorders = false;
            this.txtFehlbetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtFehlbetrag.ParentStyleUsing.UseFont = false;
            this.txtFehlbetrag.ParentStyleUsing.UseForeColor = false;
            this.txtFehlbetrag.Size = new System.Drawing.Size(100, 15);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtFehlbetrag.Summary = xrSummary1;
            this.txtFehlbetrag.Text = "Fehlbetrag";
            this.txtFehlbetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label25
            // 
            this.Label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Label25.ForeColor = System.Drawing.Color.Black;
            this.Label25.Location = new System.Drawing.Point(382, 383);
            this.Label25.Name = "Label25";
            this.Label25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label25.ParentStyleUsing.UseBackColor = false;
            this.Label25.ParentStyleUsing.UseBorderColor = false;
            this.Label25.ParentStyleUsing.UseBorders = false;
            this.Label25.ParentStyleUsing.UseBorderWidth = false;
            this.Label25.ParentStyleUsing.UseFont = false;
            this.Label25.ParentStyleUsing.UseForeColor = false;
            this.Label25.Size = new System.Drawing.Size(241, 17);
            this.Label25.Text = "Fehlbetrag";
            // 
            // Label24
            // 
            this.Label24.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Label24.ForeColor = System.Drawing.Color.Black;
            this.Label24.Location = new System.Drawing.Point(382, 351);
            this.Label24.Name = "Label24";
            this.Label24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label24.ParentStyleUsing.UseBackColor = false;
            this.Label24.ParentStyleUsing.UseBorderColor = false;
            this.Label24.ParentStyleUsing.UseBorders = false;
            this.Label24.ParentStyleUsing.UseBorderWidth = false;
            this.Label24.ParentStyleUsing.UseFont = false;
            this.Label24.ParentStyleUsing.UseForeColor = false;
            this.Label24.Size = new System.Drawing.Size(241, 16);
            this.Label24.Text = "Total Ausgaben";
            // 
            // Label23
            // 
            this.Label23.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Label23.ForeColor = System.Drawing.Color.Black;
            this.Label23.Location = new System.Drawing.Point(1, 351);
            this.Label23.Name = "Label23";
            this.Label23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label23.ParentStyleUsing.UseBackColor = false;
            this.Label23.ParentStyleUsing.UseBorderColor = false;
            this.Label23.ParentStyleUsing.UseBorders = false;
            this.Label23.ParentStyleUsing.UseBorderWidth = false;
            this.Label23.ParentStyleUsing.UseFont = false;
            this.Label23.ParentStyleUsing.UseForeColor = false;
            this.Label23.Size = new System.Drawing.Size(258, 16);
            this.Label23.Text = "Total Einnahmen";
            // 
            // txtTotOut
            // 
            this.txtTotOut.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TotOut", "{0:n2}")});
            this.txtTotOut.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtTotOut.ForeColor = System.Drawing.Color.Black;
            this.txtTotOut.Location = new System.Drawing.Point(625, 351);
            this.txtTotOut.Multiline = true;
            this.txtTotOut.Name = "txtTotOut";
            this.txtTotOut.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTotOut.ParentStyleUsing.UseBackColor = false;
            this.txtTotOut.ParentStyleUsing.UseBorderColor = false;
            this.txtTotOut.ParentStyleUsing.UseBorders = false;
            this.txtTotOut.ParentStyleUsing.UseBorderWidth = false;
            this.txtTotOut.ParentStyleUsing.UseFont = false;
            this.txtTotOut.ParentStyleUsing.UseForeColor = false;
            this.txtTotOut.Size = new System.Drawing.Size(100, 16);
            xrSummary2.FormatString = "{0:#,##0.00}";
            this.txtTotOut.Summary = xrSummary2;
            this.txtTotOut.Text = "TotOut";
            this.txtTotOut.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtTotIn
            // 
            this.txtTotIn.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TotIn", "{0:n2}")});
            this.txtTotIn.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtTotIn.ForeColor = System.Drawing.Color.Black;
            this.txtTotIn.Location = new System.Drawing.Point(261, 351);
            this.txtTotIn.Multiline = true;
            this.txtTotIn.Name = "txtTotIn";
            this.txtTotIn.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTotIn.ParentStyleUsing.UseBackColor = false;
            this.txtTotIn.ParentStyleUsing.UseBorderColor = false;
            this.txtTotIn.ParentStyleUsing.UseBorders = false;
            this.txtTotIn.ParentStyleUsing.UseBorderWidth = false;
            this.txtTotIn.ParentStyleUsing.UseFont = false;
            this.txtTotIn.ParentStyleUsing.UseForeColor = false;
            this.txtTotIn.Size = new System.Drawing.Size(100, 16);
            xrSummary3.FormatString = "{0:#,##0.00}";
            this.txtTotIn.Summary = xrSummary3;
            this.txtTotIn.Text = "TotIn";
            this.txtTotIn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line13
            // 
            this.Line13.ForeColor = System.Drawing.Color.Black;
            this.Line13.Location = new System.Drawing.Point(1, 374);
            this.Line13.Name = "Line13";
            this.Line13.ParentStyleUsing.UseBackColor = false;
            this.Line13.ParentStyleUsing.UseBorderColor = false;
            this.Line13.ParentStyleUsing.UseBorders = false;
            this.Line13.ParentStyleUsing.UseBorderWidth = false;
            this.Line13.ParentStyleUsing.UseFont = false;
            this.Line13.ParentStyleUsing.UseForeColor = false;
            this.Line13.Size = new System.Drawing.Size(730, 2);
            // 
            // Line12
            // 
            this.Line12.ForeColor = System.Drawing.Color.Black;
            this.Line12.Location = new System.Drawing.Point(1, 344);
            this.Line12.Name = "Line12";
            this.Line12.ParentStyleUsing.UseBackColor = false;
            this.Line12.ParentStyleUsing.UseBorderColor = false;
            this.Line12.ParentStyleUsing.UseBorders = false;
            this.Line12.ParentStyleUsing.UseBorderWidth = false;
            this.Line12.ParentStyleUsing.UseFont = false;
            this.Line12.ParentStyleUsing.UseForeColor = false;
            this.Line12.Size = new System.Drawing.Size(730, 2);
            // 
            // Line11
            // 
            this.Line11.ForeColor = System.Drawing.Color.Black;
            this.Line11.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line11.Location = new System.Drawing.Point(369, 274);
            this.Line11.Name = "Line11";
            this.Line11.ParentStyleUsing.UseBackColor = false;
            this.Line11.ParentStyleUsing.UseBorderColor = false;
            this.Line11.ParentStyleUsing.UseBorders = false;
            this.Line11.ParentStyleUsing.UseBorderWidth = false;
            this.Line11.ParentStyleUsing.UseFont = false;
            this.Line11.ParentStyleUsing.UseForeColor = false;
            this.Line11.Size = new System.Drawing.Size(4, 33);
            // 
            // Line10
            // 
            this.Line10.ForeColor = System.Drawing.Color.Black;
            this.Line10.Location = new System.Drawing.Point(1, 294);
            this.Line10.Name = "Line10";
            this.Line10.ParentStyleUsing.UseBackColor = false;
            this.Line10.ParentStyleUsing.UseBorderColor = false;
            this.Line10.ParentStyleUsing.UseBorders = false;
            this.Line10.ParentStyleUsing.UseBorderWidth = false;
            this.Line10.ParentStyleUsing.UseFont = false;
            this.Line10.ParentStyleUsing.UseForeColor = false;
            this.Line10.Size = new System.Drawing.Size(730, 2);
            // 
            // Label12
            // 
            this.Label12.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(382, 274);
            this.Label12.Name = "Label12";
            this.Label12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label12.ParentStyleUsing.UseBackColor = false;
            this.Label12.ParentStyleUsing.UseBorderColor = false;
            this.Label12.ParentStyleUsing.UseBorders = false;
            this.Label12.ParentStyleUsing.UseBorderWidth = false;
            this.Label12.ParentStyleUsing.UseFont = false;
            this.Label12.ParentStyleUsing.UseForeColor = false;
            this.Label12.Size = new System.Drawing.Size(191, 15);
            this.Label12.Text = "Ausgaben";
            // 
            // Label11
            // 
            this.Label11.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(1, 274);
            this.Label11.Name = "Label11";
            this.Label11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label11.ParentStyleUsing.UseBackColor = false;
            this.Label11.ParentStyleUsing.UseBorderColor = false;
            this.Label11.ParentStyleUsing.UseBorders = false;
            this.Label11.ParentStyleUsing.UseBorderWidth = false;
            this.Label11.ParentStyleUsing.UseFont = false;
            this.Label11.ParentStyleUsing.UseForeColor = false;
            this.Label11.Size = new System.Drawing.Size(263, 15);
            this.Label11.Text = "Einnahmen";
            // 
            // txtAnrede
            // 
            this.txtAnrede.CanGrow = false;
            this.txtAnrede.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Adresse", "")});
            this.txtAnrede.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtAnrede.ForeColor = System.Drawing.Color.Black;
            this.txtAnrede.Location = new System.Drawing.Point(375, 83);
            this.txtAnrede.Multiline = true;
            this.txtAnrede.Name = "txtAnrede";
            this.txtAnrede.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtAnrede.ParentStyleUsing.UseBackColor = false;
            this.txtAnrede.ParentStyleUsing.UseBorderColor = false;
            this.txtAnrede.ParentStyleUsing.UseBorders = false;
            this.txtAnrede.ParentStyleUsing.UseBorderWidth = false;
            this.txtAnrede.ParentStyleUsing.UseFont = false;
            this.txtAnrede.ParentStyleUsing.UseForeColor = false;
            this.txtAnrede.Size = new System.Drawing.Size(308, 92);
            this.txtAnrede.Text = "Anrede";
            // 
            // Line7
            // 
            this.Line7.ForeColor = System.Drawing.Color.Black;
            this.Line7.Location = new System.Drawing.Point(0, 483);
            this.Line7.Name = "Line7";
            this.Line7.ParentStyleUsing.UseBackColor = false;
            this.Line7.ParentStyleUsing.UseBorderColor = false;
            this.Line7.ParentStyleUsing.UseBorders = false;
            this.Line7.ParentStyleUsing.UseBorderWidth = false;
            this.Line7.ParentStyleUsing.UseFont = false;
            this.Line7.ParentStyleUsing.UseForeColor = false;
            this.Line7.Size = new System.Drawing.Size(730, 3);
            // 
            // Line6
            // 
            this.Line6.ForeColor = System.Drawing.Color.Black;
            this.Line6.Location = new System.Drawing.Point(1, 408);
            this.Line6.Name = "Line6";
            this.Line6.ParentStyleUsing.UseBackColor = false;
            this.Line6.ParentStyleUsing.UseBorderColor = false;
            this.Line6.ParentStyleUsing.UseBorders = false;
            this.Line6.ParentStyleUsing.UseBorderWidth = false;
            this.Line6.ParentStyleUsing.UseFont = false;
            this.Line6.ParentStyleUsing.UseForeColor = false;
            this.Line6.Size = new System.Drawing.Size(730, 2);
            // 
            // Line4
            // 
            this.Line4.ForeColor = System.Drawing.Color.Black;
            this.Line4.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.Line4.Location = new System.Drawing.Point(315, 658);
            this.Line4.Name = "Line4";
            this.Line4.ParentStyleUsing.UseBackColor = false;
            this.Line4.ParentStyleUsing.UseBorderColor = false;
            this.Line4.ParentStyleUsing.UseBorders = false;
            this.Line4.ParentStyleUsing.UseBorderWidth = false;
            this.Line4.ParentStyleUsing.UseFont = false;
            this.Line4.ParentStyleUsing.UseForeColor = false;
            this.Line4.Size = new System.Drawing.Size(244, 2);
            // 
            // Label9
            // 
            this.Label9.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(315, 667);
            this.Label9.Name = "Label9";
            this.Label9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label9.ParentStyleUsing.UseBackColor = false;
            this.Label9.ParentStyleUsing.UseBorderColor = false;
            this.Label9.ParentStyleUsing.UseBorders = false;
            this.Label9.ParentStyleUsing.UseBorderWidth = false;
            this.Label9.ParentStyleUsing.UseFont = false;
            this.Label9.ParentStyleUsing.UseForeColor = false;
            this.Label9.Size = new System.Drawing.Size(244, 14);
            this.Label9.Text = "Der/Die Sozialhilfebezüger/in";
            // 
            // Line3
            // 
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.Line3.Location = new System.Drawing.Point(315, 608);
            this.Line3.Name = "Line3";
            this.Line3.ParentStyleUsing.UseBackColor = false;
            this.Line3.ParentStyleUsing.UseBorderColor = false;
            this.Line3.ParentStyleUsing.UseBorders = false;
            this.Line3.ParentStyleUsing.UseBorderWidth = false;
            this.Line3.ParentStyleUsing.UseFont = false;
            this.Line3.ParentStyleUsing.UseForeColor = false;
            this.Line3.Size = new System.Drawing.Size(244, 2);
            // 
            // Label8
            // 
            this.Label8.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(315, 617);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(244, 14);
            this.Label8.Text = "Ort und Datum";
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.Line2.Location = new System.Drawing.Point(1, 658);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(244, 2);
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(1, 667);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(244, 14);
            this.Label7.Text = "Für den Sozialdienst";
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.Line1.Location = new System.Drawing.Point(1, 608);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(244, 2);
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(1, 617);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(244, 14);
            this.Label6.Text = "Ort und Datum";
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(1, 550);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(158, 15);
            this.Label5.Text = "Sozialhilfe bewilligt";
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(1, 492);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(158, 14);
            this.Label4.Text = "Bemerkungen";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(1, 417);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(158, 14);
            this.Label3.Text = "Hinweis";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(1, 249);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(158, 14);
            this.Label2.Text = "Budgetübersicht";
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.Silver;
            this.txtTitle.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Title", "")});
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtTitle.ForeColor = System.Drawing.Color.Black;
            this.txtTitle.Location = new System.Drawing.Point(0, 183);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTitle.ParentStyleUsing.UseBackColor = false;
            this.txtTitle.ParentStyleUsing.UseBorderColor = false;
            this.txtTitle.ParentStyleUsing.UseBorders = false;
            this.txtTitle.ParentStyleUsing.UseBorderWidth = false;
            this.txtTitle.ParentStyleUsing.UseFont = false;
            this.txtTitle.ParentStyleUsing.UseForeColor = false;
            this.txtTitle.Size = new System.Drawing.Size(730, 24);
            this.txtTitle.Text = "Title";
            this.txtTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrPageInfo1.Format = "Zollikofen, {0}";
            this.xrPageInfo1.KeepTogether = false;
            this.xrPageInfo1.Location = new System.Drawing.Point(0, 17);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(167, 19);
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 9F);
            this.xrPageInfo2.Format = "Seite {0} von {1}";
            this.xrPageInfo2.Location = new System.Drawing.Point(333, 0);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            this.xrPageInfo2.Scripts.OnPrintOnPage = resources.GetString("xrPageInfo2.Scripts.OnPrintOnPage");
            this.xrPageInfo2.Size = new System.Drawing.Size(100, 17);
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail,
                        this.PageFooter});
            this.DataSource = this.sqlQuery1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(55, 37, 80, 40);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtfHinweis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' , ParameterXML =  N'<?xml version="1.0" standalone="yes" ?>
<NewDataSet>
	<Table>
		<FieldName>label</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Finanzplan ID:</DisplayText>
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
		<FieldName>BgFinanzPlanID</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>Finanzplan ID</DisplayText>
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
</NewDataSet>' , SQLquery =  N'DECLARE @BgBudgetID  int,
        @GetDate     datetime
SELECT @BgBudgetID = BgBudgetID, @GetDate = GetDate()
FROM BgBudget
WHERE BgFinanzPlanID = {BgFinanzPlanID} AND MasterBudget = 1


DECLARE @TotIn money
DECLARE @TotOut money

SELECT @TotIn = SUM(Betrag)
FROM dbo.fnWhGetFinanzplan(@BgBudgetID, @GetDate)  TMP
  INNER JOIN XLOVCode  XPC ON XPC.LOVName = ''BgKategorie'' AND XPC.Code = TMP.BgKategorieCode
WHERE BgKategorieCode = 1

SELECT @TotOut = SUM(CASE WHEN BgKategorieCode = 2 THEN TMP.Betrag ELSE -TMP.Betrag END)
FROM dbo.fnWhGetFinanzplan(@BgBudgetID, @GetDate)  TMP
  INNER JOIN XLOVCode  XPC ON XPC.LOVName = ''BgKategorie'' AND XPC.Code = TMP.BgKategorieCode
WHERE BgKategorieCode IN (2, 4)


DECLARE @BemerkungRTF varchar(8000),
        @ItemText     varchar(8000)

DECLARE cBemerkungRTF CURSOR FAST_FORWARD FOR
  SELECT ''- '' + XLC.Text + '' ('' + PRS.NameVorname + ''): '' + Convert(varchar(2000), BPO.Bemerkung)
  FROM BgPosition             BPO
    INNER JOIN vwPerson      PRS ON PRS.BaPersonID = BPO.BaPersonID
    INNER JOIN BgPositionsart  SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
    INNER JOIN XLOVCode       XLC ON XLC.LOVName = ''BgGruppe'' AND XLC.Code = SPT.BgGruppeCode
  WHERE BPO.BgBudgetID = @BgBudgetID
    AND SPT.BgPositionsartCode BETWEEN 39000 AND 39999
    AND NOT (BPO.Bemerkung IS NULL OR Convert(varchar, BPO.Bemerkung) = '''')
    AND GetDate() BETWEEN IsNull(BPO.DatumVon, ''19000101'') AND IsNull(BPO.DatumBis, GetDate())
  ORDER BY PRS.NameVorname

OPEN cBemerkungRTF
WHILE (1 = 1) BEGIN
  FETCH NEXT FROM cBemerkungRTF INTO @ItemText
  IF @@FETCH_STATUS != 0 BREAK

  SET @BemerkungRTF = IsNull(@BemerkungRTF + char(10) + char(13), '''') + @ItemText
END
CLOSE cBemerkungRTF
DEALLOCATE cBemerkungRTF



SELECT BBG.BgBudgetID,
       Title        = ''Verfügung vom '' + IsNull(CONVERT(varchar, (SELECT MAX(Datum) FROM BgBewilligung BBW
                                                                  WHERE BBW.BgFinanzPlanID=SFP.BgFinanzPlanID AND BBW.BgBewilligungCode = 2), 104), ''???'') +
                      '': Sozialhilfe vom '' + CONVERT(varchar, SFP.DatumVon, 104) + '' bis '' + CONVERT(varchar, SFP.DatumBis, 104),
       Adresse      = IsNull(CASE PRS.GeschlechtCode WHEN 1 THEN ''Herr'' WHEN 2 THEN ''Frau'' END + char(13) + char(10),'''') +
                      PRS.VornameName + char(13) + char(10) +
                      PRS.WohnsitzStrasseHausNr + char(13) + char(10) +
                      PRS.WohnsitzPLZOrt,
       BemerkungRTF = IsNull(CONVERT(varchar(8000), SFP.Bemerkung) + char(10) + char(13), '''') + IsNull(@BemerkungRTF, ''''),
       TotIn        = IsNull(@TotIn, $0.00),
       TotOut       = IsNull(@TotOut, $0.00),
       Fehlbetrag   = IsNull(@TotOut, $0.00) - IsNull(@TotIn, $0.00)
FROM   BgBudget BBG
       INNER JOIN BgFinanzPlan  SFP on SFP.BgFinanzPlanID = BBG.BgFinanzPlanID
       INNER JOIN FaLeistung    FAL on FAL.FaLeistungID = SFP.FaLeistungID
       INNER JOIN vwPerson      PRS on PRS.BaPersonID = FAL.BaPersonID
WHERE FAL.ModulID = 3 AND BBG.BgBudgetID = @BgBudgetID
  AND SFP.BgBewilligungStatusCode in (5, 9) -- nur bewilligte' , ContextForms =  N'WhFinanzplan,CtlBgUebersicht,WhMonatsbudget,WhMasterbudget' , ParentReportName =  null , ReportSortKey = 3, System =  0 
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'ShFinanzplanverfuegung' ;


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'ShFinanzplanverfuegung_EinAus' ,  N'Einnahmen, Ausgaben' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Temp\KiSS 4.1.48\KiSS4.DB.dll" />
///     <Reference Path="C:\Temp\KiSS 4.1.48\SharpLibrary.dll" />
///     <Reference Path="C:\Temp\KiSS 4.1.48\log4net.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
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
                        "AAAAcgMREVDTEFSRSBAQmdCdWRnZXRJRCAgaW50LA0KICAgICAgICBAR2V0RGF0ZSAgICAgZGF0ZXRpb" +
                        "WUNClNFTEVDVCBAQmdCdWRnZXRJRCA9IEJnQnVkZ2V0SUQsIEBHZXREYXRlID0gR2V0RGF0ZSgpDQpGU" +
                        "k9NIEJnQnVkZ2V0DQpXSEVSRSBCZ0ZpbmFuelBsYW5JRCA9IG51bGwNCkFORCBNYXN0ZXJCdWRnZXQgP" +
                        "SAxDQoNCkRFQ0xBUkUgQEVpbm5haG1lbiBUQUJMRSAoaWQgaW50IGlkZW50aXR5LCBUZXh0IHZhcmNoY" +
                        "XIoMTAwKSwgQmV0cmFnIG1vbmV5KQ0KREVDTEFSRSBAQXVzZ2FiZW4gIFRBQkxFIChpZCBpbnQgaWRlb" +
                        "nRpdHksIFRleHQgdmFyY2hhcigxMDApLCBCZXRyYWcgbW9uZXkpDQoNCi0tIEVpbm5haG1lbg0KSU5TR" +
                        "VJUIElOVE8gQEVpbm5haG1lbiAoVGV4dCwgQmV0cmFnKQ0KICBTRUxFQ1QgVE1QLkJlemVpY2hudW5nL" +
                        "CBUTVAuQmV0cmFnDQogIEZST00gZGJvLmZuV2hHZXRGaW5hbnpwbGFuKEBCZ0J1ZGdldElELCBAR2V0R" +
                        "GF0ZSkgIFRNUA0KICAgIElOTkVSIEpPSU4gWExPVkNvZGUgICAgIFhQQyBPTiBYUEMuTE9WTmFtZSA9I" +
                        "CdCZ0thdGVnb3JpZScgICAgQU5EIFhQQy5Db2RlID0gVE1QLkJnS2F0ZWdvcmllQ29kZQ0KICBXSEVSR" +
                        "SBCZ0thdGVnb3JpZUNvZGUgPSAxDQogICAgQU5EIChUTVAuQmV0cmFnICE9ICQwLjAwIE9SIChCZ0thd" +
                        "GVnb3JpZUNvZGUgPSAxIEFORCBCZ0dydXBwZUNvZGUgTElLRSAnWzAtOV0lJykpDQoNCi0tIEF1c2dhY" +
                        "mVuIC8gS8O8cnp1bmdlbg0KSU5TRVJUIElOVE8gQEF1c2dhYmVuIChUZXh0LCBCZXRyYWcpDQogIFNFT" +
                        "EVDVA0KICAgIENBU0UNCiAgICAgIFdIRU4gVE1QLkJlemVpY2hudW5nIExJS0UgJ01lZC4gR3J1bmQlK" +
                        "EtWRyknIFRIRU4gJ0tWRyBQcsOkbWllbicNCiAgICAgIFdIRU4gVE1QLkJlemVpY2hudW5nIExJS0UgJ" +
                        "01lZC4gR3J1bmQlKFZWRyknIFRIRU4gJ1ZWRyBQcsOkbWllbicNCiAgICAgIEVMU0UgVE1QLkJlemVpY" +
                        "2hudW5nDQogICAgRU5ELA0KICAgIENBU0UNCiAgICAgIFdIRU4gQmdLYXRlZ29yaWVDb2RlID0gMiBUS" +
                        "EVOIFRNUC5CZXRyYWcNCiAgICAgIEVMU0UgLVRNUC5CZXRyYWcNCiAgICBFTkQNCiAgRlJPTSBkYm8uZ" +
                        "m5XaEdldEZpbmFuenBsYW4oQEJnQnVkZ2V0SUQsIEBHZXREYXRlKSAgVE1QDQogICAgSU5ORVIgSk9JT" +
                        "iBYTE9WQ29kZSAgICAgWFBDIE9OIFhQQy5MT1ZOYW1lID0gJ0JnS2F0ZWdvcmllJyAgICBBTkQgWFBDL" +
                        "kNvZGUgPSBUTVAuQmdLYXRlZ29yaWVDb2RlDQogIFdIRVJFIEJnS2F0ZWdvcmllQ29kZSBJTiAoMiwgN" +
                        "CkgLS0gQXVzZ2FiZW4gLyBLw7xyenVuZ2VuDQogICAgQU5EIChUTVAuQmV0cmFnICE9ICQwLjAwIE9SI" +
                        "ChCZ0thdGVnb3JpZUNvZGUgPSAyIEFORCBCZ0dydXBwZUNvZGUgTElLRSAnWzAtOV0lJykpDQogICAgQ" +
                        "U5EIFRNUC5CZ0dydXBwZUNvZGUgTk9UIElOICgzOTA1LCAzOTAzKQ0KDQpTRUxFQ1QNCiAgVGV4dEVpb" +
                        "iA9IExUUklNKEVJTi5UZXh0KSwgQmV0cmFnRWluID0gRUlOLkJldHJhZywNCiAgVGV4dEF1cyA9IExUU" +
                        "klNKEFVUy5UZXh0KSwgQmV0cmFnQXVzID0gQVVTLkJldHJhZw0KRlJPTSBARWlubmFobWVuICAgICAgI" +
                        "CAgRUlODQogIEZVTEwgIEpPSU4gQEF1c2dhYmVuICBBVVMgT04gQVVTLmlkID0gRUlOLmlk";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLine1,
                        this.xrLabel4,
                        this.xrLabel3,
                        this.xrLabel2,
                        this.xrLabel1});
            this.Detail.Height = 18;
            this.Detail.Name = "Detail";
            this.Detail.Scripts.OnBeforePrint = "private void OnBeforePrint(object sender, System.Drawing.Printing.PrintEventArgs " +
                "e) {\r\n  //xrLine1.Height = Detail.Height = 444;\r\n}";
            // 
            // xrLine1
            // 
            this.xrLine1.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine1.Location = new System.Drawing.Point(367, 0);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(8, 18);
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragAus", "{0:n2}")});
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel4.Location = new System.Drawing.Point(633, 0);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(89, 18);
            this.xrLabel4.Text = "xrLabel2";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TextAus", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel3.Location = new System.Drawing.Point(383, 0);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(246, 18);
            this.xrLabel3.Text = "xrLabel1";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragEin", "{0:n2}")});
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel2.Location = new System.Drawing.Point(283, 0);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(76, 18);
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TextEin", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel1.Location = new System.Drawing.Point(0, 0);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(275, 18);
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
            this.Margins = new System.Drawing.Printing.Margins(100, 16, 100, 100);
            this.Name = "Report";
            this.PageHeight = 1100;
            this.PageWidth = 850;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'DECLARE @BgBudgetID  int,
        @GetDate     datetime
SELECT @BgBudgetID = BgBudgetID, @GetDate = GetDate()
FROM BgBudget
WHERE BgFinanzPlanID = {BgFinanzPlanID}
AND MasterBudget = 1

DECLARE @Einnahmen TABLE (id int identity, Text varchar(100), Betrag money)
DECLARE @Ausgaben  TABLE (id int identity, Text varchar(100), Betrag money)

-- Einnahmen
INSERT INTO @Einnahmen (Text, Betrag)
  SELECT TMP.Bezeichnung, TMP.Betrag
  FROM dbo.fnWhGetFinanzplan(@BgBudgetID, @GetDate)  TMP
    INNER JOIN XLOVCode     XPC ON XPC.LOVName = ''BgKategorie''    AND XPC.Code = TMP.BgKategorieCode
  WHERE BgKategorieCode = 1
    AND (TMP.Betrag != $0.00 OR (BgKategorieCode = 1 AND BgGruppeCode LIKE ''[0-9]%''))

-- Ausgaben / Kürzungen
INSERT INTO @Ausgaben (Text, Betrag)
  SELECT
    CASE
      WHEN TMP.Bezeichnung LIKE ''%Med. Grundvers%'' THEN ''KVG Prämien''
      WHEN TMP.Bezeichnung LIKE ''%Therapie%'' THEN ''Therapie- und Entzugsmassnahmen''
      ELSE TMP.Bezeichnung
    END + ISNULL((CASE WHEN tmp.info LIKE ''%VVG%'' THEN IsNull('', davon '' + tmp.info, '''') END), ''''),
    CASE
      WHEN BgKategorieCode = 2 THEN TMP.Betrag
      ELSE -TMP.Betrag
    END
  FROM dbo.fnWhGetFinanzplan(@BgBudgetID, @GetDate)  TMP
    INNER JOIN XLOVCode     XPC ON XPC.LOVName = ''BgKategorie''    AND XPC.Code = TMP.BgKategorieCode
  WHERE BgKategorieCode IN (2, 4) -- Ausgaben / Kürzungen
    AND (TMP.Betrag != $0.00 OR (BgKategorieCode = 2 AND BgGruppeCode LIKE ''[0-9]%''))

SELECT
  TextEin = LTRIM(EIN.Text), BetragEin = EIN.Betrag,
  TextAus = LTRIM(AUS.Text), BetragAus = AUS.Betrag
FROM @Einnahmen         EIN
  FULL  JOIN @Ausgaben  AUS ON AUS.id = EIN.id' ,  null ,  N'ShFinanzplanverfuegung' ,  null ,  1 );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'ShFinanzplanverfuegung_Personen' ,  N'Personen' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Temp\KiSS 4.1.48\KiSS4.DB.dll" />
///     <Reference Path="C:\Temp\KiSS 4.1.48\SharpLibrary.dll" />
///     <Reference Path="C:\Temp\KiSS 4.1.48\log4net.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtHeimatort;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtGebDat;
        private DevExpress.XtraReports.UI.XRLabel txtName;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = @"zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OSNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kAAAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAAAAAAZECU0VMRUNUDQogIE5hbWUgICAgICAgICAgICAgID0gUFJTLk5hbWVWb3JuYW1lLA0KICBQUlMuR2VidXJ0c2RhdHVtLA0KICBOYXRpb25hbGl0YWV0ICAgICA9IFBSUy5OYXRpb25hbGl0YWV0DQpGUk9NIEJnRmluYW56UGxhbl9CYVBlcnNvbiAgIFNQUA0KICBJTk5FUiBKT0lOIHZ3UGVyc29uICAgICAgICBQUlMgT04gUFJTLkJhUGVyc29uSUQgPSBTUFAuQmFQZXJzb25JRA0KV0hFUkUgU1BQLkJnRmluYW56UGxhbklEID0gbnVsbA0KQU5EIFNQUC5Jc3RVbnRlcnN0dWV0enQgPSAx";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.txtHeimatort = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGebDat = new DevExpress.XtraReports.UI.XRLabel();
            this.txtName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtHeimatort,
                        this.txtGebDat,
                        this.txtName});
            this.Detail.Height = 22;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBackColor = false;
            this.Detail.ParentStyleUsing.UseBorderColor = false;
            this.Detail.ParentStyleUsing.UseBorders = false;
            this.Detail.ParentStyleUsing.UseBorderWidth = false;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel4,
                        this.xrLine1,
                        this.xrLabel3,
                        this.xrLabel2,
                        this.xrLabel1});
            this.ReportHeader.Height = 38;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.ParentStyleUsing.UseBackColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorderColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorders = false;
            this.ReportHeader.ParentStyleUsing.UseBorderWidth = false;
            this.ReportHeader.ParentStyleUsing.UseFont = false;
            this.ReportHeader.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Height = 0;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
            this.ReportFooter.Visible = false;
            // 
            // txtHeimatort
            // 
            this.txtHeimatort.CanShrink = true;
            this.txtHeimatort.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Nationalitaet", "")});
            this.txtHeimatort.Font = new System.Drawing.Font("Arial", 9F);
            this.txtHeimatort.ForeColor = System.Drawing.Color.Black;
            this.txtHeimatort.Location = new System.Drawing.Point(417, 0);
            this.txtHeimatort.Multiline = true;
            this.txtHeimatort.Name = "txtHeimatort";
            this.txtHeimatort.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtHeimatort.ParentStyleUsing.UseBackColor = false;
            this.txtHeimatort.ParentStyleUsing.UseBorderColor = false;
            this.txtHeimatort.ParentStyleUsing.UseBorders = false;
            this.txtHeimatort.ParentStyleUsing.UseBorderWidth = false;
            this.txtHeimatort.ParentStyleUsing.UseFont = false;
            this.txtHeimatort.ParentStyleUsing.UseForeColor = false;
            this.txtHeimatort.Size = new System.Drawing.Size(152, 15);
            this.txtHeimatort.Text = "Heimatort";
            // 
            // txtGebDat
            // 
            this.txtGebDat.CanShrink = true;
            this.txtGebDat.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Geburtsdatum", "{0:dd.MM.yyyy}")});
            this.txtGebDat.Font = new System.Drawing.Font("Arial", 9F);
            this.txtGebDat.ForeColor = System.Drawing.Color.Black;
            this.txtGebDat.Location = new System.Drawing.Point(308, 0);
            this.txtGebDat.Multiline = true;
            this.txtGebDat.Name = "txtGebDat";
            this.txtGebDat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGebDat.ParentStyleUsing.UseBackColor = false;
            this.txtGebDat.ParentStyleUsing.UseBorderColor = false;
            this.txtGebDat.ParentStyleUsing.UseBorders = false;
            this.txtGebDat.ParentStyleUsing.UseBorderWidth = false;
            this.txtGebDat.ParentStyleUsing.UseFont = false;
            this.txtGebDat.ParentStyleUsing.UseForeColor = false;
            this.txtGebDat.Size = new System.Drawing.Size(109, 15);
            xrSummary1.FormatString = "{0:dd.MM.yyyy}";
            this.txtGebDat.Summary = xrSummary1;
            this.txtGebDat.Text = "GebDat";
            // 
            // txtName
            // 
            this.txtName.CanShrink = true;
            this.txtName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.txtName.Font = new System.Drawing.Font("Arial", 9F);
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(0, 0);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtName.ParentStyleUsing.UseBackColor = false;
            this.txtName.ParentStyleUsing.UseBorderColor = false;
            this.txtName.ParentStyleUsing.UseBorders = false;
            this.txtName.ParentStyleUsing.UseBorderWidth = false;
            this.txtName.ParentStyleUsing.UseFont = false;
            this.txtName.ParentStyleUsing.UseForeColor = false;
            this.txtName.Size = new System.Drawing.Size(307, 15);
            this.txtName.Text = "Name";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.Location = new System.Drawing.Point(0, 0);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.ParentStyleUsing.UseForeColor = false;
            this.xrLabel4.Size = new System.Drawing.Size(167, 15);
            this.xrLabel4.Text = "Unterstützte Personen";
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.Location = new System.Drawing.Point(0, 33);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(731, 5);
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(417, 17);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(152, 15);
            this.xrLabel3.Text = "Nationalität";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.Location = new System.Drawing.Point(308, 17);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseBackColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorders = false;
            this.xrLabel2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.ParentStyleUsing.UseForeColor = false;
            this.xrLabel2.Size = new System.Drawing.Size(101, 15);
            this.xrLabel2.Text = "Geburtsdatum";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.Location = new System.Drawing.Point(0, 17);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseBackColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.ParentStyleUsing.UseForeColor = false;
            this.xrLabel1.Size = new System.Drawing.Size(307, 15);
            this.xrLabel1.Text = "Name";
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail,
                        this.ReportHeader,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(100, 95, 100, 100);
            this.Name = "Report";
            this.PageHeight = 1268;
            this.PageWidth = 929;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4Extra;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'SELECT
  Name              = PRS.NameVorname,
  PRS.Geburtsdatum,
  Nationalitaet     = PRS.Nationalitaet
FROM BgFinanzPlan_BaPerson   SPP
  INNER JOIN vwPerson        PRS ON PRS.BaPersonID = SPP.BaPersonID
WHERE SPP.BgFinanzPlanID = {BgFinanzPlanID}
AND SPP.IstUnterstuetzt = 1' ,  null ,  N'ShFinanzplanverfuegung' ,  null ,  1 );


