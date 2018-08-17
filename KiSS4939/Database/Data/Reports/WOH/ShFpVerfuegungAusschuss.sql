-- Insert Script for ShFpVerfuegungAusschuss
DELETE FROM XQuery WHERE QueryName LIKE 'ShFpVerfuegungAusschuss' OR ParentReportName LIKE 'ShFpVerfuegungAusschuss'
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShFpVerfuegungAusschuss' ,  N'SH - Finanzplanverfügung Ausschuss' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Temp\KiSS4_Migration\KiSS4.DB.dll" />
///     <Reference Path="C:\Temp\KiSS4_Migration\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRRichTextBox xrRichTextBox5;
        private DevExpress.XtraReports.UI.XRRichTextBox xrRichTextBox4;
        private DevExpress.XtraReports.UI.XRLine xrLine6;
        private DevExpress.XtraReports.UI.XRLine xrLine4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLine xrLine5;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRPageBreak xrPageBreak1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRRichTextBox rtfRechsmittel;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.Subreport ShFpVerfuegungAusschuss_EinAus;
        private DevExpress.XtraReports.UI.Subreport ShFpVerfuegungAusschuss_Personen;
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
        private DevExpress.XtraReports.UI.XRLine Line8;
        private DevExpress.XtraReports.UI.XRLine Line7;
        private DevExpress.XtraReports.UI.XRLine Line6;
        private DevExpress.XtraReports.UI.XRLabel Label8;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.XRLabel Label3;
        private DevExpress.XtraReports.UI.XRLabel Label2;
        private DevExpress.XtraReports.UI.XRLabel txtTitle;
        private DevExpress.XtraReports.UI.XRRichTextBox rtfHinweis;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
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
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAAGAAAAAgAAAIwBRGV2RXhwcmVzc" +
                        "y5YdHJhUmVwb3J0cy5VSS5TZXJpYWxpemFibGVTdHJpbmcsIERldkV4cHJlc3MuWHRyYVJlcG9ydHMud" +
                        "jYuMiwgVmVyc2lvbj02LjIuNi4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPTc5ODY4Y" +
                        "jgxNDdiNWVhZTRoU3lzdGVtLkRyYXdpbmcuQml0bWFwLCBTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0yL" +
                        "jAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2ETtE6kV" +
                        "OAQ3VH+fwJOBiAakeC7ONBxXVxaAAAAKQAAAAAAAACRAAAA7QAAALwAAADyAgAAJHIAdABmAEgAaQBuA" +
                        "HcAZQBpAHMALgBSAHQAZgBUAGUAeAB0AAAAAAAscgB0AGYAUgBlAGMAaABzAG0AaQB0AHQAZQBsAC4AU" +
                        "gB0AGYAVABlAHgAdABlAwAAMnMAcQBsAFEAdQBlAHIAeQAxAC4AUwBlAGwAZQBjAHQAUwB0AGEAdABlA" +
                        "G0AZQBuAHQAvAUAACZ4AHIAUABpAGMAdAB1AHIAZQBCAG8AeAAxAC4ASQBtAGEAZwBlAP0RAAAseAByA" +
                        "FIAaQBjAGgAVABlAHgAdABCAG8AeAA0AC4AUgB0AGYAVABlAHgAdABN4AAALHgAcgBSAGkAYwBoAFQAZ" +
                        "QB4AHQAQgBvAHgANQAuAFIAdABmAFQAZQB4AHQAZuEAAEAAAQAAAP////8BAAAAAAAAAAwCAAAAG0Rld" +
                        "kV4cHJlc3MuWHRyYVJlcG9ydHMudjYuMgUBAAAALERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuU2Vya" +
                        "WFsaXphYmxlU3RyaW5nAQAAAAVWYWx1ZQECAAAABgMAAADpBXtccnRmMVxhbnNpXGFuc2ljcGcxMjUyX" +
                        "GRlZmYwXGRlZmxhbmcxMDMxXGRlZmxhbmdmZTEwMzFcZGVmdGFiNzA4e1xmb250dGJse1xmMFxmbmlsX" +
                        "GZjaGFyc2V0MCBBcmlhbCBOYXJyb3c7fX0NClx2aWV3a2luZDRcdWMxXHBhcmRcbGFuZzEwMzNcZjBcZ" +
                        "nMxOCBEYXMgQnVkZ2V0IGlzdCBuYWNoIFJpY2h0bGluaWVuIGRlciBTS09TIGJlcmVjaG5ldC4gRXMgZ" +
                        "2lsdCBhbHMgUmFobWVuYnVkZ2V0LiBFaW5uYWhtZW4gdW5kIEF1c2dhYmVuIGtcJ2Y2bm5lbiBtb25hd" +
                        "GxpY2ggXCdlNG5kZXJuLiBCZXdpbGxpZ3RlIFNpdHVhdGlvbnNiZWRpbmd0ZSBMZWlzdHVuZ2VuIHdlc" +
                        "mRlbiBuYWNoIHRhdHNcJ2U0Y2hsaWNoZW4gQXVmd1wnZTRuZGVuIFwnZmNiZXJub21tZW4uIFxwYXINC" +
                        "kRpZSBCZXpcJ2ZjZ2VyaW5uZW4gdW5kIEJlelwnZmNnZXIgc2luZCB2ZXJwZmxpY2h0ZXQsIFwnYzRuZ" +
                        "GVydW5nZW4gZGVyIGZpbmFuemllbGxlbiBTaXR1YXRpb24gdW1nZWhlbmQgZGVuIFNvemlhbGVuIERpZ" +
                        "W5zdGVuIHp1IG1lbGRlbi4gRWluZSBWZXJoZWltbGljaHVuZyBvZGVyIGRpZSBBbmdhYmUgZmFsc2NoZ" +
                        "XIgVGF0c2FjaGVuIGthbm4gZWluZSBzb2ZvcnRpZ2UgUlwnZmNja3phaGx1bmdzcGZsaWNodCBhdXNsX" +
                        "CdmNnNlbiB1bmQgc3RyYWZyZWNodGxpY2hlIEZvbGdlbiBuYWNoIHNpY2ggemllaGVuLlxwYXINClNve" +
                        "mlhbGhpbGZlbGVpc3R1bmdlbiBzaW5kIHJcJ2ZjY2tlcnN0YXR0dW5nc3BmbGljaHRpZy5ccGFyDQp9D" +
                        "QoLQAABAAAA/////wEAAAAAAAAADAIAAAAbRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy52Ni4yBQEAAAAsR" +
                        "GV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5TZXJpYWxpemFibGVTdHJpbmcBAAAABVZhbHVlAQIAAAAGA" +
                        "wAAANsDe1xydGYxXGFuc2lcYW5zaWNwZzEyNTJcZGVmZjBcZGVmbGFuZzIwNTVcZGVmbGFuZ2ZlMjA1N" +
                        "XtcZm9udHRibHtcZjBcZm5pbFxmY2hhcnNldDAgQXJpYWw7fX0NClx2aWV3a2luZDRcdWMxXHBhcmRcb" +
                        "m93aWRjdGxwYXJcZnMyMCBHZWdlbiBkaWVzZSBWZXJmXCdmY2d1bmcga2FubiBpbm5lcnQgMzAgVGFnZ" +
                        "W4gc2VpdCBkZXIgRXJcJ2Y2ZmZudW5nIGJlaW0genVzdFwnZTRuZGlnZW4gUmVnaWVydW5nc3N0YXR0a" +
                        "GFsdGVyYW10IElJLCBBbXRzaGF1cywgSG9kbGVyc3RyLiA3LCAzMDAxIEJlcm4sIFZlcndhbHR1bmdzY" +
                        "mVzY2h3ZXJkZSBnZWZcJ2ZjaHJ0IHdlcmRlbi4gRGllIEJlc2Nod2VyZGUgaXN0IGltIERvcHBlbCBla" +
                        "W56dXJlaWNoZW4sIG11c3MgZWluZW4gQW50cmFnLCBkaWUgQW5nYWJlbiB2b24gVGF0c2FjaGVuLCBla" +
                        "W5lIEJlZ3JcJ2ZjbmR1bmcgc293aWUgZWluZSBVbnRlcnNjaHJpZnQgZW50aGFsdGVuLlxwYXINCn0NC" +
                        "gsBvhgtLSBQYXJhbWV0ZXINCkRFQ0xBUkUgQEdldERhdGUgZGF0ZXRpbWUgIFNFVCBAR2V0RGF0ZSA9I" +
                        "EdldERhdGUoKQ0KREVDTEFSRSBAQmdGaW5hbnpwbGFuSUQgaW50IFNFVCBAQmdGaW5hbnpwbGFuSUQgP" +
                        "SBudWxsDQoNCkRFQ0xBUkUgQEJnQnVkZ2V0SUQgaW50DQpTRUxFQ1QgQEJnQnVkZ2V0SUQgPSBCZ0J1Z" +
                        "GdldElEIEZST00gQmdCdWRnZXQNCldIRVJFIEJnRmluYW56cGxhbklEID0gQEJnRmluYW56cGxhbklEI" +
                        "EFORCBNYXN0ZXJCdWRnZXQgPSAxDQoNCg0KDQoNCkRFQ0xBUkUgQFRvdEluIG1vbmV5DQpERUNMQVJFI" +
                        "EBUb3RPdXQgbW9uZXkNCg0KU0VMRUNUIEBUb3RJbiA9IFNVTShCZXRyYWcpDQpGUk9NIGRiby5mbldoR" +
                        "2V0RmluYW56cGxhbihAQmdCdWRnZXRJRCwgQEdldERhdGUpICBUTVANCiAgSU5ORVIgSk9JTiBYTE9WQ" +
                        "29kZSAgWFBDIE9OIFhQQy5MT1ZOYW1lID0gJ0JnS2F0ZWdvcmllJyBBTkQgWFBDLkNvZGUgPSBUTVAuQ" +
                        "mdLYXRlZ29yaWVDb2RlDQpXSEVSRSBCZ0thdGVnb3JpZUNvZGUgPSAxDQoNClNFTEVDVCBAVG90T3V0I" +
                        "D0gU1VNKENBU0UgV0hFTiBCZ0thdGVnb3JpZUNvZGUgPSAyIFRIRU4gVE1QLkJldHJhZyBFTFNFIC1UT" +
                        "VAuQmV0cmFnIEVORCkNCkZST00gZGJvLmZuV2hHZXRGaW5hbnpwbGFuKEBCZ0J1ZGdldElELCBAR2V0R" +
                        "GF0ZSkgIFRNUA0KICBJTk5FUiBKT0lOIFhMT1ZDb2RlICBYUEMgT04gWFBDLkxPVk5hbWUgPSAnQmdLY" +
                        "XRlZ29yaWUnIEFORCBYUEMuQ29kZSA9IFRNUC5CZ0thdGVnb3JpZUNvZGUNCldIRVJFIEJnS2F0ZWdvc" +
                        "mllQ29kZSBJTiAoMiwgNCkNCg0KDQoNCkRFQ0xBUkUgQEJlbWVya3VuZyB2YXJjaGFyKDgwMDApLA0KI" +
                        "CAgICAgICBASXRlbVRleHQgICAgIHZhcmNoYXIoODAwMCkNCg0KREVDTEFSRSBjQmVtZXJrdW5nIENVU" +
                        "lNPUiBGQVNUX0ZPUldBUkQgRk9SDQogIFNFTEVDVCAnLSAnICsgWExDLlRleHQgKyAnICgnICsgUFJTL" +
                        "k5hbWUgKyBJc051bGwoJywgJyArIFBSUy5Wb3JuYW1lLCAnJykgKyAnKTogJyArIEJQTy5CZW1lcmt1b" +
                        "mcNCiAgRlJPTSBCZ1Bvc2l0aW9uICAgICAgICAgICAgIEJQTw0KICAgIElOTkVSIEpPSU4gQmFQZXJzb" +
                        "24gICAgICBQUlMgT04gUFJTLkJhUGVyc29uSUQgPSBCUE8uQmFQZXJzb25JRA0KICAgIElOTkVSIEpPS" +
                        "U4gQmdQb3NpdGlvbnNhcnQgIFNQVCBPTiBTUFQuQmdQb3NpdGlvbnNhcnRJRCA9IEJQTy5CZ1Bvc2l0a" +
                        "W9uc2FydElEDQogICAgSU5ORVIgSk9JTiBYTE9WQ29kZSAgICAgICBYTEMgT04gWExDLkxPVk5hbWUgP" +
                        "SAnQmdHcnVwcGUnIEFORCBYTEMuQ29kZSA9IFNQVC5CZ0dydXBwZUNvZGUNCiAgV0hFUkUgQlBPLkJnQ" +
                        "nVkZ2V0SUQgPSBAQmdCdWRnZXRJRA0KICAgIEFORCBCUE8uQmdQb3NpdGlvbnNhcnRJRCBCRVRXRUVOI" +
                        "DM5MDAwIEFORCAzOTk5OQ0KICAgIEFORCBOT1QgKEJQTy5CZW1lcmt1bmcgSVMgTlVMTCBPUiBCUE8uQ" +
                        "mVtZXJrdW5nID0gJycpDQogICAgQU5EIEdldERhdGUoKSBCRVRXRUVOIElzTnVsbChCUE8uRGF0dW1Wb" +
                        "24sICcxOTAwMDEwMScpIEFORCBJc051bGwoQlBPLkRhdHVtQmlzLCBHZXREYXRlKCkpDQogIE9SREVSI" +
                        "EJZIFBSUy5OYW1lLCBQUlMuVm9ybmFtZQ0KDQpPUEVOIGNCZW1lcmt1bmcNCldISUxFICgxID0gMSkgQ" +
                        "kVHSU4NCiAgRkVUQ0ggTkVYVCBGUk9NIGNCZW1lcmt1bmcgSU5UTyBASXRlbVRleHQNCiAgSUYgQEBGR" +
                        "VRDSF9TVEFUVVMgIT0gMCBCUkVBSw0KDQogIFNFVCBAQmVtZXJrdW5nID0gSXNOdWxsKEBCZW1lcmt1b" +
                        "mcgKyBDSEFSKDEwKSArIENIQVIoMTMpLCAnJykgKyBASXRlbVRleHQNCkVORA0KQ0xPU0UgY0JlbWVya" +
                        "3VuZw0KREVBTExPQ0FURSBjQmVtZXJrdW5nDQoNCg0KDQpTRUxFQ1QgQkJHLkJnQnVkZ2V0SUQsDQogI" +
                        "CAgICAgVGl0bGUgICAgICAgID0gJ1ZlcmbDvGd1bmcgU296aWFsaGlsZmUgdm9tICcgKyBjb252ZXJ0K" +
                        "HZhcmNoYXIsIElTTnVsbChTRlAuRGF0dW1Wb24sIFNGUC5HZXBsYW50Vm9uKSwgMTA0KSArICcgYmlzI" +
                        "CcgKyBjb252ZXJ0KHZhcmNoYXIsIElzTnVsbChTRlAuRGF0dW1CaXMsIFNGUC5HZXBsYW50QmlzKSwgM" +
                        "TA0KSwNCiAgICAgICBBZHJlc3NlICAgICAgPSBpc251bGwoY2FzZSBQUlMuR2VzY2hsZWNodENvZGUgd" +
                        "2hlbiAxIHRoZW4gJ0hlcnInIHdoZW4gMiB0aGVuICdGcmF1JyBlbmQgKyBjaGFyKDEzKSArIGNoYXIoM" +
                        "TApLCcnKSArDQogICAgICAgICAgICAgICAgICAgICAgaXNudWxsKFBSUy5Wb3JuYW1lKycgJywnJykgK" +
                        "yBQUlMuTmFtZSArIGNoYXIoMTMpICsgY2hhcigxMCkgKw0KICAgICAgICAgICAgICAgICAgICAgIGlzb" +
                        "nVsbChBRFIuU3RyYXNzZSArICcgJywnJykgKyBpc251bGwoQURSLkhhdXNOciwnJykgKyBjaGFyKDEzK" +
                        "SArIGNoYXIoMTApICsNCiAgICAgICAgICAgICAgICAgICAgICBpc251bGwoQURSLlBMWiArICcgJywnJ" +
                        "ykgKyBpc251bGwoQURSLk9ydCwnJyksDQogICAgICAgQmVtZXJrdW5nID0gSXNOdWxsKENPTlZFUlQod" +
                        "mFyY2hhcig4MDAwKSwgU0ZQLkJlbWVya3VuZykgKyBDSEFSKDEwKSArIENIQVIoMTMpLCAnJykgKyBJc" +
                        "051bGwoQEJlbWVya3VuZywgJycpLA0KICAgICAgIFRvdEluICAgICAgICA9IEBUb3RJbiwNCiAgICAgI" +
                        "CBUb3RPdXQgICAgICAgPSBAVG90T3V0LA0KICAgICAgIEZlaGxiZXRyYWcgICA9IGlzTnVsbChAVG90T" +
                        "3V0LDApIC0gaXNOdWxsKEBUb3RJbiwwKQ0KRlJPTSAgIEJnQnVkZ2V0IEJCRw0KICAgICAgIGlubmVyI" +
                        "GpvaW4gQmdGaW5hbnpwbGFuICBTRlAgb24gU0ZQLkJnRmluYW56cGxhbklEID0gQkJHLkJnRmluYW56c" +
                        "GxhbklEDQogICAgICAgaW5uZXIgam9pbiBGYUxlaXN0dW5nICAgIEZBTCBvbiBGQUwuRmFMZWlzdHVuZ" +
                        "0lEID0gU0ZQLkZhTGVpc3R1bmdJRA0KICAgICAgIGlubmVyIGpvaW4gQmFQZXJzb24gICAgIFBSUyBvb" +
                        "iBQUlMuQmFQZXJzb25JRCA9IEZBTC5CYVBlcnNvbklEDQogICAgICAgaW5uZXIgam9pbiBCYUFkcmVzc" +
                        "2UgICAgQURSIG9uIEFEUi5CYUFkcmVzc2VJRCA9IChzZWxlY3QgTUFYKEJhQWRyZXNzZUlEKSBmcm9tI" +
                        "EJhQWRyZXNzZSB3aGVyZSBCYVBlcnNvbklEPVBSUy5CYVBlcnNvbklEIGFuZCBBZHJlc3NlQ29kZT0xI" +
                        "C8qd29obnNpdHoqLykNCldIRVJFICBGQUwuTW9kdWxJRCA9IDMgYW5kDQogICAgICAgQkJHLkJnQnVkZ" +
                        "2V0SUQgPSBAQmdCdWRnZXRJREEAAQAAAP////8BAAAAAAAAAAwCAAAAUVN5c3RlbS5EcmF3aW5nLCBWZ" +
                        "XJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49YjAzZjVmN2YxMWQ1M" +
                        "GEzYQUBAAAAFVN5c3RlbS5EcmF3aW5nLkJpdG1hcAEAAAAERGF0YQcCAgAAAAkDAAAADwMAAACtzQAAA" +
                        "olQTkcNChoKAAAADUlIRFIAAA/ZAAABJggGAAAAfPXByAAAAAFzUkdCAK7OHOkAAAAEZ0FNQQAAsY8L/" +
                        "GEFAAAAIGNIUk0AAHomAACAhAAA+gAAAIDoAAB1MAAA6mAAADqYAAAXcJy6UTwAAM0rSURBVHhe7d0Lc" +
                        "ms5jiDQ2f+qcmc91stWp9JpCQAJ8lLycURFTMwF8TmkJD+3WPX//p8fAgQIECBAgAABAgQIECBAgAABA" +
                        "gQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAg" +
                        "AABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIE" +
                        "CBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABA" +
                        "gQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAg" +
                        "AABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIE" +
                        "CBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABA" +
                        "gQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAg" +
                        "AABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIE" +
                        "CBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABA" +
                        "gQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAg" +
                        "AABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIE" +
                        "CBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABA" +
                        "gQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAg" +
                        "AABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgACBgwT+56uXd/7PQZQ/t" +
                        "PI/fggQIECAAAECBAgQIECAAAECBAgQIJAQOPsvnbojQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECHyMwDtfrr/3fvZmJL47K4QAAQIECBAgQIAAAQIECBAgQIAAAQK3P3j6IUCAA" +
                        "AECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQWC/w56L6X3/99Xb/ufX9v/9Zr" +
                        "zRTwXeDCRAgQIAAAQIECBAgQIAAAQIECBAgkBGY+TuktQQIECBAgAABAgQIECBAgAABAgQIECBAgAABA" +
                        "gQIECBAgAABAgQIECBAgAABAmkBl+zTVIOBmS/PiiFAgAABAgQIECBAgAABAgQIECBAgMDgnyAtI0CAA" +
                        "AECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQqAm4ZF/zqkf7ajABAgQIECBAg" +
                        "AABAgQIECBAgAABAgQyAvW/PlpBgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABA" +
                        "gQIECAwIOCS/QBaaUnmy7NiCBAgQIAAAQIECBAgQIAAAQIECBAgUPrDo2ACBAgQIECAAAECBAgQIECAA" +
                        "AECBAgQIECAAAECBAgQIECAAAECBAgQIECAAIFRAZfsR+Wy63w1mAABAgQIECBAgAABAgQIECBAgAABA" +
                        "hmB7N8cxREgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECEwJuGQ/xZdYn" +
                        "PnyrBgCBAgQIECAAAECBAgQIECAAAECBAgk/twohAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABA" +
                        "gQIECBAgAABAgQIECBAYF7AJft5w9cZfDWYAAECBAgQIECAAAECBAgQIECAAAECGYHVf6uUnwABAgQIE" +
                        "CBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBA4I+AS/arD0Lmy7NiCBAgQIAAAQIEC" +
                        "BAgQIAAAQIECBAgsPpvlfITIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECB" +
                        "Aj8EXDJfvVB8NVgAgQIECBAgAABAgQIECBAgAABAgQIZARW/61SfgIECBAgQIAAAQIECBAgQIAAAQIEC" +
                        "BAgQIAAAQIECBAg8IsF/lyievKfFSyv6t2f7a67ot6qnDv3KjvDiT1lexc3J7D7/ePW7ex7iPP6fM9Pt" +
                        "JnpaWbt3CvjfVYzWrdX727rkv26s/F35syXZ8UQIECAAAECBAgQIECAAAECBAgQIEBg9d8q5SdAgAABA" +
                        "gQIECBAgAABAgQIECBAgAABAgQIECBAgAABAr9YILqw2k0T1bs97/6JanbXW5nvxEt7J/a0cg/k/kdg9" +
                        "yX76LWcef9wXp+f4BNtZnqaWftbXueM1u30u9u6ZL/ubPyd2VeDCRAgQIAAAQIECBAgQIAAAQIECBAgk" +
                        "BFY/bdK+QkQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAwC8X2HVRNnNBdsX/mv2u+XYcoxMv7" +
                        "Z3Y0469UOP1/6p8t0/m/SNT03l9rnSizUxPM2szZ+kTYhit28V3t3XJft3Z+Dtz5suzYggQIECAAAECB" +
                        "AgQIECAAAECBAgQILD6b5XyEyBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgACBXy6w6xJ65pKsS" +
                        "/avD+OJl/ZO7OmXv6S3jX/Se0d2aOf1udSJNjM9zazNnqd3j2O0bgff3dYl+3Vn4+/MvhpMgAABAgQIE" +
                        "CBAgAABAgQIECBAgACBjMDqv1XKT4AAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIEfrnASRdlX" +
                        "bJ/fRhPvLR3Yk+//CW9bfwd7x2Z/3KOysDO63OtE21meppZWzlT7xzLaN3uvbutS/brzsbfmTNfnhVDg" +
                        "AABAgQIECBAgAABAgQIECBAgACB1X+rlJ8AAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECPxyg" +
                        "VMuyn7vo2tbdszX1WuU58RLeyf2FDl63iOw+rXVfcH+NrXz+nzvT7SZ6Wlmbc8r5PwsjNbt0bvbumS/7" +
                        "mz8ndlXgwkQIECAAAECBAgQIECAAAECBAgQIJARWP23SvkJECBAgAABAgQIECBAgAABAgQIECBAgAABA" +
                        "gQIECBAgACBpxdPb5esOn5eXTZbeRFt9SXgDptKjpVWlT4eY0/saXQW62oCK19fKy7Y16b7fdEnvpZP7" +
                        "OmTTgbfdbv57rYu2a87G39nznx5VgwBAgQIECBAgAABAgQIECBAgAABAgRW/61SfgIECBAgQIAAAQIEC" +
                        "BAgQIAAAQIECBAgQIAAAQIECBAgQMAl+zc5Ayde2juxpzfZzrdvc9UlexfsrzkaJ76WT+zpmt1ZU5XvG" +
                        "tdb1ne3dcl+3dn4O7OvBhMgQIAAAQIECBAgQIAAAQIECBAgQCAjsPpvlfITIECAAAECBAgQIECAAAECB" +
                        "AgQIECAAAECBAgQIECAAAECLtm/yRk48dLeiT29yXa+fZsrLtm7YH/dsTjxtXxiT9ftUH9lvv2m94zvb" +
                        "uuS/bqz8XfmzJdnxRAgQIAAAQIECBAgQIAAAQIECBAgQGD13yrlJ0CAAAECBAgQIECAAAECBAgQIECAA" +
                        "AECBAgQIECAAAECBJZess9cNMvEjGzTikvAI310rVnlNNPfiT3NzGNtXqD79eWCfd5+ReSJr+UTe1phf" +
                        "1VOvuvk393WJft1Z+PvzL4aTIAAAQIECBAgQIAAAQIECBAgQIAAgYzA6r9Vyk+AAAECBAgQIECAAAECB" +
                        "AgQIECAAAECBAgQIECAAAECBAj8Eei+MHtnzVw0y8RUt2nVPNU+OuNXOM32d2JPszNZnxPofI25YJ8zX" +
                        "xl14mv5xJ5W7sHu3HzXib+7rUv2687G35kzX54VQ4AAAQIECBAgQIAAAQIECBAgQIAAgdV/q5SfAAECB" +
                        "AgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQ+CPQeWH2kTRz0SwTU92mVfNU++iMX+E029+JPc3OZ" +
                        "H1OoOs15oJ9znt11Imv5RN7Wr0PO/PzXaf97rYu2a87G39n9tVgAgQIECBAgAABAgQIECBAgAABAgQIZ" +
                        "ARW/61SfgIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQOCPQNeF2e+cmYtmmZjqNq2a57GP3" +
                        "ZeDq05Rf1XTn+KrPVVr7pih2lP2jN96/+Sf2ddYtLf35+9m+NNcHTNEXrM1qq/l1f28+lyanXXF+tnXw" +
                        "2xPI/Wrez7SY3ROrnqdR32NzJr5/eBZ3tX9VOdxyb4qVo3PfHlWDAECBAgQIECAAAECBAgQIECAAAECB" +
                        "Kp/exRPgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIDAmMXNCLClUu8FVio7q35yvmudeNL" +
                        "sPtvmT73aPaX8bzWUz3vkV7t3JfX9W+0nhmf1aundmL7Bnt7n/mvEav68xM1XkyOaO+sjWzNtWesvV/i" +
                        "sv2dNXanRaVGbNu2bjqHlZdvsdX62XjR/vK5n+My9pWexrpZWSNS/YjapU1vhpMgAABAgQIECBAgAABA" +
                        "gQIECBAgACBjEDl745iCRAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAgSmB7KWwbJFKvkpsp" +
                        "n53vlvN6mW4rsuv93kzM432mDH9KSbTUzb3aO+dFzQz88z0mbV4h7jRS/ZZvxUGmf19VvfV6zk70y0u8" +
                        "1PJN7oP3/vI2Iz2lZm5+/0lM09lr7/v3ahF9gxEZqP1H/POGFX2q6PXyOPV89H6M58tGdvRvmYssmv/9" +
                        "PbXX3+93X8eflfLznpNXObLs2IIECBAgAABAgQIECBAgAABAgQIECBwzV8wVSVAgAABAgQIECBAgAABA" +
                        "gQIECBAgAABAgQIECBAgAABAr9SoOuy5h0vc8lsJDbanO45bvVGL8O9upgbzfH9eeQ522O1n1cu1Vyzv" +
                        "c9chnzsdbVx1wXbqu+K+JHXWXafV/Q7e16fvZazM2X3vpIvE5u1XH32s31UXo+vckbzzKzNuEcxIx5dn" +
                        "0W7P3cji5H3kqzfTO2Zz+/o/M32lZ1/NM4l+1G57DpfDSZAgAABAgQIECBAgAABAgQIECBAgEBGIPs3R" +
                        "3EECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIDAtEDnRbdqrmr8q2E7c93qzF6Gm7mo9zjnq" +
                        "0t7XT1WD1F0kTCTr6v3jov2JxpnDK+Iqb7Osvu8cpaZ87rjkn3WqBqXMT3x7Hfv1y1f5udEi+7Polf5M" +
                        "kaZz6bqOe36rLz31lF/tKdTz1B2b12yz0qNxmW+PCuGAAECBAgQIECAAAECBAgQIECAAAECo3+DtI4AA" +
                        "QIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAoC1Qvzb4qMHI5cmTNTz3smKPj8l51gzpqZnJU+" +
                        "prds0w/MzGVWW6xM7Uqa6t9nRhfeZ1lbVbPOXNeszNUXB7n7cg/WvvUs79ivzJnbPVe3PNnetl5Rkb62" +
                        "mFVddpxnqOedrjcaqz6ccl+lew9r68GEyBAgAABAgQIECBAgAABAgQIECBAICOw+m+V8hMgQIAAAQIEC" +
                        "BAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQL/Epi51PiYaCTPyJqftm91nsf8r45P5pJd5fhl8kW9ZXJ09" +
                        "JTJ0dFLR47Muf2pzrMZu3vKWF4Rk73QnfFYeVk0s78Zv9E5MheXR3Pf+86sj2bM5PiE95fI4fa8YrHrf" +
                        "SDT00wv0d5WPmsruWbmmp13Zn10jjJzRU6ZHFEfo89dsh+Vy67LfHlWDAECBAgQIECAAAECBAgQIECAA" +
                        "AECBLJ/cxRHgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQItAhkL85GxUYuuo+s+d7H6v4zF" +
                        "2Yfe+q8JJfJlb2svNopOh+35109RLmyJpk8lf3vnC/juTsmM1/nme2Yb+Y9JjPLSI+deaNcr/qL1l5x9" +
                        "lfsV2aPTrOI+snM1P3+FuXL9nSP2zljtreZnqK1V7yesnP/397+9ddf//Nu/3n43aIy7/5YXw0mQIAAA" +
                        "QIECBAgQIAAAQIECBAgQIBARmD/Xy9VJECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECv1ogc" +
                        "3E2ArrqYuStr47+O/PcrTr6ii7tRfvy/fnKnqJeOmrvnKdyIfKxrxVzRra7nkezRef18fnVPWfqR/Nkc" +
                        "vwUEzlW847m655vtI/M6ydjsuJz6Kr3gQ7LzGdRdb7Ovro+d0/p6cTXU+Z1869z8m4X7G/9PvweWJl3f" +
                        "2zmy7NiCBAgQIAAAQIECBAgQIAAAQIECBAgsP+vlyoSIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQI" +
                        "ECAAIFfLdBxQW3F5cbspqzs/5Z75me2txMv7Y3u9ei6yH8274nG0cxXPY+sqs93zDFzPmZfv8/mm+mpm" +
                        "vPVe1i0X9X96fCasVmxtnoJ/W42YzGzduR8ZD/nVvR163dm3zrW/2Q2MuuJr6fKa/hP/y7ZV8iKsb4aT" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAgYxA8U+PwgkQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAA" +
                        "IF5gSsvuV1Z+y43cqEuoz6bd3b9Tz1e4T1bM7KeyX+icTTvVc+jS6Qjz1fP8i5nI3vR+ZnXyDkeWRPt1" +
                        "4z3LffM+hVrZ/ZltJ+d+1L5LxEYnWflmVlh9eocvjoPK3pZZf70dwOX7KPjOvE88+VZMQQIENgp8OIXr" +
                        "/98AO3sSy0CBAgQIECAAAECpwn43fl/Sn/4P23/9EPgHQUm/gxpKQECBAgQIECAAAECBAgQIECAAAECB" +
                        "AgQIECAAAECBAgQIDAmMHM5bGbtrdtV6ysSKy+yzeSetfnJYKafV/v1ynu2ZrSXM/lPNI7mvep56bt0w" +
                        "Wv7MdfKeX7T2aiannj2V+xX5nydZDFjMPI+PPJfJFA9ayN9zexbZm0UU53xpDMUzfb0dwOX7Efokmve8" +
                        "cu8eiZA4LMFCr+sfzaE6QgQIECAAAECBAgEAn53dsnei4TAboHknxyFESBAgAABAgQIECBAgAABAgQIE" +
                        "CBAgAABAgQIECBAgAABAn0CM5fDOi4EjuaY6ftRb7R+Zgdmcs+sfdbbbM6R9T+tydhVYkZrjMwT9bUiZ" +
                        "1Rzx3OX7P/+LwWZ+TnpbKzoZTbnzPqr1na/187M8epsdn1ezpz/n9bOzDuz9qQ5us/QyGx/LF2yH6FLr" +
                        "tn9RdzZercDMfqf2drWEyCwR6DyGt/TkSoECBAgQIAAAQIEzhTwu7NL9meeTF19skDyT47CCBAgQIAAA" +
                        "QIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAgT6Bmct3HZfcRnPM9H3X68jxaidm8o+6jPSTPU3Vnqrx2" +
                        "T6+x43WGV230njUYPW6kft2mdfZ7MX1VXvRfTZm3gtW7G33fLceZ3POrL9q7bO9GelnZE32bJx2/qL3h" +
                        "miu0+ZZsXcrcr48ry7ZR8du4vnpX/p98QY+8uH/45rTDfRH4LcJVF73v83GvAQIECBAgAABAgQeBfzu7" +
                        "JK9VwSB3QITf4a0lAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIEBgXGL3MNbrusdPRHKPrO" +
                        "mpXpEf7HF33qrfZnNX1bXezvoYayRXtU3WeKN/t+YqcmbqrY6r+mdfZY84V/c/sxczan2bpzjfrtaKf2" +
                        "Zwz669a+2wfRvoZWVM5B6vzd/Ry7zHKddIsq973d874p5ZL9tGxm3i++4u4mXqDv1hVfxlw4T6zGWL+I" +
                        "1A9nwjrAhXjenYrThao7H1n7MkmUW9Vhyif5wQIEPhtApX30ZNsKn3fYk/6qfR+Ut+n9sLTJftTz6a+P" +
                        "ldg4s+QlhIgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQLjAiOXuUbWPOtwJNfImu/1O3JE6" +
                        "qM1Rte96mc2Z3V9y12sr4FG86zam5XGUc9XPa/swU89ZtZ3z1Y9r4/1Z9ZW5u+eOZuve75b3dmcM+uvW" +
                        "nvaZ9qp702Z1/9jTHSOZ/Y7yj3yfEU/K3K+PK8u2Y9sfXLNSV/5nfilqvpCTsWfZKOXcwSq5/Sczt+nk" +
                        "4rx+0yl04xAZe93xGZ6vjqm6nB1v+oTIEDgNIF3fR/V92kn6bp+Kmfhui7XVmaw1ld2At8Fkn9yFEaAA" +
                        "AECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAj0Cry6B/OsUucFsGqukX5/mqNad0R9tMboulc9z" +
                        "uasrk/dr/pqeFVctF/VeaJ8t+crcmbqro7J7tHI+bvn7p5hZi9m1l71XlPx656v4+zP9HTV2s7Px5kZM" +
                        "nt/Vf7se4dL9v/exdX79VjtTy2X7DMvo8GYE74qvPCXrZEX+Y9rTnDSwxkC1fN6Rtfv1UXF+L0m020kU" +
                        "Nn7K2Kj/q94XnW4okc1CRAgcLpA5b30lFkqPd9jT+i90vcJ/b5DD0z9L9m/wznV42cJDP4J0jICBAgQI" +
                        "ECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIEBgTmDk0nrnBbBqrpF+fxKq1h1RHq0xuu5Vj7M5q+vb7" +
                        "l19DTWSK9qv6jxRvtvzFTkzdVfHZPwzPUR5MjmyMTN7MbP2qvearMuqczprNrP+qrXPzEf6GVlz5Z5Hr" +
                        "+WZ59Fcq62i+t+fr+hnRc6X59Ul++q2F+Kv/prv4C9RMy/iqbVXe6l/vUD1zF7f8ft1UDF+v+l0/Eqgs" +
                        "vdXx56yk1WHU/rWB4GrBSqvnat7VX+9wDueh0rP99j1knGFSt9xNhE3AaYMvBII7BYo/NlRKAECBAgQI" +
                        "ECAAAECBAgQIECAAAECBAgQIECAAAECBAgQINArULnQ1XXJ/T5BpfZtTTX+mVRXnlc7MVpjdN2KXrr3q" +
                        "fTdtBf7HeWJXiEnGkc9X/V81jo6Q4/5u2ac2d+ZtT/1351v1mhFP7M5Z9Zftbbzs2Vmhsx56MwfvR/MP" +
                        "o/m6ZwlqpV5vqKfFTlfnleX7DNbPRiz+4u4j/UmfomafSEPr7/SS+0zBKrn9oyu36uLivF7TabbSKCy9" +
                        "6fERjOtfl51WN2P/ATeRaDy2nmXmfQ5LvBu56HS72PsuFDfykrvfVU/OxNTl+w/+4Sb7kSBwT9BWkaAA" +
                        "AECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAjMC1QudFVis51VclZiX9XvyrOixoreZnNW1w/fr" +
                        "/oC7Vgbnb3qPFG+2/MVOTN1V8e82o9q7czeVnP+FD+zFzNru3vpsPieo3u+jrM/09NVa5/tzUg/I2sqZ" +
                        "6Mjf+a12xETzdUxS1Sj8nxFPytyvjyvLtlXtrwYe9WXdZt+mep4UZdyXOWl7jkC1bN7Tufv00nF+H2m0" +
                        "mlGoLL3p8Vm5lsRU3VY0YOcBN5RoPLaecf59FwTqJyHW+zVP9V+7/Hv1vfV/b5L/cp5eJeZqn0yqIqJJ" +
                        "zAnUPzTo3ACBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECgT6ByiXbF5a9szkqfkU62ZpTn1" +
                        "fPRGqPrVvRyz1ntqRo/4zyydkV/K3KOzNa9pvN1d+stum/X0f/MXsys/an37nyzPiv6mc05s/6qtc/2Y" +
                        "aSfkTWVczCbP3rNVp6PfqbMrqt4VWJnba9+z/jTv0v2lS0vxs59rXZsdeKDtvKi3Ro7NrFVnyRQPb+fN" +
                        "PuuWSrGu3pSZ49AZe9Pjd0j9U+VqsPu/tQjcKpA5bVz6gz66hV4pzNR6fV7bK9aLVul71rm3x3N1f+S/" +
                        "e9+BZj+CoHinx6FEyBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAn0ClUu0V14oq/QZ6ayY4" +
                        "3vN0Rqj617NPJuzur4aH+1X9/MV/a3I2T33SL7O1929fnRnb6TPxzUzezGz9qe+u/NdafOs9uyMM+uvW" +
                        "ttpMTND5jzM5o9eryP5R9bcZh1dl3EaiVnRz4qcL8+rS/YjW59cs/vLuC9eJKMv5K3rdnupd55A9QyfN" +
                        "8H5HVWMz59GhxWByt6fHFuZeTa26jBbz3oCnyJQee18yszmeC3wTmei0uv32CvPQaXvK/t8t9pcXbJ/t" +
                        "zOr3/cXSP7JURgBAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECCwRiBzqSsTM9pdJncmJlu/M" +
                        "9ezmqM1Rte9mn02Z3V9NT67b11xK/pbkbNr3pk8V1yyv9Wc+ZnZi5m1P/XcnW/G5bZ2RT+zOWfWX7W28" +
                        "31/ZobMeZjJn7lfm+nhe8xoT6PrRnrMrFnRz4qcL8+rS/aZrR6M2fnV3hdv8JkX8r9iKn1fVbfSo9j3E" +
                        "aiep/eZ7JxOK8bndK2TDoHK3p8e2+GRyVF1yOQUQ+A3CFReO7/Bw4zvc0m3cnZ/ir1yryu9X9nnu9Xm+" +
                        "j6v33c7W/ol8Exg8E+QlhEgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQI9AplLXZmY0W4yu" +
                        "TMx2forLg4/1p7J3znnvafZnNX1M/Nn93AmrjpPptaKnJm6q2NW7WXmzt/obDN7MbP2p35X+T17v4nMu" +
                        "ue71ZvNObP+qrXPnEf6WX1GRnqKPjtuOWd+RntabfX9PEczjs7xKu+KnC/Pq0v20TZPPN/1leEXb8SZD" +
                        "9s/MZ0/o/109iDXewpUz857Tnlt1xXjaztVvVugsvfvEttt9D1f1WF1P/ITeBeBymvnXWbS55xA5Ux0/" +
                        "9uk0nm1z+/xlVqdsdW+O2t/eq6K7adaMPjUnTXXqQITf4a0lAABAgQIECBAgAABAgQIECBAgAABAgQIE" +
                        "CBAgAABAgQIEJgXyFzqysSMdpLJnYmp1O/O91h7JvfM2mfzz+YcWT+yprJ/M7EreluRc2bGrrUrL7VGd" +
                        "/9GZ5jZi5m1q15/kUOl50psVPf+fDbnzPqr1nbv9cwcr/Zp5vU7szY6OzPzzqyN+ro9r+SvxGZqV+tnc" +
                        "748ry7ZzzK+WL/jC7svDm30Idt+ud7lxB07/tk1quf5szXWTFcxXtOBrFcJ7N77Sr2Z2JWe1b5W9iI3g" +
                        "XcSqLx23mkuvc4JvMO5qPT4LHZOaWx1pe+xCr93FVv/S/a/9/Sb/CqBhX+mlJoAAQIECBAgQIAAAQIEC" +
                        "BAgQIAAAQIECBAgQIAAAQIECBCIBTKX6VZcJrt3FuXO9BdP+e+IqGY132P8TO6Ztc96ns05sn5kTdX8s" +
                        "UZl7YreVuSszLQqdsVrL/NaudcdmWtmL2bWrnr9vTKo7s+J8830dNXa7r2emaPzfGRemyOvyUzem0HmZ" +
                        "5XVrfYnvJ4yhv/63csl+wpZMXbHF3KDg/v0UO/o7bFGps/dPalH4DcKZF6L95jf6PPJM5+w95UeKrGfv" +
                        "G9mI/COAl6/77hr63t+h3NR6fFZ7HrJ/1ao9H1Ff+9ck61L9u98fvX+ngLFPz0KJ0CAAAECBAgQIECAA" +
                        "AECBAgQIECAAAECBAgQIECAAAECBHoFootlKy+13Sd5VSPqb0RjRc5bH7N5V1jP5hxZP+sQ7elM/pF5R" +
                        "vuJ1p3+fMY5M9ur/KMX7Wf2d2bts3lXGlb7rcbP7GFm7av3zMz6mXlm1lb3OpplxRmJXlujPUXrouezs" +
                        "86uf9Vf9UxU4yOb2ddDJv9jzJ/+XbKvshXiV3+dN/il85gL9tnL9qu95CdAwCWZ33wGKp8ZO5wq/WRid" +
                        "/SsBgECOYHMa/Yek8so6hMETj8Xlf5exV6xV5Xer+jvnWuy9e+Hdz6/en9PgcKfHYUSIECAAAECBAgQI" +
                        "ECAAAECBAgQIECAAAECBAgQIECAAAECawRGLrl3drK7/qqLerN5T7y0N9LT7AXP6GyN9HTPObP2WV8rc" +
                        "kYGO57PnudMj9FZuT2v/Mzsxcza6tmozvU9/8je7Jwvu2czPV21trrXGYuZWX7KH72uop66+7nVm+0py" +
                        "hHN9Or5p7yeKgYu2Ve0RmJXf5038aL6z8Fe3VMm/7O+M2vFECAwJ1B535irZPVpAqfufaWvKPY0c/0Q+" +
                        "K0C0Wv18flvNfqtc598Niq9vYrdvbfVvnf39+71Kr7vPuuz/hl86s6a61SBkb8/WkOAAAECBAgQIECAA" +
                        "AECBAgQIECAAAECBAgQIECAAAECBAi0Cuy+5P69+Svqj1yqe4XekW/nxcbsARrtqeNC5U89zjqPzjOy9" +
                        "1njU+NmrbNzdZ6Vmf2dWTtyPmYu2o/szYr5ZnPOrL9q7bO9XtHPyBmJXk+ZnCPna/Q1cK/V8X6RzZH9H" +
                        "eSV1cx+rzhD1dldsq+KVeNXfmH3q5fMC/1fMSv7Gcn9fYaRHNYQIFATqLx31DKLPl3g9L2v9Pcs9vQ90" +
                        "B+B3yJQeT3/FhNz/i1w8tmo9BbF7tzvqJfH5zv7+pRafM9+3X7KOTMHgUeB6t8exRMgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAAQLtAqXvun1Vz1zSqzR5Rf2oZrb/KE/F6sRLe6M9dbrc9iLKN7tf2" +
                        "fU/xY0azdTcsbb7ou2rnk/Y31X7GM3W8R6Ruai8Yr7ZnDPrr1r77BzP9BO9x2Vf75mzljlvna/9rp7uB" +
                        "pl8XV4j71nZ2ld/lrhkP7NTmbUrvyac+KXo6Av2d5vHOVZ6yU2AwPmX2+zRWoHK58baTl5nr/T5U+yVv" +
                        "atNgIDPGmeg7z1+t+Xs589V/66p9L3b9BPq8XXJ/hPOsRneSyDz90YxBAgQIECAAAECBAgQIECAAAECB" +
                        "AgQIECAAAECBAgQIECAwFKBzKW1x5gVzVzRQ6bmq1ln13/PPXtJ86deZ3POrM/4RBc+O3I8uszM8+wsd" +
                        "OTsyNH9uuy8aBv1ltnnKMft+YzjzNqot8x8r14Ls+tnbVad/Rnzq9butsh89mbPxz0uOq+vzksmR7Wf6" +
                        "HMg+1n5vW51r7LrT309Zfb1HvNn1r/++uvt/vPwPl+Zd3/syq/xvviw+/HFt7KXjty3efwQILBeoPLes" +
                        "b4bFXYKvNPeV3r9KXanq1oECPxXoPIa5ve7BE49G5m+bjuVidv975psT7v7+pSTzTd/7p2xTzn15rhaY" +
                        "P9fL1UkQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIEfhBIf19skd5V9St1q7FVqplLo89qz" +
                        "eZctb5q2XXhe3aen5w7cnbkqJ63KL7LPKpzf545E1GuGceZtVFft+eZ+WZioh5WzDebc2b9VWtXvdfuO" +
                        "COZC/KV1+PMea1caK+873b19I6vp6jnx+cu2Ve0RmJXfjG3+oGyshe5CRB4H4HKe8f7TKXTjMA77n2l5" +
                        "++xGRMxBAisEai8dtd0IOvJAieej0xPd9NK7Op9yPTyGLO6n0/MXzH+xPkr/+USNys/BAjMC4z8/dEaA" +
                        "gQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAoF2gcjGtvfhXwivrV2pnY0eMZi6NPqs3m3N2/" +
                        "a2vrNlIXNW5Y57vNTtyduSoWkTxuy/ZZ87KaM/Rule1M2uzMSNnPLMmU3/FGZvNObP+qrWr3mvveTP7n" +
                        "YnpONOZOpWY6DWeOcePMZXaldhMHzPnb/UZSvfvf8k+QzUYM//V2p8zVH+pWtWHvAQIvJ9A5f3j/abT8" +
                        "SuBd937St+PsU4DAQLXCVRet9d1qfJVAieej0xPlUv2t3w7fjJ932N29POJNRj7X7L/xHNtprMFBv8Ea" +
                        "RkBAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECDQK5C9gNZb9d/ZruwhWzsTN2p04qW9rp4yb" +
                        "tWYEeeueR5rd+TsyDHi8WrNFZfsb/1E52Ck54zNrj2I5qs+z8z2yjW7/qe4WbOZ9VetfeY108/3nNUz8" +
                        "D3+nm+2p9k+HtdHPd1iR346e6z0MGu74vVU8fvTv0v2FbJi7Kqv7SY+JP91OFf18Wl5uX7ajvbPUz0j3" +
                        "+P7O6pnrMxQz75uRaXvW6yf/wpUDE/zq/T+GHvaHDv7qZrt7O2KWlmPK3qbqZmda/frotLXzPxXr63M6" +
                        "bPpn92quO3a40xPLtnP7UbGePd7VWaiSt+ZfD/FZGuM5p9dl+3vtPe5St+n9T67Z+94zlbM/K45i396F" +
                        "E6AAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAisEcheVFtT/e+sV/eQrb/q8vGJl/Y6e+rwv" +
                        "ecYPYed89x76MjZkWPU5Nm6Vec86jNzTqo9RzVfvf9k1lZjMjNmYip1V5yx2Zwz669au+Ls/ZQzs/8/x" +
                        "TzmmjGK3t8q/X2fr6OvzJyVHisX7Fe9X3S7vHp/cMm+8u45ErvqC72FX5b/bLKfnwWqjlE8588RiPa68" +
                        "/lutUrvu3t7rFfpMxN75Syn1M443WNO6Xn2TJw4x6qeKvubiV3V5868mTlfxezsNVtrdqZn67P1s3GVP" +
                        "rM5T4irzJWJPWGmK3rI2Oz8PMr0M/J5tMM20/tOyxGn7Aw7PGcuJlf/3Z2de9f79ivfSq9X7dOtbqXPT" +
                        "OyVs3TVzsz5br8LddmcnOdrT/wQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECZwhkvpOys" +
                        "tOr699ny/TxPabDZcUFu9mcs+t/chnxnb1cH+3tzP51GHXkmJmhuk/dtb7ny5yRSs+Zfq/Yg8yc0UXqz" +
                        "Gy3mBXzzeacWX/V2mfeM/1Uc2ZrZeMyZ2jkrL7K29lb9P4e9Z6ZP/seNZIr6n8m58uz5X/JfgXt/+Zc9" +
                        "aXdF2/mPx70VX28a96q30j8SpuRfq5eU/Go9FrJ23VxpNJfJbZrlijPiT3de670NhMbGX3q84rZiQaV/" +
                        "h9jZ2ep1J2tVV1f6W0mttpXNb7SWyZ3JV8mNlNzZUymx86Y7CydNTtzZfvPxnX29ipXtp9Piau4rp450" +
                        "8v3HkbWdM+R6aHz8zDbf7WvkfhsLx1xlf4y9Sr5MrGZmrMxmT7uMbO1qusrvc3EVvuqxld6y+Su5MvEZ" +
                        "mqK6RP42hM/BAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAIETBaKLedX/5dsTZ7y6J8b/3" +
                        "YFHk6v3R/19AtFrYV8nKp0o8Op87Oz3Xc7pu/S5c+8ea/3xccl+IX/fV2z/nem2cZX/rOrj3fJWzDpiV" +
                        "/l09LY7R8Wi0lsl70+xlVq7YmdnitZX5ohydT2v9NQV29X7O+Wp2J06V2WGe+zsLJWas7Wy6ys9dcVme" +
                        "xuJq/T4Kn8lz0jsyGwza0Z67F5zpffoLDPmj2tH68+s6+r9HfJUnFbPk+nlew+ZNbeYlT/ZHlb3cZ+x0" +
                        "k9H7Erb0feCK98zV3pU9mtlH6P7Uun/VezK2So9fuo5W+n7brm/zoMfAgQIECBAgAABAgQIECBAgAABA" +
                        "gQIECBAgAABAgQIECBAgAABAgT+FnDJ3kkgQIAAgZUCLtmv1P3zSb7o59svCeGF+0VtvE3aqld3fDdUd" +
                        "3878lUMKv1U8v4UW6m1O3Z2tmfrK3Os6uHqCzKPBjtmPKXGaXs/6lKZ4x47Wuu2rlJvpk52baWfFbHZP" +
                        "itxlT473tsq9b7HVuaaiZ3pccXad/oMnXG/r11hWMnZMcPpOU7yyPTy3TOzZuE/B/+0k+3hpD4qPWdjV" +
                        "5/1bB+vnCs5ZmJXWVR6WtXDp//7ocO4kmMmdsce//YaX/vjhwABAgQIECBAgAABAgQIECBAgAABAgQIE" +
                        "CBAgAABAgQIECBAgACBvwVcsncSCBAgQGClgEv2K3X/fJIv+vn2S0J4wWJRG2+Rtmq1Kr4Ta1WPK/NW5" +
                        "q/0Ucn7ThcE7waz883OvKL+KRcYH8/ZyjlPyr3ztbVy7socHa+lSr3T5q70XontnnOmdmVtV2z3/KOXd" +
                        "7vmyeSZ/TzJ1OiKmdmfrh468szM8Q5rK0Yr58n0MXP+r+6943Pw1QwZvx0xpzrvmP17jRUWlTlW1P8N/" +
                        "36YMa6s7Ypduc9y//kvUfFDgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgMDfAi7ZO" +
                        "wkECBAgsFLAJfuVun8+yRf9fPslwSX7H5yrRrviO47Erl4761TmrtSt5J25IFXpqTt2dsaZy5vdtU+8I" +
                        "HPfr1WznpS3cjZP6rvjtTszzwlulR52xc6Ydr0v7Zr1pzqd85/83vjqPfJK/1e1R/fmxHlGZ3mXdRXzV" +
                        "TNlenhWe2bt7DyZ2it/x6nU3xk76zr7O8fj+p1zf6/V7VCZpbv2yZ+RnbOOGlfWdcd2zi/XvwW+9soPA" +
                        "QIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQL/vmDvf7zCiSBAgACBFQIu2a9Qfcy56" +
                        "ovCXzXCi/XfY1b1cmLeEZ+da2bNdvbaVasyc6VmJe/spZlKX92xs3OOXvjprHvyBZn7fq2Y96SclXN5U" +
                        "t9dr93Rma52q9TfHTtq+n1dpe+T3ku65r/lqRhcEdv1OtzR+8i+7OhrtMbIPO+ypmKyaqZMD89qZ9beY" +
                        "lb8ZGuvqF+pfUVst3dlBp9R15/3yn51xHadt0ovn3rOuiw/Ic/XefBDgAABAgQIECBAgAABAgQIECBAg" +
                        "AABAgQIECBAgAABAgQIECBAgID/FXtngAABAgTWC7hkv9p41Zd7v/ouX8Za1ctpeUdsrlgz43ZFv7M1K" +
                        "/NWalXyvtMFwZ8MZmcduYzRVXOkduUcdMZ2z3xSvorTSX3PXm68zz0605VuldpXxY66Pq67qvfZuh2zv" +
                        "8v74zt9hlb3ZfYc7Fhfneld4it2q2bK9DD7ObSi90zfs59/7/S6/+7RaV6xPin2KoPOurdcJ5k+66Vj5" +
                        "neYc+W/UTsMPynH6r9Vyk+AAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIEDgTQQev0P2J" +
                        "i1rkwABAgTeTMAl+9UbtvJLvl+9l79wvrKfU3KPuDyuyc4xW+e2fvSno/buHJVZK71V8nZeFKrWrcz0L" +
                        "LZac/ZC2MwZ7bS+e2TnP8k62/OuuIrNrp5m6lTmmTnPlToz83xfW6n7U2y2l9k6M7b3Hjt6uCpH1vlV3" +
                        "Gzv2R5m6qx4X5/p59XarEfH5c1srY5Zs7XeKa7ismKuTP2O1+5VvVd/h8r0mTHreH3O1un4bPIZ9c+Jq" +
                        "OxH5hxlYyp1/S5U//vQrO+K95js2fj0uC9bPwQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAg" +
                        "AABAgR+u4AL9r/9BJifAAECewRcsl/tvPKLv1+9u2T/DXjE5LZm9md33dF6V62r+lb6rOYevcQ6W+dxf" +
                        "WW+77EdfVTqd9SbucQ4W78y62PsbN1T11c8Tp1h9rU0MtcVbpWanWf33epm+s3seSbPs5hM/o5Luid+H" +
                        "sy4rVyb3ZPRHrL5n8VdVXe271XrKx7dPWRqRzU7ckQ1fnqeqdvx75zZz92OHrKzrnifnPk9NtN3Zu8ze" +
                        "VZ9Rt37q/SQmSkTU6npd6HXfxta6d3xGs/099tivlz9ECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIE" +
                        "CBAgAABAgQIEPjNAt/vy/1mC7MTIECAwFoBl+zX+jbc3n7xTeKv3suX7G9rPvXnao+r6+/c1+qs1d4q+" +
                        "au5v8e/qjWbO1pfmfMeG+XMPK/UzeSLYir1HmOjvJXnIz1U8r9LbMXhE2ca/Qzc7Vap9ymvmdGZn60bP" +
                        "b+jfYzWG7m8OVPr1dpo9mrdKN+qs5vts9Lfql5HesjO905xFYfuuTK1o5qZHKOfP89qZ2t21q3UXPGau" +
                        "bL+aO1P+Iy6n8GKQfSayTyv1Ftx3kY+n2dfb6Mzf9I5y5yN3xLzta9+CBAgQIAAAQIECBAgQIAAAQIEC" +
                        "BAgQIAAAQIECBAgQIAAAQIECPx2gfudud/uYH4CBAgQWCvgkv1a37U32r96H7pkf1v3aT8jFqsMTuplx" +
                        "YzV+UZ6qNQYyf+45nut2XzV9ZVZ77HVGt/jKzVna41cUOmo+VOOytxd1qtmGc1bMRitsXtdZabRz79Kj" +
                        "Y75K/VGZ8r0We1jppeRWj+tycwVxYz0EuXsuCg741vp79n8lRzV9/5q7o746j531PTZ9LNiZS+69yFTO" +
                        "6qZydH9+s3W7Kpbqbf6d6grehmp+QmfUa/+zfTKJHrNZJ5XzTM5R2Kqfcy85kZqfdo5G9mjT13ztbd+C" +
                        "BAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIE1gu4ZL/aePUXfr/6H75of" +
                        "1v7KT9Vh9Vzn9ZP17y75qrUmZ3tXms2z8z6yrwdr9tKvZm5qpcsO2aL+q3MvqOfqN/u55X5u2uvyleZa" +
                        "XRPKzVm56zUGp2n0uOufqp1foqvzBXFjvQT5Zy9YD2Sf2bNd4NqrophNfdsfKW3T3qdzbqtWl/Zj84eM" +
                        "nUz9TJ5us9RtmZX3Uq9rpqv7Hf3U633KZ9Rj3tQMci8bk7a36jfyuwz579a5xPPWbQXv+n51/76IUCAA" +
                        "AECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQWC/gkv1q49VfAv7qf+qS/W39u" +
                        "/9UDXbNe2pfM/PvmqlSZ2aek9bunPlTa2X3szL/J7xHXnVBKrsfs3E79rNSY+c8s7Wy6yvzj75mqjUe4" +
                        "7NzVOOqPVXz3+IrNUbyz66ZcT55thN7q/Q0+jqbPQ8r11fm7+ojUzNbqzNXpmamXtc5yda6x2X674jZ2" +
                        "Ve11sx7Z9am2lM277O4Sr13qpXttTL/6GuvWuMTz1l2P35D3Nf++iFAgAABAgQIECBAgAABAgQIECBAg" +
                        "AABAgQIECBAgAABAgQIECBAgAABAgQIEFgv4JL9auMdX/79mqF0SetV/I5+u2tU5u+uHeU7ubeo9+/PK" +
                        "7PcYmd+KrVm6py0dufMu2rtqlPdx0pfs2e52tvq+Mrsq3vpyl+ZaXQ/KzVm5tpVp9pjpa8dxo/9VGepx" +
                        "K+eu5K/0veK2JF9PXW+T+hrZD9WnIvOnFfsS6ZmdsbOXFHNTK17TJQr83x3vUxP95hdvVXqfMpn1My/B" +
                        "St7eFWdao/VM1DNf4uv1uh8nT/rt9rTyNzW/CzwZe+HAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAA" +
                        "AECBAgQIECAAAECBAgQIEBgvYBL9quNd31h+GuO4S9lP1u7q/eZOtW5Z2qNrD29v+xMu+eo1MvOcHpcZ" +
                        "eZb7MxPpdZonR01RnurXmKZqXPa2tP3ZdSrMtfI66eSf8cMozVm1q02qOS/x87Mk11b6Sub8x63Mne1l" +
                        "xXxJ853Yk+P9qf3t+KcXPl6yHhnZ87kGvn8+al+tlZHvUqtjnpZ75FzM9Nf1WGmVsWg0lcl71Xnbuc8I" +
                        "x6r+6vk/5TfhUb24bes+dpjPwQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAg" +
                        "AABAusFXLJfbbzrC8Bfc7Rfsv+ec9cslTqVuSt5O2Pfocdo3soMt9jZn0q92Vonrd819446O2rM7F2lv" +
                        "44zPdNr59rK3J11V+eqzDWyn5X8o7PuqDHa221dpb9TjUfmr8xdzb8yd7WXFfEnzndiT4/2lf5GXmcr9" +
                        "rkrZ2X2jpqZepU6mXxde5at1VFvZ62K9+jr5uQaI73t3J8dtXbUGHG+r6n0N/L6q+SfmaO69tS+qnO8W" +
                        "/yXux8CBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAIH1Ai7Zrzbe+UXer" +
                        "1nKl+Bm1+yc73utau9X9foufT7zuaL/Ss2r9nVF3V1z76iTrbHCMZsz2+Mt7lN+PnXmylwj+1nJP3pWs" +
                        "jVG83esy/Z4qvGIQWXm6tyV3CO9X73mxPmyPV1pl+2xet6unClbe+fsmVrZvisXcKs5f4rP9N5xPrJ17" +
                        "nEds43k2NFnpcbIDKNrKn3NnolKrdXzjObvWLfSYWXumdkrfc2es5k+P23tl6UfAgQIECBAgAABAgQIE" +
                        "CBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgACB9QIu2a823v1F3695tl+0v9c8edbdvX2vV9mXq" +
                        "3t9rF/p+xbb9VOp21XzhDy75l5dZ3X+rr16lz675r3l+dSZK3ONvFdV8o/s1+r8Iz3NXOw80XjUoLI31" +
                        "bkruUf7v3LdafOd1s+zvXmXPlecrZ2zZ2pVZ1yR88p/U2TmuerfgbtdTrWo9FX9jGL88ztAxXzFe8gVr" +
                        "7nKzLPnrGr2yfFfln4IECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgTWC" +
                        "7hkv9r4ii/9fs1Uuki5Kn717JW+V/cS5X+nXu+zVHq+xXb+VGp31r061665V9fJ5v8t3lfP+Vg/uzfdr" +
                        "+nVBpW5Rmar5B+ZNZt/JHfnmmyfJxrPOKyae1XemVk71542X7afToORXNk+R15nI/3sXLNz9kyt6uyZn" +
                        "LP7lq0xW+c2+85aVWsXwP8R2LVPq+tk88+eldn12T5HXoMrc58892xvn7r+6zz4IUCAAAECBAgQIECAA" +
                        "AECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQWC/gkv1q46u+8Ps1V+lixMr4FQbVflf0UMn5b" +
                        "v1WL9bc5uv8qXh11r061665V9fJ5v8t3lfP+Vg/uzfdr+nVBpW5Rmar5B+ZNZt/JHfnmmyfJxrPOKyau" +
                        "5J3xHRm5o61lfk66kU5sv1EeVY/z/b5jmciY5edP5PrVUxUZyR/lPP+fCT3fU22xuz5qNSZrTXjMeIy0" +
                        "m/Fo2OeSo5dva2uk81fsVkRm+3TOVuh/7tyfp0hPwQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIE" +
                        "CBAgAABAgQIECBAgAABAusFXLJfbXz114C/5jvmsv2tl66fylxdNWfzvFPPlV4793Xkoszsvpy0vuI+0" +
                        "/fKOitzz8z8bO279Ttr8KnzVuYaec+q5K/u0crc1V4y8av6XZU3M1MUs6q3St6RcxvNtfp5Zb7f1Etm1" +
                        "pPsMv12xuyYPVNjdKaVuW89ZfJ3vF9k63TUGrX+vm5lzytzz86/q7eVdVbmnvX9af2qflfl7TA4ubeO+" +
                        "U7M8WXuhwABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAYL2AS/arjU/4s" +
                        "u7XjOkLGTtiO0wqfXbU68jxLj1X+rzFrvip9LCi/lU5d829sk4291XGOy9knTLjYx/Z/Vn12l5lUplrZ" +
                        "LZK/uqM2dzVvKvis/1WnVfl7XBY1Vsl7z22Y55dOSrzre4p28vqPrL5s/1WX2fZ+lfG7Zg9U2PU4OrcX" +
                        "e8VmTm6ao1a7/yd7mSPXb2trJPN3XVWZvNk+62+R6/KOzvvbf3JvXXMd2KOL3M/BAgQIECAAAECBAgQI" +
                        "ECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAEC6wVcsl9tfNKXdb9mLX05enX8jE2lt5k6nWvfp" +
                        "edKn7fYFT+VHlbUX5mzMtur2JkeKz1U62RzV/Ouis/2u+qsr5rrWd5Pnbcy18heVvJX9zSbu5p3VXy23" +
                        "6rzqrwdDit7q+S+x3bMtCNHZbbV/WR7Wd1HNn+23+rrLFv/yrgds2dqjBpkco/uWzb3aP7HmXfWGrX+v" +
                        "m5lzytzz86/q7eVdbK5Z6261mf7rb4WV+XtmPvk3jrmOzHHl7kfAgQIECBAgAABAgQIECBAgAABAgQIE" +
                        "CBAgAABAgQIECBAgAABAgQIECBAgACB9QIu2a82PvHLureevuY+4j+jPpX+R2t0r3uHnis93mJX/VT6W" +
                        "NXDSN5K37OxI/3d11RqV+tkc1fzrorP9rvyvK+a7ae8nzpvZa6Rvazkr+5nNnc176r4bL9V51V5OxxW9" +
                        "lbJ/RjbMdfqHJXZTulldR/Z/CfZZXvujMvOP1ozyj+at/JvrJEaUd+d7xE7a41Y7P4d52SPXb2trJPN3" +
                        "XVWZvNk+/W70Kz0717/dX78ECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABA" +
                        "gQIrBdwyX618Tt8LfjL4NIL91WjSr/V3KvjT+690tstduVPpZeVfTzLXelvVezM3JWeqnWyuat5V8Vn+" +
                        "1195lfN9z3vp85bmWtkLyv5q3uZzV3Nuyo+22/VeVXeDoeVvVVyP4vtmHFFjspsK+o/5sz2srqPbP5sv" +
                        "9XXWbb+1XEr58/knp1/VY1M3o4zka3TUWvWetfvOSeb7OptZZ1s7u7zMpov22/1NbIq7+icI5+j1Zk7e" +
                        "vvUHF+WfggQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBNYLuGS/2vgdv" +
                        "/D7ZbL90n3FqdJfJe+O2FN7r/R1j13pVelnZR+jFwsq/Y/GzsxdqVmpU8n7jrEVi1NjK+6nzvBTX5W5b" +
                        "rHVn0r+Su5K3neMXWVRydsRW7EfqVfJH8WO1F+1Jur18fmqHm55K328Y+xKu6tyV/ah2mMmdzXn9/gVN" +
                        "TI5u35H31lr1nrEfsTpZJNdva2qU8n7jrGVM16Zr5K3I/bk3jrmOzHHl7kfAgQIECBAgAABAgQIECBAg" +
                        "AABAgQIECBAgAABAgQIECBAgAABAgQIECBAgACB9QIu2a82PvHLutWevoy2XFDK9lXpJ5tzV9ypvVf6u" +
                        "sWu/qn0s7KXSh+7Y2fmrvRaqVPJ+46xFYtTYyvup87wU1+VuUbewyr5K26VvO8Yu8qikrcjtmI/Uq+Sv" +
                        "xo70k/XmkqvXTU73h8qfZ8Qu9LuqtwV12qPmdzVnN/jMzWqn0XZnNW8s6+ZWavu9aucVuXtmH9Xb6vqV" +
                        "PK+Y2xljyvzVfJ2xJ7cW8d8J+b4MvdDgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAg" +
                        "AABAgQIECCwXsAl+9XGJ35Zd7anL7Nll+4zvVXqZ/LtjDmx90pPt9gdP5WeVvRTqX9V7MzclZ4rdSp53" +
                        "zG2YnFqbMX91BlmLwSOvI+tcqvkfcfYyhmqzFfJ2xG7o7dKjdnYDpNMjkqfmXyjMZU+3jF21OX0ddm9q" +
                        "M4R5a3mm/lMqtSK+n58Xsk70//I5+lsb9H6VU6r8kbzZJ7v6m1VnUred4zN7OE9pjJfJW9H7Mm9dcx3Y" +
                        "o4vcz8ECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQLrBVyyX2184pd1O" +
                        "3v68mu9cJ/prVIzk29nzGm9V/q5xe76qfTV3VOl9pWxM3NX+q7UqeR9x9iKxamxFfdTZ5i9EDjyXrbKr" +
                        "ZL3HWMrZ6gyXyVvR+yu3ip1OmM7jGZfl6t6uOXttDox10q7K3NXrLN9ZnJmc0Vx3bUy+UY+305+7UbGO" +
                        "3vP+nftQWX2Xb2tqlPJ+46xJ+5lpad7bMV+JL81/xX4MvdDgAABAgQIECBAgAABAgQIECBAgAABAgQIE" +
                        "CBAgAABAgQIECBAgAABAgQIECCwXsAl+9XGv+nLwl+WLReZIrNKnSjX7uen9V7p5xa766fSV1dPlZonx" +
                        "M7MXem/UqeS9x1jKxanxlbcT53he1+VmUbfxyo1Km6VvO8Yu8qikrcjtmI/U69SZ0XsTO87L7tW+1xhd" +
                        "VLOqse7xFeMszNlcmZzRXGdtTK57jFRX5nnu+tlesrGrOp9Vd7sXK/idvW2qk4l7zvGVva4Ml8lb0fsy" +
                        "b11zHdiji9zPwQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAusFXLJfb" +
                        "Xzil3VX9/RlOnXZPuqvkj/Ktfv5Sb1XernF7vyp9NbRV6XeKbEzc1dmqNSp5H3H2IrFqbEV91Nn+N5XZ" +
                        "abR97JKjYpbJe87xq6yqOTtiK3Yz9ar1FoVOzvDfX2lv66aP+Wp9PGOsSvtrsxd2Ytsn5mc2VxRXKZW9" +
                        "jMpmyubr6v3rnpRP5Xnq6xW5a3M9ix2V2+r6lTyvmNsZY8r81XydsSe3FvHfCfm+DL3Q4AAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgsF7AJfvVxid+WXdXT1+2w5ftX/VYybtr1" +
                        "mydU3qv9HGL3f1T6W+2t0qtztjZi4Azc1fmqNSp5H3H2IrFqbEV91Nn+N5XZabR97NKjYpbJe87xq6yq" +
                        "OTtiK3Yd9S75ajUXBU7O0ulr9laXb83Vno+JXal3dW5s8bZPqN82TyZuKjW/XlnrtHPuJnP1Uz/O2Oy7" +
                        "lWrVXk7bHb1tqpOJe87xlb2uDJfJW9H7Mm9dcx3Yo4vcz8ECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAA" +
                        "QIECBAgQIAAAQIECBAgQIAAAQLrBVyyX2184pd1d/b05Tt0UazrstTOWTO1Kh6ZfKMxlT5usbt/Kv3N9" +
                        "FapU4kd7WlHjerlzcoslf7fMbZicWpsxf3UGWYuA46+n61yq+R9x9jKGarMV8nbEXtVb5W6q2Jn/Co9z" +
                        "dSJ1lb6eMfYaP53fl7Zj2jOTK4oR/V5V81MntHPt59mytbrrFm1fRa/qvdVeTvm3tXbqjqVvO8YW9njy" +
                        "nyVvB2xJ/fWMd+JOb7M/RAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQLvKzB0h+Zr3M517" +
                        "6uncwJ/Czx7PfAh8O4Czva776D+dwnsfK24ZL96V0/8su7unkZ+2X/VYyXf7lmjeif0XunhFnvFT6XH0" +
                        "f4qNV7Fjta/8lJTZfbKfKvyVnoQ+1rgE/eoMtPoe1qlRuUMrspb6eGU2JMtru6tUn9F7OgZqfQyWiOz7" +
                        "pQ+Mr2K+bdA595lcnX7d9TM5LjHdPV/Rc3Tez/ZZFdvq+qsytt1pnbmOdni5N527tHOWl/mfggQIECAA" +
                        "AECBAgQIECAAAECBAgQIECAAAECBAgQIECAAIH3Fei8LD+a6331dE7gb4GdlyuZE9gp4Gzv1FbrnQV2v" +
                        "lZcsl99UnZ+CffUWi9+uXn6C79L9msut1f34qozVelztMdKje+xozWjdZWeolxXvIZ29T8z+29f+2l7V" +
                        "JnnFjv6U6lTqbEqb6WHU2JPtjipt0ovnbEj56RSfyR/ds0pfWT7FfePQOfeZXJ122dqRp9N2RxRnspsV" +
                        "9Ss9Od33H8L7NqvVXVW5e06UzvznGxxcm8792hnrdV/q5SfAAECBAgQIECAAAECBAgQIECAAAECBAgQI" +
                        "ECAAAECBAgQWCowejG+c93SASUnsEFg5+XKDeMoQeD/BJxth4FATmDna8Ul+9yejEft/BLuybW+BMu/8" +
                        "D+bp5LrNJMre6/UvsVe+VPpdaTPSv7vsSP1smsqfWVz/hS3qs6qvDOzWnvNRaxd7pUzN/O+VqlTmX1V3" +
                        "koPp8SebPEpvVXm+Cm2elYq9aq5K/Gn9FHpWew/Atn9i8yiPNH6kedRzfvzV7mzOWY+477Xv6LmiK/fc" +
                        "f8W2LVfq+qsytt1pnbmOdni5N527tHOWl/mfggQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAA" +
                        "IH3FSh9r+drzBXx76uncwJ/C+y8XMmcwE4BZ3untlrvLLDzteKS/eqTsvNLuCfXGvnF/9k8lVynmVzZe" +
                        "6X2LfbKn0qvI31W8t9jR+pU11T6quZ+jF9VZ1XemVmt/bfAp+1RZZ6Z97VKncqZW5W30sMpsSdbnNzbz" +
                        "OXYylwjr59K/pXn8JQ+Vs74ybk79i+TY5XhbO3M+pHX56t5szW763bswareV+U9eeaZz5fKXCfbVuboi" +
                        "D3Z4uTeOuxPzPFl7ocAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBB4X4EVl+arOd9XT+cE/" +
                        "hbYebmSOYGdAs72Tm213llg52vFJfvVJ+XEL+te1dOLX3J+PPQu2fftVJd9X0evM1X6rfZUyX2PrdYYj" +
                        "a/0Nlrjtm5VnVV5Z2a19nMv2VfO2y125qdSq1JnVd5KD6fEnmxxcm+Z/av0H8Vm6t1jolyPzyt5q7Gn9" +
                        "FHtW/zfAh37l8mxynumdmbtit9Vr6rbsQerel+V9+SZv/e2ymBV3g7b3TlOtji5t937tKve6r9Vyk+AA" +
                        "AECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgsFSh99+2rkxXxSweUnMAGgZ2XKzeMowSB/xNwt" +
                        "h0GAjmBna8Vl+xzezIetesLuO9Qp/rL/7OZKnlOc7mi90rNW+wJP5Weq/1Wcu/2qPRWnfsxflWdVXlnZ" +
                        "rX23wKftEeVWWZfy5ValTO3Km+lh1NiT7Y4ubfq/lVm+Sm2Uq9Sq5K3GntKH9W+xf8t0LF/mRyrvDO1n" +
                        "31GZdfOfsbtuky9yvi3/46765ysqrMq747z1l3jZIuTe+veh1PyfZn7IUCAAAECBAgQIECAAAECBAgQI" +
                        "ECAAAECBAgQIECAAAECBN5X4NV33953Kp0T2Cuw83Ll3slU++0CzvZvPwHmzwrsfK24ZJ/dldG4U76ge" +
                        "0IfX4bbLso81jph9nsPFYOuvis1b7En/FR6rva7Mne1l6suNa00WJl71tf6nsuKJzhWztk9dqbvSr1qn" +
                        "ZW5q71cGX+yw8m9je5ZZabR36kqNUbnyK47qZdsz+L+Ecju3zOzaP1K66j2q8+o7Nru398rdbtrz+5Fp" +
                        "fdKrVV5Kz2Mnu/R9/Cd/0452bdjj7I5TnY4ubes77vFfZn7IUCAAAECBAgQIECAAAECBAgQIECAAAECB" +
                        "AgQIECAAAECBN5XwCX79907nZ8jsPNy5TlT6+Q3CDjbv2GXzdghsPO14pJ9x469yvFuX+Rd2e+XU8sl+" +
                        "1uPlVwrZ6rkvqLnSs1b7Ck/lb4rPVfyXuFR6a8yt0syM1qftXbXGVutVpmj47VcqVedfWXuai9Xxp/sc" +
                        "HJvs3tWme0em61ZyZ3NORp3Ui+jM/zmdTP7l1m72na0h8y6js+4n+bP1l5Vf2RPVva8MvfIrI9rdvW2s" +
                        "s7K3LO+O9ef7HBybzv3aGetL3M/BAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAwPsKuGT/v" +
                        "nun83MEdl6uPGdqnfwGAWf7N+yyGTsEdr5WXLLv2LFXOXZ+Cff0Wl9ObZfjK7lOcdndc6XeLfakn0rvl" +
                        "b5X5a308Cp2V38r66zM3eX8m/N8wv5UZrjHzu55pWa11src1V6ujD/Z4eTeOvasMl/l94VK3o45Tvh8X" +
                        "T3Hb80/c5Yya1e7jvSQWdP1GeeSfXwCrt6PE97fVhqszB3v7jkRJzuc3Ns5O9jbyeq/VcpPgAABAgQIE" +
                        "CBAgAABAgQIECBAgAABAgQIECBAgAABAgQILBVwyX4pr+S/RGDn5cpfQmrMQwSc7UM2QhvHC+x8rbhkv" +
                        "/o49H7N9r2zfVm7ZJ806NjpTu+Ofio5Kr2fkLfSg0sy/7wPdLnJkxdY9drKdzAXWen/HjtX8e/VlbrVe" +
                        "itzV3u5Mv5kh5N769izyny32OxPJW8252jcSb2MzvCb183sX2btattMD99fW9k1lddkZc6r61d6vceu7" +
                        "Hll7pFZH9fs6m1lnZW5Z313rj/Z4eTedu7Rzlqr/1YpPwECBAgQIECAAAECBAgQIECAAAECBAgQIECAA" +
                        "AECBAgQILBUwCX7pbyS/xKBnZcrfwmpMQ8RcLYP2QhtHC+w87Xikv3q47DzS7in1/qybruoWMl1isvOn" +
                        "iu1brGn/VT6r/S+Km+lh1exu/pbWaeS+8Sz17WXp+ap7M+JM1T6v8d2zFGpW61Xyf3Jr5mKQ9V4Nv7k3" +
                        "mZnW3k59SS3Si+f/DrrOi9X5Mnu4ffeonU7Zol6+OnzKrtm1Xm9uv7IvqzseWXukVl/8yX7VWd+dh861" +
                        "jtnHYqfk+PrPPghQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIE3lfAJfv33TudnyOw83LlO" +
                        "VPr5DcIONu/YZfN2CGw87Xikn3Hjr3K8Tlf8Z2f5Mvpkkv2t7pX/3TOHs2ys1bUy+jzygyVGqvyVnr49" +
                        "Ev2t/lOd+7ar3fM8857U+n9Htu1R5XaIzVX5x/pafeakw1O7q1rn1bMuCLnzLyn9TMzy29cO7J/mTW7L" +
                        "Ku9ZOJX/hsnW7/783Z0P1b3W8k/OsPoul29ra6zOv+o7851Jxuc3NvOPdpZ69XfGT0jQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAAQIEjhf4pEv2P80yuwHZ+wazdd59feR0wnwrz/rOy5UdltF+3Z931" +
                        "KrmiHqr5uuIP6mn3b2sPtu75xk5DyvfO0b6+Q1rrjYfqb/6tfK47y7Zr34VrPgS7lfPK9Iuz3nrO/ufT" +
                        "DPZXCd47eq1UucEl2f7XJkjc1buMavyVnpwyf6/7wNdfvLEAqe/BjreEx5njEVyEavdKvlPfu/Oaf4cV" +
                        "TGYqTOy9uTeRub5ac2KGVfknJm30s+nvs5m/K5eW9m/yu99u+bK9P/YSyZ+9TnN9rC6j8were51df7Mj" +
                        "B2/I51cp2J8wpmbsbx6L0d6r+zPSH5r/ivwZe6HAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECB" +
                        "AgQeF+BkYtku6eNLs9n7v5Ues7kW+W24pLeipw3z1Gnyl48i83OVO1xtLdsP5n8Uc+ZHD/FRHmj5911v" +
                        "+eL6n9/PtrPq7N7ZU+v5qnadP6XJHSe7fuM7zBPtceZ89i5dud+ZfvO9nS1+Wz97JxZt/A94a+//vqfd" +
                        "/vPw+8OHQ7rcqz4svB9+BW5V+Ws/rKX6aOSM5NvZcyuXit1brGn/lTmqMywKm+lh1exu/pbXaeS/+Rz2" +
                        "LWvJ+Wp7M0pfVd6fozt7L/Sw0jdSv5Pfc1UDEaMZ9ac3NvMXCMXeivn7zS3Sj+VObv2QJ5YILuH90yZ+" +
                        "LhqT0Sml/u5y8auPqen9JHZgdW9rs6fmfFZzK7eVtep5F999mf2Y2ZtxWCmzsjak3sbmecd1nyZ+yFAg" +
                        "AABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgTeV2DVZfFOkVeX7CuX4qKeKrkysVG9n56vuKTXn" +
                        "TMzeyZmxOe+JjNTpodMnkyfq/PMXJqecXj12su43GIyNjM9Zvt4jDuxp8r7QdVrxKjyWsvmr/ad2ads7" +
                        "co8M31W++mOv8rs1RyZnq42H61ffV/p2u8//b7bBftbvw+fCV0Wa/Ks+PLu9w/EFTW6c774EP/xRZOpv" +
                        "yJnpm41Zlefu+pU5x+Jr8xSyb8qb6WHV7G7+ttRp1LjFutnj0BlX/Z09LpKpd+Vn42VPkbdKjU+8TVTm" +
                        "X/UeHTdyb2NzvR93YoZV+ScnbfS0ye+zmb9rl6f3b97n1H8znmiXu7Pbz1lY1ef0Uofq3vp+v15tM+Kx" +
                        "c5ztfO87DCo1Bjdy937U6lXmb+StyP25N465jsxx5e5HwIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAA" +
                        "QIECBAgQOB9Bd75kn3lO2zRDlVyVWKjut+fZy4jXpmzMnsmtjrLPT5yytSOYiq9Rf1kcnX2EzlFtaLnm" +
                        "XmiHqLnUQ8zlzWj/arUjnJVrB5jO3qYMYr2pzrXu8zT0WfVpjN+xXmczRmtv9K8s3Y0Z/s+u2TfSfot1" +
                        "4ov636V+M8hWVGnK+dP/Ub/f9naUZ7H59mc3XE7eqzUuMWe/lOZpzLLqryVHrouCc3U3OFQqXH6mTy9v" +
                        "8pZqOxLJW93bKXPHZ+JlX5GLSo1Tj+TI/1V5h81Hl23qrcRp9EZonUrZlyRM5ojel7p6aT9+Wmu0/uL9" +
                        "mLkeXX/oviRHmbWRP3c9zQTt2v/s73s6ufZayHb5+j+ZfNf4bCrtx11KjWusK6cn5H+KvNXeumIPbm3j" +
                        "vlOzPFl7ocAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBB4XwGX7J//L213Xr7LnpAVl/S6c" +
                        "nZ4/JQja/MY92qmrj4rfc0aRz1XernHRjlnnlf62bFXtxqVnxN7ypzvmT2rGkXnqMP7tHlm+7mvr9h0x" +
                        "86+F/3Uz2zOHa+3Eceu/b6/tmadKjP8qeWSfYWsGLviy7q3TXv2nxX1ZnO+6venZ5V6K3NX+ngWu6u/X" +
                        "XU6TDI5KvNk8t1jKnlvsTt/dvZWqTVjUKmz2zsz12P/mfh3iKnsyVXzVHqc/QzJzljpKZtz9qLgp71md" +
                        "hmP7M+q3k56j8nOWPHL5rzHVXLPxJ7aV3amk85NtueuuOreRfFdfWXzRP3c39czcbs+A7K97H4d7/7dv" +
                        "uKQPQ9dcbt6O7HOrtdBZa9m3qN3GVfmGXmtjeS35r8CX+fBDwECBAgQIECAAAECBAgQIECAAAECBAgQI" +
                        "ECAAAECBAgQIPC+Au96yb56Oe7ZDlXzjMRXTseKS3odOUfmrqypGN1iK7lnYrN9zRhH/WV7eIyLcnY8z" +
                        "/a144Jt9QL5iT3dPTv2pvN9feZs73itZs/hLt+rL9rP7tdPnrM5V5/pUfNT+8qcaZfsM0ozMSu+LBz98" +
                        "rKi5mjOqNefnldrVWtU88/EV3obrVOpcYt9h5/KTNV5Vuau9jJyaeHe/2it27pdBpU6HXPNmHxf+733z" +
                        "txX5qrsye4+K709i13Vc6W3mR4qdT7tNVOZfcZ4ZO2q3k55n1k1387Pm8q+Vub9tNdZxenU2JH92/2Z8" +
                        "cyus/edv9NX+955diq9zfS1q85Ij7t6O7HOp71H7zI++ZyN9Papa77Ogx8CBAgQIECAAAECBAgQIECAA" +
                        "AECBAgQIECAAAECBAgQIEDgfQU6L2OuUsjeKfheP7p4l8kbzdSR47HG7GXGn/qdzdkxY0eOjNNPdZ7tY" +
                        "WdPo8ZRD9H5q+z3Y60ob9RX5VJ7Jlemt0yeaK7780yu3T3desv0Fc3YkSPzWov6eLd5rnrvyDhWYkbfi" +
                        "17VmM2ZOZM7Pq8z57rrdZ/JU9nXH3+/8b9kP0MYrF3xhd/km/yK0qWc2T4f40oF/je4WmekxsiaHX3tq" +
                        "DEy++yaylzVWpXct9iVP9VeZl8r91kqdWfnr9S6x87WnFn/rN+ZnCetrezHrr4rPb2KXdlvpcfZPiq1P" +
                        "uk1U5l71ri6flVvp7zfrJrv5rwyd3UfH+MrfX3S62zG7JS1I3v305or5unqffeZrPa9y3ZnX5Vau+bf/" +
                        "Xv9ToNKrd2vh5/2t+vzvDL3p56z3XOdXO/rPPghQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAA" +
                        "QIE3lfgUy7Zj+xA5+zR91Cz/c1eZvypzmzOd3L63mvGvWO+EeOuM/N9xo557jk7eoxyVC+jRvlm97z7D" +
                        "HX9FxJk5nqM6XC65Rs525nzc9o83ftena8rfma/nvUwmzM6i9EF++y5zhpG/XTlqcyVrfmv15ZL9lW2Q" +
                        "vyKL+2+eEP98VCu6CHKWe3xHh/lffa8Wm+0Tnbdjn6qNW7x7/JTma06UyX3SrNqH9/jq3OPXi6cqVO9Y" +
                        "Nk5Y7XvaD+q+U6Nj+Z8fL5yhkof2dhT+p3tIzvvT3GztSvroz4ruarvFdXcs/HRrKOvmyjvbN+Z9VEPs" +
                        "+/Lq/NnZvwpptrX6B6P9ndfF/U5m/8d10cm2edXzJ7tLRO3u/9MTztfJ7v7qdQ7eW9mettpUKk1+zm10" +
                        "qSauzJ3Nfds/Mm9zc526vovcz8ECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIDA+wpEl81WP" +
                        "K9qRT1U893jOy8j33J25Ju9zPiTxUzOjpm+99SRs/tMzPZUNe7u/9F4dpbu/YpmrVxC73rtvltPV77HV" +
                        "c921x5V3ssqZyja+6p19+utWj/7ep3JO3oGMmehsneZfJk5O/csOk8j86VncMk+QzUYs+ILu8Evik8P0" +
                        "4pevucc7e22buZnpO5MvVdrd/VSrbNq3hV5K7NV61dy32OrNbrPx089z/RUMZipk70k+Kqfjvod+7G6j" +
                        "13532nvd/facU5mP8t+82vmpP2e+d2m8lrOzlzJWYnN1p/5LKzW6HoNZRxGepuxyPRUfQ+o5PyU2Jl9e" +
                        "1x7lce79j/S9yrjK3qp1Fw197O8u3rbVaf6Ptj976TM/mUtMrkeY7J5d35WjuxHdW7xPwt87bMfAgQIE" +
                        "CBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBA4H0FMhfEumOqWp0X4u61V+S85V51GbFq9hg/09PM2" +
                        "lc9z+aNzmTVa/Y8VObp7j2z17MXPSvzfbeP5h3tbWbP3qmn6lnO+mfzju796Lqor9m80d5H9bO+o+e6W" +
                        "j/bz0zeTzKfed94Zth9pjJ79aemS/YZqsGYFV8YfvFLYnSI/u95d1+zPXX0M9pDR+1bjp31q7W6ZtyVp" +
                        "zLfSE+V/I+xI7VGLiZk+tvVy0yd0UsjP83f1cfoa7Wz/pW5MmfrnWJ2WVZMunqq1PyE10xl3i7jbJ5Vv" +
                        "VXy3mOzPb+KG6l7WzP6M1JvtlZ2/UhvXb8XfO9xpJfsnJ8WN2L1fc1VJh29z7weZ+Ye7X2mZsfvkh31K" +
                        "7N31Kvk2NXbrjode975mTnzb7nKPlb/jVLNPRt/xf7P9vzu67/M/RAgQIAAAQIECBAgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQLvKzB8t+Rr5NG1Va2dl+KqvX2PX3UZcaav0Z5G12V7ncl/2pnIzhK9ZrJ2z+Kyf" +
                        "VTrzORdNfPMGTitpxnfzF7O5B9ZO7ImM8c9Zib/zLnZ/bqrmHTYrJrvJPOdvdxrjexjtMYl+0ho9vmKL" +
                        "/ZO/OL88kOr0mt3D5XaKy6O3eaZ+Rn1GKk5WuuEddl5K71mc3Ze2Miel8oc1diRuUcuiczU6bhA+Myl0" +
                        "lfV9qf4Sr2TYzssTsmx07kyc2dflbpRbKWvKFfmeaXeb71YlnF8FZM1nq2T/cx71s9M/cyMs+/ZM/19X" +
                        "5vpd+SzuOOzsNLb6bGze3blfLO9z74eZ2ef6X+m9mjdmZqj/3boqpnNU7HJ5vwpbled3/zvh6uMM+fi5" +
                        "N4y/b9jzJe5HwIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQOB9BaLLpiueV7VWXIp77OExf" +
                        "7W37/Ezlz9vuWbX/9T/aM7RdVnDmfwrzsSKfp6ds59qZd2ycaec6xV7dTcY3bPTehqdY+QsVM/FSG8ja" +
                        "7KzzL5Prtj71fPusnlWZ3a+k8xnZ6ka3eqt+HHJfoXqvz6xF3yb98UveSt+2V6es5OoyybTU0etTJ2VF" +
                        "w06ZqjkyM67IucnOd58Zn52+K64bFnpuzt2xvuktd0uV+XbbVqZs7u3Su2TYqsOld6ruWfjV/VWyXtl7" +
                        "E6/rjmrPXfV3Z2nOuenxM86X+kw2/vs74Czs3f0n52ho9bsvPf1lV66ambz7OptV53ZC/6VPlfHZvfQO" +
                        "atK/Y74r/PphwABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIEHhfgeV3cL5ovteoaq26FFftI" +
                        "xM/2+vs+p96HM25+yL4vd4O506nW67IOHqdZWa+Miaa71VvKy7Y3uuN9nVaT5/2Wvu0eaLX3ug5jPKOP" +
                        "F/Ry2zO2fWd79crenn1GeCS/V9//c9fD/95+LwcOd/71qz4+u+LXxaiXxKOe/6bfUZnf+f9z85cmTGb0" +
                        "yX7fwR2+L7al0r9U2JHz9lp607xHO3jKs9Kvyt6rNQ/JbbqUOm7mns2flVvlbxXxc7ajVwc7Jh1pO+Ou" +
                        "rtzjMz5CWtmna82+O39z86fXd+5z9mat7jdP7t621XnmV+l/imx1bNQ6buaezb+5N5mZzt1/b6/WqpEg" +
                        "AABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQILBC44t5OdYxVl+KqfWTiZ3udXf9TjyM5R9Zkf" +
                        "L7HjNYZXfeqx5mcr9ZGr7ERt91rVth0XD4dvSw/ui7jXs09Y5vp5x4zWqe6rhpfmeExdrTO6LpV7x2j8" +
                        "z9bd+J8p/S0oo/o9dXxPvf0c/3x8vq7/L+/hrnvQ/fZ78234gu7D8NHvxgc/XyFzVWXuap7MjN7tdZJ8" +
                        "dm5Kz1nc/4UV6mzOvbWX6XGrrln6rxaW5n1hNhVDrvznmA52sNuq8d6lZ5X9Vnp4YTYqkOl52ru2fhVv" +
                        "VXyXhE76/Z9/c4ZRnvf2WNHrdE5P2HdjN/V88/0flt7ws/sDKvXdxtV+u2uHeXb1duuOr/53w8nGD/zP" +
                        "7m36DXyrs+/zP0QIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAEC7ytQvRB6xaQrL8Z1zRPdr" +
                        "8jWWTHrSM5ontXPI6+RmVbmnPGI+rryeTRXprcVe/VYdyT/yJrMrPeYSv7IePXzaK7KLLdcq/uN8nfPE" +
                        "+V7NXNmbXdMdb8y9Wdzzq7/qceRnCNrMj4jr/tK3qfzv8vFev9L9v/77eAD3iCjN9Dw+Y4vOp/qNDv7q" +
                        "XNl+srOnsl1j8nm7LgwUOkrG3vFRd5sb7e4lT+VPq6OXemwM/fVjiP1d/p0vE+s7HfE76o1VYdKn9Xcs" +
                        "/Greqvk3R07a9bxWpqZeab/mbq7187M+e5rR61PmHu099W/l1VtZuZYubY6Rya+0m8mX2fMrt521YlsK" +
                        "n1cHRvN8v15pd9q7tn4k3ubne3U9V/mfggQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAIH3F" +
                        "XDJfmzvwntIX2kfY7JVVlwCHMlZna87PvIamWllztn5o952Pa/OkelrxV491h3JP7ImM+s9ppK/at4dH" +
                        "81VmeWWq7u/ar7ueaJ8r2bOrO2Oqe5Xpv5sztn1P/U4knNkTcZn5HVfyft0fpfsZxlfrF/9hd0D3ixLb" +
                        "66rPX7Kf4pR1+ynzDPSR9agkjub81VcpV5n7FUXKyozdPhGOSr97I6Nen+357v9ZuqdZFuZY0fflX52x" +
                        "47OX+lztMboutW9VfLviB11yq57lxl29DlaI2v9yXHvbDfa+23diT8z83SuXWlT6XNlH7P/1p3p7TSDS" +
                        "j+7Y0edK32O1hhdd3JvozOdvu7L3A8BAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECDwvgIu2" +
                        "T/fu9L9o680HZYrLgGO5OycfSRX9IoamWllzpEZR/5LGKIZMs9ne632vWKvHuccyT+yJmN7j6nk79yPk" +
                        "VzRXJVZbrlGeuhc0z1PlO/VzJm13THV/crUn805u/6nHkdyjqzJ+Iy87it5n87vkv0s44v1u764e8CbZ" +
                        "vgGvMti9vLBCsvO2Vf0tytn1qHSTzZnFFep2RE7e06jeV49r/Q/U6e6ttLXythq3+8Uv9KtI/eplpXZd" +
                        "s5Q6WtlbMfMlf466lVy7OqtUmdFbMVkNnZF/485Z/t7XL+612z+zpk+IVfW7XvcKbO/e//fHUfn6Vq3e" +
                        "l8rfa7uZcZ+prdTDSp9rYydsb2vrfTXUa+S4+TeKnO8U+yXuR8CBAgQIECAAAECBAgQIECAAAECBAgQI" +
                        "ECAAAECBAgQIEDgfQU6Loavnn71xbh7/+E9o6/A0Zis0YpZR3KOztm1LvIamWllzo65o/5Gn3f0NuM9s" +
                        "zYz80j+kTWZXqL3kp9yrNyfTO5orqpVpubKmO55ony351WjTM7RmBW9zOacXV953bxyW9HHY73V+f9Ty" +
                        "yX70ZdJYt3uL/FO/IK57A11t0HX5eIOyxWzd/R1VY6sR6W/bM5MXKXuaGzX+czM8yym0vtMndG1lf66Y" +
                        "kd7fbd1XV6ded7BsDLvFfNU+uuK7Z6z0ld37SjfFb1Vas7GRvOvej7b96v1K3pe2e+z3Cvm+KScI3tyy" +
                        "vwjvd/WnP4zOtfoul0elf529XSvs6u3XXVG/Sr9dcWO9vqO/0armHW7/NZ8X+Z+CBAgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAgfcVcMn+771bdkfpf3NnT8iKS3ojOVd7RPkjr5GZVuaM5rk/j85a1" +
                        "GP1ebav0bhMPyv26rHuSP6RNZlZ7zGV/KP2XeuiuSqzROe7q+eZz63qPJHPq5kza7tjTpzvlJ5W9DH7X" +
                        "jS6/39mccl+lC+x7sovBG/4pfTlm/GVs3ddZJ4xXDX/TE9Xr82aVPrM5qzEVepnYzP1s7lucTM/u+rM9" +
                        "Dhycagy16xhx2xX5KgadcVfMWtnzYpDZ92RXJVeq7Ej/WTXVHrJ5uyKu7q3Sv1KbJfPbJ5Kz5nY2X4y6" +
                        "zN9jMZk6ov5W6BqfJJbtfd3+r1lZLaRNTv3s9Lfzr6qr4OZ3k42+D5Xpddq7IxhtLbSS5Sr+/nJvXXPe" +
                        "kq+L3M/BAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAwPsKzFxW3DX1yotx5e/3fQ09siZrt" +
                        "WLWkZwjM3auibxGZlqZMzP7vf6O11ymn46YyPT2fMVePdYdyT+yJjNrtMc/5ejYh5kc0VxVq5leOtZ2z" +
                        "xPl23HGMz2MnL1s3uoZ+J53dn3ldfNqphV9zL4XZffgR1OX7Ef5EutO+YJu9Qv4g7+knjRuqpfROZ+tS" +
                        "xUV9DYCHefjbYZ9o0ZH9uWNxtMqgXYBr5l20ksTjuznbc27/FTmO2mmSt/32JP61wuBFQIjr4tXa1b0K" +
                        "OfvEBg5i79DxpSnCiT+3CiEAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQOFdgx4Xf2elXX" +
                        "YzruNB5z3GfcbbX2fU/WY/kHFkzu8+V9Sv6m8kZnaXvs6183UW9VJ53nOsZ18yZGMk/sibTy4jX6l4qf" +
                        "Xe8f3zaPBm/k2Ze0ctsztn1HefylmNFH4+9rc7/n1ou2WdenoMxp35h997XiwOd+pA/fb5qf1WPan7x7" +
                        "ytQORvvO6XOCRAgQIAAAQIECKwRqPw+fYv1Q4AAgd8qMPgnSMsIECBAgAABAgQIECBAgAABAgQIECBAg" +
                        "AABAgQIECBAgACBMwRWXvbtmnDVxbXUPaSvIb7HvZprttfZ9T/1NpJzZE3XfmfyrOhvJufI62hkzYxNd" +
                        "N5XnesZ15l5V83T3dNqn0y/nVafNk/G76SZV/Qym3N2/bt8rq2Y89n5+1PLJfvMy3Mw5rd+IdjcBAgQI" +
                        "ECAAAECBAgQIECAAAECBAjUBAb/BGkZAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgcIbAq" +
                        "ou+ndOtuLgWXTi+PR/5me11dv1PPY/kHFkz4jW6ZkV/MzlH1q547Z14rkdsKudiJP/ImlU9re6l0nfH+" +
                        "8enzZPxO2nmFb3M5pxd33EubzlW9PHY2+r8/6nlkn3m5TkYU/sarWgCBAgQIECAAAECBAgQIECAAAECB" +
                        "H6rwOCfIC0jQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIEzhBYcdG3e7IVF9dWzT3b6+z6n" +
                        "+xHcq7y6TobIzNFtWdyjq7tdu7Odzcbne+2fmbt6J7dar76OamnVXsW2WWfV60+bZ6MU9Uok3M0ZkUvs" +
                        "zln17/L59qKOZ+dgz+1XLIffZkk1v3WLwSbmwABAgQIECBAgAABAgQIECBAgACBmkDiz41CCBAgQIAAA" +
                        "QIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAgXMFTr8QeZPrvri2cubZXmfX/3TSRnOOrttx2lf0NpPzq" +
                        "rWP1qee6xP7Oq2nmfOz+vU20tvImtVz3POv6G1FzlGPFb3M5pxd/w6fayvfU57O75L96Msksa72NVrRB" +
                        "AgQIECAAAECBAgQIECAAAECBAj8VoHEnxuFECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABA" +
                        "ucK7L4YNiLRfUGvO999pg7L7t5meuru5ae9f6xRORsrepvJuWLtLWflZ6aHV3VmztAt7+z6kd4it9N6W" +
                        "rV3jw47X2ufNs/oeYrWrXjebd/xWunu6dX7SmS6opfV73NPPztdso+2e+L5b/1CsLkJECBAgAABAgQIE" +
                        "CBAgAABAgQIEKgJTPwZ0lICBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIEDgeoGOC3Srp+i+F" +
                        "Ned7z5/h2V3bzM9zazNnImZ/N1Ot35ncs6sfVW7ctF+todnezazT9Fslfm+9zfT16u1V/Q0M8uJr7VPm" +
                        "ycyXvXai+r+9Ly7l4697O5p5v26Y57Ke9HM+8mr/f8zh0v2Iy+R5Jra12hFEyBAgAABAgQIECBAgAABA" +
                        "gQIECDwWwWSf3IURoAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECJwpsOLCWfek3Rf0uvPd5" +
                        "u26tNu5H7M9za6PzsHMPsysfdbXTM6ZtdH5iRzvz2d7+KlOxxnoyFHpLeN1Wk+r+uk4GyPn6tPmic7Ui" +
                        "FGUc/T5SZ8hHefvxPfr7z2tPu9P3/9csh99mSTW/dYvBJubAAECBAgQIECAAAECBAgQIECAAIGaQOLPj" +
                        "UIIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgACBcwU6L+StmrL7AmP3zNEFu8r/km1nb1Ffm" +
                        "f3qyPFTndk5u8/ErceZnDNr7z6rTCrn73Gvor3P5u3Kk+2t41xnZ9vZU2auk15r0b6/2zyv+u14/Y96f" +
                        "F83+z6SPdOV18gKn5mcO40qTpUz8GcGl+wrZMXY2tdoRRMgQIAAAQIECBAgQIAAAQIECBAg8FsFin96F" +
                        "E6AAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAicJdB52WzVZDOX6X7qqXPm6CLp/XnFZra/z" +
                        "p4yubpmq1xG7D4Ttxlmcs6sffSb2fuZtd/3MLPv2f3qzPVqn7L9RDke+82e7Q77jFO2n8yM2VyjZ/vT5" +
                        "nnlNWqU3YNq3Ox5zOxdx+utOlfmvTKbc9Yo8xob+fwv9e+SfZZrIO63fiHY3AQIECBAgAABAgQIECBAg" +
                        "AABAgQI1AQG/vxoCQECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIHCOQMdFs9XTrLjAGF0if" +
                        "DVTtPan5xWjTP6f8mXWdV8gzubL9pZ12nkmMj119TP7eoycrzjXUU/fnz/rMZMns1e3mEyuzNnO5Mn2V" +
                        "OmrYx+zfc2c7YxPdFm7I8fjrDPzVM9m1rg7LmN2wmfIzNyz+zhqVHmdumT/11//8/2/CODh/Xdm/9evr" +
                        "X2NVjQBAgQIECBAgAABAgQIECBAgAABAr9VYP1fK1UgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQ" +
                        "IAAAQIEFgrMXupd2Nr/pZ69TPdTj5kLdp0xFafuuh1+nT2t7Kfi/D12pq+Ztdk+osvItzw79ilz+fxxp" +
                        "l09Vfb+xJ7u/e/orcMqm+PT5ql8nmSNuuM6zV+9r2T77nx/jF4n2Z52vl9WesrG/jH1v2Sf5RqI+61fC" +
                        "DY3AQIECBAgQIAAAQIECBAgQIAAAQI1gYE/P1pCgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABA" +
                        "gQInCPwWy/Z33ag8yLi/QJ0l2dXb6/mrJ7Crp5+ytPVSzXPY/zMRdCZtT/1PHOOuvcpeq1E5q9sunqNe" +
                        "vj+/MSeMmexw6vTKpuro++u11hXnsx+ZX1WxHWZd3yGnGx+klPlHLhkX9Eaia19jVY0AQIECBAgQIAAA" +
                        "QIECBAgQIAAAQK/VWDk74/WECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAscIzFzm3TXEi" +
                        "gt6t967LtfdL9hHOates/3d63X6zfbUccH+lXPV+DF+xmlm7U89z7wuO/coOkOPZ/+Z/eoL7SN7fmJP3" +
                        "+fo3Md7rm6rSr5Pm6frvaNiWI2dNY9e/9l+ut8fuz8DTnHKev7f/P6X7Ctkxdjf+oVgcxMgQIAAAQIEC" +
                        "BAgQIAAAQIECBAgUBMo/ulROAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIHCWwMxl3l2Tr" +
                        "Ligd+999nLdT5eMO/sd7e9xbzr7ueUd7anrgv2rHmbO5IzTzNpnPc+8Njv26HtfozNm1o32O7rfJ/b00" +
                        "yyjLqe+1j5tnuhzZPR8dq4bNe/8DMm83qozd+c8wali8Kdfl+wrZMXY2tdoRRMgQIAAAQIECBAgQIAAA" +
                        "QIECBAg8FsFin96FE6AAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAicJTBzkXfXJN2X6X7qe" +
                        "+SC3av5O3uu9FaZbXb/Kn19j11VeybvzJ7NrB05Rz/9lztU9n70dT8yZ3ZN5TzN7PNt7Yk9jZ6DyG2XV" +
                        "aVO1PPo+cz0kN37TK57zIqclfpRbMW78j4S1V3ps8K84vTTe/CKnp4Zu2SfPX2jcb/1C8HmJkCAAAECB" +
                        "AgQIECAAAECBAgQIECgJjD6N0jrCBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIHCkSX7" +
                        "K5seeXF09m5IrfspfDZPqz/WSDan5Vu1YunO875iT1l9yDay3d7rX3aPNl9vCJux2vrirlW1DzdyiX7F" +
                        "bv+mLP2NVrRBAgQIECAAAECBAgQIECAAAECBAj8VoHVf6uUnwABAgQIECBAgAABAgQIECBAgAABAgQIE" +
                        "CBAgAABAgQIECBAgACBtxWoXmjfMeiJPe2YWw0CBD5DwCX71fv4W78QbG4CBAgQIECAAAECBAgQIECAA" +
                        "AECBGoCq/9WKT8BAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAm8rcOKF9hN7etsN1" +
                        "jgBAtsFXLJfTV77Gq1oAgQIECBAgAABAgQIECBAgAABAgR+q8Dqv1XKT4AAAQIECBAgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIDA2wqceKH9xJ7edoM1ToDAdgGX7FeT/9YvBJubAAECBAgQIECAAAECB" +
                        "AgQIECAAIGawOq/VcpPgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgMDbCpx4of3En" +
                        "t52gzVOgMB2AZfst5MrSIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBDIC5x4of3EnvKiIgkQ+O0CLtn/9hNgfgIECBAgQIAAAQIECBAgQIAAAQIEC" +
                        "BAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQOBogRMvtJ/Y09GbqDkCBI4ScMn+q" +
                        "O3QDAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECB" +
                        "AgQIEDg3wInXmg/sSfnhgABAlkBl+yzUuIIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABA" +
                        "gQIECBAgAABAgQIECBAgAABAgQIECBAgAABAhcInHih/cSeLtgaJQkQeFMBl+zfdOO0TYAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECPwOgRMvtJ/Y0" +
                        "+84DaYkQKBDwCX7DkU5CBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIEC" +
                        "BAgQIAAAQIECBAgQIAAAQKLBE680H5iT4v4pSVA4AMFXLL/wE01EgECBAgQIECAAAECBAgQIECAAAECB" +
                        "AgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIPA5AideaD+xp8/ZcZMQILBawCX71" +
                        "cLyEyBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBA4EKBZ190vf//X9ja5aXZXL4Ff" +
                        "xqI9mH18xMUohlP6FEPBFYLeB08F2az+vTJT4AAgb0C3tf3eqtGgACBTxI48UL7iT190p6bhQCBtQIu2" +
                        "a/1lZ0AAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQKXCrjA8ZyfzaVH8/+KR/twx" +
                        "fPdMtGMu/tRj8AVAl4HPq+uOHdqEiBA4AoBn3lXqKtJgAABAgQIECBA4L8CLtk7FQQIECBAgAABAgQIE" +
                        "CBAgAABAgQIECBAgAABAgQIECBAgAABAgQIEPhgARc4nm8umzMOfrQPVz7fJRTNuKsPdQhUBe5nt7rup" +
                        "3ivA59XM+eo8yzO9GEtAQIEMgI+8zJKYggQIECAAAECBAisF3DJfr2xCgQIECBAgAABAgQIECBAgAABA" +
                        "gQIECBAgAABAgQIECBAgAABAgQIELhMwAWO5/RsLjuW/yoc7cMJz1dLRTOuri8/garA9zNbXf9TvNeBz" +
                        "6uRc7TiLI70YQ0BAgQqAj7zKlpiCRAgQIAAAQIECKwTcMl+na3MBAgQIECAAAECBAgQIECAAAECBAgQI" +
                        "ECAAAECBAgQIECAAAECBAgQuFzABY7nW8Dm8uP5p4FoH056vkosmnFVXXkJjAj8dF5H8nxf43Xg86p6j" +
                        "ladxWof4gkQIFAV8JlXFRNPgAABAgQIECBAYI2AS/ZrXGUlQIAAAQIECBAgQIAAAQIECBAgQIAAAQIEC" +
                        "BAgQIAAAQIECBAgQIDAEQIucDzfBjZHHNG3umR/OzMrfpzFFapydgu8OqcdtbwOfF5lz9Hqs5jtQxwBA" +
                        "gRGBXzmjcpZR4AAAQIECBAgQKBXwCX7Xk/ZCBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAA" +
                        "QIECBAgcJSACxzPt4PNGUc12ocTn3fLRTN215OPQFVgxxndUaM69ynxbP7ZCRannEp9ECAwI+C9bEbPW" +
                        "gIECBAgQIAAAQJ9Ai7Z91nKRIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAgeMEX" +
                        "OB4viVszjiu0T6c+rxTL5qxs5ZcBEYEdpzRHTVGZj9hDZt/doHFCSdSDwQIzAp4L5sVtJ4AAQIECBAgQ" +
                        "IBAj4BL9j2OshAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIDAmwm43HLGhkX7c" +
                        "Hu+6idT+1XMqr7kJXCaQPRa6eh3R42OPuW4VsA5udZfdQIECBAgQIAAAQIECBAg8EkCLtl/0m6ahQABA" +
                        "gQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgTSAi7qpamWBkb7sPKS/ffBMr18j1mKI" +
                        "zmBQwSi10ZHmztqdPQpx7UCzsm1/qoTIECAAAECBAgQIECAAIFPEnDJ/pN20ywECBAgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgkBZwUS9NtTQw2oedl+zvg2Z6eoxZCiQ5gQMEotdER4s7a" +
                        "nT0Kce1As7Jtf6qEyBAgAABAgQIECBAgACBTxJwyf6TdtMsBAgQIECAAAECBAgQIECAAAECBAgQIECAA" +
                        "AECBAgQIECAAAECBAgQIJAWcFEvTbU0MNqHKy7Z3wbO9OWi/dKjIflBAtHroaPVHTU6+pTjWgHn5Fp/1" +
                        "QkQIECAAAECBAgQIECAwCcJuGT/SbtpFgIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAA" +
                        "QIECBBIC7iol6ZaGhjtw1WX7G9DZ3q7xyxFkpzAxQLRa6GjvR01OvqU41oB5+Raf9UJECBAgAABAgQIE" +
                        "CBAgMAnCbhk/0m7aRYCBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQSAu4qJemW" +
                        "hoY7cOVl+xvg2f6c9F+6RGR/ACB6HXQ0eKOGh19ynGtgHNyrb/qBAgQIECAAAECBAgQIEDgkwRcsv+k3" +
                        "TQLAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECKQFXNRLUy0NjPbh6kv2t+EzP" +
                        "Z7Q59KNkvxXC0SvgQ6cHTU6+pTjWgHn5Fp/1QkQIECAAAECBAgQIECAwCcJuGT/SbtpFgIECBAgQIAAA" +
                        "QIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBBIC7iol6ZaGhjtwymX1zN9ntLr0g2T/FcKROe/A" +
                        "2VHjY4+5bhWwDm51l91AgQIECBAgAABAgQIECDwSQIu2X/SbpqFAAECBAgQIECAAAECBAgQIECAAAECB" +
                        "AgQIECAAAECBAgQIECAAAECBNICLuqlqZYGRvtwysX1TJ+n9Lp0wyT/lQLR+e9A2VGjo085rhVwTq71V" +
                        "50AAQIECBAgQIAAAQIECHySgEv2n7SbZiFAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIE" +
                        "CDwJRBdPnp8fjpYdpbT59Bf7Vze9321W3S+Vte/54/62OWxa97vdTLzX9XbSK/vfNE+sxfvOt87zZbtd" +
                        "edeRD11vEZ31Mj0GfXx6e/Jj0ZZi087i5lz8ttismfhNJdM36f1HPWTmWnnazLqt/L8k2erOFwZaw+u1" +
                        "FebAAECBAgQIEDgCgGX7K9QV5MAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIBAs0D2y" +
                        "/BRXHNb5XRRf5nn5aLBgkzNq2Iys0a9ZXKMxER1q89HeojWRD1E62eeR7Uzz2fqn7T23WZd0W+Uc+V+R" +
                        "bUzz6/s71XtTO+vYlbO9T33bK9dF7+7+vieJ2MZ1c7kGI2Jameej9bOrIvqZ3JkY6Ja2efZes/isnWqc" +
                        "Zm+opyZHKMx3bVn8kVro+ejBjProp5G3/OjvDM9Z9ZG9TPPM3VGY6L6n/JZPerz07oZs+58US/R804Xu" +
                        "QgQIECAAAECBAjsFvjz++5ff/31dv+59f2//9ltph4BAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABA" +
                        "gQIECBAgACBYwSiL7yPPt894GifoxdlKvOt6K0rZ2aOqFYmRyUmqtfxvNLPq9iol646j3mimiPPV/S5M" +
                        "2dm5p39RLVW9BvljHoaeR7VHHk+0ke0Jurjp/XRmurzqMeZ59VesvGjPWXzV+My/UQ5MzmqMVHNkefVH" +
                        "jLxUR+ZHFFMVGP0eVT32fPRetG6TD8dOTJ1Rt6/qnlHZonWVJ9Xex6Nr/b1LH7HvmRn7JrpMU+2diUu6" +
                        "nPENMr5/Xml3xNio/mqPY7ki9ZUn1d7Fk+AAAECBAgQIEDgBIE/v/e6ZH/CVuiBAAECBAgQIECAAAECB" +
                        "AgQIECAAAECBAgQIECAAAECBAgQIECAQF6g+oX3kfh8N+ORI31V14x39/fKar2d8ZnZon4yOTIxUZ3u5" +
                        "5meopiop2h95XlUa/Z5pZfTYjOzn9Rzpt9bTOUnylnJFcVGtWafR/Wrz6N+vueL4kefV/uO4kf7qKyLe" +
                        "vjpeSV/JTbTS5QvkyMbE9WafZ7tIxsX9ZPNs3PPH3se6S+aefR5ppcodybHaEx37Wq+KH70+ahHZt1oT" +
                        "9G6x9qV2EzPUUxUb/Z5VL/6POrnXT+rqw6V+KpZlLuaL4offR716TkBAgR+q8Do+2pl3W+1NTcBAgRmB" +
                        "f6817pkP8toPQECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAIF9ApUvWHbErpqso7dsj" +
                        "pkZsjWuiMvMFfWVyRHFRDVWPY/6ip5HfUXrs8+jOp3Psz2dFJeZ/6R+b7109xzl65o/qtP5fFfPj3U6+" +
                        "/8p166Zuueo9N1d+54v00NUO5MjExPV6Xye6ScTE/WUyfFTTJS3+3mlz+7aJ57FkT2pGGY+r97xPfSKn" +
                        "qPzWN2XV/FRrc7nXX1HPV2xZ12zrcpTMcv0UMkXxc4+z/QrhgABAr9NYPa9tbr+t/mal8A7Ctxe137OE" +
                        "PjzHuuS/RmboQsCBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECkUD1S5Vd8VFf1eddf" +
                        "VXyVHu8x1dq7I7NzBT1lMnxKibKv/r5TP9RbzO5b2uj/Kuez/a9e33GYXdPUb3unqN8UT/R8yj/qudRX" +
                        "5nnUW+736szPZ/4npntO/IefZ6pH+XO5Hhn+5neR2wi71XPs71eWT+qnZ1hJK67djZfFNf1fMTk2Zqun" +
                        "qI8md/pOuaK+lj1fEfv7/ZZ3WES5Yj2M1r//Xk2XxTX9bzav3gCBAh8ukDX+2s1z6e7mo/AOwo8vo7fs" +
                        "f9P7PnPnrhk/4lbayYCBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAIFPE6h+kbIzvtOys" +
                        "69qrpE5qjV2xmfmifrJ5HgWE+Xe9Xx0hqi/0by3dVHu1c9net+9NmOxu6eoXnfPUb6on1fPo9yrn8/0n" +
                        "nktZWK6ZxydqbuPSr5sz5WcldhM/ShfJsepn1czvWfOeDV/ZL3yebbXVT1k6ke1MzlGY7prZ/JFMd3PR" +
                        "20e13X3NJtvdqbZ+rPrV/efeR+bneH7+tmZVq+P5q3Wz+SLYrqfV2cQT4AAgU8W6H6PreT7ZFezEXg3g" +
                        "Xf7nfXdfEf7/bMvLtmP8llHgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAYJ9A5QuUK" +
                        "2I7Jl3RVzVndY5q/p3xmVmifjI5foqJ8u58vmqGVXl32Yz2v3tdxmN3T1G97p6jfFE/z55HeXc9H+3/t" +
                        "m5Xj5U6o/NUaqyIzfS9ou4tZ+Ynqp3JcfLn1Wj/mddBNXdkvfp5pt9VPXTUzuQYjYnmruaN8l3xvDrD9" +
                        "/greo5qzswU5d71/BNmeLSamWfH2mhfqz1E+a54Xp1BPAECBD5Z4Ir34Xf6XPzkvTcbgVf/pqdzhsCf9" +
                        "0uX7M/YDF0QIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQeCZQ/TJmRnJFzld1q/Xu8" +
                        "btzfq832ndl3b3myJpor6Oc0fqfnkc5f3qerTOSO3uBs7q32Z6reUd9RmxGZ9i5LjPXzn6ytTr7jnJle" +
                        "/rEsxjZZJ5Hfpkc32OinLN7kclf7XtFzmwPHbUzOXZ+ZmVn77jcEtWq2ES5Rs76CTmzPWSsolyZHKMx3" +
                        "bWjfJnn0SyZHCPnasfreaT30d/jnjmO9BDtye35qrxd+1I9EzvnyfjOxkTzVPNH+TLPo5qZHNV9jWp6T" +
                        "oAAgU8RGHkP7V7zKZbmIPCOAs9ez+84yyf2/Gd/XLL/xK01EwECBAgQIECAAAECBAgQIECAAAECBAgQI" +
                        "ECAAAECBAgQIECAwCcJZL5YOTpvJvc9ZrTGbd3qOqvzz8yeWbuq/yhvprfvMVHO3eflVm/kJ5pjRc7Hm" +
                        "iP5d7yWRvsaXRftw+j+jvaTXdfZd5Qr29NjXJTzXc5iZY7ZmSq1qnuSyV3NeY/P5J59X45qjPZeObMjN" +
                        "aK+Z8/MrvfkaI6KTZRr5j03k/u3nsXsHkWG2Twj7w+zr4eo99n8q19vlf6/x1b3ZWR/PqXG7Dmo7NOo2" +
                        "Y510RzVHqJ8z55X66x+HY70Yw0BAgTeQeDV+/Rs/9nPgNk61hMgMC7Q+bvYeBdWPhP4sz8u2TsgBAgQI" +
                        "ECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBM4VyHxZsqP7lXUyuWcvXd0MdtXp8H7MsbLvK" +
                        "Hd1lihfxz6O2FTnyJyXas5PsqnOPhOfcZvJv2ptZ99RruoMUb5Pep3+NGvVa/V7TmY/Znq+r11ZJ8q9o" +
                        "/9qjajnT3odZG0yJtlcr+JW1oly7+i/o8azHN3zRfne4T208h53m2fmZ8RrtGa21sw8qz/fqnvzOPPMX" +
                        "LvtZnr1Wl+hJycBAgTeT+DVZ1fXNJnPx65a8hAgUBN49vqsZRG9SuDP/rhkv4pXXgIECBAgQIAAAQIEC" +
                        "BAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQLzAtGXJOcr/JNhVa0ob+dFt521uuxX9hzlrs4Q5Ru9aPSqj" +
                        "0zNkbpR3newufXYPUd17tn4qP+RvZ3tKbO+s+8oV6afx5go3yrTqG51jsz5/l5zpMb3NdEc1c+sKF9Hz" +
                        "/ccq2qtyls5t1WnqOdPeh1kbSKTbJ5M3Kpaq/KuPIsZr1Wv4cjrHd5Dszadr+kdbpkalbOTjY3qZvNUX" +
                        "jPvdM5G5h9Z070PUT57MLJL1hAgQKBP4NX7dF+V9//7UKeFXAROEnj2HnBSj7+5lz/745L9bz4CZidAg" +
                        "AABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIEDhdIPrCfGf/Ua2RyyuZnCN5X819Rc3RfVjda" +
                        "5S/2nd3vkz9qGb1wuu9ZpQ301s2V/cZ/95b5yyVuTtio95X243O0Nl3lKvSY5RrtWdUvzLLLTbK9/i8m" +
                        "nv2cyRbL5ohmycTF9Ua3f8ob6a3KKazRpRr1CGaIfuZkM3TnS9yqfa16zX0WGfHDDtqPLPrrh3le4f30" +
                        "Oxnwe7zO2OX2ZfOeVb/3piZZ/T39SveZ1bad7+vZ/PNnNdP3YMd+6wGAQIEMu/T3UrR53J3PfkIEIgFn" +
                        "r0u45Uidgj82R+X7HdQq0GAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIEBgTGD3lyO76" +
                        "0X5Vl10u6puZZczPc76RDW6+63kq8RGc4w4RTk7+6vkGontnGWk/syaqPeRvZ3pJ7u2s+8oV7anW1xnr" +
                        "krde2x3/Sjfikt7GcfKuYxmGHF+tWZFvRU5v8/QWaMz18j+dNfvyteVJ2uyot6KnCvPYtbKe+hrqWjfK" +
                        "+/J2T3J1Bz9DIpyZ3scjeuuH+UbdYrmy9SNclz1POq92leUzx5URcUTIECgV+DV+3Rvpb+z7a63YgY5C" +
                        "XySwLPX5CfN+M6z/Nkfl+zfeQv1ToAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAg8OkC0" +
                        "Rfmu+f/Xm8mf9T7igsxj/1eXf+VXaa3Dp+oTmV/O3NV6t5io9ojVlHOSo8nfIG5c57K7LOxUd8jezvbU" +
                        "2Z9Z99Rrkw/95hPO4uRzarz0Vk3ylXZ30xs5+d45lx17UGn0297HWTOReazNJsnG+csZqX+iet8HWT2v" +
                        "Ov1+33SaI5q3ShfXTq3Iqp7f57Lltvnaq7R+Gi2St4oV3W/s7Wvqpvtb+bfgtUaV1lcVbfqI54AAQJXC" +
                        "+z+98nuelf7qk/gdIFnr8nT+/4t/f3ZH5fsf8t2m5MAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAA" +
                        "QIECBAgQOAdBd75i+tX9351/WfnLdNX12WUqNbMa2LF5bkZs+osXTZdear9f48/pY/qHFHfXa+Fal9Rf" +
                        "GffUa6ol/vzrjzZeqOv10r+aKaV5yOqnZ0jyrNyhmyPUVw0Q7Q+87yrRleeTM+vYjr76MoV5XEW/97Ry" +
                        "Gn2bOw6N5lZVu55l2OU58oZ7r1VzkQ0TyXXTGxnH1GuK/doxmjl2sisWjvKZw+qouIJECDQK/Dqfbq3U" +
                        "vz7bHe9n2abrRF9rs3mn12/Yj9X5MzOebJ31NvI7+NZl+q/26rxv/33syvP/Pe9+tOLS/YdLw05CBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECKwROPXLZJlpo94zOWZjTujhcYaon8fns7Pf1" +
                        "kf1OmrsyBHNMfLFxChndq7jvhT4ZN+z8+yOi/ZhZG93zNDZd5QrO88nnsXIZuX5iGp37Ev3e362p2pcl" +
                        "8Wrul01fuPrILufkfFVFxSy/e/6vSZyqvRbje2uHeX7hPfQqnE1vtvwN75HvcM5q56L2fjoXFXzR/nsQ" +
                        "VVUPAECBHoFdn/+d9T7KUf175sVxcxnWdRTpd499lndn3JVesz0Usm34rN8tn7FLuMR7Um230qt77HRG" +
                        "cv0kPl3a5RnZIYo56r9ejVvxrfj/WrE6z/vZy7ZzzJaT4AAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQGCdQPULUus6qWeOeq9nrK84oYd711Evj8/rk/68IqrZVWd1nmiOkS+bRjmzM53wZcDMG" +
                        "cvOszsu2oeRvd0xQ2ffUa7sPJ94FiOblecjqt2xL9EXuLM1Vsd1Wbzqs6vGb3wdZPc/Mv7+PJt3Z1w0Q" +
                        "0cvO2o867O7dpTvE95DO/Z85r2pavgb36OqRpU9jc54JdfO2O6+o3z2YOfuqkWAAIH/Cuz+/O+o9+rfq" +
                        "pnPnXtMdB4quTrm+t7Ps5yPcaM9zv6Omekt8v3p+eg83/e0u7/Zvjr+Pdt17mdnqezrbK3sa3XkPHe8j" +
                        "lb+Hnvv74+BS/aVYyeWAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAwH6BmS9L7e/27" +
                        "4qZnnf09k59dHyp7btpNP+OPeioEc0x8oW7KGe27xVf8s3W/oT9jvZhZG9H/SrrOvuOcmX7+sSz2GWTN" +
                        "XyM66wd5Tpp736yivof8V31/nWSZZdbV57s72fdlyU6zsc9R6fFs7521NhV+xNmuXKG7Gumcsa9R1W04" +
                        "tirz0fc4c8R3X1356vMdWXtSp9iCRAgcKXA7s//jt/nf8qR/d0o+/fN6DOk+nxkjyOrag/f40f+fZ2pO" +
                        "TJrdf+icxvZVXrMzDwSU+nhmU/VrRr/7LWW6X3EJNrXTN3s33Oy/47PzDHSV3bNn/ou2We5xBEgQIAAA" +
                        "QIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBC4RiDzRaNszK4Jon529XGrc3UvUf3H590uUe3ue" +
                        "t35ov5n7KLcmVmiHKc9z8y0OyZjtLunTL3OvqNcXf1EdXY+z8x09ft35JGdITNHVGvmva7S57PYqL9Ta" +
                        "kR9nvY86xb1nc3jLOakOr1zFf+J6q7dna8yT0ftjhyVnle/B0bznPY8axf1nc0zEndl7ZF+72u6++7OV" +
                        "5ntytqVPsUSIEDgSoFX75XdfXXV+ilP9d8Tr2aLPj9Gn1c9n9Wpzpp1H53r+7rqnJ3zRDNUe4vyzTzv6" +
                        "KVqV41/9lqLep9xyZ7XqIfod9sOi3uv2V5G4v7UcMl+hM4aAgQIECBAgAABAgQIECBAgAABAgQIECBAg" +
                        "AABAgQIECBAgAABAnsFVnxxauUEUb8ra3/PfXUvUf2VXxaLau/ch0ytqN/OLwFGtVb3G9Vf8Twz0+6Yz" +
                        "Jy7e8rU6+w7ytXVT1Rn5/PMTLeYqKdsnpG47tpRvpHnI3ONrIl6G8m54rM66vO051m3qO9snntclG/ke" +
                        "bWH0fiot9G8j+t21HjWZ3ft7nwV347aHTkqPa/el2ie055n7aK+s3lG4q6sPdJv9n24mvtKhytrV53EE" +
                        "yBA4CqBzr9lRTM8qxWtq/77LHr/vz0f/d0qk7vL9JXXbB+P628Wnfle+V7lfp+vcta6TX7Kt7ufjr2Oe" +
                        "l7tFtVf8X6RmanaVzb+T22X7LNc4ggQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAhcJ" +
                        "5D5otFMTPdkUS/d9V7lu7KXqPbIFxArdlH9Sq7O2KivkefV/qIamXxRjtOeZ2baHZMx2t1Tpl5n31Gur" +
                        "n6iOjufZ2a6xUQ9ZfOMxHXXjvLNPh+ZMbsm6i2bZ/VnddTnac+zblHf2Tz3uCjf7PNqP5X4qLdKrmexO" +
                        "2rsqv3us1zZ/+MedfUR5Tntefb1FPWdzTMSd2XtkX6z78PV3Fc6XFm76iSeAAECVwm8eq/s6qn7/TjKd" +
                        "3/+vf9n///Zz8Db+ugn01uUo9LPY73R3+OrZ6BzxlvPM/kyazNGz85K1abye3rmPFXz/ZTz+7mvmn2Pf" +
                        "3V+M7mj89+RY8Tt1X509xQZ/Kd/l+wrZGIJECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABA" +
                        "gQIXCeQ+bJRR0zHhFEfHTWyOa7qJaobffE0O9+ruKiHjhrPckS1u59XZ4nqZ/JFOU57nplpd0zGaHdPm" +
                        "XqdfUe5uvqJ6ux8npnpFhP1lM0zEreidpSz6/nIvFd/lkSzZ2aKcpz2PDPTqtfBLovsjNm4qO9snqvP+" +
                        "+jvTtX5dnitnOXK/h/n6uojynPa8+x5i/rO5hmJu7L2SL/3Nd19d+erzHZl7UqfYgkQIHClwKv3ytm+o" +
                        "vfh2/ORnyvyVvuMeszki3Lcn3fm6szZ0VcmR+bfpZW5onzZnrp/t8qch2pvr2btzDXyWo/mzfYX5amcj" +
                        "ZXvly//7eqSfXa7xREgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBC4XiD7paWOuJlpo" +
                        "/ozuatrr+glqln5cll13sf4qI+Z3D+tjeqtfF6dJeolky/KcdrzzEy7YzJGu3uK6nX3HOWL+rk9j3Kc9" +
                        "jwzU2aubJ6RuMhsJGdmpqhu5floj9/XRTU76nTUiHKc9jzrFvWdzVPd16hu5floj9WeO+pEc3XUeJaju" +
                        "3Z3vsrsHbU7clR6Xr0v0TynPc/aRX1n84zEXVl7pN/7mu6+u/NVZruydqVPsQQIELhSIHqvXPV8Zuaop" +
                        "5Hcr3KO5Iv+fZ3JGc15e1756c63esbKbFEv99mzObvPQ0e+aP+ys32Pe5a3mq9jxmxvlbPf7bZizlfWf" +
                        "+q5ZF89juIJECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIXC8QfXmp8/nItFH9kZyja" +
                        "3b3EtWrfulwdO7buqiXmdz3tVGNXc+rs0R9ZfJFOU57nplpd0zGaHdPUb3unqN8UT+Z13pUY/fzzEyZu" +
                        "bJ5RuIik5Gcj2ui/J3PV/c6m79rrzvNduTKukW9ZPM8i4vydz5f3ets/q6zONpHZF3N252vUr+jdkeOS" +
                        "s+jr5FsjWie0553zZXNMxIXmY3k3LGmu+/ufBWDK2tX+hRLgACBKwWi98oVz2fnfdXTaO5nOUfz3dfN5" +
                        "I3sq71F+W7Pqz8zezGzduXvxiv6evVvuaz5qX11nPVXBjOvoVfu97xZ/2jOkddPpvafPl2yz1CJIUCAA" +
                        "AECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIHCeQOaLe10x1emjutV8M/E7e4lqPT6fmSm7N" +
                        "uonm+dZXJR/5/PqLFFvmXxRjtOeZ2baHZMx2t1TVK+75yhf1M/teZTjtOeZmTJzZfOMxEVmIzm/r4lqd" +
                        "D6f6TfqYyb3fW1HjSjHac+zblHf2Tyv4qIanc9n+o36mMndeRZH++ierztfZa6O2h05Kj2P/r6brRHNc" +
                        "9rzrrmyeUbiIrORnDvWdPfdna9icGXtSp9iCRAgcKVA9F654vnsvK96Gsn9LN9Irp/WjObvnvPW286ck" +
                        "d/OXu61op5eGWXWjvy7Npt3hVfXvKNnfHb2zPoVbqvnfZzrTy2X7DNbLYYAAQIECBAgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIDA2QIrvpD5PWdFIOqnkms2dlcvUZ3H57MzZddHPWXzfI+L8l7xvDpL1" +
                        "GMmX5TjtOeZmXbHZIx29xTV6+45yhf1c3se5TjteWamzFzZPCNxkdlIzldronodz0d7jmqP5n1c11Ejy" +
                        "nHa86xb1Hc2TzYuqtfxPNtL9feP0bzdZ3G0j8i2mrc7X6V+R+2OHJWen8V29RHlOe151i7qO5tnJO7K2" +
                        "iP93td0992drzLblbUrfYolQIDAlQLRe+XK56Nzv+ppJOezfCO5flozmr97zltvO3NGfqMuo3lv9ao/j" +
                        "z1W136Pn513xd69OhOVeWdni2rN5F/hNtNPNOuP58Yl+yqbeAIECBAgQIAAAQIECBAgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQJnC5zw5cyoh52CO3qJanR+YbBiF/VVyXWPjXJ2Pq/UrM4S9ZnJ15EjU+eTYyLDk" +
                        "S/orvTK9FvtOcqZmacjR6bO7pgr5zq5dtRb9xeco3od56KjRkeOjlm6c1w5V1R75vmIU1RvJOf3NTtqP" +
                        "Ouzu3Z3vopvR+2OHJWeV+/LKfN0mDzmuHKuK2vPOHb33Z2vMtuVtSt9iiVAgMCVAtF75Y7n1fmf9VTN8" +
                        "+rveqO5Kr+zRTW6/+18q9dtN5NzRS+v+qn+PSzan+rz2Xln11fOZtXqp96qPlH8aI0Vbityvtwfl+yj4" +
                        "+E5AQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAgfcVWPFFzYxGVDeToytmRy9Rjfvzr" +
                        "pmyeaK+snke46KcM8+f9ZPJWZ0lypnJ15EjU+eTYyLD6pdOV1ut6DfKmZmpI0emzu6YK+e6svbq99zqP" +
                        "u6w6KjRkaNqsyP+lLmiPkaeV/2iGtV8P8XvqDH6+051vnef5cr+K+/D2X05ZZ5sv9m4K+e6snbWZ8f7z" +
                        "JUOV9ae2QNrCRAgsFMgeq/c9bwy87OeKjnusZ25XtUfqTOyJjI4JeeKPjK/I0c+K5/Pzjy7vvrvvKzFq" +
                        "r6+1x+tM7qu+/Wc9fxxbpfsR/msI0CAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIPB+A" +
                        "h1f3MxMHdXJ5OiKWd1LlP/+vGueSp6ot0quW2yUL/O8WjNbt5o36jWTryNHps4nx0SGt+cn/azoN8qZm" +
                        "b8jR6bO7pgr57qy9ivnqK/M8+o+Rjmr+X6K76jRkaNjlu4cp84V9ZV5XrWKclbzrTqLo310z9edrzJXR" +
                        "+2OHJWen8V29dGVp2OmzhxXznVl7RnD7r6781Vmu7J2pU+xBAgQuFLg1XtlR1/Re/Hj82y9Zzmz6x/jK" +
                        "v2tiB359/XInPc1nXYzOVf0kdnXGbvRtdG5yeZdZTabN5pv9fPIb3a+yr/Lo15Gnv/p3yX7ETprCBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECHyGwMiXsDKTR3kzOTpioj5uz2d+Mvlna6zsr" +
                        "5I7O+s9rpI7is3UjnJ8fx7lzOTryJGp88kxkeGVr5/qmRk9+5FBZv87cmTq7I65cq4ra1ecoz5/el7Jf" +
                        "4uNalTz/RTfUaMjR8cs3TneZa6oz990FkfPQGRYzdudr1K/o3aUY8fvCJ09RLkqvifFXjnXlbVn9qC77" +
                        "+58ldmurF3pUywBAgSuFHj1XtnZV/SeXPnd6VmukX4zfa2MedVz55z3OqfkXNHHo+Xq/CP7NtvT7PpnP" +
                        "c/mXfn6yOSOXvez81X+RhT1MvL8T/8u2Y/QWUOAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECB" +
                        "AgQIEDg8wQyX6q6x0TTZ3JFOTqer+wjk7vyBdaOeb/niHqs1IxyZc9GpeY9NlO7mjfKmckX5bh6/zMzX" +
                        "B3zToareo3yZvYoyvGuZzGaK2MzGnNl7VU9P85UqbHDoqNGlMProLLrc7GZvRj5vSHKO9f136t31HjWZ" +
                        "3ft7nwV367aXXkqvT/GRvUr7yuduUbnWbEummtFzey/EVbWnsndbdadrzLblbUrfYolQIDAlQKv3itX9" +
                        "NXx3vwsx0i/UT+rn7/quXPO6PeTEbuZnCtmy/yePDNnJv/Iecn2tMpsNu/IzJ1rIr/Z+X7KvyLny3+Hu" +
                        "2QfbbPnBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBH6XQOZLWBmRKE8mx2zMqh6iv" +
                        "CMXx2Zn/Wl91GelZmeuSt1bbFS7csHpXjvKme2xK0+23qfFRX4je7vCKNPnaK9R7uw8XXmy9XbEXTnTl" +
                        "bVnbaPeq2c1yjfbb+Z9PltjR6/ZXrri3nmmqPdPPovV/e+26nxdVWfprB25jPRWWRPVP/EMV+briI2MO" +
                        "mo8y3Fl7Zm5uvvuzleZ7cralT7FEiBA4EqBV++Vq/qarfls/Ui/0WfF6ueveu6c817nlJwr+ni07M6/8" +
                        "hxkz233TF1nYqVNJnfkt8JtRc6X/6ZwyT7aZs8JECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAg" +
                        "AABAgQInCHw/ctFq7rq+HLVrbcoz6r+H/Ou6CHKeX++Y76oRtRrtP7+PMpTvWCUrZs5R6Pe0UzZHrvyZ" +
                        "Ot9Wlzkt/JsVSwzfY72GuXO9tmVJ1tvR9yVM62o/W6f49nPgI6z0OXdladjpq4cK2ZyFp/vzgrvzFmI6" +
                        "o58xkQ5M32NxnTVjvKMuGRnytSu1o9yZns7Ke7Kma6sPbMH3X1356vMdmXtSp9iCRAgcKXAq/fKVX3Nv" +
                        "j8/Wz/Sb9TL6ueveu6cM/r384jdTM4Vsz3O0Jn/yjOwaqbOvKt9ovzR2e08CzNnPurz2fM//btkP8pnH" +
                        "QECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAIG1ArNfcJrprqN2lKN6KaU6z4r6mZz3m" +
                        "Gq/K+KjfrM1u/Jk6z3GRbVHvaO82V6jPKvP+Sur7AxXxp3k98wh0+PMPkf5s/sT5ZnpMdvDPe57L9X1z" +
                        "/J05c30E3nuypGp81NMR/8796Gr3yjPb30dRC6j5yyzrrN2Z67R9/zMzCMx0WwjZzfKOdJndk1n7c5c2" +
                        "f5vcVHdkd9BMzkrPc7Edn2mRjPN9BitvbJ21Nur5919d+erzHZl7UqfYgkQIHClwKv3ypV9zdR9tnak3" +
                        "+izYvXzkc/kkTmjfz/vztm5h5W/OVTmXL331d/XV5nN5t3lNNrn6Lrdr82XfwNwyb7y0hVLgAABAgQIE" +
                        "CBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAYJ9A5gtUq7qJamfqRjlGLgtl6t5juutn8lW/vFeZZ" +
                        "yQ26jmbsytPtt5jXFR71DzKm+01yrP6nK8679n5Z+NO8Xs2R6a/0TOY3buscabXbK6ZuM4+olwzfUZrO" +
                        "2pHOVa+P0S1o/kr78OVXKOvtWyNaO6V5hWzSh/RTBmbKEeln0y9ikUlXzRHJdfoWVxlFc02UjfK2eE16" +
                        "lipHc0xYhPVz9Qc+fzP5I1663je2UeUq6PfHedsZZ/fc3ebdeerWFxZu9KnWAIECFwp8Oq9cmVfM3Wfr" +
                        "R3ptzPXSP1Xa1b0dkrOFX1k/p2X3aPod4jK83vN2Zln11d/Z521yq5fHbfCbUXOl/vjkv3qYyI/AQIEC" +
                        "BAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAgXGB6Atl45lfr+yqG+VZcSnmNll33Uy+kYs2q" +
                        "/bvnjfqO1u/K0+2Xrb/x766c1fyRT6rzvljj1EPlXl2xkZ977B7Nm+mt47XfVSnsh9Rrh2eUQ+d81RyV" +
                        "WO75ujKc1X/mc/Uam8/xXc6Rbl+6+sgcunYx6v3tmOGyGnF+cnUHKkb5e3wGv0MrdSO5hixiepnao7+D" +
                        "pDJHfU3+zzqoZK/M1el7q7Pp2pPmfhus+58mRmy/16r5BJLgACBTxV49T69cuaZus/WjvTbmWuk/qs1K" +
                        "3o7JeeKPh4tZ/NHv7+M5B9Z0zlT9d9G2fM8O1e2zmjciv5W5Hy5Py7Zj26/dQQIECBAgAABAgQIECBAg" +
                        "AABAgQIECBAgAABAgQIECBAgAABAgTWC2S+cLaii6hutmaUZ/Ryyqv6K2quyJk1nImL+s7m7sqTrXeLi" +
                        "2p+f17JnclfyZfttZKzEpupX8m3M/bU3jN9db1/RbUq+xHl6ur5WU+Z+p3zVHJVY6NZsvmiPLfnK36iu" +
                        "pWanblGz05nv7/1dRDto7P49ynb7ZSpN3pmo9yV11U1trt2lK/z/GZqPcZ024zud7aPzHzZXJnXTCVXN" +
                        "TaapZpvV3x33935Kg5X1q70KZYAAQJXCrx6r1zZ10zdZ2tH+u3MNVL/1ZoVvZ2Sc0Ufj5Yz+aPfH0Z/t" +
                        "5/p6dXvtbPn7tS+Zue6r5+d76c+VuR8Nu+fWi7Zdx0HeQgQIECAAAECBAgQIECAAAECBAgQIECAAAECB" +
                        "AgQIECAAAECBAj0C6z60tmrTqOa1SmjfJ0XSbK1Kl/Wy+asuuyIj3rP9hDlqXhmambqfY/J5H2MiWp05" +
                        "+s855U5uvem6hLFR/twRf+Znh5johmj51G9aP3351G+dzqL0SxVm0p8V+0oz4ozHtWsONxiu/P9VL+7R" +
                        "pTvN74OMibVsxHFRzWj9dX3t2q+Z/FR312v20ydmc+bKH+X1ye9piOzn56POGbrjOSe+XfeyNmOZumeo" +
                        "fJ78MraM7m7zbrzVWa7snalT7EECBC4UuDVe+XKvmbqPls70u9MHyP1Kms657zXPSnnil6ivxFk/Fedi" +
                        "dl5Z9dX/32ZserwztYZjVvhtiLny/1xyX50+60jQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAA" +
                        "QIECBAgsEcg+uL6yGWIZ52vqJXJ2XHZbUWdbM49J6FeJeo/mzHK03UGM3W6vmQX1cra3OOifI/Pq7lnX" +
                        "q9de9PV8/c8GbdVtR/zZvr4Kaajt6h2tUaU753OYjRL1aYS31k7ytX5Ol1RK8pZcR19P6vWiHr+ra+Dj" +
                        "EvVenRPR8591P/O3kf6n/3cqc63y+unvlbUjnLOvK4rub/HVvflFl+pN5J/ZE/uPVXrRbNU81Xir6xd6" +
                        "bP6+28195UOV9auOoknQIDAVQKv3itX9jRT99na0X678432kf1Mnsm/YtbRnKProvlXnK3Zf1+9+h07m" +
                        "uf+fLdXtq+O2Sq1qrEr3FbkfDbXn1ou2Ve3XTwBAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIE" +
                        "CBAgACBvQLRF9dnLpQ8TpKtMzJ9NvfoF+pW5M/mHPHYtSaaodJHlGv0Ys69h2z+ri/ZRfUqNqMzjNS4r" +
                        "Yl673pPGO2vsi4zSyVfNjZTN4rJ1oriVtSJcn5/HvX47HmlzkiNKP9IzuyaztpRrq7XbLZO1qDy3lbN+" +
                        "T0+6n0kf5TzN74OKiYj5pUzM/I7X6b/mb6r/a+a4eTfdbK+0V5l8zzGRTl/eh7VGcl5xXvHyFnbcZ4zv" +
                        "5dGezDzPNq/mdwr13b33Z2vMvuVtSt9iiVAgMCVAq/eK1f1Nfv+3PX7aPT7SOf8I/+u7p7z1e9GM7OO9" +
                        "jm6Lup15kyf2NPqc9oxc0eOyr5GsZl/p1VyfI/dMe+/9t0l+5ntspYAAQIECBAgQIAAAQIECBAgQIAAA" +
                        "QIECBAgQIAAAQIECBAgQIDAeoHoi5EzXzqq5h6dtlrnHv+q3oqc93rZ3I/9Zdd0xkX7EdWK1s/Ml8kd9" +
                        "Vd5nqlXmaea7xZf6bd6QWs098gcO9eMznX1uk6jaJaRWlHOFV+IjmqumGMkZ3ZN5zxRrtM/x7P9Z21/i" +
                        "otqjOSOcv7G18GoSca/mjuT83tMtsZI7srvCD/1EdXM9j5zLqteUc8zz6N5R3NHea94fsUsUc1Rhyjvr" +
                        "vfvbB/RnNk8u+O6++7OV/G4snalT7EECBC4UqDz97vsHLM1Z/6NWv19ITvTq7jRebvnvPV4Us5Rl1HrW" +
                        "73oZ4XPK/dMT/eed/cWWT0+X7GXXflXuK3I+cz7Ty2X7CvHUSwBAgQIECBAgAABAgQIECBAgAABAgQIE" +
                        "CBAgAABAgQIECBAgACBawSiL6/vej4z/a4eO750dkKvmR6i/YhyROsfn0e5rn5emeUWG/VbzXePj/Luf" +
                        "D46w851Oz26anX7RH2N1ovy7ny+aobRvJl1kU8mx4nvodW+M++XHVYdOX6aLcq78/mIfca/mnfnzB2/k" +
                        "3W+jipWu52u2OuKRzU28qvm6zwHUW/V558yy+gckddo3sy6K2tn+nsW0913d77KbFfWrvQplgABAlcKd" +
                        "P9OHM3S8d78LEdUe9dn3/c6o/2OrnvlcFrOzvMXna3b8+hnp8+9VtTT/fmK3l79Oy/b14p/K3a9hrrm6" +
                        "+yn4vp//btkX2UTT4AAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQOAagcwX2VbGdEy9s" +
                        "r8od6X/KNcpz6OZoj6j9d+fR/lWPb/1kcldmSfKV8l1itPjTDP971wb7cNpz1fYRDPO1Ixy73i+sv+Z3" +
                        "NHayCZa/9PzKOfq5yM939fM9JapG+XP5HgWE+Xe8Xxl/yO5d8zceZnjccaZ3itWM3Wqa7Ovs0r/md+dq" +
                        "vkq8ZFBJdeJ76edv3NFVjuez+xH1N9M7mjtlbWj3l497+67O19ltitrV/oUS4AAgSsFVv1ePPI7UtbhW" +
                        "c/Z9St7+557xnfnnCvsMjm7PqujPPfnUU8z+zVyrm71sj8rzsOrf5dl+7rHRXtQzZfJm8m5wm1Fzmez/" +
                        "Knlkn1mq8UQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQOEMg+jLVqued06/qsfNLe" +
                        "lf0OFIz2pcoZ7T+p+dRzu7n9x4yeSvzRPkquU5wepxntved66N9OOn5Kpdoxtm6Uf6Vz1f3Ppv/1frIZ" +
                        "bR2lHfV89F+K+/BM1+Cjua+sv+ot+j56t5H80d9r3o+2u+us/jY3yqDZ5/ZUb2qXXe+Sv0dtaMaHc9vM" +
                        "0d5Ki7PYqMaK5/P9h/1Npv/is/qlT2vOFP2YPWOyU+AAIE5gVfv03OZ/14dfQ6M/L1o5t92M7/vVDyiu" +
                        "TO5ds6Z6adql80ZWd2eV2uP2nW+HjJzvZrt+8yjM0X70JU3M2/Uy+PzKF82V9d8md6yPVXi/vTvkn2FT" +
                        "CwBAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgACB6wWiL0B1P18xcXePnV/Qu827s7+ZW" +
                        "tHeRLmj9T89j3J2Pn+sn8lbmSfKV8n1LDaqseJ5R987c6ww6M652iPqt6N+VGPF8x19d9QYff3O1F7h3" +
                        "f05+H2+mZ4zVlH+TI4oJqqx4nnUU+Z51Fcmx+g5j2pXn8/0el9brfkYP1J/pl60tvo6q/ZfrV/N/yp+V" +
                        "+2ozujzyu+gXW6jvc6s6+g9qt9RY/Q9bGXtmdzdZt35KrNdWbvSp1gCBAhcKRC9V+56XjF41lMlx0+x2" +
                        "Vlnfs+818j0umLOU3Nm7WfjZtwzezfSX6anW8yKvXuV91av+pOdf9draJXbqr14+r7kkn31KIonQIAAA" +
                        "QIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgcL1A9gtVs3ErJ53tLbN+tP9M7hNiovmiHqP1z" +
                        "55HeWefj9atzBP1WMkVxUa1up5HfZz4vGv2FXl2eUW9d/YR1ep63tVz1E9XnZ/yrK4d5e963mk001PUR" +
                        "5Q7Wl95HtXqel7p6VVs1M9snSh/1/PZPh/Xz/Q00sdMvcrlgKhOtffufJX6u2tH9SrPv88Zra24ZGKje" +
                        "l3PM71kYqJ+MjlGY66sPdrzbV133935KrNdWbvSp1gCBAhcKRC9V+54Xp2/8jtsV+5Oh2xPK+Y8NWen7" +
                        "6tcGftdvdzrZHp69Ttadv2zuOq8Ub1qvpH4qIfMv88rObL/BpvJ+XJ/XLJfQSsnAQIECBAgQIAAAQIEC" +
                        "BAgQIAAAQIECBAgQIAAAQIECBAgQIAAgfUCI1+Qyq5Z3/0/FbI9VeJm+6/UujI2mjPqLVofPY/yV5/P1" +
                        "ovWPz6PeqvkysRG9WaeZ+qfGjMz94q1VzhFc3T3FNWbeb671+56u98jZqyjtatsorqjFwqivN3zRPVmn" +
                        "u/utaPezLzR2o7+fsoR1R09i6/6Ha35fd2zGlH+qmV3vkr9q2pHdV8937UvGceZOaK1mfqVmN31dn9WV" +
                        "yyysd1m3fmyc9zirqxd6VMsAQIErhSI3itXPx+ZfcXv0pXP8BmTyrwr5jw554xrdm3WP5svGxf9XpLpa" +
                        "8XeRX39VHOm16zXyL+Lqv9eysyxM+fLWi7Zz2yXtQQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIE" +
                        "CBAgAABAgTOEOj4AtUtx5U/HTN09d/Ry44c0bxRD9H67POoTvQ8W+cW15WrK0+l93tsVDv7fKT2aWuys" +
                        "66IO8Uimm1ln1Ht7PNVPUb1V9XtfK/J9hjNmn2erTcTl+3lMS6qF+WM1s88j2pnn8/08GptVL+7blQv+" +
                        "7y7r5/yZXupnMVM3yN1M79nR3kzvT3GdOer1L+yduX3rcxMV88S1c8+z8w6EhPVH8mZXXNl7WyPI+9d1" +
                        "dxXOlxZu+okngABAlcJRO+VK5+Pzvysp9F8I5+HIy7V/lbMeXrOEdef/j01O+dsH5WeMv8Wu52d2Zlm/" +
                        "l0/8m/WTsN7rupraJXbyr34PuOfWi7Zj2y9NQQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAg" +
                        "AABAgTOFah8werUKbIznNr/b+7L3tV2P+uV/UJorbpoAv8IOIvnnIZ32Ytsn+fIxp1kZ/ot78nv4pHtM" +
                        "z4B9Yiodj2jFacJnLTHUS8jl3NO89YPAQIECBD4NIHK53dX7KzhrguuXfOO/vtsxZzvnvPVnjyeq445O" +
                        "/b/+1mf6WtmbfSaq84a5bs/r+bN7m+2/i1uhduKnM9m+lPLJfvKloslQIAAAQIECBAgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIEfoNAdHHlNxiYkQABAgQIEBgXiH6X6Hg+3t3PK" +
                        "3decL11MGMwM/uKOd8l56PbyMXrzjlH9v/Vvo/2Nrqucgazs1ZyXvkaelW7OkPmTM7kfLbWJfsVqnISI" +
                        "ECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECby8wcuno7Yc2A" +
                        "AECBAgQIEDgIoHMJeSLWlP2QWDFhfRo7z9pA1bOGuW+Pffzj4BL9k4DAQIECBAgQIAAAQIECBAgQIAAA" +
                        "QIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgcJzA9wsiuxuMLqjs7kc9AgQIECBAgAABAicIr" +
                        "Lhkf8Jcevh9Ai7Z/749NzEBAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAg" +
                        "AABAgQIEDhe4OpL7lfXP36DNEiAAAECBAgQIPArBVyy/5Xb/pFDu2T/kdtqKAIECBAgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAg8N4CV15yj2rfnvshQIAAAQIECBAgcKrA4" +
                        "++znT26YN+pKdfVAi7ZX70D6hMgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAA" +
                        "QIECBAgQIAAAQL/EbjyovuVtR0FAgQIECBAgAABArMCqy7Dr8o7O6/1BEYEXLIfUbOGAAECBAgQIECAA" +
                        "AECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQWCpw1UX3q+ouxZScAAECBAgQI" +
                        "EDgVwm8+p12FGJFztFerCPQIeCSfYeiHAQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABA" +
                        "gQIECBAgAABAgQIECBAgEC7wO4L75l6txg/BAgQIECAAAECBE4W6L4Q353vZDu9/R4Bl+x/z16blAABA" +
                        "gQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIvJVA9tL77MX3XXXeC" +
                        "l+zBAgQIECAAAECby2Q+R03GrAjR1TDcwJXCbhkf5W8ugQIECBAgAABAgQIECBAgAABAgQIECBAgAABA" +
                        "gQIECBAgAABAgQIECBAgAABAgQIECBAgMBLgcylnp9iMqwrc2fqiyFAgAABAgQIECCwUmD0993KupX9y" +
                        "01gtYBL9quF5SdAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABA" +
                        "gSGBSqXfFbHDg9hIQECBAgQIECAAIELBFb+fnzBOEoSaBVwyb6VUzICBAgQIECAAAECBAgQIECAAAECB" +
                        "AgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECgW2Dl5aBs7u6Z5CNAgAABAgQIECCwQyD7+24lb" +
                        "kffahBYLeCS/Wph+QkQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQI" +
                        "ECAAIEpgcqFnxWxU81bTIAAAQIECBAgQOBigc7fkS8eRXkCbQIu2bdRSkSAAAECBAgQIECAAAECBAgQI" +
                        "ECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAisFOi8HJTNtXIeuQkQIECAAAECBAjsFMj+D" +
                        "vxT3M4+1SKwQ8Al+x3KahAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIEC" +
                        "BAgQIAAAQItAjMXg6prWxqWhAABAgQIECBAgMCBApnfjQ9sW0sE2gRcsm+jlIgAAQIECBAgQIAAAQIEC" +
                        "BAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBDYJZC5FDQas2sGdQgQIECAAAECBAgQI" +
                        "EDgGgGX7K9xV5UAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIEC" +
                        "BBoEBi9SP/TuoZ2pCBAgAABAgQIECBAgACBNxBwyf4NNkmLBAgQIECAAAECBAgQIECAAAECBAgQIECAA" +
                        "AECBAgQIECAAAECBAgQIECAAAECBAgQIECAQCxQvXAfZxRBgAABAgQIECBAgAABAp8o4JL9J+6qmQgQI" +
                        "ECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECB" +
                        "AgQIEDgRwGX7B0MAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIE" +
                        "CBAgAABAgQIECBAgAABAgQIEPg1Ai7Z/5qtNigBAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIE" +
                        "CBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIuGTvDBAgQIAAAQIECBAgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIDArxFwyf7XbLVBCRAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIEC" +
                        "BAgQMAle2eAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQI" +
                        "ECAAAECBAgQIECAAAECBH6NgEv2v2arDUqAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQI" +
                        "ECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECLtk7AwQIECBAgAABAgQIECBAgAABAgQIECBAg" +
                        "AABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECDwawRcsv81W21QAgQIECBAg" +
                        "AABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIE" +
                        "HDJ3hkgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAgV8j4JL9r9lqgxIgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQICAS/bOAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAA" +
                        "AECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAj8GgGX7H/NVhuUAAECBAgQIECAA" +
                        "AECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBFyyd" +
                        "wYIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAg" +
                        "AABAgQIECBA4NcIuGT/a7baoAQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAg" +
                        "AABAgQIECBAgAABAgQIECBAgAABAgQIECDgkr0zQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAA" +
                        "QIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQK/RsAl+1+z1QYlQIAAAQIECBAgQIAAA" +
                        "QIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAZfsnQECB" +
                        "AgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAA" +
                        "AECBAgQ+DUCLtn/mq02KAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAA" +
                        "AECBAgQIECAAAECBAgQIECAAAECBAi4ZO8MECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABA" +
                        "gQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgMCvEXDJ/tdstUEJECBAgAABAgQIECBAgAABA" +
                        "gQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAwCV7Z4AAAQIEC" +
                        "BAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgcLDAny93+A8DZ8AZcAacAWfAGXAGnAFnwBlwBpwBZ" +
                        "8AZcAacAWfAGXAGnAFnwBlwBpwBZ8AZcAacgYczcPD/mVtrBAgQIECAAAECBAgQIECAAAECBAgQIECAA" +
                        "AECBAgQIECAAIExARfr/ZcLOAPOgDPgDDgDzoAz4Aw4A86AM+AMOAPOgDPgDDgDzoAz4Aw4A86AM+AMO" +
                        "APOgDPgDGTOwNj/VdoqAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgMBBApkvSYjxZRpnw" +
                        "BlwBpwBZ8AZcAacAWfAGXAGnAFnwBlwBpwBZ8AZcAacAWfAGXAGnAFnwBlwBpyB2xnwQ4AAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAAQIECBB4ewFfhPFFGGfAGXAGnAFnwBlwBpwBZ8AZcAacAWfAGXAGn" +
                        "AFnwBlwBpwBZ8AZcAacAWfAGXAGnIHKGXj7/0O5AQgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQI" +
                        "ECAAIHfK1D5koRYX6pxBpwBZ8AZcAacAWfAGXAGnAFnwBlwBpwBZ8AZcAacAWfAGXAGnAFnwBlwBpwBZ" +
                        "8AZuJ0BPwQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgACBtxbwJRhfgnEGnAFnwBlwBpwBZ" +
                        "8AZcAacAWfAGXAGnAFnwBlwBpwBZ8AZcAacAWfAGXAGnAFnwBmonIG3/j+Sa54AAQIECBAgQIAAAQIEC" +
                        "BAgQIAAAQIECBAgQIAAAQIECBAgUPmihFhfrHEGnAFnwBlwBpwBZ8AZcAacAWfAGXAGnAFnwBlwBpwBZ" +
                        "8AZcAacAWfAGXAGnAFn4HefAf9XdgIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIDA2wv4A" +
                        "szv/gKM/bf/zoAz4Aw4A86AM+AMOAPOgDPgDDgDzoAz4Aw4A86AM+AMOAPOgDPgDDgDzoAzUDkDb/9/J" +
                        "DcAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQOAmUPnChFhezoAz4Aw4A86AM+AMOAPOg" +
                        "DPgDDgDzoAz4Aw4A86AM+AMOAPOgDPgDDgDzoAz4Az83jPg/8pOgAABAgQIECBAgAABAgQIECBAgAABA" +
                        "gQIECBAgAABAgQIEPgoAV+E+b1fhLH39t4ZcAacAWfAGXAGnAFnwBlwBpwBZ8AZcAacAWfAGXAGnAFnw" +
                        "BlwBpwBZ8AZcAaenYGP+j+MG4YAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIEC" +
                        "BAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAA" +
                        "QIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIEC" +
                        "BAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAA" +
                        "QIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIEC" +
                        "BAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAA" +
                        "QIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIEC" +
                        "BAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAA" +
                        "QIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIEC" +
                        "BAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAA" +
                        "QIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIEC" +
                        "BAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAA" +
                        "QIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQ" +
                        "IAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIEC" +
                        "BAgQIAAAQIECIwI/H+BnzC+KtPU2QAAAABJRU5ErkJgggtAAAEAAAD/////AQAAAAAAAAAMAgAAABtEZ" +
                        "XZFeHByZXNzLlh0cmFSZXBvcnRzLnY2LjIFAQAAACxEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlNlc" +
                        "mlhbGl6YWJsZVN0cmluZwEAAAAFVmFsdWUBAgAAAAYDAAAAnQF7XHJ0ZjFcYW5zaVxhbnNpY3BnMTI1M" +
                        "lxkZWZmMFxkZWZsYW5nMjA1NXtcZm9udHRibHtcZjBcZm5pbFxmY2hhcnNldDAgQXJpYWw7fX0NClx2a" +
                        "WV3a2luZDRcdWMxXHBhcmRcZnMyMCBTYW5kcm8gU3RldHRsZXJccGFyDQpMZWl0ZXIgU296aWFsZSBEa" +
                        "WVuc3RlXHBhcg0KfQ0KC0AAAQAAAP////8BAAAAAAAAAAwCAAAAG0RldkV4cHJlc3MuWHRyYVJlcG9yd" +
                        "HMudjYuMgUBAAAALERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuU2VyaWFsaXphYmxlU3RyaW5nAQAAA" +
                        "AVWYWx1ZQECAAAABgMAAACfAXtccnRmMVxhbnNpXGFuc2ljcGcxMjUyXGRlZmYwXGRlZmxhbmcyMDU1e" +
                        "1xmb250dGJse1xmMFxmbmlsXGZjaGFyc2V0MCBBcmlhbDt9fQ0KXHZpZXdraW5kNFx1YzFccGFyZFxmc" +
                        "zIwIEJyaWdpdHRlIFJ5dGVyXHBhcg0KVGVhbWxlaXRlcmluIFNvemlhbGFyYmVpdFxwYXINCn0NCgs=";
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
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrRichTextBox5 = new DevExpress.XtraReports.UI.XRRichTextBox();
            this.xrRichTextBox4 = new DevExpress.XtraReports.UI.XRRichTextBox();
            this.xrLine6 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrPageBreak1 = new DevExpress.XtraReports.UI.XRPageBreak();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.rtfRechsmittel = new DevExpress.XtraReports.UI.XRRichTextBox();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.ShFpVerfuegungAusschuss_EinAus = new DevExpress.XtraReports.UI.Subreport();
            this.ShFpVerfuegungAusschuss_Personen = new DevExpress.XtraReports.UI.Subreport();
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
            this.Line8 = new DevExpress.XtraReports.UI.XRLine();
            this.Line7 = new DevExpress.XtraReports.UI.XRLine();
            this.Line6 = new DevExpress.XtraReports.UI.XRLine();
            this.Label8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.rtfHinweis = new DevExpress.XtraReports.UI.XRRichTextBox();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel5,
                        this.xrPictureBox1,
                        this.xrRichTextBox5,
                        this.xrRichTextBox4,
                        this.xrLine6,
                        this.xrLine4,
                        this.xrLabel3,
                        this.xrLine5,
                        this.xrLine3,
                        this.xrLine2,
                        this.xrPageBreak1,
                        this.xrLabel2,
                        this.rtfRechsmittel,
                        this.xrLabel1,
                        this.xrLine1,
                        this.ShFpVerfuegungAusschuss_EinAus,
                        this.ShFpVerfuegungAusschuss_Personen,
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
                        this.Line8,
                        this.Line7,
                        this.Line6,
                        this.Label8,
                        this.Label6,
                        this.Label4,
                        this.Label3,
                        this.Label2,
                        this.txtTitle,
                        this.rtfHinweis});
            this.Detail.Dpi = 254F;
            this.Detail.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Detail.Height = 1934;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBackColor = false;
            this.Detail.ParentStyleUsing.UseBorderColor = false;
            this.Detail.ParentStyleUsing.UseBorders = false;
            this.Detail.ParentStyleUsing.UseBorderWidth = false;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel4});
            this.ReportFooter.Dpi = 254F;
            this.ReportFooter.Height = 733;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 254F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.Location = new System.Drawing.Point(0, 1376);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(783, 63);
            this.xrLabel5.Text = "Wohlen, den..................................";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Dpi = 254F;
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.Size = new System.Drawing.Size(1700, 120);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // xrRichTextBox5
            // 
            this.xrRichTextBox5.Dpi = 254F;
            this.xrRichTextBox5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrRichTextBox5.Location = new System.Drawing.Point(1300, 1500);
            this.xrRichTextBox5.Name = "xrRichTextBox5";
            this.xrRichTextBox5.ParentStyleUsing.UseBackColor = false;
            this.xrRichTextBox5.ParentStyleUsing.UseFont = false;
            this.xrRichTextBox5.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichTextBox5.RtfText")));
            this.xrRichTextBox5.Size = new System.Drawing.Size(400, 106);
            // 
            // xrRichTextBox4
            // 
            this.xrRichTextBox4.Dpi = 254F;
            this.xrRichTextBox4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrRichTextBox4.Location = new System.Drawing.Point(850, 1500);
            this.xrRichTextBox4.Name = "xrRichTextBox4";
            this.xrRichTextBox4.ParentStyleUsing.UseBackColor = false;
            this.xrRichTextBox4.ParentStyleUsing.UseFont = false;
            this.xrRichTextBox4.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichTextBox4.RtfText")));
            this.xrRichTextBox4.Size = new System.Drawing.Size(380, 105);
            // 
            // xrLine6
            // 
            this.xrLine6.BorderWidth = 2;
            this.xrLine6.Dpi = 254F;
            this.xrLine6.LineWidth = 5;
            this.xrLine6.Location = new System.Drawing.Point(0, 1900);
            this.xrLine6.Name = "xrLine6";
            this.xrLine6.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine6.Size = new System.Drawing.Size(1700, 5);
            // 
            // xrLine4
            // 
            this.xrLine4.BorderWidth = 2;
            this.xrLine4.Dpi = 254F;
            this.xrLine4.LineWidth = 5;
            this.xrLine4.Location = new System.Drawing.Point(0, 1710);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine4.Size = new System.Drawing.Size(1700, 5);
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(0, 1660);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(579, 50);
            this.xrLabel3.Text = "Rechtsmittelbelehrung";
            // 
            // xrLine5
            // 
            this.xrLine5.BorderWidth = 2;
            this.xrLine5.Dpi = 254F;
            this.xrLine5.LineWidth = 5;
            this.xrLine5.Location = new System.Drawing.Point(0, 1290);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine5.Size = new System.Drawing.Size(1700, 5);
            // 
            // xrLine3
            // 
            this.xrLine3.BorderWidth = 2;
            this.xrLine3.Dpi = 254F;
            this.xrLine3.LineWidth = 5;
            this.xrLine3.Location = new System.Drawing.Point(0, 790);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine3.Size = new System.Drawing.Size(1700, 5);
            // 
            // xrLine2
            // 
            this.xrLine2.BorderWidth = 2;
            this.xrLine2.Dpi = 254F;
            this.xrLine2.LineWidth = 5;
            this.xrLine2.Location = new System.Drawing.Point(0, 440);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine2.Size = new System.Drawing.Size(1700, 5);
            // 
            // xrPageBreak1
            // 
            this.xrPageBreak1.Dpi = 254F;
            this.xrPageBreak1.Location = new System.Drawing.Point(0, 1913);
            this.xrPageBreak1.Name = "xrPageBreak1";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.Location = new System.Drawing.Point(0, 1240);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.ParentStyleUsing.UseBackColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorders = false;
            this.xrLabel2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.ParentStyleUsing.UseForeColor = false;
            this.xrLabel2.Size = new System.Drawing.Size(500, 50);
            this.xrLabel2.Text = "Beschluss";
            // 
            // rtfRechsmittel
            // 
            this.rtfRechsmittel.BorderColor = System.Drawing.Color.Transparent;
            this.rtfRechsmittel.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.rtfRechsmittel.Dpi = 254F;
            this.rtfRechsmittel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfRechsmittel.Location = new System.Drawing.Point(0, 1720);
            this.rtfRechsmittel.Name = "rtfRechsmittel";
            this.rtfRechsmittel.ParentStyleUsing.UseBackColor = false;
            this.rtfRechsmittel.ParentStyleUsing.UseBorderColor = false;
            this.rtfRechsmittel.ParentStyleUsing.UseBorders = false;
            this.rtfRechsmittel.ParentStyleUsing.UseFont = false;
            this.rtfRechsmittel.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("rtfRechsmittel.RtfText")));
            this.rtfRechsmittel.Size = new System.Drawing.Size(1700, 180);
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bemerkung", "")});
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.xrLabel1.Location = new System.Drawing.Point(0, 1130);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(1700, 50);
            this.xrLabel1.Text = "xrLabel1";
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 254F;
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine1.LineWidth = 3;
            this.xrLine1.Location = new System.Drawing.Point(845, 590);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(5, 50);
            // 
            // ShFpVerfuegungAusschuss_EinAus
            // 
            this.ShFpVerfuegungAusschuss_EinAus.Dpi = 254F;
            this.ShFpVerfuegungAusschuss_EinAus.Location = new System.Drawing.Point(0, 505);
            this.ShFpVerfuegungAusschuss_EinAus.Name = "ShFpVerfuegungAusschuss_EinAus";
            // 
            // ShFpVerfuegungAusschuss_Personen
            // 
            this.ShFpVerfuegungAusschuss_Personen.Dpi = 254F;
            this.ShFpVerfuegungAusschuss_Personen.Location = new System.Drawing.Point(0, 260);
            this.ShFpVerfuegungAusschuss_Personen.Name = "ShFpVerfuegungAusschuss_Personen";
            // 
            // txtFehlbetrag
            // 
            this.txtFehlbetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Fehlbetrag", "{0:n2}")});
            this.txtFehlbetrag.Dpi = 254F;
            this.txtFehlbetrag.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtFehlbetrag.ForeColor = System.Drawing.Color.Black;
            this.txtFehlbetrag.Location = new System.Drawing.Point(1460, 645);
            this.txtFehlbetrag.Multiline = true;
            this.txtFehlbetrag.Name = "txtFehlbetrag";
            this.txtFehlbetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtFehlbetrag.ParentStyleUsing.UseBackColor = false;
            this.txtFehlbetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtFehlbetrag.ParentStyleUsing.UseBorders = false;
            this.txtFehlbetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtFehlbetrag.ParentStyleUsing.UseFont = false;
            this.txtFehlbetrag.ParentStyleUsing.UseForeColor = false;
            this.txtFehlbetrag.Size = new System.Drawing.Size(240, 45);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtFehlbetrag.Summary = xrSummary1;
            this.txtFehlbetrag.Text = "Fehlbetrag";
            this.txtFehlbetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label25
            // 
            this.Label25.Dpi = 254F;
            this.Label25.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label25.ForeColor = System.Drawing.Color.Black;
            this.Label25.Location = new System.Drawing.Point(850, 645);
            this.Label25.Name = "Label25";
            this.Label25.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label25.ParentStyleUsing.UseBackColor = false;
            this.Label25.ParentStyleUsing.UseBorderColor = false;
            this.Label25.ParentStyleUsing.UseBorders = false;
            this.Label25.ParentStyleUsing.UseBorderWidth = false;
            this.Label25.ParentStyleUsing.UseFont = false;
            this.Label25.ParentStyleUsing.UseForeColor = false;
            this.Label25.Size = new System.Drawing.Size(600, 45);
            this.Label25.Text = "Fehlbetrag";
            this.Label25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label24
            // 
            this.Label24.Dpi = 254F;
            this.Label24.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label24.ForeColor = System.Drawing.Color.Black;
            this.Label24.Location = new System.Drawing.Point(849, 595);
            this.Label24.Name = "Label24";
            this.Label24.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label24.ParentStyleUsing.UseBackColor = false;
            this.Label24.ParentStyleUsing.UseBorderColor = false;
            this.Label24.ParentStyleUsing.UseBorders = false;
            this.Label24.ParentStyleUsing.UseBorderWidth = false;
            this.Label24.ParentStyleUsing.UseFont = false;
            this.Label24.ParentStyleUsing.UseForeColor = false;
            this.Label24.Size = new System.Drawing.Size(635, 45);
            this.Label24.Text = "Total Ausgaben";
            this.Label24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label23
            // 
            this.Label23.Dpi = 254F;
            this.Label23.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label23.ForeColor = System.Drawing.Color.Black;
            this.Label23.Location = new System.Drawing.Point(0, 595);
            this.Label23.Name = "Label23";
            this.Label23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label23.ParentStyleUsing.UseBackColor = false;
            this.Label23.ParentStyleUsing.UseBorderColor = false;
            this.Label23.ParentStyleUsing.UseBorders = false;
            this.Label23.ParentStyleUsing.UseBorderWidth = false;
            this.Label23.ParentStyleUsing.UseFont = false;
            this.Label23.ParentStyleUsing.UseForeColor = false;
            this.Label23.Size = new System.Drawing.Size(614, 45);
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
            this.txtTotOut.Location = new System.Drawing.Point(1482, 595);
            this.txtTotOut.Multiline = true;
            this.txtTotOut.Name = "txtTotOut";
            this.txtTotOut.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtTotOut.ParentStyleUsing.UseBackColor = false;
            this.txtTotOut.ParentStyleUsing.UseBorderColor = false;
            this.txtTotOut.ParentStyleUsing.UseBorders = false;
            this.txtTotOut.ParentStyleUsing.UseBorderWidth = false;
            this.txtTotOut.ParentStyleUsing.UseFont = false;
            this.txtTotOut.ParentStyleUsing.UseForeColor = false;
            this.txtTotOut.Size = new System.Drawing.Size(219, 45);
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
            this.txtTotIn.Location = new System.Drawing.Point(614, 595);
            this.txtTotIn.Multiline = true;
            this.txtTotIn.Name = "txtTotIn";
            this.txtTotIn.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtTotIn.ParentStyleUsing.UseBackColor = false;
            this.txtTotIn.ParentStyleUsing.UseBorderColor = false;
            this.txtTotIn.ParentStyleUsing.UseBorders = false;
            this.txtTotIn.ParentStyleUsing.UseBorderWidth = false;
            this.txtTotIn.ParentStyleUsing.UseFont = false;
            this.txtTotIn.ParentStyleUsing.UseForeColor = false;
            this.txtTotIn.Size = new System.Drawing.Size(225, 45);
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
            this.Line13.Location = new System.Drawing.Point(0, 640);
            this.Line13.Name = "Line13";
            this.Line13.ParentStyleUsing.UseBackColor = false;
            this.Line13.ParentStyleUsing.UseBorderColor = false;
            this.Line13.ParentStyleUsing.UseBorders = false;
            this.Line13.ParentStyleUsing.UseBorderWidth = false;
            this.Line13.ParentStyleUsing.UseFont = false;
            this.Line13.ParentStyleUsing.UseForeColor = false;
            this.Line13.Size = new System.Drawing.Size(1700, 5);
            // 
            // Line12
            // 
            this.Line12.Dpi = 254F;
            this.Line12.ForeColor = System.Drawing.Color.Black;
            this.Line12.LineWidth = 3;
            this.Line12.Location = new System.Drawing.Point(0, 590);
            this.Line12.Name = "Line12";
            this.Line12.ParentStyleUsing.UseBackColor = false;
            this.Line12.ParentStyleUsing.UseBorderColor = false;
            this.Line12.ParentStyleUsing.UseBorders = false;
            this.Line12.ParentStyleUsing.UseBorderWidth = false;
            this.Line12.ParentStyleUsing.UseFont = false;
            this.Line12.ParentStyleUsing.UseForeColor = false;
            this.Line12.Size = new System.Drawing.Size(1700, 5);
            // 
            // Line11
            // 
            this.Line11.Dpi = 254F;
            this.Line11.ForeColor = System.Drawing.Color.Black;
            this.Line11.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line11.Location = new System.Drawing.Point(845, 440);
            this.Line11.Name = "Line11";
            this.Line11.ParentStyleUsing.UseBackColor = false;
            this.Line11.ParentStyleUsing.UseBorderColor = false;
            this.Line11.ParentStyleUsing.UseBorders = false;
            this.Line11.ParentStyleUsing.UseBorderWidth = false;
            this.Line11.ParentStyleUsing.UseFont = false;
            this.Line11.ParentStyleUsing.UseForeColor = false;
            this.Line11.Size = new System.Drawing.Size(5, 60);
            // 
            // Line10
            // 
            this.Line10.Dpi = 254F;
            this.Line10.ForeColor = System.Drawing.Color.Black;
            this.Line10.Location = new System.Drawing.Point(0, 500);
            this.Line10.Name = "Line10";
            this.Line10.ParentStyleUsing.UseBackColor = false;
            this.Line10.ParentStyleUsing.UseBorderColor = false;
            this.Line10.ParentStyleUsing.UseBorders = false;
            this.Line10.ParentStyleUsing.UseBorderWidth = false;
            this.Line10.ParentStyleUsing.UseFont = false;
            this.Line10.ParentStyleUsing.UseForeColor = false;
            this.Line10.Size = new System.Drawing.Size(1700, 5);
            // 
            // Label12
            // 
            this.Label12.Dpi = 254F;
            this.Label12.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(847, 450);
            this.Label12.Name = "Label12";
            this.Label12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label12.ParentStyleUsing.UseBackColor = false;
            this.Label12.ParentStyleUsing.UseBorderColor = false;
            this.Label12.ParentStyleUsing.UseBorders = false;
            this.Label12.ParentStyleUsing.UseBorderWidth = false;
            this.Label12.ParentStyleUsing.UseFont = false;
            this.Label12.ParentStyleUsing.UseForeColor = false;
            this.Label12.Size = new System.Drawing.Size(637, 50);
            this.Label12.Text = "Ausgaben";
            this.Label12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label11
            // 
            this.Label11.Dpi = 254F;
            this.Label11.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(0, 450);
            this.Label11.Name = "Label11";
            this.Label11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label11.ParentStyleUsing.UseBackColor = false;
            this.Label11.ParentStyleUsing.UseBorderColor = false;
            this.Label11.ParentStyleUsing.UseBorders = false;
            this.Label11.ParentStyleUsing.UseBorderWidth = false;
            this.Label11.ParentStyleUsing.UseFont = false;
            this.Label11.ParentStyleUsing.UseForeColor = false;
            this.Label11.Size = new System.Drawing.Size(614, 50);
            this.Label11.Text = "Einnahmen";
            this.Label11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line8
            // 
            this.Line8.BorderWidth = 2;
            this.Line8.Dpi = 254F;
            this.Line8.ForeColor = System.Drawing.Color.Black;
            this.Line8.LineWidth = 5;
            this.Line8.Location = new System.Drawing.Point(0, 1190);
            this.Line8.Name = "Line8";
            this.Line8.ParentStyleUsing.UseBackColor = false;
            this.Line8.ParentStyleUsing.UseBorderColor = false;
            this.Line8.ParentStyleUsing.UseBorders = false;
            this.Line8.ParentStyleUsing.UseBorderWidth = false;
            this.Line8.ParentStyleUsing.UseFont = false;
            this.Line8.ParentStyleUsing.UseForeColor = false;
            this.Line8.Size = new System.Drawing.Size(1700, 5);
            // 
            // Line7
            // 
            this.Line7.BorderWidth = 2;
            this.Line7.Dpi = 254F;
            this.Line7.ForeColor = System.Drawing.Color.Black;
            this.Line7.LineWidth = 5;
            this.Line7.Location = new System.Drawing.Point(0, 1120);
            this.Line7.Name = "Line7";
            this.Line7.ParentStyleUsing.UseBackColor = false;
            this.Line7.ParentStyleUsing.UseBorderColor = false;
            this.Line7.ParentStyleUsing.UseBorders = false;
            this.Line7.ParentStyleUsing.UseBorderWidth = false;
            this.Line7.ParentStyleUsing.UseFont = false;
            this.Line7.ParentStyleUsing.UseForeColor = false;
            this.Line7.Size = new System.Drawing.Size(1700, 5);
            // 
            // Line6
            // 
            this.Line6.Dpi = 254F;
            this.Line6.ForeColor = System.Drawing.Color.Black;
            this.Line6.LineWidth = 3;
            this.Line6.Location = new System.Drawing.Point(0, 690);
            this.Line6.Name = "Line6";
            this.Line6.ParentStyleUsing.UseBackColor = false;
            this.Line6.ParentStyleUsing.UseBorderColor = false;
            this.Line6.ParentStyleUsing.UseBorders = false;
            this.Line6.ParentStyleUsing.UseBorderWidth = false;
            this.Line6.ParentStyleUsing.UseFont = false;
            this.Line6.ParentStyleUsing.UseForeColor = false;
            this.Line6.Size = new System.Drawing.Size(1700, 5);
            // 
            // Label8
            // 
            this.Label8.Dpi = 254F;
            this.Label8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(850, 1350);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(850, 50);
            this.Label8.Text = "Ausschuss individuelle Sozialhilfe";
            // 
            // Label6
            // 
            this.Label6.Dpi = 254F;
            this.Label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(0, 1300);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(800, 50);
            this.Label6.Text = "Der vorliegende Finanzplan wird genehmigt";
            // 
            // Label4
            // 
            this.Label4.Dpi = 254F;
            this.Label4.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(0, 1070);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(400, 50);
            this.Label4.Text = "Bemerkungen";
            // 
            // Label3
            // 
            this.Label3.Dpi = 254F;
            this.Label3.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(0, 740);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(400, 50);
            this.Label3.Text = "Hinweis";
            // 
            // Label2
            // 
            this.Label2.Dpi = 254F;
            this.Label2.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(0, 390);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(373, 50);
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
            this.txtTitle.Location = new System.Drawing.Point(0, 180);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtTitle.ParentStyleUsing.UseBackColor = false;
            this.txtTitle.ParentStyleUsing.UseBorderColor = false;
            this.txtTitle.ParentStyleUsing.UseBorders = false;
            this.txtTitle.ParentStyleUsing.UseBorderWidth = false;
            this.txtTitle.ParentStyleUsing.UseFont = false;
            this.txtTitle.ParentStyleUsing.UseForeColor = false;
            this.txtTitle.Size = new System.Drawing.Size(1700, 60);
            this.txtTitle.Text = "Title";
            this.txtTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // rtfHinweis
            // 
            this.rtfHinweis.Dpi = 254F;
            this.rtfHinweis.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfHinweis.ForeColor = System.Drawing.Color.Black;
            this.rtfHinweis.Location = new System.Drawing.Point(0, 800);
            this.rtfHinweis.Name = "rtfHinweis";
            this.rtfHinweis.ParentStyleUsing.UseBackColor = false;
            this.rtfHinweis.ParentStyleUsing.UseBorderColor = false;
            this.rtfHinweis.ParentStyleUsing.UseBorders = false;
            this.rtfHinweis.ParentStyleUsing.UseBorderWidth = false;
            this.rtfHinweis.ParentStyleUsing.UseFont = false;
            this.rtfHinweis.ParentStyleUsing.UseForeColor = false;
            this.rtfHinweis.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("rtfHinweis.RtfText")));
            this.rtfHinweis.Size = new System.Drawing.Size(1700, 220);
            // 
            // xrLabel4
            // 
            this.xrLabel4.CanGrow = false;
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Adresse", "")});
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 11F);
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.Location = new System.Drawing.Point(0, 500);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.ParentStyleUsing.UseForeColor = false;
            this.xrLabel4.Size = new System.Drawing.Size(910, 233);
            this.xrLabel4.Text = "Anrede";
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(250, 146, 150, 100);
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
' ,  N'<?xml version="1.0" standalone="yes" ?>
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
</NewDataSet>' ,  N'-- Parameter
DECLARE @GetDate datetime  SET @GetDate = GetDate()
DECLARE @BgFinanzplanID int SET @BgFinanzplanID = {BgFinanzplanID}

DECLARE @BgBudgetID int
SELECT @BgBudgetID = BgBudgetID FROM BgBudget
WHERE BgFinanzplanID = @BgFinanzplanID AND MasterBudget = 1




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



DECLARE @Bemerkung varchar(8000),
        @ItemText     varchar(8000)

DECLARE cBemerkung CURSOR FAST_FORWARD FOR
  SELECT ''- '' + XLC.Text + '' ('' + PRS.Name + IsNull('', '' + PRS.Vorname, '''') + ''): '' + BPO.Bemerkung
  FROM BgPosition             BPO
    INNER JOIN BaPerson      PRS ON PRS.BaPersonID = BPO.BaPersonID
    INNER JOIN BgPositionsart  SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
    INNER JOIN XLOVCode       XLC ON XLC.LOVName = ''BgGruppe'' AND XLC.Code = SPT.BgGruppeCode
  WHERE BPO.BgBudgetID = @BgBudgetID
    AND BPO.BgPositionsartID BETWEEN 39000 AND 39999
    AND NOT (BPO.Bemerkung IS NULL OR BPO.Bemerkung = '''')
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
       Title        = ''Verfügung Sozialhilfe vom '' + convert(varchar, ISNull(SFP.DatumVon, SFP.GeplantVon), 104) + '' bis '' + convert(varchar, IsNull(SFP.DatumBis, SFP.GeplantBis), 104),
       Adresse      = isnull(case PRS.GeschlechtCode when 1 then ''Herr'' when 2 then ''Frau'' end + char(13) + char(10),'''') +
                      isnull(PRS.Vorname+'' '','''') + PRS.Name + char(13) + char(10) +
                      isnull(ADR.Strasse + '' '','''') + isnull(ADR.HausNr,'''') + char(13) + char(10) +
                      isnull(ADR.PLZ + '' '','''') + isnull(ADR.Ort,''''),
       Bemerkung = IsNull(CONVERT(varchar(8000), SFP.Bemerkung) + CHAR(10) + CHAR(13), '''') + IsNull(@Bemerkung, ''''),
       TotIn        = @TotIn,
       TotOut       = @TotOut,
       Fehlbetrag   = isNull(@TotOut,0) - isNull(@TotIn,0)
FROM   BgBudget BBG
       inner join BgFinanzplan  SFP on SFP.BgFinanzplanID = BBG.BgFinanzplanID
       inner join FaLeistung    FAL on FAL.FaLeistungID = SFP.FaLeistungID
       inner join BaPerson     PRS on PRS.BaPersonID = FAL.BaPersonID
       inner join BaAdresse    ADR on ADR.BaAdresseID = (select MAX(BaAdresseID) from BaAdresse where BaPersonID=PRS.BaPersonID and AdresseCode=1 /*wohnsitz*/)
WHERE  FAL.ModulID = 3 and
       BBG.BgBudgetID = @BgBudgetID' ,  N'WhFinanzplan,WhMonatsbudget,WhMasterbudget,CtlBgUebersicht,zude' ,  null , 8)

INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShFpVerfuegungAusschuss_Personen' ,  N'Personen' , 1,  N'<!--
AssemblyName=DevExpress%2EXtraReports%2C%20Version%3D1%2E7%2E10%2E0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4
AssemblyLocation=c:\programme\born informatik ag\kiss30\devexpress.xtrareports.dll
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>254</width>
<height>58</height>
</Bounds>
<Text href="#ref-9"/>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>254</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<DataSource id="ref-14">dataSource</DataSource>
<UseDefaultPrinterSettings>false</UseDefaultPrinterSettings>
<ReportUnit xsi:type="a2:ReportUnit" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TenthsOfAMillimeter</ReportUnit>
<Landscape>false</Landscape>
<PaperKind xsi:type="a5:PaperKind" xmlns:a5="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Printing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">A4</PaperKind>
<PaperName href="#ref-9"/>
<Margins xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>254</x>
<y>254</y>
<width>148</width>
<height>254</height>
</Margins>
<HtmlCompressed>false</HtmlCompressed>
<PageSize xsi:type="a4:Size" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<width>2101</width>
<height>2969</height>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>254</width>
<height>58</height>
</Bounds>
<Text href="#ref-9"/>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>50</Height>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>254</width>
<height>58</height>
</Bounds>
<Text href="#ref-9"/>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>105</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>6</ItemCount>
<Item0 href="#ref-27"/>
<Item1 href="#ref-28"/>
<Item2 href="#ref-29"/>
<Item3 href="#ref-30"/>
<Item4 href="#ref-31"/>
<Item5 href="#ref-32"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-8" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName id="ref-33">DevExpress.XtraReports.UI.ReportFooterBand</Type_X_TypeName>
<Visible>false</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-34">ReportFooter</Name>
<Style_X_Font id="ref-35">Times New Roman, 9.75pt</Style_X_Font>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>254</width>
<height>58</height>
</Bounds>
<Text href="#ref-9"/>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>0</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<PrintAtBottom>false</PrintAtBottom>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-21" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName id="ref-36">DevExpress.XtraReports.UI.XRLabel</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-37">txtHeimatort</Name>
<Style_X_Font id="ref-38">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor id="ref-39">Black</Style_X_ForeColor>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>254</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-40">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-41">Nationalitaet</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-9"/>
<BindingItem0_X_DataSource href="#ref-14"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>1140</x>
<y>5</y>
<width>560</width>
<height>45</height>
</Bounds>
<Text id="ref-42">Heimatort</Text>
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
<Type_X_TypeName href="#ref-36"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-43">txtGebDat</Name>
<Style_X_Font id="ref-44">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-39"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopCenter</Style_X_TextAlignment>
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
<Dpi>254</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName href="#ref-40"/>
<BindingItem0_X_DataMember id="ref-45">Geburtsdatum</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-46">{0:dd.MM.yyyy}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-14"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>760</x>
<y>5</y>
<width>380</width>
<height>45</height>
</Bounds>
<Text id="ref-47">GebDat</Text>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>true</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-48">{0:dd.MM.yyyy}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-23" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-36"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-49">txtName</Name>
<Style_X_Font id="ref-50">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-39"/>
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
<Dpi>254</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName href="#ref-40"/>
<BindingItem0_X_DataMember id="ref-51">Name</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-9"/>
<BindingItem0_X_DataSource href="#ref-14"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>5</y>
<width>760</width>
<height>45</height>
</Bounds>
<Text id="ref-52">Name</Text>
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
<Type_X_TypeName id="ref-53">DevExpress.XtraReports.UI.XRLine</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-54">xrLine2</Name>
<Style_X_Font id="ref-55">Times New Roman, 9.75pt</Style_X_Font>
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
<ParentStyleUsing_X_UseFont>true</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>true</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>true</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>true</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>true</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>true</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>100</y>
<width>1700</width>
<height>5</height>
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
<LineWidth>3</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-28" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-36"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-56">xrLabel4</Name>
<Style_X_Font id="ref-57">Arial, 11.25pt, style=Bold, Italic</Style_X_Font>
<Style_X_ForeColor href="#ref-39"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>762</width>
<height>46</height>
</Bounds>
<Text id="ref-58">Unterstützte Personen</Text>
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
<a1:ObjectStorage id="ref-29" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-53"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-59">xrLine1</Name>
<Style_X_Font id="ref-60">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-39"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>2</Style_X_BorderWidth>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>50</y>
<width>1700</width>
<height>5</height>
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
<LineWidth>5</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-30" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-36"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-61">xrLabel3</Name>
<Style_X_Font id="ref-62">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-39"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>1140</x>
<y>55</y>
<width>560</width>
<height>45</height>
</Bounds>
<Text id="ref-63">Nationalität</Text>
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
<Type_X_TypeName href="#ref-36"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-64">xrLabel2</Name>
<Style_X_Font id="ref-65">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-39"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopCenter</Style_X_TextAlignment>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>760</x>
<y>55</y>
<width>380</width>
<height>45</height>
</Bounds>
<Text id="ref-66">Geburtsdatum</Text>
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
<a1:ObjectStorage id="ref-32" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-36"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-67">xrLabel1</Name>
<Style_X_Font id="ref-68">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-39"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>55</y>
<width>760</width>
<height>45</height>
</Bounds>
<Text id="ref-69">Name</Text>
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
</SOAP-ENV:Envelope>' ,  null ,  N'-- Parameter
DECLARE @BgBudgetID int
DECLARE @BgFinanzplanID int
SET @BgFinanzplanID = {BgFinanzplanID}

SELECT @BgBudgetID = BgBudgetID FROM BgBudget
WHERE BgFinanzplanID = @BgFinanzplanID AND MasterBudget = 1

select Name=PRS.Name + '', '' + PRS.Vorname,
       PRS.Geburtsdatum,
       Nationalitaet = NAT.Text
from   BgBudget BBG
       inner join BgFinanzplan_BaPerson  SPP on SPP.BgFinanzplanID=BBG.BgFinanzplanID
       inner join BaPerson               PRS on PRS.BaPersonID=SPP.BaPersonID
       left  join BaLand                 NAT on NAT.BaLandID=PRS.NationalitaetCode
where  SPP.IstUnterstuetzt=1 and
       BBG.BgBudgetID = @BgBudgetID' ,  null ,  N'ShFpVerfuegungAusschuss' ,  null )

INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShFpVerfuegungAusschuss_EinAus' ,  N'Einnahmen, Ausgaben' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Temp\KiSS4_Migration\KiSS4.DB.dll" />
///     <Reference Path="C:\Temp\KiSS4_Migration\SharpLibrary.dll" />
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
                        "AAAAc0MREVDTEFSRSBAR2V0RGF0ZSBkYXRldGltZSAgU0VUIEBHZXREYXRlID0gR2V0RGF0ZSgpDQpER" +
                        "UNMQVJFIEBCZ0ZpbmFuenBsYW5JRCBpbnQgU0VUIEBCZ0ZpbmFuenBsYW5JRCA9IG51bGwNCkRFQ0xBU" +
                        "kUgQEJnQnVkZ2V0SUQgaW50DQoNClNFTEVDVCBAQmdCdWRnZXRJRCA9IEJnQnVkZ2V0SUQgRlJPTSBCZ" +
                        "0J1ZGdldA0KV0hFUkUgQmdGaW5hbnpwbGFuSUQgPSBAQmdGaW5hbnpwbGFuSUQgQU5EIE1hc3RlckJ1Z" +
                        "GdldCA9IDENCg0KREVDTEFSRSBARWlubmFobWVuIFRBQkxFIChpZCBpbnQgaWRlbnRpdHksIFRleHQgd" +
                        "mFyY2hhcigxMDApLCBCZXRyYWcgbW9uZXkpDQpERUNMQVJFIEBBdXNnYWJlbiAgVEFCTEUgKGlkIGlud" +
                        "CBpZGVudGl0eSwgVGV4dCB2YXJjaGFyKDEwMCksIEJldHJhZyBtb25leSkNCg0KLS0gRWlubmFobWVuD" +
                        "QpJTlNFUlQgSU5UTyBARWlubmFobWVuIChUZXh0LCBCZXRyYWcpDQogIFNFTEVDVCBUTVAuQmV6ZWlja" +
                        "G51bmcsIFRNUC5CZXRyYWcNCiAgRlJPTSBkYm8uZm5XaEdldEZpbmFuenBsYW4oQEJnQnVkZ2V0SUQsI" +
                        "EBHZXREYXRlKSAgVE1QDQogICAgSU5ORVIgSk9JTiBYTE9WQ29kZSAgICAgWFBDIE9OIFhQQy5MT1ZOY" +
                        "W1lID0gJ0JnS2F0ZWdvcmllJyAgICBBTkQgWFBDLkNvZGUgPSBUTVAuQmdLYXRlZ29yaWVDb2RlDQogI" +
                        "FdIRVJFIEJnS2F0ZWdvcmllQ29kZSA9IDENCiAgICBBTkQgKFRNUC5CZXRyYWcgIT0gJDAuMDAgT1IgK" +
                        "EJnS2F0ZWdvcmllQ29kZSA9IDEgQU5EIEJnR3J1cHBlQ29kZSBMSUtFICdbMC05XSUnKSkNCg0KLS0gQ" +
                        "XVzZ2FiZW4gLyBLw7xyenVuZ2VuDQpJTlNFUlQgSU5UTyBAQXVzZ2FiZW4gKFRleHQsIEJldHJhZykNC" +
                        "iAgU0VMRUNUDQogICAgQ0FTRQ0KICAgICAgV0hFTiBUTVAuQmV6ZWljaG51bmcgTElLRSAnTWVkLiBHc" +
                        "nVuZCUoS1ZHKScgVEhFTiAnS1ZHIFByw6RtaWVuJw0KICAgICAgV0hFTiBUTVAuQmV6ZWljaG51bmcgT" +
                        "ElLRSAnTWVkLiBHcnVuZCUoVlZHKScgVEhFTiAnVlZHIFByw6RtaWVuJw0KICAgICAgRUxTRSBUTVAuQ" +
                        "mV6ZWljaG51bmcNCiAgICBFTkQsDQogICAgQ0FTRQ0KICAgICAgV0hFTiBCZ0thdGVnb3JpZUNvZGUgP" +
                        "SAyIFRIRU4gVE1QLkJldHJhZw0KICAgICAgRUxTRSAtVE1QLkJldHJhZw0KICAgIEVORA0KICBGUk9NI" +
                        "GRiby5mbldoR2V0RmluYW56cGxhbihAQmdCdWRnZXRJRCwgQEdldERhdGUpICBUTVANCiAgICBJTk5FU" +
                        "iBKT0lOIFhMT1ZDb2RlICAgICBYUEMgT04gWFBDLkxPVk5hbWUgPSAnQmdLYXRlZ29yaWUnICAgIEFOR" +
                        "CBYUEMuQ29kZSA9IFRNUC5CZ0thdGVnb3JpZUNvZGUNCiAgV0hFUkUgQmdLYXRlZ29yaWVDb2RlIElOI" +
                        "CgyLCA0KSAtLSBBdXNnYWJlbiAvIEvDvHJ6dW5nZW4NCiAgICBBTkQgKFRNUC5CZXRyYWcgIT0gJDAuM" +
                        "DAgT1IgKEJnS2F0ZWdvcmllQ29kZSA9IDIgQU5EIEJnR3J1cHBlQ29kZSBMSUtFICdbMC05XSUnKSkNC" +
                        "g0KU0VMRUNUDQogIFRleHRFaW4gPSBFSU4uVGV4dCwgQmV0cmFnRWluID0gRUlOLkJldHJhZywNCiAgV" +
                        "GV4dEF1cyA9IEFVUy5UZXh0LCBCZXRyYWdBdXMgPSBBVVMuQmV0cmFnDQpGUk9NIEBFaW5uYWhtZW4gI" +
                        "CAgICAgICBFSU4NCiAgRlVMTCAgSk9JTiBAQXVzZ2FiZW4gIEFVUyBPTiBBVVMuaWQgPSBFSU4uaWQ=";
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
            this.Detail.Dpi = 254F;
            this.Detail.Height = 50;
            this.Detail.Name = "Detail";
            this.Detail.Scripts.OnBeforePrint = "private void OnBeforePrint(object sender, System.Drawing.Printing.PrintEventArgs " +
                "e) {\r\n  xrLine1.Height = Detail.Height;\r\n}";
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 254F;
            this.xrLine1.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine1.LineWidth = 3;
            this.xrLine1.Location = new System.Drawing.Point(845, 0);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(5, 50);
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragAus", "{0:n2}")});
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel4.Location = new System.Drawing.Point(1482, 5);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(219, 45);
            this.xrLabel4.Text = "xrLabel2";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TextAus", "")});
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel3.Location = new System.Drawing.Point(849, 5);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(635, 45);
            this.xrLabel3.Text = "xrLabel1";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragEin", "{0:n2}")});
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel2.Location = new System.Drawing.Point(614, 5);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(225, 45);
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TextEin", "")});
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel1.Location = new System.Drawing.Point(0, 5);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(614, 45);
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            this.Margins = new System.Drawing.Printing.Margins(254, 204, 254, 254);
            this.Name = "Report";
            this.PageHeight = 2794;
            this.PageWidth = 2159;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'DECLARE @GetDate datetime  SET @GetDate = GetDate()
DECLARE @BgFinanzplanID int SET @BgFinanzplanID = {BgFinanzplanID}
DECLARE @BgBudgetID int

SELECT @BgBudgetID = BgBudgetID FROM BgBudget
WHERE BgFinanzplanID = @BgFinanzplanID AND MasterBudget = 1

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
  FULL  JOIN @Ausgaben  AUS ON AUS.id = EIN.id' ,  null ,  N'ShFpVerfuegungAusschuss' ,  null )

