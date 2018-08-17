-- Insert Script for KAAAMBescheinigung
-- MD5:0XDCAE68A9682B2D8D71012F419E47D463_0XE48D3B8F6FB28AB878367F381F1DB5B5_0X10B35C7F8722971CE11DE6E4743760E1
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'KAAAMBescheinigung') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('KAAAMBescheinigung', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'KAAAMBescheinigung';
--SQLCHECK_IGNORE--
UPDATE QRY
SET QueryName =  N'KAAAMBescheinigung' , UserText =  N'KA - AMM-Bescheinigung' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\Kiss.Interfaces.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\FluentValidation.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\log4net.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\Microsoft.Practices.Unity.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\Ionic.Zip.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\Kiss.BusinessLogic.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\Kiss.DbContext.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\EntityFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ComponentModel.DataAnnotations\v4.0_4.0.0.0__31bf3856ad364e35\System.ComponentModel.DataAnnotations.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.CSharp\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.CSharp.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Dynamic\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Dynamic.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\Kiss.DataAccess.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\HtmlAgilityPack.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\Kiss.BL.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\Kiss.Model.dll" />
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
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\KiSS.Common.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\Autofac.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\Common.Logging.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\Kiss.Database.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\WPFLocalizeExtension.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4544\Build\Debug\XAMLMarkupExtensions.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel25;
        private DevExpress.XtraReports.UI.XRLabel xrLabel24;
        private DevExpress.XtraReports.UI.XRLabel xrLabel26;
        private DevExpress.XtraReports.UI.XRLabel xrLabel23;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel lblAMMBesch;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.Subreport KAAMMBescheinigung_AnAbwesenheiten;
        private DevExpress.XtraReports.UI.XRLabel txtBerater;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.Subreport KAAMMBescheinigung_Abbruch;
        private DevExpress.XtraReports.UI.XRPanel pnlFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel lblZustKa;
        private DevExpress.XtraReports.UI.XRPictureBox picUnterschrift;
        private DevExpress.XtraReports.UI.XRLabel txtOrtDatum;
        private DevExpress.XtraReports.UI.XRLabel txtZustKa;
        private DevExpress.XtraReports.UI.XRLabel lblUnterschrift;
        private DevExpress.XtraReports.UI.XRLabel lblOrtDatum;
        private DevExpress.XtraReports.UI.XRLabel lblTitelMassnahme;
        private DevExpress.XtraReports.UI.Subreport KAAMMBescheinigung_Praesenz;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRPanel pnlHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel lblBeschGrad;
        private DevExpress.XtraReports.UI.XRLabel txtBeschGrad;
        private DevExpress.XtraReports.UI.XRLabel lblGebDat;
        private DevExpress.XtraReports.UI.XRLabel txtGebDat;
        private DevExpress.XtraReports.UI.XRLabel lblAHVNr;
        private DevExpress.XtraReports.UI.XRLabel txtAHVNr;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRCheckBox xrCheckBox2;
        private DevExpress.XtraReports.UI.XRCheckBox xrCheckBox1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel lblKursEinsatz;
        private DevExpress.XtraReports.UI.XRLabel txtAdresse;
        private DevExpress.XtraReports.UI.XRLabel txtRAV;
        private DevExpress.XtraReports.UI.XRLabel lblBerater;
        private DevExpress.XtraReports.UI.XRLine xrLine6;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.Subreport KAAMMBescheinigung_AMM;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel lblStrichcode;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox2;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAAGAAAAAQAAAGhTeXN0ZW0uRHJhd" +
                        "2luZy5CaXRtYXAsIFN5c3RlbS5EcmF3aW5nLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhb" +
                        "CwgUHVibGljS2V5VG9rZW49YjAzZjVmN2YxMWQ1MGEzYVBBRFBBROiU3YgTtE6kzRqEp04GIBq/XgFDi" +
                        "IttcAAAAAB6AAAA+wAAANAAAABLAAAAsQAAAHICAABGbABiAGwAUwB0AHIAaQBjAGgAYwBvAGQAZQAuA" +
                        "FMAYwByAGkAcAB0AHMALgBPAG4AQgBlAGYAbwByAGUAUAByAGkAbgB0AAAAAAAqcABpAGMAVQBuAHQAZ" +
                        "QByAHMAYwBoAHIAaQBmAHQALgBJAG0AYQBnAGUA7wAAADJzAHEAbABRAHUAZQByAHkAMQAuAFMAZQBsA" +
                        "GUAYwB0AFMAdABhAHQAZQBtAGUAbgB0APNQAAAaeAByAEwAYQBiAGUAbAAyAC4AVABlAHgAdACnXQAAJ" +
                        "ngAcgBQAGkAYwB0AHUAcgBlAEIAbwB4ADEALgBJAG0AYQBnAGUA/F4AACZ4AHIAUABpAGMAdAB1AHIAZ" +
                        "QBCAG8AeAAyAC4ASQBtAGEAZwBlAIGJAAAB7AFwcml2YXRlIHZvaWQgT25CZWZvcmVQcmludChvYmplY" +
                        "3Qgc2VuZGVyLCBTeXN0ZW0uRHJhd2luZy5QcmludGluZy5QcmludEV2ZW50QXJncyBlKSB7DQoJbGJsU" +
                        "3RyaWNoY29kZS5Gb250ID0gbmV3IFN5c3RlbS5EcmF3aW5nLkZvbnQoS2lTUzQuQ29tbW9uLlJlcG9yd" +
                        "C5SZXBVdGlsLkJhcmNvZGUzOUZvbnRGYW1pbHksIGxibFN0cmljaGNvZGUuRm9udC5TaXplLCBsYmxTd" +
                        "HJpY2hjb2RlLkZvbnQuU3R5bGUpOw0KfUAAAQAAAP////8BAAAAAAAAAAwCAAAAUVN5c3RlbS5EcmF3a" +
                        "W5nLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49YjAzZjVmN" +
                        "2YxMWQ1MGEzYQUBAAAAFVN5c3RlbS5EcmF3aW5nLkJpdG1hcAEAAAAERGF0YQcCAgAAAAkDAAAADwMAA" +
                        "ABhTwAAAv/Y/+AAEEpGSUYAAQEBASwBLAAA/9sAQwAIBgYHBgUIBwcHCQkICgwUDQwLCwwZEhMPFB0aH" +
                        "x4dGhwcICQuJyAiLCMcHCg3KSwwMTQ0NB8nOT04MjwuMzQy/9sAQwEJCQkMCwwYDQ0YMiEcITIyMjIyM" +
                        "jIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIy/8AAEQgBbwPLAwEiAAIRA" +
                        "QMRAf/EAB8AAAEFAQEBAQEBAAAAAAAAAAABAgMEBQYHCAkKC//EALUQAAIBAwMCBAMFBQQEAAABfQECA" +
                        "wAEEQUSITFBBhNRYQcicRQygZGhCCNCscEVUtHwJDNicoIJChYXGBkaJSYnKCkqNDU2Nzg5OkNERUZHS" +
                        "ElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6g4SFhoeIiYqSk5SVlpeYmZqio6Slpqeoqaqys7S1tre4u" +
                        "brCw8TFxsfIycrS09TV1tfY2drh4uPk5ebn6Onq8fLz9PX29/j5+v/EAB8BAAMBAQEBAQEBAQEAAAAAA" +
                        "AABAgMEBQYHCAkKC//EALURAAIBAgQEAwQHBQQEAAECdwABAgMRBAUhMQYSQVEHYXETIjKBCBRCkaGxw" +
                        "QkjM1LwFWJy0QoWJDThJfEXGBkaJicoKSo1Njc4OTpDREVGR0hJSlNUVVZXWFlaY2RlZmdoaWpzdHV2d" +
                        "3h5eoKDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uLj5" +
                        "OXm5+jp6vLz9PX29/j5+v/aAAwDAQACEQMRAD8A9/PSkxz3xS0UAAORRRjnPeigAooooAKKKKACiiigA" +
                        "ooooAKKKKACiikyc4xQAtFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAGecYopMBuSOv" +
                        "qKCcHpnigBaKO9FACHPalooxQAZ5x3ooooAM8470mev54xS0UAIBgdSfrS55xRRQAUUUUAFFFFABRSMS" +
                        "BwKXNABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUU" +
                        "AFFFFABRRRQAUUUUAFFFBGfagAooooAKKKKACiiigApDjrnp2FLRQAUdxRRQAh7gHmgtjqQMdaWjHTPU" +
                        "UAA6c9aKKKACkPBzyfalooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigBCoYglQccgntS0U" +
                        "UAFFFFABRRSfxfh6UALRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFI3TvntilGO1ABRRRQ" +
                        "AUUUUAFFFFABRRRQAUUUUAFFFFABSY57flS0UAMYN2UHI5zS9ic+vQ5p1HegAooooAKKKKACiiigAooo" +
                        "oAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAAMUUUUAFFIOn/ANbFLQAUUUUAFFFFA" +
                        "BRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRVS+vrPTrY3F5cRW8A2gySsEUZOBkn3I4qeNlkjDptZWGQe" +
                        "xzQBJRRTSVAGeB27UAOqN2WNck9MdM9M+lUJLyaW4kitogdgG523AKTnpxg/g3fpVPVHisbFb3UkW6ki" +
                        "kVUWNBlmJwqjP8Ank+lAFHU/Gdta38On2UBu7x3TMKkhhGW5YAA5wAfTHrXVr0JbvzjFZllaSNdm9lY5" +
                        "KGOJFY7VUnPT16c+lagAHQYH0oAWiiigApB0/8ArYpaKACiiigAooooAKaenA79MU6kwMYxwetAC4xRS" +
                        "Y5z/kUtACDp/wDWxS0UUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQA" +
                        "UUUUAFFFFABRRRQAUUUUAFFFFABRRRQAU0EEHg+hB5p1FABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABR" +
                        "RRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABR" +
                        "RRQAUUUUAFFFFABRRRQA0Dr3Gf1p1FFABRRRQAUUUUAFFFFABRRRQAUUUhI59ueKAFpjYHYdz9R3pfqO" +
                        "QSQB3rE8Qao1jbJa2smL65IihCoW2k8biB0Hv26+tAFR7pdf15rCGWU2mnNHLJJGw2ySDkLnqR0PHoR3" +
                        "rpl5zkd6o6RpsOladHbRIuRguyrgO3ALY/DNLeagkH7qN4pLph+7hLgM/PX6UATXEyQDeSMAFzg444ye" +
                        "T0HU1Wthd3H764Ywx54h2jcB23E5/z+VPs4bhXeW+eN5Q5MZQfcXpjp7H86fe3lvp1s9xdTJDCgy7scD" +
                        "H5fpQA68uYLO2e4uZEjjjUlmc44A/z/ACritGMvjTWhrF3Ht0q3JW0ikHEr9zg9QAT+PHaq8xv/AB5rM" +
                        "kMbyW3h+2k2tMpwblu6gDPt7gds5rv7W3htreOKCNUSNAiKoGFX0Ht/hQBMNoXOOvPr706jFFABRRRQA" +
                        "UUUUAFFFFABRRRQAUUUUAFFNAAHcjPcU6gAooBz2ooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKA" +
                        "CiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKA" +
                        "CiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKaxAA3Dr60AOpD07fjQO/POaWgAHHbFFFFA" +
                        "BRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFA" +
                        "Acd6jXcWO5QEAwBjv8A4U/IBPrjmq17dxWFtJdTttiiQsxPoP8AHp+IoAq6zq9vothJcz5yv3VA5dvQH" +
                        "oM8f/X6Vm+HrK6md9Y1N99zMpaBD8vko2DjGSM+47dRWTo1teeKNYj12+R4tPjINpbkjLFSOScZwGG7r" +
                        "ycdgc9NqF/Jte1sd5uyBh0i3qhJxyecHHPPagCa8u33m2tNslyeo/uDBwT+P8qkt7KOAmRzulfG52JPI" +
                        "9M9KLOyhtFfYoMjkB5GwWfAwMkDn6U+9u4LC2kubmdYYY1LM7HgDp/MigBmoX8Gm2sl3dyiOCMZLE/pj" +
                        "vk4wPevO0j1D4j6uHmMlt4ft2IAyN0p6Y54J9T0UHA5quW1H4ka8MmW18P2jsWw2wueeOMEuRn2Azznr" +
                        "6bY2cFjZxW1rCkUEShEjUcACgBbW1htbaKCKFY44htjRR90YxgfyzVk4wf1pegooAKKKKACiiigAoooo" +
                        "AKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiimkjjJBB" +
                        "6f0oAdRSdjnofWloAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAoooo" +
                        "AKKKKACiiigAooooAKKKKACiiigAoooxQAmSe2PrS0gAA4GPaloAKKQ9D6fTNLQAUD1xg0UUAFFFFABR" +
                        "RRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFAOe1ABRRSfxfh6UALRRRQAUUUUAFFFIM/8A1" +
                        "qAFpOSO44paQAY4xj2oAWiiigAopP4u2ccVGx9ACPbjj/D3oAJXEalmO1QMk5wMc55rgrh7jxv4gS1iZ" +
                        "49IsT5kpDMDIcEKFwRgnkdSMZ7mpfFOqXWtahH4a0Vw7Ox+1TIRiFVIzntgbuffA9RW9aW1votrFo2mK" +
                        "EkVcjeMnHdiQCSenWgCe4u1sxBp+nxr5q7VVAhKovB7YHQcY/lmrllZLbWyo7NNIF+d3wWY+56/n60lt" +
                        "bJF+9cKZ2G12U9eScfmasSssalpGCpglmPTGOc/h/KgBtxMltC0sjhIkUlmJwFA7/8A1zxivLNSutQ+I" +
                        "niFrHTpZLfRbM4nn5Q5OecH+I5wPTr3Ip3iDXr7xvrkfh/QJTHZo2+4uckZA6nI6AenUkeleiaLolloW" +
                        "mxWFjFsii5GeWZu7MfU/wAunHAALGm2Fvpmnw2dpGI7eFQkaKOAO/49auc460cHmigAooooAKKKKACii" +
                        "igApM+o5Az60tGBQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQ" +
                        "AUUUUAFNODgle3pmnUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUg6Eqc/jQQOvpQODj" +
                        "FAC0UUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRSYyc55FLQAUUUUAFF" +
                        "FFABRRRQAUUUUAFFFFABRSHofT6ZpaACiiigAooooAKKKKACiiigAooooAKKKKACikx7mlHHbFABRRRQ" +
                        "AUUUUAFFFN459+OP8/WgB1FNHAx3A6Up9sk57GgA6D0A7YrmfFviH+yYFtIQz3tyCsax/MUJ4BwDnqeO" +
                        "x5rR1vW7TQ7F7mdxuCkxxqcNIewHFcZoltLJeTeLNaEkign7DCdpJG44OASO49+p9yAa3hzRz4esBPdA" +
                        "3Oq3jKkrKASg7LnrgY5/wDrV0lnZLC7TSfPcyYDuQPyqLS7acqLu7d2mcHCsTgLnI47H2rRY4ycDHXB9" +
                        "u/8qADJGOuPQDn/AD1rzLxt4ludYuv+EY0OOWWWQgTPGCMnnjPYDAJJ9PqK1PGviye2kXQ9IJl1GdxE3" +
                        "lsN8ZI4GMHnkHOMAA960vCnhWDw/atIy+bfTjdcXBYMSeCVXjpnvxk80AW/DHh638O6WLRfnncBp5W5a" +
                        "Vu/PBwOQB2GK3801SAMdO3WndRzQAUUgGMc0tABRRRQAUUUUAFFFFABRRRQAn8X4elLRRQAUUUUAIeh4" +
                        "6nn3oGSATwfSlooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooA" +
                        "KKKKACiiigAooooAKKKKACiiigAooooAKKKKAExnGeTS0UUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUA" +
                        "FFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUA" +
                        "NK5GDn65pQMcUvegDH0oAbg+gx6f5/GnUmRn36UoOe1ABRSHpzjHvSKwbJAJwaADg5PBBH6U6ikOB9T+" +
                        "tAC0U0+oAznr79KcMnqMUAFFB57ZoHHbFABRzmgjpTDwOnOO/QCgB+f84qvdXEdrbyTzSbI41JZyOg9f" +
                        "0qVicEj0yDu4rzvxBqcniXV00LTrjZAp3TTjoEXBJOOwwR2GRQBWt55fGniUXVyAuj2MmGSQ4Dt02cnB" +
                        "zlST/s4xXa2ViZ7pbtmC20aeXDAgAXAzz6Y5wPpVPSdPQWsVnFE66dbkshZcF2DE7ueuevT/wCv0gQYG" +
                        "MYHHTPHpQAY+UDjt0Gea47xt4xTQI47S3k/4mE/3QF3eWpOM4yMnkYHr7Vd8X+JYvDenIV2m7nbyoU9+" +
                        "ucf55NYXgbwxcBv+Ei1pN+oTrui8xRlFP8AGwxw5HYdOlAFnwN4Ul05f7V1ZnfV51wdxyYFP8PP8R749" +
                        "R9a7lTx0OQOnp7UABRjA4PAFLk/hmgAyBnHQelKOO2KapwOmKdQAUUUUAFFFFABRRRQAUUUUAFFFFABR" +
                        "RRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABR" +
                        "RRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRSHAxwOP0oAWiiigApCQeD0PHNLQPU9aAEz/PFA6f8A1sUfd" +
                        "HTj2paACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAopM80tABRRRQAUUUUAI" +
                        "M//AFqWiigAooooAKKKKACiikzzjj86AFooooAKKKKACiiigAooooAKCM//AK6ae/p3B5p1ABRRRQAd6" +
                        "KKKACk/i/D0pDjk8cdT/n2pwGBigBCPrn2phxkggYxjBIxTz1B/CsLxL4gi0DTjLgPOchI923HufYZGT" +
                        "7j1FAGf4z1w6dZfYLRH+23K7UAQ8K3ykg5HzZxjmsrRvDpgtZNO83F7KUk1CaMgFBnIjVgOmAcjB5zVX" +
                        "Q7S4u78ajeKBqtyrG3il5WBTg72GOD3A4IHWvQLS0jt4yEGXP35D99j6k4570ATQQxwQrDGoEafKox/n" +
                        "vn86qazqtvo2nyXl1IFSMZAbBLn0Huf89Kn1C/g02zlu7uZYYIRud2OBj+p+nqK8vMt98Std+zDfa6Ra" +
                        "PiQhQGZfTP98jHToB36EAk8OWkvjnxE2t6iC1hasyxwu3y+YpUKFGCCFHJ/2iK9TjUADHP0A/z/APrqC" +
                        "xtIbG1it7eJIoIl2RoOijoOff8Ar3q1gKB6CgAAAHAx+FLRRQAUUn8X4elLQAUUg6f/AFsUtABRRRQAU" +
                        "UUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUnOfaloJ7d6ADPtRS" +
                        "YB7evaloAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACjA446dKKKACiiigAo" +
                        "oooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiikOAMY4HtQAtFIBiloAKK" +
                        "KKACiiigAooooAKKKKACk5I7jilpABjjGPagBaKKKACiiigAooooAKKKAc9qACiiigAooooAKbgHGOmO" +
                        "O4p1FAAMdqKAMfX1ooAMdPb3ooqGZ4442dmCxqMluwHr9OtAFfUtQh02zeed1jAHG5tu5jwAOpzk9ga8" +
                        "3US+JL+61S7jd7UShbWJ8J5xA3bVIzlcYJ+XJIpuq6mfG2sC2WdrTSraTe0uchgO/ORuznAx09QOOy0C" +
                        "zhubaG5WBIbaFmFlEpIVBkgHB6k9T75FAF3R9IFiWuZmD3UoAZ9qqQM5I4HTPH6dMVqSOqIWfoAWY5xg" +
                        "D/AfypwIx6gn88/5/SvNvG/iabUrpfDekIZriZ9jkco54+T2GMknpx1x1AKXiHVb7xnryaJpQlWBPnEp" +
                        "JULg4Z2Ur8wwSBgjk+lej6PpVpoumxWNmoSGMYJGAWPdiR3OP8AOKoeE/DFv4Z0pbdAr3UgX7TOvHmOB" +
                        "j8h2Hb8a6AdBtxjtQAtFFFABRRRQAUm0egpaKACiiigAooooAKKKAc9qACiiigAooooAKKKKACiiigAo" +
                        "oooAKKKKACiiigAooooAKKKKACiiigAooooAKDyKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiig" +
                        "AooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiig" +
                        "AooooAKKKKACjAGMdqKKACiiigAooooAKKKTHuaAFopMeh4pQc/WgAooooAKKKQd/rQAtFFFABRRRQAU" +
                        "UUUAFFFFABRRRQAUUUUAFJ/F+HpS0UAFFFNyBgj8/X/ABoAazKFySBwcnPbGc/pXn/inxDLrE0WkaNPD" +
                        "MJCwnIYrkAA43A8DuTx6Z64s+N/FZs0/siyZ3upSFd4cs0fPCgg/eJB4PPI4IrL0Tw/Pavb2kOwXrKGv" +
                        "ZwATHgghFPXjv6n5enAALugaGrSJZLA8VpGxeeQZAnkwuCeF4ycAY4Az3Nd5GgVFVAoC8BQOAB/9cU21" +
                        "gS2tkhjGAvTI5J9TWF4v8TReHNJebKtdPlYYiRnPcnJ6AAnp6UAUfGvjBdCtja2H73UpchEUbthOcEjO" +
                        "c5GMfmKZ4I8HjRbf7dffNqEqsCw6IjEsee5JJJP0HaqPgbw1JchfEWsmS5uZW8y3Eq4CqVX5yp6Nwceg" +
                        "xXoKjA4OD056/j/ADoAdnrzyemaDwc/5NLRQAUUn8XbIFITz1G6gB1FJjA44pCOhz/nNAC49zSjjtikB" +
                        "BHHSloAKaRkEEckYJpQeB79x3oGcAYAoAQAAYPPbnvTqKKACiiigAooooAKKKKACiiigAooooAKKKKAC" +
                        "iiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKAC" +
                        "iiigAooooAKKKKACiiigAoopD0Pp9M0ALRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFA" +
                        "BRRRQAUUUUAFFFFABRRRQAUmfr+VLSY9cHmgBaKQj079xS0AFFFFABRRRQAUhGT0/WlowKAGgAKeOPTr" +
                        "xTqKKACiiigApuCD224xgcU6igAGO1FFFABRRRQAUUUUAFFFJjJ56UAJ0Az+vOKwfFHiOHw7pxnkVJZW" +
                        "GEhL7S3qeewznirus6xbaJp0l7dsdiYAVT8zsTwAO5JrzKLztblOta68f2eJx5UEpUCZ88IM8bRxuIPO" +
                        "cYoAsaNayxXbazqDz3Gq3Uh+xQtHt2AkgSYOexYIDwPT09A0LSV0m0YGUSXEp3SylRlj6epx75Pc85rL" +
                        "8OaebyU+ILzzGlnT9yHUgIhzyFIyOvQ+nvW/qF9babZT3V3KsUMS7nYnHHHP16UAM1TVLfSLNrm4YIi4" +
                        "ADMBuY9FGTxXm3hrSr7xvq0usa0c6bHKDFDu3JJjJAC9COeuPUdqkiS++IWvyGSSSHSbRh8yhgcFfuj1" +
                        "OcEnsMV6db28VpbpbwqEhQBUTsAOMUASKvU56k59afnNA9M800jgEDGB09KAHUUA5zRQAg6Dp+FBC5OR" +
                        "9eKWjGKACiiigAoxmk/i/D0paAGkjHJyMe3NAVQDtA/4DxTqKACiiigBB0/+tilopCMk9M4/wD1UAAGB" +
                        "74pabjP59cdKUHNAC0UUnTA4A6YoAWimqRtz0GM+1OoAKKKKACiiigAooooAKKKKACiiigAooooAKKKK" +
                        "ACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACk/i/D0paKACiim" +
                        "7R6n86AHUUUUAFJ2G3n+tLRQAUUUUAFFMbhSQBgDj39KwdW8RxWMqwW1u93Ox/5Z8KuDzk0AdDSEc9PT" +
                        "vXIQz+Lb6AjbZW5kBZZDGy7M8gfMeeMZO3+tNh8N+IpAq3niErk5IjTfyewJxxx+efagDqpru2txm4ni" +
                        "jXr87AYqk+vaXG6g3sRJA+6Sw+mR9O/9azY/B9s0plnvL2ZyeSJdgx7ADp361ai8JaLHsP2PzGU7g0kr" +
                        "MSffn3NACHxTpBQuk7uAwwVhfuRjt6kfnmq7eNdK+YqJ22gNgJgnkDjJ/2s1rppGnR7ALK2AiGF/dg4A" +
                        "HTp+NSrp9mkfli0gEZbdsWIBc+uOmfegDB/4TTT+0VwABkMwUbhkj5ct6g9ucVVTx3ayuY4rKd3wPlX7" +
                        "3QngY7DBrrxGmMeWBnrgfjSkZzg0Acs/i5xGCNJuHZwflXdg4B4zt9vTqajbxbeiPd/YlwGU/Oh3ZxwM" +
                        "j5Ofr6Bj2rrjkjHT6UYAx7dKAOSbxTfBmRtDuUdVJwqOxHAIP3QMHPc5yOlNk8T6os2G0O72cMcQuT17" +
                        "Hbg4GPr6115GMEkYHqKQAenI9v8+lAHGjxfqZjbb4avs7FbJDgZIJ/uev6dqePFt8GZH0C9jIDFS0b7S" +
                        "BgDBKjk/Nj2HXpXYc8Hn6UgUDIxwaAONufGV1btIG0W4UDOwuXDHCk5wU6cjkZHPbFOHjWUQuzaPcZj3" +
                        "kgbh90Z4yvpn8j079ht7E9evvRjqRwT1oA49fHNsyM4s3ESRB2JcdflyvI7Bgc98UkXxC0ottlRw2Tu2" +
                        "MDjqD1xjkEDP9a7FlB4JPWoXhgPzPCh56lRxk+/rmgDll+IGmEEyW91Go+8CgBB2luRnpxjPuPWrS+Nt" +
                        "JaN5GE6hBuKmLJ29zgfjn6Vsf2Rpzbh9gtGDDk+QmD7dPc/majOhaUy7TptmRyAPs64A79vf8aAKK+Md" +
                        "DL7ftjD1ZoX259+OD3+gqVfFOiE7f7TiU5CncSvUZHJGCDg8+/anz+GtImPzadAMtuwgKc4PoR7/nVRv" +
                        "BOgOpX7ESCoXImcZG3b2Ppjn8aAL8OvaTJGD/adn0Of3y+pz39v0q1HfWkikxXMMnc7ZA2O/r71gN4F0" +
                        "ooyq92uQQCJzkA9Bjpgc4z06VXk+HunbyBcXJQ4+VyCM+oxj6fXmgDriwIJUZyCRjr0pc8kdc8c5/z61" +
                        "wL/AA+utkax6wxwV4MOARxk/ePTHH1qYeFvEFvCQmt75BwQ0kiqi9M8E5+X24Iz9ADus9e+KWuAXT/Gs" +
                        "BwLtJDHgZFxndxyTuAPfv2Aom1Dxpbb2+wvIFZj91Gz8wIzg+n40Ad/RXnKeLvFFmcX2hMcAsdsMi7uT" +
                        "3GeBkdM1KvxGMZjEmmk72VQVLLkkgDAK84B5/n2oA9Bori4PiHpkxcPDKvzBQBtJUlsHPII5rSh8Y6LO" +
                        "u4XJX5dzF42UDqOTjANAHRUA57ViweJNHmkMSXyBwxXDqU5GPUD1xmr8N9Z3K5huYZVPH7uQHPf8+aAL" +
                        "dFMzyeVJB7D2+tKGBB2449KAHUU3jnsB70uQM89OtAC0UUUAFFFIenOMe9AC1XuZ4bWFpp5FSFAdzucA" +
                        "DvzUrdenJ4zjI/GvMvGOrX3iLWk8M6YGWITIJHGSJT3DEZwi9SfX04yAUbu8uPGviTcx8rRrUEsTztjO" +
                        "Mnnjc3bg54+p6jSNLbWLi3nlhNtptizJawINucYGG9fug5P/wCqnZaNbTtDodpcvJaW6b7qVThpnzt5O" +
                        "CCO2M8Y9K7uKJIY1RAoQAgKigfoOPU/jQAs0kcEbSSOsaKMl2OAvHX3ryvVrm98f+IRYaeZIdOt0Zml/" +
                        "hXPBYjOCcEgL9am8aa/ceILuPw9oeLhJnKSyITh29CR/COc9s8e1dv4W8OweG9Gjs4wGmJDzygf6x8YJ" +
                        "6DgdvYCgC/pmm22kWEVlaRiOCIHGQMk55Y8Dk8kn3NXh06YoooAKKKKAG9TkZ+ueKOemAPp/n60vUcUo" +
                        "GBgdKAEAAyO2Onal4I9qKKACiikHT/62KAFopCMkcUEjPOOtAAMYyDkY9aWkAGc45+lLQAUUUUAFFFIO" +
                        "n/1sUALR3/+tQaaSF9B6AnHFACkZpabgcggAdKdQAAY75o7/wD1qKKAEHT/AOtiloooAKKM+1FABRRRQ" +
                        "AUUUUAFFFFABRRRQAUU0jg4zn1pece/8qAFooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACii" +
                        "igAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKAGk54OenbqK4y0t5/DV873UL3ULElZ0QuVyx" +
                        "JLNg4xk9cZ9e1drjp7e9IeffHUUAZtprenXsSvDdx4bOFJ2sfwOPzrQ7EcnHHQ9Px61l6h4fsNS+WRHj" +
                        "IXG6Pjj0OeDzWenhV7JwdP1CeIbdpV2O089eOO5HSgDpux5GaUjIwelcrFbeKLOPMlxFeFV/wBWpG7PQ" +
                        "HLY46HnPQ81elvtWtxIz6csyqwCMjBQwJzk8nHHf1oA3KKyrPVTcrta1kRlHzdTg47E9eK0VdGVSqnBA" +
                        "I47UASUUDjtiigAopDjPf3xSZA7YA5PHSgB1FNDcDGT64FKpyo/xzQAnB6/y5ArIvdet7O+htBFJK8rb" +
                        "WKKSEb34PNTazq1tounvfXblUXO1QRlm7KM8Z4Ncd4Jnl8Tarca5cWNjHBC7JA0cJDvIdpLFu4AAwcdW" +
                        "PpQB6EMbeR9RnNOpq5xjPTrgd6dQAYxSYB7cHrx1oJ4569cCloAQgAYx8uOmKWiigBO2cc+lL0yT/Kii" +
                        "gBMgD0Apcf5zQOBRQAd6TH0zn0paKADGOlA9cc0UUAIRz1waY8SSBldQwYYIIyMe/rUlFAGe+jaZI5dt" +
                        "NtCWILMYFyeSeeOxOfbrVWXwxosjO50223P1IXGeMEZHPrWz3zt59aU9KAOYfwLoR+7bzowzgrcOSfUk" +
                        "MSCc85xVNvh7YAxiG9u4wrb8EI2eRkfdBAxx/8Aqrs6THHOM9+KAOFbwPfW+PsmtbSoIXdEVbOc4yp4H" +
                        "XtnkelH9i+MLQyiDWYZV6RmVySVAxk5UgE8d67vOaTgew+negDhXHjuzkGDDeJ3Zdnt2IU9PWnJ4q8RQ" +
                        "JuvvD7qo6lQ64znAzg8cDJ9+tdxjPXB69qaFUElR16kH3J/nQBxUXxEs02/a7C4hJBYEMoBGQATu29c/" +
                        "kfSrUfxA8PuUEtzJAWHJlhIA74JAI/xrppLaKY4kRJARj94u7IPOOfp+lZtz4Z0S4RkbSrLLZztgVCeD" +
                        "3Az27egoAI/E+hyNt/tW0Dk8B5Qh/Xn/wDXWlHPDNHuhlR1xwYju5wPT0/qK5u58BaHcMHWKaGRQoBhk" +
                        "I24HHBz+oz71xPibQYPCsbNbavcPdTgtFCYhngD52KkcDHp1GPWgDpPG3iua2lXRNLLHULhhGxVCzKHG" +
                        "Rs9Wx+A9eKxbSyawI0rT1S61q4yt5OvWNMjKAnkruzk56jnNctpXh/xDY+Vqcj/AOmOd0W6bL52sclWP" +
                        "BIJA6/zrd0u+8T+GftFzcaLcTu2BK8kDMfT7yZB656UAepaXpsOm2aJF87EEvLgbnySeSBzgk1yPjbxX" +
                        "LFnRNJZ5L+c+S5jG0pnACg9S2Wzgc4zyOtYmsfFmRdNZINPNteyEqjmQP5Q/vFeOeTx+YqP4eXGjpPda" +
                        "vqlzD/ajMzKjqx8le7ZI5PXnPHSgDtPBvhWLw7Y+ZIQ1/PzI+QdgJ+4Dj8+xOegwB1QHX0zVW1u7e6jU" +
                        "288UgZQw8twwPTn6VaBzQAtFIDuHHGR1oGDnIGc80AGe24ZxS0mAecfTiloAKKKKACkJxz/APqpaQAY4" +
                        "6YoAXvnH0opCPTv3FLQAUd6KKACiiigAoopCP8AJ9aAFopBg5IPU5paADqPSiiigAooooAKQd/rS0UAF" +
                        "FFFACYGenX2paKKACiiigAooooAKKKKACiiigAooooAKKawOPlxnOeaXAz70ALRRRQAUUUUAFFFFABRR" +
                        "RQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFJz6j8qAFooooAKKKKACkG" +
                        "AAOnHSlNFABScccdOnFLRQAHHWiiigAooooAKMAY9qKKAE5JI6D1qvd3MNnbyXFy6xwxqXdmPAXvVmsb" +
                        "xNpEmuaHPp0d19mabaC+zcOGBxjIznH1oA8wuJNS+JHiUQoRBp8Dhs5H7qPgEn1ckcD35r1zTtPttL0+" +
                        "Kys4RFbxKERF7e+e/rn61geE/Blr4XE8vnPcXNxgSSMNowpOAF9Offr9K6oDH19fWgBaKKKAEOCBnp70" +
                        "tFFABRRRQAUUUUAFFFIfpz2oAWiiigAooooAKKKKAEwM9PfNLQDntSMRjnp3HtQAtBpuRnB+8eOvSg8c" +
                        "Yx16CgB1FM3Atj1PbI9f8KQOpG5jjv+n/16AJKQnj0z3qISLnaD0wOG/T65phu7eNwsk8SueAC/P4Z6/" +
                        "wCfSgCxnOP1FA6VUbULNAWa5gRVHJMg4GcVRvfEujWFhJeT6laLFEDu2yqTx2ABPOaAH69rdvoOmte3P" +
                        "J6RxAjLt6c/j9BXmViJNRnn8S64IzbpcbLeF4jmdx8q85+VQevGDz6VUOvQ+M/FPn6pfxWWmWSsCnnAE" +
                        "huAMZ+ZjgZGCAAQe2dyx1TR7/WLd7yWC3s4F/0eDAwuCpxgDpjlvXHpkUAdXoFlLeFNZvT88qAxRlADG" +
                        "B07emPxJ9am8UeJbfwzpr3E0sRuDgRRFgC5J54znH0+nvVK/wDHnh7T9NeaO/jmaJPlhhHLnkbRngZwO" +
                        "uOBXm+mXUfirX5NW8TXvlWsao/lqjgNyfkX/Yzg9ck8DNAHQ+F/CT+Jbl/EOuqs8U5DQxONxccjceOgy" +
                        "AB6D2BrqLn4f+H549sNiLVigG+2cqeM446HqeSPSprPxjoRxHHcuGRQNgtpflwMbR8vPTt+pzWjFrtjc" +
                        "qrL9pMbfxSwNGDwc/eA49xxQByNz4BvrJmm0LVxCygCKGZSMdODIucjHA+XI49hUUY8faGMBo9Rh6k7/" +
                        "NK8jsdrnqePauvl8Q2sNusskcpAOCFKkj3xuJ9emax28eaa02JLS7iCKxLz7YyMDOQCefbp+tAGdH8R5" +
                        "rUqNW0qe3Ylty4MbrxkfK/sD6e1dRpXinSdYVDbXOJGAPlyDa3OCAOcdx0zXGaj8S7CW2mhXSftSqpIj" +
                        "kYEMQQOV2kAZ981zMltq+t6n52meFLu0O8EMpcR5OMkFvlx9MfjmgD3Meh5IP8ASl59B+dZuhQXtto1r" +
                        "DqEwmukXDPuDbu45wOgx+vWtMdKACiiigA5z04pMc/1paKADqOR17GiiigAooooAKKKKACiiigBABwf5" +
                        "0tFFABRRRQAUh6H0+maWkAI9/TJoAD0Pp9M0tFFABRRRQAUUUUAJ/F+HpS0UUAFJ/F+HpS0UAFFFFABR" +
                        "RRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABR" +
                        "RRQAUUUUAFJkZ689OtLSA/XPvQADoOn4UtAH50UAFFFFABRRRQAUUUUAFFISBnPTHPpR7igBaKblSBgA" +
                        "jpTGlQAszKABk59Prn60AS0VTk1CyQHddwj/toM/h+tU5fE+iwhTJqNsA3IIbP8vagDYorm08Z6LJIVW" +
                        "4diFJXCE5x2Hv069yKrT+PdJichY7l+TtcIAGHcjcQe5xQB1uKQADoMdq4dviLatvNtZTyFEL4chCeRx" +
                        "xnqT39qzW+Jk0yhYdNUcHJLlwONxbhR0AOR3598AHpdICD0rzh/GHie5craaK6uzYUm2kYDBHXJ4H4ev" +
                        "0pBqnj+4jUw2Lx7scvFGhHIx949euRQB6PkHqOgzigEZ46/hXmyx/ECWBkYNGxAwWmi46Aj5T2+Y/Tvn" +
                        "gtk8L+NbpjNJq9uP9h5pAUAJOMqpA4wOD+eBQB6RuXAwR04x37Y9u1QS31pEzI9zAjr1VnAxj9a4CLwH" +
                        "rbOrTa8seARjLOOpP3TgHr6/wAhTo/htOInin1iR0GMYtue+Tkt7/z69gDuJdX06HO6+t1AO05lXg9h9" +
                        "eD71UbxRokRCyanB2IJOc9Tjjv1rCj+HlmM+Zf37vjDFWRNw24HVTzz7DINS/8ACutIbbva8wse3aLjb" +
                        "uwOp2qDn6UAXJPHGixoMSyOTyqhex6HPvmoH+ImhLgKZ3ZuqJGM9fcj/JqZfAPh0Bv+JeCGOSGllYdc9" +
                        "C/FWI/BmhRNu/s2BmAC7mUtx/wInr/SgDHn+JOlw5EcMrMMjDEKTg856445z7VXb4m2iA50+TKoST5oA" +
                        "3Yztz26YzXUp4b0aIFU0mwXcctttkxzn/ZPHX86uQ6bbW6FI4I1BByFjVev0A/yaAODPxRjeXyYtOUyY" +
                        "OP34OCB0xjpn+Xc0f8ACda5M6G10V5YzIFLJBIxG7cR046KM9ssOlegPaxygqWlwRyVkZc578HrTo4ki" +
                        "ijRNwRAAuT0xwBzQB5+3i3xZPJElv4dmiEgAy1rMdpJx97pjHNQHXvHkxCxaTIDg7t1uF6c53M2PUdP1" +
                        "r0kwxt1Rc9cEDIoMcYO7YueeoHT/OKAPNpr/wCIbwuEtTHs5JzCMjvwx559/wCYp0dt48uU/wBIkED7S" +
                        "dy3S4PHoD6nqB6V6SECgKqgAdPakAUDOevJ5z+VAHnTaH49nyJNUEZ5KuLk/Lxjsvt6d+Kj/wCER8YSz" +
                        "b31qNCQNwFzOcEYIwAozzu79wK9LwpB4B5owD2788UAeXQeB/Fjgi41m3OWH8crjIPOMj+frUtr8OdTj" +
                        "XMmsxMwHH+jswJ64JJwc9K9MAHTjjoPSkKg9QD9RQB5u/wyn85ZW1os4I5S1UZxjrl/WnW/wxCRxrNrE" +
                        "zNGPlCW4X5fTG48jnpxz616Oc5/CmEgOOcA+nTuaAPOpPhjZwtJO+rXA4G91ijXbg5JzjGME8EfyriLz" +
                        "Q49d106dpM1yltasGlurk7Qij70hIxkdMHryPeu18aeIZdSu49A0vfNI5AkEbKd7HtkNgYHJzxyPSqVj" +
                        "pzxxweHtNAleZv+Jhd+YSHcdRweFVgy4BAJOevUAytF8A6brF5LbW1zevYQuu9jKgLHByDtJIPTj3ro9" +
                        "U8CeE9Esjf3TXccEQG3M5yzdQoVhjJxxx2rtoI7XR9NCl0jt41y7uwC9epLHA59TXnF/LqvxB8RQ2EW+" +
                        "00q2ctMx5wOxODgs2OPT5uD0ABgaL4Ps/F+sMtpbz2mjwEoxeRmbOBwrHgsQMnHQE+gr0q3+Hfhy3iT/" +
                        "QCXWMISJpFOAeBhWH+R3roNM0y10nT47OzjWOFAfkA69zn1znvV4MSMjn14oA56PwR4fT5k08KQcgCZ8" +
                        "E+43Y7VJ/whvh7O5tJs3wcgyxlz+preIz1A9OmeKQ5I4xuFAGXF4b0OM5h0fToj322sYP8AKpYNF0y3Z" +
                        "nh0+zRn6lLdFLDryQOa0c80UAQC3jwFBcAcgKxXqfbFPWJFQDZu+vJqTqOR17GigAopuQTxyfanDjtig" +
                        "AooooAKKKKACiiigAooooAKKKKACiiigApOD26j0paKAAd+KKKKACk7Dj64NLRQA0Ac+5zzTqKKAExxy" +
                        "M54IpAAMk9zk+3+cU6igAooppGTg9PTHWgB1FIMdh156UtABRSfxfh6UtABRSYA56/hSHaB7HsO9ADqK" +
                        "Qd/XPpS0AFFFFABRRRQAUUjEAc0tABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFN4xz6" +
                        "cgntQA6imEqDnA6/wCf5VG80UaM7yKiDqWIAXjrmgCeisyTW9JiU79QtgOVx5g9fas9/GWgpGznUFO0A" +
                        "tsRjtJGfTtg9+lAHR0VyE3xA0aJ2jBneRdwOFAGQvqT7dfp61Ru/iVZwPtisZZGUFsu4XjaSM9cd/yNA" +
                        "He0h6H0+ma89/4TnV7hWex0OZ1XgARu5JBIIBwBnGDxwcGqw1vx7ey7bbSXhUkcvAItgz1+c88YH4UAe" +
                        "lk544z/ACppbDEDr3A7/wCeK86Nh8Qbs+W94kQ7StMq84P9wH+VKPCHiuSRBN4hygBLYmlb6DAxxx9fp" +
                        "3APQ2dYwWbhVzlicY/P2qo2qWCY8y8t1BwBlx1PPWuLX4eXEkxln1klpAS6CDAznqPm4GMjp6H2q5D8O" +
                        "dPiH/H5fSIedvmKMHd/uZOPcnqaAN2bxNo0O7zNRtuSQQsgbnjjge461Tk8b6GIvMFy7jBJCxnIHTPQc" +
                        "Z96rJ8PtBXzA0E0gbGVeZgOhHRSOxH6Veg8IaJBKXXT7Rjkli6M3fPdj3NAGe/xA0s826yS5APJCk544" +
                        "557/kfaqz/ES3kdxbWjSkL5gAfBKY+9gA8DBPr0+ldTBoum20geOwtY2zwUgRcfiB7D9KtxwrHGERdij" +
                        "oF4Hvxx35oA4s+LPEE0Mbw+HLgbj8yNDIcjPXOB2x29artrnji6b/RtICBW+YvBt3DIHG4+mfyrv9ijP" +
                        "c4Gc80uBjBGfrzQB57J/wALBuQjBUtirKCgeLkdzj0xnuOfWnnSPG1yv77U7eM5Rjmdlz6/dUjH/wCr0" +
                        "r0GigDz0eDPEEzbrvXcYGOCz9jnrt9T/Orf/CBNMCLrVJWY5XKRBOvPTJzjJ5zXbDA4HWkPt174FAHGW" +
                        "/w9skdJG1C9JQj7rqmDj6E96mh+HuiwqQ32uQ44DzHgYHHygeldcD75pD8vbgDigDnYPBOhwEbdPjbkB" +
                        "vMeR84/3mIq5D4Z0aMEf2bbtkbTvjDYHXv+Fa/GDuA9z7UpGf8A9dAFGPSrKJ1kjs7dZFxhlhUEY6YwP" +
                        "yq2EUfKCAAeABj3xT6DyKAGhQBjbx0H4UgjUNkIMngkDqKfRQAmF4OOh9KXPNBOO+KKAExycDGepoAx7" +
                        "4paKACiiigBODjvnkUvWigcdsUAGeM/0oppI69Mjrj/AD61Uv8AULTToDNd3CRJ/tPjJ9B3oAu4/wA5o" +
                        "4B+tcRd/EWytZEAs5pVebYu0jc3Dc7evYD8RXZxuHRXweRnGMEcdxQA7OSD1HbilGe/50tJjkZ6gelAH" +
                        "mvj3W9X03xFaRWV1LFA8AKBATufc2Qc4BOFUAHuaz4PEHxFhVpWsPtESkqu0JMT0HPkg8/iO9afjIGTx" +
                        "to8HmZKmFkUnAO6UD6k+2O1egCGIk7kjyScgDOf8/560AeUSfFHW7BlXUNPt42Ksf30ckPQdBu79zk8Z" +
                        "96uQ/GCDy182xjd8/KY7gAHj3Ge/wCVemPAGO0swX0DH/PpVO80PTtQI+1WVvOB0863R/8A0IE0AckPi" +
                        "to4jAe1u2cKpZYij9eCPvDOM5qZfihoIm2SpeISoOfLBxn1IY44Pf8AwrWl8EeG5QN2iaYQvT/Q0UjP0" +
                        "xg1Vn+HvhudcSaRAFB48ppYz/461ACS/EPw/Gw/0p+ELcR8ADHB59/oSMZ7VznjD4mWC6R9m0O7MlxOG" +
                        "VpCpUxLtIyuQOewB9zxwaZ4r8KeEfD2m+ebGQyc7Ilu5BnHXOTwMfT68CuGt/B9sscuo3rGXzg62tssh" +
                        "3THdtMh54UHoCeenA5oA3NE1XTNMtIphqsZ129BDuSyi3i3cr7seOxAwQD69foviTwroVswOpxyXGAZJ" +
                        "EiY5HX5Rgnbzk89axtM+EunwwrcaiAXKAlEuim0k5wT3xnA+g965jWvDmlX+sppXhxbmWXhGd5DIkj4O" +
                        "COPujuxPI6d6ANTxX45j8T38elWd0bbTFP7yaSP7xHWQrySB1A4PftXV6H4i8EeHdLeCwvZDEXLu5idm" +
                        "lfoc5UemPSqmk/CLS7aJftgW6kKnzHSaRAxySCME47fjWn/AMKt8NrMH+wOxxwDdSkKRj0OaALC/Evw6" +
                        "8ZZbmZsHbtCc/Uc89feo2+KHh3hmkudoUMxEQOzp15+nSmj4Y+GPlX+zCUAC7VuZsDBOej5zzTl+GXhj" +
                        "AI0yJipxn7TPx+cn0oAT/haXh054ux82NxjGD79enX34ok+KOgJMERbuQKPvKiY7f7X1qRvhj4YZcf2Z" +
                        "HkccTTDkkc8PSj4a+G1DD+y7XA6bnlIH/j/AF5oApn4qaIoiH2e7AfB5CDAxyfvdRxx78Ug+K+jSY2RS" +
                        "RBlB/f5UjOePkD5PQ/jWovw+0BSudLsdqkY3q749MZerA8FaAFRBoWl7F4X/Q0PGT659f1oAxV+KWish" +
                        "PyqwYK24uFA/BCR+A/Go/8Aha+jAAEfMW2kEvwNoOT8g/X8+uOhfwb4ekb95oWmOG6/6Ko9uwP608eEN" +
                        "A3bho+mgngEWUXTHrt5GKAOck+LGio+FDlem47hzkf7Ppn8qqv8XNPBJSGMnggedj68bc11w8JaIQN2k" +
                        "6ezcn/jyiGDnOeVPfFTHw3pZQL9htNvTH2aIj6fdoA4r/hcOk/KTbuoBIOG3cfXA5/Olb4x6KhYm1uBj" +
                        "ONxUYA55GfrXcRaHYQACO1gXIwdtvGOPThRTzo1nv3Jbwg5/wCeCcfpQBwMvxl0UxjybS63chi6rhcDr" +
                        "jd+maYfjHpbMT9luQDnCiNM8c5z5nTGf8RXoy2MStuUMpAxmMBP5c/5FOS3RR8skjA84MhH8v8APFAHm" +
                        "g+Menx8ywzNkfdWBV578mX6e3161MPi5atxHZ3LlQSxWIHGO+N/Trz6fia9GNqMqd83y84EjAdOnHWlF" +
                        "sgUhmkwcjmRjn60AebP8XbRPM8zTb2MI20rsBx3ycsD/k85FPb4y6MHZBaXTqoGcBFz64y4JPPbP5c16" +
                        "M1sDxuk/CV/55pTbqRy8gHQ/vD/AFoA83X4y6R5pWWyulK/eUiMZ4x3k4zj8j3pR8ZNCzuIudhXODChY" +
                        "ZA28+ZzyD0HNejNap18yXP++TzQLSLBUc567uf8/wD1qAOBj+L/AIdl5zc7c5B8lcEY553469s+nvVxv" +
                        "in4bAYl7hCuWAeBhwDg8AZ6n+tdTPo2n3LB7m0t52AAzJCrYx9RUM/hvSbnmbTLCTBJ/eWkbc9z060AY" +
                        "K/E3wyzYkvDGCCFLwy8sDz/AA9M+lPPxH8OBismpQqe6kSdM/7nTjv/APr1D4M8OkbTommYPXbZRjj04" +
                        "HvUf/CFeGtvyaDpik4OPsy/Xt70ARxePPDM6B01a3zk8MxX+Y9qlXxp4bdmEetWG1duWNyigZPfke1U2" +
                        "+Hnhlsk6NaKWOcKHAzjsN3HQVGfhr4ZOW/suMMQfuSyjB9fvewoA2IvFGgyJuTWtP2dARdJj19c9MVOm" +
                        "uaRKf3ep2TdcbJ1P9cVzM3wu8Mys5WzmiZiDvWY5BAxgbs+vp29qqf8Kl0DOVa/DFdv+vGMHvgpigDuF" +
                        "vLWTPlzwyDP8LA8/hnrz+tTrIrAkMOP89687X4RaLEmI7rUEJZSzCdD931GzH94fjSv8JdOH+r1G/B3D" +
                        "58puwO2QPQY6UAehs6qpPAAB6+xo3KWKhsnr1GP8815/F8L1hicJ4i1oFjkFJVUbePlx65HWo2+HmrHO" +
                        "3xdq2FPy/MemPlB/ec4/XigD0XK4PGOM4xgil3YPJxj1Pb/ACK85Pw81pECx+M9T8vI3BgxIGc/89eO/" +
                        "wCdQj4d+Idp2+M73O0ZBjkBHHb973oA9LDKVGCD6EY/znmnccggc/rXmv8AwgviqPcY/FspCriNXD4Pb" +
                        "5juyev+elDeEvGyTSCHxXiEvuyTICBg4H8vyxQB6Vn6/lR1PbIrztPD3j+Mho/FUDEggqYTgZGAQdpzU" +
                        "baT8Sgrf8VDZE8f8s8AY9vJ4oA9HAHHftS5xx1Pb3rgP7N+In/Qc07AI3Nt2g84PWM1BLp/xLRdy6vYu" +
                        "xw2wBVwOpHMY5H1x6460AejH3HHvScdCO2MmvN4rL4mqIg+p6d8ynG7ac8ZC/c7fj+IoK/E5IQVeweUj" +
                        "lUKZU9M8hQenSgD0gcn/D1oyDk5GO+D29a86iu/iYsvNhaPGVIBd4x/COeHz1+vT3qy2rePYYyW0azd8" +
                        "bgIyD2B7y4J6j8ufQA70fXNLXn8Gu+PAA1x4fgC78HAyeR1ADkjkHk+vtkznxJ4pidkPhuR8Z2sFfAOT" +
                        "j9O/PXr6AHc8468+oorjIfE2vFx53hudVG0cB8/N/wHHHT257VM3iq/jV3Ph68Kq3YNnqefuj/H60Adb" +
                        "RXGx+NtzOJdGv4lQjJ2E7jkcjjnuevY1dHiy13bBaXbyLGJGWNA4UFgOcHg5OOnY/iAdLRWPp2u2eogm" +
                        "LzFbcABJGRk4J649B/SrsV3FMhaPzNqkclGyc8jqM9/50AW6KaPXnr6Yp1AB1yCOKKKoaib4WhOmpA9x" +
                        "kbROxC4z1yvOcf5FAF+m4Ixjg/TiuSksPF80kZfU7KFGlVpFRSPKTowB2/NxyM45z9arnwhrlww+0eJZ" +
                        "9hyHRN/cc4y3HP1wf0AOyaSJF3OyqBjkkfX+lUJte0m2z5mo2oYYyPNBPtxnPr+Nc7/AMK8tLlB9t1C6" +
                        "mkCbA6qgJ+YnuG9T36YFW7f4f8Ah+JhJJby3L7cbpZWOcEEHAwM5FAFmbxnoEIlzfqTDjOEJ746468+v" +
                        "es1/iNpALiGG5kIYgZUBSVxnJzx1HPrW1b+FtDt87NNgkPTMy+b2A6tn0FW4dG0yCTfDptpE3TdHbop6" +
                        "59PUA/lQByLfENpTIlppM0ro20YJYnhsE4Bxyo/PpTJfFPiq6hR9P0Bl3uQpkhkIxnrnjsDzx16+vfAY" +
                        "9ifWlIGc45+lAHnQvPiDcYRLPyX+UtgxBfu89c9wP1qabSPGd8dzaj9nUpyq3G3kZP8CnnJA4x09cV3+" +
                        "FI2446YxRjOc4OfagDz7/hBtZmd/tWvMys0mGHmOQp6D72Klj+HMKq0c+pXM2UVSdirkjgHnIPGRz2b6" +
                        "13vejrg0AcjH8PdHQkbrx1+XarzcLhdoxgA++PWrcXgrQIVYLpyneGUh3duoA4yeOF7V0ZAPWjgj2PpQ" +
                        "Bjp4b0RF2jSLLaM5Bt0bIP1Gew/StKO3ihAEUSoB/dUL/nnP51NnmjvQAzYuCH5B7HkfrShQq9AF6kU6" +
                        "igBC2D0pONuRjAHHHSnUUAJwDnH44oAwfoOKWigBOCMDp04paKKACgDH1oooAKKbySQRkGnUAFFFFABQ" +
                        "elFFAATiiiigAooooAKKbxzuHbk44oAGD/ED1FADqKKKACiim4zz0oAdRSDPvS0AFFFFABQAB0pPlxu4" +
                        "x1zS0ANOOecYx3rzjxn4Y13UvGFtqWmXPkwC1WAlWfePmYkgYxnDA5+vHr6TScZ4/SgDmNL8J2NnffbJ" +
                        "Iy8q7djTTvMwwDySzEZP3uBwa6cZA/GkAAUryRjp/SnUAHfpTT0znjrn0oLKuCTj2J9aCe/JwfSgDgPF" +
                        "Cqvj3Ri7KC7RCPj/bbj37ce1d+DkHt79P51xXipwPFfh9ipJaaPCgZA+cDJ/Pj35rtF6AnHpwP5e1ADh" +
                        "39M+lGQcYPv1oXp19uuaWgAqhqmoQaVYzXt1MI4IU3MxIBPp+Z4q1IwSMsTtUAsTxx/+qvH/Emsz+Ntd" +
                        "WysrlIdLtyzNIckY+6ZCMHpnA+voTQBThvE8W+I5NW1YFtOtW2MisCrNk7I0DDBz39Mk8ZrufD+ltq2o" +
                        "HXb+ErBsUW0GMJsHT5cdsn/AArC0LSj4huYY4opINFs/lQMwBc8ZLEDlm7ntwBjmtnxZ4rj0ZE0XR491" +
                        "8wVESEZ8vOMBQPmLYPHHf3oAo+MfE13c3zeHNIkdpmCrKY4853D7oOT2P5gcjpXQeD/AApF4YsGG5JL2" +
                        "YKbiVScEgcBRgcdee/P0qp4J8JNpCNqeobjql0MuWbPlg9vTd6kYHPT17MYHQYye35UAINgJ9Qe/bvTu" +
                        "3AGMcUuMUUAIwB4NIfQg4/PNKe/Xp2pRxnigA4z70AYGB0oxmkJwPTjrQAvejvSdjkZFLQAgGBxjI4OK" +
                        "WiigBCO4Az1pe9FFABgelHSiigAooooABjpRgZzjmiigBOcHrS0mOABxSigAooooAQ88YyO4xQMDJx09" +
                        "BS0UAJgcZ5I7mjAJ7EilooAKQjPXpS0UAFIMH35paKAA/TkdKCMjB6UUUAIAOoxz6UveiigBCMj3/lS0" +
                        "UUAINvGMego4/HP60tFACYGDgd88+tIxC8nn09uKdRQAhwe2e3Sj2Bwc+lLRQA0AD7xzzn0pQMcDpS96" +
                        "QHPIHXvQAuM03C+nHSnAAUUAJwcZFLRRQAAYGB0pqgDoRycnFOooATAz0P4f59qMEAcAkDj60YAFLigB" +
                        "OB27+lAwAABwOKWigAooooAKDjHNFFACZA4oHoMYHGKWigBOgJxz7UtFFABQQD1oooAKKKKACiiigAoo" +
                        "ooAKKKKACiiigAooooAKKKKACiiigAooooAKTHPQetLRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUU" +
                        "UUAFFFFABRRRQAUUUUAA6UUUUAFFFFABRSDp/8AWxS0AFIDwSBx7d6Wm8dce5GOaAOC8YxGXxjoG1gMy" +
                        "J2+YBZFJJ7kYHH/ANeu8AOSMDHtx/niuG8TxKfHmiyOxVsRqvrnzCePwz/k13Y5APWgBM5JGeenagkZ4" +
                        "6kcDoaXpwMdOBXM+MPEsGgad8kii9lDCKNh2xkk+gwOv/16AOZ8e+KjcXUegaa7yM0gSYxt95uMID16H" +
                        "J/wzWVo2lS3MUGgad5YErb9TuYxuWTHT22jJwOhPPSsHT7Oa4bz3kklvryVkihwSwBXbnPctz1wMDk81" +
                        "3d7dxeAvDgtbIrLqk4UkgDapA27iOw+UgD1oAueI/EVj4V0+DT9N8v7QzeSqoAWjGAMkdCeR1PPvS+Cv" +
                        "Cr2Ua6vqqM2pzAsPMXBjB74OTuwB+HHas3wN4WuLiYa9rMGZmIe3WRm3lv+ej+pPUZ5BzXo64Absc44H" +
                        "5UAOGBk5HXrS9B60hHocZpRQAUHHeiigBFzjpgelLRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUmP" +
                        "c0tFAAOO2KKKKACiiigAooooAKKKKACiiigAooooAKKKKACkAx+XrS0UAJwT2II9KWiigAooooAKKKKA" +
                        "EHT/wCtigYwMdO2KWigBqgKuOeB0znFOoooAKKKQ9D6fTNAC0UUm4ZxQAtFIcjHGSB1pRx2xQAUUUUAF" +
                        "FFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFACAg9KB+Hvj1paTpyew6mgBaKaAF9" +
                        "ufX8KdQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFF" +
                        "FABRRRQAUmM54xmlooAbncBxkU4cdsUYFJ0AAwPSgA4x1G0+lJuBPXocUpPOMnPWmgEdO3YDHagDj/FD" +
                        "Qr4p0DLNua4UEYHc8dffj8a7Feeo75Oa4XWkjvviNpNvIN6W6A4K5y+S2cd8cE56Y9a7SR0hhMruERAS" +
                        "zFuAPU5/wAmgChrusW+h6XJe3DYC/Kq5wWfsM9vcntXjFzqNxrV3LrGqlcg7IbbccOSc/KS2Nq9DxjJ6" +
                        "dau+KtWk8V3xLKIdNhccksNyE8A44DEAkZ9ccYq3pKW2jxPrt/G6xRnbp9tuP7xlz6n7qlvUDJz6UAaU" +
                        "E8Pg2xfVtTKXGuXgLx27HlFZhlickDk569DipvCfhmXxBdHXddjMg3hoFcYaQjncSD90dAMcbaqeGPD9" +
                        "14r1abXdaLNbNLvSJgwEhUjC+m1cYwOD7816pGqpGqLgKowox6cdKAHrgKCcdOMf0p1FFACFQcDBxjsc" +
                        "UYyOR16ilooAKKKKACiiigAooooAKKKKACiiigAopPTJwelLQAUUUUAFFFFABRRRQAUUA57UUAFFJwOc" +
                        "dO9LQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUn8X4elLQAUUUUAFIeh9PpmlooAKKKKACiiigAooo" +
                        "oAKOmTRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAH" +
                        "eiiigAooooAKKKKACiiigAooooAKQjJ5wRjHSlooAKKKKACiiigBBjGQcjHrTHYIVBXIPHTp7VJQOBQA" +
                        "gBwRn8aWiigAooooAKKCAeooGT1GKACiigHPagAooooAKKKKACgnHaijvQAUUUUAFFFFABTGHBJwfr09" +
                        "6fTcZHYg449qAPLPEFzK/xr0e3judkcaRtIo/iyHwpGevTH9aT4i+KnnmTQdNYySSSBJRAN5kbJGzA9C" +
                        "MnjPHsa534g2t9pPxN/tpZYzvMM1sVG51KJtwV7/MCemKo6bKqSzXlzLM2pzsMuGB8vc3zBu5YgHPO7D" +
                        "YGc0AW4NNieBoWuk+zW7edczbiuXYAYJPfrj6HgbjW9oWjXPjW8hvr6IxaRAvlQKh2KyE8IoHUdMk8+l" +
                        "M8OeErnxIlm941zBo0bGRFY+U9ySv3tvbHH4evU+s21vFbW6RQRJHGgwkaLgLx/nmgBYYkjiWONQFUYA" +
                        "A9OnNTDpSEcHgc/rS0AFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFIOn/1sUALgHtSYx0wPwpaKACii" +
                        "igAooooAKKKKACiiigAxjHt70UUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFF" +
                        "FABRRRQAUUUUAJ/F+HpS0UUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFNwOQP" +
                        "TBzz+dADqKaAQvOT3606gAooooAKKKKACiiigAooooAKKKKACiikHT/AOtigBaKKKACiiigApMe5paKA" +
                        "AcdsUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUmPc0tFAAOO2KKKKACiiigAooooAKKKKACqOp30Gm2E1" +
                        "7ckiGJdzYIzn0HbJJA685q9Xn/xZuprbwvFtMv2d5x57RsAAoBK5yP72PTpQB5/qV4/iPUZ7nVgVidxs" +
                        "AJZTgEhQAOMKDznJJAxXonhrwFp0Ful5qln5t0zCSOGbDCL04H8XHPX8cZrB8FeC7m9vLLVNSt/ItLV/" +
                        "OhgkUb5pQCAzZG7C8YyR0HFerpwPocdKAFXoeSSDnHp3xTqOcdaKACiiigBMc9cD2paKKACiiigAoooo" +
                        "AKKKKACiiigAooooAKKKKACkKgjHQYxS0UAJ0BOOfaloooAKKKKACiiigAooooAKKKKACiiigAooooAK" +
                        "KKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAK" +
                        "KKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigApD0Pp9M0tFABRRRQAn8X4elLRRQAUUUUAFFFFA" +
                        "BRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUANbABJOO/Wnden8qTGR355" +
                        "60o78YoAKKKKACiiigApjqHBRlBU8YYAg0+igBBwcDGB29qWgdKKACiiigAooooAT+L8PSloooAKKbkb" +
                        "8c560o575oAWiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACk7Dbz/WlooAKKKKACiii" +
                        "gAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACikx7mlHHbFABRRRQAUU" +
                        "UUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAIeh9PpmlooHHb" +
                        "FABRRQfpmgAopOBwep9KWgAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKK" +
                        "ACiiigAooooAKKKKACik4JODyOtLQAUUUUAFFFFACE8c9euBS0nDAHqDS0AFFFFABRRRQAUUUUAFFFFA" +
                        "BRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFA" +
                        "BRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAf//ZCwGxGVNFTEVDVCAJU" +
                        "HJvZmlsTnVtbWVyID0gZGJvLmZuTE9WVGV4dCgnS2FQcm9maWwnLCBLRVAuUHJvZmlsQ29kZSksDQoJT" +
                        "mFtZVZvcm5hbWUgPSBQUlMuTmFtZSArIElzTnVsbCgnICcgKyBQUlMuVm9ybmFtZSwgJycpLA0KCUFIV" +
                        "k5yID0gSXNOdWxsKFBSUy5WZXJzaWNoZXJ0ZW5udW1tZXIsIFBSUy5BSFZOdW1tZXIpLA0KCU5hbWUgP" +
                        "SBQUlMuTmFtZSArICcgJyArIFBSUy5Wb3JuYW1lLA0KCUFkcmVzc2UgPSBQUlMuV29obnNpdHpTdHJhc" +
                        "3NlSGF1c05yLA0KCVBMWk9ydCA9IFBSUy5Xb2huc2l0elBMWk9ydCwNCglHZWJEYXQgPSBDT05WRVJUK" +
                        "FZBUkNIQVIsIFBSUy5HZWJ1cnRzZGF0dW0sIDEwNCksDQoJQUxLTnIgPSBPUkcuSW5zdGl0dXRpb25Oc" +
                        "iwNCglBTEtBZHJlc3NlID0gT1JHLk5hbWUgKyBDSEFSKDEzKSArIENIQVIoMTApICsNCgkgICAgICAgI" +
                        "CAgICAgSVNOVUxMKE9SRy5BZHJlc3NadXNhdHogKyBDSEFSKDEzKSArIENIQVIoMTApLCAnJykgKw0KC" +
                        "SAgICAgICAgICAgICBJU05VTEwoT1JHLlN0cmFzc2VIYXVzTnIgKyBDSEFSKDEzKSArIENIQVIoMTApL" +
                        "CAnJykgKw0KCSAgICAgICAgICAgICBJU05VTEwoT1JHLlBvc3RmYWNoVGV4dEQgKyBDSEFSKDEzKSArI" +
                        "ENIQVIoMTApLCAnJykgKw0KCSAgICAgICAgICAgICBJU05VTEwoT1JHLlBMWk9ydCwgJycpLA0KCU1vb" +
                        "mF0ID0gZGJvLmZuWE1vbmF0KEFNTS5Nb25hdCksDQoJSmFociA9IEFNTS5KYWhyLA0KCVJBViA9IENBU" +
                        "0UgV0hFTiBLQUUuWnV3ZWlzZXJJRCA8IDAgVEhFTg0KCQkJSXNOdWxsKFhPVS5JdGVtTmFtZSwgJycpD" +
                        "QoJCUVMU0UgSXNOdWxsKE9SRzEuTmFtZSwgJycpDQoJCUVORCwNCglCZXJhdGVyID0gQ0FTRSBXSEVOI" +
                        "EtBRS5adXdlaXNlcklEIDwgMCBUSEVODQoJCQlYVVIxLkxhc3ROYW1lICsgSXNOdWxsKCcgJyArIFhVU" +
                        "jEuRmlyc3ROYW1lLCcnKQ0KCQlFTFNFIE9LTy5OYW1lICsgSXNOdWxsKCcgJyArIE9LTy5Wb3JuYW1lL" +
                        "CcnKQ0KCQlFTkQsDQogICAgICAgIEJlc2NoR3JhZCA9IElzTnVsbChDT05WRVJUKFZBUkNIQVIsIEtBR" +
                        "S5CZXNjaEdyYWQpICsgJyUnLCAnJyksDQogICAgICAgIEt1cnMgPSBkYm8uZm5MT1ZUZXh0KCdLQUZhY" +
                        "2hiZXJlaWNoJywgS1pGLkZhY2hiZXJlaWNoSUQpLA0KCVp1c3RLQSA9IFhVUi5MYXN0TmFtZSArIElzT" +
                        "nVsbCgnICcgKyBYVVIuRmlyc3ROYW1lLCcnKSwNCglPcnREYXR1bSA9ICdCZXJuLCAnICsgQ09OVkVSV" +
                        "ChWQVJDSEFSLCBHZXREYXRlKCksIDEwNCksDQoJTmFtZUFNTSA9IEtFUC5OYW1lLA0KCVBFUlN0cmlja" +
                        "GNvZGUgPSAnKlBFUi0nICsgSVNOVUxMKENPTlZFUlQoVkFSQ0hBUiwgS0FFLlBlcnNvbmVuTnIpLCcnK" +
                        "SArICcqJywNCglBTU0uKg0KRlJPTSBkYm8uS2FBTU1CZXNjaCAgICAgICAgICAgICAgICAgIEFNTQ0KI" +
                        "CBMRUZUIEpPSU4gZGJvLkthRWluc2F0enBsYXR6MiAgICAgIEtFUCAgV0lUSCAoUkVBRFVOQ09NTUlUV" +
                        "EVEKSBPTiBLRVAuS2FFaW5zYXR6cGxhdHpJRCA9IEFNTS5LYUVpbnNhdHpwbGF0eklEDQogIExFRlQgS" +
                        "k9JTiBkYm8udndQZXJzb24gICAgICAgICAgICAgUFJTICBXSVRIIChSRUFEVU5DT01NSVRURUQpIE9OI" +
                        "FBSUy5CYVBlcnNvbklEID0gQU1NLkJhUGVyc29uSUQNCiAgTEVGVCBKT0lOIGRiby5LYUVpbnNhdHogI" +
                        "CAgICAgICAgICBLQUUgIFdJVEggKFJFQURVTkNPTU1JVFRFRCkgT04gS0FFLkthRWluc2F0eklEID0gQ" +
                        "U1NLkthRWluc2F0eklEDQogIExFRlQgSk9JTiBkYm8udndJbnN0aXR1dGlvbiAgICAgICAgT1JHICBXS" +
                        "VRIIChSRUFEVU5DT01NSVRURUQpIE9OIE9SRy5CYUluc3RpdHV0aW9uSUQgPSBLQUUuQUxLYXNzZUlED" +
                        "QogIExFRlQgSk9JTiBkYm8uWFVzZXIgICAgICAgICAgICAgICAgWFVSMSBXSVRIIChSRUFEVU5DT01NS" +
                        "VRURUQpIE9OIFhVUjEuVXNlcklEID0gLUtBRS5adXdlaXNlcklECQkNCiAgTEVGVCBKT0lOIGRiby5CY" +
                        "Uluc3RpdHV0aW9uS29udGFrdCBPS08gIFdJVEggKFJFQURVTkNPTU1JVFRFRCkgT04gT0tPLkJhSW5zd" +
                        "Gl0dXRpb25Lb250YWt0SUQgPSBLQUUuWnV3ZWlzZXJJRA0KICBMRUZUIEpPSU4gZGJvLkJhSW5zdGl0d" +
                        "XRpb24gICAgICAgIE9SRzEgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKSBPTiBPUkcxLkJhSW5zdGl0dXRpb" +
                        "25JRCA9IE9LTy5CYUluc3RpdHV0aW9uSUQJDQogIExFRlQgSk9JTiBkYm8uWE9yZ1VuaXRfVXNlciAgI" +
                        "CAgICAgT1VVICBXSVRIIChSRUFEVU5DT01NSVRURUQpIE9OIE9VVS5Vc2VySUQgPSAtS0FFLlp1d2Vpc" +
                        "2VySUQgYW5kIChPVVUuT3JnVW5pdE1lbWJlckNvZGUgPSAxIE9SIE9VVS5PcmdVbml0TWVtYmVyQ29kZ" +
                        "SA9IDIpDQogIExFRlQgSk9JTiBkYm8uWE9yZ1VuaXQgICAgICAgICAgICAgWE9VICBXSVRIIChSRUFEV" +
                        "U5DT01NSVRURUQpIE9OIFhPVS5PcmdVbml0SUQgPSBPVVUuT3JnVW5pdElEDQogIExFRlQgSk9JTiBkY" +
                        "m8uS2FadXRlaWxGYWNoYmVyZWljaCAgS1pGICBXSVRIIChSRUFEVU5DT01NSVRURUQpIE9OIEtaRi5LY" +
                        "Vp1dGVpbEZhY2hiZXJlaWNoSUQgPSAoU0VMRUNUIFRPUCAxIEthWnV0ZWlsRmFjaGJlcmVpY2hJRA0KI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBGUk9NIGRiby5LYVp1dGVpbEZhY2hiZ" +
                        "XJlaWNoIFdJVEggKFJFQURVTkNPTU1JVFRFRCkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgV0hFUkUgQmFQZXJzb25JRCA9IEFNTS5CYVBlcnNvbklEDQogICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgQU5EIFp1dGVpbHVuZ1ZvbiA8IEtBRS5EYXR1bUJpcw0KICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBPUkRFUiBCWSBadXRlaWx1bmdWb24gREVTQ" +
                        "ykNCiAgIExFRlQgSk9JTiBkYm8uWFVzZXIgWFVSIFdJVEggKFJFQURVTkNPTU1JVFRFRCkgT04gWFVSL" +
                        "lVzZXJJRCA9IEtaRi5adXN0YWVuZGlnS2FJRA0KV0hFUkUgQU1NLkJhUGVyc29uSUQgPSBudWxsDQogI" +
                        "CBBTkQgQU1NLkthRWluc2F0eklEID0gbnVsbA0KICAgQU5EIEFNTS5LYUFtbUJlc2NoSUQgPSBudWxsO" +
                        "wHSAlJlaWNoZW4gU2llIGRpZSB1bnRlcnNjaHJpZWJlbmUgQU1NLUJlc2NoZWluaWd1bmcgc29mb3J0I" +
                        "G5hY2ggRWluc2F0emVuZGUgb2RlciwgYmVpIG1vbmF0c8O8YmVyZ3JlaWZlbmRlbiBFaW5zw6R0emVuL" +
                        "CBiaXMgc3DDpHRlc3RlbnMgYW0gZHJpdHRlbiBXZXJrdGFnIGRlcyBGb2xnZW1vbmF0cyBiZWkgZGVyI" +
                        "EFyYmVpdHNsb3Nlbmthc3NlIGRlciBSQVYtS3VuZGluIGVpbi4gQmVhY2h0ZW4gU2llOiBEaWUgQXVze" +
                        "mFobHVuZyB2b24gVGFnZ2VsZGVybiBhbiBkaWUgUkFWLUt1bmRpbiB2ZXJ6w7ZnZXJ0IHNpY2gsIHdlb" +
                        "m4gZGllIEJlc2NoZWluaWd1bmcgdmVyc3DDpHRldCBlaW50cmlmZnQuQAABAAAA/////wEAAAAAAAAAD" +
                        "AIAAABRU3lzdGVtLkRyYXdpbmcsIFZlcnNpb249NC4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsa" +
                        "WNLZXlUb2tlbj1iMDNmNWY3ZjExZDUwYTNhBQEAAAAVU3lzdGVtLkRyYXdpbmcuQml0bWFwAQAAAAREY" +
                        "XRhBwICAAAACQMAAAAPAwAAAOIpAAACiVBORw0KGgoAAAANSUhEUgAAAswAAAERCAIAAADg+2YhAAAAA" +
                        "XNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAAHdElNRQfdDBINN" +
                        "BoTBE6aAAAAB3RFWHRBdXRob3IAqa7MSAAAAAx0RVh0RGVzY3JpcHRpb24AEwkhIwAAAAp0RVh0Q29we" +
                        "XJpZ2h0AKwPzDoAAAAOdEVYdENyZWF0aW9uIHRpbWUANfcPCQAAAAl0RVh0U29mdHdhcmUAXXD/OgAAA" +
                        "At0RVh0RGlzY2xhaW1lcgC3wLSPAAAACHRFWHRXYXJuaW5nAMAb5ocAAAAHdEVYdFNvdXJjZQD1/4PrA" +
                        "AAACHRFWHRDb21tZW50APbMlr8AAAAGdEVYdFRpdGxlAKju0icAACiQSURBVHhe7d1ByNxH/cfxhn/FS" +
                        "ANGLNhDwRwCFixYsAeFHFLooYeKFQVz6CHFgj30EKGHCIUIPeTQQw49WCg0YoUeeqgQMEIkKY2QQ4QUc" +
                        "qwYIUKKFSrmEDGl/f/Y+eyXzf7mmcz3OzPpbvJ+HSTNzs5snpnMvn3y5Ml9nwMAAAxAZAAAgCGIDAAAM" +
                        "ASRAQAAhiAyAADAEEQGAAAYgsgAAABDEBkAAGAIIgMAAAxBZAAAgCGIDAAAMMRdGBmfffaZfrR5vqjXF" +
                        "lt3Ez6SQ19DzeRdXsBOk2zCR7hG4+vs+8ucZus74V2v44crO9Vt59+o/Rr60Yh9fOpt1EeyEp/JAOK28" +
                        "ff83Y0dATYKkdHfnb/malbk8r0D+CDjXnbPnn9+4xfcbZFR3uzKo9B+YjhzuDtwks24D8VWf5C38cUPf" +
                        "c38llmzTZHB5pXx8emr/uNpI3d6yrZvTZfXP/SD8EV9hPt+ZL6oX8Wm4eNwN+GPS0o46xiH04V7QeU55" +
                        "7fD3YrIAO4QrlFk3WUHg3OOVdsUGe+///5JpzfffPP69et6/q3+85//aNDMH/7wBw3y/Ia5dOmSnj/z4" +
                        "YcfalBX89d27do1Lbn4tetHix+fP39eg2ayrzw9/a9//Wsa0+viSJO7FF55zOnTpzX1rQqnpeCjjz7S8" +
                        "2fslc8/eoXT0p2W9JhOrJ7cyXQyNfXMO++8o0HVpqek584/sONe+XytwCsvmI6l5u1kp3NepifPTL81p" +
                        "kdXbxVTeOWxc144LQHTK8++7LDCfZ79mKfVC3dLGubS/bSMs02Rcfjw4fv8rly5ouffavp5jZg5ePCgB" +
                        "nkcO3ZMz5+ZzoQGDXbu3DktOTN99DRo5k6+cs3rUXjlMdP+auqZnU5LQfePeXda0mPadz25k+mjpKln9" +
                        "u3bp0HVpqfoyTMb/soLYtdOQeGcF+jJM7ELM3bOCx/zgMIrjyncirG7RSM8up+WcYiMjNj+ERk1NK8Hk" +
                        "dFIS3oQGYbISGIXJpFhCneLRnh0Py3jEBkZsf0jMmpoXg8io5GW9CAyDJGRxC5MIsMU7haN8Oh+WsYhM" +
                        "jJi+0dk1NC8HkRGIy3pQWQYIiOJXZhEhincLRrh0f20jENkZMT2j8iooXk9iIxGWtKDyDBERhK7MIkMU" +
                        "7hbNMKj+2kZh8jIiO0fkVFD83oQGY20pAeRYYiMJHZhEhmmcLdohEf30zIOkZER2z8io4bm9SAyGmlJD" +
                        "yLDEBlJ7MIkMkzhbtEIj+6nZRwiIyO2f0RGDc3rQWQ00pIeRIYhMpLYhUlkmMLdohEe3U/LOERGRmz/i" +
                        "IwamteDyGikJT2IDENkJLELk8gwhbtFIzy6n5ZxiIyM2P4RGTU0rweR0UhLehAZhshIYhcmkWEKd4tGe" +
                        "HQ/LeMQGRmx/SMyamheDyKjkZb0IDIMkZHELkwiwxTuFo3w6H5axiEyMmL7R2TU0LweREYjLelBZBgiI" +
                        "4ldmESGKdwtGuHR/bSMQ2RkxPaPyKiheT2IjEZa0oPIMERGErswiQxTuFs0wqP7aRmHyMiI7R+RUUPze" +
                        "hAZjbSkB5FhiIwkdmESGaZwt2iER/fTMg6RkRHbPyKjhub1IDIaaUkPIsMQGUnswiQyTOFu0QiP7qdlH" +
                        "CIjI7Z/REYNzetBZDTSkh5EhiEyktiFSWSYwt2iER7dT8s4REZGbP+IjBqa14PIaKQlPYgMQ2QksQuTy" +
                        "DCFu0UjPLqflnGIjIzY/hEZNTSvB5HRSEt6EBmGyEhiFyaRYQp3i0Z4dD8t4xAZGbH9IzJqaF4PIqORl" +
                        "vQgMgyRkcQuTCLDFO4WjfDoflrGITIyYvtHZNTQvB5ERiMt6UFkGCIjiV2YRIYp3C0a4dH9tIxDZGTE9" +
                        "o/IqKF5PYiMRlrSg8gwREYSuzCJDFO4WzTCo/tpGYfIyIjtH5FRQ/N6EBmNtKQHkWGIjCR2YRIZpnC3a" +
                        "IRH99MyDpGREds/IqOG5vUgMhppSQ8iwxAZSezCJDJM4W7RCI/up2UcIiMjtn9ERg3N60FkNNKSHkSGI" +
                        "TKS2IVJZJjC3aIRHt1PyzhERkZs/4iMGprXg8hopCU9iAxDZCSxC5PIMIW7RSM8up+WcYiMjNj+ERk1N" +
                        "K8HkdFIS3oQGYbISGIXJpFhCneLRnh0Py3jEBkZsf0jMmpoXg8io5GW9CAyDJGRxC5MIsMU7haN8Oh+W" +
                        "sYhMjJi+0dk1NC8HkRGIy3pQWQYIiOJXZhEhincLRrh0f20jENkZMT2j8iooXk9iIxGWtKDyDBERhK7M" +
                        "IkMU7hbNMKj+2kZh8jIiO0fkVFD83oQGY20pAeRYYiMJHZhEhmmcLdohEf30zIOkZER2z8io4bm9SAyG" +
                        "mlJDyLDEBlJ7MIkMkzhbtEIj+6nZRwiIyO2f0RGDc3rQWQ00pIeRIYhMpLYhUlkmMLdohEe3U/LOERGR" +
                        "mz/iIwamteDyGikJT2IDENkJLELk8gwhbtFIzy6n5ZxiIyM2P4RGTU0rweR0UhLehAZhshIYhcmkWEKd" +
                        "4tGeHQ/LeMQGRmx/SMyamheDyKjkZb0IDIMkZHELkwiwxTuFo3w6H5axiEyMmL7R2TU0LweREYjLelBZ" +
                        "BgiI4ldmESGKdwtGuHR/bSMQ2RkxPaPyKiheT2IjEZa0oPIMERGErswiQxTuFs0wqP7aRmHyMiI7R+RU" +
                        "UPzehAZjbSkB5FhiIwkdmESGaZwt2iER/fTMg6RkRHbPyKjhub1IDIaaUkPIsMQGUnswiQyTOFu0QiP7" +
                        "qdlHCIjI7Z/REYNzetBZDTSkh5EhiEyktiFSWSYwt2iER7dT8s4REZGbP+IjBqa14PIaKQlPYgMQ2Qks" +
                        "QuTyDCFu0UjPLqflnGIjIzY/hEZNTSvB5HRSEt6EBmGyEhiFyaRYQp3i0Z4dD8t4xAZGbH9IzJqaF4PI" +
                        "qORlvQgMgyRkcQuTCLDFO4WjfDoflrGITIyYvtHZNTQvB5ERiMt6UFkGCIjiV2YRIYp3C0a4dH9tIxDZ" +
                        "GTE9o/IqKF5PYiMRlrSg8gwREYSuzCJDFO4WzTCo/tpGYfIyIjtH5FRQ/N6EBmNtKQHkWGIjCR2YRIZp" +
                        "nC3aIRH99MyDpGREds/IqOG5vUgMhppSQ8iwxAZSezCJDJM4W7RCI/up2UcIiMjtn9ERg3N60FkNNKSH" +
                        "kSGITKS2IVJZJjC3aIRHt1PyzhERkZs/4iMGprXg8hopCU9iAxDZCSxC5PIMIW7RSM8up+WcYiMjNj+E" +
                        "Rk1NK8HkdFIS3oQGYbISGIXJpFhCneLRnh0Py3jEBkZsf0jMmpoXg8io5GW9CAyDJGRxC5MIsMU7haN8" +
                        "Oh+WsYhMjJi+0dk1NC8HkRGIy3pQWQYIiOJXZhEhincLRrh0f20jENkZMT2j8iooXk9iIxGWtKDyDBER" +
                        "hK7MIkMU7hbNMKj+2kZh8jIiO0fkVFD83oQGY20pAeRYYiMJHZhEhmmcLdohEf30zIOkZER2z8io4bm9" +
                        "SAyGmlJDyLDEBlJ7MIkMkzhbtEIj+6nZRwiIyO2f0RGDc3rQWQ00pIeRIYhMpLYhUlkmMLdohEe3U/LO" +
                        "ERGRmz/iIwamteDyGikJT2IDENkJLELk8gwhbtFIzy6n5ZxiIyM2P4RGTU0rweR0UhLehAZhshIYhcmk" +
                        "WEKd4tGeHQ/LeMQGRmx/SMyamheDyKjkZb0IDIMkZHELkwiwxTuFo3w6H5axiEyMmL7R2TU0LweREYjL" +
                        "elBZBgiI4ldmESGKdwtGuHR/bSMQ2RkxPaPyKiheT2IjEZa0oPIMERGErswiQxTuFs0wqP7aRmHyMiI7" +
                        "R+RUUPzehAZjbSkB5FhiIwkdmESGaZwt2iER/fTMg6RkRHbPyKjhub1IDIaaUkPIsMQGUnswiQyTOFu0" +
                        "QiP7qdlHCIjI7Z/REYNzetBZDTSkh5EhiEyktiFSWSYwt2iER7dT8s4REZGbP+IjBqa14PIaKQlPYgMQ" +
                        "2QksQuTyDCFu0UjPLqflnGIjIzY/hEZNTSvB5HRSEt6EBmGyEhiFyaRYQp3i0Z4dD8t4xAZGbH9IzJqa" +
                        "F4PIqORlvQgMgyRkcQuTCLDFO4WjfDoflrGITIyYvtHZNTQvB5ERiMt6UFkGCIjiV2YRIYp3C0a4dH9t" +
                        "IxDZGTE9o/IqKF5PYiMRlrSg8gwREYSuzCJDFO4WzTCo/tpGYfIyIjtH5FRQ/N6EBmNtKQHkWGIjCR2Y" +
                        "RIZpnC3aIRH99MyDpGREds/IqOG5vUgMhppSQ8iwxAZSezCJDJM4W7RCI/up2UcIiMjtn9ERg3N60FkN" +
                        "NKSHkSGITKS2IVJZJjC3aIRHt1PyzhERkZs/4iMGprXg8hopCU9iAxDZCSxC5PIMIW7RSM8up+WcYiMj" +
                        "Nj+ERk1NK8HkdFIS3oQGYbISGIXJpFhCneLRnh0Py3jEBkZsf0jMmpoXg8io5GW9CAyDJGRxC5MIsMU7" +
                        "haN8Oh+WsYhMjJi+0dk1NC8HkRGIy3pQWQYIiOJXZhEhincLRrh0f20jENkZMT2j8iooXk9iIxGWtKDy" +
                        "DBERhK7MIkMU7hbNMKj+2kZh8jIiO0fkVFD83oQGY20pAeRYYiMJHZhEhmmcLdohEf30zIOkZER2z8io" +
                        "4bm9SAyGmlJDyLDEBlJ7MIkMkzhbtEIj+6nZRwiIyO2f0RGDc3rQWQ00pIeRIYhMpLYhUlkmMLdohEe3" +
                        "U/LOERGRmz/iIwamteDyGikJT2IDENkJLELk8gwhbtFIzy6n5ZxiIyM2P4RGTU0rweR0UhLehAZhshIY" +
                        "hcmkWEKd4tGeHQ/LeMQGRmx/SMyamheDyKjkZb0IDIMkZHELkwiwxTuFo3w6H5axiEyMmL7R2TU0LweR" +
                        "EYjLelBZBgiI4ldmESGKdwtGuHR/bSMQ2RkxPaPyKiheT2IjEZa0oPIMERGErswiQxTuFs0wqP7aRmHy" +
                        "MiI7R+RUUPzehAZjbSkB5FhiIwkdmESGaZwt2iER/fTMg6RkRHbPyKjhub1IDIaaUkPIsMQGUnswiQyT" +
                        "OFu0QiP7qdlHCIjI7Z/REYNzetBZDTSkh5EhiEyktiFSWSYwt2iER7dT8s4REZGbP+IjBqa14PIaKQlP" +
                        "YgMQ2QksQuTyDCFu0UjPLqflnGIjIzY/hEZNTSvB5HRSEt6EBmGyEhiFyaRYQp3i0Z4dD8t4xAZGbH9I" +
                        "zJqaF4PIqORlvQgMgyRkcQuTCLDFO4WjfDoflrGITIyYvtHZNTQvB5ERiMt6UFkGCIjiV2YRIYp3C0a4" +
                        "dH9tIxDZGTE9o/IqKF5PYiMRlrSg8gwREYSuzCJDFO4WzTCo/tpGYfIyIjtH5FRQ/N6EBmNtKQHkWGIj" +
                        "CR2YRIZpnC3aIRH99MyDpGREds/IqOG5vUgMhppSQ8iwxAZSezCJDJM4W7RCI/up2UcIiMjtn9ERg3N6" +
                        "0FkNNKSHkSGITKS2IVJZJjC3aIRHt1PyzhERkZs/4iMGprXg8hopCU9iAxDZCSxC5PIMIW7RSM8up+Wc" +
                        "YiMjNj+ERk1NK8HkdFIS3oQGYbISGIXJpFhCneLRnh0Py3jEBkZsf0jMmpoXg8io5GW9CAyDJGRxC5MI" +
                        "sMU7haN8Oh+WsYhMjJi+0dk1NC8HkRGIy3pQWQYIiOJXZhEhincLRrh0f20jENkZMT2j8iooXk9iIxGW" +
                        "tKDyDBERhK7MIkMU7hbNMKj+2kZh8jIiO0fkVFD83oQGY20pAeRYYiMJHZhEhmmcLdohEf30zIOkZER2" +
                        "z8io4bm9SAyGmlJDyLDEBlJ7MIkMkzhbtEIj+6nZRwiIyO2f0RGDc3rQWQ00pIeRIYhMpLYhUlkmMLdo" +
                        "hEe3U/LOERGRmz/iIwamteDyGikJT2IDENkJLELk8gwhbtFIzy6n5ZxiIyM2P4RGTU0rweR0UhLehAZh" +
                        "shIYhcmkWEKd4tGeHQ/LeMQGRmx/SMyamheDyKjkZb0IDIMkZHELkwiwxTuFo3w6H5axiEyMmL7R2TU0" +
                        "LweREYjLelBZBgiI4ldmESGKdwtGuHR/bSMQ2RkxPaPyKiheT2IjEZa0oPIMERGErswiQxTuFs0wqP7a" +
                        "RmHyMiI7R+RUUPzehAZjbSkB5FhiIwkdmESGaZwt2iER/fTMg6RkRHbPyKjhub1IDIaaUkPIsMQGUnsw" +
                        "iQyTOFu0QiP7qdlHCIjI7Z/REYNzetBZDTSkh5EhiEyktiFSWSYwt2iER7dT8s4REZGbP+IjBqa14PIa" +
                        "KQlPYgMQ2QksQuTyDCFu0UjPLqflnGIjIzY/hEZNTSvB5HRSEt6EBmGyEhiFyaRYQp3i0Z4dD8t4xAZG" +
                        "bH9IzJqaF4PIqORlvQgMgyRkcQuTCLDFO4WjfDoflrGITIyYvtHZNTQvB5ERiMt6UFkGCIjiV2YRIYp3" +
                        "C0a4dH9tIxDZGTE9o/IqKF5PYiMRlrSg8gwREYSuzCJDFO4WzTCo/tpGYfIyIjtH5FRQ/N6EBmNtKQHk" +
                        "WGIjCR2YRIZpnC3aIRH99MyDpGREds/IqOG5vUgMhppSQ8iwxAZSezCJDJM4W7RCI/up2UcIiMjtn9ER" +
                        "g3N60FkNNKSHkSGITKS2IVJZJjC3aIRHt1PyzhERkZs/4iMGprXg8hopCU9iAxDZCSxC5PIMIW7RSM8u" +
                        "p+WcYiMjNj+ERk1NK8HkdFIS3oQGYbISGIXJpFhCneLRnh0Py3jEBkZsf0jMmpoXg8io5GW9CAyDJGRx" +
                        "C5MIsMU7haN8Oh+WsYhMjJi+0dk1NC8HkRGIy3pQWQYIiOJXZhEhincLRrh0f20jENkZMT2j8iooXk9i" +
                        "IxGWtKDyDBERhK7MIkMU7hbNMKj+2kZh8jIiO0fkVFD83oQGY20pAeRYYiMJHZhEhmmcLdohEf30zIOk" +
                        "ZER2z8io4bm9SAyGmlJDyLDEBlJ7MIkMkzhbtEIj+6nZRwiIyO2f0RGDc3rQWQ00pIeRIYhMpLYhUlkm" +
                        "MLdohEe3U/LOERGRmz/iIwamteDyGikJT2IDENkJLELk8gwhbtFIzy6n5ZxiIyM2P4RGTU0rweR0UhLe" +
                        "hAZhshIYhcmkWEKd4tGeHQ/LeMQGRmx/SMyamheDyKjkZb0IDIMkZHELkwiwxTuFo3w6H5axiEyMmL7R" +
                        "2TU0LweREYjLelBZBgiI4ldmESGKdwtGuHR/bSMQ2RkxPaPyKiheT2IjEZa0oPIMERGErswiQxTuFs0w" +
                        "qP7aRmHyMiI7R+RUUPzehAZjbSkB5FhiIwkdmESGaZwt2iER/fTMg6RkRHbPyKjhub1IDIaaUkPIsMQG" +
                        "UnswiQyTOFu0QiP7qdlHCIjI7Z/REYNzetBZDTSkh5EhiEyktiFSWSYwt2iER7dT8s4REZGbP+IjBqa1" +
                        "4PIaKQlPYgMQ2QksQuTyDCFu0UjPLqflnGIjIzY/hEZNTSvB5HRSEt6EBmGyEhiFyaRYQp3i0Z4dD8t4" +
                        "xAZGbH9IzJqaF4PIqORlvQgMgyRkcQuTCLDFO4WjfDoflrGITIyYvtHZNTQvB5ERiMt6UFkGCIjiV2YR" +
                        "IYp3C0a4dH9tIxDZGTE9o/IqKF5PYiMRlrSg8gwREYSuzCJDFO4WzTCo/tpGYfIyIjtH5FRQ/N6EBmNt" +
                        "KQHkWGIjCR2YRIZpnC3aIRH99MyDpGREds/IqOG5vUgMhppSQ8iwxAZSezCJDJM4W7RCI/up2UcIiMjt" +
                        "n9ERg3N60FkNNKSHkSGITKS2IVJZJjC3aIRHt1PyzhERkZs/4iMGprXg8hopCU9iAxDZCSxC5PIMIW7R" +
                        "SM8up+WcYiMjNj+ERk1NK8HkdFIS3oQGYbISGIXJpFhCneLRnh0Py3jEBkZsf0jMmpoXg8io5GW9CAyD" +
                        "JGRxC5MIsMU7haN8Oh+WsYhMjJi+0dk1NC8HkRGIy3pQWQYIiOJXZhEhincLRrh0f20jENkZMT2j8ioo" +
                        "Xk9iIxGWtKDyDBERhK7MIkMU7hbNMKj+2kZh8jIiO0fkVFD83oQGY20pAeRYYiMJHZhEhmmcLdohEf30" +
                        "zIOkZER2z8io4bm9SAyGmlJDyLDEBlJ7MIkMkzhbtEIj+6nZRwiIyO2f0RGDc3rQWQ00pIeRIYhMpLYh" +
                        "UlkmMLdohEe3U/LOERGRmz/iIwamteDyGikJT2IDENkJLELk8gwhbtFIzy6n5ZxiIyM2P4RGTU0rweR0" +
                        "UhLehAZhshIYhcmkWEKd4tGeHQ/LeMQGRmx/SMyamheDyKjkZb0IDIMkZHELkwiwxTuFo3w6H5axiEyM" +
                        "mL7R2TU0LweREYjLelBZBgiI4ldmESGKdwtGuHR/bSMQ2RkxPaPyKiheT2IjEZa0oPIMERGErswiQxTu" +
                        "Fs0wqP7aRmHyMiI7R+RUUPzehAZjbSkB5FhiIwkdmESGaZwt2iER/fTMg6RkRHbPyKjhub1IDIaaUkPI" +
                        "sMQGUnswiQyTOFu0QiP7qdlHCIjI7Z/REYNzetBZDTSkh5EhiEyktiFSWSYwt2iER7dT8s4REZGbP+Ij" +
                        "Bqa14PIaKQlPYgMQ2QksQuTyDCFu0UjPLqflnGIjIzY/hEZNTSvB5HRSEt6EBmGyEhiFyaRYQp3i0Z4d" +
                        "D8t4xAZGbH9IzJqaF4PIqORlvQgMgyRkcQuTCLDFO4WjfDoflrGITIyYvtHZNTQvB5ERiMt6UFkGCIji" +
                        "V2YRIYp3C0a4dH9tIxDZGTE9o/IqKF5PYiMRlrSg8gwREYSuzCJDFO4WzTCo/tpGYfIyIjtH5FRQ/N6E" +
                        "BmNtKQHkWGIjCR2YRIZpnC3aIRH99MyDpGREds/IqOG5vUgMhppSQ8iwxAZSezCJDJM4W7RCI/up2UcI" +
                        "iMjtn9ERg3N60FkNNKSHkSGITKS2IVJZJjC3aIRHt1PyzhERkZs/4iMGprXg8hopCU9iAxDZCSxC5PIM" +
                        "IW7RSM8up+WcYiMjNj+ERk1NK8HkdFIS3oQGYbISGIXJpFhCneLRnh0Py3jEBkZsf0jMmpoXg8io5GW9" +
                        "CAyDJGRxC5MIsMU7haN8Oh+WsYhMjJi+0dk1NC8HkRGIy3pQWQYIiOJXZhEhincLRrh0f20jENkZMT2j" +
                        "8iooXk9iIxGWtKDyDBERhK7MIkMU7hbNMKj+2kZh8jIiO0fkVFD83oQGY20pAeRYYiMJHZhEhmmcLdoh" +
                        "Ef30zIOkZER2z8io4bm9SAyGmlJDyLDEBlJ7MIkMkzhbtEIj+6nZRwiIyO2f0RGDc3rQWQ00pIeRIYhM" +
                        "pLYhUlkmMLdohEe3U/LONsUGc8995w+wB5///vf9fxb/e1vf9OImdj+zX877dq1K/1gGyMjvfjf/OY3G" +
                        "tRJmtxl2yPjs88+SyNXERmGyEi6v20UznmBnrywenTnb9V2vxVeueuc24R9I2N6C0jTNqq5z+1jboPN6" +
                        "t2ydidohEf30zLONkXGdGVPH9z55pXt9LYx/z1jsvuXfatY9atf/UrPn9miyFj78HZ/5ZrX445FxvRrb" +
                        "4mM+cms/JiPpiU9iAyTfeXpNlh95d57aa7728ZO57xMT57xXphJ7Jz3jYzCK4+piYy5wt2iER7dT8s42" +
                        "xcZlez3/E6fyYj9niko/HbaoshYswmR8dxzz+nJndhFMH9jaImMOSLDrL1trCb7NkZGEnjlBd3fNgrnv" +
                        "EBPntneyLDPZLSHYPIFRob9ErqflnG2KTKOHz8+fWQLnnjiCf1oxbVr1/T8W00/rxEzR44c0SCP6eSlp" +
                        "9vLsB+cPn36tp8I6eLSpUur666aPnoaNGOvfG565RrUieb1KLzymGl/NfXMTqel4IMPPtCTZ2If8+60p" +
                        "Me073pyJ9PJ1NQzP/3pTzWo2qFDh6YnZn9P3clXPr0MDeohdu0UFM55gZ4889FHH2nETOGVx8554WMek" +
                        "L3qs5dkWc19XviYTx9ADZrRCI/up2WcrYmMO/MmPchWv/jJtr9+bJrtPVF9Xzm/s9akD8iGf1jYNZdNj" +
                        "4zu22kT3oGDstVnkd9IAXffB41jMOGDMNS2fHg5BjHb8ZkMdvdeM+34Hdt0ThfuBX3PeZqN3ztZIz442" +
                        "/uh3qavycBO+K3uMvTDxV6U2cdnxAeKD/4qPhp3sS3aXCIDAAAMQWQAAIAhiAwAADAEkQEAAIYgMgAAw" +
                        "BBEBgAAGILIAAAAQxAZAABgCCIDwHZI34Bo9X/X8O2ngE1DZABb7+rVq1dudePGjY19x+3+wmgLYGMRG" +
                        "cB2u3bt2le+8pX7bnXy5Ek9vJEO9/Dcc8/pR4cP//nPf9bUADYJkQFstxMnTqgsVnz3u9+9efOmRmwev" +
                        "coedu3aNf3vhkcVcM8iMoDttn///vR2u+bChQsasXn0EqNSWKwiMoDNRGQAW+z8+fN6m505fPiwBm2Yz" +
                        "z77TC+xHyID2ExEBrDFnn/+eb3N3nff1772tQcffFD/cd99u3fv/uijjzRuw+gldnL//fdv8qdtgHsZk" +
                        "QFsq+vXr+/du1fvtPfdd+DAgcOHD+s/Fo4dO6ahG+bkyZNvvvnm9L8BP/zhD/XLW3rjjTemOfk7JsAGI" +
                        "jKAbTW9ueptduGFF17405/+pP9YeOSRRz799FONXlHzftzxPbt9Kpvh3Llzu3fv1i9v4ciRI+khABuIy" +
                        "AC21fe+9z290y689dZbN27cWP0Tk8mZM2c0usEX+EmC1aWvXr36jW98I/260td+Th+BbEUB2BBEBrCVL" +
                        "l++/KUvfSm9406m/39/7dq16edXv0pj8vTTT6fxMbG8GBQla1G1Z8+ef/zjH3oMwEYiMoCtdPToUb3ZL" +
                        "jz55JPprf3s2bP6qaUUH3dY386YZnv11Vf161l666239PDSoLgBEEZkANvn5s2bDz/8sN5sF06cOKHHP" +
                        "v983759+tmFl156SQ/0cPXq1QsXLpw7d+7SpUvTj/Wzva3lwsWLF1e/FGPXrl3PPvtseoiwADYZkQFsn" +
                        "7ffflvvtwtf/vKXVz9d8cILL+iBhQceeODGjRt6LOrUqVPTtGtlM9m/f/8UMR9//LHGff75u+++e2yFf" +
                        "rbBVFSPPfbYtJZ9D669e/eurghgYxEZwPZ56qmn0tttet+d/lMPLFy6dCk9at555x095nfx4sXHH39cE" +
                        "+1getd/9dVX0zcyX/trtGmSFq+88ormWkp/Z9XwyQxgYxEZwJa5evXq/fffr/fbhXlDPProo3ps4cknn" +
                        "5x+MvBmfPz48bW1Cqa8mDqjJTLmr/DDDz9c+zurBw4c2OR/lgXAKiID2DLTG7/ebxf27Nkzf9Nd+xYak" +
                        "4sXL+qxavNPISQPPPDAvgX994qjR4/2jYxnnnlGEy395S9/0WMANh6RAWyZRx55RO+3C88//7weWHH9+" +
                        "vW1r5R0fdOq6c3+nXfe0ZNXHDx48PTp0/YVHlevXn311VfXvlBj7T/TyJgpjOzzKOkPhl588UU9BmAbE" +
                        "BnAdkj/L//cuXP29Y/J5cuX04A1hw4d0oiFBx98cCoPPXY7n3zyyUMPPaRnLr322mt6eMX0qqZp19Zap" +
                        "XEhBw4c0CyLyNizZ8+4v88CYAQiA9gma38Y8cgjj+iBmYsXL2rQUrYSsl5++WU9Z+n111/XYzvYqTP0s" +
                        "EfKqVOnTmmKpePHj68OALD5iAxga1y/fn36f/N6y104evSoHsvZv3+/xi08/vjjeqBoWuWrX/2qnrMwB" +
                        "YQeW7H2Tn/jxo30HTnXPtGihz3SzOlrV222vXv3fvLJJ2kAgG1BZACba+2N/OTJk+kd11y5ckWP5cw/I" +
                        "XH+/Hk9trO1b8Kxe/fuyj+kmCaf/1UUPVZh9Rd75swZPX/ZGa+88ooeA7A9iAxgC6Q34LXvV3HgwIH06" +
                        "E6uXbu29q7/k5/8RI/t7Ac/+IFGLxw+fFgPLKymwFoDTdI38Fj9ZIYecHryySf1/IU9e/bUf0EJgM1BZ" +
                        "AAbzd7I599i6+23304PFUzv1qtv+VNzlL9X5v/+97+9e/dq9MLJkyf1WIXf/e5301MaI+Py5ctrbVT+U" +
                        "yEAG4vIALbDkSNH0jtueguf/s/9f//7Xz22s9/+9rfpWca+fDJrnjI7/e2VNSmG/vnPf+ppS+lRl7Vvi" +
                        "z4FB3+pBNhSRAawBW7evPnggw/qXXdh7U8xdjI90f4yaqqThx9+uPAdM3//+9+nwUn2O33Nrf65SeP3y" +
                        "ZiWW/tUyjPPPKPHAGwbIgPYXPbmPf/WWCdOnDg389577+lHS2fPnrV/6MS8++67adq5aVoNWkTJvn379" +
                        "EC1J554Qs9f0M9We+utt/TMpdOnT+sxANuGyAC2wNq/iNbo6aef1rwzx44d06CF235t6dzaN8zQz1abX" +
                        "pueubB///6aT6UA2ExEBrDp5v8iWjv78s+1vyGyFhkHDx7UA9Va/u2S6Ve69s+hvfzyy3psxdprBrCxi" +
                        "Axg0639i2g7cX2S48SJE5p98Z5tb9tfbGR0+XfdAGwOIgPYdGv/Itpt1dTGo48+mv1jiNWvyZg89thje" +
                        "uB2LFNaImPt31zd6UUC2BZEBrDR/vjHP+otd+mll17SV3Xu7OzZs+kH9qWg3//+9/X8pTNnzkzzWxwka" +
                        "9/u86GHHtID1dI3Fzf62QpTT6x9O/PpV6rH+CMSYDsRGcBGW/s6yvvvv//DDz/UY0s1b8Dzv5/yox/9S" +
                        "I+tuHDhgh5eunbtmh6rs/ZFFfrZnLWXPZWQnrM0ZRBtAWw1IgPYFPM31OvXr6+9Zz/11FN6zOnm7DttT" +
                        "L0yD4hp2NoXmRb+vuvcNKGetqQHctZ+vfYvraQ/7pl+4fyLaMC2IzKAzfXrX/86ve+amm8lnjW9o//iF" +
                        "7/QLEurfx5h1r6vRnbMTtKftqx+UYgeqLC2buBvzwLYNEQGsLmmN1q95S7s2bPn3//+tx6r+1OSVZcuX" +
                        "Vr7LEX2u3++9tprenih8B1C5y9g/o2/9ECF3bt3r9bJL3/5Sz0AYGsRGcCGev/99/V+u1T5rcQLDh48q" +
                        "LmW5v/+2ccff7zWIqt/3zXJ9k3LP/V++fJlPWHp1KlTegzA1iIygA31/PPP6/12Kf19kBZTUmiupeyfS" +
                        "jz77LN6eGH37t0XLlzQYzv45JNP9u/fryes0MO3s/a3WibeLzgFsIGIDGATffrpp2tfpzn9Z/pjC++fk" +
                        "qyaUmDtK0knH3zwgR5eunLlyuqwXbt27d27N/tXXpNp2scff1yjb6URt7P2TcCmX6weALDNiAxgE6W/c" +
                        "br6NQrzL8D01kYav/YNryY///nP04BV9l257DX83//935QC87/xcfr06W9+85tpzJwG3c6Pf/xjPWGBr" +
                        "/oE7g5EBrCJ5ilw6dIlPdbm3Xff1YxLX//6169fv66HV8z/vGayZ8+e6bW9/PLLU3AcOXLkO9/5jh7Yg" +
                        "ea6nW9961vT4CloUtM8++yzegDANiMygI0z/3fCvv3tb+uxHh599FHNu/Taa6/psVtlO2Mn02t+6aWX9" +
                        "B9Lmuh2pnbRExZcf28WwMYiMoAv3toffBw9elRvtkvHjx+ffr7lqzFWzf/FtcK/UfLGG2/s3btX43LS5" +
                        "x4eeuih06dPz79rp2YpunHjhkYvvf7663oMwDYjMoCN8/DDD+vNdunq1at6rIfsvx1f+CujH3/88ZEjR" +
                        "9a+ENXs3r37xRdfTF+rEYuMK1euaPRS+HuOAdgoRAawcaY33TV6IGr+KZCpMzT10lQJa8PW/vPGjRvTe" +
                        "/9UG4cOHTp48OBTTz31s5/97OTJk//617+mR9PgWGTcvHlTL2Ip+zUiALYOkQFskF5/IPJFSZGR/gAl0" +
                        "QMA7klcAcBGG5cd5c9bzNW8kthnMgDcrbgCAEh70BAZAFZxBQDohsgAsIorAEA3RAaAVVwBALo5e/as4" +
                        "mJJD4z84hIAG4vIANANn8kAsIorAEA3RAaAVVwBALp57733FBdLegDAPYkrAEA3fCYDwCquAADdXLhwY" +
                        "d+t9ACAexKRAQAAhiAyAADAEEQGAAAYgsgAAABDEBkAAGAIIgMAAAzw+ef/D5DB41td+bLSAAAAAElFT" +
                        "kSuQmCCC0AAAQAAAP////8BAAAAAAAAAAwCAAAAUVN5c3RlbS5EcmF3aW5nLCBWZXJzaW9uPTQuMC4wL" +
                        "jAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49YjAzZjVmN2YxMWQ1MGEzYQUBAAAAFVN5c" +
                        "3RlbS5EcmF3aW5nLkJpdG1hcAEAAAAERGF0YQcCAgAAAAkDAAAADwMAAAC2kwAAAkJNtpMAAAAAAAA2A" +
                        "AAAKAAAAKAAAAA7AAAAAQAgAAAAAAAAAAAAxA4AAMQOAAAAAAAAAAAAAP///////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////////////////j4+P/8/" +
                        "Pz///////7+/v/////////////////+/v7//f39//7+/v///////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////z8/P/////////////////8/Pz///////T09P+np6f/vr6+/9HR0f/r6" +
                        "+v//////////////////v7+//v7+////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////////////////////9/" +
                        "f3///////39/f/////////////////Dw8P/Ly8v/xUVFf8pKSn/SUlJ/2xsbP+RkZH/tra2/9ra2v/x8" +
                        "fH//////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////7+/v//Pz8///////9/" +
                        "f3/9PT0//n5+f/4+Pj/+/v7//v7+//7+/v/+/v7//z8/P/8/Pz//Pz8//z8/P/8/Pz//Pz8//n5+f/z8" +
                        "/P//v7+//z8/P/4+Pj/9PT0//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/9PT0///////8/" +
                        "Pz/9/f3//7+/v/9/f3/+Pj4//n5+f/6+vr/+/v7//v7+//7+/v/+vr6//n5+f/6+vr/+/v7//Hx8f///" +
                        "/////////r6+v/39/f/+fn5///////4+Pj/+fn5//r6+v/39/f/9fX1///////v7+//+/v7//r6+v/6+" +
                        "vr/7u7u///////29vb/9/f3//f39//+/v7/9/f3//n5+f/5+fn/+fn5//n5+f/5+fn/+fn5//n5+f/5+" +
                        "fn/8/Pz//v7+//29vb///////Ly8v/8/Pz///////Dw8P/4+Pj/+fn5//n5+f/6+vr/+vr6//r6+v/6+" +
                        "vr/+vr6//39/f/29vb//Pz8//r6+v/9/f3//Pz8/////////////Pz8///////////////////////9/" +
                        "f3/r6+v/w8PD/8AAAD/AgIC/wQEBP8DAwP/BQUF/xEREf8mJib/Nzc3/2JiYv+NjY3/uLi4/9XV1f/l5" +
                        "eX/8PDw//z8/P//////+/v7//39/f////////////7+/v/8/Pz//f39//7+/v/6+vr/+vr6//39/f///" +
                        "//////////////29vb///////v7+//9/f3////////////////////////////+/v7//////////////" +
                        "/////////z8/P/4+Pj////////////29vb////////////39/f/sbGx/3p6ev+EhIT/e3t7/3d3d/93d" +
                        "3f/eHh4/3h4eP94eHj/eHh4/3l5ef95eXn/dHR0/3t7e/9/f3//enp6/2RkZP9kZGT/ampq/29vb/9oa" +
                        "Gj/aGho/2hoaP9oaGj/aGho/2hoaP9oaGj/aGho/2lpaf9kZGT/XFxc/3p6ev+CgoL/e3t7/3t7e/9/f" +
                        "3//eHh4/3l5ef96enr/eXl5/3l5ef94eHj/eHh4/3l5ef+CgoL/ZGRk/5iYmP/09PT////////////c3" +
                        "Nz/gICA/3BwcP9vb2//dnZ2/3Nzc/92dnb/c3Nz/3R0dP9xcXH/dXV1/25ubv92dnb/b29v/4CAgP9cX" +
                        "Fz/XFxc/2JiYv9kZGT/ZGRk/2RkZP9kZGT/ZGRk/2RkZP9kZGT/ZGRk/21tbf9oaGj/Y2Nj/2FhYf9iY" +
                        "mL/XV1d/2ZmZv9+fn7/bm5u/29vb/9wcHD/cHBw/3Fxcf9wcHD/cHBw/3BwcP9paWn/cnJy/2pqav90d" +
                        "HT/dnZ2/83Nzf//////+Pj4//7+/v/////////////////+/v7/+fn5/5OTk/8HBwf/AgIC/wMDA/8DA" +
                        "wP/AgIC/wAAAP8CAgL/BgYG/woKCv8ODg7/AAAA/xYWFv8dHR3/ODg4/2NjY/+Tk5P/np6e/9ra2v/j4" +
                        "+P/7+/v//n5+f////////////////////////////7+/v/9/f3/+vr6//v7+//+/v7//v7+/////////" +
                        "/////////7+/v/6+vr/+Pj4//r6+v/9/f3///////r6+v/6+vr//f39//////////////////39/f/39" +
                        "/f////////////+/v7/5+fn/4WFhf9gYGD/sLCw/729vf/AwMD/wMDA/8DAwP/AwMD/wMDA/8HBwf/Bw" +
                        "cH/wcHB/7+/v//BwcH/tbW1/46Ojv8iIiL/BAQE/wAAAP8AAAD/AwMD/wMDA/8DAwP/AwMD/wMDA/8DA" +
                        "wP/AwMD/wMDA/8PDw//BwcH/ysrK/+bm5v/uLi4/7S0tP+6urr/vLy8/729vf+9vb3/vb29/729vf+9v" +
                        "b3/vLy8/7y8vP+7u7v/srKy/zMzM/9kZGT/7u7u//v7+//6+vr/1NTU/0FBQf+Tk5P/rq6u/7u7u/+3t" +
                        "7f/srKy/76+vv+2trb/srKy/7m5uf+8vLz/tLS0/62trf+2trb/UVFR/w8PD/8ODg7/AgIC/wICAv8CA" +
                        "gL/AgIC/wICAv8CAgL/AgIC/wICAv8BAQH/AAAA/woKCv8AAAD/CQkJ/woKCv9XV1f/tLS0/7i4uP+5u" +
                        "bn/ubm5/7q6uv+6urr/urq6/7q6uv+5ubn/tLS0/8nJyf+4uLj/o6Oj/1RUVP/ExMT///////v7+////" +
                        "/////////7+/v/+/v7//f39//Ly8v9paWn/AAAA/wMDA/8BAQH/AAAA/wEBAf8CAgL/AQEB/wAAAP8AA" +
                        "AD/BAQE/wAAAP8FBQX/BQUF/xISEv9UVFT/ZWVl/0xMTP8qKir/PDw8/1tbW/+BgYH/qqqq/9DQ0P/u7" +
                        "u7///////n5+f/29vb//f39///////////////////////5+fn/+fn5//z8/P///////////////////" +
                        "//////////////////////////////7+/v/+Pj4//v7+/////////////39/f//////+vr6//Pz8/+Sk" +
                        "pL/f39///r6+v///////f39//39/f/9/f3//f39//39/f/+/v7//v7+//7+/v////////////r6+v/Jy" +
                        "cn/Jycn/wQEBP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP9QU" +
                        "FD/6+vr//////////////////7+/v/////////////////////////////////+/v7//f39/8nJyf8lJ" +
                        "SX/XFxc//j4+P/7+/v/+/v7/9ra2v8yMjL/lZWV//X19f//////+/v7//j4+P////////////v7+//29" +
                        "vb///////39/f/7+/v//Pz8/5KSkv8EBAT/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8JCQn/AAAA/wAAAP8MDAz/np6e///////6+vr/+/v7//v7+//8/Pz//Pz8//z8/P/8/" +
                        "Pz//Pz8//b29v/9/f3//////8DAwP9BQUH/uLi4//n5+f/6+vr////////////+/v7//v7+//7+/v/m5" +
                        "ub/QkJC/wAAAP8EBAT/AAAA/wAAAP8AAAD/AwMD/wcHB/8FBQX/AwMD/wMDA/8DAwP/AAAA/wAAAP8wM" +
                        "DD/ysrK//Dw8P/p6en/39/f/8XFxf+bm5v/cXFx/1NTU/9GRkb/RkZG/0pKSv+Li4v/m5ub/7+/v//d3" +
                        "d3/8vLy//b29v////////////////////////////7+/v/7+/v/+/v7//z8/P///////Pz8/////////" +
                        "//////////////////////////////7+/v///////f39//29vb/jo6O/3p6ev/8/Pz/9vb2//7+/v/+/" +
                        "v7//v7+//7+/v//////////////////////9PT0//n5+f/09PT/ycnJ/xsbG/8CAgL/BwcH/wcHB/8EB" +
                        "AT/BAQE/wQEBP8EBAT/BAQE/wQEBP8EBAT/BAQE/wQEBP8FBQX/b29v//b29v//////+/v7///////29" +
                        "vb///////7+/v/+/v7//////////////////Pz8//n5+f+UlJT/DAwM/1ZWVv/5+fn///////v7+//Q0" +
                        "ND/JSUl/0xMTP/w8PD///////39/f//////////////////////+/v7///////////////////////Q0" +
                        "ND/ISEh/wYGBv8DAwP/AwMD/wMDA/8DAwP/AwMD/wMDA/8DAwP/AwMD/wYGBv8CAgL/BAQE/wMDA/8EB" +
                        "AT/LCws/9HR0f/z8/P//Pz8//39/f/9/f3//v7+//7+/v/+/v7//v7+//39/f//////9vb2//v7+/+Li" +
                        "4v/Kioq/8HBwf////////////7+/v//////////////////////09PT/yYmJv8EBAT/BAQE/wICAv8AA" +
                        "AD/AAAA/wAAAP8BAQH/AgIC/wMDA/8AAAD/BQUF/wAAAP8TExP/fX19//n5+f////////////7+/v///" +
                        "/////////v7+//r6+v/09PT/7q6uv+rq6v/a2tr/15eXv9VVVX/UlJS/19fX/9jY2P/n5+f/7u7u//d3" +
                        "d3/6Ojo//f39////////////////////////f39///////5+fn/8/Pz//n5+f/+/v7//f39//39/f///" +
                        "//////////////7+/v/8fHx/4ODg/92dnb//////////////////////////////////////////////" +
                        "////////////////////////83Nzf8ZGRn/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8BAQH/DAwM/5mZmf/+/v7///////////////////////39/f/8/Pz/+/v7//39/f/+/" +
                        "v7//f39//n5+f/19fX/fX19/xAQEP9ZWVn/7u7u//39/f/+/v7/0NDQ/ywsLP8ZGRn/ysrK//n5+f///" +
                        "/////////j4+P///////f39//7+/v////////////n5+f/09PT/7e3t/0hISP8BAQH/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8FBQX/AAAA/1lZWf/39/f/9vb2/////////" +
                        "//////////////////////////////////////////////w8PD/UVFR/xYWFv+9vb3/+fn5//j4+P/9/" +
                        "f3//////////////////f39/7S0tP8TExP/CAgI/wAAAP8BAQH/AgIC/wICAv8AAAD/AAAA/wAAAP8AA" +
                        "AD/CAgI/wAAAP8AAAD/NDQ0/8zMzP/19fX///////z8/P/9/f3//f39//7+/v/////////////////9/" +
                        "f3/+/v7///////z8/P/29vb/76+vv+Tk5P/Jycn/xMTE/8SEhL/MjIy/0pKSv9vb2//l5eX/7m5uf/V1" +
                        "dX/6urq//f39/////////////////////////////r6+v/7+/v///////z8/P////////////n5+f+Li" +
                        "4v/fn5+//j4+P/6+vr/+vr6//v7+//7+/v/+/v7//v7+//8/Pz//Pz8//z8/P/8/Pz//v7+//z8/P/Hx" +
                        "8f/Hx8f/wEBAf8ICAj/AgIC/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/woKCv+5u" +
                        "bn////////////8/Pz/9/f3//v7+//////////////////////////////////9/f3/+Pj4/1dXV/8AA" +
                        "AD/WVlZ//Hx8f///////////9XV1f8vLy//CQkJ/4iIiP/x8fH////////////9/f3////////////8/" +
                        "Pz///////////////////////7+/v+NjY3/CwsL/wQEBP8EBAT/BAQE/wQEBP8EBAT/BAQE/wQEBP8EB" +
                        "AT/AgIC/wgICP8DAwP/AwMD/wAAAP+IiIj/+vr6///////8/Pz//Pz8//39/f/+/v7//v7+//7+/v/9/" +
                        "f3//f39/+zs7P/+/v7/u7u7/ygoKP8ZGRn/v7+//////////////f39//////////////////f39/+Tk" +
                        "5P/BQUF/wYGBv8AAAD/AAAA/wEBAf8CAgL/AgIC/wICAv8BAQH/AAAA/wAAAP8AAAD/FxcX/4uLi////" +
                        "///+vr6///////9/f3////////////+/v7//f39//7+/v/+/v7//f39//v7+//9/f3///////v7+//7+" +
                        "/v/2dnZ/z4+Pv8GBgb/AQEB/wICAv8CAgL/AgIC/wUFBf8RERH/KSkp/0ZGRv9bW1v/j4+P/6+vr//Q0" +
                        "ND/5eXl//f39/////////////v7+////////f39//z8/P/r6+v/iIiI/4SEhP/39/f//Pz8/////////" +
                        "///////////////////////////////////////////////////xMTE/yIiIv8AAAD/BAQE/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wQEBP8RERH/z8/P//7+/v///////v7+//j4+P///" +
                        "/////////39/f/8/Pz//v7+////////////+vr6//X19f9MTEz/AAAA/15eXv/19fX/+vr6//n5+f/Q0" +
                        "ND/LS0t/wMDA/9JSUn/4eHh///////4+Pj//v7+///////8/Pz///////7+/v/9/f3//v7+///////39" +
                        "/f/vr6+/xYWFv8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wEBAf8BAQH/AAAA/wMDA/8RE" +
                        "RH/w8PD//f39//+/v7//v7+//7+/v///////////////////////////////////////////3t7e/8HB" +
                        "wf/ICAg/7y8vP/4+Pj//Pz8//7+/v////////////39/f/y8vL/fHx8/wAAAP8CAgL/BgYG/wICAv8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/ERER/zMzM//S0tL///////v7+//5+fn//////////////" +
                        "////f39//39/f///////////////////////v7+//7+/v/4+Pj//////+3t7f9CQkL/AwMD/wcHB/8DA" +
                        "wP/BQUF/wUFBf8BAQH/AAAA/wAAAP8CAgL/CAgI/wYGBv8SEhL/ICAg/0ZGRv+ampr/8/Pz///////7+" +
                        "/v//v7+///////8/Pz/8fHx/4qKiv9+fn7/+vr6//7+/v///////////////////////////////////" +
                        "//////////////9/f3//////8LCwv8hISH/AAAA/wEBAf8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wEBAf8EBAT/GBgY/9/f3//x8fH//v7+///////////////////////9/f3////////////09" +
                        "PT////////////l5eX/NjY2/wMDA/9VVVX/+Pj4//r6+v/9/f3/1tbW/ygoKP8FBQX/Hh4e/7Kysv///" +
                        "//////////////39/f////////////5+fn///////z8/P/29vb//////+Hh4f97e3v/U1NT/1NTU/9TU" +
                        "1P/U1NT/1NTU/9TU1P/U1NT/1NTU/9PT0//Xl5e/1dXV/9OTk7/gICA/9fX1///////+vr6//z8/P///" +
                        "/////////v7+/////////////z8/P/+/v7//f39/+3t7f89PT3/BgYG/xoaGv++vr7///////v7+//9/" +
                        "f3///////7+/v/+/v7/7e3t/0NDQ/8AAAD/BgYG/wAAAP8BAQH/AAAA/wQEBP8CAgL/AAAA/wICAv8EB" +
                        "AT/AAAA/wEBAf+goKD/+fn5///////7+/v//f39//7+/v///////////////////////////////////" +
                        "//////////////5+fn///////r6+v/6+vr/Y2Nj/wEBAf8AAAD/AQEB/wEBAf8BAQH/AQEB/wEBAf8BA" +
                        "QH/AQEB/wEBAf8BAQH/BAQE/wAAAP8bGxv/tLS0///////4+Pj///////7+/v///////Pz8//Hx8f+Ki" +
                        "or/fn5+//r6+v/+/v7//////////////////////////////////////////////////f39///////Cw" +
                        "sL/ISEh/wAAAP8BAQH/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8BAQH/AwMD/ywsLP/u7" +
                        "u7//f39////////////+vr6///////+/v7//f39/////////////Pz8////////////4uLi/zIyMv8CA" +
                        "gL/VlZW//j4+P/7+/v//f39/9XV1f8oKCj/AAAA/wsLC/+CgoL/+fn5//f39////////v7+/////////" +
                        "///9/f3//39/f//////+Pj4////////////3d3d/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7" +
                        "+//8fHx/+7u7v/o6Oj/5+fn//Ly8v/////////////////+/v7////////////+/v7//////////////" +
                        "/////////z8/P+8vLz/JCQk/wEBAf8dHR3/urq6//7+/v/8/Pz//v7+///////6+vr//Pz8/9jY2P8yM" +
                        "jL/AAAA/wYGBv8AAAD/AwMD/wAAAP8AAAD/AAAA/wAAAP8CAgL/AwMD/wAAAP9JSUn/zs7O/////////" +
                        "/////////39/f//////////////////////////////////////////////////////+vr6///////8/" +
                        "Pz//Pz8/29vb/8HBwf/AgIC/wEBAf8BAQH/AQEB/wEBAf8BAQH/AQEB/wEBAf8BAQH/AQEB/wMDA/8BA" +
                        "QH/Jycn/8zMzP/+/v7//v7+///////+/v7///////z8/P/x8fH/ioqK/35+fv/6+vr//v7+/////////" +
                        "/////////////////////////////////////////39/f//////wsLC/yEhIf8AAAD/AQEB/wAAAP8BA" +
                        "QH/AQEB/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8+Pj7/7u7u//7+/v/+/v7//v7+//r6+v///" +
                        "////Pz8///////9/f3/////////////////+/v7/9ra2v8rKyv/AgIC/1dXV//39/f/+/v7//39/f/U1" +
                        "NT/KSkp/wICAv8AAAD/R0dH/+Pj4//4+Pj////////////9/f3///////n5+f/////////////////6+" +
                        "vr////////////+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+///////9/f3//f39/////////" +
                        "///+vr6//j4+P/9/f3//////////////////////////////////v7+///////19fX/eXl5/wkJCf8AA" +
                        "AD/IiIi/7i4uP/9/f3//v7+///////+/v7/9/f3//z8/P+3t7f/Ghoa/wICAv8DAwP/AAAA/wQEBP8AA" +
                        "AD/AAAA/wAAAP8DAwP/AQEB/wICAv8RERH/oaGh//r6+v///////v7+///////4+Pj//////////////" +
                        "/////////////////////////////////////////z8/P///////v7+//////+BgYH/Dg4O/wICAv8BA" +
                        "QH/AQEB/wEBAf8BAQH/AQEB/wEBAf8BAQH/AQEB/wAAAP8DAwP/AAAA/0BAQP/q6ur//v7+///////+/" +
                        "v7//v7+///////8/Pz/8fHx/4qKiv9+fn7/+vr6//7+/v///////////////////////////////////" +
                        "//////////////9/f3//////8LCwv8hISH/AAAA/wEBAf8AAAD/AgIC/wEBAf8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8DAwP/WVlZ/+jo6P/5+fn//v7+///////+/v7//v7+//39/f///////f39//z8/P///" +
                        "///+vr6//n5+f/R0dH/ISEh/wICAv9YWFj/9fX1//v7+//+/v7/09PT/ykpKf8FBQX/AAAA/xoaGv+2t" +
                        "rb/////////////////+/v7//v7+/////////////////////////////r6+v/39/f//////////////" +
                        "//////////////////////////////7+/v////////////8/Pz//Pz8///////////////////////+/" +
                        "v7////////////8/Pz/+/v7//7+/v/+/v7/39/f/0FBQf8AAAD/AAAA/yMjI/+6urr////////////9/" +
                        "f3//v7+//n5+f/+/v7/lZWV/wgICP8FBQX/AAAA/wAAAP8CAgL/AQEB/wAAAP8DAwP/BgYG/wAAAP8CA" +
                        "gL/UFBQ/+Li4v////////////r6+v//////+Pj4/////////////////////////////////////////" +
                        "//////////////+/v7/////////////////lpaW/xQUFP8AAAD/AQEB/wEBAf8BAQH/AQEB/wEBAf8BA" +
                        "QH/AQEB/wEBAf8AAAD/BQUF/wAAAP9kZGT/+vr6/////////////v7+//7+/v///////Pz8//Hx8f+Ki" +
                        "or/fn5+//r6+v/+/v7//////////////////////////////////////////////////f39///////Cw" +
                        "sL/ISEh/wAAAP8BAQH/AAAA/wICAv8BAQH/AQEB/wAAAP8AAAD/AAAA/wEBAf8BAQH/BwcH/319ff/x8" +
                        "fH//////////////////v7+//39/f/+/v7////////////5+fn///////n5+f//////xsbG/xYWFv8CA" +
                        "gL/Wlpa//Pz8//8/Pz//v7+/9LS0v8qKir/AgIC/wQEBP8CAgL/dXV1//39/f/5+fn///////v7+//9/" +
                        "f3////////////z8/P//Pz8////////////+vr6/////////////////////////////////////////" +
                        "///+fn5/////////////Pz8//z8/P///////v7+//Ly8v///////Pz8////////////+fn5//z8/P///" +
                        "////f39/7Ozs/8eHh7/AgIC/wAAAP8eHh7/vLy8///////9/f3/+/v7//7+/v/+/v7/+vr6/3V1df8AA" +
                        "AD/BQUF/wAAAP8AAAD/AAAA/wMDA/8AAAD/BgYG/wICAv8AAAD/ExMT/6urq//////////////////9/" +
                        "f3//////////////////////////////////////////////////////////////////////////////" +
                        "////////6ysrP8bGxv/AAAA/wEBAf8BAQH/AQEB/wEBAf8BAQH/AQEB/wEBAf8BAQH/AAAA/wUFBf8AA" +
                        "AD/jo6O//z8/P///////v7+///////+/v7///////z8/P/x8fH/ioqK/35+fv/6+vr//v7+/////////" +
                        "/////////////////////////////////////////39/f//////wsLC/yEhIf8AAAD/AQEB/wAAAP8BA" +
                        "QH/AAAA/wAAAP8AAAD/AQEB/wEBAf8CAgL/AwMD/wgICP+fn5//+/v7///////8/Pz//f39//39/f///" +
                        "////v7+////////////+vr6///////9/f3//////6ysrP8NDQ3/AQEB/1tbW//y8vL//Pz8///////Q0" +
                        "ND/Kioq/wAAAP8GBgb/AAAA/z09Pf/e3t7/+vr6////////////+/v7///////+/v7//v7+/////////" +
                        "////v7+///////9/f3//f39//39/f/9/f3//f39//39/f/9/f3//f39/////////////////////////" +
                        "////////////////////f39//v7+/////////////n5+f////////////Ly8v93d3f/CwsL/wcHB/8AA" +
                        "AD/GRkZ/76+vv//////+vr6//v7+//+/v7//////+rq6v9TU1P/AAAA/wEBAf8AAAD/AwMD/wAAAP8EB" +
                        "AT/AAAA/wMDA/8AAAD/BQUF/01NTf/s7Oz///////f39////////////////////////v7+/////////" +
                        "////////////////////////////////////v7+///////9/f3////////////CwsL/IyMj/wAAAP8BA" +
                        "QH/AQEB/wEBAf8BAQH/AQEB/wEBAf8BAQH/AQEB/wAAAP8CAgL/DQ0N/7a2tv/6+vr///////r6+v///" +
                        "////v7+///////8/Pz/8fHx/4qKiv9+fn7/+vr6//7+/v///////////////////////////////////" +
                        "//////////////9/f3//////8LCwv8hISH/AAAA/wEBAf8AAAD/AAAA/wAAAP8AAAD/AAAA/wEBAf8CA" +
                        "gL/AwMD/wQEBP8uLi7/y8vL//7+/v//////+Pj4//7+/v////////////////////////////z8/P///" +
                        "/////////39/f9+fn7/BQUF/wEBAf9cXFz/8fHx//z8/P//////z8/P/ysrK/8CAgL/AwMD/wQEBP8aG" +
                        "hr/paWl//z8/P////////////r6+v/6+vr//////////////////Pz8//v7+//+/v7//////////////" +
                        "/////////////////////////////////////////v7+//8/Pz/+/v7//n5+f/8/Pz////////////8/" +
                        "Pz////////////6+vr////////////W1tb/QEBA/wEBAf8GBgb/AAAA/xkZGf/BwcH///////v7+//9/" +
                        "f3//f39///////R0dH/MjIy/wAAAP8AAAD/AQEB/wUFBf8AAAD/BAQE/wAAAP8AAAD/AAAA/ysrK/+qq" +
                        "qr//v7+//7+/v/5+fn/+vr6///////7+/v///////39/f///////////////////////////////////" +
                        "/////////39/f//////+/v7////////////1dXV/ywsLP8DAwP/AQEB/wEBAf8BAQH/AQEB/wEBAf8BA" +
                        "QH/AQEB/wEBAf8AAAD/AAAA/ykpKf/T09P//v7+//7+/v/9/f3///////7+/v///////Pz8//Hx8f+Ki" +
                        "or/fn5+//r6+v/+/v7//////////////////////////////////////////////////f39///////Cw" +
                        "sL/ISEh/wAAAP8BAQH/AAAA/wAAAP8AAAD/AAAA/wAAAP8BAQH/AwMD/wQEBP8FBQX/a2tr//n5+f///" +
                        "///+/v7//j4+P////////////n5+f///////f39///////8/Pz///////39/f/x8fH/VVVV/wEBAf8BA" +
                        "QH/XFxc//Dw8P/9/f3//////87Ozv8rKyv/BAQE/wAAAP8GBgb/BwcH/3Jycv/4+Pj///////r6+v///" +
                        "////v7+//39/f/6+vr/+Pj4/////////////Pz8/////////////////////////////////////////" +
                        "///+fn5//////////////////7+/v///////////////////////f39///////+/v7/+vr6///////09" +
                        "PT/urq6/yAgIP8AAAD/AwMD/wEBAf8cHBz/xMTE//////////////////z8/P/8/Pz/vr6+/x0dHf8AA" +
                        "AD/AAAA/wUFBf8FBQX/AAAA/wQEBP8CAgL/AAAA/wMDA/9PT0//9vb2//n5+f////////////f39////" +
                        "///+/v7//v7+//////////////////////////////////////////////////8/Pz///////r6+v///" +
                        "////////+Dg4P8zMzP/BwcH/wEBAf8BAQH/AQEB/wEBAf8BAQH/AQEB/wEBAf8BAQH/AgIC/wAAAP9AQ" +
                        "ED/4uLi///////7+/v///////7+/v/+/v7///////z8/P/x8fH/ioqK/35+fv/6+vr//v7+/////////" +
                        "////////////////////////////////////v7+///////9/f3/z8/P/xoaGv8AAAD/AwMD/wICAv8BA" +
                        "QH/AQEB/wAAAP8GBgb/DAwM/wAAAP8QEBD/UFBQ/+Pj4//z8/P////////////7+/v/+/v7/////////" +
                        "////Pz8///////29vb////////////39/f/3d3d/yQkJP8EBAT/AQEB/1hYWP/19fX///////39/f/U1" +
                        "NT/KCgo/wcHB/8AAAD/BAQE/wAAAP85OTn/1dXV//7+/v///////////////////////////////////" +
                        "//////////////+/v7/9PT0/////////////f39///////09PT//////////////////v7+//b29v///" +
                        "//////////////7+/v/////////////////+vr6///////6+vr/9fX1/3Nzc/8EBAT/AgIC/wICAv8AA" +
                        "AD/Hx8f/76+vv/+/v7//v7+///////+/v7//////52dnf8JCQn/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/ERER/wAAAP8TExP/vr6+//b29v/+/v7//v7+///////////////////////+/v7//v7+//39/f/7+" +
                        "/v///////7+/v/8/Pz///////39/f////////////z8/P////////////v7+//o6Oj/VlZW/wEBAf8BA" +
                        "QH/AQEB/wAAAP8AAAD/AAAA/wAAAP8BAQH/AQEB/wAAAP8KCgr/YGBg//X19f/7+/v///////7+/v///" +
                        "////v7+///////8/Pz/8fHx/4qKiv9+fn7/+vr6//7+/v///////////////////////////////////" +
                        "//////////////7+/v/8PDw/8fHx/88PDz/IyMj/yAgIP8XFxf/FhYW/yMjI/8eHh7/FhYW/x4eHv82N" +
                        "jb/fn5+/9ra2v/09PT//Pz8/////////////f39//7+/v///////v7+///////7+/v//////////////" +
                        "///+/v7/4mJif8SEhL/BAQE/wEBAf9YWFj/9fX1///////9/f3/1NTU/ygoKP8EBAT/AAAA/wkJCf8AA" +
                        "AD/FBQU/5+fn//8/Pz////////////////////////////////////////////////////////////y8" +
                        "vL/9PT0//n5+f/8/Pz/7u7u//j4+P/4+Pj/9fX1//////////////////////////////////39/f///" +
                        "////v7+/////////////Pz8/93d3f9DQ0P/AwMD/wICAv8CAgL/AAAA/x8fH/++vr7//v7+/////////" +
                        "///+/v7//f39/99fX3/BgYG/wAAAP8AAAD/AAAA/wYGBv8AAAD/AQEB/wAAAP8HBwf/ZGRk/+fn5////" +
                        "////v7+//7+/v///////////////////////v7+//7+/v//////+/v7////////////+fn5/////////" +
                        "////f39///////7+/v////////////+/v7/7Ozs/2JiYv8EBAT/AQEB/wEBAf8AAAD/AAAA/wAAAP8AA" +
                        "AD/AQEB/wEBAf8AAAD/CwsL/4GBgf/4+Pj//v7+///////8/Pz///////7+/v///////Pz8//Hx8f+Ki" +
                        "or/fn5+//r6+v/+/v7////////////////////////////////////////////////////////////4+" +
                        "Pj/vr6+/76+vv/CwsL/urq6/8DAwP/Dw8P/t7e3/7i4uP/T09P/5ubm//Hx8f///////////////////" +
                        "////f39//////////////////z8/P//////+fn5///////5+fn/9vb2/+Dg4P8/Pz//AgIC/wQEBP8BA" +
                        "QH/WFhY//X19f///////f39/9TU1P8oKCj/BQUF/wAAAP8KCgr/AgIC/wAAAP9kZGT/9PT0//7+/v///" +
                        "/////////////////////////////////////////b29v/39/f/mZmZ/3Z2dv98fHz/dnZ2/3d3d/93d" +
                        "3f/eHh4/4yMjP/i4uL/+/v7//v7+//19fX//Pz8//z8/P/9/f3///////v7+///////9fX1//39/f+vr" +
                        "6//ERER/wMDA/8BAQH/AgIC/wAAAP8fHx//vr6+//7+/v////////////n5+f/r6+v/T09P/wMDA/8AA" +
                        "AD/AAAA/wAAAP8AAAD/BwcH/wAAAP8AAAD/HBwc/8fHx//9/f3///////7+/v/+/v7//////////////" +
                        "/////////7+/v/+/v7///////r6+v/8/Pz///////v7+//+/v7///////j4+P///////Pz8/////////" +
                        "/////////Ly8v90dHT/BwcH/wEBAf8BAQH/AAAA/wAAAP8AAAD/AAAA/wEBAf8BAQH/AwMD/w4ODv+ys" +
                        "rL/+/v7////////////+fn5///////+/v7///////z8/P/x8fH/ioqK/35+fv/6+vr//v7+/////////" +
                        "///////////////////////////////////+fn5//n5+f/9/f3//Pz8//j4+P/////////////////7+" +
                        "/v////////////8/Pz////////////4+Pj/+Pj4///////+/v7//Pz8//z8/P/////////////////9/" +
                        "f3///////j4+P/29vb//////+3t7f+MjIz/FhYW/wMDA/8EBAT/AQEB/1hYWP/19fX///////39/f/U1" +
                        "NT/KCgo/wQEBP8BAQH/AQEB/wYGBv8BAQH/Nzc3/9bW1v/8/Pz//////////////////////////////" +
                        "//////////////6+vr/8fHx/3R0dP8GBgb/CQkJ/wEBAf8LCwv/BQUF/wYGBv9HR0f/19fX/////////" +
                        "///+/v7///////////////////////6+vr///////T09P/5+fn/b29v/wAAAP8CAgL/AAAA/wEBAf8AA" +
                        "AD/Hh4e/76+vv/+/v7///////7+/v/7+/v/29vb/ygoKP8CAgL/AAAA/wAAAP8AAAD/AAAA/woKCv8BA" +
                        "QH/CgoK/2hoaP/z8/P///////39/f/+/v7//v7+///////////////////////+/v7//v7+//b29v///" +
                        "///+vr6///////////////////////5+fn///////z8/P/////////////////29vb/iYmJ/wkJCf8BA" +
                        "QH/AQEB/wAAAP8AAAD/AAAA/wAAAP8BAQH/AQEB/wEBAf8YGBj/3d3d//v7+/////////////j4+P///" +
                        "////v7+///////8/Pz/8fHx/4qKiv9+fn7/+vr6//7+/v///////////////////////////////////" +
                        "/////////////////////////z8/P/////////////////+/v7/+Pj4////////////+/v7//X19f/z8" +
                        "/P//f39///////8/Pz//Pz8//39/f/////////////////+/v7////////////19fX/+/v7//////+9v" +
                        "b3/LS0t/wAAAP8HBwf/BAQE/wEBAf9YWFj/9fX1///////9/f3/1NTU/ygoKP8AAAD/BQUF/wAAAP8DA" +
                        "wP/CQkJ/xISEv+fn5///f39//////////////////////////////////////////////////r6+v+np" +
                        "6f/AgIC/wEBAf8AAAD/BAQE/wAAAP8AAAD/aWlp//T09P//////+Pj4//r6+v///////v7+///////9/" +
                        "f3//v7+//z8/P/9/f3/4+Pj/zExMf8FBQX/AQEB/wAAAP8AAAD/AAAA/x4eHv++vr7//v7+///////8/" +
                        "Pz//v7+/8PDw/8SEhL/AgIC/wAAAP8AAAD/AAAA/wAAAP8DAwP/CgoK/yYmJv/Q0ND/8/Pz///////9/" +
                        "f3//v7+//7+/v///////////////////////v7+//7+/v/5+fn///////v7+//6+vr//////////////" +
                        "//////////////+/v7//v7+//7+/v//////9/f3/56env8MDAz/AQEB/wEBAf8AAAD/AAAA/wAAAP8AA" +
                        "AD/AQEB/wEBAf8AAAD/Ly8v//f39//5+fn////////////6+vr///////7+/v///////Pz8//Hx8f+Ki" +
                        "or/fn5+//r6+v/+/v7////////////////////////////////////////////39/f//f39//39/f/5+" +
                        "fn//v7+//v7+//7+/v////////////7+/v/+fn5//////////////////r6+v/39/f//f39//7+/v///" +
                        "//////////////9/f3//Pz8///////9/f3///////v7+/+jo6P/SUlJ/wQEBP8BAQH/BAQE/wQEBP8BA" +
                        "QH/WFhY//X19f///////f39/9TU1P8oKCj/AAAA/woKCv8AAAD/BAQE/wgICP8AAAD/ZGRk//X19f///" +
                        "/////////////////////////////////////////7+/v/4+Pj/2NjY/yMjI/8DAwP/AwMD/wgICP8BA" +
                        "QH/CQkJ/5qamv////////////Ly8v/6+vr//v7+//r6+v//////+fn5/////////////////66urv8JC" +
                        "Qn/CQkJ/wAAAP8AAAD/AAAA/wAAAP8eHh7/vr6+//7+/v//////+/v7//7+/v+cnJz/CQkJ/wEBAf8AA" +
                        "AD/AgIC/wAAAP8BAQH/BQUF/wUFBf9xcXH/+Pj4///////8/Pz///////7+/v/+/v7//////////////" +
                        "/////////7+/v/+/v7//////+bm5v/s7Oz/+fn5////////////+/v7/////////////v7+//7+/v/+/" +
                        "v7///////j4+P+1tbX/FBQU/wEBAf8BAQH/AAAA/wAAAP8AAAD/AAAA/wEBAf8BAQH/AQEB/1dXV////" +
                        "///+vr6//7+/v///////f39///////+/v7///////z8/P/x8fH/ioqK/35+fv/6+vr//v7+/////////" +
                        "////////////////////////////////////v7+///////+/v7///////7+/v//////+/v7/////////" +
                        "////v7+/////////////f39//v7+////////////////////////////////////////f39//39/f///" +
                        "///+/v7/+vr6/+oqKj/MzMz/wAAAP8EBAT/CQkJ/wAAAP8EBAT/AQEB/1hYWP/19fX///////39/f/U1" +
                        "NT/KCgo/wEBAf8FBQX/BAQE/wUFBf8BAQH/AAAA/zIyMv/Kysr//////////////////////////////" +
                        "///////////////////+/v7//Dw8P9TU1P/AAAA/wAAAP8AAAD/AAAA/xsbG//IyMj////////////9/" +
                        "f3///////////////////////v7+////////////+zs7P9lZWX/AQEB/wICAv8AAAD/AAAA/wAAAP8AA" +
                        "AD/Hh4e/76+vv////////////z8/P/5+fn/cHBw/wUFBf8AAAD/AAAA/wUFBf8AAAD/AAAA/woKCv8tL" +
                        "S3/ycnJ//b29v//////+vr6///////+/v7//v7+///////////////////////+/v7//v7+//Pz8/+Wl" +
                        "pb/xcXF///////8/Pz///////z8/P///////////////////////v7+//7+/v/6+vr/ycnJ/x4eHv8BA" +
                        "QH/AQEB/wAAAP8AAAD/AAAA/wAAAP8BAQH/AQEB/wwMDP+Ghob///////7+/v/7+/v//////////////" +
                        "////v7+///////8/Pz/8fHx/4qKiv9+fn7/+vr6//7+/v///////////////////////////////////" +
                        "///////////////////+fn5///////7+/v///////z8/P////////////39/f/+/v7//v7+//z8/P///" +
                        "/////////z8/P///////Pz8//v7+/////////////////////////////z8/P+4uLj/MjIy/wsLC/8HB" +
                        "wf/BQUF/wAAAP8BAQH/BAQE/wEBAf9YWFj/9fX1///////9/f3/1NTU/ygoKP8CAgL/AAAA/wEBAf8DA" +
                        "wP/AAAA/wAAAP8RERH/lZWV/////////////////////////////////////////////f39///////8/" +
                        "Pz/h4eH/w0NDf8BAQH/AgIC/wEBAf9CQkL/8vLy//39/f/+/v7/+/v7///////39/f//////////////" +
                        "///+vr6///////V1dX/LS0t/wkJCf8AAAD/AAAA/wAAAP8AAAD/AAAA/x4eHv++vr7////////////9/" +
                        "f3/9PT0/1FRUf8CAgL/AAAA/wMDA/8HBwf/AAAA/wAAAP8GBgb/f39///Pz8///////7+/v///////5+" +
                        "fn//v7+//7+/v///////////////////////v7+//7+/v/V1dX/SEhI/5+fn///////+vr6/////////" +
                        "///+vr6//39/f////////////7+/v///////Pz8/9XV1f8mJib/AQEB/wEBAf8AAAD/AAAA/wAAAP8AA" +
                        "AD/AQEB/wEBAf8WFhb/paWl//7+/v//////+vr6/////////////f39//7+/v///////Pz8//Hx8f+Ki" +
                        "or/fn5+//r6+v/+/v7////////////////////////////////////////////////////////////7+" +
                        "/v///////z8/P/6+vr///////z8/P/////////////////8/Pz//v7+////////////+vr6///////29" +
                        "vb//Pz8///////5+fn///////7+/v/5+fn/9vb2/9PT0/9nZ2f/CAgI/wEBAf8ICAj/AAAA/wQEBP8BA" +
                        "QH/V1dX//T09P/+/v7//Pz8/9XV1f8pKSn/AAAA/wgICP8BAQH/AAAA/wYGBv8AAAD/CwsL/1dXV//l5" +
                        "eX///////39/f///////f39//39/f///////Pz8///////4+Pj//////8vLy/8TExP/AQEB/wEBAf8AA" +
                        "AD/iIiI//Pz8///////+/v7///////4+Pj//f39//////////////////r6+v/+/v7/np6e/xQUFP8AA" +
                        "AD/AQEB/wEBAf8AAAD/AQEB/wAAAP8fHx//vr6+//7+/v/+/v7/9/f3/9bW1v88PDz/AAAA/wYGBv8CA" +
                        "gL/AAAA/wUFBf8LCwv/MDAw/8vLy///////+/v7///////+/v7//v7+//39/f////////////j4+P///" +
                        "/////////X19f/8/Pz/hISE/xoaGv+bm5v///////7+/v/5+fn///////r6+v/7+/v///////z8/P///" +
                        "/////////z8/P/j4+P/NTU1/wMDA/8BAQH/AAAA/wYGBv8AAAD/AAAA/wQEBP8AAAD/HR0d/9ra2v/8/" +
                        "Pz/+fn5/////////////Pz8///////+/v7///////z8/P/x8fH/ioqK/35+fv/6+vr//v7+/////////" +
                        "///////////////////////////////////+/v7//v7+//6+vr//Pz8///////////////////////+/" +
                        "v7/+fn5//X19f/4+Pj//v7+///////+/v7/+vr6//39/f/+/v7////////////5+fn////////////4+" +
                        "Pj/9PT0///////u7u7/0NDQ/3V1df8RERH/AAAA/wkJCf8EBAT/AQEB/1dXV//09PT//v7+//z8/P/V1" +
                        "dX/KSkp/wAAAP8DAwP/AgIC/wAAAP8ICAj/AAAA/wAAAP8vLy//ycnJ///////8/Pz////////////9/" +
                        "f3///////7+/v/+/v7//f39///////l5eX/Pj4+/wAAAP8MDAz/AQEB/6+vr/////////////39/f///" +
                        "///+/v7///////+/v7//f39//39/f//////8fHx/2FhYf8EBAT/AAAA/wAAAP8BAQH/AAAA/wEBAf8AA" +
                        "AD/Hx8f/76+vv/+/v7//v7+//////+/v7//HBwc/wQEBP8BAQH/AAAA/wYGBv8BAQH/CwsL/4KCgv/09" +
                        "PT///////z8/P////////////7+/v/8/Pz////////////9/f3//v7+//39/f//////09PT/0FBQf8AA" +
                        "AD/jo6O//r6+v/////////////////9/f3//f39///////7+/v///////7+/v/+/v7/6urq/0ZGRv8CA" +
                        "gL/AQEB/wAAAP8DAwP/AAAA/wAAAP8FBQX/AgIC/zQ0NP/j4+P///////v7+/////////////z8/P///" +
                        "////v7+///////8/Pz/8fHx/4qKiv9+fn7/+vr6//7+/v///////////////////////////////////" +
                        "//////////////////////////////7+/v//f39//z8/P/5+fn//////////////////////////////" +
                        "///+/v7//v7+///////7Ozs////////////9PT0/////////////Pz8//39/f//////9fX1///////h4" +
                        "eH/Y2Nj/wICAv8BAQH/BAQE/wEBAf9XV1f/9PT0//7+/v/8/Pz/1dXV/ykpKf8AAAD/AAAA/wICAv8CA" +
                        "gL/BQUF/wAAAP8AAAD/CwsL/5CQkP/9/f3//Pz8//z8/P////////////j4+P//////+/v7///////+/" +
                        "v7/+fn5/3l5ef8AAAD/EBAQ/xoaGv/c3Nz////////////+/v7///////7+/v//////+/v7///////19" +
                        "fX//////9LS0v8kJCT/AQEB/wEBAf8AAAD/AQEB/wAAAP8BAQH/AAAA/x8fH/++vr7//v7+//7+/v/+/" +
                        "v7/oqKi/wICAv8JCQn/AAAA/wAAAP8NDQ3/AAAA/zQ0NP/Y2Nj////////////8/Pz//Pz8///////+/" +
                        "v7//f39//z8/P/+/v7///////j4+P/+/v7//////4uLi/8QEBD/AAAA/4mJif/4+Pj//////////////" +
                        "////f39/////////////Pz8//7+/v/+/v7///////Hx8f9fX1//AQEB/wAAAP8AAAD/AAAA/wAAAP8CA" +
                        "gL/AwMD/wMDA/9ZWVn/7u7u///////9/f3////////////8/Pz///////7+/v///////Pz8//Hx8f+Ki" +
                        "or/fn5+//r6+v/+/v7////////////////////////////////////////////7+/v//v7+///////4+" +
                        "Pj/zMzM/8fHx//MzMz/zc3N/8DAwP+/v7//w8PD/8nJyf/Jycn/zs7O/+jo6P////////////Ly8v/4+" +
                        "Pj//Pz8//39/f///////f39////////////9PT0//j4+P///////////87Ozv82Njb/AAAA/wQEBP8BA" +
                        "QH/V1dX//T09P/+/v7//Pz8/9XV1f8pKSn/BgYG/wAAAP8CAgL/AAAA/wAAAP8DAwP/AAAA/wICAv9OT" +
                        "k7/6urq//7+/v/5+fn////////////39/f///////39/f///////Pz8//39/f+ysrL/CQkJ/wcHB/9UV" +
                        "FT/9fX1///////6+vr//v7+//////////////////z8/P//////9PT0//////+bm5v/BwcH/wgICP8GB" +
                        "gb/AAAA/wEBAf8AAAD/AQEB/wAAAP8fHx//vr6+//7+/v/+/v7/8/Pz/4iIiP8AAAD/BwcH/wAAAP8GB" +
                        "gb/BgYG/wgICP+NjY3///////v7+//5+fn///////z8/P/7+/v////////////9/f3//Pz8///////4+" +
                        "Pj//////9LS0v9BQUH/BgYG/wYGBv9/f3//9fX1////////////+/v7//////////////////7+/v/+/" +
                        "v7//v7+///////19fX/d3d3/wAAAP8AAAD/AgIC/wAAAP8BAQH/BAQE/wAAAP8FBQX/goKC//f39////" +
                        "////v7+/////////////Pz8///////+/v7///////z8/P/x8fH/ioqK/35+fv/6+vr//v7+/////////" +
                        "//////////////////////////////////////////////29vb/wsLC/05OTv8mJib/IiIi/yEhIf8qK" +
                        "ir/Jycn/yYmJv8nJyf/Jycn/zg4OP9jY2P/j4+P/9vb2/////////////v7+////////Pz8//39/f///" +
                        "/////////j4+P//////+vr6//T09P//////i4uL/xMTE/8EBAT/AQEB/1dXV//09PT//v7+//z8/P/V1" +
                        "dX/KSkp/wYGBv8AAAD/BAQE/wAAAP8AAAD/AwMD/wQEBP8EBAT/Hh4e/8XFxf//////+fn5//z8/P///" +
                        "///+/v7///////////////////////8/Pz/4eHh/y4uLv8AAAD/lpaW//z8/P/+/v7/+vr6//7+/v///" +
                        "////v7+///////+/v7///////r6+v/t7e3/Xl5e/wQEBP8EBAT/AAAA/wAAAP8BAQH/AAAA/wEBAf8AA" +
                        "AD/Hx8f/76+vv/+/v7//v7+/+vr6/9lZWX/AAAA/wICAv8BAQH/CAgI/wAAAP9DQ0P/39/f///////5+" +
                        "fn//v7+////////////+fn5//////////////////v7+////////f39//////+Ghob/EhIS/wEBAf8EB" +
                        "AT/ZWVl//Dw8P///////f39//f39//////////////////////////////////+/v7/9vb2/4yMjP8CA" +
                        "gL/AAAA/wMDA/8AAAD/AwMD/wMDA/8AAAD/Dg4O/6enp//7+/v///////7+/v/9/f3///////z8/P///" +
                        "////v7+///////8/Pz/8fHx/4qKiv9+fn7/+vr6//7+/v///////////////////////////////////" +
                        "/////////z8/P//////+Pj4/7u7u/8mJib/AAAA/wAAAP8DAwP/AgIC/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/CgoK/xsbG/9ubm7/6Ojo///////5+fn//v7+//v7+/////////////z8/P///////f39///////6+" +
                        "vr//////9XV1f8xMTH/BAQE/wEBAf9XV1f/9PT0//7+/v/8/Pz/1dXV/ykpKf8CAgL/AAAA/wcHB/8CA" +
                        "gL/AAAA/wEBAf8AAAD/AQEB/woKCv+MjIz/+vr6//39/f/6+vr///////7+/v///////Pz8/////////" +
                        "///+/v7//f39/9lZWX/DQ0N/8TExP/+/v7///////////////////////7+/v/+/v7///////39/f///" +
                        "///zMzM/zExMf8ICAj/AAAA/wAAAP8BAQH/AQEB/wAAAP8BAQH/AAAA/x8fH/++vr7//v7+//7+/v/i4" +
                        "uL/PDw8/wAAAP8AAAD/AwMD/wICAv8QEBD/m5ub//39/f/6+vr////////////7+/v///////z8/P///" +
                        "//////////////8/Pz//v7+//z8/P/b29v/QEBA/wQEBP8AAAD/AgIC/1FRUf/y8vL////////////39" +
                        "/f///////7+/v///////////////////////f39//f39/+hoaH/CQkJ/wAAAP8DAwP/AAAA/wQEBP8CA" +
                        "gL/AAAA/yEhIf/Gxsb//f39//7+/v///////Pz8///////8/Pz///////7+/v///////Pz8//Hx8f+Ki" +
                        "or/fn5+//r6+v/+/v7////////////////////////////////////////////////////////////Ex" +
                        "MT/IiIi/wAAAP8BAQH/AwMD/wAAAP8AAAD/AwMD/wgICP8JCQn/BgYG/wEBAf8AAAD/FhYW/6SkpP/6+" +
                        "vr/+vr6//j4+P////////////////////////////X19f////////////n5+f/5+fn/Y2Nj/wQEBP8BA" +
                        "QH/V1dX//T09P/+/v7//Pz8/9XV1f8pKSn/AAAA/wAAAP8FBQX/AgIC/wAAAP8BAQH/AAAA/wEBAf8FB" +
                        "QX/RERE/+Hh4f///////Pz8/////////////Pz8//r6+v//////+fn5///////5+fn/o6Oj/0ZGRv/m5" +
                        "ub//Pz8/////////////f39////////////+vr6///////8/Pz//////5SUlP8RERH/BgYG/wAAAP8FB" +
                        "QX/AQEB/wEBAf8AAAD/AQEB/wAAAP8fHx//vr6+//7+/v/+/v7/yMjI/x4eHv8AAAD/AgIC/wICAv8KC" +
                        "gr/T09P/+Li4v//////9vb2/////////////Pz8///////+/v7//v7+///////+/v7///////v7+//w8" +
                        "PD/i4uL/xAQEP8DAwP/AwMD/wYGBv9GRkb/8vLy////////////+/v7///////+/v7////////////+/" +
                        "v7//v7+//39/f/6+vr/tLS0/xISEv8AAAD/AgIC/wAAAP8DAwP/AQEB/wAAAP87Ozv/3t7e///////9/" +
                        "f3///////z8/P///////Pz8///////+/v7///////z8/P/x8fH/ioqK/35+fv/6+vr//v7+/////////" +
                        "////////////////////////////////////f39///////8/Pz/xcXF/yIiIv8AAAD/AwMD/wAAAP8AA" +
                        "AD/AgIC/wICAv8AAAD/AAAA/wAAAP8DAwP/BAQE/wMDA/9xcXH/7e3t///////8/Pz///////r6+v///" +
                        "////v7+//j4+P///////f39///////39/f//////56env8EBAT/AQEB/1dXV//09PT//v7+//z8/P/V1" +
                        "dX/KSkp/wAAAP8AAAD/AQEB/wAAAP8DAwP/AwMD/wAAAP8HBwf/BAQE/w8PD//Jycn//v7+//7+/v/8/" +
                        "Pz///////z8/P////////////b29v//////+Pj4/9LS0v+Dg4P///////j4+P////////////n5+f///" +
                        "/////////j4+P///////Pz8//Pz8/9cXFz/AAAA/wAAAP8CAgL/CwsL/wAAAP8BAQH/AAAA/wEBAf8AA" +
                        "AD/Hx8f/76+vv/+/v7//v7+/6urq/8TExP/BQUF/wcHB/8AAAD/Gxsb/42Njf////////////n5+f///" +
                        "////f39///////4+Pj//////////////////Pz8///////4+Pj/4uLi/0dHR/8AAAD/AwMD/wAAAP8DA" +
                        "wP/PDw8/+np6f/39/f///////////////////////7+/v///////f39//7+/v/9/f3//v7+/8HBwf8ZG" +
                        "Rn/AQEB/wEBAf8AAAD/AwMD/wEBAf8EBAT/Tk5O/+zs7P///////f39///////9/f3///////v7+////" +
                        "////v7+///////8/Pz/8fHx/4qKiv9+fn7/+vr6//7+/v///////////////////////////////////" +
                        "/////////39/f///////////8LCwv8iIiL/AAAA/wAAAP8AAAD/AAAA/wICAv8GBgb/AQEB/wAAAP8AA" +
                        "AD/AAAA/wICAv8LCwv/TU1N//r6+v/6+vr/+vr6////////////+/v7//z8/P/8/Pz////////////+/" +
                        "v7///////v7+//Dw8P/FxcX/wAAAP9YWFj/8/Pz//r6+v//////09PT/ykpKf8BAQH/AQEB/wAAAP8AA" +
                        "AD/AAAA/wAAAP8BAQH/AQEB/wkJCf8AAAD/g4OD//r6+v/9/f3//Pz8///////7+/v///////7+/v/+/" +
                        "v7///////r6+v/v7+//7+/v//b29v//////9vb2//7+/v////////////z8/P/5+fn//f39//39/f/Ly" +
                        "8v/JSUl/wAAAP8BAQH/BwcH/wAAAP8EBAT/AAAA/wMDA/8AAAD/AwMD/xsbG//ExMT/+/v7//f39/94e" +
                        "Hj/ExMT/woKCv8AAAD/CQkJ/1NTU//a2tr///////39/f/9/f3//v7+/////////////////////////" +
                        "////Pz8//z8/P//////9PT0/5qamv8QEBD/AAAA/wkJCf8AAAD/AwMD/zExMf/c3Nz///////n5+f///" +
                        "////f39///////8/Pz//Pz8//7+/v////////////T09P/a2tr/ISEh/wcHB/8AAAD/AQEB/wQEBP8BA" +
                        "QH/BAQE/3x8fP/9/f3//v7+//////////////////////////////////7+/v///////Pz8//Hx8f+Ki" +
                        "or/fn5+//r6+v/+/v7///////////////////////////////////////////////////////39/f/Dw" +
                        "8P/Jycn/wMDA/8HBwf/AAAA/wMDA/8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/3Fxcf/5+" +
                        "fn//Pz8//7+/v/9/f3//////////////////v7+///////6+vr////////////+/v7/0dHR/x8fH/8EB" +
                        "AT/WVlZ//X19f/8/Pz//v7+/9LS0v8pKSn/AQEB/wEBAf8AAAD/AAAA/wAAAP8AAAD/AQEB/wEBAf8HB" +
                        "wf/AAAA/0dHR//a2tr///////z8/P//////+/v7///////8/Pz/////////////////9/f3//j4+P///" +
                        "/////////39/f///////f39//39/f///////f39///////5+fn/lJSU/xEREf8AAAD/AAAA/wMDA/8AA" +
                        "AD/AwMD/wAAAP8CAgL/AAAA/wQEBP8aGhr/wcHB//v7+//y8vL/aWlp/wUFBf8BAQH/AwMD/xkZGf+io" +
                        "qL/+/v7//r6+v/9/f3//v7+//7+/v////////////////////////////7+/v//////9/f3/9zc3P9TU" +
                        "1P/AAAA/wEBAf8AAAD/AAAA/wICAv8oKCj/2tra///////6+vr//////////////////f39//7+/v/+/" +
                        "v7//v7+///////29vb/39/f/zMzM/8KCgr/AAAA/wICAv8FBQX/AgIC/w8PD/+cnJz//f39//7+/v///" +
                        "//////////////////////////////+/v7///////z8/P/x8fH/ioqK/35+fv/6+vr//v7+/////////" +
                        "///////////////////////////////////////////////////wsLC/yIiIv8AAAD/AgIC/wAAAP8BA" +
                        "QH/AAAA/wAAAP8FBQX/CAgI/wUFBf8DAwP/BQUF/xsbG/+wsLD/9/f3//z8/P//////+fn5/////////" +
                        "//////////////9/f3/+fn5///////8/Pz//v7+/9vb2/8pKSn/BwcH/1lZWf/39/f///////39/f/R0" +
                        "dH/Kioq/wEBAf8BAQH/AAAA/wAAAP8AAAD/AAAA/wEBAf8BAQH/BAQE/wICAv8SEhL/ra2t///////8/" +
                        "Pz////////////+/v7//Pz8//////////////////z8/P/9/f3///////z8/P////////////r6+v/+/" +
                        "v7///////39/f/9/f3/7Ozs/1FRUf8AAAD/AgIC/wAAAP8AAAD/BAQE/wAAAP8AAAD/AAAA/wAAAP8FB" +
                        "QX/GRkZ/729vf/8/Pz/5+fn/0RERP8AAAD/AAAA/wcHB/9SUlL/6Ojo///////4+Pj//f39//7+/v///" +
                        "/////////////////////////////////////////b29v+goKD/EhIS/wAAAP8GBgb/AQEB/wAAAP8BA" +
                        "QH/Gxsb/9bW1v/+/v7/+/v7//v7+/////////////39/f////////////39/f//////+vr6/+jo6P9FR" +
                        "UX/BgYG/wAAAP8AAAD/AQEB/wAAAP8cHBz/wcHB//39/f/+/v7//////////////////////////////" +
                        "////v7+///////8/Pz/8fHx/4qKiv9+fn7/+vr6//7+/v///////////////////////////////////" +
                        "/////////v7+//+/v7//////8PDw/8nJyf/AAAA/wcHB/8FBQX/BwcH/wMDA/8CAgL/AAAA/wAAAP8AA" +
                        "AD/BwcH/yEhIf+CgoL/7Ozs//f39//7+/v//////////////////f39//7+/v///////Pz8//39/f///" +
                        "///+Pj4//v7+//Z2dn/Kysr/wYGBv9YWFj/9/f3///////9/f3/0NDQ/ysrK/8BAQH/AQEB/wAAAP8AA" +
                        "AD/AAAA/wAAAP8BAQH/AQEB/wAAAP8JCQn/AgIC/3h4eP/7+/v/+fn5//r6+v////////////7+/v///" +
                        "//////////////7+/v/+/v7///////4+Pj///////////////////////z8/P/7+/v//Pz8/8fHx/8kJ" +
                        "CT/AAAA/wEBAf8AAAD/AAAA/wICAv8AAAD/AQEB/wAAAP8AAAD/BwcH/xoaGv+8vLz//////9PT0/8fH" +
                        "x//BAQE/wICAv8aGhr/rKys//z8/P/39/f///////7+/v/+/v7////////////////////////////+/" +
                        "v7///////f39//q6ur/SkpK/wAAAP8KCgr/AAAA/wkJCf8AAAD/AAAA/w8PD//S0tL//Pz8///////4+" +
                        "Pj////////////+/v7////////////8/Pz///////39/f/y8vL/V1dX/wAAAP8CAgL/AAAA/wAAAP8AA" +
                        "AD/Ly8v/9/f3//9/f3//v7+//////////////////////////////////7+/v///////Pz8//Hx8f+Ki" +
                        "or/fn5+//r6+v/+/v7////////////////////////////////////////////////////////////Jy" +
                        "cn/UVFR/ykpKf8wMDD/KSkp/yoqKv8pKSn/LS0t/zMzM/86Ojr/T09P/35+fv+rq6v/4ODg///////7+" +
                        "/v///////b29v////////////z8/P/8/Pz///////39/f////////////f39///////0dHR/yMjI/8CA" +
                        "gL/VlZW//X19f/+/v7//f39/9HR0f8sLCz/AQEB/wEBAf8AAAD/AAAA/wAAAP8AAAD/AQEB/wEBAf8AA" +
                        "AD/AgIC/wUFBf89PT3/3Nzc//7+/v/39/f//v7+////////////////////////////+/v7//v7+//8/" +
                        "Pz/+vr6///////6+vr////////////4+Pj///////7+/v+JiYn/Dg4O/wAAAP8AAAD/BgYG/wMDA/8AA" +
                        "AD/AAAA/wEBAf8AAAD/AAAA/wcHB/8cHBz/vr6+//////+zs7P/ERER/wQEBP8HBwf/YGBg/+3t7f///" +
                        "///8/Pz///////+/v7////////////////////////////+/v7//v7+//39/f/8/Pz/pqam/wsLC/8DA" +
                        "wP/DAwM/wAAAP8JCQn/AAAA/wAAAP8JCQn/ysrK//39/f//////9/f3/////////////f39/////////" +
                        "////Pz8//7+/v//////+Pj4/25ubv8AAAD/BAQE/wICAv8DAwP/AAAA/09PT//x8fH//f39//7+/v///" +
                        "//////////////////////////////+/v7///////z8/P/x8fH/ioqK/35+fv/6+vr//v7+/////////" +
                        "///////////////////////////////////+vr6//j4+P/+/v7/8/Pz/9DQ0P/Ozs7/2dnZ/9TU1P/X1" +
                        "9f/1NTU/9TU1P/Y2Nj/29vb/+Hh4f/y8vL////////////////////////////z8/P///////7+/v///" +
                        "////v7+///////9/f3//v7+///////7+/v//////7a2tv8WFhb/AAAA/1ZWVv/09PT//Pz8///////T0" +
                        "9P/Kioq/wEBAf8BAQH/AAAA/wAAAP8AAAD/AAAA/wEBAf8BAQH/AQEB/wAAAP8FBQX/ExMT/62trf///" +
                        "////f39//j4+P///////v7+////////////////////////////////////////////9vb2/////////" +
                        "///+vr6///////u7u7/RkZG/wMDA/8DAwP/AAAA/wYGBv8FBQX/AAAA/wAAAP8BAQH/AAAA/wAAAP8FB" +
                        "QX/HR0d/8DAwP/8/Pz/iYmJ/w4ODv8AAAD/Hh4e/7y8vP/5+fn////////////8/Pz//////////////" +
                        "////////////////////v7+//39/f/9/f3/8vLy/0pKSv8AAAD/BgYG/wMDA/8AAAD/BAQE/wAAAP8BA" +
                        "QH/BQUF/7u7u//8/Pz///////r6+v////////////39/f////////////z8/P/+/v7///////v7+/+Ii" +
                        "Ij/AAAA/wEBAf8CAgL/AQEB/wMDA/91dXX/9vb2//39/f/+/v7//////////////////////////////" +
                        "////v7+///////8/Pz/8fHx/4qKiv9+fn7/+vr6//7+/v///////////////////////////////////" +
                        "////////////////////v7+//v7+//+/v7///////7+/v/6+vr/+/v7//z8/P///////////////////" +
                        "////f39//f39//+/v7//f39//v7+////////f39//39/f/9/f3//////////////////v7+///////9/" +
                        "f3//f39//n5+f+BgYH/CwsL/wAAAP9aWlr/8/Pz//r6+v//////1dXV/ygoKP8BAQH/AQEB/wAAAP8AA" +
                        "AD/AAAA/wAAAP8BAQH/AQEB/wICAv8CAgL/AAAA/wUFBf9wcHD/9PT0///////7+/v//v7+//7+/v///" +
                        "/////////////////////////////////////////f39////////f39///////+/v7/u7u7/xsbG/8AA" +
                        "AD/BAQE/wAAAP8AAAD/AwMD/wAAAP8BAQH/AgIC/wAAAP8BAQH/AQEB/xwcHP/AwMD/8/Pz/19fX/8GB" +
                        "gb/Dg4O/2NjY//09PT/9/f3////////////+Pj4/////////////////////////////v7+//7+/v/9/" +
                        "f3/+Pj4/6Ojo/8SEhL/AwMD/wQEBP8AAAD/BAQE/wAAAP8CAgL/AQEB/wQEBP+qqqr/+Pj4///////9/" +
                        "f3//v7+///////8/Pz//v7+///////9/f3//v7+///////7+/v/pqam/woKCv8AAAD/AAAA/wAAAP8LC" +
                        "wv/np6e//j4+P/9/f3//v7+//////////////////////////////////7+/v///////Pz8//Hx8f+Ki" +
                        "or/fn5+//r6+v/+/v7////////////////////////////////////////////4+Pj///////z8/P/29" +
                        "vb////////////8/Pz///////7+/v///////v7+//r6+v/6+vr//v7+///////+/v7/+vr6///////09" +
                        "PT//f39///////9/f3///////7+/v/9/f3//////////////////v7+//7+/v/p6en/T09P/wUFBf8AA" +
                        "AD/Xl5e//T09P/5+fn//////9bW1v8mJib/AQEB/wEBAf8AAAD/AAAA/wAAAP8AAAD/AQEB/wEBAf8AA" +
                        "AD/BwcH/wAAAP8EBAT/PT09/9fX1//+/v7//v7+//////////////////7+/v/////////////////9/" +
                        "f3//v7+///////8/Pz///////39/f//////8fHx/4eHh/8MDAz/AAAA/wUFBf8ICAj/AAAA/wAAAP8FB" +
                        "QX/AAAA/wMDA/8BAQH/AQEB/wAAAP8aGhr/wMDA/+3t7f9DQ0P/AAAA/zExMf+xsbH////////////7+" +
                        "/v//f39//////////////////////////////////7+/v/9/f3//f39/+3t7f8/Pz//BwcH/wAAAP8BA" +
                        "QH/AAAA/wUFBf8AAAD/BAQE/wICAv8CAgL/nZ2d//T09P/9/f3///////39/f//////+/v7//39/f///" +
                        "////f39////////////+/v7/7+/v/8XFxf/AAAA/wEBAf8AAAD/FRUV/7y8vP///////f39//7+/v///" +
                        "//////////////////////////////8/Pz///////v7+//z8/P/jo6O/39/f//6+vr///////7+/v/+/" +
                        "v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/" +
                        "v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+/////////////v7+/////////////Pz8//z8/P///" +
                        "/////////T09P////////////Pz8///////uLi4/xsbG/8CAgL/AgIC/1paWv/09PT//f39//39/f/V1" +
                        "dX/KCgo/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8BAQH/AAAA/wAAAP8AAAD/BgYG/xQUFP+oq" +
                        "Kj/+/v7//7+/v/////////////////////////////////////////////////8/Pz////////////8/" +
                        "Pz//////+zs7P9AQED/AQEB/wEBAf8BAQH/AQEB/wAAAP8AAAD/AAAA/wAAAP8BAQH/AwMD/wAAAP8DA" +
                        "wP/ERER/7m5uf/a2tr/ICAg/wAAAP+CgoL/8/Pz//T09P///////Pz8//j4+P////////////z8/P///" +
                        "///9/f3//r6+v//////+Pj4//////+jo6P/ExMT/wAAAP8AAAD/AQEB/w8PD/8AAAD/BwcH/wEBAf8AA" +
                        "AD/AgIC/4qKiv/9/f3//v7+///////////////////////////////////////////////////////Pz" +
                        "8//HR0d/wcHB/8AAAD/AAAA/yoqKv/c3Nz/9/f3//39/f/+/v7//////////////////////////////" +
                        "//////////////6+vr/8PDw/4mJif97e3v/+fn5/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////7+/v/+fn5//v7+/////////////39/f/9/f3///////j4+P//////+Pj4//39/f///" +
                        "///2NjY/1hYWP8AAAD/AgIC/wICAv9aWlr/9PT0//39/f/9/f3/1dXV/ygoKP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AQEB/wAAAP8DAwP/AQEB/wMDA/8CAgL/aGho//Ly8v/8/Pz//Pz8//39/f/9/" +
                        "f3//f39//39/f/9/f3//Pz8//z8/P////////////v7+///////9vb2//////+0tLT/Ghoa/wEBAf8BA" +
                        "QH/AQEB/wEBAf8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/CQkJ/x8fH//Dw8P/ubm5/xYWFv86O" +
                        "jr/vLy8//r6+v///////v7+//39/f////////////39/f///////v7+//v7+///////+fn5//j4+P/n5" +
                        "+f/T09P/wAAAP8AAAD/AgIC/wAAAP8DAwP/AAAA/wUFBf8CAgL/AAAA/wAAAP+BgYH/+Pj4//39/f///" +
                        "///////////////////////////////////////////////////2tra/ykpKf8FBQX/AgIC/wMDA/9IS" +
                        "Ej/7Ozs//7+/v/9/f3//v7+////////////////////////////////////////////+/v7//Hx8f+Mj" +
                        "Iz/f39///39/f///////v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/" +
                        "v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//////////////" +
                        "//////////////9/f3//Pz8//7+/v////////////b29v/9/f3/9PT0/4CAgP8RERH/DAwM/wICAv8CA" +
                        "gL/Wlpa//T09P/9/f3//f39/9XV1f8oKCj/AQEB/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wEBAf8AA" +
                        "AD/AwMD/wICAv8DAwP/AAAA/ysrK//c3Nz//////////////////////////////////////////////" +
                        "////v7+///////7+/v///////39/f//////f39//w4ODv8BAQH/AQEB/wEBAf8BAQH/AAAA/wAAAP8AA" +
                        "AD/AAAA/wQEBP8AAAD/AAAA/wAAAP8YGBj/ubm5/35+fv8ICAj/fHx8/+np6f/39/f///////n5+f/9/" +
                        "f3///////39/f////////////n5+f/7+/v///////Ly8v//////qamp/woKCv8AAAD/BAQE/wMDA/8AA" +
                        "AD/AAAA/wAAAP8DAwP/AgIC/wAAAP8AAAD/dHR0//Hx8f/8/Pz//////////////////////////////" +
                        "////////////////////////+Xl5f85OTn/AAAA/wICAv8EBAT/bm5u//n5+f/+/v7//f39//7+/v///" +
                        "//////////////////////////////+/v7///////z8/P/09PT/jo6O/35+fv/5+fn//v7+/////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////v7+//7+/v//Pz8//39/f/+/v7//////////////" +
                        "///9PT0//7+/v//////7Ozs/5SUlP8mJib/AAAA/wgICP8CAgL/AgIC/1paWv/09PT//f39//39/f/V1" +
                        "dX/KCgo/wEBAf8BAQH/AAAA/wAAAP8AAAD/AAAA/wAAAP8BAQH/AQEB/wEBAf8AAAD/AwMD/wkJCf8MD" +
                        "Az/pKSk//39/f/9/f3//v7+//7+/v///////////////////////v7+///////9/f3/+Pj4//39/f/7+" +
                        "/v/4ODg/zs7O/8AAAD/AQEB/wEBAf8BAQH/AQEB/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wQEBP8AA" +
                        "AD/ICAg/8LCwv9ubm7/LS0t/8fHx//////////////////+/v7/+/v7///////8/Pz///////v7+////" +
                        "/////////n5+f//////8PDw/0ZGRv8AAAD/BgYG/wICAv8AAAD/AgIC/wICAv8EBAT/AAAA/wEBAf8AA" +
                        "AD/AAAA/2ZmZv/t7e3//f39///////////////////////////////////////////////////////v7" +
                        "+//UFBQ/wAAAP8CAgL/CAgI/5OTk//9/f3/+/v7//39/f/+/v7//////////////////////////////" +
                        "//////////////7+/v/8vLy/4qKiv96enr/9fX1//v7+//9/f3//f39//39/f/9/f3//f39//39/f/9/" +
                        "f3//f39//39/f/9/f3//f39//39/f/9/f3//f39//39/f/9/f3//f39//39/f/9/f3//f39//39/f/9/" +
                        "f3//f39//39/f/////////////////9/f3//v7+////////////////////////////4uLi/4mJif8kJ" +
                        "CT/AAAA/wMDA/8AAAD/AgIC/wICAv9aWlr/9PT0//39/f/9/f3/1dXV/ygoKP8CAgL/AgIC/wEBAf8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wYGBv8CAgL/AAAA/wAAAP8ICAj/AAAA/1dXV//x8fH//v7+/////////" +
                        "///////////////////////////////////+Pj4/////////////////7W1tf8eHh7/CQkJ/wEBAf8BA" +
                        "QH/AQEB/wEBAf8AAAD/AAAA/wAAAP8AAAD/AgIC/wAAAP8JCQn/AAAA/xISEv+mpqb/VlZW/zg4OP+oq" +
                        "Kj/vb29/9jY2P/k5OT///////r6+v/5+fn////////////9/f3//f39///////09PT//////6ysrP8WF" +
                        "hb/AgIC/wsLC/8AAAD/AAAA/wMDA/8AAAD/AQEB/wAAAP8AAAD/AAAA/wEBAf9aWlr/6+vr///////+/" +
                        "v7/////////////////////////////////////////////////9PT0/2hoaP8CAgL/BAQE/xYWFv+4u" +
                        "Lj///////7+/v/9/f3//v7+////////////////////////////////////////////+fn5//Dw8P+Li" +
                        "4v/f39///7+/v///////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////////////////////9/" +
                        "f3//f39////////////+fn5//Ly8v/r6+v/t7e3/2FhYf8WFhb/AAAA/wAAAP8HBwf/CgoK/wICAv8CA" +
                        "gL/Wlpa//T09P/9/f3//f39/9XV1f8oKCj/AwMD/wICAv8CAgL/AQEB/wAAAP8AAAD/AAAA/wAAAP8CA" +
                        "gL/AAAA/wAAAP8AAAD/AQEB/wAAAP8mJib/2NjY//39/f/+/v7//////////////////////////////" +
                        "/////////j4+P///////f39//j4+P90dHT/AgIC/wAAAP8BAQH/AQEB/wEBAf8BAQH/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/BAQE/wAAAP8kJCT/ysrK/7+/v//CwsL/iIiI/3Jycv93d3f/bW1t/4+Pj/+go" +
                        "KD/vb29/9vb2//q6ur//Pz8//b29v///////////+/v7/9NTU3/AwMD/wAAAP8FBQX/AAAA/wICAv8DA" +
                        "wP/AAAA/wAAAP8EBAT/AAAA/wAAAP8CAgL/TU1N/+bm5v///////v7+//7+/v///////////////////" +
                        "/////////////////////////Ly8v95eXn/BQUF/wMDA/8tLS3/2NjY/////////////f39//7+/v///" +
                        "//////////////////////////////+/v7///////v7+//y8vL/i4uL/3t7e//19fX/+vr6//v7+//7+" +
                        "/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+" +
                        "/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//8/Pz/+/v7//r6+v/39/f/7Ozs/9XV1f/Aw" +
                        "MD/ZWVl/zAwMP8AAAD/AAAA/woKCv8AAAD/AAAA/wEBAf8CAgL/AgIC/1paWv/09PT//f39//39/f/V1" +
                        "dX/KCgo/wQEBP8DAwP/AgIC/wEBAf8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8GBgb/AQEB/wEBAf8GB" +
                        "gb/ExMT/5OTk//8/Pz//f39//7+/v///////////////////////////////////////Pz8//T09P/X1" +
                        "9f/Q0ND/wAAAP8AAAD/AQEB/wEBAf8BAQH/AQEB/wAAAP8AAAD/AAAA/wAAAP8FBQX/AAAA/wAAAP8AA" +
                        "AD/Hh4e/8TExP/29vb//v7+///////5+fn/4uLi/8vLy/+zs7P/jo6O/3d3d/9lZWX/aWlp/4ODg/+bm" +
                        "5v/urq6/9HR0f+lpaX/Hx8f/wYGBv8AAAD/AAAA/wUFBf8FBQX/AgIC/wEBAf8AAAD/BQUF/wAAAP8AA" +
                        "AD/AAAA/0BAQP/g4OD///////39/f/+/v7////////////////////////////////////////////39" +
                        "/f/ioqK/wkJCf8DAwP/SEhI//Ly8v/8/Pz//v7+//39/f/+/v7//////////////////////////////" +
                        "///////////////////9fX1/4WFhf9oaGj/1dXV/9LS0v/T09P/09PT/9PT0//T09P/09PT/9PT0//T0" +
                        "9P/09PT/9PT0//T09P/09PT/9PT0//T09P/09PT/9PT0//T09P/09PT/9PT0//T09P/09PT/9PT0//T0" +
                        "9P/09PT/9PT0//T09P/zc3N/7+/v/+qqqr/jo6O/2VlZf8xMTH/CgoK/wkJCf8AAAD/AgIC/wsLC/8CA" +
                        "gL/AQEB/wYGBv8AAAD/AgIC/wICAv9aWlr/9PT0//39/f/9/f3/1dXV/ygoKP8EBAT/AwMD/wICAv8BA" +
                        "QH/AAAA/wAAAP8AAAD/AAAA/wcHB/8AAAD/CQkJ/wICAv8CAgL/BQUF/wMDA/9AQED/pqam/6enp/+oq" +
                        "Kj/qamp/6qqqv+qqqr/qqqq/6qqqv+hoaH/sbGx/6CgoP+pqan/jIyM/xEREf8AAAD/AgIC/wEBAf8BA" +
                        "QH/AQEB/wEBAf8AAAD/AAAA/wAAAP8AAAD/AgIC/wEBAf8BAQH/BQUF/yIiIv+4uLj///////f39//y8" +
                        "vL///////Ly8v///////f39//39/f//////8PDw/9nZ2f+2trb/o6Oj/4CAgP9cXFz/PDw8/xEREf8FB" +
                        "QX/CQkJ/wAAAP8FBQX/AAAA/wAAAP8GBgb/AAAA/wAAAP8BAQH/AAAA/wAAAP82Njb/29vb///////9/" +
                        "f3//////////////////////////////////////////////////////5ubm/8SEhL/CAgI/19fX////" +
                        "////Pz8//7+/v/9/f3//v7+//////////////////////////////////39/f///////////+zs7P+ur" +
                        "q7/cHBw/11dXf9qamr/ZmZm/2ZmZv9mZmb/ZmZm/2dnZ/9nZ2f/Z2dn/2dnZ/9oaGj/aGho/2hoaP9oa" +
                        "Gj/aGho/2hoaP9oaGj/aGho/2dnZ/9nZ2f/Z2dn/2dnZ/9nZ2f/Z2dn/2dnZ/9nZ2f/ZGRk/2NjY/9gY" +
                        "GD/XV1d/1paWv9WVlb/VFRU/1JSUv9WVlb/VlZW/1ZWVv9WVlb/VlZW/1ZWVv9WVlb/VlZW/1lZWf9KS" +
                        "kr/lJSU/+3t7f///////////9nZ2f92dnb/V1dX/1dXV/9XV1f/V1dX/1dXV/9XV1f/V1dX/1dXV/9XV" +
                        "1f/V1dX/1dXV/9XV1f/V1dX/1dXV/9XV1f/V1dX/2BgYP9gYGD/YGBg/2BgYP9gYGD/YGBg/2BgYP9gY" +
                        "GD/YWFh/2BgYP9fX1//XV1d/1tbW/9aWlr/WFhY/1hYWP9YWFj/WFhY/1hYWP9YWFj/WFhY/1hYWP9YW" +
                        "Fj/WFhY/1dXV/9fX1//WFhY/1JSUv98fHz/yMjI//r6+v///////v7+//7+/v/+/v7//v7+//7+/v/+/" +
                        "v7//v7+//7+/v/7+/v//f39//7+/v/8/Pz/9PT0/9/f3/+8vLz/nZ2d/2tra/9RUVH/LS0t/xQUFP8KC" +
                        "gr/BgYG/wAAAP8AAAD/AAAA/wAAAP8EBAT/Jycn/9fX1//5+fn//Pz8//39/f/9/f3//v7+/////////" +
                        "/////////////////////////////+4uLj/DAwM/xEREf+ZmZn/9fX1/////////////////////////" +
                        "//////////////////////////////9/f3/+/v7////////////+Pj4/+jo6P/m5ub/7+/v/+/v7//v7" +
                        "+//7+/v/+/v7//w8PD/8PDw//Dw8P/w8PD/8fHx//Hx8f/x8fH/8fHx//Hx8f/x8fH/8fHx//Hx8f/w8" +
                        "PD/8PDw//Dw8P/w8PD/8PDw//Dw8P/w8PD/8PDw//T09P/09PT/8/Pz//Ly8v/x8fH/8PDw//Dw8P/v7" +
                        "+//8fHx//Hx8f/x8fH/8fHx//Hx8f/x8fH/8fHx//Hx8f/4+Pj/7e3t//r6+v//////+vr6//39/f///" +
                        "///7+/v//Hx8f/x8fH/8fHx//Hx8f/x8fH/8fHx//Hx8f/x8fH/8fHx//Hx8f/x8fH/8fHx//Hx8f/x8" +
                        "fH/8fHx//Hx8f/x8fH/8fHx//Hx8f/x8fH/8fHx//Hx8f/x8fH/8fHx//T09P/09PT/9PT0//Pz8//y8" +
                        "vL/8fHx//Hx8f/x8fH/8vLy//Ly8v/y8vL/8vLy//Ly8v/y8vL/8vLy//Ly8v/w8PD/9PT0/+/v7//o6" +
                        "Oj/8PDw////////////+/v7//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//Pz8//39/f/8/" +
                        "Pz//Pz8//////////////////z8/P/9/f3/7e3t/9XV1f+6urr/nJyc/3h4eP9SUlL/ODg4/yAgIP8OD" +
                        "g7/AAAA/x4eHv+8vLz/8PDw//z8/P/+/v7//////////////////v7+//z8/P/6+vr/+fn5//n5+f///" +
                        "///1dXV/x4eHv8bGxv/urq6//7+/v/5+fn/+/v7/////////////////////////////////////////" +
                        "/////////39/f/5+fn//v7+///////////////////////+/v7//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////8/Pz//Pz8//39/f/9/f3//v7+//7+/v///////////////////////////////////" +
                        "///////////////////9fX1///////9/f3/+vr6///////7+/v/9vb2/////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////9/f3//f39//39/f/+/v7//v7+//7+/v///////////////////" +
                        "//////////////////////////////////////////////////////////////+/v7/+fn5//f39//+/" +
                        "v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//////////////////39/f/7+/v//f39/////////" +
                        "////f39//7+/v/////////////////8/Pz/7e3t/+Hh4f+3t7f/rKys/4WFhf9YWFj/aWlp/2pqav+Eh" +
                        "IT/qKio/8zMzP/W1tb/5ubm//b29v//////////////////////8vLy/97e3v8iIiL/Ghoa/9TU1P///" +
                        "////Pz8//////////////////////////////////////////////////v7+//+/v7//v7+//v7+//5+" +
                        "fn/+fn5//f39//z8/P//Pz8//39/f/9/f3//f39//39/f/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/" +
                        "v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//////////////" +
                        "/////////////////////////////////////////////////////////////////////////7+/v///" +
                        "////Pz8//39/f////////////39/f///////////////////////////////////////////////////" +
                        "/////////////////////////////////////////7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/" +
                        "v7//v7+//7+/v/+/v7//////////////////////////////////////////////////////////////" +
                        "//////////////9/f3/+/v7//7+/v/+/v7//Pz8/////////////////////////////////////////" +
                        "//////////////7+/v///////////////////////z8/P/7+/v/+/v7/////////////f39//z8/P/9/" +
                        "f3//v7+///////////////////////z8/P/7e3t/+3t7f/V1dX/q6ur/4+Pj/9nZ2f/a2tr/3V1df+Hh" +
                        "4f/oaGh/7+/v//a2tr/6urq//j4+P/o6Oj/RERE/0dHR//y8vL///////j4+P/8/Pz//////////////" +
                        "//////////////////////////////39/f///////////////////////////////////////39/f/+/" +
                        "v7//v7+//7+/v/+/v7//////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////7+/v/9fX1//f39//+/" +
                        "v7//////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////9/f3//////////////" +
                        "////Pz8//r6+v/6+vr/+/v7///////////////////////////////////////////////////////9/" +
                        "f3//f39///////////////////////////////////////+/v7//f39//z8/P/8/Pz//f39//Ly8v/5+" +
                        "fn////////////5+fn/+/v7//7+/v///////////+7u7v/Ozs7/qqqq/4mJif9xcXH/YmJi/1xcXP+Ii" +
                        "Ij/fn5+/yoqKv9gYGD/9PT0//39/f///////////////////////////////////////////////////" +
                        "////////////////////Pz8//v7+//9/f3//v7+//39/f///////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////8/Pz//f39//39/f/9/f3//f39//7+/v/+/v7//v7+//z8/P/8/Pz//Pz8//z8/P/8/" +
                        "Pz//Pz8//z8/P/8/Pz/+vr6//b29v////////////7+/v////////////7+/v/9/f3//f39//39/f/9/" +
                        "f3//f39//39/f/9/f3//f39//39/f/9/f3//f39//39/f/9/f3//f39//39/f/9/f3//////////////" +
                        "//////////////////////////////+/v7//v7+//39/f/9/f3//Pz8//z8/P/8/Pz//Pz8//39/f/9/" +
                        "f3//f39//39/f/9/f3//f39//39/f/9/f3/+Pj4//////////////////////////////////7+/v///" +
                        "////////////////////////////////////////////////////f39//39/f/9/f3/+/v7//r6+v/7+" +
                        "/v//////////////////////////////////v7+//39/f///////v7+//z8/P/+/v7/+fn5//39/f/9/" +
                        "f3/9/f3//n5+f/9/f3/////////////////9fX1/+np6f/h4eH/s7Oz/6Ojo/99fX3/sLCw//39/f/9/" +
                        "f3///////7+/v/////////////////////////////////////////////////8/Pz/+fn5//v7+//+/" +
                        "v7//////////////////v7+//7+/v/+/v7//////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////f39//7+/v/+/v7////////////5+fn//////////////////////////////////////////////" +
                        "/////////////////////////////////////////7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/" +
                        "v7//////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////v7+//39/f/8/Pz//f39//z8/P/8/Pz//////////////////////////////" +
                        "//////////////+/v7//f39//////////////////////////////////v7+//6+vr/+vr6//v7+//8/" +
                        "Pz///////////////////////f39//5+fn/+/v7///////////////////////9/f3//f39//z8/P/8/" +
                        "Pz//Pz8//z8/P/9/f3//f39///////29vb/4ODg//Ly8v////////////7+/v///////////////////" +
                        "////////////////////////////////////v7+//////////////////z8/P/8/Pz///////7+/v///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////+/v7//v7+//39/f/9/" +
                        "f3////////////////////////////////////////////7+/v///////7+/v/6+vr////////////8/" +
                        "Pz///////7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/" +
                        "v7//v7+//7+/v////////////////////////////////////////////39/f/9/f3//f39//7+/v/+/" +
                        "v7//v7+//7+/v///////f39//39/f/9/f3//f39//39/f/9/f3//f39//39/f///////Pz8//z8/P///" +
                        "/////////////////////////////////////////////////////////////////////////39/f/9/" +
                        "f3///////7+/v/7+/v//v7+///////////////////////////////////////+/v7//f39//7+/v/9/" +
                        "f3///////39/f//////+fn5///////8/Pz////////////////////////////////////////////6+" +
                        "vr/////////////////+vr6///////5+fn//////////////////////////////////////////////" +
                        "///CwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAA";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblAMMBesch = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.KAAMMBescheinigung_AnAbwesenheiten = new DevExpress.XtraReports.UI.Subreport();
            this.txtBerater = new DevExpress.XtraReports.UI.XRLabel();
            this.KAAMMBescheinigung_Abbruch = new DevExpress.XtraReports.UI.Subreport();
            this.pnlFooter = new DevExpress.XtraReports.UI.XRPanel();
            this.KAAMMBescheinigung_Praesenz = new DevExpress.XtraReports.UI.Subreport();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.pnlHeader = new DevExpress.XtraReports.UI.XRPanel();
            this.KAAMMBescheinigung_AMM = new DevExpress.XtraReports.UI.Subreport();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblZustKa = new DevExpress.XtraReports.UI.XRLabel();
            this.picUnterschrift = new DevExpress.XtraReports.UI.XRPictureBox();
            this.txtOrtDatum = new DevExpress.XtraReports.UI.XRLabel();
            this.txtZustKa = new DevExpress.XtraReports.UI.XRLabel();
            this.lblUnterschrift = new DevExpress.XtraReports.UI.XRLabel();
            this.lblOrtDatum = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTitelMassnahme = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblBeschGrad = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBeschGrad = new DevExpress.XtraReports.UI.XRLabel();
            this.lblGebDat = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGebDat = new DevExpress.XtraReports.UI.XRLabel();
            this.lblAHVNr = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAHVNr = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCheckBox2 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrCheckBox1 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblKursEinsatz = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAdresse = new DevExpress.XtraReports.UI.XRLabel();
            this.txtRAV = new DevExpress.XtraReports.UI.XRLabel();
            this.lblBerater = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine6 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.lblStrichcode = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel25,
                        this.xrLabel24,
                        this.xrLabel26,
                        this.xrLabel23,
                        this.xrLabel22,
                        this.xrLabel21,
                        this.xrLabel20,
                        this.xrLabel19,
                        this.xrLabel15,
                        this.xrLabel14,
                        this.xrLabel13,
                        this.xrLabel18,
                        this.xrLabel17,
                        this.xrLabel16,
                        this.xrLabel12,
                        this.xrLabel11});
            this.PageHeader.Dpi = 254F;
            this.PageHeader.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.PageHeader.Height = 590;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.ParentStyleUsing.UseFont = false;
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel8,
                        this.xrLabel7,
                        this.lblAMMBesch,
                        this.xrLabel2,
                        this.KAAMMBescheinigung_AnAbwesenheiten,
                        this.txtBerater,
                        this.KAAMMBescheinigung_Abbruch,
                        this.pnlFooter,
                        this.KAAMMBescheinigung_Praesenz,
                        this.xrLabel3,
                        this.pnlHeader,
                        this.KAAMMBescheinigung_AMM});
            this.Detail.Dpi = 254F;
            this.Detail.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Detail.Height = 1060;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseFont = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblStrichcode,
                        this.xrPictureBox2,
                        this.xrPictureBox1});
            this.PageFooter.Dpi = 254F;
            this.PageFooter.Height = 200;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrLabel25
            // 
            this.xrLabel25.Dpi = 254F;
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel25.Location = new System.Drawing.Point(169, 215);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel25.ParentStyleUsing.UseBorders = false;
            this.xrLabel25.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel25.ParentStyleUsing.UseFont = false;
            this.xrLabel25.Size = new System.Drawing.Size(508, 40);
            this.xrLabel25.Text = "Anbieter:";
            // 
            // xrLabel24
            // 
            this.xrLabel24.Dpi = 254F;
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel24.Location = new System.Drawing.Point(169, 380);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel24.ParentStyleUsing.UseBorders = false;
            this.xrLabel24.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel24.ParentStyleUsing.UseFont = false;
            this.xrLabel24.Size = new System.Drawing.Size(508, 40);
            this.xrLabel24.Text = "3001 Bern";
            // 
            // xrLabel26
            // 
            this.xrLabel26.Dpi = 254F;
            this.xrLabel26.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel26.Location = new System.Drawing.Point(169, 340);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel26.ParentStyleUsing.UseBorders = false;
            this.xrLabel26.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel26.ParentStyleUsing.UseFont = false;
            this.xrLabel26.Size = new System.Drawing.Size(508, 40);
            this.xrLabel26.Text = "Postfach";
            // 
            // xrLabel23
            // 
            this.xrLabel23.Dpi = 254F;
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel23.Location = new System.Drawing.Point(169, 300);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel23.ParentStyleUsing.UseBorders = false;
            this.xrLabel23.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel23.ParentStyleUsing.UseFont = false;
            this.xrLabel23.Size = new System.Drawing.Size(508, 40);
            this.xrLabel23.Text = "Lorrainestrasse 52";
            // 
            // xrLabel22
            // 
            this.xrLabel22.Dpi = 254F;
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel22.Location = new System.Drawing.Point(169, 260);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel22.ParentStyleUsing.UseBorders = false;
            this.xrLabel22.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel22.ParentStyleUsing.UseFont = false;
            this.xrLabel22.Size = new System.Drawing.Size(508, 40);
            this.xrLabel22.Text = "Kompetenzzentrum Arbeit KA";
            // 
            // xrLabel21
            // 
            this.xrLabel21.Dpi = 254F;
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel21.Location = new System.Drawing.Point(656, 3);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel21.ParentStyleUsing.UseFont = false;
            this.xrLabel21.Size = new System.Drawing.Size(106, 42);
            this.xrLabel21.Text = "beco";
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 254F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel20.Location = new System.Drawing.Point(656, 42);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel20.ParentStyleUsing.UseFont = false;
            this.xrLabel20.Size = new System.Drawing.Size(339, 42);
            this.xrLabel20.Text = "Economie bernoise";
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 254F;
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel19.Location = new System.Drawing.Point(656, 98);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel19.ParentStyleUsing.UseFont = false;
            this.xrLabel19.Size = new System.Drawing.Size(339, 42);
            this.xrLabel19.Text = "Service de l‘emploi";
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 254F;
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel15.Location = new System.Drawing.Point(169, 98);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel15.ParentStyleUsing.UseFont = false;
            this.xrLabel15.Size = new System.Drawing.Size(339, 42);
            this.xrLabel15.Text = "Arbeitsvermittlung";
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 254F;
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.Location = new System.Drawing.Point(169, 42);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel14.ParentStyleUsing.UseFont = false;
            this.xrLabel14.Size = new System.Drawing.Size(339, 42);
            this.xrLabel14.Text = "Berner Wirtschaft";
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 254F;
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.Location = new System.Drawing.Point(169, 3);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel13.ParentStyleUsing.UseFont = false;
            this.xrLabel13.Size = new System.Drawing.Size(106, 42);
            this.xrLabel13.Text = "beco";
            // 
            // xrLabel18
            // 
            this.xrLabel18.Dpi = 254F;
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel18.Location = new System.Drawing.Point(169, 530);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel18.ParentStyleUsing.UseBorders = false;
            this.xrLabel18.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel18.ParentStyleUsing.UseFont = false;
            this.xrLabel18.Size = new System.Drawing.Size(508, 40);
            this.xrLabel18.Text = "E-Mail: david.hesse@bern.ch";
            // 
            // xrLabel17
            // 
            this.xrLabel17.Dpi = 254F;
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel17.Location = new System.Drawing.Point(169, 490);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel17.ParentStyleUsing.UseBorders = false;
            this.xrLabel17.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel17.ParentStyleUsing.UseFont = false;
            this.xrLabel17.Size = new System.Drawing.Size(508, 40);
            this.xrLabel17.Text = "Telefon: 031 321 78 17";
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 254F;
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel16.Location = new System.Drawing.Point(169, 450);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel16.ParentStyleUsing.UseBorders = false;
            this.xrLabel16.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel16.ParentStyleUsing.UseFont = false;
            this.xrLabel16.Size = new System.Drawing.Size(508, 40);
            this.xrLabel16.Text = "Kontaktperson: David Hesse";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 254F;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel12.Location = new System.Drawing.Point(1228, 368);
            this.xrLabel12.Multiline = true;
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel12.ParentStyleUsing.UseBorders = false;
            this.xrLabel12.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel12.ParentStyleUsing.UseFont = false;
            this.xrLabel12.Size = new System.Drawing.Size(611, 169);
            this.xrLabel12.Text = "[ALKAdresse]";
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 254F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel11.Location = new System.Drawing.Point(1228, 331);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel11.ParentStyleUsing.UseBorders = false;
            this.xrLabel11.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel11.ParentStyleUsing.UseFont = false;
            this.xrLabel11.Size = new System.Drawing.Size(611, 39);
            this.xrLabel11.Text = "Arbeitslosenkasse Nr. [ALKNr]";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 254F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.Location = new System.Drawing.Point(1355, 13);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.Size = new System.Drawing.Size(508, 42);
            this.xrLabel8.Text = "Monat: [Monat] Jahr: [Jahr]";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 254F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.Location = new System.Drawing.Point(529, 13);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.Size = new System.Drawing.Size(720, 42);
            this.xrLabel7.Text = "[NameAMM]";
            // 
            // lblAMMBesch
            // 
            this.lblAMMBesch.Dpi = 254F;
            this.lblAMMBesch.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblAMMBesch.Location = new System.Drawing.Point(169, 13);
            this.lblAMMBesch.Name = "lblAMMBesch";
            this.lblAMMBesch.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblAMMBesch.ParentStyleUsing.UseFont = false;
            this.lblAMMBesch.Size = new System.Drawing.Size(360, 42);
            this.lblAMMBesch.Text = "AMM-Bescheinigung";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel2.Location = new System.Drawing.Point(169, 77);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.ParentStyleUsing.UseBackColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorders = false;
            this.xrLabel2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(1694, 106);
            this.xrLabel2.Text = resources.GetString("xrLabel2.Text");
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify;
            // 
            // KAAMMBescheinigung_AnAbwesenheiten
            // 
            this.KAAMMBescheinigung_AnAbwesenheiten.Dpi = 254F;
            this.KAAMMBescheinigung_AnAbwesenheiten.Location = new System.Drawing.Point(148, 466);
            this.KAAMMBescheinigung_AnAbwesenheiten.Name = "KAAMMBescheinigung_AnAbwesenheiten";
            // 
            // txtBerater
            // 
            this.txtBerater.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Berater", "")});
            this.txtBerater.Dpi = 254F;
            this.txtBerater.Font = new System.Drawing.Font("Arial", 8F);
            this.txtBerater.Location = new System.Drawing.Point(1143, 265);
            this.txtBerater.Name = "txtBerater";
            this.txtBerater.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtBerater.ParentStyleUsing.UseBorders = false;
            this.txtBerater.ParentStyleUsing.UseBorderWidth = false;
            this.txtBerater.ParentStyleUsing.UseFont = false;
            this.txtBerater.Size = new System.Drawing.Size(696, 42);
            this.txtBerater.Text = "txtBerater";
            // 
            // KAAMMBescheinigung_Abbruch
            // 
            this.KAAMMBescheinigung_Abbruch.Dpi = 254F;
            this.KAAMMBescheinigung_Abbruch.Location = new System.Drawing.Point(148, 593);
            this.KAAMMBescheinigung_Abbruch.Name = "KAAMMBescheinigung_Abbruch";
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel4,
                        this.lblZustKa,
                        this.picUnterschrift,
                        this.txtOrtDatum,
                        this.txtZustKa,
                        this.lblUnterschrift,
                        this.lblOrtDatum,
                        this.lblTitelMassnahme});
            this.pnlFooter.Dpi = 254F;
            this.pnlFooter.Location = new System.Drawing.Point(148, 672);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.ParentStyleUsing.UseBorders = false;
            this.pnlFooter.Size = new System.Drawing.Size(1736, 385);
            // 
            // KAAMMBescheinigung_Praesenz
            // 
            this.KAAMMBescheinigung_Praesenz.Dpi = 254F;
            this.KAAMMBescheinigung_Praesenz.Location = new System.Drawing.Point(148, 524);
            this.KAAMMBescheinigung_Praesenz.Name = "KAAMMBescheinigung_Praesenz";
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Kurs", "")});
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel3.Location = new System.Drawing.Point(347, 397);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(752, 42);
            this.xrLabel3.Text = "xrLabel3";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right)));
            this.pnlHeader.CanGrow = false;
            this.pnlHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel10,
                        this.xrLabel1,
                        this.lblBeschGrad,
                        this.txtBeschGrad,
                        this.lblGebDat,
                        this.txtGebDat,
                        this.lblAHVNr,
                        this.txtAHVNr,
                        this.xrLabel9,
                        this.xrLabel6,
                        this.xrCheckBox2,
                        this.xrCheckBox1,
                        this.xrLabel5,
                        this.lblKursEinsatz,
                        this.txtAdresse,
                        this.txtRAV,
                        this.lblBerater,
                        this.xrLine6,
                        this.xrLine2});
            this.pnlHeader.Dpi = 254F;
            this.pnlHeader.Location = new System.Drawing.Point(148, 204);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.ParentStyleUsing.UseBorders = false;
            this.pnlHeader.Size = new System.Drawing.Size(1736, 245);
            // 
            // KAAMMBescheinigung_AMM
            // 
            this.KAAMMBescheinigung_AMM.Dpi = 254F;
            this.KAAMMBescheinigung_AMM.Location = new System.Drawing.Point(0, 423);
            this.KAAMMBescheinigung_AMM.Name = "KAAMMBescheinigung_AMM";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel4.Location = new System.Drawing.Point(21, 21);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(1524, 42);
            this.xrLabel4.Text = "Die unterzeichnende Person bestätigt, alle Fragen vollständig und wahrheitsgetreu" +
                " beantwortet zu haben.";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblZustKa
            // 
            this.lblZustKa.Dpi = 254F;
            this.lblZustKa.Font = new System.Drawing.Font("Arial", 8F);
            this.lblZustKa.Location = new System.Drawing.Point(21, 130);
            this.lblZustKa.Name = "lblZustKa";
            this.lblZustKa.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblZustKa.ParentStyleUsing.UseBackColor = false;
            this.lblZustKa.ParentStyleUsing.UseBorderColor = false;
            this.lblZustKa.ParentStyleUsing.UseBorders = false;
            this.lblZustKa.ParentStyleUsing.UseBorderWidth = false;
            this.lblZustKa.ParentStyleUsing.UseFont = false;
            this.lblZustKa.Size = new System.Drawing.Size(296, 43);
            this.lblZustKa.Text = "Name und Vorname:";
            // 
            // picUnterschrift
            // 
            this.picUnterschrift.Dpi = 254F;
            this.picUnterschrift.Image = ((System.Drawing.Image)(resources.GetObject("picUnterschrift.Image")));
            this.picUnterschrift.Location = new System.Drawing.Point(323, 220);
            this.picUnterschrift.Name = "picUnterschrift";
            this.picUnterschrift.ParentStyleUsing.UseBackColor = false;
            this.picUnterschrift.ParentStyleUsing.UseBorderColor = false;
            this.picUnterschrift.ParentStyleUsing.UseBorders = false;
            this.picUnterschrift.ParentStyleUsing.UseBorderWidth = false;
            this.picUnterschrift.Size = new System.Drawing.Size(465, 169);
            this.picUnterschrift.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // txtOrtDatum
            // 
            this.txtOrtDatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "OrtDatum", "")});
            this.txtOrtDatum.Dpi = 254F;
            this.txtOrtDatum.Font = new System.Drawing.Font("Arial", 8F);
            this.txtOrtDatum.Location = new System.Drawing.Point(318, 177);
            this.txtOrtDatum.Name = "txtOrtDatum";
            this.txtOrtDatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtOrtDatum.ParentStyleUsing.UseBackColor = false;
            this.txtOrtDatum.ParentStyleUsing.UseBorderColor = false;
            this.txtOrtDatum.ParentStyleUsing.UseBorders = false;
            this.txtOrtDatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtOrtDatum.ParentStyleUsing.UseFont = false;
            this.txtOrtDatum.Size = new System.Drawing.Size(529, 42);
            this.txtOrtDatum.Text = "txtOrtDatum";
            this.txtOrtDatum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtZustKa
            // 
            this.txtZustKa.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ZustKA", "")});
            this.txtZustKa.Dpi = 254F;
            this.txtZustKa.Font = new System.Drawing.Font("Arial", 8F);
            this.txtZustKa.Location = new System.Drawing.Point(318, 127);
            this.txtZustKa.Name = "txtZustKa";
            this.txtZustKa.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtZustKa.ParentStyleUsing.UseBackColor = false;
            this.txtZustKa.ParentStyleUsing.UseBorderColor = false;
            this.txtZustKa.ParentStyleUsing.UseBorders = false;
            this.txtZustKa.ParentStyleUsing.UseBorderWidth = false;
            this.txtZustKa.ParentStyleUsing.UseFont = false;
            this.txtZustKa.Size = new System.Drawing.Size(529, 43);
            this.txtZustKa.Text = "txtZustKa";
            this.txtZustKa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblUnterschrift
            // 
            this.lblUnterschrift.Dpi = 254F;
            this.lblUnterschrift.Font = new System.Drawing.Font("Arial", 8F);
            this.lblUnterschrift.Location = new System.Drawing.Point(21, 283);
            this.lblUnterschrift.Name = "lblUnterschrift";
            this.lblUnterschrift.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblUnterschrift.ParentStyleUsing.UseBackColor = false;
            this.lblUnterschrift.ParentStyleUsing.UseBorderColor = false;
            this.lblUnterschrift.ParentStyleUsing.UseBorders = false;
            this.lblUnterschrift.ParentStyleUsing.UseBorderWidth = false;
            this.lblUnterschrift.ParentStyleUsing.UseFont = false;
            this.lblUnterschrift.Size = new System.Drawing.Size(381, 42);
            this.lblUnterschrift.Text = "Unterschrift: i.A.";
            // 
            // lblOrtDatum
            // 
            this.lblOrtDatum.Dpi = 254F;
            this.lblOrtDatum.Font = new System.Drawing.Font("Arial", 8F);
            this.lblOrtDatum.Location = new System.Drawing.Point(21, 180);
            this.lblOrtDatum.Name = "lblOrtDatum";
            this.lblOrtDatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblOrtDatum.ParentStyleUsing.UseBackColor = false;
            this.lblOrtDatum.ParentStyleUsing.UseBorderColor = false;
            this.lblOrtDatum.ParentStyleUsing.UseBorders = false;
            this.lblOrtDatum.ParentStyleUsing.UseBorderWidth = false;
            this.lblOrtDatum.ParentStyleUsing.UseFont = false;
            this.lblOrtDatum.Size = new System.Drawing.Size(212, 42);
            this.lblOrtDatum.Text = "Ort und Datum:";
            // 
            // lblTitelMassnahme
            // 
            this.lblTitelMassnahme.Dpi = 254F;
            this.lblTitelMassnahme.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblTitelMassnahme.Location = new System.Drawing.Point(21, 77);
            this.lblTitelMassnahme.Multiline = true;
            this.lblTitelMassnahme.Name = "lblTitelMassnahme";
            this.lblTitelMassnahme.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblTitelMassnahme.ParentStyleUsing.UseBackColor = false;
            this.lblTitelMassnahme.ParentStyleUsing.UseBorderColor = false;
            this.lblTitelMassnahme.ParentStyleUsing.UseBorders = false;
            this.lblTitelMassnahme.ParentStyleUsing.UseBorderWidth = false;
            this.lblTitelMassnahme.ParentStyleUsing.UseFont = false;
            this.lblTitelMassnahme.Size = new System.Drawing.Size(381, 43);
            this.lblTitelMassnahme.Text = "Verantwortliche Person:";
            this.lblTitelMassnahme.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 254F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel10.Location = new System.Drawing.Point(21, 53);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel10.ParentStyleUsing.UseBorders = false;
            this.xrLabel10.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel10.ParentStyleUsing.UseFont = false;
            this.xrLabel10.Size = new System.Drawing.Size(508, 42);
            this.xrLabel10.Text = "[Name]";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel1.Location = new System.Drawing.Point(21, 130);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(508, 40);
            this.xrLabel1.Text = "[PLZOrt]";
            // 
            // lblBeschGrad
            // 
            this.lblBeschGrad.Dpi = 254F;
            this.lblBeschGrad.Font = new System.Drawing.Font("Arial", 8F);
            this.lblBeschGrad.Location = new System.Drawing.Point(542, 132);
            this.lblBeschGrad.Name = "lblBeschGrad";
            this.lblBeschGrad.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblBeschGrad.ParentStyleUsing.UseBackColor = false;
            this.lblBeschGrad.ParentStyleUsing.UseBorderColor = false;
            this.lblBeschGrad.ParentStyleUsing.UseBorders = false;
            this.lblBeschGrad.ParentStyleUsing.UseBorderWidth = false;
            this.lblBeschGrad.ParentStyleUsing.UseFont = false;
            this.lblBeschGrad.Size = new System.Drawing.Size(275, 42);
            this.lblBeschGrad.Text = "Beschäftigungsgrad:";
            this.lblBeschGrad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtBeschGrad
            // 
            this.txtBeschGrad.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BeschGrad", "")});
            this.txtBeschGrad.Dpi = 254F;
            this.txtBeschGrad.Font = new System.Drawing.Font("Arial", 8F);
            this.txtBeschGrad.Location = new System.Drawing.Point(815, 130);
            this.txtBeschGrad.Name = "txtBeschGrad";
            this.txtBeschGrad.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtBeschGrad.ParentStyleUsing.UseBackColor = false;
            this.txtBeschGrad.ParentStyleUsing.UseBorderColor = false;
            this.txtBeschGrad.ParentStyleUsing.UseBorders = false;
            this.txtBeschGrad.ParentStyleUsing.UseBorderWidth = false;
            this.txtBeschGrad.ParentStyleUsing.UseFont = false;
            this.txtBeschGrad.Size = new System.Drawing.Size(148, 43);
            this.txtBeschGrad.Text = "txtBeschGrad";
            this.txtBeschGrad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblGebDat
            // 
            this.lblGebDat.Dpi = 254F;
            this.lblGebDat.Font = new System.Drawing.Font("Arial", 8F);
            this.lblGebDat.Location = new System.Drawing.Point(542, 95);
            this.lblGebDat.Name = "lblGebDat";
            this.lblGebDat.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblGebDat.ParentStyleUsing.UseBackColor = false;
            this.lblGebDat.ParentStyleUsing.UseBorderColor = false;
            this.lblGebDat.ParentStyleUsing.UseBorders = false;
            this.lblGebDat.ParentStyleUsing.UseBorderWidth = false;
            this.lblGebDat.ParentStyleUsing.UseFont = false;
            this.lblGebDat.Size = new System.Drawing.Size(212, 42);
            this.lblGebDat.Text = "Geburtsdatum:";
            // 
            // txtGebDat
            // 
            this.txtGebDat.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GebDat", "")});
            this.txtGebDat.Dpi = 254F;
            this.txtGebDat.Font = new System.Drawing.Font("Arial", 8F);
            this.txtGebDat.Location = new System.Drawing.Point(754, 95);
            this.txtGebDat.Name = "txtGebDat";
            this.txtGebDat.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtGebDat.ParentStyleUsing.UseBorders = false;
            this.txtGebDat.ParentStyleUsing.UseBorderWidth = false;
            this.txtGebDat.ParentStyleUsing.UseFont = false;
            this.txtGebDat.Size = new System.Drawing.Size(212, 40);
            this.txtGebDat.Text = "txtGebDat";
            // 
            // lblAHVNr
            // 
            this.lblAHVNr.Dpi = 254F;
            this.lblAHVNr.Font = new System.Drawing.Font("Arial", 8F);
            this.lblAHVNr.Location = new System.Drawing.Point(542, 53);
            this.lblAHVNr.Name = "lblAHVNr";
            this.lblAHVNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblAHVNr.ParentStyleUsing.UseBackColor = false;
            this.lblAHVNr.ParentStyleUsing.UseBorderColor = false;
            this.lblAHVNr.ParentStyleUsing.UseBorders = false;
            this.lblAHVNr.ParentStyleUsing.UseBorderWidth = false;
            this.lblAHVNr.ParentStyleUsing.UseFont = false;
            this.lblAHVNr.Size = new System.Drawing.Size(106, 42);
            this.lblAHVNr.Text = "SV-Nr.:";
            // 
            // txtAHVNr
            // 
            this.txtAHVNr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AHVNr", "")});
            this.txtAHVNr.Dpi = 254F;
            this.txtAHVNr.Font = new System.Drawing.Font("Arial", 8F);
            this.txtAHVNr.Location = new System.Drawing.Point(648, 53);
            this.txtAHVNr.Name = "txtAHVNr";
            this.txtAHVNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtAHVNr.ParentStyleUsing.UseBorders = false;
            this.txtAHVNr.ParentStyleUsing.UseBorderWidth = false;
            this.txtAHVNr.ParentStyleUsing.UseFont = false;
            this.txtAHVNr.Size = new System.Drawing.Size(317, 42);
            this.txtAHVNr.Text = "txtAHVNr";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 254F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.Location = new System.Drawing.Point(21, 16);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel9.ParentStyleUsing.UseBackColor = false;
            this.xrLabel9.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel9.ParentStyleUsing.UseBorders = false;
            this.xrLabel9.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.Size = new System.Drawing.Size(190, 42);
            this.xrLabel9.Text = "RAV-Kundin:";
            // 
            // xrLabel6
            // 
            this.xrLabel6.BorderWidth = 0;
            this.xrLabel6.Dpi = 254F;
            this.xrLabel6.Location = new System.Drawing.Point(995, 101);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel6.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel6.Size = new System.Drawing.Size(84, 45);
            this.xrLabel6.Text = "RAV";
            // 
            // xrCheckBox2
            // 
            this.xrCheckBox2.BorderWidth = 0;
            this.xrCheckBox2.Checked = true;
            this.xrCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.xrCheckBox2.Dpi = 254F;
            this.xrCheckBox2.Location = new System.Drawing.Point(1545, 198);
            this.xrCheckBox2.Name = "xrCheckBox2";
            this.xrCheckBox2.ParentStyleUsing.UseBorderWidth = false;
            this.xrCheckBox2.Size = new System.Drawing.Size(169, 34);
            this.xrCheckBox2.Text = "Nein";
            // 
            // xrCheckBox1
            // 
            this.xrCheckBox1.BorderWidth = 0;
            this.xrCheckBox1.Dpi = 254F;
            this.xrCheckBox1.Location = new System.Drawing.Point(1376, 198);
            this.xrCheckBox1.Name = "xrCheckBox1";
            this.xrCheckBox1.ParentStyleUsing.UseBorderWidth = false;
            this.xrCheckBox1.Size = new System.Drawing.Size(127, 34);
            this.xrCheckBox1.Text = "Ja";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 254F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel5.Location = new System.Drawing.Point(995, 196);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel5.ParentStyleUsing.UseBackColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorders = false;
            this.xrLabel5.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(360, 37);
            this.xrLabel5.Text = "Subventionierte Kantine?";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblKursEinsatz
            // 
            this.lblKursEinsatz.Dpi = 254F;
            this.lblKursEinsatz.Font = new System.Drawing.Font("Arial", 8F);
            this.lblKursEinsatz.Location = new System.Drawing.Point(21, 194);
            this.lblKursEinsatz.Name = "lblKursEinsatz";
            this.lblKursEinsatz.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblKursEinsatz.ParentStyleUsing.UseBackColor = false;
            this.lblKursEinsatz.ParentStyleUsing.UseBorderColor = false;
            this.lblKursEinsatz.ParentStyleUsing.UseBorders = false;
            this.lblKursEinsatz.ParentStyleUsing.UseBorderWidth = false;
            this.lblKursEinsatz.ParentStyleUsing.UseFont = false;
            this.lblKursEinsatz.Size = new System.Drawing.Size(169, 42);
            this.lblKursEinsatz.Text = "Einsatzort:";
            this.lblKursEinsatz.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtAdresse
            // 
            this.txtAdresse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Adresse", "")});
            this.txtAdresse.Dpi = 254F;
            this.txtAdresse.Font = new System.Drawing.Font("Arial", 8F);
            this.txtAdresse.Location = new System.Drawing.Point(21, 93);
            this.txtAdresse.Name = "txtAdresse";
            this.txtAdresse.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtAdresse.ParentStyleUsing.UseBorders = false;
            this.txtAdresse.ParentStyleUsing.UseBorderWidth = false;
            this.txtAdresse.ParentStyleUsing.UseFont = false;
            this.txtAdresse.Size = new System.Drawing.Size(508, 40);
            this.txtAdresse.Text = "txtAdresse";
            // 
            // txtRAV
            // 
            this.txtRAV.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "RAV", "")});
            this.txtRAV.Dpi = 254F;
            this.txtRAV.Font = new System.Drawing.Font("Arial", 8F);
            this.txtRAV.Location = new System.Drawing.Point(1080, 101);
            this.txtRAV.Name = "txtRAV";
            this.txtRAV.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtRAV.ParentStyleUsing.UseBorders = false;
            this.txtRAV.ParentStyleUsing.UseBorderWidth = false;
            this.txtRAV.ParentStyleUsing.UseFont = false;
            this.txtRAV.Size = new System.Drawing.Size(613, 45);
            this.txtRAV.Text = "txtRAV";
            // 
            // lblBerater
            // 
            this.lblBerater.Dpi = 254F;
            this.lblBerater.Font = new System.Drawing.Font("Arial", 8F);
            this.lblBerater.Location = new System.Drawing.Point(995, 21);
            this.lblBerater.Name = "lblBerater";
            this.lblBerater.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblBerater.ParentStyleUsing.UseBackColor = false;
            this.lblBerater.ParentStyleUsing.UseBorderColor = false;
            this.lblBerater.ParentStyleUsing.UseBorders = false;
            this.lblBerater.ParentStyleUsing.UseBorderWidth = false;
            this.lblBerater.ParentStyleUsing.UseFont = false;
            this.lblBerater.Size = new System.Drawing.Size(698, 43);
            this.lblBerater.Text = "Personalberaterin:";
            // 
            // xrLine6
            // 
            this.xrLine6.Dpi = 254F;
            this.xrLine6.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine6.LineWidth = 3;
            this.xrLine6.Location = new System.Drawing.Point(974, 0);
            this.xrLine6.Name = "xrLine6";
            this.xrLine6.ParentStyleUsing.UseBorders = false;
            this.xrLine6.Size = new System.Drawing.Size(11, 270);
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 254F;
            this.xrLine2.LineWidth = 3;
            this.xrLine2.Location = new System.Drawing.Point(0, 183);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.ParentStyleUsing.UseBorders = false;
            this.xrLine2.Size = new System.Drawing.Size(1842, 10);
            // 
            // lblStrichcode
            // 
            this.lblStrichcode.BorderWidth = 0;
            this.lblStrichcode.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "PERStrichcode", "")});
            this.lblStrichcode.Dpi = 254F;
            this.lblStrichcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.lblStrichcode.Location = new System.Drawing.Point(624, 21);
            this.lblStrichcode.Name = "lblStrichcode";
            this.lblStrichcode.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblStrichcode.ParentStyleUsing.UseBorderWidth = false;
            this.lblStrichcode.ParentStyleUsing.UseFont = false;
            this.lblStrichcode.Scripts.OnBeforePrint = resources.GetString("lblStrichcode.Scripts.OnBeforePrint");
            this.lblStrichcode.Size = new System.Drawing.Size(783, 127);
            this.lblStrichcode.Text = "lblStrichcode";
            this.lblStrichcode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrPictureBox2
            // 
            this.xrPictureBox2.Dpi = 254F;
            this.xrPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox2.Image")));
            this.xrPictureBox2.Location = new System.Drawing.Point(1482, 11);
            this.xrPictureBox2.Name = "xrPictureBox2";
            this.xrPictureBox2.Size = new System.Drawing.Size(357, 127);
            this.xrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Dpi = 254F;
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.Location = new System.Drawing.Point(169, 21);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.Size = new System.Drawing.Size(381, 127);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
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
            this.Dpi = 254F;
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Margins = new System.Drawing.Printing.Margins(90, 90, 90, 90);
            this.Name = "Report";
            this.PageHeight = 2969;
            this.PageWidth = 2101;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.ScriptReferencesString = "KiSS4.Common.dll";
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' , ParameterXML =  N'<NewDataSet>
       <Table>
		<FieldName>BaPersonID</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>Person ID</DisplayText>
		<TabPosition>1</TabPosition>
		<X>120</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>    
        <Table>
		<FieldName>KaEinsatzID</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>Einsatz ID</DisplayText>
		<TabPosition>2</TabPosition>
		<X>120</X>
		<Y>90</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>    
</NewDataSet>' , SQLquery =  N'SELECT 	ProfilNummer = dbo.fnLOVText(''KaProfil'', KEP.ProfilCode),
	NameVorname = PRS.Name + IsNull('' '' + PRS.Vorname, ''''),
	AHVNr = IsNull(PRS.Versichertennummer, PRS.AHVNummer),
	Name = PRS.Name + '' '' + PRS.Vorname,
	Adresse = PRS.WohnsitzStrasseHausNr,
	PLZOrt = PRS.WohnsitzPLZOrt,
	GebDat = CONVERT(VARCHAR, PRS.Geburtsdatum, 104),
	ALKNr = ORG.InstitutionNr,
	ALKAdresse = ORG.Name + CHAR(13) + CHAR(10) +
	             ISNULL(ORG.AdressZusatz + CHAR(13) + CHAR(10), '''') +
	             ISNULL(ORG.StrasseHausNr + CHAR(13) + CHAR(10), '''') +
	             ISNULL(ORG.PostfachTextD + CHAR(13) + CHAR(10), '''') +
	             ISNULL(ORG.PLZOrt, ''''),
	Monat = dbo.fnXMonat(AMM.Monat),
	Jahr = AMM.Jahr,
	RAV = CASE WHEN KAE.ZuweiserID < 0 THEN
			IsNull(XOU.ItemName, '''')
		ELSE IsNull(ORG1.Name, '''')
		END,
	Berater = CASE WHEN KAE.ZuweiserID < 0 THEN
			XUR1.LastName + IsNull('' '' + XUR1.FirstName,'''')
		ELSE OKO.Name + IsNull('' '' + OKO.Vorname,'''')
		END,
        BeschGrad = IsNull(CONVERT(VARCHAR, KAE.BeschGrad) + ''%'', ''''),
        Kurs = dbo.fnLOVText(''KAFachbereich'', KZF.FachbereichID),
	ZustKA = XUR.LastName + IsNull('' '' + XUR.FirstName,''''),
	OrtDatum = ''Bern, '' + CONVERT(VARCHAR, GetDate(), 104),
	NameAMM = KEP.Name,
	PERStrichcode = ''*PER-'' + ISNULL(CONVERT(VARCHAR, KAE.PersonenNr),'''') + ''*'',
	AMM.*
FROM dbo.KaAMMBesch                  AMM
  LEFT JOIN dbo.KaEinsatzplatz2      KEP  WITH (READUNCOMMITTED) ON KEP.KaEinsatzplatzID = AMM.KaEinsatzplatzID
  LEFT JOIN dbo.vwPerson             PRS  WITH (READUNCOMMITTED) ON PRS.BaPersonID = AMM.BaPersonID
  LEFT JOIN dbo.KaEinsatz            KAE  WITH (READUNCOMMITTED) ON KAE.KaEinsatzID = AMM.KaEinsatzID
  LEFT JOIN dbo.vwInstitution        ORG  WITH (READUNCOMMITTED) ON ORG.BaInstitutionID = KAE.ALKasseID
  LEFT JOIN dbo.XUser                XUR1 WITH (READUNCOMMITTED) ON XUR1.UserID = -KAE.ZuweiserID		
  LEFT JOIN dbo.BaInstitutionKontakt OKO  WITH (READUNCOMMITTED) ON OKO.BaInstitutionKontaktID = KAE.ZuweiserID
  LEFT JOIN dbo.BaInstitution        ORG1 WITH (READUNCOMMITTED) ON ORG1.BaInstitutionID = OKO.BaInstitutionID	
  LEFT JOIN dbo.XOrgUnit_User        OUU  WITH (READUNCOMMITTED) ON OUU.UserID = -KAE.ZuweiserID and (OUU.OrgUnitMemberCode = 1 OR OUU.OrgUnitMemberCode = 2)
  LEFT JOIN dbo.XOrgUnit             XOU  WITH (READUNCOMMITTED) ON XOU.OrgUnitID = OUU.OrgUnitID
  LEFT JOIN dbo.KaZuteilFachbereich  KZF  WITH (READUNCOMMITTED) ON KZF.KaZuteilFachbereichID = (SELECT TOP 1 KaZuteilFachbereichID
                                                                                                  FROM dbo.KaZuteilFachbereich WITH (READUNCOMMITTED)
                                                                                                  WHERE BaPersonID = AMM.BaPersonID
                                                                                                    AND ZuteilungVon < KAE.DatumBis
                                                                                                  ORDER BY ZuteilungVon DESC)
   LEFT JOIN dbo.XUser XUR WITH (READUNCOMMITTED) ON XUR.UserID = KZF.ZustaendigKaID
WHERE AMM.BaPersonID = {BaPersonID}
   AND AMM.KaEinsatzID = {KaEinsatzID}
   AND AMM.KaAmmBeschID = {KaAmmBeschID};' , ContextForms =  N'FrmKaAMMBescheinigung' , ParentReportName =  null , ReportSortKey =  null , System =  0 
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'KAAAMBescheinigung' ;


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'KAAMMBescheinigung_Abbruch' ,  N'KA - AMM Bescheinigung, Abbruch Massnahme' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\Kiss.Interfaces.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\FluentValidation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xml.Linq\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.Linq.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\log4net.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\Microsoft.Practices.Unity.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\Ionic.Zip.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\Kiss.BL.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\Kiss.Model.dll" />
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
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\KiSS.Common.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\Autofac.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\Common.Logging.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\HtmlAgilityPack.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\Kiss.Database.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\WPFLocalizeExtension.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\XAMLMarkupExtensions.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRLabel lblAbbruch;
        private DevExpress.XtraReports.UI.XRCheckBox cbxOrganisator;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRCheckBox cbxVersicherter;
        private DevExpress.XtraReports.UI.XRCheckBox cbxGegenseitig;
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
                        "AAAAdwIU0VMRUNUIFRPUCAxDQogIGR1cmNoT3JnID0gSXNOdWxsKA0KICAgIENBU0UgV0hFTiAoQVVTL" +
                        "kF1c3RyaXR0RGF0dW0gSVMgTk9UIE5VTEwgQU5EIE1PTlRIKEFVUy5BdXN0cml0dERhdHVtKSA9IEFNT" +
                        "S5Nb25hdCkgVEhFTiANCiAgICAgICAgQVVTLkF1c3RyaXR0RHVyY2hPcmcNCiAgICAgIEVMU0UNCiAgI" +
                        "CAgICAgLS0gS2VpbiBBdXN0cml0dCBpbSBnZXfDpGhsdGVuIE1vbmF0IQ0KICAgICAgICBDb252ZXJ0K" +
                        "GJpdCwgMCkgICAgDQogICAgRU5ELCANCiAgICBDb252ZXJ0KGJpdCwgMCkpLA0KDQogIGR1cmNoVmVyc" +
                        "yA9IElzTnVsbCgNCiAgIENBU0UgV0hFTiAoQVVTLkF1c3RyaXR0RGF0dW0gSVMgTk9UIE5VTEwgQU5EI" +
                        "E1PTlRIKEFVUy5BdXN0cml0dERhdHVtKSA9IEFNTS5Nb25hdCkgVEhFTg0KICAgICAgICBBVVMuQXVzd" +
                        "HJpdHREdXJjaFZlcnMNCiAgICAtLSBLZWluIEF1c3RyaXR0IGltIGdld8OkaGx0ZW4gTW9uYXQhDQogI" +
                        "CAgRUxTRQ0KICAgICAgQ29udmVydChiaXQsIDApICAgIA0KICAgIEVORCwgQ29udmVydChiaXQsIDApK" +
                        "SwNCg0KICBnZWdlbnNlaXRpZyA9IElzTnVsbCgNCiAgIENBU0UgV0hFTiAoQVVTLkF1c3RyaXR0RGF0d" +
                        "W0gSVMgTk9UIE5VTEwgQU5EIE1PTlRIKEFVUy5BdXN0cml0dERhdHVtKSA9IEFNTS5Nb25hdCkgVEhFT" +
                        "g0KIAkgICAgICBBVVMuQXVzdHJpdHRHZWdlbnNlaXRpZw0KICAgLS0gS2VpbiBBdXN0cml0dCBpbSBnZ" +
                        "XfDpGhsdGVuIE1vbmF0IQ0KICAgIEVMU0UNCiAgICAgIENvbnZlcnQoYml0LCAwKSAgICANCiAgICBFT" +
                        "kQsIENvbnZlcnQoYml0LCAwKSkNCg0KRlJPTSBkYm8uS2FBbW1CZXNjaCAgICAgICAgICBBTU0gV0lUS" +
                        "CAoUkVBRFVOQ09NTUlUVEVEKQ0KICBMRUZUIEpPSU4gZGJvLkthRWluc2F0eiAgICBFSU4gV0lUSCAoU" +
                        "kVBRFVOQ09NTUlUVEVEKSBPTiBFSU4uS2FFaW5zYXR6SUQgPSBBTU0uS2FFaW5zYXR6SUQNCiAgT1VUR" +
                        "VIgQVBQTFkgZGJvLmZuS2FHZXRBdXN0cml0dERhdHVtQ29kZShFSU4uRmFMZWlzdHVuZ0lELCBFSU4uS" +
                        "2FFaW5zYXR6SUQpIEFVUw0KV0hFUkUgQU1NLkJhUGVyc29uSUQgPSBudWxsDQpBTkQgQU1NLkthRWluc" +
                        "2F0eklEID0gbnVsbA0KQU5EIEFNTS5LYUFtbUJlc2NoSUQgPSBudWxs";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.lblAbbruch = new DevExpress.XtraReports.UI.XRLabel();
            this.cbxOrganisator = new DevExpress.XtraReports.UI.XRCheckBox();
            this.cbxVersicherter = new DevExpress.XtraReports.UI.XRCheckBox();
            this.cbxGegenseitig = new DevExpress.XtraReports.UI.XRCheckBox();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPanel1});
            this.Detail.Dpi = 254F;
            this.Detail.Height = 70;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBorders = false;
            // 
            // xrPanel1
            // 
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblAbbruch,
                        this.cbxOrganisator,
                        this.cbxVersicherter,
                        this.cbxGegenseitig});
            this.xrPanel1.Dpi = 254F;
            this.xrPanel1.Location = new System.Drawing.Point(0, 0);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.ParentStyleUsing.UseBorders = false;
            this.xrPanel1.Size = new System.Drawing.Size(1736, 70);
            // 
            // lblAbbruch
            // 
            this.lblAbbruch.Dpi = 254F;
            this.lblAbbruch.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblAbbruch.Location = new System.Drawing.Point(21, 11);
            this.lblAbbruch.Name = "lblAbbruch";
            this.lblAbbruch.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblAbbruch.ParentStyleUsing.UseBackColor = false;
            this.lblAbbruch.ParentStyleUsing.UseBorderColor = false;
            this.lblAbbruch.ParentStyleUsing.UseBorders = false;
            this.lblAbbruch.ParentStyleUsing.UseBorderWidth = false;
            this.lblAbbruch.ParentStyleUsing.UseFont = false;
            this.lblAbbruch.Size = new System.Drawing.Size(339, 42);
            this.lblAbbruch.Text = "Abbruch des Einsatzes:";
            this.lblAbbruch.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // cbxOrganisator
            // 
            this.cbxOrganisator.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("CheckState", this.sqlQuery1, "durchOrg", "")});
            this.cbxOrganisator.Dpi = 254F;
            this.cbxOrganisator.Font = new System.Drawing.Font("Arial", 7F);
            this.cbxOrganisator.Location = new System.Drawing.Point(466, 0);
            this.cbxOrganisator.Name = "cbxOrganisator";
            this.cbxOrganisator.ParentStyleUsing.UseBackColor = false;
            this.cbxOrganisator.ParentStyleUsing.UseBorderColor = false;
            this.cbxOrganisator.ParentStyleUsing.UseBorders = false;
            this.cbxOrganisator.ParentStyleUsing.UseBorderWidth = false;
            this.cbxOrganisator.ParentStyleUsing.UseFont = false;
            this.cbxOrganisator.Size = new System.Drawing.Size(317, 64);
            this.cbxOrganisator.Text = " durch Anbieter";
            // 
            // cbxVersicherter
            // 
            this.cbxVersicherter.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("CheckState", this.sqlQuery1, "durchVers", "")});
            this.cbxVersicherter.Dpi = 254F;
            this.cbxVersicherter.Font = new System.Drawing.Font("Arial", 7F);
            this.cbxVersicherter.Location = new System.Drawing.Point(889, 0);
            this.cbxVersicherter.Name = "cbxVersicherter";
            this.cbxVersicherter.ParentStyleUsing.UseBackColor = false;
            this.cbxVersicherter.ParentStyleUsing.UseBorderColor = false;
            this.cbxVersicherter.ParentStyleUsing.UseBorders = false;
            this.cbxVersicherter.ParentStyleUsing.UseBorderWidth = false;
            this.cbxVersicherter.ParentStyleUsing.UseFont = false;
            this.cbxVersicherter.Size = new System.Drawing.Size(296, 64);
            this.cbxVersicherter.Text = "durch RAV-Kundin";
            // 
            // cbxGegenseitig
            // 
            this.cbxGegenseitig.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("CheckState", this.sqlQuery1, "gegenseitig", "")});
            this.cbxGegenseitig.Dpi = 254F;
            this.cbxGegenseitig.Font = new System.Drawing.Font("Arial", 7F);
            this.cbxGegenseitig.Location = new System.Drawing.Point(1312, 0);
            this.cbxGegenseitig.Name = "cbxGegenseitig";
            this.cbxGegenseitig.ParentStyleUsing.UseBackColor = false;
            this.cbxGegenseitig.ParentStyleUsing.UseBorderColor = false;
            this.cbxGegenseitig.ParentStyleUsing.UseBorders = false;
            this.cbxGegenseitig.ParentStyleUsing.UseBorderWidth = false;
            this.cbxGegenseitig.ParentStyleUsing.UseFont = false;
            this.cbxGegenseitig.Size = new System.Drawing.Size(254, 64);
            this.cbxGegenseitig.Text = " gegenseitig";
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
            this.Margins = new System.Drawing.Printing.Margins(254, 147, 254, 254);
            this.Name = "Report";
            this.PageHeight = 2969;
            this.PageWidth = 2101;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'SELECT TOP 1
  durchOrg = IsNull(
    CASE WHEN (AUS.AustrittDatum IS NOT NULL AND MONTH(AUS.AustrittDatum) = AMM.Monat) THEN 
        AUS.AustrittDurchOrg
      ELSE
        -- Kein Austritt im gewählten Monat!
        Convert(bit, 0)    
    END, 
    Convert(bit, 0)),

  durchVers = IsNull(
   CASE WHEN (AUS.AustrittDatum IS NOT NULL AND MONTH(AUS.AustrittDatum) = AMM.Monat) THEN
        AUS.AustrittDurchVers
    -- Kein Austritt im gewählten Monat!
    ELSE
      Convert(bit, 0)    
    END, Convert(bit, 0)),

  gegenseitig = IsNull(
   CASE WHEN (AUS.AustrittDatum IS NOT NULL AND MONTH(AUS.AustrittDatum) = AMM.Monat) THEN
 	      AUS.AustrittGegenseitig
   -- Kein Austritt im gewählten Monat!
    ELSE
      Convert(bit, 0)    
    END, Convert(bit, 0))

FROM dbo.KaAmmBesch          AMM WITH (READUNCOMMITTED)
  LEFT JOIN dbo.KaEinsatz    EIN WITH (READUNCOMMITTED) ON EIN.KaEinsatzID = AMM.KaEinsatzID
  OUTER APPLY dbo.fnKaGetAustrittDatumCode(EIN.FaLeistungID, EIN.KaEinsatzID) AUS
WHERE AMM.BaPersonID = {BaPersonID}
AND AMM.KaEinsatzID = {KaEinsatzID}
AND AMM.KaAmmBeschID = {KaAmmBeschID}' ,  null ,  N'KAAAMBescheinigung' , 2,  0 );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'KAAMMBescheinigung_AMM' ,  N'KA - AMM Bescheinigung, Arbeitsmarkt. Massn.' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\KiSS\Trunk\KiSS4.DB.dll" />
///     <Reference Path="C:\KiSS\Trunk\Kiss.Interfaces.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\KiSS\Trunk\FluentValidation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\KiSS\Trunk\log4net.dll" />
///     <Reference Path="C:\KiSS\Trunk\SharpLibrary.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\KiSS\Trunk\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="C:\KiSS\Trunk\Microsoft.Practices.Unity.dll" />
///     <Reference Path="C:\KiSS\Trunk\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="C:\KiSS\Trunk\Ionic.Zip.dll" />
///     <Reference Path="C:\KiSS\Trunk\Kiss.BL.dll" />
///     <Reference Path="C:\KiSS\Trunk\Kiss.Model.dll" />
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
///     <Reference Path="C:\KiSS\Trunk\KiSS.Common.dll" />
///     <Reference Path="C:\KiSS\Trunk\Autofac.dll" />
///     <Reference Path="C:\KiSS\Trunk\Common.Logging.dll" />
///     <Reference Path="C:\KiSS\Trunk\HtmlAgilityPack.dll" />
///     <Reference Path="C:\KiSS\Trunk\Kiss.Database.dll" />
///     <Reference Path="C:\KiSS\Trunk\WPFLocalizeExtension.dll" />
///     <Reference Path="C:\KiSS\Trunk\XAMLMarkupExtensions.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell16;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell23;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell17;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell18;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell22;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell13;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell15;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell19;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell25;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell20;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell21;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell28;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell29;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAACAAAAAQAAAGhTeXN0ZW0uRHJhd" +
                        "2luZy5CaXRtYXAsIFN5c3RlbS5EcmF3aW5nLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhb" +
                        "CwgUHVibGljS2V5VG9rZW49YjAzZjVmN2YxMWQ1MGEzYVBBRFBBRBO0TqROBiAaAAAAADcAAACOAQAAM" +
                        "nMAcQBsAFEAdQBlAHIAeQAxAC4AUwBlAGwAZQBjAHQAUwB0AGEAdABlAG0AZQBuAHQAAAAAACZ4AHIAU" +
                        "ABpAGMAdAB1AHIAZQBCAG8AeAAxAC4ASQBtAGEAZwBlAB0XAAABmi5ERUNMQVJFIEByZXN1bHQgVEFCT" +
                        "EUoDQogIFNFTU8gQklULA0KICBQdkIgQklULA0KICBBbnpWZXJwZlRhZ2UgSU5ULA0KICBWZXJwZkJld" +
                        "HJhZyBJTlQsDQogIFJlaXNlQmV0cmFnIElOVA0KKTsNCg0KO1dJVEggS2FBcmJlaXRDdGUgDQpBUw0KK" +
                        "A0KICBTRUxFQ1QNCiAgICBJc1NlbW8gPSBDT05WRVJUKEJJVCwgDQogICAgICAgICAgICAgICBDQVNFI" +
                        "FdIRU4gS0FFLkthRWluc2F0enBsYXR6SUQgSU4gKFNFTEVDVCBFUDIuS2FFaW5zYXR6cGxhdHpJRA0KI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBGUk9NIEthRWluc" +
                        "2F0enBsYXR6MiAgRVAyIFdJVEggKFJFQURVTkNPTU1JVFRFRCkNCiAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBJTk5FUiBKT0lOIFhMT1ZDb2RlIExPViBXSVRII" +
                        "ChSRUFEVU5DT01NSVRURUQpIE9OIExPVi5MT1ZOYW1lID0gJ0thUHJvamVrdCcgDQogICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBMT1YuQ29kZSA9IEVQMi5Qcm9qZWt0Q29kZQ0KI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVSRSBVUFBFU" +
                        "ihMT1YuVGV4dCkgTElLRSAnJVNFTU8gVE9ETyUnKSANCiAgICAgICAgICAgICAgICAgVEhFTiAxIA0KI" +
                        "CAgICAgICAgICAgICAgICBFTFNFIDAgDQogICAgICAgICAgICAgICBFTkQpLA0KICAgIENvdW50QXJiZ" +
                        "Wl0c3JhcHBvcnRWZXJwZlZlcmxhZW5nZXJ1bmcgPSAoU0VMRUNUIENPVU5UKDEpDQogICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBGUk9NIGRiby5LYUFyYmVpdHNyYXBwb3J0I" +
                        "EtBUiBXSVRIIChSRUFEVU5DT01NSVRURUQpDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICBXSEVSRSBLQVIuQmFQZXJzb25JRCA9IEtBRTEuQmFQZXJzb25JRA0KICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgS0FSLkRhdHVtIEJFVFdFR" +
                        "U4gQU1NLkRhdHVtVm9uIEFORCBBTU0uRGF0dW1CaXMNCiAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgQU5EIE1PTlRIKEtBUi5EYXR1bSkgPSBDT05WRVJUKGludCwgQU1NL" +
                        "k1vbmF0KQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgW" +
                        "UVBUihLQVIuRGF0dW0pID0gQ09OVkVSVChpbnQsIEFNTS5KYWhyKQ0KICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgS0FSLkFNX0Fud0NvZGUgPSA5DQogICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBLQVIuUE1fQW53Q29kZSA9I" +
                        "DkpLA0KICAgIENvdW50QXJiZWl0c3JhcHBvcnRWZXJwZkFuZGVyZSA9IChTRUxFQ1QgQ09VTlQoMSkNC" +
                        "iAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPTSBkYm8uS2FBcmJlaXRzcmFwc" +
                        "G9ydCBLQVIgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICBXSEVSRSBLQVIuQmFQZXJzb25JRCA9IEtBRTEuQmFQZXJzb25JRA0KICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBLQVIuS2FFaW5zYXR6SUQgPSBLQUUxLkthR" +
                        "Wluc2F0eklEDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEtBUi5EY" +
                        "XR1bSBCRVRXRUVOIEFNTS5EYXR1bVZvbiBBTkQgQU1NLkRhdHVtQmlzDQogICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgQU5EIE1PTlRIKEtBUi5EYXR1bSkgPSBDT05WRVJUKGludCwgQ" +
                        "U1NLk1vbmF0KQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBZRUFSK" +
                        "EtBUi5EYXR1bSkgPSBDT05WRVJUKGludCwgQU1NLkphaHIpDQogICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgQU5EIEtBUi5BTV9BbndDb2RlID0gOQ0KICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgIEFORCBLQVIuUE1fQW53Q29kZSA9IDkpLA0KICAgIENvdW50QXJiZ" +
                        "Wl0c3JhcHBvcnRSZWlzZVZlcmxhZW5nZXJ1bmcgPSAoU0VMRUNUIENPVU5UKDEpDQogICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBGUk9NIGRiby5LYUFyYmVpdHNyYXBwb3J0I" +
                        "EtBUiBXSVRIIChSRUFEVU5DT01NSVRURUQpDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICBXSEVSRSBLQVIuQmFQZXJzb25JRCA9IEtBRTEuQmFQZXJzb25JRA0KICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgS0FSLkRhdHVtIEJFVFdFR" +
                        "U4gQU1NLkRhdHVtVm9uIEFORCBBTU0uRGF0dW1CaXMNCiAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgQU5EIE1PTlRIKEtBUi5EYXR1bSkgPSBDT05WRVJUKElOVCwgQU1NL" +
                        "k1vbmF0KQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgW" +
                        "UVBUihLQVIuRGF0dW0pID0gQ09OVkVSVChpbnQsIEFNTS5KYWhyKQ0KICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgKEtBUi5BTV9BbndDb2RlID4gMA0KICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIE9SIEtBUi5QTV9BbndDb2RlI" +
                        "D4gMCkpLA0KICAgIENvdW50QXJiZWl0c3JhcHBvcnRSZWlzZUFuZGVyZSA9IChTRUxFQ1QgQ09VTlQoM" +
                        "SkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPTSBkYm8uS2FBcmJlaXRzc" +
                        "mFwcG9ydCBLQVIgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKQ0KICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICBXSEVSRSBLQVIuQmFQZXJzb25JRCA9IEtBRTEuQmFQZXJzb25JRA0KICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBLQVIuS2FFaW5zYXR6SUQgPSBLQUUxL" +
                        "kthRWluc2F0eklEDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEtBU" +
                        "i5EYXR1bSBCRVRXRUVOIEFNTS5EYXR1bVZvbiBBTkQgQU1NLkRhdHVtQmlzDQogICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIE1PTlRIKEtBUi5EYXR1bSkgPSBDT05WRVJUKGlud" +
                        "CwgQU1NLk1vbmF0KQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBZR" +
                        "UFSKEtBUi5EYXR1bSkgPSBDT05WRVJUKGludCwgQU1NLkphaHIpDQogICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgQU5EIChLQVIuQU1fQW53Q29kZSA+IDANCiAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgIE9SIEtBUi5QTV9BbndDb2RlID4gMCkpLA0KICAgIEtBR" +
                        "S5BbndlaXN1bmdDb2RlLA0KICAgIFNwZXNlbiA9IENBU0UgV0hFTiBkYm8uZm5HZXRBZ2UoR2VidXJ0c" +
                        "0RhdHVtLCBHRVREQVRFKCkpID4gMjUgDQogICAgICAgICAgICAgICBUSEVOIENPTlZFUlQoSU5ULCBJU" +
                        "05VTEwoWExPLlZhbHVlMSwgMCkpDQogICAgICAgICAgICAgICBFTFNFIENPTlZFUlQoSU5ULCBJU05VT" +
                        "EwoWExPLlZhbHVlMiwgMCkpDQogICAgICAgICAgICAgRU5EDQogICAgDQogIEZST00gZGJvLkthRWluc" +
                        "2F0eiAgICAgICAgICBLQUUgIFdJVEggKFJFQURVTkNPTU1JVFRFRCkNCiAgICAgTEVGVCBKT0lOIGRib" +
                        "y5GYUxlaXN0dW5nIEZBTCAgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKSBPTiBGQUwuRmFMZWlzdHVuZ0lEI" +
                        "D0gS0FFLkZhTGVpc3R1bmdJRA0KICAgICBMRUZUIEpPSU4gZGJvLkthRWluc2F0eiAgS0FFMSBXSVRII" +
                        "ChSRUFEVU5DT01NSVRURUQpIE9OIEtBRTEuS2FFaW5zYXR6SUQgPSBLQUUuS2FFaW5zYXR6SUQgDQogI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgT" +
                        "k9UIChGQUwuRmFQcm96ZXNzY29kZSA9IDcwMyBBTkQgS0FFMS5BUFZadXNhdHpDb2RlID0gMSkNCiAgI" +
                        "CAgTEVGVCBKT0lOIGRiby5LYUFtbUJlc2NoIEFNTSAgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKSBPTiBBT" +
                        "U0uS2FBbW1CZXNjaElEID0gbnVsbA0KICAgICBMRUZUIEpPSU4gZGJvLnZ3UGVyc29uICAgUFJTICBXS" +
                        "VRIIChSRUFEVU5DT01NSVRURUQpIE9OIFBSUy5CYVBlcnNvbklEID0gS0FFMS5CYVBlcnNvbklEDQogI" +
                        "CAgIExFRlQgSk9JTiBkYm8uWExPVkNvZGUgICBYTE8gIFdJVEggKFJFQURVTkNPTU1JVFRFRCkgT04gT" +
                        "E9WTmFtZSA9ICdLYVBMWlNwZXNlbicgDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICBBTkQgQ09OVkVSVChpbnQsIFNob3J0VGV4dCkgPSBQUlMuV29ob" +
                        "nNpdHpQTFoNCiAgV0hFUkUgS0FFLkJhUGVyc29uSUQgPSBudWxsDQogICAgQU5EIEtBRS5LYUVpbnNhd" +
                        "HpJRCA9IG51bGwNCikNCg0KSU5TRVJUIElOVE8gQHJlc3VsdA0KU0VMRUNUIA0KICBTRU1PID0gSXNTZ" +
                        "W1vLA0KICBQdkIgID0gfklzU2VtbywgLS0gaXMgbm90IHNlbW8NCiAgQW56VmVycGZUYWdlID0gQ0FTR" +
                        "Q0KICAgICAgICAgICAgICAgICAgIFdIRU4gSXNTZW1vID0gMQ0KICAgICAgICAgICAgICAgICAgICAgV" +
                        "EhFTiAwIA0KICAgICAgICAgICAgICAgICAgIFdIRU4gQW53ZWlzdW5nQ29kZSA9IDMgLS0gVmVybMOkb" +
                        "mdlcnVuZw0KICAgICAgICAgICAgICAgICAgICAgVEhFTiBJU05VTEwoQ291bnRBcmJlaXRzcmFwcG9yd" +
                        "FZlcnBmVmVybGFlbmdlcnVuZywgMCkNCiAgICAgICAgICAgICAgICAgICBFTFNFIElTTlVMTChDb3Vud" +
                        "EFyYmVpdHNyYXBwb3J0VmVycGZBbmRlcmUsIDApDQogICAgICAgICAgICAgICAgIEVORCwNCiAgVmVyc" +
                        "GZCZXRyYWcgID0gQ0FTRSANCiAgICAgICAgICAgICAgICAgICBXSEVOIElzU2VtbyA9IDENCiAgICAgI" +
                        "CAgICAgICAgICAgICAgIFRIRU4gMCANCiAgICAgICAgICAgICAgICAgICBXSEVOIEFud2Vpc3VuZ0NvZ" +
                        "GUgPSAzIC0tIFZlcmzDpG5nZXJ1bmcNCiAgICAgICAgICAgICAgICAgICAgIFRIRU4gSVNOVUxMKENvd" +
                        "W50QXJiZWl0c3JhcHBvcnRWZXJwZlZlcmxhZW5nZXJ1bmcsIDApDQogICAgICAgICAgICAgICAgICAgR" +
                        "UxTRSBJU05VTEwoQ291bnRBcmJlaXRzcmFwcG9ydFZlcnBmQW5kZXJlLCAwKQ0KICAgICAgICAgICAgI" +
                        "CAgICBFTkQgKiAxNSwNCiAgUmVpc2VCZXRyYWcgID0gQ0FTRSANCiAgICAgICAgICAgICAgICAgICBXS" +
                        "EVOIElzU2VtbyA9IDENCiAgICAgICAgICAgICAgICAgICAgIFRIRU4gMCANCiAgICAgICAgICAgICAgI" +
                        "CAgICBXSEVOIChDQVNFIFdIRU4gQW53ZWlzdW5nQ29kZSA9IDMgLS0gVmVybMOkbmdlcnVuZyANCiAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgIFRIRU4gSVNOVUxMKENvdW50QXJiZWl0c3JhcHBvcnRSZWlzZ" +
                        "VZlcmxhZW5nZXJ1bmcsIDApDQogICAgICAgICAgICAgICAgICAgICAgICAgICBFTFNFIElTTlVMTChDb" +
                        "3VudEFyYmVpdHNyYXBwb3J0UmVpc2VBbmRlcmUsIDApDQogICAgICAgICAgICAgICAgICAgICAgICAgR" +
                        "U5EID4gMCkNCiAgICAgICAgICAgICAgICAgICAgIFRIRU4gU3Blc2VuDQogICAgICAgICAgICAgICAgI" +
                        "CAgRUxTRSAwDQogICAgICAgICAgICAgICAgIEVORA0KRlJPTSBLYUFyYmVpdEN0ZTsNCg0KLS0gT1VUU" +
                        "FVUDQpTRUxFQ1QgVE9QIDENCiAgU0VNTywNCiAgUHZCLA0KICBBbnpWZXJwZlRhZ2UsDQogIFZlcnBmQ" +
                        "mV0cmFnLA0KICBSZWlzZUJldHJhZywNCiAgVG90YWwgPSBWZXJwZkJldHJhZyArIFJlaXNlQmV0cmFnD" +
                        "QpGUk9NIEByZXN1bHQ7QAABAAAA/////wEAAAAAAAAADAIAAABRU3lzdGVtLkRyYXdpbmcsIFZlcnNpb" +
                        "249NC4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iMDNmNWY3ZjExZDUwYTNhB" +
                        "QEAAAAVU3lzdGVtLkRyYXdpbmcuQml0bWFwAQAAAAREYXRhBwICAAAACQMAAAAPAwAAAJqeAAACQk2an" +
                        "gAAAAAAADYAAAAoAAAAXQAAAG0AAAABACAAAAAAAAAAAADEDgAAxA4AAAAAAAAAAAAA/////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD//////////////////////////////////////wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD//////////////////////////////" +
                        "////////wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD//////////////" +
                        "////////////////////////wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD//////////////////////////////////////wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD//////////////////////////////////////wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD//////////////////////////////////////wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD//////////////////////////////" +
                        "////////wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD//////////////" +
                        "////////////////////////wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD//////////////////////////////////////wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD//////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////+/v7//j4+P/39/f/8/P" +
                        "z//Pz8//z8/P/8/Pz//T09P/39/f/+fn5//z8/P/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////+vr6//T09P/w8PD/8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/x8fH/9vb2//39/f/////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////n5+f/x8fH/8AA" +
                        "AD/AAAA/x8fH/9fX1//n5+f/7+/v//v7+//////////////////v7+//6+vr/9/f3//Ly8v/wAAAP8AA" +
                        "AD/AAAA/09PT/+/v7///////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////7+/v/8fH" +
                        "x//AAAA/wAAAP9fX1//v7+//////////////////////////////////////////////////////////" +
                        "////////9/f3/+Pj4//Hx8f/wAAAP8AAAD/X19f/+/v7////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///f39//wAAAP8AAAD/Pz8//9/f3////////////////////////////////////////////////////" +
                        "////////////////////////////////////////4+Pj/8PDw//AAAA/x8fH//Pz8///////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////9fX1//AAAA/w8PD/+vr6///////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////4+Pj/8PDw//AAAA/wAAAP8AA" +
                        "AD/n5+f/////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////19fX/8AAAD/Ly8v/9/f3////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////v7+//T09P/wAAAP8AA" +
                        "AD/b29v/4+Pj/8AAAD/AAAA/5+fn////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////X19f/wAAAP8vLy//7+/v/////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////6+vr/8PD" +
                        "w//AAAA/w8PD/+vr6////////////+fn5//AAAA/wAAAP+vr6///////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////+Pj4//AAAA/x8fH//v7+///////////////" +
                        "//////////////////////////////////////////////////////////////////////////////v7" +
                        "+//T09P/wAAAP8AAAD/T09P/+/v7///////////////////////f39//wAAAP8PDw//39/f/////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////8/Pz/8AAAD/AAAA/8/Pz////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////6+vr/8PDw//AAAA/w8PD/+vr6///////+/v7/+vr6///////////////////////z8/P/8AA" +
                        "AD/Ly8v/////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////y8vL/8AA" +
                        "AD/f39//////////////////////////////////////////////////////////////////////////" +
                        "//////////////v7+//b29v/wAAAP8AAAD/T09P/+/v7//v7+//r6+v/19fX/8vLy//7+/v/////////" +
                        "////////+/v7/8PDw//AAAA/4+Pj////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///n5+f/wAAAP8fHx///////////////////////////////////////////////////////////////" +
                        "////////////////////////7+/v/8fHx//AAAA/w8PD/+Pj4///////8/Pz/9/f3//Pz8//z8/P/9vb" +
                        "2//Pz8//+/v7/////////////////+fn5//AAAA/w8PD//v7+///////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////Hx8f/wAAAP+fn5///////////////////////////////////////////////" +
                        "//////////////////////////////v7+//b29v/wAAAP8AAAD/Pz8//9/f3/////////////////8fH" +
                        "x//f39//z8/P/8AAAD/AAAA/09PT///////////////////////Ly8v/wAAAP9/f3///////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////+vr6//AAAA/x8fH////////////////////////////////////" +
                        "////////////////////////////////////////8/Pz/8fHx//AAAA/w8PD/+Pj4///////////////" +
                        "//////////////Pz8//Dw8P/wAAAP8AAAD/AAAA/wAAAP9/f3//////////////////r6+v/wAAAP8PD" +
                        "w///////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////9fX1//AAAA/4+Pj////////////////////" +
                        "///////////////////////////////////////////////////f39//wAAAP8AAAD/Ly8v/8/Pz////" +
                        "///////////////////////////////////X19f/wAAAP8AAAD/AAAA/wAAAP8PDw//39/f/////////" +
                        "////////x8fH/8AAAD/r6+v/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////8PDw//AAAA/9/f3////" +
                        "////////////////////////////////////////////////////////8/Pz/8vLy//AAAA/wAAAP9/f" +
                        "3///////////////////////8/Pz/+/v7//z8/P/////////////////8/Pz/+fn5//Dw8P/wAAAP8AA" +
                        "AD/X19f/////////////////4+Pj/8AAAD/X19f/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////7+/v/8AA" +
                        "AD/Ly8v////////////////////////////////////////////////////////////f39//wAAAP8AA" +
                        "AD/Ly8v/8/Pz//v7+//X19f/29vb/8PDw//AAAA/wAAAP8AAAD/AAAA/6+vr////////////+/v7/8PD" +
                        "w//AAAA/wAAAP8AAAD/T09P/////////////////9/f3/8AAAD/Dw8P/////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////4+Pj/8AAAD/b29v/////////////////////////////////////////////////9/f3/8vL" +
                        "y//AAAA/wAAAP9vb2/////////////f39//X19f/09PT/8AAAD/AAAA/wAAAP8AAAD/AAAA/z8/P////" +
                        "////////29vb/8AAAD/AAAA/wAAAP8AAAD/f39///////////////////////8fHx//AAAA/9/f3////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////29vb/8AAAD/r6+v/////////////////////////////////////////" +
                        "///j4+P/w8PD/8AAAD/Hx8f/7+/v//////////////////v7+//f39//29vb/8/Pz//AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP/f39//z8/P/wAAAP8AAAD/AAAA/wAAAP8AAAD/f39///////////////////////9PT" +
                        "0//AAAA/7+/v////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////z8/P/8AAAD/v7+//////////////////////////" +
                        "////////9/f3/8/Pz//AAAA/wAAAP9vb2//7+/v////////////////////////////j4+P/09PT/8/P" +
                        "z//AAAA/wAAAP8AAAD/AAAA/wAAAP9/f3//Ly8v/wAAAP8AAAD/AAAA/wAAAP8AAAD/r6+v/////////" +
                        "/////////////9/f3//AAAA/4+Pj////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////z8/P/8AAAD/7+/v/////////" +
                        "///////////////////j4+P/w8PD/8AAAD/Dw8P/7+/v////////////////////////////////////" +
                        "///j4+P/09PT/9vb2//b29v/x8fH/8AAAD/AAAA/wAAAP9/f3//AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/v7+///////////////////////9/f3//AAAA/39/f////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////z8/P/8AA" +
                        "AD//////////////////////+/v7/9PT0//AAAA/wAAAP9PT0//7+/v////////////v7+//5+fn/9/f" +
                        "3//j4+P////////////////////////////f39//wAAAP8AAAD/AAAA/19fX/8fHx//AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/z8/P//////////////////////9/f3//AAAA/39/f////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////z8/P/8AAAD/////////////////r6+v/w8PD/8AAAD/Dw8P/6+vr/+/v7//X19f/39/f/8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/39/f//////////////////f39//AAAA/wAAAP8AAAD/AAAA/29vb/8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD///////////////////////////9/f3//AAAA/39/f////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////z8/P/8AAAD//////+/v7/9PT0//AAAA/wAAAP9PT0//7+/v///////f3" +
                        "9//b29v/39/f/8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP+/v7////////////8/Pz//AAAA/wAAAP8AA" +
                        "AD/AAAA/39/f/8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD///////////////////////////9/f" +
                        "3//AAAA/39/f////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////z8/P/8AAAD/r6+v/w8PD/8AAAD/Dw8P/4+Pj////" +
                        "//////////////v7+//X19f/39/f/8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8PDw//7+/v/+/v7/8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/39/f/8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8vLy//f39//9/f3////" +
                        "/////////////9/f3//AAAA/39/f////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////z8/P/8AAAD/AAAA/wAAAP8/P" +
                        "z//39/f///////////////////////f39//X19f/5+fn/8AAAD/AAAA/5+fn/8AAAD/AAAA/wAAAP8AA" +
                        "AD/Pz8///////8AAAD/AAAA/wAAAP8AAAD/b29v/8/Pz/8PDw//AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/7+/v/////////////////9/f3//AAAA/39/f////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////z8/P/8AA" +
                        "AD/Dw8P/4+Pj//////////////////////////////////f39//b29v/5+fn/9PT0//v7+///////8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/29vb/8/Pz//AAAA/wAAAP8fHx//Dw8P/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/+/v7/////////////////9/f3//AAAA/39/f////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////z8/P/8AAAD/z8/P/////////////////////////////////////////////////////////" +
                        "/////////////8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/Ly8v//////////////////////9/f3//AAAA/39/f////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////z8/P/8AAAD//////////////////////////////////////7+/v/+fn" +
                        "5//f39//z8/P/8vLy//AAAA/39/f/8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8PDw//z8/P//////////////////////9vb" +
                        "2//AAAA/39/f////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////z8/P/8AAAD///////////////////////////+/v" +
                        "7//Dw8P/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/39/f/8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/z8/P//f39///////////////" +
                        "///7+/v/29vb/8AAAD/AAAA/39/f////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////z8/P/8AAAD//////////////" +
                        "////////9/f3/8PDw//AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/39/f/8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8PDw//j4+P/////////" +
                        "//////////////Pz8//Hx8f/wAAAP8AAAD/AAAA/39/f////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////z8/P/8AA" +
                        "AD//////////////////////z8/P/8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/39/f/8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/z8/P//f3" +
                        "9///////////////////////39/f/8AAAD/AAAA/y8vL/9fX1//AAAA/39/f////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////z8/P/8AAAD/////////////////f39//wAAAP8AAAD/AAAA/19fX/8vLy//AAAA/wAAAP8AA" +
                        "AD/AAAA/z8/P/8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8PD" +
                        "w//j4+P///////////////////////Pz8//Ly8v/wAAAP8AAAD/f39///////9/f3//AAAA/39/f////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////z8/P/8AAAD////////////f39//Pz8//wAAAP8AAAD/AAAA/////////" +
                        "///7+/v/6+vr/9/f3//X19f/w8PD/8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/z8/P//f39///////////////////////39/f/8AAAD/AAAA/y8vL//Pz8////////////9/f" +
                        "3//AAAA/39/f////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////z8/P/8AAAD//////+/v7/8vLy//Pz8//19fX/8AA" +
                        "AD/AAAA//////////////////////+/v7//Dw8P/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8PDw//j4+P///////////////////////Pz8//Ly8v/wAAAP8AAAD/f39//////////" +
                        "/////////////9/f3//AAAA/39/f////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////z8/P/8AAAD//////+/v7/9/f" +
                        "3//X19f/y8vL/9fX1//AAAA/9/f3///////7+/v/29vb/8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/y8vL//Pz8///////////////////////39/f/8AAAD/AAAA/y8vL//Pz" +
                        "8////////////////////////////9/f3//AAAA/39/f////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////z8/P/8AA" +
                        "AD/////////////////n5+f/09PT/8/Pz//v7+////////Pz8//Ly8v/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8PDw//f39////////////////////////f39//Ly8v/wAAAP8AA" +
                        "AD/f39///////////////////////////////////////9/f3//AAAA/39/f////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////z8/P/8AAAD/////////////////7+/v/7+/v/+vr6///////4+Pj/8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP9fX1///////////////////////4+Pj/8PD" +
                        "w//AAAA/y8vL//Pz8////////////////////////////////////////////9/f3//AAAA/39/f////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////z8/P/8AAAD//////////////////////////////////////wAAAP9PT" +
                        "0//Pz8//wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/z8/P//Pz8/////////////f3" +
                        "9//Pz8//wAAAP8AAAD/b29v/+/v7/////////////////////////////////////////////////9/f" +
                        "3//AAAA/39/f////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////z8/P/8AAAD//////////////////////////////" +
                        "////////19fX/8fHx//r6+v/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8fHx//n5+f/////////" +
                        "////////4+Pj/8PDw//AAAA/x8fH/+/v7///////////////////////////////////////////////" +
                        "/////////////9/f3//AAAA/39/f////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////z8/P/8AAAD//////////////" +
                        "//////////////v7+//b29v/z8/P/+vr6//Hx8f/wAAAP8PDw//Hx8f/wAAAP8AAAD/AAAA/y8vL////" +
                        "//////////////f39//Pz8//wAAAP8AAAD/b29v/+/v7////////////////////////////////////" +
                        "/////////////////////////////9/f3//AAAA/39/f////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////z8/P/8AA" +
                        "AD//////////////////////8/Pz/8fHx//j4+P/39/f/8AAAD/AAAA/wAAAP8AAAD/AAAA/w8PD/8/P" +
                        "z//AAAA/z8/P////////////5+fn/8PDw//AAAA/x8fH/+/v7///////////////////////////////" +
                        "/////////////////////////////////////////////9/f3//AAAA/7+/v////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////z8/P/8AAAD/////////////////7+/v/w8PD/9/f3//z8/P/wAAAP8AAAD/AAAA/z8/P/9vb" +
                        "2//f39//+/v7//v7+//v7+//9/f3//v7+//T09P/wAAAP8AAAD/b29v/+/v7////////////////////" +
                        "/////////////////////////////////////////////////////////////9/f3//AAAA/7+/v////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////z8/P/8AAAD//////////////////////wAAAP9vb2//v7+//wAAAP8fH" +
                        "x//r6+v/////////////////////////////////6+vr/8PDw//AAAA/x8fH/+/v7///////////////" +
                        "/////////////////////////////////////////////////////////////////////////////9/f" +
                        "3//AAAA/7+/v////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////z8/P/8AAAD//////////////////////8/Pz/+Pj" +
                        "4//r6+v/4+Pj//////////////////////////////////v7+//T09P/wAAAP8AAAD/T09P/+/v7////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////9/f3//AAAA/7+/v////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////z8/P/8AAAD//////////////" +
                        "////////////////////////////////////////////////////////6+vr/8PDw//AAAA/w8PD/+vr" +
                        "6///////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////9/f3//AAAA/7+/v////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////z8/P/8AA" +
                        "AD////////////////////////////////////////////////////////////v7+//T09P/wAAAP8AA" +
                        "AD/T09P/+/v7////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////9/f3//AAAA/7+/v////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////z8/P/8AAAD//////////////////////////////////////////////////////7+/v/8fH" +
                        "x//AAAA/w8PD/+vr6///////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////9/f3//AAAA/7+/v////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////z8/P/8AAAD/f39//39/f/9/f3//f39//39/f/9/f3//f39//39/f/9/f" +
                        "3//X19f/wAAAP8AAAD/AAAA/29vb/9/f3//f39//39/f/9/f3//f39//39/f/9/f3//f39//39/f/9/f" +
                        "3//f39//39/f/9/f3//f39//39/f/9/f3//f39//39/f/9/f3//f39//39/f/9/f3//f39//39/f/8/P" +
                        "z//AAAA/7+/v////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////z8/P/8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/7+/v////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////8/Pz/+/v7//v7+//7+/v/+/v" +
                        "7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v" +
                        "7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v" +
                        "7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//+/v7////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////5+fn/9/f" +
                        "3//f39//39/f/9/f3//f39//39/f/9/f3//f39//39/f/9/f3//f39//39/f/9/f3//f39//39/f/9/f" +
                        "3//f39//39/f/9/f3//f39//39/f/9/f3//f39//39/f/9/f3//f39//39/f/9/f3//f39//39/f/9/f" +
                        "3//f39//39/f/9/f3//f39//39/f/9/f3//f39//39/f/9/f3//f39//9/f3////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////z8/P/8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/wAAAP8AAAD/AAAA/7+/v////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////z8/P/8AAAD/v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v" +
                        "7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v" +
                        "7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/+/v7//v7+//7+/v/9fX" +
                        "1//AAAA/7+/v////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////z8/P/8AAAD//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////9/f3//AAAA/7+/v////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////z8/P/8AAAD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////9/f3//AAAA/7+/v////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////z8/P/8AA" +
                        "AD/////////////////z8/P/4+Pj/9/f3//v7+////////////////////////v7+//j4+P/29vb/9vb" +
                        "2//n5+f/+/v7////////////////////////////8/Pz/9/f3//f39//39/f/+/v7///////////////" +
                        "////////9/f3/+Pj4//f39//6+vr//v7+////////////9/f3//AAAA/7+/v////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////z8/P/8AAAD//////+/v7/8vLy//AAAA/wAAAP8AAAD/AAAA/y8vL//Pz8///////5+fn/8PD" +
                        "w//AAAA/wAAAP8AAAD/AAAA/w8PD//Pz8//////////////////X19f/wAAAP8AAAD/AAAA/wAAAP8AA" +
                        "AD/X19f////////////j4+P/wAAAP8AAAD/AAAA/wAAAP8PDw//n5+f//////9/f3//AAAA/7+/v////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////z8/P/8AAAD//////z8/P/8AAAD/AAAA/y8vL/8/Pz//Ly8v/wAAAP8fH" +
                        "x//n5+f/wAAAP8AAAD/f39//+/v7/9/f3//AAAA/wAAAP8PDw//z8/P//////9fX1//AAAA/wAAAP8/P" +
                        "z//39/f/6+vr/8vLy//AAAA/4+Pj/+Pj4//AAAA/wAAAP8/Pz//j4+P/y8vL/8AAAD/AAAA/7+/v/9/f" +
                        "3//AAAA/7+/v////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////z8/P/8AAAD/v7+//x8fH/8PDw//AAAA/x8fH//v7" +
                        "+///////y8vL/8AAAD/AAAA/wAAAP+fn5///////4+Pj/8AAAD/AAAA/y8vL/8fHx//Pz8//8/Pz/8fH" +
                        "x//Dw8P/wAAAP8AAAD/Ly8v/+/v7//v7+//Hx8f/wAAAP8PDw//AAAA/39/f///////n5+f/wAAAP8AA" +
                        "AD/Dw8P/x8fH/9/f3//AAAA/7+/v////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////z8/P/8AAAD////////////Pz" +
                        "8//Dw8P/wAAAP9vb2///////09PT/8AAAD/AAAA/wAAAP+/v7///////w8PD/8AAAD/X19f/////////" +
                        "///7+/v/+/v7/////////////////8/Pz//AAAA/4+Pj///////Ly8v/wAAAP8AAAD/AAAA/8/Pz//v7" +
                        "+//Dw8P/wAAAP9fX1////////////9/f3//AAAA/7+/v////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////z8/P/8AA" +
                        "AD/////////////////z8/P/wAAAP8/Pz//n5+f/wAAAP8PDw//T09P/wAAAP8fHx//v7+//wAAAP8vL" +
                        "y////////////////////////////////////////////+/v7//AAAA/09PT/9/f3//AAAA/w8PD/9PT" +
                        "0//AAAA/y8vL/+/v7//AAAA/z8/P/////////////////9/f3//AAAA/7+/v////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////z8/P/8AAAD/////////////////39/f/wAAAP8/Pz//T09P/wAAAP9PT0//z8/P/wAAAP8PD" +
                        "w//r6+v/wAAAP8/Pz////////////////////////////////////////////+vr6//AAAA/z8/P/9PT" +
                        "0//AAAA/09PT//Pz8//AAAA/w8PD/+vr6//AAAA/19fX/////////////////9/f3//AAAA/7+/v////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////z8/P/8AAAD/////////////////X19f/wAAAP9fX1//n5+f/wAAAP8AA" +
                        "AD/AAAA/wAAAP9/f3///////w8PD/8AAAD/z8/P/////////////////////////////////8/Pz/8PD" +
                        "w//AAAA/29vb/+fn5//AAAA/wAAAP8AAAD/AAAA/19fX//f39//AAAA/w8PD//Pz8////////////9/f" +
                        "3//AAAA/7+/v////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////z8/P/8AAAD//////09PT/8PDw//AAAA/09PT//v7" +
                        "+///////4+Pj/9/f3//f39//39/f//v7+///////4+Pj/8AAAD/AAAA/wAAAP8vLy//39/f//////9/f" +
                        "3//Pz8//w8PD/8AAAD/Dw8P/+/v7///////j4+P/39/f/9/f3//f39//9/f3///////b29v/wAAAP8PD" +
                        "w//Pz8//5+fn/9/f3//AAAA/5+fn////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////z8/P/8AAAD//////5+fn/8AA" +
                        "AD/T09P//////////////////////////////////////////////////////+vr6//Pz8//wAAAP9/f" +
                        "3/////////////Pz8//AAAA/wAAAP9fX1//39/f/////////////////////////////////////////" +
                        "////////5+fn/8PDw//AAAA/8/Pz/9/f3//AAAA/39/f////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////w8PD/8AA" +
                        "AD//////6+vr/8AAAD/f39//////////////////////////////////////////////////////////" +
                        "///f39//wAAAP+/v7//////////////////Pz8//wAAAP/f39///////////////////////////////" +
                        "/////////////////////////////8/Pz//Dw8P//////9/f3//AAAA/39/f////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////wAAAP8/Pz///////z8/P/8AAAD/n5+f/////////////////////////////////////////" +
                        "///////////////////f39//wAAAP+/v7//////////////////Ly8v/wAAAP+/v7///////////////" +
                        "/////////////////////////////////////////////8/Pz//AAAA/7+/v/+Pj4//AAAA/39/f////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////wAAAP8/Pz//X19f/wAAAP8vLy///////////////////////////////" +
                        "///////////////////////////////////j4+P/wAAAP8/Pz////////////+/v7//AAAA/w8PD////" +
                        "/////////////////////////////////////////////////////////////+vr6//AAAA/w8PD/+Pj" +
                        "4//AAAA/29vb////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////z8/P/wAAAP8PDw//AAAA/y8vL//v7+///////////////" +
                        "///////////////////////////////////////////////////7+/v/y8vL/8AAAD/X19f/+/v7/8PD" +
                        "w//AAAA/5+fn////////////////////////////////////////////////////////////////////" +
                        "///b29v/wAAAP8AAAD/AAAA/z8/P////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////v7+//wAAAP8AAAD/Ly8v/+/v7////" +
                        "////////////////////////////////////////////////////////////////////////9/f3/8PD" +
                        "w//AAAA/x8fH/8AAAD/X19f/////////////////////////////////////////////////////////" +
                        "////////////////////////39/f/8AAAD/AAAA/y8vL////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////f39//wAAAP9PT" +
                        "0//7+/v/////////////////////////////////////////////////////////////////////////" +
                        "//////////////Pz8//Dw8P/wAAAP9fX1///////////////////////////////////////////////" +
                        "/////////////////////////////////////////////+vr6//Dw8P/wAAAP///////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///X19f/6+vr////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////z8/P/09PT////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////39/f/z8/P//Pz" +
                        "8///////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////CwAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
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
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPictureBox1,
                        this.xrPanel1});
            this.Detail.Dpi = 254F;
            this.Detail.Height = 275;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBorders = false;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Dpi = 254F;
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.Location = new System.Drawing.Point(0, 101);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.Size = new System.Drawing.Size(148, 167);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xrPanel1
            // 
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel2,
                        this.xrLabel1,
                        this.xrTable1});
            this.xrPanel1.Dpi = 254F;
            this.xrPanel1.Location = new System.Drawing.Point(148, 0);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.ParentStyleUsing.UseBorders = false;
            this.xrPanel1.Size = new System.Drawing.Size(1736, 275);
            // 
            // xrLabel2
            // 
            this.xrLabel2.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.Location = new System.Drawing.Point(1122, 26);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(592, 106);
            this.xrLabel2.Text = "Kostenvergütung der Arbeitslosenkasse an die RAV-Kundin";
            // 
            // xrLabel1
            // 
            this.xrLabel1.BorderColor = System.Drawing.Color.Transparent;
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel1.Location = new System.Drawing.Point(1122, 169);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(592, 84);
            this.xrLabel1.Text = "* Gemäss Weisung  \"Ersatz der Auslagen für die Teilnahme an Arbeitsmarktlichen Ma" +
                "ssnahmen\".";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Dpi = 254F;
            this.xrTable1.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTable1.Location = new System.Drawing.Point(0, 21);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.ParentStyleUsing.UseBorders = false;
            this.xrTable1.ParentStyleUsing.UseFont = false;
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow6,
                        this.xrTableRow5,
                        this.xrTableRow7,
                        this.xrTableRow3,
                        this.xrTableRow2});
            this.xrTable1.Size = new System.Drawing.Size(1080, 252);
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell16,
                        this.xrTableCell23,
                        this.xrTableCell17,
                        this.xrTableCell18});
            this.xrTableRow6.Dpi = 254F;
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Size = new System.Drawing.Size(1080, 51);
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell22,
                        this.xrTableCell13,
                        this.xrTableCell14,
                        this.xrTableCell15});
            this.xrTableRow5.Dpi = 254F;
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Size = new System.Drawing.Size(1080, 51);
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell19,
                        this.xrTableCell25,
                        this.xrTableCell20,
                        this.xrTableCell21});
            this.xrTableRow7.Dpi = 254F;
            this.xrTableRow7.Name = "xrTableRow7";
            this.xrTableRow7.Size = new System.Drawing.Size(1080, 50);
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell7,
                        this.xrTableCell28,
                        this.xrTableCell8,
                        this.xrTableCell9});
            this.xrTableRow3.Dpi = 254F;
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Size = new System.Drawing.Size(1080, 51);
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell4,
                        this.xrTableCell29,
                        this.xrTableCell5,
                        this.xrTableCell6});
            this.xrTableRow2.Dpi = 254F;
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Size = new System.Drawing.Size(1080, 49);
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Dpi = 254F;
            this.xrTableCell16.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell16.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell16.ParentStyleUsing.UseBackColor = false;
            this.xrTableCell16.ParentStyleUsing.UseFont = false;
            this.xrTableCell16.Size = new System.Drawing.Size(419, 51);
            this.xrTableCell16.Text = "   Auslagen*";
            this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Dpi = 254F;
            this.xrTableCell23.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell23.Location = new System.Drawing.Point(419, 0);
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell23.ParentStyleUsing.UseFont = false;
            this.xrTableCell23.Size = new System.Drawing.Size(220, 51);
            this.xrTableCell23.Text = "Anz. Tage";
            this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Dpi = 254F;
            this.xrTableCell17.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell17.Location = new System.Drawing.Point(639, 0);
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell17.ParentStyleUsing.UseBackColor = false;
            this.xrTableCell17.ParentStyleUsing.UseFont = false;
            this.xrTableCell17.Size = new System.Drawing.Size(220, 51);
            this.xrTableCell17.Text = "CHF / Tag";
            this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Dpi = 254F;
            this.xrTableCell18.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell18.Location = new System.Drawing.Point(859, 0);
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell18.ParentStyleUsing.UseBackColor = false;
            this.xrTableCell18.ParentStyleUsing.UseFont = false;
            this.xrTableCell18.Size = new System.Drawing.Size(221, 51);
            this.xrTableCell18.Text = "Summe";
            this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Dpi = 254F;
            this.xrTableCell22.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell22.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell22.ParentStyleUsing.UseFont = false;
            this.xrTableCell22.Size = new System.Drawing.Size(419, 51);
            this.xrTableCell22.Text = "   Verpflegungskosten";
            this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AnzVerpfTage", "")});
            this.xrTableCell13.Dpi = 254F;
            this.xrTableCell13.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell13.Location = new System.Drawing.Point(419, 0);
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell13.ParentStyleUsing.UseFont = false;
            this.xrTableCell13.Size = new System.Drawing.Size(220, 51);
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Dpi = 254F;
            this.xrTableCell14.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell14.Location = new System.Drawing.Point(639, 0);
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell14.ParentStyleUsing.UseFont = false;
            this.xrTableCell14.Size = new System.Drawing.Size(220, 51);
            this.xrTableCell14.Text = "15";
            this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VerpfBetrag", "")});
            this.xrTableCell15.Dpi = 254F;
            this.xrTableCell15.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell15.Location = new System.Drawing.Point(859, 0);
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell15.ParentStyleUsing.UseFont = false;
            this.xrTableCell15.Size = new System.Drawing.Size(221, 51);
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Dpi = 254F;
            this.xrTableCell19.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell19.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell19.ParentStyleUsing.UseFont = false;
            this.xrTableCell19.Size = new System.Drawing.Size(419, 50);
            this.xrTableCell19.Text = "   Effektive Reisekosten";
            this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Dpi = 254F;
            this.xrTableCell25.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell25.Location = new System.Drawing.Point(419, 0);
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell25.ParentStyleUsing.UseFont = false;
            this.xrTableCell25.Size = new System.Drawing.Size(220, 50);
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Dpi = 254F;
            this.xrTableCell20.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell20.Location = new System.Drawing.Point(639, 0);
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell20.ParentStyleUsing.UseFont = false;
            this.xrTableCell20.Size = new System.Drawing.Size(220, 50);
            this.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ReiseBetrag", "")});
            this.xrTableCell21.Dpi = 254F;
            this.xrTableCell21.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell21.Location = new System.Drawing.Point(859, 0);
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell21.ParentStyleUsing.UseFont = false;
            this.xrTableCell21.Size = new System.Drawing.Size(221, 50);
            this.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Dpi = 254F;
            this.xrTableCell7.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell7.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell7.ParentStyleUsing.UseFont = false;
            this.xrTableCell7.Size = new System.Drawing.Size(419, 51);
            this.xrTableCell7.Text = "   Anderes";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Dpi = 254F;
            this.xrTableCell28.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell28.Location = new System.Drawing.Point(419, 0);
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell28.ParentStyleUsing.UseFont = false;
            this.xrTableCell28.Size = new System.Drawing.Size(220, 51);
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Dpi = 254F;
            this.xrTableCell8.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell8.Location = new System.Drawing.Point(639, 0);
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell8.ParentStyleUsing.UseFont = false;
            this.xrTableCell8.Size = new System.Drawing.Size(220, 51);
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Dpi = 254F;
            this.xrTableCell9.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell9.Location = new System.Drawing.Point(859, 0);
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell9.ParentStyleUsing.UseFont = false;
            this.xrTableCell9.Size = new System.Drawing.Size(221, 51);
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.BackColor = System.Drawing.Color.White;
            this.xrTableCell4.Dpi = 254F;
            this.xrTableCell4.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell4.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell4.ParentStyleUsing.UseBackColor = false;
            this.xrTableCell4.ParentStyleUsing.UseFont = false;
            this.xrTableCell4.Size = new System.Drawing.Size(419, 49);
            this.xrTableCell4.Text = "   Total";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Dpi = 254F;
            this.xrTableCell29.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell29.Location = new System.Drawing.Point(419, 0);
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell29.ParentStyleUsing.UseFont = false;
            this.xrTableCell29.Size = new System.Drawing.Size(220, 49);
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.BackColor = System.Drawing.Color.White;
            this.xrTableCell5.Dpi = 254F;
            this.xrTableCell5.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell5.Location = new System.Drawing.Point(639, 0);
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell5.ParentStyleUsing.UseBackColor = false;
            this.xrTableCell5.ParentStyleUsing.UseFont = false;
            this.xrTableCell5.Size = new System.Drawing.Size(220, 49);
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.BackColor = System.Drawing.Color.White;
            this.xrTableCell6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Total", "")});
            this.xrTableCell6.Dpi = 254F;
            this.xrTableCell6.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.xrTableCell6.Location = new System.Drawing.Point(859, 0);
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell6.ParentStyleUsing.UseBackColor = false;
            this.xrTableCell6.ParentStyleUsing.UseFont = false;
            this.xrTableCell6.Size = new System.Drawing.Size(221, 49);
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(254, 148, 254, 254);
            this.Name = "Report";
            this.PageHeight = 2101;
            this.PageWidth = 2969;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' ,  null ,  N'DECLARE @result TABLE(
  SEMO BIT,
  PvB BIT,
  AnzVerpfTage INT,
  VerpfBetrag INT,
  ReiseBetrag INT
);

;WITH KaArbeitCte 
AS
(
  SELECT
    IsSemo = CONVERT(BIT, 
               CASE WHEN KAE.KaEinsatzplatzID IN (SELECT EP2.KaEinsatzplatzID
                                                  FROM KaEinsatzplatz2  EP2 WITH (READUNCOMMITTED)
                                                    INNER JOIN XLOVCode LOV WITH (READUNCOMMITTED) ON LOV.LOVName = ''KaProjekt'' 
                                                                                                  AND LOV.Code = EP2.ProjektCode
                                                  WHERE UPPER(LOV.Text) LIKE ''%SEMO TODO%'') 
                 THEN 1 
                 ELSE 0 
               END),
    CountArbeitsrapportVerpfVerlaengerung = (SELECT COUNT(1)
                                             FROM dbo.KaArbeitsrapport KAR WITH (READUNCOMMITTED)
                                             WHERE KAR.BaPersonID = KAE1.BaPersonID
                                               AND KAR.Datum BETWEEN AMM.DatumVon AND AMM.DatumBis
                                               AND MONTH(KAR.Datum) = CONVERT(int, AMM.Monat)
                                               AND YEAR(KAR.Datum) = CONVERT(int, AMM.Jahr)
                                               AND KAR.AM_AnwCode = 9
                                               AND KAR.PM_AnwCode = 9),
    CountArbeitsrapportVerpfAndere = (SELECT COUNT(1)
                                      FROM dbo.KaArbeitsrapport KAR WITH (READUNCOMMITTED)
                                      WHERE KAR.BaPersonID = KAE1.BaPersonID
                                        AND KAR.KaEinsatzID = KAE1.KaEinsatzID
                                        AND KAR.Datum BETWEEN AMM.DatumVon AND AMM.DatumBis
                                        AND MONTH(KAR.Datum) = CONVERT(int, AMM.Monat)
                                        AND YEAR(KAR.Datum) = CONVERT(int, AMM.Jahr)
                                        AND KAR.AM_AnwCode = 9
                                        AND KAR.PM_AnwCode = 9),
    CountArbeitsrapportReiseVerlaengerung = (SELECT COUNT(1)
                                             FROM dbo.KaArbeitsrapport KAR WITH (READUNCOMMITTED)
                                             WHERE KAR.BaPersonID = KAE1.BaPersonID
                                               AND KAR.Datum BETWEEN AMM.DatumVon AND AMM.DatumBis
                                               AND MONTH(KAR.Datum) = CONVERT(INT, AMM.Monat)
                                               AND YEAR(KAR.Datum) = CONVERT(int, AMM.Jahr)
                                               AND (KAR.AM_AnwCode > 0
                                                 OR KAR.PM_AnwCode > 0)),
    CountArbeitsrapportReiseAndere = (SELECT COUNT(1)
                                      FROM dbo.KaArbeitsrapport KAR WITH (READUNCOMMITTED)
                                      WHERE KAR.BaPersonID = KAE1.BaPersonID
                                        AND KAR.KaEinsatzID = KAE1.KaEinsatzID
                                        AND KAR.Datum BETWEEN AMM.DatumVon AND AMM.DatumBis
                                        AND MONTH(KAR.Datum) = CONVERT(int, AMM.Monat)
                                        AND YEAR(KAR.Datum) = CONVERT(int, AMM.Jahr)
                                        AND (KAR.AM_AnwCode > 0
                                          OR KAR.PM_AnwCode > 0)),
    KAE.AnweisungCode,
    Spesen = CASE WHEN dbo.fnGetAge(GeburtsDatum, GETDATE()) > 25 
               THEN CONVERT(INT, ISNULL(XLO.Value1, 0))
               ELSE CONVERT(INT, ISNULL(XLO.Value2, 0))
             END
    
  FROM dbo.KaEinsatz          KAE  WITH (READUNCOMMITTED)
     LEFT JOIN dbo.FaLeistung FAL  WITH (READUNCOMMITTED) ON FAL.FaLeistungID = KAE.FaLeistungID
     LEFT JOIN dbo.KaEinsatz  KAE1 WITH (READUNCOMMITTED) ON KAE1.KaEinsatzID = KAE.KaEinsatzID 
                                                         AND NOT (FAL.FaProzesscode = 703 AND KAE1.APVZusatzCode = 1)
     LEFT JOIN dbo.KaAmmBesch AMM  WITH (READUNCOMMITTED) ON AMM.KaAmmBeschID = {KaAmmBeschID}
     LEFT JOIN dbo.vwPerson   PRS  WITH (READUNCOMMITTED) ON PRS.BaPersonID = KAE1.BaPersonID
     LEFT JOIN dbo.XLOVCode   XLO  WITH (READUNCOMMITTED) ON LOVName = ''KaPLZSpesen'' 
                                                         AND CONVERT(int, ShortText) = PRS.WohnsitzPLZ
  WHERE KAE.BaPersonID = {BaPersonID}
    AND KAE.KaEinsatzID = {KaEinsatzID}
)

INSERT INTO @result
SELECT 
  SEMO = IsSemo,
  PvB  = ~IsSemo, -- is not semo
  AnzVerpfTage = CASE
                   WHEN IsSemo = 1
                     THEN 0 
                   WHEN AnweisungCode = 3 -- Verlängerung
                     THEN ISNULL(CountArbeitsrapportVerpfVerlaengerung, 0)
                   ELSE ISNULL(CountArbeitsrapportVerpfAndere, 0)
                 END,
  VerpfBetrag  = CASE 
                   WHEN IsSemo = 1
                     THEN 0 
                   WHEN AnweisungCode = 3 -- Verlängerung
                     THEN ISNULL(CountArbeitsrapportVerpfVerlaengerung, 0)
                   ELSE ISNULL(CountArbeitsrapportVerpfAndere, 0)
                 END * 15,
  ReiseBetrag  = CASE 
                   WHEN IsSemo = 1
                     THEN 0 
                   WHEN (CASE WHEN AnweisungCode = 3 -- Verlängerung 
                           THEN ISNULL(CountArbeitsrapportReiseVerlaengerung, 0)
                           ELSE ISNULL(CountArbeitsrapportReiseAndere, 0)
                         END > 0)
                     THEN Spesen
                   ELSE 0
                 END
FROM KaArbeitCte;

-- OUTPUT
SELECT TOP 1
  SEMO,
  PvB,
  AnzVerpfTage,
  VerpfBetrag,
  ReiseBetrag,
  Total = VerpfBetrag + ReiseBetrag
FROM @result;' ,  null ,  N'KAAAMBescheinigung' , 1,  0 );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'KAAMMBescheinigung_AnAbwesenheiten' ,  N'KA - AMM Bescheinigung, An- und Abwesenheiten' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\KiSS\Trunk\KiSS4.DB.dll" />
///     <Reference Path="C:\KiSS\Trunk\Kiss.Interfaces.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\KiSS\Trunk\FluentValidation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\KiSS\Trunk\log4net.dll" />
///     <Reference Path="C:\KiSS\Trunk\SharpLibrary.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\KiSS\Trunk\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="C:\KiSS\Trunk\Microsoft.Practices.Unity.dll" />
///     <Reference Path="C:\KiSS\Trunk\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="C:\KiSS\Trunk\Ionic.Zip.dll" />
///     <Reference Path="C:\KiSS\Trunk\Kiss.BL.dll" />
///     <Reference Path="C:\KiSS\Trunk\Kiss.Model.dll" />
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
///     <Reference Path="C:\KiSS\Trunk\KiSS.Common.dll" />
///     <Reference Path="C:\KiSS\Trunk\Autofac.dll" />
///     <Reference Path="C:\KiSS\Trunk\Common.Logging.dll" />
///     <Reference Path="C:\KiSS\Trunk\HtmlAgilityPack.dll" />
///     <Reference Path="C:\KiSS\Trunk\Kiss.Database.dll" />
///     <Reference Path="C:\KiSS\Trunk\WPFLocalizeExtension.dll" />
///     <Reference Path="C:\KiSS\Trunk\XAMLMarkupExtensions.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel40;
        private DevExpress.XtraReports.UI.XRLabel xrLabel39;
        private DevExpress.XtraReports.UI.XRLabel xrLabel38;
        private DevExpress.XtraReports.UI.XRLabel xrLabel37;
        private DevExpress.XtraReports.UI.XRLabel xrLabel36;
        private DevExpress.XtraReports.UI.XRLabel xrLabel35;
        private DevExpress.XtraReports.UI.XRLabel xrLabel34;
        private DevExpress.XtraReports.UI.XRLabel xrLabel33;
        private DevExpress.XtraReports.UI.XRLabel xrLabel32;
        private DevExpress.XtraReports.UI.XRLabel xrLabel31;
        private DevExpress.XtraReports.UI.XRLabel xrLabel30;
        private DevExpress.XtraReports.UI.XRLabel xrLabel29;
        private DevExpress.XtraReports.UI.XRLabel xrLabel28;
        private DevExpress.XtraReports.UI.XRRichText xrRichText3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRRichText xrRichText2;
        private DevExpress.XtraReports.UI.XRLabel lblBemerkungen;
        private DevExpress.XtraReports.UI.XRLabel txtBemerkungen;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRRichText xrRichText1;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAAEAAAAAQAAAIwBRGV2RXhwcmVzc" +
                        "y5YdHJhUmVwb3J0cy5VSS5TZXJpYWxpemFibGVTdHJpbmcsIERldkV4cHJlc3MuWHRyYVJlcG9ydHMud" +
                        "jYuMiwgVmVyc2lvbj02LjIuNi4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPTc5ODY4Y" +
                        "jgxNDdiNWVhZTRQE7ROpIBtm7ZDDrpRgl1XdQAAAAA3AAAAYgAAAI0AAAAUAgAAMnMAcQBsAFEAdQBlA" +
                        "HIAeQAxAC4AUwBlAGwAZQBjAHQAUwB0AGEAdABlAG0AZQBuAHQAAAAAACZ4AHIAUgBpAGMAaABUAGUAe" +
                        "AB0ADEALgBSAHQAZgBUAGUAeAB0APIBAAAmeAByAFIAaQBjAGgAVABlAHgAdAAyAC4AUgB0AGYAVABlA" +
                        "HgAdAB0BAAAJngAcgBSAGkAYwBoAFQAZQB4AHQAMwAuAFIAdABmAFQAZQB4AHQAIgYAAAHvA1NFTEVDV" +
                        "CBUT1AgMQ0KICAgR3J1bmQgPQ0KICAgIENBU0UgV0hFTiAoQVVTLkF1c3RyaXR0RGF0dW0gSVMgTk9UI" +
                        "E5VTEwgQU5EIE1PTlRIKEFVUy5BdXN0cml0dERhdHVtKSA9IEFNTS5Nb25hdCkgVEhFTg0KICAgICAgQ" +
                        "VVTLkF1c3RyaXR0Q29kZVRleHRMYW5nDQogICBFTFNFDQogICAgICcnDQogICBFTkQNCkZST00gZGJvL" +
                        "kthQW1tQmVzY2ggICAgICAgICAgQU1NIFdJVEggKFJFQURVTkNPTU1JVFRFRCkNCiAgTEVGVCBKT0lOI" +
                        "GRiby5LYUVpbnNhdHogICAgRUlOIFdJVEggKFJFQURVTkNPTU1JVFRFRCkgT04gRUlOLkthRWluc2F0e" +
                        "klEID0gQU1NLkthRWluc2F0eklEDQogIE9VVEVSIEFQUExZIGRiby5mbkthR2V0QXVzdHJpdHREYXR1b" +
                        "UNvZGUoRUlOLkZhTGVpc3R1bmdJRCwgRUlOLkthRWluc2F0eklEKSBBVVMNCldIRVJFIEFNTS5CYVBlc" +
                        "nNvbklEID0gbnVsbA0KQU5EIEFNTS5LYUVpbnNhdHpJRCA9IG51bGwNCkFORCBBTU0uS2FBbW1CZXNja" +
                        "ElEID0gbnVsbEAAAQAAAP////8BAAAAAAAAAAwCAAAAG0RldkV4cHJlc3MuWHRyYVJlcG9ydHMudjYuM" +
                        "gUBAAAALERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuU2VyaWFsaXphYmxlU3RyaW5nAQAAAAVWYWx1Z" +
                        "QECAAAABgMAAACGBHtccnRmMVxmYmlkaXNcYW5zaVxhbnNpY3BnMTI1MlxkZWZmMHtcZm9udHRibHtcZ" +
                        "jBcZnN3aXNzXGZwcnEyXGZjaGFyc2V0MCBBcmlhbDt9e1xmMVxmbmlsIFRpbWVzIE5ldyBSb21hbjt9f" +
                        "Q0Ke1xjb2xvcnRibCA7XHJlZDBcZ3JlZW4wXGJsdWUyNTU7fQ0KXHZpZXdraW5kNFx1YzFccGFyZFxsd" +
                        "HJwYXJcbGFuZzEwMjRcYlxmMFxmczE2IEVudHNjaHVsZGlndGUgQWJzZW56ZW46XGIwICBWb3JzdGVsb" +
                        "HVuZ3NnZXNwclwnZTRjaCwgUkFWLVRlcm1pbiwgQXJ6dC0gLyBaYWhuYXJ6dCwgV29obnVuZ3N3ZWNoc" +
                        "2VsXGNmMSAsXGNmMCAgZWlnZW5lXGNmMSAgXGNmMCBIZWlyYXQsIEdlYnVydCBlaWdlbmVyIEtpbmRlc" +
                        "iwgVG9kZXNmYWxsIG9kZXIgRXJrcmFua3VuZyBlaW5lciAvIGVpbmVzIG5haGVuIEZhbWlsaWVuYW5nZ" +
                        "WhcJ2Y2cmlnZW4sIEJlaFwnZjZyZGVudm9yc3ByYWNoZW4gdS5cJ2U0LiAoWnV0cmVmZmVuZGVzIHVud" +
                        "GVyIEJlbWVya3VuZ2VuIGFuZ2ViZW4pLlxsYW5nMjA1NVxmMVxmczI0XHBhcg0KfQ0KC0AAAQAAAP///" +
                        "/8BAAAAAAAAAAwCAAAAG0RldkV4cHJlc3MuWHRyYVJlcG9ydHMudjYuMgUBAAAALERldkV4cHJlc3MuW" +
                        "HRyYVJlcG9ydHMuVUkuU2VyaWFsaXphYmxlU3RyaW5nAQAAAAVWYWx1ZQECAAAABgMAAACyAntccnRmM" +
                        "VxhbnNpXGFuc2ljcGcxMjUyXGRlZmYwe1xmb250dGJse1xmMFxmc3dpc3NcZnBycTJcZmNoYXJzZXQwI" +
                        "EFyaWFsO317XGYxXGZuaWwgVGltZXMgTmV3IFJvbWFuO319DQpcdmlld2tpbmQ0XHVjMVxwYXJkXHR4M" +
                        "TAwNjVcbGFuZzEwMjRcZjBcZnMxNiBCaXR0ZSBBbndlc2VuaGVpdCBkZXIgUkFWLUt1bmRpbiBtaXQgX" +
                        "Cc4NFxiIFhcYjBcbGRibHF1b3RlICBrZW5uemVpY2huZW4uIEZcJ2ZjciBBYnNlbnplbiBzaW5kIGRpZ" +
                        "SBuYWNoc3RlaGVuZGVuIENvZGVzIHp1IHZlcndlbmRlbjpcbGFuZzIwNTVcZjFcZnMyNFxwYXINCn0NC" +
                        "gtAAAEAAAD/////AQAAAAAAAAAMAgAAABtEZXZFeHByZXNzLlh0cmFSZXBvcnRzLnY2LjIFAQAAACxEZ" +
                        "XZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlNlcmlhbGl6YWJsZVN0cmluZwEAAAAFVmFsdWUBAgAAAAYDA" +
                        "AAAtQF7XHJ0ZjFcYW5zaVxhbnNpY3BnMTI1MlxkZWZmMHtcZm9udHRibHtcZjBcZm5pbFxmY2hhcnNld" +
                        "DAgQXJpYWw7fXtcZjFcZm5pbCBUaW1lcyBOZXcgUm9tYW47fX0NClx2aWV3a2luZDRcdWMxXHBhcmRcb" +
                        "GFuZzEwMjRcYlxmczE2IEFuLSB1bmQgQWJ3ZXNlbmhlaXRlblxsYW5nMjA1NVxiMFxmMVxmczI0XHBhc" +
                        "g0KfQ0KCw==";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrRichText3 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrRichText2 = new DevExpress.XtraReports.UI.XRRichText();
            this.lblBemerkungen = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBemerkungen = new DevExpress.XtraReports.UI.XRLabel();
            this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPanel1});
            this.Detail.Dpi = 254F;
            this.Detail.Height = 490;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBorders = false;
            // 
            // xrPanel1
            // 
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel40,
                        this.xrLabel39,
                        this.xrLabel38,
                        this.xrLabel37,
                        this.xrLabel36,
                        this.xrLabel35,
                        this.xrLabel34,
                        this.xrLabel33,
                        this.xrLabel32,
                        this.xrLabel31,
                        this.xrLabel30,
                        this.xrLabel29,
                        this.xrLabel28,
                        this.xrRichText3,
                        this.xrLabel15,
                        this.xrLabel14,
                        this.xrLabel12,
                        this.xrLabel11,
                        this.xrLabel10,
                        this.xrLabel9,
                        this.xrLabel8,
                        this.xrLabel7,
                        this.xrLabel6,
                        this.xrLabel5,
                        this.xrLabel4,
                        this.xrLabel3,
                        this.xrLabel2,
                        this.xrLabel1,
                        this.xrRichText2,
                        this.lblBemerkungen,
                        this.txtBemerkungen,
                        this.xrRichText1});
            this.xrPanel1.Dpi = 254F;
            this.xrPanel1.Location = new System.Drawing.Point(0, 0);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.ParentStyleUsing.UseBorders = false;
            this.xrPanel1.Size = new System.Drawing.Size(1736, 490);
            // 
            // xrLabel40
            // 
            this.xrLabel40.Dpi = 254F;
            this.xrLabel40.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel40.Location = new System.Drawing.Point(635, 204);
            this.xrLabel40.Name = "xrLabel40";
            this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel40.ParentStyleUsing.UseBackColor = false;
            this.xrLabel40.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel40.ParentStyleUsing.UseBorders = false;
            this.xrLabel40.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel40.ParentStyleUsing.UseFont = false;
            this.xrLabel40.Size = new System.Drawing.Size(338, 42);
            this.xrLabel40.Text = "Entschuldigte Absenzen";
            this.xrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel39
            // 
            this.xrLabel39.Dpi = 254F;
            this.xrLabel39.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel39.Location = new System.Drawing.Point(106, 161);
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel39.ParentStyleUsing.UseBackColor = false;
            this.xrLabel39.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel39.ParentStyleUsing.UseBorders = false;
            this.xrLabel39.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel39.ParentStyleUsing.UseFont = false;
            this.xrLabel39.Size = new System.Drawing.Size(169, 42);
            this.xrLabel39.Text = "Stellenantritt";
            this.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel38
            // 
            this.xrLabel38.Dpi = 254F;
            this.xrLabel38.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel38.Location = new System.Drawing.Point(64, 161);
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel38.ParentStyleUsing.UseBackColor = false;
            this.xrLabel38.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel38.ParentStyleUsing.UseBorders = false;
            this.xrLabel38.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel38.ParentStyleUsing.UseFont = false;
            this.xrLabel38.Size = new System.Drawing.Size(43, 42);
            this.xrLabel38.Text = "=";
            this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel37
            // 
            this.xrLabel37.Dpi = 254F;
            this.xrLabel37.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel37.Location = new System.Drawing.Point(593, 204);
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel37.ParentStyleUsing.UseBackColor = false;
            this.xrLabel37.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel37.ParentStyleUsing.UseBorders = false;
            this.xrLabel37.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel37.ParentStyleUsing.UseFont = false;
            this.xrLabel37.Size = new System.Drawing.Size(43, 43);
            this.xrLabel37.Text = "=";
            this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel36
            // 
            this.xrLabel36.Dpi = 254F;
            this.xrLabel36.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel36.Location = new System.Drawing.Point(21, 161);
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel36.ParentStyleUsing.UseBackColor = false;
            this.xrLabel36.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel36.ParentStyleUsing.UseBorders = false;
            this.xrLabel36.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel36.ParentStyleUsing.UseFont = false;
            this.xrLabel36.Size = new System.Drawing.Size(42, 42);
            this.xrLabel36.Text = "D";
            this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel35
            // 
            this.xrLabel35.Dpi = 254F;
            this.xrLabel35.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel35.Location = new System.Drawing.Point(550, 204);
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel35.ParentStyleUsing.UseBackColor = false;
            this.xrLabel35.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel35.ParentStyleUsing.UseBorders = false;
            this.xrLabel35.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel35.ParentStyleUsing.UseFont = false;
            this.xrLabel35.Size = new System.Drawing.Size(42, 43);
            this.xrLabel35.Text = "H";
            this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel34
            // 
            this.xrLabel34.Dpi = 254F;
            this.xrLabel34.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel34.Location = new System.Drawing.Point(1122, 119);
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel34.ParentStyleUsing.UseBackColor = false;
            this.xrLabel34.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel34.ParentStyleUsing.UseBorders = false;
            this.xrLabel34.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel34.ParentStyleUsing.UseFont = false;
            this.xrLabel34.Size = new System.Drawing.Size(487, 43);
            this.xrLabel34.Text = "Militär / Zivilschutz / Zivildienst";
            this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel33
            // 
            this.xrLabel33.Dpi = 254F;
            this.xrLabel33.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel33.Location = new System.Drawing.Point(106, 204);
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel33.ParentStyleUsing.UseBackColor = false;
            this.xrLabel33.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel33.ParentStyleUsing.UseBorders = false;
            this.xrLabel33.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel33.ParentStyleUsing.UseFont = false;
            this.xrLabel33.Size = new System.Drawing.Size(360, 43);
            this.xrLabel33.Text = "Unentschuldigte Absenzen";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel32
            // 
            this.xrLabel32.Dpi = 254F;
            this.xrLabel32.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel32.Location = new System.Drawing.Point(1080, 119);
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel32.ParentStyleUsing.UseBackColor = false;
            this.xrLabel32.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel32.ParentStyleUsing.UseBorders = false;
            this.xrLabel32.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel32.ParentStyleUsing.UseFont = false;
            this.xrLabel32.Size = new System.Drawing.Size(42, 42);
            this.xrLabel32.Text = "=";
            this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel31
            // 
            this.xrLabel31.Dpi = 254F;
            this.xrLabel31.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel31.Location = new System.Drawing.Point(64, 204);
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel31.ParentStyleUsing.UseBackColor = false;
            this.xrLabel31.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel31.ParentStyleUsing.UseBorders = false;
            this.xrLabel31.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel31.ParentStyleUsing.UseFont = false;
            this.xrLabel31.Size = new System.Drawing.Size(42, 43);
            this.xrLabel31.Text = "=";
            this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel30
            // 
            this.xrLabel30.Dpi = 254F;
            this.xrLabel30.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel30.Location = new System.Drawing.Point(1037, 119);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel30.ParentStyleUsing.UseBackColor = false;
            this.xrLabel30.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel30.ParentStyleUsing.UseBorders = false;
            this.xrLabel30.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel30.ParentStyleUsing.UseFont = false;
            this.xrLabel30.Size = new System.Drawing.Size(43, 42);
            this.xrLabel30.Text = "C";
            this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel29
            // 
            this.xrLabel29.Dpi = 254F;
            this.xrLabel29.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel29.Location = new System.Drawing.Point(21, 204);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel29.ParentStyleUsing.UseBackColor = false;
            this.xrLabel29.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel29.ParentStyleUsing.UseBorders = false;
            this.xrLabel29.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel29.ParentStyleUsing.UseFont = false;
            this.xrLabel29.Size = new System.Drawing.Size(43, 43);
            this.xrLabel29.Text = "G";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel28
            // 
            this.xrLabel28.Dpi = 254F;
            this.xrLabel28.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel28.Location = new System.Drawing.Point(1122, 161);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel28.ParentStyleUsing.UseBackColor = false;
            this.xrLabel28.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel28.ParentStyleUsing.UseBorders = false;
            this.xrLabel28.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel28.ParentStyleUsing.UseFont = false;
            this.xrLabel28.Size = new System.Drawing.Size(106, 43);
            this.xrLabel28.Text = "Ferien";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrRichText3
            // 
            this.xrRichText3.Dpi = 254F;
            this.xrRichText3.Font = new System.Drawing.Font("Arial", 7F);
            this.xrRichText3.Location = new System.Drawing.Point(21, 21);
            this.xrRichText3.Name = "xrRichText3";
            this.xrRichText3.ParentStyleUsing.UseBackColor = false;
            this.xrRichText3.ParentStyleUsing.UseBorderColor = false;
            this.xrRichText3.ParentStyleUsing.UseBorders = false;
            this.xrRichText3.ParentStyleUsing.UseBorderWidth = false;
            this.xrRichText3.ParentStyleUsing.UseFont = false;
            this.xrRichText3.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichText3.RtfText")));
            this.xrRichText3.Size = new System.Drawing.Size(593, 42);
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 254F;
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel15.Location = new System.Drawing.Point(1037, 161);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel15.ParentStyleUsing.UseBackColor = false;
            this.xrLabel15.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel15.ParentStyleUsing.UseBorders = false;
            this.xrLabel15.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel15.ParentStyleUsing.UseFont = false;
            this.xrLabel15.Size = new System.Drawing.Size(42, 43);
            this.xrLabel15.Text = "F";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 254F;
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel14.Location = new System.Drawing.Point(1080, 161);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel14.ParentStyleUsing.UseBackColor = false;
            this.xrLabel14.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel14.ParentStyleUsing.UseBorders = false;
            this.xrLabel14.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel14.ParentStyleUsing.UseFont = false;
            this.xrLabel14.Size = new System.Drawing.Size(42, 43);
            this.xrLabel14.Text = "=";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 254F;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel12.Location = new System.Drawing.Point(550, 119);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel12.ParentStyleUsing.UseBackColor = false;
            this.xrLabel12.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel12.ParentStyleUsing.UseBorders = false;
            this.xrLabel12.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel12.ParentStyleUsing.UseFont = false;
            this.xrLabel12.Size = new System.Drawing.Size(42, 42);
            this.xrLabel12.Text = "B";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 254F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel11.Location = new System.Drawing.Point(593, 119);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel11.ParentStyleUsing.UseBackColor = false;
            this.xrLabel11.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel11.ParentStyleUsing.UseBorders = false;
            this.xrLabel11.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel11.ParentStyleUsing.UseFont = false;
            this.xrLabel11.Size = new System.Drawing.Size(42, 42);
            this.xrLabel11.Text = "=";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 254F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel10.Location = new System.Drawing.Point(635, 119);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel10.ParentStyleUsing.UseBackColor = false;
            this.xrLabel10.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel10.ParentStyleUsing.UseBorders = false;
            this.xrLabel10.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel10.ParentStyleUsing.UseFont = false;
            this.xrLabel10.Size = new System.Drawing.Size(106, 42);
            this.xrLabel10.Text = "Unfall";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 254F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.Location = new System.Drawing.Point(1037, 204);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel9.ParentStyleUsing.UseBackColor = false;
            this.xrLabel9.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel9.ParentStyleUsing.UseBorders = false;
            this.xrLabel9.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.Size = new System.Drawing.Size(43, 42);
            this.xrLabel9.Text = "I";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 254F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel8.Location = new System.Drawing.Point(1080, 204);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel8.ParentStyleUsing.UseBackColor = false;
            this.xrLabel8.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel8.ParentStyleUsing.UseBorders = false;
            this.xrLabel8.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.Size = new System.Drawing.Size(42, 42);
            this.xrLabel8.Text = "=";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 254F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel7.Location = new System.Drawing.Point(1122, 204);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel7.ParentStyleUsing.UseBackColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorders = false;
            this.xrLabel7.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.Size = new System.Drawing.Size(529, 43);
            this.xrLabel7.Text = "Feiertage / Brückentage / Betriebsferien";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 254F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.Location = new System.Drawing.Point(550, 161);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel6.ParentStyleUsing.UseBackColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorders = false;
            this.xrLabel6.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.Size = new System.Drawing.Size(43, 43);
            this.xrLabel6.Text = "E";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 254F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel5.Location = new System.Drawing.Point(593, 161);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel5.ParentStyleUsing.UseBackColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorders = false;
            this.xrLabel5.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(42, 43);
            this.xrLabel5.Text = "=";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel4.Location = new System.Drawing.Point(635, 161);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(339, 43);
            this.xrLabel4.Text = "Zwischenverdienst";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel3.Location = new System.Drawing.Point(106, 119);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(423, 43);
            this.xrLabel3.Text = "Krankheit oder Mutterschaft";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel2.Location = new System.Drawing.Point(64, 119);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.ParentStyleUsing.UseBackColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorders = false;
            this.xrLabel2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(42, 42);
            this.xrLabel2.Text = "=";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.Location = new System.Drawing.Point(21, 119);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.ParentStyleUsing.UseBackColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(43, 42);
            this.xrLabel1.Text = "A";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrRichText2
            // 
            this.xrRichText2.Dpi = 254F;
            this.xrRichText2.Font = new System.Drawing.Font("Arial", 7F);
            this.xrRichText2.Location = new System.Drawing.Point(21, 61);
            this.xrRichText2.Name = "xrRichText2";
            this.xrRichText2.ParentStyleUsing.UseBackColor = false;
            this.xrRichText2.ParentStyleUsing.UseBorderColor = false;
            this.xrRichText2.ParentStyleUsing.UseBorders = false;
            this.xrRichText2.ParentStyleUsing.UseBorderWidth = false;
            this.xrRichText2.ParentStyleUsing.UseFont = false;
            this.xrRichText2.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichText2.RtfText")));
            this.xrRichText2.Size = new System.Drawing.Size(1588, 45);
            // 
            // lblBemerkungen
            // 
            this.lblBemerkungen.Dpi = 254F;
            this.lblBemerkungen.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.lblBemerkungen.Location = new System.Drawing.Point(21, 389);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblBemerkungen.ParentStyleUsing.UseBackColor = false;
            this.lblBemerkungen.ParentStyleUsing.UseBorderColor = false;
            this.lblBemerkungen.ParentStyleUsing.UseBorders = false;
            this.lblBemerkungen.ParentStyleUsing.UseBorderWidth = false;
            this.lblBemerkungen.ParentStyleUsing.UseFont = false;
            this.lblBemerkungen.Size = new System.Drawing.Size(190, 45);
            this.lblBemerkungen.Text = "Bemerkungen:";
            this.lblBemerkungen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtBemerkungen
            // 
            this.txtBemerkungen.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Grund", "")});
            this.txtBemerkungen.Dpi = 254F;
            this.txtBemerkungen.Font = new System.Drawing.Font("Arial", 7F);
            this.txtBemerkungen.Location = new System.Drawing.Point(21, 431);
            this.txtBemerkungen.Name = "txtBemerkungen";
            this.txtBemerkungen.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtBemerkungen.ParentStyleUsing.UseBackColor = false;
            this.txtBemerkungen.ParentStyleUsing.UseBorderColor = false;
            this.txtBemerkungen.ParentStyleUsing.UseBorders = false;
            this.txtBemerkungen.ParentStyleUsing.UseBorderWidth = false;
            this.txtBemerkungen.ParentStyleUsing.UseFont = false;
            this.txtBemerkungen.Size = new System.Drawing.Size(1545, 42);
            this.txtBemerkungen.Text = "txtBemerkungen";
            this.txtBemerkungen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrRichText1
            // 
            this.xrRichText1.Dpi = 254F;
            this.xrRichText1.Font = new System.Drawing.Font("Arial", 7F);
            this.xrRichText1.Location = new System.Drawing.Point(21, 267);
            this.xrRichText1.Name = "xrRichText1";
            this.xrRichText1.ParentStyleUsing.UseBackColor = false;
            this.xrRichText1.ParentStyleUsing.UseBorderColor = false;
            this.xrRichText1.ParentStyleUsing.UseBorders = false;
            this.xrRichText1.ParentStyleUsing.UseBorderWidth = false;
            this.xrRichText1.ParentStyleUsing.UseFont = false;
            this.xrRichText1.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichText1.RtfText")));
            this.xrRichText1.Size = new System.Drawing.Size(1630, 106);
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
            this.Margins = new System.Drawing.Printing.Margins(254, 148, 254, 254);
            this.Name = "Report";
            this.PageHeight = 2969;
            this.PageWidth = 2101;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' ,  null ,  N'SELECT TOP 1
   Grund =
    CASE WHEN (AUS.AustrittDatum IS NOT NULL AND MONTH(AUS.AustrittDatum) = AMM.Monat) THEN
      AUS.AustrittCodeTextLang
   ELSE
     ''''
   END
FROM dbo.KaAmmBesch          AMM WITH (READUNCOMMITTED)
  LEFT JOIN dbo.KaEinsatz    EIN WITH (READUNCOMMITTED) ON EIN.KaEinsatzID = AMM.KaEinsatzID
  OUTER APPLY dbo.fnKaGetAustrittDatumCode(EIN.FaLeistungID, EIN.KaEinsatzID) AUS
WHERE AMM.BaPersonID = {BaPersonID}
AND AMM.KaEinsatzID = {KaEinsatzID}
AND AMM.KaAmmBeschID = {KaAmmBeschID}' ,  null ,  N'KAAAMBescheinigung' , 2,  0 );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'KAAMMBescheinigung_Praesenz' ,  N'KA - AMM Bescheinigung, Präsenzzeit' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\Kiss.Interfaces.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\FluentValidation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xml.Linq\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.Linq.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\log4net.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\Microsoft.Practices.Unity.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\Ionic.Zip.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\Kiss.BL.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\Kiss.Model.dll" />
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
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\KiSS.Common.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\Autofac.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\Common.Logging.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\HtmlAgilityPack.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\Kiss.Database.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\WPFLocalizeExtension.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS\Build\Debug\XAMLMarkupExtensions.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow rowTitle;
        private DevExpress.XtraReports.UI.XRTableCell xtcText;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay1;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay2;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay3;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay4;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay5;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay6;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay7;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay8;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay9;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay10;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay11;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay12;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay13;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay14;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay15;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay16;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay17;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay18;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay19;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay20;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay21;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay22;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay23;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay24;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay25;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay26;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay27;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay28;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay29;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay30;
        private DevExpress.XtraReports.UI.XRTableCell xtcDay31;
        private DevExpress.XtraReports.UI.XRTableCell xtcTmp;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell34;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell35;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell36;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell37;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell38;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell39;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell40;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell41;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell42;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell43;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell44;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell45;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell46;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell47;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell48;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell49;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell50;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell51;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell52;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell53;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell54;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell55;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell56;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell57;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell58;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell59;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell60;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell61;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell62;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell63;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell64;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell65;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell66;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell11;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell13;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell15;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell16;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell17;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell18;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell19;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell20;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell21;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell22;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell23;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell24;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell25;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell26;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell27;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell28;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell29;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell30;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell31;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell32;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell33;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = @"zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OSNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kAAAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAAAAAAcECREVDTEFSRSBATW9uYXQgSU5UDQpERUNMQVJFIEBKYWhyIElOVA0KREVDTEFSRSBARGF0dW1Wb24gREFURVRJTUUNCkRFQ0xBUkUgQERhdHVtQmlzIERBVEVUSU1FDQoNClNFTEVDVCBATW9uYXQgPSBNb25hdCwgQEphaHIgPSBKYWhyLCBARGF0dW1Wb24gPSBEYXR1bVZvbiwgQERhdHVtQmlzID0gRGF0dW1CaXMNCkZST00gIGRiby5LYUFtbUJlc2NoIFdJVEggKFJFQURVTkNPTU1JVFRFRCkNCldIRVJFIEthQW1tQmVzY2hJRCA9IG51bGwNCg0KRVhFQyBzcEthR2V0UHJhZXNlbnp6ZWl0QU1NIG51bGwsIEBNb25hdCwgQEphaHIsIEBEYXR1bVZvbiwgQERhdHVtQmlz";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.rowTitle = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xtcText = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcDay31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xtcTmp = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell53 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell54 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell55 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell56 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell57 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell58 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell59 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell60 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell61 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell62 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell63 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell64 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell65 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPanel1});
            this.Detail.Dpi = 254F;
            this.Detail.Height = 225;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBorders = false;
            // 
            // xrPanel1
            // 
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrTable1,
                        this.xrLabel1});
            this.xrPanel1.Dpi = 254F;
            this.xrPanel1.Location = new System.Drawing.Point(0, 0);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.ParentStyleUsing.UseBorders = false;
            this.xrPanel1.Size = new System.Drawing.Size(1736, 225);
            // 
            // xrTable1
            // 
            this.xrTable1.Dpi = 254F;
            this.xrTable1.Location = new System.Drawing.Point(0, 0);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.rowTitle,
                        this.xrTableRow2,
                        this.xrTableRow1});
            this.xrTable1.Size = new System.Drawing.Size(1842, 180);
            // 
            // xrLabel1
            // 
            this.xrLabel1.BorderWidth = 0;
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 7F);
            this.xrLabel1.Location = new System.Drawing.Point(24, 180);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(1630, 40);
            this.xrLabel1.Text = "(VM = Vormittag, NM = Nachmittag)";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // rowTitle
            // 
            this.rowTitle.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xtcText,
                        this.xtcDay1,
                        this.xtcDay2,
                        this.xtcDay3,
                        this.xtcDay4,
                        this.xtcDay5,
                        this.xtcDay6,
                        this.xtcDay7,
                        this.xtcDay8,
                        this.xtcDay9,
                        this.xtcDay10,
                        this.xtcDay11,
                        this.xtcDay12,
                        this.xtcDay13,
                        this.xtcDay14,
                        this.xtcDay15,
                        this.xtcDay16,
                        this.xtcDay17,
                        this.xtcDay18,
                        this.xtcDay19,
                        this.xtcDay20,
                        this.xtcDay21,
                        this.xtcDay22,
                        this.xtcDay23,
                        this.xtcDay24,
                        this.xtcDay25,
                        this.xtcDay26,
                        this.xtcDay27,
                        this.xtcDay28,
                        this.xtcDay29,
                        this.xtcDay30,
                        this.xtcDay31,
                        this.xtcTmp});
            this.rowTitle.Dpi = 254F;
            this.rowTitle.Font = new System.Drawing.Font("Arial", 8F);
            this.rowTitle.Name = "rowTitle";
            this.rowTitle.ParentStyleUsing.UseFont = false;
            this.rowTitle.Size = new System.Drawing.Size(1842, 60);
            this.rowTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell34,
                        this.xrTableCell35,
                        this.xrTableCell36,
                        this.xrTableCell37,
                        this.xrTableCell38,
                        this.xrTableCell39,
                        this.xrTableCell40,
                        this.xrTableCell41,
                        this.xrTableCell42,
                        this.xrTableCell43,
                        this.xrTableCell44,
                        this.xrTableCell45,
                        this.xrTableCell46,
                        this.xrTableCell47,
                        this.xrTableCell48,
                        this.xrTableCell49,
                        this.xrTableCell50,
                        this.xrTableCell51,
                        this.xrTableCell52,
                        this.xrTableCell53,
                        this.xrTableCell54,
                        this.xrTableCell55,
                        this.xrTableCell56,
                        this.xrTableCell57,
                        this.xrTableCell58,
                        this.xrTableCell59,
                        this.xrTableCell60,
                        this.xrTableCell61,
                        this.xrTableCell62,
                        this.xrTableCell63,
                        this.xrTableCell64,
                        this.xrTableCell65,
                        this.xrTableCell66});
            this.xrTableRow2.Dpi = 254F;
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Size = new System.Drawing.Size(1842, 60);
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell1,
                        this.xrTableCell2,
                        this.xrTableCell3,
                        this.xrTableCell4,
                        this.xrTableCell5,
                        this.xrTableCell6,
                        this.xrTableCell7,
                        this.xrTableCell8,
                        this.xrTableCell9,
                        this.xrTableCell10,
                        this.xrTableCell11,
                        this.xrTableCell12,
                        this.xrTableCell13,
                        this.xrTableCell14,
                        this.xrTableCell15,
                        this.xrTableCell16,
                        this.xrTableCell17,
                        this.xrTableCell18,
                        this.xrTableCell19,
                        this.xrTableCell20,
                        this.xrTableCell21,
                        this.xrTableCell22,
                        this.xrTableCell23,
                        this.xrTableCell24,
                        this.xrTableCell25,
                        this.xrTableCell26,
                        this.xrTableCell27,
                        this.xrTableCell28,
                        this.xrTableCell29,
                        this.xrTableCell30,
                        this.xrTableCell31,
                        this.xrTableCell32,
                        this.xrTableCell33});
            this.xrTableRow1.Dpi = 254F;
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Size = new System.Drawing.Size(1842, 60);
            // 
            // xtcText
            // 
            this.xtcText.BackColor = System.Drawing.Color.White;
            this.xtcText.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcText.Dpi = 254F;
            this.xtcText.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcText.Location = new System.Drawing.Point(0, 0);
            this.xtcText.Name = "xtcText";
            this.xtcText.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcText.ParentStyleUsing.UseBackColor = false;
            this.xtcText.ParentStyleUsing.UseBorders = false;
            this.xtcText.ParentStyleUsing.UseFont = false;
            this.xtcText.Size = new System.Drawing.Size(101, 60);
            this.xtcText.Text = "Tag";
            this.xtcText.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay1
            // 
            this.xtcDay1.BackColor = System.Drawing.Color.White;
            this.xtcDay1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay1.Dpi = 254F;
            this.xtcDay1.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay1.Location = new System.Drawing.Point(101, 0);
            this.xtcDay1.Name = "xtcDay1";
            this.xtcDay1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay1.ParentStyleUsing.UseBackColor = false;
            this.xtcDay1.ParentStyleUsing.UseBorders = false;
            this.xtcDay1.ParentStyleUsing.UseFont = false;
            this.xtcDay1.Size = new System.Drawing.Size(50, 60);
            this.xtcDay1.Text = "1";
            this.xtcDay1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay2
            // 
            this.xtcDay2.BackColor = System.Drawing.Color.White;
            this.xtcDay2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay2.Dpi = 254F;
            this.xtcDay2.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay2.Location = new System.Drawing.Point(151, 0);
            this.xtcDay2.Name = "xtcDay2";
            this.xtcDay2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay2.ParentStyleUsing.UseBackColor = false;
            this.xtcDay2.ParentStyleUsing.UseBorders = false;
            this.xtcDay2.ParentStyleUsing.UseFont = false;
            this.xtcDay2.Size = new System.Drawing.Size(50, 60);
            this.xtcDay2.Text = "2";
            this.xtcDay2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay3
            // 
            this.xtcDay3.BackColor = System.Drawing.Color.White;
            this.xtcDay3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay3.Dpi = 254F;
            this.xtcDay3.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay3.Location = new System.Drawing.Point(201, 0);
            this.xtcDay3.Name = "xtcDay3";
            this.xtcDay3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay3.ParentStyleUsing.UseBackColor = false;
            this.xtcDay3.ParentStyleUsing.UseBorders = false;
            this.xtcDay3.ParentStyleUsing.UseFont = false;
            this.xtcDay3.Size = new System.Drawing.Size(50, 60);
            this.xtcDay3.Text = "3";
            this.xtcDay3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay4
            // 
            this.xtcDay4.BackColor = System.Drawing.Color.White;
            this.xtcDay4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay4.Dpi = 254F;
            this.xtcDay4.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay4.Location = new System.Drawing.Point(251, 0);
            this.xtcDay4.Name = "xtcDay4";
            this.xtcDay4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay4.ParentStyleUsing.UseBackColor = false;
            this.xtcDay4.ParentStyleUsing.UseBorders = false;
            this.xtcDay4.ParentStyleUsing.UseFont = false;
            this.xtcDay4.Size = new System.Drawing.Size(50, 60);
            this.xtcDay4.Text = "4";
            this.xtcDay4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay5
            // 
            this.xtcDay5.BackColor = System.Drawing.Color.White;
            this.xtcDay5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay5.Dpi = 254F;
            this.xtcDay5.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay5.Location = new System.Drawing.Point(301, 0);
            this.xtcDay5.Name = "xtcDay5";
            this.xtcDay5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay5.ParentStyleUsing.UseBackColor = false;
            this.xtcDay5.ParentStyleUsing.UseBorders = false;
            this.xtcDay5.ParentStyleUsing.UseFont = false;
            this.xtcDay5.Size = new System.Drawing.Size(50, 60);
            this.xtcDay5.Text = "5";
            this.xtcDay5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay6
            // 
            this.xtcDay6.BackColor = System.Drawing.Color.White;
            this.xtcDay6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay6.Dpi = 254F;
            this.xtcDay6.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay6.Location = new System.Drawing.Point(351, 0);
            this.xtcDay6.Name = "xtcDay6";
            this.xtcDay6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay6.ParentStyleUsing.UseBackColor = false;
            this.xtcDay6.ParentStyleUsing.UseBorders = false;
            this.xtcDay6.ParentStyleUsing.UseFont = false;
            this.xtcDay6.Size = new System.Drawing.Size(50, 60);
            this.xtcDay6.Text = "6";
            this.xtcDay6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay7
            // 
            this.xtcDay7.BackColor = System.Drawing.Color.White;
            this.xtcDay7.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay7.Dpi = 254F;
            this.xtcDay7.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay7.Location = new System.Drawing.Point(401, 0);
            this.xtcDay7.Name = "xtcDay7";
            this.xtcDay7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay7.ParentStyleUsing.UseBackColor = false;
            this.xtcDay7.ParentStyleUsing.UseBorders = false;
            this.xtcDay7.ParentStyleUsing.UseFont = false;
            this.xtcDay7.Size = new System.Drawing.Size(50, 60);
            this.xtcDay7.Text = "7";
            this.xtcDay7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay8
            // 
            this.xtcDay8.BackColor = System.Drawing.Color.White;
            this.xtcDay8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay8.Dpi = 254F;
            this.xtcDay8.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay8.Location = new System.Drawing.Point(451, 0);
            this.xtcDay8.Name = "xtcDay8";
            this.xtcDay8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay8.ParentStyleUsing.UseBackColor = false;
            this.xtcDay8.ParentStyleUsing.UseBorders = false;
            this.xtcDay8.ParentStyleUsing.UseFont = false;
            this.xtcDay8.Size = new System.Drawing.Size(50, 60);
            this.xtcDay8.Text = "8";
            this.xtcDay8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay9
            // 
            this.xtcDay9.BackColor = System.Drawing.Color.White;
            this.xtcDay9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay9.Dpi = 254F;
            this.xtcDay9.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay9.Location = new System.Drawing.Point(501, 0);
            this.xtcDay9.Name = "xtcDay9";
            this.xtcDay9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay9.ParentStyleUsing.UseBackColor = false;
            this.xtcDay9.ParentStyleUsing.UseBorders = false;
            this.xtcDay9.ParentStyleUsing.UseFont = false;
            this.xtcDay9.Size = new System.Drawing.Size(50, 60);
            this.xtcDay9.Text = "9";
            this.xtcDay9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay10
            // 
            this.xtcDay10.BackColor = System.Drawing.Color.White;
            this.xtcDay10.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay10.Dpi = 254F;
            this.xtcDay10.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay10.Location = new System.Drawing.Point(551, 0);
            this.xtcDay10.Name = "xtcDay10";
            this.xtcDay10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay10.ParentStyleUsing.UseBackColor = false;
            this.xtcDay10.ParentStyleUsing.UseBorders = false;
            this.xtcDay10.ParentStyleUsing.UseFont = false;
            this.xtcDay10.Size = new System.Drawing.Size(50, 60);
            this.xtcDay10.Text = "10";
            this.xtcDay10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay11
            // 
            this.xtcDay11.BackColor = System.Drawing.Color.White;
            this.xtcDay11.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay11.Dpi = 254F;
            this.xtcDay11.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay11.Location = new System.Drawing.Point(601, 0);
            this.xtcDay11.Name = "xtcDay11";
            this.xtcDay11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay11.ParentStyleUsing.UseBackColor = false;
            this.xtcDay11.ParentStyleUsing.UseBorders = false;
            this.xtcDay11.ParentStyleUsing.UseFont = false;
            this.xtcDay11.Size = new System.Drawing.Size(50, 60);
            this.xtcDay11.Text = "11";
            this.xtcDay11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay12
            // 
            this.xtcDay12.BackColor = System.Drawing.Color.White;
            this.xtcDay12.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay12.Dpi = 254F;
            this.xtcDay12.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay12.Location = new System.Drawing.Point(651, 0);
            this.xtcDay12.Name = "xtcDay12";
            this.xtcDay12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay12.ParentStyleUsing.UseBackColor = false;
            this.xtcDay12.ParentStyleUsing.UseBorders = false;
            this.xtcDay12.ParentStyleUsing.UseFont = false;
            this.xtcDay12.Size = new System.Drawing.Size(50, 60);
            this.xtcDay12.Text = "12";
            this.xtcDay12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay13
            // 
            this.xtcDay13.BackColor = System.Drawing.Color.White;
            this.xtcDay13.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay13.Dpi = 254F;
            this.xtcDay13.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay13.Location = new System.Drawing.Point(701, 0);
            this.xtcDay13.Name = "xtcDay13";
            this.xtcDay13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay13.ParentStyleUsing.UseBackColor = false;
            this.xtcDay13.ParentStyleUsing.UseBorders = false;
            this.xtcDay13.ParentStyleUsing.UseFont = false;
            this.xtcDay13.Size = new System.Drawing.Size(50, 60);
            this.xtcDay13.Text = "13";
            this.xtcDay13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay14
            // 
            this.xtcDay14.BackColor = System.Drawing.Color.White;
            this.xtcDay14.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay14.Dpi = 254F;
            this.xtcDay14.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay14.Location = new System.Drawing.Point(751, 0);
            this.xtcDay14.Name = "xtcDay14";
            this.xtcDay14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay14.ParentStyleUsing.UseBackColor = false;
            this.xtcDay14.ParentStyleUsing.UseBorders = false;
            this.xtcDay14.ParentStyleUsing.UseFont = false;
            this.xtcDay14.Size = new System.Drawing.Size(50, 60);
            this.xtcDay14.Text = "14";
            this.xtcDay14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay15
            // 
            this.xtcDay15.BackColor = System.Drawing.Color.White;
            this.xtcDay15.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay15.Dpi = 254F;
            this.xtcDay15.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay15.Location = new System.Drawing.Point(801, 0);
            this.xtcDay15.Name = "xtcDay15";
            this.xtcDay15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay15.ParentStyleUsing.UseBackColor = false;
            this.xtcDay15.ParentStyleUsing.UseBorders = false;
            this.xtcDay15.ParentStyleUsing.UseFont = false;
            this.xtcDay15.Size = new System.Drawing.Size(50, 60);
            this.xtcDay15.Text = "15";
            this.xtcDay15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay16
            // 
            this.xtcDay16.BackColor = System.Drawing.Color.White;
            this.xtcDay16.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay16.Dpi = 254F;
            this.xtcDay16.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay16.Location = new System.Drawing.Point(851, 0);
            this.xtcDay16.Name = "xtcDay16";
            this.xtcDay16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay16.ParentStyleUsing.UseBackColor = false;
            this.xtcDay16.ParentStyleUsing.UseBorders = false;
            this.xtcDay16.ParentStyleUsing.UseFont = false;
            this.xtcDay16.Size = new System.Drawing.Size(50, 60);
            this.xtcDay16.Text = "16";
            this.xtcDay16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay17
            // 
            this.xtcDay17.BackColor = System.Drawing.Color.White;
            this.xtcDay17.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay17.Dpi = 254F;
            this.xtcDay17.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay17.Location = new System.Drawing.Point(901, 0);
            this.xtcDay17.Name = "xtcDay17";
            this.xtcDay17.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay17.ParentStyleUsing.UseBackColor = false;
            this.xtcDay17.ParentStyleUsing.UseBorders = false;
            this.xtcDay17.ParentStyleUsing.UseFont = false;
            this.xtcDay17.Size = new System.Drawing.Size(50, 60);
            this.xtcDay17.Text = "17";
            this.xtcDay17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay18
            // 
            this.xtcDay18.BackColor = System.Drawing.Color.White;
            this.xtcDay18.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay18.Dpi = 254F;
            this.xtcDay18.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay18.Location = new System.Drawing.Point(951, 0);
            this.xtcDay18.Name = "xtcDay18";
            this.xtcDay18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay18.ParentStyleUsing.UseBackColor = false;
            this.xtcDay18.ParentStyleUsing.UseBorders = false;
            this.xtcDay18.ParentStyleUsing.UseFont = false;
            this.xtcDay18.Size = new System.Drawing.Size(50, 60);
            this.xtcDay18.Text = "18";
            this.xtcDay18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay19
            // 
            this.xtcDay19.BackColor = System.Drawing.Color.White;
            this.xtcDay19.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay19.Dpi = 254F;
            this.xtcDay19.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay19.Location = new System.Drawing.Point(1001, 0);
            this.xtcDay19.Name = "xtcDay19";
            this.xtcDay19.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay19.ParentStyleUsing.UseBackColor = false;
            this.xtcDay19.ParentStyleUsing.UseBorders = false;
            this.xtcDay19.ParentStyleUsing.UseFont = false;
            this.xtcDay19.Size = new System.Drawing.Size(50, 60);
            this.xtcDay19.Text = "19";
            this.xtcDay19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay20
            // 
            this.xtcDay20.BackColor = System.Drawing.Color.White;
            this.xtcDay20.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay20.Dpi = 254F;
            this.xtcDay20.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay20.Location = new System.Drawing.Point(1051, 0);
            this.xtcDay20.Name = "xtcDay20";
            this.xtcDay20.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay20.ParentStyleUsing.UseBackColor = false;
            this.xtcDay20.ParentStyleUsing.UseBorders = false;
            this.xtcDay20.ParentStyleUsing.UseFont = false;
            this.xtcDay20.Size = new System.Drawing.Size(50, 60);
            this.xtcDay20.Text = "20";
            this.xtcDay20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay21
            // 
            this.xtcDay21.BackColor = System.Drawing.Color.White;
            this.xtcDay21.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay21.Dpi = 254F;
            this.xtcDay21.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay21.Location = new System.Drawing.Point(1101, 0);
            this.xtcDay21.Name = "xtcDay21";
            this.xtcDay21.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay21.ParentStyleUsing.UseBackColor = false;
            this.xtcDay21.ParentStyleUsing.UseBorders = false;
            this.xtcDay21.ParentStyleUsing.UseFont = false;
            this.xtcDay21.Size = new System.Drawing.Size(50, 60);
            this.xtcDay21.Text = "21";
            this.xtcDay21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay22
            // 
            this.xtcDay22.BackColor = System.Drawing.Color.White;
            this.xtcDay22.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay22.Dpi = 254F;
            this.xtcDay22.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay22.Location = new System.Drawing.Point(1151, 0);
            this.xtcDay22.Name = "xtcDay22";
            this.xtcDay22.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay22.ParentStyleUsing.UseBackColor = false;
            this.xtcDay22.ParentStyleUsing.UseBorders = false;
            this.xtcDay22.ParentStyleUsing.UseFont = false;
            this.xtcDay22.Size = new System.Drawing.Size(50, 60);
            this.xtcDay22.Text = "22";
            this.xtcDay22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay23
            // 
            this.xtcDay23.BackColor = System.Drawing.Color.White;
            this.xtcDay23.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay23.Dpi = 254F;
            this.xtcDay23.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay23.Location = new System.Drawing.Point(1201, 0);
            this.xtcDay23.Name = "xtcDay23";
            this.xtcDay23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay23.ParentStyleUsing.UseBackColor = false;
            this.xtcDay23.ParentStyleUsing.UseBorders = false;
            this.xtcDay23.ParentStyleUsing.UseFont = false;
            this.xtcDay23.Size = new System.Drawing.Size(50, 60);
            this.xtcDay23.Text = "23";
            this.xtcDay23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay24
            // 
            this.xtcDay24.BackColor = System.Drawing.Color.White;
            this.xtcDay24.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay24.Dpi = 254F;
            this.xtcDay24.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay24.Location = new System.Drawing.Point(1251, 0);
            this.xtcDay24.Name = "xtcDay24";
            this.xtcDay24.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay24.ParentStyleUsing.UseBackColor = false;
            this.xtcDay24.ParentStyleUsing.UseBorders = false;
            this.xtcDay24.ParentStyleUsing.UseFont = false;
            this.xtcDay24.Size = new System.Drawing.Size(50, 60);
            this.xtcDay24.Text = "24";
            this.xtcDay24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay25
            // 
            this.xtcDay25.BackColor = System.Drawing.Color.White;
            this.xtcDay25.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay25.Dpi = 254F;
            this.xtcDay25.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay25.Location = new System.Drawing.Point(1301, 0);
            this.xtcDay25.Name = "xtcDay25";
            this.xtcDay25.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay25.ParentStyleUsing.UseBackColor = false;
            this.xtcDay25.ParentStyleUsing.UseBorders = false;
            this.xtcDay25.ParentStyleUsing.UseFont = false;
            this.xtcDay25.Size = new System.Drawing.Size(50, 60);
            this.xtcDay25.Text = "25";
            this.xtcDay25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay26
            // 
            this.xtcDay26.BackColor = System.Drawing.Color.White;
            this.xtcDay26.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay26.Dpi = 254F;
            this.xtcDay26.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay26.Location = new System.Drawing.Point(1351, 0);
            this.xtcDay26.Name = "xtcDay26";
            this.xtcDay26.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay26.ParentStyleUsing.UseBackColor = false;
            this.xtcDay26.ParentStyleUsing.UseBorders = false;
            this.xtcDay26.ParentStyleUsing.UseFont = false;
            this.xtcDay26.Size = new System.Drawing.Size(50, 60);
            this.xtcDay26.Text = "26";
            this.xtcDay26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay27
            // 
            this.xtcDay27.BackColor = System.Drawing.Color.White;
            this.xtcDay27.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay27.Dpi = 254F;
            this.xtcDay27.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay27.Location = new System.Drawing.Point(1401, 0);
            this.xtcDay27.Name = "xtcDay27";
            this.xtcDay27.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay27.ParentStyleUsing.UseBackColor = false;
            this.xtcDay27.ParentStyleUsing.UseBorders = false;
            this.xtcDay27.ParentStyleUsing.UseFont = false;
            this.xtcDay27.Size = new System.Drawing.Size(50, 60);
            this.xtcDay27.Text = "27";
            this.xtcDay27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay28
            // 
            this.xtcDay28.BackColor = System.Drawing.Color.White;
            this.xtcDay28.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Day28", "")});
            this.xtcDay28.Dpi = 254F;
            this.xtcDay28.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay28.Location = new System.Drawing.Point(1451, 0);
            this.xtcDay28.Name = "xtcDay28";
            this.xtcDay28.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay28.ParentStyleUsing.UseBackColor = false;
            this.xtcDay28.ParentStyleUsing.UseBorders = false;
            this.xtcDay28.ParentStyleUsing.UseFont = false;
            this.xtcDay28.Size = new System.Drawing.Size(50, 60);
            this.xtcDay28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay29
            // 
            this.xtcDay29.BackColor = System.Drawing.Color.White;
            this.xtcDay29.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Day29", "")});
            this.xtcDay29.Dpi = 254F;
            this.xtcDay29.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay29.Location = new System.Drawing.Point(1501, 0);
            this.xtcDay29.Name = "xtcDay29";
            this.xtcDay29.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay29.ParentStyleUsing.UseBackColor = false;
            this.xtcDay29.ParentStyleUsing.UseBorders = false;
            this.xtcDay29.ParentStyleUsing.UseFont = false;
            this.xtcDay29.Size = new System.Drawing.Size(50, 60);
            this.xtcDay29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay30
            // 
            this.xtcDay30.BackColor = System.Drawing.Color.White;
            this.xtcDay30.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xtcDay30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Day30", "")});
            this.xtcDay30.Dpi = 254F;
            this.xtcDay30.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay30.Location = new System.Drawing.Point(1551, 0);
            this.xtcDay30.Name = "xtcDay30";
            this.xtcDay30.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay30.ParentStyleUsing.UseBackColor = false;
            this.xtcDay30.ParentStyleUsing.UseBorders = false;
            this.xtcDay30.ParentStyleUsing.UseFont = false;
            this.xtcDay30.Size = new System.Drawing.Size(50, 60);
            this.xtcDay30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcDay31
            // 
            this.xtcDay31.BackColor = System.Drawing.Color.White;
            this.xtcDay31.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xtcDay31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Day31", "")});
            this.xtcDay31.Dpi = 254F;
            this.xtcDay31.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcDay31.Location = new System.Drawing.Point(1601, 0);
            this.xtcDay31.Name = "xtcDay31";
            this.xtcDay31.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcDay31.ParentStyleUsing.UseBackColor = false;
            this.xtcDay31.ParentStyleUsing.UseBorders = false;
            this.xtcDay31.ParentStyleUsing.UseFont = false;
            this.xtcDay31.Size = new System.Drawing.Size(50, 60);
            this.xtcDay31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xtcTmp
            // 
            this.xtcTmp.Dpi = 254F;
            this.xtcTmp.Font = new System.Drawing.Font("Arial", 7F);
            this.xtcTmp.Location = new System.Drawing.Point(1651, 0);
            this.xtcTmp.Name = "xtcTmp";
            this.xtcTmp.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xtcTmp.ParentStyleUsing.UseBorders = false;
            this.xtcTmp.ParentStyleUsing.UseFont = false;
            this.xtcTmp.Size = new System.Drawing.Size(191, 60);
            this.xtcTmp.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell34
            // 
            this.xrTableCell34.BackColor = System.Drawing.Color.White;
            this.xrTableCell34.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell34.Dpi = 254F;
            this.xrTableCell34.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell34.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell34.Name = "xrTableCell34";
            this.xrTableCell34.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell34.ParentStyleUsing.UseBackColor = false;
            this.xrTableCell34.ParentStyleUsing.UseBorders = false;
            this.xrTableCell34.ParentStyleUsing.UseFont = false;
            this.xrTableCell34.Size = new System.Drawing.Size(101, 60);
            this.xrTableCell34.Text = "VM";
            this.xrTableCell34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell35
            // 
            this.xrTableCell35.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell35.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C01V", "")});
            this.xrTableCell35.Dpi = 254F;
            this.xrTableCell35.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell35.Location = new System.Drawing.Point(101, 0);
            this.xrTableCell35.Name = "xrTableCell35";
            this.xrTableCell35.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell35.ParentStyleUsing.UseBorders = false;
            this.xrTableCell35.ParentStyleUsing.UseFont = false;
            this.xrTableCell35.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell36.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C02V", "")});
            this.xrTableCell36.Dpi = 254F;
            this.xrTableCell36.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell36.Location = new System.Drawing.Point(151, 0);
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell36.ParentStyleUsing.UseBorders = false;
            this.xrTableCell36.ParentStyleUsing.UseFont = false;
            this.xrTableCell36.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell37
            // 
            this.xrTableCell37.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell37.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C03V", "")});
            this.xrTableCell37.Dpi = 254F;
            this.xrTableCell37.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell37.Location = new System.Drawing.Point(201, 0);
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell37.ParentStyleUsing.UseBorders = false;
            this.xrTableCell37.ParentStyleUsing.UseFont = false;
            this.xrTableCell37.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell38.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C04V", "")});
            this.xrTableCell38.Dpi = 254F;
            this.xrTableCell38.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell38.Location = new System.Drawing.Point(251, 0);
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell38.ParentStyleUsing.UseBorders = false;
            this.xrTableCell38.ParentStyleUsing.UseFont = false;
            this.xrTableCell38.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell39
            // 
            this.xrTableCell39.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell39.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C05V", "")});
            this.xrTableCell39.Dpi = 254F;
            this.xrTableCell39.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell39.Location = new System.Drawing.Point(301, 0);
            this.xrTableCell39.Name = "xrTableCell39";
            this.xrTableCell39.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell39.ParentStyleUsing.UseBorders = false;
            this.xrTableCell39.ParentStyleUsing.UseFont = false;
            this.xrTableCell39.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell40.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C06V", "")});
            this.xrTableCell40.Dpi = 254F;
            this.xrTableCell40.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell40.Location = new System.Drawing.Point(351, 0);
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell40.ParentStyleUsing.UseBorders = false;
            this.xrTableCell40.ParentStyleUsing.UseFont = false;
            this.xrTableCell40.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell41
            // 
            this.xrTableCell41.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell41.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C07V", "")});
            this.xrTableCell41.Dpi = 254F;
            this.xrTableCell41.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell41.Location = new System.Drawing.Point(401, 0);
            this.xrTableCell41.Name = "xrTableCell41";
            this.xrTableCell41.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell41.ParentStyleUsing.UseBorders = false;
            this.xrTableCell41.ParentStyleUsing.UseFont = false;
            this.xrTableCell41.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell42.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C08V", "")});
            this.xrTableCell42.Dpi = 254F;
            this.xrTableCell42.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell42.Location = new System.Drawing.Point(451, 0);
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell42.ParentStyleUsing.UseBorders = false;
            this.xrTableCell42.ParentStyleUsing.UseFont = false;
            this.xrTableCell42.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell43
            // 
            this.xrTableCell43.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell43.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C09V", "")});
            this.xrTableCell43.Dpi = 254F;
            this.xrTableCell43.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell43.Location = new System.Drawing.Point(501, 0);
            this.xrTableCell43.Name = "xrTableCell43";
            this.xrTableCell43.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell43.ParentStyleUsing.UseBorders = false;
            this.xrTableCell43.ParentStyleUsing.UseFont = false;
            this.xrTableCell43.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell44
            // 
            this.xrTableCell44.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell44.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C10V", "")});
            this.xrTableCell44.Dpi = 254F;
            this.xrTableCell44.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell44.Location = new System.Drawing.Point(551, 0);
            this.xrTableCell44.Name = "xrTableCell44";
            this.xrTableCell44.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell44.ParentStyleUsing.UseBorders = false;
            this.xrTableCell44.ParentStyleUsing.UseFont = false;
            this.xrTableCell44.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell45.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C11V", "")});
            this.xrTableCell45.Dpi = 254F;
            this.xrTableCell45.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell45.Location = new System.Drawing.Point(601, 0);
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell45.ParentStyleUsing.UseBorders = false;
            this.xrTableCell45.ParentStyleUsing.UseFont = false;
            this.xrTableCell45.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell46
            // 
            this.xrTableCell46.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell46.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C12V", "")});
            this.xrTableCell46.Dpi = 254F;
            this.xrTableCell46.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell46.Location = new System.Drawing.Point(651, 0);
            this.xrTableCell46.Name = "xrTableCell46";
            this.xrTableCell46.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell46.ParentStyleUsing.UseBorders = false;
            this.xrTableCell46.ParentStyleUsing.UseFont = false;
            this.xrTableCell46.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell47
            // 
            this.xrTableCell47.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell47.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C13V", "")});
            this.xrTableCell47.Dpi = 254F;
            this.xrTableCell47.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell47.Location = new System.Drawing.Point(701, 0);
            this.xrTableCell47.Name = "xrTableCell47";
            this.xrTableCell47.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell47.ParentStyleUsing.UseBorders = false;
            this.xrTableCell47.ParentStyleUsing.UseFont = false;
            this.xrTableCell47.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell48.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C14V", "")});
            this.xrTableCell48.Dpi = 254F;
            this.xrTableCell48.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell48.Location = new System.Drawing.Point(751, 0);
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell48.ParentStyleUsing.UseBorders = false;
            this.xrTableCell48.ParentStyleUsing.UseFont = false;
            this.xrTableCell48.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell49
            // 
            this.xrTableCell49.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell49.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C15V", "")});
            this.xrTableCell49.Dpi = 254F;
            this.xrTableCell49.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell49.Location = new System.Drawing.Point(801, 0);
            this.xrTableCell49.Name = "xrTableCell49";
            this.xrTableCell49.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell49.ParentStyleUsing.UseBorders = false;
            this.xrTableCell49.ParentStyleUsing.UseFont = false;
            this.xrTableCell49.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell50
            // 
            this.xrTableCell50.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell50.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C16V", "")});
            this.xrTableCell50.Dpi = 254F;
            this.xrTableCell50.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell50.Location = new System.Drawing.Point(851, 0);
            this.xrTableCell50.Name = "xrTableCell50";
            this.xrTableCell50.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell50.ParentStyleUsing.UseBorders = false;
            this.xrTableCell50.ParentStyleUsing.UseFont = false;
            this.xrTableCell50.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell51
            // 
            this.xrTableCell51.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell51.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C17V", "")});
            this.xrTableCell51.Dpi = 254F;
            this.xrTableCell51.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell51.Location = new System.Drawing.Point(901, 0);
            this.xrTableCell51.Name = "xrTableCell51";
            this.xrTableCell51.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell51.ParentStyleUsing.UseBorders = false;
            this.xrTableCell51.ParentStyleUsing.UseFont = false;
            this.xrTableCell51.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell52
            // 
            this.xrTableCell52.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell52.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C18V", "")});
            this.xrTableCell52.Dpi = 254F;
            this.xrTableCell52.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell52.Location = new System.Drawing.Point(951, 0);
            this.xrTableCell52.Name = "xrTableCell52";
            this.xrTableCell52.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell52.ParentStyleUsing.UseBorders = false;
            this.xrTableCell52.ParentStyleUsing.UseFont = false;
            this.xrTableCell52.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell53
            // 
            this.xrTableCell53.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell53.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C19V", "")});
            this.xrTableCell53.Dpi = 254F;
            this.xrTableCell53.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell53.Location = new System.Drawing.Point(1001, 0);
            this.xrTableCell53.Name = "xrTableCell53";
            this.xrTableCell53.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell53.ParentStyleUsing.UseBorders = false;
            this.xrTableCell53.ParentStyleUsing.UseFont = false;
            this.xrTableCell53.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell54
            // 
            this.xrTableCell54.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell54.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C20V", "")});
            this.xrTableCell54.Dpi = 254F;
            this.xrTableCell54.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell54.Location = new System.Drawing.Point(1051, 0);
            this.xrTableCell54.Name = "xrTableCell54";
            this.xrTableCell54.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell54.ParentStyleUsing.UseBorders = false;
            this.xrTableCell54.ParentStyleUsing.UseFont = false;
            this.xrTableCell54.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell55
            // 
            this.xrTableCell55.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell55.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C21V", "")});
            this.xrTableCell55.Dpi = 254F;
            this.xrTableCell55.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell55.Location = new System.Drawing.Point(1101, 0);
            this.xrTableCell55.Name = "xrTableCell55";
            this.xrTableCell55.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell55.ParentStyleUsing.UseBorders = false;
            this.xrTableCell55.ParentStyleUsing.UseFont = false;
            this.xrTableCell55.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell56
            // 
            this.xrTableCell56.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell56.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C22V", "")});
            this.xrTableCell56.Dpi = 254F;
            this.xrTableCell56.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell56.Location = new System.Drawing.Point(1151, 0);
            this.xrTableCell56.Name = "xrTableCell56";
            this.xrTableCell56.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell56.ParentStyleUsing.UseBorders = false;
            this.xrTableCell56.ParentStyleUsing.UseFont = false;
            this.xrTableCell56.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell57
            // 
            this.xrTableCell57.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell57.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C23V", "")});
            this.xrTableCell57.Dpi = 254F;
            this.xrTableCell57.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell57.Location = new System.Drawing.Point(1201, 0);
            this.xrTableCell57.Name = "xrTableCell57";
            this.xrTableCell57.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell57.ParentStyleUsing.UseBorders = false;
            this.xrTableCell57.ParentStyleUsing.UseFont = false;
            this.xrTableCell57.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell58
            // 
            this.xrTableCell58.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell58.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C24V", "")});
            this.xrTableCell58.Dpi = 254F;
            this.xrTableCell58.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell58.Location = new System.Drawing.Point(1251, 0);
            this.xrTableCell58.Name = "xrTableCell58";
            this.xrTableCell58.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell58.ParentStyleUsing.UseBorders = false;
            this.xrTableCell58.ParentStyleUsing.UseFont = false;
            this.xrTableCell58.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell58.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell59
            // 
            this.xrTableCell59.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell59.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C25V", "")});
            this.xrTableCell59.Dpi = 254F;
            this.xrTableCell59.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell59.Location = new System.Drawing.Point(1301, 0);
            this.xrTableCell59.Name = "xrTableCell59";
            this.xrTableCell59.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell59.ParentStyleUsing.UseBorders = false;
            this.xrTableCell59.ParentStyleUsing.UseFont = false;
            this.xrTableCell59.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell59.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell60
            // 
            this.xrTableCell60.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell60.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C26V", "")});
            this.xrTableCell60.Dpi = 254F;
            this.xrTableCell60.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell60.Location = new System.Drawing.Point(1351, 0);
            this.xrTableCell60.Name = "xrTableCell60";
            this.xrTableCell60.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell60.ParentStyleUsing.UseBorders = false;
            this.xrTableCell60.ParentStyleUsing.UseFont = false;
            this.xrTableCell60.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell61
            // 
            this.xrTableCell61.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell61.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C27V", "")});
            this.xrTableCell61.Dpi = 254F;
            this.xrTableCell61.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell61.Location = new System.Drawing.Point(1401, 0);
            this.xrTableCell61.Name = "xrTableCell61";
            this.xrTableCell61.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell61.ParentStyleUsing.UseBorders = false;
            this.xrTableCell61.ParentStyleUsing.UseFont = false;
            this.xrTableCell61.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell61.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell62
            // 
            this.xrTableCell62.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell62.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C28V", "")});
            this.xrTableCell62.Dpi = 254F;
            this.xrTableCell62.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell62.Location = new System.Drawing.Point(1451, 0);
            this.xrTableCell62.Name = "xrTableCell62";
            this.xrTableCell62.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell62.ParentStyleUsing.UseBorders = false;
            this.xrTableCell62.ParentStyleUsing.UseFont = false;
            this.xrTableCell62.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell63
            // 
            this.xrTableCell63.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell63.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C29V", "")});
            this.xrTableCell63.Dpi = 254F;
            this.xrTableCell63.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell63.Location = new System.Drawing.Point(1501, 0);
            this.xrTableCell63.Name = "xrTableCell63";
            this.xrTableCell63.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell63.ParentStyleUsing.UseBorders = false;
            this.xrTableCell63.ParentStyleUsing.UseFont = false;
            this.xrTableCell63.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell63.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell64
            // 
            this.xrTableCell64.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell64.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C30V", "")});
            this.xrTableCell64.Dpi = 254F;
            this.xrTableCell64.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell64.Location = new System.Drawing.Point(1551, 0);
            this.xrTableCell64.Name = "xrTableCell64";
            this.xrTableCell64.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell64.ParentStyleUsing.UseBorders = false;
            this.xrTableCell64.ParentStyleUsing.UseFont = false;
            this.xrTableCell64.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell64.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell65
            // 
            this.xrTableCell65.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrTableCell65.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C31V", "")});
            this.xrTableCell65.Dpi = 254F;
            this.xrTableCell65.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell65.Location = new System.Drawing.Point(1601, 0);
            this.xrTableCell65.Name = "xrTableCell65";
            this.xrTableCell65.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell65.ParentStyleUsing.UseBorders = false;
            this.xrTableCell65.ParentStyleUsing.UseFont = false;
            this.xrTableCell65.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell65.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell66
            // 
            this.xrTableCell66.Dpi = 254F;
            this.xrTableCell66.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell66.Location = new System.Drawing.Point(1651, 0);
            this.xrTableCell66.Name = "xrTableCell66";
            this.xrTableCell66.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell66.ParentStyleUsing.UseBorders = false;
            this.xrTableCell66.ParentStyleUsing.UseFont = false;
            this.xrTableCell66.Size = new System.Drawing.Size(191, 60);
            this.xrTableCell66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.BackColor = System.Drawing.Color.White;
            this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell1.Dpi = 254F;
            this.xrTableCell1.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell1.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell1.ParentStyleUsing.UseBackColor = false;
            this.xrTableCell1.ParentStyleUsing.UseBorders = false;
            this.xrTableCell1.ParentStyleUsing.UseFont = false;
            this.xrTableCell1.Size = new System.Drawing.Size(101, 60);
            this.xrTableCell1.Text = "NM";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C01N", "")});
            this.xrTableCell2.Dpi = 254F;
            this.xrTableCell2.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell2.Location = new System.Drawing.Point(101, 0);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell2.ParentStyleUsing.UseBorders = false;
            this.xrTableCell2.ParentStyleUsing.UseFont = false;
            this.xrTableCell2.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C02N", "")});
            this.xrTableCell3.Dpi = 254F;
            this.xrTableCell3.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell3.Location = new System.Drawing.Point(151, 0);
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell3.ParentStyleUsing.UseBorders = false;
            this.xrTableCell3.ParentStyleUsing.UseFont = false;
            this.xrTableCell3.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C03N", "")});
            this.xrTableCell4.Dpi = 254F;
            this.xrTableCell4.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell4.Location = new System.Drawing.Point(201, 0);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell4.ParentStyleUsing.UseBorders = false;
            this.xrTableCell4.ParentStyleUsing.UseFont = false;
            this.xrTableCell4.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C04N", "")});
            this.xrTableCell5.Dpi = 254F;
            this.xrTableCell5.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell5.Location = new System.Drawing.Point(251, 0);
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell5.ParentStyleUsing.UseBorders = false;
            this.xrTableCell5.ParentStyleUsing.UseFont = false;
            this.xrTableCell5.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C05N", "")});
            this.xrTableCell6.Dpi = 254F;
            this.xrTableCell6.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell6.Location = new System.Drawing.Point(301, 0);
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell6.ParentStyleUsing.UseBorders = false;
            this.xrTableCell6.ParentStyleUsing.UseFont = false;
            this.xrTableCell6.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C06N", "")});
            this.xrTableCell7.Dpi = 254F;
            this.xrTableCell7.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell7.Location = new System.Drawing.Point(351, 0);
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell7.ParentStyleUsing.UseBorders = false;
            this.xrTableCell7.ParentStyleUsing.UseFont = false;
            this.xrTableCell7.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C07N", "")});
            this.xrTableCell8.Dpi = 254F;
            this.xrTableCell8.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell8.Location = new System.Drawing.Point(401, 0);
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell8.ParentStyleUsing.UseBorders = false;
            this.xrTableCell8.ParentStyleUsing.UseFont = false;
            this.xrTableCell8.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C08N", "")});
            this.xrTableCell9.Dpi = 254F;
            this.xrTableCell9.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell9.Location = new System.Drawing.Point(451, 0);
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell9.ParentStyleUsing.UseBorders = false;
            this.xrTableCell9.ParentStyleUsing.UseFont = false;
            this.xrTableCell9.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C09N", "")});
            this.xrTableCell10.Dpi = 254F;
            this.xrTableCell10.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell10.Location = new System.Drawing.Point(501, 0);
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell10.ParentStyleUsing.UseBorders = false;
            this.xrTableCell10.ParentStyleUsing.UseFont = false;
            this.xrTableCell10.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C10N", "")});
            this.xrTableCell11.Dpi = 254F;
            this.xrTableCell11.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell11.Location = new System.Drawing.Point(551, 0);
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell11.ParentStyleUsing.UseBorders = false;
            this.xrTableCell11.ParentStyleUsing.UseFont = false;
            this.xrTableCell11.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C11N", "")});
            this.xrTableCell12.Dpi = 254F;
            this.xrTableCell12.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell12.Location = new System.Drawing.Point(601, 0);
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell12.ParentStyleUsing.UseBorders = false;
            this.xrTableCell12.ParentStyleUsing.UseFont = false;
            this.xrTableCell12.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C12N", "")});
            this.xrTableCell13.Dpi = 254F;
            this.xrTableCell13.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell13.Location = new System.Drawing.Point(651, 0);
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell13.ParentStyleUsing.UseBorders = false;
            this.xrTableCell13.ParentStyleUsing.UseFont = false;
            this.xrTableCell13.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C13N", "")});
            this.xrTableCell14.Dpi = 254F;
            this.xrTableCell14.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell14.Location = new System.Drawing.Point(701, 0);
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell14.ParentStyleUsing.UseBorders = false;
            this.xrTableCell14.ParentStyleUsing.UseFont = false;
            this.xrTableCell14.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C14N", "")});
            this.xrTableCell15.Dpi = 254F;
            this.xrTableCell15.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell15.Location = new System.Drawing.Point(751, 0);
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell15.ParentStyleUsing.UseBorders = false;
            this.xrTableCell15.ParentStyleUsing.UseFont = false;
            this.xrTableCell15.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C15N", "")});
            this.xrTableCell16.Dpi = 254F;
            this.xrTableCell16.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell16.Location = new System.Drawing.Point(801, 0);
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell16.ParentStyleUsing.UseBorders = false;
            this.xrTableCell16.ParentStyleUsing.UseFont = false;
            this.xrTableCell16.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C16N", "")});
            this.xrTableCell17.Dpi = 254F;
            this.xrTableCell17.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell17.Location = new System.Drawing.Point(851, 0);
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell17.ParentStyleUsing.UseBorders = false;
            this.xrTableCell17.ParentStyleUsing.UseFont = false;
            this.xrTableCell17.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C17N", "")});
            this.xrTableCell18.Dpi = 254F;
            this.xrTableCell18.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell18.Location = new System.Drawing.Point(901, 0);
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell18.ParentStyleUsing.UseBorders = false;
            this.xrTableCell18.ParentStyleUsing.UseFont = false;
            this.xrTableCell18.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C18N", "")});
            this.xrTableCell19.Dpi = 254F;
            this.xrTableCell19.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell19.Location = new System.Drawing.Point(951, 0);
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell19.ParentStyleUsing.UseBorders = false;
            this.xrTableCell19.ParentStyleUsing.UseFont = false;
            this.xrTableCell19.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C19N", "")});
            this.xrTableCell20.Dpi = 254F;
            this.xrTableCell20.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell20.Location = new System.Drawing.Point(1001, 0);
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell20.ParentStyleUsing.UseBorders = false;
            this.xrTableCell20.ParentStyleUsing.UseFont = false;
            this.xrTableCell20.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell20.Text = "xrTableCell20";
            this.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C20N", "")});
            this.xrTableCell21.Dpi = 254F;
            this.xrTableCell21.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell21.Location = new System.Drawing.Point(1051, 0);
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell21.ParentStyleUsing.UseBorders = false;
            this.xrTableCell21.ParentStyleUsing.UseFont = false;
            this.xrTableCell21.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C21N", "")});
            this.xrTableCell22.Dpi = 254F;
            this.xrTableCell22.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell22.Location = new System.Drawing.Point(1101, 0);
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell22.ParentStyleUsing.UseBorders = false;
            this.xrTableCell22.ParentStyleUsing.UseFont = false;
            this.xrTableCell22.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C22N", "")});
            this.xrTableCell23.Dpi = 254F;
            this.xrTableCell23.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell23.Location = new System.Drawing.Point(1151, 0);
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell23.ParentStyleUsing.UseBorders = false;
            this.xrTableCell23.ParentStyleUsing.UseFont = false;
            this.xrTableCell23.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C23N", "")});
            this.xrTableCell24.Dpi = 254F;
            this.xrTableCell24.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell24.Location = new System.Drawing.Point(1201, 0);
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell24.ParentStyleUsing.UseBorders = false;
            this.xrTableCell24.ParentStyleUsing.UseFont = false;
            this.xrTableCell24.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C24N", "")});
            this.xrTableCell25.Dpi = 254F;
            this.xrTableCell25.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell25.Location = new System.Drawing.Point(1251, 0);
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell25.ParentStyleUsing.UseBorders = false;
            this.xrTableCell25.ParentStyleUsing.UseFont = false;
            this.xrTableCell25.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C25N", "")});
            this.xrTableCell26.Dpi = 254F;
            this.xrTableCell26.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell26.Location = new System.Drawing.Point(1301, 0);
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell26.ParentStyleUsing.UseBorders = false;
            this.xrTableCell26.ParentStyleUsing.UseFont = false;
            this.xrTableCell26.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C26N", "")});
            this.xrTableCell27.Dpi = 254F;
            this.xrTableCell27.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell27.Location = new System.Drawing.Point(1351, 0);
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell27.ParentStyleUsing.UseBorders = false;
            this.xrTableCell27.ParentStyleUsing.UseFont = false;
            this.xrTableCell27.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C27N", "")});
            this.xrTableCell28.Dpi = 254F;
            this.xrTableCell28.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell28.Location = new System.Drawing.Point(1401, 0);
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell28.ParentStyleUsing.UseBorders = false;
            this.xrTableCell28.ParentStyleUsing.UseFont = false;
            this.xrTableCell28.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C28N", "")});
            this.xrTableCell29.Dpi = 254F;
            this.xrTableCell29.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell29.Location = new System.Drawing.Point(1451, 0);
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell29.ParentStyleUsing.UseBorders = false;
            this.xrTableCell29.ParentStyleUsing.UseFont = false;
            this.xrTableCell29.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C29N", "")});
            this.xrTableCell30.Dpi = 254F;
            this.xrTableCell30.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell30.Location = new System.Drawing.Point(1501, 0);
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell30.ParentStyleUsing.UseBorders = false;
            this.xrTableCell30.ParentStyleUsing.UseFont = false;
            this.xrTableCell30.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C30N", "")});
            this.xrTableCell31.Dpi = 254F;
            this.xrTableCell31.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell31.Location = new System.Drawing.Point(1551, 0);
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell31.ParentStyleUsing.UseBorders = false;
            this.xrTableCell31.ParentStyleUsing.UseFont = false;
            this.xrTableCell31.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell32.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "C31N", "")});
            this.xrTableCell32.Dpi = 254F;
            this.xrTableCell32.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell32.Location = new System.Drawing.Point(1601, 0);
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell32.ParentStyleUsing.UseBorders = false;
            this.xrTableCell32.ParentStyleUsing.UseFont = false;
            this.xrTableCell32.Size = new System.Drawing.Size(50, 60);
            this.xrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.Dpi = 254F;
            this.xrTableCell33.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell33.Location = new System.Drawing.Point(1651, 0);
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell33.ParentStyleUsing.UseBorders = false;
            this.xrTableCell33.ParentStyleUsing.UseFont = false;
            this.xrTableCell33.Size = new System.Drawing.Size(191, 60);
            this.xrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
            this.Font = new System.Drawing.Font("Arial", 7F);
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.Name = "Report";
            this.PageHeight = 2969;
            this.PageWidth = 1901;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'DECLARE @Monat INT
DECLARE @Jahr INT
DECLARE @DatumVon DATETIME
DECLARE @DatumBis DATETIME

SELECT @Monat = Monat, @Jahr = Jahr, @DatumVon = DatumVon, @DatumBis = DatumBis
FROM  dbo.KaAmmBesch WITH (READUNCOMMITTED)
WHERE KaAmmBeschID = {KaAmmBeschID}

EXEC spKaGetPraesenzzeitAMM {BaPersonID}, @Monat, @Jahr, @DatumVon, @DatumBis' ,  null ,  N'KAAAMBescheinigung' , 3,  0 );


