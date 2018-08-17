-- Insert Script for ShUebersichtMonatsbudget2
DELETE FROM XQuery WHERE QueryName LIKE 'ShUebersichtMonatsbudget2' OR ParentReportName LIKE 'ShUebersichtMonatsbudget2'
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShUebersichtMonatsbudget2' ,  N'SH - Übersicht Monatsbudget' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Temp\KiSS4_Migration\KiSS4.DB.dll" />
///     <Reference Path="C:\Temp\KiSS4_Migration\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.Subreport ShUebersichtMonatsbudget2_Zahlungen;
        private DevExpress.XtraReports.UI.Subreport ShUebersichtMonatsbudget2_Uebersicht;
        private DevExpress.XtraReports.UI.Subreport ShUebersichtMonatsbudget2_Budget;
        private DevExpress.XtraReports.UI.Subreport ShUebersichtMonatsbudget2_Unterst;
        private DevExpress.XtraReports.UI.XRLabel txtOrgPlzOrt;
        private DevExpress.XtraReports.UI.XRLabel txtOrgAdr;
        private DevExpress.XtraReports.UI.XRLabel txtOrg;
        private DevExpress.XtraReports.UI.XRLabel txtZust;
        private DevExpress.XtraReports.UI.XRLabel txtOrt;
        private DevExpress.XtraReports.UI.XRLabel txtStrasse;
        private DevExpress.XtraReports.UI.XRLabel lblStatus;
        private DevExpress.XtraReports.UI.XRLabel txtStatus;
        private DevExpress.XtraReports.UI.XRLabel txtName;
        private DevExpress.XtraReports.UI.XRControl shpAdr;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel lblFooterLeft;
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
                        "AAAAZwNU0VMRUNUDQogIE9yZ19OYW1lICAgID0gSXNOdWxsKENPTlZFUlQodmFyY2hhcigxMDAwKSwgZ" +
                        "GJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc2VcU296aWFsaGlsZmVcT3JnYW5pc2F0aW9uJywgR2V0R" +
                        "GF0ZSgpKSksICcnKSwNCiAgT3JnX0FkcmVzc2UgPSBJc051bGwoQ09OVkVSVCh2YXJjaGFyKDEwMDApL" +
                        "CBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxBZHJlc3NlJywgR2V0RGF0Z" +
                        "SgpKSksICcnKSwNCiAgT3JnX1BMWiAgICAgPSBJc051bGwoQ09OVkVSVCh2YXJjaGFyKDEwMDApLCBkY" +
                        "m8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxQTFonLCBHZXREYXRlKCkpKSwgJ" +
                        "ycpLA0KICBPcmdfT3J0ICAgICA9IElzTnVsbChDT05WRVJUKHZhcmNoYXIoMTAwMCksIGRiby5mblhDb" +
                        "25maWcoJ1N5c3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlXE9ydCcsIEdldERhdGUoKSkpLCAnJyksDQogI" +
                        "E9yZ19QTFpPcnQgID0gSXNOdWxsKENPTlZFUlQodmFyY2hhcigxMDAwKSwgZGJvLmZuWENvbmZpZygnU" +
                        "3lzdGVtXEFkcmVzc2VcU296aWFsaGlsZmVcUExaJywgR2V0RGF0ZSgpKSkgKyAnICcsICcnKQ0KICAgI" +
                        "CAgICAgICAgICArIElzTnVsbChDT05WRVJUKHZhcmNoYXIoMTAwMCksIGRiby5mblhDb25maWcoJ1N5c" +
                        "3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlXE9ydCcsIEdldERhdGUoKSkpLCAnJyksDQogIEJCRy5CZ0J1Z" +
                        "GdldElELA0KICBKYWhyICAgICAgID0gQ09OVkVSVChEQVRFVElNRSwgQ09OVkVSVChWQVJDSEFSLEJCR" +
                        "y5KYWhyKSksIA0KICBNb25hdCAgICAgID0gREFURUFERChtLEJCRy5Nb25hdCwgJzIwMDAxMjAxJyksD" +
                        "QotLSAgRGF0dW0gICAgICA9IGRiby5mbkRhdGVTZXJpYWwoQkJHLkphaHIsIEJCRy5Nb25hdCwgMSksD" +
                        "QogIFN0YXR1cyAgICAgPSBJc051bGwoJ01vbmF0c2J1ZGdldCAnICsgQkJHX0xPVi5UZXh0LCAnPycpL" +
                        "A0KICBTdGF0dXNDb2RlID0gQkJHLkJnQmV3aWxsaWd1bmdTdGF0dXNDb2RlLA0KICBOYW1lICAgICAgI" +
                        "D0gUFJTLlZvcm5hbWVOYW1lLA0KICBTdHJhc3NlICAgID0gUFJTLldvaG5zaXR6U3RyYXNzZUhhdXNOc" +
                        "iwNCiAgT3J0ICAgICAgICA9IFBSUy5Xb2huc2l0elBMWk9ydCwNCiAgWnVzdCAgICAgICA9IElzTnVsb" +
                        "ChVU1IuRmlyc3ROYW1lKycgJywgJycpICsgSXNOdWxsKFVTUi5MYXN0TmFtZSwgJycpDQpGUk9NIEJnQ" +
                        "nVkZ2V0ICAgICAgICAgICAgICBCQkcNCiAgSU5ORVIgSk9JTiBCZ0ZpbmFuenBsYW4gIFNGUCBvbiBTR" +
                        "lAuQmdGaW5hbnpwbGFuSUQgPSBCQkcuQmdGaW5hbnpwbGFuSUQNCiAgSU5ORVIgSk9JTiBGYUxlaXN0d" +
                        "W5nICAgIEZBTCBvbiBGQUwuRmFMZWlzdHVuZ0lEID0gU0ZQLkZhTGVpc3R1bmdJRA0KICBJTk5FUiBKT" +
                        "0lOIHZ3UGVyc29uICAgICAgUFJTIG9uIFBSUy5CYVBlcnNvbklEID0gRkFMLkJhUGVyc29uSUQNCiAgS" +
                        "U5ORVIgSk9JTiBYVXNlciAgICAgICAgIFVTUiBvbiBVU1IuVXNlcklEID0gRkFMLlVzZXJJRA0KICBMR" +
                        "UZUICBKT0lOIFhMT1ZDb2RlICBCQkdfTE9WIG9uIEJCR19MT1YuTE9WTmFtZSA9ICdCZ0Jld2lsbGlnd" +
                        "W5nU3RhdHVzJyBBTkQgQkJHX0xPVi5Db2RlID0gQkJHLkJnQmV3aWxsaWd1bmdTdGF0dXNDb2RlDQpXS" +
                        "EVSRSBGQUwuTW9kdWxJRCA9IDMNCiAgQU5EIEJCRy5Nb25hdCBJUyBOT1QgTlVMTA0KICBBTkQgQkJHL" +
                        "kJnQnVkZ2V0SUQgPSBudWxs";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ShUebersichtMonatsbudget2_Zahlungen = new DevExpress.XtraReports.UI.Subreport();
            this.ShUebersichtMonatsbudget2_Uebersicht = new DevExpress.XtraReports.UI.Subreport();
            this.ShUebersichtMonatsbudget2_Budget = new DevExpress.XtraReports.UI.Subreport();
            this.ShUebersichtMonatsbudget2_Unterst = new DevExpress.XtraReports.UI.Subreport();
            this.txtOrgPlzOrt = new DevExpress.XtraReports.UI.XRLabel();
            this.txtOrgAdr = new DevExpress.XtraReports.UI.XRLabel();
            this.txtOrg = new DevExpress.XtraReports.UI.XRLabel();
            this.txtZust = new DevExpress.XtraReports.UI.XRLabel();
            this.txtOrt = new DevExpress.XtraReports.UI.XRLabel();
            this.txtStrasse = new DevExpress.XtraReports.UI.XRLabel();
            this.lblStatus = new DevExpress.XtraReports.UI.XRLabel();
            this.txtStatus = new DevExpress.XtraReports.UI.XRLabel();
            this.txtName = new DevExpress.XtraReports.UI.XRLabel();
            this.shpAdr = new DevExpress.XtraReports.UI.XRControl();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblFooterLeft = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel6,
                        this.xrLabel2,
                        this.xrLabel1,
                        this.ShUebersichtMonatsbudget2_Zahlungen,
                        this.ShUebersichtMonatsbudget2_Uebersicht,
                        this.ShUebersichtMonatsbudget2_Budget,
                        this.ShUebersichtMonatsbudget2_Unterst,
                        this.txtOrgPlzOrt,
                        this.txtOrgAdr,
                        this.txtOrg,
                        this.txtZust,
                        this.txtOrt,
                        this.txtStrasse,
                        this.lblStatus,
                        this.txtStatus,
                        this.txtName,
                        this.shpAdr});
            this.Detail.Height = 345;
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
            // GroupHeader1
            // 
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("BgBudgetId", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 25;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            this.GroupHeader1.Visible = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel9,
                        this.xrLabel8,
                        this.xrLabel7});
            this.GroupFooter1.Height = 101;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorders = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter1.ParentStyleUsing.UseFont = false;
            this.GroupFooter1.ParentStyleUsing.UseForeColor = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLine1,
                        this.xrPageInfo1,
                        this.xrLabel5,
                        this.xrLabel4,
                        this.xrLabel3,
                        this.lblFooterLeft});
            this.PageFooter.Height = 54;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel6.ForeColor = System.Drawing.Color.Black;
            this.xrLabel6.Location = new System.Drawing.Point(8, 108);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseBackColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorders = false;
            this.xrLabel6.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.ParentStyleUsing.UseForeColor = false;
            this.xrLabel6.Size = new System.Drawing.Size(75, 17);
            this.xrLabel6.Text = "Zuständig:";
            // 
            // xrLabel2
            // 
            this.xrLabel2.CanShrink = true;
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Jahr", "Monatsbudget {0:yyyy}")});
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 14F);
            this.xrLabel2.Location = new System.Drawing.Point(8, 67);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(184, 25);
            this.xrLabel2.Text = "xrLabel2";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Monat", "{0:MMMM}")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 14F);
            this.xrLabel1.Location = new System.Drawing.Point(192, 67);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(240, 25);
            this.xrLabel1.Text = "xrLabel1";
            // 
            // ShUebersichtMonatsbudget2_Zahlungen
            // 
            this.ShUebersichtMonatsbudget2_Zahlungen.Location = new System.Drawing.Point(8, 300);
            this.ShUebersichtMonatsbudget2_Zahlungen.Name = "ShUebersichtMonatsbudget2_Zahlungen";
            // 
            // ShUebersichtMonatsbudget2_Uebersicht
            // 
            this.ShUebersichtMonatsbudget2_Uebersicht.Location = new System.Drawing.Point(8, 258);
            this.ShUebersichtMonatsbudget2_Uebersicht.Name = "ShUebersichtMonatsbudget2_Uebersicht";
            // 
            // ShUebersichtMonatsbudget2_Budget
            // 
            this.ShUebersichtMonatsbudget2_Budget.Location = new System.Drawing.Point(8, 217);
            this.ShUebersichtMonatsbudget2_Budget.Name = "ShUebersichtMonatsbudget2_Budget";
            // 
            // ShUebersichtMonatsbudget2_Unterst
            // 
            this.ShUebersichtMonatsbudget2_Unterst.Location = new System.Drawing.Point(8, 175);
            this.ShUebersichtMonatsbudget2_Unterst.Name = "ShUebersichtMonatsbudget2_Unterst";
            // 
            // txtOrgPlzOrt
            // 
            this.txtOrgPlzOrt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_PLZOrt", "")});
            this.txtOrgPlzOrt.Font = new System.Drawing.Font("Arial", 10F);
            this.txtOrgPlzOrt.ForeColor = System.Drawing.Color.Black;
            this.txtOrgPlzOrt.Location = new System.Drawing.Point(8, 42);
            this.txtOrgPlzOrt.Multiline = true;
            this.txtOrgPlzOrt.Name = "txtOrgPlzOrt";
            this.txtOrgPlzOrt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOrgPlzOrt.ParentStyleUsing.UseBackColor = false;
            this.txtOrgPlzOrt.ParentStyleUsing.UseBorderColor = false;
            this.txtOrgPlzOrt.ParentStyleUsing.UseBorders = false;
            this.txtOrgPlzOrt.ParentStyleUsing.UseBorderWidth = false;
            this.txtOrgPlzOrt.ParentStyleUsing.UseFont = false;
            this.txtOrgPlzOrt.ParentStyleUsing.UseForeColor = false;
            this.txtOrgPlzOrt.Size = new System.Drawing.Size(228, 16);
            this.txtOrgPlzOrt.Text = "Org_PLZOrt";
            // 
            // txtOrgAdr
            // 
            this.txtOrgAdr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Adresse", "")});
            this.txtOrgAdr.Font = new System.Drawing.Font("Arial", 10F);
            this.txtOrgAdr.ForeColor = System.Drawing.Color.Black;
            this.txtOrgAdr.Location = new System.Drawing.Point(8, 25);
            this.txtOrgAdr.Multiline = true;
            this.txtOrgAdr.Name = "txtOrgAdr";
            this.txtOrgAdr.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOrgAdr.ParentStyleUsing.UseBackColor = false;
            this.txtOrgAdr.ParentStyleUsing.UseBorderColor = false;
            this.txtOrgAdr.ParentStyleUsing.UseBorders = false;
            this.txtOrgAdr.ParentStyleUsing.UseBorderWidth = false;
            this.txtOrgAdr.ParentStyleUsing.UseFont = false;
            this.txtOrgAdr.ParentStyleUsing.UseForeColor = false;
            this.txtOrgAdr.Size = new System.Drawing.Size(228, 17);
            this.txtOrgAdr.Text = "Org_Adresse";
            // 
            // txtOrg
            // 
            this.txtOrg.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Name", "")});
            this.txtOrg.Font = new System.Drawing.Font("Arial", 12F);
            this.txtOrg.ForeColor = System.Drawing.Color.Black;
            this.txtOrg.Location = new System.Drawing.Point(8, 0);
            this.txtOrg.Multiline = true;
            this.txtOrg.Name = "txtOrg";
            this.txtOrg.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOrg.ParentStyleUsing.UseBackColor = false;
            this.txtOrg.ParentStyleUsing.UseBorderColor = false;
            this.txtOrg.ParentStyleUsing.UseBorders = false;
            this.txtOrg.ParentStyleUsing.UseBorderWidth = false;
            this.txtOrg.ParentStyleUsing.UseFont = false;
            this.txtOrg.ParentStyleUsing.UseForeColor = false;
            this.txtOrg.Size = new System.Drawing.Size(479, 25);
            this.txtOrg.Text = "Org_Name";
            // 
            // txtZust
            // 
            this.txtZust.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Zust", "")});
            this.txtZust.Font = new System.Drawing.Font("Arial", 10F);
            this.txtZust.ForeColor = System.Drawing.Color.Black;
            this.txtZust.Location = new System.Drawing.Point(83, 108);
            this.txtZust.Multiline = true;
            this.txtZust.Name = "txtZust";
            this.txtZust.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtZust.ParentStyleUsing.UseBackColor = false;
            this.txtZust.ParentStyleUsing.UseBorderColor = false;
            this.txtZust.ParentStyleUsing.UseBorders = false;
            this.txtZust.ParentStyleUsing.UseBorderWidth = false;
            this.txtZust.ParentStyleUsing.UseFont = false;
            this.txtZust.ParentStyleUsing.UseForeColor = false;
            this.txtZust.Size = new System.Drawing.Size(350, 17);
            this.txtZust.Text = "Zust";
            // 
            // txtOrt
            // 
            this.txtOrt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Ort", "")});
            this.txtOrt.Font = new System.Drawing.Font("Arial", 10F);
            this.txtOrt.ForeColor = System.Drawing.Color.Black;
            this.txtOrt.Location = new System.Drawing.Point(507, 102);
            this.txtOrt.Multiline = true;
            this.txtOrt.Name = "txtOrt";
            this.txtOrt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOrt.ParentStyleUsing.UseBackColor = false;
            this.txtOrt.ParentStyleUsing.UseBorderColor = false;
            this.txtOrt.ParentStyleUsing.UseBorders = false;
            this.txtOrt.ParentStyleUsing.UseBorderWidth = false;
            this.txtOrt.ParentStyleUsing.UseFont = false;
            this.txtOrt.ParentStyleUsing.UseForeColor = false;
            this.txtOrt.Size = new System.Drawing.Size(212, 15);
            this.txtOrt.Text = "Ort";
            // 
            // txtStrasse
            // 
            this.txtStrasse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Strasse", "")});
            this.txtStrasse.Font = new System.Drawing.Font("Arial", 10F);
            this.txtStrasse.ForeColor = System.Drawing.Color.Black;
            this.txtStrasse.Location = new System.Drawing.Point(507, 86);
            this.txtStrasse.Multiline = true;
            this.txtStrasse.Name = "txtStrasse";
            this.txtStrasse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtStrasse.ParentStyleUsing.UseBackColor = false;
            this.txtStrasse.ParentStyleUsing.UseBorderColor = false;
            this.txtStrasse.ParentStyleUsing.UseBorders = false;
            this.txtStrasse.ParentStyleUsing.UseBorderWidth = false;
            this.txtStrasse.ParentStyleUsing.UseFont = false;
            this.txtStrasse.ParentStyleUsing.UseForeColor = false;
            this.txtStrasse.Size = new System.Drawing.Size(212, 15);
            this.txtStrasse.Text = "Strasse";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Arial", 10F);
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(8, 92);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblStatus.ParentStyleUsing.UseBackColor = false;
            this.lblStatus.ParentStyleUsing.UseBorderColor = false;
            this.lblStatus.ParentStyleUsing.UseBorders = false;
            this.lblStatus.ParentStyleUsing.UseBorderWidth = false;
            this.lblStatus.ParentStyleUsing.UseFont = false;
            this.lblStatus.ParentStyleUsing.UseForeColor = false;
            this.lblStatus.Size = new System.Drawing.Size(74, 16);
            this.lblStatus.Text = "Status:";
            // 
            // txtStatus
            // 
            this.txtStatus.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Status", "")});
            this.txtStatus.Font = new System.Drawing.Font("Arial", 10F);
            this.txtStatus.ForeColor = System.Drawing.Color.Black;
            this.txtStatus.Location = new System.Drawing.Point(83, 92);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtStatus.ParentStyleUsing.UseBackColor = false;
            this.txtStatus.ParentStyleUsing.UseBorderColor = false;
            this.txtStatus.ParentStyleUsing.UseBorders = false;
            this.txtStatus.ParentStyleUsing.UseBorderWidth = false;
            this.txtStatus.ParentStyleUsing.UseFont = false;
            this.txtStatus.ParentStyleUsing.UseForeColor = false;
            this.txtStatus.Size = new System.Drawing.Size(350, 16);
            this.txtStatus.Text = "Status";
            // 
            // txtName
            // 
            this.txtName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.txtName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(507, 70);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtName.ParentStyleUsing.UseBackColor = false;
            this.txtName.ParentStyleUsing.UseBorderColor = false;
            this.txtName.ParentStyleUsing.UseBorders = false;
            this.txtName.ParentStyleUsing.UseBorderWidth = false;
            this.txtName.ParentStyleUsing.UseFont = false;
            this.txtName.ParentStyleUsing.UseForeColor = false;
            this.txtName.Size = new System.Drawing.Size(212, 15);
            this.txtName.Text = "Name";
            // 
            // shpAdr
            // 
            this.shpAdr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.shpAdr.BorderColor = System.Drawing.Color.Black;
            this.shpAdr.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.shpAdr.Location = new System.Drawing.Point(503, 62);
            this.shpAdr.Name = "shpAdr";
            this.shpAdr.ParentStyleUsing.UseBackColor = false;
            this.shpAdr.ParentStyleUsing.UseBorderColor = false;
            this.shpAdr.ParentStyleUsing.UseBorders = false;
            this.shpAdr.ParentStyleUsing.UseBorderWidth = false;
            this.shpAdr.ParentStyleUsing.UseFont = false;
            this.shpAdr.ParentStyleUsing.UseForeColor = false;
            this.shpAdr.Size = new System.Drawing.Size(225, 70);
            // 
            // xrLabel9
            // 
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.Location = new System.Drawing.Point(575, 50);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.Size = new System.Drawing.Size(150, 16);
            this.xrLabel9.Text = "Unterschrift Klient/in";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.Location = new System.Drawing.Point(8, 50);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.Size = new System.Drawing.Size(75, 16);
            this.xrLabel8.Text = "Wohlen,";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.Location = new System.Drawing.Point(8, 17);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.Size = new System.Drawing.Size(717, 25);
            this.xrLabel7.Text = "Der Empfänger/die Empfängerin bestätigt mit seiner/ihrer Unterschrift die Vollstä" +
                "ndigkeit und Richtigkeit der  Angaben.";
            // 
            // xrLine1
            // 
            this.xrLine1.Location = new System.Drawing.Point(0, 8);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(736, 9);
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 10F);
            this.xrPageInfo1.Format = "{0:dd.MMMM.yyyy}";
            this.xrPageInfo1.Location = new System.Drawing.Point(0, 31);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(142, 17);
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel5.Location = new System.Drawing.Point(447, 31);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(293, 16);
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Jahr", "{0:yyyy}")});
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel4.Location = new System.Drawing.Point(700, 17);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(40, 20);
            this.xrLabel4.Text = "xrLabel1";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Monat", "Monatsbudget {0:MMMM}")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel3.Location = new System.Drawing.Point(433, 17);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(267, 20);
            this.xrLabel3.Text = "xrLabel2";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblFooterLeft
            // 
            this.lblFooterLeft.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_PLZOrt", "{0}")});
            this.lblFooterLeft.Font = new System.Drawing.Font("Arial", 10F);
            this.lblFooterLeft.ForeColor = System.Drawing.Color.Black;
            this.lblFooterLeft.Location = new System.Drawing.Point(0, 17);
            this.lblFooterLeft.Name = "lblFooterLeft";
            this.lblFooterLeft.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblFooterLeft.ParentStyleUsing.UseBackColor = false;
            this.lblFooterLeft.ParentStyleUsing.UseBorderColor = false;
            this.lblFooterLeft.ParentStyleUsing.UseBorders = false;
            this.lblFooterLeft.ParentStyleUsing.UseBorderWidth = false;
            this.lblFooterLeft.ParentStyleUsing.UseFont = false;
            this.lblFooterLeft.ParentStyleUsing.UseForeColor = false;
            this.lblFooterLeft.Size = new System.Drawing.Size(425, 15);
            this.lblFooterLeft.Text = "Ort, Datum";
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
            this.Margins = new System.Drawing.Printing.Margins(39, 28, 80, 40);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' ,  N'<?xml version="1.0" standalone="yes" ?>
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
</NewDataSet>' ,  N'SELECT
  Org_Name    = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Organisation'', GetDate())), ''''),
  Org_Adresse = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Adresse'', GetDate())), ''''),
  Org_PLZ     = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', GetDate())), ''''),
  Org_Ort     = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', GetDate())), ''''),
  Org_PLZOrt  = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', GetDate())) + '' '', '''')
              + IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', GetDate())), ''''),
  BBG.BgBudgetID,
  Jahr       = CONVERT(DATETIME, CONVERT(VARCHAR,BBG.Jahr)), 
  Monat      = DATEADD(m,BBG.Monat, ''20001201''),
--  Datum      = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1),
  Status     = IsNull(''Monatsbudget '' + BBG_LOV.Text, ''?''),
  StatusCode = BBG.BgBewilligungStatusCode,
  Name       = PRS.VornameName,
  Strasse    = PRS.WohnsitzStrasseHausNr,
  Ort        = PRS.WohnsitzPLZOrt,
  Zust       = IsNull(USR.FirstName+'' '', '''') + IsNull(USR.LastName, '''')
FROM BgBudget              BBG
  INNER JOIN BgFinanzplan  SFP on SFP.BgFinanzplanID = BBG.BgFinanzplanID
  INNER JOIN FaLeistung    FAL on FAL.FaLeistungID = SFP.FaLeistungID
  INNER JOIN vwPerson      PRS on PRS.BaPersonID = FAL.BaPersonID
  INNER JOIN XUser         USR on USR.UserID = FAL.UserID
  LEFT  JOIN XLOVCode  BBG_LOV on BBG_LOV.LOVName = ''BgBewilligungStatus'' AND BBG_LOV.Code = BBG.BgBewilligungStatusCode
WHERE FAL.ModulID = 3
  AND BBG.Monat IS NOT NULL
  AND BBG.BgBudgetID = {BgBudgetID}' ,  N'WhMonatsbudget,WhMasterbudget' ,  null , 3)

INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShUebersichtMonatsbudget2_Unterst' ,  N'Monatsbudget2-Unterst' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Temp\KiSS4_Migration\KiSS4.DB.dll" />
///     <Reference Path="C:\Temp\KiSS4_Migration\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtKSTName;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtZahlungsweg;
        private DevExpress.XtraReports.UI.XRLabel txtHeimatort;
        private DevExpress.XtraReports.UI.XRLabel txtAHV;
        private DevExpress.XtraReports.UI.XRLabel txtName;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.XRLabel Label3;
        private DevExpress.XtraReports.UI.XRLabel Label2;
        private DevExpress.XtraReports.UI.XRLabel Label1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = @"zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OSNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kAAAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAAAAAAb8FU0VMRUNUDQogIE5hbWUgICAgICAgPSBQUlMuTmFtZSArICcsICcgKyBQUlMuVm9ybmFtZSwNCiAgQUhWICAgICAgICA9IElzTnVsbChQUlMuQUhWTnVtbWVyLCcnKSwNCiAgSGVpbWF0b3J0ICA9IFBSUy5IZWltYXRvcnQsDQogIEJhbmsgICAgICAgPSBJc051bGwoS1JELkJhbmtOYW1lLCAnJyksDQogIEtvbnRvICAgICAgPSBJc051bGwoS1JELkJhbmtLb250b051bW1lciwgJycpLA0KICBaYWhsdW5nc3dlZyA9IEtSRC5aYWhsdW5nc3dlZywgLS0/DQotLSAgWmFobHVuZ3N3ZWdtID0gS1JELlphaGx1bmdzd2VnTWVoclplaWxpZywgLS0/DQogIEtTVE5hbWUgICAgPSBkYm8uZm5LYkdldEtvc3RlbnN0ZWxsZShQUlMuQmFQZXJzb25JRCkNCkZST00gQmdCdWRnZXQgICAgICAgICAgICAgICAgICAgICAgICBCQkcNCiAgSU5ORVIgSk9JTiBCZ0ZpbmFuenBsYW5fQmFQZXJzb24gICBTUFAgT04gU1BQLkJnRmluYW56cGxhbklEID0gQkJHLkJnRmluYW56cGxhbklEDQogIElOTkVSIEpPSU4gdndQZXJzb24gICAgICAgICAgICAgICAgUFJTIE9OIFBSUy5CYVBlcnNvbklEID0gU1BQLkJhUGVyc29uSUQNCiAgTEVGVCAgSk9JTiB2d2tyZWRpdG9yICAgICAgICAgICAgICBLUkQgT04gS1JELkJhUGVyc29uSUQgPSBTUFAuQmFQZXJzb25JRA0KV0hFUkUgU1BQLklzdFVudGVyc3R1ZXR6dCA9IDENCiAgQU5EIEJCRy5CZ0J1ZGdldElEID0gbnVsbA==";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.txtKSTName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtZahlungsweg = new DevExpress.XtraReports.UI.XRLabel();
            this.txtHeimatort = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAHV = new DevExpress.XtraReports.UI.XRLabel();
            this.txtName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
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
                        this.txtKSTName,
                        this.txtZahlungsweg,
                        this.txtHeimatort,
                        this.txtAHV,
                        this.txtName});
            this.Detail.Height = 23;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBackColor = false;
            this.Detail.ParentStyleUsing.UseBorderColor = false;
            this.Detail.ParentStyleUsing.UseBorders = false;
            this.Detail.ParentStyleUsing.UseBorderWidth = false;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel1,
                        this.Line2,
                        this.Label6,
                        this.Label4,
                        this.Label3,
                        this.Label2,
                        this.Label1});
            this.ReportHeader.Height = 69;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.ParentStyleUsing.UseBackColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorderColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorders = false;
            this.ReportHeader.ParentStyleUsing.UseBorderWidth = false;
            this.ReportHeader.ParentStyleUsing.UseFont = false;
            this.ReportHeader.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Height = 25;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
            this.ReportFooter.Visible = false;
            // 
            // txtKSTName
            // 
            this.txtKSTName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KSTName", "")});
            this.txtKSTName.Font = new System.Drawing.Font("Arial", 9F);
            this.txtKSTName.ForeColor = System.Drawing.Color.Black;
            this.txtKSTName.Location = new System.Drawing.Point(527, 0);
            this.txtKSTName.Multiline = true;
            this.txtKSTName.Name = "txtKSTName";
            this.txtKSTName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKSTName.ParentStyleUsing.UseBackColor = false;
            this.txtKSTName.ParentStyleUsing.UseBorderColor = false;
            this.txtKSTName.ParentStyleUsing.UseBorders = false;
            this.txtKSTName.ParentStyleUsing.UseBorderWidth = false;
            this.txtKSTName.ParentStyleUsing.UseFont = false;
            this.txtKSTName.ParentStyleUsing.UseForeColor = false;
            this.txtKSTName.Size = new System.Drawing.Size(200, 15);
            this.txtKSTName.Text = "KSTName";
            // 
            // txtZahlungsweg
            // 
            this.txtZahlungsweg.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Zahlungsweg", "")});
            this.txtZahlungsweg.Font = new System.Drawing.Font("Arial", 9F);
            this.txtZahlungsweg.ForeColor = System.Drawing.Color.Black;
            this.txtZahlungsweg.Location = new System.Drawing.Point(333, 0);
            this.txtZahlungsweg.Multiline = true;
            this.txtZahlungsweg.Name = "txtZahlungsweg";
            this.txtZahlungsweg.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtZahlungsweg.ParentStyleUsing.UseBackColor = false;
            this.txtZahlungsweg.ParentStyleUsing.UseBorderColor = false;
            this.txtZahlungsweg.ParentStyleUsing.UseBorders = false;
            this.txtZahlungsweg.ParentStyleUsing.UseBorderWidth = false;
            this.txtZahlungsweg.ParentStyleUsing.UseFont = false;
            this.txtZahlungsweg.ParentStyleUsing.UseForeColor = false;
            this.txtZahlungsweg.Size = new System.Drawing.Size(192, 15);
            this.txtZahlungsweg.Text = "txtZahlungsweg";
            // 
            // txtHeimatort
            // 
            this.txtHeimatort.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Heimatort", "")});
            this.txtHeimatort.Font = new System.Drawing.Font("Arial", 9F);
            this.txtHeimatort.ForeColor = System.Drawing.Color.Black;
            this.txtHeimatort.Location = new System.Drawing.Point(233, 0);
            this.txtHeimatort.Multiline = true;
            this.txtHeimatort.Name = "txtHeimatort";
            this.txtHeimatort.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtHeimatort.ParentStyleUsing.UseBackColor = false;
            this.txtHeimatort.ParentStyleUsing.UseBorderColor = false;
            this.txtHeimatort.ParentStyleUsing.UseBorders = false;
            this.txtHeimatort.ParentStyleUsing.UseBorderWidth = false;
            this.txtHeimatort.ParentStyleUsing.UseFont = false;
            this.txtHeimatort.ParentStyleUsing.UseForeColor = false;
            this.txtHeimatort.Size = new System.Drawing.Size(100, 15);
            this.txtHeimatort.Text = "Heimatort";
            // 
            // txtAHV
            // 
            this.txtAHV.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AHV", "")});
            this.txtAHV.Font = new System.Drawing.Font("Arial", 9F);
            this.txtAHV.ForeColor = System.Drawing.Color.Black;
            this.txtAHV.Location = new System.Drawing.Point(140, 0);
            this.txtAHV.Multiline = true;
            this.txtAHV.Name = "txtAHV";
            this.txtAHV.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtAHV.ParentStyleUsing.UseBackColor = false;
            this.txtAHV.ParentStyleUsing.UseBorderColor = false;
            this.txtAHV.ParentStyleUsing.UseBorders = false;
            this.txtAHV.ParentStyleUsing.UseBorderWidth = false;
            this.txtAHV.ParentStyleUsing.UseFont = false;
            this.txtAHV.ParentStyleUsing.UseForeColor = false;
            this.txtAHV.Size = new System.Drawing.Size(93, 15);
            this.txtAHV.Text = "AHV";
            // 
            // txtName
            // 
            this.txtName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.txtName.Font = new System.Drawing.Font("Arial", 9F);
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(0, 0);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtName.ParentStyleUsing.UseBackColor = false;
            this.txtName.ParentStyleUsing.UseBorderColor = false;
            this.txtName.ParentStyleUsing.UseBorders = false;
            this.txtName.ParentStyleUsing.UseBorderWidth = false;
            this.txtName.ParentStyleUsing.UseFont = false;
            this.txtName.ParentStyleUsing.UseForeColor = false;
            this.txtName.Size = new System.Drawing.Size(140, 15);
            this.txtName.Text = "Name";
            // 
            // xrLabel1
            // 
            this.xrLabel1.BackColor = System.Drawing.Color.Silver;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.Location = new System.Drawing.Point(0, 0);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseBackColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.ParentStyleUsing.UseForeColor = false;
            this.xrLabel1.Size = new System.Drawing.Size(724, 23);
            this.xrLabel1.Text = "Unterstützte Personen";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.LineDirection = DevExpress.XtraReports.UI.LineDirection.BackSlant;
            this.Line2.Location = new System.Drawing.Point(0, 46);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(724, 2);
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(527, 31);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(200, 15);
            this.Label6.Text = "KST GB, Miete";
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(333, 31);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(192, 15);
            this.Label4.Text = "Zahlungsweg";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(233, 31);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(100, 15);
            this.Label3.Text = "Heimatort";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(140, 31);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(94, 15);
            this.Label2.Text = "AHV";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(0, 31);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(140, 15);
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
                        this.ReportHeader,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(100, 0, 100, 100);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' ,  N'<?xml version="1.0" standalone="yes" ?>
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
</NewDataSet>' ,  N'SELECT
  Name       = PRS.Name + '', '' + PRS.Vorname,
  AHV        = IsNull(PRS.AHVNummer,''''),
  Heimatort  = PRS.Heimatort,
  Bank       = IsNull(KRD.BankName, ''''),
  Konto      = IsNull(KRD.BankKontoNummer, ''''),
  Zahlungsweg = KRD.Zahlungsweg, --?
--  Zahlungswegm = KRD.ZahlungswegMehrZeilig, --?
  KSTName    = dbo.fnKbGetKostenstelle(PRS.BaPersonID)
FROM BgBudget                        BBG
  INNER JOIN BgFinanzplan_BaPerson   SPP ON SPP.BgFinanzplanID = BBG.BgFinanzplanID
  INNER JOIN vwPerson                PRS ON PRS.BaPersonID = SPP.BaPersonID
  LEFT  JOIN vwkreditor              KRD ON KRD.BaPersonID = SPP.BaPersonID
WHERE SPP.IstUnterstuetzt = 1
  AND BBG.BgBudgetID = {BgBudgetID}' ,  null ,  N'ShUebersichtMonatsbudget2' ,  null )

INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShUebersichtMonatsbudget2_Uebersicht' ,  N'Monatsbudget2-Uebersicht' , 1,  N'<!--
AssemblyName=DevExpress%2EXtraReports%2C%20Version%3D1%2E7%2E10%2E0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4
AssemblyLocation=c:\windows\assembly\gac\devexpress.xtrareports\1.7.10.0__79868b8147b5eae4\devexpress.xtrareports.dll
TypeName=DevExpress.XtraReports.UI.XtraReport
Localization=de-DE
-->
<SOAP-ENV:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:SOAP-ENC="http://schemas.xmlsoap.org/soap/encoding/" xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/" xmlns:clr="http://schemas.microsoft.com/soap/encoding/clr/1.0" SOAP-ENV:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
<SOAP-ENV:Body>
<a1:ReportStorage id="ref-1" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<BandCount>3</BandCount>
<Band0 href="#ref-6"/>
<Band1 href="#ref-7"/>
<Band2 href="#ref-8"/>
<Visible>true</Visible>
<Tag id="ref-9"></Tag>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-10">Report</Name>
<Style_X_Font id="ref-11">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor id="ref-12">ControlText</Style_X_ForeColor>
<Style_X_BackColor id="ref-13">Transparent</Style_X_BackColor>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>true</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>true</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>true</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>true</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>true</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>true</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>100</width>
<height>23</height>
</Bounds>
<Text href="#ref-9"/>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>100</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<DataSource id="ref-14">dataSource</DataSource>
<UseDefaultPrinterSettings>false</UseDefaultPrinterSettings>
<ReportUnit xsi:type="a2:ReportUnit" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">HundredthsOfAnInch</ReportUnit>
<Landscape>false</Landscape>
<PaperKind xsi:type="a5:PaperKind" xmlns:a5="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Printing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">A4</PaperKind>
<PaperName href="#ref-9"/>
<Margins xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>100</x>
<y>100</y>
<width>0</width>
<height>100</height>
</Margins>
<HtmlCompressed>false</HtmlCompressed>
<PageSize xsi:type="a4:Size" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<width>827</width>
<height>1169</height>
</PageSize>
<StyleSheet_X_StyleCount>0</StyleSheet_X_StyleCount>
<ShowPreviewMarginLines>true</ShowPreviewMarginLines>
<ScriptLanguage xsi:type="a6:ScriptLanguage" xmlns:a6="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">CSharp</ScriptLanguage>
<Watermark_X_Text href="#ref-9"/>
<Watermark_X_Font id="ref-15">Verdana, 36pt</Watermark_X_Font>
<Watermark_X_ForeColor id="ref-16">Red</Watermark_X_ForeColor>
<Watermark_X_Transparency>50</Watermark_X_Transparency>
<Watermark_X_TextDirection xsi:type="a7:DirectionMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">ForwardDiagonal</Watermark_X_TextDirection>
<Watermark_X_Image xsi:type="xsd:anyType" xsi:null="1"/>
<Watermark_X_ImageAlign xsi:type="a4:ContentAlignment" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">MiddleCenter</Watermark_X_ImageAlign>
<Watermark_X_ImageViewMode xsi:type="a7:ImageViewMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Clip</Watermark_X_ImageViewMode>
<Watermark_X_ImageTiling>false</Watermark_X_ImageTiling>
<Watermark_X_PageRange href="#ref-9"/>
<Watermark_X_ShowBehind>true</Watermark_X_ShowBehind>
<DefaultPrinterSettingsUsing_X_UseMargins>false</DefaultPrinterSettingsUsing_X_UseMargins>
<DefaultPrinterSettingsUsing_X_UsePaperKind>false</DefaultPrinterSettingsUsing_X_UsePaperKind>
<DefaultPrinterSettingsUsing_X_UseLandscape>false</DefaultPrinterSettingsUsing_X_UseLandscape>
<ShrinkSubReportIconArea>true</ShrinkSubReportIconArea>
</a1:ReportStorage>
<a1:ObjectStorage id="ref-6" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName id="ref-17">DevExpress.XtraReports, Version=1.7.10.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</Type_X_AssemblyName>
<Type_X_TypeName id="ref-18">DevExpress.XtraReports.UI.DetailBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-19">Detail</Name>
<Style_X_Font id="ref-20">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-12"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>100</width>
<height>23</height>
</Bounds>
<Text href="#ref-9"/>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>15</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<PrintOnEmptyDataSource>true</PrintOnEmptyDataSource>
<MultiColumn_X_ColumnCount>1</MultiColumn_X_ColumnCount>
<MultiColumn_X_Direction xsi:type="a2:ColumnDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">DownThenAcross</MultiColumn_X_Direction>
<MultiColumn_X_ColumnWidth>0</MultiColumn_X_ColumnWidth>
<MultiColumn_X_ColumnSpacing>0</MultiColumn_X_ColumnSpacing>
<MultiColumn_X_Mode xsi:type="a2:MultiColumnMode" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">UseColumnCount</MultiColumn_X_Mode>
<RepeatCountOnEmptyDataSource>1</RepeatCountOnEmptyDataSource>
<ItemCount>2</ItemCount>
<Item0 href="#ref-21"/>
<Item1 href="#ref-22"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-7" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName id="ref-23">DevExpress.XtraReports.UI.ReportHeaderBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-24">ReportHeader</Name>
<Style_X_Font id="ref-25">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-12"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>100</width>
<height>23</height>
</Bounds>
<Text href="#ref-9"/>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>25</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>1</ItemCount>
<Item0 href="#ref-26"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-8" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName id="ref-27">DevExpress.XtraReports.UI.ReportFooterBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-28">ReportFooter</Name>
<Style_X_Font id="ref-29">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-12"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>100</width>
<height>23</height>
</Bounds>
<Text href="#ref-9"/>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>54</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<PrintAtBottom>false</PrintAtBottom>
<ItemCount>3</ItemCount>
<Item0 href="#ref-30"/>
<Item1 href="#ref-31"/>
<Item2 href="#ref-32"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-21" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName id="ref-33">DevExpress.XtraReports.UI.XRLabel</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-34">txtBezeichnung</Name>
<Style_X_Font id="ref-35">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor id="ref-36">Black</Style_X_ForeColor>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-37">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-38">Bezeichnung</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-9"/>
<BindingItem0_X_DataSource href="#ref-14"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>574</width>
<height>15</height>
</Bounds>
<Text id="ref-39">Bezeichnung</Text>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-22" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-33"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-40">txtBetrag</Name>
<Style_X_Font id="ref-41">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-36"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName href="#ref-37"/>
<BindingItem0_X_DataMember id="ref-42">Betrag</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-43">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-14"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>574</x>
<y>0</y>
<width>133</width>
<height>15</height>
</Bounds>
<Text id="ref-44">Betrag</Text>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-45">{0:#,##0.00}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-26" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-33"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-46">lblTitle</Name>
<Style_X_Font id="ref-47">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-36"/>
<Style_X_BackColor id="ref-48">Silver</Style_X_BackColor>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">MiddleLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>724</width>
<height>23</height>
</Bounds>
<Text id="ref-49">Leistungen des Sozialdienstes</Text>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-30" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-33"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-50">Betrag1</Name>
<Style_X_Font id="ref-51">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-36"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName href="#ref-37"/>
<BindingItem0_X_DataMember id="ref-52">Betrag</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-53">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-14"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>574</x>
<y>7</y>
<width>133</width>
<height>15</height>
</Bounds>
<Text id="ref-54">Betrag</Text>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-55">{0:#,##0.00}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Report</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-31" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName id="ref-56">DevExpress.XtraReports.UI.XRLine</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-57">Line1</Name>
<Style_X_Font id="ref-58">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-36"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>708</width>
<height>2</height>
</Bounds>
<Text href="#ref-9"/>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-32" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-33"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-59">lblTot</Name>
<Style_X_Font id="ref-60">Arial, 9.75pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-36"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>7</y>
<width>574</width>
<height>15</height>
</Bounds>
<Text id="ref-61">Gesamte, vom Sozialdienst erbrachte Leistung</Text>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
</SOAP-ENV:Body>
</SOAP-ENV:Envelope>' ,  N'<?xml version="1.0" standalone="yes" ?>
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
</NewDataSet>' ,  N'DECLARE @RefDate  datetime  SET @RefDate = GetDate()

DECLARE @out TABLE (
  Rec_ID      int NULL,
  Parent_ID   int NOT NULL,
  SortKey     int NOT NULL,
  Style       int NOT NULL,
  Bezeichnung varchar(100) NOT NULL,
  Betrag      money NULL
)

INSERT INTO @out
  SELECT Rec_ID, Parent_ID, SortKey, Style, Bezeichnung, Betrag
  FROM dbo.fnWhGetBudgetUebersicht({BgBudgetID}, @RefDate)  TMP
  WHERE Parent_ID < 0

SELECT
  GroupID     = GRP.Rec_ID,
  Gruppe      = LTrim(GRP.Bezeichnung),
  TotalText   = (SELECT LTrim(Bezeichnung) FROM @out WHERE SortKey = TMP.SortKey + 1),
  Bezeichnung = LTrim(BEZ.Bezeichnung),
  BEZ.Betrag
FROM @out          GRP
  INNER JOIN @out  BEZ ON BEZ.Parent_ID = GRP.Rec_ID
  INNER JOIN (SELECT Parent_ID, SortKey = MAX(SortKey)
              FROM @out GROUP BY Parent_ID)  TMP ON TMP.Parent_ID = GRP.Rec_ID
WHERE GRP.Rec_ID = -10' ,  null ,  N'ShUebersichtMonatsbudget2' ,  null )

INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShUebersichtMonatsbudget2_Zahlungen' ,  N'Monatsbudget2-Zahlungen' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Temp\KiSS4_Migration\KiSS4.DB.dll" />
///     <Reference Path="C:\Temp\KiSS4_Migration\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLine Line6;
        private DevExpress.XtraReports.UI.XRLine Line5;
        private DevExpress.XtraReports.UI.XRLine Line4;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLabel txtCashOrCheckAm;
        private DevExpress.XtraReports.UI.XRLabel txtVerfalldatum;
        private DevExpress.XtraReports.UI.XRLabel txtKOA;
        private DevExpress.XtraReports.UI.XRLabel txtBuchungstext;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel lblTitle;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLine Line11;
        private DevExpress.XtraReports.UI.XRLine Line10;
        private DevExpress.XtraReports.UI.XRLine Line9;
        private DevExpress.XtraReports.UI.XRLine Line8;
        private DevExpress.XtraReports.UI.XRLine Line7;
        private DevExpress.XtraReports.UI.XRLabel Label5;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.XRLabel Label3;
        private DevExpress.XtraReports.UI.XRLabel Label2;
        private DevExpress.XtraReports.UI.XRLabel Label1;
        private DevExpress.XtraReports.UI.XRLabel txtEmpfänger;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel Betrag1;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel Betrag2;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLine Line1;
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
                        "AAAAcMNREVDTEFSRSBAQmdCdWRnZXRJRCAgICAgaW50LA0KICAgICAgICBAQmdGaW5hbnpwbGFuSUQga" +
                        "W50DQoNClNFTEVDVA0KICBAQmdCdWRnZXRJRCA9IEJnQnVkZ2V0SUQsDQogIEBCZ0ZpbmFuenBsYW5JR" +
                        "CA9IEJnRmluYW56cGxhbklEDQpGUk9NIEJnQnVkZ2V0DQpXSEVSRSBCZ0J1ZGdldElEID0gbnVsbA0KD" +
                        "QpTRUxFQ1QNCiAgUGF5VG9DbGllbnQgPSBDQVNFDQogICAgICBXSEVOIEtCVS5LYkF1c3phaGx1bmdzQ" +
                        "XJ0Q29kZSBJTiAoMTAzLCAxMDQpICAgIFRIRU4gMQ0KICAgICAgV0hFTiBLUkUuQmFQZXJzb25JRCBJU" +
                        "yBOVUxMICAgICAgICAgICAgICAgICAgICBUSEVOIDANCiAgICAgIFdIRU4gS1JFLkJhUGVyc29uSUQgS" +
                        "U4gKFNFTEVDVCBCRlAuQmFQZXJzb25JRA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPT" +
                        "SBCZ0ZpbmFuenBsYW5fQmFQZXJzb24gIEJGUA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgV" +
                        "0hFUkUgQkZQLkJnRmluYW56cGxhbklEID0gQEJnRmluYW56cGxhbklEDQogICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgIEFORCBCRlAuSXN0VW50ZXJzdHVldHp0ID0gMSkgVEhFTiAxDQogICAgICBXS" +
                        "EVOIEtSRS5CYVBlcnNvbklEIElOIChTRUxFQ1QgQlpXLkJhUGVyc29uSUQNCiAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgIEZST00gQmdGaW5hbnpwbGFuX0JhUGVyc29uICBCRlANCiAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgSU5ORVIgSk9JTiBCYVphaGx1bmdzd2VnICBCWlcgT04gQlpXLkJhW" +
                        "mFobHVuZ3N3ZWdJRCA9IEJGUC5CYVphaGx1bmdzd2VnSUQNCiAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgIFdIRVJFIEJGUC5CZ0ZpbmFuenBsYW5JRCA9IEBCZ0ZpbmFuenBsYW5JRA0KICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICBBTkQgQkZQLklzdFVudGVyc3R1ZXR6dCA9IDEpIFRIRU4gMQ0KI" +
                        "CAgICAgRUxTRSAwDQogICAgRU5ELA0KICBFbXBmw6RuZ2VyID0NCiAgICBDQVNFIFdIRU4gS0JVLktiQ" +
                        "XVzemFobHVuZ3NBcnRDb2RlIElOICgxMDMsIDEwNCkNCiAgICAgIFRIRU4gJ0FuIEtsaWVudCcNCiAgI" +
                        "CAgIEVMU0UgSXNOdWxsKEtSRS5LcmVkaXRvciwgJycpDQogICAgRU5EICsgJyAtICcgKw0KICAgIChTR" +
                        "UxFQ1QgVGV4dCBGUk9NIFhMT1ZDb2RlIFdIRVJFIExPVk5hbWUgPSAnS2JBdXN6YWhsdW5nc0FydCcgQ" +
                        "U5EIENvZGUgPSBLQlUuS2JBdXN6YWhsdW5nc0FydENvZGUpLA0KICBLQksuQnVjaHVuZ3N0ZXh0LA0KI" +
                        "CBLT0EgPSBGS0EuS29udG9OciwNCiAgS0JVLlZhbHV0YURhdHVtLA0KICBLQlUuQmFyYmVsZWdEYXR1b" +
                        "SwNCiAgS0JLLkJldHJhZw0KRlJPTSBLYkJ1Y2h1bmcgICAgICAgICAgICAgICAgICBLQlUNCiAgSU5OR" +
                        "VIgSk9JTiBLYkJ1Y2h1bmdLb3N0ZW5hcnQgS0JLIE9OIEtCSy5LYkJ1Y2h1bmdJRCA9IEtCVS5LYkJ1Y" +
                        "2h1bmdJRA0KICBJTk5FUiBKT0lOIEJnS29zdGVuYXJ0ICAgICAgICBGS0EgT04gRktBLkJnS29zdGVuY" +
                        "XJ0SUQgPSBLQksuQmdLb3N0ZW5hcnRJRA0KICBMRUZUICBKT0lOIHZ3S3JlZGl0b3IgICAgICAgICBLU" +
                        "kUgT04gS1JFLkJhWmFobHVuZ3N3ZWdJRCA9IEtCVS5CYVphaGx1bmdzd2VnSUQNCldIRVJFIEtCVS5CZ" +
                        "0J1ZGdldElEID0gQEJnQnVkZ2V0SUQNCk9SREVSIEJZDQogIFBheVRvQ2xpZW50IERFU0MsDQogIDIsI" +
                        "C8qIEVtcGbDpG5nZXIgKi8NCiAgS0JVLlZhbHV0YURhdHVtLA0KICBLQksuQnVjaHVuZ3N0ZXh0";
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
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.Line6 = new DevExpress.XtraReports.UI.XRLine();
            this.Line5 = new DevExpress.XtraReports.UI.XRLine();
            this.Line4 = new DevExpress.XtraReports.UI.XRLine();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.txtCashOrCheckAm = new DevExpress.XtraReports.UI.XRLabel();
            this.txtVerfalldatum = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKOA = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBuchungstext = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.Line11 = new DevExpress.XtraReports.UI.XRLine();
            this.Line10 = new DevExpress.XtraReports.UI.XRLine();
            this.Line9 = new DevExpress.XtraReports.UI.XRLine();
            this.Line8 = new DevExpress.XtraReports.UI.XRLine();
            this.Line7 = new DevExpress.XtraReports.UI.XRLine();
            this.Label5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtEmpfänger = new DevExpress.XtraReports.UI.XRLabel();
            this.Betrag1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Betrag2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtBetrag,
                        this.Line6,
                        this.Line5,
                        this.Line4,
                        this.Line3,
                        this.txtCashOrCheckAm,
                        this.txtVerfalldatum,
                        this.txtKOA,
                        this.txtBuchungstext});
            this.Detail.Height = 20;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBackColor = false;
            this.Detail.ParentStyleUsing.UseBorderColor = false;
            this.Detail.ParentStyleUsing.UseBorders = false;
            this.Detail.ParentStyleUsing.UseBorderWidth = false;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblTitle});
            this.ReportHeader.Height = 25;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.ParentStyleUsing.UseBackColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorderColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorders = false;
            this.ReportHeader.ParentStyleUsing.UseBorderWidth = false;
            this.ReportHeader.ParentStyleUsing.UseFont = false;
            this.ReportHeader.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Line11,
                        this.Line10,
                        this.Line9,
                        this.Line8,
                        this.Line7,
                        this.Label5,
                        this.Label4,
                        this.Label3,
                        this.Label2,
                        this.Label1,
                        this.txtEmpfänger});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("Empfänger", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 57;
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
                        this.Betrag1,
                        this.Label6});
            this.GroupFooter1.Height = 28;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorders = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter1.ParentStyleUsing.UseFont = false;
            this.GroupFooter1.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Betrag2,
                        this.Label7,
                        this.Line2,
                        this.Line1});
            this.ReportFooter.Height = 35;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(640, 0);
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(73, 18);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtBetrag.Summary = xrSummary1;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line6
            // 
            this.Line6.ForeColor = System.Drawing.Color.Black;
            this.Line6.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line6.Location = new System.Drawing.Point(520, 0);
            this.Line6.Name = "Line6";
            this.Line6.ParentStyleUsing.UseBackColor = false;
            this.Line6.ParentStyleUsing.UseBorderColor = false;
            this.Line6.ParentStyleUsing.UseBorders = false;
            this.Line6.ParentStyleUsing.UseBorderWidth = false;
            this.Line6.ParentStyleUsing.UseFont = false;
            this.Line6.ParentStyleUsing.UseForeColor = false;
            this.Line6.Size = new System.Drawing.Size(2, 20);
            // 
            // Line5
            // 
            this.Line5.ForeColor = System.Drawing.Color.Black;
            this.Line5.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line5.Location = new System.Drawing.Point(439, 0);
            this.Line5.Name = "Line5";
            this.Line5.ParentStyleUsing.UseBackColor = false;
            this.Line5.ParentStyleUsing.UseBorderColor = false;
            this.Line5.ParentStyleUsing.UseBorders = false;
            this.Line5.ParentStyleUsing.UseBorderWidth = false;
            this.Line5.ParentStyleUsing.UseFont = false;
            this.Line5.ParentStyleUsing.UseForeColor = false;
            this.Line5.Size = new System.Drawing.Size(2, 20);
            // 
            // Line4
            // 
            this.Line4.ForeColor = System.Drawing.Color.Black;
            this.Line4.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line4.Location = new System.Drawing.Point(641, 0);
            this.Line4.Name = "Line4";
            this.Line4.ParentStyleUsing.UseBackColor = false;
            this.Line4.ParentStyleUsing.UseBorderColor = false;
            this.Line4.ParentStyleUsing.UseBorders = false;
            this.Line4.ParentStyleUsing.UseBorderWidth = false;
            this.Line4.ParentStyleUsing.UseFont = false;
            this.Line4.ParentStyleUsing.UseForeColor = false;
            this.Line4.Size = new System.Drawing.Size(2, 20);
            // 
            // Line3
            // 
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line3.Location = new System.Drawing.Point(406, 0);
            this.Line3.Name = "Line3";
            this.Line3.ParentStyleUsing.UseBackColor = false;
            this.Line3.ParentStyleUsing.UseBorderColor = false;
            this.Line3.ParentStyleUsing.UseBorders = false;
            this.Line3.ParentStyleUsing.UseBorderWidth = false;
            this.Line3.ParentStyleUsing.UseFont = false;
            this.Line3.ParentStyleUsing.UseForeColor = false;
            this.Line3.Size = new System.Drawing.Size(2, 20);
            // 
            // txtCashOrCheckAm
            // 
            this.txtCashOrCheckAm.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BarbelegDatum", "{0:MM/dd/yyyy}")});
            this.txtCashOrCheckAm.Font = new System.Drawing.Font("Arial", 10F);
            this.txtCashOrCheckAm.ForeColor = System.Drawing.Color.Black;
            this.txtCashOrCheckAm.Location = new System.Drawing.Point(522, 0);
            this.txtCashOrCheckAm.Name = "txtCashOrCheckAm";
            this.txtCashOrCheckAm.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtCashOrCheckAm.ParentStyleUsing.UseBackColor = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseBorderColor = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseBorders = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseBorderWidth = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseFont = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseForeColor = false;
            this.txtCashOrCheckAm.Size = new System.Drawing.Size(116, 18);
            xrSummary2.FormatString = "{0:dd.MM.yyyy hh:mm}";
            this.txtCashOrCheckAm.Summary = xrSummary2;
            this.txtCashOrCheckAm.Text = "txtCashOrCheckAm";
            this.txtCashOrCheckAm.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // txtVerfalldatum
            // 
            this.txtVerfalldatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ValutaDatum", "{0:MM/dd/yyyy}")});
            this.txtVerfalldatum.Font = new System.Drawing.Font("Arial", 10F);
            this.txtVerfalldatum.ForeColor = System.Drawing.Color.Black;
            this.txtVerfalldatum.Location = new System.Drawing.Point(441, 0);
            this.txtVerfalldatum.Name = "txtVerfalldatum";
            this.txtVerfalldatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtVerfalldatum.ParentStyleUsing.UseBackColor = false;
            this.txtVerfalldatum.ParentStyleUsing.UseBorderColor = false;
            this.txtVerfalldatum.ParentStyleUsing.UseBorders = false;
            this.txtVerfalldatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtVerfalldatum.ParentStyleUsing.UseFont = false;
            this.txtVerfalldatum.ParentStyleUsing.UseForeColor = false;
            this.txtVerfalldatum.Size = new System.Drawing.Size(78, 18);
            xrSummary3.FormatString = "{0:dd.MM.yyyy}";
            this.txtVerfalldatum.Summary = xrSummary3;
            this.txtVerfalldatum.Text = "txtVerfalldatum";
            this.txtVerfalldatum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // txtKOA
            // 
            this.txtKOA.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KOA", "")});
            this.txtKOA.Font = new System.Drawing.Font("Arial", 10F);
            this.txtKOA.ForeColor = System.Drawing.Color.Black;
            this.txtKOA.Location = new System.Drawing.Point(408, 0);
            this.txtKOA.Name = "txtKOA";
            this.txtKOA.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKOA.ParentStyleUsing.UseBackColor = false;
            this.txtKOA.ParentStyleUsing.UseBorderColor = false;
            this.txtKOA.ParentStyleUsing.UseBorders = false;
            this.txtKOA.ParentStyleUsing.UseBorderWidth = false;
            this.txtKOA.ParentStyleUsing.UseFont = false;
            this.txtKOA.ParentStyleUsing.UseForeColor = false;
            this.txtKOA.Size = new System.Drawing.Size(32, 18);
            this.txtKOA.Text = "KOA";
            this.txtKOA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // txtBuchungstext
            // 
            this.txtBuchungstext.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Buchungstext", "")});
            this.txtBuchungstext.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBuchungstext.ForeColor = System.Drawing.Color.Black;
            this.txtBuchungstext.Location = new System.Drawing.Point(13, 0);
            this.txtBuchungstext.Name = "txtBuchungstext";
            this.txtBuchungstext.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBuchungstext.ParentStyleUsing.UseBackColor = false;
            this.txtBuchungstext.ParentStyleUsing.UseBorderColor = false;
            this.txtBuchungstext.ParentStyleUsing.UseBorders = false;
            this.txtBuchungstext.ParentStyleUsing.UseBorderWidth = false;
            this.txtBuchungstext.ParentStyleUsing.UseFont = false;
            this.txtBuchungstext.ParentStyleUsing.UseForeColor = false;
            this.txtBuchungstext.Size = new System.Drawing.Size(393, 18);
            this.txtBuchungstext.Text = "Buchungstext";
            this.txtBuchungstext.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Silver;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTitle.ParentStyleUsing.UseBackColor = false;
            this.lblTitle.ParentStyleUsing.UseBorderColor = false;
            this.lblTitle.ParentStyleUsing.UseBorders = false;
            this.lblTitle.ParentStyleUsing.UseBorderWidth = false;
            this.lblTitle.ParentStyleUsing.UseFont = false;
            this.lblTitle.ParentStyleUsing.UseForeColor = false;
            this.lblTitle.Size = new System.Drawing.Size(720, 23);
            this.lblTitle.Text = "Zahlungen";
            this.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Line11
            // 
            this.Line11.ForeColor = System.Drawing.Color.Black;
            this.Line11.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line11.Location = new System.Drawing.Point(641, 25);
            this.Line11.Name = "Line11";
            this.Line11.ParentStyleUsing.UseBackColor = false;
            this.Line11.ParentStyleUsing.UseBorderColor = false;
            this.Line11.ParentStyleUsing.UseBorders = false;
            this.Line11.ParentStyleUsing.UseBorderWidth = false;
            this.Line11.ParentStyleUsing.UseFont = false;
            this.Line11.ParentStyleUsing.UseForeColor = false;
            this.Line11.Size = new System.Drawing.Size(2, 31);
            // 
            // Line10
            // 
            this.Line10.ForeColor = System.Drawing.Color.Black;
            this.Line10.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line10.Location = new System.Drawing.Point(520, 25);
            this.Line10.Name = "Line10";
            this.Line10.ParentStyleUsing.UseBackColor = false;
            this.Line10.ParentStyleUsing.UseBorderColor = false;
            this.Line10.ParentStyleUsing.UseBorders = false;
            this.Line10.ParentStyleUsing.UseBorderWidth = false;
            this.Line10.ParentStyleUsing.UseFont = false;
            this.Line10.ParentStyleUsing.UseForeColor = false;
            this.Line10.Size = new System.Drawing.Size(2, 31);
            // 
            // Line9
            // 
            this.Line9.ForeColor = System.Drawing.Color.Black;
            this.Line9.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line9.Location = new System.Drawing.Point(439, 25);
            this.Line9.Name = "Line9";
            this.Line9.ParentStyleUsing.UseBackColor = false;
            this.Line9.ParentStyleUsing.UseBorderColor = false;
            this.Line9.ParentStyleUsing.UseBorders = false;
            this.Line9.ParentStyleUsing.UseBorderWidth = false;
            this.Line9.ParentStyleUsing.UseFont = false;
            this.Line9.ParentStyleUsing.UseForeColor = false;
            this.Line9.Size = new System.Drawing.Size(2, 31);
            // 
            // Line8
            // 
            this.Line8.ForeColor = System.Drawing.Color.Black;
            this.Line8.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line8.Location = new System.Drawing.Point(406, 25);
            this.Line8.Name = "Line8";
            this.Line8.ParentStyleUsing.UseBackColor = false;
            this.Line8.ParentStyleUsing.UseBorderColor = false;
            this.Line8.ParentStyleUsing.UseBorders = false;
            this.Line8.ParentStyleUsing.UseBorderWidth = false;
            this.Line8.ParentStyleUsing.UseFont = false;
            this.Line8.ParentStyleUsing.UseForeColor = false;
            this.Line8.Size = new System.Drawing.Size(2, 31);
            // 
            // Line7
            // 
            this.Line7.ForeColor = System.Drawing.Color.Black;
            this.Line7.Location = new System.Drawing.Point(0, 55);
            this.Line7.Name = "Line7";
            this.Line7.ParentStyleUsing.UseBackColor = false;
            this.Line7.ParentStyleUsing.UseBorderColor = false;
            this.Line7.ParentStyleUsing.UseBorders = false;
            this.Line7.ParentStyleUsing.UseBorderWidth = false;
            this.Line7.ParentStyleUsing.UseFont = false;
            this.Line7.ParentStyleUsing.UseForeColor = false;
            this.Line7.Size = new System.Drawing.Size(720, 2);
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial", 10F);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(641, 23);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(73, 31);
            this.Label5.Text = "Betrag";
            this.Label5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial", 10F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(522, 23);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(116, 31);
            this.Label4.Text = "Ausbezahlt Kasse/Check";
            this.Label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Arial", 10F);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(441, 23);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(78, 31);
            this.Label3.Text = "Fällig am";
            this.Label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 10F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(403, 23);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(40, 31);
            this.Label2.Text = "KOA";
            this.Label2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 10F);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(15, 23);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(385, 31);
            this.Label1.Text = "Buchungstext";
            this.Label1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // txtEmpfänger
            // 
            this.txtEmpfänger.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Empfänger", "")});
            this.txtEmpfänger.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.txtEmpfänger.ForeColor = System.Drawing.Color.Black;
            this.txtEmpfänger.Location = new System.Drawing.Point(3, 0);
            this.txtEmpfänger.Multiline = true;
            this.txtEmpfänger.Name = "txtEmpfänger";
            this.txtEmpfänger.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtEmpfänger.ParentStyleUsing.UseBackColor = false;
            this.txtEmpfänger.ParentStyleUsing.UseBorderColor = false;
            this.txtEmpfänger.ParentStyleUsing.UseBorders = false;
            this.txtEmpfänger.ParentStyleUsing.UseBorderWidth = false;
            this.txtEmpfänger.ParentStyleUsing.UseFont = false;
            this.txtEmpfänger.ParentStyleUsing.UseForeColor = false;
            this.txtEmpfänger.Size = new System.Drawing.Size(720, 20);
            this.txtEmpfänger.Text = "Empfänger";
            // 
            // Betrag1
            // 
            this.Betrag1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.Betrag1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Betrag1.ForeColor = System.Drawing.Color.Black;
            this.Betrag1.Location = new System.Drawing.Point(641, 7);
            this.Betrag1.Name = "Betrag1";
            this.Betrag1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Betrag1.ParentStyleUsing.UseBackColor = false;
            this.Betrag1.ParentStyleUsing.UseBorderColor = false;
            this.Betrag1.ParentStyleUsing.UseBorders = false;
            this.Betrag1.ParentStyleUsing.UseBorderWidth = false;
            this.Betrag1.ParentStyleUsing.UseFont = false;
            this.Betrag1.ParentStyleUsing.UseForeColor = false;
            this.Betrag1.Size = new System.Drawing.Size(73, 18);
            xrSummary4.FormatString = "{0:#,##0.00}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.Betrag1.Summary = xrSummary4;
            this.Betrag1.Text = "Betrag";
            this.Betrag1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(409, 7);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(236, 18);
            this.Label6.Text = "Total für diesen Empfänger";
            this.Label6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Betrag2
            // 
            this.Betrag2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.Betrag2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Betrag2.ForeColor = System.Drawing.Color.Black;
            this.Betrag2.Location = new System.Drawing.Point(641, 6);
            this.Betrag2.Name = "Betrag2";
            this.Betrag2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Betrag2.ParentStyleUsing.UseBackColor = false;
            this.Betrag2.ParentStyleUsing.UseBorderColor = false;
            this.Betrag2.ParentStyleUsing.UseBorders = false;
            this.Betrag2.ParentStyleUsing.UseBorderWidth = false;
            this.Betrag2.ParentStyleUsing.UseFont = false;
            this.Betrag2.ParentStyleUsing.UseForeColor = false;
            this.Betrag2.Size = new System.Drawing.Size(73, 18);
            xrSummary5.FormatString = "{0:#,##0.00}";
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.Betrag2.Summary = xrSummary5;
            this.Betrag2.Text = "Betrag";
            this.Betrag2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(409, 6);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(236, 18);
            this.Label7.Text = "Total Zahlungen";
            this.Label7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.Location = new System.Drawing.Point(0, 31);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(720, 2);
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.Location = new System.Drawing.Point(0, 0);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(720, 2);
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
                        this.GroupHeader1,
                        this.GroupFooter1,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(100, 0, 100, 100);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' ,  N'<?xml version="1.0" standalone="yes" ?>
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
</NewDataSet>' ,  N'DECLARE @BgBudgetID     int,
        @BgFinanzplanID int

SELECT
  @BgBudgetID = BgBudgetID,
  @BgFinanzplanID = BgFinanzplanID
FROM BgBudget
WHERE BgBudgetID = {BgBudgetID}

SELECT
  PayToClient = CASE
      WHEN KBU.KbAuszahlungsArtCode IN (103, 104)    THEN 1
      WHEN KRE.BaPersonID IS NULL                    THEN 0
      WHEN KRE.BaPersonID IN (SELECT BFP.BaPersonID
                              FROM BgFinanzplan_BaPerson  BFP
                              WHERE BFP.BgFinanzplanID = @BgFinanzplanID
                                AND BFP.IstUnterstuetzt = 1) THEN 1
      WHEN KRE.BaPersonID IN (SELECT BZW.BaPersonID
                              FROM BgFinanzplan_BaPerson  BFP
                                INNER JOIN BaZahlungsweg  BZW ON BZW.BaZahlungswegID = BFP.BaZahlungswegID
                              WHERE BFP.BgFinanzplanID = @BgFinanzplanID
                                AND BFP.IstUnterstuetzt = 1) THEN 1
      ELSE 0
    END,
  Empfänger =
    CASE WHEN KBU.KbAuszahlungsArtCode IN (103, 104)
      THEN ''An Klient''
      ELSE IsNull(KRE.Kreditor, ''(ohne Namen)'')
    END + '' - '' +
    (SELECT Text FROM XLOVCode WHERE LOVName = ''KbAuszahlungsArt'' AND Code = KBU.KbAuszahlungsArtCode),
  KBK.Buchungstext,
  KOA = FKA.KontoNr,
  KBU.ValutaDatum,
  KBU.BarbelegDatum,
  KBK.Betrag
FROM KbBuchung                  KBU
  INNER JOIN KbBuchungKostenart KBK ON KBK.KbBuchungID = KBU.KbBuchungID
  INNER JOIN BgKostenart        FKA ON FKA.BgKostenartID = KBK.BgKostenartID
  LEFT  JOIN vwKreditor         KRE ON KRE.BaZahlungswegID = KBU.BaZahlungswegID
WHERE KBU.BgBudgetID = @BgBudgetID
ORDER BY
  PayToClient DESC,
  2, /* Empfänger */
  KBU.ValutaDatum,
  KBK.Buchungstext' ,  null ,  N'ShUebersichtMonatsbudget2' ,  null )

INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShUebersichtMonatsbudget2_Budget' ,  N'Monatsbudget2-Budget' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Temp\KiSS4_Migration\KiSS4.DB.dll" />
///     <Reference Path="C:\Temp\KiSS4_Migration\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel Betrag1;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtKOA;
        private DevExpress.XtraReports.UI.XRLabel txtBezeichnung;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel lblTitle;
        private DevExpress.XtraReports.UI.GroupHeaderBand grp1H;
        private DevExpress.XtraReports.UI.XRLabel txtGrp1Text;
        private DevExpress.XtraReports.UI.GroupHeaderBand grp2H;
        private DevExpress.XtraReports.UI.XRLabel txtGrp2Text;
        private DevExpress.XtraReports.UI.GroupHeaderBand grp3H;
        private DevExpress.XtraReports.UI.XRLabel txtGrp3Text;
        private DevExpress.XtraReports.UI.GroupFooterBand grp3F;
        private DevExpress.XtraReports.UI.GroupFooterBand grp2F;
        private DevExpress.XtraReports.UI.GroupFooterBand grp1F;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel lblTotGrp1;
        private DevExpress.XtraReports.UI.XRLabel Grp1Betrag;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRPanel HiddenPanel;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel hiddenLblGroupText;
        private DevExpress.XtraReports.UI.XRLabel hiddenLblShPositionTypID;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAACAAAAAAAAAFBBRFBBRFATtE6kz" +
                        "4L1rTsAAAAAAAAANgEAADZnAHIAcAAyAEgALgBTAGMAcgBpAHAAdABzAC4ATwBuAEIAZQBmAG8AcgBlA" +
                        "FAAcgBpAG4AdAAAAAAAMnMAcQBsAFEAdQBlAHIAeQAxAC4AUwBlAGwAZQBjAHQAUwB0AGEAdABlAG0AZ" +
                        "QBuAHQAOQEAAAG2AnByaXZhdGUgdm9pZCBPbkJlZm9yZVByaW50KG9iamVjdCBzZW5kZXIsIFN5c3Rlb" +
                        "S5EcmF3aW5nLlByaW50aW5nLlByaW50RXZlbnRBcmdzIGUpIHsNCiAgIHRyeSB7DQogICAgICAvLyBoa" +
                        "WRlIGdycDIgaWYgZW1wdHkNCiAgICAgIGdycDJILlZpc2libGUgPSBoaWRkZW5MYmxTaFBvc2l0aW9uV" +
                        "HlwSUQuVGV4dCAhPSBzdHJpbmcuRW1wdHk7DQogICB9Y2F0Y2ggKFN5c3RlbS5FeGNlcHRpb24gZXgpI" +
                        "HsNCiAgICAgIFN5c3RlbS5XaW5kb3dzLkZvcm1zLk1lc3NhZ2VCb3guU2hvdyhleC5TdGFja1RyYWNlL" +
                        "CBleC5NZXNzYWdlKTsNCiAgIH0NCn0BwgtERUNMQVJFIEBSZWZEYXRlICBkYXRldGltZSAgU0VUIEBSZ" +
                        "WZEYXRlID0gR2V0RGF0ZSgpDQoNClNFTEVDVA0KICBUTVAuQmdLYXRlZ29yaWVDb2RlLCBCZ0thdGVnb" +
                        "3JpZVRleHQgPSBCUEMuVGV4dCwNCiAgVE1QLkJnR3J1cHBlQ29kZSwgQmdHcnVwcGVUZXh0ID0gU1BDL" +
                        "lRleHQsDQogIFRNUC5CZ1Bvc2l0aW9uc2FydElELA0KICBUTVAuRHJpdHRlLA0KICBUTVAuQmdTcGV6a" +
                        "29udG9JRCwNCg0KICBHcm91cFRleHQgPSBDQVNFIFRNUC5CZ0thdGVnb3JpZUNvZGUNCiAgICAgICAgI" +
                        "CAgICAgICBXSEVOIDEgICBUSEVOICdFaW5uYWhtZW4sICcgKyBDQVNFIFdIRU4gVE1QLkRyaXR0ZSA9I" +
                        "DEgVEhFTiAndm9uIFNEJyBFTFNFICd2b24gS2xpZW50L2luJyBFTkQgKyAnIHZlcndhbHRldCcNCiAgI" +
                        "CAgICAgICAgICAgICBXSEVOIDIgICBUSEVOIENBU0UgV0hFTiBUTVAuQmdTcGV6a29udG9JRCBJUyBOV" +
                        "UxMDQogICAgICAgICAgICAgICAgICBUSEVOICdWZXJnw7x0dW5nIGFuICcgKyBDQVNFIFdIRU4gVE1QL" +
                        "kRyaXR0ZSA9IDEgVEhFTiAnRHJpdHRlJyBFTFNFICdLbGllbnQvaW4nIEVORA0KICAgICAgICAgICAgI" +
                        "CAgICAgRUxTRSAnR3V0c2NocmlmdCBhdWYgQXVzZ2FiZWtvbnRpJw0KICAgICAgICAgICAgICAgIEVOR" +
                        "A0KICAgICAgICAgICAgICAgIFdIRU4gMTAwIFRIRU4gJ0ZpbmFuemllcnVuZyBhbHMgU0lMICcgKyBTU" +
                        "FQuTmFtZQ0KICAgICAgICAgICAgICAgIEVMU0UgQ0FTRSBXSEVOIFRNUC5CZ1NwZXprb250b0lEIElTI" +
                        "E5PVCBOVUxMDQogICAgICAgICAgICAgICAgICBUSEVOICdGaW5hbnppZXJ1bmcgZHVyY2ggJyArIGRib" +
                        "y5mbkxPVlRleHQoJ0JnU3BlemtvbnRvVHlwJywgU1BLLkJnU3BlemtvbnRvVHlwQ29kZSkNCiAgICAgI" +
                        "CAgICAgICAgICAgIEVMU0UgJ0ZpbmFuemllcnVuZyBkdXJjaCBHcnVuZGJlZGFyZicNCiAgICAgICAgI" +
                        "CAgICAgICBFTkQNCiAgICAgICAgICAgICAgRU5ELA0KDQogIEJlemVpY2hudW5nID0gTFRyaW0oVE1QL" +
                        "kJlemVpY2hudW5nKSwgVE1QLkJldHJhZywgVE1QLktPQSwgVE1QLkJlbWVya3VuZw0KRlJPTSBkYm8uZ" +
                        "m5XaEdldEJ1ZGdldChudWxsLCBAUmVmRGF0ZSkgIFRNUA0KICBMRUZUICBKT0lOIFhMT1ZDb2RlICAgI" +
                        "CAgICBCUEMgT04gQlBDLkxPVk5hbWUgPSAnQmdLYXRlZ29yaWUnIEFORCBCUEMuQ29kZSA9IFRNUC5CZ" +
                        "0thdGVnb3JpZUNvZGUNCiAgTEVGVCAgSk9JTiBYTE9WQ29kZSAgICAgICAgU1BDIE9OIFNQQy5MT1ZOY" +
                        "W1lID0gJ0JnR3J1cHBlJyBBTkQgU1BDLkNvZGUgPSBUTVAuQmdHcnVwcGVDb2RlDQogIExFRlQgIEpPS" +
                        "U4gQmdQb3NpdGlvbnNhcnQgIFNQVCBPTiBTUFQuQmdQb3NpdGlvbnNhcnRJRCA9IFRNUC5CZ1Bvc2l0a" +
                        "W9uc2FydElEDQogIExFRlQgIEpPSU4gQmdTcGV6a29udG8gICAgIFNQSyBPTiBTUEsuQmdTcGV6a29ud" +
                        "G9JRCA9IFRNUC5CZ1NwZXprb250b0lEDQpXSEVSRSBUTVAuQmdQb3NpdGlvbklEIElTIE5PVCBOVUxM";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.grp1H = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.grp2H = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.grp3H = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.grp3F = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.grp2F = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.grp1F = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.Betrag1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKOA = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBezeichnung = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGrp1Text = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGrp2Text = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGrp3Text = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.lblTotGrp1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Grp1Betrag = new DevExpress.XtraReports.UI.XRLabel();
            this.HiddenPanel = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.hiddenLblGroupText = new DevExpress.XtraReports.UI.XRLabel();
            this.hiddenLblShPositionTypID = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Betrag1,
                        this.txtKOA,
                        this.txtBezeichnung});
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
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblTitle});
            this.ReportHeader.Height = 25;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.ParentStyleUsing.UseBackColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorderColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorders = false;
            this.ReportHeader.ParentStyleUsing.UseBorderWidth = false;
            this.ReportHeader.ParentStyleUsing.UseFont = false;
            this.ReportHeader.ParentStyleUsing.UseForeColor = false;
            // 
            // grp1H
            // 
            this.grp1H.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtGrp1Text});
            this.grp1H.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("BgKategorieCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.grp1H.Height = 23;
            this.grp1H.Level = 2;
            this.grp1H.Name = "grp1H";
            this.grp1H.ParentStyleUsing.UseBackColor = false;
            this.grp1H.ParentStyleUsing.UseBorderColor = false;
            this.grp1H.ParentStyleUsing.UseBorders = false;
            this.grp1H.ParentStyleUsing.UseBorderWidth = false;
            this.grp1H.ParentStyleUsing.UseFont = false;
            this.grp1H.ParentStyleUsing.UseForeColor = false;
            // 
            // grp2H
            // 
            this.grp2H.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtGrp2Text});
            this.grp2H.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("BgGruppeCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.grp2H.Height = 19;
            this.grp2H.Level = 1;
            this.grp2H.Name = "grp2H";
            this.grp2H.ParentStyleUsing.UseBackColor = false;
            this.grp2H.ParentStyleUsing.UseBorderColor = false;
            this.grp2H.ParentStyleUsing.UseBorders = false;
            this.grp2H.ParentStyleUsing.UseBorderWidth = false;
            this.grp2H.ParentStyleUsing.UseFont = false;
            this.grp2H.ParentStyleUsing.UseForeColor = false;
            this.grp2H.Scripts.OnBeforePrint = resources.GetString("grp2H.Scripts.OnBeforePrint");
            // 
            // grp3H
            // 
            this.grp3H.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtGrp3Text});
            this.grp3H.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("GroupText", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.grp3H.Height = 15;
            this.grp3H.Name = "grp3H";
            this.grp3H.ParentStyleUsing.UseBackColor = false;
            this.grp3H.ParentStyleUsing.UseBorderColor = false;
            this.grp3H.ParentStyleUsing.UseBorders = false;
            this.grp3H.ParentStyleUsing.UseBorderWidth = false;
            this.grp3H.ParentStyleUsing.UseFont = false;
            this.grp3H.ParentStyleUsing.UseForeColor = false;
            this.grp3H.Scripts.OnBeforePrint = "private void OnBeforePrint(object sender, System.Drawing.Printing.PrintEventArgs " +
                "e) {\r\n      // hide grp3 if empty\r\n      grp3H.Visible = hiddenLblGroupText.Text" +
                " != string.Empty;\r\n}";
            // 
            // grp3F
            // 
            this.grp3F.Height = 6;
            this.grp3F.Name = "grp3F";
            this.grp3F.ParentStyleUsing.UseBackColor = false;
            this.grp3F.ParentStyleUsing.UseBorderColor = false;
            this.grp3F.ParentStyleUsing.UseBorders = false;
            this.grp3F.ParentStyleUsing.UseBorderWidth = false;
            this.grp3F.ParentStyleUsing.UseFont = false;
            this.grp3F.ParentStyleUsing.UseForeColor = false;
            this.grp3F.Visible = false;
            // 
            // grp2F
            // 
            this.grp2F.Height = 7;
            this.grp2F.Level = 1;
            this.grp2F.Name = "grp2F";
            this.grp2F.ParentStyleUsing.UseBackColor = false;
            this.grp2F.ParentStyleUsing.UseBorderColor = false;
            this.grp2F.ParentStyleUsing.UseBorders = false;
            this.grp2F.ParentStyleUsing.UseBorderWidth = false;
            this.grp2F.ParentStyleUsing.UseFont = false;
            this.grp2F.ParentStyleUsing.UseForeColor = false;
            this.grp2F.Visible = false;
            // 
            // grp1F
            // 
            this.grp1F.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel1,
                        this.Line2,
                        this.Line1,
                        this.lblTotGrp1,
                        this.Grp1Betrag});
            this.grp1F.Height = 54;
            this.grp1F.Level = 2;
            this.grp1F.Name = "grp1F";
            this.grp1F.ParentStyleUsing.UseBackColor = false;
            this.grp1F.ParentStyleUsing.UseBorderColor = false;
            this.grp1F.ParentStyleUsing.UseBorders = false;
            this.grp1F.ParentStyleUsing.UseBorderWidth = false;
            this.grp1F.ParentStyleUsing.UseFont = false;
            this.grp1F.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.HiddenPanel});
            this.ReportFooter.Height = 87;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
            this.ReportFooter.Visible = false;
            // 
            // Betrag1
            // 
            this.Betrag1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.Betrag1.Font = new System.Drawing.Font("Arial", 10F);
            this.Betrag1.ForeColor = System.Drawing.Color.Black;
            this.Betrag1.Location = new System.Drawing.Point(469, 0);
            this.Betrag1.Multiline = true;
            this.Betrag1.Name = "Betrag1";
            this.Betrag1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Betrag1.ParentStyleUsing.UseBackColor = false;
            this.Betrag1.ParentStyleUsing.UseBorderColor = false;
            this.Betrag1.ParentStyleUsing.UseBorders = false;
            this.Betrag1.ParentStyleUsing.UseBorderWidth = false;
            this.Betrag1.ParentStyleUsing.UseFont = false;
            this.Betrag1.ParentStyleUsing.UseForeColor = false;
            this.Betrag1.Size = new System.Drawing.Size(97, 15);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.Betrag1.Summary = xrSummary1;
            this.Betrag1.Text = "Betrag";
            this.Betrag1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtKOA
            // 
            this.txtKOA.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KOA", "")});
            this.txtKOA.Font = new System.Drawing.Font("Arial", 10F);
            this.txtKOA.ForeColor = System.Drawing.Color.Black;
            this.txtKOA.Location = new System.Drawing.Point(422, 0);
            this.txtKOA.Multiline = true;
            this.txtKOA.Name = "txtKOA";
            this.txtKOA.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKOA.ParentStyleUsing.UseBackColor = false;
            this.txtKOA.ParentStyleUsing.UseBorderColor = false;
            this.txtKOA.ParentStyleUsing.UseBorders = false;
            this.txtKOA.ParentStyleUsing.UseBorderWidth = false;
            this.txtKOA.ParentStyleUsing.UseFont = false;
            this.txtKOA.ParentStyleUsing.UseForeColor = false;
            this.txtKOA.Size = new System.Drawing.Size(47, 15);
            this.txtKOA.Text = "KOA";
            // 
            // txtBezeichnung
            // 
            this.txtBezeichnung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bezeichnung", "")});
            this.txtBezeichnung.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBezeichnung.ForeColor = System.Drawing.Color.Black;
            this.txtBezeichnung.Location = new System.Drawing.Point(42, 0);
            this.txtBezeichnung.Multiline = true;
            this.txtBezeichnung.Name = "txtBezeichnung";
            this.txtBezeichnung.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBezeichnung.ParentStyleUsing.UseBackColor = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorderColor = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorders = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorderWidth = false;
            this.txtBezeichnung.ParentStyleUsing.UseFont = false;
            this.txtBezeichnung.ParentStyleUsing.UseForeColor = false;
            this.txtBezeichnung.Size = new System.Drawing.Size(375, 15);
            this.txtBezeichnung.Text = "Bezeichnung";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Silver;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTitle.ParentStyleUsing.UseBackColor = false;
            this.lblTitle.ParentStyleUsing.UseBorderColor = false;
            this.lblTitle.ParentStyleUsing.UseBorders = false;
            this.lblTitle.ParentStyleUsing.UseBorderWidth = false;
            this.lblTitle.ParentStyleUsing.UseFont = false;
            this.lblTitle.ParentStyleUsing.UseForeColor = false;
            this.lblTitle.Size = new System.Drawing.Size(724, 23);
            this.lblTitle.Text = "Budget";
            this.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtGrp1Text
            // 
            this.txtGrp1Text.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BgKategorieText", "")});
            this.txtGrp1Text.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtGrp1Text.ForeColor = System.Drawing.Color.Black;
            this.txtGrp1Text.Location = new System.Drawing.Point(0, 0);
            this.txtGrp1Text.Multiline = true;
            this.txtGrp1Text.Name = "txtGrp1Text";
            this.txtGrp1Text.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGrp1Text.ParentStyleUsing.UseBackColor = false;
            this.txtGrp1Text.ParentStyleUsing.UseBorderColor = false;
            this.txtGrp1Text.ParentStyleUsing.UseBorders = false;
            this.txtGrp1Text.ParentStyleUsing.UseBorderWidth = false;
            this.txtGrp1Text.ParentStyleUsing.UseFont = false;
            this.txtGrp1Text.ParentStyleUsing.UseForeColor = false;
            this.txtGrp1Text.Size = new System.Drawing.Size(640, 21);
            this.txtGrp1Text.Text = "txtGrp1Text";
            // 
            // txtGrp2Text
            // 
            this.txtGrp2Text.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BgGruppeText", "")});
            this.txtGrp2Text.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtGrp2Text.ForeColor = System.Drawing.Color.Black;
            this.txtGrp2Text.Location = new System.Drawing.Point(8, 0);
            this.txtGrp2Text.Multiline = true;
            this.txtGrp2Text.Name = "txtGrp2Text";
            this.txtGrp2Text.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGrp2Text.ParentStyleUsing.UseBackColor = false;
            this.txtGrp2Text.ParentStyleUsing.UseBorderColor = false;
            this.txtGrp2Text.ParentStyleUsing.UseBorders = false;
            this.txtGrp2Text.ParentStyleUsing.UseBorderWidth = false;
            this.txtGrp2Text.ParentStyleUsing.UseFont = false;
            this.txtGrp2Text.ParentStyleUsing.UseForeColor = false;
            this.txtGrp2Text.Size = new System.Drawing.Size(620, 15);
            this.txtGrp2Text.Text = "txtGrp2Text";
            // 
            // txtGrp3Text
            // 
            this.txtGrp3Text.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GroupText", "")});
            this.txtGrp3Text.Font = new System.Drawing.Font("Arial", 10F);
            this.txtGrp3Text.ForeColor = System.Drawing.Color.Black;
            this.txtGrp3Text.Location = new System.Drawing.Point(25, 0);
            this.txtGrp3Text.Multiline = true;
            this.txtGrp3Text.Name = "txtGrp3Text";
            this.txtGrp3Text.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGrp3Text.ParentStyleUsing.UseBackColor = false;
            this.txtGrp3Text.ParentStyleUsing.UseBorderColor = false;
            this.txtGrp3Text.ParentStyleUsing.UseBorders = false;
            this.txtGrp3Text.ParentStyleUsing.UseBorderWidth = false;
            this.txtGrp3Text.ParentStyleUsing.UseFont = false;
            this.txtGrp3Text.ParentStyleUsing.UseForeColor = false;
            this.txtGrp3Text.Size = new System.Drawing.Size(606, 15);
            this.txtGrp3Text.Text = "GroupText";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BgKategorieText", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.Location = new System.Drawing.Point(353, 7);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(100, 20);
            this.xrLabel1.Text = "xrLabel1";
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.Location = new System.Drawing.Point(0, 31);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(564, 2);
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.Location = new System.Drawing.Point(311, 0);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(255, 2);
            // 
            // lblTotGrp1
            // 
            this.lblTotGrp1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotGrp1.ForeColor = System.Drawing.Color.Black;
            this.lblTotGrp1.Location = new System.Drawing.Point(311, 7);
            this.lblTotGrp1.Name = "lblTotGrp1";
            this.lblTotGrp1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTotGrp1.ParentStyleUsing.UseBackColor = false;
            this.lblTotGrp1.ParentStyleUsing.UseBorderColor = false;
            this.lblTotGrp1.ParentStyleUsing.UseBorders = false;
            this.lblTotGrp1.ParentStyleUsing.UseBorderWidth = false;
            this.lblTotGrp1.ParentStyleUsing.UseFont = false;
            this.lblTotGrp1.ParentStyleUsing.UseForeColor = false;
            this.lblTotGrp1.Size = new System.Drawing.Size(159, 13);
            this.lblTotGrp1.Text = "Total";
            // 
            // Grp1Betrag
            // 
            this.Grp1Betrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.Grp1Betrag.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Grp1Betrag.ForeColor = System.Drawing.Color.Black;
            this.Grp1Betrag.Location = new System.Drawing.Point(469, 7);
            this.Grp1Betrag.Multiline = true;
            this.Grp1Betrag.Name = "Grp1Betrag";
            this.Grp1Betrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Grp1Betrag.ParentStyleUsing.UseBackColor = false;
            this.Grp1Betrag.ParentStyleUsing.UseBorderColor = false;
            this.Grp1Betrag.ParentStyleUsing.UseBorders = false;
            this.Grp1Betrag.ParentStyleUsing.UseBorderWidth = false;
            this.Grp1Betrag.ParentStyleUsing.UseFont = false;
            this.Grp1Betrag.ParentStyleUsing.UseForeColor = false;
            this.Grp1Betrag.Size = new System.Drawing.Size(97, 15);
            xrSummary2.FormatString = "{0:#,##0.00}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.Grp1Betrag.Summary = xrSummary2;
            this.Grp1Betrag.Text = "Grp1Betrag";
            this.Grp1Betrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // HiddenPanel
            // 
            this.HiddenPanel.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel2,
                        this.hiddenLblGroupText,
                        this.hiddenLblShPositionTypID});
            this.HiddenPanel.Location = new System.Drawing.Point(160, 27);
            this.HiddenPanel.Name = "HiddenPanel";
            this.HiddenPanel.Scripts.OnBeforePrint = "private void OnBeforePrint(object sender, System.Drawing.Printing.PrintEventArgs " +
                "e) {\r\n   HiddenPanel.Visible = false;\r\n}";
            this.HiddenPanel.Size = new System.Drawing.Size(293, 47);
            // 
            // xrLabel2
            // 
            this.xrLabel2.Location = new System.Drawing.Point(193, 20);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.Size = new System.Drawing.Size(100, 27);
            this.xrLabel2.Text = "nur ein test";
            // 
            // hiddenLblGroupText
            // 
            this.hiddenLblGroupText.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GroupText", "")});
            this.hiddenLblGroupText.Location = new System.Drawing.Point(0, 27);
            this.hiddenLblGroupText.Name = "hiddenLblGroupText";
            this.hiddenLblGroupText.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hiddenLblGroupText.Size = new System.Drawing.Size(100, 27);
            this.hiddenLblGroupText.Text = "hiddenLblGroupText";
            // 
            // hiddenLblShPositionTypID
            // 
            this.hiddenLblShPositionTypID.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BgGruppeCode", "")});
            this.hiddenLblShPositionTypID.Location = new System.Drawing.Point(0, 0);
            this.hiddenLblShPositionTypID.Name = "hiddenLblShPositionTypID";
            this.hiddenLblShPositionTypID.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hiddenLblShPositionTypID.Size = new System.Drawing.Size(160, 20);
            this.hiddenLblShPositionTypID.Text = "hiddenLblShPositionTypID";
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
                        this.grp1H,
                        this.grp2H,
                        this.grp3H,
                        this.grp3F,
                        this.grp2F,
                        this.grp1F,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(100, 0, 100, 100);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ScriptReferencesString = "System.Windows.Forms.dll";
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
</NewDataSet>' ,  N'DECLARE @RefDate  datetime  SET @RefDate = GetDate()

SELECT
  TMP.BgKategorieCode, BgKategorieText = BPC.Text,
  TMP.BgGruppeCode, BgGruppeText = SPC.Text,
  TMP.BgPositionsartID,
  TMP.Dritte,
  TMP.BgSpezkontoID,

  GroupText = CASE TMP.BgKategorieCode
                WHEN 1   THEN ''Einnahmen, '' + CASE WHEN TMP.Dritte = 1 THEN ''von SD'' ELSE ''von Klient/in'' END + '' verwaltet''
                WHEN 2   THEN CASE WHEN TMP.BgSpezkontoID IS NULL
                  THEN ''Vergütung an '' + CASE WHEN TMP.Dritte = 1 THEN ''Dritte'' ELSE ''Klient/in'' END
                  ELSE ''Gutschrift auf Ausgabekonti''
                END
                WHEN 100 THEN ''Finanzierung als SIL '' + SPT.Name
                ELSE CASE WHEN TMP.BgSpezkontoID IS NOT NULL
                  THEN ''Finanzierung durch '' + dbo.fnLOVText(''BgSpezkontoTyp'', SPK.BgSpezkontoTypCode)
                  ELSE ''Finanzierung durch Grundbedarf''
                END
              END,

  Bezeichnung = LTrim(TMP.Bezeichnung), TMP.Betrag, TMP.KOA, TMP.Bemerkung
FROM dbo.fnWhGetBudget({BgBudgetID}, @RefDate)  TMP
  LEFT  JOIN XLOVCode        BPC ON BPC.LOVName = ''BgKategorie'' AND BPC.Code = TMP.BgKategorieCode
  LEFT  JOIN XLOVCode        SPC ON SPC.LOVName = ''BgGruppe'' AND SPC.Code = TMP.BgGruppeCode
  LEFT  JOIN BgPositionsart  SPT ON SPT.BgPositionsartID = TMP.BgPositionsartID
  LEFT  JOIN BgSpezkonto     SPK ON SPK.BgSpezkontoID = TMP.BgSpezkontoID
WHERE TMP.BgPositionID IS NOT NULL' ,  null ,  N'ShUebersichtMonatsbudget2' ,  null )

