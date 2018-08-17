-- Insert Script for ShPapierverfuegungBuchhaltung
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'ShPapierverfuegungBuchhaltung') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('ShPapierverfuegungBuchhaltung', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'ShPapierverfuegungBuchhaltung';
UPDATE QRY
SET QueryName =  N'ShPapierverfuegungBuchhaltung' , UserText =  N'SH - Papierverfügung an die Buchhaltung' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\KiSS\R4233\KiSS4.DB.dll" />
///     <Reference Path="C:\KiSS\R4233\log4net.dll" />
///     <Reference Path="C:\KiSS\R4233\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.Subreport ShPapierverfuegungBuchhaltung_Belege;
        private DevExpress.XtraReports.UI.Subreport ShPapierverfuegungBuchhaltung_Personen;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel txtEmployeeName;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtBezugsmonat;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel txtMbStatus;
        private DevExpress.XtraReports.UI.XRLabel txtDatumBis;
        private DevExpress.XtraReports.UI.XRLabel txtDatumVon;
        private DevExpress.XtraReports.UI.XRLabel txtFpTyp;
        private DevExpress.XtraReports.UI.XRLabel Label11;
        private DevExpress.XtraReports.UI.XRLabel Label10;
        private DevExpress.XtraReports.UI.XRLabel Label9;
        private DevExpress.XtraReports.UI.XRLabel Label8;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.XRLabel txtFpStatus;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.XRLabel txtKlientName;
        private DevExpress.XtraReports.UI.XRLabel Label5;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.XRLabel OrgPLZOrt;
        private DevExpress.XtraReports.UI.XRLabel OrgAdresse;
        private DevExpress.XtraReports.UI.XRLabel OrgName;
        private DevExpress.XtraReports.UI.XRLabel Label12;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLabel Label13;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRRichTextBox xrRichTextBox1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRPageInfo piOrgOrtDatum;
        private DevExpress.XtraReports.UI.XRLine Line4;
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
                        "jgxNDdiNWVhZTRQkzSRhhO0TqSVv7u6AAAAAEsAAACCAAAABwIAAEZwAGkATwByAGcATwByAHQARABhA" +
                        "HQAdQBtAC4AUwBjAHIAaQBwAHQAcwAuAE8AbgBCAGUAZgBvAHIAZQBQAHIAaQBuAHQAAAAAADJzAHEAb" +
                        "ABRAHUAZQByAHkAMQAuAFMAZQBsAGUAYwB0AFMAdABhAHQAZQBtAGUAbgB0ANIAAAAseAByAFIAaQBjA" +
                        "GgAVABlAHgAdABCAG8AeAAxAC4AUgB0AGYAVABlAHgAdAAuDQAAAc8BcHJpdmF0ZSB2b2lkIE9uQmVmb" +
                        "3JlUHJpbnQob2JqZWN0IHNlbmRlciwgU3lzdGVtLkRyYXdpbmcuUHJpbnRpbmcuUHJpbnRFdmVudEFyZ" +
                        "3MgZSkgew0KICBwaU9yZ09ydERhdHVtLkZvcm1hdCA9IHBpT3JnT3J0RGF0dW0uRm9ybWF0LlJlcGxhY" +
                        "2UoIjxPcmdPcnQ+IixSZXBvcnQuR2V0Q3VycmVudENvbHVtblZhbHVlKCJPcmdfT3J0IikuVG9TdHJpb" +
                        "mcoKSk7DQp9AdkYZGVjbGFyZSBAQmdCdWRnZXRJRCAgICAgICAgICAgIGludA0KZGVjbGFyZSBAUHJpb" +
                        "nRBbGwgICAgICAgICAgICAgIGJpdA0KZGVjbGFyZSBARGF0ZUdlbmVyaWVydCAgICAgICAgIGRhdGV0a" +
                        "W1lDQpkZWNsYXJlIEBPbmx5VW52ZXJidWNodGVCZWxlZ2UgYml0DQpkZWNsYXJlIEBzTW9udGggICAgI" +
                        "CAgICAgICAgICAgdmFyY2hhcigyMCkNCg0Kc2V0IEBCZ0J1ZGdldElEICAgICAgICAgICAgPSBudWxsD" +
                        "QpzZXQgQFByaW50QWxsICAgICAgICAgICAgICA9IG51bGwNCnNldCBARGF0ZUdlbmVyaWVydCAgICAgI" +
                        "CAgID0gbnVsbA0Kc2V0IEBPbmx5VW52ZXJidWNodGVCZWxlZ2UgPSBudWxsDQoNClNFTEVDVCBAc01vb" +
                        "nRoID0gZGJvLmZuWE1vbmF0KE1vbmF0KSArICcgJyArIFNUUihKYWhyLDQpDQpGUk9NIEJnQnVkZ2V0I" +
                        "FdIRVJFIEJnQnVkZ2V0SUQgPSBAQmdCdWRnZXRJRA0KDQoNClNFTEVDVA0KICBPcmdfTmFtZSAgICA9I" +
                        "ElzTnVsbChDT05WRVJUKHZhcmNoYXIoMTAwMCksIGRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlX" +
                        "FNvemlhbGhpbGZlXE9yZ2FuaXNhdGlvbicsIEdldERhdGUoKSkpLCAnJyksDQogIE9yZ19BZHJlc3NlI" +
                        "D0gSXNOdWxsKENPTlZFUlQodmFyY2hhcigxMDAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc" +
                        "2VcU296aWFsaGlsZmVcQWRyZXNzZScsIEdldERhdGUoKSkpLCAnJyksDQogIE9yZ19QTFogICAgID0gS" +
                        "XNOdWxsKENPTlZFUlQodmFyY2hhcigxMDAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc2VcU" +
                        "296aWFsaGlsZmVcUExaJywgR2V0RGF0ZSgpKSksICcnKSwNCiAgT3JnX09ydCAgICAgPSBJc051bGwoQ" +
                        "09OVkVSVCh2YXJjaGFyKDEwMDApLCBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoa" +
                        "WxmZVxPcnQnLCBHZXREYXRlKCkpKSwgJycpLA0KICBPcmdfUExaT3J0ICA9IElzTnVsbChDT05WRVJUK" +
                        "HZhcmNoYXIoMTAwMCksIGRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlXFBMW" +
                        "icsIEdldERhdGUoKSkpICsgJyAnLCAnJykNCiAgICAgICAgICAgICAgKyBJc051bGwoQ09OVkVSVCh2Y" +
                        "XJjaGFyKDEwMDApLCBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxPcnQnL" +
                        "CBHZXREYXRlKCkpKSwgJycpLA0KDQogIE9yZ1VuaXRBZHJlc3NlID0gT3JnLlRleHQxLA0KICBQUlMuT" +
                        "mFtZSArICcsICcgKyBQUlMuVm9ybmFtZSArIElzTnVsbCgnICcgKyBQUlMuVm9ybmFtZTIsICcnKSBBU" +
                        "yBLbGllbnROYW1lLA0KICBMVlMuVGV4dCBBUyBGcFN0YXR1cywNCiAgTFZULlRleHQgQVMgRnBUeXAsD" +
                        "QogIExWVC5WYWx1ZTIgQVMgSXNVcmdlbnQsIC0tIDIuMCBEQjogSXNVcmdlbnQNCiAgU0ZQLkdlcGxhb" +
                        "nRWb24sDQogIFNGUC5HZXBsYW50QmlzLA0KICBTRlAuRGF0dW1Wb24sDQogIFNGUC5EYXR1bUJpcywNC" +
                        "iAgU0ZQLkJlbWVya3VuZyBBUyBTaEZwQmVtZXJrdW5nLA0KICBCQkcuSmFociwNCiAgQkJHLk1vbmF0L" +
                        "A0KICBAc01vbnRoIEFTIEJlenVnc21vbmF0LA0KICBMVkIuVGV4dCBBUyBNYlN0YXR1cywNCiAgVVNSL" +
                        "kxhc3ROYW1lK0lTTlVMTCgnLCAnK1VTUi5GaXJzdE5hbWUsJycpK0lTTlVMTCgnICgnK09yZy5JdGVtT" +
                        "mFtZSsnKScsJycpK0lTTlVMTCgnLCBUZWwuICcrVVNSLlBob25lLCcnKSBBUyBFbXBsb3llZU5hbWUsD" +
                        "QogIC0tIE11c3QgcHJvdmlkZSBwYXJhbWV0ZXJzIGFzIHZhcmlhYmxlcyB0byBwYXJlbnQgaW4gc3BlY" +
                        "2lhbCBmb3JtIHNvIHRoYXQgc3VicmVwb3J0cyBjYW4gcmVhZCB0aGVtDQogIEBCZ0J1ZGdldElEIEFTI" +
                        "EJnQnVkZ2V0SUQsDQogIENBU1QgKEBQcmludEFsbCBBUyBpbnQpIEFTIFByaW50QWxsLA0KICAnJycnI" +
                        "CsgSXNOdWxsKENPTlZFUlQoVkFSQ0hBUiwgQERhdGVHZW5lcmllcnQsIDExMiksICcxOTAwMDEwMScpI" +
                        "CsgJycnJyBBUyBEYXRlR2VuZXJpZXJ0LA0KICBDQVNUIChAT25seVVudmVyYnVjaHRlQmVsZWdlIEFTI" +
                        "GludCkgIEFTIE9ubHlVbnZlcmJ1Y2h0ZUJlbGVnZQ0KRlJPTSBCZ0J1ZGdldCAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICBCQkcNCiAgSU5ORVIgSk9JTiBCZ0ZpbmFuenBsYW4gICAgICAgICAgICAgI" +
                        "CAgU0ZQIE9OIEJCRy5CZ0ZpbmFuenBsYW5JRCA9IFNGUC5CZ0ZpbmFuenBsYW5JRCAtLSBJTk5FUiBKT" +
                        "0lOIGludGVuZGVkOiBnZXQgbm90aGluZyBpZiBCQkcuQmdGaW5hbnpwbGFuSUQgaXMgbnVsbA0KICBJT" +
                        "k5FUiBKT0lOIEZhTGVpc3R1bmcgICAgICAgICAgICAgICAgICBMRUkgT04gTEVJLkZhTGVpc3R1bmdJR" +
                        "CA9IFNGUC5GYUxlaXN0dW5nSUQNCiAgLS1JTk5FUiBKT0lOIEZhRmFsbCAgICAgICAgICAgICAgICAgI" +
                        "CAgICBGQUwgT04gRkFMLkZhRmFsbElEID0gTEVJLkZhRmFsbElEDQogIElOTkVSIEpPSU4gQmFQZXJzb" +
                        "24gICAgICAgICAgICAgICAgICAgIFBSUyBPTiBMRUkuQmFQZXJzb25JRCA9IFBSUy5CYVBlcnNvbklED" +
                        "QogIExFRlQgIEpPSU4gWExPVkNvZGUgICAgICAgICAgICAgICAgICAgIExWUyBPTiBMVlMuQ29kZSA9I" +
                        "FNGUC5CZ0Jld2lsbGlndW5nU3RhdHVzQ29kZSBBTkQgTFZTLkxPVk5hbWUgPSAnQmdCZXdpbGxpZ3VuZ" +
                        "1N0YXR1cycNCiAgTEVGVCAgSk9JTiBYTE9WQ29kZSAgICAgICAgICAgICAgICAgICAgTFZUIE9OIExWV" +
                        "C5Db2RlID0gU0ZQLldoSGlsZmVUeXBDb2RlIEFORCBMVlQuTE9WTmFtZSA9ICdXaEhpbGZlVHlwJw0KI" +
                        "CBMRUZUICBKT0lOIFhMT1ZDb2RlICAgICAgICAgICAgICAgICAgICBMVkIgT04gTFZCLkNvZGUgPSBCQ" +
                        "kcuQmdCZXdpbGxpZ3VuZ1N0YXR1c0NvZGUgQU5EIExWQi5MT1ZOYW1lID0gJ0JnQmV3aWxsaWd1bmdTd" +
                        "GF0dXMnDQogIElOTkVSIEpPSU4gWFVzZXIgICAgICAgICAgICAgICAgICAgICAgIFVTUiBPTiBMRUkuV" +
                        "XNlcklEID0gVVNSLlVzZXJJRA0KICBMRUZUICBKT0lOIFhPcmdVbml0ICAgICBPcmcgb24gT3JnLk9yZ" +
                        "1VuaXRJRCA9ICgNCiAgICBTRUxFQ1QgVE9QIDEgT1UuT3JnVW5pdElEIEZST00gWE9yZ1VuaXRfVXNlc" +
                        "iBPVQ0KICAgIFdIRVJFIE9VLlVzZXJJRCA9IExFSS5Vc2VySUQNCiAgICAgIEFORCBPVS5PcmdVbml0T" +
                        "WVtYmVyQ29kZSA9IDIgKQ0KDQpXSEVSRSBCQkcuQmdCdWRnZXRJRCA9IEBCZ0J1ZGdldElEDQogIC0tQ" +
                        "U5EIEJCRy5CZ0Jld2lsbGlndW5nU3RhdHVzQ29kZSA9IDUgLS0gbnVyIGJld2lsbGlndGVAAAEAAAD//" +
                        "///AQAAAAAAAAAMAgAAABtEZXZFeHByZXNzLlh0cmFSZXBvcnRzLnY2LjIFAQAAACxEZXZFeHByZXNzL" +
                        "lh0cmFSZXBvcnRzLlVJLlNlcmlhbGl6YWJsZVN0cmluZwEAAAAFVmFsdWUBAgAAAAYDAAAAiQF7XHJ0Z" +
                        "jFcYW5zaVxhbnNpY3BnMTI1MlxkZWZmMFxkZWZsYW5nMjA1NXtcZm9udHRibHtcZjBcZm5pbFxmY2hhc" +
                        "nNldDAgQXJpYWw7fX0NClx2aWV3a2luZDRcdWMxXHBhcmRcZnMyMCBadXIgWmFobHVuZyBmcmVpZ2VnZ" +
                        "WJlblxwYXINCn0NCgs=";
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
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.ShPapierverfuegungBuchhaltung_Belege = new DevExpress.XtraReports.UI.Subreport();
            this.ShPapierverfuegungBuchhaltung_Personen = new DevExpress.XtraReports.UI.Subreport();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.txtEmployeeName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBezugsmonat = new DevExpress.XtraReports.UI.XRLabel();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.txtMbStatus = new DevExpress.XtraReports.UI.XRLabel();
            this.txtDatumBis = new DevExpress.XtraReports.UI.XRLabel();
            this.txtDatumVon = new DevExpress.XtraReports.UI.XRLabel();
            this.txtFpTyp = new DevExpress.XtraReports.UI.XRLabel();
            this.Label11 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label10 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label9 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtFpStatus = new DevExpress.XtraReports.UI.XRLabel();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKlientName = new DevExpress.XtraReports.UI.XRLabel();
            this.Label5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.OrgPLZOrt = new DevExpress.XtraReports.UI.XRLabel();
            this.OrgAdresse = new DevExpress.XtraReports.UI.XRLabel();
            this.OrgName = new DevExpress.XtraReports.UI.XRLabel();
            this.Label12 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.Label13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrRichTextBox1 = new DevExpress.XtraReports.UI.XRRichTextBox();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.piOrgOrtDatum = new DevExpress.XtraReports.UI.XRPageInfo();
            this.Line4 = new DevExpress.XtraReports.UI.XRLine();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.ShPapierverfuegungBuchhaltung_Belege,
                        this.ShPapierverfuegungBuchhaltung_Personen});
            this.Detail.Height = 80;
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
                        this.xrLine1,
                        this.txtEmployeeName,
                        this.txtBezugsmonat,
                        this.Line2,
                        this.Line1,
                        this.txtMbStatus,
                        this.txtDatumBis,
                        this.txtDatumVon,
                        this.txtFpTyp,
                        this.Label11,
                        this.Label10,
                        this.Label9,
                        this.Label8,
                        this.Label7,
                        this.txtFpStatus,
                        this.Label6,
                        this.txtKlientName,
                        this.Label5,
                        this.Label4,
                        this.OrgPLZOrt,
                        this.OrgAdresse,
                        this.OrgName,
                        this.Label12});
            this.PageHeader.Height = 247;
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
                        this.Line3,
                        this.Label13});
            this.GroupHeader1.Height = 31;
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
            this.GroupFooter1.Height = 0;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorders = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter1.ParentStyleUsing.UseFont = false;
            this.GroupFooter1.ParentStyleUsing.UseForeColor = false;
            this.GroupFooter1.Visible = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrRichTextBox1,
                        this.xrLabel2,
                        this.xrPageInfo2,
                        this.piOrgOrtDatum,
                        this.Line4});
            this.PageFooter.Height = 47;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // ShPapierverfuegungBuchhaltung_Belege
            // 
            this.ShPapierverfuegungBuchhaltung_Belege.Location = new System.Drawing.Point(0, 47);
            this.ShPapierverfuegungBuchhaltung_Belege.Name = "ShPapierverfuegungBuchhaltung_Belege";
            // 
            // ShPapierverfuegungBuchhaltung_Personen
            // 
            this.ShPapierverfuegungBuchhaltung_Personen.Location = new System.Drawing.Point(0, 0);
            this.ShPapierverfuegungBuchhaltung_Personen.Name = "ShPapierverfuegungBuchhaltung_Personen";
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Gray;
            this.xrLine1.Location = new System.Drawing.Point(0, 242);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(748, 2);
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "EmployeeName", "")});
            this.txtEmployeeName.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.txtEmployeeName.ForeColor = System.Drawing.Color.Black;
            this.txtEmployeeName.Location = new System.Drawing.Point(196, 218);
            this.txtEmployeeName.Multiline = true;
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtEmployeeName.ParentStyleUsing.UseBackColor = false;
            this.txtEmployeeName.ParentStyleUsing.UseBorderColor = false;
            this.txtEmployeeName.ParentStyleUsing.UseBorders = false;
            this.txtEmployeeName.ParentStyleUsing.UseBorderWidth = false;
            this.txtEmployeeName.ParentStyleUsing.UseFont = false;
            this.txtEmployeeName.ParentStyleUsing.UseForeColor = false;
            this.txtEmployeeName.Size = new System.Drawing.Size(511, 19);
            this.txtEmployeeName.Text = "EmployeeName";
            // 
            // txtBezugsmonat
            // 
            this.txtBezugsmonat.BackColor = System.Drawing.Color.PeachPuff;
            this.txtBezugsmonat.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bezugsmonat", "")});
            this.txtBezugsmonat.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtBezugsmonat.ForeColor = System.Drawing.Color.Black;
            this.txtBezugsmonat.Location = new System.Drawing.Point(196, 202);
            this.txtBezugsmonat.Multiline = true;
            this.txtBezugsmonat.Name = "txtBezugsmonat";
            this.txtBezugsmonat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBezugsmonat.ParentStyleUsing.UseBackColor = false;
            this.txtBezugsmonat.ParentStyleUsing.UseBorderColor = false;
            this.txtBezugsmonat.ParentStyleUsing.UseBorders = false;
            this.txtBezugsmonat.ParentStyleUsing.UseBorderWidth = false;
            this.txtBezugsmonat.ParentStyleUsing.UseFont = false;
            this.txtBezugsmonat.ParentStyleUsing.UseForeColor = false;
            this.txtBezugsmonat.Size = new System.Drawing.Size(511, 17);
            this.txtBezugsmonat.Text = "Bezugsmonat";
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.LineWidth = 2;
            this.Line2.Location = new System.Drawing.Point(0, 129);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(748, 2);
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.LineWidth = 2;
            this.Line1.Location = new System.Drawing.Point(0, 88);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(748, 2);
            // 
            // txtMbStatus
            // 
            this.txtMbStatus.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "MbStatus", "")});
            this.txtMbStatus.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtMbStatus.ForeColor = System.Drawing.Color.Black;
            this.txtMbStatus.Location = new System.Drawing.Point(196, 186);
            this.txtMbStatus.Multiline = true;
            this.txtMbStatus.Name = "txtMbStatus";
            this.txtMbStatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtMbStatus.ParentStyleUsing.UseBackColor = false;
            this.txtMbStatus.ParentStyleUsing.UseBorderColor = false;
            this.txtMbStatus.ParentStyleUsing.UseBorders = false;
            this.txtMbStatus.ParentStyleUsing.UseBorderWidth = false;
            this.txtMbStatus.ParentStyleUsing.UseFont = false;
            this.txtMbStatus.ParentStyleUsing.UseForeColor = false;
            this.txtMbStatus.Size = new System.Drawing.Size(511, 19);
            this.txtMbStatus.Text = "MbStatus";
            // 
            // txtDatumBis
            // 
            this.txtDatumBis.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "DatumBis", "{0:dd.MM.yyyy}")});
            this.txtDatumBis.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtDatumBis.ForeColor = System.Drawing.Color.Black;
            this.txtDatumBis.Location = new System.Drawing.Point(303, 170);
            this.txtDatumBis.Multiline = true;
            this.txtDatumBis.Name = "txtDatumBis";
            this.txtDatumBis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtDatumBis.ParentStyleUsing.UseBackColor = false;
            this.txtDatumBis.ParentStyleUsing.UseBorderColor = false;
            this.txtDatumBis.ParentStyleUsing.UseBorders = false;
            this.txtDatumBis.ParentStyleUsing.UseBorderWidth = false;
            this.txtDatumBis.ParentStyleUsing.UseFont = false;
            this.txtDatumBis.ParentStyleUsing.UseForeColor = false;
            this.txtDatumBis.Size = new System.Drawing.Size(78, 19);
            xrSummary1.FormatString = "{0:dd.MM.yyyy}";
            this.txtDatumBis.Summary = xrSummary1;
            this.txtDatumBis.Text = "DatumBis";
            // 
            // txtDatumVon
            // 
            this.txtDatumVon.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "DatumVon", "{0:dd.MM.yyyy}")});
            this.txtDatumVon.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtDatumVon.ForeColor = System.Drawing.Color.Black;
            this.txtDatumVon.Location = new System.Drawing.Point(196, 170);
            this.txtDatumVon.Multiline = true;
            this.txtDatumVon.Name = "txtDatumVon";
            this.txtDatumVon.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtDatumVon.ParentStyleUsing.UseBackColor = false;
            this.txtDatumVon.ParentStyleUsing.UseBorderColor = false;
            this.txtDatumVon.ParentStyleUsing.UseBorders = false;
            this.txtDatumVon.ParentStyleUsing.UseBorderWidth = false;
            this.txtDatumVon.ParentStyleUsing.UseFont = false;
            this.txtDatumVon.ParentStyleUsing.UseForeColor = false;
            this.txtDatumVon.Size = new System.Drawing.Size(78, 19);
            xrSummary2.FormatString = "{0:dd.MM.yyyy}";
            this.txtDatumVon.Summary = xrSummary2;
            this.txtDatumVon.Text = "DatumVon";
            // 
            // txtFpTyp
            // 
            this.txtFpTyp.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "FpTyp", "")});
            this.txtFpTyp.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtFpTyp.ForeColor = System.Drawing.Color.Black;
            this.txtFpTyp.Location = new System.Drawing.Point(196, 155);
            this.txtFpTyp.Multiline = true;
            this.txtFpTyp.Name = "txtFpTyp";
            this.txtFpTyp.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtFpTyp.ParentStyleUsing.UseBackColor = false;
            this.txtFpTyp.ParentStyleUsing.UseBorderColor = false;
            this.txtFpTyp.ParentStyleUsing.UseBorders = false;
            this.txtFpTyp.ParentStyleUsing.UseBorderWidth = false;
            this.txtFpTyp.ParentStyleUsing.UseFont = false;
            this.txtFpTyp.ParentStyleUsing.UseForeColor = false;
            this.txtFpTyp.Size = new System.Drawing.Size(511, 20);
            this.txtFpTyp.Text = "FpTyp";
            // 
            // Label11
            // 
            this.Label11.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(7, 218);
            this.Label11.Name = "Label11";
            this.Label11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label11.ParentStyleUsing.UseBackColor = false;
            this.Label11.ParentStyleUsing.UseBorderColor = false;
            this.Label11.ParentStyleUsing.UseBorders = false;
            this.Label11.ParentStyleUsing.UseBorderWidth = false;
            this.Label11.ParentStyleUsing.UseFont = false;
            this.Label11.ParentStyleUsing.UseForeColor = false;
            this.Label11.Size = new System.Drawing.Size(173, 19);
            this.Label11.Text = "Zuständiger Sozialarbeiter";
            // 
            // Label10
            // 
            this.Label10.BackColor = System.Drawing.Color.PeachPuff;
            this.Label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label10.ForeColor = System.Drawing.Color.Black;
            this.Label10.Location = new System.Drawing.Point(7, 202);
            this.Label10.Name = "Label10";
            this.Label10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label10.ParentStyleUsing.UseBackColor = false;
            this.Label10.ParentStyleUsing.UseBorderColor = false;
            this.Label10.ParentStyleUsing.UseBorders = false;
            this.Label10.ParentStyleUsing.UseBorderWidth = false;
            this.Label10.ParentStyleUsing.UseFont = false;
            this.Label10.ParentStyleUsing.UseForeColor = false;
            this.Label10.Size = new System.Drawing.Size(173, 17);
            this.Label10.Text = "Bezugsmonat";
            // 
            // Label9
            // 
            this.Label9.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(7, 186);
            this.Label9.Name = "Label9";
            this.Label9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label9.ParentStyleUsing.UseBackColor = false;
            this.Label9.ParentStyleUsing.UseBorderColor = false;
            this.Label9.ParentStyleUsing.UseBorders = false;
            this.Label9.ParentStyleUsing.UseBorderWidth = false;
            this.Label9.ParentStyleUsing.UseFont = false;
            this.Label9.ParentStyleUsing.UseForeColor = false;
            this.Label9.Size = new System.Drawing.Size(173, 19);
            this.Label9.Text = "Status Monatsbudget";
            // 
            // Label8
            // 
            this.Label8.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(7, 170);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(173, 19);
            this.Label8.Text = "Gültig von";
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(7, 155);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(173, 19);
            this.Label7.Text = "Typ Finanzplan";
            // 
            // txtFpStatus
            // 
            this.txtFpStatus.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "FpStatus", "")});
            this.txtFpStatus.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtFpStatus.ForeColor = System.Drawing.Color.Black;
            this.txtFpStatus.Location = new System.Drawing.Point(196, 139);
            this.txtFpStatus.Multiline = true;
            this.txtFpStatus.Name = "txtFpStatus";
            this.txtFpStatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtFpStatus.ParentStyleUsing.UseBackColor = false;
            this.txtFpStatus.ParentStyleUsing.UseBorderColor = false;
            this.txtFpStatus.ParentStyleUsing.UseBorders = false;
            this.txtFpStatus.ParentStyleUsing.UseBorderWidth = false;
            this.txtFpStatus.ParentStyleUsing.UseFont = false;
            this.txtFpStatus.ParentStyleUsing.UseForeColor = false;
            this.txtFpStatus.Size = new System.Drawing.Size(511, 19);
            this.txtFpStatus.Text = "FpStatus";
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(7, 139);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(173, 19);
            this.Label6.Text = "Status Finanzplan";
            // 
            // txtKlientName
            // 
            this.txtKlientName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KlientName", "")});
            this.txtKlientName.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.txtKlientName.ForeColor = System.Drawing.Color.Black;
            this.txtKlientName.Location = new System.Drawing.Point(118, 110);
            this.txtKlientName.Multiline = true;
            this.txtKlientName.Name = "txtKlientName";
            this.txtKlientName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKlientName.ParentStyleUsing.UseBackColor = false;
            this.txtKlientName.ParentStyleUsing.UseBorderColor = false;
            this.txtKlientName.ParentStyleUsing.UseBorders = false;
            this.txtKlientName.ParentStyleUsing.UseBorderWidth = false;
            this.txtKlientName.ParentStyleUsing.UseFont = false;
            this.txtKlientName.ParentStyleUsing.UseForeColor = false;
            this.txtKlientName.Size = new System.Drawing.Size(590, 19);
            this.txtKlientName.Text = "KlientName";
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(0, 110);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(118, 19);
            this.Label5.Text = "Klient/Klientin";
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(0, 64);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(708, 23);
            this.Label4.Text = "Zahlungsverfügung an die Buchhaltung (Papierschnitsttstelle)";
            // 
            // OrgPLZOrt
            // 
            this.OrgPLZOrt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_PLZOrt", "")});
            this.OrgPLZOrt.Font = new System.Drawing.Font("Arial", 11F);
            this.OrgPLZOrt.ForeColor = System.Drawing.Color.Black;
            this.OrgPLZOrt.Location = new System.Drawing.Point(542, 29);
            this.OrgPLZOrt.Name = "OrgPLZOrt";
            this.OrgPLZOrt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.OrgPLZOrt.ParentStyleUsing.UseBackColor = false;
            this.OrgPLZOrt.ParentStyleUsing.UseBorderColor = false;
            this.OrgPLZOrt.ParentStyleUsing.UseBorders = false;
            this.OrgPLZOrt.ParentStyleUsing.UseBorderWidth = false;
            this.OrgPLZOrt.ParentStyleUsing.UseFont = false;
            this.OrgPLZOrt.ParentStyleUsing.UseForeColor = false;
            this.OrgPLZOrt.Size = new System.Drawing.Size(181, 23);
            this.OrgPLZOrt.Text = "<OrgPlzOrt>";
            // 
            // OrgAdresse
            // 
            this.OrgAdresse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Adresse", "")});
            this.OrgAdresse.Font = new System.Drawing.Font("Arial", 11F);
            this.OrgAdresse.ForeColor = System.Drawing.Color.Black;
            this.OrgAdresse.Location = new System.Drawing.Point(542, 6);
            this.OrgAdresse.Name = "OrgAdresse";
            this.OrgAdresse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.OrgAdresse.ParentStyleUsing.UseBackColor = false;
            this.OrgAdresse.ParentStyleUsing.UseBorderColor = false;
            this.OrgAdresse.ParentStyleUsing.UseBorders = false;
            this.OrgAdresse.ParentStyleUsing.UseBorderWidth = false;
            this.OrgAdresse.ParentStyleUsing.UseFont = false;
            this.OrgAdresse.ParentStyleUsing.UseForeColor = false;
            this.OrgAdresse.Size = new System.Drawing.Size(181, 23);
            this.OrgAdresse.Text = "<OrgAdresse>";
            // 
            // OrgName
            // 
            this.OrgName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Name", "")});
            this.OrgName.Font = new System.Drawing.Font("Arial", 12F);
            this.OrgName.ForeColor = System.Drawing.Color.Black;
            this.OrgName.Location = new System.Drawing.Point(0, 0);
            this.OrgName.Name = "OrgName";
            this.OrgName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.OrgName.ParentStyleUsing.UseBackColor = false;
            this.OrgName.ParentStyleUsing.UseBorderColor = false;
            this.OrgName.ParentStyleUsing.UseBorders = false;
            this.OrgName.ParentStyleUsing.UseBorderWidth = false;
            this.OrgName.ParentStyleUsing.UseFont = false;
            this.OrgName.ParentStyleUsing.UseForeColor = false;
            this.OrgName.Size = new System.Drawing.Size(492, 31);
            this.OrgName.Text = "<OrgName>";
            // 
            // Label12
            // 
            this.Label12.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(275, 170);
            this.Label12.Name = "Label12";
            this.Label12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label12.ParentStyleUsing.UseBackColor = false;
            this.Label12.ParentStyleUsing.UseBorderColor = false;
            this.Label12.ParentStyleUsing.UseBorders = false;
            this.Label12.ParentStyleUsing.UseBorderWidth = false;
            this.Label12.ParentStyleUsing.UseFont = false;
            this.Label12.ParentStyleUsing.UseForeColor = false;
            this.Label12.Size = new System.Drawing.Size(27, 19);
            this.Label12.Text = "bis";
            // 
            // Line3
            // 
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.LineWidth = 2;
            this.Line3.Location = new System.Drawing.Point(0, 25);
            this.Line3.Name = "Line3";
            this.Line3.ParentStyleUsing.UseBackColor = false;
            this.Line3.ParentStyleUsing.UseBorderColor = false;
            this.Line3.ParentStyleUsing.UseBorders = false;
            this.Line3.ParentStyleUsing.UseBorderWidth = false;
            this.Line3.ParentStyleUsing.UseFont = false;
            this.Line3.ParentStyleUsing.UseForeColor = false;
            this.Line3.Size = new System.Drawing.Size(746, 2);
            // 
            // Label13
            // 
            this.Label13.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label13.ForeColor = System.Drawing.Color.Black;
            this.Label13.Location = new System.Drawing.Point(0, 4);
            this.Label13.Name = "Label13";
            this.Label13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label13.ParentStyleUsing.UseBackColor = false;
            this.Label13.ParentStyleUsing.UseBorderColor = false;
            this.Label13.ParentStyleUsing.UseBorders = false;
            this.Label13.ParentStyleUsing.UseBorderWidth = false;
            this.Label13.ParentStyleUsing.UseFont = false;
            this.Label13.ParentStyleUsing.UseForeColor = false;
            this.Label13.Size = new System.Drawing.Size(467, 23);
            this.Label13.Text = "Personen im Haushalt und in der Unterstützungseinheit";
            // 
            // xrRichTextBox1
            // 
            this.xrRichTextBox1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrRichTextBox1.Location = new System.Drawing.Point(283, 8);
            this.xrRichTextBox1.Name = "xrRichTextBox1";
            this.xrRichTextBox1.ParentStyleUsing.UseBackColor = false;
            this.xrRichTextBox1.ParentStyleUsing.UseFont = false;
            this.xrRichTextBox1.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichTextBox1.RtfText")));
            this.xrRichTextBox1.Size = new System.Drawing.Size(250, 17);
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel2.Location = new System.Drawing.Point(660, 7);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(40, 20);
            this.xrLabel2.Text = "Seite";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrPageInfo2.Location = new System.Drawing.Point(707, 7);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            this.xrPageInfo2.Size = new System.Drawing.Size(53, 20);
            // 
            // piOrgOrtDatum
            // 
            this.piOrgOrtDatum.Font = new System.Drawing.Font("Arial", 9.75F);
            this.piOrgOrtDatum.Format = "<OrgOrt>, {0:dd.MM.yyyy}";
            this.piOrgOrtDatum.Location = new System.Drawing.Point(8, 7);
            this.piOrgOrtDatum.Name = "piOrgOrtDatum";
            this.piOrgOrtDatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.piOrgOrtDatum.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.piOrgOrtDatum.ParentStyleUsing.UseFont = false;
            this.piOrgOrtDatum.Scripts.OnBeforePrint = resources.GetString("piOrgOrtDatum.Scripts.OnBeforePrint");
            this.piOrgOrtDatum.Size = new System.Drawing.Size(259, 20);
            // 
            // Line4
            // 
            this.Line4.ForeColor = System.Drawing.Color.Black;
            this.Line4.Location = new System.Drawing.Point(0, 0);
            this.Line4.Name = "Line4";
            this.Line4.ParentStyleUsing.UseBackColor = false;
            this.Line4.ParentStyleUsing.UseBorderColor = false;
            this.Line4.ParentStyleUsing.UseBorders = false;
            this.Line4.ParentStyleUsing.UseBorderWidth = false;
            this.Line4.ParentStyleUsing.UseFont = false;
            this.Line4.ParentStyleUsing.UseForeColor = false;
            this.Line4.Size = new System.Drawing.Size(746, 2);
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
            this.Margins = new System.Drawing.Printing.Margins(39, 26, 39, 39);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ScriptReferencesString = "System.Windows.Forms.dll";
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' , ParameterXML =  N'<?xml version="1.0" standalone="yes"?>
  <NewDataSet>
      <Table>
          <FieldName>label</FieldName>
          <FieldCode>1</FieldCode>
          <DisplayText>Budget ID:</DisplayText>
          <TabPosition>0</TabPosition>
          <X>10</X>
          <Y>60</Y>
          <Width>80</Width>
          <Height>25</Height>
          <Length>7</Length>
          <LOVName></LOVName>
          <DefaultValue>          </DefaultValue>
          <Mandatory>false</Mandatory>
          <TabName>          </TabName>
          <AppCode>          </AppCode>
      </Table>
      <Table>
          <FieldName>BgBudgetID</FieldName>
          <FieldCode>4</FieldCode>
          <DisplayText>Budget ID</DisplayText>
          <TabPosition>1</TabPosition>
          <X>240</X>
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
          <FieldName>PrintAll</FieldName>
          <FieldCode>7</FieldCode>
          <DisplayText>Alle Belege ausdrucken</DisplayText>
          <TabPosition>3</TabPosition>
          <X>10</X>
          <Y>90</Y>
          <Width>180</Width>
          <Height>25</Height>
          <Length>7</Length>
          <LOVName></LOVName>
          <DefaultValue></DefaultValue>
          <Mandatory>true</Mandatory>
          <TabName></TabName>
          <AppCode></AppCode>
      </Table>
      <Table>
          <FieldName>label</FieldName>
          <FieldCode>1</FieldCode>
          <DisplayText>Nur Belege ab diesem Datum ausdrucken:</DisplayText>
          <TabPosition>4</TabPosition>
          <X>10</X>
          <Y>120</Y>
          <Width>180</Width>
          <Height>25</Height>
          <Length>7</Length>
          <LOVName></LOVName>
          <DefaultValue></DefaultValue>
          <Mandatory>false</Mandatory>
          <TabName></TabName>
          <AppCode></AppCode>
      </Table>
      <Table>
          <FieldName>DateGeneriert</FieldName>
          <FieldCode>5</FieldCode>
          <DisplayText>Nur Belege ab diesem Datum ausdrucken</DisplayText>
          <TabPosition>5</TabPosition>
          <X>240</X>
          <Y>120</Y>
          <Width>96</Width>
          <Height>25</Height>
          <Length>7</Length>
          <LOVName></LOVName>
          <DefaultValue>today</DefaultValue>
          <Mandatory>false</Mandatory>
          <TabName></TabName>
          <AppCode></AppCode>
      </Table>
      <Table>
          <FieldName>OnlyUnverbuchteBelege</FieldName>
          <FieldCode>7</FieldCode>
          <DisplayText>Nur unverbuchte Belege</DisplayText>
          <TabPosition>7</TabPosition>
          <X>10</X>
          <Y>150</Y>
          <Width>180</Width>
          <Height>25</Height>
          <Length>7</Length>
          <LOVName></LOVName>
          <DefaultValue>1</DefaultValue>
          <Mandatory>true</Mandatory>
          <TabName></TabName>
          <AppCode></AppCode>
      </Table>
  </NewDataSet>' , SQLquery =  N'declare @BgBudgetID            int
declare @PrintAll              bit
declare @DateGeneriert         datetime
declare @OnlyUnverbuchteBelege bit
declare @sMonth                varchar(20)

set @BgBudgetID            = {BgBudgetID}
set @PrintAll              = {PrintAll}
set @DateGeneriert         = {DateGeneriert}
set @OnlyUnverbuchteBelege = {OnlyUnverbuchteBelege}

SELECT @sMonth = dbo.fnXMonat(Monat) + '' '' + STR(Jahr,4)
FROM BgBudget WHERE BgBudgetID = @BgBudgetID


SELECT
  Org_Name    = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Organisation'', GetDate())), ''''),
  Org_Adresse = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Adresse'', GetDate())), ''''),
  Org_PLZ     = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', GetDate())), ''''),
  Org_Ort     = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', GetDate())), ''''),
  Org_PLZOrt  = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', GetDate())) + '' '', '''')
              + IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', GetDate())), ''''),

  OrgUnitAdresse = Org.Text1,
  PRS.Name + '', '' + PRS.Vorname + IsNull('' '' + PRS.Vorname2, '''') AS KlientName,
  LVS.Text AS FpStatus,
  LVT.Text AS FpTyp,
  LVT.Value2 AS IsUrgent, -- 2.0 DB: IsUrgent
  SFP.GeplantVon,
  SFP.GeplantBis,
  SFP.DatumVon,
  SFP.DatumBis,
  SFP.Bemerkung AS ShFpBemerkung,
  BBG.Jahr,
  BBG.Monat,
  @sMonth AS Bezugsmonat,
  LVB.Text AS MbStatus,
  USR.LastName+ISNULL('', ''+USR.FirstName,'''')+ISNULL('' (''+Org.ItemName+'')'','''')+ISNULL('', Tel. ''+USR.Phone,'''') AS EmployeeName,
  -- Must provide parameters as variables to parent in special form so that subreports can read them
  @BgBudgetID AS BgBudgetID,
  CAST (@PrintAll AS int) AS PrintAll,
  '''''''' + IsNull(CONVERT(VARCHAR, @DateGeneriert, 112), ''19000101'') + '''''''' AS DateGeneriert,
  CAST (@OnlyUnverbuchteBelege AS int)  AS OnlyUnverbuchteBelege
FROM BgBudget                               BBG
  INNER JOIN BgFinanzplan                SFP ON BBG.BgFinanzplanID = SFP.BgFinanzplanID -- INNER JOIN intended: get nothing if BBG.BgFinanzplanID is null
  INNER JOIN FaLeistung                  LEI ON LEI.FaLeistungID = SFP.FaLeistungID
  --INNER JOIN FaFall                      FAL ON FAL.FaFallID = LEI.FaFallID
  INNER JOIN BaPerson                    PRS ON LEI.BaPersonID = PRS.BaPersonID
  LEFT  JOIN XLOVCode                    LVS ON LVS.Code = SFP.BgBewilligungStatusCode AND LVS.LOVName = ''BgBewilligungStatus''
  LEFT  JOIN XLOVCode                    LVT ON LVT.Code = SFP.WhHilfeTypCode AND LVT.LOVName = ''WhHilfeTyp''
  LEFT  JOIN XLOVCode                    LVB ON LVB.Code = BBG.BgBewilligungStatusCode AND LVB.LOVName = ''BgBewilligungStatus''
  INNER JOIN XUser                       USR ON LEI.UserID = USR.UserID
  LEFT  JOIN XOrgUnit     Org on Org.OrgUnitID = (
    SELECT TOP 1 OU.OrgUnitID FROM XOrgUnit_User OU
    WHERE OU.UserID = LEI.UserID
      AND OU.OrgUnitMemberCode = 2 )

WHERE BBG.BgBudgetID = @BgBudgetID
  --AND BBG.BgBewilligungStatusCode = 5 -- nur bewilligte' , ContextForms =  N'WhMonatsbudget,CtlWhBudget' , ParentReportName =  null , ReportSortKey = 1
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'ShPapierverfuegungBuchhaltung' ;


INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShPapierverfuegungBuchhaltung_Belege' ,  N'Belege' , 1,  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>C:\Windows\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>en-US</Localization>
///   <References>
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraPrinting.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Drawing\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Configuration\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Data.SqlXml\v4.0_4.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Security\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.Utils.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Utils.v6.2.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Forms\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Forms.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Accessibility\v4.0_4.0.0.0__b03f5f7f11d50a3a\Accessibility.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Serialization.Formatters.Soap\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Runtime.Serialization.Formatters.Soap.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Deployment\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Deployment.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Design\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Design.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Data\v4.0_4.0.0.0__b77a5c561934e089\System.Data.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.VisualC\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualC.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Transactions\v4.0_4.0.0.0__b77a5c561934e089\System.Transactions.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.EnterpriseServices\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.EnterpriseServices.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.DirectoryServices\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Remoting\v4.0_4.0.0.0__b77a5c561934e089\System.Runtime.Remoting.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Web\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Framework\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Framework.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Xaml\v4.0_4.0.0.0__b77a5c561934e089\System.Xaml.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Caching\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Runtime.Caching.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Web.ApplicationServices\v4.0_4.0.0.0__31bf3856ad364e35\System.Web.ApplicationServices.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Core\v4.0_4.0.0.0__b77a5c561934e089\System.Core.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Numerics\v4.0_4.0.0.0__b77a5c561934e089\System.Numerics.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Web.Services\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.Services.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Utilities.v4.0\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Utilities.v4.0.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.DirectoryServices.Protocols\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.Protocols.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Tasks.v4.0\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Tasks.v4.0.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceProcess\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.ServiceProcess.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Configuration.Install\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.Install.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Serialization\v4.0_4.0.0.0__b77a5c561934e089\System.Runtime.Serialization.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\SMDiagnostics\v4.0_4.0.0.0__b77a5c561934e089\SMDiagnostics.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.DurableInstancing\v4.0_4.0.0.0__31bf3856ad364e35\System.Runtime.DurableInstancing.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Xml.Linq\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.Linq.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Web.RegularExpressions\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.RegularExpressions.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Drawing.Design\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.Design.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Data.OracleClient\v4.0_4.0.0.0__b77a5c561934e089\System.Data.OracleClient.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraEditors.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.Data.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Data.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraBars.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraNavBar.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraCharts.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraRichTextEdit.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="C:\KiSS\Current\KiSS4.DB.dll" />
///     <Reference Path="C:\KiSS\Current\log4net.dll" />
///     <Reference Path="C:\KiSS\Current\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtNameFbKostenstelle;
        private DevExpress.XtraReports.UI.XRLabel txtNummerNrmKonto;
        private DevExpress.XtraReports.UI.XRLabel txtIntern;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel txtBelegBezeichnung;
        private DevExpress.XtraReports.UI.XRLabel txtVerfallDatum;
        private DevExpress.XtraReports.UI.XRLabel txtBuchungsdatum;
        private DevExpress.XtraReports.UI.XRLabel Label2;
        private DevExpress.XtraReports.UI.XRLabel Label1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader4;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLabel Label13;
        private DevExpress.XtraReports.UI.XRLabel Label12;
        private DevExpress.XtraReports.UI.XRLabel Label11;
        private DevExpress.XtraReports.UI.XRLabel Label10;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel24;
        private DevExpress.XtraReports.UI.XRPageBreak xrPageBreak1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel23;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kA" +
                        "AAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAA" +
                        "AAAAcYhZGVjbGFyZSAgQEJnQnVkZ2V0SUQgICAgICAgICAgICBpbnQNCmRlY2xhcmUgIEBQcmludEFsb" +
                        "CAgICAgICAgICAgICAgYml0DQpkZWNsYXJlICBARGF0ZUdlbmVyaWVydCAgICAgICAgIGRhdGV0aW1lD" +
                        "QpkZWNsYXJlICBAT25seVVudmVyYnVjaHRlQmVsZWdlIGJpdA0KDQpzZXQgQEJnQnVkZ2V0SUQgICAgI" +
                        "CAgICAgID0gbnVsbA0Kc2V0IEBQcmludEFsbCAgICAgICAgICAgICA9IG51bGwNCnNldCBARGF0ZUdlb" +
                        "mVyaWVydCAgICAgICAgPSBudWxsDQpzZXQgQE9ubHlVbnZlcmJ1Y2h0ZUJlbGVnZT0gbnVsbA0KDQpkZ" +
                        "WNsYXJlICBAQnVkZ2V0TW9uYXQgICAgICAgICAgIGludA0KZGVjbGFyZSAgQEJ1ZGdldEphaHIgICAgI" +
                        "CAgICAgICBpbnQNCnNldCBAQnVkZ2V0TW9uYXQgICAgICAgICAgPSAoU0VMRUNUIE1vbmF0IEZST00gQ" +
                        "mdCdWRnZXQgV0hFUkUgQmdCdWRnZXRJRCA9IEBCZ0J1ZGdldElEKQ0Kc2V0IEBCdWRnZXRKYWhyICAgI" +
                        "CAgICAgICA9IChTRUxFQ1QgSmFociAgRlJPTSBCZ0J1ZGdldCBXSEVSRSBCZ0J1ZGdldElEID0gQEJnQ" +
                        "nVkZ2V0SUQpDQoNCg0KICBTRUxFQ1QNCiAgICBCZXp1Z3Ntb25hdCA9IGRiby5mblhNb25hdChAQnVkZ" +
                        "2V0TW9uYXQpICsgJyAnICsgQ09OVkVSVChWQVJDSEFSKDQpLCBAQnVkZ2V0SmFociksDQogICAgS2xpZ" +
                        "W50TmFtZSA9IChTRUxFQ1QgUFJTLk5hbWUgKyAnLCAnICsgUFJTLlZvcm5hbWUgDQogICAgICAgICAgI" +
                        "CAgICAgICBGUk9NIEJhUGVyc29uIFBSUyANCiAgICAgICAgICAgICAgICAgICAgSU5ORVIgSk9JTiBGY" +
                        "UxlaXN0dW5nIExFSSBPTiBMRUkuQmFQZXJzb25JRCA9IFBSUy5CYVBlcnNvbklEIA0KICAgICAgICAgI" +
                        "CAgICAgICAgICBJTk5FUiBKT0lOIEJnRmluYW56cGxhbiBGUEwgT04gRlBMLkZhTGVpc3R1bmdJRCA9I" +
                        "ExFSS5GYUxlaXN0dW5nSUQgDQogICAgICAgICAgICAgICAgICAgIElOTkVSIEpPSU4gQmdCdWRnZXQgQ" +
                        "kRHIE9OIEJERy5CZ0ZpbmFuenBsYW5JRCA9IEZQTC5CZ0ZpbmFuenBsYW5JRA0KICAgICAgICAgICAgI" +
                        "CAgICAgV0hFUkUgQkRHLkJnQnVkZ2V0SUQgPSBAQmdCdWRnZXRJRCksDQogICAgQmVsZWdCZXplaWNob" +
                        "nVuZyA9ICdCZWxlZyAjICcgKyBDQVNUKEZCTC5LYkJ1Y2h1bmdJRCBBUyBWQVJDSEFSKSArICcsICcgK" +
                        "w0KICAgICAgZGJvLmZuTE9WVGV4dCgnS2JCdWNodW5nc1N0YXR1cycsRkJMLktiQnVjaHVuZ1N0YXR1c" +
                        "0NvZGUpLA0KICAgIElkR3JvdXAgPSAxLA0KICAgIE5hbWVHcm91cCA9IENPTlZFUlQoVkFSQ0hBUigyM" +
                        "CksJ0J1ZGdldHBvc2l0aW9uZW4nKSwNCiAgICBGQkwuS2JCdWNodW5nSUQsDQogICAgRktBLktiQnVja" +
                        "HVuZ0tvc3RlbmFydElELA0KICAgIEZLUy5LYktvc3RlbnN0ZWxsZUlELA0KICAgIEdlbmVyaWVydEFtI" +
                        "D0gRkJMLkVyc3RlbGx0RGF0dW0sDQogICAgVmVyYnVjaHRBbSA9IEZCTC5CZWxlZ0RhdHVtLA0KICAgI" +
                        "EJ1Y2h1bmdzZGF0dW0gPSBGQkwuQmVsZWdEYXR1bSwNCiAgICBWZXJmYWxsRGF0dW0gPSBGQkwuVmFsd" +
                        "XRhRGF0dW0sDQogICAgQnVjaHVuZ3N0ZXh0ID0gRkJMLlRleHQsDQogICAgRXh0ZXJuID0gRkJMLkV4d" +
                        "GVybiwtLUlzTnVsbChQUjIuTmFtZSwgUFJTLk5hbWUpICsgQ29hbGVzY2UoJyAnK1BSMi5Wb3JuYW1lL" +
                        "CAnICcrUFJTLlZvcm5hbWUsICcnKSwNCiAgICBFU1IgPSBGQkwuUmVmZXJlbnpOdW1tZXIsDQogICAgQ" +
                        "mVsZWdudW1tZXIgPSBGQkwuQmVsZWdOciwNCiAgICBJbnRlcm4gPSBGS0EuQnVjaHVuZ3N0ZXh0LA0KI" +
                        "CAgIEludGVybkJ1ZGdldERhdHVtID0gZGJvLmZuWE1vbmF0KEBCdWRnZXRNb25hdCkgKyAnICcgKyBDT" +
                        "05WRVJUKHZhcmNoYXIsIEBCdWRnZXRKYWhyKSwNCiAgICBGS0EuQmV0cmFnLA0KICAgIE5hbWVCZWxlZ" +
                        "1N0YXR1cyA9IGRiby5mbkxPVlRleHQoJ0tiQnVjaHVuZ1N0YXR1cycsIEZCTC5LYkJ1Y2h1bmdTdGF0d" +
                        "XNDb2RlKSwNCiAgICBJZEZpYnVLb3N0ZW5hcnQgPSBLT0EuRXh0RmlidUtvc3RlbmFydE5yLA0KICAgI" +
                        "E5hbWVGYktvc3RlbmFydCA9IEtPQS5OYW1lLA0KICAgIE5hbWVGYktvc3RlbnN0ZWxsZSA9IA0KICAgI" +
                        "CBDQVNFIA0KICAgICAgV0hFTiAnNTMwJyBJTiAoICANCiAgICAgICAgU0VMRUNUIEV4dEZpYnVLb3N0Z" +
                        "W5hcnROcg0KICAgICAgICBGUk9NIEJnS29zdGVuYXJ0DQogICAgICAgIFdIRVJFIEJnS29zdGVuYXJ0S" +
                        "UQgPSBGS0EuQmdLb3N0ZW5hcnRJRCAgICAgICAgICANCiAgICAgICAgKQ0KICAgICAgVEhFTg0KICAgI" +
                        "CAgICAnNTIwLjM2Ni4wMScNCiAgICAgIEVMU0UgDQogICAgICAgIEtTVC5Ocg0KICAgICBFTkQsDQogI" +
                        "CAgTnJtS29udG8gPSBMVk4uVmFsdWUxLA0KICAgIE5hbWVJbmhhYmVyID0gS1NULk5hbWUsIC0tS1NUL" +
                        "k5hbWVJbmhhYmVyIEFTIE5hbWVJbmhhYmVyLA0KICAgIEtyZWRpdG9yTmFtZSA9IEZCTC5CZWd1ZW5zd" +
                        "GlndE5hbWUsDQogICAgS3JlZGl0b3JTdHJhc3NlID0gRkJMLkJlZ3VlbnN0aWd0U3RyYXNzZSwNCiAgI" +
                        "CBLcmVkaXRvck9ydCA9IElTTlVMTChGQkwuQmVndWVuc3RpZ3RQTForJyAnLCcnKSArSVNOVUxMKEZCT" +
                        "C5CZWd1ZW5zdGlndE9ydCwnJyksDQogICAgSVNOVUxMKEZCTC5CYW5rTmFtZSsnLCAnLCcnKSArDQogI" +
                        "CAgQ0FTRQ0KICAgICAgV0hFTiBMRU4oSVNOVUxMKEZCTC5CYW5rS29udG9OciwgJycpKSA+IDANCiAgI" +
                        "CAgIFRIRU4gJ0t0bzogJytGQkwuQmFua0tvbnRvTnIrJyAnIA0KICAgICAgV0hFTiBMRU4oSVNOVUxMK" +
                        "EZCTC5JQkFOLCAnJykpID4gMA0KICAgICAgVEhFTiAnSUJBTjogJytGQkwuSUJBTisnICcNCiAgICAgI" +
                        "EVMU0UgJycNCiAgICBFTkQgKw0KICAgIENBU0UNCiAgICAgIFdIRU4gTEVOKElTTlVMTChGQkwuUENLb" +
                        "250b05yLCcnKSkgPiAwDQogICAgICBUSEVOICdQQzogJytkYm8uZm5UblRvUGMoRkJMLlBDS29udG9Oc" +
                        "ikgRUxTRSAnJw0KICAgIEVORCBBUyBCYW5rTmFtZSANCiAgRlJPTSBLYkJ1Y2h1bmcgRkJMDQogICAgT" +
                        "EVGVCBKT0lOIEtiQnVjaHVuZ0tvc3RlbmFydCBGS0EgT04gRkJMLktiQnVjaHVuZ0lEICAgICAgICAgI" +
                        "D0gRktBLktiQnVjaHVuZ0lEDQogICAgTEVGVCBKT0lOIEtiS29zdGVuc3RlbGxlICAgICBGS1MgT04gR" +
                        "ktBLktiS29zdGVuc3RlbGxlSUQgPSBGS1MuS2JLb3N0ZW5zdGVsbGVJRA0KICAgIExFRlQgSk9JTiBCZ" +
                        "0tvc3RlbmFydCAgICAgICAgS09BIE9OIEtPQS5CZ0tvc3RlbmFydElEICAgICAgPSBGS0EuQmdLb3N0Z" +
                        "W5hcnRJRA0KICAgIExFRlQgSk9JTiBLYktvc3RlbnN0ZWxsZSAgICAgS1NUIE9OIEtTVC5LYktvc3Rlb" +
                        "nN0ZWxsZUlEICAgPSBGS1MuS2JLb3N0ZW5zdGVsbGVJRA0KICAgIExFRlQgSk9JTiBYTE9WQ29kZSAgI" +
                        "CAgICAgICAgTFZOIE9OIExWTi5Db2RlID0gRktBLk5ybUtvbnRvQ29kZSBBTkQgTFZOLkxPVk5hbWUgP" +
                        "SAnTnJtS29udG8nDQogICAgTEVGVCBKT0lOIEJhUGVyc29uICAgICAgICAgICBQUlMgT04gUFJTLkJhU" +
                        "GVyc29uSUQgPSBGS0EuQmFQZXJzb25JRA0KICAgIExFRlQgSk9JTiBLYktvc3RlbnN0ZWxsZV9CYVBlc" +
                        "nNvbiBLU1AgT04gS1NQLktiS29zdGVuc3RlbGxlSUQgPSBLU1QuS2JLb3N0ZW5zdGVsbGVJRCANCiAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgQU5EIEtTUC5CYVBlcnNvbklEID0gUFJTLkJhUGVyc29uSUQNC" +
                        "iAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIChLU1AuRGF0dW1CaXMgSVMgTlVMTCBPUiBHZXREY" +
                        "XRlKCkgQkVUV0VFTiBLU1AuRGF0dW1Wb24gQU5EIEtTUC5EYXR1bUJpcykNCiAgICBMRUZUIEpPSU4gQ" +
                        "mFQZXJzb24gICAgICAgICAgIFBSMiBPTiBQUjIuQmFQZXJzb25JRCA9IEtTUC5CYVBlcnNvbklEDQogV" +
                        "0hFUkUgRkJMLkJnQnVkZ2V0SUQgPSBAQmdCdWRnZXRJRA0KICAgIEFORCBGQkwuS2JBdXN6YWhsdW5nc" +
                        "2FydENvZGUgSU4gKDEwMiwgMTA0KSAgIC0tIFBhcGllcnZlcmbDvGd1bmcgenVyIEJ1Y2hoYWx0dW5nD" +
                        "QogICAgQU5EIEZCTC5LYkJ1Y2h1bmdTdGF0dXNDb2RlIGluICgxLDIpIC0tIHZvcmJlcmVpdGV0LCBmc" +
                        "mVpZ2VnZWJlbg0KICAgIEFORCBGQkwuS2JCdWNodW5nVHlwQ29kZT0xDQogICAgQU5EICgNCiAgICAgI" +
                        "ChAT25seVVudmVyYnVjaHRlQmVsZWdlPTEgQU5EIEZCTC5LYkJ1Y2h1bmdTdGF0dXNDb2RlID0gMikgT" +
                        "1INCiAgICAgIChAT25seVVudmVyYnVjaHRlQmVsZWdlPTApDQogICAgKQ0KICAgIEFORCAoDQogICAgI" +
                        "CAoQFByaW50QWxsID0gMCBBTkQgKEBEYXRlR2VuZXJpZXJ0IDw9IEZCTC5FcnN0ZWxsdERhdHVtKSApI" +
                        "E9SDQogICAgICAoQFByaW50QWxsID0gMSkNCiAgICApDQoNCg0KICBPUkRFUiBCWSBJZEdyb3VwLCBGQ" +
                        "kwuS2JCdWNodW5nSUQsIEZLQS5LYkJ1Y2h1bmdLb3N0ZW5hcnRJRAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=";
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
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter4 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNameFbKostenstelle = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNummerNrmKonto = new DevExpress.XtraReports.UI.XRLabel();
            this.txtIntern = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.txtBelegBezeichnung = new DevExpress.XtraReports.UI.XRLabel();
            this.txtVerfallDatum = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBuchungsdatum = new DevExpress.XtraReports.UI.XRLabel();
            this.Label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.Label13 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label12 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label11 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageBreak1 = new DevExpress.XtraReports.UI.XRPageBreak();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtBetrag,
                        this.txtNameFbKostenstelle,
                        this.txtNummerNrmKonto,
                        this.txtIntern});
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
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Line1,
                        this.txtBelegBezeichnung,
                        this.txtVerfallDatum,
                        this.txtBuchungsdatum,
                        this.Label2,
                        this.Label1});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("KbBuchungID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 61;
            this.GroupHeader1.Level = 1;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLine2,
                        this.xrLabel7,
                        this.xrLabel6,
                        this.Line2,
                        this.Label13,
                        this.Label12,
                        this.Label11,
                        this.Label10});
            this.GroupHeader4.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("IdFibuKostenart", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader4.Height = 45;
            this.GroupHeader4.Name = "GroupHeader4";
            this.GroupHeader4.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader4.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader4.ParentStyleUsing.UseBorders = false;
            this.GroupHeader4.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader4.ParentStyleUsing.UseFont = false;
            this.GroupHeader4.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter4
            // 
            this.GroupFooter4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel24,
                        this.xrPageBreak1,
                        this.xrLabel23,
                        this.xrLabel22,
                        this.xrLabel21,
                        this.xrLabel20,
                        this.xrLabel19,
                        this.xrLabel18,
                        this.xrLabel17,
                        this.xrLabel16,
                        this.xrLabel15,
                        this.xrLabel14,
                        this.xrLabel13,
                        this.xrLabel12,
                        this.xrLabel11,
                        this.xrLabel10,
                        this.xrLabel9,
                        this.xrLabel8,
                        this.xrLabel4,
                        this.xrLabel3});
            this.GroupFooter4.Height = 255;
            this.GroupFooter4.Level = 1;
            this.GroupFooter4.Name = "GroupFooter4";
            this.GroupFooter4.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter4.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter4.ParentStyleUsing.UseBorders = false;
            this.GroupFooter4.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter4.ParentStyleUsing.UseFont = false;
            this.GroupFooter4.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel5,
                        this.xrLabel2,
                        this.xrLine1,
                        this.xrLabel1});
            this.GroupFooter1.Height = 28;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorders = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter1.ParentStyleUsing.UseFont = false;
            this.GroupFooter1.ParentStyleUsing.UseForeColor = false;
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 8F);
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
            this.txtBetrag.Size = new System.Drawing.Size(84, 19);
            xrSummary1.FormatString = "{0:0.00}";
            this.txtBetrag.Summary = xrSummary1;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtNameFbKostenstelle
            // 
            this.txtNameFbKostenstelle.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameFbKostenstelle", "")});
            this.txtNameFbKostenstelle.Font = new System.Drawing.Font("Arial", 8F);
            this.txtNameFbKostenstelle.ForeColor = System.Drawing.Color.Black;
            this.txtNameFbKostenstelle.Location = new System.Drawing.Point(472, 0);
            this.txtNameFbKostenstelle.Multiline = true;
            this.txtNameFbKostenstelle.Name = "txtNameFbKostenstelle";
            this.txtNameFbKostenstelle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBackColor = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBorderColor = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBorders = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBorderWidth = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseFont = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseForeColor = false;
            this.txtNameFbKostenstelle.Size = new System.Drawing.Size(133, 19);
            this.txtNameFbKostenstelle.Text = "NameFbKostenstelle";
            // 
            // txtNummerNrmKonto
            // 
            this.txtNummerNrmKonto.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NrmKonto", "")});
            this.txtNummerNrmKonto.Font = new System.Drawing.Font("Arial", 8F);
            this.txtNummerNrmKonto.ForeColor = System.Drawing.Color.Black;
            this.txtNummerNrmKonto.Location = new System.Drawing.Point(330, 0);
            this.txtNummerNrmKonto.Multiline = true;
            this.txtNummerNrmKonto.Name = "txtNummerNrmKonto";
            this.txtNummerNrmKonto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNummerNrmKonto.ParentStyleUsing.UseBackColor = false;
            this.txtNummerNrmKonto.ParentStyleUsing.UseBorderColor = false;
            this.txtNummerNrmKonto.ParentStyleUsing.UseBorders = false;
            this.txtNummerNrmKonto.ParentStyleUsing.UseBorderWidth = false;
            this.txtNummerNrmKonto.ParentStyleUsing.UseFont = false;
            this.txtNummerNrmKonto.ParentStyleUsing.UseForeColor = false;
            this.txtNummerNrmKonto.Size = new System.Drawing.Size(141, 19);
            this.txtNummerNrmKonto.Text = "txtNummerNrmKonto";
            // 
            // txtIntern
            // 
            this.txtIntern.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Intern", "")});
            this.txtIntern.Font = new System.Drawing.Font("Arial", 8F);
            this.txtIntern.ForeColor = System.Drawing.Color.Black;
            this.txtIntern.Location = new System.Drawing.Point(39, 0);
            this.txtIntern.Name = "txtIntern";
            this.txtIntern.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtIntern.ParentStyleUsing.UseBackColor = false;
            this.txtIntern.ParentStyleUsing.UseBorderColor = false;
            this.txtIntern.ParentStyleUsing.UseBorders = false;
            this.txtIntern.ParentStyleUsing.UseBorderWidth = false;
            this.txtIntern.ParentStyleUsing.UseFont = false;
            this.txtIntern.ParentStyleUsing.UseForeColor = false;
            this.txtIntern.Size = new System.Drawing.Size(287, 19);
            this.txtIntern.Text = "Intern";
            this.txtIntern.WordWrap = false;
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.Location = new System.Drawing.Point(0, 17);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(747, 3);
            // 
            // txtBelegBezeichnung
            // 
            this.txtBelegBezeichnung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BelegBezeichnung", "")});
            this.txtBelegBezeichnung.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.txtBelegBezeichnung.ForeColor = System.Drawing.Color.Black;
            this.txtBelegBezeichnung.Location = new System.Drawing.Point(0, 0);
            this.txtBelegBezeichnung.Multiline = true;
            this.txtBelegBezeichnung.Name = "txtBelegBezeichnung";
            this.txtBelegBezeichnung.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBelegBezeichnung.ParentStyleUsing.UseBackColor = false;
            this.txtBelegBezeichnung.ParentStyleUsing.UseBorderColor = false;
            this.txtBelegBezeichnung.ParentStyleUsing.UseBorders = false;
            this.txtBelegBezeichnung.ParentStyleUsing.UseBorderWidth = false;
            this.txtBelegBezeichnung.ParentStyleUsing.UseFont = false;
            this.txtBelegBezeichnung.ParentStyleUsing.UseForeColor = false;
            this.txtBelegBezeichnung.Size = new System.Drawing.Size(547, 17);
            this.txtBelegBezeichnung.Text = "BelegBezeichnung";
            // 
            // txtVerfallDatum
            // 
            this.txtVerfallDatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VerfallDatum", "{0:dd.MM.yyyy}")});
            this.txtVerfallDatum.Font = new System.Drawing.Font("Arial", 8F);
            this.txtVerfallDatum.ForeColor = System.Drawing.Color.Black;
            this.txtVerfallDatum.Location = new System.Drawing.Point(173, 42);
            this.txtVerfallDatum.Multiline = true;
            this.txtVerfallDatum.Name = "txtVerfallDatum";
            this.txtVerfallDatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtVerfallDatum.ParentStyleUsing.UseBackColor = false;
            this.txtVerfallDatum.ParentStyleUsing.UseBorderColor = false;
            this.txtVerfallDatum.ParentStyleUsing.UseBorders = false;
            this.txtVerfallDatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtVerfallDatum.ParentStyleUsing.UseFont = false;
            this.txtVerfallDatum.ParentStyleUsing.UseForeColor = false;
            this.txtVerfallDatum.Size = new System.Drawing.Size(374, 19);
            xrSummary2.FormatString = "{0:dd.MM.yyyy}";
            this.txtVerfallDatum.Summary = xrSummary2;
            this.txtVerfallDatum.Text = "txtVerfallDatum";
            // 
            // txtBuchungsdatum
            // 
            this.txtBuchungsdatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Buchungsdatum", "{0:dd.MM.yyyy}")});
            this.txtBuchungsdatum.Font = new System.Drawing.Font("Arial", 8F);
            this.txtBuchungsdatum.ForeColor = System.Drawing.Color.Black;
            this.txtBuchungsdatum.Location = new System.Drawing.Point(173, 25);
            this.txtBuchungsdatum.Multiline = true;
            this.txtBuchungsdatum.Name = "txtBuchungsdatum";
            this.txtBuchungsdatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBuchungsdatum.ParentStyleUsing.UseBackColor = false;
            this.txtBuchungsdatum.ParentStyleUsing.UseBorderColor = false;
            this.txtBuchungsdatum.ParentStyleUsing.UseBorders = false;
            this.txtBuchungsdatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtBuchungsdatum.ParentStyleUsing.UseFont = false;
            this.txtBuchungsdatum.ParentStyleUsing.UseForeColor = false;
            this.txtBuchungsdatum.Size = new System.Drawing.Size(374, 19);
            xrSummary3.FormatString = "{0:dd.MM.yyyy}";
            this.txtBuchungsdatum.Summary = xrSummary3;
            this.txtBuchungsdatum.Text = "txtBuchungsdatum";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 8F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(39, 42);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(125, 19);
            this.Label2.Text = "Verfalldatum";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 8F);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(39, 25);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(125, 19);
            this.Label1.Text = "Buchungsdatum";
            // 
            // xrLine2
            // 
            this.xrLine2.ForeColor = System.Drawing.Color.Gray;
            this.xrLine2.Location = new System.Drawing.Point(33, 0);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.ParentStyleUsing.UseBackColor = false;
            this.xrLine2.ParentStyleUsing.UseBorderColor = false;
            this.xrLine2.ParentStyleUsing.UseBorders = false;
            this.xrLine2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine2.ParentStyleUsing.UseFont = false;
            this.xrLine2.ParentStyleUsing.UseForeColor = false;
            this.xrLine2.Size = new System.Drawing.Size(653, 2);
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameFbKostenart", "")});
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel7.Location = new System.Drawing.Point(140, 8);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.Size = new System.Drawing.Size(507, 17);
            this.xrLabel7.Text = "xrLabel7";
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "IdFibuKostenart", "Kostenart {0} :")});
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel6.Location = new System.Drawing.Point(40, 8);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.Size = new System.Drawing.Size(180, 17);
            this.xrLabel6.Text = "xrLabel6";
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Gray;
            this.Line2.Location = new System.Drawing.Point(39, 42);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(653, 2);
            // 
            // Label13
            // 
            this.Label13.Font = new System.Drawing.Font("Arial", 8F);
            this.Label13.ForeColor = System.Drawing.Color.Black;
            this.Label13.Location = new System.Drawing.Point(598, 25);
            this.Label13.Name = "Label13";
            this.Label13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label13.ParentStyleUsing.UseBackColor = false;
            this.Label13.ParentStyleUsing.UseBorderColor = false;
            this.Label13.ParentStyleUsing.UseBorders = false;
            this.Label13.ParentStyleUsing.UseBorderWidth = false;
            this.Label13.ParentStyleUsing.UseFont = false;
            this.Label13.ParentStyleUsing.UseForeColor = false;
            this.Label13.Size = new System.Drawing.Size(94, 17);
            this.Label13.Text = "Betrag";
            this.Label13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label12
            // 
            this.Label12.Font = new System.Drawing.Font("Arial", 8F);
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(472, 25);
            this.Label12.Name = "Label12";
            this.Label12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label12.ParentStyleUsing.UseBackColor = false;
            this.Label12.ParentStyleUsing.UseBorderColor = false;
            this.Label12.ParentStyleUsing.UseBorders = false;
            this.Label12.ParentStyleUsing.UseBorderWidth = false;
            this.Label12.ParentStyleUsing.UseFont = false;
            this.Label12.ParentStyleUsing.UseForeColor = false;
            this.Label12.Size = new System.Drawing.Size(94, 17);
            this.Label12.Text = "Kostenstelle";
            // 
            // Label11
            // 
            this.Label11.Font = new System.Drawing.Font("Arial", 8F);
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(330, 25);
            this.Label11.Name = "Label11";
            this.Label11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label11.ParentStyleUsing.UseBackColor = false;
            this.Label11.ParentStyleUsing.UseBorderColor = false;
            this.Label11.ParentStyleUsing.UseBorders = false;
            this.Label11.ParentStyleUsing.UseBorderWidth = false;
            this.Label11.ParentStyleUsing.UseFont = false;
            this.Label11.ParentStyleUsing.UseForeColor = false;
            this.Label11.Size = new System.Drawing.Size(110, 17);
            this.Label11.Text = "NRM-Konto";
            // 
            // Label10
            // 
            this.Label10.Font = new System.Drawing.Font("Arial", 8F);
            this.Label10.ForeColor = System.Drawing.Color.Black;
            this.Label10.Location = new System.Drawing.Point(39, 25);
            this.Label10.Name = "Label10";
            this.Label10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label10.ParentStyleUsing.UseBackColor = false;
            this.Label10.ParentStyleUsing.UseBorderColor = false;
            this.Label10.ParentStyleUsing.UseBorders = false;
            this.Label10.ParentStyleUsing.UseBorderWidth = false;
            this.Label10.ParentStyleUsing.UseFont = false;
            this.Label10.ParentStyleUsing.UseForeColor = false;
            this.Label10.Size = new System.Drawing.Size(157, 17);
            this.Label10.Text = "Buchungstext intern";
            // 
            // xrLabel24
            // 
            this.xrLabel24.BackColor = System.Drawing.Color.PeachPuff;
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel24.ForeColor = System.Drawing.Color.Black;
            this.xrLabel24.Location = new System.Drawing.Point(175, 150);
            this.xrLabel24.Multiline = true;
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.ParentStyleUsing.UseBackColor = false;
            this.xrLabel24.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel24.ParentStyleUsing.UseBorders = false;
            this.xrLabel24.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel24.ParentStyleUsing.UseFont = false;
            this.xrLabel24.ParentStyleUsing.UseForeColor = false;
            this.xrLabel24.Size = new System.Drawing.Size(25, 19);
            this.xrLabel24.Text = "LU";
            // 
            // xrPageBreak1
            // 
            this.xrPageBreak1.Location = new System.Drawing.Point(0, 250);
            this.xrPageBreak1.Name = "xrPageBreak1";
            // 
            // xrLabel23
            // 
            this.xrLabel23.BackColor = System.Drawing.Color.PeachPuff;
            this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VerfallDatum", "{0:dd.MM.yyyy}")});
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel23.ForeColor = System.Drawing.Color.Black;
            this.xrLabel23.Location = new System.Drawing.Point(175, 208);
            this.xrLabel23.Multiline = true;
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.ParentStyleUsing.UseBackColor = false;
            this.xrLabel23.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel23.ParentStyleUsing.UseBorders = false;
            this.xrLabel23.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel23.ParentStyleUsing.UseFont = false;
            this.xrLabel23.ParentStyleUsing.UseForeColor = false;
            this.xrLabel23.Size = new System.Drawing.Size(374, 19);
            this.xrLabel23.Text = "xrLabel23";
            // 
            // xrLabel22
            // 
            this.xrLabel22.BackColor = System.Drawing.Color.PeachPuff;
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel22.ForeColor = System.Drawing.Color.Black;
            this.xrLabel22.Location = new System.Drawing.Point(42, 208);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.ParentStyleUsing.UseBackColor = false;
            this.xrLabel22.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel22.ParentStyleUsing.UseBorders = false;
            this.xrLabel22.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel22.ParentStyleUsing.UseFont = false;
            this.xrLabel22.ParentStyleUsing.UseForeColor = false;
            this.xrLabel22.Size = new System.Drawing.Size(133, 19);
            this.xrLabel22.Text = "Zahlbar per";
            // 
            // xrLabel21
            // 
            this.xrLabel21.BackColor = System.Drawing.Color.PeachPuff;
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel21.ForeColor = System.Drawing.Color.Black;
            this.xrLabel21.Location = new System.Drawing.Point(42, 192);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.ParentStyleUsing.UseBackColor = false;
            this.xrLabel21.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel21.ParentStyleUsing.UseBorders = false;
            this.xrLabel21.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel21.ParentStyleUsing.UseFont = false;
            this.xrLabel21.ParentStyleUsing.UseForeColor = false;
            this.xrLabel21.Size = new System.Drawing.Size(133, 19);
            this.xrLabel21.Text = "Kostenstelle";
            // 
            // xrLabel20
            // 
            this.xrLabel20.BackColor = System.Drawing.Color.PeachPuff;
            this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameFbKostenstelle", "")});
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel20.ForeColor = System.Drawing.Color.Black;
            this.xrLabel20.Location = new System.Drawing.Point(175, 192);
            this.xrLabel20.Multiline = true;
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.ParentStyleUsing.UseBackColor = false;
            this.xrLabel20.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel20.ParentStyleUsing.UseBorders = false;
            this.xrLabel20.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel20.ParentStyleUsing.UseFont = false;
            this.xrLabel20.ParentStyleUsing.UseForeColor = false;
            this.xrLabel20.Size = new System.Drawing.Size(374, 19);
            this.xrLabel20.Text = "xrLabel20";
            // 
            // xrLabel19
            // 
            this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BankName", "")});
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel19.ForeColor = System.Drawing.Color.Black;
            this.xrLabel19.Location = new System.Drawing.Point(175, 125);
            this.xrLabel19.Multiline = true;
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.ParentStyleUsing.UseBackColor = false;
            this.xrLabel19.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel19.ParentStyleUsing.UseBorders = false;
            this.xrLabel19.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel19.ParentStyleUsing.UseFont = false;
            this.xrLabel19.ParentStyleUsing.UseForeColor = false;
            this.xrLabel19.Size = new System.Drawing.Size(375, 17);
            this.xrLabel19.Text = "xrLabel19";
            // 
            // xrLabel18
            // 
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel18.ForeColor = System.Drawing.Color.Black;
            this.xrLabel18.Location = new System.Drawing.Point(42, 125);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.ParentStyleUsing.UseBackColor = false;
            this.xrLabel18.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel18.ParentStyleUsing.UseBorders = false;
            this.xrLabel18.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel18.ParentStyleUsing.UseFont = false;
            this.xrLabel18.ParentStyleUsing.UseForeColor = false;
            this.xrLabel18.Size = new System.Drawing.Size(125, 19);
            this.xrLabel18.Text = "Zahlungsweg";
            // 
            // xrLabel17
            // 
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel17.ForeColor = System.Drawing.Color.Black;
            this.xrLabel17.Location = new System.Drawing.Point(42, 67);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.ParentStyleUsing.UseBackColor = false;
            this.xrLabel17.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel17.ParentStyleUsing.UseBorders = false;
            this.xrLabel17.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel17.ParentStyleUsing.UseFont = false;
            this.xrLabel17.ParentStyleUsing.UseForeColor = false;
            this.xrLabel17.Size = new System.Drawing.Size(125, 16);
            this.xrLabel17.Text = "Kreditor";
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KreditorOrt", "")});
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel16.ForeColor = System.Drawing.Color.Black;
            this.xrLabel16.Location = new System.Drawing.Point(175, 100);
            this.xrLabel16.Multiline = true;
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.ParentStyleUsing.UseBackColor = false;
            this.xrLabel16.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel16.ParentStyleUsing.UseBorders = false;
            this.xrLabel16.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel16.ParentStyleUsing.UseFont = false;
            this.xrLabel16.ParentStyleUsing.UseForeColor = false;
            this.xrLabel16.Size = new System.Drawing.Size(375, 17);
            this.xrLabel16.Text = "xrLabel16";
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KreditorStrasse", "")});
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel15.ForeColor = System.Drawing.Color.Black;
            this.xrLabel15.Location = new System.Drawing.Point(175, 83);
            this.xrLabel15.Multiline = true;
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.ParentStyleUsing.UseBackColor = false;
            this.xrLabel15.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel15.ParentStyleUsing.UseBorders = false;
            this.xrLabel15.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel15.ParentStyleUsing.UseFont = false;
            this.xrLabel15.ParentStyleUsing.UseForeColor = false;
            this.xrLabel15.Size = new System.Drawing.Size(375, 17);
            this.xrLabel15.Text = "xrLabel15";
            // 
            // xrLabel14
            // 
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KreditorName", "")});
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.ForeColor = System.Drawing.Color.Black;
            this.xrLabel14.Location = new System.Drawing.Point(175, 67);
            this.xrLabel14.Multiline = true;
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.ParentStyleUsing.UseBackColor = false;
            this.xrLabel14.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel14.ParentStyleUsing.UseBorders = false;
            this.xrLabel14.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel14.ParentStyleUsing.UseFont = false;
            this.xrLabel14.ParentStyleUsing.UseForeColor = false;
            this.xrLabel14.Size = new System.Drawing.Size(375, 16);
            this.xrLabel14.Text = "xrLabel14";
            // 
            // xrLabel13
            // 
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.ForeColor = System.Drawing.Color.Black;
            this.xrLabel13.Location = new System.Drawing.Point(42, 50);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.ParentStyleUsing.UseBackColor = false;
            this.xrLabel13.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel13.ParentStyleUsing.UseBorders = false;
            this.xrLabel13.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel13.ParentStyleUsing.UseFont = false;
            this.xrLabel13.ParentStyleUsing.UseForeColor = false;
            this.xrLabel13.Size = new System.Drawing.Size(125, 17);
            this.xrLabel13.Text = "ESR";
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ESR", "")});
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel12.ForeColor = System.Drawing.Color.Black;
            this.xrLabel12.Location = new System.Drawing.Point(175, 50);
            this.xrLabel12.Multiline = true;
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.ParentStyleUsing.UseBackColor = false;
            this.xrLabel12.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel12.ParentStyleUsing.UseBorders = false;
            this.xrLabel12.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel12.ParentStyleUsing.UseFont = false;
            this.xrLabel12.ParentStyleUsing.UseForeColor = false;
            this.xrLabel12.Size = new System.Drawing.Size(375, 17);
            this.xrLabel12.Text = "xrLabel12";
            // 
            // xrLabel11
            // 
            this.xrLabel11.BackColor = System.Drawing.Color.PeachPuff;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.ForeColor = System.Drawing.Color.Black;
            this.xrLabel11.Location = new System.Drawing.Point(42, 150);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.ParentStyleUsing.UseBackColor = false;
            this.xrLabel11.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel11.ParentStyleUsing.UseBorders = false;
            this.xrLabel11.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel11.ParentStyleUsing.UseFont = false;
            this.xrLabel11.ParentStyleUsing.UseForeColor = false;
            this.xrLabel11.Size = new System.Drawing.Size(133, 19);
            this.xrLabel11.Text = "Buchungstext";
            // 
            // xrLabel10
            // 
            this.xrLabel10.BackColor = System.Drawing.Color.PeachPuff;
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bezugsmonat", "")});
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.ForeColor = System.Drawing.Color.Black;
            this.xrLabel10.Location = new System.Drawing.Point(200, 150);
            this.xrLabel10.Multiline = true;
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.ParentStyleUsing.UseBackColor = false;
            this.xrLabel10.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel10.ParentStyleUsing.UseBorders = false;
            this.xrLabel10.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel10.ParentStyleUsing.UseFont = false;
            this.xrLabel10.ParentStyleUsing.UseForeColor = false;
            this.xrLabel10.Size = new System.Drawing.Size(349, 19);
            this.xrLabel10.Text = "xrLabel10";
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KlientName", "")});
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.ForeColor = System.Drawing.Color.Black;
            this.xrLabel9.Location = new System.Drawing.Point(175, 25);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.ParentStyleUsing.UseBackColor = false;
            this.xrLabel9.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel9.ParentStyleUsing.UseBorders = false;
            this.xrLabel9.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.ParentStyleUsing.UseForeColor = false;
            this.xrLabel9.Size = new System.Drawing.Size(374, 17);
            this.xrLabel9.Text = "xrLabel9";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.ForeColor = System.Drawing.Color.Black;
            this.xrLabel8.Location = new System.Drawing.Point(42, 25);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseBackColor = false;
            this.xrLabel8.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel8.ParentStyleUsing.UseBorders = false;
            this.xrLabel8.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.ParentStyleUsing.UseForeColor = false;
            this.xrLabel8.Size = new System.Drawing.Size(125, 17);
            this.xrLabel8.Text = "KlientIn";
            // 
            // xrLabel4
            // 
            this.xrLabel4.BackColor = System.Drawing.Color.PeachPuff;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.Location = new System.Drawing.Point(42, 167);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.ParentStyleUsing.UseForeColor = false;
            this.xrLabel4.Size = new System.Drawing.Size(133, 25);
            this.xrLabel4.Text = "Teiltotal CHF";
            // 
            // xrLabel3
            // 
            this.xrLabel3.BackColor = System.Drawing.Color.PeachPuff;
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(175, 167);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(375, 25);
            xrSummary4.FormatString = "{0:0.00}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel3.Summary = xrSummary4;
            this.xrLabel3.Text = "Betrag";
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "IdFibuKostenart", "Kostenart {0} :")});
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel5.Location = new System.Drawing.Point(307, 8);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(180, 20);
            this.xrLabel5.Text = "xrLabel6";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameFbKostenart", "")});
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel2.Location = new System.Drawing.Point(400, 8);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(195, 20);
            this.xrLabel2.Text = "xrLabel7";
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Gray;
            this.xrLine1.Location = new System.Drawing.Point(98, 0);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(620, 4);
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.Location = new System.Drawing.Point(591, 8);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseBackColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.ParentStyleUsing.UseForeColor = false;
            this.xrLabel1.Size = new System.Drawing.Size(100, 19);
            xrSummary5.FormatString = "{0:0.00}";
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel1.Summary = xrSummary5;
            this.xrLabel1.Text = "Betrag";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail,
                        this.GroupHeader1,
                        this.GroupHeader4,
                        this.GroupFooter4,
                        this.GroupFooter1});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 39, 39);
            this.Name = "Report";
            this.PageHeight = 1178;
            this.PageWidth = 761;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  N'<?xml version="1.0" standalone="yes" ?>
<NewDataSet>
	<Table>
		<FieldName>label</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Budget ID:</DisplayText>
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
		<DisplayText>Budget ID</DisplayText>
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
		<FieldName>PrintAll</FieldName>
		<FieldCode>7</FieldCode>
		<DisplayText>Alle Belege ausdrucken</DisplayText>
		<TabPosition>3</TabPosition>
		<X>220</X>
		<Y>120</Y>
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
		<FieldName>label</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Nur Belege ab diesem Datum ausdrucken:</DisplayText>
		<TabPosition>4</TabPosition>
		<X>10</X>
		<Y>180</Y>
		<Width>210</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>DateGeneriert</FieldName>
		<FieldCode>5</FieldCode>
		<DisplayText>Nur Belege ab diesem Datum ausdrucken</DisplayText>
		<TabPosition>5</TabPosition>
		<X>220</X>
		<Y>180</Y>
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
		<FieldName>OnlyUnverbuchteBelege</FieldName>
		<FieldCode>7</FieldCode>
		<DisplayText>Nur unverbuchte Belege</DisplayText>
		<TabPosition>7</TabPosition>
		<X>220</X>
		<Y>240</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>true</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
</NewDataSet>' ,  N'declare  @BgBudgetID            int
declare  @PrintAll              bit
declare  @DateGeneriert         datetime
declare  @OnlyUnverbuchteBelege bit

set @BgBudgetID           = {BgBudgetID}
set @PrintAll             = {PrintAll}
set @DateGeneriert        = {DateGeneriert}
set @OnlyUnverbuchteBelege= {OnlyUnverbuchteBelege}

declare  @BudgetMonat           int
declare  @BudgetJahr            int
set @BudgetMonat          = (SELECT Monat FROM BgBudget WHERE BgBudgetID = @BgBudgetID)
set @BudgetJahr           = (SELECT Jahr  FROM BgBudget WHERE BgBudgetID = @BgBudgetID)


  SELECT
    Bezugsmonat = dbo.fnXMonat(@BudgetMonat) + '' '' + CONVERT(VARCHAR(4), @BudgetJahr),
    KlientName = (SELECT PRS.Name + '', '' + PRS.Vorname 
                  FROM BaPerson PRS 
                    INNER JOIN FaLeistung LEI ON LEI.BaPersonID = PRS.BaPersonID 
                    INNER JOIN BgFinanzplan FPL ON FPL.FaLeistungID = LEI.FaLeistungID 
                    INNER JOIN BgBudget BDG ON BDG.BgFinanzplanID = FPL.BgFinanzplanID
                  WHERE BDG.BgBudgetID = @BgBudgetID),
    BelegBezeichnung = ''Beleg # '' + CAST(FBL.KbBuchungID AS VARCHAR) + '', '' +
      dbo.fnLOVText(''KbBuchungsStatus'',FBL.KbBuchungStatusCode),
    IdGroup = 1,
    NameGroup = CONVERT(VARCHAR(20),''Budgetpositionen''),
    FBL.KbBuchungID,
    FKA.KbBuchungKostenartID,
    FKS.KbKostenstelleID,
    GeneriertAm = FBL.ErstelltDatum,
    VerbuchtAm = FBL.BelegDatum,
    Buchungsdatum = FBL.BelegDatum,
    VerfallDatum = FBL.ValutaDatum,
    Buchungstext = FBL.Text,
    Extern = FBL.Extern,--IsNull(PR2.Name, PRS.Name) + Coalesce('' ''+PR2.Vorname, '' ''+PRS.Vorname, ''''),
    ESR = FBL.ReferenzNummer,
    Belegnummer = FBL.BelegNr,
    Intern = FKA.Buchungstext,
    InternBudgetDatum = dbo.fnXMonat(@BudgetMonat) + '' '' + CONVERT(varchar, @BudgetJahr),
    FKA.Betrag,
    NameBelegStatus = dbo.fnLOVText(''KbBuchungStatus'', FBL.KbBuchungStatusCode),
    IdFibuKostenart = KOA.KontoNr,
    NameFbKostenart = KOA.Name,
    NameFbKostenstelle = 
     CASE 
      WHEN ''530'' IN (  
        SELECT KontoNr
        FROM BgKostenart
        WHERE BgKostenartID = FKA.BgKostenartID          
        )
      THEN
        ''520.366.01''
      ELSE 
        KST.Nr
     END,
    NrmKonto = LVN.Value1,
    NameInhaber = KST.Name, --KST.NameInhaber AS NameInhaber,
    KreditorName = FBL.BeguenstigtName,
    KreditorStrasse = FBL.BeguenstigtStrasse,
    KreditorOrt = ISNULL(FBL.BeguenstigtPLZ+'' '','''') +ISNULL(FBL.BeguenstigtOrt,''''),
    ISNULL(FBL.BankName+'', '','''') +
    CASE
      WHEN LEN(ISNULL(FBL.BankKontoNr, '''')) > 0
      THEN ''Kto: ''+FBL.BankKontoNr+'' '' 
      WHEN LEN(ISNULL(FBL.IBAN, '''')) > 0
      THEN ''IBAN: ''+FBL.IBAN+'' ''
      ELSE ''''
    END +
    CASE
      WHEN LEN(ISNULL(FBL.PCKontoNr,'''')) > 0
      THEN ''PC: ''+dbo.fnTnToPc(FBL.PCKontoNr) ELSE ''''
    END AS BankName 
  FROM KbBuchung FBL
    LEFT JOIN KbBuchungKostenart FKA ON FBL.KbBuchungID          = FKA.KbBuchungID
    LEFT JOIN KbKostenstelle     FKS ON FKA.KbKostenstelleID = FKS.KbKostenstelleID
    LEFT JOIN BgKostenart        KOA ON KOA.BgKostenartID      = FKA.BgKostenartID
    LEFT JOIN KbKostenstelle     KST ON KST.KbKostenstelleID   = FKS.KbKostenstelleID
    LEFT JOIN XLOVCode           LVN ON LVN.Code = FKA.NrmKontoCode AND LVN.LOVName = ''NrmKonto''
    LEFT JOIN BaPerson           PRS ON PRS.BaPersonID = FKA.BaPersonID
    LEFT JOIN KbKostenstelle_BaPerson KSP ON KSP.KbKostenstelleID = KST.KbKostenstelleID 
                          AND KSP.BaPersonID = PRS.BaPersonID
                          AND (KSP.DatumBis IS NULL OR GetDate() BETWEEN KSP.DatumVon AND KSP.DatumBis)
    LEFT JOIN BaPerson           PR2 ON PR2.BaPersonID = KSP.BaPersonID
 WHERE FBL.BgBudgetID = @BgBudgetID
    AND FBL.KbAuszahlungsartCode IN (102, 104)   -- Papierverfügung zur Buchhaltung
    AND FBL.KbBuchungStatusCode in (1,2) -- vorbereitet, freigegeben
    AND FBL.KbBuchungTypCode=1
    AND (
      (@OnlyUnverbuchteBelege=1 AND FBL.KbBuchungStatusCode = 2) OR
      (@OnlyUnverbuchteBelege=0)
    )
    AND (
      (@PrintAll = 0 AND (@DateGeneriert <= FBL.ErstelltDatum) ) OR
      (@PrintAll = 1)
    )


  ORDER BY IdGroup, FBL.KbBuchungID, FKA.KbBuchungKostenartID' ,  null ,  N'ShPapierverfuegungBuchhaltung' ,  null );


INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShPapierverfuegungBuchhaltung_Personen' ,  N'Personen' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\KiSS\4.2.33\KiSS4.DB.dll" />
///     <Reference Path="C:\KiSS\4.2.33\log4net.dll" />
///     <Reference Path="C:\KiSS\4.2.33\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRCheckBox CheckBox1;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtNameKstKvg;
        private DevExpress.XtraReports.UI.XRLabel txtNameKst;
        private DevExpress.XtraReports.UI.XRLabel txtNummerNrmKonto;
        private DevExpress.XtraReports.UI.XRLabel txtHeimatort;
        private DevExpress.XtraReports.UI.XRLabel txtAHVNummer;
        private DevExpress.XtraReports.UI.XRLabel txtGeburtsdatum;
        private DevExpress.XtraReports.UI.XRLabel txtNameKomplett;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel Label9;
        private DevExpress.XtraReports.UI.XRLabel Label8;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.XRLabel Label5;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.XRLabel Label3;
        private DevExpress.XtraReports.UI.XRLabel Label2;
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
                        "AAAAYQYZGVjbGFyZSBAQmdCdWRnZXRJRCBpbnQNCmRlY2xhcmUgQFByaW50QWxsIGJpdA0KZGVjbGFyZ" +
                        "SBARGF0ZUdlbmVyaWVydCBkYXRldGltZQ0KZGVjbGFyZSBAT25seVVudmVyYnVjaHRlQmVsZWdlIGJpd" +
                        "A0KDQpzZXQgQEJnQnVkZ2V0SUQgICAgICAgICAgICA9IG51bGwNCnNldCBAUHJpbnRBbGwgICAgICAgI" +
                        "CAgICAgID0gbnVsbA0Kc2V0IEBEYXRlR2VuZXJpZXJ0ICAgICAgICAgPSBudWxsDQpzZXQgQE9ubHlVb" +
                        "nZlcmJ1Y2h0ZUJlbGVnZSA9IG51bGwNCg0KU0VMRUNUDQogIE5hbWUgPSBQUlMuTmFtZSArIGlzTnVsb" +
                        "CgnLCAnICsgUFJTLlZvcm5hbWUsJycpLA0KICBQUlMuR2VidXJ0c2RhdHVtLA0KICBQUlMuVmVyc2lja" +
                        "GVydGVubnVtbWVyLA0KICBIRUkuTmFtZSArIElzTnVsbCgnICcgKyBIRUkuS2FudG9uLCAnJykgQVMgS" +
                        "GVpbWF0b3J0LA0KICBTUFAuSXN0VW50ZXJzdHVldHp0LA0KICBOdW1tZXJOcm1Lb250byA9IExWTi5WY" +
                        "Wx1ZTEsDQogIE5hbWVLc3QgPSBLU1QuTnIsIC0tZGJvLmZuS2JHZXRLb3N0ZW5zdGVsbGUoUFJTLkJhU" +
                        "GVyc29uSUQpLA0KICBOYW1lS3N0S3ZnID0gDQogICAgQ0FTRSANCiAgICAgIFdIRU4gJzUzMCcgSU4gK" +
                        "CAgDQogICAgICAgIFNFTEVDVCBFeHRGaWJ1S29zdGVuYXJ0TnINCiAgICAgICAgRlJPTSBCZ0tvc3Rlb" +
                        "mFydA0KICAgICAgICBXSEVSRSBCZ0tvc3RlbmFydElEIElOICgNCiAgICAgICAgICBTRUxFQ1QgQmdLb" +
                        "3N0ZW5hcnRJRA0KICAgICAgICAgIEZST00gQmdQb3NpdGlvbnNhcnQNCiAgICAgICAgICBXSEVSRSBCZ" +
                        "1Bvc2l0aW9uc2FydElEIElOICgNCiAgICAgICAgICAgIFNFTEVDVCBCZ1Bvc2l0aW9uc2FydElEDQogI" +
                        "CAgICAgICAgICBGUk9NIEJnUG9zaXRpb24NCiAgICAgICAgICAgIFdIRVJFIEJnQnVkZ2V0SUQgPSBCQ" +
                        "kcuQmdCdWRnZXRJRA0KICAgICAgICAgICAgKQ0KICAgICAgICAgICkNCiAgICAgICAgKQ0KICAgICAgV" +
                        "EhFTg0KICAgICAgICAnNTIwLjM2Ni4wMScNCiAgICAgIEVMU0UgDQogICAgICAgIGRiby5mbktiR2V0S" +
                        "29zdGVuc3RlbGxlKFBSUy5CYVBlcnNvbklEKQ0KICAgIEVORA0KDQpGUk9NIEJnQnVkZ2V0ICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgQkJHDQogIElOTkVSIEpPSU4gQmdGaW5hbnpwbGFuICAgICAgICAgICAgU" +
                        "0ZQIE9OIFNGUC5CZ0ZpbmFuenBsYW5JRCA9IEJCRy5CZ0ZpbmFuenBsYW5JRA0KICBJTk5FUiBKT0lOI" +
                        "EJnRmluYW56cGxhbl9CYVBlcnNvbiAgIFNQUCBPTiBTUFAuQmdGaW5hbnpwbGFuSUQgPSBTRlAuQmdGa" +
                        "W5hbnpwbGFuSUQNCiAgSU5ORVIgSk9JTiBCYVBlcnNvbiAgICAgICAgICAgICAgICBQUlMgT04gUFJTL" +
                        "kJhUGVyc29uSWQgPSBTUFAuQmFQZXJzb25JZA0KICBMRUZUICBKT0lOIEJhV1ZDb2RlICAgICAgICAgI" +
                        "CAgICAgIEJXViBPTiBCV1YuQmFQZXJzb25JRCA9IFBSUy5CYVBlcnNvbklEDQogICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIENPTlZFUlQoREFURVRJTUUsICcwMS4nICsgQ09OV" +
                        "kVSVChWQVJDSEFSLCBCQkcuTW9uYXQpICsgJy4nICsgQ09OVkVSVChWQVJDSEFSLCBCQkcuSmFociksI" +
                        "DEwNCkgQkVUV0VFTiBCV1YuRGF0dW1Wb24gQU5EIElTTlVMTChCV1YuRGF0dW1CaXMsIENPTlZFUlQoR" +
                        "EFURVRJTUUsICcwMS4wMS45OTk5JywgMTA0KSkNCiAgTEVGVCAgSk9JTiBCYUdlbWVpbmRlICAgICAgI" +
                        "CAgICAgICBIRUkgT04gSEVJLkJhR2VtZWluZGVJRCA9IFBSUy5IZWltYXRnZW1laW5kZUJhR2VtZWluZ" +
                        "GVJRA0KICBMRUZUICBKT0lOIFhMT1ZDb2RlICAgICAgICAgICAgICAgIExWTiBPTiBMVk4uQ29kZSA9I" +
                        "EJXVi5CYVdWQ29kZSBBTkQgTFZOLkxPVk5hbWUgPSAnQmFXVkNvZGUnDQogIExFRlQgIEpPSU4gS2JLb" +
                        "3N0ZW5zdGVsbGVfQmFQZXJzb24gS1NQIE9OIEtTUC5CYVBlcnNvbklEID0gUFJTLkJhUGVyc29uSUQNC" +
                        "iAgTEVGVCAgSk9JTiBLYktvc3RlbnN0ZWxsZSAgICAgICAgICBLU1QgT04gS1NULktiS29zdGVuc3Rlb" +
                        "GxlSUQgPSBLU1AuS2JLb3N0ZW5zdGVsbGVJRA0KV0hFUkUgQkJHLkJnQnVkZ2V0SUQ9QEJnQnVkZ2V0S" +
                        "UQNCiAgQU5EIChTUFAuSXN0VW50ZXJzdHVldHp0PTEpDQoNClVOSU9OIEFMTA0KDQotLSBub3cgYWxsI" +
                        "HRoZSBwZXJzb25zIHdobyBhcmUgbm90IHVudGVyc3R1ZXR6dA0KU0VMRUNUDQogIE5hbWUgPSBQUlMuT" +
                        "mFtZSArIGlzTnVsbCgnLCAnICsgUFJTLlZvcm5hbWUsJycpLA0KICBQUlMuR2VidXJ0c2RhdHVtLA0KI" +
                        "CBQUlMuVmVyc2ljaGVydGVubnVtbWVyLA0KICBIRUkuTmFtZSArIElzTnVsbCgnICcgKyBIRUkuS2Fud" +
                        "G9uLCAnJykgQVMgSGVpbWF0b3J0LA0KICBTUFAuSXN0VW50ZXJzdHVldHp0LA0KICBOdW1tZXJOcm1Lb" +
                        "250byA9IE5VTEwsDQogIE5hbWVLc3QgPSBLU1QuTnIsLS1kYm8uZm5LYkdldEtvc3RlbnN0ZWxsZShQU" +
                        "lMuQmFQZXJzb25JRCksDQogIE5hbWVLc3RLdmcgPSBOVUxMDQoNCkZST00gQmdCdWRnZXQgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICBCQkcNCiAgSU5ORVIgSk9JTiBCZ0ZpbmFuenBsYW4gICAgICAgICAgICBTR" +
                        "lAgT04gU0ZQLkJnRmluYW56cGxhbklEICA9IEJCRy5CZ0ZpbmFuenBsYW5JRA0KICBJTk5FUiBKT0lOI" +
                        "EJnRmluYW56cGxhbl9CYVBlcnNvbiAgIFNQUCBPTiBTUFAuQmdGaW5hbnpwbGFuSUQgID0gU0ZQLkJnR" +
                        "mluYW56cGxhbklEDQogIElOTkVSIEpPSU4gQmFQZXJzb24gICAgICAgICAgICAgICAgUFJTIE9OIFBSU" +
                        "y5CYVBlcnNvbklkICAgICAgPSBTUFAuQmFQZXJzb25JZA0KICBMRUZUICBKT0lOIEJhR2VtZWluZGUgI" +
                        "CAgICAgICAgICAgIEhFSSBPTiBIRUkuQmFHZW1laW5kZUlEICAgID0gUFJTLkhlaW1hdGdlbWVpbmRlQ" +
                        "mFHZW1laW5kZUlEDQogIExFRlQgIEpPSU4gS2JLb3N0ZW5zdGVsbGVfQmFQZXJzb24gS1NQIE9OIEtTU" +
                        "C5CYVBlcnNvbklEID0gUFJTLkJhUGVyc29uSUQNCiAgTEVGVCAgSk9JTiBLYktvc3RlbnN0ZWxsZSAgI" +
                        "CAgICAgICBLU1QgT04gS1NULktiS29zdGVuc3RlbGxlSUQgPSBLU1AuS2JLb3N0ZW5zdGVsbGVJRA0KV" +
                        "0hFUkUgQkJHLkJnQnVkZ2V0SUQgPSBAQmdCdWRnZXRJRA0KICBBTkQgU1BQLklzdFVudGVyc3R1ZXR6d" +
                        "CA9IDANCg0KT1JERVIgQlkgTmFtZQ==";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.CheckBox1 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.txtNameKstKvg = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNameKst = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNummerNrmKonto = new DevExpress.XtraReports.UI.XRLabel();
            this.txtHeimatort = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAHVNummer = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGeburtsdatum = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNameKomplett = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.Label9 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.CheckBox1,
                        this.txtNameKstKvg,
                        this.txtNameKst,
                        this.txtNummerNrmKonto,
                        this.txtHeimatort,
                        this.txtAHVNummer,
                        this.txtGeburtsdatum,
                        this.txtNameKomplett});
            this.Detail.Height = 17;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBackColor = false;
            this.Detail.ParentStyleUsing.UseBorderColor = false;
            this.Detail.ParentStyleUsing.UseBorders = false;
            this.Detail.ParentStyleUsing.UseBorderWidth = false;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Line1,
                        this.Label9,
                        this.Label8,
                        this.Label6,
                        this.Label5,
                        this.Label4,
                        this.Label3,
                        this.Label2,
                        this.Label1});
            this.GroupHeader1.Height = 19;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            // 
            // CheckBox1
            // 
            this.CheckBox1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("CheckState", this.sqlQuery1, "IstUnterstuetzt", "")});
            this.CheckBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.CheckBox1.ForeColor = System.Drawing.Color.Black;
            this.CheckBox1.Location = new System.Drawing.Point(470, 0);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.ParentStyleUsing.UseBackColor = false;
            this.CheckBox1.ParentStyleUsing.UseBorderColor = false;
            this.CheckBox1.ParentStyleUsing.UseBorders = false;
            this.CheckBox1.ParentStyleUsing.UseBorderWidth = false;
            this.CheckBox1.ParentStyleUsing.UseFont = false;
            this.CheckBox1.ParentStyleUsing.UseForeColor = false;
            this.CheckBox1.Size = new System.Drawing.Size(16, 17);
            this.CheckBox1.Text = "CheckBox1";
            this.CheckBox1.WordWrap = false;
            // 
            // txtNameKstKvg
            // 
            this.txtNameKstKvg.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameKstKvg", "")});
            this.txtNameKstKvg.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.txtNameKstKvg.ForeColor = System.Drawing.Color.Black;
            this.txtNameKstKvg.Location = new System.Drawing.Point(657, 0);
            this.txtNameKstKvg.Name = "txtNameKstKvg";
            this.txtNameKstKvg.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNameKstKvg.ParentStyleUsing.UseBackColor = false;
            this.txtNameKstKvg.ParentStyleUsing.UseBorderColor = false;
            this.txtNameKstKvg.ParentStyleUsing.UseBorders = false;
            this.txtNameKstKvg.ParentStyleUsing.UseBorderWidth = false;
            this.txtNameKstKvg.ParentStyleUsing.UseFont = false;
            this.txtNameKstKvg.ParentStyleUsing.UseForeColor = false;
            this.txtNameKstKvg.Size = new System.Drawing.Size(86, 17);
            this.txtNameKstKvg.Text = "NameKstKvg";
            this.txtNameKstKvg.WordWrap = false;
            // 
            // txtNameKst
            // 
            this.txtNameKst.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameKst", "")});
            this.txtNameKst.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.txtNameKst.ForeColor = System.Drawing.Color.Black;
            this.txtNameKst.Location = new System.Drawing.Point(566, 0);
            this.txtNameKst.Name = "txtNameKst";
            this.txtNameKst.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNameKst.ParentStyleUsing.UseBackColor = false;
            this.txtNameKst.ParentStyleUsing.UseBorderColor = false;
            this.txtNameKst.ParentStyleUsing.UseBorders = false;
            this.txtNameKst.ParentStyleUsing.UseBorderWidth = false;
            this.txtNameKst.ParentStyleUsing.UseFont = false;
            this.txtNameKst.ParentStyleUsing.UseForeColor = false;
            this.txtNameKst.Size = new System.Drawing.Size(90, 17);
            this.txtNameKst.Text = "NameKst";
            this.txtNameKst.WordWrap = false;
            // 
            // txtNummerNrmKonto
            // 
            this.txtNummerNrmKonto.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NummerNrmKonto", "")});
            this.txtNummerNrmKonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.txtNummerNrmKonto.ForeColor = System.Drawing.Color.Black;
            this.txtNummerNrmKonto.Location = new System.Drawing.Point(492, 0);
            this.txtNummerNrmKonto.Multiline = true;
            this.txtNummerNrmKonto.Name = "txtNummerNrmKonto";
            this.txtNummerNrmKonto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNummerNrmKonto.ParentStyleUsing.UseBackColor = false;
            this.txtNummerNrmKonto.ParentStyleUsing.UseBorderColor = false;
            this.txtNummerNrmKonto.ParentStyleUsing.UseBorders = false;
            this.txtNummerNrmKonto.ParentStyleUsing.UseBorderWidth = false;
            this.txtNummerNrmKonto.ParentStyleUsing.UseFont = false;
            this.txtNummerNrmKonto.ParentStyleUsing.UseForeColor = false;
            this.txtNummerNrmKonto.Size = new System.Drawing.Size(74, 17);
            this.txtNummerNrmKonto.Text = "NummerNrmKonto";
            // 
            // txtHeimatort
            // 
            this.txtHeimatort.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Heimatort", "")});
            this.txtHeimatort.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.txtHeimatort.ForeColor = System.Drawing.Color.Black;
            this.txtHeimatort.Location = new System.Drawing.Point(397, 0);
            this.txtHeimatort.Name = "txtHeimatort";
            this.txtHeimatort.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtHeimatort.ParentStyleUsing.UseBackColor = false;
            this.txtHeimatort.ParentStyleUsing.UseBorderColor = false;
            this.txtHeimatort.ParentStyleUsing.UseBorders = false;
            this.txtHeimatort.ParentStyleUsing.UseBorderWidth = false;
            this.txtHeimatort.ParentStyleUsing.UseFont = false;
            this.txtHeimatort.ParentStyleUsing.UseForeColor = false;
            this.txtHeimatort.Size = new System.Drawing.Size(70, 17);
            this.txtHeimatort.Text = "Heimatort";
            this.txtHeimatort.WordWrap = false;
            // 
            // txtAHVNummer
            // 
            this.txtAHVNummer.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Versichertennummer", "")});
            this.txtAHVNummer.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.txtAHVNummer.ForeColor = System.Drawing.Color.Black;
            this.txtAHVNummer.Location = new System.Drawing.Point(283, 0);
            this.txtAHVNummer.Multiline = true;
            this.txtAHVNummer.Name = "txtAHVNummer";
            this.txtAHVNummer.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtAHVNummer.ParentStyleUsing.UseBackColor = false;
            this.txtAHVNummer.ParentStyleUsing.UseBorderColor = false;
            this.txtAHVNummer.ParentStyleUsing.UseBorders = false;
            this.txtAHVNummer.ParentStyleUsing.UseBorderWidth = false;
            this.txtAHVNummer.ParentStyleUsing.UseFont = false;
            this.txtAHVNummer.ParentStyleUsing.UseForeColor = false;
            this.txtAHVNummer.Size = new System.Drawing.Size(117, 17);
            this.txtAHVNummer.Text = "txtAHVNummer";
            // 
            // txtGeburtsdatum
            // 
            this.txtGeburtsdatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Geburtsdatum", "{0:dd.MM.yyyy}")});
            this.txtGeburtsdatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.txtGeburtsdatum.ForeColor = System.Drawing.Color.Black;
            this.txtGeburtsdatum.Location = new System.Drawing.Point(208, 0);
            this.txtGeburtsdatum.Multiline = true;
            this.txtGeburtsdatum.Name = "txtGeburtsdatum";
            this.txtGeburtsdatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGeburtsdatum.ParentStyleUsing.UseBackColor = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorderColor = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorders = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseFont = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseForeColor = false;
            this.txtGeburtsdatum.Size = new System.Drawing.Size(77, 17);
            xrSummary1.FormatString = "{0:dd.MM.yyyy}";
            this.txtGeburtsdatum.Summary = xrSummary1;
            this.txtGeburtsdatum.Text = "Geburtsdatum";
            this.txtGeburtsdatum.WordWrap = false;
            // 
            // txtNameKomplett
            // 
            this.txtNameKomplett.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.txtNameKomplett.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.txtNameKomplett.ForeColor = System.Drawing.Color.Black;
            this.txtNameKomplett.Location = new System.Drawing.Point(7, 0);
            this.txtNameKomplett.Name = "txtNameKomplett";
            this.txtNameKomplett.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNameKomplett.ParentStyleUsing.UseBackColor = false;
            this.txtNameKomplett.ParentStyleUsing.UseBorderColor = false;
            this.txtNameKomplett.ParentStyleUsing.UseBorders = false;
            this.txtNameKomplett.ParentStyleUsing.UseBorderWidth = false;
            this.txtNameKomplett.ParentStyleUsing.UseFont = false;
            this.txtNameKomplett.ParentStyleUsing.UseForeColor = false;
            this.txtNameKomplett.Size = new System.Drawing.Size(200, 17);
            this.txtNameKomplett.Text = "Name, Vorname";
            this.txtNameKomplett.WordWrap = false;
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Gray;
            this.Line1.Location = new System.Drawing.Point(0, 17);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(748, 2);
            // 
            // Label9
            // 
            this.Label9.Font = new System.Drawing.Font("Arial Narrow", 8F);
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(657, 0);
            this.Label9.Name = "Label9";
            this.Label9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label9.ParentStyleUsing.UseBackColor = false;
            this.Label9.ParentStyleUsing.UseBorderColor = false;
            this.Label9.ParentStyleUsing.UseBorders = false;
            this.Label9.ParentStyleUsing.UseBorderWidth = false;
            this.Label9.ParentStyleUsing.UseFont = false;
            this.Label9.ParentStyleUsing.UseForeColor = false;
            this.Label9.Size = new System.Drawing.Size(84, 19);
            this.Label9.Text = "KST KVG";
            // 
            // Label8
            // 
            this.Label8.Font = new System.Drawing.Font("Arial Narrow", 8F);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(566, 0);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(90, 19);
            this.Label8.Text = "KST Soz.hilfe";
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial Narrow", 8F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(492, 0);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(74, 19);
            this.Label6.Text = "NRM-Kto.";
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial Narrow", 8F);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(468, 0);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(23, 19);
            this.Label5.Text = "UE";
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial Narrow", 8F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(398, 0);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(70, 19);
            this.Label4.Text = "Heimatort";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Arial Narrow", 8F);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(283, 0);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(117, 19);
            this.Label3.Text = "Vers.-Nummer";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial Narrow", 8F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(208, 0);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(62, 19);
            this.Label2.Text = "Geb.datum";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial Narrow", 8F);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(7, 0);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(69, 19);
            this.Label1.Text = "Name";
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail,
                        this.GroupHeader1});
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
}' ,  N'<?xml version="1.0" standalone="yes" ?>
<NewDataSet>
	<Table>
		<FieldName>label</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Budget ID:</DisplayText>
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
		<DisplayText>Budget ID</DisplayText>
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
		<FieldName>PrintAll</FieldName>
		<FieldCode>7</FieldCode>
		<DisplayText>Alle Belege ausdrucken</DisplayText>
		<TabPosition>3</TabPosition>
		<X>220</X>
		<Y>120</Y>
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
		<FieldName>label</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Nur Belege ab diesem Datum ausdrucken:</DisplayText>
		<TabPosition>4</TabPosition>
		<X>10</X>
		<Y>180</Y>
		<Width>210</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>DateGeneriert</FieldName>
		<FieldCode>5</FieldCode>
		<DisplayText>Nur Belege ab diesem Datum ausdrucken</DisplayText>
		<TabPosition>5</TabPosition>
		<X>220</X>
		<Y>180</Y>
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
		<FieldName>OnlyUnverbuchteBelege</FieldName>
		<FieldCode>7</FieldCode>
		<DisplayText>Nur unverbuchte Belege</DisplayText>
		<TabPosition>7</TabPosition>
		<X>220</X>
		<Y>240</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>true</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
</NewDataSet>' ,  N'declare @BgBudgetID int
declare @PrintAll bit
declare @DateGeneriert datetime
declare @OnlyUnverbuchteBelege bit

set @BgBudgetID            = {BgBudgetID}
set @PrintAll              = {PrintAll}
set @DateGeneriert         = {DateGeneriert}
set @OnlyUnverbuchteBelege = {OnlyUnverbuchteBelege}

SELECT
  Name = PRS.Name + isNull('', '' + PRS.Vorname,''''),
  PRS.Geburtsdatum,
  PRS.Versichertennummer,
  HEI.Name + IsNull('' '' + HEI.Kanton, '''') AS Heimatort,
  SPP.IstUnterstuetzt,
  NameKstKvg = KST.Nr,
  NameKst = KST.Nr, --dbo.fnKbGetKostenstelle(PRS.BaPersonID),
  NummerNrmKonto = 
    CASE 
      WHEN ''530'' IN (  
        SELECT KontoNr
        FROM BgKostenart
        WHERE BgKostenartID IN (
          SELECT BgKostenartID
          FROM BgPositionsart
          WHERE BgPositionsartID IN (
            SELECT BgPositionsartID
            FROM BgPosition
            WHERE BgBudgetID = BBG.BgBudgetID
            )
          )
        )
      THEN
        ''520.366.01''
      ELSE 
        dbo.fnKbGetKostenstelle(PRS.BaPersonID)
    END

FROM BgBudget                        BBG
  INNER JOIN BgFinanzplan            SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
  INNER JOIN BgFinanzplan_BaPerson   SPP ON SPP.BgFinanzplanID = SFP.BgFinanzplanID
  INNER JOIN BaPerson                PRS ON PRS.BaPersonId = SPP.BaPersonId
  LEFT  JOIN BaWVCode                BWV ON BWV.BaPersonID = PRS.BaPersonID
                                        AND CONVERT(DATETIME, ''01.'' + CONVERT(VARCHAR, BBG.Monat) + ''.'' + CONVERT(VARCHAR, BBG.Jahr), 104) BETWEEN BWV.DatumVon AND ISNULL(BWV.DatumBis, CONVERT(DATETIME, ''01.01.9999'', 104))
  LEFT  JOIN BaGemeinde              HEI ON HEI.BaGemeindeID = PRS.HeimatgemeindeBaGemeindeID
  LEFT  JOIN XLOVCode                LVN ON LVN.Code = BWV.BaWVCode AND LVN.LOVName = ''BaWVCode''
  LEFT  JOIN (SELECT KST1.Nr, KSP1.BaPersonID 
              FROM KbKostenstelle_BaPerson KSP1
                INNER JOIN KbKostenstelle  KST1 ON KST1.KbKostenstelleID = KSP1.KbKostenstelleID AND KST1.Aktiv = 1
              WHERE (KSP1.DatumVon <= @DateGeneriert AND  (KSP1.DatumBis IS NULL OR KSP1.DatumBis >= @DateGeneriert))) KST ON KST.BaPersonID = PRS.BaPersonID
WHERE BBG.BgBudgetID=@BgBudgetID
  AND (SPP.IstUnterstuetzt=1)

UNION ALL

-- now all the persons who are not unterstuetzt
SELECT
  Name = PRS.Name + isNull('', '' + PRS.Vorname,''''),
  PRS.Geburtsdatum,
  PRS.Versichertennummer,
  HEI.Name + IsNull('' '' + HEI.Kanton, '''') AS Heimatort,
  SPP.IstUnterstuetzt,
  NummerNrmKonto = NULL,
  NameKst = KST.Nr,--dbo.fnKbGetKostenstelle(PRS.BaPersonID),
  NameKstKvg = NULL

FROM BgBudget                        BBG
  INNER JOIN BgFinanzplan            SFP ON SFP.BgFinanzplanID  = BBG.BgFinanzplanID
  INNER JOIN BgFinanzplan_BaPerson   SPP ON SPP.BgFinanzplanID  = SFP.BgFinanzplanID
  INNER JOIN BaPerson                PRS ON PRS.BaPersonId      = SPP.BaPersonId
  LEFT  JOIN BaGemeinde              HEI ON HEI.BaGemeindeID    = PRS.HeimatgemeindeBaGemeindeID
  LEFT  JOIN (SELECT KST1.Nr, KSP1.BaPersonID 
              FROM KbKostenstelle_BaPerson KSP1
                INNER JOIN KbKostenstelle  KST1 ON KST1.KbKostenstelleID = KSP1.KbKostenstelleID AND KST1.Aktiv = 1
              WHERE (KSP1.DatumVon <= @DateGeneriert AND  (KSP1.DatumBis IS NULL OR KSP1.DatumBis >= @DateGeneriert))) KST ON KST.BaPersonID = PRS.BaPersonID
WHERE BBG.BgBudgetID = @BgBudgetID
  AND SPP.IstUnterstuetzt = 0

ORDER BY Name' ,  null ,  N'ShPapierverfuegungBuchhaltung' ,  null );


