-- Insert Script for ShMonatsbudgetBruttoprinzip
-- MD5:0X73B317782449F1844F124CDC60735B31_0X0ADF4580439533DD6350CC8EA9813309_0XA7EA22512CCF8E65A9B9134ED6E3D812
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'ShMonatsbudgetBruttoprinzip') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('ShMonatsbudgetBruttoprinzip', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'ShMonatsbudgetBruttoprinzip';
UPDATE QRY
SET QueryName =  N'ShMonatsbudgetBruttoprinzip' , UserText =  N'SH - Monatsbudget Bruttoprinzip' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\KiSS4.DB.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRRichText xrRichText1;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.Subreport ShMonatsbudgetBruttoprinzip_Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel txtOrgPlzOrt;
        private DevExpress.XtraReports.UI.XRLabel txtOrt;
        private DevExpress.XtraReports.UI.XRLabel txtStrasse;
        private DevExpress.XtraReports.UI.XRLabel txtName;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAACAAAAAQAAAIwBRGV2RXhwcmVzc" +
                        "y5YdHJhUmVwb3J0cy5VSS5TZXJpYWxpemFibGVTdHJpbmcsIERldkV4cHJlc3MuWHRyYVJlcG9ydHMud" +
                        "jYuMiwgVmVyc2lvbj02LjIuNi4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPTc5ODY4Y" +
                        "jgxNDdiNWVhZTRQE7ROpIBtm7YAAAAANwAAAK4BAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlA" +
                        "GMAdABTAHQAYQB0AGUAbQBlAG4AdAAAAAAAJngAcgBSAGkAYwBoAFQAZQB4AHQAMQAuAFIAdABmAFQAZ" +
                        "QB4AHQAZAcAAAHhDkRFQ0xBUkUgQEJnQnVkZ2V0SUQgSU5UDQpTRVQgQEJnQnVkZ2V0SUQgPSAyNzIwO" +
                        "TggLS0gbnVsbA0KDQpTRUxFQ1QNCiAgT3JnQWRyZXNzZSA9IE9SRy5UZXh0MSwNCiAgU0FSSW5mbyA9I" +
                        "CdUZWxlZm9uIGRpcmVrdCAnICsgVVNSLlBob25lICsgQ0hBUigxMCkgKyBDSEFSKDEzKSArDQogICAgI" +
                        "CAgICAgICBVU1IuZW1haWwsDQotLSAgT3JnX05hbWUgICAgPSBJc051bGwoQ09OVkVSVCh2YXJjaGFyK" +
                        "DEwMDApLCBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxPcmdhbmlzYXRpb" +
                        "24nLCBHZXREYXRlKCkpKSwgJycpLA0KLS0gIE9yZ19BZHJlc3NlID0gSXNOdWxsKENPTlZFUlQodmFyY" +
                        "2hhcigxMDAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc2VcU296aWFsaGlsZmVcQWRyZXNzZ" +
                        "ScsIEdldERhdGUoKSkpLCAnJyksDQotLSAgT3JnX1BMWiAgICAgPSBJc051bGwoQ09OVkVSVCh2YXJja" +
                        "GFyKDEwMDApLCBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxQTFonLCBHZ" +
                        "XREYXRlKCkpKSwgJycpLA0KLS0gIE9yZ19PcnQgICAgID0gSXNOdWxsKENPTlZFUlQodmFyY2hhcigxM" +
                        "DAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc2VcU296aWFsaGlsZmVcT3J0JywgR2V0RGF0Z" +
                        "SgpKSksICcnKSwNCi0tICBPcmdfUExaT3J0ICA9IElzTnVsbChDT05WRVJUKHZhcmNoYXIoMTAwMCksI" +
                        "GRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlXFBMWicsIEdldERhdGUoKSkpI" +
                        "CsgJyAnLCAnJykNCi0tICAgICAgICAgICAgICArIElzTnVsbChDT05WRVJUKHZhcmNoYXIoMTAwMCksI" +
                        "GRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlXE9ydCcsIEdldERhdGUoKSkpL" +
                        "CAnJyksDQogIEJCRy5CZ0J1ZGdldElELA0KDQogIERhdHVtICAgICAgPSBkYm8uZm5EYXRlU2VyaWFsK" +
                        "EJCRy5KYWhyLCBCQkcuTW9uYXQsIDEpLA0KICBTdGF0dXMgICAgID0gSXNOdWxsKCdNb25hdHNidWRnZ" +
                        "XQgJyArIEJCR19MT1YuVGV4dCwgJz8nKSwNCg0KICBOYW1lICAgICAgID0gUFJTLlZvcm5hbWVOYW1lL" +
                        "A0KICBTdHJhc3NlICAgID0gUFJTLldvaG5zaXR6U3RyYXNzZUhhdXNOciwNCiAgT3J0ICAgICAgICA9I" +
                        "FBSUy5Xb2huc2l0elBMWk9ydA0KLS0gIFp1c3QgICAgICAgPSBJc051bGwoVVNSLkZpcnN0TmFtZSsnI" +
                        "CcsICcnKSArIElzTnVsbChVU1IuTGFzdE5hbWUsICcnKQ0KRlJPTSBCZ0J1ZGdldCAgICAgICAgICAgI" +
                        "CAgQkJHDQogIElOTkVSIEpPSU4gQmdGaW5hbnpwbGFuICBTRlAgb24gU0ZQLkJnRmluYW56cGxhbklEI" +
                        "D0gQkJHLkJnRmluYW56cGxhbklEDQogIElOTkVSIEpPSU4gRmFMZWlzdHVuZyAgICBGQUwgb24gRkFML" +
                        "kZhTGVpc3R1bmdJRCA9IFNGUC5GYUxlaXN0dW5nSUQNCiAgSU5ORVIgSk9JTiB2d1BlcnNvbiAgICAgI" +
                        "FBSUyBvbiBQUlMuQmFQZXJzb25JRCA9IEZBTC5CYVBlcnNvbklEDQogIElOTkVSIEpPSU4gWFVzZXIgI" +
                        "CAgICAgICBVU1Igb24gVVNSLlVzZXJJRCA9IEZBTC5Vc2VySUQNCiAgSU5ORVIgSk9JTiBYT3JnVW5pd" +
                        "F9Vc2VyIE9VVSBPTiBPVVUuVXNlcklEID0gVVNSLlVzZXJJRCBBTkQgT1VVLk9yZ1VuaXRNZW1iZXJDb" +
                        "2RlID0gMg0KICBJTk5FUiBKT0lOIFhPcmdVbml0ICAgICAgT1JHIE9OIE9SRy5PcmdVbml0SUQgPSBPV" +
                        "VUuT3JnVW5pdElEDQogIExFRlQgIEpPSU4gWExPVkNvZGUgIEJCR19MT1Ygb24gQkJHX0xPVi5MT1ZOY" +
                        "W1lID0gJ0JnQmV3aWxsaWd1bmdTdGF0dXMnIEFORCBCQkdfTE9WLkNvZGUgPSBCQkcuQmdCZXdpbGxpZ" +
                        "3VuZ1N0YXR1c0NvZGUNCldIRVJFIEZBTC5Nb2R1bElEID0gMw0KICBBTkQgQkJHLk1vbmF0IElTIE5PV" +
                        "CBOVUxMDQogIEFORCBCQkcuQmdCdWRnZXRJRCA9IEBCZ0J1ZGdldElEQAABAAAA/////wEAAAAAAAAAD" +
                        "AIAAAAbRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy52Ni4yBQEAAAAsRGV2RXhwcmVzcy5YdHJhUmVwb3J0c" +
                        "y5VSS5TZXJpYWxpemFibGVTdHJpbmcBAAAABVZhbHVlAQIAAAAGAwAAAJIBe1xydGYxXGFuc2ljcGcxM" +
                        "jUyDQp7DQpcZm9udHRibA0Ke1xmMCBUaW1lcyBOZXcgUm9tYW47fQ0KfQ0Kew0KXGNvbG9ydGJsDQo7D" +
                        "QpccmVkMFxncmVlbjBcYmx1ZTA7DQp9DQp7XHBhcmRccGxhaW57XGZzMThcY2YxIHhyUmljaFRleHQxf" +
                        "VxwYXJ9DQp9DQoL";
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
            this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
            this.ShMonatsbudgetBruttoprinzip_Detail = new DevExpress.XtraReports.UI.Subreport();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtOrgPlzOrt = new DevExpress.XtraReports.UI.XRLabel();
            this.txtOrt = new DevExpress.XtraReports.UI.XRLabel();
            this.txtStrasse = new DevExpress.XtraReports.UI.XRLabel();
            this.txtName = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrRichText1,
                        this.ShMonatsbudgetBruttoprinzip_Detail,
                        this.xrLabel2,
                        this.txtOrgPlzOrt,
                        this.txtOrt,
                        this.txtStrasse,
                        this.txtName});
            this.Detail.Height = 225;
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
            this.GroupHeader1.Height = 6;
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
            this.GroupFooter1.Height = 40;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorders = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter1.ParentStyleUsing.UseFont = false;
            this.GroupFooter1.ParentStyleUsing.UseForeColor = false;
            this.GroupFooter1.Visible = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 40;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // xrRichText1
            // 
            this.xrRichText1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Rtf", this.sqlQuery1, "OrgAdresse", "")});
            this.xrRichText1.Location = new System.Drawing.Point(8, 8);
            this.xrRichText1.Name = "xrRichText1";
            this.xrRichText1.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichText1.RtfText")));
            this.xrRichText1.Size = new System.Drawing.Size(230, 110);
            // 
            // ShMonatsbudgetBruttoprinzip_Detail
            // 
            this.ShMonatsbudgetBruttoprinzip_Detail.Location = new System.Drawing.Point(8, 192);
            this.ShMonatsbudgetBruttoprinzip_Detail.Name = "ShMonatsbudgetBruttoprinzip_Detail";
            // 
            // xrLabel2
            // 
            this.xrLabel2.CanShrink = true;
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Datum", "Monatsbudget {0:MMMM yyyy}")});
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 14F);
            this.xrLabel2.Location = new System.Drawing.Point(7, 158);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(475, 20);
            this.xrLabel2.Text = "xrLabel2";
            // 
            // txtOrgPlzOrt
            // 
            this.txtOrgPlzOrt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SARInfo", "")});
            this.txtOrgPlzOrt.Font = new System.Drawing.Font("Arial", 10F);
            this.txtOrgPlzOrt.ForeColor = System.Drawing.Color.Black;
            this.txtOrgPlzOrt.Location = new System.Drawing.Point(8, 125);
            this.txtOrgPlzOrt.Multiline = true;
            this.txtOrgPlzOrt.Name = "txtOrgPlzOrt";
            this.txtOrgPlzOrt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOrgPlzOrt.ParentStyleUsing.UseBackColor = false;
            this.txtOrgPlzOrt.ParentStyleUsing.UseBorderColor = false;
            this.txtOrgPlzOrt.ParentStyleUsing.UseBorders = false;
            this.txtOrgPlzOrt.ParentStyleUsing.UseBorderWidth = false;
            this.txtOrgPlzOrt.ParentStyleUsing.UseFont = false;
            this.txtOrgPlzOrt.ParentStyleUsing.UseForeColor = false;
            this.txtOrgPlzOrt.Size = new System.Drawing.Size(230, 15);
            this.txtOrgPlzOrt.Text = "txtOrgPlzOrt";
            // 
            // txtOrt
            // 
            this.txtOrt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Ort", "")});
            this.txtOrt.Font = new System.Drawing.Font("Arial", 10F);
            this.txtOrt.ForeColor = System.Drawing.Color.Black;
            this.txtOrt.Location = new System.Drawing.Point(517, 42);
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
            this.txtStrasse.Location = new System.Drawing.Point(517, 25);
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
            // txtName
            // 
            this.txtName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.txtName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(517, 8);
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
                        this.GroupHeader1,
                        this.GroupFooter1,
                        this.PageFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(39, 28, 80, 40);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).EndInit();
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
</NewDataSet>' , SQLquery =  N'DECLARE @BgBudgetID INT
SET @BgBudgetID = {BgBudgetID}

SELECT
  OrgAdresse = ORG.Text1,
  SARInfo = ''Telefon direkt '' + USR.Phone + CHAR(10) + CHAR(13) +
            USR.email,
  BBG.BgBudgetID,

  Datum      = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1),
  Status     = IsNull(''Monatsbudget '' + BBG_LOV.Text, ''?''),

  Name       = PRS.VornameName,
  Strasse    = PRS.WohnsitzStrasseHausNr,
  Ort        = PRS.WohnsitzPLZOrt
FROM BgBudget              BBG
  INNER JOIN BgFinanzplan  SFP on SFP.BgFinanzplanID = BBG.BgFinanzplanID
  INNER JOIN FaLeistung    FAL on FAL.FaLeistungID = SFP.FaLeistungID
  INNER JOIN vwPerson      PRS on PRS.BaPersonID = FAL.BaPersonID
  INNER JOIN XUser         USR on USR.UserID = FAL.UserID
  INNER JOIN XOrgUnit_User OUU ON OUU.UserID = USR.UserID AND OUU.OrgUnitMemberCode = 2
  INNER JOIN XOrgUnit      ORG ON ORG.OrgUnitID = OUU.OrgUnitID
  LEFT  JOIN XLOVCode  BBG_LOV on BBG_LOV.LOVName = ''BgBewilligungStatus'' AND BBG_LOV.Code = BBG.BgBewilligungStatusCode
WHERE FAL.ModulID = 3
  AND BBG.Monat IS NOT NULL
  AND BBG.BgBudgetID = @BgBudgetID' , ContextForms =  N'WhMonatsbudget,WhMasterbudget' , ParentReportName =  null , ReportSortKey = 6
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'ShMonatsbudgetBruttoprinzip' ;


INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShMonatsbudgetBruttoprinzip_Detail' ,  N'Monatsbudget-Detail' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\KiSS4.DB.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel Betrag1;
        private DevExpress.XtraReports.UI.XRLabel txtBezeichnung;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.GroupHeaderBand grp1H;
        private DevExpress.XtraReports.UI.GroupHeaderBand grp2H;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel txtGrp2Text;
        private DevExpress.XtraReports.UI.GroupFooterBand grp2F;
        private DevExpress.XtraReports.UI.XRLine xrLine7;
        private DevExpress.XtraReports.UI.GroupFooterBand grp1F;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel Grp1Betrag;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRPanel HiddenPanel;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel hiddenLblGroupText;
        private DevExpress.XtraReports.UI.XRLabel hiddenLblShPositionTypID;
        private DevExpress.XtraReports.UI.GroupHeaderBand grp0H;
        private DevExpress.XtraReports.UI.XRLabel txtGrp1Text;
        private DevExpress.XtraReports.UI.GroupFooterBand grp0F;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLine xrLine14;
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
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAACAAAAAAAAAFBBRFBBRFATtE6kz" +
                        "4L1rTsAAAAAAAAANgEAADZnAHIAcAAyAEgALgBTAGMAcgBpAHAAdABzAC4ATwBuAEIAZQBmAG8AcgBlA" +
                        "FAAcgBpAG4AdAAAAAAAMnMAcQBsAFEAdQBlAHIAeQAxAC4AUwBlAGwAZQBjAHQAUwB0AGEAdABlAG0AZ" +
                        "QBuAHQAOQEAAAG2AnByaXZhdGUgdm9pZCBPbkJlZm9yZVByaW50KG9iamVjdCBzZW5kZXIsIFN5c3Rlb" +
                        "S5EcmF3aW5nLlByaW50aW5nLlByaW50RXZlbnRBcmdzIGUpIHsNCiAgIHRyeSB7DQogICAgICAvLyBoa" +
                        "WRlIGdycDIgaWYgZW1wdHkNCiAgICAgIGdycDJILlZpc2libGUgPSBoaWRkZW5MYmxTaFBvc2l0aW9uV" +
                        "HlwSUQuVGV4dCAhPSBzdHJpbmcuRW1wdHk7DQogICB9Y2F0Y2ggKFN5c3RlbS5FeGNlcHRpb24gZXgpI" +
                        "HsNCiAgICAgIFN5c3RlbS5XaW5kb3dzLkZvcm1zLk1lc3NhZ2VCb3guU2hvdyhleC5TdGFja1RyYWNlL" +
                        "CBleC5NZXNzYWdlKTsNCiAgIH0NCn0B44QBREVDTEFSRSBAQmdCdWRnZXRJRCBJTlQNClNFVCBAQmdCd" +
                        "WRnZXRJRCA9IG51bGwNCg0KREVDTEFSRSBAUmVmRGF0ZSAgZGF0ZXRpbWUgIFNFVCBAUmVmRGF0ZSA9I" +
                        "EdldERhdGUoKQ0KDQpERUNMQVJFIEBBbnphaGxQZXJzb25lbiBJTlQNClNFVCBAQW56YWhsUGVyc29uZ" +
                        "W4gPSAoDQogIFNFTEVDVCBjb3VudCgqKQ0KICBGUk9NIEJnRmluYW56cGxhbl9CYVBlcnNvbiAgICBCR" +
                        "kINCiAgICBJTk5FUiBKT0lOIHZ3UGVyc29uICAgICAgICAgUFJTIE9OIFBSUy5CYVBlcnNvbklEID0gQ" +
                        "kZCLkJhUGVyc29uSUQNCiAgICBJTk5FUiBKT0lOIEJnRmluYW56cGxhbiAgICAgQkZQIE9OIEJGUC5CZ" +
                        "0ZpbmFuenBsYW5JRCA9IEJGQi5CZ0ZpbmFuenBsYW5JRA0KICAgIElOTkVSIEpPSU4gRmFMZWlzdHVuZ" +
                        "yAgICAgICBGTEUgT04gRkxFLkZhTGVpc3R1bmdJRCA9IEJGUC5GYUxlaXN0dW5nSUQNCiAgV0hFUkUgQ" +
                        "kZCLkJnRmluYW56cGxhbklEID0gKA0KICAgIFNFTEVDVCBCZ0ZpbmFuenBsYW5JRA0KICAgIEZST00gQ" +
                        "mdCdWRnZXQNCiAgICBXSEVSRSBCZ0J1ZGdldElEID0gQEJnQnVkZ2V0SUQNCiAgICApDQogICkNCg0KD" +
                        "QpERUNMQVJFIEByZXBvcnQgVEFCTEUgKA0KICBBbnphaGxQZXJzb25lbiB2YXJjaGFyKG1heCksIA0KI" +
                        "CBHcnVwcGVDb2RlIGludCwgDQogIERldGFpbENvZGUgaW50LCANCiAgR3J1cHBlIHZhcmNoYXIobWF4K" +
                        "SwgDQogIERldGFpbCB2YXJjaGFyKG1heCksIA0KICBCZ1Bvc2l0aW9uc2FydElEIGludCwgDQogIEJnS" +
                        "2F0ZWdvcmllQ29kZSBpbnQsIA0KICBCZ0thdGVnb3JpZVRleHQgdmFyY2hhcihtYXgpLCANCiAgQmdHc" +
                        "nVwcGVDb2RlIGludCwgDQogIEJnR3J1cHBlVGV4dCB2YXJjaGFyKG1heCksIA0KICBEcml0dGUgYml0L" +
                        "CANCiAgQmV6ZWljaG51bmcgdmFyY2hhcihtYXgpLCANCiAgQmdTcGV6a29udG9JRCBpbnQsIA0KICBCZ" +
                        "XRyYWcgbW9uZXkpDQoNCklOU0VSVCBJTlRPIEByZXBvcnQgKEFuemFobFBlcnNvbmVuLCBHcnVwcGVDb" +
                        "2RlLCBEZXRhaWxDb2RlLCBHcnVwcGUsIERldGFpbCwgQmdLYXRlZ29yaWVDb2RlLCBCZ0thdGVnb3JpZ" +
                        "VRleHQsIEJnR3J1cHBlQ29kZSwgQmdHcnVwcGVUZXh0LCBCZ1Bvc2l0aW9uc2FydElELCBEcml0dGUsI" +
                        "EJnU3BlemtvbnRvSUQsIEJlemVpY2hudW5nLCBCZXRyYWcpDQpTRUxFQ1QNCiAgICBBbnphaGxQZXJzb" +
                        "25lbiA9IENBU0UgV0hFTiBUTVAuQmdLYXRlZ29yaWVDb2RlID0gMiBBTkQgVE1QLkJnR3J1cHBlQ29kZ" +
                        "SA9IDMyMDEgVEhFTiBDT05WRVJUKHZhcmNoYXIoTUFYKSwgQEFuemFobFBlcnNvbmVuKSArICcgUGVyc" +
                        "29uZW4nIEVMU0UgJycgRU5ELA0KDQogICAgR3J1cHBlQ29kZSA9IENBU0UNCiAgICAgIFdIRU4gVE1QL" +
                        "kJnS2F0ZWdvcmllQ29kZSA9IDIgQU5EIA0KICAgICAgICBUTVAuQmdHcnVwcGVDb2RlIElOICgzMjAxL" +
                        "CAgICAgIC0tIEdydW5kYmVkYXJmDQogICAgICAgICAgMzkzMDAsICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgLS0gTUlaDQogICAgICAgICAgMzkyMDAsIDM5MjEwLCAzOTIyMCwgMzkyMzAsICAgLS0gSVpVDQogI" +
                        "CAgICAgICAgMzkxMDAsIDM5MTEwLCAzOTEyMCwgMzkxMzAsICAgLS0gRUZCDQogICAgICAgICAgMzIwM" +
                        "yAgICAgICAgICAgICAgICAgICAgICAgICAgLS0gRXJ3ZXJic3Vua29zdGVuDQogICAgICAgICkgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBUSEVOIDEgLS0gTGViZ" +
                        "W5zdW50ZXJoYWx0DQogICAgICBXSEVOIFRNUC5CZ0thdGVnb3JpZUNvZGUgPSAyIEFORCANCiAgICAgI" +
                        "CAgVE1QLkJnR3J1cHBlQ29kZSA9IDMyMDYgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFRIRU4gM" +
                        "iAtLSBXb2hua29zdGVuDQogICAgICBXSEVOIFRNUC5CZ0thdGVnb3JpZUNvZGUgPSAyIEFORCANCiAgI" +
                        "CAgICAgVE1QLkJnR3J1cHBlQ29kZSBJTiAoMzIwMiwgMzkwNCwgMzkwMywgMzkwMiwgMzkwMSkgIFRIR" +
                        "U4gMyAtLSBNZWQuIEdydW5kdmVyc29yZ3VuZw0KICAgICAgV0hFTiBUTVAuQmdLYXRlZ29yaWVDb2RlI" +
                        "ElOICgxMDAsIDEwMSkgICAgICAgICAgICAgICAgVEhFTiA0IC0tIFp1c8OkdHpsaWNoZSBMZWlzdHVuZ" +
                        "2VuL0VpbnplbHphaGx1bmdlbg0KICAgICAgV0hFTiBUTVAuQmdHcnVwcGVDb2RlIElOICgzMTAxLCAzM" +
                        "TAyLCAzMTAzLCAzMTA0KSBUSEVOIDExIC0tIEVpbm5haG1lbg0KICAgICAgV0hFTiBUTVAuQmdLYXRlZ" +
                        "29yaWVDb2RlIElOICg2LCAzLCA0KSBUSEVOIDEyIC0tIERpcmVrdHphaGx1bmdlbiwgQWJ6w7xnZQ0KI" +
                        "CAgICAgRUxTRSAwDQogICAgRU5ELA0KDQogICAgRGV0YWlsQ29kZSA9IENBU0UNCiAgICAgIC0tIExlY" +
                        "mVuc3VudGVyaGFsdA0KICAgICAgV0hFTiBUTVAuQmdLYXRlZ29yaWVDb2RlID0gMiBBTkQgVE1QLkJnR" +
                        "3J1cHBlQ29kZSA9IDMyMDEgICAgICAgICAgICAgICAgICAgICAgICAgIFRIRU4gMSAgLS0gR3J1bmRiZ" +
                        "WRhcmYNCiAgICAgIFdIRU4gVE1QLkJnS2F0ZWdvcmllQ29kZSA9IDIgQU5EIFRNUC5CZ0dydXBwZUNvZ" +
                        "GUgPSAzOTMwMCAgICAgICAgICAgICAgICAgICAgICAgICBUSEVOIDIgIC0tIE1JWg0KICAgICAgV0hFT" +
                        "iBUTVAuQmdLYXRlZ29yaWVDb2RlID0gMiBBTkQgVE1QLkJnR3J1cHBlQ29kZSBJTiAoMzkyMDAsIDM5M" +
                        "jEwLCAzOTIyMCwgMzkyMzApIFRIRU4gMyAgLS0gSVpVDQogICAgICBXSEVOIFRNUC5CZ0thdGVnb3JpZ" +
                        "UNvZGUgPSAyIEFORCBUTVAuQmdHcnVwcGVDb2RlIElOICgzOTEwMCwgMzkxMTAsIDM5MTIwLCAzOTEzM" +
                        "CkgVEhFTiA0ICAtLSBFRkINCiAgICAgIFdIRU4gVE1QLkJnS2F0ZWdvcmllQ29kZSA9IDIgQU5EIFRNU" +
                        "C5CZ0dydXBwZUNvZGUgPSAzMjAzICAgICAgICAgICAgICAgICAgICAgICAgICBUSEVOIDUgIC0tIEVyd" +
                        "2VyYnN1bmtvc3Rlbg0KICAgICAgV0hFTiBUTVAuQmdLYXRlZ29yaWVDb2RlID0gMiBBTkQgVE1QLkJnU" +
                        "G9zaXRpb25zYXJ0SUQgPSAzMjAxOSAgICAgICAgICAgICAgICAgICAgIFRIRU4gNiAgLS0gTmViZW5rb" +
                        "3N0ZW4gaW4gc3RhdGlvbsOkcmVuIEVpbnJpY2h0dW5nZW4NCiAgICAgIC0tIFdvaG5rb3N0ZW4NCiAgI" +
                        "CAgIFdIRU4gVE1QLkJnS2F0ZWdvcmllQ29kZSA9IDIgQU5EIFRNUC5CZ0dydXBwZUNvZGUgPSAzMjA2I" +
                        "EFORCBUTVAuQmdQb3NpdGlvbnNhcnRJRCAhPSAzMjA2MCBUSEVOIDEgIC0tIE1pZXRlDQogICAgICBXS" +
                        "EVOIFRNUC5CZ0thdGVnb3JpZUNvZGUgPSAyIEFORCBUTVAuQmdHcnVwcGVDb2RlID0gMzIwNiBBTkQgV" +
                        "E1QLkJnUG9zaXRpb25zYXJ0SUQgPSAzMjA2MCAgVEhFTiAyICAtLSBNaWV0bmViZW5rb3N0ZW4NCiAgI" +
                        "CAgIC0tIE1lZC4gR3J1bmR2ZXJzb3JndW5nDQogICAgICBXSEVOIFRNUC5CZ0thdGVnb3JpZUNvZGUgP" +
                        "SAyIEFORCBUTVAuQmdQb3NpdGlvbnNhcnRJRCBJTiAoMzIwMjAsIDMyMDIzLCAzMjAyNCkgVEhFTiAxI" +
                        "CAtLSBLcmFua2VudmVyc2ljaGVydW5nIChLVkcpDQogICAgICBXSEVOIFRNUC5CZ0thdGVnb3JpZUNvZ" +
                        "GUgPSAyIEFORCBUTVAuQmdQb3NpdGlvbnNhcnRJRCBCRVRXRUVOIDMyMTIxIEFORCAzMjEyOSAgVEhFT" +
                        "iAxICAtLSBLcmFua2VudmVyc2ljaGVydW5nIChLVkcpDQogICAgICBXSEVOIFRNUC5CZ0thdGVnb3JpZ" +
                        "UNvZGUgPSAyIEFORCBUTVAuQmdQb3NpdGlvbnNhcnRJRCBJTiAoMzIwMjEsIDMyMDIyKSAgICAgICAgV" +
                        "EhFTiAyICAtLSBLcmFua2VudmVyc2ljaGVydW5nIChWVkcpDQogICAgICBXSEVOIFRNUC5CZ0thdGVnb" +
                        "3JpZUNvZGUgPSAyIEFORCBUTVAuQmdHcnVwcGVDb2RlID0gMzkwNCAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgVEhFTiAzICAtLSBXaWVkZXJlaW5nbGllZGVydW5nDQogICAgICBXSEVOIFRNUC5CZ0thdGVnb3JpZ" +
                        "UNvZGUgPSAyIEFORCBUTVAuQmdHcnVwcGVDb2RlID0gMzkwMyAgICAgICAgICAgICAgICAgICAgICAgV" +
                        "EhFTiA0ICAtLSBMZWlzdHVuZ2VuIGbDvHIgVGhlcmFwaWUgdW5kIEVudHp1Z3NtYXNzbmFobWVuDQogI" +
                        "CAgICBXSEVOIFRNUC5CZ0thdGVnb3JpZUNvZGUgPSAyIEFORCBUTVAuQmdHcnVwcGVDb2RlID0gMzkwM" +
                        "iAgICAgICAgICAgICAgICAgICAgICAgVEhFTiA1ICAtLSBLcmFua2hlaXRzLSB1bmQgYmVoaW5kZXJ1b" +
                        "mdzYmVkaW5ndGUgS29zdGVuDQogICAgICBXSEVOIFRNUC5CZ0thdGVnb3JpZUNvZGUgPSAyIEFORCBUT" +
                        "VAuQmdHcnVwcGVDb2RlID0gMzkwMSAgICAgICAgICAgICAgICAgICAgICAgVEhFTiA2ICAtLSBTaXR1Y" +
                        "XRpb25zYmVkaW5ndGUgTGVpc3R1bmdlbg0KICAgICAgLS0gWnVzw6R0emxpY2hlIExlaXN0dW5nZW4vR" +
                        "WluemVsemFobHVuZ2VuDQogICAgICBXSEVOIFRNUC5CZ0thdGVnb3JpZUNvZGUgSU4gKDEwMCwgMTAxK" +
                        "SBUSEVOIDENCiAgICAgIC0tIEVpbm5haG1lbg0KICAgICAgV0hFTiBUTVAuQmdHcnVwcGVDb2RlID0gM" +
                        "zEwMSAgICAgICAgICAgICAgICAgICAgICAgICAgVEhFTiAxICAtLSBFcndlcmJzdW5rb3N0ZW4NCiAgI" +
                        "CAgIFdIRU4gVE1QLkJnR3J1cHBlQ29kZSA9IDMxMDIgICAgICAgICAgICAgICAgICAgICAgICAgIFRIR" +
                        "U4gMiAgLS0gQWxpbWVudGd1dGhhYmVuDQogICAgICBXSEVOIFRNUC5CZ0dydXBwZUNvZGUgPSAzMTAzI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICBUSEVOIDMgIC0tIEVpbmtvbW1lbiBhdXMgVmVyc2ljaGVyd" +
                        "W5nc2xlaXN0dW5nZW4NCiAgICAgIFdIRU4gVE1QLkJnR3J1cHBlQ29kZSA9IDMxMDQgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgIFRIRU4gNCAgLS0gVmVybcO2Z2VuLSB1bmQgVmVybcO2Z2Vuc3ZlcmJyYXVja" +
                        "A0KICAgICAgLS0gRGlyZWt0emFobHVuZ2VuLCBBYnrDvGdlDQogICAgICAgIC0tIERpcmVrdHphaGx1b" +
                        "mdlbiBhbiBEcml0dGU6IERldGFpbENvZGUgMQ0KICAgICAgV0hFTiBUTVAuQmdLYXRlZ29yaWVDb2RlI" +
                        "D0gNiAgICAgICAgICAgICAgICAgICAgICAgICAgVEhFTiAyICAtLSBWb3JhYnp1Z3Nrb250bw0KICAgI" +
                        "CAgV0hFTiBUTVAuQmdLYXRlZ29yaWVDb2RlID0gMyAgICAgICAgICAgICAgICAgICAgICAgICAgVEhFT" +
                        "iAzICAtLSBBYnphaGx1bmdza29udG8NCiAgICAgIFdIRU4gVE1QLkJnS2F0ZWdvcmllQ29kZSA9IDQgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgIFRIRU4gNCAgLS0gS8O8cnp1bmdlbg0KICAgICAgRUxTRSAwD" +
                        "QogICAgRU5ELA0KDQogICAgR3J1cHBlID0gQ0FTRQ0KICAgICAgV0hFTiBUTVAuQmdLYXRlZ29yaWVDb" +
                        "2RlID0gMiBBTkQgDQogICAgICAgIFRNUC5CZ0dydXBwZUNvZGUgSU4gKDMyMDEsIC0tIEdydW5kYmVkY" +
                        "XJmDQogICAgICAgICAgMzkzMDAsICAgICAgICAgICAgICAgICAgICAgICAgLS0gTUlaDQogICAgICAgI" +
                        "CAgMzkyMDAsIDM5MjEwLCAzOTIyMCwgMzkyMzAsICAgLS0gSVpVDQogICAgICAgICAgMzkxMDAsIDM5M" +
                        "TEwLCAzOTEyMCwgMzkxMzAsICAgLS0gRUZCDQogICAgICAgICAgMzIwMyAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgLS0gRXJ3ZXJic3Vua29zdGVuDQogICAgICAgICkgVEhFTiAnTGViZW5zdW50ZXJoYWx0J" +
                        "w0KICAgICAgV0hFTiBUTVAuQmdLYXRlZ29yaWVDb2RlID0gMiBBTkQgVE1QLkJnR3J1cHBlQ29kZSA9I" +
                        "DMyMDYgVEhFTiBkYm8uZm5MT1ZUZXh0KCdCZ0dydXBwZScsIFRNUC5CZ0dydXBwZUNvZGUpDQogICAgI" +
                        "CBXSEVOIFRNUC5CZ0thdGVnb3JpZUNvZGUgPSAyIEFORCBUTVAuQmdHcnVwcGVDb2RlIElOICgzMjAyL" +
                        "CAzOTA0LCAzOTAzLCAzOTAyLCAzOTAxKSBUSEVOIGRiby5mbkxPVlRleHQoJ0JnR3J1cHBlJywgVE1QL" +
                        "kJnR3J1cHBlQ29kZSkNCiAgICAgIFdIRU4gVE1QLkJnS2F0ZWdvcmllQ29kZSBJTiAoMTAwLCAxMDEpI" +
                        "CAgICAgICAgICAgICAgICAgVEhFTiAnJyAtLSBadXPDpHR6bGljaGUgTGVpc3R1bmdlbi9FaW56ZWx6Y" +
                        "WhsdW5nZW4NCiAgICAgIFdIRU4gVE1QLkJnR3J1cHBlQ29kZSBJTiAoMzEwMSwgMzEwMiwgMzEwMywgM" +
                        "zEwNCkgVEhFTiAnJyAtLSBFaW5uYWhtZW4NCiAgICAgIFdIRU4gVE1QLkJnS2F0ZWdvcmllQ29kZSBJT" +
                        "iAoNiwgMywgNCkgVEhFTiAnRGlyZWt0emFobHVuZ2VuLCBBYnrDvGdlJyAtLSBEaXJla3R6YWhsdW5nZ" +
                        "W4sIEFiesO8Z2UNCiAgICAgIEVMU0UgJycNCiAgICBFTkQsDQoNCiAgICBEZXRhaWwgPSBDQVNFDQogI" +
                        "CAgICAtLSBMZWJlbnN1bnRlcmhhbHQNCiAgICAgIFdIRU4gVE1QLkJnS2F0ZWdvcmllQ29kZSA9IDIgQ" +
                        "U5EIFRNUC5CZ0dydXBwZUNvZGUgPSAzMjAxIFRIRU4gZGJvLmZuTE9WVGV4dCgnQmdHcnVwcGUnLCBUT" +
                        "VAuQmdHcnVwcGVDb2RlKQ0KICAgICAgV0hFTiBUTVAuQmdLYXRlZ29yaWVDb2RlID0gMiBBTkQgVE1QL" +
                        "kJnR3J1cHBlQ29kZSA9IDM5MzAwIFRIRU4gZGJvLmZuTE9WVGV4dCgnQmdHcnVwcGUnLCBUTVAuQmdHc" +
                        "nVwcGVDb2RlKQ0KICAgICAgV0hFTiBUTVAuQmdLYXRlZ29yaWVDb2RlID0gMiBBTkQgVE1QLkJnR3J1c" +
                        "HBlQ29kZSBJTiAoMzkyMDAsIDM5MjEwLCAzOTIyMCwgMzkyMzApIFRIRU4gJ0laVScNCiAgICAgIFdIR" +
                        "U4gVE1QLkJnS2F0ZWdvcmllQ29kZSA9IDIgQU5EIFRNUC5CZ0dydXBwZUNvZGUgSU4gKDM5MTAwLCAzO" +
                        "TExMCwgMzkxMjAsIDM5MTMwKSBUSEVOICdFRkInDQogICAgICBXSEVOIFRNUC5CZ0thdGVnb3JpZUNvZ" +
                        "GUgPSAyIEFORCBUTVAuQmdHcnVwcGVDb2RlID0gMzIwMyBUSEVOICBkYm8uZm5MT1ZUZXh0KCdCZ0dyd" +
                        "XBwZScsIFRNUC5CZ0dydXBwZUNvZGUpDQogICAgICBXSEVOIFRNUC5CZ0thdGVnb3JpZUNvZGUgPSAyI" +
                        "EFORCBUTVAuQmdQb3NpdGlvbnNhcnRJRCA9IDMyMDE5IFRIRU4gJ05lYmVua29zdGVuIGluIHN0YXRpb" +
                        "27DpHJlbiBFaW5yaWNodHVuZ2VuJw0KICAgICAgLS0gV29obmtvc3Rlbg0KICAgICAgV0hFTiBUTVAuQ" +
                        "mdLYXRlZ29yaWVDb2RlID0gMiBBTkQgVE1QLkJnR3J1cHBlQ29kZSA9IDMyMDYgQU5EIFRNUC5CZ1Bvc" +
                        "2l0aW9uc2FydElEICE9IDMyMDYwIFRIRU4gJ01pZXRlJw0KICAgICAgV0hFTiBUTVAuQmdLYXRlZ29ya" +
                        "WVDb2RlID0gMiBBTkQgVE1QLkJnR3J1cHBlQ29kZSA9IDMyMDYgQU5EIFRNUC5CZ1Bvc2l0aW9uc2Fyd" +
                        "ElEID0gMzIwNjAgVEhFTiAnTWlldG5lYmVua29zdGVuJw0KICAgICAgLS0gTWVkLiBHcnVuZHZlcnNvc" +
                        "md1bmcNCiAgICAgIFdIRU4gVE1QLkJnS2F0ZWdvcmllQ29kZSA9IDIgQU5EIFRNUC5CZ1Bvc2l0aW9uc" +
                        "2FydElEIElOICgzMjAyMCwgMzIwMjMsIDMyMDI0KSBUSEVOICdLcmFua2VudmVyc2ljaGVydW5nIChLV" +
                        "kcpJw0KICAgICAgV0hFTiBUTVAuQmdLYXRlZ29yaWVDb2RlID0gMiBBTkQgVE1QLkJnUG9zaXRpb25zY" +
                        "XJ0SUQgQkVUV0VFTiAzMjEyMSBBTkQgMzIxMjkgIFRIRU4gJ0tyYW5rZW52ZXJzaWNoZXJ1bmcgKEtWR" +
                        "yknDQogICAgICBXSEVOIFRNUC5CZ0thdGVnb3JpZUNvZGUgPSAyIEFORCBUTVAuQmdQb3NpdGlvbnNhc" +
                        "nRJRCBJTiAoMzIwMjEsIDMyMDIyKSBUSEVOICdLcmFua2VudmVyc2ljaGVydW5nIChWVkcpJw0KICAgI" +
                        "CAgV0hFTiBUTVAuQmdLYXRlZ29yaWVDb2RlID0gMiBBTkQgVE1QLkJnR3J1cHBlQ29kZSBJTiAoMzkwN" +
                        "CwgMzkwMywgMzkwMiwgMzkwMSkgVEhFTiAgZGJvLmZuTE9WVGV4dCgnQmdHcnVwcGUnLCBUTVAuQmdHc" +
                        "nVwcGVDb2RlKQ0KICAgICAgV0hFTiBUTVAuQmdLYXRlZ29yaWVDb2RlIElOICgxMDAsIDEwMSkgVEhFT" +
                        "iAnWnVzw6R0emxpY2hlIExlaXN0dW5nZW4vRWluemVsemFobHVuZ2VuJw0KICAgICAgLS0gRWlubmFob" +
                        "WVuDQogICAgICBXSEVOIFRNUC5CZ0dydXBwZUNvZGUgPSAzMTAxICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICBUSEVOICdFcndlcmJzdW5rb3N0ZW4nDQogICAgICBXSEVOIFRNUC5CZ0dydXBwZUNvZGUgPSAzM" +
                        "TAyICAgICAgICAgICAgICAgICAgICAgICAgICBUSEVOICdBbGltZW50Z3V0aGFiZW4nDQogICAgICBXS" +
                        "EVOIFRNUC5CZ0dydXBwZUNvZGUgPSAzMTAzICAgICAgICAgICAgICAgICAgICAgICAgICBUSEVOICdFa" +
                        "W5rb21tZW4gYXVzIFZlcnNpY2hlcnVuZ3NsZWlzdHVuZ2VuJw0KICAgICAgV0hFTiBUTVAuQmdHcnVwc" +
                        "GVDb2RlID0gMzEwNCAgICAgICAgICAgICAgICAgICAgICAgICAgVEhFTiAnVmVybcO2Z2VuLSB1bmQgV" +
                        "mVybcO2Z2Vuc3ZlcmJyYXVjaCcNCiAgICAgIC0tIERpcmVrdHphaGx1bmdlbiwgQWJ6w7xnZQ0KICAgI" +
                        "CAgV0hFTiBUTVAuQmdLYXRlZ29yaWVDb2RlID0gNiAgICAgICAgICAgICAgICAgICAgICAgICAgVEhFT" +
                        "iAnVm9yYWJ6dWdza29udG8nDQogICAgICBXSEVOIFRNUC5CZ0thdGVnb3JpZUNvZGUgPSAzICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICBUSEVOICdBYnphaGx1bmdza29udG8nDQogICAgICBXSEVOIFRNUC5CZ" +
                        "0thdGVnb3JpZUNvZGUgPSA0ICAgICAgICAgICAgICAgICAgICAgICAgICBUSEVOICdLw7xyenVuZ2VuJ" +
                        "w0KICAgICAgRUxTRSBUTVAuQmV6ZWljaG51bmcNCiAgICBFTkQsDQoNCiAgVE1QLkJnS2F0ZWdvcmllQ" +
                        "29kZSwgDQogIEJnS2F0ZWdvcmllVGV4dCA9IENBU0UgDQogICAgV0hFTiBUTVAuQmdLYXRlZ29yaWVDb" +
                        "2RlIElOICgxLCA2LCAzLCA0KSBUSEVOIGRiby5mbkxPVlRleHQoJ0JnS2F0ZWdvcmllJywgMSkNCiAgI" +
                        "CBXSEVOIFRNUC5CZ0thdGVnb3JpZUNvZGUgSU4gKDIsIDEwMCwgMTAxKSBUSEVOIGRiby5mbkxPVlRle" +
                        "HQoJ0JnS2F0ZWdvcmllJywgMikNCiAgRU5ELA0KICBUTVAuQmdHcnVwcGVDb2RlLCANCiAgQmdHcnVwc" +
                        "GVUZXh0ID0gU1BDLlRleHQsDQogIFRNUC5CZ1Bvc2l0aW9uc2FydElELA0KICBUTVAuRHJpdHRlLA0KI" +
                        "CBUTVAuQmdTcGV6a29udG9JRCwNCiAgQmV6ZWljaG51bmcgPSBMVHJpbShUTVAuQmV6ZWljaG51bmcpL" +
                        "CANCiAgVE1QLkJldHJhZw0KRlJPTSBkYm8uZm5XaEdldEJ1ZGdldChAQmdCdWRnZXRJRCwgQFJlZkRhd" +
                        "GUpICBUTVANCiAgTEVGVCAgSk9JTiBYTE9WQ29kZSAgICAgICAgQlBDIE9OIEJQQy5MT1ZOYW1lID0gJ" +
                        "0JnS2F0ZWdvcmllJyBBTkQgQlBDLkNvZGUgPSBUTVAuQmdLYXRlZ29yaWVDb2RlDQogIExFRlQgIEpPS" +
                        "U4gWExPVkNvZGUgICAgICAgIFNQQyBPTiBTUEMuTE9WTmFtZSA9ICdCZ0dydXBwZScgQU5EIFNQQy5Db" +
                        "2RlID0gVE1QLkJnR3J1cHBlQ29kZQ0KICBMRUZUICBKT0lOIEJnUG9zaXRpb25zYXJ0ICBTUFQgT04gU" +
                        "1BULkJnUG9zaXRpb25zYXJ0SUQgPSBUTVAuQmdQb3NpdGlvbnNhcnRJRA0KICBMRUZUICBKT0lOIEJnU" +
                        "3BlemtvbnRvICAgICBTUEsgT04gU1BLLkJnU3BlemtvbnRvSUQgPSBUTVAuQmdTcGV6a29udG9JRA0KV" +
                        "0hFUkUgVE1QLkJnUG9zaXRpb25JRCBJUyBOT1QgTlVMTA0KDQoNCi0tIERpcmVrdHphaGx1bmdlbiBhb" +
                        "iBEcml0dGUNCkRFQ0xBUkUgQEJnRmluYW56cGxhbklEIElOVA0KU0VMRUNUIEBCZ0ZpbmFuenBsYW5JR" +
                        "CA9IEJCRy5CZ0ZpbmFuenBsYW5JRA0KRlJPTSAgIEJnQnVkZ2V0IEJCRw0KV0hFUkUgIEJCRy5CZ0J1Z" +
                        "GdldElEID0gQEJnQnVkZ2V0SUQNCg0KREVDTEFSRSBAQmV0cmFnRHJpdHRlIElOVA0KDQpTRUxFQ1QgQ" +
                        "EJldHJhZ0RyaXR0ZSA9IFNVTShCZXRyYWcpDQpGUk9NICAgdndCZ1Bvc2l0aW9uIEJQTw0KICAgICAgI" +
                        "ExFRlQgIEpPSU4gQmdBdXN6YWhsdW5nUGVyc29uICAgICAgIEJBUCAgT04gQkFQLkJnUG9zaXRpb25JR" +
                        "CA9IEJQTy5CZ1Bvc2l0aW9uSUQgQU5EDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICBCQVAuQmdBdXN6YWhsdW5nUGVyc29uSUQgPSAoU0VMRUNUIFRPUCAxIEJnQ" +
                        "XVzemFobHVuZ1BlcnNvbklEDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPTSAgIEJnQXVzemFobHVuZ1Blc" +
                        "nNvbg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgIFdIRVJFICBCZ1Bvc2l0aW9uSUQgPSBCUE8uQmdQb3NpdGlvb" +
                        "klEDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgT1JERVIgQlkgDQogICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBDQVNFI" +
                        "FdIRU4gQmFQZXJzb25JRCBJUyBOVUxMIFRIRU4gMQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXS" +
                        "EVOIEJhUGVyc29uSUQgPSBCUE8uQmFQZXJzb25JRCBUSEVOIDINCiAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgRUxTRSAzDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTkQpDQogICAgICAgTEVGVCAgSk9JTiB2d" +
                        "0tyZWRpdG9yICAgICAgICAgICAgICAgS1JFICBPTiBLUkUuQmFaYWhsdW5nc3dlZ0lEID0gQkFQLkJhW" +
                        "mFobHVuZ3N3ZWdJRA0KV0hFUkUgIEJQTy5CZ0J1ZGdldElEID0gQEJnQnVkZ2V0SUQNCiAgQU5EIChDQ" +
                        "VNFDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgV0hFTiBLUkUuQmFaYWhsdW5nc3dlZ0lEIElTI" +
                        "E5VTEwgICAgICAgICBUSEVOIDANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVOIEVYSVNUU" +
                        "yAoU0VMRUNUICoNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRlJPTSBCZ" +
                        "0ZpbmFuenBsYW5fQmFQZXJzb24NCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgV0hFUkUgQmFQZXJzb25JRCA9IEtSRS5CYVBlcnNvbklEDQogICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgQU5EIEJnRmluYW56cGxhbklEID0gQEJnRmluYW56cGxhbklEDQogI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIElzdFVudGVyc3R1ZXR6d" +
                        "CA9IDEpICBUSEVOIDANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICBFTFNFIDENCiAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgRU5EKSA9IDENCg0KSU5TRVJUIElOVE8gQHJlcG9ydCAoQW56YWhsUGVyc" +
                        "29uZW4sIEdydXBwZUNvZGUsIERldGFpbENvZGUsIEdydXBwZSwgRGV0YWlsLCBCZ0thdGVnb3JpZUNvZ" +
                        "GUsIEJnS2F0ZWdvcmllVGV4dCwgQmV0cmFnKQ0KVkFMVUVTICgnJywgMTIsIDEsICdEaXJla3R6YWhsd" +
                        "W5nZW4sIEFiesO8Z2UnLCAnRGlyZWt0emFobHVuZ2VuIGFuIERyaXR0ZScsIDEsICdFSU5OQUhNRU4nL" +
                        "CBAQmV0cmFnRHJpdHRlKQ0KDQotLSBFaW5uYWhtZW4tR3J1cHBlIGhpbnp1ZsO8Z2VuIGRhc3MgZXMga" +
                        "W1tZXIgZ2xlaWNoIGlzdA0KSU5TRVJUIElOVE8gQHJlcG9ydCAoQW56YWhsUGVyc29uZW4sIEdydXBwZ" +
                        "UNvZGUsIERldGFpbENvZGUsIEdydXBwZSwgRGV0YWlsLCBCZ0thdGVnb3JpZUNvZGUsIEJnS2F0ZWdvc" +
                        "mllVGV4dCwgQmV0cmFnKQ0KVkFMVUVTICgnJywgMTEsIDEsICcnLCBkYm8uZm5MT1ZUZXh0KCdCZ0dyd" +
                        "XBwZScsIDMxMDEpLCAxLCAnRUlOTkFITUVOJywgMCkNCg0KSU5TRVJUIElOVE8gQHJlcG9ydCAoQW56Y" +
                        "WhsUGVyc29uZW4sIEdydXBwZUNvZGUsIERldGFpbENvZGUsIEdydXBwZSwgRGV0YWlsLCBCZ0thdGVnb" +
                        "3JpZUNvZGUsIEJnS2F0ZWdvcmllVGV4dCwgQmV0cmFnKQ0KVkFMVUVTICgnJywgMTEsIDIsICcnLCBkY" +
                        "m8uZm5MT1ZUZXh0KCdCZ0dydXBwZScsIDMxMDIpLCAxLCAnRUlOTkFITUVOJywgMCkNCg0KSU5TRVJUI" +
                        "ElOVE8gQHJlcG9ydCAoQW56YWhsUGVyc29uZW4sIEdydXBwZUNvZGUsIERldGFpbENvZGUsIEdydXBwZ" +
                        "SwgRGV0YWlsLCBCZ0thdGVnb3JpZUNvZGUsIEJnS2F0ZWdvcmllVGV4dCwgQmV0cmFnKQ0KVkFMVUVTI" +
                        "CgnJywgMTEsIDMsICcnLCBkYm8uZm5MT1ZUZXh0KCdCZ0dydXBwZScsIDMxMDMpLCAxLCAnRUlOTkFIT" +
                        "UVOJywgMCkNCg0KSU5TRVJUIElOVE8gQHJlcG9ydCAoQW56YWhsUGVyc29uZW4sIEdydXBwZUNvZGUsI" +
                        "ERldGFpbENvZGUsIEdydXBwZSwgRGV0YWlsLCBCZ0thdGVnb3JpZUNvZGUsIEJnS2F0ZWdvcmllVGV4d" +
                        "CwgQmV0cmFnKQ0KVkFMVUVTICgnJywgMTEsIDQsICcnLCBkYm8uZm5MT1ZUZXh0KCdCZ0dydXBwZScsI" +
                        "DMxMDQpLCAxLCAnRUlOTkFITUVOJywgMCkNCg0KSU5TRVJUIElOVE8gQHJlcG9ydCAoQW56YWhsUGVyc" +
                        "29uZW4sIEdydXBwZUNvZGUsIERldGFpbENvZGUsIEdydXBwZSwgRGV0YWlsLCBCZ0thdGVnb3JpZUNvZ" +
                        "GUsIEJnS2F0ZWdvcmllVGV4dCwgQmV0cmFnKQ0KVkFMVUVTICgnJywgMTIsIDEsICdEaXJla3R6YWhsd" +
                        "W5nZW4sIEFiesO8Z2UnLCAnRGlyZWt0emFobHVuZ2VuIGFuIERyaXR0ZScsIDEsICdFSU5OQUhNRU4nL" +
                        "CAwKQ0KDQpJTlNFUlQgSU5UTyBAcmVwb3J0IChBbnphaGxQZXJzb25lbiwgR3J1cHBlQ29kZSwgRGV0Y" +
                        "WlsQ29kZSwgR3J1cHBlLCBEZXRhaWwsIEJnS2F0ZWdvcmllQ29kZSwgQmdLYXRlZ29yaWVUZXh0LCBCZ" +
                        "XRyYWcpDQpWQUxVRVMgKCcnLCAxMiwgMiwgJ0RpcmVrdHphaGx1bmdlbiwgQWJ6w7xnZScsICdWb3JhY" +
                        "np1Z3Nrb250bycsIDYsICdFSU5OQUhNRU4nLCAwKQ0KDQpJTlNFUlQgSU5UTyBAcmVwb3J0IChBbnpha" +
                        "GxQZXJzb25lbiwgR3J1cHBlQ29kZSwgRGV0YWlsQ29kZSwgR3J1cHBlLCBEZXRhaWwsIEJnS2F0ZWdvc" +
                        "mllQ29kZSwgQmdLYXRlZ29yaWVUZXh0LCBCZXRyYWcpDQpWQUxVRVMgKCcnLCAxMiwgMywgJ0RpcmVrd" +
                        "HphaGx1bmdlbiwgQWJ6w7xnZScsICdBYnphaGx1bmdza29udG8nLCAzLCAnRUlOTkFITUVOJywgMCkNC" +
                        "g0KSU5TRVJUIElOVE8gQHJlcG9ydCAoQW56YWhsUGVyc29uZW4sIEdydXBwZUNvZGUsIERldGFpbENvZ" +
                        "GUsIEdydXBwZSwgRGV0YWlsLCBCZ0thdGVnb3JpZUNvZGUsIEJnS2F0ZWdvcmllVGV4dCwgQmV0cmFnK" +
                        "Q0KVkFMVUVTICgnJywgMTIsIDQsICdEaXJla3R6YWhsdW5nZW4sIEFiesO8Z2UnLCAnS8O8cnp1bmdlb" +
                        "icsIDQsICdFSU5OQUhNRU4nLCAwKQ0KDQotLSBBdXNnYWJlbi1HcnVwcGUgaGluenVmw7xnZW4gZGFzc" +
                        "yBlcyBpbW1lciBnbGVpY2ggaXN0DQpJRiBOT1QgRVhJU1RTKFNFTEVDVCBUT1AgMSAxIEZST00gQHJlc" +
                        "G9ydCBXSEVSRSBHcnVwcGVDb2RlID0gMSBBTkQgRGV0YWlsQ29kZSA9IDEpIEJFR0lODQogIElOU0VSV" +
                        "CBJTlRPIEByZXBvcnQgKEFuemFobFBlcnNvbmVuLCBHcnVwcGVDb2RlLCBEZXRhaWxDb2RlLCBHcnVwc" +
                        "GUsIERldGFpbCwgQmdLYXRlZ29yaWVDb2RlLCBCZ0thdGVnb3JpZVRleHQsIEJldHJhZykNCiAgVkFMV" +
                        "UVTICgnMCBQZXJzb25lbicsIDEsIDEsICdMZWJlbnN1bnRlcmhhbHQnLCBkYm8uZm5MT1ZUZXh0KCdCZ" +
                        "0dydXBwZScsIDMyMDEpLCAyLCAnQXVzZ2FiZW4nLCAwKQ0KRU5EDQoNCklOU0VSVCBJTlRPIEByZXBvc" +
                        "nQgKEFuemFobFBlcnNvbmVuLCBHcnVwcGVDb2RlLCBEZXRhaWxDb2RlLCBHcnVwcGUsIERldGFpbCwgQ" +
                        "mdLYXRlZ29yaWVDb2RlLCBCZ0thdGVnb3JpZVRleHQsIEJldHJhZykNClZBTFVFUyAoJycsIDEsIDIsI" +
                        "CdMZWJlbnN1bnRlcmhhbHQnLCBkYm8uZm5MT1ZUZXh0KCdCZ0dydXBwZScsIDM5MzAwKSwgMiwgJ0F1c" +
                        "2dhYmVuJywgMCkNCg0KSU5TRVJUIElOVE8gQHJlcG9ydCAoQW56YWhsUGVyc29uZW4sIEdydXBwZUNvZ" +
                        "GUsIERldGFpbENvZGUsIEdydXBwZSwgRGV0YWlsLCBCZ0thdGVnb3JpZUNvZGUsIEJnS2F0ZWdvcmllV" +
                        "GV4dCwgQmV0cmFnKQ0KVkFMVUVTICgnJywgMSwgMywgJ0xlYmVuc3VudGVyaGFsdCcsICdJWlUnLCAyL" +
                        "CAnQXVzZ2FiZW4nLCAwKQ0KDQpJTlNFUlQgSU5UTyBAcmVwb3J0IChBbnphaGxQZXJzb25lbiwgR3J1c" +
                        "HBlQ29kZSwgRGV0YWlsQ29kZSwgR3J1cHBlLCBEZXRhaWwsIEJnS2F0ZWdvcmllQ29kZSwgQmdLYXRlZ" +
                        "29yaWVUZXh0LCBCZXRyYWcpDQpWQUxVRVMgKCcnLCAxLCA0LCAnTGViZW5zdW50ZXJoYWx0JywgJ0VGQ" +
                        "icsIDIsICdBdXNnYWJlbicsIDApDQoNCklOU0VSVCBJTlRPIEByZXBvcnQgKEFuemFobFBlcnNvbmVuL" +
                        "CBHcnVwcGVDb2RlLCBEZXRhaWxDb2RlLCBHcnVwcGUsIERldGFpbCwgQmdLYXRlZ29yaWVDb2RlLCBCZ" +
                        "0thdGVnb3JpZVRleHQsIEJldHJhZykNClZBTFVFUyAoJycsIDEsIDUsICdMZWJlbnN1bnRlcmhhbHQnL" +
                        "CBkYm8uZm5MT1ZUZXh0KCdCZ0dydXBwZScsIDMyMDMpLCAyLCAnQXVzZ2FiZW4nLCAwKQ0KDQpJTlNFU" +
                        "lQgSU5UTyBAcmVwb3J0IChBbnphaGxQZXJzb25lbiwgR3J1cHBlQ29kZSwgRGV0YWlsQ29kZSwgR3J1c" +
                        "HBlLCBEZXRhaWwsIEJnS2F0ZWdvcmllQ29kZSwgQmdLYXRlZ29yaWVUZXh0LCBCZXRyYWcpDQpWQUxVR" +
                        "VMgKCcnLCAxLCA2LCAnTGViZW5zdW50ZXJoYWx0JywgJ05lYmVua29zdGVuIGluIHN0YXRpb27DpHJlb" +
                        "iBFaW5yaWNodHVuZ2VuJywgMiwgJ0F1c2dhYmVuJywgMCkNCg0KSU5TRVJUIElOVE8gQHJlcG9ydCAoQ" +
                        "W56YWhsUGVyc29uZW4sIEdydXBwZUNvZGUsIERldGFpbENvZGUsIEdydXBwZSwgRGV0YWlsLCBCZ0thd" +
                        "GVnb3JpZUNvZGUsIEJnS2F0ZWdvcmllVGV4dCwgQmV0cmFnKQ0KVkFMVUVTICgnJywgMiwgMSwgZGJvL" +
                        "mZuTE9WVGV4dCgnQmdHcnVwcGUnLCAzMjA2KSwgJ01pZXRlJywgMiwgJ0F1c2dhYmVuJywgMCkNCg0KS" +
                        "U5TRVJUIElOVE8gQHJlcG9ydCAoQW56YWhsUGVyc29uZW4sIEdydXBwZUNvZGUsIERldGFpbENvZGUsI" +
                        "EdydXBwZSwgRGV0YWlsLCBCZ0thdGVnb3JpZUNvZGUsIEJnS2F0ZWdvcmllVGV4dCwgQmV0cmFnKQ0KV" +
                        "kFMVUVTICgnJywgMiwgMiwgZGJvLmZuTE9WVGV4dCgnQmdHcnVwcGUnLCAzMjA2KSwgJ01pZXRuZWJlb" +
                        "mtvc3RlbicsIDIsICdBdXNnYWJlbicsIDApDQoNCklOU0VSVCBJTlRPIEByZXBvcnQgKEFuemFobFBlc" +
                        "nNvbmVuLCBHcnVwcGVDb2RlLCBEZXRhaWxDb2RlLCBHcnVwcGUsIERldGFpbCwgQmdLYXRlZ29yaWVDb" +
                        "2RlLCBCZ0thdGVnb3JpZVRleHQsIEJldHJhZykNClZBTFVFUyAoJycsIDMsIDEsIGRiby5mbkxPVlRle" +
                        "HQoJ0JnR3J1cHBlJywgMzIwMiksICdLcmFua2VudmVyc2ljaGVydW5nIChLVkcpJywgMiwgJ0F1c2dhY" +
                        "mVuJywgMCkNCg0KSU5TRVJUIElOVE8gQHJlcG9ydCAoQW56YWhsUGVyc29uZW4sIEdydXBwZUNvZGUsI" +
                        "ERldGFpbENvZGUsIEdydXBwZSwgRGV0YWlsLCBCZ0thdGVnb3JpZUNvZGUsIEJnS2F0ZWdvcmllVGV4d" +
                        "CwgQmV0cmFnKQ0KVkFMVUVTICgnJywgMywgMiwgZGJvLmZuTE9WVGV4dCgnQmdHcnVwcGUnLCAzMjAyK" +
                        "SwgJ0tyYW5rZW52ZXJzaWNoZXJ1bmcgKFZWRyknLCAyLCAnQXVzZ2FiZW4nLCAwKQ0KDQpJTlNFUlQgS" +
                        "U5UTyBAcmVwb3J0IChBbnphaGxQZXJzb25lbiwgR3J1cHBlQ29kZSwgRGV0YWlsQ29kZSwgR3J1cHBlL" +
                        "CBEZXRhaWwsIEJnS2F0ZWdvcmllQ29kZSwgQmdLYXRlZ29yaWVUZXh0LCBCZXRyYWcpDQpWQUxVRVMgK" +
                        "CcnLCAzLCAzLCBkYm8uZm5MT1ZUZXh0KCdCZ0dydXBwZScsIDMyMDIpLCBkYm8uZm5MT1ZUZXh0KCdCZ" +
                        "0dydXBwZScsIDM5MDQpLCAyLCAnQXVzZ2FiZW4nLCAwKQ0KDQpJTlNFUlQgSU5UTyBAcmVwb3J0IChBb" +
                        "nphaGxQZXJzb25lbiwgR3J1cHBlQ29kZSwgRGV0YWlsQ29kZSwgR3J1cHBlLCBEZXRhaWwsIEJnS2F0Z" +
                        "WdvcmllQ29kZSwgQmdLYXRlZ29yaWVUZXh0LCBCZXRyYWcpDQpWQUxVRVMgKCcnLCAzLCA0LCBkYm8uZ" +
                        "m5MT1ZUZXh0KCdCZ0dydXBwZScsIDMyMDIpLCBkYm8uZm5MT1ZUZXh0KCdCZ0dydXBwZScsIDM5MDMpL" +
                        "CAyLCAnQXVzZ2FiZW4nLCAwKQ0KDQpJTlNFUlQgSU5UTyBAcmVwb3J0IChBbnphaGxQZXJzb25lbiwgR" +
                        "3J1cHBlQ29kZSwgRGV0YWlsQ29kZSwgR3J1cHBlLCBEZXRhaWwsIEJnS2F0ZWdvcmllQ29kZSwgQmdLY" +
                        "XRlZ29yaWVUZXh0LCBCZXRyYWcpDQpWQUxVRVMgKCcnLCAzLCA1LCBkYm8uZm5MT1ZUZXh0KCdCZ0dyd" +
                        "XBwZScsIDMyMDIpLCBkYm8uZm5MT1ZUZXh0KCdCZ0dydXBwZScsIDM5MDIpLCAyLCAnQXVzZ2FiZW4nL" +
                        "CAwKQ0KDQpJTlNFUlQgSU5UTyBAcmVwb3J0IChBbnphaGxQZXJzb25lbiwgR3J1cHBlQ29kZSwgRGV0Y" +
                        "WlsQ29kZSwgR3J1cHBlLCBEZXRhaWwsIEJnS2F0ZWdvcmllQ29kZSwgQmdLYXRlZ29yaWVUZXh0LCBCZ" +
                        "XRyYWcpDQpWQUxVRVMgKCcnLCAzLCA2LCBkYm8uZm5MT1ZUZXh0KCdCZ0dydXBwZScsIDMyMDIpLCBkY" +
                        "m8uZm5MT1ZUZXh0KCdCZ0dydXBwZScsIDM5MDEpLCAyLCAnQXVzZ2FiZW4nLCAwKQ0KDQpJTlNFUlQgS" +
                        "U5UTyBAcmVwb3J0IChBbnphaGxQZXJzb25lbiwgR3J1cHBlQ29kZSwgRGV0YWlsQ29kZSwgR3J1cHBlL" +
                        "CBEZXRhaWwsIEJnS2F0ZWdvcmllQ29kZSwgQmdLYXRlZ29yaWVUZXh0LCBCZXRyYWcpDQpWQUxVRVMgK" +
                        "CcnLCA0LCAxLCAnJywgJ1p1c8OkdHpsaWNoZSBMZWlzdHVuZ2VuL0VpbnplbHphaGx1bmdlbicsIDIsI" +
                        "CdBdXNnYWJlbicsIDApDQoNCi0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tL" +
                        "S0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tL" +
                        "S0tLS0tLS0tLS0tLS0tLS0NCi0tIEFuemVpZ2UNClNFTEVDVCANCiAgQW56YWhsUGVyc29uZW4sIA0KI" +
                        "CBHcnVwcGVDb2RlLCANCiAgRGV0YWlsQ29kZSwgDQogIEdydXBwZSwgDQogIERldGFpbCwgDQogIEJnS" +
                        "2F0ZWdvcmllVGV4dCA9IFVQUEVSKEJnS2F0ZWdvcmllVGV4dCksIA0KICBCZXRyYWcgPSBDQVNFIFdIR" +
                        "U4gR3J1cHBlQ29kZSBJTiAoMTEsIDEyKSBUSEVOIC1zdW0oQmV0cmFnKSBFTFNFIHN1bShCZXRyYWcpI" +
                        "EVORCwNCiAgQmV0cmFnRGlzcGxheSA9IHN1bShCZXRyYWcpLA0KICBUb3RhbFRleHQgPSBDQVNFIA0KI" +
                        "CAgIFdIRU4gR3J1cHBlQ29kZSBCRVRXRUVOIDEgQU5EIDEwIFRIRU4gJ0FVU0dBQkVOIFRPVEFMJw0KI" +
                        "CAgIFdIRU4gR3J1cHBlQ29kZSA9IDExIFRIRU4gJ0VJTk5BSE1FTiBUT1RBTCcNCiAgICBXSEVOIEdyd" +
                        "XBwZUNvZGUgPSAxMiBUSEVOICdEaXJla3R6YWhsdW5nZW4sIEFiesO8Z2UgVG90YWwnDQogIEVORA0KR" +
                        "lJPTSBAcmVwb3J0DQpHUk9VUCBCWSBBbnphaGxQZXJzb25lbiwgR3J1cHBlQ29kZSwgRGV0YWlsQ29kZ" +
                        "SwgQmdLYXRlZ29yaWVUZXh0LCBHcnVwcGUsIERldGFpbA0KLS1PUkRFUiBCWSBCZ0thdGVnb3JpZVRle" +
                        "HQsIFRvdGFsVGV4dCBERVNDLCBHcnVwcGVDb2RlLCBEZXRhaWxDb2Rl";
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
            this.grp1H = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.grp2H = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.grp2F = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.grp1F = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.grp0H = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.grp0F = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Betrag1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBezeichnung = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGrp2Text = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine7 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Grp1Betrag = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.HiddenPanel = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.hiddenLblGroupText = new DevExpress.XtraReports.UI.XRLabel();
            this.hiddenLblShPositionTypID = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGrp1Text = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine14 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel7,
                        this.xrLabel6,
                        this.Betrag1,
                        this.txtBezeichnung});
            this.Detail.Height = 20;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBackColor = false;
            this.Detail.ParentStyleUsing.UseBorderColor = false;
            this.Detail.ParentStyleUsing.UseBorders = false;
            this.Detail.ParentStyleUsing.UseBorderWidth = false;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.ParentStyleUsing.UseForeColor = false;
            this.Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("DetailCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            // 
            // ReportHeader
            // 
            this.ReportHeader.Height = 0;
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
            this.grp1H.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("TotalText", DevExpress.XtraReports.UI.XRColumnSortOrder.Descending)});
            this.grp1H.Height = 0;
            this.grp1H.Level = 1;
            this.grp1H.Name = "grp1H";
            this.grp1H.ParentStyleUsing.UseBackColor = false;
            this.grp1H.ParentStyleUsing.UseBorderColor = false;
            this.grp1H.ParentStyleUsing.UseBorders = false;
            this.grp1H.ParentStyleUsing.UseBorderWidth = false;
            this.grp1H.ParentStyleUsing.UseFont = false;
            this.grp1H.ParentStyleUsing.UseForeColor = false;
            this.grp1H.Visible = false;
            // 
            // grp2H
            // 
            this.grp2H.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel5,
                        this.txtGrp2Text});
            this.grp2H.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("GruppeCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.grp2H.Height = 20;
            this.grp2H.Name = "grp2H";
            this.grp2H.ParentStyleUsing.UseBackColor = false;
            this.grp2H.ParentStyleUsing.UseBorderColor = false;
            this.grp2H.ParentStyleUsing.UseBorders = false;
            this.grp2H.ParentStyleUsing.UseBorderWidth = false;
            this.grp2H.ParentStyleUsing.UseFont = false;
            this.grp2H.ParentStyleUsing.UseForeColor = false;
            this.grp2H.Scripts.OnBeforePrint = resources.GetString("grp2H.Scripts.OnBeforePrint");
            // 
            // grp2F
            // 
            this.grp2F.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLine7});
            this.grp2F.Height = 2;
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
                        this.xrLabel8,
                        this.Grp1Betrag,
                        this.xrLabel1});
            this.grp1F.Height = 25;
            this.grp1F.Level = 1;
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
            // grp0H
            // 
            this.grp0H.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtGrp1Text});
            this.grp0H.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("BgKategorieText", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.grp0H.Height = 33;
            this.grp0H.Level = 2;
            this.grp0H.Name = "grp0H";
            // 
            // grp0F
            // 
            this.grp0F.Height = 2;
            this.grp0F.Level = 2;
            this.grp0F.Name = "grp0F";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Height = 0;
            this.GroupHeader1.Level = 3;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.Visible = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLine14,
                        this.xrLabel3,
                        this.xrLabel4});
            this.GroupFooter1.Height = 38;
            this.GroupFooter1.Level = 3;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AnzahlPersonen", "")});
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel7.ForeColor = System.Drawing.Color.Black;
            this.xrLabel7.Location = new System.Drawing.Point(375, 0);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseBackColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorders = false;
            this.xrLabel7.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.ParentStyleUsing.UseForeColor = false;
            this.xrLabel7.Size = new System.Drawing.Size(100, 20);
            this.xrLabel7.Text = "xrLabel7";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.ForeColor = System.Drawing.Color.Black;
            this.xrLabel6.Location = new System.Drawing.Point(0, 0);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseBackColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorders = false;
            this.xrLabel6.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.ParentStyleUsing.UseForeColor = false;
            this.xrLabel6.Size = new System.Drawing.Size(20, 20);
            // 
            // Betrag1
            // 
            this.Betrag1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right)));
            this.Betrag1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragDisplay", "{0:n2}")});
            this.Betrag1.Font = new System.Drawing.Font("Arial", 10F);
            this.Betrag1.ForeColor = System.Drawing.Color.Black;
            this.Betrag1.Location = new System.Drawing.Point(475, 0);
            this.Betrag1.Multiline = true;
            this.Betrag1.Name = "Betrag1";
            this.Betrag1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Betrag1.ParentStyleUsing.UseBackColor = false;
            this.Betrag1.ParentStyleUsing.UseBorderColor = false;
            this.Betrag1.ParentStyleUsing.UseBorders = false;
            this.Betrag1.ParentStyleUsing.UseBorderWidth = false;
            this.Betrag1.ParentStyleUsing.UseFont = false;
            this.Betrag1.ParentStyleUsing.UseForeColor = false;
            this.Betrag1.Size = new System.Drawing.Size(100, 20);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.Betrag1.Summary = xrSummary1;
            this.Betrag1.Text = "Betrag1";
            this.Betrag1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtBezeichnung
            // 
            this.txtBezeichnung.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.txtBezeichnung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Detail", "")});
            this.txtBezeichnung.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBezeichnung.ForeColor = System.Drawing.Color.Black;
            this.txtBezeichnung.Location = new System.Drawing.Point(20, 0);
            this.txtBezeichnung.Multiline = true;
            this.txtBezeichnung.Name = "txtBezeichnung";
            this.txtBezeichnung.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBezeichnung.ParentStyleUsing.UseBackColor = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorderColor = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorders = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorderWidth = false;
            this.txtBezeichnung.ParentStyleUsing.UseFont = false;
            this.txtBezeichnung.ParentStyleUsing.UseForeColor = false;
            this.txtBezeichnung.Size = new System.Drawing.Size(355, 20);
            this.txtBezeichnung.Text = "txtBezeichnung";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.ForeColor = System.Drawing.Color.Black;
            this.xrLabel5.Location = new System.Drawing.Point(0, 0);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseBackColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorders = false;
            this.xrLabel5.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.ParentStyleUsing.UseForeColor = false;
            this.xrLabel5.Size = new System.Drawing.Size(20, 20);
            // 
            // txtGrp2Text
            // 
            this.txtGrp2Text.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right)));
            this.txtGrp2Text.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Gruppe", "")});
            this.txtGrp2Text.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtGrp2Text.ForeColor = System.Drawing.Color.Black;
            this.txtGrp2Text.Location = new System.Drawing.Point(20, 0);
            this.txtGrp2Text.Multiline = true;
            this.txtGrp2Text.Name = "txtGrp2Text";
            this.txtGrp2Text.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGrp2Text.ParentStyleUsing.UseBackColor = false;
            this.txtGrp2Text.ParentStyleUsing.UseBorderColor = false;
            this.txtGrp2Text.ParentStyleUsing.UseBorders = false;
            this.txtGrp2Text.ParentStyleUsing.UseBorderWidth = false;
            this.txtGrp2Text.ParentStyleUsing.UseFont = false;
            this.txtGrp2Text.ParentStyleUsing.UseForeColor = false;
            this.txtGrp2Text.Size = new System.Drawing.Size(555, 20);
            this.txtGrp2Text.Text = "txtGrp2Text";
            // 
            // xrLine7
            // 
            this.xrLine7.Location = new System.Drawing.Point(0, 0);
            this.xrLine7.Name = "xrLine7";
            this.xrLine7.Size = new System.Drawing.Size(576, 2);
            // 
            // xrLabel8
            // 
            this.xrLabel8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.ForeColor = System.Drawing.Color.Black;
            this.xrLabel8.Location = new System.Drawing.Point(0, 0);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseBackColor = false;
            this.xrLabel8.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel8.ParentStyleUsing.UseBorders = false;
            this.xrLabel8.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.ParentStyleUsing.UseForeColor = false;
            this.xrLabel8.Size = new System.Drawing.Size(20, 25);
            // 
            // Grp1Betrag
            // 
            this.Grp1Betrag.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Grp1Betrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BetragDisplay", "{0:n2}")});
            this.Grp1Betrag.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Grp1Betrag.ForeColor = System.Drawing.Color.Black;
            this.Grp1Betrag.Location = new System.Drawing.Point(475, 0);
            this.Grp1Betrag.Multiline = true;
            this.Grp1Betrag.Name = "Grp1Betrag";
            this.Grp1Betrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Grp1Betrag.ParentStyleUsing.UseBackColor = false;
            this.Grp1Betrag.ParentStyleUsing.UseBorderColor = false;
            this.Grp1Betrag.ParentStyleUsing.UseBorders = false;
            this.Grp1Betrag.ParentStyleUsing.UseBorderWidth = false;
            this.Grp1Betrag.ParentStyleUsing.UseFont = false;
            this.Grp1Betrag.ParentStyleUsing.UseForeColor = false;
            this.Grp1Betrag.Size = new System.Drawing.Size(100, 25);
            xrSummary2.FormatString = "{0:#,##0.00}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.Grp1Betrag.Summary = xrSummary2;
            this.Grp1Betrag.Text = "Grp1Betrag";
            this.Grp1Betrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TotalText", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.Location = new System.Drawing.Point(20, 0);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(455, 25);
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
            this.hiddenLblGroupText.Location = new System.Drawing.Point(0, 27);
            this.hiddenLblGroupText.Name = "hiddenLblGroupText";
            this.hiddenLblGroupText.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hiddenLblGroupText.Size = new System.Drawing.Size(100, 27);
            this.hiddenLblGroupText.Text = "hiddenLblGroupText";
            // 
            // hiddenLblShPositionTypID
            // 
            this.hiddenLblShPositionTypID.Location = new System.Drawing.Point(0, 0);
            this.hiddenLblShPositionTypID.Name = "hiddenLblShPositionTypID";
            this.hiddenLblShPositionTypID.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hiddenLblShPositionTypID.Size = new System.Drawing.Size(160, 20);
            this.hiddenLblShPositionTypID.Text = "hiddenLblShPositionTypID";
            // 
            // txtGrp1Text
            // 
            this.txtGrp1Text.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right)));
            this.txtGrp1Text.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BgKategorieText", "")});
            this.txtGrp1Text.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtGrp1Text.ForeColor = System.Drawing.Color.Black;
            this.txtGrp1Text.Location = new System.Drawing.Point(0, 12);
            this.txtGrp1Text.Multiline = true;
            this.txtGrp1Text.Name = "txtGrp1Text";
            this.txtGrp1Text.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGrp1Text.ParentStyleUsing.UseBackColor = false;
            this.txtGrp1Text.ParentStyleUsing.UseBorderColor = false;
            this.txtGrp1Text.ParentStyleUsing.UseBorders = false;
            this.txtGrp1Text.ParentStyleUsing.UseBorderWidth = false;
            this.txtGrp1Text.ParentStyleUsing.UseFont = false;
            this.txtGrp1Text.ParentStyleUsing.UseForeColor = false;
            this.txtGrp1Text.Size = new System.Drawing.Size(575, 21);
            this.txtGrp1Text.Text = "txtGrp1Text";
            // 
            // xrLine14
            // 
            this.xrLine14.ForeColor = System.Drawing.Color.Black;
            this.xrLine14.Location = new System.Drawing.Point(475, 26);
            this.xrLine14.Name = "xrLine14";
            this.xrLine14.ParentStyleUsing.UseBackColor = false;
            this.xrLine14.ParentStyleUsing.UseBorderColor = false;
            this.xrLine14.ParentStyleUsing.UseBorders = false;
            this.xrLine14.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine14.ParentStyleUsing.UseFont = false;
            this.xrLine14.ParentStyleUsing.UseForeColor = false;
            this.xrLine14.Size = new System.Drawing.Size(100, 2);
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(475, 0);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(100, 25);
            xrSummary3.FormatString = "{0:#,##0.00}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel3.Summary = xrSummary3;
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.Location = new System.Drawing.Point(20, 0);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(420, 20);
            this.xrLabel4.Text = "Ueberweisung aufs Konto/UEBERSCHUSS";
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
                        this.ReportHeader,
                        this.grp1H,
                        this.grp2H,
                        this.grp2F,
                        this.grp1F,
                        this.ReportFooter,
                        this.grp0H,
                        this.grp0F,
                        this.GroupHeader1,
                        this.GroupFooter1});
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
</NewDataSet>' ,  N'DECLARE @BgBudgetID INT
SET @BgBudgetID = {BgBudgetID};

DECLARE @RefDate  datetime  SET @RefDate = GETDATE();

DECLARE @AUSGABEN                               VARCHAR(50),
        @Lebensunterhalt                        VARCHAR(50),
        @IZU                                    VARCHAR(50),
        @EFB                                    VARCHAR(50),
        @NebenkostenInStationaerenEinrichtungen VARCHAR(50),
        @Miete                                  VARCHAR(50),
        @Mietnebenkosten                        VARCHAR(50),
        @KrankenversicherungKVG                 VARCHAR(50),
        @KrankenversicherungVVG                 VARCHAR(50),
        @ZusaetzlicheLeistungenEinzelzahlungen  VARCHAR(50),
        @GutschriftAufAusgabekonto              VARCHAR(50),
        @EINNAHMEN                              VARCHAR(50),
        @DirektzahlungenAbzuege                 VARCHAR(50),
        @DirektzahlungenAnDritte                VARCHAR(50),
        @Vorabzugskonto                         VARCHAR(50),
        @Abzahlungskonto                        VARCHAR(50),
        @Kuerzungen                             VARCHAR(50);

SELECT @AUSGABEN                               = ''AUSGABEN'',
       @Lebensunterhalt                        = ''Lebensunterhalt'',
       @IZU                                    = ''IZU'',
       @EFB                                    = ''EFB'',
       @NebenkostenInStationaerenEinrichtungen = ''Nebenkosten in stationären Einrichtungen'',
       @Miete                                  = ''Miete'',
       @Mietnebenkosten                        = ''Mietnebenkosten'',
       @KrankenversicherungKVG                 = ''Krankenversicherung (KVG)'',
       @KrankenversicherungVVG                 = ''Krankenversicherung (VVG)'',
       @ZusaetzlicheLeistungenEinzelzahlungen  = ''Zusätzliche Leistungen/Einzelzahlungen'',
       @GutschriftAufAusgabekonto              = ''Gutschrift auf Ausgabekonto'',
       @EINNAHMEN                              = ''EINNAHMEN'',
       @DirektzahlungenAbzuege                 = ''Direktzahlungen, Abzüge'',
       @DirektzahlungenAnDritte                = ''Direktzahlungen an Dritte'',
       @Vorabzugskonto                         = ''Vorabzugskonto'',
       @Abzahlungskonto                        = ''Abzahlungskonto'',
       @Kuerzungen                             = ''Kürzungen'';

-- Anzahl von unterstützte Personen
DECLARE @AnzahlPersonen INT;
SET @AnzahlPersonen = (
  SELECT COUNT(*)
  FROM dbo.BgFinanzplan_BaPerson    BFB WITH (READUNCOMMITTED)
    INNER JOIN dbo.vwPerson         PRS                        ON PRS.BaPersonID = BFB.BaPersonID
    INNER JOIN dbo.BgFinanzplan     BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID = BFB.BgFinanzplanID
    INNER JOIN dbo.FaLeistung       FLE WITH (READUNCOMMITTED) ON FLE.FaLeistungID = BFP.FaLeistungID
  WHERE BFB.BgFinanzplanID = (
      SELECT BgFinanzplanID
      FROM dbo.BgBudget WITH (READUNCOMMITTED)
      WHERE BgBudgetID = @BgBudgetID
    )
    AND IstUnterstuetzt = 1
  );

-- Temporäre Tabelle für den Report
DECLARE @report TABLE (
  AnzahlPersonen   VARCHAR(MAX),
  GruppeCode       INT,
  DetailCode       INT,
  Gruppe           VARCHAR(MAX),
  Detail           VARCHAR(MAX),
  BgPositionsartID INT,
  BgKategorieCode  INT,
  BgKategorieText  VARCHAR(MAX),
  BgGruppeCode     INT,
  BgGruppeText     VARCHAR(MAX),
  Dritte           BIT,
  Bezeichnung      VARCHAR(MAX),
  BgSpezkontoID    INT,
  Betrag           MONEY
);

-- Direktzahlungen an Dritte
DECLARE @anDritte TABLE (
  BgPositionID INT, 
  Betrag       MONEY
);

DECLARE @BgFinanzplanID INT;

SELECT @BgFinanzplanID = BBG.BgFinanzplanID
FROM dbo.BgBudget BBG WITH (READUNCOMMITTED)
WHERE  BBG.BgBudgetID = @BgBudgetID;

DECLARE @BetragDritte MONEY;

-- alle Zahlungen an Dritte vom Budget suchen
INSERT INTO @anDritte(BgPositionID, Betrag)
SELECT BPO.BgPositionID, Betrag
FROM dbo.vwBgPosition BPO
       LEFT  JOIN dbo.BgAuszahlungPerson BAP WITH (READUNCOMMITTED) ON BAP.BgPositionID = BPO.BgPositionID 
                                                                   AND BAP.BgAuszahlungPersonID = (SELECT TOP 1 BgAuszahlungPersonID
                                                                                                   FROM dbo.BgAuszahlungPerson WITH (READUNCOMMITTED)
                                                                                                   WHERE  BgPositionID = BPO.BgPositionID
                                                                                                   ORDER BY 
                                                                                                     CASE WHEN BaPersonID IS NULL THEN 1
                                                                                                          WHEN BaPersonID = BPO.BaPersonID THEN 2
                                                                                                          ELSE 3
                                                                                                     END)
       LEFT  JOIN dbo.vwKreditor         KRE  ON KRE.BaZahlungswegID = BAP.BaZahlungswegID
WHERE  BPO.BgBudgetID = @BgBudgetID
  AND (CASE
         WHEN KRE.BaZahlungswegID IS NULL         THEN 0
         WHEN EXISTS (SELECT TOP 1 1
                      FROM dbo.BgFinanzplan_BaPerson WITH (READUNCOMMITTED)
                      WHERE BaPersonID = KRE.BaPersonID
                        AND BgFinanzplanID = @BgFinanzplanID
                        AND IstUnterstuetzt = 1)  THEN 0
         ELSE 1
       END) = 1;

SELECT @BetragDritte = SUM(Betrag)
FROM @anDritte;

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 12, 1, @DirektzahlungenAbzuege, @DirektzahlungenAnDritte, 1, @EINNAHMEN, @BetragDritte);

-- Infos vom Budget hinzufügen ohne Einträge mit Gutschrift auf Ausgabekonto
INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, BgGruppeCode, BgGruppeText, BgPositionsartID, Dritte, BgSpezkontoID, Bezeichnung, Betrag)
SELECT
    AnzahlPersonen = CASE WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode = 3201 
                       THEN CONVERT(varchar(MAX), @AnzahlPersonen) + CASE WHEN @AnzahlPersonen = 1 THEN '' Person'' ELSE '' Personen'' END 
                       ELSE '''' 
                     END,

    GruppeCode = CASE
      WHEN TMP.BgKategorieCode = 2 AND 
        TMP.BgGruppeCode IN (3201,      -- Grundbedarf
          39300,                        -- MIZ
          39200, 39210, 39220, 39230,   -- IZU
          39100, 39110, 39120, 39130,   -- EFB
          3203                          -- Erwerbsunkosten
        )                                                   THEN 1 -- Lebensunterhalt
      WHEN TMP.BgKategorieCode = 2 AND 
        TMP.BgGruppeCode = 3206                             THEN 2 -- Wohnkosten
      WHEN TMP.BgKategorieCode = 2 AND 
        TMP.BgGruppeCode IN (3202, 3904, 3903, 3902, 3901)  THEN 3 -- Med. Grundversorgung
      WHEN TMP.BgKategorieCode IN (100, 101)                THEN 4 -- andere Ausgaben
      WHEN TMP.BgGruppeCode IN (3101, 3102, 3103, 3104) THEN 11 -- Einnahmen
      WHEN TMP.BgKategorieCode IN (6, 3, 4) THEN 12 -- Direktzahlungen, Abzüge
      ELSE 0
    END,

    DetailCode = CASE
      -- Lebensunterhalt
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode = 3201                          THEN 1  -- Grundbedarf
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode = 39300                         THEN 2  -- MIZ
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode IN (39200, 39210, 39220, 39230) THEN 3  -- IZU
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode IN (39100, 39110, 39120, 39130) THEN 4  -- EFB
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode = 3203                          THEN 5  -- Erwerbsunkosten
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgPositionsartID = 32019                     THEN 6  -- Nebenkosten in stationären Einrichtungen
      -- Wohnkosten
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode = 3206 AND TMP.BgPositionsartID != 32060 THEN 1  -- Miete
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode = 3206 AND TMP.BgPositionsartID = 32060  THEN 2  -- Mietnebenkosten
      -- Med. Grundversorgung
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgPositionsartID IN (32020, 32023, 32024) THEN 1  -- Krankenversicherung (KVG)
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgPositionsartID BETWEEN 32121 AND 32129  THEN 1  -- Krankenversicherung (KVG)
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgPositionsartID IN (32021, 32022)        THEN 2  -- Krankenversicherung (VVG)
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode = 3904                       THEN 3  -- Wiedereingliederung
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode = 3903                       THEN 4  -- Leistungen für Therapie und Entzugsmassnahmen
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode = 3902                       THEN 5  -- Krankheits- und behinderungsbedingte Kosten
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode = 3901                       THEN 6  -- Situationsbedingte Leistungen
      -- andere Ausgaben
      WHEN TMP.BgKategorieCode IN (100, 101) THEN 1  -- Zusätzliche Leistungen/Einzelzahlungen
      -- Einnahmen
      WHEN TMP.BgGruppeCode = 3101                          THEN 1  -- Erwerbseinkommen
      WHEN TMP.BgGruppeCode = 3102                          THEN 2  -- Alimentguthaben
      WHEN TMP.BgGruppeCode = 3103                          THEN 3  -- Einkommen aus Versicherungsleistungen
      WHEN TMP.BgGruppeCode = 3104                          THEN 4  -- Vermögen- und Vermögensverbrauch
      -- Direktzahlungen, Abzüge
        -- Direktzahlungen an Dritte: DetailCode 1
      WHEN TMP.BgKategorieCode = 6                          THEN 2  -- Vorabzugskonto
      WHEN TMP.BgKategorieCode = 3                          THEN 3  -- Abzahlungskonto
      WHEN TMP.BgKategorieCode = 4                          THEN 4  -- Kürzungen
      ELSE 0
    END,

    Gruppe = CASE
      WHEN TMP.BgKategorieCode = 2 AND 
        TMP.BgGruppeCode IN (3201, -- Grundbedarf
          39300,                        -- MIZ
          39200, 39210, 39220, 39230,   -- IZU
          39100, 39110, 39120, 39130,   -- EFB
          3203                          -- Erwerbsunkosten
        ) THEN @Lebensunterhalt
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode = 3206 THEN dbo.fnLOVText(''BgGruppe'', TMP.BgGruppeCode)
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode IN (3202, 3904, 3903, 3902, 3901) THEN dbo.fnLOVText(''BgGruppe'', TMP.BgGruppeCode)
      WHEN TMP.BgKategorieCode IN (100, 101)                  THEN '''' -- andere Ausgaben
      WHEN TMP.BgGruppeCode IN (3101, 3102, 3103, 3104) THEN '''' -- Einnahmen
      WHEN TMP.BgKategorieCode IN (6, 3, 4) THEN @DirektzahlungenAbzuege -- Direktzahlungen, Abzüge
      ELSE ''''
    END,

    Detail = CASE
      -- Lebensunterhalt
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode = 3201 THEN dbo.fnLOVText(''BgGruppe'', TMP.BgGruppeCode)
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode = 39300 THEN dbo.fnLOVText(''BgGruppe'', TMP.BgGruppeCode)
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode IN (39200, 39210, 39220, 39230) THEN @IZU
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode IN (39100, 39110, 39120, 39130) THEN @EFB
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode = 3203 THEN  dbo.fnLOVText(''BgGruppe'', TMP.BgGruppeCode)
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgPositionsartID = 32019 THEN @NebenkostenInStationaerenEinrichtungen
      -- Wohnkosten
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode = 3206 AND TMP.BgPositionsartID != 32060 THEN @Miete
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode = 3206 AND TMP.BgPositionsartID = 32060 THEN @Mietnebenkosten
      -- Med. Grundversorgung
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgPositionsartID IN (32020, 32023, 32024) THEN @KrankenversicherungKVG
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgPositionsartID BETWEEN 32121 AND 32129  THEN @KrankenversicherungKVG
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgPositionsartID IN (32021, 32022) THEN @KrankenversicherungVVG
      WHEN TMP.BgKategorieCode = 2 AND TMP.BgGruppeCode IN (3904, 3903, 3902, 3901) THEN  dbo.fnLOVText(''BgGruppe'', TMP.BgGruppeCode)
      -- andere Ausgaben
      WHEN TMP.BgKategorieCode IN (100, 101) THEN @ZusaetzlicheLeistungenEinzelzahlungen
      -- Einnahmen
      WHEN TMP.BgGruppeCode = 3101                          THEN ''Erwerbseinkommen''
      WHEN TMP.BgGruppeCode = 3102                          THEN ''Alimentguthaben''
      WHEN TMP.BgGruppeCode = 3103                          THEN ''Einkommen aus Versicherungsleistungen''
      WHEN TMP.BgGruppeCode = 3104                          THEN ''Vermögen- und Vermögensverbrauch''
      -- Direktzahlungen, Abzüge
      WHEN TMP.BgKategorieCode = 6                          THEN @Vorabzugskonto
      WHEN TMP.BgKategorieCode = 3                          THEN @Abzahlungskonto
      WHEN TMP.BgKategorieCode = 4                          THEN @Kuerzungen
      ELSE TMP.Bezeichnung
    END,

  TMP.BgKategorieCode, 
  BgKategorieText = CASE 
    WHEN TMP.BgKategorieCode IN (1, 6, 3, 4) THEN dbo.fnLOVText(''BgKategorie'', 1)
    WHEN TMP.BgKategorieCode IN (2, 100, 101) THEN dbo.fnLOVText(''BgKategorie'', 2)
  END,
  TMP.BgGruppeCode, 
  BgGruppeText = dbo.fnLOVText(''BgGruppe'', TMP.BgGruppeCode),
  TMP.BgPositionsartID,
  TMP.Dritte,
  TMP.BgSpezkontoID,
  Bezeichnung = LTrim(TMP.Bezeichnung), 
  TMP.Betrag
FROM dbo.fnWhGetBudget(@BgBudgetID, @RefDate)  TMP
  LEFT JOIN dbo.BgPositionsart SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = TMP.BgPositionsartID
  LEFT JOIN dbo.BgSpezkonto    SPK WITH (READUNCOMMITTED) ON SPK.BgSpezkontoID = TMP.BgSpezkontoID
  LEFT JOIN @anDritte          DRT                        ON DRT.BgPositionID = TMP.BgPositionID
WHERE TMP.BgPositionID IS NOT NULL
  AND DRT.BgPositionID IS NULL -- Direktzahlungen an Dritte nicht hier berücksichtigen
--  AND NOT (TMP.BgKategorieCode = 101 AND TMP.BgSpezkontoID IS NOT NULL) -- keine Einzelzahlungen aus Ausgabekonto
  AND ISNULL(SPK.BgSpezkontoTypCode, 0) <> 1; -- keine Ausgabekonto-Positionen! #4654, Notiz 0021165


-- Infos vom Budget hinzufügen für Einträge mit Gutschrift auf Ausgabekonto
INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, BgGruppeCode, BgGruppeText, BgPositionsartID, Dritte, BgSpezkontoID, Bezeichnung, Betrag)
SELECT
  AnzahlPersonen = '''' ,
  GruppeCode = 4, -- andere Ausgaben
  DetailCode = 2, -- Gutschrift auf Ausgebekonto
  Gruppe = '''',    -- andere Ausgaben
  Detail = @GutschriftAufAusgabekonto,
  TMP.BgKategorieCode, 
  BgKategorieText = dbo.fnLOVText(''BgKategorie'', 2),
  TMP.BgGruppeCode, 
  BgGruppeText = dbo.fnLOVText(''BgGruppe'', TMP.BgGruppeCode),
  TMP.BgPositionsartID,
  TMP.Dritte,
  TMP.BgSpezkontoID,
  Bezeichnung = LTRIM(TMP.Bezeichnung), 
  TMP.Betrag
FROM dbo.fnWhGetBudget(@BgBudgetID, @RefDate)  TMP
  LEFT JOIN dbo.BgPositionsart SPT WITH (READUNCOMMITTED) ON SPT.BgPositionsartID = TMP.BgPositionsartID
  LEFT JOIN dbo.BgSpezkonto    SPK WITH (READUNCOMMITTED) ON SPK.BgSpezkontoID = TMP.BgSpezkontoID
  LEFT JOIN @anDritte          DRT                        ON DRT.BgPositionID = TMP.BgPositionID
WHERE TMP.BgPositionID IS NOT NULL
  AND DRT.BgPositionID IS NULL -- Direktzahlungen an Dritte nicht hier berücksichtigen
  AND ISNULL(SPK.BgSpezkontoTypCode, 0) = 1; -- Ausgabekonto-Positionen

-- Einnahmen-Gruppe hinzufügen dass es immer gleich ist
INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 11, 1, '''', dbo.fnLOVText(''BgGruppe'', 3101), 1, @EINNAHMEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 11, 2, '''', dbo.fnLOVText(''BgGruppe'', 3102), 1, @EINNAHMEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 11, 3, '''', dbo.fnLOVText(''BgGruppe'', 3103), 1, @EINNAHMEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 11, 4, '''', dbo.fnLOVText(''BgGruppe'', 3104), 1, @EINNAHMEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 12, 1, @DirektzahlungenAbzuege, @DirektzahlungenAnDritte, 1, @EINNAHMEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 12, 2, @DirektzahlungenAbzuege, @Vorabzugskonto, 6, @EINNAHMEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 12, 3, @DirektzahlungenAbzuege, @Abzahlungskonto, 3, @EINNAHMEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 12, 4, @DirektzahlungenAbzuege, @Kuerzungen, 4, @EINNAHMEN, 0);

-- Ausgaben-Gruppe hinzufügen dass es immer gleich ist
IF NOT EXISTS(SELECT TOP 1 1 FROM @report WHERE GruppeCode = 1 AND DetailCode = 1) 
BEGIN
  INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
  VALUES (''0 Personen'', 1, 1, @Lebensunterhalt, dbo.fnLOVText(''BgGruppe'', 3201), 2, @AUSGABEN, 0);
END;

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 1, 2, @Lebensunterhalt, dbo.fnLOVText(''BgGruppe'', 39300), 2, @AUSGABEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 1, 3, @Lebensunterhalt, @IZU, 2, @AUSGABEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 1, 4, @Lebensunterhalt, @EFB, 2, @AUSGABEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 1, 5, @Lebensunterhalt, dbo.fnLOVText(''BgGruppe'', 3203), 2, @AUSGABEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 1, 6, @Lebensunterhalt, @NebenkostenInStationaerenEinrichtungen, 2, @AUSGABEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 2, 1, dbo.fnLOVText(''BgGruppe'', 3206), @Miete, 2, @AUSGABEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 2, 2, dbo.fnLOVText(''BgGruppe'', 3206), @Mietnebenkosten, 2, @AUSGABEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 3, 1, dbo.fnLOVText(''BgGruppe'', 3202), @KrankenversicherungKVG, 2, @AUSGABEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 3, 2, dbo.fnLOVText(''BgGruppe'', 3202), @KrankenversicherungVVG, 2, @AUSGABEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 3, 3, dbo.fnLOVText(''BgGruppe'', 3202), dbo.fnLOVText(''BgGruppe'', 3904), 2, @AUSGABEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 3, 4, dbo.fnLOVText(''BgGruppe'', 3202), dbo.fnLOVText(''BgGruppe'', 3903), 2, @AUSGABEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 3, 5, dbo.fnLOVText(''BgGruppe'', 3202), dbo.fnLOVText(''BgGruppe'', 3902), 2, @AUSGABEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 3, 6, dbo.fnLOVText(''BgGruppe'', 3901), dbo.fnLOVText(''BgGruppe'', 3901), 2, @AUSGABEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 4, 1, '''', @ZusaetzlicheLeistungenEinzelzahlungen, 2, @AUSGABEN, 0);

INSERT INTO @report (AnzahlPersonen, GruppeCode, DetailCode, Gruppe, Detail, BgKategorieCode, BgKategorieText, Betrag)
VALUES ('''', 4, 2, '''', @GutschriftAufAusgabekonto, 2, @AUSGABEN, 0);

----------------------------------------------------------------------------------------------------------------------
-- Anzeige
SELECT 
  AnzahlPersonen, 
  GruppeCode, 
  DetailCode, 
  Gruppe, 
  Detail, 
  BgKategorieText = UPPER(BgKategorieText), 
  Betrag = ROUND(CASE WHEN GruppeCode IN (11, 12) THEN -sum(Betrag) ELSE sum(Betrag) END / 0.05, 0) * 0.05,
  BetragDisplay = ROUND(sum(Betrag) / 0.05, 0) * 0.05,
  TotalText = CASE 
    WHEN GruppeCode BETWEEN 1 AND 10 THEN ''AUSGABEN TOTAL''
    WHEN GruppeCode = 11 THEN ''EINNAHMEN TOTAL''
    WHEN GruppeCode = 12 THEN ''Direktzahlungen, Abzüge Total''
  END
FROM @report
GROUP BY AnzahlPersonen, GruppeCode, DetailCode, BgKategorieText, Gruppe, Detail;
--ORDER BY BgKategorieText, TotalText DESC, GruppeCode, DetailCode' ,  null ,  N'ShMonatsbudgetBruttoprinzip' ,  null );


