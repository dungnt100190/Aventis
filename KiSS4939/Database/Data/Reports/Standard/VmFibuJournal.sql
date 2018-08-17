-- Insert Script for VmFibuJournal
-- MD5:0X7093E6CC11B97EFE7A77525722B131F0_0X2B5A617E9A1122D95A7E3F5AF623283A_0XF74C2136DBE7BA3D9654D97003BCAA65
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'VmFibuJournal') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('VmFibuJournal', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'VmFibuJournal';
UPDATE QRY
SET QueryName =  N'VmFibuJournal' , UserText =  N'VM - Fibu Journal' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtText;
        private DevExpress.XtraReports.UI.XRLabel txtHabenKtoNr;
        private DevExpress.XtraReports.UI.XRLabel txtSollKtoNr;
        private DevExpress.XtraReports.UI.XRLabel txtBelegNr;
        private DevExpress.XtraReports.UI.XRLabel txtBuchungsDatum;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel txtGeburtsdatum;
        private DevExpress.XtraReports.UI.XRLabel TextBox12;
        private DevExpress.XtraReports.UI.XRLabel txtDatumBereich;
        private DevExpress.XtraReports.UI.XRLabel TextBox10;
        private DevExpress.XtraReports.UI.XRLabel txtMandant;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel TextBox7;
        private DevExpress.XtraReports.UI.XRLabel TextBox6;
        private DevExpress.XtraReports.UI.XRLabel TextBox5;
        private DevExpress.XtraReports.UI.XRLabel TextBox8;
        private DevExpress.XtraReports.UI.XRLabel TextBox3;
        private DevExpress.XtraReports.UI.XRLabel TextBox2;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
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
                    string resourceString = @"zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OSNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kAAAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAAAAAAfEDc2VsZWN0IEJVQy4qLA0KICAgICAgIE1hbmRhbnQgPSBQUlMuTmFtZSArIGlzTnVsbCgnLCAnICsgUFJTLlZvcm5hbWUsJycpICwNCiAgICAgICBQUlMuR2VidXJ0c2RhdHVtLA0KICAgICAgIGNvbnZlcnQodmFyY2hhcixjb252ZXJ0KGRhdGV0aW1lLG51bGwpLDEwNCkgKyAnIC0gJyArDQogICAgICAgY29udmVydCh2YXJjaGFyLGNvbnZlcnQoZGF0ZXRpbWUsbnVsbCksMTA0KSBEYXR1bUJlcmVpY2gNCmZyb20gICBGQkJ1Y2h1bmcgQlVDDQogICAgICAgaW5uZXIgam9pbiBGYlBlcmlvZGUgUEVSIG9uIFBFUi5GYlBlcmlvZGVJRCA9IEJVQy5GYlBlcmlvZGVJRA0KICAgICAgIGlubmVyIGpvaW4gQmFQZXJzb24gUFJTIG9uIFBSUy5CYVBlcnNvbklEID0gUEVSLkJhUGVyc29uSUQNCndoZXJlICBCVUMuRmJQZXJpb2RlSUQgPSBudWxsIGFuZA0KICAgICAgIEJ1Y2h1bmdzRGF0dW0gYmV0d2VlbiBudWxsIGFuZCBudWxsDQpvcmRlciBieSBCdWNodW5nc0RhdHVtLEJlbGVnTnI=";
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
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtText = new DevExpress.XtraReports.UI.XRLabel();
            this.txtHabenKtoNr = new DevExpress.XtraReports.UI.XRLabel();
            this.txtSollKtoNr = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBelegNr = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBuchungsDatum = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGeburtsdatum = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox12 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtDatumBereich = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox10 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtMandant = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.TextBox7 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox6 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox5 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox8 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox3 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
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
                        this.txtBetrag,
                        this.txtText,
                        this.txtHabenKtoNr,
                        this.txtSollKtoNr,
                        this.txtBelegNr,
                        this.txtBuchungsDatum});
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
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel2,
                        this.txtGeburtsdatum,
                        this.TextBox12,
                        this.txtDatumBereich,
                        this.TextBox10,
                        this.txtMandant,
                        this.Line1,
                        this.TextBox7,
                        this.TextBox6,
                        this.TextBox5,
                        this.TextBox8,
                        this.TextBox3,
                        this.TextBox2,
                        this.Label4});
            this.PageHeader.Height = 255;
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
                        this.xrPageInfo2,
                        this.xrLabel1,
                        this.xrPageInfo1,
                        this.Label6,
                        this.Line2,
                        this.Label1});
            this.PageFooter.Height = 35;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 9F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(606, 0);
            this.txtBetrag.Multiline = true;
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(86, 20);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtBetrag.Summary = xrSummary1;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtText
            // 
            this.txtText.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text", "")});
            this.txtText.Font = new System.Drawing.Font("Arial", 9F);
            this.txtText.ForeColor = System.Drawing.Color.Black;
            this.txtText.Location = new System.Drawing.Point(314, 0);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtText.ParentStyleUsing.UseBackColor = false;
            this.txtText.ParentStyleUsing.UseBorderColor = false;
            this.txtText.ParentStyleUsing.UseBorders = false;
            this.txtText.ParentStyleUsing.UseBorderWidth = false;
            this.txtText.ParentStyleUsing.UseFont = false;
            this.txtText.ParentStyleUsing.UseForeColor = false;
            this.txtText.Size = new System.Drawing.Size(291, 20);
            this.txtText.Text = "Text";
            // 
            // txtHabenKtoNr
            // 
            this.txtHabenKtoNr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "HabenKtoNr", "")});
            this.txtHabenKtoNr.Font = new System.Drawing.Font("Arial", 9F);
            this.txtHabenKtoNr.ForeColor = System.Drawing.Color.Black;
            this.txtHabenKtoNr.Location = new System.Drawing.Point(231, 0);
            this.txtHabenKtoNr.Multiline = true;
            this.txtHabenKtoNr.Name = "txtHabenKtoNr";
            this.txtHabenKtoNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtHabenKtoNr.ParentStyleUsing.UseBackColor = false;
            this.txtHabenKtoNr.ParentStyleUsing.UseBorderColor = false;
            this.txtHabenKtoNr.ParentStyleUsing.UseBorders = false;
            this.txtHabenKtoNr.ParentStyleUsing.UseBorderWidth = false;
            this.txtHabenKtoNr.ParentStyleUsing.UseFont = false;
            this.txtHabenKtoNr.ParentStyleUsing.UseForeColor = false;
            this.txtHabenKtoNr.Size = new System.Drawing.Size(56, 20);
            this.txtHabenKtoNr.Text = "HabenKtoNr";
            this.txtHabenKtoNr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtSollKtoNr
            // 
            this.txtSollKtoNr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SollKtoNr", "")});
            this.txtSollKtoNr.Font = new System.Drawing.Font("Arial", 9F);
            this.txtSollKtoNr.ForeColor = System.Drawing.Color.Black;
            this.txtSollKtoNr.Location = new System.Drawing.Point(135, 0);
            this.txtSollKtoNr.Multiline = true;
            this.txtSollKtoNr.Name = "txtSollKtoNr";
            this.txtSollKtoNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtSollKtoNr.ParentStyleUsing.UseBackColor = false;
            this.txtSollKtoNr.ParentStyleUsing.UseBorderColor = false;
            this.txtSollKtoNr.ParentStyleUsing.UseBorders = false;
            this.txtSollKtoNr.ParentStyleUsing.UseBorderWidth = false;
            this.txtSollKtoNr.ParentStyleUsing.UseFont = false;
            this.txtSollKtoNr.ParentStyleUsing.UseForeColor = false;
            this.txtSollKtoNr.Size = new System.Drawing.Size(78, 20);
            this.txtSollKtoNr.Text = "SollKtoNr";
            this.txtSollKtoNr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtBelegNr
            // 
            this.txtBelegNr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BelegNr", "")});
            this.txtBelegNr.Font = new System.Drawing.Font("Arial", 9F);
            this.txtBelegNr.ForeColor = System.Drawing.Color.Black;
            this.txtBelegNr.Location = new System.Drawing.Point(86, 0);
            this.txtBelegNr.Multiline = true;
            this.txtBelegNr.Name = "txtBelegNr";
            this.txtBelegNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBelegNr.ParentStyleUsing.UseBackColor = false;
            this.txtBelegNr.ParentStyleUsing.UseBorderColor = false;
            this.txtBelegNr.ParentStyleUsing.UseBorders = false;
            this.txtBelegNr.ParentStyleUsing.UseBorderWidth = false;
            this.txtBelegNr.ParentStyleUsing.UseFont = false;
            this.txtBelegNr.ParentStyleUsing.UseForeColor = false;
            this.txtBelegNr.Size = new System.Drawing.Size(78, 20);
            this.txtBelegNr.Text = "BelegNr";
            // 
            // txtBuchungsDatum
            // 
            this.txtBuchungsDatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BuchungsDatum", "{0:dd.MM.yyyy}")});
            this.txtBuchungsDatum.Font = new System.Drawing.Font("Arial", 9F);
            this.txtBuchungsDatum.ForeColor = System.Drawing.Color.Black;
            this.txtBuchungsDatum.Location = new System.Drawing.Point(0, 0);
            this.txtBuchungsDatum.Multiline = true;
            this.txtBuchungsDatum.Name = "txtBuchungsDatum";
            this.txtBuchungsDatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBuchungsDatum.ParentStyleUsing.UseBackColor = false;
            this.txtBuchungsDatum.ParentStyleUsing.UseBorderColor = false;
            this.txtBuchungsDatum.ParentStyleUsing.UseBorders = false;
            this.txtBuchungsDatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtBuchungsDatum.ParentStyleUsing.UseFont = false;
            this.txtBuchungsDatum.ParentStyleUsing.UseForeColor = false;
            this.txtBuchungsDatum.Size = new System.Drawing.Size(78, 20);
            xrSummary2.FormatString = "{0:dd/MM/yyyy}";
            this.txtBuchungsDatum.Summary = xrSummary2;
            this.txtBuchungsDatum.Text = "BuchungsDatum";
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
            // txtGeburtsdatum
            // 
            this.txtGeburtsdatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Geburtsdatum", "{0:dd.MM.yyyy}")});
            this.txtGeburtsdatum.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.txtGeburtsdatum.ForeColor = System.Drawing.Color.Black;
            this.txtGeburtsdatum.Location = new System.Drawing.Point(305, 167);
            this.txtGeburtsdatum.Multiline = true;
            this.txtGeburtsdatum.Name = "txtGeburtsdatum";
            this.txtGeburtsdatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGeburtsdatum.ParentStyleUsing.UseBackColor = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorderColor = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorders = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseFont = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseForeColor = false;
            this.txtGeburtsdatum.Size = new System.Drawing.Size(100, 20);
            xrSummary3.FormatString = "{0:dd/MM/yyyy}";
            this.txtGeburtsdatum.Summary = xrSummary3;
            this.txtGeburtsdatum.Text = "Geburtsdatum";
            // 
            // TextBox12
            // 
            this.TextBox12.Font = new System.Drawing.Font("Arial", 9F);
            this.TextBox12.ForeColor = System.Drawing.Color.Black;
            this.TextBox12.Location = new System.Drawing.Point(228, 167);
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
            this.txtDatumBereich.Location = new System.Drawing.Point(50, 167);
            this.txtDatumBereich.Multiline = true;
            this.txtDatumBereich.Name = "txtDatumBereich";
            this.txtDatumBereich.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtDatumBereich.ParentStyleUsing.UseBackColor = false;
            this.txtDatumBereich.ParentStyleUsing.UseBorderColor = false;
            this.txtDatumBereich.ParentStyleUsing.UseBorders = false;
            this.txtDatumBereich.ParentStyleUsing.UseBorderWidth = false;
            this.txtDatumBereich.ParentStyleUsing.UseFont = false;
            this.txtDatumBereich.ParentStyleUsing.UseForeColor = false;
            this.txtDatumBereich.Size = new System.Drawing.Size(149, 20);
            this.txtDatumBereich.Text = "DatumBereich";
            // 
            // TextBox10
            // 
            this.TextBox10.Font = new System.Drawing.Font("Arial", 9F);
            this.TextBox10.ForeColor = System.Drawing.Color.Black;
            this.TextBox10.Location = new System.Drawing.Point(0, 167);
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
            this.TextBox10.Text = "Datum";
            // 
            // txtMandant
            // 
            this.txtMandant.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Mandant", "")});
            this.txtMandant.Font = new System.Drawing.Font("Arial", 14.25F);
            this.txtMandant.ForeColor = System.Drawing.Color.Black;
            this.txtMandant.Location = new System.Drawing.Point(0, 133);
            this.txtMandant.Multiline = true;
            this.txtMandant.Name = "txtMandant";
            this.txtMandant.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtMandant.ParentStyleUsing.UseBackColor = false;
            this.txtMandant.ParentStyleUsing.UseBorderColor = false;
            this.txtMandant.ParentStyleUsing.UseBorders = false;
            this.txtMandant.ParentStyleUsing.UseBorderWidth = false;
            this.txtMandant.ParentStyleUsing.UseFont = false;
            this.txtMandant.ParentStyleUsing.UseForeColor = false;
            this.txtMandant.Size = new System.Drawing.Size(692, 23);
            this.txtMandant.Text = "Mandant";
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.Location = new System.Drawing.Point(0, 233);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(692, 2);
            // 
            // TextBox7
            // 
            this.TextBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox7.ForeColor = System.Drawing.Color.Black;
            this.TextBox7.Location = new System.Drawing.Point(590, 213);
            this.TextBox7.Multiline = true;
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox7.ParentStyleUsing.UseBackColor = false;
            this.TextBox7.ParentStyleUsing.UseBorderColor = false;
            this.TextBox7.ParentStyleUsing.UseBorders = false;
            this.TextBox7.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox7.ParentStyleUsing.UseFont = false;
            this.TextBox7.ParentStyleUsing.UseForeColor = false;
            this.TextBox7.Size = new System.Drawing.Size(102, 20);
            this.TextBox7.Text = "Betrag";
            this.TextBox7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox6
            // 
            this.TextBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox6.ForeColor = System.Drawing.Color.Black;
            this.TextBox6.Location = new System.Drawing.Point(231, 213);
            this.TextBox6.Multiline = true;
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox6.ParentStyleUsing.UseBackColor = false;
            this.TextBox6.ParentStyleUsing.UseBorderColor = false;
            this.TextBox6.ParentStyleUsing.UseBorders = false;
            this.TextBox6.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox6.ParentStyleUsing.UseFont = false;
            this.TextBox6.ParentStyleUsing.UseForeColor = false;
            this.TextBox6.Size = new System.Drawing.Size(56, 20);
            this.TextBox6.Text = "Haben";
            this.TextBox6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox5
            // 
            this.TextBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox5.ForeColor = System.Drawing.Color.Black;
            this.TextBox5.Location = new System.Drawing.Point(135, 213);
            this.TextBox5.Multiline = true;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox5.ParentStyleUsing.UseBackColor = false;
            this.TextBox5.ParentStyleUsing.UseBorderColor = false;
            this.TextBox5.ParentStyleUsing.UseBorders = false;
            this.TextBox5.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox5.ParentStyleUsing.UseFont = false;
            this.TextBox5.ParentStyleUsing.UseForeColor = false;
            this.TextBox5.Size = new System.Drawing.Size(78, 20);
            this.TextBox5.Text = "Soll";
            this.TextBox5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox8
            // 
            this.TextBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox8.ForeColor = System.Drawing.Color.Black;
            this.TextBox8.Location = new System.Drawing.Point(314, 213);
            this.TextBox8.Multiline = true;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox8.ParentStyleUsing.UseBackColor = false;
            this.TextBox8.ParentStyleUsing.UseBorderColor = false;
            this.TextBox8.ParentStyleUsing.UseBorders = false;
            this.TextBox8.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox8.ParentStyleUsing.UseFont = false;
            this.TextBox8.ParentStyleUsing.UseForeColor = false;
            this.TextBox8.Size = new System.Drawing.Size(275, 20);
            this.TextBox8.Text = "Text";
            // 
            // TextBox3
            // 
            this.TextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox3.ForeColor = System.Drawing.Color.Black;
            this.TextBox3.Location = new System.Drawing.Point(86, 213);
            this.TextBox3.Multiline = true;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox3.ParentStyleUsing.UseBackColor = false;
            this.TextBox3.ParentStyleUsing.UseBorderColor = false;
            this.TextBox3.ParentStyleUsing.UseBorders = false;
            this.TextBox3.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox3.ParentStyleUsing.UseFont = false;
            this.TextBox3.ParentStyleUsing.UseForeColor = false;
            this.TextBox3.Size = new System.Drawing.Size(78, 20);
            this.TextBox3.Text = "Beleg";
            // 
            // TextBox2
            // 
            this.TextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox2.ForeColor = System.Drawing.Color.Black;
            this.TextBox2.Location = new System.Drawing.Point(0, 213);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox2.ParentStyleUsing.UseBackColor = false;
            this.TextBox2.ParentStyleUsing.UseBorderColor = false;
            this.TextBox2.ParentStyleUsing.UseBorders = false;
            this.TextBox2.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox2.ParentStyleUsing.UseFont = false;
            this.TextBox2.ParentStyleUsing.UseForeColor = false;
            this.TextBox2.Size = new System.Drawing.Size(78, 20);
            this.TextBox2.Text = "Datum";
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial", 10F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(417, 100);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(275, 23);
            this.Label4.Text = "Buchhaltung - Journal";
            this.Label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 9F);
            this.xrPageInfo2.Format = "{0:dd.MM.yyyy}";
            this.xrPageInfo2.Location = new System.Drawing.Point(80, 12);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            this.xrPageInfo2.Size = new System.Drawing.Size(100, 20);
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel1.Location = new System.Drawing.Point(0, 12);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(100, 20);
            this.xrLabel1.Text = "Druckdatum";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 9F);
            this.xrPageInfo1.Location = new System.Drawing.Point(327, 12);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(100, 17);
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 9F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(645, 12);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(47, 23);
            this.Label6.Text = "KISS 4";
            this.Label6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.Location = new System.Drawing.Point(0, 7);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(692, 2);
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 9F);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(287, 12);
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
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
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
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
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
		<FieldName>labelDatumVon</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Datum von:</DisplayText>
		<TabPosition>0</TabPosition>
		<X>10</X>
		<Y>70</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName>LOV Name</LOVName>
		<DefaultValue>DefaultValue1</DefaultValue>
		<Mandatory>false</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>
		<FieldName>DatumVon</FieldName>
		<FieldCode>5</FieldCode>
		<DisplayText>Datum von</DisplayText>
		<TabPosition>4</TabPosition>
		<X>120</X>
		<Y>70</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>10</Length>
		<LOVName>LOV Name</LOVName>
		<DefaultValue>1</DefaultValue>
		<Mandatory>true</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>
		<FieldName>labelDatumBis</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Datum bis:</DisplayText>
		<TabPosition>0</TabPosition>
		<X>10</X>
		<Y>100</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName>LOV Name</LOVName>
		<DefaultValue>DefaultValue1</DefaultValue>
		<Mandatory>false</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>
		<FieldName>DatumBis</FieldName>
		<FieldCode>5</FieldCode>
		<DisplayText>Datum bis</DisplayText>
		<TabPosition>5</TabPosition>
		<X>120</X>
		<Y>100</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>10</Length>
		<LOVName>LOV Name</LOVName>
		<DefaultValue>1</DefaultValue>
		<Mandatory>true</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
</NewDataSet>' , SQLquery =  N'select BUC.*,
       Mandant = PRS.Name + isNull('', '' + PRS.Vorname,'''') ,
       PRS.Geburtsdatum,
       convert(varchar,convert(datetime,{DatumVon}),104) + '' - '' +
       convert(varchar,convert(datetime,{DatumBis}),104) DatumBereich
from   FBBuchung BUC
       inner join FbPeriode PER on PER.FbPeriodeID = BUC.FbPeriodeID
       inner join BaPerson PRS on PRS.BaPersonID = PER.BaPersonID
where  BUC.FbPeriodeID = {FbPeriodeID} and
       BuchungsDatum between {DatumVon} and {DatumBis}
order by BuchungsDatum,BelegNr' , ContextForms =  N'VmFibu,CtlFibuJournal,CtlFibuKontoblatt,CtlFibuKontoblatt2,CtlFibuBilanzErfolg' , ParentReportName =  null , ReportSortKey =  null 
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'VmFibuJournal' ;


