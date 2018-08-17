-- Insert Script for ShDetaillierterFinanzplan
-- MD5:0X9D9F624E330E3B97316627B78B062A16_0X908CF3801AC004136B2A4C5896CE8AA1_0X6C0CE31F253A922DAA799181B6FAFE13
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'ShDetaillierterFinanzplan') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('ShDetaillierterFinanzplan', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'ShDetaillierterFinanzplan';
--SQLCHECK_IGNORE--
UPDATE QRY
SET QueryName =  N'ShDetaillierterFinanzplan' , UserText =  N'SH - Detaillierter Finanzplan' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4.2.20\KiSS4.DB.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4.2.20\log4net.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4.2.20\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplan_Bewilligungsverfahren;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplan_Vermoegen;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplan_EinkommenAlimente;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplan_EinkommenVersich;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplan_Erwerbseinkommen;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplan_AllgErwerbsunkosten;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplan_Sil;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplan_KvgVvg;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplan_GBMiete;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplan_Uebersicht;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplan_Personen;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel Label8;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.XRLabel Label5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.XRLabel txtDatumBis;
        private DevExpress.XtraReports.UI.XRLabel txtDatumVon;
        private DevExpress.XtraReports.UI.XRLabel Label3;
        private DevExpress.XtraReports.UI.XRLabel txtGeplantBis;
        private DevExpress.XtraReports.UI.XRLabel txtGeplantVon;
        private DevExpress.XtraReports.UI.XRLabel Label2;
        private DevExpress.XtraReports.UI.XRLabel FullName1;
        private DevExpress.XtraReports.UI.XRLabel TextBox1;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLabel txtTitel;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel txtOrgAdresse;
        private DevExpress.XtraReports.UI.XRLabel txtOrgName;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo3;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
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
                        "AAAAZ4XLS0tLSBzcHNvdGE6IDIwMTAwMzE4DQpERUNMQVJFIEBWb3JuYW1lTmFtZV9adXNhdHogVkFSQ" +
                        "0hBUihNQVgpDQpTRVQgQFZvcm5hbWVOYW1lX1p1c2F0eiA9IChTRUxFQ1QgVm9ybmFtZU5hbWUgKyBja" +
                        "GFyKDEzKSArIGNoYXIoMTApIEZST00gdndQZXJzb24gV0hFUkUgQmFQZXJzb25JRCA9IG51bGwpDQoNC" +
                        "lNFTEVDVCBUT1AgMQ0KICBbT3JnTmFtZV0gICAgICA9IElzTnVsbChDT05WRVJUKHZhcmNoYXIoMTAwM" +
                        "CksIGRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlXE9yZ2FuaXNhdGlvbicsI" +
                        "EdldGRhdGUoKSkpLCAnJyksDQogIFtPcmdBZHJlc3NlXSAgID0gSXNOdWxsKENPTlZFUlQodmFyY2hhc" +
                        "igxMDAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc2VcU296aWFsaGlsZmVcQWRyZXNzZScsI" +
                        "EdldGRhdGUoKSkpLCAnJyksDQogIFtPcmdQTFpPcnRdICAgID0gSXNOdWxsKENPTlZFUlQodmFyY2hhc" +
                        "igxMDAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc2VcU296aWFsaGlsZmVcUExaJywgR2V0Z" +
                        "GF0ZSgpKSkgKyAnICcsICcnKQ0KICAgICAgICAgICAgICAgICArIElzTnVsbChDT05WRVJUKHZhcmNoY" +
                        "XIoMTAwMCksIGRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlXE9ydCcsIEdld" +
                        "GRhdGUoKSkpLCAnJyksDQoNCiAgW0JnRmluYW56cGxhbklEXSA9IFNGUC5CZ0ZpbmFuenBsYW5JRCwgL" +
                        "S0gcmVxdWlyZWQgZm9yIHN1YnJlcG9ydHMNCiAgW0JnQnVkZ2V0SURdICAgICA9IEJCRy5CZ0J1ZGdld" +
                        "ElELCAtLSByZXF1aXJlZCBmb3Igc3VicmVwb3J0cw0KICBbVGl0ZWxdICAgICAgICA9ICdEZXRhaWxsa" +
                        "WVydGUgVmVyZsO8Z3VuZyAnICsgTFZULlRleHQsIC0tIExWVC5UZXh0ID0gVHlwDQogIFtGdWxsTmFtZ" +
                        "V0gICAgID0gUFJTLk5hbWUgKyBJc051bGwoJywgJyArIFBSUy5Wb3JuYW1lLCcnKSArICBDQVNFIExFT" +
                        "ihJc051bGwoUFJTLlZvcm5hbWUyLCAnJykpIFdIRU4gMCBUSEVOICcnIEVMU0UgJyAnICsgUFJTLlZvc" +
                        "m5hbWUyIEVORCwNCiAgW0FIVk51bW1lcl0gICAgPSBQUlMuQUhWTnVtbWVyLA0KICBbU3RhdHVzXSAgI" +
                        "CAgICA9IExWUy5UZXh0ICsgQ0FTRSBXSEVOIEZGQS5GYUxlaXN0dW5nSUQgSVMgTk9UIE5VTEwgVEhFT" +
                        "iAnIChhcmNoaXZpZXJ0KScgRUxTRSAnJyBFTkQsDQogIFtJc1VyZ2VudF0gICAgID0gTFZULlZhbHVlM" +
                        "iwNCiAgW0dlcGxhbnRWb25dICAgPSBTRlAuR2VwbGFudFZvbiwNCiAgW0dlcGxhbnRCaXNdICAgPSBTR" +
                        "lAuR2VwbGFudEJpcywNCiAgW0RhdHVtVm9uXSAgICAgPSBTRlAuRGF0dW1Wb24sDQogIFtEYXR1bUJpc" +
                        "10gICAgID0gU0ZQLkRhdHVtQmlzLA0KICBbQmVtZXJrdW5nXSAgICA9IFNGUC5CZW1lcmt1bmcsDQogI" +
                        "FtBbnJlZGVdICAgICAgID0gQ0FTRSBQUlMuR2VzY2hsZWNodENvZGUgV0hFTiAyIFRIRU4gJ0ZyYXUnI" +
                        "EVMU0UgJ0hlcnJuJyBFTkQsDQogIFtOYW1lXSAgICAgICAgID0gUFJTLk5hbWUsDQogIFtWb3JuYW1lX" +
                        "SAgICAgID0gUFJTLlZvcm5hbWUsDQogIFtTdHJhc3NlXSAgICAgID0gUFJTLldvaG5zaXR6U3RyYXNzZ" +
                        "UhhdXNOciwNCiAgW1BMWk9ydF0gICAgICAgPSBQUlMuV29obnNpdHpQTFpPcnQsDQogIEFkcmVzc2UgI" +
                        "CAgICAgID0gQ0FTRSANCiAgICAgICAgICAgICAgICAgICAgIFdIRU4gQFZvcm5hbWVOYW1lX1p1c2F0e" +
                        "iBJUyBOVUxMIFRIRU4NCiAgICAgICAgICAgICAgICAgICAgICAgSXNOdWxsKENBU0UgUFJTLkdlc2Nob" +
                        "GVjaHRDb2RlIFdIRU4gMSBUSEVOICdIZXJyJyBXSEVOIDIgVEhFTiAnRnJhdScgRU5EICsgY2hhcigxM" +
                        "ykgKyBjaGFyKDEwKSwnJykgKw0KICAgICAgICAgICAgICAgICAgICAgICBQUlMuTmFtZVZvcm5hbWUgK" +
                        "yBjaGFyKDEzKSArIGNoYXIoMTApICsNCiAgICAgICAgICAgICAgICAgICAgICAgUFJTLldvaG5zaXR6U" +
                        "3RyYXNzZUhhdXNOciArIGNoYXIoMTMpICsgY2hhcigxMCkgKw0KICAgICAgICAgICAgICAgICAgICAgI" +
                        "CBQUlMuV29obnNpdHpQTFpPcnQNCiAgICAgICAgICAgICAgICAgICAgIEVMU0UNCiAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgUFJTLlZvcm5hbWVOYW1lICsgY2hhcigxMykgKyBjaGFyKDEwKSArDQogICAgICAgI" +
                        "CAgICAgICAgICAgICAgIEBWb3JuYW1lTmFtZV9adXNhdHogKw0KICAgICAgICAgICAgICAgICAgICAgI" +
                        "CBQUlMuV29obnNpdHpTdHJhc3NlSGF1c05yICsgY2hhcigxMykgKyBjaGFyKDEwKSArDQogICAgICAgI" +
                        "CAgICAgICAgICAgICAgIFBSUy5Xb2huc2l0elBMWk9ydA0KICAgICAgICAgICAgICAgICAgIEVORA0KD" +
                        "QpGUk9NIEJnRmluYW56cGxhbiAgICAgICAgICAgICAgU0ZQDQogIElOTkVSIEpPSU4gQmdCdWRnZXQgI" +
                        "CAgICAgICAgQkJHIE9OIEJCRy5CZ0ZpbmFuenBsYW5JRCA9IFNGUC5CZ0ZpbmFuenBsYW5JRCBBTkQgQ" +
                        "kJHLk1hc3RlckJ1ZGdldCA9IDENCiAgTEVGVCAgSk9JTiBYTE9WQ29kZSAgICAgICAgICBMVlMgT04gT" +
                        "FZTLkxPVk5hbWUgPSAnQmdCZXdpbGxpZ3VuZ1N0YXR1cycgQU5EIExWUy5Db2RlID0gU0ZQLkJnQmV3a" +
                        "WxsaWd1bmdTdGF0dXNDb2RlDQogIExFRlQgIEpPSU4gWExPVkNvZGUgICAgICAgICAgTFZUIE9OIExWV" +
                        "C5MT1ZOYW1lID0gJ1doSGlsZmVUeXAnIEFORCBMVlQuQ29kZSA9IFNGUC5XaEhpbGZlVHlwQ29kZQ0KI" +
                        "CBJTk5FUiBKT0lOIEZhTGVpc3R1bmcgICAgICAgIEZBTCBPTiBGQUwuRmFMZWlzdHVuZ0lEID0gU0ZQL" +
                        "kZhTGVpc3R1bmdJRA0KICBMRUZUICBKT0lOIEZhTGVpc3R1bmdBcmNoaXYgIEZGQSBPTiBGRkEuRmFMZ" +
                        "WlzdHVuZ0lEID0gRkFMLkZhTGVpc3R1bmdJRCBBTkQgRkZBLkNoZWNrT3V0IElTIE5VTEwNCiAgSU5OR" +
                        "VIgSk9JTiBYVXNlciAgICAgICAgICAgICBVU1IgT04gVVNSLlVzZXJJRCA9IEZBTC5Vc2VySUQNCiAgS" +
                        "U5ORVIgSk9JTiB2d1BlcnNvbiAgICAgICAgICBQUlMgT04gUFJTLkJhUGVyc29uSUQgPSBGQUwuQmFQZ" +
                        "XJzb25JRA0KV0hFUkUgU0ZQLkJnRmluYW56cGxhbklEID0gbnVsbA==";
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
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.ShDetaillierterFinanzplan_Bewilligungsverfahren = new DevExpress.XtraReports.UI.Subreport();
            this.ShDetaillierterFinanzplan_Vermoegen = new DevExpress.XtraReports.UI.Subreport();
            this.ShDetaillierterFinanzplan_EinkommenAlimente = new DevExpress.XtraReports.UI.Subreport();
            this.ShDetaillierterFinanzplan_EinkommenVersich = new DevExpress.XtraReports.UI.Subreport();
            this.ShDetaillierterFinanzplan_Erwerbseinkommen = new DevExpress.XtraReports.UI.Subreport();
            this.ShDetaillierterFinanzplan_AllgErwerbsunkosten = new DevExpress.XtraReports.UI.Subreport();
            this.ShDetaillierterFinanzplan_Sil = new DevExpress.XtraReports.UI.Subreport();
            this.ShDetaillierterFinanzplan_KvgVvg = new DevExpress.XtraReports.UI.Subreport();
            this.ShDetaillierterFinanzplan_GBMiete = new DevExpress.XtraReports.UI.Subreport();
            this.ShDetaillierterFinanzplan_Uebersicht = new DevExpress.XtraReports.UI.Subreport();
            this.ShDetaillierterFinanzplan_Personen = new DevExpress.XtraReports.UI.Subreport();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtDatumBis = new DevExpress.XtraReports.UI.XRLabel();
            this.txtDatumVon = new DevExpress.XtraReports.UI.XRLabel();
            this.Label3 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGeplantBis = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGeplantVon = new DevExpress.XtraReports.UI.XRLabel();
            this.Label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.FullName1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.txtTitel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtOrgAdresse = new DevExpress.XtraReports.UI.XRLabel();
            this.txtOrgName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.ShDetaillierterFinanzplan_Bewilligungsverfahren,
                        this.ShDetaillierterFinanzplan_Vermoegen,
                        this.ShDetaillierterFinanzplan_EinkommenAlimente,
                        this.ShDetaillierterFinanzplan_EinkommenVersich,
                        this.ShDetaillierterFinanzplan_Erwerbseinkommen,
                        this.ShDetaillierterFinanzplan_AllgErwerbsunkosten,
                        this.ShDetaillierterFinanzplan_Sil,
                        this.ShDetaillierterFinanzplan_KvgVvg,
                        this.ShDetaillierterFinanzplan_GBMiete,
                        this.ShDetaillierterFinanzplan_Uebersicht,
                        this.ShDetaillierterFinanzplan_Personen});
            this.Detail.Height = 316;
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
                        this.xrLabel7,
                        this.xrLabel6,
                        this.xrLabel5,
                        this.xrPageInfo1,
                        this.xrLabel4,
                        this.Label8,
                        this.Label7,
                        this.Label6,
                        this.Label5,
                        this.xrLabel3,
                        this.Label4,
                        this.txtDatumBis,
                        this.txtDatumVon,
                        this.Label3,
                        this.txtGeplantBis,
                        this.txtGeplantVon,
                        this.Label2,
                        this.FullName1,
                        this.TextBox1,
                        this.Line3,
                        this.Line2,
                        this.txtTitel,
                        this.xrLabel1,
                        this.txtOrgAdresse,
                        this.txtOrgName});
            this.ReportHeader.Height = 319;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.ParentStyleUsing.UseBackColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorderColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorders = false;
            this.ReportHeader.ParentStyleUsing.UseBorderWidth = false;
            this.ReportHeader.ParentStyleUsing.UseFont = false;
            this.ReportHeader.ParentStyleUsing.UseForeColor = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Height = 0;
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
                        this.xrPageInfo3,
                        this.xrPageInfo2});
            this.PageFooter.Height = 47;
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
            this.ReportFooter.Height = 0;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // ShDetaillierterFinanzplan_Bewilligungsverfahren
            // 
            this.ShDetaillierterFinanzplan_Bewilligungsverfahren.Location = new System.Drawing.Point(10, 280);
            this.ShDetaillierterFinanzplan_Bewilligungsverfahren.Name = "ShDetaillierterFinanzplan_Bewilligungsverfahren";
            // 
            // ShDetaillierterFinanzplan_Vermoegen
            // 
            this.ShDetaillierterFinanzplan_Vermoegen.Location = new System.Drawing.Point(10, 253);
            this.ShDetaillierterFinanzplan_Vermoegen.Name = "ShDetaillierterFinanzplan_Vermoegen";
            // 
            // ShDetaillierterFinanzplan_EinkommenAlimente
            // 
            this.ShDetaillierterFinanzplan_EinkommenAlimente.Location = new System.Drawing.Point(10, 220);
            this.ShDetaillierterFinanzplan_EinkommenAlimente.Name = "ShDetaillierterFinanzplan_EinkommenAlimente";
            // 
            // ShDetaillierterFinanzplan_EinkommenVersich
            // 
            this.ShDetaillierterFinanzplan_EinkommenVersich.Location = new System.Drawing.Point(10, 193);
            this.ShDetaillierterFinanzplan_EinkommenVersich.Name = "ShDetaillierterFinanzplan_EinkommenVersich";
            // 
            // ShDetaillierterFinanzplan_Erwerbseinkommen
            // 
            this.ShDetaillierterFinanzplan_Erwerbseinkommen.Location = new System.Drawing.Point(10, 167);
            this.ShDetaillierterFinanzplan_Erwerbseinkommen.Name = "ShDetaillierterFinanzplan_Erwerbseinkommen";
            // 
            // ShDetaillierterFinanzplan_AllgErwerbsunkosten
            // 
            this.ShDetaillierterFinanzplan_AllgErwerbsunkosten.Location = new System.Drawing.Point(10, 140);
            this.ShDetaillierterFinanzplan_AllgErwerbsunkosten.Name = "ShDetaillierterFinanzplan_AllgErwerbsunkosten";
            // 
            // ShDetaillierterFinanzplan_Sil
            // 
            this.ShDetaillierterFinanzplan_Sil.Location = new System.Drawing.Point(10, 112);
            this.ShDetaillierterFinanzplan_Sil.Name = "ShDetaillierterFinanzplan_Sil";
            // 
            // ShDetaillierterFinanzplan_KvgVvg
            // 
            this.ShDetaillierterFinanzplan_KvgVvg.Location = new System.Drawing.Point(10, 88);
            this.ShDetaillierterFinanzplan_KvgVvg.Name = "ShDetaillierterFinanzplan_KvgVvg";
            // 
            // ShDetaillierterFinanzplan_GBMiete
            // 
            this.ShDetaillierterFinanzplan_GBMiete.Location = new System.Drawing.Point(10, 60);
            this.ShDetaillierterFinanzplan_GBMiete.Name = "ShDetaillierterFinanzplan_GBMiete";
            // 
            // ShDetaillierterFinanzplan_Uebersicht
            // 
            this.ShDetaillierterFinanzplan_Uebersicht.Location = new System.Drawing.Point(10, 33);
            this.ShDetaillierterFinanzplan_Uebersicht.Name = "ShDetaillierterFinanzplan_Uebersicht";
            // 
            // ShDetaillierterFinanzplan_Personen
            // 
            this.ShDetaillierterFinanzplan_Personen.Location = new System.Drawing.Point(10, 7);
            this.ShDetaillierterFinanzplan_Personen.Name = "ShDetaillierterFinanzplan_Personen";
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Adresse", "")});
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 11F);
            this.xrLabel7.ForeColor = System.Drawing.Color.Black;
            this.xrLabel7.Location = new System.Drawing.Point(447, 71);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseBackColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorders = false;
            this.xrLabel7.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.ParentStyleUsing.UseForeColor = false;
            this.xrLabel7.Size = new System.Drawing.Size(251, 75);
            this.xrLabel7.Text = "xrLabel7";
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bemerkung", "")});
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel6.ForeColor = System.Drawing.Color.Black;
            this.xrLabel6.Location = new System.Drawing.Point(129, 295);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseBackColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorders = false;
            this.xrLabel6.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.ParentStyleUsing.UseForeColor = false;
            this.xrLabel6.Size = new System.Drawing.Size(594, 16);
            this.xrLabel6.Text = "xrLabel6";
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AHVNummer", "")});
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 11F);
            this.xrLabel5.Location = new System.Drawing.Point(300, 216);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(287, 20);
            this.xrLabel5.Text = "xrLabel5";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 10F);
            this.xrPageInfo1.Format = "{0:dd.MM.yyyy}";
            this.xrPageInfo1.Location = new System.Drawing.Point(47, 153);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(100, 20);
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel4.Location = new System.Drawing.Point(7, 153);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(40, 20);
            this.xrLabel4.Text = "Bern,";
            // 
            // Label8
            // 
            this.Label8.Font = new System.Drawing.Font("Arial", 10F);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(333, 255);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(94, 19);
            this.Label8.Text = "(Bewilligt)";
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Arial", 10F);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(333, 240);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(94, 19);
            this.Label7.Text = "(Geplant)";
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 10F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(11, 295);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(94, 19);
            this.Label6.Text = "Bemerkungen";
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial", 10F);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(11, 279);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(94, 19);
            this.Label5.Text = "Status";
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Status", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(129, 279);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(594, 19);
            this.xrLabel3.Text = "Status";
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial", 10F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(204, 255);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(27, 19);
            this.Label4.Text = "bis";
            this.Label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // txtDatumBis
            // 
            this.txtDatumBis.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "DatumBis", "{0:dd.MM.yyyy}")});
            this.txtDatumBis.Font = new System.Drawing.Font("Arial", 10F);
            this.txtDatumBis.ForeColor = System.Drawing.Color.Black;
            this.txtDatumBis.Location = new System.Drawing.Point(232, 255);
            this.txtDatumBis.Multiline = true;
            this.txtDatumBis.Name = "txtDatumBis";
            this.txtDatumBis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtDatumBis.ParentStyleUsing.UseBackColor = false;
            this.txtDatumBis.ParentStyleUsing.UseBorderColor = false;
            this.txtDatumBis.ParentStyleUsing.UseBorders = false;
            this.txtDatumBis.ParentStyleUsing.UseBorderWidth = false;
            this.txtDatumBis.ParentStyleUsing.UseFont = false;
            this.txtDatumBis.ParentStyleUsing.UseForeColor = false;
            this.txtDatumBis.Size = new System.Drawing.Size(74, 19);
            xrSummary1.FormatString = "{0:dd.MM.yyyy}";
            this.txtDatumBis.Summary = xrSummary1;
            this.txtDatumBis.Text = "DatumBis";
            // 
            // txtDatumVon
            // 
            this.txtDatumVon.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "DatumVon", "{0:dd.MM.yyyy}")});
            this.txtDatumVon.Font = new System.Drawing.Font("Arial", 10F);
            this.txtDatumVon.ForeColor = System.Drawing.Color.Black;
            this.txtDatumVon.Location = new System.Drawing.Point(129, 255);
            this.txtDatumVon.Multiline = true;
            this.txtDatumVon.Name = "txtDatumVon";
            this.txtDatumVon.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtDatumVon.ParentStyleUsing.UseBackColor = false;
            this.txtDatumVon.ParentStyleUsing.UseBorderColor = false;
            this.txtDatumVon.ParentStyleUsing.UseBorders = false;
            this.txtDatumVon.ParentStyleUsing.UseBorderWidth = false;
            this.txtDatumVon.ParentStyleUsing.UseFont = false;
            this.txtDatumVon.ParentStyleUsing.UseForeColor = false;
            this.txtDatumVon.Size = new System.Drawing.Size(74, 19);
            xrSummary2.FormatString = "{0:dd.MM.yyyy}";
            this.txtDatumVon.Summary = xrSummary2;
            this.txtDatumVon.Text = "DatumVon";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Arial", 10F);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(204, 240);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(27, 19);
            this.Label3.Text = "bis";
            this.Label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // txtGeplantBis
            // 
            this.txtGeplantBis.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GeplantBis", "{0:dd.MM.yyyy}")});
            this.txtGeplantBis.Font = new System.Drawing.Font("Arial", 10F);
            this.txtGeplantBis.ForeColor = System.Drawing.Color.Black;
            this.txtGeplantBis.Location = new System.Drawing.Point(232, 240);
            this.txtGeplantBis.Multiline = true;
            this.txtGeplantBis.Name = "txtGeplantBis";
            this.txtGeplantBis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGeplantBis.ParentStyleUsing.UseBackColor = false;
            this.txtGeplantBis.ParentStyleUsing.UseBorderColor = false;
            this.txtGeplantBis.ParentStyleUsing.UseBorders = false;
            this.txtGeplantBis.ParentStyleUsing.UseBorderWidth = false;
            this.txtGeplantBis.ParentStyleUsing.UseFont = false;
            this.txtGeplantBis.ParentStyleUsing.UseForeColor = false;
            this.txtGeplantBis.Size = new System.Drawing.Size(74, 19);
            xrSummary3.FormatString = "{0:dd.MM.yyyy}";
            this.txtGeplantBis.Summary = xrSummary3;
            this.txtGeplantBis.Text = "GeplantBis";
            // 
            // txtGeplantVon
            // 
            this.txtGeplantVon.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GeplantVon", "{0:dd.MM.yyyy}")});
            this.txtGeplantVon.Font = new System.Drawing.Font("Arial", 10F);
            this.txtGeplantVon.ForeColor = System.Drawing.Color.Black;
            this.txtGeplantVon.Location = new System.Drawing.Point(129, 240);
            this.txtGeplantVon.Multiline = true;
            this.txtGeplantVon.Name = "txtGeplantVon";
            this.txtGeplantVon.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGeplantVon.ParentStyleUsing.UseBackColor = false;
            this.txtGeplantVon.ParentStyleUsing.UseBorderColor = false;
            this.txtGeplantVon.ParentStyleUsing.UseBorders = false;
            this.txtGeplantVon.ParentStyleUsing.UseBorderWidth = false;
            this.txtGeplantVon.ParentStyleUsing.UseFont = false;
            this.txtGeplantVon.ParentStyleUsing.UseForeColor = false;
            this.txtGeplantVon.Size = new System.Drawing.Size(74, 19);
            xrSummary4.FormatString = "{0:dd.MM.yyyy}";
            this.txtGeplantVon.Summary = xrSummary4;
            this.txtGeplantVon.Text = "GeplantVon";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 10F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(11, 240);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(94, 19);
            this.Label2.Text = "Periode vom";
            // 
            // FullName1
            // 
            this.FullName1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "FullName", "")});
            this.FullName1.Font = new System.Drawing.Font("Arial", 11F);
            this.FullName1.ForeColor = System.Drawing.Color.Black;
            this.FullName1.Location = new System.Drawing.Point(122, 216);
            this.FullName1.Multiline = true;
            this.FullName1.Name = "FullName1";
            this.FullName1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.FullName1.ParentStyleUsing.UseBackColor = false;
            this.FullName1.ParentStyleUsing.UseBorderColor = false;
            this.FullName1.ParentStyleUsing.UseBorders = false;
            this.FullName1.ParentStyleUsing.UseBorderWidth = false;
            this.FullName1.ParentStyleUsing.UseFont = false;
            this.FullName1.ParentStyleUsing.UseForeColor = false;
            this.FullName1.Size = new System.Drawing.Size(180, 19);
            this.FullName1.Text = "FullName";
            // 
            // TextBox1
            // 
            this.TextBox1.Font = new System.Drawing.Font("Arial", 11F);
            this.TextBox1.ForeColor = System.Drawing.Color.Black;
            this.TextBox1.Location = new System.Drawing.Point(12, 215);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox1.ParentStyleUsing.UseBackColor = false;
            this.TextBox1.ParentStyleUsing.UseBorderColor = false;
            this.TextBox1.ParentStyleUsing.UseBorders = false;
            this.TextBox1.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox1.ParentStyleUsing.UseFont = false;
            this.TextBox1.ParentStyleUsing.UseForeColor = false;
            this.TextBox1.Size = new System.Drawing.Size(110, 19);
            this.TextBox1.Text = "Finanzplan von ";
            // 
            // Line3
            // 
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.Location = new System.Drawing.Point(0, 177);
            this.Line3.Name = "Line3";
            this.Line3.ParentStyleUsing.UseBackColor = false;
            this.Line3.ParentStyleUsing.UseBorderColor = false;
            this.Line3.ParentStyleUsing.UseBorders = false;
            this.Line3.ParentStyleUsing.UseBorderWidth = false;
            this.Line3.ParentStyleUsing.UseFont = false;
            this.Line3.ParentStyleUsing.UseForeColor = false;
            this.Line3.Size = new System.Drawing.Size(724, 2);
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.Location = new System.Drawing.Point(0, 211);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(724, 2);
            // 
            // txtTitel
            // 
            this.txtTitel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Titel", "")});
            this.txtTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txtTitel.ForeColor = System.Drawing.Color.Black;
            this.txtTitel.Location = new System.Drawing.Point(0, 185);
            this.txtTitel.Multiline = true;
            this.txtTitel.Name = "txtTitel";
            this.txtTitel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTitel.ParentStyleUsing.UseBackColor = false;
            this.txtTitel.ParentStyleUsing.UseBorderColor = false;
            this.txtTitel.ParentStyleUsing.UseBorders = false;
            this.txtTitel.ParentStyleUsing.UseBorderWidth = false;
            this.txtTitel.ParentStyleUsing.UseFont = false;
            this.txtTitel.ParentStyleUsing.UseForeColor = false;
            this.txtTitel.Size = new System.Drawing.Size(716, 23);
            this.txtTitel.Text = "Titel";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "OrgPLZOrt", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.Location = new System.Drawing.Point(0, 51);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseBackColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.ParentStyleUsing.UseForeColor = false;
            this.xrLabel1.Size = new System.Drawing.Size(183, 19);
            this.xrLabel1.Text = "OrgPLZOrt";
            // 
            // txtOrgAdresse
            // 
            this.txtOrgAdresse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "OrgAdresse", "")});
            this.txtOrgAdresse.Font = new System.Drawing.Font("Arial", 10F);
            this.txtOrgAdresse.ForeColor = System.Drawing.Color.Black;
            this.txtOrgAdresse.Location = new System.Drawing.Point(0, 31);
            this.txtOrgAdresse.Multiline = true;
            this.txtOrgAdresse.Name = "txtOrgAdresse";
            this.txtOrgAdresse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOrgAdresse.ParentStyleUsing.UseBackColor = false;
            this.txtOrgAdresse.ParentStyleUsing.UseBorderColor = false;
            this.txtOrgAdresse.ParentStyleUsing.UseBorders = false;
            this.txtOrgAdresse.ParentStyleUsing.UseBorderWidth = false;
            this.txtOrgAdresse.ParentStyleUsing.UseFont = false;
            this.txtOrgAdresse.ParentStyleUsing.UseForeColor = false;
            this.txtOrgAdresse.Size = new System.Drawing.Size(183, 19);
            this.txtOrgAdresse.Text = "OrgAdresse";
            // 
            // txtOrgName
            // 
            this.txtOrgName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "OrgName", "")});
            this.txtOrgName.Font = new System.Drawing.Font("Arial", 14F);
            this.txtOrgName.ForeColor = System.Drawing.Color.Black;
            this.txtOrgName.Location = new System.Drawing.Point(0, 2);
            this.txtOrgName.Multiline = true;
            this.txtOrgName.Name = "txtOrgName";
            this.txtOrgName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOrgName.ParentStyleUsing.UseBackColor = false;
            this.txtOrgName.ParentStyleUsing.UseBorderColor = false;
            this.txtOrgName.ParentStyleUsing.UseBorders = false;
            this.txtOrgName.ParentStyleUsing.UseBorderWidth = false;
            this.txtOrgName.ParentStyleUsing.UseFont = false;
            this.txtOrgName.ParentStyleUsing.UseForeColor = false;
            this.txtOrgName.Size = new System.Drawing.Size(433, 27);
            this.txtOrgName.Text = "OrgName";
            // 
            // xrPageInfo3
            // 
            this.xrPageInfo3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrPageInfo3.Format = "Bern, {0:dd.MM.yyyy}";
            this.xrPageInfo3.Location = new System.Drawing.Point(21, 20);
            this.xrPageInfo3.Name = "xrPageInfo3";
            this.xrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo3.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo3.ParentStyleUsing.UseFont = false;
            this.xrPageInfo3.Size = new System.Drawing.Size(160, 20);
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrPageInfo2.Format = "Seite {0} von {1}";
            this.xrPageInfo2.Location = new System.Drawing.Point(314, 20);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            this.xrPageInfo2.Size = new System.Drawing.Size(100, 20);
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail,
                        this.ReportHeader,
                        this.PageHeader,
                        this.PageFooter,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(59, 39, 39, 39);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
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
		<Length>15</Length>
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
</NewDataSet>' , SQLquery =  N'---- spsota: 20100318
DECLARE @VornameName_Zusatz VARCHAR(MAX)
SET @VornameName_Zusatz = (SELECT VornameName + char(13) + char(10) FROM vwPerson WHERE BaPersonID = {BaPersonID_Zusatz})

SELECT TOP 1
  [OrgName]      = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Organisation'', Getdate())), ''''),
  [OrgAdresse]   = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Adresse'', Getdate())), ''''),
  [OrgPLZOrt]    = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', Getdate())) + '' '', '''')
                 + IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', Getdate())), ''''),

  [BgFinanzplanID] = SFP.BgFinanzplanID, -- required for subreports
  [BgBudgetID]     = BBG.BgBudgetID, -- required for subreports
  [Titel]        = ''Detaillierte Verfügung '' + LVT.Text, -- LVT.Text = Typ
  [FullName]     = PRS.Name + IsNull('', '' + PRS.Vorname,'''') +  CASE LEN(IsNull(PRS.Vorname2, '''')) WHEN 0 THEN '''' ELSE '' '' + PRS.Vorname2 END,
  [AHVNummer]    = PRS.AHVNummer,
  [Status]       = LVS.Text + CASE WHEN FFA.FaLeistungID IS NOT NULL THEN '' (archiviert)'' ELSE '''' END,
  [IsUrgent]     = LVT.Value2,
  [GeplantVon]   = SFP.GeplantVon,
  [GeplantBis]   = SFP.GeplantBis,
  [DatumVon]     = SFP.DatumVon,
  [DatumBis]     = SFP.DatumBis,
  [Bemerkung]    = SFP.Bemerkung,
  [Anrede]       = CASE PRS.GeschlechtCode WHEN 2 THEN ''Frau'' ELSE ''Herrn'' END,
  [Name]         = PRS.Name,
  [Vorname]      = PRS.Vorname,
  [Strasse]      = PRS.WohnsitzStrasseHausNr,
  [PLZOrt]       = PRS.WohnsitzPLZOrt,
  Adresse        = CASE 
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
                   END

FROM BgFinanzplan              SFP
  INNER JOIN BgBudget          BBG ON BBG.BgFinanzplanID = SFP.BgFinanzplanID AND BBG.MasterBudget = 1
  LEFT  JOIN XLOVCode          LVS ON LVS.LOVName = ''BgBewilligungStatus'' AND LVS.Code = SFP.BgBewilligungStatusCode
  LEFT  JOIN XLOVCode          LVT ON LVT.LOVName = ''WhHilfeTyp'' AND LVT.Code = SFP.WhHilfeTypCode
  INNER JOIN FaLeistung        FAL ON FAL.FaLeistungID = SFP.FaLeistungID
  LEFT  JOIN FaLeistungArchiv  FFA ON FFA.FaLeistungID = FAL.FaLeistungID AND FFA.CheckOut IS NULL
  INNER JOIN XUser             USR ON USR.UserID = FAL.UserID
  INNER JOIN vwPerson          PRS ON PRS.BaPersonID = FAL.BaPersonID
WHERE SFP.BgFinanzplanID = {BgFinanzplanID}' , ContextForms =  N'WhFinanzplan,CtlBgUebersicht,WhMonatsbudget,WhMasterbudget' , ParentReportName =  null , ReportSortKey = 5
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'ShDetaillierterFinanzplan' ;


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShDetaillierterFinanzplan_AllgErwerbsunkosten' ,  N'Allgemeine Erwerbsunkosten' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\log4net.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtBemerkungRTF;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private DevExpress.XtraReports.UI.XRLabel txtGrad;
        private DevExpress.XtraReports.UI.XRLabel txtNamePerson;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRPanel hiderPanel;
        private DevExpress.XtraReports.UI.XRLabel hiderTxtBemerkungRTF;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLine Line4;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLabel txtTotGrad;
        private DevExpress.XtraReports.UI.XRLabel txtTotBetrag;
        private DevExpress.XtraReports.UI.XRLabel Label5;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = @"zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OSNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kAAAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAAAAAAYMEREVDTEFSRSBAQmdCdWRnZXRJRCBpbnQNCg0KU0VMRUNUIEBCZ0J1ZGdldElEID0gQmdCdWRnZXRJRA0KRlJPTSBCZ0J1ZGdldA0KV0hFUkUgQmdGaW5hbnpwbGFuSUQgPSBudWxsIEFORCBNYXN0ZXJCdWRnZXQgPSAxDQoNClNFTEVDVCBCUE8uKiwNCiAgTmFtZVBlcnNvbiAgID0gUFJTLk5hbWUgKyBJc051bGwoJywgJyArIFBSUy5Wb3JuYW1lLCAnJyksDQogIEdlYnVydHNkYXR1bSA9IENPTlZFUlQodmFyY2hhciwgUFJTLkdlYnVydHNkYXR1bSwgMTA0KSwNCiAgR3JhZCAgICAgICAgID0gQ0FTVCgxMDAgKiBCUE8uQmV0cmFnIC8gQlBPLk1heEJlaXRyYWdTRCBBUyBpbnQpDQpGUk9NIEJnUG9zaXRpb24gICAgICAgIEJQTw0KICBMRUZUICBKT0lOIEJhUGVyc29uICBQUlMgT04gUFJTLkJhUGVyc29uSUQgPSBCUE8uQmFQZXJzb25JRA0KV0hFUkUgQlBPLkJnQnVkZ2V0SUQgPSBAQmdCdWRnZXRJRCBBTkQgQlBPLkJnUG9zaXRpb25zYXJ0SUQgPSAzMjAzMQ0KICBBTkQgQlBPLkRhdHVtVm9uIElTIE5VTEw=";
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
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.txtBemerkungRTF = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGrad = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNamePerson = new DevExpress.XtraReports.UI.XRLabel();
            this.hiderPanel = new DevExpress.XtraReports.UI.XRPanel();
            this.hiderTxtBemerkungRTF = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line4 = new DevExpress.XtraReports.UI.XRLine();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.txtTotGrad = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTotBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.Label5 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtBemerkungRTF,
                        this.txtBetrag,
                        this.txtGrad,
                        this.txtNamePerson});
            this.Detail.Height = 34;
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
                        this.hiderPanel});
            this.PageHeader.Height = 40;
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
                        this.xrLabel2,
                        this.xrLine1,
                        this.xrLabel4,
                        this.xrLabel3,
                        this.xrLabel1});
            this.GroupHeader1.Font = new System.Drawing.Font("Arial", 10F);
            this.GroupHeader1.Height = 70;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Line4,
                        this.Line3,
                        this.Line2,
                        this.txtTotGrad,
                        this.txtTotBetrag,
                        this.Label5});
            this.GroupFooter1.Height = 60;
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
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // txtBemerkungRTF
            // 
            this.txtBemerkungRTF.CanShrink = true;
            this.txtBemerkungRTF.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bemerkung", "")});
            this.txtBemerkungRTF.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.txtBemerkungRTF.ForeColor = System.Drawing.Color.Black;
            this.txtBemerkungRTF.Location = new System.Drawing.Point(7, 15);
            this.txtBemerkungRTF.Multiline = true;
            this.txtBemerkungRTF.Name = "txtBemerkungRTF";
            this.txtBemerkungRTF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBemerkungRTF.ParentStyleUsing.UseBackColor = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorderColor = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorders = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorderWidth = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseFont = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseForeColor = false;
            this.txtBemerkungRTF.Size = new System.Drawing.Size(693, 19);
            this.txtBemerkungRTF.Text = "txtBemerkungRTF";
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(620, 0);
            this.txtBetrag.Multiline = true;
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(78, 19);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtBetrag.Summary = xrSummary1;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtGrad
            // 
            this.txtGrad.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Grad", "{0}%")});
            this.txtGrad.Font = new System.Drawing.Font("Arial", 10F);
            this.txtGrad.ForeColor = System.Drawing.Color.Black;
            this.txtGrad.Location = new System.Drawing.Point(500, 0);
            this.txtGrad.Multiline = true;
            this.txtGrad.Name = "txtGrad";
            this.txtGrad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGrad.ParentStyleUsing.UseBackColor = false;
            this.txtGrad.ParentStyleUsing.UseBorderColor = false;
            this.txtGrad.ParentStyleUsing.UseBorders = false;
            this.txtGrad.ParentStyleUsing.UseBorderWidth = false;
            this.txtGrad.ParentStyleUsing.UseFont = false;
            this.txtGrad.ParentStyleUsing.UseForeColor = false;
            this.txtGrad.Size = new System.Drawing.Size(78, 19);
            xrSummary2.FormatString = "{0:0\\%}";
            this.txtGrad.Summary = xrSummary2;
            this.txtGrad.Text = "Grad";
            this.txtGrad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtNamePerson
            // 
            this.txtNamePerson.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NamePerson", "")});
            this.txtNamePerson.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNamePerson.ForeColor = System.Drawing.Color.Black;
            this.txtNamePerson.Location = new System.Drawing.Point(7, 0);
            this.txtNamePerson.Multiline = true;
            this.txtNamePerson.Name = "txtNamePerson";
            this.txtNamePerson.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNamePerson.ParentStyleUsing.UseBackColor = false;
            this.txtNamePerson.ParentStyleUsing.UseBorderColor = false;
            this.txtNamePerson.ParentStyleUsing.UseBorders = false;
            this.txtNamePerson.ParentStyleUsing.UseBorderWidth = false;
            this.txtNamePerson.ParentStyleUsing.UseFont = false;
            this.txtNamePerson.ParentStyleUsing.UseForeColor = false;
            this.txtNamePerson.Size = new System.Drawing.Size(486, 19);
            this.txtNamePerson.Text = "NamePerson";
            // 
            // hiderPanel
            // 
            this.hiderPanel.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.hiderTxtBemerkungRTF});
            this.hiderPanel.Location = new System.Drawing.Point(393, 0);
            this.hiderPanel.Name = "hiderPanel";
            this.hiderPanel.Size = new System.Drawing.Size(300, 40);
            this.hiderPanel.Visible = false;
            // 
            // hiderTxtBemerkungRTF
            // 
            this.hiderTxtBemerkungRTF.Location = new System.Drawing.Point(20, 0);
            this.hiderTxtBemerkungRTF.Name = "hiderTxtBemerkungRTF";
            this.hiderTxtBemerkungRTF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hiderTxtBemerkungRTF.Scripts.OnAfterPrint = "private void OnAfterPrint(object sender, System.EventArgs e) {\r\n  \r\ntxtBemerkungR" +
                "TF.Visible = hiderTxtBemerkungRTF.Text != String.Empty;\r\n}";
            this.hiderTxtBemerkungRTF.Size = new System.Drawing.Size(100, 20);
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel2.Location = new System.Drawing.Point(7, 40);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(100, 20);
            this.xrLabel2.Text = "Betrifft";
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.Location = new System.Drawing.Point(7, 67);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(686, 3);
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel4.Location = new System.Drawing.Point(593, 40);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(100, 20);
            this.xrLabel4.Text = "Betrag";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel3.Location = new System.Drawing.Point(353, 40);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(227, 27);
            this.xrLabel3.Text = "Prozentuale Arbeitsauslastung";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.xrLabel1.Location = new System.Drawing.Point(0, 0);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(227, 27);
            this.xrLabel1.Text = "Allgemeine Erwerbsunkosten";
            // 
            // Line4
            // 
            this.Line4.ForeColor = System.Drawing.Color.Black;
            this.Line4.Location = new System.Drawing.Point(527, 27);
            this.Line4.Name = "Line4";
            this.Line4.ParentStyleUsing.UseBackColor = false;
            this.Line4.ParentStyleUsing.UseBorderColor = false;
            this.Line4.ParentStyleUsing.UseBorders = false;
            this.Line4.ParentStyleUsing.UseBorderWidth = false;
            this.Line4.ParentStyleUsing.UseFont = false;
            this.Line4.ParentStyleUsing.UseForeColor = false;
            this.Line4.Size = new System.Drawing.Size(173, 2);
            // 
            // Line3
            // 
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.Location = new System.Drawing.Point(527, 23);
            this.Line3.Name = "Line3";
            this.Line3.ParentStyleUsing.UseBackColor = false;
            this.Line3.ParentStyleUsing.UseBorderColor = false;
            this.Line3.ParentStyleUsing.UseBorders = false;
            this.Line3.ParentStyleUsing.UseBorderWidth = false;
            this.Line3.ParentStyleUsing.UseFont = false;
            this.Line3.ParentStyleUsing.UseForeColor = false;
            this.Line3.Size = new System.Drawing.Size(173, 2);
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.Location = new System.Drawing.Point(7, 0);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(686, 3);
            // 
            // txtTotGrad
            // 
            this.txtTotGrad.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Grad", "{0}")});
            this.txtTotGrad.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.txtTotGrad.ForeColor = System.Drawing.Color.Black;
            this.txtTotGrad.Location = new System.Drawing.Point(500, 3);
            this.txtTotGrad.Multiline = true;
            this.txtTotGrad.Name = "txtTotGrad";
            this.txtTotGrad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTotGrad.ParentStyleUsing.UseBackColor = false;
            this.txtTotGrad.ParentStyleUsing.UseBorderColor = false;
            this.txtTotGrad.ParentStyleUsing.UseBorders = false;
            this.txtTotGrad.ParentStyleUsing.UseBorderWidth = false;
            this.txtTotGrad.ParentStyleUsing.UseFont = false;
            this.txtTotGrad.ParentStyleUsing.UseForeColor = false;
            this.txtTotGrad.Size = new System.Drawing.Size(78, 19);
            xrSummary3.FormatString = "{0}%";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.txtTotGrad.Summary = xrSummary3;
            this.txtTotGrad.Text = "txtTotGrad";
            this.txtTotGrad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtTotBetrag
            // 
            this.txtTotBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "")});
            this.txtTotBetrag.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.txtTotBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtTotBetrag.Location = new System.Drawing.Point(620, 3);
            this.txtTotBetrag.Multiline = true;
            this.txtTotBetrag.Name = "txtTotBetrag";
            this.txtTotBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTotBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtTotBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtTotBetrag.ParentStyleUsing.UseBorders = false;
            this.txtTotBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtTotBetrag.ParentStyleUsing.UseFont = false;
            this.txtTotBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtTotBetrag.Size = new System.Drawing.Size(78, 19);
            xrSummary4.FormatString = "{0:n2}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.txtTotBetrag.Summary = xrSummary4;
            this.txtTotBetrag.Text = "txtTotBetrag";
            this.txtTotBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(80, 3);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(425, 19);
            this.Label5.Text = "Gesamte allgemeine Erwerbsunkosten";
            this.Label5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
                        this.GroupFooter1,
                        this.PageFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(39, 42, 39, 39);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'DECLARE @BgBudgetID int

SELECT @BgBudgetID = BgBudgetID
FROM BgBudget
WHERE BgFinanzplanID = {BgFinanzplanID} AND MasterBudget = 1

SELECT BPO.*,
  NamePerson   = PRS.Name + IsNull('', '' + PRS.Vorname, ''''),
  Geburtsdatum = CONVERT(varchar, PRS.Geburtsdatum, 104),
  Grad         = CAST(100 * BPO.Betrag / BPO.MaxBeitragSD AS int)
FROM BgPosition        BPO
  INNER JOIN BgPositionsart POA ON POA.BgPositionsartID = BPO.BgPositionsartID
  LEFT  JOIN BaPerson  PRS ON PRS.BaPersonID = BPO.BaPersonID
WHERE BPO.BgBudgetID = @BgBudgetID AND POA.BgPositionsartCode = 32031
  AND BPO.DatumVon IS NULL' ,  null ,  N'ShDetaillierterFinanzplan' ,  null );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShDetaillierterFinanzplan_Bewilligungsverfahren' ,  N'Bewilligungsverfahren' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\log4net.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtEmpfaenger;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtAbsender;
        private DevExpress.XtraReports.UI.XRLabel txtVorgang;
        private DevExpress.XtraReports.UI.XRLabel txtDatum;
        private DevExpress.XtraReports.UI.XRLabel txtBemerkungRTF;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRPanel hiderPanel;
        private DevExpress.XtraReports.UI.XRLabel hiderTxtBemerkungRTF;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel Label5;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel Label2;
        private DevExpress.XtraReports.UI.XRLabel Label1;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLine Line5;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = @"zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OSNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kAAAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAAAAAAcoDU0VMRUNUIEJCVy4qLA0KICBBYnNlbmRlciAgID0gQUJTLkxhc3ROYW1lICsgSXNOdWxsKCcsICcgKyBBQlMuRmlyc3ROYW1lLCAnJyksDQogIEVtcGZhZW5nZXIgPSBFTVAuTGFzdE5hbWUgKyBJc051bGwoJywgJyArIEVNUC5GaXJzdE5hbWUsICcnKSwNCiAgVm9yZ2FuZyAgICA9IExPVi5UZXh0DQpGUk9NIEJnQmV3aWxsaWd1bmcgICAgQkJXDQogIElOTkVSIEpPSU4gWFVzZXIgICAgQUJTICAgT04gQUJTLlVzZXJJRCA9IEJCVy5Vc2VySUQNCiAgTEVGVCAgSk9JTiBYVXNlciAgICBFTVAgICBPTiBFTVAuVXNlcklEID0gQkJXLlVzZXJJRF9Bbg0KICBJTk5FUiBKT0lOIFhMT1ZDb2RlIExPViBPTiBMT1YuTE9WTmFtZT0nQmdCZXdpbGxpZ3VuZycgQU5EIExPVi5Db2RlID0gQkJXLkJnQmV3aWxsaWd1bmdDb2RlDQpXSEVSRSBCQlcuQmdGaW5hbnpwbGFuSUQgPSBudWxsDQpPUkRFUiBCWSBCQlcuRGF0dW0=";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.txtEmpfaenger = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAbsender = new DevExpress.XtraReports.UI.XRLabel();
            this.txtVorgang = new DevExpress.XtraReports.UI.XRLabel();
            this.txtDatum = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBemerkungRTF = new DevExpress.XtraReports.UI.XRLabel();
            this.hiderPanel = new DevExpress.XtraReports.UI.XRPanel();
            this.hiderTxtBemerkungRTF = new DevExpress.XtraReports.UI.XRLabel();
            this.Label5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.Label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line5 = new DevExpress.XtraReports.UI.XRLine();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtEmpfaenger,
                        this.txtAbsender,
                        this.txtVorgang,
                        this.txtDatum,
                        this.txtBemerkungRTF});
            this.Detail.Height = 34;
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
                        this.hiderPanel});
            this.PageHeader.Height = 75;
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
                        this.Label5,
                        this.Line1,
                        this.Label2,
                        this.Label1,
                        this.Label6,
                        this.Label7});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("SilTypName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 70;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Line5});
            this.GroupFooter1.Height = 20;
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
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // txtEmpfaenger
            // 
            this.txtEmpfaenger.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Empfaenger", "")});
            this.txtEmpfaenger.Font = new System.Drawing.Font("Arial", 10F);
            this.txtEmpfaenger.ForeColor = System.Drawing.Color.Black;
            this.txtEmpfaenger.Location = new System.Drawing.Point(540, 0);
            this.txtEmpfaenger.Multiline = true;
            this.txtEmpfaenger.Name = "txtEmpfaenger";
            this.txtEmpfaenger.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtEmpfaenger.ParentStyleUsing.UseBackColor = false;
            this.txtEmpfaenger.ParentStyleUsing.UseBorderColor = false;
            this.txtEmpfaenger.ParentStyleUsing.UseBorders = false;
            this.txtEmpfaenger.ParentStyleUsing.UseBorderWidth = false;
            this.txtEmpfaenger.ParentStyleUsing.UseFont = false;
            this.txtEmpfaenger.ParentStyleUsing.UseForeColor = false;
            this.txtEmpfaenger.Size = new System.Drawing.Size(167, 19);
            this.txtEmpfaenger.Text = "Empfaenger";
            // 
            // txtAbsender
            // 
            this.txtAbsender.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Absender", "")});
            this.txtAbsender.Font = new System.Drawing.Font("Arial", 10F);
            this.txtAbsender.ForeColor = System.Drawing.Color.Black;
            this.txtAbsender.Location = new System.Drawing.Point(354, 0);
            this.txtAbsender.Multiline = true;
            this.txtAbsender.Name = "txtAbsender";
            this.txtAbsender.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtAbsender.ParentStyleUsing.UseBackColor = false;
            this.txtAbsender.ParentStyleUsing.UseBorderColor = false;
            this.txtAbsender.ParentStyleUsing.UseBorders = false;
            this.txtAbsender.ParentStyleUsing.UseBorderWidth = false;
            this.txtAbsender.ParentStyleUsing.UseFont = false;
            this.txtAbsender.ParentStyleUsing.UseForeColor = false;
            this.txtAbsender.Size = new System.Drawing.Size(180, 19);
            this.txtAbsender.Text = "Absender";
            // 
            // txtVorgang
            // 
            this.txtVorgang.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Vorgang", "")});
            this.txtVorgang.Font = new System.Drawing.Font("Arial", 10F);
            this.txtVorgang.ForeColor = System.Drawing.Color.Black;
            this.txtVorgang.Location = new System.Drawing.Point(125, 0);
            this.txtVorgang.Multiline = true;
            this.txtVorgang.Name = "txtVorgang";
            this.txtVorgang.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtVorgang.ParentStyleUsing.UseBackColor = false;
            this.txtVorgang.ParentStyleUsing.UseBorderColor = false;
            this.txtVorgang.ParentStyleUsing.UseBorders = false;
            this.txtVorgang.ParentStyleUsing.UseBorderWidth = false;
            this.txtVorgang.ParentStyleUsing.UseFont = false;
            this.txtVorgang.ParentStyleUsing.UseForeColor = false;
            this.txtVorgang.Size = new System.Drawing.Size(228, 19);
            this.txtVorgang.Text = "Vorgang";
            // 
            // txtDatum
            // 
            this.txtDatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Datum", "{0:dd.MM.yyyy}")});
            this.txtDatum.Font = new System.Drawing.Font("Arial", 10F);
            this.txtDatum.ForeColor = System.Drawing.Color.Black;
            this.txtDatum.Location = new System.Drawing.Point(7, 0);
            this.txtDatum.Multiline = true;
            this.txtDatum.Name = "txtDatum";
            this.txtDatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtDatum.ParentStyleUsing.UseBackColor = false;
            this.txtDatum.ParentStyleUsing.UseBorderColor = false;
            this.txtDatum.ParentStyleUsing.UseBorders = false;
            this.txtDatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtDatum.ParentStyleUsing.UseFont = false;
            this.txtDatum.ParentStyleUsing.UseForeColor = false;
            this.txtDatum.Size = new System.Drawing.Size(118, 19);
            xrSummary1.FormatString = "{0:dd.MM.yyyy}";
            this.txtDatum.Summary = xrSummary1;
            this.txtDatum.Text = "Datum";
            // 
            // txtBemerkungRTF
            // 
            this.txtBemerkungRTF.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bemerkung", "")});
            this.txtBemerkungRTF.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.txtBemerkungRTF.ForeColor = System.Drawing.Color.Black;
            this.txtBemerkungRTF.Location = new System.Drawing.Point(7, 15);
            this.txtBemerkungRTF.Multiline = true;
            this.txtBemerkungRTF.Name = "txtBemerkungRTF";
            this.txtBemerkungRTF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBemerkungRTF.ParentStyleUsing.UseBackColor = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorderColor = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorders = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorderWidth = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseFont = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseForeColor = false;
            this.txtBemerkungRTF.Size = new System.Drawing.Size(693, 19);
            this.txtBemerkungRTF.Text = "txtBemerkungRTF";
            // 
            // hiderPanel
            // 
            this.hiderPanel.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.hiderTxtBemerkungRTF});
            this.hiderPanel.Location = new System.Drawing.Point(173, 0);
            this.hiderPanel.Name = "hiderPanel";
            this.hiderPanel.Size = new System.Drawing.Size(300, 74);
            this.hiderPanel.Visible = false;
            // 
            // hiderTxtBemerkungRTF
            // 
            this.hiderTxtBemerkungRTF.Location = new System.Drawing.Point(53, 13);
            this.hiderTxtBemerkungRTF.Name = "hiderTxtBemerkungRTF";
            this.hiderTxtBemerkungRTF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hiderTxtBemerkungRTF.Scripts.OnAfterPrint = "private void OnAfterPrint(object sender, System.EventArgs e) {\r\n   txtBemerkungRT" +
                "F.Visible = hiderTxtBemerkungRTF.Text != String.Empty;\r\n}";
            this.hiderTxtBemerkungRTF.Size = new System.Drawing.Size(100, 20);
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(0, 0);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(366, 19);
            this.Label5.Text = "Bewilligungsverfahren";
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.Location = new System.Drawing.Point(7, 47);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(700, 2);
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 10F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(125, 27);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(228, 19);
            this.Label2.Text = "Vorgang";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 10F);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(7, 27);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(118, 19);
            this.Label1.Text = "Datum";
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 10F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(354, 27);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(180, 19);
            this.Label6.Text = "Veranlasst durch";
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Arial", 10F);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(540, 27);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(167, 19);
            this.Label7.Text = "Mitteilung an";
            // 
            // Line5
            // 
            this.Line5.ForeColor = System.Drawing.Color.Black;
            this.Line5.Location = new System.Drawing.Point(7, 0);
            this.Line5.Name = "Line5";
            this.Line5.ParentStyleUsing.UseBackColor = false;
            this.Line5.ParentStyleUsing.UseBorderColor = false;
            this.Line5.ParentStyleUsing.UseBorders = false;
            this.Line5.ParentStyleUsing.UseBorderWidth = false;
            this.Line5.ParentStyleUsing.UseFont = false;
            this.Line5.ParentStyleUsing.UseForeColor = false;
            this.Line5.Size = new System.Drawing.Size(700, 2);
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
                        this.GroupFooter1,
                        this.PageFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(39, 76, 39, 39);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'SELECT BBW.*,
  Absender   = ABS.LastName + IsNull('', '' + ABS.FirstName, ''''),
  Empfaenger = EMP.LastName + IsNull('', '' + EMP.FirstName, ''''),
  Vorgang    = LOV.Text
FROM BgBewilligung    BBW
  INNER JOIN XUser    ABS   ON ABS.UserID = BBW.UserID
  LEFT  JOIN XUser    EMP   ON EMP.UserID = BBW.UserID_An
  INNER JOIN XLOVCode LOV ON LOV.LOVName=''BgBewilligung'' AND LOV.Code = BBW.BgBewilligungCode
WHERE BBW.BgFinanzplanID = {BgFinanzplanID}
ORDER BY BBW.Datum' ,  null ,  N'ShDetaillierterFinanzplan' ,  null );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShDetaillierterFinanzplan_EinkommenAlimente' ,  N'Einkommen aus Alimenten' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\log4net.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtAlimentenTyp;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtBewertungAls;
        private DevExpress.XtraReports.UI.XRLabel txtVerwaltungDurch;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private DevExpress.XtraReports.UI.XRLabel txtNamePerson;
        private DevExpress.XtraReports.UI.XRLabel txtBemerkungRTF;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRPanel hiderPanel;
        private DevExpress.XtraReports.UI.XRLabel hiderTxtBemerkungRTF;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel Label5;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel Label3;
        private DevExpress.XtraReports.UI.XRLabel Label2;
        private DevExpress.XtraReports.UI.XRLabel Label1;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel Label8;
        private DevExpress.XtraReports.UI.XRLine Line5;
        private DevExpress.XtraReports.UI.XRLine Line4;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLabel totEinkommen;
        private DevExpress.XtraReports.UI.XRLabel totBetrag;
        private DevExpress.XtraReports.UI.XRLabel TextBox1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = @"zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OSNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kAAAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAAAAAAZ0GREVDTEFSRSBAQmdCdWRnZXRJRCBpbnQNCg0KU0VMRUNUIEBCZ0J1ZGdldElEID0gQmdCdWRnZXRJRA0KRlJPTSBCZ0J1ZGdldA0KV0hFUkUgQmdGaW5hbnpwbGFuSUQgPSBudWxsIEFORCBNYXN0ZXJCdWRnZXQgPSAxDQoNClNFTEVDVCBCUE8uKiwNCiAgTmFtZVBlcnNvbiAgICAgICAgID0gUFJTLk5hbWUgKyBJc051bGwoJywgJyArIFBSUy5Wb3JuYW1lLCAnJyksDQogIEFsaW1lbnRlblR5cCAgICAgICA9IFNQVC5OYW1lLA0KICBWZXJ3YWx0dW5nRHVyY2ggICAgPSBDQVNFIFdIRU4gQlBPLlZlcndhbHR1bmdTRCA9IDAgVEhFTiAnS2xpZW50JyBFTFNFICdJbmthc3NvZGllbnN0JyBFTkQsDQogIEJld2VydHVuZ0FscyAgICAgICA9IENBU0UgV0hFTiBCUE8uVmVyd2FsdHVuZ1NEID0gMCBUSEVOICdVbnRlcnN0w7x0enVuZycgRUxTRSAnRWlua29tbWVuJyBFTkQsDQogIEJldHJhZ0Fsc0VpbmtvbW1lbiA9IENBU0UgV0hFTiBCUE8uVmVyd2FsdHVuZ1NEID0gMCBUSEVOICQwLjAwIEVMU0UgQlBPLkJldHJhZyBFTkQNCkZST00gQmdQb3NpdGlvbiAgICAgICAgICAgICAgQlBPDQogIElOTkVSIEpPSU4gV2hQb3NpdGlvbnNhcnQgIFNQVCBPTiBTUFQuQmdQb3NpdGlvbnNhcnRJRCA9IEJQTy5CZ1Bvc2l0aW9uc2FydElEDQogIExFRlQgIEpPSU4gQmFQZXJzb24gICAgICAgIFBSUyBPTiBQUlMuQmFQZXJzb25JRCA9IEJQTy5CYVBlcnNvbklEDQpXSEVSRSBCUE8uQmdCdWRnZXRJRCA9IEBCZ0J1ZGdldElEIEFORCBTUFQuQmdHcnVwcGVDb2RlID0gMzEwMg0KICBBTkQgQlBPLkRhdHVtVm9uIElTIE5VTEw=";
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
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.txtAlimentenTyp = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBewertungAls = new DevExpress.XtraReports.UI.XRLabel();
            this.txtVerwaltungDurch = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNamePerson = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBemerkungRTF = new DevExpress.XtraReports.UI.XRLabel();
            this.hiderPanel = new DevExpress.XtraReports.UI.XRPanel();
            this.hiderTxtBemerkungRTF = new DevExpress.XtraReports.UI.XRLabel();
            this.Label5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.Label3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line5 = new DevExpress.XtraReports.UI.XRLine();
            this.Line4 = new DevExpress.XtraReports.UI.XRLine();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.totEinkommen = new DevExpress.XtraReports.UI.XRLabel();
            this.totBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox1 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtAlimentenTyp,
                        this.txtBewertungAls,
                        this.txtVerwaltungDurch,
                        this.txtBetrag,
                        this.txtNamePerson,
                        this.txtBemerkungRTF});
            this.Detail.Height = 40;
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
                        this.hiderPanel});
            this.PageHeader.Height = 40;
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
                        this.Label5,
                        this.Line1,
                        this.Label3,
                        this.Label2,
                        this.Label1,
                        this.Label6,
                        this.Label7});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("SilTypName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 70;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Label8,
                        this.Line5,
                        this.Line4,
                        this.Line3,
                        this.totEinkommen,
                        this.totBetrag,
                        this.TextBox1});
            this.GroupFooter1.Height = 78;
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
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // txtAlimentenTyp
            // 
            this.txtAlimentenTyp.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AlimentenTyp", "")});
            this.txtAlimentenTyp.Font = new System.Drawing.Font("Arial", 10F);
            this.txtAlimentenTyp.ForeColor = System.Drawing.Color.Black;
            this.txtAlimentenTyp.Location = new System.Drawing.Point(216, 0);
            this.txtAlimentenTyp.Name = "txtAlimentenTyp";
            this.txtAlimentenTyp.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtAlimentenTyp.ParentStyleUsing.UseBackColor = false;
            this.txtAlimentenTyp.ParentStyleUsing.UseBorderColor = false;
            this.txtAlimentenTyp.ParentStyleUsing.UseBorders = false;
            this.txtAlimentenTyp.ParentStyleUsing.UseBorderWidth = false;
            this.txtAlimentenTyp.ParentStyleUsing.UseFont = false;
            this.txtAlimentenTyp.ParentStyleUsing.UseForeColor = false;
            this.txtAlimentenTyp.Size = new System.Drawing.Size(226, 19);
            this.txtAlimentenTyp.Text = "AlimentenTyp";
            this.txtAlimentenTyp.WordWrap = false;
            // 
            // txtBewertungAls
            // 
            this.txtBewertungAls.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BewertungAls", "")});
            this.txtBewertungAls.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBewertungAls.ForeColor = System.Drawing.Color.Black;
            this.txtBewertungAls.Location = new System.Drawing.Point(540, 0);
            this.txtBewertungAls.Multiline = true;
            this.txtBewertungAls.Name = "txtBewertungAls";
            this.txtBewertungAls.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBewertungAls.ParentStyleUsing.UseBackColor = false;
            this.txtBewertungAls.ParentStyleUsing.UseBorderColor = false;
            this.txtBewertungAls.ParentStyleUsing.UseBorders = false;
            this.txtBewertungAls.ParentStyleUsing.UseBorderWidth = false;
            this.txtBewertungAls.ParentStyleUsing.UseFont = false;
            this.txtBewertungAls.ParentStyleUsing.UseForeColor = false;
            this.txtBewertungAls.Size = new System.Drawing.Size(86, 19);
            this.txtBewertungAls.Text = "BewertungAls";
            // 
            // txtVerwaltungDurch
            // 
            this.txtVerwaltungDurch.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VerwaltungDurch", "")});
            this.txtVerwaltungDurch.Font = new System.Drawing.Font("Arial", 10F);
            this.txtVerwaltungDurch.ForeColor = System.Drawing.Color.Black;
            this.txtVerwaltungDurch.Location = new System.Drawing.Point(440, 0);
            this.txtVerwaltungDurch.Multiline = true;
            this.txtVerwaltungDurch.Name = "txtVerwaltungDurch";
            this.txtVerwaltungDurch.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtVerwaltungDurch.ParentStyleUsing.UseBackColor = false;
            this.txtVerwaltungDurch.ParentStyleUsing.UseBorderColor = false;
            this.txtVerwaltungDurch.ParentStyleUsing.UseBorders = false;
            this.txtVerwaltungDurch.ParentStyleUsing.UseBorderWidth = false;
            this.txtVerwaltungDurch.ParentStyleUsing.UseFont = false;
            this.txtVerwaltungDurch.ParentStyleUsing.UseForeColor = false;
            this.txtVerwaltungDurch.Size = new System.Drawing.Size(94, 19);
            this.txtVerwaltungDurch.Text = "VerwaltungDurch";
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(627, 0);
            this.txtBetrag.Multiline = true;
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(78, 19);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtBetrag.Summary = xrSummary1;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtNamePerson
            // 
            this.txtNamePerson.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NamePerson", "")});
            this.txtNamePerson.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNamePerson.ForeColor = System.Drawing.Color.Black;
            this.txtNamePerson.Location = new System.Drawing.Point(7, 0);
            this.txtNamePerson.Multiline = true;
            this.txtNamePerson.Name = "txtNamePerson";
            this.txtNamePerson.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNamePerson.ParentStyleUsing.UseBackColor = false;
            this.txtNamePerson.ParentStyleUsing.UseBorderColor = false;
            this.txtNamePerson.ParentStyleUsing.UseBorders = false;
            this.txtNamePerson.ParentStyleUsing.UseBorderWidth = false;
            this.txtNamePerson.ParentStyleUsing.UseFont = false;
            this.txtNamePerson.ParentStyleUsing.UseForeColor = false;
            this.txtNamePerson.Size = new System.Drawing.Size(208, 19);
            this.txtNamePerson.Text = "NamePerson";
            // 
            // txtBemerkungRTF
            // 
            this.txtBemerkungRTF.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bemerkung", "")});
            this.txtBemerkungRTF.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.txtBemerkungRTF.ForeColor = System.Drawing.Color.Black;
            this.txtBemerkungRTF.Location = new System.Drawing.Point(7, 15);
            this.txtBemerkungRTF.Multiline = true;
            this.txtBemerkungRTF.Name = "txtBemerkungRTF";
            this.txtBemerkungRTF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBemerkungRTF.ParentStyleUsing.UseBackColor = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorderColor = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorders = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorderWidth = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseFont = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseForeColor = false;
            this.txtBemerkungRTF.Size = new System.Drawing.Size(693, 19);
            this.txtBemerkungRTF.Text = "txtBemerkungRTF";
            // 
            // hiderPanel
            // 
            this.hiderPanel.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.hiderTxtBemerkungRTF});
            this.hiderPanel.Location = new System.Drawing.Point(167, 0);
            this.hiderPanel.Name = "hiderPanel";
            this.hiderPanel.Size = new System.Drawing.Size(300, 40);
            this.hiderPanel.Visible = false;
            // 
            // hiderTxtBemerkungRTF
            // 
            this.hiderTxtBemerkungRTF.Location = new System.Drawing.Point(47, 7);
            this.hiderTxtBemerkungRTF.Name = "hiderTxtBemerkungRTF";
            this.hiderTxtBemerkungRTF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hiderTxtBemerkungRTF.Scripts.OnAfterPrint = "private void OnAfterPrint(object sender, System.EventArgs e) {\r\n    txtBemerkungR" +
                "TF.Visible = hiderTxtBemerkungRTF.Text != String.Empty;\r\n}";
            this.hiderTxtBemerkungRTF.Size = new System.Drawing.Size(100, 26);
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(0, 0);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(366, 19);
            this.Label5.Text = "Einkommen aus Alimenteguthaben";
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.Location = new System.Drawing.Point(7, 47);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(700, 2);
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Arial", 10F);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(627, 27);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(78, 19);
            this.Label3.Text = "Betrag";
            this.Label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 10F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(216, 27);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(226, 19);
            this.Label2.Text = "Art des Alimenteguthabens";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 10F);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(7, 27);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(208, 19);
            this.Label1.Text = "Betrifft";
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 10F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(440, 27);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(94, 19);
            this.Label6.Text = "Inkasso durch";
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Arial", 10F);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(540, 27);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(86, 19);
            this.Label7.Text = "Bewertet als";
            // 
            // Label8
            // 
            this.Label8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(360, 3);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(251, 19);
            this.Label8.Text = "Gesamtes Alimenteguthaben";
            this.Label8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line5
            // 
            this.Line5.ForeColor = System.Drawing.Color.Black;
            this.Line5.Location = new System.Drawing.Point(7, 0);
            this.Line5.Name = "Line5";
            this.Line5.ParentStyleUsing.UseBackColor = false;
            this.Line5.ParentStyleUsing.UseBorderColor = false;
            this.Line5.ParentStyleUsing.UseBorders = false;
            this.Line5.ParentStyleUsing.UseBorderWidth = false;
            this.Line5.ParentStyleUsing.UseFont = false;
            this.Line5.ParentStyleUsing.UseForeColor = false;
            this.Line5.Size = new System.Drawing.Size(700, 2);
            // 
            // Line4
            // 
            this.Line4.ForeColor = System.Drawing.Color.Black;
            this.Line4.Location = new System.Drawing.Point(627, 54);
            this.Line4.Name = "Line4";
            this.Line4.ParentStyleUsing.UseBackColor = false;
            this.Line4.ParentStyleUsing.UseBorderColor = false;
            this.Line4.ParentStyleUsing.UseBorders = false;
            this.Line4.ParentStyleUsing.UseBorderWidth = false;
            this.Line4.ParentStyleUsing.UseFont = false;
            this.Line4.ParentStyleUsing.UseForeColor = false;
            this.Line4.Size = new System.Drawing.Size(78, 2);
            // 
            // Line3
            // 
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.Location = new System.Drawing.Point(627, 51);
            this.Line3.Name = "Line3";
            this.Line3.ParentStyleUsing.UseBackColor = false;
            this.Line3.ParentStyleUsing.UseBorderColor = false;
            this.Line3.ParentStyleUsing.UseBorders = false;
            this.Line3.ParentStyleUsing.UseBorderWidth = false;
            this.Line3.ParentStyleUsing.UseFont = false;
            this.Line3.ParentStyleUsing.UseForeColor = false;
            this.Line3.Size = new System.Drawing.Size(78, 2);
            // 
            // totEinkommen
            // 
            this.totEinkommen.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragAlsEinkommen", "{0:n2}")});
            this.totEinkommen.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.totEinkommen.ForeColor = System.Drawing.Color.Black;
            this.totEinkommen.Location = new System.Drawing.Point(627, 31);
            this.totEinkommen.Multiline = true;
            this.totEinkommen.Name = "totEinkommen";
            this.totEinkommen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totEinkommen.ParentStyleUsing.UseBackColor = false;
            this.totEinkommen.ParentStyleUsing.UseBorderColor = false;
            this.totEinkommen.ParentStyleUsing.UseBorders = false;
            this.totEinkommen.ParentStyleUsing.UseBorderWidth = false;
            this.totEinkommen.ParentStyleUsing.UseFont = false;
            this.totEinkommen.ParentStyleUsing.UseForeColor = false;
            this.totEinkommen.Size = new System.Drawing.Size(78, 19);
            xrSummary2.FormatString = "{0:#,##0.00}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.totEinkommen.Summary = xrSummary2;
            this.totEinkommen.Text = "totEinkommen";
            this.totEinkommen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // totBetrag
            // 
            this.totBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.totBetrag.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.totBetrag.ForeColor = System.Drawing.Color.Black;
            this.totBetrag.Location = new System.Drawing.Point(627, 3);
            this.totBetrag.Multiline = true;
            this.totBetrag.Name = "totBetrag";
            this.totBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totBetrag.ParentStyleUsing.UseBackColor = false;
            this.totBetrag.ParentStyleUsing.UseBorderColor = false;
            this.totBetrag.ParentStyleUsing.UseBorders = false;
            this.totBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.totBetrag.ParentStyleUsing.UseFont = false;
            this.totBetrag.ParentStyleUsing.UseForeColor = false;
            this.totBetrag.Size = new System.Drawing.Size(78, 19);
            xrSummary3.FormatString = "{0:#,##0.00}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.totBetrag.Summary = xrSummary3;
            this.totBetrag.Text = "totBetrag";
            this.totBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox1
            // 
            this.TextBox1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.TextBox1.ForeColor = System.Drawing.Color.Black;
            this.TextBox1.Location = new System.Drawing.Point(7, 31);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox1.ParentStyleUsing.UseBackColor = false;
            this.TextBox1.ParentStyleUsing.UseBorderColor = false;
            this.TextBox1.ParentStyleUsing.UseBorders = false;
            this.TextBox1.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox1.ParentStyleUsing.UseFont = false;
            this.TextBox1.ParentStyleUsing.UseForeColor = false;
            this.TextBox1.Size = new System.Drawing.Size(606, 19);
            this.TextBox1.Text = "Davon als Einkommen bewertet";
            this.TextBox1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
                        this.GroupFooter1,
                        this.PageFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(39, 78, 39, 39);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'DECLARE @BgBudgetID int

SELECT @BgBudgetID = BgBudgetID
FROM BgBudget
WHERE BgFinanzplanID = {BgFinanzplanID} AND MasterBudget = 1

SELECT BPO.*,
  NamePerson         = PRS.Name + IsNull('', '' + PRS.Vorname, ''''),
  AlimentenTyp       = SPT.Name,
  VerwaltungDurch    = CASE WHEN BPO.VerwaltungSD = 0 THEN ''Klient'' ELSE ''Inkassodienst'' END,
  BewertungAls       = CASE WHEN BPO.VerwaltungSD = 0 THEN ''Unterstützung'' ELSE ''Einkommen'' END,
  BetragAlsEinkommen = CASE WHEN BPO.VerwaltungSD = 0 THEN $0.00 ELSE BPO.Betrag END
FROM BgPosition              BPO
  INNER JOIN WhPositionsart  SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
  LEFT  JOIN BaPerson        PRS ON PRS.BaPersonID = BPO.BaPersonID
WHERE BPO.BgBudgetID = @BgBudgetID AND SPT.BgGruppeCode = 3102
  AND BPO.DatumVon IS NULL' ,  null ,  N'ShDetaillierterFinanzplan' ,  null );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShDetaillierterFinanzplan_EinkommenVersich' ,  N'Einkommen aus Versicherungsleistungen' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\log4net.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtVersicherungsTyp;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtBemerkungRTF;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private DevExpress.XtraReports.UI.XRLabel txtVerwaltungDurch;
        private DevExpress.XtraReports.UI.XRLabel txtNamePerson;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRPanel hiderPanel;
        private DevExpress.XtraReports.UI.XRLabel hiderTxtBemerkungRTF;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLine Line4;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLabel txtTotBetrag;
        private DevExpress.XtraReports.UI.XRLabel Label5;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = @"zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OSNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kAAAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAAAAAAeAEREVDTEFSRSBAQmdCdWRnZXRJRCBpbnQNCg0KU0VMRUNUIEBCZ0J1ZGdldElEID0gQmdCdWRnZXRJRA0KRlJPTSBCZ0J1ZGdldA0KV0hFUkUgQmdGaW5hbnpwbGFuSUQgPSBudWxsIEFORCBNYXN0ZXJCdWRnZXQgPSAxDQoNClNFTEVDVCBCUE8uKiwNCiAgTmFtZVBlcnNvbiAgICAgICA9IFBSUy5OYW1lICsgSXNOdWxsKCcsICcgKyBQUlMuVm9ybmFtZSwgJycpLA0KICBWZXJzaWNoZXJ1bmdzVHlwID0gU1BULk5hbWUsDQogIFZlcndhbHR1bmdEdXJjaCAgPSBDQVNFIFdIRU4gQlBPLlZlcndhbHR1bmdTRCA9IDAgVEhFTiAnS2xpZW50JyBFTFNFICdTb3ppYWxkaWVuc3QnIEVORA0KRlJPTSBCZ1Bvc2l0aW9uICAgICAgICAgICAgICBCUE8NCiAgSU5ORVIgSk9JTiBXaFBvc2l0aW9uc2FydCAgU1BUIE9OIFNQVC5CZ1Bvc2l0aW9uc2FydElEID0gQlBPLkJnUG9zaXRpb25zYXJ0SUQNCiAgTEVGVCAgSk9JTiBCYVBlcnNvbiAgICAgICAgUFJTIE9OIFBSUy5CYVBlcnNvbklEICAgICA9IEJQTy5CYVBlcnNvbklEDQpXSEVSRSBCUE8uQmdCdWRnZXRJRCA9IEBCZ0J1ZGdldElEIEFORCBTUFQuQmdHcnVwcGVDb2RlID0gMzEwMw0KICBBTkQgQlBPLkRhdHVtVm9uIElTIE5VTEw=";
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
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.txtVersicherungsTyp = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBemerkungRTF = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtVerwaltungDurch = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNamePerson = new DevExpress.XtraReports.UI.XRLabel();
            this.hiderPanel = new DevExpress.XtraReports.UI.XRPanel();
            this.hiderTxtBemerkungRTF = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line4 = new DevExpress.XtraReports.UI.XRLine();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.txtTotBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.Label5 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtVersicherungsTyp,
                        this.txtBemerkungRTF,
                        this.txtBetrag,
                        this.txtVerwaltungDurch,
                        this.txtNamePerson});
            this.Detail.Height = 41;
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
                        this.hiderPanel});
            this.PageHeader.Height = 27;
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
                        this.xrLine1,
                        this.xrLabel7,
                        this.xrLabel6,
                        this.xrLabel5,
                        this.xrLabel4,
                        this.xrLabel1});
            this.GroupHeader1.Height = 55;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Line4,
                        this.Line3,
                        this.Line2,
                        this.txtTotBetrag,
                        this.Label5});
            this.GroupFooter1.Height = 51;
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
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // txtVersicherungsTyp
            // 
            this.txtVersicherungsTyp.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VersicherungsTyp", "")});
            this.txtVersicherungsTyp.Font = new System.Drawing.Font("Arial", 10F);
            this.txtVersicherungsTyp.ForeColor = System.Drawing.Color.Black;
            this.txtVersicherungsTyp.Location = new System.Drawing.Point(216, 0);
            this.txtVersicherungsTyp.Multiline = true;
            this.txtVersicherungsTyp.Name = "txtVersicherungsTyp";
            this.txtVersicherungsTyp.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtVersicherungsTyp.ParentStyleUsing.UseBackColor = false;
            this.txtVersicherungsTyp.ParentStyleUsing.UseBorderColor = false;
            this.txtVersicherungsTyp.ParentStyleUsing.UseBorders = false;
            this.txtVersicherungsTyp.ParentStyleUsing.UseBorderWidth = false;
            this.txtVersicherungsTyp.ParentStyleUsing.UseFont = false;
            this.txtVersicherungsTyp.ParentStyleUsing.UseForeColor = false;
            this.txtVersicherungsTyp.Size = new System.Drawing.Size(280, 19);
            this.txtVersicherungsTyp.Text = "VersicherungsTyp";
            // 
            // txtBemerkungRTF
            // 
            this.txtBemerkungRTF.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bemerkung", "")});
            this.txtBemerkungRTF.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.txtBemerkungRTF.ForeColor = System.Drawing.Color.Black;
            this.txtBemerkungRTF.Location = new System.Drawing.Point(7, 15);
            this.txtBemerkungRTF.Multiline = true;
            this.txtBemerkungRTF.Name = "txtBemerkungRTF";
            this.txtBemerkungRTF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBemerkungRTF.ParentStyleUsing.UseBackColor = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorderColor = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorders = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorderWidth = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseFont = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseForeColor = false;
            this.txtBemerkungRTF.Size = new System.Drawing.Size(693, 19);
            this.txtBemerkungRTF.Text = "txtBemerkungRTF";
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(627, 0);
            this.txtBetrag.Multiline = true;
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(78, 19);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtBetrag.Summary = xrSummary1;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtVerwaltungDurch
            // 
            this.txtVerwaltungDurch.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VerwaltungDurch", "")});
            this.txtVerwaltungDurch.Font = new System.Drawing.Font("Arial", 10F);
            this.txtVerwaltungDurch.ForeColor = System.Drawing.Color.Black;
            this.txtVerwaltungDurch.Location = new System.Drawing.Point(500, 0);
            this.txtVerwaltungDurch.Multiline = true;
            this.txtVerwaltungDurch.Name = "txtVerwaltungDurch";
            this.txtVerwaltungDurch.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtVerwaltungDurch.ParentStyleUsing.UseBackColor = false;
            this.txtVerwaltungDurch.ParentStyleUsing.UseBorderColor = false;
            this.txtVerwaltungDurch.ParentStyleUsing.UseBorders = false;
            this.txtVerwaltungDurch.ParentStyleUsing.UseBorderWidth = false;
            this.txtVerwaltungDurch.ParentStyleUsing.UseFont = false;
            this.txtVerwaltungDurch.ParentStyleUsing.UseForeColor = false;
            this.txtVerwaltungDurch.Size = new System.Drawing.Size(125, 19);
            xrSummary2.FormatString = "{0:0\\%}";
            this.txtVerwaltungDurch.Summary = xrSummary2;
            this.txtVerwaltungDurch.Text = "VerwaltungDurch";
            // 
            // txtNamePerson
            // 
            this.txtNamePerson.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NamePerson", "")});
            this.txtNamePerson.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNamePerson.ForeColor = System.Drawing.Color.Black;
            this.txtNamePerson.Location = new System.Drawing.Point(7, 0);
            this.txtNamePerson.Multiline = true;
            this.txtNamePerson.Name = "txtNamePerson";
            this.txtNamePerson.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNamePerson.ParentStyleUsing.UseBackColor = false;
            this.txtNamePerson.ParentStyleUsing.UseBorderColor = false;
            this.txtNamePerson.ParentStyleUsing.UseBorders = false;
            this.txtNamePerson.ParentStyleUsing.UseBorderWidth = false;
            this.txtNamePerson.ParentStyleUsing.UseFont = false;
            this.txtNamePerson.ParentStyleUsing.UseForeColor = false;
            this.txtNamePerson.Size = new System.Drawing.Size(208, 19);
            this.txtNamePerson.Text = "NamePerson";
            // 
            // hiderPanel
            // 
            this.hiderPanel.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.hiderTxtBemerkungRTF});
            this.hiderPanel.Location = new System.Drawing.Point(220, 0);
            this.hiderPanel.Name = "hiderPanel";
            this.hiderPanel.Size = new System.Drawing.Size(300, 27);
            this.hiderPanel.Visible = false;
            // 
            // hiderTxtBemerkungRTF
            // 
            this.hiderTxtBemerkungRTF.Location = new System.Drawing.Point(13, 0);
            this.hiderTxtBemerkungRTF.Name = "hiderTxtBemerkungRTF";
            this.hiderTxtBemerkungRTF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hiderTxtBemerkungRTF.Scripts.OnAfterPrint = "private void OnAfterPrint(object sender, System.EventArgs e) {\r\n    txtBemerkungR" +
                "TF.Visible = hiderTxtBemerkungRTF.Text != String.Empty;\r\n}";
            this.hiderTxtBemerkungRTF.Size = new System.Drawing.Size(100, 27);
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.Location = new System.Drawing.Point(7, 53);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(700, 2);
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel7.Location = new System.Drawing.Point(7, 35);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.Size = new System.Drawing.Size(100, 13);
            this.xrLabel7.Text = "Betrifft";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel6.Location = new System.Drawing.Point(216, 35);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.Size = new System.Drawing.Size(100, 14);
            this.xrLabel6.Text = "Versicherung";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel5.Location = new System.Drawing.Point(625, 35);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(75, 13);
            this.xrLabel5.Text = "Betrag";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel4.Location = new System.Drawing.Point(500, 35);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(117, 13);
            this.xrLabel4.Text = "Verwaltet durch";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.xrLabel1.Location = new System.Drawing.Point(0, 0);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(320, 27);
            this.xrLabel1.Text = "Einkommen aus Versicherungsleistungen";
            // 
            // Line4
            // 
            this.Line4.ForeColor = System.Drawing.Color.Black;
            this.Line4.Location = new System.Drawing.Point(607, 27);
            this.Line4.Name = "Line4";
            this.Line4.ParentStyleUsing.UseBackColor = false;
            this.Line4.ParentStyleUsing.UseBorderColor = false;
            this.Line4.ParentStyleUsing.UseBorders = false;
            this.Line4.ParentStyleUsing.UseBorderWidth = false;
            this.Line4.ParentStyleUsing.UseFont = false;
            this.Line4.ParentStyleUsing.UseForeColor = false;
            this.Line4.Size = new System.Drawing.Size(98, 2);
            // 
            // Line3
            // 
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.Location = new System.Drawing.Point(607, 23);
            this.Line3.Name = "Line3";
            this.Line3.ParentStyleUsing.UseBackColor = false;
            this.Line3.ParentStyleUsing.UseBorderColor = false;
            this.Line3.ParentStyleUsing.UseBorders = false;
            this.Line3.ParentStyleUsing.UseBorderWidth = false;
            this.Line3.ParentStyleUsing.UseFont = false;
            this.Line3.ParentStyleUsing.UseForeColor = false;
            this.Line3.Size = new System.Drawing.Size(98, 2);
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.Location = new System.Drawing.Point(7, 0);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(700, 2);
            // 
            // txtTotBetrag
            // 
            this.txtTotBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtTotBetrag.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.txtTotBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtTotBetrag.Location = new System.Drawing.Point(627, 3);
            this.txtTotBetrag.Multiline = true;
            this.txtTotBetrag.Name = "txtTotBetrag";
            this.txtTotBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTotBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtTotBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtTotBetrag.ParentStyleUsing.UseBorders = false;
            this.txtTotBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtTotBetrag.ParentStyleUsing.UseFont = false;
            this.txtTotBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtTotBetrag.Size = new System.Drawing.Size(78, 19);
            xrSummary3.FormatString = "{0:#,##0.00}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.txtTotBetrag.Summary = xrSummary3;
            this.txtTotBetrag.Text = "txtTotBetrag";
            this.txtTotBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(173, 3);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(414, 19);
            this.Label5.Text = "Gesamtes Versicherungseinkommen";
            this.Label5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
                        this.GroupFooter1,
                        this.PageFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(39, 75, 39, 39);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'DECLARE @BgBudgetID int

SELECT @BgBudgetID = BgBudgetID
FROM BgBudget
WHERE BgFinanzplanID = {BgFinanzplanID} AND MasterBudget = 1

SELECT BPO.*,
  NamePerson       = PRS.Name + IsNull('', '' + PRS.Vorname, ''''),
  VersicherungsTyp = SPT.Name,
  VerwaltungDurch  = CASE WHEN BPO.VerwaltungSD = 0 THEN ''Klient'' ELSE ''Sozialdienst'' END
FROM BgPosition              BPO
  INNER JOIN WhPositionsart  SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
  LEFT  JOIN BaPerson        PRS ON PRS.BaPersonID     = BPO.BaPersonID
WHERE BPO.BgBudgetID = @BgBudgetID AND SPT.BgGruppeCode = 3103
  AND BPO.DatumVon IS NULL' ,  null ,  N'ShDetaillierterFinanzplan' ,  null );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShDetaillierterFinanzplan_Erwerbseinkommen' ,  N'Erwerbseinkommen' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\log4net.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtBemerkungRTF;
        private DevExpress.XtraReports.UI.XRLabel txtUnkostenAbzug;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtUnkostenBetrag;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private DevExpress.XtraReports.UI.XRLabel txtVerwaltungDurch;
        private DevExpress.XtraReports.UI.XRLabel txtTaetigkeit;
        private DevExpress.XtraReports.UI.XRLabel txtNamePerson;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRLabel hiderTxtBemerkungRTF;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel Label16;
        private DevExpress.XtraReports.UI.XRLabel Label15;
        private DevExpress.XtraReports.UI.XRLine Line6;
        private DevExpress.XtraReports.UI.XRLine Line5;
        private DevExpress.XtraReports.UI.XRLine Line4;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLabel sumTotal;
        private DevExpress.XtraReports.UI.XRLabel totUnkostenAbzug;
        private DevExpress.XtraReports.UI.XRLabel totUnkosten;
        private DevExpress.XtraReports.UI.XRLabel totBetrag;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
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
                        "AAAAaUIREVDTEFSRSBAQmdCdWRnZXRJRCBpbnQNCg0KU0VMRUNUIEBCZ0J1ZGdldElEID0gQmdCdWRnZ" +
                        "XRJRA0KRlJPTSBCZ0J1ZGdldA0KV0hFUkUgQmdGaW5hbnpwbGFuSUQgPSBudWxsIEFORCBNYXN0ZXJCd" +
                        "WRnZXQgPSAxDQoNClNFTEVDVCBCUE8uKiwNCiAgVmVyd2FsdHVuZ0R1cmNoICAgICAgICAgID0gQ0FTR" +
                        "SBXSEVOIEJQTy5WZXJ3YWx0dW5nU0QgPSAwIFRIRU4gJ0tsaWVudCcgRUxTRSAnU296aWFsZGllbnN0J" +
                        "yBFTkQsDQogIE5hbWVQZXJzb24gICAgICAgICAgICAgICA9IFBSUy5OYW1lICsgSXNOdWxsKCcsICcgK" +
                        "yBQUlMuVm9ybmFtZSwgJycpLA0KICBHZWJ1cnRzZGF0dW0gICAgICAgICAgICAgPSBDT05WRVJUKHZhc" +
                        "mNoYXIsIFBSUy5HZWJ1cnRzZGF0dW0sIDEwNCksDQogIFRhZXRpZ2tlaXQgICAgICAgICAgICAgICA9I" +
                        "FNQVC5OYW1lLA0KICBVbmtvc3RlbkJldHJhZyAgICAgICAgICAgPSBQVUsuQmV0cmFnLA0KICBVbmtvc" +
                        "3RlbkFienVnICAgICAgICAgICAgPSBQVUsuQWJ6dWcsDQogIFVua29zdGVuQW5nZXJlY2huZXQgICAgI" +
                        "CA9IFBVSy5CZXRyYWcgLSBQVUsuQWJ6dWcsDQogIFRvdGFsICAgICAgICAgICAgICAgICAgICA9IEJQT" +
                        "y5CZXRyYWcgLSBJc051bGwoUFVLLkJldHJhZyAtIFBVSy5BYnp1ZywgMCksDQogIEdlc2FtdGVzRXJ3Z" +
                        "XJic2VpbmtvbW1lbiA9IEJQTy5CZXRyYWcgLSBQVUsuQmV0cmFnIC0gUFVLLkFienVnDQpGUk9NIEJnU" +
                        "G9zaXRpb24gICAgICAgICAgICAgIEJQTw0KICBJTk5FUiBKT0lOIFdoUG9zaXRpb25zYXJ0ICBTUFQgT" +
                        "04gU1BULkJnUG9zaXRpb25zYXJ0SUQgPSBCUE8uQmdQb3NpdGlvbnNhcnRJRA0KICBMRUZUICBKT0lOI" +
                        "EJhUGVyc29uICAgICAgICBQUlMgT04gUFJTLkJhUGVyc29uSUQgPSBCUE8uQmFQZXJzb25JRA0KICBMR" +
                        "UZUICBKT0lOIEJnUG9zaXRpb24gICAgICBQVUsgT04gUFVLLkJnUG9zaXRpb25JRF9QYXJlbnQgPSBCU" +
                        "E8uQmdQb3NpdGlvbklEDQpXSEVSRSBCUE8uQmdCdWRnZXRJRCA9IEBCZ0J1ZGdldElEIEFORCBTUFQuQ" +
                        "mdHcnVwcGVDb2RlID0gMzEwMQ0KICBBTkQgQlBPLkRhdHVtVm9uIElTIE5VTEw=";
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
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.txtBemerkungRTF = new DevExpress.XtraReports.UI.XRLabel();
            this.txtUnkostenAbzug = new DevExpress.XtraReports.UI.XRLabel();
            this.txtUnkostenBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtVerwaltungDurch = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTaetigkeit = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNamePerson = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.hiderTxtBemerkungRTF = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label16 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label15 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line6 = new DevExpress.XtraReports.UI.XRLine();
            this.Line5 = new DevExpress.XtraReports.UI.XRLine();
            this.Line4 = new DevExpress.XtraReports.UI.XRLine();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.sumTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.totUnkostenAbzug = new DevExpress.XtraReports.UI.XRLabel();
            this.totUnkosten = new DevExpress.XtraReports.UI.XRLabel();
            this.totBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtBemerkungRTF,
                        this.txtUnkostenAbzug,
                        this.txtUnkostenBetrag,
                        this.txtBetrag,
                        this.txtVerwaltungDurch,
                        this.txtTaetigkeit,
                        this.txtNamePerson});
            this.Detail.Height = 43;
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
                        this.xrPanel1});
            this.ReportHeader.Height = 27;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.ParentStyleUsing.UseBackColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorderColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorders = false;
            this.ReportHeader.ParentStyleUsing.UseBorderWidth = false;
            this.ReportHeader.ParentStyleUsing.UseFont = false;
            this.ReportHeader.ParentStyleUsing.UseForeColor = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Height = 0;
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
                        this.xrLine1,
                        this.xrLabel12,
                        this.xrLabel11,
                        this.xrLabel10,
                        this.xrLabel9,
                        this.xrLabel8,
                        this.xrLabel7,
                        this.xrLabel4,
                        this.xrLabel1});
            this.GroupHeader1.Height = 82;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Label16,
                        this.Label15,
                        this.Line6,
                        this.Line5,
                        this.Line4,
                        this.Line3,
                        this.sumTotal,
                        this.totUnkostenAbzug,
                        this.totUnkosten,
                        this.totBetrag});
            this.GroupFooter1.Height = 93;
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
            this.PageFooter.Height = 0;
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
            this.ReportFooter.Height = 0;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // txtBemerkungRTF
            // 
            this.txtBemerkungRTF.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.txtBemerkungRTF.ForeColor = System.Drawing.Color.Black;
            this.txtBemerkungRTF.Location = new System.Drawing.Point(7, 17);
            this.txtBemerkungRTF.Multiline = true;
            this.txtBemerkungRTF.Name = "txtBemerkungRTF";
            this.txtBemerkungRTF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBemerkungRTF.ParentStyleUsing.UseBackColor = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorderColor = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorders = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorderWidth = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseFont = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseForeColor = false;
            this.txtBemerkungRTF.Size = new System.Drawing.Size(693, 17);
            this.txtBemerkungRTF.Text = "BemerkungRTF";
            // 
            // txtUnkostenAbzug
            // 
            this.txtUnkostenAbzug.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "UnkostenAbzug", "{0:n2}")});
            this.txtUnkostenAbzug.Font = new System.Drawing.Font("Arial", 10F);
            this.txtUnkostenAbzug.ForeColor = System.Drawing.Color.Black;
            this.txtUnkostenAbzug.Location = new System.Drawing.Point(627, 0);
            this.txtUnkostenAbzug.Multiline = true;
            this.txtUnkostenAbzug.Name = "txtUnkostenAbzug";
            this.txtUnkostenAbzug.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtUnkostenAbzug.ParentStyleUsing.UseBackColor = false;
            this.txtUnkostenAbzug.ParentStyleUsing.UseBorderColor = false;
            this.txtUnkostenAbzug.ParentStyleUsing.UseBorders = false;
            this.txtUnkostenAbzug.ParentStyleUsing.UseBorderWidth = false;
            this.txtUnkostenAbzug.ParentStyleUsing.UseFont = false;
            this.txtUnkostenAbzug.ParentStyleUsing.UseForeColor = false;
            this.txtUnkostenAbzug.Size = new System.Drawing.Size(78, 19);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtUnkostenAbzug.Summary = xrSummary1;
            this.txtUnkostenAbzug.Text = "UnkostenAbzug";
            this.txtUnkostenAbzug.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtUnkostenBetrag
            // 
            this.txtUnkostenBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "UnkostenBetrag", "{0:n2}")});
            this.txtUnkostenBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtUnkostenBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtUnkostenBetrag.Location = new System.Drawing.Point(540, 0);
            this.txtUnkostenBetrag.Multiline = true;
            this.txtUnkostenBetrag.Name = "txtUnkostenBetrag";
            this.txtUnkostenBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtUnkostenBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtUnkostenBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtUnkostenBetrag.ParentStyleUsing.UseBorders = false;
            this.txtUnkostenBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtUnkostenBetrag.ParentStyleUsing.UseFont = false;
            this.txtUnkostenBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtUnkostenBetrag.Size = new System.Drawing.Size(78, 19);
            xrSummary2.FormatString = "{0:#,##0.00}";
            this.txtUnkostenBetrag.Summary = xrSummary2;
            this.txtUnkostenBetrag.Text = "UnkostenBetrag";
            this.txtUnkostenBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(453, 0);
            this.txtBetrag.Multiline = true;
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(78, 19);
            xrSummary3.FormatString = "{0:#,##0.00}";
            this.txtBetrag.Summary = xrSummary3;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtVerwaltungDurch
            // 
            this.txtVerwaltungDurch.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VerwaltungDurch", "")});
            this.txtVerwaltungDurch.Font = new System.Drawing.Font("Arial", 10F);
            this.txtVerwaltungDurch.ForeColor = System.Drawing.Color.Black;
            this.txtVerwaltungDurch.Location = new System.Drawing.Point(340, 0);
            this.txtVerwaltungDurch.Multiline = true;
            this.txtVerwaltungDurch.Name = "txtVerwaltungDurch";
            this.txtVerwaltungDurch.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtVerwaltungDurch.ParentStyleUsing.UseBackColor = false;
            this.txtVerwaltungDurch.ParentStyleUsing.UseBorderColor = false;
            this.txtVerwaltungDurch.ParentStyleUsing.UseBorders = false;
            this.txtVerwaltungDurch.ParentStyleUsing.UseBorderWidth = false;
            this.txtVerwaltungDurch.ParentStyleUsing.UseFont = false;
            this.txtVerwaltungDurch.ParentStyleUsing.UseForeColor = false;
            this.txtVerwaltungDurch.Size = new System.Drawing.Size(111, 17);
            this.txtVerwaltungDurch.Text = "VerwaltungDurch";
            // 
            // txtTaetigkeit
            // 
            this.txtTaetigkeit.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Taetigkeit", "")});
            this.txtTaetigkeit.Font = new System.Drawing.Font("Arial", 10F);
            this.txtTaetigkeit.ForeColor = System.Drawing.Color.Black;
            this.txtTaetigkeit.Location = new System.Drawing.Point(216, 0);
            this.txtTaetigkeit.Multiline = true;
            this.txtTaetigkeit.Name = "txtTaetigkeit";
            this.txtTaetigkeit.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTaetigkeit.ParentStyleUsing.UseBackColor = false;
            this.txtTaetigkeit.ParentStyleUsing.UseBorderColor = false;
            this.txtTaetigkeit.ParentStyleUsing.UseBorders = false;
            this.txtTaetigkeit.ParentStyleUsing.UseBorderWidth = false;
            this.txtTaetigkeit.ParentStyleUsing.UseFont = false;
            this.txtTaetigkeit.ParentStyleUsing.UseForeColor = false;
            this.txtTaetigkeit.Size = new System.Drawing.Size(119, 19);
            this.txtTaetigkeit.Text = "Taetigkeit";
            // 
            // txtNamePerson
            // 
            this.txtNamePerson.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NamePerson", "")});
            this.txtNamePerson.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNamePerson.ForeColor = System.Drawing.Color.Black;
            this.txtNamePerson.Location = new System.Drawing.Point(7, 0);
            this.txtNamePerson.Multiline = true;
            this.txtNamePerson.Name = "txtNamePerson";
            this.txtNamePerson.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNamePerson.ParentStyleUsing.UseBackColor = false;
            this.txtNamePerson.ParentStyleUsing.UseBorderColor = false;
            this.txtNamePerson.ParentStyleUsing.UseBorders = false;
            this.txtNamePerson.ParentStyleUsing.UseBorderWidth = false;
            this.txtNamePerson.ParentStyleUsing.UseFont = false;
            this.txtNamePerson.ParentStyleUsing.UseForeColor = false;
            this.txtNamePerson.Size = new System.Drawing.Size(208, 19);
            this.txtNamePerson.Text = "NamePerson";
            // 
            // xrPanel1
            // 
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.hiderTxtBemerkungRTF});
            this.xrPanel1.Location = new System.Drawing.Point(180, 0);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.Size = new System.Drawing.Size(300, 27);
            this.xrPanel1.Visible = false;
            // 
            // hiderTxtBemerkungRTF
            // 
            this.hiderTxtBemerkungRTF.Location = new System.Drawing.Point(7, 0);
            this.hiderTxtBemerkungRTF.Name = "hiderTxtBemerkungRTF";
            this.hiderTxtBemerkungRTF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hiderTxtBemerkungRTF.Scripts.OnAfterPrint = "private void OnAfterPrint(object sender, System.EventArgs e) {\r\n  txtBemerkungRTF" +
                ".Visible = hiderTxtBemerkungRTF.Text != String.Empty;\r\n}";
            this.hiderTxtBemerkungRTF.Size = new System.Drawing.Size(100, 20);
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.Location = new System.Drawing.Point(4, 80);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(700, 2);
            // 
            // xrLabel12
            // 
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel12.Location = new System.Drawing.Point(216, 60);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.ParentStyleUsing.UseFont = false;
            this.xrLabel12.Size = new System.Drawing.Size(100, 20);
            this.xrLabel12.Text = "Tätigkeit";
            // 
            // xrLabel11
            // 
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel11.Location = new System.Drawing.Point(7, 60);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.ParentStyleUsing.UseFont = false;
            this.xrLabel11.Size = new System.Drawing.Size(100, 20);
            this.xrLabel11.Text = "Betrifft";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel10.Location = new System.Drawing.Point(449, 60);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.ParentStyleUsing.UseFont = false;
            this.xrLabel10.Size = new System.Drawing.Size(82, 20);
            this.xrLabel10.Text = "Einkommen";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel9.Location = new System.Drawing.Point(540, 60);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.Size = new System.Drawing.Size(76, 20);
            this.xrLabel9.Text = "Betrag";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel8.Location = new System.Drawing.Point(493, 40);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.Size = new System.Drawing.Size(207, 20);
            this.xrLabel8.Text = "effektive Erwerbsunkosten";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel7.Location = new System.Drawing.Point(620, 60);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.Size = new System.Drawing.Size(82, 20);
            this.xrLabel7.Text = "Reduktion";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel4.Location = new System.Drawing.Point(342, 60);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(105, 20);
            this.xrLabel4.Text = "Verwaltet durch";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.xrLabel1.Location = new System.Drawing.Point(0, 7);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(347, 20);
            this.xrLabel1.Text = "Erwerbseinkommen und effektive Erwerbsunkosten";
            // 
            // Label16
            // 
            this.Label16.Font = new System.Drawing.Font("Arial", 10F);
            this.Label16.ForeColor = System.Drawing.Color.Black;
            this.Label16.Location = new System.Drawing.Point(320, 43);
            this.Label16.Name = "Label16";
            this.Label16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label16.ParentStyleUsing.UseBackColor = false;
            this.Label16.ParentStyleUsing.UseBorderColor = false;
            this.Label16.ParentStyleUsing.UseBorders = false;
            this.Label16.ParentStyleUsing.UseBorderWidth = false;
            this.Label16.ParentStyleUsing.UseFont = false;
            this.Label16.ParentStyleUsing.UseForeColor = false;
            this.Label16.Size = new System.Drawing.Size(271, 19);
            this.Label16.Text = "Gesamtes Erwerbseinkommen";
            this.Label16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label15
            // 
            this.Label15.Font = new System.Drawing.Font("Arial", 10F);
            this.Label15.ForeColor = System.Drawing.Color.Black;
            this.Label15.Location = new System.Drawing.Point(360, 11);
            this.Label15.Name = "Label15";
            this.Label15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label15.ParentStyleUsing.UseBackColor = false;
            this.Label15.ParentStyleUsing.UseBorderColor = false;
            this.Label15.ParentStyleUsing.UseBorders = false;
            this.Label15.ParentStyleUsing.UseBorderWidth = false;
            this.Label15.ParentStyleUsing.UseFont = false;
            this.Label15.ParentStyleUsing.UseForeColor = false;
            this.Label15.Size = new System.Drawing.Size(78, 19);
            this.Label15.Text = "Total";
            this.Label15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line6
            // 
            this.Line6.ForeColor = System.Drawing.Color.Black;
            this.Line6.Location = new System.Drawing.Point(7, 37);
            this.Line6.Name = "Line6";
            this.Line6.ParentStyleUsing.UseBackColor = false;
            this.Line6.ParentStyleUsing.UseBorderColor = false;
            this.Line6.ParentStyleUsing.UseBorders = false;
            this.Line6.ParentStyleUsing.UseBorderWidth = false;
            this.Line6.ParentStyleUsing.UseFont = false;
            this.Line6.ParentStyleUsing.UseForeColor = false;
            this.Line6.Size = new System.Drawing.Size(700, 2);
            // 
            // Line5
            // 
            this.Line5.ForeColor = System.Drawing.Color.Black;
            this.Line5.Location = new System.Drawing.Point(607, 70);
            this.Line5.Name = "Line5";
            this.Line5.ParentStyleUsing.UseBackColor = false;
            this.Line5.ParentStyleUsing.UseBorderColor = false;
            this.Line5.ParentStyleUsing.UseBorders = false;
            this.Line5.ParentStyleUsing.UseBorderWidth = false;
            this.Line5.ParentStyleUsing.UseFont = false;
            this.Line5.ParentStyleUsing.UseForeColor = false;
            this.Line5.Size = new System.Drawing.Size(94, 2);
            // 
            // Line4
            // 
            this.Line4.ForeColor = System.Drawing.Color.Black;
            this.Line4.Location = new System.Drawing.Point(607, 66);
            this.Line4.Name = "Line4";
            this.Line4.ParentStyleUsing.UseBackColor = false;
            this.Line4.ParentStyleUsing.UseBorderColor = false;
            this.Line4.ParentStyleUsing.UseBorders = false;
            this.Line4.ParentStyleUsing.UseBorderWidth = false;
            this.Line4.ParentStyleUsing.UseFont = false;
            this.Line4.ParentStyleUsing.UseForeColor = false;
            this.Line4.Size = new System.Drawing.Size(94, 2);
            // 
            // Line3
            // 
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.Location = new System.Drawing.Point(7, 3);
            this.Line3.Name = "Line3";
            this.Line3.ParentStyleUsing.UseBackColor = false;
            this.Line3.ParentStyleUsing.UseBorderColor = false;
            this.Line3.ParentStyleUsing.UseBorders = false;
            this.Line3.ParentStyleUsing.UseBorderWidth = false;
            this.Line3.ParentStyleUsing.UseFont = false;
            this.Line3.ParentStyleUsing.UseForeColor = false;
            this.Line3.Size = new System.Drawing.Size(700, 2);
            // 
            // sumTotal
            // 
            this.sumTotal.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GesamtesErwerbseinkommen", "")});
            this.sumTotal.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.sumTotal.ForeColor = System.Drawing.Color.Black;
            this.sumTotal.Location = new System.Drawing.Point(607, 43);
            this.sumTotal.Multiline = true;
            this.sumTotal.Name = "sumTotal";
            this.sumTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.sumTotal.ParentStyleUsing.UseBackColor = false;
            this.sumTotal.ParentStyleUsing.UseBorderColor = false;
            this.sumTotal.ParentStyleUsing.UseBorders = false;
            this.sumTotal.ParentStyleUsing.UseBorderWidth = false;
            this.sumTotal.ParentStyleUsing.UseFont = false;
            this.sumTotal.ParentStyleUsing.UseForeColor = false;
            this.sumTotal.Size = new System.Drawing.Size(94, 19);
            xrSummary4.FormatString = "{0:n2}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.sumTotal.Summary = xrSummary4;
            this.sumTotal.Text = "sumTotal";
            this.sumTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // totUnkostenAbzug
            // 
            this.totUnkostenAbzug.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "UnkostenAbzug", "{0:n2}")});
            this.totUnkostenAbzug.Font = new System.Drawing.Font("Arial", 10F);
            this.totUnkostenAbzug.ForeColor = System.Drawing.Color.Black;
            this.totUnkostenAbzug.Location = new System.Drawing.Point(627, 11);
            this.totUnkostenAbzug.Multiline = true;
            this.totUnkostenAbzug.Name = "totUnkostenAbzug";
            this.totUnkostenAbzug.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totUnkostenAbzug.ParentStyleUsing.UseBackColor = false;
            this.totUnkostenAbzug.ParentStyleUsing.UseBorderColor = false;
            this.totUnkostenAbzug.ParentStyleUsing.UseBorders = false;
            this.totUnkostenAbzug.ParentStyleUsing.UseBorderWidth = false;
            this.totUnkostenAbzug.ParentStyleUsing.UseFont = false;
            this.totUnkostenAbzug.ParentStyleUsing.UseForeColor = false;
            this.totUnkostenAbzug.Size = new System.Drawing.Size(78, 19);
            xrSummary5.FormatString = "{0:#,##0.00}";
            this.totUnkostenAbzug.Summary = xrSummary5;
            this.totUnkostenAbzug.Text = "totUnkostenAbzug";
            this.totUnkostenAbzug.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // totUnkosten
            // 
            this.totUnkosten.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "UnkostenBetrag", "{0:n2}")});
            this.totUnkosten.Font = new System.Drawing.Font("Arial", 10F);
            this.totUnkosten.ForeColor = System.Drawing.Color.Black;
            this.totUnkosten.Location = new System.Drawing.Point(540, 11);
            this.totUnkosten.Multiline = true;
            this.totUnkosten.Name = "totUnkosten";
            this.totUnkosten.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totUnkosten.ParentStyleUsing.UseBackColor = false;
            this.totUnkosten.ParentStyleUsing.UseBorderColor = false;
            this.totUnkosten.ParentStyleUsing.UseBorders = false;
            this.totUnkosten.ParentStyleUsing.UseBorderWidth = false;
            this.totUnkosten.ParentStyleUsing.UseFont = false;
            this.totUnkosten.ParentStyleUsing.UseForeColor = false;
            this.totUnkosten.Size = new System.Drawing.Size(78, 19);
            xrSummary6.FormatString = "{0:#,##0.00}";
            this.totUnkosten.Summary = xrSummary6;
            this.totUnkosten.Text = "totUnkosten";
            this.totUnkosten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // totBetrag
            // 
            this.totBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.totBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.totBetrag.ForeColor = System.Drawing.Color.Black;
            this.totBetrag.Location = new System.Drawing.Point(453, 11);
            this.totBetrag.Multiline = true;
            this.totBetrag.Name = "totBetrag";
            this.totBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totBetrag.ParentStyleUsing.UseBackColor = false;
            this.totBetrag.ParentStyleUsing.UseBorderColor = false;
            this.totBetrag.ParentStyleUsing.UseBorders = false;
            this.totBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.totBetrag.ParentStyleUsing.UseFont = false;
            this.totBetrag.ParentStyleUsing.UseForeColor = false;
            this.totBetrag.Size = new System.Drawing.Size(78, 19);
            xrSummary7.FormatString = "{0:#,##0.00}";
            this.totBetrag.Summary = xrSummary7;
            this.totBetrag.Text = "totBetrag";
            this.totBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail,
                        this.ReportHeader,
                        this.PageHeader,
                        this.GroupHeader1,
                        this.GroupFooter1,
                        this.PageFooter,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(0, 61, 100, 100);
            this.Name = "Report";
            this.PageHeight = 1300;
            this.PageWidth = 769;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'DECLARE @BgBudgetID int

SELECT @BgBudgetID = BgBudgetID
FROM BgBudget
WHERE BgFinanzplanID = {BgFinanzplanID} AND MasterBudget = 1

SELECT BPO.*,
  VerwaltungDurch          = CASE WHEN BPO.VerwaltungSD = 0 THEN ''Klient'' ELSE ''Sozialdienst'' END,
  NamePerson               = PRS.Name + IsNull('', '' + PRS.Vorname, ''''),
  Geburtsdatum             = CONVERT(varchar, PRS.Geburtsdatum, 104),
  Taetigkeit               = SPT.Name,
  UnkostenBetrag           = PUK.Betrag,
  UnkostenAbzug            = PUK.Abzug,
  UnkostenAngerechnet      = PUK.Betrag - PUK.Abzug,
  Total                    = BPO.Betrag - IsNull(PUK.Betrag - PUK.Abzug, 0),
  GesamtesErwerbseinkommen = BPO.Betrag - PUK.Betrag - PUK.Abzug
FROM BgPosition              BPO
  INNER JOIN WhPositionsart  SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
  LEFT  JOIN BaPerson        PRS ON PRS.BaPersonID = BPO.BaPersonID
  LEFT  JOIN BgPosition      PUK ON PUK.BgPositionID_Parent = BPO.BgPositionID
WHERE BPO.BgBudgetID = @BgBudgetID AND SPT.BgGruppeCode = 3101
  AND BPO.DatumVon IS NULL' ,  null ,  N'ShDetaillierterFinanzplan' ,  null );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShDetaillierterFinanzplan_GBMiete' ,  N'Grundbedarf, Miete' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS40\KiSS4\KiSS4.Main\bin\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4\KiSS4.Main\bin\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRPanel hiderPanel;
        private DevExpress.XtraReports.UI.XRLabel hiderGBI_Anpassung_Bemerkung;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel hiderMiete_Bemerkung;
        private DevExpress.XtraReports.UI.XRLabel hiderGB_Typ;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader2;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader4;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader5;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader6;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader7;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter7;
        private DevExpress.XtraReports.UI.XRLabel txtGB_TypText;
        private DevExpress.XtraReports.UI.XRLabel Label8;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.XRLine Line4;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLabel txtUeWohnkosten;
        private DevExpress.XtraReports.UI.XRLabel txtUeZuschlagI;
        private DevExpress.XtraReports.UI.XRLabel txtUeGrundbedarf;
        private DevExpress.XtraReports.UI.XRLabel txtHgWohnkosten;
        private DevExpress.XtraReports.UI.XRLabel txtHgGrundbedarf;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.XRLabel Label5;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.XRLabel Label3;
        private DevExpress.XtraReports.UI.XRLabel Label2;
        private DevExpress.XtraReports.UI.XRLabel Label1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter6;
        private DevExpress.XtraReports.UI.XRLabel GBII_Betrag1;
        private DevExpress.XtraReports.UI.XRLabel GBIZusatz_Betrag1;
        private DevExpress.XtraReports.UI.XRLabel GBI_Betrag3;
        private DevExpress.XtraReports.UI.XRLabel txtTOTAL;
        private DevExpress.XtraReports.UI.XRLabel Label15;
        private DevExpress.XtraReports.UI.XRLabel txtGBI_Anpassung;
        private DevExpress.XtraReports.UI.XRLabel txtGBII_Betrag;
        private DevExpress.XtraReports.UI.XRLabel txtGBIZusatz_Betrag;
        private DevExpress.XtraReports.UI.XRLabel txtGBI_Betrag;
        private DevExpress.XtraReports.UI.XRLine Line6;
        private DevExpress.XtraReports.UI.XRLabel Label14;
        private DevExpress.XtraReports.UI.XRLine Line5;
        private DevExpress.XtraReports.UI.XRLabel Label13;
        private DevExpress.XtraReports.UI.XRLabel Label12;
        private DevExpress.XtraReports.UI.XRLabel Label11;
        private DevExpress.XtraReports.UI.XRLabel Label10;
        private DevExpress.XtraReports.UI.XRLabel Label9;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter5;
        private DevExpress.XtraReports.UI.XRLabel Label16;
        private DevExpress.XtraReports.UI.XRLabel GBI_Betrag1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter4;
        private DevExpress.XtraReports.UI.XRLabel Label17;
        private DevExpress.XtraReports.UI.XRLabel GBI_Betrag2;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter3;
        private DevExpress.XtraReports.UI.XRLabel txtGBI_Anpassung_Bemerkung;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter2;
        private DevExpress.XtraReports.UI.XRLabel Nebenkosten_Betrag1;
        private DevExpress.XtraReports.UI.XRLabel Miete_Betrag1;
        private DevExpress.XtraReports.UI.XRLabel Miete_Betrag_Eff1;
        private DevExpress.XtraReports.UI.XRLabel txtMiete_Betrag_Text;
        private DevExpress.XtraReports.UI.XRLabel txtBerechnungsgrundlage;
        private DevExpress.XtraReports.UI.XRLabel txtWohnsituation;
        private DevExpress.XtraReports.UI.XRLabel txtNebenkosten_Betrag;
        private DevExpress.XtraReports.UI.XRLabel txtMiete_Betrag;
        private DevExpress.XtraReports.UI.XRLabel txtMiete_Betrag_Eff;
        private DevExpress.XtraReports.UI.XRLabel TextBox1;
        private DevExpress.XtraReports.UI.XRLabel Label27;
        private DevExpress.XtraReports.UI.XRLine Line8;
        private DevExpress.XtraReports.UI.XRLine Line7;
        private DevExpress.XtraReports.UI.XRLabel Label25;
        private DevExpress.XtraReports.UI.XRLabel Label23;
        private DevExpress.XtraReports.UI.XRLabel Label22;
        private DevExpress.XtraReports.UI.XRLabel Label21;
        private DevExpress.XtraReports.UI.XRLabel Label20;
        private DevExpress.XtraReports.UI.XRLabel Label19;
        private DevExpress.XtraReports.UI.XRLabel Label18;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel txtMiete_Bemerkung;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAACAAAAAAAAAFBBRFBBRFATtE6kG" +
                        "I89VEUAAAAAAAAAQAEAAEBoAGkAZABlAHIARwBCAF8AVAB5AHAALgBTAGMAcgBpAHAAdABzAC4ATwBuA" +
                        "EEAZgB0AGUAcgBQAHIAaQBuAHQAAAAAADJzAHEAbABRAHUAZQByAHkAMQAuAFMAZQBsAGUAYwB0AFMAd" +
                        "ABhAHQAZQBtAGUAbgB0APECAAAB7gVwcml2YXRlIHZvaWQgT25BZnRlclByaW50KG9iamVjdCBzZW5kZ" +
                        "XIsIFN5c3RlbS5FdmVudEFyZ3MgZSkgew0KdHJ5IHsNCiAgICBHcm91cEZvb3RlcjYuVmlzaWJsZSA9I" +
                        "GZhbHNlOw0KICAgIEdyb3VwRm9vdGVyNS5WaXNpYmxlID0gZmFsc2U7DQogICAgR3JvdXBGb290ZXI0L" +
                        "lZpc2libGUgPSBmYWxzZTsNCg0KICAgIGludCBnYlR5cDsNCg0KICAgIGlmIChTdHJpbmcuSXNOdWxsT" +
                        "3JFbXB0eShoaWRlckdCX1R5cC5UZXh0KSkNCiAgICB7DQoJZ2JUeXAgPSAwOw0KICAgIH0NCiAgICBlb" +
                        "HNlDQogICAgew0KCWdiVHlwID0gaW50LlBhcnNlKGhpZGVyR0JfVHlwLlRleHQpOw0KICAgIH0gICAgD" +
                        "QoNCiAgICBpbnQgR0JfVHlwID0gZ2JUeXA7DQogICAgc3dpdGNoIChHQl9UeXApIHsNCiAgICAgIGNhc" +
                        "2UgMTogR3JvdXBGb290ZXI2LlZpc2libGUgPSB0cnVlOyBicmVhazsNCiAgICAgIGNhc2UgMjogR3Jvd" +
                        "XBGb290ZXI1LlZpc2libGUgPSB0cnVlOyBicmVhazsNCiAgICAgIGNhc2UgMzogR3JvdXBGb290ZXI0L" +
                        "lZpc2libGUgPSB0cnVlOyBicmVhazsNCiAgICB9DQogIH0NCiAgY2F0Y2ggKFN5c3RlbS5FeGNlcHRpb" +
                        "24gZXgpDQogIHsNCiAgICBTeXN0ZW0uV2luZG93cy5Gb3Jtcy5NZXNzYWdlQm94LlNob3coIkltIFJlc" +
                        "G9ydCBpc3QgZWluIFNrcmlwdC1GZWhsZXIgYXVmZ2V0cmV0ZW4uIChHQl9UeXAtIGhpZGVyLk9uQWZ0Z" +
                        "XJQcmludCkuIFN5c3RlbSBNZWxkdW5nOiAiKyBleC5NZXNzYWdlKTsNCiAgfQ0KDQoNCn0BjjNERUNMQ" +
                        "VJFIEBCZ0J1ZGdldElEIGludA0KDQpTRUxFQ1QgQEJnQnVkZ2V0SUQgPSBCZ0J1ZGdldElEDQpGUk9NI" +
                        "EJnQnVkZ2V0DQpXSEVSRSBCZ0ZpbmFuenBsYW5JRCA9IG51bGwgQU5EIE1hc3RlckJ1ZGdldCA9IDENC" +
                        "g0KREVDTEFSRSBAVUVfRmFjdG9yX1dvaG5rb3N0ZW4gZGVjaW1hbA0Kc2V0IEBVRV9GYWN0b3JfV29ob" +
                        "mtvc3RlbiA9IChzZWxlY3QgUm50SGdVZUZhY3RvciBmcm9tIGRiby5mbldoS2VubnphaGxlbihudWxsK" +
                        "SkNCg0KU0VMRUNUDQogIChTRUxFQ1QgQ291bnQoKikNCiAgIEZST00gQmdGaW5hbnpwbGFuX0JhUGVyc" +
                        "29uICAgIFNQUA0KICAgV0hFUkUgU1BQLkJnRmluYW56cGxhbklEID0gQkJHLkJnRmluYW56cGxhbklEK" +
                        "SAgICAgICAgICAgICAgICAgICAgICAgICAgICBBUyBIZ0dydW5kYmVkYXJmLA0KDQogIChTRUxFQ1QgU" +
                        "1VNKENBU0UgV0hFTiBkYm8uZm5HZXRBZ2UoUFJTLkdlYnVydHNkYXR1bSwgU0ZQLkRhdHVtVm9uKSA8I" +
                        "GRiby5mblhDb25maWcoJ1N5c3RlbVxTb3ppYWxoaWxmZVxTS09TXEY1MV9BZ2UnLCBTRlAuRGF0dW1Wb" +
                        "24pDQogICAgICAgICAgICAgICAgVEhFTiBDQVNUKGRiby5mblhDb25maWcoJ1N5c3RlbVxTb3ppYWxoa" +
                        "WxmZVxTS09TXEY1MV9GYWN0b3InLCBTRlAuRGF0dW1Wb24pIEFTIGZsb2F0KQ0KICAgICAgICAgICAgI" +
                        "CAgIEVMU0UgMQ0KICAgICAgICAgICAgICBFTkQpDQogICBGUk9NIEJnRmluYW56cGxhbl9CYVBlcnNvb" +
                        "iAgICBTUFANCiAgICAgSU5ORVIgSk9JTiBCZ0ZpbmFuenBsYW4gICAgICBTRlAgT04gU0ZQLkJnRmluY" +
                        "W56cGxhbklEID0gU1BQLkJnRmluYW56cGxhbklEDQogICAgIElOTkVSIEpPSU4gQmFQZXJzb24gICAgI" +
                        "CAgICBQUlMgT04gUFJTLkJhUGVyc29uSUQgICAgPSBTUFAuQmFQZXJzb25JRA0KICAgV0hFUkUgU1BQL" +
                        "kJnRmluYW56cGxhbklEID0gQkJHLkJnRmluYW56cGxhbklEKSAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICBBUyBIZ1dvaG5rb3N0ZW4sDQoNCiAgKFNFTEVDVCBDb3VudCgqKQ0KICAgRlJPTSBCZ0ZpbmFue" +
                        "nBsYW5fQmFQZXJzb24gICAgU1BQDQogICBXSEVSRSBTUFAuQmdGaW5hbnpwbGFuSUQgPSBCQkcuQmdGa" +
                        "W5hbnpwbGFuSUQgQU5EIFNQUC5Jc3RVbnRlcnN0dWV0enQgPSAxKSBBUyBVZUdydW5kYmVkYXJmLA0KD" +
                        "QogIChTRUxFQ1QgU1VNKENBU0UgV0hFTiBkYm8uZm5HZXRBZ2UoUFJTLkdlYnVydHNkYXR1bSwgU0ZQL" +
                        "kRhdHVtVm9uKSA8IGRiby5mblhDb25maWcoJ1N5c3RlbVxTb3ppYWxoaWxmZVxTS09TXEY1MV9BZ2UnL" +
                        "CBTRlAuRGF0dW1Wb24pDQogICAgICAgICAgICAgICAgVEhFTiBDQVNUKGRiby5mblhDb25maWcoJ1N5c" +
                        "3RlbVxTb3ppYWxoaWxmZVxTS09TXEY1MV9GYWN0b3InLCBTRlAuRGF0dW1Wb24pIEFTIGZsb2F0KQ0KI" +
                        "CAgICAgICAgICAgICAgIEVMU0UgMQ0KICAgICAgICAgICAgICBFTkQpDQogICBGUk9NIEJnRmluYW56c" +
                        "Gxhbl9CYVBlcnNvbiAgICBTUFANCiAgICAgSU5ORVIgSk9JTiBCZ0ZpbmFuenBsYW4gICAgICBTRlAgT" +
                        "04gU0ZQLkJnRmluYW56cGxhbklEID0gU1BQLkJnRmluYW56cGxhbklEDQogICAgIElOTkVSIEpPSU4gQ" +
                        "mFQZXJzb24gICAgICAgICBQUlMgT04gUFJTLkJhUGVyc29uSUQgICAgPSBTUFAuQmFQZXJzb25JRA0KI" +
                        "CAgV0hFUkUgU1BQLkJnRmluYW56cGxhbklEID0gQkJHLkJnRmluYW56cGxhbklEIEFORCBTUFAuSXN0V" +
                        "W50ZXJzdHVldHp0ID0gMSkgQVMgVWVXb2hua29zdGVuLA0KDQogIChTRUxFQ1QgQ0FTRSBXSEVOIGRib" +
                        "y5mblhDb25maWcoJ1N5c3RlbVxTb3ppYWxoaWxmZVxTS09TXEIyM19PZmZzZXQnLCBNQVgoU0ZQLkRhd" +
                        "HVtVm9uKSkgPiBDb3VudCgqKQ0KICAgICAgICAgICAgVEhFTiAwDQogICAgICAgICAgICBFTFNFIENvd" +
                        "W50KCopIC0gSXNOdWxsKENBU1QoZGJvLmZuWENvbmZpZygnU3lzdGVtXFNvemlhbGhpbGZlXFNLT1NcQ" +
                        "jIzX09mZnNldCcsIE1BWChTRlAuRGF0dW1Wb24pKSBBUyBmbG9hdCksIDApDQogICAgICAgICAgRU5ED" +
                        "QogICBGUk9NIEJnRmluYW56cGxhbl9CYVBlcnNvbiAgICBTUFANCiAgICAgSU5ORVIgSk9JTiBCZ0Zpb" +
                        "mFuenBsYW4gICAgICBTRlAgT04gU0ZQLkJnRmluYW56cGxhbklEID0gU1BQLkJnRmluYW56cGxhbklED" +
                        "QogICAgIElOTkVSIEpPSU4gQmFQZXJzb24gICAgICAgICBQUlMgT04gUFJTLkJhUGVyc29uSUQgICAgP" +
                        "SBTUFAuQmFQZXJzb25JRA0KICAgV0hFUkUgU1BQLkJnRmluYW56cGxhbklEID0gQkJHLkJnRmluYW56c" +
                        "GxhbklEIEFORCBTUFAuSXN0VW50ZXJzdHVldHp0ID0gMQ0KICAgICBBTkQgZGJvLmZuR2V0QWdlKFBSU" +
                        "y5HZWJ1cnRzZGF0dW0sIFNGUC5EYXR1bVZvbikgPj0gQ0FTVChkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cU" +
                        "296aWFsaGlsZmVcU0tPU1xCMjNfQWdlJywgU0ZQLkRhdHVtVm9uKSBBUyBpbnQpKSBBUyBVZVp1c2Nob" +
                        "GFnSSwNCg0KICAgW0dCX1R5cF0gICAgICAgICAgICAgICAgICA9IEJQT19HQkkuQmdQb3NpdGlvbnNhc" +
                        "nRJRCwNCiAgIFtHQl9UeXBUZXh0XSAgICAgICAgICAgICAgPSBYTENfR0IuVGV4dCwNCiAgIFtHQklfQ" +
                        "mV0cmFnXSAgICAgICAgICAgICAgPSBCUE9fR0JJLkJldHJhZywNCiAgIFtHQkladXNhdHpfQmV0cmFnX" +
                        "SAgICAgICAgPSBCUE9fR0JJWi5CZXRyYWcsDQogICBbR0JJSV9CZXRyYWddICAgICAgICAgICAgID0gQ" +
                        "lBPX0dCSUkuQmV0cmFnLA0KICAgW0dCSV9BbnBhc3N1bmddICAgICAgICAgICA9IC1CUE9fR0JJLlJlZ" +
                        "HVrdGlvbiwNCiAgIFtHQklfQW5wYXNzdW5nX0JlbWVya3VuZ10gPSBCUE9fR0JJLkJlbWVya3VuZywNC" +
                        "g0KICAgW1dvaG5zaXR1YXRpb25dICAgICAgICA9IFNVQlNUUklORyhOYW1lLCAxLCBDSEFSSU5ERVgoJ" +
                        "yAtJywgTmFtZSkgLSAxKSwNCiAgIFtCZXJlY2hudW5nc2dydW5kbGFnZV0gPSAnV29obmtvc3RlbiAnI" +
                        "CsgQ0FTRSBCUE9fTUsuQmdQb3NpdGlvbnNhcnRJRCAlIDIgV0hFTiAwIFRIRU4gJ2dlbS4gUmljaHRsa" +
                        "W5pZW4nIEVMU0UgJ2luZGl2aWR1ZWxsJyBFTkQgKyAnIGJlc3RpbW1lbicsDQogICBbTWlldGVfQmV0c" +
                        "mFnX0VmZl0gICAgID0gQlBPX01LLkJldHJhZywNCiAgIFtNaWV0ZV9CZXRyYWdfVGV4dF0gICAgPSAnQ" +
                        "W5zYXR6ICcgKyBDQVNFIEJQT19NSy5CZ1Bvc2l0aW9uc2FydElEICUgMiBXSEVOIDAgVEhFTiAnZ2VtL" +
                        "iBSaWNodGxpbmllbicgRUxTRSAnaW5kaXZpZHVlbGwnIEVORCwNCiAgIFtNaWV0ZV9CZXRyYWddICAgI" +
                        "CAgICAgPSBDQVNFIFdIRU4gQlBPX01LLkJldHJhZyA+IEJQT19NSy5NYXhCZWl0cmFnU0QgVEhFTiBCU" +
                        "E9fTUsuTWF4QmVpdHJhZ1NEIEVMU0UgQlBPX01LLkJldHJhZyBFTkQsDQogICBbTmViZW5rb3N0ZW5fQ" +
                        "mV0cmFnXSAgID0gQlBPX01OSy5CZXRyYWcsDQogICBbTWlldGVfQmVtZXJrdW5nXSAgICAgID0gQlBPX" +
                        "01LLkJlbWVya3VuZywNCiAgIFVFX0dCSV9CZXRyYWcgICAgICAgICAgPSBkYm8uZm5TaEdydW5kYmVkY" +
                        "XJmSShCQkcuQmdGaW5hbnpwbGFuSUQpLA0KICAgVUVfR0JJX1p1c2F0el9CZXRyYWcgICA9IGRiby5mb" +
                        "lNoR3J1bmRiZWRhcmZJWnVzY2hsYWcoQkJHLkJnRmluYW56cGxhbklEKSwNCiAgIFVFX0dCSUlfQmV0c" +
                        "mFnICAgICAgICAgPSBDQVNFIFdIRU4gQlBPX0dCSUkuQmdQb3NpdGlvbnNhcnRJRCA9IDMNCiAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICBUSEVOIGRiby5mblNoR3J1bmRiZWRhcmZJSShCQkcuQmdGaW5hb" +
                        "npwbGFuSUQsMSkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTFNFIGRiby5mblNoR3J1bmRiZ" +
                        "WRhcmZJSShCQkcuQmdGaW5hbnpwbGFuSUQsMCkgLS0ga2VpbmUgS29wZnRlaWx1bmcNCiAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICBFTkQsDQogICBVRV9GYWN0b3JfV29obmtvc3RlbiAgID0gQFVFX0ZhY" +
                        "3Rvcl9Xb2hua29zdGVuLA0KICAgVG90YWxHcnVuZGJlZGFyZiAgICAgICA9IGRiby5mblNoR3J1bmRiZ" +
                        "WRhcmZJKEJCRy5CZ0ZpbmFuenBsYW5JRCkgKyAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgIGRiby5mblNoR3J1bmRiZWRhcmZJWnVzY2hsYWcoQkJHLkJnR" +
                        "mluYW56cGxhbklEKSArDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgQ0FTRSBXSEVOIEJQT19HQ" +
                        "klJLkJnUG9zaXRpb25zYXJ0SUQgPSAzDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgVEhFTiBkYm8uZm5TaEdydW5kYmVkYXJmSUkoQkJHLkJnRmluYW56cGxhbklELDEpDQogICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICBFTFNFIGRiby5mblNoR3J1bmRiZWRhcmZJSShCQkcuQmdGa" +
                        "W5hbnpwbGFuSUQsMCkgLS0ga2VpbmUgS29wZnRlaWx1bmcNCiAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICBFTkQgLQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgIEJQT19HQkkuUmVkdWt0aW9uLA0KD" +
                        "QogICBBbmdlcmVjaG5XS0FudGVpbCAgICAgID0gKCBDQVNFIFdIRU4gQlBPX01LLkJldHJhZyA+IEJQT" +
                        "19NSy5NYXhCZWl0cmFnU0QgVEhFTiBCUE9fTUsuTWF4QmVpdHJhZ1NEIEVMU0UgQlBPX01LLkJldHJhZ" +
                        "yBFTkQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICArIEJQT19NTksuQmV0cmFnDQogICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgKQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICogQFVFX0ZhY" +
                        "3Rvcl9Xb2hua29zdGVuLA0KICAgW01pZXRlX0JldHJhZ19FZmYxXSAgICA9IEJQT19NSy5CZXRyYWcgK" +
                        "g0KICAgICAgICAgICAgICAgICAgICAgICAgICAgIEBVRV9GYWN0b3JfV29obmtvc3RlbiwNCiAgIFtNa" +
                        "WV0ZV9CZXRyYWcxXSAgICAgICAgID0gQ0FTRSBXSEVOIEJQT19NSy5CZXRyYWcgPiBCUE9fTUsuTWF4Q" +
                        "mVpdHJhZ1NEIFRIRU4gQlBPX01LLk1heEJlaXRyYWdTRCBFTFNFIEJQT19NSy5CZXRyYWcgRU5EICoNC" +
                        "iAgICAgICAgICAgICAgICAgICAgICAgICAgICBAVUVfRmFjdG9yX1dvaG5rb3N0ZW4sDQogICBbTmViZ" +
                        "W5rb3N0ZW5fQmV0cmFnXSAgID0gQlBPX01OSy5CZXRyYWcgKg0KICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgIEBVRV9GYWN0b3JfV29obmtvc3Rlbg0KRlJPTSBCZ0J1ZGdldCAgQkJHDQogIExFRlQgIEpPS" +
                        "U4gQmdQb3NpdGlvbiAgICAgQlBPX0dCSSAgT04gQlBPX0dCSS5CZ0J1ZGdldElEICA9IEJCRy5CZ0J1Z" +
                        "GdldElEDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEJQT19HQkkuQ" +
                        "mdQb3NpdGlvbnNhcnRJRCBJTiAoU0VMRUNUIEJnUG9zaXRpb25zYXJ0SUQgRlJPTSBXaFBvc2l0aW9uc" +
                        "2FydA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgV0hFUkUgQmdHcnVwcGVDb2RlID0gNSBBTkQgU29ydEtleSA9IDEpDQogI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEJQT19HQkkuRGF0dW1Wb24gS" +
                        "VMgTlVMTA0KICBMRUZUICBKT0lOIFhMT1ZDb2RlICAgICAgIFhMQ19HQiAgIE9OIFhMQ19HQi5MT1ZOY" +
                        "W1lID0gJ1doR3J1bmRiZWRhcmZUeXAnIEFORCBYTENfR0IuQ29kZSA9IEJQT19HQkkuQmdQb3NpdGlvb" +
                        "nNhcnRJRA0KICBMRUZUICBKT0lOIEJnUG9zaXRpb24gICAgIEJQT19HQklaIE9OIEJQT19HQklaLkJnQ" +
                        "nVkZ2V0SUQgPSBCQkcuQmdCdWRnZXRJRCBBTkQgQlBPX0dCSVouQmdQb3NpdGlvbnNhcnRJRCA9IDINC" +
                        "iAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgQlBPX0dCSVouRGF0dW1Wb" +
                        "24gSVMgTlVMTA0KICBMRUZUICBKT0lOIEJnUG9zaXRpb24gICAgIEJQT19HQklJIE9OIEJQT19HQklJL" +
                        "kJnQnVkZ2V0SUQgPSBCQkcuQmdCdWRnZXRJRCBBTkQgQlBPX0dCSUkuQmdQb3NpdGlvbnNhcnRJRCBJT" +
                        "iAoMywgNCkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgQlBPX0dCS" +
                        "UkuRGF0dW1Wb24gSVMgTlVMTA0KDQogIExFRlQgIEpPSU4gQmdQb3NpdGlvbiAgICAgQlBPX01LICBPT" +
                        "iBCUE9fTUsuQmdCdWRnZXRJRCAgID0gQkJHLkJnQnVkZ2V0SUQgQU5EIEJQT19NSy5CZ1Bvc2l0aW9uc" +
                        "2FydElEIEJFVFdFRU4gNjIgQU5EIDk5DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICBBTkQgR2V0RGF0ZSgpIEJFVFdFRU4gSXNOdWxsKEJQT19NSy5EYXR1bVZvbiwgJzE5MDAwMTAxJ" +
                        "ykgIEFORCBJc051bGwoQlBPX01LLkRhdHVtQmlzLCBHZXREYXRlKCkpDQogIExFRlQgIEpPSU4gV2hQb" +
                        "3NpdGlvbnNhcnQgU1BUX01LICBPTiBTUFRfTUsuQmdQb3NpdGlvbnNhcnRJRCA9IEJQT19NSy5CZ1Bvc" +
                        "2l0aW9uc2FydElEDQogIExFRlQgIEpPSU4gQmdQb3NpdGlvbiAgICAgQlBPX01OSyBPTiBCUE9fTU5LL" +
                        "kJnQnVkZ2V0SUQgID0gQkJHLkJnQnVkZ2V0SUQgQU5EIEJQT19NTksuQmdQb3NpdGlvbnNhcnRJRCA9I" +
                        "DYwDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgR2V0RGF0ZSgpIEJFV" +
                        "FdFRU4gSXNOdWxsKEJQT19NTksuRGF0dW1Wb24sICcxOTAwMDEwMScpIEFORCBJc051bGwoQlBPX01OS" +
                        "y5EYXR1bUJpcywgR2V0RGF0ZSgpKQ0KV0hFUkUgQkJHLkJnQnVkZ2V0SUQgPSBAQmdCdWRnZXRJRA==";
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
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary10 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary11 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary12 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary13 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary14 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary15 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary16 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary17 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary18 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary19 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary20 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary21 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary22 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader5 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader6 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader7 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter7 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter6 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter5 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter4 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter3 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.hiderPanel = new DevExpress.XtraReports.UI.XRPanel();
            this.hiderGBI_Anpassung_Bemerkung = new DevExpress.XtraReports.UI.XRLabel();
            this.hiderMiete_Bemerkung = new DevExpress.XtraReports.UI.XRLabel();
            this.hiderGB_Typ = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGB_TypText = new DevExpress.XtraReports.UI.XRLabel();
            this.Label8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line4 = new DevExpress.XtraReports.UI.XRLine();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.txtUeWohnkosten = new DevExpress.XtraReports.UI.XRLabel();
            this.txtUeZuschlagI = new DevExpress.XtraReports.UI.XRLabel();
            this.txtUeGrundbedarf = new DevExpress.XtraReports.UI.XRLabel();
            this.txtHgWohnkosten = new DevExpress.XtraReports.UI.XRLabel();
            this.txtHgGrundbedarf = new DevExpress.XtraReports.UI.XRLabel();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GBII_Betrag1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GBIZusatz_Betrag1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GBI_Betrag3 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTOTAL = new DevExpress.XtraReports.UI.XRLabel();
            this.Label15 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGBI_Anpassung = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGBII_Betrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGBIZusatz_Betrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGBI_Betrag = new DevExpress.XtraReports.UI.XRLabel();
            this.Line6 = new DevExpress.XtraReports.UI.XRLine();
            this.Label14 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line5 = new DevExpress.XtraReports.UI.XRLine();
            this.Label13 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label12 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label11 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label10 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label9 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label16 = new DevExpress.XtraReports.UI.XRLabel();
            this.GBI_Betrag1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label17 = new DevExpress.XtraReports.UI.XRLabel();
            this.GBI_Betrag2 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGBI_Anpassung_Bemerkung = new DevExpress.XtraReports.UI.XRLabel();
            this.Nebenkosten_Betrag1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Miete_Betrag1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Miete_Betrag_Eff1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtMiete_Betrag_Text = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBerechnungsgrundlage = new DevExpress.XtraReports.UI.XRLabel();
            this.txtWohnsituation = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNebenkosten_Betrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtMiete_Betrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtMiete_Betrag_Eff = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label27 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line8 = new DevExpress.XtraReports.UI.XRLine();
            this.Line7 = new DevExpress.XtraReports.UI.XRLine();
            this.Label25 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label23 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label22 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label21 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label20 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label19 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label18 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtMiete_Bemerkung = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
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
                        this.hiderPanel});
            this.PageHeader.Height = 40;
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
            this.GroupHeader1.Height = 0;
            this.GroupHeader1.Level = 6;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Height = 0;
            this.GroupHeader2.Level = 5;
            this.GroupHeader2.Name = "GroupHeader2";
            this.GroupHeader2.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader2.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader2.ParentStyleUsing.UseBorders = false;
            this.GroupHeader2.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader2.ParentStyleUsing.UseFont = false;
            this.GroupHeader2.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.Height = 0;
            this.GroupHeader3.Level = 4;
            this.GroupHeader3.Name = "GroupHeader3";
            this.GroupHeader3.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader3.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader3.ParentStyleUsing.UseBorders = false;
            this.GroupHeader3.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader3.ParentStyleUsing.UseFont = false;
            this.GroupHeader3.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Height = 0;
            this.GroupHeader4.Level = 3;
            this.GroupHeader4.Name = "GroupHeader4";
            this.GroupHeader4.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader4.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader4.ParentStyleUsing.UseBorders = false;
            this.GroupHeader4.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader4.ParentStyleUsing.UseFont = false;
            this.GroupHeader4.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader5
            // 
            this.GroupHeader5.Height = 0;
            this.GroupHeader5.Level = 2;
            this.GroupHeader5.Name = "GroupHeader5";
            this.GroupHeader5.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader5.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader5.ParentStyleUsing.UseBorders = false;
            this.GroupHeader5.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader5.ParentStyleUsing.UseFont = false;
            this.GroupHeader5.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader6
            // 
            this.GroupHeader6.Height = 0;
            this.GroupHeader6.Level = 1;
            this.GroupHeader6.Name = "GroupHeader6";
            this.GroupHeader6.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader6.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader6.ParentStyleUsing.UseBorders = false;
            this.GroupHeader6.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader6.ParentStyleUsing.UseFont = false;
            this.GroupHeader6.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader7
            // 
            this.GroupHeader7.Height = 0;
            this.GroupHeader7.Name = "GroupHeader7";
            this.GroupHeader7.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader7.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader7.ParentStyleUsing.UseBorders = false;
            this.GroupHeader7.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader7.ParentStyleUsing.UseFont = false;
            this.GroupHeader7.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter7
            // 
            this.GroupFooter7.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtGB_TypText,
                        this.Label8,
                        this.Label7,
                        this.Line4,
                        this.Line3,
                        this.txtUeWohnkosten,
                        this.txtUeZuschlagI,
                        this.txtUeGrundbedarf,
                        this.txtHgWohnkosten,
                        this.txtHgGrundbedarf,
                        this.Label6,
                        this.Label5,
                        this.Label4,
                        this.Label3,
                        this.Label2,
                        this.Label1});
            this.GroupFooter7.Height = 232;
            this.GroupFooter7.Name = "GroupFooter7";
            this.GroupFooter7.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter7.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter7.ParentStyleUsing.UseBorders = false;
            this.GroupFooter7.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter7.ParentStyleUsing.UseFont = false;
            this.GroupFooter7.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter6
            // 
            this.GroupFooter6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.GBII_Betrag1,
                        this.GBIZusatz_Betrag1,
                        this.GBI_Betrag3,
                        this.txtTOTAL,
                        this.Label15,
                        this.txtGBI_Anpassung,
                        this.txtGBII_Betrag,
                        this.txtGBIZusatz_Betrag,
                        this.txtGBI_Betrag,
                        this.Line6,
                        this.Label14,
                        this.Line5,
                        this.Label13,
                        this.Label12,
                        this.Label11,
                        this.Label10,
                        this.Label9});
            this.GroupFooter6.Height = 157;
            this.GroupFooter6.Level = 1;
            this.GroupFooter6.Name = "GroupFooter6";
            this.GroupFooter6.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter6.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter6.ParentStyleUsing.UseBorders = false;
            this.GroupFooter6.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter6.ParentStyleUsing.UseFont = false;
            this.GroupFooter6.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter5
            // 
            this.GroupFooter5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Label16,
                        this.GBI_Betrag1});
            this.GroupFooter5.Height = 47;
            this.GroupFooter5.Level = 2;
            this.GroupFooter5.Name = "GroupFooter5";
            this.GroupFooter5.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter5.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter5.ParentStyleUsing.UseBorders = false;
            this.GroupFooter5.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter5.ParentStyleUsing.UseFont = false;
            this.GroupFooter5.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter4
            // 
            this.GroupFooter4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Label17,
                        this.GBI_Betrag2});
            this.GroupFooter4.Height = 47;
            this.GroupFooter4.Level = 3;
            this.GroupFooter4.Name = "GroupFooter4";
            this.GroupFooter4.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter4.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter4.ParentStyleUsing.UseBorders = false;
            this.GroupFooter4.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter4.ParentStyleUsing.UseFont = false;
            this.GroupFooter4.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter3
            // 
            this.GroupFooter3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtGBI_Anpassung_Bemerkung});
            this.GroupFooter3.Height = 47;
            this.GroupFooter3.Level = 4;
            this.GroupFooter3.Name = "GroupFooter3";
            this.GroupFooter3.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter3.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter3.ParentStyleUsing.UseBorders = false;
            this.GroupFooter3.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter3.ParentStyleUsing.UseFont = false;
            this.GroupFooter3.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Nebenkosten_Betrag1,
                        this.Miete_Betrag1,
                        this.Miete_Betrag_Eff1,
                        this.txtMiete_Betrag_Text,
                        this.txtBerechnungsgrundlage,
                        this.txtWohnsituation,
                        this.txtNebenkosten_Betrag,
                        this.txtMiete_Betrag,
                        this.txtMiete_Betrag_Eff,
                        this.TextBox1,
                        this.Label27,
                        this.Line8,
                        this.Line7,
                        this.Label25,
                        this.Label23,
                        this.Label22,
                        this.Label21,
                        this.Label20,
                        this.Label19,
                        this.Label18});
            this.GroupFooter2.Height = 240;
            this.GroupFooter2.Level = 5;
            this.GroupFooter2.Name = "GroupFooter2";
            this.GroupFooter2.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter2.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter2.ParentStyleUsing.UseBorders = false;
            this.GroupFooter2.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter2.ParentStyleUsing.UseFont = false;
            this.GroupFooter2.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtMiete_Bemerkung});
            this.GroupFooter1.Height = 47;
            this.GroupFooter1.Level = 6;
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
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // hiderPanel
            // 
            this.hiderPanel.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.hiderGBI_Anpassung_Bemerkung,
                        this.hiderMiete_Bemerkung,
                        this.hiderGB_Typ});
            this.hiderPanel.Location = new System.Drawing.Point(160, 0);
            this.hiderPanel.Name = "hiderPanel";
            this.hiderPanel.Size = new System.Drawing.Size(373, 40);
            this.hiderPanel.Visible = false;
            // 
            // hiderGBI_Anpassung_Bemerkung
            // 
            this.hiderGBI_Anpassung_Bemerkung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GBI_Anpassung_Bemerkung", "")});
            this.hiderGBI_Anpassung_Bemerkung.Location = new System.Drawing.Point(227, 0);
            this.hiderGBI_Anpassung_Bemerkung.Name = "hiderGBI_Anpassung_Bemerkung";
            this.hiderGBI_Anpassung_Bemerkung.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hiderGBI_Anpassung_Bemerkung.Scripts.OnAfterPrint = "private void OnAfterPrint(object sender, System.EventArgs e) {\r\n   GroupFooter3.V" +
                "isible = hiderGBI_Anpassung_Bemerkung.Text != String.Empty;\r\n}";
            this.hiderGBI_Anpassung_Bemerkung.Size = new System.Drawing.Size(133, 20);
            // 
            // hiderMiete_Bemerkung
            // 
            this.hiderMiete_Bemerkung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Miete_Bemerkung", "")});
            this.hiderMiete_Bemerkung.Location = new System.Drawing.Point(113, 0);
            this.hiderMiete_Bemerkung.Name = "hiderMiete_Bemerkung";
            this.hiderMiete_Bemerkung.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hiderMiete_Bemerkung.Scripts.OnAfterPrint = "private void OnAfterPrint(object sender, System.EventArgs e) {\r\n    GroupFooter1." +
                "Visible = hiderMiete_Bemerkung.Text != String.Empty;\r\n}";
            this.hiderMiete_Bemerkung.Size = new System.Drawing.Size(100, 13);
            // 
            // hiderGB_Typ
            // 
            this.hiderGB_Typ.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GB_Typ", "")});
            this.hiderGB_Typ.Location = new System.Drawing.Point(0, 0);
            this.hiderGB_Typ.Name = "hiderGB_Typ";
            this.hiderGB_Typ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hiderGB_Typ.Scripts.OnAfterPrint = resources.GetString("hiderGB_Typ.Scripts.OnAfterPrint");
            this.hiderGB_Typ.Size = new System.Drawing.Size(100, 13);
            // 
            // txtGB_TypText
            // 
            this.txtGB_TypText.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GB_TypText", "")});
            this.txtGB_TypText.Font = new System.Drawing.Font("Arial", 10F);
            this.txtGB_TypText.ForeColor = System.Drawing.Color.Black;
            this.txtGB_TypText.Location = new System.Drawing.Point(149, 185);
            this.txtGB_TypText.Multiline = true;
            this.txtGB_TypText.Name = "txtGB_TypText";
            this.txtGB_TypText.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGB_TypText.ParentStyleUsing.UseBackColor = false;
            this.txtGB_TypText.ParentStyleUsing.UseBorderColor = false;
            this.txtGB_TypText.ParentStyleUsing.UseBorders = false;
            this.txtGB_TypText.ParentStyleUsing.UseBorderWidth = false;
            this.txtGB_TypText.ParentStyleUsing.UseFont = false;
            this.txtGB_TypText.ParentStyleUsing.UseForeColor = false;
            this.txtGB_TypText.Size = new System.Drawing.Size(496, 19);
            this.txtGB_TypText.Text = "GB_TypText";
            // 
            // Label8
            // 
            this.Label8.Font = new System.Drawing.Font("Arial", 10F);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(0, 185);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(149, 19);
            this.Label8.Text = "Berechnungsgrundlage";
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(0, 157);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(149, 19);
            this.Label7.Text = "Grundbedarf";
            // 
            // Line4
            // 
            this.Line4.ForeColor = System.Drawing.Color.Black;
            this.Line4.Location = new System.Drawing.Point(0, 118);
            this.Line4.Name = "Line4";
            this.Line4.ParentStyleUsing.UseBackColor = false;
            this.Line4.ParentStyleUsing.UseBorderColor = false;
            this.Line4.ParentStyleUsing.UseBorders = false;
            this.Line4.ParentStyleUsing.UseBorderWidth = false;
            this.Line4.ParentStyleUsing.UseFont = false;
            this.Line4.ParentStyleUsing.UseForeColor = false;
            this.Line4.Size = new System.Drawing.Size(629, 2);
            // 
            // Line3
            // 
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.Location = new System.Drawing.Point(0, 55);
            this.Line3.Name = "Line3";
            this.Line3.ParentStyleUsing.UseBackColor = false;
            this.Line3.ParentStyleUsing.UseBorderColor = false;
            this.Line3.ParentStyleUsing.UseBorders = false;
            this.Line3.ParentStyleUsing.UseBorderWidth = false;
            this.Line3.ParentStyleUsing.UseFont = false;
            this.Line3.ParentStyleUsing.UseForeColor = false;
            this.Line3.Size = new System.Drawing.Size(629, 2);
            // 
            // txtUeWohnkosten
            // 
            this.txtUeWohnkosten.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "UeWohnkosten", "{0:n2}")});
            this.txtUeWohnkosten.Font = new System.Drawing.Font("Arial", 10F);
            this.txtUeWohnkosten.ForeColor = System.Drawing.Color.Black;
            this.txtUeWohnkosten.Location = new System.Drawing.Point(472, 98);
            this.txtUeWohnkosten.Multiline = true;
            this.txtUeWohnkosten.Name = "txtUeWohnkosten";
            this.txtUeWohnkosten.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtUeWohnkosten.ParentStyleUsing.UseBackColor = false;
            this.txtUeWohnkosten.ParentStyleUsing.UseBorderColor = false;
            this.txtUeWohnkosten.ParentStyleUsing.UseBorders = false;
            this.txtUeWohnkosten.ParentStyleUsing.UseBorderWidth = false;
            this.txtUeWohnkosten.ParentStyleUsing.UseFont = false;
            this.txtUeWohnkosten.ParentStyleUsing.UseForeColor = false;
            this.txtUeWohnkosten.Size = new System.Drawing.Size(98, 19);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtUeWohnkosten.Summary = xrSummary1;
            this.txtUeWohnkosten.Text = "UeWohnkosten";
            this.txtUeWohnkosten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtUeZuschlagI
            // 
            this.txtUeZuschlagI.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "UeZuschlagI", "{0:n2}")});
            this.txtUeZuschlagI.Font = new System.Drawing.Font("Arial", 10F);
            this.txtUeZuschlagI.ForeColor = System.Drawing.Color.Black;
            this.txtUeZuschlagI.Location = new System.Drawing.Point(472, 78);
            this.txtUeZuschlagI.Multiline = true;
            this.txtUeZuschlagI.Name = "txtUeZuschlagI";
            this.txtUeZuschlagI.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtUeZuschlagI.ParentStyleUsing.UseBackColor = false;
            this.txtUeZuschlagI.ParentStyleUsing.UseBorderColor = false;
            this.txtUeZuschlagI.ParentStyleUsing.UseBorders = false;
            this.txtUeZuschlagI.ParentStyleUsing.UseBorderWidth = false;
            this.txtUeZuschlagI.ParentStyleUsing.UseFont = false;
            this.txtUeZuschlagI.ParentStyleUsing.UseForeColor = false;
            this.txtUeZuschlagI.Size = new System.Drawing.Size(98, 19);
            xrSummary2.FormatString = "{0:#,##0.00}";
            this.txtUeZuschlagI.Summary = xrSummary2;
            this.txtUeZuschlagI.Text = "UeZuschlagI";
            this.txtUeZuschlagI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtUeGrundbedarf
            // 
            this.txtUeGrundbedarf.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "UeGrundbedarf", "{0:n2}")});
            this.txtUeGrundbedarf.Font = new System.Drawing.Font("Arial", 10F);
            this.txtUeGrundbedarf.ForeColor = System.Drawing.Color.Black;
            this.txtUeGrundbedarf.Location = new System.Drawing.Point(472, 59);
            this.txtUeGrundbedarf.Multiline = true;
            this.txtUeGrundbedarf.Name = "txtUeGrundbedarf";
            this.txtUeGrundbedarf.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtUeGrundbedarf.ParentStyleUsing.UseBackColor = false;
            this.txtUeGrundbedarf.ParentStyleUsing.UseBorderColor = false;
            this.txtUeGrundbedarf.ParentStyleUsing.UseBorders = false;
            this.txtUeGrundbedarf.ParentStyleUsing.UseBorderWidth = false;
            this.txtUeGrundbedarf.ParentStyleUsing.UseFont = false;
            this.txtUeGrundbedarf.ParentStyleUsing.UseForeColor = false;
            this.txtUeGrundbedarf.Size = new System.Drawing.Size(98, 19);
            xrSummary3.FormatString = "{0:#,##0.00}";
            this.txtUeGrundbedarf.Summary = xrSummary3;
            this.txtUeGrundbedarf.Text = "UeGrundbedarf";
            this.txtUeGrundbedarf.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtHgWohnkosten
            // 
            this.txtHgWohnkosten.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "HgWohnkosten", "{0:n2}")});
            this.txtHgWohnkosten.Font = new System.Drawing.Font("Arial", 10F);
            this.txtHgWohnkosten.ForeColor = System.Drawing.Color.Black;
            this.txtHgWohnkosten.Location = new System.Drawing.Point(236, 98);
            this.txtHgWohnkosten.Multiline = true;
            this.txtHgWohnkosten.Name = "txtHgWohnkosten";
            this.txtHgWohnkosten.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtHgWohnkosten.ParentStyleUsing.UseBackColor = false;
            this.txtHgWohnkosten.ParentStyleUsing.UseBorderColor = false;
            this.txtHgWohnkosten.ParentStyleUsing.UseBorders = false;
            this.txtHgWohnkosten.ParentStyleUsing.UseBorderWidth = false;
            this.txtHgWohnkosten.ParentStyleUsing.UseFont = false;
            this.txtHgWohnkosten.ParentStyleUsing.UseForeColor = false;
            this.txtHgWohnkosten.Size = new System.Drawing.Size(98, 19);
            xrSummary4.FormatString = "{0:#,##0.00}";
            this.txtHgWohnkosten.Summary = xrSummary4;
            this.txtHgWohnkosten.Text = "HgWohnkosten";
            this.txtHgWohnkosten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtHgGrundbedarf
            // 
            this.txtHgGrundbedarf.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "HgGrundbedarf", "{0:n2}")});
            this.txtHgGrundbedarf.Font = new System.Drawing.Font("Arial", 10F);
            this.txtHgGrundbedarf.ForeColor = System.Drawing.Color.Black;
            this.txtHgGrundbedarf.Location = new System.Drawing.Point(236, 59);
            this.txtHgGrundbedarf.Multiline = true;
            this.txtHgGrundbedarf.Name = "txtHgGrundbedarf";
            this.txtHgGrundbedarf.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtHgGrundbedarf.ParentStyleUsing.UseBackColor = false;
            this.txtHgGrundbedarf.ParentStyleUsing.UseBorderColor = false;
            this.txtHgGrundbedarf.ParentStyleUsing.UseBorders = false;
            this.txtHgGrundbedarf.ParentStyleUsing.UseBorderWidth = false;
            this.txtHgGrundbedarf.ParentStyleUsing.UseFont = false;
            this.txtHgGrundbedarf.ParentStyleUsing.UseForeColor = false;
            this.txtHgGrundbedarf.Size = new System.Drawing.Size(98, 19);
            xrSummary5.FormatString = "{0:#,##0.00}";
            this.txtHgGrundbedarf.Summary = xrSummary5;
            this.txtHgGrundbedarf.Text = "HgGrundbedarf";
            this.txtHgGrundbedarf.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 10F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(7, 98);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(122, 19);
            this.Label6.Text = "Wohnkosten";
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial", 10F);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(7, 78);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(122, 19);
            this.Label5.Text = "Zuschlag zu GB 1";
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial", 10F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(7, 59);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(122, 19);
            this.Label4.Text = "Grundbedarf";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Arial", 10F);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(437, 35);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(192, 19);
            this.Label3.Text = "Unterstützungseinheit (UE)";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 10F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(208, 35);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(196, 19);
            this.Label2.Text = "Haushaltsgrösse (HG)";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(413, 19);
            this.Label1.Text = "Faktoren für Haushaltsgrösse und Unterstützungseinheit";
            // 
            // GBII_Betrag1
            // 
            this.GBII_Betrag1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "UE_GBII_Betrag", "{0:n2}")});
            this.GBII_Betrag1.Font = new System.Drawing.Font("Arial", 10F);
            this.GBII_Betrag1.ForeColor = System.Drawing.Color.Black;
            this.GBII_Betrag1.Location = new System.Drawing.Point(472, 62);
            this.GBII_Betrag1.Multiline = true;
            this.GBII_Betrag1.Name = "GBII_Betrag1";
            this.GBII_Betrag1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.GBII_Betrag1.ParentStyleUsing.UseBackColor = false;
            this.GBII_Betrag1.ParentStyleUsing.UseBorderColor = false;
            this.GBII_Betrag1.ParentStyleUsing.UseBorders = false;
            this.GBII_Betrag1.ParentStyleUsing.UseBorderWidth = false;
            this.GBII_Betrag1.ParentStyleUsing.UseFont = false;
            this.GBII_Betrag1.ParentStyleUsing.UseForeColor = false;
            this.GBII_Betrag1.Size = new System.Drawing.Size(98, 19);
            xrSummary6.FormatString = "{0:#,##0.00}";
            this.GBII_Betrag1.Summary = xrSummary6;
            this.GBII_Betrag1.Text = "UE_GBII_Betrag";
            this.GBII_Betrag1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // GBIZusatz_Betrag1
            // 
            this.GBIZusatz_Betrag1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "UE_GBI_Zusatz_Betrag", "{0:n2}")});
            this.GBIZusatz_Betrag1.Font = new System.Drawing.Font("Arial", 10F);
            this.GBIZusatz_Betrag1.ForeColor = System.Drawing.Color.Black;
            this.GBIZusatz_Betrag1.Location = new System.Drawing.Point(472, 43);
            this.GBIZusatz_Betrag1.Multiline = true;
            this.GBIZusatz_Betrag1.Name = "GBIZusatz_Betrag1";
            this.GBIZusatz_Betrag1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.GBIZusatz_Betrag1.ParentStyleUsing.UseBackColor = false;
            this.GBIZusatz_Betrag1.ParentStyleUsing.UseBorderColor = false;
            this.GBIZusatz_Betrag1.ParentStyleUsing.UseBorders = false;
            this.GBIZusatz_Betrag1.ParentStyleUsing.UseBorderWidth = false;
            this.GBIZusatz_Betrag1.ParentStyleUsing.UseFont = false;
            this.GBIZusatz_Betrag1.ParentStyleUsing.UseForeColor = false;
            this.GBIZusatz_Betrag1.Size = new System.Drawing.Size(98, 19);
            xrSummary7.FormatString = "{0:#,##0.00}";
            this.GBIZusatz_Betrag1.Summary = xrSummary7;
            this.GBIZusatz_Betrag1.Text = "UE_GBI_Zusatz_Betrag";
            this.GBIZusatz_Betrag1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // GBI_Betrag3
            // 
            this.GBI_Betrag3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "UE_GBI_Betrag", "{0:n2}")});
            this.GBI_Betrag3.Font = new System.Drawing.Font("Arial", 10F);
            this.GBI_Betrag3.ForeColor = System.Drawing.Color.Black;
            this.GBI_Betrag3.Location = new System.Drawing.Point(472, 23);
            this.GBI_Betrag3.Multiline = true;
            this.GBI_Betrag3.Name = "GBI_Betrag3";
            this.GBI_Betrag3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.GBI_Betrag3.ParentStyleUsing.UseBackColor = false;
            this.GBI_Betrag3.ParentStyleUsing.UseBorderColor = false;
            this.GBI_Betrag3.ParentStyleUsing.UseBorders = false;
            this.GBI_Betrag3.ParentStyleUsing.UseBorderWidth = false;
            this.GBI_Betrag3.ParentStyleUsing.UseFont = false;
            this.GBI_Betrag3.ParentStyleUsing.UseForeColor = false;
            this.GBI_Betrag3.Size = new System.Drawing.Size(98, 19);
            xrSummary8.FormatString = "{0:#,##0.00}";
            this.GBI_Betrag3.Summary = xrSummary8;
            this.GBI_Betrag3.Text = "UE_GBI_Betrag";
            this.GBI_Betrag3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtTOTAL
            // 
            this.txtTOTAL.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TotalGrundbedarf", "")});
            this.txtTOTAL.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.txtTOTAL.ForeColor = System.Drawing.Color.Black;
            this.txtTOTAL.Location = new System.Drawing.Point(472, 110);
            this.txtTOTAL.Multiline = true;
            this.txtTOTAL.Name = "txtTOTAL";
            this.txtTOTAL.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTOTAL.ParentStyleUsing.UseBackColor = false;
            this.txtTOTAL.ParentStyleUsing.UseBorderColor = false;
            this.txtTOTAL.ParentStyleUsing.UseBorders = false;
            this.txtTOTAL.ParentStyleUsing.UseBorderWidth = false;
            this.txtTOTAL.ParentStyleUsing.UseFont = false;
            this.txtTOTAL.ParentStyleUsing.UseForeColor = false;
            this.txtTOTAL.Size = new System.Drawing.Size(98, 19);
            xrSummary9.FormatString = "{0:#,##0.00}";
            this.txtTOTAL.Summary = xrSummary9;
            this.txtTOTAL.Text = "Summe";
            this.txtTOTAL.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label15
            // 
            this.Label15.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label15.ForeColor = System.Drawing.Color.Black;
            this.Label15.Location = new System.Drawing.Point(200, 110);
            this.Label15.Name = "Label15";
            this.Label15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label15.ParentStyleUsing.UseBackColor = false;
            this.Label15.ParentStyleUsing.UseBorderColor = false;
            this.Label15.ParentStyleUsing.UseBorders = false;
            this.Label15.ParentStyleUsing.UseBorderWidth = false;
            this.Label15.ParentStyleUsing.UseFont = false;
            this.Label15.ParentStyleUsing.UseForeColor = false;
            this.Label15.Size = new System.Drawing.Size(263, 19);
            this.Label15.Text = "Total monatlicher Grundbedarf";
            this.Label15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtGBI_Anpassung
            // 
            this.txtGBI_Anpassung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GBI_Anpassung", "{0:n2}")});
            this.txtGBI_Anpassung.Font = new System.Drawing.Font("Arial", 10F);
            this.txtGBI_Anpassung.ForeColor = System.Drawing.Color.Black;
            this.txtGBI_Anpassung.Location = new System.Drawing.Point(472, 78);
            this.txtGBI_Anpassung.Multiline = true;
            this.txtGBI_Anpassung.Name = "txtGBI_Anpassung";
            this.txtGBI_Anpassung.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGBI_Anpassung.ParentStyleUsing.UseBackColor = false;
            this.txtGBI_Anpassung.ParentStyleUsing.UseBorderColor = false;
            this.txtGBI_Anpassung.ParentStyleUsing.UseBorders = false;
            this.txtGBI_Anpassung.ParentStyleUsing.UseBorderWidth = false;
            this.txtGBI_Anpassung.ParentStyleUsing.UseFont = false;
            this.txtGBI_Anpassung.ParentStyleUsing.UseForeColor = false;
            this.txtGBI_Anpassung.Size = new System.Drawing.Size(98, 19);
            xrSummary10.FormatString = "{0:#,##0.00}";
            this.txtGBI_Anpassung.Summary = xrSummary10;
            this.txtGBI_Anpassung.Text = "GBI_Anpassung";
            this.txtGBI_Anpassung.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtGBII_Betrag
            // 
            this.txtGBII_Betrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GBII_Betrag", "{0:n2}")});
            this.txtGBII_Betrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtGBII_Betrag.ForeColor = System.Drawing.Color.Black;
            this.txtGBII_Betrag.Location = new System.Drawing.Point(236, 62);
            this.txtGBII_Betrag.Multiline = true;
            this.txtGBII_Betrag.Name = "txtGBII_Betrag";
            this.txtGBII_Betrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGBII_Betrag.ParentStyleUsing.UseBackColor = false;
            this.txtGBII_Betrag.ParentStyleUsing.UseBorderColor = false;
            this.txtGBII_Betrag.ParentStyleUsing.UseBorders = false;
            this.txtGBII_Betrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtGBII_Betrag.ParentStyleUsing.UseFont = false;
            this.txtGBII_Betrag.ParentStyleUsing.UseForeColor = false;
            this.txtGBII_Betrag.Size = new System.Drawing.Size(98, 19);
            xrSummary11.FormatString = "{0:#,##0.00}";
            this.txtGBII_Betrag.Summary = xrSummary11;
            this.txtGBII_Betrag.Text = "GBII_Betrag";
            this.txtGBII_Betrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtGBIZusatz_Betrag
            // 
            this.txtGBIZusatz_Betrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GBIZusatz_Betrag", "{0:n2}")});
            this.txtGBIZusatz_Betrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtGBIZusatz_Betrag.ForeColor = System.Drawing.Color.Black;
            this.txtGBIZusatz_Betrag.Location = new System.Drawing.Point(236, 43);
            this.txtGBIZusatz_Betrag.Multiline = true;
            this.txtGBIZusatz_Betrag.Name = "txtGBIZusatz_Betrag";
            this.txtGBIZusatz_Betrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGBIZusatz_Betrag.ParentStyleUsing.UseBackColor = false;
            this.txtGBIZusatz_Betrag.ParentStyleUsing.UseBorderColor = false;
            this.txtGBIZusatz_Betrag.ParentStyleUsing.UseBorders = false;
            this.txtGBIZusatz_Betrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtGBIZusatz_Betrag.ParentStyleUsing.UseFont = false;
            this.txtGBIZusatz_Betrag.ParentStyleUsing.UseForeColor = false;
            this.txtGBIZusatz_Betrag.Size = new System.Drawing.Size(98, 19);
            xrSummary12.FormatString = "{0:#,##0.00}";
            this.txtGBIZusatz_Betrag.Summary = xrSummary12;
            this.txtGBIZusatz_Betrag.Text = "GBIZusatz_Betrag";
            this.txtGBIZusatz_Betrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtGBI_Betrag
            // 
            this.txtGBI_Betrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GBI_Betrag", "{0:n2}")});
            this.txtGBI_Betrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtGBI_Betrag.ForeColor = System.Drawing.Color.Black;
            this.txtGBI_Betrag.Location = new System.Drawing.Point(236, 23);
            this.txtGBI_Betrag.Multiline = true;
            this.txtGBI_Betrag.Name = "txtGBI_Betrag";
            this.txtGBI_Betrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGBI_Betrag.ParentStyleUsing.UseBackColor = false;
            this.txtGBI_Betrag.ParentStyleUsing.UseBorderColor = false;
            this.txtGBI_Betrag.ParentStyleUsing.UseBorders = false;
            this.txtGBI_Betrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtGBI_Betrag.ParentStyleUsing.UseFont = false;
            this.txtGBI_Betrag.ParentStyleUsing.UseForeColor = false;
            this.txtGBI_Betrag.Size = new System.Drawing.Size(98, 19);
            xrSummary13.FormatString = "{0:#,##0.00}";
            this.txtGBI_Betrag.Summary = xrSummary13;
            this.txtGBI_Betrag.Text = "GBI_Betrag";
            this.txtGBI_Betrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line6
            // 
            this.Line6.ForeColor = System.Drawing.Color.Black;
            this.Line6.Location = new System.Drawing.Point(0, 102);
            this.Line6.Name = "Line6";
            this.Line6.ParentStyleUsing.UseBackColor = false;
            this.Line6.ParentStyleUsing.UseBorderColor = false;
            this.Line6.ParentStyleUsing.UseBorders = false;
            this.Line6.ParentStyleUsing.UseBorderWidth = false;
            this.Line6.ParentStyleUsing.UseFont = false;
            this.Line6.ParentStyleUsing.UseForeColor = false;
            this.Line6.Size = new System.Drawing.Size(629, 2);
            // 
            // Label14
            // 
            this.Label14.Font = new System.Drawing.Font("Arial", 10F);
            this.Label14.ForeColor = System.Drawing.Color.Black;
            this.Label14.Location = new System.Drawing.Point(7, 82);
            this.Label14.Name = "Label14";
            this.Label14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label14.ParentStyleUsing.UseBackColor = false;
            this.Label14.ParentStyleUsing.UseBorderColor = false;
            this.Label14.ParentStyleUsing.UseBorders = false;
            this.Label14.ParentStyleUsing.UseBorderWidth = false;
            this.Label14.ParentStyleUsing.UseFont = false;
            this.Label14.ParentStyleUsing.UseForeColor = false;
            this.Label14.Size = new System.Drawing.Size(216, 19);
            this.Label14.Text = "Anpassung (siehe Bemerkungen)";
            // 
            // Line5
            // 
            this.Line5.ForeColor = System.Drawing.Color.Black;
            this.Line5.Location = new System.Drawing.Point(0, 19);
            this.Line5.Name = "Line5";
            this.Line5.ParentStyleUsing.UseBackColor = false;
            this.Line5.ParentStyleUsing.UseBorderColor = false;
            this.Line5.ParentStyleUsing.UseBorders = false;
            this.Line5.ParentStyleUsing.UseBorderWidth = false;
            this.Line5.ParentStyleUsing.UseFont = false;
            this.Line5.ParentStyleUsing.UseForeColor = false;
            this.Line5.Size = new System.Drawing.Size(629, 2);
            // 
            // Label13
            // 
            this.Label13.Font = new System.Drawing.Font("Arial", 10F);
            this.Label13.ForeColor = System.Drawing.Color.Black;
            this.Label13.Location = new System.Drawing.Point(7, 62);
            this.Label13.Name = "Label13";
            this.Label13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label13.ParentStyleUsing.UseBackColor = false;
            this.Label13.ParentStyleUsing.UseBorderColor = false;
            this.Label13.ParentStyleUsing.UseBorders = false;
            this.Label13.ParentStyleUsing.UseBorderWidth = false;
            this.Label13.ParentStyleUsing.UseFont = false;
            this.Label13.ParentStyleUsing.UseForeColor = false;
            this.Label13.Size = new System.Drawing.Size(122, 19);
            this.Label13.Text = "Grundbedarf II";
            // 
            // Label12
            // 
            this.Label12.Font = new System.Drawing.Font("Arial", 10F);
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(7, 43);
            this.Label12.Name = "Label12";
            this.Label12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label12.ParentStyleUsing.UseBackColor = false;
            this.Label12.ParentStyleUsing.UseBorderColor = false;
            this.Label12.ParentStyleUsing.UseBorders = false;
            this.Label12.ParentStyleUsing.UseBorderWidth = false;
            this.Label12.ParentStyleUsing.UseFont = false;
            this.Label12.ParentStyleUsing.UseForeColor = false;
            this.Label12.Size = new System.Drawing.Size(174, 19);
            this.Label12.Text = "Zuschlag zu Grundbedarf I";
            // 
            // Label11
            // 
            this.Label11.Font = new System.Drawing.Font("Arial", 10F);
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(7, 23);
            this.Label11.Name = "Label11";
            this.Label11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label11.ParentStyleUsing.UseBackColor = false;
            this.Label11.ParentStyleUsing.UseBorderColor = false;
            this.Label11.ParentStyleUsing.UseBorders = false;
            this.Label11.ParentStyleUsing.UseBorderWidth = false;
            this.Label11.ParentStyleUsing.UseFont = false;
            this.Label11.ParentStyleUsing.UseForeColor = false;
            this.Label11.Size = new System.Drawing.Size(122, 19);
            this.Label11.Text = "Grundbedarf I";
            // 
            // Label10
            // 
            this.Label10.Font = new System.Drawing.Font("Arial", 10F);
            this.Label10.ForeColor = System.Drawing.Color.Black;
            this.Label10.Location = new System.Drawing.Point(437, 0);
            this.Label10.Name = "Label10";
            this.Label10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label10.ParentStyleUsing.UseBackColor = false;
            this.Label10.ParentStyleUsing.UseBorderColor = false;
            this.Label10.ParentStyleUsing.UseBorders = false;
            this.Label10.ParentStyleUsing.UseBorderWidth = false;
            this.Label10.ParentStyleUsing.UseFont = false;
            this.Label10.ParentStyleUsing.UseForeColor = false;
            this.Label10.Size = new System.Drawing.Size(192, 19);
            this.Label10.Text = "Unterstützungseinheit (UE)";
            // 
            // Label9
            // 
            this.Label9.Font = new System.Drawing.Font("Arial", 10F);
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(208, 0);
            this.Label9.Name = "Label9";
            this.Label9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label9.ParentStyleUsing.UseBackColor = false;
            this.Label9.ParentStyleUsing.UseBorderColor = false;
            this.Label9.ParentStyleUsing.UseBorders = false;
            this.Label9.ParentStyleUsing.UseBorderWidth = false;
            this.Label9.ParentStyleUsing.UseFont = false;
            this.Label9.ParentStyleUsing.UseForeColor = false;
            this.Label9.Size = new System.Drawing.Size(196, 19);
            this.Label9.Text = "Haushaltsgrösse (HG)";
            // 
            // Label16
            // 
            this.Label16.Font = new System.Drawing.Font("Arial", 10F);
            this.Label16.ForeColor = System.Drawing.Color.Black;
            this.Label16.Location = new System.Drawing.Point(0, 0);
            this.Label16.Name = "Label16";
            this.Label16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label16.ParentStyleUsing.UseBackColor = false;
            this.Label16.ParentStyleUsing.UseBorderColor = false;
            this.Label16.ParentStyleUsing.UseBorders = false;
            this.Label16.ParentStyleUsing.UseBorderWidth = false;
            this.Label16.ParentStyleUsing.UseFont = false;
            this.Label16.ParentStyleUsing.UseForeColor = false;
            this.Label16.Size = new System.Drawing.Size(354, 19);
            this.Label16.Text = "Grundbedarf gem. Angaben vom Betreibungsamt (BEX)";
            // 
            // GBI_Betrag1
            // 
            this.GBI_Betrag1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GBI_Betrag", "{0:n2}")});
            this.GBI_Betrag1.Font = new System.Drawing.Font("Arial", 10F);
            this.GBI_Betrag1.ForeColor = System.Drawing.Color.Black;
            this.GBI_Betrag1.Location = new System.Drawing.Point(354, 0);
            this.GBI_Betrag1.Multiline = true;
            this.GBI_Betrag1.Name = "GBI_Betrag1";
            this.GBI_Betrag1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.GBI_Betrag1.ParentStyleUsing.UseBackColor = false;
            this.GBI_Betrag1.ParentStyleUsing.UseBorderColor = false;
            this.GBI_Betrag1.ParentStyleUsing.UseBorders = false;
            this.GBI_Betrag1.ParentStyleUsing.UseBorderWidth = false;
            this.GBI_Betrag1.ParentStyleUsing.UseFont = false;
            this.GBI_Betrag1.ParentStyleUsing.UseForeColor = false;
            this.GBI_Betrag1.Size = new System.Drawing.Size(98, 19);
            xrSummary14.FormatString = "{0:#,##0.00}";
            this.GBI_Betrag1.Summary = xrSummary14;
            this.GBI_Betrag1.Text = "GBI_Betrag";
            this.GBI_Betrag1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label17
            // 
            this.Label17.Font = new System.Drawing.Font("Arial", 10F);
            this.Label17.ForeColor = System.Drawing.Color.Black;
            this.Label17.Location = new System.Drawing.Point(0, 0);
            this.Label17.Name = "Label17";
            this.Label17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label17.ParentStyleUsing.UseBackColor = false;
            this.Label17.ParentStyleUsing.UseBorderColor = false;
            this.Label17.ParentStyleUsing.UseBorders = false;
            this.Label17.ParentStyleUsing.UseBorderWidth = false;
            this.Label17.ParentStyleUsing.UseFont = false;
            this.Label17.ParentStyleUsing.UseForeColor = false;
            this.Label17.Size = new System.Drawing.Size(354, 19);
            this.Label17.Text = "Grundbedarf für Klienten in stationären Einrichtungen";
            // 
            // GBI_Betrag2
            // 
            this.GBI_Betrag2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GBI_Betrag", "{0:n2}")});
            this.GBI_Betrag2.Font = new System.Drawing.Font("Arial", 10F);
            this.GBI_Betrag2.ForeColor = System.Drawing.Color.Black;
            this.GBI_Betrag2.Location = new System.Drawing.Point(354, 0);
            this.GBI_Betrag2.Multiline = true;
            this.GBI_Betrag2.Name = "GBI_Betrag2";
            this.GBI_Betrag2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.GBI_Betrag2.ParentStyleUsing.UseBackColor = false;
            this.GBI_Betrag2.ParentStyleUsing.UseBorderColor = false;
            this.GBI_Betrag2.ParentStyleUsing.UseBorders = false;
            this.GBI_Betrag2.ParentStyleUsing.UseBorderWidth = false;
            this.GBI_Betrag2.ParentStyleUsing.UseFont = false;
            this.GBI_Betrag2.ParentStyleUsing.UseForeColor = false;
            this.GBI_Betrag2.Size = new System.Drawing.Size(98, 19);
            xrSummary15.FormatString = "{0:#,##0.00}";
            this.GBI_Betrag2.Summary = xrSummary15;
            this.GBI_Betrag2.Text = "GBI_Betrag";
            this.GBI_Betrag2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtGBI_Anpassung_Bemerkung
            // 
            this.txtGBI_Anpassung_Bemerkung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GBI_Anpassung_Bemerkung", "")});
            this.txtGBI_Anpassung_Bemerkung.Font = new System.Drawing.Font("Arial", 10F);
            this.txtGBI_Anpassung_Bemerkung.ForeColor = System.Drawing.Color.Black;
            this.txtGBI_Anpassung_Bemerkung.Location = new System.Drawing.Point(0, 0);
            this.txtGBI_Anpassung_Bemerkung.Multiline = true;
            this.txtGBI_Anpassung_Bemerkung.Name = "txtGBI_Anpassung_Bemerkung";
            this.txtGBI_Anpassung_Bemerkung.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGBI_Anpassung_Bemerkung.ParentStyleUsing.UseBackColor = false;
            this.txtGBI_Anpassung_Bemerkung.ParentStyleUsing.UseBorderColor = false;
            this.txtGBI_Anpassung_Bemerkung.ParentStyleUsing.UseBorders = false;
            this.txtGBI_Anpassung_Bemerkung.ParentStyleUsing.UseBorderWidth = false;
            this.txtGBI_Anpassung_Bemerkung.ParentStyleUsing.UseFont = false;
            this.txtGBI_Anpassung_Bemerkung.ParentStyleUsing.UseForeColor = false;
            this.txtGBI_Anpassung_Bemerkung.Size = new System.Drawing.Size(629, 19);
            this.txtGBI_Anpassung_Bemerkung.Text = "GBI_Anpassung_Bemerkung";
            // 
            // Nebenkosten_Betrag1
            // 
            this.Nebenkosten_Betrag1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Nebenkosten_Betrag1", "{0:n2}")});
            this.Nebenkosten_Betrag1.Font = new System.Drawing.Font("Arial", 10F);
            this.Nebenkosten_Betrag1.ForeColor = System.Drawing.Color.Black;
            this.Nebenkosten_Betrag1.Location = new System.Drawing.Point(472, 145);
            this.Nebenkosten_Betrag1.Multiline = true;
            this.Nebenkosten_Betrag1.Name = "Nebenkosten_Betrag1";
            this.Nebenkosten_Betrag1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Nebenkosten_Betrag1.ParentStyleUsing.UseBackColor = false;
            this.Nebenkosten_Betrag1.ParentStyleUsing.UseBorderColor = false;
            this.Nebenkosten_Betrag1.ParentStyleUsing.UseBorders = false;
            this.Nebenkosten_Betrag1.ParentStyleUsing.UseBorderWidth = false;
            this.Nebenkosten_Betrag1.ParentStyleUsing.UseFont = false;
            this.Nebenkosten_Betrag1.ParentStyleUsing.UseForeColor = false;
            this.Nebenkosten_Betrag1.Size = new System.Drawing.Size(98, 19);
            xrSummary16.FormatString = "{0:#,##0.00}";
            this.Nebenkosten_Betrag1.Summary = xrSummary16;
            this.Nebenkosten_Betrag1.Text = "Nebenkosten_Betrag";
            this.Nebenkosten_Betrag1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Miete_Betrag1
            // 
            this.Miete_Betrag1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Miete_Betrag1", "{0:n2}")});
            this.Miete_Betrag1.Font = new System.Drawing.Font("Arial", 10F);
            this.Miete_Betrag1.ForeColor = System.Drawing.Color.Black;
            this.Miete_Betrag1.Location = new System.Drawing.Point(472, 125);
            this.Miete_Betrag1.Multiline = true;
            this.Miete_Betrag1.Name = "Miete_Betrag1";
            this.Miete_Betrag1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Miete_Betrag1.ParentStyleUsing.UseBackColor = false;
            this.Miete_Betrag1.ParentStyleUsing.UseBorderColor = false;
            this.Miete_Betrag1.ParentStyleUsing.UseBorders = false;
            this.Miete_Betrag1.ParentStyleUsing.UseBorderWidth = false;
            this.Miete_Betrag1.ParentStyleUsing.UseFont = false;
            this.Miete_Betrag1.ParentStyleUsing.UseForeColor = false;
            this.Miete_Betrag1.Size = new System.Drawing.Size(98, 19);
            xrSummary17.FormatString = "{0:#,##0.00}";
            this.Miete_Betrag1.Summary = xrSummary17;
            this.Miete_Betrag1.Text = "Miete_Betrag";
            this.Miete_Betrag1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Miete_Betrag_Eff1
            // 
            this.Miete_Betrag_Eff1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Miete_Betrag_Eff1", "{0:n2}")});
            this.Miete_Betrag_Eff1.Font = new System.Drawing.Font("Arial", 10F);
            this.Miete_Betrag_Eff1.ForeColor = System.Drawing.Color.Black;
            this.Miete_Betrag_Eff1.Location = new System.Drawing.Point(472, 106);
            this.Miete_Betrag_Eff1.Multiline = true;
            this.Miete_Betrag_Eff1.Name = "Miete_Betrag_Eff1";
            this.Miete_Betrag_Eff1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Miete_Betrag_Eff1.ParentStyleUsing.UseBackColor = false;
            this.Miete_Betrag_Eff1.ParentStyleUsing.UseBorderColor = false;
            this.Miete_Betrag_Eff1.ParentStyleUsing.UseBorders = false;
            this.Miete_Betrag_Eff1.ParentStyleUsing.UseBorderWidth = false;
            this.Miete_Betrag_Eff1.ParentStyleUsing.UseFont = false;
            this.Miete_Betrag_Eff1.ParentStyleUsing.UseForeColor = false;
            this.Miete_Betrag_Eff1.Size = new System.Drawing.Size(98, 19);
            xrSummary18.FormatString = "{0:#,##0.00}";
            this.Miete_Betrag_Eff1.Summary = xrSummary18;
            this.Miete_Betrag_Eff1.Text = "Miete_Betrag_Eff";
            this.Miete_Betrag_Eff1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtMiete_Betrag_Text
            // 
            this.txtMiete_Betrag_Text.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Miete_Betrag_Text", "")});
            this.txtMiete_Betrag_Text.Font = new System.Drawing.Font("Arial", 10F);
            this.txtMiete_Betrag_Text.ForeColor = System.Drawing.Color.Black;
            this.txtMiete_Betrag_Text.Location = new System.Drawing.Point(7, 125);
            this.txtMiete_Betrag_Text.Multiline = true;
            this.txtMiete_Betrag_Text.Name = "txtMiete_Betrag_Text";
            this.txtMiete_Betrag_Text.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtMiete_Betrag_Text.ParentStyleUsing.UseBackColor = false;
            this.txtMiete_Betrag_Text.ParentStyleUsing.UseBorderColor = false;
            this.txtMiete_Betrag_Text.ParentStyleUsing.UseBorders = false;
            this.txtMiete_Betrag_Text.ParentStyleUsing.UseBorderWidth = false;
            this.txtMiete_Betrag_Text.ParentStyleUsing.UseFont = false;
            this.txtMiete_Betrag_Text.ParentStyleUsing.UseForeColor = false;
            this.txtMiete_Betrag_Text.Size = new System.Drawing.Size(196, 19);
            this.txtMiete_Betrag_Text.Text = "Miete_Betrag_Text";
            // 
            // txtBerechnungsgrundlage
            // 
            this.txtBerechnungsgrundlage.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Berechnungsgrundlage", "")});
            this.txtBerechnungsgrundlage.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBerechnungsgrundlage.ForeColor = System.Drawing.Color.Black;
            this.txtBerechnungsgrundlage.Location = new System.Drawing.Point(157, 47);
            this.txtBerechnungsgrundlage.Multiline = true;
            this.txtBerechnungsgrundlage.Name = "txtBerechnungsgrundlage";
            this.txtBerechnungsgrundlage.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBerechnungsgrundlage.ParentStyleUsing.UseBackColor = false;
            this.txtBerechnungsgrundlage.ParentStyleUsing.UseBorderColor = false;
            this.txtBerechnungsgrundlage.ParentStyleUsing.UseBorders = false;
            this.txtBerechnungsgrundlage.ParentStyleUsing.UseBorderWidth = false;
            this.txtBerechnungsgrundlage.ParentStyleUsing.UseFont = false;
            this.txtBerechnungsgrundlage.ParentStyleUsing.UseForeColor = false;
            this.txtBerechnungsgrundlage.Size = new System.Drawing.Size(472, 19);
            this.txtBerechnungsgrundlage.Text = "Berechnungsgrundlage";
            // 
            // txtWohnsituation
            // 
            this.txtWohnsituation.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Wohnsituation", "")});
            this.txtWohnsituation.Font = new System.Drawing.Font("Arial", 10F);
            this.txtWohnsituation.ForeColor = System.Drawing.Color.Black;
            this.txtWohnsituation.Location = new System.Drawing.Point(157, 27);
            this.txtWohnsituation.Multiline = true;
            this.txtWohnsituation.Name = "txtWohnsituation";
            this.txtWohnsituation.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtWohnsituation.ParentStyleUsing.UseBackColor = false;
            this.txtWohnsituation.ParentStyleUsing.UseBorderColor = false;
            this.txtWohnsituation.ParentStyleUsing.UseBorders = false;
            this.txtWohnsituation.ParentStyleUsing.UseBorderWidth = false;
            this.txtWohnsituation.ParentStyleUsing.UseFont = false;
            this.txtWohnsituation.ParentStyleUsing.UseForeColor = false;
            this.txtWohnsituation.Size = new System.Drawing.Size(472, 19);
            this.txtWohnsituation.Text = "Wohnsituation";
            // 
            // txtNebenkosten_Betrag
            // 
            this.txtNebenkosten_Betrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Nebenkosten_Betrag", "{0:n2}")});
            this.txtNebenkosten_Betrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNebenkosten_Betrag.ForeColor = System.Drawing.Color.Black;
            this.txtNebenkosten_Betrag.Location = new System.Drawing.Point(236, 145);
            this.txtNebenkosten_Betrag.Multiline = true;
            this.txtNebenkosten_Betrag.Name = "txtNebenkosten_Betrag";
            this.txtNebenkosten_Betrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNebenkosten_Betrag.ParentStyleUsing.UseBackColor = false;
            this.txtNebenkosten_Betrag.ParentStyleUsing.UseBorderColor = false;
            this.txtNebenkosten_Betrag.ParentStyleUsing.UseBorders = false;
            this.txtNebenkosten_Betrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtNebenkosten_Betrag.ParentStyleUsing.UseFont = false;
            this.txtNebenkosten_Betrag.ParentStyleUsing.UseForeColor = false;
            this.txtNebenkosten_Betrag.Size = new System.Drawing.Size(98, 19);
            xrSummary19.FormatString = "{0:#,##0.00}";
            this.txtNebenkosten_Betrag.Summary = xrSummary19;
            this.txtNebenkosten_Betrag.Text = "Nebenkosten_Betrag";
            this.txtNebenkosten_Betrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtMiete_Betrag
            // 
            this.txtMiete_Betrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Miete_Betrag", "{0:n2}")});
            this.txtMiete_Betrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtMiete_Betrag.ForeColor = System.Drawing.Color.Black;
            this.txtMiete_Betrag.Location = new System.Drawing.Point(236, 125);
            this.txtMiete_Betrag.Multiline = true;
            this.txtMiete_Betrag.Name = "txtMiete_Betrag";
            this.txtMiete_Betrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtMiete_Betrag.ParentStyleUsing.UseBackColor = false;
            this.txtMiete_Betrag.ParentStyleUsing.UseBorderColor = false;
            this.txtMiete_Betrag.ParentStyleUsing.UseBorders = false;
            this.txtMiete_Betrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtMiete_Betrag.ParentStyleUsing.UseFont = false;
            this.txtMiete_Betrag.ParentStyleUsing.UseForeColor = false;
            this.txtMiete_Betrag.Size = new System.Drawing.Size(98, 19);
            xrSummary20.FormatString = "{0:#,##0.00}";
            this.txtMiete_Betrag.Summary = xrSummary20;
            this.txtMiete_Betrag.Text = "Miete_Betrag";
            this.txtMiete_Betrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtMiete_Betrag_Eff
            // 
            this.txtMiete_Betrag_Eff.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Miete_Betrag_Eff", "{0:n2}")});
            this.txtMiete_Betrag_Eff.Font = new System.Drawing.Font("Arial", 10F);
            this.txtMiete_Betrag_Eff.ForeColor = System.Drawing.Color.Black;
            this.txtMiete_Betrag_Eff.Location = new System.Drawing.Point(236, 106);
            this.txtMiete_Betrag_Eff.Multiline = true;
            this.txtMiete_Betrag_Eff.Name = "txtMiete_Betrag_Eff";
            this.txtMiete_Betrag_Eff.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtMiete_Betrag_Eff.ParentStyleUsing.UseBackColor = false;
            this.txtMiete_Betrag_Eff.ParentStyleUsing.UseBorderColor = false;
            this.txtMiete_Betrag_Eff.ParentStyleUsing.UseBorders = false;
            this.txtMiete_Betrag_Eff.ParentStyleUsing.UseBorderWidth = false;
            this.txtMiete_Betrag_Eff.ParentStyleUsing.UseFont = false;
            this.txtMiete_Betrag_Eff.ParentStyleUsing.UseForeColor = false;
            this.txtMiete_Betrag_Eff.Size = new System.Drawing.Size(98, 19);
            xrSummary21.FormatString = "{0:#,##0.00}";
            this.txtMiete_Betrag_Eff.Summary = xrSummary21;
            this.txtMiete_Betrag_Eff.Text = "Miete_Betrag_Eff";
            this.txtMiete_Betrag_Eff.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox1
            // 
            this.TextBox1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AngerechnWKAnteil", "{0:n2}")});
            this.TextBox1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.TextBox1.ForeColor = System.Drawing.Color.Black;
            this.TextBox1.Location = new System.Drawing.Point(472, 192);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox1.ParentStyleUsing.UseBackColor = false;
            this.TextBox1.ParentStyleUsing.UseBorderColor = false;
            this.TextBox1.ParentStyleUsing.UseBorders = false;
            this.TextBox1.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox1.ParentStyleUsing.UseFont = false;
            this.TextBox1.ParentStyleUsing.UseForeColor = false;
            this.TextBox1.Size = new System.Drawing.Size(98, 19);
            xrSummary22.FormatString = "{0:#,##0.00}";
            this.TextBox1.Summary = xrSummary22;
            this.TextBox1.Text = "Summe";
            this.TextBox1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label27
            // 
            this.Label27.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label27.ForeColor = System.Drawing.Color.Black;
            this.Label27.Location = new System.Drawing.Point(141, 192);
            this.Label27.Name = "Label27";
            this.Label27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label27.ParentStyleUsing.UseBackColor = false;
            this.Label27.ParentStyleUsing.UseBorderColor = false;
            this.Label27.ParentStyleUsing.UseBorders = false;
            this.Label27.ParentStyleUsing.UseBorderWidth = false;
            this.Label27.ParentStyleUsing.UseFont = false;
            this.Label27.ParentStyleUsing.UseForeColor = false;
            this.Label27.Size = new System.Drawing.Size(322, 19);
            this.Label27.Text = "Angerechneter Wohnkostenanteil inkl. NK";
            this.Label27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line8
            // 
            this.Line8.ForeColor = System.Drawing.Color.Black;
            this.Line8.Location = new System.Drawing.Point(0, 185);
            this.Line8.Name = "Line8";
            this.Line8.ParentStyleUsing.UseBackColor = false;
            this.Line8.ParentStyleUsing.UseBorderColor = false;
            this.Line8.ParentStyleUsing.UseBorders = false;
            this.Line8.ParentStyleUsing.UseBorderWidth = false;
            this.Line8.ParentStyleUsing.UseFont = false;
            this.Line8.ParentStyleUsing.UseForeColor = false;
            this.Line8.Size = new System.Drawing.Size(629, 2);
            // 
            // Line7
            // 
            this.Line7.ForeColor = System.Drawing.Color.Black;
            this.Line7.Location = new System.Drawing.Point(0, 102);
            this.Line7.Name = "Line7";
            this.Line7.ParentStyleUsing.UseBackColor = false;
            this.Line7.ParentStyleUsing.UseBorderColor = false;
            this.Line7.ParentStyleUsing.UseBorders = false;
            this.Line7.ParentStyleUsing.UseBorderWidth = false;
            this.Line7.ParentStyleUsing.UseFont = false;
            this.Line7.ParentStyleUsing.UseForeColor = false;
            this.Line7.Size = new System.Drawing.Size(629, 2);
            // 
            // Label25
            // 
            this.Label25.Font = new System.Drawing.Font("Arial", 10F);
            this.Label25.ForeColor = System.Drawing.Color.Black;
            this.Label25.Location = new System.Drawing.Point(7, 145);
            this.Label25.Name = "Label25";
            this.Label25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label25.ParentStyleUsing.UseBackColor = false;
            this.Label25.ParentStyleUsing.UseBorderColor = false;
            this.Label25.ParentStyleUsing.UseBorders = false;
            this.Label25.ParentStyleUsing.UseBorderWidth = false;
            this.Label25.ParentStyleUsing.UseFont = false;
            this.Label25.ParentStyleUsing.UseForeColor = false;
            this.Label25.Size = new System.Drawing.Size(196, 19);
            this.Label25.Text = "Effektive Nebenkosten";
            // 
            // Label23
            // 
            this.Label23.Font = new System.Drawing.Font("Arial", 10F);
            this.Label23.ForeColor = System.Drawing.Color.Black;
            this.Label23.Location = new System.Drawing.Point(7, 106);
            this.Label23.Name = "Label23";
            this.Label23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label23.ParentStyleUsing.UseBackColor = false;
            this.Label23.ParentStyleUsing.UseBorderColor = false;
            this.Label23.ParentStyleUsing.UseBorders = false;
            this.Label23.ParentStyleUsing.UseBorderWidth = false;
            this.Label23.ParentStyleUsing.UseFont = false;
            this.Label23.ParentStyleUsing.UseForeColor = false;
            this.Label23.Size = new System.Drawing.Size(196, 19);
            this.Label23.Text = "Effektive Zins- rsp. Mietkosten";
            // 
            // Label22
            // 
            this.Label22.Font = new System.Drawing.Font("Arial", 10F);
            this.Label22.ForeColor = System.Drawing.Color.Black;
            this.Label22.Location = new System.Drawing.Point(437, 82);
            this.Label22.Name = "Label22";
            this.Label22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label22.ParentStyleUsing.UseBackColor = false;
            this.Label22.ParentStyleUsing.UseBorderColor = false;
            this.Label22.ParentStyleUsing.UseBorders = false;
            this.Label22.ParentStyleUsing.UseBorderWidth = false;
            this.Label22.ParentStyleUsing.UseFont = false;
            this.Label22.ParentStyleUsing.UseForeColor = false;
            this.Label22.Size = new System.Drawing.Size(192, 19);
            this.Label22.Text = "Unterstützungseinheit (UE)";
            // 
            // Label21
            // 
            this.Label21.Font = new System.Drawing.Font("Arial", 10F);
            this.Label21.ForeColor = System.Drawing.Color.Black;
            this.Label21.Location = new System.Drawing.Point(208, 82);
            this.Label21.Name = "Label21";
            this.Label21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label21.ParentStyleUsing.UseBackColor = false;
            this.Label21.ParentStyleUsing.UseBorderColor = false;
            this.Label21.ParentStyleUsing.UseBorders = false;
            this.Label21.ParentStyleUsing.UseBorderWidth = false;
            this.Label21.ParentStyleUsing.UseFont = false;
            this.Label21.ParentStyleUsing.UseForeColor = false;
            this.Label21.Size = new System.Drawing.Size(196, 19);
            this.Label21.Text = "Haushaltsgrösse (HG)";
            // 
            // Label20
            // 
            this.Label20.Font = new System.Drawing.Font("Arial", 10F);
            this.Label20.ForeColor = System.Drawing.Color.Black;
            this.Label20.Location = new System.Drawing.Point(0, 47);
            this.Label20.Name = "Label20";
            this.Label20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label20.ParentStyleUsing.UseBackColor = false;
            this.Label20.ParentStyleUsing.UseBorderColor = false;
            this.Label20.ParentStyleUsing.UseBorders = false;
            this.Label20.ParentStyleUsing.UseBorderWidth = false;
            this.Label20.ParentStyleUsing.UseFont = false;
            this.Label20.ParentStyleUsing.UseForeColor = false;
            this.Label20.Size = new System.Drawing.Size(149, 19);
            this.Label20.Text = "Berechnungsgrundlage";
            // 
            // Label19
            // 
            this.Label19.Font = new System.Drawing.Font("Arial", 10F);
            this.Label19.ForeColor = System.Drawing.Color.Black;
            this.Label19.Location = new System.Drawing.Point(0, 27);
            this.Label19.Name = "Label19";
            this.Label19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label19.ParentStyleUsing.UseBackColor = false;
            this.Label19.ParentStyleUsing.UseBorderColor = false;
            this.Label19.ParentStyleUsing.UseBorders = false;
            this.Label19.ParentStyleUsing.UseBorderWidth = false;
            this.Label19.ParentStyleUsing.UseFont = false;
            this.Label19.ParentStyleUsing.UseForeColor = false;
            this.Label19.Size = new System.Drawing.Size(122, 19);
            this.Label19.Text = "Wohnsituation";
            // 
            // Label18
            // 
            this.Label18.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.Label18.ForeColor = System.Drawing.Color.Black;
            this.Label18.Location = new System.Drawing.Point(0, 0);
            this.Label18.Name = "Label18";
            this.Label18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label18.ParentStyleUsing.UseBackColor = false;
            this.Label18.ParentStyleUsing.UseBorderColor = false;
            this.Label18.ParentStyleUsing.UseBorders = false;
            this.Label18.ParentStyleUsing.UseBorderWidth = false;
            this.Label18.ParentStyleUsing.UseFont = false;
            this.Label18.ParentStyleUsing.UseForeColor = false;
            this.Label18.Size = new System.Drawing.Size(149, 19);
            this.Label18.Text = "Wohnungsmiete";
            // 
            // txtMiete_Bemerkung
            // 
            this.txtMiete_Bemerkung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Miete_Bemerkung", "")});
            this.txtMiete_Bemerkung.Font = new System.Drawing.Font("Arial", 10F);
            this.txtMiete_Bemerkung.ForeColor = System.Drawing.Color.Black;
            this.txtMiete_Bemerkung.Location = new System.Drawing.Point(0, 0);
            this.txtMiete_Bemerkung.Multiline = true;
            this.txtMiete_Bemerkung.Name = "txtMiete_Bemerkung";
            this.txtMiete_Bemerkung.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtMiete_Bemerkung.ParentStyleUsing.UseBackColor = false;
            this.txtMiete_Bemerkung.ParentStyleUsing.UseBorderColor = false;
            this.txtMiete_Bemerkung.ParentStyleUsing.UseBorders = false;
            this.txtMiete_Bemerkung.ParentStyleUsing.UseBorderWidth = false;
            this.txtMiete_Bemerkung.ParentStyleUsing.UseFont = false;
            this.txtMiete_Bemerkung.ParentStyleUsing.UseForeColor = false;
            this.txtMiete_Bemerkung.Size = new System.Drawing.Size(629, 19);
            this.txtMiete_Bemerkung.Text = "Miete_Bemerkung";
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
                        this.GroupHeader2,
                        this.GroupHeader3,
                        this.GroupHeader4,
                        this.GroupHeader5,
                        this.GroupHeader6,
                        this.GroupHeader7,
                        this.GroupFooter7,
                        this.GroupFooter6,
                        this.GroupFooter5,
                        this.GroupFooter4,
                        this.GroupFooter3,
                        this.GroupFooter2,
                        this.GroupFooter1,
                        this.PageFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(39, 39, 39, 39);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ScriptReferencesString = "System.Windows.Forms.dll";
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'DECLARE @BgBudgetID int

SELECT @BgBudgetID = BgBudgetID
FROM BgBudget
WHERE BgFinanzplanID = {BgFinanzplanID} AND MasterBudget = 1

SELECT
  (SELECT Count(*)
   FROM BgFinanzplan_BaPerson    SPP
   WHERE SPP.BgFinanzplanID = BBG.BgFinanzplanID)                            AS HgGrundbedarf,

  (SELECT SUM(CASE WHEN dbo.fnGetAge(PRS.Geburtsdatum, SFP.DatumVon) < dbo.fnXConfig(''System\Sozialhilfe\SKOS\F51_Age'', SFP.DatumVon)
                THEN CAST(dbo.fnXConfig(''System\Sozialhilfe\SKOS\F51_Factor'', SFP.DatumVon) AS float)
                ELSE 1
              END)
   FROM BgFinanzplan_BaPerson    SPP
     INNER JOIN BgFinanzplan      SFP ON SFP.BgFinanzplanID = SPP.BgFinanzplanID
     INNER JOIN BaPerson         PRS ON PRS.BaPersonID    = SPP.BaPersonID
   WHERE SPP.BgFinanzplanID = BBG.BgFinanzplanID)                            AS HgWohnkosten,

  (SELECT Count(*)
   FROM BgFinanzplan_BaPerson    SPP
   WHERE SPP.BgFinanzplanID = BBG.BgFinanzplanID AND SPP.IstUnterstuetzt = 1) AS UeGrundbedarf,

  (SELECT SUM(CASE WHEN dbo.fnGetAge(PRS.Geburtsdatum, SFP.DatumVon) < dbo.fnXConfig(''System\Sozialhilfe\SKOS\F51_Age'', SFP.DatumVon)
                THEN CAST(dbo.fnXConfig(''System\Sozialhilfe\SKOS\F51_Factor'', SFP.DatumVon) AS float)
                ELSE 1
              END)
   FROM BgFinanzplan_BaPerson    SPP
     INNER JOIN BgFinanzplan      SFP ON SFP.BgFinanzplanID = SPP.BgFinanzplanID
     INNER JOIN BaPerson         PRS ON PRS.BaPersonID    = SPP.BaPersonID
   WHERE SPP.BgFinanzplanID = BBG.BgFinanzplanID AND SPP.IstUnterstuetzt = 1) AS UeWohnkosten,

  (SELECT CASE WHEN dbo.fnXConfig(''System\Sozialhilfe\SKOS\B23_Offset'', MAX(SFP.DatumVon)) > Count(*)
            THEN 0
            ELSE Count(*) - IsNull(CAST(dbo.fnXConfig(''System\Sozialhilfe\SKOS\B23_Offset'', MAX(SFP.DatumVon)) AS float), 0)
          END
   FROM BgFinanzplan_BaPerson    SPP
     INNER JOIN BgFinanzplan      SFP ON SFP.BgFinanzplanID = SPP.BgFinanzplanID
     INNER JOIN BaPerson         PRS ON PRS.BaPersonID    = SPP.BaPersonID
   WHERE SPP.BgFinanzplanID = BBG.BgFinanzplanID AND SPP.IstUnterstuetzt = 1
     AND dbo.fnGetAge(PRS.Geburtsdatum, SFP.DatumVon) >= CAST(dbo.fnXConfig(''System\Sozialhilfe\SKOS\B23_Age'', SFP.DatumVon) AS int)) AS UeZuschlagI,

   [GB_Typ]                  = BPO_GBI.BgPositionsartCode,
   [GB_TypText]              = XLC_GB.Text,
   [GBI_Betrag]              = BPO_GBI.Betrag,
   [GBIZusatz_Betrag]        = BPO_GBIZ.Betrag,
   [GBII_Betrag]             = BPO_GBII.Betrag,
   [GBI_Anpassung]           = -BPO_GBI.Reduktion,
   [GBI_Anpassung_Bemerkung] = BPO_GBI.Bemerkung,

   [Wohnsituation]        = SUBSTRING(Name, 1, CHARINDEX('' -'', Name) - 1),
   [Berechnungsgrundlage] = ''Wohnkosten '' + CASE BPO_MK.BgPositionsartCode % 2 WHEN 0 THEN ''gem. Richtlinien'' ELSE ''individuell'' END + '' bestimmen'',
   [Miete_Betrag_Eff]     = ISNULL(BPO_MK.Betrag, 0),
   [Miete_Betrag_Text]    = ''Ansatz '' + CASE BPO_MK.BgPositionsartCode % 2 WHEN 0 THEN ''gem. Richtlinien'' ELSE ''individuell'' END,
   [Miete_Betrag]         = ISNULL(BPO_MK.Betrag, 0) - ISNULL(BPO_MK.Abzug, 0),
   [Nebenkosten_Betrag]   = ISNULL(BPO_MNK.Betrag, 0),
   [Miete_Bemerkung]      = BPO_MK.Bemerkung,
   UE_GBI_Betrag          = dbo.fnShGrundbedarfI(BBG.BgFinanzplanID),
   UE_GBI_Zusatz_Betrag   = dbo.fnShGrundbedarfIZuschlag(BBG.BgFinanzplanID),
   UE_GBII_Betrag         = CASE WHEN BPO_GBII.BgPositionsartCode = 3
                            THEN dbo.fnShGrundbedarfII(BBG.BgFinanzplanID,1)
                            ELSE dbo.fnShGrundbedarfII(BBG.BgFinanzplanID,0) -- keine Kopfteilung
                            END,
   TotalGrundbedarf       = dbo.fnShGrundbedarfI(BBG.BgFinanzplanID) +                                                         dbo.fnShGrundbedarfIZuschlag(BBG.BgFinanzplanID) +
                            CASE WHEN BPO_GBII.BgPositionsartCode = 3
                                     THEN dbo.fnShGrundbedarfII(BBG.BgFinanzplanID,1)
                                 ELSE dbo.fnShGrundbedarfII(BBG.BgFinanzplanID,0) -- keine Kopfteilung
                            END -
                            BPO_GBI.Reduktion,

   AngerechnWKAnteil      = ISNULL(BPO_MK.Betrag, 0) - ISNULL(BPO_MK.Abzug, 0) - ISNULL(BPO_MK.Reduktion, 0)
                            + ISNULL(BPO_MNK.Betrag, 0) - ISNULL(BPO_MNK.Reduktion, 0),
   [Miete_Betrag_Eff1]    = ISNULL(BPO_MK.Betrag, 0) - ISNULL(BPO_MK.Reduktion, 0),
   [Miete_Betrag1]        = ISNULL(BPO_MK.Betrag, 0) - ISNULL(BPO_MK.Abzug, 0) - ISNULL(BPO_MK.Reduktion, 0),
   [Nebenkosten_Betrag]   = ISNULL(BPO_MNK.Betrag, 0) - ISNULL(BPO_MNK.Reduktion, 0)
FROM BgBudget  BBG
  --LEFT  JOIN BgPosition     BPO_GBI  ON BPO_GBI.BgBudgetID  = BBG.BgBudgetID
  --                                      AND BPO_GBI.BgPositionsartID IN (SELECT BgPositionsartID FROM WhPositionsart
  --                                                                      WHERE BgGruppeCode = 5 AND SortKey = 1)
  --                                      AND BPO_GBI.DatumVon IS NULL
  LEFT JOIN (SELECT BPOI.*, POAI.BgPositionsartCode
             FROM BgPosition BPOI
               INNER JOIN BgPositionsart POAI ON POAI.BgPositionsartID = BPOI.BgPositionsartID
             WHERE POAI.BgGruppeCode = 5 AND POAI.SortKey = 1) 
                            BPO_GBI ON BPO_GBI.BgBudgetID = BBG.BgBudgetID
                                   AND BPO_GBI.DatumVon IS NULL
                                        
  LEFT  JOIN XLOVCode       XLC_GB   ON XLC_GB.LOVName = ''WhGrundbedarfTyp'' AND XLC_GB.Code = BPO_GBI.BgPositionsartCode

  --LEFT  JOIN BgPosition     BPO_GBIZ ON BPO_GBIZ.BgBudgetID = BBG.BgBudgetID AND BPO_GBIZ.BgPositionsartID = 2
  --                                      AND BPO_GBIZ.DatumVon IS NULL
  LEFT JOIN (SELECT BPOI.*, POAI.BgPositionsartCode
             FROM BgPosition BPOI
               INNER JOIN BgPositionsart POAI ON POAI.BgPositionsartID = BPOI.BgPositionsartID
             WHERE POAI.BgPositionsartCode = 2) 
                            BPO_GBIZ ON BPO_GBIZ.BgBudgetID = BBG.BgBudgetID
                                    AND BPO_GBIZ.DatumVon IS NULL

  --LEFT  JOIN BgPosition     BPO_GBII ON BPO_GBII.BgBudgetID = BBG.BgBudgetID AND BPO_GBII.BgPositionsartID IN (3, 4)
  --                                      AND BPO_GBII.DatumVon IS NULL
  LEFT JOIN (SELECT BPOI.*, POAI.BgPositionsartCode
             FROM BgPosition BPOI
               INNER JOIN BgPositionsart POAI ON POAI.BgPositionsartID = BPOI.BgPositionsartID
             WHERE POAI.BgPositionsartCode IN (3, 4)) 
                            BPO_GBII ON BPO_GBII.BgBudgetID = BBG.BgBudgetID
                                    AND BPO_GBII.DatumVon IS NULL

  --LEFT  JOIN BgPosition     BPO_MK  ON BPO_MK.BgBudgetID   = BBG.BgBudgetID AND BPO_MK.BgPositionsartID BETWEEN 62 AND 99
  --                                     AND GetDate() BETWEEN IsNull(BPO_MK.DatumVon, ''19000101'')  AND IsNull(BPO_MK.DatumBis, GetDate())
  LEFT JOIN (SELECT BPOI.*, POAI.BgPositionsartCode, Name
             FROM BgPosition BPOI
               INNER JOIN BgPositionsart POAI ON POAI.BgPositionsartID = BPOI.BgPositionsartID
             WHERE POAI.BgPositionsartCode BETWEEN 62 AND 99) 
                            BPO_MK ON BPO_MK.BgBudgetID = BBG.BgBudgetID
                                  AND GetDate() BETWEEN IsNull(BPO_MK.DatumVon, ''19000101'')  AND IsNull(BPO_MK.DatumBis, GetDate())

  --LEFT  JOIN BgPosition     BPO_MNK ON BPO_MNK.BgBudgetID  = BBG.BgBudgetID AND BPO_MNK.BgPositionsartID = 60
  --                                     AND GetDate() BETWEEN IsNull(BPO_MNK.DatumVon, ''19000101'') AND IsNull(BPO_MNK.DatumBis, GetDate())
  LEFT JOIN (SELECT BPOI.*, POAI.BgPositionsartCode
             FROM BgPosition BPOI
               INNER JOIN BgPositionsart POAI ON POAI.BgPositionsartID = BPOI.BgPositionsartID
             WHERE POAI.BgPositionsartCode = 60) 
                            BPO_MNK ON BPO_MNK.BgBudgetID = BBG.BgBudgetID
                                   AND GetDate() BETWEEN IsNull(BPO_MNK.DatumVon, ''19000101'') AND IsNull(BPO_MNK.DatumBis, GetDate())

WHERE BBG.BgBudgetID = @BgBudgetID' ,  null ,  N'ShDetaillierterFinanzplan' ,  null );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShDetaillierterFinanzplan_KvgVvg' ,  N'KVG, VVG' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS40.VSS\KiSS4 Branches\KiSS4233\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\KiSS40.VSS\KiSS4 Branches\KiSS4233\Build\Debug\log4net.dll" />
///     <Reference Path="C:\Projects\KiSS40.VSS\KiSS4 Branches\KiSS4233\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel txtBemerkungRTF;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtVVG_Reduktion;
        private DevExpress.XtraReports.UI.XRLabel txtVVG;
        private DevExpress.XtraReports.UI.XRLabel txtKVG_Reduktion;
        private DevExpress.XtraReports.UI.XRLabel txtKVG;
        private DevExpress.XtraReports.UI.XRLabel txtName;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLine Line6;
        private DevExpress.XtraReports.UI.XRLine Line5;
        private DevExpress.XtraReports.UI.XRLine Line4;
        private DevExpress.XtraReports.UI.XRLabel Label13;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLabel totVVG_Reduziert;
        private DevExpress.XtraReports.UI.XRLabel totKVG_Reduziert;
        private DevExpress.XtraReports.UI.XRLabel Label9;
        private DevExpress.XtraReports.UI.XRLabel TextBox4;
        private DevExpress.XtraReports.UI.XRLabel TextBox3;
        private DevExpress.XtraReports.UI.XRLabel TextBox2;
        private DevExpress.XtraReports.UI.XRLabel TextBox1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
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
                        "AAAAb8KU0VMRUNUDQogIFtOYW1lXSAgICAgICAgICAgPSBQUlMuTmFtZSArICcsICcgKyBQUlMuVm9yb" +
                        "mFtZSwNCg0KICBbS1ZHXSAgICAgICAgICAgID0gQlBPX0tWRy5CZXRyYWcsDQogIFtLVkdfUmVkdWt0a" +
                        "W9uXSAgPSBCUE9fS1ZHLkFienVnLA0KICBbS1ZHX1JlZHV6aWVydF0gID0gQlBPX0tWRy5CZXRyYWcgL" +
                        "SBCUE9fS1ZHLkFienVnLA0KDQogIFtWVkddICAgICAgICAgICAgPSBCUE9fVlZHLkJldHJhZywNCiAgW" +
                        "1ZWR19SZWR1a3Rpb25dICA9IEJQT19WVkcuQWJ6dWcsDQogIFtWVkdfUmVkdXppZXJ0XSAgPSBCUE9fV" +
                        "lZHLkJldHJhZyAtIEJQT19WVkcuQWJ6dWcsDQoNCiAgW0JlbWVya3VuZ10gICAgICA9IEJQT19LVkcuQ" +
                        "mVtZXJrdW5nDQoNCkZST00gQmdGaW5hbnpwbGFuX0JhUGVyc29uICAgU1BQDQogIElOTkVSIEpPSU4gQ" +
                        "mdCdWRnZXQgICAgICAgIEJCRyAgICAgT04gQkJHLkJnRmluYW56cGxhbklEID0gU1BQLkJnRmluYW56c" +
                        "GxhbklEIEFORCBCQkcuTWFzdGVyQnVkZ2V0ID0gMQ0KICBJTk5FUiBKT0lOIEJhUGVyc29uICAgICAgI" +
                        "CBQUlMgICAgIE9OIFBSUy5CYVBlcnNvbklEID0gU1BQLkJhUGVyc29uSUQNCiAgTEVGVCBKT0lOIChTR" +
                        "UxFQ1QgQlBPSS4qLCBQT0FJLkJnUG9zaXRpb25zYXJ0Q29kZQ0KICAgICAgICAgICAgIEZST00gQmdQb" +
                        "3NpdGlvbiBCUE9JDQogICAgICAgICAgICAgICBJTk5FUiBKT0lOIEJnUG9zaXRpb25zYXJ0IFBPQUkgT" +
                        "04gUE9BSS5CZ1Bvc2l0aW9uc2FydElEID0gQlBPSS5CZ1Bvc2l0aW9uc2FydElEDQogICAgICAgICAgI" +
                        "CAgV0hFUkUgUE9BSS5CZ1Bvc2l0aW9uc2FydENvZGUgPSAzMjAyMCBBTkQgUE9BSS5Tb3J0S2V5ID0gM" +
                        "SkgLS13YXJ1bSBuaWNodCBkaWUgYW5kZXJlbiBLVkctQ29kZXMgKGbDvHIgUmVnaW9uIDEtMy4uLikgY" +
                        "XVjaCBub2NoPw0KICAgICAgICAgICAgICAgICAgICAgICAgICAgIEJQT19LVkcgT04gQlBPX0tWRy5CZ" +
                        "0J1ZGdldElEID0gQkJHLkJnQnVkZ2V0SUQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgQU5EIEJQT19LVkcuQmFQZXJzb25JRCA9IFNQUC5CYVBlcnNvbklEDQogICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgIEFORCBHZXREYXRlKCkgQkVUV0VFTiBJc051bGwoQlBPX0tWRy5EYXR1b" +
                        "VZvbiwgJzE5MDAwMTAxJykgQU5EIElzTnVsbChCUE9fS1ZHLkRhdHVtQmlzLCBHZXREYXRlKCkpDQogI" +
                        "ExFRlQgIEpPSU4gQmdQb3NpdGlvbiAgICAgQlBPX1ZWRyBPTiBCUE9fVlZHLkJnUG9zaXRpb25JRF9QY" +
                        "XJlbnQgPSBCUE9fS1ZHLkJnUG9zaXRpb25JRA0KV0hFUkUgU1BQLkJnRmluYW56cGxhbklEID0gbnVsb" +
                        "CBBTkQgU1BQLklzdFVudGVyc3R1ZXR6dCA9IDE=";
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
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary10 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.txtBemerkungRTF = new DevExpress.XtraReports.UI.XRLabel();
            this.txtVVG_Reduktion = new DevExpress.XtraReports.UI.XRLabel();
            this.txtVVG = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKVG_Reduktion = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKVG = new DevExpress.XtraReports.UI.XRLabel();
            this.txtName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line6 = new DevExpress.XtraReports.UI.XRLine();
            this.Line5 = new DevExpress.XtraReports.UI.XRLine();
            this.Line4 = new DevExpress.XtraReports.UI.XRLine();
            this.Label13 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.totVVG_Reduziert = new DevExpress.XtraReports.UI.XRLabel();
            this.totKVG_Reduziert = new DevExpress.XtraReports.UI.XRLabel();
            this.Label9 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox4 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox3 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox2 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox1 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Line1,
                        this.txtBemerkungRTF,
                        this.txtVVG_Reduktion,
                        this.txtVVG,
                        this.txtKVG_Reduktion,
                        this.txtKVG,
                        this.txtName});
            this.Detail.Height = 46;
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
            this.ReportHeader.Height = 0;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.ParentStyleUsing.UseBackColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorderColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorders = false;
            this.ReportHeader.ParentStyleUsing.UseBorderWidth = false;
            this.ReportHeader.ParentStyleUsing.UseFont = false;
            this.ReportHeader.ParentStyleUsing.UseForeColor = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Height = 0;
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
                        this.xrLabel6,
                        this.xrLabel2,
                        this.xrLabel1,
                        this.xrLabel8,
                        this.xrLabel7,
                        this.xrLabel5,
                        this.xrLabel4,
                        this.xrLabel3});
            this.GroupHeader1.Height = 69;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Line6,
                        this.Line5,
                        this.Line4,
                        this.Label13,
                        this.Line3,
                        this.totVVG_Reduziert,
                        this.totKVG_Reduziert,
                        this.Label9,
                        this.TextBox4,
                        this.TextBox3,
                        this.TextBox2,
                        this.TextBox1});
            this.GroupFooter1.Height = 97;
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
            this.PageFooter.Height = 0;
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
            this.ReportFooter.Height = 0;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.Location = new System.Drawing.Point(0, 0);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(681, 2);
            // 
            // txtBemerkungRTF
            // 
            this.txtBemerkungRTF.CanShrink = true;
            this.txtBemerkungRTF.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bemerkung", "")});
            this.txtBemerkungRTF.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.txtBemerkungRTF.ForeColor = System.Drawing.Color.Black;
            this.txtBemerkungRTF.Location = new System.Drawing.Point(3, 23);
            this.txtBemerkungRTF.Multiline = true;
            this.txtBemerkungRTF.Name = "txtBemerkungRTF";
            this.txtBemerkungRTF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBemerkungRTF.ParentStyleUsing.UseBackColor = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorderColor = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorders = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorderWidth = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseFont = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseForeColor = false;
            this.txtBemerkungRTF.Size = new System.Drawing.Size(677, 19);
            this.txtBemerkungRTF.Text = "txtBemerkungRTF";
            this.txtBemerkungRTF.WordWrap = false;
            // 
            // txtVVG_Reduktion
            // 
            this.txtVVG_Reduktion.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VVG_Reduktion", "{0:n2}")});
            this.txtVVG_Reduktion.Font = new System.Drawing.Font("Arial", 10F);
            this.txtVVG_Reduktion.ForeColor = System.Drawing.Color.Black;
            this.txtVVG_Reduktion.Location = new System.Drawing.Point(582, 3);
            this.txtVVG_Reduktion.Multiline = true;
            this.txtVVG_Reduktion.Name = "txtVVG_Reduktion";
            this.txtVVG_Reduktion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtVVG_Reduktion.ParentStyleUsing.UseBackColor = false;
            this.txtVVG_Reduktion.ParentStyleUsing.UseBorderColor = false;
            this.txtVVG_Reduktion.ParentStyleUsing.UseBorders = false;
            this.txtVVG_Reduktion.ParentStyleUsing.UseBorderWidth = false;
            this.txtVVG_Reduktion.ParentStyleUsing.UseFont = false;
            this.txtVVG_Reduktion.ParentStyleUsing.UseForeColor = false;
            this.txtVVG_Reduktion.Size = new System.Drawing.Size(98, 19);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtVVG_Reduktion.Summary = xrSummary1;
            this.txtVVG_Reduktion.Text = "VVG_Reduktion";
            this.txtVVG_Reduktion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtVVG
            // 
            this.txtVVG.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VVG", "{0:n2}")});
            this.txtVVG.Font = new System.Drawing.Font("Arial", 10F);
            this.txtVVG.ForeColor = System.Drawing.Color.Black;
            this.txtVVG.Location = new System.Drawing.Point(484, 3);
            this.txtVVG.Multiline = true;
            this.txtVVG.Name = "txtVVG";
            this.txtVVG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtVVG.ParentStyleUsing.UseBackColor = false;
            this.txtVVG.ParentStyleUsing.UseBorderColor = false;
            this.txtVVG.ParentStyleUsing.UseBorders = false;
            this.txtVVG.ParentStyleUsing.UseBorderWidth = false;
            this.txtVVG.ParentStyleUsing.UseFont = false;
            this.txtVVG.ParentStyleUsing.UseForeColor = false;
            this.txtVVG.Size = new System.Drawing.Size(98, 19);
            xrSummary2.FormatString = "{0:#,##0.00}";
            this.txtVVG.Summary = xrSummary2;
            this.txtVVG.Text = "VVG";
            this.txtVVG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtKVG_Reduktion
            // 
            this.txtKVG_Reduktion.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KVG_Reduktion", "{0:n2}")});
            this.txtKVG_Reduktion.Font = new System.Drawing.Font("Arial", 10F);
            this.txtKVG_Reduktion.ForeColor = System.Drawing.Color.Black;
            this.txtKVG_Reduktion.Location = new System.Drawing.Point(346, 3);
            this.txtKVG_Reduktion.Multiline = true;
            this.txtKVG_Reduktion.Name = "txtKVG_Reduktion";
            this.txtKVG_Reduktion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKVG_Reduktion.ParentStyleUsing.UseBackColor = false;
            this.txtKVG_Reduktion.ParentStyleUsing.UseBorderColor = false;
            this.txtKVG_Reduktion.ParentStyleUsing.UseBorders = false;
            this.txtKVG_Reduktion.ParentStyleUsing.UseBorderWidth = false;
            this.txtKVG_Reduktion.ParentStyleUsing.UseFont = false;
            this.txtKVG_Reduktion.ParentStyleUsing.UseForeColor = false;
            this.txtKVG_Reduktion.Size = new System.Drawing.Size(98, 19);
            xrSummary3.FormatString = "{0:#,##0.00}";
            this.txtKVG_Reduktion.Summary = xrSummary3;
            this.txtKVG_Reduktion.Text = "KVG_Reduktion";
            this.txtKVG_Reduktion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtKVG
            // 
            this.txtKVG.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KVG", "{0:n2}")});
            this.txtKVG.Font = new System.Drawing.Font("Arial", 10F);
            this.txtKVG.ForeColor = System.Drawing.Color.Black;
            this.txtKVG.Location = new System.Drawing.Point(248, 3);
            this.txtKVG.Multiline = true;
            this.txtKVG.Name = "txtKVG";
            this.txtKVG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKVG.ParentStyleUsing.UseBackColor = false;
            this.txtKVG.ParentStyleUsing.UseBorderColor = false;
            this.txtKVG.ParentStyleUsing.UseBorders = false;
            this.txtKVG.ParentStyleUsing.UseBorderWidth = false;
            this.txtKVG.ParentStyleUsing.UseFont = false;
            this.txtKVG.ParentStyleUsing.UseForeColor = false;
            this.txtKVG.Size = new System.Drawing.Size(98, 19);
            xrSummary4.FormatString = "{0:#,##0.00}";
            this.txtKVG.Summary = xrSummary4;
            this.txtKVG.Text = "KVG";
            this.txtKVG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtName
            // 
            this.txtName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.txtName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(3, 3);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtName.ParentStyleUsing.UseBackColor = false;
            this.txtName.ParentStyleUsing.UseBorderColor = false;
            this.txtName.ParentStyleUsing.UseBorders = false;
            this.txtName.ParentStyleUsing.UseBorderWidth = false;
            this.txtName.ParentStyleUsing.UseFont = false;
            this.txtName.ParentStyleUsing.UseForeColor = false;
            this.txtName.Size = new System.Drawing.Size(244, 19);
            this.txtName.Text = "Name";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel6.Location = new System.Drawing.Point(579, 29);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.Size = new System.Drawing.Size(42, 13);
            this.xrLabel6.Text = "VVG";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel2.Location = new System.Drawing.Point(583, 55);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(98, 14);
            this.xrLabel2.Text = "Reduktion";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel1.Location = new System.Drawing.Point(250, 55);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(96, 14);
            this.xrLabel1.Text = "Prämien";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.xrLabel8.Location = new System.Drawing.Point(0, 0);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.Size = new System.Drawing.Size(653, 20);
            this.xrLabel8.Text = "Prämien für Krankenversicherung (KVG) und Zusatzversicherung";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel7.Location = new System.Drawing.Point(0, 55);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.Size = new System.Drawing.Size(120, 14);
            this.xrLabel7.Text = "Name, Vorname";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel5.Location = new System.Drawing.Point(346, 55);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(98, 14);
            this.xrLabel5.Text = "Reduktion";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel4.Location = new System.Drawing.Point(483, 55);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(100, 14);
            this.xrLabel4.Text = "Prämien";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel3.Location = new System.Drawing.Point(339, 29);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(47, 13);
            this.xrLabel3.Text = "KVG";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Line6
            // 
            this.Line6.ForeColor = System.Drawing.Color.Black;
            this.Line6.Location = new System.Drawing.Point(0, 37);
            this.Line6.Name = "Line6";
            this.Line6.ParentStyleUsing.UseBackColor = false;
            this.Line6.ParentStyleUsing.UseBorderColor = false;
            this.Line6.ParentStyleUsing.UseBorders = false;
            this.Line6.ParentStyleUsing.UseBorderWidth = false;
            this.Line6.ParentStyleUsing.UseFont = false;
            this.Line6.ParentStyleUsing.UseForeColor = false;
            this.Line6.Size = new System.Drawing.Size(681, 2);
            // 
            // Line5
            // 
            this.Line5.ForeColor = System.Drawing.Color.Black;
            this.Line5.Location = new System.Drawing.Point(248, 70);
            this.Line5.Name = "Line5";
            this.Line5.ParentStyleUsing.UseBackColor = false;
            this.Line5.ParentStyleUsing.UseBorderColor = false;
            this.Line5.ParentStyleUsing.UseBorders = false;
            this.Line5.ParentStyleUsing.UseBorderWidth = false;
            this.Line5.ParentStyleUsing.UseFont = false;
            this.Line5.ParentStyleUsing.UseForeColor = false;
            this.Line5.Size = new System.Drawing.Size(433, 2);
            // 
            // Line4
            // 
            this.Line4.ForeColor = System.Drawing.Color.Black;
            this.Line4.Location = new System.Drawing.Point(248, 66);
            this.Line4.Name = "Line4";
            this.Line4.ParentStyleUsing.UseBackColor = false;
            this.Line4.ParentStyleUsing.UseBorderColor = false;
            this.Line4.ParentStyleUsing.UseBorders = false;
            this.Line4.ParentStyleUsing.UseBorderWidth = false;
            this.Line4.ParentStyleUsing.UseFont = false;
            this.Line4.ParentStyleUsing.UseForeColor = false;
            this.Line4.Size = new System.Drawing.Size(433, 2);
            // 
            // Label13
            // 
            this.Label13.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label13.ForeColor = System.Drawing.Color.Black;
            this.Label13.Location = new System.Drawing.Point(484, 43);
            this.Label13.Name = "Label13";
            this.Label13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label13.ParentStyleUsing.UseBackColor = false;
            this.Label13.ParentStyleUsing.UseBorderColor = false;
            this.Label13.ParentStyleUsing.UseBorders = false;
            this.Label13.ParentStyleUsing.UseBorderWidth = false;
            this.Label13.ParentStyleUsing.UseFont = false;
            this.Label13.ParentStyleUsing.UseForeColor = false;
            this.Label13.Size = new System.Drawing.Size(98, 19);
            this.Label13.Text = "VVG Total";
            // 
            // Line3
            // 
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.Location = new System.Drawing.Point(0, 3);
            this.Line3.Name = "Line3";
            this.Line3.ParentStyleUsing.UseBackColor = false;
            this.Line3.ParentStyleUsing.UseBorderColor = false;
            this.Line3.ParentStyleUsing.UseBorders = false;
            this.Line3.ParentStyleUsing.UseBorderWidth = false;
            this.Line3.ParentStyleUsing.UseFont = false;
            this.Line3.ParentStyleUsing.UseForeColor = false;
            this.Line3.Size = new System.Drawing.Size(681, 2);
            // 
            // totVVG_Reduziert
            // 
            this.totVVG_Reduziert.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VVG_Reduziert", "{0:n2}")});
            this.totVVG_Reduziert.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.totVVG_Reduziert.ForeColor = System.Drawing.Color.Black;
            this.totVVG_Reduziert.Location = new System.Drawing.Point(582, 43);
            this.totVVG_Reduziert.Multiline = true;
            this.totVVG_Reduziert.Name = "totVVG_Reduziert";
            this.totVVG_Reduziert.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totVVG_Reduziert.ParentStyleUsing.UseBackColor = false;
            this.totVVG_Reduziert.ParentStyleUsing.UseBorderColor = false;
            this.totVVG_Reduziert.ParentStyleUsing.UseBorders = false;
            this.totVVG_Reduziert.ParentStyleUsing.UseBorderWidth = false;
            this.totVVG_Reduziert.ParentStyleUsing.UseFont = false;
            this.totVVG_Reduziert.ParentStyleUsing.UseForeColor = false;
            this.totVVG_Reduziert.Size = new System.Drawing.Size(98, 19);
            xrSummary5.FormatString = "{0:#,##0.00}";
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.totVVG_Reduziert.Summary = xrSummary5;
            this.totVVG_Reduziert.Text = "totVVG_Reduziert";
            this.totVVG_Reduziert.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // totKVG_Reduziert
            // 
            this.totKVG_Reduziert.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KVG_Reduziert", "")});
            this.totKVG_Reduziert.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.totKVG_Reduziert.ForeColor = System.Drawing.Color.Black;
            this.totKVG_Reduziert.Location = new System.Drawing.Point(346, 43);
            this.totKVG_Reduziert.Multiline = true;
            this.totKVG_Reduziert.Name = "totKVG_Reduziert";
            this.totKVG_Reduziert.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totKVG_Reduziert.ParentStyleUsing.UseBackColor = false;
            this.totKVG_Reduziert.ParentStyleUsing.UseBorderColor = false;
            this.totKVG_Reduziert.ParentStyleUsing.UseBorders = false;
            this.totKVG_Reduziert.ParentStyleUsing.UseBorderWidth = false;
            this.totKVG_Reduziert.ParentStyleUsing.UseFont = false;
            this.totKVG_Reduziert.ParentStyleUsing.UseForeColor = false;
            this.totKVG_Reduziert.Size = new System.Drawing.Size(98, 19);
            xrSummary6.FormatString = "{0:#,##0.00}";
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.totKVG_Reduziert.Summary = xrSummary6;
            this.totKVG_Reduziert.Text = "totKVG_Reduziert";
            this.totKVG_Reduziert.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label9
            // 
            this.Label9.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(248, 43);
            this.Label9.Name = "Label9";
            this.Label9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label9.ParentStyleUsing.UseBackColor = false;
            this.Label9.ParentStyleUsing.UseBorderColor = false;
            this.Label9.ParentStyleUsing.UseBorders = false;
            this.Label9.ParentStyleUsing.UseBorderWidth = false;
            this.Label9.ParentStyleUsing.UseFont = false;
            this.Label9.ParentStyleUsing.UseForeColor = false;
            this.Label9.Size = new System.Drawing.Size(98, 19);
            this.Label9.Text = "KVG Total";
            // 
            // TextBox4
            // 
            this.TextBox4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VVG_Reduktion", "")});
            this.TextBox4.Font = new System.Drawing.Font("Arial", 10F);
            this.TextBox4.ForeColor = System.Drawing.Color.Black;
            this.TextBox4.Location = new System.Drawing.Point(582, 11);
            this.TextBox4.Multiline = true;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox4.ParentStyleUsing.UseBackColor = false;
            this.TextBox4.ParentStyleUsing.UseBorderColor = false;
            this.TextBox4.ParentStyleUsing.UseBorders = false;
            this.TextBox4.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox4.ParentStyleUsing.UseFont = false;
            this.TextBox4.ParentStyleUsing.UseForeColor = false;
            this.TextBox4.Size = new System.Drawing.Size(98, 19);
            xrSummary7.FormatString = "{0:#,##0.00}";
            xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.TextBox4.Summary = xrSummary7;
            this.TextBox4.Text = "TextBox4";
            this.TextBox4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox3
            // 
            this.TextBox3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VVG", "")});
            this.TextBox3.Font = new System.Drawing.Font("Arial", 10F);
            this.TextBox3.ForeColor = System.Drawing.Color.Black;
            this.TextBox3.Location = new System.Drawing.Point(484, 11);
            this.TextBox3.Multiline = true;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox3.ParentStyleUsing.UseBackColor = false;
            this.TextBox3.ParentStyleUsing.UseBorderColor = false;
            this.TextBox3.ParentStyleUsing.UseBorders = false;
            this.TextBox3.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox3.ParentStyleUsing.UseFont = false;
            this.TextBox3.ParentStyleUsing.UseForeColor = false;
            this.TextBox3.Size = new System.Drawing.Size(98, 19);
            xrSummary8.FormatString = "{0:#,##0.00}";
            xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.TextBox3.Summary = xrSummary8;
            this.TextBox3.Text = "TextBox3";
            this.TextBox3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox2
            // 
            this.TextBox2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KVG_Reduktion", "")});
            this.TextBox2.Font = new System.Drawing.Font("Arial", 10F);
            this.TextBox2.ForeColor = System.Drawing.Color.Black;
            this.TextBox2.Location = new System.Drawing.Point(346, 11);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox2.ParentStyleUsing.UseBackColor = false;
            this.TextBox2.ParentStyleUsing.UseBorderColor = false;
            this.TextBox2.ParentStyleUsing.UseBorders = false;
            this.TextBox2.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox2.ParentStyleUsing.UseFont = false;
            this.TextBox2.ParentStyleUsing.UseForeColor = false;
            this.TextBox2.Size = new System.Drawing.Size(98, 19);
            xrSummary9.FormatString = "{0:#,##0.00}";
            xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.TextBox2.Summary = xrSummary9;
            this.TextBox2.Text = "TextBox2";
            this.TextBox2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox1
            // 
            this.TextBox1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KVG", "")});
            this.TextBox1.Font = new System.Drawing.Font("Arial", 10F);
            this.TextBox1.ForeColor = System.Drawing.Color.Black;
            this.TextBox1.Location = new System.Drawing.Point(248, 11);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox1.ParentStyleUsing.UseBackColor = false;
            this.TextBox1.ParentStyleUsing.UseBorderColor = false;
            this.TextBox1.ParentStyleUsing.UseBorders = false;
            this.TextBox1.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox1.ParentStyleUsing.UseFont = false;
            this.TextBox1.ParentStyleUsing.UseForeColor = false;
            this.TextBox1.Size = new System.Drawing.Size(98, 19);
            xrSummary10.FormatString = "{0:#,##0.00}";
            xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.TextBox1.Summary = xrSummary10;
            this.TextBox1.Text = "totKVG";
            this.TextBox1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail,
                        this.ReportHeader,
                        this.PageHeader,
                        this.GroupHeader1,
                        this.GroupFooter1,
                        this.PageFooter,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Name = "Report";
            this.PageHeight = 1390;
            this.PageWidth = 984;
            this.PaperKind = System.Drawing.Printing.PaperKind.B4;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' ,  null ,  N'SELECT
  [Name]           = PRS.Name + '', '' + PRS.Vorname,

  [KVG]            = BPO_KVG.Betrag,
  [KVG_Reduktion]  = BPO_KVG.Abzug,
  [KVG_Reduziert]  = BPO_KVG.Betrag - BPO_KVG.Abzug,

  [VVG]            = BPO_VVG.Betrag,
  [VVG_Reduktion]  = BPO_VVG.Abzug,
  [VVG_Reduziert]  = BPO_VVG.Betrag - BPO_VVG.Abzug,

  [Bemerkung]      = BPO_KVG.Bemerkung

FROM BgFinanzplan_BaPerson   SPP
  INNER JOIN BgBudget        BBG     ON BBG.BgFinanzplanID = SPP.BgFinanzplanID AND BBG.MasterBudget = 1
  INNER JOIN BaPerson        PRS     ON PRS.BaPersonID = SPP.BaPersonID
  LEFT JOIN (SELECT BPOI.*, POAI.BgPositionsartCode
             FROM BgPosition BPOI
               INNER JOIN BgPositionsart POAI ON POAI.BgPositionsartID = BPOI.BgPositionsartID
             WHERE POAI.BgPositionsartCode = 32020 AND POAI.SortKey = 1) --warum nicht die anderen KVG-Codes (für Region 1-3...) auch noch?
                            BPO_KVG ON BPO_KVG.BgBudgetID = BBG.BgBudgetID
                                   AND BPO_KVG.BaPersonID = SPP.BaPersonID
                                   AND GetDate() BETWEEN IsNull(BPO_KVG.DatumVon, ''19000101'') AND IsNull(BPO_KVG.DatumBis, GetDate())
  LEFT  JOIN BgPosition     BPO_VVG ON BPO_VVG.BgPositionID_Parent = BPO_KVG.BgPositionID
WHERE SPP.BgFinanzplanID = {BgFinanzplanID} AND SPP.IstUnterstuetzt = 1' ,  null ,  N'ShDetaillierterFinanzplan' ,  null );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShDetaillierterFinanzplan_Personen' ,  N'Personen' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\log4net.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRPanel hider;
        private DevExpress.XtraReports.UI.XRLabel hiderGroupFooter;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel txtTitel;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel TextBox4;
        private DevExpress.XtraReports.UI.XRLabel TextBox3;
        private DevExpress.XtraReports.UI.XRLabel TextBox2;
        private DevExpress.XtraReports.UI.XRLabel TextBox1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel txtGebDatum;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3a;
        private DevExpress.XtraReports.UI.XRLabel txtKst;
        private DevExpress.XtraReports.UI.XRLabel lblKst;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3b;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel txtZahlungsweg;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3c;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3d;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3e;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
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
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kA" +
                        "AAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAA" +
                        "AAAAcwRU0VMRUNUIFtUaXRlbF0gICAgICAgICAgICAgID0gJ1VudGVyc3TDvHR6dGUgUGVyc29uZW4sI" +
                        "GlocmUgS29zdGVuc3RlbGxlbiB1bmQgQmFua3ZlcmJpbmR1bmdlbicsDQogICAgICAgW05hbWVdICAgI" +
                        "CAgICAgICAgICAgPSBQUlMuTmFtZSwNCiAgICAgICBbVm9ybmFtZV0gICAgICAgICAgICA9IFBSUy5Wb" +
                        "3JuYW1lLA0KICAgICAgIFtGdWxsTmFtZV0gICAgICAgICAgID0gUFJTLk5hbWUgKyBJc051bGwoJywgJ" +
                        "yArIFBSUy5Wb3JuYW1lLCcnKSArICBDQVNFIExFTihJc051bGwoUFJTLlZvcm5hbWUyLCAnJykpIFdIR" +
                        "U4gMCBUSEVOICcnIEVMU0UgJyAnICsgUFJTLlZvcm5hbWUyIEVORCwNCiAgICAgICBbR2VidXJ0c2Rhd" +
                        "HVtXSAgICAgICA9IFBSUy5HZWJ1cnRzZGF0dW0sDQogICAgICAgW0FIVk51bW1lcl0gICAgICAgICAgP" +
                        "SBQUlMuQUhWTnVtbWVyLA0KICAgICAgIFtIZWltYXRvcnRdICAgICAgICAgID0gUFJTLkhlaW1hdG9yd" +
                        "CwNCiAgICAgICBbSXN0VW50ZXJzdHVldHp0XSAgICA9IFNQUC5Jc3RVbnRlcnN0dWV0enQsDQogICAgI" +
                        "CAgTmFtZUtzdCA9IGRiby5mbktiR2V0S29zdGVuc3RlbGxlKFBSUy5CYVBlcnNvbklEKSwNCiAgICAgI" +
                        "CBLUlQuS3JlZGl0b3JNZWhyemVpbGlnLA0KICAgICAgIEtSVC5aYWhsdW5nc3dlZw0KDQogICAgICAgD" +
                        "QpGUk9NIEJnRmluYW56cGxhbiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgU0ZQDQogICAgIElOT" +
                        "kVSIEpPSU4gQmdGaW5hbnpwbGFuX0JhUGVyc29uICAgICAgICAgU1BQIE9OIFNQUC5CZ0ZpbmFuenBsY" +
                        "W5JRCAgID0gU0ZQLkJnRmluYW56cGxhbklEDQogICAgIElOTkVSIEpPSU4gdndQZXJzb24gICAgICAgI" +
                        "CAgICAgICAgICAgICAgUFJTIE9OIFBSUy5CYVBlcnNvbklEICAgICAgID0gU1BQLkJhUGVyc29uSUQNC" +
                        "iAgICAgTEVGVCBKT0lOICB2d0tyZWRpdG9yICAgICAgICAgICAgICAgICAgICBLUlQgT04gUFJTLkJhU" +
                        "GVyc29uSUQgICAgICAgPSBLUlQuQmFQZXJzb25JRA0KV0hFUkUgU0ZQLkJnRmluYW56cGxhbklEID0gb" +
                        "nVsbCBBTkQgKFNQUC5Jc3RVbnRlcnN0dWV0enQgPSAxKQ0KDQpVTklPTiBBTEwgICAgICAgLS0gbm93I" +
                        "GFsbCB0aGUgcGVyc29ucyB3aG8gYXJlIG5vdCB1bnRlcnN0dWV0enQNCg0KU0VMRUNUIFtUaXRlbF0gI" +
                        "CAgICAgICAgICAgID0gJ1VudGVyc3TDvHR6dGUgUGVyc29uZW4sIGlocmUgS29zdGVuc3RlbGxlbiB1b" +
                        "mQgQmFua3ZlcmJpbmR1bmdlbicsDQogICAgICAgW05hbWVdICAgICAgICAgICAgICAgPSBQUlMuTmFtZ" +
                        "SwNCiAgICAgICBbVm9ybmFtZV0gICAgICAgICAgICA9IFBSUy5Wb3JuYW1lLA0KICAgICAgIFtGdWxsT" +
                        "mFtZV0gICAgICAgICAgID0gUFJTLk5hbWUgKyBJc051bGwoJywgJyArIFBSUy5Wb3JuYW1lLCcnKSArI" +
                        "CBDQVNFIExFTihJc051bGwoUFJTLlZvcm5hbWUyLCAnJykpIFdIRU4gMCBUSEVOICcnIEVMU0UgJyAnI" +
                        "CsgUFJTLlZvcm5hbWUyIEVORCwNCiAgICAgICBbR2VidXJ0c2RhdHVtXSAgICAgICA9IFBSUy5HZWJ1c" +
                        "nRzZGF0dW0sDQogICAgICAgW0FIVk51bW1lcl0gICAgICAgICAgPSBQUlMuQUhWTnVtbWVyLA0KICAgI" +
                        "CAgIFtIZWltYXRvcnRdICAgICAgICAgID0gUFJTLkhlaW1hdG9ydCwNCiAgICAgICBbSXN0VW50ZXJzd" +
                        "HVldHp0XSAgICA9IFNQUC5Jc3RVbnRlcnN0dWV0enQsDQogICAgICAgTmFtZUtzdCA9IGRiby5mbktiR" +
                        "2V0S29zdGVuc3RlbGxlKFBSUy5CYVBlcnNvbklEKSwNCiAgICAgICBLUlQuS3JlZGl0b3JNZWhyemVpb" +
                        "GlnLA0KICAgICAgIEtSVC5aYWhsdW5nc3dlZw0KICAgICAgIA0KRlJPTSBCZ0ZpbmFuenBsYW4gICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgIFNGUA0KICAgICBJTk5FUiBKT0lOIEJnRmluYW56cGxhbl9CY" +
                        "VBlcnNvbiAgICAgICAgIFNQUCBPTiBTUFAuQmdGaW5hbnpwbGFuSUQgICA9IFNGUC5CZ0ZpbmFuenBsY" +
                        "W5JRA0KICAgICBJTk5FUiBKT0lOIHZ3UGVyc29uICAgICAgICAgICAgICAgICAgICAgIFBSUyBPTiBQU" +
                        "lMuQmFQZXJzb25JRCAgICAgICA9IFNQUC5CYVBlcnNvbklEDQogICAgIExFRlQgSk9JTiAgdndLcmVka" +
                        "XRvciAgICAgICAgICAgICAgICAgICAgS1JUIE9OIFBSUy5CYVBlcnNvbklEICAgICAgID0gS1JULkJhU" +
                        "GVyc29uSUQNCldIRVJFIFNGUC5CZ0ZpbmFuenBsYW5JRCA9IG51bGwgQU5EIChTUFAuSXN0VW50ZXJzd" +
                        "HVldHp0ID0gMCkNCg0KT1JERVIgQlkgSXN0VW50ZXJzdHVldHp0IGRlc2MgLS0gZmlyc3QgdW50ZXJzd" +
                        "HVldHp0IG9uZXMsIHJlc3Q6IERFU0MgcHV0cyBOVUxMIGxhc3Q=";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader3a = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader3b = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader3c = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader3d = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader3e = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.hider = new DevExpress.XtraReports.UI.XRPanel();
            this.hiderGroupFooter = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTitel = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.TextBox4 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox3 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox2 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGebDatum = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKst = new DevExpress.XtraReports.UI.XRLabel();
            this.lblKst = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtZahlungsweg = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
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
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.hider});
            this.ReportHeader.Height = 27;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.ParentStyleUsing.UseBackColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorderColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorders = false;
            this.ReportHeader.ParentStyleUsing.UseBorderWidth = false;
            this.ReportHeader.ParentStyleUsing.UseFont = false;
            this.ReportHeader.ParentStyleUsing.UseForeColor = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Height = 0;
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
                        this.txtTitel,
                        this.Line1,
                        this.TextBox4,
                        this.TextBox3,
                        this.TextBox2,
                        this.TextBox1});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("IstUnterstuetzt", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 52;
            this.GroupHeader1.Level = 6;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel13,
                        this.txtGebDatum,
                        this.xrLabel11,
                        this.xrLabel10});
            this.GroupHeader2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("FullName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader2.Height = 29;
            this.GroupHeader2.Level = 5;
            this.GroupHeader2.Name = "GroupHeader2";
            this.GroupHeader2.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader2.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader2.ParentStyleUsing.UseBorders = false;
            this.GroupHeader2.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader2.ParentStyleUsing.UseFont = false;
            this.GroupHeader2.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader3a
            // 
            this.GroupHeader3a.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtKst,
                        this.lblKst});
            this.GroupHeader3a.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("NameKst", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader3a.Height = 20;
            this.GroupHeader3a.Level = 4;
            this.GroupHeader3a.Name = "GroupHeader3a";
            this.GroupHeader3a.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader3a.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader3a.ParentStyleUsing.UseBorders = false;
            this.GroupHeader3a.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader3a.ParentStyleUsing.UseFont = false;
            this.GroupHeader3a.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader3b
            // 
            this.GroupHeader3b.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel12,
                        this.txtZahlungsweg});
            this.GroupHeader3b.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("Zahlungsweg", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader3b.Height = 20;
            this.GroupHeader3b.Level = 3;
            this.GroupHeader3b.Name = "GroupHeader3b";
            this.GroupHeader3b.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader3b.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader3b.ParentStyleUsing.UseBorders = false;
            this.GroupHeader3b.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader3b.ParentStyleUsing.UseFont = false;
            this.GroupHeader3b.ParentStyleUsing.UseForeColor = false;
            this.GroupHeader3b.Scripts.OnBeforePrint = "private void OnBeforePrint(object sender, System.Drawing.Printing.PrintEventArgs " +
                "e) {\r\n\tif(string.IsNullOrEmpty(txtZahlungsweg.Text)){\r\n\t\tGroupHeader3b.Visible =" +
                " false;\r\n\t}\r\n}";
            // 
            // GroupHeader3c
            // 
            this.GroupHeader3c.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("GroupVerrechnung", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader3c.Height = 0;
            this.GroupHeader3c.Level = 2;
            this.GroupHeader3c.Name = "GroupHeader3c";
            this.GroupHeader3c.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader3c.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader3c.ParentStyleUsing.UseBorders = false;
            this.GroupHeader3c.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader3c.ParentStyleUsing.UseFont = false;
            this.GroupHeader3c.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader3d
            // 
            this.GroupHeader3d.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("GroupVerrechnung", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader3d.Height = 0;
            this.GroupHeader3d.Level = 1;
            this.GroupHeader3d.Name = "GroupHeader3d";
            this.GroupHeader3d.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader3d.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader3d.ParentStyleUsing.UseBorders = false;
            this.GroupHeader3d.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader3d.ParentStyleUsing.UseFont = false;
            this.GroupHeader3d.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader3e
            // 
            this.GroupHeader3e.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("GroupVerrechnung", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader3e.Height = 0;
            this.GroupHeader3e.Name = "GroupHeader3e";
            this.GroupHeader3e.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader3e.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader3e.ParentStyleUsing.UseBorders = false;
            this.GroupHeader3e.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader3e.ParentStyleUsing.UseFont = false;
            this.GroupHeader3e.ParentStyleUsing.UseForeColor = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 26;
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
                        this.xrPanel1});
            this.ReportFooter.Height = 27;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // hider
            // 
            this.hider.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.hiderGroupFooter});
            this.hider.Location = new System.Drawing.Point(160, 0);
            this.hider.Name = "hider";
            this.hider.Size = new System.Drawing.Size(340, 27);
            this.hider.Visible = false;
            // 
            // hiderGroupFooter
            // 
            this.hiderGroupFooter.Location = new System.Drawing.Point(13, 0);
            this.hiderGroupFooter.Name = "hiderGroupFooter";
            this.hiderGroupFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hiderGroupFooter.Size = new System.Drawing.Size(100, 20);
            // 
            // txtTitel
            // 
            this.txtTitel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Titel", "")});
            this.txtTitel.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.txtTitel.ForeColor = System.Drawing.Color.Black;
            this.txtTitel.Location = new System.Drawing.Point(0, 1);
            this.txtTitel.Multiline = true;
            this.txtTitel.Name = "txtTitel";
            this.txtTitel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTitel.ParentStyleUsing.UseBackColor = false;
            this.txtTitel.ParentStyleUsing.UseBorderColor = false;
            this.txtTitel.ParentStyleUsing.UseBorders = false;
            this.txtTitel.ParentStyleUsing.UseBorderWidth = false;
            this.txtTitel.ParentStyleUsing.UseFont = false;
            this.txtTitel.ParentStyleUsing.UseForeColor = false;
            this.txtTitel.Size = new System.Drawing.Size(700, 19);
            this.txtTitel.Text = "Titel";
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.Location = new System.Drawing.Point(0, 47);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(700, 2);
            // 
            // TextBox4
            // 
            this.TextBox4.Font = new System.Drawing.Font("Arial", 10F);
            this.TextBox4.ForeColor = System.Drawing.Color.Black;
            this.TextBox4.Location = new System.Drawing.Point(539, 27);
            this.TextBox4.Multiline = true;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox4.ParentStyleUsing.UseBackColor = false;
            this.TextBox4.ParentStyleUsing.UseBorderColor = false;
            this.TextBox4.ParentStyleUsing.UseBorders = false;
            this.TextBox4.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox4.ParentStyleUsing.UseFont = false;
            this.TextBox4.ParentStyleUsing.UseForeColor = false;
            this.TextBox4.Size = new System.Drawing.Size(160, 19);
            this.TextBox4.Text = "Heimatort";
            // 
            // TextBox3
            // 
            this.TextBox3.Font = new System.Drawing.Font("Arial", 10F);
            this.TextBox3.ForeColor = System.Drawing.Color.Black;
            this.TextBox3.Location = new System.Drawing.Point(425, 27);
            this.TextBox3.Multiline = true;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox3.ParentStyleUsing.UseBackColor = false;
            this.TextBox3.ParentStyleUsing.UseBorderColor = false;
            this.TextBox3.ParentStyleUsing.UseBorders = false;
            this.TextBox3.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox3.ParentStyleUsing.UseFont = false;
            this.TextBox3.ParentStyleUsing.UseForeColor = false;
            this.TextBox3.Size = new System.Drawing.Size(114, 19);
            this.TextBox3.Text = "AHV-Nummer";
            // 
            // TextBox2
            // 
            this.TextBox2.Font = new System.Drawing.Font("Arial", 10F);
            this.TextBox2.ForeColor = System.Drawing.Color.Black;
            this.TextBox2.Location = new System.Drawing.Point(326, 27);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox2.ParentStyleUsing.UseBackColor = false;
            this.TextBox2.ParentStyleUsing.UseBorderColor = false;
            this.TextBox2.ParentStyleUsing.UseBorders = false;
            this.TextBox2.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox2.ParentStyleUsing.UseFont = false;
            this.TextBox2.ParentStyleUsing.UseForeColor = false;
            this.TextBox2.Size = new System.Drawing.Size(98, 19);
            this.TextBox2.Text = "Geburtsdatum";
            // 
            // TextBox1
            // 
            this.TextBox1.Font = new System.Drawing.Font("Arial", 10F);
            this.TextBox1.ForeColor = System.Drawing.Color.Black;
            this.TextBox1.Location = new System.Drawing.Point(0, 27);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox1.ParentStyleUsing.UseBackColor = false;
            this.TextBox1.ParentStyleUsing.UseBorderColor = false;
            this.TextBox1.ParentStyleUsing.UseBorders = false;
            this.TextBox1.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox1.ParentStyleUsing.UseFont = false;
            this.TextBox1.ParentStyleUsing.UseForeColor = false;
            this.TextBox1.Size = new System.Drawing.Size(326, 19);
            this.TextBox1.Text = "Name";
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "FullName", "")});
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel13.ForeColor = System.Drawing.Color.Black;
            this.xrLabel13.Location = new System.Drawing.Point(0, 8);
            this.xrLabel13.Multiline = true;
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.ParentStyleUsing.UseBackColor = false;
            this.xrLabel13.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel13.ParentStyleUsing.UseBorders = false;
            this.xrLabel13.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel13.ParentStyleUsing.UseFont = false;
            this.xrLabel13.ParentStyleUsing.UseForeColor = false;
            this.xrLabel13.Size = new System.Drawing.Size(325, 19);
            this.xrLabel13.Text = "xrLabel13";
            // 
            // txtGebDatum
            // 
            this.txtGebDatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Geburtsdatum", "{0:MM/dd/yyyy}")});
            this.txtGebDatum.Font = new System.Drawing.Font("Arial", 10F);
            this.txtGebDatum.ForeColor = System.Drawing.Color.Black;
            this.txtGebDatum.Location = new System.Drawing.Point(325, 8);
            this.txtGebDatum.Multiline = true;
            this.txtGebDatum.Name = "txtGebDatum";
            this.txtGebDatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGebDatum.ParentStyleUsing.UseBackColor = false;
            this.txtGebDatum.ParentStyleUsing.UseBorderColor = false;
            this.txtGebDatum.ParentStyleUsing.UseBorders = false;
            this.txtGebDatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtGebDatum.ParentStyleUsing.UseFont = false;
            this.txtGebDatum.ParentStyleUsing.UseForeColor = false;
            this.txtGebDatum.Size = new System.Drawing.Size(98, 19);
            xrSummary1.FormatString = "{0:dd.MM.yyyy}";
            this.txtGebDatum.Summary = xrSummary1;
            this.txtGebDatum.Text = "txtGebDatum";
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AHVNummer", "")});
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel11.ForeColor = System.Drawing.Color.Black;
            this.xrLabel11.Location = new System.Drawing.Point(425, 8);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.ParentStyleUsing.UseBackColor = false;
            this.xrLabel11.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel11.ParentStyleUsing.UseBorders = false;
            this.xrLabel11.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel11.ParentStyleUsing.UseFont = false;
            this.xrLabel11.ParentStyleUsing.UseForeColor = false;
            this.xrLabel11.Size = new System.Drawing.Size(114, 19);
            this.xrLabel11.Text = "xrLabel11";
            // 
            // xrLabel10
            // 
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Heimatort", "")});
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel10.ForeColor = System.Drawing.Color.Black;
            this.xrLabel10.Location = new System.Drawing.Point(542, 8);
            this.xrLabel10.Multiline = true;
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.ParentStyleUsing.UseBackColor = false;
            this.xrLabel10.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel10.ParentStyleUsing.UseBorders = false;
            this.xrLabel10.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel10.ParentStyleUsing.UseFont = false;
            this.xrLabel10.ParentStyleUsing.UseForeColor = false;
            this.xrLabel10.Size = new System.Drawing.Size(160, 19);
            this.xrLabel10.Text = "xrLabel10";
            // 
            // txtKst
            // 
            this.txtKst.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameKst", "")});
            this.txtKst.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.txtKst.ForeColor = System.Drawing.Color.Black;
            this.txtKst.Location = new System.Drawing.Point(150, 0);
            this.txtKst.Multiline = true;
            this.txtKst.Name = "txtKst";
            this.txtKst.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKst.ParentStyleUsing.UseBackColor = false;
            this.txtKst.ParentStyleUsing.UseBorderColor = false;
            this.txtKst.ParentStyleUsing.UseBorders = false;
            this.txtKst.ParentStyleUsing.UseBorderWidth = false;
            this.txtKst.ParentStyleUsing.UseFont = false;
            this.txtKst.ParentStyleUsing.UseForeColor = false;
            this.txtKst.Size = new System.Drawing.Size(550, 19);
            this.txtKst.Text = "txtKst";
            // 
            // lblKst
            // 
            this.lblKst.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.lblKst.ForeColor = System.Drawing.Color.Black;
            this.lblKst.Location = new System.Drawing.Point(33, 0);
            this.lblKst.Multiline = true;
            this.lblKst.Name = "lblKst";
            this.lblKst.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblKst.ParentStyleUsing.UseBackColor = false;
            this.lblKst.ParentStyleUsing.UseBorderColor = false;
            this.lblKst.ParentStyleUsing.UseBorders = false;
            this.lblKst.ParentStyleUsing.UseBorderWidth = false;
            this.lblKst.ParentStyleUsing.UseFont = false;
            this.lblKst.ParentStyleUsing.UseForeColor = false;
            this.lblKst.Size = new System.Drawing.Size(117, 19);
            this.lblKst.Text = "Kostenstelle:";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.xrLabel12.ForeColor = System.Drawing.Color.Black;
            this.xrLabel12.Location = new System.Drawing.Point(33, 0);
            this.xrLabel12.Multiline = true;
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.ParentStyleUsing.UseBackColor = false;
            this.xrLabel12.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel12.ParentStyleUsing.UseBorders = false;
            this.xrLabel12.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel12.ParentStyleUsing.UseFont = false;
            this.xrLabel12.ParentStyleUsing.UseForeColor = false;
            this.xrLabel12.Size = new System.Drawing.Size(117, 19);
            this.xrLabel12.Text = "Zahlungsweg:";
            // 
            // txtZahlungsweg
            // 
            this.txtZahlungsweg.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Zahlungsweg", "")});
            this.txtZahlungsweg.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.txtZahlungsweg.ForeColor = System.Drawing.Color.Black;
            this.txtZahlungsweg.Location = new System.Drawing.Point(150, 0);
            this.txtZahlungsweg.Multiline = true;
            this.txtZahlungsweg.Name = "txtZahlungsweg";
            this.txtZahlungsweg.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtZahlungsweg.ParentStyleUsing.UseBackColor = false;
            this.txtZahlungsweg.ParentStyleUsing.UseBorderColor = false;
            this.txtZahlungsweg.ParentStyleUsing.UseBorders = false;
            this.txtZahlungsweg.ParentStyleUsing.UseBorderWidth = false;
            this.txtZahlungsweg.ParentStyleUsing.UseFont = false;
            this.txtZahlungsweg.ParentStyleUsing.UseForeColor = false;
            this.txtZahlungsweg.Size = new System.Drawing.Size(550, 19);
            this.txtZahlungsweg.Text = "txtZahlungsweg";
            // 
            // xrPanel1
            // 
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel14});
            this.xrPanel1.Location = new System.Drawing.Point(183, 0);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.Size = new System.Drawing.Size(340, 27);
            this.xrPanel1.Visible = false;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Location = new System.Drawing.Point(17, 0);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.Size = new System.Drawing.Size(100, 20);
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail,
                        this.ReportHeader,
                        this.PageHeader,
                        this.GroupHeader1,
                        this.GroupHeader2,
                        this.GroupHeader3a,
                        this.GroupHeader3b,
                        this.GroupHeader3c,
                        this.GroupHeader3d,
                        this.GroupHeader3e,
                        this.PageFooter,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(0, 59, 100, 100);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ScriptReferencesString = "System.Windows.Forms.dll";
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'SELECT [Titel]              = ''Unterstützte Personen, ihre Kostenstellen und Bankverbindungen'',
       [Name]               = PRS.Name,
       [Vorname]            = PRS.Vorname,
       [FullName]           = PRS.Name + IsNull('', '' + PRS.Vorname,'''') +  CASE LEN(IsNull(PRS.Vorname2, '''')) WHEN 0 THEN '''' ELSE '' '' + PRS.Vorname2 END,
       [Geburtsdatum]       = PRS.Geburtsdatum,
       [AHVNummer]          = PRS.AHVNummer,
       [Heimatort]          = PRS.Heimatort,
       [IstUnterstuetzt]    = SPP.IstUnterstuetzt,
       NameKst = dbo.fnKbGetKostenstelle(PRS.BaPersonID),
       KRT.KreditorMehrzeilig,
       KRT.Zahlungsweg

       
FROM BgFinanzplan                             SFP
     INNER JOIN BgFinanzplan_BaPerson         SPP ON SPP.BgFinanzplanID   = SFP.BgFinanzplanID
     INNER JOIN vwPerson                      PRS ON PRS.BaPersonID       = SPP.BaPersonID
     LEFT JOIN  vwKreditor                    KRT ON PRS.BaPersonID       = KRT.BaPersonID
WHERE SFP.BgFinanzplanID = {BgFinanzplanID} AND (SPP.IstUnterstuetzt = 1)

UNION ALL       -- now all the persons who are not unterstuetzt

SELECT [Titel]              = ''Unterstützte Personen, ihre Kostenstellen und Bankverbindungen'',
       [Name]               = PRS.Name,
       [Vorname]            = PRS.Vorname,
       [FullName]           = PRS.Name + IsNull('', '' + PRS.Vorname,'''') +  CASE LEN(IsNull(PRS.Vorname2, '''')) WHEN 0 THEN '''' ELSE '' '' + PRS.Vorname2 END,
       [Geburtsdatum]       = PRS.Geburtsdatum,
       [AHVNummer]          = PRS.AHVNummer,
       [Heimatort]          = PRS.Heimatort,
       [IstUnterstuetzt]    = SPP.IstUnterstuetzt,
       NameKst = dbo.fnKbGetKostenstelle(PRS.BaPersonID),
       KRT.KreditorMehrzeilig,
       KRT.Zahlungsweg
       
FROM BgFinanzplan                             SFP
     INNER JOIN BgFinanzplan_BaPerson         SPP ON SPP.BgFinanzplanID   = SFP.BgFinanzplanID
     INNER JOIN vwPerson                      PRS ON PRS.BaPersonID       = SPP.BaPersonID
     LEFT JOIN  vwKreditor                    KRT ON PRS.BaPersonID       = KRT.BaPersonID
WHERE SFP.BgFinanzplanID = {BgFinanzplanID} AND (SPP.IstUnterstuetzt = 0)

ORDER BY IstUnterstuetzt desc -- first unterstuetzt ones, rest: DESC puts NULL last' ,  null ,  N'ShDetaillierterFinanzplan' ,  null );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShDetaillierterFinanzplan_Sil' ,  N'SiL' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\log4net.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtBemerkungRTF;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtPersonName;
        private DevExpress.XtraReports.UI.XRLabel txtAbzug;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private DevExpress.XtraReports.UI.XRLabel txtSilName;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRPanel hiderPanel;
        private DevExpress.XtraReports.UI.XRLabel hiderSilTypName;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.XRLabel Label3;
        private DevExpress.XtraReports.UI.XRLabel Label2;
        private DevExpress.XtraReports.UI.XRLabel Label1;
        private DevExpress.XtraReports.UI.XRLabel txtSilTypName;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLine Line5;
        private DevExpress.XtraReports.UI.XRLine Line4;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLabel BetragMINUSReduktion;
        private DevExpress.XtraReports.UI.XRLabel totReduktion;
        private DevExpress.XtraReports.UI.XRLabel totBetrag;
        private DevExpress.XtraReports.UI.XRLabel TextBox1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = @"zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OSNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kAAAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAAAAAAfUEREVDTEFSRSBAQmdCdWRnZXRJRCBpbnQNCg0KU0VMRUNUIEBCZ0J1ZGdldElEID0gQmdCdWRnZXRJRA0KRlJPTSBCZ0J1ZGdldA0KV0hFUkUgQmdGaW5hbnpwbGFuSUQgPSBudWxsIEFORCBNYXN0ZXJCdWRnZXQgPSAxDQoNClNFTEVDVA0KICBbU2lsVHlwTmFtZV0gPSBkYm8uZm5MT1ZUZXh0KCdCZ0dydXBwZScsIFNQVC5CZ0dydXBwZUNvZGUpLA0KICBbUGVyc29uTmFtZV0gPSBQUlMuTmFtZSArICcsICcgKyBQUlMuVm9ybmFtZSwNCiAgW1NpbE5hbWVdICAgID0gU1BULk5hbWUsDQogIEJQTy5CZXRyYWcsDQogIEJQTy5BYnp1ZywNCiAgQlBPLkJlbWVya3VuZywNCiAgQmV0cmFnTWludXNBYnp1ZyA9IEJQTy5CZXRyYWcgLSBCUE8uQWJ6dWcNCkZST00gV2hQb3NpdGlvbnNhcnQgICAgICBTUFQNCiAgSU5ORVIgSk9JTiBCZ1Bvc2l0aW9uICBCUE8gT04gQlBPLkJnUG9zaXRpb25zYXJ0SUQgPSBTUFQuQmdQb3NpdGlvbnNhcnRJRA0KICBMRUZUICBKT0lOIEJhUGVyc29uICAgIFBSUyBPTiBQUlMuQmFQZXJzb25JRCA9IEJQTy5CYVBlcnNvbklEDQpXSEVSRSBTUFQuQmdHcnVwcGVDb2RlID0gMzkwMSBBTkQgQlBPLkJnQnVkZ2V0SUQgPSBAQmdCdWRnZXRJRA0KICBBTkQgQlBPLkRhdHVtVm9uIElTIE5VTEw=";
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
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.txtBemerkungRTF = new DevExpress.XtraReports.UI.XRLabel();
            this.txtPersonName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAbzug = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtSilName = new DevExpress.XtraReports.UI.XRLabel();
            this.hiderPanel = new DevExpress.XtraReports.UI.XRPanel();
            this.hiderSilTypName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtSilTypName = new DevExpress.XtraReports.UI.XRLabel();
            this.Line5 = new DevExpress.XtraReports.UI.XRLine();
            this.Line4 = new DevExpress.XtraReports.UI.XRLine();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.BetragMINUSReduktion = new DevExpress.XtraReports.UI.XRLabel();
            this.totReduktion = new DevExpress.XtraReports.UI.XRLabel();
            this.totBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox1 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtBemerkungRTF,
                        this.txtPersonName,
                        this.txtAbzug,
                        this.txtBetrag,
                        this.txtSilName});
            this.Detail.Height = 40;
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
                        this.hiderPanel});
            this.PageHeader.Height = 27;
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
                        this.xrLine1,
                        this.Label4,
                        this.Label3,
                        this.Label2,
                        this.Label1,
                        this.txtSilTypName});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("SilTypName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 70;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Line5,
                        this.Line4,
                        this.Line3,
                        this.Line2,
                        this.BetragMINUSReduktion,
                        this.totReduktion,
                        this.totBetrag,
                        this.TextBox1});
            this.GroupFooter1.Height = 78;
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
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // txtBemerkungRTF
            // 
            this.txtBemerkungRTF.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bemerkung", "")});
            this.txtBemerkungRTF.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.txtBemerkungRTF.ForeColor = System.Drawing.Color.Black;
            this.txtBemerkungRTF.Location = new System.Drawing.Point(7, 15);
            this.txtBemerkungRTF.Multiline = true;
            this.txtBemerkungRTF.Name = "txtBemerkungRTF";
            this.txtBemerkungRTF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBemerkungRTF.ParentStyleUsing.UseBackColor = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorderColor = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorders = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorderWidth = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseFont = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseForeColor = false;
            this.txtBemerkungRTF.Size = new System.Drawing.Size(680, 19);
            this.txtBemerkungRTF.Text = "txtBemerkungRTF";
            // 
            // txtPersonName
            // 
            this.txtPersonName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "PersonName", "")});
            this.txtPersonName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtPersonName.ForeColor = System.Drawing.Color.Black;
            this.txtPersonName.Location = new System.Drawing.Point(7, 0);
            this.txtPersonName.Multiline = true;
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtPersonName.ParentStyleUsing.UseBackColor = false;
            this.txtPersonName.ParentStyleUsing.UseBorderColor = false;
            this.txtPersonName.ParentStyleUsing.UseBorders = false;
            this.txtPersonName.ParentStyleUsing.UseBorderWidth = false;
            this.txtPersonName.ParentStyleUsing.UseFont = false;
            this.txtPersonName.ParentStyleUsing.UseForeColor = false;
            this.txtPersonName.Size = new System.Drawing.Size(244, 19);
            this.txtPersonName.Text = "PersonName";
            // 
            // txtAbzug
            // 
            this.txtAbzug.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Abzug", "{0:n2}")});
            this.txtAbzug.Font = new System.Drawing.Font("Arial", 10F);
            this.txtAbzug.ForeColor = System.Drawing.Color.Black;
            this.txtAbzug.Location = new System.Drawing.Point(613, 0);
            this.txtAbzug.Multiline = true;
            this.txtAbzug.Name = "txtAbzug";
            this.txtAbzug.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtAbzug.ParentStyleUsing.UseBackColor = false;
            this.txtAbzug.ParentStyleUsing.UseBorderColor = false;
            this.txtAbzug.ParentStyleUsing.UseBorders = false;
            this.txtAbzug.ParentStyleUsing.UseBorderWidth = false;
            this.txtAbzug.ParentStyleUsing.UseFont = false;
            this.txtAbzug.ParentStyleUsing.UseForeColor = false;
            this.txtAbzug.Size = new System.Drawing.Size(78, 19);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtAbzug.Summary = xrSummary1;
            this.txtAbzug.Text = "Abzug";
            this.txtAbzug.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(520, 0);
            this.txtBetrag.Multiline = true;
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(78, 19);
            xrSummary2.FormatString = "{0:#,##0.00}";
            this.txtBetrag.Summary = xrSummary2;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtSilName
            // 
            this.txtSilName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SilName", "")});
            this.txtSilName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtSilName.ForeColor = System.Drawing.Color.Black;
            this.txtSilName.Location = new System.Drawing.Point(251, 0);
            this.txtSilName.Multiline = true;
            this.txtSilName.Name = "txtSilName";
            this.txtSilName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtSilName.ParentStyleUsing.UseBackColor = false;
            this.txtSilName.ParentStyleUsing.UseBorderColor = false;
            this.txtSilName.ParentStyleUsing.UseBorders = false;
            this.txtSilName.ParentStyleUsing.UseBorderWidth = false;
            this.txtSilName.ParentStyleUsing.UseFont = false;
            this.txtSilName.ParentStyleUsing.UseForeColor = false;
            this.txtSilName.Size = new System.Drawing.Size(260, 19);
            this.txtSilName.Text = "SilName";
            // 
            // hiderPanel
            // 
            this.hiderPanel.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.hiderSilTypName});
            this.hiderPanel.Location = new System.Drawing.Point(160, 0);
            this.hiderPanel.Name = "hiderPanel";
            this.hiderPanel.Size = new System.Drawing.Size(347, 27);
            this.hiderPanel.Visible = false;
            // 
            // hiderSilTypName
            // 
            this.hiderSilTypName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SilTypName", "")});
            this.hiderSilTypName.Location = new System.Drawing.Point(0, 0);
            this.hiderSilTypName.Name = "hiderSilTypName";
            this.hiderSilTypName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hiderSilTypName.Scripts.OnAfterPrint = "private void OnAfterPrint(object sender, System.EventArgs e) {\r\n  GroupHeader1.Vi" +
                "sible = hiderSilTypName.Text != String.Empty;\r\n  GroupFooter1.Visible = hiderSil" +
                "TypName.Text != String.Empty;\r\n}";
            this.hiderSilTypName.Size = new System.Drawing.Size(100, 27);
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.Location = new System.Drawing.Point(7, 47);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(686, 3);
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial", 10F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(613, 27);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(78, 19);
            this.Label4.Text = "Reduktion";
            this.Label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Arial", 10F);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(520, 27);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(78, 19);
            this.Label3.Text = "Betrag";
            this.Label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 10F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(251, 27);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(153, 19);
            this.Label2.Text = "Art der Leistung";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 10F);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(7, 27);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(118, 19);
            this.Label1.Text = "Betrifft";
            // 
            // txtSilTypName
            // 
            this.txtSilTypName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SilTypName", "")});
            this.txtSilTypName.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.txtSilTypName.ForeColor = System.Drawing.Color.Black;
            this.txtSilTypName.Location = new System.Drawing.Point(0, 0);
            this.txtSilTypName.Multiline = true;
            this.txtSilTypName.Name = "txtSilTypName";
            this.txtSilTypName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtSilTypName.ParentStyleUsing.UseBackColor = false;
            this.txtSilTypName.ParentStyleUsing.UseBorderColor = false;
            this.txtSilTypName.ParentStyleUsing.UseBorders = false;
            this.txtSilTypName.ParentStyleUsing.UseBorderWidth = false;
            this.txtSilTypName.ParentStyleUsing.UseFont = false;
            this.txtSilTypName.ParentStyleUsing.UseForeColor = false;
            this.txtSilTypName.Size = new System.Drawing.Size(693, 19);
            this.txtSilTypName.Text = "SilTypName";
            // 
            // Line5
            // 
            this.Line5.ForeColor = System.Drawing.Color.Black;
            this.Line5.Location = new System.Drawing.Point(7, 0);
            this.Line5.Name = "Line5";
            this.Line5.ParentStyleUsing.UseBackColor = false;
            this.Line5.ParentStyleUsing.UseBorderColor = false;
            this.Line5.ParentStyleUsing.UseBorders = false;
            this.Line5.ParentStyleUsing.UseBorderWidth = false;
            this.Line5.ParentStyleUsing.UseFont = false;
            this.Line5.ParentStyleUsing.UseForeColor = false;
            this.Line5.Size = new System.Drawing.Size(686, 3);
            // 
            // Line4
            // 
            this.Line4.ForeColor = System.Drawing.Color.Black;
            this.Line4.Location = new System.Drawing.Point(613, 54);
            this.Line4.Name = "Line4";
            this.Line4.ParentStyleUsing.UseBackColor = false;
            this.Line4.ParentStyleUsing.UseBorderColor = false;
            this.Line4.ParentStyleUsing.UseBorders = false;
            this.Line4.ParentStyleUsing.UseBorderWidth = false;
            this.Line4.ParentStyleUsing.UseFont = false;
            this.Line4.ParentStyleUsing.UseForeColor = false;
            this.Line4.Size = new System.Drawing.Size(78, 2);
            // 
            // Line3
            // 
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.Location = new System.Drawing.Point(613, 51);
            this.Line3.Name = "Line3";
            this.Line3.ParentStyleUsing.UseBackColor = false;
            this.Line3.ParentStyleUsing.UseBorderColor = false;
            this.Line3.ParentStyleUsing.UseBorders = false;
            this.Line3.ParentStyleUsing.UseBorderWidth = false;
            this.Line3.ParentStyleUsing.UseFont = false;
            this.Line3.ParentStyleUsing.UseForeColor = false;
            this.Line3.Size = new System.Drawing.Size(78, 2);
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.Location = new System.Drawing.Point(7, 26);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(680, 3);
            // 
            // BetragMINUSReduktion
            // 
            this.BetragMINUSReduktion.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragMinusAbzug", "")});
            this.BetragMINUSReduktion.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.BetragMINUSReduktion.ForeColor = System.Drawing.Color.Black;
            this.BetragMINUSReduktion.Location = new System.Drawing.Point(613, 31);
            this.BetragMINUSReduktion.Multiline = true;
            this.BetragMINUSReduktion.Name = "BetragMINUSReduktion";
            this.BetragMINUSReduktion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.BetragMINUSReduktion.ParentStyleUsing.UseBackColor = false;
            this.BetragMINUSReduktion.ParentStyleUsing.UseBorderColor = false;
            this.BetragMINUSReduktion.ParentStyleUsing.UseBorders = false;
            this.BetragMINUSReduktion.ParentStyleUsing.UseBorderWidth = false;
            this.BetragMINUSReduktion.ParentStyleUsing.UseFont = false;
            this.BetragMINUSReduktion.ParentStyleUsing.UseForeColor = false;
            this.BetragMINUSReduktion.Size = new System.Drawing.Size(78, 19);
            xrSummary3.FormatString = "{0:n2}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.BetragMINUSReduktion.Summary = xrSummary3;
            this.BetragMINUSReduktion.Text = "BetragMINUSReduktion";
            this.BetragMINUSReduktion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // totReduktion
            // 
            this.totReduktion.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Abzug", "{0:n2}")});
            this.totReduktion.Font = new System.Drawing.Font("Arial", 10F);
            this.totReduktion.ForeColor = System.Drawing.Color.Black;
            this.totReduktion.Location = new System.Drawing.Point(613, 3);
            this.totReduktion.Multiline = true;
            this.totReduktion.Name = "totReduktion";
            this.totReduktion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totReduktion.ParentStyleUsing.UseBackColor = false;
            this.totReduktion.ParentStyleUsing.UseBorderColor = false;
            this.totReduktion.ParentStyleUsing.UseBorders = false;
            this.totReduktion.ParentStyleUsing.UseBorderWidth = false;
            this.totReduktion.ParentStyleUsing.UseFont = false;
            this.totReduktion.ParentStyleUsing.UseForeColor = false;
            this.totReduktion.Size = new System.Drawing.Size(78, 19);
            xrSummary4.FormatString = "{0:n2}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.totReduktion.Summary = xrSummary4;
            this.totReduktion.Text = "totReduktion";
            this.totReduktion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // totBetrag
            // 
            this.totBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.totBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.totBetrag.ForeColor = System.Drawing.Color.Black;
            this.totBetrag.Location = new System.Drawing.Point(520, 3);
            this.totBetrag.Multiline = true;
            this.totBetrag.Name = "totBetrag";
            this.totBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totBetrag.ParentStyleUsing.UseBackColor = false;
            this.totBetrag.ParentStyleUsing.UseBorderColor = false;
            this.totBetrag.ParentStyleUsing.UseBorders = false;
            this.totBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.totBetrag.ParentStyleUsing.UseFont = false;
            this.totBetrag.ParentStyleUsing.UseForeColor = false;
            this.totBetrag.Size = new System.Drawing.Size(78, 19);
            xrSummary5.FormatString = "{0:n2}";
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.totBetrag.Summary = xrSummary5;
            this.totBetrag.Text = "totBetrag";
            this.totBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox1
            // 
            this.TextBox1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SilTypName", "Total {0}")});
            this.TextBox1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.TextBox1.ForeColor = System.Drawing.Color.Black;
            this.TextBox1.Location = new System.Drawing.Point(7, 31);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox1.ParentStyleUsing.UseBackColor = false;
            this.TextBox1.ParentStyleUsing.UseBorderColor = false;
            this.TextBox1.ParentStyleUsing.UseBorders = false;
            this.TextBox1.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox1.ParentStyleUsing.UseFont = false;
            this.TextBox1.ParentStyleUsing.UseForeColor = false;
            this.TextBox1.Size = new System.Drawing.Size(593, 19);
            this.TextBox1.Text = "Total SiL";
            this.TextBox1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
                        this.GroupFooter1,
                        this.PageFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(39, 47, 39, 39);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ScriptReferencesString = "System.Windows.Forms.dll";
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'DECLARE @BgBudgetID int

SELECT @BgBudgetID = BgBudgetID
FROM BgBudget
WHERE BgFinanzplanID = {BgFinanzplanID} AND MasterBudget = 1

SELECT
  [SilTypName] = dbo.fnLOVText(''BgGruppe'', SPT.BgGruppeCode),
  [PersonName] = PRS.Name + '', '' + PRS.Vorname,
  [SilName]    = SPT.Name,
  BPO.Betrag,
  BPO.Abzug,
  BPO.Bemerkung,
  BetragMinusAbzug = BPO.Betrag - BPO.Abzug
FROM WhPositionsart      SPT
  INNER JOIN BgPosition  BPO ON BPO.BgPositionsartID = SPT.BgPositionsartID
  LEFT  JOIN BaPerson    PRS ON PRS.BaPersonID = BPO.BaPersonID
WHERE SPT.BgGruppeCode = 3901 AND BPO.BgBudgetID = @BgBudgetID
  AND BPO.DatumVon IS NULL' ,  null ,  N'ShDetaillierterFinanzplan' ,  null );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShDetaillierterFinanzplan_Uebersicht' ,  N'Budget Übersicht' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\log4net.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel Betrag1;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtBezeichnung;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel Label1;
        private DevExpress.XtraReports.UI.GroupHeaderBand grp1H;
        private DevExpress.XtraReports.UI.XRLabel txtGrp1Text;
        private DevExpress.XtraReports.UI.GroupFooterBand grp1F;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel lblTotGrp1;
        private DevExpress.XtraReports.UI.XRLabel Grp1Betrag;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
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
                        "AAAAecQREVDTEFSRSBAQmdCdWRnZXRJRCBpbnQNCg0KU0VMRUNUIEBCZ0J1ZGdldElEID0gQmdCdWRnZ" +
                        "XRJRA0KRlJPTSBCZ0J1ZGdldA0KV0hFUkUgQmdGaW5hbnpwbGFuSUQgPSBudWxsIEFORCBNYXN0ZXJCd" +
                        "WRnZXQgPSAxDQoNClNFTEVDVCBCUE8uQmdQb3NpdGlvbklELCBCUE8uQmdQb3NpdGlvbnNhcnRJRCwgQ" +
                        "lBPLkJldHJhZ0ZpbmFuenBsYW4NCklOVE8gI0JnUG9zaXRpb24NCkZST00gdndCZ1Bvc2l0aW9uICAgI" +
                        "CAgICAgICAgQlBPDQogIElOTkVSIEpPSU4gV2hQb3NpdGlvbnNhcnQgIFNQVCBPTiBTUFQuQmdQb3Npd" +
                        "GlvbnNhcnRJRCA9IEJQTy5CZ1Bvc2l0aW9uc2FydElEDQpXSEVSRSBCUE8uQmdCdWRnZXRJRCA9IEBCZ" +
                        "0J1ZGdldElEIEFORCBCUE8uQmdLYXRlZ29yaWVDb2RlIElOICgxLCAyKQ0KICBBTkQgKCAoQlBPLkRhd" +
                        "HVtVm9uIElTIE5VTEwgIEFORCBCUE8uQmdQb3NpdGlvbnNhcnRJRCBOT1QgSU4gKDIwLCAyMSkgQU5EI" +
                        "EJQTy5CZ1Bvc2l0aW9uc2FydElEIE5PVCBCRVRXRUVOIDYwIEFORCA5OSkgT1INCiAgICAgICAgKChCU" +
                        "E8uQmdQb3NpdGlvbnNhcnRJRCBJTiAoMjAsIDIxKSBPUiBCUE8uQmdQb3NpdGlvbnNhcnRJRCBCRVRXR" +
                        "UVOIDYwIEFORCA5OSkNCiAgICAgICAgICAgQU5EIEdldERhdGUoKSBCRVRXRUVOIElzTnVsbChCUE8uR" +
                        "GF0dW1Wb24sICcxOTAwMDEwMScpIEFORCBJc051bGwoQlBPLkRhdHVtQmlzLCBHZXREYXRlKCkpKQ0KI" +
                        "CAgICAgKQ0KDQpTRUxFQ1QgU1BULkJnS2F0ZWdvcmllQ29kZSwgTUFYKFhQQy5UZXh0KSBBUyBCZ0thd" +
                        "GVnb3JpZVRleHQsDQogIEJnUG9zaXRpb25zYXJ0VGV4dCA9IE1BWChDQVNFDQogICAgICAgICAgICAgV" +
                        "0hFTiBTUFQuQmdHcnVwcGVDb2RlID0gMzIwMSAgICAgIFRIRU4gJ0dydW5kYmVkYXJmJw0KDQogICAgI" +
                        "CAgICAgICAgV0hFTiBTUFQuQmdQb3NpdGlvbnNhcnRJRCA9IDMyMDIwIFRIRU4gJ0tWRyBQcsOkbWllb" +
                        "icNCiAgICAgICAgICAgICBXSEVOIFNQVC5CZ1Bvc2l0aW9uc2FydElEID0gMzIwMjEgVEhFTiAnVlZHI" +
                        "FByw6RtaWVuJw0KICAgICAgICAgICAgIFdIRU4gU1BULkJnUG9zaXRpb25zYXJ0SUQgPSAzMjAyMiBUS" +
                        "EVOICdWVkcgUHLDpG1pZW4nDQoNCiAgICAgICAgICAgICBXSEVOIFNQVC5CZ1Bvc2l0aW9uc2FydElEI" +
                        "D0gMzIwMzAgVEhFTiBTUFQuTmFtZQ0KICAgICAgICAgICAgIFdIRU4gU1BULkJnUG9zaXRpb25zYXJ0S" +
                        "UQgPSAzMjAzMSBUSEVOIFNQVC5OYW1lDQoNCiAgICAgICAgICAgICBFTFNFIFhQVC5UZXh0DQogICAgI" +
                        "CAgICAgIEVORCksDQogIEJldHJhZyA9IFNVTShJc051bGwoQlBPLkJldHJhZ0ZpbmFuenBsYW4sICQwL" +
                        "jAwKSkNCkZST00gV2hQb3NpdGlvbnNhcnQgICAgICAgU1BUDQogIElOTkVSIEpPSU4gWExPVkNvZGUgI" +
                        "CAgIFhQQyBPTiBYUEMuTE9WTmFtZSA9ICdCZ0thdGVnb3JpZScgQU5EIFhQQy5Db2RlID0gU1BULkJnS" +
                        "2F0ZWdvcmllQ29kZQ0KICBJTk5FUiBKT0lOIFhMT1ZDb2RlICAgICBYUFQgT04gWFBULkxPVk5hbWUgP" +
                        "SAnQmdHcnVwcGUnICAgIEFORCBYUFQuQ29kZSA9IFNQVC5CZ0dydXBwZUNvZGUNCiAgTEVGVCAgSk9JT" +
                        "iAjQmdQb3NpdGlvbiAgQlBPIE9OIEJQTy5CZ1Bvc2l0aW9uc2FydElEID0gU1BULkJnUG9zaXRpb25zY" +
                        "XJ0SUQNCldIRVJFIFNQVC5CZ0thdGVnb3JpZUNvZGUgSU4gKDEsIDIpDQogIEFORCBCUE8uQmV0cmFnR" +
                        "mluYW56cGxhbiBJUyBOT1QgTlVMTA0KR1JPVVAgQlkgU1BULkJnS2F0ZWdvcmllQ29kZSwgU1BULkJnS" +
                        "2F0ZWdvcmllQ29kZSwgU1BULkJnR3J1cHBlQ29kZSwNCiAgQ0FTRQ0KICAgIFdIRU4gU1BULkJnR3J1c" +
                        "HBlQ29kZSA9IDMyMDEgICAgICBUSEVOIDENCg0KICAgIFdIRU4gU1BULkJnUG9zaXRpb25zYXJ0SUQgP" +
                        "SAzMjAyMCBUSEVOIDIwDQogICAgV0hFTiBTUFQuQmdQb3NpdGlvbnNhcnRJRCA9IDMyMDIxIFRIRU4gM" +
                        "jENCiAgICBXSEVOIFNQVC5CZ1Bvc2l0aW9uc2FydElEID0gMzIwMjIgVEhFTiAyMQ0KDQogICAgV0hFT" +
                        "iBTUFQuQmdQb3NpdGlvbnNhcnRJRCA9IDMyMDMwIFRIRU4gMzANCiAgICBXSEVOIFNQVC5CZ1Bvc2l0a" +
                        "W9uc2FydElEID0gMzIwMzEgVEhFTiAzMQ0KDQogICAgRUxTRSAwDQogIEVORA0KT1JERVIgQlkgTUFYK" +
                        "FhQQy5Tb3J0S2V5KSwgTUFYKFhQVC5Tb3J0S2V5KQ0KDQpEUk9QIFRBQkxFICNCZ1Bvc2l0aW9u";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.grp1H = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.grp1F = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.Betrag1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBezeichnung = new DevExpress.XtraReports.UI.XRLabel();
            this.Label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGrp1Text = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.lblTotGrp1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Grp1Betrag = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Betrag1,
                        this.txtBezeichnung});
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
                        this.Label1});
            this.ReportHeader.Height = 31;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.ParentStyleUsing.UseBackColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorderColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorders = false;
            this.ReportHeader.ParentStyleUsing.UseBorderWidth = false;
            this.ReportHeader.ParentStyleUsing.UseFont = false;
            this.ReportHeader.ParentStyleUsing.UseForeColor = false;
            // 
            // grp1H
            // 
            this.grp1H.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtGrp1Text});
            this.grp1H.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("BgKategorieCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.grp1H.Height = 19;
            this.grp1H.Name = "grp1H";
            this.grp1H.ParentStyleUsing.UseBackColor = false;
            this.grp1H.ParentStyleUsing.UseBorderColor = false;
            this.grp1H.ParentStyleUsing.UseBorders = false;
            this.grp1H.ParentStyleUsing.UseBorderWidth = false;
            this.grp1H.ParentStyleUsing.UseFont = false;
            this.grp1H.ParentStyleUsing.UseForeColor = false;
            // 
            // grp1F
            // 
            this.grp1F.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel1,
                        this.Line2,
                        this.Line1,
                        this.lblTotGrp1,
                        this.Grp1Betrag});
            this.grp1F.Height = 40;
            this.grp1F.Name = "grp1F";
            this.grp1F.ParentStyleUsing.UseBackColor = false;
            this.grp1F.ParentStyleUsing.UseBorderColor = false;
            this.grp1F.ParentStyleUsing.UseBorders = false;
            this.grp1F.ParentStyleUsing.UseBorderWidth = false;
            this.grp1F.ParentStyleUsing.UseFont = false;
            this.grp1F.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Height = 0;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
            this.ReportFooter.Visible = false;
            // 
            // Betrag1
            // 
            this.Betrag1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.Betrag1.Font = new System.Drawing.Font("Arial", 10F);
            this.Betrag1.ForeColor = System.Drawing.Color.Black;
            this.Betrag1.Location = new System.Drawing.Point(469, 0);
            this.Betrag1.Multiline = true;
            this.Betrag1.Name = "Betrag1";
            this.Betrag1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Betrag1.ParentStyleUsing.UseBackColor = false;
            this.Betrag1.ParentStyleUsing.UseBorderColor = false;
            this.Betrag1.ParentStyleUsing.UseBorders = false;
            this.Betrag1.ParentStyleUsing.UseBorderWidth = false;
            this.Betrag1.ParentStyleUsing.UseFont = false;
            this.Betrag1.ParentStyleUsing.UseForeColor = false;
            this.Betrag1.Size = new System.Drawing.Size(97, 19);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.Betrag1.Summary = xrSummary1;
            this.Betrag1.Text = "Betrag";
            this.Betrag1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtBezeichnung
            // 
            this.txtBezeichnung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BgPositionsartText", "")});
            this.txtBezeichnung.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBezeichnung.ForeColor = System.Drawing.Color.Black;
            this.txtBezeichnung.Location = new System.Drawing.Point(47, 0);
            this.txtBezeichnung.Multiline = true;
            this.txtBezeichnung.Name = "txtBezeichnung";
            this.txtBezeichnung.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBezeichnung.ParentStyleUsing.UseBackColor = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorderColor = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorders = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorderWidth = false;
            this.txtBezeichnung.ParentStyleUsing.UseFont = false;
            this.txtBezeichnung.ParentStyleUsing.UseForeColor = false;
            this.txtBezeichnung.Size = new System.Drawing.Size(375, 19);
            this.txtBezeichnung.Text = "txtBezeichnung";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(0, 12);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(617, 19);
            this.Label1.Text = "Übersicht über das Budget";
            // 
            // txtGrp1Text
            // 
            this.txtGrp1Text.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BgKategorieText", "")});
            this.txtGrp1Text.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtGrp1Text.ForeColor = System.Drawing.Color.Black;
            this.txtGrp1Text.Location = new System.Drawing.Point(0, 0);
            this.txtGrp1Text.Multiline = true;
            this.txtGrp1Text.Name = "txtGrp1Text";
            this.txtGrp1Text.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGrp1Text.ParentStyleUsing.UseBackColor = false;
            this.txtGrp1Text.ParentStyleUsing.UseBorderColor = false;
            this.txtGrp1Text.ParentStyleUsing.UseBorders = false;
            this.txtGrp1Text.ParentStyleUsing.UseBorderWidth = false;
            this.txtGrp1Text.ParentStyleUsing.UseFont = false;
            this.txtGrp1Text.ParentStyleUsing.UseForeColor = false;
            this.txtGrp1Text.Size = new System.Drawing.Size(617, 19);
            this.txtGrp1Text.Text = "txtGrp1Text";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BgKategorieText", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.Location = new System.Drawing.Point(353, 7);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(100, 20);
            this.xrLabel1.Text = "xrLabel1";
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.Location = new System.Drawing.Point(0, 31);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(564, 2);
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.Location = new System.Drawing.Point(311, 0);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(255, 2);
            // 
            // lblTotGrp1
            // 
            this.lblTotGrp1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotGrp1.ForeColor = System.Drawing.Color.Black;
            this.lblTotGrp1.Location = new System.Drawing.Point(311, 7);
            this.lblTotGrp1.Name = "lblTotGrp1";
            this.lblTotGrp1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTotGrp1.ParentStyleUsing.UseBackColor = false;
            this.lblTotGrp1.ParentStyleUsing.UseBorderColor = false;
            this.lblTotGrp1.ParentStyleUsing.UseBorders = false;
            this.lblTotGrp1.ParentStyleUsing.UseBorderWidth = false;
            this.lblTotGrp1.ParentStyleUsing.UseFont = false;
            this.lblTotGrp1.ParentStyleUsing.UseForeColor = false;
            this.lblTotGrp1.Size = new System.Drawing.Size(40, 19);
            this.lblTotGrp1.Text = "Total";
            // 
            // Grp1Betrag
            // 
            this.Grp1Betrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.Grp1Betrag.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Grp1Betrag.ForeColor = System.Drawing.Color.Black;
            this.Grp1Betrag.Location = new System.Drawing.Point(469, 7);
            this.Grp1Betrag.Multiline = true;
            this.Grp1Betrag.Name = "Grp1Betrag";
            this.Grp1Betrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Grp1Betrag.ParentStyleUsing.UseBackColor = false;
            this.Grp1Betrag.ParentStyleUsing.UseBorderColor = false;
            this.Grp1Betrag.ParentStyleUsing.UseBorders = false;
            this.Grp1Betrag.ParentStyleUsing.UseBorderWidth = false;
            this.Grp1Betrag.ParentStyleUsing.UseFont = false;
            this.Grp1Betrag.ParentStyleUsing.UseForeColor = false;
            this.Grp1Betrag.Size = new System.Drawing.Size(97, 19);
            xrSummary2.FormatString = "{0:#,##0.00}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.Grp1Betrag.Summary = xrSummary2;
            this.Grp1Betrag.Text = "Grp1Betrag";
            this.Grp1Betrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail,
                        this.ReportHeader,
                        this.grp1H,
                        this.grp1F,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'DECLARE @BgBudgetID int

SELECT @BgBudgetID = BgBudgetID
FROM BgBudget
WHERE BgFinanzplanID = {BgFinanzplanID} AND MasterBudget = 1

SELECT BPO.BgPositionID, BPO.BgPositionsartID, BPO.BetragFinanzplan
INTO #BgPosition
FROM vwBgPosition            BPO
  INNER JOIN WhPositionsart  SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode IN (1, 2)
  AND GetDate() BETWEEN IsNull(BPO.DatumVon, ''19000101'') AND IsNull(BPO.DatumBis, GetDate())

SELECT SPT.BgKategorieCode, MAX(XPC.Text) AS BgKategorieText,
  BgPositionsartText = MAX(CASE
             WHEN SPT.BgGruppeCode = 3201      THEN ''Grundbedarf''

             WHEN SPT.BgPositionsartCode = 32020 THEN ''KVG Prämien''
             WHEN SPT.BgPositionsartCode = 32021 THEN ''VVG Prämien''
             WHEN SPT.BgPositionsartCode = 32022 THEN ''VVG Prämien''

             WHEN SPT.BgPositionsartCode = 32030 THEN SPT.Name
             WHEN SPT.BgPositionsartCode = 32031 THEN SPT.Name

             ELSE XPT.Text
           END),
  Betrag = SUM(IsNull(BPO.BetragFinanzplan, $0.00))
FROM WhPositionsart       SPT
  INNER JOIN XLOVCode     XPC ON XPC.LOVName = ''BgKategorie'' AND XPC.Code = SPT.BgKategorieCode
  INNER JOIN XLOVCode     XPT ON XPT.LOVName = ''BgGruppe''    AND XPT.Code = SPT.BgGruppeCode
  LEFT  JOIN #BgPosition  BPO ON BPO.BgPositionsartID = SPT.BgPositionsartID
WHERE SPT.BgKategorieCode IN (1, 2)
  AND BPO.BetragFinanzplan IS NOT NULL
GROUP BY SPT.BgKategorieCode, SPT.BgKategorieCode, SPT.BgGruppeCode,
  CASE
    WHEN SPT.BgGruppeCode = 3201      THEN 1

    WHEN SPT.BgPositionsartCode = 32020 THEN 20
    WHEN SPT.BgPositionsartCode = 32021 THEN 21
    WHEN SPT.BgPositionsartCode = 32022 THEN 21

    WHEN SPT.BgPositionsartCode = 32030 THEN 30
    WHEN SPT.BgPositionsartCode = 32031 THEN 31

    ELSE 0
  END
ORDER BY MAX(XPC.SortKey), MAX(XPT.SortKey)

DROP TABLE #BgPosition' ,  null ,  N'ShDetaillierterFinanzplan' ,  null );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShDetaillierterFinanzplan_Vermoegen' ,  N'Vermögen' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\log4net.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS4\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtVerbrauch;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtVermoegensTyp;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private DevExpress.XtraReports.UI.XRLabel txtNamePerson;
        private DevExpress.XtraReports.UI.XRLabel txtBemerkungRTF;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRPanel hiderPanel;
        private DevExpress.XtraReports.UI.XRLabel hiderTxtBemerkungRTF;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel Label5;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel Label3;
        private DevExpress.XtraReports.UI.XRLabel Label2;
        private DevExpress.XtraReports.UI.XRLabel Label1;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLine Line7;
        private DevExpress.XtraReports.UI.XRLine Line6;
        private DevExpress.XtraReports.UI.XRLabel txtSumVerbrauch;
        private DevExpress.XtraReports.UI.XRLabel txtFreibetrag;
        private DevExpress.XtraReports.UI.XRLabel Label9;
        private DevExpress.XtraReports.UI.XRLabel Label8;
        private DevExpress.XtraReports.UI.XRLine Line5;
        private DevExpress.XtraReports.UI.XRLabel totBetragMINUSFreibetrag;
        private DevExpress.XtraReports.UI.XRLabel totBetrag;
        private DevExpress.XtraReports.UI.XRLabel TextBox1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
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
                        "AAAAbINREVDTEFSRSBAQmdCdWRnZXRJRCBpbnQNCg0KU0VMRUNUIEBCZ0J1ZGdldElEID0gQmdCdWRnZ" +
                        "XRJRA0KRlJPTSBCZ0J1ZGdldA0KV0hFUkUgQmdGaW5hbnpwbGFuSUQgPSBudWxsIEFORCBNYXN0ZXJCd" +
                        "WRnZXQgPSAxDQoNCkRFQ0xBUkUgQFJlZkRhdGUgICAgIGRhdGV0aW1lLA0KICAgICAgICBARnJlaWJld" +
                        "HJhZyAgbW9uZXkNCg0KU0VMRUNUIEBSZWZEYXRlID0gZGJvLmZuRGF0ZVNlcmlhbChKYWhyLCBNb25hd" +
                        "CwgMSkNCkZST00gQmdCdWRnZXQNCldIRVJFIEJnQnVkZ2V0SUQgPSBAQmdCdWRnZXRJRA0KDQpTRUxFQ" +
                        "1QgQEZyZWliZXRyYWcgPSBTVU0oQ0FTRSBXSEVOIGRiby5mbkdldEFnZShQUlMuR2VidXJ0c2RhdHVtL" +
                        "CBAUmVmRGF0ZSkgPj0gMTgNCiAgICAgICAgICAgICAgICAgICAgICAgICAgIFRIRU4gQ09OVkVSVChtb" +
                        "25leSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXFNvemlhbGhpbGZlXFNLT1NcRTJcRXJ3YWNoc2VuZScgL" +
                        "CBAUmVmRGF0ZSkpDQogICAgICAgICAgICAgICAgICAgICAgICAgICBFTFNFIENPTlZFUlQobW9uZXksI" +
                        "GRiby5mblhDb25maWcoJ1N5c3RlbVxTb3ppYWxoaWxmZVxTS09TXEUyXE1pbmRlcmrDpGhyaWdlJyAsI" +
                        "EBSZWZEYXRlKSkNCiAgICAgICAgICAgICAgICAgICAgICAgICBFTkQpDQpGUk9NIEJnQnVkZ2V0ICAgI" +
                        "CAgICAgICAgICAgICAgICAgICBCQkcNCiAgSU5ORVIgSk9JTiBCZ0ZpbmFuenBsYW5fQmFQZXJzb24gI" +
                        "FNQUCBPTiBTUFAuQmdGaW5hbnpwbGFuSUQgPSBCQkcuQmdGaW5hbnpwbGFuSUQNCiAgSU5ORVIgSk9JT" +
                        "iBCYVBlcnNvbiAgICAgICAgICAgICAgIFBSUyBPTiBQUlMuQmFQZXJzb25JRCA9IFNQUC5CYVBlcnNvb" +
                        "klEDQpXSEVSRSBCQkcuQmdCdWRnZXRJRCA9IEBCZ0J1ZGdldElEIEFORCBTUFAuSXN0VW50ZXJzdHVld" +
                        "Hp0ID0gMQ0KDQpJRiAoQEZyZWliZXRyYWcgPiBDT05WRVJUKG1vbmV5LCBkYm8uZm5YQ29uZmlnKCdTe" +
                        "XN0ZW1cU296aWFsaGlsZmVcU0tPU1xFMlxNYXhpbWFsJyAsIEBSZWZEYXRlKSkpDQogIFNFVCBARnJla" +
                        "WJldHJhZyA9IENPTlZFUlQobW9uZXksIGRiby5mblhDb25maWcoJ1N5c3RlbVxTb3ppYWxoaWxmZVxTS" +
                        "09TXEUyXE1heGltYWwnICwgQFJlZkRhdGUpKQ0KDQpTRUxFQ1QgQlBPLiosDQogIE5hbWVQZXJzb24gI" +
                        "CAgID0gUFJTLk5hbWUgKyBJc051bGwoJywgJyArIFBSUy5Wb3JuYW1lLCAnJyksDQogIFZlcm1vZWdlb" +
                        "nNUeXAgID0gU1BULk5hbWUsDQogIFZlcmJyYXVjaCAgICAgID0gUFZWLkJldHJhZywNCiAgRnJlaWJld" +
                        "HJhZyAgICAgPSBARnJlaWJldHJhZywNCiAgVG90QmV0cmFnTWludXNGcmVpYmV0cmFnID0gQlBPLkJld" +
                        "HJhZy1ARnJlaWJldHJhZw0KRlJPTSBCZ1Bvc2l0aW9uICAgICAgICAgICAgICBCUE8NCiAgSU5ORVIgS" +
                        "k9JTiBXaFBvc2l0aW9uc2FydCAgU1BUIE9OIFNQVC5CZ1Bvc2l0aW9uc2FydElEID0gQlBPLkJnUG9za" +
                        "XRpb25zYXJ0SUQNCiAgTEVGVCAgSk9JTiBCYVBlcnNvbiAgICAgICAgUFJTIE9OIFBSUy5CYVBlcnNvb" +
                        "klEID0gQlBPLkJhUGVyc29uSUQNCiAgTEVGVCAgSk9JTiBCZ1Bvc2l0aW9uICAgICAgUFZWIE9OIFBWV" +
                        "i5CZ1Bvc2l0aW9uSURfUGFyZW50ID0gQlBPLkJnUG9zaXRpb25JRA0KV0hFUkUgQlBPLkJnQnVkZ2V0S" +
                        "UQgPSBAQmdCdWRnZXRJRCBBTkQgU1BULkJnR3J1cHBlQ29kZSA9IDMxMDQgQU5EIFNQVC5CZ0thdGVnb" +
                        "3JpZUNvZGUgPSA1DQogIEFORCBCUE8uRGF0dW1Wb24gSVMgTlVMTA==";
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
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.txtVerbrauch = new DevExpress.XtraReports.UI.XRLabel();
            this.txtVermoegensTyp = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNamePerson = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBemerkungRTF = new DevExpress.XtraReports.UI.XRLabel();
            this.hiderPanel = new DevExpress.XtraReports.UI.XRPanel();
            this.hiderTxtBemerkungRTF = new DevExpress.XtraReports.UI.XRLabel();
            this.Label5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.Label3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line7 = new DevExpress.XtraReports.UI.XRLine();
            this.Line6 = new DevExpress.XtraReports.UI.XRLine();
            this.txtSumVerbrauch = new DevExpress.XtraReports.UI.XRLabel();
            this.txtFreibetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.Label9 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line5 = new DevExpress.XtraReports.UI.XRLine();
            this.totBetragMINUSFreibetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.totBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox1 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtVerbrauch,
                        this.txtVermoegensTyp,
                        this.txtBetrag,
                        this.txtNamePerson,
                        this.txtBemerkungRTF});
            this.Detail.Height = 40;
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
                        this.hiderPanel});
            this.PageHeader.Height = 75;
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
                        this.Label5,
                        this.Line1,
                        this.Label3,
                        this.Label2,
                        this.Label1,
                        this.Label7});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("SilTypName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 70;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Line7,
                        this.Line6,
                        this.txtSumVerbrauch,
                        this.txtFreibetrag,
                        this.Label9,
                        this.Label8,
                        this.Line5,
                        this.totBetragMINUSFreibetrag,
                        this.totBetrag,
                        this.TextBox1});
            this.GroupFooter1.Height = 91;
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
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // txtVerbrauch
            // 
            this.txtVerbrauch.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Verbrauch", "{0:n2}")});
            this.txtVerbrauch.Font = new System.Drawing.Font("Arial", 10F);
            this.txtVerbrauch.ForeColor = System.Drawing.Color.Black;
            this.txtVerbrauch.Location = new System.Drawing.Point(613, 0);
            this.txtVerbrauch.Multiline = true;
            this.txtVerbrauch.Name = "txtVerbrauch";
            this.txtVerbrauch.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtVerbrauch.ParentStyleUsing.UseBackColor = false;
            this.txtVerbrauch.ParentStyleUsing.UseBorderColor = false;
            this.txtVerbrauch.ParentStyleUsing.UseBorders = false;
            this.txtVerbrauch.ParentStyleUsing.UseBorderWidth = false;
            this.txtVerbrauch.ParentStyleUsing.UseFont = false;
            this.txtVerbrauch.ParentStyleUsing.UseForeColor = false;
            this.txtVerbrauch.Size = new System.Drawing.Size(78, 19);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtVerbrauch.Summary = xrSummary1;
            this.txtVerbrauch.Text = "Verbrauch";
            this.txtVerbrauch.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtVermoegensTyp
            // 
            this.txtVermoegensTyp.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VermoegensTyp", "")});
            this.txtVermoegensTyp.Font = new System.Drawing.Font("Arial", 10F);
            this.txtVermoegensTyp.ForeColor = System.Drawing.Color.Black;
            this.txtVermoegensTyp.Location = new System.Drawing.Point(216, 0);
            this.txtVermoegensTyp.Multiline = true;
            this.txtVermoegensTyp.Name = "txtVermoegensTyp";
            this.txtVermoegensTyp.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtVermoegensTyp.ParentStyleUsing.UseBackColor = false;
            this.txtVermoegensTyp.ParentStyleUsing.UseBorderColor = false;
            this.txtVermoegensTyp.ParentStyleUsing.UseBorders = false;
            this.txtVermoegensTyp.ParentStyleUsing.UseBorderWidth = false;
            this.txtVermoegensTyp.ParentStyleUsing.UseFont = false;
            this.txtVermoegensTyp.ParentStyleUsing.UseForeColor = false;
            this.txtVermoegensTyp.Size = new System.Drawing.Size(313, 19);
            this.txtVermoegensTyp.Text = "VermoegensTyp";
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(533, 0);
            this.txtBetrag.Multiline = true;
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(78, 19);
            xrSummary2.FormatString = "{0:#,##0.00}";
            this.txtBetrag.Summary = xrSummary2;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtNamePerson
            // 
            this.txtNamePerson.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NamePerson", "")});
            this.txtNamePerson.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNamePerson.ForeColor = System.Drawing.Color.Black;
            this.txtNamePerson.Location = new System.Drawing.Point(7, 0);
            this.txtNamePerson.Multiline = true;
            this.txtNamePerson.Name = "txtNamePerson";
            this.txtNamePerson.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNamePerson.ParentStyleUsing.UseBackColor = false;
            this.txtNamePerson.ParentStyleUsing.UseBorderColor = false;
            this.txtNamePerson.ParentStyleUsing.UseBorders = false;
            this.txtNamePerson.ParentStyleUsing.UseBorderWidth = false;
            this.txtNamePerson.ParentStyleUsing.UseFont = false;
            this.txtNamePerson.ParentStyleUsing.UseForeColor = false;
            this.txtNamePerson.Size = new System.Drawing.Size(208, 19);
            this.txtNamePerson.Text = "NamePerson";
            // 
            // txtBemerkungRTF
            // 
            this.txtBemerkungRTF.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.txtBemerkungRTF.ForeColor = System.Drawing.Color.Black;
            this.txtBemerkungRTF.Location = new System.Drawing.Point(7, 15);
            this.txtBemerkungRTF.Multiline = true;
            this.txtBemerkungRTF.Name = "txtBemerkungRTF";
            this.txtBemerkungRTF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBemerkungRTF.ParentStyleUsing.UseBackColor = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorderColor = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorders = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorderWidth = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseFont = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseForeColor = false;
            this.txtBemerkungRTF.Size = new System.Drawing.Size(680, 19);
            this.txtBemerkungRTF.Text = "BemerkungRTF";
            // 
            // hiderPanel
            // 
            this.hiderPanel.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.hiderTxtBemerkungRTF});
            this.hiderPanel.Location = new System.Drawing.Point(240, 0);
            this.hiderPanel.Name = "hiderPanel";
            this.hiderPanel.Size = new System.Drawing.Size(300, 73);
            this.hiderPanel.Visible = false;
            // 
            // hiderTxtBemerkungRTF
            // 
            this.hiderTxtBemerkungRTF.Location = new System.Drawing.Point(53, 13);
            this.hiderTxtBemerkungRTF.Name = "hiderTxtBemerkungRTF";
            this.hiderTxtBemerkungRTF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hiderTxtBemerkungRTF.Scripts.OnAfterPrint = "private void OnAfterPrint(object sender, System.EventArgs e) {\r\n   txtBemerkungRT" +
                "F.Visible = hiderTxtBemerkungRTF.Text != String.Empty;\r\n}";
            this.hiderTxtBemerkungRTF.Size = new System.Drawing.Size(100, 27);
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(0, 0);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(366, 19);
            this.Label5.Text = "Vermögen und Vermögensverbrauch";
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.Location = new System.Drawing.Point(7, 47);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(686, 3);
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Arial", 10F);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(613, 27);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(78, 19);
            this.Label3.Text = "Verbrauch";
            this.Label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 10F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(216, 27);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(313, 19);
            this.Label2.Text = "Art des Vermögens";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 10F);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(7, 27);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(208, 19);
            this.Label1.Text = "Betrifft";
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Arial", 10F);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(533, 27);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(78, 19);
            this.Label7.Text = "Vermögen";
            // 
            // Line7
            // 
            this.Line7.ForeColor = System.Drawing.Color.Black;
            this.Line7.Location = new System.Drawing.Point(7, 69);
            this.Line7.Name = "Line7";
            this.Line7.ParentStyleUsing.UseBackColor = false;
            this.Line7.ParentStyleUsing.UseBorderColor = false;
            this.Line7.ParentStyleUsing.UseBorders = false;
            this.Line7.ParentStyleUsing.UseBorderWidth = false;
            this.Line7.ParentStyleUsing.UseFont = false;
            this.Line7.ParentStyleUsing.UseForeColor = false;
            this.Line7.Size = new System.Drawing.Size(686, 3);
            // 
            // Line6
            // 
            this.Line6.ForeColor = System.Drawing.Color.Black;
            this.Line6.Location = new System.Drawing.Point(7, 43);
            this.Line6.Name = "Line6";
            this.Line6.ParentStyleUsing.UseBackColor = false;
            this.Line6.ParentStyleUsing.UseBorderColor = false;
            this.Line6.ParentStyleUsing.UseBorders = false;
            this.Line6.ParentStyleUsing.UseBorderWidth = false;
            this.Line6.ParentStyleUsing.UseFont = false;
            this.Line6.ParentStyleUsing.UseForeColor = false;
            this.Line6.Size = new System.Drawing.Size(686, 4);
            // 
            // txtSumVerbrauch
            // 
            this.txtSumVerbrauch.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Verbrauch", "")});
            this.txtSumVerbrauch.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.txtSumVerbrauch.ForeColor = System.Drawing.Color.Black;
            this.txtSumVerbrauch.Location = new System.Drawing.Point(612, 49);
            this.txtSumVerbrauch.Multiline = true;
            this.txtSumVerbrauch.Name = "txtSumVerbrauch";
            this.txtSumVerbrauch.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtSumVerbrauch.ParentStyleUsing.UseBackColor = false;
            this.txtSumVerbrauch.ParentStyleUsing.UseBorderColor = false;
            this.txtSumVerbrauch.ParentStyleUsing.UseBorders = false;
            this.txtSumVerbrauch.ParentStyleUsing.UseBorderWidth = false;
            this.txtSumVerbrauch.ParentStyleUsing.UseFont = false;
            this.txtSumVerbrauch.ParentStyleUsing.UseForeColor = false;
            this.txtSumVerbrauch.Size = new System.Drawing.Size(78, 19);
            xrSummary3.FormatString = "{0:n2}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.txtSumVerbrauch.Summary = xrSummary3;
            this.txtSumVerbrauch.Text = "txtSumVerbrauch";
            this.txtSumVerbrauch.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtFreibetrag
            // 
            this.txtFreibetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Freibetrag", "{0:n2}")});
            this.txtFreibetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtFreibetrag.ForeColor = System.Drawing.Color.Black;
            this.txtFreibetrag.Location = new System.Drawing.Point(533, 23);
            this.txtFreibetrag.Multiline = true;
            this.txtFreibetrag.Name = "txtFreibetrag";
            this.txtFreibetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtFreibetrag.ParentStyleUsing.UseBackColor = false;
            this.txtFreibetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtFreibetrag.ParentStyleUsing.UseBorders = false;
            this.txtFreibetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtFreibetrag.ParentStyleUsing.UseFont = false;
            this.txtFreibetrag.ParentStyleUsing.UseForeColor = false;
            this.txtFreibetrag.Size = new System.Drawing.Size(78, 20);
            xrSummary4.FormatString = "{0:#,##0.00}";
            this.txtFreibetrag.Summary = xrSummary4;
            this.txtFreibetrag.Text = "Freibetrag";
            this.txtFreibetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label9
            // 
            this.Label9.Font = new System.Drawing.Font("Arial", 10F);
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(307, 23);
            this.Label9.Name = "Label9";
            this.Label9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label9.ParentStyleUsing.UseBackColor = false;
            this.Label9.ParentStyleUsing.UseBorderColor = false;
            this.Label9.ParentStyleUsing.UseBorders = false;
            this.Label9.ParentStyleUsing.UseBorderWidth = false;
            this.Label9.ParentStyleUsing.UseFont = false;
            this.Label9.ParentStyleUsing.UseForeColor = false;
            this.Label9.Size = new System.Drawing.Size(220, 19);
            this.Label9.Text = "abzüglich Freibetrag";
            this.Label9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label8
            // 
            this.Label8.Font = new System.Drawing.Font("Arial", 10F);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(307, 3);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(220, 19);
            this.Label8.Text = "Gesamtes Vermögen";
            this.Label8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line5
            // 
            this.Line5.ForeColor = System.Drawing.Color.Black;
            this.Line5.Location = new System.Drawing.Point(7, 0);
            this.Line5.Name = "Line5";
            this.Line5.ParentStyleUsing.UseBackColor = false;
            this.Line5.ParentStyleUsing.UseBorderColor = false;
            this.Line5.ParentStyleUsing.UseBorders = false;
            this.Line5.ParentStyleUsing.UseBorderWidth = false;
            this.Line5.ParentStyleUsing.UseFont = false;
            this.Line5.ParentStyleUsing.UseForeColor = false;
            this.Line5.Size = new System.Drawing.Size(686, 4);
            // 
            // totBetragMINUSFreibetrag
            // 
            this.totBetragMINUSFreibetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TotBetragMinusFreibetrag", "")});
            this.totBetragMINUSFreibetrag.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.totBetragMINUSFreibetrag.ForeColor = System.Drawing.Color.Black;
            this.totBetragMINUSFreibetrag.Location = new System.Drawing.Point(533, 49);
            this.totBetragMINUSFreibetrag.Multiline = true;
            this.totBetragMINUSFreibetrag.Name = "totBetragMINUSFreibetrag";
            this.totBetragMINUSFreibetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totBetragMINUSFreibetrag.ParentStyleUsing.UseBackColor = false;
            this.totBetragMINUSFreibetrag.ParentStyleUsing.UseBorderColor = false;
            this.totBetragMINUSFreibetrag.ParentStyleUsing.UseBorders = false;
            this.totBetragMINUSFreibetrag.ParentStyleUsing.UseBorderWidth = false;
            this.totBetragMINUSFreibetrag.ParentStyleUsing.UseFont = false;
            this.totBetragMINUSFreibetrag.ParentStyleUsing.UseForeColor = false;
            this.totBetragMINUSFreibetrag.Size = new System.Drawing.Size(78, 19);
            xrSummary5.FormatString = "{0:n2}";
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.totBetragMINUSFreibetrag.Summary = xrSummary5;
            this.totBetragMINUSFreibetrag.Text = "totBetragMINUSFreibetrag";
            this.totBetragMINUSFreibetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // totBetrag
            // 
            this.totBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.totBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.totBetrag.ForeColor = System.Drawing.Color.Black;
            this.totBetrag.Location = new System.Drawing.Point(533, 3);
            this.totBetrag.Multiline = true;
            this.totBetrag.Name = "totBetrag";
            this.totBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totBetrag.ParentStyleUsing.UseBackColor = false;
            this.totBetrag.ParentStyleUsing.UseBorderColor = false;
            this.totBetrag.ParentStyleUsing.UseBorders = false;
            this.totBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.totBetrag.ParentStyleUsing.UseFont = false;
            this.totBetrag.ParentStyleUsing.UseForeColor = false;
            this.totBetrag.Size = new System.Drawing.Size(78, 19);
            xrSummary6.FormatString = "{0:#,##0.00}";
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.totBetrag.Summary = xrSummary6;
            this.totBetrag.Text = "totBetrag";
            this.totBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox1
            // 
            this.TextBox1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.TextBox1.ForeColor = System.Drawing.Color.Black;
            this.TextBox1.Location = new System.Drawing.Point(7, 49);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox1.ParentStyleUsing.UseBackColor = false;
            this.TextBox1.ParentStyleUsing.UseBorderColor = false;
            this.TextBox1.ParentStyleUsing.UseBorders = false;
            this.TextBox1.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox1.ParentStyleUsing.UseFont = false;
            this.TextBox1.ParentStyleUsing.UseForeColor = false;
            this.TextBox1.Size = new System.Drawing.Size(520, 19);
            this.TextBox1.Text = "Angerechnetes Vermögen und Vermögensverbrauch";
            this.TextBox1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
                        this.GroupFooter1,
                        this.PageFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(39, 92, 39, 39);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'DECLARE @BgBudgetID int

SELECT @BgBudgetID = BgBudgetID
FROM BgBudget
WHERE BgFinanzplanID = {BgFinanzplanID} AND MasterBudget = 1

DECLARE @RefDate     datetime,
        @Freibetrag  money

SELECT @RefDate = dbo.fnDateSerial(Jahr, Monat, 1)
FROM BgBudget
WHERE BgBudgetID = @BgBudgetID

SELECT @Freibetrag = SUM(CASE WHEN dbo.fnGetAge(PRS.Geburtsdatum, @RefDate) >= 18
                           THEN CONVERT(money, dbo.fnXConfig(''System\Sozialhilfe\SKOS\E2\Erwachsene'' , @RefDate))
                           ELSE CONVERT(money, dbo.fnXConfig(''System\Sozialhilfe\SKOS\E2\Minderjährige'' , @RefDate))
                         END)
FROM BgBudget                       BBG
  INNER JOIN BgFinanzplan_BaPerson  SPP ON SPP.BgFinanzplanID = BBG.BgFinanzplanID
  INNER JOIN BaPerson               PRS ON PRS.BaPersonID = SPP.BaPersonID
WHERE BBG.BgBudgetID = @BgBudgetID AND SPP.IstUnterstuetzt = 1

IF (@Freibetrag > CONVERT(money, dbo.fnXConfig(''System\Sozialhilfe\SKOS\E2\Maximal'' , @RefDate)))
  SET @Freibetrag = CONVERT(money, dbo.fnXConfig(''System\Sozialhilfe\SKOS\E2\Maximal'' , @RefDate))

SELECT BPO.*,
  NamePerson     = PRS.Name + IsNull('', '' + PRS.Vorname, ''''),
  VermoegensTyp  = SPT.Name,
  Verbrauch      = PVV.Betrag,
  Freibetrag     = @Freibetrag,
  TotBetragMinusFreibetrag = BPO.Betrag-@Freibetrag
FROM BgPosition              BPO
  INNER JOIN WhPositionsart  SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
  LEFT  JOIN BaPerson        PRS ON PRS.BaPersonID = BPO.BaPersonID
  LEFT  JOIN BgPosition      PVV ON PVV.BgPositionID_Parent = BPO.BgPositionID
WHERE BPO.BgBudgetID = @BgBudgetID AND SPT.BgGruppeCode = 3104 AND SPT.BgKategorieCode = 5
  AND BPO.DatumVon IS NULL' ,  null ,  N'ShDetaillierterFinanzplan' ,  null );


