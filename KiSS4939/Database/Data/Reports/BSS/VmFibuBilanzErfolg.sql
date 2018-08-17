-- Insert Script for VmFibuBilanz Erfolg
-- MD5:0X273CC88041164EA539D6FAB12E60759D_0X39BD7A6C6BA6AF44F05521C7D5A95B21_0X46A6AEB6AFFDCC1120BD194C9E6AE0CD
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'VmFibuBilanz Erfolg') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('VmFibuBilanz Erfolg', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'VmFibuBilanz Erfolg';
--SQLCHECK_IGNORE--
UPDATE QRY
SET QueryName =  N'VmFibuBilanz Erfolg' , UserText =  N'VM - Fibu Bilanz / Erfolg' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>E:\KiSS\KiSS4 Produktion\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>en-US</Localization>
///   <References>
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Drawing\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Configuration\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.SqlXml\v4.0_4.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Security\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.Utils.v6.2.dll" />
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
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.Data.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\KiSS4.DB.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\Kiss.Interfaces.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\FluentValidation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\StructureMap.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\log4net.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\SharpLibrary.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.Subreport VmFibuBilanzSaldoGruppen;
        private DevExpress.XtraReports.UI.XRPageBreak xrPageBreak1;
        private DevExpress.XtraReports.UI.Subreport VmFibuBilanzAufwandErtrag;
        private DevExpress.XtraReports.UI.Subreport VmFibuBilanzEinnahmen;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.Subreport VmFibuBilanzVergleich;
        private DevExpress.XtraReports.UI.Subreport VmFibuBilanzAktivPassiv;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel Geburtsdatum1;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtGeburtsdatum;
        private DevExpress.XtraReports.UI.XRLabel TextBox12;
        private DevExpress.XtraReports.UI.XRLabel txtDatumBereich;
        private DevExpress.XtraReports.UI.XRLabel TextBox10;
        private DevExpress.XtraReports.UI.XRLabel TextBox1;
        private DevExpress.XtraReports.UI.XRLabel Label4;
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
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kA" +
                        "AAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAA" +
                        "AAAAbAIZGVjbGFyZSBARmJQZXJpb2RlSUQgICAgIGludA0KZGVjbGFyZSBAUGVyRGF0dW0gICAgICAgI" +
                        "GRhdGV0aW1lDQpkZWNsYXJlIEBOdXJNaXRCdWNodW5nZW4gYml0DQoNCnNldCBARmJQZXJpb2RlSUQgI" +
                        "CAgID0gbnVsbA0Kc2V0IEBQZXJEYXR1bSAgICAgICAgPSBudWxsDQpzZXQgQE51ck1pdEJ1Y2h1bmdlb" +
                        "iA9IG51bGwNCg0KZGVjbGFyZSBAVGVhbSAgICAgICAgICB2YXJjaGFyKDUwKQ0KZGVjbGFyZSBARGF0d" +
                        "W1CZXJlaWNoICB2YXJjaGFyKDUwKQ0KZGVjbGFyZSBAR2VidXJ0c2RhdHVtICB2YXJjaGFyKDIwKQ0KZ" +
                        "GVjbGFyZSBATWFuZGFudCAgICAgICB2YXJjaGFyKDIwMCkNCg0KaWYgQFBlckRhdHVtIGlzIG51bGwNC" +
                        "iAgIHNldCBAUGVyRGF0dW0gPSAoc2VsZWN0IFBlcmlvZGVCaXMgZnJvbSBGYlBlcmlvZGUgd2hlcmUgR" +
                        "mJQZXJpb2RlSUQgPSBARmJQZXJpb2RlSUQpDQoNCnNlbGVjdCBATWFuZGFudCA9IFBSUy5OYW1lICsga" +
                        "XNOdWxsKCcsICcgKyBQUlMuVm9ybmFtZSwnJyksDQogICAgICAgQEdlYnVydHNkYXR1bSA9IGNvbnZlc" +
                        "nQodmFyY2hhcixQUlMuR2VidXJ0c2RhdHVtLDEwNCksDQogICAgICAgQERhdHVtQmVyZWljaCA9IGNvb" +
                        "nZlcnQodmFyY2hhcixQRVIuUGVyaW9kZVZvbiwxMDQpICsgJyAtICcgKw0KICAgICAgICAgICAgICAgI" +
                        "CAgICAgICBjb252ZXJ0KHZhcmNoYXIsUEVSLlBlcmlvZGVCaXMsMTA0KSwNCiAgICAgICBAVGVhbSA9I" +
                        "FRFQS5OYW1lDQpmcm9tICAgRmJQZXJpb2RlIFBFUg0KICAgICAgIGlubmVyIGpvaW4gQmFQZXJzb24gU" +
                        "FJTIG9uIFBSUy5CYVBlcnNvbklEID0gUEVSLkJhUGVyc29uSUQNCiAgICAgICBsZWZ0ICBqb2luIEZiV" +
                        "GVhbSAgICBURUEgb24gVEVBLkZiVGVhbUlEID0gUEVSLkZiVGVhbUlEDQp3aGVyZSAgUEVSLkZiUGVya" +
                        "W9kZUlEID0gQEZiUGVyaW9kZUlEDQoNCnNlbGVjdCBNYW5kYW50ID0gQE1hbmRhbnQsDQogICAgICAgR" +
                        "2VidXJ0c2RhdHVtID0gQEdlYnVydHNkYXR1bSwNCiAgICAgICBEYXR1bUJlcmVpY2ggPSBARGF0dW1CZ" +
                        "XJlaWNoLA0KICAgICAgIFRlYW0gPSBAVGVhbSwNCiAgICAgICBQZXJEYXR1bSA9IEBQZXJEYXR1bQ==";
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
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.VmFibuBilanzSaldoGruppen = new DevExpress.XtraReports.UI.Subreport();
            this.xrPageBreak1 = new DevExpress.XtraReports.UI.XRPageBreak();
            this.VmFibuBilanzAufwandErtrag = new DevExpress.XtraReports.UI.Subreport();
            this.VmFibuBilanzEinnahmen = new DevExpress.XtraReports.UI.Subreport();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.VmFibuBilanzVergleich = new DevExpress.XtraReports.UI.Subreport();
            this.VmFibuBilanzAktivPassiv = new DevExpress.XtraReports.UI.Subreport();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Geburtsdatum1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGeburtsdatum = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox12 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtDatumBereich = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox10 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
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
                        this.VmFibuBilanzSaldoGruppen,
                        this.xrPageBreak1,
                        this.VmFibuBilanzAufwandErtrag,
                        this.VmFibuBilanzEinnahmen,
                        this.xrLabel2,
                        this.VmFibuBilanzVergleich,
                        this.VmFibuBilanzAktivPassiv});
            this.Detail.Height = 273;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBackColor = false;
            this.Detail.ParentStyleUsing.UseBorderColor = false;
            this.Detail.ParentStyleUsing.UseBorders = false;
            this.Detail.ParentStyleUsing.UseBorderWidth = false;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.ParentStyleUsing.UseForeColor = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel3,
                        this.Geburtsdatum1,
                        this.txtGeburtsdatum,
                        this.TextBox12,
                        this.txtDatumBereich,
                        this.TextBox10,
                        this.TextBox1,
                        this.Label4});
            this.PageHeader.Height = 160;
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
                        this.xrLabel1,
                        this.xrPageInfo2,
                        this.xrPageInfo1,
                        this.Label6,
                        this.Line2,
                        this.Label1});
            this.PageFooter.Height = 60;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // VmFibuBilanzSaldoGruppen
            // 
            this.VmFibuBilanzSaldoGruppen.Location = new System.Drawing.Point(0, 147);
            this.VmFibuBilanzSaldoGruppen.Name = "VmFibuBilanzSaldoGruppen";
            // 
            // xrPageBreak1
            // 
            this.xrPageBreak1.Location = new System.Drawing.Point(0, 193);
            this.xrPageBreak1.Name = "xrPageBreak1";
            // 
            // VmFibuBilanzAufwandErtrag
            // 
            this.VmFibuBilanzAufwandErtrag.Location = new System.Drawing.Point(0, 200);
            this.VmFibuBilanzAufwandErtrag.Name = "VmFibuBilanzAufwandErtrag";
            // 
            // VmFibuBilanzEinnahmen
            // 
            this.VmFibuBilanzEinnahmen.Location = new System.Drawing.Point(0, 240);
            this.VmFibuBilanzEinnahmen.Name = "VmFibuBilanzEinnahmen";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.Location = new System.Drawing.Point(0, 33);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(140, 27);
            this.xrLabel2.Text = "Vermögensvergleich";
            // 
            // VmFibuBilanzVergleich
            // 
            this.VmFibuBilanzVergleich.Location = new System.Drawing.Point(0, 60);
            this.VmFibuBilanzVergleich.Name = "VmFibuBilanzVergleich";
            // 
            // VmFibuBilanzAktivPassiv
            // 
            this.VmFibuBilanzAktivPassiv.Location = new System.Drawing.Point(0, 0);
            this.VmFibuBilanzAktivPassiv.Name = "VmFibuBilanzAktivPassiv";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel3.Location = new System.Drawing.Point(0, 0);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(347, 117);
            this.xrLabel3.Text = "Stadt Bern\r\nDirektion für Sicherheit\r\nUmwelt und Energie\r\n\r\n\r\nAmt für Erwachsenen" +
                "- und \r\nKindesschutz";
            // 
            // Geburtsdatum1
            // 
            this.Geburtsdatum1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Team", "")});
            this.Geburtsdatum1.Font = new System.Drawing.Font("Arial", 9F);
            this.Geburtsdatum1.ForeColor = System.Drawing.Color.Black;
            this.Geburtsdatum1.Location = new System.Drawing.Point(240, 140);
            this.Geburtsdatum1.Multiline = true;
            this.Geburtsdatum1.Name = "Geburtsdatum1";
            this.Geburtsdatum1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Geburtsdatum1.ParentStyleUsing.UseBackColor = false;
            this.Geburtsdatum1.ParentStyleUsing.UseBorderColor = false;
            this.Geburtsdatum1.ParentStyleUsing.UseBorders = false;
            this.Geburtsdatum1.ParentStyleUsing.UseBorderWidth = false;
            this.Geburtsdatum1.ParentStyleUsing.UseFont = false;
            this.Geburtsdatum1.ParentStyleUsing.UseForeColor = false;
            this.Geburtsdatum1.Size = new System.Drawing.Size(240, 20);
            xrSummary1.FormatString = "{0:dd/MM/yyyy}";
            this.Geburtsdatum1.Summary = xrSummary1;
            this.Geburtsdatum1.Text = "Team";
            // 
            // txtGeburtsdatum
            // 
            this.txtGeburtsdatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Geburtsdatum", "{0:dd.MM.yyyy}")});
            this.txtGeburtsdatum.Font = new System.Drawing.Font("Arial", 9F);
            this.txtGeburtsdatum.ForeColor = System.Drawing.Color.Black;
            this.txtGeburtsdatum.Location = new System.Drawing.Point(73, 140);
            this.txtGeburtsdatum.Multiline = true;
            this.txtGeburtsdatum.Name = "txtGeburtsdatum";
            this.txtGeburtsdatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGeburtsdatum.ParentStyleUsing.UseBackColor = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorderColor = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorders = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseFont = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseForeColor = false;
            this.txtGeburtsdatum.Size = new System.Drawing.Size(77, 20);
            xrSummary2.FormatString = "{0:dd/MM/yyyy}";
            this.txtGeburtsdatum.Summary = xrSummary2;
            this.txtGeburtsdatum.Text = "Geburtsdatum";
            // 
            // TextBox12
            // 
            this.TextBox12.Font = new System.Drawing.Font("Arial", 9F);
            this.TextBox12.ForeColor = System.Drawing.Color.Black;
            this.TextBox12.Location = new System.Drawing.Point(0, 140);
            this.TextBox12.Multiline = true;
            this.TextBox12.Name = "TextBox12";
            this.TextBox12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox12.ParentStyleUsing.UseBackColor = false;
            this.TextBox12.ParentStyleUsing.UseBorderColor = false;
            this.TextBox12.ParentStyleUsing.UseBorders = false;
            this.TextBox12.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox12.ParentStyleUsing.UseFont = false;
            this.TextBox12.ParentStyleUsing.UseForeColor = false;
            this.TextBox12.Size = new System.Drawing.Size(70, 18);
            this.TextBox12.Text = "Geburtstag";
            // 
            // txtDatumBereich
            // 
            this.txtDatumBereich.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "DatumBereich", "")});
            this.txtDatumBereich.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.txtDatumBereich.ForeColor = System.Drawing.Color.Black;
            this.txtDatumBereich.Location = new System.Drawing.Point(547, 140);
            this.txtDatumBereich.Multiline = true;
            this.txtDatumBereich.Name = "txtDatumBereich";
            this.txtDatumBereich.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtDatumBereich.ParentStyleUsing.UseBackColor = false;
            this.txtDatumBereich.ParentStyleUsing.UseBorderColor = false;
            this.txtDatumBereich.ParentStyleUsing.UseBorders = false;
            this.txtDatumBereich.ParentStyleUsing.UseBorderWidth = false;
            this.txtDatumBereich.ParentStyleUsing.UseFont = false;
            this.txtDatumBereich.ParentStyleUsing.UseForeColor = false;
            this.txtDatumBereich.Size = new System.Drawing.Size(153, 20);
            this.txtDatumBereich.Text = "DatumBereich";
            // 
            // TextBox10
            // 
            this.TextBox10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.TextBox10.ForeColor = System.Drawing.Color.Black;
            this.TextBox10.Location = new System.Drawing.Point(493, 140);
            this.TextBox10.Multiline = true;
            this.TextBox10.Name = "TextBox10";
            this.TextBox10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox10.ParentStyleUsing.UseBackColor = false;
            this.TextBox10.ParentStyleUsing.UseBorderColor = false;
            this.TextBox10.ParentStyleUsing.UseBorders = false;
            this.TextBox10.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox10.ParentStyleUsing.UseFont = false;
            this.TextBox10.ParentStyleUsing.UseForeColor = false;
            this.TextBox10.Size = new System.Drawing.Size(51, 18);
            this.TextBox10.Text = "Periode";
            // 
            // TextBox1
            // 
            this.TextBox1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Mandant", "")});
            this.TextBox1.Font = new System.Drawing.Font("Arial", 14F);
            this.TextBox1.ForeColor = System.Drawing.Color.Black;
            this.TextBox1.Location = new System.Drawing.Point(0, 113);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox1.ParentStyleUsing.UseBackColor = false;
            this.TextBox1.ParentStyleUsing.UseBorderColor = false;
            this.TextBox1.ParentStyleUsing.UseBorders = false;
            this.TextBox1.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox1.ParentStyleUsing.UseFont = false;
            this.TextBox1.ParentStyleUsing.UseForeColor = false;
            this.TextBox1.Size = new System.Drawing.Size(700, 23);
            this.TextBox1.Text = "Mandant";
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial", 10F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(421, 80);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(281, 25);
            this.Label4.Text = "Buchhaltung - Bilanz / Erfolg";
            this.Label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            this.xrPageInfo2.Location = new System.Drawing.Point(80, 13);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            this.xrPageInfo2.Size = new System.Drawing.Size(100, 27);
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 9F);
            this.xrPageInfo1.Location = new System.Drawing.Point(338, 12);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(100, 27);
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 9F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(641, 12);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(59, 19);
            this.Label6.Text = "KISS 4";
            this.Label6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.Location = new System.Drawing.Point(0, 9);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(700, 2);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 9F);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(300, 12);
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
            this.sqlQuery1.Position = 0;
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail,
                        this.PageHeader,
                        this.PageFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(60, 60, 60, 100);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ScriptReferencesString = "System.Windows.Forms.dll\r\n";
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' , ParameterXML =  N'<NewDataSet>
    <Table>
        <FieldName>-</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Mandant / Periode</DisplayText>
        <TabPosition>1</TabPosition>
        <X>10</X>
        <Y>40</Y>
        <Height>25</Height>
        <LOVName>LOV Name</LOVName>
        <DefaultValue>DefaultValue1</DefaultValue>
        <Mandatory>true</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>-</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>per Datum</DisplayText>
        <TabPosition>2</TabPosition>
        <X>10</X>
        <Y>70</Y>
        <Height>25</Height>
    </Table>
    <Table>
        <FieldName>FbPeriodeID</FieldName>
        <FieldCode>14</FieldCode>
        <DisplayText>Mandant / Periode</DisplayText>
        <TabPosition>21</TabPosition>
        <X>120</X>
        <Y>40</Y>
        <Width>350</Width>
        <Height>25</Height>
        <Length>10</Length>
        <Mandatory>true</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
        <SQL>
declare @Pattern varchar(200)

set @Pattern = {0} + ''%''
set @Pattern = replace(@Pattern,'','',''%'')
set @Pattern = replace(@Pattern,'' '',''%'')

select distinct 
       ID = PER.FbPeriodeID,
       [Mandant / Periode] = PRS.NameVorname + 
                 '' ('' + convert(varchar,PER.PeriodeVon,104) + '' - '' + convert(varchar,PER.PeriodeBis,104),
       Strasse   = PRS.WohnsitzStrasseHausNr,
       [PLZ/Ort] = PRS.WohnsitzPLZOrt, 
       FB        = IsNull(BEN.FirstName + '' '','''') + isNull(BEN.LastName,'''') + '' ('' + BEN.LogonName + '')''
from   FbPeriode PER 
       inner join vwPerson         PRS on PRS.BaPersonID = PER.BaPersonID 
       left  join FaLeistung       FAL on FAL.BaPersonID = PER.BaPersonID and 
                                          FAL.ModulID = 5 and 
                                          FAL.DatumVon  = (select max(DatumVon) 
                                                           from   FaLeistung 
                                                           where  BaPersonID = PER.BaPersonID and 
                                                                  FAL.ModulID = 5) 
       left  join XUser            BEN on BEN.UserID = FAL.UserID
where (PRS.Name + isNull('', '' + PRS.Vorname,'''') like @Pattern
or    (CONVERT(VARCHAR, PER.FbPeriodeID) like @Pattern))
order by [Mandant / Periode]
    </SQL>
    </Table>
    <Table>
        <FieldName>PerDatum</FieldName>
        <FieldCode>5</FieldCode>
        <DisplayText>per Datum</DisplayText>
        <TabPosition>22</TabPosition>
        <X>120</X>
        <Y>70</Y>
        <Height>25</Height>
        <Width>100</Width>
    </Table>
    <Table>
        <FieldName>NurMitBuchungen</FieldName>
        <FieldCode>7</FieldCode>
        <DisplayText>nur Konti mit Buchungen</DisplayText>
        <TabPosition>23</TabPosition>
        <X>120</X>
        <Y>100</Y>
        <Width>300</Width>
        <Height>25</Height>
        <Length>200</Length>
        <DefaultValue>1</DefaultValue>
        <Mandatory>false</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
    </Table>
</NewDataSet>' , SQLquery =  N'declare @FbPeriodeID     int
declare @PerDatum        datetime
declare @NurMitBuchungen bit

set @FbPeriodeID     = {FbPeriodeID}
set @PerDatum        = {PerDatum}
set @NurMitBuchungen = {NurMitBuchungen}

declare @Team          varchar(50)
declare @DatumBereich  varchar(50)
declare @Geburtsdatum  varchar(20)
declare @Mandant       varchar(200)

if @PerDatum is null
   set @PerDatum = (select PeriodeBis from FbPeriode where FbPeriodeID = @FbPeriodeID)

select @Mandant = PRS.Name + isNull('', '' + PRS.Vorname,''''),
       @Geburtsdatum = convert(varchar,PRS.Geburtsdatum,104),
       @DatumBereich = convert(varchar,PER.PeriodeVon,104) + '' - '' +
                       convert(varchar,PER.PeriodeBis,104),
       @Team = TEA.Name
from   FbPeriode PER
       inner join BaPerson PRS on PRS.BaPersonID = PER.BaPersonID
       left  join FbTeam    TEA on TEA.FbTeamID = PER.FbTeamID
where  PER.FbPeriodeID = @FbPeriodeID

select Mandant = @Mandant,
       Geburtsdatum = @Geburtsdatum,
       DatumBereich = @DatumBereich,
       Team = @Team,
       PerDatum = @PerDatum' , ContextForms =  N'VmFibu,CtlFibuJournal,CtlFibuKontoblatt,CtlFibuKontoblatt2,CtlFibuBilanzErfolg' , ParentReportName =  null , ReportSortKey =  null , System =  0 
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'VmFibuBilanz Erfolg' ;


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'VmFibuBilanzAktivPassiv' ,  N'VM - Fibu Bilanz / Erfolg' , 1,  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>E:\KiSS\KiSS4 Produktion\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>en-US</Localization>
///   <References>
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Drawing\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Configuration\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.SqlXml\v4.0_4.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Security\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.Utils.v6.2.dll" />
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
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.Data.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\KiSS4.DB.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\Kiss.Interfaces.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\FluentValidation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\StructureMap.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\log4net.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\SharpLibrary.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel EroeffnungsSaldo1;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtSaldo;
        private DevExpress.XtraReports.UI.XRLabel txtEroeffnungsSaldo;
        private DevExpress.XtraReports.UI.XRLabel txtKontoName;
        private DevExpress.XtraReports.UI.XRLabel txtKontoNr;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel txtKlasse;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
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
                        "QBlAG4AdAAKAgAAAYcEc3RhdGljIFN5c3RlbS5EcmF3aW5nLkZvbnQgZm9udFJlZ3VsYXIgPSBuZXcgU" +
                        "3lzdGVtLkRyYXdpbmcuRm9udCgiQXJpYWwiLDksIFN5c3RlbS5EcmF3aW5nLkZvbnRTdHlsZS5SZWd1b" +
                        "GFyKTsgICAgICANCnN0YXRpYyBTeXN0ZW0uRHJhd2luZy5Gb250IGZvbnRCb2xkID0gbmV3IFN5c3Rlb" +
                        "S5EcmF3aW5nLkZvbnQoIkFyaWFsIiw5LCBTeXN0ZW0uRHJhd2luZy5Gb250U3R5bGUuQm9sZCk7DQoNC" +
                        "nByaXZhdGUgdm9pZCBPbkJlZm9yZVByaW50KG9iamVjdCBzZW5kZXIsIFN5c3RlbS5EcmF3aW5nLlBya" +
                        "W50aW5nLlByaW50RXZlbnRBcmdzIGUpIHsgICANCglpZiAodHh0S29udG9Oci5Ub1N0cmluZygpLkxlb" +
                        "md0aCA+MCkgDQoJew0KCQl0eHRTYWxkby5Gb250ICAgICA9IGZvbnRSZWd1bGFyOw0KCQl0eHRLb250b" +
                        "05hbWUuRm9udCA9IGZvbnRSZWd1bGFyOw0KCX0NCgllbHNlIA0KCXsNCgkJdHh0U2FsZG8uRm9udCAgI" +
                        "CAgPSBmb250Qm9sZDsNCgkJdHh0S29udG9OYW1lLkZvbnQgPSBmb250Qm9sZDsNCgl9DQp9AccZZGVjb" +
                        "GFyZSBARmJQZXJpb2RlSUQgICAgIGludA0KZGVjbGFyZSBAUGVyRGF0dW0gICAgICAgIGRhdGV0aW1lD" +
                        "QpkZWNsYXJlIEBOdXJNaXRCdWNodW5nZW4gYml0DQoNCnNldCBARmJQZXJpb2RlSUQgICAgID0gbnVsb" +
                        "A0Kc2V0IEBQZXJEYXR1bSAgICAgICAgPSBudWxsDQpzZXQgQE51ck1pdEJ1Y2h1bmdlbiA9IG51bGwNC" +
                        "g0KICBkZWNsYXJlIEBWb3JTYWxkb0FrdGl2ZW4gIG1vbmV5DQogIGRlY2xhcmUgQFZvclNhbGRvUGFzc" +
                        "2l2ZW4gbW9uZXkNCiAgZGVjbGFyZSBAVm9yU2FsZG9BdWZ3YW5kICBtb25leQ0KICBkZWNsYXJlIEBWb" +
                        "3JTYWxkb0VydHJhZyAgIG1vbmV5DQoNCiAgZGVjbGFyZSBAU2FsZG9Ba3RpdmVuICBtb25leQ0KICBkZ" +
                        "WNsYXJlIEBTYWxkb1Bhc3NpdmVuIG1vbmV5DQogIGRlY2xhcmUgQFNhbGRvQXVmd2FuZCAgbW9uZXkNC" +
                        "iAgZGVjbGFyZSBAU2FsZG9FcnRyYWcgICBtb25leQ0KDQogIGRlY2xhcmUgQFRlYW0gICAgICAgICAgd" +
                        "mFyY2hhcig1MCkNCiAgZGVjbGFyZSBARGF0dW1CZXJlaWNoICB2YXJjaGFyKDUwKQ0KICBkZWNsYXJlI" +
                        "EBHZWJ1cnRzZGF0dW0gIHZhcmNoYXIoMjApDQogIGRlY2xhcmUgQE1hbmRhbnQgICAgICAgdmFyY2hhc" +
                        "igyMDApDQoNCiAgZGVjbGFyZSBAdG1wIHRhYmxlKA0KICAgIElEICAgICAgICAgICAgICAgaW50IGlkZ" +
                        "W50aXR5LA0KICAgIEtsYXNzZUNvZGUgICAgICAgaW50LA0KICAgIEtsYXNzZSAgICAgICAgICAgdmFyY" +
                        "2hhcigyMCksDQogICAgS29udG9OciAgICAgICAgICBpbnQsDQogICAgS29udG9OYW1lICAgICAgICB2Y" +
                        "XJjaGFyKDE1MCksDQogICAgVm9yU2FsZG8gICAgICAgICBtb25leSwNCiAgICBTYWxkbyAgICAgICAgI" +
                        "CAgIG1vbmV5LA0KICAgIFNhbGRvR3J1cHBlTmFtZSAgdmFyY2hhcigyMCkpDQoNCiAgaWYgQFBlckRhd" +
                        "HVtIGlzIG51bGwNCiAgICBzZXQgQFBlckRhdHVtID0gKHNlbGVjdCBQZXJpb2RlQmlzIGZyb20gRmJQZ" +
                        "XJpb2RlIHdoZXJlIEZiUGVyaW9kZUlEID0gQEZiUGVyaW9kZUlEKQ0KDQogIGluc2VydCBAdG1wDQogI" +
                        "CAgc2VsZWN0DQogICAgICBLVE8uS29udG9LbGFzc2VDb2RlLA0KICAgICAgS0xBLlRleHQsDQogICAgI" +
                        "CBLVE8uS29udG9OciwNCiAgICAgIEtUTy5Lb250b05hbWUsDQogICAgICBLVE8uRXJvZWZmbnVuZ3NTY" +
                        "WxkbywNCiAgICAgIGlzTnVsbChLVE8uRXJvZWZmbnVuZ3NTYWxkbywwKSArDQogICAgICAoc2VsZWN0I" +
                        "GlzTnVsbChzdW0oQmV0cmFnKSwwKQ0KICAgICAgIGZyb20gICBGYkJ1Y2h1bmcNCiAgICAgICB3aGVyZ" +
                        "SAgRmJQZXJpb2RlSUQgPSBARmJQZXJpb2RlSUQgYW5kDQogICAgICAgICAgICAgIFNvbGxLdG9OciA9I" +
                        "EtUTy5Lb250b05yIGFuZA0KICAgICAgICAgICAgICBCdWNodW5nc2RhdHVtIDw9IEBQZXJEYXR1bSkgL" +
                        "Q0KICAgICAgKHNlbGVjdCBpc051bGwoc3VtKEJldHJhZyksMCkNCiAgICAgICBmcm9tICAgRmJCdWNod" +
                        "W5nDQogICAgICAgd2hlcmUgIEZiUGVyaW9kZUlEID0gQEZiUGVyaW9kZUlEIGFuZA0KICAgICAgICAgI" +
                        "CAgICBIYWJlbkt0b05yID0gS1RPLktvbnRvTnIgYW5kDQogICAgICAgICAgICAgIEJ1Y2h1bmdzZGF0d" +
                        "W0gPD0gQFBlckRhdHVtKSwNCiAgICAgIEtUTy5TYWxkb0dydXBwZU5hbWUNCiAgICBmcm9tIEZiS29ud" +
                        "G8gS1RPDQogICAgICAgICBpbm5lciBqb2luIFhMT1ZDb2RlIEtMQSBvbiBLTEEuTE9WTmFtZSA9ICdGY" +
                        "ktvbnRvS2xhc3NlJyBhbmQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEtMQS5Db" +
                        "2RlID0gS1RPLktvbnRvS2xhc3NlQ29kZQ0KICAgIHdoZXJlIEZiUGVyaW9kZUlEID0gQEZiUGVyaW9kZ" +
                        "UlEICBBTkQNCiAgICAgICAgICBLVE8uS29udG9LbGFzc2VDb2RlIElOICgxLDIpQU5EDQogICAgICAgI" +
                        "CAgKGlzTnVsbChATnVyTWl0QnVjaHVuZ2VuLDEpID0gMCBvciBleGlzdHMNCiAgICAgICAgICAgIChzZ" +
                        "WxlY3QgMSBmcm9tICAgRmJCdWNodW5nDQogICAgICAgICAgICAgd2hlcmUgIEZiUGVyaW9kZUlEID0gQ" +
                        "EZiUGVyaW9kZUlEIGFuZA0KICAgICAgICAgICAgICAgICAgICAoU29sbEt0b05yID0gS1RPLktvbnRvT" +
                        "nIgb3IgSGFiZW5LdG9OciA9IEtUTy5Lb250b05yKSBhbmQNCiAgICAgICAgICAgICAgICAgICAgQnVja" +
                        "HVuZ3NkYXR1bSA8PSBpc051bGwoQFBlckRhdHVtLEJ1Y2h1bmdzZGF0dW0pKSBvcg0KICAgICAgICAgI" +
                        "CAgaXNOdWxsKEtUTy5Fcm9lZmZudW5nc1NhbGRvLDApIDw+IDAJDQogICAgICAgICAgKQ0KICAgIG9yZ" +
                        "GVyIGJ5IEtUTy5Lb250b0tsYXNzZUNvZGUsIEtUTy5Lb250b05yDQoNCiAgc2VsZWN0IEBNYW5kYW50I" +
                        "D0gUFJTLk5hbWUgKyBpc051bGwoJywgJyArIFBSUy5Wb3JuYW1lLCcnKSwNCiAgICAgICAgIEBHZWJ1c" +
                        "nRzZGF0dW0gPSBjb252ZXJ0KHZhcmNoYXIsUFJTLkdlYnVydHNkYXR1bSwxMDQpLA0KICAgICAgICAgQ" +
                        "ERhdHVtQmVyZWljaCA9IGNvbnZlcnQodmFyY2hhcixQRVIuUGVyaW9kZVZvbiwxMDQpICsgJyAtICcgK" +
                        "w0KICAgICAgICAgICAgICAgICAgICAgICAgIGNvbnZlcnQodmFyY2hhcixQRVIuUGVyaW9kZUJpcywxM" +
                        "DQpLA0KICAgICAgICAgQFRlYW0gPSBURUEuTmFtZQ0KICBmcm9tICAgRmJQZXJpb2RlIFBFUg0KICAgI" +
                        "CAgICAgaW5uZXIgam9pbiBCYVBlcnNvbiBQUlMgb24gUFJTLkJhUGVyc29uSUQgPSBQRVIuQmFQZXJzb" +
                        "25JRA0KICAgICAgICAgbGVmdCAgam9pbiBGYlRlYW0gICAgVEVBIG9uIFRFQS5GYlRlYW1JRCA9IFBFU" +
                        "i5GYlRlYW1JRA0KICB3aGVyZSAgUEVSLkZiUGVyaW9kZUlEID0gQEZiUGVyaW9kZUlEDQoNCg0KICBzZ" +
                        "WxlY3QgTWFuZGFudCA9IEBNYW5kYW50LA0KICAgICAgICAgR2VidXJ0c2RhdHVtID0gQEdlYnVydHNkY" +
                        "XR1bSwNCiAgICAgICAgIERhdHVtQmVyZWljaCA9IEBEYXR1bUJlcmVpY2gsDQogICAgICAgICBUZWFtI" +
                        "D0gQFRlYW0sDQogICAgICAgICBLbGFzc2UgPSBjb252ZXJ0KHZhcmNoYXIsS2xhc3NlQ29kZSkgKyAnL" +
                        "iAnICsgS2xhc3NlLA0KICAgICAgICAgS29udG9OciwNCiAgICAgICAgIEtvbnRvTmFtZSwNCiAgICAgI" +
                        "CAgIEVyb2VmZm51bmdzU2FsZG8gPSBWb3JTYWxkbyAsDQogICAgICAgICBVbXNhdHogPSBjYXNlIHdoZ" +
                        "W4gS2xhc3NlQ29kZSBpbiAoMSwyLDk5KQ0KICAgICAgICAgICAgICAgICAgdGhlbiBTYWxkbyAtIFZvc" +
                        "lNhbGRvDQogICAgICAgICAgICAgICAgICBlbHNlIG51bGwNCiAgICAgICAgICAgICAgICAgIGVuZCwNC" +
                        "iAgICAgICAgIFNhbGRvLA0KICAgICAgICAgUGVyRGF0dW0gPSBAUGVyRGF0dW0NCiAgZnJvbSAgIEB0b" +
                        "XANCiAgb3JkZXIgYnkgS2xhc3NlQ29kZSxJRA==";
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
            DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.EroeffnungsSaldo1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtSaldo = new DevExpress.XtraReports.UI.XRLabel();
            this.txtEroeffnungsSaldo = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKontoName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKontoNr = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKlasse = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.EroeffnungsSaldo1,
                        this.txtSaldo,
                        this.txtEroeffnungsSaldo,
                        this.txtKontoName,
                        this.txtKontoNr});
            this.Detail.Height = 15;
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
                        this.xrLabel8,
                        this.xrLine2,
                        this.xrLabel7,
                        this.xrLabel6,
                        this.xrLabel2,
                        this.xrLabel1});
            this.PageHeader.Height = 31;
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
                        this.txtKlasse});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("Klasse", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 30;
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
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel10,
                        this.xrLabel9,
                        this.xrLine1,
                        this.xrLabel5,
                        this.xrLabel3,
                        this.xrLabel4});
            this.GroupFooter1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.GroupFooter1.Height = 47;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorders = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter1.ParentStyleUsing.UseFont = false;
            this.GroupFooter1.ParentStyleUsing.UseForeColor = false;
            // 
            // EroeffnungsSaldo1
            // 
            this.EroeffnungsSaldo1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Umsatz", "{0:n2}")});
            this.EroeffnungsSaldo1.Font = new System.Drawing.Font("Arial", 9F);
            this.EroeffnungsSaldo1.ForeColor = System.Drawing.Color.Black;
            this.EroeffnungsSaldo1.Location = new System.Drawing.Point(480, 0);
            this.EroeffnungsSaldo1.Multiline = true;
            this.EroeffnungsSaldo1.Name = "EroeffnungsSaldo1";
            this.EroeffnungsSaldo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.EroeffnungsSaldo1.ParentStyleUsing.UseBackColor = false;
            this.EroeffnungsSaldo1.ParentStyleUsing.UseBorderColor = false;
            this.EroeffnungsSaldo1.ParentStyleUsing.UseBorders = false;
            this.EroeffnungsSaldo1.ParentStyleUsing.UseBorderWidth = false;
            this.EroeffnungsSaldo1.ParentStyleUsing.UseFont = false;
            this.EroeffnungsSaldo1.ParentStyleUsing.UseForeColor = false;
            this.EroeffnungsSaldo1.Size = new System.Drawing.Size(108, 15);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.EroeffnungsSaldo1.Summary = xrSummary1;
            this.EroeffnungsSaldo1.Text = "Umsatz";
            this.EroeffnungsSaldo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtSaldo
            // 
            this.txtSaldo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Saldo", "{0:n2}")});
            this.txtSaldo.Font = new System.Drawing.Font("Arial", 9F);
            this.txtSaldo.ForeColor = System.Drawing.Color.Black;
            this.txtSaldo.Location = new System.Drawing.Point(590, 0);
            this.txtSaldo.Multiline = true;
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtSaldo.ParentStyleUsing.UseBackColor = false;
            this.txtSaldo.ParentStyleUsing.UseBorderColor = false;
            this.txtSaldo.ParentStyleUsing.UseBorders = false;
            this.txtSaldo.ParentStyleUsing.UseBorderWidth = false;
            this.txtSaldo.ParentStyleUsing.UseFont = false;
            this.txtSaldo.ParentStyleUsing.UseForeColor = false;
            this.txtSaldo.Size = new System.Drawing.Size(108, 15);
            xrSummary2.FormatString = "{0:#,##0.00}";
            this.txtSaldo.Summary = xrSummary2;
            this.txtSaldo.Text = "Saldo";
            this.txtSaldo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtEroeffnungsSaldo
            // 
            this.txtEroeffnungsSaldo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "EroeffnungsSaldo", "{0:n2}")});
            this.txtEroeffnungsSaldo.Font = new System.Drawing.Font("Arial", 9F);
            this.txtEroeffnungsSaldo.ForeColor = System.Drawing.Color.Black;
            this.txtEroeffnungsSaldo.Location = new System.Drawing.Point(370, 0);
            this.txtEroeffnungsSaldo.Multiline = true;
            this.txtEroeffnungsSaldo.Name = "txtEroeffnungsSaldo";
            this.txtEroeffnungsSaldo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtEroeffnungsSaldo.ParentStyleUsing.UseBackColor = false;
            this.txtEroeffnungsSaldo.ParentStyleUsing.UseBorderColor = false;
            this.txtEroeffnungsSaldo.ParentStyleUsing.UseBorders = false;
            this.txtEroeffnungsSaldo.ParentStyleUsing.UseBorderWidth = false;
            this.txtEroeffnungsSaldo.ParentStyleUsing.UseFont = false;
            this.txtEroeffnungsSaldo.ParentStyleUsing.UseForeColor = false;
            this.txtEroeffnungsSaldo.Size = new System.Drawing.Size(108, 15);
            xrSummary3.FormatString = "{0:#,##0.00}";
            this.txtEroeffnungsSaldo.Summary = xrSummary3;
            this.txtEroeffnungsSaldo.Text = "EroeffnungsSaldo";
            this.txtEroeffnungsSaldo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtKontoName
            // 
            this.txtKontoName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KontoName", "")});
            this.txtKontoName.Font = new System.Drawing.Font("Arial", 9F);
            this.txtKontoName.ForeColor = System.Drawing.Color.Black;
            this.txtKontoName.Location = new System.Drawing.Point(71, 0);
            this.txtKontoName.Multiline = true;
            this.txtKontoName.Name = "txtKontoName";
            this.txtKontoName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKontoName.ParentStyleUsing.UseBackColor = false;
            this.txtKontoName.ParentStyleUsing.UseBorderColor = false;
            this.txtKontoName.ParentStyleUsing.UseBorders = false;
            this.txtKontoName.ParentStyleUsing.UseBorderWidth = false;
            this.txtKontoName.ParentStyleUsing.UseFont = false;
            this.txtKontoName.ParentStyleUsing.UseForeColor = false;
            this.txtKontoName.Size = new System.Drawing.Size(298, 15);
            this.txtKontoName.Text = "KontoName";
            // 
            // txtKontoNr
            // 
            this.txtKontoNr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KontoNr", "")});
            this.txtKontoNr.Font = new System.Drawing.Font("Arial", 9F);
            this.txtKontoNr.ForeColor = System.Drawing.Color.Black;
            this.txtKontoNr.Location = new System.Drawing.Point(0, 0);
            this.txtKontoNr.Multiline = true;
            this.txtKontoNr.Name = "txtKontoNr";
            this.txtKontoNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKontoNr.ParentStyleUsing.UseBackColor = false;
            this.txtKontoNr.ParentStyleUsing.UseBorderColor = false;
            this.txtKontoNr.ParentStyleUsing.UseBorders = false;
            this.txtKontoNr.ParentStyleUsing.UseBorderWidth = false;
            this.txtKontoNr.ParentStyleUsing.UseFont = false;
            this.txtKontoNr.ParentStyleUsing.UseForeColor = false;
            this.txtKontoNr.Size = new System.Drawing.Size(70, 15);
            this.txtKontoNr.Text = "KontoNr";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.xrLabel8.ForeColor = System.Drawing.Color.Black;
            this.xrLabel8.Location = new System.Drawing.Point(487, 7);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseBackColor = false;
            this.xrLabel8.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel8.ParentStyleUsing.UseBorders = false;
            this.xrLabel8.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.ParentStyleUsing.UseForeColor = false;
            this.xrLabel8.Size = new System.Drawing.Size(108, 15);
            this.xrLabel8.Text = "Veränderung";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLine2
            // 
            this.xrLine2.ForeColor = System.Drawing.Color.Black;
            this.xrLine2.Location = new System.Drawing.Point(0, 27);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.ParentStyleUsing.UseBackColor = false;
            this.xrLine2.ParentStyleUsing.UseBorderColor = false;
            this.xrLine2.ParentStyleUsing.UseBorders = false;
            this.xrLine2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine2.ParentStyleUsing.UseFont = false;
            this.xrLine2.ParentStyleUsing.UseForeColor = false;
            this.xrLine2.Size = new System.Drawing.Size(700, 2);
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.xrLabel7.ForeColor = System.Drawing.Color.Black;
            this.xrLabel7.Location = new System.Drawing.Point(587, 7);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseBackColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorders = false;
            this.xrLabel7.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.ParentStyleUsing.UseForeColor = false;
            this.xrLabel7.Size = new System.Drawing.Size(108, 15);
            this.xrLabel7.Text = "Schlussbestand";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.xrLabel6.ForeColor = System.Drawing.Color.Black;
            this.xrLabel6.Location = new System.Drawing.Point(373, 7);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseBackColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorders = false;
            this.xrLabel6.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.ParentStyleUsing.UseForeColor = false;
            this.xrLabel6.Size = new System.Drawing.Size(108, 15);
            this.xrLabel6.Text = "Anfangsbestand";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.Location = new System.Drawing.Point(72, 7);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseBackColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorders = false;
            this.xrLabel2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.ParentStyleUsing.UseForeColor = false;
            this.xrLabel2.Size = new System.Drawing.Size(299, 15);
            this.xrLabel2.Text = "Kontoname";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.Location = new System.Drawing.Point(0, 7);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseBackColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.ParentStyleUsing.UseForeColor = false;
            this.xrLabel1.Size = new System.Drawing.Size(70, 15);
            this.xrLabel1.Text = "Kto-Nr.";
            // 
            // txtKlasse
            // 
            this.txtKlasse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Klasse", "")});
            this.txtKlasse.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.txtKlasse.ForeColor = System.Drawing.Color.Black;
            this.txtKlasse.Location = new System.Drawing.Point(0, 0);
            this.txtKlasse.Multiline = true;
            this.txtKlasse.Name = "txtKlasse";
            this.txtKlasse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKlasse.ParentStyleUsing.UseBackColor = false;
            this.txtKlasse.ParentStyleUsing.UseBorderColor = false;
            this.txtKlasse.ParentStyleUsing.UseBorders = false;
            this.txtKlasse.ParentStyleUsing.UseBorderWidth = false;
            this.txtKlasse.ParentStyleUsing.UseFont = false;
            this.txtKlasse.ParentStyleUsing.UseForeColor = false;
            this.txtKlasse.Size = new System.Drawing.Size(236, 23);
            this.txtKlasse.Text = "Klasse";
            // 
            // xrLabel10
            // 
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Klasse", "{0}")});
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel10.Location = new System.Drawing.Point(107, 4);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.ParentStyleUsing.UseFont = false;
            this.xrLabel10.Scripts.OnBeforePrint = "private void OnBeforePrint(object sender, System.Drawing.Printing.PrintEventArgs " +
                "e) {\r\n   xrLabel10.Text = xrLabel10.Text.Substring(3);\r\n}";
            this.xrLabel10.Size = new System.Drawing.Size(100, 20);
            // 
            // xrLabel9
            // 
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.Location = new System.Drawing.Point(71, 4);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.Size = new System.Drawing.Size(35, 15);
            this.xrLabel9.Text = "Total";
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.Location = new System.Drawing.Point(0, 0);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(700, 2);
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Saldo", "")});
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.Location = new System.Drawing.Point(590, 4);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(108, 15);
            xrSummary4.FormatString = "{0:n2}";
            xrSummary4.IgnoreNullValues = true;
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel5.Summary = xrSummary4;
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "EroeffnungsSaldo", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.Location = new System.Drawing.Point(370, 4);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(108, 15);
            xrSummary5.FormatString = "{0:n2}";
            xrSummary5.IgnoreNullValues = true;
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel3.Summary = xrSummary5;
            this.xrLabel3.Text = "xrLabel3";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Umsatz", "")});
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.Location = new System.Drawing.Point(480, 4);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(108, 15);
            xrSummary6.FormatString = "{0:n2}";
            xrSummary6.IgnoreNullValues = true;
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel4.Summary = xrSummary6;
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
                        this.GroupFooter1});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(60, 60, 60, 39);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ScriptReferencesString = "System.Windows.Forms.dll\r\n";
            this.Scripts.OnBeforePrint = resources.GetString("Report.Scripts.OnBeforePrint");
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'declare @FbPeriodeID     int
declare @PerDatum        datetime
declare @NurMitBuchungen bit

set @FbPeriodeID     = {FbPeriodeID}
set @PerDatum        = {PerDatum}
set @NurMitBuchungen = {NurMitBuchungen}

  declare @VorSaldoAktiven  money
  declare @VorSaldoPassiven money
  declare @VorSaldoAufwand  money
  declare @VorSaldoErtrag   money

  declare @SaldoAktiven  money
  declare @SaldoPassiven money
  declare @SaldoAufwand  money
  declare @SaldoErtrag   money

  declare @Team          varchar(50)
  declare @DatumBereich  varchar(50)
  declare @Geburtsdatum  varchar(20)
  declare @Mandant       varchar(200)

  declare @tmp table(
    ID               int identity,
    KlasseCode       int,
    Klasse           varchar(20),
    KontoNr          int,
    KontoName        varchar(150),
    VorSaldo         money,
    Saldo            money,
    SaldoGruppeName  varchar(20))

  if @PerDatum is null
    set @PerDatum = (select PeriodeBis from FbPeriode where FbPeriodeID = @FbPeriodeID)

  insert @tmp
    select
      KTO.KontoKlasseCode,
      KLA.Text,
      KTO.KontoNr,
      KTO.KontoName,
      KTO.EroeffnungsSaldo,
      isNull(KTO.EroeffnungsSaldo,0) +
      (select isNull(sum(Betrag),0)
       from   FbBuchung
       where  FbPeriodeID = @FbPeriodeID and
              SollKtoNr = KTO.KontoNr and
              Buchungsdatum <= @PerDatum) -
      (select isNull(sum(Betrag),0)
       from   FbBuchung
       where  FbPeriodeID = @FbPeriodeID and
              HabenKtoNr = KTO.KontoNr and
              Buchungsdatum <= @PerDatum),
      KTO.SaldoGruppeName
    from FbKonto KTO
         inner join XLOVCode KLA on KLA.LOVName = ''FbKontoKlasse'' and
                                    KLA.Code = KTO.KontoKlasseCode
    where FbPeriodeID = @FbPeriodeID  AND
          KTO.KontoKlasseCode IN (1,2)AND
          (isNull(@NurMitBuchungen,1) = 0 or exists
            (select 1 from   FbBuchung
             where  FbPeriodeID = @FbPeriodeID and
                    (SollKtoNr = KTO.KontoNr or HabenKtoNr = KTO.KontoNr) and
                    Buchungsdatum <= isNull(@PerDatum,Buchungsdatum)) or
            isNull(KTO.EroeffnungsSaldo,0) <> 0	
          )
    order by KTO.KontoKlasseCode, KTO.KontoNr

  select @Mandant = PRS.Name + isNull('', '' + PRS.Vorname,''''),
         @Geburtsdatum = convert(varchar,PRS.Geburtsdatum,104),
         @DatumBereich = convert(varchar,PER.PeriodeVon,104) + '' - '' +
                         convert(varchar,PER.PeriodeBis,104),
         @Team = TEA.Name
  from   FbPeriode PER
         inner join BaPerson PRS on PRS.BaPersonID = PER.BaPersonID
         left  join FbTeam    TEA on TEA.FbTeamID = PER.FbTeamID
  where  PER.FbPeriodeID = @FbPeriodeID

  --vorzeichen bei passiv- und ertragskonti invertieren
  UPDATE @tmp SET vorsaldo = -vorsaldo, saldo = -saldo WHERE klassecode in (2, 4)

  select Mandant = @Mandant,
         Geburtsdatum = @Geburtsdatum,
         DatumBereich = @DatumBereich,
         Team = @Team,
         Klasse = convert(varchar,KlasseCode) + ''. '' + Klasse,
         KontoNr,
         KontoName,
         EroeffnungsSaldo = VorSaldo ,
         Umsatz = case when KlasseCode in (1,2,99)
                  then Saldo - VorSaldo
                  else null
                  end,
         Saldo,
         PerDatum = @PerDatum
  from   @tmp
  order by KlasseCode,ID' ,  null ,  N'VmFibuBilanz Erfolg' , 1,  1 );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'VmFibuBilanzAufwandErtrag' ,  N'VM - Fibu Bilanz / Erfolg' , 1,  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>E:\KiSS\KiSS4 Produktion\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>en-US</Localization>
///   <References>
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Drawing\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Configuration\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.SqlXml\v4.0_4.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Security\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.Utils.v6.2.dll" />
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
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.Data.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\KiSS4.DB.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\Kiss.Interfaces.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\FluentValidation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\StructureMap.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\log4net.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\SharpLibrary.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtSaldo;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtKontoName;
        private DevExpress.XtraReports.UI.XRLabel txtKontoNr;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel txtKlasse;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
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
                        "QBlAG4AdAAKAgAAAYcEc3RhdGljIFN5c3RlbS5EcmF3aW5nLkZvbnQgZm9udFJlZ3VsYXIgPSBuZXcgU" +
                        "3lzdGVtLkRyYXdpbmcuRm9udCgiQXJpYWwiLDksIFN5c3RlbS5EcmF3aW5nLkZvbnRTdHlsZS5SZWd1b" +
                        "GFyKTsgICAgICANCnN0YXRpYyBTeXN0ZW0uRHJhd2luZy5Gb250IGZvbnRCb2xkID0gbmV3IFN5c3Rlb" +
                        "S5EcmF3aW5nLkZvbnQoIkFyaWFsIiw5LCBTeXN0ZW0uRHJhd2luZy5Gb250U3R5bGUuQm9sZCk7DQoNC" +
                        "nByaXZhdGUgdm9pZCBPbkJlZm9yZVByaW50KG9iamVjdCBzZW5kZXIsIFN5c3RlbS5EcmF3aW5nLlBya" +
                        "W50aW5nLlByaW50RXZlbnRBcmdzIGUpIHsgICANCglpZiAodHh0S29udG9Oci5Ub1N0cmluZygpLkxlb" +
                        "md0aCA+MCkgDQoJew0KCQl0eHRTYWxkby5Gb250ICAgICA9IGZvbnRSZWd1bGFyOw0KCQl0eHRLb250b" +
                        "05hbWUuRm9udCA9IGZvbnRSZWd1bGFyOw0KCX0NCgllbHNlIA0KCXsNCgkJdHh0U2FsZG8uRm9udCAgI" +
                        "CAgPSBmb250Qm9sZDsNCgkJdHh0S29udG9OYW1lLkZvbnQgPSBmb250Qm9sZDsNCgl9DQp9AbkZZGVjb" +
                        "GFyZSBARmJQZXJpb2RlSUQgICAgIGludA0KZGVjbGFyZSBAUGVyRGF0dW0gICAgICAgIGRhdGV0aW1lD" +
                        "QpkZWNsYXJlIEBOdXJNaXRCdWNodW5nZW4gYml0DQoNCnNldCBARmJQZXJpb2RlSUQgICAgID0gbnVsb" +
                        "A0Kc2V0IEBQZXJEYXR1bSAgICAgICAgPSBudWxsDQpzZXQgQE51ck1pdEJ1Y2h1bmdlbiA9IG51bGwNC" +
                        "g0KICBkZWNsYXJlIEBWb3JTYWxkb0FrdGl2ZW4gIG1vbmV5DQogIGRlY2xhcmUgQFZvclNhbGRvUGFzc" +
                        "2l2ZW4gbW9uZXkNCiAgZGVjbGFyZSBAVm9yU2FsZG9BdWZ3YW5kICBtb25leQ0KICBkZWNsYXJlIEBWb" +
                        "3JTYWxkb0VydHJhZyAgIG1vbmV5DQoNCiAgZGVjbGFyZSBAU2FsZG9Ba3RpdmVuICBtb25leQ0KICBkZ" +
                        "WNsYXJlIEBTYWxkb1Bhc3NpdmVuIG1vbmV5DQogIGRlY2xhcmUgQFNhbGRvQXVmd2FuZCAgbW9uZXkNC" +
                        "iAgZGVjbGFyZSBAU2FsZG9FcnRyYWcgICBtb25leQ0KDQogIGRlY2xhcmUgQFRlYW0gICAgICAgICAgd" +
                        "mFyY2hhcig1MCkNCiAgZGVjbGFyZSBARGF0dW1CZXJlaWNoICB2YXJjaGFyKDUwKQ0KICBkZWNsYXJlI" +
                        "EBHZWJ1cnRzZGF0dW0gIHZhcmNoYXIoMjApDQogIGRlY2xhcmUgQE1hbmRhbnQgICAgICAgdmFyY2hhc" +
                        "igyMDApDQoNCiAgZGVjbGFyZSBAdG1wIHRhYmxlKA0KICAgIElEICAgICAgICAgICAgICAgaW50IGlkZ" +
                        "W50aXR5LA0KICAgIEtsYXNzZUNvZGUgICAgICAgaW50LA0KICAgIEtsYXNzZSAgICAgICAgICAgdmFyY" +
                        "2hhcigyMCksDQogICAgS29udG9OciAgICAgICAgICBpbnQsDQogICAgS29udG9OYW1lICAgICAgICB2Y" +
                        "XJjaGFyKDE1MCksDQogICAgVm9yU2FsZG8gICAgICAgICBtb25leSwNCiAgICBTYWxkbyAgICAgICAgI" +
                        "CAgIG1vbmV5LA0KICAgIFNhbGRvR3J1cHBlTmFtZSAgdmFyY2hhcigyMCkpDQoNCiAgaWYgQFBlckRhd" +
                        "HVtIGlzIG51bGwNCiAgICBzZXQgQFBlckRhdHVtID0gKHNlbGVjdCBQZXJpb2RlQmlzIGZyb20gRmJQZ" +
                        "XJpb2RlIHdoZXJlIEZiUGVyaW9kZUlEID0gQEZiUGVyaW9kZUlEKQ0KDQogIGluc2VydCBAdG1wDQogI" +
                        "CAgc2VsZWN0DQogICAgICBLVE8uS29udG9LbGFzc2VDb2RlLA0KICAgICAgS0xBLlRleHQsDQogICAgI" +
                        "CBLVE8uS29udG9OciwNCiAgICAgIEtUTy5Lb250b05hbWUsDQogICAgICBudWxsLA0KICAgICAgaXNOd" +
                        "WxsKEtUTy5Fcm9lZmZudW5nc1NhbGRvLDApICsNCiAgICAgIChzZWxlY3QgaXNOdWxsKHN1bShCZXRyY" +
                        "WcpLDApDQogICAgICAgZnJvbSAgIEZiQnVjaHVuZw0KICAgICAgIHdoZXJlICBGYlBlcmlvZGVJRCA9I" +
                        "EBGYlBlcmlvZGVJRCBhbmQNCiAgICAgICAgICAgICAgU29sbEt0b05yID0gS1RPLktvbnRvTnIgYW5kD" +
                        "QogICAgICAgICAgICAgIEJ1Y2h1bmdzZGF0dW0gPD0gQFBlckRhdHVtKSAtDQogICAgICAoc2VsZWN0I" +
                        "GlzTnVsbChzdW0oQmV0cmFnKSwwKQ0KICAgICAgIGZyb20gICBGYkJ1Y2h1bmcNCiAgICAgICB3aGVyZ" +
                        "SAgRmJQZXJpb2RlSUQgPSBARmJQZXJpb2RlSUQgYW5kDQogICAgICAgICAgICAgIEhhYmVuS3RvTnIgP" +
                        "SBLVE8uS29udG9OciBhbmQNCiAgICAgICAgICAgICAgQnVjaHVuZ3NkYXR1bSA8PSBAUGVyRGF0dW0pL" +
                        "A0KICAgICAgS1RPLlNhbGRvR3J1cHBlTmFtZQ0KICAgIGZyb20gRmJLb250byBLVE8NCiAgICAgICAgI" +
                        "GlubmVyIGpvaW4gWExPVkNvZGUgS0xBIG9uIEtMQS5MT1ZOYW1lID0gJ0ZiS29udG9LbGFzc2UnIGFuZ" +
                        "A0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgS0xBLkNvZGUgPSBLVE8uS29udG9Lb" +
                        "GFzc2VDb2RlDQogICAgd2hlcmUgRmJQZXJpb2RlSUQgPSBARmJQZXJpb2RlSUQgICBBTkQNCiAgICAgI" +
                        "CAgICBLVE8uS29udG9LbGFzc2VDb2RlIElOICgzLDQpIEFORA0KICAgICAgICAgIChpc051bGwoQE51c" +
                        "k1pdEJ1Y2h1bmdlbiwxKSA9IDAgb3IgZXhpc3RzDQogICAgICAgICAgICAoc2VsZWN0IDEgZnJvbSAgI" +
                        "EZiQnVjaHVuZw0KICAgICAgICAgICAgIHdoZXJlICBGYlBlcmlvZGVJRCA9IEBGYlBlcmlvZGVJRCBhb" +
                        "mQNCiAgICAgICAgICAgICAgICAgICAgKFNvbGxLdG9OciA9IEtUTy5Lb250b05yIG9yIEhhYmVuS3RvT" +
                        "nIgPSBLVE8uS29udG9OcikgYW5kDQogICAgICAgICAgICAgICAgICAgIEJ1Y2h1bmdzZGF0dW0gPD0ga" +
                        "XNOdWxsKEBQZXJEYXR1bSxCdWNodW5nc2RhdHVtKSkgb3INCiAgICAgICAgICAgIGlzTnVsbChLVE8uR" +
                        "XJvZWZmbnVuZ3NTYWxkbywwKSA8PiAwCQ0KICAgICAgICAgICkNCiAgICBvcmRlciBieSBLVE8uS29ud" +
                        "G9LbGFzc2VDb2RlLCBLVE8uS29udG9Ocg0KDQogIHNlbGVjdCBATWFuZGFudCA9IFBSUy5OYW1lICsga" +
                        "XNOdWxsKCcsICcgKyBQUlMuVm9ybmFtZSwnJyksDQogICAgICAgICBAR2VidXJ0c2RhdHVtID0gY29ud" +
                        "mVydCh2YXJjaGFyLFBSUy5HZWJ1cnRzZGF0dW0sMTA0KSwNCiAgICAgICAgIEBEYXR1bUJlcmVpY2ggP" +
                        "SBjb252ZXJ0KHZhcmNoYXIsUEVSLlBlcmlvZGVWb24sMTA0KSArICcgLSAnICsNCiAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICBjb252ZXJ0KHZhcmNoYXIsUEVSLlBlcmlvZGVCaXMsMTA0KSwNCiAgICAgICAgI" +
                        "EBUZWFtID0gVEVBLk5hbWUNCiAgZnJvbSAgIEZiUGVyaW9kZSBQRVINCiAgICAgICAgIGlubmVyIGpva" +
                        "W4gQmFQZXJzb24gUFJTIG9uIFBSUy5CYVBlcnNvbklEID0gUEVSLkJhUGVyc29uSUQNCiAgICAgICAgI" +
                        "GxlZnQgIGpvaW4gRmJUZWFtICAgIFRFQSBvbiBURUEuRmJUZWFtSUQgPSBQRVIuRmJUZWFtSUQNCiAgd" +
                        "2hlcmUgIFBFUi5GYlBlcmlvZGVJRCA9IEBGYlBlcmlvZGVJRA0KDQoNCiAgc2VsZWN0IE1hbmRhbnQgP" +
                        "SBATWFuZGFudCwNCiAgICAgICAgIEdlYnVydHNkYXR1bSA9IEBHZWJ1cnRzZGF0dW0sDQogICAgICAgI" +
                        "CBEYXR1bUJlcmVpY2ggPSBARGF0dW1CZXJlaWNoLA0KICAgICAgICAgVGVhbSA9IEBUZWFtLA0KICAgI" +
                        "CAgICAgS2xhc3NlID0gY29udmVydCh2YXJjaGFyLEtsYXNzZUNvZGUpICsgJy4gJyArIEtsYXNzZSwNC" +
                        "iAgICAgICAgIEtvbnRvTnIsDQogICAgICAgICBLb250b05hbWUsDQogICAgICAgICBFcm9lZmZudW5nc" +
                        "1NhbGRvID0gVm9yU2FsZG8gLA0KICAgICAgICAgVW1zYXR6ID0gY2FzZSB3aGVuIEtsYXNzZUNvZGUga" +
                        "W4gKDEsMiw5OSkNCiAgICAgICAgICAgICAgICAgIHRoZW4gU2FsZG8gLSBWb3JTYWxkbw0KICAgICAgI" +
                        "CAgICAgICAgICAgZWxzZSBudWxsDQogICAgICAgICAgICAgICAgICBlbmQsDQogICAgICAgICBTYWxkb" +
                        "ywNCiAgICAgICAgIFBlckRhdHVtID0gQFBlckRhdHVtDQogIGZyb20gICBAdG1wDQogIG9yZGVyIGJ5I" +
                        "EtsYXNzZUNvZGUsSUQ=";
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
            this.txtSaldo = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKontoName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKontoNr = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKlasse = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtSaldo,
                        this.txtKontoName,
                        this.txtKontoNr});
            this.Detail.Height = 15;
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
                        this.xrLine2,
                        this.xrLabel1});
            this.PageHeader.Height = 30;
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
                        this.txtKlasse});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("Klasse", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 30;
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
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel6,
                        this.xrLabel2,
                        this.xrLine1,
                        this.xrLabel5});
            this.GroupFooter1.Height = 53;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorders = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter1.ParentStyleUsing.UseFont = false;
            this.GroupFooter1.ParentStyleUsing.UseForeColor = false;
            // 
            // txtSaldo
            // 
            this.txtSaldo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Saldo", "{0:n2}")});
            this.txtSaldo.Font = new System.Drawing.Font("Arial", 9F);
            this.txtSaldo.ForeColor = System.Drawing.Color.Black;
            this.txtSaldo.Location = new System.Drawing.Point(590, 0);
            this.txtSaldo.Multiline = true;
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtSaldo.ParentStyleUsing.UseBackColor = false;
            this.txtSaldo.ParentStyleUsing.UseBorderColor = false;
            this.txtSaldo.ParentStyleUsing.UseBorders = false;
            this.txtSaldo.ParentStyleUsing.UseBorderWidth = false;
            this.txtSaldo.ParentStyleUsing.UseFont = false;
            this.txtSaldo.ParentStyleUsing.UseForeColor = false;
            this.txtSaldo.Size = new System.Drawing.Size(108, 15);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtSaldo.Summary = xrSummary1;
            this.txtSaldo.Text = "Saldo";
            this.txtSaldo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtKontoName
            // 
            this.txtKontoName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KontoName", "")});
            this.txtKontoName.Font = new System.Drawing.Font("Arial", 9F);
            this.txtKontoName.ForeColor = System.Drawing.Color.Black;
            this.txtKontoName.Location = new System.Drawing.Point(71, 0);
            this.txtKontoName.Multiline = true;
            this.txtKontoName.Name = "txtKontoName";
            this.txtKontoName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKontoName.ParentStyleUsing.UseBackColor = false;
            this.txtKontoName.ParentStyleUsing.UseBorderColor = false;
            this.txtKontoName.ParentStyleUsing.UseBorders = false;
            this.txtKontoName.ParentStyleUsing.UseBorderWidth = false;
            this.txtKontoName.ParentStyleUsing.UseFont = false;
            this.txtKontoName.ParentStyleUsing.UseForeColor = false;
            this.txtKontoName.Size = new System.Drawing.Size(298, 15);
            this.txtKontoName.Text = "KontoName";
            // 
            // txtKontoNr
            // 
            this.txtKontoNr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KontoNr", "")});
            this.txtKontoNr.Font = new System.Drawing.Font("Arial", 9F);
            this.txtKontoNr.ForeColor = System.Drawing.Color.Black;
            this.txtKontoNr.Location = new System.Drawing.Point(0, 0);
            this.txtKontoNr.Multiline = true;
            this.txtKontoNr.Name = "txtKontoNr";
            this.txtKontoNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKontoNr.ParentStyleUsing.UseBackColor = false;
            this.txtKontoNr.ParentStyleUsing.UseBorderColor = false;
            this.txtKontoNr.ParentStyleUsing.UseBorders = false;
            this.txtKontoNr.ParentStyleUsing.UseBorderWidth = false;
            this.txtKontoNr.ParentStyleUsing.UseFont = false;
            this.txtKontoNr.ParentStyleUsing.UseForeColor = false;
            this.txtKontoNr.Size = new System.Drawing.Size(70, 15);
            this.txtKontoNr.Text = "KontoNr";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.Location = new System.Drawing.Point(60, 7);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.ParentStyleUsing.UseForeColor = false;
            this.xrLabel4.Size = new System.Drawing.Size(299, 15);
            this.xrLabel4.Text = "Kontoname";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(0, 7);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(70, 15);
            this.xrLabel3.Text = "Kto-Nr.";
            // 
            // xrLine2
            // 
            this.xrLine2.ForeColor = System.Drawing.Color.Black;
            this.xrLine2.Location = new System.Drawing.Point(0, 27);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.ParentStyleUsing.UseBackColor = false;
            this.xrLine2.ParentStyleUsing.UseBorderColor = false;
            this.xrLine2.ParentStyleUsing.UseBorders = false;
            this.xrLine2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine2.ParentStyleUsing.UseFont = false;
            this.xrLine2.ParentStyleUsing.UseForeColor = false;
            this.xrLine2.Size = new System.Drawing.Size(700, 2);
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.Location = new System.Drawing.Point(587, 7);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseBackColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.ParentStyleUsing.UseForeColor = false;
            this.xrLabel1.Size = new System.Drawing.Size(108, 15);
            this.xrLabel1.Text = "Schlussbestand";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtKlasse
            // 
            this.txtKlasse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Klasse", "")});
            this.txtKlasse.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.txtKlasse.ForeColor = System.Drawing.Color.Black;
            this.txtKlasse.Location = new System.Drawing.Point(0, 0);
            this.txtKlasse.Multiline = true;
            this.txtKlasse.Name = "txtKlasse";
            this.txtKlasse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKlasse.ParentStyleUsing.UseBackColor = false;
            this.txtKlasse.ParentStyleUsing.UseBorderColor = false;
            this.txtKlasse.ParentStyleUsing.UseBorders = false;
            this.txtKlasse.ParentStyleUsing.UseBorderWidth = false;
            this.txtKlasse.ParentStyleUsing.UseFont = false;
            this.txtKlasse.ParentStyleUsing.UseForeColor = false;
            this.txtKlasse.Size = new System.Drawing.Size(236, 23);
            this.txtKlasse.Text = "Klasse";
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Klasse", "")});
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.Location = new System.Drawing.Point(108, 4);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.Scripts.OnBeforePrint = "private void OnBeforePrint(object sender, System.Drawing.Printing.PrintEventArgs " +
                "e) {\r\n    xrLabel6.Text = xrLabel6.Text.Substring(3);\r\n}";
            this.xrLabel6.Size = new System.Drawing.Size(100, 26);
            this.xrLabel6.Text = "xrLabel6";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.Location = new System.Drawing.Point(71, 4);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(35, 15);
            this.xrLabel2.Text = "Total";
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.Location = new System.Drawing.Point(0, 0);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(700, 2);
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Saldo", "")});
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.Location = new System.Drawing.Point(590, 4);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(108, 15);
            xrSummary2.FormatString = "{0:n2}";
            xrSummary2.IgnoreNullValues = true;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel5.Summary = xrSummary2;
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
                        this.GroupFooter1});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(60, 60, 60, 39);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ScriptReferencesString = "System.Windows.Forms.dll\r\n";
            this.Scripts.OnBeforePrint = resources.GetString("Report.Scripts.OnBeforePrint");
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'declare @FbPeriodeID     int
declare @PerDatum        datetime
declare @NurMitBuchungen bit

set @FbPeriodeID     = {FbPeriodeID}
set @PerDatum        = {PerDatum}
set @NurMitBuchungen = {NurMitBuchungen}

  declare @VorSaldoAktiven  money
  declare @VorSaldoPassiven money
  declare @VorSaldoAufwand  money
  declare @VorSaldoErtrag   money

  declare @SaldoAktiven  money
  declare @SaldoPassiven money
  declare @SaldoAufwand  money
  declare @SaldoErtrag   money

  declare @Team          varchar(50)
  declare @DatumBereich  varchar(50)
  declare @Geburtsdatum  varchar(20)
  declare @Mandant       varchar(200)

  declare @tmp table(
    ID               int identity,
    KlasseCode       int,
    Klasse           varchar(20),
    KontoNr          int,
    KontoName        varchar(150),
    VorSaldo         money,
    Saldo            money,
    SaldoGruppeName  varchar(20))

  if @PerDatum is null
    set @PerDatum = (select PeriodeBis from FbPeriode where FbPeriodeID = @FbPeriodeID)

  insert @tmp
    select
      KTO.KontoKlasseCode,
      KLA.Text,
      KTO.KontoNr,
      KTO.KontoName,
      null,
      isNull(KTO.EroeffnungsSaldo,0) +
      (select isNull(sum(Betrag),0)
       from   FbBuchung
       where  FbPeriodeID = @FbPeriodeID and
              SollKtoNr = KTO.KontoNr and
              Buchungsdatum <= @PerDatum) -
      (select isNull(sum(Betrag),0)
       from   FbBuchung
       where  FbPeriodeID = @FbPeriodeID and
              HabenKtoNr = KTO.KontoNr and
              Buchungsdatum <= @PerDatum),
      KTO.SaldoGruppeName
    from FbKonto KTO
         inner join XLOVCode KLA on KLA.LOVName = ''FbKontoKlasse'' and
                                    KLA.Code = KTO.KontoKlasseCode
    where FbPeriodeID = @FbPeriodeID   AND
          KTO.KontoKlasseCode IN (3,4) AND
          (isNull(@NurMitBuchungen,1) = 0 or exists
            (select 1 from   FbBuchung
             where  FbPeriodeID = @FbPeriodeID and
                    (SollKtoNr = KTO.KontoNr or HabenKtoNr = KTO.KontoNr) and
                    Buchungsdatum <= isNull(@PerDatum,Buchungsdatum)) or
            isNull(KTO.EroeffnungsSaldo,0) <> 0	
          )
    order by KTO.KontoKlasseCode, KTO.KontoNr

  select @Mandant = PRS.Name + isNull('', '' + PRS.Vorname,''''),
         @Geburtsdatum = convert(varchar,PRS.Geburtsdatum,104),
         @DatumBereich = convert(varchar,PER.PeriodeVon,104) + '' - '' +
                         convert(varchar,PER.PeriodeBis,104),
         @Team = TEA.Name
  from   FbPeriode PER
         inner join BaPerson PRS on PRS.BaPersonID = PER.BaPersonID
         left  join FbTeam    TEA on TEA.FbTeamID = PER.FbTeamID
  where  PER.FbPeriodeID = @FbPeriodeID

  --vorzeichen bei passiv- und ertragskonti invertieren
  UPDATE @tmp SET vorsaldo = -vorsaldo, saldo = -saldo WHERE klassecode in (2, 4)

  select Mandant = @Mandant,
         Geburtsdatum = @Geburtsdatum,
         DatumBereich = @DatumBereich,
         Team = @Team,
         Klasse = convert(varchar,KlasseCode) + ''. '' + Klasse,
         KontoNr,
         KontoName,
         EroeffnungsSaldo = VorSaldo ,
         Umsatz = case when KlasseCode in (1,2,99)
                  then Saldo - VorSaldo
                  else null
                  end,
         Saldo,
         PerDatum = @PerDatum
  from   @tmp
  order by KlasseCode,ID' ,  null ,  N'VmFibuBilanz Erfolg' ,  null ,  1 );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'VmFibuBilanzEinnahmen' ,  N'VM - Fibu Bilanz / Erfolg' , 1,  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>E:\KiSS\KiSS4 Produktion\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>en-US</Localization>
///   <References>
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Drawing\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Configuration\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.SqlXml\v4.0_4.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Security\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.Utils.v6.2.dll" />
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
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.Data.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\KiSS4.DB.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\Kiss.Interfaces.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\FluentValidation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\StructureMap.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\log4net.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\SharpLibrary.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
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
                        "AAAAbYPZGVjbGFyZSBARmJQZXJpb2RlSUQgICAgIGludA0KZGVjbGFyZSBAUGVyRGF0dW0gICAgICAgI" +
                        "GRhdGV0aW1lDQpkZWNsYXJlIEBOdXJNaXRCdWNodW5nZW4gYml0DQoNCnNldCBARmJQZXJpb2RlSUQgI" +
                        "CAgID0gbnVsbA0Kc2V0IEBQZXJEYXR1bSAgICAgICAgPSBudWxsDQpzZXQgQE51ck1pdEJ1Y2h1bmdlb" +
                        "iA9IG51bGwNCg0KICBkZWNsYXJlIEB0bXAgdGFibGUoDQogICAgS2xhc3NlQ29kZSAgICAgICBpbnQsD" +
                        "QogICAgU2FsZG8gICAgICAgICAgICBtb25leSkNCg0KICBpZiBAUGVyRGF0dW0gaXMgbnVsbA0KICAgI" +
                        "HNldCBAUGVyRGF0dW0gPSAoU0VMRUNUIFBlcmlvZGVCaXMgRlJPTSBGYlBlcmlvZGUgV0hFUkUgRmJQZ" +
                        "XJpb2RlSUQgPSBARmJQZXJpb2RlSUQpDQoNCklOU0VSVCBAdG1wDQogICAgU0VMRUNUDQogICAgICBLV" +
                        "E8uS29udG9LbGFzc2VDb2RlLA0KICAgICAgaXNOdWxsKEtUTy5Fcm9lZmZudW5nc1NhbGRvLDApICsNC" +
                        "iAgICAgIChTRUxFQ1QgaXNOdWxsKHN1bShCZXRyYWcpLDApDQogICAgICAgRlJPTSAgIEZiQnVjaHVuZ" +
                        "w0KICAgICAgIFdIRVJFICBGYlBlcmlvZGVJRCA9IEBGYlBlcmlvZGVJRCBhbmQNCiAgICAgICAgICAgI" +
                        "CAgU29sbEt0b05yID0gS1RPLktvbnRvTnIgYW5kDQogICAgICAgICAgICAgIEJ1Y2h1bmdzZGF0dW0gP" +
                        "D0gQFBlckRhdHVtKSAtDQogICAgICAoU0VMRUNUIGlzTnVsbChzdW0oQmV0cmFnKSwwKQ0KICAgICAgI" +
                        "EZST00gICBGYkJ1Y2h1bmcNCiAgICAgICBXSEVSRSAgRmJQZXJpb2RlSUQgPSBARmJQZXJpb2RlSUQgY" +
                        "W5kDQogICAgICAgICAgICAgIEhhYmVuS3RvTnIgPSBLVE8uS29udG9OciBhbmQNCiAgICAgICAgICAgI" +
                        "CAgQnVjaHVuZ3NkYXR1bSA8PSBAUGVyRGF0dW0pDQogICAgRlJPTSBGYktvbnRvIEtUTw0KICAgICAgI" +
                        "CAgSU5ORVIgam9pbiBYTE9WQ29kZSBLTEEgb24gS0xBLkxPVk5hbWUgPSAnRmJLb250b0tsYXNzZScgY" +
                        "W5kDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBLTEEuQ29kZSA9IEtUTy5Lb250b" +
                        "0tsYXNzZUNvZGUNCiAgICBXSEVSRSBGYlBlcmlvZGVJRCA9IEBGYlBlcmlvZGVJRCBhbmQNCiAgICAgI" +
                        "CAgICBLVE8uS29udG9LbGFzc2VDb2RlIGluICgzLDQpIGFuZA0KICAgICAgICAgIChpc051bGwoQE51c" +
                        "k1pdEJ1Y2h1bmdlbiwxKSA9IDAgb3IgZXhpc3RzDQogICAgICAgICAgICAoU0VMRUNUIDEgRlJPTSAgI" +
                        "EZiQnVjaHVuZw0KICAgICAgICAgICAgIFdIRVJFICBGYlBlcmlvZGVJRCA9IEBGYlBlcmlvZGVJRCBhb" +
                        "mQNCiAgICAgICAgICAgICAgICAgICAgKFNvbGxLdG9OciA9IEtUTy5Lb250b05yIG9yIEhhYmVuS3RvT" +
                        "nIgPSBLVE8uS29udG9OcikgYW5kDQogICAgICAgICAgICAgICAgICAgIEJ1Y2h1bmdzZGF0dW0gPD0ga" +
                        "XNOdWxsKEBQZXJEYXR1bSxCdWNodW5nc2RhdHVtKSkgb3INCiAgICAgICAgICAgIGlzTnVsbChLVE8uR" +
                        "XJvZWZmbnVuZ3NTYWxkbywwKSA8PiAwCQ0KICAgICAgICAgICkNCg0KREVDTEFSRSBAZWlubmFobWVuI" +
                        "E1PTkVZDQpERUNMQVJFIEBhdXNnYWJlbiAgTU9ORVkNCg0KU0VUIEBlaW5uYWhtZW4gPSAoU0VMRUNUI" +
                        "FNVTShTYWxkbykgRlJPTSBAdG1wIFdIRVJFIEtsYXNzZUNvZGU9NCBHUk9VUCBCWSBLbGFzc2VDb2RlK" +
                        "Q0KU0VUIEBhdXNnYWJlbiA9IChTRUxFQ1QgU1VNKFNhbGRvKSBGUk9NIEB0bXAgV0hFUkUgS2xhc3NlQ" +
                        "29kZT0zIEdST1VQIEJZIEtsYXNzZUNvZGUpDQoNClNFTEVDVCBFaW5uYWhtZW4gPSBAZWlubmFobWVuL" +
                        "A0KICAgICAgIEF1c2dhYmVuICA9IEBhdXNnYWJlbiwNCiAgICAgICBNZWhyRWluQXVzZ2FiZSA9IENBU" +
                        "0UgV0hFTiBAZWlubmFobWVuK0BhdXNnYWJlbiA8PSAwIFRIRU4gJ01laHJlaW5uYWhtZW4nDQogICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgIEVMU0UgJ01laHJhdXNnYWJlbicNCiAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgRU5ELA0KICAgICAgIE1laHJhdXNnYWJlbiA9IEBlaW5uYWhtZW4rQGF1c2dhYmVu";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel6,
                        this.xrLabel5,
                        this.xrLabel4,
                        this.xrLabel3,
                        this.xrLine1,
                        this.xrLabel2,
                        this.xrLabel1});
            this.Detail.Font = new System.Drawing.Font("Arial", 9F);
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseFont = false;
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Mehrausgaben", "{0:n2}")});
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.Location = new System.Drawing.Point(590, 38);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.Size = new System.Drawing.Size(108, 15);
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Ausgaben", "{0:n2}")});
            this.xrLabel5.Location = new System.Drawing.Point(590, 15);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.Size = new System.Drawing.Size(108, 15);
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Einnahmen", "{0:n2}")});
            this.xrLabel4.Location = new System.Drawing.Point(590, 0);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.Size = new System.Drawing.Size(108, 15);
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "MehrEinAusgabe", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.Location = new System.Drawing.Point(0, 38);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(125, 15);
            this.xrLabel3.Text = "Mehrausgaben";
            // 
            // xrLine1
            // 
            this.xrLine1.Location = new System.Drawing.Point(0, 33);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(700, 2);
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel2.Location = new System.Drawing.Point(0, 15);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(100, 15);
            this.xrLabel2.Text = "Total Ausgaben";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel1.Location = new System.Drawing.Point(0, 0);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(100, 15);
            this.xrLabel1.Text = "Total Einnahmen";
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.Position = 0;
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(100, 14, 100, 100);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'declare @FbPeriodeID     int
declare @PerDatum        datetime
declare @NurMitBuchungen bit

set @FbPeriodeID     = {FbPeriodeID}
set @PerDatum        = {PerDatum}
set @NurMitBuchungen = {NurMitBuchungen}

  declare @tmp table(
    KlasseCode       int,
    Saldo            money)

  if @PerDatum is null
    set @PerDatum = (SELECT PeriodeBis FROM FbPeriode WHERE FbPeriodeID = @FbPeriodeID)

INSERT @tmp
    SELECT
      KTO.KontoKlasseCode,
      isNull(KTO.EroeffnungsSaldo,0) +
      (SELECT isNull(sum(Betrag),0)
       FROM   FbBuchung
       WHERE  FbPeriodeID = @FbPeriodeID and
              SollKtoNr = KTO.KontoNr and
              Buchungsdatum <= @PerDatum) -
      (SELECT isNull(sum(Betrag),0)
       FROM   FbBuchung
       WHERE  FbPeriodeID = @FbPeriodeID and
              HabenKtoNr = KTO.KontoNr and
              Buchungsdatum <= @PerDatum)
    FROM FbKonto KTO
         INNER join XLOVCode KLA on KLA.LOVName = ''FbKontoKlasse'' and
                                    KLA.Code = KTO.KontoKlasseCode
    WHERE FbPeriodeID = @FbPeriodeID and
          KTO.KontoKlasseCode in (3,4) and
          (isNull(@NurMitBuchungen,1) = 0 or exists
            (SELECT 1 FROM   FbBuchung
             WHERE  FbPeriodeID = @FbPeriodeID and
                    (SollKtoNr = KTO.KontoNr or HabenKtoNr = KTO.KontoNr) and
                    Buchungsdatum <= isNull(@PerDatum,Buchungsdatum)) or
            isNull(KTO.EroeffnungsSaldo,0) <> 0	
          )

--vorzeichen bei passiv- und ertragskonti invertieren
UPDATE @tmp SET saldo = -saldo WHERE klassecode in (2, 4)

DECLARE @einnahmen MONEY
DECLARE @ausgaben  MONEY

SET @einnahmen = (SELECT SUM(Saldo) FROM @tmp WHERE KlasseCode=4 GROUP BY KlasseCode)
SET @ausgaben = (SELECT SUM(Saldo) FROM @tmp WHERE KlasseCode=3 GROUP BY KlasseCode)

SELECT Einnahmen = @einnahmen,
       Ausgaben  = @ausgaben,
       MehrEinAusgabe = CASE WHEN @ausgaben-@einnahmen <= 0 THEN ''Mehreinnahmen''
                             ELSE ''Mehrausgaben''
                          END,
       Mehrausgaben = ABS(@einnahmen-@ausgaben)' ,  null ,  N'VmFibuBilanz Erfolg' ,  null ,  1 );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'VmFibuBilanzSaldoGruppen' ,  N'VM - Fibu Bilanz / Erfolg' , 1,  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>E:\KiSS\KiSS4 Produktion\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>en-US</Localization>
///   <References>
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Drawing\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Configuration\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.SqlXml\v4.0_4.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Security\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.Utils.v6.2.dll" />
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
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.Data.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\KiSS4.DB.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\Kiss.Interfaces.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\FluentValidation.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\StructureMap.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\log4net.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\SharpLibrary.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="E:\KiSS\KiSS4 Produktion\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
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
                        "AAAAYIRZGVjbGFyZSBARmJQZXJpb2RlSUQgICAgIGludA0KZGVjbGFyZSBAUGVyRGF0dW0gICAgICAgI" +
                        "GRhdGV0aW1lDQpkZWNsYXJlIEBOdXJNaXRCdWNodW5nZW4gYml0DQoNCnNldCBARmJQZXJpb2RlSUQgI" +
                        "CAgID0gbnVsbA0Kc2V0IEBQZXJEYXR1bSAgICAgICAgPSBudWxsDQpzZXQgQE51ck1pdEJ1Y2h1bmdlb" +
                        "iA9IG51bGwNCg0KICBkZWNsYXJlIEB0bXAgdGFibGUoDQogICAgSUQgICAgICAgICAgICAgICBpbnQga" +
                        "WRlbnRpdHksDQogICAgS2xhc3NlQ29kZSAgICAgICBpbnQsDQogICAgS2xhc3NlICAgICAgICAgICB2Y" +
                        "XJjaGFyKDIwKSwNCiAgICBLb250b05yICAgICAgICAgIGludCwNCiAgICBLb250b05hbWUgICAgICAgI" +
                        "HZhcmNoYXIoMTUwKSwNCiAgICBWb3JTYWxkbyAgICAgICAgIG1vbmV5LA0KICAgIFNhbGRvICAgICAgI" +
                        "CAgICAgbW9uZXksDQogICAgU2FsZG9HcnVwcGVOYW1lICB2YXJjaGFyKDIwKSkNCg0KICBpZiBAUGVyR" +
                        "GF0dW0gaXMgbnVsbA0KICAgIHNldCBAUGVyRGF0dW0gPSAoc2VsZWN0IFBlcmlvZGVCaXMgZnJvbSBGY" +
                        "lBlcmlvZGUgd2hlcmUgRmJQZXJpb2RlSUQgPSBARmJQZXJpb2RlSUQpDQoNCiAgaW5zZXJ0IEB0bXANC" +
                        "iAgICBzZWxlY3QNCiAgICAgIEtUTy5Lb250b0tsYXNzZUNvZGUsDQogICAgICBLTEEuVGV4dCwNCiAgI" +
                        "CAgIEtUTy5Lb250b05yLA0KICAgICAgS1RPLktvbnRvTmFtZSwNCiAgICAgIGNhc2Ugd2hlbiBLVE8uS" +
                        "29udG9LbGFzc2VDb2RlIGluICgxLDIpDQogICAgICB0aGVuIEtUTy5Fcm9lZmZudW5nc1NhbGRvDQogI" +
                        "CAgICBlbHNlIG51bGwNCiAgICAgIGVuZCwNCiAgICAgIGlzTnVsbChLVE8uRXJvZWZmbnVuZ3NTYWxkb" +
                        "ywwKSArDQogICAgICAoc2VsZWN0IGlzTnVsbChzdW0oQmV0cmFnKSwwKQ0KICAgICAgIGZyb20gICBGY" +
                        "kJ1Y2h1bmcNCiAgICAgICB3aGVyZSAgRmJQZXJpb2RlSUQgPSBARmJQZXJpb2RlSUQgYW5kDQogICAgI" +
                        "CAgICAgICAgIFNvbGxLdG9OciA9IEtUTy5Lb250b05yIGFuZA0KICAgICAgICAgICAgICBCdWNodW5nc" +
                        "2RhdHVtIDw9IEBQZXJEYXR1bSkgLQ0KICAgICAgKHNlbGVjdCBpc051bGwoc3VtKEJldHJhZyksMCkNC" +
                        "iAgICAgICBmcm9tICAgRmJCdWNodW5nDQogICAgICAgd2hlcmUgIEZiUGVyaW9kZUlEID0gQEZiUGVya" +
                        "W9kZUlEIGFuZA0KICAgICAgICAgICAgICBIYWJlbkt0b05yID0gS1RPLktvbnRvTnIgYW5kDQogICAgI" +
                        "CAgICAgICAgIEJ1Y2h1bmdzZGF0dW0gPD0gQFBlckRhdHVtKSwNCiAgICAgIEtUTy5TYWxkb0dydXBwZ" +
                        "U5hbWUNCiAgICBmcm9tIEZiS29udG8gS1RPDQogICAgICAgICBpbm5lciBqb2luIFhMT1ZDb2RlIEtMQ" +
                        "SBvbiBLTEEuTE9WTmFtZSA9ICdGYktvbnRvS2xhc3NlJyBhbmQNCiAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgIEtMQS5Db2RlID0gS1RPLktvbnRvS2xhc3NlQ29kZQ0KICAgIHdoZXJlIEZiU" +
                        "GVyaW9kZUlEID0gQEZiUGVyaW9kZUlEIGFuZA0KICAgICAgICAgIEtUTy5Lb250b0tsYXNzZUNvZGUgP" +
                        "D0gNCBhbmQNCiAgICAgICAgICAoaXNOdWxsKEBOdXJNaXRCdWNodW5nZW4sMSkgPSAwIG9yIGV4aXN0c" +
                        "w0KICAgICAgICAgICAgKHNlbGVjdCAxIGZyb20gICBGYkJ1Y2h1bmcNCiAgICAgICAgICAgICB3aGVyZ" +
                        "SAgRmJQZXJpb2RlSUQgPSBARmJQZXJpb2RlSUQgYW5kDQogICAgICAgICAgICAgICAgICAgIChTb2xsS" +
                        "3RvTnIgPSBLVE8uS29udG9OciBvciBIYWJlbkt0b05yID0gS1RPLktvbnRvTnIpIGFuZA0KICAgICAgI" +
                        "CAgICAgICAgICAgICBCdWNodW5nc2RhdHVtIDw9IGlzTnVsbChAUGVyRGF0dW0sQnVjaHVuZ3NkYXR1b" +
                        "SkpIG9yDQogICAgICAgICAgICBpc051bGwoS1RPLkVyb2VmZm51bmdzU2FsZG8sMCkgPD4gMAkNCiAgI" +
                        "CAgICAgICApDQogICAgb3JkZXIgYnkgS1RPLktvbnRvS2xhc3NlQ29kZSwgS1RPLktvbnRvTnINCg0KU" +
                        "0VMRUNUIE5hbWUgICAgID0gU2FsZG9HcnVwcGVOYW1lLA0KICAgICAgIFZvcnNhbGRvID0gU1VNKFZvc" +
                        "nNhbGRvKSwNCiAgICAgICBBZW5kZXJ1bmc9IElTTlVMTChTVU0oVm9yc2FsZG8pLDApIC0gSVNOVUxMK" +
                        "FNVTShTYWxkbyksIDApLA0KICAgICAgIFNhbGRvICAgID0gU1VNKFNhbGRvKQ0KRlJPTSBAdG1wDQpXS" +
                        "EVSRSBTYWxkb0dydXBwZU5hbWUgaXMgbm90IG51bGwNCkdST1VQIEJZIFNhbGRvR3J1cHBlTmFtZQ0KT" +
                        "1JERVIgQlkgU2FsZG9HcnVwcGVOYW1l";
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
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLine1,
                        this.xrLabel1});
            this.GroupHeader1.Height = 15;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel6,
                        this.xrLabel4,
                        this.xrLabel3,
                        this.xrLabel2});
            this.Detail.Height = 15;
            this.Detail.Name = "Detail";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel5,
                        this.xrLine2});
            this.GroupFooter1.Height = 33;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // xrLine1
            // 
            this.xrLine1.Location = new System.Drawing.Point(0, 13);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(700, 2);
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel1.Location = new System.Drawing.Point(0, 0);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(100, 15);
            this.xrLabel1.Text = "Saldogruppen";
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel6.ForeColor = System.Drawing.Color.Black;
            this.xrLabel6.Location = new System.Drawing.Point(80, 0);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseBackColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorders = false;
            this.xrLabel6.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.ParentStyleUsing.UseForeColor = false;
            this.xrLabel6.Size = new System.Drawing.Size(298, 15);
            this.xrLabel6.Text = "KontoName";
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Vorsaldo", "{0:n2}")});
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.Location = new System.Drawing.Point(370, 0);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.ParentStyleUsing.UseForeColor = false;
            this.xrLabel4.Size = new System.Drawing.Size(108, 15);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.xrLabel4.Summary = xrSummary1;
            this.xrLabel4.Text = "EroeffnungsSaldo";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Aenderung", "{0:n2}")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(480, 0);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(108, 15);
            xrSummary2.FormatString = "{0:#,##0.00}";
            this.xrLabel3.Summary = xrSummary2;
            this.xrLabel3.Text = "Umsatz";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Saldo", "{0:n2}")});
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.Location = new System.Drawing.Point(590, 0);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseBackColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorders = false;
            this.xrLabel2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.ParentStyleUsing.UseForeColor = false;
            this.xrLabel2.Size = new System.Drawing.Size(108, 15);
            xrSummary3.FormatString = "{0:#,##0.00}";
            this.xrLabel2.Summary = xrSummary3;
            this.xrLabel2.Text = "Saldo";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Saldo", "")});
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel5.Location = new System.Drawing.Point(592, 7);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(108, 15);
            xrSummary4.FormatString = "{0:n2}";
            xrSummary4.IgnoreNullValues = true;
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel5.Summary = xrSummary4;
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLine2
            // 
            this.xrLine2.Location = new System.Drawing.Point(590, 0);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.Size = new System.Drawing.Size(108, 2);
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.GroupHeader1,
                        this.Detail,
                        this.GroupFooter1});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(100, 18, 100, 100);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'declare @FbPeriodeID     int
declare @PerDatum        datetime
declare @NurMitBuchungen bit

set @FbPeriodeID     = {FbPeriodeID}
set @PerDatum        = {PerDatum}
set @NurMitBuchungen = {NurMitBuchungen}

  declare @tmp table(
    ID               int identity,
    KlasseCode       int,
    Klasse           varchar(20),
    KontoNr          int,
    KontoName        varchar(150),
    VorSaldo         money,
    Saldo            money,
    SaldoGruppeName  varchar(20))

  if @PerDatum is null
    set @PerDatum = (select PeriodeBis from FbPeriode where FbPeriodeID = @FbPeriodeID)

  insert @tmp
    select
      KTO.KontoKlasseCode,
      KLA.Text,
      KTO.KontoNr,
      KTO.KontoName,
      case when KTO.KontoKlasseCode in (1,2)
      then KTO.EroeffnungsSaldo
      else null
      end,
      isNull(KTO.EroeffnungsSaldo,0) +
      (select isNull(sum(Betrag),0)
       from   FbBuchung
       where  FbPeriodeID = @FbPeriodeID and
              SollKtoNr = KTO.KontoNr and
              Buchungsdatum <= @PerDatum) -
      (select isNull(sum(Betrag),0)
       from   FbBuchung
       where  FbPeriodeID = @FbPeriodeID and
              HabenKtoNr = KTO.KontoNr and
              Buchungsdatum <= @PerDatum),
      KTO.SaldoGruppeName
    from FbKonto KTO
         inner join XLOVCode KLA on KLA.LOVName = ''FbKontoKlasse'' and
                                    KLA.Code = KTO.KontoKlasseCode
    where FbPeriodeID = @FbPeriodeID and
          KTO.KontoKlasseCode <= 4 and
          (isNull(@NurMitBuchungen,1) = 0 or exists
            (select 1 from   FbBuchung
             where  FbPeriodeID = @FbPeriodeID and
                    (SollKtoNr = KTO.KontoNr or HabenKtoNr = KTO.KontoNr) and
                    Buchungsdatum <= isNull(@PerDatum,Buchungsdatum)) or
            isNull(KTO.EroeffnungsSaldo,0) <> 0	
          )
    order by KTO.KontoKlasseCode, KTO.KontoNr

--vorzeichen bei passiv- und ertragskonti invertieren
UPDATE @tmp SET vorsaldo = -vorsaldo, saldo = -saldo WHERE klassecode in (2, 4)

SELECT Name     = SaldoGruppeName,
       Vorsaldo = SUM(Vorsaldo),
       Aenderung= ISNULL(SUM(Vorsaldo),0) - ISNULL(SUM(Saldo), 0),
       Saldo    = SUM(Saldo)
FROM @tmp
WHERE SaldoGruppeName is not null
GROUP BY SaldoGruppeName
ORDER BY SaldoGruppeName' ,  null ,  N'VmFibuBilanz Erfolg' ,  null ,  1 );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'VmFibuBilanzVergleich' ,  N'VM - Fibu Bilanz / Erfolg' , 1,  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>C:\Windows\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>de-CH</Localization>
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
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Deployment\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Deployment.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Core\v4.0_4.0.0.0__b77a5c561934e089\System.Core.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Numerics\v4.0_4.0.0.0__b77a5c561934e089\System.Numerics.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Serialization.Formatters.Soap\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Runtime.Serialization.Formatters.Soap.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Design\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Design.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Data\v4.0_4.0.0.0__b77a5c561934e089\System.Data.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Transactions\v4.0_4.0.0.0__b77a5c561934e089\System.Transactions.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.EnterpriseServices\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.EnterpriseServices.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.DirectoryServices\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Remoting\v4.0_4.0.0.0__b77a5c561934e089\System.Runtime.Remoting.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Web\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Framework\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Framework.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Xaml\v4.0_4.0.0.0__b77a5c561934e089\System.Xaml.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ComponentModel.DataAnnotations\v4.0_4.0.0.0__31bf3856ad364e35\System.ComponentModel.DataAnnotations.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Caching\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Runtime.Caching.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Web.ApplicationServices\v4.0_4.0.0.0__31bf3856ad364e35\System.Web.ApplicationServices.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Web.Services\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.Services.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Utilities.v4.0\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Utilities.v4.0.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.DirectoryServices.Protocols\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.Protocols.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Build.Tasks.v4.0\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Build.Tasks.v4.0.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceProcess\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.ServiceProcess.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Configuration.Install\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.Install.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.Serialization\v4.0_4.0.0.0__b77a5c561934e089\System.Runtime.Serialization.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Internals\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Internals.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\SMDiagnostics\v4.0_4.0.0.0__b77a5c561934e089\SMDiagnostics.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Web.RegularExpressions\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Web.RegularExpressions.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Drawing.Design\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.Design.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Data.OracleClient\v4.0_4.0.0.0__b77a5c561934e089\System.Data.OracleClient.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraEditors.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.Data.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Data.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraBars.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraNavBar.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraCharts.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraRichTextEdit.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\KiSS4.DB.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\Kiss.Interfaces.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\PresentationCore\v4.0_4.0.0.0__31bf3856ad364e35\PresentationCore.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\WindowsBase\v4.0_4.0.0.0__31bf3856ad364e35\WindowsBase.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\UIAutomationProvider\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationProvider.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\UIAutomationTypes\v4.0_4.0.0.0__31bf3856ad364e35\UIAutomationTypes.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Windows.Input.Manipulations\v4.0_4.0.0.0__b77a5c561934e089\System.Windows.Input.Manipulations.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\FluentValidation.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Data.Entity\v4.0_4.0.0.0__b77a5c561934e089\System.Data.Entity.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Xml.Linq\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.Linq.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\log4net.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\Kiss.Infrastructure.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\PresentationFramework\v4.0_4.0.0.0__31bf3856ad364e35\PresentationFramework.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\PresentationUI\v4.0_4.0.0.0__31bf3856ad364e35\PresentationUI.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\ReachFramework\v4.0_4.0.0.0__31bf3856ad364e35\ReachFramework.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\System.Printing\v4.0_4.0.0.0__31bf3856ad364e35\System.Printing.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\Microsoft.Practices.Unity.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\Microsoft.Practices.ServiceLocation.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\Ionic.Zip.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\PdfSharp.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\C1.C1Zip.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\Kiss.BusinessLogic.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\Kiss.DbContext.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\EntityFramework.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.CSharp\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.CSharp.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Dynamic\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Dynamic.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\Kiss.DataAccess.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\HtmlAgilityPack.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\Kiss.BL.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\Kiss.Model.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel\v4.0_4.0.0.0__b77a5c561934e089\System.ServiceModel.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Runtime.DurableInstancing\v4.0_4.0.0.0__31bf3856ad364e35\System.Runtime.DurableInstancing.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Net.Http\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Net.Http.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.IdentityModel\v4.0_4.0.0.0__b77a5c561934e089\System.IdentityModel.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Messaging\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Messaging.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.IdentityModel.Selectors\v4.0_4.0.0.0__b77a5c561934e089\System.IdentityModel.Selectors.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.Transactions.Bridge\v4.0_4.0.0.0__b03f5f7f11d50a3a\Microsoft.Transactions.Bridge.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Activation\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Activation.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Xaml.Hosting\v4.0_4.0.0.0__31bf3856ad364e35\System.Xaml.Hosting.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.ServiceModel.Activities\v4.0_4.0.0.0__31bf3856ad364e35\System.ServiceModel.Activities.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Activities\v4.0_4.0.0.0__31bf3856ad364e35\System.Activities.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_32\Microsoft.VisualBasic.Activities.Compiler\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualBasic.Activities.Compiler.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.VisualBasic\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualBasic.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Management\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Management.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\Microsoft.JScript\v4.0_10.0.0.0__b03f5f7f11d50a3a\Microsoft.JScript.dll" />
///     <Reference Path="C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Activities.DurableInstancing\v4.0_4.0.0.0__31bf3856ad364e35\System.Activities.DurableInstancing.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\KiSS.Common.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\Autofac.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\Common.Logging.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\Kiss.Database.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\WPFLocalizeExtension.dll" />
///     <Reference Path="C:\Program Files (x86)\Bedag Informatik AG\KiSS Integration\XAMLMarkupExtensions.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
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
                        "AAAAbUoZGVjbGFyZSBARmJQZXJpb2RlSUQgICAgIGludA0KZGVjbGFyZSBAUGVyRGF0dW0gICAgICAgI" +
                        "GRhdGV0aW1lDQpkZWNsYXJlIEBOdXJNaXRCdWNodW5nZW4gYml0DQoNCnNldCBARmJQZXJpb2RlSUQgI" +
                        "CAgID0gbnVsbA0Kc2V0IEBQZXJEYXR1bSAgICAgICAgPSBudWxsDQpzZXQgQE51ck1pdEJ1Y2h1bmdlb" +
                        "iA9IG51bGwNCg0KICBkZWNsYXJlIEBWb3JTYWxkb0FrdGl2ZW4gbW9uZXkNCiAgZGVjbGFyZSBAVm9yU" +
                        "2FsZG9QYXNzaXZlbiBtb25leQ0KICBkZWNsYXJlIEBWb3JTYWxkb1Bhc3NpdmVuT2huZUthcGl0YWxLb" +
                        "GllbnQgbW9uZXkNCiAgZGVjbGFyZSBAVm9yU2FsZG9QYXNzaXZlbkthcGl0YWxLbGllbnQgbW9uZXkgI" +
                        "A0KICBkZWNsYXJlIEBWb3JTYWxkb0F1ZndhbmQgbW9uZXkNCiAgZGVjbGFyZSBAVm9yU2FsZG9FcnRyY" +
                        "WcgbW9uZXkNCg0KICBkZWNsYXJlIEBTYWxkb0FrdGl2ZW4gbW9uZXkNCiAgZGVjbGFyZSBAU2FsZG9QY" +
                        "XNzaXZlbiBtb25leQ0KICBkZWNsYXJlIEBTYWxkb1Bhc3NpdmVuS2FwaXRhbEtsaWVudCBtb25leQ0KI" +
                        "CBkZWNsYXJlIEBTYWxkb1Bhc3NpdmVuT2huZUthcGl0YWxLbGllbnQgbW9uZXkNCiAgZGVjbGFyZSBAU" +
                        "2FsZG9BdWZ3YW5kIG1vbmV5DQogIGRlY2xhcmUgQFNhbGRvRXJ0cmFnIG1vbmV5DQoNCiAgZGVjbGFyZ" +
                        "SBAVGVhbSAgICAgICAgICB2YXJjaGFyKDUwKQ0KICBkZWNsYXJlIEBEYXR1bUJlcmVpY2ggIHZhcmNoY" +
                        "XIoNTApDQogIGRlY2xhcmUgQEdlYnVydHNkYXR1bSAgdmFyY2hhcigyMCkNCiAgZGVjbGFyZSBATWFuZ" +
                        "GFudCAgICAgICB2YXJjaGFyKDIwMCkNCg0KICBkZWNsYXJlIEB0bXAgdGFibGUoDQogICAgSUQgICAgI" +
                        "CAgICAgICAgICBpbnQgaWRlbnRpdHksDQogICAgS2xhc3NlQ29kZSAgICAgICBpbnQsDQogICAgS2xhc" +
                        "3NlICAgICAgICAgICB2YXJjaGFyKDIwKSwNCiAgICBLb250b1R5cENvZGUgICAgIGludCwNCiAgICBLb" +
                        "250b05yICAgICAgICAgIGludCwNCiAgICBLb250b05hbWUgICAgICAgIHZhcmNoYXIoMTUwKSwNCiAgI" +
                        "CBWb3JTYWxkbyAgICAgICAgIG1vbmV5LA0KICAgIFNhbGRvICAgICAgICAgICAgbW9uZXksDQogICAgU" +
                        "2FsZG9HcnVwcGVOYW1lICB2YXJjaGFyKDIwKSkNCg0KICBpZiBAUGVyRGF0dW0gaXMgbnVsbA0KICAgI" +
                        "HNldCBAUGVyRGF0dW0gPSAoc2VsZWN0IFBlcmlvZGVCaXMgZnJvbSBGYlBlcmlvZGUgd2hlcmUgRmJQZ" +
                        "XJpb2RlSUQgPSBARmJQZXJpb2RlSUQpDQoNCiAgaW5zZXJ0IEB0bXANCiAgICBzZWxlY3QNCiAgICAgI" +
                        "EtUTy5Lb250b0tsYXNzZUNvZGUsDQogICAgICBLTEEuVGV4dCwNCiAgICAgIEtUTy5Lb250b1R5cENvZ" +
                        "GUsDQogICAgICBLVE8uS29udG9OciwNCiAgICAgIEtUTy5Lb250b05hbWUsDQogICAgICBDQVNFIFdIR" +
                        "U4gS1RPLktvbnRvS2xhc3NlQ29kZSBpbiAoMSwyKQ0KICAgICAgICAgICAgICAgIFRIRU4gS1RPLkVyb" +
                        "2VmZm51bmdzU2FsZG8NCiAgICAgICAgICAgRUxTRSBOVUxMDQogICAgICBFTkQsDQogICAgICBpc051b" +
                        "GwoS1RPLkVyb2VmZm51bmdzU2FsZG8sMCkgKw0KICAgICAgKHNlbGVjdCBpc051bGwoc3VtKEJldHJhZ" +
                        "yksMCkNCiAgICAgICBmcm9tICAgRmJCdWNodW5nDQogICAgICAgd2hlcmUgIEZiUGVyaW9kZUlEID0gQ" +
                        "EZiUGVyaW9kZUlEIGFuZA0KICAgICAgICAgICAgICBTb2xsS3RvTnIgPSBLVE8uS29udG9OciBhbmQNC" +
                        "iAgICAgICAgICAgICAgQnVjaHVuZ3NkYXR1bSA8PSBAUGVyRGF0dW0pIC0NCiAgICAgIChzZWxlY3Qga" +
                        "XNOdWxsKHN1bShCZXRyYWcpLDApDQogICAgICAgZnJvbSAgIEZiQnVjaHVuZw0KICAgICAgIHdoZXJlI" +
                        "CBGYlBlcmlvZGVJRCA9IEBGYlBlcmlvZGVJRCBhbmQNCiAgICAgICAgICAgICAgSGFiZW5LdG9OciA9I" +
                        "EtUTy5Lb250b05yIGFuZA0KICAgICAgICAgICAgICBCdWNodW5nc2RhdHVtIDw9IEBQZXJEYXR1bSksD" +
                        "QogICAgICBLVE8uU2FsZG9HcnVwcGVOYW1lDQogICAgZnJvbSBGYktvbnRvIEtUTw0KICAgICAgICAga" +
                        "W5uZXIgam9pbiBYTE9WQ29kZSBLTEEgb24gS0xBLkxPVk5hbWUgPSAnRmJLb250b0tsYXNzZScgYW5kD" +
                        "QogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBLTEEuQ29kZSA9IEtUTy5Lb250b0tsY" +
                        "XNzZUNvZGUNCiAgICB3aGVyZSBGYlBlcmlvZGVJRCA9IEBGYlBlcmlvZGVJRCBhbmQNCiAgICAgICAgL" +
                        "S0gIChLVE8uS29udG9LbGFzc2VDb2RlIDw+IDIgT1IgS1RPLktvbnRvVHlwQ29kZSA8PiA2KSAgIEFOR" +
                        "CAgICAgICAtLSBvaG5lIEthcGl0YWwgS2xpZW50DQogICAgICAgICAgS1RPLktvbnRvS2xhc3NlQ29kZ" +
                        "SA8PSA0IGFuZA0KICAgICAgICAgIChpc051bGwoQE51ck1pdEJ1Y2h1bmdlbiwxKSA9IDAgb3IgZXhpc" +
                        "3RzDQogICAgICAgICAgICAoc2VsZWN0IDEgZnJvbSAgIEZiQnVjaHVuZw0KICAgICAgICAgICAgIHdoZ" +
                        "XJlICBGYlBlcmlvZGVJRCA9IEBGYlBlcmlvZGVJRCBhbmQNCiAgICAgICAgICAgICAgICAgICAgKFNvb" +
                        "GxLdG9OciA9IEtUTy5Lb250b05yIG9yIEhhYmVuS3RvTnIgPSBLVE8uS29udG9OcikgYW5kDQogICAgI" +
                        "CAgICAgICAgICAgICAgIEJ1Y2h1bmdzZGF0dW0gPD0gaXNOdWxsKEBQZXJEYXR1bSxCdWNodW5nc2Rhd" +
                        "HVtKSkgb3INCiAgICAgICAgICAgIGlzTnVsbChLVE8uRXJvZWZmbnVuZ3NTYWxkbywwKSA8PiAwCQ0KI" +
                        "CAgICAgICAgICkNCiAgICBvcmRlciBieSBLVE8uS29udG9LbGFzc2VDb2RlLCBLVE8uS29udG9Ocg0KD" +
                        "QogIC0tdm9yemVpY2hlbiBiZWkgcGFzc2l2LSB1bmQgZXJ0cmFnc2tvbnRpIGludmVydGllcmVuDQogI" +
                        "FVQREFURSBAdG1wIFNFVCB2b3JzYWxkbyA9IC12b3JzYWxkbywgc2FsZG8gPSAtc2FsZG8gV0hFUkUga" +
                        "2xhc3NlY29kZSBpbiAoMiwgNCkNCg0KICBzZWxlY3QgQFNhbGRvQWt0aXZlbiA9IHN1bShTYWxkbyksI" +
                        "EBWb3JTYWxkb0FrdGl2ZW4gPSBzdW0oVm9yU2FsZG8pIGZyb20gQHRtcCB3aGVyZSBLbGFzc2VDb2RlI" +
                        "D0gMQ0KICBzZWxlY3QgQFNhbGRvUGFzc2l2ZW4gPSBzdW0oU2FsZG8pLCBAVm9yU2FsZG9QYXNzaXZlb" +
                        "iA9IHN1bShWb3JTYWxkbykgZnJvbSBAdG1wIHdoZXJlIEtsYXNzZUNvZGUgPSAyDQogIHNlbGVjdCBAU" +
                        "2FsZG9QYXNzaXZlbk9obmVLYXBpdGFsS2xpZW50ID0gc3VtKFNhbGRvKSwgQFZvclNhbGRvUGFzc2l2Z" +
                        "W5PaG5lS2FwaXRhbEtsaWVudCA9IHN1bShWb3JTYWxkbykgZnJvbSBAdG1wIHdoZXJlIEtsYXNzZUNvZ" +
                        "GUgPSAyIGFuZCBLb250b1R5cENvZGUgPD4gNg0KICBzZWxlY3QgQFNhbGRvUGFzc2l2ZW5LYXBpdGFsS" +
                        "2xpZW50ID0gc3VtKFNhbGRvKSwgQFZvclNhbGRvUGFzc2l2ZW5LYXBpdGFsS2xpZW50ID0gc3VtKFZvc" +
                        "lNhbGRvKSBmcm9tIEB0bXAgd2hlcmUgS2xhc3NlQ29kZSA9IDIgYW5kIEtvbnRvVHlwQ29kZSA9IDYNC" +
                        "iAgc2VsZWN0IEBTYWxkb0F1ZndhbmQgPSBzdW0oU2FsZG8pLCBAVm9yU2FsZG9BdWZ3YW5kID0gc3VtK" +
                        "FZvclNhbGRvKSBmcm9tIEB0bXAgd2hlcmUgS2xhc3NlQ29kZSA9IDMNCiAgc2VsZWN0IEBTYWxkb0Vyd" +
                        "HJhZyA9IHN1bShTYWxkbyksIEBWb3JTYWxkb0VydHJhZyA9IHN1bShWb3JTYWxkbykgZnJvbSBAdG1wI" +
                        "HdoZXJlIEtsYXNzZUNvZGUgPSA0DQoNCg0KU0VMRUNUIFNhbGRvQWt0aXZlbiA9IElTTlVMTChAU2FsZ" +
                        "G9Ba3RpdmVuLCAwLjAwKSwNCiAgICAgICBWb3JTYWxkb0FrdGl2ZW4gPSBJU05VTEwoQFZvclNhbGRvQ" +
                        "Wt0aXZlbiwgMC4wMCksDQogICAgICAgU2FsZG9QYXNzaXZlbiA9IElTTlVMTChAU2FsZG9QYXNzaXZlb" +
                        "iwgMC4wMCksDQogICAgICAgU2FsZG9QYXNzaXZlbk9obmVLYXBpdGFsS2xpZW50ID0gSVNOVUxMKEBTY" +
                        "Wxkb1Bhc3NpdmVuT2huZUthcGl0YWxLbGllbnQsIDAuMDApLA0KICAgICAgIFNhbGRvUGFzc2l2ZW5LY" +
                        "XBpdGFsS2xpZW50ID0gSVNOVUxMKEBTYWxkb1Bhc3NpdmVuS2FwaXRhbEtsaWVudCwgMC4wMCksDQogI" +
                        "CAgICAgVm9yU2FsZG9QYXNzaXZlbiA9IElTTlVMTChAVm9yU2FsZG9QYXNzaXZlbiwgMC4wMCksDQogI" +
                        "CAgICAgVm9yU2FsZG9QYXNzaXZlbk9obmVLYXBpdGFsS2xpZW50ID0gSVNOVUxMKEBWb3JTYWxkb1Bhc" +
                        "3NpdmVuT2huZUthcGl0YWxLbGllbnQsIDAuMDApLA0KICAgICAgIFZvclNhbGRvUGFzc2l2ZW5LYXBpd" +
                        "GFsS2xpZW50ID0gSVNOVUxMKEBWb3JTYWxkb1Bhc3NpdmVuS2FwaXRhbEtsaWVudCwgMC4wMCksDQogI" +
                        "CAgICAgU2FsZG9BdWZ3YW5kID0gSVNOVUxMKEBTYWxkb0F1ZndhbmQsIDAuMDApLA0KICAgICAgIFZvc" +
                        "lNhbGRvQXVmd2FuZCA9IElTTlVMTChAVm9yU2FsZG9BdWZ3YW5kLCAwLjAwKSwNCiAgICAgICBTYWxkb" +
                        "0VydHJhZyA9IElTTlVMTChAU2FsZG9FcnRyYWcsIDAuMDApLA0KICAgICAgIFZvclNhbGRvRXJ0cmFnI" +
                        "D0gSVNOVUxMKEBWb3JTYWxkb0VydHJhZywgMC4wMCksDQogICAgICAgTmV1ZXNWZXJtb2VnZW4gPSBJU" +
                        "05VTEwoQFNhbGRvQWt0aXZlbiwgMC4wMCkgKyBJU05VTEwoQFNhbGRvUGFzc2l2ZW5PaG5lS2FwaXRhb" +
                        "EtsaWVudCwgMC4wMCksDQogICAgICAgQWx0ZXNWZXJtb2VnZW4gPSBJU05VTEwoQFZvclNhbGRvQWt0a" +
                        "XZlbiwgMC4wMCkgKyBJU05VTEwoQFZvclNhbGRvUGFzc2l2ZW5PaG5lS2FwaXRhbEtsaWVudCwgMC4wM" +
                        "CksDQogICAgICAgVmVybW9lZ2Vuc2FibmFobWUgPSBBQlMoKElTTlVMTChAVm9yU2FsZG9Ba3RpdmVuL" +
                        "CAwLjAwKSAtIElTTlVMTChAU2FsZG9Ba3RpdmVuLCAwLjAwKSkgKyAoSVNOVUxMKEBWb3JTYWxkb1Bhc" +
                        "3NpdmVuLCAwLjAwKSAtIElTTlVMTChAU2FsZG9QYXNzaXZlbiwgMC4wMCkpKSwNCiAgICAgICBadUFib" +
                        "mFobWUgICAgICAgID0gQ0FTRSBXSEVOICgoSVNOVUxMKEBTYWxkb0FrdGl2ZW4sIDAuMDApIC0gSVNOV" +
                        "UxMKEBWb3JTYWxkb0FrdGl2ZW4sIDAuMDApKSArIChJU05VTEwoQFNhbGRvUGFzc2l2ZW4sIDAuMDApI" +
                        "C0gSVNOVUxMKEBWb3JTYWxkb1Bhc3NpdmVuLCAwLjAwKSkpIDwgMA0KICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgIFRIRU4gJ1Zlcm3DtmdlbnNhYm5haG1lJw0KICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgIEVMU0UgJ1Zlcm3DtmdlbnN6dW5haG1lJw0KICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CBFTkQsDQogICAgICAgUGVyRGF0dW0gICAgICAgICA9IEBQZXJEYXR1bSwNCiAgICAgICBBbHRQZXJEY" +
                        "XR1bSAgICAgID0gKHNlbGVjdCBQZXJpb2RlVm9uIGZyb20gRmJQZXJpb2RlIHdoZXJlIEZiUGVyaW9kZ" +
                        "UlEID0gQEZiUGVyaW9kZUlEKQ==";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel12,
                        this.xrLabel11,
                        this.xrLine2,
                        this.xrLabel10,
                        this.xrLabel9,
                        this.xrLabel8,
                        this.xrLabel7,
                        this.xrLabel6,
                        this.xrLabel5,
                        this.xrLine1,
                        this.xrLabel4,
                        this.xrLabel3,
                        this.xrLabel2,
                        this.xrLabel1});
            this.PageHeader.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.PageHeader.Height = 130;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.ParentStyleUsing.UseFont = false;
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Vermoegensabnahme", "{0:n2}")});
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel12.Location = new System.Drawing.Point(590, 89);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.ParentStyleUsing.UseFont = false;
            this.xrLabel12.Size = new System.Drawing.Size(108, 15);
            this.xrLabel12.Text = "xrLabel12";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ZuAbnahme", "")});
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.Location = new System.Drawing.Point(0, 89);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.ParentStyleUsing.UseFont = false;
            this.xrLabel11.Size = new System.Drawing.Size(147, 20);
            this.xrLabel11.Text = "Vermögensabnahme";
            // 
            // xrLine2
            // 
            this.xrLine2.Location = new System.Drawing.Point(0, 80);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.Size = new System.Drawing.Size(700, 2);
            // 
            // xrLabel10
            // 
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AltesVermoegen", "{0:n2}")});
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel10.Location = new System.Drawing.Point(590, 58);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.ParentStyleUsing.UseFont = false;
            this.xrLabel10.Size = new System.Drawing.Size(108, 15);
            this.xrLabel10.Text = "xrLabel10";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AltPerDatum", "Altes Vermögen per {0:dd.MM.yyyy}")});
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel9.Location = new System.Drawing.Point(0, 58);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.Size = new System.Drawing.Size(213, 14);
            this.xrLabel9.Text = "Altes Vermögen per <TODO>";
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "PerDatum", "Neues Vermögen per {0:dd.MM.yyyy}")});
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.Location = new System.Drawing.Point(0, 42);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.Size = new System.Drawing.Size(213, 14);
            this.xrLabel8.Text = "Neues Vermögen per <TODO>";
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NeuesVermoegen", "{0:n2}")});
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.xrLabel7.Location = new System.Drawing.Point(590, 42);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.Size = new System.Drawing.Size(108, 15);
            this.xrLabel7.Text = "xrLabel7";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel6.Location = new System.Drawing.Point(0, 17);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.Size = new System.Drawing.Size(213, 14);
            this.xrLabel6.Text = "Total Passiven ohne Kapital Klient";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel5.Location = new System.Drawing.Point(0, 0);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(213, 14);
            this.xrLabel5.Text = "Total Aktiven";
            // 
            // xrLine1
            // 
            this.xrLine1.Location = new System.Drawing.Point(0, 36);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(700, 2);
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VorSaldoPassivenOhneKapitalKlient", "{0:n2}")});
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel4.Location = new System.Drawing.Point(342, 17);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(133, 14);
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VorSaldoAktiven", "{0:n2}")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel3.Location = new System.Drawing.Point(342, 0);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(133, 14);
            this.xrLabel3.Text = "xrLabel3";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SaldoPassivenOhneKapitalKlient", "{0:n2}")});
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel2.Location = new System.Drawing.Point(590, 17);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(108, 15);
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SaldoAktiven", "{0:n2}")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel1.Location = new System.Drawing.Point(590, 0);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(108, 15);
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.Position = 0;
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.PageHeader});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(100, 21, 100, 100);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' ,  null ,  N'declare @FbPeriodeID     int
declare @PerDatum        datetime
declare @NurMitBuchungen bit

set @FbPeriodeID     = {FbPeriodeID}
set @PerDatum        = {PerDatum}
set @NurMitBuchungen = {NurMitBuchungen}

  declare @VorSaldoAktiven money
  declare @VorSaldoPassiven money
  declare @VorSaldoPassivenOhneKapitalKlient money
  declare @VorSaldoPassivenKapitalKlient money  
  declare @VorSaldoAufwand money
  declare @VorSaldoErtrag money

  declare @SaldoAktiven money
  declare @SaldoPassiven money
  declare @SaldoPassivenKapitalKlient money
  declare @SaldoPassivenOhneKapitalKlient money
  declare @SaldoAufwand money
  declare @SaldoErtrag money

  declare @Team          varchar(50)
  declare @DatumBereich  varchar(50)
  declare @Geburtsdatum  varchar(20)
  declare @Mandant       varchar(200)

  declare @tmp table(
    ID               int identity,
    KlasseCode       int,
    Klasse           varchar(20),
    KontoTypCode     int,
    KontoNr          int,
    KontoName        varchar(150),
    VorSaldo         money,
    Saldo            money,
    SaldoGruppeName  varchar(20))

  if @PerDatum is null
    set @PerDatum = (select PeriodeBis from FbPeriode where FbPeriodeID = @FbPeriodeID)

  insert @tmp
    select
      KTO.KontoKlasseCode,
      KLA.Text,
      KTO.KontoTypCode,
      KTO.KontoNr,
      KTO.KontoName,
      CASE WHEN KTO.KontoKlasseCode in (1,2)
                THEN KTO.EroeffnungsSaldo
           ELSE NULL
      END,
      isNull(KTO.EroeffnungsSaldo,0) +
      (select isNull(sum(Betrag),0)
       from   FbBuchung
       where  FbPeriodeID = @FbPeriodeID and
              SollKtoNr = KTO.KontoNr and
              Buchungsdatum <= @PerDatum) -
      (select isNull(sum(Betrag),0)
       from   FbBuchung
       where  FbPeriodeID = @FbPeriodeID and
              HabenKtoNr = KTO.KontoNr and
              Buchungsdatum <= @PerDatum),
      KTO.SaldoGruppeName
    from FbKonto KTO
         inner join XLOVCode KLA on KLA.LOVName = ''FbKontoKlasse'' and
                                    KLA.Code = KTO.KontoKlasseCode
    where FbPeriodeID = @FbPeriodeID and
        --  (KTO.KontoKlasseCode <> 2 OR KTO.KontoTypCode <> 6)   AND       -- ohne Kapital Klient
          KTO.KontoKlasseCode <= 4 and
          (isNull(@NurMitBuchungen,1) = 0 or exists
            (select 1 from   FbBuchung
             where  FbPeriodeID = @FbPeriodeID and
                    (SollKtoNr = KTO.KontoNr or HabenKtoNr = KTO.KontoNr) and
                    Buchungsdatum <= isNull(@PerDatum,Buchungsdatum)) or
            isNull(KTO.EroeffnungsSaldo,0) <> 0	
          )
    order by KTO.KontoKlasseCode, KTO.KontoNr

  --vorzeichen bei passiv- und ertragskonti invertieren
  UPDATE @tmp SET vorsaldo = -vorsaldo, saldo = -saldo WHERE klassecode in (2, 4)

  select @SaldoAktiven = sum(Saldo), @VorSaldoAktiven = sum(VorSaldo) from @tmp where KlasseCode = 1
  select @SaldoPassiven = sum(Saldo), @VorSaldoPassiven = sum(VorSaldo) from @tmp where KlasseCode = 2
  select @SaldoPassivenOhneKapitalKlient = sum(Saldo), @VorSaldoPassivenOhneKapitalKlient = sum(VorSaldo) from @tmp where KlasseCode = 2 and KontoTypCode <> 6
  select @SaldoPassivenKapitalKlient = sum(Saldo), @VorSaldoPassivenKapitalKlient = sum(VorSaldo) from @tmp where KlasseCode = 2 and KontoTypCode = 6
  select @SaldoAufwand = sum(Saldo), @VorSaldoAufwand = sum(VorSaldo) from @tmp where KlasseCode = 3
  select @SaldoErtrag = sum(Saldo), @VorSaldoErtrag = sum(VorSaldo) from @tmp where KlasseCode = 4


SELECT SaldoAktiven = ISNULL(@SaldoAktiven, 0.00),
       VorSaldoAktiven = ISNULL(@VorSaldoAktiven, 0.00),
       SaldoPassiven = ISNULL(@SaldoPassiven, 0.00),
       SaldoPassivenOhneKapitalKlient = ISNULL(@SaldoPassivenOhneKapitalKlient, 0.00),
       SaldoPassivenKapitalKlient = ISNULL(@SaldoPassivenKapitalKlient, 0.00),
       VorSaldoPassiven = ISNULL(@VorSaldoPassiven, 0.00),
       VorSaldoPassivenOhneKapitalKlient = ISNULL(@VorSaldoPassivenOhneKapitalKlient, 0.00),
       VorSaldoPassivenKapitalKlient = ISNULL(@VorSaldoPassivenKapitalKlient, 0.00),
       SaldoAufwand = ISNULL(@SaldoAufwand, 0.00),
       VorSaldoAufwand = ISNULL(@VorSaldoAufwand, 0.00),
       SaldoErtrag = ISNULL(@SaldoErtrag, 0.00),
       VorSaldoErtrag = ISNULL(@VorSaldoErtrag, 0.00),
       NeuesVermoegen = ISNULL(@SaldoAktiven, 0.00) - ISNULL(@SaldoPassivenOhneKapitalKlient, 0.00),
       AltesVermoegen = ISNULL(@VorSaldoAktiven, 0.00) - ISNULL(@VorSaldoPassivenOhneKapitalKlient, 0.00),
       Vermoegensabnahme = ABS((ISNULL(@SaldoAktiven, 0.00) - ISNULL(@SaldoPassivenOhneKapitalKlient, 0.00))-(ISNULL(@VorSaldoAktiven, 0.00) - ISNULL(@VorSaldoPassivenOhneKapitalKlient, 0.00))),
       ZuAbnahme        = CASE WHEN ((ISNULL(@SaldoAktiven, 0.00) - ISNULL(@SaldoPassivenOhneKapitalKlient, 0.00))-(ISNULL(@VorSaldoAktiven, 0.00) - ISNULL(@VorSaldoPassivenOhneKapitalKlient, 0.00))) < 0
                               THEN ''Vermögensabnahme''
                               ELSE ''Vermögenszunahme''
                          END,
       PerDatum         = @PerDatum,
       AltPerDatum      = (select PeriodeVon from FbPeriode where FbPeriodeID = @FbPeriodeID)' ,  null ,  N'VmFibuBilanz Erfolg' , 2,  1 );


