-- Insert Script for AyMasterbudgetVerfuegung
-- MD5:0XF77A154D1FF8E60B3F4786761F5DCD8C_0X2279E9AE4E2CB196C6DE373E696E8275_0X14D8947DD33C80317752C3989918CE63
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'AyMasterbudgetVerfuegung') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('AyMasterbudgetVerfuegung', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'AyMasterbudgetVerfuegung';
UPDATE QRY
SET QueryName =  N'AyMasterbudgetVerfuegung' , UserText =  N'AY - Masterbudget' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>C:\Programme\Born Informatik AG\KiSS4\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>de-DE</Localization>
///   <References>
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Drawing\2.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System\2.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Configuration\2.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Xml\2.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Data.SqlXml\2.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Security\2.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.Utils.v6.2.dll" />
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
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.Data.v6.2.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\KiSS4.DB.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\SharpLibrary.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRRichTextBox rtfEmpfang;
        private DevExpress.XtraReports.UI.XRLabel txtBemerkung;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.Subreport AyMasterbudgetVerfuegung_EinAus;
        private DevExpress.XtraReports.UI.Subreport AyMasterbudgetVerfuegung_Personen;
        private DevExpress.XtraReports.UI.XRRichTextBox xrRichTextBox1;
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
        private DevExpress.XtraReports.UI.XRRichTextBox rtfHinweis;
        private DevExpress.XtraReports.UI.XRControl shpAdr;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAADAAAAAQAAAIwBRGV2RXhwcmVzc" +
                        "y5YdHJhUmVwb3J0cy5VSS5TZXJpYWxpemFibGVTdHJpbmcsIERldkV4cHJlc3MuWHRyYVJlcG9ydHMud" +
                        "jYuMiwgVmVyc2lvbj02LjIuNi4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPTc5ODY4Y" +
                        "jgxNDdiNWVhZTRQE7ROpJW/u7pR/n8CKQAAAGAAAAAAAAAA5QEAACRyAHQAZgBIAGkAbgB3AGUAaQBzA" +
                        "C4AUgB0AGYAVABlAHgAdAAAAAAAMnMAcQBsAFEAdQBlAHIAeQAxAC4AUwBlAGwAZQBjAHQAUwB0AGEAd" +
                        "ABlAG0AZQBuAHQAuAMAACx4AHIAUgBpAGMAaABUAGUAeAB0AEIAbwB4ADEALgBSAHQAZgBUAGUAeAB0A" +
                        "MYLAABAAAEAAAD/////AQAAAAAAAAAMAgAAABtEZXZFeHByZXNzLlh0cmFSZXBvcnRzLnY2LjIFAQAAA" +
                        "CxEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlNlcmlhbGl6YWJsZVN0cmluZwEAAAAFVmFsdWUBAgAAA" +
                        "AYDAAAAvAZ7XHJ0ZjFcYW5zaVxhbnNpY3BnMTI1MlxkZWZmMFxkZWZsYW5nMTAzM3tcZm9udHRibHtcZ" +
                        "jBcZm5pbFxmY2hhcnNldDAgQXJpYWw7fX0NClx2aWV3a2luZDRcdWMxXHBhcmRcbGFuZzEwMjRcZnMxO" +
                        "CBEYXMgQnVkZ2V0IGlzdCBnZW1cJ2U0c3MgIldlaXN1bmcgZGVyIEJTUyB6dXIgVW50ZXJzdFwnZmN0e" +
                        "nVuZyB2b24gQXN5bHN1Y2hlbmRlbiwgdm9ybFwnZTR1ZmlnIEF1Zmdlbm9tbWVuZW4gdW5kIFNjaHV0e" +
                        "mJlZFwnZmNyZnRpZ2VuIG9obmUgQXVmZW50aGFsdHNiZXdpbGxpZ3VuZyBtaXQgV29obnNpdHogaW4gZ" +
                        "GVyIFN0YWR0IEJlcm4iLCBnXCdmY2x0aWcgYWIgMS4xMS4yMDA2IGJlcmVjaG5ldC4gRXMgZ2lsdCBhb" +
                        "HMgUmFobWVuYnVkZ2V0LiBFaW5uYWhtZW4gdW5kIEF1c2dhYmVuIGtcJ2Y2bm5lbiBtb25hdGxpY2ggX" +
                        "CdlNG5kZXJuLiBEaWUgQmV6XCdmY2dlcmlubmVuIHVuZCBCZXpcJ2ZjZ2VyIHNpbmQgdmVycGZsaWNod" +
                        "GV0LCBcJ2M0bmRlcnVuZ2VuIGRlciBmaW5hbnppZWxsZW4gdW5kIHBlcnNcJ2Y2bmxpY2hlbiBTaXR1Y" +
                        "XRpb24gdW1nZWhlbmQgZGVtIEtvbXBldGVuenplbnRydW0gSW50ZWdyYXRpb24genUgbWVsZGVuLiBFa" +
                        "W5lIFZlcmhlaW1saWNodW5nIG9kZXIgZGllIEFuZ2FiZSBmYWxzY2hlciBUYXRzYWNoZW4ga2FubiBla" +
                        "W5lIHNvZm9ydGlnZSBSXCdmY2NremFobHVuZ3NwZmxpY2h0IGF1c2xcJ2Y2c2VuIHVuZCBzdHJhZnJlY" +
                        "2h0bGljaGUgRm9sZ2VuIG5hY2ggc2ljaCB6aWVoZW4uIFdlaXRlcmVyIEJlc3RhbmR0ZWlsIGRpZXNlc" +
                        "yBIaW53ZWlzZXMgYmlsZGV0IGRpZSAiVmVyZWluYmFydW5nIi5cbGFuZzEwMzNccGFyDQp9DQoLAYsQR" +
                        "EVDTEFSRSBAVG90SW4gbW9uZXksIEBUb3RPdXQgbW9uZXkNCg0KU0VUIEBUb3RJbiAgPSAoU0VMRUNUI" +
                        "FNVTShCZXRyYWdGaW5hbnpwbGFuKQ0KICAgICAgICAgICAgICAgRlJPTSAgIHZ3QmdQb3NpdGlvbiAgQ" +
                        "lBPDQogICAgICAgICAgICAgICBXSEVSRSAgQlBPLkJnQnVkZ2V0SUQgPSBudWxsIEFORA0KICAgICAgI" +
                        "CAgICAgICAgICAgICAgIEJnS2F0ZWdvcmllQ29kZSA9IDEgQU5EDQogICAgICAgICAgICAgICAgICAgI" +
                        "CAgR2V0RGF0ZSgpIEJFVFdFRU4gSXNOdWxsKEJQTy5EYXR1bVZvbiwgJzE5MDAwMTAxJykgQU5EIElzT" +
                        "nVsbChCUE8uRGF0dW1CaXMsIEdldERhdGUoKSkpDQoNClNFVCBAVG90T3V0ID0gKFNFTEVDVCBTVU0oQ" +
                        "mV0cmFnRmluYW56cGxhbikNCiAgICAgICAgICAgICAgIEZST00gICB2d0JnUG9zaXRpb24gIEJQTw0KI" +
                        "CAgICAgICAgICAgICAgV0hFUkUgIEJQTy5CZ0J1ZGdldElEID0gbnVsbCBBTkQNCiAgICAgICAgICAgI" +
                        "CAgICAgICAgICBCZ0thdGVnb3JpZUNvZGUgPSAyIEFORA0KICAgICAgICAgICAgICAgICAgICAgIEdld" +
                        "ERhdGUoKSBCRVRXRUVOIElzTnVsbChCUE8uRGF0dW1Wb24sICcxOTAwMDEwMScpIEFORCBJc051bGwoQ" +
                        "lBPLkRhdHVtQmlzLCBHZXREYXRlKCkpKQ0KDQpTRUxFQ1QgQmdCdWRnZXRJRCAgID0gQkJHLkJnQnVkZ" +
                        "2V0SUQsDQogICAgICAgVGl0bGUgICAgICAgID0gJ01hc3RlcmJ1ZGdldCAvIEZpbmFuemllbGxlIFVud" +
                        "GVyc3TDvHR6dW5nICcgKw0KICAgICAgICAgICAgICAgICAgICAgIENBU0UgU0ZQLkJnQmV3aWxsaWd1b" +
                        "mdTdGF0dXNDb2RlDQogICAgICAgICAgICAgICAgICAgICAgICBXSEVOIDEgVEhFTiAnKGdlcGxhbnQpI" +
                        "GFiICcgKyBJc051bGwoQ09OVkVSVCh2YXJjaGFyLCBTRlAuR2VwbGFudFZvbiwgMTA0KSwgJz8/PycpD" +
                        "QogICAgICAgICAgICAgICAgICAgICAgICBXSEVOIDMgVEhFTiAnKG5vY2ggbmljaHQgYmV3aWxsaWd0K" +
                        "SBhYiAnICsgSXNOdWxsKENPTlZFUlQodmFyY2hhciwgU0ZQLkdlcGxhbnRWb24sIDEwNCksICc/Pz8nK" +
                        "Q0KICAgICAgICAgICAgICAgICAgICAgICAgV0hFTiA1IFRIRU4gJyhiZXdpbGxpZ3QpIGFiICcgKyBJc" +
                        "051bGwoQ09OVkVSVCh2YXJjaGFyLCBTRlAuRGF0dW1Wb24sIDEwNCksICc/Pz8nKQ0KICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgV0hFTiA5IFRIRU4gJyhhYmdlbGF1ZmVuKSBhYiAnICsgSXNOdWxsKENPTlZFU" +
                        "lQodmFyY2hhciwgU0ZQLkRhdHVtVm9uLCAxMDQpLCAnPz8/JykNCiAgICAgICAgICAgICAgICAgICAgI" +
                        "CBFTkQsDQogICAgICAgQWRyZXNzZSAgICAgID0gSXNOdWxsKENBU0UgUFJTLkdlc2NobGVjaHRDb2RlI" +
                        "FdIRU4gMSBUSEVOICdIZXJyJyBXSEVOIDIgVEhFTiAnRnJhdScgRU5EICsgY2hhcigxMykgKyBjaGFyK" +
                        "DEwKSwnJykgKw0KICAgICAgICAgICAgICAgICAgICAgIFBSUy5OYW1lVm9ybmFtZSArIGNoYXIoMTMpI" +
                        "CsgY2hhcigxMCkgKw0KICAgICAgICAgICAgICAgICAgICAgIElzTnVsbChQUlMuV29obnNpdHpTdHJhc" +
                        "3NlSGF1c05yLCAnJykgKyBjaGFyKDEzKSArIGNoYXIoMTApICsNCiAgICAgICAgICAgICAgICAgICAgI" +
                        "CBXb2huc2l0elBMWk9ydCwNCiAgICAgICBCZW1lcmt1bmcgPSBTRlAuQmVtZXJrdW5nLA0KICAgICAgI" +
                        "FRvdEluICAgICAgICA9IElzTnVsbChAVG90SW4sICQwLjAwKSwNCiAgICAgICBUb3RPdXQgICAgICAgP" +
                        "SBJc051bGwoQFRvdE91dCwgJDAuMDApLA0KICAgICAgIEZlaGxiZXRyYWcgICA9IElzTnVsbChAVG90T" +
                        "3V0LCAkMC4wMCkgLSBJc051bGwoQFRvdEluLCAkMC4wMCkNCkZST00gQmdCdWRnZXQgQkJHDQogIElOT" +
                        "kVSIEpPSU4gQmdGaW5hbnpwbGFuICBTRlAgb24gU0ZQLkJnRmluYW56cGxhbklEID0gQkJHLkJnRmluY" +
                        "W56cGxhbklEDQogIElOTkVSIEpPSU4gRmFMZWlzdHVuZyAgICBGTEUgb24gRkxFLkZhTGVpc3R1bmdJR" +
                        "CA9IFNGUC5GYUxlaXN0dW5nSUQNCiAgSU5ORVIgSk9JTiB2d1BlcnNvbiAgICAgIFBSUyBvbiBQUlMuQ" +
                        "mFQZXJzb25JRCA9IEZMRS5CYVBlcnNvbklEDQpXSEVSRSBCQkcuQmdCdWRnZXRJRCA9IG51bGwNCiAgQ" +
                        "U5EIEZMRS5Nb2R1bElEID0gNkAAAQAAAP////8BAAAAAAAAAAwCAAAAG0RldkV4cHJlc3MuWHRyYVJlc" +
                        "G9ydHMudjYuMgUBAAAALERldkV4cHJlc3MuWHRyYVJlcG9ydHMuVUkuU2VyaWFsaXphYmxlU3RyaW5nA" +
                        "QAAAAVWYWx1ZQECAAAABgMAAADXAXtccnRmMVxhbnNpXGFuc2ljcGcxMjUyXGRlZmYwe1xmb250dGJse" +
                        "1xmMFxmbmlsXGZjaGFyc2V0MCBNaWNyb3NvZnQgU2FucyBTZXJpZjt9fQ0KXHZpZXdraW5kNFx1YzFcc" +
                        "GFyZFxsYW5nMjA1NVxmMFxmczE3IEtvbXBldGVuenplbnRydW0gSW50ZWdyYXRpb25ccGFyDQpFZmZpb" +
                        "mdlcnN0cmFzc2UgMjFccGFyDQpQb3N0ZmFjaCA4MTI1XHBhcg0KMzAwMSBCZXJuXHBhcg0KfQ0KCw==";
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
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.rtfEmpfang = new DevExpress.XtraReports.UI.XRRichTextBox();
            this.txtBemerkung = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.AyMasterbudgetVerfuegung_EinAus = new DevExpress.XtraReports.UI.Subreport();
            this.AyMasterbudgetVerfuegung_Personen = new DevExpress.XtraReports.UI.Subreport();
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
            this.shpAdr = new DevExpress.XtraReports.UI.XRControl();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageInfo1,
                        this.rtfEmpfang,
                        this.txtBemerkung,
                        this.xrLine1,
                        this.AyMasterbudgetVerfuegung_EinAus,
                        this.AyMasterbudgetVerfuegung_Personen,
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
                        this.rtfHinweis,
                        this.shpAdr});
            this.Detail.Dpi = 254F;
            this.Detail.Height = 1947;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBackColor = false;
            this.Detail.ParentStyleUsing.UseBorderColor = false;
            this.Detail.ParentStyleUsing.UseBorders = false;
            this.Detail.ParentStyleUsing.UseBorderWidth = false;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.ParentStyleUsing.UseForeColor = false;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 254F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 10F);
            this.xrPageInfo1.Format = "Bern, {0:d}";
            this.xrPageInfo1.Location = new System.Drawing.Point(37, 1736);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(572, 42);
            // 
            // rtfEmpfang
            // 
            this.rtfEmpfang.Dpi = 254F;
            this.rtfEmpfang.ForeColor = System.Drawing.Color.Black;
            this.rtfEmpfang.Location = new System.Drawing.Point(402, 1450);
            this.rtfEmpfang.Name = "rtfEmpfang";
            this.rtfEmpfang.ParentStyleUsing.UseBackColor = false;
            this.rtfEmpfang.ParentStyleUsing.UseBorderColor = false;
            this.rtfEmpfang.ParentStyleUsing.UseBorders = false;
            this.rtfEmpfang.ParentStyleUsing.UseBorderWidth = false;
            this.rtfEmpfang.ParentStyleUsing.UseFont = false;
            this.rtfEmpfang.ParentStyleUsing.UseForeColor = false;
            this.rtfEmpfang.Size = new System.Drawing.Size(1458, 148);
            // 
            // txtBemerkung
            // 
            this.txtBemerkung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bemerkung", "")});
            this.txtBemerkung.Dpi = 254F;
            this.txtBemerkung.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtBemerkung.Location = new System.Drawing.Point(394, 1323);
            this.txtBemerkung.Name = "txtBemerkung";
            this.txtBemerkung.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtBemerkung.ParentStyleUsing.UseFont = false;
            this.txtBemerkung.Size = new System.Drawing.Size(1458, 85);
            this.txtBemerkung.Text = "txtBemerkung";
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
            // AyMasterbudgetVerfuegung_EinAus
            // 
            this.AyMasterbudgetVerfuegung_EinAus.Dpi = 254F;
            this.AyMasterbudgetVerfuegung_EinAus.Location = new System.Drawing.Point(0, 660);
            this.AyMasterbudgetVerfuegung_EinAus.Name = "AyMasterbudgetVerfuegung_EinAus";
            // 
            // AyMasterbudgetVerfuegung_Personen
            // 
            this.AyMasterbudgetVerfuegung_Personen.Dpi = 254F;
            this.AyMasterbudgetVerfuegung_Personen.Location = new System.Drawing.Point(0, 429);
            this.AyMasterbudgetVerfuegung_Personen.Name = "AyMasterbudgetVerfuegung_Personen";
            // 
            // xrRichTextBox1
            // 
            this.xrRichTextBox1.CanShrink = true;
            this.xrRichTextBox1.Dpi = 254F;
            this.xrRichTextBox1.ForeColor = System.Drawing.Color.Black;
            this.xrRichTextBox1.Location = new System.Drawing.Point(0, 20);
            this.xrRichTextBox1.Name = "xrRichTextBox1";
            this.xrRichTextBox1.ParentStyleUsing.UseBackColor = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorderColor = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorders = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorderWidth = false;
            this.xrRichTextBox1.ParentStyleUsing.UseFont = false;
            this.xrRichTextBox1.ParentStyleUsing.UseForeColor = false;
            this.xrRichTextBox1.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichTextBox1.RtfText")));
            this.xrRichTextBox1.Size = new System.Drawing.Size(401, 191);
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
            this.txtAnrede.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Adresse", "")});
            this.txtAnrede.Dpi = 254F;
            this.txtAnrede.Font = new System.Drawing.Font("Arial", 10F);
            this.txtAnrede.ForeColor = System.Drawing.Color.Black;
            this.txtAnrede.Location = new System.Drawing.Point(1290, 89);
            this.txtAnrede.Multiline = true;
            this.txtAnrede.Name = "txtAnrede";
            this.txtAnrede.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtAnrede.ParentStyleUsing.UseBackColor = false;
            this.txtAnrede.ParentStyleUsing.UseBorderColor = false;
            this.txtAnrede.ParentStyleUsing.UseBorders = false;
            this.txtAnrede.ParentStyleUsing.UseBorderWidth = false;
            this.txtAnrede.ParentStyleUsing.UseFont = false;
            this.txtAnrede.ParentStyleUsing.UseForeColor = false;
            this.txtAnrede.Size = new System.Drawing.Size(539, 190);
            this.txtAnrede.Text = "Anrede";
            // 
            // Line8
            // 
            this.Line8.Dpi = 254F;
            this.Line8.ForeColor = System.Drawing.Color.Black;
            this.Line8.LineWidth = 3;
            this.Line8.Location = new System.Drawing.Point(3, 1427);
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
            this.Line7.Location = new System.Drawing.Point(3, 1300);
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
            this.Line6.Location = new System.Drawing.Point(3, 960);
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
            this.Line4.Location = new System.Drawing.Point(799, 1905);
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
            this.Label9.Location = new System.Drawing.Point(799, 1905);
            this.Label9.Name = "Label9";
            this.Label9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label9.ParentStyleUsing.UseBackColor = false;
            this.Label9.ParentStyleUsing.UseBorderColor = false;
            this.Label9.ParentStyleUsing.UseBorders = false;
            this.Label9.ParentStyleUsing.UseBorderWidth = false;
            this.Label9.ParentStyleUsing.UseFont = false;
            this.Label9.ParentStyleUsing.UseForeColor = false;
            this.Label9.Size = new System.Drawing.Size(620, 38);
            this.Label9.Text = "Unterschrift Empfänger / Empfängerin";
            // 
            // Line3
            // 
            this.Line3.Dpi = 254F;
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.Line3.LineWidth = 3;
            this.Line3.Location = new System.Drawing.Point(799, 1778);
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
            this.Label8.Location = new System.Drawing.Point(799, 1778);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(620, 38);
            this.Label8.Text = "Für das Kompetenzzentrum Integration";
            // 
            // Line2
            // 
            this.Line2.Dpi = 254F;
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.Line2.LineWidth = 3;
            this.Line2.Location = new System.Drawing.Point(37, 1905);
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
            this.Label7.Location = new System.Drawing.Point(37, 1905);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(620, 38);
            this.Label7.Text = "Ort und Datum Empfang";
            // 
            // Line1
            // 
            this.Line1.Dpi = 254F;
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.Line1.LineWidth = 3;
            this.Line1.Location = new System.Drawing.Point(37, 1778);
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
            this.Label6.Location = new System.Drawing.Point(37, 1778);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(620, 38);
            this.Label6.Text = "Ort und Datum Ausstellung";
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.Color.Silver;
            this.Label5.Dpi = 254F;
            this.Label5.Font = new System.Drawing.Font("Arial", 10F);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(3, 1450);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(373, 38);
            this.Label5.Text = "Erklärung";
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Silver;
            this.Label4.Dpi = 254F;
            this.Label4.Font = new System.Drawing.Font("Arial", 10F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(3, 1323);
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
            this.Label3.Location = new System.Drawing.Point(3, 986);
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
            this.txtTitle.Location = new System.Drawing.Point(0, 318);
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
            this.rtfHinweis.Location = new System.Drawing.Point(394, 986);
            this.rtfHinweis.Name = "rtfHinweis";
            this.rtfHinweis.ParentStyleUsing.UseBackColor = false;
            this.rtfHinweis.ParentStyleUsing.UseBorderColor = false;
            this.rtfHinweis.ParentStyleUsing.UseBorders = false;
            this.rtfHinweis.ParentStyleUsing.UseBorderWidth = false;
            this.rtfHinweis.ParentStyleUsing.UseFont = false;
            this.rtfHinweis.ParentStyleUsing.UseForeColor = false;
            this.rtfHinweis.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("rtfHinweis.RtfText")));
            this.rtfHinweis.Size = new System.Drawing.Size(1458, 312);
            // 
            // shpAdr
            // 
            this.shpAdr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.shpAdr.BorderColor = System.Drawing.Color.Black;
            this.shpAdr.Dpi = 254F;
            this.shpAdr.Location = new System.Drawing.Point(1278, 79);
            this.shpAdr.Name = "shpAdr";
            this.shpAdr.ParentStyleUsing.UseBackColor = false;
            this.shpAdr.ParentStyleUsing.UseBorderColor = false;
            this.shpAdr.ParentStyleUsing.UseBorders = false;
            this.shpAdr.ParentStyleUsing.UseBorderWidth = false;
            this.shpAdr.ParentStyleUsing.UseFont = false;
            this.shpAdr.ParentStyleUsing.UseForeColor = false;
            this.shpAdr.Size = new System.Drawing.Size(571, 211);
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
            this.Margins = new System.Drawing.Printing.Margins(140, 95, 203, 102);
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
		<DisplayText>Masterbudget ID:</DisplayText>
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
		<DisplayText>Masterbudget ID</DisplayText>
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
</NewDataSet>' , SQLquery =  N'DECLARE @TotIn money, @TotOut money

SET @TotIn  = (SELECT SUM(BetragFinanzplan)
               FROM   vwBgPosition  BPO
               WHERE  BPO.BgBudgetID = {BgBudgetID} AND
                      BgKategorieCode = 1 AND
                      GetDate() BETWEEN IsNull(BPO.DatumVon, ''19000101'') AND IsNull(BPO.DatumBis, GetDate()))

SET @TotOut = (SELECT SUM(BetragFinanzplan)
               FROM   vwBgPosition  BPO
               WHERE  BPO.BgBudgetID = {BgBudgetID} AND
                      BgKategorieCode = 2 AND
                      GetDate() BETWEEN IsNull(BPO.DatumVon, ''19000101'') AND IsNull(BPO.DatumBis, GetDate()))

SELECT BgBudgetID   = BBG.BgBudgetID,
       Title        = ''Masterbudget / Finanzielle Unterstützung '' +
                      CASE SFP.BgBewilligungStatusCode
                        WHEN 1 THEN ''(geplant) ab '' + IsNull(CONVERT(varchar, SFP.GeplantVon, 104), ''???'')
                        WHEN 3 THEN ''(noch nicht bewilligt) ab '' + IsNull(CONVERT(varchar, SFP.GeplantVon, 104), ''???'')
                        WHEN 5 THEN ''(bewilligt) ab '' + IsNull(CONVERT(varchar, SFP.DatumVon, 104), ''???'')
                        WHEN 9 THEN ''(abgelaufen) ab '' + IsNull(CONVERT(varchar, SFP.DatumVon, 104), ''???'')
                      END,
       Adresse      = IsNull(CASE PRS.GeschlechtCode WHEN 1 THEN ''Herr'' WHEN 2 THEN ''Frau'' END + char(13) + char(10),'''') +
                      PRS.NameVorname + char(13) + char(10) +
                      IsNull(PRS.WohnsitzStrasseHausNr, '''') + char(13) + char(10) +
                      WohnsitzPLZOrt,
       Bemerkung = SFP.Bemerkung,
       TotIn        = IsNull(@TotIn, $0.00),
       TotOut       = IsNull(@TotOut, $0.00),
       Fehlbetrag   = IsNull(@TotOut, $0.00) - IsNull(@TotIn, $0.00)
FROM BgBudget BBG
  INNER JOIN BgFinanzplan  SFP on SFP.BgFinanzplanID = BBG.BgFinanzplanID
  INNER JOIN FaLeistung    FLE on FLE.FaLeistungID = SFP.FaLeistungID
  INNER JOIN vwPerson      PRS on PRS.BaPersonID = FLE.BaPersonID
WHERE BBG.BgBudgetID = {BgBudgetID}
  AND FLE.ModulID = 6' , ContextForms =  N'AyMasterbudget' , ParentReportName =  null , ReportSortKey = 2
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'AyMasterbudgetVerfuegung' ;


INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'AyMasterbudgetVerfuegung_EinAus' ,  N'Einnahmen, Ausgaben' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS40\KiSS4.NET\KiSS4.Main\bin\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4.NET\KiSS4.Main\bin\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
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
                        "AAAAeUKLS0gUGFyYW1ldGVyDQpERUNMQVJFIEBCZ0J1ZGdldElEICBpbnQsDQogICAgICAgIEBSZWZEY" +
                        "XRlICAgICBkYXRldGltZQ0KU0VMRUNUIEBCZ0J1ZGdldElEID0gQmdCdWRnZXRJRCwNCiAgICAgICBAU" +
                        "mVmRGF0ZSA9IGNvbnZlcnQgKGRhdGV0aW1lLCBkYm8uZm5NSU4oZGJvLmZuTUFYKElzTnVsbChTRlAuR" +
                        "GF0dW1Wb24sIFNGUC5HZXBsYW50Vm9uKSwgR2V0RGF0ZSgpKSwNCiAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgSXNOdWxsKElzTnVsbChTRlAuRGF0dW1CaXMsIFNGU" +
                        "C5HZXBsYW50QmlzKSwgR2V0RGF0ZSgpKSkpDQpGUk9NIEJnQnVkZ2V0ICAgICAgICAgICAgICBCQkcNC" +
                        "iAgSU5ORVIgSk9JTiBCZ0ZpbmFuenBsYW4gIFNGUCBPTiBTRlAuQmdGaW5hbnpwbGFuSUQgPSBCQkcuQ" +
                        "mdGaW5hbnpwbGFuSUQNCldIRVJFIEJCRy5CZ0J1ZGdldElEID0gbnVsbCBBTkQgQkJHLk1hc3RlckJ1Z" +
                        "GdldCA9IDENCg0KREVDTEFSRSBARWlubmFobWVuIFRBQkxFIChpZCBpbnQgaWRlbnRpdHksIFRleHQgd" +
                        "mFyY2hhcigxMDApLCBCZXRyYWcgbW9uZXkpDQpERUNMQVJFIEBBdXNnYWJlbiAgVEFCTEUgKGlkIGlud" +
                        "CBpZGVudGl0eSwgVGV4dCB2YXJjaGFyKDEwMCksIEJldHJhZyBtb25leSkNCg0KDQoNCklOU0VSVCBJT" +
                        "lRPIEBFaW5uYWhtZW4gKFRleHQsQmV0cmFnKQ0KICBTRUxFQ1QgQmV6ZWljaG51bmcsIEJldHJhZw0KI" +
                        "CBGUk9NIGRiby5mbkF5R2V0QnVkZ2V0KEBCZ0J1ZGdldElELCBAUmVmRGF0ZSkNCiAgV0hFUkUgQmdLY" +
                        "XRlZ29yaWVDb2RlID0gMSBBTkQgU3R5bGUgPiAxDQogICAgQU5EIFRvdGFsIElTIE5VTEwNCg0KSU5TR" +
                        "VJUIElOVE8gQEF1c2dhYmVuIChUZXh0LEJldHJhZykNCiAgU0VMRUNUIEJlemVpY2hudW5nLCBCZXRyY" +
                        "WcNCiAgRlJPTSBkYm8uZm5BeUdldEJ1ZGdldChAQmdCdWRnZXRJRCwgQFJlZkRhdGUpDQogIFdIRVJFI" +
                        "EJnS2F0ZWdvcmllQ29kZSA+IDEgQU5EIChCZ0thdGVnb3JpZUNvZGUgPiAyIE9SIFN0eWxlID4gMSkNC" +
                        "iAgICBBTkQgVG90YWwgSVMgTlVMTA0KDQpERUxFVEUgRlJPTSBARWlubmFobWVuIFdIRVJFIFRleHQgP" +
                        "SAnJyBBTkQgaWQgPSAoU0VMRUNUIE1BWChpZCkgRlJPTSBARWlubmFobWVuKQ0KREVMRVRFIEZST00gQ" +
                        "EF1c2dhYmVuICBXSEVSRSBUZXh0ID0gJycgQU5EIGlkID0gKFNFTEVDVCBNQVgoaWQpIEZST00gQEF1c" +
                        "2dhYmVuKQ0KDQpTRUxFQ1QNCiAgVGV4dEVpbiA9IEVJTi5UZXh0LCBCZXRyYWdFaW4gPSBFSU4uQmV0c" +
                        "mFnLA0KICBUZXh0QXVzID0gQVVTLlRleHQsIEJldHJhZ0F1cyA9IEFVUy5CZXRyYWcNCkZST00gQEVpb" +
                        "m5haG1lbiAgICAgICAgIEVJTg0KICBGVUxMICBKT0lOIEBBdXNnYWJlbiAgQVVTIE9OIEFVUy5pZCA9I" +
                        "EVJTi5pZA==";
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
            this.Detail.Height = 19;
            this.Detail.Name = "Detail";
            // 
            // xrLine1
            // 
            this.xrLine1.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine1.Location = new System.Drawing.Point(367, 0);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(8, 19);
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragAus", "{0:n2}")});
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel4.Location = new System.Drawing.Point(622, 0);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(100, 19);
            this.xrLabel4.Text = "xrLabel2";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TextAus", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel3.Location = new System.Drawing.Point(379, 0);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(258, 19);
            this.xrLabel3.Text = "xrLabel1";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragEin", "{0:n2}")});
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel2.Location = new System.Drawing.Point(258, 0);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(100, 19);
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TextEin", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel1.Location = new System.Drawing.Point(0, 0);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(275, 19);
            this.xrLabel1.Text = "xrLabel1";
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
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'-- Parameter
DECLARE @BgBudgetID  int,
        @RefDate     datetime
SELECT @BgBudgetID = BgBudgetID,
       @RefDate = convert (datetime, dbo.fnMIN(dbo.fnMAX(IsNull(SFP.DatumVon, SFP.GeplantVon), GetDate()),
                                                  IsNull(IsNull(SFP.DatumBis, SFP.GeplantBis), GetDate())))
FROM BgBudget              BBG
  INNER JOIN BgFinanzplan  SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
WHERE BBG.BgBudgetID = {BgBudgetID} AND BBG.MasterBudget = 1

DECLARE @Einnahmen TABLE (id int identity, Text varchar(100), Betrag money)
DECLARE @Ausgaben  TABLE (id int identity, Text varchar(100), Betrag money)



INSERT INTO @Einnahmen (Text,Betrag)
  SELECT Bezeichnung, Betrag
  FROM dbo.fnAyGetBudget(@BgBudgetID, @RefDate)
  WHERE BgKategorieCode = 1 AND Style > 1
    AND Total IS NULL

INSERT INTO @Ausgaben (Text,Betrag)
  SELECT Bezeichnung, Betrag
  FROM dbo.fnAyGetBudget(@BgBudgetID, @RefDate)
  WHERE BgKategorieCode > 1 AND (BgKategorieCode > 2 OR Style > 1)
    AND Total IS NULL

DELETE FROM @Einnahmen WHERE Text = '''' AND id = (SELECT MAX(id) FROM @Einnahmen)
DELETE FROM @Ausgaben  WHERE Text = '''' AND id = (SELECT MAX(id) FROM @Ausgaben)

SELECT
  TextEin = EIN.Text, BetragEin = EIN.Betrag,
  TextAus = AUS.Text, BetragAus = AUS.Betrag
FROM @Einnahmen         EIN
  FULL  JOIN @Ausgaben  AUS ON AUS.id = EIN.id' ,  null ,  N'AyMasterbudgetVerfuegung' ,  null );


INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'AyMasterbudgetVerfuegung_Personen' ,  N'Personen' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS40\KiSS4.NET\KiSS4.Main\bin\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4.NET\KiSS4.Main\bin\Debug\SharpLibrary.dll" />
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
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = @"zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OSNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kAAAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAAAAAAd8Dc2VsZWN0IE5hbWU9UFJTLk5hbWUgKyAnLCAnICsgUFJTLlZvcm5hbWUsDQogICAgICAgUFJTLkdlYnVydHNkYXR1bSwNCiAgICAgICBQUlMuTk51bW1lciwNCiAgICAgICBOYXRpb25hbGl0YWV0ID0gTkFULlRleHQNCmZyb20gICBCZ0J1ZGdldCBCQkcNCiAgICAgICBpbm5lciBqb2luIEJnRmluYW56cGxhbl9CYVBlcnNvbiAgU1BQIG9uIFNQUC5CZ0ZpbmFuenBsYW5JRD1CQkcuQmdGaW5hbnpwbGFuSUQNCiAgICAgICBpbm5lciBqb2luIEJhUGVyc29uICAgICAgICAgICAgICAgUFJTIG9uIFBSUy5CYVBlcnNvbklEPVNQUC5CYVBlcnNvbklEDQogICAgICAgbGVmdCAgam9pbiBYTE9WQ29kZSAgICAgICAgICAgICAgICBOQVQgb24gTkFULkxPVk5hbWU9J0JhTGFuZCcgYW5kIE5BVC5Db2RlPVBSUy5OYXRpb25hbGl0YWV0Q29kZQ0Kd2hlcmUgIFNQUC5Jc3RVbnRlcnN0dWV0enQ9MSBhbmQNCiAgICAgICBCQkcuQmdCdWRnZXRJRCA9IG51bGw=";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
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
            this.Detail.Height = 19;
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
            this.ReportHeader.Height = 23;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.ParentStyleUsing.UseBackColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorderColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorders = false;
            this.ReportHeader.ParentStyleUsing.UseBorderWidth = false;
            this.ReportHeader.ParentStyleUsing.UseFont = false;
            this.ReportHeader.ParentStyleUsing.UseForeColor = false;
            // 
            // txtHeimatort
            // 
            this.txtHeimatort.CanShrink = true;
            this.txtHeimatort.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NNummer", "")});
            this.txtHeimatort.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtHeimatort.ForeColor = System.Drawing.Color.Black;
            this.txtHeimatort.Location = new System.Drawing.Point(572, 0);
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
            this.txtHeimatort.Text = "txtHeimatort";
            // 
            // txtGebDat
            // 
            this.txtGebDat.CanShrink = true;
            this.txtGebDat.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Geburtsdatum", "{0:dd.MM.yyyy}")});
            this.txtGebDat.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtGebDat.ForeColor = System.Drawing.Color.Black;
            this.txtGebDat.Location = new System.Drawing.Point(464, 0);
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
            this.txtName.Location = new System.Drawing.Point(155, 0);
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
            this.xrLine1.Location = new System.Drawing.Point(155, 17);
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
            this.xrLabel3.Location = new System.Drawing.Point(572, 0);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(152, 15);
            this.xrLabel3.Text = "N-Nummer";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.Location = new System.Drawing.Point(464, 0);
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
            this.xrLabel1.Location = new System.Drawing.Point(155, 0);
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
                        this.ReportHeader});
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
' ,  null ,  N'select Name = PRS.NameVorname,
       PRS.Geburtsdatum,
       PRS.NNummer,
       PRS.Nationalitaet
from   BgBudget BBG
       inner join BgFinanzplan_BaPerson  SPP on SPP.BgFinanzplanID = BBG.BgFinanzplanID
       inner join vwPerson               PRS on PRS.BaPersonID = SPP.BaPersonID
where  SPP.IstUnterstuetzt = 1 and
       BBG.BgBudgetID = {BgBudgetID}' ,  null ,  N'AyMasterbudgetVerfuegung' ,  null );


