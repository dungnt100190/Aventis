insert [XQuery]([QueryName], [UserText], [QueryCode], [LayoutXML], [ParameterXML], [SQLquery], [ContextForms], [ParentReportName], [ReportSortKey], [RelationColumnName])
values ( N'WhKassenbeleg' ,  N'W - Kassenbeleg' , 1,  N'/// <XRTypeInfo>
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
        private DevExpress.XtraReports.UI.XRLabel xrLabel25;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel24;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRControl xrControl1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
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
                        "GEAdABlAG0AZQBuAHQAAAAAACZ4AHIAUABpAGMAdAB1AHIAZQBCAG8AeAAxAC4ASQBtAGEAZwBlANcPA" +
                        "AAmeAByAFIAaQBjAGgAVABlAHgAdAAxAC4AUgB0AGYAVABlAHgAdADWIwAAAdQfZGVjbGFyZSBAS2JCd" +
                        "WNodW5nSUQgaW50DQpkZWNsYXJlIEBLYXNzZVVzZXJJRCBpbnQNCmRlY2xhcmUgQEJldHJhZ1RleHQgd" +
                        "mFyY2hhcigyMCkNCmRlY2xhcmUgQEluV29ydGVuIHZhcmNoYXIoMjAwKQ0KZGVjbGFyZSBAVmFsdXRhI" +
                        "GRhdGV0aW1lDQoNCnNldCBAS2JCdWNodW5nSUQgPSBudWxsDQpzZXQgQEthc3NlVXNlcklEID0gbnVsb" +
                        "A0KDQpzZWxlY3QgQEJldHJhZ1RleHQgPSBjb252ZXJ0KHZhcmNoYXIsIEJldHJhZywgMSksDQogICAgI" +
                        "CAgQFZhbHV0YSAgICAgPSBjb252ZXJ0KGRhdGV0aW1lLGRiby5mbk1BWChWYWx1dGFEYXR1bSxnZXRkY" +
                        "XRlKCkpKQ0KZnJvbSAgIEtiQnVjaHVuZw0Kd2hlcmUgIEtiQnVjaHVuZ0lEID0gQEtiQnVjaHVuZ0lED" +
                        "QoNCnNldCBASW5Xb3J0ZW4gPSAnJw0Kd2hpbGUgbGVuKEBCZXRyYWdUZXh0KSA+IDAgYmVnaW4NCiAga" +
                        "WYgbGVmdChAQmV0cmFnVGV4dCwxKSA8PiAnLicgYW5kIA0KICAgICBASW5Xb3J0ZW4gPD4gJycgYW5kI" +
                        "A0KICAgICByaWdodChASW5Xb3J0ZW4sMSkgbm90IGluICgnLicsJy0nKSANCiAgYmVnaW4NCiAgICBzZ" +
                        "XQgQEluV29ydGVuID0gQEluV29ydGVuICsgJy0nDQogIGVuZA0KDQogIHNldCBASW5Xb3J0ZW4gPSBAS" +
                        "W5Xb3J0ZW4gKw0KICAgIGNhc2UgbGVmdChAQmV0cmFnVGV4dCwxKQ0KICAgIHdoZW4gJy4nIHRoZW4gJ" +
                        "y4nDQogICAgd2hlbiAnMCcgdGhlbiAnTnVsbCcNCiAgICB3aGVuICcxJyB0aGVuICdFaW5zJw0KICAgI" +
                        "HdoZW4gJzInIHRoZW4gJ1p3ZWknDQogICAgd2hlbiAnMycgdGhlbiAnRHJlaScNCiAgICB3aGVuICc0J" +
                        "yB0aGVuICdWaWVyJw0KICAgIHdoZW4gJzUnIHRoZW4gJ0bDvG5mJw0KICAgIHdoZW4gJzYnIHRoZW4gJ" +
                        "1NlY2hzJw0KICAgIHdoZW4gJzcnIHRoZW4gJ1NpZWJlbicNCiAgICB3aGVuICc4JyB0aGVuICdBY2h0J" +
                        "w0KICAgIHdoZW4gJzknIHRoZW4gJ05ldW4nDQogICAgZWxzZSAnJw0KICAgIGVuZA0KDQogIHNldCBAQ" +
                        "mV0cmFnVGV4dCA9IHN1YnN0cmluZyhAQmV0cmFnVGV4dCwyLDIwMCkNCmVuZA0Kc2V0IEBJbldvcnRlb" +
                        "iA9ICcqJyArIEBJbldvcnRlbiArICcqJw0KDQpzZWxlY3QgQmdQb3NpdGlvbklEICAgICAgICAgPSBCV" +
                        "UsuQmdQb3NpdGlvbklELA0KICAgICAgIEJhcmNvZGV0ZXh0ICAgICAgICAgID0gY29udmVydCh2YXJja" +
                        "GFyKDIwKSxjb252ZXJ0KGJpZ2ludCxCVUMuQmVsZWdOcikpLA0KICAgICAgIEtsaWVudCAgICAgICAgI" +
                        "CAgICAgID0gUFJTLk5hbWVWb3JuYW1lLA0KICAgICAgIFBlcnNvbmVuTnIgICAgICAgICAgID0gUFJTL" +
                        "kJhUGVyc29uSUQsDQogICAgICAgR3VlbHRpZ0FiICAgICAgICAgICAgPSBjb252ZXJ0KHZhcmNoYXIsQ" +
                        "FZhbHV0YSwxMDQpLA0KICAgICAgIEd1ZWx0aWdCaXMgICAgICAgICAgID0gY29udmVydCh2YXJjaGFyL" +
                        "GRhdGVhZGQoZGF5LCANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgY2FzZSBkYXRlcGFyd" +
                        "Ch3ZWVrZGF5LCBAVmFsdXRhKQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICB3aGVuIDEgd" +
                        "GhlbiAyIC0tIFNvDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIHdoZW4gMiB0aGVuIDIgL" +
                        "S0gTW8NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgd2hlbiAzIHRoZW4gMiAtLSBEaQ0KI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICB3aGVuIDQgdGhlbiAyIC0tIE1pIA0KICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICB3aGVuIDUgdGhlbiA0IC0tIERvDQogICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgIHdoZW4gNiB0aGVuIDQgLS0gRnINCiAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgd2hlbiA3IHRoZW4gMyAtLSBTYQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICBlbmQsDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEBWYWx1dGEpLDEwNCksDQogI" +
                        "CAgICAgQXVzemFobHVuZ0FuICAgICAgICAgPSBJc051bGwoQlVDLkJlZ3VlbnN0aWd0TmFtZSArIENIQ" +
                        "VIoMTMpICsgQ0hBUigxMCksJycpICsNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIElzTnVsb" +
                        "ChCVUMuQmVndWVuc3RpZ3ROYW1lMiArIGNoYXIoMTMpICsgY2hhcigxMCksJycpICsNCiAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgIElzTnVsbChCVUMuQmVndWVuc3RpZ3RQb3N0ZmFjaCArIGNoYXIoM" +
                        "TMpICsgY2hhcigxMCksICcnKSArDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICBJc051bGwoQ" +
                        "lVDLkJlZ3VlbnN0aWd0U3RyYXNzZSArIElzTnVsbCgnICcgKyBCVUMuQmVndWVuc3RpZ3RIYXVzTnIsI" +
                        "CcnKSArIGNoYXIoMTMpICsgY2hhcigxMCksICcnKSArDQogICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICBJc051bGwoSXNOdWxsKEJVQy5CZWd1ZW5zdGlndFBMWiArICcgJywgJycpICsgSXNOdWxsKEJVQ" +
                        "y5CZWd1ZW5zdGlndE9ydCwgJycpLCcnKSwNCiAgICAgICBLb250byAgICAgICAgICAgICAgICA9IEJVQ" +
                        "y5Tb2xsS3RvTnIsDQogICAgICAgTEEgICAgICAgICAgICAgICAgICAgPSBLT0EuS29udG9OciwNCiAgI" +
                        "CAgICBUZXh0ICAgICAgICAgICAgICAgICA9IEJVSy5CdWNodW5nc3RleHQsDQogICAgICAgTW9uYXRzY" +
                        "nVkZ2V0ICAgICAgICAgPSBkYm8uZm5YTW9uYXQoQkRHLk1vbmF0KSArICcgJyArIGNvbnZlcnQodmFyY" +
                        "2hhcixCREcuSmFociksDQogICAgICAgQmV0cmFnICAgICAgICAgICAgICAgPSBCVUsuQmV0cmFnLA0KI" +
                        "CAgICAgIFZlcndQZXJpb2RlICAgICAgICAgID0gY29udmVydCh2YXJjaGFyLEJVSy5WZXJ3UGVyaW9kZ" +
                        "VZvbiwxMDQpICsgaXNudWxsKCcgLSAnICsgY29udmVydCh2YXJjaGFyLEJVSy5WZXJ3UGVyaW9kZUJpc" +
                        "ywxMDQpLCcnKSwNCiAgICAgICBpbldvcnRlbiAgICAgICAgICAgICA9IEBJbldvcnRlbiwNCiAgICAgI" +
                        "CBFcnN0ZWxsZGF0dW0gICAgICAgICA9IGNvbnZlcnQodmFyY2hhcixnZXRkYXRlKCksMTA0KSwNCiAgI" +
                        "CAgICBPcmdhbmlzYXRpb25zZWluaGVpdCA9IGlzTnVsbChVU1IuU296aWFsemVudHJ1bSArICcsICcsJ" +
                        "ycpICsgVVNSLk9yZ1VuaXQsIA0KICAgICAgIEJlbGVnZXJzdGVsbGVyICAgICAgID0gS1VTUi5OYW1lV" +
                        "m9ybmFtZSArIGlzTnVsbCgnICgnICsgS1VTUi5QaG9uZSArICcpJywnJyksDQogICAgICAgU296aWFsY" +
                        "XJiZWl0ZXIgICAgICAgPSBVU1IuTmFtZVZvcm5hbWUgKyBpc051bGwoJyAoJyArIFVTUi5QaG9uZSArI" +
                        "CcpJywnJykNCmZyb20gICBGYUxlaXN0dW5nIExFSQ0KICAgICAgIGlubmVyIGpvaW4gdndQZXJzb24gI" +
                        "CAgICAgICAgICAgICAgUFJTICBvbiBQUlMuQmFQZXJzb25JRCA9IExFSS5CYVBlcnNvbklEDQogICAgI" +
                        "CAgaW5uZXIgam9pbiB2d1VzZXIgICAgICAgICAgICAgICAgICBVU1IgIG9uIFVTUi5Vc2VySUQgPSBMR" +
                        "UkuVXNlcklkDQogICAgICAgaW5uZXIgam9pbiBCZ0ZpbmFuenBsYW4gICAgICAgICAgICBGUEwgIG9uI" +
                        "EZQTC5GYUxlaXN0dW5nSUQgPSBMRUkuRmFMZWlzdHVuZ0lEDQogICAgICAgaW5uZXIgam9pbiBCZ0J1Z" +
                        "GdldCAgICAgICAgICAgICAgICBCREcgIG9uIEJERy5CZ0ZpbmFuenBsYW5JRCA9IEZQTC5CZ0ZpbmFue" +
                        "nBsYW5JRA0KICAgICAgIGlubmVyIGpvaW4gS2JCdWNodW5nICAgICAgICAgICAgICAgQlVDICBvbiBCV" +
                        "UMuQmdCdWRnZXRJRCA9IEJERy5CZ0J1ZGdldElEDQogICAgICAgaW5uZXIgam9pbiBLYkJ1Y2h1bmdLb" +
                        "3N0ZW5hcnQgICAgICBCVUsgIG9uIEJVSy5LYkJ1Y2h1bmdJRCA9IEJVQy5LYkJ1Y2h1bmdJRA0KICAgI" +
                        "CAgIGlubmVyIGpvaW4gQmdLb3N0ZW5hcnQgICAgICAgICAgICAgS09BICBvbiBLT0EuQmdLb3N0ZW5hc" +
                        "nRJRCA9IEJVSy5CZ0tvc3RlbmFydElEDQogICAgICAgbGVmdCAgam9pbiB2d1VzZXIgICAgICAgICAgI" +
                        "CAgICAgICBLVVNSIG9uIEtVU1IuVXNlcklEID0gQEthc3NlVXNlcklEDQp3aGVyZSAgQlVDLktiQnVja" +
                        "HVuZ0lEID0gQEtiQnVjaHVuZ0lEIGFuZA0KICAgICAgIEJVQy5LYkF1c3phaGx1bmdzQXJ0Q29kZSA9I" +
                        "DEwMyBhbmQgLS0gY2FzaA0KICAgICAgIEJVSy5CZXRyYWcgPD4gMA0Kb3JkZXIgYnkgS09BLktvbnRvT" +
                        "nIsIEJVSy5CZ1Bvc2l0aW9uSURAAAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd2luZywgV" +
                        "mVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkN" +
                        "TBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DAAAAXBMAA" +
                        "AL/2P/gABBKRklGAAEAAQBgAGAAAP/+AB9MRUFEIFRlY2hub2xvZ2llcyBJbmMuIFYxLjAxAP/bAEMAC" +
                        "AYGBwYFCAcHBwoJCAoNFg4NDAwNGxMUEBYgHCIhHxwfHiMoMysjJjAmHh8sPS0wNTY5OjkiKz9DPjhDM" +
                        "zg5N//bAEMBCQoKDQsNGg4OGjckHyQ3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3N" +
                        "zc3Nzc3Nzc3Nzc3N//AABEIADIA2wMBEQACEQEDEQH/xAAfAAABBQEBAQEBAQAAAAAAAAAAAQIDBAUGB" +
                        "wgJCgv/xAC1EAACAQMDAgQDBQUEBAAAAX0BAgMABBEFEiExQQYTUWEHInEUMoGRoQgjQrHBFVLR8CQzY" +
                        "nKCCQoWFxgZGiUmJygpKjQ1Njc4OTpDREVGR0hJSlNUVVZXWFlaY2RlZmdoaWpzdHV2d3h5eoOEhYaHi" +
                        "ImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4eLj5OXm5+jp6vHy8" +
                        "/T19vf4+fr/xAAfAQADAQEBAQEBAQEBAAAAAAAAAQIDBAUGBwgJCgv/xAC1EQACAQIEBAMEBwUEBAABA" +
                        "ncAAQIDEQQFITEGEkFRB2FxEyIygQgUQpGhscEJIzNS8BVictEKFiQ04SXxFxgZGiYnKCkqNTY3ODk6Q" +
                        "0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqCg4SFhoeIiYqSk5SVlpeYmZqio6Slpqeoqaqys" +
                        "7S1tre4ubrCw8TFxsfIycrS09TV1tfY2dri4+Tl5ufo6ery8/T19vf4+fr/2gAMAwEAAhEDEQA/APbNc" +
                        "8QaZ4csftep3IijJ2ooUs8jYztVRyx47UAYnhX4i6N4vvFtdOhvY5GgNwPtEOwFA231Pc/zoAt65468P" +
                        "6A3l3N6Jpw5RoLUedIhCljuVeV4B60AZDfFrw2m4NHqQ25zmxk4xnPb/Zb8jQAv/C2fDecCPUief+XGT" +
                        "tn29j+VAG/ofivRfEMSNp99GZm3f6O7BZl2sVOUPI5B7UAYWs/FTQNC1iXTLuDUGlhnSB3itt6hmGR0O" +
                        "Tx6D1xmgDrdN1Ky1fT4b/T7lLi1mGUkQ5B/z6UAWqAOF8R/F3wn4Z1STTLm4nubyI4ljtYt/ln0Y8DPt" +
                        "QBueHvGWg+KNHl1TSr9ZbaDPnbgVaLAz8wPI4oAv6Prem6/YC+0m8ju7UsVEkZ4yOooAv0AFAGE3i7SE" +
                        "8YL4WMz/wBqtD5wj8s7duM/e6dqALeneINJ1a9vbPT7+K4ubF9lxGh5jbJGD+R/KgB2t6zZeHtGudW1F" +
                        "2S0tlDSMqliBkDoPc0AcJ/wvjwH/wA/9z/4Cv8A4UAdD/wsTw7/AMIYPFf2iX+yS+wP5Lbs7tv3evWgC" +
                        "5pvjHRtW1+bRLSaRr6G3W5ZWiZRsYKQcnjPzDigDeoAw7PxbpN94pvfDlvLIdSskEkyGMhQOOjdD94UA" +
                        "blAGFqni7SNG8QaZol5M6X2pHFuqxkhucckdKAN2gAoAKACgDi9Xa3g+KGlSaoQtpPp8lvZM5wq3BYFx" +
                        "nszJgD1wQKAOb1DwO/g0w+IFkfWbHTIgJLXb5UohQ5VgykCQoM8MORQBxA0KeSXTtYt4Fi/s27xdTQht" +
                        "zyXBaR1aRAWIjVkUnnliKANSLTmjlt2Os7hFdSXBG69GQ4b5f8AV8fePPegAtLB7VrJzrJc2rTMfnvRv" +
                        "3kn/nnxjP40AZmkWDeEoNP1DUdPM0wb+1cBNlxPFKpiki3HBJVmRtp6hvUUAeh6B8N5re6i1XUr1bQfa" +
                        "I7xrGIbxH5eTHGZnJYhSST0GaANjwI0M+oeJ7zTgP7HuNQ3WzL9x2CKJXT2Lg8jqQTQB2dAHg8OjeNPA" +
                        "XizXNY8MafZeI9N1GcySbHDSpli23g5B5PTIPFAB4Xu9F8QaN4ug0C0uvCniFozNfR5MoZVyWCq2AoyS" +
                        "CMDGeKALPwUt9Wsvhpf6rbatGUxMtvaXQCQQyDnzGfrj1oA5nWvG+taNpCapbfEZtU1pZx5tpa2++0VS" +
                        "TxuKgen5/jQB2niHxR4k8TeNtD8IaHqX9j+fYpe3dyibm5XdtXPoP5+1AGJpul63aftALp+p6x9rvP7L" +
                        "kSG/EQV9pRtrFem4HP1xQA/4SaPqq/EfxSx8QTFbK8xdKYlxenLjLf3eeeKAPdZ0hkgdbhUaHHzCQArj" +
                        "3zQB8/a63/C3/Gy+G/DdvDa+HdPcPd3scKjzCOMg4+oUd+p9gDq/Ht3c+B5fA+h+HZfsWnS3YgliVQRI" +
                        "m5OuR15PPvQBd8WeIdV034x+E9Hs7sxWF7GTcRBRiTBbqcZ7CgDmNP1Lx/4w8beK9B0zxEun2Vjdt+/a" +
                        "MM8ahyFRceuDk+1AG1Z+MtTs/ip4wtry6abS9J043CQbQMFVQnnGeefzoAytCT4k+NPDD+L7DxR9luZZ" +
                        "GNppqxKISqtjBJ+h65/wAKfxAPiC68e/DwSC3stfeMqxP7yOKTcAWx3HfFAG14e1XxT4b+MkfhLWNffW" +
                        "bO9tTOkksYUocMeAOnKkY6cigD2GgAoAKAPOfiDqN9qGo3Xhq1g01re30ttTuTfoziRQxUKuCNpG0nd1" +
                        "HGKAOOl8T6xHoktodSu4dIgitmF/IBLJbNPFkQTKeZUAYDcPmGQecUAc9NLrGh23h600/8Ata3sorfaV" +
                        "sJ3aLVJt+5jHJGerISQSONuD0oA9U8O6Jo/ifS1vrDxL4lGDslhk1SVZIXHVHXPBFAGv/wgNv8A9DF4j" +
                        "/8ABrL/AI0AeSaxvulv3N5ffYNP1ZJ7DWdSkaSONYwFdVyd0rM6kbAOcD0oA0NT8QaxqWlGxv5ZzYi2t" +
                        "7i1jupADqCzTbBJOUPyoCc+WvYgE0AeleCNUvZJ9X8P6hHZ+foskcQkso/LidGTcoC/wkdCPpQB11AHk" +
                        "S/DXxf4T1rULrwNr1pBY38nmPa3keQhyenBzj8KANfwd8NbrR5tc1TXdWF9rWsxNFNNEm1I1PXA79vTo" +
                        "KAMvw78LfEGmeD9Z8JX2uWsmk3cTC3MMRDpISDubPbjpnvQBm3Hwr8baj4Ji8KXOs6Pb6dalTH5ED75i" +
                        "Dxvb8SeByetAG94g+HGsyaloXiHw7qlvZ69ptoltL5qkxTKFx9e5/DHTFACeH/h34ktfiRD4w13W7S9m" +
                        "Nu0cscURTaSpAC+w4/WgCfQvAPiDw58RNT1qx1i1Oj6pOZrm3eM+YRyQAenBbr6UAdH480DUvE3hG70f" +
                        "Sr9bGe4Kq0rZwUz8y8c8jigDzbQPhZ8RPC9g1lo3i7T7SBnLsqwEktxySVyelAGz4h+G3ifxF4V0hL3x" +
                        "DBL4i0u6aeO6KEIwJBA4HBGBzigBLf4deLL7xzofinxBr1lcz2HDwwxFFVecBeOTySScUAb3gzwPeeGf" +
                        "FvijWLi7hmi1efzYkjBDINzHBz/ALw6elAEFn8PJk+IfiLX7y5hl0/V7Q2xt1BDgEKDk9P4TQBzcHwz8" +
                        "c6Vo9x4X0jxTaR+H5nJWR4mFxGhOSoI/wAfyoA3L34Z3DeIvB17aagrWvh9Asn2jc0s3OSc+p5oAv3ng" +
                        "e8uPi5YeMVu4FtLa1MDQEHeSQ4z6fxD8qAO4oAKACgDyr40QWkljYC1uHTxFOTbW1vC4V7mFyBLGf8AZ" +
                        "xznsaAOU0DxDD9rtNRurNm06C5OrXyLIu6AyHybclTyyxouTjpkHtQBqfEzwrpmmeItCuNNsTsvXuDJb" +
                        "xxyzR7woIdYo2BDdclce9AGFp41rwxqg1jw/p93HMo2zWUWkXSJeDPRi7NhuuGoA9v8MeJ7DxTpf2uz3" +
                        "xyxt5dxbSjbLbyDqjr2P86AOJ8J6ZoVjD4i8X6hAGFpqN7JCXJZII1Y58tM7QTg8jk0Aed6xdXS2i6dD" +
                        "pci3K+ZbWtn5qmRLe6HmQKxHAZJEHB5AxQB678Km0ybwbHdWV8b29uX83UZnOZDckAuG9McAD0AoA7eg" +
                        "DlT4q1K/u7tNA0H+0La0maCS4lulgV5F4ZU4JbB4ycDIoA0vD3iGDX7e4It5bS7tJTDdWs2N8L4BwccE" +
                        "EEEEcEGgDYoAKAKl3dzW11ZRRWUk6XEhSSRCMQjaTub2yAPxoAt0AZl9rMdjrek6Y0LO+otKFcEYTYm4" +
                        "5+tAGnQAUAcve+KdRXxHeaNpegPfvaRRyyyfakiA35wAD1+6aAJ9M8VfadWXSNU0y40rUZELwxzFXSdR" +
                        "97Y6kgkdxwfagDWsLua7FyZrKS18qd4kEhB8xQeHGOx7UAW6ACgAoAZLIsMTyNnailjj0FAFbStSt9Y0" +
                        "m11K13fZ7qNZY94wdpGRkUAXKACgDjviPFZW/hi51U2cEmqxRm2sZnUF45JiIxtPb72fwoA4WcWz3dre" +
                        "zWiHwZaWj+Hxdrww3AI059Y9y7M9jzQBX8S3R1b4caTNcywzaj4auxBqcTAuURcxNIUVgxB+Vuo60AZK" +
                        "6aHUMmmllIyCNCvMEf9/qAIDcX3g64PiTTVlsXtk/fxDR54Yrpcj5JGd2x7HsaAOsknitvA+heG9Tnit" +
                        "7jUJ31HVY2cZt7be1w4cdRnKpz1yaAM+7nv10fWZ7nTxZRa9M2r6Oz/AOsWaIq4jc9mdEDAe7CgD13w3" +
                        "b6THo8V5o9nBbW+oAXZEKBQ7OAdxx3oA16AOG0/SdUtknv/AAXrtlNpd5PJOLS8hLxq7Md+yRSGA3Z4I" +
                        "ODmgClqHiu/j0PX7Z7CLSfEVu9vFNLEQ6FZmCJMrYBOBu4PQigCbxL4YsfC/hm61zR5J7fVNOj88XL3D" +
                        "u0+3llkycMGGQfrxigCXxfZ6RI1vMunSXev6mAlrB9plQZC8u4VgAijknHt1NAEL6O/heTwPpUV7cTY1" +
                        "CTz5XkYmVjBKTnJ6Z6DtgUAVJbTSdZvdVlNhqviK5aeRVuoSYYrfBwI43LgDbjllzzmgBNCv7rU/wDhW" +
                        "t5eytLcyxXBkdjksfJIyfU8UAZukPb+I9MfVtW8P6/fX93JIyXVswCwKHIRYsSDaFAHbJOc0Aei+EptU" +
                        "m8LWDa1E8eohCswkwGJBIDHBIyQAT9aAMrR/wDkqHib/r0tP5PQAeN9v9o+ExH/AMfX9sR+Xjrt2P5n4" +
                        "bc0ActeavfQ6Je2sUl6/wBu8UTWbm1bMwiyzFYySMEhMdeMmgC9YQPp/iDSpfD3hrWdOiaYRXy3BHkvC" +
                        "QfmOZD8ynBBAyec0AP8K+FrHxFo+oXGsyXF5I1/dJCWncfZ1ErABMHg8Zz1oArQprGu+B/C11LHPq1tC" +
                        "X/tC1jn8uW6VcorZyN2CASpIyaALekWmh3kOv6Xb/2haQNbrJJo92HjaEjP7xDnO1iB904ytAGVbA6D8" +
                        "JPD0elJdpLq720M7WzlpsMMv5e44ViFIGMYzQBftLdrDW9Km8O+Gda07/SFivPtBHkyQHIJbMhywOCD1" +
                        "6+tAHpdAGH4q8PN4j0uK3ivDaXFvcR3MEuwOokQ5G5Tww9qAItA8J2ukeFDoN1J9vhl8wz+YgVX8wksA" +
                        "o4VeTgDpQBj+HPhxHomtte3OpG+hjtXs4IngVT5TEEiVh/rSAABnsKAMq6+DenQ3ks+jzQxwyHP2W9ha" +
                        "eOP/cIdWUe2TQBZ0T4R6TZatFqepul5NCQ0VvFF5VujDodhJLEe5/CgCxcfDKC78T3V/cah5mmXdyt3P" +
                        "ZmBd8kgAAUy9THlQdnTigDY8XeFZfEaafLa6h9hu7CVpInaESodyFDlDwTg8HsaANPQNHi8P+H7HSIZX" +
                        "ljtIliDyfebHc0AaVAHJp4QvtMubhvD/iCXTbW4kaVrR7dJ40djlimcFQTk4zjJoAmtPBVium6pb6lcT" +
                        "alcaqALy5mIVnAGFChcBAvYDoeaAIH8HX17FDZax4juNQ0uJlY27QojTbTlRI45YZAzgDOOaAC48Iai3" +
                        "iW91u08STW89yixhTaxyCKMfwKWHAzyfU0AXR4buLiXSZ9S1aW8uNNumuEk8lI9+Y2TaQvGBuJzQBRt/" +
                        "Bt5ZJNY2XiG4t9HlleT7KsKl0DksyLL1AJJ7ZGeDQBLpHgmHSF0ONb+aWPRmm+zq6qPkdSoUkddoPXvQ" +
                        "Az/AIRC/smuoNF8RT6dp9zI0htxAkhiZjlvLY/dBJJxzgnigDoNK0y10XSrbTbNStvboETcck+5Pck8k" +
                        "0AYd74UvpPEd3rOmeIJ9Oku4o4pY1t45FOzOD8w46mgCfS/CqWeqrq2o6jdarqSIY45rjaFhU9QiKAq5" +
                        "wMnqaAIpPBdnLpV9ZNdTq1zfvqEc6EK8EpbcCp9j69RQAtt4YvZdUtL3W9bk1L7ES9vCIFhRXIxvYD7z" +
                        "AE47DJ4oA0tC0WLQbCS0ileVXuJZ9zAAgu5Yj8M4oAxk8Dra6VpNvp+qT2t7pRk+z3WxWyHJLKynhgeP" +
                        "yGKALmmeGZLfULrUtU1KTUb+4gFtv8ALESRxZztVR0yTkkknpQBUtfBKR+Ff+Efu9UnubeFkNnKEWOW2" +
                        "2EFMMOpUgcmgCWDwvfT6jZ3Wt67JqSWL+bBCIFhTzMEB22/eIBOOg74oA6agAoAKACgAoAKACgAoAKAC" +
                        "gAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoA//9kLQQABAAAA/////wEAAAAAAAAADAIAA" +
                        "AAbRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy52Ni4yBQEAAAAsRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VS" +
                        "S5TZXJpYWxpemFibGVTdHJpbmcBAAAABVZhbHVlAQIAAAAGAwAAAOIEe1xydGYxXGFuc2lcYW5zaWNwZ" +
                        "zEyNTJcZGVmZjB7XGZvbnR0Ymx7XGYwXGZuaWwgQXJpYWw7fXtcZjFcZm5pbFxmY2hhcnNldDAgQXJpY" +
                        "Ww7fXtcZjJcZm5pbCBUaW1lcyBOZXcgUm9tYW47fX0NCntcY29sb3J0YmwgO1xyZWQwXGdyZWVuMFxib" +
                        "HVlMDt9DQpcdmlld2tpbmQ0XHVjMVxwYXJkXGNmMVxsYW5nMjA1NVxmMFxmczIwIEVpbmxcZjFcJ2Y2X" +
                        "GYwIHNiYXIgdm9uIE1vLUZyIDA4OjMwIC0xNjozMCBVaHIgYmVpIGRlciBTdGFkdGthc3NlIFpcZjFcJ" +
                        "2ZjXGYwIHJpY2gsIFxmMSBTdGFkdGhhdXNxdWFpIDE3LCA4MDAxIFxmMCBaXGYxXCdmY1xmMCByaWNoX" +
                        "GNmMFxmMlxmczI0XHBhcg0KXGZzMThccGFyDQpcY2YxXGYwXGZzMjAgQXVzemFobHVuZyBlcmZvbGd0I" +
                        "GdlZ2VuIGdcZjFcJ2ZjXGYwIGx0aWdlbiBhbXRsaWNoZW4gQXVzd2VpczogSUQsIFBhc3MsIEF1c2xcZ" +
                        "jFcJ2U0XGYwIG5kZXJhdXN3ZWlzLCBGXGYxXCdmY1xmMCBocmVyc2NoZWluLiBccGFyDQpJc3Qga2Vpb" +
                        "iBBdXN3ZWlzIHZvcmhhbmRlbiwgYml0dGUgbWl0IHp1c3RcZjFcJ2U0XGYwIG5kaWdlci9tIFNvemlhb" +
                        "GFyYmVpdGVyL2luIEtvbnRha3QgYXVmbmVobWVuLlxjZjBcZjJcZnMyNFxwYXINCn0NCgs=";
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
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrControl1 = new DevExpress.XtraReports.UI.XRControl();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
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
                        this.xrLabel25,
                        this.xrLine2,
                        this.xrLabel24,
                        this.xrLine1,
                        this.xrControl1,
                        this.xrLabel21,
                        this.xrLabel20,
                        this.xrLabel19,
                        this.xrLabel18,
                        this.xrLabel17,
                        this.xrLabel16,
                        this.xrLabel15,
                        this.xrLabel14,
                        this.xrLabel13});
            this.PageFooter.Dpi = 254F;
            this.PageFooter.Height = 650;
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
            this.xrLabel3.Location = new System.Drawing.Point(1122, 376);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(550, 63);
            this.xrLabel3.Text = "Wirtschaftliche Hilfe";
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
            this.xrLabel5.Text = "W";
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
            this.xrRichText1.Location = new System.Drawing.Point(169, 444);
            this.xrRichText1.Name = "xrRichText1";
            this.xrRichText1.ParentStyleUsing.UseFont = false;
            this.xrRichText1.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichText1.RtfText")));
            this.xrRichText1.Size = new System.Drawing.Size(1567, 191);
            // 
            // xrLabel25
            // 
            this.xrLabel25.Dpi = 254F;
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 11F);
            this.xrLabel25.Location = new System.Drawing.Point(1058, 42);
            this.xrLabel25.Multiline = true;
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel25.ParentStyleUsing.UseFont = false;
            this.xrLabel25.Size = new System.Drawing.Size(170, 64);
            this.xrLabel25.Text = "Stempel";
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 254F;
            this.xrLine2.ForeColor = System.Drawing.Color.Black;
            this.xrLine2.LineWidth = 3;
            this.xrLine2.Location = new System.Drawing.Point(1228, 85);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.ParentStyleUsing.UseBackColor = false;
            this.xrLine2.ParentStyleUsing.UseBorderColor = false;
            this.xrLine2.ParentStyleUsing.UseBorders = false;
            this.xrLine2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine2.ParentStyleUsing.UseFont = false;
            this.xrLine2.ParentStyleUsing.UseForeColor = false;
            this.xrLine2.Size = new System.Drawing.Size(508, 10);
            // 
            // xrLabel24
            // 
            this.xrLabel24.Dpi = 254F;
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel24.ForeColor = System.Drawing.Color.Black;
            this.xrLabel24.Location = new System.Drawing.Point(153, 127);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel24.ParentStyleUsing.UseBackColor = false;
            this.xrLabel24.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel24.ParentStyleUsing.UseBorders = false;
            this.xrLabel24.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel24.ParentStyleUsing.UseFont = false;
            this.xrLabel24.ParentStyleUsing.UseForeColor = false;
            this.xrLabel24.Size = new System.Drawing.Size(1566, 39);
            this.xrLabel24.Text = "(Unterschriftsberechtigte/r gemäss Unterschriftenkarte)";
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 254F;
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.LineWidth = 3;
            this.xrLine1.Location = new System.Drawing.Point(386, 85);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(614, 10);
            // 
            // xrControl1
            // 
            this.xrControl1.BackColor = System.Drawing.Color.Empty;
            this.xrControl1.BorderColor = System.Drawing.Color.Gray;
            this.xrControl1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrControl1.Dpi = 254F;
            this.xrControl1.Location = new System.Drawing.Point(148, 423);
            this.xrControl1.Name = "xrControl1";
            this.xrControl1.ParentStyleUsing.UseBackColor = false;
            this.xrControl1.ParentStyleUsing.UseBorderColor = false;
            this.xrControl1.ParentStyleUsing.UseBorders = false;
            this.xrControl1.ParentStyleUsing.UseBorderWidth = false;
            this.xrControl1.ParentStyleUsing.UseFont = false;
            this.xrControl1.ParentStyleUsing.UseForeColor = false;
            this.xrControl1.Size = new System.Drawing.Size(1588, 212);
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
            this.xrLabel21.Text = "Sozialarbeiter/in";
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
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 254F;
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 11F);
            this.xrLabel13.Location = new System.Drawing.Point(153, 0);
            this.xrLabel13.Multiline = true;
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel13.ParentStyleUsing.UseFont = false;
            this.xrLabel13.Size = new System.Drawing.Size(212, 106);
            this.xrLabel13.Text = "Unterschrift\r\n(Blau)";
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

set @KbBuchungID = {KbBuchungID}
set @KasseUserID = {KasseUserID}

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

select BgPositionID         = BUK.BgPositionID,
       Barcodetext          = convert(varchar(20),convert(bigint,BUC.BelegNr)),
       Klient               = PRS.NameVorname,
       PersonenNr           = PRS.BaPersonID,
       GueltigAb            = convert(varchar,@Valuta,104),
       GueltigBis           = convert(varchar,dateadd(day, 
                                case datepart(weekday, @Valuta)
                                when 1 then 2 -- So
                                when 2 then 2 -- Mo
                                when 3 then 2 -- Di
                                when 4 then 2 -- Mi 
                                when 5 then 4 -- Do
                                when 6 then 4 -- Fr
                                when 7 then 3 -- Sa
                                end,
                                @Valuta),104),
       AuszahlungAn         = IsNull(BUC.BeguenstigtName + CHAR(13) + CHAR(10),'''') +
                              IsNull(BUC.BeguenstigtName2 + char(13) + char(10),'''') +
                              IsNull(BUC.BeguenstigtPostfach + char(13) + char(10), '''') +
                              IsNull(BUC.BeguenstigtStrasse + IsNull('' '' + BUC.BeguenstigtHausNr, '''') + char(13) + char(10), '''') +
                              IsNull(IsNull(BUC.BeguenstigtPLZ + '' '', '''') + IsNull(BUC.BeguenstigtOrt, ''''),''''),
       Konto                = BUC.SollKtoNr,
       LA                   = KOA.KontoNr,
       Text                 = BUK.Buchungstext,
       Monatsbudget         = dbo.fnXMonat(BDG.Monat) + '' '' + convert(varchar,BDG.Jahr),
       Betrag               = BUK.Betrag,
       VerwPeriode          = convert(varchar,BUK.VerwPeriodeVon,104) + isnull('' - '' + convert(varchar,BUK.VerwPeriodeBis,104),''''),
       inWorten             = @InWorten,
       Erstelldatum         = convert(varchar,getdate(),104),
       Organisationseinheit = isNull(USR.Sozialzentrum + '', '','''') + USR.OrgUnit, 
       Belegersteller       = KUSR.NameVorname + isNull('' ('' + KUSR.Phone + '')'',''''),
       Sozialarbeiter       = USR.NameVorname + isNull('' ('' + USR.Phone + '')'','''')
from   FaLeistung LEI
       inner join vwPerson                PRS  on PRS.BaPersonID = LEI.BaPersonID
       inner join vwUser                  USR  on USR.UserID = LEI.UserId
       inner join BgFinanzplan            FPL  on FPL.FaLeistungID = LEI.FaLeistungID
       inner join BgBudget                BDG  on BDG.BgFinanzplanID = FPL.BgFinanzplanID
       inner join KbBuchung               BUC  on BUC.BgBudgetID = BDG.BgBudgetID
       inner join KbBuchungKostenart      BUK  on BUK.KbBuchungID = BUC.KbBuchungID
       inner join BgKostenart             KOA  on KOA.BgKostenartID = BUK.BgKostenartID
       left  join vwUser                  KUSR on KUSR.UserID = @KasseUserID
where  BUC.KbBuchungID = @KbBuchungID and
       BUC.KbAuszahlungsArtCode = 103 and -- cash
       BUK.Betrag <> 0
order by KOA.KontoNr, BUK.BgPositionID' ,  N'wKassenbeleg' ,  null , 10,  null )
