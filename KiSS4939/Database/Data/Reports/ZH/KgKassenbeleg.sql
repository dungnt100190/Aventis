insert [XQuery]([QueryName], [UserText], [QueryCode], [LayoutXML], [ParameterXML], [SQLquery], [ContextForms], [ParentReportName], [ReportSortKey], [RelationColumnName])
values ( N'KgKassenbeleg' ,  N'K - Kassenbeleg' , 1,  N'/// <XRTypeInfo>
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
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private DevExpress.XtraReports.UI.XRLabel txtIntern;
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
        private DevExpress.XtraReports.UI.XRLabel xrLabel23;
        private DevExpress.XtraReports.UI.XRLine Line6;
        private DevExpress.XtraReports.UI.XRLine Line4;
        private DevExpress.XtraReports.UI.XRLabel Betrag1;
        private DevExpress.XtraReports.UI.XRLabel Label19;
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
                        "GEAdABlAG0AZQBuAHQAAAAAACZ4AHIAUABpAGMAdAB1AHIAZQBCAG8AeAAxAC4ASQBtAGEAZwBlAGQPA" +
                        "AAmeAByAFIAaQBjAGgAVABlAHgAdAAxAC4AUgB0AGYAVABlAHgAdABjIwAAAeEeZGVjbGFyZSBAS2dCd" +
                        "WNodW5nSUQgaW50DQpkZWNsYXJlIEBLYXNzZVVzZXJJRCBpbnQNCmRlY2xhcmUgQEJldHJhZ1RleHQgd" +
                        "mFyY2hhcigyMCkNCmRlY2xhcmUgQEluV29ydGVuIHZhcmNoYXIoMjAwKQ0KZGVjbGFyZSBAVmFsdXRhI" +
                        "GRhdGV0aW1lDQoNCnNldCBAS2dCdWNodW5nSUQgPSBudWxsDQpzZXQgQEthc3NlVXNlcklEID0gbnVsb" +
                        "A0KDQpzZWxlY3QgQEJldHJhZ1RleHQgPSBjb252ZXJ0KHZhcmNoYXIsIEJldHJhZywgMSksDQogICAgI" +
                        "CAgQFZhbHV0YSAgICAgPSBjb252ZXJ0KGRhdGV0aW1lLGRiby5mbk1BWChWYWx1dGFEYXR1bSxnZXRkY" +
                        "XRlKCkpKQ0KZnJvbSAgIEtnQnVjaHVuZw0Kd2hlcmUgIEtnQnVjaHVuZ0lEID0gQEtnQnVjaHVuZ0lED" +
                        "QoNCnNldCBASW5Xb3J0ZW4gPSAnJw0Kd2hpbGUgbGVuKEBCZXRyYWdUZXh0KSA+IDAgYmVnaW4NCiAga" +
                        "WYgbGVmdChAQmV0cmFnVGV4dCwxKSA9ICcuJw0KICAgIHNldCBASW5Xb3J0ZW4gPSBASW5Xb3J0ZW4gK" +
                        "yAnLicNCiAgZWxzZQ0KICAgIGlmIEBJbldvcnRlbiA8PiAnJyBhbmQgcmlnaHQoQEluV29ydGVuLDEpI" +
                        "Dw+ICcuJyBzZXQgQEluV29ydGVuID0gQEluV29ydGVuICsgJy0nDQoNCiAgc2V0IEBJbldvcnRlbiA9I" +
                        "EBJbldvcnRlbiArDQogICAgY2FzZSBsZWZ0KEBCZXRyYWdUZXh0LDEpDQogICAgd2hlbiAnMCcgdGhlb" +
                        "iAnTnVsbCcNCiAgICB3aGVuICcxJyB0aGVuICdFaW5zJw0KICAgIHdoZW4gJzInIHRoZW4gJ1p3ZWknD" +
                        "QogICAgd2hlbiAnMycgdGhlbiAnRHJlaScNCiAgICB3aGVuICc0JyB0aGVuICdWaWVyJw0KICAgIHdoZ" +
                        "W4gJzUnIHRoZW4gJ0bDvG5mJw0KICAgIHdoZW4gJzYnIHRoZW4gJ1NlY2hzJw0KICAgIHdoZW4gJzcnI" +
                        "HRoZW4gJ1NpZWJlbicNCiAgICB3aGVuICc4JyB0aGVuICdBY2h0Jw0KICAgIHdoZW4gJzknIHRoZW4gJ" +
                        "05ldW4nDQogICAgZWxzZSAnJw0KICAgIGVuZA0KDQogIHNldCBAQmV0cmFnVGV4dCA9IHN1YnN0cmluZ" +
                        "yhAQmV0cmFnVGV4dCwyLDIwMCkNCmVuZA0Kc2V0IEBJbldvcnRlbiA9ICcqJyArIEBJbldvcnRlbiArI" +
                        "CcqJw0KDQpzZWxlY3QgQmFyY29kZXRleHQgICAgICAgICAgPSBjb252ZXJ0KHZhcmNoYXIoMjApLA0KI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBjb252ZXJ0KGJpZ2ludCxLZ0J1Y2h1bmdJR" +
                        "CkgKw0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAoc2VsZ" +
                        "WN0IEZpcnN0SUQgZnJvbSBQc2NkS2V5U291cmNlIHdoZXJlIEtleU5hbWUgPSAnQUsnKSksDQogICAgI" +
                        "CAgS2xpZW50ICAgICAgICAgICAgICAgPSBQUlMuTmFtZVZvcm5hbWUsDQogICAgICAgUGVyc29uZW5Oc" +
                        "iAgICAgICAgICAgPSBQUlMuQmFQZXJzb25JRCwNCiAgICAgICBHdWVsdGlnQWIgICAgICAgICAgICA9I" +
                        "GNvbnZlcnQodmFyY2hhcixAVmFsdXRhLDEwNCksDQogICAgICAgR3VlbHRpZ0JpcyAgICAgICAgICAgP" +
                        "SBjYXNlIGRhdGVwYXJ0KHdlZWtkYXksIEBWYWx1dGEpDQogICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICB3aGVuIDUgdGhlbiBjb252ZXJ0KHZhcmNoYXIsZGF0ZWFkZChkYXksIDExLCBAVmFsdXRhKSwxM" +
                        "DQpICAtLSBEbw0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgd2hlbiA2IHRoZW4gY29udmVyd" +
                        "Ch2YXJjaGFyLGRhdGVhZGQoZGF5LCAxMSwgQFZhbHV0YSksMTA0KSAgLS0gRnINCiAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgIHdoZW4gNyB0aGVuIGNvbnZlcnQodmFyY2hhcixkYXRlYWRkKGRheSwgM" +
                        "TAsIEBWYWx1dGEpLDEwNCkgIC0tIFNhDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICBlbHNlI" +
                        "GNvbnZlcnQodmFyY2hhcixkYXRlYWRkKGRheSwgOSwgQFZhbHV0YSksMTA0KQ0KICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgZW5kLA0KICAgICAgIEF1c3phaGx1bmdBbiAgICAgICAgID0gY2FzZSB3a" +
                        "GVuIEJVQy5NaXR0ZWlsdW5nWmVpbGUxIGlzIG51bGwNCiAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgIHRoZW4gUFJTLk5hbWVWb3JuYW1lICsNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgaXNOdWxsKGNoYXIoMTMpICsgY2hhcigxMCkgKyBQUlMuV29obnNpdHpTdHJhc3NlSGF1c05yLCcnK" +
                        "SArDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIGlzTnVsbChjaGFyKDEzKSArIGNoY" +
                        "XIoMTApICsgUFJTLldvaG5zaXR6UExaT3J0LCcnKQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgZWxzZSBCVUMuTWl0dGVpbHVuZ1plaWxlMSArDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgIGlzTnVsbChjaGFyKDEzKSArIGNoYXIoMTApICsgQlVDLk1pdHRlaWx1bmdaZWlsZTIsJycpI" +
                        "CsNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgaXNOdWxsKGNoYXIoMTMpICsgY2hhc" +
                        "igxMCkgKyBCVUMuTWl0dGVpbHVuZ1plaWxlMywnJykNCiAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgIGVuZCwNCiAgICAgICBLb250byAgICAgICAgICAgICAgICA9IEJVQy5Tb2xsS3RvTnIsDQogICAgI" +
                        "CAgVGV4dCAgICAgICAgICAgICAgICAgPSBCVUMuVGV4dCwNCiAgICAgICBNb25hdHNidWRnZXQgICAgI" +
                        "CAgICA9IGRiby5mblhNb25hdChCREcuTW9uYXQpICsgJyAnICsgY29udmVydCh2YXJjaGFyLEJERy5KY" +
                        "WhyKSwNCiAgICAgICBCZXRyYWcgICAgICAgICAgICAgICA9IEJVQy5CZXRyYWcsDQogICAgICAgaW5Xb" +
                        "3J0ZW4gICAgICAgICAgICAgPSBASW5Xb3J0ZW4sDQogICAgICAgRXJzdGVsbGRhdHVtICAgICAgICAgP" +
                        "SBjb252ZXJ0KHZhcmNoYXIsZ2V0ZGF0ZSgpLDEwNCksDQogICAgICAgT3JnYW5pc2F0aW9uc2Vpbmhla" +
                        "XQgPSBpc051bGwoU1ouSXRlbU5hbWUgKyAnLCAnLCcnKSArIFVTUi5PcmdFaW5oZWl0TmFtZSwgLS0gU" +
                        "ExaL09ydCBuaWNodCBhbHMgZWluemVsbmVzIEZlbGQgVmVyZsO8Z2Jhcg0KICAgICAgIEJlbGVnZXJzd" +
                        "GVsbGVyICAgICAgID0gS1VTUi5OYW1lVm9ybmFtZSArIGlzTnVsbCgnICgnICsgS1VTUi5QaG9uZSArI" +
                        "CcpJywnJyksDQogICAgICAgU296aWFsYXJiZWl0ZXIgICAgICAgPSBVU1IuTmFtZVZvcm5hbWUgKyBpc" +
                        "051bGwoJyAoJyArIFVTUi5QaG9uZSArICcpJywnJykNCmZyb20gICBGYUxlaXN0dW5nIExFSQ0KICAgI" +
                        "CAgIGlubmVyIGpvaW4gdndQZXJzb24gICAgICAgICAgICAgICAgUFJTICBvbiBQUlMuQmFQZXJzb25JR" +
                        "CA9IExFSS5CYVBlcnNvbklEDQogICAgICAgaW5uZXIgam9pbiBLZ0J1ZGdldCAgICAgICAgICAgICAgI" +
                        "CBCREcgIG9uIEJERy5GYUxlaXN0dW5nSUQgPSBMRUkuRmFMZWlzdHVuZ0lEDQogICAgICAgaW5uZXIga" +
                        "m9pbiBLZ1Bvc2l0aW9uICAgICAgICAgICAgICBQT1MgIG9uIFBPUy5LZ0J1ZGdldElEID0gQkRHLktnQ" +
                        "nVkZ2V0SUQNCiAgICAgICBpbm5lciBqb2luIEtnQnVjaHVuZyAgICAgICAgICAgICAgIEJVQyAgb24gQ" +
                        "lVDLktnUG9zaXRpb25JRCA9IFBPUy5LZ1Bvc2l0aW9uSUQNCiAgICAgICBpbm5lciBqb2luIHZ3VXNlc" +
                        "iAgICAgICAgICAgICAgICAgIFVTUiAgb24gVVNSLlVzZXJJRCA9IExFSS5Vc2VySWQNCiAgICAgICBpb" +
                        "m5lciBqb2luIFhPcmdVbml0ICAgICAgICAgICAgICAgIE9SRyAgb24gT1JHLk9yZ1VuaXRJRCA9IFVTU" +
                        "i5PcmdVbml0SUQNCiAgICAgICBpbm5lciBqb2luIFhPcmdVbml0ICAgICAgICAgICAgICAgIFNaICAgb" +
                        "24gU1ouT3JnVW5pdElEID0gT1JHLlBhcmVudElEDQogICAgICAgbGVmdCAgam9pbiB2d1VzZXIgICAgI" +
                        "CAgICAgICAgICAgICBLVVNSIG9uIEtVU1IuVXNlcklEID0gQEthc3NlVXNlcklEDQp3aGVyZSAgUE9TL" +
                        "ktnUG9zaXRpb25zS2F0ZWdvcmllQ29kZSBpbiAoMSwyKSBhbmQgIC0tIEF1c3phaGx1bmdlbg0KICAgI" +
                        "CAgIFBPUy5LZ0F1c3phaGx1bmdzYXJ0Q29kZSA9IDEwMyBhbmQgLS0gY2FzaA0KICAgICAgIEJVQy5LZ" +
                        "0J1Y2h1bmdJRCA9IEBLZ0J1Y2h1bmdJREAAAQAAAP////8BAAAAAAAAAAwCAAAAUVN5c3RlbS5EcmF3a" +
                        "W5nLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49YjAzZjVmN" +
                        "2YxMWQ1MGEzYQUBAAAAFVN5c3RlbS5EcmF3aW5nLkJpdG1hcAEAAAAERGF0YQcCAgAAAAkDAAAADwMAA" +
                        "ABcEwAAAv/Y/+AAEEpGSUYAAQABAGAAYAAA//4AH0xFQUQgVGVjaG5vbG9naWVzIEluYy4gVjEuMDEA/" +
                        "9sAQwAIBgYHBgUIBwcHCgkICg0WDg0MDA0bExQQFiAcIiEfHB8eIygzKyMmMCYeHyw9LTA1Njk6OSIrP" +
                        "0M+OEMzODk3/9sAQwEJCgoNCw0aDg4aNyQfJDc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3N" +
                        "zc3Nzc3Nzc3Nzc3Nzc3Nzc3/8AAEQgAMgDbAwERAAIRAQMRAf/EAB8AAAEFAQEBAQEBAAAAAAAAAAABA" +
                        "gMEBQYHCAkKC//EALUQAAIBAwMCBAMFBQQEAAABfQECAwAEEQUSITFBBhNRYQcicRQygZGhCCNCscEVU" +
                        "tHwJDNicoIJChYXGBkaJSYnKCkqNDU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6g" +
                        "4SFhoeIiYqSk5SVlpeYmZqio6Slpqeoqaqys7S1tre4ubrCw8TFxsfIycrS09TV1tfY2drh4uPk5ebn6" +
                        "Onq8fLz9PX29/j5+v/EAB8BAAMBAQEBAQEBAQEAAAAAAAABAgMEBQYHCAkKC//EALURAAIBAgQEAwQHB" +
                        "QQEAAECdwABAgMRBAUhMQYSQVEHYXETIjKBCBRCkaGxwQkjM1LwFWJy0QoWJDThJfEXGBkaJicoKSo1N" +
                        "jc4OTpDREVGR0hJSlNUVVZXWFlaY2RlZmdoaWpzdHV2d3h5eoKDhIWGh4iJipKTlJWWl5iZmqKjpKWmp" +
                        "6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uLj5OXm5+jp6vLz9PX29/j5+v/aAAwDAQACEQMRA" +
                        "D8A9s1zxBpnhyx+16nciKMnaihSzyNjO1VHLHjtQBieFfiLo3i+8W106G9jkaA3A+0Q7AUDbfU9z/OgC" +
                        "3rnjrw/oDeXc3omnDlGgtR50iEKWO5V5XgHrQBkN8WvDabg0epDbnObGTjGc9v9lvyNAC/8LZ8N5wI9S" +
                        "J5/5cZO2fb2P5UAb+h+K9F8QxI2n30Zmbd/o7sFmXaxU5Q8jkHtQBhaz8VNA0LWJdMu4NQaWGdIHeK23" +
                        "qGYZHQ5PHoPXGaAOt03UrLV9Phv9PuUuLWYZSRDkH/PpQBaoA4XxH8XfCfhnVJNMubie5vIjiWO1i3+W" +
                        "fRjwM+1AG54e8ZaD4o0eXVNKv1ltoM+duBVosDPzA8jigC/o+t6br9gL7SbyO7tSxUSRnjI6igC/QAUA" +
                        "YTeLtITxgvhYzP/AGq0PnCPyzt24z97p2oAt6d4g0nVr29s9Pv4ri5sX2XEaHmNskYP5H8qAHa3rNl4e" +
                        "0a51bUXZLS2UNIyqWIGQOg9zQBwn/C+PAf/AD/3P/gK/wDhQB0P/CxPDv8Awhg8V/aJf7JL7A/ktuzu2" +
                        "/d69aALmm+MdG1bX5tEtJpGvobdbllaJlGxgpByeM/MOKAN6gDDs/Fuk33im98OW8sh1KyQSTIYyFA46" +
                        "N0P3hQBuUAYWqeLtI0bxBpmiXkzpfakcW6rGSG5xyR0oA3aACgAoAKAOL1dreD4oaVJqhC2k+nyW9kzn" +
                        "CrcFgXGezMmAPXBAoA5vUPA7+DTD4gWR9ZsdMiAktdvlSiFDlWDKQJCgzww5FAHEDQp5JdO1i3gWL+zb" +
                        "vF1NCG3PJcFpHVpEBYiNWRSeeWIoA1ItOaOW3Y6zuEV1JcEbr0ZDhvl/wBXx94896AC0sHtWsnOslzat" +
                        "Mx+e9G/eSf+efGM/jQBmaRYN4Sg0/UNR08zTBv7VwE2XE8UqmKSLccElWZG2nqG9RQB6HoHw3mt7qLVd" +
                        "SvVtB9ojvGsYhvEfl5McZmcliFJJPQZoA2PAjQz6h4nvNOA/se41DdbMv3HYIoldPYuDyOpBNAHZ0AeD" +
                        "w6N408BeLNc1jwxp9l4j03UZzJJscNKmWLbeDkHk9Mg8UAHhe70XxBo3i6DQLS68KeIWjM19HkyhlXJY" +
                        "KrYCjJIIwMZ4oAs/BS31ay+Gl/qttq0ZTEy29pdAJBDIOfMZ+uPWgDmda8b61o2kJqlt8Rm1TWlnHm2l" +
                        "rb77RVJPG4qB6fn+NAHaeIfFHiTxN420Pwhoepf2P59il7d3KJubld21c+g/n7UAYmm6Xrdp+0Aun6nr" +
                        "H2u8/suRIb8RBX2lG2sV6bgc/XFAD/hJo+qr8R/FLHxBMVsrzF0piXF6cuMt/d554oA91nSGSB1uFRoc" +
                        "fMJACuPfNAHz9rrf8Lf8bL4b8N28Nr4d09w93exwqPMI4yDj6hR36n2AOr8e3dz4Hl8D6H4dl+xadLdi" +
                        "CWJVBEibk65HXk8+9AF3xZ4h1XTfjH4T0ezuzFYXsZNxEFGJMFupxnsKAOY0/UvH/jDxt4r0HTPES6fZ" +
                        "WN2379owzxqHIVFx64OT7UAbVn4y1Oz+KnjC2vLpptL0nTjcJBtAwVVCecZ55/OgDK0JPiT408MP4vsP" +
                        "FH2W5lkY2mmrEohKq2MEn6Hrn/AAp/EA+ILrx78PBILey194yrE/vI4pNwBbHcd8UAbXh7VfFPhv4yR+" +
                        "EtY199Zs721M6SSxhShwx4A6cqRjpyKAPYaACgAoA85+IOo32oajdeGrWDTWt7fS21O5N+jOJFDFQq4I" +
                        "2kbSd3UcYoA46XxPrEeiS2h1K7h0iCK2YX8gEsls08WRBMp5lQBgNw+YZB5xQBz00usaHbeHrTT/wC1r" +
                        "eyit9pWwndotUm37mMckZ6shJBI424PSgD1Tw7omj+J9LW+sPEviUYOyWGTVJVkhcdUdc8EUAa//CA2/" +
                        "wD0MXiP/wAGsv8AjQB5JrG+6W/c3l99g0/VknsNZ1KRpI41jAV1XJ3SszqRsA5wPSgDQ1PxBrGpaUbG/" +
                        "lnNiLa3uLWO6kAOoLNNsEk5Q/KgJz5a9iATQB6V4I1S9kn1fw/qEdn5+iyRxCSyj8uJ0ZNygL/CR0I+l" +
                        "AHXUAeRL8NfF/hPWtQuvA2vWkFjfyeY9reR5CHJ6cHOPwoA1/B3w1utHm1zVNd1YX2tazE0U00SbUjU9" +
                        "cDv29OgoAy/Dvwt8QaZ4P1nwlfa5ayaTdxMLcwxEOkhIO5s9uOme9AGbcfCvxtqPgmLwpc6zo9vp1qVM" +
                        "fkQPvmIPG9vxJ4HJ60Ab3iD4cazJqWheIfDuqW9nr2m2iW0vmqTFMoXH17n8MdMUAJ4f+HfiS1+JEPjD" +
                        "XdbtL2Y27RyxxRFNpKkAL7Dj9aAJ9C8A+IPDnxE1PWrHWLU6Pqk5mubd4z5hHJAB6cFuvpQB0fjzQNS8" +
                        "TeEbvR9Kv1sZ7gqrStnBTPzLxzyOKAPNtA+FnxE8L2DWWjeLtPtIGcuyrASS3HJJXJ6UAbPiH4beJ/EX" +
                        "hXSEvfEMEviLS7pp47ooQjAkEDgcEYHOKAEt/h14svvHOh+KfEGvWVzPYcPDDEUVV5wF45PJJJxQBveD" +
                        "PA954Z8W+KNYuLuGaLV5/NiSMEMg3McHP8AvDp6UAQWfw8mT4h+ItfvLmGXT9XtDbG3UEOAQoOT0/hNA" +
                        "HNwfDPxzpWj3HhfSPFNpH4fmclZHiYXEaE5Kgj/AB/KgDcvfhncN4i8HXtpqCta+H0CyfaNzSzc5Jz6n" +
                        "mgC/eeB7y4+Llh4xW7gW0trUwNAQd5JDjPp/EPyoA7igAoAKAPKvjRBaSWNgLW4dPEU5NtbW8LhXuYXI" +
                        "EsZ/wBnHOexoA5TQPEMP2u01G6s2bToLk6tfIsi7oDIfJtyVPLLGi5OOmQe1AGp8TPCumaZ4i0K402xO" +
                        "y9e4MlvHHLNHvCgh1ijYEN1yVx70AYWnjWvDGqDWPD+n3ccyjbNZRaRdIl4M9GLs2G64agD2/wx4nsPF" +
                        "Ol/a7PfHLG3l3FtKNstvIOqOvY/zoA4nwnpmhWMPiLxfqEAYWmo3skJclkgjVjny0ztBODyOTQB53rF1" +
                        "dLaLp0OlyLcr5lta2fmqZEt7oeZArEcBkkQcHkDFAHrvwqbTJvBsd1ZXxvb25fzdRmc5kNyQC4b0xwAP" +
                        "QCgDt6AOVPirUr+7u00DQf7QtrSZoJLiW6WBXkXhlTglsHjJwMigDS8PeIYNft7gi3ltLu0lMN1azY3w" +
                        "vgHBxwQQQQRwQaANigAoAqXd3NbXVlFFZSTpcSFJJEIxCNpO5vbIA/GgC3QBmX2sx2Ot6TpjQs76i0oV" +
                        "wRhNibjn60AadABQBy974p1FfEd5o2l6A9+9pFHLLJ9qSIDfnAAPX7poAn0zxV9p1ZdI1TTLjStRkQvD" +
                        "HMVdJ1H3tjqSCR3HB9qANawu5rsXJmspLXyp3iQSEHzFB4cY7HtQBboAKACgBksiwxPI2dqKWOPQUAVt" +
                        "K1K31jSbXUrXd9nuo1lj3jB2kZGRQBcoAKAOO+I8Vlb+GLnVTZwSarFGbaxmdQXjkmIjG09vvZ/CgDhZ" +
                        "xbPd2t7NaIfBlpaP4fF2vDDcAjTn1j3Lsz2PNAFfxLdHVvhxpM1zLDNqPhq7EGpxMC5RFzE0hRWDEH5W" +
                        "6jrQBkrpodQyaaWUjII0K8wR/3+oAgNxfeDrg+JNNWWxe2T9/ENHnhiulyPkkZ3bHsexoA6ySeK28D6F" +
                        "4b1OeK3uNQnfUdVjZxm3tt7XDhx1GcqnPXJoAz7ue/XR9ZnudPFlFr0zavo7P8A6xZoiriNz2Z0QMB7s" +
                        "KAPXfDdvpMejxXmj2cFtb6gBdkQoFDs4B3HHegDXoA4bT9J1S2Se/8ABeu2U2l3k8k4tLyEvGrsx37JF" +
                        "IYDdngg4OaAKWoeK7+PQ9ftnsItJ8RW728U0sRDoVmYIkytgE4G7g9CKAJvEvhix8L+GbrXNHknt9U06" +
                        "PzxcvcO7T7eWWTJwwYZB+vGKAJfF9npEjW8y6dJd6/qYCWsH2mVBkLy7hWACKOSce3U0AQvo7+F5PA+l" +
                        "RXtxNjUJPPleRiZWMEpOcnpnoO2BQBUltNJ1m91WU2Gq+Irlp5FW6hJhit8HAjjcuANuOWXPOaAE0K/u" +
                        "tT/AOFa3l7K0tzLFcGR2OSx8kjJ9TxQBm6Q9v4j0x9W1bw/r99f3ckjJdWzALAochFixINoUAdsk5zQB" +
                        "6L4Sm1SbwtYNrUTx6iEKzCTAYkEgMcEjJABP1oAytH/AOSoeJv+vS0/k9AB432/2j4TEf8Ax9f2xH5eO" +
                        "u3Y/mfhtzQBy15q99Dol7axSXr/AG7xRNZubVszCLLMVjJIwSEx14yaAL1hA+n+INKl8PeGtZ06JphFf" +
                        "LcEeS8JB+Y5kPzKcEEDJ5zQA/wr4WsfEWj6hcazJcXkjX90kJadx9nUSsAEweDxnPWgCtCmsa74H8LXU" +
                        "sc+rW0Jf+0LWOfy5bpVyitnI3YIBKkjJoAt6RaaHeQ6/pdv/aFpA1uskmj3YeNoSM/vEOc7WIH3TjK0A" +
                        "ZVsDoPwk8PR6Ul2kurvbQztbOWmwwy/l7jhWIUgYxjNAF+0t2sNb0qbw74Z1rTv9IWK8+0EeTJAcglsy" +
                        "HLA4IPXr60Ael0AYfirw83iPS4reK8NpcW9xHcwS7A6iRDkblPDD2oAi0Dwna6R4UOg3Un2+GXzDP5iB" +
                        "VfzCSwCjhV5OAOlAGP4c+HEeia217c6kb6GO1ezgieBVPlMQSJWH+tIAAGewoAyrr4N6dDeSz6PNDHDI" +
                        "c/Zb2Fp44/9wh1ZR7ZNAFnRPhHpNlq0Wp6m6Xk0JDRW8UXlW6MOh2EksR7n8KALFx8MoLvxPdX9xqHma" +
                        "Zd3K3c9mYF3ySAABTL1MeVB2dOKANjxd4Vl8Rpp8trqH2G7sJWkidoRKh3IUOUPBODwexoA09A0eLw/4" +
                        "fsdIhleWO0iWIPJ95sdzQBpUAcmnhC+0y5uG8P+IJdNtbiRpWtHt0njR2OWKZwVBOTjOMmgCa08FWK6b" +
                        "qlvqVxNqVxqoAvLmYhWcAYUKFwEC9gOh5oAgfwdfXsUNlrHiO41DS4mVjbtCiNNtOVEjjlhkDOAM45oA" +
                        "LjwhqLeJb3W7TxJNbz3KLGFNrHIIox/ApYcDPJ9TQBdHhu4uJdJn1LVpby4026a4STyUj35jZNpC8YG4" +
                        "nNAFG38G3lkk1jZeIbi30eWV5PsqwqXQOSzIsvUAkntkZ4NAEukeCYdIXQ41v5pY9Gab7Orqo+R1KhSR" +
                        "12g9e9ADP8AhEL+ya6g0XxFPp2n3MjSG3ECSGJmOW8tj90EknHOCeKAOg0rTLXRdKttNs1K29ugRNxyT" +
                        "7k9yTyTQBh3vhS+k8R3es6Z4gn06S7ijiljW3jkU7M4PzDjqaAJ9L8KpZ6qurajqN1qupIhjjmuNoWFT" +
                        "1CIoCrnAyepoAik8F2culX1k11OrXN++oRzoQrwSltwKn2Pr1FAC23hi9l1S0vdb1uTUvsRL28IgWFFc" +
                        "jG9gPvMATjsMnigDS0LRYtBsJLSKV5Ve4ln3MACC7liPwzigDGTwOtrpWk2+n6pPa3ulGT7PdbFbIcks" +
                        "rKeGB4/IYoAuaZ4Zkt9QutS1TUpNRv7iAW2/wAsRJHFnO1VHTJOSSSelAFS18EpH4V/4R+71Se5t4WQ2" +
                        "coRY5bbYQUww6lSByaAJYPC99PqNnda3rsmpJYv5sEIgWFPMwQHbb94gE46DvigDpqACgAoAKACgAoAK" +
                        "ACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgD//2QtBAAEAAAD/////AQAAAAAAA" +
                        "AAMAgAAABtEZXZFeHByZXNzLlh0cmFSZXBvcnRzLnY2LjIFAQAAACxEZXZFeHByZXNzLlh0cmFSZXBvc" +
                        "nRzLlVJLlNlcmlhbGl6YWJsZVN0cmluZwEAAAAFVmFsdWUBAgAAAAYDAAAA4gR7XHJ0ZjFcYW5zaVxhb" +
                        "nNpY3BnMTI1MlxkZWZmMHtcZm9udHRibHtcZjBcZm5pbCBBcmlhbDt9e1xmMVxmbmlsXGZjaGFyc2V0M" +
                        "CBBcmlhbDt9e1xmMlxmbmlsIFRpbWVzIE5ldyBSb21hbjt9fQ0Ke1xjb2xvcnRibCA7XHJlZDBcZ3JlZ" +
                        "W4wXGJsdWUwO30NClx2aWV3a2luZDRcdWMxXHBhcmRcY2YxXGxhbmcyMDU1XGYwXGZzMjAgRWlubFxmM" +
                        "VwnZjZcZjAgc2JhciB2b24gTW8tRnIgMDg6MzAgLTE2OjMwIFVociBiZWkgZGVyIFN0YWR0a2Fzc2UgW" +
                        "lxmMVwnZmNcZjAgcmljaCwgXGYxIFN0YWR0aGF1c3F1YWkgMTcsIDgwMDEgXGYwIFpcZjFcJ2ZjXGYwI" +
                        "HJpY2hcY2YwXGYyXGZzMjRccGFyDQpcZnMxOFxwYXINClxjZjFcZjBcZnMyMCBBdXN6YWhsdW5nIGVyZ" +
                        "m9sZ3QgZ2VnZW4gZ1xmMVwnZmNcZjAgbHRpZ2VuIGFtdGxpY2hlbiBBdXN3ZWlzOiBJRCwgUGFzcywgQ" +
                        "XVzbFxmMVwnZTRcZjAgbmRlcmF1c3dlaXMsIEZcZjFcJ2ZjXGYwIGhyZXJzY2hlaW4uIFxwYXINCklzd" +
                        "CBrZWluIEF1c3dlaXMgdm9yaGFuZGVuLCBiaXR0ZSBtaXQgenVzdFxmMVwnZTRcZjAgbmRpZ2VyL20gU" +
                        "296aWFsYXJiZWl0ZXIvaW4gS29udGFrdCBhdWZuZWhtZW4uXGNmMFxmMlxmczI0XHBhcg0KfQ0KCw==";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.BarCode.XRCode128Generator xrCode128Generator1 = new DevExpress.XtraReports.UI.BarCode.XRCode128Generator();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtIntern = new DevExpress.XtraReports.UI.XRLabel();
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
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line6 = new DevExpress.XtraReports.UI.XRLine();
            this.Line4 = new DevExpress.XtraReports.UI.XRLine();
            this.Betrag1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label19 = new DevExpress.XtraReports.UI.XRLabel();
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
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel12,
                        this.xrLabel11,
                        this.txtBetrag,
                        this.txtIntern});
            this.Detail.Dpi = 254F;
            this.Detail.Height = 74;
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
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel23,
                        this.Line6,
                        this.Line4,
                        this.Betrag1,
                        this.Label19});
            this.GroupFooter1.Dpi = 254F;
            this.GroupFooter1.Height = 275;
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
            this.PageFooter.Height = 650;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Monatsbudget", "")});
            this.xrLabel12.Dpi = 254F;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel12.ForeColor = System.Drawing.Color.Black;
            this.xrLabel12.Location = new System.Drawing.Point(1085, 0);
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
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text", "")});
            this.xrLabel11.Dpi = 254F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel11.ForeColor = System.Drawing.Color.Black;
            this.xrLabel11.Location = new System.Drawing.Point(323, 0);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel11.ParentStyleUsing.UseBackColor = false;
            this.xrLabel11.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel11.ParentStyleUsing.UseBorders = false;
            this.xrLabel11.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel11.ParentStyleUsing.UseFont = false;
            this.xrLabel11.ParentStyleUsing.UseForeColor = false;
            this.xrLabel11.Size = new System.Drawing.Size(678, 50);
            this.xrLabel11.Text = "xrLabel11";
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Dpi = 254F;
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(1543, 0);
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
            xrSummary1.FormatString = "{0:0.00}";
            this.txtBetrag.Summary = xrSummary1;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtIntern
            // 
            this.txtIntern.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Konto", "")});
            this.txtIntern.Dpi = 254F;
            this.txtIntern.Font = new System.Drawing.Font("Arial", 10F);
            this.txtIntern.ForeColor = System.Drawing.Color.Black;
            this.txtIntern.Location = new System.Drawing.Point(153, 0);
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
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel9.ParentStyleUsing.UseBackColor = false;
            this.xrLabel9.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel9.ParentStyleUsing.UseBorders = false;
            this.xrLabel9.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.ParentStyleUsing.UseForeColor = false;
            this.xrLabel9.Size = new System.Drawing.Size(254, 50);
            this.xrLabel9.Text = "Monatsbudget";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 254F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel8.ForeColor = System.Drawing.Color.Black;
            this.xrLabel8.Location = new System.Drawing.Point(323, 1122);
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
            this.xrLabel3.Location = new System.Drawing.Point(1291, 376);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(381, 63);
            this.xrLabel3.Text = "Klientengelder";
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
            this.xrLabel5.Text = "K";
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
            this.Label16.Size = new System.Drawing.Size(170, 48);
            this.Label16.Text = "Konto";
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
            xrSummary2.FormatString = "{0:dd.MM.yyyy}";
            this.xrLabel2.Summary = xrSummary2;
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
            xrSummary3.FormatString = "{0:dd.MM.yyyy}";
            this.txtVerfalldatum.Summary = xrSummary3;
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
            // xrLabel23
            // 
            this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "inWorten", "")});
            this.xrLabel23.Dpi = 254F;
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 11F);
            this.xrLabel23.Location = new System.Drawing.Point(874, 190);
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
            this.Line6.Location = new System.Drawing.Point(868, 156);
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
            this.Line4.Location = new System.Drawing.Point(868, 167);
            this.Line4.Name = "Line4";
            this.Line4.ParentStyleUsing.UseBackColor = false;
            this.Line4.ParentStyleUsing.UseBorderColor = false;
            this.Line4.ParentStyleUsing.UseBorders = false;
            this.Line4.ParentStyleUsing.UseBorderWidth = false;
            this.Line4.ParentStyleUsing.UseFont = false;
            this.Line4.ParentStyleUsing.UseForeColor = false;
            this.Line4.Size = new System.Drawing.Size(894, 10);
            // 
            // Betrag1
            // 
            this.Betrag1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.Betrag1.Dpi = 254F;
            this.Betrag1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Betrag1.ForeColor = System.Drawing.Color.Black;
            this.Betrag1.Location = new System.Drawing.Point(1508, 85);
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
            // Label19
            // 
            this.Label19.Dpi = 254F;
            this.Label19.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Label19.ForeColor = System.Drawing.Color.Black;
            this.Label19.Location = new System.Drawing.Point(868, 85);
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
            // xrRichText1
            // 
            this.xrRichText1.Dpi = 254F;
            this.xrRichText1.Font = new System.Drawing.Font("Arial", 10F);
            this.xrRichText1.Location = new System.Drawing.Point(190, 444);
            this.xrRichText1.Name = "xrRichText1";
            this.xrRichText1.ParentStyleUsing.UseFont = false;
            this.xrRichText1.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichText1.RtfText")));
            this.xrRichText1.Size = new System.Drawing.Size(1567, 191);
            // 
            // xrControl1
            // 
            this.xrControl1.BackColor = System.Drawing.Color.Empty;
            this.xrControl1.BorderColor = System.Drawing.Color.Gray;
            this.xrControl1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrControl1.Dpi = 254F;
            this.xrControl1.Location = new System.Drawing.Point(169, 423);
            this.xrControl1.Name = "xrControl1";
            this.xrControl1.ParentStyleUsing.UseBackColor = false;
            this.xrControl1.ParentStyleUsing.UseBorderColor = false;
            this.xrControl1.ParentStyleUsing.UseBorders = false;
            this.xrControl1.ParentStyleUsing.UseBorderWidth = false;
            this.xrControl1.ParentStyleUsing.UseFont = false;
            this.xrControl1.ParentStyleUsing.UseForeColor = false;
            this.xrControl1.Size = new System.Drawing.Size(1588, 212);
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
            this.xrLabel21.Location = new System.Drawing.Point(169, 318);
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
            this.xrLabel20.Location = new System.Drawing.Point(614, 318);
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
            this.xrLabel19.Location = new System.Drawing.Point(169, 275);
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
            this.xrLabel18.Location = new System.Drawing.Point(614, 275);
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
            this.xrLabel17.Location = new System.Drawing.Point(614, 233);
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
            this.xrLabel16.Location = new System.Drawing.Point(614, 190);
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
            this.xrLabel15.Location = new System.Drawing.Point(169, 233);
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
            this.xrLabel14.Location = new System.Drawing.Point(169, 190);
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
                        this.PageFooter});
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
		<FieldName>KgBuchungID</FieldName>
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
</NewDataSet>' ,  N'declare @KgBuchungID int
declare @KasseUserID int
declare @BetragText varchar(20)
declare @InWorten varchar(200)
declare @Valuta datetime

set @KgBuchungID = {KgBuchungID}
set @KasseUserID = {KasseUserID}

select @BetragText = convert(varchar, Betrag, 1),
       @Valuta     = convert(datetime,dbo.fnMAX(ValutaDatum,getdate()))
from   KgBuchung
where  KgBuchungID = @KgBuchungID

set @InWorten = ''''
while len(@BetragText) > 0 begin
  if left(@BetragText,1) = ''.''
    set @InWorten = @InWorten + ''.''
  else
    if @InWorten <> '''' and right(@InWorten,1) <> ''.'' set @InWorten = @InWorten + ''-''

  set @InWorten = @InWorten +
    case left(@BetragText,1)
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

select Barcodetext          = convert(varchar(20),
                                   convert(bigint,KgBuchungID) +
                                                  (select FirstID from PscdKeySource where KeyName = ''AK'')),
       Klient               = PRS.NameVorname,
       PersonenNr           = PRS.BaPersonID,
       GueltigAb            = convert(varchar,@Valuta,104),
       GueltigBis           = case datepart(weekday, @Valuta)
                              when 5 then convert(varchar,dateadd(day, 11, @Valuta),104)  -- Do
                              when 6 then convert(varchar,dateadd(day, 11, @Valuta),104)  -- Fr
                              when 7 then convert(varchar,dateadd(day, 10, @Valuta),104)  -- Sa
                              else convert(varchar,dateadd(day, 9, @Valuta),104)
                              end,
       AuszahlungAn         = case when BUC.MitteilungZeile1 is null
                              then PRS.NameVorname +
                                   isNull(char(13) + char(10) + PRS.WohnsitzStrasseHausNr,'''') +
                                   isNull(char(13) + char(10) + PRS.WohnsitzPLZOrt,'''')
                              else BUC.MitteilungZeile1 +
                                   isNull(char(13) + char(10) + BUC.MitteilungZeile2,'''') +
                                   isNull(char(13) + char(10) + BUC.MitteilungZeile3,'''')
                              end,
       Konto                = BUC.SollKtoNr,
       Text                 = BUC.Text,
       Monatsbudget         = dbo.fnXMonat(BDG.Monat) + '' '' + convert(varchar,BDG.Jahr),
       Betrag               = BUC.Betrag,
       inWorten             = @InWorten,
       Erstelldatum         = convert(varchar,getdate(),104),
       Organisationseinheit = isNull(SZ.ItemName + '', '','''') + USR.OrgEinheitName, -- PLZ/Ort nicht als einzelnes Feld Verfügbar
       Belegersteller       = KUSR.NameVorname + isNull('' ('' + KUSR.Phone + '')'',''''),
       Sozialarbeiter       = USR.NameVorname + isNull('' ('' + USR.Phone + '')'','''')
from   FaLeistung LEI
       inner join vwPerson                PRS  on PRS.BaPersonID = LEI.BaPersonID
       inner join KgBudget                BDG  on BDG.FaLeistungID = LEI.FaLeistungID
       inner join KgPosition              POS  on POS.KgBudgetID = BDG.KgBudgetID
       inner join KgBuchung               BUC  on BUC.KgPositionID = POS.KgPositionID
       inner join vwUser                  USR  on USR.UserID = LEI.UserId
       inner join XOrgUnit                ORG  on ORG.OrgUnitID = USR.OrgUnitID
       inner join XOrgUnit                SZ   on SZ.OrgUnitID = ORG.ParentID
       left  join vwUser                  KUSR on KUSR.UserID = @KasseUserID
where  POS.KgPositionsKategorieCode in (1,2) and  -- Auszahlungen
       POS.KgAuszahlungsartCode = 103 and -- cash
       BUC.KgBuchungID = @KgBuchungID' ,  N'Kassenbeleg' ,  null , 10,  null )
