-- Insert Script for KbSaldolisteKreditoren
-- MD5:0XA9BF3A393D6EAF9DD25514C49B22794E_0XC6BAA1565AF0EE4D328EA0C8C9BE4806_0X454ED33E19355C49530D60C401A09479
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'KbSaldolisteKreditoren') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('KbSaldolisteKreditoren', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'KbSaldolisteKreditoren';
--SQLCHECK_IGNORE--
UPDATE QRY
SET QueryName =  N'KbSaldolisteKreditoren' , UserText =  N'KB - Saldoliste Kreditoren' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\Kiss40\KiSS\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\Kiss40\KiSS\Build\Debug\Kiss.Interfaces.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\Projects\Kiss40\KiSS\Build\Debug\FluentValidation.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\Projects\Kiss40\KiSS\Build\Debug\StructureMap.dll" />
///     <Reference Path="C:\Projects\Kiss40\KiSS\Build\Debug\log4net.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Projects\Kiss40\KiSS\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
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
                        "AAAAe8UREVDTEFSRSBAS2JQZXJpb2RlSUQgSU5UDQpERUNMQVJFIEBCZWxlZ05yVm9uICBJTlQNCkRFQ" +
                        "0xBUkUgQEJlbGVnTnJCaXMgIElOVA0KREVDTEFSRSBAVmFsdXRhRGF0dW0gIERBVEVUSU1FDQoNCg0KU" +
                        "0VUIEBLYlBlcmlvZGVJRCA9IG51bGwgICAgIC0tMzAtLQ0KU0VUIEBCZWxlZ05yVm9uICA9IGlzTnVsb" +
                        "ChudWxsLDApDQpTRVQgQEJlbGVnTnJCaXMgID0gaXNOdWxsKG51bGwsIDk5OTk5OSkNClNFVCBAVmFsd" +
                        "XRhRGF0dW0gPSBpc051bGwobnVsbCwgR0VUREFURSgpKQ0KDQpTRUxFQ1QNCiAgICAgSW5zdE5hbWUgI" +
                        "CAgPSBJU05VTEwoQ09OVkVSVChWQVJDSEFSKDIwMCksIGRiby5mblhDb25maWcoJ1NvemlhbERpZW5zd" +
                        "FxBbGxnZW1laW5cTmFtZScsIEdFVERBVEUoKSkpLCAnW2tlaW4gSW5zdGl0dXRpb25zbmFtZV0nKSwNC" +
                        "iAgICAgSW5zdFN0cmFzc2UgPSBJU05VTEwoQ09OVkVSVChWQVJDSEFSKDIwMCksIGRiby5mblhDb25ma" +
                        "WcoJ1NvemlhbERpZW5zdFxBbGxnZW1laW5cQWRyZXNzZScsIEdFVERBVEUoKSkpLCAnJyksDQogICAgI" +
                        "Eluc3RQTFpPcnQgID0gSVNOVUxMKENPTlZFUlQoVkFSQ0hBUigyMDApLCBkYm8uZm5YQ29uZmlnKCdTb" +
                        "3ppYWxEaWVuc3RcQWxsZ2VtZWluXFBMWicsIEdFVERBVEUoKSkpICsgJyAnLCAnJykgKw0KICAgICAgI" +
                        "CAgICAgICAgICAgIElTTlVMTChDT05WRVJUKFZBUkNIQVIoMjAwKSwgZGJvLmZuWENvbmZpZygnU296a" +
                        "WFsRGllbnN0XEFsbGdlbWVpblxPcnQnLCBHRVREQVRFKCkpKSArICcgJywgJycpLA0KICAgICBQYXJhb" +
                        "WV0ZXIgPSAnQmVsZWdudW1tZXIgJyArIENPTlZFUlQoVkFSQ0hBUigyMCksIEBCZWxlZ05yVm9uKSArI" +
                        "CcgLSAnICsgQ09OVkVSVChWQVJDSEFSKDIwKSwgQEJlbGVnTnJCaXMpICsgJywgJyANCiAgICAgICAgI" +
                        "CAgICAgICsgJ1N0aWNoZGF0dW0gJyArIENPTlZFUlQoVkFSQ0hBUigyMCksIEBWYWx1dGFEYXR1bSwgM" +
                        "TA0KSwNCiAgICAgRHJ1Y2tEYXR1bSA9ICdEcnVja2RhdHVtICcgKyBDT05WRVJUKFZBUkNIQVIoMjApL" +
                        "CBHRVREQVRFKCksIDEwNCksDQogICAgIEtyZWRpdG9yICAgID0gSVNOVUxMKEJBWi5CYVBlcnNvbklEL" +
                        "CBCQVouQmFJbnN0aXR1dGlvbklEKSwNCiAgICAgUGVyc29uICAgICAgPSBDT05WRVJUKEJJVCwgQ0FTR" +
                        "SBXSEVOIEJBWi5CYVBlcnNvbklEIElTIE5VTEwgVEhFTiAwIEVMU0UgMSBFTkQpLA0KICAgICBbTmFtZ" +
                        "V0JID0gSVNOVUxMKEJBWi5QZXJzb25OYW1lVm9ybmFtZSwgQkFaLkluc3RpdHV0aW9uTmFtZSksDQogI" +
                        "CAgIEJldHJhZyAgICAgID0gQlVDLkJldHJhZywNCiAgICAgQmVsZWdOciAgICAgPSBCVUMuQmVsZWdOc" +
                        "iwNCiAgICAgRXh0ZXJuICAgICAgPSBCVUMuTWl0dGVpbHVuZ1plaWxlMSwNCiAgICAgVmFsdXRhRGF0d" +
                        "W0gPSBCVUMuVmFsdXRhRGF0dW0sDQogICAgIEJlbGVnTnJWb24gID0gQEJlbGVnTnJWb24sDQogICAgI" +
                        "EJlbGVnTnJCaXMgID0gQEJlbGVnTnJCaXMsDQogICAgIHVudGlsVmFsdXRhID0gQFZhbHV0YURhdHVtL" +
                        "A0KICAgICBUZXh0ICAgICAgICA9IEJVQy5UZXh0LA0KICAgICBJbWFnZSAgICAgICA9IElDTy5JY29uD" +
                        "QpGUk9NIGRiby5LYkJ1Y2h1bmcgIEJVQyBXSVRIIChSRUFEVU5DT01NSVRURUQpDQogIElOTkVSIEpPS" +
                        "U4gZGJvLktiS29udG8gICAgS0JLIFdJVEggKFJFQURVTkNPTU1JVFRFRCkNCiAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICBPTiBLQksuS2JQZXJpb2RlSUQgICAgICAgID0gQlVDLktiUGVyaW9kZUlEDQogICAgI" +
                        "CAgICAgICAgICAgICAgICAgIEFORCAoS0JLLktvbnRvTnIgPSBCVUMuSGFiZW5LdG9OciBPUiBLQksuS" +
                        "29udG9OciA9IEJVQy5Tb2xsS3RvTnIpDQogIExFRlQgIEpPSU4gZGJvLnZ3S3JlZGl0b3IgQkFaIE9OI" +
                        "EJBWi5CYVphaGx1bmdzd2VnSUQgICAgPSBCVUMuQmFaYWhsdW5nc3dlZ0lEDQogIElOTkVSIEpPSU4gZ" +
                        "GJvLlhMT1ZDb2RlICAgTE9WIFdJVEggKFJFQURVTkNPTU1JVFRFRCkNCiAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICBPTiBMT1YuQ29kZSA9IEJVQy5LYkJ1Y2h1bmdTdGF0dXNDb2RlIEFORCBMT1YuTE9WTmFtZ" +
                        "SA9ICdLYkJ1Y2h1bmdzU3RhdHVzJw0KICBJTk5FUiBKT0lOIGRiby5YSWNvbiAgICAgIElDTyBXSVRII" +
                        "ChSRUFEVU5DT01NSVRURUQpDQogICAgICAgICAgICAgICAgICAgICAgICAgT04gSUNPLlhJY29uSUQgP" +
                        "SBMT1YuVmFsdWUxDQpXSEVSRSAxPTENCiAgICBBTkQgQlVDLktiQnVjaHVuZ0lEIElOIChTRUxFQ1QgR" +
                        "ElTVElOQ1QgS2JCdWNodW5nSUQgRlJPTSBkYm8uZm5LYkdldFJlbGV2YW50ZUJ1Y2h1bmdlbihAS2JQZ" +
                        "XJpb2RlSUQsIE5VTEwsIE5VTEwsIDAsIDApKQ0KICAgIEFORCBCVUMuS2JCdWNodW5nU3RhdHVzQ29kZ" +
                        "SBpbiAoMyw1LDEzKSAtLTUgWmFobGF1ZnRyYWcgZmVobGVyaGFmdCwgMyBaYWhsYXVmdHJhZyBlcnN0Z" +
                        "WxsdCB1bmQgMTMgdmVyYnVjaHQNCiAgICBBTkQgJywnICsgIEtCSy5rYmtvbnRvYXJ0Y29kZXMgKyAnL" +
                        "CcgTElLRSAnJSwzMCwlJw0KICAgIEFORCBCVUMuS2JQZXJpb2RlSUQgID0gQEtiUGVyaW9kZUlEDQogI" +
                        "CAgQU5EIEJVQy5CZWxlZ05yICAgICA+PSBAQmVsZWdOclZvbg0KICAgIEFORCBCVUMuQmVsZWdOciAgI" +
                        "CAgPD0gQEJlbGVnTnJCaXMNCiAgICBBTkQgQlVDLlZhbHV0YURhdHVtICA8PSBAVmFsdXRhRGF0dW0NC" +
                        "k9SREVSIEJZIE5hbWUsIEtyZWRpdG9yLCBCVUMuQmVsZWdOcg==";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel22,
                        this.xrLabel12,
                        this.xrLabel16,
                        this.xrLabel15,
                        this.xrLabel11});
            this.Detail.Height = 17;
            this.Detail.Name = "Detail";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel10,
                        this.xrLabel9});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("Kreditor", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
                        new DevExpress.XtraReports.UI.GroupField("Name", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
                        new DevExpress.XtraReports.UI.GroupField("Person", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 19;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel14,
                        this.xrLabel13});
            this.GroupFooter1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupFooter1.Height = 20;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.ParentStyleUsing.UseFont = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel18,
                        this.xrLabel17,
                        this.xrLabel8,
                        this.xrLabel6,
                        this.xrLabel4,
                        this.xrLabel1,
                        this.xrLabel2,
                        this.xrLabel3,
                        this.xrLabel5,
                        this.xrLabel7});
            this.PageHeader.Height = 189;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageInfo1,
                        this.xrLabel19});
            this.PageFooter.Height = 26;
            this.PageFooter.Name = "PageFooter";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel21,
                        this.xrLabel20});
            this.ReportFooter.Height = 20;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrLabel22
            // 
            this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text", "")});
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.KeepTogether = true;
            this.xrLabel22.Location = new System.Drawing.Point(508, 0);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.ParentStyleUsing.UseFont = false;
            this.xrLabel22.Size = new System.Drawing.Size(317, 17);
            this.xrLabel22.Text = "xrLabel22";
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:#.00}")});
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.Location = new System.Drawing.Point(825, 0);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.ParentStyleUsing.UseFont = false;
            this.xrLabel12.Size = new System.Drawing.Size(142, 17);
            this.xrLabel12.Text = "xrLabel12";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ValutaDatum", "{0:dd.MM.yyyy}")});
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel16.Location = new System.Drawing.Point(408, 0);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.ParentStyleUsing.UseFont = false;
            this.xrLabel16.Size = new System.Drawing.Size(100, 17);
            this.xrLabel16.Text = "xrLabel16";
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Extern", "")});
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel15.Location = new System.Drawing.Point(125, 0);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.ParentStyleUsing.UseFont = false;
            this.xrLabel15.Size = new System.Drawing.Size(275, 17);
            this.xrLabel15.Text = "xrLabel15";
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BelegNr", "")});
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.Location = new System.Drawing.Point(25, 0);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.ParentStyleUsing.UseFont = false;
            this.xrLabel11.Size = new System.Drawing.Size(83, 17);
            this.xrLabel11.Text = "xrLabel11";
            // 
            // xrLabel10
            // 
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.Location = new System.Drawing.Point(92, 0);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.ParentStyleUsing.UseFont = false;
            this.xrLabel10.Size = new System.Drawing.Size(316, 17);
            this.xrLabel10.Text = "xrLabel10";
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Kreditor", "")});
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.Location = new System.Drawing.Point(0, 0);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.Size = new System.Drawing.Size(75, 17);
            this.xrLabel9.Text = "xrLabel9";
            // 
            // xrLabel14
            // 
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.Location = new System.Drawing.Point(408, 0);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.ParentStyleUsing.UseFont = false;
            this.xrLabel14.Size = new System.Drawing.Size(100, 17);
            this.xrLabel14.Text = "Total";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:#.00}")});
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.Location = new System.Drawing.Point(825, 0);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.ParentStyleUsing.UseBackColor = false;
            this.xrLabel13.ParentStyleUsing.UseFont = false;
            this.xrLabel13.Size = new System.Drawing.Size(142, 17);
            xrSummary1.FormatString = "{0:#.00}";
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel13.Summary = xrSummary1;
            this.xrLabel13.Text = "xrLabel12";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel18
            // 
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "InstPLZOrt", "")});
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.Location = new System.Drawing.Point(0, 50);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.ParentStyleUsing.UseFont = false;
            this.xrLabel18.Size = new System.Drawing.Size(600, 25);
            this.xrLabel18.Text = "xrLabel18";
            // 
            // xrLabel17
            // 
            this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "InstStrasse", "")});
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel17.Location = new System.Drawing.Point(0, 25);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.ParentStyleUsing.UseFont = false;
            this.xrLabel17.Size = new System.Drawing.Size(600, 25);
            this.xrLabel17.Text = "xrLabel17";
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Parameter", "")});
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.Location = new System.Drawing.Point(8, 125);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.Size = new System.Drawing.Size(959, 17);
            this.xrLabel8.Text = "xrLabel8";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "InstName", "")});
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.Location = new System.Drawing.Point(0, 0);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.Size = new System.Drawing.Size(600, 25);
            this.xrLabel6.Text = "xrLabel6";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.Location = new System.Drawing.Point(608, 92);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(359, 25);
            this.xrLabel4.Text = "Offene Posten Kreditoren";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.Location = new System.Drawing.Point(0, 150);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(125, 33);
            this.xrLabel1.Text = "Kreditor\r\n     Beleg";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.Location = new System.Drawing.Point(125, 150);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(283, 33);
            this.xrLabel2.Text = "Extern";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.Location = new System.Drawing.Point(408, 150);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(100, 33);
            this.xrLabel3.Text = "Valuta";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.Location = new System.Drawing.Point(508, 150);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(317, 33);
            this.xrLabel5.Text = "Text";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.Location = new System.Drawing.Point(825, 150);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.Size = new System.Drawing.Size(142, 33);
            this.xrLabel7.Text = "Betrag";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.Format = "Seite {0} von {1}";
            this.xrPageInfo1.Location = new System.Drawing.Point(825, 0);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(142, 25);
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel19
            // 
            this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "DruckDatum", "")});
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel19.Location = new System.Drawing.Point(0, 0);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.ParentStyleUsing.UseFont = false;
            this.xrLabel19.Size = new System.Drawing.Size(367, 25);
            this.xrLabel19.Text = "xrLabel19";
            // 
            // xrLabel21
            // 
            this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "")});
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel21.Location = new System.Drawing.Point(825, 0);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.ParentStyleUsing.UseBackColor = false;
            this.xrLabel21.ParentStyleUsing.UseFont = false;
            this.xrLabel21.Size = new System.Drawing.Size(142, 17);
            xrSummary2.FormatString = "{0:#.00}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel21.Summary = xrSummary2;
            this.xrLabel21.Text = "xrLabel21";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.Location = new System.Drawing.Point(408, 0);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.ParentStyleUsing.UseFont = false;
            this.xrLabel20.Size = new System.Drawing.Size(134, 17);
            this.xrLabel20.Text = "Ausdruckstotal";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
                        this.GroupFooter1,
                        this.PageHeader,
                        this.PageFooter,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Name = "Report";
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4Rotated;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' , ParameterXML =  N'<?xml version="1.0" standalone="yes" ?>
<NewDataSet>
	<Table>
		<FieldName>label</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>KbPeriodeID:</DisplayText>
		<TabPosition>0</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
	<Table>
		<FieldName>KbPeriodeID</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>KbPeriodeID</DisplayText>
		<TabPosition>20</TabPosition>
		<X>120</X>
		<Y>60</Y>
		<Width>95</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
	<Table>
		<FieldName>label</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Beleg-Datum:</DisplayText>
		<TabPosition>0</TabPosition>
		<X>10</X>
		<Y>90</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
	<Table>
        	<FieldName>DatumBis</FieldName>
	        <FieldCode>5</FieldCode>
        	<DisplayText>Beleg-Datum</DisplayText>
	        <TabPosition>1</TabPosition>
        	<X>120</X>
	        <Y>90</Y>
        	<Width>80</Width>
	        <Height>25</Height>
	</Table>
	<Table>
		<FieldName>label</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>BelegNr von:</DisplayText>
		<TabPosition>0</TabPosition>
		<X>10</X>
		<Y>120</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
	<Table>
        	<FieldName>BelegNrVon</FieldName>
	        <FieldCode>4</FieldCode>
        	<DisplayText>Beleg-Nr Von</DisplayText>
	        <TabPosition>2</TabPosition>
        	<X>120</X>
		<Y>120</Y>
        	<Width>95</Width>
	        <Height>25</Height>
	</Table>
	<Table>
		<FieldName>label</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>bis:</DisplayText>
		<TabPosition>0</TabPosition>
		<X>230</X>
		<Y>120</Y>
		<Width>40</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
	<Table>
        	<FieldName>BelegNrBis</FieldName>
	        <FieldCode>4</FieldCode>
        	<DisplayText>Beleg-Nr bis</DisplayText>
	        <TabPosition>2</TabPosition>
        	<X>255</X>
		<Y>120</Y>
        	<Width>95</Width>
	        <Height>25</Height>
        	<Mandatory>false</Mandatory>
	</Table>
</NewDataSet>' , SQLquery =  N'DECLARE @KbPeriodeID INT;
DECLARE @BelegNrVon  INT;
DECLARE @BelegNrBis  INT;
DECLARE @ValutaDatum  DATETIME;

SET @KbPeriodeID = {kbPeriodeID};
SET @BelegNrVon  = {BelegNrVon};
SET @BelegNrBis  = {BelegNrBis};
SET @ValutaDatum = ISNULL({DatumBis}, GETDATE());

DECLARE @KreditorenKonto VARCHAR(10);
SELECT @KreditorenKonto = KontoNr 
FROM dbo.KbKonto WITH (READUNCOMMITTED)
WHERE KbPeriodeID = @KbPeriodeID
  AND '','' + KbKontoArtCodes + '','' LIKE ''%,30,%'';

SELECT
  InstName      = ISNULL(CONVERT(VARCHAR(200), dbo.fnXConfig(''SozialDienst\Allgemein\Name'', GETDATE())), ''[kein Institutionsname]''),
  InstStrasse   = ISNULL(CONVERT(VARCHAR(200), dbo.fnXConfig(''SozialDienst\Allgemein\Adresse'', GETDATE())), ''''),
  InstPLZOrt    = ISNULL(CONVERT(VARCHAR(200), dbo.fnXConfig(''SozialDienst\Allgemein\PLZ'', GETDATE())) + '' '', '''')
                  + ISNULL(CONVERT(VARCHAR(200), dbo.fnXConfig(''SozialDienst\Allgemein\Ort'', GETDATE())) + '' '', ''''),
  Parameter     = ''Belegnummer '' + ISNULL(CONVERT(VARCHAR(20), @BelegNrVon), '''') + '' - '' + ISNULL(CONVERT(VARCHAR(20), @BelegNrBis), '''') + '', '' 
                  + ''Stichdatum '' + CONVERT(VARCHAR(20), @ValutaDatum, 104),
  DruckDatum    = ''Druckdatum '' + CONVERT(VARCHAR(20), GETDATE(), 104),
  Kreditor      = ISNULL(BAZ.BaPersonID, BAZ.BaInstitutionID),
  Person        = CONVERT(BIT, CASE WHEN BAZ.BaPersonID IS NULL THEN 0 ELSE 1 END),
  [Name]        = ISNULL(BAZ.PersonNameVorname, BAZ.InstitutionName),
  Betrag        = CASE WHEN BUC.HabenKtoNr = @KreditorenKonto THEN BUC.Betrag ELSE -BUC.Betrag END,
  BelegNr       = BUC.BelegNr,
  Extern        = BUC.MitteilungZeile1,
  ValutaDatum   = BUC.ValutaDatum,
  BelegNrVon    = @BelegNrVon,
  BelegNrBis    = @BelegNrBis,
  untilValuta   = @ValutaDatum,
  [Text]        = BUC.[Text],
  [Image]       = ICO.Icon
FROM dbo.KbBuchung             BUC WITH (READUNCOMMITTED)
  INNER JOIN dbo.KbKonto       KBK WITH (READUNCOMMITTED) ON KBK.KbPeriodeID = BUC.KbPeriodeID
                                                         AND (KBK.KontoNr = BUC.HabenKtoNr OR KBK.KontoNr = BUC.SollKtoNr)
  LEFT  JOIN dbo.vwKreditor    BAZ WITH (READUNCOMMITTED) ON BAZ.BaZahlungswegID = BUC.BaZahlungswegID
  INNER JOIN dbo.XLOVCode      LOV WITH (READUNCOMMITTED) ON LOV.Code = BUC.KbBuchungStatusCode 
                                                         AND LOV.LOVName = ''KbBuchungsStatus''
  INNER JOIN dbo.XIcon         ICO WITH (READUNCOMMITTED) ON ICO.XIconID = LOV.Value1
  LEFT  JOIN dbo.KbOpAusgleich OPA WITH (READUNCOMMITTED) ON OPA.OpBuchungID = BUC.KbBuchungID
  LEFT  JOIN dbo.KbBuchung     AUS WITH (READUNCOMMITTED) ON AUS.KbBuchungID = OPA.AusgleichBuchungID
WHERE BUC.KbPeriodeID  = @KbPeriodeID
  AND BUC.KbBuchungID IN (SELECT DISTINCT KbBuchungID FROM dbo.fnKbGetRelevanteBuchungen(@KbPeriodeID, NULL, NULL, 0, 0))
  AND (BUC.KbBuchungStatusCode IN (3, 5, 13) --5 Zahlauftrag fehlerhaft, 3 Zahlauftrag erstellt und 13 verbucht
       OR BUC.KbBuchungStatusCode = 6 AND AUS.KbPeriodeID <> BUC.KbPeriodeID) --#7341 nicht in selber Periode ausgeglichene anzeigen
  AND KBK.KontoNr = @KreditorenKonto
  AND (@BelegNrVon IS NULL OR BUC.BelegNr >= @BelegNrVon)
  AND (@BelegNrBis IS NULL OR BUC.BelegNr <= @BelegNrBis)
  AND BUC.ValutaDatum  <= @ValutaDatum
ORDER BY Name, Kreditor, BUC.BelegNr;' , ContextForms =  N'CtlQueryKbSaldolisteKreditoren' , ParentReportName =  null , ReportSortKey =  null 
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'KbSaldolisteKreditoren' ;


