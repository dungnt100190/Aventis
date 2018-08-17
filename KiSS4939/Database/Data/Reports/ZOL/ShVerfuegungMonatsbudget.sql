-- Insert Script for ShVerfuegungMonatsbudget
-- MD5:0XD17D262CC7F7B9839D8046914DA86AE9_0X0ADF4580439533DD6350CC8EA9813309_0X4C203CA8B940D148E66D9A9DFB712384
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'ShVerfuegungMonatsbudget') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('ShVerfuegungMonatsbudget', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'ShVerfuegungMonatsbudget';
--SQLCHECK_IGNORE--
UPDATE QRY
SET QueryName =  N'ShVerfuegungMonatsbudget' , UserText =  N'SH - Monatsbudgetverfügung' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\log4net.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\SharpLibrary.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Microsoft.Practices.Unity.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Ionic.Zip.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\PdfSharp.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\itextsharp.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Microsoft.Practices.Unity.Configuration.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\C1.C1Zip.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Kiss.BusinessLogic.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Kiss.DbContext.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\EntityFramework.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ComponentModel.DataAnnotations\v4.0_4.0.0.0__31bf3856ad364e35\System.ComponentModel.DataAnnotations.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.CSharp\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.CSharp.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Dynamic\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Dynamic.dll" />
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
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Kiss.DataAccess.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\HtmlAgilityPack.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Kiss.BL.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Kiss.Model.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\KiSS.Common.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Autofac.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Common.Logging.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\Kiss.Database.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\WPFLocalizeExtension.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\XAMLMarkupExtensions.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS4 Integration\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRRichTextBox xrRichTextBox2;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.Subreport ShVerfuegungMonatsbudget_EinAus;
        private DevExpress.XtraReports.UI.Subreport ShVerfuegungMonatsbudget_Personen;
        private DevExpress.XtraReports.UI.XRRichTextBox xrRichTextBox1;
        private DevExpress.XtraReports.UI.XRLabel txtFehlbetrag;
        private KiSS4.DB.SqlQuery sqlQuery1;
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
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAAFAAAAAgAAAIwBRGV2RXhwcmVzc" +
                        "y5YdHJhUmVwb3J0cy5VSS5TZXJpYWxpemFibGVTdHJpbmcsIERldkV4cHJlc3MuWHRyYVJlcG9ydHMud" +
                        "jYuMiwgVmVyc2lvbj02LjIuNi4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPTc5ODY4Y" +
                        "jgxNDdiNWVhZTRoU3lzdGVtLkRyYXdpbmcuQml0bWFwLCBTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj00L" +
                        "jAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2ETtE6kl" +
                        "b+7ulH+fwJOBiAa1iF9SCkAAACLAAAAAAAAAGAAAAC8AAAAuQIAACRyAHQAZgBIAGkAbgB3AGUAaQBzA" +
                        "C4AUgB0AGYAVABlAHgAdAAAAAAAMnMAcQBsAFEAdQBlAHIAeQAxAC4AUwBlAGwAZQBjAHQAUwB0AGEAd" +
                        "ABlAG0AZQBuAHQANwIAACZ4AHIAUABpAGMAdAB1AHIAZQBCAG8AeAAxAC4ASQBtAGEAZwBlAGkNAAAse" +
                        "AByAFIAaQBjAGgAVABlAHgAdABCAG8AeAAxAC4AUgB0AGYAVABlAHgAdABSGQIALHgAcgBSAGkAYwBoA" +
                        "FQAZQB4AHQAQgBvAHgAMgAuAFIAdABmAFQAZQB4AHQAohoCAEAAAQAAAP////8BAAAAAAAAAAwCAAAAG" +
                        "0RldkV4cHJlc3MuWHRyYVJlcG9ydHMudjYuMgUBAAAALERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuU" +
                        "2VyaWFsaXphYmxlU3RyaW5nAQAAAAVWYWx1ZQECAAAABgMAAAC7A3tccnRmMVxhbnNpXGFuc2ljcGcxM" +
                        "jUyXGRlZmYwXGRlZnRhYjcwOHtcZm9udHRibHtcZjBcZm5pbFxmY2hhcnNldDAgQXJpYWw7fX0NClx2a" +
                        "WV3a2luZDRcdWMxXHBhcmRcbGFuZzEwMzNcZnMxOCBEYXMgQnVkZ2V0IGlzdCBuYWNoIFJpY2h0bGlua" +
                        "WVuIGRlciBTY2h3ZWl6LiBLb25mZXJlbnogZlwnZmNyIFNvemlhbGhpbGZlIFNLT1MgYmVyZWNobmV0L" +
                        "iBFcyBnaWx0IGFscyBSYWhtZW5idWRnZXQuIEVpbm5haG1lbiB1bmQgQXVzZ2FiZW4ga1wnZjZubmVuI" +
                        "G1vbmF0bGljaCBcJ2U0bmRlcm4uIERpZSBCZXpcJ2ZjZ2VyaW5uZW4gdW5kIEJlelwnZmNnZXIgc2luZ" +
                        "CB2ZXJwZmxpY2h0ZXQsIFwnYzRuZGVydW5nZW4gZGVyIGZpbmFuemllbGxlbiBTaXR1YXRpb24gdW5hd" +
                        "WZnZWZvcmRlcnQgdW5kIHVtZ2VoZW5kIGRlbiBTb3ppYWxkaWVuc3RlbiB6dSBtZWxkZW4uXHBhcg0Kf" +
                        "Q0KCwGvFi0tIFBhcmFtZXRlcg0KREVDTEFSRSBAR2V0RGF0ZSBkYXRldGltZSAgU0VUIEBHZXREYXRlI" +
                        "D0gR2V0RGF0ZSgpDQoNCkRFQ0xBUkUgQFRvdEluIG1vbmV5DQpERUNMQVJFIEBUb3RPdXQgbW9uZXkNC" +
                        "g0KDQpTRUxFQ1QgQFRvdEluID0gU1VNKEJldHJhZykNCkZST00gZGJvLmZuV2hHZXRGaW5hbnpwbGFuS" +
                        "W5kZW50KG51bGwsIEBHZXREYXRlLCAwKSAgVE1QDQogIElOTkVSIEpPSU4gWExPVkNvZGUgIFhQQyBPT" +
                        "iBYUEMuTE9WTmFtZSA9ICdCZ0thdGVnb3JpZScgQU5EIFhQQy5Db2RlID0gVE1QLkJnS2F0ZWdvcmllQ" +
                        "29kZQ0KV0hFUkUgQmdLYXRlZ29yaWVDb2RlID0gMQ0KDQoNClNFTEVDVCBAVG90T3V0ID0gU1VNKEJld" +
                        "HJhZykNCkZST00gZGJvLmZuV2hHZXRGaW5hbnpwbGFuSW5kZW50KG51bGwsIEBHZXREYXRlLCAwKSAgV" +
                        "E1QDQogIElOTkVSIEpPSU4gWExPVkNvZGUgIFhQQyBPTiBYUEMuTE9WTmFtZSA9ICdCZ0thdGVnb3JpZ" +
                        "ScgQU5EIFhQQy5Db2RlID0gVE1QLkJnS2F0ZWdvcmllQ29kZQ0KV0hFUkUgQmdLYXRlZ29yaWVDb2RlI" +
                        "D0gMg0KDQoNCkRFQ0xBUkUgQEJlbWVya3VuZyAgdmFyY2hhcig4MDAwKSwNCiAgICAgICAgQEl0ZW1UZ" +
                        "Xh0ICAgdmFyY2hhcig4MDAwKQ0KDQpERUNMQVJFIGNCZW1lcmt1bmcgQ1VSU09SIEZBU1RfRk9SV0FSR" +
                        "CBGT1INCiAgU0VMRUNUICctICcgKyBYTEMuVGV4dCArICcgKCcgKyBQUlMuTmFtZSArIElzTnVsbCgnL" +
                        "CAnICsgUFJTLlZvcm5hbWUsICcnKSArICcpOiAnICsgQ09OVkVSVCh2YXJjaGFyKDgwMDApLCBCUE8uQ" +
                        "mVtZXJrdW5nKQ0KICBGUk9NIEJnUG9zaXRpb24gICAgICAgICAgICAgIEJQTw0KICAgIElOTkVSIEpPS" +
                        "U4gQmFQZXJzb24gICAgICAgIFBSUyBPTiBQUlMuQmFQZXJzb25JRCA9IEJQTy5CYVBlcnNvbklEDQogI" +
                        "CAgSU5ORVIgSk9JTiBXaFBvc2l0aW9uc2FydCAgU1BUIE9OIFNQVC5CZ1Bvc2l0aW9uc2FydElEID0gQ" +
                        "lBPLkJnUG9zaXRpb25zYXJ0SUQNCiAgICBJTk5FUiBKT0lOIFhMT1ZDb2RlICAgICAgICBYTEMgT04gW" +
                        "ExDLkxPVk5hbWUgPSAnQmdHcnVwcGUnIEFORCBYTEMuQ29kZSA9IFNQVC5CZ0dydXBwZUNvZGUNCiAgV" +
                        "0hFUkUgQlBPLkJnQnVkZ2V0SUQgPSBudWxsDQogICAgQU5EIFNQVC5CZ1Bvc2l0aW9uc2FydENvZGUgQ" +
                        "kVUV0VFTiAzOTAwMCBBTkQgMzk5OTkNCiAgICBBTkQgTk9UIChCUE8uQmVtZXJrdW5nIElTIE5VTEwgT" +
                        "1IgQlBPLkJlbWVya3VuZyBMSUtFICcnKQ0KICAgIEFORCBHZXREYXRlKCkgQkVUV0VFTiBJc051bGwoQ" +
                        "lBPLkRhdHVtVm9uLCAnMTkwMDAxMDEnKSBBTkQgSXNOdWxsKEJQTy5EYXR1bUJpcywgR2V0RGF0ZSgpK" +
                        "Q0KICBPUkRFUiBCWSBQUlMuTmFtZSwgUFJTLlZvcm5hbWUNCg0KT1BFTiBjQmVtZXJrdW5nDQpXSElMR" +
                        "SAoMSA9IDEpIEJFR0lODQogIEZFVENIIE5FWFQgRlJPTSBjQmVtZXJrdW5nIElOVE8gQEl0ZW1UZXh0D" +
                        "QogIElGIEBARkVUQ0hfU1RBVFVTICE9IDAgQlJFQUsNCg0KICBTRVQgQEJlbWVya3VuZyA9IElzTnVsb" +
                        "ChAQmVtZXJrdW5nICsgQ0hBUigxMCkgKyBDSEFSKDEzKSwgJycpICsgQEl0ZW1UZXh0DQpFTkQNCkNMT" +
                        "1NFIGNCZW1lcmt1bmcNCkRFQUxMT0NBVEUgY0JlbWVya3VuZw0KDQoNClNFTEVDVCBCQkcuQmdCdWRnZ" +
                        "XRJRCwNCiAgICAgICBUaXRsZSAgICAgICAgPSAnVmVyZsO8Z3VuZzogU296aWFsaGlsZmUgJyArIGRib" +
                        "y5mblhNb25hdEphaHIoZGJvLmZuRGF0ZVNlcmlhbChCQkcuSmFociwgQkJHLk1vbmF0LCAxKSksDQogI" +
                        "CAgICAgQWRyZXNzZSAgICAgID0gaXNudWxsKGNhc2UgUFJTLkdlc2NobGVjaHRDb2RlIHdoZW4gMSB0a" +
                        "GVuICdIZXJyJyB3aGVuIDIgdGhlbiAnRnJhdScgZW5kICsgY2hhcigxMykgKyBjaGFyKDEwKSwnJykgK" +
                        "w0KICAgICAgICAgICAgICAgICAgICAgIFBSUy5Wb3JuYW1lTmFtZSArIGNoYXIoMTMpICsgY2hhcigxM" +
                        "CkgKw0KICAgICAgICAgICAgICAgICAgICAgIGlzbnVsbChQUlMuV29obnNpdHpTdHJhc3NlSGF1c05yL" +
                        "CAnJykgKyBjaGFyKDEzKSArIGNoYXIoMTApICsNCiAgICAgICAgICAgICAgICAgICAgICBpc251bGwoU" +
                        "FJTLldvaG5zaXR6UExaT3J0LCAnJyksDQogICAgICAgRGF0dW1GaW5hbnpwbGFuID0gKFNFTEVDVCBNQ" +
                        "VgoRGF0dW0pDQogICAgICAgICAgICAgICAgICAgICAgICAgIEZST00gQmdCZXdpbGxpZ3VuZyBCQlcNC" +
                        "iAgICAgICAgICAgICAgICAgICAgICAgICAgV0hFUkUgQkJXLkJnRmluYW56cGxhbklEID0gU0ZQLkJnR" +
                        "mluYW56cGxhbklEIGFuZCBCQlcuQmdCZXdpbGxpZ3VuZ0NvZGUgPSAyKSwNCiAgICAgICBCZW1lcmt1b" +
                        "mcgPSBJc051bGwoQ09OVkVSVCh2YXJjaGFyKDgwMDApLCBTRlAuQmVtZXJrdW5nKSArIENIQVIoMTApI" +
                        "CsgQ0hBUigxMyksICcnKSArIElzTnVsbChAQmVtZXJrdW5nLCAnJyksDQogICAgICAgVG90SW4gICAgI" +
                        "CAgID0gQFRvdEluLA0KICAgICAgIFRvdE91dCAgICAgICA9IEBUb3RPdXQsDQogICAgICAgRmVobGJld" +
                        "HJhZyAgID0gaXNOdWxsKEBUb3RPdXQsMCkgLSBpc051bGwoQFRvdEluLDApDQpGUk9NICAgQmdCdWRnZ" +
                        "XQgQkJHDQogICAgICAgaW5uZXIgam9pbiBCZ0ZpbmFuenBsYW4gIFNGUCBvbiBTRlAuQmdGaW5hbnpwb" +
                        "GFuSUQgPSBCQkcuQmdGaW5hbnpwbGFuSUQNCiAgICAgICBpbm5lciBqb2luIEZhTGVpc3R1bmcgICAgR" +
                        "kFMIG9uIEZBTC5GYUxlaXN0dW5nSUQgPSBTRlAuRmFMZWlzdHVuZ0lEDQogICAgICAgaW5uZXIgam9pb" +
                        "iB2d1BlcnNvbiAgICAgIFBSUyBvbiBQUlMuQmFQZXJzb25JRCA9IEZBTC5CYVBlcnNvbklEDQpXSEVSR" +
                        "SBGQUwuTW9kdWxJRCA9IDMNCiAgQU5EIEJCRy5NYXN0ZXJCdWRnZXQgPSAwIEFORCBCQkcuQmdCZXdpb" +
                        "GxpZ3VuZ1N0YXR1c0NvZGUgPSA1DQogIEFORCBCQkcuQmdCdWRnZXRJRCA9IG51bGxBAAEAAAD/////A" +
                        "QAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj00LjAuMC4wLCBDdWx0dXJlPW5ldXRyY" +
                        "WwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtY" +
                        "XABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAARgsCAAJCTUYLAgAAAAAANgQAACgAAAC3AQAALgEAAAEAC" +
                        "AAAAAAAAAAAAFo3AABaNwAAAAEAAAABAAAAAAD/AQEB/wICAv8DAwP/BAQE/wUFBf8GBgb/BwcH/wgIC" +
                        "P8JCQn/CgoK/wsLC/8MDAz/DQ0N/w4ODv8PDw//EBAQ/xEREf8SEhL/ExMT/xQUFP8VFRX/FhYW/xcXF" +
                        "/8YGBj/GRkZ/xoaGv8bGxv/HBwc/x0dHf8eHh7/Hx8f/yAgIP8hISH/IiIi/yMjI/8kJCT/JSUl/yYmJ" +
                        "v8nJyf/KCgo/ykpKf8qKir/Kysr/ywsLP8tLS3/Li4u/y8vL/8wMDD/MTEx/zIyMv8zMzP/NDQ0/zU1N" +
                        "f82Njb/Nzc3/zg4OP85OTn/Ojo6/zs7O/88PDz/PT09/z4+Pv8/Pz//QEBA/0FBQf9CQkL/Q0ND/0RER" +
                        "P9FRUX/RkZG/0dHR/9ISEj/SUlJ/0pKSv9LS0v/TExM/01NTf9OTk7/T09P/1BQUP9RUVH/UlJS/1NTU" +
                        "/9UVFT/VVVV/1ZWVv9XV1f/WFhY/1lZWf9aWlr/W1tb/1xcXP9dXV3/Xl5e/19fX/9gYGD/YWFh/2JiY" +
                        "v9jY2P/ZGRk/2VlZf9mZmb/Z2dn/2hoaP9paWn/ampq/2tra/9sbGz/bW1t/25ubv9vb2//cHBw/3Fxc" +
                        "f9ycnL/c3Nz/3R0dP91dXX/dnZ2/3d3d/94eHj/eXl5/3p6ev97e3v/fHx8/319ff9+fn7/f39//4CAg" +
                        "P+BgYH/goKC/4ODg/+EhIT/hYWF/4aGhv+Hh4f/iIiI/4mJif+Kior/i4uL/4yMjP+NjY3/jo6O/4+Pj" +
                        "/+QkJD/kZGR/5KSkv+Tk5P/lJSU/5WVlf+Wlpb/l5eX/5iYmP+ZmZn/mpqa/5ubm/+cnJz/nZ2d/56en" +
                        "v+fn5//oKCg/6Ghof+ioqL/o6Oj/6SkpP+lpaX/pqam/6enp/+oqKj/qamp/6qqqv+rq6v/rKys/62tr" +
                        "f+urq7/r6+v/7CwsP+xsbH/srKy/7Ozs/+0tLT/tbW1/7a2tv+3t7f/uLi4/7m5uf+6urr/u7u7/7y8v" +
                        "P+9vb3/vr6+/7+/v//AwMD/wcHB/8LCwv/Dw8P/xMTE/8XFxf/Gxsb/x8fH/8jIyP/Jycn/ysrK/8vLy" +
                        "//MzMz/zc3N/87Ozv/Pz8//0NDQ/9HR0f/S0tL/09PT/9TU1P/V1dX/1tbW/9fX1//Y2Nj/2dnZ/9ra2" +
                        "v/b29v/3Nzc/93d3f/e3t7/39/f/+Dg4P/h4eH/4uLi/+Pj4//k5OT/5eXl/+bm5v/n5+f/6Ojo/+np6" +
                        "f/q6ur/6+vr/+zs7P/t7e3/7u7u/+/v7//w8PD/8fHx//Ly8v/z8/P/9PT0//X19f/29vb/9/f3//j4+" +
                        "P/5+fn/+vr6//v7+//8/Pz//f39//7+/v///////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////77cukfmxeUUc4LCQdGA8PDw+H/" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////9dWkZ" +
                        "zcRBAAAAAAAAAAAAAAAAAAAAH3//////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////7bjVgjCAAAAAAAAAAAAAAAAAAAAAAAAAAAf////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////9sB/QAwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB//" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////31YQlAQAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAH///////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////9Z4TikHAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAf////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////+7tiDgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB//" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////8Zg3AAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAH///////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////KssA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAf////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////9qA6AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB//" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////5ZQwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAH///////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////5XgTAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAf////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////+JIcAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB9/" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////9c3AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAFCA4PD4f//////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////+nIQAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAMI0Bce5mtus7V6/Dw9////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////WUQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAUOLVuJu+T1/v///////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////eUw8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEgX42qz" +
                        "On4/////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////xisAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAABhlv/X//////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "4oJAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAElup7f///////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////+NQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAG3nl/////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////jKQAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAABQZ3t/////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////uToAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAfW77+/////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////8V4AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA7p/L//////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////+A+AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAApn" +
                        "/3//////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////////////VKgAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAU+P//////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////+TcAAAAAAAAAAAAAAAAAAAAAAAAAAAAAM7T//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////9BTAAAAAAAAAAAAAAAAAAAAAAAAAAAANpD2/////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////////+kDQAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAABHb2/////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////pAYAAAAAAAAAAAAAAAAAAAAAAAAAADG//////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////68GAAAAAAAAAAAAAAAAAAAAAAAAAABt7f///////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////4KQAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAJpv///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////91oAAAAAAAAAAAAAAAAAAAAAAAAADZ3//////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////9c+AAAAAAAAAAAAAAAAAAAAAAAAAHPW/////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////nLQAAAAAAAAAAAAAAAAAAA" +
                        "AAAAA6h/////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///9EMAAAAAAAAAAAAAAAAAAAAAAAAOvv///////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////97AAAAAAAAAAAAAAAAAAAAAAAAAJX//////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////5RcAAAAAAAAAAAAAAAAAAAAAA" +
                        "AST/////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "+NFAAAAAAAAAAAAAAAAAAAAAAAnrP///////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////uLwAAAAAAAAAAAAAAAAAAAAAAROn//////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////1wAAAAAAAAAAAAAAAAAAAAAACLu/" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////////////////////+ZA" +
                        "AAAAAAAAAAAAAAAAAAAAAADr////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////1REAAAAAAAAAAAAAAAAAAAAAAI3//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////o+AAAAAAAAAAAAAAAAAAAAAAB8/////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////ngAAA" +
                        "AAAAAAAAAAAAAAAAAAJof///////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////+oiAAAAAAAAAAAAAAAAAAAAAJr//////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////YwAAAAAAAAAAAAAAAAAAAABn/////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////70CAAAAA" +
                        "AAAAAAAAAAAAAAABtb//////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////5MAAAAAAAAAAAAAAAAAAAAACA/////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////3kAAAAAAAAAAAAAAAAAAAAAYvr//////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////////////+pAAAAAAAAA" +
                        "AAAAAAAAAAAAFj//////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////9ywAAAAAAAAAAAAAAAAAAAAi6v///////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////BAAAAAAAAAAAAAAAAAAAAAq///////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////34AAAAAAAAAA" +
                        "AAAAAAAAABb/////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////XGAAAAAAAAAAAAAAAAAAABMf//////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////kYAAAAAAAAAAAAAAAAAAABv/////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////////++AAAAAAAAAAAAA" +
                        "AAAAAAAH+r//////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////1IAAAAAAAAAAAAAAAAAAACd/////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////MBAAAAAAAAAAAAAAAAAAAN/v//////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////2MAAAAAAAAAAAAAA" +
                        "AAAAAC6/////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////BCAAAAAAAAAAAAAAAAAAAdv///////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////1UAAAAAAAAAAAAAAAAAACLz/////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////ZCgAAAAAAAAAAAAAAA" +
                        "AAAgP///////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////4cAAAAAAAAAAAAAAAAAAAC5/////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////VQAAAAAAAAAAAAAAAAAAEez//////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////YmAAAAAAAAAAAAAAAAA" +
                        "AB9/////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////twAAAAAAAAAAAAAAAAAAIfX//////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////9iAAAAAAAAAAAAAAAAAAB5/////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////8RcAAAAAAAAAAAAAAAAAB" +
                        "tX//////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////+2AAAAAAAAAAAAAAAAAABM/////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////2YAAAAAAAAAAAAAAAAAAKP//////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////qFwAAAAAAAAAAAAAAAAAw9" +
                        "f///////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////6cAAAAAAAAAAAAAAAAAAIX//////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////aQAAAAAAAAAAAAAAAAAF0f///////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////orAAAAAAAAAAAAAAAAADL8/" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///1AUAAAAAAAAAAAAAAAAAeP///////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////+KAAAAAAAAAAAAAAAAAAbQ/////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////1AAAAAAAAAAAAAAAAAAIfn//" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//1HQAAAAAAAAAAAAAAAABA/v///////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////9EEAAAAAAAAAAAAAAAAAFz//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////pQAAAAAAAAAAAAAAAAAAdP///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/94AAAAAAAAAAAAAAAAAACk/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////14AAAAAAAAAAAAAAAAACuL//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////TAAAAAAAAAAAAAAAAAAt+////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/06AAAAAAAAAAAAAAAAAFb//////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////+CoAAAAAAAAAAAAAAAAAev///////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////1HAAAAAAAAAAAAAAAAACY/////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "90AAAAAAAAAAAAAAAAAAML//////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////4mdjY2NjY2NjY2NjY2No5////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A////////9PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8" +
                        "PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8v/////////////////////////////////59PLw8PDx9" +
                        "Pb7/////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////9fDw8PDw8PDw8PDw8PD3/////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////////////////9+PTy8" +
                        "PDw8fP2/f///////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////349PLw8PDw8/b6/////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD///////9SDw8PD" +
                        "w8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw84+P///////////////" +
                        "//////////nlW9WQzAeFg8PDxMeJzVHZYfH+f////////////////////////////+4f39/f39/f39/f" +
                        "39/f7H////////////7lX9/f39/f39/f39/f5X7//////////////tCDw8PDw8PDw8PDw8PD4f//////" +
                        "/////////eHf39/f39/f39/f39/o///////////////////////mn9/f39/f39/f39/f39/gu7//////" +
                        "///////////////2JdvVDsrHxYPDw8THSU7TmiHx///////////////////////////////////uH9/f" +
                        "39/f39/f39/f3+x//////////////////////////////////////zRk29POysfGA8PDxAcJTRDUWmHz" +
                        "fb//////////////////9t/f39/f39/f39/f39/o///////////////////////o39/f39/f39/f39/f" +
                        "47/////////AP///////0QAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAACf4///////////////////////FaR0AAAAAAAAAAAAAAAAAAAAAAAMvf9///////////////" +
                        "////////////2cAAAAAAAAAAAAAAAAAWP////////////gdAAAAAAAAAAAAAAAAHfj/////////////+" +
                        "CcAAAAAAAAAAAAAAAAAff//////////////7wAAAAAAAAAAAAAAAAA6/////////////////////9AAA" +
                        "AAAAAAAAAAAAAAAAAAp9///////////////////vkQJAAAAAAAAAAAAAAAAAAAAAAADS634/////////" +
                        "/////////////////////9nAAAAAAAAAAAAAAAAAFj///////////////////////////////////OOO" +
                        "QYAAAAAAAAAAAAAAAAAAAAAAAAFJGep8v//////////////sgAAAAAAAAAAAAAAAAA6/////////////" +
                        "/////////86AAAAAAAAAAAAAAAADv////////8A////////RwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAK/j///////////////////+/SwMAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAHqD+////////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAA" +
                        "Ef////////////////////9RQAAAAAAAAAAAAAAAAAAAKn/////////////////xFQBAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAADCf/f///////////////////////////3EAAAAAAAAAAAAAAAAAY////////////" +
                        "/////////////////////+rNQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAokeT///////////+3AAAAA" +
                        "AAAAAAAAAAAAEf//////////////////////0cAAAAAAAAAAAAAAAAe/////////wD///////9HAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAr+P///////////////" +
                        "///kwMAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEHK//////////////////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH///////" +
                        "/////////APAAAAAAAAAAAAAAAAR////////////////////6AAAAAAAAAAAAAAAAAAAABc/////////" +
                        "///////52YCAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA+zf//////////////////////////cQAAA" +
                        "AAAAAAAAAAAAABj///////////////////////////////GRAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAEnn8/////////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAA" +
                        "B7/////////AP///////0cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAACv4////////////////6WQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA2O/v///////" +
                        "////////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+" +
                        "CwAAAAAAAAAAAAAAAAAf///////////////8A8AAAAAAAAAAAAAAABH///////////////////nHAAAA" +
                        "AAAAAAAAAAAAAAAJuv//////////////78mAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAez////" +
                        "/////////////////////9xAAAAAAAAAAAAAAAAAGP/////////////////////////////gwgAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAOP7/////////twAAAAAAAAAAAAAAAABH/////////////" +
                        "/////////9HAAAAAAAAAAAAAAAAHv////////8A////////RwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAK/j//////////////5IiAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAABQ+P//////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAA" +
                        "Ef/////////////////7zsAAAAAAAAAAAAAAAAAACjY//////////////+YDwAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAOcfD//////////////////////3EAAAAAAAAAAAAAAAAAY////////////" +
                        "///////////////4VEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABV//////////+3AAAAA" +
                        "AAAAAAAAAAAAEf//////////////////////0cAAAAAAAAAAAAAAAAe/////////wD///////9HAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAr+P////////////+AA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABa+f////////////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH///////" +
                        "/////////APAAAAAAAAAAAAAAAAR/////////////////90AAAAAAAAAAAAAAAAAAAHwv///////////" +
                        "///jAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAT/j/////////////////////cQAAA" +
                        "AAAAAAAAAAAAABj/////////////////////////+EvAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAGP//////////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAA" +
                        "B7/////////AP///////0cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAACv4////////////oQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABp/////" +
                        "////////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+" +
                        "CwAAAAAAAAAAAAAAAAAf///////////////8A8AAAAAAAAAAAAAAABH////////////////ywcAAAAAA" +
                        "AAAAAAAAAAAAIL//////////////54AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAZ" +
                        "f////////////////////9xAAAAAAAAAAAAAAAAAGP////////////////////////qMAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAcf//////////twAAAAAAAAAAAAAAAABH/////////////" +
                        "/////////9HAAAAAAAAAAAAAAAAHv////////8A////////RwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAK/j///////////0tAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAACc////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAA" +
                        "Ef///////////////9eAAAAAAAAAAAAAAAAAAAj9//////////////ICwAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAnv///////////////////3EAAAAAAAAAAAAAAAAAY////////////" +
                        "///////////+UcAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB///////////+3AAAAA" +
                        "AAAAAAAAAAAAEf//////////////////////0cAAAAAAAAAAAAAAAAe/////////wD///////9HAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAr+P//////////mQAAA" +
                        "AAAAAAAAAAAAAAAAAAACR4uKxIAAAAAAAAAAAAAAAAAAAAAABDZ//////////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH///////" +
                        "/////////APAAAAAAAAAAAAAAAAR///////////////8RkAAAAAAAAAAAAAAAAAAH7/////////////8" +
                        "i8AAAAAAAAAAAAAAAAAAAAAAAgeLicOAAAAAAAAAAAAAAAAAAAAAAA0////////////////////cQAAA" +
                        "AAAAAAAAAAAAABj//////////////////////95AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAIr//////////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAA" +
                        "B7/////////AP///////0cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAACf4/////////8wUAAAAAAAAAAAAAAAAAAACRpfY9Pn46KhqLwAAAAAAAAAAAAAAAAAAAEDu/" +
                        "////////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+" +
                        "CwAAAAAAAAAAAAAAAAAf///////////////8A8AAAAAAAAAAAAAAABH//////////////xnAAAAAAAAA" +
                        "AAAAAAAAABH7v////////////9/AAAAAAAAAAAAAAAAAAAAHF2W1fT59ueraxoAAAAAAAAAAAAAAAAAA" +
                        "AKi//////////////////9xAAAAAAAAAAAAAAAAAGP/////////////////////sAQAAAAAAAAAAAAAA" +
                        "AAAAAAoS2d8oLi4t7mqlX9tWTwTAAAAAAAAnv//////////twAAAAAAAAAAAAAAAABH/////////////" +
                        "/////////9HAAAAAAAAAAAAAAAAHv////////8A////////RwAAAAAAAAAAAAAAAAAAAAAAEBAPDw8PD" +
                        "w8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8POPj////////3LAAAAAAAAAAAAAAAAAAAHbf//////////" +
                        "//5jwQAAAAAAAAAAAAAAAAAAID/////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAA" +
                        "Ef/////////////jAAAAAAAAAAAAAAAAAAANvX/////////////9BwAAAAAAAAAAAAAAAAAAC3m/////" +
                        "///////2z4AAAAAAAAAAAAAAAAAAAzV/////////////////3EAAAAAAAAAAAAAAAAAY////////////" +
                        "/////////4yAAAAAAAAAAAAAAAAAAAjtvf//////////////////eupUQUAAACy//////////+3AAAAA" +
                        "AAAAAAAAAAAAEf//////////////////////0cAAAAAAAAAAAAAAAAe/////////wD///////9DAAAAA" +
                        "AAAAAAAAAAAAAAAAACF8/Dw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDw8PDy/////////54AAAAAA" +
                        "AAAAAAAAAAAABHO////////////////VAAAAAAAAAAAAAAAAAAAPv////////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH///////" +
                        "/////////APAAAAAAAAAAAAAAAAR////////////9kQAAAAAAAAAAAAAAAAAAzN//////////////+oA" +
                        "AAAAAAAAAAAAAAAAAAPwf//////////////7zoAAAAAAAAAAAAAAAAAAGv/////////////////cQAAA" +
                        "AAAAAAAAAAAAABj////////////////////xwQAAAAAAAAAAAAAAAAAXeb//////////////////////" +
                        "///zk8AALn//////////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAA" +
                        "B7/////////AP///////1wAAAAAAAAAAAAAAAAAAAAAABzs/////////////////////////////////" +
                        "//////////////////7NgAAAAAAAAAAAAAAAAABqP/////////////////XEQAAAAAAAAAAAAAAAAAQ5" +
                        "////////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+" +
                        "CwAAAAAAAAAAAAAAAAAf///////////////8A8AAAAAAAAAAAAAAABH////////////TwAAAAAAAAAAA" +
                        "AAAAAAAkf///////////////DsAAAAAAAAAAAAAAAAAAKL/////////////////3BYAAAAAAAAAAAAAA" +
                        "AAAEeb///////////////9xAAAAAAAAAAAAAAAAAGP///////////////////9TAAAAAAAAAAAAAAAAA" +
                        "HP/////////////////////////////+nMGyf//////////twAAAAAAAAAAAAAAAABH/////////////" +
                        "/////////9HAAAAAAAAAAAAAAAAHv////////8A////////0QcAAAAAAAAAAAAAAAAAAAAAAG3//////" +
                        "////////////////////////////////////////////8EAAAAAAAAAAAAAAAAAAFn//////////////" +
                        "/////+OAAAAAAAAAAAAAAAAAACW////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAA" +
                        "Ef//////////6gAAAAAAAAAAAAAAAAAAEz9///////////////IAgAAAAAAAAAAAAAAAABQ/////////" +
                        "///////////mAAAAAAAAAAAAAAAAAAAk////////////////3EAAAAAAAAAAAAAAAAAY////////////" +
                        "///////0AMAAAAAAAAAAAAAAABn/////////////////////////////////7zi//////////+3AAAAA" +
                        "AAAAAAAAAAAAEf//////////////////////0cAAAAAAAAAAAAAAAAe/////////wD/////////bwAAA" +
                        "AAAAAAAAAAAAAAAAAAACM//////////////////////////////////////////////////aAAAAAAAA" +
                        "AAAAAAAAAAI0/////////////////////grAAAAAAAAAAAAAAAAAEH+//////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH///////" +
                        "/////////APAAAAAAAAAAAAAAAAR//////////tIgAAAAAAAAAAAAAAAAAN3P///////////////3AAA" +
                        "AAAAAAAAAAAAAAABdL////////////////////4LAAAAAAAAAAAAAAAAAA6/f//////////////cQAAA" +
                        "AAAAAAAAAAAAABj//////////////////9zAAAAAAAAAAAAAAAAMfT//////////////////////////" +
                        "////////////////////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAA" +
                        "B7/////////AP/////////yQwAAAAAAAAAAAAAAAAAAAAAAUP///////////////////////////////" +
                        "////////////////+ITAAAAAAAAAAAAAAAAAEX//////////////////////6wAAAAAAAAAAAAAAAAAB" +
                        "MT//////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+" +
                        "CwAAAAAAAAAAAAAAAAAf///////////////8A8AAAAAAAAAAAAAAABH////////9kYAAAAAAAAAAAAAA" +
                        "AAAAIf////////////////pFwAAAAAAAAAAAAAAAABw//////////////////////+zAwAAAAAAAAAAA" +
                        "AAAAAK///////////////9xAAAAAAAAAAAAAAAAAGP/////////////////3BEAAAAAAAAAAAAAAA7S/" +
                        "///////////////////////////////////////////////twAAAAAAAAAAAAAAAABH/////////////" +
                        "/////////9HAAAAAAAAAAAAAAAAHv////////8A///////////SCAAAAAAAAAAAAAAAAAAAAAAM3f///" +
                        "///////////////////////////////////////////oQAAAAAAAAAAAAAAAAAAdf///////////////" +
                        "///////+ycAAAAAAAAAAAAAAAAAfv//////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAA" +
                        "Ef///////+7AAAAAAAAAAAAAAAAAABB+f///////////////6oAAAAAAAAAAAAAAAAABdT//////////" +
                        "/////////////keAAAAAAAAAAAAAAAAAHf//////////////3EAAAAAAAAAAAAAAAAAY////////////" +
                        "/////+UAAAAAAAAAAAAAAAAPP////////////////////////////////////////////////+3AAAAA" +
                        "AAAAAAAAAAAAEf//////////////////////0cAAAAAAAAAAAAAAAAe/////////wD///////////9tA" +
                        "AAAAAAAAAAAAAAAAAAAAABh//////////////////////////////////////////////91AAAAAAAAA" +
                        "AAAAAAAAACw////////////////////////agAAAAAAAAAAAAAAAABG/v////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH///////" +
                        "/////////APAAAAAAAAAAAAAAAAR////////10AAAAAAAAAAAAAAAAAFNn/////////////////cQAAA" +
                        "AAAAAAAAAAAAAA0/P///////////////////////kAAAAAAAAAAAAAAAAAAP/7/////////////cQAAA" +
                        "AAAAAAAAAAAAABj/////////////////1IAAAAAAAAAAAAAAABk/////////////////////////////" +
                        "////////////////////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAA" +
                        "B7/////////AP///////////+cXAAAAAAAAAAAAAAAAAAAAAATF/////////////////////////////" +
                        "////////////////1wAAAAAAAAAAAAAAAAAD+f///////////////////////+kAAAAAAAAAAAAAAAAA" +
                        "BXv/////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+" +
                        "CwAAAAAAAAAAAAAAAAAf///////////////8A8AAAAAAAAAAAAAAABH//////+9AwAAAAAAAAAAAAAAA" +
                        "ACg//////////////////0/AAAAAAAAAAAAAAAAAHL/////////////////////////XAAAAAAAAAAAA" +
                        "AAAAAAQ6v////////////9xAAAAAAAAAAAAAAAAAGP////////////////0GQAAAAAAAAAAAAAAAI3//" +
                        "///////////////////////////////////////////////twAAAAAAAAAAAAAAAABH/////////////" +
                        "/////////9HAAAAAAAAAAAAAAAAHv////////8A/////////////4wAAAAAAAAAAAAAAAAAAAAAAET//" +
                        "///////////////////////////////////////////RgAAAAAAAAAAAAAAAAA8/v///////////////" +
                        "////////9gGAAAAAAAAAAAAAAAAA8r/////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAA" +
                        "Ef/////+TAAAAAAAAAAAAAAAAAAWP//////////////////8hUAAAAAAAAAAAAAAAAApv///////////" +
                        "/////////////92AAAAAAAAAAAAAAAAAALC/////////////3EAAAAAAAAAAAAAAAAAY////////////" +
                        "////8cCAAAAAAAAAAAAAAABwf////////////////////////////////////////////////+3AAAAA" +
                        "AAAAAAAAAAAAEf//////////////////////0cAAAAAAAAAAAAAAAAe/////////wD/////////////9" +
                        "CQAAAAAAAAAAAAAAAAAAAAAAJX///////////////////////////////////////////kwAAAAAAAAA" +
                        "AAAAAAAAG//////////////////////////+CUAAAAAAAAAAAAAAAAAnv////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH///////" +
                        "/////////APAAAAAAAAAAAAAAAAR/////1wAAAAAAAAAAAAAAAAADvq///////////////////JAwAAA" +
                        "AAAAAAAAAAAAAfW/////////////////////////5wAAAAAAAAAAAAAAAAAAJX/////////////cQAAA" +
                        "AAAAAAAAAAAAABj////////////////lAAAAAAAAAAAAAAAABLo/////////////////////////////" +
                        "////////////////////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAA" +
                        "B7/////////AP//////////////hwAAAAAAAAAAAAAAAAAAAAAAB8n//////////////////////////" +
                        "///////////////9BsAAAAAAAAAAAAAAAAAoP//////////////////////////VAAAAAAAAAAAAAAAA" +
                        "ABy/////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+" +
                        "CwAAAAAAAAAAAAAAAAAf///////////////8A8AAAAAAAAAAAAAAABH////kwAAAAAAAAAAAAAAAAAo7" +
                        "P///////////////////58AAAAAAAAAAAAAAAAAGvX/////////////////////////zAUAAAAAAAAAA" +
                        "AAAAAAAdP////////////9xAAAAAAAAAAAAAAAAAGP///////////////9lAAAAAAAAAAAAAAAAMfv//" +
                        "///////////////////////////////////////////////twAAAAAAAAAAAAAAAABH/////////////" +
                        "/////////9HAAAAAAAAAAAAAAAAHv////////8A///////////////sIAAAAAAAAAAAAAAAAAAAAAAAR" +
                        "f7////////////////////////////////////////uDwAAAAAAAAAAAAAAAAG7/////////////////" +
                        "/////////9yAAAAAAAAAAAAAAAAAFb/////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAA" +
                        "Ef//+AVAAAAAAAAAAAAAAAAAKL/////////////////////hAAAAAAAAAAAAAAAAAAq+P///////////" +
                        "//////////////pDAAAAAAAAAAAAAAAAABp/////////////3EAAAAAAAAAAAAAAAAAY////////////" +
                        "////0YAAAAAAAAAAAAAAABG//////////////////////////////////////////////////+3AAAAA" +
                        "AAAAAAAAAAAAEf//////////////////////0cAAAAAAAAAAAAAAAAe/////////wD//////////////" +
                        "/+cAAAAAAAAAAAAAAAAAAAAAAAAr////////////////////////////////////////9cIAAAAAAAAA" +
                        "AAAAAAAB9L//////////////////////////4kAAAAAAAAAAAAAAAAARP////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH///////" +
                        "/////////APAAAAAAAAAAAAAAAAR///WwAAAAAAAAAAAAAAAAAd7v////////////////////9tAAAAA" +
                        "AAAAAAAAAAAADX7//////////////////////////YhAAAAAAAAAAAAAAAAAF3/////////////cQAAA" +
                        "AAAAAAAAAAAAABj///////////////5LgAAAAAAAAAAAAAAAEz//////////////////////////////" +
                        "////////////////////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAA" +
                        "B7/////////AP////////////////g1AAAAAAAAAAAAAAAAAAAAAABT/////////////////////////" +
                        "///////////////xAMAAAAAAAAAAAAAAAAM6P//////////////////////////mgAAAAAAAAAAAAAAA" +
                        "AAv+f///////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+" +
                        "CwAAAAAAAAAAAAAAAAAf///////////////8A8AAAAAAAAAAAAAAABH/9kDAAAAAAAAAAAAAAAAAK7//" +
                        "////////////////////2AAAAAAAAAAAAAAAAAAPv3/////////////////////////+S8AAAAAAAAAA" +
                        "AAAAAAAVv////////////9xAAAAAAAAAAAAAAAAAGP///////////////MaAAAAAAAAAAAAAAAAQLq4t" +
                        "7e3t7e3t7e3t7e3t7e3t7e3t7e3t7e3t7e3t7ez2///////twAAAAAAAAAAAAAAAABH/////////////" +
                        "/////////9HAAAAAAAAAAAAAAAAHv////////8A/////////////////8MQAAAAAAAAAAAAAAAAAAAAA" +
                        "BTY//////////////////////////////////////+3AAAAAAAAAAAAAAAAABHy/////////////////" +
                        "/////////+oAAAAAAAAAAAAAAAAACX2////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAA" +
                        "Ej/cgAAAAAAAAAAAAAAAAB9////////////////////////SQAAAAAAAAAAAAAAAABH/////////////" +
                        "//////////////+QwAAAAAAAAAAAAAAAABO/////////////3EAAAAAAAAAAAAAAAAAY////////////" +
                        "///8Q4AAAAAAAAAAAAAAAABAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB+//////+3AAAAA" +
                        "AAAAAAAAAAAAEf//////////////////////0cAAAAAAAAAAAAAAAAe/////////wD//////////////" +
                        "////5YAAAAAAAAAAAAAAAAAAAAAAD38/////////////////////////////////////60AAAAAAAAAA" +
                        "AAAAAAAKvj//////////////////////////7kAAAAAAAAAAAAAAAAAD/D///////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH///////" +
                        "/////////APAAAAAAAAAAAAAAAAV6gBAAAAAAAAAAAAAAAAc/////////////////////////9HAAAAA" +
                        "AAAAAAAAAAAAEj///////////////////////////9IAAAAAAAAAAAAAAAAAEb/////////////cQAAA" +
                        "AAAAAAAAAAAAABj///////////////oDQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAH7//////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAA" +
                        "B7/////////AP//////////////////+TUAAAAAAAAAAAAAAAAAAAAAAKH//////////////////////" +
                        "///////////////mwAAAAAAAAAAAAAAAAAt+P//////////////////////////twAAAAAAAAAAAAAAA" +
                        "AAP8P///////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+" +
                        "CwAAAAAAAAAAAAAAAAAf///////////////8A8AAAAAAAAAAAAAAAAkHwAAAAAAAAAAAAAAADb0/////" +
                        "////////////////////0cAAAAAAAAAAAAAAAAAVP///////////////////////////0cAAAAAAAAAA" +
                        "AAAAAAAR/////////////9xAAAAAAAAAAAAAAAAAGP//////////////9IHAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAf///////twAAAAAAAAAAAAAAAABH/////////////" +
                        "/////////9HAAAAAAAAAAAAAAAAHv////////8A////////////////////tgIAAAAAAAAAAAAAAAAAA" +
                        "AAAJPH///////////////////////////////////+cAAAAAAAAAAAAAAAAACz4/////////////////" +
                        "/////////+3AAAAAAAAAAAAAAAAAA/w////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAANzf//////////////////////////RwAAAAAAAAAAAAAAAABV/////////////" +
                        "///////////////RwAAAAAAAAAAAAAAAABH/////////////3EAAAAAAAAAAAAAAAAAY////////////" +
                        "///5AwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB///////+3AAAAA" +
                        "AAAAAAAAAAAAEf//////////////////////0cAAAAAAAAAAAAAAAAe/////////wD//////////////" +
                        "//////9LgAAAAAAAAAAAAAAAAAAAAAAf////////////////////////////////////5sAAAAAAAAAA" +
                        "AAAAAAALfj//////////////////////////7cAAAAAAAAAAAAAAAAAD/D///////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH///////" +
                        "/////////APAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHz///////////////////////////9HAAAAA" +
                        "AAAAAAAAAAAAFT///////////////////////////9HAAAAAAAAAAAAAAAAAEf/////////////cQAAA" +
                        "AAAAAAAAAAAAABj///////////////yDwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAH7//////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAA" +
                        "B7/////////AP////////////////////93AAAAAAAAAAAAAAAAAAAAAAAO2////////////////////" +
                        "///////////////rAAAAAAAAAAAAAAAAAAq+P//////////////////////////uQAAAAAAAAAAAAAAA" +
                        "AAQ8P///////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+" +
                        "CwAAAAAAAAAAAAAAAAAf///////////////8A8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR3P///////" +
                        "////////////////////0YAAAAAAAAAAAAAAAAASP///////////////////////////0gAAAAAAAAAA" +
                        "AAAAAAARv////////////9xAAAAAAAAAAAAAAAAAGP///////////////AQAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAhv//////twAAAAAAAAAAAAAAAABH/////////////" +
                        "/////////9HAAAAAAAAAAAAAAAAHv////////8A/////////////////////+s5AAAAAAAAAAAAAAAAA" +
                        "AAAAAA48v////////////////////////////////+3AAAAAAAAAAAAAAAAABHy/////////////////" +
                        "/////////+pAAAAAAAAAAAAAAAAACb2////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAACDq////////////////////////////TAAAAAAAAAAAAAAAAABH/////////////" +
                        "//////////////+QwAAAAAAAAAAAAAAAABP/////////////3EAAAAAAAAAAAAAAAAAY////////////" +
                        "///9ycAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACP//////+3AAAAA" +
                        "AAAAAAAAAAAAEf//////////////////////0cAAAAAAAAAAAAAAAAe/////////wD//////////////" +
                        "////////8YDAAAAAAAAAAAAAAAAAAAAAACD/////////////////////////////////8cEAAAAAAAAA" +
                        "AAAAAAAC+X//////////////////////////5oAAAAAAAAAAAAAAAAANPr///////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH///////" +
                        "/////////APAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIj///////////////////////////9gAAAAA" +
                        "AAAAAAAAAAAAD79//////////////////////////kvAAAAAAAAAAAAAAAAAFb/////////////cQAAA" +
                        "AAAAAAAAAAAAABj///////////////+QAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAJf//////7cAAAAAAAAAAAAAAAAAR///////////////////////RwAAAAAAAAAAAAAAA" +
                        "B7/////////AP///////////////////////10AAAAAAAAAAAAAAAAAAAAAABXp/////////////////" +
                        "///////////////3AkAAAAAAAAAAAAAAAAG0f//////////////////////////hgAAAAAAAAAAAAAAA" +
                        "ABI/////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+" +
                        "CwAAAAAAAAAAAAAAAAAf///////////////8A8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAEc3//////" +
                        "////////////////////3AAAAAAAAAAAAAAAAAANfv/////////////////////////9R0AAAAAAAAAA" +
                        "AAAAAAAYP////////////9xAAAAAAAAAAAAAAAAAGP///////////////9cAAAAAAAAAAAAAAAAOJ2cn" +
                        "JycnJycnJycnJycnJycnJwrAAAAAAAAAAAAAAAAn///////twAAAAAAAAAAAAAAAABH/////////////" +
                        "/////////9IAAAAAAAAAAAAAAAAHv////////8A////////////////////////2w4AAAAAAAAAAAAAA" +
                        "AAAAAAAAKz////////////////////////////////xEQAAAAAAAAAAAAAAAAC3/////////////////" +
                        "/////////9yAAAAAAAAAAAAAAAAAF7/////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAA" +
                        "DY6AAAAAAAAAAAAAAAAK+7/////////////////////////iwAAAAAAAAAAAAAAAAAo9////////////" +
                        "//////////////pCwAAAAAAAAAAAAAAAABp/////////////3EAAAAAAAAAAAAAAAAAY////////////" +
                        "////3kAAAAAAAAAAAAAAABO/////////////////////////0wAAAAAAAAAAAAAAACr//////+3AAAAA" +
                        "AAAAAAAAAAAAEf//////////////////////UAAAAAAAAAAAAAAAAAe/////////wD//////////////" +
                        "///////////fwAAAAAAAAAAAAAAAAAAAAAAVf////////////////////////////////QfAAAAAAAAA" +
                        "AAAAAAAAJ7//////////////////////////1UAAAAAAAAAAAAAAAAAd/////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH///////" +
                        "/////////APAAAAAAAAAAAAAAAAUtkTAAAAAAAAAAAAAAAAVv////////////////////////+lAAAAA" +
                        "AAAAAAAAAAAABr2/////////////////////////8sEAAAAAAAAAAAAAAAAAHf/////////////cQAAA" +
                        "AAAAAAAAAAAAABj////////////////oAAAAAAAAAAAAAAAAEf////////////////////////9QAAAA" +
                        "AAAAAAAAAAAALj//////7cAAAAAAAAAAAAAAAAARv/////////////////////4LAAAAAAAAAAAAAAAA" +
                        "B7/////////AP/////////////////////////xNwAAAAAAAAAAAAAAAAAAAAACpP///////////////" +
                        "///////////////+jIAAAAAAAAAAAAAAAAAdP/////////////////////////5KgAAAAAAAAAAAAAAA" +
                        "ACh/////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+" +
                        "CwAAAAAAAAAAAAAAAAAf///////////////8A8AAAAAAAAAAAAAAABH/5sAAAAAAAAAAAAAAAAAdPf//" +
                        "////////////////////8sDAAAAAAAAAAAAAAAACd//////////////////////////pAAAAAAAAAAAA" +
                        "AAAAAAAl/////////////9xAAAAAAAAAAAAAAAAAGP////////////////NBQAAAAAAAAAAAAAALfr//" +
                        "/////////////////////gpAAAAAAAAAAAAAAAEyv//////twAAAAAAAAAAAAAAAAA2+////////////" +
                        "/////////grAAAAAAAAAAAAAAAAHv////////8A///////////////////////////aDwAAAAAAAAAAA" +
                        "AAAAAAAAAAM1P//////////////////////////////TAAAAAAAAAAAAAAAAAA4/f///////////////" +
                        "////////9UGAAAAAAAAAAAAAAAABtf/////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAA" +
                        "Ef//UoAAAAAAAAAAAAAAAAAZv//////////////////////9yEAAAAAAAAAAAAAAAAApP///////////" +
                        "/////////////92AAAAAAAAAAAAAAAAAAPO/////////////3EAAAAAAAAAAAAAAAAAY////////////" +
                        "/////wxAAAAAAAAAAAAAAAL4///////////////////////7Q8AAAAAAAAAAAAAAArl//////+3AAAAA" +
                        "AAAAAAAAAAAACD3////////////////////8xQAAAAAAAAAAAAAAAAe/////////wD//////////////" +
                        "/////////////9yAAAAAAAAAAAAAAAAAAAAAABW//////////////////////////////9iAAAAAAAAA" +
                        "AAAAAAAAAvm////////////////////////owAAAAAAAAAAAAAAAAAg9v////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH///////" +
                        "/////////APAAAAAAAAAAAAAAAAR///4RkAAAAAAAAAAAAAAAAAyf//////////////////////UQAAA" +
                        "AAAAAAAAAAAAABu/////////////////////////1wAAAAAAAAAAAAAAAAAHPT/////////////cQAAA" +
                        "AAAAAAAAAAAAABj/////////////////2oAAAAAAAAAAAAAAAG6///////////////////////OBQAAA" +
                        "AAAAAAAAAAAIPb//////7cAAAAAAAAAAAAAAAAACuP////////////////////fCQAAAAAAAAAAAAAAA" +
                        "B7/////////AP///////////////////////////8AAAAAAAAAAAAAAAAAAAAAAAAK+/////////////" +
                        "////////////////4IAAAAAAAAAAAAAAAAAAKb///////////////////////9nAAAAAAAAAAAAAAAAA" +
                        "FT//////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+" +
                        "CwAAAAAAAAAAAAAAAAAf///////////////8A8AAAAAAAAAAAAAAABH////sQIAAAAAAAAAAAAAAABS/" +
                        "/////////////////////+GAAAAAAAAAAAAAAAAAC78///////////////////////+PQAAAAAAAAAAA" +
                        "AAAAABO//////////////9xAAAAAAAAAAAAAAAAAGP/////////////////pwAAAAAAAAAAAAAAAIn//" +
                        "////////////////////6oAAAAAAAAAAAAAAABR////////twAAAAAAAAAAAAAAAAAAp////////////" +
                        "////////74BAAAAAAAAAAAAAAAAH/////////8A////////////////////////////9ywAAAAAAAAAA" +
                        "AAAAAAAAAAAADr7////////////////////////////uQAAAAAAAAAAAAAAAAAAb////////////////" +
                        "///////9B8AAAAAAAAAAAAAAAAAkP//////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAA" +
                        "Ef/////dQAAAAAAAAAAAAAAAACK/////////////////////8EAAAAAAAAAAAAAAAAABM7//////////" +
                        "/////////////YbAAAAAAAAAAAAAAAAAIr//////////////3EAAAAAAAAAAAAAAAAAY////////////" +
                        "//////oEQAAAAAAAAAAAAAAZf//////////////////////eQAAAAAAAAAAAAAAAIb///////+3AAAAA" +
                        "AAAAAAAAAAAAABb////////////////////jwAAAAAAAAAAAAAAAAAp/////////wD//////////////" +
                        "///////////////rwAAAAAAAAAAAAAAAAAAAAAAAJv////////////////////////////wFwAAAAAAA" +
                        "AAAAAAAAABH//////////////////////+yAAAAAAAAAAAAAAAAAATS//////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH///////" +
                        "/////////APAAAAAAAAAAAAAAAAR//////3PgAAAAAAAAAAAAAAAAa2////////////////////9h4AA" +
                        "AAAAAAAAAAAAAAAdv//////////////////////ugIAAAAAAAAAAAAAAAACzv//////////////cQAAA" +
                        "AAAAAAAAAAAAABj//////////////////9UAAAAAAAAAAAAAABA//////////////////////8+AAAAA" +
                        "AAAAAAAAAAAwf///////7cAAAAAAAAAAAAAAAAAAA/f//////////////////9QAAAAAAAAAAAAAAAAA" +
                        "DL/////////AP//////////////////////////////eAAAAAAAAAAAAAAAAAAAAAAAE93//////////" +
                        "/////////////////9+AAAAAAAAAAAAAAAAAAzN////////////////////8S8AAAAAAAAAAAAAAAAAU" +
                        "v7//////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+" +
                        "CwAAAAAAAAAAAAAAAAAf///////////////8A8AAAAAAAAAAAAAAABH///////oQgAAAAAAAAAAAAAAA" +
                        "A+k////////////////////hwAAAAAAAAAAAAAAAAAQyv////////////////////IxAAAAAAAAAAAAA" +
                        "AAAAE/9//////////////9xAAAAAAAAAAAAAAAAAGP//////////////////8gFAAAAAAAAAAAAAAvM/" +
                        "///////////////////uQQAAAAAAAAAAAAAADj4////////twAAAAAAAAAAAAAAAAAAAEH0/////////" +
                        "///////wQkAAAAAAAAAAAAAAAAARv////////8A///////////////////////////////2KgAAAAAAA" +
                        "AAAAAAAAAAAAAAAl////////////////////////////+ALAAAAAAAAAAAAAAAAAEf//////////////" +
                        "/////97AAAAAAAAAAAAAAAAAAG7////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAA" +
                        "Ef///////+/AAAAAAAAAAAAAAAAAAnF///////////////////kEAAAAAAAAAAAAAAAAABA/v///////" +
                        "///////////hQAAAAAAAAAAAAAAAAAAtf///////////////3EAAAAAAAAAAAAAAAAAY////////////" +
                        "////////0wAAAAAAAAAAAAAAFL///////////////////5EAAAAAAAAAAAAAAAAjv////////+3AAAAA" +
                        "AAAAAAAAAAAAAAAAGf///////////////9eAAAAAAAAAAAAAAAAAABa/////////wD//////////////" +
                        "/////////////////+pAAAAAAAAAAAAAAAAAAAAAAAw9////////////////////////////1oAAAAAA" +
                        "AAAAAAAAAAAAJP/////////////////yAkAAAAAAAAAAAAAAAAAIff///////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH///////" +
                        "/////////APAAAAAAAAAAAAAAAAR/////////pJAAAAAAAAAAAAAAAAACXl//////////////////9lA" +
                        "AAAAAAAAAAAAAAAAACM/////////////////8wMAAAAAAAAAAAAAAAAACz5////////////////cQAAA" +
                        "AAAAAAAAAAAAABj////////////////////uQMAAAAAAAAAAAAAAq7/////////////////tgEAAAAAA" +
                        "AAAAAAAAAve/////////7cAAAAAAAAAAAAAAAAAAAAAAG/5////////////2hQAAAAAAAAAAAAAAAAAA" +
                        "G3/////////AP////////////////////////////////5FAAAAAAAAAAAAAAAAAAAAAACS/////////" +
                        "///////////////////xwMAAAAAAAAAAAAAAAAAB7T///////////////9FAAAAAAAAAAAAAAAAAABS/" +
                        "////////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+" +
                        "CwAAAAAAAAAAAAAAAAAf///////////////8A8AAAAAAAAAAAAAAABH/////////94ZAAAAAAAAAAAAA" +
                        "AAAAGj//////////////////9IIAAAAAAAAAAAAAAAAAAav///////////////fKQAAAAAAAAAAAAAAA" +
                        "AAAnf////////////////9yAAAAAAAAAAAAAAAAAGT////////////////////7KQAAAAAAAAAAAAAAG" +
                        "dn///////////////9KAAAAAAAAAAAAAAAAV///////////twAAAAAAAAAAAAAAAAAAAAAAAEDW/////" +
                        "////rMiAAAAAAAAAAAAAAAAAAAAjf////////8A/////////////////////////////////8kGAAAAA" +
                        "AAAAAAAAAAAAAAAABjq////////////////////////////VgAAAAAAAAAAAAAAAAAACZb//////////" +
                        "//1bwAAAAAAAAAAAAAAAAAAAKP/////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAA" +
                        "Ef//////////7EAAAAAAAAAAAAAAAAAEt///////////////////zQAAAAAAAAAAAAAAAAAAB3X/////" +
                        "///////zCcAAAAAAAAAAAAAAAAAACn3/////vj4+Pj4+Pj4+G4AAAAAAAAAAAAAAAAAYPj4+Pj4+Pj4+" +
                        "Pj+//////9jAAAAAAAAAAAAAAAALNT/////////////owUAAAAAAAAAAAAAAADH//////////+3AAAAA" +
                        "AAAAAAAAAAAAAAAAAAAABFgkrS6rodAAAAAAAAAAAAAAAAAAAAAAAHK/////////wD//////////////" +
                        "////////////////////2oAAAAAAAAAAAAAAAAAAAAAAGL8///////////////////////////aIgAAA" +
                        "AAAAAAAAAAAAAAAAFSvz+Xw7tq6kzMAAAAAAAAAAAAAAAAAAABU+/////////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH///////" +
                        "/////////APAAAAAAAAAAAAAAAAR////////////4YEAAAAAAAAAAAAAAAAPd//////////////////l" +
                        "AAAAAAAAAAAAAAAAAAAABZ3sM7m8OnXvJIbAAAAAAAAAAAAAAAAAAAItf/////aMSosLCwsLCwtEwAAA" +
                        "AAAAAAAAAAAAAARLCwsLCwsLCwqOPL//////9AdAAAAAAAAAAAAAAAAG47a/P/////svnEDAAAAAAAAA" +
                        "AAAAAAAY////////////7cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAO" +
                        "Pr/////////AP//////////////////////////////////1gMAAAAAAAAAAAAAAAAAAAAAAJf//////" +
                        "//////////////////////NCgAAAAAAAAAAAAAAAAAAAAAGDA8PCQAAAAAAAAAAAAAAAAAAAAAAOvb//" +
                        "////////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+" +
                        "CwAAAAAAAAAAAAAAAAAf///////////////8A8AAAAAAAAAAAAAAABH/////////////4kAAAAAAAAAA" +
                        "AAAAAAAKef/////////////////bQAAAAAAAAAAAAAAAAAAAAAABQ0PDggAAAAAAAAAAAAAAAAAAAAAA" +
                        "Fb//////9IAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAI8P///////8YIAAAAAAAAAAAAA" +
                        "AAAAAk5Zn96SRQBAAAAAAAAAAAAAAAAAC/2////////////uQAAAAAAAAAAAAAAAA8zAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAACo//////////8A///////////////////////////////////+UAAAA" +
                        "AAAAAAAAAAAAAAAAAAAGun///////////////////////////9TAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAABbW////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAA" +
                        "Ef//////////////U4AAAAAAAAAAAAAAAAATv3////////////////zNwAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAPzv//////0wcAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "A/w/////////44AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAGwP////////////+pAAAAA" +
                        "AAAAAAAAAAAJpsAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAK/f//////////wD//////////////" +
                        "//////////////////////TCAAAAAAAAAAAAAAAAAAAAAAAdP///////////////////////////9YeA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAGtf////////////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH///////" +
                        "/////////APAAAAAAAAAAAAAAAAR///////////////4xMAAAAAAAAAAAAAAAAAgP///////////////" +
                        "//dHgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABq3////////TBwAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAD/D//////////2UAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAEP//////////////5oAAAAAAAAAAAAAAAAw5yAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACe/" +
                        "///////////AP////////////////////////////////////9zAAAAAAAAAAAAAAAAAAAAAAAL1P///" +
                        "////////////////////////9AeAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAKT//////" +
                        "////////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+" +
                        "CwAAAAAAAAAAAAAAAAAf///////////////8A8AAAAAAAAAAAAAAABH////////////////ZAAAAAAAA" +
                        "AAAAAAAAAAFuP/////////////////QHgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAWk/" +
                        "////////9MHAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP8P//////////+E8AAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAQw///////////////nAAAAAAAAAAAAAAAACz/rgAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAPfj///////////8A/////////////////////////////////////+otA" +
                        "AAAAAAAAAAAAAAAAAAAAABj/////////////////////////////9FJAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAA+A////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAA" +
                        "Ef////////////////dNAAAAAAAAAAAAAAAAAA08v/////////////////QLgAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAxrP//////////0wcAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "A/w////////////71sAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAANL////////////////+bAAAAA" +
                        "AAAAAAAAAAAPv//jwwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACvV/////////////wD//////////////" +
                        "////////////////////////88IAAAAAAAAAAAAAAAAAAAAAA7f/////////////////////////////" +
                        "/+xIQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABA0/////////////////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////////gsAAAAAAAAAAAAAAAAAH///////" +
                        "/////////APAAAAAAAAAAAAAAAAR//////////////////rJwAAAAAAAAAAAAAAAABR/f///////////" +
                        "//////tZwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAU/b////////////TBwAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAD/D//////////////3wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "G/1/////////////////4UAAAAAAAAAAAAAAABQ////uxYAAAAAAAAAAAAAAAAAAAAAAAAAAAAf6P///" +
                        "///////////AP///////////////////////////////////////20AAAAAAAAAAAAAAAAAAAAAAGn//" +
                        "//////////////////////////////ULwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAZj/v//////////" +
                        "////////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+" +
                        "CwAAAAAAAAAAAAAAAAAf///////////////8A8AAAAAAAAAAAAAAABH///////////////////ECAAAA" +
                        "AAAAAAAAAAAAACA////////////////////sTEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAFYj4/////" +
                        "////////9MHAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAP8P///////////////7crAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAyk////////////////////fQAAAAAAAAAAAAAAAGL/////0C0AAAAAA" +
                        "AAAAAAAAAAAAAAAAAAADa////////////////8A////////////////////////////////////////5" +
                        "xoAAAAAAAAAAAAAAAAAAAAAB83////////////////////////////////ykC0AAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAABUN//////////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////4LAAAAAAAAAAAAAAAAAB////////////////wDwAAAAAAAAAAAAAAA" +
                        "Ef///////////////////+KAAAAAAAAAAAAAAAAAASy////////////////////954rAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAFnHc////////////////0wYAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "A7w/////////////////+1/EgAAAAAAAAAAAAAAAAAAAAAAAAA7u/////////////////////9oAAAAA" +
                        "AAAAAAAAAAAbv//////6zwAAAAAAAAAAAAAAAAAAAAAAD3H/////////////////wD//////////////" +
                        "///////////////////////////ggAAAAAAAAAAAAAAAAAAAAAASP///////////////////////////" +
                        "///////9qpMBQAAAAAAAAAAAAAAAAAAAAAgaL7///////////////////////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////////gqAAAAAAAAAAAAAAAAAH7//////" +
                        "/////////APAAAAAAAAAAAAAAAAR/////////////////////1OAAAAAAAAAAAAAAAAAA3P/////////" +
                        "////////////+qCLwYAAAAAAAAAAAAAAAAAAAAAIYjl///////////////////RAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAABu/////////////////////UUgwAAAAAAAAAAAAAAAAAAAxSrv3//" +
                        "////////////////////0oAAAAAAAAAAAAAAAB7////////8oIgAAAAAAAAAAAAAAAAADSd+v///////" +
                        "///////////AP/////////////////////////////////////////LAAAAAAAAAAAAAAAAAAAAAAAAr" +
                        "P/////////////////////////////////////OjV8zDwoHBQMDBggMFTp7vPL//////////////////" +
                        "////////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////+" +
                        "C4CAwMDAwMDAwMDAwMCgP//////////////8A8AAAAAAAAAAAAAAABH/////////////////////+mcm" +
                        "5ycnJycnJycnJyckcb////////////////////////50ZNbIA4JBwUCBAcIDCBSf7ny/////////////" +
                        "////////+6empycnJycnJ1FAAAAAAAAAAAAAAAAADydnJycnJycnJqi+f//////////////////////3" +
                        "5deJwwHBQMDBgkNIE2W4P//////////////////////////tpicnJycnJycnJycls3///////////CmY" +
                        "BsKBwQDBggNIFek+v////////////////////8A/////////////////////////////////////////" +
                        "/1rAAAAAAAAAAAAAAAAAAAAAAAX1f////////////////////////////////////////rs3NPMxMbQ1" +
                        "+Tx/P//////////////////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////90MTFxcXFxcXFxcXFxcPi///////////////wDwAAAAAAAAAAAAAAA" +
                        "Ef////////////////////////////////////////////////////////////////////////06dvUz" +
                        "MTJ09fk9P///////////////////////////////////////3cAAAAAAAAAAAAAAAAAaf///////////" +
                        "//////////////////////////////25dTOxcbR2uj0/////////////////////////////////////" +
                        "///////////////////////////8d7TycXP1+f0/////////////////////////wD//////////////" +
                        "////////////////////////////+8gAAAAAAAAAAAAAAAAAAAAAABM/////////////////////////" +
                        "/////////////////////////////////////////////////////////////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4/////////////////////////////////////////" +
                        "/////////APAAAAAAAAAAAAAAAAR////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////cQAAA" +
                        "AAAAAAAAAAAAABj/////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////50AAAAAAAAAAAAAAAAAAAAAA" +
                        "ACz/////////////////////////////////////////////////////////////////////////////" +
                        "////////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj//////////////" +
                        "///////////////////////////////////8A8AAAAAAAAAAAAAAABH/////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////9xAAAAAAAAAAAAAAAAAGP//////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "///+zoAAAAAAAAAAAAAAAAAAAAAAFT//////////////////////////////////////////////////" +
                        "///////////////////////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////////////45eHh6vr////////////////////wDwAAAAAAAAAAAAAAA" +
                        "Ef//////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////3EAAAAAAAAAAAAAAAAAY////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "///////////////////////////////vgAAAAAAAAAAAAAAAAAAAAAAGPH//////////////////////" +
                        "/////////////////////////////////////////////////////////////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////////////jVtJuUk5OVnbrp/////////" +
                        "/////////APAAAAAAAAAAAAAAAAR////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////cQAAA" +
                        "AAAAAAAAAAAAABj/////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP//////////////////////////////////////////////agAAAAAAAAAAAAAAAAAAA" +
                        "AAAcv///////////////////////////////////////////////////////////////////////////" +
                        "////////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj//////////////" +
                        "/3To5OTk5OTk5OTk5W63/7/////////////8A8AAAAAAAAAAAAAAABH/////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////9xAAAAAAAAAAAAAAAAAGP//////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "//////4NgAAAAAAAAAAAAAAAAAAAAAApv///////////////////////////////////////////////" +
                        "///////////////////////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////////4sZOTk5OTk5OTk5OTk5OTtPf////////////wDwAAAAAAAAAAAAAAA" +
                        "Ef//////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////3EAAAAAAAAAAAAAAAAAY////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "/////////////////////////////////+5AwAAAAAAAAAAAAAAAAAAAAAm8////////////////////" +
                        "/////////////////////////////////////////////////////////////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4////////////+rCTk5OTk5OTk5OTk5OTk5OTvf///" +
                        "/////////APAAAAAAAAAAAAAAAAR////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////cQAAA" +
                        "AAAAAAAAAAAAABj/////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP////////////////////////////////////////////////0xAAAAAAAAAAAAAAAAA" +
                        "AAAAACH/////////////////////////////////////////////////////////////////////////" +
                        "////////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj///////////+/k" +
                        "5OTk5OTk5OTk5OTk5OTk5OX7v//////////8A8AAAAAAAAAAAAAAABH/////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////9xAAAAAAAAAAAAAAAAAGP//////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////3cAAAAAAAAAAAAAAAAAAAAAABXh/////////////////////////////////////////////" +
                        "///////////////////////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P//////////4ZOTk5OTk5OTk5OTk5OTk5OTk5Oy///////////wDwAAAAAAAAAAAAAAA" +
                        "Ef//////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////3EAAAAAAAAAAAAAAAAAZf///////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "///////////////////////////////////3hIAAAAAAAAAAAAAAAAAAAAAAGT//////////////////" +
                        "/////////////////////////////////////////////////////////////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4//////////2qk5OTk5OTk5OTk5OTk5OTk5OTk5Ph/" +
                        "/////////APAAAAAAAAAAAAAAAAR////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////cQAAA" +
                        "AAAAAAAAAAAAABd/////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP//////////////////////////////////////////////////vw0AAAAAAAAAAAAAA" +
                        "AAAAAAAA5///////////////////////////////////////////////////////////////////////" +
                        "////////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////2ZOTk" +
                        "5OTk5OTk5OTk5OTk5OTk5OTk6v9////////8A8AAAAAAAAAAAAAAABH/////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////9xAAAAAAAAAAAAAAAAAB/v/////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////7eYnJycnJycnJycnJycnJycnJycnJycn" +
                        "JycnJycnJyjLAAAAAAAAAAAAAAAAAAAAAAAXf///////////////////////////////////////////" +
                        "///////////////////////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////Ak5OTk5OTk5OTk5OTk5OTk5OTk5OTk+r////////wDwAAAAAAAAAAAAAAA" +
                        "Ef//////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////3EAAAAAAAAAAAAAAAAAAJ///////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD/////////QAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABj/////////////////" +
                        "/////////////////////////////////////////////////////////////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4/////////7eTk5OTk5OTk5OTk5OTk5OTk5OTk5OT2" +
                        "f////////APAAAAAAAAAAAAAAAAR////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////fwAAA" +
                        "AAAAAAAAAAAAAAATP///////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP////////9GAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAGP//////////////////////////////////////////////////////////////////////" +
                        "////////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////spOTk" +
                        "5OTk5OTk5OTk5OTk5OTk5OTk5PL////////8A8AAAAAAAAAAAAAAABH/////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////+XAAAAAAAAAAAAAAAAAAAIrP///////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////0cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAY////////////////////////////////////////////" +
                        "///////////////////////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P////////+xk5OTk5OTk5OTk5OTk5OTk5OTk5OTk8j////////wDwAAAAAAAAAAAAAAA" +
                        "Ef//////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////8IAAAAAAAAAAAAAAAAAAAACa9j2/Pz59" +
                        "OKiyv///////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD/////////RwAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABj/////////////////" +
                        "/////////////////////////////////////////////////////////////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4/////////7STk5OTk5OTk5OTk5OTk5OTk5OTk5OT0" +
                        "v////////APAAAAAAAAAAAAAAAAR////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////9isAA" +
                        "AAAAAAAAAAAAAAAAAAACSU4Oi4dCwCN/////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP////////9HAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAGP//////////////////////////////////////////////////////////////////////" +
                        "////////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////vJOTk" +
                        "5OTk5OTk5OTk5OTk5OTk5OTk5Pj////////8A8AAAAAAAAAAAAAAABH/////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////fAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAI7//////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////0cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAY////////////////////////////////////////////" +
                        "///////////////////////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P/////////Jk5OTk5OTk5OTk5OTk5OTk5OTk5OTm/f////////wDwAAAAAAAAAAAAAAA" +
                        "Ef//////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////WCAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAiP///////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD/////////RwAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABj/////////////////" +
                        "/////////////////////////////////////////////////////////////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4/////////+eUk5OTk5OTk5OTk5OTk5OTk5OTk5O4/" +
                        "/////////APAAAAAAAAAAAAAAAAR////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////////////////////9hA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAB//////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP////////9HAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAGP//////////////////////////////////////////////////////////////////////" +
                        "////////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj//////////rCTk" +
                        "5OTk5OTk5OTk5OTk5OTk5OTk+P/////////8A8AAAAAAAAAAAAAAABH/////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////9wPAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHr//////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////0cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAY////////////////////////////////////////////" +
                        "///////////////////////////////////////cQAAAAAAAAAAAAAAAABj////////////+CwAAAAAA" +
                        "AAAAAAAAAAs+P//////////55yTk5OTk5OTk5OTk5OTk5OTk5O+///////////wDwAAAAAAAAAAAAAAA" +
                        "Ef//////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////6kTAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAZf///////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD/////////RwAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABj/////////////////" +
                        "/////////////////////////////////////////////////////////////////9xAAAAAAAAAAAAA" +
                        "AAAAGP////////////4LAAAAAAAAAAAAAAAACz4////////////5ZiTk5OTk5OTk5OTk5OTk5OTqP7//" +
                        "/////////APAAAAAAAAAAAAAAAAR////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "80eAAAAAAAAAAAAAAAAAAAAAAAAAABY/////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP////////9FAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAGH//////////////////////////////////////////////////////////////////////" +
                        "////////////3EAAAAAAAAAAAAAAAAAY/////////////gsAAAAAAAAAAAAAAAALPj/////////////2" +
                        "ZaTk5OTk5OTk5OTk5OTk5nf////////////8A8AAAAAAAAAAAAAAABH/////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////8MPAAAAAAAAAAAAAAAAAAAAAAAAAEf//////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////0wHBwcHBwcHBwcHBwcHBwcHBwcHBwcHB" +
                        "wcHBwcHBwcHBwcHBwcHBwcHBwcHBwcHBwcHZ////////////////////////////////////////////" +
                        "///////////////////////////////////////ZwAAAAAAAAAAAAAAAABY////////////+B0AAAAAA" +
                        "AAAAAAAAAAd+P//////////////4JmTk5OTk5OTk5OTk5Ok5f/////////////vAAAAAAAAAAAAAAAAA" +
                        "Dr//////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////81LAQAAAAAAAAAAAAAAAAAAA" +
                        "AAANv7//////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD/////////4NLT0" +
                        "9PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09Lk/////////////////" +
                        "/////////////////////////////////////////////////////////////////+4f39/f39/f39/f" +
                        "39/f7H////////////7lX9/f39/f39/f39/f5X7////////////////4aeTk5OTk5OTk5OXwPX//////" +
                        "/////////eHf39/f39/f39/f39/o////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////++YxUAAAAAAAAAAAAAAAAACiaB/P///////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////Nq6n5iWl5miwO3//////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////5J5yTTMiDw8jLUJqjbXf9v///////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////68uzw9fv//////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////+vXw8PX4/////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/7b09PT09PT09PT09PT0/P//////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////+DIHBwcHBwcHBwcHBwcHuf///////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////2IwAAAAAAAAAAAAAAAAC2/////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/QdAAAAAAAAAAAAAAAAALX//////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////9B8AAAAAAAAAAAAAAAADwv///////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////yFgAAAAAAAAAAAAAAAAfU/////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/IPAAAAAAAAAAAAAAAAB9T//////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////4wsAAAAAAAAAAAAAAAAM6////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////CAgAAAAAAAAAAAAAAAB31/////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "68AAAAAAAAAAAAAAAAAL/n//////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////mAAAAAAAAAAAAAAAAABF/////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////98AAAAAAAAAAAAAAAAAFr//////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "14AAAAAAAAAAAAAAAAAdP///////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////9OQAAAAAAAAAAAAAAAACU/////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////+oNAAAAAAAAAAAAAAAAAb7//////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////////x" +
                        "QMAAAAAAAAAAAAAAAAI3v///////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////+cAAAAAAAAAAAAAAAAAB31/////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////3IAAAAAAAAAAAAAAAAAQv7//////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////////P" +
                        "wAAAAAAAAAAAAAAAABo/////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////94MAAAAAAAAAAAAAAAAAKP//////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////owAAAAAAAAAAAAAAAAAG2f///////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////////////////////9qA" +
                        "AAAAAAAAAAAAAAAACD2/////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////DEAAAAAAAAAAAAAAAAAVP///////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////aBwAAAAAAAAAAAAAAAACG/////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////48AA" +
                        "AAAAAAAAAAAAAAABMf//////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////7LgAAAAAAAAAAAAAAAAAg9////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////9AEAAAAAAAAAAAAAAAAAD39/////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////hwAAA" +
                        "AAAAAAAAAAAAAAAWv///////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////9cAAAAAAAAAAAAAAAAAAB9/////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////+y4AAAAAAAAAAAAAAAAABMP//////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////////////////BAgAAA" +
                        "AAAAAAAAAAAAABB/////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////2gAAAAAAAAAAAAAAAAAAIr//////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////qFgAAAAAAAAAAAAAAAAAG1f///////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////5IAAAAAA" +
                        "AAAAAAAAAAAAEH//////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////8LwAAAAAAAAAAAAAAAAAAkP///////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////4wAAAAAAAAAAAAAAAAAACXv/////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////////////vGAAAAAAAA" +
                        "AAAAAAAAAAAgf///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////48AAAAAAAAAAAAAAAAAAAna/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////wIAAAAAAAAAAAAAAAAAAAUP///////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////48AAAAAAAAAA" +
                        "AAAAAAAAAC0/////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////oHgAAAAAAAAAAAAAAAAAAP/r//////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////5sAAAAAAAAAAAAAAAAAAACk/////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////////////4NAAAAAAAAAAAA" +
                        "AAAAAAABdn//////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////5QAAAAAAAAAAAAAAAAAAABF/P///////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////kFwAAAAAAAAAAAAAAAAAAALr//////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////2IAAAAAAAAAAAAAA" +
                        "AAAAABG/v///////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////+AAAAAAAAAAAAAAAAAAAAAFtf//////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////uQAAAAAAAAAAAAAAAAAAAACK/////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////QoAAAAAAAAAAAAAAAAA" +
                        "AAAJvL//////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////sAAAAAAAAAAAAAAAAAAAAACi/////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////k6AAAAAAAAAAAAAAAAAAAAPfz//////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////1YwAAAAAAAAAAAAAAAAAAA" +
                        "ACv/////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////VUAAAAAAAAAAAAAAAAAAAAAPvv//////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////9/AAAAAAAAAAAAAAAAAAAAAAnN/////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////qwIAAAAAAAAAAAAAAAAAAAAAf" +
                        "P///////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "8sQAAAAAAAAAAAAAAAAAAAAAC3z/////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////vOAAAAAAAAAAAAAAAAAAAAAAdx////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////7kQAAAAAAAAAAAAAAAAAAAAADcb//" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////////////////////hJA" +
                        "AAAAAAAAAAAAAAAAAAAAAB8/////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////5WgAAAAAAAAAAAAAAAAAAAAAACNv//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////91sAAAAAAAAAAAAAAAAAAAAAAACH/////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////////////////////////////////////////9xAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAWP7//////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////vZQQAAAAAAAAAAAAAAAAAAAAAAG72/////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////4T4AAAAAAAAAAAAAAAAAAAAAAABX/////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////9EtAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAOPD//////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////BGgAAAAAAAAAAAAAAAAAAAAAAABLd/////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////3R8AAAAAAAAAAAAAAAAAAAAAAAAAev///////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////8J8hAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAmv2/////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////8MsAAAAAAAAAAAAAAAAAAAAAAAAAAej/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////+GBwAAAAAAAAAAAAAAAAAAAAAAAAAAmv///////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////fwAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAIv//////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///1EcAAAAAAAAAAAAAAAAAAAAAAAAAAABT/////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////8osSAAAAAAAAAAAAAAAAAAAAAAAAAAAARu3//////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////////////////////////////////////////////94wjAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAEJb2/////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////640A" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAB2+/////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////7dHAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAr0v///////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////+plAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD" +
                        "Mv//////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////d5/HAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAACXA/////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////4Xk9DQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABiT6v///////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////3t18SAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA11f///" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////////////////////////////////////////lhykAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAK+L//////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "t6aVhIAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAGHr/////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "//////////////////////31ZJACgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAB+m/////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////z06dzMvKeHXyoIAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAhk4P///////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////+m3uK2bnId7ZltIOB8OCgUAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABEy////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////nQAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAjoP///////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////+bAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAc+f//////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////5wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAJqr//////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////nAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHYrv/////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////+cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACW" +
                        "rbs/////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////5wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAALW8T//////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////nAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAbedb//////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////+cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAecOD//////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////5wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAlPo+7//////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////nAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAANLU900v///////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////+cAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA5BmOP4/////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////5wAAAAAAAAAAAAAAAAAAAAAAAAAAAAHN" +
                        "3Kn4/7//////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "///////////////////////////////////////////////////////////////////////////nAAAA" +
                        "AAAAAAAAAAAAAAAAAAIIERvmdP7/////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////+XAAAAAAAABAoPHzRNaH+Xs9b0/////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////8Fxf46cprjL3fD0+v///////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AP///////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "/////////////////////////////////////8A/////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////wD//////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "////////////////////////////////////////////////////////////////////////////////" +
                        "///////////AAtAAAEAAAD/////AQAAAAAAAAAMAgAAABtEZXZFeHByZXNzLlh0cmFSZXBvcnRzLnY2L" +
                        "jIFAQAAACxEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlNlcmlhbGl6YWJsZVN0cmluZwEAAAAFVmFsd" +
                        "WUBAgAAAAYDAAAA1AF7XHJ0ZjFcYW5zaVxhbnNpY3BnMTI1MlxkZWZmMHtcZm9udHRibHtcZjBcZm5pb" +
                        "FxmY2hhcnNldDAgQXJpYWw7fX0NClx2aWV3a2luZDRcdWMxXHBhcmRcbm93aWRjdGxwYXJcc2wyNDBcc" +
                        "2xtdWx0MFxsYW5nMjA1NVxmczE4IFNvemlhbGRpZW5zdGUgWm9sbGlrb2ZlblxwYXINCldhaGxhY2tlc" +
                        "nN0cmFzc2UgMjVccGFyDQozMDUyIFpvbGxpa29mZW5cZnMyMFxwYXINCn0NCgtAAAEAAAD/////AQAAA" +
                        "AAAAAAMAgAAABtEZXZFeHByZXNzLlh0cmFSZXBvcnRzLnY2LjIFAQAAACxEZXZFeHByZXNzLlh0cmFSZ" +
                        "XBvcnRzLlVJLlNlcmlhbGl6YWJsZVN0cmluZwEAAAAFVmFsdWUBAgAAAAYDAAAAnwR7XHJ0ZjFcYW5za" +
                        "VxhbnNpY3BnMTI1MlxkZWZmMFxkZWZ0YWI3MDh7XGZvbnR0Ymx7XGYwXGZuaWxcZmNoYXJzZXQwIEFya" +
                        "WFsO319DQpcdmlld2tpbmQ0XHVjMVxwYXJkXGxhbmcxMDMzXGZzMTcgR2VnZW4gZGllc2UgVmVyZlwnZ" +
                        "mNndW5nIGthbm4gaW5uZXJ0IDMwIFRhZ2VuIHNlaXQgZGVyIEVyXCdmNmZmbnVuZyBcbGFuZzEwMzEgY" +
                        "mVpbSBSZWdpZXJ1bmdzc3RhdHRoYWx0ZXJhbXQsIEJlcm4tTWl0dGVsbGFuZCwgUG9zdHN0cmFzc2UgM" +
                        "jUsIFxwYXINCjMwNzEgT3N0ZXJtdW5kaWdlblxsYW5nMTAzMyAgVmVyd2FsdHVuZ3NiZXNjaHdlcmRlI" +
                        "GdlZlwnZmNocnQgd2VyZGVuLiBkaWUgQmVzY2h3ZXJkZSBpc3QgaW0gRG9wcGVsIGVpbnp1cmVpY2hlb" +
                        "iwgbXVzcyBlaW5lbiBBbnRyYWcsIGRpZSBBbmdhYmVuIHZvbiBUYXRzYWNoZW4gdW5kIEJld2Vpc21pd" +
                        "HRlbG4sIGVpbmUgQmVnclwnZmNuZHVuZyBzb3dpZSBlaW5lIFVudGVyc2NocmlmdCBlbnRoYWx0ZW4uI" +
                        "EFsbGZcJ2U0bGxpZ2UgQmV3ZWlzbWl0dGVsIHNpbmQgYmVpenVsZWdlbi5ccGFyDQp9DQoLAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAA==";
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
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrRichTextBox2 = new DevExpress.XtraReports.UI.XRRichTextBox();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
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
                        this.xrLabel4,
                        this.xrPictureBox1,
                        this.xrLine3,
                        this.xrLabel3,
                        this.xrRichTextBox2,
                        this.xrLine2,
                        this.xrPanel1,
                        this.xrLabel2,
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
            this.Detail.Height = 2051;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBackColor = false;
            this.Detail.ParentStyleUsing.UseBorderColor = false;
            this.Detail.ParentStyleUsing.UseBorders = false;
            this.Detail.ParentStyleUsing.UseBorderWidth = false;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.ParentStyleUsing.UseForeColor = false;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.Location = new System.Drawing.Point(0, 85);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(296, 63);
            this.xrLabel4.Text = "Gemeinde";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Dpi = 254F;
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.Location = new System.Drawing.Point(296, 0);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.Size = new System.Drawing.Size(360, 212);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 254F;
            this.xrLine3.ForeColor = System.Drawing.Color.Black;
            this.xrLine3.LineWidth = 3;
            this.xrLine3.Location = new System.Drawing.Point(0, 1799);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.ParentStyleUsing.UseBackColor = false;
            this.xrLine3.ParentStyleUsing.UseBorderColor = false;
            this.xrLine3.ParentStyleUsing.UseBorders = false;
            this.xrLine3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine3.ParentStyleUsing.UseFont = false;
            this.xrLine3.ParentStyleUsing.UseForeColor = false;
            this.xrLine3.Size = new System.Drawing.Size(1854, 5);
            // 
            // xrLabel3
            // 
            this.xrLabel3.BackColor = System.Drawing.Color.Silver;
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(0, 1799);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(373, 38);
            this.xrLabel3.Text = "Rechtsmittelbelehrung";
            // 
            // xrRichTextBox2
            // 
            this.xrRichTextBox2.Dpi = 254F;
            this.xrRichTextBox2.Font = new System.Drawing.Font("Arial", 8F);
            this.xrRichTextBox2.ForeColor = System.Drawing.Color.Black;
            this.xrRichTextBox2.Location = new System.Drawing.Point(0, 1842);
            this.xrRichTextBox2.Name = "xrRichTextBox2";
            this.xrRichTextBox2.ParentStyleUsing.UseBackColor = false;
            this.xrRichTextBox2.ParentStyleUsing.UseBorderColor = false;
            this.xrRichTextBox2.ParentStyleUsing.UseBorders = false;
            this.xrRichTextBox2.ParentStyleUsing.UseBorderWidth = false;
            this.xrRichTextBox2.ParentStyleUsing.UseFont = false;
            this.xrRichTextBox2.ParentStyleUsing.UseForeColor = false;
            this.xrRichTextBox2.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichTextBox2.RtfText")));
            this.xrRichTextBox2.Scripts.OnBeforePrint = "private void OnBeforePrint(object sender, System.Drawing.Printing.PrintEventArgs " +
                "e) {\r\n\trtfHinweis.Text = string.Format(rtfHinweis.Text, Report.GetCurrentColumnV" +
                "alue(\"DatumFinanzplan\"));\r\n}";
            this.xrRichTextBox2.Size = new System.Drawing.Size(1852, 127);
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 254F;
            this.xrLine2.ForeColor = System.Drawing.Color.Black;
            this.xrLine2.LineWidth = 3;
            this.xrLine2.Location = new System.Drawing.Point(0, 2011);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.ParentStyleUsing.UseBackColor = false;
            this.xrLine2.ParentStyleUsing.UseBorderColor = false;
            this.xrLine2.ParentStyleUsing.UseBorders = false;
            this.xrLine2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine2.ParentStyleUsing.UseFont = false;
            this.xrLine2.ParentStyleUsing.UseForeColor = false;
            this.xrLine2.Size = new System.Drawing.Size(1854, 6);
            // 
            // xrPanel1
            // 
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageInfo1});
            this.xrPanel1.Dpi = 254F;
            this.xrPanel1.Location = new System.Drawing.Point(0, 1503);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.ParentStyleUsing.UseBorders = false;
            this.xrPanel1.Size = new System.Drawing.Size(444, 106);
            // 
            // xrLabel2
            // 
            this.xrLabel2.BackColor = System.Drawing.Color.Silver;
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.Location = new System.Drawing.Point(799, 1439);
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
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel1.Location = new System.Drawing.Point(0, 1312);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(1842, 85);
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 254F;
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine1.LineWidth = 2;
            this.xrLine1.Location = new System.Drawing.Point(931, 804);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(10, 134);
            // 
            // ShVerfuegungMonatsbudget_EinAus
            // 
            this.ShVerfuegungMonatsbudget_EinAus.Dpi = 254F;
            this.ShVerfuegungMonatsbudget_EinAus.Location = new System.Drawing.Point(0, 741);
            this.ShVerfuegungMonatsbudget_EinAus.Name = "ShVerfuegungMonatsbudget_EinAus";
            // 
            // ShVerfuegungMonatsbudget_Personen
            // 
            this.ShVerfuegungMonatsbudget_Personen.Dpi = 254F;
            this.ShVerfuegungMonatsbudget_Personen.Location = new System.Drawing.Point(0, 508);
            this.ShVerfuegungMonatsbudget_Personen.Name = "ShVerfuegungMonatsbudget_Personen";
            // 
            // xrRichTextBox1
            // 
            this.xrRichTextBox1.CanShrink = true;
            this.xrRichTextBox1.Dpi = 254F;
            this.xrRichTextBox1.ForeColor = System.Drawing.Color.Black;
            this.xrRichTextBox1.Location = new System.Drawing.Point(0, 214);
            this.xrRichTextBox1.Name = "xrRichTextBox1";
            this.xrRichTextBox1.ParentStyleUsing.UseBackColor = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorderColor = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorders = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorderWidth = false;
            this.xrRichTextBox1.ParentStyleUsing.UseFont = false;
            this.xrRichTextBox1.ParentStyleUsing.UseForeColor = false;
            this.xrRichTextBox1.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichTextBox1.RtfText")));
            this.xrRichTextBox1.Size = new System.Drawing.Size(529, 149);
            // 
            // txtFehlbetrag
            // 
            this.txtFehlbetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Fehlbetrag", "{0:n2}")});
            this.txtFehlbetrag.Dpi = 254F;
            this.txtFehlbetrag.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.txtFehlbetrag.ForeColor = System.Drawing.Color.Black;
            this.txtFehlbetrag.Location = new System.Drawing.Point(1588, 952);
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
            this.Label25.Location = new System.Drawing.Point(971, 952);
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
            this.Label24.Location = new System.Drawing.Point(974, 868);
            this.Label24.Name = "Label24";
            this.Label24.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label24.ParentStyleUsing.UseBackColor = false;
            this.Label24.ParentStyleUsing.UseBorderColor = false;
            this.Label24.ParentStyleUsing.UseBorders = false;
            this.Label24.ParentStyleUsing.UseBorderWidth = false;
            this.Label24.ParentStyleUsing.UseFont = false;
            this.Label24.ParentStyleUsing.UseForeColor = false;
            this.Label24.Size = new System.Drawing.Size(381, 40);
            this.Label24.Text = "Total Ausgaben";
            // 
            // Label23
            // 
            this.Label23.Dpi = 254F;
            this.Label23.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label23.ForeColor = System.Drawing.Color.Black;
            this.Label23.Location = new System.Drawing.Point(3, 868);
            this.Label23.Name = "Label23";
            this.Label23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label23.ParentStyleUsing.UseBackColor = false;
            this.Label23.ParentStyleUsing.UseBorderColor = false;
            this.Label23.ParentStyleUsing.UseBorders = false;
            this.Label23.ParentStyleUsing.UseBorderWidth = false;
            this.Label23.ParentStyleUsing.UseFont = false;
            this.Label23.ParentStyleUsing.UseForeColor = false;
            this.Label23.Size = new System.Drawing.Size(444, 40);
            this.Label23.Text = "Total Einnahmen";
            // 
            // txtTotOut
            // 
            this.txtTotOut.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TotOut", "{0:n2}")});
            this.txtTotOut.Dpi = 254F;
            this.txtTotOut.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtTotOut.ForeColor = System.Drawing.Color.Black;
            this.txtTotOut.Location = new System.Drawing.Point(1588, 868);
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
            this.txtTotIn.Location = new System.Drawing.Point(656, 868);
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
            this.Line13.LineWidth = 2;
            this.Line13.Location = new System.Drawing.Point(3, 931);
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
            this.Line12.LineWidth = 2;
            this.Line12.Location = new System.Drawing.Point(3, 847);
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
            this.Line11.Dpi = 254F;
            this.Line11.ForeColor = System.Drawing.Color.Black;
            this.Line11.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line11.LineWidth = 2;
            this.Line11.Location = new System.Drawing.Point(931, 677);
            this.Line11.Name = "Line11";
            this.Line11.ParentStyleUsing.UseBackColor = false;
            this.Line11.ParentStyleUsing.UseBorderColor = false;
            this.Line11.ParentStyleUsing.UseBorders = false;
            this.Line11.ParentStyleUsing.UseBorderWidth = false;
            this.Line11.ParentStyleUsing.UseFont = false;
            this.Line11.ParentStyleUsing.UseForeColor = false;
            this.Line11.Size = new System.Drawing.Size(10, 84);
            // 
            // Line10
            // 
            this.Line10.Dpi = 254F;
            this.Line10.ForeColor = System.Drawing.Color.Black;
            this.Line10.LineWidth = 2;
            this.Line10.Location = new System.Drawing.Point(3, 720);
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
            this.Label12.Location = new System.Drawing.Point(974, 677);
            this.Label12.Name = "Label12";
            this.Label12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label12.ParentStyleUsing.UseBackColor = false;
            this.Label12.ParentStyleUsing.UseBorderColor = false;
            this.Label12.ParentStyleUsing.UseBorders = false;
            this.Label12.ParentStyleUsing.UseBorderWidth = false;
            this.Label12.ParentStyleUsing.UseFont = false;
            this.Label12.ParentStyleUsing.UseForeColor = false;
            this.Label12.Size = new System.Drawing.Size(381, 37);
            this.Label12.Text = "Ausgaben";
            // 
            // Label11
            // 
            this.Label11.Dpi = 254F;
            this.Label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(3, 677);
            this.Label11.Name = "Label11";
            this.Label11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label11.ParentStyleUsing.UseBackColor = false;
            this.Label11.ParentStyleUsing.UseBorderColor = false;
            this.Label11.ParentStyleUsing.UseBorders = false;
            this.Label11.ParentStyleUsing.UseBorderWidth = false;
            this.Label11.ParentStyleUsing.UseFont = false;
            this.Label11.ParentStyleUsing.UseForeColor = false;
            this.Label11.Size = new System.Drawing.Size(444, 37);
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
            this.txtAnrede.Location = new System.Drawing.Point(974, 212);
            this.txtAnrede.Multiline = true;
            this.txtAnrede.Name = "txtAnrede";
            this.txtAnrede.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtAnrede.ParentStyleUsing.UseBackColor = false;
            this.txtAnrede.ParentStyleUsing.UseBorderColor = false;
            this.txtAnrede.ParentStyleUsing.UseBorders = false;
            this.txtAnrede.ParentStyleUsing.UseBorderWidth = false;
            this.txtAnrede.ParentStyleUsing.UseFont = false;
            this.txtAnrede.ParentStyleUsing.UseForeColor = false;
            this.txtAnrede.Size = new System.Drawing.Size(741, 232);
            this.txtAnrede.Text = "Anrede";
            // 
            // Line8
            // 
            this.Line8.Dpi = 254F;
            this.Line8.ForeColor = System.Drawing.Color.Black;
            this.Line8.LineWidth = 3;
            this.Line8.Location = new System.Drawing.Point(3, 1418);
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
            this.Line7.Location = new System.Drawing.Point(3, 1249);
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
            this.Line6.Location = new System.Drawing.Point(3, 1037);
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
            this.Line4.Location = new System.Drawing.Point(799, 1714);
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
            this.Label9.Location = new System.Drawing.Point(799, 1736);
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
            this.Line3.Location = new System.Drawing.Point(799, 1588);
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
            this.Label8.Location = new System.Drawing.Point(799, 1609);
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
            this.Line2.Location = new System.Drawing.Point(3, 1714);
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
            this.Label7.Location = new System.Drawing.Point(3, 1736);
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
            this.Line1.Location = new System.Drawing.Point(3, 1588);
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
            this.Label6.Location = new System.Drawing.Point(3, 1609);
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
            this.Label5.Location = new System.Drawing.Point(3, 1439);
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
            this.Label4.Location = new System.Drawing.Point(3, 1270);
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
            this.Label3.Location = new System.Drawing.Point(3, 1058);
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
            this.Label2.Location = new System.Drawing.Point(3, 614);
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
            this.txtTitle.Location = new System.Drawing.Point(0, 444);
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
            this.rtfHinweis.Font = new System.Drawing.Font("Arial", 9F);
            this.rtfHinweis.ForeColor = System.Drawing.Color.Black;
            this.rtfHinweis.Location = new System.Drawing.Point(0, 1101);
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
            this.rtfHinweis.Size = new System.Drawing.Size(1852, 127);
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 254F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.xrPageInfo1.Format = "Zollikofen, {0}";
            this.xrPageInfo1.KeepTogether = false;
            this.xrPageInfo1.Location = new System.Drawing.Point(0, 42);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(423, 50);
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
            this.Margins = new System.Drawing.Printing.Margins(140, 94, 203, 102);
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
</NewDataSet>' , SQLquery =  N'-- Parameter
DECLARE @GetDate datetime  SET @GetDate = GetDate()

DECLARE @TotIn money
DECLARE @TotOut money


SELECT @TotIn = SUM(Betrag)
FROM dbo.fnWhGetFinanzplanIndent({BgBudgetID}, @GetDate, 0)  TMP
  INNER JOIN XLOVCode  XPC ON XPC.LOVName = ''BgKategorie'' AND XPC.Code = TMP.BgKategorieCode
WHERE BgKategorieCode = 1


SELECT @TotOut = SUM(Betrag)
FROM dbo.fnWhGetFinanzplanIndent({BgBudgetID}, @GetDate, 0)  TMP
  INNER JOIN XLOVCode  XPC ON XPC.LOVName = ''BgKategorie'' AND XPC.Code = TMP.BgKategorieCode
WHERE BgKategorieCode = 2


DECLARE @Bemerkung  varchar(8000),
        @ItemText   varchar(8000)

DECLARE cBemerkung CURSOR FAST_FORWARD FOR
  SELECT ''- '' + XLC.Text + '' ('' + PRS.Name + IsNull('', '' + PRS.Vorname, '''') + ''): '' + CONVERT(varchar(8000), BPO.Bemerkung)
  FROM BgPosition              BPO
    INNER JOIN BaPerson        PRS ON PRS.BaPersonID = BPO.BaPersonID
    INNER JOIN WhPositionsart  SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
    INNER JOIN XLOVCode        XLC ON XLC.LOVName = ''BgGruppe'' AND XLC.Code = SPT.BgGruppeCode
  WHERE BPO.BgBudgetID = {BgBudgetID}
    AND SPT.BgPositionsartCode BETWEEN 39000 AND 39999
    AND NOT (BPO.Bemerkung IS NULL OR BPO.Bemerkung LIKE '''')
    AND GetDate() BETWEEN IsNull(BPO.DatumVon, ''19000101'') AND IsNull(BPO.DatumBis, GetDate())
  ORDER BY PRS.Name, PRS.Vorname

OPEN cBemerkung
WHILE (1 = 1) BEGIN
  FETCH NEXT FROM cBemerkung INTO @ItemText
  IF @@FETCH_STATUS != 0 BREAK

  SET @Bemerkung = IsNull(@Bemerkung + CHAR(10) + CHAR(13), '''') + @ItemText
END
CLOSE cBemerkung
DEALLOCATE cBemerkung


SELECT BBG.BgBudgetID,
       Title        = ''Verfügung: Sozialhilfe '' + dbo.fnXMonatJahr(dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)),
       Adresse      = isnull(case PRS.GeschlechtCode when 1 then ''Herr'' when 2 then ''Frau'' end + char(13) + char(10),'''') +
                      PRS.VornameName + char(13) + char(10) +
                      isnull(PRS.WohnsitzStrasseHausNr, '''') + char(13) + char(10) +
                      isnull(PRS.WohnsitzPLZOrt, ''''),
       DatumFinanzplan = (SELECT MAX(Datum)
                          FROM BgBewilligung BBW
                          WHERE BBW.BgFinanzplanID = SFP.BgFinanzplanID and BBW.BgBewilligungCode = 2),
       Bemerkung = IsNull(CONVERT(varchar(8000), SFP.Bemerkung) + CHAR(10) + CHAR(13), '''') + IsNull(@Bemerkung, ''''),
       TotIn        = @TotIn,
       TotOut       = @TotOut,
       Fehlbetrag   = isNull(@TotOut,0) - isNull(@TotIn,0)
FROM   BgBudget BBG
       inner join BgFinanzplan  SFP on SFP.BgFinanzplanID = BBG.BgFinanzplanID
       inner join FaLeistung    FAL on FAL.FaLeistungID = SFP.FaLeistungID
       inner join vwPerson      PRS on PRS.BaPersonID = FAL.BaPersonID
WHERE FAL.ModulID = 3
  AND BBG.MasterBudget = 0 AND BBG.BgBewilligungStatusCode = 5
  AND BBG.BgBudgetID = {BgBudgetID}' , ContextForms =  N'WhMonatsbudget,SKOS2005' , ParentReportName =  null , ReportSortKey = 3, System =  0 
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'ShVerfuegungMonatsbudget' ;


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'ShVerfuegungMonatsbudget_EinAus' ,  N'Einnahmen, Ausgaben' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\KiSS\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\Kiss.Interfaces.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\FluentValidation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xml.Linq\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.Linq.dll" />
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
///     <Reference Path="C:\KiSS\Build\Debug\PdfSharp.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\itextsharp.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\C1.C1Zip.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\Microsoft.Practices.Unity.Configuration.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\Kiss.BusinessLogic.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\Kiss.DbContext.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\EntityFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.CSharp\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.CSharp.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Dynamic\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Dynamic.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\Kiss.DataAccess.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\HtmlAgilityPack.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\Kiss.BL.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\Kiss.Model.dll" />
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
///     <Reference Path="C:\KiSS\Build\Debug\KiSS.Common.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\Common.Logging.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\Autofac.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\Kiss.Database.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\WPFLocalizeExtension.dll" />
///     <Reference Path="C:\KiSS\Build\Debug\XAMLMarkupExtensions.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
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
                        "AAAAcQJREVDTEFSRSBAR2V0RGF0ZSBkYXRldGltZSAgU0VUIEBHZXREYXRlID0gR2V0RGF0ZSgpDQoNC" +
                        "g0KREVDTEFSRSBARWlubmFobWVuIFRBQkxFIChpZCBpbnQgaWRlbnRpdHksIFRleHQgdmFyY2hhcigxM" +
                        "DApLCBCZXRyYWcgbW9uZXkpDQpERUNMQVJFIEBBdXNnYWJlbiAgVEFCTEUgKGlkIGludCBpZGVudGl0e" +
                        "SwgVGV4dCB2YXJjaGFyKDEwMCksIEJldHJhZyBtb25leSkNCg0KLS0gRWlubmFobWVuDQpJTlNFUlQgS" +
                        "U5UTyBARWlubmFobWVuIChUZXh0LCBCZXRyYWcpDQogIFNFTEVDVCBUTVAuQmV6ZWljaG51bmcsIFRNU" +
                        "C5CZXRyYWcNCiAgRlJPTSBkYm8uZm5XaEdldEZpbmFuenBsYW5JbmRlbnQobnVsbCwgQEdldERhdGUsI" +
                        "DApICBUTVANCiAgV0hFUkUgQmdLYXRlZ29yaWVDb2RlID0gMQ0KICBBTkQgKFRNUC5CZXRyYWcgPD4gJ" +
                        "DAuMDAgT1IgKEJnS2F0ZWdvcmllQ29kZSA9IDEgQU5EIEJnR3J1cHBlQ29kZSBMSUtFICdbMC05XSUnK" +
                        "SkNCi0tIEF1c2dhYmVuIC8gS8O8cnp1bmdlbg0KSU5TRVJUIElOVE8gQEF1c2dhYmVuIChUZXh0LCBCZ" +
                        "XRyYWcpDQogIFNFTEVDVA0KICAgIENBU0UNCiAgICAgIFdIRU4gVE1QLkJlemVpY2hudW5nIExJS0UgJ" +
                        "01lZC4gR3J1bmQlKEtWRyknIFRIRU4gJ0tWRyBQcsOkbWllbicNCiAgICAgIFdIRU4gVE1QLkJlemVpY" +
                        "2hudW5nIExJS0UgJ01lZC4gR3J1bmQlKFZWRyknIFRIRU4gJ1ZWRyBQcsOkbWllbicNCiAgICAgIEVMU" +
                        "0UgVE1QLkJlemVpY2hudW5nDQogICAgRU5ELA0KICAgIENBU0UNCiAgICAgIFdIRU4gQmdLYXRlZ29ya" +
                        "WVDb2RlID0gMiBUSEVOIFRNUC5CZXRyYWcNCiAgICAgIEVMU0UgLVRNUC5CZXRyYWcNCiAgICBFTkQNC" +
                        "iAgRlJPTSBkYm8uZm5XaEdldEZpbmFuenBsYW5JbmRlbnQobnVsbCwgQEdldERhdGUsIDApICBUTVANC" +
                        "iAgV0hFUkUgQmdLYXRlZ29yaWVDb2RlIElOICgyLCA0KSAtLSBBdXNnYWJlbiAvIEvDvHJ6dW5nZW4NC" +
                        "iAgICBBTkQgKFRNUC5CZXRyYWcgPD4gJDAuMDAgT1IgKEJnS2F0ZWdvcmllQ29kZSA9IDIgQU5EIEJnR" +
                        "3J1cHBlQ29kZSBMSUtFICdbMC05XSUnKSkNCg0KU0VMRUNUDQogIFRleHRFaW4gPSBFSU4uVGV4dCwgQ" +
                        "mV0cmFnRWluID0gRUlOLkJldHJhZywNCiAgVGV4dEF1cyA9IEFVUy5UZXh0LCBCZXRyYWdBdXMgPSBBV" +
                        "VMuQmV0cmFnDQpGUk9NIEBFaW5uYWhtZW4gICAgICAgICBFSU4NCiAgRlVMTCAgSk9JTiBAQXVzZ2FiZ" +
                        "W4gIEFVUyBPTiBBVVMuaWQgPSBFSU4uaWQ=";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrTable1});
            this.Detail.Height = 25;
            this.Detail.Name = "Detail";
            this.Detail.Scripts.OnBeforePrint = "private void OnBeforePrint(object sender, System.Drawing.Printing.PrintEventArgs " +
                "e) {\r\n  //xrLine1.Height = Detail.Height = 444;\r\n}";
            // 
            // xrTable1
            // 
            this.xrTable1.Location = new System.Drawing.Point(0, 0);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow1});
            this.xrTable1.Size = new System.Drawing.Size(733, 25);
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell1,
                        this.xrTableCell2,
                        this.xrTableCell3,
                        this.xrTableCell4});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Size = new System.Drawing.Size(733, 25);
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel6});
            this.xrTableCell1.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell1.Size = new System.Drawing.Size(258, 25);
            this.xrTableCell1.Text = "xrTableCell1";
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            this.xrTableCell2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel1});
            this.xrTableCell2.Location = new System.Drawing.Point(258, 0);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell2.ParentStyleUsing.UseBorders = false;
            this.xrTableCell2.ParentStyleUsing.UseBorderWidth = false;
            this.xrTableCell2.Size = new System.Drawing.Size(111, 25);
            this.xrTableCell2.Text = "xrTableCell2";
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel7});
            this.xrTableCell3.Location = new System.Drawing.Point(369, 0);
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell3.Size = new System.Drawing.Size(264, 25);
            this.xrTableCell3.Text = "xrTableCell3";
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel8});
            this.xrTableCell4.Location = new System.Drawing.Point(633, 0);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell4.ParentStyleUsing.UseBorders = false;
            this.xrTableCell4.Size = new System.Drawing.Size(100, 25);
            this.xrTableCell4.Text = "xrTableCell4";
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TextEin", "")});
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel6.Location = new System.Drawing.Point(15, 0);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.Size = new System.Drawing.Size(258, 18);
            this.xrLabel6.Text = "xrLabel6";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragEin", "{0:n2}")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel1.Location = new System.Drawing.Point(0, 0);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(100, 18);
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TextAus", "")});
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel7.Location = new System.Drawing.Point(15, 0);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.Size = new System.Drawing.Size(250, 18);
            this.xrLabel7.Text = "xrLabel7";
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragAus", "{0:n2}")});
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel8.Location = new System.Drawing.Point(0, 0);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.Size = new System.Drawing.Size(100, 18);
            this.xrLabel8.Text = "xrLabel8";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            this.Margins = new System.Drawing.Printing.Margins(100, 10, 100, 100);
            this.Name = "Report";
            this.PageHeight = 1100;
            this.PageWidth = 850;
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'DECLARE @GetDate datetime  SET @GetDate = GetDate()


DECLARE @Einnahmen TABLE (id int identity, Text varchar(100), Betrag money)
DECLARE @Ausgaben  TABLE (id int identity, Text varchar(100), Betrag money)

-- Einnahmen
INSERT INTO @Einnahmen (Text, Betrag)
  SELECT TMP.Bezeichnung, TMP.Betrag
  FROM dbo.fnWhGetFinanzplanIndent({BgBudgetID}, @GetDate, 0)  TMP
  WHERE BgKategorieCode = 1
  AND (TMP.Betrag <> $0.00 OR (BgKategorieCode = 1 AND BgGruppeCode LIKE ''[0-9]%''))
-- Ausgaben / Kürzungen
INSERT INTO @Ausgaben (Text, Betrag)
  SELECT
    CASE
      WHEN TMP.Bezeichnung LIKE ''Med. Grund%(KVG)'' THEN ''KVG Prämien''
      WHEN TMP.Bezeichnung LIKE ''Med. Grund%(VVG)'' THEN ''VVG Prämien''
      ELSE TMP.Bezeichnung
    END,
    CASE
      WHEN BgKategorieCode = 2 THEN TMP.Betrag
      ELSE -TMP.Betrag
    END
  FROM dbo.fnWhGetFinanzplanIndent({BgBudgetID}, @GetDate, 0)  TMP
  WHERE BgKategorieCode IN (2, 4) -- Ausgaben / Kürzungen
    AND (TMP.Betrag <> $0.00 OR (BgKategorieCode = 2 AND BgGruppeCode LIKE ''[0-9]%''))

SELECT
  TextEin = EIN.Text, BetragEin = EIN.Betrag,
  TextAus = AUS.Text, BetragAus = AUS.Betrag
FROM @Einnahmen         EIN
  FULL  JOIN @Ausgaben  AUS ON AUS.id = EIN.id' ,  null ,  N'ShVerfuegungMonatsbudget' ,  null ,  0 );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'ShVerfuegungMonatsbudget_Personen' ,  N'Personen' , 1,  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>en-US</Localization>
///   <References>
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraPrinting.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Drawing\2.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System\2.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Configuration\2.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Xml\2.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Data.SqlXml\2.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Security\2.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.Utils.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Utils.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Windows.Forms\2.0.0.0__b77a5c561934e089\System.Windows.Forms.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\Accessibility\2.0.0.0__b03f5f7f11d50a3a\Accessibility.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Runtime.Serialization.Formatters.Soap\2.0.0.0__b03f5f7f11d50a3a\System.Runtime.Serialization.Formatters.Soap.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Deployment\2.0.0.0__b03f5f7f11d50a3a\System.Deployment.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Design\2.0.0.0__b03f5f7f11d50a3a\System.Design.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_32\System.Data\2.0.0.0__b77a5c561934e089\System.Data.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\Microsoft.VisualC\8.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualC.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_32\System.Transactions\2.0.0.0__b77a5c561934e089\System.Transactions.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_32\System.EnterpriseServices\2.0.0.0__b03f5f7f11d50a3a\System.EnterpriseServices.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.DirectoryServices\2.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Runtime.Remoting\2.0.0.0__b77a5c561934e089\System.Runtime.Remoting.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_32\System.Web\2.0.0.0__b03f5f7f11d50a3a\System.Web.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Web.Services\2.0.0.0__b03f5f7f11d50a3a\System.Web.Services.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.DirectoryServices.Protocols\2.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.Protocols.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.ServiceProcess\2.0.0.0__b03f5f7f11d50a3a\System.ServiceProcess.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Configuration.Install\2.0.0.0__b03f5f7f11d50a3a\System.Configuration.Install.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Web.RegularExpressions\2.0.0.0__b03f5f7f11d50a3a\System.Web.RegularExpressions.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Drawing.Design\2.0.0.0__b03f5f7f11d50a3a\System.Drawing.Design.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_32\System.Data.OracleClient\2.0.0.0__b77a5c561934e089\System.Data.OracleClient.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraEditors.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.Data.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Data.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraBars.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraNavBar.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraCharts.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraRichTextEdit.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="C:\KiSS4_Migration\KiSS4.DB.dll" />
///     <Reference Path="C:\KiSS4_Migration\SharpLibrary.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
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
                    string resourceString = @"zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OSNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kAAAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAAAAAAYwDU0VMRUNUDQogIE5hbWUgICAgICAgICAgICAgID0gUFJTLk5hbWVWb3JuYW1lLA0KICBBSFYgICAgICAgICAgICAgICA9IElzTnVsbChQUlMuQUhWTnVtbWVyLCAnJyksDQogIFBSUy5HZWJ1cnRzZGF0dW0sDQogIFBSUy5OYXRpb25hbGl0YWV0DQpGUk9NIEJnQnVkZ2V0ICAgICAgICAgICAgICAgICAgICAgICBCQkcNCiAgSU5ORVIgSk9JTiBCZ0ZpbmFuenBsYW5fQmFQZXJzb24gIFNQUCBPTiBTUFAuQmdGaW5hbnpwbGFuSUQgPSBCQkcuQmdGaW5hbnpwbGFuSUQNCiAgSU5ORVIgSk9JTiB2d1BlcnNvbiAgICAgICAgICAgICAgIFBSUyBPTiBQUlMuQmFQZXJzb25JRCA9IFNQUC5CYVBlcnNvbklEDQpXSEVSRSBCQkcuQmdCdWRnZXRJRCA9IG51bGwgQU5EIFNQUC5Jc3RVbnRlcnN0dWV0enQgPSAx";
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
            this.Detail.Height = 18;
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
            this.ReportHeader.Height = 49;
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
            this.ReportFooter.Height = 8;
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
            this.txtHeimatort.Font = new System.Drawing.Font("Arial", 9.75F);
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
            this.txtGebDat.Font = new System.Drawing.Font("Arial", 9.75F);
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
            this.txtName.Font = new System.Drawing.Font("Arial", 9.75F);
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
            this.xrLabel4.BackColor = System.Drawing.Color.Silver;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.Location = new System.Drawing.Point(0, 2);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.ParentStyleUsing.UseForeColor = false;
            this.xrLabel4.Size = new System.Drawing.Size(147, 15);
            this.xrLabel4.Text = "Unterstützte Personen";
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.Location = new System.Drawing.Point(0, 42);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(570, 2);
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(417, 25);
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
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.Location = new System.Drawing.Point(308, 25);
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
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.Location = new System.Drawing.Point(0, 25);
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
            this.Margins = new System.Drawing.Printing.Margins(100, 5, 100, 100);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' ,  null ,  N'SELECT
  Name              = PRS.NameVorname,
  AHV               = IsNull(PRS.AHVNummer, ''''),
  PRS.Geburtsdatum,
  PRS.Nationalitaet
FROM BgBudget                       BBG
  INNER JOIN BgFinanzplan_BaPerson  SPP ON SPP.BgFinanzplanID = BBG.BgFinanzplanID
  INNER JOIN vwPerson               PRS ON PRS.BaPersonID = SPP.BaPersonID
WHERE BBG.BgBudgetID = {BgBudgetID} AND SPP.IstUnterstuetzt = 1' ,  null ,  N'ShVerfuegungMonatsbudget' ,  null ,  0 );


