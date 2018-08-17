-- Insert Script for ShFinanzplanverfuegung
-- MD5:0X2F47D6A2A43DA9F82685C3431392C253_0X655F2032EFA88DBE4DFF38F090865581_0XE6F30ED46DB285EB368321E266F4AD85
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'ShFinanzplanverfuegung') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('ShFinanzplanverfuegung', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'ShFinanzplanverfuegung';
UPDATE QRY
SET QueryName =  N'ShFinanzplanverfuegung' , UserText =  N'SH - Finanzplanverfügung' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>C:\Windows\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>en-US</Localization>
///   <References>
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraPrinting.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Drawing\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Configuration\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Data.SqlXml\v4.0_4.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Security\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.Utils.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Utils.v6.2.dll" />
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
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraEditors.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.Data.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Data.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraBars.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraNavBar.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraCharts.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraRichTextEdit.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="C:\Projects\Kiss40\KiSS\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\Kiss40\KiSS\Build\Debug\Kiss.Interfaces.dll" />
///     <Reference Path="C:\Projects\Kiss40\KiSS\Build\Debug\FluentValidation.dll" />
///     <Reference Path="C:\Projects\Kiss40\KiSS\Build\Debug\StructureMap.dll" />
///     <Reference Path="C:\Projects\Kiss40\KiSS\Build\Debug\log4net.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Projects\Kiss40\KiSS\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRRichText rtfRechsmittel;
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
                        "jgxNDdiNWVhZTRQE7ROpJW/u7pU4BDdUf5/AloAAACRAAAAKQAAAAAAAAAeAgAAJHIAdABmAEgAaQBuA" +
                        "HcAZQBpAHMALgBSAHQAZgBUAGUAeAB0AAAAAAAscgB0AGYAUgBlAGMAaABzAG0AaQB0AHQAZQBsAC4AU" +
                        "gB0AGYAVABlAHgAdAAdBgAAMnMAcQBsAFEAdQBlAHIAeQAxAC4AUwBlAGwAZQBjAHQAUwB0AGEAdABlA" +
                        "G0AZQBuAHQA0QgAACx4AHIAUgBpAGMAaABUAGUAeAB0AEIAbwB4ADEALgBSAHQAZgBUAGUAeAB0AFQXA" +
                        "ABAAAEAAAD/////AQAAAAAAAAAMAgAAABtEZXZFeHByZXNzLlh0cmFSZXBvcnRzLnY2LjIFAQAAACxEZ" +
                        "XZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlNlcmlhbGl6YWJsZVN0cmluZwEAAAAFVmFsdWUBAgAAAAYDA" +
                        "AAAoQt7XHJ0ZjFcYW5zaWNwZzEyNTINCnsNClxmb250dGJsDQp7XGYwIFRpbWVzIE5ldyBSb21hbjt9D" +
                        "Qp7XGYxIEFyaWFsO30NCn0NCnsNClxjb2xvcnRibA0KOw0KXHJlZDBcZ3JlZW4wXGJsdWUwOw0KfQ0Ke" +
                        "1xwYXJkXHBsYWlue1xmMVxmczE4XGNmMSBEYXMgQnVkZ2V0IGlzdCBuYWNoIGRlbiBTS09TLVJpY2h0b" +
                        "GluaWVuIChpbiBkZXIgRmFzc3VuZyAyMDA1KSBiZXJlY2huZXQuIEVzIGdpbHQgYWxzIFJhaG1lbmJ1Z" +
                        "GdldC4gRWlubmFobWVuIHVuZCBBdXNnYWJlbiBrXHUyNDbvv71ubmVuIG1vbmF0bGljaCBcdTIyOO+/v" +
                        "W5kZXJuLiBEaWUgS2xpZW50ZWwgaXN0IHZlcnBmbGljaHRldCwgXHUxOTbvv71uZGVydW5nZW4gZGVyI" +
                        "GZpbmFuemllbGxlbiBTaXR1YXRpb24gdW1nZWhlbmQgZGVtIFNvemlhbGRpZW5zdCB6dSBtZWxkZW4gd" +
                        "W5kIHp1c1x1MjI477+9dHpsaWNoZSBBdXNsYWdlbiB3aWUgQW5zY2hhZmZ1bmdlbiwgWmFobmJlaGFuZ" +
                        "Gx1bmdlbiB1c3cuIHZvcmhlciBtaXQgZGVtIFNvemlhbGRpZW5zdCB6dSBiZXNwcmVjaGVuLiBFaW5lI" +
                        "FZlcmhlaW1saWNodW5nIHZvbiBUYXRzYWNoZW4gb2RlciBkaWUgQW5nYWJlIGZhbHNjaGVyIFRhdHNhY" +
                        "2hlbiBrYW5uIGVpbmUgc29mb3J0aWdlIFJcdTI1Mu+/vWNrZXJzdGF0dHVuZ3NwZmxpY2h0IGF1c2xcd" +
                        "TI0Nu+/vXNlbiB1bmQgc3RyYWZyZWNodGxpY2hlIEZvbGdlbiBuYWNoIHNpY2ggemllaGVuLiBTb3ppY" +
                        "WxoaWxmZWxlaXN0dW5nZW4gc2luZCBncnVuZHNcdTIyOO+/vXR6bGljaCByXHUyNTLvv71ja2Vyc3Rhd" +
                        "HR1bmdzcGZsaWNodGlnLiB9XHBhclxwYXJkXHBsYWlue1xmMVxmczE4XGNmMSBadWxhZ2VuIChNSVosI" +
                        "ElaVSBvZGVyIEVGQikgd2VyZGVuIGVyc3QgYXVzZ2VyaWNodGV0LCB3ZW5uIGRpZSB2ZXJlaW5iYXJ0Z" +
                        "W4gRWlnZW5sZWlzdHVuZ2VuIGVyYnJhY2h0IHd1cmRlbiBvZGVyIGRpZXNlIG9iamVrdGl2IG5pY2h0I" +
                        "G1cdTI0Nu+/vWdsaWNoIHNpbmQuIEVzIG9ibGllZ3QgZGVyIEtsaWVudGVsLCBkZW4gZW50c3ByZWNoZ" +
                        "W5kZW4gTmFjaHdlaXMgenUgZXJicmluZ2VuLiBEaWUgSFx1MjQ277+9aGUgZGVyIGpld2VpbGlnZW4gW" +
                        "nVsYWdlIGthbm4gc2ljaCBtb25hdGxpY2ggdmVyXHUyMjjvv71uZGVybi4gU2llIHdpcmQgcGVyaW9ka" +
                        "XNjaCBkZW4gdGF0c1x1MjI477+9Y2hsaWNoZW4gVmVyaFx1MjI477+9bHRuaXNzZW4gYW5nZXBhc3N0L" +
                        "iBGYWxscyBkaWUgS2xpZW50ZWwgbWl0IGRlciBIXHUyNDbvv71oZSBkZXIgWnVsYWdlIG5pY2h0IGVpb" +
                        "nZlcnN0YW5kZW4gaXN0LCBrYW5uIHNpZSBqZWRlcnplaXQgZWluZSBhdXNmb3JtdWxpZXJ0ZSBWZXJmX" +
                        "HUyNTLvv71ndW5nIHZlcmxhbmdlbi4gRmFsbHMgZWluZSBadWxhZ2UgenUgVW5yZWNodCBhdXNnZXJpY" +
                        "2h0ZXQgd3VyZGUsIGlzdCBkaWVzZSByXHUyNTLvv71ja2Vyc3RhdHR1bmdzcGZsaWNodGlnLn1ccGFyf" +
                        "Q0KfQ0KC0AAAQAAAP////8BAAAAAAAAAAwCAAAAG0RldkV4cHJlc3MuWHRyYVJlcG9ydHMudjYuMgUBA" +
                        "AAALERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuU2VyaWFsaXphYmxlU3RyaW5nAQAAAAVWYWx1ZQECA" +
                        "AAABgMAAAC4BHtccnRmMVxhbnNpY3BnMTI1Mg0Kew0KXGZvbnR0YmwNCntcZjAgVGltZXMgTmV3IFJvb" +
                        "WFuO30NCntcZjEgQXJpYWw7fQ0KfQ0Kew0KXGNvbG9ydGJsDQo7DQpccmVkMFxncmVlbjBcYmx1ZTA7D" +
                        "Qp9DQp7XHBhcmRccGxhaW57XGYxXGZzMThcY2YxIERpZXNlIFZlcmZcdTI1Mu+/vWd1bmcga2FubiBpb" +
                        "m5lcnQgMzAgVGFnZW4gYmVpbSBSZWdpZXJ1bmdzc3RhdHRoYWx0ZXJhbXQgQmVybi1NaXR0ZWxsYW5kI" +
                        "GFuZ2Vmb2NodGVuIHdlcmRlbi4gRWluZSBhbGxmXHUyMjjvv71sbGlnZSBCZXNjaHdlcmRlIGlzdCBpb" +
                        "SBEb3BwZWwgbWl0IGVpbmVtIEFudHJhZywgZGVyIEFuZ2FiZSB2b24gVGF0c2FjaGVuIHVuZCBCZXdla" +
                        "XNtaXR0ZWxuLCBlaW5lciBCZWdyXHUyNTLvv71uZHVuZyBzb3dpZSBlaW5lciBVbnRlcnNjaHJpZnQgd" +
                        "W5kIGVpbmVyIEtvcGllIGRlciBhbmdlZm9jaHRlbmVuIFZlcmZcdTI1Mu+/vWd1bmcgYmVpbSBSZWdpZ" +
                        "XJ1bmdzc3RhdHRoYWx0ZXJhbXQgQmVybi1NaXR0ZWxsYW5kLCBQb3N0c3RyYXNzZSAyNSwgMzA3MSBPc" +
                        "3Rlcm11bmRpZ2VuLCBlaW56dXJlaWNoZW4ufVxwYXJ9DQp9DQoLAYAdREVDTEFSRSBAQmdCdWRnZXRJR" +
                        "CAgaW50LA0KICAgICAgICBAR2V0RGF0ZSAgICAgZGF0ZXRpbWUNClNFTEVDVCBAQmdCdWRnZXRJRCA9I" +
                        "EJnQnVkZ2V0SUQsIEBHZXREYXRlID0gR2V0RGF0ZSgpDQpGUk9NIEJnQnVkZ2V0DQpXSEVSRSBCZ0Zpb" +
                        "mFuelBsYW5JRCA9IG51bGwgQU5EIE1hc3RlckJ1ZGdldCA9IDENCg0KDQpERUNMQVJFIEBUb3RJbiBtb" +
                        "25leQ0KREVDTEFSRSBAVG90T3V0IG1vbmV5DQoNClNFTEVDVCBAVG90SW4gPSBTVU0oQmV0cmFnKQ0KR" +
                        "lJPTSBkYm8uZm5XaEdldEZpbmFuenBsYW4oQEJnQnVkZ2V0SUQsIEBHZXREYXRlKSAgVE1QDQogIElOT" +
                        "kVSIEpPSU4gWExPVkNvZGUgIFhQQyBPTiBYUEMuTE9WTmFtZSA9ICdCZ0thdGVnb3JpZScgQU5EIFhQQ" +
                        "y5Db2RlID0gVE1QLkJnS2F0ZWdvcmllQ29kZQ0KV0hFUkUgQmdLYXRlZ29yaWVDb2RlID0gMQ0KDQpTR" +
                        "UxFQ1QgQFRvdE91dCA9IFNVTShDQVNFIFdIRU4gQmdLYXRlZ29yaWVDb2RlID0gMiBUSEVOIFRNUC5CZ" +
                        "XRyYWcgRUxTRSAtVE1QLkJldHJhZyBFTkQpDQpGUk9NIGRiby5mbldoR2V0RmluYW56cGxhbihAQmdCd" +
                        "WRnZXRJRCwgQEdldERhdGUpICBUTVANCiAgSU5ORVIgSk9JTiBYTE9WQ29kZSAgWFBDIE9OIFhQQy5MT" +
                        "1ZOYW1lID0gJ0JnS2F0ZWdvcmllJyBBTkQgWFBDLkNvZGUgPSBUTVAuQmdLYXRlZ29yaWVDb2RlDQpXS" +
                        "EVSRSBCZ0thdGVnb3JpZUNvZGUgSU4gKDIsIDQpDQoNCg0KDQpERUNMQVJFIEBCZW1lcmt1bmdSVEYgd" +
                        "mFyY2hhcig4MDAwKSwNCiAgICAgICAgQEl0ZW1UZXh0ICAgICB2YXJjaGFyKDgwMDApDQoNCkRFQ0xBU" +
                        "kUgY0JlbWVya3VuZ1JURiBDVVJTT1IgRkFTVF9GT1JXQVJEIEZPUg0KICBTRUxFQ1QgJy0gJyArIFhMQ" +
                        "y5UZXh0ICsgJyAoJyArIFBSUy5OYW1lVm9ybmFtZSArICcpOiAnICsgQ29udmVydCh2YXJjaGFyKDIwM" +
                        "DApLCBCUE8uQmVtZXJrdW5nKQ0KICBGUk9NIEJnUG9zaXRpb24gICAgICAgICAgICAgQlBPDQogICAgS" +
                        "U5ORVIgSk9JTiB2d1BlcnNvbiAgICAgIFBSUyBPTiBQUlMuQmFQZXJzb25JRCA9IEJQTy5CYVBlcnNvb" +
                        "klEDQogICAgSU5ORVIgSk9JTiBCZ1Bvc2l0aW9uc2FydCAgU1BUIE9OIFNQVC5CZ1Bvc2l0aW9uc2Fyd" +
                        "ElEID0gQlBPLkJnUG9zaXRpb25zYXJ0SUQNCiAgICBJTk5FUiBKT0lOIFhMT1ZDb2RlICAgICAgIFhMQ" +
                        "yBPTiBYTEMuTE9WTmFtZSA9ICdCZ0dydXBwZScgQU5EIFhMQy5Db2RlID0gU1BULkJnR3J1cHBlQ29kZ" +
                        "Q0KICBXSEVSRSBCUE8uQmdCdWRnZXRJRCA9IEBCZ0J1ZGdldElEDQogICAgQU5EIEJQTy5CZ1Bvc2l0a" +
                        "W9uc2FydElEIEJFVFdFRU4gMzkwMDAgQU5EIDM5OTk5DQogICAgQU5EIE5PVCAoQlBPLkJlbWVya3VuZ" +
                        "yBJUyBOVUxMIE9SIENvbnZlcnQodmFyY2hhciwgQlBPLkJlbWVya3VuZykgPSAnJykNCiAgICBBTkQgR" +
                        "2V0RGF0ZSgpIEJFVFdFRU4gSXNOdWxsKEJQTy5EYXR1bVZvbiwgJzE5MDAwMTAxJykgQU5EIElzTnVsb" +
                        "ChCUE8uRGF0dW1CaXMsIEdldERhdGUoKSkNCiAgT1JERVIgQlkgUFJTLk5hbWVWb3JuYW1lDQoNCk9QR" +
                        "U4gY0JlbWVya3VuZ1JURg0KV0hJTEUgKDEgPSAxKSBCRUdJTg0KICBGRVRDSCBORVhUIEZST00gY0Jlb" +
                        "WVya3VuZ1JURiBJTlRPIEBJdGVtVGV4dA0KICBJRiBAQEZFVENIX1NUQVRVUyAhPSAwIEJSRUFLDQoNC" +
                        "iAgU0VUIEBCZW1lcmt1bmdSVEYgPSBJc051bGwoQEJlbWVya3VuZ1JURiArIGNoYXIoMTApICsgY2hhc" +
                        "igxMyksICcnKSArIEBJdGVtVGV4dA0KRU5EDQpDTE9TRSBjQmVtZXJrdW5nUlRGDQpERUFMTE9DQVRFI" +
                        "GNCZW1lcmt1bmdSVEYNCg0KREVDTEFSRSBAVm9ybmFtZU5hbWVfWnVzYXR6IFZBUkNIQVIoTUFYKQ0KU" +
                        "0VUIEBWb3JuYW1lTmFtZV9adXNhdHogPSAoU0VMRUNUIFZvcm5hbWVOYW1lICsgY2hhcigxMykgKyBja" +
                        "GFyKDEwKSBGUk9NIHZ3UGVyc29uIFdIRVJFIEJhUGVyc29uSUQgPSBudWxsKQ0KDQpTRUxFQ1QgQkJHL" +
                        "kJnQnVkZ2V0SUQsDQogICAgICAgVGl0bGUgICAgICAgID0gJ1ZlcmbDvGd1bmcgdm9tICcgKyBJc051b" +
                        "GwoQ09OVkVSVCh2YXJjaGFyLCAoU0VMRUNUIE1BWChEYXR1bSkgRlJPTSBCZ0Jld2lsbGlndW5nIEJCV" +
                        "w0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgV0hFUkUgQkJXLkJnRmluYW56UGxhbklEPVNGUC5CZ0ZpbmFuelBsYW5JRCBBTkQgQkJXL" +
                        "kJnQmV3aWxsaWd1bmdDb2RlID0gMiksIDEwNCksICc/Pz8nKSArDQogICAgICAgICAgICAgICAgICAgI" +
                        "CAgJzogU296aWFsaGlsZmUgdm9tICcgKyBDT05WRVJUKHZhcmNoYXIsIFNGUC5EYXR1bVZvbiwgMTA0K" +
                        "SArICcgYmlzICcgKyBDT05WRVJUKHZhcmNoYXIsIFNGUC5EYXR1bUJpcywgMTA0KSwNCiAgICAgICBBZ" +
                        "HJlc3NlICAgICAgPSBDQVNFIA0KICAgICAgICAgICAgICAgICAgICAgICAgV0hFTiBAVm9ybmFtZU5hb" +
                        "WVfWnVzYXR6IElTIE5VTEwgVEhFTg0KICAgICAgICAgICAgICAgICAgICAgICAgICBJc051bGwoQ0FTR" +
                        "SBQUlMuR2VzY2hsZWNodENvZGUgV0hFTiAxIFRIRU4gJ0hlcnInIFdIRU4gMiBUSEVOICdGcmF1JyBFT" +
                        "kQgKyBjaGFyKDEzKSArIGNoYXIoMTApLCcnKSArDQogICAgICAgICAgICAgICAgICAgICAgICAgIFBSU" +
                        "y5OYW1lVm9ybmFtZSArIGNoYXIoMTMpICsgY2hhcigxMCkgKw0KICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICBQUlMuV29obnNpdHpTdHJhc3NlSGF1c05yICsgY2hhcigxMykgKyBjaGFyKDEwKSArDQogICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgIFBSUy5Xb2huc2l0elBMWk9ydA0KICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgRUxTRQ0KICAgICAgICAgICAgICAgICAgICAgICAgICBQUlMuVm9ybmFtZU5hbWUgKyBjaGFyK" +
                        "DEzKSArIGNoYXIoMTApICsNCiAgICAgICAgICAgICAgICAgICAgICAgICAgQFZvcm5hbWVOYW1lX1p1c" +
                        "2F0eiArDQogICAgICAgICAgICAgICAgICAgICAgICAgIFBSUy5Xb2huc2l0elN0cmFzc2VIYXVzTnIgK" +
                        "yBjaGFyKDEzKSArIGNoYXIoMTApICsNCiAgICAgICAgICAgICAgICAgICAgICAgICAgUFJTLldvaG5za" +
                        "XR6UExaT3J0DQogICAgICAgICAgICAgICAgICAgICAgRU5ELA0KICAgICAgIEJlbWVya3VuZ1JURiA9I" +
                        "ElzTnVsbChDT05WRVJUKHZhcmNoYXIoODAwMCksIFNGUC5CZW1lcmt1bmcpICsgY2hhcigxMCkgKyBja" +
                        "GFyKDEzKSwgJycpICsgSXNOdWxsKEBCZW1lcmt1bmdSVEYsICcnKSwNCiAgICAgICBUb3RJbiAgICAgI" +
                        "CAgPSBJc051bGwoQFRvdEluLCAkMC4wMCksDQogICAgICAgVG90T3V0ICAgICAgID0gSXNOdWxsKEBUb" +
                        "3RPdXQsICQwLjAwKSwNCiAgICAgICBGZWhsYmV0cmFnICAgPSBJc051bGwoQFRvdE91dCwgJDAuMDApI" +
                        "C0gSXNOdWxsKEBUb3RJbiwgJDAuMDApDQpGUk9NICAgQmdCdWRnZXQgQkJHDQogICAgICAgSU5ORVIgS" +
                        "k9JTiBCZ0ZpbmFuelBsYW4gIFNGUCBvbiBTRlAuQmdGaW5hbnpQbGFuSUQgPSBCQkcuQmdGaW5hbnpQb" +
                        "GFuSUQNCiAgICAgICBJTk5FUiBKT0lOIEZhTGVpc3R1bmcgICAgRkFMIG9uIEZBTC5GYUxlaXN0dW5nS" +
                        "UQgPSBTRlAuRmFMZWlzdHVuZ0lEDQogICAgICAgSU5ORVIgSk9JTiB2d1BlcnNvbiAgICAgIFBSUyBvb" +
                        "iBQUlMuQmFQZXJzb25JRCA9IEZBTC5CYVBlcnNvbklEDQpXSEVSRSBGQUwuTW9kdWxJRCA9IDMgQU5EI" +
                        "EJCRy5CZ0J1ZGdldElEID0gQEJnQnVkZ2V0SUQNCi0tICBBTkQgU0ZQLkJnQmV3aWxsaWd1bmdTdGF0d" +
                        "XNDb2RlIGluICg1LCA5KSAtLSBudXIgYmV3aWxsaWd0ZUAAAQAAAP////8BAAAAAAAAAAwCAAAAG0Rld" +
                        "kV4cHJlc3MuWHRyYVJlcG9ydHMudjYuMgUBAAAALERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuU2Vya" +
                        "WFsaXphYmxlU3RyaW5nAQAAAAVWYWx1ZQECAAAABgMAAACiAntccnRmMVxhbnNpXGFuc2ljcGcxMjUyX" +
                        "GRlZmYwe1xmb250dGJse1xmMFxmbmlsXGZjaGFyc2V0MCBBcmlhbDt9e1xmMVxmbmlsIFRpbWVzIE5ld" +
                        "yBSb21hbjt9fQ0KXHZpZXdraW5kNFx1YzFccGFyZFxub3dpZGN0bHBhclxzbDI0MFxzbG11bHQwXGxhb" +
                        "mcyMDU1XGZzMTggU296aWFsYW10LCBTb3ppYWxkaWVuc3RccGFyDQpQcmVkaWdlcmdhc3NlIDEwXHBhc" +
                        "g0KUG9zdGZhY2ggOTE3XHBhcg0KMzAwMCBCZXJuIDdccGFyDQpccGFyDQpccGFyZCB3d3cuQmVybi5ja" +
                        "FxsYW5nMTAzM1xmMVxmczI0XHBhcg0KfQ0KCwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
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
            this.rtfRechsmittel = new DevExpress.XtraReports.UI.XRRichText();
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
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.rtfRechsmittel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtfHinweis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.rtfRechsmittel,
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
                        this.txtTitle});
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
            // rtfRechsmittel
            // 
            this.rtfRechsmittel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.rtfRechsmittel.BorderColor = System.Drawing.Color.Black;
            this.rtfRechsmittel.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.rtfRechsmittel.Dpi = 254F;
            this.rtfRechsmittel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfRechsmittel.Location = new System.Drawing.Point(0, 1775);
            this.rtfRechsmittel.Name = "rtfRechsmittel";
            this.rtfRechsmittel.ParentStyleUsing.UseBackColor = false;
            this.rtfRechsmittel.ParentStyleUsing.UseBorderColor = false;
            this.rtfRechsmittel.ParentStyleUsing.UseBorders = false;
            this.rtfRechsmittel.ParentStyleUsing.UseFont = false;
            this.rtfRechsmittel.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("rtfRechsmittel.RtfText")));
            this.rtfRechsmittel.Size = new System.Drawing.Size(1863, 170);
            // 
            // rtfHinweis
            // 
            this.rtfHinweis.BackColor = System.Drawing.Color.White;
            this.rtfHinweis.Dpi = 254F;
            this.rtfHinweis.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfHinweis.Location = new System.Drawing.Point(394, 974);
            this.rtfHinweis.Name = "rtfHinweis";
            this.rtfHinweis.ParentStyleUsing.UseBackColor = false;
            this.rtfHinweis.ParentStyleUsing.UseBorderColor = false;
            this.rtfHinweis.ParentStyleUsing.UseBorders = false;
            this.rtfHinweis.ParentStyleUsing.UseBorderWidth = false;
            this.rtfHinweis.ParentStyleUsing.UseFont = false;
            this.rtfHinweis.ParentStyleUsing.UseForeColor = false;
            this.rtfHinweis.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("rtfHinweis.RtfText")));
            this.rtfHinweis.Size = new System.Drawing.Size(1458, 275);
            // 
            // xrRichTextBox1
            // 
            this.xrRichTextBox1.BackColor = System.Drawing.Color.White;
            this.xrRichTextBox1.CanShrink = true;
            this.xrRichTextBox1.Dpi = 254F;
            this.xrRichTextBox1.Location = new System.Drawing.Point(0, 21);
            this.xrRichTextBox1.Name = "xrRichTextBox1";
            this.xrRichTextBox1.ParentStyleUsing.UseBackColor = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorderColor = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorders = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorderWidth = false;
            this.xrRichTextBox1.ParentStyleUsing.UseFont = false;
            this.xrRichTextBox1.ParentStyleUsing.UseForeColor = false;
            this.xrRichTextBox1.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichTextBox1.RtfText")));
            this.xrRichTextBox1.Size = new System.Drawing.Size(529, 297);
            // 
            // xrPanel1
            // 
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageInfo1});
            this.xrPanel1.Dpi = 254F;
            this.xrPanel1.Location = new System.Drawing.Point(0, 1460);
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
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BemerkungRTF", "")});
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
            this.xrLine1.Dpi = 254F;
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine1.LineWidth = 3;
            this.xrLine1.Location = new System.Drawing.Point(937, 719);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(10, 134);
            // 
            // ShFinanzplanverfuegung_EinAus
            // 
            this.ShFinanzplanverfuegung_EinAus.Dpi = 254F;
            this.ShFinanzplanverfuegung_EinAus.Location = new System.Drawing.Point(0, 660);
            this.ShFinanzplanverfuegung_EinAus.Name = "ShFinanzplanverfuegung_EinAus";
            // 
            // ShFinanzplanverfuegung_Personen
            // 
            this.ShFinanzplanverfuegung_Personen.Dpi = 254F;
            this.ShFinanzplanverfuegung_Personen.Location = new System.Drawing.Point(0, 429);
            this.ShFinanzplanverfuegung_Personen.Name = "ShFinanzplanverfuegung_Personen";
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
            this.Line11.Dpi = 254F;
            this.Line11.ForeColor = System.Drawing.Color.Black;
            this.Line11.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line11.LineWidth = 3;
            this.Line11.Location = new System.Drawing.Point(937, 589);
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
            this.Label12.Location = new System.Drawing.Point(970, 589);
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
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 254F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 11F);
            this.xrPageInfo1.Format = "Bern, {0}";
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
            ((System.ComponentModel.ISupportInitialize)(this.rtfRechsmittel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtfHinweis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' , ParameterXML =  N'<?xml version="1.0" standalone="yes" ?>
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
    <Parameter0>BgFinanzPlanID</Parameter0>
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
  INNER JOIN vwPerson         PRS ON PRS.BaPersonID = BFB.BaPersonID
  INNER JOIN BgFinanzplan     BFP ON BFP.BgFinanzplanID = BFB.BgFinanzplanID
  INNER JOIN FaLeistung       FLE ON FLE.FaLeistungID = BFP.FaLeistungID
WHERE BFB.BgFinanzplanID = {BgFinanzPlanID}
  AND PRS.BaPersonID != FLE.BaPersonID
		</SQL>
	</Table>
	<Table>
		<FieldName>label</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Finanzplan ID:</DisplayText>
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
		<FieldName>BgFinanzPlanID</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>Finanzplan ID</DisplayText>
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

DECLARE @VornameName_Zusatz VARCHAR(MAX)
SET @VornameName_Zusatz = (SELECT VornameName + char(13) + char(10) FROM vwPerson WHERE BaPersonID = {BaPersonID_Zusatz})

SELECT BBG.BgBudgetID,
       Title        = ''Verfügung vom '' + IsNull(CONVERT(varchar, (SELECT MAX(Datum) FROM BgBewilligung BBW
                                                                  WHERE BBW.BgFinanzPlanID=SFP.BgFinanzPlanID AND BBW.BgBewilligungCode = 2), 104), ''???'') +
                      '': Sozialhilfe vom '' + CONVERT(varchar, SFP.DatumVon, 104) + '' bis '' + CONVERT(varchar, SFP.DatumBis, 104),
       Adresse      = CASE 
                        WHEN @VornameName_Zusatz IS NULL THEN
                          IsNull(CASE PRS.GeschlechtCode WHEN 1 THEN ''Herr'' WHEN 2 THEN ''Frau'' END + char(13) + char(10),'''') +
                          PRS.NameVorname + char(13) + char(10) +
                          PRS.WohnsitzStrasseHausNr + char(13) + char(10) +
                          PRS.WohnsitzPLZOrt
                        ELSE
                          PRS.VornameName + char(13) + char(10) +
                          @VornameName_Zusatz +
                          PRS.WohnsitzStrasseHausNr + char(13) + char(10) +
                          PRS.WohnsitzPLZOrt
                      END,
       BemerkungRTF = IsNull(CONVERT(varchar(8000), SFP.Bemerkung) + char(10) + char(13), '''') + IsNull(@BemerkungRTF, ''''),
       TotIn        = IsNull(@TotIn, $0.00),
       TotOut       = IsNull(@TotOut, $0.00),
       Fehlbetrag   = IsNull(@TotOut, $0.00) - IsNull(@TotIn, $0.00)
FROM   BgBudget BBG
       INNER JOIN BgFinanzPlan  SFP on SFP.BgFinanzPlanID = BBG.BgFinanzPlanID
       INNER JOIN FaLeistung    FAL on FAL.FaLeistungID = SFP.FaLeistungID
       INNER JOIN vwPerson      PRS on PRS.BaPersonID = FAL.BaPersonID
WHERE FAL.ModulID = 3 AND BBG.BgBudgetID = @BgBudgetID
--  AND SFP.BgBewilligungStatusCode in (5, 9) -- nur bewilligte' , ContextForms =  N'WhFinanzplan,CtlBgUebersicht,WhMonatsbudget,WhMasterbudget' , ParentReportName =  null , ReportSortKey = 3
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'ShFinanzplanverfuegung' ;


INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShFinanzplanverfuegung_EinAus' ,  N'Einnahmen, Ausgaben' , 1,  N'<!--
AssemblyName=DevExpress%2EXtraReports%2C%20Version%3D1%2E7%2E10%2E0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4
AssemblyLocation=c:\windows\assembly\gac\devexpress.xtrareports\1.7.10.0__79868b8147b5eae4\devexpress.xtrareports.dll
TypeName=DevExpress.XtraReports.UI.XtraReport
Localization=de-DE
-->
<SOAP-ENV:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:SOAP-ENC="http://schemas.xmlsoap.org/soap/encoding/" xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/" xmlns:clr="http://schemas.microsoft.com/soap/encoding/clr/1.0" SOAP-ENV:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
<SOAP-ENV:Body>
<a1:ReportStorage id="ref-1" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<BandCount>1</BandCount>
<Band0 href="#ref-6"/>
<Visible>true</Visible>
<Tag id="ref-7"></Tag>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-8">Report</Name>
<Style_X_Font id="ref-9">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor id="ref-10">ControlText</Style_X_ForeColor>
<Style_X_BackColor id="ref-11">Transparent</Style_X_BackColor>
<Style_X_BorderColor href="#ref-10"/>
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
<Text href="#ref-7"/>
<NavigateUrl href="#ref-7"/>
<Target href="#ref-7"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>100</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<DataSource id="ref-12">dataSource</DataSource>
<UseDefaultPrinterSettings>false</UseDefaultPrinterSettings>
<ReportUnit xsi:type="a2:ReportUnit" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">HundredthsOfAnInch</ReportUnit>
<Landscape>false</Landscape>
<PaperKind xsi:type="a5:PaperKind" xmlns:a5="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Printing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Letter</PaperKind>
<PaperName href="#ref-7"/>
<Margins xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>100</x>
<y>100</y>
<width>10</width>
<height>100</height>
</Margins>
<HtmlCompressed>false</HtmlCompressed>
<PageSize xsi:type="a4:Size" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<width>850</width>
<height>1100</height>
</PageSize>
<StyleSheet_X_StyleCount>0</StyleSheet_X_StyleCount>
<ShowPreviewMarginLines>true</ShowPreviewMarginLines>
<ScriptLanguage xsi:type="a6:ScriptLanguage" xmlns:a6="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">CSharp</ScriptLanguage>
<Watermark_X_Text href="#ref-7"/>
<Watermark_X_Font id="ref-13">Verdana, 36pt</Watermark_X_Font>
<Watermark_X_ForeColor id="ref-14">Red</Watermark_X_ForeColor>
<Watermark_X_Transparency>50</Watermark_X_Transparency>
<Watermark_X_TextDirection xsi:type="a7:DirectionMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">ForwardDiagonal</Watermark_X_TextDirection>
<Watermark_X_Image xsi:type="xsd:anyType" xsi:null="1"/>
<Watermark_X_ImageAlign xsi:type="a4:ContentAlignment" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">MiddleCenter</Watermark_X_ImageAlign>
<Watermark_X_ImageViewMode xsi:type="a7:ImageViewMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Clip</Watermark_X_ImageViewMode>
<Watermark_X_ImageTiling>false</Watermark_X_ImageTiling>
<Watermark_X_PageRange href="#ref-7"/>
<Watermark_X_ShowBehind>true</Watermark_X_ShowBehind>
<DefaultPrinterSettingsUsing_X_UseMargins>false</DefaultPrinterSettingsUsing_X_UseMargins>
<DefaultPrinterSettingsUsing_X_UsePaperKind>false</DefaultPrinterSettingsUsing_X_UsePaperKind>
<DefaultPrinterSettingsUsing_X_UseLandscape>false</DefaultPrinterSettingsUsing_X_UseLandscape>
<ShrinkSubReportIconArea>true</ShrinkSubReportIconArea>
</a1:ReportStorage>
<a1:ObjectStorage id="ref-6" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName id="ref-15">DevExpress.XtraReports, Version=1.7.10.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</Type_X_AssemblyName>
<Type_X_TypeName id="ref-16">DevExpress.XtraReports.UI.DetailBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-7"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-17">Detail</Name>
<Style_X_Font id="ref-18">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-10"/>
<Style_X_BackColor href="#ref-11"/>
<Style_X_BorderColor href="#ref-10"/>
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
<Text href="#ref-7"/>
<NavigateUrl href="#ref-7"/>
<Target href="#ref-7"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<EventsScript_X_OnBeforePrint id="ref-19">private void OnBeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
  //xrLine1.Height = Detail.Height = 444;
}</EventsScript_X_OnBeforePrint>
<Height>18</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<PrintOnEmptyDataSource>true</PrintOnEmptyDataSource>
<MultiColumn_X_ColumnCount>1</MultiColumn_X_ColumnCount>
<MultiColumn_X_Direction xsi:type="a2:ColumnDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">DownThenAcross</MultiColumn_X_Direction>
<MultiColumn_X_ColumnWidth>0</MultiColumn_X_ColumnWidth>
<MultiColumn_X_ColumnSpacing>0</MultiColumn_X_ColumnSpacing>
<MultiColumn_X_Mode xsi:type="a2:MultiColumnMode" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</MultiColumn_X_Mode>
<RepeatCountOnEmptyDataSource>1</RepeatCountOnEmptyDataSource>
<ItemCount>5</ItemCount>
<Item0 href="#ref-20"/>
<Item1 href="#ref-21"/>
<Item2 href="#ref-22"/>
<Item3 href="#ref-23"/>
<Item4 href="#ref-24"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-20" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-15"/>
<Type_X_TypeName id="ref-25">DevExpress.XtraReports.UI.XRLine</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-7"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-26">xrLine1</Name>
<Style_X_Font id="ref-27">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-10"/>
<Style_X_BackColor href="#ref-11"/>
<Style_X_BorderColor href="#ref-10"/>
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
<x>367</x>
<y>0</y>
<width>8</width>
<height>18</height>
</Bounds>
<Text href="#ref-7"/>
<NavigateUrl href="#ref-7"/>
<Target href="#ref-7"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Vertical</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-21" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-15"/>
<Type_X_TypeName id="ref-28">DevExpress.XtraReports.UI.XRLabel</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-7"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-29">xrLabel4</Name>
<Style_X_Font id="ref-30">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-10"/>
<Style_X_BackColor href="#ref-11"/>
<Style_X_BorderColor href="#ref-10"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>true</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>true</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>true</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>true</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>true</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-31">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-32">BetragAus</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-33">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-12"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>622</x>
<y>0</y>
<width>100</width>
<height>18</height>
</Bounds>
<Text id="ref-34">xrLabel2</Text>
<NavigateUrl href="#ref-7"/>
<Target href="#ref-7"/>
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
<a1:ObjectStorage id="ref-22" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-15"/>
<Type_X_TypeName href="#ref-28"/>
<Visible>true</Visible>
<Tag href="#ref-7"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-35">xrLabel3</Name>
<Style_X_Font id="ref-36">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-10"/>
<Style_X_BackColor href="#ref-11"/>
<Style_X_BorderColor href="#ref-10"/>
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
<ParentStyleUsing_X_UseForeColor>true</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>true</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>true</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>true</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>true</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-37">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-38">TextAus</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-7"/>
<BindingItem0_X_DataSource href="#ref-12"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>379</x>
<y>0</y>
<width>258</width>
<height>18</height>
</Bounds>
<Text id="ref-39">xrLabel1</Text>
<NavigateUrl href="#ref-7"/>
<Target href="#ref-7"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-23" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-15"/>
<Type_X_TypeName href="#ref-28"/>
<Visible>true</Visible>
<Tag href="#ref-7"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-40">xrLabel2</Name>
<Style_X_Font id="ref-41">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-10"/>
<Style_X_BackColor href="#ref-11"/>
<Style_X_BorderColor href="#ref-10"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>true</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>true</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>true</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>true</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>true</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-42">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-43">BetragEin</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-44">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-12"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>259</x>
<y>0</y>
<width>100</width>
<height>18</height>
</Bounds>
<Text href="#ref-40"/>
<NavigateUrl href="#ref-7"/>
<Target href="#ref-7"/>
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
<a1:ObjectStorage id="ref-24" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-15"/>
<Type_X_TypeName href="#ref-28"/>
<Visible>true</Visible>
<Tag href="#ref-7"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-45">xrLabel1</Name>
<Style_X_Font id="ref-46">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-10"/>
<Style_X_BackColor href="#ref-11"/>
<Style_X_BorderColor href="#ref-10"/>
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
<ParentStyleUsing_X_UseForeColor>true</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>true</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>true</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>true</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>true</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName href="#ref-42"/>
<BindingItem0_X_DataMember id="ref-47">TextEin</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-7"/>
<BindingItem0_X_DataSource href="#ref-12"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>1</x>
<y>0</y>
<width>275</width>
<height>18</height>
</Bounds>
<Text href="#ref-45"/>
<NavigateUrl href="#ref-7"/>
<Target href="#ref-7"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
</SOAP-ENV:Body>
</SOAP-ENV:Envelope>' ,  N'' ,  N'DECLARE @BgBudgetID  int,
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
  FROM dbo.fnWhGetFinanzplan(@BgBudgetID, @GetDate)  TMP
    INNER JOIN XLOVCode     XPC ON XPC.LOVName = ''BgKategorie''    AND XPC.Code = TMP.BgKategorieCode
  WHERE BgKategorieCode IN (2, 4) -- Ausgaben / Kürzungen
    AND (TMP.Betrag != $0.00 OR (BgKategorieCode = 2 AND BgGruppeCode LIKE ''[0-9]%''))

SELECT
  TextEin = EIN.Text, BetragEin = EIN.Betrag,
  TextAus = AUS.Text, BetragAus = AUS.Betrag
FROM @Einnahmen         EIN
  FULL  JOIN @Ausgaben  AUS ON AUS.id = EIN.id' ,  null ,  N'ShFinanzplanverfuegung' ,  null );


INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShFinanzplanverfuegung_Personen' ,  N'Personen' , 1,  N'<!--
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
</SOAP-ENV:Envelope>' ,  N'' ,  N'SELECT
  Name              = PRS.NameVorname,
  PRS.Geburtsdatum,
  Nationalitaet     = PRS.Nationalitaet
FROM BgFinanzPlan_BaPerson   SPP
  INNER JOIN vwPerson        PRS ON PRS.BaPersonID = SPP.BaPersonID
WHERE SPP.BgFinanzPlanID = {BgFinanzPlanID}
AND SPP.IstUnterstuetzt = 1' ,  null ,  N'ShFinanzplanverfuegung' ,  null );


