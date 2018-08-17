-- Insert Script for ShVollmachtBarbezug
-- MD5:0X8EC0447E3DE16D8D469A8049B0FAC90A_0X0ADF4580439533DD6350CC8EA9813309_0X5964450BD3287A526CFB3CDB7BDC47AF
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'ShVollmachtBarbezug') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('ShVollmachtBarbezug', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'ShVollmachtBarbezug';
UPDATE QRY
SET QueryName =  N'ShVollmachtBarbezug' , UserText =  N'SH - Vollmacht für Barbezug' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>de-DE</Localization>
///   <References>
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraPrinting.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Drawing\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Configuration\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.SqlXml\v4.0_4.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Security\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.Utils.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Utils.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Forms\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Forms.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Accessibility\v4.0_4.0.0.0__b03f5f7f11d50a3a\Accessibility.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Serialization.Formatters.Soap\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Runtime.Serialization.Formatters.Soap.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Deployment\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Deployment.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Design\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Design.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Data\v4.0_4.0.0.0__b77a5c561934e089\System.Data.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.VisualC\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualC.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Transactions\v4.0_4.0.0.0__b77a5c561934e089\System.Transactions.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.EnterpriseServices\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.EnterpriseServices.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.DirectoryServices\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Remoting\v4.0_4.0.0.0__b77a5c561934e089\System.Runtime.Remoting.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Web\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Framework\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Framework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xaml\v4.0_4.0.0.0__b77a5c561934e089\System.Xaml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Caching\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Runtime.Caching.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Web.ApplicationServices\v4.0_4.0.0.0__31bf3856ad364e35\System.Web.ApplicationServices.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Core\v4.0_4.0.0.0__b77a5c561934e089\System.Core.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Numerics\v4.0_4.0.0.0__b77a5c561934e089\System.Numerics.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Web.Services\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.Services.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Utilities.v4.0\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Utilities.v4.0.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.DirectoryServices.Protocols\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.Protocols.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Tasks.v4.0\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Tasks.v4.0.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ServiceProcess\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.ServiceProcess.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Configuration.Install\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.Install.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Serialization\v4.0_4.0.0.0__b77a5c561934e089\System.Runtime.Serialization.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\SMDiagnostics\v4.0_4.0.0.0__b77a5c561934e089\SMDiagnostics.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.DurableInstancing\v4.0_4.0.0.0__31bf3856ad364e35\System.Runtime.DurableInstancing.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xml.Linq\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.Linq.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Web.RegularExpressions\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.RegularExpressions.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Drawing.Design\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.Design.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Data.OracleClient\v4.0_4.0.0.0__b77a5c561934e089\System.Data.OracleClient.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraEditors.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.Data.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Data.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraBars.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraNavBar.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraCharts.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraRichTextEdit.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="C:\Projects\KiSS40\Releases\R4.3.46\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\KiSS40\Releases\R4.3.46\Kiss.Interfaces.dll" />
///     <Reference Path="C:\Projects\KiSS40\Releases\R4.3.46\Microsoft.Practices.Unity.dll" />
///     <Reference Path="C:\Projects\KiSS40\Releases\R4.3.46\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\Projects\KiSS40\Releases\R4.3.46\FluentValidation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\Projects\KiSS40\Releases\R4.3.46\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="C:\Projects\KiSS40\Releases\R4.3.46\log4net.dll" />
///     <Reference Path="C:\Projects\KiSS40\Releases\R4.3.46\SharpLibrary.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtIntern;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.GroupHeaderBand Header_KbBuchungID;
        private DevExpress.XtraReports.UI.XRLabel Label18;
        private DevExpress.XtraReports.UI.XRLabel Label16;
        private DevExpress.XtraReports.UI.XRRichText xrRichText1;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel txtBemerkung;
        private DevExpress.XtraReports.UI.XRLabel Label11;
        private DevExpress.XtraReports.UI.XRLabel Label9;
        private DevExpress.XtraReports.UI.XRLabel txtEmployeeName;
        private DevExpress.XtraReports.UI.XRLabel txtNameYearMonth;
        private DevExpress.XtraReports.UI.XRLabel txtFullName;
        private DevExpress.XtraReports.UI.XRLabel Label8;
        private DevExpress.XtraReports.UI.XRLabel txtFlBelegID;
        private DevExpress.XtraReports.UI.XRControl xrControl1;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel Label15;
        private DevExpress.XtraReports.UI.XRLabel txtStrasse;
        private DevExpress.XtraReports.UI.XRLabel FullName1;
        private DevExpress.XtraReports.UI.XRLabel Label14;
        private DevExpress.XtraReports.UI.XRLabel Label3;
        private DevExpress.XtraReports.UI.XRLabel Label2;
        private DevExpress.XtraReports.UI.XRLabel Label1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter2;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel txtCashOrCheckAm;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.XRLabel Label5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLine Line6;
        private DevExpress.XtraReports.UI.XRLine Line5;
        private DevExpress.XtraReports.UI.XRLine Line4;
        private DevExpress.XtraReports.UI.XRLabel Betrag1;
        private DevExpress.XtraReports.UI.XRLabel Label19;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAACAAAAAQAAAIwBRGV2RXhwcmVzc" +
                        "y5YdHJhUmVwb3J0cy5VSS5TZXJpYWxpemFibGVTdHJpbmcsIERldkV4cHJlc3MuWHRyYVJlcG9ydHMud" +
                        "jYuMiwgVmVyc2lvbj02LjIuNi4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPTc5ODY4Y" +
                        "jgxNDdiNWVhZTRQE7ROpIBtm7YAAAAANwAAAK4BAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlA" +
                        "GMAdABTAHQAYQB0AGUAbQBlAG4AdAAAAAAAJngAcgBSAGkAYwBoAFQAZQB4AHQAMQAuAFIAdABmAFQAZ" +
                        "QB4AHQASgwAAAHHGGRlY2xhcmUgQEJnQnVkZ2V0SUQgaW50DQpzZXQgQEJnQnVkZ2V0SUQgPSA0MjgxM" +
                        "DggLS0gKFRlc3RDYXNlKTQyODEwOA0KDQpzZWxlY3QgZGlzdGluY3QNCiAgIE9yZ19OYW1lICAgID0gS" +
                        "XNOdWxsKENPTlZFUlQodmFyY2hhcigxMDAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc2VcU" +
                        "296aWFsaGlsZmVcT3JnYW5pc2F0aW9uJywgR2V0ZGF0ZSgpKSksICcnKSwNCiAgIE9yZ19BZHJlc3NlI" +
                        "D0gSXNOdWxsKENPTlZFUlQodmFyY2hhcigxMDAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc" +
                        "2VcU296aWFsaGlsZmVcQWRyZXNzZScsIEdldGRhdGUoKSkpLCAnJyksDQogICBPcmdfUExaICAgICA9I" +
                        "ElzTnVsbChDT05WRVJUKHZhcmNoYXIoMTAwMCksIGRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlX" +
                        "FNvemlhbGhpbGZlXFBMWicsIEdldGRhdGUoKSkpLCAnJyksDQogICBPcmdfT3J0ICAgICA9IElzTnVsb" +
                        "ChDT05WRVJUKHZhcmNoYXIoMTAwMCksIGRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlXFNvemlhb" +
                        "GhpbGZlXE9ydCcsIEdldGRhdGUoKSkpLCAnJyksDQogICBPcmdfUExaT3J0ICA9IElzTnVsbChDT05WR" +
                        "VJUKHZhcmNoYXIoMTAwMCksIGRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlX" +
                        "FBMWicsIEdldGRhdGUoKSkpICsgJyAnLCAnJykNCiAgICAgICAgICAgICAgICArIElzTnVsbChDT05WR" +
                        "VJUKHZhcmNoYXIoMTAwMCksIGRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlX" +
                        "E9ydCcsIEdldGRhdGUoKSkpLCAnJyksDQogICBLQkIuS2JBdXN6YWhsdW5nc2FydENvZGUsDQogICBLQ" +
                        "kIuS2JCdWNodW5nSUQsDQogICBLQkIuS2JCdWNodW5nU3RhdHVzQ29kZSwNCiAgIE5hbWVLYkJ1Y2h1b" +
                        "mdzU3RhdHVzID0gZGJvLmZuTE9WVGV4dCgnS2JCdWNodW5nc1N0YXR1cycsIEtCQi5LYkJ1Y2h1bmdTd" +
                        "GF0dXNDb2RlKSwNCiAgIE5hbWVLYkF1c3phaGx1bmdzQXJ0ICAgID0gZGJvLmZuTE9WVGV4dCgnS2JBd" +
                        "XN6YWhsdW5nc0FydCcsIEtCQi5LYkF1c3phaGx1bmdzYXJ0Q29kZSksDQogICBOYW1lWWVhck1vbnRoI" +
                        "CAgICA9IGRiby5mblhNb25hdChCR0cuTW9uYXQpICsgJyAnICsgQ29udmVydCh2YXJjaGFyLCBCR0cuS" +
                        "mFociksDQogICBWZXJmYWxsZGF0dW0gPSBEQVRFQUREKERBWSwgNSwgS0JCLlZhbHV0YURhdHVtKSwNC" +
                        "iAgIEtCSy5LYkJ1Y2h1bmdLb3N0ZW5hcnRJRCwNCiAgIEtCSy5CdWNodW5nc3RleHQsDQogICBCZXRyY" +
                        "WcgPSBLQksuQmV0cmFnLA0KICAgTmFtZUtvc3RlbmFydCA9IEJHSy5OYW1lLA0KICAgTmFtZUtvc3Rlb" +
                        "nN0ZWxsZSA9IEJLUy5OYW1lLA0KICAgS0JLUGVyc29uSUQgPSBLQksuQmFQZXJzb25JRCwgICAgCQ0KI" +
                        "CAgTmFtZUthc3NpZXIgPSBLVVNSLkxhc3ROYW1lICsgaXNudWxsKCcsICcgKyBLVVNSLkZpcnN0TmFtZ" +
                        "SwnJykgKw0KCQkJCQlpc051bGwoJyAoJyArIEtVU1IuUGhvbmUgKyAnKScsJycpLA0KICAgRnVsbE5hb" +
                        "WUgPSBQUlMuTmFtZVZvcm5hbWUsDQogICBBdXN6dXphaGxlbkFuID0gQ0FTRSBXSEVOIEtCQi5CZWd1Z" +
                        "W5zdGlndE5hbWUgaXMgTlVMTCBPUiBLQkIuQmVndWVuc3RpZ3ROYW1lID0gJycgVEhFTiBQUlMuTmFtZ" +
                        "VZvcm5hbWUgRUxTRSBLQkIuQmVndWVuc3RpZ3ROYW1lIEVORCwNCiAgIFN0cmFzc2UgID0gQ0FTRSBXS" +
                        "EVOIEtCQi5CZWd1ZW5zdGlndFN0cmFzc2UgaXMgTlVMTCBPUiBLQkIuQmVndWVuc3RpZ3RTdHJhc3NlI" +
                        "D0gJycgVEhFTiBQUlMuV29obnNpdHpTdHJhc3NlSGF1c05yIEVMU0UgS0JCLkJlZ3VlbnN0aWd0U3RyY" +
                        "XNzZSBFTkQsDQogICBQTFpPcnQgPSBDQVNFIFdIRU4gS0JCLkJlZ3VlbnN0aWd0T3J0IGlzIE5VTEwgT" +
                        "1IgS0JCLkJlZ3VlbnN0aWd0T3J0ID0gJycgVEhFTiBQUlMuV29obnNpdHpQTFpPcnQgRUxTRSBLQkIuQ" +
                        "mVndWVuc3RpZ3RPcnQgRU5ELA0KICAgUExaID0gUFJTLldvaG5zaXR6UExaLA0KICAgT3J0ID0gUFJTL" +
                        "ldvaG5zaXR6T3J0LA0KDQogICBLQkIuQmVsZWdOciwNCiAgIEVtcGxveWVlTmFtZSA9IFVTUi5MYXN0T" +
                        "mFtZSArIGlzbnVsbCgnLCAnICsgVVNSLkZpcnN0TmFtZSwnJykgKw0KCQkJCQlpc051bGwoJyAoJyArI" +
                        "FVTUi5QaG9uZSArICcpJywnJyksDQogICBLQkIuUmVtYXJrLA0KICAgVmFsdXRhRGF0dW0gPSBLQkIuV" +
                        "mFsdXRhRGF0dW0sDQogICBCYXJiZWxlZ0RhdHVtDQpmcm9tCUZhTGVpc3R1bmcgRkFMDQoJaW5uZXIga" +
                        "m9pbiB2d1BlcnNvbiAgICAgICAgICAgICAgICBQUlMgIG9uIFBSUy5CYVBlcnNvbklEID0gRkFMLkJhU" +
                        "GVyc29uSUQNCglpbm5lciBqb2luIEJnRmluYW56cGxhbiAgICAgICAgICAgIFNGUCAgb24gU0ZQLkZhT" +
                        "GVpc3R1bmdJRCA9IEZBTC5GYUxlaXN0dW5nSUQNCglpbm5lciBqb2luIEJnRmluYW56cGxhbl9CYVBlc" +
                        "nNvbiAgIFNGRCAgb24gU0ZELkJnRmluYW56cGxhbklEID0gU0ZQLkJnRmluYW56cGxhbklEIEFORCBTR" +
                        "kQuSXN0VW50ZXJzdHVldHp0ID0gMQ0KCWlubmVyIGpvaW4gQmdCdWRnZXQgICAgICAgICAgICAgICAgQ" +
                        "kdHICBvbiBCR0cuQmdGaW5hbnpwbGFuSUQgPSBTRlAuQmdGaW5hbnpwbGFuSUQNCglpbm5lciBqb2luI" +
                        "EtiQnVjaHVuZyAgICAgICAgICAgICAgIEtCQiAgb24gS0JCLkJnQnVkZ2V0SUQgPSBCR0cuQmdCdWRnZ" +
                        "XRJRA0KICAgICAgICBpbm5lciBqb2luIEtiQnVjaHVuZ0tvc3RlbmFydCAgICAgIEtCSyAgb24gS0JLL" +
                        "ktiQnVjaHVuZ0lEID0gS0JCLktiQnVjaHVuZ0lEDQoJaW5uZXIgam9pbiBYVVNFUiAgICAgICAgICAgI" +
                        "CAgICAgICBVU1IgIG9uIFVTUi5Vc2VySUQgPSBGQUwuVXNlcklkDQoJbGVmdCAgam9pbiBYVVNFUiAgI" +
                        "CAgICAgICAgICAgICAgICBLVVNSIG9uIEtVU1IuVXNlcklEID0gS0JCLkJhcmJlbGVnVXNlcklEDQoJb" +
                        "GVmdCAgam9pbiBCZ0tvc3RlbmFydAkJICAgQkdLICBvbiBCR0suQmdLb3N0ZW5hcnRJRCA9IEtCSy5CZ" +
                        "0tvc3RlbmFydElEDQoJbGVmdCAgam9pbiBLYktvc3RlbnN0ZWxsZQkgICBCS1MgIG9uIEJLUy5LYktvc" +
                        "3RlbnN0ZWxsZUlEID0gS0JLLktiS29zdGVuc3RlbGxlSUQNCg0Kd2hlcmUgS0JCLkJnQnVkZ2V0SUQgP" +
                        "SBAQmdCdWRnZXRJRA0KICBhbmQgS0JCLktiQXVzemFobHVuZ3NBcnRDb2RlID0gMTA0DQoNCm9yZGVyI" +
                        "GJ5IEtCQi5WYWx1dGFEYXR1bSwgS0JCLktiQnVjaHVuZ0lEQAABAAAA/////wEAAAAAAAAADAIAAAAbR" +
                        "GV2RXhwcmVzcy5YdHJhUmVwb3J0cy52Ni4yBQEAAAAsRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5TZ" +
                        "XJpYWxpemFibGVTdHJpbmcBAAAABVZhbHVlAQIAAAAGAwAAAKgDe1xydGYxXGFuc2lcYW5zaWNwZzEyN" +
                        "TJcZGVmZjB7XGZvbnR0Ymx7XGYwXGZuaWwgQXJpYWw7fXtcZjFcZm5pbFxmY2hhcnNldDAgQXJpYWw7f" +
                        "XtcZjJcZm5pbCBUaW1lcyBOZXcgUm9tYW47fX0NCntcY29sb3J0YmwgO1xyZWQwXGdyZWVuMFxibHVlM" +
                        "Dt9DQpcdmlld2tpbmQ0XHVjMVxwYXJkXGNmMVxsYW5nMTAzMVxmMFxmczM2IFZvbGxtYWNodCBmXGYxX" +
                        "CdmY1xmMCByIEJhcmJlenVnXHBhcg0KXGxhbmcyMDU1XGYxXGZzMjQgSGllcm1pdCBlcnN1Y2hlbiB3a" +
                        "XIgZGllIEJlcm5lcmxhbmQgQmFuayB1bSBlaW5lIEJhcmF1c3phaGx1bmcgenUgTGFzdGVuIFxwYXINC" +
                        "ktvbnRvIE5yLiBcYiAyMi4yNDEuNjAzLjUwOS4zXGIwICBsYXV0ZW5kIGF1ZiBTb3ppYWxkaWVuc3Qgb" +
                        "2JlcmVzIExhbmdldGVudGFsXGNmMFxsYW5nMTAzMVxmMlxwYXINCn0NCgs=";
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
            this.Header_KbBuchungID = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtIntern = new DevExpress.XtraReports.UI.XRLabel();
            this.Label18 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.Label15 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtStrasse = new DevExpress.XtraReports.UI.XRLabel();
            this.FullName1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label14 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.Label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBemerkung = new DevExpress.XtraReports.UI.XRLabel();
            this.Label11 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label9 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtEmployeeName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNameYearMonth = new DevExpress.XtraReports.UI.XRLabel();
            this.txtFullName = new DevExpress.XtraReports.UI.XRLabel();
            this.Label8 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtFlBelegID = new DevExpress.XtraReports.UI.XRLabel();
            this.xrControl1 = new DevExpress.XtraReports.UI.XRControl();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.txtCashOrCheckAm = new DevExpress.XtraReports.UI.XRLabel();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line6 = new DevExpress.XtraReports.UI.XRLine();
            this.Line5 = new DevExpress.XtraReports.UI.XRLine();
            this.Line4 = new DevExpress.XtraReports.UI.XRLine();
            this.Betrag1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label19 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtBetrag,
                        this.txtIntern});
            this.Detail.Height = 29;
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
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // Header_KbBuchungID
            // 
            this.Header_KbBuchungID.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Label18,
                        this.Label16,
                        this.xrRichText1,
                        this.xrTable1,
                        this.Line1,
                        this.Label15,
                        this.txtStrasse,
                        this.FullName1,
                        this.Label14,
                        this.Label3,
                        this.Label2,
                        this.Label1});
            this.Header_KbBuchungID.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("KbBuchungID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.Header_KbBuchungID.Height = 456;
            this.Header_KbBuchungID.Name = "Header_KbBuchungID";
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLine2,
                        this.xrLine1,
                        this.txtCashOrCheckAm,
                        this.Label6,
                        this.Label5,
                        this.xrLabel1,
                        this.Line6,
                        this.Line5,
                        this.Line4,
                        this.Betrag1,
                        this.Label19});
            this.GroupFooter2.Height = 235;
            this.GroupFooter2.Name = "GroupFooter2";
            this.GroupFooter2.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            this.GroupFooter2.PrintAtBottom = true;
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "Fr. {0:n2}")});
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(625, 4);
            this.txtBetrag.Multiline = true;
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(102, 20);
            xrSummary1.FormatString = "{0:0.00}";
            this.txtBetrag.Summary = xrSummary1;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtIntern
            // 
            this.txtIntern.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Buchungstext", "")});
            this.txtIntern.Font = new System.Drawing.Font("Arial", 10F);
            this.txtIntern.ForeColor = System.Drawing.Color.Black;
            this.txtIntern.Location = new System.Drawing.Point(39, 4);
            this.txtIntern.Multiline = true;
            this.txtIntern.Name = "txtIntern";
            this.txtIntern.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtIntern.ParentStyleUsing.UseBackColor = false;
            this.txtIntern.ParentStyleUsing.UseBorderColor = false;
            this.txtIntern.ParentStyleUsing.UseBorders = false;
            this.txtIntern.ParentStyleUsing.UseBorderWidth = false;
            this.txtIntern.ParentStyleUsing.UseFont = false;
            this.txtIntern.ParentStyleUsing.UseForeColor = false;
            this.txtIntern.Size = new System.Drawing.Size(370, 20);
            // 
            // Label18
            // 
            this.Label18.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label18.ForeColor = System.Drawing.Color.Black;
            this.Label18.Location = new System.Drawing.Point(628, 425);
            this.Label18.Name = "Label18";
            this.Label18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label18.ParentStyleUsing.UseBackColor = false;
            this.Label18.ParentStyleUsing.UseBorderColor = false;
            this.Label18.ParentStyleUsing.UseBorders = false;
            this.Label18.ParentStyleUsing.UseBorderWidth = false;
            this.Label18.ParentStyleUsing.UseFont = false;
            this.Label18.ParentStyleUsing.UseForeColor = false;
            this.Label18.Size = new System.Drawing.Size(102, 19);
            this.Label18.Text = "Betrag";
            this.Label18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label16
            // 
            this.Label16.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label16.ForeColor = System.Drawing.Color.Black;
            this.Label16.Location = new System.Drawing.Point(42, 425);
            this.Label16.Name = "Label16";
            this.Label16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label16.ParentStyleUsing.UseBackColor = false;
            this.Label16.ParentStyleUsing.UseBorderColor = false;
            this.Label16.ParentStyleUsing.UseBorders = false;
            this.Label16.ParentStyleUsing.UseBorderWidth = false;
            this.Label16.ParentStyleUsing.UseFont = false;
            this.Label16.ParentStyleUsing.UseForeColor = false;
            this.Label16.Size = new System.Drawing.Size(370, 19);
            this.Label16.Text = "Buchungstext";
            // 
            // xrRichText1
            // 
            this.xrRichText1.BackColor = System.Drawing.Color.Gainsboro;
            this.xrRichText1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrRichText1.Font = new System.Drawing.Font("Arial", 18F);
            this.xrRichText1.Location = new System.Drawing.Point(8, 67);
            this.xrRichText1.Name = "xrRichText1";
            this.xrRichText1.Padding = new DevExpress.XtraPrinting.PaddingInfo(12, 12, 6, 6, 100F);
            this.xrRichText1.ParentStyleUsing.UseBackColor = false;
            this.xrRichText1.ParentStyleUsing.UseBorders = false;
            this.xrRichText1.ParentStyleUsing.UseFont = false;
            this.xrRichText1.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichText1.RtfText")));
            this.xrRichText1.Size = new System.Drawing.Size(737, 83);
            // 
            // xrTable1
            // 
            this.xrTable1.Location = new System.Drawing.Point(8, 175);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow1});
            this.xrTable1.Size = new System.Drawing.Size(737, 100);
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.LineWidth = 2;
            this.Line1.Location = new System.Drawing.Point(8, 408);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(737, 4);
            // 
            // Label15
            // 
            this.Label15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "PLZOrt", "")});
            this.Label15.Font = new System.Drawing.Font("Arial", 10F);
            this.Label15.ForeColor = System.Drawing.Color.Black;
            this.Label15.Location = new System.Drawing.Point(35, 380);
            this.Label15.Name = "Label15";
            this.Label15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label15.ParentStyleUsing.UseBackColor = false;
            this.Label15.ParentStyleUsing.UseBorderColor = false;
            this.Label15.ParentStyleUsing.UseBorders = false;
            this.Label15.ParentStyleUsing.UseBorderWidth = false;
            this.Label15.ParentStyleUsing.UseFont = false;
            this.Label15.ParentStyleUsing.UseForeColor = false;
            this.Label15.Size = new System.Drawing.Size(656, 19);
            this.Label15.Text = "Label15";
            // 
            // txtStrasse
            // 
            this.txtStrasse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Strasse", "")});
            this.txtStrasse.Font = new System.Drawing.Font("Arial", 10F);
            this.txtStrasse.ForeColor = System.Drawing.Color.Black;
            this.txtStrasse.Location = new System.Drawing.Point(35, 360);
            this.txtStrasse.Multiline = true;
            this.txtStrasse.Name = "txtStrasse";
            this.txtStrasse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtStrasse.ParentStyleUsing.UseBackColor = false;
            this.txtStrasse.ParentStyleUsing.UseBorderColor = false;
            this.txtStrasse.ParentStyleUsing.UseBorders = false;
            this.txtStrasse.ParentStyleUsing.UseBorderWidth = false;
            this.txtStrasse.ParentStyleUsing.UseFont = false;
            this.txtStrasse.ParentStyleUsing.UseForeColor = false;
            this.txtStrasse.Size = new System.Drawing.Size(656, 19);
            this.txtStrasse.Text = "Strasse";
            // 
            // FullName1
            // 
            this.FullName1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AuszuzahlenAn", "")});
            this.FullName1.Font = new System.Drawing.Font("Arial", 10F);
            this.FullName1.ForeColor = System.Drawing.Color.Black;
            this.FullName1.Location = new System.Drawing.Point(35, 340);
            this.FullName1.Multiline = true;
            this.FullName1.Name = "FullName1";
            this.FullName1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.FullName1.ParentStyleUsing.UseBackColor = false;
            this.FullName1.ParentStyleUsing.UseBorderColor = false;
            this.FullName1.ParentStyleUsing.UseBorders = false;
            this.FullName1.ParentStyleUsing.UseBorderWidth = false;
            this.FullName1.ParentStyleUsing.UseFont = false;
            this.FullName1.ParentStyleUsing.UseForeColor = false;
            this.FullName1.Size = new System.Drawing.Size(656, 19);
            this.FullName1.Text = "FullName1";
            // 
            // Label14
            // 
            this.Label14.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.Label14.ForeColor = System.Drawing.Color.Black;
            this.Label14.Location = new System.Drawing.Point(35, 308);
            this.Label14.Name = "Label14";
            this.Label14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label14.ParentStyleUsing.UseBackColor = false;
            this.Label14.ParentStyleUsing.UseBorderColor = false;
            this.Label14.ParentStyleUsing.UseBorders = false;
            this.Label14.ParentStyleUsing.UseBorderWidth = false;
            this.Label14.ParentStyleUsing.UseFont = false;
            this.Label14.ParentStyleUsing.UseForeColor = false;
            this.Label14.Size = new System.Drawing.Size(145, 23);
            this.Label14.Text = "Auszahlung an:";
            // 
            // Label3
            // 
            this.Label3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_PLZOrt", "")});
            this.Label3.Font = new System.Drawing.Font("Arial", 11F);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(527, 23);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(217, 23);
            this.Label3.Text = "Org_PLZOrt";
            // 
            // Label2
            // 
            this.Label2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Adresse", "")});
            this.Label2.Font = new System.Drawing.Font("Arial", 11F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(527, 0);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(217, 23);
            this.Label2.Text = "Org_Adresse";
            // 
            // Label1
            // 
            this.Label1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Name", "")});
            this.Label1.Font = new System.Drawing.Font("Arial", 14F);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(8, 0);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(338, 39);
            this.Label1.Text = "Org_Name";
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell1});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Size = new System.Drawing.Size(737, 100);
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.BackColor = System.Drawing.Color.Gainsboro;
            this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Label7,
                        this.xrLabel4,
                        this.xrLabel2,
                        this.xrLabel3,
                        this.txtBemerkung,
                        this.Label11,
                        this.Label9,
                        this.txtEmployeeName,
                        this.txtNameYearMonth,
                        this.txtFullName,
                        this.Label8,
                        this.txtFlBelegID,
                        this.xrControl1});
            this.xrTableCell1.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell1.ParentStyleUsing.UseBackColor = false;
            this.xrTableCell1.ParentStyleUsing.UseBorders = false;
            this.xrTableCell1.Size = new System.Drawing.Size(737, 100);
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(11, 8);
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
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.Location = new System.Drawing.Point(342, 28);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.ParentStyleUsing.UseForeColor = false;
            this.xrLabel4.Size = new System.Drawing.Size(129, 19);
            this.xrLabel4.Text = "Valuta:";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ValutaDatum", "{0:dd.MM.yyyy}")});
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.Location = new System.Drawing.Point(473, 28);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseBackColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorders = false;
            this.xrLabel2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.ParentStyleUsing.UseForeColor = false;
            this.xrLabel2.Size = new System.Drawing.Size(261, 19);
            xrSummary2.FormatString = "{0:dd.MM.yyyy}";
            this.xrLabel2.Summary = xrSummary2;
            this.xrLabel2.Text = "xrLabel2";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(342, 68);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(129, 19);
            this.xrLabel3.Text = "Bemerkungen:";
            // 
            // txtBemerkung
            // 
            this.txtBemerkung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Remark", "")});
            this.txtBemerkung.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBemerkung.ForeColor = System.Drawing.Color.Black;
            this.txtBemerkung.Location = new System.Drawing.Point(473, 68);
            this.txtBemerkung.Multiline = true;
            this.txtBemerkung.Name = "txtBemerkung";
            this.txtBemerkung.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBemerkung.ParentStyleUsing.UseBackColor = false;
            this.txtBemerkung.ParentStyleUsing.UseBorderColor = false;
            this.txtBemerkung.ParentStyleUsing.UseBorders = false;
            this.txtBemerkung.ParentStyleUsing.UseBorderWidth = false;
            this.txtBemerkung.ParentStyleUsing.UseFont = false;
            this.txtBemerkung.ParentStyleUsing.UseForeColor = false;
            this.txtBemerkung.Size = new System.Drawing.Size(261, 19);
            this.txtBemerkung.Text = "txtBemerkung";
            // 
            // Label11
            // 
            this.Label11.Font = new System.Drawing.Font("Arial", 10F);
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(342, 48);
            this.Label11.Name = "Label11";
            this.Label11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label11.ParentStyleUsing.UseBackColor = false;
            this.Label11.ParentStyleUsing.UseBorderColor = false;
            this.Label11.ParentStyleUsing.UseBorders = false;
            this.Label11.ParentStyleUsing.UseBorderWidth = false;
            this.Label11.ParentStyleUsing.UseFont = false;
            this.Label11.ParentStyleUsing.UseForeColor = false;
            this.Label11.Size = new System.Drawing.Size(129, 19);
            this.Label11.Text = "Sozialarbeiter:";
            // 
            // Label9
            // 
            this.Label9.Font = new System.Drawing.Font("Arial", 10F);
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(342, 8);
            this.Label9.Name = "Label9";
            this.Label9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label9.ParentStyleUsing.UseBackColor = false;
            this.Label9.ParentStyleUsing.UseBorderColor = false;
            this.Label9.ParentStyleUsing.UseBorders = false;
            this.Label9.ParentStyleUsing.UseBorderWidth = false;
            this.Label9.ParentStyleUsing.UseFont = false;
            this.Label9.ParentStyleUsing.UseForeColor = false;
            this.Label9.Size = new System.Drawing.Size(129, 19);
            this.Label9.Text = "Auszahlungsmonat:";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "EmployeeName", "")});
            this.txtEmployeeName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtEmployeeName.ForeColor = System.Drawing.Color.Black;
            this.txtEmployeeName.Location = new System.Drawing.Point(473, 48);
            this.txtEmployeeName.Multiline = true;
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtEmployeeName.ParentStyleUsing.UseBackColor = false;
            this.txtEmployeeName.ParentStyleUsing.UseBorderColor = false;
            this.txtEmployeeName.ParentStyleUsing.UseBorders = false;
            this.txtEmployeeName.ParentStyleUsing.UseBorderWidth = false;
            this.txtEmployeeName.ParentStyleUsing.UseFont = false;
            this.txtEmployeeName.ParentStyleUsing.UseForeColor = false;
            this.txtEmployeeName.Size = new System.Drawing.Size(261, 19);
            this.txtEmployeeName.Text = "EmployeeName";
            // 
            // txtNameYearMonth
            // 
            this.txtNameYearMonth.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameYearMonth", "")});
            this.txtNameYearMonth.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNameYearMonth.ForeColor = System.Drawing.Color.Black;
            this.txtNameYearMonth.Location = new System.Drawing.Point(473, 8);
            this.txtNameYearMonth.Multiline = true;
            this.txtNameYearMonth.Name = "txtNameYearMonth";
            this.txtNameYearMonth.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNameYearMonth.ParentStyleUsing.UseBackColor = false;
            this.txtNameYearMonth.ParentStyleUsing.UseBorderColor = false;
            this.txtNameYearMonth.ParentStyleUsing.UseBorders = false;
            this.txtNameYearMonth.ParentStyleUsing.UseBorderWidth = false;
            this.txtNameYearMonth.ParentStyleUsing.UseFont = false;
            this.txtNameYearMonth.ParentStyleUsing.UseForeColor = false;
            this.txtNameYearMonth.Size = new System.Drawing.Size(261, 19);
            this.txtNameYearMonth.Text = "NameYearMonth";
            // 
            // txtFullName
            // 
            this.txtFullName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "FullName", "")});
            this.txtFullName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txtFullName.ForeColor = System.Drawing.Color.Black;
            this.txtFullName.Location = new System.Drawing.Point(75, 35);
            this.txtFullName.Multiline = true;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtFullName.ParentStyleUsing.UseBackColor = false;
            this.txtFullName.ParentStyleUsing.UseBorderColor = false;
            this.txtFullName.ParentStyleUsing.UseBorders = false;
            this.txtFullName.ParentStyleUsing.UseBorderWidth = false;
            this.txtFullName.ParentStyleUsing.UseFont = false;
            this.txtFullName.ParentStyleUsing.UseForeColor = false;
            this.txtFullName.Size = new System.Drawing.Size(265, 27);
            this.txtFullName.Text = "FullName";
            // 
            // Label8
            // 
            this.Label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(11, 35);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(62, 27);
            this.Label8.Text = "Klient :";
            // 
            // txtFlBelegID
            // 
            this.txtFlBelegID.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KbBuchungID", "")});
            this.txtFlBelegID.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txtFlBelegID.ForeColor = System.Drawing.Color.Black;
            this.txtFlBelegID.Location = new System.Drawing.Point(75, 8);
            this.txtFlBelegID.Multiline = true;
            this.txtFlBelegID.Name = "txtFlBelegID";
            this.txtFlBelegID.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtFlBelegID.ParentStyleUsing.UseBackColor = false;
            this.txtFlBelegID.ParentStyleUsing.UseBorderColor = false;
            this.txtFlBelegID.ParentStyleUsing.UseBorders = false;
            this.txtFlBelegID.ParentStyleUsing.UseBorderWidth = false;
            this.txtFlBelegID.ParentStyleUsing.UseFont = false;
            this.txtFlBelegID.ParentStyleUsing.UseForeColor = false;
            this.txtFlBelegID.Size = new System.Drawing.Size(265, 27);
            // 
            // xrControl1
            // 
            this.xrControl1.BackColor = System.Drawing.Color.Gainsboro;
            this.xrControl1.BorderColor = System.Drawing.Color.Black;
            this.xrControl1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrControl1.Location = new System.Drawing.Point(0, 0);
            this.xrControl1.Name = "xrControl1";
            this.xrControl1.ParentStyleUsing.UseBackColor = false;
            this.xrControl1.ParentStyleUsing.UseBorderColor = false;
            this.xrControl1.ParentStyleUsing.UseBorders = false;
            this.xrControl1.ParentStyleUsing.UseBorderWidth = false;
            this.xrControl1.ParentStyleUsing.UseFont = false;
            this.xrControl1.ParentStyleUsing.UseForeColor = false;
            this.xrControl1.Size = new System.Drawing.Size(737, 100);
            // 
            // xrLine2
            // 
            this.xrLine2.ForeColor = System.Drawing.Color.Black;
            this.xrLine2.Location = new System.Drawing.Point(17, 175);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.ParentStyleUsing.UseBackColor = false;
            this.xrLine2.ParentStyleUsing.UseBorderColor = false;
            this.xrLine2.ParentStyleUsing.UseBorders = false;
            this.xrLine2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine2.ParentStyleUsing.UseFont = false;
            this.xrLine2.ParentStyleUsing.UseForeColor = false;
            this.xrLine2.Size = new System.Drawing.Size(300, 4);
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.Location = new System.Drawing.Point(467, 217);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(275, 4);
            // 
            // txtCashOrCheckAm
            // 
            this.txtCashOrCheckAm.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ValutaDatum", "{0:dd.MM.yyyy} (Valuta)")});
            this.txtCashOrCheckAm.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.txtCashOrCheckAm.ForeColor = System.Drawing.Color.Black;
            this.txtCashOrCheckAm.Location = new System.Drawing.Point(142, 200);
            this.txtCashOrCheckAm.Multiline = true;
            this.txtCashOrCheckAm.Name = "txtCashOrCheckAm";
            this.txtCashOrCheckAm.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtCashOrCheckAm.ParentStyleUsing.UseBackColor = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseBorderColor = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseBorders = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseBorderWidth = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseFont = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseForeColor = false;
            this.txtCashOrCheckAm.Size = new System.Drawing.Size(183, 19);
            xrSummary3.FormatString = "{0:dd.MM.yyyy}";
            this.txtCashOrCheckAm.Summary = xrSummary3;
            this.txtCashOrCheckAm.Text = "txtCashOrCheckAm";
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(367, 200);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(100, 19);
            this.Label6.Text = "Unterschrift:";
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(19, 200);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(120, 19);
            this.Label5.Text = "Ausbezahlt am:";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.Location = new System.Drawing.Point(17, 83);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseBackColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.ParentStyleUsing.UseForeColor = false;
            this.xrLabel1.Size = new System.Drawing.Size(208, 19);
            this.xrLabel1.Text = "Unterschrift und Stempel:";
            // 
            // Line6
            // 
            this.Line6.ForeColor = System.Drawing.Color.Black;
            this.Line6.LineWidth = 2;
            this.Line6.Location = new System.Drawing.Point(325, 70);
            this.Line6.Name = "Line6";
            this.Line6.ParentStyleUsing.UseBackColor = false;
            this.Line6.ParentStyleUsing.UseBorderColor = false;
            this.Line6.ParentStyleUsing.UseBorders = false;
            this.Line6.ParentStyleUsing.UseBorderWidth = false;
            this.Line6.ParentStyleUsing.UseFont = false;
            this.Line6.ParentStyleUsing.UseForeColor = false;
            this.Line6.Size = new System.Drawing.Size(402, 2);
            // 
            // Line5
            // 
            this.Line5.ForeColor = System.Drawing.Color.Black;
            this.Line5.LineDirection = DevExpress.XtraReports.UI.LineDirection.BackSlant;
            this.Line5.LineWidth = 2;
            this.Line5.Location = new System.Drawing.Point(1, 14);
            this.Line5.Name = "Line5";
            this.Line5.ParentStyleUsing.UseBackColor = false;
            this.Line5.ParentStyleUsing.UseBorderColor = false;
            this.Line5.ParentStyleUsing.UseBorders = false;
            this.Line5.ParentStyleUsing.UseBorderWidth = false;
            this.Line5.ParentStyleUsing.UseFont = false;
            this.Line5.ParentStyleUsing.UseForeColor = false;
            this.Line5.Size = new System.Drawing.Size(737, 2);
            // 
            // Line4
            // 
            this.Line4.ForeColor = System.Drawing.Color.Black;
            this.Line4.LineWidth = 2;
            this.Line4.Location = new System.Drawing.Point(325, 73);
            this.Line4.Name = "Line4";
            this.Line4.ParentStyleUsing.UseBackColor = false;
            this.Line4.ParentStyleUsing.UseBorderColor = false;
            this.Line4.ParentStyleUsing.UseBorders = false;
            this.Line4.ParentStyleUsing.UseBorderWidth = false;
            this.Line4.ParentStyleUsing.UseFont = false;
            this.Line4.ParentStyleUsing.UseForeColor = false;
            this.Line4.Size = new System.Drawing.Size(402, 2);
            // 
            // Betrag1
            // 
            this.Betrag1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "")});
            this.Betrag1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.Betrag1.ForeColor = System.Drawing.Color.Black;
            this.Betrag1.Location = new System.Drawing.Point(578, 42);
            this.Betrag1.Multiline = true;
            this.Betrag1.Name = "Betrag1";
            this.Betrag1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Betrag1.ParentStyleUsing.UseBackColor = false;
            this.Betrag1.ParentStyleUsing.UseBorderColor = false;
            this.Betrag1.ParentStyleUsing.UseBorders = false;
            this.Betrag1.ParentStyleUsing.UseBorderWidth = false;
            this.Betrag1.ParentStyleUsing.UseFont = false;
            this.Betrag1.ParentStyleUsing.UseForeColor = false;
            this.Betrag1.Size = new System.Drawing.Size(146, 27);
            xrSummary4.FormatString = "Fr. {0:0.00}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.Betrag1.Summary = xrSummary4;
            this.Betrag1.Text = "Betrag1";
            this.Betrag1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label19
            // 
            this.Label19.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.Label19.ForeColor = System.Drawing.Color.Black;
            this.Label19.Location = new System.Drawing.Point(325, 42);
            this.Label19.Name = "Label19";
            this.Label19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label19.ParentStyleUsing.UseBackColor = false;
            this.Label19.ParentStyleUsing.UseBorderColor = false;
            this.Label19.ParentStyleUsing.UseBorders = false;
            this.Label19.ParentStyleUsing.UseBorderWidth = false;
            this.Label19.ParentStyleUsing.UseFont = false;
            this.Label19.ParentStyleUsing.UseForeColor = false;
            this.Label19.Size = new System.Drawing.Size(251, 27);
            this.Label19.Text = "Auszuzahlender Betrag :";
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.Position = 0;
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail,
                        this.PageHeader,
                        this.PageFooter,
                        this.Header_KbBuchungID,
                        this.GroupFooter2});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(39, 39, 39, 39);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' , ParameterXML =  N'<?xml version="1.0" standalone="yes" ?>
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
</NewDataSet>' , SQLquery =  N'declare @BgBudgetID int
set @BgBudgetID = {BgBudgetID} -- (TestCase)428108

select distinct
   Org_Name    = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Organisation'', Getdate())), ''''),
   Org_Adresse = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Adresse'', Getdate())), ''''),
   Org_PLZ     = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', Getdate())), ''''),
   Org_Ort     = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', Getdate())), ''''),
   Org_PLZOrt  = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', Getdate())) + '' '', '''')
                + IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', Getdate())), ''''),
   KBB.KbAuszahlungsartCode,
   KBB.KbBuchungID,
   KBB.KbBuchungStatusCode,
   NameKbBuchungsStatus = dbo.fnLOVText(''KbBuchungsStatus'', KBB.KbBuchungStatusCode),
   NameKbAuszahlungsArt    = dbo.fnLOVText(''KbAuszahlungsArt'', KBB.KbAuszahlungsartCode),
   NameYearMonth     = dbo.fnXMonat(BGG.Monat) + '' '' + Convert(varchar, BGG.Jahr),
   Verfalldatum = DATEADD(DAY, 5, KBB.ValutaDatum),
   KBK.KbBuchungKostenartID,
   KBK.Buchungstext,
   Betrag = KBK.Betrag,
   NameKostenart = BGK.Name,
   NameKostenstelle = BKS.Name,
   KBKPersonID = KBK.BaPersonID,    	
   NameKassier = KUSR.LastName + isnull('', '' + KUSR.FirstName,'''') +
					isNull('' ('' + KUSR.Phone + '')'',''''),
   FullName = PRS.NameVorname,
   AuszuzahlenAn = CASE WHEN KBB.BeguenstigtName is NULL OR KBB.BeguenstigtName = '''' THEN PRS.NameVorname ELSE KBB.BeguenstigtName END,
   Strasse  = CASE WHEN KBB.BeguenstigtStrasse is NULL OR KBB.BeguenstigtStrasse = '''' THEN PRS.WohnsitzStrasseHausNr ELSE KBB.BeguenstigtStrasse END,
   PLZOrt = CASE WHEN KBB.BeguenstigtOrt is NULL OR KBB.BeguenstigtOrt = '''' THEN PRS.WohnsitzPLZOrt ELSE KBB.BeguenstigtOrt END,
   PLZ = PRS.WohnsitzPLZ,
   Ort = PRS.WohnsitzOrt,

   KBB.BelegNr,
   EmployeeName = USR.LastName + isnull('', '' + USR.FirstName,'''') +
					isNull('' ('' + USR.Phone + '')'',''''),
   KBB.Remark,
   ValutaDatum = KBB.ValutaDatum,
   BarbelegDatum
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

where KBB.BgBudgetID = @BgBudgetID
  and KBB.KbAuszahlungsArtCode = 104

order by KBB.ValutaDatum, KBB.KbBuchungID' , ContextForms =  N'WhMonatsbudget' , ParentReportName =  null , ReportSortKey = 10
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'ShVollmachtBarbezug' ;


