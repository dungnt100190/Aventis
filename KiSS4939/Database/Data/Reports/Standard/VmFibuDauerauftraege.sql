-- Insert Script for VmFibuDauerauftraege
-- MD5:0XFA94645985CA33F8E6EA90956E9755EC_0XFB119AC1935440F10887D714E282AC3D_0XB24A0C35D866B3C84049E7D22F262A12
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'VmFibuDauerauftraege') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('VmFibuDauerauftraege', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'VmFibuDauerauftraege';
UPDATE QRY
SET QueryName =  N'VmFibuDauerauftraege' , UserText =  N'VM - Fibu Daueraufträge' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>C:\Programme\Born Informatik AG\KiSS4\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>de-DE</Localization>
///   <References>
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Drawing\2.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System\2.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Configuration\2.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Xml\2.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Data.SqlXml\2.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Security\2.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.Utils.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Windows.Forms\2.0.0.0__b77a5c561934e089\System.Windows.Forms.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\Accessibility\2.0.0.0__b03f5f7f11d50a3a\Accessibility.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Runtime.Serialization.Formatters.Soap\2.0.0.0__b03f5f7f11d50a3a\System.Runtime.Serialization.Formatters.Soap.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Deployment\2.0.0.0__b03f5f7f11d50a3a\System.Deployment.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Design\2.0.0.0__b03f5f7f11d50a3a\System.Design.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_32\System.Data\2.0.0.0__b77a5c561934e089\System.Data.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\Microsoft.VisualC\8.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualC.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_32\System.Transactions\2.0.0.0__b77a5c561934e089\System.Transactions.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_32\System.EnterpriseServices\2.0.0.0__b03f5f7f11d50a3a\System.EnterpriseServices.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.DirectoryServices\2.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Runtime.Remoting\2.0.0.0__b77a5c561934e089\System.Runtime.Remoting.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_32\System.Web\2.0.0.0__b03f5f7f11d50a3a\System.Web.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Web.Services\2.0.0.0__b03f5f7f11d50a3a\System.Web.Services.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.DirectoryServices.Protocols\2.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.Protocols.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.ServiceProcess\2.0.0.0__b03f5f7f11d50a3a\System.ServiceProcess.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Configuration.Install\2.0.0.0__b03f5f7f11d50a3a\System.Configuration.Install.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Web.RegularExpressions\2.0.0.0__b03f5f7f11d50a3a\System.Web.RegularExpressions.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Drawing.Design\2.0.0.0__b03f5f7f11d50a3a\System.Drawing.Design.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_32\System.Data.OracleClient\2.0.0.0__b77a5c561934e089\System.Data.OracleClient.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.Data.v6.2.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\KiSS4.DB.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\SharpLibrary.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Programme\Born Informatik AG\KiSS4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtLetzteAusfuehrung;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtText;
        private DevExpress.XtraReports.UI.XRLabel txtGueltigBis;
        private DevExpress.XtraReports.UI.XRLabel txtGueltigVon;
        private DevExpress.XtraReports.UI.XRLabel txtMonatstag2;
        private DevExpress.XtraReports.UI.XRLabel txtMonatstag1;
        private DevExpress.XtraReports.UI.XRLabel txtAuftragPeriodizitaet;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private DevExpress.XtraReports.UI.XRLabel txtMandant;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel Label16;
        private DevExpress.XtraReports.UI.XRLabel Label15;
        private DevExpress.XtraReports.UI.XRLabel Label14;
        private DevExpress.XtraReports.UI.XRLabel Label13;
        private DevExpress.XtraReports.UI.XRLabel Label12;
        private DevExpress.XtraReports.UI.XRLabel Label11;
        private DevExpress.XtraReports.UI.XRLabel Label10;
        private DevExpress.XtraReports.UI.XRLabel Label9;
        private DevExpress.XtraReports.UI.XRLabel Label8;
        private DevExpress.XtraReports.UI.XRLabel Geburtsdatum1;
        private DevExpress.XtraReports.UI.XRLabel TextBox13;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLabel lblKtoNr;
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
                    string resourceString = @"zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OSNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAAAAAAAAAAAAFBBRFBBRFC0AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==";
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
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.txtLetzteAusfuehrung = new DevExpress.XtraReports.UI.XRLabel();
            this.txtText = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGueltigBis = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGueltigVon = new DevExpress.XtraReports.UI.XRLabel();
            this.txtMonatstag2 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtMonatstag1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAuftragPeriodizitaet = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtMandant = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label16 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label15 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label14 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label13 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label12 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label11 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label10 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label9 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Geburtsdatum1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox13 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.lblKtoNr = new DevExpress.XtraReports.UI.XRLabel();
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
                        this.txtLetzteAusfuehrung,
                        this.txtText,
                        this.txtGueltigBis,
                        this.txtGueltigVon,
                        this.txtMonatstag2,
                        this.txtMonatstag1,
                        this.txtAuftragPeriodizitaet,
                        this.txtBetrag,
                        this.txtMandant});
            this.Detail.Height = 26;
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
                        this.xrLabel2,
                        this.Label16,
                        this.Label15,
                        this.Label14,
                        this.Label13,
                        this.Label12,
                        this.Label11,
                        this.Label10,
                        this.Label9,
                        this.Label8,
                        this.Geburtsdatum1,
                        this.TextBox13,
                        this.Label4,
                        this.Line3,
                        this.lblKtoNr});
            this.PageHeader.Height = 237;
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
            this.PageFooter.Height = 67;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // txtLetzteAusfuehrung
            // 
            this.txtLetzteAusfuehrung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "LetzteAusfuehrung", "{0:dd.MM.yyyy}")});
            this.txtLetzteAusfuehrung.Font = new System.Drawing.Font("Arial", 9F);
            this.txtLetzteAusfuehrung.ForeColor = System.Drawing.Color.Black;
            this.txtLetzteAusfuehrung.Location = new System.Drawing.Point(964, 6);
            this.txtLetzteAusfuehrung.Multiline = true;
            this.txtLetzteAusfuehrung.Name = "txtLetzteAusfuehrung";
            this.txtLetzteAusfuehrung.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtLetzteAusfuehrung.ParentStyleUsing.UseBackColor = false;
            this.txtLetzteAusfuehrung.ParentStyleUsing.UseBorderColor = false;
            this.txtLetzteAusfuehrung.ParentStyleUsing.UseBorders = false;
            this.txtLetzteAusfuehrung.ParentStyleUsing.UseBorderWidth = false;
            this.txtLetzteAusfuehrung.ParentStyleUsing.UseFont = false;
            this.txtLetzteAusfuehrung.ParentStyleUsing.UseForeColor = false;
            this.txtLetzteAusfuehrung.Size = new System.Drawing.Size(78, 20);
            xrSummary1.FormatString = "{0:dd/MM/yyyy}";
            this.txtLetzteAusfuehrung.Summary = xrSummary1;
            this.txtLetzteAusfuehrung.Text = "LetzteAusfuehrung";
            // 
            // txtText
            // 
            this.txtText.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text", "")});
            this.txtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtText.ForeColor = System.Drawing.Color.Black;
            this.txtText.Location = new System.Drawing.Point(157, 6);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtText.ParentStyleUsing.UseBackColor = false;
            this.txtText.ParentStyleUsing.UseBorderColor = false;
            this.txtText.ParentStyleUsing.UseBorders = false;
            this.txtText.ParentStyleUsing.UseBorderWidth = false;
            this.txtText.ParentStyleUsing.UseFont = false;
            this.txtText.ParentStyleUsing.UseForeColor = false;
            this.txtText.Size = new System.Drawing.Size(287, 20);
            this.txtText.Text = "Text";
            // 
            // txtGueltigBis
            // 
            this.txtGueltigBis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtGueltigBis.ForeColor = System.Drawing.Color.Black;
            this.txtGueltigBis.Location = new System.Drawing.Point(672, 6);
            this.txtGueltigBis.Multiline = true;
            this.txtGueltigBis.Name = "txtGueltigBis";
            this.txtGueltigBis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGueltigBis.ParentStyleUsing.UseBackColor = false;
            this.txtGueltigBis.ParentStyleUsing.UseBorderColor = false;
            this.txtGueltigBis.ParentStyleUsing.UseBorders = false;
            this.txtGueltigBis.ParentStyleUsing.UseBorderWidth = false;
            this.txtGueltigBis.ParentStyleUsing.UseFont = false;
            this.txtGueltigBis.ParentStyleUsing.UseForeColor = false;
            this.txtGueltigBis.Size = new System.Drawing.Size(78, 20);
            xrSummary2.FormatString = "{0:dd/MM/yyyy}";
            this.txtGueltigBis.Summary = xrSummary2;
            this.txtGueltigBis.Text = "GueltigBis";
            // 
            // txtGueltigVon
            // 
            this.txtGueltigVon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtGueltigVon.ForeColor = System.Drawing.Color.Black;
            this.txtGueltigVon.Location = new System.Drawing.Point(593, 6);
            this.txtGueltigVon.Multiline = true;
            this.txtGueltigVon.Name = "txtGueltigVon";
            this.txtGueltigVon.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGueltigVon.ParentStyleUsing.UseBackColor = false;
            this.txtGueltigVon.ParentStyleUsing.UseBorderColor = false;
            this.txtGueltigVon.ParentStyleUsing.UseBorders = false;
            this.txtGueltigVon.ParentStyleUsing.UseBorderWidth = false;
            this.txtGueltigVon.ParentStyleUsing.UseFont = false;
            this.txtGueltigVon.ParentStyleUsing.UseForeColor = false;
            this.txtGueltigVon.Size = new System.Drawing.Size(70, 20);
            xrSummary3.FormatString = "{0:dd/MM/yyyy}";
            this.txtGueltigVon.Summary = xrSummary3;
            this.txtGueltigVon.Text = "GueltigVon";
            // 
            // txtMonatstag2
            // 
            this.txtMonatstag2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Monatstag2", "")});
            this.txtMonatstag2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtMonatstag2.ForeColor = System.Drawing.Color.Black;
            this.txtMonatstag2.Location = new System.Drawing.Point(910, 6);
            this.txtMonatstag2.Multiline = true;
            this.txtMonatstag2.Name = "txtMonatstag2";
            this.txtMonatstag2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtMonatstag2.ParentStyleUsing.UseBackColor = false;
            this.txtMonatstag2.ParentStyleUsing.UseBorderColor = false;
            this.txtMonatstag2.ParentStyleUsing.UseBorders = false;
            this.txtMonatstag2.ParentStyleUsing.UseBorderWidth = false;
            this.txtMonatstag2.ParentStyleUsing.UseFont = false;
            this.txtMonatstag2.ParentStyleUsing.UseForeColor = false;
            this.txtMonatstag2.Size = new System.Drawing.Size(27, 20);
            this.txtMonatstag2.Text = "Monatstag2";
            // 
            // txtMonatstag1
            // 
            this.txtMonatstag1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Monatstag1", "")});
            this.txtMonatstag1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtMonatstag1.ForeColor = System.Drawing.Color.Black;
            this.txtMonatstag1.Location = new System.Drawing.Point(868, 6);
            this.txtMonatstag1.Multiline = true;
            this.txtMonatstag1.Name = "txtMonatstag1";
            this.txtMonatstag1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtMonatstag1.ParentStyleUsing.UseBackColor = false;
            this.txtMonatstag1.ParentStyleUsing.UseBorderColor = false;
            this.txtMonatstag1.ParentStyleUsing.UseBorders = false;
            this.txtMonatstag1.ParentStyleUsing.UseBorderWidth = false;
            this.txtMonatstag1.ParentStyleUsing.UseFont = false;
            this.txtMonatstag1.ParentStyleUsing.UseForeColor = false;
            this.txtMonatstag1.Size = new System.Drawing.Size(27, 20);
            this.txtMonatstag1.Text = "Monatstag1";
            // 
            // txtAuftragPeriodizitaet
            // 
            this.txtAuftragPeriodizitaet.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AuftragPeriodizitaet", "")});
            this.txtAuftragPeriodizitaet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtAuftragPeriodizitaet.ForeColor = System.Drawing.Color.Black;
            this.txtAuftragPeriodizitaet.Location = new System.Drawing.Point(758, 6);
            this.txtAuftragPeriodizitaet.Multiline = true;
            this.txtAuftragPeriodizitaet.Name = "txtAuftragPeriodizitaet";
            this.txtAuftragPeriodizitaet.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtAuftragPeriodizitaet.ParentStyleUsing.UseBackColor = false;
            this.txtAuftragPeriodizitaet.ParentStyleUsing.UseBorderColor = false;
            this.txtAuftragPeriodizitaet.ParentStyleUsing.UseBorders = false;
            this.txtAuftragPeriodizitaet.ParentStyleUsing.UseBorderWidth = false;
            this.txtAuftragPeriodizitaet.ParentStyleUsing.UseFont = false;
            this.txtAuftragPeriodizitaet.ParentStyleUsing.UseForeColor = false;
            this.txtAuftragPeriodizitaet.Size = new System.Drawing.Size(100, 20);
            this.txtAuftragPeriodizitaet.Text = "AuftragPeriodizitaet";
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(468, 6);
            this.txtBetrag.Multiline = true;
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(100, 20);
            xrSummary4.FormatString = "{0:#,##0.00}";
            this.txtBetrag.Summary = xrSummary4;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtMandant
            // 
            this.txtMandant.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Mandant", "")});
            this.txtMandant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtMandant.ForeColor = System.Drawing.Color.Black;
            this.txtMandant.Location = new System.Drawing.Point(0, 6);
            this.txtMandant.Multiline = true;
            this.txtMandant.Name = "txtMandant";
            this.txtMandant.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtMandant.ParentStyleUsing.UseBackColor = false;
            this.txtMandant.ParentStyleUsing.UseBorderColor = false;
            this.txtMandant.ParentStyleUsing.UseBorders = false;
            this.txtMandant.ParentStyleUsing.UseBorderWidth = false;
            this.txtMandant.ParentStyleUsing.UseFont = false;
            this.txtMandant.ParentStyleUsing.UseForeColor = false;
            this.txtMandant.Size = new System.Drawing.Size(153, 20);
            this.txtMandant.Text = "Mandant";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel2.Location = new System.Drawing.Point(0, 0);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(347, 107);
            this.xrLabel2.Text = "Stadt Bern\r\nDirektion für Sicherheit\r\nUmwelt und Energie\r\n\r\n\r\nAmt für Erwachsenen" +
                "- und \r\nKindesschutz";
            // 
            // Label16
            // 
            this.Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label16.ForeColor = System.Drawing.Color.Black;
            this.Label16.Location = new System.Drawing.Point(964, 187);
            this.Label16.Name = "Label16";
            this.Label16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label16.ParentStyleUsing.UseBackColor = false;
            this.Label16.ParentStyleUsing.UseBorderColor = false;
            this.Label16.ParentStyleUsing.UseBorders = false;
            this.Label16.ParentStyleUsing.UseBorderWidth = false;
            this.Label16.ParentStyleUsing.UseFont = false;
            this.Label16.ParentStyleUsing.UseForeColor = false;
            this.Label16.Size = new System.Drawing.Size(70, 15);
            this.Label16.Text = "letzte Ausf.";
            // 
            // Label15
            // 
            this.Label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label15.ForeColor = System.Drawing.Color.Black;
            this.Label15.Location = new System.Drawing.Point(910, 187);
            this.Label15.Name = "Label15";
            this.Label15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label15.ParentStyleUsing.UseBackColor = false;
            this.Label15.ParentStyleUsing.UseBorderColor = false;
            this.Label15.ParentStyleUsing.UseBorders = false;
            this.Label15.ParentStyleUsing.UseBorderWidth = false;
            this.Label15.ParentStyleUsing.UseFont = false;
            this.Label15.ParentStyleUsing.UseForeColor = false;
            this.Label15.Size = new System.Drawing.Size(39, 15);
            this.Label15.Text = "Tag2";
            // 
            // Label14
            // 
            this.Label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label14.ForeColor = System.Drawing.Color.Black;
            this.Label14.Location = new System.Drawing.Point(868, 187);
            this.Label14.Name = "Label14";
            this.Label14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label14.ParentStyleUsing.UseBackColor = false;
            this.Label14.ParentStyleUsing.UseBorderColor = false;
            this.Label14.ParentStyleUsing.UseBorders = false;
            this.Label14.ParentStyleUsing.UseBorderWidth = false;
            this.Label14.ParentStyleUsing.UseFont = false;
            this.Label14.ParentStyleUsing.UseForeColor = false;
            this.Label14.Size = new System.Drawing.Size(39, 15);
            this.Label14.Text = "Tag1";
            // 
            // Label13
            // 
            this.Label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label13.ForeColor = System.Drawing.Color.Black;
            this.Label13.Location = new System.Drawing.Point(758, 187);
            this.Label13.Name = "Label13";
            this.Label13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label13.ParentStyleUsing.UseBackColor = false;
            this.Label13.ParentStyleUsing.UseBorderColor = false;
            this.Label13.ParentStyleUsing.UseBorders = false;
            this.Label13.ParentStyleUsing.UseBorderWidth = false;
            this.Label13.ParentStyleUsing.UseFont = false;
            this.Label13.ParentStyleUsing.UseForeColor = false;
            this.Label13.Size = new System.Drawing.Size(70, 15);
            this.Label13.Text = "Periodizität";
            // 
            // Label12
            // 
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(672, 187);
            this.Label12.Name = "Label12";
            this.Label12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label12.ParentStyleUsing.UseBackColor = false;
            this.Label12.ParentStyleUsing.UseBorderColor = false;
            this.Label12.ParentStyleUsing.UseBorders = false;
            this.Label12.ParentStyleUsing.UseBorderWidth = false;
            this.Label12.ParentStyleUsing.UseFont = false;
            this.Label12.ParentStyleUsing.UseForeColor = false;
            this.Label12.Size = new System.Drawing.Size(70, 15);
            this.Label12.Text = "bis";
            // 
            // Label11
            // 
            this.Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(593, 187);
            this.Label11.Name = "Label11";
            this.Label11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label11.ParentStyleUsing.UseBackColor = false;
            this.Label11.ParentStyleUsing.UseBorderColor = false;
            this.Label11.ParentStyleUsing.UseBorders = false;
            this.Label11.ParentStyleUsing.UseBorderWidth = false;
            this.Label11.ParentStyleUsing.UseFont = false;
            this.Label11.ParentStyleUsing.UseForeColor = false;
            this.Label11.Size = new System.Drawing.Size(70, 15);
            this.Label11.Text = "Gültig von";
            // 
            // Label10
            // 
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label10.ForeColor = System.Drawing.Color.Black;
            this.Label10.Location = new System.Drawing.Point(497, 187);
            this.Label10.Name = "Label10";
            this.Label10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label10.ParentStyleUsing.UseBackColor = false;
            this.Label10.ParentStyleUsing.UseBorderColor = false;
            this.Label10.ParentStyleUsing.UseBorders = false;
            this.Label10.ParentStyleUsing.UseBorderWidth = false;
            this.Label10.ParentStyleUsing.UseFont = false;
            this.Label10.ParentStyleUsing.UseForeColor = false;
            this.Label10.Size = new System.Drawing.Size(70, 15);
            this.Label10.Text = "Betrag";
            this.Label10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label9
            // 
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(157, 187);
            this.Label9.Name = "Label9";
            this.Label9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label9.ParentStyleUsing.UseBackColor = false;
            this.Label9.ParentStyleUsing.UseBorderColor = false;
            this.Label9.ParentStyleUsing.UseBorders = false;
            this.Label9.ParentStyleUsing.UseBorderWidth = false;
            this.Label9.ParentStyleUsing.UseFont = false;
            this.Label9.ParentStyleUsing.UseForeColor = false;
            this.Label9.Size = new System.Drawing.Size(70, 15);
            this.Label9.Text = "Text";
            // 
            // Label8
            // 
            this.Label8.Font = new System.Drawing.Font("Arial", 14F);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(0, 140);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(157, 27);
            this.Label8.Text = "Daueraufträge";
            // 
            // Geburtsdatum1
            // 
            this.Geburtsdatum1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Team", "{0:dd.MM.yyyy}")});
            this.Geburtsdatum1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Geburtsdatum1.ForeColor = System.Drawing.Color.Black;
            this.Geburtsdatum1.Location = new System.Drawing.Point(237, 140);
            this.Geburtsdatum1.Multiline = true;
            this.Geburtsdatum1.Name = "Geburtsdatum1";
            this.Geburtsdatum1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Geburtsdatum1.ParentStyleUsing.UseBackColor = false;
            this.Geburtsdatum1.ParentStyleUsing.UseBorderColor = false;
            this.Geburtsdatum1.ParentStyleUsing.UseBorders = false;
            this.Geburtsdatum1.ParentStyleUsing.UseBorderWidth = false;
            this.Geburtsdatum1.ParentStyleUsing.UseFont = false;
            this.Geburtsdatum1.ParentStyleUsing.UseForeColor = false;
            this.Geburtsdatum1.Size = new System.Drawing.Size(163, 20);
            xrSummary5.FormatString = "{0:dd/MM/yyyy}";
            this.Geburtsdatum1.Summary = xrSummary5;
            this.Geburtsdatum1.Text = "Team";
            // 
            // TextBox13
            // 
            this.TextBox13.Font = new System.Drawing.Font("Arial", 9F);
            this.TextBox13.ForeColor = System.Drawing.Color.Black;
            this.TextBox13.Location = new System.Drawing.Point(185, 140);
            this.TextBox13.Multiline = true;
            this.TextBox13.Name = "TextBox13";
            this.TextBox13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox13.ParentStyleUsing.UseBackColor = false;
            this.TextBox13.ParentStyleUsing.UseBorderColor = false;
            this.TextBox13.ParentStyleUsing.UseBorders = false;
            this.TextBox13.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox13.ParentStyleUsing.UseFont = false;
            this.TextBox13.ParentStyleUsing.UseForeColor = false;
            this.TextBox13.Size = new System.Drawing.Size(51, 18);
            this.TextBox13.Text = "Team";
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial", 10F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(956, 107);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(86, 25);
            this.Label4.Text = "Buchhaltung";
            this.Label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line3
            // 
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.Location = new System.Drawing.Point(0, 207);
            this.Line3.Name = "Line3";
            this.Line3.ParentStyleUsing.UseBackColor = false;
            this.Line3.ParentStyleUsing.UseBorderColor = false;
            this.Line3.ParentStyleUsing.UseBorders = false;
            this.Line3.ParentStyleUsing.UseBorderWidth = false;
            this.Line3.ParentStyleUsing.UseFont = false;
            this.Line3.ParentStyleUsing.UseForeColor = false;
            this.Line3.Size = new System.Drawing.Size(1043, 2);
            // 
            // lblKtoNr
            // 
            this.lblKtoNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblKtoNr.ForeColor = System.Drawing.Color.Black;
            this.lblKtoNr.Location = new System.Drawing.Point(0, 187);
            this.lblKtoNr.Name = "lblKtoNr";
            this.lblKtoNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblKtoNr.ParentStyleUsing.UseBackColor = false;
            this.lblKtoNr.ParentStyleUsing.UseBorderColor = false;
            this.lblKtoNr.ParentStyleUsing.UseBorders = false;
            this.lblKtoNr.ParentStyleUsing.UseBorderWidth = false;
            this.lblKtoNr.ParentStyleUsing.UseFont = false;
            this.lblKtoNr.ParentStyleUsing.UseForeColor = false;
            this.lblKtoNr.Size = new System.Drawing.Size(70, 15);
            this.lblKtoNr.Text = "Mandant";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel1.Location = new System.Drawing.Point(0, 12);
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
            this.xrPageInfo2.Location = new System.Drawing.Point(73, 12);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            this.xrPageInfo2.Size = new System.Drawing.Size(100, 27);
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 9F);
            this.xrPageInfo1.Location = new System.Drawing.Point(533, 12);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(100, 26);
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 9F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(984, 15);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(59, 19);
            this.Label6.Text = "KISS 3";
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
            this.Line2.Size = new System.Drawing.Size(1043, 2);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 9F);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(493, 12);
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
            this.sqlQuery1.SelectStatement = "select DAU.*,\r\n       Team = TEA.Name\r\nfrom   viewDauerauftrag DAU\r\n       left  " +
                "join FbTeam        TEA on TEA.FbTeamID = DAU.FbTeamID\r\nwhere  DAU.FbTeamID = nul" +
                "l\r\norder by Mandant";
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail,
                        this.PageHeader,
                        this.PageFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(60, 60, 60, 39);
            this.Name = "Report";
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4Rotated;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' , ParameterXML =  N'<NewDataSet>
	<Table>
		<FieldName>label</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Team-Nr:</DisplayText>
		<TabPosition>0</TabPosition>
		<X>10</X>
		<Y>40</Y>
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
		<FieldName>FbTeamID</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>FbTeamID</DisplayText>
		<TabPosition>1</TabPosition>
		<X>100</X>
		<Y>40</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>true</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
</NewDataSet>' , SQLquery =  N'select DAU.*,
       Team = TEA.Name
from   viewDauerauftrag DAU
       left  join FbTeam        TEA on TEA.FbTeamID = DAU.FbTeamID
where  DAU.FbTeamID = {FbTeamID}
order by Mandant' , ContextForms =  N'VmFibu' , ParentReportName =  null , ReportSortKey =  null 
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'VmFibuDauerauftraege' ;


