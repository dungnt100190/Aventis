-- Insert Script for VmFibuAblageJournal
-- MD5:0XA6180CA06AAAE5D4F72A5B52E2F564D8_0XCED653166A39F133B3720489907C21F9_0X50C56AFA241DCBD92B6770EBBFD5775C
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'VmFibuAblageJournal') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('VmFibuAblageJournal', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'VmFibuAblageJournal';
UPDATE QRY
SET QueryName =  N'VmFibuAblageJournal' , UserText =  N'VM - Fibu Ablage-Journal' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtText;
        private DevExpress.XtraReports.UI.XRLabel txtHabenKtoNr;
        private DevExpress.XtraReports.UI.XRLabel txtSollKtoNr;
        private DevExpress.XtraReports.UI.XRLabel txtBelegNr;
        private DevExpress.XtraReports.UI.XRLabel txtBuchungsDatum;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel Geburtsdatum1;
        private DevExpress.XtraReports.UI.XRLabel TextBox13;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.XRLabel txtDateRange;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel txtGeburtsdatum;
        private DevExpress.XtraReports.UI.XRLabel TextBox12;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLabel txtMandant;
        private DevExpress.XtraReports.UI.XRLabel TextBox7;
        private DevExpress.XtraReports.UI.XRLabel TextBox6;
        private DevExpress.XtraReports.UI.XRLabel TextBox5;
        private DevExpress.XtraReports.UI.XRLabel TextBox8;
        private DevExpress.XtraReports.UI.XRLabel TextBox3;
        private DevExpress.XtraReports.UI.XRLabel TextBox2;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLabel Label1;
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
                        "AAAAasTc2VsZWN0IA0KICAgIE9yZ19OYW1lICAgID0gSXNOdWxsKENPTlZFUlQodmFyY2hhcigxMDAwK" +
                        "SwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc2VcVm9ybXVuZHNjaGFmdFxPcmdhbmlzYXRpb24nL" +
                        "CBHZXRkYXRlKCkpKSwgJycpLA0KICAgIE9yZ19BZHJlc3NlID0gSXNOdWxsKENPTlZFUlQodmFyY2hhc" +
                        "igxMDAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc2VcVm9ybXVuZHNjaGFmdFxBZHJlc3NlJ" +
                        "ywgR2V0ZGF0ZSgpKSksICcnKSwNCiAgICBPcmdfUExaICAgICA9IElzTnVsbChDT05WRVJUKHZhcmNoY" +
                        "XIoMTAwMCksIGRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlXFZvcm11bmRzY2hhZnRcUExaJywgR" +
                        "2V0ZGF0ZSgpKSksICcnKSwNCiAgICBPcmdfT3J0ICAgICA9IElzTnVsbChDT05WRVJUKHZhcmNoYXIoM" +
                        "TAwMCksIGRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlXFZvcm11bmRzY2hhZnRcT3J0JywgR2V0Z" +
                        "GF0ZSgpKSksICcnKSwNCiAgICBPcmdfUExaT3J0ICA9IElzTnVsbChDT05WRVJUKHZhcmNoYXIoMTAwM" +
                        "CksIGRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlXFZvcm11bmRzY2hhZnRcUExaJywgR2V0ZGF0Z" +
                        "SgpKSkgKyAnICcsICcnKQ0KICAgICAgICAgICAgICAgICsgSXNOdWxsKENPTlZFUlQodmFyY2hhcigxM" +
                        "DAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc2VcVm9ybXVuZHNjaGFmdFxPcnQnLCBHZXRkY" +
                        "XRlKCkpKSwgJycpLA0KDQogICAgICAgQlVDLkJ1Y2h1bmdzRGF0dW0sDQogICAgICAgQlVDLkJlbGVnT" +
                        "nIsDQogICAgICAgQlVDLlNvbGxLdG9OciwNCiAgICAgICBCVUMuSGFiZW5LdG9OciwNCiAgICAgICBCV" +
                        "UMuVGV4dCwNCiAgICAgICBCVUMuQmV0cmFnLA0KICAgICAgIE1hbmRhbnQgPSBQUlMuTmFtZSArIGlzT" +
                        "nVsbCgnLCAnICsgUFJTLlZvcm5hbWUsJycpLA0KICAgICAgIFBSUy5HZWJ1cnRzZGF0dW0sDQogICAgI" +
                        "CAgY29udmVydCh2YXJjaGFyLGNvbnZlcnQoZGF0ZXRpbWUsbnVsbCksMTA0KSArICcgLSAnICsNCiAgI" +
                        "CAgICBjb252ZXJ0KHZhcmNoYXIsY29udmVydChkYXRldGltZSxudWxsKSwxMDQpIEFTIERhdHVtQmVyZ" +
                        "WljaCwNCiAgICAgICBUZWFtID0gKFNFTEVDVCBbTmFtZV0gRlJPTSBGYlRlYW0gV0hFUkUgRmJUZWFtS" +
                        "UQgPSBJU05VTEwobnVsbCwgLTEpKSwgLS1URUEuTmFtZSwNCiAgICAgICBKb3VybmFsYWJsYWdlb3J0I" +
                        "D0gKFNFTEVDVCBUZXh0IEZST00gWExPVkNvZGUgV0hFUkUgTE9WTmFtZSA9ICdGYkpvdXJuYWxhYmxhZ" +
                        "2VvcnQnIEFORCBDb2RlID0gSVNOVUxMKG51bGwsIC0xKSksDQogICAgICAgU29ydE9yZGVyID0gQ0FTR" +
                        "Q0KICAgICAgICAgICAgICAgICAgICAgIFdIRU4gUFJTLk5hbWUgTElLRSAnc3QlJyBUSEVOICdzMicgK" +
                        "yBQUlMuTmFtZSArIGlzTnVsbCgnLCAnICsgUFJTLlZvcm5hbWUsJycpDQogICAgICAgICAgICAgICAgI" +
                        "CAgICAgV0hFTiBQUlMuTmFtZSBMSUtFICdzY2glJyBUSEVOICdzMScgKyBQUlMuTmFtZSArIGlzTnVsb" +
                        "CgnLCAnICsgUFJTLlZvcm5hbWUsJycpDQogICAgICAgICAgICAgICAgICAgICAgV0hFTiBQUlMuTmFtZ" +
                        "SBMSUtFICdzJScgVEhFTiAnczAnICsgUFJTLk5hbWUgKyBpc051bGwoJywgJyArIFBSUy5Wb3JuYW1lL" +
                        "CcnKQ0KICAgICAgICAgICAgICAgICAgICAgIEVMU0UgUFJTLk5hbWUgKyBpc051bGwoJywgJyArIFBSU" +
                        "y5Wb3JuYW1lLCcnKQ0KICAgICAgICAgICAgICAgICAgICBFTkQgKyBDT05WRVJUKFZBUkNIQVIoNTApL" +
                        "CBQUlMuQmFQZXJzb25JRCkNCmZyb20gICBGQkJ1Y2h1bmcgQlVDDQogICAgICAgaW5uZXIgam9pbiBGY" +
                        "lBlcmlvZGUgUEVSIG9uIFBFUi5GYlBlcmlvZGVJRCA9IEJVQy5GYlBlcmlvZGVJRA0KICAgICAgIGlub" +
                        "mVyIGpvaW4gQmFQZXJzb24gUFJTIG9uIFBSUy5CYVBlcnNvbklEID0gUEVSLkJhUGVyc29uSUQNCiAgI" +
                        "CAgICBsZWZ0ICBqb2luIEZiVGVhbSAgICBURUEgb24gVEVBLkZiVGVhbUlEID0gUEVSLkZiVGVhbUlED" +
                        "QogICAgICAgTEVGVCAgSk9JTiBYTE9WQ29kZSBMT1YgT04gTE9WLkxPVk5hbWUgPSAnRmJKb3VybmFsY" +
                        "WJsYWdlb3J0JyBBTkQgTE9WLkNvZGUgPSBQRVIuSm91cm5hbGFibGFnZW9ydENvZGUNCndoZXJlICBCd" +
                        "WNodW5nc0RhdHVtIGJldHdlZW4gbnVsbCBhbmQgbnVsbCBhbmQNCiAgICAgICAoKChQRVIuRmJUZWFtS" +
                        "UQgPSBudWxsIE9SIFBFUi5Kb3VybmFsYWJsYWdlb3J0Q29kZSA9IG51bGwpIEFORCANCiAgICAgICAgI" +
                        "ChJU05VTEwobnVsbCwgLTEpID0gLTEgT1IgSVNOVUxMKG51bGwsIC0xKSA9IC0xKSkgT1IgDQogICAgI" +
                        "CAgIChQRVIuRmJUZWFtSUQgPSBudWxsIEFORCBQRVIuSm91cm5hbGFibGFnZW9ydENvZGUgPSBudWxsK" +
                        "SkgYW5kDQogICAgICAgKGlzTnVsbChudWxsLFNvbGxLdG9OcikgPSBTb2xsS3RvTnIgT1INCiAgICAgI" +
                        "CAgaXNOdWxsKG51bGwsSGFiZW5LdG9OcikgPSBIYWJlbkt0b05yKQ0Kb3JkZXIgYnkNCiAgICAgICBCd" +
                        "WNodW5nc0RhdHVtLCBCZWxlZ05y";
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
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtText = new DevExpress.XtraReports.UI.XRLabel();
            this.txtHabenKtoNr = new DevExpress.XtraReports.UI.XRLabel();
            this.txtSollKtoNr = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBelegNr = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBuchungsDatum = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Geburtsdatum1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox13 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtDateRange = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGeburtsdatum = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox12 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.txtMandant = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox7 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox6 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox5 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox8 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox3 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.Label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtBetrag,
                        this.txtText,
                        this.txtHabenKtoNr,
                        this.txtSollKtoNr,
                        this.txtBelegNr,
                        this.txtBuchungsDatum});
            this.Detail.Height = 23;
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
                        this.xrLabel4,
                        this.xrLabel3,
                        this.xrLabel2,
                        this.Geburtsdatum1,
                        this.TextBox13,
                        this.Label7,
                        this.txtDateRange,
                        this.Label4});
            this.PageHeader.Height = 187;
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
                        this.txtGeburtsdatum,
                        this.TextBox12,
                        this.Line3,
                        this.txtMandant,
                        this.TextBox7,
                        this.TextBox6,
                        this.TextBox5,
                        this.TextBox8,
                        this.TextBox3,
                        this.TextBox2});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("SortOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 84;
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
            this.GroupFooter1.Height = 25;
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
                        this.xrLabel1,
                        this.xrPageInfo2,
                        this.xrPageInfo1,
                        this.Label6,
                        this.Line2,
                        this.Label1});
            this.PageFooter.Height = 67;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 9F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(606, 0);
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
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtBetrag.Summary = xrSummary1;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtText
            // 
            this.txtText.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text", "")});
            this.txtText.Font = new System.Drawing.Font("Arial", 9F);
            this.txtText.ForeColor = System.Drawing.Color.Black;
            this.txtText.Location = new System.Drawing.Point(314, 0);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtText.ParentStyleUsing.UseBackColor = false;
            this.txtText.ParentStyleUsing.UseBorderColor = false;
            this.txtText.ParentStyleUsing.UseBorders = false;
            this.txtText.ParentStyleUsing.UseBorderWidth = false;
            this.txtText.ParentStyleUsing.UseFont = false;
            this.txtText.ParentStyleUsing.UseForeColor = false;
            this.txtText.Size = new System.Drawing.Size(291, 20);
            this.txtText.Text = "Text";
            // 
            // txtHabenKtoNr
            // 
            this.txtHabenKtoNr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "HabenKtoNr", "")});
            this.txtHabenKtoNr.Font = new System.Drawing.Font("Arial", 9F);
            this.txtHabenKtoNr.ForeColor = System.Drawing.Color.Black;
            this.txtHabenKtoNr.Location = new System.Drawing.Point(231, 0);
            this.txtHabenKtoNr.Multiline = true;
            this.txtHabenKtoNr.Name = "txtHabenKtoNr";
            this.txtHabenKtoNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtHabenKtoNr.ParentStyleUsing.UseBackColor = false;
            this.txtHabenKtoNr.ParentStyleUsing.UseBorderColor = false;
            this.txtHabenKtoNr.ParentStyleUsing.UseBorders = false;
            this.txtHabenKtoNr.ParentStyleUsing.UseBorderWidth = false;
            this.txtHabenKtoNr.ParentStyleUsing.UseFont = false;
            this.txtHabenKtoNr.ParentStyleUsing.UseForeColor = false;
            this.txtHabenKtoNr.Size = new System.Drawing.Size(56, 20);
            this.txtHabenKtoNr.Text = "HabenKtoNr";
            this.txtHabenKtoNr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtSollKtoNr
            // 
            this.txtSollKtoNr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SollKtoNr", "")});
            this.txtSollKtoNr.Font = new System.Drawing.Font("Arial", 9F);
            this.txtSollKtoNr.ForeColor = System.Drawing.Color.Black;
            this.txtSollKtoNr.Location = new System.Drawing.Point(135, 0);
            this.txtSollKtoNr.Multiline = true;
            this.txtSollKtoNr.Name = "txtSollKtoNr";
            this.txtSollKtoNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtSollKtoNr.ParentStyleUsing.UseBackColor = false;
            this.txtSollKtoNr.ParentStyleUsing.UseBorderColor = false;
            this.txtSollKtoNr.ParentStyleUsing.UseBorders = false;
            this.txtSollKtoNr.ParentStyleUsing.UseBorderWidth = false;
            this.txtSollKtoNr.ParentStyleUsing.UseFont = false;
            this.txtSollKtoNr.ParentStyleUsing.UseForeColor = false;
            this.txtSollKtoNr.Size = new System.Drawing.Size(78, 20);
            this.txtSollKtoNr.Text = "SollKtoNr";
            this.txtSollKtoNr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtBelegNr
            // 
            this.txtBelegNr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BelegNr", "")});
            this.txtBelegNr.Font = new System.Drawing.Font("Arial", 9F);
            this.txtBelegNr.ForeColor = System.Drawing.Color.Black;
            this.txtBelegNr.Location = new System.Drawing.Point(86, 0);
            this.txtBelegNr.Multiline = true;
            this.txtBelegNr.Name = "txtBelegNr";
            this.txtBelegNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBelegNr.ParentStyleUsing.UseBackColor = false;
            this.txtBelegNr.ParentStyleUsing.UseBorderColor = false;
            this.txtBelegNr.ParentStyleUsing.UseBorders = false;
            this.txtBelegNr.ParentStyleUsing.UseBorderWidth = false;
            this.txtBelegNr.ParentStyleUsing.UseFont = false;
            this.txtBelegNr.ParentStyleUsing.UseForeColor = false;
            this.txtBelegNr.Size = new System.Drawing.Size(78, 20);
            this.txtBelegNr.Text = "BelegNr";
            // 
            // txtBuchungsDatum
            // 
            this.txtBuchungsDatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BuchungsDatum", "{0:dd.MM.yyyy}")});
            this.txtBuchungsDatum.Font = new System.Drawing.Font("Arial", 9F);
            this.txtBuchungsDatum.ForeColor = System.Drawing.Color.Black;
            this.txtBuchungsDatum.Location = new System.Drawing.Point(0, 0);
            this.txtBuchungsDatum.Multiline = true;
            this.txtBuchungsDatum.Name = "txtBuchungsDatum";
            this.txtBuchungsDatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBuchungsDatum.ParentStyleUsing.UseBackColor = false;
            this.txtBuchungsDatum.ParentStyleUsing.UseBorderColor = false;
            this.txtBuchungsDatum.ParentStyleUsing.UseBorders = false;
            this.txtBuchungsDatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtBuchungsDatum.ParentStyleUsing.UseFont = false;
            this.txtBuchungsDatum.ParentStyleUsing.UseForeColor = false;
            this.txtBuchungsDatum.Size = new System.Drawing.Size(78, 20);
            xrSummary2.FormatString = "{0:dd/MM/yyyy}";
            this.txtBuchungsDatum.Summary = xrSummary2;
            this.txtBuchungsDatum.Text = "BuchungsDatum";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.Location = new System.Drawing.Point(408, 158);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.ParentStyleUsing.UseForeColor = false;
            this.xrLabel4.Size = new System.Drawing.Size(109, 18);
            this.xrLabel4.Text = "Journalablageort";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Journalablageort", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(525, 158);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(163, 20);
            xrSummary3.FormatString = "{0:dd/MM/yyyy}";
            this.xrLabel3.Summary = xrSummary3;
            this.xrLabel3.Text = "xrLabel3";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel2.Location = new System.Drawing.Point(0, 0);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(347, 107);
            this.xrLabel2.Text = "Stadt Bern\r\nDirektion für Sicherheit, Umwelt und Energie\r\n\r\nAmt für Erwachsenen- " +
                "und \r\nKindesschutz";
            // 
            // Geburtsdatum1
            // 
            this.Geburtsdatum1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Team", "")});
            this.Geburtsdatum1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Geburtsdatum1.ForeColor = System.Drawing.Color.Black;
            this.Geburtsdatum1.Location = new System.Drawing.Point(524, 140);
            this.Geburtsdatum1.Multiline = true;
            this.Geburtsdatum1.Name = "Geburtsdatum1";
            this.Geburtsdatum1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Geburtsdatum1.ParentStyleUsing.UseBackColor = false;
            this.Geburtsdatum1.ParentStyleUsing.UseBorderColor = false;
            this.Geburtsdatum1.ParentStyleUsing.UseBorders = false;
            this.Geburtsdatum1.ParentStyleUsing.UseBorderWidth = false;
            this.Geburtsdatum1.ParentStyleUsing.UseFont = false;
            this.Geburtsdatum1.ParentStyleUsing.UseForeColor = false;
            this.Geburtsdatum1.Size = new System.Drawing.Size(163, 20);
            xrSummary4.FormatString = "{0:dd/MM/yyyy}";
            this.Geburtsdatum1.Summary = xrSummary4;
            this.Geburtsdatum1.Text = "Team";
            // 
            // TextBox13
            // 
            this.TextBox13.Font = new System.Drawing.Font("Arial", 9F);
            this.TextBox13.ForeColor = System.Drawing.Color.Black;
            this.TextBox13.Location = new System.Drawing.Point(467, 140);
            this.TextBox13.Multiline = true;
            this.TextBox13.Name = "TextBox13";
            this.TextBox13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox13.ParentStyleUsing.UseBackColor = false;
            this.TextBox13.ParentStyleUsing.UseBorderColor = false;
            this.TextBox13.ParentStyleUsing.UseBorders = false;
            this.TextBox13.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox13.ParentStyleUsing.UseFont = false;
            this.TextBox13.ParentStyleUsing.UseForeColor = false;
            this.TextBox13.Size = new System.Drawing.Size(50, 18);
            this.TextBox13.Text = "Team";
            this.TextBox13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(0, 140);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(157, 23);
            this.Label7.Text = "Ablage-Journal";
            // 
            // txtDateRange
            // 
            this.txtDateRange.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "DatumBereich", "")});
            this.txtDateRange.Font = new System.Drawing.Font("Arial", 14F);
            this.txtDateRange.ForeColor = System.Drawing.Color.Black;
            this.txtDateRange.Location = new System.Drawing.Point(163, 140);
            this.txtDateRange.Multiline = true;
            this.txtDateRange.Name = "txtDateRange";
            this.txtDateRange.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtDateRange.ParentStyleUsing.UseBackColor = false;
            this.txtDateRange.ParentStyleUsing.UseBorderColor = false;
            this.txtDateRange.ParentStyleUsing.UseBorders = false;
            this.txtDateRange.ParentStyleUsing.UseBorderWidth = false;
            this.txtDateRange.ParentStyleUsing.UseFont = false;
            this.txtDateRange.ParentStyleUsing.UseForeColor = false;
            this.txtDateRange.Size = new System.Drawing.Size(291, 20);
            this.txtDateRange.Text = "DatumBereich";
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial", 10F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(554, 100);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(141, 23);
            this.Label4.Text = "Buchhaltung";
            this.Label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtGeburtsdatum
            // 
            this.txtGeburtsdatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Geburtsdatum", "{0:dd.MM.yyyy}")});
            this.txtGeburtsdatum.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.txtGeburtsdatum.ForeColor = System.Drawing.Color.Black;
            this.txtGeburtsdatum.Location = new System.Drawing.Point(622, 11);
            this.txtGeburtsdatum.Multiline = true;
            this.txtGeburtsdatum.Name = "txtGeburtsdatum";
            this.txtGeburtsdatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGeburtsdatum.ParentStyleUsing.UseBackColor = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorderColor = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorders = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseFont = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseForeColor = false;
            this.txtGeburtsdatum.Size = new System.Drawing.Size(70, 20);
            xrSummary5.FormatString = "{0:dd/MM/yyyy}";
            this.txtGeburtsdatum.Summary = xrSummary5;
            this.txtGeburtsdatum.Text = "01.01.2000";
            this.txtGeburtsdatum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox12
            // 
            this.TextBox12.Font = new System.Drawing.Font("Arial", 9F);
            this.TextBox12.ForeColor = System.Drawing.Color.Black;
            this.TextBox12.Location = new System.Drawing.Point(591, 11);
            this.TextBox12.Multiline = true;
            this.TextBox12.Name = "TextBox12";
            this.TextBox12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox12.ParentStyleUsing.UseBackColor = false;
            this.TextBox12.ParentStyleUsing.UseBorderColor = false;
            this.TextBox12.ParentStyleUsing.UseBorders = false;
            this.TextBox12.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox12.ParentStyleUsing.UseFont = false;
            this.TextBox12.ParentStyleUsing.UseForeColor = false;
            this.TextBox12.Size = new System.Drawing.Size(31, 18);
            this.TextBox12.Text = "geb.";
            // 
            // Line3
            // 
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.Location = new System.Drawing.Point(0, 61);
            this.Line3.Name = "Line3";
            this.Line3.ParentStyleUsing.UseBackColor = false;
            this.Line3.ParentStyleUsing.UseBorderColor = false;
            this.Line3.ParentStyleUsing.UseBorders = false;
            this.Line3.ParentStyleUsing.UseBorderWidth = false;
            this.Line3.ParentStyleUsing.UseFont = false;
            this.Line3.ParentStyleUsing.UseForeColor = false;
            this.Line3.Size = new System.Drawing.Size(692, 2);
            // 
            // txtMandant
            // 
            this.txtMandant.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Mandant", "")});
            this.txtMandant.Font = new System.Drawing.Font("Arial", 14.25F);
            this.txtMandant.ForeColor = System.Drawing.Color.Black;
            this.txtMandant.Location = new System.Drawing.Point(0, 7);
            this.txtMandant.Multiline = true;
            this.txtMandant.Name = "txtMandant";
            this.txtMandant.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtMandant.ParentStyleUsing.UseBackColor = false;
            this.txtMandant.ParentStyleUsing.UseBorderColor = false;
            this.txtMandant.ParentStyleUsing.UseBorders = false;
            this.txtMandant.ParentStyleUsing.UseBorderWidth = false;
            this.txtMandant.ParentStyleUsing.UseFont = false;
            this.txtMandant.ParentStyleUsing.UseForeColor = false;
            this.txtMandant.Size = new System.Drawing.Size(519, 23);
            this.txtMandant.Text = "Mandant";
            // 
            // TextBox7
            // 
            this.TextBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox7.ForeColor = System.Drawing.Color.Black;
            this.TextBox7.Location = new System.Drawing.Point(590, 39);
            this.TextBox7.Multiline = true;
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox7.ParentStyleUsing.UseBackColor = false;
            this.TextBox7.ParentStyleUsing.UseBorderColor = false;
            this.TextBox7.ParentStyleUsing.UseBorders = false;
            this.TextBox7.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox7.ParentStyleUsing.UseFont = false;
            this.TextBox7.ParentStyleUsing.UseForeColor = false;
            this.TextBox7.Size = new System.Drawing.Size(102, 20);
            this.TextBox7.Text = "Betrag";
            this.TextBox7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox6
            // 
            this.TextBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox6.ForeColor = System.Drawing.Color.Black;
            this.TextBox6.Location = new System.Drawing.Point(231, 39);
            this.TextBox6.Multiline = true;
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox6.ParentStyleUsing.UseBackColor = false;
            this.TextBox6.ParentStyleUsing.UseBorderColor = false;
            this.TextBox6.ParentStyleUsing.UseBorders = false;
            this.TextBox6.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox6.ParentStyleUsing.UseFont = false;
            this.TextBox6.ParentStyleUsing.UseForeColor = false;
            this.TextBox6.Size = new System.Drawing.Size(56, 20);
            this.TextBox6.Text = "Haben";
            this.TextBox6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox5
            // 
            this.TextBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox5.ForeColor = System.Drawing.Color.Black;
            this.TextBox5.Location = new System.Drawing.Point(135, 39);
            this.TextBox5.Multiline = true;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox5.ParentStyleUsing.UseBackColor = false;
            this.TextBox5.ParentStyleUsing.UseBorderColor = false;
            this.TextBox5.ParentStyleUsing.UseBorders = false;
            this.TextBox5.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox5.ParentStyleUsing.UseFont = false;
            this.TextBox5.ParentStyleUsing.UseForeColor = false;
            this.TextBox5.Size = new System.Drawing.Size(78, 20);
            this.TextBox5.Text = "Soll";
            this.TextBox5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox8
            // 
            this.TextBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox8.ForeColor = System.Drawing.Color.Black;
            this.TextBox8.Location = new System.Drawing.Point(314, 39);
            this.TextBox8.Multiline = true;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox8.ParentStyleUsing.UseBackColor = false;
            this.TextBox8.ParentStyleUsing.UseBorderColor = false;
            this.TextBox8.ParentStyleUsing.UseBorders = false;
            this.TextBox8.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox8.ParentStyleUsing.UseFont = false;
            this.TextBox8.ParentStyleUsing.UseForeColor = false;
            this.TextBox8.Size = new System.Drawing.Size(275, 20);
            this.TextBox8.Text = "Text";
            // 
            // TextBox3
            // 
            this.TextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox3.ForeColor = System.Drawing.Color.Black;
            this.TextBox3.Location = new System.Drawing.Point(86, 40);
            this.TextBox3.Multiline = true;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox3.ParentStyleUsing.UseBackColor = false;
            this.TextBox3.ParentStyleUsing.UseBorderColor = false;
            this.TextBox3.ParentStyleUsing.UseBorders = false;
            this.TextBox3.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox3.ParentStyleUsing.UseFont = false;
            this.TextBox3.ParentStyleUsing.UseForeColor = false;
            this.TextBox3.Size = new System.Drawing.Size(78, 20);
            this.TextBox3.Text = "Beleg";
            // 
            // TextBox2
            // 
            this.TextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox2.ForeColor = System.Drawing.Color.Black;
            this.TextBox2.Location = new System.Drawing.Point(0, 40);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox2.ParentStyleUsing.UseBackColor = false;
            this.TextBox2.ParentStyleUsing.UseBorderColor = false;
            this.TextBox2.ParentStyleUsing.UseBorders = false;
            this.TextBox2.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox2.ParentStyleUsing.UseFont = false;
            this.TextBox2.ParentStyleUsing.UseForeColor = false;
            this.TextBox2.Size = new System.Drawing.Size(78, 20);
            this.TextBox2.Text = "Datum";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel1.Location = new System.Drawing.Point(0, 13);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(100, 27);
            this.xrLabel1.Text = "Druckdatum";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 9F);
            this.xrPageInfo2.Format = "{0:dd.MM.yyyy}";
            this.xrPageInfo2.Location = new System.Drawing.Point(73, 13);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            this.xrPageInfo2.Size = new System.Drawing.Size(100, 27);
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 9F);
            this.xrPageInfo1.Location = new System.Drawing.Point(326, 12);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(100, 27);
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 9F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(645, 12);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(47, 23);
            this.Label6.Text = "KISS 3";
            this.Label6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.Location = new System.Drawing.Point(0, 7);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(692, 2);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 9F);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(287, 12);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(37, 18);
            this.Label1.Text = "Seite";
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
            this.Margins = new System.Drawing.Printing.Margins(60, 60, 60, 39);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' , ParameterXML =  N'<NewDataSet>
    <Table>
        <FieldName>-</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Team</DisplayText>
        <TabPosition>1</TabPosition>
        <X>10</X>
        <Y>40</Y>
        <Width>80</Width>
        <Height>25</Height>
        <Mandatory>false</Mandatory>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>-</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Journalablageort</DisplayText>
        <TabPosition>1</TabPosition>
        <X>10</X>
        <Y>70</Y>
        <Width>80</Width>
        <Height>25</Height>
        <Mandatory>false</Mandatory>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>-</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Datum von</DisplayText>
        <TabPosition>2</TabPosition>
        <X>10</X>
        <Y>100</Y>
        <Width>80</Width>
        <Height>25</Height>
        <Mandatory>false</Mandatory>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>-</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Datum bis</DisplayText>
        <TabPosition>3</TabPosition>
        <X>10</X>
        <Y>130</Y>
        <Width>80</Width>
        <Height>25</Height>
        <Mandatory>false</Mandatory>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>-</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Konto-Nr</DisplayText>
        <TabPosition>4</TabPosition>
        <X>10</X>
        <Y>160</Y>
        <Width>80</Width>
        <Height>25</Height>
        <Mandatory>false</Mandatory>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>FbTeamID</FieldName>
        <FieldCode>8</FieldCode>
        <DisplayText>Team</DisplayText>
        <TabPosition>21</TabPosition>
        <X>100</X>
        <Y>40</Y>
        <Width>250</Width>
        <Height>25</Height>
        <Mandatory>false</Mandatory>
        <AppCode>
        </AppCode>
        <SQL>select Code = FbTeamID, Text = Name from FbTeam order by FbTeamID</SQL>
    </Table>
    <Table>
        <FieldName>JournalablageortCode</FieldName>
        <FieldCode>8</FieldCode>
        <DisplayText>Journalablageort</DisplayText>
        <TabPosition>21</TabPosition>
        <X>100</X>
        <Y>70</Y>
        <Width>250</Width>
        <Height>25</Height>
        <Mandatory>false</Mandatory>
        <AppCode></AppCode>
        <LOVName>FbJournalablageort</LOVName>
    </Table>
    <Table>
        <FieldName>DatumVon</FieldName>
        <FieldCode>5</FieldCode>
        <DisplayText>Datum von</DisplayText>
        <TabPosition>22</TabPosition>
        <X>100</X>
        <Y>100</Y>
        <Width>80</Width>
        <Height>25</Height>
        <Mandatory>true</Mandatory>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>DatumBis</FieldName>
        <FieldCode>5</FieldCode>
        <DisplayText>Datum bis</DisplayText>
        <TabPosition>23</TabPosition>
        <X>100</X>
        <Y>130</Y>
        <Width>80</Width>
        <Height>25</Height>
        <Mandatory>true</Mandatory>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>KontoNr</FieldName>
        <FieldCode>4</FieldCode>
        <DisplayText>Konto-Nr</DisplayText>
        <TabPosition>24</TabPosition>
        <X>100</X>
        <Y>160</Y>
        <Width>80</Width>
        <Height>25</Height>
        <Mandatory>false</Mandatory>
        <AppCode>
        </AppCode>
    </Table>
</NewDataSet>' , SQLquery =  N'select 
    Org_Name    = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Vormundschaft\Organisation'', Getdate())), ''''),
    Org_Adresse = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Vormundschaft\Adresse'', Getdate())), ''''),
    Org_PLZ     = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Vormundschaft\PLZ'', Getdate())), ''''),
    Org_Ort     = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Vormundschaft\Ort'', Getdate())), ''''),
    Org_PLZOrt  = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Vormundschaft\PLZ'', Getdate())) + '' '', '''')
                + IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Vormundschaft\Ort'', Getdate())), ''''),

       BUC.BuchungsDatum,
       BUC.BelegNr,
       BUC.SollKtoNr,
       BUC.HabenKtoNr,
       BUC.Text,
       BUC.Betrag,
       Mandant = PRS.Name + isNull('', '' + PRS.Vorname,''''),
       PRS.Geburtsdatum,
       convert(varchar,convert(datetime,{DatumVon}),104) + '' - '' +
       convert(varchar,convert(datetime,{DatumBis}),104) AS DatumBereich,
       Team = (SELECT [Name] FROM FbTeam WHERE FbTeamID = ISNULL({FbTeamID}, -1)), --TEA.Name,
       Journalablageort = (SELECT Text FROM XLOVCode WHERE LOVName = ''FbJournalablageort'' AND Code = ISNULL({JournalablageortCode}, -1)),
       SortOrder = CASE
                      WHEN PRS.Name LIKE ''st%'' THEN ''s2'' + PRS.Name + isNull('', '' + PRS.Vorname,'''')
                      WHEN PRS.Name LIKE ''sch%'' THEN ''s1'' + PRS.Name + isNull('', '' + PRS.Vorname,'''')
                      WHEN PRS.Name LIKE ''s%'' THEN ''s0'' + PRS.Name + isNull('', '' + PRS.Vorname,'''')
                      ELSE PRS.Name + isNull('', '' + PRS.Vorname,'''')
                    END + CONVERT(VARCHAR(50), PRS.BaPersonID)
from   FBBuchung BUC
       inner join FbPeriode PER on PER.FbPeriodeID = BUC.FbPeriodeID
       inner join BaPerson PRS on PRS.BaPersonID = PER.BaPersonID
       left  join FbTeam    TEA on TEA.FbTeamID = PER.FbTeamID
       LEFT  JOIN XLOVCode LOV ON LOV.LOVName = ''FbJournalablageort'' AND LOV.Code = PER.JournalablageortCode
where  ( ({DatumVon} <= BUC.BuchungsDatum) AND (BUC.BuchungsDatum < DATEADD(d, 1, {DatumBis})) ) and
       (((PER.FbTeamID = {FbTeamID} OR PER.JournalablageortCode = {JournalablageortCode}) AND 
         (ISNULL({FbTeamID}, -1) = -1 OR ISNULL({JournalablageortCode}, -1) = -1)) OR 
        (PER.FbTeamID = {FbTeamID} AND PER.JournalablageortCode = {JournalablageortCode})) and
       (isNull({KontoNr},SollKtoNr) = SollKtoNr OR
        isNull({KontoNr},HabenKtoNr) = HabenKtoNr)
order by
       BUC.BuchungsDatum, BUC.BelegNr' , ContextForms =  N'VmFibu,CtlFibuJournal,CtlFibuKontoblatt,CtlFibuKontoblatt2,CtlFibuBilanzErfolg' , ParentReportName =  null , ReportSortKey = 1
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'VmFibuAblageJournal' ;


