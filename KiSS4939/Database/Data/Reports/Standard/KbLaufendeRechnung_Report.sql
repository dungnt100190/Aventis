-- Insert Script for KBLaufendeRechnung
-- MD5:0X09B451BD85B3F1292CFEEA5718B51D85_0XF51BD69AF867D9B1333B8C010BA34798_0X25E8DEA6029E277DF6B581C57AFFBED8
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'KBLaufendeRechnung') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('KBLaufendeRechnung', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'KBLaufendeRechnung';
--SQLCHECK_IGNORE--
UPDATE QRY
SET QueryName =  N'KBLaufendeRechnung' , UserText =  N'KB - Laufende Rechnung' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
        private DevExpress.XtraReports.UI.XRLabel lblDTAufwand;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel lblDTKontoNr;
        private DevExpress.XtraReports.UI.XRLabel lblDTErtrag;
        private DevExpress.XtraReports.UI.XRLabel lblDTKontoName;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel lblRHDatumBis;
        private DevExpress.XtraReports.UI.XRLabel lblPHKlibu;
        private DevExpress.XtraReports.UI.XRLabel lblPHInstName;
        private DevExpress.XtraReports.UI.XRLabel lblPHInstPlzOrt;
        private DevExpress.XtraReports.UI.XRLabel lblPHInstStrasse;
        private DevExpress.XtraReports.UI.XRPanel panColHeaders;
        private DevExpress.XtraReports.UI.XRLabel lblPHAufwand;
        private DevExpress.XtraReports.UI.XRLabel lblPHKonto;
        private DevExpress.XtraReports.UI.XRLabel lblPHErtrag;
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
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAAFAAAAAAAAAFBBRFBBRFATtE6kD" +
                        "3z42fTVBuvM0mz31YmmZiYBAADdAAAAkAAAAAAAAABJAAAAOQIAAERsAGIAbABEAFQAQQB1AGYAdwBhA" +
                        "G4AZAAuAFMAYwByAGkAcAB0AHMALgBPAG4AQgBlAGYAbwByAGUAUAByAGkAbgB0AAAAAABCbABiAGwAR" +
                        "ABUAEUAcgB0AHIAYQBnAC4AUwBjAHIAaQBwAHQAcwAuAE8AbgBCAGUAZgBvAHIAZQBQAHIAaQBuAHQAL" +
                        "QcAAEhsAGIAbABEAFQASwBvAG4AdABvAE4AYQBtAGUALgBTAGMAcgBpAHAAdABzAC4ATwBuAEIAZQBmA" +
                        "G8AcgBlAFAAcgBpAG4AdABYDgAARGwAYgBsAEQAVABLAG8AbgB0AG8ATgByAC4AUwBjAHIAaQBwAHQAc" +
                        "wAuAE8AbgBCAGUAZgBvAHIAZQBQAHIAaQBuAHQAhxUAADJzAHEAbABRAHUAZQByAHkAMQAuAFMAZQBsA" +
                        "GUAYwB0AFMAdABhAHQAZQBtAGUAbgB0ALQcAAABqg5wcml2YXRlIHZvaWQgT25CZWZvcmVQcmludChvY" +
                        "mplY3Qgc2VuZGVyLCBTeXN0ZW0uRHJhd2luZy5QcmludGluZy5QcmludEV2ZW50QXJncyBlKSANCnsNC" +
                        "iAgICBYUkxhYmVsIGxibCA9IGxibERUQXVmd2FuZDsNCiAgICBib29sIGxlZnRCb3JkZXIgPSB0cnVlO" +
                        "w0KICAgIGJvb2wgcmlnaHRCb3JkZXIgPSBmYWxzZTsNCiAgICANCiAgICBvYmplY3QgZ3J1cHBlS29ud" +
                        "G9JRCA9IEdldEN1cnJlbnRDb2x1bW5WYWx1ZSgiR3J1cHBlS29udG9JRCIpOw0KICAgIGJvb2wga29ud" +
                        "G9HcnVwcGUgPSAoYm9vbClHZXRDdXJyZW50Q29sdW1uVmFsdWUoIktvbnRvZ3J1cHBlIik7DQoNCiAgI" +
                        "CBpZiAoa29udG9HcnVwcGUpDQogICAgew0KICAgICAgIGxibC5Gb250ID0gbmV3IEZvbnQobGJsLkZvb" +
                        "nQsIEZvbnRTdHlsZS5Cb2xkKTsNCiAgICB9DQogICAgZWxzZQ0KICAgIHsNCiAgICAgICBsYmwuRm9ud" +
                        "CA9IG5ldyBGb250KGxibC5Gb250LCBGb250U3R5bGUuUmVndWxhcik7DQogICAgfQ0KDQogICAgaWYgK" +
                        "GtvbnRvR3J1cHBlICYmIChncnVwcGVLb250b0lEID09IG51bGwgfHwgZ3J1cHBlS29udG9JRCA9PSBTe" +
                        "XN0ZW0uREJOdWxsLlZhbHVlKSkNCiAgICB7DQogICAgICAgIGlmIChsZWZ0Qm9yZGVyICYmIHJpZ2h0Q" +
                        "m9yZGVyKQ0KICAgICAgICB7DQogICAgICAgICAgICBsYmwuQm9yZGVycyA9ICgoRGV2RXhwcmVzcy5Yd" +
                        "HJhUHJpbnRpbmcuQm9yZGVyU2lkZSkoKERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuT" +
                        "GVmdCB8IERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuUmlnaHQgfCBEZXZFeHByZXNzL" +
                        "lh0cmFQcmludGluZy5Cb3JkZXJTaWRlLlRvcCkpKTsNCiAgICAgICAgfQ0KICAgICAgICBlbHNlIGlmI" +
                        "ChsZWZ0Qm9yZGVyKQ0KICAgICAgICB7DQogICAgICAgICAgICBsYmwuQm9yZGVycyA9ICgoRGV2RXhwc" +
                        "mVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZSkoKERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlc" +
                        "lNpZGUuTGVmdCB8IERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuVG9wKSkpOw0KICAgI" +
                        "CAgICB9DQogICAgICAgIGVsc2UgaWYgKHJpZ2h0Qm9yZGVyKQ0KICAgICAgICB7DQogICAgICAgICAgI" +
                        "CBsYmwuQm9yZGVycyA9ICgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZSkoKERldkV4c" +
                        "HJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuUmlnaHQgfCBEZXZFeHByZXNzLlh0cmFQcmludGluZ" +
                        "y5Cb3JkZXJTaWRlLlRvcCkpKTsNCiAgICAgICAgfQ0KICAgIH0NCiAgICBlbHNlDQogICAgew0KICAgI" +
                        "CAgICBpZiAobGVmdEJvcmRlciAmJiByaWdodEJvcmRlcikNCiAgICAgICAgew0KICAgICAgICAgICAgb" +
                        "GJsLkJvcmRlcnMgPSAoKERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUpKChEZXZFeHByZ" +
                        "XNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlLkxlZnQgfCBEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb" +
                        "3JkZXJTaWRlLlJpZ2h0KSkpOw0KICAgICAgICB9DQogICAgICAgIGVsc2UgaWYgKGxlZnRCb3JkZXIpD" +
                        "QogICAgICAgIHsNCiAgICAgICAgICAgIGxibC5Cb3JkZXJzID0gKChEZXZFeHByZXNzLlh0cmFQcmlud" +
                        "GluZy5Cb3JkZXJTaWRlKSgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5MZWZ0KSkpO" +
                        "w0KICAgICAgICB9DQogICAgICAgIGVsc2UgaWYgKHJpZ2h0Qm9yZGVyKQ0KICAgICAgICB7DQogICAgI" +
                        "CAgICAgICBsYmwuQm9yZGVycyA9ICgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZSkoK" +
                        "ERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuUmlnaHQpKSk7DQogICAgICAgIH0NCiAgI" +
                        "CB9DQp9AagOcHJpdmF0ZSB2b2lkIE9uQmVmb3JlUHJpbnQob2JqZWN0IHNlbmRlciwgU3lzdGVtLkRyY" +
                        "XdpbmcuUHJpbnRpbmcuUHJpbnRFdmVudEFyZ3MgZSkgDQp7DQogICAgWFJMYWJlbCBsYmwgPSBsYmxEV" +
                        "EVydHJhZzsNCiAgICBib29sIGxlZnRCb3JkZXIgPSB0cnVlOw0KICAgIGJvb2wgcmlnaHRCb3JkZXIgP" +
                        "SB0cnVlOw0KICAgIA0KICAgIG9iamVjdCBncnVwcGVLb250b0lEID0gR2V0Q3VycmVudENvbHVtblZhb" +
                        "HVlKCJHcnVwcGVLb250b0lEIik7DQogICAgYm9vbCBrb250b0dydXBwZSA9IChib29sKUdldEN1cnJlb" +
                        "nRDb2x1bW5WYWx1ZSgiS29udG9ncnVwcGUiKTsNCg0KICAgIGlmIChrb250b0dydXBwZSkNCiAgICB7D" +
                        "QogICAgICAgbGJsLkZvbnQgPSBuZXcgRm9udChsYmwuRm9udCwgRm9udFN0eWxlLkJvbGQpOw0KICAgI" +
                        "H0NCiAgICBlbHNlDQogICAgew0KICAgICAgIGxibC5Gb250ID0gbmV3IEZvbnQobGJsLkZvbnQsIEZvb" +
                        "nRTdHlsZS5SZWd1bGFyKTsNCiAgICB9DQoNCiAgICBpZiAoa29udG9HcnVwcGUgJiYgKGdydXBwZUtvb" +
                        "nRvSUQgPT0gbnVsbCB8fCBncnVwcGVLb250b0lEID09IFN5c3RlbS5EQk51bGwuVmFsdWUpKQ0KICAgI" +
                        "HsNCiAgICAgICAgaWYgKGxlZnRCb3JkZXIgJiYgcmlnaHRCb3JkZXIpDQogICAgICAgIHsNCiAgICAgI" +
                        "CAgICAgIGxibC5Cb3JkZXJzID0gKChEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlKSgoR" +
                        "GV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5MZWZ0IHwgRGV2RXhwcmVzcy5YdHJhUHJpb" +
                        "nRpbmcuQm9yZGVyU2lkZS5SaWdodCB8IERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuV" +
                        "G9wKSkpOw0KICAgICAgICB9DQogICAgICAgIGVsc2UgaWYgKGxlZnRCb3JkZXIpDQogICAgICAgIHsNC" +
                        "iAgICAgICAgICAgIGxibC5Cb3JkZXJzID0gKChEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTa" +
                        "WRlKSgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5MZWZ0IHwgRGV2RXhwcmVzcy5Yd" +
                        "HJhUHJpbnRpbmcuQm9yZGVyU2lkZS5Ub3ApKSk7DQogICAgICAgIH0NCiAgICAgICAgZWxzZSBpZiAoc" +
                        "mlnaHRCb3JkZXIpDQogICAgICAgIHsNCiAgICAgICAgICAgIGxibC5Cb3JkZXJzID0gKChEZXZFeHByZ" +
                        "XNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlKSgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU" +
                        "2lkZS5SaWdodCB8IERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuVG9wKSkpOw0KICAgI" +
                        "CAgICB9DQogICAgfQ0KICAgIGVsc2UNCiAgICB7DQogICAgICAgIGlmIChsZWZ0Qm9yZGVyICYmIHJpZ" +
                        "2h0Qm9yZGVyKQ0KICAgICAgICB7DQogICAgICAgICAgICBsYmwuQm9yZGVycyA9ICgoRGV2RXhwcmVzc" +
                        "y5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZSkoKERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZ" +
                        "GUuTGVmdCB8IERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuUmlnaHQpKSk7DQogICAgI" +
                        "CAgIH0NCiAgICAgICAgZWxzZSBpZiAobGVmdEJvcmRlcikNCiAgICAgICAgew0KICAgICAgICAgICAgb" +
                        "GJsLkJvcmRlcnMgPSAoKERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUpKChEZXZFeHByZ" +
                        "XNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlLkxlZnQpKSk7DQogICAgICAgIH0NCiAgICAgICAgZWxzZ" +
                        "SBpZiAocmlnaHRCb3JkZXIpDQogICAgICAgIHsNCiAgICAgICAgICAgIGxibC5Cb3JkZXJzID0gKChEZ" +
                        "XZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlKSgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQ" +
                        "m9yZGVyU2lkZS5SaWdodCkpKTsNCiAgICAgICAgfQ0KICAgIH0NCn0BrA5wcml2YXRlIHZvaWQgT25CZ" +
                        "WZvcmVQcmludChvYmplY3Qgc2VuZGVyLCBTeXN0ZW0uRHJhd2luZy5QcmludGluZy5QcmludEV2ZW50Q" +
                        "XJncyBlKSANCnsNCiAgICBYUkxhYmVsIGxibCA9IGxibERUS29udG9OYW1lOw0KICAgIGJvb2wgbGVmd" +
                        "EJvcmRlciA9IHRydWU7DQogICAgYm9vbCByaWdodEJvcmRlciA9IGZhbHNlOw0KICAgIA0KICAgIG9ia" +
                        "mVjdCBncnVwcGVLb250b0lEID0gR2V0Q3VycmVudENvbHVtblZhbHVlKCJHcnVwcGVLb250b0lEIik7D" +
                        "QogICAgYm9vbCBrb250b0dydXBwZSA9IChib29sKUdldEN1cnJlbnRDb2x1bW5WYWx1ZSgiS29udG9nc" +
                        "nVwcGUiKTsNCg0KICAgIGlmIChrb250b0dydXBwZSkNCiAgICB7DQogICAgICAgbGJsLkZvbnQgPSBuZ" +
                        "XcgRm9udChsYmwuRm9udCwgRm9udFN0eWxlLkJvbGQpOw0KICAgIH0NCiAgICBlbHNlDQogICAgew0KI" +
                        "CAgICAgIGxibC5Gb250ID0gbmV3IEZvbnQobGJsLkZvbnQsIEZvbnRTdHlsZS5SZWd1bGFyKTsNCiAgI" +
                        "CB9DQoNCiAgICBpZiAoa29udG9HcnVwcGUgJiYgKGdydXBwZUtvbnRvSUQgPT0gbnVsbCB8fCBncnVwc" +
                        "GVLb250b0lEID09IFN5c3RlbS5EQk51bGwuVmFsdWUpKQ0KICAgIHsNCiAgICAgICAgaWYgKGxlZnRCb" +
                        "3JkZXIgJiYgcmlnaHRCb3JkZXIpDQogICAgICAgIHsNCiAgICAgICAgICAgIGxibC5Cb3JkZXJzID0gK" +
                        "ChEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlKSgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpb" +
                        "mcuQm9yZGVyU2lkZS5MZWZ0IHwgRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5SaWdod" +
                        "CB8IERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuVG9wKSkpOw0KICAgICAgICB9DQogI" +
                        "CAgICAgIGVsc2UgaWYgKGxlZnRCb3JkZXIpDQogICAgICAgIHsNCiAgICAgICAgICAgIGxibC5Cb3JkZ" +
                        "XJzID0gKChEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlKSgoRGV2RXhwcmVzcy5YdHJhU" +
                        "HJpbnRpbmcuQm9yZGVyU2lkZS5MZWZ0IHwgRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZ" +
                        "S5Ub3ApKSk7DQogICAgICAgIH0NCiAgICAgICAgZWxzZSBpZiAocmlnaHRCb3JkZXIpDQogICAgICAgI" +
                        "HsNCiAgICAgICAgICAgIGxibC5Cb3JkZXJzID0gKChEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZ" +
                        "XJTaWRlKSgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5SaWdodCB8IERldkV4cHJlc" +
                        "3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuVG9wKSkpOw0KICAgICAgICB9DQogICAgfQ0KICAgIGVsc" +
                        "2UNCiAgICB7DQogICAgICAgIGlmIChsZWZ0Qm9yZGVyICYmIHJpZ2h0Qm9yZGVyKQ0KICAgICAgICB7D" +
                        "QogICAgICAgICAgICBsYmwuQm9yZGVycyA9ICgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU" +
                        "2lkZSkoKERldkV4cHJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuTGVmdCB8IERldkV4cHJlc3MuW" +
                        "HRyYVByaW50aW5nLkJvcmRlclNpZGUuUmlnaHQpKSk7DQogICAgICAgIH0NCiAgICAgICAgZWxzZSBpZ" +
                        "iAobGVmdEJvcmRlcikNCiAgICAgICAgew0KICAgICAgICAgICAgbGJsLkJvcmRlcnMgPSAoKERldkV4c" +
                        "HJlc3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUpKChEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZ" +
                        "XJTaWRlLkxlZnQpKSk7DQogICAgICAgIH0NCiAgICAgICAgZWxzZSBpZiAocmlnaHRCb3JkZXIpDQogI" +
                        "CAgICAgIHsNCiAgICAgICAgICAgIGxibC5Cb3JkZXJzID0gKChEZXZFeHByZXNzLlh0cmFQcmludGluZ" +
                        "y5Cb3JkZXJTaWRlKSgoRGV2RXhwcmVzcy5YdHJhUHJpbnRpbmcuQm9yZGVyU2lkZS5SaWdodCkpKTsNC" +
                        "iAgICAgICAgfQ0KICAgIH0NCn0Bqg5wcml2YXRlIHZvaWQgT25CZWZvcmVQcmludChvYmplY3Qgc2VuZ" +
                        "GVyLCBTeXN0ZW0uRHJhd2luZy5QcmludGluZy5QcmludEV2ZW50QXJncyBlKSANCnsNCiAgICBYUkxhY" +
                        "mVsIGxibCA9IGxibERUS29udG9OcjsNCiAgICBib29sIGxlZnRCb3JkZXIgPSB0cnVlOw0KICAgIGJvb" +
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
                        "3MuWHRyYVByaW50aW5nLkJvcmRlclNpZGUuUmlnaHQpKSk7DQogICAgICAgIH0NCiAgICB9DQp9AZEER" +
                        "EVDTEFSRSBAS2JQZXJpb2RlSUQgSU5UOw0KREVDTEFSRSBARGF0dW1Wb24gREFURVRJTUU7DQpERUNMQ" +
                        "VJFIEBEYXR1bUJpcyBEQVRFVElNRTsNCkRFQ0xBUkUgQE51ck1pdEJ1Y2h1bmdlbiBCSVQ7DQpERUNMQ" +
                        "VJFIEBPaG5lS3RvR3J1cHBlbiBCSVQ7DQoNClNFVCBAS2JQZXJpb2RlSUQgICAgID0gbnVsbDsgICAgI" +
                        "C0tMzAtLQ0KU0VUIEBEYXR1bVZvbiAgICAgICAgPSBudWxsOyAgICAgICAgLS0nMjAwODA3MDEnLS0NC" +
                        "lNFVCBARGF0dW1CaXMgICAgICAgID0gbnVsbDsgICAgICAgIC0tJzIwMDgwNzAxJy0tDQpTRVQgQE51c" +
                        "k1pdEJ1Y2h1bmdlbiA9IG51bGw7IC0tMS0tDQpTRVQgQE9obmVLdG9HcnVwcGVuICA9IDA7IC0tIFRPR" +
                        "E8hIGdlaHQgbmljaHQgd2VnZW4gU29ydGllcnVuZyEgbnVsbCAgLS0wLS0NCg0KRVhFQyBkYm8uc3BLY" +
                        "kdldEJpbGFuekVyZm9sZyBAS2JQZXJpb2RlSUQsIEBEYXR1bVZvbiwgQERhdHVtQmlzLCBATnVyTWl0Q" +
                        "nVjaHVuZ2VuLCBAT2huZUt0b0dydXBwZW4sIDI7IC0tIEVyZm9sZ3NyZWNobnVuZw==";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.lblDTAufwand = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDTKontoNr = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDTErtrag = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDTKontoName = new DevExpress.XtraReports.UI.XRLabel();
            this.lblRHDatumBis = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHKlibu = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHInstName = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHInstPlzOrt = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHInstStrasse = new DevExpress.XtraReports.UI.XRLabel();
            this.panColHeaders = new DevExpress.XtraReports.UI.XRPanel();
            this.lblPHBilanzEr = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHAufwand = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHKonto = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPHErtrag = new DevExpress.XtraReports.UI.XRLabel();
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
                        this.lblDTAufwand,
                        this.lblDTKontoNr,
                        this.lblDTErtrag,
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
            // lblDTAufwand
            // 
            this.lblDTAufwand.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.lblDTAufwand.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Aufwand", "{0:n2}")});
            this.lblDTAufwand.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDTAufwand.Location = new System.Drawing.Point(668, 0);
            this.lblDTAufwand.Name = "lblDTAufwand";
            this.lblDTAufwand.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDTAufwand.ParentStyleUsing.UseBorders = false;
            this.lblDTAufwand.ParentStyleUsing.UseFont = false;
            this.lblDTAufwand.Scripts.OnBeforePrint = resources.GetString("lblDTAufwand.Scripts.OnBeforePrint");
            this.lblDTAufwand.Size = new System.Drawing.Size(116, 25);
            this.lblDTAufwand.Text = "lblDTAufwand";
            this.lblDTAufwand.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            this.lblDTKontoNr.Text = "lblDTKontoNr";
            // 
            // lblDTErtrag
            // 
            this.lblDTErtrag.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
            this.lblDTErtrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Ertrag", "{0:n2}")});
            this.lblDTErtrag.Font = new System.Drawing.Font("Arial", 9F);
            this.lblDTErtrag.Location = new System.Drawing.Point(784, 0);
            this.lblDTErtrag.Name = "lblDTErtrag";
            this.lblDTErtrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDTErtrag.ParentStyleUsing.UseBorders = false;
            this.lblDTErtrag.ParentStyleUsing.UseFont = false;
            this.lblDTErtrag.Scripts.OnBeforePrint = resources.GetString("lblDTErtrag.Scripts.OnBeforePrint");
            this.lblDTErtrag.Size = new System.Drawing.Size(116, 25);
            this.lblDTErtrag.Text = "lblDTErtrag";
            this.lblDTErtrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            this.lblDTKontoName.Size = new System.Drawing.Size(526, 25);
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
                        this.lblPHAufwand,
                        this.lblPHKonto,
                        this.lblPHErtrag,
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
            this.lblPHBilanzEr.Text = "Laufende Rechnung";
            this.lblPHBilanzEr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblPHAufwand
            // 
            this.lblPHAufwand.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.lblPHAufwand.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblPHAufwand.Location = new System.Drawing.Point(668, 0);
            this.lblPHAufwand.Name = "lblPHAufwand";
            this.lblPHAufwand.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPHAufwand.ParentStyleUsing.UseBorders = false;
            this.lblPHAufwand.ParentStyleUsing.UseFont = false;
            this.lblPHAufwand.Size = new System.Drawing.Size(116, 33);
            this.lblPHAufwand.Text = "Aufwand";
            this.lblPHAufwand.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            // lblPHErtrag
            // 
            this.lblPHErtrag.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.lblPHErtrag.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblPHErtrag.Location = new System.Drawing.Point(784, 0);
            this.lblPHErtrag.Name = "lblPHErtrag";
            this.lblPHErtrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPHErtrag.ParentStyleUsing.UseBorders = false;
            this.lblPHErtrag.ParentStyleUsing.UseFont = false;
            this.lblPHErtrag.Size = new System.Drawing.Size(116, 33);
            this.lblPHErtrag.Text = "Ertrag";
            this.lblPHErtrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            this.lblPHBezeichnung.Size = new System.Drawing.Size(526, 33);
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

EXEC dbo.spKbGetBilanzErfolg @KbPeriodeID, @DatumVon, @DatumBis, @NurMitBuchungen, @OhneKtoGruppen, 2; -- Erfolgsrechnung' , ContextForms =  N'CtlQueryKbBilanzErfolg,CtlQueryKbBilanzErfolg_Erfolg' , ParentReportName =  null , ReportSortKey = 4, System =  0 
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'KBLaufendeRechnung' ;


