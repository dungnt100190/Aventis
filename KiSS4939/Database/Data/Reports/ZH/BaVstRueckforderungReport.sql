-- Insert Script for BaVstRueckforderung
-- MD5:0X5745F63F6A8C709E6EE3251F7B0608B3_0XF60CC2E4ACC9F6AD80C4178F70AAB96F_0X33E84FFA6CAFDCF9A74450E0A4ED1C4D
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'BaVstRueckforderung') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('BaVstRueckforderung', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'BaVstRueckforderung';
--SQLCHECK_IGNORE--
UPDATE QRY
SET QueryName =  N'BaVstRueckforderung' , UserText =  N'B - Verrechungssteuer Rückforderung' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell11;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell13;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell15;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell16;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell17;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell18;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell19;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell20;
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
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRTable xrTable4;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell22;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell26;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell31;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrlblArt;
        private DevExpress.XtraReports.UI.XRLabel xrLabel33;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRTable xrTable3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell21;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell24;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell28;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell29;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell30;
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
                        "gBlAFAAcgBpAG4AdADzNAAAHHgAcgBMAGEAYgBlAGwAMwAzAC4AVABlAHgAdABXNgAAJngAcgBQAGkAY" +
                        "wB0AHUAcgBlAEIAbwB4ADEALgBJAG0AYQBnAGUAajcAAAHwaS0tIEFsbGUgVmFyaWFibGVuIMO8YmVyb" +
                        "mVobWVuDQpERUNMQVJFIEBEYXR1bVZvbiBkYXRldGltZQ0KU0VUIEBEYXR1bVZvbiA9IFNUUihEQVRFU" +
                        "EFSVCh5eXl5LCBHZXREYXRlKCkpKSArICcwMTAxJyAtLSBEZWZhdWx0LCBmYWxscyB2b24gS2lzcyBua" +
                        "WNodHMgw7xiZXJnZWJlbiB3dXJkZQ0KSUYgbnVsbCBpcyBub3QgbnVsbCBhbmQgbnVsbCBiZXR3ZWVuI" +
                        "DAgYW5kIDk5OTkgDQogICBzZWxlY3QgQERhdHVtVm9uID0gY2FzZSBsZW4oY2FzdChudWxsIGFzIG52Y" +
                        "XJjaGFyKDQpKSkNCiAgICAgICAgICAgICAgICAgICAgICB3aGVuIDEgdGhlbiAnMCcgKyBjYXN0KG51b" +
                        "GwgYXMgbnZhcmNoYXIoNCkpICsgJzAxMDEnDQogICAgICAgICAgICAgICAgICAgICAgd2hlbiAyIHRoZ" +
                        "W4gY2FzdChudWxsIGFzIG52YXJjaGFyKDQpKSArICcwMTAxJw0KICAgICAgICAgICAgICAgICAgICAgI" +
                        "HdoZW4gMyB0aGVuICcxJyArIGNhc3QobnVsbCBhcyBudmFyY2hhcig0KSkgKyAnMDEwMScNCiAgICAgI" +
                        "CAgICAgICAgICAgICAgICB3aGVuIDQgdGhlbiBjYXN0KG51bGwgYXMgbnZhcmNoYXIoNCkpICsgJzAxM" +
                        "DEnDQogICAgICAgICAgICAgICAgICAgICAgZWxzZSBTVFIoREFURVBBUlQoeXl5eSwgR2V0RGF0ZSgpK" +
                        "SkgKyAnMDEwMScgDQpFbmQNCg0KREVDTEFSRSBARGF0dW1CaXMgZGF0ZXRpbWUNClNFVCBARGF0dW1Ca" +
                        "XMgPSBTVFIoREFURVBBUlQoeXl5eSwgR2V0RGF0ZSgpKSkgKyAnMTIzMScgIC0tIERlZmF1bHQsIGZhb" +
                        "GxzIHZvbiBLaXNzIG5pY2h0cyDDvGJlcmdlYmVuIHd1cmRlDQpJRiBudWxsIGlzIG5vdCBudWxsIGFuZ" +
                        "CBudWxsIGJldHdlZW4gMCBhbmQgOTk5OSANCiAgIHNlbGVjdCBARGF0dW1CaXMgPSBjYXNlIGxlbihjY" +
                        "XN0KG51bGwgYXMgbnZhcmNoYXIoNCkpKQ0KICAgICAgICAgICAgICAgICAgICAgIHdoZW4gMSB0aGVuI" +
                        "CcwJyArIGNhc3QobnVsbCBhcyBudmFyY2hhcig0KSkgKyAnMTIzMScNCiAgICAgICAgICAgICAgICAgI" +
                        "CAgICB3aGVuIDIgdGhlbiBjYXN0KG51bGwgYXMgbnZhcmNoYXIoNCkpICsgJzEyMzEnDQogICAgICAgI" +
                        "CAgICAgICAgICAgICAgd2hlbiAzIHRoZW4gJzEnICsgY2FzdChudWxsIGFzIG52YXJjaGFyKDQpKSArI" +
                        "CcxMjMxJw0KICAgICAgICAgICAgICAgICAgICAgIHdoZW4gNCB0aGVuIGNhc3QobnVsbCBhcyBudmFyY" +
                        "2hhcig0KSkgKyAnMTIzMScNCiAgICAgICAgICAgICAgICAgICAgICBlbHNlIFNUUihEQVRFUEFSVCh5e" +
                        "Xl5LCBHZXREYXRlKCkpKSArICcxMjMxJyANCkVuZA0KDQpERUNMQVJFIEBTdGljaHRhZyBkYXRldGltZ" +
                        "Q0KLS1TRVQgQFN0aWNodGFnID0gR2V0RGF0ZSgpIC0tIERlZmF1bHQsIGZhbGxzIHZvbiBLaXNzIG5pY" +
                        "2h0cyDDvGJlcmdlYmVuIHd1cmRlDQpTRVQgQFN0aWNodGFnID0gREFURUFERCh5eSwxLEBEYXR1bUJpc" +
                        "ykNCklGIG51bGwgaXMgbm90IG51bGwgYW5kIG51bGwgPD4gTicnIFNFVCBAU3RpY2h0YWcgPSBudWxsD" +
                        "QoNCkRFQ0xBUkUgQFN1Y2hlQXJ0IGludA0KU0VUIEBTdWNoZUFydCA9IG51bGwNCg0KREVDTEFSRSBAU" +
                        "3VjaGVCYVBlcnNvbklEIGludA0KU0VUIEBTdWNoZUJhUGVyc29uSUQgPSBudWxsDQoNCkRFQ0xBUkUgQ" +
                        "FN1Y2hlS2xpZW50IHZhcmNoYXIoNTApDQpTRVQgQFN1Y2hlS2xpZW50ID0gbnVsbA0KSUYgbnVsbCBpc" +
                        "yBub3QgbnVsbCBhbmQgbnVsbCA8PiBOJycgU0VUIEBTdWNoZUtsaWVudCA9ICclJyArIHJlcGxhY2Uob" +
                        "nVsbCwgJyAnLCAnJScpICsgJyUnDQoNCkRFQ0xBUkUgQFN1Y2hlQXVzemFobHVuZ1ZvbiBkYXRldGltZ" +
                        "Q0KU0VUIEBTdWNoZUF1c3phaGx1bmdWb24gPSBudWxsDQpJRiBudWxsIGlzIG5vdCBudWxsIFNFVCBAU" +
                        "3VjaGVBdXN6YWhsdW5nVm9uID0gbnVsbA0KDQpERUNMQVJFIEBTdWNoZUF1c3phaGx1bmdCaXMgZGF0Z" +
                        "XRpbWUNClNFVCBAU3VjaGVBdXN6YWhsdW5nQmlzID0gbnVsbA0KSUYgbnVsbCBpcyBub3QgbnVsbCBTR" +
                        "VQgQFN1Y2hlQXVzemFobHVuZ0JpcyA9IG51bGwNCg0KREVDTEFSRSBAU3VjaGVNaWdyaWVydCBpbnQgD" +
                        "QpTRVQgQFN1Y2hlTWlncmllcnQgPSBudWxsDQoNCkRFQ0xBUkUgQFN1Y2hlTGF1ZmVuZCBpbnQgDQpTR" +
                        "VQgQFN1Y2hlTGF1ZmVuZCA9IG51bGwNCg0KREVDTEFSRSBAU3VjaGVOZXUgaW50IA0KU0VUIEBTdWNoZ" +
                        "U5ldSA9IG51bGwNCg0KREVDTEFSRSBAU3VjaGVJbnN0aXR1dGlvbiB2YXJjaGFyKDUwKQ0KU0VUIEBTd" +
                        "WNoZUluc3RpdHV0aW9uID0gbnVsbA0KSUYgbnVsbCBpcyBub3QgbnVsbCBhbmQgbnVsbCA8PiBOJycgU" +
                        "0VUIEBTdWNoZUluc3RpdHV0aW9uID0gJyUnICsgcmVwbGFjZShudWxsLCAnICcsICclJykgKyAnJScNC" +
                        "g0KREVDTEFSRSBAU3VjaGVLb250b05yIHZhcmNoYXIoNTApDQpTRVQgQFN1Y2hlS29udG9OciA9IG51b" +
                        "GwNCklGIG51bGwgaXMgbm90IG51bGwgYW5kIG51bGwgPD4gTicnIFNFVCBAU3VjaGVLb250b05yID0gJ" +
                        "yUnICsgcmVwbGFjZShudWxsLCAnICcsICclJykgKyAnJScNCg0KREVDTEFSRSBAU3VjaGVTdHJhc3NlI" +
                        "HZhcmNoYXIoNTApDQpTRVQgQFN1Y2hlU3RyYXNzZSA9IG51bGwNCklGIG51bGwgaXMgbm90IG51bGwgY" +
                        "W5kIG51bGwgPD4gTicnIFNFVCBAU3VjaGVTdHJhc3NlID0gJyUnICsgcmVwbGFjZShudWxsLCAnICcsI" +
                        "CclJykgKyAnJScNCg0KREVDTEFSRSBAU3VjaGVIYXVzTnIgdmFyY2hhcig1MCkNClNFVCBAU3VjaGVIY" +
                        "XVzTnIgPSBudWxsDQpJRiBudWxsIGlzIG5vdCBudWxsIGFuZCBudWxsIDw+IE4nJyBTRVQgQFN1Y2hlS" +
                        "GF1c05yICA9ICclJyArIHJlcGxhY2UobnVsbCwgJyAnLCAnJScpICsgJyUnDQoNCkRFQ0xBUkUgQFN1Y" +
                        "2hlUExaIHZhcmNoYXIoNTApDQpTRVQgQFN1Y2hlUExaID0gbnVsbA0KSUYgbnVsbCBpcyBub3QgbnVsb" +
                        "CBhbmQgbnVsbCA8PiBOJycgU0VUIEBTdWNoZVBMWiA9ICclJyArIHJlcGxhY2UobnVsbCwgJyAnLCAnJ" +
                        "ScpICsgJyUnDQoNCkRFQ0xBUkUgQFN1Y2hlT3J0IHZhcmNoYXIoNTApDQpTRVQgQFN1Y2hlT3J0ID0gb" +
                        "nVsbA0KSUYgbnVsbCBpcyBub3QgbnVsbCBhbmQgbnVsbCA8PiBOJycgU0VUIEBTdWNoZU9ydCA9ICclJ" +
                        "yArIHJlcGxhY2UobnVsbCwgJyAnLCAnJScpICsgJyUnDQoNCkRFQ0xBUkUgQFN1Y2hlRmFGYWxsSUQga" +
                        "W50IA0KU0VUIEBTdWNoZUZhRmFsbElEID0gbnVsbA0KDQpERUNMQVJFIEBTdWNoZUFsdGVQTnIgdmFyY" +
                        "2hhcig1MCkNClNFVCBAU3VjaGVBbHRlUE5yICA9IG51bGwNCklGIG51bGwgaXMgbm90IG51bGwgYW5kI" +
                        "G51bGwgPD4gTicnIFNFVCBAU3VjaGVBbHRlUE5yICA9ICclJyArIHJlcGxhY2UobnVsbCwgJyAnLCAnJ" +
                        "ScpICsgJyUnDQoNCg0KDQotLSBad2lzY2hlbnRhYmVsbGVuDQpERUNMQVJFIEB0bXBWU1RTaWNoZXJoZ" +
                        "Wl0c2xlaXN0dW5nIFRBQkxFDQooDQogIEJhUGVyc29uSUQgICAgICAgICAgICAgICAgICAgICAgICBpb" +
                        "nQsDQogIEJhU2ljaGVyaGVpdHNsZWlzdHVuZ0lEICAgICAgICAgICBpbnQsDQogIEJhTWlldGVTaWNoZ" +
                        "XJoZWl0c2xlaXN0dW5nQXJ0Q29kZSBpbnQsDQogIEphaHIgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICBpbnQsDQogIEJ1Y2h1bmdzRGF0dW0gICAgICAgICAgICAgICAgICAgICBkYXRldGltZSwNCiAgQ" +
                        "mFJbnN0aXR1dGlvbklEICAgICAgICAgICAgICAgICAgIGludCwNCiAgQmFCYW5rSUQgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgIGludCwNCiAgQnJ1dHRvemlucyAgICAgICAgICAgICAgICAgICAgICAgIG1vb" +
                        "mV5LA0KICBWU1QgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgbW9uZXksDQogIE5ldHRvemluc" +
                        "yAgICAgICAgICAgICAgICAgICAgICAgICBtb25leSwNCiAgTWlnQmVsZWdudW1tZXIgICAgICAgICAgI" +
                        "CAgICAgICAgIGludCwNCiAgS2JCdWNodW5nQnJ1dHRvSUQgICAgICAgICAgICAgICAgIGludCwNCiAgQ" +
                        "nVjaHVuZ3N0ZXh0ICAgICAgICAgICAgICAgICAgICAgIHZhcmNoYXIoMjAwKQ0KKQ0KDQotLQ0KLS0gQ" +
                        "WxsZSBTaWNoZXJoZWl0c2xlaXN0dW5nZW4gYmVpIHdlbGNoZW4gJ1ZTdCBlaW5mb3JkZXJiYXInIHZvc" +
                        "mhhbmRlbiBpc3QgKGF1cyAnTWlnRGV0YWlsQnVjaHVuZycgdW5pb24gYWxsICdLYkJ1Y2h1bmdCcnV0d" +
                        "G8nKQ0KLS0NCklOU0VSVCBAdG1wVlNUU2ljaGVyaGVpdHNsZWlzdHVuZyhCYVBlcnNvbklELCBCYVNpY" +
                        "2hlcmhlaXRzbGVpc3R1bmdJRCwgQmFNaWV0ZVNpY2hlcmhlaXRzbGVpc3R1bmdBcnRDb2RlLCBKYWhyL" +
                        "CBCdWNodW5nc0RhdHVtLCBWU1QsIEJhSW5zdGl0dXRpb25JRCwgQmFCYW5rSUQsIE1pZ0JlbGVnbnVtb" +
                        "WVyLCBLYkJ1Y2h1bmdCcnV0dG9JRCwgQnVjaHVuZ3N0ZXh0KQ0KU0VMRUNUIFNJQy5CYVBlcnNvbklEL" +
                        "A0KICAgICAgIFNJQy5CYVNpY2hlcmhlaXRzbGVpc3R1bmdJRCwNCiAgICAgICBTSUMuQmFNaWV0ZVNpY" +
                        "2hlcmhlaXRzbGVpc3R1bmdBcnRDb2RlLA0KICAgICAgIE1JRy5aaW5zcGVyaW9kZSBhcyBKYWhyLA0KI" +
                        "CAgICAgIE1BWChNSUcuQnVjaHVuZ3NEYXR1bSkgYXMgQnVjaHVuZ3NEYXR1bSwNCiAgICAgICBTVU0oT" +
                        "UlHLkJldHJhZykgYXMgQmV0cmFnLA0KICAgICAgIE1BWChTSUMuQmFJbnN0aXR1dGlvbklEKSBhcyBCY" +
                        "Uluc3RpdHV0aW9uSUQsDQogICAgICAgTUFYKFNJQy5CYUJhbmtJRCkgYXMgQmFCYW5rSUQsDQogICAgI" +
                        "CAgTUlHLkJlbGVnbnVtbWVyLA0KICAgICAgIE5VTEwsDQogICAgICAgTlVMTA0KRlJPTSBkYm8uQmFTa" +
                        "WNoZXJoZWl0c2xlaXN0dW5nICAgICAgICAgICAgICAgICBTSUMgV0lUSChSRUFEVU5DT01NSVRURUQpI" +
                        "A0KICBJTk5FUiBKT0lOIGRiby5CYVNpY2hlcmhlaXRzbGVpc3R1bmdQb3NpdGlvbiBTSVAgV0lUSChSR" +
                        "UFEVU5DT01NSVRURUQpIE9OIFNJUC5CYVNpY2hlcmhlaXRzbGVpc3R1bmdJRCA9IFNJQy5CYVNpY2hlc" +
                        "mhlaXRzbGVpc3R1bmdJRA0KICBJTk5FUiBKT0lOIGRiby5NaWdEZXRhaWxCdWNodW5nICAgICAgICAgI" +
                        "CAgICBNSUcgV0lUSChSRUFEVU5DT01NSVRURUQpIE9OIE1JRy5NaWdEZXRhaWxCdWNodW5nSUQgICAgI" +
                        "CA9IFNJUC5NaWdEZXRhaWxCdWNodW5nSUQNCldIRVJFIE1JRy5LaVNTTGVpc3R1bmdzYXJ0IElOICgnM" +
                        "DM0JykgLS0gMDM0ID0gSW52TURBUyBWU3QgZWluZm9yZGVyYmFyDQogIEFORCBNSUcuWmluc3BlcmlvZ" +
                        "GUgQkVUV0VFTiBZRUFSKEBEYXR1bVZvbikgQU5EIFlFQVIoQERhdHVtQmlzKSAtLUVpbnNjaHLDpG5rd" +
                        "W5nIGF1ZiBQZXJpb2RlDQogIEFORCAoQFN1Y2hlQmFQZXJzb25JRCBJUyBOVUxMIE9SIEBTdWNoZUJhU" +
                        "GVyc29uSUQgPSBTSUMuQmFQZXJzb25JRCkNCi0tICBBTkQgTUlHLkJ1Y2h1bmdzZGF0dW0gPD0gQFN0a" +
                        "WNodGFnDQpHUk9VUCBCWSBTSUMuQmFQZXJzb25JRCwgU0lDLkJhU2ljaGVyaGVpdHNsZWlzdHVuZ0lEL" +
                        "CBTSUMuQmFNaWV0ZVNpY2hlcmhlaXRzbGVpc3R1bmdBcnRDb2RlLCBNSUcuWmluc3BlcmlvZGUsIE1JR" +
                        "y5CZWxlZ251bW1lcg0KSEFWSU5HIFNVTShNSUcuQmV0cmFnKSA8PiAwDQoNClVOSU9OIEFMTA0KDQpTR" +
                        "UxFQ1QgU0lDLkJhUGVyc29uSUQsDQogICAgICAgU0lDLkJhU2ljaGVyaGVpdHNsZWlzdHVuZ0lELA0KI" +
                        "CAgICAgIFNJQy5CYU1pZXRlU2ljaGVyaGVpdHNsZWlzdHVuZ0FydENvZGUsDQogICAgICAgS0JQLlppb" +
                        "nNwZXJpb2RlIGFzIEphaHIsDQogICAgICAgTUFYKEtCQi5WYWx1dGFEYXR1bSkgYXMgVmFsdXRhRGF0d" +
                        "W0sDQogICAgICAgU1VNKC1LQlAuQmV0cmFnKSBhcyBCZXRyYWcsDQogICAgICAgTUFYKFNJQy5CYUluc" +
                        "3RpdHV0aW9uSUQpIGFzIEJhSW5zdGl0dXRpb25JRCwNCiAgICAgICBNQVgoU0lDLkJhQmFua0lEKSBhc" +
                        "yBCYUJhbmtJRCwNCiAgICAgICBOVUxMLA0KICAgICAgIEtCQi5LYkJ1Y2h1bmdCcnV0dG9JRCwNCiAgI" +
                        "CAgICBkYm8uQ29uY0Rpc3RpbmN0KEtCQi5UZXh0KQ0KRlJPTSBkYm8uQmFTaWNoZXJoZWl0c2xlaXN0d" +
                        "W5nICAgICAgICAgICAgICAgICBTSUMgV0lUSChSRUFEVU5DT01NSVRURUQpIA0KICBJTk5FUiBKT0lOI" +
                        "GRiby5CYVNpY2hlcmhlaXRzbGVpc3R1bmdQb3NpdGlvbiBTSVAgV0lUSChSRUFEVU5DT01NSVRURUQpI" +
                        "E9OIFNJUC5CYVNpY2hlcmhlaXRzbGVpc3R1bmdJRCA9IFNJQy5CYVNpY2hlcmhlaXRzbGVpc3R1bmdJR" +
                        "A0KICBJTk5FUiBKT0lOIGRiby5LYkJ1Y2h1bmdCcnV0dG8gICAgICAgICAgICAgICBLQkIgV0lUSChSR" +
                        "UFEVU5DT01NSVRURUQpIE9OIEtCQi5LYkJ1Y2h1bmdCcnV0dG9JRCAgICAgICA9IFNJUC5LYkJ1Y2h1b" +
                        "mdCcnV0dG9JRA0KICBJTk5FUiBKT0lOIGRiby5LYkJ1Y2h1bmdCcnV0dG9QZXJzb24gICAgICAgICBLQ" +
                        "lAgV0lUSChSRUFEVU5DT01NSVRURUQpIE9OIEtCUC5LYkJ1Y2h1bmdCcnV0dG9JRCAgICAgICA9IFNJU" +
                        "C5LYkJ1Y2h1bmdCcnV0dG9JRA0KICBJTk5FUiBKT0lOIGRiby5CZ0tvc3RlbmFydCAgICAgICAgICAgI" +
                        "CAgICAgICBCS0EgV0lUSChSRUFEVU5DT01NSVRURUQpIE9OIEJLQS5CZ0tvc3RlbmFydElEICAgICAgI" +
                        "CAgICA9IEtCUC5TcGV6QmdLb3N0ZW5hcnRJRA0KV0hFUkUgQktBLktvbnRvTnIgaW4gKCcwMzQnKSAtL" +
                        "SAwMzQgPSBJbnZNREFTIFZTdCBlaW5mb3JkZXJiYXINCiAgQU5EIEtCUC5aaW5zcGVyaW9kZSBiZXR3Z" +
                        "WVuIFlFQVIoQERhdHVtVm9uKSBBTkQgWUVBUihARGF0dW1CaXMpIC0tRWluc2NocsOkbmt1bmcgYXVmI" +
                        "FBlcmlvZGUNCiAgQU5EIChAU3VjaGVCYVBlcnNvbklEIElTIE5VTEwgT1IgQFN1Y2hlQmFQZXJzb25JR" +
                        "CA9IFNJQy5CYVBlcnNvbklEKQ0KLS0gIEFORCBLQkIuVmFsdXRhRGF0dW0gPD0gQFN0aWNodGFnDQpHU" +
                        "k9VUCBCWSBTSUMuQmFQZXJzb25JRCwgU0lDLkJhU2ljaGVyaGVpdHNsZWlzdHVuZ0lELCBTSUMuQmFNa" +
                        "WV0ZVNpY2hlcmhlaXRzbGVpc3R1bmdBcnRDb2RlLCBLQlAuWmluc3BlcmlvZGUsIEtCQi5LYkJ1Y2h1b" +
                        "mdCcnV0dG9JRA0KSEFWSU5HIFNVTShLQlAuQmV0cmFnKSA8PiAwDQoNCi0tDQotLSBCcnV0dG96aW5zZ" +
                        "W4gaG9sZW4gYXVzIGRlbiBNaWdyaWVydGVuIHVuZCBuZXVlbiBEYXRlbg0KLS0NCkRFQ0xBUkUgQHRtc" +
                        "FZTVEJydXR0b3ppbnMgVEFCTEUNCigNCiAgS2JCdWNodW5nQnJ1dHRvSUQgICAgICAgICAgICAgICAgI" +
                        "GludCwNCiAgQmFQZXJzb25JRCAgICAgICAgICAgICAgICAgICAgICAgIGludCwNCiAgQmFTaWNoZXJoZ" +
                        "Wl0c2xlaXN0dW5nSUQgICAgICAgICAgIGludCwNCiAgQmFNaWV0ZVNpY2hlcmhlaXRzbGVpc3R1bmdBc" +
                        "nRDb2RlIGludCwNCiAgSmFociAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIGludCwNCiAgQnJ1d" +
                        "HRvemlucyAgICAgICAgICAgICAgICAgICAgICAgIG1vbmV5DQopDQoNCklOU0VSVCBAdG1wVlNUQnJ1d" +
                        "HRvemlucyhLYkJ1Y2h1bmdCcnV0dG9JRCwgQmFQZXJzb25JRCwgQmFTaWNoZXJoZWl0c2xlaXN0dW5nS" +
                        "UQsIEJhTWlldGVTaWNoZXJoZWl0c2xlaXN0dW5nQXJ0Q29kZSwgSmFociwgQnJ1dHRvemlucykNClNFT" +
                        "EVDVCBWU1QuS2JCdWNodW5nQnJ1dHRvSUQsIFZTVC5CYVBlcnNvbklELCBWU1QuQmFTaWNoZXJoZWl0c" +
                        "2xlaXN0dW5nSUQsIFZTVC5CYU1pZXRlU2ljaGVyaGVpdHNsZWlzdHVuZ0FydENvZGUsIFZTVC5KYWhyL" +
                        "CBTVU0oLU1JRy5CZXRyYWcpDQpGUk9NIEB0bXBWU1RTaWNoZXJoZWl0c2xlaXN0dW5nICAgICAgVlNUD" +
                        "QogIElOTkVSIEpPSU4gZGJvLk1pZ0RldGFpbEJ1Y2h1bmcgTUlHIFdJVEgoUkVBRFVOQ09NTUlUVEVEK" +
                        "SBPTiBNSUcuQmVsZWdOdW1tZXIgSVMgTk9UIE5VTEwgQU5EIE1JRy5CZWxlZ051bW1lciA9IFZTVC5Na" +
                        "WdCZWxlZ251bW1lcg0KV0hFUkUgTUlHLktpU1NMZWlzdHVuZ3NhcnQgaW4gKCcwNDEnKSAtLSAwNDEgP" +
                        "SBJbnZNREFTIFppbnN2ZXJidWNodW5nDQogIEFORCBNSUcuQmFQZXJzb25JRCAgICA9IFZTVC5CYVBlc" +
                        "nNvbklEDQogIEFORCBNSUcuWmluc3BlcmlvZGUgICA9IFZTVC5KYWhyDQpHUk9VUCBCWSBWU1QuS2JCd" +
                        "WNodW5nQnJ1dHRvSUQsIFZTVC5CYVBlcnNvbklELCBWU1QuQmFTaWNoZXJoZWl0c2xlaXN0dW5nSUQsI" +
                        "FZTVC5CYU1pZXRlU2ljaGVyaGVpdHNsZWlzdHVuZ0FydENvZGUsIFZTVC5KYWhyDQoNClVOSU9OIEFMT" +
                        "CAtLSBCcnV0dG96aW5zZW4gaG9sZW4gYXVzIGRlbiBOZXVlbg0KDQpTRUxFQ1QgVlNULktiQnVjaHVuZ" +
                        "0JydXR0b0lELCBWU1QuQmFQZXJzb25JRCwgVlNULkJhU2ljaGVyaGVpdHNsZWlzdHVuZ0lELCBWU1QuQ" +
                        "mFNaWV0ZVNpY2hlcmhlaXRzbGVpc3R1bmdBcnRDb2RlLCBWU1QuSmFociwgU1VNKEtCUC5CZXRyYWcpD" +
                        "QpGUk9NIEB0bXBWU1RTaWNoZXJoZWl0c2xlaXN0dW5nICAgICAgICAgICAgICAgIFZTVA0KICBJTk5FU" +
                        "iBKT0lOIGRiby5LYkJ1Y2h1bmdCcnV0dG9QZXJzb24gICAgICAgICBLQlAgV0lUSChSRUFEVU5DT01NS" +
                        "VRURUQpIE9OIFZTVC5LYkJ1Y2h1bmdCcnV0dG9JRCBJUyBOT1QgTlVMTCBBTkQgS0JQLktiQnVjaHVuZ" +
                        "0JydXR0b0lEID0gVlNULktiQnVjaHVuZ0JydXR0b0lEDQogIElOTkVSIEpPSU4gZGJvLkJhU2ljaGVya" +
                        "GVpdHNsZWlzdHVuZyAgICAgICAgIFNJQyBXSVRIKFJFQURVTkNPTU1JVFRFRCkgT04gU0lDLkJhU2lja" +
                        "GVyaGVpdHNsZWlzdHVuZ0lEID0gVlNULkJhU2ljaGVyaGVpdHNsZWlzdHVuZ0lEDQogIElOTkVSIEpPS" +
                        "U4gZGJvLkJnS29zdGVuYXJ0ICAgICAgICAgICAgICAgICAgIEJLQSBXSVRIKFJFQURVTkNPTU1JVFRFR" +
                        "CkgT04gQktBLkJnS29zdGVuYXJ0SUQgPSBLQlAuU3BlekJnS29zdGVuYXJ0SUQNCldIRVJFIEJLQS5Lb" +
                        "250b05yICBpbiAoJzA0MScpIC0tIDA0MSA9IEludk1EQVMgWmluc3ZlcmJ1Y2h1bmcNCiAgQU5EIFNJQ" +
                        "y5CYVBlcnNvbklEICAgID0gVlNULkJhUGVyc29uSUQNCiAgQU5EIEtCUC5aaW5zcGVyaW9kZSAgID0gV" +
                        "lNULkphaHINCkdST1VQIEJZIFZTVC5LYkJ1Y2h1bmdCcnV0dG9JRCwgVlNULkJhUGVyc29uSUQsIFZTV" +
                        "C5CYVNpY2hlcmhlaXRzbGVpc3R1bmdJRCwgVlNULkJhTWlldGVTaWNoZXJoZWl0c2xlaXN0dW5nQXJ0Q" +
                        "29kZSwgVlNULkphaHINCi0tc2VsZWN0ICogZnJvbSBAdG1wVlNUQnJ1dHRvemlucyANCg0KLS0NCi0tI" +
                        "FZTVCBUYWJlbGxlIFVwZGF0ZW4gbWl0IEJydXR0by0gdW5kIE5ldHRvemlucywgc293aWUgQmFCYW5rS" +
                        "UQgYnp3LiBCYUluc3RpdHV0aW9uSUQNCi0tDQpVUERBVEUgVlNUDQpTRVQgVlNULkJydXR0b3ppbnMgI" +
                        "CAgICA9IFZTVEIuQnJ1dHRvemlucywNCiAgICBWU1QuTmV0dG96aW5zICAgICAgID0gVlNUQi5CcnV0d" +
                        "G96aW5zIC0gVlNULlZTVCwNCiAgICBWU1QuQmFCYW5rSUQgICAgICAgID0gU0lMLkJhQmFua0lELA0KI" +
                        "CAgIFZTVC5CYUluc3RpdHV0aW9uSUQgPSBTSUwuQmFJbnN0aXR1dGlvbklEDQpGUk9NIEB0bXBWU1RTa" +
                        "WNoZXJoZWl0c2xlaXN0dW5nICAgICAgICAgICBWU1QNCiAgSU5ORVIgSk9JTiBAdG1wVlNUQnJ1dHRve" +
                        "mlucyAgICAgICAgIFZTVEIgICAgICAgICAgICAgICAgICAgICAgIE9OIFZTVEIuS2JCdWNodW5nQnJ1d" +
                        "HRvSUQgICAgICAgICAgICAgICAgID0gVlNULktiQnVjaHVuZ0JydXR0b0lEDQogIElOTkVSIEpPSU4gZ" +
                        "GJvLkJhU2ljaGVyaGVpdHNsZWlzdHVuZyBTSUwgIFdJVEgoUkVBRFVOQ09NTUlUVEVEKSBPTiBTSUwuQ" +
                        "mFTaWNoZXJoZWl0c2xlaXN0dW5nSUQgICAgICAgICAgICA9IFZTVC5CYVNpY2hlcmhlaXRzbGVpc3R1b" +
                        "mdJRCBBTkQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgIFZTVEIuQmFTaWNoZXJoZWl0c2xlaXN0dW5nSUQgICAgICAgICAgID0gV" +
                        "lNULkJhU2ljaGVyaGVpdHNsZWlzdHVuZ0lEIEFORA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgVlNUQi5CYVBlcnNvbklEICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgPSBWU1QuQmFQZXJzb25JRCBBTkQNCiAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFZTVEIuQmFNa" +
                        "WV0ZVNpY2hlcmhlaXRzbGVpc3R1bmdBcnRDb2RlID0gVlNULkJhTWlldGVTaWNoZXJoZWl0c2xlaXN0d" +
                        "W5nQXJ0Q29kZSBBTkQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgIFZTVEIuSmFociAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgID0gVlNULkphaHINCi0tc2VsZWN0ICogZnJvbSBAdG1wVlNUU2ljaGVyaGVpdHNsZWlzdHVuZyBvc" +
                        "mRlciBieSAzDQoNCg0KLS0NCi0tIEFuemVpZ2UgaW0gUmVwb3J0DQotLQ0KU0VMRUNUIGlzTnVsbChAU" +
                        "3VjaGVBcnQsIC0xKSBhcyBBcnQsDQogICAgICAgaXNOdWxsKENPTlZFUlQodmFyY2hhciwgQFN0aWNod" +
                        "GFnLCAxMDQpLCAnJykgYXMgU3RpY2h0YWcsIA0KICAgICAgIEFSVC5TaG9ydFRleHQsDQogICAgICAgU" +
                        "FJTLkJhUGVyc29uSUQsIA0KICAgICAgIE5hbWVWb3JuYW1lID0gQ0FTRSBXSEVOIFBSUy5CYVBlcnNvb" +
                        "klEIElOICgxNjg1NjMsMTY4NTY0KSBUSEVOIFZTVC5CdWNodW5nc3RleHQgRUxTRSBQUlMuTmFtZVZvc" +
                        "m5hbWUgRU5ELCAtLUJlaSBEdW1teS1QZXJzb25lbiBkZW4gQnVjaHVuZ3N0ZXh0IGFscyBOYW1lbiB2Z" +
                        "XJ3ZW5kZW4sIGRvcnQgc3RlaHQgZGVyIGVpZ2VudGxpY2hlIE5hbWUuIFNvbnN0IG11c3MgZGllIExpc" +
                        "3RlIG1hbnVlbGwgZXJnw6RuenQgd2VyZGVuDQogICAgICAgW05hbWVdID0gaXNudWxsKElOUy5JbnN0a" +
                        "XR1dGlvbk5hbWUsIEJOSy5OYW1lKSwNCiAgICAgICBTSUMuS29udG9OdW1tZXIsIA0KICAgICAgIFZTV" +
                        "C5CdWNodW5nc0RhdHVtLCANCiAgICAgICBWU1QuSmFociwgDQogICAgICAgVlNULkJydXR0b3ppbnMsI" +
                        "A0KICAgICAgIFZTVC5WU1QsIA0KICAgICAgIFZTVC5OZXR0b3ppbnMNCkZST00gQHRtcFZTVFNpY2hlc" +
                        "mhlaXRzbGVpc3R1bmcgICAgICAgIFZTVA0KICBJTk5FUiBKT0lOIGRiby5CYVNpY2hlcmhlaXRzbGVpc" +
                        "3R1bmcgU0lDIFdJVEgoUkVBRFVOQ09NTUlUVEVEKSBPTiBTSUMuQmFTaWNoZXJoZWl0c2xlaXN0dW5nS" +
                        "UQgPSBWU1QuQmFTaWNoZXJoZWl0c2xlaXN0dW5nSUQNCiAgTEVGVCAgSk9JTiBkYm8uRmFMZWlzdHVuZ" +
                        "yAgICAgICAgICAgIExFSSBXSVRIKFJFQURVTkNPTU1JVFRFRCkgT04gTEVJLkJhUGVyc29uSUQgPSBTS" +
                        "UMuQmFQZXJzb25JRCANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgQU5EIExFSS5GYVByb3plc3NDb2RlID0gMzAwIA0KICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CBBTkQgTEVJLkZhTGVpc3R1bmdJRCA9IChTRUxFQ1QgVE9QIDEgRmFMZWlzdHVuZ0lEDQogICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgIEZST00gIEZhTGVpc3R1bmcNCiAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgV0hFUkUgQmFQZXJzb25JRCA9IFNJQy5CYVBlcnNvbklEIA0KICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgIEFORCBGYVByb3plc3NDb2RlID0gMzAwDQogICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgIE9SREVSIEJZIERhdHVtVm9uIERFU0MpDQogIElOTkVSIEpPSU4gZ" +
                        "GJvLnZ3UGVyc29uICAgICAgICAgICAgICBQUlMgV0lUSChSRUFEVU5DT01NSVRURUQpIE9OIFBSUy5CY" +
                        "VBlcnNvbklEID0gU0lDLkJhUGVyc29uSUQNCiAgTEVGVCAgSk9JTiBkYm8udndJbnN0aXR1dGlvbiAgI" +
                        "CAgICAgIElOUyBXSVRIKFJFQURVTkNPTU1JVFRFRCkgT04gSU5TLkJhSW5zdGl0dXRpb25JRCA9IFNJQ" +
                        "y5CYUluc3RpdHV0aW9uSUQNCiAgTEVGVCAgSk9JTiBkYm8uQmFCYW5rICAgICAgICAgICAgICAgIEJOS" +
                        "yBXSVRIKFJFQURVTkNPTU1JVFRFRCkgT04gQk5LLkJhQmFua0lEID0gU0lDLkJhQmFua0lEDQogIExFR" +
                        "lQgIEpPSU4gZGJvLlhMT1ZDb2RlICAgICAgICAgICAgICBBUlQgV0lUSChSRUFEVU5DT01NSVRURUQpI" +
                        "E9OIEFSVC5MT1ZOYW1lID0gJ0JhTWlldGVTaWNoZXJoZWl0c2xlaXN0dW5nQXJ0JyANCiAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQ" +
                        "U5EIEFSVC5Db2RlID0gU0lDLkJhTWlldGVTaWNoZXJoZWl0c2xlaXN0dW5nQXJ0Q29kZQ0KV0hFUkUgM" +
                        "SA9IDEgDQogIEFORCAoQFN1Y2hlQXJ0IElTIE5VTEwgICAgICAgICAgIE9SIFNJQy5CYU1pZXRlU2lja" +
                        "GVyaGVpdHNsZWlzdHVuZ0FydENvZGUgPSBAU3VjaGVBcnQpDQogIEFORCAoQFN1Y2hlQmFQZXJzb25JR" +
                        "CBJUyBOVUxMICAgIE9SIFNJQy5CYVBlcnNvbklEID0gQFN1Y2hlQmFQZXJzb25JRCkNCiAgQU5EIChAU" +
                        "3VjaGVLbGllbnQgSVMgTlVMTCAgICAgICAgT1IgUFJTLk5hbWVWb3JuYW1lIExJS0UgQFN1Y2hlS2xpZ" +
                        "W50KQ0KICBBTkQgKEBTdWNoZUF1c3phaGx1bmdWb24gSVMgTlVMTCBPUiBTSUMuQXVzemFobHVuZ0FtI" +
                        "D49IEBTdWNoZUF1c3phaGx1bmdWb24pDQogIEFORCAoQFN1Y2hlQXVzemFobHVuZ0JpcyBJUyBOVUxMI" +
                        "E9SIFNJQy5BdXN6YWhsdW5nQW0gPD0gQFN1Y2hlQXVzemFobHVuZ0JpcykNCiAgQU5EICgoQFN1Y2hlT" +
                        "WlncmllcnQgPSAxIEFORCBTSUMuTWlnRGFybGVoZW5JRCBJUyBOT1QgTlVMTCkgT1INCiAgICAgICAoQ" +
                        "FN1Y2hlTGF1ZmVuZCA9IDEgIEFORCBTSUMuTWlnRGFybGVoZW5JRCBJUyBOVUxMIEFORCBTSUMubmV1I" +
                        "D0gMCkgT1INCiAgICAgICAoQFN1Y2hlTmV1ID0gMSAgICAgIEFORCBTSUMubmV1ID0gMSkpDQogIEFOR" +
                        "CAoQFN1Y2hlSW5zdGl0dXRpb24gSVMgTlVMTCAgIE9SIElOUy5JbnN0aXR1dGlvbk5hbWUgTElLRSBAU" +
                        "3VjaGVJbnN0aXR1dGlvbikNCiAgQU5EIChAU3VjaGVLb250b05yIElTIE5VTEwgICAgICAgT1IgU0lDL" +
                        "ktvbnRvTnVtbWVyIExJS0UgQFN1Y2hlS29udG9OcikNCiAgQU5EIChAU3VjaGVTdHJhc3NlIElTIE5VT" +
                        "EwgICAgICAgT1IgU0lDLk9iamVrdFN0cmFzc2UgTElLRSBAU3VjaGVTdHJhc3NlKQ0KICBBTkQgKEBTd" +
                        "WNoZUhhdXNOciBJUyBOVUxMICAgICAgICBPUiBTSUMuT2JqZWt0SGF1c05yID0gQFN1Y2hlSGF1c05yK" +
                        "Q0KICBBTkQgKEBTdWNoZVBMWiBJUyBOVUxMICAgICAgICAgICBPUiBTSUMuT2JqZWt0UExaID0gQFN1Y" +
                        "2hlUExaKQ0KICBBTkQgKEBTdWNoZU9ydCBJUyBOVUxMICAgICAgICAgICBPUiBTSUMuT2JqZWt0T3J0I" +
                        "ExJS0UgQFN1Y2hlT3J0KQ0KICBBTkQgKEBTdWNoZUFsdGVQTnIgSVMgTlVMTCAgICAgICBPUiBTSUMuQ" +
                        "mFQZXJzb25JRCBJTiAoU0VMRUNUIERJU1RJTkNUIEJhUGVyc29uSUQgRlJPTSBCYUFsdGVGYWxsTnIgV" +
                        "0hFUkUgUGVyc29uTnJBbHQgPSBAU3VjaGVBbHRlUE5yKSkNCiAgQU5EIChAU3VjaGVGYUZhbGxJRCBJU" +
                        "yBOVUxMICAgICAgT1IgTEVJLkZhRmFsbElEID0gQFN1Y2hlRmFGYWxsSUQpDQpPUkRFUiBCWSBBUlQuU" +
                        "2hvcnRUZXh0LCBQUlMuTmFtZSwgVlNULkphaHIB4QJwcml2YXRlIHZvaWQgT25CZWZvcmVQcmludChvY" +
                        "mplY3Qgc2VuZGVyLCBTeXN0ZW0uRHJhd2luZy5QcmludGluZy5QcmludEV2ZW50QXJncyBlKQ0Kew0KI" +
                        "CAvLyBUZXh0IEFucGFzc2VuLCBqZSBuYWNoIGRlbSB3ZWxjaGUgJ0FydCcgYXVzZ2V3w6RobHQgd3VyZ" +
                        "GUNCiAgaWYgKHhybGJsQXJ0LlRleHQgPT0gIjIiKQ0KICAgICB4ckxhYmVsMzMuVGV4dCA9IHhyTGFiZ" +
                        "WwzMy5MaW5lc1sxXTsNCiAgZWxzZSBpZiAoeHJsYmxBcnQuVGV4dCA9PSAiMyIpDQogICAgIHhyTGFiZ" +
                        "WwzMy5UZXh0ID0geHJMYWJlbDMzLkxpbmVzWzJdOw0KICBlbHNlDQogICAgIHhyTGFiZWwzMy5UZXh0I" +
                        "D0geHJMYWJlbDMzLkxpbmVzWzBdOw0KfQGQAlZlcnJlY2hudW5nc3N0ZXVlciBSw7xja2ZvcmRlcnVuZ" +
                        "yBmw7xyIEFudGVpbHNzY2hlaW5lIChBUykgdW5kIE1pZXR6aW5zZGVwb3QgKE1EKSBwZXIgU3RpY2h0Y" +
                        "WcgW1N0aWNodGFnXQ0KVmVycmVjaG51bmdzc3RldWVyIFLDvGNrZm9yZGVydW5nIGbDvHIgTWlldHppb" +
                        "nNkZXBvdCAoTUQpIHBlciBTdGljaHRhZyBbU3RpY2h0YWddDQpWZXJyZWNobnVuZ3NzdGV1ZXIgUsO8Y" +
                        "2tmb3JkZXJ1bmcgZsO8ciBBbnRlaWxzc2NoZWluZSAoQVMpIHBlciBTdGljaHRhZyBbU3RpY2h0YWddQ" +
                        "AABAAAA/////wEAAAAAAAAADAIAAABRU3lzdGVtLkRyYXdpbmcsIFZlcnNpb249Mi4wLjAuMCwgQ3Vsd" +
                        "HVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlbj1iMDNmNWY3ZjExZDUwYTNhBQEAAAAVU3lzdGVtLkRyY" +
                        "XdpbmcuQml0bWFwAQAAAAREYXRhBwICAAAACQMAAAAPAwAAAFwTAAAC/9j/4AAQSkZJRgABAAEAYABgA" +
                        "AD//gAfTEVBRCBUZWNobm9sb2dpZXMgSW5jLiBWMS4wMQD/2wBDAAgGBgcGBQgHBwcKCQgKDRYODQwMD" +
                        "RsTFBAWIBwiIR8cHx4jKDMrIyYwJh4fLD0tMDU2OTo5Iis/Qz44QzM4OTf/2wBDAQkKCg0LDRoODho3J" +
                        "B8kNzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzf/wAARCAAyA" +
                        "NsDAREAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFB" +
                        "AQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3O" +
                        "Dk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipq" +
                        "rKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBA" +
                        "QEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiM" +
                        "oEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ" +
                        "2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1" +
                        "dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD2zXPEGmeHLH7XqdyIoydqKFLPI2M7V" +
                        "UcseO1AGJ4V+IujeL7xbXTob2ORoDcD7RDsBQNt9T3P86ALeueOvD+gN5dzeiacOUaC1HnSIQpY7lXle" +
                        "AetAGQ3xa8NpuDR6kNuc5sZOMZz2/2W/I0AL/wtnw3nAj1Inn/lxk7Z9vY/lQBv6H4r0XxDEjaffRmZt" +
                        "3+juwWZdrFTlDyOQe1AGFrPxU0DQtYl0y7g1BpYZ0gd4rbeoZhkdDk8eg9cZoA63TdSstX0+G/0+5S4t" +
                        "ZhlJEOQf8+lAFqgDhfEfxd8J+GdUk0y5uJ7m8iOJY7WLf5Z9GPAz7UAbnh7xloPijR5dU0q/WW2gz524" +
                        "FWiwM/MDyOKAL+j63puv2AvtJvI7u1LFRJGeMjqKAL9ABQBhN4u0hPGC+FjM/8AarQ+cI/LO3bjP3una" +
                        "gC3p3iDSdWvb2z0+/iuLmxfZcRoeY2yRg/kfyoAdres2Xh7RrnVtRdktLZQ0jKpYgZA6D3NAHCf8L48B" +
                        "/8AP/c/+Ar/AOFAHQ/8LE8O/wDCGDxX9ol/skvsD+S27O7b93r1oAuab4x0bVtfm0S0mka+ht1uWVomU" +
                        "bGCkHJ4z8w4oA3qAMOz8W6TfeKb3w5byyHUrJBJMhjIUDjo3Q/eFAG5QBhap4u0jRvEGmaJeTOl9qRxb" +
                        "qsZIbnHJHSgDdoAKACgAoA4vV2t4PihpUmqELaT6fJb2TOcKtwWBcZ7MyYA9cECgDm9Q8Dv4NMPiBZH1" +
                        "mx0yICS12+VKIUOVYMpAkKDPDDkUAcQNCnkl07WLeBYv7Nu8XU0Ibc8lwWkdWkQFiI1ZFJ55YigDUi05" +
                        "o5bdjrO4RXUlwRuvRkOG+X/AFfH3jz3oALSwe1ayc6yXNq0zH570b95J/558Yz+NAGZpFg3hKDT9Q1HT" +
                        "zNMG/tXATZcTxSqYpItxwSVZkbaeob1FAHoegfDea3uotV1K9W0H2iO8axiG8R+XkxxmZyWIUkk9BmgD" +
                        "Y8CNDPqHie804D+x7jUN1sy/cdgiiV09i4PI6kE0AdnQB4PDo3jTwF4s1zWPDGn2XiPTdRnMkmxw0qZY" +
                        "tt4OQeT0yDxQAeF7vRfEGjeLoNAtLrwp4haMzX0eTKGVclgqtgKMkgjAxnigCz8FLfVrL4aX+q22rRlM" +
                        "TLb2l0AkEMg58xn649aAOZ1rxvrWjaQmqW3xGbVNaWcebaWtvvtFUk8bioHp+f40Adp4h8UeJPE3jbQ/" +
                        "CGh6l/Y/n2KXt3com5uV3bVz6D+ftQBiabpet2n7QC6fqesfa7z+y5EhvxEFfaUbaxXpuBz9cUAP+Emj" +
                        "6qvxH8UsfEExWyvMXSmJcXpy4y393nnigD3WdIZIHW4VGhx8wkAK4980AfP2ut/wt/xsvhvw3bw2vh3T" +
                        "3D3d7HCo8wjjIOPqFHfqfYA6vx7d3PgeXwPofh2X7Fp0t2IJYlUESJuTrkdeTz70AXfFniHVdN+MfhPR" +
                        "7O7MVhexk3EQUYkwW6nGewoA5jT9S8f+MPG3ivQdM8RLp9lY3bfv2jDPGochUXHrg5PtQBtWfjLU7P4q" +
                        "eMLa8umm0vSdONwkG0DBVUJ5xnnn86AMrQk+JPjTww/i+w8UfZbmWRjaaasSiEqrYwSfoeuf8ACn8QD4" +
                        "guvHvw8Egt7LX3jKsT+8jik3AFsdx3xQBteHtV8U+G/jJH4S1jX31mzvbUzpJLGFKHDHgDpypGOnIoA9" +
                        "hoAKACgDzn4g6jfahqN14atYNNa3t9LbU7k36M4kUMVCrgjaRtJ3dRxigDjpfE+sR6JLaHUruHSIIrZh" +
                        "fyASyWzTxZEEynmVAGA3D5hkHnFAHPTS6xodt4etNP/ALWt7KK32lbCd2i1SbfuYxyRnqyEkEjjbg9KA" +
                        "PVPDuiaP4n0tb6w8S+JRg7JYZNUlWSFx1R1zwRQBr/8IDb/APQxeI//AAay/wCNAHkmsb7pb9zeX32DT" +
                        "9WSew1nUpGkjjWMBXVcndKzOpGwDnA9KANDU/EGsalpRsb+Wc2Itre4tY7qQA6gs02wSTlD8qAnPlr2I" +
                        "BNAHpXgjVL2SfV/D+oR2fn6LJHEJLKPy4nRk3KAv8JHQj6UAddQB5Evw18X+E9a1C68Da9aQWN/J5j2t" +
                        "5HkIcnpwc4/CgDX8HfDW60ebXNU13Vhfa1rMTRTTRJtSNT1wO/b06CgDL8O/C3xBpng/WfCV9rlrJpN3" +
                        "EwtzDEQ6SEg7mz246Z70AZtx8K/G2o+CYvClzrOj2+nWpUx+RA++Yg8b2/EngcnrQBveIPhxrMmpaF4h" +
                        "8O6pb2evabaJbS+apMUyhcfXufwx0xQAnh/4d+JLX4kQ+MNd1u0vZjbtHLHFEU2kqQAvsOP1oAn0LwD4" +
                        "g8OfETU9asdYtTo+qTma5t3jPmEckAHpwW6+lAHR+PNA1LxN4Ru9H0q/WxnuCqtK2cFM/MvHPI4oA820" +
                        "D4WfETwvYNZaN4u0+0gZy7KsBJLccklcnpQBs+Ifht4n8ReFdIS98QwS+ItLumnjuihCMCQQOBwRgc4o" +
                        "AS3+HXiy+8c6H4p8Qa9ZXM9hw8MMRRVXnAXjk8kknFAG94M8D3nhnxb4o1i4u4ZotXn82JIwQyDcxwc/" +
                        "wC8OnpQBBZ/DyZPiH4i1+8uYZdP1e0NsbdQQ4BCg5PT+E0Ac3B8M/HOlaPceF9I8U2kfh+ZyVkeJhcRo" +
                        "TkqCP8AH8qANy9+Gdw3iLwde2moK1r4fQLJ9o3NLNzknPqeaAL954HvLj4uWHjFbuBbS2tTA0BB3kkOM" +
                        "+n8Q/KgDuKACgAoA8q+NEFpJY2Atbh08RTk21tbwuFe5hcgSxn/AGcc57GgDlNA8Qw/a7TUbqzZtOguT" +
                        "q18iyLugMh8m3JU8ssaLk46ZB7UAanxM8K6ZpniLQrjTbE7L17gyW8ccs0e8KCHWKNgQ3XJXHvQBhaeN" +
                        "a8MaoNY8P6fdxzKNs1lFpF0iXgz0YuzYbrhqAPb/DHiew8U6X9rs98csbeXcW0o2y28g6o69j/OgDifC" +
                        "emaFYw+IvF+oQBhaajeyQlyWSCNWOfLTO0E4PI5NAHnesXV0tounQ6XItyvmW1rZ+apkS3uh5kCsRwGS" +
                        "RBweQMUAeu/CptMm8Gx3VlfG9vbl/N1GZzmQ3JALhvTHAA9AKAO3oA5U+KtSv7u7TQNB/tC2tJmgkuJb" +
                        "pYFeReGVOCWweMnAyKANLw94hg1+3uCLeW0u7SUw3VrNjfC+AcHHBBBBBHBBoA2KACgCpd3c1tdWUUVl" +
                        "JOlxIUkkQjEI2k7m9sgD8aALdAGZfazHY63pOmNCzvqLShXBGE2JuOfrQBp0AFAHL3vinUV8R3mjaXoD" +
                        "372kUcssn2pIgN+cAA9fumgCfTPFX2nVl0jVNMuNK1GRC8McxV0nUfe2OpIJHccH2oA1rC7muxcmaykt" +
                        "fKneJBIQfMUHhxjse1AFugAoAKAGSyLDE8jZ2opY49BQBW0rUrfWNJtdStd32e6jWWPeMHaRkZFAFygA" +
                        "oA474jxWVv4YudVNnBJqsUZtrGZ1BeOSYiMbT2+9n8KAOFnFs93a3s1oh8GWlo/h8Xa8MNwCNOfWPcuz" +
                        "PY80AV/Et0dW+HGkzXMsM2o+GrsQanEwLlEXMTSFFYMQflbqOtAGSumh1DJppZSMgjQrzBH/f6gCA3F9" +
                        "4OuD4k01ZbF7ZP38Q0eeGK6XI+SRndsex7GgDrJJ4rbwPoXhvU54re41Cd9R1WNnGbe23tcOHHUZyqc9" +
                        "cmgDPu579dH1me508WUWvTNq+js/wDrFmiKuI3PZnRAwHuwoA9d8N2+kx6PFeaPZwW1vqAF2RCgUOzgH" +
                        "ccd6ANegDhtP0nVLZJ7/wAF67ZTaXeTyTi0vIS8auzHfskUhgN2eCDg5oApah4rv49D1+2ewi0nxFbvb" +
                        "xTSxEOhWZgiTK2ATgbuD0IoAm8S+GLHwv4Zutc0eSe31TTo/PFy9w7tPt5ZZMnDBhkH68YoAl8X2ekSN" +
                        "bzLp0l3r+pgJawfaZUGQvLuFYAIo5Jx7dTQBC+jv4Xk8D6VFe3E2NQk8+V5GJlYwSk5yemeg7YFAFSW0" +
                        "0nWb3VZTYar4iuWnkVbqEmGK3wcCONy4A245Zc85oATQr+61P8A4VreXsrS3MsVwZHY5LHySMn1PFAGb" +
                        "pD2/iPTH1bVvD+v31/dySMl1bMAsChyEWLEg2hQB2yTnNAHovhKbVJvC1g2tRPHqIQrMJMBiQSAxwSMk" +
                        "AE/WgDK0f8A5Kh4m/69LT+T0AHjfb/aPhMR/wDH1/bEfl467dj+Z+G3NAHLXmr30OiXtrFJev8AbvFE1" +
                        "m5tWzMIssxWMkjBITHXjJoAvWED6f4g0qXw94a1nTommEV8twR5LwkH5jmQ/MpwQQMnnNAD/Cvhax8Ra" +
                        "PqFxrMlxeSNf3SQlp3H2dRKwATB4PGc9aAK0KaxrvgfwtdSxz6tbQl/7QtY5/LlulXKK2cjdggEqSMmg" +
                        "C3pFpod5Dr+l2/9oWkDW6ySaPdh42hIz+8Q5ztYgfdOMrQBlWwOg/CTw9HpSXaS6u9tDO1s5abDDL+Xu" +
                        "OFYhSBjGM0AX7S3aw1vSpvDvhnWtO/0hYrz7QR5MkByCWzIcsDgg9evrQB6XQBh+KvDzeI9Lit4rw2lx" +
                        "b3EdzBLsDqJEORuU8MPagCLQPCdrpHhQ6DdSfb4ZfMM/mIFV/MJLAKOFXk4A6UAY/hz4cR6JrbXtzqRv" +
                        "oY7V7OCJ4FU+UxBIlYf60gAAZ7CgDKuvg3p0N5LPo80McMhz9lvYWnjj/3CHVlHtk0AWdE+Eek2WrRan" +
                        "qbpeTQkNFbxReVbow6HYSSxHufwoAsXHwygu/E91f3GoeZpl3crdz2ZgXfJIAAFMvUx5UHZ04oA2PF3h" +
                        "WXxGmny2uofYbuwlaSJ2hEqHchQ5Q8E4PB7GgDT0DR4vD/h+x0iGV5Y7SJYg8n3mx3NAGlQByaeEL7TL" +
                        "m4bw/4gl021uJGla0e3SeNHY5YpnBUE5OM4yaAJrTwVYrpuqW+pXE2pXGqgC8uZiFZwBhQoXAQL2A6Hm" +
                        "gCB/B19exQ2WseI7jUNLiZWNu0KI0205USOOWGQM4AzjmgAuPCGot4lvdbtPEk1vPcosYU2scgijH8Cl" +
                        "hwM8n1NAF0eG7i4l0mfUtWlvLjTbprhJPJSPfmNk2kLxgbic0AUbfwbeWSTWNl4huLfR5ZXk+yrCpdA5" +
                        "LMiy9QCSe2Rng0AS6R4Jh0hdDjW/mlj0Zpvs6uqj5HUqFJHXaD170AM/wCEQv7JrqDRfEU+nafcyNIbc" +
                        "QJIYmY5by2P3QSScc4J4oA6DStMtdF0q202zUrb26BE3HJPuT3JPJNAGHe+FL6TxHd6zpniCfTpLuKOK" +
                        "WNbeORTszg/MOOpoAn0vwqlnqq6tqOo3Wq6kiGOOa42hYVPUIigKucDJ6mgCKTwXZy6VfWTXU6tc376h" +
                        "HOhCvBKW3AqfY+vUUALbeGL2XVLS91vW5NS+xEvbwiBYUVyMb2A+8wBOOwyeKANLQtFi0GwktIpXlV7i" +
                        "WfcwAILuWI/DOKAMZPA62ulaTb6fqk9re6UZPs91sVshySysp4YHj8higC5pnhmS31C61LVNSk1G/uIB" +
                        "bb/ACxEkcWc7VUdMk5JJJ6UAVLXwSkfhX/hH7vVJ7m3hZDZyhFjltthBTDDqVIHJoAlg8L30+o2d1reu" +
                        "yakli/mwQiBYU8zBAdtv3iATjoO+KAOmoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACg" +
                        "AoAKACgAoAKACgAoAKAP//ZCw==";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
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
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
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
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
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
            this.PageHeader.Height = 56;
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
            this.xrTable2.Size = new System.Drawing.Size(2669, 42);
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell11,
                        this.xrTableCell12,
                        this.xrTableCell13,
                        this.xrTableCell14,
                        this.xrTableCell15,
                        this.xrTableCell16,
                        this.xrTableCell17,
                        this.xrTableCell18,
                        this.xrTableCell19,
                        this.xrTableCell20});
            this.xrTableRow2.Dpi = 254F;
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Size = new System.Drawing.Size(2669, 42);
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ShortText", "")});
            this.xrTableCell11.Dpi = 254F;
            this.xrTableCell11.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell11.Size = new System.Drawing.Size(70, 42);
            this.xrTableCell11.Text = "xrTableCell11";
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BaPersonID", "")});
            this.xrTableCell12.Dpi = 254F;
            this.xrTableCell12.Location = new System.Drawing.Point(70, 0);
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell12.Size = new System.Drawing.Size(120, 42);
            this.xrTableCell12.Text = "xrTableCell12";
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameVorname", "")});
            this.xrTableCell13.Dpi = 254F;
            this.xrTableCell13.Location = new System.Drawing.Point(190, 0);
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell13.Size = new System.Drawing.Size(678, 42);
            this.xrTableCell13.Text = "xrTableCell13";
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.xrTableCell14.Dpi = 254F;
            this.xrTableCell14.Location = new System.Drawing.Point(868, 0);
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell14.Size = new System.Drawing.Size(656, 42);
            this.xrTableCell14.Text = "xrTableCell14";
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KontoNummer", "")});
            this.xrTableCell15.Dpi = 254F;
            this.xrTableCell15.Location = new System.Drawing.Point(1524, 0);
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell15.Size = new System.Drawing.Size(338, 42);
            this.xrTableCell15.Text = "xrTableCell15";
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BuchungsDatum", "{0:dd.MM.yyyy}")});
            this.xrTableCell16.Dpi = 254F;
            this.xrTableCell16.Location = new System.Drawing.Point(1862, 0);
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell16.Size = new System.Drawing.Size(172, 42);
            this.xrTableCell16.Text = "xrTableCell16";
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Jahr", "")});
            this.xrTableCell17.Dpi = 254F;
            this.xrTableCell17.Location = new System.Drawing.Point(2034, 0);
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell17.Size = new System.Drawing.Size(136, 42);
            this.xrTableCell17.Text = "xrTableCell17";
            this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bruttozins", "{0:n2}")});
            this.xrTableCell18.Dpi = 254F;
            this.xrTableCell18.Location = new System.Drawing.Point(2170, 0);
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell18.Size = new System.Drawing.Size(170, 42);
            this.xrTableCell18.Text = "xrTableCell18";
            this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VST", "{0:n2}")});
            this.xrTableCell19.Dpi = 254F;
            this.xrTableCell19.Location = new System.Drawing.Point(2340, 0);
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell19.Size = new System.Drawing.Size(170, 42);
            this.xrTableCell19.Text = "xrTableCell19";
            this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Nettozins", "{0:n2}")});
            this.xrTableCell20.Dpi = 254F;
            this.xrTableCell20.Location = new System.Drawing.Point(2510, 0);
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell20.Size = new System.Drawing.Size(159, 42);
            this.xrTableCell20.Text = "xrTableCell20";
            this.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            this.xrTable1.Size = new System.Drawing.Size(2669, 42);
            // 
            // Line1
            // 
            this.Line1.Dpi = 254F;
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.LineWidth = 3;
            this.Line1.Location = new System.Drawing.Point(0, 45);
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
                        this.xrTableCell10});
            this.xrTableRow1.Dpi = 254F;
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Size = new System.Drawing.Size(2669, 42);
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Dpi = 254F;
            this.xrTableCell1.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell1.Size = new System.Drawing.Size(70, 42);
            this.xrTableCell1.Text = "Typ";
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Dpi = 254F;
            this.xrTableCell2.Location = new System.Drawing.Point(70, 0);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell2.Size = new System.Drawing.Size(120, 42);
            this.xrTableCell2.Text = "PNr";
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Dpi = 254F;
            this.xrTableCell3.Location = new System.Drawing.Point(190, 0);
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell3.Size = new System.Drawing.Size(678, 42);
            this.xrTableCell3.Text = "Name, Vorname";
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Dpi = 254F;
            this.xrTableCell4.Location = new System.Drawing.Point(868, 0);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell4.Size = new System.Drawing.Size(656, 42);
            this.xrTableCell4.Text = "Baugenossenschaft / Depothalter";
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Dpi = 254F;
            this.xrTableCell5.Location = new System.Drawing.Point(1524, 0);
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell5.Size = new System.Drawing.Size(338, 42);
            this.xrTableCell5.Text = "Konto-Nr.";
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Dpi = 254F;
            this.xrTableCell6.Location = new System.Drawing.Point(1862, 0);
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell6.Size = new System.Drawing.Size(172, 42);
            this.xrTableCell6.Text = "Eingang per";
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Dpi = 254F;
            this.xrTableCell7.Location = new System.Drawing.Point(2034, 0);
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell7.Size = new System.Drawing.Size(136, 42);
            this.xrTableCell7.Text = "VST Jahr";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Dpi = 254F;
            this.xrTableCell8.Location = new System.Drawing.Point(2170, 0);
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell8.Size = new System.Drawing.Size(170, 42);
            this.xrTableCell8.Text = "Bruttozins";
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Dpi = 254F;
            this.xrTableCell9.Location = new System.Drawing.Point(2340, 0);
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell9.Size = new System.Drawing.Size(170, 42);
            this.xrTableCell9.Text = "VST (35%)";
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Dpi = 254F;
            this.xrTableCell10.Location = new System.Drawing.Point(2510, 0);
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell10.Size = new System.Drawing.Size(159, 42);
            this.xrTableCell10.Text = "Nettozins";
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            this.xrTable4.Size = new System.Drawing.Size(2669, 42);
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
                        this.xrTableCell22,
                        this.xrTableCell26,
                        this.xrTableCell31});
            this.xrTableRow4.Dpi = 254F;
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Size = new System.Drawing.Size(2669, 42);
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageInfo2});
            this.xrTableCell22.Dpi = 254F;
            this.xrTableCell22.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell22.Size = new System.Drawing.Size(868, 42);
            this.xrTableCell22.Text = "Typ";
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageInfo1});
            this.xrTableCell26.Dpi = 254F;
            this.xrTableCell26.Location = new System.Drawing.Point(868, 0);
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell26.Size = new System.Drawing.Size(994, 42);
            this.xrTableCell26.Text = "Baugenossenschaft / Depothalter";
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Dpi = 254F;
            this.xrTableCell31.Location = new System.Drawing.Point(1862, 0);
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell31.Size = new System.Drawing.Size(807, 42);
            this.xrTableCell31.Text = "KiSS 4";
            this.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            this.xrPageInfo2.Size = new System.Drawing.Size(868, 43);
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
            this.xrPageInfo1.Size = new System.Drawing.Size(994, 43);
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrlblArt
            // 
            this.xrlblArt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Art", "")});
            this.xrlblArt.Dpi = 254F;
            this.xrlblArt.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrlblArt.Location = new System.Drawing.Point(0, 212);
            this.xrlblArt.Name = "xrlblArt";
            this.xrlblArt.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrlblArt.ParentStyleUsing.UseFont = false;
            this.xrlblArt.Size = new System.Drawing.Size(190, 43);
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
            this.xrLabel33.Size = new System.Drawing.Size(2170, 85);
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
            this.xrPictureBox1.Size = new System.Drawing.Size(868, 127);
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
            this.xrTable3.Size = new System.Drawing.Size(2669, 42);
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
            this.xrLine2.Size = new System.Drawing.Size(2669, 21);
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
                        this.xrTableCell21,
                        this.xrTableCell24,
                        this.xrTableCell28,
                        this.xrTableCell29,
                        this.xrTableCell30});
            this.xrTableRow3.Dpi = 254F;
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Size = new System.Drawing.Size(2669, 42);
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Art", "")});
            this.xrTableCell21.Dpi = 254F;
            this.xrTableCell21.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell21.Size = new System.Drawing.Size(868, 42);
            xrSummary1.FormatString = "{0} Positionen";
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Count;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell21.Summary = xrSummary1;
            this.xrTableCell21.Text = "xrTableCell21";
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Dpi = 254F;
            this.xrTableCell24.Location = new System.Drawing.Point(868, 0);
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell24.Size = new System.Drawing.Size(1302, 42);
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bruttozins", "")});
            this.xrTableCell28.Dpi = 254F;
            this.xrTableCell28.Location = new System.Drawing.Point(2170, 0);
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell28.Size = new System.Drawing.Size(170, 42);
            xrSummary2.FormatString = "{0:n2}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell28.Summary = xrSummary2;
            this.xrTableCell28.Text = "xrTableCell28";
            this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VST", "")});
            this.xrTableCell29.Dpi = 254F;
            this.xrTableCell29.Location = new System.Drawing.Point(2340, 0);
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell29.Size = new System.Drawing.Size(170, 42);
            xrSummary3.FormatString = "{0:n2}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell29.Summary = xrSummary3;
            this.xrTableCell29.Text = "xrTableCell29";
            this.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Nettozins", "")});
            this.xrTableCell30.Dpi = 254F;
            this.xrTableCell30.Location = new System.Drawing.Point(2510, 0);
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell30.Size = new System.Drawing.Size(159, 42);
            xrSummary4.FormatString = "{0:n2}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell30.Summary = xrSummary4;
            this.xrTableCell30.Text = "xrTableCell30";
            this.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
}' , ParameterXML =  N'<NewDataSet>
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
</NewDataSet>' , SQLquery =  N'-- Alle Variablen übernehmen
DECLARE @DatumVon DATETIME;
SET @DatumVon = ''17530101''; -- Default, falls von Kiss nichts übergeben wurde
IF {edtSucheJahrVon} IS NOT NULL 
BEGIN
  SET @DatumVon = {edtSucheJahrVon};
END;

DECLARE @DatumBis DATETIME;
SET @DatumBis = GETDATE(); -- Default, falls von Kiss nichts übergeben wurde
IF {edtSucheJahrBis} IS NOT NULL 
BEGIN 
  SET @DatumBis = {edtSucheJahrBis};
END;

/*Stichtag wird in FrmSicherheitsleistungen immer mit NULL übergeben!!!!*/
DECLARE @Stichtag DATETIME;
SET @Stichtag = @DatumBis;
IF ({edtStichtag} IS NOT NULL AND {edtStichtag} <> N'''')
BEGIN 
  SET @Stichtag = {edtStichtag};
END;

DECLARE @SucheArt INT;
SET @SucheArt = {edtSucheArt};

DECLARE @SucheBaPersonID INT;
SET @SucheBaPersonID = {edtSucheBaPersonID};

DECLARE @SucheKlient VARCHAR(50);
SET @SucheKlient = NULL;
IF ({edtSucheKlient} IS NOT NULL AND {edtSucheKlient} <> N'''')
BEGIN
  SET @SucheKlient = ''%'' + REPLACE({edtSucheKlient}, '' '', ''%'') + ''%'';
END;

DECLARE @SucheAuszahlungVon DATETIME;
SET @SucheAuszahlungVon = NULL;
IF ({edtSucheAuszahlungVon} IS NOT NULL)
BEGIN 
  SET @SucheAuszahlungVon = {edtSucheAuszahlungVon};
END;

DECLARE @SucheAuszahlungBis DATETIME;
SET @SucheAuszahlungBis = NULL;
IF ({edtSucheAuszahlungBis} IS NOT NULL)
BEGIN
  SET @SucheAuszahlungBis = {edtSucheAuszahlungBis};
END;

DECLARE @SucheMigriert INT;
SET @SucheMigriert = {edtSucheMigriert};

DECLARE @SucheLaufend INT;
SET @SucheLaufend = {edtSucheLaufend};

DECLARE @SucheNeu INT;
SET @SucheNeu = {edtSucheNeu};

DECLARE @SucheInstitution VARCHAR(50);
SET @SucheInstitution = NULL;
IF ({edtSucheInstitution} IS NOT NULL AND {edtSucheInstitution} <> N'''')
BEGIN 
  SET @SucheInstitution = ''%'' + REPLACE({edtSucheInstitution}, '' '', ''%'') + ''%'';
END;

DECLARE @SucheKontoNr VARCHAR(50);
SET @SucheKontoNr = NULL;
IF ({edtSucheKontoNr} IS NOT NULL AND {edtSucheKontoNr} <> N'''')
BEGIN
  SET @SucheKontoNr = ''%'' + REPLACE({edtSucheKontoNr}, '' '', ''%'') + ''%'';
END;

DECLARE @SucheStrasse VARCHAR(50);
SET @SucheStrasse = NULL;
IF ({edtSucheStrasse} IS NOT NULL AND {edtSucheStrasse} <> N'''')
BEGIN
  SET @SucheStrasse = ''%'' + REPLACE({edtSucheStrasse}, '' '', ''%'') + ''%'';
END;

DECLARE @SucheHausNr VARCHAR(50);
SET @SucheHausNr = NULL;
IF ({edtSucheHausNr} IS NOT NULL AND {edtSucheHausNr} <> N'''')
BEGIN
  SET @SucheHausNr  = ''%'' + REPLACE({edtSucheHausNr}, '' '', ''%'') + ''%'';
END;

DECLARE @SuchePLZ VARCHAR(50);
SET @SuchePLZ = NULL;
IF ({edtSuchePLZ} IS NOT NULL AND {edtSuchePLZ} <> N'''')
BEGIN
  SET @SuchePLZ = ''%'' + REPLACE({edtSuchePLZ}, '' '', ''%'') + ''%'';
END;

DECLARE @SucheOrt VARCHAR(50);
SET @SucheOrt = NULL;
IF ({edtSucheOrt} IS NOT NULL AND {edtSucheOrt} <> N'''')
BEGIN
  SET @SucheOrt = ''%'' + REPLACE({edtSucheOrt}, '' '', ''%'') + ''%'';
END;

DECLARE @SucheFaFallID INT;
SET @SucheFaFallID = {edtSucheFaFallID};

DECLARE @SucheAltePNr VARCHAR(50);
SET @SucheAltePNr  = NULL;
IF ({edtSucheAltePNr} IS NOT NULL AND {edtSucheAltePNr} <> N'''')
BEGIN
  SET @SucheAltePNr  = ''%'' + REPLACE({edtSucheAltePNr}, '' '', ''%'') + ''%'';
END;


-- Zwischentabellen
DECLARE @tmpVSTSicherheitsleistung TABLE
(
  BaPersonID                        INT,
  BaSicherheitsleistungID           INT,
  BaMieteSicherheitsleistungArtCode INT,
  Jahr                              INT,
  BuchungsDatum                     DATETIME,
  BaInstitutionID                   INT,
  BaBankID                          INT,
  Bruttozins                        MONEY,
  VST                               MONEY,
  Nettozins                         MONEY,
  MigBelegnummer                    INT,
  KbBuchungBruttoID                 INT,
  Buchungstext                      VARCHAR(200)
);

--
-- Alle Sicherheitsleistungen bei welchen ''VSt einforderbar'' vorhanden ist (aus ''MigDetailBuchung'' union all ''KbBuchungBrutto'')
--
INSERT @tmpVSTSicherheitsleistung(BaPersonID, BaSicherheitsleistungID, BaMieteSicherheitsleistungArtCode, Jahr, BuchungsDatum, VST, BaInstitutionID, BaBankID, MigBelegnummer, KbBuchungBruttoID, Buchungstext)
  SELECT SIC.BaPersonID,
         SIC.BaSicherheitsleistungID,
         SIC.BaMieteSicherheitsleistungArtCode,
         Jahr = MIG.Zinsperiode,
         BuchungsDatum = MAX(MIG.BuchungsDatum),
         Betrag = SUM(MIG.Betrag),
         BaInstitutionID = MAX(SIC.BaInstitutionID),
         BaBankID = MAX(SIC.BaBankID),
         MIG.Belegnummer,
         NULL,
         NULL
  FROM dbo.BaSicherheitsleistung                 SIC WITH(READUNCOMMITTED) 
    INNER JOIN dbo.BaSicherheitsleistungPosition SIP WITH(READUNCOMMITTED) ON SIP.BaSicherheitsleistungID = SIC.BaSicherheitsleistungID
    INNER JOIN dbo.MigDetailBuchung              MIG WITH(READUNCOMMITTED) ON MIG.MigDetailBuchungID = SIP.MigDetailBuchungID
  WHERE MIG.KiSSLeistungsart IN (''034'') -- 034 = InvMDAS VSt einforderbar
    AND MIG.BuchungsDatum BETWEEN @DatumVon AND @DatumBis --Einschränkung auf BuchungsDatum
    AND (@SucheBaPersonID IS NULL OR @SucheBaPersonID = SIC.BaPersonID)
  --  AND MIG.Buchungsdatum <= @Stichtag
  GROUP BY SIC.BaPersonID, 
           SIC.BaSicherheitsleistungID, 
           SIC.BaMieteSicherheitsleistungArtCode,
           MIG.Zinsperiode, 
           MIG.Belegnummer, 
           MIG.BuchungsDatum
  HAVING SUM(MIG.Betrag) <> 0

  UNION ALL

  SELECT SIC.BaPersonID,
         SIC.BaSicherheitsleistungID,
         SIC.BaMieteSicherheitsleistungArtCode,
         Jahr = KBP.Zinsperiode, 
         ValutaDatum = MAX(KBB.ValutaDatum),
         Betrag = SUM(-KBP.Betrag),
         BaInstitutionID = MAX(SIC.BaInstitutionID),
         BaBankID = MAX(SIC.BaBankID),
         NULL,
         KBB.KbBuchungBruttoID,
         dbo.ConcDistinct(KBB.Text)
  FROM dbo.BaSicherheitsleistung                 SIC WITH(READUNCOMMITTED) 
    INNER JOIN dbo.BaSicherheitsleistungPosition SIP WITH(READUNCOMMITTED) ON SIP.BaSicherheitsleistungID = SIC.BaSicherheitsleistungID
    INNER JOIN dbo.KbBuchungBrutto               KBB WITH(READUNCOMMITTED) ON KBB.KbBuchungBruttoID = SIP.KbBuchungBruttoID 
                                                                          AND KBB.KbBuchungStatusCode <> 8
    INNER JOIN dbo.KbBuchungBruttoPerson         KBP WITH(READUNCOMMITTED) ON KBP.KbBuchungBruttoID = SIP.KbBuchungBruttoID
    INNER JOIN dbo.BgKostenart                   BKA WITH(READUNCOMMITTED) ON BKA.BgKostenartID = KBP.SpezBgKostenartID
  WHERE BKA.KontoNr IN (''034'') -- 034 = InvMDAS VSt einforderbar
    AND KBB.ValutaDatum BETWEEN @DatumVon AND @DatumBis --Einschränkung auf ValutaDatum
    AND (@SucheBaPersonID IS NULL OR @SucheBaPersonID = SIC.BaPersonID)
  --  AND KBB.ValutaDatum <= @Stichtag
  GROUP BY SIC.BaPersonID, SIC.BaSicherheitsleistungID, SIC.BaMieteSicherheitsleistungArtCode, KBP.Zinsperiode, KBB.KbBuchungBruttoID, KBB.ValutaDatum
  HAVING SUM(KBP.Betrag) <> 0;

--
-- Bruttozinsen holen aus den Migrierten und neuen Daten
--
DECLARE @tmpVSTBruttozins TABLE
(
  KbBuchungBruttoID                 INT,
  BaPersonID                        INT,
  BaSicherheitsleistungID           INT,
  BaMieteSicherheitsleistungArtCode INT,
  Jahr                              INT,
  Bruttozins                        MONEY
);

INSERT @tmpVSTBruttozins(KbBuchungBruttoID, BaPersonID, BaSicherheitsleistungID, BaMieteSicherheitsleistungArtCode, Jahr, Bruttozins)
  SELECT VST.KbBuchungBruttoID, VST.BaPersonID, VST.BaSicherheitsleistungID, VST.BaMieteSicherheitsleistungArtCode, VST.Jahr, SUM(-MIG.Betrag)
  FROM @tmpVSTSicherheitsleistung   VST
    INNER JOIN dbo.MigDetailBuchung MIG WITH(READUNCOMMITTED) ON MIG.BelegNummer IS NOT NULL 
                                                             AND MIG.BelegNummer = VST.MigBelegnummer
  WHERE MIG.KiSSLeistungsart in (''041'') -- 041 = InvMDAS Zinsverbuchung
    AND MIG.BaPersonID = VST.BaPersonID
    AND MIG.BuchungsDatum BETWEEN @DatumVon AND @DatumBis
  GROUP BY VST.KbBuchungBruttoID, VST.BaPersonID, VST.BaSicherheitsleistungID, VST.BaMieteSicherheitsleistungArtCode, VST.Jahr

  UNION ALL -- Bruttozinsen holen aus den Neuen

  SELECT VST.KbBuchungBruttoID, VST.BaPersonID, VST.BaSicherheitsleistungID, VST.BaMieteSicherheitsleistungArtCode, VST.Jahr, SUM(KBP.Betrag)
  FROM @tmpVSTSicherheitsleistung        VST
    INNER JOIN dbo.KbBuchungBruttoPerson KBP WITH(READUNCOMMITTED) ON VST.KbBuchungBruttoID IS NOT NULL 
                                                                  AND KBP.KbBuchungBruttoID = VST.KbBuchungBruttoID
                                                                  AND KBP.Zinsperiode = VST.Jahr
    INNER JOIN dbo.KbBuchungBrutto       KBB WITH(READUNCOMMITTED) ON VST.KbBuchungBruttoID IS NOT NULL 
                                                                  AND KBB.KbBuchungBruttoID = VST.KbBuchungBruttoID 
                                                                  AND KBB.KbBuchungStatusCode <> 8
    INNER JOIN dbo.BaSicherheitsleistung SIC WITH(READUNCOMMITTED) ON SIC.BaSicherheitsleistungID = VST.BaSicherheitsleistungID
    INNER JOIN dbo.BgKostenart           BKA WITH(READUNCOMMITTED) ON BKA.BgKostenartID = KBP.SpezBgKostenartID
  WHERE BKA.KontoNr  in (''041'') -- 041 = InvMDAS Zinsverbuchung
    AND SIC.BaPersonID = VST.BaPersonID
    AND KBB.ValutaDatum BETWEEN @DatumVon AND @DatumBis
  GROUP BY VST.KbBuchungBruttoID, VST.BaPersonID, VST.BaSicherheitsleistungID, VST.BaMieteSicherheitsleistungArtCode, VST.Jahr;
  
--select * from @tmpVSTBruttozins 

--
-- VST Tabelle Updaten mit Brutto- und Nettozins, sowie BaBankID bzw. BaInstitutionID
--
UPDATE VST
SET VST.Bruttozins      = VSTB.Bruttozins,
    VST.Nettozins       = VSTB.Bruttozins - VST.VST,
    VST.BaBankID        = SIL.BaBankID,
    VST.BaInstitutionID = SIL.BaInstitutionID
FROM @tmpVSTSicherheitsleistung        VST
  INNER JOIN @tmpVSTBruttozins         VSTB                       ON VSTB.KbBuchungBruttoID = VST.KbBuchungBruttoID
  INNER JOIN dbo.BaSicherheitsleistung SIL  WITH(READUNCOMMITTED) ON SIL.BaSicherheitsleistungID = VST.BaSicherheitsleistungID 
                                                                 AND VSTB.BaSicherheitsleistungID = VST.BaSicherheitsleistungID 
                                                                 AND VSTB.BaPersonID = VST.BaPersonID 
                                                                 AND VSTB.BaMieteSicherheitsleistungArtCode = VST.BaMieteSicherheitsleistungArtCode 
                                                                 AND VSTB.Jahr = VST.Jahr
--select * from @tmpVSTSicherheitsleistung order by 3


--
-- Anzeige im Report
--
SELECT Art = ISNULL(@SucheArt, -1),
       Stichtag = ISNULL(CONVERT(VARCHAR, @Stichtag, 104), ''''), 
       ART.ShortText,
       PRS.BaPersonID, 
       NameVorname = CASE WHEN PRS.BaPersonID IN (168563,168564) --Bei Dummy-Personen den Buchungstext als Namen verwenden, dort steht der eigentliche Name. Sonst muss die Liste manuell ergänzt werden
                       THEN VST.Buchungstext 
                       ELSE PRS.NameVorname 
                     END, 
       [Name] = ISNULL(INS.InstitutionName, BNK.Name),
       SIC.KontoNummer, 
       VST.BuchungsDatum, 
       VST.Jahr, 
       VST.Bruttozins, 
       VST.VST, 
       VST.Nettozins
FROM @tmpVSTSicherheitsleistung        VST
  INNER JOIN dbo.BaSicherheitsleistung SIC WITH(READUNCOMMITTED) ON SIC.BaSicherheitsleistungID = VST.BaSicherheitsleistungID
  LEFT  JOIN dbo.FaLeistung            LEI WITH(READUNCOMMITTED) ON LEI.BaPersonID = SIC.BaPersonID 
                                                                AND LEI.FaProzessCode = 300 
                                                                AND LEI.FaLeistungID = (SELECT TOP 1 FaLeistungID
                                                                                        FROM dbo.FaLeistung
                                                                                        WHERE BaPersonID = SIC.BaPersonID 
                                                                                          AND FaProzessCode = 300
                                                                                        ORDER BY DatumVon DESC)
  INNER JOIN dbo.vwPerson              PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = SIC.BaPersonID
  LEFT  JOIN dbo.vwInstitution         INS WITH(READUNCOMMITTED) ON INS.BaInstitutionID = SIC.BaInstitutionID
  LEFT  JOIN dbo.BaBank                BNK WITH(READUNCOMMITTED) ON BNK.BaBankID = SIC.BaBankID
  LEFT  JOIN dbo.XLOVCode              ART WITH(READUNCOMMITTED) ON ART.LOVName = ''BaMieteSicherheitsleistungArt'' 
                                                                AND ART.Code = SIC.BaMieteSicherheitsleistungArtCode
WHERE 1 = 1 
  AND (@SucheArt IS NULL           OR SIC.BaMieteSicherheitsleistungArtCode = @SucheArt)
  AND (@SucheBaPersonID IS NULL    OR SIC.BaPersonID = @SucheBaPersonID)
  AND (@SucheKlient IS NULL        OR PRS.NameVorname LIKE @SucheKlient)
  AND (@SucheAuszahlungVon IS NULL OR SIC.AuszahlungAm >= @SucheAuszahlungVon)
  AND (@SucheAuszahlungBis IS NULL OR SIC.AuszahlungAm <= @SucheAuszahlungBis)
  AND ((@SucheMigriert = 1 AND SIC.MigDarlehenID IS NOT NULL) OR
       (@SucheLaufend = 1  AND SIC.MigDarlehenID IS NULL AND SIC.neu = 0) OR
       (@SucheNeu = 1      AND SIC.neu = 1))
  AND (@SucheInstitution IS NULL   OR INS.InstitutionName LIKE @SucheInstitution)
  AND (@SucheKontoNr IS NULL       OR SIC.KontoNummer LIKE @SucheKontoNr)
  AND (@SucheStrasse IS NULL       OR SIC.ObjektStrasse LIKE @SucheStrasse)
  AND (@SucheHausNr IS NULL        OR SIC.ObjektHausNr = @SucheHausNr)
  AND (@SuchePLZ IS NULL           OR SIC.ObjektPLZ = @SuchePLZ)
  AND (@SucheOrt IS NULL           OR SIC.ObjektOrt LIKE @SucheOrt)
  AND (@SucheAltePNr IS NULL       OR SIC.BaPersonID IN (SELECT DISTINCT BaPersonID FROM BaAlteFallNr WHERE PersonNrAlt = @SucheAltePNr))
  AND (@SucheFaFallID IS NULL      OR LEI.FaFallID = @SucheFaFallID)
ORDER BY ART.ShortText, PRS.Name, VST.Jahr;' , ContextForms =  N'FrmBaSicherheitsleistung' , ParentReportName =  null , ReportSortKey = 1
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'BaVstRueckforderung' ;


