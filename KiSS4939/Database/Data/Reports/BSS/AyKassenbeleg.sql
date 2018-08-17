-- Insert Script for AyKassenbeleg
-- MD5:0X0ED54064CD380AA624EC1A34AD8884BE_0XB4C8772B5FDC602B7B6ACD41A694CD9C_0X1556D0025AFA229105362165541B8F76
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'AyKassenbeleg') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('AyKassenbeleg', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'AyKassenbeleg';
UPDATE QRY
SET QueryName =  N'AyKassenbeleg' , UserText =  N'AY - Kassenbeleg' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtNameFbKostenstelle;
        private DevExpress.XtraReports.UI.XRLabel txtIntern;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLine xrLine4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRRichTextBox xrRichTextBox1;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel Label14;
        private DevExpress.XtraReports.UI.XRLabel Label11;
        private DevExpress.XtraReports.UI.XRLabel Label10;
        private DevExpress.XtraReports.UI.XRLabel Label9;
        private DevExpress.XtraReports.UI.XRLabel txtEmployeeName;
        private DevExpress.XtraReports.UI.XRLabel txtVerfalldatum;
        private DevExpress.XtraReports.UI.XRLabel txtNameYearMonth;
        private DevExpress.XtraReports.UI.XRLabel txtFullName;
        private DevExpress.XtraReports.UI.XRLabel txtFlBelegID;
        private DevExpress.XtraReports.UI.XRLabel Label8;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel txtNameFbKostenart;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.XRLabel Label5;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLine xrLine5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAACAAAAAQAAAIwBRGV2RXhwcmVzc" +
                        "y5YdHJhUmVwb3J0cy5VSS5TZXJpYWxpemFibGVTdHJpbmcsIERldkV4cHJlc3MuWHRyYVJlcG9ydHMud" +
                        "jYuMiwgVmVyc2lvbj02LjIuNi4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPTc5ODY4Y" +
                        "jgxNDdiNWVhZTRQE7ROpJW/u7oAAAAANwAAALQBAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlA" +
                        "GMAdABTAHQAYQB0AGUAbQBlAG4AdAAAAAAALHgAcgBSAGkAYwBoAFQAZQB4AHQAQgBvAHgAMQAuAFIAd" +
                        "ABmAFQAZQB4AHQAcwoAAAHwFGRlY2xhcmUgQEtiQnVjaHVuZ0lEIGludA0Kc2V0IEBLYkJ1Y2h1bmdJR" +
                        "CA9IG51bGwNCg0Kc2VsZWN0IGRpc3RpbmN0ICAgIAkNCglLQkIuS2JBdXN6YWhsdW5nc2FydENvZGUsD" +
                        "QoJS0JCLktiQnVjaHVuZ0lELA0KCUtCQi5LYkJ1Y2h1bmdTdGF0dXNDb2RlLA0KCU5hbWVLYkJ1Y2h1b" +
                        "mdzU3RhdHVzID0gZGJvLmZuTE9WVGV4dCgnS2JCdWNodW5nc1N0YXR1cycsIEtCQi5LYkJ1Y2h1bmdTd" +
                        "GF0dXNDb2RlKSwNCglOYW1lS2JBdXN6YWhsdW5nc0FydCA9IGRiby5mbkxPVlRleHQoJ0tiQXVzemFob" +
                        "HVuZ3NBcnQnLCBLQkIuS2JBdXN6YWhsdW5nc2FydENvZGUpLA0KCU5hbWVZZWFyTW9udGggICAgICAgI" +
                        "D0gZGJvLmZuWE1vbmF0KEJHRy5Nb25hdCkgKyAnICcgKyBDb252ZXJ0KHZhcmNoYXIsIEJHRy5KYWhyK" +
                        "SwNCglWZXJmYWxsZGF0dW0gICAgICAgICA9IERBVEVBREQoREFZLCA1LCBLQkIuVmFsdXRhRGF0dW0pL" +
                        "A0KCUtCSy5LYkJ1Y2h1bmdLb3N0ZW5hcnRJRCwNCglLQksuQnVjaHVuZ3N0ZXh0LA0KCUtCSy5CZXRyY" +
                        "WcsDQoJTmFtZUtvc3RlbmFydCA9IEJHSy5OYW1lLA0KCUtCSy5CYVBlcnNvbklELCAgICAJDQoJTmFtZ" +
                        "Uthc3NpZXIgPSBLVVNSLkxhc3ROYW1lICsgaXNudWxsKCcsICcgKyBLVVNSLkZpcnN0TmFtZSwnJykgK" +
                        "w0KCQkJCQlpc051bGwoJyAoJyArIEtVU1IuUGhvbmUgKyAnKScsJycpLA0KCUZ1bGxOYW1lID0gUFJTL" +
                        "k5hbWVWb3JuYW1lLA0KCUF1c3p1emFobGVuQW4gPSBDQVNFIFdIRU4gS0JCLk1pdHRlaWx1bmdaZWlsZ" +
                        "TEgaXMgTlVMTCBPUiBLQkIuTWl0dGVpbHVuZ1plaWxlMSA9ICcnIFRIRU4gUFJTLk5hbWVWb3JuYW1lI" +
                        "EVMU0UgS0JCLk1pdHRlaWx1bmdaZWlsZTEgRU5ELA0KCVN0cmFzc2UgICAgICAgPSBDQVNFIFdIRU4gS" +
                        "0JCLk1pdHRlaWx1bmdaZWlsZTIgaXMgTlVMTCBPUiBLQkIuTWl0dGVpbHVuZ1plaWxlMiA9ICcnIFRIR" +
                        "U4gUFJTLldvaG5zaXR6U3RyYXNzZUhhdXNOciBFTFNFIEtCQi5NaXR0ZWlsdW5nWmVpbGUyIEVORCwNC" +
                        "glQTFpPcnQgICAgICAgID0gQ0FTRSBXSEVOIEtCQi5NaXR0ZWlsdW5nWmVpbGUzIGlzIE5VTEwgT1IgS" +
                        "0JCLk1pdHRlaWx1bmdaZWlsZTMgPSAnJyBUSEVOIFBSUy5Xb2huc2l0elBMWk9ydCBFTFNFIEtCQi5Na" +
                        "XR0ZWlsdW5nWmVpbGUzIEVORCwNCiAgICAgICAgUExaID0gUFJTLldvaG5zaXR6UExaLA0KICAgICAgI" +
                        "CBPcnQgPSBQUlMuV29obnNpdHpPcnQsDQoJS0JCLkJlbGVnTnIsDQogICAgICAgIEVtcGxveWVlTmFtZ" +
                        "SA9IFVTUi5MYXN0TmFtZSArIGlzbnVsbCgnLCAnICsgVVNSLkZpcnN0TmFtZSwnJykgKw0KCQkJCQlpc" +
                        "051bGwoJyAoJyArIFVTUi5QaG9uZSArICcpJywnJyksDQoJS0JCLlJlbWFyaywNCiAgICAgICAgVmFsd" +
                        "XRhRGF0dW0gPSBLQkIuVmFsdXRhRGF0dW0sDQoJQmFyYmVsZWdEYXR1bSwNCglOYW1lS29zdGVuc3Rlb" +
                        "GxlID0gQktTLk5hbWUsDQoJTk51bW1lciA9IFBSUy5OTnVtbWVyLA0KICAgICAgICBBZHJlc3NlID0ga" +
                        "XNudWxsKGNhc2UgUFJTLkdlc2NobGVjaHRDb2RlIHdoZW4gMSB0aGVuICdIZXJyJyB3aGVuIDIgdGhlb" +
                        "iAnRnJhdScgZW5kICsgY2hhcigxMykgKyBjaGFyKDEwKSwnJykgKw0KICAgICAgICAgICAgICAgICAgI" +
                        "CBpc251bGwoUFJTLk5hbWVWb3JuYW1lLCcnKSArIGNoYXIoMTMpICsgY2hhcigxMCkgKw0KICAgICAgI" +
                        "CAgICAgICAgICAgICBpc251bGwoUFJTLldvaG5zaXR6U3RyYXNzZUhhdXNOciwnJykgICsgY2hhcigxM" +
                        "ykgKyBjaGFyKDEwKSArDQogICAgICAgICAgICAgICAgICAgIGlzbnVsbChQUlMuV29obnNpdHpQTFpPc" +
                        "nQsJycpDQpmcm9tCUZhTGVpc3R1bmcgRkFMDQoJaW5uZXIgam9pbiB2d1BlcnNvbiAgICAgICAgICAgI" +
                        "CAgICBQUlMgIG9uIFBSUy5CYVBlcnNvbklEID0gRkFMLkJhUGVyc29uSUQNCglpbm5lciBqb2luIEJnR" +
                        "mluYW56cGxhbiAgICAgICAgICAgIFNGUCAgb24gU0ZQLkZhTGVpc3R1bmdJRCA9IEZBTC5GYUxlaXN0d" +
                        "W5nSUQNCglpbm5lciBqb2luIEJnRmluYW56cGxhbl9CYVBlcnNvbiAgIFNGRCAgb24gU0ZELkJnRmluY" +
                        "W56cGxhbklEID0gU0ZQLkJnRmluYW56cGxhbklEIEFORCBTRkQuSXN0VW50ZXJzdHVldHp0ID0gMQ0KC" +
                        "WlubmVyIGpvaW4gQmdCdWRnZXQgICAgICAgICAgICAgICAgQkdHICBvbiBCR0cuQmdGaW5hbnpwbGFuS" +
                        "UQgPSBTRlAuQmdGaW5hbnpwbGFuSUQNCglpbm5lciBqb2luIEtiQnVjaHVuZyAgICAgICAgICAgICAgI" +
                        "EtCQiAgb24gS0JCLkJnQnVkZ2V0SUQgPSBCR0cuQmdCdWRnZXRJRA0KICAgICAgICBpbm5lciBqb2luI" +
                        "EtiQnVjaHVuZ0tvc3RlbmFydCAgICAgIEtCSyAgb24gS0JLLktiQnVjaHVuZ0lEID0gS0JCLktiQnVja" +
                        "HVuZ0lEDQoJaW5uZXIgam9pbiBYVVNFUiAgICAgICAgICAgICAgICAgICBVU1IgIG9uIFVTUi5Vc2VyS" +
                        "UQgPSBGQUwuVXNlcklkDQoJbGVmdCAgam9pbiBYVVNFUiAgICAgICAgICAgICAgICAgICBLVVNSIG9uI" +
                        "EtVU1IuVXNlcklEID0gS0JCLkJhcmJlbGVnVXNlcklEDQoJbGVmdCAgam9pbiBCZ0tvc3RlbmFydAkJI" +
                        "CAgQkdLICBvbiBCR0suQmdLb3N0ZW5hcnRJRCA9IEtCSy5CZ0tvc3RlbmFydElEDQoJbGVmdCAgam9pb" +
                        "iBLYktvc3RlbnN0ZWxsZQkgICBCS1MgIG9uIEJLUy5LYktvc3RlbnN0ZWxsZUlEID0gS0JLLktiS29zd" +
                        "GVuc3RlbGxlSUQNCg0Kd2hlcmUgS0JCLktiQnVjaHVuZ0lEID0gQEtiQnVjaHVuZ0lEQAABAAAA/////" +
                        "wEAAAAAAAAADAIAAAAbRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy52Ni4yBQEAAAAsRGV2RXhwcmVzcy5Yd" +
                        "HJhUmVwb3J0cy5VSS5TZXJpYWxpemFibGVTdHJpbmcBAAAABVZhbHVlAQIAAAAGAwAAANcBe1xydGYxX" +
                        "GFuc2lcYW5zaWNwZzEyNTJcZGVmZjB7XGZvbnR0Ymx7XGYwXGZuaWxcZmNoYXJzZXQwIE1pY3Jvc29md" +
                        "CBTYW5zIFNlcmlmO319DQpcdmlld2tpbmQ0XHVjMVxwYXJkXGxhbmcxMDMzXGYwXGZzMTcgS29tcGV0Z" +
                        "W56emVudHJ1bSBJbnRlZ3JhdGlvblxwYXINCkVmZmluZ2Vyc3RyYXNzZSAyMVxwYXINClBvc3RmYWNoI" +
                        "DgxMjVccGFyDQozMDAxIEJlcm5ccGFyDQp9DQoL";
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
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNameFbKostenstelle = new DevExpress.XtraReports.UI.XRLabel();
            this.txtIntern = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrRichTextBox1 = new DevExpress.XtraReports.UI.XRRichTextBox();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.Label14 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label11 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label10 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label9 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtEmployeeName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtVerfalldatum = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNameYearMonth = new DevExpress.XtraReports.UI.XRLabel();
            this.txtFullName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtFlBelegID = new DevExpress.XtraReports.UI.XRLabel();
            this.Label8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNameFbKostenart = new DevExpress.XtraReports.UI.XRLabel();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtBetrag,
                        this.txtNameFbKostenstelle,
                        this.txtIntern});
            this.Detail.Height = 27;
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
                        this.xrLine4,
                        this.xrLabel8,
                        this.xrLabel7,
                        this.xrLabel6,
                        this.xrLabel3,
                        this.xrLabel2,
                        this.xrLabel1,
                        this.xrRichTextBox1,
                        this.Line1,
                        this.Label14,
                        this.Label11,
                        this.Label10,
                        this.Label9,
                        this.txtEmployeeName,
                        this.txtVerfalldatum,
                        this.txtNameYearMonth,
                        this.txtFullName,
                        this.txtFlBelegID,
                        this.Label8,
                        this.Label7,
                        this.Label4});
            this.PageHeader.Height = 412;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.ParentStyleUsing.UseBackColor = false;
            this.PageHeader.ParentStyleUsing.UseBorderColor = false;
            this.PageHeader.ParentStyleUsing.UseBorders = false;
            this.PageHeader.ParentStyleUsing.UseBorderWidth = false;
            this.PageHeader.ParentStyleUsing.UseFont = false;
            this.PageHeader.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtNameFbKostenart});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("NameFbKostenart", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 31;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Label6,
                        this.Label5});
            this.PageFooter.Height = 31;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLine5,
                        this.xrLabel5,
                        this.xrLine3,
                        this.xrLabel4,
                        this.xrLine2});
            this.ReportFooter.Name = "ReportFooter";
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(641, 4);
            this.txtBetrag.Multiline = true;
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(86, 20);
            xrSummary1.FormatString = "{0:0.00}";
            this.txtBetrag.Summary = xrSummary1;
            this.txtBetrag.Text = "txtBetrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtNameFbKostenstelle
            // 
            this.txtNameFbKostenstelle.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameKostenstelle", "")});
            this.txtNameFbKostenstelle.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNameFbKostenstelle.ForeColor = System.Drawing.Color.Black;
            this.txtNameFbKostenstelle.Location = new System.Drawing.Point(429, 4);
            this.txtNameFbKostenstelle.Multiline = true;
            this.txtNameFbKostenstelle.Name = "txtNameFbKostenstelle";
            this.txtNameFbKostenstelle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBackColor = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBorderColor = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBorders = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBorderWidth = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseFont = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseForeColor = false;
            this.txtNameFbKostenstelle.Size = new System.Drawing.Size(208, 20);
            this.txtNameFbKostenstelle.Text = "txtNameFbKostenstelle";
            // 
            // txtIntern
            // 
            this.txtIntern.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Buchungstext", "")});
            this.txtIntern.Font = new System.Drawing.Font("Arial", 10F);
            this.txtIntern.ForeColor = System.Drawing.Color.Black;
            this.txtIntern.Location = new System.Drawing.Point(19, 4);
            this.txtIntern.Multiline = true;
            this.txtIntern.Name = "txtIntern";
            this.txtIntern.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtIntern.ParentStyleUsing.UseBackColor = false;
            this.txtIntern.ParentStyleUsing.UseBorderColor = false;
            this.txtIntern.ParentStyleUsing.UseBorders = false;
            this.txtIntern.ParentStyleUsing.UseBorderWidth = false;
            this.txtIntern.ParentStyleUsing.UseFont = false;
            this.txtIntern.ParentStyleUsing.UseForeColor = false;
            this.txtIntern.Size = new System.Drawing.Size(385, 20);
            this.txtIntern.Text = "txtIntern";
            // 
            // xrLine4
            // 
            this.xrLine4.ForeColor = System.Drawing.Color.Black;
            this.xrLine4.Location = new System.Drawing.Point(19, 400);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.ParentStyleUsing.UseBackColor = false;
            this.xrLine4.ParentStyleUsing.UseBorderColor = false;
            this.xrLine4.ParentStyleUsing.UseBorders = false;
            this.xrLine4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine4.ParentStyleUsing.UseFont = false;
            this.xrLine4.ParentStyleUsing.UseForeColor = false;
            this.xrLine4.Size = new System.Drawing.Size(709, 4);
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel8.ForeColor = System.Drawing.Color.Black;
            this.xrLabel8.Location = new System.Drawing.Point(641, 383);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseBackColor = false;
            this.xrLabel8.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel8.ParentStyleUsing.UseBorders = false;
            this.xrLabel8.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.ParentStyleUsing.UseForeColor = false;
            this.xrLabel8.Size = new System.Drawing.Size(86, 19);
            this.xrLabel8.Text = "Betrag";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel7.ForeColor = System.Drawing.Color.Black;
            this.xrLabel7.Location = new System.Drawing.Point(429, 383);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseBackColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorders = false;
            this.xrLabel7.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.ParentStyleUsing.UseForeColor = false;
            this.xrLabel7.Size = new System.Drawing.Size(208, 19);
            this.xrLabel7.Text = "Kostenstelle";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel6.ForeColor = System.Drawing.Color.Black;
            this.xrLabel6.Location = new System.Drawing.Point(19, 383);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseBackColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorders = false;
            this.xrLabel6.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.ParentStyleUsing.UseForeColor = false;
            this.xrLabel6.Size = new System.Drawing.Size(385, 19);
            this.xrLabel6.Text = "Buchungstext";
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NNummer", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(500, 232);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(233, 19);
            this.xrLabel3.Text = "xrLabel3";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.Location = new System.Drawing.Point(375, 232);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseBackColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorders = false;
            this.xrLabel2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.ParentStyleUsing.UseForeColor = false;
            this.xrLabel2.Size = new System.Drawing.Size(122, 19);
            this.xrLabel2.Text = "N-Nummer";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Adresse", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.Location = new System.Drawing.Point(158, 267);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseBackColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.ParentStyleUsing.UseForeColor = false;
            this.xrLabel1.Size = new System.Drawing.Size(367, 75);
            this.xrLabel1.Text = "xrLabel1";
            // 
            // xrRichTextBox1
            // 
            this.xrRichTextBox1.CanShrink = true;
            this.xrRichTextBox1.ForeColor = System.Drawing.Color.Black;
            this.xrRichTextBox1.Location = new System.Drawing.Point(8, 0);
            this.xrRichTextBox1.Name = "xrRichTextBox1";
            this.xrRichTextBox1.ParentStyleUsing.UseBackColor = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorderColor = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorders = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorderWidth = false;
            this.xrRichTextBox1.ParentStyleUsing.UseFont = false;
            this.xrRichTextBox1.ParentStyleUsing.UseForeColor = false;
            this.xrRichTextBox1.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichTextBox1.RtfText")));
            this.xrRichTextBox1.Size = new System.Drawing.Size(158, 75);
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.LineWidth = 2;
            this.Line1.Location = new System.Drawing.Point(0, 358);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(744, 2);
            // 
            // Label14
            // 
            this.Label14.Font = new System.Drawing.Font("Arial", 11F);
            this.Label14.ForeColor = System.Drawing.Color.Black;
            this.Label14.Location = new System.Drawing.Point(14, 267);
            this.Label14.Name = "Label14";
            this.Label14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label14.ParentStyleUsing.UseBackColor = false;
            this.Label14.ParentStyleUsing.UseBorderColor = false;
            this.Label14.ParentStyleUsing.UseBorders = false;
            this.Label14.ParentStyleUsing.UseBorderWidth = false;
            this.Label14.ParentStyleUsing.UseFont = false;
            this.Label14.ParentStyleUsing.UseForeColor = false;
            this.Label14.Size = new System.Drawing.Size(141, 23);
            this.Label14.Text = "Auszahlung an:";
            // 
            // Label11
            // 
            this.Label11.Font = new System.Drawing.Font("Arial", 10F);
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(375, 213);
            this.Label11.Name = "Label11";
            this.Label11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label11.ParentStyleUsing.UseBackColor = false;
            this.Label11.ParentStyleUsing.UseBorderColor = false;
            this.Label11.ParentStyleUsing.UseBorders = false;
            this.Label11.ParentStyleUsing.UseBorderWidth = false;
            this.Label11.ParentStyleUsing.UseFont = false;
            this.Label11.ParentStyleUsing.UseForeColor = false;
            this.Label11.Size = new System.Drawing.Size(122, 19);
            this.Label11.Text = "Fallbearbeitung";
            // 
            // Label10
            // 
            this.Label10.Font = new System.Drawing.Font("Arial", 10F);
            this.Label10.ForeColor = System.Drawing.Color.Black;
            this.Label10.Location = new System.Drawing.Point(375, 194);
            this.Label10.Name = "Label10";
            this.Label10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label10.ParentStyleUsing.UseBackColor = false;
            this.Label10.ParentStyleUsing.UseBorderColor = false;
            this.Label10.ParentStyleUsing.UseBorders = false;
            this.Label10.ParentStyleUsing.UseBorderWidth = false;
            this.Label10.ParentStyleUsing.UseFont = false;
            this.Label10.ParentStyleUsing.UseForeColor = false;
            this.Label10.Size = new System.Drawing.Size(122, 19);
            this.Label10.Text = "Verfalldatum";
            // 
            // Label9
            // 
            this.Label9.Font = new System.Drawing.Font("Arial", 10F);
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(375, 175);
            this.Label9.Name = "Label9";
            this.Label9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label9.ParentStyleUsing.UseBackColor = false;
            this.Label9.ParentStyleUsing.UseBorderColor = false;
            this.Label9.ParentStyleUsing.UseBorders = false;
            this.Label9.ParentStyleUsing.UseBorderWidth = false;
            this.Label9.ParentStyleUsing.UseFont = false;
            this.Label9.ParentStyleUsing.UseForeColor = false;
            this.Label9.Size = new System.Drawing.Size(133, 19);
            this.Label9.Text = "Auszahlungsmonat";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "EmployeeName", "")});
            this.txtEmployeeName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtEmployeeName.ForeColor = System.Drawing.Color.Black;
            this.txtEmployeeName.Location = new System.Drawing.Point(500, 213);
            this.txtEmployeeName.Multiline = true;
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtEmployeeName.ParentStyleUsing.UseBackColor = false;
            this.txtEmployeeName.ParentStyleUsing.UseBorderColor = false;
            this.txtEmployeeName.ParentStyleUsing.UseBorders = false;
            this.txtEmployeeName.ParentStyleUsing.UseBorderWidth = false;
            this.txtEmployeeName.ParentStyleUsing.UseFont = false;
            this.txtEmployeeName.ParentStyleUsing.UseForeColor = false;
            this.txtEmployeeName.Size = new System.Drawing.Size(233, 19);
            this.txtEmployeeName.Text = "txtEmployeeName";
            // 
            // txtVerfalldatum
            // 
            this.txtVerfalldatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ValutaDatum", "{0:dd,MM.yyyy}")});
            this.txtVerfalldatum.Font = new System.Drawing.Font("Arial", 10F);
            this.txtVerfalldatum.ForeColor = System.Drawing.Color.Black;
            this.txtVerfalldatum.Location = new System.Drawing.Point(500, 194);
            this.txtVerfalldatum.Multiline = true;
            this.txtVerfalldatum.Name = "txtVerfalldatum";
            this.txtVerfalldatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtVerfalldatum.ParentStyleUsing.UseBackColor = false;
            this.txtVerfalldatum.ParentStyleUsing.UseBorderColor = false;
            this.txtVerfalldatum.ParentStyleUsing.UseBorders = false;
            this.txtVerfalldatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtVerfalldatum.ParentStyleUsing.UseFont = false;
            this.txtVerfalldatum.ParentStyleUsing.UseForeColor = false;
            this.txtVerfalldatum.Size = new System.Drawing.Size(233, 19);
            xrSummary2.FormatString = "{0:dd.MM.yyyy}";
            this.txtVerfalldatum.Summary = xrSummary2;
            this.txtVerfalldatum.Text = "txtVerfalldatum";
            // 
            // txtNameYearMonth
            // 
            this.txtNameYearMonth.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameYearMonth", "")});
            this.txtNameYearMonth.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNameYearMonth.ForeColor = System.Drawing.Color.Black;
            this.txtNameYearMonth.Location = new System.Drawing.Point(500, 175);
            this.txtNameYearMonth.Multiline = true;
            this.txtNameYearMonth.Name = "txtNameYearMonth";
            this.txtNameYearMonth.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNameYearMonth.ParentStyleUsing.UseBackColor = false;
            this.txtNameYearMonth.ParentStyleUsing.UseBorderColor = false;
            this.txtNameYearMonth.ParentStyleUsing.UseBorders = false;
            this.txtNameYearMonth.ParentStyleUsing.UseBorderWidth = false;
            this.txtNameYearMonth.ParentStyleUsing.UseFont = false;
            this.txtNameYearMonth.ParentStyleUsing.UseForeColor = false;
            this.txtNameYearMonth.Size = new System.Drawing.Size(233, 19);
            this.txtNameYearMonth.Text = "NameYearMonth";
            // 
            // txtFullName
            // 
            this.txtFullName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "FullName", "")});
            this.txtFullName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txtFullName.ForeColor = System.Drawing.Color.Black;
            this.txtFullName.Location = new System.Drawing.Point(100, 202);
            this.txtFullName.Multiline = true;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtFullName.ParentStyleUsing.UseBackColor = false;
            this.txtFullName.ParentStyleUsing.UseBorderColor = false;
            this.txtFullName.ParentStyleUsing.UseBorders = false;
            this.txtFullName.ParentStyleUsing.UseBorderWidth = false;
            this.txtFullName.ParentStyleUsing.UseFont = false;
            this.txtFullName.ParentStyleUsing.UseForeColor = false;
            this.txtFullName.Size = new System.Drawing.Size(269, 27);
            this.txtFullName.Text = "FullName";
            // 
            // txtFlBelegID
            // 
            this.txtFlBelegID.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BelegNr", "")});
            this.txtFlBelegID.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txtFlBelegID.ForeColor = System.Drawing.Color.Black;
            this.txtFlBelegID.Location = new System.Drawing.Point(100, 175);
            this.txtFlBelegID.Multiline = true;
            this.txtFlBelegID.Name = "txtFlBelegID";
            this.txtFlBelegID.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtFlBelegID.ParentStyleUsing.UseBackColor = false;
            this.txtFlBelegID.ParentStyleUsing.UseBorderColor = false;
            this.txtFlBelegID.ParentStyleUsing.UseBorders = false;
            this.txtFlBelegID.ParentStyleUsing.UseBorderWidth = false;
            this.txtFlBelegID.ParentStyleUsing.UseFont = false;
            this.txtFlBelegID.ParentStyleUsing.UseForeColor = false;
            this.txtFlBelegID.Size = new System.Drawing.Size(269, 27);
            this.txtFlBelegID.Text = "txtFlBelegID";
            // 
            // Label8
            // 
            this.Label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(14, 202);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(100, 27);
            this.Label8.Text = "Klient/-in :";
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(14, 175);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(62, 27);
            this.Label7.Text = "Beleg :";
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Gainsboro;
            this.Label4.Font = new System.Drawing.Font("Arial", 18F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(8, 98);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(734, 40);
            this.Label4.Text = "Kassenbeleg";
            this.Label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // txtNameFbKostenart
            // 
            this.txtNameFbKostenart.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameKostenart", "")});
            this.txtNameFbKostenart.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.txtNameFbKostenart.ForeColor = System.Drawing.Color.Black;
            this.txtNameFbKostenart.Location = new System.Drawing.Point(19, 7);
            this.txtNameFbKostenart.Multiline = true;
            this.txtNameFbKostenart.Name = "txtNameFbKostenart";
            this.txtNameFbKostenart.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNameFbKostenart.ParentStyleUsing.UseBackColor = false;
            this.txtNameFbKostenart.ParentStyleUsing.UseBorderColor = false;
            this.txtNameFbKostenart.ParentStyleUsing.UseBorders = false;
            this.txtNameFbKostenart.ParentStyleUsing.UseBorderWidth = false;
            this.txtNameFbKostenart.ParentStyleUsing.UseFont = false;
            this.txtNameFbKostenart.ParentStyleUsing.UseForeColor = false;
            this.txtNameFbKostenart.Size = new System.Drawing.Size(696, 20);
            this.txtNameFbKostenart.Text = "txtNameFbKostenart";
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 10F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(307, 7);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(429, 19);
            this.Label6.Text = "Betrag dankend erhalten  ........................................................" +
                "...........";
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial", 10F);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(7, 7);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(284, 19);
            this.Label5.Text = "Bezahlt am: ..............................................";
            // 
            // xrLine5
            // 
            this.xrLine5.ForeColor = System.Drawing.Color.Black;
            this.xrLine5.LineWidth = 2;
            this.xrLine5.Location = new System.Drawing.Point(350, 72);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.ParentStyleUsing.UseBackColor = false;
            this.xrLine5.ParentStyleUsing.UseBorderColor = false;
            this.xrLine5.ParentStyleUsing.UseBorders = false;
            this.xrLine5.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine5.ParentStyleUsing.UseFont = false;
            this.xrLine5.ParentStyleUsing.UseForeColor = false;
            this.xrLine5.Size = new System.Drawing.Size(374, 2);
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.ForeColor = System.Drawing.Color.Black;
            this.xrLabel5.Location = new System.Drawing.Point(350, 33);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseBackColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorders = false;
            this.xrLabel5.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.ParentStyleUsing.UseForeColor = false;
            this.xrLabel5.Size = new System.Drawing.Size(251, 27);
            this.xrLabel5.Text = "Auszubezahlender Betrag ";
            // 
            // xrLine3
            // 
            this.xrLine3.ForeColor = System.Drawing.Color.Black;
            this.xrLine3.LineWidth = 2;
            this.xrLine3.Location = new System.Drawing.Point(350, 67);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.ParentStyleUsing.UseBackColor = false;
            this.xrLine3.ParentStyleUsing.UseBorderColor = false;
            this.xrLine3.ParentStyleUsing.UseBorders = false;
            this.xrLine3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine3.ParentStyleUsing.UseFont = false;
            this.xrLine3.ParentStyleUsing.UseForeColor = false;
            this.xrLine3.Size = new System.Drawing.Size(374, 2);
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "")});
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.Location = new System.Drawing.Point(625, 33);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.ParentStyleUsing.UseForeColor = false;
            this.xrLabel4.Size = new System.Drawing.Size(100, 27);
            xrSummary3.FormatString = "{0:n2}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel4.Summary = xrSummary3;
            this.xrLabel4.Text = "Betrag";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLine2
            // 
            this.xrLine2.ForeColor = System.Drawing.Color.Black;
            this.xrLine2.LineWidth = 2;
            this.xrLine2.Location = new System.Drawing.Point(350, 67);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.ParentStyleUsing.UseBackColor = false;
            this.xrLine2.ParentStyleUsing.UseBorderColor = false;
            this.xrLine2.ParentStyleUsing.UseBorders = false;
            this.xrLine2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine2.ParentStyleUsing.UseFont = false;
            this.xrLine2.ParentStyleUsing.UseForeColor = false;
            this.xrLine2.Size = new System.Drawing.Size(374, 2);
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
                        this.GroupHeader1,
                        this.PageFooter,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(39, 39, 39, 39);
            this.Name = "Report";
            this.PageHeight = 1178;
            this.PageWidth = 928;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' , ParameterXML =  N'<?xml version="1.0" standalone="yes" ?>
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
</NewDataSet>' , SQLquery =  N'declare @KbBuchungID int
set @KbBuchungID = {KbBuchungID}

select distinct    	
	KBB.KbAuszahlungsartCode,
	KBB.KbBuchungID,
	KBB.KbBuchungStatusCode,
	NameKbBuchungsStatus = dbo.fnLOVText(''KbBuchungsStatus'', KBB.KbBuchungStatusCode),
	NameKbAuszahlungsArt = dbo.fnLOVText(''KbAuszahlungsArt'', KBB.KbAuszahlungsartCode),
	NameYearMonth        = dbo.fnXMonat(BGG.Monat) + '' '' + Convert(varchar, BGG.Jahr),
	Verfalldatum         = DATEADD(DAY, 5, KBB.ValutaDatum),
	KBK.KbBuchungKostenartID,
	KBK.Buchungstext,
	KBK.Betrag,
	NameKostenart = BGK.Name,
	KBK.BaPersonID,    	
	NameKassier = KUSR.LastName + isnull('', '' + KUSR.FirstName,'''') +
					isNull('' ('' + KUSR.Phone + '')'',''''),
	FullName = PRS.NameVorname,
	AuszuzahlenAn = CASE WHEN KBB.MitteilungZeile1 is NULL OR KBB.MitteilungZeile1 = '''' THEN PRS.NameVorname ELSE KBB.MitteilungZeile1 END,
	Strasse       = CASE WHEN KBB.MitteilungZeile2 is NULL OR KBB.MitteilungZeile2 = '''' THEN PRS.WohnsitzStrasseHausNr ELSE KBB.MitteilungZeile2 END,
	PLZOrt        = CASE WHEN KBB.MitteilungZeile3 is NULL OR KBB.MitteilungZeile3 = '''' THEN PRS.WohnsitzPLZOrt ELSE KBB.MitteilungZeile3 END,
        PLZ = PRS.WohnsitzPLZ,
        Ort = PRS.WohnsitzOrt,
	KBB.BelegNr,
        EmployeeName = USR.LastName + isnull('', '' + USR.FirstName,'''') +
					isNull('' ('' + USR.Phone + '')'',''''),
	KBB.Remark,
        ValutaDatum = KBB.ValutaDatum,
	BarbelegDatum,
	NameKostenstelle = BKS.Name,
	NNummer = PRS.NNummer,
        Adresse = isnull(case PRS.GeschlechtCode when 1 then ''Herr'' when 2 then ''Frau'' end + char(13) + char(10),'''') +
                    isnull(PRS.NameVorname,'''') + char(13) + char(10) +
                    isnull(PRS.WohnsitzStrasseHausNr,'''')  + char(13) + char(10) +
                    isnull(PRS.WohnsitzPLZOrt,'''')
from	FaLeistung FAL
	inner join vwPerson                PRS  on PRS.BaPersonID = FAL.BaPersonID
	inner join BgFinanzplan            SFP  on SFP.FaLeistungID = FAL.FaLeistungID
	inner join BgFinanzplan_BaPerson   SFD  on SFD.BgFinanzplanID = SFP.BgFinanzplanID AND SFD.IstUnterstuetzt = 1
	inner join BgBudget                BGG  on BGG.BgFinanzplanID = SFP.BgFinanzplanID
	inner join KbBuchung               KBB  on KBB.BgBudgetID = BGG.BgBudgetID
        inner join KbBuchungKostenart      KBK  on KBK.KbBuchungID = KBB.KbBuchungID
	inner join XUSER                   USR  on USR.UserID = FAL.UserId
	left  join XUSER                   KUSR on KUSR.UserID = KBB.BarbelegUserID
	left  join BgKostenart		   BGK  on BGK.BgKostenartID = KBK.BgKostenartID
	left  join KbKostenstelle	   BKS  on BKS.KbKostenstelleID = KBK.KbKostenstelleID

where KBB.KbBuchungID = @KbBuchungID' , ContextForms =  N'FrmAyKasse' , ParentReportName =  null , ReportSortKey = 10
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'AyKassenbeleg' ;


