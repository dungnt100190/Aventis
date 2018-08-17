insert [XQuery]([QueryName], [UserText], [QueryCode], [LayoutXML], [ParameterXML], [SQLquery], [ContextForms], [ParentReportName], [ReportSortKey], [RelationColumnName])
values ( N'BaInventarSicherheitsleistung' ,  N'B - Inventar Sicherheitsleistung' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\SharpLibrary.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell13;
        private KiSS4.DB.SqlQuery sqlQuery1;
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
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
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
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRTable xrTable4;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell37;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell40;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell45;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrlblArt;
        private DevExpress.XtraReports.UI.XRLabel xrLabel33;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRTable xrTable3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell25;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell28;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell35;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAAEAAAAAQAAAGhTeXN0ZW0uRHJhd" +
                        "2luZy5CaXRtYXAsIFN5c3RlbS5EcmF3aW5nLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhb" +
                        "CwgUHVibGljS2V5VG9rZW49YjAzZjVmN2YxMWQ1MGEzYVBBRFBBRHwji4ATtE6kTgYgGvqVxHw3AAAAA" +
                        "AAAAJsAAAB6AAAAAgIAADJzAHEAbABRAHUAZQByAHkAMQAuAFMAZQBsAGUAYwB0AFMAdABhAHQAZQBtA" +
                        "GUAbgB0AAAAAAA+eAByAEwAYQBiAGUAbAAzADMALgBTAGMAcgBpAHAAdABzAC4ATwBuAEIAZQBmAG8Ac" +
                        "gBlAFAAcgBpAG4AdABiLQAAHHgAcgBMAGEAYgBlAGwAMwAzAC4AVABlAHgAdADGLgAAJngAcgBQAGkAY" +
                        "wB0AHUAcgBlAEIAbwB4ADEALgBJAG0AYQBnAGUAmi8AAAHfWi0tIEFsbGUgVmFyaWFibGVuIMO8YmVyb" +
                        "mVobWVuDQpERUNMQVJFIEBTdGljaHRhZyBkYXRldGltZQ0KU0VUIEBTdGljaHRhZyA9IEdldERhdGUoK" +
                        "SAtLSBEZWZhdWx0LCBmYWxscyB2b24gS2lzcyBuaWNodHMgw7xiZXJnZWJlbiB3dXJkZQ0KSUYgbnVsb" +
                        "CBpcyBub3QgbnVsbCBhbmQgbnVsbCA8PiBOJycgU0VUIEBTdGljaHRhZyA9IG51bGwNCg0KREVDTEFSR" +
                        "SBATnVyUG9zaXRpdmVTYWxkaSBiaXQNClNFVCBATnVyUG9zaXRpdmVTYWxkaSA9IElzTnVsbChudWxsL" +
                        "DApDQoNCkRFQ0xBUkUgQFN1Y2hlQXJ0IGludA0KU0VUIEBTdWNoZUFydCA9IG51bGwNCg0KREVDTEFSR" +
                        "SBAU3VjaGVCYVBlcnNvbklEIGludA0KU0VUIEBTdWNoZUJhUGVyc29uSUQgPSBudWxsDQoNCkRFQ0xBU" +
                        "kUgQFN1Y2hlS2xpZW50IHZhcmNoYXIoNTApDQpTRVQgQFN1Y2hlS2xpZW50ID0gbnVsbA0KSUYgbnVsb" +
                        "CBpcyBub3QgbnVsbCBhbmQgbnVsbCA8PiBOJycgU0VUIEBTdWNoZUtsaWVudCA9ICclJyArIHJlcGxhY" +
                        "2UobnVsbCwgJyAnLCAnJScpICsgJyUnDQoNCkRFQ0xBUkUgQFN1Y2hlQXVzemFobHVuZ1ZvbiBkYXRld" +
                        "GltZQ0KU0VUIEBTdWNoZUF1c3phaGx1bmdWb24gPSBudWxsDQpJRiBudWxsIGlzIG5vdCBudWxsIFNFV" +
                        "CBAU3VjaGVBdXN6YWhsdW5nVm9uID0gbnVsbA0KDQpERUNMQVJFIEBTdWNoZUF1c3phaGx1bmdCaXMgZ" +
                        "GF0ZXRpbWUNClNFVCBAU3VjaGVBdXN6YWhsdW5nQmlzID0gbnVsbA0KSUYgbnVsbCBpcyBub3QgbnVsb" +
                        "CBTRVQgQFN1Y2hlQXVzemFobHVuZ0JpcyA9IG51bGwNCg0KREVDTEFSRSBAU3VjaGVNaWdyaWVydCBpb" +
                        "nQgDQpTRVQgQFN1Y2hlTWlncmllcnQgPSBudWxsDQoNCkRFQ0xBUkUgQFN1Y2hlTGF1ZmVuZCBpbnQgD" +
                        "QpTRVQgQFN1Y2hlTGF1ZmVuZCA9IG51bGwNCg0KREVDTEFSRSBAU3VjaGVOZXUgaW50IA0KU0VUIEBTd" +
                        "WNoZU5ldSA9IG51bGwNCg0KREVDTEFSRSBAU3VjaGVJbnN0aXR1dGlvbiB2YXJjaGFyKDUwKQ0KU0VUI" +
                        "EBTdWNoZUluc3RpdHV0aW9uID0gbnVsbA0KSUYgbnVsbCBpcyBub3QgbnVsbCBhbmQgbnVsbCA8PiBOJ" +
                        "ycgU0VUIEBTdWNoZUluc3RpdHV0aW9uID0gJyUnICsgcmVwbGFjZShudWxsLCAnICcsICclJykgKyAnJ" +
                        "ScNCg0KREVDTEFSRSBAU3VjaGVLb250b05yIHZhcmNoYXIoNTApDQpTRVQgQFN1Y2hlS29udG9OciA9I" +
                        "G51bGwNCklGIG51bGwgaXMgbm90IG51bGwgYW5kIG51bGwgPD4gTicnIFNFVCBAU3VjaGVLb250b05yI" +
                        "D0gJyUnICsgcmVwbGFjZShudWxsLCAnICcsICclJykgKyAnJScNCg0KREVDTEFSRSBAU3VjaGVTdHJhc" +
                        "3NlIHZhcmNoYXIoNTApDQpTRVQgQFN1Y2hlU3RyYXNzZSA9IG51bGwNCklGIG51bGwgaXMgbm90IG51b" +
                        "GwgYW5kIG51bGwgPD4gTicnIFNFVCBAU3VjaGVTdHJhc3NlID0gJyUnICsgcmVwbGFjZShudWxsLCAnI" +
                        "CcsICclJykgKyAnJScNCg0KREVDTEFSRSBAU3VjaGVIYXVzTnIgdmFyY2hhcig1MCkNClNFVCBAU3Vja" +
                        "GVIYXVzTnIgPSBudWxsDQpJRiBudWxsIGlzIG5vdCBudWxsIGFuZCBudWxsIDw+IE4nJyBTRVQgQFN1Y" +
                        "2hlSGF1c05yICA9ICclJyArIHJlcGxhY2UobnVsbCwgJyAnLCAnJScpICsgJyUnDQoNCkRFQ0xBUkUgQ" +
                        "FN1Y2hlUExaIHZhcmNoYXIoNTApDQpTRVQgQFN1Y2hlUExaID0gbnVsbA0KSUYgbnVsbCBpcyBub3Qgb" +
                        "nVsbCBhbmQgbnVsbCA8PiBOJycgU0VUIEBTdWNoZVBMWiA9ICclJyArIHJlcGxhY2UobnVsbCwgJyAnL" +
                        "CAnJScpICsgJyUnDQoNCkRFQ0xBUkUgQFN1Y2hlT3J0IHZhcmNoYXIoNTApDQpTRVQgQFN1Y2hlT3J0I" +
                        "D0gbnVsbA0KSUYgbnVsbCBpcyBub3QgbnVsbCBhbmQgbnVsbCA8PiBOJycgU0VUIEBTdWNoZU9ydCA9I" +
                        "CclJyArIHJlcGxhY2UobnVsbCwgJyAnLCAnJScpICsgJyUnDQoNCkRFQ0xBUkUgQFN1Y2hlRmFGYWxsS" +
                        "UQgaW50IA0KU0VUIEBTdWNoZUZhRmFsbElEID0gbnVsbA0KDQpERUNMQVJFIEBTdWNoZUFsdGVQTnIgd" +
                        "mFyY2hhcig1MCkNClNFVCBAU3VjaGVBbHRlUE5yICA9IG51bGwNCklGIG51bGwgaXMgbm90IG51bGwgY" +
                        "W5kIG51bGwgPD4gTicnIFNFVCBAU3VjaGVBbHRlUE5yICA9ICclJyArIHJlcGxhY2UobnVsbCwgJyAnL" +
                        "CAnJScpICsgJyUnDQoNCkRFQ0xBUkUgQFN1Y2hlU2FsZG9OaWNodE51bGwgaW50IA0KU0VUIEBTdWNoZ" +
                        "VNhbGRvTmljaHROdWxsID0gbnVsbA0KDQoNCkRFQ0xBUkUgQFNhbGRpVG1wIFRBQkxFDQooDQogIEJhU" +
                        "2ljaGVyaGVpdHNsZWlzdHVuZ0lEIGludCwNCiAgU2FsZG8gICAgICAgICAgICAgICAgICAgbW9uZXksD" +
                        "QogIEVyc3RlQnVjaHVuZyAgICAgICAgICAgIGRhdGV0aW1lDQopDQoNCklOU0VSVCBJTlRPIEBTYWxka" +
                        "VRtcA0KU0VMRUNUIFNJQy5CYVNpY2hlcmhlaXRzbGVpc3R1bmdJRCwgSXNOdWxsKFNVTShNSUcuQmV0c" +
                        "mFnKSwwKSwgTUlOKE1JRy5CdWNodW5nc2RhdHVtKQ0KRlJPTSBkYm8uQmFTaWNoZXJoZWl0c2xlaXN0d" +
                        "W5nICAgICAgICAgICAgICAgICBTSUMgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKQ0KICBJTk5FUiBKT0lOI" +
                        "GRiby5CYVNpY2hlcmhlaXRzbGVpc3R1bmdQb3NpdGlvbiBTSVAgV0lUSCAoUkVBRFVOQ09NTUlUVEVEK" +
                        "SBPTiBTSUMuQmFTaWNoZXJoZWl0c2xlaXN0dW5nSUQgPSBTSVAuQmFTaWNoZXJoZWl0c2xlaXN0dW5nS" +
                        "UQNCiAgSU5ORVIgSk9JTiBkYm8uTWlnRGV0YWlsQnVjaHVuZyAgICAgICAgICAgICAgTUlHIFdJVEggK" +
                        "FJFQURVTkNPTU1JVFRFRCkgT04gTUlHLk1pZ0RldGFpbEJ1Y2h1bmdJRCAgICAgID0gU0lQLk1pZ0Rld" +
                        "GFpbEJ1Y2h1bmdJRA0KV0hFUkUgU0lDLkdlbG9lc2NodCA9IDAgQU5EDQogICAgICBNSUcuS2lzc0xla" +
                        "XN0dW5nc2FydCBJTiAoJzMyMCcsJzMyMScsJzg2MCcsJzg2MScsJzg2MicpIEFORA0KICAgICAgTUlHL" +
                        "kJ1Y2h1bmdzZGF0dW0gPD0gQFN0aWNodGFnDQpHUk9VUCBCWSBTSUMuQmFTaWNoZXJoZWl0c2xlaXN0d" +
                        "W5nSUQNCg0KLS1OZXR0b2J1Y2h1bmdlbg0KSU5TRVJUIElOVE8gQFNhbGRpVG1wDQpTRUxFQ1QgU0lDL" +
                        "kJhU2ljaGVyaGVpdHNsZWlzdHVuZ0lELCBJc051bGwoU1VNKEtCSy5CZXRyYWcpLDApLCBNSU4oS0JVL" +
                        "lZhbHV0YURhdHVtKQ0KRlJPTSBkYm8uQmFTaWNoZXJoZWl0c2xlaXN0dW5nICAgICAgICAgICAgICAgI" +
                        "CBTSUMgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKQ0KICBJTk5FUiBKT0lOIGRiby5CYVNpY2hlcmhlaXRzb" +
                        "GVpc3R1bmdQb3NpdGlvbiBTSVAgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKSBPTiBTSUMuQmFTaWNoZXJoZ" +
                        "Wl0c2xlaXN0dW5nSUQgPSBTSVAuQmFTaWNoZXJoZWl0c2xlaXN0dW5nSUQNCiAgSU5ORVIgSk9JTiBkY" +
                        "m8uS2JCdWNodW5nICAgICAgICAgICAgICAgICAgICAgS0JVIFdJVEggKFJFQURVTkNPTU1JVFRFRCkgT" +
                        "04gS0JVLktiQnVjaHVuZ0lEICAgICAgICAgICAgID0gU0lQLktiQnVjaHVuZ0lEDQogIElOTkVSIEpPS" +
                        "U4gZGJvLktiQnVjaHVuZ0tvc3RlbmFydCAgICAgICAgICAgIEtCSyBXSVRIIChSRUFEVU5DT01NSVRUR" +
                        "UQpIE9OIEtCSy5LYkJ1Y2h1bmdJRCAgICAgICAgICAgICA9IEtCVS5LYkJ1Y2h1bmdJRA0KICBJTk5FU" +
                        "iBKT0lOIGRiby5CZ0tvc3RlbmFydCAgICAgICAgICAgICAgICAgICBCS0EgV0lUSCAoUkVBRFVOQ09NT" +
                        "UlUVEVEKSBPTiBCS0EuQmdLb3N0ZW5hcnRJRCAgICAgICAgICAgPSBLQksuQmdLb3N0ZW5hcnRJRA0KV" +
                        "0hFUkUgU0lDLkdlbG9lc2NodCA9IDAgQU5EDQogICAgICBLQlUuS2JCdWNodW5nU3RhdHVzQ29kZSBOT" +
                        "1QgSU4gKDkpIEFORCAtLVLDvGNrbMOkdWZlciBhdXNzY2hsaWVzc2VuDQogICAgICBCS0EuS29udG9Oc" +
                        "iBJTiAoJzMyMCcsJzMyMScsJzg2MCcsJzg2MScsJzg2MicpIEFORA0KICAgICAgS0JVLlZhbHV0YURhd" +
                        "HVtIDw9IEBTdGljaHRhZw0KR1JPVVAgQlkgU0lDLkJhU2ljaGVyaGVpdHNsZWlzdHVuZ0lEDQoNCi0tQ" +
                        "nJ1dHRvYnVjaHVuZ2VuIGlua2wgTmV1YnVjaHVuZ2VuDQpJTlNFUlQgSU5UTyBAU2FsZGlUbXANClNFT" +
                        "EVDVCBTSUMuQmFTaWNoZXJoZWl0c2xlaXN0dW5nSUQsIC1Jc051bGwoU1VNKEtCUC5CZXRyYWcpLDApL" +
                        "CBNSU4oS0JCLlZhbHV0YURhdHVtKQ0KRlJPTSBkYm8uQmFTaWNoZXJoZWl0c2xlaXN0dW5nICAgICAgI" +
                        "CAgICAgICAgICBTSUMgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKQ0KICBJTk5FUiBKT0lOIGRiby5CYVNpY" +
                        "2hlcmhlaXRzbGVpc3R1bmdQb3NpdGlvbiBTSVAgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKSBPTiBTSUMuQ" +
                        "mFTaWNoZXJoZWl0c2xlaXN0dW5nSUQgPSBTSVAuQmFTaWNoZXJoZWl0c2xlaXN0dW5nSUQNCiAgSU5OR" +
                        "VIgSk9JTiBkYm8uS2JCdWNodW5nQnJ1dHRvICAgICAgICAgICAgICAgS0JCIFdJVEggKFJFQURVTkNPT" +
                        "U1JVFRFRCkgT04gS0JCLktiQnVjaHVuZ0JydXR0b0lEICAgICAgID0gU0lQLktiQnVjaHVuZ0JydXR0b" +
                        "0lEIEFORCAvKktCQi5CZXRyYWcgPj0gMCBBTkQqLyBTSVAuS2JCdWNodW5nSUQgSVMgTlVMTA0KICBJT" +
                        "k5FUiBKT0lOIGRiby5LYkJ1Y2h1bmdCcnV0dG9QZXJzb24gICAgICAgICBLQlAgV0lUSCAoUkVBRFVOQ" +
                        "09NTUlUVEVEKSBPTiBLQlAuS2JCdWNodW5nQnJ1dHRvSUQgICAgICAgPSBLQkIuS2JCdWNodW5nQnJ1d" +
                        "HRvSUQNCiAgSU5ORVIgSk9JTiBkYm8uQmdLb3N0ZW5hcnQgICAgICAgICAgICAgICAgICAgQktBIFdJV" +
                        "EggKFJFQURVTkNPTU1JVFRFRCkgT04gQktBLkJnS29zdGVuYXJ0SUQgICAgICAgICAgID0gSXNOdWxsK" +
                        "EtCUC5TcGV6QmdLb3N0ZW5hcnRJRCxLQkIuQmdLb3N0ZW5hcnRJRCkNCldIRVJFIFNJQy5HZWxvZXNja" +
                        "HQgPSAwIEFORA0KICAgICAgQktBLktvbnRvTnIgSU4gKCczMjAnLCczMjEnLCc4NjAnLCc4NjEnLCc4N" +
                        "jInKSBBTkQNCiAgICAgIEtCQi5WYWx1dGFEYXR1bSA8PSBAU3RpY2h0YWcNCkdST1VQIEJZIFNJQy5CY" +
                        "VNpY2hlcmhlaXRzbGVpc3R1bmdJRA0KDQotLVN0b3Jub2J1Y2h1bmdlbg0KSU5TRVJUIElOVE8gQFNhb" +
                        "GRpVG1wDQpTRUxFQ1QgU0lDLkJhU2ljaGVyaGVpdHNsZWlzdHVuZ0lELCAtSXNOdWxsKFNVTShLQlAuQ" +
                        "mV0cmFnKSwwKSwgTUlOKEtCQi5WYWx1dGFEYXR1bSkNCkZST00gZGJvLkJhU2ljaGVyaGVpdHNsZWlzd" +
                        "HVuZyAgICAgICAgICAgICAgICAgU0lDIFdJVEgoUkVBRFVOQ09NTUlUVEVEKQ0KICBJTk5FUiBKT0lOI" +
                        "GRiby5CYVNpY2hlcmhlaXRzbGVpc3R1bmdQb3NpdGlvbiBCU1AgV0lUSChSRUFEVU5DT01NSVRURUQpI" +
                        "E9OIFNJQy5CYVNpY2hlcmhlaXRzbGVpc3R1bmdJRCA9IEJTUC5CYVNpY2hlcmhlaXRzbGVpc3R1bmdJR" +
                        "A0KICBMRUZUICBKT0lOIChTRUxFQ1QgRElTVElOQ1QgT1JQLktiQnVjaHVuZ0JydXR0b0lELCBLQksuS" +
                        "2JCdWNodW5nSUQNCiAgICAgICAgICAgICAgRlJPTSBLYkJ1Y2h1bmdCcnV0dG9QZXJzb24gICAgICBPU" +
                        "lAgV0lUSChSRUFEVU5DT01NSVRURUQpDQogICAgICAgICAgICAgICAgSU5ORVIgSk9JTiBLYkJ1Y2h1b" +
                        "mdLb3N0ZW5hcnQgS0JLIFdJVEgoUkVBRFVOQ09NTUlUVEVEKSBPTiBLQksuQmdQb3NpdGlvbklEID0gT" +
                        "1JQLkJnUG9zaXRpb25JRCkgS0JLIE9OIEJTUC5LYkJ1Y2h1bmdJRCA9IEtCSy5LYkJ1Y2h1bmdJRA0KI" +
                        "CBJTk5FUiBKT0lOIGRiby5LYkJ1Y2h1bmdCcnV0dG8gICAgICAgICAgICAgICBPUkIgV0lUSChSRUFEV" +
                        "U5DT01NSVRURUQpIE9OIEJTUC5LYkJ1Y2h1bmdCcnV0dG9JRCA9IE9SQi5LYkJ1Y2h1bmdCcnV0dG9JR" +
                        "CBPUiBLQksuS2JCdWNodW5nQnJ1dHRvSUQgPSBPUkIuS2JCdWNodW5nQnJ1dHRvSUQNCiAgSU5ORVIgS" +
                        "k9JTiBkYm8uS2JCdWNodW5nQnJ1dHRvICAgICAgICAgICAgICAgS0JCIFdJVEgoUkVBRFVOQ09NTUlUV" +
                        "EVEKSBPTiBPUkIuS2JCdWNodW5nQnJ1dHRvSUQgPSBLQkIuU3Rvcm5pZXJ0S2JCdWNodW5nQnJ1dHRvS" +
                        "UQNCiAgSU5ORVIgSk9JTiBkYm8uS2JCdWNodW5nQnJ1dHRvUGVyc29uICAgICAgICAgS0JQIFdJVEgoU" +
                        "kVBRFVOQ09NTUlUVEVEKSBPTiBLQlAuS2JCdWNodW5nQnJ1dHRvSUQgPSBLQkIuS2JCdWNodW5nQnJ1d" +
                        "HRvSUQNCiAgSU5ORVIgSk9JTiBkYm8uQmdLb3N0ZW5hcnQgICAgICAgICAgICAgICAgICAgQktBIFdJV" +
                        "EgoUkVBRFVOQ09NTUlUVEVEKSBPTiBCS0EuQmdLb3N0ZW5hcnRJRCAgICAgPSBJc051bGwoS0JCLkJnS" +
                        "29zdGVuYXJ0SUQsS0JQLlNwZXpCZ0tvc3RlbmFydElEKQ0KV0hFUkUgU0lDLkdlbG9lc2NodCA9IDAgQ" +
                        "U5EDQogICAgICBLQkIuU3Rvcm5pZXJ0S2JCdWNodW5nQnJ1dHRvSUQgSVMgTk9UIE5VTEwgQU5EIC0tI" +
                        "E9SIEtCQi5OZXVidWNodW5nVm9uS2JCdWNodW5nQnJ1dHRvSUQgSVMgTk9UIE5VTEwpDQogICAgICBCS" +
                        "0EuS29udG9OciBJTiAoJzMyMCcsJzMyMScsJzg2MCcsJzg2MScsJzg2MicpIEFORA0KICAgICAgS0JCL" +
                        "lZhbHV0YURhdHVtIDw9IEBTdGljaHRhZw0KR1JPVVAgQlkgU0lDLkJhU2ljaGVyaGVpdHNsZWlzdHVuZ" +
                        "0lEDQoNCi0tVW1idWNodW5nZW4gQWx0ZGF0ZW4NCklOU0VSVCBJTlRPIEBTYWxkaVRtcA0KU0VMRUNUI" +
                        "FNJQy5CYVNpY2hlcmhlaXRzbGVpc3R1bmdJRCwgLUlzTnVsbChTVU0oS0JQLkJldHJhZyksMCksIE1JT" +
                        "ihLQkIuVmFsdXRhRGF0dW0pDQpGUk9NIGRiby5CYVNpY2hlcmhlaXRzbGVpc3R1bmcgICAgICAgICAgI" +
                        "CAgICAgIFNJQyBXSVRIKFJFQURVTkNPTU1JVFRFRCkNCiAgSU5ORVIgSk9JTiBkYm8uQmFTaWNoZXJoZ" +
                        "Wl0c2xlaXN0dW5nUG9zaXRpb24gQlNQIFdJVEgoUkVBRFVOQ09NTUlUVEVEKSBPTiBTSUMuQmFTaWNoZ" +
                        "XJoZWl0c2xlaXN0dW5nSUQgPSBCU1AuQmFTaWNoZXJoZWl0c2xlaXN0dW5nSUQNCiAgSU5ORVIgSk9JT" +
                        "iBkYm8uS2JCdWNodW5nQnJ1dHRvICAgICAgICAgICAgICAgS0JCIFdJVEgoUkVBRFVOQ09NTUlUVEVEK" +
                        "SBPTiBCU1AuTWlnRGV0YWlsYnVjaHVuZ0lEICAgICAgPSBLQkIuTWlnRGV0YWlsYnVjaHVuZ0lEDQogI" +
                        "ElOTkVSIEpPSU4gZGJvLk1pZ0RldGFpbEJ1Y2h1bmcgICAgICAgICAgICAgIE1JRyBXSVRIKFJFQURVT" +
                        "kNPTU1JVFRFRCkgT04gTUlHLk1pZ0RldGFpbEJ1Y2h1bmdJRCAgICAgID0gQlNQLk1pZ0RldGFpbEJ1Y" +
                        "2h1bmdJRA0KICBJTk5FUiBKT0lOIGRiby5LYkJ1Y2h1bmdCcnV0dG9QZXJzb24gICAgICAgICBLQlAgV" +
                        "0lUSChSRUFEVU5DT01NSVRURUQpIE9OIEtCUC5LYkJ1Y2h1bmdCcnV0dG9JRCAgICAgICA9IEtCQi5LY" +
                        "kJ1Y2h1bmdCcnV0dG9JRA0KICBJTk5FUiBKT0lOIGRiby5CZ0tvc3RlbmFydCAgICAgICAgICAgICAgI" +
                        "CAgICBCS0EgV0lUSChSRUFEVU5DT01NSVRURUQpIE9OIEJLQS5CZ0tvc3RlbmFydElEICAgICAgICAgI" +
                        "CA9IEtCQi5CZ0tvc3RlbmFydElEDQpXSEVSRSBTSUMuR2Vsb2VzY2h0ID0gMA0KICBBTkQgQktBLktvb" +
                        "nRvTnIgaW4gKCczMjAnLCczMjEnLCc4NjAnLCc4NjEnLCc4NjInKQ0KICBBTkQgS0JCLkJlbGVnYXJ0I" +
                        "D0gJ1VCJyAtLSBOdXIgZGllIFN0b3Jub2J1Y2h1bmcsIG5pY2h0IGRpZSBOZXVidWNodW5nDQogIEFOR" +
                        "CBLQkIuVmFsdXRhRGF0dW0gPD0gQFN0aWNodGFnDQpHUk9VUCBCWSBTSUMuQmFTaWNoZXJoZWl0c2xla" +
                        "XN0dW5nSUQNCg0KDQpERUNMQVJFIEBTYWxkaSBUQUJMRQ0KKA0KICBCYVNpY2hlcmhlaXRzbGVpc3R1b" +
                        "mdJRCBpbnQsDQogIFNhbGRvICAgICAgICAgICAgICAgICAgIG1vbmV5LA0KICBFcnN0ZUJ1Y2h1bmcgI" +
                        "CAgICAgICAgICBkYXRldGltZQ0KKQ0KDQpJTlNFUlQgSU5UTyBAU2FsZGkNClNFTEVDVCBCYVNpY2hlc" +
                        "mhlaXRzbGVpc3R1bmdJRCwgU1VNKFNhbGRvKSwgTUlOKEVyc3RlQnVjaHVuZykNCkZST00gQFNhbGRpV" +
                        "G1wDQpHUk9VUCBCWSBCYVNpY2hlcmhlaXRzbGVpc3R1bmdJRA0KDQovKg0KREVDTEFSRSBAU2FsZGkgV" +
                        "EFCTEUNCigNCiAgQmFTaWNoZXJoZWl0c2xlaXN0dW5nSUQgaW50LA0KICBTYWxkbyAgICAgICAgICAgI" +
                        "CAgICAgICBtb25leQ0KKQ0KDQpJTlNFUlQgSU5UTyBAU2FsZGkNClNFTEVDVCBCYVNpY2hlcmhlaXRzb" +
                        "GVpc3R1bmdJRCwgZGJvLmZuQ2FsY3VsYXRlU2lMZWlTYWxkbyhCYVNpY2hlcmhlaXRzbGVpc3R1bmdJR" +
                        "CxAU3RpY2h0YWcpDQpGUk9NIEJhU2ljaGVyaGVpdHNsZWlzdHVuZw0KV0hFUkUgR2Vsb2VzY2h0ID0gM" +
                        "A0KKi8NCg0KLS0gT3V0cHV0IGluIFJlcG9ydA0Kc2VsZWN0IGlzTnVsbChAU3VjaGVBcnQsIC0xKSBhc" +
                        "yBBcnQsDQogICAgICAgaXNOdWxsKENPTlZFUlQodmFyY2hhciwgQFN0aWNodGFnLCAxMDQpLCAnJykgY" +
                        "XMgU3RpY2h0YWcsIA0KICAgICAgIEFSVC5TaG9ydFRleHQsIA0KICAgICAgIFBSUy5CYVBlcnNvbklEL" +
                        "CANCiAgICAgICBQUlMuTmFtZVZvcm5hbWUsIA0KICAgICAgIGlzTnVsbChTSUMuT2JqZWt0U3RyYXNzZ" +
                        "SwgJycpICsgaXNOdWxsKCcgJyArIFNJQy5PYmpla3RIYXVzTnIsICcnKSBhcyBTdHJhc3NlLCANCiAgI" +
                        "CAgICBTSUMuT2JqZWt0UExaIGFzIFBMWiwgDQogICAgICAgU0lDLk9iamVrdE9ydCBhcyBPcnQsIA0KI" +
                        "CAgICAgIFNJQy5BdXN6YWhsdW5nQW0sIA0KICAgICAgIE5hbWUgPSBpc251bGwoSU5TLkluc3RpdHV0a" +
                        "W9uTmFtZSwgQk5LLk5hbWUpLA0KICAgICAgIFBseiA9IGlzTnVsbChJTlMuUGx6LCBCTksuUGx6KSwNC" +
                        "iAgICAgICBPcnQgPSBpc051bGwoSU5TLk9ydCwgQk5LLk9ydCksDQogICAgICAgU0lDLktvbnRvTnVtb" +
                        "WVyLCANCiAgICAgICBTYWxkbyA9IFNMRC5TYWxkbw0KZnJvbSAgIGRiby5CYVNpY2hlcmhlaXRzbGVpc" +
                        "3R1bmcgICBTSUMgV0lUSChSRUFEVU5DT01NSVRURUQpDQogICAgICAgbGVmdCBqb2luIEBTYWxkaSAgI" +
                        "CAgICAgICAgIFNMRCAgICAgICAgICAgICAgICAgICAgICAgb24gU0xELkJhU2ljaGVyaGVpdHNsZWlzd" +
                        "HVuZ0lEID0gU0lDLkJhU2ljaGVyaGVpdHNsZWlzdHVuZ0lEDQogICAgICAgbGVmdCBqb2luIGRiby5GY" +
                        "UxlaXN0dW5nICAgIExFSSBXSVRIKFJFQURVTkNPTU1JVFRFRCkgb24gTEVJLkJhUGVyc29uSUQgPSBTS" +
                        "UMuQmFQZXJzb25JRCANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICBhbmQgTEVJLkZhUHJvemVzc0NvZGUgPSAzMDAgDQogICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgYW5kIExFS" +
                        "S5GYUxlaXN0dW5nSUQgPSAoc2VsZWN0IHRvcCAxIEZhTGVpc3R1bmdJRA0KICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgIGZyb20gICBGYUxlaXN0dW5nDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgd" +
                        "2hlcmUgIEJhUGVyc29uSUQgPSBTSUMuQmFQZXJzb25JRA0KICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgIGFuZCBGYVByb3plc3NDb2RlID0gMzAwDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgb3JkZ" +
                        "XIgYnkgRGF0dW1Wb24gZGVzYykNCiAgICAgICBsZWZ0IGpvaW4gZGJvLnZ3UGVyc29uICAgICAgUFJTI" +
                        "FdJVEgoUkVBRFVOQ09NTUlUVEVEKSBvbiBQUlMuQmFQZXJzb25JRCA9IFNJQy5CYVBlcnNvbklEDQogI" +
                        "CAgICAgbGVmdCBqb2luIGRiby52d1VzZXIgICAgICAgIFVTUiBXSVRIKFJFQURVTkNPTU1JVFRFRCkgb" +
                        "24gVVNSLlVzZXJJRCA9IExFSS5Vc2VySUQNCiAgICAgICBsZWZ0IGpvaW4gZGJvLnZ3SW5zdGl0dXRpb" +
                        "24gSU5TIFdJVEgoUkVBRFVOQ09NTUlUVEVEKSBvbiBJTlMuQmFJbnN0aXR1dGlvbklEID0gU0lDLkJhS" +
                        "W5zdGl0dXRpb25JRA0KICAgICAgIGxlZnQgam9pbiBkYm8uQmFCYW5rICAgICAgICBCTksgV0lUSChSR" +
                        "UFEVU5DT01NSVRURUQpIG9uIEJOSy5CYUJhbmtJRCA9IFNJQy5CYUJhbmtJRA0KICAgICAgIGxlZnQga" +
                        "m9pbiBkYm8uWExPVkNvZGUgICAgICBBUlQgV0lUSChSRUFEVU5DT01NSVRURUQpIG9uIEFSVC5MT1ZOY" +
                        "W1lID0gJ0JhTWlldGVTaWNoZXJoZWl0c2xlaXN0dW5nQXJ0JyANCiAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBhbmQgQVJULkNvZGUgPSBTS" +
                        "UMuQmFNaWV0ZVNpY2hlcmhlaXRzbGVpc3R1bmdBcnRDb2RlDQp3aGVyZSAxPTENCi0tYW5kIChTSUMuQ" +
                        "XVzemFobHVuZ0FtIElTIE5VTEwgT1IgU0lDLkF1c3phaGx1bmdBbSA8PSBAU3RpY2h0YWcpDQphbmQgU" +
                        "0xELkVyc3RlQnVjaHVuZyA8PSBAU3RpY2h0YWcNCmFuZCAoQFN1Y2hlU2FsZG9OaWNodE51bGwgPSAwI" +
                        "CAgIG9yIFNMRC5TYWxkbyBpcyBub3QgbnVsbCBhbmQgU0xELlNhbGRvIDw+IDApDQphbmQgKEBOdXJQb" +
                        "3NpdGl2ZVNhbGRpID0gMCAgICAgICBvciBTTEQuU2FsZG8gaXMgbm90IG51bGwgYW5kIFNMRC5TYWxkb" +
                        "yAgPiAwKQ0KYW5kIChAU3VjaGVBcnQgaXMgbnVsbCAgICAgICAgICAgb3IgU0lDLkJhTWlldGVTaWNoZ" +
                        "XJoZWl0c2xlaXN0dW5nQXJ0Q29kZSA9IEBTdWNoZUFydCkNCmFuZCAoQFN1Y2hlQmFQZXJzb25JRCBpc" +
                        "yBudWxsICAgIG9yIFNJQy5CYVBlcnNvbklEID0gQFN1Y2hlQmFQZXJzb25JRCkNCmFuZCAoQFN1Y2hlS" +
                        "2xpZW50IGlzIG51bGwgICAgICAgIG9yIFBSUy5OYW1lVm9ybmFtZSBsaWtlIEBTdWNoZUtsaWVudCkNC" +
                        "mFuZCAoQFN1Y2hlQXVzemFobHVuZ1ZvbiBpcyBudWxsIG9yIFNJQy5BdXN6YWhsdW5nQW0gPj0gQFN1Y" +
                        "2hlQXVzemFobHVuZ1ZvbikNCmFuZCAoQFN1Y2hlQXVzemFobHVuZ0JpcyBpcyBudWxsIG9yIFNJQy5Bd" +
                        "XN6YWhsdW5nQW0gPD0gQFN1Y2hlQXVzemFobHVuZ0JpcykNCmFuZCAoKEBTdWNoZU1pZ3JpZXJ0ID0gM" +
                        "SAgICAgICAgIGFuZCBTSUMuTWlnRGFybGVoZW5JRCBpcyBub3QgbnVsbCkgb3INCiAgICAgKEBTdWNoZ" +
                        "UxhdWZlbmQgPSAxICAgICAgICAgIGFuZCBTSUMuTWlnRGFybGVoZW5JRCBpcyBudWxsIGFuZCBTSUMub" +
                        "mV1ID0gMCkgb3INCiAgICAgKEBTdWNoZU5ldSA9IDEgICAgICAgICAgICAgIGFuZCBTSUMubmV1ID0gM" +
                        "SkpDQphbmQgKEBTdWNoZUluc3RpdHV0aW9uIGlzIG51bGwgICBvciBJTlMuSW5zdGl0dXRpb25OYW1lI" +
                        "Gxpa2UgQFN1Y2hlSW5zdGl0dXRpb24pDQphbmQgKEBTdWNoZUtvbnRvTnIgaXMgbnVsbCAgICAgICBvc" +
                        "iBTSUMuS29udG9OdW1tZXIgbGlrZSBAU3VjaGVLb250b05yKQ0KYW5kIChAU3VjaGVTdHJhc3NlIGlzI" +
                        "G51bGwgICAgICAgb3IgU0lDLk9iamVrdFN0cmFzc2UgbGlrZSBAU3VjaGVTdHJhc3NlKQ0KYW5kIChAU" +
                        "3VjaGVIYXVzTnIgaXMgbnVsbCAgICAgICAgb3IgU0lDLk9iamVrdEhhdXNOciA9IEBTdWNoZUhhdXNOc" +
                        "ikNCmFuZCAoQFN1Y2hlUExaIGlzIG51bGwgICAgICAgICAgIG9yIFNJQy5PYmpla3RQTFogPSBAU3Vja" +
                        "GVQTFopDQphbmQgKEBTdWNoZU9ydCBpcyBudWxsICAgICAgICAgICBvciBTSUMuT2JqZWt0T3J0IGxpa" +
                        "2UgQFN1Y2hlT3J0KQ0KYW5kIChAU3VjaGVBbHRlUE5yIGlzIG51bGwgICAgICAgb3IgU0lDLkJhUGVyc" +
                        "29uSUQgaW4gKHNlbGVjdCBkaXN0aW5jdCBCYVBlcnNvbklEIGZyb20gQmFBbHRlRmFsbE5yIHdoZXJlI" +
                        "FBlcnNvbk5yQWx0ID0gQFN1Y2hlQWx0ZVBOcikpDQphbmQgKEBTdWNoZUZhRmFsbElEIGlzIG51bGwgI" +
                        "CAgICBvciBMRUkuRmFGYWxsSUQgPSBAU3VjaGVGYUZhbGxJRCkNCm9yZGVyIGJ5IEFSVC5TaG9ydFRle" +
                        "HQsIFBSUy5OYW1lAeECcHJpdmF0ZSB2b2lkIE9uQmVmb3JlUHJpbnQob2JqZWN0IHNlbmRlciwgU3lzd" +
                        "GVtLkRyYXdpbmcuUHJpbnRpbmcuUHJpbnRFdmVudEFyZ3MgZSkNCnsNCiAgLy8gVGV4dCBBbnBhc3Nlb" +
                        "iwgamUgbmFjaCBkZW0gd2VsY2hlICdBcnQnIGF1c2dld8OkaGx0IHd1cmRlDQogIGlmICh4cmxibEFyd" +
                        "C5UZXh0ID09ICIyIikNCiAgICAgeHJMYWJlbDMzLlRleHQgPSB4ckxhYmVsMzMuTGluZXNbMV07DQogI" +
                        "GVsc2UgaWYgKHhybGJsQXJ0LlRleHQgPT0gIjMiKQ0KICAgICB4ckxhYmVsMzMuVGV4dCA9IHhyTGFiZ" +
                        "WwzMy5MaW5lc1syXTsNCiAgZWxzZQ0KICAgICB4ckxhYmVsMzMuVGV4dCA9IHhyTGFiZWwzMy5MaW5lc" +
                        "1swXTsNCn0B0QFCZXN0YW5kZXNpbnZlbnRhciBBbnRlaWxzc2NoZWluZSAoQVMpIHVuZCBNaWV0emluc" +
                        "2RlcG90IChNRCkgcGVyIFN0aWNodGFnIFtTdGljaHRhZ10NCkJlc3RhbmRlc2ludmVudGFyIE1pZXR6a" +
                        "W5zZGVwb3QgKE1EKSBwZXIgU3RpY2h0YWcgW1N0aWNodGFnXQ0KQmVzdGFuZGVzaW52ZW50YXIgQW50Z" +
                        "Wlsc3NjaGVpbmUgKEFTKSBwZXIgU3RpY2h0YWcgW1N0aWNodGFnXUAAAQAAAP////8BAAAAAAAAAAwCA" +
                        "AAAUVN5c3RlbS5EcmF3aW5nLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS" +
                        "2V5VG9rZW49YjAzZjVmN2YxMWQ1MGEzYQUBAAAAFVN5c3RlbS5EcmF3aW5nLkJpdG1hcAEAAAAERGF0Y" +
                        "QcCAgAAAAkDAAAADwMAAABcEwAAAv/Y/+AAEEpGSUYAAQABAGAAYAAA//4AH0xFQUQgVGVjaG5vbG9na" +
                        "WVzIEluYy4gVjEuMDEA/9sAQwAIBgYHBgUIBwcHCgkICg0WDg0MDA0bExQQFiAcIiEfHB8eIygzKyMmM" +
                        "CYeHyw9LTA1Njk6OSIrP0M+OEMzODk3/9sAQwEJCgoNCw0aDg4aNyQfJDc3Nzc3Nzc3Nzc3Nzc3Nzc3N" +
                        "zc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3/8AAEQgAMgDbAwERAAIRAQMRAf/EAB8AAAEFA" +
                        "QEBAQEBAAAAAAAAAAABAgMEBQYHCAkKC//EALUQAAIBAwMCBAMFBQQEAAABfQECAwAEEQUSITFBBhNRY" +
                        "QcicRQygZGhCCNCscEVUtHwJDNicoIJChYXGBkaJSYnKCkqNDU2Nzg5OkNERUZHSElKU1RVVldYWVpjZ" +
                        "GVmZ2hpanN0dXZ3eHl6g4SFhoeIiYqSk5SVlpeYmZqio6Slpqeoqaqys7S1tre4ubrCw8TFxsfIycrS0" +
                        "9TV1tfY2drh4uPk5ebn6Onq8fLz9PX29/j5+v/EAB8BAAMBAQEBAQEBAQEAAAAAAAABAgMEBQYHCAkKC" +
                        "//EALURAAIBAgQEAwQHBQQEAAECdwABAgMRBAUhMQYSQVEHYXETIjKBCBRCkaGxwQkjM1LwFWJy0QoWJ" +
                        "DThJfEXGBkaJicoKSo1Njc4OTpDREVGR0hJSlNUVVZXWFlaY2RlZmdoaWpzdHV2d3h5eoKDhIWGh4iJi" +
                        "pKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uLj5OXm5+jp6vLz9PX29" +
                        "/j5+v/aAAwDAQACEQMRAD8A9s1zxBpnhyx+16nciKMnaihSzyNjO1VHLHjtQBieFfiLo3i+8W106G9jk" +
                        "aA3A+0Q7AUDbfU9z/OgC3rnjrw/oDeXc3omnDlGgtR50iEKWO5V5XgHrQBkN8WvDabg0epDbnObGTjGc" +
                        "9v9lvyNAC/8LZ8N5wI9SJ5/5cZO2fb2P5UAb+h+K9F8QxI2n30Zmbd/o7sFmXaxU5Q8jkHtQBhaz8VNA" +
                        "0LWJdMu4NQaWGdIHeK23qGYZHQ5PHoPXGaAOt03UrLV9Phv9PuUuLWYZSRDkH/PpQBaoA4XxH8XfCfhn" +
                        "VJNMubie5vIjiWO1i3+WfRjwM+1AG54e8ZaD4o0eXVNKv1ltoM+duBVosDPzA8jigC/o+t6br9gL7Sby" +
                        "O7tSxUSRnjI6igC/QAUAYTeLtITxgvhYzP/AGq0PnCPyzt24z97p2oAt6d4g0nVr29s9Pv4ri5sX2XEa" +
                        "HmNskYP5H8qAHa3rNl4e0a51bUXZLS2UNIyqWIGQOg9zQBwn/C+PAf/AD/3P/gK/wDhQB0P/CxPDv8Aw" +
                        "hg8V/aJf7JL7A/ktuzu2/d69aALmm+MdG1bX5tEtJpGvobdbllaJlGxgpByeM/MOKAN6gDDs/Fuk33im" +
                        "98OW8sh1KyQSTIYyFA46N0P3hQBuUAYWqeLtI0bxBpmiXkzpfakcW6rGSG5xyR0oA3aACgAoAKAOL1dr" +
                        "eD4oaVJqhC2k+nyW9kznCrcFgXGezMmAPXBAoA5vUPA7+DTD4gWR9ZsdMiAktdvlSiFDlWDKQJCgzww5" +
                        "FAHEDQp5JdO1i3gWL+zbvF1NCG3PJcFpHVpEBYiNWRSeeWIoA1ItOaOW3Y6zuEV1JcEbr0ZDhvl/wBXx" +
                        "94896AC0sHtWsnOslzatMx+e9G/eSf+efGM/jQBmaRYN4Sg0/UNR08zTBv7VwE2XE8UqmKSLccElWZG2" +
                        "nqG9RQB6HoHw3mt7qLVdSvVtB9ojvGsYhvEfl5McZmcliFJJPQZoA2PAjQz6h4nvNOA/se41DdbMv3HY" +
                        "IoldPYuDyOpBNAHZ0AeDw6N408BeLNc1jwxp9l4j03UZzJJscNKmWLbeDkHk9Mg8UAHhe70XxBo3i6DQ" +
                        "LS68KeIWjM19HkyhlXJYKrYCjJIIwMZ4oAs/BS31ay+Gl/qttq0ZTEy29pdAJBDIOfMZ+uPWgDmda8b6" +
                        "1o2kJqlt8Rm1TWlnHm2lrb77RVJPG4qB6fn+NAHaeIfFHiTxN420Pwhoepf2P59il7d3KJubld21c+g/" +
                        "n7UAYmm6Xrdp+0Aun6nrH2u8/suRIb8RBX2lG2sV6bgc/XFAD/hJo+qr8R/FLHxBMVsrzF0piXF6cuMt" +
                        "/d554oA91nSGSB1uFRocfMJACuPfNAHz9rrf8Lf8bL4b8N28Nr4d09w93exwqPMI4yDj6hR36n2AOr8e" +
                        "3dz4Hl8D6H4dl+xadLdiCWJVBEibk65HXk8+9AF3xZ4h1XTfjH4T0ezuzFYXsZNxEFGJMFupxnsKAOY0" +
                        "/UvH/jDxt4r0HTPES6fZWN2379owzxqHIVFx64OT7UAbVn4y1Oz+KnjC2vLpptL0nTjcJBtAwVVCecZ5" +
                        "5/OgDK0JPiT408MP4vsPFH2W5lkY2mmrEohKq2MEn6Hrn/AAp/EA+ILrx78PBILey194yrE/vI4pNwBb" +
                        "Hcd8UAbXh7VfFPhv4yR+EtY199Zs721M6SSxhShwx4A6cqRjpyKAPYaACgAoA85+IOo32oajdeGrWDTW" +
                        "t7fS21O5N+jOJFDFQq4I2kbSd3UcYoA46XxPrEeiS2h1K7h0iCK2YX8gEsls08WRBMp5lQBgNw+YZB5x" +
                        "QBz00usaHbeHrTT/wC1reyit9pWwndotUm37mMckZ6shJBI424PSgD1Tw7omj+J9LW+sPEviUYOyWGTV" +
                        "JVkhcdUdc8EUAa//CA2/wD0MXiP/wAGsv8AjQB5JrG+6W/c3l99g0/VknsNZ1KRpI41jAV1XJ3SszqRs" +
                        "A5wPSgDQ1PxBrGpaUbG/lnNiLa3uLWO6kAOoLNNsEk5Q/KgJz5a9iATQB6V4I1S9kn1fw/qEdn5+iyRx" +
                        "CSyj8uJ0ZNygL/CR0I+lAHXUAeRL8NfF/hPWtQuvA2vWkFjfyeY9reR5CHJ6cHOPwoA1/B3w1utHm1zV" +
                        "Nd1YX2tazE0U00SbUjU9cDv29OgoAy/Dvwt8QaZ4P1nwlfa5ayaTdxMLcwxEOkhIO5s9uOme9AGbcfCv" +
                        "xtqPgmLwpc6zo9vp1qVMfkQPvmIPG9vxJ4HJ60Ab3iD4cazJqWheIfDuqW9nr2m2iW0vmqTFMoXH17n8" +
                        "MdMUAJ4f+HfiS1+JEPjDXdbtL2Y27RyxxRFNpKkAL7Dj9aAJ9C8A+IPDnxE1PWrHWLU6Pqk5mubd4z5h" +
                        "HJAB6cFuvpQB0fjzQNS8TeEbvR9Kv1sZ7gqrStnBTPzLxzyOKAPNtA+FnxE8L2DWWjeLtPtIGcuyrASS" +
                        "3HJJXJ6UAbPiH4beJ/EXhXSEvfEMEviLS7pp47ooQjAkEDgcEYHOKAEt/h14svvHOh+KfEGvWVzPYcPD" +
                        "DEUVV5wF45PJJJxQBveDPA954Z8W+KNYuLuGaLV5/NiSMEMg3McHP8AvDp6UAQWfw8mT4h+ItfvLmGXT" +
                        "9XtDbG3UEOAQoOT0/hNAHNwfDPxzpWj3HhfSPFNpH4fmclZHiYXEaE5Kgj/AB/KgDcvfhncN4i8HXtpq" +
                        "Cta+H0CyfaNzSzc5Jz6nmgC/eeB7y4+Llh4xW7gW0trUwNAQd5JDjPp/EPyoA7igAoAKAPKvjRBaSWNg" +
                        "LW4dPEU5NtbW8LhXuYXIEsZ/wBnHOexoA5TQPEMP2u01G6s2bToLk6tfIsi7oDIfJtyVPLLGi5OOmQe1" +
                        "AGp8TPCumaZ4i0K402xOy9e4MlvHHLNHvCgh1ijYEN1yVx70AYWnjWvDGqDWPD+n3ccyjbNZRaRdIl4M" +
                        "9GLs2G64agD2/wx4nsPFOl/a7PfHLG3l3FtKNstvIOqOvY/zoA4nwnpmhWMPiLxfqEAYWmo3skJclkgj" +
                        "Vjny0ztBODyOTQB53rF1dLaLp0OlyLcr5lta2fmqZEt7oeZArEcBkkQcHkDFAHrvwqbTJvBsd1ZXxvb2" +
                        "5fzdRmc5kNyQC4b0xwAPQCgDt6AOVPirUr+7u00DQf7QtrSZoJLiW6WBXkXhlTglsHjJwMigDS8PeIYN" +
                        "ft7gi3ltLu0lMN1azY3wvgHBxwQQQQRwQaANigAoAqXd3NbXVlFFZSTpcSFJJEIxCNpO5vbIA/GgC3QB" +
                        "mX2sx2Ot6TpjQs76i0oVwRhNibjn60AadABQBy974p1FfEd5o2l6A9+9pFHLLJ9qSIDfnAAPX7poAn0z" +
                        "xV9p1ZdI1TTLjStRkQvDHMVdJ1H3tjqSCR3HB9qANawu5rsXJmspLXyp3iQSEHzFB4cY7HtQBboAKACg" +
                        "BksiwxPI2dqKWOPQUAVtK1K31jSbXUrXd9nuo1lj3jB2kZGRQBcoAKAOO+I8Vlb+GLnVTZwSarFGbaxm" +
                        "dQXjkmIjG09vvZ/CgDhZxbPd2t7NaIfBlpaP4fF2vDDcAjTn1j3Lsz2PNAFfxLdHVvhxpM1zLDNqPhq7" +
                        "EGpxMC5RFzE0hRWDEH5W6jrQBkrpodQyaaWUjII0K8wR/3+oAgNxfeDrg+JNNWWxe2T9/ENHnhiulyPk" +
                        "kZ3bHsexoA6ySeK28D6F4b1OeK3uNQnfUdVjZxm3tt7XDhx1GcqnPXJoAz7ue/XR9ZnudPFlFr0zavo7" +
                        "P8A6xZoiriNz2Z0QMB7sKAPXfDdvpMejxXmj2cFtb6gBdkQoFDs4B3HHegDXoA4bT9J1S2Se/8ABeu2U" +
                        "2l3k8k4tLyEvGrsx37JFIYDdngg4OaAKWoeK7+PQ9ftnsItJ8RW728U0sRDoVmYIkytgE4G7g9CKAJvE" +
                        "vhix8L+GbrXNHknt9U06PzxcvcO7T7eWWTJwwYZB+vGKAJfF9npEjW8y6dJd6/qYCWsH2mVBkLy7hWAC" +
                        "KOSce3U0AQvo7+F5PA+lRXtxNjUJPPleRiZWMEpOcnpnoO2BQBUltNJ1m91WU2Gq+Irlp5FW6hJhit8H" +
                        "AjjcuANuOWXPOaAE0K/utT/AOFa3l7K0tzLFcGR2OSx8kjJ9TxQBm6Q9v4j0x9W1bw/r99f3ckjJdWzA" +
                        "LAochFixINoUAdsk5zQB6L4Sm1SbwtYNrUTx6iEKzCTAYkEgMcEjJABP1oAytH/AOSoeJv+vS0/k9AB4" +
                        "32/2j4TEf8Ax9f2xH5eOu3Y/mfhtzQBy15q99Dol7axSXr/AG7xRNZubVszCLLMVjJIwSEx14yaAL1hA" +
                        "+n+INKl8PeGtZ06JphFfLcEeS8JB+Y5kPzKcEEDJ5zQA/wr4WsfEWj6hcazJcXkjX90kJadx9nUSsAEw" +
                        "eDxnPWgCtCmsa74H8LXUsc+rW0Jf+0LWOfy5bpVyitnI3YIBKkjJoAt6RaaHeQ6/pdv/aFpA1uskmj3Y" +
                        "eNoSM/vEOc7WIH3TjK0AZVsDoPwk8PR6Ul2kurvbQztbOWmwwy/l7jhWIUgYxjNAF+0t2sNb0qbw74Z1" +
                        "rTv9IWK8+0EeTJAcglsyHLA4IPXr60Ael0AYfirw83iPS4reK8NpcW9xHcwS7A6iRDkblPDD2oAi0Dwn" +
                        "a6R4UOg3Un2+GXzDP5iBVfzCSwCjhV5OAOlAGP4c+HEeia217c6kb6GO1ezgieBVPlMQSJWH+tIAAGew" +
                        "oAyrr4N6dDeSz6PNDHDIc/Zb2Fp44/9wh1ZR7ZNAFnRPhHpNlq0Wp6m6Xk0JDRW8UXlW6MOh2EksR7n8" +
                        "KALFx8MoLvxPdX9xqHmaZd3K3c9mYF3ySAABTL1MeVB2dOKANjxd4Vl8Rpp8trqH2G7sJWkidoRKh3IU" +
                        "OUPBODwexoA09A0eLw/4fsdIhleWO0iWIPJ95sdzQBpUAcmnhC+0y5uG8P+IJdNtbiRpWtHt0njR2OWK" +
                        "ZwVBOTjOMmgCa08FWK6bqlvqVxNqVxqoAvLmYhWcAYUKFwEC9gOh5oAgfwdfXsUNlrHiO41DS4mVjbtC" +
                        "iNNtOVEjjlhkDOAM45oALjwhqLeJb3W7TxJNbz3KLGFNrHIIox/ApYcDPJ9TQBdHhu4uJdJn1LVpby40" +
                        "26a4STyUj35jZNpC8YG4nNAFG38G3lkk1jZeIbi30eWV5PsqwqXQOSzIsvUAkntkZ4NAEukeCYdIXQ41" +
                        "v5pY9Gab7Orqo+R1KhSR12g9e9ADP8AhEL+ya6g0XxFPp2n3MjSG3ECSGJmOW8tj90EknHOCeKAOg0rT" +
                        "LXRdKttNs1K29ugRNxyT7k9yTyTQBh3vhS+k8R3es6Z4gn06S7ijiljW3jkU7M4PzDjqaAJ9L8KpZ6qu" +
                        "rajqN1qupIhjjmuNoWFT1CIoCrnAyepoAik8F2culX1k11OrXN++oRzoQrwSltwKn2Pr1FAC23hi9l1S" +
                        "0vdb1uTUvsRL28IgWFFcjG9gPvMATjsMnigDS0LRYtBsJLSKV5Ve4ln3MACC7liPwzigDGTwOtrpWk2+" +
                        "n6pPa3ulGT7PdbFbIcksrKeGB4/IYoAuaZ4Zkt9QutS1TUpNRv7iAW2/wAsRJHFnO1VHTJOSSSelAFS1" +
                        "8EpH4V/4R+71Se5t4WQ2coRY5bbYQUww6lSByaAJYPC99PqNnda3rsmpJYv5sEIgWFPMwQHbb94gE46D" +
                        "vigDpqACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgD//2Qs=";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
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
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
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
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrlblArt = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrTable2});
            this.Detail.Dpi = 254F;
            this.Detail.Height = 42;
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
                        this.xrTable1,
                        this.Line1});
            this.PageHeader.Dpi = 254F;
            this.PageHeader.Height = 54;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.ParentStyleUsing.UseBackColor = false;
            this.PageHeader.ParentStyleUsing.UseBorderColor = false;
            this.PageHeader.ParentStyleUsing.UseBorders = false;
            this.PageHeader.ParentStyleUsing.UseBorderWidth = false;
            this.PageHeader.ParentStyleUsing.UseFont = false;
            this.PageHeader.ParentStyleUsing.UseForeColor = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrTable4,
                        this.Line2});
            this.PageFooter.Dpi = 254F;
            this.PageFooter.Height = 84;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrlblArt,
                        this.xrLabel33,
                        this.xrLabel3,
                        this.xrPictureBox1});
            this.ReportHeader.Dpi = 254F;
            this.ReportHeader.Height = 360;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrTable3,
                        this.xrLine2,
                        this.xrLine1});
            this.ReportFooter.Dpi = 254F;
            this.ReportFooter.Height = 85;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrTable2
            // 
            this.xrTable2.Dpi = 254F;
            this.xrTable2.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrTable2.Location = new System.Drawing.Point(0, 0);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.ParentStyleUsing.UseFont = false;
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow2});
            this.xrTable2.Size = new System.Drawing.Size(2667, 42);
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
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
                        this.xrTableCell24});
            this.xrTableRow2.Dpi = 254F;
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Size = new System.Drawing.Size(2667, 42);
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ShortText", "")});
            this.xrTableCell13.Dpi = 254F;
            this.xrTableCell13.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell13.Size = new System.Drawing.Size(64, 42);
            this.xrTableCell13.Text = "xrTableCell13";
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BaPersonID", "")});
            this.xrTableCell14.Dpi = 254F;
            this.xrTableCell14.Location = new System.Drawing.Point(64, 0);
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell14.Size = new System.Drawing.Size(126, 42);
            this.xrTableCell14.Text = "xrTableCell14";
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameVorname", "")});
            this.xrTableCell15.Dpi = 254F;
            this.xrTableCell15.Location = new System.Drawing.Point(190, 0);
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell15.Size = new System.Drawing.Size(487, 42);
            this.xrTableCell15.Text = "xrTableCell15";
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Strasse", "")});
            this.xrTableCell16.Dpi = 254F;
            this.xrTableCell16.Location = new System.Drawing.Point(677, 0);
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell16.Size = new System.Drawing.Size(339, 42);
            this.xrTableCell16.Text = "xrTableCell16";
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "PLZ", "")});
            this.xrTableCell17.Dpi = 254F;
            this.xrTableCell17.Location = new System.Drawing.Point(1016, 0);
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell17.Size = new System.Drawing.Size(85, 42);
            this.xrTableCell17.Text = "xrTableCell17";
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Ort", "")});
            this.xrTableCell18.Dpi = 254F;
            this.xrTableCell18.Location = new System.Drawing.Point(1101, 0);
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell18.Size = new System.Drawing.Size(148, 42);
            this.xrTableCell18.Text = "xrTableCell18";
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AuszahlungAm", "{0:dd.MM.yyyy}")});
            this.xrTableCell19.Dpi = 254F;
            this.xrTableCell19.Location = new System.Drawing.Point(1249, 0);
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell19.Size = new System.Drawing.Size(169, 42);
            this.xrTableCell19.Text = "xrTableCell19";
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.xrTableCell20.Dpi = 254F;
            this.xrTableCell20.Location = new System.Drawing.Point(1418, 0);
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell20.Size = new System.Drawing.Size(583, 42);
            this.xrTableCell20.Text = "xrTableCell20";
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Plz1", "")});
            this.xrTableCell21.Dpi = 254F;
            this.xrTableCell21.Location = new System.Drawing.Point(2001, 0);
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell21.Size = new System.Drawing.Size(80, 42);
            this.xrTableCell21.Text = "xrTableCell21";
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Ort1", "")});
            this.xrTableCell22.Dpi = 254F;
            this.xrTableCell22.Location = new System.Drawing.Point(2081, 0);
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell22.Size = new System.Drawing.Size(171, 42);
            this.xrTableCell22.Text = "xrTableCell22";
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KontoNummer", "")});
            this.xrTableCell23.Dpi = 254F;
            this.xrTableCell23.Location = new System.Drawing.Point(2252, 0);
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell23.Size = new System.Drawing.Size(254, 42);
            this.xrTableCell23.Text = "xrTableCell23";
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Saldo", "{0:n2}")});
            this.xrTableCell24.Dpi = 254F;
            this.xrTableCell24.Location = new System.Drawing.Point(2506, 0);
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell24.Size = new System.Drawing.Size(161, 42);
            this.xrTableCell24.Text = "xrTableCell24";
            this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTable1
            // 
            this.xrTable1.Dpi = 254F;
            this.xrTable1.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrTable1.Location = new System.Drawing.Point(0, 0);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.ParentStyleUsing.UseFont = false;
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow1});
            this.xrTable1.Size = new System.Drawing.Size(2667, 42);
            // 
            // Line1
            // 
            this.Line1.Dpi = 254F;
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.LineWidth = 3;
            this.Line1.Location = new System.Drawing.Point(0, 43);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(2669, 11);
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
                        this.xrTableCell12});
            this.xrTableRow1.Dpi = 254F;
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Size = new System.Drawing.Size(2667, 42);
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Dpi = 254F;
            this.xrTableCell1.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell1.Size = new System.Drawing.Size(64, 42);
            this.xrTableCell1.Text = "Typ";
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Dpi = 254F;
            this.xrTableCell2.Location = new System.Drawing.Point(64, 0);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell2.Size = new System.Drawing.Size(126, 42);
            this.xrTableCell2.Text = "PNr.";
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Dpi = 254F;
            this.xrTableCell3.Location = new System.Drawing.Point(190, 0);
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell3.Size = new System.Drawing.Size(487, 42);
            this.xrTableCell3.Text = "Name, Vorname";
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Dpi = 254F;
            this.xrTableCell4.Location = new System.Drawing.Point(677, 0);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell4.Size = new System.Drawing.Size(339, 42);
            this.xrTableCell4.Text = "Strasse";
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Dpi = 254F;
            this.xrTableCell5.Location = new System.Drawing.Point(1016, 0);
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell5.Size = new System.Drawing.Size(85, 42);
            this.xrTableCell5.Text = "PLZ";
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Dpi = 254F;
            this.xrTableCell6.Location = new System.Drawing.Point(1101, 0);
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell6.Size = new System.Drawing.Size(148, 42);
            this.xrTableCell6.Text = "Ort";
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Dpi = 254F;
            this.xrTableCell7.Location = new System.Drawing.Point(1249, 0);
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell7.Size = new System.Drawing.Size(169, 42);
            this.xrTableCell7.Text = "Auszahlung";
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Dpi = 254F;
            this.xrTableCell8.Location = new System.Drawing.Point(1418, 0);
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell8.Size = new System.Drawing.Size(583, 42);
            this.xrTableCell8.Text = "Baugenossenschaft / Depothalter";
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Dpi = 254F;
            this.xrTableCell9.Location = new System.Drawing.Point(2001, 0);
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell9.Size = new System.Drawing.Size(80, 42);
            this.xrTableCell9.Text = "PLZ";
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Dpi = 254F;
            this.xrTableCell10.Location = new System.Drawing.Point(2081, 0);
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell10.Size = new System.Drawing.Size(171, 42);
            this.xrTableCell10.Text = "Ort";
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Dpi = 254F;
            this.xrTableCell11.Location = new System.Drawing.Point(2252, 0);
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell11.Size = new System.Drawing.Size(254, 42);
            this.xrTableCell11.Text = "Konto-Nr.";
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Dpi = 254F;
            this.xrTableCell12.Location = new System.Drawing.Point(2506, 0);
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell12.Size = new System.Drawing.Size(161, 42);
            this.xrTableCell12.Text = "Saldo";
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTable4
            // 
            this.xrTable4.Dpi = 254F;
            this.xrTable4.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrTable4.Location = new System.Drawing.Point(0, 42);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.ParentStyleUsing.UseFont = false;
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow4});
            this.xrTable4.Size = new System.Drawing.Size(2667, 42);
            // 
            // Line2
            // 
            this.Line2.Dpi = 254F;
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.LineWidth = 3;
            this.Line2.Location = new System.Drawing.Point(0, 3);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(2669, 21);
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell37,
                        this.xrTableCell40,
                        this.xrTableCell45});
            this.xrTableRow4.Dpi = 254F;
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Size = new System.Drawing.Size(2667, 42);
            // 
            // xrTableCell37
            // 
            this.xrTableCell37.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageInfo2});
            this.xrTableCell37.Dpi = 254F;
            this.xrTableCell37.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell37.Size = new System.Drawing.Size(698, 42);
            this.xrTableCell37.Text = "Typ";
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageInfo1});
            this.xrTableCell40.Dpi = 254F;
            this.xrTableCell40.Location = new System.Drawing.Point(698, 0);
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell40.Size = new System.Drawing.Size(1303, 42);
            this.xrTableCell40.Text = "Strasse";
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.Dpi = 254F;
            this.xrTableCell45.Location = new System.Drawing.Point(2001, 0);
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell45.Size = new System.Drawing.Size(666, 42);
            this.xrTableCell45.Text = "KiSS 4";
            this.xrTableCell45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 254F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 8F);
            this.xrPageInfo2.Format = "{0:Druck\\da\\tu\\m: dd.MM.yyyy}";
            this.xrPageInfo2.Location = new System.Drawing.Point(0, 0);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            this.xrPageInfo2.Size = new System.Drawing.Size(698, 43);
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 254F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8F);
            this.xrPageInfo1.Format = "Seite {0}/{1}";
            this.xrPageInfo1.Location = new System.Drawing.Point(0, 0);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(1303, 43);
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlblArt
            // 
            this.xrlblArt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Art", "")});
            this.xrlblArt.Dpi = 254F;
            this.xrlblArt.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrlblArt.Location = new System.Drawing.Point(0, 214);
            this.xrlblArt.Name = "xrlblArt";
            this.xrlblArt.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrlblArt.ParentStyleUsing.UseFont = false;
            this.xrlblArt.Size = new System.Drawing.Size(205, 43);
            this.xrlblArt.Text = "xrlblArt";
            this.xrlblArt.Visible = false;
            // 
            // xrLabel33
            // 
            this.xrLabel33.Dpi = 254F;
            this.xrLabel33.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel33.Location = new System.Drawing.Point(0, 275);
            this.xrLabel33.Multiline = true;
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel33.ParentStyleUsing.UseFont = false;
            this.xrLabel33.Scripts.OnBeforePrint = resources.GetString("xrLabel33.Scripts.OnBeforePrint");
            this.xrLabel33.Size = new System.Drawing.Size(2261, 85);
            this.xrLabel33.Text = resources.GetString("xrLabel33.Text");
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.Location = new System.Drawing.Point(2261, 0);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(408, 360);
            this.xrLabel3.Text = "Stadt Zürich\r\nSoziale Dienste\r\nVerwaltungszentrum Werd\r\nPostfach\r\n8036 Zürich\r\n\r\n" +
                "Telefon  044 412 61 11\r\nFax        044 412 09 89\r\nwww.stadt-zuerich.ch/sd";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Dpi = 254F;
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.Size = new System.Drawing.Size(698, 127);
            // 
            // xrTable3
            // 
            this.xrTable3.Dpi = 254F;
            this.xrTable3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTable3.Location = new System.Drawing.Point(0, 21);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.ParentStyleUsing.UseFont = false;
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow3});
            this.xrTable3.Size = new System.Drawing.Size(2667, 42);
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 254F;
            this.xrLine2.ForeColor = System.Drawing.Color.Black;
            this.xrLine2.LineWidth = 5;
            this.xrLine2.Location = new System.Drawing.Point(0, 64);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.ParentStyleUsing.UseBackColor = false;
            this.xrLine2.ParentStyleUsing.UseBorderColor = false;
            this.xrLine2.ParentStyleUsing.UseBorders = false;
            this.xrLine2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine2.ParentStyleUsing.UseFont = false;
            this.xrLine2.ParentStyleUsing.UseForeColor = false;
            this.xrLine2.Size = new System.Drawing.Size(2667, 21);
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 254F;
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.LineWidth = 3;
            this.xrLine1.Location = new System.Drawing.Point(0, 0);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(2669, 21);
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell25,
                        this.xrTableCell28,
                        this.xrTableCell35});
            this.xrTableRow3.Dpi = 254F;
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Size = new System.Drawing.Size(2667, 42);
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Art", "")});
            this.xrTableCell25.Dpi = 254F;
            this.xrTableCell25.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell25.Size = new System.Drawing.Size(698, 42);
            xrSummary1.FormatString = "{0} Positionen";
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Count;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell25.Summary = xrSummary1;
            this.xrTableCell25.Text = "xrTableCell25";
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Dpi = 254F;
            this.xrTableCell28.Location = new System.Drawing.Point(698, 0);
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell28.Size = new System.Drawing.Size(1553, 42);
            // 
            // xrTableCell35
            // 
            this.xrTableCell35.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Saldo", "")});
            this.xrTableCell35.Dpi = 254F;
            this.xrTableCell35.Location = new System.Drawing.Point(2251, 0);
            this.xrTableCell35.Name = "xrTableCell35";
            this.xrTableCell35.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell35.Size = new System.Drawing.Size(416, 42);
            xrSummary2.FormatString = "{0:n2}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell35.Summary = xrSummary2;
            this.xrTableCell35.Text = "xrTableCell35";
            this.xrTableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
                        this.PageFooter,
                        this.ReportHeader,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Dpi = 254F;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(201, 99, 99, 79);
            this.Name = "Report";
            this.PageHeight = 2101;
            this.PageWidth = 2969;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' ,  N'<NewDataSet>
	<Table>
		<FieldName>labelFbPeriodeID</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>FbPeriodeID:</DisplayText>
		<TabPosition>0</TabPosition>
		<X>10</X>
		<Y>40</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName>LOV Name</LOVName>
		<DefaultValue>DefaultValue1</DefaultValue>
		<Mandatory>false</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>
		<FieldName>FbPeriodeID</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>Periode</DisplayText>
		<TabPosition>1</TabPosition>
		<X>100</X>
		<Y>40</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>10</Length>
		<LOVName>LOV Name</LOVName>
		<DefaultValue>1</DefaultValue>
		<Mandatory>false</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>
		<FieldName>labelDatumVon</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Datum von:</DisplayText>
		<TabPosition>0</TabPosition>
		<X>10</X>
		<Y>70</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName>LOV Name</LOVName>
		<DefaultValue>DefaultValue1</DefaultValue>
		<Mandatory>false</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>
		<FieldName>DatumVon</FieldName>
		<FieldCode>5</FieldCode>
		<DisplayText>Datum von</DisplayText>
		<TabPosition>4</TabPosition>
		<X>100</X>
		<Y>70</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>10</Length>
		<LOVName>LOV Name</LOVName>
		<DefaultValue>1</DefaultValue>
		<Mandatory>true</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>
		<FieldName>labelDatumBis</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Datum bis:</DisplayText>
		<TabPosition>0</TabPosition>
		<X>10</X>
		<Y>100</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName>LOV Name</LOVName>
		<DefaultValue>DefaultValue1</DefaultValue>
		<Mandatory>false</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>
		<FieldName>DatumBis</FieldName>
		<FieldCode>5</FieldCode>
		<DisplayText>Datum bis</DisplayText>
		<TabPosition>5</TabPosition>
		<X>100</X>
		<Y>100</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>10</Length>
		<LOVName>LOV Name</LOVName>
		<DefaultValue>1</DefaultValue>
		<Mandatory>true</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
</NewDataSet>' ,  N'-- Alle Variablen übernehmen
DECLARE @Stichtag datetime
SET @Stichtag = GetDate() -- Default, falls von Kiss nichts übergeben wurde
IF {edtReportInventarBis} is not null and {edtReportInventarBis} <> N'''' SET @Stichtag = {edtReportInventarBis}

DECLARE @NurPositiveSaldi bit
SET @NurPositiveSaldi = IsNull({edtReportInventarNurPositiveSaldi},0)

DECLARE @SucheArt int
SET @SucheArt = {edtSucheArt}

DECLARE @SucheBaPersonID int
SET @SucheBaPersonID = {edtSucheBaPersonID}

DECLARE @SucheKlient varchar(50)
SET @SucheKlient = null
IF {edtSucheKlient} is not null and {edtSucheKlient} <> N'''' SET @SucheKlient = ''%'' + replace({edtSucheKlient}, '' '', ''%'') + ''%''

DECLARE @SucheAuszahlungVon datetime
SET @SucheAuszahlungVon = null
IF {edtSucheAuszahlungVon} is not null SET @SucheAuszahlungVon = {edtSucheAuszahlungVon}

DECLARE @SucheAuszahlungBis datetime
SET @SucheAuszahlungBis = null
IF {edtSucheAuszahlungBis} is not null SET @SucheAuszahlungBis = {edtSucheAuszahlungBis}

DECLARE @SucheMigriert int 
SET @SucheMigriert = {edtSucheMigriert}

DECLARE @SucheLaufend int 
SET @SucheLaufend = {edtSucheLaufend}

DECLARE @SucheNeu int 
SET @SucheNeu = {edtSucheNeu}

DECLARE @SucheInstitution varchar(50)
SET @SucheInstitution = null
IF {edtSucheInstitution} is not null and {edtSucheInstitution} <> N'''' SET @SucheInstitution = ''%'' + replace({edtSucheInstitution}, '' '', ''%'') + ''%''

DECLARE @SucheKontoNr varchar(50)
SET @SucheKontoNr = null
IF {edtSucheKontoNr} is not null and {edtSucheKontoNr} <> N'''' SET @SucheKontoNr = ''%'' + replace({edtSucheKontoNr}, '' '', ''%'') + ''%''

DECLARE @SucheStrasse varchar(50)
SET @SucheStrasse = null
IF {edtSucheStrasse} is not null and {edtSucheStrasse} <> N'''' SET @SucheStrasse = ''%'' + replace({edtSucheStrasse}, '' '', ''%'') + ''%''

DECLARE @SucheHausNr varchar(50)
SET @SucheHausNr = null
IF {edtSucheHausNr} is not null and {edtSucheHausNr} <> N'''' SET @SucheHausNr  = ''%'' + replace({edtSucheHausNr}, '' '', ''%'') + ''%''

DECLARE @SuchePLZ varchar(50)
SET @SuchePLZ = null
IF {edtSuchePLZ} is not null and {edtSuchePLZ} <> N'''' SET @SuchePLZ = ''%'' + replace({edtSuchePLZ}, '' '', ''%'') + ''%''

DECLARE @SucheOrt varchar(50)
SET @SucheOrt = null
IF {edtSucheOrt} is not null and {edtSucheOrt} <> N'''' SET @SucheOrt = ''%'' + replace({edtSucheOrt}, '' '', ''%'') + ''%''

DECLARE @SucheFaFallID int 
SET @SucheFaFallID = {edtSucheFaFallID}

DECLARE @SucheAltePNr varchar(50)
SET @SucheAltePNr  = null
IF {edtSucheAltePNr} is not null and {edtSucheAltePNr} <> N'''' SET @SucheAltePNr  = ''%'' + replace({edtSucheAltePNr}, '' '', ''%'') + ''%''

DECLARE @SucheSaldoNichtNull int 
SET @SucheSaldoNichtNull = {edtSucheSaldoNichtNull}


DECLARE @SaldiTmp TABLE
(
  BaSicherheitsleistungID int,
  Saldo                   money,
  ErsteBuchung            datetime
)

INSERT INTO @SaldiTmp
SELECT SIC.BaSicherheitsleistungID, IsNull(SUM(MIG.Betrag),0), MIN(MIG.Buchungsdatum)
FROM dbo.BaSicherheitsleistung                 SIC WITH (READUNCOMMITTED)
  INNER JOIN dbo.BaSicherheitsleistungPosition SIP WITH (READUNCOMMITTED) ON SIC.BaSicherheitsleistungID = SIP.BaSicherheitsleistungID
  INNER JOIN dbo.MigDetailBuchung              MIG WITH (READUNCOMMITTED) ON MIG.MigDetailBuchungID      = SIP.MigDetailBuchungID
WHERE SIC.Geloescht = 0 AND
      MIG.KissLeistungsart IN (''320'',''321'',''860'',''861'',''862'') AND
      MIG.Buchungsdatum <= @Stichtag
GROUP BY SIC.BaSicherheitsleistungID

--Nettobuchungen
INSERT INTO @SaldiTmp
SELECT SIC.BaSicherheitsleistungID, IsNull(SUM(KBK.Betrag),0), MIN(KBU.ValutaDatum)
FROM dbo.BaSicherheitsleistung                 SIC WITH (READUNCOMMITTED)
  INNER JOIN dbo.BaSicherheitsleistungPosition SIP WITH (READUNCOMMITTED) ON SIC.BaSicherheitsleistungID = SIP.BaSicherheitsleistungID
  INNER JOIN dbo.KbBuchung                     KBU WITH (READUNCOMMITTED) ON KBU.KbBuchungID             = SIP.KbBuchungID
  INNER JOIN dbo.KbBuchungKostenart            KBK WITH (READUNCOMMITTED) ON KBK.KbBuchungID             = KBU.KbBuchungID
  INNER JOIN dbo.BgKostenart                   BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID           = KBK.BgKostenartID
WHERE SIC.Geloescht = 0 AND
      KBU.KbBuchungStatusCode NOT IN (9) AND --Rückläufer ausschliessen
      BKA.KontoNr IN (''320'',''321'',''860'',''861'',''862'') AND
      KBU.ValutaDatum <= @Stichtag
GROUP BY SIC.BaSicherheitsleistungID

--Bruttobuchungen inkl Neubuchungen
INSERT INTO @SaldiTmp
SELECT SIC.BaSicherheitsleistungID, -IsNull(SUM(KBP.Betrag),0), MIN(KBB.ValutaDatum)
FROM dbo.BaSicherheitsleistung                 SIC WITH (READUNCOMMITTED)
  INNER JOIN dbo.BaSicherheitsleistungPosition SIP WITH (READUNCOMMITTED) ON SIC.BaSicherheitsleistungID = SIP.BaSicherheitsleistungID
  INNER JOIN dbo.KbBuchungBrutto               KBB WITH (READUNCOMMITTED) ON KBB.KbBuchungBruttoID       = SIP.KbBuchungBruttoID AND /*KBB.Betrag >= 0 AND*/ SIP.KbBuchungID IS NULL
  INNER JOIN dbo.KbBuchungBruttoPerson         KBP WITH (READUNCOMMITTED) ON KBP.KbBuchungBruttoID       = KBB.KbBuchungBruttoID
  INNER JOIN dbo.BgKostenart                   BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID           = IsNull(KBP.SpezBgKostenartID,KBB.BgKostenartID)
WHERE SIC.Geloescht = 0 AND
      BKA.KontoNr IN (''320'',''321'',''860'',''861'',''862'') AND
      KBB.ValutaDatum <= @Stichtag
GROUP BY SIC.BaSicherheitsleistungID

--Stornobuchungen
INSERT INTO @SaldiTmp
SELECT SIC.BaSicherheitsleistungID, -IsNull(SUM(KBP.Betrag),0), MIN(KBB.ValutaDatum)
FROM dbo.BaSicherheitsleistung                 SIC WITH(READUNCOMMITTED)
  INNER JOIN dbo.BaSicherheitsleistungPosition BSP WITH(READUNCOMMITTED) ON SIC.BaSicherheitsleistungID = BSP.BaSicherheitsleistungID
  LEFT  JOIN (SELECT DISTINCT ORP.KbBuchungBruttoID, KBK.KbBuchungID
              FROM KbBuchungBruttoPerson      ORP WITH(READUNCOMMITTED)
                INNER JOIN KbBuchungKostenart KBK WITH(READUNCOMMITTED) ON KBK.BgPositionID = ORP.BgPositionID) KBK ON BSP.KbBuchungID = KBK.KbBuchungID
  INNER JOIN dbo.KbBuchungBrutto               ORB WITH(READUNCOMMITTED) ON BSP.KbBuchungBruttoID = ORB.KbBuchungBruttoID OR KBK.KbBuchungBruttoID = ORB.KbBuchungBruttoID
  INNER JOIN dbo.KbBuchungBrutto               KBB WITH(READUNCOMMITTED) ON ORB.KbBuchungBruttoID = KBB.StorniertKbBuchungBruttoID
  INNER JOIN dbo.KbBuchungBruttoPerson         KBP WITH(READUNCOMMITTED) ON KBP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
  INNER JOIN dbo.BgKostenart                   BKA WITH(READUNCOMMITTED) ON BKA.BgKostenartID     = IsNull(KBB.BgKostenartID,KBP.SpezBgKostenartID)
WHERE SIC.Geloescht = 0 AND
      KBB.StorniertKbBuchungBruttoID IS NOT NULL AND -- OR KBB.NeubuchungVonKbBuchungBruttoID IS NOT NULL)
      BKA.KontoNr IN (''320'',''321'',''860'',''861'',''862'') AND
      KBB.ValutaDatum <= @Stichtag
GROUP BY SIC.BaSicherheitsleistungID

--Umbuchungen Altdaten
INSERT INTO @SaldiTmp
SELECT SIC.BaSicherheitsleistungID, -IsNull(SUM(KBP.Betrag),0), MIN(KBB.ValutaDatum)
FROM dbo.BaSicherheitsleistung                 SIC WITH(READUNCOMMITTED)
  INNER JOIN dbo.BaSicherheitsleistungPosition BSP WITH(READUNCOMMITTED) ON SIC.BaSicherheitsleistungID = BSP.BaSicherheitsleistungID
  INNER JOIN dbo.KbBuchungBrutto               KBB WITH(READUNCOMMITTED) ON BSP.MigDetailbuchungID      = KBB.MigDetailbuchungID
  INNER JOIN dbo.MigDetailBuchung              MIG WITH(READUNCOMMITTED) ON MIG.MigDetailBuchungID      = BSP.MigDetailBuchungID
  INNER JOIN dbo.KbBuchungBruttoPerson         KBP WITH(READUNCOMMITTED) ON KBP.KbBuchungBruttoID       = KBB.KbBuchungBruttoID
  INNER JOIN dbo.BgKostenart                   BKA WITH(READUNCOMMITTED) ON BKA.BgKostenartID           = KBB.BgKostenartID
WHERE SIC.Geloescht = 0
  AND BKA.KontoNr in (''320'',''321'',''860'',''861'',''862'')
  AND KBB.Belegart = ''UB'' -- Nur die Stornobuchung, nicht die Neubuchung
  AND KBB.ValutaDatum <= @Stichtag
GROUP BY SIC.BaSicherheitsleistungID


DECLARE @Saldi TABLE
(
  BaSicherheitsleistungID int,
  Saldo                   money,
  ErsteBuchung            datetime
)

INSERT INTO @Saldi
SELECT BaSicherheitsleistungID, SUM(Saldo), MIN(ErsteBuchung)
FROM @SaldiTmp
GROUP BY BaSicherheitsleistungID

/*
DECLARE @Saldi TABLE
(
  BaSicherheitsleistungID int,
  Saldo                   money
)

INSERT INTO @Saldi
SELECT BaSicherheitsleistungID, dbo.fnCalculateSiLeiSaldo(BaSicherheitsleistungID,@Stichtag)
FROM BaSicherheitsleistung
WHERE Geloescht = 0
*/

-- Output in Report
select isNull(@SucheArt, -1) as Art,
       isNull(CONVERT(varchar, @Stichtag, 104), '''') as Stichtag, 
       ART.ShortText, 
       PRS.BaPersonID, 
       PRS.NameVorname, 
       isNull(SIC.ObjektStrasse, '''') + isNull('' '' + SIC.ObjektHausNr, '''') as Strasse, 
       SIC.ObjektPLZ as PLZ, 
       SIC.ObjektOrt as Ort, 
       SIC.AuszahlungAm, 
       Name = isnull(INS.Name, BNK.Name),
       Plz = isNull(INS.Plz, BNK.Plz),
       Ort = isNull(INS.Ort, BNK.Ort),
       SIC.KontoNummer, 
       Saldo = SLD.Saldo
from   dbo.BaSicherheitsleistung   SIC WITH(READUNCOMMITTED)
       left join @Saldi            SLD                       on SLD.BaSicherheitsleistungID = SIC.BaSicherheitsleistungID
       left join dbo.FaLeistung    LEI WITH(READUNCOMMITTED) on LEI.BaPersonID = SIC.BaPersonID 
                                                                and LEI.FaProzessCode = 300 
                                                                and LEI.FaLeistungID = (select top 1 FaLeistungID
                                                                                        from   FaLeistung
                                                                                        where  BaPersonID = SIC.BaPersonID
                                                                                        and FaProzessCode = 300
                                                                                        order by DatumVon desc)
       left join dbo.vwPerson      PRS WITH(READUNCOMMITTED) on PRS.BaPersonID = SIC.BaPersonID
       left join dbo.vwUser        USR WITH(READUNCOMMITTED) on USR.UserID = LEI.UserID
       left join dbo.vwInstitution INS WITH(READUNCOMMITTED) on INS.BaInstitutionID = SIC.BaInstitutionID
       left join dbo.BaBank        BNK WITH(READUNCOMMITTED) on BNK.BaBankID = SIC.BaBankID
       left join dbo.XLOVCode      ART WITH(READUNCOMMITTED) on ART.LOVName = ''BaMieteSicherheitsleistungArt'' 
                                                                and ART.Code = SIC.BaMieteSicherheitsleistungArtCode
where 1=1
--and (SIC.AuszahlungAm IS NULL OR SIC.AuszahlungAm <= @Stichtag)
and SLD.ErsteBuchung <= @Stichtag
and (@SucheSaldoNichtNull = 0    or SLD.Saldo is not null and SLD.Saldo <> 0)
and (@NurPositiveSaldi = 0       or SLD.Saldo is not null and SLD.Saldo  > 0)
and (@SucheArt is null           or SIC.BaMieteSicherheitsleistungArtCode = @SucheArt)
and (@SucheBaPersonID is null    or SIC.BaPersonID = @SucheBaPersonID)
and (@SucheKlient is null        or PRS.NameVorname like @SucheKlient)
and (@SucheAuszahlungVon is null or SIC.AuszahlungAm >= @SucheAuszahlungVon)
and (@SucheAuszahlungBis is null or SIC.AuszahlungAm <= @SucheAuszahlungBis)
and ((@SucheMigriert = 1         and SIC.MigDarlehenID is not null) or
     (@SucheLaufend = 1          and SIC.MigDarlehenID is null and SIC.neu = 0) or
     (@SucheNeu = 1              and SIC.neu = 1))
and (@SucheInstitution is null   or INS.Name like @SucheInstitution)
and (@SucheKontoNr is null       or SIC.KontoNummer like @SucheKontoNr)
and (@SucheStrasse is null       or SIC.ObjektStrasse like @SucheStrasse)
and (@SucheHausNr is null        or SIC.ObjektHausNr = @SucheHausNr)
and (@SuchePLZ is null           or SIC.ObjektPLZ = @SuchePLZ)
and (@SucheOrt is null           or SIC.ObjektOrt like @SucheOrt)
and (@SucheAltePNr is null       or SIC.BaPersonID in (select distinct BaPersonID from BaAlteFallNr where PersonNrAlt = @SucheAltePNr))
and (@SucheFaFallID is null      or LEI.FaFallID = @SucheFaFallID)
order by ART.ShortText, PRS.Name' ,  N'FrmBaSicherheitsleistung' ,  null , 1,  null )
