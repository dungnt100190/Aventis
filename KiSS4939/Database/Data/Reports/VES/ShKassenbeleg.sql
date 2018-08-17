-- Insert Script for ShKassenbeleg
-- MD5:0X79FF7B6562310BBFAC404037313EA0F8_0XB4C8772B5FDC602B7B6ACD41A694CD9C_0XEE2474AE154C7C6DACB89288F8D8A1BB
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'ShKassenbeleg') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('ShKassenbeleg', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'ShKassenbeleg';
--SQLCHECK_IGNORE--
UPDATE QRY
SET QueryName =  N'ShKassenbeleg' , UserText =  N'SH - Kassenbeleg' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>c:\program files (x86)\bedag informatik ag\kiss4 produktion\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>de-DE</Localization>
///   <References>
///     <Reference Path="c:\program files (x86)\bedag informatik ag\kiss4 produktion\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="c:\program files (x86)\bedag informatik ag\kiss4 produktion\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Drawing\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Configuration\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Data.SqlXml\v4.0_4.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Security\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="c:\program files (x86)\bedag informatik ag\kiss4 produktion\DevExpress.Utils.v6.2.dll" />
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
///     <Reference Path="c:\program files (x86)\bedag informatik ag\kiss4 produktion\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="c:\program files (x86)\bedag informatik ag\kiss4 produktion\DevExpress.Data.v6.2.dll" />
///     <Reference Path="c:\program files (x86)\bedag informatik ag\kiss4 produktion\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="c:\program files (x86)\bedag informatik ag\kiss4 produktion\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="c:\program files (x86)\bedag informatik ag\kiss4 produktion\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="c:\program files (x86)\bedag informatik ag\kiss4 produktion\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="c:\program files (x86)\bedag informatik ag\kiss4 produktion\KiSS4.DB.dll" />
///     <Reference Path="c:\program files (x86)\bedag informatik ag\kiss4 produktion\Kiss.Interfaces.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="c:\program files (x86)\bedag informatik ag\kiss4 produktion\FluentValidation.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="c:\program files (x86)\bedag informatik ag\kiss4 produktion\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="c:\program files (x86)\bedag informatik ag\kiss4 produktion\Microsoft.Practices.Unity.dll" />
///     <Reference Path="c:\program files (x86)\bedag informatik ag\kiss4 produktion\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="c:\program files (x86)\bedag informatik ag\kiss4 produktion\log4net.dll" />
///     <Reference Path="c:\program files (x86)\bedag informatik ag\kiss4 produktion\SharpLibrary.dll" />
///     <Reference Path="c:\program files (x86)\bedag informatik ag\kiss4 produktion\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="c:\program files (x86)\bedag informatik ag\kiss4 produktion\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtNameFbKostenstelle;
        private DevExpress.XtraReports.UI.XRLabel txtIntern;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel Label18;
        private DevExpress.XtraReports.UI.XRLabel Label17;
        private DevExpress.XtraReports.UI.XRLabel Label16;
        private DevExpress.XtraReports.UI.XRLabel txtNameFbKostenart;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel txtCashOrCheckAm;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.XRLabel Label5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel txtBemerkung;
        private DevExpress.XtraReports.UI.XRLabel Label12;
        private DevExpress.XtraReports.UI.XRLabel Label11;
        private DevExpress.XtraReports.UI.XRLabel Label9;
        private DevExpress.XtraReports.UI.XRLabel txtNameKassier;
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
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kA" +
                        "AAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAA" +
                        "AAAAf8eREVDTEFSRSBAS2JCdWNodW5nSUQgSU5UOw0KU0VUIEBLYkJ1Y2h1bmdJRCA9IG51bGw7IC0tI" +
                        "ChUZXN0Q2FzZSkxMzQ0MQ0KDQpTRUxFQ1QgRElTVElOQ1QNCiAgT3JnX05hbWUgICAgICAgICAgICAgP" +
                        "SBJU05VTEwoQ09OVkVSVChWQVJDSEFSKDEwMDApLCBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZ" +
                        "VxTb3ppYWxoaWxmZVxPcmdhbmlzYXRpb24nLCBHRVREQVRFKCkpKSwgJycpLA0KICBPcmdfQWRyZXNzZ" +
                        "SAgICAgICAgICA9IElTTlVMTChDT05WRVJUKFZBUkNIQVIoMTAwMCksIGRiby5mblhDb25maWcoJ1N5c" +
                        "3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlXEFkcmVzc2UnLCBHRVREQVRFKCkpKSwgJycpLA0KICBPcmdfU" +
                        "ExaICAgICAgICAgICAgICA9IElTTlVMTChDT05WRVJUKFZBUkNIQVIoMTAwMCksIGRiby5mblhDb25ma" +
                        "WcoJ1N5c3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlXFBMWicsIEdFVERBVEUoKSkpLCAnJyksDQogIE9yZ" +
                        "19PcnQgICAgICAgICAgICAgID0gSVNOVUxMKENPTlZFUlQoVkFSQ0hBUigxMDAwKSwgZGJvLmZuWENvb" +
                        "mZpZygnU3lzdGVtXEFkcmVzc2VcU296aWFsaGlsZmVcT3J0JywgR0VUREFURSgpKSksICcnKSwNCiAgT" +
                        "3JnX1BMWk9ydCAgICAgICAgICAgPSBJU05VTEwoQ09OVkVSVChWQVJDSEFSKDEwMDApLCBkYm8uZm5YQ" +
                        "29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxQTFonLCBHRVREQVRFKCkpKSArICcgJywgJ" +
                        "ycpICsNCiAgICAgICAgICAgICAgICAgICAgICAgICBJU05VTEwoQ09OVkVSVChWQVJDSEFSKDEwMDApL" +
                        "CBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxPcnQnLCBHRVREQVRFKCkpK" +
                        "SwgJycpLA0KICBLYkF1c3phaGx1bmdzYXJ0Q29kZSA9IEJVQy5LYkF1c3phaGx1bmdzYXJ0Q29kZSwNC" +
                        "iAgS2JCdWNodW5nSUQgICAgICAgICAgPSBCVUMuS2JCdWNodW5nSUQsDQogIEtiQnVjaHVuZ1N0YXR1c" +
                        "0NvZGUgID0gQlVDLktiQnVjaHVuZ1N0YXR1c0NvZGUsDQogIE5hbWVLYkJ1Y2h1bmdzU3RhdHVzID0gZ" +
                        "GJvLmZuTE9WVGV4dCgnS2JCdWNodW5nc1N0YXR1cycsIEJVQy5LYkJ1Y2h1bmdTdGF0dXNDb2RlKSwNC" +
                        "iAgTmFtZUtiQXVzemFobHVuZ3NBcnQgPSBkYm8uZm5MT1ZUZXh0KCdLYkF1c3phaGx1bmdzQXJ0JywgQ" +
                        "lVDLktiQXVzemFobHVuZ3NhcnRDb2RlKSwNCiAgTmFtZVllYXJNb250aCAgICAgICAgPSBkYm8uZm5YT" +
                        "W9uYXQoQkRHLk1vbmF0KSArICcgJyArIENPTlZFUlQoVkFSQ0hBUiwgQkRHLkphaHIpLA0KICBWZXJmY" +
                        "WxsZGF0dW0gICAgICAgICA9IERBVEVBREQoREFZLCA1LCBCVUMuVmFsdXRhRGF0dW0pLA0KICBLYkJ1Y" +
                        "2h1bmdLb3N0ZW5zcnRJRCA9IEtCSy5LYkJ1Y2h1bmdLb3N0ZW5hcnRJRCwNCiAgQnVjaHVuZ3N0ZXh0I" +
                        "CAgICAgICAgPSBLQksuQnVjaHVuZ3N0ZXh0LA0KICBCZXRyYWcgICAgICAgICAgICAgICA9IEtCSy5CZ" +
                        "XRyYWcsDQogIE5hbWVLb3N0ZW5hcnQgICAgICAgID0gQkdLLk5hbWUsDQogIE5hbWVLb3N0ZW5zdGVsb" +
                        "GUgICAgID0gS1NULk5hbWUsLS1JU05VTEwoS1NULk5hbWUsIEtQUi5OYW1lVm9ybmFtZSksDQogIEtCS" +
                        "1BlcnNvbklEICAgICAgICAgID0gS0JLLkJhUGVyc29uSUQsDQogIEtiS29zdGVuc3RlbGxlSUQgICAgI" +
                        "D0gS0JLLktiS29zdGVuc3RlbGxlSUQsDQogIE5hbWVLYXNzaWVyICAgICAgICAgID0gS1VTUi5MYXN0T" +
                        "mFtZSArIElTTlVMTCgnLCAnICsgS1VTUi5GaXJzdE5hbWUsICcnKSArIElTTlVMTCgnICgnICsgS1VTU" +
                        "i5QaG9uZSArICcpJywgJycpLA0KICBGdWxsTmFtZSAgICAgICAgICAgICA9IFBSUy5OYW1lVm9ybmFtZ" +
                        "SwNCiAgQXVzenV6YWhsZW5BbiAgICAgICAgPSBJU05VTEwoTlVMTElGKEJVQy5CZWd1ZW5zdGlndE5hb" +
                        "WUsICcnKSwgUFJTLk5hbWVWb3JuYW1lKSwNCiAgU3RyYXNzZSAgICAgICAgICAgICAgPSBJU05VTEwoT" +
                        "lVMTElGKEJVQy5CZWd1ZW5zdGlndFN0cmFzc2UsICcnKSwgUFJTLldvaG5zaXR6U3RyYXNzZUhhdXNOc" +
                        "iksDQogIFBMWk9ydCAgICAgICAgICAgICAgID0gSVNOVUxMKE5VTExJRihCVUMuQmVndWVuc3RpZ3RPc" +
                        "nQsICcnKSwgUFJTLldvaG5zaXR6UExaT3J0KSwNCiAgUExaICAgICAgICAgICAgICAgICAgPSBQUlMuV" +
                        "29obnNpdHpQTFosDQogIE9ydCAgICAgICAgICAgICAgICAgID0gUFJTLldvaG5zaXR6T3J0LA0KICBCZ" +
                        "WxlZ05yICAgICAgICAgICAgICA9IEJVQy5CZWxlZ05yLA0KICBFbXBsb3llZU5hbWUgICAgICAgICA9I" +
                        "FVTUi5MYXN0TmFtZSArIElTTlVMTCgnLCAnICsgVVNSLkZpcnN0TmFtZSwgJycpICsgSVNOVUxMKCcgK" +
                        "CcgKyBVU1IuUGhvbmUgKyAnKScsICcnKSwNCiAgUmVtYXJrICAgICAgICAgICAgICAgPSBCVUMuUmVtY" +
                        "XJrLA0KICBWYWx1dGFEYXR1bSAgICAgICAgICA9IEJVQy5WYWx1dGFEYXR1bSwNCiAgQmFyYmVsZWdEY" +
                        "XR1bSAgICAgICAgPSBCVUMuQmFyYmVsZWdEYXR1bQ0KRlJPTSBkYm8uRmFMZWlzdHVuZyAgICAgICAgI" +
                        "CAgICAgICAgICAgICBGQUwgIFdJVEgoUkVBRFVOQ09NTUlUVEVEKQ0KICBJTk5FUiBKT0lOIGRiby52d" +
                        "1BlcnNvbiAgICAgICAgICAgICAgICBQUlMgIFdJVEgoUkVBRFVOQ09NTUlUVEVEKSBPTiBQUlMuQmFQZ" +
                        "XJzb25JRCA9IEZBTC5CYVBlcnNvbklEDQogIElOTkVSIEpPSU4gZGJvLkJnRmluYW56cGxhbiAgICAgI" +
                        "CAgICAgIEZQTCAgV0lUSChSRUFEVU5DT01NSVRURUQpIE9OIEZQTC5GYUxlaXN0dW5nSUQgPSBGQUwuR" +
                        "mFMZWlzdHVuZ0lEDQogIElOTkVSIEpPSU4gZGJvLkJnRmluYW56cGxhbl9CYVBlcnNvbiAgIEZCUCAgV" +
                        "0lUSChSRUFEVU5DT01NSVRURUQpIE9OIEZCUC5CZ0ZpbmFuenBsYW5JRCA9IEZQTC5CZ0ZpbmFuenBsY" +
                        "W5JRA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgIEFORCBGQlAuSXN0VW50ZXJzdHVldHp0ID0gMQ0KICBJTk5FUiBKT0lOIGRiby5CZ" +
                        "0J1ZGdldCAgICAgICAgICAgICAgICBCREcgIFdJVEgoUkVBRFVOQ09NTUlUVEVEKSBPTiBCREcuQmdGa" +
                        "W5hbnpwbGFuSUQgPSBGUEwuQmdGaW5hbnpwbGFuSUQNCiAgSU5ORVIgSk9JTiBkYm8uS2JCdWNodW5nI" +
                        "CAgICAgICAgICAgICAgQlVDICBXSVRIKFJFQURVTkNPTU1JVFRFRCkgT04gQlVDLkJnQnVkZ2V0SUQgP" +
                        "SBCREcuQmdCdWRnZXRJRA0KICBJTk5FUiBKT0lOIGRiby5LYkJ1Y2h1bmdLb3N0ZW5hcnQgICAgICBLQ" +
                        "ksgIFdJVEgoUkVBRFVOQ09NTUlUVEVEKSBPTiBLQksuS2JCdWNodW5nSUQgPSBCVUMuS2JCdWNodW5nS" +
                        "UQNCiAgSU5ORVIgSk9JTiBkYm8uWFVzZXIgICAgICAgICAgICAgICAgICAgVVNSICBXSVRIKFJFQURVT" +
                        "kNPTU1JVFRFRCkgT04gVVNSLlVzZXJJRCA9IEZBTC5Vc2VySUQNCiAgTEVGVCAgSk9JTiBkYm8uWFVzZ" +
                        "XIgICAgICAgICAgICAgICAgICAgS1VTUiBXSVRIKFJFQURVTkNPTU1JVFRFRCkgT04gS1VTUi5Vc2VyS" +
                        "UQgPSBCVUMuQmFyYmVsZWdVc2VySUQNCiAgTEVGVCAgSk9JTiBkYm8uQmdLb3N0ZW5hcnQgICAgICAgI" +
                        "CAgICAgQkdLICBXSVRIKFJFQURVTkNPTU1JVFRFRCkgT04gQkdLLkJnS29zdGVuYXJ0SUQgPSBLQksuQ" +
                        "mdLb3N0ZW5hcnRJRA0KICBMRUZUICBKT0lOIGRiby5LYktvc3RlbnN0ZWxsZQkgICAgICAgICBLU1QgI" +
                        "FdJVEgoUkVBRFVOQ09NTUlUVEVEKSBPTiBLU1QuS2JLb3N0ZW5zdGVsbGVJRCA9IEtCSy5LYktvc3Rlb" +
                        "nN0ZWxsZUlEDQotLSAgTEVGVCAgSk9JTiBkYm8uS2JLb3N0ZW5zdGVsbGVfQmFQZXJzb24gS1NQICBXS" +
                        "VRIKFJFQURVTkNPTU1JVFRFRCkgT04gS1NQLktiS29zdGVuc3RlbGxlSUQgPSBLQksuS2JLb3N0ZW5zd" +
                        "GVsbGVJRA0KLS0gIExFRlQgIEpPSU4gZGJvLnZ3UGVyc29uU2ltcGxlICAgICAgICAgIEtQUiAgV0lUS" +
                        "ChSRUFEVU5DT01NSVRURUQpIE9OIEtQUi5CYVBlcnNvbklEID0gS1NQLkJhUGVyc29uSUQNCldIRVJFI" +
                        "EJVQy5LYkJ1Y2h1bmdJRCA9IEBLYkJ1Y2h1bmdJRA0KT1JERVIgQlkgTmFtZUtvc3RlbmFydCBBU0MsI" +
                        "EJldHJhZyBERVNDOw==";
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
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNameFbKostenstelle = new DevExpress.XtraReports.UI.XRLabel();
            this.txtIntern = new DevExpress.XtraReports.UI.XRLabel();
            this.Label18 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label17 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label16 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNameFbKostenart = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtCashOrCheckAm = new DevExpress.XtraReports.UI.XRLabel();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.Label15 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtStrasse = new DevExpress.XtraReports.UI.XRLabel();
            this.FullName1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label14 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
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
            this.Label12 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label11 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label9 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNameKassier = new DevExpress.XtraReports.UI.XRLabel();
            this.txtEmployeeName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNameYearMonth = new DevExpress.XtraReports.UI.XRLabel();
            this.txtFullName = new DevExpress.XtraReports.UI.XRLabel();
            this.Label8 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtFlBelegID = new DevExpress.XtraReports.UI.XRLabel();
            this.xrControl1 = new DevExpress.XtraReports.UI.XRControl();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtBetrag,
                        this.txtNameFbKostenstelle,
                        this.txtIntern});
            this.Detail.Height = 35;
            this.Detail.KeepTogether = true;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBackColor = false;
            this.Detail.ParentStyleUsing.UseBorderColor = false;
            this.Detail.ParentStyleUsing.UseBorders = false;
            this.Detail.ParentStyleUsing.UseBorderWidth = false;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.ParentStyleUsing.UseForeColor = false;
            this.Detail.PrintOnEmptyDataSource = false;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Label18,
                        this.Label17,
                        this.Label16,
                        this.txtNameFbKostenart});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("NameKostenart", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 66;
            this.GroupHeader1.KeepTogether = true;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLine3,
                        this.xrLine2,
                        this.xrLine1,
                        this.xrLabel5,
                        this.txtCashOrCheckAm,
                        this.Label6,
                        this.Label5,
                        this.xrLabel1});
            this.ReportFooter.Height = 177;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrTable1,
                        this.Line1,
                        this.Label15,
                        this.txtStrasse,
                        this.FullName1,
                        this.Label14,
                        this.Label4,
                        this.Label3,
                        this.Label2,
                        this.Label1});
            this.ReportHeader.Height = 421;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(667, 0);
            this.txtBetrag.Multiline = true;
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(83, 20);
            xrSummary1.FormatString = "{0:0.00}";
            this.txtBetrag.Summary = xrSummary1;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtNameFbKostenstelle
            // 
            this.txtNameFbKostenstelle.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameKostenstelle", "")});
            this.txtNameFbKostenstelle.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNameFbKostenstelle.ForeColor = System.Drawing.Color.Black;
            this.txtNameFbKostenstelle.Location = new System.Drawing.Point(433, 0);
            this.txtNameFbKostenstelle.Multiline = true;
            this.txtNameFbKostenstelle.Name = "txtNameFbKostenstelle";
            this.txtNameFbKostenstelle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBackColor = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBorderColor = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBorders = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBorderWidth = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseFont = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseForeColor = false;
            this.txtNameFbKostenstelle.Size = new System.Drawing.Size(234, 20);
            this.txtNameFbKostenstelle.Text = "txtNameFbKostenstelle";
            // 
            // txtIntern
            // 
            this.txtIntern.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Buchungstext", "")});
            this.txtIntern.Font = new System.Drawing.Font("Arial", 10F);
            this.txtIntern.ForeColor = System.Drawing.Color.Black;
            this.txtIntern.Location = new System.Drawing.Point(33, 0);
            this.txtIntern.Multiline = true;
            this.txtIntern.Name = "txtIntern";
            this.txtIntern.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtIntern.ParentStyleUsing.UseBackColor = false;
            this.txtIntern.ParentStyleUsing.UseBorderColor = false;
            this.txtIntern.ParentStyleUsing.UseBorders = false;
            this.txtIntern.ParentStyleUsing.UseBorderWidth = false;
            this.txtIntern.ParentStyleUsing.UseFont = false;
            this.txtIntern.ParentStyleUsing.UseForeColor = false;
            this.txtIntern.Size = new System.Drawing.Size(400, 20);
            // 
            // Label18
            // 
            this.Label18.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label18.ForeColor = System.Drawing.Color.Black;
            this.Label18.Location = new System.Drawing.Point(667, 42);
            this.Label18.Name = "Label18";
            this.Label18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label18.ParentStyleUsing.UseBackColor = false;
            this.Label18.ParentStyleUsing.UseBorderColor = false;
            this.Label18.ParentStyleUsing.UseBorders = false;
            this.Label18.ParentStyleUsing.UseBorderWidth = false;
            this.Label18.ParentStyleUsing.UseFont = false;
            this.Label18.ParentStyleUsing.UseForeColor = false;
            this.Label18.Size = new System.Drawing.Size(83, 19);
            this.Label18.Text = "Betrag";
            this.Label18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label17
            // 
            this.Label17.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label17.ForeColor = System.Drawing.Color.Black;
            this.Label17.Location = new System.Drawing.Point(433, 42);
            this.Label17.Name = "Label17";
            this.Label17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label17.ParentStyleUsing.UseBackColor = false;
            this.Label17.ParentStyleUsing.UseBorderColor = false;
            this.Label17.ParentStyleUsing.UseBorders = false;
            this.Label17.ParentStyleUsing.UseBorderWidth = false;
            this.Label17.ParentStyleUsing.UseFont = false;
            this.Label17.ParentStyleUsing.UseForeColor = false;
            this.Label17.Size = new System.Drawing.Size(234, 19);
            this.Label17.Text = "Kostenstelle";
            // 
            // Label16
            // 
            this.Label16.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label16.ForeColor = System.Drawing.Color.Black;
            this.Label16.Location = new System.Drawing.Point(33, 42);
            this.Label16.Name = "Label16";
            this.Label16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label16.ParentStyleUsing.UseBackColor = false;
            this.Label16.ParentStyleUsing.UseBorderColor = false;
            this.Label16.ParentStyleUsing.UseBorders = false;
            this.Label16.ParentStyleUsing.UseBorderWidth = false;
            this.Label16.ParentStyleUsing.UseFont = false;
            this.Label16.ParentStyleUsing.UseForeColor = false;
            this.Label16.Size = new System.Drawing.Size(400, 19);
            this.Label16.Text = "Buchungstext";
            // 
            // txtNameFbKostenart
            // 
            this.txtNameFbKostenart.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameKostenart", "")});
            this.txtNameFbKostenart.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNameFbKostenart.ForeColor = System.Drawing.Color.Black;
            this.txtNameFbKostenart.Location = new System.Drawing.Point(17, 17);
            this.txtNameFbKostenart.Multiline = true;
            this.txtNameFbKostenart.Name = "txtNameFbKostenart";
            this.txtNameFbKostenart.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNameFbKostenart.ParentStyleUsing.UseBackColor = false;
            this.txtNameFbKostenart.ParentStyleUsing.UseBorderColor = false;
            this.txtNameFbKostenart.ParentStyleUsing.UseBorders = false;
            this.txtNameFbKostenart.ParentStyleUsing.UseBorderWidth = false;
            this.txtNameFbKostenart.ParentStyleUsing.UseFont = false;
            this.txtNameFbKostenart.ParentStyleUsing.UseForeColor = false;
            this.txtNameFbKostenart.Size = new System.Drawing.Size(733, 20);
            this.txtNameFbKostenart.Text = "txtNameFbKostenart";
            // 
            // xrLine3
            // 
            this.xrLine3.ForeColor = System.Drawing.Color.Black;
            this.xrLine3.LineWidth = 2;
            this.xrLine3.Location = new System.Drawing.Point(400, 50);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.ParentStyleUsing.UseBackColor = false;
            this.xrLine3.ParentStyleUsing.UseBorderColor = false;
            this.xrLine3.ParentStyleUsing.UseBorders = false;
            this.xrLine3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine3.ParentStyleUsing.UseFont = false;
            this.xrLine3.ParentStyleUsing.UseForeColor = false;
            this.xrLine3.Size = new System.Drawing.Size(349, 4);
            // 
            // xrLine2
            // 
            this.xrLine2.ForeColor = System.Drawing.Color.Black;
            this.xrLine2.LineWidth = 2;
            this.xrLine2.Location = new System.Drawing.Point(0, 8);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.ParentStyleUsing.UseBackColor = false;
            this.xrLine2.ParentStyleUsing.UseBorderColor = false;
            this.xrLine2.ParentStyleUsing.UseBorders = false;
            this.xrLine2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine2.ParentStyleUsing.UseFont = false;
            this.xrLine2.ParentStyleUsing.UseForeColor = false;
            this.xrLine2.Size = new System.Drawing.Size(750, 4);
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.LineWidth = 2;
            this.xrLine1.Location = new System.Drawing.Point(400, 58);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(350, 4);
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "")});
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.ForeColor = System.Drawing.Color.Black;
            this.xrLabel5.Location = new System.Drawing.Point(650, 17);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseBackColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorders = false;
            this.xrLabel5.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.ParentStyleUsing.UseForeColor = false;
            this.xrLabel5.Size = new System.Drawing.Size(100, 27);
            xrSummary2.FormatString = "{0:0.00}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel5.Summary = xrSummary2;
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtCashOrCheckAm
            // 
            this.txtCashOrCheckAm.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BarbelegDatum", "{0:dd.MM.yyyy}")});
            this.txtCashOrCheckAm.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.txtCashOrCheckAm.ForeColor = System.Drawing.Color.Black;
            this.txtCashOrCheckAm.Location = new System.Drawing.Point(117, 158);
            this.txtCashOrCheckAm.Multiline = true;
            this.txtCashOrCheckAm.Name = "txtCashOrCheckAm";
            this.txtCashOrCheckAm.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtCashOrCheckAm.ParentStyleUsing.UseBackColor = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseBorderColor = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseBorders = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseBorderWidth = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseFont = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseForeColor = false;
            this.txtCashOrCheckAm.Size = new System.Drawing.Size(98, 19);
            xrSummary3.FormatString = "{0:dd.MM.yyyy}";
            this.txtCashOrCheckAm.Summary = xrSummary3;
            this.txtCashOrCheckAm.Text = "txtCashOrCheckAm";
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 10F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(308, 158);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(442, 19);
            this.Label6.Text = "Betrag dankend erhalten  ........................................................" +
                "................";
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(25, 158);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(86, 19);
            this.Label5.Text = "Bezahlt am:";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.Location = new System.Drawing.Point(400, 17);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseBackColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.ParentStyleUsing.UseForeColor = false;
            this.xrLabel1.Size = new System.Drawing.Size(250, 27);
            this.xrLabel1.Text = "Auszuzahlender Betrag ";
            // 
            // xrTable1
            // 
            this.xrTable1.Location = new System.Drawing.Point(17, 158);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow1});
            this.xrTable1.Size = new System.Drawing.Size(737, 142);
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.LineWidth = 2;
            this.Line1.Location = new System.Drawing.Point(0, 417);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(750, 4);
            // 
            // Label15
            // 
            this.Label15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "PLZOrt", "")});
            this.Label15.Font = new System.Drawing.Font("Arial", 10F);
            this.Label15.ForeColor = System.Drawing.Color.Black;
            this.Label15.Location = new System.Drawing.Point(33, 392);
            this.Label15.Name = "Label15";
            this.Label15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label15.ParentStyleUsing.UseBackColor = false;
            this.Label15.ParentStyleUsing.UseBorderColor = false;
            this.Label15.ParentStyleUsing.UseBorders = false;
            this.Label15.ParentStyleUsing.UseBorderWidth = false;
            this.Label15.ParentStyleUsing.UseFont = false;
            this.Label15.ParentStyleUsing.UseForeColor = false;
            this.Label15.Size = new System.Drawing.Size(717, 19);
            this.Label15.Text = "Label15";
            // 
            // txtStrasse
            // 
            this.txtStrasse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Strasse", "")});
            this.txtStrasse.Font = new System.Drawing.Font("Arial", 10F);
            this.txtStrasse.ForeColor = System.Drawing.Color.Black;
            this.txtStrasse.Location = new System.Drawing.Point(33, 367);
            this.txtStrasse.Multiline = true;
            this.txtStrasse.Name = "txtStrasse";
            this.txtStrasse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtStrasse.ParentStyleUsing.UseBackColor = false;
            this.txtStrasse.ParentStyleUsing.UseBorderColor = false;
            this.txtStrasse.ParentStyleUsing.UseBorders = false;
            this.txtStrasse.ParentStyleUsing.UseBorderWidth = false;
            this.txtStrasse.ParentStyleUsing.UseFont = false;
            this.txtStrasse.ParentStyleUsing.UseForeColor = false;
            this.txtStrasse.Size = new System.Drawing.Size(717, 19);
            this.txtStrasse.Text = "Strasse";
            // 
            // FullName1
            // 
            this.FullName1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AuszuzahlenAn", "")});
            this.FullName1.Font = new System.Drawing.Font("Arial", 10F);
            this.FullName1.ForeColor = System.Drawing.Color.Black;
            this.FullName1.Location = new System.Drawing.Point(33, 342);
            this.FullName1.Multiline = true;
            this.FullName1.Name = "FullName1";
            this.FullName1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.FullName1.ParentStyleUsing.UseBackColor = false;
            this.FullName1.ParentStyleUsing.UseBorderColor = false;
            this.FullName1.ParentStyleUsing.UseBorders = false;
            this.FullName1.ParentStyleUsing.UseBorderWidth = false;
            this.FullName1.ParentStyleUsing.UseFont = false;
            this.FullName1.ParentStyleUsing.UseForeColor = false;
            this.FullName1.Size = new System.Drawing.Size(717, 19);
            this.FullName1.Text = "FullName1";
            // 
            // Label14
            // 
            this.Label14.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.Label14.ForeColor = System.Drawing.Color.Black;
            this.Label14.Location = new System.Drawing.Point(17, 317);
            this.Label14.Name = "Label14";
            this.Label14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label14.ParentStyleUsing.UseBackColor = false;
            this.Label14.ParentStyleUsing.UseBorderColor = false;
            this.Label14.ParentStyleUsing.UseBorders = false;
            this.Label14.ParentStyleUsing.UseBorderWidth = false;
            this.Label14.ParentStyleUsing.UseFont = false;
            this.Label14.ParentStyleUsing.UseForeColor = false;
            this.Label14.Size = new System.Drawing.Size(125, 23);
            this.Label14.Text = "Auszahlung an:";
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Gainsboro;
            this.Label4.BorderColor = System.Drawing.Color.Black;
            this.Label4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Label4.Font = new System.Drawing.Font("Arial", 18F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(124, 98);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(501, 39);
            this.Label4.Text = "Kassenbeleg";
            this.Label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Label3
            // 
            this.Label3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_PLZOrt", "")});
            this.Label3.Font = new System.Drawing.Font("Arial", 11F);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(567, 25);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(200, 23);
            this.Label3.Text = "Org_PLZOrt";
            // 
            // Label2
            // 
            this.Label2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Adresse", "")});
            this.Label2.Font = new System.Drawing.Font("Arial", 11F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(567, 0);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(200, 23);
            this.Label2.Text = "Org_Adresse";
            // 
            // Label1
            // 
            this.Label1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Name", "")});
            this.Label1.Font = new System.Drawing.Font("Arial", 14F);
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
            this.Label1.Size = new System.Drawing.Size(338, 39);
            this.Label1.Text = "Org_Name";
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell1});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Size = new System.Drawing.Size(737, 142);
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
                        this.Label12,
                        this.Label11,
                        this.Label9,
                        this.txtNameKassier,
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
            this.xrTableCell1.Size = new System.Drawing.Size(737, 142);
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
            this.xrLabel4.Location = new System.Drawing.Point(346, 28);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.ParentStyleUsing.UseForeColor = false;
            this.xrLabel4.Size = new System.Drawing.Size(125, 17);
            this.xrLabel4.Text = "Valuta";
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
            this.xrLabel2.Size = new System.Drawing.Size(258, 18);
            xrSummary4.FormatString = "{0:dd.MM.yyyy}";
            this.xrLabel2.Summary = xrSummary4;
            this.xrLabel2.Text = "xrLabel2";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(346, 89);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(125, 20);
            this.xrLabel3.Text = "Bemerkung";
            // 
            // txtBemerkung
            // 
            this.txtBemerkung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Remark", "")});
            this.txtBemerkung.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBemerkung.ForeColor = System.Drawing.Color.Black;
            this.txtBemerkung.Location = new System.Drawing.Point(473, 89);
            this.txtBemerkung.Multiline = true;
            this.txtBemerkung.Name = "txtBemerkung";
            this.txtBemerkung.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBemerkung.ParentStyleUsing.UseBackColor = false;
            this.txtBemerkung.ParentStyleUsing.UseBorderColor = false;
            this.txtBemerkung.ParentStyleUsing.UseBorders = false;
            this.txtBemerkung.ParentStyleUsing.UseBorderWidth = false;
            this.txtBemerkung.ParentStyleUsing.UseFont = false;
            this.txtBemerkung.ParentStyleUsing.UseForeColor = false;
            this.txtBemerkung.Size = new System.Drawing.Size(258, 18);
            this.txtBemerkung.Text = "txtBemerkung";
            // 
            // Label12
            // 
            this.Label12.Font = new System.Drawing.Font("Arial", 10F);
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(346, 69);
            this.Label12.Name = "Label12";
            this.Label12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label12.ParentStyleUsing.UseBackColor = false;
            this.Label12.ParentStyleUsing.UseBorderColor = false;
            this.Label12.ParentStyleUsing.UseBorders = false;
            this.Label12.ParentStyleUsing.UseBorderWidth = false;
            this.Label12.ParentStyleUsing.UseFont = false;
            this.Label12.ParentStyleUsing.UseForeColor = false;
            this.Label12.Size = new System.Drawing.Size(125, 17);
            this.Label12.Text = "Kassier";
            // 
            // Label11
            // 
            this.Label11.Font = new System.Drawing.Font("Arial", 10F);
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(346, 48);
            this.Label11.Name = "Label11";
            this.Label11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label11.ParentStyleUsing.UseBackColor = false;
            this.Label11.ParentStyleUsing.UseBorderColor = false;
            this.Label11.ParentStyleUsing.UseBorders = false;
            this.Label11.ParentStyleUsing.UseBorderWidth = false;
            this.Label11.ParentStyleUsing.UseFont = false;
            this.Label11.ParentStyleUsing.UseForeColor = false;
            this.Label11.Size = new System.Drawing.Size(125, 19);
            this.Label11.Text = "Sozialarbeiter";
            // 
            // Label9
            // 
            this.Label9.Font = new System.Drawing.Font("Arial", 10F);
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(346, 8);
            this.Label9.Name = "Label9";
            this.Label9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label9.ParentStyleUsing.UseBackColor = false;
            this.Label9.ParentStyleUsing.UseBorderColor = false;
            this.Label9.ParentStyleUsing.UseBorders = false;
            this.Label9.ParentStyleUsing.UseBorderWidth = false;
            this.Label9.ParentStyleUsing.UseFont = false;
            this.Label9.ParentStyleUsing.UseForeColor = false;
            this.Label9.Size = new System.Drawing.Size(125, 19);
            this.Label9.Text = "Auszahlungsmonat";
            // 
            // txtNameKassier
            // 
            this.txtNameKassier.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameKassier", "")});
            this.txtNameKassier.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNameKassier.ForeColor = System.Drawing.Color.Black;
            this.txtNameKassier.Location = new System.Drawing.Point(473, 69);
            this.txtNameKassier.Multiline = true;
            this.txtNameKassier.Name = "txtNameKassier";
            this.txtNameKassier.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNameKassier.ParentStyleUsing.UseBackColor = false;
            this.txtNameKassier.ParentStyleUsing.UseBorderColor = false;
            this.txtNameKassier.ParentStyleUsing.UseBorders = false;
            this.txtNameKassier.ParentStyleUsing.UseBorderWidth = false;
            this.txtNameKassier.ParentStyleUsing.UseFont = false;
            this.txtNameKassier.ParentStyleUsing.UseForeColor = false;
            this.txtNameKassier.Size = new System.Drawing.Size(258, 19);
            this.txtNameKassier.Text = "NameKassier";
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
            this.txtEmployeeName.Size = new System.Drawing.Size(258, 19);
            this.txtEmployeeName.Text = "EmployeeName";
            // 
            // txtNameYearMonth
            // 
            this.txtNameYearMonth.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameYearMonth", "")});
            this.txtNameYearMonth.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNameYearMonth.ForeColor = System.Drawing.Color.Black;
            this.txtNameYearMonth.Location = new System.Drawing.Point(473, 7);
            this.txtNameYearMonth.Multiline = true;
            this.txtNameYearMonth.Name = "txtNameYearMonth";
            this.txtNameYearMonth.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNameYearMonth.ParentStyleUsing.UseBackColor = false;
            this.txtNameYearMonth.ParentStyleUsing.UseBorderColor = false;
            this.txtNameYearMonth.ParentStyleUsing.UseBorders = false;
            this.txtNameYearMonth.ParentStyleUsing.UseBorderWidth = false;
            this.txtNameYearMonth.ParentStyleUsing.UseFont = false;
            this.txtNameYearMonth.ParentStyleUsing.UseForeColor = false;
            this.txtNameYearMonth.Size = new System.Drawing.Size(258, 20);
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
            this.txtFullName.Size = new System.Drawing.Size(269, 27);
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
            this.txtFlBelegID.Size = new System.Drawing.Size(269, 27);
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
            this.xrControl1.Size = new System.Drawing.Size(737, 142);
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
                        this.ReportFooter,
                        this.ReportHeader});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(39, 19, 39, 39);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
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
</NewDataSet>' , SQLquery =  N'DECLARE @KbBuchungID INT;
SET @KbBuchungID = {KbBuchungID}; -- (TestCase)13441

SELECT DISTINCT
  Org_Name             = ISNULL(CONVERT(VARCHAR(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Organisation'', GETDATE())), ''''),
  Org_Adresse          = ISNULL(CONVERT(VARCHAR(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Adresse'', GETDATE())), ''''),
  Org_PLZ              = ISNULL(CONVERT(VARCHAR(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', GETDATE())), ''''),
  Org_Ort              = ISNULL(CONVERT(VARCHAR(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', GETDATE())), ''''),
  Org_PLZOrt           = ISNULL(CONVERT(VARCHAR(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', GETDATE())) + '' '', '''') +
                         ISNULL(CONVERT(VARCHAR(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', GETDATE())), ''''),
  KbAuszahlungsartCode = BUC.KbAuszahlungsartCode,
  KbBuchungID          = BUC.KbBuchungID,
  KbBuchungStatusCode  = BUC.KbBuchungStatusCode,
  NameKbBuchungsStatus = dbo.fnLOVText(''KbBuchungsStatus'', BUC.KbBuchungStatusCode),
  NameKbAuszahlungsArt = dbo.fnLOVText(''KbAuszahlungsArt'', BUC.KbAuszahlungsartCode),
  NameYearMonth        = dbo.fnXMonat(BDG.Monat) + '' '' + CONVERT(VARCHAR, BDG.Jahr),
  Verfalldatum         = DATEADD(DAY, 5, BUC.ValutaDatum),
  KbBuchungKostensrtID = KBK.KbBuchungKostenartID,
  Buchungstext         = KBK.Buchungstext,
  Betrag               = KBK.Betrag,
  NameKostenart        = BGK.Name,
  NameKostenstelle     = KST.Name,--ISNULL(KST.Name, KPR.NameVorname),
  KBKPersonID          = KBK.BaPersonID,
  KbKostenstelleID     = KBK.KbKostenstelleID,
  NameKassier          = KUSR.LastName + ISNULL('', '' + KUSR.FirstName, '''') + ISNULL('' ('' + KUSR.Phone + '')'', ''''),
  FullName             = PRS.NameVorname,
  AuszuzahlenAn        = ISNULL(NULLIF(BUC.BeguenstigtName, ''''), PRS.NameVorname),
  Strasse              = ISNULL(NULLIF(BUC.BeguenstigtStrasse, ''''), PRS.WohnsitzStrasseHausNr),
  PLZOrt               = ISNULL(NULLIF(BUC.BeguenstigtOrt, ''''), PRS.WohnsitzPLZOrt),
  PLZ                  = PRS.WohnsitzPLZ,
  Ort                  = PRS.WohnsitzOrt,
  BelegNr              = BUC.BelegNr,
  EmployeeName         = USR.LastName + ISNULL('', '' + USR.FirstName, '''') + ISNULL('' ('' + USR.Phone + '')'', ''''),
  Remark               = BUC.Remark,
  ValutaDatum          = BUC.ValutaDatum,
  BarbelegDatum        = BUC.BarbelegDatum
FROM dbo.FaLeistung                      FAL  WITH(READUNCOMMITTED)
  INNER JOIN dbo.vwPerson                PRS  WITH(READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID
  INNER JOIN dbo.BgFinanzplan            FPL  WITH(READUNCOMMITTED) ON FPL.FaLeistungID = FAL.FaLeistungID
  INNER JOIN dbo.BgFinanzplan_BaPerson   FBP  WITH(READUNCOMMITTED) ON FBP.BgFinanzplanID = FPL.BgFinanzplanID
                                                                   AND FBP.IstUnterstuetzt = 1
  INNER JOIN dbo.BgBudget                BDG  WITH(READUNCOMMITTED) ON BDG.BgFinanzplanID = FPL.BgFinanzplanID
  INNER JOIN dbo.KbBuchung               BUC  WITH(READUNCOMMITTED) ON BUC.BgBudgetID = BDG.BgBudgetID
  INNER JOIN dbo.KbBuchungKostenart      KBK  WITH(READUNCOMMITTED) ON KBK.KbBuchungID = BUC.KbBuchungID
  INNER JOIN dbo.XUser                   USR  WITH(READUNCOMMITTED) ON USR.UserID = FAL.UserID
  LEFT  JOIN dbo.XUser                   KUSR WITH(READUNCOMMITTED) ON KUSR.UserID = BUC.BarbelegUserID
  LEFT  JOIN dbo.BgKostenart             BGK  WITH(READUNCOMMITTED) ON BGK.BgKostenartID = KBK.BgKostenartID
  LEFT  JOIN dbo.KbKostenstelle	         KST  WITH(READUNCOMMITTED) ON KST.KbKostenstelleID = KBK.KbKostenstelleID
--  LEFT  JOIN dbo.KbKostenstelle_BaPerson KSP  WITH(READUNCOMMITTED) ON KSP.KbKostenstelleID = KBK.KbKostenstelleID
--  LEFT  JOIN dbo.vwPersonSimple          KPR  WITH(READUNCOMMITTED) ON KPR.BaPersonID = KSP.BaPersonID
WHERE BUC.KbBuchungID = @KbBuchungID
ORDER BY NameKostenart ASC, Betrag DESC;' , ContextForms =  N'FrmKasse' , ParentReportName =  null , ReportSortKey = 10
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'ShKassenbeleg' ;


