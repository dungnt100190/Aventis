insert [XQuery]([QueryName], [UserText], [QueryCode], [LayoutXML], [ParameterXML], [SQLquery], [ContextForms], [ParentReportName], [ReportSortKey], [RelationColumnName])
values ( N'AKassenbeleg' ,  N'A - Kassenbeleg' , 1,  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>de-DE</Localization>
///   <References>
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Drawing\2.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System\2.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Configuration\2.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Xml\2.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Data.SqlXml\2.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Security\2.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.Utils.v6.2.dll" />
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
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.Data.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\KiSS4.DB.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\log4net.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\SharpLibrary.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel Label16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCode1;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel FullName1;
        private DevExpress.XtraReports.UI.XRLabel Label14;
        private DevExpress.XtraReports.UI.XRLabel Label9;
        private DevExpress.XtraReports.UI.XRLabel txtVerfalldatum;
        private DevExpress.XtraReports.UI.XRLabel txtNameYearMonth;
        private DevExpress.XtraReports.UI.XRLabel txtFullName;
        private DevExpress.XtraReports.UI.XRLabel txtFlBelegID;
        private DevExpress.XtraReports.UI.XRLabel Label8;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.XRControl Shape1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRRichText xrRichText1;
        private DevExpress.XtraReports.UI.XRControl xrControl1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel24;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel txtIntern;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel23;
        private DevExpress.XtraReports.UI.XRLine Line6;
        private DevExpress.XtraReports.UI.XRLine Line4;
        private DevExpress.XtraReports.UI.XRLabel Label19;
        private DevExpress.XtraReports.UI.XRLabel Betrag1;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAADAAAAAgAAAGhTeXN0ZW0uRHJhd" +
                        "2luZy5CaXRtYXAsIFN5c3RlbS5EcmF3aW5nLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhb" +
                        "CwgUHVibGljS2V5VG9rZW49YjAzZjVmN2YxMWQ1MGEzYYwBRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VS" +
                        "S5TZXJpYWxpemFibGVTdHJpbmcsIERldkV4cHJlc3MuWHRyYVJlcG9ydHMudjYuMiwgVmVyc2lvbj02L" +
                        "jIuNi4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPTc5ODY4YjgxNDdiNWVhZTQTtE6kg" +
                        "G2btk4GIBoAAAAAYgAAADcAAABJAgAAMnMAcQBsAFEAdQBlAHIAeQAxAC4AUwBlAGwAZQBjAHQAUwB0A" +
                        "GEAdABlAG0AZQBuAHQAAAAAACZ4AHIAUABpAGMAdAB1AHIAZQBCAG8AeAAxAC4ASQBtAGEAZwBlAKENA" +
                        "AAmeAByAFIAaQBjAGgAVABlAHgAdAAxAC4AUgB0AGYAVABlAHgAdACgIQAAAZ4bZGVjbGFyZSBAS2JCd" +
                        "WNodW5nSUQgaW50DQpkZWNsYXJlIEBLYXNzZVVzZXJJRCBpbnQNCmRlY2xhcmUgQEJldHJhZ1RleHQgd" +
                        "mFyY2hhcigyMCkNCmRlY2xhcmUgQEluV29ydGVuIHZhcmNoYXIoMjAwKQ0KZGVjbGFyZSBAVmFsdXRhI" +
                        "GRhdGV0aW1lDQoNCnNldCBAS2JCdWNodW5nSUQgPSBudWxsIC0tIDg4Mg0Kc2V0IEBLYXNzZVVzZXJJR" +
                        "CA9IG51bGwgLS0gMQ0KDQpzZWxlY3QgQEJldHJhZ1RleHQgPSBjb252ZXJ0KHZhcmNoYXIsIEJldHJhZ" +
                        "ywgMSksDQogICAgICAgQFZhbHV0YSAgICAgPSBjb252ZXJ0KGRhdGV0aW1lLGRiby5mbk1BWChWYWx1d" +
                        "GFEYXR1bSxnZXRkYXRlKCkpKQ0KZnJvbSAgIEtiQnVjaHVuZw0Kd2hlcmUgIEtiQnVjaHVuZ0lEID0gQ" +
                        "EtiQnVjaHVuZ0lEDQoNCnNldCBASW5Xb3J0ZW4gPSAnJw0Kd2hpbGUgbGVuKEBCZXRyYWdUZXh0KSA+I" +
                        "DAgYmVnaW4NCiAgaWYgbGVmdChAQmV0cmFnVGV4dCwxKSA8PiAnLicgYW5kIA0KICAgICBASW5Xb3J0Z" +
                        "W4gPD4gJycgYW5kIA0KICAgICByaWdodChASW5Xb3J0ZW4sMSkgbm90IGluICgnLicsJy0nKSANCiAgY" +
                        "mVnaW4NCiAgICBzZXQgQEluV29ydGVuID0gQEluV29ydGVuICsgJy0nDQogIGVuZA0KDQogIHNldCBAS" +
                        "W5Xb3J0ZW4gPSBASW5Xb3J0ZW4gKw0KICAgIGNhc2UgbGVmdChAQmV0cmFnVGV4dCwxKQ0KICAgIHdoZ" +
                        "W4gJy4nIHRoZW4gJy4nDQogICAgd2hlbiAnMCcgdGhlbiAnTnVsbCcNCiAgICB3aGVuICcxJyB0aGVuI" +
                        "CdFaW5zJw0KICAgIHdoZW4gJzInIHRoZW4gJ1p3ZWknDQogICAgd2hlbiAnMycgdGhlbiAnRHJlaScNC" +
                        "iAgICB3aGVuICc0JyB0aGVuICdWaWVyJw0KICAgIHdoZW4gJzUnIHRoZW4gJ0bDvG5mJw0KICAgIHdoZ" +
                        "W4gJzYnIHRoZW4gJ1NlY2hzJw0KICAgIHdoZW4gJzcnIHRoZW4gJ1NpZWJlbicNCiAgICB3aGVuICc4J" +
                        "yB0aGVuICdBY2h0Jw0KICAgIHdoZW4gJzknIHRoZW4gJ05ldW4nDQogICAgZWxzZSAnJw0KICAgIGVuZ" +
                        "A0KDQogIHNldCBAQmV0cmFnVGV4dCA9IHN1YnN0cmluZyhAQmV0cmFnVGV4dCwyLDIwMCkNCmVuZA0Kc" +
                        "2V0IEBJbldvcnRlbiA9ICcqJyArIEBJbldvcnRlbiArICcqJw0KDQpzZWxlY3QgDQogIElrUG9zaXRpb" +
                        "25JRCA9IEJVQy5Ja1Bvc2l0aW9uSUQsDQogIEJhcmNvZGV0ZXh0ID0gY29udmVydCh2YXJjaGFyKDIwK" +
                        "Sxjb252ZXJ0KGJpZ2ludCxCVUMuQmVsZWdOcikpLA0KICBLbGllbnQgPSBQUlMuTmFtZVZvcm5hbWUsD" +
                        "QogIFBlcnNvbmVuTnIgPSBQUlMuQmFQZXJzb25JRCwNCiAgR3VlbHRpZ0FiID0gY29udmVydCh2YXJja" +
                        "GFyLEBWYWx1dGEsMTA0KSwNCiAgR3VlbHRpZ0JpcyA9IGNvbnZlcnQodmFyY2hhciwgZGF0ZWFkZChkY" +
                        "XksIGNhc2UgZGF0ZXBhcnQod2Vla2RheSwgQFZhbHV0YSkNCiAgICB3aGVuIDEgdGhlbiAyIC0tIFNvD" +
                        "QogICAgd2hlbiAyIHRoZW4gMiAtLSBNbw0KICAgIHdoZW4gMyB0aGVuIDIgLS0gRGkNCiAgICB3aGVuI" +
                        "DQgdGhlbiAyIC0tIE1pIA0KICAgIHdoZW4gNSB0aGVuIDQgLS0gRG8NCiAgICB3aGVuIDYgdGhlbiA0I" +
                        "C0tIEZyDQogICAgd2hlbiA3IHRoZW4gMyAtLSBTYQ0KICBlbmQsIEBWYWx1dGEpLDEwNCksDQogIEF1c" +
                        "3phaGx1bmdBbiA9IA0KICAgIElzTnVsbChCVUMuQmVndWVuc3RpZ3ROYW1lICsgQ0hBUigxMykgKyBDS" +
                        "EFSKDEwKSwnJykgKw0KICAgIElzTnVsbChCVUMuQmVndWVuc3RpZ3ROYW1lMiArIGNoYXIoMTMpICsgY" +
                        "2hhcigxMCksJycpICsNCiAgICBJc051bGwoQlVDLkJlZ3VlbnN0aWd0UG9zdGZhY2ggKyBjaGFyKDEzK" +
                        "SArIGNoYXIoMTApLCAnJykgKw0KICAgIElzTnVsbChCVUMuQmVndWVuc3RpZ3RTdHJhc3NlICsgSXNOd" +
                        "WxsKCcgJyArIEJVQy5CZWd1ZW5zdGlndEhhdXNOciwgJycpICsgY2hhcigxMykgKyBjaGFyKDEwKSwgJ" +
                        "ycpICsNCiAgICBJc051bGwoSXNOdWxsKEJVQy5CZWd1ZW5zdGlndFBMWiArICcgJywgJycpICsgSXNOd" +
                        "WxsKEJVQy5CZWd1ZW5zdGlndE9ydCwgJycpLCcnKSwNCiAgS29udG8gPSBCVUMuU29sbEt0b05yLA0KI" +
                        "CBMQSA9IEtPQS5Lb250b05yLA0KICBUZXh0ID0gY2FzZSBMU1QuRmFQcm96ZXNzQ29kZSANCiAgICB3a" +
                        "GVuIDQwNSB0aGVuICdBbGltZW50ZW5iZXZvcnNjaHVzc3VuZycNCiAgICB3aGVuIDQwNiB0aGVuICfDn" +
                        "GJlcmJyw7xja3VuZ3NoaWxmZScNCiAgICB3aGVuIDQwNyB0aGVuICdLbGVpbmtpbmRlcmJldHJldXVuZ" +
                        "3NiZWl0csOkZ2UnDQogICAgZWxzZSAnW3VuZGVmaW5pZXJ0XScNCiAgZW5kLA0KICBNb25hdCA9IGRib" +
                        "y5mblhNb25hdChQT1MuTW9uYXQpICsgJyAnICsgY29udmVydCh2YXJjaGFyLFBPUy5KYWhyKSwNCiAgQ" +
                        "mV0cmFnID0gQlVLLkJldHJhZywNCiAgVmVyd1BlcmlvZGUgPSBjb252ZXJ0KHZhcmNoYXIsQlVLLlZlc" +
                        "ndQZXJpb2RlVm9uLDEwNCkgKyBpc251bGwoJyAtICcgKyBjb252ZXJ0KHZhcmNoYXIsQlVLLlZlcndQZ" +
                        "XJpb2RlQmlzLDEwNCksJycpLA0KICBpbldvcnRlbiA9IEBJbldvcnRlbiwNCiAgRXJzdGVsbGRhdHVtI" +
                        "D0gY29udmVydCh2YXJjaGFyLGdldGRhdGUoKSwxMDQpLA0KICBPcmdhbmlzYXRpb25zZWluaGVpdCA9I" +
                        "GlzTnVsbChVU1IuU296aWFsemVudHJ1bSArICcsICcsJycpICsgVVNSLk9yZ1VuaXQsIA0KICBCZWxlZ" +
                        "2Vyc3RlbGxlciA9IEtVU1IuTmFtZVZvcm5hbWUgKyBpc051bGwoJyAoJyArIEtVU1IuUGhvbmUgKyAnK" +
                        "ScsJycpLA0KICBTb3ppYWxhcmJlaXRlciA9IFVTUi5OYW1lVm9ybmFtZSArIGlzTnVsbCgnICgnICsgV" +
                        "VNSLlBob25lICsgJyknLCcnKQ0KZnJvbSBLYkJ1Y2h1bmcgQlVDDQogIGxlZnQgam9pbiBLYkJ1Y2h1b" +
                        "mdLb3N0ZW5hcnQgQlVLIG9uIEJVSy5LYkJ1Y2h1bmdJRCA9IEJVQy5LYkJ1Y2h1bmdJRA0KICBsZWZ0I" +
                        "GpvaW4gQmdLb3N0ZW5hcnQgS09BIG9uIEtPQS5CZ0tvc3RlbmFydElEID0gQlVLLkJnS29zdGVuYXJ0S" +
                        "UQNCiAgbGVmdCBqb2luIElrUG9zaXRpb24gUE9TIG9uIFBPUy5Ja1Bvc2l0aW9uSUQgPSBCVUMuSWtQb" +
                        "3NpdGlvbklEDQogIGxlZnQgam9pbiBJa1JlY2h0c3RpdGVsIFJUIG9uIFJULklrUmVjaHRzdGl0ZWxJR" +
                        "CA9IFBPUy5Ja1JlY2h0c3RpdGVsSUQNCiAgbGVmdCBqb2luIEZhTGVpc3R1bmcgTFNUIG9uIExTVC5GY" +
                        "UxlaXN0dW5nSUQgPSBDQVNFIA0KICAgIFdIRU4gUE9TLkZhTGVpc3R1bmdJRCBJUyBOVUxMIFRIRU4gU" +
                        "lQuRmFMZWlzdHVuZ0lEDQogICAgRUxTRSBQT1MuRmFMZWlzdHVuZ0lEDQogIEVORA0KICBsZWZ0IGpva" +
                        "W4gRmFGYWxsIEZBTCBvbiBGQUwuRmFGYWxsSUQgPSBMU1QuRmFGYWxsSUQNCiAgbGVmdCBqb2luIHZ3U" +
                        "GVyc29uIFBSUyAgb24gUFJTLkJhUGVyc29uSUQgPSBGQUwuQmFQZXJzb25JRA0KICBsZWZ0IGpvaW4gd" +
                        "ndVc2VyIFVTUiAgb24gVVNSLlVzZXJJRCA9IExTVC5Vc2VySWQNCiAgbGVmdCAgam9pbiB2d1VzZXIgS" +
                        "1VTUiBvbiBLVVNSLlVzZXJJRCA9IEBLYXNzZVVzZXJJRA0Kd2hlcmUgIEJVQy5LYkJ1Y2h1bmdJRCA9I" +
                        "EBLYkJ1Y2h1bmdJRCANCm9yZGVyIGJ5IEtPQS5Lb250b05yLCBCVUMuSWtQb3NpdGlvbklEQAABAAAA/" +
                        "////wEAAAAAAAAADAIAAABRU3lzdGVtLkRyYXdpbmcsIFZlcnNpb249Mi4wLjAuMCwgQ3VsdHVyZT1uZ" +
                        "XV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iMDNmNWY3ZjExZDUwYTNhBQEAAAAVU3lzdGVtLkRyYXdpbmcuQ" +
                        "ml0bWFwAQAAAAREYXRhBwICAAAACQMAAAAPAwAAAFwTAAAC/9j/4AAQSkZJRgABAAEAYABgAAD//gAfT" +
                        "EVBRCBUZWNobm9sb2dpZXMgSW5jLiBWMS4wMQD/2wBDAAgGBgcGBQgHBwcKCQgKDRYODQwMDRsTFBAWI" +
                        "BwiIR8cHx4jKDMrIyYwJh4fLD0tMDU2OTo5Iis/Qz44QzM4OTf/2wBDAQkKCg0LDRoODho3JB8kNzc3N" +
                        "zc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzf/wAARCAAyANsDAREAA" +
                        "hEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9A" +
                        "QIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFR" +
                        "kdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t" +
                        "7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAA" +
                        "AAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRo" +
                        "bHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0d" +
                        "XZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4" +
                        "uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2zXPEGmeHLH7XqdyIoydqKFLPI2M7VUcseO1AG" +
                        "J4V+IujeL7xbXTob2ORoDcD7RDsBQNt9T3P86ALeueOvD+gN5dzeiacOUaC1HnSIQpY7lXleAetAGQ3x" +
                        "a8NpuDR6kNuc5sZOMZz2/2W/I0AL/wtnw3nAj1Inn/lxk7Z9vY/lQBv6H4r0XxDEjaffRmZt3+juwWZd" +
                        "rFTlDyOQe1AGFrPxU0DQtYl0y7g1BpYZ0gd4rbeoZhkdDk8eg9cZoA63TdSstX0+G/0+5S4tZhlJEOQf" +
                        "8+lAFqgDhfEfxd8J+GdUk0y5uJ7m8iOJY7WLf5Z9GPAz7UAbnh7xloPijR5dU0q/WW2gz524FWiwM/MD" +
                        "yOKAL+j63puv2AvtJvI7u1LFRJGeMjqKAL9ABQBhN4u0hPGC+FjM/8AarQ+cI/LO3bjP3unagC3p3iDS" +
                        "dWvb2z0+/iuLmxfZcRoeY2yRg/kfyoAdres2Xh7RrnVtRdktLZQ0jKpYgZA6D3NAHCf8L48B/8AP/c/+" +
                        "Ar/AOFAHQ/8LE8O/wDCGDxX9ol/skvsD+S27O7b93r1oAuab4x0bVtfm0S0mka+ht1uWVomUbGCkHJ4z" +
                        "8w4oA3qAMOz8W6TfeKb3w5byyHUrJBJMhjIUDjo3Q/eFAG5QBhap4u0jRvEGmaJeTOl9qRxbqsZIbnHJ" +
                        "HSgDdoAKACgAoA4vV2t4PihpUmqELaT6fJb2TOcKtwWBcZ7MyYA9cECgDm9Q8Dv4NMPiBZH1mx0yICS1" +
                        "2+VKIUOVYMpAkKDPDDkUAcQNCnkl07WLeBYv7Nu8XU0Ibc8lwWkdWkQFiI1ZFJ55YigDUi05o5bdjrO4" +
                        "RXUlwRuvRkOG+X/AFfH3jz3oALSwe1ayc6yXNq0zH570b95J/558Yz+NAGZpFg3hKDT9Q1HTzNMG/tXA" +
                        "TZcTxSqYpItxwSVZkbaeob1FAHoegfDea3uotV1K9W0H2iO8axiG8R+XkxxmZyWIUkk9BmgDY8CNDPqH" +
                        "ie804D+x7jUN1sy/cdgiiV09i4PI6kE0AdnQB4PDo3jTwF4s1zWPDGn2XiPTdRnMkmxw0qZYtt4OQeT0" +
                        "yDxQAeF7vRfEGjeLoNAtLrwp4haMzX0eTKGVclgqtgKMkgjAxnigCz8FLfVrL4aX+q22rRlMTLb2l0Ak" +
                        "EMg58xn649aAOZ1rxvrWjaQmqW3xGbVNaWcebaWtvvtFUk8bioHp+f40Adp4h8UeJPE3jbQ/CGh6l/Y/" +
                        "n2KXt3com5uV3bVz6D+ftQBiabpet2n7QC6fqesfa7z+y5EhvxEFfaUbaxXpuBz9cUAP+Emj6qvxH8Us" +
                        "fEExWyvMXSmJcXpy4y393nnigD3WdIZIHW4VGhx8wkAK4980AfP2ut/wt/xsvhvw3bw2vh3T3D3d7HCo" +
                        "8wjjIOPqFHfqfYA6vx7d3PgeXwPofh2X7Fp0t2IJYlUESJuTrkdeTz70AXfFniHVdN+MfhPR7O7MVhex" +
                        "k3EQUYkwW6nGewoA5jT9S8f+MPG3ivQdM8RLp9lY3bfv2jDPGochUXHrg5PtQBtWfjLU7P4qeMLa8umm" +
                        "0vSdONwkG0DBVUJ5xnnn86AMrQk+JPjTww/i+w8UfZbmWRjaaasSiEqrYwSfoeuf8ACn8QD4guvHvw8E" +
                        "gt7LX3jKsT+8jik3AFsdx3xQBteHtV8U+G/jJH4S1jX31mzvbUzpJLGFKHDHgDpypGOnIoA9hoAKACgD" +
                        "zn4g6jfahqN14atYNNa3t9LbU7k36M4kUMVCrgjaRtJ3dRxigDjpfE+sR6JLaHUruHSIIrZhfyASyWzT" +
                        "xZEEynmVAGA3D5hkHnFAHPTS6xodt4etNP/ALWt7KK32lbCd2i1SbfuYxyRnqyEkEjjbg9KAPVPDuiaP" +
                        "4n0tb6w8S+JRg7JYZNUlWSFx1R1zwRQBr/8IDb/APQxeI//AAay/wCNAHkmsb7pb9zeX32DT9WSew1nU" +
                        "pGkjjWMBXVcndKzOpGwDnA9KANDU/EGsalpRsb+Wc2Itre4tY7qQA6gs02wSTlD8qAnPlr2IBNAHpXgj" +
                        "VL2SfV/D+oR2fn6LJHEJLKPy4nRk3KAv8JHQj6UAddQB5Evw18X+E9a1C68Da9aQWN/J5j2t5HkIcnpw" +
                        "c4/CgDX8HfDW60ebXNU13Vhfa1rMTRTTRJtSNT1wO/b06CgDL8O/C3xBpng/WfCV9rlrJpN3EwtzDEQ6" +
                        "SEg7mz246Z70AZtx8K/G2o+CYvClzrOj2+nWpUx+RA++Yg8b2/EngcnrQBveIPhxrMmpaF4h8O6pb2ev" +
                        "abaJbS+apMUyhcfXufwx0xQAnh/4d+JLX4kQ+MNd1u0vZjbtHLHFEU2kqQAvsOP1oAn0LwD4g8OfETU9" +
                        "asdYtTo+qTma5t3jPmEckAHpwW6+lAHR+PNA1LxN4Ru9H0q/WxnuCqtK2cFM/MvHPI4oA820D4WfETwv" +
                        "YNZaN4u0+0gZy7KsBJLccklcnpQBs+Ifht4n8ReFdIS98QwS+ItLumnjuihCMCQQOBwRgc4oAS3+HXiy" +
                        "+8c6H4p8Qa9ZXM9hw8MMRRVXnAXjk8kknFAG94M8D3nhnxb4o1i4u4ZotXn82JIwQyDcxwc/wC8OnpQB" +
                        "BZ/DyZPiH4i1+8uYZdP1e0NsbdQQ4BCg5PT+E0Ac3B8M/HOlaPceF9I8U2kfh+ZyVkeJhcRoTkqCP8AH" +
                        "8qANy9+Gdw3iLwde2moK1r4fQLJ9o3NLNzknPqeaAL954HvLj4uWHjFbuBbS2tTA0BB3kkOM+n8Q/KgD" +
                        "uKACgAoA8q+NEFpJY2Atbh08RTk21tbwuFe5hcgSxn/AGcc57GgDlNA8Qw/a7TUbqzZtOguTq18iyLug" +
                        "Mh8m3JU8ssaLk46ZB7UAanxM8K6ZpniLQrjTbE7L17gyW8ccs0e8KCHWKNgQ3XJXHvQBhaeNa8MaoNY8" +
                        "P6fdxzKNs1lFpF0iXgz0YuzYbrhqAPb/DHiew8U6X9rs98csbeXcW0o2y28g6o69j/OgDifCemaFYw+I" +
                        "vF+oQBhaajeyQlyWSCNWOfLTO0E4PI5NAHnesXV0tounQ6XItyvmW1rZ+apkS3uh5kCsRwGSRBweQMUA" +
                        "eu/CptMm8Gx3VlfG9vbl/N1GZzmQ3JALhvTHAA9AKAO3oA5U+KtSv7u7TQNB/tC2tJmgkuJbpYFeReGV" +
                        "OCWweMnAyKANLw94hg1+3uCLeW0u7SUw3VrNjfC+AcHHBBBBBHBBoA2KACgCpd3c1tdWUUVlJOlxIUkk" +
                        "QjEI2k7m9sgD8aALdAGZfazHY63pOmNCzvqLShXBGE2JuOfrQBp0AFAHL3vinUV8R3mjaXoD372kUcss" +
                        "n2pIgN+cAA9fumgCfTPFX2nVl0jVNMuNK1GRC8McxV0nUfe2OpIJHccH2oA1rC7muxcmayktfKneJBIQ" +
                        "fMUHhxjse1AFugAoAKAGSyLDE8jZ2opY49BQBW0rUrfWNJtdStd32e6jWWPeMHaRkZFAFygAoA474jxW" +
                        "Vv4YudVNnBJqsUZtrGZ1BeOSYiMbT2+9n8KAOFnFs93a3s1oh8GWlo/h8Xa8MNwCNOfWPcuzPY80AV/E" +
                        "t0dW+HGkzXMsM2o+GrsQanEwLlEXMTSFFYMQflbqOtAGSumh1DJppZSMgjQrzBH/f6gCA3F94OuD4k01" +
                        "ZbF7ZP38Q0eeGK6XI+SRndsex7GgDrJJ4rbwPoXhvU54re41Cd9R1WNnGbe23tcOHHUZyqc9cmgDPu57" +
                        "9dH1me508WUWvTNq+js/wDrFmiKuI3PZnRAwHuwoA9d8N2+kx6PFeaPZwW1vqAF2RCgUOzgHccd6ANeg" +
                        "DhtP0nVLZJ7/wAF67ZTaXeTyTi0vIS8auzHfskUhgN2eCDg5oApah4rv49D1+2ewi0nxFbvbxTSxEOhW" +
                        "ZgiTK2ATgbuD0IoAm8S+GLHwv4Zutc0eSe31TTo/PFy9w7tPt5ZZMnDBhkH68YoAl8X2ekSNbzLp0l3r" +
                        "+pgJawfaZUGQvLuFYAIo5Jx7dTQBC+jv4Xk8D6VFe3E2NQk8+V5GJlYwSk5yemeg7YFAFSW00nWb3VZT" +
                        "Yar4iuWnkVbqEmGK3wcCONy4A245Zc85oATQr+61P8A4VreXsrS3MsVwZHY5LHySMn1PFAGbpD2/iPTH" +
                        "1bVvD+v31/dySMl1bMAsChyEWLEg2hQB2yTnNAHovhKbVJvC1g2tRPHqIQrMJMBiQSAxwSMkAE/WgDK0" +
                        "f8A5Kh4m/69LT+T0AHjfb/aPhMR/wDH1/bEfl467dj+Z+G3NAHLXmr30OiXtrFJev8AbvFE1m5tWzMIs" +
                        "sxWMkjBITHXjJoAvWED6f4g0qXw94a1nTommEV8twR5LwkH5jmQ/MpwQQMnnNAD/Cvhax8RaPqFxrMlx" +
                        "eSNf3SQlp3H2dRKwATB4PGc9aAK0KaxrvgfwtdSxz6tbQl/7QtY5/LlulXKK2cjdggEqSMmgC3pFpod5" +
                        "Dr+l2/9oWkDW6ySaPdh42hIz+8Q5ztYgfdOMrQBlWwOg/CTw9HpSXaS6u9tDO1s5abDDL+XuOFYhSBjG" +
                        "M0AX7S3aw1vSpvDvhnWtO/0hYrz7QR5MkByCWzIcsDgg9evrQB6XQBh+KvDzeI9Lit4rw2lxb3EdzBLs" +
                        "DqJEORuU8MPagCLQPCdrpHhQ6DdSfb4ZfMM/mIFV/MJLAKOFXk4A6UAY/hz4cR6JrbXtzqRvoY7V7OCJ" +
                        "4FU+UxBIlYf60gAAZ7CgDKuvg3p0N5LPo80McMhz9lvYWnjj/3CHVlHtk0AWdE+Eek2WrRanqbpeTQkN" +
                        "FbxReVbow6HYSSxHufwoAsXHwygu/E91f3GoeZpl3crdz2ZgXfJIAAFMvUx5UHZ04oA2PF3hWXxGmny2" +
                        "uofYbuwlaSJ2hEqHchQ5Q8E4PB7GgDT0DR4vD/h+x0iGV5Y7SJYg8n3mx3NAGlQByaeEL7TLm4bw/4gl" +
                        "021uJGla0e3SeNHY5YpnBUE5OM4yaAJrTwVYrpuqW+pXE2pXGqgC8uZiFZwBhQoXAQL2A6HmgCB/B19e" +
                        "xQ2WseI7jUNLiZWNu0KI0205USOOWGQM4AzjmgAuPCGot4lvdbtPEk1vPcosYU2scgijH8ClhwM8n1NA" +
                        "F0eG7i4l0mfUtWlvLjTbprhJPJSPfmNk2kLxgbic0AUbfwbeWSTWNl4huLfR5ZXk+yrCpdA5LMiy9QCS" +
                        "e2Rng0AS6R4Jh0hdDjW/mlj0Zpvs6uqj5HUqFJHXaD170AM/wCEQv7JrqDRfEU+nafcyNIbcQJIYmY5b" +
                        "y2P3QSScc4J4oA6DStMtdF0q202zUrb26BE3HJPuT3JPJNAGHe+FL6TxHd6zpniCfTpLuKOKWNbeORTs" +
                        "zg/MOOpoAn0vwqlnqq6tqOo3Wq6kiGOOa42hYVPUIigKucDJ6mgCKTwXZy6VfWTXU6tc376hHOhCvBKW" +
                        "3AqfY+vUUALbeGL2XVLS91vW5NS+xEvbwiBYUVyMb2A+8wBOOwyeKANLQtFi0GwktIpXlV7iWfcwAILu" +
                        "WI/DOKAMZPA62ulaTb6fqk9re6UZPs91sVshySysp4YHj8higC5pnhmS31C61LVNSk1G/uIBbb/ACxEk" +
                        "cWc7VUdMk5JJJ6UAVLXwSkfhX/hH7vVJ7m3hZDZyhFjltthBTDDqVIHJoAlg8L30+o2d1reuyakli/mw" +
                        "QiBYU8zBAdtv3iATjoO+KAOmoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgA" +
                        "oAKACgAoAKAP//ZC0EAAQAAAP////8BAAAAAAAAAAwCAAAAG0RldkV4cHJlc3MuWHRyYVJlcG9ydHMud" +
                        "jYuMgUBAAAALERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuU2VyaWFsaXphYmxlU3RyaW5nAQAAAAVWY" +
                        "Wx1ZQECAAAABgMAAADiBHtccnRmMVxhbnNpXGFuc2ljcGcxMjUyXGRlZmYwe1xmb250dGJse1xmMFxmb" +
                        "mlsIEFyaWFsO317XGYxXGZuaWxcZmNoYXJzZXQwIEFyaWFsO317XGYyXGZuaWwgVGltZXMgTmV3IFJvb" +
                        "WFuO319DQp7XGNvbG9ydGJsIDtccmVkMFxncmVlbjBcYmx1ZTA7fQ0KXHZpZXdraW5kNFx1YzFccGFyZ" +
                        "FxjZjFcbGFuZzIwNTVcZjBcZnMyMCBFaW5sXGYxXCdmNlxmMCBzYmFyIHZvbiBNby1GciAwODozMCAtM" +
                        "TY6MzAgVWhyIGJlaSBkZXIgU3RhZHRrYXNzZSBaXGYxXCdmY1xmMCByaWNoLCBcZjEgU3RhZHRoYXVzc" +
                        "XVhaSAxNywgODAwMSBcZjAgWlxmMVwnZmNcZjAgcmljaFxjZjBcZjJcZnMyNFxwYXINClxmczE4XHBhc" +
                        "g0KXGNmMVxmMFxmczIwIEF1c3phaGx1bmcgZXJmb2xndCBnZWdlbiBnXGYxXCdmY1xmMCBsdGlnZW4gY" +
                        "W10bGljaGVuIEF1c3dlaXM6IElELCBQYXNzLCBBdXNsXGYxXCdlNFxmMCBuZGVyYXVzd2VpcywgRlxmM" +
                        "VwnZmNcZjAgaHJlcnNjaGVpbi4gXHBhcg0KSXN0IGtlaW4gQXVzd2VpcyB2b3JoYW5kZW4sIGJpdHRlI" +
                        "G1pdCB6dXN0XGYxXCdlNFxmMCBuZGlnZXIvbSBTb3ppYWxhcmJlaXRlci9pbiBLb250YWt0IGF1Zm5la" +
                        "G1lbi5cY2YwXGYyXGZzMjRccGFyDQp9DQoL";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.BarCode.XRCode128Generator xrCode128Generator1 = new DevExpress.XtraReports.UI.BarCode.XRCode128Generator();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarCode1 = new DevExpress.XtraReports.UI.XRBarCode();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.FullName1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label14 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label9 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtVerfalldatum = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNameYearMonth = new DevExpress.XtraReports.UI.XRLabel();
            this.txtFullName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtFlBelegID = new DevExpress.XtraReports.UI.XRLabel();
            this.Label8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Shape1 = new DevExpress.XtraReports.UI.XRControl();
            this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrControl1 = new DevExpress.XtraReports.UI.XRControl();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtIntern = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line6 = new DevExpress.XtraReports.UI.XRLine();
            this.Line4 = new DevExpress.XtraReports.UI.XRLine();
            this.Label19 = new DevExpress.XtraReports.UI.XRLabel();
            this.Betrag1 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 254F;
            this.Detail.Height = 0;
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
                        this.xrLabel10,
                        this.xrLabel9,
                        this.xrLabel8,
                        this.xrLabel6,
                        this.xrLabel3,
                        this.xrLabel1,
                        this.xrPictureBox1,
                        this.xrLabel7,
                        this.xrLabel5,
                        this.Label16,
                        this.xrLabel4,
                        this.xrLabel2,
                        this.xrBarCode1,
                        this.Line1,
                        this.FullName1,
                        this.Label14,
                        this.Label9,
                        this.txtVerfalldatum,
                        this.txtNameYearMonth,
                        this.txtFullName,
                        this.txtFlBelegID,
                        this.Label8,
                        this.Label7,
                        this.Shape1});
            this.PageHeader.Dpi = 254F;
            this.PageHeader.Height = 1204;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.ParentStyleUsing.UseBackColor = false;
            this.PageHeader.ParentStyleUsing.UseBorderColor = false;
            this.PageHeader.ParentStyleUsing.UseBorders = false;
            this.PageHeader.ParentStyleUsing.UseBorderWidth = false;
            this.PageHeader.ParentStyleUsing.UseFont = false;
            this.PageHeader.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Dpi = 254F;
            this.GroupFooter1.Height = 0;
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
                        this.xrRichText1,
                        this.xrControl1,
                        this.xrLabel24,
                        this.xrLine2,
                        this.xrLabel22,
                        this.xrLine1,
                        this.xrLabel13,
                        this.xrLabel21,
                        this.xrLabel20,
                        this.xrLabel19,
                        this.xrLabel18,
                        this.xrLabel17,
                        this.xrLabel16,
                        this.xrLabel15,
                        this.xrLabel14});
            this.PageFooter.Dpi = 254F;
            this.PageFooter.Height = 656;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtIntern,
                        this.xrLabel11,
                        this.xrLabel12,
                        this.txtBetrag});
            this.GroupHeader1.Dpi = 254F;
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("LA", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
                        new DevExpress.XtraReports.UI.GroupField("Text", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 56;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel23,
                        this.Line6,
                        this.Line4,
                        this.Label19,
                        this.Betrag1});
            this.ReportFooter.Dpi = 254F;
            this.ReportFooter.Height = 318;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 254F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel10.ForeColor = System.Drawing.Color.Black;
            this.xrLabel10.Location = new System.Drawing.Point(1592, 1122);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel10.ParentStyleUsing.UseBackColor = false;
            this.xrLabel10.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel10.ParentStyleUsing.UseBorders = false;
            this.xrLabel10.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel10.ParentStyleUsing.UseFont = false;
            this.xrLabel10.ParentStyleUsing.UseForeColor = false;
            this.xrLabel10.Size = new System.Drawing.Size(170, 48);
            this.xrLabel10.Text = "Betrag";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 254F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel9.ForeColor = System.Drawing.Color.Black;
            this.xrLabel9.Location = new System.Drawing.Point(1085, 1122);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel9.ParentStyleUsing.UseBackColor = false;
            this.xrLabel9.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel9.ParentStyleUsing.UseBorders = false;
            this.xrLabel9.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.ParentStyleUsing.UseForeColor = false;
            this.xrLabel9.Size = new System.Drawing.Size(381, 50);
            this.xrLabel9.Text = "Verwendungsperiode\r\n";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 254F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel8.ForeColor = System.Drawing.Color.Black;
            this.xrLabel8.Location = new System.Drawing.Point(280, 1122);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel8.ParentStyleUsing.UseBackColor = false;
            this.xrLabel8.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel8.ParentStyleUsing.UseBorders = false;
            this.xrLabel8.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.ParentStyleUsing.UseForeColor = false;
            this.xrLabel8.Size = new System.Drawing.Size(170, 48);
            this.xrLabel8.Text = "Text";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 254F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel6.ForeColor = System.Drawing.Color.Black;
            this.xrLabel6.Location = new System.Drawing.Point(153, 603);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel6.ParentStyleUsing.UseBackColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorders = false;
            this.xrLabel6.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.ParentStyleUsing.UseForeColor = false;
            this.xrLabel6.Size = new System.Drawing.Size(310, 40);
            this.xrLabel6.Text = "Personen-Nr.";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 16F);
            this.xrLabel3.Location = new System.Drawing.Point(1206, 376);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(466, 63);
            this.xrLabel3.Text = "Alimentenstelle";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 16F);
            this.xrLabel1.Location = new System.Drawing.Point(132, 381);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(678, 63);
            this.xrLabel1.Text = "Barauszahlungsbeleg";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Dpi = 254F;
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.Location = new System.Drawing.Point(132, 0);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.Size = new System.Drawing.Size(592, 127);
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 254F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.Location = new System.Drawing.Point(1418, 0);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.Size = new System.Drawing.Size(381, 318);
            this.xrLabel7.Text = "Stadt Zürich\r\nSoziale Dienste\r\nVerwaltungszentrum Werd\r\nPostfach\r\n8036 Zürich\r\n\r\n" +
                "044 412 61 11\r\n044 412 09 89\r\nwww.stadt-zuerich.ch/sd\r\n\r\n";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel5.Dpi = 254F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.ForeColor = System.Drawing.Color.Black;
            this.xrLabel5.Location = new System.Drawing.Point(1679, 360);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel5.ParentStyleUsing.UseBackColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorders = false;
            this.xrLabel5.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.ParentStyleUsing.UseForeColor = false;
            this.xrLabel5.Size = new System.Drawing.Size(83, 84);
            this.xrLabel5.Text = "A";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Label16
            // 
            this.Label16.Dpi = 254F;
            this.Label16.Font = new System.Drawing.Font("Arial", 10F);
            this.Label16.ForeColor = System.Drawing.Color.Black;
            this.Label16.Location = new System.Drawing.Point(153, 1122);
            this.Label16.Name = "Label16";
            this.Label16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label16.ParentStyleUsing.UseBackColor = false;
            this.Label16.ParentStyleUsing.UseBorderColor = false;
            this.Label16.ParentStyleUsing.UseBorders = false;
            this.Label16.ParentStyleUsing.UseBorderWidth = false;
            this.Label16.ParentStyleUsing.UseFont = false;
            this.Label16.ParentStyleUsing.UseForeColor = false;
            this.Label16.Size = new System.Drawing.Size(106, 47);
            this.Label16.Text = "LA";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.Location = new System.Drawing.Point(153, 709);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.ParentStyleUsing.UseForeColor = false;
            this.xrLabel4.Size = new System.Drawing.Size(310, 40);
            this.xrLabel4.Text = "Gültig bis";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GueltigAb", "")});
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.Location = new System.Drawing.Point(598, 669);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.ParentStyleUsing.UseBackColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorders = false;
            this.xrLabel2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.ParentStyleUsing.UseForeColor = false;
            this.xrLabel2.Size = new System.Drawing.Size(1079, 40);
            xrSummary1.FormatString = "{0:dd.MM.yyyy}";
            this.xrLabel2.Summary = xrSummary1;
            this.xrLabel2.Text = "[GueltigAb]";
            // 
            // xrBarCode1
            // 
            this.xrBarCode1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Barcodetext", "")});
            this.xrBarCode1.Dpi = 254F;
            this.xrBarCode1.Location = new System.Drawing.Point(114, 190);
            this.xrBarCode1.Module = 2.54F;
            this.xrBarCode1.Name = "xrBarCode1";
            this.xrBarCode1.PaddingInfo = new DevExpress.XtraPrinting.PaddingInfo(25, 25, 0, 0, 254F);
            this.xrBarCode1.ShowText = false;
            this.xrBarCode1.Size = new System.Drawing.Size(1079, 107);
            this.xrBarCode1.Symbology = xrCode128Generator1;
            this.xrBarCode1.Text = "xrBarCode1";
            // 
            // Line1
            // 
            this.Line1.Dpi = 254F;
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.LineWidth = 3;
            this.Line1.Location = new System.Drawing.Point(132, 1172);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(1630, 11);
            // 
            // FullName1
            // 
            this.FullName1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AuszahlungAn", "")});
            this.FullName1.Dpi = 254F;
            this.FullName1.Font = new System.Drawing.Font("Arial", 10F);
            this.FullName1.ForeColor = System.Drawing.Color.Black;
            this.FullName1.Location = new System.Drawing.Point(153, 889);
            this.FullName1.Multiline = true;
            this.FullName1.Name = "FullName1";
            this.FullName1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.FullName1.ParentStyleUsing.UseBackColor = false;
            this.FullName1.ParentStyleUsing.UseBorderColor = false;
            this.FullName1.ParentStyleUsing.UseBorders = false;
            this.FullName1.ParentStyleUsing.UseBorderWidth = false;
            this.FullName1.ParentStyleUsing.UseFont = false;
            this.FullName1.ParentStyleUsing.UseForeColor = false;
            this.FullName1.Size = new System.Drawing.Size(953, 168);
            this.FullName1.Text = "FullName";
            // 
            // Label14
            // 
            this.Label14.Dpi = 254F;
            this.Label14.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label14.ForeColor = System.Drawing.Color.Black;
            this.Label14.Location = new System.Drawing.Point(153, 826);
            this.Label14.Name = "Label14";
            this.Label14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label14.ParentStyleUsing.UseBackColor = false;
            this.Label14.ParentStyleUsing.UseBorderColor = false;
            this.Label14.ParentStyleUsing.UseBorders = false;
            this.Label14.ParentStyleUsing.UseBorderWidth = false;
            this.Label14.ParentStyleUsing.UseFont = false;
            this.Label14.ParentStyleUsing.UseForeColor = false;
            this.Label14.Size = new System.Drawing.Size(317, 58);
            this.Label14.Text = "Auszahlung an:";
            // 
            // Label9
            // 
            this.Label9.Dpi = 254F;
            this.Label9.Font = new System.Drawing.Font("Arial", 10F);
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(153, 669);
            this.Label9.Name = "Label9";
            this.Label9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label9.ParentStyleUsing.UseBackColor = false;
            this.Label9.ParentStyleUsing.UseBorderColor = false;
            this.Label9.ParentStyleUsing.UseBorders = false;
            this.Label9.ParentStyleUsing.UseBorderWidth = false;
            this.Label9.ParentStyleUsing.UseFont = false;
            this.Label9.ParentStyleUsing.UseForeColor = false;
            this.Label9.Size = new System.Drawing.Size(310, 40);
            this.Label9.Text = "Gültig ab (Valuta)";
            // 
            // txtVerfalldatum
            // 
            this.txtVerfalldatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GueltigBis", "")});
            this.txtVerfalldatum.Dpi = 254F;
            this.txtVerfalldatum.Font = new System.Drawing.Font("Arial", 10F);
            this.txtVerfalldatum.ForeColor = System.Drawing.Color.Black;
            this.txtVerfalldatum.Location = new System.Drawing.Point(598, 709);
            this.txtVerfalldatum.Multiline = true;
            this.txtVerfalldatum.Name = "txtVerfalldatum";
            this.txtVerfalldatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtVerfalldatum.ParentStyleUsing.UseBackColor = false;
            this.txtVerfalldatum.ParentStyleUsing.UseBorderColor = false;
            this.txtVerfalldatum.ParentStyleUsing.UseBorders = false;
            this.txtVerfalldatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtVerfalldatum.ParentStyleUsing.UseFont = false;
            this.txtVerfalldatum.ParentStyleUsing.UseForeColor = false;
            this.txtVerfalldatum.Size = new System.Drawing.Size(1079, 40);
            xrSummary2.FormatString = "{0:dd.MM.yyyy}";
            this.txtVerfalldatum.Summary = xrSummary2;
            this.txtVerfalldatum.Text = "Verfalldatum";
            // 
            // txtNameYearMonth
            // 
            this.txtNameYearMonth.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "PersonenNr", "")});
            this.txtNameYearMonth.Dpi = 254F;
            this.txtNameYearMonth.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNameYearMonth.ForeColor = System.Drawing.Color.Black;
            this.txtNameYearMonth.Location = new System.Drawing.Point(598, 603);
            this.txtNameYearMonth.Multiline = true;
            this.txtNameYearMonth.Name = "txtNameYearMonth";
            this.txtNameYearMonth.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtNameYearMonth.ParentStyleUsing.UseBackColor = false;
            this.txtNameYearMonth.ParentStyleUsing.UseBorderColor = false;
            this.txtNameYearMonth.ParentStyleUsing.UseBorders = false;
            this.txtNameYearMonth.ParentStyleUsing.UseBorderWidth = false;
            this.txtNameYearMonth.ParentStyleUsing.UseFont = false;
            this.txtNameYearMonth.ParentStyleUsing.UseForeColor = false;
            this.txtNameYearMonth.Size = new System.Drawing.Size(1079, 40);
            this.txtNameYearMonth.Text = "NameYearMonth";
            // 
            // txtFullName
            // 
            this.txtFullName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Klient", "")});
            this.txtFullName.Dpi = 254F;
            this.txtFullName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtFullName.ForeColor = System.Drawing.Color.Black;
            this.txtFullName.Location = new System.Drawing.Point(598, 561);
            this.txtFullName.Multiline = true;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtFullName.ParentStyleUsing.UseBackColor = false;
            this.txtFullName.ParentStyleUsing.UseBorderColor = false;
            this.txtFullName.ParentStyleUsing.UseBorders = false;
            this.txtFullName.ParentStyleUsing.UseBorderWidth = false;
            this.txtFullName.ParentStyleUsing.UseFont = false;
            this.txtFullName.ParentStyleUsing.UseForeColor = false;
            this.txtFullName.Size = new System.Drawing.Size(1079, 40);
            this.txtFullName.Text = "FullName";
            // 
            // txtFlBelegID
            // 
            this.txtFlBelegID.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Barcodetext", "")});
            this.txtFlBelegID.Dpi = 254F;
            this.txtFlBelegID.Font = new System.Drawing.Font("Arial", 10F);
            this.txtFlBelegID.ForeColor = System.Drawing.Color.Black;
            this.txtFlBelegID.Location = new System.Drawing.Point(598, 521);
            this.txtFlBelegID.Multiline = true;
            this.txtFlBelegID.Name = "txtFlBelegID";
            this.txtFlBelegID.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtFlBelegID.ParentStyleUsing.UseBackColor = false;
            this.txtFlBelegID.ParentStyleUsing.UseBorderColor = false;
            this.txtFlBelegID.ParentStyleUsing.UseBorders = false;
            this.txtFlBelegID.ParentStyleUsing.UseBorderWidth = false;
            this.txtFlBelegID.ParentStyleUsing.UseFont = false;
            this.txtFlBelegID.ParentStyleUsing.UseForeColor = false;
            this.txtFlBelegID.Size = new System.Drawing.Size(1079, 40);
            // 
            // Label8
            // 
            this.Label8.Dpi = 254F;
            this.Label8.Font = new System.Drawing.Font("Arial", 10F);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(153, 561);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(310, 40);
            this.Label8.Text = "Klient/in";
            // 
            // Label7
            // 
            this.Label7.Dpi = 254F;
            this.Label7.Font = new System.Drawing.Font("Arial", 10F);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(153, 521);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(310, 40);
            this.Label7.Text = "Beleg-Nr.";
            // 
            // Shape1
            // 
            this.Shape1.BackColor = System.Drawing.Color.Empty;
            this.Shape1.BorderColor = System.Drawing.Color.Gray;
            this.Shape1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Shape1.Dpi = 254F;
            this.Shape1.Location = new System.Drawing.Point(132, 508);
            this.Shape1.Name = "Shape1";
            this.Shape1.ParentStyleUsing.UseBackColor = false;
            this.Shape1.ParentStyleUsing.UseBorderColor = false;
            this.Shape1.ParentStyleUsing.UseBorders = false;
            this.Shape1.ParentStyleUsing.UseBorderWidth = false;
            this.Shape1.ParentStyleUsing.UseFont = false;
            this.Shape1.ParentStyleUsing.UseForeColor = false;
            this.Shape1.Size = new System.Drawing.Size(1630, 275);
            // 
            // xrRichText1
            // 
            this.xrRichText1.Dpi = 254F;
            this.xrRichText1.Font = new System.Drawing.Font("Arial", 10F);
            this.xrRichText1.Location = new System.Drawing.Point(169, 466);
            this.xrRichText1.Name = "xrRichText1";
            this.xrRichText1.ParentStyleUsing.UseFont = false;
            this.xrRichText1.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichText1.RtfText")));
            this.xrRichText1.Size = new System.Drawing.Size(1567, 190);
            // 
            // xrControl1
            // 
            this.xrControl1.BackColor = System.Drawing.Color.Empty;
            this.xrControl1.BorderColor = System.Drawing.Color.Gray;
            this.xrControl1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrControl1.Dpi = 254F;
            this.xrControl1.Location = new System.Drawing.Point(148, 444);
            this.xrControl1.Name = "xrControl1";
            this.xrControl1.ParentStyleUsing.UseBackColor = false;
            this.xrControl1.ParentStyleUsing.UseBorderColor = false;
            this.xrControl1.ParentStyleUsing.UseBorders = false;
            this.xrControl1.ParentStyleUsing.UseBorderWidth = false;
            this.xrControl1.ParentStyleUsing.UseFont = false;
            this.xrControl1.ParentStyleUsing.UseForeColor = false;
            this.xrControl1.Size = new System.Drawing.Size(1609, 212);
            // 
            // xrLabel24
            // 
            this.xrLabel24.Dpi = 254F;
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 11F);
            this.xrLabel24.Location = new System.Drawing.Point(169, 0);
            this.xrLabel24.Multiline = true;
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel24.ParentStyleUsing.UseFont = false;
            this.xrLabel24.Size = new System.Drawing.Size(212, 106);
            this.xrLabel24.Text = "Unterschrift\r\n(Blau)";
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 254F;
            this.xrLine2.ForeColor = System.Drawing.Color.Black;
            this.xrLine2.LineWidth = 3;
            this.xrLine2.Location = new System.Drawing.Point(402, 85);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.ParentStyleUsing.UseBackColor = false;
            this.xrLine2.ParentStyleUsing.UseBorderColor = false;
            this.xrLine2.ParentStyleUsing.UseBorders = false;
            this.xrLine2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine2.ParentStyleUsing.UseFont = false;
            this.xrLine2.ParentStyleUsing.UseForeColor = false;
            this.xrLine2.Size = new System.Drawing.Size(614, 10);
            // 
            // xrLabel22
            // 
            this.xrLabel22.Dpi = 254F;
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 11F);
            this.xrLabel22.Location = new System.Drawing.Point(1080, 42);
            this.xrLabel22.Multiline = true;
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel22.ParentStyleUsing.UseFont = false;
            this.xrLabel22.Size = new System.Drawing.Size(170, 64);
            this.xrLabel22.Text = "Stempel";
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 254F;
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.LineWidth = 3;
            this.xrLine1.Location = new System.Drawing.Point(1249, 85);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(508, 10);
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 254F;
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel13.ForeColor = System.Drawing.Color.Black;
            this.xrLabel13.Location = new System.Drawing.Point(169, 127);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel13.ParentStyleUsing.UseBackColor = false;
            this.xrLabel13.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel13.ParentStyleUsing.UseBorders = false;
            this.xrLabel13.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel13.ParentStyleUsing.UseFont = false;
            this.xrLabel13.ParentStyleUsing.UseForeColor = false;
            this.xrLabel13.Size = new System.Drawing.Size(1566, 39);
            this.xrLabel13.Text = "(Unterschriftsberechtigte/r gemäss Unterschriftenkarte)";
            // 
            // xrLabel21
            // 
            this.xrLabel21.Dpi = 254F;
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel21.ForeColor = System.Drawing.Color.Black;
            this.xrLabel21.Location = new System.Drawing.Point(153, 318);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel21.ParentStyleUsing.UseBackColor = false;
            this.xrLabel21.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel21.ParentStyleUsing.UseBorders = false;
            this.xrLabel21.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel21.ParentStyleUsing.UseFont = false;
            this.xrLabel21.ParentStyleUsing.UseForeColor = false;
            this.xrLabel21.Size = new System.Drawing.Size(310, 40);
            this.xrLabel21.Text = "Sachbearbeiter/in";
            // 
            // xrLabel20
            // 
            this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Sozialarbeiter", "")});
            this.xrLabel20.Dpi = 254F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel20.ForeColor = System.Drawing.Color.Black;
            this.xrLabel20.Location = new System.Drawing.Point(598, 318);
            this.xrLabel20.Multiline = true;
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel20.ParentStyleUsing.UseBackColor = false;
            this.xrLabel20.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel20.ParentStyleUsing.UseBorders = false;
            this.xrLabel20.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel20.ParentStyleUsing.UseFont = false;
            this.xrLabel20.ParentStyleUsing.UseForeColor = false;
            this.xrLabel20.Size = new System.Drawing.Size(1079, 40);
            this.xrLabel20.Text = "NameYearMonth";
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 254F;
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel19.ForeColor = System.Drawing.Color.Black;
            this.xrLabel19.Location = new System.Drawing.Point(153, 275);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel19.ParentStyleUsing.UseBackColor = false;
            this.xrLabel19.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel19.ParentStyleUsing.UseBorders = false;
            this.xrLabel19.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel19.ParentStyleUsing.UseFont = false;
            this.xrLabel19.ParentStyleUsing.UseForeColor = false;
            this.xrLabel19.Size = new System.Drawing.Size(310, 40);
            this.xrLabel19.Text = "Belegersteller/in";
            // 
            // xrLabel18
            // 
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Belegersteller", "")});
            this.xrLabel18.Dpi = 254F;
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel18.ForeColor = System.Drawing.Color.Black;
            this.xrLabel18.Location = new System.Drawing.Point(598, 275);
            this.xrLabel18.Multiline = true;
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel18.ParentStyleUsing.UseBackColor = false;
            this.xrLabel18.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel18.ParentStyleUsing.UseBorders = false;
            this.xrLabel18.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel18.ParentStyleUsing.UseFont = false;
            this.xrLabel18.ParentStyleUsing.UseForeColor = false;
            this.xrLabel18.Size = new System.Drawing.Size(1079, 40);
            this.xrLabel18.Text = "NameYearMonth";
            // 
            // xrLabel17
            // 
            this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Organisationseinheit", "")});
            this.xrLabel17.Dpi = 254F;
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel17.ForeColor = System.Drawing.Color.Black;
            this.xrLabel17.Location = new System.Drawing.Point(598, 233);
            this.xrLabel17.Multiline = true;
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel17.ParentStyleUsing.UseBackColor = false;
            this.xrLabel17.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel17.ParentStyleUsing.UseBorders = false;
            this.xrLabel17.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel17.ParentStyleUsing.UseFont = false;
            this.xrLabel17.ParentStyleUsing.UseForeColor = false;
            this.xrLabel17.Size = new System.Drawing.Size(1079, 40);
            this.xrLabel17.Text = "FullName";
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Erstelldatum", "")});
            this.xrLabel16.Dpi = 254F;
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel16.ForeColor = System.Drawing.Color.Black;
            this.xrLabel16.Location = new System.Drawing.Point(598, 190);
            this.xrLabel16.Multiline = true;
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel16.ParentStyleUsing.UseBackColor = false;
            this.xrLabel16.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel16.ParentStyleUsing.UseBorders = false;
            this.xrLabel16.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel16.ParentStyleUsing.UseFont = false;
            this.xrLabel16.ParentStyleUsing.UseForeColor = false;
            this.xrLabel16.Size = new System.Drawing.Size(1079, 40);
            this.xrLabel16.Text = "xrLabel16";
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 254F;
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel15.ForeColor = System.Drawing.Color.Black;
            this.xrLabel15.Location = new System.Drawing.Point(153, 233);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel15.ParentStyleUsing.UseBackColor = false;
            this.xrLabel15.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel15.ParentStyleUsing.UseBorders = false;
            this.xrLabel15.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel15.ParentStyleUsing.UseFont = false;
            this.xrLabel15.ParentStyleUsing.UseForeColor = false;
            this.xrLabel15.Size = new System.Drawing.Size(360, 40);
            this.xrLabel15.Text = "Organisationseinheit";
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 254F;
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel14.ForeColor = System.Drawing.Color.Black;
            this.xrLabel14.Location = new System.Drawing.Point(153, 190);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel14.ParentStyleUsing.UseBackColor = false;
            this.xrLabel14.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel14.ParentStyleUsing.UseBorders = false;
            this.xrLabel14.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel14.ParentStyleUsing.UseFont = false;
            this.xrLabel14.ParentStyleUsing.UseForeColor = false;
            this.xrLabel14.Size = new System.Drawing.Size(310, 40);
            this.xrLabel14.Text = "Erstellungsdatum";
            // 
            // txtIntern
            // 
            this.txtIntern.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "LA", "")});
            this.txtIntern.Dpi = 254F;
            this.txtIntern.Font = new System.Drawing.Font("Arial", 10F);
            this.txtIntern.ForeColor = System.Drawing.Color.Black;
            this.txtIntern.Location = new System.Drawing.Point(148, 0);
            this.txtIntern.Multiline = true;
            this.txtIntern.Name = "txtIntern";
            this.txtIntern.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtIntern.ParentStyleUsing.UseBackColor = false;
            this.txtIntern.ParentStyleUsing.UseBorderColor = false;
            this.txtIntern.ParentStyleUsing.UseBorders = false;
            this.txtIntern.ParentStyleUsing.UseBorderWidth = false;
            this.txtIntern.ParentStyleUsing.UseFont = false;
            this.txtIntern.ParentStyleUsing.UseForeColor = false;
            this.txtIntern.Size = new System.Drawing.Size(169, 50);
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text", "")});
            this.xrLabel11.Dpi = 254F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel11.ForeColor = System.Drawing.Color.Black;
            this.xrLabel11.Location = new System.Drawing.Point(280, 0);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel11.ParentStyleUsing.UseBackColor = false;
            this.xrLabel11.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel11.ParentStyleUsing.UseBorders = false;
            this.xrLabel11.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel11.ParentStyleUsing.UseFont = false;
            this.xrLabel11.ParentStyleUsing.UseForeColor = false;
            this.xrLabel11.Size = new System.Drawing.Size(784, 50);
            this.xrLabel11.Text = "xrLabel11";
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VerwPeriode", "")});
            this.xrLabel12.Dpi = 254F;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel12.ForeColor = System.Drawing.Color.Black;
            this.xrLabel12.Location = new System.Drawing.Point(1080, 0);
            this.xrLabel12.Multiline = true;
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel12.ParentStyleUsing.UseBackColor = false;
            this.xrLabel12.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel12.ParentStyleUsing.UseBorders = false;
            this.xrLabel12.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel12.ParentStyleUsing.UseFont = false;
            this.xrLabel12.ParentStyleUsing.UseForeColor = false;
            this.xrLabel12.Size = new System.Drawing.Size(423, 50);
            this.xrLabel12.Text = "xrLabel12";
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Dpi = 254F;
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(1545, 0);
            this.txtBetrag.Multiline = true;
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(219, 51);
            xrSummary3.FormatString = "{0:0.00}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.txtBetrag.Summary = xrSummary3;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel23
            // 
            this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "inWorten", "")});
            this.xrLabel23.Dpi = 254F;
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 11F);
            this.xrLabel23.Location = new System.Drawing.Point(868, 212);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel23.ParentStyleUsing.UseFont = false;
            this.xrLabel23.Size = new System.Drawing.Size(888, 63);
            this.xrLabel23.Text = "xrLabel23";
            // 
            // Line6
            // 
            this.Line6.Dpi = 254F;
            this.Line6.ForeColor = System.Drawing.Color.Black;
            this.Line6.LineWidth = 5;
            this.Line6.Location = new System.Drawing.Point(863, 177);
            this.Line6.Name = "Line6";
            this.Line6.ParentStyleUsing.UseBackColor = false;
            this.Line6.ParentStyleUsing.UseBorderColor = false;
            this.Line6.ParentStyleUsing.UseBorders = false;
            this.Line6.ParentStyleUsing.UseBorderWidth = false;
            this.Line6.ParentStyleUsing.UseFont = false;
            this.Line6.ParentStyleUsing.UseForeColor = false;
            this.Line6.Size = new System.Drawing.Size(894, 11);
            // 
            // Line4
            // 
            this.Line4.Dpi = 254F;
            this.Line4.ForeColor = System.Drawing.Color.Black;
            this.Line4.LineWidth = 5;
            this.Line4.Location = new System.Drawing.Point(863, 188);
            this.Line4.Name = "Line4";
            this.Line4.ParentStyleUsing.UseBackColor = false;
            this.Line4.ParentStyleUsing.UseBorderColor = false;
            this.Line4.ParentStyleUsing.UseBorders = false;
            this.Line4.ParentStyleUsing.UseBorderWidth = false;
            this.Line4.ParentStyleUsing.UseFont = false;
            this.Line4.ParentStyleUsing.UseForeColor = false;
            this.Line4.Size = new System.Drawing.Size(894, 10);
            // 
            // Label19
            // 
            this.Label19.Dpi = 254F;
            this.Label19.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Label19.ForeColor = System.Drawing.Color.Black;
            this.Label19.Location = new System.Drawing.Point(863, 106);
            this.Label19.Name = "Label19";
            this.Label19.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label19.ParentStyleUsing.UseBackColor = false;
            this.Label19.ParentStyleUsing.UseBorderColor = false;
            this.Label19.ParentStyleUsing.UseBorders = false;
            this.Label19.ParentStyleUsing.UseBorderWidth = false;
            this.Label19.ParentStyleUsing.UseFont = false;
            this.Label19.ParentStyleUsing.UseForeColor = false;
            this.Label19.Size = new System.Drawing.Size(529, 69);
            this.Label19.Text = "Auszuzahlender Betrag ";
            // 
            // Betrag1
            // 
            this.Betrag1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.Betrag1.Dpi = 254F;
            this.Betrag1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Betrag1.ForeColor = System.Drawing.Color.Black;
            this.Betrag1.Location = new System.Drawing.Point(1503, 106);
            this.Betrag1.Multiline = true;
            this.Betrag1.Name = "Betrag1";
            this.Betrag1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Betrag1.ParentStyleUsing.UseBackColor = false;
            this.Betrag1.ParentStyleUsing.UseBorderColor = false;
            this.Betrag1.ParentStyleUsing.UseBorders = false;
            this.Betrag1.ParentStyleUsing.UseBorderWidth = false;
            this.Betrag1.ParentStyleUsing.UseFont = false;
            this.Betrag1.ParentStyleUsing.UseForeColor = false;
            this.Betrag1.Size = new System.Drawing.Size(254, 69);
            xrSummary4.FormatString = "{0:0.00}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.Betrag1.Summary = xrSummary4;
            this.Betrag1.Text = "Betrag";
            this.Betrag1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
                        this.GroupFooter1,
                        this.PageFooter,
                        this.GroupHeader1,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(99, 99, 99, 99);
            this.Name = "Report";
            this.PageHeight = 2969;
            this.PageWidth = 2101;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).EndInit();
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
		<DisplayText>Belegnummer:</DisplayText>
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
		<FieldName>KbBuchungID</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>Belegnummer</DisplayText>
		<TabPosition>1</TabPosition>
		<X>220</X>
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
		<FieldName>KasseUserID</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>Kasse Benutzer</DisplayText>
		<TabPosition>1</TabPosition>
		<X>220</X>
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
</NewDataSet>' ,  N'declare @KbBuchungID int
declare @KasseUserID int
declare @BetragText varchar(20)
declare @InWorten varchar(200)
declare @Valuta datetime

set @KbBuchungID = {KbBuchungID} -- 882
set @KasseUserID = {KasseUserID} -- 1

select @BetragText = convert(varchar, Betrag, 1),
       @Valuta     = convert(datetime,dbo.fnMAX(ValutaDatum,getdate()))
from   KbBuchung
where  KbBuchungID = @KbBuchungID

set @InWorten = ''''
while len(@BetragText) > 0 begin
  if left(@BetragText,1) <> ''.'' and 
     @InWorten <> '''' and 
     right(@InWorten,1) not in (''.'',''-'') 
  begin
    set @InWorten = @InWorten + ''-''
  end

  set @InWorten = @InWorten +
    case left(@BetragText,1)
    when ''.'' then ''.''
    when ''0'' then ''Null''
    when ''1'' then ''Eins''
    when ''2'' then ''Zwei''
    when ''3'' then ''Drei''
    when ''4'' then ''Vier''
    when ''5'' then ''Fünf''
    when ''6'' then ''Sechs''
    when ''7'' then ''Sieben''
    when ''8'' then ''Acht''
    when ''9'' then ''Neun''
    else ''''
    end

  set @BetragText = substring(@BetragText,2,200)
end
set @InWorten = ''*'' + @InWorten + ''*''

select 
  IkPositionID = BUC.IkPositionID,
  Barcodetext = convert(varchar(20),convert(bigint,BUC.BelegNr)),
  Klient = PRS.NameVorname,
  PersonenNr = PRS.BaPersonID,
  GueltigAb = convert(varchar,@Valuta,104),
  GueltigBis = convert(varchar, dateadd(day, case datepart(weekday, @Valuta)
    when 1 then 2 -- So
    when 2 then 2 -- Mo
    when 3 then 2 -- Di
    when 4 then 2 -- Mi 
    when 5 then 4 -- Do
    when 6 then 4 -- Fr
    when 7 then 3 -- Sa
  end, @Valuta),104),
  AuszahlungAn = 
    IsNull(BUC.BeguenstigtName + CHAR(13) + CHAR(10),'''') +
    IsNull(BUC.BeguenstigtName2 + char(13) + char(10),'''') +
    IsNull(BUC.BeguenstigtPostfach + char(13) + char(10), '''') +
    IsNull(BUC.BeguenstigtStrasse + IsNull('' '' + BUC.BeguenstigtHausNr, '''') + char(13) + char(10), '''') +
    IsNull(IsNull(BUC.BeguenstigtPLZ + '' '', '''') + IsNull(BUC.BeguenstigtOrt, ''''),''''),
  Konto = BUC.SollKtoNr,
  LA = KOA.KontoNr,
  Text = case LST.FaProzessCode 
    when 405 then ''Alimentenbevorschussung''
    when 406 then ''Überbrückungshilfe''
    when 407 then ''Kleinkinderbetreuungsbeiträge''
    else ''[undefiniert]''
  end,
  Monat = dbo.fnXMonat(POS.Monat) + '' '' + convert(varchar,POS.Jahr),
  Betrag = BUK.Betrag,
  VerwPeriode = convert(varchar,BUK.VerwPeriodeVon,104) + isnull('' - '' + convert(varchar,BUK.VerwPeriodeBis,104),''''),
  inWorten = @InWorten,
  Erstelldatum = convert(varchar,getdate(),104),
  Organisationseinheit = isNull(USR.Sozialzentrum + '', '','''') + USR.OrgUnit, 
  Belegersteller = KUSR.NameVorname + isNull('' ('' + KUSR.Phone + '')'',''''),
  Sozialarbeiter = USR.NameVorname + isNull('' ('' + USR.Phone + '')'','''')
from KbBuchung BUC
  left join KbBuchungKostenart BUK on BUK.KbBuchungID = BUC.KbBuchungID
  left join BgKostenart KOA on KOA.BgKostenartID = BUK.BgKostenartID
  left join IkPosition POS on POS.IkPositionID = BUC.IkPositionID
  left join IkRechtstitel RT on RT.IkRechtstitelID = POS.IkRechtstitelID
  left join FaLeistung LST on LST.FaLeistungID = CASE 
    WHEN POS.FaLeistungID IS NULL THEN RT.FaLeistungID
    ELSE POS.FaLeistungID
  END
  left join FaFall FAL on FAL.FaFallID = LST.FaFallID
  left join vwPerson PRS  on PRS.BaPersonID = FAL.BaPersonID
  left join vwUser USR  on USR.UserID = LST.UserId
  left  join vwUser KUSR on KUSR.UserID = @KasseUserID
where  BUC.KbBuchungID = @KbBuchungID 
order by KOA.KontoNr, BUC.IkPositionID' ,  N'AKassenbeleg' ,  null , 1,  null )
