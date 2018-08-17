﻿-- Insert Script for ShUebersichtMonatsbudget
-- MD5:0X6E58306875436F5A083E8D1E932B1C32_0X0ADF4580439533DD6350CC8EA9813309_0XD2499A3F45999E3C28BEFCB1FFF5989B
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'ShUebersichtMonatsbudget') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('ShUebersichtMonatsbudget', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'ShUebersichtMonatsbudget';
UPDATE QRY
SET QueryName =  N'ShUebersichtMonatsbudget' , UserText =  N'SH - Übersicht Monatsbudget' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\KiSS\R4233\KiSS4.DB.dll" />
///     <Reference Path="C:\KiSS\R4233\log4net.dll" />
///     <Reference Path="C:\KiSS\R4233\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.Subreport ShUebersichtMonatsbudget_Zahlungen;
        private DevExpress.XtraReports.UI.Subreport ShUebersichtMonatsbudget_Unterst;
        private DevExpress.XtraReports.UI.Subreport ShUebersichtMonatsbudget_Uebersicht;
        private DevExpress.XtraReports.UI.Subreport ShUebersichtMonatsbudget_Budget;
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
        private DevExpress.XtraReports.UI.XRLabel lblSig;
        private DevExpress.XtraReports.UI.XRLabel lblSigLoc;
        private DevExpress.XtraReports.UI.XRLabel lblConf;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
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
                        "AAAAZkMLS0tLSBzcHNvdGE6IDIwMTAwMzE4DQoNClNFTEVDVA0KICBPcmdfTmFtZSAgICA9IElzTnVsb" +
                        "ChDT05WRVJUKHZhcmNoYXIoMTAwMCksIGRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlXFNvemlhb" +
                        "GhpbGZlXE9yZ2FuaXNhdGlvbicsIEdldERhdGUoKSkpLCAnJyksDQogIE9yZ19BZHJlc3NlID0gSXNOd" +
                        "WxsKENPTlZFUlQodmFyY2hhcigxMDAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc2VcU296a" +
                        "WFsaGlsZmVcQWRyZXNzZScsIEdldERhdGUoKSkpLCAnJyksDQogIE9yZ19QTFogICAgID0gSXNOdWxsK" +
                        "ENPTlZFUlQodmFyY2hhcigxMDAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc2VcU296aWFsa" +
                        "GlsZmVcUExaJywgR2V0RGF0ZSgpKSksICcnKSwNCiAgT3JnX09ydCAgICAgPSBJc051bGwoQ09OVkVSV" +
                        "Ch2YXJjaGFyKDEwMDApLCBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxPc" +
                        "nQnLCBHZXREYXRlKCkpKSwgJycpLA0KICBPcmdfUExaT3J0ICA9IElzTnVsbChDT05WRVJUKHZhcmNoY" +
                        "XIoMTAwMCksIGRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlXFBMWicsIEdld" +
                        "ERhdGUoKSkpICsgJyAnLCAnJykNCiAgICAgICAgICAgICAgKyBJc051bGwoQ09OVkVSVCh2YXJjaGFyK" +
                        "DEwMDApLCBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxPcnQnLCBHZXREY" +
                        "XRlKCkpKSwgJycpLA0KICBCQkcuQmdCdWRnZXRJRCwNCg0KICBEYXR1bSAgICAgID0gZGJvLmZuRGF0Z" +
                        "VNlcmlhbChCQkcuSmFociwgQkJHLk1vbmF0LCAxKSwNCiAgU3RhdHVzICAgICA9IElzTnVsbCgnTW9uY" +
                        "XRzYnVkZ2V0ICcgKyBCQkdfTE9WLlRleHQsICc/JyksDQoNCiAgTmFtZSAgICAgICA9IFBSUy5Wb3JuY" +
                        "W1lTmFtZSwNCiAgU3RyYXNzZSAgICA9IFBSUy5Xb2huc2l0elN0cmFzc2VIYXVzTnIsDQogIE9ydCAgI" +
                        "CAgICAgPSBQUlMuV29obnNpdHpQTFpPcnQsDQogIFp1c3QgICAgICAgPSBJc051bGwoVVNSLkZpcnN0T" +
                        "mFtZSsnICcsICcnKSArIElzTnVsbChVU1IuTGFzdE5hbWUsICcnKQ0KRlJPTSBCZ0J1ZGdldCAgICAgI" +
                        "CAgICAgICAgQkJHDQogIElOTkVSIEpPSU4gQmdGaW5hbnpwbGFuICBTRlAgb24gU0ZQLkJnRmluYW56c" +
                        "GxhbklEID0gQkJHLkJnRmluYW56cGxhbklEDQogIElOTkVSIEpPSU4gRmFMZWlzdHVuZyAgICBGQUwgb" +
                        "24gRkFMLkZhTGVpc3R1bmdJRCA9IFNGUC5GYUxlaXN0dW5nSUQNCiAgSU5ORVIgSk9JTiB2d1BlcnNvb" +
                        "iAgICAgIFBSUyBvbiBQUlMuQmFQZXJzb25JRCA9IEZBTC5CYVBlcnNvbklEDQogIElOTkVSIEpPSU4gW" +
                        "FVzZXIgICAgICAgICBVU1Igb24gVVNSLlVzZXJJRCA9IEZBTC5Vc2VySUQNCiAgTEVGVCAgSk9JTiBYT" +
                        "E9WQ29kZSAgQkJHX0xPViBvbiBCQkdfTE9WLkxPVk5hbWUgPSAnQmdCZXdpbGxpZ3VuZ1N0YXR1cycgQ" +
                        "U5EIEJCR19MT1YuQ29kZSA9IEJCRy5CZ0Jld2lsbGlndW5nU3RhdHVzQ29kZQ0KV0hFUkUgRkFMLk1vZ" +
                        "HVsSUQgPSAzDQogIEFORCBCQkcuTW9uYXQgSVMgTk9UIE5VTEwNCiAgQU5EIEJCRy5CZ0J1ZGdldElEI" +
                        "D0gbnVsbA==";
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
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.ShUebersichtMonatsbudget_Zahlungen = new DevExpress.XtraReports.UI.Subreport();
            this.ShUebersichtMonatsbudget_Unterst = new DevExpress.XtraReports.UI.Subreport();
            this.ShUebersichtMonatsbudget_Uebersicht = new DevExpress.XtraReports.UI.Subreport();
            this.ShUebersichtMonatsbudget_Budget = new DevExpress.XtraReports.UI.Subreport();
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
            this.lblSig = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSigLoc = new DevExpress.XtraReports.UI.XRLabel();
            this.lblConf = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblFooterLeft = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel2,
                        this.ShUebersichtMonatsbudget_Zahlungen,
                        this.ShUebersichtMonatsbudget_Unterst,
                        this.ShUebersichtMonatsbudget_Uebersicht,
                        this.ShUebersichtMonatsbudget_Budget,
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
            this.Detail.Height = 333;
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
            this.GroupHeader1.Height = 33;
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
                        this.lblSig,
                        this.lblSigLoc,
                        this.lblConf});
            this.GroupFooter1.Height = 123;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorders = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter1.ParentStyleUsing.UseFont = false;
            this.GroupFooter1.ParentStyleUsing.UseForeColor = false;
            this.GroupFooter1.PrintAtBottom = true;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLine1,
                        this.xrLabel5,
                        this.xrPageInfo1,
                        this.xrLabel3,
                        this.lblFooterLeft});
            this.PageFooter.Height = 42;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.CanShrink = true;
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Datum", "Monatsbudget {0:yyyy MMMM}")});
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 14F);
            this.xrLabel2.Location = new System.Drawing.Point(7, 62);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(475, 20);
            this.xrLabel2.Text = "xrLabel2";
            // 
            // ShUebersichtMonatsbudget_Zahlungen
            // 
            this.ShUebersichtMonatsbudget_Zahlungen.Location = new System.Drawing.Point(8, 292);
            this.ShUebersichtMonatsbudget_Zahlungen.Name = "ShUebersichtMonatsbudget_Zahlungen";
            // 
            // ShUebersichtMonatsbudget_Unterst
            // 
            this.ShUebersichtMonatsbudget_Unterst.Location = new System.Drawing.Point(8, 167);
            this.ShUebersichtMonatsbudget_Unterst.Name = "ShUebersichtMonatsbudget_Unterst";
            // 
            // ShUebersichtMonatsbudget_Uebersicht
            // 
            this.ShUebersichtMonatsbudget_Uebersicht.Location = new System.Drawing.Point(8, 250);
            this.ShUebersichtMonatsbudget_Uebersicht.Name = "ShUebersichtMonatsbudget_Uebersicht";
            // 
            // ShUebersichtMonatsbudget_Budget
            // 
            this.ShUebersichtMonatsbudget_Budget.Location = new System.Drawing.Point(8, 208);
            this.ShUebersichtMonatsbudget_Budget.Name = "ShUebersichtMonatsbudget_Budget";
            // 
            // txtOrgPlzOrt
            // 
            this.txtOrgPlzOrt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_PLZOrt", "")});
            this.txtOrgPlzOrt.Font = new System.Drawing.Font("Arial", 10F);
            this.txtOrgPlzOrt.ForeColor = System.Drawing.Color.Black;
            this.txtOrgPlzOrt.Location = new System.Drawing.Point(503, 15);
            this.txtOrgPlzOrt.Multiline = true;
            this.txtOrgPlzOrt.Name = "txtOrgPlzOrt";
            this.txtOrgPlzOrt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOrgPlzOrt.ParentStyleUsing.UseBackColor = false;
            this.txtOrgPlzOrt.ParentStyleUsing.UseBorderColor = false;
            this.txtOrgPlzOrt.ParentStyleUsing.UseBorders = false;
            this.txtOrgPlzOrt.ParentStyleUsing.UseBorderWidth = false;
            this.txtOrgPlzOrt.ParentStyleUsing.UseFont = false;
            this.txtOrgPlzOrt.ParentStyleUsing.UseForeColor = false;
            this.txtOrgPlzOrt.Size = new System.Drawing.Size(228, 15);
            this.txtOrgPlzOrt.Text = "Org_PLZOrt";
            // 
            // txtOrgAdr
            // 
            this.txtOrgAdr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Adresse", "")});
            this.txtOrgAdr.Font = new System.Drawing.Font("Arial", 10F);
            this.txtOrgAdr.ForeColor = System.Drawing.Color.Black;
            this.txtOrgAdr.Location = new System.Drawing.Point(503, 0);
            this.txtOrgAdr.Multiline = true;
            this.txtOrgAdr.Name = "txtOrgAdr";
            this.txtOrgAdr.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOrgAdr.ParentStyleUsing.UseBackColor = false;
            this.txtOrgAdr.ParentStyleUsing.UseBorderColor = false;
            this.txtOrgAdr.ParentStyleUsing.UseBorders = false;
            this.txtOrgAdr.ParentStyleUsing.UseBorderWidth = false;
            this.txtOrgAdr.ParentStyleUsing.UseFont = false;
            this.txtOrgAdr.ParentStyleUsing.UseForeColor = false;
            this.txtOrgAdr.Size = new System.Drawing.Size(228, 15);
            this.txtOrgAdr.Text = "Org_Adresse";
            // 
            // txtOrg
            // 
            this.txtOrg.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Name", "")});
            this.txtOrg.Font = new System.Drawing.Font("Arial", 12F);
            this.txtOrg.ForeColor = System.Drawing.Color.Black;
            this.txtOrg.Location = new System.Drawing.Point(7, 0);
            this.txtOrg.Multiline = true;
            this.txtOrg.Name = "txtOrg";
            this.txtOrg.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOrg.ParentStyleUsing.UseBackColor = false;
            this.txtOrg.ParentStyleUsing.UseBorderColor = false;
            this.txtOrg.ParentStyleUsing.UseBorders = false;
            this.txtOrg.ParentStyleUsing.UseBorderWidth = false;
            this.txtOrg.ParentStyleUsing.UseFont = false;
            this.txtOrg.ParentStyleUsing.UseForeColor = false;
            this.txtOrg.Size = new System.Drawing.Size(480, 23);
            this.txtOrg.Text = "Org_Name";
            // 
            // txtZust
            // 
            this.txtZust.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Zust", "")});
            this.txtZust.Font = new System.Drawing.Font("Arial", 10F);
            this.txtZust.ForeColor = System.Drawing.Color.Black;
            this.txtZust.Location = new System.Drawing.Point(7, 23);
            this.txtZust.Multiline = true;
            this.txtZust.Name = "txtZust";
            this.txtZust.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtZust.ParentStyleUsing.UseBackColor = false;
            this.txtZust.ParentStyleUsing.UseBorderColor = false;
            this.txtZust.ParentStyleUsing.UseBorders = false;
            this.txtZust.ParentStyleUsing.UseBorderWidth = false;
            this.txtZust.ParentStyleUsing.UseFont = false;
            this.txtZust.ParentStyleUsing.UseForeColor = false;
            this.txtZust.Size = new System.Drawing.Size(480, 15);
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
            this.lblStatus.Location = new System.Drawing.Point(7, 86);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblStatus.ParentStyleUsing.UseBackColor = false;
            this.lblStatus.ParentStyleUsing.UseBorderColor = false;
            this.lblStatus.ParentStyleUsing.UseBorders = false;
            this.lblStatus.ParentStyleUsing.UseBorderWidth = false;
            this.lblStatus.ParentStyleUsing.UseFont = false;
            this.lblStatus.ParentStyleUsing.UseForeColor = false;
            this.lblStatus.Size = new System.Drawing.Size(75, 15);
            this.lblStatus.Text = "Status:";
            // 
            // txtStatus
            // 
            this.txtStatus.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Status", "")});
            this.txtStatus.Font = new System.Drawing.Font("Arial", 10F);
            this.txtStatus.ForeColor = System.Drawing.Color.Black;
            this.txtStatus.Location = new System.Drawing.Point(83, 86);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtStatus.ParentStyleUsing.UseBackColor = false;
            this.txtStatus.ParentStyleUsing.UseBorderColor = false;
            this.txtStatus.ParentStyleUsing.UseBorders = false;
            this.txtStatus.ParentStyleUsing.UseBorderWidth = false;
            this.txtStatus.ParentStyleUsing.UseFont = false;
            this.txtStatus.ParentStyleUsing.UseForeColor = false;
            this.txtStatus.Size = new System.Drawing.Size(404, 50);
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
            // lblSig
            // 
            this.lblSig.Font = new System.Drawing.Font("Arial", 10F);
            this.lblSig.ForeColor = System.Drawing.Color.Black;
            this.lblSig.Location = new System.Drawing.Point(502, 60);
            this.lblSig.Name = "lblSig";
            this.lblSig.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSig.ParentStyleUsing.UseBackColor = false;
            this.lblSig.ParentStyleUsing.UseBorderColor = false;
            this.lblSig.ParentStyleUsing.UseBorders = false;
            this.lblSig.ParentStyleUsing.UseBorderWidth = false;
            this.lblSig.ParentStyleUsing.UseFont = false;
            this.lblSig.ParentStyleUsing.UseForeColor = false;
            this.lblSig.Size = new System.Drawing.Size(228, 15);
            this.lblSig.Text = "Unterschrift Klient/in";
            // 
            // lblSigLoc
            // 
            this.lblSigLoc.Font = new System.Drawing.Font("Arial", 10F);
            this.lblSigLoc.ForeColor = System.Drawing.Color.Black;
            this.lblSigLoc.Location = new System.Drawing.Point(6, 60);
            this.lblSigLoc.Name = "lblSigLoc";
            this.lblSigLoc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSigLoc.ParentStyleUsing.UseBackColor = false;
            this.lblSigLoc.ParentStyleUsing.UseBorderColor = false;
            this.lblSigLoc.ParentStyleUsing.UseBorders = false;
            this.lblSigLoc.ParentStyleUsing.UseBorderWidth = false;
            this.lblSigLoc.ParentStyleUsing.UseFont = false;
            this.lblSigLoc.ParentStyleUsing.UseForeColor = false;
            this.lblSigLoc.Size = new System.Drawing.Size(480, 15);
            this.lblSigLoc.Text = "[Ort],";
            // 
            // lblConf
            // 
            this.lblConf.Font = new System.Drawing.Font("Arial", 10F);
            this.lblConf.ForeColor = System.Drawing.Color.Black;
            this.lblConf.Location = new System.Drawing.Point(6, 7);
            this.lblConf.Name = "lblConf";
            this.lblConf.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblConf.ParentStyleUsing.UseBackColor = false;
            this.lblConf.ParentStyleUsing.UseBorderColor = false;
            this.lblConf.ParentStyleUsing.UseBorders = false;
            this.lblConf.ParentStyleUsing.UseBorderWidth = false;
            this.lblConf.ParentStyleUsing.UseFont = false;
            this.lblConf.ParentStyleUsing.UseForeColor = false;
            this.lblConf.Size = new System.Drawing.Size(736, 40);
            this.lblConf.Text = "Der Empfänger/die Empfängerin bestätigt mit seiner/ihrer Unterschrift die Vollstä" +
                "ndigkeit und Richtigkeit der Angaben.";
            // 
            // xrLine1
            // 
            this.xrLine1.Location = new System.Drawing.Point(0, 0);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(743, 4);
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel5.Location = new System.Drawing.Point(447, 20);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(293, 18);
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 9F);
            this.xrPageInfo1.Format = "{0:dd.MMMM.yyyy}";
            this.xrPageInfo1.Location = new System.Drawing.Point(108, 5);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(108, 25);
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Datum", "Monatsbudget {0:MMMM yyyy}")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel3.Location = new System.Drawing.Point(447, 5);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(293, 17);
            this.xrLabel3.Text = "xrLabel3";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblFooterLeft
            // 
            this.lblFooterLeft.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Ort", "{0},")});
            this.lblFooterLeft.Font = new System.Drawing.Font("Arial", 9F);
            this.lblFooterLeft.ForeColor = System.Drawing.Color.Black;
            this.lblFooterLeft.Location = new System.Drawing.Point(0, 5);
            this.lblFooterLeft.Name = "lblFooterLeft";
            this.lblFooterLeft.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblFooterLeft.ParentStyleUsing.UseBackColor = false;
            this.lblFooterLeft.ParentStyleUsing.UseBorderColor = false;
            this.lblFooterLeft.ParentStyleUsing.UseBorders = false;
            this.lblFooterLeft.ParentStyleUsing.UseBorderWidth = false;
            this.lblFooterLeft.ParentStyleUsing.UseFont = false;
            this.lblFooterLeft.ParentStyleUsing.UseForeColor = false;
            this.lblFooterLeft.Size = new System.Drawing.Size(108, 17);
            this.lblFooterLeft.Text = "lblFooterLeft";
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
' , ParameterXML =  N'<?xml version="1.0" standalone="yes" ?>
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
</NewDataSet>' , SQLquery =  N'---- spsota: 20100318

SELECT
  Org_Name    = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Organisation'', GetDate())), ''''),
  Org_Adresse = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Adresse'', GetDate())), ''''),
  Org_PLZ     = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', GetDate())), ''''),
  Org_Ort     = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', GetDate())), ''''),
  Org_PLZOrt  = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', GetDate())) + '' '', '''')
              + IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', GetDate())), ''''),
  BBG.BgBudgetID,

  Datum      = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1),
  Status     = IsNull(''Monatsbudget '' + BBG_LOV.Text, ''?''),

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
  AND BBG.BgBudgetID = {BgBudgetID}' , ContextForms =  N'WhMonatsbudget,WhMasterbudget' , ParentReportName =  null , ReportSortKey = 2
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'ShUebersichtMonatsbudget' ;


INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShUebersichtMonatsbudget_Budget' ,  N'Monatsbudget-Budget' , 1,  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>de-DE</Localization>
///   <References>
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Drawing\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Configuration\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.SqlXml\v4.0_4.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Security\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.Utils.v6.2.dll" />
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
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.Data.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\KiSS4.DB.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\Kiss.Interfaces.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\FluentValidation.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\StructureMap.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\log4net.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\SharpLibrary.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtGrp3Text;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel Betrag1;
        private DevExpress.XtraReports.UI.XRLabel txtKOA;
        private DevExpress.XtraReports.UI.XRLabel txtBezeichnung;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel lblTitle;
        private DevExpress.XtraReports.UI.GroupHeaderBand grp1H;
        private DevExpress.XtraReports.UI.XRLabel txtGrp1Text;
        private DevExpress.XtraReports.UI.GroupHeaderBand grp2H;
        private DevExpress.XtraReports.UI.XRLabel txtGrp2Text;
        private DevExpress.XtraReports.UI.GroupHeaderBand grp3H;
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
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAACAAAAAAAAAFBBRFBBRFATtE6kz" +
                        "4L1rTsAAAAAAAAANgEAADZnAHIAcAAyAEgALgBTAGMAcgBpAHAAdABzAC4ATwBuAEIAZQBmAG8AcgBlA" +
                        "FAAcgBpAG4AdAAAAAAAMnMAcQBsAFEAdQBlAHIAeQAxAC4AUwBlAGwAZQBjAHQAUwB0AGEAdABlAG0AZ" +
                        "QBuAHQAOQEAAAG2AnByaXZhdGUgdm9pZCBPbkJlZm9yZVByaW50KG9iamVjdCBzZW5kZXIsIFN5c3Rlb" +
                        "S5EcmF3aW5nLlByaW50aW5nLlByaW50RXZlbnRBcmdzIGUpIHsNCiAgIHRyeSB7DQogICAgICAvLyBoa" +
                        "WRlIGdycDIgaWYgZW1wdHkNCiAgICAgIGdycDJILlZpc2libGUgPSBoaWRkZW5MYmxTaFBvc2l0aW9uV" +
                        "HlwSUQuVGV4dCAhPSBzdHJpbmcuRW1wdHk7DQogICB9Y2F0Y2ggKFN5c3RlbS5FeGNlcHRpb24gZXgpI" +
                        "HsNCiAgICAgIFN5c3RlbS5XaW5kb3dzLkZvcm1zLk1lc3NhZ2VCb3guU2hvdyhleC5TdGFja1RyYWNlL" +
                        "CBleC5NZXNzYWdlKTsNCiAgIH0NCn0BswtERUNMQVJFIEBSZWZEYXRlICBkYXRldGltZSAgU0VUIEBSZ" +
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
                        "kJlemVpY2hudW5nKSwgVE1QLkJldHJhZywgVE1QLktPQQ0KRlJPTSBkYm8uZm5XaEdldEJ1ZGdldChud" +
                        "WxsLCBAUmVmRGF0ZSkgIFRNUA0KICBMRUZUICBKT0lOIFhMT1ZDb2RlICAgICAgICBCUEMgT04gQlBDL" +
                        "kxPVk5hbWUgPSAnQmdLYXRlZ29yaWUnIEFORCBCUEMuQ29kZSA9IFRNUC5CZ0thdGVnb3JpZUNvZGUNC" +
                        "iAgTEVGVCAgSk9JTiBYTE9WQ29kZSAgICAgICAgU1BDIE9OIFNQQy5MT1ZOYW1lID0gJ0JnR3J1cHBlJ" +
                        "yBBTkQgU1BDLkNvZGUgPSBUTVAuQmdHcnVwcGVDb2RlDQogIExFRlQgIEpPSU4gQmdQb3NpdGlvbnNhc" +
                        "nQgIFNQVCBPTiBTUFQuQmdQb3NpdGlvbnNhcnRJRCA9IFRNUC5CZ1Bvc2l0aW9uc2FydElEDQogIExFR" +
                        "lQgIEpPSU4gQmdTcGV6a29udG8gICAgIFNQSyBPTiBTUEsuQmdTcGV6a29udG9JRCA9IFRNUC5CZ1NwZ" +
                        "Xprb250b0lEDQpXSEVSRSBUTVAuQmdQb3NpdGlvbklEIElTIE5PVCBOVUxM";
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
            this.txtGrp3Text = new DevExpress.XtraReports.UI.XRLabel();
            this.Betrag1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKOA = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBezeichnung = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGrp1Text = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGrp2Text = new DevExpress.XtraReports.UI.XRLabel();
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
                        this.txtGrp3Text,
                        this.Betrag1,
                        this.txtKOA,
                        this.txtBezeichnung});
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
            this.grp1H.Height = 25;
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
            this.grp2H.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.grp2H.Height = 16;
            this.grp2H.KeepTogether = true;
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
            this.grp3H.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("GroupText", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.grp3H.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
            this.grp3H.Height = 0;
            this.grp3H.KeepTogether = true;
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
            this.ReportFooter.Height = 86;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
            this.ReportFooter.Visible = false;
            // 
            // txtGrp3Text
            // 
            this.txtGrp3Text.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GroupText", "")});
            this.txtGrp3Text.Font = new System.Drawing.Font("Arial", 7F);
            this.txtGrp3Text.ForeColor = System.Drawing.Color.Black;
            this.txtGrp3Text.Location = new System.Drawing.Point(417, 0);
            this.txtGrp3Text.Multiline = true;
            this.txtGrp3Text.Name = "txtGrp3Text";
            this.txtGrp3Text.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGrp3Text.ParentStyleUsing.UseBackColor = false;
            this.txtGrp3Text.ParentStyleUsing.UseBorderColor = false;
            this.txtGrp3Text.ParentStyleUsing.UseBorders = false;
            this.txtGrp3Text.ParentStyleUsing.UseBorderWidth = false;
            this.txtGrp3Text.ParentStyleUsing.UseFont = false;
            this.txtGrp3Text.ParentStyleUsing.UseForeColor = false;
            this.txtGrp3Text.Size = new System.Drawing.Size(183, 15);
            this.txtGrp3Text.Text = "GroupText";
            // 
            // Betrag1
            // 
            this.Betrag1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.Betrag1.Font = new System.Drawing.Font("Arial", 10F);
            this.Betrag1.ForeColor = System.Drawing.Color.Black;
            this.Betrag1.Location = new System.Drawing.Point(642, 0);
            this.Betrag1.Multiline = true;
            this.Betrag1.Name = "Betrag1";
            this.Betrag1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Betrag1.ParentStyleUsing.UseBackColor = false;
            this.Betrag1.ParentStyleUsing.UseBorderColor = false;
            this.Betrag1.ParentStyleUsing.UseBorders = false;
            this.Betrag1.ParentStyleUsing.UseBorderWidth = false;
            this.Betrag1.ParentStyleUsing.UseFont = false;
            this.Betrag1.ParentStyleUsing.UseForeColor = false;
            this.Betrag1.Size = new System.Drawing.Size(82, 15);
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
            this.txtKOA.Location = new System.Drawing.Point(600, 0);
            this.txtKOA.Multiline = true;
            this.txtKOA.Name = "txtKOA";
            this.txtKOA.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKOA.ParentStyleUsing.UseBackColor = false;
            this.txtKOA.ParentStyleUsing.UseBorderColor = false;
            this.txtKOA.ParentStyleUsing.UseBorders = false;
            this.txtKOA.ParentStyleUsing.UseBorderWidth = false;
            this.txtKOA.ParentStyleUsing.UseFont = false;
            this.txtKOA.ParentStyleUsing.UseForeColor = false;
            this.txtKOA.Size = new System.Drawing.Size(42, 15);
            this.txtKOA.Text = "KOA";
            // 
            // txtBezeichnung
            // 
            this.txtBezeichnung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bezeichnung", "")});
            this.txtBezeichnung.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBezeichnung.ForeColor = System.Drawing.Color.Black;
            this.txtBezeichnung.Location = new System.Drawing.Point(17, 0);
            this.txtBezeichnung.Multiline = true;
            this.txtBezeichnung.Name = "txtBezeichnung";
            this.txtBezeichnung.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBezeichnung.ParentStyleUsing.UseBackColor = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorderColor = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorders = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorderWidth = false;
            this.txtBezeichnung.ParentStyleUsing.UseFont = false;
            this.txtBezeichnung.ParentStyleUsing.UseForeColor = false;
            this.txtBezeichnung.Size = new System.Drawing.Size(389, 15);
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
            this.txtGrp1Text.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.txtGrp1Text.ForeColor = System.Drawing.Color.Black;
            this.txtGrp1Text.Location = new System.Drawing.Point(0, 3);
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
            this.txtGrp2Text.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
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
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BgKategorieText", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.Location = new System.Drawing.Point(353, 7);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(164, 20);
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
            this.Line2.Size = new System.Drawing.Size(600, 2);
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
            this.Line1.Size = new System.Drawing.Size(289, 2);
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
            this.Grp1Betrag.Location = new System.Drawing.Point(502, 7);
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
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BgPositionsartID", "")});
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

  Bezeichnung = LTrim(TMP.Bezeichnung), TMP.Betrag, TMP.KOA
FROM dbo.fnWhGetBudget({BgBudgetID}, @RefDate)  TMP
  LEFT  JOIN XLOVCode        BPC ON BPC.LOVName = ''BgKategorie'' AND BPC.Code = TMP.BgKategorieCode
  LEFT  JOIN XLOVCode        SPC ON SPC.LOVName = ''BgGruppe'' AND SPC.Code = TMP.BgGruppeCode
  LEFT  JOIN BgPositionsart  SPT ON SPT.BgPositionsartID = TMP.BgPositionsartID
  LEFT  JOIN BgSpezkonto     SPK ON SPK.BgSpezkontoID = TMP.BgSpezkontoID
WHERE TMP.BgPositionID IS NOT NULL' ,  null ,  N'ShUebersichtMonatsbudget' ,  null );


INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShUebersichtMonatsbudget_Uebersicht' ,  N'Monatsbudget-Uebersicht' , 1,  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>de-DE</Localization>
///   <References>
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Drawing\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Configuration\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.SqlXml\v4.0_4.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Security\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.Utils.v6.2.dll" />
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
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.Data.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\KiSS4.DB.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\Kiss.Interfaces.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\FluentValidation.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\StructureMap.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\log4net.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\SharpLibrary.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtBezeichnung;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel lblTitle;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLabel Betrag1;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel lblTot;
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
                        "AAAAYgHREVDTEFSRSBAUmVmRGF0ZSAgZGF0ZXRpbWUgIFNFVCBAUmVmRGF0ZSA9IEdldERhdGUoKQ0KD" +
                        "QpERUNMQVJFIEBvdXQgVEFCTEUgKA0KICBSZWNfSUQgICAgICBpbnQgTlVMTCwNCiAgUGFyZW50X0lEI" +
                        "CAgaW50IE5PVCBOVUxMLA0KICBTb3J0S2V5ICAgICBpbnQgTk9UIE5VTEwsDQogIFN0eWxlICAgICAgI" +
                        "GludCBOT1QgTlVMTCwNCiAgQmV6ZWljaG51bmcgdmFyY2hhcigxMDApIE5PVCBOVUxMLA0KICBCZXRyY" +
                        "WcgICAgICBtb25leSBOVUxMDQopDQoNCklOU0VSVCBJTlRPIEBvdXQNCiAgU0VMRUNUIFJlY19JRCwgU" +
                        "GFyZW50X0lELCBTb3J0S2V5LCBTdHlsZSwgQmV6ZWljaG51bmcsIEJldHJhZw0KICBGUk9NIGRiby5mb" +
                        "ldoR2V0QnVkZ2V0KG51bGwsIEBSZWZEYXRlKSAgVE1QDQogIFdIRVJFIFBhcmVudF9JRCA+IDANCg0KU" +
                        "0VMRUNUDQogIEdyb3VwSUQgICAgID0gR1JQLlJlY19JRCwNCiAgR3J1cHBlICAgICAgPSBMVHJpbShHU" +
                        "lAuQmV6ZWljaG51bmcpLA0KICBUb3RhbFRleHQgICA9IChTRUxFQ1QgTFRyaW0oQmV6ZWljaG51bmcpI" +
                        "EZST00gQG91dCBXSEVSRSBTb3J0S2V5ID0gVE1QLlNvcnRLZXkgKyAxKSwNCiAgQmV6ZWljaG51bmcgP" +
                        "SBMVHJpbShCRVouQmV6ZWljaG51bmcpLA0KICBCRVouQmV0cmFnDQpGUk9NIEBvdXQgICAgICAgICAgR" +
                        "1JQDQogIElOTkVSIEpPSU4gQG91dCAgQkVaIE9OIEJFWi5QYXJlbnRfSUQgPSBHUlAuUmVjX0lEDQogI" +
                        "ElOTkVSIEpPSU4gKFNFTEVDVCBQYXJlbnRfSUQsIFNvcnRLZXkgPSBNQVgoU29ydEtleSkNCiAgICAgI" +
                        "CAgICAgICAgRlJPTSBAb3V0IEdST1VQIEJZIFBhcmVudF9JRCkgIFRNUCBPTiBUTVAuUGFyZW50X0lEI" +
                        "D0gR1JQLlJlY19JRA0KV0hFUkUgR1JQLlJlY19JRCBJUyBOT1QgTlVMTA0KICBBTkQgQkVaLkJldHJhZ" +
                        "yA8PiAkMC4wMA==";
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
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.txtBezeichnung = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.Betrag1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.lblTot = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtBezeichnung,
                        this.txtBetrag});
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
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Line2,
                        this.Betrag1,
                        this.Line1,
                        this.lblTot});
            this.ReportFooter.Height = 26;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // txtBezeichnung
            // 
            this.txtBezeichnung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bezeichnung", "")});
            this.txtBezeichnung.Font = new System.Drawing.Font("Arial", 8F);
            this.txtBezeichnung.ForeColor = System.Drawing.Color.Black;
            this.txtBezeichnung.Location = new System.Drawing.Point(0, 0);
            this.txtBezeichnung.Multiline = true;
            this.txtBezeichnung.Name = "txtBezeichnung";
            this.txtBezeichnung.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBezeichnung.ParentStyleUsing.UseBackColor = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorderColor = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorders = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorderWidth = false;
            this.txtBezeichnung.ParentStyleUsing.UseFont = false;
            this.txtBezeichnung.ParentStyleUsing.UseForeColor = false;
            this.txtBezeichnung.Size = new System.Drawing.Size(400, 15);
            this.txtBezeichnung.Text = "Bezeichnung";
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 8F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(400, 0);
            this.txtBetrag.Multiline = true;
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(133, 15);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtBetrag.Summary = xrSummary1;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            this.lblTitle.Size = new System.Drawing.Size(533, 23);
            this.lblTitle.Text = "Leistungen des Sozialdienstes";
            this.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.Location = new System.Drawing.Point(0, 22);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(533, 4);
            // 
            // Betrag1
            // 
            this.Betrag1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.Betrag1.Font = new System.Drawing.Font("Arial", 8F);
            this.Betrag1.ForeColor = System.Drawing.Color.Black;
            this.Betrag1.Location = new System.Drawing.Point(400, 8);
            this.Betrag1.Multiline = true;
            this.Betrag1.Name = "Betrag1";
            this.Betrag1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Betrag1.ParentStyleUsing.UseBackColor = false;
            this.Betrag1.ParentStyleUsing.UseBorderColor = false;
            this.Betrag1.ParentStyleUsing.UseBorders = false;
            this.Betrag1.ParentStyleUsing.UseBorderWidth = false;
            this.Betrag1.ParentStyleUsing.UseFont = false;
            this.Betrag1.ParentStyleUsing.UseForeColor = false;
            this.Betrag1.Size = new System.Drawing.Size(133, 16);
            xrSummary2.FormatString = "{0:#,##0.00}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.Betrag1.Summary = xrSummary2;
            this.Betrag1.Text = "Betrag";
            this.Betrag1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            this.Line1.Size = new System.Drawing.Size(533, 4);
            // 
            // lblTot
            // 
            this.lblTot.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblTot.ForeColor = System.Drawing.Color.Black;
            this.lblTot.Location = new System.Drawing.Point(0, 5);
            this.lblTot.Name = "lblTot";
            this.lblTot.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTot.ParentStyleUsing.UseBackColor = false;
            this.lblTot.ParentStyleUsing.UseBorderColor = false;
            this.lblTot.ParentStyleUsing.UseBorders = false;
            this.lblTot.ParentStyleUsing.UseBorderWidth = false;
            this.lblTot.ParentStyleUsing.UseFont = false;
            this.lblTot.ParentStyleUsing.UseForeColor = false;
            this.lblTot.Size = new System.Drawing.Size(400, 16);
            this.lblTot.Text = "Gesamte, vom Sozialdienst erbrachte Leistung";
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
  FROM dbo.fnWhGetBudget({BgBudgetID}, @RefDate)  TMP
  WHERE Parent_ID > 0 AND BgKategorieCode in (2,100,101) 

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
WHERE GRP.Rec_ID IS NOT NULL
  AND BEZ.Betrag <> $0.00' ,  null ,  N'ShUebersichtMonatsbudget' ,  null );


INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShUebersichtMonatsbudget_Unterst' ,  N'Monatsbudget-Unterst' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\KiSS\R4233\KiSS4.DB.dll" />
///     <Reference Path="C:\KiSS\R4233\log4net.dll" />
///     <Reference Path="C:\KiSS\R4233\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtKSTName;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtHeimatort;
        private DevExpress.XtraReports.UI.XRLabel txtAHV;
        private DevExpress.XtraReports.UI.XRLabel txtName;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLabel Label6;
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
                    string resourceString = @"zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OSNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kAAAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAAAAAAcUFU0VMRUNUDQogIE5hbWUgICAgICAgPSBQUlMuTmFtZVZvcm5hbWUsDQogIFZlcnNOdW1tZXIgPSBJc051bGwoUFJTLlZlcnNpY2hlcnRlbm51bW1lciwnJyksDQogIEtTVE5hbWUgICAgPSBLU1QuTnIsLS1kYm8uZm5LYkdldEtvc3RlbnN0ZWxsZShQUlMuQmFQZXJzb25JRCksDQogIFBSUy5IZWltYXRvcnQNCkZST00gQmdCdWRnZXQgICAgICAgICAgICAgICAgICAgICAgICBCQkcNCiAgSU5ORVIgSk9JTiBCZ0ZpbmFuenBsYW5fQmFQZXJzb24gICBTUFAgT04gU1BQLkJnRmluYW56cGxhbklEID0gQkJHLkJnRmluYW56cGxhbklEDQogIElOTkVSIEpPSU4gdndQZXJzb24gICAgICAgICAgICAgICAgUFJTIE9OIFBSUy5CYVBlcnNvbklEID0gU1BQLkJhUGVyc29uSUQNCiAgTEVGVCAgSk9JTiBLYktvc3RlbnN0ZWxsZV9CYVBlcnNvbiBLU1AgT04gS1NQLkJhUGVyc29uSUQgPSBQUlMuQmFQZXJzb25JRCBBTkQgKEtTUC5EYXR1bVZvbiA8PSBHRVREQVRFKCkgQU5EIChLU1AuRGF0dW1CaXMgSVMgTlVMTCBPUiBLU1AuRGF0dW1CaXMgPj0gR0VUREFURSgpKSkNCiAgTEVGVCAgSk9JTiBLYktvc3RlbnN0ZWxsZSAgICAgICAgICBLU1QgT04gS1NULktiS29zdGVuc3RlbGxlSUQgPSBLU1AuS2JLb3N0ZW5zdGVsbGVJRCBBTkQgS1NULkFrdGl2ID0gMQ0KV0hFUkUgU1BQLklzdFVudGVyc3R1ZXR6dCA9IDENCiAgQU5EIEJCRy5CZ0J1ZGdldElEID0gbnVsbA==";
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
            this.txtHeimatort = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAHV = new DevExpress.XtraReports.UI.XRLabel();
            this.txtName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
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
                        this.Label3,
                        this.Label2,
                        this.Label1});
            this.ReportHeader.Height = 53;
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
            this.ReportFooter.Height = 22;
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
            this.txtKSTName.Location = new System.Drawing.Point(458, 0);
            this.txtKSTName.Multiline = true;
            this.txtKSTName.Name = "txtKSTName";
            this.txtKSTName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKSTName.ParentStyleUsing.UseBackColor = false;
            this.txtKSTName.ParentStyleUsing.UseBorderColor = false;
            this.txtKSTName.ParentStyleUsing.UseBorders = false;
            this.txtKSTName.ParentStyleUsing.UseBorderWidth = false;
            this.txtKSTName.ParentStyleUsing.UseFont = false;
            this.txtKSTName.ParentStyleUsing.UseForeColor = false;
            this.txtKSTName.Size = new System.Drawing.Size(266, 15);
            this.txtKSTName.Text = "KSTName";
            // 
            // txtHeimatort
            // 
            this.txtHeimatort.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Heimatort", "")});
            this.txtHeimatort.Font = new System.Drawing.Font("Arial", 9F);
            this.txtHeimatort.ForeColor = System.Drawing.Color.Black;
            this.txtHeimatort.Location = new System.Drawing.Point(333, 0);
            this.txtHeimatort.Multiline = true;
            this.txtHeimatort.Name = "txtHeimatort";
            this.txtHeimatort.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtHeimatort.ParentStyleUsing.UseBackColor = false;
            this.txtHeimatort.ParentStyleUsing.UseBorderColor = false;
            this.txtHeimatort.ParentStyleUsing.UseBorders = false;
            this.txtHeimatort.ParentStyleUsing.UseBorderWidth = false;
            this.txtHeimatort.ParentStyleUsing.UseFont = false;
            this.txtHeimatort.ParentStyleUsing.UseForeColor = false;
            this.txtHeimatort.Size = new System.Drawing.Size(117, 15);
            this.txtHeimatort.Text = "Heimatort";
            // 
            // txtAHV
            // 
            this.txtAHV.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VersNummer", "")});
            this.txtAHV.Font = new System.Drawing.Font("Arial", 9F);
            this.txtAHV.ForeColor = System.Drawing.Color.Black;
            this.txtAHV.Location = new System.Drawing.Point(225, 0);
            this.txtAHV.Multiline = true;
            this.txtAHV.Name = "txtAHV";
            this.txtAHV.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtAHV.ParentStyleUsing.UseBackColor = false;
            this.txtAHV.ParentStyleUsing.UseBorderColor = false;
            this.txtAHV.ParentStyleUsing.UseBorders = false;
            this.txtAHV.ParentStyleUsing.UseBorderWidth = false;
            this.txtAHV.ParentStyleUsing.UseFont = false;
            this.txtAHV.ParentStyleUsing.UseForeColor = false;
            this.txtAHV.Size = new System.Drawing.Size(108, 15);
            this.txtAHV.Text = "txtAHV";
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
            this.txtName.Size = new System.Drawing.Size(217, 15);
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
            this.Label6.Location = new System.Drawing.Point(458, 31);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(100, 15);
            this.Label6.Text = "KST GB, Miete";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(333, 31);
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
            this.Label2.Location = new System.Drawing.Point(225, 31);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(94, 15);
            this.Label2.Text = "Vers.-Nummer";
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
  Name       = PRS.NameVorname,
  VersNummer = IsNull(PRS.Versichertennummer,''''),
  KSTName    = KST.Nr,--dbo.fnKbGetKostenstelle(PRS.BaPersonID),
  PRS.Heimatort
FROM BgBudget                        BBG
  INNER JOIN BgFinanzplan_BaPerson   SPP ON SPP.BgFinanzplanID = BBG.BgFinanzplanID
  INNER JOIN vwPerson                PRS ON PRS.BaPersonID = SPP.BaPersonID
  LEFT  JOIN KbKostenstelle_BaPerson KSP ON KSP.BaPersonID = PRS.BaPersonID AND (KSP.DatumVon <= GETDATE() AND (KSP.DatumBis IS NULL OR KSP.DatumBis >= GETDATE()))
  LEFT  JOIN KbKostenstelle          KST ON KST.KbKostenstelleID = KSP.KbKostenstelleID AND KST.Aktiv = 1
WHERE SPP.IstUnterstuetzt = 1
  AND BBG.BgBudgetID = {BgBudgetID}' ,  null ,  N'ShUebersichtMonatsbudget' ,  null );


INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShUebersichtMonatsbudget_Zahlungen' ,  N'Monatsbudget-Zahlungen' , 1,  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>de-DE</Localization>
///   <References>
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Drawing\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Configuration\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Data.SqlXml\v4.0_4.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Security\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.Utils.v6.2.dll" />
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
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.Data.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\KiSS4.DB.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\Kiss.Interfaces.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\FluentValidation.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\StructureMap.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\log4net.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\SharpLibrary.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="c:\programme\born informatik ag\KISS4_Prod\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtVerfalldatum;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel txtCashOrCheckAm;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private DevExpress.XtraReports.UI.XRLabel txtKOA;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel lblTitle;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
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
                        "W9uPTQuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
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
            this.txtVerfalldatum = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtCashOrCheckAm = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKOA = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTitle = new DevExpress.XtraReports.UI.XRLabel();
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
                        this.txtVerfalldatum,
                        this.xrLabel1,
                        this.txtCashOrCheckAm,
                        this.txtBetrag,
                        this.txtKOA});
            this.Detail.Height = 19;
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
                        this.Label5,
                        this.Label4,
                        this.Label3,
                        this.Label2,
                        this.Label1,
                        this.txtEmpfänger});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("Empfänger", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 58;
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
            this.GroupFooter1.Height = 26;
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
            // txtVerfalldatum
            // 
            this.txtVerfalldatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ValutaDatum", "{0:d}")});
            this.txtVerfalldatum.Font = new System.Drawing.Font("Arial", 8F);
            this.txtVerfalldatum.ForeColor = System.Drawing.Color.Black;
            this.txtVerfalldatum.Location = new System.Drawing.Point(383, 0);
            this.txtVerfalldatum.Name = "txtVerfalldatum";
            this.txtVerfalldatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtVerfalldatum.ParentStyleUsing.UseBackColor = false;
            this.txtVerfalldatum.ParentStyleUsing.UseBorderColor = false;
            this.txtVerfalldatum.ParentStyleUsing.UseBorders = false;
            this.txtVerfalldatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtVerfalldatum.ParentStyleUsing.UseFont = false;
            this.txtVerfalldatum.ParentStyleUsing.UseForeColor = false;
            this.txtVerfalldatum.Size = new System.Drawing.Size(69, 17);
            xrSummary1.FormatString = "{0:dd.MM.yyyy}";
            this.txtVerfalldatum.Summary = xrSummary1;
            this.txtVerfalldatum.Text = "txtVerfalldatum";
            this.txtVerfalldatum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Buchungstext", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.Location = new System.Drawing.Point(17, 0);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseBackColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.ParentStyleUsing.UseForeColor = false;
            this.xrLabel1.Size = new System.Drawing.Size(333, 16);
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // txtCashOrCheckAm
            // 
            this.txtCashOrCheckAm.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BarbelegDatum", "{0:d}")});
            this.txtCashOrCheckAm.Font = new System.Drawing.Font("Arial", 8F);
            this.txtCashOrCheckAm.ForeColor = System.Drawing.Color.Black;
            this.txtCashOrCheckAm.Location = new System.Drawing.Point(450, 0);
            this.txtCashOrCheckAm.Name = "txtCashOrCheckAm";
            this.txtCashOrCheckAm.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtCashOrCheckAm.ParentStyleUsing.UseBackColor = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseBorderColor = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseBorders = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseBorderWidth = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseFont = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseForeColor = false;
            this.txtCashOrCheckAm.Size = new System.Drawing.Size(83, 17);
            xrSummary2.FormatString = "{0:dd.MM.yyyy hh:mm}";
            this.txtCashOrCheckAm.Summary = xrSummary2;
            this.txtCashOrCheckAm.Text = "txtCashOrCheckAm";
            this.txtCashOrCheckAm.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 8F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(533, 0);
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(70, 17);
            xrSummary3.FormatString = "{0:#,##0.00}";
            this.txtBetrag.Summary = xrSummary3;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtKOA
            // 
            this.txtKOA.Font = new System.Drawing.Font("Arial", 8F);
            this.txtKOA.ForeColor = System.Drawing.Color.Black;
            this.txtKOA.Location = new System.Drawing.Point(350, 0);
            this.txtKOA.Name = "txtKOA";
            this.txtKOA.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKOA.ParentStyleUsing.UseBackColor = false;
            this.txtKOA.ParentStyleUsing.UseBorderColor = false;
            this.txtKOA.ParentStyleUsing.UseBorders = false;
            this.txtKOA.ParentStyleUsing.UseBorderWidth = false;
            this.txtKOA.ParentStyleUsing.UseFont = false;
            this.txtKOA.ParentStyleUsing.UseForeColor = false;
            this.txtKOA.Size = new System.Drawing.Size(32, 17);
            this.txtKOA.Text = "KOA";
            this.txtKOA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            this.lblTitle.Size = new System.Drawing.Size(608, 23);
            this.lblTitle.Text = "Zahlungen";
            this.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(533, 33);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(73, 16);
            this.Label5.Text = "Betrag";
            this.Label5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(450, 33);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(83, 16);
            this.Label4.Text = "Ausbezahlt";
            this.Label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(383, 33);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(67, 16);
            this.Label3.Text = "Fällig am";
            this.Label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(350, 33);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(34, 16);
            this.Label2.Text = "KOA";
            this.Label2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(17, 35);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(333, 16);
            this.Label1.Text = "Buchungstext";
            this.Label1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // txtEmpfänger
            // 
            this.txtEmpfänger.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Empfänger", "")});
            this.txtEmpfänger.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtEmpfänger.ForeColor = System.Drawing.Color.Black;
            this.txtEmpfänger.Location = new System.Drawing.Point(0, 10);
            this.txtEmpfänger.Multiline = true;
            this.txtEmpfänger.Name = "txtEmpfänger";
            this.txtEmpfänger.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtEmpfänger.ParentStyleUsing.UseBackColor = false;
            this.txtEmpfänger.ParentStyleUsing.UseBorderColor = false;
            this.txtEmpfänger.ParentStyleUsing.UseBorders = false;
            this.txtEmpfänger.ParentStyleUsing.UseBorderWidth = false;
            this.txtEmpfänger.ParentStyleUsing.UseFont = false;
            this.txtEmpfänger.ParentStyleUsing.UseForeColor = false;
            this.txtEmpfänger.Size = new System.Drawing.Size(608, 20);
            this.txtEmpfänger.Text = "Empfänger";
            // 
            // Betrag1
            // 
            this.Betrag1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.Betrag1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Betrag1.ForeColor = System.Drawing.Color.Black;
            this.Betrag1.Location = new System.Drawing.Point(533, 8);
            this.Betrag1.Name = "Betrag1";
            this.Betrag1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Betrag1.ParentStyleUsing.UseBackColor = false;
            this.Betrag1.ParentStyleUsing.UseBorderColor = false;
            this.Betrag1.ParentStyleUsing.UseBorders = false;
            this.Betrag1.ParentStyleUsing.UseBorderWidth = false;
            this.Betrag1.ParentStyleUsing.UseFont = false;
            this.Betrag1.ParentStyleUsing.UseForeColor = false;
            this.Betrag1.Size = new System.Drawing.Size(73, 17);
            xrSummary4.FormatString = "{0:#,##0.00}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.Betrag1.Summary = xrSummary4;
            this.Betrag1.Text = "Betrag";
            this.Betrag1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(300, 8);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(236, 17);
            this.Label6.Text = "Total für diesen Empfänger";
            this.Label6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Betrag2
            // 
            this.Betrag2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.Betrag2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Betrag2.ForeColor = System.Drawing.Color.Black;
            this.Betrag2.Location = new System.Drawing.Point(532, 8);
            this.Betrag2.Name = "Betrag2";
            this.Betrag2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Betrag2.ParentStyleUsing.UseBackColor = false;
            this.Betrag2.ParentStyleUsing.UseBorderColor = false;
            this.Betrag2.ParentStyleUsing.UseBorders = false;
            this.Betrag2.ParentStyleUsing.UseBorderWidth = false;
            this.Betrag2.ParentStyleUsing.UseFont = false;
            this.Betrag2.ParentStyleUsing.UseForeColor = false;
            this.Betrag2.Size = new System.Drawing.Size(73, 17);
            xrSummary5.FormatString = "{0:#,##0.00}";
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.Betrag2.Summary = xrSummary5;
            this.Betrag2.Text = "Betrag";
            this.Betrag2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(300, 8);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(236, 17);
            this.Label7.Text = "Total Zahlungen";
            this.Label7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.Location = new System.Drawing.Point(0, 21);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(600, 8);
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
            this.Line1.Size = new System.Drawing.Size(600, 4);
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
      ELSE IsNull(KRE.Kreditor, '''')
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
  KBK.Buchungstext' ,  null ,  N'ShUebersichtMonatsbudget' ,  null );


INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShUebersichtMonatsbudget_Zahlungen_OLD' ,  N'Monatsbudget-Zahlungen_OLD' , 1,  N'/// <XRTypeInfo>
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
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAACAAAAAAAAAFBBRFBBRFChz7yjE" +
                        "7ROpAAAAABJAAAARAEAAERSAGUAcABvAHIAdABIAGUAYQBkAGUAcgAuAFMAYwByAGkAcAB0AHMALgBPA" +
                        "G4AQgBlAGYAbwByAGUAUAByAGkAbgB0AAAAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAd" +
                        "ABTAHQAYQB0AGUAbQBlAG4AdAAXAQAAAZQCcHJpdmF0ZSB2b2lkIE9uQmVmb3JlUHJpbnQob2JqZWN0I" +
                        "HNlbmRlciwgU3lzdGVtLkRyYXdpbmcuUHJpbnRpbmcuUHJpbnRFdmVudEFyZ3MgZSkgDQp7DQogIC8vI" +
                        "EJlaSBJbnRlZ3JhdGlvbkJFIHNvbGxlbiBrZWllbiBEZWF0aWxzIGRlciBaYWhsdW5nZW4gDQogIC8vI" +
                        "GdlZHJ1Y2t0IHdlcmRlbiwgbnVyIFRvdGFsZSBkZXIgRW1wZsOkbmdlcg0KICBHcm91cEhlYWRlclpha" +
                        "Gx1bmdlbi5WaXNpYmxlID0gZmFsc2U7DQogIERldGFpbFphaGx1bmdlbi5WaXNpYmxlID0gZmFsc2U7D" +
                        "Qp9AcsNREVDTEFSRSBAQmdCdWRnZXRJRCAgICAgaW50LA0KICAgICAgICBAQmdGaW5hbnpwbGFuSUQga" +
                        "W50DQoNClNFTEVDVA0KICBAQmdCdWRnZXRJRCA9IEJnQnVkZ2V0SUQsDQogIEBCZ0ZpbmFuenBsYW5JR" +
                        "CA9IEJnRmluYW56cGxhbklEDQpGUk9NIEJnQnVkZ2V0DQpXSEVSRSBCZ0J1ZGdldElEID0gbnVsbA0KD" +
                        "QpTRUxFQ1QNCiAgUGF5VG9DbGllbnQgPSBDQVNFDQogICAgICBXSEVOIEtCVS5LYkF1c3phaGx1bmdzQ" +
                        "XJ0Q29kZSBJTiAoMTAzLCAxMDQpICAgIFRIRU4gMQ0KICAgICAgV0hFTiBLUkUuQmFQZXJzb25JRCBJU" +
                        "yBOVUxMICAgICAgICAgICAgICAgICAgICBUSEVOIDANCiAgICAgIFdIRU4gS1JFLkJhUGVyc29uSUQgS" +
                        "U4gKFNFTEVDVCBCRlAuQmFQZXJzb25JRA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPT" +
                        "SBCZ0ZpbmFuenBsYW5fQmFQZXJzb24gIEJGUA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgV" +
                        "0hFUkUgQkZQLkJnRmluYW56cGxhbklEID0gQEJnRmluYW56cGxhbklEDQogICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgIEFORCBCRlAuSXN0VW50ZXJzdHVldHp0ID0gMSkgVEhFTiAxDQovKg0KICAgI" +
                        "CAgV0hFTiBLUkUuQmFQZXJzb25JRCBJTiAoU0VMRUNUIEJaVy5CYVBlcnNvbklEDQogICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICBGUk9NIEJnRmluYW56cGxhbl9CYVBlcnNvbiAgQkZQDQogICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgIElOTkVSIEpPSU4gQmFaYWhsdW5nc3dlZyAgQlpXIE9OIEJaV" +
                        "y5CYVphaGx1bmdzd2VnSUQgPSBCRlAuQmFaYWhsdW5nc3dlZ0lEDQogICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICBXSEVSRSBCRlAuQmdGaW5hbnpwbGFuSUQgPSBAQmdGaW5hbnpwbGFuSUQNCiAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEJGUC5Jc3RVbnRlcnN0dWV0enQgPSAxKSBUSEVOI" +
                        "DENCiovDQogICAgICBFTFNFIDANCiAgICBFTkQsDQogIEVtcGbDpG5nZXIgPQ0KICAgIENBU0UgV0hFT" +
                        "iBLQlUuS2JBdXN6YWhsdW5nc0FydENvZGUgSU4gKDEwMywgMTA0KQ0KICAgICAgVEhFTiAnQW4gS2xpZ" +
                        "W50Jw0KICAgICAgRUxTRSBJc051bGwoS1JFLktyZWRpdG9yLCAnJykNCiAgICBFTkQgKyAnIC0gJyArD" +
                        "QogICAgKFNFTEVDVCBUZXh0IEZST00gWExPVkNvZGUgV0hFUkUgTE9WTmFtZSA9ICdLYkF1c3phaGx1b" +
                        "mdzQXJ0JyBBTkQgQ29kZSA9IEtCVS5LYkF1c3phaGx1bmdzQXJ0Q29kZSksDQogIEtCSy5CdWNodW5nc" +
                        "3RleHQsDQogIEtPQSA9IEZLQS5Lb250b05yLA0KICBLQlUuVmFsdXRhRGF0dW0sDQogIEtCVS5CYXJiZ" +
                        "WxlZ0RhdHVtLA0KICBLQksuQmV0cmFnDQpGUk9NIEtiQnVjaHVuZyAgICAgICAgICAgICAgICAgIEtCV" +
                        "Q0KICBJTk5FUiBKT0lOIEtiQnVjaHVuZ0tvc3RlbmFydCBLQksgT04gS0JLLktiQnVjaHVuZ0lEID0gS" +
                        "0JVLktiQnVjaHVuZ0lEDQogIElOTkVSIEpPSU4gQmdLb3N0ZW5hcnQgICAgICAgIEZLQSBPTiBGS0EuQ" +
                        "mdLb3N0ZW5hcnRJRCA9IEtCSy5CZ0tvc3RlbmFydElEDQogIExFRlQgIEpPSU4gdndLcmVkaXRvciAgI" +
                        "CAgICAgIEtSRSBPTiBLUkUuQmFaYWhsdW5nc3dlZ0lEID0gS0JVLkJhWmFobHVuZ3N3ZWdJRA0KV0hFU" +
                        "kUgS0JVLkJnQnVkZ2V0SUQgPSBAQmdCdWRnZXRJRA0KT1JERVIgQlkNCiAgUGF5VG9DbGllbnQgREVTQ" +
                        "ywNCiAgMiwgLyogRW1wZsOkbmdlciAqLw0KICBLQlUuVmFsdXRhRGF0dW0sDQogIEtCSy5CdWNodW5nc" +
                        "3RleHQ=";
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
            this.ReportHeader.Scripts.OnBeforePrint = resources.GetString("ReportHeader.Scripts.OnBeforePrint");
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
            this.Line3.Location = new System.Drawing.Point(367, 0);
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
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BarbelegDatum", "{0:d}")});
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
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ValutaDatum", "{0:d}")});
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
            this.txtKOA.Location = new System.Drawing.Point(367, 0);
            this.txtKOA.Name = "txtKOA";
            this.txtKOA.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKOA.ParentStyleUsing.UseBackColor = false;
            this.txtKOA.ParentStyleUsing.UseBorderColor = false;
            this.txtKOA.ParentStyleUsing.UseBorders = false;
            this.txtKOA.ParentStyleUsing.UseBorderWidth = false;
            this.txtKOA.ParentStyleUsing.UseFont = false;
            this.txtKOA.ParentStyleUsing.UseForeColor = false;
            this.txtKOA.Size = new System.Drawing.Size(68, 18);
            this.txtKOA.Text = "KOA";
            this.txtKOA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // txtBuchungstext
            // 
            this.txtBuchungstext.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Buchungstext", "")});
            this.txtBuchungstext.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBuchungstext.ForeColor = System.Drawing.Color.Black;
            this.txtBuchungstext.Location = new System.Drawing.Point(12, 0);
            this.txtBuchungstext.Name = "txtBuchungstext";
            this.txtBuchungstext.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBuchungstext.ParentStyleUsing.UseBackColor = false;
            this.txtBuchungstext.ParentStyleUsing.UseBorderColor = false;
            this.txtBuchungstext.ParentStyleUsing.UseBorders = false;
            this.txtBuchungstext.ParentStyleUsing.UseBorderWidth = false;
            this.txtBuchungstext.ParentStyleUsing.UseFont = false;
            this.txtBuchungstext.ParentStyleUsing.UseForeColor = false;
            this.txtBuchungstext.Size = new System.Drawing.Size(350, 18);
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
            this.Line8.Location = new System.Drawing.Point(367, 25);
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
            this.Label2.Location = new System.Drawing.Point(367, 25);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(68, 31);
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
            this.Label1.Size = new System.Drawing.Size(350, 31);
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
/*
      WHEN KRE.BaPersonID IN (SELECT BZW.BaPersonID
                              FROM BgFinanzplan_BaPerson  BFP
                                INNER JOIN BaZahlungsweg  BZW ON BZW.BaZahlungswegID = BFP.BaZahlungswegID
                              WHERE BFP.BgFinanzplanID = @BgFinanzplanID
                                AND BFP.IstUnterstuetzt = 1) THEN 1
*/
      ELSE 0
    END,
  Empfänger =
    CASE WHEN KBU.KbAuszahlungsArtCode IN (103, 104)
      THEN ''An Klient''
      ELSE IsNull(KRE.Kreditor, '''')
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
  KBK.Buchungstext' ,  null ,  N'ShUebersichtMonatsbudget' ,  null );
