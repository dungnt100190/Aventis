-- Insert Script for BaSiLeiEinAuszahlungen
-- MD5:0XF5659AE1E39CE6A4A3A2B323F3DD4740_0X3755093093CC8CBA2FB51780548A4C64_0X47661CFFAACAD9374FC252D6ED895D8E
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'BaSiLeiEinAuszahlungen') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('BaSiLeiEinAuszahlungen', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'BaSiLeiEinAuszahlungen';
--SQLCHECK_IGNORE--
UPDATE QRY
SET QueryName =  N'BaSiLeiEinAuszahlungen' , UserText =  N'B - SiLei-EinAuszahlungen' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\KiSS-Branches\KiSS4420\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4420\Build\Debug\Kiss.Interfaces.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4420\Build\Debug\Microsoft.Practices.Unity.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4420\Build\Debug\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4420\Build\Debug\FluentValidation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4420\Build\Debug\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4420\Build\Debug\log4net.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\KiSS-Branches\KiSS4420\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell11;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell13;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell15;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell23;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell16;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell17;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell18;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell19;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell20;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell25;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRTable xrTable4;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell22;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell26;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell31;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabelAngezeigt;
        private DevExpress.XtraReports.UI.XRLabel xrLabelDetail2;
        private DevExpress.XtraReports.UI.XRLabel xrLabelDetail1;
        private DevExpress.XtraReports.UI.XRLabel xrlblSiLeiArt;
        private DevExpress.XtraReports.UI.XRLabel xrlblArt;
        private DevExpress.XtraReports.UI.XRLabel xrlblTitle;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRTable xrTable3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell21;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell24;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell28;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell30;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAADAAAAAQAAAGhTeXN0ZW0uRHJhd" +
                        "2luZy5CaXRtYXAsIFN5c3RlbS5EcmF3aW5nLCBWZXJzaW9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhb" +
                        "CwgUHVibGljS2V5VG9rZW49YjAzZjVmN2YxMWQ1MGEzYVBBRFBBRBO0TqROBiAauJECZwAAAAA3AAAAY" +
                        "gAAANsBAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAA" +
                        "AAAJngAcgBQAGkAYwB0AHUAcgBlAEIAbwB4ADEALgBJAG0AYQBnAGUA0jUAAEB4AHIAbABiAGwAVABpA" +
                        "HQAbABlAC4AUwBjAHIAaQBwAHQAcwAuAE8AbgBCAGUAZgBvAHIAZQBQAHIAaQBuAHQASUoAAAHPay0tI" +
                        "EFsbGUgVmFyaWFibGVuIMO8YmVybmVobWVuDQpERUNMQVJFIEBTZWxla3RpZXJ0ZUxlaXN0dW5nc2Fyd" +
                        "GVuIFRBQkxFDQooDQogIEJnS29zdGVuYXJ0SUQgSU5ULA0KICBLb250b05yIFZBUkNIQVIoMjUwKSwNC" +
                        "iAgQW5kcnVjayBWQVJDSEFSKDI1MCkNCikNCklOU0VSVCBJTlRPIEBTZWxla3RpZXJ0ZUxlaXN0dW5nc" +
                        "2FydGVuIChCZ0tvc3RlbmFydElELCBLb250b05yLCBBbmRydWNrKSANCiAgU0VMRUNUIA0KICAgIEJnS" +
                        "29zdGVuYXJ0SUQgPSBTcGxpdFZhbHVlLA0KICAgIEtvbnRvTnIgICAgICAgPSBCS0EuS29udG9OciwNC" +
                        "iAgICBBbmRydWNrICAgICAgID0gQ0FTRSANCiAgICAgICAgICAgICAgICAgICAgICBXSEVOIEJLQS5Lb" +
                        "250b05yPSczMjEnIE9SICBCS0EuS29udG9Ocj0nMzIwJyAgVEhFTiAnQXVzemFobHVuZ2VuJw0KCQkJC" +
                        "QkgICAgICAgICAgICBXSEVOIEJLQS5Lb250b05yPSc4NjAnIE9SICBCS0EuS29udG9Ocj0nODYxJyAgV" +
                        "EhFTiAnUsO8Y2t6YWhsdW5nZW4nDQoJCQkJCSAgICAgICAgICAgIFdIRU4gQktBLktvbnRvTnI9Jzg2M" +
                        "icgICBUSEVOICdSw7xja3phaGx1bmdlbiBhLm8uIChvaG5lIFZlcmVpbmJhcnVuZyknDQoJCQkJCSAgI" +
                        "CAgICAgICAgIFdIRU4gQktBLktvbnRvTnI9JzAzMScgICBUSEVOICdBdXN3ZXJ0dW5nIEJhbmtzcGVzZ" +
                        "W4nDQoJCQkJCSAgICAgICAgICAgIFdIRU4gQktBLktvbnRvTnI9JzAzMicgICBUSEVOICdBdXN3ZXJ0d" +
                        "W5nIFNvbGlkYXJpdMOkdHNiZWl0cmFnJw0KCQkJCQkgICAgICAgICAgICBXSEVOIEJLQS5Lb250b05yP" +
                        "ScwMzMnICAgVEhFTiAnQXVzd2VydHVuZyBWU1QgbmljaHQgZWluZm9yZGVyYmFyJw0KCQkJCQkgICAgI" +
                        "CAgICAgICBXSEVOIEJLQS5Lb250b05yPScwMzQnICAgVEhFTiAnQXVzd2VydHVuZyBWU1QgZWluZm9yZ" +
                        "GVyYmFyJw0KCQkJCQkgICAgICAgICAgICBXSEVOIEJLQS5Lb250b05yPScwNDEnICAgVEhFTiAnQXVzd" +
                        "2VydHVuZyBaaW5zdmVyYnVjaHVuZycNCgkJCQkgICAgICAgICAgICBFTkQgDQogIEZST00gZGJvLmZuU" +
                        "3BsaXRTdHJpbmdUb1ZhbHVlcyhudWxsLCAnLCcsIDEpIFNMDQogIAlJTk5FUiBKT0lOIGRiby5CZ0tvc" +
                        "3RlbmFydCAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQktBIFdJVEggKFJFQURVTkNPTU1JVFRFR" +
                        "CkgT04gU0wuU3BsaXRWYWx1ZT1CS0EuQmdLb3N0ZW5hcnRJRA0KDQotLUJlcmVjaG51bmcgVGV4dGUgZ" +
                        "sO8ciBFYmVuZTIgaW4gZGVyIERldGFpbHNlbGVrdGlvbg0KREVDTEFSRSBAVGV4dEViZW5lMiBWQVJDS" +
                        "EFSKDgwMDApOyANClNFTEVDVCAgQFRleHRFYmVuZTIgPSBkYm8uQ29uY0Rpc3RpbmN0T3JkZXIoJyAnI" +
                        "CsgQW5kcnVjaykNCkZST00gQFNlbGVrdGllcnRlTGVpc3R1bmdzYXJ0ZW4NCklGIExFTiggQFRleHRFY" +
                        "mVuZTIgKSA+MA0KICBTRUxFQ1QgIEBUZXh0RWJlbmUyID0gIFNVQlNUUklORyhAVGV4dEViZW5lMiwgM" +
                        "iwgTEVOKEBUZXh0RWJlbmUyKS0xKQ0KDQoNCg0KREVDTEFSRSBARGF0dW1Wb24gZGF0ZXRpbWUNClNFV" +
                        "CBARGF0dW1Wb24gPSBJc051bGwobnVsbCwnMTkwMC0wMS0wMScpDQoNCkRFQ0xBUkUgQERhdHVtQmlzI" +
                        "GRhdGV0aW1lDQotLVNFVCBARGF0dW1CaXMgPSBEQVRFQUREKG1zLC0zLERBVEVBREQoZCwxLG51bGwpK" +
                        "Q0KU0VUIEBEYXR1bUJpcz1udWxsDQpJRiBudWxsIElTIE5VTEwgDQogIFNFVCBARGF0dW1CaXM9R0VUR" +
                        "EFURSgpDQoNCkRFQ0xBUkUgQFN1Y2hlQXJ0IGludA0KU0VUIEBTdWNoZUFydCA9IG51bGwNCg0KREVDT" +
                        "EFSRSBAU3VjaGVCYVBlcnNvbklEIGludA0KU0VUIEBTdWNoZUJhUGVyc29uSUQgPSBudWxsDQoNCkRFQ" +
                        "0xBUkUgQFN1Y2hlS2xpZW50IHZhcmNoYXIoNTApDQpTRVQgQFN1Y2hlS2xpZW50ID0gbnVsbA0KSUYgb" +
                        "nVsbCBpcyBub3QgbnVsbCBhbmQgbnVsbCA8PiBOJycgU0VUIEBTdWNoZUtsaWVudCA9ICclJyArIHJlc" +
                        "GxhY2UobnVsbCwgJyAnLCAnJScpICsgJyUnDQoNCkRFQ0xBUkUgQFN1Y2hlQXVzemFobHVuZ1ZvbiBkY" +
                        "XRldGltZQ0KU0VUIEBTdWNoZUF1c3phaGx1bmdWb24gPSBudWxsDQpJRiBudWxsIGlzIG5vdCBudWxsI" +
                        "FNFVCBAU3VjaGVBdXN6YWhsdW5nVm9uID0gbnVsbA0KDQpERUNMQVJFIEBTdWNoZUF1c3phaGx1bmdCa" +
                        "XMgZGF0ZXRpbWUNClNFVCBAU3VjaGVBdXN6YWhsdW5nQmlzID0gbnVsbA0KSUYgbnVsbCBpcyBub3Qgb" +
                        "nVsbCBTRVQgQFN1Y2hlQXVzemFobHVuZ0JpcyA9IG51bGwNCg0KREVDTEFSRSBAU3VjaGVNaWdyaWVyd" +
                        "CBpbnQgDQpTRVQgQFN1Y2hlTWlncmllcnQgPSBudWxsDQoNCkRFQ0xBUkUgQFN1Y2hlTGF1ZmVuZCBpb" +
                        "nQgDQpTRVQgQFN1Y2hlTGF1ZmVuZCA9IG51bGwNCg0KREVDTEFSRSBAU3VjaGVOZXUgaW50IA0KU0VUI" +
                        "EBTdWNoZU5ldSA9IG51bGwNCg0KREVDTEFSRSBAU3VjaGVJbnN0aXR1dGlvbiB2YXJjaGFyKDUwKQ0KU" +
                        "0VUIEBTdWNoZUluc3RpdHV0aW9uID0gbnVsbA0KSUYgbnVsbCBpcyBub3QgbnVsbCBhbmQgbnVsbCA8P" +
                        "iBOJycgU0VUIEBTdWNoZUluc3RpdHV0aW9uID0gJyUnICsgcmVwbGFjZShudWxsLCAnICcsICclJykgK" +
                        "yAnJScNCg0KREVDTEFSRSBAU3VjaGVLb250b05yIHZhcmNoYXIoNTApDQpTRVQgQFN1Y2hlS29udG9Oc" +
                        "iA9IG51bGwNCklGIG51bGwgaXMgbm90IG51bGwgYW5kIG51bGwgPD4gTicnIFNFVCBAU3VjaGVLb250b" +
                        "05yID0gJyUnICsgcmVwbGFjZShudWxsLCAnICcsICclJykgKyAnJScNCg0KREVDTEFSRSBAU3VjaGVTd" +
                        "HJhc3NlIHZhcmNoYXIoNTApDQpTRVQgQFN1Y2hlU3RyYXNzZSA9IG51bGwNCklGIG51bGwgaXMgbm90I" +
                        "G51bGwgYW5kIG51bGwgPD4gTicnIFNFVCBAU3VjaGVTdHJhc3NlID0gJyUnICsgcmVwbGFjZShudWxsL" +
                        "CAnICcsICclJykgKyAnJScNCg0KREVDTEFSRSBAU3VjaGVIYXVzTnIgdmFyY2hhcig1MCkNClNFVCBAU" +
                        "3VjaGVIYXVzTnIgPSBudWxsDQpJRiBudWxsIGlzIG5vdCBudWxsIGFuZCBudWxsIDw+IE4nJyBTRVQgQ" +
                        "FN1Y2hlSGF1c05yICA9ICclJyArIHJlcGxhY2UobnVsbCwgJyAnLCAnJScpICsgJyUnDQoNCkRFQ0xBU" +
                        "kUgQFN1Y2hlUExaIHZhcmNoYXIoNTApDQpTRVQgQFN1Y2hlUExaID0gbnVsbA0KSUYgbnVsbCBpcyBub" +
                        "3QgbnVsbCBhbmQgbnVsbCA8PiBOJycgU0VUIEBTdWNoZVBMWiA9ICclJyArIHJlcGxhY2UobnVsbCwgJ" +
                        "yAnLCAnJScpICsgJyUnDQoNCkRFQ0xBUkUgQFN1Y2hlT3J0IHZhcmNoYXIoNTApDQpTRVQgQFN1Y2hlT" +
                        "3J0ID0gbnVsbA0KSUYgbnVsbCBpcyBub3QgbnVsbCBhbmQgbnVsbCA8PiBOJycgU0VUIEBTdWNoZU9yd" +
                        "CA9ICclJyArIHJlcGxhY2UobnVsbCwgJyAnLCAnJScpICsgJyUnDQoNCkRFQ0xBUkUgQFN1Y2hlRmFGY" +
                        "WxsSUQgaW50IA0KU0VUIEBTdWNoZUZhRmFsbElEID0gbnVsbA0KDQpERUNMQVJFIEBTdWNoZUFsdGVQT" +
                        "nIgdmFyY2hhcig1MCkNClNFVCBAU3VjaGVBbHRlUE5yICA9IG51bGwNCklGIG51bGwgaXMgbm90IG51b" +
                        "GwgYW5kIG51bGwgPD4gTicnIFNFVCBAU3VjaGVBbHRlUE5yICA9ICclJyArIHJlcGxhY2UobnVsbCwgJ" +
                        "yAnLCAnJScpICsgJyUnDQoNCi0tIFp3aXNjaGVudGFiZWxsZW4NCkRFQ0xBUkUgQElEcyBUQUJMRQ0KK" +
                        "A0KICBCYVNpY2hlcmhlaXRzbGVpc3R1bmdJRCBpbnQNCikNCg0KSU5TRVJUIElOVE8gQElEcw0KU0VMR" +
                        "UNUIFNJQy5CYVNpY2hlcmhlaXRzbGVpc3R1bmdJRA0KRlJPTSBkYm8uQmFTaWNoZXJoZWl0c2xlaXN0d" +
                        "W5nIFNJQyBXSVRIKFJFQURVTkNPTU1JVFRFRCkNCiAgTEVGVCBKT0lOIGRiby5GYUxlaXN0dW5nICAgI" +
                        "CBMRUkgV0lUSChSRUFEVU5DT01NSVRURUQpIE9OIExFSS5CYVBlcnNvbklEID0gU0lDLkJhUGVyc29uS" +
                        "UQgDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgIEFORCBMRUkuRmFQcm96ZXNzQ29kZSA9IDMwMCANCiAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EI" +
                        "ExFSS5GYUxlaXN0dW5nSUQgPSAoU0VMRUNUIFRPUCAxIEZhTGVpc3R1bmdJRA0KICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICBGUk9NICBGYUxlaXN0dW5nDQogICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgIFdIRVJFIEJhUGVyc29uSUQgPSBTSUMuQmFQZXJzb25JRCANCiAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgRmFQcm96ZXNzQ29kZSA9IDMwMA0KICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICBPUkRFUiBCWSBEYXR1bVZvbiBERVNDKQ0KICBMRUZUI" +
                        "EpPSU4gZGJvLnZ3UGVyc29uICAgICAgIFBSUyBXSVRIKFJFQURVTkNPTU1JVFRFRCkgT04gUFJTLkJhU" +
                        "GVyc29uSUQgPSBTSUMuQmFQZXJzb25JRA0KICBMRUZUIEpPSU4gZGJvLnZ3SW5zdGl0dXRpb24gIElOU" +
                        "yBXSVRIKFJFQURVTkNPTU1JVFRFRCkgT04gSU5TLkJhSW5zdGl0dXRpb25JRCA9IFNJQy5CYUluc3Rpd" +
                        "HV0aW9uSUQNCiAgTEVGVCBKT0lOIGRiby5CYUJhbmsgICAgICAgICBCTksgV0lUSChSRUFEVU5DT01NS" +
                        "VRURUQpIE9OIEJOSy5CYUJhbmtJRCA9IFNJQy5CYUJhbmtJRA0KV0hFUkUgMSA9IDEgDQogIEFORCAoQ" +
                        "FN1Y2hlQXJ0IGlzIG51bGwgICAgICAgICAgIE9SIFNJQy5CYU1pZXRlU2ljaGVyaGVpdHNsZWlzdHVuZ" +
                        "0FydENvZGUgPSBAU3VjaGVBcnQpDQogIEFORCAoQFN1Y2hlQmFQZXJzb25JRCBpcyBudWxsICAgIE9SI" +
                        "FNJQy5CYVBlcnNvbklEID0gQFN1Y2hlQmFQZXJzb25JRCkNCiAgQU5EIChAU3VjaGVLbGllbnQgaXMgb" +
                        "nVsbCAgICAgICAgT1IgUFJTLk5hbWVWb3JuYW1lIExJS0UgQFN1Y2hlS2xpZW50KQ0KICBBTkQgKEBTd" +
                        "WNoZUF1c3phaGx1bmdWb24gaXMgbnVsbCBPUiBTSUMuQXVzemFobHVuZ0FtID49IEBTdWNoZUF1c3pha" +
                        "Gx1bmdWb24pDQogIEFORCAoQFN1Y2hlQXVzemFobHVuZ0JpcyBpcyBudWxsIE9SIFNJQy5BdXN6YWhsd" +
                        "W5nQW0gPD0gQFN1Y2hlQXVzemFobHVuZ0JpcykNCiAgQU5EICgoQFN1Y2hlTWlncmllcnQgPSAxIGFuZ" +
                        "CBTSUMuTWlnRGFybGVoZW5JRCBpcyBub3QgbnVsbCkgT1INCiAgICAgICAoQFN1Y2hlTGF1ZmVuZCA9I" +
                        "DEgIGFuZCBTSUMuTWlnRGFybGVoZW5JRCBpcyBudWxsIGFuZCBTSUMubmV1ID0gMCkgT1INCiAgICAgI" +
                        "CAoQFN1Y2hlTmV1ID0gMSAgICAgIGFuZCBTSUMubmV1ID0gMSkpDQogIEFORCAoQFN1Y2hlSW5zdGl0d" +
                        "XRpb24gaXMgbnVsbCAgIE9SIElOUy5JbnN0aXR1dGlvbk5hbWUgbGlrZSBAU3VjaGVJbnN0aXR1dGlvb" +
                        "ikNCiAgQU5EIChAU3VjaGVLb250b05yIGlzIG51bGwgICAgICAgT1IgU0lDLktvbnRvTnVtbWVyIGxpa" +
                        "2UgQFN1Y2hlS29udG9OcikNCiAgQU5EIChAU3VjaGVTdHJhc3NlIGlzIG51bGwgICAgICAgT1IgU0lDL" +
                        "k9iamVrdFN0cmFzc2UgbGlrZSBAU3VjaGVTdHJhc3NlKQ0KICBBTkQgKEBTdWNoZUhhdXNOciBpcyBud" +
                        "WxsICAgICAgICBPUiBTSUMuT2JqZWt0SGF1c05yID0gQFN1Y2hlSGF1c05yKQ0KICBBTkQgKEBTdWNoZ" +
                        "VBMWiBpcyBudWxsICAgICAgICAgICBPUiBTSUMuT2JqZWt0UExaID0gQFN1Y2hlUExaKQ0KICBBTkQgK" +
                        "EBTdWNoZU9ydCBpcyBudWxsICAgICAgICAgICBPUiBTSUMuT2JqZWt0T3J0IGxpa2UgQFN1Y2hlT3J0K" +
                        "Q0KICBBTkQgKEBTdWNoZUFsdGVQTnIgaXMgbnVsbCAgICAgICBPUiBTSUMuQmFQZXJzb25JRCBpbiAoc" +
                        "2VsZWN0IGRpc3RpbmN0IEJhUGVyc29uSUQgZnJvbSBCYUFsdGVGYWxsTnIgd2hlcmUgUGVyc29uTnJBb" +
                        "HQgPSBAU3VjaGVBbHRlUE5yKSkNCiAgQU5EIChAU3VjaGVGYUZhbGxJRCBpcyBudWxsICAgICAgT1IgT" +
                        "EVJLkZhRmFsbElEID0gQFN1Y2hlRmFGYWxsSUQpDQoNCkRFQ0xBUkUgQHRtcEJ1Y2h1bmdlbiBUQUJMR" +
                        "Q0KKA0KICBCYVNpY2hlcmhlaXRzbGVpc3R1bmdJRCAgICAgICAgICAgaW50LA0KICBCdWNodW5nc0Rhd" +
                        "HVtICAgICAgICAgICAgICAgICAgICAgZGF0ZXRpbWUsDQogIEJlbGVnTnIgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICB2YXJjaGFyKDIwKSwNCiAgTEEgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "HZhcmNoYXIoMTApLA0KICBCdWNodW5nc3RleHQgICAgICAgICAgICAgICAgICAgICAgdmFyY2hhcigyM" +
                        "DApLA0KICBCZXRyYWcgICAgICAgICAgICAgICAgICAgICAgICAgICAgbW9uZXksDQogIFRvb2wgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICBjaGFyKDEpLA0KICBCZWxlZ05ybkJydXR0byAgICAgICAgI" +
                        "CAgICAgICAgICAgdmFyY2hhcigyMDApDQopDQoNCi0tIE1pZ3JpZXJ0ZSBCdWNodW5nZW4NCklOU0VSV" +
                        "CBJTlRPIEB0bXBCdWNodW5nZW4NClNFTEVDVCBTSUMuQmFTaWNoZXJoZWl0c2xlaXN0dW5nSUQsIE1JR" +
                        "y5CdWNodW5nc0RhdHVtLCBNSUcuTnVtbWVybmtyZWlzICsgJy0nICsgQ0FTVChNSUcuQmVsZWdOdW1tZ" +
                        "XIgYXMgdmFyY2hhcikgKyAnLScgKyBDQVNUKE1JRy5Qb3NpdGlvbnNOdW1tZXIgYXMgdmFyY2hhciksI" +
                        "EJLQS5Lb250b05yLCBCS0EuTmFtZSwgTUlHLkJldHJhZywgJ1AnLCBOVUxMDQpGUk9NIGRiby5CYVNpY" +
                        "2hlcmhlaXRzbGVpc3R1bmcgICAgICAgICAgICAgICAgIFNJQyBXSVRIIChSRUFEVU5DT01NSVRURUQpD" +
                        "QogIElOTkVSIEpPSU4gZGJvLkJhU2ljaGVyaGVpdHNsZWlzdHVuZ1Bvc2l0aW9uIFNJUCBXSVRIIChSR" +
                        "UFEVU5DT01NSVRURUQpIE9OIFNJQy5CYVNpY2hlcmhlaXRzbGVpc3R1bmdJRCA9IFNJUC5CYVNpY2hlc" +
                        "mhlaXRzbGVpc3R1bmdJRA0KICBJTk5FUiBKT0lOIGRiby5NaWdEZXRhaWxCdWNodW5nICAgICAgICAgI" +
                        "CAgICBNSUcgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKSBPTiBNSUcuTWlnRGV0YWlsQnVjaHVuZ0lEICAgI" +
                        "CAgPSBTSVAuTWlnRGV0YWlsQnVjaHVuZ0lEDQogIElOTkVSIEpPSU4gZGJvLkJnS29zdGVuYXJ0ICAgI" +
                        "CAgICAgICAgICAgICAgIEJLQSBXSVRIIChSRUFEVU5DT01NSVRURUQpIE9OIEJLQS5Lb250b05yICAgI" +
                        "CAgICAgICAgICAgICA9IE1JRy5LaXNzTGVpc3R1bmdzYXJ0DQogIElOTkVSIEpPSU4gQFNlbGVrdGllc" +
                        "nRlTGVpc3R1bmdzYXJ0ZW4gICAgICAgIFNFTCAgICAgICAgICAgICAgICAgICAgICAgIE9OIFNFTC5CZ" +
                        "0tvc3RlbmFydElEICAgICAgICAgICA9IEJLQS5CZ0tvc3RlbmFydElEDQpXSEVSRSBTSUMuR2Vsb2VzY" +
                        "2h0ID0gMCANCiAgQU5EIFNJUC5CYVNpY2hlcmhlaXRzbGVpc3R1bmdJRCBJTiAoU0VMRUNUIEJhU2lja" +
                        "GVyaGVpdHNsZWlzdHVuZ0lEIEZST00gQElEcykgDQoNCi0tTmV0dG9idWNodW5nZW4NCklOU0VSVCBJT" +
                        "lRPIEB0bXBCdWNodW5nZW4NClNFTEVDVCBTSUMuQmFTaWNoZXJoZWl0c2xlaXN0dW5nSUQsIEtCVS5WY" +
                        "Wx1dGFEYXR1bSwgS0JVLkJlbGVnTnIsIEJLQS5Lb250b05yLCBLQksuQnVjaHVuZ3N0ZXh0LCBLQksuQ" +
                        "mV0cmFnLCAnSycsIEJSVS5CZWxlZ05ybg0KRlJPTSBkYm8uQmFTaWNoZXJoZWl0c2xlaXN0dW5nICAgI" +
                        "CAgICAgICAgICAgICBTSUMgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKQ0KICBJTk5FUiBKT0lOIGRiby5CY" +
                        "VNpY2hlcmhlaXRzbGVpc3R1bmdQb3NpdGlvbiBTSVAgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKSBPTiBTS" +
                        "UMuQmFTaWNoZXJoZWl0c2xlaXN0dW5nSUQgPSBTSVAuQmFTaWNoZXJoZWl0c2xlaXN0dW5nSUQNCiAgS" +
                        "U5ORVIgSk9JTiBkYm8uS2JCdWNodW5nICAgICAgICAgICAgICAgICAgICAgS0JVIFdJVEggKFJFQURVT" +
                        "kNPTU1JVFRFRCkgT04gS0JVLktiQnVjaHVuZ0lEICAgICAgICAgICAgID0gU0lQLktiQnVjaHVuZ0lED" +
                        "QogIElOTkVSIEpPSU4gZGJvLktiQnVjaHVuZ0tvc3RlbmFydCAgICAgICAgICAgIEtCSyBXSVRIIChSR" +
                        "UFEVU5DT01NSVRURUQpIE9OIEtCSy5LYkJ1Y2h1bmdJRCAgICAgICAgICAgICA9IEtCVS5LYkJ1Y2h1b" +
                        "mdJRA0KICBJTk5FUiBKT0lOIGRiby5CZ0tvc3RlbmFydCAgICAgICAgICAgICAgICAgICBCS0EgV0lUS" +
                        "CAoUkVBRFVOQ09NTUlUVEVEKSBPTiBCS0EuQmdLb3N0ZW5hcnRJRCAgICAgICAgICAgPSBLQksuQmdLb" +
                        "3N0ZW5hcnRJRA0KICBJTk5FUiBKT0lOIEBTZWxla3RpZXJ0ZUxlaXN0dW5nc2FydGVuICAgICAgICBTR" +
                        "UwgICAgICAgICAgICAgICAgICAgICAgICBPTiBTRUwuQmdLb3N0ZW5hcnRJRCAgICAgICAgICAgPSBCS" +
                        "0EuQmdLb3N0ZW5hcnRJRA0KICBJTk5FUiBKT0lOIChTRUxFQ1QgS0JQLkJnUG9zaXRpb25JRCwgQmVsZ" +
                        "WdOcm4gPSBkYm8uQ29uY0Rpc3RpbmN0KEtCQi5CZWxlZ05yKQ0KICAgICAgICAgICAgICBGUk9NIGRib" +
                        "y5LYkJ1Y2h1bmdCcnV0dG9QZXJzb24gICBLQlAgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKQ0KICAgICAgI" +
                        "CAgICAgICAgIElOTkVSIEpPSU4gZGJvLktiQnVjaHVuZ0JydXR0byBLQkIgV0lUSCAoUkVBRFVOQ09NT" +
                        "UlUVEVEKSBPTiBLQkIuS2JCdWNodW5nQnJ1dHRvSUQgPSBLQlAuS2JCdWNodW5nQnJ1dHRvSUQgQU5EI" +
                        "EtCQi5TdG9ybmllcnRLYkJ1Y2h1bmdicnV0dG9JRCBJUyBOVUxMDQogICAgICAgICAgICAgICAgSU5OR" +
                        "VIgSk9JTiBkYm8uQmdLb3N0ZW5hcnQgICAgIEJLQSBXSVRIIChSRUFEVU5DT01NSVRURUQpIE9OIEJLQ" +
                        "S5CZ0tvc3RlbmFydElEICAgICA9IEtCQi5CZ0tvc3RlbmFydElEDQogICAgICAgICAgICAgIEdST1VQI" +
                        "EJZIEtCUC5CZ1Bvc2l0aW9uSUQpIEJSVSBPTiBCUlUuQmdQb3NpdGlvbklEID0gS0JLLkJnUG9zaXRpb" +
                        "25JRA0KV0hFUkUgU0lDLkdlbG9lc2NodCA9IDAgDQogIEFORCBLQlUuS2JCdWNodW5nU3RhdHVzQ29kZ" +
                        "SBOT1QgSU4gKDkpIC0tUsO8Y2tsw6R1ZmVyIGF1c3NjaGxpZXNzZW4NCiAgQU5EIFNJUC5CYVNpY2hlc" +
                        "mhlaXRzbGVpc3R1bmdJRCBJTiAoU0VMRUNUIEJhU2ljaGVyaGVpdHNsZWlzdHVuZ0lEIEZST00gQElEc" +
                        "ykNCg0KLS1CcnV0dG9idWNodW5nZW4gaW5rbC4gTmV1YnVjaHVuZ2VuDQpJTlNFUlQgSU5UTyBAdG1wQ" +
                        "nVjaHVuZ2VuDQpTRUxFQ1QgQlNQLkJhU2ljaGVyaGVpdHNsZWlzdHVuZ0lELCBLQkIuVmFsdXRhRGF0d" +
                        "W0sIE5VTEwsIEJLQS5Lb250b05yLCBLQlAuQnVjaHVuZ3N0ZXh0LCAtS0JQLkJldHJhZywgJ0snLCBLQ" +
                        "kIuQmVsZWdOcg0KRlJPTSBkYm8uQmFTaWNoZXJoZWl0c2xlaXN0dW5nUG9zaXRpb24gIEJTUCBXSVRII" +
                        "ChSRUFEVU5DT01NSVRURUQpDQogIElOTkVSIEpPSU4gZGJvLkJhU2ljaGVyaGVpdHNsZWlzdHVuZyAgU" +
                        "0lDIFdJVEggKFJFQURVTkNPTU1JVFRFRCkgT04gU0lDLkJhU2ljaGVyaGVpdHNsZWlzdHVuZ0lEID0gQ" +
                        "lNQLkJhU2ljaGVyaGVpdHNsZWlzdHVuZ0lEDQogIElOTkVSIEpPSU4gZGJvLktiQnVjaHVuZ0JydXR0b" +
                        "yAgICAgICAgS0JCIFdJVEggKFJFQURVTkNPTU1JVFRFRCkgT04gS0JCLktiQnVjaHVuZ0JydXR0b0lEI" +
                        "CAgICAgID0gQlNQLktiQnVjaHVuZ0JydXR0b0lEIEFORCAvKktCQi5CZXRyYWcgPj0gMCBBTkQqLyBCU" +
                        "1AuS2JCdWNodW5nSUQgSVMgTlVMTA0KICBJTk5FUiBKT0lOIGRiby5LYkJ1Y2h1bmdCcnV0dG9QZXJzb" +
                        "24gIEtCUCBXSVRIIChSRUFEVU5DT01NSVRURUQpIE9OIEtCUC5LYkJ1Y2h1bmdCcnV0dG9JRCAgICAgI" +
                        "CA9IEtCQi5LYkJ1Y2h1bmdCcnV0dG9JRA0KICBJTk5FUiBKT0lOIGRiby5CZ0tvc3RlbmFydCAgICAgI" +
                        "CAgICAgIEJLQSBXSVRIIChSRUFEVU5DT01NSVRURUQpIE9OIEJLQS5CZ0tvc3RlbmFydElEICAgICAgI" +
                        "CAgICA9IElzTnVsbChLQlAuU3BlekJnS29zdGVuYXJ0SUQsS0JCLkJnS29zdGVuYXJ0SUQpDQogIElOT" +
                        "kVSIEpPSU4gQFNlbGVrdGllcnRlTGVpc3R1bmdzYXJ0ZW4gU0VMICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgT04gU0VMLkJnS29zdGVuYXJ0SUQgICAgICAgICAgID0gQktBLkJnS29zdGVuYXJ0SUQNCldIRVJFI" +
                        "FNJQy5HZWxvZXNjaHQgPSAwIA0KICBBTkQgQlNQLkJhU2ljaGVyaGVpdHNsZWlzdHVuZ0lEIElOIChTR" +
                        "UxFQ1QgQmFTaWNoZXJoZWl0c2xlaXN0dW5nSUQgRlJPTSBASURzKSANCg0KLS1TdG9ybm9idWNodW5nZ" +
                        "W4NCklOU0VSVCBJTlRPIEB0bXBCdWNodW5nZW4NClNFTEVDVCBTSUMuQmFTaWNoZXJoZWl0c2xlaXN0d" +
                        "W5nSUQsIEtCQi5WYWx1dGFEYXR1bSwgTlVMTCwgQktBLktvbnRvTnIsIEtCUC5CdWNodW5nc3RleHQsI" +
                        "C1LQlAuQmV0cmFnLCAnSycsIEtCQi5CZWxlZ05yDQpGUk9NIGRiby5CYVNpY2hlcmhlaXRzbGVpc3R1b" +
                        "mcgICAgICAgICAgICAgICAgIFNJQyBXSVRIKFJFQURVTkNPTU1JVFRFRCkNCiAgSU5ORVIgSk9JTiBkY" +
                        "m8uQmFTaWNoZXJoZWl0c2xlaXN0dW5nUG9zaXRpb24gQlNQIFdJVEgoUkVBRFVOQ09NTUlUVEVEKSBPT" +
                        "iBTSUMuQmFTaWNoZXJoZWl0c2xlaXN0dW5nSUQgPSBCU1AuQmFTaWNoZXJoZWl0c2xlaXN0dW5nSUQNC" +
                        "iAgTEVGVCAgSk9JTiAoU0VMRUNUIERJU1RJTkNUIE9SUC5LYkJ1Y2h1bmdCcnV0dG9JRCwgS0JLLktiQ" +
                        "nVjaHVuZ0lEDQogICAgICAgICAgICAgIEZST00gS2JCdWNodW5nQnJ1dHRvUGVyc29uICAgICAgT1JQI" +
                        "FdJVEggKFJFQURVTkNPTU1JVFRFRCkNCiAgICAgICAgICAgICAgICBJTk5FUiBKT0lOIEtiQnVjaHVuZ" +
                        "0tvc3RlbmFydCBLQksgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKSBPTiBLQksuQmdQb3NpdGlvbklEID0gT" +
                        "1JQLkJnUG9zaXRpb25JRCkgS0JLIE9OIEJTUC5LYkJ1Y2h1bmdJRCA9IEtCSy5LYkJ1Y2h1bmdJRA0KI" +
                        "CBJTk5FUiBKT0lOIGRiby5LYkJ1Y2h1bmdCcnV0dG8gICAgICAgICAgICAgICBPUkIgV0lUSCAoUkVBR" +
                        "FVOQ09NTUlUVEVEKSBPTiBCU1AuS2JCdWNodW5nQnJ1dHRvSUQgPSBPUkIuS2JCdWNodW5nQnJ1dHRvS" +
                        "UQgT1IgS0JLLktiQnVjaHVuZ0JydXR0b0lEID0gT1JCLktiQnVjaHVuZ0JydXR0b0lEDQogIElOTkVSI" +
                        "EpPSU4gZGJvLktiQnVjaHVuZ0JydXR0byAgICAgICAgICAgICAgIEtCQiBXSVRIIChSRUFEVU5DT01NS" +
                        "VRURUQpIE9OIE9SQi5LYkJ1Y2h1bmdCcnV0dG9JRCA9IEtCQi5TdG9ybmllcnRLYkJ1Y2h1bmdCcnV0d" +
                        "G9JRA0KICBJTk5FUiBKT0lOIGRiby5LYkJ1Y2h1bmdCcnV0dG9QZXJzb24gICAgICAgICBLQlAgV0lUS" +
                        "CAoUkVBRFVOQ09NTUlUVEVEKSBPTiBLQlAuS2JCdWNodW5nQnJ1dHRvSUQgPSBLQkIuS2JCdWNodW5nQ" +
                        "nJ1dHRvSUQNCiAgSU5ORVIgSk9JTiBkYm8uQmdLb3N0ZW5hcnQgICAgICAgICAgICAgICAgICAgQktBI" +
                        "FdJVEggKFJFQURVTkNPTU1JVFRFRCkgT04gQktBLkJnS29zdGVuYXJ0SUQgICAgID0gSXNOdWxsKEtCQ" +
                        "i5CZ0tvc3RlbmFydElELEtCUC5TcGV6QmdLb3N0ZW5hcnRJRCkNCiAgSU5ORVIgSk9JTiBAU2VsZWt0a" +
                        "WVydGVMZWlzdHVuZ3NhcnRlbiBTRUwgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgT04gU0VML" +
                        "kJnS29zdGVuYXJ0SUQgICAgICAgICAgID0gQktBLkJnS29zdGVuYXJ0SUQNCldIRVJFIFNJQy5HZWxvZ" +
                        "XNjaHQgPSAwIA0KICBBTkQgU0lDLkJhU2ljaGVyaGVpdHNsZWlzdHVuZ0lEIElOIChTRUxFQ1QgQmFTa" +
                        "WNoZXJoZWl0c2xlaXN0dW5nSUQgRlJPTSBASURzKSANCiAgQU5EIEtCQi5TdG9ybmllcnRLYkJ1Y2h1b" +
                        "mdCcnV0dG9JRCBJUyBOT1QgTlVMTCAtLSBPUiBLQkIuTmV1YnVjaHVuZ1ZvbktiQnVjaHVuZ0JydXR0b" +
                        "0lEIElTIE5PVCBOVUxMKQ0KDQoNCi0tVW1idWNodW5nZW4gQWx0ZGF0ZW4NCklOU0VSVCBJTlRPIEB0b" +
                        "XBCdWNodW5nZW4NClNFTEVDVCBCU1AuQmFTaWNoZXJoZWl0c2xlaXN0dW5nSUQsIEtCQi5WYWx1dGFEY" +
                        "XR1bS8qTUlHLkJ1Y2h1bmdzRGF0dW0qLywgTlVMTCwgQktBLktvbnRvTnIsIEtCUC5CdWNodW5nc3Rle" +
                        "HQsIC1LQlAuQmV0cmFnLCAnSycsIEtCQi5CZWxlZ05yDQpGUk9NIEJhU2ljaGVyaGVpdHNsZWlzdHVuZ" +
                        "1Bvc2l0aW9uICAgICAgQlNQDQogIElOTkVSIEpPSU4gZGJvLkJhU2ljaGVyaGVpdHNsZWlzdHVuZyAgU" +
                        "0lDIFdJVEggKFJFQURVTkNPTU1JVFRFRCkgT04gU0lDLkJhU2ljaGVyaGVpdHNsZWlzdHVuZ0lEID0gQ" +
                        "lNQLkJhU2ljaGVyaGVpdHNsZWlzdHVuZ0lEDQogIElOTkVSIEpPSU4gZGJvLk1pZ0RldGFpbEJ1Y2h1b" +
                        "mcgICAgICAgTUlHIFdJVEggKFJFQURVTkNPTU1JVFRFRCkgT04gTUlHLk1pZ0RldGFpbEJ1Y2h1bmdJR" +
                        "CAgICAgID0gQlNQLk1pZ0RldGFpbEJ1Y2h1bmdJRA0KICBJTk5FUiBKT0lOIGRiby5LYkJ1Y2h1bmdCc" +
                        "nV0dG8gICAgICAgIEtCQiBXSVRIIChSRUFEVU5DT01NSVRURUQpIE9OIEJTUC5NaWdEZXRhaWxidWNod" +
                        "W5nSUQgICAgICA9IEtCQi5NaWdEZXRhaWxidWNodW5nSUQNCiAgSU5ORVIgSk9JTiBkYm8uS2JCdWNod" +
                        "W5nQnJ1dHRvUGVyc29uICBLQlAgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKSBPTiBLQlAuS2JCdWNodW5nQ" +
                        "nJ1dHRvSUQgICAgICAgPSBLQkIuS2JCdWNodW5nQnJ1dHRvSUQNCiAgSU5ORVIgSk9JTiBkYm8uQmdLb" +
                        "3N0ZW5hcnQgICAgICAgICAgICBCS0EgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKSBPTiBCS0EuQmdLb3N0Z" +
                        "W5hcnRJRCAgICAgICAgICAgPSBLQkIuQmdLb3N0ZW5hcnRJRA0KICBJTk5FUiBKT0lOIEBTZWxla3RpZ" +
                        "XJ0ZUxlaXN0dW5nc2FydGVuIFNFTCAgICAgICAgICAgICAgICAgICAgICAgIE9OIFNFTC5CZ0tvc3Rlb" +
                        "mFydElEICAgICAgICAgICA9IEJLQS5CZ0tvc3RlbmFydElEDQpXSEVSRSBTSUMuR2Vsb2VzY2h0ID0gM" +
                        "CANCiAgQU5EIEtCQi5CZWxlZ2FydCA9ICdVQicgLS0gTnVyIGRpZSBTdG9ybm9idWNodW5nLCBuaWNod" +
                        "CBkaWUgTmV1YnVjaHVuZw0KDQoNCi0tQXVmYmVyZWl0dW5nDQpTRUxFQ1QgU3RpY2h0YWcgID0gQ09OV" +
                        "kVSVChWQVJDSEFSLCBARGF0dW1Wb24sIDEwNCkgICsgJyBiaXMgJyArICBDT05WRVJUKFZBUkNIQVIsI" +
                        "EBEYXR1bUJpcywgMTA0KSwNCiAgICAgICBBcnQgICAgICAgID0gQFN1Y2hlQXJ0LA0KICAgICAgIEViZ" +
                        "W5lMlRleHQgPSBAVGV4dEViZW5lMiwNCiAgICAgICBTTEEuU2hvcnRUZXh0LCBTSUMuQmFQZXJzb25JR" +
                        "CwgUFJTLk5hbWVWb3JuYW1lLCBCVUMuQnVjaHVuZ3NEYXR1bSwgQlVDLkJlbGVnTnIsIEJVQy5MQSwgQ" +
                        "lVDLkJ1Y2h1bmdzdGV4dCwgQlVDLkJldHJhZywgQlVDLlRvb2wsIEJVQy5CZWxlZ05ybkJydXR0bywNC" +
                        "iAgICAgICBUeXAgPSBDQVNFIA0KICAgICAgICAgICAgICAgV0hFTiBTSUMuTWlnRGFybGVoZW5JRCBJU" +
                        "yBOT1QgTlVMTCBUSEVOICdhbHQnDQogICAgICAgICAgICAgICBXSEVOIG5ldSA9IDEgdGhlbiAnbmV1J" +
                        "w0KICAgICAgICAgICAgICAgRUxTRSAnbGF1Zi4nDQogICAgICAgICAgICAgRU5EDQpGUk9NIEB0bXBCd" +
                        "WNodW5nZW4gICAgICAgICAgICAgICAgICAgICBCVUMNCiAgSU5ORVIgSk9JTiBkYm8uQmFTaWNoZXJoZ" +
                        "Wl0c2xlaXN0dW5nIFNJQyBXSVRIKFJFQURVTkNPTU1JVFRFRCkgT04gU0lDLkJhU2ljaGVyaGVpdHNsZ" +
                        "WlzdHVuZ0lEID0gQlVDLkJhU2ljaGVyaGVpdHNsZWlzdHVuZ0lEDQogIElOTkVSIEpPSU4gZGJvLlhMT" +
                        "1ZDb2RlICAgICAgICAgICAgICBTTEEgV0lUSChSRUFEVU5DT01NSVRURUQpIE9OIFNMQS5MT1ZOYW1lI" +
                        "D0gJ0JhTWlldGVTaWNoZXJoZWl0c2xlaXN0dW5nQXJ0JyBBTkQgU0xBLkNvZGUgPSBTSUMuQmFNaWV0Z" +
                        "VNpY2hlcmhlaXRzbGVpc3R1bmdBcnRDb2RlDQogIElOTkVSIEpPSU4gZGJvLnZ3UGVyc29uICAgICAgI" +
                        "CAgICAgICBQUlMgV0lUSChSRUFEVU5DT01NSVRURUQpIE9OIFBSUy5CYVBlcnNvbklEID0gU0lDLkJhU" +
                        "GVyc29uSUQNCldIRVJFIEJVQy5CdWNodW5nc0RhdHVtIEJFVFdFRU4gQERhdHVtVm9uIEFORCBARGF0d" +
                        "W1CaXMNCk9SREVSIEJZIEJVQy5CdWNodW5nc0RhdHVtQAABAAAA/////wEAAAAAAAAADAIAAABRU3lzd" +
                        "GVtLkRyYXdpbmcsIFZlcnNpb249NC4wLjAuMCwgQ3VsdHVyZT1uZXV0cmFsLCBQdWJsaWNLZXlUb2tlb" +
                        "j1iMDNmNWY3ZjExZDUwYTNhBQEAAAAVU3lzdGVtLkRyYXdpbmcuQml0bWFwAQAAAAREYXRhBwICAAAAC" +
                        "QMAAAAPAwAAANQTAAAC/9j/4AAQSkZJRgABAAEAYABgAAD/4QB2RXhpZgAATU0AKgAAAAgAAYdpAAQAA" +
                        "AABAAAAGgAAAAAAAZKGAAcAAABAAAAALAAAAABVTklDT0RFAABMAEUAQQBEACAAVABlAGMAaABuAG8Ab" +
                        "ABvAGcAaQBlAHMAIABJAG4AYwAuACAAVgAxAC4AMAAxAAD//gAfTEVBRCBUZWNobm9sb2dpZXMgSW5jL" +
                        "iBWMS4wMQD/2wBDAAgGBgcGBQgHBwcKCQgKDRYODQwMDRsTFBAWIBwiIR8cHx4jKDMrIyYwJh4fLD0tM" +
                        "DU2OTo5Iis/Qz44QzM4OTf/2wBDAQkKCg0LDRoODho3JB8kNzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3N" +
                        "zc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzf/wAARCAAyANsDAREAAhEBAxEB/8QAHwAAAQUBAQEBAQEAA" +
                        "AAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBk" +
                        "aEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc" +
                        "3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2" +
                        "uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAA" +
                        "gECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYG" +
                        "RomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXm" +
                        "JmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oAD" +
                        "AMBAAIRAxEAPwD2zXPEGmeHLH7XqdyIoydqKFLPI2M7VUcseO1AGJ4V+IujeL7xbXTob2ORoDcD7RDsB" +
                        "QNt9T3P86ALeueOvD+gN5dzeiacOUaC1HnSIQpY7lXleAetAGQ3xa8NpuDR6kNuc5sZOMZz2/2W/I0AL" +
                        "/wtnw3nAj1Inn/lxk7Z9vY/lQBv6H4r0XxDEjaffRmZt3+juwWZdrFTlDyOQe1AGFrPxU0DQtYl0y7g1" +
                        "BpYZ0gd4rbeoZhkdDk8eg9cZoA63TdSstX0+G/0+5S4tZhlJEOQf8+lAFqgDhfEfxd8J+GdUk0y5uJ7m" +
                        "8iOJY7WLf5Z9GPAz7UAbnh7xloPijR5dU0q/WW2gz524FWiwM/MDyOKAL+j63puv2AvtJvI7u1LFRJGe" +
                        "MjqKAL9ABQBhN4u0hPGC+FjM/8AarQ+cI/LO3bjP3unagC3p3iDSdWvb2z0+/iuLmxfZcRoeY2yRg/kf" +
                        "yoAdres2Xh7RrnVtRdktLZQ0jKpYgZA6D3NAHCf8L48B/8AP/c/+Ar/AOFAHQ/8LE8O/wDCGDxX9ol/s" +
                        "kvsD+S27O7b93r1oAuab4x0bVtfm0S0mka+ht1uWVomUbGCkHJ4z8w4oA3qAMOz8W6TfeKb3w5byyHUr" +
                        "JBJMhjIUDjo3Q/eFAG5QBhap4u0jRvEGmaJeTOl9qRxbqsZIbnHJHSgDdoAKACgAoA4vV2t4PihpUmqE" +
                        "LaT6fJb2TOcKtwWBcZ7MyYA9cECgDm9Q8Dv4NMPiBZH1mx0yICS12+VKIUOVYMpAkKDPDDkUAcQNCnkl" +
                        "07WLeBYv7Nu8XU0Ibc8lwWkdWkQFiI1ZFJ55YigDUi05o5bdjrO4RXUlwRuvRkOG+X/AFfH3jz3oALSw" +
                        "e1ayc6yXNq0zH570b95J/558Yz+NAGZpFg3hKDT9Q1HTzNMG/tXATZcTxSqYpItxwSVZkbaeob1FAHoe" +
                        "gfDea3uotV1K9W0H2iO8axiG8R+XkxxmZyWIUkk9BmgDY8CNDPqHie804D+x7jUN1sy/cdgiiV09i4PI" +
                        "6kE0AdnQB4PDo3jTwF4s1zWPDGn2XiPTdRnMkmxw0qZYtt4OQeT0yDxQAeF7vRfEGjeLoNAtLrwp4haM" +
                        "zX0eTKGVclgqtgKMkgjAxnigCz8FLfVrL4aX+q22rRlMTLb2l0AkEMg58xn649aAOZ1rxvrWjaQmqW3x" +
                        "GbVNaWcebaWtvvtFUk8bioHp+f40Adp4h8UeJPE3jbQ/CGh6l/Y/n2KXt3com5uV3bVz6D+ftQBiabpe" +
                        "t2n7QC6fqesfa7z+y5EhvxEFfaUbaxXpuBz9cUAP+Emj6qvxH8UsfEExWyvMXSmJcXpy4y393nnigD3W" +
                        "dIZIHW4VGhx8wkAK4980AfP2ut/wt/xsvhvw3bw2vh3T3D3d7HCo8wjjIOPqFHfqfYA6vx7d3PgeXwPo" +
                        "fh2X7Fp0t2IJYlUESJuTrkdeTz70AXfFniHVdN+MfhPR7O7MVhexk3EQUYkwW6nGewoA5jT9S8f+MPG3" +
                        "ivQdM8RLp9lY3bfv2jDPGochUXHrg5PtQBtWfjLU7P4qeMLa8umm0vSdONwkG0DBVUJ5xnnn86AMrQk+" +
                        "JPjTww/i+w8UfZbmWRjaaasSiEqrYwSfoeuf8ACn8QD4guvHvw8Egt7LX3jKsT+8jik3AFsdx3xQBteH" +
                        "tV8U+G/jJH4S1jX31mzvbUzpJLGFKHDHgDpypGOnIoA9hoAKACgDzn4g6jfahqN14atYNNa3t9LbU7k3" +
                        "6M4kUMVCrgjaRtJ3dRxigDjpfE+sR6JLaHUruHSIIrZhfyASyWzTxZEEynmVAGA3D5hkHnFAHPTS6xod" +
                        "t4etNP/ALWt7KK32lbCd2i1SbfuYxyRnqyEkEjjbg9KAPVPDuiaP4n0tb6w8S+JRg7JYZNUlWSFx1R1z" +
                        "wRQBr/8IDb/APQxeI//AAay/wCNAHkmsb7pb9zeX32DT9WSew1nUpGkjjWMBXVcndKzOpGwDnA9KANDU" +
                        "/EGsalpRsb+Wc2Itre4tY7qQA6gs02wSTlD8qAnPlr2IBNAHpXgjVL2SfV/D+oR2fn6LJHEJLKPy4nRk" +
                        "3KAv8JHQj6UAddQB5Evw18X+E9a1C68Da9aQWN/J5j2t5HkIcnpwc4/CgDX8HfDW60ebXNU13Vhfa1rM" +
                        "TRTTRJtSNT1wO/b06CgDL8O/C3xBpng/WfCV9rlrJpN3EwtzDEQ6SEg7mz246Z70AZtx8K/G2o+CYvCl" +
                        "zrOj2+nWpUx+RA++Yg8b2/EngcnrQBveIPhxrMmpaF4h8O6pb2evabaJbS+apMUyhcfXufwx0xQAnh/4" +
                        "d+JLX4kQ+MNd1u0vZjbtHLHFEU2kqQAvsOP1oAn0LwD4g8OfETU9asdYtTo+qTma5t3jPmEckAHpwW6+" +
                        "lAHR+PNA1LxN4Ru9H0q/WxnuCqtK2cFM/MvHPI4oA820D4WfETwvYNZaN4u0+0gZy7KsBJLccklcnpQB" +
                        "s+Ifht4n8ReFdIS98QwS+ItLumnjuihCMCQQOBwRgc4oAS3+HXiy+8c6H4p8Qa9ZXM9hw8MMRRVXnAXj" +
                        "k8kknFAG94M8D3nhnxb4o1i4u4ZotXn82JIwQyDcxwc/wC8OnpQBBZ/DyZPiH4i1+8uYZdP1e0NsbdQQ" +
                        "4BCg5PT+E0Ac3B8M/HOlaPceF9I8U2kfh+ZyVkeJhcRoTkqCP8AH8qANy9+Gdw3iLwde2moK1r4fQLJ9" +
                        "o3NLNzknPqeaAL954HvLj4uWHjFbuBbS2tTA0BB3kkOM+n8Q/KgDuKACgAoA8q+NEFpJY2Atbh08RTk2" +
                        "1tbwuFe5hcgSxn/AGcc57GgDlNA8Qw/a7TUbqzZtOguTq18iyLugMh8m3JU8ssaLk46ZB7UAanxM8K6Z" +
                        "pniLQrjTbE7L17gyW8ccs0e8KCHWKNgQ3XJXHvQBhaeNa8MaoNY8P6fdxzKNs1lFpF0iXgz0YuzYbrhq" +
                        "APb/DHiew8U6X9rs98csbeXcW0o2y28g6o69j/OgDifCemaFYw+IvF+oQBhaajeyQlyWSCNWOfLTO0E4" +
                        "PI5NAHnesXV0tounQ6XItyvmW1rZ+apkS3uh5kCsRwGSRBweQMUAeu/CptMm8Gx3VlfG9vbl/N1GZzmQ" +
                        "3JALhvTHAA9AKAO3oA5U+KtSv7u7TQNB/tC2tJmgkuJbpYFeReGVOCWweMnAyKANLw94hg1+3uCLeW0u" +
                        "7SUw3VrNjfC+AcHHBBBBBHBBoA2KACgCpd3c1tdWUUVlJOlxIUkkQjEI2k7m9sgD8aALdAGZfazHY63p" +
                        "OmNCzvqLShXBGE2JuOfrQBp0AFAHL3vinUV8R3mjaXoD372kUcssn2pIgN+cAA9fumgCfTPFX2nVl0jV" +
                        "NMuNK1GRC8McxV0nUfe2OpIJHccH2oA1rC7muxcmayktfKneJBIQfMUHhxjse1AFugAoAKAGSyLDE8jZ" +
                        "2opY49BQBW0rUrfWNJtdStd32e6jWWPeMHaRkZFAFygAoA474jxWVv4YudVNnBJqsUZtrGZ1BeOSYiMb" +
                        "T2+9n8KAOFnFs93a3s1oh8GWlo/h8Xa8MNwCNOfWPcuzPY80AV/Et0dW+HGkzXMsM2o+GrsQanEwLlEX" +
                        "MTSFFYMQflbqOtAGSumh1DJppZSMgjQrzBH/f6gCA3F94OuD4k01ZbF7ZP38Q0eeGK6XI+SRndsex7Gg" +
                        "DrJJ4rbwPoXhvU54re41Cd9R1WNnGbe23tcOHHUZyqc9cmgDPu579dH1me508WUWvTNq+js/wDrFmiKu" +
                        "I3PZnRAwHuwoA9d8N2+kx6PFeaPZwW1vqAF2RCgUOzgHccd6ANegDhtP0nVLZJ7/wAF67ZTaXeTyTi0v" +
                        "IS8auzHfskUhgN2eCDg5oApah4rv49D1+2ewi0nxFbvbxTSxEOhWZgiTK2ATgbuD0IoAm8S+GLHwv4Zu" +
                        "tc0eSe31TTo/PFy9w7tPt5ZZMnDBhkH68YoAl8X2ekSNbzLp0l3r+pgJawfaZUGQvLuFYAIo5Jx7dTQB" +
                        "C+jv4Xk8D6VFe3E2NQk8+V5GJlYwSk5yemeg7YFAFSW00nWb3VZTYar4iuWnkVbqEmGK3wcCONy4A245" +
                        "Zc85oATQr+61P8A4VreXsrS3MsVwZHY5LHySMn1PFAGbpD2/iPTH1bVvD+v31/dySMl1bMAsChyEWLEg" +
                        "2hQB2yTnNAHovhKbVJvC1g2tRPHqIQrMJMBiQSAxwSMkAE/WgDK0f8A5Kh4m/69LT+T0AHjfb/aPhMR/" +
                        "wDH1/bEfl467dj+Z+G3NAHLXmr30OiXtrFJev8AbvFE1m5tWzMIssxWMkjBITHXjJoAvWED6f4g0qXw9" +
                        "4a1nTommEV8twR5LwkH5jmQ/MpwQQMnnNAD/Cvhax8RaPqFxrMlxeSNf3SQlp3H2dRKwATB4PGc9aAK0" +
                        "KaxrvgfwtdSxz6tbQl/7QtY5/LlulXKK2cjdggEqSMmgC3pFpod5Dr+l2/9oWkDW6ySaPdh42hIz+8Q5" +
                        "ztYgfdOMrQBlWwOg/CTw9HpSXaS6u9tDO1s5abDDL+XuOFYhSBjGM0AX7S3aw1vSpvDvhnWtO/0hYrz7" +
                        "QR5MkByCWzIcsDgg9evrQB6XQBh+KvDzeI9Lit4rw2lxb3EdzBLsDqJEORuU8MPagCLQPCdrpHhQ6DdS" +
                        "fb4ZfMM/mIFV/MJLAKOFXk4A6UAY/hz4cR6JrbXtzqRvoY7V7OCJ4FU+UxBIlYf60gAAZ7CgDKuvg3p0" +
                        "N5LPo80McMhz9lvYWnjj/3CHVlHtk0AWdE+Eek2WrRanqbpeTQkNFbxReVbow6HYSSxHufwoAsXHwygu" +
                        "/E91f3GoeZpl3crdz2ZgXfJIAAFMvUx5UHZ04oA2PF3hWXxGmny2uofYbuwlaSJ2hEqHchQ5Q8E4PB7G" +
                        "gDT0DR4vD/h+x0iGV5Y7SJYg8n3mx3NAGlQByaeEL7TLm4bw/4gl021uJGla0e3SeNHY5YpnBUE5OM4y" +
                        "aAJrTwVYrpuqW+pXE2pXGqgC8uZiFZwBhQoXAQL2A6HmgCB/B19exQ2WseI7jUNLiZWNu0KI0205USOO" +
                        "WGQM4AzjmgAuPCGot4lvdbtPEk1vPcosYU2scgijH8ClhwM8n1NAF0eG7i4l0mfUtWlvLjTbprhJPJSP" +
                        "fmNk2kLxgbic0AUbfwbeWSTWNl4huLfR5ZXk+yrCpdA5LMiy9QCSe2Rng0AS6R4Jh0hdDjW/mlj0Zpvs" +
                        "6uqj5HUqFJHXaD170AM/wCEQv7JrqDRfEU+nafcyNIbcQJIYmY5by2P3QSScc4J4oA6DStMtdF0q202z" +
                        "Urb26BE3HJPuT3JPJNAGHe+FL6TxHd6zpniCfTpLuKOKWNbeORTszg/MOOpoAn0vwqlnqq6tqOo3Wq6k" +
                        "iGOOa42hYVPUIigKucDJ6mgCKTwXZy6VfWTXU6tc376hHOhCvBKW3AqfY+vUUALbeGL2XVLS91vW5NS+" +
                        "xEvbwiBYUVyMb2A+8wBOOwyeKANLQtFi0GwktIpXlV7iWfcwAILuWI/DOKAMZPA62ulaTb6fqk9re6UZ" +
                        "Ps91sVshySysp4YHj8higC5pnhmS31C61LVNSk1G/uIBbb/ACxEkcWc7VUdMk5JJJ6UAVLXwSkfhX/hH" +
                        "7vVJ7m3hZDZyhFjltthBTDDqVIHJoAlg8L30+o2d1reuyakli/mwQiBYU8zBAdtv3iATjoO+KAOmoAKA" +
                        "CgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAP//ZCwHzBHByaXZhd" +
                        "GUgdm9pZCBPbkJlZm9yZVByaW50KG9iamVjdCBzZW5kZXIsIFN5c3RlbS5EcmF3aW5nLlByaW50aW5nL" +
                        "lByaW50RXZlbnRBcmdzIGUpDQp7DQogLy8gYm9vbCBydWVja3phaGx1bmcgPSB4cmxibEFydC5UZXh0I" +
                        "D09ICJUcnVlIjsgIC8vLi4uZG9uJ3QgYXNrLCB3ZSBkb24ndCBoYXZlIGFjY2VzcyB0byB0aGUgRGF0Y" +
                        "VNvdXJjZSBoZXJlDQogLy8gc3RyaW5nIHJ1ZWNrQXVzWmFobHVuZ1RleHQgPSBydWVja3phaGx1bmcgP" +
                        "yAiUsO8Y2t6YWhsdW5nZW4iIDogIkF1c3phaGx1bmdlbiI7DQoNCiAgaW50IGFydCA9IDA7DQogIHN0c" +
                        "mluZyBhcnRUZXh0ID0gc3RyaW5nLkVtcHR5Ow0KICBpZiggIWludC5UcnlQYXJzZSh4cmxibFNpTGVpQ" +
                        "XJ0LlRleHQsIG91dCBhcnQpKSANCiAgICBhcnRUZXh0ID0gIk1pZXR6aW5zZGVwb3RzIChNRCkgLyBBb" +
                        "nRlaWxzY2hlaW5lIChBUyk6IjsNCiAgZWxzZSBpZiggYXJ0ID09IDIgKQ0KICAgIGFydFRleHQgPSAiT" +
                        "WlldHppbnNkZXBvdHMgKE1EKToiOw0KICBlbHNlIGlmKCBhcnQgPT0gMyApDQogICAgYXJ0VGV4dCA9I" +
                        "CJBbnRlaWxzY2hlaW5lIChBUyk6IjsNCiAgDQogIHhybGJsVGl0bGUuVGV4dCA9IHN0cmluZy5Gb3JtY" +
                        "XQoInswfSIsIGFydFRleHQpOw0KfQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
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
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==";
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
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabelAngezeigt = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelDetail2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelDetail1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblSiLeiArt = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblArt = new DevExpress.XtraReports.UI.XRLabel();
            this.xrlblTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrTable2});
            this.Detail.Dpi = 254F;
            this.Detail.Height = 42;
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
                        this.xrTable1,
                        this.Line1});
            this.PageHeader.Dpi = 254F;
            this.PageHeader.Height = 56;
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
                        this.xrTable4,
                        this.Line2});
            this.PageFooter.Dpi = 254F;
            this.PageFooter.Height = 84;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabelAngezeigt,
                        this.xrLabelDetail2,
                        this.xrLabelDetail1,
                        this.xrlblSiLeiArt,
                        this.xrlblArt,
                        this.xrlblTitle,
                        this.xrLabel3,
                        this.xrPictureBox1});
            this.ReportHeader.Dpi = 254F;
            this.ReportHeader.Height = 386;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrTable3,
                        this.xrLine2,
                        this.xrLine1});
            this.ReportFooter.Dpi = 254F;
            this.ReportFooter.Height = 85;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrTable2
            // 
            this.xrTable2.Dpi = 254F;
            this.xrTable2.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrTable2.Location = new System.Drawing.Point(0, 0);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.ParentStyleUsing.UseFont = false;
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow2});
            this.xrTable2.Size = new System.Drawing.Size(2669, 42);
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell11,
                        this.xrTableCell12,
                        this.xrTableCell13,
                        this.xrTableCell14,
                        this.xrTableCell15,
                        this.xrTableCell23,
                        this.xrTableCell16,
                        this.xrTableCell17,
                        this.xrTableCell18,
                        this.xrTableCell19,
                        this.xrTableCell20});
            this.xrTableRow2.Dpi = 254F;
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Size = new System.Drawing.Size(2669, 42);
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ShortText", "")});
            this.xrTableCell11.Dpi = 254F;
            this.xrTableCell11.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell11.Size = new System.Drawing.Size(70, 42);
            this.xrTableCell11.Text = "xrTableCell11";
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BaPersonID", "")});
            this.xrTableCell12.Dpi = 254F;
            this.xrTableCell12.Location = new System.Drawing.Point(70, 0);
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell12.Size = new System.Drawing.Size(120, 42);
            this.xrTableCell12.Text = "xrTableCell12";
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameVorname", "")});
            this.xrTableCell13.Dpi = 254F;
            this.xrTableCell13.Location = new System.Drawing.Point(190, 0);
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell13.Size = new System.Drawing.Size(614, 42);
            this.xrTableCell13.Text = "xrTableCell13";
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BuchungsDatum", "{0:dd.MM.yyyy}")});
            this.xrTableCell14.Dpi = 254F;
            this.xrTableCell14.Location = new System.Drawing.Point(804, 0);
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell14.Size = new System.Drawing.Size(170, 42);
            this.xrTableCell14.Text = "xrTableCell14";
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BelegNr", "")});
            this.xrTableCell15.Dpi = 254F;
            this.xrTableCell15.Location = new System.Drawing.Point(974, 0);
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell15.Size = new System.Drawing.Size(275, 42);
            this.xrTableCell15.Text = "xrTableCell15";
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BelegNrnBrutto", "")});
            this.xrTableCell23.Dpi = 254F;
            this.xrTableCell23.Location = new System.Drawing.Point(1249, 0);
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell23.Size = new System.Drawing.Size(233, 42);
            this.xrTableCell23.Text = "xrTableCell23";
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "LA", "")});
            this.xrTableCell16.Dpi = 254F;
            this.xrTableCell16.Location = new System.Drawing.Point(1482, 0);
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell16.Size = new System.Drawing.Size(106, 42);
            this.xrTableCell16.Text = "xrTableCell16";
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Buchungstext", "")});
            this.xrTableCell17.Dpi = 254F;
            this.xrTableCell17.Location = new System.Drawing.Point(1588, 0);
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell17.Size = new System.Drawing.Size(656, 42);
            this.xrTableCell17.Text = "xrTableCell17";
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.xrTableCell18.Dpi = 254F;
            this.xrTableCell18.Location = new System.Drawing.Point(2244, 0);
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell18.Size = new System.Drawing.Size(169, 42);
            this.xrTableCell18.Text = "xrTableCell18";
            this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Tool", "")});
            this.xrTableCell19.Dpi = 254F;
            this.xrTableCell19.Location = new System.Drawing.Point(2413, 0);
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell19.Size = new System.Drawing.Size(106, 42);
            this.xrTableCell19.Text = "xrTableCell19";
            this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Typ", "")});
            this.xrTableCell20.Dpi = 254F;
            this.xrTableCell20.Location = new System.Drawing.Point(2519, 0);
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell20.Size = new System.Drawing.Size(150, 42);
            this.xrTableCell20.Text = "xrTableCell20";
            // 
            // xrTable1
            // 
            this.xrTable1.Dpi = 254F;
            this.xrTable1.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrTable1.Location = new System.Drawing.Point(0, 0);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.ParentStyleUsing.UseFont = false;
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow1});
            this.xrTable1.Size = new System.Drawing.Size(2669, 42);
            // 
            // Line1
            // 
            this.Line1.Dpi = 254F;
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.LineWidth = 3;
            this.Line1.Location = new System.Drawing.Point(0, 45);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(2669, 11);
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell1,
                        this.xrTableCell2,
                        this.xrTableCell3,
                        this.xrTableCell4,
                        this.xrTableCell5,
                        this.xrTableCell25,
                        this.xrTableCell6,
                        this.xrTableCell7,
                        this.xrTableCell8,
                        this.xrTableCell9,
                        this.xrTableCell10});
            this.xrTableRow1.Dpi = 254F;
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Size = new System.Drawing.Size(2669, 42);
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Dpi = 254F;
            this.xrTableCell1.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell1.Size = new System.Drawing.Size(70, 42);
            this.xrTableCell1.Text = "Typ";
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Dpi = 254F;
            this.xrTableCell2.Location = new System.Drawing.Point(70, 0);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell2.Size = new System.Drawing.Size(120, 42);
            this.xrTableCell2.Text = "PNr";
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Dpi = 254F;
            this.xrTableCell3.Location = new System.Drawing.Point(190, 0);
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell3.Size = new System.Drawing.Size(614, 42);
            this.xrTableCell3.Text = "Name, Vorname";
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Dpi = 254F;
            this.xrTableCell4.Location = new System.Drawing.Point(804, 0);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell4.Size = new System.Drawing.Size(170, 42);
            this.xrTableCell4.Text = "B-Datum";
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Dpi = 254F;
            this.xrTableCell5.Location = new System.Drawing.Point(974, 0);
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell5.Size = new System.Drawing.Size(254, 42);
            this.xrTableCell5.Text = "BelegNr.";
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Dpi = 254F;
            this.xrTableCell25.Location = new System.Drawing.Point(1228, 0);
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell25.Size = new System.Drawing.Size(254, 42);
            this.xrTableCell25.Text = "BelegNr Brutto";
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Dpi = 254F;
            this.xrTableCell6.Location = new System.Drawing.Point(1482, 0);
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell6.Size = new System.Drawing.Size(106, 42);
            this.xrTableCell6.Text = "LA";
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Dpi = 254F;
            this.xrTableCell7.Location = new System.Drawing.Point(1588, 0);
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell7.Size = new System.Drawing.Size(656, 42);
            this.xrTableCell7.Text = "Buchungstext";
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Dpi = 254F;
            this.xrTableCell8.Location = new System.Drawing.Point(2244, 0);
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell8.Size = new System.Drawing.Size(169, 42);
            this.xrTableCell8.Text = "Betrag";
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Dpi = 254F;
            this.xrTableCell9.Location = new System.Drawing.Point(2413, 0);
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell9.Size = new System.Drawing.Size(106, 42);
            this.xrTableCell9.Text = "K/P";
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Dpi = 254F;
            this.xrTableCell10.Location = new System.Drawing.Point(2519, 0);
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell10.Size = new System.Drawing.Size(150, 42);
            this.xrTableCell10.Text = "Typ";
            // 
            // xrTable4
            // 
            this.xrTable4.Dpi = 254F;
            this.xrTable4.Font = new System.Drawing.Font("Arial", 8.5F);
            this.xrTable4.Location = new System.Drawing.Point(0, 42);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.ParentStyleUsing.UseFont = false;
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow4});
            this.xrTable4.Size = new System.Drawing.Size(2669, 42);
            // 
            // Line2
            // 
            this.Line2.Dpi = 254F;
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.LineWidth = 3;
            this.Line2.Location = new System.Drawing.Point(0, 3);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(2669, 21);
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell22,
                        this.xrTableCell26,
                        this.xrTableCell31});
            this.xrTableRow4.Dpi = 254F;
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Size = new System.Drawing.Size(2669, 42);
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageInfo2});
            this.xrTableCell22.Dpi = 254F;
            this.xrTableCell22.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell22.Size = new System.Drawing.Size(868, 42);
            this.xrTableCell22.Text = "Typ";
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageInfo1});
            this.xrTableCell26.Dpi = 254F;
            this.xrTableCell26.Location = new System.Drawing.Point(868, 0);
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell26.Size = new System.Drawing.Size(994, 42);
            this.xrTableCell26.Text = "Baugenossenschaft / Depothalter";
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Dpi = 254F;
            this.xrTableCell31.Location = new System.Drawing.Point(1862, 0);
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell31.Size = new System.Drawing.Size(807, 42);
            this.xrTableCell31.Text = "KiSS 4";
            this.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 254F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 8F);
            this.xrPageInfo2.Format = "{0:Druck\\da\\tu\\m: dd.MM.yyyy}";
            this.xrPageInfo2.Location = new System.Drawing.Point(0, 0);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            this.xrPageInfo2.Size = new System.Drawing.Size(868, 43);
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 254F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8F);
            this.xrPageInfo1.Format = "Seite {0}/{1}";
            this.xrPageInfo1.Location = new System.Drawing.Point(0, 0);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(994, 43);
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabelAngezeigt
            // 
            this.xrLabelAngezeigt.Dpi = 254F;
            this.xrLabelAngezeigt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabelAngezeigt.Location = new System.Drawing.Point(0, 169);
            this.xrLabelAngezeigt.Multiline = true;
            this.xrLabelAngezeigt.Name = "xrLabelAngezeigt";
            this.xrLabelAngezeigt.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelAngezeigt.ParentStyleUsing.UseFont = false;
            this.xrLabelAngezeigt.Scripts.OnBeforePrint = "private void OnBeforePrint(object sender, System.Drawing.Printing.PrintEventArgs " +
                "e)\r\n{\r\n\txrLabelAngezeigt.Text= xrlblTitle.Text + \" \" +\r\n\t\t\t\txrLabelDetail1.Text " +
                "+ \" \" +\r\n\t\t\t\txrLabelDetail2.Text;\t \r\n}";
            this.xrLabelAngezeigt.Size = new System.Drawing.Size(2170, 191);
            this.xrLabelAngezeigt.Text = "[in Skript]";
            // 
            // xrLabelDetail2
            // 
            this.xrLabelDetail2.Dpi = 254F;
            this.xrLabelDetail2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabelDetail2.Location = new System.Drawing.Point(1990, 21);
            this.xrLabelDetail2.Multiline = true;
            this.xrLabelDetail2.Name = "xrLabelDetail2";
            this.xrLabelDetail2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelDetail2.ParentStyleUsing.UseFont = false;
            this.xrLabelDetail2.Scripts.OnBeforePrint = "private void OnBeforePrint(object sender, System.Drawing.Printing.PrintEventArgs " +
                "e)\r\n{\r\n  xrLabelDetail2.Text = string.Format(\"vom {0}\", xrLabelDetail2.Text);\r\n\t" +
                "\r\n}";
            this.xrLabelDetail2.Size = new System.Drawing.Size(254, 85);
            this.xrLabelDetail2.Text = "[Stichtag]";
            this.xrLabelDetail2.Visible = false;
            // 
            // xrLabelDetail1
            // 
            this.xrLabelDetail1.Dpi = 254F;
            this.xrLabelDetail1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabelDetail1.Location = new System.Drawing.Point(1588, 21);
            this.xrLabelDetail1.Multiline = true;
            this.xrLabelDetail1.Name = "xrLabelDetail1";
            this.xrLabelDetail1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabelDetail1.ParentStyleUsing.UseFont = false;
            this.xrLabelDetail1.Size = new System.Drawing.Size(339, 85);
            this.xrLabelDetail1.Text = "[Ebene2Text]";
            this.xrLabelDetail1.Visible = false;
            // 
            // xrlblSiLeiArt
            // 
            this.xrlblSiLeiArt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Art", "")});
            this.xrlblSiLeiArt.Dpi = 254F;
            this.xrlblSiLeiArt.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrlblSiLeiArt.Location = new System.Drawing.Point(974, 64);
            this.xrlblSiLeiArt.Name = "xrlblSiLeiArt";
            this.xrlblSiLeiArt.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrlblSiLeiArt.ParentStyleUsing.UseFont = false;
            this.xrlblSiLeiArt.Size = new System.Drawing.Size(190, 43);
            this.xrlblSiLeiArt.Text = "xrlblSiLeiArt";
            this.xrlblSiLeiArt.Visible = false;
            // 
            // xrlblArt
            // 
            this.xrlblArt.Dpi = 254F;
            this.xrlblArt.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrlblArt.Location = new System.Drawing.Point(1355, 64);
            this.xrlblArt.Name = "xrlblArt";
            this.xrlblArt.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrlblArt.ParentStyleUsing.UseFont = false;
            this.xrlblArt.Size = new System.Drawing.Size(190, 43);
            this.xrlblArt.Text = "xrlblArt";
            this.xrlblArt.Visible = false;
            // 
            // xrlblTitle
            // 
            this.xrlblTitle.Dpi = 254F;
            this.xrlblTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrlblTitle.Location = new System.Drawing.Point(1143, 42);
            this.xrlblTitle.Multiline = true;
            this.xrlblTitle.Name = "xrlblTitle";
            this.xrlblTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrlblTitle.ParentStyleUsing.UseFont = false;
            this.xrlblTitle.Scripts.OnBeforePrint = resources.GetString("xrlblTitle.Scripts.OnBeforePrint");
            this.xrlblTitle.Size = new System.Drawing.Size(190, 85);
            this.xrlblTitle.Text = "[in Skript]";
            this.xrlblTitle.Visible = false;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.Location = new System.Drawing.Point(2262, 0);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(402, 360);
            this.xrLabel3.Text = "Stadt Zürich\r\nSoziale Dienste\r\nVerwaltungszentrum Werd\r\nPostfach\r\n8036 Zürich\r\n\r\n" +
                "Telefon  044 412 61 11\r\nFax        044 412 09 89\r\nwww.stadt-zuerich.ch/sd";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Dpi = 254F;
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.Size = new System.Drawing.Size(868, 127);
            // 
            // xrTable3
            // 
            this.xrTable3.Dpi = 254F;
            this.xrTable3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTable3.Location = new System.Drawing.Point(0, 21);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.ParentStyleUsing.UseFont = false;
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow3});
            this.xrTable3.Size = new System.Drawing.Size(2669, 42);
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 254F;
            this.xrLine2.ForeColor = System.Drawing.Color.Black;
            this.xrLine2.LineWidth = 5;
            this.xrLine2.Location = new System.Drawing.Point(0, 64);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.ParentStyleUsing.UseBackColor = false;
            this.xrLine2.ParentStyleUsing.UseBorderColor = false;
            this.xrLine2.ParentStyleUsing.UseBorders = false;
            this.xrLine2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine2.ParentStyleUsing.UseFont = false;
            this.xrLine2.ParentStyleUsing.UseForeColor = false;
            this.xrLine2.Size = new System.Drawing.Size(2669, 21);
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 254F;
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.LineWidth = 3;
            this.xrLine1.Location = new System.Drawing.Point(0, 0);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(2669, 21);
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell21,
                        this.xrTableCell24,
                        this.xrTableCell28,
                        this.xrTableCell30});
            this.xrTableRow3.Dpi = 254F;
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Size = new System.Drawing.Size(2669, 42);
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Dpi = 254F;
            this.xrTableCell21.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell21.Size = new System.Drawing.Size(868, 42);
            xrSummary1.FormatString = "{0} Positionen";
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Count;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell21.Summary = xrSummary1;
            this.xrTableCell21.Text = "xrTableCell21";
            this.xrTableCell21.Visible = false;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Dpi = 254F;
            this.xrTableCell24.Location = new System.Drawing.Point(868, 0);
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell24.Size = new System.Drawing.Size(1376, 42);
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "")});
            this.xrTableCell28.Dpi = 254F;
            this.xrTableCell28.Location = new System.Drawing.Point(2244, 0);
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell28.Size = new System.Drawing.Size(168, 42);
            xrSummary2.FormatString = "{0:n2}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell28.Summary = xrSummary2;
            this.xrTableCell28.Text = "xrTableCell28";
            this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.Dpi = 254F;
            this.xrTableCell30.Location = new System.Drawing.Point(2412, 0);
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell30.Size = new System.Drawing.Size(257, 42);
            xrSummary3.FormatString = "{0:#.00}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell30.Summary = xrSummary3;
            this.xrTableCell30.Text = "xrTableCell30";
            this.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell30.Visible = false;
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
                        this.PageFooter,
                        this.ReportHeader,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Dpi = 254F;
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(201, 99, 99, 79);
            this.Name = "Report";
            this.PageHeight = 2101;
            this.PageWidth = 2969;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' , ParameterXML =  N'<?xml version="1.0" standalone="yes" ?>
<NewDataSet>
<!--Leistungsarten-->
	<Table>
		<FieldName>label</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Leistungsarten:</DisplayText>
		<TabPosition>36</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>true</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>LeistungsArten</FieldName>
		<FieldCode>17</FieldCode>
		<DisplayText>Leistungsarten:</DisplayText>
		<TabPosition>37</TabPosition>
		<X>120</X>
		<Y>60</Y>
		<Width>728</Width>
		<Height>268</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>true</Mandatory>
		<Visible>true</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
		<SQL>
		SELECT Code=BgKostenartID, [Name]=KontoNr + '' '' + Name 
		FROM BgKostenart
		WHERE KontoNr IN (''031'', ''032'', ''033'', ''034'', ''041'', ''320'', ''321'', ''860'', ''861'', ''862'')
		ORDER BY KontoNr
		</SQL>
		<ParameterCount>2</ParameterCount>
		<Parameter0>Verfügbare Leistungsart</Parameter0>
		<Parameter1>Zugeteilte Leistungsart</Parameter1>		
	</Table>

<!--edtSucheArt-->
	<Table>
		<FieldName>lblSucheArt</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Art:</DisplayText>
		<TabPosition>0</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>edtSucheArt</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>Art:</DisplayText>
		<TabPosition>1</TabPosition>
		<X>80</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
		<SQL></SQL>
		<ParameterCount>0</ParameterCount>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
<!--edtSucheBaPersonID-->
	<Table>
		<FieldName>lblSucheBaPersonID</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Pers.-Nr.:</DisplayText>
		<TabPosition>2</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>edtSucheBaPersonID</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>Pers.-Nr.:</DisplayText>
		<TabPosition>3</TabPosition>
		<X>80</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
		<SQL></SQL>
		<ParameterCount>0</ParameterCount>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>

<!--edtSucheKlient-->
	<Table>
		<FieldName>lblSucheKlient</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Klient:</DisplayText>
		<TabPosition>4</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>edtSucheKlient</FieldName>
		<FieldCode>2</FieldCode>
		<DisplayText>Klient:</DisplayText>
		<TabPosition>5</TabPosition>
		<X>80</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
		<SQL></SQL>
		<ParameterCount>0</ParameterCount>
	</Table>

<!--edtSucheAuszahlungVon-->
	<Table>
		<FieldName>lblSucheAuszahlungVon</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Auszahlung von:</DisplayText>
		<TabPosition>6</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>edtSucheAuszahlungVon</FieldName>
		<FieldCode>5</FieldCode>
		<DisplayText>Auszahlung von:</DisplayText>
		<TabPosition>7</TabPosition>
		<X>80</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
		<SQL></SQL>
		<ParameterCount>0</ParameterCount>
	</Table>
	
<!--edtSucheAuszahlungBis-->
	<Table>
		<FieldName>lblSucheAuszahlungBis</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Auszahlung bis:</DisplayText>
		<TabPosition>8</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>edtSucheAuszahlungBis</FieldName>
		<FieldCode>5</FieldCode>
		<DisplayText>Auszahlung bis:</DisplayText>
		<TabPosition>9</TabPosition>
		<X>80</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
		<SQL></SQL>
		<ParameterCount>0</ParameterCount>
	</Table>
	
<!--edtSucheFaFallID-->
	<Table>
		<FieldName>lblSucheFaFallID</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Fall-Nr.:</DisplayText>
		<TabPosition>10</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>edtSucheFaFallID</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>Fall-Nr:</DisplayText>
		<TabPosition>11</TabPosition>
		<X>80</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
		<SQL></SQL>
		<ParameterCount>0</ParameterCount>
	</Table>

<!--edtSucheAltePNr-->
	<Table>
		<FieldName>lblSucheAltePNr</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Alte P-Nr.:</DisplayText>
		<TabPosition>12</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>edtSucheAltePNr</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>Alte P-Nr:</DisplayText>
		<TabPosition>13</TabPosition>
		<X>80</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
		<SQL></SQL>
		<ParameterCount>0</ParameterCount>
	</Table>

<!--edtSucheMigriert-->
	<Table>
		<FieldName>lblSucheMigriert</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Migriert:</DisplayText>
		<TabPosition>14</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>edtSucheMigriert</FieldName>
		<FieldCode>7</FieldCode>
		<DisplayText>Migriert:</DisplayText>
		<TabPosition>15</TabPosition>
		<X>80</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
		<SQL></SQL>
		<ParameterCount>0</ParameterCount>
	</Table>

<!--edtSucheLaufend-->
	<Table>
		<FieldName>lblSucheLaufend</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Laufend:</DisplayText>
		<TabPosition>16</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>edtSucheLaufend</FieldName>
		<FieldCode>7</FieldCode>
		<DisplayText>Laufend:</DisplayText>
		<TabPosition>17</TabPosition>
		<X>80</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
		<SQL></SQL>
		<ParameterCount>0</ParameterCount>
	</Table>

<!--edtSucheNeu-->
	<Table>
		<FieldName>lblucheNeu</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Neu:</DisplayText>
		<TabPosition>18</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>edtSucheNeu</FieldName>
		<FieldCode>7</FieldCode>
		<DisplayText>Neu:</DisplayText>
		<TabPosition>19</TabPosition>
		<X>80</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
		<SQL></SQL>
		<ParameterCount>0</ParameterCount>
	</Table>

<!--edtSucheInstitution-->
	<Table>
		<FieldName>lblSucheInstitution</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Institution:</DisplayText>
		<TabPosition>20</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>edtSucheInstitution</FieldName>
		<FieldCode>2</FieldCode>
		<DisplayText>Institution:</DisplayText>
		<TabPosition>21</TabPosition>
		<X>80</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
		<SQL></SQL>
		<ParameterCount>0</ParameterCount>
	</Table>

<!--edtSucheKontoNr-->
	<Table>
		<FieldName>lblSucheKontoNr</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Konto-Nr.:</DisplayText>
		<TabPosition>22</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>edtSucheKontoNr</FieldName>
		<FieldCode>2</FieldCode>
		<DisplayText>Konto-Nr:</DisplayText>
		<TabPosition>23</TabPosition>
		<X>80</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
		<SQL></SQL>
		<ParameterCount>0</ParameterCount>
	</Table>

<!--edtSucheStrasse-->
	<Table>
		<FieldName>lblSucheStrasse</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Strasse:</DisplayText>
		<TabPosition>24</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>edtSucheStrasse</FieldName>
		<FieldCode>2</FieldCode>
		<DisplayText>Strasse:</DisplayText>
		<TabPosition>25</TabPosition>
		<X>80</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
		<SQL></SQL>
		<ParameterCount>0</ParameterCount>
	</Table>

<!--edtSucheHausNr-->
	<Table>
		<FieldName>lblSucheHausNr</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Nr:</DisplayText>
		<TabPosition>26</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>edtSucheHausNr</FieldName>
		<FieldCode>2</FieldCode>
		<DisplayText>Nr:</DisplayText>
		<TabPosition>27</TabPosition>
		<X>80</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
		<SQL></SQL>
		<ParameterCount>0</ParameterCount>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>

<!--edtSuchePLZ-->
	<Table>
		<FieldName>lblSuchePLZ</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>PLZ:</DisplayText>
		<TabPosition>28</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>edtSuchePLZ</FieldName>
		<FieldCode>2</FieldCode>
		<DisplayText>PLZ:</DisplayText>
		<TabPosition>29</TabPosition>
		<X>80</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
		<SQL></SQL>
		<ParameterCount>0</ParameterCount>
	</Table>

<!--edtSucheOrt-->
	<Table>
		<FieldName>lblSucheOrt</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Ort:</DisplayText>
		<TabPosition>30</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>edtSucheOrt</FieldName>
		<FieldCode>2</FieldCode>
		<DisplayText>Ort:</DisplayText>
		<TabPosition>31</TabPosition>
		<X>80</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
		<SQL></SQL>
		<ParameterCount>0</ParameterCount>
	</Table>
	
<!--edtReportBelegeVon-->
	<Table>
		<FieldName>lblReportBelegeVon</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Stichtag von:</DisplayText>
		<TabPosition>32</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>edtReportBelegeVon</FieldName>
		<FieldCode>5</FieldCode>
		<DisplayText>Stichtag von:</DisplayText>
		<TabPosition>33</TabPosition>
		<X>80</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
		<SQL></SQL>
		<ParameterCount>0</ParameterCount>
	</Table>
	
<!--edtReportBelegeBis-->
	<Table>
		<FieldName>lblReportBelegeBis</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Stichtag bis:</DisplayText>
		<TabPosition>34</TabPosition>
		<X>10</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>edtReportBelegeBis</FieldName>
		<FieldCode>5</FieldCode>
		<DisplayText>Stichtag bis:</DisplayText>
		<TabPosition>35</TabPosition>
		<X>80</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<Visible>false</Visible>
		<TabName></TabName>
		<AppCode></AppCode>
		<SQL></SQL>
		<ParameterCount>0</ParameterCount>
	</Table>
</NewDataSet>' , SQLquery =  N'-- Alle Variablen übernehmen
DECLARE @SelektierteLeistungsarten TABLE
(
  BgKostenartID INT,
  KontoNr VARCHAR(250),
  Andruck VARCHAR(250)
)
INSERT INTO @SelektierteLeistungsarten (BgKostenartID, KontoNr, Andruck) 
  SELECT 
    BgKostenartID = SplitValue,
    KontoNr       = BKA.KontoNr,
    Andruck       = CASE 
                      WHEN BKA.KontoNr=''321'' OR  BKA.KontoNr=''320''  THEN ''Auszahlungen''
					            WHEN BKA.KontoNr=''860'' OR  BKA.KontoNr=''861''  THEN ''Rückzahlungen''
					            WHEN BKA.KontoNr=''862''   THEN ''Rückzahlungen a.o. (ohne Vereinbarung)''
					            WHEN BKA.KontoNr=''031''   THEN ''Auswertung Bankspesen''
					            WHEN BKA.KontoNr=''032''   THEN ''Auswertung Solidaritätsbeitrag''
					            WHEN BKA.KontoNr=''033''   THEN ''Auswertung VST nicht einforderbar''
					            WHEN BKA.KontoNr=''034''   THEN ''Auswertung VST einforderbar''
					            WHEN BKA.KontoNr=''041''   THEN ''Auswertung Zinsverbuchung''
				            END 
  FROM dbo.fnSplitStringToValues({LeistungsArten}, '','', 1) SL
  	INNER JOIN dbo.BgKostenart                             BKA WITH (READUNCOMMITTED) ON SL.SplitValue=BKA.BgKostenartID

--Berechnung Texte für Ebene2 in der Detailselektion
DECLARE @TextEbene2 VARCHAR(8000); 
SELECT  @TextEbene2 = dbo.ConcDistinctOrder('' '' + Andruck)
FROM @SelektierteLeistungsarten
IF LEN( @TextEbene2 ) >0
  SELECT  @TextEbene2 =  SUBSTRING(@TextEbene2, 2, LEN(@TextEbene2)-1)



DECLARE @DatumVon datetime
SET @DatumVon = IsNull({edtReportBelegeVon},''1900-01-01'')

DECLARE @DatumBis datetime
--SET @DatumBis = DATEADD(ms,-3,DATEADD(d,1,{edtReportBelegeBis}))
SET @DatumBis={edtReportBelegeBis}
IF {edtReportBelegeBis} IS NULL 
  SET @DatumBis=GETDATE()

DECLARE @SucheArt int
SET @SucheArt = {edtSucheArt}

DECLARE @SucheBaPersonID int
SET @SucheBaPersonID = {edtSucheBaPersonID}

DECLARE @SucheKlient varchar(50)
SET @SucheKlient = null
IF {edtSucheKlient} is not null and {edtSucheKlient} <> N'''' SET @SucheKlient = ''%'' + replace({edtSucheKlient}, '' '', ''%'') + ''%''

DECLARE @SucheAuszahlungVon datetime
SET @SucheAuszahlungVon = null
IF {edtSucheAuszahlungVon} is not null SET @SucheAuszahlungVon = {edtSucheAuszahlungVon}

DECLARE @SucheAuszahlungBis datetime
SET @SucheAuszahlungBis = null
IF {edtSucheAuszahlungBis} is not null SET @SucheAuszahlungBis = {edtSucheAuszahlungBis}

DECLARE @SucheMigriert int 
SET @SucheMigriert = {edtSucheMigriert}

DECLARE @SucheLaufend int 
SET @SucheLaufend = {edtSucheLaufend}

DECLARE @SucheNeu int 
SET @SucheNeu = {edtSucheNeu}

DECLARE @SucheInstitution varchar(50)
SET @SucheInstitution = null
IF {edtSucheInstitution} is not null and {edtSucheInstitution} <> N'''' SET @SucheInstitution = ''%'' + replace({edtSucheInstitution}, '' '', ''%'') + ''%''

DECLARE @SucheKontoNr varchar(50)
SET @SucheKontoNr = null
IF {edtSucheKontoNr} is not null and {edtSucheKontoNr} <> N'''' SET @SucheKontoNr = ''%'' + replace({edtSucheKontoNr}, '' '', ''%'') + ''%''

DECLARE @SucheStrasse varchar(50)
SET @SucheStrasse = null
IF {edtSucheStrasse} is not null and {edtSucheStrasse} <> N'''' SET @SucheStrasse = ''%'' + replace({edtSucheStrasse}, '' '', ''%'') + ''%''

DECLARE @SucheHausNr varchar(50)
SET @SucheHausNr = null
IF {edtSucheHausNr} is not null and {edtSucheHausNr} <> N'''' SET @SucheHausNr  = ''%'' + replace({edtSucheHausNr}, '' '', ''%'') + ''%''

DECLARE @SuchePLZ varchar(50)
SET @SuchePLZ = null
IF {edtSuchePLZ} is not null and {edtSuchePLZ} <> N'''' SET @SuchePLZ = ''%'' + replace({edtSuchePLZ}, '' '', ''%'') + ''%''

DECLARE @SucheOrt varchar(50)
SET @SucheOrt = null
IF {edtSucheOrt} is not null and {edtSucheOrt} <> N'''' SET @SucheOrt = ''%'' + replace({edtSucheOrt}, '' '', ''%'') + ''%''

DECLARE @SucheFaFallID int 
SET @SucheFaFallID = {edtSucheFaFallID}

DECLARE @SucheAltePNr varchar(50)
SET @SucheAltePNr  = null
IF {edtSucheAltePNr} is not null and {edtSucheAltePNr} <> N'''' SET @SucheAltePNr  = ''%'' + replace({edtSucheAltePNr}, '' '', ''%'') + ''%''

-- Zwischentabellen
DECLARE @IDs TABLE
(
  BaSicherheitsleistungID int
)

INSERT INTO @IDs
SELECT SIC.BaSicherheitsleistungID
FROM dbo.BaSicherheitsleistung SIC WITH(READUNCOMMITTED)
  LEFT JOIN dbo.FaLeistung     LEI WITH(READUNCOMMITTED) ON LEI.BaPersonID = SIC.BaPersonID 
                                                                       AND LEI.FaProzessCode = 300 
                                                                       AND LEI.FaLeistungID = (SELECT TOP 1 FaLeistungID
                                                                                               FROM  FaLeistung
                                                                                               WHERE BaPersonID = SIC.BaPersonID 
                                                                                                 AND FaProzessCode = 300
                                                                                               ORDER BY DatumVon DESC)
  LEFT JOIN dbo.vwPerson       PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = SIC.BaPersonID
  LEFT JOIN dbo.vwInstitution  INS WITH(READUNCOMMITTED) ON INS.BaInstitutionID = SIC.BaInstitutionID
  LEFT JOIN dbo.BaBank         BNK WITH(READUNCOMMITTED) ON BNK.BaBankID = SIC.BaBankID
WHERE 1 = 1 
  AND (@SucheArt is null           OR SIC.BaMieteSicherheitsleistungArtCode = @SucheArt)
  AND (@SucheBaPersonID is null    OR SIC.BaPersonID = @SucheBaPersonID)
  AND (@SucheKlient is null        OR PRS.NameVorname LIKE @SucheKlient)
  AND (@SucheAuszahlungVon is null OR SIC.AuszahlungAm >= @SucheAuszahlungVon)
  AND (@SucheAuszahlungBis is null OR SIC.AuszahlungAm <= @SucheAuszahlungBis)
  AND ((@SucheMigriert = 1 and SIC.MigDarlehenID is not null) OR
       (@SucheLaufend = 1  and SIC.MigDarlehenID is null and SIC.neu = 0) OR
       (@SucheNeu = 1      and SIC.neu = 1))
  AND (@SucheInstitution is null   OR INS.InstitutionName like @SucheInstitution)
  AND (@SucheKontoNr is null       OR SIC.KontoNummer like @SucheKontoNr)
  AND (@SucheStrasse is null       OR SIC.ObjektStrasse like @SucheStrasse)
  AND (@SucheHausNr is null        OR SIC.ObjektHausNr = @SucheHausNr)
  AND (@SuchePLZ is null           OR SIC.ObjektPLZ = @SuchePLZ)
  AND (@SucheOrt is null           OR SIC.ObjektOrt like @SucheOrt)
  AND (@SucheAltePNr is null       OR SIC.BaPersonID in (select distinct BaPersonID from BaAlteFallNr where PersonNrAlt = @SucheAltePNr))
  AND (@SucheFaFallID is null      OR LEI.FaFallID = @SucheFaFallID)

DECLARE @tmpBuchungen TABLE
(
  BaSicherheitsleistungID           int,
  BuchungsDatum                     datetime,
  BelegNr                           varchar(20),
  LA                                varchar(10),
  Buchungstext                      varchar(200),
  Betrag                            money,
  Tool                              char(1),
  BelegNrnBrutto                    varchar(200)
)

-- Migrierte Buchungen
INSERT INTO @tmpBuchungen
SELECT SIC.BaSicherheitsleistungID, MIG.BuchungsDatum, MIG.Nummernkreis + ''-'' + CAST(MIG.BelegNummer as varchar) + ''-'' + CAST(MIG.PositionsNummer as varchar), BKA.KontoNr, BKA.Name, MIG.Betrag, ''P'', NULL
FROM dbo.BaSicherheitsleistung                 SIC WITH (READUNCOMMITTED)
  INNER JOIN dbo.BaSicherheitsleistungPosition SIP WITH (READUNCOMMITTED) ON SIC.BaSicherheitsleistungID = SIP.BaSicherheitsleistungID
  INNER JOIN dbo.MigDetailBuchung              MIG WITH (READUNCOMMITTED) ON MIG.MigDetailBuchungID      = SIP.MigDetailBuchungID
  INNER JOIN dbo.BgKostenart                   BKA WITH (READUNCOMMITTED) ON BKA.KontoNr                 = MIG.KissLeistungsart
  INNER JOIN @SelektierteLeistungsarten        SEL                        ON SEL.BgKostenartID           = BKA.BgKostenartID
WHERE SIC.Geloescht = 0 
  AND SIP.BaSicherheitsleistungID IN (SELECT BaSicherheitsleistungID FROM @IDs) 

--Nettobuchungen
INSERT INTO @tmpBuchungen
SELECT SIC.BaSicherheitsleistungID, KBU.ValutaDatum, KBU.BelegNr, BKA.KontoNr, KBK.Buchungstext, KBK.Betrag, ''K'', BRU.BelegNrn
FROM dbo.BaSicherheitsleistung                 SIC WITH (READUNCOMMITTED)
  INNER JOIN dbo.BaSicherheitsleistungPosition SIP WITH (READUNCOMMITTED) ON SIC.BaSicherheitsleistungID = SIP.BaSicherheitsleistungID
  INNER JOIN dbo.KbBuchung                     KBU WITH (READUNCOMMITTED) ON KBU.KbBuchungID             = SIP.KbBuchungID
  INNER JOIN dbo.KbBuchungKostenart            KBK WITH (READUNCOMMITTED) ON KBK.KbBuchungID             = KBU.KbBuchungID
  INNER JOIN dbo.BgKostenart                   BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID           = KBK.BgKostenartID
  INNER JOIN @SelektierteLeistungsarten        SEL                        ON SEL.BgKostenartID           = BKA.BgKostenartID
  INNER JOIN (SELECT KBP.BgPositionID, BelegNrn = dbo.ConcDistinct(KBB.BelegNr)
              FROM dbo.KbBuchungBruttoPerson   KBP WITH (READUNCOMMITTED)
                INNER JOIN dbo.KbBuchungBrutto KBB WITH (READUNCOMMITTED) ON KBB.KbBuchungBruttoID = KBP.KbBuchungBruttoID AND KBB.StorniertKbBuchungbruttoID IS NULL
                INNER JOIN dbo.BgKostenart     BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID     = KBB.BgKostenartID
              GROUP BY KBP.BgPositionID) BRU ON BRU.BgPositionID = KBK.BgPositionID
WHERE SIC.Geloescht = 0 
  AND KBU.KbBuchungStatusCode NOT IN (9) --Rückläufer ausschliessen
  AND SIP.BaSicherheitsleistungID IN (SELECT BaSicherheitsleistungID FROM @IDs)

--Bruttobuchungen inkl. Neubuchungen
INSERT INTO @tmpBuchungen
SELECT BSP.BaSicherheitsleistungID, KBB.ValutaDatum, NULL, BKA.KontoNr, KBP.Buchungstext, -KBP.Betrag, ''K'', KBB.BelegNr
FROM dbo.BaSicherheitsleistungPosition  BSP WITH (READUNCOMMITTED)
  INNER JOIN dbo.BaSicherheitsleistung  SIC WITH (READUNCOMMITTED) ON SIC.BaSicherheitsleistungID = BSP.BaSicherheitsleistungID
  INNER JOIN dbo.KbBuchungBrutto        KBB WITH (READUNCOMMITTED) ON KBB.KbBuchungBruttoID       = BSP.KbBuchungBruttoID AND /*KBB.Betrag >= 0 AND*/ BSP.KbBuchungID IS NULL
  INNER JOIN dbo.KbBuchungBruttoPerson  KBP WITH (READUNCOMMITTED) ON KBP.KbBuchungBruttoID       = KBB.KbBuchungBruttoID
  INNER JOIN dbo.BgKostenart            BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID           = IsNull(KBP.SpezBgKostenartID,KBB.BgKostenartID)
  INNER JOIN @SelektierteLeistungsarten SEL                        ON SEL.BgKostenartID           = BKA.BgKostenartID
WHERE SIC.Geloescht = 0 
  AND BSP.BaSicherheitsleistungID IN (SELECT BaSicherheitsleistungID FROM @IDs) 

--Stornobuchungen
INSERT INTO @tmpBuchungen
SELECT BSL.BaSicherheitsleistungID, KBB.ValutaDatum, NULL, BKA.KontoNr, KBP.Buchungstext, -KBP.Betrag, ''S'', KBB.BelegNr
FROM BaSicherheitsleistung              BSL WITH (READUNCOMMITTED)
  INNER JOIN (SELECT DISTINCT BSP.BaSicherheitsleistungID, KbBuchungBruttoID = ISNULL(BSP.KbBuchungBruttoID,ORP.KbBuchungBruttoID)
              FROM BaSicherheitsleistungPosition BSP WITH (READUNCOMMITTED)
                LEFT JOIN KbBuchungKostenart     KBK WITH (READUNCOMMITTED) ON BSP.KbBuchungID  = KBK.KbBuchungID
                LEFT JOIN KbBuchungBruttoPerson  ORP WITH (READUNCOMMITTED) ON KBK.BgPositionID = ORP.BgPositionID) S2B ON S2B.BaSicherheitsleistungID = BSL.BaSicherheitsleistungID
  INNER JOIN KbBuchungBrutto            ORB WITH (READUNCOMMITTED) ON ORB.KbBuchungBruttoID = S2B.KbBuchungBruttoID
  INNER JOIN KbBuchungBrutto            KBB WITH (READUNCOMMITTED) ON ORB.KbBuchungBruttoID = KBB.StorniertKbBuchungBruttoID
  INNER JOIN KbBuchungBruttoPerson      KBP WITH (READUNCOMMITTED) ON KBP.KbBuchungBruttoID = KBB.KbBuchungBruttoID
  INNER JOIN BgKostenart                BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID     = IsNull(KBB.BgKostenartID,KBP.SpezBgKostenartID)              
  INNER JOIN @SelektierteLeistungsarten SEL                        ON SEL.BgKostenartID     = BKA.BgKostenartID
WHERE BSL.Geloescht = 0 
  AND BSL.BaSicherheitsleistungID IN (SELECT BaSicherheitsleistungID FROM @IDs) 
  AND KBB.StorniertKbBuchungBruttoID IS NOT NULL -- OR KBB.NeubuchungVonKbBuchungBruttoID IS NOT NULL)


--Umbuchungen Altdaten
INSERT INTO @tmpBuchungen
SELECT BSP.BaSicherheitsleistungID, KBB.ValutaDatum/*MIG.BuchungsDatum*/, NULL, BKA.KontoNr, KBP.Buchungstext, -KBP.Betrag, ''K'', KBB.BelegNr
FROM BaSicherheitsleistungPosition      BSP
  INNER JOIN dbo.BaSicherheitsleistung  SIC WITH (READUNCOMMITTED) ON SIC.BaSicherheitsleistungID = BSP.BaSicherheitsleistungID
  INNER JOIN dbo.MigDetailBuchung       MIG WITH (READUNCOMMITTED) ON MIG.MigDetailBuchungID      = BSP.MigDetailBuchungID
  INNER JOIN dbo.KbBuchungBrutto        KBB WITH (READUNCOMMITTED) ON BSP.MigDetailbuchungID      = KBB.MigDetailbuchungID
  INNER JOIN dbo.KbBuchungBruttoPerson  KBP WITH (READUNCOMMITTED) ON KBP.KbBuchungBruttoID       = KBB.KbBuchungBruttoID
  INNER JOIN dbo.BgKostenart            BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID           = KBB.BgKostenartID
  INNER JOIN @SelektierteLeistungsarten SEL                        ON SEL.BgKostenartID           = BKA.BgKostenartID
WHERE SIC.Geloescht = 0 
  AND SIC.BaSicherheitsleistungID IN (SELECT BaSicherheitsleistungID FROM @IDs) 
  AND KBB.Belegart = ''UB'' -- Nur die Stornobuchung, nicht die Neubuchung


--Aufbereitung
SELECT Stichtag  = CONVERT(VARCHAR, @DatumVon, 104)  + '' bis '' +  CONVERT(VARCHAR, @DatumBis, 104),
       Art        = @SucheArt,
       Ebene2Text = @TextEbene2,
       SLA.ShortText, SIC.BaPersonID, PRS.NameVorname, BUC.BuchungsDatum, BUC.BelegNr, BUC.LA, BUC.Buchungstext, BUC.Betrag, BUC.Tool, BUC.BelegNrnBrutto,
       Typ = CASE 
               WHEN SIC.MigDarlehenID IS NOT NULL THEN ''alt''
               WHEN neu = 1 then ''neu''
               ELSE ''lauf.''
             END
FROM @tmpBuchungen                     BUC
  INNER JOIN dbo.BaSicherheitsleistung SIC WITH(READUNCOMMITTED) ON SIC.BaSicherheitsleistungID = BUC.BaSicherheitsleistungID
  INNER JOIN dbo.XLOVCode              SLA WITH(READUNCOMMITTED) ON SLA.LOVName = ''BaMieteSicherheitsleistungArt'' AND SLA.Code = SIC.BaMieteSicherheitsleistungArtCode
  INNER JOIN dbo.vwPerson              PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = SIC.BaPersonID
WHERE BUC.BuchungsDatum BETWEEN @DatumVon AND @DatumBis
ORDER BY BUC.BuchungsDatum' , ContextForms =  N'FrmBaSicherheitsleistung' , ParentReportName =  null , ReportSortKey = 1 
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'BaSiLeiEinAuszahlungen' ;


