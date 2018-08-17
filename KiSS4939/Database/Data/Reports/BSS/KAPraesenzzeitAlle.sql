-- Insert Script for KAPraesenzzeitAlle
-- MD5:0X989158FB8FBF471E3BE6CD8DC8645C38_0X10FF341E34BA3D8FD636B4215AF2E320_0X047BD7C8246584350CA84EE7B47E7504
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'KAPraesenzzeitAlle') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('KAPraesenzzeitAlle', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'KAPraesenzzeitAlle';
--SQLCHECK_IGNORE--
UPDATE QRY
SET QueryName =  N'KAPraesenzzeitAlle' , UserText =  N'KA - Präsenzzeit' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS40\KiSS\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS\Build\Debug\Kiss.Interfaces.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS\Build\Debug\Microsoft.Practices.Unity.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS\Build\Debug\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS\Build\Debug\FluentValidation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS\Build\Debug\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS\Build\Debug\log4net.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Projects\KiSS40\KiSS\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell27;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell29;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell30;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell31;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell32;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell33;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell34;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell35;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell36;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell37;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell38;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell39;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell69;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell72;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell63;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell75;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell66;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell78;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell48;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell45;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell81;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell42;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell54;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell51;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell57;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell84;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell90;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell93;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell60;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell87;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell96;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell108;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell102;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell105;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell111;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell120;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell114;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell123;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell117;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell99;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell cV01;
        private DevExpress.XtraReports.UI.XRTableCell cV02;
        private DevExpress.XtraReports.UI.XRTableCell cV03;
        private DevExpress.XtraReports.UI.XRTableCell cV04;
        private DevExpress.XtraReports.UI.XRTableCell cV05;
        private DevExpress.XtraReports.UI.XRTableCell cV06;
        private DevExpress.XtraReports.UI.XRTableCell cV07;
        private DevExpress.XtraReports.UI.XRTableCell cV08;
        private DevExpress.XtraReports.UI.XRTableCell cV09;
        private DevExpress.XtraReports.UI.XRTableCell cV10;
        private DevExpress.XtraReports.UI.XRTableCell cV11;
        private DevExpress.XtraReports.UI.XRTableCell cV12;
        private DevExpress.XtraReports.UI.XRTableCell cV13;
        private DevExpress.XtraReports.UI.XRTableCell cV14;
        private DevExpress.XtraReports.UI.XRTableCell cV15;
        private DevExpress.XtraReports.UI.XRTableCell cV16;
        private DevExpress.XtraReports.UI.XRTableCell cV17;
        private DevExpress.XtraReports.UI.XRTableCell cV18;
        private DevExpress.XtraReports.UI.XRTableCell cV19;
        private DevExpress.XtraReports.UI.XRTableCell cV20;
        private DevExpress.XtraReports.UI.XRTableCell cV21;
        private DevExpress.XtraReports.UI.XRTableCell cV22;
        private DevExpress.XtraReports.UI.XRTableCell cV23;
        private DevExpress.XtraReports.UI.XRTableCell cV24;
        private DevExpress.XtraReports.UI.XRTableCell cV25;
        private DevExpress.XtraReports.UI.XRTableCell cV26;
        private DevExpress.XtraReports.UI.XRTableCell cV27;
        private DevExpress.XtraReports.UI.XRTableCell cV28;
        private DevExpress.XtraReports.UI.XRTableCell cV29;
        private DevExpress.XtraReports.UI.XRTableCell cV30;
        private DevExpress.XtraReports.UI.XRTableCell cV31;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell109;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell103;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell106;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell112;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell121;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell115;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell124;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell118;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell100;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell28;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell15;
        private DevExpress.XtraReports.UI.XRTableCell cN01;
        private DevExpress.XtraReports.UI.XRTableCell cN02;
        private DevExpress.XtraReports.UI.XRTableCell cN03;
        private DevExpress.XtraReports.UI.XRTableCell cN04;
        private DevExpress.XtraReports.UI.XRTableCell cN05;
        private DevExpress.XtraReports.UI.XRTableCell cN06;
        private DevExpress.XtraReports.UI.XRTableCell cN07;
        private DevExpress.XtraReports.UI.XRTableCell cN08;
        private DevExpress.XtraReports.UI.XRTableCell cN09;
        private DevExpress.XtraReports.UI.XRTableCell cN10;
        private DevExpress.XtraReports.UI.XRTableCell cN11;
        private DevExpress.XtraReports.UI.XRTableCell cN12;
        private DevExpress.XtraReports.UI.XRTableCell cN13;
        private DevExpress.XtraReports.UI.XRTableCell cN14;
        private DevExpress.XtraReports.UI.XRTableCell cN15;
        private DevExpress.XtraReports.UI.XRTableCell cN16;
        private DevExpress.XtraReports.UI.XRTableCell cN17;
        private DevExpress.XtraReports.UI.XRTableCell cN18;
        private DevExpress.XtraReports.UI.XRTableCell cN19;
        private DevExpress.XtraReports.UI.XRTableCell cN20;
        private DevExpress.XtraReports.UI.XRTableCell cN21;
        private DevExpress.XtraReports.UI.XRTableCell cN22;
        private DevExpress.XtraReports.UI.XRTableCell cN23;
        private DevExpress.XtraReports.UI.XRTableCell cN24;
        private DevExpress.XtraReports.UI.XRTableCell cN25;
        private DevExpress.XtraReports.UI.XRTableCell cN26;
        private DevExpress.XtraReports.UI.XRTableCell cN27;
        private DevExpress.XtraReports.UI.XRTableCell cN28;
        private DevExpress.XtraReports.UI.XRTableCell cN29;
        private DevExpress.XtraReports.UI.XRTableCell cN30;
        private DevExpress.XtraReports.UI.XRTableCell cN31;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell110;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell104;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell107;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell113;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell122;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell116;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell125;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell119;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell101;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAACAAAAAAAAAFBBRFBBRFATtE6ko" +
                        "aGH4D0AAAAAAAAAOAEAADhEAGUAdABhAGkAbAAuAFMAYwByAGkAcAB0AHMALgBPAG4AQgBlAGYAbwByA" +
                        "GUAUAByAGkAbgB0AAAAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAb" +
                        "QBlAG4AdACLFgAAAYgtcHJpdmF0ZSB2b2lkIE9uQmVmb3JlUHJpbnQob2JqZWN0IHNlbmRlciwgU3lzd" +
                        "GVtLkRyYXdpbmcuUHJpbnRpbmcuUHJpbnRFdmVudEFyZ3MgZSkgew0KDQogIGludD8gdmFsID0gKGlud" +
                        "D8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjAxIik7DQogIGNWMDEuQmFja0NvbG9yID0gKHZhb" +
                        "CA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gMykgPyBDb2xvci5HcmF5IDogQ29sb3IuV" +
                        "HJhbnNwYXJlbnQ7DQogIGNOMDEuQmFja0NvbG9yID0gY1YwMS5CYWNrQ29sb3I7DQoNCiAgdmFsID0gK" +
                        "GludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjAyIik7DQogIGNWMDIuQmFja0NvbG9yID0gK" +
                        "HZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gMykgPyBDb2xvci5HcmF5IDogQ29sb" +
                        "3IuVHJhbnNwYXJlbnQ7DQogIGNOMDIuQmFja0NvbG9yID0gY1YwMi5CYWNrQ29sb3I7DQoNCiAgdmFsI" +
                        "D0gKGludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjAzIik7DQogIGNWMDMuQmFja0NvbG9yI" +
                        "D0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gMykgPyBDb2xvci5HcmF5IDogQ" +
                        "29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMDMuQmFja0NvbG9yID0gY1YwMy5CYWNrQ29sb3I7DQoNCiAgd" +
                        "mFsID0gKGludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjA0Iik7DQogIGNWMDQuQmFja0Nvb" +
                        "G9yID0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gMykgPyBDb2xvci5HcmF5I" +
                        "DogQ29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMDQuQmFja0NvbG9yID0gY1YwNC5CYWNrQ29sb3I7DQoNC" +
                        "iAgdmFsID0gKGludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjA1Iik7DQogIGNWMDUuQmFja" +
                        "0NvbG9yID0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gMykgPyBDb2xvci5Hc" +
                        "mF5IDogQ29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMDUuQmFja0NvbG9yID0gY1YwNS5CYWNrQ29sb3I7D" +
                        "QoNCiAgdmFsID0gKGludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjA2Iik7DQogIGNWMDYuQ" +
                        "mFja0NvbG9yID0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gMykgPyBDb2xvc" +
                        "i5HcmF5IDogQ29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMDYuQmFja0NvbG9yID0gY1YwNi5CYWNrQ29sb" +
                        "3I7DQoNCiAgdmFsID0gKGludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjA3Iik7DQogIGNWM" +
                        "DcuQmFja0NvbG9yID0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gMykgPyBDb" +
                        "2xvci5HcmF5IDogQ29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMDcuQmFja0NvbG9yID0gY1YwNy5CYWNrQ" +
                        "29sb3I7DQoNCiAgdmFsID0gKGludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjA4Iik7DQogI" +
                        "GNWMDguQmFja0NvbG9yID0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gMykgP" +
                        "yBDb2xvci5HcmF5IDogQ29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMDguQmFja0NvbG9yID0gY1YwOC5CY" +
                        "WNrQ29sb3I7DQoNCiAgdmFsID0gKGludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjA5Iik7D" +
                        "QogIGNWMDkuQmFja0NvbG9yID0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gM" +
                        "ykgPyBDb2xvci5HcmF5IDogQ29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMDkuQmFja0NvbG9yID0gY1YwO" +
                        "S5CYWNrQ29sb3I7DQoNCiAgdmFsID0gKGludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjEwI" +
                        "ik7DQogIGNWMTAuQmFja0NvbG9yID0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgP" +
                        "T0gMykgPyBDb2xvci5HcmF5IDogQ29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMTAuQmFja0NvbG9yID0gY" +
                        "1YxMC5CYWNrQ29sb3I7DQoNCiAgdmFsID0gKGludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvc" +
                        "jExIik7DQogIGNWMTEuQmFja0NvbG9yID0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2Y" +
                        "WwgPT0gMykgPyBDb2xvci5HcmF5IDogQ29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMTEuQmFja0NvbG9yI" +
                        "D0gY1YxMS5CYWNrQ29sb3I7DQoNCiAgdmFsID0gKGludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb" +
                        "2xvcjEyIik7DQogIGNWMTIuQmFja0NvbG9yID0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6I" +
                        "Ch2YWwgPT0gMykgPyBDb2xvci5HcmF5IDogQ29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMTIuQmFja0Nvb" +
                        "G9yID0gY1YxMi5CYWNrQ29sb3I7DQoNCiAgdmFsID0gKGludD8pR2V0Q3VycmVudENvbHVtblZhbHVlK" +
                        "CJDb2xvcjEzIik7DQogIGNWMTMuQmFja0NvbG9yID0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3Jhe" +
                        "SA6ICh2YWwgPT0gMykgPyBDb2xvci5HcmF5IDogQ29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMTMuQmFja" +
                        "0NvbG9yID0gY1YxMy5CYWNrQ29sb3I7DQoNCiAgdmFsID0gKGludD8pR2V0Q3VycmVudENvbHVtblZhb" +
                        "HVlKCJDb2xvcjE0Iik7DQogIGNWMTQuQmFja0NvbG9yID0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R" +
                        "3JheSA6ICh2YWwgPT0gMykgPyBDb2xvci5HcmF5IDogQ29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMTQuQ" +
                        "mFja0NvbG9yID0gY1YxNC5CYWNrQ29sb3I7DQoNCiAgdmFsID0gKGludD8pR2V0Q3VycmVudENvbHVtb" +
                        "lZhbHVlKCJDb2xvcjE1Iik7DQogIGNWMTUuQmFja0NvbG9yID0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ" +
                        "2h0R3JheSA6ICh2YWwgPT0gMykgPyBDb2xvci5HcmF5IDogQ29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOM" +
                        "TUuQmFja0NvbG9yID0gY1YxNS5CYWNrQ29sb3I7DQoNCiAgdmFsID0gKGludD8pR2V0Q3VycmVudENvb" +
                        "HVtblZhbHVlKCJDb2xvcjE2Iik7DQogIGNWMTYuQmFja0NvbG9yID0gKHZhbCA9PSAwKSA/IENvbG9yL" +
                        "kxpZ2h0R3JheSA6ICh2YWwgPT0gMykgPyBDb2xvci5HcmF5IDogQ29sb3IuVHJhbnNwYXJlbnQ7DQogI" +
                        "GNOMTYuQmFja0NvbG9yID0gY1YxNi5CYWNrQ29sb3I7DQoNCiAgdmFsID0gKGludD8pR2V0Q3VycmVud" +
                        "ENvbHVtblZhbHVlKCJDb2xvcjE3Iik7DQogIGNWMTcuQmFja0NvbG9yID0gKHZhbCA9PSAwKSA/IENvb" +
                        "G9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gMykgPyBDb2xvci5HcmF5IDogQ29sb3IuVHJhbnNwYXJlbnQ7D" +
                        "QogIGNOMTcuQmFja0NvbG9yID0gY1YxNy5CYWNrQ29sb3I7DQoNCiAgdmFsID0gKGludD8pR2V0Q3Vyc" +
                        "mVudENvbHVtblZhbHVlKCJDb2xvcjE4Iik7DQogIGNWMTguQmFja0NvbG9yID0gKHZhbCA9PSAwKSA/I" +
                        "ENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gMykgPyBDb2xvci5HcmF5IDogQ29sb3IuVHJhbnNwYXJlb" +
                        "nQ7DQogIGNOMTguQmFja0NvbG9yID0gY1YxOC5CYWNrQ29sb3I7DQoNCiAgdmFsID0gKGludD8pR2V0Q" +
                        "3VycmVudENvbHVtblZhbHVlKCJDb2xvcjE5Iik7DQogIGNWMTkuQmFja0NvbG9yID0gKHZhbCA9PSAwK" +
                        "SA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gMykgPyBDb2xvci5HcmF5IDogQ29sb3IuVHJhbnNwY" +
                        "XJlbnQ7DQogIGNOMTkuQmFja0NvbG9yID0gY1YxOS5CYWNrQ29sb3I7DQoNCiAgdmFsID0gKGludD8pR" +
                        "2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjIwIik7DQogIGNWMjAuQmFja0NvbG9yID0gKHZhbCA9P" +
                        "SAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gMykgPyBDb2xvci5HcmF5IDogQ29sb3IuVHJhb" +
                        "nNwYXJlbnQ7DQogIGNOMjAuQmFja0NvbG9yID0gY1YyMC5CYWNrQ29sb3I7DQoNCiAgdmFsID0gKGlud" +
                        "D8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjIxIik7DQogIGNWMjEuQmFja0NvbG9yID0gKHZhb" +
                        "CA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gMykgPyBDb2xvci5HcmF5IDogQ29sb3IuV" +
                        "HJhbnNwYXJlbnQ7DQogIGNOMjEuQmFja0NvbG9yID0gY1YyMS5CYWNrQ29sb3I7DQoNCiAgdmFsID0gK" +
                        "GludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjIyIik7DQogIGNWMjIuQmFja0NvbG9yID0gK" +
                        "HZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gMykgPyBDb2xvci5HcmF5IDogQ29sb" +
                        "3IuVHJhbnNwYXJlbnQ7DQogIGNOMjIuQmFja0NvbG9yID0gY1YyMi5CYWNrQ29sb3I7DQoNCiAgdmFsI" +
                        "D0gKGludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjIzIik7DQogIGNWMjMuQmFja0NvbG9yI" +
                        "D0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gMykgPyBDb2xvci5HcmF5IDogQ" +
                        "29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMjMuQmFja0NvbG9yID0gY1YyMy5CYWNrQ29sb3I7DQoNCiAgd" +
                        "mFsID0gKGludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjI0Iik7DQogIGNWMjQuQmFja0Nvb" +
                        "G9yID0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gMykgPyBDb2xvci5HcmF5I" +
                        "DogQ29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMjQuQmFja0NvbG9yID0gY1YyNC5CYWNrQ29sb3I7DQoNC" +
                        "iAgdmFsID0gKGludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjI1Iik7DQogIGNWMjUuQmFja" +
                        "0NvbG9yID0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gMykgPyBDb2xvci5Hc" +
                        "mF5IDogQ29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMjUuQmFja0NvbG9yID0gY1YyNS5CYWNrQ29sb3I7D" +
                        "QoNCiAgdmFsID0gKGludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjI2Iik7DQogIGNWMjYuQ" +
                        "mFja0NvbG9yID0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gMykgPyBDb2xvc" +
                        "i5HcmF5IDogQ29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMjYuQmFja0NvbG9yID0gY1YyNi5CYWNrQ29sb" +
                        "3I7DQoNCiAgdmFsID0gKGludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjI3Iik7DQogIGNWM" +
                        "jcuQmFja0NvbG9yID0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gMykgPyBDb" +
                        "2xvci5HcmF5IDogQ29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMjcuQmFja0NvbG9yID0gY1YyNy5CYWNrQ" +
                        "29sb3I7DQoNCiAgdmFsID0gKGludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjI4Iik7DQogI" +
                        "GNWMjguQmFja0NvbG9yID0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gMykgP" +
                        "yBDb2xvci5HcmF5IDogQ29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMjguQmFja0NvbG9yID0gY1YyOC5CY" +
                        "WNrQ29sb3I7DQoNCiAgdmFsID0gKGludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjI5Iik7D" +
                        "QogIGNWMjkuQmFja0NvbG9yID0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgPT0gM" +
                        "ykgPyBDb2xvci5HcmF5IDogQ29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMjkuQmFja0NvbG9yID0gY1YyO" +
                        "S5CYWNrQ29sb3I7DQoNCiAgdmFsID0gKGludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvcjMwI" +
                        "ik7DQogIGNWMzAuQmFja0NvbG9yID0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2YWwgP" +
                        "T0gMykgPyBDb2xvci5HcmF5IDogQ29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMzAuQmFja0NvbG9yID0gY" +
                        "1YzMC5CYWNrQ29sb3I7DQoNCiAgdmFsID0gKGludD8pR2V0Q3VycmVudENvbHVtblZhbHVlKCJDb2xvc" +
                        "jMxIik7DQogIGNWMzEuQmFja0NvbG9yID0gKHZhbCA9PSAwKSA/IENvbG9yLkxpZ2h0R3JheSA6ICh2Y" +
                        "WwgPT0gMykgPyBDb2xvci5HcmF5IDogQ29sb3IuVHJhbnNwYXJlbnQ7DQogIGNOMzEuQmFja0NvbG9yI" +
                        "D0gY1YzMS5CYWNrQ29sb3I7DQoNCn0BjAlkZWNsYXJlIEBVc2VyS0EgaW50DQpkZWNsYXJlIEBNb25hd" +
                        "CBpbnQNCmRlY2xhcmUgQEphaHIgaW50DQpkZWNsYXJlIEBLbGllbnRJRCBpbnQNCmRlY2xhcmUgQEFQV" +
                        "k5yIGludA0KZGVjbGFyZSBAWnVzYXR6IGludA0KZGVjbGFyZSBAQ29hY2hJRCBpbnQNCmRlY2xhcmUgQ" +
                        "EZhY2hiZXJlaWNoSUQgaW50DQpkZWNsYXJlIEBGYWNobGVpdHVuZ0lEIGludA0KZGVjbGFyZSBAS3Vyc" +
                        "0lEIGludA0KDQpTRVQgQFVzZXJLQSA9IElTTlVMTChudWxsLCAwKQ0Kc2V0IEBNb25hdCA9IGNhc2UgS" +
                        "VNOVUxMKG51bGwsIDApIHdoZW4gMCB0aGVuIE1vbnRoKEdldERhdGUoKSkgZWxzZSBpc251bGwobnVsb" +
                        "CwgTW9udGgoR2V0RGF0ZSgpKSkgZW5kDQpzZXQgQEphaHIgPSBjYXNlIElTTlVMTChudWxsLCAwKSB3a" +
                        "GVuIDAgdGhlbiBZZWFyKEdldERhdGUoKSkgZWxzZSBpc251bGwobnVsbCAsIFllYXIoR2V0RGF0ZSgpK" +
                        "SkgZW5kDQoNCklGIG51bGwgPSAwIEJFR0lOIFNFVCBAS2xpZW50SUQgPSBOVUxMIEVORCBFTFNFIEJFR" +
                        "0lOIFNFVCBAS2xpZW50SUQgPSBudWxsIEVORA0KSUYgbnVsbCA9IDAgQkVHSU4gU0VUIEBBUFZOciA9I" +
                        "E5VTEwgRU5EIEVMU0UgQkVHSU4gU0VUIEBBUFZOciA9IG51bGwgRU5EDQpJRiBudWxsID0gMCBCRUdJT" +
                        "iBTRVQgQFp1c2F0eiA9IE5VTEwgRU5EIEVMU0UgQkVHSU4gU0VUIEBadXNhdHogPSBudWxsIEVORA0KS" +
                        "UYgbnVsbCA9IDAgQkVHSU4gU0VUIEBDb2FjaElEID0gTlVMTCBFTkQgRUxTRSBCRUdJTiBTRVQgQENvY" +
                        "WNoSUQgPSBudWxsIEVORA0KSUYgbnVsbCA9IDAgQkVHSU4gU0VUIEBGYWNoYmVyZWljaElEID0gTlVMT" +
                        "CBFTkQgRUxTRSBCRUdJTiBTRVQgQEZhY2hiZXJlaWNoSUQgPSBudWxsIEVORA0KSUYgbnVsbCA9IDAgQ" +
                        "kVHSU4gU0VUIEBGYWNobGVpdHVuZ0lEID0gTlVMTCBFTkQgRUxTRSBCRUdJTiBTRVQgQEZhY2hsZWl0d" +
                        "W5nSUQgPSBudWxsIEVORA0KSUYgbnVsbCA9IDAgQkVHSU4gU0VUIEBLdXJzSUQgPSBOVUxMIEVORCBFT" +
                        "FNFIEJFR0lOIFNFVCBAS3Vyc0lEID0gbnVsbCBFTkQNCg0KDQpleGVjIHNwS2FHZXRQcmFlc2Vuenpla" +
                        "XRSZXBvcnQgQFVzZXJLQSwgQE1vbmF0LCBASmFociwgQEtsaWVudElELCBAQVBWTnIsIEBadXNhdHosI" +
                        "EBDb2FjaElELCBARmFjaGJlcmVpY2hJRCwgQEZhY2hsZWl0dW5nSUQsIEBLdXJzSUQAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell69 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell72 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell63 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell75 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell78 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell81 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell54 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell57 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell84 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell90 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell93 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell60 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell87 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell96 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell108 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell102 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell105 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell111 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell120 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell114 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell123 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell117 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell99 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV01 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV02 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV03 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV04 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV05 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV06 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV07 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV08 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV09 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cV31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell109 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell103 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell106 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell112 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell121 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell115 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell124 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell118 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell100 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN01 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN02 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN03 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN04 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN05 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN06 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN07 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN08 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN09 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.cN31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell110 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell104 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell107 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell113 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell122 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell116 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell125 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell119 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell101 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel3,
                        this.xrLabel1});
            this.PageHeader.Font = new System.Drawing.Font("Arial", 9.75F);
            this.PageHeader.Height = 58;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.ParentStyleUsing.UseFont = false;
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrTable1});
            this.Detail.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Detail.Height = 83;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.Scripts.OnBeforePrint = resources.GetString("Detail.Scripts.OnBeforePrint");
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageInfo2,
                        this.xrLine1,
                        this.xrPageInfo1});
            this.PageFooter.Font = new System.Drawing.Font("Arial", 9.75F);
            this.PageFooter.Height = 42;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseFont = false;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "MonatJahr", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.Location = new System.Drawing.Point(17, 33);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(325, 25);
            this.xrLabel3.Text = "xrLabel3";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.Location = new System.Drawing.Point(17, 8);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(616, 25);
            this.xrLabel1.Text = "Gesamtübersicht Präsenz";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrTable1.KeepTogether = true;
            this.xrTable1.Location = new System.Drawing.Point(17, 8);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.ParentStyleUsing.UseBorders = false;
            this.xrTable1.ParentStyleUsing.UseFont = false;
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow3,
                        this.xrTableRow1,
                        this.xrTableRow2});
            this.xrTable1.Size = new System.Drawing.Size(950, 75);
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell27,
                        this.xrTableCell29,
                        this.xrTableCell30,
                        this.xrTableCell31,
                        this.xrTableCell32,
                        this.xrTableCell33,
                        this.xrTableCell34,
                        this.xrTableCell35,
                        this.xrTableCell36,
                        this.xrTableCell37,
                        this.xrTableCell38,
                        this.xrTableCell39,
                        this.xrTableCell69,
                        this.xrTableCell72,
                        this.xrTableCell63,
                        this.xrTableCell75,
                        this.xrTableCell66,
                        this.xrTableCell78,
                        this.xrTableCell14,
                        this.xrTableCell48,
                        this.xrTableCell45,
                        this.xrTableCell81,
                        this.xrTableCell42,
                        this.xrTableCell54,
                        this.xrTableCell51,
                        this.xrTableCell57,
                        this.xrTableCell84,
                        this.xrTableCell90,
                        this.xrTableCell93,
                        this.xrTableCell60,
                        this.xrTableCell87,
                        this.xrTableCell96,
                        this.xrTableCell108,
                        this.xrTableCell102,
                        this.xrTableCell105,
                        this.xrTableCell111,
                        this.xrTableCell120,
                        this.xrTableCell114,
                        this.xrTableCell123,
                        this.xrTableCell117,
                        this.xrTableCell99});
            this.xrTableRow3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.ParentStyleUsing.UseFont = false;
            this.xrTableRow3.Size = new System.Drawing.Size(950, 25);
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell2,
                        this.xrTableCell1,
                        this.cV01,
                        this.cV02,
                        this.cV03,
                        this.cV04,
                        this.cV05,
                        this.cV06,
                        this.cV07,
                        this.cV08,
                        this.cV09,
                        this.cV10,
                        this.cV11,
                        this.cV12,
                        this.cV13,
                        this.cV14,
                        this.cV15,
                        this.cV16,
                        this.cV17,
                        this.cV18,
                        this.cV19,
                        this.cV20,
                        this.cV21,
                        this.cV22,
                        this.cV23,
                        this.cV24,
                        this.cV25,
                        this.cV26,
                        this.cV27,
                        this.cV28,
                        this.cV29,
                        this.cV30,
                        this.cV31,
                        this.xrTableCell109,
                        this.xrTableCell103,
                        this.xrTableCell106,
                        this.xrTableCell112,
                        this.xrTableCell121,
                        this.xrTableCell115,
                        this.xrTableCell124,
                        this.xrTableCell118,
                        this.xrTableCell100});
            this.xrTableRow1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.ParentStyleUsing.UseFont = false;
            this.xrTableRow1.Size = new System.Drawing.Size(950, 25);
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell28,
                        this.xrTableCell15,
                        this.cN01,
                        this.cN02,
                        this.cN03,
                        this.cN04,
                        this.cN05,
                        this.cN06,
                        this.cN07,
                        this.cN08,
                        this.cN09,
                        this.cN10,
                        this.cN11,
                        this.cN12,
                        this.cN13,
                        this.cN14,
                        this.cN15,
                        this.cN16,
                        this.cN17,
                        this.cN18,
                        this.cN19,
                        this.cN20,
                        this.cN21,
                        this.cN22,
                        this.cN23,
                        this.cN24,
                        this.cN25,
                        this.cN26,
                        this.cN27,
                        this.cN28,
                        this.cN29,
                        this.cN30,
                        this.cN31,
                        this.xrTableCell110,
                        this.xrTableCell104,
                        this.xrTableCell107,
                        this.xrTableCell113,
                        this.xrTableCell122,
                        this.xrTableCell116,
                        this.xrTableCell125,
                        this.xrTableCell119,
                        this.xrTableCell101});
            this.xrTableRow2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.ParentStyleUsing.UseFont = false;
            this.xrTableRow2.Size = new System.Drawing.Size(950, 25);
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Klient", "")});
            this.xrTableCell27.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell27.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell27.ParentStyleUsing.UseFont = false;
            this.xrTableCell27.Size = new System.Drawing.Size(125, 25);
            this.xrTableCell27.Text = "xrTableCell27";
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell29.Location = new System.Drawing.Point(125, 0);
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell29.ParentStyleUsing.UseFont = false;
            this.xrTableCell29.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell29.Text = "1";
            this.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell30.Location = new System.Drawing.Point(145, 0);
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell30.ParentStyleUsing.UseFont = false;
            this.xrTableCell30.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell30.Text = "2";
            this.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell31.Location = new System.Drawing.Point(165, 0);
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell31.ParentStyleUsing.UseFont = false;
            this.xrTableCell31.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell31.Text = "3";
            this.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell32.Location = new System.Drawing.Point(185, 0);
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell32.ParentStyleUsing.UseFont = false;
            this.xrTableCell32.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell32.Text = "4";
            this.xrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell33.Location = new System.Drawing.Point(205, 0);
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell33.ParentStyleUsing.UseFont = false;
            this.xrTableCell33.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell33.Text = "5";
            this.xrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell34
            // 
            this.xrTableCell34.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell34.Location = new System.Drawing.Point(225, 0);
            this.xrTableCell34.Name = "xrTableCell34";
            this.xrTableCell34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell34.ParentStyleUsing.UseFont = false;
            this.xrTableCell34.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell34.Text = "6";
            this.xrTableCell34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell35
            // 
            this.xrTableCell35.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell35.Location = new System.Drawing.Point(245, 0);
            this.xrTableCell35.Name = "xrTableCell35";
            this.xrTableCell35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell35.ParentStyleUsing.UseFont = false;
            this.xrTableCell35.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell35.Text = "7";
            this.xrTableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell36.Location = new System.Drawing.Point(265, 0);
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell36.ParentStyleUsing.UseFont = false;
            this.xrTableCell36.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell36.Text = "8";
            this.xrTableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell37
            // 
            this.xrTableCell37.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell37.Location = new System.Drawing.Point(285, 0);
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell37.ParentStyleUsing.UseFont = false;
            this.xrTableCell37.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell37.Text = "9";
            this.xrTableCell37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell38.Location = new System.Drawing.Point(305, 0);
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell38.ParentStyleUsing.UseFont = false;
            this.xrTableCell38.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell38.Text = "10";
            this.xrTableCell38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell39
            // 
            this.xrTableCell39.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell39.Location = new System.Drawing.Point(325, 0);
            this.xrTableCell39.Name = "xrTableCell39";
            this.xrTableCell39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell39.ParentStyleUsing.UseFont = false;
            this.xrTableCell39.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell39.Text = "11";
            this.xrTableCell39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell69
            // 
            this.xrTableCell69.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell69.Location = new System.Drawing.Point(345, 0);
            this.xrTableCell69.Name = "xrTableCell69";
            this.xrTableCell69.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell69.ParentStyleUsing.UseFont = false;
            this.xrTableCell69.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell69.Text = "12";
            this.xrTableCell69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell72
            // 
            this.xrTableCell72.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell72.Location = new System.Drawing.Point(365, 0);
            this.xrTableCell72.Name = "xrTableCell72";
            this.xrTableCell72.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell72.ParentStyleUsing.UseFont = false;
            this.xrTableCell72.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell72.Text = "13";
            this.xrTableCell72.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell63
            // 
            this.xrTableCell63.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell63.Location = new System.Drawing.Point(385, 0);
            this.xrTableCell63.Name = "xrTableCell63";
            this.xrTableCell63.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell63.ParentStyleUsing.UseFont = false;
            this.xrTableCell63.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell63.Text = "14";
            this.xrTableCell63.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell75
            // 
            this.xrTableCell75.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell75.Location = new System.Drawing.Point(405, 0);
            this.xrTableCell75.Name = "xrTableCell75";
            this.xrTableCell75.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell75.ParentStyleUsing.UseFont = false;
            this.xrTableCell75.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell75.Text = "15";
            this.xrTableCell75.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell66
            // 
            this.xrTableCell66.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell66.Location = new System.Drawing.Point(425, 0);
            this.xrTableCell66.Name = "xrTableCell66";
            this.xrTableCell66.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell66.ParentStyleUsing.UseFont = false;
            this.xrTableCell66.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell66.Text = "16";
            this.xrTableCell66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell78
            // 
            this.xrTableCell78.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell78.Location = new System.Drawing.Point(445, 0);
            this.xrTableCell78.Name = "xrTableCell78";
            this.xrTableCell78.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell78.ParentStyleUsing.UseFont = false;
            this.xrTableCell78.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell78.Text = "17";
            this.xrTableCell78.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell14.Location = new System.Drawing.Point(465, 0);
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell14.ParentStyleUsing.UseFont = false;
            this.xrTableCell14.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell14.Text = "18";
            this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell48.Location = new System.Drawing.Point(485, 0);
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell48.ParentStyleUsing.UseFont = false;
            this.xrTableCell48.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell48.Text = "19";
            this.xrTableCell48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell45.Location = new System.Drawing.Point(505, 0);
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell45.ParentStyleUsing.UseFont = false;
            this.xrTableCell45.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell45.Text = "20";
            this.xrTableCell45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell81
            // 
            this.xrTableCell81.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell81.Location = new System.Drawing.Point(525, 0);
            this.xrTableCell81.Name = "xrTableCell81";
            this.xrTableCell81.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell81.ParentStyleUsing.UseFont = false;
            this.xrTableCell81.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell81.Text = "21";
            this.xrTableCell81.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell42.Location = new System.Drawing.Point(545, 0);
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell42.ParentStyleUsing.UseFont = false;
            this.xrTableCell42.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell42.Text = "22";
            this.xrTableCell42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell54
            // 
            this.xrTableCell54.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell54.Location = new System.Drawing.Point(565, 0);
            this.xrTableCell54.Name = "xrTableCell54";
            this.xrTableCell54.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell54.ParentStyleUsing.UseFont = false;
            this.xrTableCell54.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell54.Text = "23";
            this.xrTableCell54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell51
            // 
            this.xrTableCell51.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell51.Location = new System.Drawing.Point(585, 0);
            this.xrTableCell51.Name = "xrTableCell51";
            this.xrTableCell51.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell51.ParentStyleUsing.UseFont = false;
            this.xrTableCell51.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell51.Text = "24";
            this.xrTableCell51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell57
            // 
            this.xrTableCell57.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell57.Location = new System.Drawing.Point(605, 0);
            this.xrTableCell57.Name = "xrTableCell57";
            this.xrTableCell57.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell57.ParentStyleUsing.UseFont = false;
            this.xrTableCell57.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell57.Text = "25";
            this.xrTableCell57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell84
            // 
            this.xrTableCell84.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell84.Location = new System.Drawing.Point(625, 0);
            this.xrTableCell84.Name = "xrTableCell84";
            this.xrTableCell84.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell84.ParentStyleUsing.UseFont = false;
            this.xrTableCell84.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell84.Text = "26";
            this.xrTableCell84.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell90
            // 
            this.xrTableCell90.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell90.Location = new System.Drawing.Point(645, 0);
            this.xrTableCell90.Name = "xrTableCell90";
            this.xrTableCell90.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell90.ParentStyleUsing.UseFont = false;
            this.xrTableCell90.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell90.Text = "27";
            this.xrTableCell90.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell93
            // 
            this.xrTableCell93.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Day28", "")});
            this.xrTableCell93.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell93.Location = new System.Drawing.Point(665, 0);
            this.xrTableCell93.Name = "xrTableCell93";
            this.xrTableCell93.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell93.ParentStyleUsing.UseFont = false;
            this.xrTableCell93.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell93.Text = "xrTableCell93";
            this.xrTableCell93.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell60
            // 
            this.xrTableCell60.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Day29", "")});
            this.xrTableCell60.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell60.Location = new System.Drawing.Point(685, 0);
            this.xrTableCell60.Name = "xrTableCell60";
            this.xrTableCell60.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell60.ParentStyleUsing.UseFont = false;
            this.xrTableCell60.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell60.Text = "xrTableCell60";
            this.xrTableCell60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell87
            // 
            this.xrTableCell87.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Day30", "")});
            this.xrTableCell87.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell87.Location = new System.Drawing.Point(705, 0);
            this.xrTableCell87.Name = "xrTableCell87";
            this.xrTableCell87.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell87.ParentStyleUsing.UseFont = false;
            this.xrTableCell87.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell87.Text = "xrTableCell87";
            this.xrTableCell87.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell96
            // 
            this.xrTableCell96.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Day31", "")});
            this.xrTableCell96.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell96.Location = new System.Drawing.Point(725, 0);
            this.xrTableCell96.Name = "xrTableCell96";
            this.xrTableCell96.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell96.ParentStyleUsing.UseFont = false;
            this.xrTableCell96.Size = new System.Drawing.Size(20, 25);
            this.xrTableCell96.Text = "xrTableCell96";
            this.xrTableCell96.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell108
            // 
            this.xrTableCell108.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell108.Location = new System.Drawing.Point(745, 0);
            this.xrTableCell108.Name = "xrTableCell108";
            this.xrTableCell108.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell108.ParentStyleUsing.UseFont = false;
            this.xrTableCell108.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell108.Text = "A";
            this.xrTableCell108.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell102
            // 
            this.xrTableCell102.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell102.Location = new System.Drawing.Point(770, 0);
            this.xrTableCell102.Name = "xrTableCell102";
            this.xrTableCell102.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell102.ParentStyleUsing.UseFont = false;
            this.xrTableCell102.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell102.Text = "B";
            this.xrTableCell102.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell105
            // 
            this.xrTableCell105.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell105.Location = new System.Drawing.Point(795, 0);
            this.xrTableCell105.Name = "xrTableCell105";
            this.xrTableCell105.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell105.ParentStyleUsing.UseFont = false;
            this.xrTableCell105.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell105.Text = "E";
            this.xrTableCell105.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell111
            // 
            this.xrTableCell111.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell111.Location = new System.Drawing.Point(820, 0);
            this.xrTableCell111.Name = "xrTableCell111";
            this.xrTableCell111.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell111.ParentStyleUsing.UseFont = false;
            this.xrTableCell111.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell111.Text = "F";
            this.xrTableCell111.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell120
            // 
            this.xrTableCell120.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell120.Location = new System.Drawing.Point(845, 0);
            this.xrTableCell120.Name = "xrTableCell120";
            this.xrTableCell120.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell120.ParentStyleUsing.UseFont = false;
            this.xrTableCell120.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell120.Text = "G";
            this.xrTableCell120.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell114
            // 
            this.xrTableCell114.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell114.Location = new System.Drawing.Point(870, 0);
            this.xrTableCell114.Name = "xrTableCell114";
            this.xrTableCell114.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell114.ParentStyleUsing.UseFont = false;
            this.xrTableCell114.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell114.Text = "H";
            this.xrTableCell114.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell123
            // 
            this.xrTableCell123.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell123.Location = new System.Drawing.Point(895, 0);
            this.xrTableCell123.Name = "xrTableCell123";
            this.xrTableCell123.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell123.ParentStyleUsing.UseFont = false;
            this.xrTableCell123.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell123.Text = "I";
            this.xrTableCell123.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell117
            // 
            this.xrTableCell117.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell117.Location = new System.Drawing.Point(920, 0);
            this.xrTableCell117.Name = "xrTableCell117";
            this.xrTableCell117.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell117.ParentStyleUsing.UseFont = false;
            this.xrTableCell117.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell117.Text = "X";
            this.xrTableCell117.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell99
            // 
            this.xrTableCell99.BorderColor = System.Drawing.Color.White;
            this.xrTableCell99.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell99.Location = new System.Drawing.Point(945, 0);
            this.xrTableCell99.Name = "xrTableCell99";
            this.xrTableCell99.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell99.ParentStyleUsing.UseBorderColor = false;
            this.xrTableCell99.ParentStyleUsing.UseFont = false;
            this.xrTableCell99.Size = new System.Drawing.Size(5, 25);
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell2.Size = new System.Drawing.Size(108, 25);
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Font = new System.Drawing.Font("Arial", 9F);
            this.xrTableCell1.Location = new System.Drawing.Point(108, 0);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell1.ParentStyleUsing.UseFont = false;
            this.xrTableCell1.Size = new System.Drawing.Size(17, 25);
            this.xrTableCell1.Text = "V";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV01
            // 
            this.cV01.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V01", "")});
            this.cV01.Font = new System.Drawing.Font("Arial", 8F);
            this.cV01.Location = new System.Drawing.Point(125, 0);
            this.cV01.Name = "cV01";
            this.cV01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV01.ParentStyleUsing.UseFont = false;
            this.cV01.Size = new System.Drawing.Size(20, 25);
            this.cV01.Text = "cV01";
            this.cV01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV02
            // 
            this.cV02.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V02", "")});
            this.cV02.Font = new System.Drawing.Font("Arial", 8F);
            this.cV02.Location = new System.Drawing.Point(145, 0);
            this.cV02.Name = "cV02";
            this.cV02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV02.ParentStyleUsing.UseFont = false;
            this.cV02.Size = new System.Drawing.Size(20, 25);
            this.cV02.Text = "cV02";
            this.cV02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV03
            // 
            this.cV03.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V03", "")});
            this.cV03.Font = new System.Drawing.Font("Arial", 8F);
            this.cV03.Location = new System.Drawing.Point(165, 0);
            this.cV03.Name = "cV03";
            this.cV03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV03.ParentStyleUsing.UseFont = false;
            this.cV03.Size = new System.Drawing.Size(20, 25);
            this.cV03.Text = "cV03";
            this.cV03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV04
            // 
            this.cV04.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V04", "")});
            this.cV04.Font = new System.Drawing.Font("Arial", 8F);
            this.cV04.Location = new System.Drawing.Point(185, 0);
            this.cV04.Name = "cV04";
            this.cV04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV04.ParentStyleUsing.UseFont = false;
            this.cV04.Size = new System.Drawing.Size(20, 25);
            this.cV04.Text = "cV04";
            this.cV04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV05
            // 
            this.cV05.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V05", "")});
            this.cV05.Font = new System.Drawing.Font("Arial", 8F);
            this.cV05.Location = new System.Drawing.Point(205, 0);
            this.cV05.Name = "cV05";
            this.cV05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV05.ParentStyleUsing.UseFont = false;
            this.cV05.Size = new System.Drawing.Size(20, 25);
            this.cV05.Text = "cV05";
            this.cV05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV06
            // 
            this.cV06.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V06", "")});
            this.cV06.Font = new System.Drawing.Font("Arial", 8F);
            this.cV06.Location = new System.Drawing.Point(225, 0);
            this.cV06.Name = "cV06";
            this.cV06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV06.ParentStyleUsing.UseFont = false;
            this.cV06.Size = new System.Drawing.Size(20, 25);
            this.cV06.Text = "cV06";
            this.cV06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV07
            // 
            this.cV07.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V07", "")});
            this.cV07.Font = new System.Drawing.Font("Arial", 8F);
            this.cV07.Location = new System.Drawing.Point(245, 0);
            this.cV07.Name = "cV07";
            this.cV07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV07.ParentStyleUsing.UseFont = false;
            this.cV07.Size = new System.Drawing.Size(20, 25);
            this.cV07.Text = "cV07";
            this.cV07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV08
            // 
            this.cV08.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V08", "")});
            this.cV08.Font = new System.Drawing.Font("Arial", 8F);
            this.cV08.Location = new System.Drawing.Point(265, 0);
            this.cV08.Name = "cV08";
            this.cV08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV08.ParentStyleUsing.UseFont = false;
            this.cV08.Size = new System.Drawing.Size(20, 25);
            this.cV08.Text = "cV08";
            this.cV08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV09
            // 
            this.cV09.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V09", "")});
            this.cV09.Font = new System.Drawing.Font("Arial", 8F);
            this.cV09.Location = new System.Drawing.Point(285, 0);
            this.cV09.Name = "cV09";
            this.cV09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV09.ParentStyleUsing.UseFont = false;
            this.cV09.Size = new System.Drawing.Size(20, 25);
            this.cV09.Text = "cV09";
            this.cV09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV10
            // 
            this.cV10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V10", "")});
            this.cV10.Font = new System.Drawing.Font("Arial", 8F);
            this.cV10.Location = new System.Drawing.Point(305, 0);
            this.cV10.Name = "cV10";
            this.cV10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV10.ParentStyleUsing.UseFont = false;
            this.cV10.Size = new System.Drawing.Size(20, 25);
            this.cV10.Text = "cV10";
            this.cV10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV11
            // 
            this.cV11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V11", "")});
            this.cV11.Font = new System.Drawing.Font("Arial", 8F);
            this.cV11.Location = new System.Drawing.Point(325, 0);
            this.cV11.Name = "cV11";
            this.cV11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV11.ParentStyleUsing.UseFont = false;
            this.cV11.Size = new System.Drawing.Size(20, 25);
            this.cV11.Text = "cV11";
            this.cV11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV12
            // 
            this.cV12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V12", "")});
            this.cV12.Font = new System.Drawing.Font("Arial", 8F);
            this.cV12.Location = new System.Drawing.Point(345, 0);
            this.cV12.Name = "cV12";
            this.cV12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV12.ParentStyleUsing.UseFont = false;
            this.cV12.Size = new System.Drawing.Size(20, 25);
            this.cV12.Text = "cV12";
            this.cV12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV13
            // 
            this.cV13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V13", "")});
            this.cV13.Font = new System.Drawing.Font("Arial", 8F);
            this.cV13.Location = new System.Drawing.Point(365, 0);
            this.cV13.Name = "cV13";
            this.cV13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV13.ParentStyleUsing.UseFont = false;
            this.cV13.Size = new System.Drawing.Size(20, 25);
            this.cV13.Text = "cV13";
            this.cV13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV14
            // 
            this.cV14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V14", "")});
            this.cV14.Font = new System.Drawing.Font("Arial", 8F);
            this.cV14.Location = new System.Drawing.Point(385, 0);
            this.cV14.Name = "cV14";
            this.cV14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV14.ParentStyleUsing.UseFont = false;
            this.cV14.Size = new System.Drawing.Size(20, 25);
            this.cV14.Text = "cV14";
            this.cV14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV15
            // 
            this.cV15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V15", "")});
            this.cV15.Font = new System.Drawing.Font("Arial", 8F);
            this.cV15.Location = new System.Drawing.Point(405, 0);
            this.cV15.Name = "cV15";
            this.cV15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV15.ParentStyleUsing.UseFont = false;
            this.cV15.Size = new System.Drawing.Size(20, 25);
            this.cV15.Text = "cV15";
            this.cV15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV16
            // 
            this.cV16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V16", "")});
            this.cV16.Font = new System.Drawing.Font("Arial", 8F);
            this.cV16.Location = new System.Drawing.Point(425, 0);
            this.cV16.Name = "cV16";
            this.cV16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV16.ParentStyleUsing.UseFont = false;
            this.cV16.Size = new System.Drawing.Size(20, 25);
            this.cV16.Text = "cV16";
            this.cV16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV17
            // 
            this.cV17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V17", "")});
            this.cV17.Font = new System.Drawing.Font("Arial", 8F);
            this.cV17.Location = new System.Drawing.Point(445, 0);
            this.cV17.Name = "cV17";
            this.cV17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV17.ParentStyleUsing.UseFont = false;
            this.cV17.Size = new System.Drawing.Size(20, 25);
            this.cV17.Text = "cV17";
            this.cV17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV18
            // 
            this.cV18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V18", "")});
            this.cV18.Font = new System.Drawing.Font("Arial", 8F);
            this.cV18.Location = new System.Drawing.Point(465, 0);
            this.cV18.Name = "cV18";
            this.cV18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV18.ParentStyleUsing.UseFont = false;
            this.cV18.Size = new System.Drawing.Size(20, 25);
            this.cV18.Text = "cV18";
            this.cV18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV19
            // 
            this.cV19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V19", "")});
            this.cV19.Font = new System.Drawing.Font("Arial", 8F);
            this.cV19.Location = new System.Drawing.Point(485, 0);
            this.cV19.Name = "cV19";
            this.cV19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV19.ParentStyleUsing.UseFont = false;
            this.cV19.Size = new System.Drawing.Size(20, 25);
            this.cV19.Text = "cV19";
            this.cV19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV20
            // 
            this.cV20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V20", "")});
            this.cV20.Font = new System.Drawing.Font("Arial", 8F);
            this.cV20.Location = new System.Drawing.Point(505, 0);
            this.cV20.Name = "cV20";
            this.cV20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV20.ParentStyleUsing.UseFont = false;
            this.cV20.Size = new System.Drawing.Size(20, 25);
            this.cV20.Text = "cV20";
            this.cV20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV21
            // 
            this.cV21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V21", "")});
            this.cV21.Font = new System.Drawing.Font("Arial", 8F);
            this.cV21.Location = new System.Drawing.Point(525, 0);
            this.cV21.Name = "cV21";
            this.cV21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV21.ParentStyleUsing.UseFont = false;
            this.cV21.Size = new System.Drawing.Size(20, 25);
            this.cV21.Text = "cV21";
            this.cV21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV22
            // 
            this.cV22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V22", "")});
            this.cV22.Font = new System.Drawing.Font("Arial", 8F);
            this.cV22.Location = new System.Drawing.Point(545, 0);
            this.cV22.Name = "cV22";
            this.cV22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV22.ParentStyleUsing.UseFont = false;
            this.cV22.Size = new System.Drawing.Size(20, 25);
            this.cV22.Text = "cV22";
            this.cV22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV23
            // 
            this.cV23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V23", "")});
            this.cV23.Font = new System.Drawing.Font("Arial", 8F);
            this.cV23.Location = new System.Drawing.Point(565, 0);
            this.cV23.Name = "cV23";
            this.cV23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV23.ParentStyleUsing.UseFont = false;
            this.cV23.Size = new System.Drawing.Size(20, 25);
            this.cV23.Text = "cV23";
            this.cV23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV24
            // 
            this.cV24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V24", "")});
            this.cV24.Font = new System.Drawing.Font("Arial", 8F);
            this.cV24.Location = new System.Drawing.Point(585, 0);
            this.cV24.Name = "cV24";
            this.cV24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV24.ParentStyleUsing.UseFont = false;
            this.cV24.Size = new System.Drawing.Size(20, 25);
            this.cV24.Text = "cV24";
            this.cV24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV25
            // 
            this.cV25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V25", "")});
            this.cV25.Font = new System.Drawing.Font("Arial", 8F);
            this.cV25.Location = new System.Drawing.Point(605, 0);
            this.cV25.Name = "cV25";
            this.cV25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV25.ParentStyleUsing.UseFont = false;
            this.cV25.Size = new System.Drawing.Size(20, 25);
            this.cV25.Text = "cV25";
            this.cV25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV26
            // 
            this.cV26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V26", "")});
            this.cV26.Font = new System.Drawing.Font("Arial", 8F);
            this.cV26.Location = new System.Drawing.Point(625, 0);
            this.cV26.Name = "cV26";
            this.cV26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV26.ParentStyleUsing.UseFont = false;
            this.cV26.Size = new System.Drawing.Size(20, 25);
            this.cV26.Text = "cV26";
            this.cV26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV27
            // 
            this.cV27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V27", "")});
            this.cV27.Font = new System.Drawing.Font("Arial", 8F);
            this.cV27.Location = new System.Drawing.Point(645, 0);
            this.cV27.Name = "cV27";
            this.cV27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV27.ParentStyleUsing.UseFont = false;
            this.cV27.Size = new System.Drawing.Size(20, 25);
            this.cV27.Text = "cV27";
            this.cV27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV28
            // 
            this.cV28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V28", "")});
            this.cV28.Font = new System.Drawing.Font("Arial", 8F);
            this.cV28.Location = new System.Drawing.Point(665, 0);
            this.cV28.Name = "cV28";
            this.cV28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV28.ParentStyleUsing.UseFont = false;
            this.cV28.Size = new System.Drawing.Size(20, 25);
            this.cV28.Text = "cV28";
            this.cV28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV29
            // 
            this.cV29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V29", "")});
            this.cV29.Font = new System.Drawing.Font("Arial", 8F);
            this.cV29.Location = new System.Drawing.Point(685, 0);
            this.cV29.Name = "cV29";
            this.cV29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV29.ParentStyleUsing.UseFont = false;
            this.cV29.Size = new System.Drawing.Size(20, 25);
            this.cV29.Text = "cV29";
            this.cV29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV30
            // 
            this.cV30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V30", "")});
            this.cV30.Font = new System.Drawing.Font("Arial", 8F);
            this.cV30.Location = new System.Drawing.Point(705, 0);
            this.cV30.Name = "cV30";
            this.cV30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV30.ParentStyleUsing.UseFont = false;
            this.cV30.Size = new System.Drawing.Size(20, 25);
            this.cV30.Text = "cV30";
            this.cV30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cV31
            // 
            this.cV31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "V31", "")});
            this.cV31.Font = new System.Drawing.Font("Arial", 8F);
            this.cV31.Location = new System.Drawing.Point(725, 0);
            this.cV31.Name = "cV31";
            this.cV31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cV31.ParentStyleUsing.UseFont = false;
            this.cV31.Size = new System.Drawing.Size(20, 25);
            this.cV31.Text = "cV31";
            this.cV31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell109
            // 
            this.xrTableCell109.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Stat01", "")});
            this.xrTableCell109.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell109.Location = new System.Drawing.Point(745, 0);
            this.xrTableCell109.Name = "xrTableCell109";
            this.xrTableCell109.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell109.ParentStyleUsing.UseFont = false;
            this.xrTableCell109.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell109.Text = "xrTableCell109";
            this.xrTableCell109.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell103
            // 
            this.xrTableCell103.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Stat02", "")});
            this.xrTableCell103.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell103.Location = new System.Drawing.Point(770, 0);
            this.xrTableCell103.Name = "xrTableCell103";
            this.xrTableCell103.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell103.ParentStyleUsing.UseFont = false;
            this.xrTableCell103.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell103.Text = "xrTableCell103";
            this.xrTableCell103.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell106
            // 
            this.xrTableCell106.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Stat04", "")});
            this.xrTableCell106.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell106.Location = new System.Drawing.Point(795, 0);
            this.xrTableCell106.Name = "xrTableCell106";
            this.xrTableCell106.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell106.ParentStyleUsing.UseFont = false;
            this.xrTableCell106.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell106.Text = "xrTableCell106";
            this.xrTableCell106.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell112
            // 
            this.xrTableCell112.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Stat05", "")});
            this.xrTableCell112.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell112.Location = new System.Drawing.Point(820, 0);
            this.xrTableCell112.Name = "xrTableCell112";
            this.xrTableCell112.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell112.ParentStyleUsing.UseFont = false;
            this.xrTableCell112.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell112.Text = "xrTableCell112";
            this.xrTableCell112.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell121
            // 
            this.xrTableCell121.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Stat07", "")});
            this.xrTableCell121.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell121.Location = new System.Drawing.Point(845, 0);
            this.xrTableCell121.Name = "xrTableCell121";
            this.xrTableCell121.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell121.ParentStyleUsing.UseFont = false;
            this.xrTableCell121.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell121.Text = "xrTableCell121";
            this.xrTableCell121.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell115
            // 
            this.xrTableCell115.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Stat06", "")});
            this.xrTableCell115.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell115.Location = new System.Drawing.Point(870, 0);
            this.xrTableCell115.Name = "xrTableCell115";
            this.xrTableCell115.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell115.ParentStyleUsing.UseFont = false;
            this.xrTableCell115.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell115.Text = "xrTableCell115";
            this.xrTableCell115.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell124
            // 
            this.xrTableCell124.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Stat10", "")});
            this.xrTableCell124.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell124.Location = new System.Drawing.Point(895, 0);
            this.xrTableCell124.Name = "xrTableCell124";
            this.xrTableCell124.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell124.ParentStyleUsing.UseFont = false;
            this.xrTableCell124.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell124.Text = "xrTableCell124";
            this.xrTableCell124.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell118
            // 
            this.xrTableCell118.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Stat08", "")});
            this.xrTableCell118.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell118.Location = new System.Drawing.Point(920, 0);
            this.xrTableCell118.Name = "xrTableCell118";
            this.xrTableCell118.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell118.ParentStyleUsing.UseFont = false;
            this.xrTableCell118.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell118.Text = "xrTableCell118";
            this.xrTableCell118.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell100
            // 
            this.xrTableCell100.BorderColor = System.Drawing.Color.White;
            this.xrTableCell100.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell100.Location = new System.Drawing.Point(945, 0);
            this.xrTableCell100.Name = "xrTableCell100";
            this.xrTableCell100.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell100.ParentStyleUsing.UseBorderColor = false;
            this.xrTableCell100.ParentStyleUsing.UseFont = false;
            this.xrTableCell100.Size = new System.Drawing.Size(5, 25);
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell28.Size = new System.Drawing.Size(108, 25);
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Font = new System.Drawing.Font("Arial", 9F);
            this.xrTableCell15.Location = new System.Drawing.Point(108, 0);
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell15.ParentStyleUsing.UseFont = false;
            this.xrTableCell15.Size = new System.Drawing.Size(17, 25);
            this.xrTableCell15.Text = "N";
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN01
            // 
            this.cN01.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N01", "")});
            this.cN01.Font = new System.Drawing.Font("Arial", 8F);
            this.cN01.Location = new System.Drawing.Point(125, 0);
            this.cN01.Name = "cN01";
            this.cN01.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN01.ParentStyleUsing.UseFont = false;
            this.cN01.Size = new System.Drawing.Size(20, 25);
            this.cN01.Text = "cN01";
            this.cN01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN02
            // 
            this.cN02.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N02", "")});
            this.cN02.Font = new System.Drawing.Font("Arial", 8F);
            this.cN02.Location = new System.Drawing.Point(145, 0);
            this.cN02.Name = "cN02";
            this.cN02.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN02.ParentStyleUsing.UseFont = false;
            this.cN02.Size = new System.Drawing.Size(20, 25);
            this.cN02.Text = "cN02";
            this.cN02.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN03
            // 
            this.cN03.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N03", "")});
            this.cN03.Font = new System.Drawing.Font("Arial", 8F);
            this.cN03.Location = new System.Drawing.Point(165, 0);
            this.cN03.Name = "cN03";
            this.cN03.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN03.ParentStyleUsing.UseFont = false;
            this.cN03.Size = new System.Drawing.Size(20, 25);
            this.cN03.Text = "cN03";
            this.cN03.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN04
            // 
            this.cN04.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N04", "")});
            this.cN04.Font = new System.Drawing.Font("Arial", 8F);
            this.cN04.Location = new System.Drawing.Point(185, 0);
            this.cN04.Name = "cN04";
            this.cN04.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN04.ParentStyleUsing.UseFont = false;
            this.cN04.Size = new System.Drawing.Size(20, 25);
            this.cN04.Text = "cN04";
            this.cN04.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN05
            // 
            this.cN05.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N05", "")});
            this.cN05.Font = new System.Drawing.Font("Arial", 8F);
            this.cN05.Location = new System.Drawing.Point(205, 0);
            this.cN05.Name = "cN05";
            this.cN05.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN05.ParentStyleUsing.UseFont = false;
            this.cN05.Size = new System.Drawing.Size(20, 25);
            this.cN05.Text = "cN05";
            this.cN05.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN06
            // 
            this.cN06.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N06", "")});
            this.cN06.Font = new System.Drawing.Font("Arial", 8F);
            this.cN06.Location = new System.Drawing.Point(225, 0);
            this.cN06.Name = "cN06";
            this.cN06.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN06.ParentStyleUsing.UseFont = false;
            this.cN06.Size = new System.Drawing.Size(20, 25);
            this.cN06.Text = "cN06";
            this.cN06.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN07
            // 
            this.cN07.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N07", "")});
            this.cN07.Font = new System.Drawing.Font("Arial", 8F);
            this.cN07.Location = new System.Drawing.Point(245, 0);
            this.cN07.Name = "cN07";
            this.cN07.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN07.ParentStyleUsing.UseFont = false;
            this.cN07.Size = new System.Drawing.Size(20, 25);
            this.cN07.Text = "cN07";
            this.cN07.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN08
            // 
            this.cN08.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N08", "")});
            this.cN08.Font = new System.Drawing.Font("Arial", 8F);
            this.cN08.Location = new System.Drawing.Point(265, 0);
            this.cN08.Name = "cN08";
            this.cN08.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN08.ParentStyleUsing.UseFont = false;
            this.cN08.Size = new System.Drawing.Size(20, 25);
            this.cN08.Text = "cN08";
            this.cN08.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN09
            // 
            this.cN09.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N09", "")});
            this.cN09.Font = new System.Drawing.Font("Arial", 8F);
            this.cN09.Location = new System.Drawing.Point(285, 0);
            this.cN09.Name = "cN09";
            this.cN09.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN09.ParentStyleUsing.UseFont = false;
            this.cN09.Size = new System.Drawing.Size(20, 25);
            this.cN09.Text = "cN09";
            this.cN09.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN10
            // 
            this.cN10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N10", "")});
            this.cN10.Font = new System.Drawing.Font("Arial", 8F);
            this.cN10.Location = new System.Drawing.Point(305, 0);
            this.cN10.Name = "cN10";
            this.cN10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN10.ParentStyleUsing.UseFont = false;
            this.cN10.Size = new System.Drawing.Size(20, 25);
            this.cN10.Text = "cN10";
            this.cN10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN11
            // 
            this.cN11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N11", "")});
            this.cN11.Font = new System.Drawing.Font("Arial", 8F);
            this.cN11.Location = new System.Drawing.Point(325, 0);
            this.cN11.Name = "cN11";
            this.cN11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN11.ParentStyleUsing.UseFont = false;
            this.cN11.Size = new System.Drawing.Size(20, 25);
            this.cN11.Text = "cN11";
            this.cN11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN12
            // 
            this.cN12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N12", "")});
            this.cN12.Font = new System.Drawing.Font("Arial", 8F);
            this.cN12.Location = new System.Drawing.Point(345, 0);
            this.cN12.Name = "cN12";
            this.cN12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN12.ParentStyleUsing.UseFont = false;
            this.cN12.Size = new System.Drawing.Size(20, 25);
            this.cN12.Text = "cN12";
            this.cN12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN13
            // 
            this.cN13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N13", "")});
            this.cN13.Font = new System.Drawing.Font("Arial", 8F);
            this.cN13.Location = new System.Drawing.Point(365, 0);
            this.cN13.Name = "cN13";
            this.cN13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN13.ParentStyleUsing.UseFont = false;
            this.cN13.Size = new System.Drawing.Size(20, 25);
            this.cN13.Text = "cN13";
            this.cN13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN14
            // 
            this.cN14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N14", "")});
            this.cN14.Font = new System.Drawing.Font("Arial", 8F);
            this.cN14.Location = new System.Drawing.Point(385, 0);
            this.cN14.Name = "cN14";
            this.cN14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN14.ParentStyleUsing.UseFont = false;
            this.cN14.Size = new System.Drawing.Size(20, 25);
            this.cN14.Text = "cN14";
            this.cN14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN15
            // 
            this.cN15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N15", "")});
            this.cN15.Font = new System.Drawing.Font("Arial", 8F);
            this.cN15.Location = new System.Drawing.Point(405, 0);
            this.cN15.Name = "cN15";
            this.cN15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN15.ParentStyleUsing.UseFont = false;
            this.cN15.Size = new System.Drawing.Size(20, 25);
            this.cN15.Text = "cN15";
            this.cN15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN16
            // 
            this.cN16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N16", "")});
            this.cN16.Font = new System.Drawing.Font("Arial", 8F);
            this.cN16.Location = new System.Drawing.Point(425, 0);
            this.cN16.Name = "cN16";
            this.cN16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN16.ParentStyleUsing.UseFont = false;
            this.cN16.Size = new System.Drawing.Size(20, 25);
            this.cN16.Text = "cN16";
            this.cN16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN17
            // 
            this.cN17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N17", "")});
            this.cN17.Font = new System.Drawing.Font("Arial", 8F);
            this.cN17.Location = new System.Drawing.Point(445, 0);
            this.cN17.Name = "cN17";
            this.cN17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN17.ParentStyleUsing.UseFont = false;
            this.cN17.Size = new System.Drawing.Size(20, 25);
            this.cN17.Text = "cN17";
            this.cN17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN18
            // 
            this.cN18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N18", "")});
            this.cN18.Font = new System.Drawing.Font("Arial", 8F);
            this.cN18.Location = new System.Drawing.Point(465, 0);
            this.cN18.Name = "cN18";
            this.cN18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN18.ParentStyleUsing.UseFont = false;
            this.cN18.Size = new System.Drawing.Size(20, 25);
            this.cN18.Text = "cN18";
            this.cN18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN19
            // 
            this.cN19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N19", "")});
            this.cN19.Font = new System.Drawing.Font("Arial", 8F);
            this.cN19.Location = new System.Drawing.Point(485, 0);
            this.cN19.Name = "cN19";
            this.cN19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN19.ParentStyleUsing.UseFont = false;
            this.cN19.Size = new System.Drawing.Size(20, 25);
            this.cN19.Text = "cN19";
            this.cN19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN20
            // 
            this.cN20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N20", "")});
            this.cN20.Font = new System.Drawing.Font("Arial", 8F);
            this.cN20.Location = new System.Drawing.Point(505, 0);
            this.cN20.Name = "cN20";
            this.cN20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN20.ParentStyleUsing.UseFont = false;
            this.cN20.Size = new System.Drawing.Size(20, 25);
            this.cN20.Text = "cN20";
            this.cN20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN21
            // 
            this.cN21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N21", "")});
            this.cN21.Font = new System.Drawing.Font("Arial", 8F);
            this.cN21.Location = new System.Drawing.Point(525, 0);
            this.cN21.Name = "cN21";
            this.cN21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN21.ParentStyleUsing.UseFont = false;
            this.cN21.Size = new System.Drawing.Size(20, 25);
            this.cN21.Text = "cN21";
            this.cN21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN22
            // 
            this.cN22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N22", "")});
            this.cN22.Font = new System.Drawing.Font("Arial", 8F);
            this.cN22.Location = new System.Drawing.Point(545, 0);
            this.cN22.Name = "cN22";
            this.cN22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN22.ParentStyleUsing.UseFont = false;
            this.cN22.Size = new System.Drawing.Size(20, 25);
            this.cN22.Text = "cN22";
            this.cN22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN23
            // 
            this.cN23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N23", "")});
            this.cN23.Font = new System.Drawing.Font("Arial", 8F);
            this.cN23.Location = new System.Drawing.Point(565, 0);
            this.cN23.Name = "cN23";
            this.cN23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN23.ParentStyleUsing.UseFont = false;
            this.cN23.Size = new System.Drawing.Size(20, 25);
            this.cN23.Text = "cN23";
            this.cN23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN24
            // 
            this.cN24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N24", "")});
            this.cN24.Font = new System.Drawing.Font("Arial", 8F);
            this.cN24.Location = new System.Drawing.Point(585, 0);
            this.cN24.Name = "cN24";
            this.cN24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN24.ParentStyleUsing.UseFont = false;
            this.cN24.Size = new System.Drawing.Size(20, 25);
            this.cN24.Text = "cN24";
            this.cN24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN25
            // 
            this.cN25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N25", "")});
            this.cN25.Font = new System.Drawing.Font("Arial", 8F);
            this.cN25.Location = new System.Drawing.Point(605, 0);
            this.cN25.Name = "cN25";
            this.cN25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN25.ParentStyleUsing.UseFont = false;
            this.cN25.Size = new System.Drawing.Size(20, 25);
            this.cN25.Text = "cN25";
            this.cN25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN26
            // 
            this.cN26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N26", "")});
            this.cN26.Font = new System.Drawing.Font("Arial", 8F);
            this.cN26.Location = new System.Drawing.Point(625, 0);
            this.cN26.Name = "cN26";
            this.cN26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN26.ParentStyleUsing.UseFont = false;
            this.cN26.Size = new System.Drawing.Size(20, 25);
            this.cN26.Text = "cN26";
            this.cN26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN27
            // 
            this.cN27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N27", "")});
            this.cN27.Font = new System.Drawing.Font("Arial", 8F);
            this.cN27.Location = new System.Drawing.Point(645, 0);
            this.cN27.Name = "cN27";
            this.cN27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN27.ParentStyleUsing.UseFont = false;
            this.cN27.Size = new System.Drawing.Size(20, 25);
            this.cN27.Text = "cN27";
            this.cN27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN28
            // 
            this.cN28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N28", "")});
            this.cN28.Font = new System.Drawing.Font("Arial", 8F);
            this.cN28.Location = new System.Drawing.Point(665, 0);
            this.cN28.Name = "cN28";
            this.cN28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN28.ParentStyleUsing.UseFont = false;
            this.cN28.Size = new System.Drawing.Size(20, 25);
            this.cN28.Text = "cN28";
            this.cN28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN29
            // 
            this.cN29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N29", "")});
            this.cN29.Font = new System.Drawing.Font("Arial", 8F);
            this.cN29.Location = new System.Drawing.Point(685, 0);
            this.cN29.Name = "cN29";
            this.cN29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN29.ParentStyleUsing.UseFont = false;
            this.cN29.Size = new System.Drawing.Size(20, 25);
            this.cN29.Text = "cN29";
            this.cN29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN30
            // 
            this.cN30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N30", "")});
            this.cN30.Font = new System.Drawing.Font("Arial", 8F);
            this.cN30.Location = new System.Drawing.Point(705, 0);
            this.cN30.Name = "cN30";
            this.cN30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN30.ParentStyleUsing.UseFont = false;
            this.cN30.Size = new System.Drawing.Size(20, 25);
            this.cN30.Text = "cN30";
            this.cN30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // cN31
            // 
            this.cN31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "N31", "")});
            this.cN31.Font = new System.Drawing.Font("Arial", 8F);
            this.cN31.Location = new System.Drawing.Point(725, 0);
            this.cN31.Name = "cN31";
            this.cN31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cN31.ParentStyleUsing.UseFont = false;
            this.cN31.Size = new System.Drawing.Size(20, 25);
            this.cN31.Text = "cN31";
            this.cN31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell110
            // 
            this.xrTableCell110.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell110.Location = new System.Drawing.Point(745, 0);
            this.xrTableCell110.Name = "xrTableCell110";
            this.xrTableCell110.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell110.ParentStyleUsing.UseFont = false;
            this.xrTableCell110.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell110.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell104
            // 
            this.xrTableCell104.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell104.Location = new System.Drawing.Point(770, 0);
            this.xrTableCell104.Name = "xrTableCell104";
            this.xrTableCell104.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell104.ParentStyleUsing.UseFont = false;
            this.xrTableCell104.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell104.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell107
            // 
            this.xrTableCell107.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell107.Location = new System.Drawing.Point(795, 0);
            this.xrTableCell107.Name = "xrTableCell107";
            this.xrTableCell107.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell107.ParentStyleUsing.UseFont = false;
            this.xrTableCell107.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell107.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell113
            // 
            this.xrTableCell113.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell113.Location = new System.Drawing.Point(820, 0);
            this.xrTableCell113.Name = "xrTableCell113";
            this.xrTableCell113.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell113.ParentStyleUsing.UseFont = false;
            this.xrTableCell113.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell113.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell122
            // 
            this.xrTableCell122.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell122.Location = new System.Drawing.Point(845, 0);
            this.xrTableCell122.Name = "xrTableCell122";
            this.xrTableCell122.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell122.ParentStyleUsing.UseFont = false;
            this.xrTableCell122.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell122.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell116
            // 
            this.xrTableCell116.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell116.Location = new System.Drawing.Point(870, 0);
            this.xrTableCell116.Name = "xrTableCell116";
            this.xrTableCell116.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell116.ParentStyleUsing.UseFont = false;
            this.xrTableCell116.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell116.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell125
            // 
            this.xrTableCell125.Location = new System.Drawing.Point(895, 0);
            this.xrTableCell125.Name = "xrTableCell125";
            this.xrTableCell125.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell125.Size = new System.Drawing.Size(25, 25);
            // 
            // xrTableCell119
            // 
            this.xrTableCell119.Font = new System.Drawing.Font("Arial", 7F);
            this.xrTableCell119.Location = new System.Drawing.Point(920, 0);
            this.xrTableCell119.Name = "xrTableCell119";
            this.xrTableCell119.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell119.ParentStyleUsing.UseFont = false;
            this.xrTableCell119.Size = new System.Drawing.Size(25, 25);
            this.xrTableCell119.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell101
            // 
            this.xrTableCell101.BorderColor = System.Drawing.Color.White;
            this.xrTableCell101.Font = new System.Drawing.Font("Arial", 8F);
            this.xrTableCell101.Location = new System.Drawing.Point(945, 0);
            this.xrTableCell101.Name = "xrTableCell101";
            this.xrTableCell101.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell101.ParentStyleUsing.UseBorderColor = false;
            this.xrTableCell101.ParentStyleUsing.UseFont = false;
            this.xrTableCell101.Size = new System.Drawing.Size(5, 25);
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrPageInfo2.Location = new System.Drawing.Point(850, 8);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            this.xrPageInfo2.Size = new System.Drawing.Size(117, 25);
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLine1
            // 
            this.xrLine1.Location = new System.Drawing.Point(17, 0);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(949, 8);
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrPageInfo1.Format = "{0:dd.MM.yyyy}";
            this.xrPageInfo1.Location = new System.Drawing.Point(17, 8);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(83, 25);
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.Position = 0;
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.PageHeader,
                        this.Detail,
                        this.PageFooter});
            this.DataSource = this.sqlQuery1;
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Landscape = true;
            this.Name = "Report";
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' , ParameterXML =  N'<NewDataSet>
       <Table>
		<FieldName>label</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>leere Maske</DisplayText>
		<TabPosition>1</TabPosition>
		<X>120</X>
		<Y>60</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table> 
</NewDataSet>' , SQLquery =  N'declare @UserKA int
declare @Monat int
declare @Jahr int
declare @KlientID int
declare @APVNr int
declare @Zusatz int
declare @CoachID int
declare @FachbereichID int
declare @FachleitungID int
declare @KursID int

SET @UserKA = ISNULL({UserKA}, 0)
set @Monat = case ISNULL({Monat}, 0) when 0 then Month(GetDate()) else isnull({Monat}, Month(GetDate())) end
set @Jahr = case ISNULL({Jahr}, 0) when 0 then Year(GetDate()) else isnull({Jahr} , Year(GetDate())) end

IF {KlientID} = 0 BEGIN SET @KlientID = NULL END ELSE BEGIN SET @KlientID = {KlientID} END
IF {APVNr} = 0 BEGIN SET @APVNr = NULL END ELSE BEGIN SET @APVNr = {APVNr} END
IF {Zusatz} = 0 BEGIN SET @Zusatz = NULL END ELSE BEGIN SET @Zusatz = {Zusatz} END
IF {CoachID} = 0 BEGIN SET @CoachID = NULL END ELSE BEGIN SET @CoachID = {CoachID} END
IF {FachbereichID} = 0 BEGIN SET @FachbereichID = NULL END ELSE BEGIN SET @FachbereichID = {FachbereichID} END
IF {FachleitungID} = 0 BEGIN SET @FachleitungID = NULL END ELSE BEGIN SET @FachleitungID = {FachleitungID} END
IF {KursID} = 0 BEGIN SET @KursID = NULL END ELSE BEGIN SET @KursID = {KursID} END


exec spKaGetPraesenzzeitReport @UserKA, @Monat, @Jahr, @KlientID, @APVNr, @Zusatz, @CoachID, @FachbereichID, @FachleitungID, @KursID' , ContextForms =  N'FrmKaPraesenzzeit' , ParentReportName =  null , ReportSortKey =  null 
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'KAPraesenzzeitAlle' ;


