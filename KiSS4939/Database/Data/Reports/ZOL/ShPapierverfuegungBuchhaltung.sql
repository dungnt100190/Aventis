-- Insert Script for ShPapierverfuegungBuchhaltung
-- MD5:0X8BB00D6D615479C1FC0E4BF8D9137FF7_0X63995A62562BC501B7F7EFBBF649957E_0X3A642CDADCA5C21D669F9A705E843307
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'ShPapierverfuegungBuchhaltung') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('ShPapierverfuegungBuchhaltung', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'ShPapierverfuegungBuchhaltung';
UPDATE QRY
SET QueryName =  N'ShPapierverfuegungBuchhaltung' , UserText =  N'SH - Papierverfügung an die Buchhaltung' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>C:\Program Files (x86)\Born Informatik AG\KiSS4\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>de-DE</Localization>
///   <References>
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Drawing\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Configuration\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Data.SqlXml\v4.0_4.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Security\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\DevExpress.Utils.v6.2.dll" />
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
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\DevExpress.Data.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\KiSS4.DB.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\Kiss.Interfaces.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\Microsoft.Practices.Unity.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\FluentValidation.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\log4net.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\SharpLibrary.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.Subreport ShPapierverfuegungBuchhaltung_Belege;
        private DevExpress.XtraReports.UI.Subreport ShPapierverfuegungBuchhaltung_Personen;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
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
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAACAAAAAAAAAFBBRFBBRFCTNJGGE" +
                        "7ROpAAAAABLAAAARgEAAEZwAGkATwByAGcATwByAHQARABhAHQAdQBtAC4AUwBjAHIAaQBwAHQAcwAuA" +
                        "E8AbgBCAGUAZgBvAHIAZQBQAHIAaQBuAHQAAAAAADJzAHEAbABRAHUAZQByAHkAMQAuAFMAZQBsAGUAY" +
                        "wB0AFMAdABhAHQAZQBtAGUAbgB0ANIAAAABzwFwcml2YXRlIHZvaWQgT25CZWZvcmVQcmludChvYmplY" +
                        "3Qgc2VuZGVyLCBTeXN0ZW0uRHJhd2luZy5QcmludGluZy5QcmludEV2ZW50QXJncyBlKSB7DQogIHBpT" +
                        "3JnT3J0RGF0dW0uRm9ybWF0ID0gcGlPcmdPcnREYXR1bS5Gb3JtYXQuUmVwbGFjZSgiPE9yZ09ydD4iL" +
                        "FJlcG9ydC5HZXRDdXJyZW50Q29sdW1uVmFsdWUoIk9yZ19PcnQiKS5Ub1N0cmluZygpKTsNCn0B1xhkZ" +
                        "WNsYXJlIEBCZ0J1ZGdldElEICAgICAgICAgICAgaW50DQpkZWNsYXJlIEBQcmludEFsbCAgICAgICAgI" +
                        "CAgICAgYml0DQpkZWNsYXJlIEBEYXRlR2VuZXJpZXJ0ICAgICAgICAgZGF0ZXRpbWUNCmRlY2xhcmUgQ" +
                        "E9ubHlVbnZlcmJ1Y2h0ZUJlbGVnZSBiaXQNCmRlY2xhcmUgQHNNb250aCAgICAgICAgICAgICAgICB2Y" +
                        "XJjaGFyKDIwKQ0KDQpzZXQgQEJnQnVkZ2V0SUQgICAgICAgICAgICA9IG51bGwNCnNldCBAUHJpbnRBb" +
                        "GwgICAgICAgICAgICAgID0gbnVsbA0Kc2V0IEBEYXRlR2VuZXJpZXJ0ICAgICAgICAgPSBudWxsDQpzZ" +
                        "XQgQE9ubHlVbnZlcmJ1Y2h0ZUJlbGVnZSA9IG51bGwNCg0KU0VMRUNUIEBzTW9udGggPSBkYm8uZm5YT" +
                        "W9uYXQoTW9uYXQpICsgJyAnICsgU1RSKEphaHIsNCkNCkZST00gQmdCdWRnZXQgV0hFUkUgQmdCdWRnZ" +
                        "XRJRCA9IEBCZ0J1ZGdldElEDQoNCg0KU0VMRUNUDQogIE9yZ19OYW1lICAgID0gSXNOdWxsKENPTlZFU" +
                        "lQodmFyY2hhcigxMDAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc2VcU296aWFsaGlsZmVcT" +
                        "3JnYW5pc2F0aW9uJywgR2V0RGF0ZSgpKSksICcnKSwNCiAgT3JnX0FkcmVzc2UgPSBJc051bGwoQ09OV" +
                        "kVSVCh2YXJjaGFyKDEwMDApLCBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZ" +
                        "VxBZHJlc3NlJywgR2V0RGF0ZSgpKSksICcnKSwNCiAgT3JnX1BMWiAgICAgPSBJc051bGwoQ09OVkVSV" +
                        "Ch2YXJjaGFyKDEwMDApLCBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxQT" +
                        "FonLCBHZXREYXRlKCkpKSwgJycpLA0KICBPcmdfT3J0ICAgICA9IElzTnVsbChDT05WRVJUKHZhcmNoY" +
                        "XIoMTAwMCksIGRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlXE9ydCcsIEdld" +
                        "ERhdGUoKSkpLCAnJyksDQogIE9yZ19QTFpPcnQgID0gSXNOdWxsKENPTlZFUlQodmFyY2hhcigxMDAwK" +
                        "SwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc2VcU296aWFsaGlsZmVcUExaJywgR2V0RGF0ZSgpK" +
                        "SkgKyAnICcsICcnKQ0KICAgICAgICAgICAgICArIElzTnVsbChDT05WRVJUKHZhcmNoYXIoMTAwMCksI" +
                        "GRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlXE9ydCcsIEdldERhdGUoKSkpL" +
                        "CAnJyksDQoNCiAgT3JnVW5pdEFkcmVzc2UgPSBPcmcuVGV4dDEsDQogIFBSUy5OYW1lICsgJywgJyArI" +
                        "FBSUy5Wb3JuYW1lICsgSXNOdWxsKCcgJyArIFBSUy5Wb3JuYW1lMiwgJycpIEFTIEtsaWVudE5hbWUsD" +
                        "QogIExWUy5UZXh0IEFTIEZwU3RhdHVzLA0KICBMVlQuVGV4dCBBUyBGcFR5cCwNCiAgTFZULlZhbHVlM" +
                        "iBBUyBJc1VyZ2VudCwgLS0gMi4wIERCOiBJc1VyZ2VudA0KICBTRlAuR2VwbGFudFZvbiwNCiAgU0ZQL" +
                        "kdlcGxhbnRCaXMsDQogIFNGUC5EYXR1bVZvbiwNCiAgU0ZQLkRhdHVtQmlzLA0KICBTRlAuQmVtZXJrd" +
                        "W5nIEFTIFNoRnBCZW1lcmt1bmcsDQogIEJCRy5KYWhyLA0KICBCQkcuTW9uYXQsDQogIEBzTW9udGggQ" +
                        "VMgQmV6dWdzbW9uYXQsDQogIExWQi5UZXh0IEFTIE1iU3RhdHVzLA0KICBVU1IuTGFzdE5hbWUrSVNOV" +
                        "UxMKCcsICcrVVNSLkZpcnN0TmFtZSwnJykrSVNOVUxMKCcgKCcrT3JnLkl0ZW1OYW1lKycpJywnJykrS" +
                        "VNOVUxMKCcsIFRlbC4gJytVU1IuUGhvbmUsJycpIEFTIEVtcGxveWVlTmFtZSwNCiAgLS0gTXVzdCBwc" +
                        "m92aWRlIHBhcmFtZXRlcnMgYXMgdmFyaWFibGVzIHRvIHBhcmVudCBpbiBzcGVjaWFsIGZvcm0gc28gd" +
                        "GhhdCBzdWJyZXBvcnRzIGNhbiByZWFkIHRoZW0NCiAgQEJnQnVkZ2V0SUQgQVMgQmdCdWRnZXRJRCwNC" +
                        "iAgQ0FTVCAoQFByaW50QWxsIEFTIGludCkgQVMgUHJpbnRBbGwsDQogICcnJycgKyBJc051bGwoQ09OV" +
                        "kVSVChWQVJDSEFSLCBARGF0ZUdlbmVyaWVydCwgMTEyKSwgJzE5MDAwMTAxJykgKyAnJycnIEFTIERhd" +
                        "GVHZW5lcmllcnQsDQogIENBU1QgKEBPbmx5VW52ZXJidWNodGVCZWxlZ2UgQVMgaW50KSAgQVMgT25se" +
                        "VVudmVyYnVjaHRlQmVsZWdlDQpGUk9NIEJnQnVkZ2V0ICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgIEJCRw0KICBJTk5FUiBKT0lOIEJnRmluYW56cGxhbiAgICAgICAgICAgICAgICBTRlAgT04gQkJHL" +
                        "kJnRmluYW56cGxhbklEID0gU0ZQLkJnRmluYW56cGxhbklEIC0tIElOTkVSIEpPSU4gaW50ZW5kZWQ6I" +
                        "GdldCBub3RoaW5nIGlmIEJCRy5CZ0ZpbmFuenBsYW5JRCBpcyBudWxsDQogIElOTkVSIEpPSU4gRmFMZ" +
                        "WlzdHVuZyAgICAgICAgICAgICAgICAgIExFSSBPTiBMRUkuRmFMZWlzdHVuZ0lEID0gU0ZQLkZhTGVpc" +
                        "3R1bmdJRA0KICBJTk5FUiBKT0lOIEZhRmFsbCAgICAgICAgICAgICAgICAgICAgICBGQUwgT04gRkFML" +
                        "kZhRmFsbElEID0gTEVJLkZhRmFsbElEDQogIElOTkVSIEpPSU4gQmFQZXJzb24gICAgICAgICAgICAgI" +
                        "CAgICAgIFBSUyBPTiBGQUwuQmFQZXJzb25JRCA9IFBSUy5CYVBlcnNvbklEDQogIExFRlQgIEpPSU4gW" +
                        "ExPVkNvZGUgICAgICAgICAgICAgICAgICAgIExWUyBPTiBMVlMuQ29kZSA9IFNGUC5CZ0Jld2lsbGlnd" +
                        "W5nU3RhdHVzQ29kZSBBTkQgTFZTLkxPVk5hbWUgPSAnQmdCZXdpbGxpZ3VuZ1N0YXR1cycNCiAgTEVGV" +
                        "CAgSk9JTiBYTE9WQ29kZSAgICAgICAgICAgICAgICAgICAgTFZUIE9OIExWVC5Db2RlID0gU0ZQLldoS" +
                        "GlsZmVUeXBDb2RlIEFORCBMVlQuTE9WTmFtZSA9ICdXaEhpbGZlVHlwJw0KICBMRUZUICBKT0lOIFhMT" +
                        "1ZDb2RlICAgICAgICAgICAgICAgICAgICBMVkIgT04gTFZCLkNvZGUgPSBCQkcuQmdCZXdpbGxpZ3VuZ" +
                        "1N0YXR1c0NvZGUgQU5EIExWQi5MT1ZOYW1lID0gJ0JnQmV3aWxsaWd1bmdTdGF0dXMnDQogIElOTkVSI" +
                        "EpPSU4gWFVzZXIgICAgICAgICAgICAgICAgICAgICAgIFVTUiBPTiBGQUwuVXNlcklEID0gVVNSLlVzZ" +
                        "XJJRA0KICBMRUZUICBKT0lOIFhPcmdVbml0ICAgICBPcmcgb24gT3JnLk9yZ1VuaXRJRCA9ICgNCiAgI" +
                        "CBTRUxFQ1QgVE9QIDEgT1UuT3JnVW5pdElEIEZST00gWE9yZ1VuaXRfVXNlciBPVQ0KICAgIFdIRVJFI" +
                        "E9VLlVzZXJJRCA9IEZBTC5Vc2VySUQNCiAgICAgIEFORCBPVS5PcmdVbml0TWVtYmVyQ29kZSA9IDIgK" +
                        "Q0KDQpXSEVSRSBCQkcuQmdCdWRnZXRJRCA9IEBCZ0J1ZGdldElEDQogIC0tQU5EIEJCRy5CZ0Jld2lsb" +
                        "GlndW5nU3RhdHVzQ29kZSA9IDUgLS0gbnVyIGJld2lsbGlndGU=";
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
            // txtEmployeeName
            // 
            this.txtEmployeeName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "EmployeeName", "")});
            this.txtEmployeeName.Font = new System.Drawing.Font("Arial", 10F);
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
            this.txtEmployeeName.Size = new System.Drawing.Size(492, 19);
            this.txtEmployeeName.Text = "EmployeeName";
            // 
            // txtBezugsmonat
            // 
            this.txtBezugsmonat.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bezugsmonat", "")});
            this.txtBezugsmonat.Font = new System.Drawing.Font("Arial", 10F);
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
            this.txtBezugsmonat.Size = new System.Drawing.Size(492, 19);
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
            this.Line2.Size = new System.Drawing.Size(750, 4);
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
            this.Line1.Size = new System.Drawing.Size(750, 4);
            // 
            // txtMbStatus
            // 
            this.txtMbStatus.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "MbStatus", "")});
            this.txtMbStatus.Font = new System.Drawing.Font("Arial", 10F);
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
            this.txtMbStatus.Size = new System.Drawing.Size(492, 19);
            this.txtMbStatus.Text = "MbStatus";
            // 
            // txtDatumBis
            // 
            this.txtDatumBis.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "DatumBis", "{0:dd.MM.yyyy}")});
            this.txtDatumBis.Font = new System.Drawing.Font("Arial", 10F);
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
            this.txtDatumVon.Font = new System.Drawing.Font("Arial", 10F);
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
            this.txtFpTyp.Font = new System.Drawing.Font("Arial", 10F);
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
            this.txtFpTyp.Size = new System.Drawing.Size(492, 20);
            this.txtFpTyp.Text = "FpTyp";
            // 
            // Label11
            // 
            this.Label11.Font = new System.Drawing.Font("Arial", 10F);
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
            this.Label10.Font = new System.Drawing.Font("Arial", 10F);
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
            this.Label10.Size = new System.Drawing.Size(173, 19);
            this.Label10.Text = "Bezugsmonat";
            // 
            // Label9
            // 
            this.Label9.Font = new System.Drawing.Font("Arial", 10F);
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
            this.Label8.Font = new System.Drawing.Font("Arial", 10F);
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
            this.Label7.Font = new System.Drawing.Font("Arial", 10F);
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
            this.txtFpStatus.Font = new System.Drawing.Font("Arial", 10F);
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
            this.txtFpStatus.Size = new System.Drawing.Size(492, 19);
            this.txtFpStatus.Text = "FpStatus";
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 10F);
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
            this.txtKlientName.Size = new System.Drawing.Size(566, 19);
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
            this.Label4.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
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
            this.Label4.Size = new System.Drawing.Size(692, 24);
            this.Label4.Text = "Zahlungsverfügung an die Buchhaltung (Papierschnittstelle)";
            // 
            // OrgPLZOrt
            // 
            this.OrgPLZOrt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_PLZOrt", "")});
            this.OrgPLZOrt.Font = new System.Drawing.Font("Arial", 11F);
            this.OrgPLZOrt.ForeColor = System.Drawing.Color.Black;
            this.OrgPLZOrt.Location = new System.Drawing.Point(0, 30);
            this.OrgPLZOrt.Name = "OrgPLZOrt";
            this.OrgPLZOrt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.OrgPLZOrt.ParentStyleUsing.UseBackColor = false;
            this.OrgPLZOrt.ParentStyleUsing.UseBorderColor = false;
            this.OrgPLZOrt.ParentStyleUsing.UseBorders = false;
            this.OrgPLZOrt.ParentStyleUsing.UseBorderWidth = false;
            this.OrgPLZOrt.ParentStyleUsing.UseFont = false;
            this.OrgPLZOrt.ParentStyleUsing.UseForeColor = false;
            this.OrgPLZOrt.Size = new System.Drawing.Size(417, 16);
            this.OrgPLZOrt.Text = "<OrgPlzOrt>";
            // 
            // OrgAdresse
            // 
            this.OrgAdresse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Adresse", "")});
            this.OrgAdresse.Font = new System.Drawing.Font("Arial", 11F);
            this.OrgAdresse.ForeColor = System.Drawing.Color.Black;
            this.OrgAdresse.Location = new System.Drawing.Point(0, 15);
            this.OrgAdresse.Name = "OrgAdresse";
            this.OrgAdresse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.OrgAdresse.ParentStyleUsing.UseBackColor = false;
            this.OrgAdresse.ParentStyleUsing.UseBorderColor = false;
            this.OrgAdresse.ParentStyleUsing.UseBorders = false;
            this.OrgAdresse.ParentStyleUsing.UseBorderWidth = false;
            this.OrgAdresse.ParentStyleUsing.UseFont = false;
            this.OrgAdresse.ParentStyleUsing.UseForeColor = false;
            this.OrgAdresse.Size = new System.Drawing.Size(417, 16);
            this.OrgAdresse.Text = "<OrgAdresse>";
            // 
            // OrgName
            // 
            this.OrgName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Name", "")});
            this.OrgName.Font = new System.Drawing.Font("Arial", 11F);
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
            this.OrgName.Size = new System.Drawing.Size(417, 17);
            this.OrgName.Text = "<OrgName>";
            // 
            // Label12
            // 
            this.Label12.Font = new System.Drawing.Font("Arial", 10F);
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
            this.Line3.Size = new System.Drawing.Size(750, 4);
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
            this.Label13.Size = new System.Drawing.Size(456, 23);
            this.Label13.Text = "Personen im Haushalt und in der Unterstützungseinheit";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel2.Location = new System.Drawing.Point(650, 7);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(40, 20);
            this.xrLabel2.Text = "Seite";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrPageInfo2.Location = new System.Drawing.Point(692, 7);
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
            this.Line4.Size = new System.Drawing.Size(750, 4);
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
            this.Margins = new System.Drawing.Printing.Margins(39, 36, 39, 39);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
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
  INNER JOIN FaFall                      FAL ON FAL.FaFallID = LEI.FaFallID
  INNER JOIN BaPerson                    PRS ON FAL.BaPersonID = PRS.BaPersonID
  LEFT  JOIN XLOVCode                    LVS ON LVS.Code = SFP.BgBewilligungStatusCode AND LVS.LOVName = ''BgBewilligungStatus''
  LEFT  JOIN XLOVCode                    LVT ON LVT.Code = SFP.WhHilfeTypCode AND LVT.LOVName = ''WhHilfeTyp''
  LEFT  JOIN XLOVCode                    LVB ON LVB.Code = BBG.BgBewilligungStatusCode AND LVB.LOVName = ''BgBewilligungStatus''
  INNER JOIN XUser                       USR ON FAL.UserID = USR.UserID
  LEFT  JOIN XOrgUnit     Org on Org.OrgUnitID = (
    SELECT TOP 1 OU.OrgUnitID FROM XOrgUnit_User OU
    WHERE OU.UserID = FAL.UserID
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
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private DevExpress.XtraReports.UI.XRLabel txtNameFbKostenstelle;
        private DevExpress.XtraReports.UI.XRLabel txtIntern;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel txtBelegBezeichnung;
        private DevExpress.XtraReports.UI.XRLabel txtVerfallDatum;
        private DevExpress.XtraReports.UI.XRLabel Label2;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader2;
        private DevExpress.XtraReports.UI.XRLabel txtESR;
        private DevExpress.XtraReports.UI.XRLabel lblESR;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3;
        private DevExpress.XtraReports.UI.XRLabel txtBankName;
        private DevExpress.XtraReports.UI.XRLabel Label8;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.XRLabel txtKreditorOrt;
        private DevExpress.XtraReports.UI.XRLabel txtKreditorStrasse;
        private DevExpress.XtraReports.UI.XRLabel txtKreditorName;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLabel Label13;
        private DevExpress.XtraReports.UI.XRLabel Label12;
        private DevExpress.XtraReports.UI.XRLabel Label10;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRPageBreak xrPageBreak1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter3;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter2;
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
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kA" +
                        "AAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAA" +
                        "AAAAbMvZGVjbGFyZSAgQEJnQnVkZ2V0SUQgICAgICAgICAgICBpbnQNCmRlY2xhcmUgIEBLYkJ1Y2h1b" +
                        "mdJRCAgICAgICAgICAgaW50DQpkZWNsYXJlICBAQnVkZ2V0TW9uYXQgICAgICAgICAgIGludA0KZGVjb" +
                        "GFyZSAgQEJ1ZGdldEphaHIgICAgICAgICAgICBpbnQNCg0Kc2V0IEBCZ0J1ZGdldElEICAgICAgICAgI" +
                        "CA9IG51bGwNCnNldCBAS2JCdWNodW5nSUQgICAgICAgICAgPSBudWxsDQpzZXQgQEJ1ZGdldE1vbmF0I" +
                        "CAgICAgICAgID0gKFNFTEVDVCBNb25hdCBGUk9NIEJnQnVkZ2V0IFdIRVJFIEJnQnVkZ2V0SUQgPSBAQ" +
                        "mdCdWRnZXRJRCkNCnNldCBAQnVkZ2V0SmFociAgICAgICAgICAgPSAoU0VMRUNUIEphaHIgIEZST00gQ" +
                        "mdCdWRnZXQgV0hFUkUgQmdCdWRnZXRJRCA9IEBCZ0J1ZGdldElEKQ0KDQoNCiAgU0VMRUNUDQogICAgQ" +
                        "mVsZWdCZXplaWNobnVuZyA9ICdCZWxlZyAjICcgKyBDQVNUKEZCTC5LYkJ1Y2h1bmdJRCBBUyBWQVJDS" +
                        "EFSKSArICcsICcgKw0KICAgICAgZGJvLmZuTE9WVGV4dCgnS2JCdWNodW5nc1N0YXR1cycsRkJMLktiQ" +
                        "nVjaHVuZ1N0YXR1c0NvZGUpLA0KICAgIElkR3JvdXAgPSAxLA0KICAgIE5hbWVHcm91cCA9IENPTlZFU" +
                        "lQoVkFSQ0hBUigyMCksJ0J1ZGdldHBvc2l0aW9uZW4nKSwNCiAgICBGQkwuS2JCdWNodW5nSUQsDQogI" +
                        "CAgRktTLktiS29zdGVuc3RlbGxlSUQsDQogICAgR2VuZXJpZXJ0QW0gPSBGQkwuRXJzdGVsbHREYXR1b" +
                        "SwNCiAgICBWZXJidWNodEFtID0gRkJMLkJlbGVnRGF0dW0sDQogICAgQnVjaHVuZ3NkYXR1bSA9IEZCT" +
                        "C5CZWxlZ0RhdHVtLA0KICAgIFZlcmZhbGxEYXR1bSA9IEZCTC5WYWx1dGFEYXR1bSwNCiAgICBCdWNod" +
                        "W5nc3RleHQgPSBGQkwuVGV4dCwNCiAgICBFU1IgPSBGQkwuUmVmZXJlbnpOdW1tZXIsDQogICAgQmVsZ" +
                        "WdudW1tZXIgPSBGQkwuQmVsZWdOciwNCiAgICBJbnRlcm4gPSBGS0EuQnVjaHVuZ3N0ZXh0LCANCiAgI" +
                        "CBJbnRlcm5CdWRnZXREYXR1bSA9IGRiby5mblhNb25hdChAQnVkZ2V0TW9uYXQpICsgJyAnICsgQ09OV" +
                        "kVSVCh2YXJjaGFyLCBAQnVkZ2V0SmFociksDQogICAgQmV0cmFnID0gU1VNKEZLQS5CZXRyYWcpLA0KI" +
                        "CAgIE5hbWVCZWxlZ1N0YXR1cyA9IGRiby5mbkxPVlRleHQoJ0tiQnVjaHVuZ3NTdGF0dXMnLCBGQkwuS" +
                        "2JCdWNodW5nU3RhdHVzQ29kZSksDQogICAgSWRGaWJ1S29zdGVuYXJ0ID0gS09BLkV4dEZpYnVLb3N0Z" +
                        "W5hcnROciwNCiAgICBOYW1lRmJLb3N0ZW5hcnQgPSBLT0EuTmFtZSwNCiAgICBOYW1lRmJLb3N0ZW5zd" +
                        "GVsbGUgPSANCiAgICAgIENBU0UgDQogICAgICBXSEVOICc1MzAnIElOICggIA0KICAgICAgICBTRUxFQ" +
                        "1QgRXh0RmlidUtvc3RlbmFydE5yDQogICAgICAgIEZST00gQmdLb3N0ZW5hcnQNCiAgICAgICAgV0hFU" +
                        "kUgQmdLb3N0ZW5hcnRJRCA9IEZLQS5CZ0tvc3RlbmFydElEICAgICAgICAgIA0KICAgICAgICApDQogI" +
                        "CAgICBUSEVODQogICAgICAgICc1MjAuMzY2LjAxJw0KICAgICAgRUxTRSANCiAgICAgICAgS1NULk5yD" +
                        "QogICAgIEVORCwNCiAgICBOYW1lSW5oYWJlciA9IEtTVC5OYW1lLA0KICAgIEtyZWRpdG9yTmFtZSA9I" +
                        "EZCTC5CZWd1ZW5zdGlndE5hbWUsDQogICAgS3JlZGl0b3JTdHJhc3NlID0gRkJMLkJlZ3VlbnN0aWd0U" +
                        "3RyYXNzZSwNCiAgICBLcmVkaXRvck9ydCA9IElTTlVMTChGQkwuQmVndWVuc3RpZ3RQTForJyAnLCcnK" +
                        "SArSVNOVUxMKEZCTC5CZWd1ZW5zdGlndE9ydCwnJyksDQogICAgSVNOVUxMKEZCTC5CYW5rTmFtZSsnL" +
                        "CAnLCcnKSArDQogICAgQ0FTRQ0KICAgICAgV0hFTiBMRU4oSVNOVUxMKEZCTC5CYW5rS29udG9OciwnJ" +
                        "ykpID4gMA0KICAgICAgVEhFTiAnS3RvOiAnK0JhbmtLb250b05yIEVMU0UgJycNCiAgICBFTkQgKw0KI" +
                        "CAgIENBU0UNCiAgICAgIFdIRU4gTEVOKElTTlVMTChGQkwuUENLb250b05yLCcnKSkgPiAwDQogICAgI" +
                        "CBUSEVOICdQQzogJytkYm8uZm5UblRvUGMoRkJMLlBDS29udG9OcikgRUxTRSAnJw0KICAgIEVORCBBU" +
                        "yBCYW5rTmFtZQ0KICBGUk9NIEtiQnVjaHVuZyBGQkwNCiAgICBMRUZUIEpPSU4gS2JCdWNodW5nS29zd" +
                        "GVuYXJ0IEZLQSBPTiBGQkwuS2JCdWNodW5nSUQgICAgICAgICAgPSBGS0EuS2JCdWNodW5nSUQNCiAgI" +
                        "CBMRUZUIEpPSU4gS2JLb3N0ZW5zdGVsbGUgICAgIEZLUyBPTiBGS0EuS2JLb3N0ZW5zdGVsbGVJRCA9I" +
                        "EZLUy5LYktvc3RlbnN0ZWxsZUlEDQogICAgTEVGVCBKT0lOIEJnS29zdGVuYXJ0ICAgICAgICBLT0EgT" +
                        "04gS09BLkJnS29zdGVuYXJ0SUQgICAgICA9IEZLQS5CZ0tvc3RlbmFydElEDQogICAgTEVGVCBKT0lOI" +
                        "EtiS29zdGVuc3RlbGxlICAgICBLU1QgT04gS1NULktiS29zdGVuc3RlbGxlSUQgICA9IEZLUy5LYktvc" +
                        "3RlbnN0ZWxsZUlEDQogICAgTEVGVCBKT0lOIEJhUGVyc29uICAgICAgICAgICBQUlMgT04gUFJTLkJhU" +
                        "GVyc29uSUQgPSBGS0EuQmFQZXJzb25JRA0KDQogIFdIRVJFIEZCTC5LYkJ1Y2h1bmdJRCA9IEBLYkJ1Y" +
                        "2h1bmdJRA0KICAgIEFORCBOT1QgKEZLQS5CdWNodW5nc3RleHQgTElLRSAnJUtWRyUnIE9SIEZLQS5Cd" +
                        "WNodW5nc3RleHQgTElLRSAnJVZWRyUnKQ0KICBHUk9VUCBCWSBGS0EuQnVjaHVuZ3N0ZXh0LEtPQS5Fe" +
                        "HRGaWJ1S29zdGVuYXJ0TnIsS09BLk5hbWUsIEZCTC5LYkJ1Y2h1bmdJRCwgRkJMLktiQnVjaHVuZ1N0Y" +
                        "XR1c0NvZGUsIEZLUy5LYktvc3RlbnN0ZWxsZUlELCANCiAgICBGQkwuRXJzdGVsbHREYXR1bSwgRkJML" +
                        "kJlbGVnRGF0dW0sRkJMLkJlbGVnRGF0dW0sRkJMLlZhbHV0YURhdHVtLEZCTC5UZXh0LEZCTC5SZWZlc" +
                        "mVuek51bW1lcixGQkwuQmVsZWdOciwNCiAgICBGQkwuS2JCdWNodW5nU3RhdHVzQ29kZSxGS0EuQmdLb" +
                        "3N0ZW5hcnRJRCxLU1QuTnIsS1NULk5hbWUsRkJMLkJlZ3VlbnN0aWd0TmFtZSxGQkwuQmVndWVuc3RpZ" +
                        "3RTdHJhc3NlLEZCTC5CZWd1ZW5zdGlndFBMWiwNCiAgICBGQkwuQmVndWVuc3RpZ3RPcnQsRkJMLkJhb" +
                        "mtOYW1lLEZCTC5CYW5rS29udG9OcixGQkwuUENLb250b05yDQogICAgDQoNCiAgVU5JT04gQUxMDQogI" +
                        "A0KICBTRUxFQ1QNCiAgICBCZWxlZ0JlemVpY2hudW5nID0gJ0JlbGVnICMgJyArIENBU1QoRkJMLktiQ" +
                        "nVjaHVuZ0lEIEFTIFZBUkNIQVIpICsgJywgJyArDQogICAgICBkYm8uZm5MT1ZUZXh0KCdLYkJ1Y2h1b" +
                        "mdzU3RhdHVzJyxGQkwuS2JCdWNodW5nU3RhdHVzQ29kZSksDQogICAgSWRHcm91cCA9IDIsDQogICAgT" +
                        "mFtZUdyb3VwID0gQ09OVkVSVChWQVJDSEFSKDIwKSwnQnVkZ2V0cG9zaXRpb25lbicpLA0KICAgIEZCT" +
                        "C5LYkJ1Y2h1bmdJRCwNCiAgICBGS1MuS2JLb3N0ZW5zdGVsbGVJRCwNCiAgICBHZW5lcmllcnRBbSA9I" +
                        "EZCTC5FcnN0ZWxsdERhdHVtLA0KICAgIFZlcmJ1Y2h0QW0gPSBGQkwuQmVsZWdEYXR1bSwNCiAgICBCd" +
                        "WNodW5nc2RhdHVtID0gRkJMLkJlbGVnRGF0dW0sDQogICAgVmVyZmFsbERhdHVtID0gRkJMLlZhbHV0Y" +
                        "URhdHVtLA0KICAgIEJ1Y2h1bmdzdGV4dCA9IEZCTC5UZXh0LA0KICAgIEVTUiA9IEZCTC5SZWZlcmVue" +
                        "k51bW1lciwNCiAgICBCZWxlZ251bW1lciA9IEZCTC5CZWxlZ05yLA0KICAgIEludGVybiA9IEZLQS5Cd" +
                        "WNodW5nc3RleHQgKyAnLCAnICsgSXNOdWxsKFBSUy5OYW1lLCcnKSArIElzTnVsbCgnICcrUFJTLlZvc" +
                        "m5hbWUsJycpLCANCiAgICBJbnRlcm5CdWRnZXREYXR1bSA9IGRiby5mblhNb25hdChAQnVkZ2V0TW9uY" +
                        "XQpICsgJyAnICsgQ09OVkVSVCh2YXJjaGFyLCBAQnVkZ2V0SmFociksDQogICAgQmV0cmFnID0gU1VNK" +
                        "EZLQS5CZXRyYWcpLA0KICAgIE5hbWVCZWxlZ1N0YXR1cyA9IGRiby5mbkxPVlRleHQoJ0tiQnVjaHVuZ" +
                        "3NTdGF0dXMnLCBGQkwuS2JCdWNodW5nU3RhdHVzQ29kZSksDQogICAgSWRGaWJ1S29zdGVuYXJ0ID0gS" +
                        "09BLkV4dEZpYnVLb3N0ZW5hcnROciwNCiAgICBOYW1lRmJLb3N0ZW5hcnQgPSBLT0EuTmFtZSwNCiAgI" +
                        "CBOYW1lRmJLb3N0ZW5zdGVsbGUgPSANCiAgICAgIENBU0UgDQogICAgICBXSEVOICc1MzAnIElOICggI" +
                        "A0KICAgICAgICBTRUxFQ1QgRXh0RmlidUtvc3RlbmFydE5yDQogICAgICAgIEZST00gQmdLb3N0ZW5hc" +
                        "nQNCiAgICAgICAgV0hFUkUgQmdLb3N0ZW5hcnRJRCA9IEZLQS5CZ0tvc3RlbmFydElEICAgICAgICAgI" +
                        "A0KICAgICAgICApDQogICAgICBUSEVODQogICAgICAgICc1MjAuMzY2LjAxJw0KICAgICAgRUxTRSANC" +
                        "iAgICAgICAgS1NULk5yDQogICAgIEVORCwNCiAgICBOYW1lSW5oYWJlciA9IEtTVC5OYW1lLCAtLUtTV" +
                        "C5OYW1lSW5oYWJlciBBUyBOYW1lSW5oYWJlciwNCiAgICBLcmVkaXRvck5hbWUgPSBGQkwuQmVndWVuc" +
                        "3RpZ3ROYW1lLA0KICAgIEtyZWRpdG9yU3RyYXNzZSA9IEZCTC5CZWd1ZW5zdGlndFN0cmFzc2UsDQogI" +
                        "CAgS3JlZGl0b3JPcnQgPSBJU05VTEwoRkJMLkJlZ3VlbnN0aWd0UExaKycgJywnJykgK0lTTlVMTChGQ" +
                        "kwuQmVndWVuc3RpZ3RPcnQsJycpLA0KICAgIElTTlVMTChGQkwuQmFua05hbWUrJywgJywnJykgKw0KI" +
                        "CAgIENBU0UNCiAgICAgIFdIRU4gTEVOKElTTlVMTChGQkwuQmFua0tvbnRvTnIsJycpKSA+IDANCiAgI" +
                        "CAgIFRIRU4gJ0t0bzogJytCYW5rS29udG9OciBFTFNFICcnDQogICAgRU5EICsNCiAgICBDQVNFDQogI" +
                        "CAgICBXSEVOIExFTihJU05VTEwoRkJMLlBDS29udG9OciwnJykpID4gMA0KICAgICAgVEhFTiAnUEM6I" +
                        "CcrZGJvLmZuVG5Ub1BjKEZCTC5QQ0tvbnRvTnIpIEVMU0UgJycNCiAgICBFTkQgQVMgQmFua05hbWUNC" +
                        "iAgRlJPTSBLYkJ1Y2h1bmcgRkJMDQogICAgTEVGVCBKT0lOIEtiQnVjaHVuZ0tvc3RlbmFydCBGS0EgT" +
                        "04gRkJMLktiQnVjaHVuZ0lEICAgICAgICAgID0gRktBLktiQnVjaHVuZ0lEDQogICAgTEVGVCBKT0lOI" +
                        "EtiS29zdGVuc3RlbGxlICAgICBGS1MgT04gRktBLktiS29zdGVuc3RlbGxlSUQgPSBGS1MuS2JLb3N0Z" +
                        "W5zdGVsbGVJRA0KICAgIExFRlQgSk9JTiBCZ0tvc3RlbmFydCAgICAgICAgS09BIE9OIEtPQS5CZ0tvc" +
                        "3RlbmFydElEICAgICAgPSBGS0EuQmdLb3N0ZW5hcnRJRA0KICAgIExFRlQgSk9JTiBLYktvc3RlbnN0Z" +
                        "WxsZSAgICAgS1NUIE9OIEtTVC5LYktvc3RlbnN0ZWxsZUlEICAgPSBGS1MuS2JLb3N0ZW5zdGVsbGVJR" +
                        "A0KICAgIExFRlQgSk9JTiBCYVBlcnNvbiAgICAgICAgICAgUFJTIE9OIFBSUy5CYVBlcnNvbklEID0gR" +
                        "ktBLkJhUGVyc29uSUQNCiAgICBMRUZUIEpPSU4gS2JLb3N0ZW5zdGVsbGVfQmFQZXJzb24gS1NQIE9OI" +
                        "EtTUC5LYktvc3RlbnN0ZWxsZUlEID0gS1NULktiS29zdGVuc3RlbGxlSUQgDQogICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgIEFORCBLU1AuQmFQZXJzb25JRCA9IEZLQS5CYVBlcnNvbklEDQogICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgIEFORCAoS1NQLkRhdHVtQmlzIElTIE5VTEwgT1IgR2V0RGF0ZSgpIEJFVFdFR" +
                        "U4gS1NQLkRhdHVtVm9uIEFORCBLU1AuRGF0dW1CaXMpDQogICAgTEVGVCBKT0lOIEJhUGVyc29uICAgI" +
                        "CAgICAgICBQUjIgT04gUFIyLkJhUGVyc29uSUQgPSBLU1AuQmFQZXJzb25JRA0KICBXSEVSRSBGQkwuS" +
                        "2JCdWNodW5nSUQgPSBAS2JCdWNodW5nSUQNCiAgICBBTkQgKEZLQS5CdWNodW5nc3RleHQgTElLRSAnJ" +
                        "UtWRyUnIE9SIEZLQS5CdWNodW5nc3RleHQgTElLRSAnJVZWRyUnKQ0KICBHUk9VUCBCWSBGS0EuQnVja" +
                        "HVuZ3N0ZXh0LEtPQS5FeHRGaWJ1S29zdGVuYXJ0TnIsS09BLk5hbWUsIEZCTC5LYkJ1Y2h1bmdJRCwgR" +
                        "kJMLktiQnVjaHVuZ1N0YXR1c0NvZGUsIEZLUy5LYktvc3RlbnN0ZWxsZUlELCANCiAgICBGQkwuRXJzd" +
                        "GVsbHREYXR1bSwgRkJMLkJlbGVnRGF0dW0sRkJMLkJlbGVnRGF0dW0sRkJMLlZhbHV0YURhdHVtLEZCT" +
                        "C5UZXh0LEZCTC5SZWZlcmVuek51bW1lcixGQkwuQmVsZWdOcixQUjIuTmFtZSxQUjIuVm9ybmFtZSwNC" +
                        "iAgICBGQkwuS2JCdWNodW5nU3RhdHVzQ29kZSxGS0EuQmdLb3N0ZW5hcnRJRCxLU1QuTnIsS1NULk5hb" +
                        "WUsRkJMLkJlZ3VlbnN0aWd0TmFtZSxGQkwuQmVndWVuc3RpZ3RTdHJhc3NlLEZCTC5CZWd1ZW5zdGlnd" +
                        "FBMWiwNCiAgICBGQkwuQmVndWVuc3RpZ3RPcnQsRkJMLkJhbmtOYW1lLEZCTC5CYW5rS29udG9OcixGQ" +
                        "kwuUENLb250b05yLFBSUy5OYW1lLFBSUy5Wb3JuYW1lDQogDQogIE9SREVSIEJZIElkR3JvdXAsIEZCT" +
                        "C5LYkJ1Y2h1bmdJRA==";
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
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter4 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter3 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNameFbKostenstelle = new DevExpress.XtraReports.UI.XRLabel();
            this.txtIntern = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.txtBelegBezeichnung = new DevExpress.XtraReports.UI.XRLabel();
            this.txtVerfallDatum = new DevExpress.XtraReports.UI.XRLabel();
            this.Label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtESR = new DevExpress.XtraReports.UI.XRLabel();
            this.lblESR = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBankName = new DevExpress.XtraReports.UI.XRLabel();
            this.Label8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKreditorOrt = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKreditorStrasse = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKreditorName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.Label13 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label12 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrPageBreak1 = new DevExpress.XtraReports.UI.XRPageBreak();
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
                        this.xrLabel6,
                        this.txtBetrag,
                        this.txtNameFbKostenstelle,
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
                        this.Label2});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("FlBelegID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 44;
            this.GroupHeader1.Level = 3;
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
                        this.txtESR,
                        this.lblESR});
            this.GroupHeader2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("FlBelegID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader2.Height = 14;
            this.GroupHeader2.Level = 2;
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
            this.GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtBankName,
                        this.Label8,
                        this.Label7,
                        this.txtKreditorOrt,
                        this.txtKreditorStrasse,
                        this.txtKreditorName});
            this.GroupHeader3.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("FlBelegID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader3.Height = 64;
            this.GroupHeader3.Level = 1;
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
            this.GroupHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel7,
                        this.Line2,
                        this.Label13,
                        this.Label12,
                        this.Label10});
            this.GroupHeader4.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("IdFibuKostenart", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader4.Height = 42;
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
                        this.xrLabel9,
                        this.xrLabel8,
                        this.xrLine3,
                        this.xrLine2,
                        this.xrPageBreak1,
                        this.xrLabel4,
                        this.xrLabel3});
            this.GroupFooter4.Height = 136;
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
            this.GroupFooter3.Height = 0;
            this.GroupFooter3.Level = 2;
            this.GroupFooter3.Name = "GroupFooter3";
            this.GroupFooter3.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter3.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter3.ParentStyleUsing.UseBorders = false;
            this.GroupFooter3.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter3.ParentStyleUsing.UseFont = false;
            this.GroupFooter3.ParentStyleUsing.UseForeColor = false;
            this.GroupFooter3.Visible = false;
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Height = 0;
            this.GroupFooter2.Level = 1;
            this.GroupFooter2.Name = "GroupFooter2";
            this.GroupFooter2.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter2.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter2.ParentStyleUsing.UseBorders = false;
            this.GroupFooter2.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter2.ParentStyleUsing.UseFont = false;
            this.GroupFooter2.ParentStyleUsing.UseForeColor = false;
            this.GroupFooter2.Visible = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel5,
                        this.xrLabel2,
                        this.xrLine1,
                        this.xrLabel1});
            this.GroupFooter1.Height = 45;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorders = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter1.ParentStyleUsing.UseFont = false;
            this.GroupFooter1.ParentStyleUsing.UseForeColor = false;
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "InternBudgetDatum", "")});
            this.xrLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.xrLabel6.ForeColor = System.Drawing.Color.Black;
            this.xrLabel6.Location = new System.Drawing.Point(434, 0);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseBackColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorders = false;
            this.xrLabel6.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.ParentStyleUsing.UseForeColor = false;
            this.xrLabel6.Size = new System.Drawing.Size(92, 19);
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrLabel6.WordWrap = false;
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(617, 0);
            this.txtBetrag.Multiline = true;
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(75, 19);
            xrSummary1.FormatString = "{0:0.00}";
            this.txtBetrag.Summary = xrSummary1;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtNameFbKostenstelle
            // 
            this.txtNameFbKostenstelle.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameFbKostenstelle", "")});
            this.txtNameFbKostenstelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNameFbKostenstelle.ForeColor = System.Drawing.Color.Black;
            this.txtNameFbKostenstelle.Location = new System.Drawing.Point(533, 0);
            this.txtNameFbKostenstelle.Multiline = true;
            this.txtNameFbKostenstelle.Name = "txtNameFbKostenstelle";
            this.txtNameFbKostenstelle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBackColor = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBorderColor = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBorders = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBorderWidth = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseFont = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseForeColor = false;
            this.txtNameFbKostenstelle.Size = new System.Drawing.Size(83, 19);
            this.txtNameFbKostenstelle.Text = "NameFbKostenstelle";
            this.txtNameFbKostenstelle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtIntern
            // 
            this.txtIntern.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Intern", "")});
            this.txtIntern.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
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
            this.txtIntern.Size = new System.Drawing.Size(393, 19);
            this.txtIntern.Text = "Intern";
            this.txtIntern.WordWrap = false;
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.Location = new System.Drawing.Point(0, 21);
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
            this.txtBelegBezeichnung.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
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
            this.txtBelegBezeichnung.Size = new System.Drawing.Size(547, 20);
            this.txtBelegBezeichnung.Text = "BelegBezeichnung";
            // 
            // txtVerfallDatum
            // 
            this.txtVerfallDatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VerfallDatum", "{0:dd.MM.yyyy}")});
            this.txtVerfallDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtVerfallDatum.ForeColor = System.Drawing.Color.Black;
            this.txtVerfallDatum.Location = new System.Drawing.Point(173, 29);
            this.txtVerfallDatum.Multiline = true;
            this.txtVerfallDatum.Name = "txtVerfallDatum";
            this.txtVerfallDatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtVerfallDatum.ParentStyleUsing.UseBackColor = false;
            this.txtVerfallDatum.ParentStyleUsing.UseBorderColor = false;
            this.txtVerfallDatum.ParentStyleUsing.UseBorders = false;
            this.txtVerfallDatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtVerfallDatum.ParentStyleUsing.UseFont = false;
            this.txtVerfallDatum.ParentStyleUsing.UseForeColor = false;
            this.txtVerfallDatum.Size = new System.Drawing.Size(374, 14);
            xrSummary2.FormatString = "{0:dd.MM.yyyy}";
            this.txtVerfallDatum.Summary = xrSummary2;
            this.txtVerfallDatum.Text = "txtVerfallDatum";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(39, 29);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(125, 14);
            this.Label2.Text = "Verfalldatum";
            // 
            // txtESR
            // 
            this.txtESR.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ESR", "")});
            this.txtESR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtESR.ForeColor = System.Drawing.Color.Black;
            this.txtESR.Location = new System.Drawing.Point(173, 0);
            this.txtESR.Multiline = true;
            this.txtESR.Name = "txtESR";
            this.txtESR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtESR.ParentStyleUsing.UseBackColor = false;
            this.txtESR.ParentStyleUsing.UseBorderColor = false;
            this.txtESR.ParentStyleUsing.UseBorders = false;
            this.txtESR.ParentStyleUsing.UseBorderWidth = false;
            this.txtESR.ParentStyleUsing.UseFont = false;
            this.txtESR.ParentStyleUsing.UseForeColor = false;
            this.txtESR.Size = new System.Drawing.Size(547, 14);
            this.txtESR.Text = "ESR";
            // 
            // lblESR
            // 
            this.lblESR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblESR.ForeColor = System.Drawing.Color.Black;
            this.lblESR.Location = new System.Drawing.Point(39, 0);
            this.lblESR.Name = "lblESR";
            this.lblESR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblESR.ParentStyleUsing.UseBackColor = false;
            this.lblESR.ParentStyleUsing.UseBorderColor = false;
            this.lblESR.ParentStyleUsing.UseBorders = false;
            this.lblESR.ParentStyleUsing.UseBorderWidth = false;
            this.lblESR.ParentStyleUsing.UseFont = false;
            this.lblESR.ParentStyleUsing.UseForeColor = false;
            this.lblESR.Size = new System.Drawing.Size(125, 14);
            this.lblESR.Text = "ESR";
            // 
            // txtBankName
            // 
            this.txtBankName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BankName", "")});
            this.txtBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtBankName.ForeColor = System.Drawing.Color.Black;
            this.txtBankName.Location = new System.Drawing.Point(173, 42);
            this.txtBankName.Multiline = true;
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBankName.ParentStyleUsing.UseBackColor = false;
            this.txtBankName.ParentStyleUsing.UseBorderColor = false;
            this.txtBankName.ParentStyleUsing.UseBorders = false;
            this.txtBankName.ParentStyleUsing.UseBorderWidth = false;
            this.txtBankName.ParentStyleUsing.UseFont = false;
            this.txtBankName.ParentStyleUsing.UseForeColor = false;
            this.txtBankName.Size = new System.Drawing.Size(547, 14);
            this.txtBankName.Text = "BankName";
            // 
            // Label8
            // 
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(39, 42);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(125, 14);
            this.Label8.Text = "Zahlungsweg";
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(39, 0);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(125, 14);
            this.Label7.Text = "Kreditor";
            // 
            // txtKreditorOrt
            // 
            this.txtKreditorOrt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KreditorOrt", "")});
            this.txtKreditorOrt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtKreditorOrt.ForeColor = System.Drawing.Color.Black;
            this.txtKreditorOrt.Location = new System.Drawing.Point(173, 28);
            this.txtKreditorOrt.Multiline = true;
            this.txtKreditorOrt.Name = "txtKreditorOrt";
            this.txtKreditorOrt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKreditorOrt.ParentStyleUsing.UseBackColor = false;
            this.txtKreditorOrt.ParentStyleUsing.UseBorderColor = false;
            this.txtKreditorOrt.ParentStyleUsing.UseBorders = false;
            this.txtKreditorOrt.ParentStyleUsing.UseBorderWidth = false;
            this.txtKreditorOrt.ParentStyleUsing.UseFont = false;
            this.txtKreditorOrt.ParentStyleUsing.UseForeColor = false;
            this.txtKreditorOrt.Size = new System.Drawing.Size(547, 14);
            this.txtKreditorOrt.Text = "KreditorOrt";
            // 
            // txtKreditorStrasse
            // 
            this.txtKreditorStrasse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KreditorStrasse", "")});
            this.txtKreditorStrasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtKreditorStrasse.ForeColor = System.Drawing.Color.Black;
            this.txtKreditorStrasse.Location = new System.Drawing.Point(173, 14);
            this.txtKreditorStrasse.Multiline = true;
            this.txtKreditorStrasse.Name = "txtKreditorStrasse";
            this.txtKreditorStrasse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKreditorStrasse.ParentStyleUsing.UseBackColor = false;
            this.txtKreditorStrasse.ParentStyleUsing.UseBorderColor = false;
            this.txtKreditorStrasse.ParentStyleUsing.UseBorders = false;
            this.txtKreditorStrasse.ParentStyleUsing.UseBorderWidth = false;
            this.txtKreditorStrasse.ParentStyleUsing.UseFont = false;
            this.txtKreditorStrasse.ParentStyleUsing.UseForeColor = false;
            this.txtKreditorStrasse.Size = new System.Drawing.Size(547, 14);
            this.txtKreditorStrasse.Text = "KreditorStrasse";
            // 
            // txtKreditorName
            // 
            this.txtKreditorName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KreditorName", "")});
            this.txtKreditorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtKreditorName.ForeColor = System.Drawing.Color.Black;
            this.txtKreditorName.Location = new System.Drawing.Point(173, 0);
            this.txtKreditorName.Multiline = true;
            this.txtKreditorName.Name = "txtKreditorName";
            this.txtKreditorName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKreditorName.ParentStyleUsing.UseBackColor = false;
            this.txtKreditorName.ParentStyleUsing.UseBorderColor = false;
            this.txtKreditorName.ParentStyleUsing.UseBorders = false;
            this.txtKreditorName.ParentStyleUsing.UseBorderWidth = false;
            this.txtKreditorName.ParentStyleUsing.UseFont = false;
            this.txtKreditorName.ParentStyleUsing.UseForeColor = false;
            this.txtKreditorName.Size = new System.Drawing.Size(547, 14);
            this.txtKreditorName.Text = "KreditorName";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.xrLabel7.ForeColor = System.Drawing.Color.Black;
            this.xrLabel7.Location = new System.Drawing.Point(442, 8);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseBackColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorders = false;
            this.xrLabel7.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.ParentStyleUsing.UseForeColor = false;
            this.xrLabel7.Size = new System.Drawing.Size(84, 19);
            this.xrLabel7.Text = "Budget Monat";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Gray;
            this.Line2.Location = new System.Drawing.Point(39, 33);
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
            this.Label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label13.ForeColor = System.Drawing.Color.Black;
            this.Label13.Location = new System.Drawing.Point(633, 8);
            this.Label13.Name = "Label13";
            this.Label13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label13.ParentStyleUsing.UseBackColor = false;
            this.Label13.ParentStyleUsing.UseBorderColor = false;
            this.Label13.ParentStyleUsing.UseBorders = false;
            this.Label13.ParentStyleUsing.UseBorderWidth = false;
            this.Label13.ParentStyleUsing.UseFont = false;
            this.Label13.ParentStyleUsing.UseForeColor = false;
            this.Label13.Size = new System.Drawing.Size(59, 19);
            this.Label13.Text = "Betrag";
            this.Label13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label12
            // 
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(533, 8);
            this.Label12.Name = "Label12";
            this.Label12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label12.ParentStyleUsing.UseBackColor = false;
            this.Label12.ParentStyleUsing.UseBorderColor = false;
            this.Label12.ParentStyleUsing.UseBorders = false;
            this.Label12.ParentStyleUsing.UseBorderWidth = false;
            this.Label12.ParentStyleUsing.UseFont = false;
            this.Label12.ParentStyleUsing.UseForeColor = false;
            this.Label12.Size = new System.Drawing.Size(84, 19);
            this.Label12.Text = "Kostenstelle";
            this.Label12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label10
            // 
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label10.ForeColor = System.Drawing.Color.Black;
            this.Label10.Location = new System.Drawing.Point(39, 8);
            this.Label10.Name = "Label10";
            this.Label10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label10.ParentStyleUsing.UseBackColor = false;
            this.Label10.ParentStyleUsing.UseBorderColor = false;
            this.Label10.ParentStyleUsing.UseBorders = false;
            this.Label10.ParentStyleUsing.UseBorderWidth = false;
            this.Label10.ParentStyleUsing.UseFont = false;
            this.Label10.ParentStyleUsing.UseForeColor = false;
            this.Label10.Size = new System.Drawing.Size(157, 19);
            this.Label10.Text = "Buchungstext intern";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.xrLabel9.ForeColor = System.Drawing.Color.Black;
            this.xrLabel9.Location = new System.Drawing.Point(425, 83);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.ParentStyleUsing.UseForeColor = false;
            this.xrLabel9.Size = new System.Drawing.Size(287, 24);
            this.xrLabel9.Text = "Zur Zahlung freigegeben";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.xrLabel8.ForeColor = System.Drawing.Color.Black;
            this.xrLabel8.Location = new System.Drawing.Point(42, 83);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.ParentStyleUsing.UseForeColor = false;
            this.xrLabel8.Size = new System.Drawing.Size(287, 24);
            this.xrLabel8.Text = "Die Richtigkeit bescheinigt";
            // 
            // xrLine3
            // 
            this.xrLine3.ForeColor = System.Drawing.Color.Black;
            this.xrLine3.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.xrLine3.Location = new System.Drawing.Point(425, 83);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.ParentStyleUsing.UseBackColor = false;
            this.xrLine3.ParentStyleUsing.UseBorderColor = false;
            this.xrLine3.ParentStyleUsing.UseBorders = false;
            this.xrLine3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine3.ParentStyleUsing.UseFont = false;
            this.xrLine3.ParentStyleUsing.UseForeColor = false;
            this.xrLine3.Size = new System.Drawing.Size(264, 2);
            // 
            // xrLine2
            // 
            this.xrLine2.ForeColor = System.Drawing.Color.Black;
            this.xrLine2.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.xrLine2.Location = new System.Drawing.Point(42, 83);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.ParentStyleUsing.UseBackColor = false;
            this.xrLine2.ParentStyleUsing.UseBorderColor = false;
            this.xrLine2.ParentStyleUsing.UseBorders = false;
            this.xrLine2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine2.ParentStyleUsing.UseFont = false;
            this.xrLine2.ParentStyleUsing.UseForeColor = false;
            this.xrLine2.Size = new System.Drawing.Size(264, 2);
            // 
            // xrPageBreak1
            // 
            this.xrPageBreak1.Location = new System.Drawing.Point(0, 125);
            this.xrPageBreak1.Name = "xrPageBreak1";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.Location = new System.Drawing.Point(432, 13);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.ParentStyleUsing.UseForeColor = false;
            this.xrLabel4.Size = new System.Drawing.Size(157, 19);
            this.xrLabel4.Text = "Total für Beleg";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(592, 13);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(100, 19);
            xrSummary3.FormatString = "{0:0.00}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel3.Summary = xrSummary3;
            this.xrLabel3.Text = "Betrag";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "IdFibuKostenart", "Kostenart {0} :")});
            this.xrLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.xrLabel5.Location = new System.Drawing.Point(267, 19);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(91, 20);
            this.xrLabel5.Text = "xrLabel6";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameFbKostenart", "")});
            this.xrLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.xrLabel2.Location = new System.Drawing.Point(358, 19);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(242, 20);
            this.xrLabel2.Text = "xrLabel7";
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Gray;
            this.xrLine1.Location = new System.Drawing.Point(39, 8);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(653, 2);
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.xrLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.Location = new System.Drawing.Point(600, 19);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseBackColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.ParentStyleUsing.UseForeColor = false;
            this.xrLabel1.Size = new System.Drawing.Size(91, 19);
            xrSummary4.FormatString = "{0:0.00}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel1.Summary = xrSummary4;
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
                        this.GroupHeader2,
                        this.GroupHeader3,
                        this.GroupHeader4,
                        this.GroupFooter4,
                        this.GroupFooter3,
                        this.GroupFooter2,
                        this.GroupFooter1});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 39, 39);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
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

  /*
  DECLARE @aDate        DATETIME
  IF @PrintAll = 1 BEGIN
    SET @aDate = ''19000101''
  END ELSE BEGIN
    SET @aDate = @DateGeneriert
  END
  */

  SELECT
    BelegBezeichnung = ''Beleg # '' + CAST(FBL.KbBuchungID AS VARCHAR) + '', '' +
      dbo.fnLOVText(''KbBuchungStatus'',FBL.KbBuchungStatusCode),
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
    Extern = IsNull(PR2.Name,'''') + IsNull('' ''+PR2.Vorname,''''),
    ESR = FBL.ReferenzNummer,
    Belegnummer = FBL.BelegNr,
    Intern = FKA.Buchungstext,
    InternBudgetDatum = dbo.fnXMonat(@BudgetMonat) + '' '' + CONVERT(varchar, @BudgetJahr),
    FKA.Betrag,
    NameBelegStatus = dbo.fnLOVText(''KbBuchungStatus'', FBL.KbBuchungStatusCode),
    IdFibuKostenart = KOA.KontoNr,
    NameFbKostenart = KOA.Name,
    NameFbKostenstelle = PRS.Fax,
    NameInhaber = KST.Name, --KST.NameInhaber AS NameInhaber,
    KreditorName = FBL.BeguenstigtName,
    KreditorStrasse = FBL.BeguenstigtStrasse,
    KreditorOrt = ISNULL(FBL.BeguenstigtPLZ+'' '','''') +ISNULL(FBL.BeguenstigtOrt,''''),
    ISNULL(FBL.BankName+'', '','''') +
    CASE
      WHEN LEN(COALESCE(FBL.IBAN, FBL.BankKontoNr, '''')) > 0
      THEN ''Kto: ''+ IsNull(FBL.IBAN, FBL.BankKontoNr) + '' '' ELSE ''''
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

/*
  UNION ALL

  SELECT ''Beleg # '' + CAST(FBL.KbBuchungID AS VARCHAR) + '', '' + FBS.Text AS BelegBezeichnung,
    2                                          AS IdGroup,
    CONVERT(VARCHAR(20),''Einzelzahlungen'')     AS NameGroup,
    FBL.KbBuchungID                            AS KbBuchungID,
    FKA.KbBuchungKostenartID                   AS KbBuchungKostenartID,
    FKS.KbKostenstelleID                       AS FlBelegKostenstelleID,
    FBL.ErstelltDatum                          AS GeneriertAm,
    FBL.BelegDatum                             AS VerbuchtAm,
    FBL.BelegDatum                             AS Buchungsdatum,
    FBL.ValutaDatum                            AS VerfallDatum,
    FBL.Text                                   AS Buchungstext,
    Extern = IsNull(PR2.Name,'''') + IsNull('' ''+PR2.Vorname,''''),
    FBL.ReferenzNummer                         AS ESR,
    FBL.BelegNr                                AS Belegnummer,
    Intern = FKA.Buchungstext + '', '' + IsNull(PRS.Name,'''') + IsNull('' ''+PRS.Vorname,''''),
    FKA.Betrag                                 AS Betrag,
    FBS.Text                                   AS NameBelegStatus,
    KOA.KontoNr                     AS IdFibuKostenart,
    KOA.Name                                   AS NameFbKostenart,
    FKS.Nr                                     AS NameFbKostenstelle,
    FKS.Name                                   AS NameInhaber,
    LVN.Value1                                 AS NummerNrmKonto,
    LVN.Text                                   AS NameNrmKonto,
    FBL.BeguenstigtName                                   AS KreditorName,
    FBL.BeguenstigtStrasse                                AS KreditorStrasse,
    ISNULL(FBL.BeguenstigtPLZ+'' '','''') +ISNULL(FBL.BeguenstigtOrt,'''') AS KreditorOrt,

    ISNULL(FBL.BankName+'', '','''') +
    CASE
      WHEN LEN(ISNULL(FBL.BankKontoNr,'''')) > 0
      THEN ''Kto: ''+BankKontoNr ELSE ''''
    END +
    CASE
      WHEN LEN(ISNULL(FBL.PCKontoNr,'''')) > 0
      THEN ''PC: ''+dbo.fnTnToPc(FBL.PCKontoNr) ELSE ''''
    END AS BankName

  FROM BgPosition SEZ -- ShEinzelzahlung SEZ
    LEFT JOIN KbBuchung            FBL ON SEZ.BgBudgetID = FBL.BgBudgetID AND FBL.BuchungTypCode = 1  -- ???? = FBL.IdSource AND FBL.FlTypSourceCode=105  -- Einzelverfügungen aus Einzelzahlungen
    LEFT JOIN KbBuchungKostenart   FKA ON FBL.KbBuchungID = FKA.KbBuchungID
    LEFT JOIN KbKostenstelle       FKS ON FKA.KbKostenstelleID = FKS.KbKostenstelleID
    LEFT JOIN XLOVCode             FBS ON FBS.Code = FBL.KbBuchungStatusCode AND FBS.LOVName = ''KbBuchungStatus''
    LEFT JOIN BgKostenart          KOA ON KOA.BgKostenartID      = FKA.BgKostenartID
    LEFT JOIN XLOVCode             LVN ON LVN.Code = FKA.NrmKontoCode AND LVN.LOVName = ''NrmKonto''
    LEFT JOIN BaPerson             PRS ON PRS.BaPersonID = FKA.BaPersonID
    LEFT JOIN BaPerson             PR2 ON PR2.BaPersonID = FKS.BaPersonID
  WHERE SEZ.BgBudgetID = @BgBudgetID
    AND FBL.KbAuszahlungsartCode = 102   -- Papierverfügung zur Buchhaltung
    AND FBL.KbBuchungStatusCode in (1,2) -- vorbereitet, freigegeben
    AND FBL.KbBuchungTypCode=1
    AND SEZ.BgKategorieCode = 101  -- Einzelzahlung
    AND (
      (@OnlyUnverbuchteBelege=1 AND FBL.KbBuchungStatusCode = 3 ) OR
      (@OnlyUnverbuchteBelege=0)
    )
    AND (
      (@PrintAll = 0 AND (@DateGeneriert <= FBL.ErstelltDatum) ) OR
      (@PrintAll = 1)
    )
*/
  ORDER BY IdGroup, FBL.KbBuchungID, KbBuchungKostenartID' ,  null ,  N'ShPapierverfuegungBuchhaltung' ,  null );


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
        private DevExpress.XtraReports.UI.XRCheckBox CheckBox1;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtHeimatort;
        private DevExpress.XtraReports.UI.XRLabel txtAHVNummer;
        private DevExpress.XtraReports.UI.XRLabel txtGeburtsdatum;
        private DevExpress.XtraReports.UI.XRLabel txtNameKomplett;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLine Line1;
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
                    string resourceString = @"zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OSNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kAAAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAAAAAAaQFZGVjbGFyZSBAQmdCdWRnZXRJRCBpbnQNCg0Kc2V0IEBCZ0J1ZGdldElEICAgICAgICAgICAgPSBudWxsDQoNClNFTEVDVA0KICBOYW1lID0gUFJTLk5hbWUgKyBpc051bGwoJywgJyArIFBSUy5Wb3JuYW1lLCcnKSwNCiAgUFJTLkdlYnVydHNkYXR1bSwNCiAgUFJTLkFIVk51bW1lciwNCiAgSEVJLk5hbWUgKyBJc051bGwoJyAnICsgSEVJLkthbnRvbiwgJycpIEFTIEhlaW1hdG9ydCwNCiAgU1BQLklzdFVudGVyc3R1ZXR6dA0KRlJPTSBCZ0J1ZGdldCAgICAgICAgICAgICAgICAgICAgICAgIEJCRw0KICBJTk5FUiBKT0lOIEJnRmluYW56cGxhbiAgICAgICAgICAgIFNGUCBPTiBTRlAuQmdGaW5hbnpwbGFuSUQgPSBCQkcuQmdGaW5hbnpwbGFuSUQNCiAgSU5ORVIgSk9JTiBCZ0ZpbmFuenBsYW5fQmFQZXJzb24gICBTUFAgT04gU1BQLkJnRmluYW56cGxhbklEID0gU0ZQLkJnRmluYW56cGxhbklEDQogIElOTkVSIEpPSU4gQmFQZXJzb24gICAgICAgICAgICAgICAgUFJTIE9OIFBSUy5CYVBlcnNvbklkID0gU1BQLkJhUGVyc29uSWQNCiAgTEVGVCAgSk9JTiBCYUdlbWVpbmRlICAgICAgICAgICAgICBIRUkgT04gSEVJLkJhR2VtZWluZGVJRCA9IFBSUy5IZWltYXRnZW1laW5kZUJhR2VtZWluZGVJRA0KV0hFUkUgQkJHLkJnQnVkZ2V0SUQ9QEJnQnVkZ2V0SUQNCg0KT1JERVIgQlkgTmFtZQ==";
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
            this.txtHeimatort = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAHVNummer = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGeburtsdatum = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNameKomplett = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
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
                        this.txtHeimatort,
                        this.txtAHVNummer,
                        this.txtGeburtsdatum,
                        this.txtNameKomplett});
            this.Detail.Height = 16;
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
                        this.Label5,
                        this.Label4,
                        this.Label3,
                        this.Label2,
                        this.Label1});
            this.GroupHeader1.Height = 22;
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
            this.CheckBox1.Font = new System.Drawing.Font("Arial", 10F);
            this.CheckBox1.ForeColor = System.Drawing.Color.Black;
            this.CheckBox1.Location = new System.Drawing.Point(708, 0);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.ParentStyleUsing.UseBackColor = false;
            this.CheckBox1.ParentStyleUsing.UseBorderColor = false;
            this.CheckBox1.ParentStyleUsing.UseBorders = false;
            this.CheckBox1.ParentStyleUsing.UseBorderWidth = false;
            this.CheckBox1.ParentStyleUsing.UseFont = false;
            this.CheckBox1.ParentStyleUsing.UseForeColor = false;
            this.CheckBox1.Size = new System.Drawing.Size(17, 15);
            this.CheckBox1.WordWrap = false;
            // 
            // txtHeimatort
            // 
            this.txtHeimatort.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Heimatort", "")});
            this.txtHeimatort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtHeimatort.ForeColor = System.Drawing.Color.Black;
            this.txtHeimatort.Location = new System.Drawing.Point(500, 0);
            this.txtHeimatort.Name = "txtHeimatort";
            this.txtHeimatort.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtHeimatort.ParentStyleUsing.UseBackColor = false;
            this.txtHeimatort.ParentStyleUsing.UseBorderColor = false;
            this.txtHeimatort.ParentStyleUsing.UseBorders = false;
            this.txtHeimatort.ParentStyleUsing.UseBorderWidth = false;
            this.txtHeimatort.ParentStyleUsing.UseFont = false;
            this.txtHeimatort.ParentStyleUsing.UseForeColor = false;
            this.txtHeimatort.Size = new System.Drawing.Size(184, 15);
            this.txtHeimatort.Text = "Heimatort";
            this.txtHeimatort.WordWrap = false;
            // 
            // txtAHVNummer
            // 
            this.txtAHVNummer.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AHVNummer", "")});
            this.txtAHVNummer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtAHVNummer.ForeColor = System.Drawing.Color.Black;
            this.txtAHVNummer.Location = new System.Drawing.Point(350, 0);
            this.txtAHVNummer.Multiline = true;
            this.txtAHVNummer.Name = "txtAHVNummer";
            this.txtAHVNummer.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtAHVNummer.ParentStyleUsing.UseBackColor = false;
            this.txtAHVNummer.ParentStyleUsing.UseBorderColor = false;
            this.txtAHVNummer.ParentStyleUsing.UseBorders = false;
            this.txtAHVNummer.ParentStyleUsing.UseBorderWidth = false;
            this.txtAHVNummer.ParentStyleUsing.UseFont = false;
            this.txtAHVNummer.ParentStyleUsing.UseForeColor = false;
            this.txtAHVNummer.Size = new System.Drawing.Size(117, 15);
            this.txtAHVNummer.Text = "AHVNummer";
            // 
            // txtGeburtsdatum
            // 
            this.txtGeburtsdatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Geburtsdatum", "{0:dd.MM.yyyy}")});
            this.txtGeburtsdatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtGeburtsdatum.ForeColor = System.Drawing.Color.Black;
            this.txtGeburtsdatum.Location = new System.Drawing.Point(233, 0);
            this.txtGeburtsdatum.Multiline = true;
            this.txtGeburtsdatum.Name = "txtGeburtsdatum";
            this.txtGeburtsdatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGeburtsdatum.ParentStyleUsing.UseBackColor = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorderColor = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorders = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseFont = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseForeColor = false;
            this.txtGeburtsdatum.Size = new System.Drawing.Size(92, 15);
            xrSummary1.FormatString = "{0:dd.MM.yyyy}";
            this.txtGeburtsdatum.Summary = xrSummary1;
            this.txtGeburtsdatum.Text = "Geburtsdatum";
            this.txtGeburtsdatum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.txtGeburtsdatum.WordWrap = false;
            // 
            // txtNameKomplett
            // 
            this.txtNameKomplett.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.txtNameKomplett.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
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
            this.txtNameKomplett.Size = new System.Drawing.Size(225, 15);
            this.txtNameKomplett.Text = "Name, Vorname";
            this.txtNameKomplett.WordWrap = false;
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Gray;
            this.Line1.Location = new System.Drawing.Point(0, 19);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(748, 2);
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(700, 0);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(25, 19);
            this.Label5.Text = "UE";
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(500, 0);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(75, 19);
            this.Label4.Text = "Heimatort";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(350, 0);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(91, 19);
            this.Label3.Text = "AHV-Nummer";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(242, 0);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(84, 19);
            this.Label2.Text = "Geb.datum";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
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
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
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
  PRS.AHVNummer,
  HEI.Name + IsNull('' '' + HEI.Kanton, '''') AS Heimatort,
  SPP.IstUnterstuetzt,
  NummerNrmKonto = LVN.Value1,
  NameKst = dbo.fnKbGetKostenstelle(PRS.BaPersonID),
  NameKstKvg = 
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
/*,
  NameNrmKonto = LVN.Text,
  SPP.PrsNummerKanton,
  SPP.PrsNummerHeimat,
  NameKst = FS1.Nr,
  InhaberKst = FS1.Name,
  NameKstKvg = FS2.Nr,
  InhaberKstKvg = FS2.Name
*/
FROM BgBudget                        BBG
  INNER JOIN BgFinanzplan            SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
  INNER JOIN BgFinanzplan_BaPerson   SPP ON SPP.BgFinanzplanID = SFP.BgFinanzplanID
  INNER JOIN BaPerson                PRS ON PRS.BaPersonId = SPP.BaPersonId
  LEFT  JOIN BaWVCode                BWV ON BWV.BaPersonID = PRS.BaPersonID
                                        AND CONVERT(DATETIME, ''01.'' + CONVERT(VARCHAR, BBG.Monat) + ''.'' + CONVERT(VARCHAR, BBG.Jahr), 104) BETWEEN BWV.DatumVon AND ISNULL(BWV.DatumBis, CONVERT(DATETIME, ''01.01.9999'', 104))
  LEFT  JOIN BaGemeinde              HEI ON HEI.BaGemeindeID = PRS.HeimatgemeindeBaGemeindeID
  LEFT  JOIN XLOVCode                LVN ON LVN.Code = BWV.BaWVCode AND LVN.LOVName = ''BaWVCode''
--  LEFT  JOIN KbKostenstelle          FS1 ON FS1.KbKostenstelleID = SPP.KbKostenstelleID
--  LEFT  JOIN KbKostenstelle          FS2 ON FS2.KbKostenstelleID = SPP.KbKostenstelleID_KVG
WHERE BBG.BgBudgetID=@BgBudgetID
  AND (SPP.IstUnterstuetzt=1)

UNION ALL

-- now all the persons who are not unterstuetzt
SELECT
  Name = PRS.Name + isNull('', '' + PRS.Vorname,''''),
  PRS.Geburtsdatum,
  PRS.AHVNummer,
  HEI.Name + IsNull('' '' + HEI.Kanton, '''') AS Heimatort,
  SPP.IstUnterstuetzt,
  NummerNrmKonto = NULL,
  NameKst = dbo.fnKbGetKostenstelle(PRS.BaPersonID),
  NameKstKvg = NULL
/*,
  NULL,   -- LVN.Text   AS NameNrmKonto,
  NULL,   -- SPP.PrsNummerKanton,
  NULL,   -- SPP.PrsNummerHeimat,
  NULL,   -- FS1.NameFbKostenstelle  AS NameKst,
  NULL,   -- FS1.NameInhaber         AS InhaberKst,
  NULL,   -- FS2.NameFbKostenstelle  AS NameKstKvg,
  NULL    -- FS2.NameInhaber         AS InhaberKstKvg,
*/
FROM BgBudget                        BBG
  INNER JOIN BgFinanzplan            SFP ON SFP.BgFinanzplanID  = BBG.BgFinanzplanID
  INNER JOIN BgFinanzplan_BaPerson   SPP ON SPP.BgFinanzplanID  = SFP.BgFinanzplanID
  INNER JOIN BaPerson                PRS ON PRS.BaPersonId      = SPP.BaPersonId
  LEFT  JOIN BaGemeinde              HEI ON HEI.BaGemeindeID    = PRS.HeimatgemeindeBaGemeindeID
WHERE BBG.BgBudgetID = @BgBudgetID
  AND SPP.IstUnterstuetzt = 0

ORDER BY Name' ,  null ,  N'ShPapierverfuegungBuchhaltung' ,  null );


