-- Insert Script for ShKontoauszug
-- MD5:0X1519FFC439833C84C51BF6B7CEDB18E8_0XE7DC1D830277A46F61EB7523C744C544_0XD302C75E6161D94C42A8D1C38B59686C
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'ShKontoauszug') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('ShKontoauszug', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'ShKontoauszug';
--SQLCHECK_IGNORE--
UPDATE QRY
SET QueryName =  N'ShKontoauszug' , UserText =  N'SH - Kontoauszug' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Deployment\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Deployment.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Core\v4.0_4.0.0.0__b77a5c561934e089\System.Core.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Numerics\v4.0_4.0.0.0__b77a5c561934e089\System.Numerics.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Serialization.Formatters.Soap\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Runtime.Serialization.Formatters.Soap.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Design\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Design.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Data\v4.0_4.0.0.0__b77a5c561934e089\System.Data.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Transactions\v4.0_4.0.0.0__b77a5c561934e089\System.Transactions.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.EnterpriseServices\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.EnterpriseServices.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.DirectoryServices\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Remoting\v4.0_4.0.0.0__b77a5c561934e089\System.Runtime.Remoting.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Web\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Framework\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Framework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xaml\v4.0_4.0.0.0__b77a5c561934e089\System.Xaml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ComponentModel.DataAnnotations\v4.0_4.0.0.0__31bf3856ad364e35\System.ComponentModel.DataAnnotations.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Caching\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Runtime.Caching.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Web.ApplicationServices\v4.0_4.0.0.0__31bf3856ad364e35\System.Web.ApplicationServices.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Web.Services\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.Services.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Utilities.v4.0\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Utilities.v4.0.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.DirectoryServices.Protocols\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.Protocols.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Tasks.v4.0\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Tasks.v4.0.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ServiceProcess\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.ServiceProcess.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Configuration.Install\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.Install.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Serialization\v4.0_4.0.0.0__b77a5c561934e089\System.Runtime.Serialization.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Internals\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Internals.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\SMDiagnostics\v4.0_4.0.0.0__b77a5c561934e089\SMDiagnostics.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Web.RegularExpressions\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.RegularExpressions.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Drawing.Design\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.Design.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Data.OracleClient\v4.0_4.0.0.0__b77a5c561934e089\System.Data.OracleClient.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraEditors.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.Data.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Data.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraBars.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraNavBar.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraCharts.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraRichTextEdit.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS-Branches\KiSS4444\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS-Branches\KiSS4444\Build\Debug\Kiss.Interfaces.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS-Branches\KiSS4444\Build\Debug\Microsoft.Practices.Unity.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS-Branches\KiSS4444\Build\Debug\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS-Branches\KiSS4444\Build\Debug\FluentValidation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xml.Linq\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.Linq.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS-Branches\KiSS4444\Build\Debug\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS-Branches\KiSS4444\Build\Debug\log4net.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Projects\KiSS\KiSS-Branches\KiSS4444\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel26;
        private DevExpress.XtraReports.UI.XRLabel xrLabel28;
        private DevExpress.XtraReports.UI.XRLabel xrLabel25;
        private DevExpress.XtraReports.UI.XRLabel xrLabel24;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel Klient;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRPanel xrPanel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRLabel xrLabel23;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAACAAAAAAAAAFBBRFBBRFATtE6kX" +
                        "vDYwj0AAAAAAAAAOAEAADhSAGUAcABvAHIAdAAuAFMAYwByAGkAcAB0AHMALgBPAG4AQgBlAGYAbwByA" +
                        "GUAUAByAGkAbgB0AAAAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAb" +
                        "QBlAG4AdAB3AQAAAfQCcHJpdmF0ZSB2b2lkIE9uQmVmb3JlUHJpbnQob2JqZWN0IHNlbmRlciwgU3lzd" +
                        "GVtLkRyYXdpbmcuUHJpbnRpbmcuUHJpbnRFdmVudEFyZ3MgZSkgew0KDQpkZWNpbWFsIHNhbGRvID0gM" +
                        "DsNCktpU1M0LkRCLlNxbFF1ZXJ5IHFyeSA9IChLaVNTNC5EQi5TcWxRdWVyeSlSZXBvcnQuRGF0YVNvd" +
                        "XJjZTsNCmZvcmVhY2ggKFN5c3RlbS5EYXRhLkRhdGFSb3cgcm93IGluIHFyeS5EYXRhVGFibGUuUm93c" +
                        "ykNCnsNCglzYWxkbyArPSAgKHJvd1siQXVzZ2FiZSJdIGFzIGRlY2ltYWw/ID8/IDApIC0gKHJvd1siR" +
                        "WlubmFobWUiXSBhcyBkZWNpbWFsPyA/PyAwKTsNCglyb3dbIlNhbGRvIl0gPSBzYWxkbzsNCn0NClJlc" +
                        "G9ydC5EYXRhU291cmNlID0gcXJ5Ow0KDQp9AdQTLyoNClNhbGRvIHdpcmQgw7xiZXIgT25CZWZvcmVQc" +
                        "mludCBFdmVudCBiZXJlY2huZXQhDQoqLw0KDQpERUNMQVJFIEBCYVBlcnNvbklEIElOVDsgICAgICAgI" +
                        "CAgLS0tIEZhbGx0csOkZ2VyDQpERUNMQVJFIEBQZXJzb24gVkFSQ0hBUig1MDApOyAgICAgLS0tIEF1c" +
                        "3dhaGwgTWFza2UgKFVFLVBlcnNvbmVuKQ0KREVDTEFSRSBAWmVpdHJhdW0gSU5UOyAgICAgICAgICAgI" +
                        "C0tLSBBdXN3YWhsIE1hc2tlDQpERUNMQVJFIEBMYUxpc3QgVkFSQ0hBUig1MDApOyAgICAgLS0tIEF1c" +
                        "3dhaGwgTWFza2UNCkRFQ0xBUkUgQERhdHVtVm9uIERBVEVUSU1FOyAgICAgICAtLS0gQXVzd2FobCBNY" +
                        "XNrZQ0KREVDTEFSRSBARGF0dW1CaXMgREFURVRJTUU7ICAgICAgIC0tLSBBdXN3YWhsIE1hc2tlDQpER" +
                        "UNMQVJFIEBWZXJkaWNodGV0IEJJVDsgICAgICAgICAgLS0tIEF1c3dhaGwgTWFza2UNCkRFQ0xBUkUgQ" +
                        "EJldHJhZWdlQW5wYXNzZW4gQklUOyAgICAtLS0gQXVzd2FobCBNYXNrZQ0KREVDTEFSRSBARmFMZWlzd" +
                        "HVuZ0lEIElOVDsNCg0KU0VMRUNUIEBCYVBlcnNvbklEICAgICAgID0gbnVsbCwNCiAgICAgICBAUGVyc" +
                        "29uICAgICAgICAgICA9IG51bGwsDQogICAgICAgQFplaXRyYXVtICAgICAgICAgPSBudWxsLA0KICAgI" +
                        "CAgIEBMYUxpc3QgICAgICAgICAgID0gbnVsbCwNCiAgICAgICBARGF0dW1Wb24gICAgICAgICA9IG51b" +
                        "GwsDQogICAgICAgQERhdHVtQmlzICAgICAgICAgPSBudWxsLA0KICAgICAgIEBWZXJkaWNodGV0ICAgI" +
                        "CAgID0gbnVsbCwNCiAgICAgICBAQmV0cmFlZ2VBbnBhc3NlbiA9IG51bGwsDQogICAgICAgQEZhTGVpc" +
                        "3R1bmdJRCAgICAgPSBudWxsOw0KDQpJRiAoT0JKRUNUX0lEKCdUZW1wREIuZGJvLiNUbXBLb250b0F1c" +
                        "3p1ZycpIElTIE5PVCBOVUxMKQ0KQkVHSU4gDQogIERST1AgVEFCTEUgI1RtcEtvbnRvQXVzenVnOw0KR" +
                        "U5EOw0KDQpDUkVBVEUgVEFCTEUgI1RtcEtvbnRvQXVzenVnDQooDQogIE9yZ05hbWUgVkFSQ0hBUigxM" +
                        "DAwKSwgDQogIE9yZ0FkcmVzc2UgVkFSQ0hBUigxMDAwKSwgDQogIE9yZ1BMWk9ydCBWQVJDSEFSKDEwM" +
                        "DApLA0KICBOZXVlU2VpdGUgQklULA0KICBEcnVja0RhdHVtIFZBUkNIQVIoMjAwKSwNCiAgQXVzd2Vyd" +
                        "HVuZ3N6ZWl0cmF1bSBWQVJDSEFSKDIwMCksDQogIEtiQnVjaHVuZ0lEIElOVCwNCiAgQmVsZWdEYXR1b" +
                        "SBEQVRFVElNRSwNCiAgVmFsdXRhRGF0dW0gREFURVRJTUUsDQogIEJhUGVyc29uSUQgSU5ULA0KICBLb" +
                        "GllbnQgVkFSQ0hBUigyMDApLA0KICBCZWxlZ05yIFZBUkNIQVIoMjApLA0KICBMQSBWQVJDSEFSKDEwK" +
                        "SwNCiAgTEFUZXh0IFZBUkNIQVIoMTUwKSwNCiAgQnVjaHVuZ3N0ZXh0IFZBUkNIQVIoMjAwKSwNCiAgV" +
                        "mVyd1BlcmlvZGVWb24gREFURVRJTUUsDQogIFZlcndQZXJpb2RlQmlzIERBVEVUSU1FLA0KICBCZ1Nwb" +
                        "Gl0dGluZ0FydENvZGUgSU5ULA0KICBCZXRyYWcgTU9ORVksDQogIEJldHJhZ1NhbGRvIE1PTkVZLA0KI" +
                        "CBCZXRyYWcxMDAgTU9ORVksDQogIEVBIFZBUkNIQVIoMSksIC0tIEUgPSBFaW5uYWhtZSwgQSA9IEF1c" +
                        "2dhYmUNCiAgS2JCdWNodW5nU3RhdHVzQ29kZSBJTlQsDQogIERvYyBWQVJDSEFSKDEpLA0KICBBdXN6Y" +
                        "WhsYXJ0IFZBUkNIQVIoMTAwKSwNCiAgS3JlZGl0b3JEZWJpdG9yIFZBUkNIQVIoMjAwMCksDQogIEVpb" +
                        "m5haG1lIE1PTkVZLA0KICBBdXNnYWJlIE1PTkVZLA0KICBTYWxkbyBNT05FWQ0KKTsNCg0KSU5TRVJUI" +
                        "ElOVE8gI1RtcEtvbnRvQXVzenVnDQogIEVYRUMgZGJvLnNwV2hLb250b2F1c3p1ZyBAQmFQZXJzb25JR" +
                        "CwgQFBlcnNvbiwgQFplaXRyYXVtLCBARGF0dW1Wb24sIEBEYXR1bUJpcywgQExhTGlzdCwgQFZlcmRpY" +
                        "2h0ZXQsIEBCZXRyYWVnZUFucGFzc2VuLCBARmFMZWlzdHVuZ0lEOw0KDQpTRUxFQ1QNCiAgS2JCdWNod" +
                        "W5nSUQsDQogIEJlbGVnRGF0dW0sDQogIFZhbHV0YURhdHVtLA0KICBCZWxlZ05yLA0KICBMQSwNCiAgT" +
                        "EFUZXh0LA0KICBCdWNodW5nc3RleHQsDQogIFZlcndQZXJpb2RlVm9uLA0KICBWZXJ3UGVyaW9kZUJpc" +
                        "ywNCiAgQmdTcGxpdHRpbmdBcnRDb2RlLA0KICBFQSwNCiAgS2JCdWNodW5nU3RhdHVzQ29kZSwNCiAgR" +
                        "G9jLA0KICBBdXN6YWhsYXJ0LA0KICBLcmVkaXRvckRlYml0b3IsDQogIFRNUC5CYVBlcnNvbklELA0KI" +
                        "CBLbGllbnQsDQogIEJldHJhZywNCiAgQmV0cmFnMTAwLA0KICBFaW5uYWhtZSwNCiAgQXVzZ2FiZSwNC" +
                        "iAgU2FsZG8sDQogIEZUID0gUFJTLk5hbWVWb3JuYW1lLA0KICBBSFZOdW1tZXIgPSBQUlMuQUhWTnVtb" +
                        "WVyDQpGUk9NICNUbXBLb250b0F1c3p1ZyAgICAgIFRNUA0KICBJTk5FUiBKT0lOIGRiby52d1BlcnNvb" +
                        "iBQUlMgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKSBPTiBQUlMuQmFQZXJzb25JRCA9IEBCYVBlcnNvbklEI" +
                        "C0tIEZhbGx0csOkZ2VyDQpPUkRFUiBCWSBCZWxlZ0RhdHVtIEFTQzsNCg0KSUYgKE9CSkVDVF9JRCgnV" +
                        "GVtcERCLmRiby4jVG1wS29udG9BdXN6dWcnKSBJUyBOT1QgTlVMTCkNCkJFR0lOIA0KICBEUk9QIFRBQ" +
                        "kxFICNUbXBLb250b0F1c3p1ZzsNCkVORDs=";
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
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Klient = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel2 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel2,
                        this.xrLabel15,
                        this.xrLabel10,
                        this.xrLabel9,
                        this.xrLabel8,
                        this.xrLabel7,
                        this.xrLabel6,
                        this.xrLabel5,
                        this.xrLabel4});
            this.Detail.Height = 20;
            this.Detail.Name = "Detail";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel26,
                        this.xrLabel28,
                        this.xrLabel25,
                        this.xrLabel24,
                        this.xrLabel20,
                        this.xrLabel19,
                        this.xrLabel1,
                        this.Klient,
                        this.xrLabel18,
                        this.xrLabel17,
                        this.xrLabel16,
                        this.xrLabel14,
                        this.xrLabel13,
                        this.xrLabel12,
                        this.xrLabel11,
                        this.xrLabel3});
            this.ReportHeader.Height = 150;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPanel2});
            this.GroupFooter1.Height = 25;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BelegDatum", "{0:dd.MM.yyyy}")});
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel2.Location = new System.Drawing.Point(0, 0);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseBorders = false;
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(83, 20);
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel15
            // 
            this.xrLabel15.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Klient", "")});
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel15.Location = new System.Drawing.Point(83, 0);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.ParentStyleUsing.UseBorders = false;
            this.xrLabel15.ParentStyleUsing.UseFont = false;
            this.xrLabel15.Size = new System.Drawing.Size(133, 20);
            this.xrLabel15.Text = "xrLabel2";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Saldo", "{0:n2}")});
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel10.Location = new System.Drawing.Point(842, 0);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.ParentStyleUsing.UseBorders = false;
            this.xrLabel10.ParentStyleUsing.UseFont = false;
            this.xrLabel10.Size = new System.Drawing.Size(75, 20);
            xrSummary1.FormatString = "{0:n2}";
            xrSummary1.IgnoreNullValues = true;
            this.xrLabel10.Summary = xrSummary1;
            this.xrLabel10.Text = "xrLabel10";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Einnahme", "{0:n2}")});
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel9.Location = new System.Drawing.Point(767, 0);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.ParentStyleUsing.UseBorders = false;
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.Size = new System.Drawing.Size(75, 20);
            this.xrLabel9.Text = "xrLabel9";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Ausgabe", "{0:n2}")});
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel8.Location = new System.Drawing.Point(683, 0);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseBorders = false;
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.Size = new System.Drawing.Size(84, 20);
            this.xrLabel8.Text = "xrLabel8";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VerwPeriodeVon", "{0:dd.MM.yyyy}")});
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel7.Location = new System.Drawing.Point(533, 0);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseBorders = false;
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.Size = new System.Drawing.Size(75, 20);
            this.xrLabel7.Text = "xrLabel6";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VerwPeriodeBis", "{0:dd.MM.yyyy}")});
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel6.Location = new System.Drawing.Point(608, 0);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseBorders = false;
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.Size = new System.Drawing.Size(75, 20);
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrLabel5.CanGrow = false;
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Buchungstext", "")});
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel5.Location = new System.Drawing.Point(250, 0);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseBorders = false;
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(283, 20);
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "LA", "")});
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel4.Location = new System.Drawing.Point(216, 0);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(34, 20);
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel26
            // 
            this.xrLabel26.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel26.Location = new System.Drawing.Point(725, 0);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.ParentStyleUsing.UseFont = false;
            this.xrLabel26.Size = new System.Drawing.Size(191, 42);
            this.xrLabel26.Text = "Sozialdienst Münchenbuchsee";
            // 
            // xrLabel28
            // 
            this.xrLabel28.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel28.Location = new System.Drawing.Point(533, 92);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.ParentStyleUsing.UseFont = false;
            this.xrLabel28.Size = new System.Drawing.Size(109, 25);
            this.xrLabel28.Text = "Saldoübernahme";
            // 
            // xrLabel25
            // 
            this.xrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "FT", "")});
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel25.Location = new System.Drawing.Point(0, 0);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.ParentStyleUsing.UseBorders = false;
            this.xrLabel25.ParentStyleUsing.UseFont = false;
            this.xrLabel25.Size = new System.Drawing.Size(133, 25);
            this.xrLabel25.Text = "xrLabel25";
            // 
            // xrLabel24
            // 
            this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AHVNummer", "")});
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel24.Location = new System.Drawing.Point(75, 42);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.ParentStyleUsing.UseFont = false;
            this.xrLabel24.Size = new System.Drawing.Size(100, 25);
            this.xrLabel24.Text = "AHV-Nr.";
            // 
            // xrLabel20
            // 
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel20.Location = new System.Drawing.Point(0, 42);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.ParentStyleUsing.UseFont = false;
            this.xrLabel20.Size = new System.Drawing.Size(75, 25);
            this.xrLabel20.Text = "AHV-Nr.";
            // 
            // xrLabel19
            // 
            this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BaPersonID", "")});
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel19.Location = new System.Drawing.Point(75, 67);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.ParentStyleUsing.UseFont = false;
            this.xrLabel19.Size = new System.Drawing.Size(100, 25);
            this.xrLabel19.Text = "xrLabel1";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel1.Location = new System.Drawing.Point(0, 68);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(75, 25);
            this.xrLabel1.Text = "Personennr.";
            // 
            // Klient
            // 
            this.Klient.BackColor = System.Drawing.Color.Silver;
            this.Klient.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.Klient.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Klient.Location = new System.Drawing.Point(83, 125);
            this.Klient.Name = "Klient";
            this.Klient.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Klient.ParentStyleUsing.UseBackColor = false;
            this.Klient.ParentStyleUsing.UseBorders = false;
            this.Klient.ParentStyleUsing.UseFont = false;
            this.Klient.Size = new System.Drawing.Size(133, 25);
            this.Klient.Text = "Klient/in";
            this.Klient.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel18
            // 
            this.xrLabel18.BackColor = System.Drawing.Color.Silver;
            this.xrLabel18.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel18.Location = new System.Drawing.Point(842, 125);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.ParentStyleUsing.UseBackColor = false;
            this.xrLabel18.ParentStyleUsing.UseBorders = false;
            this.xrLabel18.ParentStyleUsing.UseFont = false;
            this.xrLabel18.Size = new System.Drawing.Size(75, 25);
            this.xrLabel18.Text = "Saldo";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel17
            // 
            this.xrLabel17.BackColor = System.Drawing.Color.Silver;
            this.xrLabel17.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel17.Location = new System.Drawing.Point(767, 125);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.ParentStyleUsing.UseBackColor = false;
            this.xrLabel17.ParentStyleUsing.UseBorders = false;
            this.xrLabel17.ParentStyleUsing.UseFont = false;
            this.xrLabel17.Size = new System.Drawing.Size(75, 25);
            this.xrLabel17.Text = "Einnahme";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel16
            // 
            this.xrLabel16.BackColor = System.Drawing.Color.Silver;
            this.xrLabel16.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel16.Location = new System.Drawing.Point(683, 125);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.ParentStyleUsing.UseBackColor = false;
            this.xrLabel16.ParentStyleUsing.UseBorders = false;
            this.xrLabel16.ParentStyleUsing.UseFont = false;
            this.xrLabel16.Size = new System.Drawing.Size(84, 25);
            this.xrLabel16.Text = "Auszahlung";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel14
            // 
            this.xrLabel14.BackColor = System.Drawing.Color.Silver;
            this.xrLabel14.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.Location = new System.Drawing.Point(533, 125);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.ParentStyleUsing.UseBackColor = false;
            this.xrLabel14.ParentStyleUsing.UseBorders = false;
            this.xrLabel14.ParentStyleUsing.UseFont = false;
            this.xrLabel14.Size = new System.Drawing.Size(75, 25);
            this.xrLabel14.Text = "Verw.P.von";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel13
            // 
            this.xrLabel13.BackColor = System.Drawing.Color.Silver;
            this.xrLabel13.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.Location = new System.Drawing.Point(608, 125);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.ParentStyleUsing.UseBackColor = false;
            this.xrLabel13.ParentStyleUsing.UseBorders = false;
            this.xrLabel13.ParentStyleUsing.UseFont = false;
            this.xrLabel13.Size = new System.Drawing.Size(75, 25);
            this.xrLabel13.Text = "Verw.P.bis";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel12
            // 
            this.xrLabel12.BackColor = System.Drawing.Color.Silver;
            this.xrLabel12.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel12.Location = new System.Drawing.Point(250, 125);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.ParentStyleUsing.UseBackColor = false;
            this.xrLabel12.ParentStyleUsing.UseBorders = false;
            this.xrLabel12.ParentStyleUsing.UseFont = false;
            this.xrLabel12.Size = new System.Drawing.Size(283, 25);
            this.xrLabel12.Text = "Buchungstext";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.BackColor = System.Drawing.Color.Silver;
            this.xrLabel11.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.Location = new System.Drawing.Point(216, 125);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.ParentStyleUsing.UseBackColor = false;
            this.xrLabel11.ParentStyleUsing.UseBorders = false;
            this.xrLabel11.ParentStyleUsing.UseFont = false;
            this.xrLabel11.Size = new System.Drawing.Size(34, 25);
            this.xrLabel11.Text = "KoA";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.BackColor = System.Drawing.Color.Silver;
            this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.Location = new System.Drawing.Point(0, 125);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(83, 25);
            this.xrLabel3.Text = "Beleg-Datum";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPanel2
            // 
            this.xrPanel2.BackColor = System.Drawing.Color.Silver;
            this.xrPanel2.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrPanel2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel21,
                        this.xrLabel22,
                        this.xrLabel23});
            this.xrPanel2.Location = new System.Drawing.Point(0, 0);
            this.xrPanel2.Name = "xrPanel2";
            this.xrPanel2.ParentStyleUsing.UseBackColor = false;
            this.xrPanel2.ParentStyleUsing.UseBorders = false;
            this.xrPanel2.Size = new System.Drawing.Size(917, 25);
            // 
            // xrLabel21
            // 
            this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Einnahme", "{0:n2}")});
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel21.Location = new System.Drawing.Point(758, 0);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.ParentStyleUsing.UseFont = false;
            this.xrLabel21.Size = new System.Drawing.Size(75, 25);
            xrSummary2.FormatString = "{0:n2}";
            xrSummary2.IgnoreNullValues = true;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel21.Summary = xrSummary2;
            this.xrLabel21.Text = "xrLabel21";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel22
            // 
            this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Ausgabe", "{0:n2}")});
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel22.Location = new System.Drawing.Point(692, 0);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.ParentStyleUsing.UseFont = false;
            this.xrLabel22.Size = new System.Drawing.Size(66, 25);
            xrSummary3.FormatString = "{0:n2}";
            xrSummary3.IgnoreNullValues = true;
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel22.Summary = xrSummary3;
            this.xrLabel22.Text = "xrLabel22";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel23
            // 
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel23.Location = new System.Drawing.Point(0, 0);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.ParentStyleUsing.UseFont = false;
            this.xrLabel23.Size = new System.Drawing.Size(80, 25);
            this.xrLabel23.Text = "Summe";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
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
                        this.GroupFooter1});
            this.DataSource = this.sqlQuery1;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(100, 80, 100, 100);
            this.Name = "Report";
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.ScriptReferencesString = "KiSS4.DB.dll";
            this.Scripts.OnBeforePrint = resources.GetString("Report.Scripts.OnBeforePrint");
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' , ParameterXML =  N'<?xml version="1.0" standalone="yes" ?>
<NewDataSet>
	<Table>	
		<FieldName>-</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Fallträger</DisplayText>
		<TabPosition>1</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<DefaultValue></DefaultValue>
	</Table>
	<Table>	
		<FieldName>-</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Person</DisplayText>
		<TabPosition>1</TabPosition>
		<X>10</X>
		<Y>90</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<DefaultValue></DefaultValue>
	</Table>
	<Table>	
		<FieldName>-</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Zeitraum</DisplayText>
		<TabPosition>1</TabPosition>
		<X>10</X>
		<Y>120</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
	<Table>	
		<FieldName>-</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Kostenart</DisplayText>
		<TabPosition>1</TabPosition>
		<X>10</X>
		<Y>150</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
	<Table>	
		<FieldName>-</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Datum von</DisplayText>
		<TabPosition>1</TabPosition>
		<X>10</X>
		<Y>180</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
	<Table>	
		<FieldName>-</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Datum bis</DisplayText>
		<TabPosition>1</TabPosition>
		<X>10</X>
		<Y>210</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
	<Table>	
		<FieldName>-</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Verdichtet</DisplayText>
		<TabPosition>1</TabPosition>
		<X>10</X>
		<Y>240</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
	<Table>	
		<FieldName>-</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>BetraegeAnpassen</DisplayText>
		<TabPosition>1</TabPosition>
		<X>10</X>
		<Y>270</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
	<Table>	
		<FieldName>-</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>FaLeistungIDsList</DisplayText>
		<TabPosition>1</TabPosition>
		<X>10</X>
		<Y>300</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<DefaultValue></DefaultValue>
	</Table>

	<Table>	
		<FieldName>BaPersonID</FieldName>
		<FieldCode>2</FieldCode>
		<DisplayText>Fallträger</DisplayText>
		<TabPosition>1</TabPosition>
		<X>220</X>
		<Y>60</Y>
		<Width>150</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
	<Table>	
		<FieldName>Person</FieldName>
		<FieldCode>2</FieldCode>
		<DisplayText>Person</DisplayText>
		<TabPosition>1</TabPosition>
		<X>220</X>
		<Y>90</Y>
		<Width>150</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
	<Table>	
		<FieldName>Zeitraum</FieldName>
		<FieldCode>8</FieldCode>
		<DisplayText>Zeitraum</DisplayText>
		<TabPosition>1</TabPosition>
		<LOVName>KbKontoZeitraum</LOVName>
		<X>220</X>
		<Y>120</Y>
		<Width>150</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
	<Table>	
		<FieldName>LAList</FieldName>
		<FieldCode>2</FieldCode>
		<DisplayText>LAList</DisplayText>
		<TabPosition>1</TabPosition>
		<X>220</X>
		<Y>150</Y>
		<Width>150</Width>
		<Height>25</Height>
		<Length>70</Length>
	</Table>
	<Table>	
		<FieldName>DatumVon</FieldName>
		<FieldCode>5</FieldCode>
		<DisplayText>Datum von</DisplayText>
		<TabPosition>1</TabPosition>
		<X>220</X>
		<Y>180</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
	<Table>	
		<FieldName>DatumBis</FieldName>
		<FieldCode>5</FieldCode>
		<DisplayText>Datum bis</DisplayText>
		<TabPosition>1</TabPosition>
		<X>220</X>
		<Y>210</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
	<Table>	
		<FieldName>Verdichtet</FieldName>
		<FieldCode>7</FieldCode>
		<TabPosition>1</TabPosition>
		<X>220</X>
		<Y>240</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
	<Table>	
		<FieldName>BetraegeAnpassen</FieldName>
		<FieldCode>7</FieldCode>
		<TabPosition>1</TabPosition>
		<X>220</X>
		<Y>270</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
	<Table>	
		<FieldName>FaLeistungIDsList</FieldName>
		<FieldCode>2</FieldCode>
		<DisplayText>FaLeistungIDsList</DisplayText>
		<TabPosition>1</TabPosition>
		<X>220</X>
		<Y>300</Y>
		<Width>150</Width>
		<Height>25</Height>
		<Length>7</Length>
	</Table>
</NewDataSet>' , SQLquery =  N'/*
Saldo wird über OnBeforePrint Event berechnet!
*/

DECLARE @BaPersonID INT;          --- Fallträger
DECLARE @Person VARCHAR(500);     --- Auswahl Maske (UE-Personen)
DECLARE @Zeitraum INT;            --- Auswahl Maske
DECLARE @LaList VARCHAR(500);     --- Auswahl Maske
DECLARE @DatumVon DATETIME;       --- Auswahl Maske
DECLARE @DatumBis DATETIME;       --- Auswahl Maske
DECLARE @Verdichtet BIT;          --- Auswahl Maske
DECLARE @BetraegeAnpassen BIT;    --- Auswahl Maske
DECLARE @FaLeistungIDsList VARCHAR(200);

SELECT @BaPersonID       = {BaPersonID},
       @Person           = {Person},
       @Zeitraum         = {Zeitraum},
       @LaList           = {LaList},
       @DatumVon         = {DatumVon},
       @DatumBis         = {DatumBis},
       @Verdichtet       = {Verdichtet},
       @BetraegeAnpassen = {BetraegeAnpassen},
       @FaLeistungIDsList = {FaLeistungIDsList};

IF (OBJECT_ID(''TempDB.dbo.#TmpKontoAuszug'') IS NOT NULL)
BEGIN 
  DROP TABLE #TmpKontoAuszug;
END;

CREATE TABLE #TmpKontoAuszug
(
  OrgName VARCHAR(1000), 
  OrgAdresse VARCHAR(1000), 
  OrgPLZOrt VARCHAR(1000),
  NeueSeite BIT,
  DruckDatum VARCHAR(200),
  Auswertungszeitraum VARCHAR(200),
  KbBuchungID INT,
  BelegDatum DATETIME,
  ValutaDatum DATETIME,
  BaPersonID INT,
  Klient VARCHAR(200),
  BelegNr VARCHAR(20),
  LA VARCHAR(10),
  LAText VARCHAR(150),
  Buchungstext VARCHAR(200),
  VerwPeriodeVon DATETIME,
  VerwPeriodeBis DATETIME,
  BgSplittingArtCode INT,
  Betrag MONEY,
  BetragSaldo MONEY,
  Betrag100 MONEY,
  EA VARCHAR(1), -- E = Einnahme, A = Ausgabe
  KbBuchungStatusCode INT,
  Doc VARCHAR(1),
  Auszahlart VARCHAR(100),
  KreditorDebitor VARCHAR(2000),
  Einnahme MONEY,
  Ausgabe MONEY,
  Saldo MONEY
);

INSERT INTO #TmpKontoAuszug
  EXEC dbo.spWhKontoauszug @BaPersonID, @Person, @Zeitraum, @DatumVon, @DatumBis, @LaList, @Verdichtet, @BetraegeAnpassen, @FaLeistungIDsList;

SELECT
  KbBuchungID,
  BelegDatum,
  ValutaDatum,
  BelegNr,
  LA,
  LAText,
  Buchungstext,
  VerwPeriodeVon,
  VerwPeriodeBis,
  BgSplittingArtCode,
  EA,
  KbBuchungStatusCode,
  Doc,
  Auszahlart,
  KreditorDebitor,
  TMP.BaPersonID,
  Klient,
  Betrag,
  Betrag100,
  Einnahme,
  Ausgabe,
  Saldo,
  FT = PRS.NameVorname,
  AHVNummer = PRS.AHVNummer
FROM #TmpKontoAuszug      TMP
  INNER JOIN dbo.vwPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = @BaPersonID -- Fallträger
ORDER BY BelegDatum ASC;

IF (OBJECT_ID(''TempDB.dbo.#TmpKontoAuszug'') IS NOT NULL)
BEGIN 
  DROP TABLE #TmpKontoAuszug;
END;' , ContextForms =  N'CtlWhKontoauszug' , ParentReportName =  null , ReportSortKey =  null 
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'ShKontoauszug' ;


