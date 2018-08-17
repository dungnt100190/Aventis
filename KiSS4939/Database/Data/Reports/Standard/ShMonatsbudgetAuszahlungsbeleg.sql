-- Insert Script for ShMonatsbudgetAuszahlungsbeleg
-- MD5:0XD93532CD9939F512C25B1047FD0BA00F_0X0ADF4580439533DD6350CC8EA9813309_0X0FAFA284CE268BC6018ABA3E0880D942
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'ShMonatsbudgetAuszahlungsbeleg') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('ShMonatsbudgetAuszahlungsbeleg', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'ShMonatsbudgetAuszahlungsbeleg';
--SQLCHECK_IGNORE--
UPDATE QRY
SET QueryName =  N'ShMonatsbudgetAuszahlungsbeleg' , UserText =  N'SH - Monatsbudget Auszahlungsbeleg (mehrsprachig)' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>en-US</Localization>
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
///     <Reference Path="C:\KiSS\KiSS4\KiSS4.DB.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.Interfaces.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Microsoft.Practices.Unity.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\KiSS\KiSS4\FluentValidation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="C:\KiSS\KiSS4\log4net.dll" />
///     <Reference Path="C:\KiSS\KiSS4\SharpLibrary.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel lblStatus;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel lblGedrucktDatum;
        private DevExpress.XtraReports.UI.Subreport ShMonatsbudgetAuszahlungsbeleg_Detail;
        private DevExpress.XtraReports.UI.XRLabel lblOrgName;
        private DevExpress.XtraReports.UI.XRLabel lblOrgAdresse;
        private DevExpress.XtraReports.UI.XRLabel lblOrgOrt;
        private DevExpress.XtraReports.UI.XRLabel lblNameSar;
        private DevExpress.XtraReports.UI.XRLabel lblName;
        private DevExpress.XtraReports.UI.XRLabel lblStrasse;
        private DevExpress.XtraReports.UI.XRLabel lblOrt;
        private DevExpress.XtraReports.UI.XRLabel lblMonatsbudgetTitle;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPageInfo piOrgOrtDatum;
        private DevExpress.XtraReports.UI.XRLabel lblSeite;
        private DevExpress.XtraReports.UI.XRPageInfo piSeite;
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
                        "FJlcG9ydC5HZXRDdXJyZW50Q29sdW1uVmFsdWUoIk9yZ19PcnQiKS5Ub1N0cmluZygpKTsNCn0BxBVER" +
                        "UNMQVJFIEBCZ0J1ZGdldElkIElOVDsNClNFVCBAQmdCdWRnZXRJZCA9IG51bGw7DQoNCkRFQ0xBUkUgQ" +
                        "Exhbmd1YWdlQ29kZSBJTlQ7DQoNCi0tIFNwcmFjaGNvZGUgZGVzIEtsaWVudGVuIGVydWllcmVuLg0KU" +
                        "0VMRUNUIEBMYW5ndWFnZUNvZGUgPSBQUlMuVmVyc3RhZW5kaWd1bmdTcHJhY2hDb2RlDQpGUk9NIGRib" +
                        "y5CZ0J1ZGdldCAgICAgICAgICAgIEJERyBXSVRIIChSRUFEVU5DT01NSVRURUQpDQogSU5ORVIgSk9JT" +
                        "iBkYm8uQmdGaW5hbnpwbGFuIEZQTCBXSVRIIChSRUFEVU5DT01NSVRURUQpIE9OIEZQTC5CZ0ZpbmFue" +
                        "nBsYW5JRCA9IEJERy5CZ0ZpbmFuenBsYW5JRA0KIElOTkVSIEpPSU4gZGJvLkZhTGVpc3R1bmcgICBMR" +
                        "UkgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKSBPTiBMRUkuRmFMZWlzdHVuZ0lEICAgPSBGUEwuRmFMZWlzd" +
                        "HVuZ0lEDQogSU5ORVIgSk9JTiBkYm8uQmFQZXJzb24gICAgIFBSUyBXSVRIIChSRUFEVU5DT01NSVRUR" +
                        "UQpIE9OIFBSUy5CYVBlcnNvbklEICAgICA9IExFSS5CYVBlcnNvbklEDQpXSEVSRSBCREcuQmdCdWRnZ" +
                        "XRJRCA9ICBAQmdCdWRnZXRJZDsNCiANCi0tIERlZmF1bHRzcHJhY2hlIERFDQpJRiBATGFuZ3VhZ2VDb" +
                        "2RlIElTIE5VTEwNCkJFR0lODQogIFNFVCBATGFuZ3VhZ2VDb2RlID0gMTsNCkVORDsNCg0KU0VMRUNUD" +
                        "QogIE9yZ19OYW1lICAgICAgPSBJU05VTEwoQ09OVkVSVCh2YXJjaGFyKDEwMDApLCBkYm8uZm5YQ29uZ" +
                        "mlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxPcmdhbmlzYXRpb24nLCBHRVREQVRFKCkpKSwgJ" +
                        "ycpLA0KICBPcmdfQWRyZXNzZSAgID0gSVNOVUxMKENPTlZFUlQodmFyY2hhcigxMDAwKSwgZGJvLmZuW" +
                        "ENvbmZpZygnU3lzdGVtXEFkcmVzc2VcU296aWFsaGlsZmVcQWRyZXNzZScsIEdFVERBVEUoKSkpLCAnJ" +
                        "yksDQogIE9yZ19QTFogICAgICAgPSBJU05VTEwoQ09OVkVSVCh2YXJjaGFyKDEwMDApLCBkYm8uZm5YQ" +
                        "29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxQTFonLCBHRVREQVRFKCkpKSwgJycpLA0KI" +
                        "CBPcmdfT3J0ICAgICAgID0gSVNOVUxMKENPTlZFUlQodmFyY2hhcigxMDAwKSwgZGJvLmZuWENvbmZpZ" +
                        "ygnU3lzdGVtXEFkcmVzc2VcU296aWFsaGlsZmVcT3J0JywgR0VUREFURSgpKSksICcnKSwNCiAgT3JnX" +
                        "1BMWk9ydCAgICA9IElTTlVMTChDT05WRVJUKHZhcmNoYXIoMTAwMCksIGRiby5mblhDb25maWcoJ1N5c" +
                        "3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlXFBMWicsIEdFVERBVEUoKSkpICsgJyAnLCAnJykNCiAgICAgI" +
                        "CAgICAgICAgICAgICsgSVNOVUxMKENPTlZFUlQodmFyY2hhcigxMDAwKSwgZGJvLmZuWENvbmZpZygnU" +
                        "3lzdGVtXEFkcmVzc2VcU296aWFsaGlsZmVcT3J0JywgR0VUREFURSgpKSksICcnKSwgDQogIEJnQnVkZ" +
                        "2V0SUQgICAgPSBCREcuQmdCdWRnZXRJRCwgICAgICAgICAgICAgICAgICAgICAgICAgICAgIA0KICBBd" +
                        "XN6YWhsdW5nc0JlbGVnRGF0dW0gID0gIGRiby5mbkdldE1MVGV4dEZyb21OYW1lKCdTSC1Nb25hdHNid" +
                        "WRnZXQgQXVzemFobGJlbGVnJywgJ1RleHRBdXN6YWhsdW5nc2JlbGVnJywgQExhbmd1YWdlQ29kZSkgK" +
                        "yAnICcgKw0KICAgICAgICAgICAgICAgICAgICAgICAgICAgIGRiby5mbkdldExPVk1MVGV4dCgnTW9uY" +
                        "XQnLCBNT05USChCREcuTW9uYXQpLCBATGFuZ3VhZ2VDb2RlKSArICcgJyArIENPTlZFUlQoVkFSQ0hBU" +
                        "ixCREcuSmFociksDQogIEJ1ZGdldFN0YXR1cyAgPSBkYm8uZm5HZXRMT1ZNTFRleHQoJ0JnQmV3aWxsa" +
                        "Wd1bmdTdGF0dXMnLCBCREcuQmdCZXdpbGxpZ3VuZ1N0YXR1c0NvZGUsIEBMYW5ndWFnZUNvZGUpLA0KD" +
                        "QogIE5hbWUgICAgICAgICAgPSBkYm8uZm5HZXRFaGVwYWFyTmFtZShQUlMuQmFQZXJzb25JRCksDQogI" +
                        "FN0cmFzc2UgICAgICAgPSBQUlMuV29obnNpdHpTdHJhc3NlSGF1c05yLA0KICBPcnQgICAgICAgICAgI" +
                        "D0gUFJTLldvaG5zaXR6UExaT3J0LA0KICBTYXJadXN0YWVuZGlnID0gVVNSLlZvcm5hbWVOYW1lLA0KI" +
                        "CBHZWRydWNrdEFtICAgID0gZGJvLmZuR2V0TUxUZXh0RnJvbU5hbWUoJ1NILU1vbmF0c2J1ZGdldCBBd" +
                        "XN6YWhsYmVsZWcnLCAnVGV4dFBlcicsICAgQExhbmd1YWdlQ29kZSkgKyAnICcgKyBDT05WRVJUKFZBU" +
                        "kNIQVIsIEdFVERBVEUoKSwgMTA0KSwgDQogIFRleHRTZWl0ZSAgICAgPSBkYm8uZm5HZXRNTFRleHRGc" +
                        "m9tTmFtZSgnU0gtTW9uYXRzYnVkZ2V0IEF1c3phaGxiZWxlZycsICdUZXh0U2VpdGUnLCBATGFuZ3VhZ" +
                        "2VDb2RlKQ0KRlJPTSBkYm8uQmdCdWRnZXQgICAgICAgICAgICAgIEJERyBXSVRIIChSRUFEVU5DT01NS" +
                        "VRURUQpDQogIElOTkVSIEpPSU4gZGJvLkJnRmluYW56cGxhbiAgRlBMIFdJVEggKFJFQURVTkNPTU1JV" +
                        "FRFRCkgT04gRlBMLkJnRmluYW56cGxhbklEID0gQkRHLkJnRmluYW56cGxhbklEDQogIElOTkVSIEpPS" +
                        "U4gZGJvLkZhTGVpc3R1bmcgICAgTEVJIFdJVEggKFJFQURVTkNPTU1JVFRFRCkgT04gTEVJLkZhTGVpc" +
                        "3R1bmdJRCA9IEZQTC5GYUxlaXN0dW5nSUQNCiAgSU5ORVIgSk9JTiBkYm8udndQZXJzb24gICAgICBQU" +
                        "lMgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKSBPTiBQUlMuQmFQZXJzb25JRCA9IExFSS5CYVBlcnNvbklED" +
                        "QogIElOTkVSIEpPSU4gZGJvLnZ3VXNlciAgICAgICAgVVNSIFdJVEggKFJFQURVTkNPTU1JVFRFRCkgT" +
                        "04gVVNSLlVzZXJJRCA9IExFSS5Vc2VySUQNCldIRVJFIExFSS5Nb2R1bElEID0gMw0KICBBTkQgQkRHL" +
                        "k1vbmF0IElTIE5PVCBOVUxMDQogIEFORCBCREcuQmdCdWRnZXRJRCA9IEBCZ0J1ZGdldElkOw==";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.lblStatus = new DevExpress.XtraReports.UI.XRLabel();
            this.lblGedrucktDatum = new DevExpress.XtraReports.UI.XRLabel();
            this.ShMonatsbudgetAuszahlungsbeleg_Detail = new DevExpress.XtraReports.UI.Subreport();
            this.lblOrgName = new DevExpress.XtraReports.UI.XRLabel();
            this.lblOrgAdresse = new DevExpress.XtraReports.UI.XRLabel();
            this.lblOrgOrt = new DevExpress.XtraReports.UI.XRLabel();
            this.lblNameSar = new DevExpress.XtraReports.UI.XRLabel();
            this.lblName = new DevExpress.XtraReports.UI.XRLabel();
            this.lblStrasse = new DevExpress.XtraReports.UI.XRLabel();
            this.lblOrt = new DevExpress.XtraReports.UI.XRLabel();
            this.lblMonatsbudgetTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.piOrgOrtDatum = new DevExpress.XtraReports.UI.XRPageInfo();
            this.lblSeite = new DevExpress.XtraReports.UI.XRLabel();
            this.piSeite = new DevExpress.XtraReports.UI.XRPageInfo();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // PageHeader
            // 
            this.PageHeader.Height = 0;
            this.PageHeader.Name = "PageHeader";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblStatus,
                        this.lblGedrucktDatum,
                        this.ShMonatsbudgetAuszahlungsbeleg_Detail,
                        this.lblOrgName,
                        this.lblOrgAdresse,
                        this.lblOrgOrt,
                        this.lblNameSar,
                        this.lblName,
                        this.lblStrasse,
                        this.lblOrt,
                        this.lblMonatsbudgetTitle});
            this.Detail.Height = 241;
            this.Detail.Name = "Detail";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.piOrgOrtDatum,
                        this.lblSeite,
                        this.piSeite});
            this.PageFooter.Height = 42;
            this.PageFooter.Name = "PageFooter";
            // 
            // lblStatus
            // 
            this.lblStatus.CanShrink = true;
            this.lblStatus.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BudgetStatus", "")});
            this.lblStatus.Font = new System.Drawing.Font("Arial", 10F);
            this.lblStatus.Location = new System.Drawing.Point(142, 175);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblStatus.ParentStyleUsing.UseFont = false;
            this.lblStatus.Size = new System.Drawing.Size(141, 17);
            this.lblStatus.Text = "lblStatus";
            // 
            // lblGedrucktDatum
            // 
            this.lblGedrucktDatum.CanShrink = true;
            this.lblGedrucktDatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GedrucktAm", "")});
            this.lblGedrucktDatum.Font = new System.Drawing.Font("Arial", 10F);
            this.lblGedrucktDatum.Location = new System.Drawing.Point(8, 175);
            this.lblGedrucktDatum.Name = "lblGedrucktDatum";
            this.lblGedrucktDatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblGedrucktDatum.ParentStyleUsing.UseFont = false;
            this.lblGedrucktDatum.Size = new System.Drawing.Size(125, 17);
            this.lblGedrucktDatum.Text = "lblGedrucktDatum";
            // 
            // ShMonatsbudgetAuszahlungsbeleg_Detail
            // 
            this.ShMonatsbudgetAuszahlungsbeleg_Detail.Location = new System.Drawing.Point(8, 208);
            this.ShMonatsbudgetAuszahlungsbeleg_Detail.Name = "ShMonatsbudgetAuszahlungsbeleg_Detail";
            // 
            // lblOrgName
            // 
            this.lblOrgName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Name", "")});
            this.lblOrgName.Font = new System.Drawing.Font("Arial", 10F);
            this.lblOrgName.ForeColor = System.Drawing.Color.Black;
            this.lblOrgName.Location = new System.Drawing.Point(8, 8);
            this.lblOrgName.Multiline = true;
            this.lblOrgName.Name = "lblOrgName";
            this.lblOrgName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblOrgName.ParentStyleUsing.UseBackColor = false;
            this.lblOrgName.ParentStyleUsing.UseBorderColor = false;
            this.lblOrgName.ParentStyleUsing.UseBorders = false;
            this.lblOrgName.ParentStyleUsing.UseBorderWidth = false;
            this.lblOrgName.ParentStyleUsing.UseFont = false;
            this.lblOrgName.ParentStyleUsing.UseForeColor = false;
            this.lblOrgName.Size = new System.Drawing.Size(325, 17);
            this.lblOrgName.Text = "lblOrgName";
            // 
            // lblOrgAdresse
            // 
            this.lblOrgAdresse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Adresse", "")});
            this.lblOrgAdresse.Font = new System.Drawing.Font("Arial", 10F);
            this.lblOrgAdresse.ForeColor = System.Drawing.Color.Black;
            this.lblOrgAdresse.Location = new System.Drawing.Point(8, 25);
            this.lblOrgAdresse.Multiline = true;
            this.lblOrgAdresse.Name = "lblOrgAdresse";
            this.lblOrgAdresse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblOrgAdresse.ParentStyleUsing.UseBackColor = false;
            this.lblOrgAdresse.ParentStyleUsing.UseBorderColor = false;
            this.lblOrgAdresse.ParentStyleUsing.UseBorders = false;
            this.lblOrgAdresse.ParentStyleUsing.UseBorderWidth = false;
            this.lblOrgAdresse.ParentStyleUsing.UseFont = false;
            this.lblOrgAdresse.ParentStyleUsing.UseForeColor = false;
            this.lblOrgAdresse.Size = new System.Drawing.Size(183, 19);
            this.lblOrgAdresse.Text = "lblOrgAdresse";
            // 
            // lblOrgOrt
            // 
            this.lblOrgOrt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_PLZOrt", "")});
            this.lblOrgOrt.Font = new System.Drawing.Font("Arial", 10F);
            this.lblOrgOrt.ForeColor = System.Drawing.Color.Black;
            this.lblOrgOrt.Location = new System.Drawing.Point(8, 44);
            this.lblOrgOrt.Multiline = true;
            this.lblOrgOrt.Name = "lblOrgOrt";
            this.lblOrgOrt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblOrgOrt.ParentStyleUsing.UseBackColor = false;
            this.lblOrgOrt.ParentStyleUsing.UseBorderColor = false;
            this.lblOrgOrt.ParentStyleUsing.UseBorders = false;
            this.lblOrgOrt.ParentStyleUsing.UseBorderWidth = false;
            this.lblOrgOrt.ParentStyleUsing.UseFont = false;
            this.lblOrgOrt.ParentStyleUsing.UseForeColor = false;
            this.lblOrgOrt.Size = new System.Drawing.Size(183, 19);
            this.lblOrgOrt.Text = "lblOrgOrt";
            // 
            // lblNameSar
            // 
            this.lblNameSar.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SarZustaendig", "")});
            this.lblNameSar.Font = new System.Drawing.Font("Arial", 10F);
            this.lblNameSar.ForeColor = System.Drawing.Color.Black;
            this.lblNameSar.Location = new System.Drawing.Point(8, 117);
            this.lblNameSar.Multiline = true;
            this.lblNameSar.Name = "lblNameSar";
            this.lblNameSar.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblNameSar.ParentStyleUsing.UseBackColor = false;
            this.lblNameSar.ParentStyleUsing.UseBorderColor = false;
            this.lblNameSar.ParentStyleUsing.UseBorders = false;
            this.lblNameSar.ParentStyleUsing.UseBorderWidth = false;
            this.lblNameSar.ParentStyleUsing.UseFont = false;
            this.lblNameSar.ParentStyleUsing.UseForeColor = false;
            this.lblNameSar.Size = new System.Drawing.Size(230, 15);
            this.lblNameSar.Text = "lblNameSar";
            // 
            // lblName
            // 
            this.lblName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.lblName.Font = new System.Drawing.Font("Arial", 10F);
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(475, 0);
            this.lblName.Multiline = true;
            this.lblName.Name = "lblName";
            this.lblName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblName.ParentStyleUsing.UseBackColor = false;
            this.lblName.ParentStyleUsing.UseBorderColor = false;
            this.lblName.ParentStyleUsing.UseBorders = false;
            this.lblName.ParentStyleUsing.UseBorderWidth = false;
            this.lblName.ParentStyleUsing.UseFont = false;
            this.lblName.ParentStyleUsing.UseForeColor = false;
            this.lblName.Size = new System.Drawing.Size(195, 15);
            this.lblName.Text = "lblName";
            // 
            // lblStrasse
            // 
            this.lblStrasse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Strasse", "")});
            this.lblStrasse.Font = new System.Drawing.Font("Arial", 10F);
            this.lblStrasse.ForeColor = System.Drawing.Color.Black;
            this.lblStrasse.Location = new System.Drawing.Point(475, 17);
            this.lblStrasse.Multiline = true;
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblStrasse.ParentStyleUsing.UseBackColor = false;
            this.lblStrasse.ParentStyleUsing.UseBorderColor = false;
            this.lblStrasse.ParentStyleUsing.UseBorders = false;
            this.lblStrasse.ParentStyleUsing.UseBorderWidth = false;
            this.lblStrasse.ParentStyleUsing.UseFont = false;
            this.lblStrasse.ParentStyleUsing.UseForeColor = false;
            this.lblStrasse.Size = new System.Drawing.Size(195, 15);
            this.lblStrasse.Text = "lblStrasse";
            // 
            // lblOrt
            // 
            this.lblOrt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Ort", "")});
            this.lblOrt.Font = new System.Drawing.Font("Arial", 10F);
            this.lblOrt.ForeColor = System.Drawing.Color.Black;
            this.lblOrt.Location = new System.Drawing.Point(475, 33);
            this.lblOrt.Multiline = true;
            this.lblOrt.Name = "lblOrt";
            this.lblOrt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblOrt.ParentStyleUsing.UseBackColor = false;
            this.lblOrt.ParentStyleUsing.UseBorderColor = false;
            this.lblOrt.ParentStyleUsing.UseBorders = false;
            this.lblOrt.ParentStyleUsing.UseBorderWidth = false;
            this.lblOrt.ParentStyleUsing.UseFont = false;
            this.lblOrt.ParentStyleUsing.UseForeColor = false;
            this.lblOrt.Size = new System.Drawing.Size(195, 15);
            this.lblOrt.Text = "lblOrt";
            // 
            // lblMonatsbudgetTitle
            // 
            this.lblMonatsbudgetTitle.CanShrink = true;
            this.lblMonatsbudgetTitle.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AuszahlungsBelegDatum", "")});
            this.lblMonatsbudgetTitle.Font = new System.Drawing.Font("Arial", 14F);
            this.lblMonatsbudgetTitle.Location = new System.Drawing.Point(8, 150);
            this.lblMonatsbudgetTitle.Name = "lblMonatsbudgetTitle";
            this.lblMonatsbudgetTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblMonatsbudgetTitle.ParentStyleUsing.UseFont = false;
            this.lblMonatsbudgetTitle.Size = new System.Drawing.Size(375, 20);
            this.lblMonatsbudgetTitle.Text = "lblMonatsbudgetTitle";
            // 
            // piOrgOrtDatum
            // 
            this.piOrgOrtDatum.Font = new System.Drawing.Font("Arial", 9.75F);
            this.piOrgOrtDatum.Format = "<OrgOrt>, {0:dd.MM.yyyy}";
            this.piOrgOrtDatum.Location = new System.Drawing.Point(8, 8);
            this.piOrgOrtDatum.Name = "piOrgOrtDatum";
            this.piOrgOrtDatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.piOrgOrtDatum.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.piOrgOrtDatum.ParentStyleUsing.UseFont = false;
            this.piOrgOrtDatum.Scripts.OnBeforePrint = resources.GetString("piOrgOrtDatum.Scripts.OnBeforePrint");
            this.piOrgOrtDatum.Size = new System.Drawing.Size(259, 20);
            // 
            // lblSeite
            // 
            this.lblSeite.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TextSeite", "")});
            this.lblSeite.Font = new System.Drawing.Font("Arial", 10F);
            this.lblSeite.Location = new System.Drawing.Point(583, 8);
            this.lblSeite.Name = "lblSeite";
            this.lblSeite.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSeite.ParentStyleUsing.UseFont = false;
            this.lblSeite.Size = new System.Drawing.Size(40, 20);
            this.lblSeite.Text = "lblSeite";
            // 
            // piSeite
            // 
            this.piSeite.Font = new System.Drawing.Font("Arial", 10F);
            this.piSeite.Location = new System.Drawing.Point(633, 8);
            this.piSeite.Name = "piSeite";
            this.piSeite.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.piSeite.ParentStyleUsing.UseFont = false;
            this.piSeite.Size = new System.Drawing.Size(35, 20);
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.PageHeader,
                        this.Detail,
                        this.PageFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(100, 54, 100, 100);
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
</NewDataSet>' , SQLquery =  N'DECLARE @BgBudgetId INT;
SET @BgBudgetId = {BgBudgetID};

DECLARE @LanguageCode INT;

-- Sprachcode des Klienten eruieren.
SELECT @LanguageCode = PRS.VerstaendigungSprachCode
FROM dbo.BgBudget            BDG WITH (READUNCOMMITTED)
 INNER JOIN dbo.BgFinanzplan FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
 INNER JOIN dbo.FaLeistung   LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID   = FPL.FaLeistungID
 INNER JOIN dbo.BaPerson     PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID     = LEI.BaPersonID
WHERE BDG.BgBudgetID =  @BgBudgetId;
 
-- Defaultsprache DE
IF @LanguageCode IS NULL
BEGIN
  SET @LanguageCode = 1;
END;

SELECT
  Org_Name      = ISNULL(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Organisation'', GETDATE())), ''''),
  Org_Adresse   = ISNULL(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Adresse'', GETDATE())), ''''),
  Org_PLZ       = ISNULL(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', GETDATE())), ''''),
  Org_Ort       = ISNULL(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', GETDATE())), ''''),
  Org_PLZOrt    = ISNULL(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', GETDATE())) + '' '', '''')
                  + ISNULL(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', GETDATE())), ''''), 
  BgBudgetID    = BDG.BgBudgetID,                             
  AuszahlungsBelegDatum  =  dbo.fnGetMLTextFromName(''SH-Monatsbudget Auszahlbeleg'', ''TextAuszahlungsbeleg'', @LanguageCode) + '' '' +
                            dbo.fnGetLOVMLText(''Monat'', BDG.Monat, @LanguageCode) + '' '' + CONVERT(VARCHAR,BDG.Jahr),
  BudgetStatus  = dbo.fnGetLOVMLText(''BgBewilligungStatus'', BDG.BgBewilligungStatusCode, @LanguageCode),

  Name          = dbo.fnGetEhepaarName(PRS.BaPersonID, NULL, 0, @LanguageCode),
  Strasse       = PRS.WohnsitzStrasseHausNr,
  Ort           = PRS.WohnsitzPLZOrt,
  SarZustaendig = USR.VornameName,
  GedrucktAm    = dbo.fnGetMLTextFromName(''SH-Monatsbudget Auszahlbeleg'', ''TextPer'',   @LanguageCode) + '' '' + CONVERT(VARCHAR, GETDATE(), 104), 
  TextSeite     = dbo.fnGetMLTextFromName(''SH-Monatsbudget Auszahlbeleg'', ''TextSeite'', @LanguageCode)
FROM dbo.BgBudget              BDG WITH (READUNCOMMITTED)
  INNER JOIN dbo.BgFinanzplan  FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
  INNER JOIN dbo.FaLeistung    LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
  INNER JOIN dbo.vwPerson      PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
  INNER JOIN dbo.vwUser        USR WITH (READUNCOMMITTED) ON USR.UserID = LEI.UserID
WHERE LEI.ModulID = 3
  AND BDG.Monat IS NOT NULL
  AND BDG.BgBudgetID = @BgBudgetId;' , ContextForms =  N'WhMonatsbudget,WhFinanzplan' , ParentReportName =  null , ReportSortKey = 4
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'ShMonatsbudgetAuszahlungsbeleg' ;


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShMonatsbudgetAuszahlungsbeleg_Detail' ,  N'Auszahlungsbeleg - Detail' , 1,  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>en-US</Localization>
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
///     <Reference Path="C:\KiSS\KiSS4\KiSS4.DB.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.Interfaces.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Microsoft.Practices.Unity.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\KiSS\KiSS4\FluentValidation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\KiSS\KiSS4\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="C:\KiSS\KiSS4\log4net.dll" />
///     <Reference Path="C:\KiSS\KiSS4\SharpLibrary.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.GroupHeaderBand GH_GruppeCode;
        private DevExpress.XtraReports.UI.XRLabel lblZahlungswegHeader;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel lblBetragHeader;
        private DevExpress.XtraReports.UI.XRLabel lblGruppeHeader;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel lblZahlungsweg;
        private DevExpress.XtraReports.UI.XRLabel lblDisplayBetrag;
        private DevExpress.XtraReports.UI.XRLabel lblBuchungstext;
        private DevExpress.XtraReports.UI.GroupFooterBand GF_GruppeCode;
        private DevExpress.XtraReports.UI.XRPanel panGruppeFooter;
        private DevExpress.XtraReports.UI.XRLabel lblSummeGruppe;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAAEAAAAAAAAAFBBRFBBRFATtE6k6" +
                        "Akg9o9KjDboCMpy6QAAAEsAAACaAAAAAAAAAPQBAABGRwBIAF8ARwByAHUAcABwAGUAQwBvAGQAZQAuA" +
                        "FMAYwByAGkAcAB0AHMALgBPAG4AQgBlAGYAbwByAGUAUAByAGkAbgB0AAAAAABKbABiAGwARwByAHUAc" +
                        "ABwAGUASABlAGEAZABlAHIALgBTAGMAcgBpAHAAdABzAC4ATwBuAEIAZQBmAG8AcgBlAFAAcgBpAG4Ad" +
                        "AABAQAASnAAYQBuAEcAcgB1AHAAcABlAEYAbwBvAHQAZQByAC4AUwBjAHIAaQBwAHQAcwAuAE8AbgBCA" +
                        "GUAZgBvAHIAZQBQAHIAaQBuAHQAZwIAADJzAHEAbABRAHUAZQByAHkAMQAuAFMAZQBsAGUAYwB0AFMAd" +
                        "ABhAHQAZQBtAGUAbgB0AGYEAAAB/gFwcml2YXRlIHZvaWQgT25CZWZvcmVQcmludChvYmplY3Qgc2VuZ" +
                        "GVyLCBTeXN0ZW0uRHJhd2luZy5QcmludGluZy5QcmludEV2ZW50QXJncyBlKSANCnsNCi8vICAgIHN0c" +
                        "mluZyByZXBvcnRHcnVwcGVIZWFkZXIgPSBHZXRDdXJyZW50Q29sdW1uVmFsdWUoIlJlcG9ydEdydXBwZ" +
                        "UhlYWRlciIpIGFzIHN0cmluZzsNCi8vICAgIEdIX0dydXBwZUNvZGUuVmlzaWJsZSA9ICFzdHJpbmcuS" +
                        "XNOdWxsT3JFbXB0eShyZXBvcnRHcnVwcGVIZWFkZXIpOw0KfQHjAnByaXZhdGUgdm9pZCBPbkJlZm9yZ" +
                        "VByaW50KG9iamVjdCBzZW5kZXIsIFN5c3RlbS5EcmF3aW5nLlByaW50aW5nLlByaW50RXZlbnRBcmdzI" +
                        "GUpIHsNCiAgICBzdHJpbmcgcmVwb3J0R3J1cHBlSGVhZGVyID0gR2V0Q3VycmVudENvbHVtblZhbHVlK" +
                        "CJSZXBvcnRHcnVwcGVIZWFkZXIiKSBhcyBzdHJpbmc7DQogICAgYm9vbCB2aXNpYmxlID0gIXN0cmluZ" +
                        "y5Jc051bGxPckVtcHR5KHJlcG9ydEdydXBwZUhlYWRlcik7DQogICAgbGJsQmV0cmFnSGVhZGVyLlZpc" +
                        "2libGUgPSB2aXNpYmxlOw0KICAgIGxibFphaGx1bmdzd2VnSGVhZGVyLlZpc2libGUgPSB2aXNpYmxlO" +
                        "w0KICAgIERldGFpbC5WaXNpYmxlID0gdmlzaWJsZTsNCn0B/ANwcml2YXRlIHZvaWQgT25CZWZvcmVQc" +
                        "mludChvYmplY3Qgc2VuZGVyLCBTeXN0ZW0uRHJhd2luZy5QcmludGluZy5QcmludEV2ZW50QXJncyBlK" +
                        "SANCnsNCiAgICBpbnQ/IHJlcG9ydEdydXBwZUNvZGUgPSBHZXRDdXJyZW50Q29sdW1uVmFsdWUoIlJlc" +
                        "G9ydEdydXBwZUNvZGUiKSBhcyBpbnQ/Ow0KICAgIGlmKChyZXBvcnRHcnVwcGVDb2RlID8/IC0xKSA9P" +
                        "SA1KQ0KICAgIHsNCiAgICAgICAgcGFuR3J1cHBlRm9vdGVyLkJvcmRlcnMgPSBEZXZFeHByZXNzLlh0c" +
                        "mFQcmludGluZy5Cb3JkZXJTaWRlLkFsbDsNCiAgICAgICAgcGFuR3J1cHBlRm9vdGVyLkJhY2tDb2xvc" +
                        "iA9IENvbG9yLkxpZ2h0R3JheTsNCiAgICB9DQogICAgZWxzZQ0KICAgIHsNCiAgICAgICAgcGFuR3J1c" +
                        "HBlRm9vdGVyLkJvcmRlcnMgPSBEZXZFeHByZXNzLlh0cmFQcmludGluZy5Cb3JkZXJTaWRlLk5vbmU7D" +
                        "QogICAgICAgIHBhbkdydXBwZUZvb3Rlci5CYWNrQ29sb3IgPSBDb2xvci5UcmFuc3BhcmVudDsNCiAgI" +
                        "CB9DQp9Ac4FREVDTEFSRSBAQmdCdWRnZXRJZCBJTlQ7DQpTRVQgQEJnQnVkZ2V0SWQgPSBudWxsOw0KD" +
                        "QpERUNMQVJFIEBMYW5ndWFnZUNvZGUgSU5UOw0KDQotLSBTcHJhY2hjb2RlIGRlcyBLbGllbnRlbiBlc" +
                        "nVpZXJlbi4NClNFTEVDVCBATGFuZ3VhZ2VDb2RlID0gUFJTLlZlcnN0YWVuZGlndW5nU3ByYWNoQ29kZ" +
                        "Q0KRlJPTSBkYm8uQmdCdWRnZXQgICAgICAgICAgICBCREcgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKQ0KI" +
                        "ElOTkVSIEpPSU4gZGJvLkJnRmluYW56cGxhbiBGUEwgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKSBPTiBGU" +
                        "EwuQmdGaW5hbnpwbGFuSUQgPSBCREcuQmdGaW5hbnpwbGFuSUQNCiBJTk5FUiBKT0lOIGRiby5GYUxla" +
                        "XN0dW5nICAgTEVJIFdJVEggKFJFQURVTkNPTU1JVFRFRCkgT04gTEVJLkZhTGVpc3R1bmdJRCAgID0gR" +
                        "lBMLkZhTGVpc3R1bmdJRA0KIElOTkVSIEpPSU4gZGJvLkJhUGVyc29uICAgICBQUlMgV0lUSCAoUkVBR" +
                        "FVOQ09NTUlUVEVEKSBPTiBQUlMuQmFQZXJzb25JRCAgICAgPSBMRUkuQmFQZXJzb25JRA0KV0hFUkUgQ" +
                        "kRHLkJnQnVkZ2V0SUQgPSAgQEJnQnVkZ2V0SWQ7DQogDQotLSBEZWZhdWx0c3ByYWNoZSBERQ0KSUYgQ" +
                        "Exhbmd1YWdlQ29kZSBJUyBOVUxMDQpCRUdJTg0KICBTRVQgQExhbmd1YWdlQ29kZSA9IDE7DQpFTkQ7D" +
                        "QoNCkVYRUMgZGJvLnNwUmVwb3J0V2hBdXN6YWhsdW5nc2JlbGVnIEBCZ0J1ZGdldElkLCBATGFuZ3VhZ" +
                        "2VDb2RlOw==";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.GH_GruppeCode = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.GF_GruppeCode = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.lblZahlungswegHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.lblBetragHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.lblGruppeHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.lblZahlungsweg = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDisplayBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.lblBuchungstext = new DevExpress.XtraReports.UI.XRLabel();
            this.panGruppeFooter = new DevExpress.XtraReports.UI.XRPanel();
            this.lblSummeGruppe = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // GH_GruppeCode
            // 
            this.GH_GruppeCode.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblZahlungswegHeader,
                        this.lblBetragHeader,
                        this.lblGruppeHeader});
            this.GH_GruppeCode.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("ReportGruppeCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GH_GruppeCode.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.GH_GruppeCode.Height = 38;
            this.GH_GruppeCode.Name = "GH_GruppeCode";
            this.GH_GruppeCode.RepeatEveryPage = true;
            this.GH_GruppeCode.Scripts.OnBeforePrint = resources.GetString("GH_GruppeCode.Scripts.OnBeforePrint");
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblZahlungsweg,
                        this.lblDisplayBetrag,
                        this.lblBuchungstext});
            this.Detail.Height = 27;
            this.Detail.Name = "Detail";
            // 
            // GF_GruppeCode
            // 
            this.GF_GruppeCode.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.panGruppeFooter});
            this.GF_GruppeCode.Height = 38;
            this.GF_GruppeCode.Name = "GF_GruppeCode";
            // 
            // lblZahlungswegHeader
            // 
            this.lblZahlungswegHeader.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ZahlungswegHeader", "")});
            this.lblZahlungswegHeader.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblZahlungswegHeader.Location = new System.Drawing.Point(408, 8);
            this.lblZahlungswegHeader.Name = "lblZahlungswegHeader";
            this.lblZahlungswegHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblZahlungswegHeader.ParentStyleUsing.UseFont = false;
            this.lblZahlungswegHeader.Size = new System.Drawing.Size(217, 25);
            this.lblZahlungswegHeader.Text = "lblZahlungswegHeader";
            // 
            // lblBetragHeader
            // 
            this.lblBetragHeader.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TextBetrag", "")});
            this.lblBetragHeader.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblBetragHeader.Location = new System.Drawing.Point(317, 8);
            this.lblBetragHeader.Name = "lblBetragHeader";
            this.lblBetragHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblBetragHeader.ParentStyleUsing.UseFont = false;
            this.lblBetragHeader.Size = new System.Drawing.Size(83, 25);
            this.lblBetragHeader.Text = "lblBetragHeader";
            this.lblBetragHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblGruppeHeader
            // 
            this.lblGruppeHeader.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ReportGruppeHeader", "")});
            this.lblGruppeHeader.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblGruppeHeader.Location = new System.Drawing.Point(12, 8);
            this.lblGruppeHeader.Name = "lblGruppeHeader";
            this.lblGruppeHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblGruppeHeader.ParentStyleUsing.UseFont = false;
            this.lblGruppeHeader.Scripts.OnBeforePrint = resources.GetString("lblGruppeHeader.Scripts.OnBeforePrint");
            this.lblGruppeHeader.Size = new System.Drawing.Size(300, 25);
            this.lblGruppeHeader.Text = "lblGruppeHeader";
            // 
            // lblZahlungsweg
            // 
            this.lblZahlungsweg.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ZahlungswegDetails", "")});
            this.lblZahlungsweg.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblZahlungsweg.Location = new System.Drawing.Point(408, 0);
            this.lblZahlungsweg.Multiline = true;
            this.lblZahlungsweg.Name = "lblZahlungsweg";
            this.lblZahlungsweg.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblZahlungsweg.ParentStyleUsing.UseFont = false;
            this.lblZahlungsweg.Size = new System.Drawing.Size(217, 25);
            this.lblZahlungsweg.Text = "lblZahlungsweg";
            // 
            // lblDisplayBetrag
            // 
            this.lblDisplayBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.lblDisplayBetrag.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblDisplayBetrag.Location = new System.Drawing.Point(317, 0);
            this.lblDisplayBetrag.Name = "lblDisplayBetrag";
            this.lblDisplayBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDisplayBetrag.ParentStyleUsing.UseFont = false;
            this.lblDisplayBetrag.Size = new System.Drawing.Size(83, 25);
            this.lblDisplayBetrag.Text = "lblDisplayBetrag";
            this.lblDisplayBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblBuchungstext
            // 
            this.lblBuchungstext.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Buchungstext", "")});
            this.lblBuchungstext.Font = new System.Drawing.Font("Arial", 9.75F);
            this.lblBuchungstext.Location = new System.Drawing.Point(12, 0);
            this.lblBuchungstext.Name = "lblBuchungstext";
            this.lblBuchungstext.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblBuchungstext.ParentStyleUsing.UseFont = false;
            this.lblBuchungstext.Size = new System.Drawing.Size(300, 25);
            this.lblBuchungstext.Text = "lblBuchungstext";
            // 
            // panGruppeFooter
            // 
            this.panGruppeFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblSummeGruppe,
                        this.xrLabel3});
            this.panGruppeFooter.Location = new System.Drawing.Point(0, 0);
            this.panGruppeFooter.Name = "panGruppeFooter";
            this.panGruppeFooter.ParentStyleUsing.UseBackColor = false;
            this.panGruppeFooter.ParentStyleUsing.UseBorders = false;
            this.panGruppeFooter.Scripts.OnBeforePrint = resources.GetString("panGruppeFooter.Scripts.OnBeforePrint");
            this.panGruppeFooter.Size = new System.Drawing.Size(408, 33);
            // 
            // lblSummeGruppe
            // 
            this.lblSummeGruppe.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "")});
            this.lblSummeGruppe.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSummeGruppe.Location = new System.Drawing.Point(317, 5);
            this.lblSummeGruppe.Name = "lblSummeGruppe";
            this.lblSummeGruppe.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSummeGruppe.ParentStyleUsing.UseBorders = false;
            this.lblSummeGruppe.ParentStyleUsing.UseFont = false;
            this.lblSummeGruppe.Size = new System.Drawing.Size(83, 25);
            xrSummary1.FormatString = "{0:n2}";
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.lblSummeGruppe.Summary = xrSummary1;
            this.lblSummeGruppe.Text = "lblSummeGruppe";
            this.lblSummeGruppe.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ReportGruppeFooter", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.Location = new System.Drawing.Point(12, 5);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(300, 25);
            this.xrLabel3.Text = "xrLabel3";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.Position = 0;
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.GH_GruppeCode,
                        this.Detail,
                        this.GF_GruppeCode});
            this.DataSource = this.sqlQuery1;
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
</NewDataSet>' ,  N'DECLARE @BgBudgetId INT;
SET @BgBudgetId = {BgBudgetID};

DECLARE @LanguageCode INT;

-- Sprachcode des Klienten eruieren.
SELECT @LanguageCode = PRS.VerstaendigungSprachCode
FROM dbo.BgBudget            BDG WITH (READUNCOMMITTED)
 INNER JOIN dbo.BgFinanzplan FPL WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
 INNER JOIN dbo.FaLeistung   LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID   = FPL.FaLeistungID
 INNER JOIN dbo.BaPerson     PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID     = LEI.BaPersonID
WHERE BDG.BgBudgetID =  @BgBudgetId;
 
-- Defaultsprache DE
IF @LanguageCode IS NULL
BEGIN
  SET @LanguageCode = 1;
END;

EXEC dbo.spReportWhAuszahlungsbeleg @BgBudgetId, @LanguageCode;' ,  null ,  N'ShMonatsbudgetAuszahlungsbeleg' ,  null );


