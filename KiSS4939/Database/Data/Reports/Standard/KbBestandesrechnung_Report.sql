-- Insert Script for KBBestandesrechnung
-- MD5:0X09B451BD85B3F1292CFEEA5718B51D85_0XF51BD69AF867D9B1333B8C010BA34798_0X232E12F75143A21C5DC71A9A8E113AAC
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'KBBestandesrechnung') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('KBBestandesrechnung', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'KBBestandesrechnung';
--SQLCHECK_IGNORE--
UPDATE QRY
SET QueryName =  N'KBBestandesrechnung' , UserText =  N'KB - Bestandesrechnung' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
        private DevExpress.XtraReports.UI.XRLabel lblDTBestandVon;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel lblDTZuwachs;
        private DevExpress.XtraReports.UI.XRLabel lblDTKontoNr;
        private DevExpress.XtraReports.UI.XRLabel lblDTBestandBis;
        private DevExpress.XtraReports.UI.XRLabel lblDTAbgang;
        private DevExpress.XtraReports.UI.XRLabel lblDTKontoName;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel lblRHDatumBis;
        private DevExpress.XtraReports.UI.XRLabel lblPHKlibu;
        private DevExpress.XtraReports.UI.XRLabel lblPHInstName;
        private DevExpress.XtraReports.UI.XRLabel lblPHInstPlzOrt;
        private DevExpress.XtraReports.UI.XRLabel lblPHInstStrasse;
        private DevExpress.XtraReports.UI.XRPanel panColHeaders;
        private DevExpress.XtraReports.UI.XRLabel lblPHVeraenderung;
        private DevExpress.XtraReports.UI.XRLabel lblPHBestandVon;
        private DevExpress.XtraReports.UI.XRLabel lblPHZuwachs;
        private DevExpress.XtraReports.UI.XRLabel lblPHKonto;
        private DevExpress.XtraReports.UI.XRLabel lblPHAbgang;
        private DevExpress.XtraReports.UI.XRLabel lblPHBestandBis;
        private DevExpress.XtraReports.UI.XRLabel lblPHBezeichnung;
        private DevExpress.XtraReports.UI.XRLabel lblPHBilanzEr;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLine linePageFooter;
        private DevExpress.XtraReports.UI.XRLabel lblPFDruckDatum;
        private DevExpress.XtraReports.UI.XRPageInfo infoPFPageInfo;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAAHAAAAAAAAAFBBRFBBRFATtE6kj" +
                        "i3mxQ98+Nn01QbrEaQZ7UMFhhaegewgxAEAAAAAAAAyAQAA5QAAAEcAAAB7AQAAlgAAAOcCAABCbABiA" +
                        "GwARABUAEEAYgBnAGEAbgBnAC4AUwBjAHIAaQBwAHQAcwAuAE8AbgBCAGUAZgBvAHIAZQBQAHIAaQBuA" +
                        "HQAAAAAAEpsAGIAbABEAFQAQgBlAHMAdABhAG4AZABCAGkAcwAuAFMAYwByAGkAcAB0AHMALgBPAG4AQ" +
                        "gBlAGYAbwByAGUAUAByAGkAbgB0ACwHAABKbABiAGwARABUAEIAZQBzAHQAYQBuAGQAVgBvAG4ALgBTA" +
                        "GMAcgBpAHAAdABzAC4ATwBuAEIAZQBmAG8AcgBlAFAAcgBpAG4AdABbDgAASGwAYgBsAEQAVABLAG8Ab" +
                        "gB0AG8ATgBhAG0AZQAuAFMAYwByAGkAcAB0AHMALgBPAG4AQgBlAGYAbwByAGUAUAByAGkAbgB0AIsVA" +
                        "ABEbABiAGwARABUAEsAbwBuAHQAbwBOAHIALgBTAGMAcgBpAHAAdABzAC4ATwBuAEIAZQBmAG8AcgBlA" +
                        "FAAcgBpAG4AdAC6HAAARGwAYgBsAEQAVABaAHUAdwBhAGMAaABzAC4AUwBjAHIAaQBwAHQAcwAuAE8Ab" +
                        "gBCAGUAZgBvAHIAZQBQAHIAaQBuAHQA5yMAADJzAHEAbABRAHUAZQByAHkAMQAuAFMAZQBsAGUAYwB0A" +
                        "FMAdABhAHQAZQBtAGUAbgB0ABQrAAABqQ5wcml2YXRlIHZvaWQgT25CZWZvcmVQcmludChvYmplY3Qgc" +
                        "2VuZGVyLCBTeXN0ZW0uRHJhd2luZy5QcmludGluZy5QcmludEV2ZW50QXJncyBlKSANCnsNCiAgICBYU" +
                        "kxhYmVsIGxibCA9IGxibERUQWJnYW5nOw0KICAgIGJvb2wgbGVmdEJvcmRlciA9IHRydWU7DQogICAgY" +
                        "m9vbCByaWdodEJvcmRlciA9IGZhbHNlOw0KICAgIA0KICAgIG9iamVjdCBncnVwcGVLb250b0lEID0gR" +
                        "2V0Q3VycmVudENvbHVtblZhbHVlKCJHcnVwcGVLb250b0lEIik7DQogICAgYm9vbCBrb250b0dydXBwZ" +
                        "SA9IChib29sKUdldEN1cnJlbnRDb2x1bW5WYWx1ZSgiS29udG9ncnVwcGUiKTsNCg0KICAgIGlmIChrb" +
                        "250b0dydXBwZSkNCiAgICB7DQogICAgICAgbGJsLkZvbnQgPSBuZXcgRm9udChsYmwuRm9udCwgRm9ud" +
                        "FN0eWxlLkJvbGQpOw0KICAgIH0NCiAgICBlbHNlDQogICAgew0KICAgICAgIGxibC5Gb250ID0gbmV3I" +
                        "EZvbnQobGJsLkZvbnQsIEZvbnRTdHlsZS5SZWd1bGFyKTsNCiAgICB9DQoNCiAgICBpZiAoa29udG9Hc" +
                        "nVwcGUgJiYgKGdydXBwZUtvbnRvSUQgPT0gbnVsbCB8fCBncnVwcGVLb250b0lEID09IFN5c3RlbS5EQ" +
                        "k51bGwuVmFsdWUpKQ0KICAgIHsNCiAgICAgICAgaWYgKGxlZnRCb3JkZXIgJiYgcmlnaHRCb3JkZXIpD" +
                        "QogICAgICAgIHsNCiAgICAgICAgICAgIGxibC5Cb3JkZXJzID0gKChEZXZFeHByZXNzLlh0cmFQcmlud" +
                        "GluZy5Cb3JkZXJTaWRlKSgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5MZWZ0IHwgR" +
                        "GV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5SaWdodCB8IERldkV4cHJlc3MuWHRyYVBya" +
                        "W50aW5nLkJvcmRlclNpZGUuVG9wKSkpOw0KICAgICAgICB9DQogICAgICAgIGVsc2UgaWYgKGxlZnRCb" +
                        "3JkZXIpDQogICAgICAgIHsNCiAgICAgICAgICAgIGxibC5Cb3JkZXJzID0gKChEZXZFeHByZXNzLlh0c" +
                        "mFQcmludGluZy5Cb3JkZXJTaWRlKSgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5MZ" +
                        "WZ0IHwgRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5Ub3ApKSk7DQogICAgICAgIH0NC" +
                        "iAgICAgICAgZWxzZSBpZiAocmlnaHRCb3JkZXIpDQogICAgICAgIHsNCiAgICAgICAgICAgIGxibC5Cb" +
                        "3JkZXJzID0gKChEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlKSgoRGV2RXhwcmVzcy5Yd" +
                        "HJhUHJpbnRpbmcuQm9yZGVyU2lkZS5SaWdodCB8IERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlc" +
                        "lNpZGUuVG9wKSkpOw0KICAgICAgICB9DQogICAgfQ0KICAgIGVsc2UNCiAgICB7DQogICAgICAgIGlmI" +
                        "ChsZWZ0Qm9yZGVyICYmIHJpZ2h0Qm9yZGVyKQ0KICAgICAgICB7DQogICAgICAgICAgICBsYmwuQm9yZ" +
                        "GVycyA9ICgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZSkoKERldkV4cHJlc3MuWHRyY" +
                        "VByaW50aW5nLkJvcmRlclNpZGUuTGVmdCB8IERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZ" +
                        "GUuUmlnaHQpKSk7DQogICAgICAgIH0NCiAgICAgICAgZWxzZSBpZiAobGVmdEJvcmRlcikNCiAgICAgI" +
                        "CAgew0KICAgICAgICAgICAgbGJsLkJvcmRlcnMgPSAoKERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvc" +
                        "mRlclNpZGUpKChEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlLkxlZnQpKSk7DQogICAgI" +
                        "CAgIH0NCiAgICAgICAgZWxzZSBpZiAocmlnaHRCb3JkZXIpDQogICAgICAgIHsNCiAgICAgICAgICAgI" +
                        "GxibC5Cb3JkZXJzID0gKChEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlKSgoRGV2RXhwc" +
                        "mVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5SaWdodCkpKTsNCiAgICAgICAgfQ0KICAgIH0NCn0Br" +
                        "A5wcml2YXRlIHZvaWQgT25CZWZvcmVQcmludChvYmplY3Qgc2VuZGVyLCBTeXN0ZW0uRHJhd2luZy5Qc" +
                        "mludGluZy5QcmludEV2ZW50QXJncyBlKSANCnsNCiAgICBYUkxhYmVsIGxibCA9IGxibERUQmVzdGFuZ" +
                        "EJpczsNCiAgICBib29sIGxlZnRCb3JkZXIgPSB0cnVlOw0KICAgIGJvb2wgcmlnaHRCb3JkZXIgPSB0c" +
                        "nVlOw0KICAgIA0KICAgIG9iamVjdCBncnVwcGVLb250b0lEID0gR2V0Q3VycmVudENvbHVtblZhbHVlK" +
                        "CJHcnVwcGVLb250b0lEIik7DQogICAgYm9vbCBrb250b0dydXBwZSA9IChib29sKUdldEN1cnJlbnRDb" +
                        "2x1bW5WYWx1ZSgiS29udG9ncnVwcGUiKTsNCg0KICAgIGlmIChrb250b0dydXBwZSkNCiAgICB7DQogI" +
                        "CAgICAgbGJsLkZvbnQgPSBuZXcgRm9udChsYmwuRm9udCwgRm9udFN0eWxlLkJvbGQpOw0KICAgIH0NC" +
                        "iAgICBlbHNlDQogICAgew0KICAgICAgIGxibC5Gb250ID0gbmV3IEZvbnQobGJsLkZvbnQsIEZvbnRTd" +
                        "HlsZS5SZWd1bGFyKTsNCiAgICB9DQoNCiAgICBpZiAoa29udG9HcnVwcGUgJiYgKGdydXBwZUtvbnRvS" +
                        "UQgPT0gbnVsbCB8fCBncnVwcGVLb250b0lEID09IFN5c3RlbS5EQk51bGwuVmFsdWUpKQ0KICAgIHsNC" +
                        "iAgICAgICAgaWYgKGxlZnRCb3JkZXIgJiYgcmlnaHRCb3JkZXIpDQogICAgICAgIHsNCiAgICAgICAgI" +
                        "CAgIGxibC5Cb3JkZXJzID0gKChEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlKSgoRGV2R" +
                        "XhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5MZWZ0IHwgRGV2RXhwcmVzcy5YdHJhUHJpbnRpb" +
                        "mcuQm9yZGVyU2lkZS5SaWdodCB8IERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuVG9wK" +
                        "SkpOw0KICAgICAgICB9DQogICAgICAgIGVsc2UgaWYgKGxlZnRCb3JkZXIpDQogICAgICAgIHsNCiAgI" +
                        "CAgICAgICAgIGxibC5Cb3JkZXJzID0gKChEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlK" +
                        "SgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5MZWZ0IHwgRGV2RXhwcmVzcy5YdHJhU" +
                        "HJpbnRpbmcuQm9yZGVyU2lkZS5Ub3ApKSk7DQogICAgICAgIH0NCiAgICAgICAgZWxzZSBpZiAocmlna" +
                        "HRCb3JkZXIpDQogICAgICAgIHsNCiAgICAgICAgICAgIGxibC5Cb3JkZXJzID0gKChEZXZFeHByZXNzL" +
                        "lh0cmFQcmludGluZy5Cb3JkZXJTaWRlKSgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZ" +
                        "S5SaWdodCB8IERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuVG9wKSkpOw0KICAgICAgI" +
                        "CB9DQogICAgfQ0KICAgIGVsc2UNCiAgICB7DQogICAgICAgIGlmIChsZWZ0Qm9yZGVyICYmIHJpZ2h0Q" +
                        "m9yZGVyKQ0KICAgICAgICB7DQogICAgICAgICAgICBsYmwuQm9yZGVycyA9ICgoRGV2RXhwcmVzcy5Yd" +
                        "HJhUHJpbnRpbmcuQm9yZGVyU2lkZSkoKERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuT" +
                        "GVmdCB8IERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuUmlnaHQpKSk7DQogICAgICAgI" +
                        "H0NCiAgICAgICAgZWxzZSBpZiAobGVmdEJvcmRlcikNCiAgICAgICAgew0KICAgICAgICAgICAgbGJsL" +
                        "kJvcmRlcnMgPSAoKERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUpKChEZXZFeHByZXNzL" +
                        "lh0cmFQcmludGluZy5Cb3JkZXJTaWRlLkxlZnQpKSk7DQogICAgICAgIH0NCiAgICAgICAgZWxzZSBpZ" +
                        "iAocmlnaHRCb3JkZXIpDQogICAgICAgIHsNCiAgICAgICAgICAgIGxibC5Cb3JkZXJzID0gKChEZXZFe" +
                        "HByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlKSgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZ" +
                        "GVyU2lkZS5SaWdodCkpKTsNCiAgICAgICAgfQ0KICAgIH0NCn0BrQ5wcml2YXRlIHZvaWQgT25CZWZvc" +
                        "mVQcmludChvYmplY3Qgc2VuZGVyLCBTeXN0ZW0uRHJhd2luZy5QcmludGluZy5QcmludEV2ZW50QXJnc" +
                        "yBlKSANCnsNCiAgICBYUkxhYmVsIGxibCA9IGxibERUQmVzdGFuZFZvbjsNCiAgICBib29sIGxlZnRCb" +
                        "3JkZXIgPSB0cnVlOw0KICAgIGJvb2wgcmlnaHRCb3JkZXIgPSBmYWxzZTsNCiAgICANCiAgICBvYmplY" +
                        "3QgZ3J1cHBlS29udG9JRCA9IEdldEN1cnJlbnRDb2x1bW5WYWx1ZSgiR3J1cHBlS29udG9JRCIpOw0KI" +
                        "CAgIGJvb2wga29udG9HcnVwcGUgPSAoYm9vbClHZXRDdXJyZW50Q29sdW1uVmFsdWUoIktvbnRvZ3J1c" +
                        "HBlIik7DQoNCiAgICBpZiAoa29udG9HcnVwcGUpDQogICAgew0KICAgICAgIGxibC5Gb250ID0gbmV3I" +
                        "EZvbnQobGJsLkZvbnQsIEZvbnRTdHlsZS5Cb2xkKTsNCiAgICB9DQogICAgZWxzZQ0KICAgIHsNCiAgI" +
                        "CAgICBsYmwuRm9udCA9IG5ldyBGb250KGxibC5Gb250LCBGb250U3R5bGUuUmVndWxhcik7DQogICAgf" +
                        "Q0KDQogICAgaWYgKGtvbnRvR3J1cHBlICYmIChncnVwcGVLb250b0lEID09IG51bGwgfHwgZ3J1cHBlS" +
                        "29udG9JRCA9PSBTeXN0ZW0uREJOdWxsLlZhbHVlKSkNCiAgICB7DQogICAgICAgIGlmIChsZWZ0Qm9yZ" +
                        "GVyICYmIHJpZ2h0Qm9yZGVyKQ0KICAgICAgICB7DQogICAgICAgICAgICBsYmwuQm9yZGVycyA9ICgoR" +
                        "GV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZSkoKERldkV4cHJlc3MuWHRyYVByaW50aW5nL" +
                        "kJvcmRlclNpZGUuTGVmdCB8IERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuUmlnaHQgf" +
                        "CBEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlLlRvcCkpKTsNCiAgICAgICAgfQ0KICAgI" +
                        "CAgICBlbHNlIGlmIChsZWZ0Qm9yZGVyKQ0KICAgICAgICB7DQogICAgICAgICAgICBsYmwuQm9yZGVyc" +
                        "yA9ICgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZSkoKERldkV4cHJlc3MuWHRyYVBya" +
                        "W50aW5nLkJvcmRlclNpZGUuTGVmdCB8IERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuV" +
                        "G9wKSkpOw0KICAgICAgICB9DQogICAgICAgIGVsc2UgaWYgKHJpZ2h0Qm9yZGVyKQ0KICAgICAgICB7D" +
                        "QogICAgICAgICAgICBsYmwuQm9yZGVycyA9ICgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU" +
                        "2lkZSkoKERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuUmlnaHQgfCBEZXZFeHByZXNzL" +
                        "lh0cmFQcmludGluZy5Cb3JkZXJTaWRlLlRvcCkpKTsNCiAgICAgICAgfQ0KICAgIH0NCiAgICBlbHNlD" +
                        "QogICAgew0KICAgICAgICBpZiAobGVmdEJvcmRlciAmJiByaWdodEJvcmRlcikNCiAgICAgICAgew0KI" +
                        "CAgICAgICAgICAgbGJsLkJvcmRlcnMgPSAoKERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZ" +
                        "GUpKChEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlLkxlZnQgfCBEZXZFeHByZXNzLlh0c" +
                        "mFQcmludGluZy5Cb3JkZXJTaWRlLlJpZ2h0KSkpOw0KICAgICAgICB9DQogICAgICAgIGVsc2UgaWYgK" +
                        "GxlZnRCb3JkZXIpDQogICAgICAgIHsNCiAgICAgICAgICAgIGxibC5Cb3JkZXJzID0gKChEZXZFeHByZ" +
                        "XNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlKSgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU" +
                        "2lkZS5MZWZ0KSkpOw0KICAgICAgICB9DQogICAgICAgIGVsc2UgaWYgKHJpZ2h0Qm9yZGVyKQ0KICAgI" +
                        "CAgICB7DQogICAgICAgICAgICBsYmwuQm9yZGVycyA9ICgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQ" +
                        "m9yZGVyU2lkZSkoKERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuUmlnaHQpKSk7DQogI" +
                        "CAgICAgIH0NCiAgICB9DQp9AawOcHJpdmF0ZSB2b2lkIE9uQmVmb3JlUHJpbnQob2JqZWN0IHNlbmRlc" +
                        "iwgU3lzdGVtLkRyYXdpbmcuUHJpbnRpbmcuUHJpbnRFdmVudEFyZ3MgZSkgDQp7DQogICAgWFJMYWJlb" +
                        "CBsYmwgPSBsYmxEVEtvbnRvTmFtZTsNCiAgICBib29sIGxlZnRCb3JkZXIgPSB0cnVlOw0KICAgIGJvb" +
                        "2wgcmlnaHRCb3JkZXIgPSBmYWxzZTsNCiAgICANCiAgICBvYmplY3QgZ3J1cHBlS29udG9JRCA9IEdld" +
                        "EN1cnJlbnRDb2x1bW5WYWx1ZSgiR3J1cHBlS29udG9JRCIpOw0KICAgIGJvb2wga29udG9HcnVwcGUgP" +
                        "SAoYm9vbClHZXRDdXJyZW50Q29sdW1uVmFsdWUoIktvbnRvZ3J1cHBlIik7DQoNCiAgICBpZiAoa29ud" +
                        "G9HcnVwcGUpDQogICAgew0KICAgICAgIGxibC5Gb250ID0gbmV3IEZvbnQobGJsLkZvbnQsIEZvbnRTd" +
                        "HlsZS5Cb2xkKTsNCiAgICB9DQogICAgZWxzZQ0KICAgIHsNCiAgICAgICBsYmwuRm9udCA9IG5ldyBGb" +
                        "250KGxibC5Gb250LCBGb250U3R5bGUuUmVndWxhcik7DQogICAgfQ0KDQogICAgaWYgKGtvbnRvR3J1c" +
                        "HBlICYmIChncnVwcGVLb250b0lEID09IG51bGwgfHwgZ3J1cHBlS29udG9JRCA9PSBTeXN0ZW0uREJOd" +
                        "WxsLlZhbHVlKSkNCiAgICB7DQogICAgICAgIGlmIChsZWZ0Qm9yZGVyICYmIHJpZ2h0Qm9yZGVyKQ0KI" +
                        "CAgICAgICB7DQogICAgICAgICAgICBsYmwuQm9yZGVycyA9ICgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpb" +
                        "mcuQm9yZGVyU2lkZSkoKERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuTGVmdCB8IERld" +
                        "kV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuUmlnaHQgfCBEZXZFeHByZXNzLlh0cmFQcmlud" +
                        "GluZy5Cb3JkZXJTaWRlLlRvcCkpKTsNCiAgICAgICAgfQ0KICAgICAgICBlbHNlIGlmIChsZWZ0Qm9yZ" +
                        "GVyKQ0KICAgICAgICB7DQogICAgICAgICAgICBsYmwuQm9yZGVycyA9ICgoRGV2RXhwcmVzcy5YdHJhU" +
                        "HJpbnRpbmcuQm9yZGVyU2lkZSkoKERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuTGVmd" +
                        "CB8IERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuVG9wKSkpOw0KICAgICAgICB9DQogI" +
                        "CAgICAgIGVsc2UgaWYgKHJpZ2h0Qm9yZGVyKQ0KICAgICAgICB7DQogICAgICAgICAgICBsYmwuQm9yZ" +
                        "GVycyA9ICgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZSkoKERldkV4cHJlc3MuWHRyY" +
                        "VByaW50aW5nLkJvcmRlclNpZGUuUmlnaHQgfCBEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTa" +
                        "WRlLlRvcCkpKTsNCiAgICAgICAgfQ0KICAgIH0NCiAgICBlbHNlDQogICAgew0KICAgICAgICBpZiAob" +
                        "GVmdEJvcmRlciAmJiByaWdodEJvcmRlcikNCiAgICAgICAgew0KICAgICAgICAgICAgbGJsLkJvcmRlc" +
                        "nMgPSAoKERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUpKChEZXZFeHByZXNzLlh0cmFQc" +
                        "mludGluZy5Cb3JkZXJTaWRlLkxlZnQgfCBEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlL" +
                        "lJpZ2h0KSkpOw0KICAgICAgICB9DQogICAgICAgIGVsc2UgaWYgKGxlZnRCb3JkZXIpDQogICAgICAgI" +
                        "HsNCiAgICAgICAgICAgIGxibC5Cb3JkZXJzID0gKChEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZ" +
                        "XJTaWRlKSgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5MZWZ0KSkpOw0KICAgICAgI" +
                        "CB9DQogICAgICAgIGVsc2UgaWYgKHJpZ2h0Qm9yZGVyKQ0KICAgICAgICB7DQogICAgICAgICAgICBsY" +
                        "mwuQm9yZGVycyA9ICgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZSkoKERldkV4cHJlc" +
                        "3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuUmlnaHQpKSk7DQogICAgICAgIH0NCiAgICB9DQp9AaoOc" +
                        "HJpdmF0ZSB2b2lkIE9uQmVmb3JlUHJpbnQob2JqZWN0IHNlbmRlciwgU3lzdGVtLkRyYXdpbmcuUHJpb" +
                        "nRpbmcuUHJpbnRFdmVudEFyZ3MgZSkgDQp7DQogICAgWFJMYWJlbCBsYmwgPSBsYmxEVEtvbnRvTnI7D" +
                        "QogICAgYm9vbCBsZWZ0Qm9yZGVyID0gdHJ1ZTsNCiAgICBib29sIHJpZ2h0Qm9yZGVyID0gZmFsc2U7D" +
                        "QogICAgDQogICAgb2JqZWN0IGdydXBwZUtvbnRvSUQgPSBHZXRDdXJyZW50Q29sdW1uVmFsdWUoIkdyd" +
                        "XBwZUtvbnRvSUQiKTsNCiAgICBib29sIGtvbnRvR3J1cHBlID0gKGJvb2wpR2V0Q3VycmVudENvbHVtb" +
                        "lZhbHVlKCJLb250b2dydXBwZSIpOw0KDQogICAgaWYgKGtvbnRvR3J1cHBlKQ0KICAgIHsNCiAgICAgI" +
                        "CBsYmwuRm9udCA9IG5ldyBGb250KGxibC5Gb250LCBGb250U3R5bGUuQm9sZCk7DQogICAgfQ0KICAgI" +
                        "GVsc2UNCiAgICB7DQogICAgICAgbGJsLkZvbnQgPSBuZXcgRm9udChsYmwuRm9udCwgRm9udFN0eWxlL" +
                        "lJlZ3VsYXIpOw0KICAgIH0NCg0KICAgIGlmIChrb250b0dydXBwZSAmJiAoZ3J1cHBlS29udG9JRCA9P" +
                        "SBudWxsIHx8IGdydXBwZUtvbnRvSUQgPT0gU3lzdGVtLkRCTnVsbC5WYWx1ZSkpDQogICAgew0KICAgI" +
                        "CAgICBpZiAobGVmdEJvcmRlciAmJiByaWdodEJvcmRlcikNCiAgICAgICAgew0KICAgICAgICAgICAgb" +
                        "GJsLkJvcmRlcnMgPSAoKERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUpKChEZXZFeHByZ" +
                        "XNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlLkxlZnQgfCBEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb" +
                        "3JkZXJTaWRlLlJpZ2h0IHwgRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5Ub3ApKSk7D" +
                        "QogICAgICAgIH0NCiAgICAgICAgZWxzZSBpZiAobGVmdEJvcmRlcikNCiAgICAgICAgew0KICAgICAgI" +
                        "CAgICAgbGJsLkJvcmRlcnMgPSAoKERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUpKChEZ" +
                        "XZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlLkxlZnQgfCBEZXZFeHByZXNzLlh0cmFQcmlud" +
                        "GluZy5Cb3JkZXJTaWRlLlRvcCkpKTsNCiAgICAgICAgfQ0KICAgICAgICBlbHNlIGlmIChyaWdodEJvc" +
                        "mRlcikNCiAgICAgICAgew0KICAgICAgICAgICAgbGJsLkJvcmRlcnMgPSAoKERldkV4cHJlc3MuWHRyY" +
                        "VByaW50aW5nLkJvcmRlclNpZGUpKChEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlLlJpZ" +
                        "2h0IHwgRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5Ub3ApKSk7DQogICAgICAgIH0NC" +
                        "iAgICB9DQogICAgZWxzZQ0KICAgIHsNCiAgICAgICAgaWYgKGxlZnRCb3JkZXIgJiYgcmlnaHRCb3JkZ" +
                        "XIpDQogICAgICAgIHsNCiAgICAgICAgICAgIGxibC5Cb3JkZXJzID0gKChEZXZFeHByZXNzLlh0cmFQc" +
                        "mludGluZy5Cb3JkZXJTaWRlKSgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5MZWZ0I" +
                        "HwgRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5SaWdodCkpKTsNCiAgICAgICAgfQ0KI" +
                        "CAgICAgICBlbHNlIGlmIChsZWZ0Qm9yZGVyKQ0KICAgICAgICB7DQogICAgICAgICAgICBsYmwuQm9yZ" +
                        "GVycyA9ICgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZSkoKERldkV4cHJlc3MuWHRyY" +
                        "VByaW50aW5nLkJvcmRlclNpZGUuTGVmdCkpKTsNCiAgICAgICAgfQ0KICAgICAgICBlbHNlIGlmIChya" +
                        "WdodEJvcmRlcikNCiAgICAgICAgew0KICAgICAgICAgICAgbGJsLkJvcmRlcnMgPSAoKERldkV4cHJlc" +
                        "3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUpKChEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTa" +
                        "WRlLlJpZ2h0KSkpOw0KICAgICAgICB9DQogICAgfQ0KfQGqDnByaXZhdGUgdm9pZCBPbkJlZm9yZVBya" +
                        "W50KG9iamVjdCBzZW5kZXIsIFN5c3RlbS5EcmF3aW5nLlByaW50aW5nLlByaW50RXZlbnRBcmdzIGUpI" +
                        "A0Kew0KICAgIFhSTGFiZWwgbGJsID0gbGJsRFRadXdhY2hzOw0KICAgIGJvb2wgbGVmdEJvcmRlciA9I" +
                        "HRydWU7DQogICAgYm9vbCByaWdodEJvcmRlciA9IGZhbHNlOw0KICAgIA0KICAgIG9iamVjdCBncnVwc" +
                        "GVLb250b0lEID0gR2V0Q3VycmVudENvbHVtblZhbHVlKCJHcnVwcGVLb250b0lEIik7DQogICAgYm9vb" +
                        "CBrb250b0dydXBwZSA9IChib29sKUdldEN1cnJlbnRDb2x1bW5WYWx1ZSgiS29udG9ncnVwcGUiKTsNC" +
                        "g0KICAgIGlmIChrb250b0dydXBwZSkNCiAgICB7DQogICAgICAgbGJsLkZvbnQgPSBuZXcgRm9udChsY" +
                        "mwuRm9udCwgRm9udFN0eWxlLkJvbGQpOw0KICAgIH0NCiAgICBlbHNlDQogICAgew0KICAgICAgIGxib" +
                        "C5Gb250ID0gbmV3IEZvbnQobGJsLkZvbnQsIEZvbnRTdHlsZS5SZWd1bGFyKTsNCiAgICB9DQoNCiAgI" +
                        "CBpZiAoa29udG9HcnVwcGUgJiYgKGdydXBwZUtvbnRvSUQgPT0gbnVsbCB8fCBncnVwcGVLb250b0lEI" +
                        "D09IFN5c3RlbS5EQk51bGwuVmFsdWUpKQ0KICAgIHsNCiAgICAgICAgaWYgKGxlZnRCb3JkZXIgJiYgc" +
                        "mlnaHRCb3JkZXIpDQogICAgICAgIHsNCiAgICAgICAgICAgIGxibC5Cb3JkZXJzID0gKChEZXZFeHByZ" +
                        "XNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlKSgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU" +
                        "2lkZS5MZWZ0IHwgRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5SaWdodCB8IERldkV4c" +
                        "HJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuVG9wKSkpOw0KICAgICAgICB9DQogICAgICAgIGVsc" +
                        "2UgaWYgKGxlZnRCb3JkZXIpDQogICAgICAgIHsNCiAgICAgICAgICAgIGxibC5Cb3JkZXJzID0gKChEZ" +
                        "XZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlKSgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQ" +
                        "m9yZGVyU2lkZS5MZWZ0IHwgRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5Ub3ApKSk7D" +
                        "QogICAgICAgIH0NCiAgICAgICAgZWxzZSBpZiAocmlnaHRCb3JkZXIpDQogICAgICAgIHsNCiAgICAgI" +
                        "CAgICAgIGxibC5Cb3JkZXJzID0gKChEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlKSgoR" +
                        "GV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5SaWdodCB8IERldkV4cHJlc3MuWHRyYVBya" +
                        "W50aW5nLkJvcmRlclNpZGUuVG9wKSkpOw0KICAgICAgICB9DQogICAgfQ0KICAgIGVsc2UNCiAgICB7D" +
                        "QogICAgICAgIGlmIChsZWZ0Qm9yZGVyICYmIHJpZ2h0Qm9yZGVyKQ0KICAgICAgICB7DQogICAgICAgI" +
                        "CAgICBsYmwuQm9yZGVycyA9ICgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZSkoKERld" +
                        "kV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuTGVmdCB8IERldkV4cHJlc3MuWHRyYVByaW50a" +
                        "W5nLkJvcmRlclNpZGUuUmlnaHQpKSk7DQogICAgICAgIH0NCiAgICAgICAgZWxzZSBpZiAobGVmdEJvc" +
                        "mRlcikNCiAgICAgICAgew0KICAgICAgICAgICAgbGJsLkJvcmRlcnMgPSAoKERldkV4cHJlc3MuWHRyY" +
                        "VByaW50aW5nLkJvcmRlclNpZGUpKChEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlLkxlZ" +
                        "nQpKSk7DQogICAgICAgIH0NCiAgICAgICAgZWxzZSBpZiAocmlnaHRCb3JkZXIpDQogICAgICAgIHsNC" +
                        "iAgICAgICAgICAgIGxibC5Cb3JkZXJzID0gKChEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTa" +
                        "WRlKSgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5SaWdodCkpKTsNCiAgICAgICAgf" +
                        "Q0KICAgIH0NCn0BiARERUNMQVJFIEBLYlBlcmlvZGVJRCBJTlQ7DQpERUNMQVJFIEBEYXR1bVZvbiBEQ" +
                        "VRFVElNRTsNCkRFQ0xBUkUgQERhdHVtQmlzIERBVEVUSU1FOw0KREVDTEFSRSBATnVyTWl0QnVjaHVuZ" +
                        "2VuIEJJVDsNCkRFQ0xBUkUgQE9obmVLdG9HcnVwcGVuIEJJVDsNCg0KU0VUIEBLYlBlcmlvZGVJRCAgI" +
                        "CAgPSBudWxsOyAgICAgLS0zMC0tDQpTRVQgQERhdHVtVm9uICAgICAgICA9IG51bGw7ICAgICAgICAtL" +
                        "ScyMDA4MDcwMSctLQ0KU0VUIEBEYXR1bUJpcyAgICAgICAgPSBudWxsOyAgICAgICAgLS0nMjAwODA3M" +
                        "DEnLS0NClNFVCBATnVyTWl0QnVjaHVuZ2VuID0gbnVsbDsgLS0xLS0NClNFVCBAT2huZUt0b0dydXBwZ" +
                        "W4gID0gMDsgLS0gVE9ETyEgZ2VodCBuaWNodCB3ZWdlbiBTb3J0aWVydW5nISBudWxsICAtLTAtLQ0KD" +
                        "QpFWEVDIGRiby5zcEtiR2V0QmlsYW56RXJmb2xnIEBLYlBlcmlvZGVJRCwgQERhdHVtVm9uLCBARGF0d" +
                        "W1CaXMsIEBOdXJNaXRCdWNodW5nZW4sIEBPaG5lS3RvR3J1cHBlbiwgMTsgLS0gQmlsYW56";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.lblDTBestandVon = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDTZuwachs = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDTKontoNr = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDTBestandBis = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDTAbgang = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDTKontoName = new DevExpress.XtraReports.UI.XRLabel();
            this.lblRHDatumBis = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHKlibu = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHInstName = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHInstPlzOrt = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHInstStrasse = new DevExpress.XtraReports.UI.XRLabel();
            this.panColHeaders = new DevExpress.XtraReports.UI.XRPanel();
            this.lblPHBilanzEr = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHVeraenderung = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHBestandVon = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHZuwachs = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHKonto = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHAbgang = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHBestandBis = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHBezeichnung = new DevExpress.XtraReports.UI.XRLabel();
            this.linePageFooter = new DevExpress.XtraReports.UI.XRLine();
            this.lblPFDruckDatum = new DevExpress.XtraReports.UI.XRLabel();
            this.infoPFPageInfo = new DevExpress.XtraReports.UI.XRPageInfo();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblDTBestandVon,
                        this.lblDTZuwachs,
                        this.lblDTKontoNr,
                        this.lblDTBestandBis,
                        this.lblDTAbgang,
                        this.lblDTKontoName});
            this.Detail.Height = 25;
            this.Detail.Name = "Detail";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblRHDatumBis,
                        this.lblPHKlibu,
                        this.lblPHInstName,
                        this.lblPHInstPlzOrt,
                        this.lblPHInstStrasse,
                        this.panColHeaders,
                        this.lblPHBilanzEr});
            this.PageHeader.Height = 127;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.linePageFooter,
                        this.lblPFDruckDatum,
                        this.infoPFPageInfo});
            this.PageFooter.Height = 38;
            this.PageFooter.Name = "PageFooter";
            // 
            // lblDTBestandVon
            // 
            this.lblDTBestandVon.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.lblDTBestandVon.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Anfangsbestand", "{0:n2}")});
            this.lblDTBestandVon.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDTBestandVon.Location = new System.Drawing.Point(460, 0);
            this.lblDTBestandVon.Name = "lblDTBestandVon";
            this.lblDTBestandVon.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDTBestandVon.ParentStyleUsing.UseBorders = false;
            this.lblDTBestandVon.ParentStyleUsing.UseFont = false;
            this.lblDTBestandVon.Scripts.OnBeforePrint = resources.GetString("lblDTBestandVon.Scripts.OnBeforePrint");
            this.lblDTBestandVon.Size = new System.Drawing.Size(110, 25);
            this.lblDTBestandVon.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblDTZuwachs
            // 
            this.lblDTZuwachs.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.lblDTZuwachs.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Zuwachs", "{0:n2}")});
            this.lblDTZuwachs.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDTZuwachs.Location = new System.Drawing.Point(570, 0);
            this.lblDTZuwachs.Name = "lblDTZuwachs";
            this.lblDTZuwachs.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDTZuwachs.ParentStyleUsing.UseBorders = false;
            this.lblDTZuwachs.ParentStyleUsing.UseFont = false;
            this.lblDTZuwachs.Scripts.OnBeforePrint = resources.GetString("lblDTZuwachs.Scripts.OnBeforePrint");
            this.lblDTZuwachs.Size = new System.Drawing.Size(110, 25);
            this.lblDTZuwachs.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblDTKontoNr
            // 
            this.lblDTKontoNr.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.lblDTKontoNr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KontoNr", "")});
            this.lblDTKontoNr.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDTKontoNr.Location = new System.Drawing.Point(0, 0);
            this.lblDTKontoNr.Name = "lblDTKontoNr";
            this.lblDTKontoNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDTKontoNr.ParentStyleUsing.UseBorders = false;
            this.lblDTKontoNr.ParentStyleUsing.UseFont = false;
            this.lblDTKontoNr.Scripts.OnBeforePrint = resources.GetString("lblDTKontoNr.Scripts.OnBeforePrint");
            this.lblDTKontoNr.Size = new System.Drawing.Size(142, 25);
            this.lblDTKontoNr.StyleName = "xrControlStyle1";
            this.lblDTKontoNr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblDTBestandBis
            // 
            this.lblDTBestandBis.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
            this.lblDTBestandBis.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Endbestand", "{0:n2}")});
            this.lblDTBestandBis.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDTBestandBis.Location = new System.Drawing.Point(790, 0);
            this.lblDTBestandBis.Name = "lblDTBestandBis";
            this.lblDTBestandBis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDTBestandBis.ParentStyleUsing.UseBorders = false;
            this.lblDTBestandBis.ParentStyleUsing.UseFont = false;
            this.lblDTBestandBis.Scripts.OnBeforePrint = resources.GetString("lblDTBestandBis.Scripts.OnBeforePrint");
            this.lblDTBestandBis.Size = new System.Drawing.Size(110, 25);
            this.lblDTBestandBis.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblDTAbgang
            // 
            this.lblDTAbgang.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.lblDTAbgang.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Abgang", "{0:n2}")});
            this.lblDTAbgang.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDTAbgang.Location = new System.Drawing.Point(680, 0);
            this.lblDTAbgang.Name = "lblDTAbgang";
            this.lblDTAbgang.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDTAbgang.ParentStyleUsing.UseBorders = false;
            this.lblDTAbgang.ParentStyleUsing.UseFont = false;
            this.lblDTAbgang.Scripts.OnBeforePrint = resources.GetString("lblDTAbgang.Scripts.OnBeforePrint");
            this.lblDTAbgang.Size = new System.Drawing.Size(110, 25);
            this.lblDTAbgang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblDTKontoName
            // 
            this.lblDTKontoName.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.lblDTKontoName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KontoName", "")});
            this.lblDTKontoName.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDTKontoName.Location = new System.Drawing.Point(142, 0);
            this.lblDTKontoName.Name = "lblDTKontoName";
            this.lblDTKontoName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDTKontoName.ParentStyleUsing.UseBorders = false;
            this.lblDTKontoName.ParentStyleUsing.UseFont = false;
            this.lblDTKontoName.Scripts.OnBeforePrint = resources.GetString("lblDTKontoName.Scripts.OnBeforePrint");
            this.lblDTKontoName.Size = new System.Drawing.Size(318, 25);
            this.lblDTKontoName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
            // lblPHKlibu
            // 
            this.lblPHKlibu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblPHKlibu.Location = new System.Drawing.Point(542, 0);
            this.lblPHKlibu.Name = "lblPHKlibu";
            this.lblPHKlibu.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPHKlibu.ParentStyleUsing.UseFont = false;
            this.lblPHKlibu.Size = new System.Drawing.Size(358, 25);
            this.lblPHKlibu.Text = "Klientenbuchhaltung";
            this.lblPHKlibu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblPHInstName
            // 
            this.lblPHInstName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "InstName", "")});
            this.lblPHInstName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPHInstName.Location = new System.Drawing.Point(0, 0);
            this.lblPHInstName.Name = "lblPHInstName";
            this.lblPHInstName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPHInstName.ParentStyleUsing.UseFont = false;
            this.lblPHInstName.Size = new System.Drawing.Size(533, 25);
            this.lblPHInstName.Text = "lblPHInstName";
            // 
            // lblPHInstPlzOrt
            // 
            this.lblPHInstPlzOrt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "InstPLZOrt", "")});
            this.lblPHInstPlzOrt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPHInstPlzOrt.Location = new System.Drawing.Point(0, 50);
            this.lblPHInstPlzOrt.Name = "lblPHInstPlzOrt";
            this.lblPHInstPlzOrt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPHInstPlzOrt.ParentStyleUsing.UseFont = false;
            this.lblPHInstPlzOrt.Size = new System.Drawing.Size(533, 25);
            this.lblPHInstPlzOrt.Text = "lblPHInstPlzOrt";
            // 
            // lblPHInstStrasse
            // 
            this.lblPHInstStrasse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "InstStrasse", "")});
            this.lblPHInstStrasse.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPHInstStrasse.Location = new System.Drawing.Point(0, 25);
            this.lblPHInstStrasse.Name = "lblPHInstStrasse";
            this.lblPHInstStrasse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPHInstStrasse.ParentStyleUsing.UseFont = false;
            this.lblPHInstStrasse.Size = new System.Drawing.Size(533, 25);
            this.lblPHInstStrasse.Text = "lblPHInstStrasse";
            // 
            // panColHeaders
            // 
            this.panColHeaders.BackColor = System.Drawing.Color.Gainsboro;
            this.panColHeaders.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.panColHeaders.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblPHVeraenderung,
                        this.lblPHBestandVon,
                        this.lblPHZuwachs,
                        this.lblPHKonto,
                        this.lblPHAbgang,
                        this.lblPHBestandBis,
                        this.lblPHBezeichnung});
            this.panColHeaders.Location = new System.Drawing.Point(0, 94);
            this.panColHeaders.Name = "panColHeaders";
            this.panColHeaders.ParentStyleUsing.UseBackColor = false;
            this.panColHeaders.ParentStyleUsing.UseBorders = false;
            this.panColHeaders.Size = new System.Drawing.Size(900, 33);
            // 
            // lblPHBilanzEr
            // 
            this.lblPHBilanzEr.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPHBilanzEr.Location = new System.Drawing.Point(542, 25);
            this.lblPHBilanzEr.Name = "lblPHBilanzEr";
            this.lblPHBilanzEr.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPHBilanzEr.ParentStyleUsing.UseFont = false;
            this.lblPHBilanzEr.Size = new System.Drawing.Size(358, 25);
            this.lblPHBilanzEr.Text = "Bestandesrechnung";
            this.lblPHBilanzEr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblPHVeraenderung
            // 
            this.lblPHVeraenderung.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lblPHVeraenderung.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblPHVeraenderung.Location = new System.Drawing.Point(570, 0);
            this.lblPHVeraenderung.Name = "lblPHVeraenderung";
            this.lblPHVeraenderung.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPHVeraenderung.ParentStyleUsing.UseBorders = false;
            this.lblPHVeraenderung.ParentStyleUsing.UseFont = false;
            this.lblPHVeraenderung.Size = new System.Drawing.Size(220, 17);
            this.lblPHVeraenderung.Text = "    Veränderung";
            this.lblPHVeraenderung.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lblPHBestandVon
            // 
            this.lblPHBestandVon.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.lblPHBestandVon.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "DatumVon", "Bestand {0:d}")});
            this.lblPHBestandVon.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblPHBestandVon.Location = new System.Drawing.Point(460, 0);
            this.lblPHBestandVon.Name = "lblPHBestandVon";
            this.lblPHBestandVon.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPHBestandVon.ParentStyleUsing.UseBorders = false;
            this.lblPHBestandVon.ParentStyleUsing.UseFont = false;
            this.lblPHBestandVon.Size = new System.Drawing.Size(110, 33);
            this.lblPHBestandVon.Text = "lblPHBestandVon";
            this.lblPHBestandVon.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblPHZuwachs
            // 
            this.lblPHZuwachs.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.lblPHZuwachs.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblPHZuwachs.Location = new System.Drawing.Point(570, 16);
            this.lblPHZuwachs.Name = "lblPHZuwachs";
            this.lblPHZuwachs.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 0, 100F);
            this.lblPHZuwachs.ParentStyleUsing.UseBorders = false;
            this.lblPHZuwachs.ParentStyleUsing.UseFont = false;
            this.lblPHZuwachs.Size = new System.Drawing.Size(110, 19);
            this.lblPHZuwachs.Text = "Zuwachs";
            this.lblPHZuwachs.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblPHKonto
            // 
            this.lblPHKonto.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblPHKonto.Location = new System.Drawing.Point(0, 0);
            this.lblPHKonto.Name = "lblPHKonto";
            this.lblPHKonto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPHKonto.ParentStyleUsing.UseBorders = false;
            this.lblPHKonto.ParentStyleUsing.UseFont = false;
            this.lblPHKonto.Size = new System.Drawing.Size(142, 33);
            this.lblPHKonto.Text = "Konto";
            // 
            // lblPHAbgang
            // 
            this.lblPHAbgang.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.lblPHAbgang.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblPHAbgang.Location = new System.Drawing.Point(680, 16);
            this.lblPHAbgang.Name = "lblPHAbgang";
            this.lblPHAbgang.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 1, 0, 100F);
            this.lblPHAbgang.ParentStyleUsing.UseBorders = false;
            this.lblPHAbgang.ParentStyleUsing.UseFont = false;
            this.lblPHAbgang.Size = new System.Drawing.Size(110, 19);
            this.lblPHAbgang.Text = "Abgang";
            this.lblPHAbgang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblPHBestandBis
            // 
            this.lblPHBestandBis.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.lblPHBestandBis.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "DatumBis", "Bestand {0:d}")});
            this.lblPHBestandBis.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblPHBestandBis.Location = new System.Drawing.Point(790, 0);
            this.lblPHBestandBis.Name = "lblPHBestandBis";
            this.lblPHBestandBis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPHBestandBis.ParentStyleUsing.UseBorders = false;
            this.lblPHBestandBis.ParentStyleUsing.UseFont = false;
            this.lblPHBestandBis.Size = new System.Drawing.Size(110, 33);
            this.lblPHBestandBis.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblPHBezeichnung
            // 
            this.lblPHBezeichnung.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.lblPHBezeichnung.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblPHBezeichnung.Location = new System.Drawing.Point(142, 0);
            this.lblPHBezeichnung.Name = "lblPHBezeichnung";
            this.lblPHBezeichnung.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPHBezeichnung.ParentStyleUsing.UseBorders = false;
            this.lblPHBezeichnung.ParentStyleUsing.UseFont = false;
            this.lblPHBezeichnung.Size = new System.Drawing.Size(318, 35);
            this.lblPHBezeichnung.Text = "Bezeichnung";
            // 
            // linePageFooter
            // 
            this.linePageFooter.Location = new System.Drawing.Point(0, 0);
            this.linePageFooter.Name = "linePageFooter";
            this.linePageFooter.Size = new System.Drawing.Size(900, 9);
            // 
            // lblPFDruckDatum
            // 
            this.lblPFDruckDatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "DruckDatum", "")});
            this.lblPFDruckDatum.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPFDruckDatum.Location = new System.Drawing.Point(0, 18);
            this.lblPFDruckDatum.Name = "lblPFDruckDatum";
            this.lblPFDruckDatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPFDruckDatum.ParentStyleUsing.UseFont = false;
            this.lblPFDruckDatum.Size = new System.Drawing.Size(400, 17);
            // 
            // infoPFPageInfo
            // 
            this.infoPFPageInfo.Font = new System.Drawing.Font("Arial", 8F);
            this.infoPFPageInfo.Format = "Seite {0} von {1}";
            this.infoPFPageInfo.Location = new System.Drawing.Point(800, 17);
            this.infoPFPageInfo.Name = "infoPFPageInfo";
            this.infoPFPageInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.infoPFPageInfo.ParentStyleUsing.UseFont = false;
            this.infoPFPageInfo.Size = new System.Drawing.Size(100, 17);
            this.infoPFPageInfo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
}
' , ParameterXML =  N'<?xml version="1.0" standalone="yes" ?>
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
</NewDataSet>' , SQLquery =  N'DECLARE @KbPeriodeID INT;
DECLARE @DatumVon DATETIME;
DECLARE @DatumBis DATETIME;
DECLARE @NurMitBuchungen BIT;
DECLARE @OhneKtoGruppen BIT;

SET @KbPeriodeID     = {kbPeriodeID};     --30--
SET @DatumVon        = {DatumVon};        --''20080701''--
SET @DatumBis        = {DatumBis};        --''20080701''--
SET @NurMitBuchungen = {NurMitBuchungen}; --1--
SET @OhneKtoGruppen  = 0; -- TODO! geht nicht wegen Sortierung! {OhneKtoGruppen}  --0--

EXEC dbo.spKbGetBilanzErfolg @KbPeriodeID, @DatumVon, @DatumBis, @NurMitBuchungen, @OhneKtoGruppen, 1; -- Bilanz' , ContextForms =  N'CtlQueryKbBilanzErfolg,CtlQueryKbBilanzErfolg_Bilanz' , ParentReportName =  null , ReportSortKey = 3, System =  0 
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'KBBestandesrechnung' ;


