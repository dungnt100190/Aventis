-- Insert Script for ShDetaillierterFinanzplanStandard
-- MD5:0X019AAFF0591F925602E2B1280F399723_0XDADEC3614B6B6655128488C2ADD0C93A_0X67DD3C0C0F0BE9C862CD02BAC9BE6B65
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'ShDetaillierterFinanzplanStandard') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('ShDetaillierterFinanzplanStandard', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'ShDetaillierterFinanzplanStandard';
--SQLCHECK_IGNORE--
UPDATE QRY
SET QueryName =  N'ShDetaillierterFinanzplanStandard' , UserText =  N'SH - Detaillierter Finanzplan (Standard)' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS40.VSS\KiSS4 Branches\KiSS4233\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\KiSS40.VSS\KiSS4 Branches\KiSS4233\Build\Debug\log4net.dll" />
///     <Reference Path="C:\Projects\KiSS40.VSS\KiSS4 Branches\KiSS4233\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplanStandard_Bewilligungsverfahren;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplanStandard_Vermoegen;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplanStandard_EinkommenAlimente;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplanStandard_EinkommenVersich;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplanStandard_Erwerbseinkommen;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplanStandard_AllgErwerbsunkosten;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplanStandard_Sil;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplanStandard_KvgVvg;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplanStandard_GBMiete;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplanStandard_Uebersicht;
        private DevExpress.XtraReports.UI.Subreport ShDetaillierterFinanzplanStandard_Personen;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel Label8;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.XRLabel Label5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.XRLabel txtDatumBis;
        private DevExpress.XtraReports.UI.XRLabel txtDatumVon;
        private DevExpress.XtraReports.UI.XRLabel Label3;
        private DevExpress.XtraReports.UI.XRLabel txtGeplantBis;
        private DevExpress.XtraReports.UI.XRLabel txtGeplantVon;
        private DevExpress.XtraReports.UI.XRLabel Label2;
        private DevExpress.XtraReports.UI.XRLabel FullName1;
        private DevExpress.XtraReports.UI.XRLabel TextBox1;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLabel txtPLZOrt;
        private DevExpress.XtraReports.UI.XRLabel txtTitel;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel txtFullName;
        private DevExpress.XtraReports.UI.XRLabel txtAnrede;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel txtOrgAdresse;
        private DevExpress.XtraReports.UI.XRLabel txtOrgName;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo3;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
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
                        "AAAAcIRU0VMRUNUIFRPUCAxDQogIFtPcmdOYW1lXSAgICAgID0gSXNOdWxsKENPTlZFUlQodmFyY2hhc" +
                        "igxMDAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc2VcU296aWFsaGlsZmVcT3JnYW5pc2F0a" +
                        "W9uJywgR2V0ZGF0ZSgpKSksICcnKSwNCiAgW09yZ0FkcmVzc2VdICAgPSBJc051bGwoQ09OVkVSVCh2Y" +
                        "XJjaGFyKDEwMDApLCBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxBZHJlc" +
                        "3NlJywgR2V0ZGF0ZSgpKSksICcnKSwNCiAgW09yZ1BMWk9ydF0gICAgPSBJc051bGwoQ09OVkVSVCh2Y" +
                        "XJjaGFyKDEwMDApLCBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxQTFonL" +
                        "CBHZXRkYXRlKCkpKSArICcgJywgJycpDQogICAgICAgICAgICAgICAgICsgSXNOdWxsKENPTlZFUlQod" +
                        "mFyY2hhcigxMDAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc2VcU296aWFsaGlsZmVcT3J0J" +
                        "ywgR2V0ZGF0ZSgpKSksICcnKSwNCiAgW09yZ09ydF0gICAgICAgPSBJc051bGwoQ09OVkVSVCh2YXJja" +
                        "GFyKDEwMDApLCBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxPcnQnLCBHZ" +
                        "XRkYXRlKCkpKSwgJycpLA0KDQogIFtCZ0ZpbmFuenBsYW5JRF0gPSBTRlAuQmdGaW5hbnpwbGFuSUQsI" +
                        "C0tIHJlcXVpcmVkIGZvciBzdWJyZXBvcnRzDQogIFtCZ0J1ZGdldElEXSAgICAgPSBCQkcuQmdCdWRnZ" +
                        "XRJRCwgLS0gcmVxdWlyZWQgZm9yIHN1YnJlcG9ydHMNCiAgW1RpdGVsXSAgICAgICAgPSAnRGV0YWlsb" +
                        "GllcnRlIFZlcmbDvGd1bmcgJyArIExWVC5UZXh0LCAtLSBMVlQuVGV4dCA9IFR5cA0KICBbRnVsbE5hb" +
                        "WVdICAgICA9IFBSUy5OYW1lICsgSXNOdWxsKCcsICcgKyBQUlMuVm9ybmFtZSwnJykgKyAgQ0FTRSBMR" +
                        "U4oSXNOdWxsKFBSUy5Wb3JuYW1lMiwgJycpKSBXSEVOIDAgVEhFTiAnJyBFTFNFICcgJyArIFBSUy5Wb" +
                        "3JuYW1lMiBFTkQsDQogIFtBSFZOdW1tZXJdICAgID0gUFJTLkFIVk51bW1lciwNCiAgW1N0YXR1c10gI" +
                        "CAgICAgPSBMVlMuVGV4dCArIENBU0UgV0hFTiBGRkEuRmFMZWlzdHVuZ0lEIElTIE5PVCBOVUxMIFRIR" +
                        "U4gJyAoYXJjaGl2aWVydCknIEVMU0UgJycgRU5ELA0KICBbSXNVcmdlbnRdICAgICA9IExWVC5WYWx1Z" +
                        "TIsDQogIFtHZXBsYW50Vm9uXSAgID0gU0ZQLkdlcGxhbnRWb24sDQogIFtHZXBsYW50QmlzXSAgID0gU" +
                        "0ZQLkdlcGxhbnRCaXMsDQogIFtEYXR1bVZvbl0gICAgID0gU0ZQLkRhdHVtVm9uLA0KICBbRGF0dW1Ca" +
                        "XNdICAgICA9IFNGUC5EYXR1bUJpcywNCiAgW0JlbWVya3VuZ10gICAgPSBTRlAuQmVtZXJrdW5nLA0KI" +
                        "CBbQW5yZWRlXSAgICAgICA9IENBU0UgUFJTLkdlc2NobGVjaHRDb2RlIFdIRU4gMiBUSEVOICdGcmF1J" +
                        "yBFTFNFICdIZXJybicgRU5ELA0KICBbTmFtZV0gICAgICAgICA9IFBSUy5OYW1lLA0KICBbVm9ybmFtZ" +
                        "V0gICAgICA9IFBSUy5Wb3JuYW1lLA0KICBbU3RyYXNzZV0gICAgICA9IFBSUy5Xb2huc2l0elN0cmFzc" +
                        "2VIYXVzTnIsDQogIFtQTFpPcnRdICAgICAgID0gUFJTLldvaG5zaXR6UExaT3J0DQpGUk9NIEJnRmluY" +
                        "W56cGxhbiAgICAgICAgICAgICAgU0ZQDQogIElOTkVSIEpPSU4gQmdCdWRnZXQgICAgICAgICAgQkJHI" +
                        "E9OIEJCRy5CZ0ZpbmFuenBsYW5JRCA9IFNGUC5CZ0ZpbmFuenBsYW5JRCBBTkQgQkJHLk1hc3RlckJ1Z" +
                        "GdldCA9IDENCiAgTEVGVCAgSk9JTiBYTE9WQ29kZSAgICAgICAgICBMVlMgT04gTFZTLkxPVk5hbWUgP" +
                        "SAnQmdCZXdpbGxpZ3VuZ1N0YXR1cycgQU5EIExWUy5Db2RlID0gU0ZQLkJnQmV3aWxsaWd1bmdTdGF0d" +
                        "XNDb2RlDQogIExFRlQgIEpPSU4gWExPVkNvZGUgICAgICAgICAgTFZUIE9OIExWVC5MT1ZOYW1lID0gJ" +
                        "1doSGlsZmVUeXAnIEFORCBMVlQuQ29kZSA9IFNGUC5XaEhpbGZlVHlwQ29kZQ0KICBJTk5FUiBKT0lOI" +
                        "EZhTGVpc3R1bmcgICAgICAgIEZBTCBPTiBGQUwuRmFMZWlzdHVuZ0lEID0gU0ZQLkZhTGVpc3R1bmdJR" +
                        "A0KICBMRUZUICBKT0lOIEZhTGVpc3R1bmdBcmNoaXYgIEZGQSBPTiBGRkEuRmFMZWlzdHVuZ0lEID0gR" +
                        "kFMLkZhTGVpc3R1bmdJRCBBTkQgRkZBLkNoZWNrT3V0IElTIE5VTEwNCiAgSU5ORVIgSk9JTiBYVXNlc" +
                        "iAgICAgICAgICAgICBVU1IgT04gVVNSLlVzZXJJRCA9IEZBTC5Vc2VySUQNCiAgSU5ORVIgSk9JTiB2d" +
                        "1BlcnNvbiAgICAgICAgICBQUlMgT04gUFJTLkJhUGVyc29uSUQgPSBGQUwuQmFQZXJzb25JRA0KV0hFU" +
                        "kUgU0ZQLkJnRmluYW56cGxhbklEID0gbnVsbA==";
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
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.ShDetaillierterFinanzplanStandard_Bewilligungsverfahren = new DevExpress.XtraReports.UI.Subreport();
            this.ShDetaillierterFinanzplanStandard_Vermoegen = new DevExpress.XtraReports.UI.Subreport();
            this.ShDetaillierterFinanzplanStandard_EinkommenAlimente = new DevExpress.XtraReports.UI.Subreport();
            this.ShDetaillierterFinanzplanStandard_EinkommenVersich = new DevExpress.XtraReports.UI.Subreport();
            this.ShDetaillierterFinanzplanStandard_Erwerbseinkommen = new DevExpress.XtraReports.UI.Subreport();
            this.ShDetaillierterFinanzplanStandard_AllgErwerbsunkosten = new DevExpress.XtraReports.UI.Subreport();
            this.ShDetaillierterFinanzplanStandard_Sil = new DevExpress.XtraReports.UI.Subreport();
            this.ShDetaillierterFinanzplanStandard_KvgVvg = new DevExpress.XtraReports.UI.Subreport();
            this.ShDetaillierterFinanzplanStandard_GBMiete = new DevExpress.XtraReports.UI.Subreport();
            this.ShDetaillierterFinanzplanStandard_Uebersicht = new DevExpress.XtraReports.UI.Subreport();
            this.ShDetaillierterFinanzplanStandard_Personen = new DevExpress.XtraReports.UI.Subreport();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.Label8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtDatumBis = new DevExpress.XtraReports.UI.XRLabel();
            this.txtDatumVon = new DevExpress.XtraReports.UI.XRLabel();
            this.Label3 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGeplantBis = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGeplantVon = new DevExpress.XtraReports.UI.XRLabel();
            this.Label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.FullName1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.txtPLZOrt = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTitel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtFullName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAnrede = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtOrgAdresse = new DevExpress.XtraReports.UI.XRLabel();
            this.txtOrgName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo3 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.ShDetaillierterFinanzplanStandard_Bewilligungsverfahren,
                        this.ShDetaillierterFinanzplanStandard_Vermoegen,
                        this.ShDetaillierterFinanzplanStandard_EinkommenAlimente,
                        this.ShDetaillierterFinanzplanStandard_EinkommenVersich,
                        this.ShDetaillierterFinanzplanStandard_Erwerbseinkommen,
                        this.ShDetaillierterFinanzplanStandard_AllgErwerbsunkosten,
                        this.ShDetaillierterFinanzplanStandard_Sil,
                        this.ShDetaillierterFinanzplanStandard_KvgVvg,
                        this.ShDetaillierterFinanzplanStandard_GBMiete,
                        this.ShDetaillierterFinanzplanStandard_Uebersicht,
                        this.ShDetaillierterFinanzplanStandard_Personen});
            this.Detail.Height = 316;
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
                        this.xrLabel6,
                        this.xrLabel5,
                        this.xrPageInfo1,
                        this.Label8,
                        this.Label7,
                        this.Label6,
                        this.Label5,
                        this.xrLabel3,
                        this.Label4,
                        this.txtDatumBis,
                        this.txtDatumVon,
                        this.Label3,
                        this.txtGeplantBis,
                        this.txtGeplantVon,
                        this.Label2,
                        this.FullName1,
                        this.TextBox1,
                        this.Line3,
                        this.Line2,
                        this.txtPLZOrt,
                        this.txtTitel,
                        this.xrLabel2,
                        this.txtFullName,
                        this.txtAnrede,
                        this.xrLabel1,
                        this.txtOrgAdresse,
                        this.txtOrgName});
            this.ReportHeader.Height = 319;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.ParentStyleUsing.UseBackColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorderColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorders = false;
            this.ReportHeader.ParentStyleUsing.UseBorderWidth = false;
            this.ReportHeader.ParentStyleUsing.UseFont = false;
            this.ReportHeader.ParentStyleUsing.UseForeColor = false;
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
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel4,
                        this.xrPageInfo3,
                        this.xrPageInfo2});
            this.PageFooter.Height = 73;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Height = 0;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // ShDetaillierterFinanzplanStandard_Bewilligungsverfahren
            // 
            this.ShDetaillierterFinanzplanStandard_Bewilligungsverfahren.Location = new System.Drawing.Point(20, 280);
            this.ShDetaillierterFinanzplanStandard_Bewilligungsverfahren.Name = "ShDetaillierterFinanzplanStandard_Bewilligungsverfahren";
            // 
            // ShDetaillierterFinanzplanStandard_Vermoegen
            // 
            this.ShDetaillierterFinanzplanStandard_Vermoegen.Location = new System.Drawing.Point(20, 253);
            this.ShDetaillierterFinanzplanStandard_Vermoegen.Name = "ShDetaillierterFinanzplanStandard_Vermoegen";
            // 
            // ShDetaillierterFinanzplanStandard_EinkommenAlimente
            // 
            this.ShDetaillierterFinanzplanStandard_EinkommenAlimente.Location = new System.Drawing.Point(20, 220);
            this.ShDetaillierterFinanzplanStandard_EinkommenAlimente.Name = "ShDetaillierterFinanzplanStandard_EinkommenAlimente";
            // 
            // ShDetaillierterFinanzplanStandard_EinkommenVersich
            // 
            this.ShDetaillierterFinanzplanStandard_EinkommenVersich.Location = new System.Drawing.Point(20, 193);
            this.ShDetaillierterFinanzplanStandard_EinkommenVersich.Name = "ShDetaillierterFinanzplanStandard_EinkommenVersich";
            // 
            // ShDetaillierterFinanzplanStandard_Erwerbseinkommen
            // 
            this.ShDetaillierterFinanzplanStandard_Erwerbseinkommen.Location = new System.Drawing.Point(20, 167);
            this.ShDetaillierterFinanzplanStandard_Erwerbseinkommen.Name = "ShDetaillierterFinanzplanStandard_Erwerbseinkommen";
            // 
            // ShDetaillierterFinanzplanStandard_AllgErwerbsunkosten
            // 
            this.ShDetaillierterFinanzplanStandard_AllgErwerbsunkosten.Location = new System.Drawing.Point(20, 140);
            this.ShDetaillierterFinanzplanStandard_AllgErwerbsunkosten.Name = "ShDetaillierterFinanzplanStandard_AllgErwerbsunkosten";
            // 
            // ShDetaillierterFinanzplanStandard_Sil
            // 
            this.ShDetaillierterFinanzplanStandard_Sil.Location = new System.Drawing.Point(20, 113);
            this.ShDetaillierterFinanzplanStandard_Sil.Name = "ShDetaillierterFinanzplanStandard_Sil";
            // 
            // ShDetaillierterFinanzplanStandard_KvgVvg
            // 
            this.ShDetaillierterFinanzplanStandard_KvgVvg.Location = new System.Drawing.Point(20, 87);
            this.ShDetaillierterFinanzplanStandard_KvgVvg.Name = "ShDetaillierterFinanzplanStandard_KvgVvg";
            // 
            // ShDetaillierterFinanzplanStandard_GBMiete
            // 
            this.ShDetaillierterFinanzplanStandard_GBMiete.Location = new System.Drawing.Point(20, 60);
            this.ShDetaillierterFinanzplanStandard_GBMiete.Name = "ShDetaillierterFinanzplanStandard_GBMiete";
            // 
            // ShDetaillierterFinanzplanStandard_Uebersicht
            // 
            this.ShDetaillierterFinanzplanStandard_Uebersicht.Location = new System.Drawing.Point(20, 33);
            this.ShDetaillierterFinanzplanStandard_Uebersicht.Name = "ShDetaillierterFinanzplanStandard_Uebersicht";
            // 
            // ShDetaillierterFinanzplanStandard_Personen
            // 
            this.ShDetaillierterFinanzplanStandard_Personen.Location = new System.Drawing.Point(20, 7);
            this.ShDetaillierterFinanzplanStandard_Personen.Name = "ShDetaillierterFinanzplanStandard_Personen";
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bemerkung", "")});
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel6.ForeColor = System.Drawing.Color.Black;
            this.xrLabel6.Location = new System.Drawing.Point(129, 295);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseBackColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorders = false;
            this.xrLabel6.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.ParentStyleUsing.UseForeColor = false;
            this.xrLabel6.Size = new System.Drawing.Size(594, 16);
            this.xrLabel6.Text = "xrLabel6";
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AHVNummer", "")});
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 11F);
            this.xrLabel5.Location = new System.Drawing.Point(300, 216);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(287, 20);
            this.xrLabel5.Text = "xrLabel5";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 10F);
            this.xrPageInfo1.Format = "{0:dd.MM.yyyy}";
            this.xrPageInfo1.Location = new System.Drawing.Point(0, 150);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(100, 20);
            // 
            // Label8
            // 
            this.Label8.Font = new System.Drawing.Font("Arial", 10F);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(333, 255);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(94, 19);
            this.Label8.Text = "(Bewilligt)";
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Arial", 10F);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(333, 240);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(94, 19);
            this.Label7.Text = "(Geplant)";
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 10F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(11, 295);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(94, 19);
            this.Label6.Text = "Bemerkungen";
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial", 10F);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(11, 279);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(94, 19);
            this.Label5.Text = "Status";
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Status", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(129, 279);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(594, 19);
            this.xrLabel3.Text = "Status";
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial", 10F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(204, 255);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(27, 19);
            this.Label4.Text = "bis";
            this.Label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // txtDatumBis
            // 
            this.txtDatumBis.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "DatumBis", "{0:dd.MM.yyyy}")});
            this.txtDatumBis.Font = new System.Drawing.Font("Arial", 10F);
            this.txtDatumBis.ForeColor = System.Drawing.Color.Black;
            this.txtDatumBis.Location = new System.Drawing.Point(232, 255);
            this.txtDatumBis.Multiline = true;
            this.txtDatumBis.Name = "txtDatumBis";
            this.txtDatumBis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtDatumBis.ParentStyleUsing.UseBackColor = false;
            this.txtDatumBis.ParentStyleUsing.UseBorderColor = false;
            this.txtDatumBis.ParentStyleUsing.UseBorders = false;
            this.txtDatumBis.ParentStyleUsing.UseBorderWidth = false;
            this.txtDatumBis.ParentStyleUsing.UseFont = false;
            this.txtDatumBis.ParentStyleUsing.UseForeColor = false;
            this.txtDatumBis.Size = new System.Drawing.Size(74, 19);
            xrSummary1.FormatString = "{0:dd.MM.yyyy}";
            this.txtDatumBis.Summary = xrSummary1;
            this.txtDatumBis.Text = "DatumBis";
            // 
            // txtDatumVon
            // 
            this.txtDatumVon.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "DatumVon", "{0:dd.MM.yyyy}")});
            this.txtDatumVon.Font = new System.Drawing.Font("Arial", 10F);
            this.txtDatumVon.ForeColor = System.Drawing.Color.Black;
            this.txtDatumVon.Location = new System.Drawing.Point(129, 255);
            this.txtDatumVon.Multiline = true;
            this.txtDatumVon.Name = "txtDatumVon";
            this.txtDatumVon.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtDatumVon.ParentStyleUsing.UseBackColor = false;
            this.txtDatumVon.ParentStyleUsing.UseBorderColor = false;
            this.txtDatumVon.ParentStyleUsing.UseBorders = false;
            this.txtDatumVon.ParentStyleUsing.UseBorderWidth = false;
            this.txtDatumVon.ParentStyleUsing.UseFont = false;
            this.txtDatumVon.ParentStyleUsing.UseForeColor = false;
            this.txtDatumVon.Size = new System.Drawing.Size(74, 19);
            xrSummary2.FormatString = "{0:dd.MM.yyyy}";
            this.txtDatumVon.Summary = xrSummary2;
            this.txtDatumVon.Text = "DatumVon";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Arial", 10F);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(204, 240);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(27, 19);
            this.Label3.Text = "bis";
            this.Label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // txtGeplantBis
            // 
            this.txtGeplantBis.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GeplantBis", "{0:dd.MM.yyyy}")});
            this.txtGeplantBis.Font = new System.Drawing.Font("Arial", 10F);
            this.txtGeplantBis.ForeColor = System.Drawing.Color.Black;
            this.txtGeplantBis.Location = new System.Drawing.Point(232, 240);
            this.txtGeplantBis.Multiline = true;
            this.txtGeplantBis.Name = "txtGeplantBis";
            this.txtGeplantBis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGeplantBis.ParentStyleUsing.UseBackColor = false;
            this.txtGeplantBis.ParentStyleUsing.UseBorderColor = false;
            this.txtGeplantBis.ParentStyleUsing.UseBorders = false;
            this.txtGeplantBis.ParentStyleUsing.UseBorderWidth = false;
            this.txtGeplantBis.ParentStyleUsing.UseFont = false;
            this.txtGeplantBis.ParentStyleUsing.UseForeColor = false;
            this.txtGeplantBis.Size = new System.Drawing.Size(74, 19);
            xrSummary3.FormatString = "{0:dd.MM.yyyy}";
            this.txtGeplantBis.Summary = xrSummary3;
            this.txtGeplantBis.Text = "GeplantBis";
            // 
            // txtGeplantVon
            // 
            this.txtGeplantVon.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GeplantVon", "{0:dd.MM.yyyy}")});
            this.txtGeplantVon.Font = new System.Drawing.Font("Arial", 10F);
            this.txtGeplantVon.ForeColor = System.Drawing.Color.Black;
            this.txtGeplantVon.Location = new System.Drawing.Point(129, 240);
            this.txtGeplantVon.Multiline = true;
            this.txtGeplantVon.Name = "txtGeplantVon";
            this.txtGeplantVon.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGeplantVon.ParentStyleUsing.UseBackColor = false;
            this.txtGeplantVon.ParentStyleUsing.UseBorderColor = false;
            this.txtGeplantVon.ParentStyleUsing.UseBorders = false;
            this.txtGeplantVon.ParentStyleUsing.UseBorderWidth = false;
            this.txtGeplantVon.ParentStyleUsing.UseFont = false;
            this.txtGeplantVon.ParentStyleUsing.UseForeColor = false;
            this.txtGeplantVon.Size = new System.Drawing.Size(74, 19);
            xrSummary4.FormatString = "{0:dd.MM.yyyy}";
            this.txtGeplantVon.Summary = xrSummary4;
            this.txtGeplantVon.Text = "GeplantVon";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 10F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(11, 240);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(94, 19);
            this.Label2.Text = "Periode vom";
            // 
            // FullName1
            // 
            this.FullName1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "FullName", "")});
            this.FullName1.Font = new System.Drawing.Font("Arial", 11F);
            this.FullName1.ForeColor = System.Drawing.Color.Black;
            this.FullName1.Location = new System.Drawing.Point(122, 216);
            this.FullName1.Multiline = true;
            this.FullName1.Name = "FullName1";
            this.FullName1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.FullName1.ParentStyleUsing.UseBackColor = false;
            this.FullName1.ParentStyleUsing.UseBorderColor = false;
            this.FullName1.ParentStyleUsing.UseBorders = false;
            this.FullName1.ParentStyleUsing.UseBorderWidth = false;
            this.FullName1.ParentStyleUsing.UseFont = false;
            this.FullName1.ParentStyleUsing.UseForeColor = false;
            this.FullName1.Size = new System.Drawing.Size(180, 19);
            this.FullName1.Text = "FullName";
            // 
            // TextBox1
            // 
            this.TextBox1.Font = new System.Drawing.Font("Arial", 11F);
            this.TextBox1.ForeColor = System.Drawing.Color.Black;
            this.TextBox1.Location = new System.Drawing.Point(11, 216);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox1.ParentStyleUsing.UseBackColor = false;
            this.TextBox1.ParentStyleUsing.UseBorderColor = false;
            this.TextBox1.ParentStyleUsing.UseBorders = false;
            this.TextBox1.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox1.ParentStyleUsing.UseFont = false;
            this.TextBox1.ParentStyleUsing.UseForeColor = false;
            this.TextBox1.Size = new System.Drawing.Size(110, 19);
            this.TextBox1.Text = "Finanzplan von ";
            // 
            // Line3
            // 
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.Location = new System.Drawing.Point(0, 177);
            this.Line3.Name = "Line3";
            this.Line3.ParentStyleUsing.UseBackColor = false;
            this.Line3.ParentStyleUsing.UseBorderColor = false;
            this.Line3.ParentStyleUsing.UseBorders = false;
            this.Line3.ParentStyleUsing.UseBorderWidth = false;
            this.Line3.ParentStyleUsing.UseFont = false;
            this.Line3.ParentStyleUsing.UseForeColor = false;
            this.Line3.Size = new System.Drawing.Size(724, 2);
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.Location = new System.Drawing.Point(0, 211);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(724, 2);
            // 
            // txtPLZOrt
            // 
            this.txtPLZOrt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "PLZOrt", "")});
            this.txtPLZOrt.Font = new System.Drawing.Font("Arial", 11F);
            this.txtPLZOrt.ForeColor = System.Drawing.Color.Black;
            this.txtPLZOrt.Location = new System.Drawing.Point(447, 130);
            this.txtPLZOrt.Multiline = true;
            this.txtPLZOrt.Name = "txtPLZOrt";
            this.txtPLZOrt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtPLZOrt.ParentStyleUsing.UseBackColor = false;
            this.txtPLZOrt.ParentStyleUsing.UseBorderColor = false;
            this.txtPLZOrt.ParentStyleUsing.UseBorders = false;
            this.txtPLZOrt.ParentStyleUsing.UseBorderWidth = false;
            this.txtPLZOrt.ParentStyleUsing.UseFont = false;
            this.txtPLZOrt.ParentStyleUsing.UseForeColor = false;
            this.txtPLZOrt.Size = new System.Drawing.Size(251, 19);
            this.txtPLZOrt.Text = "PLZOrt";
            // 
            // txtTitel
            // 
            this.txtTitel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Titel", "")});
            this.txtTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txtTitel.ForeColor = System.Drawing.Color.Black;
            this.txtTitel.Location = new System.Drawing.Point(0, 185);
            this.txtTitel.Multiline = true;
            this.txtTitel.Name = "txtTitel";
            this.txtTitel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTitel.ParentStyleUsing.UseBackColor = false;
            this.txtTitel.ParentStyleUsing.UseBorderColor = false;
            this.txtTitel.ParentStyleUsing.UseBorders = false;
            this.txtTitel.ParentStyleUsing.UseBorderWidth = false;
            this.txtTitel.ParentStyleUsing.UseFont = false;
            this.txtTitel.ParentStyleUsing.UseForeColor = false;
            this.txtTitel.Size = new System.Drawing.Size(716, 23);
            this.txtTitel.Text = "Titel";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Strasse", "")});
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 11F);
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.Location = new System.Drawing.Point(447, 110);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseBackColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorders = false;
            this.xrLabel2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.ParentStyleUsing.UseForeColor = false;
            this.xrLabel2.Size = new System.Drawing.Size(251, 19);
            this.xrLabel2.Text = "Strasse";
            // 
            // txtFullName
            // 
            this.txtFullName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "FullName", "")});
            this.txtFullName.Font = new System.Drawing.Font("Arial", 11F);
            this.txtFullName.ForeColor = System.Drawing.Color.Black;
            this.txtFullName.Location = new System.Drawing.Point(447, 90);
            this.txtFullName.Multiline = true;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtFullName.ParentStyleUsing.UseBackColor = false;
            this.txtFullName.ParentStyleUsing.UseBorderColor = false;
            this.txtFullName.ParentStyleUsing.UseBorders = false;
            this.txtFullName.ParentStyleUsing.UseBorderWidth = false;
            this.txtFullName.ParentStyleUsing.UseFont = false;
            this.txtFullName.ParentStyleUsing.UseForeColor = false;
            this.txtFullName.Size = new System.Drawing.Size(251, 19);
            this.txtFullName.Text = "FullName";
            // 
            // txtAnrede
            // 
            this.txtAnrede.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Anrede", "")});
            this.txtAnrede.Font = new System.Drawing.Font("Arial", 11F);
            this.txtAnrede.ForeColor = System.Drawing.Color.Black;
            this.txtAnrede.Location = new System.Drawing.Point(447, 71);
            this.txtAnrede.Multiline = true;
            this.txtAnrede.Name = "txtAnrede";
            this.txtAnrede.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtAnrede.ParentStyleUsing.UseBackColor = false;
            this.txtAnrede.ParentStyleUsing.UseBorderColor = false;
            this.txtAnrede.ParentStyleUsing.UseBorders = false;
            this.txtAnrede.ParentStyleUsing.UseBorderWidth = false;
            this.txtAnrede.ParentStyleUsing.UseFont = false;
            this.txtAnrede.ParentStyleUsing.UseForeColor = false;
            this.txtAnrede.Size = new System.Drawing.Size(251, 19);
            this.txtAnrede.Text = "Anrede";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "OrgPLZOrt", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.Location = new System.Drawing.Point(0, 41);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseBackColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.ParentStyleUsing.UseForeColor = false;
            this.xrLabel1.Size = new System.Drawing.Size(183, 19);
            this.xrLabel1.Text = "OrgPLZOrt";
            // 
            // txtOrgAdresse
            // 
            this.txtOrgAdresse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "OrgAdresse", "")});
            this.txtOrgAdresse.Font = new System.Drawing.Font("Arial", 10F);
            this.txtOrgAdresse.ForeColor = System.Drawing.Color.Black;
            this.txtOrgAdresse.Location = new System.Drawing.Point(0, 22);
            this.txtOrgAdresse.Multiline = true;
            this.txtOrgAdresse.Name = "txtOrgAdresse";
            this.txtOrgAdresse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOrgAdresse.ParentStyleUsing.UseBackColor = false;
            this.txtOrgAdresse.ParentStyleUsing.UseBorderColor = false;
            this.txtOrgAdresse.ParentStyleUsing.UseBorders = false;
            this.txtOrgAdresse.ParentStyleUsing.UseBorderWidth = false;
            this.txtOrgAdresse.ParentStyleUsing.UseFont = false;
            this.txtOrgAdresse.ParentStyleUsing.UseForeColor = false;
            this.txtOrgAdresse.Size = new System.Drawing.Size(183, 19);
            this.txtOrgAdresse.Text = "OrgAdresse";
            // 
            // txtOrgName
            // 
            this.txtOrgName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "OrgName", "")});
            this.txtOrgName.Font = new System.Drawing.Font("Arial", 12F);
            this.txtOrgName.ForeColor = System.Drawing.Color.Black;
            this.txtOrgName.Location = new System.Drawing.Point(0, 2);
            this.txtOrgName.Multiline = true;
            this.txtOrgName.Name = "txtOrgName";
            this.txtOrgName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOrgName.ParentStyleUsing.UseBackColor = false;
            this.txtOrgName.ParentStyleUsing.UseBorderColor = false;
            this.txtOrgName.ParentStyleUsing.UseBorders = false;
            this.txtOrgName.ParentStyleUsing.UseBorderWidth = false;
            this.txtOrgName.ParentStyleUsing.UseFont = false;
            this.txtOrgName.ParentStyleUsing.UseForeColor = false;
            this.txtOrgName.Size = new System.Drawing.Size(433, 20);
            this.txtOrgName.Text = "OrgName";
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "OrgOrt", "")});
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.Location = new System.Drawing.Point(0, 47);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.ParentStyleUsing.UseForeColor = false;
            this.xrLabel4.Size = new System.Drawing.Size(183, 19);
            this.xrLabel4.Text = "xrLabel4";
            // 
            // xrPageInfo3
            // 
            this.xrPageInfo3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrPageInfo3.Format = " {0:dd.MM.yyyy}";
            this.xrPageInfo3.Location = new System.Drawing.Point(642, 46);
            this.xrPageInfo3.Name = "xrPageInfo3";
            this.xrPageInfo3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo3.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo3.ParentStyleUsing.UseFont = false;
            this.xrPageInfo3.Size = new System.Drawing.Size(83, 20);
            this.xrPageInfo3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrPageInfo2.Format = "Seite {0} von {1}";
            this.xrPageInfo2.Location = new System.Drawing.Point(314, 46);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            this.xrPageInfo2.Size = new System.Drawing.Size(100, 20);
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
                        this.PageHeader,
                        this.PageFooter,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(59, 39, 39, 39);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' , ParameterXML =  N'<?xml version="1.0" standalone="yes" ?>
<NewDataSet>
	<Table>
		<FieldName>label</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Finanzplan ID:</DisplayText>
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
		<FieldName>BgFinanzplanID</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>Finanzplan ID</DisplayText>
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
</NewDataSet>' , SQLquery =  N'SELECT TOP 1
  [OrgName]      = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Organisation'', Getdate())), ''''),
  [OrgAdresse]   = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Adresse'', Getdate())), ''''),
  [OrgPLZOrt]    = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', Getdate())) + '' '', '''')
                 + IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', Getdate())), ''''),
  [OrgOrt]       = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', Getdate())), ''''),

  [BgFinanzplanID] = SFP.BgFinanzplanID, -- required for subreports
  [BgBudgetID]     = BBG.BgBudgetID, -- required for subreports
  [Titel]        = ''Detaillierte Verfügung '' + LVT.Text, -- LVT.Text = Typ
  [FullName]     = PRS.Name + IsNull('', '' + PRS.Vorname,'''') +  CASE LEN(IsNull(PRS.Vorname2, '''')) WHEN 0 THEN '''' ELSE '' '' + PRS.Vorname2 END,
  [AHVNummer]    = PRS.AHVNummer,
  [Status]       = LVS.Text + CASE WHEN FFA.FaLeistungID IS NOT NULL THEN '' (archiviert)'' ELSE '''' END,
  [IsUrgent]     = LVT.Value2,
  [GeplantVon]   = SFP.GeplantVon,
  [GeplantBis]   = SFP.GeplantBis,
  [DatumVon]     = SFP.DatumVon,
  [DatumBis]     = SFP.DatumBis,
  [Bemerkung]    = SFP.Bemerkung,
  [Anrede]       = CASE PRS.GeschlechtCode WHEN 2 THEN ''Frau'' ELSE ''Herrn'' END,
  [Name]         = PRS.Name,
  [Vorname]      = PRS.Vorname,
  [Strasse]      = PRS.WohnsitzStrasseHausNr,
  [PLZOrt]       = PRS.WohnsitzPLZOrt
FROM BgFinanzplan              SFP
  INNER JOIN BgBudget          BBG ON BBG.BgFinanzplanID = SFP.BgFinanzplanID AND BBG.MasterBudget = 1
  LEFT  JOIN XLOVCode          LVS ON LVS.LOVName = ''BgBewilligungStatus'' AND LVS.Code = SFP.BgBewilligungStatusCode
  LEFT  JOIN XLOVCode          LVT ON LVT.LOVName = ''WhHilfeTyp'' AND LVT.Code = SFP.WhHilfeTypCode
  INNER JOIN FaLeistung        FAL ON FAL.FaLeistungID = SFP.FaLeistungID
  LEFT  JOIN FaLeistungArchiv  FFA ON FFA.FaLeistungID = FAL.FaLeistungID AND FFA.CheckOut IS NULL
  INNER JOIN XUser             USR ON USR.UserID = FAL.UserID
  INNER JOIN vwPerson          PRS ON PRS.BaPersonID = FAL.BaPersonID
WHERE SFP.BgFinanzplanID = {BgFinanzplanID}' , ContextForms =  N'WhFinanzplan,CtlBgUebersicht,WhMonatsbudget,WhMasterbudget' , ParentReportName =  null , ReportSortKey = 6, System =  1 
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'ShDetaillierterFinanzplanStandard' ;


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'ShDetaillierterFinanzplanStandard_AllgErwerbsunkosten' ,  N'Allgemeine Erwerbsunkosten' , 1,  N'<!--
AssemblyName=DevExpress%2EXtraReports%2C%20Version%3D1%2E7%2E9%2E0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4
AssemblyLocation=c:\windows\assembly\gac\devexpress.xtrareports\1.7.9.0__79868b8147b5eae4\devexpress.xtrareports.dll
TypeName=DevExpress.XtraReports.UI.XtraReport
Localization=de-CH
-->
<SOAP-ENV:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:SOAP-ENC="http://schemas.xmlsoap.org/soap/encoding/" xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/" xmlns:clr="http://schemas.microsoft.com/soap/encoding/clr/1.0" SOAP-ENV:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
<SOAP-ENV:Body>
<a1:ReportStorage id="ref-1" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<BandCount>5</BandCount>
<Band0 href="#ref-6"/>
<Band1 href="#ref-7"/>
<Band2 href="#ref-8"/>
<Band3 href="#ref-9"/>
<Band4 href="#ref-10"/>
<Visible>true</Visible>
<Tag id="ref-11"></Tag>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-12">Report</Name>
<Style_X_Font id="ref-13">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor id="ref-14">ControlText</Style_X_ForeColor>
<Style_X_BackColor id="ref-15">Transparent</Style_X_BackColor>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>100</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<DataSource id="ref-16">dataSource</DataSource>
<UseDefaultPrinterSettings>false</UseDefaultPrinterSettings>
<ReportUnit xsi:type="a2:ReportUnit" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">HundredthsOfAnInch</ReportUnit>
<Landscape>false</Landscape>
<PaperKind xsi:type="a5:PaperKind" xmlns:a5="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Printing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">A4</PaperKind>
<PaperName href="#ref-11"/>
<Margins xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>39</x>
<y>39</y>
<width>42</width>
<height>39</height>
</Margins>
<HtmlCompressed>false</HtmlCompressed>
<PageSize xsi:type="a4:Size" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<width>827</width>
<height>1169</height>
</PageSize>
<StyleSheet_X_StyleCount>0</StyleSheet_X_StyleCount>
<ShowPreviewMarginLines>true</ShowPreviewMarginLines>
<ScriptLanguage xsi:type="a6:ScriptLanguage" xmlns:a6="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">CSharp</ScriptLanguage>
<Watermark_X_Text href="#ref-11"/>
<Watermark_X_Font id="ref-17">Verdana, 36pt</Watermark_X_Font>
<Watermark_X_ForeColor id="ref-18">Red</Watermark_X_ForeColor>
<Watermark_X_Transparency>50</Watermark_X_Transparency>
<Watermark_X_TextDirection xsi:type="a7:DirectionMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">ForwardDiagonal</Watermark_X_TextDirection>
<Watermark_X_Image xsi:type="xsd:anyType" xsi:null="1"/>
<Watermark_X_ImageAlign xsi:type="a4:ContentAlignment" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">MiddleCenter</Watermark_X_ImageAlign>
<Watermark_X_ImageViewMode xsi:type="a7:ImageViewMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Clip</Watermark_X_ImageViewMode>
<Watermark_X_ImageTiling>false</Watermark_X_ImageTiling>
<Watermark_X_PageRange href="#ref-11"/>
<Watermark_X_ShowBehind>true</Watermark_X_ShowBehind>
<DefaultPrinterSettingsUsing_X_UseMargins>false</DefaultPrinterSettingsUsing_X_UseMargins>
<DefaultPrinterSettingsUsing_X_UsePaperKind>false</DefaultPrinterSettingsUsing_X_UsePaperKind>
<DefaultPrinterSettingsUsing_X_UseLandscape>false</DefaultPrinterSettingsUsing_X_UseLandscape>
<ShrinkSubReportIconArea>true</ShrinkSubReportIconArea>
</a1:ReportStorage>
<a1:ObjectStorage id="ref-6" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName id="ref-19">DevExpress.XtraReports, Version=1.7.9.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</Type_X_AssemblyName>
<Type_X_TypeName id="ref-20">DevExpress.XtraReports.UI.DetailBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-21">Detail</Name>
<Style_X_Font id="ref-22">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>34</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<PrintOnEmptyDataSource>true</PrintOnEmptyDataSource>
<MultiColumn_X_ColumnCount>1</MultiColumn_X_ColumnCount>
<MultiColumn_X_Direction xsi:type="a2:ColumnDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">DownThenAcross</MultiColumn_X_Direction>
<MultiColumn_X_ColumnWidth>0</MultiColumn_X_ColumnWidth>
<MultiColumn_X_ColumnSpacing>0</MultiColumn_X_ColumnSpacing>
<MultiColumn_X_Mode xsi:type="a2:MultiColumnMode" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">UseColumnCount</MultiColumn_X_Mode>
<RepeatCountOnEmptyDataSource>1</RepeatCountOnEmptyDataSource>
<ItemCount>4</ItemCount>
<Item0 href="#ref-23"/>
<Item1 href="#ref-24"/>
<Item2 href="#ref-25"/>
<Item3 href="#ref-26"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-7" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-27">DevExpress.XtraReports.UI.PageHeaderBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-28">PageHeader</Name>
<Style_X_Font id="ref-29">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>40</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>1</ItemCount>
<Item0 href="#ref-30"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-8" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-31">DevExpress.XtraReports.UI.GroupHeaderBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-32">GroupHeader1</Name>
<Style_X_Font id="ref-33">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>70</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<Level>0</Level>
<RepeatEveryPage>false</RepeatEveryPage>
<GroupFieldCount>0</GroupFieldCount>
<GroupUnion xsi:type="a2:GroupUnion" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</GroupUnion>
<ItemCount>5</ItemCount>
<Item0 href="#ref-34"/>
<Item1 href="#ref-35"/>
<Item2 href="#ref-36"/>
<Item3 href="#ref-37"/>
<Item4 href="#ref-38"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-9" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-39">DevExpress.XtraReports.UI.GroupFooterBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-40">GroupFooter1</Name>
<Style_X_Font id="ref-41">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>62</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<Level>0</Level>
<RepeatEveryPage>false</RepeatEveryPage>
<GroupUnion xsi:type="a2:GroupFooterUnion" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</GroupUnion>
<PrintAtBottom>false</PrintAtBottom>
<ItemCount>6</ItemCount>
<Item0 href="#ref-42"/>
<Item1 href="#ref-43"/>
<Item2 href="#ref-44"/>
<Item3 href="#ref-45"/>
<Item4 href="#ref-46"/>
<Item5 href="#ref-47"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-10" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-48">DevExpress.XtraReports.UI.PageFooterBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-49">PageFooter</Name>
<Style_X_Font id="ref-50">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>0</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-23" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-51">DevExpress.XtraReports.UI.XRLabel</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-52">txtBemerkungRTF</Name>
<Style_X_Font id="ref-53">Arial, 10pt, style=Italic</Style_X_Font>
<Style_X_ForeColor id="ref-54">Black</Style_X_ForeColor>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName id="ref-55">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-56">BemerkungRTF</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>15</y>
<width>693</width>
<height>19</height>
</Bounds>
<Text id="ref-57">BemerkungRTF</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>true</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-24" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-51"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-58">txtBetrag</Name>
<Style_X_Font id="ref-59">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-54"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-55"/>
<BindingItem0_X_DataMember id="ref-60">Betrag</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-61">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>620</x>
<y>0</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-62">Betrag</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-63">{0:#,##0.00}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-25" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-51"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-64">txtGrad</Name>
<Style_X_Font id="ref-65">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-54"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-55"/>
<BindingItem0_X_DataMember id="ref-66">Grad</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-67">{0}%</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>500</x>
<y>0</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-68">Grad</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-69">{0:0\%}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-26" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-51"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-70">txtNamePerson</Name>
<Style_X_Font id="ref-71">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-54"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-55"/>
<BindingItem0_X_DataMember id="ref-72">NamePerson</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>0</y>
<width>486</width>
<height>19</height>
</Bounds>
<Text id="ref-73">NamePerson</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-30" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-74">DevExpress.XtraReports.UI.XRPanel</Type_X_TypeName>
<Visible>false</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-75">hiderPanel</Name>
<Style_X_Font id="ref-76">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>393</x>
<y>0</y>
<width>300</width>
<height>40</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<ItemCount>1</ItemCount>
<Item0 href="#ref-77"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-34" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-51"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-78">xrLabel2</Name>
<Style_X_Font id="ref-79">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>true</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>true</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>true</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>true</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>true</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>40</y>
<width>100</width>
<height>20</height>
</Bounds>
<Text id="ref-80">Betrifft</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-35" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-81">DevExpress.XtraReports.UI.XRLine</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-82">xrLine1</Name>
<Style_X_Font id="ref-83">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-54"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>7</x>
<y>67</y>
<width>686</width>
<height>3</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-36" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-51"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-84">xrLabel4</Name>
<Style_X_Font id="ref-85">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>true</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>true</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>true</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>true</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>true</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>593</x>
<y>40</y>
<width>100</width>
<height>20</height>
</Bounds>
<Text id="ref-86">Betrag</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-37" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-51"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-87">xrLabel3</Name>
<Style_X_Font id="ref-88">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>true</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>true</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>true</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>true</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>true</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>353</x>
<y>40</y>
<width>227</width>
<height>27</height>
</Bounds>
<Text id="ref-89">Prozentuale Arbeitsauslastung</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-38" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-51"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-90">xrLabel1</Name>
<Style_X_Font id="ref-91">Arial, 10pt, style=Bold, Underline</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
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
<width>227</width>
<height>27</height>
</Bounds>
<Text id="ref-92">Allgemeine Erwerbsunkosten</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-42" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-81"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-93">Line4</Name>
<Style_X_Font id="ref-94">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-54"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>527</x>
<y>27</y>
<width>173</width>
<height>2</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-43" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-81"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-95">Line3</Name>
<Style_X_Font id="ref-96">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-54"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>527</x>
<y>23</y>
<width>173</width>
<height>2</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-44" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-81"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-97">Line2</Name>
<Style_X_Font id="ref-98">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-54"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>7</x>
<y>0</y>
<width>686</width>
<height>3</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-45" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-51"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-99">txtTotGrad</Name>
<Style_X_Font id="ref-100">Arial, 10pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-54"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName id="ref-101">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-102">Grad</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-103">{0}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>500</x>
<y>3</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-104">txtTotGrad</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-105">{0}%</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Group</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-46" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-51"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-106">txtTotBetrag</Name>
<Style_X_Font id="ref-107">Arial, 10pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-54"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-55"/>
<BindingItem0_X_DataMember id="ref-108">Betrag</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>620</x>
<y>3</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-109">txtTotBetrag</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-110">{0:n2}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Group</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-47" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-51"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-111">Label5</Name>
<Style_X_Font id="ref-112">Arial, 10pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-54"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<x>80</x>
<y>3</y>
<width>425</width>
<height>19</height>
</Bounds>
<Text id="ref-113">Gesamte allgemeine Erwerbsunkosten</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-77" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-51"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-114">hiderTxtBemerkungRTF</Name>
<Style_X_Font id="ref-115">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-116">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-117">BemerkungRTF</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>20</x>
<y>0</y>
<width>100</width>
<height>20</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<EventsScript_X_OnAfterPrint id="ref-118">private void OnAfterPrint(object sender, System.EventArgs e) {
  
txtBemerkungRTF.Visible = hiderTxtBemerkungRTF.Text != String.Empty;
}</EventsScript_X_OnAfterPrint>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
</SOAP-ENV:Body>
</SOAP-ENV:Envelope>' ,  null ,  N'DECLARE @BgBudgetID int

SELECT @BgBudgetID = BgBudgetID
FROM BgBudget
WHERE BgFinanzplanID = {BgFinanzplanID} AND MasterBudget = 1

SELECT BPO.*,
  NamePerson   = PRS.Name + IsNull('', '' + PRS.Vorname, ''''),
  Geburtsdatum = CONVERT(varchar, PRS.Geburtsdatum, 104),
  Grad         = CAST(100 * BPO.Betrag / BPO.MaxBeitragSD AS int)
FROM BgPosition        BPO
  INNER JOIN BgPositionsart POA ON POA.BgPositionsartID = BPO.BgPositionsartID
  LEFT  JOIN BaPerson  PRS ON PRS.BaPersonID = BPO.BaPersonID
WHERE BPO.BgBudgetID = @BgBudgetID AND POA.BgPositionsartCode = 32031
  AND BPO.DatumVon IS NULL' ,  null ,  N'ShDetaillierterFinanzplanStandard' ,  null ,  1 );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'ShDetaillierterFinanzplanStandard_Bewilligungsverfahren' ,  N'Bewilligungsverfahren' , 1,  N'<!--
AssemblyName=DevExpress%2EXtraReports%2C%20Version%3D1%2E7%2E9%2E0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4
AssemblyLocation=c:\windows\assembly\gac\devexpress.xtrareports\1.7.9.0__79868b8147b5eae4\devexpress.xtrareports.dll
TypeName=DevExpress.XtraReports.UI.XtraReport
Localization=de-CH
-->
<SOAP-ENV:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:SOAP-ENC="http://schemas.xmlsoap.org/soap/encoding/" xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/" xmlns:clr="http://schemas.microsoft.com/soap/encoding/clr/1.0" SOAP-ENV:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
<SOAP-ENV:Body>
<a1:ReportStorage id="ref-1" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<BandCount>5</BandCount>
<Band0 href="#ref-6"/>
<Band1 href="#ref-7"/>
<Band2 href="#ref-8"/>
<Band3 href="#ref-9"/>
<Band4 href="#ref-10"/>
<Visible>true</Visible>
<Tag id="ref-11"></Tag>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-12">Report</Name>
<Style_X_Font id="ref-13">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor id="ref-14">ControlText</Style_X_ForeColor>
<Style_X_BackColor id="ref-15">Transparent</Style_X_BackColor>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>100</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<DataSource id="ref-16">dataSource</DataSource>
<UseDefaultPrinterSettings>false</UseDefaultPrinterSettings>
<ReportUnit xsi:type="a2:ReportUnit" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">HundredthsOfAnInch</ReportUnit>
<Landscape>false</Landscape>
<PaperKind xsi:type="a5:PaperKind" xmlns:a5="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Printing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">A4</PaperKind>
<PaperName href="#ref-11"/>
<Margins xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>39</x>
<y>39</y>
<width>76</width>
<height>39</height>
</Margins>
<HtmlCompressed>false</HtmlCompressed>
<PageSize xsi:type="a4:Size" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<width>827</width>
<height>1169</height>
</PageSize>
<StyleSheet_X_StyleCount>0</StyleSheet_X_StyleCount>
<ShowPreviewMarginLines>true</ShowPreviewMarginLines>
<ScriptLanguage xsi:type="a6:ScriptLanguage" xmlns:a6="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">CSharp</ScriptLanguage>
<Watermark_X_Text href="#ref-11"/>
<Watermark_X_Font id="ref-17">Verdana, 36pt</Watermark_X_Font>
<Watermark_X_ForeColor id="ref-18">Red</Watermark_X_ForeColor>
<Watermark_X_Transparency>50</Watermark_X_Transparency>
<Watermark_X_TextDirection xsi:type="a7:DirectionMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">ForwardDiagonal</Watermark_X_TextDirection>
<Watermark_X_Image xsi:type="xsd:anyType" xsi:null="1"/>
<Watermark_X_ImageAlign xsi:type="a4:ContentAlignment" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">MiddleCenter</Watermark_X_ImageAlign>
<Watermark_X_ImageViewMode xsi:type="a7:ImageViewMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Clip</Watermark_X_ImageViewMode>
<Watermark_X_ImageTiling>false</Watermark_X_ImageTiling>
<Watermark_X_PageRange href="#ref-11"/>
<Watermark_X_ShowBehind>true</Watermark_X_ShowBehind>
<DefaultPrinterSettingsUsing_X_UseMargins>false</DefaultPrinterSettingsUsing_X_UseMargins>
<DefaultPrinterSettingsUsing_X_UsePaperKind>false</DefaultPrinterSettingsUsing_X_UsePaperKind>
<DefaultPrinterSettingsUsing_X_UseLandscape>false</DefaultPrinterSettingsUsing_X_UseLandscape>
<ShrinkSubReportIconArea>true</ShrinkSubReportIconArea>
</a1:ReportStorage>
<a1:ObjectStorage id="ref-6" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName id="ref-19">DevExpress.XtraReports, Version=1.7.9.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</Type_X_AssemblyName>
<Type_X_TypeName id="ref-20">DevExpress.XtraReports.UI.DetailBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-21">Detail</Name>
<Style_X_Font id="ref-22">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>34</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<PrintOnEmptyDataSource>true</PrintOnEmptyDataSource>
<MultiColumn_X_ColumnCount>1</MultiColumn_X_ColumnCount>
<MultiColumn_X_Direction xsi:type="a2:ColumnDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">DownThenAcross</MultiColumn_X_Direction>
<MultiColumn_X_ColumnWidth>0</MultiColumn_X_ColumnWidth>
<MultiColumn_X_ColumnSpacing>0</MultiColumn_X_ColumnSpacing>
<MultiColumn_X_Mode xsi:type="a2:MultiColumnMode" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">UseColumnCount</MultiColumn_X_Mode>
<RepeatCountOnEmptyDataSource>1</RepeatCountOnEmptyDataSource>
<ItemCount>5</ItemCount>
<Item0 href="#ref-23"/>
<Item1 href="#ref-24"/>
<Item2 href="#ref-25"/>
<Item3 href="#ref-26"/>
<Item4 href="#ref-27"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-7" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-28">DevExpress.XtraReports.UI.PageHeaderBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-29">PageHeader</Name>
<Style_X_Font id="ref-30">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>75</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>1</ItemCount>
<Item0 href="#ref-31"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-8" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-32">DevExpress.XtraReports.UI.GroupHeaderBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-33">GroupHeader1</Name>
<Style_X_Font id="ref-34">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>70</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<Level>0</Level>
<RepeatEveryPage>false</RepeatEveryPage>
<GroupFieldCount>1</GroupFieldCount>
<GroupField0_X_FieldName id="ref-35">SilTypName</GroupField0_X_FieldName>
<GroupField0_X_SortOrder xsi:type="a2:XRColumnSortOrder" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Ascending</GroupField0_X_SortOrder>
<GroupUnion xsi:type="a2:GroupUnion" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</GroupUnion>
<ItemCount>6</ItemCount>
<Item0 href="#ref-36"/>
<Item1 href="#ref-37"/>
<Item2 href="#ref-38"/>
<Item3 href="#ref-39"/>
<Item4 href="#ref-40"/>
<Item5 href="#ref-41"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-9" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-42">DevExpress.XtraReports.UI.GroupFooterBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-43">GroupFooter1</Name>
<Style_X_Font id="ref-44">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>20</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<Level>0</Level>
<RepeatEveryPage>false</RepeatEveryPage>
<GroupUnion xsi:type="a2:GroupFooterUnion" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</GroupUnion>
<PrintAtBottom>false</PrintAtBottom>
<ItemCount>1</ItemCount>
<Item0 href="#ref-45"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-10" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-46">DevExpress.XtraReports.UI.PageFooterBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-47">PageFooter</Name>
<Style_X_Font id="ref-48">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>0</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-23" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-49">DevExpress.XtraReports.UI.XRLabel</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-50">txtEmpfaenger</Name>
<Style_X_Font id="ref-51">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor id="ref-52">Black</Style_X_ForeColor>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName id="ref-53">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-54">Empfaenger</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>540</x>
<y>0</y>
<width>167</width>
<height>19</height>
</Bounds>
<Text id="ref-55">Empfaenger</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-24" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-49"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-56">txtAbsender</Name>
<Style_X_Font id="ref-57">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-52"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-53"/>
<BindingItem0_X_DataMember id="ref-58">Absender</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>354</x>
<y>0</y>
<width>180</width>
<height>19</height>
</Bounds>
<Text id="ref-59">Absender</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-25" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-49"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-60">txtVorgang</Name>
<Style_X_Font id="ref-61">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-52"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-53"/>
<BindingItem0_X_DataMember id="ref-62">Vorgang</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>125</x>
<y>0</y>
<width>228</width>
<height>19</height>
</Bounds>
<Text id="ref-63">Vorgang</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-26" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-49"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-64">txtDatum</Name>
<Style_X_Font id="ref-65">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-52"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-53"/>
<BindingItem0_X_DataMember id="ref-66">Datum</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-67">{0:dd.MM.yyyy}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>0</y>
<width>118</width>
<height>19</height>
</Bounds>
<Text id="ref-68">Datum</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-69">{0:dd.MM.yyyy}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-27" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-49"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-70">txtBemerkungRTF</Name>
<Style_X_Font id="ref-71">Arial, 10pt, style=Italic</Style_X_Font>
<Style_X_ForeColor href="#ref-52"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-53"/>
<BindingItem0_X_DataMember id="ref-72">BemerkungRTF</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>15</y>
<width>693</width>
<height>19</height>
</Bounds>
<Text id="ref-73">BemerkungRTF</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-31" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-74">DevExpress.XtraReports.UI.XRPanel</Type_X_TypeName>
<Visible>false</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-75">hiderPanel</Name>
<Style_X_Font id="ref-76">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>173</x>
<y>0</y>
<width>300</width>
<height>74</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<ItemCount>1</ItemCount>
<Item0 href="#ref-77"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-36" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-49"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-78">Label5</Name>
<Style_X_Font id="ref-79">Arial, 10pt, style=Bold, Underline</Style_X_Font>
<Style_X_ForeColor href="#ref-52"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<width>366</width>
<height>19</height>
</Bounds>
<Text id="ref-80">Bewilligungsverfahren</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-37" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-81">DevExpress.XtraReports.UI.XRLine</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-82">Line1</Name>
<Style_X_Font id="ref-83">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-52"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>7</x>
<y>47</y>
<width>700</width>
<height>2</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-38" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-49"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-84">Label2</Name>
<Style_X_Font id="ref-85">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-52"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>125</x>
<y>27</y>
<width>228</width>
<height>19</height>
</Bounds>
<Text id="ref-86">Vorgang</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-39" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-49"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-87">Label1</Name>
<Style_X_Font id="ref-88">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-52"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>7</x>
<y>27</y>
<width>118</width>
<height>19</height>
</Bounds>
<Text id="ref-89">Datum</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-40" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-49"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-90">Label6</Name>
<Style_X_Font id="ref-91">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-52"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>354</x>
<y>27</y>
<width>180</width>
<height>19</height>
</Bounds>
<Text id="ref-92">Veranlasst durch</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-41" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-49"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-93">Label7</Name>
<Style_X_Font id="ref-94">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-52"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>540</x>
<y>27</y>
<width>167</width>
<height>19</height>
</Bounds>
<Text id="ref-95">Mitteilung an</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-45" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-81"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-96">Line5</Name>
<Style_X_Font id="ref-97">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-52"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>7</x>
<y>0</y>
<width>700</width>
<height>2</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-77" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-49"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-98">hiderTxtBemerkungRTF</Name>
<Style_X_Font id="ref-99">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-100">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-101">BemerkungRTF</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>53</x>
<y>13</y>
<width>100</width>
<height>20</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<EventsScript_X_OnAfterPrint id="ref-102">private void OnAfterPrint(object sender, System.EventArgs e) {
   txtBemerkungRTF.Visible = hiderTxtBemerkungRTF.Text != String.Empty;
}</EventsScript_X_OnAfterPrint>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
</SOAP-ENV:Body>
</SOAP-ENV:Envelope>' ,  null ,  N'SELECT BBW.*,
  Absender   = ABS.LastName + IsNull('', '' + ABS.FirstName, ''''),
  Empfaenger = EMP.LastName + IsNull('', '' + EMP.FirstName, ''''),
  Vorgang    = LOV.Text
FROM BgBewilligung    BBW
  INNER JOIN XUser    ABS   ON ABS.UserID = BBW.UserID
  LEFT  JOIN XUser    EMP   ON EMP.UserID = BBW.UserID_An
  INNER JOIN XLOVCode LOV ON LOV.LOVName=''BgBewilligung'' AND LOV.Code = BBW.BgBewilligungCode
WHERE BBW.BgFinanzplanID = {BgFinanzplanID}
ORDER BY BBW.Datum' ,  null ,  N'ShDetaillierterFinanzplanStandard' ,  null ,  1 );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'ShDetaillierterFinanzplanStandard_EinkommenAlimente' ,  N'Einkommen aus Alimenten' , 1,  N'<!--
AssemblyName=DevExpress%2EXtraReports%2C%20Version%3D1%2E7%2E9%2E0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4
AssemblyLocation=c:\windows\assembly\gac\devexpress.xtrareports\1.7.9.0__79868b8147b5eae4\devexpress.xtrareports.dll
TypeName=DevExpress.XtraReports.UI.XtraReport
Localization=de-CH
-->
<SOAP-ENV:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:SOAP-ENC="http://schemas.xmlsoap.org/soap/encoding/" xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/" xmlns:clr="http://schemas.microsoft.com/soap/encoding/clr/1.0" SOAP-ENV:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
<SOAP-ENV:Body>
<a1:ReportStorage id="ref-1" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<BandCount>5</BandCount>
<Band0 href="#ref-6"/>
<Band1 href="#ref-7"/>
<Band2 href="#ref-8"/>
<Band3 href="#ref-9"/>
<Band4 href="#ref-10"/>
<Visible>true</Visible>
<Tag id="ref-11"></Tag>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-12">Report</Name>
<Style_X_Font id="ref-13">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor id="ref-14">ControlText</Style_X_ForeColor>
<Style_X_BackColor id="ref-15">Transparent</Style_X_BackColor>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>100</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<DataSource id="ref-16">dataSource</DataSource>
<UseDefaultPrinterSettings>false</UseDefaultPrinterSettings>
<ReportUnit xsi:type="a2:ReportUnit" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">HundredthsOfAnInch</ReportUnit>
<Landscape>false</Landscape>
<PaperKind xsi:type="a5:PaperKind" xmlns:a5="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Printing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">A4</PaperKind>
<PaperName href="#ref-11"/>
<Margins xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>39</x>
<y>39</y>
<width>78</width>
<height>39</height>
</Margins>
<HtmlCompressed>false</HtmlCompressed>
<PageSize xsi:type="a4:Size" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<width>827</width>
<height>1169</height>
</PageSize>
<StyleSheet_X_StyleCount>0</StyleSheet_X_StyleCount>
<ShowPreviewMarginLines>true</ShowPreviewMarginLines>
<ScriptLanguage xsi:type="a6:ScriptLanguage" xmlns:a6="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">CSharp</ScriptLanguage>
<Watermark_X_Text href="#ref-11"/>
<Watermark_X_Font id="ref-17">Verdana, 36pt</Watermark_X_Font>
<Watermark_X_ForeColor id="ref-18">Red</Watermark_X_ForeColor>
<Watermark_X_Transparency>50</Watermark_X_Transparency>
<Watermark_X_TextDirection xsi:type="a7:DirectionMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">ForwardDiagonal</Watermark_X_TextDirection>
<Watermark_X_Image xsi:type="xsd:anyType" xsi:null="1"/>
<Watermark_X_ImageAlign xsi:type="a4:ContentAlignment" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">MiddleCenter</Watermark_X_ImageAlign>
<Watermark_X_ImageViewMode xsi:type="a7:ImageViewMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Clip</Watermark_X_ImageViewMode>
<Watermark_X_ImageTiling>false</Watermark_X_ImageTiling>
<Watermark_X_PageRange href="#ref-11"/>
<Watermark_X_ShowBehind>true</Watermark_X_ShowBehind>
<DefaultPrinterSettingsUsing_X_UseMargins>false</DefaultPrinterSettingsUsing_X_UseMargins>
<DefaultPrinterSettingsUsing_X_UsePaperKind>false</DefaultPrinterSettingsUsing_X_UsePaperKind>
<DefaultPrinterSettingsUsing_X_UseLandscape>false</DefaultPrinterSettingsUsing_X_UseLandscape>
<ShrinkSubReportIconArea>true</ShrinkSubReportIconArea>
</a1:ReportStorage>
<a1:ObjectStorage id="ref-6" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName id="ref-19">DevExpress.XtraReports, Version=1.7.9.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</Type_X_AssemblyName>
<Type_X_TypeName id="ref-20">DevExpress.XtraReports.UI.DetailBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-21">Detail</Name>
<Style_X_Font id="ref-22">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>40</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<PrintOnEmptyDataSource>true</PrintOnEmptyDataSource>
<MultiColumn_X_ColumnCount>1</MultiColumn_X_ColumnCount>
<MultiColumn_X_Direction xsi:type="a2:ColumnDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">DownThenAcross</MultiColumn_X_Direction>
<MultiColumn_X_ColumnWidth>0</MultiColumn_X_ColumnWidth>
<MultiColumn_X_ColumnSpacing>0</MultiColumn_X_ColumnSpacing>
<MultiColumn_X_Mode xsi:type="a2:MultiColumnMode" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">UseColumnCount</MultiColumn_X_Mode>
<RepeatCountOnEmptyDataSource>1</RepeatCountOnEmptyDataSource>
<ItemCount>6</ItemCount>
<Item0 href="#ref-23"/>
<Item1 href="#ref-24"/>
<Item2 href="#ref-25"/>
<Item3 href="#ref-26"/>
<Item4 href="#ref-27"/>
<Item5 href="#ref-28"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-7" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-29">DevExpress.XtraReports.UI.PageHeaderBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-30">PageHeader</Name>
<Style_X_Font id="ref-31">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>40</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>1</ItemCount>
<Item0 href="#ref-32"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-8" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-33">DevExpress.XtraReports.UI.GroupHeaderBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-34">GroupHeader1</Name>
<Style_X_Font id="ref-35">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>70</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<Level>0</Level>
<RepeatEveryPage>false</RepeatEveryPage>
<GroupFieldCount>1</GroupFieldCount>
<GroupField0_X_FieldName id="ref-36">SilTypName</GroupField0_X_FieldName>
<GroupField0_X_SortOrder xsi:type="a2:XRColumnSortOrder" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Ascending</GroupField0_X_SortOrder>
<GroupUnion xsi:type="a2:GroupUnion" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</GroupUnion>
<ItemCount>7</ItemCount>
<Item0 href="#ref-37"/>
<Item1 href="#ref-38"/>
<Item2 href="#ref-39"/>
<Item3 href="#ref-40"/>
<Item4 href="#ref-41"/>
<Item5 href="#ref-42"/>
<Item6 href="#ref-43"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-9" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-44">DevExpress.XtraReports.UI.GroupFooterBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-45">GroupFooter1</Name>
<Style_X_Font id="ref-46">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>78</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<Level>0</Level>
<RepeatEveryPage>false</RepeatEveryPage>
<GroupUnion xsi:type="a2:GroupFooterUnion" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</GroupUnion>
<PrintAtBottom>false</PrintAtBottom>
<ItemCount>7</ItemCount>
<Item0 href="#ref-47"/>
<Item1 href="#ref-48"/>
<Item2 href="#ref-49"/>
<Item3 href="#ref-50"/>
<Item4 href="#ref-51"/>
<Item5 href="#ref-52"/>
<Item6 href="#ref-53"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-10" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName id="ref-54">DevExpress.XtraReports, Version=1.7.9.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</Type_X_AssemblyName>
<Type_X_TypeName id="ref-55">DevExpress.XtraReports.UI.PageFooterBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-56">PageFooter</Name>
<Style_X_Font id="ref-57">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>0</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-23" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName id="ref-58">DevExpress.XtraReports, Version=1.7.9.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</Type_X_AssemblyName>
<Type_X_TypeName id="ref-59">DevExpress.XtraReports.UI.XRLabel</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-60">txtAlimentenTyp</Name>
<Style_X_Font id="ref-61">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor id="ref-62">Black</Style_X_ForeColor>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName id="ref-63">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-64">AlimentenTyp</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource id="ref-65">dataSource</BindingItem0_X_DataSource>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>216</x>
<y>0</y>
<width>226</width>
<height>19</height>
</Bounds>
<Text id="ref-66">AlimentenTyp</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>false</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-24" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName href="#ref-59"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-67">txtBewertungAls</Name>
<Style_X_Font id="ref-68">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-62"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-63"/>
<BindingItem0_X_DataMember id="ref-69">BewertungAls</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-65"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>540</x>
<y>0</y>
<width>86</width>
<height>19</height>
</Bounds>
<Text id="ref-70">BewertungAls</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-25" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName href="#ref-59"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-71">txtVerwaltungDurch</Name>
<Style_X_Font id="ref-72">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-62"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-63"/>
<BindingItem0_X_DataMember id="ref-73">VerwaltungDurch</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-65"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>440</x>
<y>0</y>
<width>94</width>
<height>19</height>
</Bounds>
<Text id="ref-74">VerwaltungDurch</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-26" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName href="#ref-59"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-75">txtBetrag</Name>
<Style_X_Font id="ref-76">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-62"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-63"/>
<BindingItem0_X_DataMember id="ref-77">Betrag</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-78">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-65"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>627</x>
<y>0</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-79">Betrag</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-80">{0:#,##0.00}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-27" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName href="#ref-59"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-81">txtNamePerson</Name>
<Style_X_Font id="ref-82">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-62"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-63"/>
<BindingItem0_X_DataMember id="ref-83">NamePerson</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-65"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>0</y>
<width>208</width>
<height>19</height>
</Bounds>
<Text id="ref-84">NamePerson</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-28" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName href="#ref-59"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-85">txtBemerkungRTF</Name>
<Style_X_Font id="ref-86">Arial, 10pt, style=Italic</Style_X_Font>
<Style_X_ForeColor href="#ref-62"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-63"/>
<BindingItem0_X_DataMember id="ref-87">BemerkungRTF</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-65"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>15</y>
<width>693</width>
<height>19</height>
</Bounds>
<Text id="ref-88">BemerkungRTF</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-32" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName id="ref-89">DevExpress.XtraReports.UI.XRPanel</Type_X_TypeName>
<Visible>false</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-90">hiderPanel</Name>
<Style_X_Font id="ref-91">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>167</x>
<y>0</y>
<width>300</width>
<height>40</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<ItemCount>1</ItemCount>
<Item0 href="#ref-92"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-37" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName href="#ref-59"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-93">Label5</Name>
<Style_X_Font id="ref-94">Arial, 10pt, style=Bold, Underline</Style_X_Font>
<Style_X_ForeColor href="#ref-62"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<width>366</width>
<height>19</height>
</Bounds>
<Text id="ref-95">Einkommen aus Alimenteguthaben</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-38" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName id="ref-96">DevExpress.XtraReports.UI.XRLine</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-97">Line1</Name>
<Style_X_Font id="ref-98">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-62"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>7</x>
<y>47</y>
<width>700</width>
<height>2</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-39" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName href="#ref-59"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-99">Label3</Name>
<Style_X_Font id="ref-100">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-62"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<x>627</x>
<y>27</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-101">Betrag</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-40" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName href="#ref-59"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-102">Label2</Name>
<Style_X_Font id="ref-103">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-62"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>216</x>
<y>27</y>
<width>226</width>
<height>19</height>
</Bounds>
<Text id="ref-104">Art des Alimenteguthabens</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-41" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName href="#ref-59"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-105">Label1</Name>
<Style_X_Font id="ref-106">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-62"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>7</x>
<y>27</y>
<width>208</width>
<height>19</height>
</Bounds>
<Text id="ref-107">Betrifft</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-42" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName href="#ref-59"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-108">Label6</Name>
<Style_X_Font id="ref-109">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-62"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>440</x>
<y>27</y>
<width>94</width>
<height>19</height>
</Bounds>
<Text id="ref-110">Inkasso durch</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-43" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName href="#ref-59"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-111">Label7</Name>
<Style_X_Font id="ref-112">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-62"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>540</x>
<y>27</y>
<width>86</width>
<height>19</height>
</Bounds>
<Text id="ref-113">Bewertet als</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-47" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName href="#ref-59"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-114">Label8</Name>
<Style_X_Font id="ref-115">Arial, 10pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-62"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<x>360</x>
<y>3</y>
<width>251</width>
<height>19</height>
</Bounds>
<Text id="ref-116">Gesamtes Alimenteguthaben</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-48" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName href="#ref-96"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-117">Line5</Name>
<Style_X_Font id="ref-118">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-62"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>7</x>
<y>0</y>
<width>700</width>
<height>2</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-49" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName href="#ref-96"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-119">Line4</Name>
<Style_X_Font id="ref-120">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-62"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>627</x>
<y>54</y>
<width>78</width>
<height>2</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-50" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName href="#ref-96"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-121">Line3</Name>
<Style_X_Font id="ref-122">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-62"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>627</x>
<y>51</y>
<width>78</width>
<height>2</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-51" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName href="#ref-59"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-123">totEinkommen</Name>
<Style_X_Font id="ref-124">Arial, 10pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-62"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-63"/>
<BindingItem0_X_DataMember id="ref-125">BetragAlsEinkommen</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-126">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-65"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>627</x>
<y>31</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-127">totEinkommen</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-128">{0:#,##0.00}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Group</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-52" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName href="#ref-59"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-129">totBetrag</Name>
<Style_X_Font id="ref-130">Arial, 10pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-62"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-63"/>
<BindingItem0_X_DataMember id="ref-131">Betrag</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-132">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-65"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>627</x>
<y>3</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-133">totBetrag</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-134">{0:#,##0.00}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Group</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-53" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName href="#ref-59"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-135">TextBox1</Name>
<Style_X_Font id="ref-136">Arial, 10pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-62"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<x>7</x>
<y>31</y>
<width>606</width>
<height>19</height>
</Bounds>
<Text id="ref-137">Davon als Einkommen bewertet</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-92" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-58"/>
<Type_X_TypeName href="#ref-59"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-138">hiderTxtBemerkungRTF</Name>
<Style_X_Font id="ref-139">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-140">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-141">BemerkungRTF</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-65"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>47</x>
<y>7</y>
<width>100</width>
<height>26</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<EventsScript_X_OnAfterPrint id="ref-142">private void OnAfterPrint(object sender, System.EventArgs e) {
    txtBemerkungRTF.Visible = hiderTxtBemerkungRTF.Text != String.Empty;
}</EventsScript_X_OnAfterPrint>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
</SOAP-ENV:Body>
</SOAP-ENV:Envelope>' ,  null ,  N'DECLARE @BgBudgetID int

SELECT @BgBudgetID = BgBudgetID
FROM BgBudget
WHERE BgFinanzplanID = {BgFinanzplanID} AND MasterBudget = 1

SELECT BPO.*,
  NamePerson         = PRS.Name + IsNull('', '' + PRS.Vorname, ''''),
  AlimentenTyp       = SPT.Name,
  VerwaltungDurch    = CASE WHEN BPO.VerwaltungSD = 0 THEN ''Klient'' ELSE ''Inkassodienst'' END,
  BewertungAls       = CASE WHEN BPO.VerwaltungSD = 0 THEN ''Unterstützung'' ELSE ''Einkommen'' END,
  BetragAlsEinkommen = CASE WHEN BPO.VerwaltungSD = 0 THEN $0.00 ELSE BPO.Betrag END
FROM BgPosition              BPO
  INNER JOIN WhPositionsart  SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
  LEFT  JOIN BaPerson        PRS ON PRS.BaPersonID = BPO.BaPersonID
WHERE BPO.BgBudgetID = @BgBudgetID AND SPT.BgGruppeCode = 3102
  AND BPO.DatumVon IS NULL' ,  null ,  N'ShDetaillierterFinanzplanStandard' ,  null ,  1 );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'ShDetaillierterFinanzplanStandard_EinkommenVersich' ,  N'Einkommen aus Versicherungsleistungen' , 1,  N'<!--
AssemblyName=DevExpress%2EXtraReports%2C%20Version%3D1%2E7%2E9%2E0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4
AssemblyLocation=c:\windows\assembly\gac\devexpress.xtrareports\1.7.9.0__79868b8147b5eae4\devexpress.xtrareports.dll
TypeName=DevExpress.XtraReports.UI.XtraReport
Localization=de-CH
-->
<SOAP-ENV:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:SOAP-ENC="http://schemas.xmlsoap.org/soap/encoding/" xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/" xmlns:clr="http://schemas.microsoft.com/soap/encoding/clr/1.0" SOAP-ENV:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
<SOAP-ENV:Body>
<a1:ReportStorage id="ref-1" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<BandCount>5</BandCount>
<Band0 href="#ref-6"/>
<Band1 href="#ref-7"/>
<Band2 href="#ref-8"/>
<Band3 href="#ref-9"/>
<Band4 href="#ref-10"/>
<Visible>true</Visible>
<Tag id="ref-11"></Tag>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-12">Report</Name>
<Style_X_Font id="ref-13">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor id="ref-14">ControlText</Style_X_ForeColor>
<Style_X_BackColor id="ref-15">Transparent</Style_X_BackColor>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>100</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<DataSource id="ref-16">dataSource</DataSource>
<UseDefaultPrinterSettings>false</UseDefaultPrinterSettings>
<ReportUnit xsi:type="a2:ReportUnit" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">HundredthsOfAnInch</ReportUnit>
<Landscape>false</Landscape>
<PaperKind xsi:type="a5:PaperKind" xmlns:a5="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Printing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">A4</PaperKind>
<PaperName href="#ref-11"/>
<Margins xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>39</x>
<y>39</y>
<width>75</width>
<height>39</height>
</Margins>
<HtmlCompressed>false</HtmlCompressed>
<PageSize xsi:type="a4:Size" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<width>827</width>
<height>1169</height>
</PageSize>
<StyleSheet_X_StyleCount>0</StyleSheet_X_StyleCount>
<ShowPreviewMarginLines>true</ShowPreviewMarginLines>
<ScriptLanguage xsi:type="a6:ScriptLanguage" xmlns:a6="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">CSharp</ScriptLanguage>
<Watermark_X_Text href="#ref-11"/>
<Watermark_X_Font id="ref-17">Verdana, 36pt</Watermark_X_Font>
<Watermark_X_ForeColor id="ref-18">Red</Watermark_X_ForeColor>
<Watermark_X_Transparency>50</Watermark_X_Transparency>
<Watermark_X_TextDirection xsi:type="a7:DirectionMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">ForwardDiagonal</Watermark_X_TextDirection>
<Watermark_X_Image xsi:type="xsd:anyType" xsi:null="1"/>
<Watermark_X_ImageAlign xsi:type="a4:ContentAlignment" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">MiddleCenter</Watermark_X_ImageAlign>
<Watermark_X_ImageViewMode xsi:type="a7:ImageViewMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Clip</Watermark_X_ImageViewMode>
<Watermark_X_ImageTiling>false</Watermark_X_ImageTiling>
<Watermark_X_PageRange href="#ref-11"/>
<Watermark_X_ShowBehind>true</Watermark_X_ShowBehind>
<DefaultPrinterSettingsUsing_X_UseMargins>false</DefaultPrinterSettingsUsing_X_UseMargins>
<DefaultPrinterSettingsUsing_X_UsePaperKind>false</DefaultPrinterSettingsUsing_X_UsePaperKind>
<DefaultPrinterSettingsUsing_X_UseLandscape>false</DefaultPrinterSettingsUsing_X_UseLandscape>
<ShrinkSubReportIconArea>true</ShrinkSubReportIconArea>
</a1:ReportStorage>
<a1:ObjectStorage id="ref-6" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName id="ref-19">DevExpress.XtraReports, Version=1.7.9.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</Type_X_AssemblyName>
<Type_X_TypeName id="ref-20">DevExpress.XtraReports.UI.DetailBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-21">Detail</Name>
<Style_X_Font id="ref-22">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>41</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<PrintOnEmptyDataSource>true</PrintOnEmptyDataSource>
<MultiColumn_X_ColumnCount>1</MultiColumn_X_ColumnCount>
<MultiColumn_X_Direction xsi:type="a2:ColumnDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">DownThenAcross</MultiColumn_X_Direction>
<MultiColumn_X_ColumnWidth>0</MultiColumn_X_ColumnWidth>
<MultiColumn_X_ColumnSpacing>0</MultiColumn_X_ColumnSpacing>
<MultiColumn_X_Mode xsi:type="a2:MultiColumnMode" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">UseColumnCount</MultiColumn_X_Mode>
<RepeatCountOnEmptyDataSource>1</RepeatCountOnEmptyDataSource>
<ItemCount>5</ItemCount>
<Item0 href="#ref-23"/>
<Item1 href="#ref-24"/>
<Item2 href="#ref-25"/>
<Item3 href="#ref-26"/>
<Item4 href="#ref-27"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-7" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-28">DevExpress.XtraReports.UI.PageHeaderBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-29">PageHeader</Name>
<Style_X_Font id="ref-30">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>27</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>1</ItemCount>
<Item0 href="#ref-31"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-8" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-32">DevExpress.XtraReports.UI.GroupHeaderBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-33">GroupHeader1</Name>
<Style_X_Font id="ref-34">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>55</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<Level>0</Level>
<RepeatEveryPage>false</RepeatEveryPage>
<GroupFieldCount>0</GroupFieldCount>
<GroupUnion xsi:type="a2:GroupUnion" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</GroupUnion>
<ItemCount>6</ItemCount>
<Item0 href="#ref-35"/>
<Item1 href="#ref-36"/>
<Item2 href="#ref-37"/>
<Item3 href="#ref-38"/>
<Item4 href="#ref-39"/>
<Item5 href="#ref-40"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-9" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-41">DevExpress.XtraReports.UI.GroupFooterBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-42">GroupFooter1</Name>
<Style_X_Font id="ref-43">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>51</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<Level>0</Level>
<RepeatEveryPage>false</RepeatEveryPage>
<GroupUnion xsi:type="a2:GroupFooterUnion" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</GroupUnion>
<PrintAtBottom>false</PrintAtBottom>
<ItemCount>5</ItemCount>
<Item0 href="#ref-44"/>
<Item1 href="#ref-45"/>
<Item2 href="#ref-46"/>
<Item3 href="#ref-47"/>
<Item4 href="#ref-48"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-10" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-49">DevExpress.XtraReports.UI.PageFooterBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-50">PageFooter</Name>
<Style_X_Font id="ref-51">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>0</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-23" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-52">DevExpress.XtraReports.UI.XRLabel</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-53">txtVersicherungsTyp</Name>
<Style_X_Font id="ref-54">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor id="ref-55">Black</Style_X_ForeColor>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName id="ref-56">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-57">VersicherungsTyp</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>216</x>
<y>0</y>
<width>280</width>
<height>19</height>
</Bounds>
<Text id="ref-58">VersicherungsTyp</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-24" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-52"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-59">txtBemerkungRTF</Name>
<Style_X_Font id="ref-60">Arial, 10pt, style=Italic</Style_X_Font>
<Style_X_ForeColor href="#ref-55"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-56"/>
<BindingItem0_X_DataMember id="ref-61">BemerkungRTF</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>15</y>
<width>693</width>
<height>19</height>
</Bounds>
<Text id="ref-62">BemerkungRTF</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-25" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-52"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-63">txtBetrag</Name>
<Style_X_Font id="ref-64">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-55"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-56"/>
<BindingItem0_X_DataMember id="ref-65">Betrag</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-66">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>627</x>
<y>0</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-67">Betrag</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-68">{0:#,##0.00}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-26" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-52"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-69">txtVerwaltungDurch</Name>
<Style_X_Font id="ref-70">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-55"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-56"/>
<BindingItem0_X_DataMember id="ref-71">VerwaltungDurch</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>500</x>
<y>0</y>
<width>125</width>
<height>19</height>
</Bounds>
<Text id="ref-72">VerwaltungDurch</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-73">{0:0\%}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-27" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-52"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-74">txtNamePerson</Name>
<Style_X_Font id="ref-75">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-55"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-56"/>
<BindingItem0_X_DataMember id="ref-76">NamePerson</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>0</y>
<width>208</width>
<height>19</height>
</Bounds>
<Text id="ref-77">NamePerson</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-31" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-78">DevExpress.XtraReports.UI.XRPanel</Type_X_TypeName>
<Visible>false</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-79">hiderPanel</Name>
<Style_X_Font id="ref-80">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>220</x>
<y>0</y>
<width>300</width>
<height>27</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<ItemCount>1</ItemCount>
<Item0 href="#ref-81"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-35" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-82">DevExpress.XtraReports.UI.XRLine</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-83">xrLine1</Name>
<Style_X_Font id="ref-84">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-55"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>7</x>
<y>53</y>
<width>700</width>
<height>2</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-36" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-52"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-85">xrLabel7</Name>
<Style_X_Font id="ref-86">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>true</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>true</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>true</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>true</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>true</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>35</y>
<width>100</width>
<height>13</height>
</Bounds>
<Text id="ref-87">Betrifft</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-37" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-52"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-88">xrLabel6</Name>
<Style_X_Font id="ref-89">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>true</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>true</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>true</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>true</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>true</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>216</x>
<y>35</y>
<width>100</width>
<height>14</height>
</Bounds>
<Text id="ref-90">Versicherung</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-38" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-52"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-91">xrLabel5</Name>
<Style_X_Font id="ref-92">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>true</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>true</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>true</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>true</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>true</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>600</x>
<y>35</y>
<width>100</width>
<height>13</height>
</Bounds>
<Text id="ref-93">Betrag</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-39" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-52"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-94">xrLabel4</Name>
<Style_X_Font id="ref-95">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
<ParentStyleUsing_X_UseForeColor>true</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>true</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>true</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>true</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>true</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>500</x>
<y>35</y>
<width>100</width>
<height>13</height>
</Bounds>
<Text id="ref-96">Verwaltet durch</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-40" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-52"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-97">xrLabel1</Name>
<Style_X_Font id="ref-98">Arial, 10pt, style=Bold, Underline</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>1</Style_X_BorderWidth>
<Style_X_StyleUsing_X_UseFont>true</Style_X_StyleUsing_X_UseFont>
<Style_X_StyleUsing_X_UseForeColor>true</Style_X_StyleUsing_X_UseForeColor>
<Style_X_StyleUsing_X_UseBackColor>true</Style_X_StyleUsing_X_UseBackColor>
<Style_X_StyleUsing_X_UseBorderColor>true</Style_X_StyleUsing_X_UseBorderColor>
<Style_X_StyleUsing_X_UseBorders>true</Style_X_StyleUsing_X_UseBorders>
<Style_X_StyleUsing_X_UseBorderWidth>true</Style_X_StyleUsing_X_UseBorderWidth>
<Style_X_StyleUsing_X_UseTextAlignment>false</Style_X_StyleUsing_X_UseTextAlignment>
<ParentStyleUsing_X_UseFont>false</ParentStyleUsing_X_UseFont>
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
<width>320</width>
<height>27</height>
</Bounds>
<Text id="ref-99">Einkommen aus Versicherungsleistungen</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-44" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-82"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-100">Line4</Name>
<Style_X_Font id="ref-101">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-55"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>607</x>
<y>27</y>
<width>98</width>
<height>2</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-45" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-82"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-102">Line3</Name>
<Style_X_Font id="ref-103">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-55"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>607</x>
<y>23</y>
<width>98</width>
<height>2</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-46" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-82"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-104">Line2</Name>
<Style_X_Font id="ref-105">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-55"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>7</x>
<y>0</y>
<width>700</width>
<height>2</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-47" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-52"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-106">txtTotBetrag</Name>
<Style_X_Font id="ref-107">Arial, 10pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-55"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-56"/>
<BindingItem0_X_DataMember id="ref-108">Betrag</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-109">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>627</x>
<y>3</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-110">txtTotBetrag</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-111">{0:#,##0.00}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Group</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-48" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-52"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-112">Label5</Name>
<Style_X_Font id="ref-113">Arial, 10pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-55"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<x>173</x>
<y>3</y>
<width>414</width>
<height>19</height>
</Bounds>
<Text id="ref-114">Gesamtes Versicherungseinkommen</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-81" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-52"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-115">hiderTxtBemerkungRTF</Name>
<Style_X_Font id="ref-116">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-117">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-118">BemerkungRTF</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>13</x>
<y>0</y>
<width>100</width>
<height>27</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<EventsScript_X_OnAfterPrint id="ref-119">private void OnAfterPrint(object sender, System.EventArgs e) {
    txtBemerkungRTF.Visible = hiderTxtBemerkungRTF.Text != String.Empty;
}</EventsScript_X_OnAfterPrint>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
</SOAP-ENV:Body>
</SOAP-ENV:Envelope>' ,  null ,  N'DECLARE @BgBudgetID int

SELECT @BgBudgetID = BgBudgetID
FROM BgBudget
WHERE BgFinanzplanID = {BgFinanzplanID} AND MasterBudget = 1

SELECT BPO.*,
  NamePerson       = PRS.Name + IsNull('', '' + PRS.Vorname, ''''),
  VersicherungsTyp = SPT.Name,
  VerwaltungDurch  = CASE WHEN BPO.VerwaltungSD = 0 THEN ''Klient'' ELSE ''Sozialdienst'' END
FROM BgPosition              BPO
  INNER JOIN WhPositionsart  SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
  LEFT  JOIN BaPerson        PRS ON PRS.BaPersonID     = BPO.BaPersonID
WHERE BPO.BgBudgetID = @BgBudgetID AND SPT.BgGruppeCode = 3103
  AND BPO.DatumVon IS NULL' ,  null ,  N'ShDetaillierterFinanzplanStandard' ,  null ,  1 );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'ShDetaillierterFinanzplanStandard_Erwerbseinkommen' ,  N'Erwerbseinkommen' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4.2.07\KiSS4.DB.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4.2.07\log4net.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4.2.07\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtBemerkungRTF;
        private DevExpress.XtraReports.UI.XRLabel txtUnkostenAbzug;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtUnkostenBetrag;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private DevExpress.XtraReports.UI.XRLabel txtVerwaltungDurch;
        private DevExpress.XtraReports.UI.XRLabel txtTaetigkeit;
        private DevExpress.XtraReports.UI.XRLabel txtNamePerson;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRLabel hiderTxtBemerkungRTF;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel Label16;
        private DevExpress.XtraReports.UI.XRLabel Label15;
        private DevExpress.XtraReports.UI.XRLine Line6;
        private DevExpress.XtraReports.UI.XRLine Line5;
        private DevExpress.XtraReports.UI.XRLine Line4;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLabel sumTotal;
        private DevExpress.XtraReports.UI.XRLabel totUnkostenAbzug;
        private DevExpress.XtraReports.UI.XRLabel totUnkosten;
        private DevExpress.XtraReports.UI.XRLabel totBetrag;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
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
                        "AAAAaUIREVDTEFSRSBAQmdCdWRnZXRJRCBpbnQNCg0KU0VMRUNUIEBCZ0J1ZGdldElEID0gQmdCdWRnZ" +
                        "XRJRA0KRlJPTSBCZ0J1ZGdldA0KV0hFUkUgQmdGaW5hbnpwbGFuSUQgPSBudWxsIEFORCBNYXN0ZXJCd" +
                        "WRnZXQgPSAxDQoNClNFTEVDVCBCUE8uKiwNCiAgVmVyd2FsdHVuZ0R1cmNoICAgICAgICAgID0gQ0FTR" +
                        "SBXSEVOIEJQTy5WZXJ3YWx0dW5nU0QgPSAwIFRIRU4gJ0tsaWVudCcgRUxTRSAnU296aWFsZGllbnN0J" +
                        "yBFTkQsDQogIE5hbWVQZXJzb24gICAgICAgICAgICAgICA9IFBSUy5OYW1lICsgSXNOdWxsKCcsICcgK" +
                        "yBQUlMuVm9ybmFtZSwgJycpLA0KICBHZWJ1cnRzZGF0dW0gICAgICAgICAgICAgPSBDT05WRVJUKHZhc" +
                        "mNoYXIsIFBSUy5HZWJ1cnRzZGF0dW0sIDEwNCksDQogIFRhZXRpZ2tlaXQgICAgICAgICAgICAgICA9I" +
                        "FNQVC5OYW1lLA0KICBVbmtvc3RlbkJldHJhZyAgICAgICAgICAgPSBQVUsuQmV0cmFnLA0KICBVbmtvc" +
                        "3RlbkFienVnICAgICAgICAgICAgPSBQVUsuQWJ6dWcsDQogIFVua29zdGVuQW5nZXJlY2huZXQgICAgI" +
                        "CA9IFBVSy5CZXRyYWcgLSBQVUsuQWJ6dWcsDQogIFRvdGFsICAgICAgICAgICAgICAgICAgICA9IEJQT" +
                        "y5CZXRyYWcgLSBJc051bGwoUFVLLkJldHJhZyAtIFBVSy5BYnp1ZywgMCksDQogIEdlc2FtdGVzRXJ3Z" +
                        "XJic2VpbmtvbW1lbiA9IEJQTy5CZXRyYWcgLSBQVUsuQmV0cmFnIC0gUFVLLkFienVnDQpGUk9NIEJnU" +
                        "G9zaXRpb24gICAgICAgICAgICAgIEJQTw0KICBJTk5FUiBKT0lOIFdoUG9zaXRpb25zYXJ0ICBTUFQgT" +
                        "04gU1BULkJnUG9zaXRpb25zYXJ0SUQgPSBCUE8uQmdQb3NpdGlvbnNhcnRJRA0KICBMRUZUICBKT0lOI" +
                        "EJhUGVyc29uICAgICAgICBQUlMgT04gUFJTLkJhUGVyc29uSUQgPSBCUE8uQmFQZXJzb25JRA0KICBMR" +
                        "UZUICBKT0lOIEJnUG9zaXRpb24gICAgICBQVUsgT04gUFVLLkJnUG9zaXRpb25JRF9QYXJlbnQgPSBCU" +
                        "E8uQmdQb3NpdGlvbklEDQpXSEVSRSBCUE8uQmdCdWRnZXRJRCA9IEBCZ0J1ZGdldElEIEFORCBTUFQuQ" +
                        "mdHcnVwcGVDb2RlID0gMzEwMQ0KICBBTkQgQlBPLkRhdHVtVm9uIElTIE5VTEw=";
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
            DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.txtBemerkungRTF = new DevExpress.XtraReports.UI.XRLabel();
            this.txtUnkostenAbzug = new DevExpress.XtraReports.UI.XRLabel();
            this.txtUnkostenBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtVerwaltungDurch = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTaetigkeit = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNamePerson = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.hiderTxtBemerkungRTF = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label16 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label15 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line6 = new DevExpress.XtraReports.UI.XRLine();
            this.Line5 = new DevExpress.XtraReports.UI.XRLine();
            this.Line4 = new DevExpress.XtraReports.UI.XRLine();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.sumTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.totUnkostenAbzug = new DevExpress.XtraReports.UI.XRLabel();
            this.totUnkosten = new DevExpress.XtraReports.UI.XRLabel();
            this.totBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtBemerkungRTF,
                        this.txtUnkostenAbzug,
                        this.txtUnkostenBetrag,
                        this.txtBetrag,
                        this.txtVerwaltungDurch,
                        this.txtTaetigkeit,
                        this.txtNamePerson});
            this.Detail.Height = 43;
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
                        this.xrPanel1});
            this.ReportHeader.Height = 27;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.ParentStyleUsing.UseBackColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorderColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorders = false;
            this.ReportHeader.ParentStyleUsing.UseBorderWidth = false;
            this.ReportHeader.ParentStyleUsing.UseFont = false;
            this.ReportHeader.ParentStyleUsing.UseForeColor = false;
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
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLine1,
                        this.xrLabel13,
                        this.xrLabel12,
                        this.xrLabel11,
                        this.xrLabel10,
                        this.xrLabel9,
                        this.xrLabel8,
                        this.xrLabel7,
                        this.xrLabel4,
                        this.xrLabel1});
            this.GroupHeader1.Height = 82;
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
                        this.Label16,
                        this.Label15,
                        this.Line6,
                        this.Line5,
                        this.Line4,
                        this.Line3,
                        this.sumTotal,
                        this.totUnkostenAbzug,
                        this.totUnkosten,
                        this.totBetrag});
            this.GroupFooter1.Height = 77;
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
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Height = 0;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // txtBemerkungRTF
            // 
            this.txtBemerkungRTF.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.txtBemerkungRTF.ForeColor = System.Drawing.Color.Black;
            this.txtBemerkungRTF.Location = new System.Drawing.Point(7, 15);
            this.txtBemerkungRTF.Multiline = true;
            this.txtBemerkungRTF.Name = "txtBemerkungRTF";
            this.txtBemerkungRTF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBemerkungRTF.ParentStyleUsing.UseBackColor = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorderColor = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorders = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorderWidth = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseFont = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseForeColor = false;
            this.txtBemerkungRTF.Size = new System.Drawing.Size(693, 19);
            this.txtBemerkungRTF.Text = "BemerkungRTF";
            // 
            // txtUnkostenAbzug
            // 
            this.txtUnkostenAbzug.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "UnkostenAbzug", "{0:n2}")});
            this.txtUnkostenAbzug.Font = new System.Drawing.Font("Arial", 10F);
            this.txtUnkostenAbzug.ForeColor = System.Drawing.Color.Black;
            this.txtUnkostenAbzug.Location = new System.Drawing.Point(624, 0);
            this.txtUnkostenAbzug.Multiline = true;
            this.txtUnkostenAbzug.Name = "txtUnkostenAbzug";
            this.txtUnkostenAbzug.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtUnkostenAbzug.ParentStyleUsing.UseBackColor = false;
            this.txtUnkostenAbzug.ParentStyleUsing.UseBorderColor = false;
            this.txtUnkostenAbzug.ParentStyleUsing.UseBorders = false;
            this.txtUnkostenAbzug.ParentStyleUsing.UseBorderWidth = false;
            this.txtUnkostenAbzug.ParentStyleUsing.UseFont = false;
            this.txtUnkostenAbzug.ParentStyleUsing.UseForeColor = false;
            this.txtUnkostenAbzug.Size = new System.Drawing.Size(78, 19);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtUnkostenAbzug.Summary = xrSummary1;
            this.txtUnkostenAbzug.Text = "UnkostenAbzug";
            this.txtUnkostenAbzug.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtUnkostenBetrag
            // 
            this.txtUnkostenBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "UnkostenBetrag", "{0:n2}")});
            this.txtUnkostenBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtUnkostenBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtUnkostenBetrag.Location = new System.Drawing.Point(540, 0);
            this.txtUnkostenBetrag.Multiline = true;
            this.txtUnkostenBetrag.Name = "txtUnkostenBetrag";
            this.txtUnkostenBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtUnkostenBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtUnkostenBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtUnkostenBetrag.ParentStyleUsing.UseBorders = false;
            this.txtUnkostenBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtUnkostenBetrag.ParentStyleUsing.UseFont = false;
            this.txtUnkostenBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtUnkostenBetrag.Size = new System.Drawing.Size(78, 19);
            xrSummary2.FormatString = "{0:#,##0.00}";
            this.txtUnkostenBetrag.Summary = xrSummary2;
            this.txtUnkostenBetrag.Text = "UnkostenBetrag";
            this.txtUnkostenBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(453, 0);
            this.txtBetrag.Multiline = true;
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(78, 19);
            xrSummary3.FormatString = "{0:#,##0.00}";
            this.txtBetrag.Summary = xrSummary3;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtVerwaltungDurch
            // 
            this.txtVerwaltungDurch.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VerwaltungDurch", "")});
            this.txtVerwaltungDurch.Font = new System.Drawing.Font("Arial", 10F);
            this.txtVerwaltungDurch.ForeColor = System.Drawing.Color.Black;
            this.txtVerwaltungDurch.Location = new System.Drawing.Point(340, 0);
            this.txtVerwaltungDurch.Multiline = true;
            this.txtVerwaltungDurch.Name = "txtVerwaltungDurch";
            this.txtVerwaltungDurch.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtVerwaltungDurch.ParentStyleUsing.UseBackColor = false;
            this.txtVerwaltungDurch.ParentStyleUsing.UseBorderColor = false;
            this.txtVerwaltungDurch.ParentStyleUsing.UseBorders = false;
            this.txtVerwaltungDurch.ParentStyleUsing.UseBorderWidth = false;
            this.txtVerwaltungDurch.ParentStyleUsing.UseFont = false;
            this.txtVerwaltungDurch.ParentStyleUsing.UseForeColor = false;
            this.txtVerwaltungDurch.Size = new System.Drawing.Size(110, 19);
            this.txtVerwaltungDurch.Text = "VerwaltungDurch";
            // 
            // txtTaetigkeit
            // 
            this.txtTaetigkeit.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Taetigkeit", "")});
            this.txtTaetigkeit.Font = new System.Drawing.Font("Arial", 10F);
            this.txtTaetigkeit.ForeColor = System.Drawing.Color.Black;
            this.txtTaetigkeit.Location = new System.Drawing.Point(216, 0);
            this.txtTaetigkeit.Multiline = true;
            this.txtTaetigkeit.Name = "txtTaetigkeit";
            this.txtTaetigkeit.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTaetigkeit.ParentStyleUsing.UseBackColor = false;
            this.txtTaetigkeit.ParentStyleUsing.UseBorderColor = false;
            this.txtTaetigkeit.ParentStyleUsing.UseBorders = false;
            this.txtTaetigkeit.ParentStyleUsing.UseBorderWidth = false;
            this.txtTaetigkeit.ParentStyleUsing.UseFont = false;
            this.txtTaetigkeit.ParentStyleUsing.UseForeColor = false;
            this.txtTaetigkeit.Size = new System.Drawing.Size(137, 19);
            this.txtTaetigkeit.Text = "Taetigkeit";
            // 
            // txtNamePerson
            // 
            this.txtNamePerson.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NamePerson", "")});
            this.txtNamePerson.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNamePerson.ForeColor = System.Drawing.Color.Black;
            this.txtNamePerson.Location = new System.Drawing.Point(7, 0);
            this.txtNamePerson.Multiline = true;
            this.txtNamePerson.Name = "txtNamePerson";
            this.txtNamePerson.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNamePerson.ParentStyleUsing.UseBackColor = false;
            this.txtNamePerson.ParentStyleUsing.UseBorderColor = false;
            this.txtNamePerson.ParentStyleUsing.UseBorders = false;
            this.txtNamePerson.ParentStyleUsing.UseBorderWidth = false;
            this.txtNamePerson.ParentStyleUsing.UseFont = false;
            this.txtNamePerson.ParentStyleUsing.UseForeColor = false;
            this.txtNamePerson.Size = new System.Drawing.Size(208, 19);
            this.txtNamePerson.Text = "NamePerson";
            // 
            // xrPanel1
            // 
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.hiderTxtBemerkungRTF});
            this.xrPanel1.Location = new System.Drawing.Point(180, 0);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.Size = new System.Drawing.Size(300, 27);
            this.xrPanel1.Visible = false;
            // 
            // hiderTxtBemerkungRTF
            // 
            this.hiderTxtBemerkungRTF.Location = new System.Drawing.Point(7, 0);
            this.hiderTxtBemerkungRTF.Name = "hiderTxtBemerkungRTF";
            this.hiderTxtBemerkungRTF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hiderTxtBemerkungRTF.Scripts.OnAfterPrint = "private void OnAfterPrint(object sender, System.EventArgs e) {\r\n  txtBemerkungRTF" +
                ".Visible = hiderTxtBemerkungRTF.Text != String.Empty;\r\n}";
            this.hiderTxtBemerkungRTF.Size = new System.Drawing.Size(100, 20);
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.Location = new System.Drawing.Point(4, 80);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(700, 2);
            // 
            // xrLabel13
            // 
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel13.Location = new System.Drawing.Point(353, 60);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.ParentStyleUsing.UseFont = false;
            this.xrLabel13.Size = new System.Drawing.Size(100, 20);
            this.xrLabel13.Text = "Verwaltet durch";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel12.Location = new System.Drawing.Point(216, 60);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.ParentStyleUsing.UseFont = false;
            this.xrLabel12.Size = new System.Drawing.Size(100, 20);
            this.xrLabel12.Text = "Tätigkeit";
            // 
            // xrLabel11
            // 
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel11.Location = new System.Drawing.Point(7, 60);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.ParentStyleUsing.UseFont = false;
            this.xrLabel11.Size = new System.Drawing.Size(100, 20);
            this.xrLabel11.Text = "Betrifft";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel10.Location = new System.Drawing.Point(447, 60);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.ParentStyleUsing.UseFont = false;
            this.xrLabel10.Size = new System.Drawing.Size(82, 20);
            this.xrLabel10.Text = "Einkommen";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel9.Location = new System.Drawing.Point(540, 60);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.Size = new System.Drawing.Size(76, 20);
            this.xrLabel9.Text = "Betrag";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel8.Location = new System.Drawing.Point(493, 40);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.Size = new System.Drawing.Size(207, 20);
            this.xrLabel8.Text = "effektive Erwerbsunkosten";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel7.Location = new System.Drawing.Point(620, 60);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.Size = new System.Drawing.Size(82, 20);
            this.xrLabel7.Text = "Reduktion";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel4.Location = new System.Drawing.Point(353, 60);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(100, 20);
            this.xrLabel4.Text = "Verwaltet durch";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.xrLabel1.Location = new System.Drawing.Point(0, 7);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(347, 20);
            this.xrLabel1.Text = "Erwerbseinkommen und effektive Erwerbsunkosten";
            // 
            // Label16
            // 
            this.Label16.Font = new System.Drawing.Font("Arial", 10F);
            this.Label16.ForeColor = System.Drawing.Color.Black;
            this.Label16.Location = new System.Drawing.Point(320, 43);
            this.Label16.Name = "Label16";
            this.Label16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label16.ParentStyleUsing.UseBackColor = false;
            this.Label16.ParentStyleUsing.UseBorderColor = false;
            this.Label16.ParentStyleUsing.UseBorders = false;
            this.Label16.ParentStyleUsing.UseBorderWidth = false;
            this.Label16.ParentStyleUsing.UseFont = false;
            this.Label16.ParentStyleUsing.UseForeColor = false;
            this.Label16.Size = new System.Drawing.Size(271, 19);
            this.Label16.Text = "Gesamtes Erwerbseinkommen";
            this.Label16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label15
            // 
            this.Label15.Font = new System.Drawing.Font("Arial", 10F);
            this.Label15.ForeColor = System.Drawing.Color.Black;
            this.Label15.Location = new System.Drawing.Point(360, 11);
            this.Label15.Name = "Label15";
            this.Label15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label15.ParentStyleUsing.UseBackColor = false;
            this.Label15.ParentStyleUsing.UseBorderColor = false;
            this.Label15.ParentStyleUsing.UseBorders = false;
            this.Label15.ParentStyleUsing.UseBorderWidth = false;
            this.Label15.ParentStyleUsing.UseFont = false;
            this.Label15.ParentStyleUsing.UseForeColor = false;
            this.Label15.Size = new System.Drawing.Size(78, 19);
            this.Label15.Text = "Total";
            this.Label15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line6
            // 
            this.Line6.ForeColor = System.Drawing.Color.Black;
            this.Line6.Location = new System.Drawing.Point(4, 38);
            this.Line6.Name = "Line6";
            this.Line6.ParentStyleUsing.UseBackColor = false;
            this.Line6.ParentStyleUsing.UseBorderColor = false;
            this.Line6.ParentStyleUsing.UseBorders = false;
            this.Line6.ParentStyleUsing.UseBorderWidth = false;
            this.Line6.ParentStyleUsing.UseFont = false;
            this.Line6.ParentStyleUsing.UseForeColor = false;
            this.Line6.Size = new System.Drawing.Size(700, 2);
            // 
            // Line5
            // 
            this.Line5.ForeColor = System.Drawing.Color.Black;
            this.Line5.Location = new System.Drawing.Point(607, 70);
            this.Line5.Name = "Line5";
            this.Line5.ParentStyleUsing.UseBackColor = false;
            this.Line5.ParentStyleUsing.UseBorderColor = false;
            this.Line5.ParentStyleUsing.UseBorders = false;
            this.Line5.ParentStyleUsing.UseBorderWidth = false;
            this.Line5.ParentStyleUsing.UseFont = false;
            this.Line5.ParentStyleUsing.UseForeColor = false;
            this.Line5.Size = new System.Drawing.Size(94, 2);
            // 
            // Line4
            // 
            this.Line4.ForeColor = System.Drawing.Color.Black;
            this.Line4.Location = new System.Drawing.Point(607, 66);
            this.Line4.Name = "Line4";
            this.Line4.ParentStyleUsing.UseBackColor = false;
            this.Line4.ParentStyleUsing.UseBorderColor = false;
            this.Line4.ParentStyleUsing.UseBorders = false;
            this.Line4.ParentStyleUsing.UseBorderWidth = false;
            this.Line4.ParentStyleUsing.UseFont = false;
            this.Line4.ParentStyleUsing.UseForeColor = false;
            this.Line4.Size = new System.Drawing.Size(94, 2);
            // 
            // Line3
            // 
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.Location = new System.Drawing.Point(4, 3);
            this.Line3.Name = "Line3";
            this.Line3.ParentStyleUsing.UseBackColor = false;
            this.Line3.ParentStyleUsing.UseBorderColor = false;
            this.Line3.ParentStyleUsing.UseBorders = false;
            this.Line3.ParentStyleUsing.UseBorderWidth = false;
            this.Line3.ParentStyleUsing.UseFont = false;
            this.Line3.ParentStyleUsing.UseForeColor = false;
            this.Line3.Size = new System.Drawing.Size(700, 2);
            // 
            // sumTotal
            // 
            this.sumTotal.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GesamtesErwerbseinkommen", "")});
            this.sumTotal.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.sumTotal.ForeColor = System.Drawing.Color.Black;
            this.sumTotal.Location = new System.Drawing.Point(607, 43);
            this.sumTotal.Multiline = true;
            this.sumTotal.Name = "sumTotal";
            this.sumTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.sumTotal.ParentStyleUsing.UseBackColor = false;
            this.sumTotal.ParentStyleUsing.UseBorderColor = false;
            this.sumTotal.ParentStyleUsing.UseBorders = false;
            this.sumTotal.ParentStyleUsing.UseBorderWidth = false;
            this.sumTotal.ParentStyleUsing.UseFont = false;
            this.sumTotal.ParentStyleUsing.UseForeColor = false;
            this.sumTotal.Size = new System.Drawing.Size(94, 19);
            xrSummary4.FormatString = "{0:n2}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.sumTotal.Summary = xrSummary4;
            this.sumTotal.Text = "sumTotal";
            this.sumTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // totUnkostenAbzug
            // 
            this.totUnkostenAbzug.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "UnkostenAbzug", "{0:n2}")});
            this.totUnkostenAbzug.Font = new System.Drawing.Font("Arial", 10F);
            this.totUnkostenAbzug.ForeColor = System.Drawing.Color.Black;
            this.totUnkostenAbzug.Location = new System.Drawing.Point(624, 11);
            this.totUnkostenAbzug.Multiline = true;
            this.totUnkostenAbzug.Name = "totUnkostenAbzug";
            this.totUnkostenAbzug.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totUnkostenAbzug.ParentStyleUsing.UseBackColor = false;
            this.totUnkostenAbzug.ParentStyleUsing.UseBorderColor = false;
            this.totUnkostenAbzug.ParentStyleUsing.UseBorders = false;
            this.totUnkostenAbzug.ParentStyleUsing.UseBorderWidth = false;
            this.totUnkostenAbzug.ParentStyleUsing.UseFont = false;
            this.totUnkostenAbzug.ParentStyleUsing.UseForeColor = false;
            this.totUnkostenAbzug.Size = new System.Drawing.Size(78, 19);
            xrSummary5.FormatString = "{0:#,##0.00}";
            this.totUnkostenAbzug.Summary = xrSummary5;
            this.totUnkostenAbzug.Text = "totUnkostenAbzug";
            this.totUnkostenAbzug.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // totUnkosten
            // 
            this.totUnkosten.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "UnkostenBetrag", "{0:n2}")});
            this.totUnkosten.Font = new System.Drawing.Font("Arial", 10F);
            this.totUnkosten.ForeColor = System.Drawing.Color.Black;
            this.totUnkosten.Location = new System.Drawing.Point(540, 11);
            this.totUnkosten.Multiline = true;
            this.totUnkosten.Name = "totUnkosten";
            this.totUnkosten.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totUnkosten.ParentStyleUsing.UseBackColor = false;
            this.totUnkosten.ParentStyleUsing.UseBorderColor = false;
            this.totUnkosten.ParentStyleUsing.UseBorders = false;
            this.totUnkosten.ParentStyleUsing.UseBorderWidth = false;
            this.totUnkosten.ParentStyleUsing.UseFont = false;
            this.totUnkosten.ParentStyleUsing.UseForeColor = false;
            this.totUnkosten.Size = new System.Drawing.Size(78, 19);
            xrSummary6.FormatString = "{0:#,##0.00}";
            this.totUnkosten.Summary = xrSummary6;
            this.totUnkosten.Text = "totUnkosten";
            this.totUnkosten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // totBetrag
            // 
            this.totBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.totBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.totBetrag.ForeColor = System.Drawing.Color.Black;
            this.totBetrag.Location = new System.Drawing.Point(453, 11);
            this.totBetrag.Multiline = true;
            this.totBetrag.Name = "totBetrag";
            this.totBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totBetrag.ParentStyleUsing.UseBackColor = false;
            this.totBetrag.ParentStyleUsing.UseBorderColor = false;
            this.totBetrag.ParentStyleUsing.UseBorders = false;
            this.totBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.totBetrag.ParentStyleUsing.UseFont = false;
            this.totBetrag.ParentStyleUsing.UseForeColor = false;
            this.totBetrag.Size = new System.Drawing.Size(78, 19);
            xrSummary7.FormatString = "{0:#,##0.00}";
            this.totBetrag.Summary = xrSummary7;
            this.totBetrag.Text = "totBetrag";
            this.totBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
                        this.PageHeader,
                        this.GroupHeader1,
                        this.GroupFooter1,
                        this.PageFooter,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(0, 61, 100, 100);
            this.Name = "Report";
            this.PageHeight = 1300;
            this.PageWidth = 769;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'DECLARE @BgBudgetID int

SELECT @BgBudgetID = BgBudgetID
FROM BgBudget
WHERE BgFinanzplanID = {BgFinanzplanID} AND MasterBudget = 1

SELECT BPO.*,
  VerwaltungDurch          = CASE WHEN BPO.VerwaltungSD = 0 THEN ''Klient'' ELSE ''Sozialdienst'' END,
  NamePerson               = PRS.Name + IsNull('', '' + PRS.Vorname, ''''),
  Geburtsdatum             = CONVERT(varchar, PRS.Geburtsdatum, 104),
  Taetigkeit               = SPT.Name,
  UnkostenBetrag           = PUK.Betrag,
  UnkostenAbzug            = PUK.Abzug,
  UnkostenAngerechnet      = PUK.Betrag - PUK.Abzug,
  Total                    = BPO.Betrag - IsNull(PUK.Betrag - PUK.Abzug, 0),
  GesamtesErwerbseinkommen = BPO.Betrag - PUK.Betrag - PUK.Abzug
FROM BgPosition              BPO
  INNER JOIN WhPositionsart  SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
  LEFT  JOIN BaPerson        PRS ON PRS.BaPersonID = BPO.BaPersonID
  LEFT  JOIN BgPosition      PUK ON PUK.BgPositionID_Parent = BPO.BgPositionID
WHERE BPO.BgBudgetID = @BgBudgetID AND SPT.BgGruppeCode = 3101
  AND BPO.DatumVon IS NULL' ,  null ,  N'ShDetaillierterFinanzplanStandard' ,  null ,  1 );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'ShDetaillierterFinanzplanStandard_GBMiete' ,  N'Grundbedarf, Miete' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4.2.07\KiSS4.DB.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4.2.07\log4net.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4.2.07\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel lblGBHGBetrag;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRPanel hiderPanel;
        private DevExpress.XtraReports.UI.XRLabel hiderGB_Typ;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader2;
        private DevExpress.XtraReports.UI.XRLabel lblGBHG;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel39;
        private DevExpress.XtraReports.UI.XRLabel xrLabel38;
        private DevExpress.XtraReports.UI.XRLine xrLine6;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel37;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel36;
        private DevExpress.XtraReports.UI.XRLabel xrLabel35;
        private DevExpress.XtraReports.UI.XRLabel xrLabel34;
        private DevExpress.XtraReports.UI.XRLabel xrLabel33;
        private DevExpress.XtraReports.UI.XRLabel xrLabel32;
        private DevExpress.XtraReports.UI.XRLabel xrLabel31;
        private DevExpress.XtraReports.UI.XRLabel xrLabel30;
        private DevExpress.XtraReports.UI.XRLabel xrLabel29;
        private DevExpress.XtraReports.UI.XRLabel xrLabel28;
        private DevExpress.XtraReports.UI.XRLabel xrLabel27;
        private DevExpress.XtraReports.UI.XRLabel xrLabel26;
        private DevExpress.XtraReports.UI.XRLabel xrLabel25;
        private DevExpress.XtraReports.UI.XRLine xrLine5;
        private DevExpress.XtraReports.UI.XRLine xrLine4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel24;
        private DevExpress.XtraReports.UI.XRLabel xrLabel23;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAACAAAAAAAAAFBBRFBBRFATtE6kG" +
                        "I89VEUAAAAAAAAAQAEAAEBoAGkAZABlAHIARwBCAF8AVAB5AHAALgBTAGMAcgBpAHAAdABzAC4ATwBuA" +
                        "EEAZgB0AGUAcgBQAHIAaQBuAHQAAAAAADJzAHEAbABRAHUAZQByAHkAMQAuAFMAZQBsAGUAYwB0AFMAd" +
                        "ABhAHQAZQBtAGUAbgB0AKMCAAABoAVwcml2YXRlIHZvaWQgT25BZnRlclByaW50KG9iamVjdCBzZW5kZ" +
                        "XIsIFN5c3RlbS5FdmVudEFyZ3MgZSkgew0KdHJ5IHsNCg0KICAgIGxibEdCSEcuVmlzaWJsZSA9IGZhb" +
                        "HNlOyANCiAgICBsYmxHQkhHQmV0cmFnLlZpc2libGUgPSBmYWxzZTsgDQoNCiAgICBpbnQgZ2JUeXA7D" +
                        "QoNCiAgICBpZiAoU3RyaW5nLklzTnVsbE9yRW1wdHkoaGlkZXJHQl9UeXAuVGV4dCkpDQogICAgew0KC" +
                        "WdiVHlwID0gMDsNCiAgICB9DQogICAgZWxzZQ0KICAgIHsNCglnYlR5cCA9IGludC5QYXJzZShoaWRlc" +
                        "kdCX1R5cC5UZXh0KTsNCiAgICB9ICAgIA0KDQogICAgaW50IEdCX1R5cCA9IGdiVHlwOw0KICAgIHN3a" +
                        "XRjaCAoR0JfVHlwKSB7DQogICAgICBjYXNlIDMyMDE1OiANCiAgICAgICAgbGJsR0JIRy5WaXNpYmxlI" +
                        "D0gdHJ1ZTsgDQogICAgICAgIGxibEdCSEdCZXRyYWcuVmlzaWJsZSA9IHRydWU7IA0KICAgICAgICBic" +
                        "mVhazsNCiAgICB9DQogIH0NCiAgY2F0Y2ggKFN5c3RlbS5FeGNlcHRpb24gZXgpDQogIHsNCiAgICBTe" +
                        "XN0ZW0uV2luZG93cy5Gb3Jtcy5NZXNzYWdlQm94LlNob3coIkltIFJlcG9ydCBpc3QgZWluIFNrcmlwd" +
                        "C1GZWhsZXIgYXVmZ2V0cmV0ZW4uIChHQl9UeXAtIGhpZGVyLk9uQWZ0ZXJQcmludCkuIFN5c3RlbSBNZ" +
                        "WxkdW5nOiAiKyBleC5NZXNzYWdlKTsNCiAgfQ0KDQoNCn0BnjItLSBOdXIgZsO8ciBTS09TIDIwMDUNC" +
                        "kRFQ0xBUkUgQEJnQnVkZ2V0SUQgSU5ULA0KICAgICAgICBAUmVmRGF0ZSAgICBkYXRldGltZQ0KU0VMR" +
                        "UNUIEBCZ0J1ZGdldElEID0gQmdCdWRnZXRJRCwgQFJlZkRhdGUgPSBJc051bGwoRlBMLkRhdHVtVm9uL" +
                        "CBGUEwuR2VwbGFudFZvbikNCkZST00gQmdGaW5hbnpQbGFuICAgICAgRlBMDQogIElOTkVSIEpPSU4gQ" +
                        "mdCdWRnZXQgIEJERyBPTiBCREcuQmdGaW5hbnpQbGFuSUQgPSBGUEwuQmdGaW5hbnpQbGFuSUQNCldIR" +
                        "VJFIEZQTC5CZ0ZpbmFuelBsYW5JRCA9IG51bGwgQU5EIEJERy5NYXN0ZXJCdWRnZXQgPSAxDQoNCkRFQ" +
                        "0xBUkUgQEdydW5kYmVkYXJmIFRBQkxFICgNCiAgW0lEXSAgICAgICAgICBJTlQgTk9UIE5VTEwgSURFT" +
                        "lRJVFkgKDEsIDEpLA0KICBbR0JfVGV4dF0gICAgIFZBUkNIQVIoMjAwKSwNCiAgW1VFX0JldHJhZ10gI" +
                        "CBNT05FWSwNCiAgW0JlbWVya3VuZ2VuXSBWQVJDSEFSKDEwMDApDQopDQoNCi0tIEdydW5kYmVkYXJmD" +
                        "QpJTlNFUlQgSU5UTyBAR3J1bmRiZWRhcmYgKEdCX1RleHQsIFVFX0JldHJhZykNCiAgU0VMRUNUIA0KI" +
                        "CAgIFBPQS5OYW1lLCANCiAgICBQT1MuQmV0cmFnDQogIEZST00gdndCZ1Bvc2l0aW9uICAgICAgICAgI" +
                        "CBQT1MNCiAgICBJTk5FUiBKT0lOIEJnUG9zaXRpb25zYXJ0IFBPQSBPTiBQT0EuQmdQb3NpdGlvbnNhc" +
                        "nRJRCA9IFBPUy5CZ1Bvc2l0aW9uc2FydElEDQogIFdIRVJFIFBPUy5CZ0J1ZGdldElEID0gQEJnQnVkZ" +
                        "2V0SUQgQU5EIFBPUy5EYXR1bVZvbiBJUyBOVUxMDQogICAgQU5EIFBPUy5CZ1Bvc2l0aW9uc2FydElEI" +
                        "ElOIChTRUxFQ1QgQmdQb3NpdGlvbnNhcnRJRCANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgIEZST00gQmdQb3NpdGlvbnNhcnQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIR" +
                        "VJFIEJnR3J1cHBlQ29kZSA9IDMyMDEgQU5EIFNvcnRLZXkgPSAxKQ0KDQotLSBBbnBhc3N1bmcNCklOU" +
                        "0VSVCBJTlRPIEBHcnVuZGJlZGFyZiAoR0JfVGV4dCwgVUVfQmV0cmFnKQ0KICBTRUxFQ1QgDQogICAgJ" +
                        "0FucGFzc3VuZyAoc2llaGUgQmVtZXJrdW5nKScsIA0KICAgIENBU0UgV0hFTiBQT1MuUmVkdWt0aW9uI" +
                        "Dw+ICQwLjAwIA0KICAgICAgVEhFTiAtUE9TLlJlZHVrdGlvbiANCiAgICAgIEVMU0UgJDAuMDAgDQogI" +
                        "CAgRU5EDQogIEZST00gdndCZ1Bvc2l0aW9uICAgICAgICAgICBQT1MNCiAgICBJTk5FUiBKT0lOIEJnU" +
                        "G9zaXRpb25zYXJ0IFBPQSBPTiBQT0EuQmdQb3NpdGlvbnNhcnRJRCA9IFBPUy5CZ1Bvc2l0aW9uc2Fyd" +
                        "ElEDQogIFdIRVJFIFBPUy5CZ0J1ZGdldElEID0gQEJnQnVkZ2V0SUQgQU5EIFBPUy5EYXR1bVZvbiBJU" +
                        "yBOVUxMDQogICAgQU5EIFBPUy5CZ1Bvc2l0aW9uc2FydElEIElOIChTRUxFQ1QgQmdQb3NpdGlvbnNhc" +
                        "nRJRCANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEZST00gQmdQb3NpdGlvbnNhcnQNC" +
                        "iAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRVJFIEJnR3J1cHBlQ29kZSA9IDMyMDEgQ" +
                        "U5EIFNvcnRLZXkgPSAxKQ0KLS0gVlZHLUJlaXRyw6RnZQ0KSU5TRVJUIElOVE8gQEdydW5kYmVkYXJmI" +
                        "ChHQl9UZXh0LCBVRV9CZXRyYWcpDQogIFNFTEVDVCANCiAgICAnVlZHLUJlaXRyYWdlJywgDQogICAgU" +
                        "1VNKC1CZXRyYWcgLSBSZWR1a3Rpb24pICAgIC0tIEFienVnIFZWRyB3ZW5uIG5pY2h0IHZvbiBTRCDDv" +
                        "GJlcm5vbW1lbg0KICBGUk9NIEJnUG9zaXRpb24gUE9TDQogIFdIRVJFIFBPUy5CZ0J1ZGdldElEID0gQ" +
                        "EJnQnVkZ2V0SUQgDQogICAgQU5EIFBPUy5CZ1Bvc2l0aW9uc2FydElEID0gMzIwMjENCiAgICBBTkQgU" +
                        "E9TLk1heEJlaXRyYWdTRCA9ICQwLjAwDQogICAgQU5EIEdldERhdGUoKSBCRVRXRUVOIElzTnVsbChQT" +
                        "1MuRGF0dW1Wb24sICcxOTAwMDEwMScpIEFORCBJc051bGwoUE9TLkRhdHVtQmlzLCAnOTk5OTEyMzEnK" +
                        "Q0KDQoNCi0tIFp1bGFnZW4vRUZCLCBTYW5rdGlvbmVuDQpJTlNFUlQgSU5UTyBAR3J1bmRiZWRhcmYgK" +
                        "EdCX1RleHQsIFVFX0JldHJhZywgQmVtZXJrdW5nZW4pDQogIFNFTEVDVA0KICAgIEdCX1RleHQgPSBkY" +
                        "m8uZm5MT1ZUZXh0KCdCZ0dydXBwZScsIFBPQS5CZ0dydXBwZUNvZGUpICsgDQogICAgICAgICAgICAgI" +
                        "ENBU0UgV0hFTiBQT0EuQmdHcnVwcGVDb2RlIElOICgzOTExMCwgMzkxMzAsIDM5MjEwLCAzOTkxMCkgV" +
                        "EhFTiAnIEFsbGVpbmVyemllaGVuZCAnIEVMU0UgJyAnIEVORCArIA0KICAgICAgICAgICAgICBQT0EuT" +
                        "mFtZSArIA0KICAgICAgICAgICAgICAnICAoJyArIFBSUy5Wb3JuYW1lTmFtZSArICcpJywNCiAgICBDQ" +
                        "VNFIFdIRU4gUE9TLkJnS2F0ZWdvcmllQ29kZSA9IDIgDQogICAgICBUSEVOIFBPUy5CZXRyYWdGaW5hb" +
                        "npwbGFuIA0KICAgICAgRUxTRSAtUE9TLkJldHJhZ0ZpbmFuenBsYW4gDQogICAgRU5ELA0KICAgIFBPU" +
                        "y5CZW1lcmt1bmcNCiAgRlJPTSB2d0JnUG9zaXRpb24gICAgICAgICAgIFBPUw0KICAgIElOTkVSIEpPS" +
                        "U4gQmdQb3NpdGlvbnNhcnQgUE9BIE9OIFBPQS5CZ1Bvc2l0aW9uc2FydElEID0gUE9TLkJnUG9zaXRpb" +
                        "25zYXJ0SUQNCiAgICBJTk5FUiBKT0lOIHZ3UGVyc29uICAgICAgIFBSUyBPTiBQUlMuQmFQZXJzb25JR" +
                        "CA9IFBPUy5CYVBlcnNvbklEDQogIFdIRVJFIFBPUy5CZ0J1ZGdldElEID0gQEJnQnVkZ2V0SUQgDQogI" +
                        "CAgQU5EIFBPUy5EYXR1bVZvbiBJUyBOVUxMDQogICAgQU5EIFBPQS5CZ0dydXBwZUNvZGUgQkVUV0VFT" +
                        "iAzOTAwMCBBTkQgMzk5OTkNCg0KDQpERUNMQVJFIEBVRV9GYWN0b3JfV29obmtvc3RlbiBkZWNpbWFsD" +
                        "QpTRUxFQ1QgQFVFX0ZhY3Rvcl9Xb2hua29zdGVuICA9IFJudEhnVWVGYWN0b3IgDQpGUk9NIGRiby5mb" +
                        "ldoS2VubnphaGxlbihudWxsKQ0KDQpTRUxFQ1QgDQogIC0tIEZha3RvcmVuDQogIFNLWi4qLA0KICANC" +
                        "iAgLS0gR3J1bmRiZWRhcmYNCiAgR0JSLiosDQogIFtHQl9UeXBdICAgICAgICAgICAgICAgICAgPSBCU" +
                        "E9fR0JJLkJnUG9zaXRpb25zYXJ0SUQsDQogIFtHQl9UeXBUZXh0XSAgICAgICAgICAgICAgPSBkYm8uZ" +
                        "m5MT1ZUZXh0KCdXaEdydW5kYmVkYXJmVHlwJywgQlBPX0dCSS5CZ1Bvc2l0aW9uc2FydElEKSwNCiAgW" +
                        "0dCX0hHX1NLT1MyMDA1XSAgICAgICAgICA9IENBU0UgV0hFTiBHQlIuSUQgPSAxIFRIRU4NCiAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgKFNFTEVDVCBUT1AgMSBDT05WRVJUKG1vbmV5LCBUTVAuV" +
                        "mFsdWVWYXIpICsgKENPTlZFUlQobW9uZXksIGRiby5mblhDb25maWcoJ1N5c3RlbVxTb3ppYWxoaWxmZ" +
                        "VxTS09TMjAwNVxHQkxfUGVyUGVyc29uJywgQFJlZkRhdGUpKSAqIChTS1ouSGdHcnVuZGJlZGFyZiAtI" +
                        "ENPTlZFUlQoaW50LCBDaGlsZCkpICkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEZST" +
                        "00gZGJvLmZuWENvbmZpZ0NoaWxkKCdTeXN0ZW1cU296aWFsaGlsZmVcU0tPUzIwMDVcR0JMXCcsIEBSZ" +
                        "WZEYXRlKSAgVE1QDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVSRSBDT05WRVJUK" +
                        "GludCwgQ2hpbGQpIDw9IFNLWi5IZ0dydW5kYmVkYXJmDQogICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICBPUkRFUiBCWSBDT05WRVJUKGludCwgQ2hpbGQpIERFU0MpDQogICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICBFTFNFIE5VTEwgRU5ELA0KICBbR0JJX0FucGFzc3VuZ19CZW1lcmt1bmddID0gQ" +
                        "lBPX0dCSS5CZW1lcmt1bmcsDQoNCiAgLS0gV29obnVuZ3NtaWV0ZQ0KICBbV29obnNpdHVhdGlvbl0gI" +
                        "CAgICAgID0gU1VCU1RSSU5HKE5hbWUsIDEsIENIQVJJTkRFWCgnIC0nLCBOYW1lKSAtIDEpLA0KICBbQ" +
                        "mVyZWNobnVuZ3NncnVuZGxhZ2VdID0gJ1dvaG5rb3N0ZW4gJyArIENBU0UgQlBPX01LLkJnUG9zaXRpb" +
                        "25zYXJ0SUQgJSAyIFdIRU4gMCBUSEVOICdnZW0uIFJpY2h0bGluaWVuJyBFTFNFICdpbmRpdmlkdWVsb" +
                        "CcgRU5EICsgJyBiZXN0aW1tZW4nLA0KICBbTWlldGVfQmV0cmFnX0VmZl0gICAgID0gSVNOVUxMKEJQT" +
                        "19NSy5CZXRyYWcsIDApLA0KICBbTWlldGVfQmV0cmFnX0VmZjFdICAgID0gSVNOVUxMKEJQT19NSy5CZ" +
                        "XRyYWcsIDApICoNCiAgICAgICAgICAgICAgICAgICAgICAgICAgIEBVRV9GYWN0b3JfV29obmtvc3Rlb" +
                        "iwNCiAgW01pZXRlX0JldHJhZ19UZXh0XSAgICA9ICdBbnNhdHogJyArIENBU0UgQlBPX01LLkJnUG9za" +
                        "XRpb25zYXJ0SUQgJSAyIFdIRU4gMCBUSEVOICdnZW0uIFJpY2h0bGluaWVuJyBFTFNFICdpbmRpdmlkd" +
                        "WVsbCcgRU5ELA0KICBbTWlldGVfQmV0cmFnXSAgICAgICAgID0gQ0FTRSBXSEVOIElTTlVMTChCUE9fT" +
                        "UsuQmV0cmFnLCAwKSA+IElTTlVMTChCUE9fTUsuTWF4QmVpdHJhZ1NELCAwKSANCiAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgVEhFTiBJU05VTEwoQlBPX01LLk1heEJlaXRyYWdTRCwgMCkgDQogICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgIEVMU0UgSVNOVUxMKEJQT19NSy5CZXRyYWcsIDApIA0KICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgRU5ELA0KICBbTWlldGVfQmV0cmFnMV0gICAgICAgID0gQ0FTR" +
                        "SBXSEVOIElTTlVMTChCUE9fTUsuQmV0cmFnLCAwKSA+IElTTlVMTChCUE9fTUsuTWF4QmVpdHJhZ1NEL" +
                        "CAwKSANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgVEhFTiBJU05VTEwoQlBPX01LLk1heEJla" +
                        "XRyYWdTRCwgMCkgDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgIEVMU0UgSVNOVUxMKEJQT19NS" +
                        "y5CZXRyYWcsIDApIA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgRU5EICogQFVFX0ZhY3Rvcl9Xb" +
                        "2hua29zdGVuLA0KICBbTmViZW5rb3N0ZW5fQmV0cmFnXSAgID0gSVNOVUxMKEJQT19NTksuQmV0cmFnL" +
                        "CAwKSwNCiAgW05lYmVua29zdGVuX0JldHJhZzFdICA9IElTTlVMTChCUE9fTU5LLkJldHJhZywgMCkgK" +
                        "iBAVUVfRmFjdG9yX1dvaG5rb3N0ZW4sDQogIFtBbmdlcmVjaG5XS0FudGVpbF0gICAgPSAoIENBU0UgV" +
                        "0hFTiBJU05VTEwoQlBPX01LLkJldHJhZywgMCkgPiBJU05VTEwoQlBPX01LLk1heEJlaXRyYWdTRCwgM" +
                        "CkgDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgVEhFTiBJU05VTEwoQlBPX01LLk1heEJla" +
                        "XRyYWdTRCwgMCkgDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgRUxTRSBJU05VTEwoQlBPX" +
                        "01LLkJldHJhZywgMCkgDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgIEVORA0KICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICArIElTTlVMTChCUE9fTU5LLkJldHJhZywgMCkpDQogICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAqIEBVRV9GYWN0b3JfV29obmtvc3RlbiwNCiAgW01pZXRlX0JlbWVya3VuZ" +
                        "10gICAgICA9IEJQT19NSy5CZW1lcmt1bmcNCg0KICANCkZST00gQmdCdWRnZXQgIEJERw0KICBMRUZUI" +
                        "CBKT0lOIEJnUG9zaXRpb24gICAgIEJQT19HQkkgT04gQlBPX0dCSS5CZ0J1ZGdldElEICA9IEJERy5CZ" +
                        "0J1ZGdldElEDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgQlBPX0dCS" +
                        "S5CZ1Bvc2l0aW9uc2FydElEIElOIChTRUxFQ1QgQmdQb3NpdGlvbnNhcnRJRCBGUk9NIFdoUG9zaXRpb" +
                        "25zYXJ0DQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICBXSEVSRSBCZ0dydXBwZUNvZGUgPSAzMjAxIEFORCBTb3J0S2V5ID0gM" +
                        "SkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBCUE9fR0JJLkRhdHVtV" +
                        "m9uIElTIE5VTEwNCiAgTEVGVCAgSk9JTiBCZ1Bvc2l0aW9uICAgICBCUE9fTUsgIE9OIEJQT19NSy5CZ" +
                        "0J1ZGdldElEICAgPSBCREcuQmdCdWRnZXRJRCBBTkQgQlBPX01LLkJnUG9zaXRpb25zYXJ0SUQgQkVUV" +
                        "0VFTiA2MiBBTkQgOTkNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBHZ" +
                        "XREYXRlKCkgQkVUV0VFTiBJc051bGwoQlBPX01LLkRhdHVtVm9uLCAnMTkwMDAxMDEnKSAgQU5EIElzT" +
                        "nVsbChCUE9fTUsuRGF0dW1CaXMsIEdldERhdGUoKSkNCiAgTEVGVCAgSk9JTiBXaFBvc2l0aW9uc2Fyd" +
                        "CBTUFRfTUsgIE9OIFNQVF9NSy5CZ1Bvc2l0aW9uc2FydElEID0gQlBPX01LLkJnUG9zaXRpb25zYXJ0S" +
                        "UQNCiAgTEVGVCAgSk9JTiBCZ1Bvc2l0aW9uICAgICBCUE9fTU5LIE9OIEJQT19NTksuQmdCdWRnZXRJR" +
                        "CAgPSBCREcuQmdCdWRnZXRJRCBBTkQgQlBPX01OSy5CZ1Bvc2l0aW9uc2FydElEID0gMzIwNjANCiAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBHZXREYXRlKCkgQkVUV0VFTiBJc" +
                        "051bGwoQlBPX01OSy5EYXR1bVZvbiwgJzE5MDAwMTAxJykgQU5EIElzTnVsbChCUE9fTU5LLkRhdHVtQ" +
                        "mlzLCBHZXREYXRlKCkpDQogICwgQEdydW5kYmVkYXJmIEdCUg0KICAsIGRiby5mbldoS2VubnphaGxlb" +
                        "ihudWxsKSAgU0taDQpXSEVSRSBCREcuQmdCdWRnZXRJRCA9IEBCZ0J1ZGdldElE";
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
            DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary10 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary11 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary12 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter3 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.lblGBHGBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.hiderPanel = new DevExpress.XtraReports.UI.XRPanel();
            this.hiderGB_Typ = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblGBHG = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine6 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblGBHGBetrag,
                        this.xrLabel15,
                        this.xrLabel17});
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
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.hiderPanel});
            this.PageHeader.Height = 40;
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
                        this.xrLine2,
                        this.xrLine1,
                        this.xrLabel11,
                        this.xrLabel9,
                        this.xrLabel8,
                        this.xrLabel7,
                        this.xrLabel6,
                        this.xrLabel4,
                        this.xrLabel3,
                        this.xrLabel2,
                        this.xrLabel1});
            this.GroupHeader1.Height = 103;
            this.GroupHeader1.Level = 2;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblGBHG,
                        this.xrLabel13,
                        this.xrLine3,
                        this.xrLabel12,
                        this.xrLabel10,
                        this.xrLabel5});
            this.GroupHeader2.Height = 83;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            this.GroupHeader2.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader2.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader2.ParentStyleUsing.UseBorders = false;
            this.GroupHeader2.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader2.ParentStyleUsing.UseFont = false;
            this.GroupHeader2.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter3
            // 
            this.GroupFooter3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel39,
                        this.xrLabel38,
                        this.xrLine6});
            this.GroupFooter3.Height = 22;
            this.GroupFooter3.Name = "GroupFooter3";
            this.GroupFooter3.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter3.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter3.ParentStyleUsing.UseBorders = false;
            this.GroupFooter3.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter3.ParentStyleUsing.UseFont = false;
            this.GroupFooter3.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel37});
            this.GroupFooter2.Height = 19;
            this.GroupFooter2.Level = 1;
            this.GroupFooter2.Name = "GroupFooter2";
            this.GroupFooter2.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter2.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter2.ParentStyleUsing.UseBorders = false;
            this.GroupFooter2.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter2.ParentStyleUsing.UseFont = false;
            this.GroupFooter2.ParentStyleUsing.UseForeColor = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel36,
                        this.xrLabel35,
                        this.xrLabel34,
                        this.xrLabel33,
                        this.xrLabel32,
                        this.xrLabel31,
                        this.xrLabel30,
                        this.xrLabel29,
                        this.xrLabel28,
                        this.xrLabel27,
                        this.xrLabel26,
                        this.xrLabel25,
                        this.xrLine5,
                        this.xrLine4,
                        this.xrLabel24,
                        this.xrLabel23,
                        this.xrLabel22,
                        this.xrLabel21,
                        this.xrLabel20,
                        this.xrLabel19,
                        this.xrLabel18});
            this.GroupFooter1.Height = 211;
            this.GroupFooter1.Level = 2;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // lblGBHGBetrag
            // 
            this.lblGBHGBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GB_HG_SKOS2005", "{0:n2}")});
            this.lblGBHGBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.lblGBHGBetrag.Location = new System.Drawing.Point(267, 0);
            this.lblGBHGBetrag.Name = "lblGBHGBetrag";
            this.lblGBHGBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblGBHGBetrag.ParentStyleUsing.UseFont = false;
            this.lblGBHGBetrag.Size = new System.Drawing.Size(100, 17);
            this.lblGBHGBetrag.Text = "lblGBHGBetrag";
            this.lblGBHGBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.lblGBHGBetrag.Visible = false;
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "UE_Betrag", "{0:n2}")});
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel15.Location = new System.Drawing.Point(483, 0);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.ParentStyleUsing.UseFont = false;
            this.xrLabel15.Size = new System.Drawing.Size(100, 17);
            this.xrLabel15.Text = "xrLabel15";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel17
            // 
            this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GB_Text", "")});
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel17.Location = new System.Drawing.Point(8, 0);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.ParentStyleUsing.UseFont = false;
            this.xrLabel17.Size = new System.Drawing.Size(366, 17);
            this.xrLabel17.Text = "xrLabel17";
            // 
            // hiderPanel
            // 
            this.hiderPanel.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.hiderGB_Typ});
            this.hiderPanel.Location = new System.Drawing.Point(160, 0);
            this.hiderPanel.Name = "hiderPanel";
            this.hiderPanel.Size = new System.Drawing.Size(373, 40);
            this.hiderPanel.Visible = false;
            // 
            // hiderGB_Typ
            // 
            this.hiderGB_Typ.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GB_Typ", "")});
            this.hiderGB_Typ.Location = new System.Drawing.Point(0, 0);
            this.hiderGB_Typ.Name = "hiderGB_Typ";
            this.hiderGB_Typ.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hiderGB_Typ.Scripts.OnAfterPrint = resources.GetString("hiderGB_Typ.Scripts.OnAfterPrint");
            this.hiderGB_Typ.Size = new System.Drawing.Size(100, 13);
            // 
            // xrLine2
            // 
            this.xrLine2.ForeColor = System.Drawing.Color.Black;
            this.xrLine2.Location = new System.Drawing.Point(0, 100);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.ParentStyleUsing.UseBackColor = false;
            this.xrLine2.ParentStyleUsing.UseBorderColor = false;
            this.xrLine2.ParentStyleUsing.UseBorders = false;
            this.xrLine2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine2.ParentStyleUsing.UseFont = false;
            this.xrLine2.ParentStyleUsing.UseForeColor = false;
            this.xrLine2.Size = new System.Drawing.Size(629, 2);
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.Location = new System.Drawing.Point(0, 65);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(629, 2);
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "UeWohnkosten", "")});
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel11.ForeColor = System.Drawing.Color.Black;
            this.xrLabel11.Location = new System.Drawing.Point(483, 84);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.ParentStyleUsing.UseBackColor = false;
            this.xrLabel11.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel11.ParentStyleUsing.UseBorders = false;
            this.xrLabel11.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel11.ParentStyleUsing.UseFont = false;
            this.xrLabel11.ParentStyleUsing.UseForeColor = false;
            this.xrLabel11.Size = new System.Drawing.Size(98, 19);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.xrLabel11.Summary = xrSummary1;
            this.xrLabel11.Text = "xrLabel11";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "UeGrundbedarf", "")});
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel9.ForeColor = System.Drawing.Color.Black;
            this.xrLabel9.Location = new System.Drawing.Point(483, 68);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.ParentStyleUsing.UseBackColor = false;
            this.xrLabel9.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel9.ParentStyleUsing.UseBorders = false;
            this.xrLabel9.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.ParentStyleUsing.UseForeColor = false;
            this.xrLabel9.Size = new System.Drawing.Size(98, 19);
            xrSummary2.FormatString = "{0:#,##0.00}";
            this.xrLabel9.Summary = xrSummary2;
            this.xrLabel9.Text = "xrLabel9";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "HgWohnkosten", "")});
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel8.ForeColor = System.Drawing.Color.Black;
            this.xrLabel8.Location = new System.Drawing.Point(267, 84);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseBackColor = false;
            this.xrLabel8.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel8.ParentStyleUsing.UseBorders = false;
            this.xrLabel8.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.ParentStyleUsing.UseForeColor = false;
            this.xrLabel8.Size = new System.Drawing.Size(98, 19);
            xrSummary3.FormatString = "{0:#,##0.00}";
            this.xrLabel8.Summary = xrSummary3;
            this.xrLabel8.Text = "xrLabel8";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "HgGrundbedarf", "")});
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel7.ForeColor = System.Drawing.Color.Black;
            this.xrLabel7.Location = new System.Drawing.Point(267, 68);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseBackColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorders = false;
            this.xrLabel7.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.ParentStyleUsing.UseForeColor = false;
            this.xrLabel7.Size = new System.Drawing.Size(98, 19);
            xrSummary4.FormatString = "{0:#,##0.00}";
            this.xrLabel7.Summary = xrSummary4;
            this.xrLabel7.Text = "xrLabel7";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.ForeColor = System.Drawing.Color.Black;
            this.xrLabel6.Location = new System.Drawing.Point(8, 84);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseBackColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorders = false;
            this.xrLabel6.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.ParentStyleUsing.UseForeColor = false;
            this.xrLabel6.Size = new System.Drawing.Size(122, 19);
            this.xrLabel6.Text = "Wohnkosten";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.Location = new System.Drawing.Point(8, 68);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.ParentStyleUsing.UseForeColor = false;
            this.xrLabel4.Size = new System.Drawing.Size(122, 19);
            this.xrLabel4.Text = "Grundbedarf";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(450, 48);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(192, 19);
            this.xrLabel3.Text = "Unterstützungseinheit (UE)";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.Location = new System.Drawing.Point(250, 48);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseBackColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorders = false;
            this.xrLabel2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.ParentStyleUsing.UseForeColor = false;
            this.xrLabel2.Size = new System.Drawing.Size(196, 19);
            this.xrLabel2.Text = "Haushaltsgrösse (HG)";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.Location = new System.Drawing.Point(0, 8);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseBackColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.ParentStyleUsing.UseForeColor = false;
            this.xrLabel1.Size = new System.Drawing.Size(413, 19);
            this.xrLabel1.Text = "Faktoren für Haushaltsgrösse und Unterstützungseinheit";
            // 
            // lblGBHG
            // 
            this.lblGBHG.Font = new System.Drawing.Font("Arial", 10F);
            this.lblGBHG.ForeColor = System.Drawing.Color.Black;
            this.lblGBHG.Location = new System.Drawing.Point(250, 58);
            this.lblGBHG.Name = "lblGBHG";
            this.lblGBHG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblGBHG.ParentStyleUsing.UseBackColor = false;
            this.lblGBHG.ParentStyleUsing.UseBorderColor = false;
            this.lblGBHG.ParentStyleUsing.UseBorders = false;
            this.lblGBHG.ParentStyleUsing.UseBorderWidth = false;
            this.lblGBHG.ParentStyleUsing.UseFont = false;
            this.lblGBHG.ParentStyleUsing.UseForeColor = false;
            this.lblGBHG.Size = new System.Drawing.Size(196, 19);
            this.lblGBHG.Text = "Haushaltsgrösse (HG)";
            // 
            // xrLabel13
            // 
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel13.ForeColor = System.Drawing.Color.Black;
            this.xrLabel13.Location = new System.Drawing.Point(450, 58);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.ParentStyleUsing.UseBackColor = false;
            this.xrLabel13.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel13.ParentStyleUsing.UseBorders = false;
            this.xrLabel13.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel13.ParentStyleUsing.UseFont = false;
            this.xrLabel13.ParentStyleUsing.UseForeColor = false;
            this.xrLabel13.Size = new System.Drawing.Size(192, 19);
            this.xrLabel13.Text = "Unterstützungseinheit (UE)";
            // 
            // xrLine3
            // 
            this.xrLine3.ForeColor = System.Drawing.Color.Black;
            this.xrLine3.Location = new System.Drawing.Point(0, 75);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.ParentStyleUsing.UseBackColor = false;
            this.xrLine3.ParentStyleUsing.UseBorderColor = false;
            this.xrLine3.ParentStyleUsing.UseBorders = false;
            this.xrLine3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine3.ParentStyleUsing.UseFont = false;
            this.xrLine3.ParentStyleUsing.UseForeColor = false;
            this.xrLine3.Size = new System.Drawing.Size(629, 2);
            // 
            // xrLabel12
            // 
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.xrLabel12.ForeColor = System.Drawing.Color.Black;
            this.xrLabel12.Location = new System.Drawing.Point(0, 11);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.ParentStyleUsing.UseBackColor = false;
            this.xrLabel12.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel12.ParentStyleUsing.UseBorders = false;
            this.xrLabel12.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel12.ParentStyleUsing.UseFont = false;
            this.xrLabel12.ParentStyleUsing.UseForeColor = false;
            this.xrLabel12.Size = new System.Drawing.Size(149, 19);
            this.xrLabel12.Text = "Grundbedarf";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel10.ForeColor = System.Drawing.Color.Black;
            this.xrLabel10.Location = new System.Drawing.Point(0, 33);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.ParentStyleUsing.UseBackColor = false;
            this.xrLabel10.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel10.ParentStyleUsing.UseBorders = false;
            this.xrLabel10.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel10.ParentStyleUsing.UseFont = false;
            this.xrLabel10.ParentStyleUsing.UseForeColor = false;
            this.xrLabel10.Size = new System.Drawing.Size(149, 19);
            this.xrLabel10.Text = "Berechnungsgrundlage";
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GB_TypText", "")});
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel5.ForeColor = System.Drawing.Color.Black;
            this.xrLabel5.Location = new System.Drawing.Point(150, 33);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseBackColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorders = false;
            this.xrLabel5.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.ParentStyleUsing.UseForeColor = false;
            this.xrLabel5.Size = new System.Drawing.Size(496, 19);
            this.xrLabel5.Text = "xrLabel5";
            // 
            // xrLabel39
            // 
            this.xrLabel39.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "UE_Betrag", "{0:n2}")});
            this.xrLabel39.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel39.ForeColor = System.Drawing.Color.Black;
            this.xrLabel39.Location = new System.Drawing.Point(485, 3);
            this.xrLabel39.Multiline = true;
            this.xrLabel39.Name = "xrLabel39";
            this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel39.ParentStyleUsing.UseBackColor = false;
            this.xrLabel39.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel39.ParentStyleUsing.UseBorders = false;
            this.xrLabel39.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel39.ParentStyleUsing.UseFont = false;
            this.xrLabel39.ParentStyleUsing.UseForeColor = false;
            this.xrLabel39.Size = new System.Drawing.Size(98, 19);
            xrSummary5.FormatString = "{0:n2}";
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel39.Summary = xrSummary5;
            this.xrLabel39.Text = "xrLabel39";
            this.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel38
            // 
            this.xrLabel38.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel38.ForeColor = System.Drawing.Color.Black;
            this.xrLabel38.Location = new System.Drawing.Point(150, 3);
            this.xrLabel38.Name = "xrLabel38";
            this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel38.ParentStyleUsing.UseBackColor = false;
            this.xrLabel38.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel38.ParentStyleUsing.UseBorders = false;
            this.xrLabel38.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel38.ParentStyleUsing.UseFont = false;
            this.xrLabel38.ParentStyleUsing.UseForeColor = false;
            this.xrLabel38.Size = new System.Drawing.Size(322, 19);
            this.xrLabel38.Text = "Total monatlicher Grundbedarf";
            this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLine6
            // 
            this.xrLine6.ForeColor = System.Drawing.Color.Black;
            this.xrLine6.Location = new System.Drawing.Point(0, 0);
            this.xrLine6.Name = "xrLine6";
            this.xrLine6.ParentStyleUsing.UseBackColor = false;
            this.xrLine6.ParentStyleUsing.UseBorderColor = false;
            this.xrLine6.ParentStyleUsing.UseBorders = false;
            this.xrLine6.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine6.ParentStyleUsing.UseFont = false;
            this.xrLine6.ParentStyleUsing.UseForeColor = false;
            this.xrLine6.Size = new System.Drawing.Size(629, 2);
            // 
            // xrLabel37
            // 
            this.xrLabel37.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GBI_Anpassung_Bemerkung", "")});
            this.xrLabel37.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel37.ForeColor = System.Drawing.Color.Black;
            this.xrLabel37.Location = new System.Drawing.Point(0, 0);
            this.xrLabel37.Multiline = true;
            this.xrLabel37.Name = "xrLabel37";
            this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel37.ParentStyleUsing.UseBackColor = false;
            this.xrLabel37.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel37.ParentStyleUsing.UseBorders = false;
            this.xrLabel37.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel37.ParentStyleUsing.UseFont = false;
            this.xrLabel37.ParentStyleUsing.UseForeColor = false;
            this.xrLabel37.Size = new System.Drawing.Size(629, 19);
            this.xrLabel37.Text = "xrLabel37";
            // 
            // xrLabel36
            // 
            this.xrLabel36.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Miete_Bemerkung", "")});
            this.xrLabel36.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel36.ForeColor = System.Drawing.Color.Black;
            this.xrLabel36.Location = new System.Drawing.Point(0, 192);
            this.xrLabel36.Multiline = true;
            this.xrLabel36.Name = "xrLabel36";
            this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel36.ParentStyleUsing.UseBackColor = false;
            this.xrLabel36.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel36.ParentStyleUsing.UseBorders = false;
            this.xrLabel36.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel36.ParentStyleUsing.UseFont = false;
            this.xrLabel36.ParentStyleUsing.UseForeColor = false;
            this.xrLabel36.Size = new System.Drawing.Size(629, 19);
            this.xrLabel36.Text = "xrLabel36";
            // 
            // xrLabel35
            // 
            this.xrLabel35.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Nebenkosten_Betrag1", "{0:n2}")});
            this.xrLabel35.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel35.ForeColor = System.Drawing.Color.Black;
            this.xrLabel35.Location = new System.Drawing.Point(483, 142);
            this.xrLabel35.Multiline = true;
            this.xrLabel35.Name = "xrLabel35";
            this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel35.ParentStyleUsing.UseBackColor = false;
            this.xrLabel35.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel35.ParentStyleUsing.UseBorders = false;
            this.xrLabel35.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel35.ParentStyleUsing.UseFont = false;
            this.xrLabel35.ParentStyleUsing.UseForeColor = false;
            this.xrLabel35.Size = new System.Drawing.Size(98, 19);
            xrSummary6.FormatString = "{0:#,##0.00}";
            this.xrLabel35.Summary = xrSummary6;
            this.xrLabel35.Text = "xrLabel35";
            this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel34
            // 
            this.xrLabel34.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Miete_Betrag1", "{0:n2}")});
            this.xrLabel34.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel34.ForeColor = System.Drawing.Color.Black;
            this.xrLabel34.Location = new System.Drawing.Point(483, 125);
            this.xrLabel34.Multiline = true;
            this.xrLabel34.Name = "xrLabel34";
            this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel34.ParentStyleUsing.UseBackColor = false;
            this.xrLabel34.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel34.ParentStyleUsing.UseBorders = false;
            this.xrLabel34.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel34.ParentStyleUsing.UseFont = false;
            this.xrLabel34.ParentStyleUsing.UseForeColor = false;
            this.xrLabel34.Size = new System.Drawing.Size(98, 19);
            xrSummary7.FormatString = "{0:#,##0.00}";
            this.xrLabel34.Summary = xrSummary7;
            this.xrLabel34.Text = "xrLabel34";
            this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel33
            // 
            this.xrLabel33.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Miete_Betrag_Eff1", "{0:n2}")});
            this.xrLabel33.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel33.ForeColor = System.Drawing.Color.Black;
            this.xrLabel33.Location = new System.Drawing.Point(483, 108);
            this.xrLabel33.Multiline = true;
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.ParentStyleUsing.UseBackColor = false;
            this.xrLabel33.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel33.ParentStyleUsing.UseBorders = false;
            this.xrLabel33.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel33.ParentStyleUsing.UseFont = false;
            this.xrLabel33.ParentStyleUsing.UseForeColor = false;
            this.xrLabel33.Size = new System.Drawing.Size(98, 19);
            xrSummary8.FormatString = "{0:#,##0.00}";
            this.xrLabel33.Summary = xrSummary8;
            this.xrLabel33.Text = "xrLabel33";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel32
            // 
            this.xrLabel32.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Miete_Betrag_Text", "")});
            this.xrLabel32.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel32.ForeColor = System.Drawing.Color.Black;
            this.xrLabel32.Location = new System.Drawing.Point(8, 125);
            this.xrLabel32.Multiline = true;
            this.xrLabel32.Name = "xrLabel32";
            this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel32.ParentStyleUsing.UseBackColor = false;
            this.xrLabel32.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel32.ParentStyleUsing.UseBorders = false;
            this.xrLabel32.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel32.ParentStyleUsing.UseFont = false;
            this.xrLabel32.ParentStyleUsing.UseForeColor = false;
            this.xrLabel32.Size = new System.Drawing.Size(196, 19);
            this.xrLabel32.Text = "xrLabel32";
            // 
            // xrLabel31
            // 
            this.xrLabel31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Berechnungsgrundlage", "")});
            this.xrLabel31.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel31.ForeColor = System.Drawing.Color.Black;
            this.xrLabel31.Location = new System.Drawing.Point(158, 50);
            this.xrLabel31.Multiline = true;
            this.xrLabel31.Name = "xrLabel31";
            this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel31.ParentStyleUsing.UseBackColor = false;
            this.xrLabel31.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel31.ParentStyleUsing.UseBorders = false;
            this.xrLabel31.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel31.ParentStyleUsing.UseFont = false;
            this.xrLabel31.ParentStyleUsing.UseForeColor = false;
            this.xrLabel31.Size = new System.Drawing.Size(472, 19);
            this.xrLabel31.Text = "xrLabel31";
            // 
            // xrLabel30
            // 
            this.xrLabel30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Wohnsituation", "")});
            this.xrLabel30.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel30.ForeColor = System.Drawing.Color.Black;
            this.xrLabel30.Location = new System.Drawing.Point(158, 25);
            this.xrLabel30.Multiline = true;
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel30.ParentStyleUsing.UseBackColor = false;
            this.xrLabel30.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel30.ParentStyleUsing.UseBorders = false;
            this.xrLabel30.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel30.ParentStyleUsing.UseFont = false;
            this.xrLabel30.ParentStyleUsing.UseForeColor = false;
            this.xrLabel30.Size = new System.Drawing.Size(472, 19);
            this.xrLabel30.Text = "xrLabel30";
            // 
            // xrLabel29
            // 
            this.xrLabel29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Nebenkosten_Betrag", "{0:n2}")});
            this.xrLabel29.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel29.ForeColor = System.Drawing.Color.Black;
            this.xrLabel29.Location = new System.Drawing.Point(267, 142);
            this.xrLabel29.Multiline = true;
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel29.ParentStyleUsing.UseBackColor = false;
            this.xrLabel29.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel29.ParentStyleUsing.UseBorders = false;
            this.xrLabel29.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel29.ParentStyleUsing.UseFont = false;
            this.xrLabel29.ParentStyleUsing.UseForeColor = false;
            this.xrLabel29.Size = new System.Drawing.Size(98, 19);
            xrSummary9.FormatString = "{0:#,##0.00}";
            this.xrLabel29.Summary = xrSummary9;
            this.xrLabel29.Text = "xrLabel29";
            this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel28
            // 
            this.xrLabel28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Miete_Betrag", "{0:n2}")});
            this.xrLabel28.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel28.ForeColor = System.Drawing.Color.Black;
            this.xrLabel28.Location = new System.Drawing.Point(267, 125);
            this.xrLabel28.Multiline = true;
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.ParentStyleUsing.UseBackColor = false;
            this.xrLabel28.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel28.ParentStyleUsing.UseBorders = false;
            this.xrLabel28.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel28.ParentStyleUsing.UseFont = false;
            this.xrLabel28.ParentStyleUsing.UseForeColor = false;
            this.xrLabel28.Size = new System.Drawing.Size(98, 19);
            xrSummary10.FormatString = "{0:#,##0.00}";
            this.xrLabel28.Summary = xrSummary10;
            this.xrLabel28.Text = "xrLabel28";
            this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel27
            // 
            this.xrLabel27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Miete_Betrag_Eff", "{0:n2}")});
            this.xrLabel27.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel27.ForeColor = System.Drawing.Color.Black;
            this.xrLabel27.Location = new System.Drawing.Point(267, 108);
            this.xrLabel27.Multiline = true;
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.ParentStyleUsing.UseBackColor = false;
            this.xrLabel27.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel27.ParentStyleUsing.UseBorders = false;
            this.xrLabel27.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel27.ParentStyleUsing.UseFont = false;
            this.xrLabel27.ParentStyleUsing.UseForeColor = false;
            this.xrLabel27.Size = new System.Drawing.Size(98, 19);
            xrSummary11.FormatString = "{0:#,##0.00}";
            this.xrLabel27.Summary = xrSummary11;
            this.xrLabel27.Text = "xrLabel27";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel26
            // 
            this.xrLabel26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AngerechnWKAnteil", "{0:n2}")});
            this.xrLabel26.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel26.ForeColor = System.Drawing.Color.Black;
            this.xrLabel26.Location = new System.Drawing.Point(484, 166);
            this.xrLabel26.Multiline = true;
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.ParentStyleUsing.UseBackColor = false;
            this.xrLabel26.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel26.ParentStyleUsing.UseBorders = false;
            this.xrLabel26.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel26.ParentStyleUsing.UseFont = false;
            this.xrLabel26.ParentStyleUsing.UseForeColor = false;
            this.xrLabel26.Size = new System.Drawing.Size(98, 19);
            xrSummary12.FormatString = "{0:#,##0.00}";
            this.xrLabel26.Summary = xrSummary12;
            this.xrLabel26.Text = "xrLabel26";
            this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel25
            // 
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel25.ForeColor = System.Drawing.Color.Black;
            this.xrLabel25.Location = new System.Drawing.Point(142, 166);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.ParentStyleUsing.UseBackColor = false;
            this.xrLabel25.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel25.ParentStyleUsing.UseBorders = false;
            this.xrLabel25.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel25.ParentStyleUsing.UseFont = false;
            this.xrLabel25.ParentStyleUsing.UseForeColor = false;
            this.xrLabel25.Size = new System.Drawing.Size(322, 19);
            this.xrLabel25.Text = "Angerechneter Wohnkostenanteil inkl. NK";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLine5
            // 
            this.xrLine5.ForeColor = System.Drawing.Color.Black;
            this.xrLine5.Location = new System.Drawing.Point(0, 158);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.ParentStyleUsing.UseBackColor = false;
            this.xrLine5.ParentStyleUsing.UseBorderColor = false;
            this.xrLine5.ParentStyleUsing.UseBorders = false;
            this.xrLine5.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine5.ParentStyleUsing.UseFont = false;
            this.xrLine5.ParentStyleUsing.UseForeColor = false;
            this.xrLine5.Size = new System.Drawing.Size(629, 2);
            // 
            // xrLine4
            // 
            this.xrLine4.ForeColor = System.Drawing.Color.Black;
            this.xrLine4.Location = new System.Drawing.Point(0, 100);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.ParentStyleUsing.UseBackColor = false;
            this.xrLine4.ParentStyleUsing.UseBorderColor = false;
            this.xrLine4.ParentStyleUsing.UseBorders = false;
            this.xrLine4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine4.ParentStyleUsing.UseFont = false;
            this.xrLine4.ParentStyleUsing.UseForeColor = false;
            this.xrLine4.Size = new System.Drawing.Size(629, 2);
            // 
            // xrLabel24
            // 
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel24.ForeColor = System.Drawing.Color.Black;
            this.xrLabel24.Location = new System.Drawing.Point(8, 142);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.ParentStyleUsing.UseBackColor = false;
            this.xrLabel24.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel24.ParentStyleUsing.UseBorders = false;
            this.xrLabel24.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel24.ParentStyleUsing.UseFont = false;
            this.xrLabel24.ParentStyleUsing.UseForeColor = false;
            this.xrLabel24.Size = new System.Drawing.Size(196, 19);
            this.xrLabel24.Text = "Effektive Nebenkosten";
            // 
            // xrLabel23
            // 
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel23.ForeColor = System.Drawing.Color.Black;
            this.xrLabel23.Location = new System.Drawing.Point(8, 108);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.ParentStyleUsing.UseBackColor = false;
            this.xrLabel23.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel23.ParentStyleUsing.UseBorders = false;
            this.xrLabel23.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel23.ParentStyleUsing.UseFont = false;
            this.xrLabel23.ParentStyleUsing.UseForeColor = false;
            this.xrLabel23.Size = new System.Drawing.Size(196, 19);
            this.xrLabel23.Text = "Effektive Zins- rsp. Mietkosten";
            // 
            // xrLabel22
            // 
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel22.ForeColor = System.Drawing.Color.Black;
            this.xrLabel22.Location = new System.Drawing.Point(450, 83);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.ParentStyleUsing.UseBackColor = false;
            this.xrLabel22.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel22.ParentStyleUsing.UseBorders = false;
            this.xrLabel22.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel22.ParentStyleUsing.UseFont = false;
            this.xrLabel22.ParentStyleUsing.UseForeColor = false;
            this.xrLabel22.Size = new System.Drawing.Size(192, 19);
            this.xrLabel22.Text = "Unterstützungseinheit (UE)";
            // 
            // xrLabel21
            // 
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel21.ForeColor = System.Drawing.Color.Black;
            this.xrLabel21.Location = new System.Drawing.Point(250, 83);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.ParentStyleUsing.UseBackColor = false;
            this.xrLabel21.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel21.ParentStyleUsing.UseBorders = false;
            this.xrLabel21.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel21.ParentStyleUsing.UseFont = false;
            this.xrLabel21.ParentStyleUsing.UseForeColor = false;
            this.xrLabel21.Size = new System.Drawing.Size(196, 19);
            this.xrLabel21.Text = "Haushaltsgrösse (HG)";
            // 
            // xrLabel20
            // 
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel20.ForeColor = System.Drawing.Color.Black;
            this.xrLabel20.Location = new System.Drawing.Point(0, 50);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.ParentStyleUsing.UseBackColor = false;
            this.xrLabel20.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel20.ParentStyleUsing.UseBorders = false;
            this.xrLabel20.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel20.ParentStyleUsing.UseFont = false;
            this.xrLabel20.ParentStyleUsing.UseForeColor = false;
            this.xrLabel20.Size = new System.Drawing.Size(149, 19);
            this.xrLabel20.Text = "Berechnungsgrundlage";
            // 
            // xrLabel19
            // 
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel19.ForeColor = System.Drawing.Color.Black;
            this.xrLabel19.Location = new System.Drawing.Point(0, 25);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.ParentStyleUsing.UseBackColor = false;
            this.xrLabel19.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel19.ParentStyleUsing.UseBorders = false;
            this.xrLabel19.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel19.ParentStyleUsing.UseFont = false;
            this.xrLabel19.ParentStyleUsing.UseForeColor = false;
            this.xrLabel19.Size = new System.Drawing.Size(122, 19);
            this.xrLabel19.Text = "Wohnsituation";
            // 
            // xrLabel18
            // 
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.xrLabel18.ForeColor = System.Drawing.Color.Black;
            this.xrLabel18.Location = new System.Drawing.Point(0, 0);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.ParentStyleUsing.UseBackColor = false;
            this.xrLabel18.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel18.ParentStyleUsing.UseBorders = false;
            this.xrLabel18.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel18.ParentStyleUsing.UseFont = false;
            this.xrLabel18.ParentStyleUsing.UseForeColor = false;
            this.xrLabel18.Size = new System.Drawing.Size(149, 19);
            this.xrLabel18.Text = "Wohnungsmiete";
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
                        this.GroupHeader2,
                        this.GroupFooter3,
                        this.GroupFooter2,
                        this.PageFooter,
                        this.GroupFooter1});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(39, 39, 39, 39);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ScriptReferencesString = "System.Windows.Forms.dll";
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'-- Nur für SKOS 2005
DECLARE @BgBudgetID INT,
        @RefDate    datetime
SELECT @BgBudgetID = BgBudgetID, @RefDate = IsNull(FPL.DatumVon, FPL.GeplantVon)
FROM BgFinanzPlan      FPL
  INNER JOIN BgBudget  BDG ON BDG.BgFinanzPlanID = FPL.BgFinanzPlanID
WHERE FPL.BgFinanzPlanID = {BgFinanzPlanID} AND BDG.MasterBudget = 1

DECLARE @Grundbedarf TABLE (
  [ID]          INT NOT NULL IDENTITY (1, 1),
  [GB_Text]     VARCHAR(200),
  [UE_Betrag]   MONEY,
  [Bemerkungen] VARCHAR(1000)
)

-- Grundbedarf
INSERT INTO @Grundbedarf (GB_Text, UE_Betrag)
  SELECT 
    POA.Name, 
    POS.Betrag
  FROM vwBgPosition           POS
    INNER JOIN BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
  WHERE POS.BgBudgetID = @BgBudgetID AND POS.DatumVon IS NULL
    AND POS.BgPositionsartID IN (SELECT BgPositionsartID 
                                 FROM BgPositionsart
                                 WHERE BgGruppeCode = 3201 AND SortKey = 1)

-- Anpassung
INSERT INTO @Grundbedarf (GB_Text, UE_Betrag)
  SELECT 
    ''Anpassung (siehe Bemerkung)'', 
    CASE WHEN POS.Reduktion <> $0.00 
      THEN -POS.Reduktion 
      ELSE $0.00 
    END
  FROM vwBgPosition           POS
    INNER JOIN BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
  WHERE POS.BgBudgetID = @BgBudgetID AND POS.DatumVon IS NULL
    AND POS.BgPositionsartID IN (SELECT BgPositionsartID 
                                 FROM BgPositionsart
                                 WHERE BgGruppeCode = 3201 AND SortKey = 1)
-- VVG-Beiträge
INSERT INTO @Grundbedarf (GB_Text, UE_Betrag)
  SELECT 
    ''VVG-Beitrage'', 
    SUM(-Betrag - Reduktion)    -- Abzug VVG wenn nicht von SD übernommen
  FROM BgPosition POS
    INNER JOIN BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
  WHERE POS.BgBudgetID = @BgBudgetID 
    AND POA.BgPositionsartCode = 32021
    AND POS.MaxBeitragSD = $0.00
    AND GetDate() BETWEEN IsNull(POS.DatumVon, ''19000101'') AND IsNull(POS.DatumBis, ''99991231'')


-- Zulagen/EFB, Sanktionen
INSERT INTO @Grundbedarf (GB_Text, UE_Betrag, Bemerkungen)
  SELECT
    GB_Text = dbo.fnLOVText(''BgGruppe'', POA.BgGruppeCode) + 
              CASE WHEN POA.BgGruppeCode IN (39110, 39130, 39210, 39910) THEN '' Alleinerziehend '' ELSE '' '' END + 
              POA.Name + 
              ''  ('' + PRS.VornameName + '')'',
    CASE WHEN POS.BgKategorieCode = 2 
      THEN POS.BetragFinanzplan 
      ELSE -POS.BetragFinanzplan 
    END,
    POS.Bemerkung
  FROM vwBgPosition           POS
    INNER JOIN BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
    INNER JOIN vwPerson       PRS ON PRS.BaPersonID = POS.BaPersonID
  WHERE POS.BgBudgetID = @BgBudgetID 
    AND POS.DatumVon IS NULL
    AND POA.BgGruppeCode BETWEEN 39000 AND 39999
;WITH cte AS
(
SELECT 
  -- Faktoren
  SKZ.*,
  
  -- Grundbedarf
  GBR.*,
  [GB_Typ]                  = BPO_GBI.BgPositionsartCode,
  [GB_TypText]              = dbo.fnLOVText(''WhGrundbedarfTyp'', BPO_GBI.BgPositionsartCode),
  [GB_HG_SKOS2005]          = CASE WHEN GBR.ID = 1 THEN
                                (SELECT TOP 1 CONVERT(money, TMP.ValueVar) + (CONVERT(money, dbo.fnXConfig(''System\Sozialhilfe\SKOS2005\GBL_PerPerson'', @RefDate)) * (SKZ.HgGrundbedarf - CONVERT(int, Child)) )
                                 FROM dbo.fnXConfigChild(''System\Sozialhilfe\SKOS2005\GBL\'', @RefDate)  TMP
                                 WHERE CONVERT(int, Child) <= SKZ.HgGrundbedarf
                                 ORDER BY CONVERT(int, Child) DESC)
                              ELSE NULL END,
  [GBI_Anpassung_Bemerkung] = BPO_GBI.Bemerkung,

  -- Wohnungsmiete
  [Wohnsituation]        = SUBSTRING(BPO_MK.Name, 1, CHARINDEX('' -'', BPO_MK.Name) - 1),
  [Berechnungsgrundlage] = ''Wohnkosten '' + CASE BPO_MK.BgPositionsartCode % 2 WHEN 0 THEN ''gem. Richtlinien'' ELSE ''individuell'' END + '' bestimmen'',
  [Miete_Betrag_Eff]     = ISNULL(BPO_MK.Betrag, 0),
  [Miete_Betrag_Eff1]    = ISNULL(BPO_MK.Betrag, 0) - ISNULL(BPO_MK.Reduktion, 0),
  [Miete_Betrag_Richtlinie] = (SELECT dbo.fnShWohnkosten_Hg(SFP.BgFinanzplanID, SFP.DatumVon)),
  [Miete_Betrag_Text]    = ''Ansatz '' + CASE BPO_MK.BgPositionsartCode % 2 WHEN 0 THEN ''gem. Richtlinien'' ELSE ''individuell'' END,
  [Miete_Betrag]         = ISNULL(BPO_MK.Betrag, 0) - ISNULL(BPO_MK.Abzug, 0),
  [Miete_Betrag1]        = ISNULL(BPO_MK.Betrag, 0) - ISNULL(BPO_MK.Abzug, 0) - ISNULL(BPO_MK.Reduktion, 0),
  [Nebenkosten_Betrag]   = ISNULL(BPO_MNK.Betrag, 0),
  [Nebenkosten_Betrag1]  = ISNULL(BPO_MNK.Betrag, 0) - ISNULL(BPO_MNK.Reduktion, 0),
  [AngerechnWKAnteil]    = ISNULL(BPO_MK.Betrag, 0) - ISNULL(BPO_MK.Abzug, 0) - ISNULL(BPO_MK.Reduktion, 0)
                            + ISNULL(BPO_MNK.Betrag, 0) - ISNULL(BPO_MNK.Reduktion, 0),
  [Miete_Bemerkung]      = BPO_MK.Bemerkung

  
FROM BgBudget  BDG
  INNER JOIN BgFinanzplan      SFP ON SFP.BgFinanzplanID = BDG.BgFinanzplanID
  LEFT JOIN (SELECT BPOI.*, POAI.BgPositionsartCode
             FROM BgPosition BPOI
               INNER JOIN BgPositionsart POAI ON POAI.BgPositionsartID = BPOI.BgPositionsartID
             WHERE POAI.BgGruppeCode = 3201 AND POAI.SortKey = 1) 
                            BPO_GBI ON BPO_GBI.BgBudgetID = BDG.BgBudgetID
                                   AND BPO_GBI.DatumVon IS NULL                                       
                                       
  LEFT JOIN (SELECT BPOI.*, POAI.BgPositionsartCode, Name
             FROM BgPosition BPOI
               INNER JOIN BgPositionsart POAI ON POAI.BgPositionsartID = BPOI.BgPositionsartID
             WHERE POAI.BgPositionsartCode BETWEEN 62 AND 99) 
                            BPO_MK  ON BPO_MK.BgBudgetID = BDG.BgBudgetID
                                   AND GetDate() BETWEEN IsNull(BPO_MK.DatumVon, ''19000101'')  AND IsNull(BPO_MK.DatumBis, GetDate())

  LEFT JOIN (SELECT BPOI.*, POAI.BgPositionsartCode, Name
             FROM BgPosition BPOI
               INNER JOIN BgPositionsart POAI ON POAI.BgPositionsartID = BPOI.BgPositionsartID
             WHERE POAI.BgPositionsartCode = 32060) 
                            BPO_MNK ON BPO_MNK.BgBudgetID = BDG.BgBudgetID
                                   AND GetDate() BETWEEN IsNull(BPO_MNK.DatumVon, ''19000101'') AND IsNull(BPO_MNK.DatumBis, GetDate())
                                       
  , @Grundbedarf GBR
 , dbo.fnWhKennzahlen({BgFinanzplanID})  SKZ
WHERE BDG.BgBudgetID = @BgBudgetID
)

SELECT 
  HgGrundbedarf,
  UeGrundbedarf,
  HgWohnkosten,
  UeWohnkosten,
  HgZuschlagI,
  UeZuschlagI,
  B23Amount,  
  GBUseHgUeFactor,
  RntUseHgUeFactor,
  GBHgUeFactor,
  RntHgUeFactor,
  RefDate,
  ID,
  GB_Text,
  UE_Betrag,
  Bemerkungen,  
  GB_Typ,
  GB_TypText,
  GB_HG_SKOS2005,
  GBI_Anpassung_Bemerkung,
  Wohnsituation,
  Berechnungsgrundlage,
  Miete_Betrag_Eff,
  Miete_Betrag_Eff1,
  Miete_Betrag_Text,
  Miete_Betrag= CASE WHEN Miete_Betrag > Miete_Betrag_Richtlinie THEN Miete_Betrag_Richtlinie ELSE Miete_Betrag END,
  Miete_Betrag1,
  Nebenkosten_Betrag,
  Nebenkosten_Betrag1,
  AngerechnWKAnteil,
  Miete_Bemerkung
FROM CTE' ,  null ,  N'ShDetaillierterFinanzplanStandard' ,  null ,  1 );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'ShDetaillierterFinanzplanStandard_KvgVvg' ,  N'KVG, VVG' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS40.VSS\KiSS4 Branches\KiSS4233\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\KiSS40.VSS\KiSS4 Branches\KiSS4233\Build\Debug\log4net.dll" />
///     <Reference Path="C:\Projects\KiSS40.VSS\KiSS4 Branches\KiSS4233\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel txtBemerkungRTF;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtVVG_Reduktion;
        private DevExpress.XtraReports.UI.XRLabel txtVVG;
        private DevExpress.XtraReports.UI.XRLabel txtKVG_Reduktion;
        private DevExpress.XtraReports.UI.XRLabel txtKVG;
        private DevExpress.XtraReports.UI.XRLabel txtName;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLine Line6;
        private DevExpress.XtraReports.UI.XRLine Line5;
        private DevExpress.XtraReports.UI.XRLine Line4;
        private DevExpress.XtraReports.UI.XRLabel Label13;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLabel totVVG_Reduziert;
        private DevExpress.XtraReports.UI.XRLabel totKVG_Reduziert;
        private DevExpress.XtraReports.UI.XRLabel Label9;
        private DevExpress.XtraReports.UI.XRLabel TextBox4;
        private DevExpress.XtraReports.UI.XRLabel TextBox3;
        private DevExpress.XtraReports.UI.XRLabel TextBox2;
        private DevExpress.XtraReports.UI.XRLabel TextBox1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
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
                        "AAAAcsUREVDTEFSRSBAQmdGaW5hbnpwbGFuSUQgSU5ULA0KICAgICAgICBARlBWb24gREFURVRJTUUsD" +
                        "QogICAgICAgIEBGUEJpcyBEQVRFVElNRSwNCiAgICAgICAgQERhdGUgIERBVEVUSU1FDQoNClNFVCBAQ" +
                        "mdGaW5hbnpwbGFuSUQgPSBudWxsIA0KDQpTRUxFQ1QgDQogIEBGUFZvbiA9IElTTlVMTChEYXR1bVZvb" +
                        "iwgR2VwbGFudFZvbiksDQogIEBGUEJpcyA9IElTTlVMTChEYXR1bUJpcywgR2VwbGFudEJpcykNCkZST" +
                        "00gZGJvLkJnRmluYW56cGxhbiBXSVRIIChSRUFEVU5DT01NSVRURUQpDQpXSEVSRSBCZ0ZpbmFuenBsY" +
                        "W5JRCA9IEBCZ0ZpbmFuenBsYW5JRA0KDQpTRVQgQERhdGUgPSBHRVREQVRFKCkNCg0KSUYgQERhdGUgP" +
                        "CBARlBWb24NCkJFR0lODQogIFNFVCBARGF0ZSA9IEBGUFZvbg0KRU5EDQpFTFNFIElGIEBEYXRlID4gQ" +
                        "EZQQmlzDQpCRUdJTg0KICBTRVQgQERhdGUgPSBARlBCaXMNCkVORA0KDQpTRUxFQ1QNCiAgW05hbWVdI" +
                        "CAgICAgICAgICA9IFBSUy5OYW1lICsgJywgJyArIFBSUy5Wb3JuYW1lLA0KDQogIFtLVkddICAgICAgI" +
                        "CAgICAgPSBQT1MuQmV0cmFnLA0KICBbS1ZHX1JlZHVrdGlvbl0gID0gUE9TLlJlZHVrdGlvbiwNCiAgW" +
                        "0tWR19SZWR1emllcnRdICA9IFBPUy5CZXRyYWcgLSBQT1MuUmVkdWt0aW9uLA0KDQogIFtWVkddICAgI" +
                        "CAgICAgICAgPSBWVkcuQmV0cmFnLA0KICBbVlZHX1JlZHVrdGlvbl0gID0gVlZHLlJlZHVrdGlvbiwNC" +
                        "iAgW1ZWR19SZWR1emllcnRdICA9IFZWRy5CZXRyYWcgLSBWVkcuUmVkdWt0aW9uLA0KDQogIFtCZW1lc" +
                        "mt1bmddICAgICAgPSBLVkcuQmVtZXJrdW5nDQosICctLS1QT1MtLS0nLFBPUy4qIA0KLCAnLS0tS1ZHL" +
                        "S0tJyxLVkcuKiANCiwgJy0tLVZWRy0tLScsVlZHLiogDQpGUk9NIEJnRmluYW56cGxhbl9CYVBlcnNvb" +
                        "iAgIEZQUA0KICBJTk5FUiBKT0lOIEJnQnVkZ2V0ICAgICAgICBCREcgICAgIE9OIEJERy5CZ0ZpbmFue" +
                        "nBsYW5JRCA9IEZQUC5CZ0ZpbmFuenBsYW5JRCANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgIEFORCBCREcuTWFzdGVyQnVkZ2V0ID0gMQ0KICBJTk5FUiBKT0lOIEJhUGVyc29uICAgICAgI" +
                        "CBQUlMgICAgIE9OIFBSUy5CYVBlcnNvbklEID0gRlBQLkJhUGVyc29uSUQNCiAgSU5ORVIgSk9JTiBCZ" +
                        "1Bvc2l0aW9uICAgICAgUE9TICAgICBPTiBQT1MuQmdCdWRnZXRJRCA9IEJERy5CZ0J1ZGdldElEDQogI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBTkQgUE9TLkJhUGVyc29uSUQgPSBGUFAuQ" +
                        "mFQZXJzb25JRA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEBEYXRlIEJFV" +
                        "FdFRU4gSVNOVUxMKFBPUy5EYXR1bVZvbiwgQEZQVm9uKSBBTkQgSVNOVUxMKFBPUy5EYXR1bUJpcywgQ" +
                        "EZQQmlzKQ0KICBJTk5FUiBKT0lOIEJnUG9zaXRpb25zYXJ0ICBQT0EgICAgIE9OIFBPQS5CZ1Bvc2l0a" +
                        "W9uc2FydElEID0gUE9TLkJnUG9zaXRpb25zYXJ0SUQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgIEFORCAoUE9BLkJnUG9zaXRpb25zYXJ0Q29kZSA9IDMyMDIwIA0KICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICBPUiBQT0EuQmdQb3NpdGlvbnNhcnRDb2RlIEJFVFdFRU4gM" +
                        "zIxMjEgQU5EIDMyMTMwKQ0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICANCiAgT" +
                        "EVGVCBKT0lOIChTRUxFQ1QgQlBPSS4qLCBQT0FJLkJnUG9zaXRpb25zYXJ0Q29kZQ0KICAgICAgICAgI" +
                        "CAgIEZST00gQmdQb3NpdGlvbiBCUE9JDQogICAgICAgICAgICAgICBJTk5FUiBKT0lOIEJnUG9zaXRpb" +
                        "25zYXJ0IFBPQUkgT04gUE9BSS5CZ1Bvc2l0aW9uc2FydElEID0gQlBPSS5CZ1Bvc2l0aW9uc2FydElED" +
                        "QogICAgICAgICAgICAgV0hFUkUgUE9BSS5CZ1Bvc2l0aW9uc2FydENvZGUgSU4gKDMyMDIzLCAzMjAyN" +
                        "CkpIA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICBLVkcgICAgIE9OIEtWRy5CZ0J1ZGdldElEI" +
                        "D0gUE9TLkJnQnVkZ2V0SUQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBLV" +
                        "kcuQmdQb3NpdGlvbklEX1BhcmVudCA9IFBPUy5CZ1Bvc2l0aW9uSUQNCiAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICANCiAgTEVGVCBKT0lOIChTRUxFQ1QgQlBPSS4qLCBQT0FJLkJnU" +
                        "G9zaXRpb25zYXJ0Q29kZQ0KICAgICAgICAgICAgIEZST00gQmdQb3NpdGlvbiBCUE9JDQogICAgICAgI" +
                        "CAgICAgICBJTk5FUiBKT0lOIEJnUG9zaXRpb25zYXJ0IFBPQUkgT04gUE9BSS5CZ1Bvc2l0aW9uc2Fyd" +
                        "ElEID0gQlBPSS5CZ1Bvc2l0aW9uc2FydElEDQogICAgICAgICAgICAgV0hFUkUgUE9BSS5CZ1Bvc2l0a" +
                        "W9uc2FydENvZGUgSU4gKDMyMDIxLCAzMjAyMikpIA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CBWVkcgICAgIE9OIFZWRy5CZ0J1ZGdldElEID0gUE9TLkJnQnVkZ2V0SUQNCiAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgIEFORCBWVkcuQmdQb3NpdGlvbklEX1BhcmVudCA9IFBPUy5CZ1Bvc" +
                        "2l0aW9uSUQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIA0KV0hFUkUgRlBQLkJnR" +
                        "mluYW56cGxhbklEID0gQEJnRmluYW56cGxhbklEDQogIEFORCBGUFAuSXN0VW50ZXJzdHVldHp0ID0gM" +
                        "Q==";
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
            DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary10 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.txtBemerkungRTF = new DevExpress.XtraReports.UI.XRLabel();
            this.txtVVG_Reduktion = new DevExpress.XtraReports.UI.XRLabel();
            this.txtVVG = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKVG_Reduktion = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKVG = new DevExpress.XtraReports.UI.XRLabel();
            this.txtName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line6 = new DevExpress.XtraReports.UI.XRLine();
            this.Line5 = new DevExpress.XtraReports.UI.XRLine();
            this.Line4 = new DevExpress.XtraReports.UI.XRLine();
            this.Label13 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.totVVG_Reduziert = new DevExpress.XtraReports.UI.XRLabel();
            this.totKVG_Reduziert = new DevExpress.XtraReports.UI.XRLabel();
            this.Label9 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox4 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox3 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox2 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox1 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Line1,
                        this.txtBemerkungRTF,
                        this.txtVVG_Reduktion,
                        this.txtVVG,
                        this.txtKVG_Reduktion,
                        this.txtKVG,
                        this.txtName});
            this.Detail.Height = 46;
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
            this.ReportHeader.Height = 0;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.ParentStyleUsing.UseBackColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorderColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorders = false;
            this.ReportHeader.ParentStyleUsing.UseBorderWidth = false;
            this.ReportHeader.ParentStyleUsing.UseFont = false;
            this.ReportHeader.ParentStyleUsing.UseForeColor = false;
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
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel6,
                        this.xrLabel2,
                        this.xrLabel1,
                        this.xrLabel8,
                        this.xrLabel7,
                        this.xrLabel5,
                        this.xrLabel4,
                        this.xrLabel3});
            this.GroupHeader1.Height = 69;
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
                        this.Line6,
                        this.Line5,
                        this.Line4,
                        this.Label13,
                        this.Line3,
                        this.totVVG_Reduziert,
                        this.totKVG_Reduziert,
                        this.Label9,
                        this.TextBox4,
                        this.TextBox3,
                        this.TextBox2,
                        this.TextBox1});
            this.GroupFooter1.Height = 78;
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
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Height = 0;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
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
            this.Line1.Size = new System.Drawing.Size(681, 2);
            // 
            // txtBemerkungRTF
            // 
            this.txtBemerkungRTF.CanShrink = true;
            this.txtBemerkungRTF.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bemerkung", "")});
            this.txtBemerkungRTF.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.txtBemerkungRTF.ForeColor = System.Drawing.Color.Black;
            this.txtBemerkungRTF.Location = new System.Drawing.Point(3, 23);
            this.txtBemerkungRTF.Multiline = true;
            this.txtBemerkungRTF.Name = "txtBemerkungRTF";
            this.txtBemerkungRTF.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBemerkungRTF.ParentStyleUsing.UseBackColor = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorderColor = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorders = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseBorderWidth = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseFont = false;
            this.txtBemerkungRTF.ParentStyleUsing.UseForeColor = false;
            this.txtBemerkungRTF.Size = new System.Drawing.Size(677, 19);
            this.txtBemerkungRTF.Text = "txtBemerkungRTF";
            this.txtBemerkungRTF.WordWrap = false;
            // 
            // txtVVG_Reduktion
            // 
            this.txtVVG_Reduktion.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VVG_Reduktion", "{0:n2}")});
            this.txtVVG_Reduktion.Font = new System.Drawing.Font("Arial", 10F);
            this.txtVVG_Reduktion.ForeColor = System.Drawing.Color.Black;
            this.txtVVG_Reduktion.Location = new System.Drawing.Point(582, 3);
            this.txtVVG_Reduktion.Multiline = true;
            this.txtVVG_Reduktion.Name = "txtVVG_Reduktion";
            this.txtVVG_Reduktion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtVVG_Reduktion.ParentStyleUsing.UseBackColor = false;
            this.txtVVG_Reduktion.ParentStyleUsing.UseBorderColor = false;
            this.txtVVG_Reduktion.ParentStyleUsing.UseBorders = false;
            this.txtVVG_Reduktion.ParentStyleUsing.UseBorderWidth = false;
            this.txtVVG_Reduktion.ParentStyleUsing.UseFont = false;
            this.txtVVG_Reduktion.ParentStyleUsing.UseForeColor = false;
            this.txtVVG_Reduktion.Size = new System.Drawing.Size(98, 19);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtVVG_Reduktion.Summary = xrSummary1;
            this.txtVVG_Reduktion.Text = "VVG_Reduktion";
            this.txtVVG_Reduktion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtVVG
            // 
            this.txtVVG.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VVG", "{0:n2}")});
            this.txtVVG.Font = new System.Drawing.Font("Arial", 10F);
            this.txtVVG.ForeColor = System.Drawing.Color.Black;
            this.txtVVG.Location = new System.Drawing.Point(484, 3);
            this.txtVVG.Multiline = true;
            this.txtVVG.Name = "txtVVG";
            this.txtVVG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtVVG.ParentStyleUsing.UseBackColor = false;
            this.txtVVG.ParentStyleUsing.UseBorderColor = false;
            this.txtVVG.ParentStyleUsing.UseBorders = false;
            this.txtVVG.ParentStyleUsing.UseBorderWidth = false;
            this.txtVVG.ParentStyleUsing.UseFont = false;
            this.txtVVG.ParentStyleUsing.UseForeColor = false;
            this.txtVVG.Size = new System.Drawing.Size(98, 19);
            xrSummary2.FormatString = "{0:#,##0.00}";
            this.txtVVG.Summary = xrSummary2;
            this.txtVVG.Text = "VVG";
            this.txtVVG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtKVG_Reduktion
            // 
            this.txtKVG_Reduktion.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KVG_Reduktion", "{0:n2}")});
            this.txtKVG_Reduktion.Font = new System.Drawing.Font("Arial", 10F);
            this.txtKVG_Reduktion.ForeColor = System.Drawing.Color.Black;
            this.txtKVG_Reduktion.Location = new System.Drawing.Point(346, 3);
            this.txtKVG_Reduktion.Multiline = true;
            this.txtKVG_Reduktion.Name = "txtKVG_Reduktion";
            this.txtKVG_Reduktion.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKVG_Reduktion.ParentStyleUsing.UseBackColor = false;
            this.txtKVG_Reduktion.ParentStyleUsing.UseBorderColor = false;
            this.txtKVG_Reduktion.ParentStyleUsing.UseBorders = false;
            this.txtKVG_Reduktion.ParentStyleUsing.UseBorderWidth = false;
            this.txtKVG_Reduktion.ParentStyleUsing.UseFont = false;
            this.txtKVG_Reduktion.ParentStyleUsing.UseForeColor = false;
            this.txtKVG_Reduktion.Size = new System.Drawing.Size(98, 19);
            xrSummary3.FormatString = "{0:#,##0.00}";
            this.txtKVG_Reduktion.Summary = xrSummary3;
            this.txtKVG_Reduktion.Text = "KVG_Reduktion";
            this.txtKVG_Reduktion.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtKVG
            // 
            this.txtKVG.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KVG", "{0:n2}")});
            this.txtKVG.Font = new System.Drawing.Font("Arial", 10F);
            this.txtKVG.ForeColor = System.Drawing.Color.Black;
            this.txtKVG.Location = new System.Drawing.Point(248, 3);
            this.txtKVG.Multiline = true;
            this.txtKVG.Name = "txtKVG";
            this.txtKVG.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKVG.ParentStyleUsing.UseBackColor = false;
            this.txtKVG.ParentStyleUsing.UseBorderColor = false;
            this.txtKVG.ParentStyleUsing.UseBorders = false;
            this.txtKVG.ParentStyleUsing.UseBorderWidth = false;
            this.txtKVG.ParentStyleUsing.UseFont = false;
            this.txtKVG.ParentStyleUsing.UseForeColor = false;
            this.txtKVG.Size = new System.Drawing.Size(98, 19);
            xrSummary4.FormatString = "{0:#,##0.00}";
            this.txtKVG.Summary = xrSummary4;
            this.txtKVG.Text = "KVG";
            this.txtKVG.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtName
            // 
            this.txtName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.txtName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(3, 3);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtName.ParentStyleUsing.UseBackColor = false;
            this.txtName.ParentStyleUsing.UseBorderColor = false;
            this.txtName.ParentStyleUsing.UseBorders = false;
            this.txtName.ParentStyleUsing.UseBorderWidth = false;
            this.txtName.ParentStyleUsing.UseFont = false;
            this.txtName.ParentStyleUsing.UseForeColor = false;
            this.txtName.Size = new System.Drawing.Size(244, 19);
            this.txtName.Text = "Name";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel6.Location = new System.Drawing.Point(575, 27);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.Size = new System.Drawing.Size(42, 17);
            this.xrLabel6.Text = "VVG";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel2.Location = new System.Drawing.Point(582, 55);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(98, 14);
            this.xrLabel2.Text = "Reduktion";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel1.Location = new System.Drawing.Point(484, 55);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(98, 14);
            this.xrLabel1.Text = "Prämien";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.xrLabel8.Location = new System.Drawing.Point(0, 0);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.Size = new System.Drawing.Size(653, 20);
            this.xrLabel8.Text = "Prämien für Krankenversicherung (KVG) und Zusatzversicherung";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel7.Location = new System.Drawing.Point(0, 55);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.Size = new System.Drawing.Size(120, 14);
            this.xrLabel7.Text = "Name, Vorname";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel5.Location = new System.Drawing.Point(346, 55);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(98, 14);
            this.xrLabel5.Text = "Reduktion";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel4.Location = new System.Drawing.Point(248, 55);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(98, 14);
            this.xrLabel4.Text = "Prämien";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel3.Location = new System.Drawing.Point(342, 27);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(47, 17);
            this.xrLabel3.Text = "KVG";
            // 
            // Line6
            // 
            this.Line6.ForeColor = System.Drawing.Color.Black;
            this.Line6.Location = new System.Drawing.Point(0, 37);
            this.Line6.Name = "Line6";
            this.Line6.ParentStyleUsing.UseBackColor = false;
            this.Line6.ParentStyleUsing.UseBorderColor = false;
            this.Line6.ParentStyleUsing.UseBorders = false;
            this.Line6.ParentStyleUsing.UseBorderWidth = false;
            this.Line6.ParentStyleUsing.UseFont = false;
            this.Line6.ParentStyleUsing.UseForeColor = false;
            this.Line6.Size = new System.Drawing.Size(681, 2);
            // 
            // Line5
            // 
            this.Line5.ForeColor = System.Drawing.Color.Black;
            this.Line5.Location = new System.Drawing.Point(248, 70);
            this.Line5.Name = "Line5";
            this.Line5.ParentStyleUsing.UseBackColor = false;
            this.Line5.ParentStyleUsing.UseBorderColor = false;
            this.Line5.ParentStyleUsing.UseBorders = false;
            this.Line5.ParentStyleUsing.UseBorderWidth = false;
            this.Line5.ParentStyleUsing.UseFont = false;
            this.Line5.ParentStyleUsing.UseForeColor = false;
            this.Line5.Size = new System.Drawing.Size(433, 2);
            // 
            // Line4
            // 
            this.Line4.ForeColor = System.Drawing.Color.Black;
            this.Line4.Location = new System.Drawing.Point(248, 66);
            this.Line4.Name = "Line4";
            this.Line4.ParentStyleUsing.UseBackColor = false;
            this.Line4.ParentStyleUsing.UseBorderColor = false;
            this.Line4.ParentStyleUsing.UseBorders = false;
            this.Line4.ParentStyleUsing.UseBorderWidth = false;
            this.Line4.ParentStyleUsing.UseFont = false;
            this.Line4.ParentStyleUsing.UseForeColor = false;
            this.Line4.Size = new System.Drawing.Size(433, 2);
            // 
            // Label13
            // 
            this.Label13.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label13.ForeColor = System.Drawing.Color.Black;
            this.Label13.Location = new System.Drawing.Point(484, 43);
            this.Label13.Name = "Label13";
            this.Label13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label13.ParentStyleUsing.UseBackColor = false;
            this.Label13.ParentStyleUsing.UseBorderColor = false;
            this.Label13.ParentStyleUsing.UseBorders = false;
            this.Label13.ParentStyleUsing.UseBorderWidth = false;
            this.Label13.ParentStyleUsing.UseFont = false;
            this.Label13.ParentStyleUsing.UseForeColor = false;
            this.Label13.Size = new System.Drawing.Size(98, 19);
            this.Label13.Text = "VVG Total";
            // 
            // Line3
            // 
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.Location = new System.Drawing.Point(0, 3);
            this.Line3.Name = "Line3";
            this.Line3.ParentStyleUsing.UseBackColor = false;
            this.Line3.ParentStyleUsing.UseBorderColor = false;
            this.Line3.ParentStyleUsing.UseBorders = false;
            this.Line3.ParentStyleUsing.UseBorderWidth = false;
            this.Line3.ParentStyleUsing.UseFont = false;
            this.Line3.ParentStyleUsing.UseForeColor = false;
            this.Line3.Size = new System.Drawing.Size(681, 2);
            // 
            // totVVG_Reduziert
            // 
            this.totVVG_Reduziert.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VVG_Reduziert", "{0:n2}")});
            this.totVVG_Reduziert.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.totVVG_Reduziert.ForeColor = System.Drawing.Color.Black;
            this.totVVG_Reduziert.Location = new System.Drawing.Point(582, 43);
            this.totVVG_Reduziert.Multiline = true;
            this.totVVG_Reduziert.Name = "totVVG_Reduziert";
            this.totVVG_Reduziert.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totVVG_Reduziert.ParentStyleUsing.UseBackColor = false;
            this.totVVG_Reduziert.ParentStyleUsing.UseBorderColor = false;
            this.totVVG_Reduziert.ParentStyleUsing.UseBorders = false;
            this.totVVG_Reduziert.ParentStyleUsing.UseBorderWidth = false;
            this.totVVG_Reduziert.ParentStyleUsing.UseFont = false;
            this.totVVG_Reduziert.ParentStyleUsing.UseForeColor = false;
            this.totVVG_Reduziert.Size = new System.Drawing.Size(98, 19);
            xrSummary5.FormatString = "{0:#,##0.00}";
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.totVVG_Reduziert.Summary = xrSummary5;
            this.totVVG_Reduziert.Text = "totVVG_Reduziert";
            this.totVVG_Reduziert.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // totKVG_Reduziert
            // 
            this.totKVG_Reduziert.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KVG_Reduziert", "")});
            this.totKVG_Reduziert.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.totKVG_Reduziert.ForeColor = System.Drawing.Color.Black;
            this.totKVG_Reduziert.Location = new System.Drawing.Point(346, 43);
            this.totKVG_Reduziert.Multiline = true;
            this.totKVG_Reduziert.Name = "totKVG_Reduziert";
            this.totKVG_Reduziert.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totKVG_Reduziert.ParentStyleUsing.UseBackColor = false;
            this.totKVG_Reduziert.ParentStyleUsing.UseBorderColor = false;
            this.totKVG_Reduziert.ParentStyleUsing.UseBorders = false;
            this.totKVG_Reduziert.ParentStyleUsing.UseBorderWidth = false;
            this.totKVG_Reduziert.ParentStyleUsing.UseFont = false;
            this.totKVG_Reduziert.ParentStyleUsing.UseForeColor = false;
            this.totKVG_Reduziert.Size = new System.Drawing.Size(98, 19);
            xrSummary6.FormatString = "{0:#,##0.00}";
            xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.totKVG_Reduziert.Summary = xrSummary6;
            this.totKVG_Reduziert.Text = "totKVG_Reduziert";
            this.totKVG_Reduziert.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label9
            // 
            this.Label9.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(248, 43);
            this.Label9.Name = "Label9";
            this.Label9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label9.ParentStyleUsing.UseBackColor = false;
            this.Label9.ParentStyleUsing.UseBorderColor = false;
            this.Label9.ParentStyleUsing.UseBorders = false;
            this.Label9.ParentStyleUsing.UseBorderWidth = false;
            this.Label9.ParentStyleUsing.UseFont = false;
            this.Label9.ParentStyleUsing.UseForeColor = false;
            this.Label9.Size = new System.Drawing.Size(98, 19);
            this.Label9.Text = "KVG Total";
            // 
            // TextBox4
            // 
            this.TextBox4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VVG_Reduktion", "")});
            this.TextBox4.Font = new System.Drawing.Font("Arial", 10F);
            this.TextBox4.ForeColor = System.Drawing.Color.Black;
            this.TextBox4.Location = new System.Drawing.Point(582, 11);
            this.TextBox4.Multiline = true;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox4.ParentStyleUsing.UseBackColor = false;
            this.TextBox4.ParentStyleUsing.UseBorderColor = false;
            this.TextBox4.ParentStyleUsing.UseBorders = false;
            this.TextBox4.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox4.ParentStyleUsing.UseFont = false;
            this.TextBox4.ParentStyleUsing.UseForeColor = false;
            this.TextBox4.Size = new System.Drawing.Size(98, 19);
            xrSummary7.FormatString = "{0:#,##0.00}";
            xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.TextBox4.Summary = xrSummary7;
            this.TextBox4.Text = "TextBox4";
            this.TextBox4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox3
            // 
            this.TextBox3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VVG", "")});
            this.TextBox3.Font = new System.Drawing.Font("Arial", 10F);
            this.TextBox3.ForeColor = System.Drawing.Color.Black;
            this.TextBox3.Location = new System.Drawing.Point(484, 11);
            this.TextBox3.Multiline = true;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox3.ParentStyleUsing.UseBackColor = false;
            this.TextBox3.ParentStyleUsing.UseBorderColor = false;
            this.TextBox3.ParentStyleUsing.UseBorders = false;
            this.TextBox3.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox3.ParentStyleUsing.UseFont = false;
            this.TextBox3.ParentStyleUsing.UseForeColor = false;
            this.TextBox3.Size = new System.Drawing.Size(98, 19);
            xrSummary8.FormatString = "{0:#,##0.00}";
            xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.TextBox3.Summary = xrSummary8;
            this.TextBox3.Text = "TextBox3";
            this.TextBox3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox2
            // 
            this.TextBox2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KVG_Reduktion", "")});
            this.TextBox2.Font = new System.Drawing.Font("Arial", 10F);
            this.TextBox2.ForeColor = System.Drawing.Color.Black;
            this.TextBox2.Location = new System.Drawing.Point(346, 11);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox2.ParentStyleUsing.UseBackColor = false;
            this.TextBox2.ParentStyleUsing.UseBorderColor = false;
            this.TextBox2.ParentStyleUsing.UseBorders = false;
            this.TextBox2.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox2.ParentStyleUsing.UseFont = false;
            this.TextBox2.ParentStyleUsing.UseForeColor = false;
            this.TextBox2.Size = new System.Drawing.Size(98, 19);
            xrSummary9.FormatString = "{0:#,##0.00}";
            xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.TextBox2.Summary = xrSummary9;
            this.TextBox2.Text = "TextBox2";
            this.TextBox2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox1
            // 
            this.TextBox1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KVG", "")});
            this.TextBox1.Font = new System.Drawing.Font("Arial", 10F);
            this.TextBox1.ForeColor = System.Drawing.Color.Black;
            this.TextBox1.Location = new System.Drawing.Point(248, 11);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox1.ParentStyleUsing.UseBackColor = false;
            this.TextBox1.ParentStyleUsing.UseBorderColor = false;
            this.TextBox1.ParentStyleUsing.UseBorders = false;
            this.TextBox1.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox1.ParentStyleUsing.UseFont = false;
            this.TextBox1.ParentStyleUsing.UseForeColor = false;
            this.TextBox1.Size = new System.Drawing.Size(98, 19);
            xrSummary10.FormatString = "{0:#,##0.00}";
            xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.TextBox1.Summary = xrSummary10;
            this.TextBox1.Text = "TextBox1";
            this.TextBox1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
                        this.PageHeader,
                        this.GroupHeader1,
                        this.GroupFooter1,
                        this.PageFooter,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Name = "Report";
            this.PageHeight = 1300;
            this.PageWidth = 1050;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' ,  null ,  N'DECLARE @BgFinanzplanID INT,
        @FPVon DATETIME,
        @FPBis DATETIME,
        @Date  DATETIME

SET @BgFinanzplanID = {BgFinanzplanID} 

SELECT 
  @FPVon = ISNULL(DatumVon, GeplantVon),
  @FPBis = ISNULL(DatumBis, GeplantBis)
FROM dbo.BgFinanzplan WITH (READUNCOMMITTED)
WHERE BgFinanzplanID = @BgFinanzplanID

SET @Date = GETDATE()

IF @Date < @FPVon
BEGIN
  SET @Date = @FPVon
END
ELSE IF @Date > @FPBis
BEGIN
  SET @Date = @FPBis
END

SELECT
  [Name]           = PRS.Name + '', '' + PRS.Vorname,

  [KVG]            = POS.Betrag,
  [KVG_Reduktion]  = POS.Reduktion,
  [KVG_Reduziert]  = POS.Betrag - POS.Reduktion,

  [VVG]            = VVG.Betrag,
  [VVG_Reduktion]  = VVG.Reduktion,
  [VVG_Reduziert]  = VVG.Betrag - VVG.Reduktion,

  [Bemerkung]      = KVG.Bemerkung
, ''---POS---'',POS.* 
, ''---KVG---'',KVG.* 
, ''---VVG---'',VVG.* 
FROM BgFinanzplan_BaPerson   FPP
  INNER JOIN BgBudget        BDG     ON BDG.BgFinanzplanID = FPP.BgFinanzplanID 
                                    AND BDG.MasterBudget = 1
  INNER JOIN BaPerson        PRS     ON PRS.BaPersonID = FPP.BaPersonID
  INNER JOIN BgPosition      POS     ON POS.BgBudgetID = BDG.BgBudgetID
                                    AND POS.BaPersonID = FPP.BaPersonID
                                    AND @Date BETWEEN ISNULL(POS.DatumVon, @FPVon) AND ISNULL(POS.DatumBis, @FPBis)
  INNER JOIN BgPositionsart  POA     ON POA.BgPositionsartID = POS.BgPositionsartID
                                    AND (POA.BgPositionsartCode = 32020 
                                      OR POA.BgPositionsartCode BETWEEN 32121 AND 32130)
                                      
  LEFT JOIN (SELECT BPOI.*, POAI.BgPositionsartCode
             FROM BgPosition BPOI
               INNER JOIN BgPositionsart POAI ON POAI.BgPositionsartID = BPOI.BgPositionsartID
             WHERE POAI.BgPositionsartCode IN (32023, 32024)) 
                             KVG     ON KVG.BgBudgetID = POS.BgBudgetID
                                    AND KVG.BgPositionID_Parent = POS.BgPositionID
                                        
  LEFT JOIN (SELECT BPOI.*, POAI.BgPositionsartCode
             FROM BgPosition BPOI
               INNER JOIN BgPositionsart POAI ON POAI.BgPositionsartID = BPOI.BgPositionsartID
             WHERE POAI.BgPositionsartCode IN (32021, 32022)) 
                             VVG     ON VVG.BgBudgetID = POS.BgBudgetID
                                    AND VVG.BgPositionID_Parent = POS.BgPositionID
                                    
WHERE FPP.BgFinanzplanID = @BgFinanzplanID
  AND FPP.IstUnterstuetzt = 1' ,  null ,  N'ShDetaillierterFinanzplanStandard' ,  null ,  1 );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'ShDetaillierterFinanzplanStandard_Personen' ,  N'Personen' , 1,  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>en-US</Localization>
///   <References>
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraPrinting.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Drawing\2.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System\2.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Configuration\2.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Xml\2.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Data.SqlXml\2.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Security\2.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.Utils.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Utils.v6.2.dll" />
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
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraEditors.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.Data.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Data.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraBars.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraNavBar.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraCharts.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraRichTextEdit.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="C:\KiSS4_Migration\KiSS4.DB.dll" />
///     <Reference Path="C:\KiSS4_Migration\SharpLibrary.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtFullName;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtHeimatort;
        private DevExpress.XtraReports.UI.XRLabel txtAHVNummer;
        private DevExpress.XtraReports.UI.XRLabel txtGeburtsdatum;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRPanel hider;
        private DevExpress.XtraReports.UI.XRLabel hiderGroupFooter;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel txtTitel;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel TextBox4;
        private DevExpress.XtraReports.UI.XRLabel TextBox3;
        private DevExpress.XtraReports.UI.XRLabel TextBox2;
        private DevExpress.XtraReports.UI.XRLabel TextBox1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader2;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3a;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3b;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3c;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3d;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3e;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter3e;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel Label21;
        private DevExpress.XtraReports.UI.XRLabel PrsNummerHeimat3;
        private DevExpress.XtraReports.UI.XRLabel PrsNummerKanton3;
        private DevExpress.XtraReports.UI.XRLabel Label20;
        private DevExpress.XtraReports.UI.XRLabel Label10;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter3d;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel NRM_VerrechnungVon1;
        private DevExpress.XtraReports.UI.XRLabel txtAuslandChMeldungAm;
        private DevExpress.XtraReports.UI.XRLabel Label24;
        private DevExpress.XtraReports.UI.XRLabel Label23;
        private DevExpress.XtraReports.UI.XRLabel Label19;
        private DevExpress.XtraReports.UI.XRLabel PrsNummerHeimat2;
        private DevExpress.XtraReports.UI.XRLabel PrsNummerKanton2;
        private DevExpress.XtraReports.UI.XRLabel Label18;
        private DevExpress.XtraReports.UI.XRLabel Label9;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter3c;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel NRM_VerrechnungVon2;
        private DevExpress.XtraReports.UI.XRLabel Label22;
        private DevExpress.XtraReports.UI.XRLabel Label17;
        private DevExpress.XtraReports.UI.XRLabel PrsNummerHeimat1;
        private DevExpress.XtraReports.UI.XRLabel PrsNummerKanton1;
        private DevExpress.XtraReports.UI.XRLabel Label16;
        private DevExpress.XtraReports.UI.XRLabel Label8;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter3b;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel txtNRM_VerrechnungBis;
        private DevExpress.XtraReports.UI.XRLabel txtNRM_VerrechnungVon;
        private DevExpress.XtraReports.UI.XRLabel txtVerrechnungsanteil;
        private DevExpress.XtraReports.UI.XRLabel Label15;
        private DevExpress.XtraReports.UI.XRLabel Label14;
        private DevExpress.XtraReports.UI.XRLabel txtPrsNummerHeimat;
        private DevExpress.XtraReports.UI.XRLabel txtPrsNummerKanton;
        private DevExpress.XtraReports.UI.XRLabel Label13;
        private DevExpress.XtraReports.UI.XRLabel Label12;
        private DevExpress.XtraReports.UI.XRLabel Label11;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter3a;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel TextBox10;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter2;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAACAAAAAAAAAFBBRFBBRFATtE6k5" +
                        "d3rSE8AAAAAAAAASgEAAEpoAGkAZABlAHIARwByAG8AdQBwAEYAbwBvAHQAZQByAC4AUwBjAHIAaQBwA" +
                        "HQAcwAuAE8AbgBBAGYAdABlAHIAUAByAGkAbgB0AAAAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAb" +
                        "ABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAfAwAAAZwGcHJpdmF0ZSB2b2lkIE9uQWZ0ZXJQcmludChvY" +
                        "mplY3Qgc2VuZGVyLCBTeXN0ZW0uRXZlbnRBcmdzIGUpIHsNCiAgdHJ5IHsNCiAgICAvL2ludCB0eXBMY" +
                        "XlvdXQgPSBpbnQuUGFyc2UoaGlkZXJHcm91cEZvb3Rlci5UZXh0KTsNCiAgICBHcm91cEZvb3RlcjNhL" +
                        "lZpc2libGUgPSBmYWxzZTsNCiAgICBHcm91cEZvb3RlcjNiLlZpc2libGUgPSBmYWxzZTsNCiAgICBHc" +
                        "m91cEZvb3RlcjNjLlZpc2libGUgPSBmYWxzZTsNCiAgICBHcm91cEZvb3RlcjNkLlZpc2libGUgPSBmY" +
                        "WxzZTsNCiAgICBHcm91cEZvb3RlcjNlLlZpc2libGUgPSBmYWxzZTsNCiAgICAvKnN3aXRjaCAodHlwT" +
                        "GF5b3V0KSB7DQogICAgICBjYXNlIDA6IEdyb3VwRm9vdGVyM2EuVmlzaWJsZSA9IHRydWU7IGJyZWFrO" +
                        "w0KICAgICAgY2FzZSAxOiBHcm91cEZvb3RlcjNiLlZpc2libGUgPSB0cnVlOyBicmVhazsNCiAgICAgI" +
                        "GNhc2UgMjogR3JvdXBGb290ZXIzYy5WaXNpYmxlID0gdHJ1ZTsgYnJlYWs7DQogICAgICBjYXNlIDM6I" +
                        "Edyb3VwRm9vdGVyM2QuVmlzaWJsZSA9IHRydWU7IGJyZWFrOw0KICAgICAgY2FzZSA0OiBHcm91cEZvb" +
                        "3RlcjNlLlZpc2libGUgPSB0cnVlOyBicmVhazsNCiAgICB9Ki8NCiAgfQ0KICBjYXRjaCAoU3lzdGVtL" +
                        "kV4Y2VwdGlvbiBleCkNCiAgew0KICAgIFN5c3RlbS5XaW5kb3dzLkZvcm1zLk1lc3NhZ2VCb3guU2hvd" +
                        "ygiSW0gUmVwb3J0IGlzdCBlaW4gU2tyaXB0LUZlaGxlciBhdWZnZXRyZXRlbi4gKGhpZGVyLk9uQWZ0Z" +
                        "XJQcmludCkuIFN5c3RlbSBNZWxkdW5nOiAiKyBleC5NZXNzYWdlKTsNCiAgfQ0KfQH8DVNFTEVDVCBbV" +
                        "Gl0ZWxdICAgICAgICAgICAgICA9ICdVbnRlcnN0w7x0enRlIFBlcnNvbmVuLCBpaHJlIEtvc3RlbnN0Z" +
                        "WxsZW4gdW5kIEJhbmt2ZXJiaW5kdW5nZW4nLA0KICAgICAgIFtOYW1lXSAgICAgICAgICAgICAgID0gU" +
                        "FJTLk5hbWUsDQogICAgICAgW1Zvcm5hbWVdICAgICAgICAgICAgPSBQUlMuVm9ybmFtZSwNCiAgICAgI" +
                        "CBbRnVsbE5hbWVdICAgICAgICAgICA9IFBSUy5OYW1lICsgSXNOdWxsKCcsICcgKyBQUlMuVm9ybmFtZ" +
                        "SwnJykgKyAgQ0FTRSBMRU4oSXNOdWxsKFBSUy5Wb3JuYW1lMiwgJycpKSBXSEVOIDAgVEhFTiAnJyBFT" +
                        "FNFICcgJyArIFBSUy5Wb3JuYW1lMiBFTkQsDQogICAgICAgW0dlYnVydHNkYXR1bV0gICAgICAgPSBQU" +
                        "lMuR2VidXJ0c2RhdHVtLA0KICAgICAgIFtBSFZOdW1tZXJdICAgICAgICAgID0gUFJTLkFIVk51bW1lc" +
                        "iwNCiAgICAgICBbSGVpbWF0b3J0XSAgICAgICAgICA9IFBSUy5IZWltYXRvcnQsDQogICAgICAgW0lzd" +
                        "FVudGVyc3R1ZXR6dF0gICAgPSBTUFAuSXN0VW50ZXJzdHVldHp0DQpGUk9NIEJnRmluYW56cGxhbiAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgU0ZQDQogICAgIElOTkVSIEpPSU4gQmdGaW5hbnpwbGFuX" +
                        "0JhUGVyc29uICAgICAgICAgU1BQIE9OIFNQUC5CZ0ZpbmFuenBsYW5JRCAgICAgICAgICAgPSBTRlAuQ" +
                        "mdGaW5hbnpwbGFuSUQNCiAgICAgSU5ORVIgSk9JTiB2d1BlcnNvbiAgICAgICAgICAgICAgICAgICAgI" +
                        "CBQUlMgT04gUFJTLkJhUGVyc29uSUQgICAgICAgICAgICAgID0gU1BQLkJhUGVyc29uSUQNCldIRVJFI" +
                        "FNGUC5CZ0ZpbmFuenBsYW5JRCA9IG51bGwgQU5EIChTUFAuSXN0VW50ZXJzdHVldHp0ID0gMSkNCg0KV" +
                        "U5JT04gQUxMICAgICAgIC0tIG5vdyBhbGwgdGhlIHBlcnNvbnMgd2hvIGFyZSBub3QgdW50ZXJzdHVld" +
                        "Hp0DQoNClNFTEVDVCBbVGl0ZWxdICAgICAgICAgICAgICA9ICdOaWNodCB1bnRlcnN0w7x0enRlIFBlc" +
                        "nNvbmVuJywNCiAgICAgICBbTmFtZV0gICAgICAgICAgICAgICA9IFBSUy5OYW1lLA0KICAgICAgIFtWb" +
                        "3JuYW1lXSAgICAgICAgICAgID0gUFJTLlZvcm5hbWUsDQogICAgICAgW0Z1bGxOYW1lXSAgICAgICAgI" +
                        "CAgPSBQUlMuTmFtZSArIElzTnVsbCgnLCAnICsgUFJTLlZvcm5hbWUsJycpICsgIENBU0UgTEVOKElzT" +
                        "nVsbChQUlMuVm9ybmFtZTIsICcnKSkgV0hFTiAwIFRIRU4gJycgRUxTRSAnICcgKyBQUlMuVm9ybmFtZ" +
                        "TIgRU5ELA0KICAgICAgIFtHZWJ1cnRzZGF0dW1dICAgICAgID0gUFJTLkdlYnVydHNkYXR1bSwNCiAgI" +
                        "CAgICBbQUhWTnVtbWVyXSAgICAgICAgICA9IFBSUy5BaHZOdW1tZXIsDQogICAgICAgW0hlaW1hdG9yd" +
                        "F0gICAgICAgICAgPSBQUlMuSGVpbWF0b3J0LA0KICAgICAgIFtJc3RVbnRlcnN0dWV0enRdICAgID0gU" +
                        "1BQLklzdFVudGVyc3R1ZXR6dA0KRlJPTSBCZ0ZpbmFuenBsYW4gICAgICAgICAgICAgICAgICAgICAgU" +
                        "0ZQDQogICAgIElOTkVSIEpPSU4gQmdGaW5hbnpwbGFuX0JhUGVyc29uICBTUFAgT04gU1BQLkJnRmluY" +
                        "W56cGxhbklEICAgICAgICAgICA9IFNGUC5CZ0ZpbmFuenBsYW5JRA0KICAgICBJTk5FUiBKT0lOIHZ3U" +
                        "GVyc29uICAgICAgICAgICAgICAgUFJTIE9OIFBSUy5CYVBlcnNvbklEICAgICAgICAgICAgICA9IFNQU" +
                        "C5CYVBlcnNvbklEDQpXSEVSRSBTRlAuQmdGaW5hbnpwbGFuSUQgPSBudWxsIEFORCAoU1BQLklzdFVud" +
                        "GVyc3R1ZXR6dD0wKQ0KDQpPUkRFUiBCWSBJc3RVbnRlcnN0dWV0enQgZGVzYyAtLSBmaXJzdCB1bnRlc" +
                        "nN0dWV0enQgb25lcywgcmVzdDogREVTQyBwdXRzIE5VTEwgbGFzdA==";
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
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader3a = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader3b = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader3c = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader3d = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader3e = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter3e = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter3d = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter3c = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter3b = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter3a = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.txtFullName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtHeimatort = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAHVNummer = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGeburtsdatum = new DevExpress.XtraReports.UI.XRLabel();
            this.hider = new DevExpress.XtraReports.UI.XRPanel();
            this.hiderGroupFooter = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTitel = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.TextBox4 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox3 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox2 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label21 = new DevExpress.XtraReports.UI.XRLabel();
            this.PrsNummerHeimat3 = new DevExpress.XtraReports.UI.XRLabel();
            this.PrsNummerKanton3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label20 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.NRM_VerrechnungVon1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAuslandChMeldungAm = new DevExpress.XtraReports.UI.XRLabel();
            this.Label24 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label23 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label19 = new DevExpress.XtraReports.UI.XRLabel();
            this.PrsNummerHeimat2 = new DevExpress.XtraReports.UI.XRLabel();
            this.PrsNummerKanton2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label18 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.NRM_VerrechnungVon2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label22 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label17 = new DevExpress.XtraReports.UI.XRLabel();
            this.PrsNummerHeimat1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PrsNummerKanton1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label16 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNRM_VerrechnungBis = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNRM_VerrechnungVon = new DevExpress.XtraReports.UI.XRLabel();
            this.txtVerrechnungsanteil = new DevExpress.XtraReports.UI.XRLabel();
            this.Label15 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label14 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtPrsNummerHeimat = new DevExpress.XtraReports.UI.XRLabel();
            this.txtPrsNummerKanton = new DevExpress.XtraReports.UI.XRLabel();
            this.Label13 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label12 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label11 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox10 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtFullName,
                        this.txtHeimatort,
                        this.txtAHVNummer,
                        this.txtGeburtsdatum});
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
                        this.hider});
            this.ReportHeader.Height = 27;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.ParentStyleUsing.UseBackColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorderColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorders = false;
            this.ReportHeader.ParentStyleUsing.UseBorderWidth = false;
            this.ReportHeader.ParentStyleUsing.UseFont = false;
            this.ReportHeader.ParentStyleUsing.UseForeColor = false;
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
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtTitel,
                        this.Line1,
                        this.TextBox4,
                        this.TextBox3,
                        this.TextBox2,
                        this.TextBox1});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("IstUnterstuetzt", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 70;
            this.GroupHeader1.Level = 6;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("GroupMoney", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader2.Height = 0;
            this.GroupHeader2.Level = 5;
            this.GroupHeader2.Name = "GroupHeader2";
            this.GroupHeader2.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader2.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader2.ParentStyleUsing.UseBorders = false;
            this.GroupHeader2.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader2.ParentStyleUsing.UseFont = false;
            this.GroupHeader2.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader3a
            // 
            this.GroupHeader3a.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("GroupVerrechnung", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader3a.Height = 0;
            this.GroupHeader3a.Level = 4;
            this.GroupHeader3a.Name = "GroupHeader3a";
            this.GroupHeader3a.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader3a.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader3a.ParentStyleUsing.UseBorders = false;
            this.GroupHeader3a.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader3a.ParentStyleUsing.UseFont = false;
            this.GroupHeader3a.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader3b
            // 
            this.GroupHeader3b.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("GroupVerrechnung", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader3b.Height = 0;
            this.GroupHeader3b.Level = 3;
            this.GroupHeader3b.Name = "GroupHeader3b";
            this.GroupHeader3b.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader3b.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader3b.ParentStyleUsing.UseBorders = false;
            this.GroupHeader3b.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader3b.ParentStyleUsing.UseFont = false;
            this.GroupHeader3b.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader3c
            // 
            this.GroupHeader3c.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("GroupVerrechnung", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader3c.Height = 0;
            this.GroupHeader3c.Level = 2;
            this.GroupHeader3c.Name = "GroupHeader3c";
            this.GroupHeader3c.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader3c.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader3c.ParentStyleUsing.UseBorders = false;
            this.GroupHeader3c.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader3c.ParentStyleUsing.UseFont = false;
            this.GroupHeader3c.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader3d
            // 
            this.GroupHeader3d.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("GroupVerrechnung", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader3d.Height = 0;
            this.GroupHeader3d.Level = 1;
            this.GroupHeader3d.Name = "GroupHeader3d";
            this.GroupHeader3d.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader3d.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader3d.ParentStyleUsing.UseBorders = false;
            this.GroupHeader3d.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader3d.ParentStyleUsing.UseFont = false;
            this.GroupHeader3d.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader3e
            // 
            this.GroupHeader3e.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("GroupVerrechnung", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader3e.Height = 0;
            this.GroupHeader3e.Name = "GroupHeader3e";
            this.GroupHeader3e.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader3e.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader3e.ParentStyleUsing.UseBorders = false;
            this.GroupHeader3e.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader3e.ParentStyleUsing.UseFont = false;
            this.GroupHeader3e.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter3e
            // 
            this.GroupFooter3e.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel3,
                        this.xrLabel2,
                        this.Label21,
                        this.PrsNummerHeimat3,
                        this.PrsNummerKanton3,
                        this.Label20,
                        this.Label10});
            this.GroupFooter3e.Height = 90;
            this.GroupFooter3e.Name = "GroupFooter3e";
            this.GroupFooter3e.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter3e.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter3e.ParentStyleUsing.UseBorders = false;
            this.GroupFooter3e.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter3e.ParentStyleUsing.UseFont = false;
            this.GroupFooter3e.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter3d
            // 
            this.GroupFooter3d.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel5,
                        this.xrLabel4,
                        this.NRM_VerrechnungVon1,
                        this.txtAuslandChMeldungAm,
                        this.Label24,
                        this.Label23,
                        this.Label19,
                        this.PrsNummerHeimat2,
                        this.PrsNummerKanton2,
                        this.Label18,
                        this.Label9});
            this.GroupFooter3d.Height = 91;
            this.GroupFooter3d.Level = 1;
            this.GroupFooter3d.Name = "GroupFooter3d";
            this.GroupFooter3d.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter3d.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter3d.ParentStyleUsing.UseBorders = false;
            this.GroupFooter3d.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter3d.ParentStyleUsing.UseFont = false;
            this.GroupFooter3d.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter3c
            // 
            this.GroupFooter3c.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel7,
                        this.xrLabel6,
                        this.NRM_VerrechnungVon2,
                        this.Label22,
                        this.Label17,
                        this.PrsNummerHeimat1,
                        this.PrsNummerKanton1,
                        this.Label16,
                        this.Label8});
            this.GroupFooter3c.Height = 70;
            this.GroupFooter3c.Level = 2;
            this.GroupFooter3c.Name = "GroupFooter3c";
            this.GroupFooter3c.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter3c.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter3c.ParentStyleUsing.UseBorders = false;
            this.GroupFooter3c.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter3c.ParentStyleUsing.UseFont = false;
            this.GroupFooter3c.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter3b
            // 
            this.GroupFooter3b.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel9,
                        this.xrLabel8,
                        this.txtNRM_VerrechnungBis,
                        this.txtNRM_VerrechnungVon,
                        this.txtVerrechnungsanteil,
                        this.Label15,
                        this.Label14,
                        this.txtPrsNummerHeimat,
                        this.txtPrsNummerKanton,
                        this.Label13,
                        this.Label12,
                        this.Label11,
                        this.Label7});
            this.GroupFooter3b.Height = 92;
            this.GroupFooter3b.Level = 3;
            this.GroupFooter3b.Name = "GroupFooter3b";
            this.GroupFooter3b.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter3b.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter3b.ParentStyleUsing.UseBorders = false;
            this.GroupFooter3b.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter3b.ParentStyleUsing.UseFont = false;
            this.GroupFooter3b.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter3a
            // 
            this.GroupFooter3a.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel1,
                        this.TextBox10,
                        this.Label6});
            this.GroupFooter3a.Height = 36;
            this.GroupFooter3a.Level = 4;
            this.GroupFooter3a.Name = "GroupFooter3a";
            this.GroupFooter3a.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter3a.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter3a.ParentStyleUsing.UseBorders = false;
            this.GroupFooter3a.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter3a.ParentStyleUsing.UseFont = false;
            this.GroupFooter3a.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Height = 0;
            this.GroupFooter2.Level = 5;
            this.GroupFooter2.Name = "GroupFooter2";
            this.GroupFooter2.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter2.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter2.ParentStyleUsing.UseBorders = false;
            this.GroupFooter2.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter2.ParentStyleUsing.UseFont = false;
            this.GroupFooter2.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Height = 0;
            this.GroupFooter1.Level = 6;
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
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Height = 0;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // txtFullName
            // 
            this.txtFullName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "FullName", "")});
            this.txtFullName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtFullName.ForeColor = System.Drawing.Color.Black;
            this.txtFullName.Location = new System.Drawing.Point(0, 0);
            this.txtFullName.Multiline = true;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtFullName.ParentStyleUsing.UseBackColor = false;
            this.txtFullName.ParentStyleUsing.UseBorderColor = false;
            this.txtFullName.ParentStyleUsing.UseBorders = false;
            this.txtFullName.ParentStyleUsing.UseBorderWidth = false;
            this.txtFullName.ParentStyleUsing.UseFont = false;
            this.txtFullName.ParentStyleUsing.UseForeColor = false;
            this.txtFullName.Size = new System.Drawing.Size(326, 19);
            this.txtFullName.Text = "FullName";
            // 
            // txtHeimatort
            // 
            this.txtHeimatort.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Heimatort", "")});
            this.txtHeimatort.Font = new System.Drawing.Font("Arial", 10F);
            this.txtHeimatort.ForeColor = System.Drawing.Color.Black;
            this.txtHeimatort.Location = new System.Drawing.Point(539, 0);
            this.txtHeimatort.Multiline = true;
            this.txtHeimatort.Name = "txtHeimatort";
            this.txtHeimatort.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtHeimatort.ParentStyleUsing.UseBackColor = false;
            this.txtHeimatort.ParentStyleUsing.UseBorderColor = false;
            this.txtHeimatort.ParentStyleUsing.UseBorders = false;
            this.txtHeimatort.ParentStyleUsing.UseBorderWidth = false;
            this.txtHeimatort.ParentStyleUsing.UseFont = false;
            this.txtHeimatort.ParentStyleUsing.UseForeColor = false;
            this.txtHeimatort.Size = new System.Drawing.Size(160, 19);
            this.txtHeimatort.Text = "Heimatort";
            // 
            // txtAHVNummer
            // 
            this.txtAHVNummer.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AHVNummer", "")});
            this.txtAHVNummer.Font = new System.Drawing.Font("Arial", 10F);
            this.txtAHVNummer.ForeColor = System.Drawing.Color.Black;
            this.txtAHVNummer.Location = new System.Drawing.Point(425, 0);
            this.txtAHVNummer.Multiline = true;
            this.txtAHVNummer.Name = "txtAHVNummer";
            this.txtAHVNummer.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtAHVNummer.ParentStyleUsing.UseBackColor = false;
            this.txtAHVNummer.ParentStyleUsing.UseBorderColor = false;
            this.txtAHVNummer.ParentStyleUsing.UseBorders = false;
            this.txtAHVNummer.ParentStyleUsing.UseBorderWidth = false;
            this.txtAHVNummer.ParentStyleUsing.UseFont = false;
            this.txtAHVNummer.ParentStyleUsing.UseForeColor = false;
            this.txtAHVNummer.Size = new System.Drawing.Size(114, 19);
            this.txtAHVNummer.Text = "AHVNummer";
            // 
            // txtGeburtsdatum
            // 
            this.txtGeburtsdatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Geburtsdatum", "{0:dd.MM.yyyy}")});
            this.txtGeburtsdatum.Font = new System.Drawing.Font("Arial", 10F);
            this.txtGeburtsdatum.ForeColor = System.Drawing.Color.Black;
            this.txtGeburtsdatum.Location = new System.Drawing.Point(326, 0);
            this.txtGeburtsdatum.Multiline = true;
            this.txtGeburtsdatum.Name = "txtGeburtsdatum";
            this.txtGeburtsdatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGeburtsdatum.ParentStyleUsing.UseBackColor = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorderColor = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorders = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseFont = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseForeColor = false;
            this.txtGeburtsdatum.Size = new System.Drawing.Size(98, 19);
            xrSummary1.FormatString = "{0:dd.MM.yyyy}";
            this.txtGeburtsdatum.Summary = xrSummary1;
            this.txtGeburtsdatum.Text = "Geburtsdatum";
            // 
            // hider
            // 
            this.hider.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.hiderGroupFooter});
            this.hider.Location = new System.Drawing.Point(160, 0);
            this.hider.Name = "hider";
            this.hider.Size = new System.Drawing.Size(340, 27);
            this.hider.Visible = false;
            // 
            // hiderGroupFooter
            // 
            this.hiderGroupFooter.Location = new System.Drawing.Point(13, 0);
            this.hiderGroupFooter.Name = "hiderGroupFooter";
            this.hiderGroupFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hiderGroupFooter.Scripts.OnAfterPrint = resources.GetString("hiderGroupFooter.Scripts.OnAfterPrint");
            this.hiderGroupFooter.Size = new System.Drawing.Size(100, 20);
            // 
            // txtTitel
            // 
            this.txtTitel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Titel", "")});
            this.txtTitel.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.txtTitel.ForeColor = System.Drawing.Color.Black;
            this.txtTitel.Location = new System.Drawing.Point(0, 1);
            this.txtTitel.Multiline = true;
            this.txtTitel.Name = "txtTitel";
            this.txtTitel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtTitel.ParentStyleUsing.UseBackColor = false;
            this.txtTitel.ParentStyleUsing.UseBorderColor = false;
            this.txtTitel.ParentStyleUsing.UseBorders = false;
            this.txtTitel.ParentStyleUsing.UseBorderWidth = false;
            this.txtTitel.ParentStyleUsing.UseFont = false;
            this.txtTitel.ParentStyleUsing.UseForeColor = false;
            this.txtTitel.Size = new System.Drawing.Size(700, 19);
            this.txtTitel.Text = "Titel";
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.Location = new System.Drawing.Point(0, 47);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(700, 2);
            // 
            // TextBox4
            // 
            this.TextBox4.Font = new System.Drawing.Font("Arial", 10F);
            this.TextBox4.ForeColor = System.Drawing.Color.Black;
            this.TextBox4.Location = new System.Drawing.Point(539, 27);
            this.TextBox4.Multiline = true;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox4.ParentStyleUsing.UseBackColor = false;
            this.TextBox4.ParentStyleUsing.UseBorderColor = false;
            this.TextBox4.ParentStyleUsing.UseBorders = false;
            this.TextBox4.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox4.ParentStyleUsing.UseFont = false;
            this.TextBox4.ParentStyleUsing.UseForeColor = false;
            this.TextBox4.Size = new System.Drawing.Size(160, 19);
            this.TextBox4.Text = "Heimatort";
            // 
            // TextBox3
            // 
            this.TextBox3.Font = new System.Drawing.Font("Arial", 10F);
            this.TextBox3.ForeColor = System.Drawing.Color.Black;
            this.TextBox3.Location = new System.Drawing.Point(425, 27);
            this.TextBox3.Multiline = true;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox3.ParentStyleUsing.UseBackColor = false;
            this.TextBox3.ParentStyleUsing.UseBorderColor = false;
            this.TextBox3.ParentStyleUsing.UseBorders = false;
            this.TextBox3.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox3.ParentStyleUsing.UseFont = false;
            this.TextBox3.ParentStyleUsing.UseForeColor = false;
            this.TextBox3.Size = new System.Drawing.Size(114, 19);
            this.TextBox3.Text = "AHV-Nummer";
            // 
            // TextBox2
            // 
            this.TextBox2.Font = new System.Drawing.Font("Arial", 10F);
            this.TextBox2.ForeColor = System.Drawing.Color.Black;
            this.TextBox2.Location = new System.Drawing.Point(326, 27);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox2.ParentStyleUsing.UseBackColor = false;
            this.TextBox2.ParentStyleUsing.UseBorderColor = false;
            this.TextBox2.ParentStyleUsing.UseBorders = false;
            this.TextBox2.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox2.ParentStyleUsing.UseFont = false;
            this.TextBox2.ParentStyleUsing.UseForeColor = false;
            this.TextBox2.Size = new System.Drawing.Size(98, 19);
            this.TextBox2.Text = "Geburtsdatum";
            // 
            // TextBox1
            // 
            this.TextBox1.Font = new System.Drawing.Font("Arial", 10F);
            this.TextBox1.ForeColor = System.Drawing.Color.Black;
            this.TextBox1.Location = new System.Drawing.Point(0, 27);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox1.ParentStyleUsing.UseBackColor = false;
            this.TextBox1.ParentStyleUsing.UseBorderColor = false;
            this.TextBox1.ParentStyleUsing.UseBorders = false;
            this.TextBox1.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox1.ParentStyleUsing.UseFont = false;
            this.TextBox1.ParentStyleUsing.UseForeColor = false;
            this.TextBox1.Size = new System.Drawing.Size(326, 19);
            this.TextBox1.Text = "Name";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(127, 0);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(126, 19);
            this.xrLabel3.Text = "NRM_KontoNummer_und_Name";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel2.Location = new System.Drawing.Point(253, 0);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(333, 20);
            this.xrLabel2.Text = "xrLabel1";
            // 
            // Label21
            // 
            this.Label21.Font = new System.Drawing.Font("Arial", 10F);
            this.Label21.ForeColor = System.Drawing.Color.Black;
            this.Label21.Location = new System.Drawing.Point(12, 39);
            this.Label21.Name = "Label21";
            this.Label21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label21.ParentStyleUsing.UseBackColor = false;
            this.Label21.ParentStyleUsing.UseBorderColor = false;
            this.Label21.ParentStyleUsing.UseBorders = false;
            this.Label21.ParentStyleUsing.UseBorderWidth = false;
            this.Label21.ParentStyleUsing.UseFont = false;
            this.Label21.ParentStyleUsing.UseForeColor = false;
            this.Label21.Size = new System.Drawing.Size(236, 19);
            this.Label21.Text = "Personennummer d. Heimatlandes";
            // 
            // PrsNummerHeimat3
            // 
            this.PrsNummerHeimat3.Font = new System.Drawing.Font("Arial", 10F);
            this.PrsNummerHeimat3.ForeColor = System.Drawing.Color.Black;
            this.PrsNummerHeimat3.Location = new System.Drawing.Point(248, 39);
            this.PrsNummerHeimat3.Multiline = true;
            this.PrsNummerHeimat3.Name = "PrsNummerHeimat3";
            this.PrsNummerHeimat3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PrsNummerHeimat3.ParentStyleUsing.UseBackColor = false;
            this.PrsNummerHeimat3.ParentStyleUsing.UseBorderColor = false;
            this.PrsNummerHeimat3.ParentStyleUsing.UseBorders = false;
            this.PrsNummerHeimat3.ParentStyleUsing.UseBorderWidth = false;
            this.PrsNummerHeimat3.ParentStyleUsing.UseFont = false;
            this.PrsNummerHeimat3.ParentStyleUsing.UseForeColor = false;
            this.PrsNummerHeimat3.Size = new System.Drawing.Size(149, 19);
            this.PrsNummerHeimat3.Text = "PrsNummerHeimat";
            // 
            // PrsNummerKanton3
            // 
            this.PrsNummerKanton3.Font = new System.Drawing.Font("Arial", 10F);
            this.PrsNummerKanton3.ForeColor = System.Drawing.Color.Black;
            this.PrsNummerKanton3.Location = new System.Drawing.Point(248, 19);
            this.PrsNummerKanton3.Multiline = true;
            this.PrsNummerKanton3.Name = "PrsNummerKanton3";
            this.PrsNummerKanton3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PrsNummerKanton3.ParentStyleUsing.UseBackColor = false;
            this.PrsNummerKanton3.ParentStyleUsing.UseBorderColor = false;
            this.PrsNummerKanton3.ParentStyleUsing.UseBorders = false;
            this.PrsNummerKanton3.ParentStyleUsing.UseBorderWidth = false;
            this.PrsNummerKanton3.ParentStyleUsing.UseFont = false;
            this.PrsNummerKanton3.ParentStyleUsing.UseForeColor = false;
            this.PrsNummerKanton3.Size = new System.Drawing.Size(149, 19);
            this.PrsNummerKanton3.Text = "PrsNummerKanton";
            // 
            // Label20
            // 
            this.Label20.Font = new System.Drawing.Font("Arial", 10F);
            this.Label20.ForeColor = System.Drawing.Color.Black;
            this.Label20.Location = new System.Drawing.Point(12, 19);
            this.Label20.Name = "Label20";
            this.Label20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label20.ParentStyleUsing.UseBackColor = false;
            this.Label20.ParentStyleUsing.UseBorderColor = false;
            this.Label20.ParentStyleUsing.UseBorders = false;
            this.Label20.ParentStyleUsing.UseBorderWidth = false;
            this.Label20.ParentStyleUsing.UseFont = false;
            this.Label20.ParentStyleUsing.UseForeColor = false;
            this.Label20.Size = new System.Drawing.Size(236, 19);
            this.Label20.Text = "Personennummer d. Kantons";
            // 
            // Label10
            // 
            this.Label10.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.Label10.ForeColor = System.Drawing.Color.Black;
            this.Label10.Location = new System.Drawing.Point(12, 0);
            this.Label10.Name = "Label10";
            this.Label10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label10.ParentStyleUsing.UseBackColor = false;
            this.Label10.ParentStyleUsing.UseBorderColor = false;
            this.Label10.ParentStyleUsing.UseBorders = false;
            this.Label10.ParentStyleUsing.UseBorderWidth = false;
            this.Label10.ParentStyleUsing.UseFont = false;
            this.Label10.ParentStyleUsing.UseForeColor = false;
            this.Label10.Size = new System.Drawing.Size(114, 19);
            this.Label10.Text = "Verrechnungsart";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.xrLabel5.ForeColor = System.Drawing.Color.Black;
            this.xrLabel5.Location = new System.Drawing.Point(127, 0);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseBackColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorders = false;
            this.xrLabel5.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.ParentStyleUsing.UseForeColor = false;
            this.xrLabel5.Size = new System.Drawing.Size(126, 19);
            this.xrLabel5.Text = "NRM_KontoNummer_und_Name";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel4.Location = new System.Drawing.Point(253, 0);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(333, 20);
            this.xrLabel4.Text = "xrLabel1";
            // 
            // NRM_VerrechnungVon1
            // 
            this.NRM_VerrechnungVon1.Font = new System.Drawing.Font("Arial", 10F);
            this.NRM_VerrechnungVon1.ForeColor = System.Drawing.Color.Black;
            this.NRM_VerrechnungVon1.Location = new System.Drawing.Point(587, 39);
            this.NRM_VerrechnungVon1.Multiline = true;
            this.NRM_VerrechnungVon1.Name = "NRM_VerrechnungVon1";
            this.NRM_VerrechnungVon1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.NRM_VerrechnungVon1.ParentStyleUsing.UseBackColor = false;
            this.NRM_VerrechnungVon1.ParentStyleUsing.UseBorderColor = false;
            this.NRM_VerrechnungVon1.ParentStyleUsing.UseBorders = false;
            this.NRM_VerrechnungVon1.ParentStyleUsing.UseBorderWidth = false;
            this.NRM_VerrechnungVon1.ParentStyleUsing.UseFont = false;
            this.NRM_VerrechnungVon1.ParentStyleUsing.UseForeColor = false;
            this.NRM_VerrechnungVon1.Size = new System.Drawing.Size(113, 19);
            xrSummary2.FormatString = "{0:dd.MM.yyyy}";
            this.NRM_VerrechnungVon1.Summary = xrSummary2;
            this.NRM_VerrechnungVon1.Text = "NRM_VerrechnungVon";
            // 
            // txtAuslandChMeldungAm
            // 
            this.txtAuslandChMeldungAm.Font = new System.Drawing.Font("Arial", 10F);
            this.txtAuslandChMeldungAm.ForeColor = System.Drawing.Color.Black;
            this.txtAuslandChMeldungAm.Location = new System.Drawing.Point(587, 19);
            this.txtAuslandChMeldungAm.Multiline = true;
            this.txtAuslandChMeldungAm.Name = "txtAuslandChMeldungAm";
            this.txtAuslandChMeldungAm.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtAuslandChMeldungAm.ParentStyleUsing.UseBackColor = false;
            this.txtAuslandChMeldungAm.ParentStyleUsing.UseBorderColor = false;
            this.txtAuslandChMeldungAm.ParentStyleUsing.UseBorders = false;
            this.txtAuslandChMeldungAm.ParentStyleUsing.UseBorderWidth = false;
            this.txtAuslandChMeldungAm.ParentStyleUsing.UseFont = false;
            this.txtAuslandChMeldungAm.ParentStyleUsing.UseForeColor = false;
            this.txtAuslandChMeldungAm.Size = new System.Drawing.Size(107, 19);
            xrSummary3.FormatString = "{0:dd.MM.yyyy}";
            this.txtAuslandChMeldungAm.Summary = xrSummary3;
            this.txtAuslandChMeldungAm.Text = "AuslandChMeldungAm";
            // 
            // Label24
            // 
            this.Label24.Font = new System.Drawing.Font("Arial", 10F);
            this.Label24.ForeColor = System.Drawing.Color.Black;
            this.Label24.Location = new System.Drawing.Point(410, 39);
            this.Label24.Name = "Label24";
            this.Label24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label24.ParentStyleUsing.UseBackColor = false;
            this.Label24.ParentStyleUsing.UseBorderColor = false;
            this.Label24.ParentStyleUsing.UseBorders = false;
            this.Label24.ParentStyleUsing.UseBorderWidth = false;
            this.Label24.ParentStyleUsing.UseFont = false;
            this.Label24.ParentStyleUsing.UseForeColor = false;
            this.Label24.Size = new System.Drawing.Size(180, 19);
            this.Label24.Text = "An Frankreich verrechnen ab";
            // 
            // Label23
            // 
            this.Label23.Font = new System.Drawing.Font("Arial", 10F);
            this.Label23.ForeColor = System.Drawing.Color.Black;
            this.Label23.Location = new System.Drawing.Point(410, 19);
            this.Label23.Name = "Label23";
            this.Label23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label23.ParentStyleUsing.UseBackColor = false;
            this.Label23.ParentStyleUsing.UseBorderColor = false;
            this.Label23.ParentStyleUsing.UseBorders = false;
            this.Label23.ParentStyleUsing.UseBorderWidth = false;
            this.Label23.ParentStyleUsing.UseFont = false;
            this.Label23.ParentStyleUsing.UseForeColor = false;
            this.Label23.Size = new System.Drawing.Size(180, 19);
            this.Label23.Text = "Der Botschaft gemeldet am";
            // 
            // Label19
            // 
            this.Label19.Font = new System.Drawing.Font("Arial", 10F);
            this.Label19.ForeColor = System.Drawing.Color.Black;
            this.Label19.Location = new System.Drawing.Point(12, 39);
            this.Label19.Name = "Label19";
            this.Label19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label19.ParentStyleUsing.UseBackColor = false;
            this.Label19.ParentStyleUsing.UseBorderColor = false;
            this.Label19.ParentStyleUsing.UseBorders = false;
            this.Label19.ParentStyleUsing.UseBorderWidth = false;
            this.Label19.ParentStyleUsing.UseFont = false;
            this.Label19.ParentStyleUsing.UseForeColor = false;
            this.Label19.Size = new System.Drawing.Size(236, 19);
            this.Label19.Text = "Personennummer Frankreich";
            // 
            // PrsNummerHeimat2
            // 
            this.PrsNummerHeimat2.Font = new System.Drawing.Font("Arial", 10F);
            this.PrsNummerHeimat2.ForeColor = System.Drawing.Color.Black;
            this.PrsNummerHeimat2.Location = new System.Drawing.Point(248, 39);
            this.PrsNummerHeimat2.Multiline = true;
            this.PrsNummerHeimat2.Name = "PrsNummerHeimat2";
            this.PrsNummerHeimat2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PrsNummerHeimat2.ParentStyleUsing.UseBackColor = false;
            this.PrsNummerHeimat2.ParentStyleUsing.UseBorderColor = false;
            this.PrsNummerHeimat2.ParentStyleUsing.UseBorders = false;
            this.PrsNummerHeimat2.ParentStyleUsing.UseBorderWidth = false;
            this.PrsNummerHeimat2.ParentStyleUsing.UseFont = false;
            this.PrsNummerHeimat2.ParentStyleUsing.UseForeColor = false;
            this.PrsNummerHeimat2.Size = new System.Drawing.Size(149, 19);
            this.PrsNummerHeimat2.Text = "PrsNummerHeimat";
            // 
            // PrsNummerKanton2
            // 
            this.PrsNummerKanton2.Font = new System.Drawing.Font("Arial", 10F);
            this.PrsNummerKanton2.ForeColor = System.Drawing.Color.Black;
            this.PrsNummerKanton2.Location = new System.Drawing.Point(248, 19);
            this.PrsNummerKanton2.Multiline = true;
            this.PrsNummerKanton2.Name = "PrsNummerKanton2";
            this.PrsNummerKanton2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PrsNummerKanton2.ParentStyleUsing.UseBackColor = false;
            this.PrsNummerKanton2.ParentStyleUsing.UseBorderColor = false;
            this.PrsNummerKanton2.ParentStyleUsing.UseBorders = false;
            this.PrsNummerKanton2.ParentStyleUsing.UseBorderWidth = false;
            this.PrsNummerKanton2.ParentStyleUsing.UseFont = false;
            this.PrsNummerKanton2.ParentStyleUsing.UseForeColor = false;
            this.PrsNummerKanton2.Size = new System.Drawing.Size(149, 19);
            this.PrsNummerKanton2.Text = "PrsNummerKanton";
            // 
            // Label18
            // 
            this.Label18.Font = new System.Drawing.Font("Arial", 10F);
            this.Label18.ForeColor = System.Drawing.Color.Black;
            this.Label18.Location = new System.Drawing.Point(12, 19);
            this.Label18.Name = "Label18";
            this.Label18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label18.ParentStyleUsing.UseBackColor = false;
            this.Label18.ParentStyleUsing.UseBorderColor = false;
            this.Label18.ParentStyleUsing.UseBorders = false;
            this.Label18.ParentStyleUsing.UseBorderWidth = false;
            this.Label18.ParentStyleUsing.UseFont = false;
            this.Label18.ParentStyleUsing.UseForeColor = false;
            this.Label18.Size = new System.Drawing.Size(236, 19);
            this.Label18.Text = "Personennummer d. Kantons";
            // 
            // Label9
            // 
            this.Label9.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(12, 0);
            this.Label9.Name = "Label9";
            this.Label9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label9.ParentStyleUsing.UseBackColor = false;
            this.Label9.ParentStyleUsing.UseBorderColor = false;
            this.Label9.ParentStyleUsing.UseBorders = false;
            this.Label9.ParentStyleUsing.UseBorderWidth = false;
            this.Label9.ParentStyleUsing.UseFont = false;
            this.Label9.ParentStyleUsing.UseForeColor = false;
            this.Label9.Size = new System.Drawing.Size(114, 19);
            this.Label9.Text = "Verrechnungsart";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.xrLabel7.ForeColor = System.Drawing.Color.Black;
            this.xrLabel7.Location = new System.Drawing.Point(127, 0);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseBackColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorders = false;
            this.xrLabel7.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.ParentStyleUsing.UseForeColor = false;
            this.xrLabel7.Size = new System.Drawing.Size(126, 19);
            this.xrLabel7.Text = "NRM_KontoNummer_und_Name";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel6.Location = new System.Drawing.Point(253, 0);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.Size = new System.Drawing.Size(333, 20);
            this.xrLabel6.Text = "xrLabel1";
            // 
            // NRM_VerrechnungVon2
            // 
            this.NRM_VerrechnungVon2.Font = new System.Drawing.Font("Arial", 10F);
            this.NRM_VerrechnungVon2.ForeColor = System.Drawing.Color.Black;
            this.NRM_VerrechnungVon2.Location = new System.Drawing.Point(539, 35);
            this.NRM_VerrechnungVon2.Multiline = true;
            this.NRM_VerrechnungVon2.Name = "NRM_VerrechnungVon2";
            this.NRM_VerrechnungVon2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.NRM_VerrechnungVon2.ParentStyleUsing.UseBackColor = false;
            this.NRM_VerrechnungVon2.ParentStyleUsing.UseBorderColor = false;
            this.NRM_VerrechnungVon2.ParentStyleUsing.UseBorders = false;
            this.NRM_VerrechnungVon2.ParentStyleUsing.UseBorderWidth = false;
            this.NRM_VerrechnungVon2.ParentStyleUsing.UseFont = false;
            this.NRM_VerrechnungVon2.ParentStyleUsing.UseForeColor = false;
            this.NRM_VerrechnungVon2.Size = new System.Drawing.Size(150, 19);
            xrSummary4.FormatString = "{0:dd.MM.yyyy}";
            this.NRM_VerrechnungVon2.Summary = xrSummary4;
            this.NRM_VerrechnungVon2.Text = "NRM_VerrechnungVon";
            // 
            // Label22
            // 
            this.Label22.Font = new System.Drawing.Font("Arial", 10F);
            this.Label22.ForeColor = System.Drawing.Color.Black;
            this.Label22.Location = new System.Drawing.Point(410, 19);
            this.Label22.Name = "Label22";
            this.Label22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label22.ParentStyleUsing.UseBackColor = false;
            this.Label22.ParentStyleUsing.UseBorderColor = false;
            this.Label22.ParentStyleUsing.UseBorders = false;
            this.Label22.ParentStyleUsing.UseBorderWidth = false;
            this.Label22.ParentStyleUsing.UseFont = false;
            this.Label22.ParentStyleUsing.UseForeColor = false;
            this.Label22.Size = new System.Drawing.Size(129, 39);
            this.Label22.Text = "Pflichtleistungen zu unseren Kosten bis";
            // 
            // Label17
            // 
            this.Label17.Font = new System.Drawing.Font("Arial", 10F);
            this.Label17.ForeColor = System.Drawing.Color.Black;
            this.Label17.Location = new System.Drawing.Point(12, 39);
            this.Label17.Name = "Label17";
            this.Label17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label17.ParentStyleUsing.UseBackColor = false;
            this.Label17.ParentStyleUsing.UseBorderColor = false;
            this.Label17.ParentStyleUsing.UseBorders = false;
            this.Label17.ParentStyleUsing.UseBorderWidth = false;
            this.Label17.ParentStyleUsing.UseFont = false;
            this.Label17.ParentStyleUsing.UseForeColor = false;
            this.Label17.Size = new System.Drawing.Size(236, 19);
            this.Label17.Text = "Personennummer Deutschland";
            // 
            // PrsNummerHeimat1
            // 
            this.PrsNummerHeimat1.Font = new System.Drawing.Font("Arial", 10F);
            this.PrsNummerHeimat1.ForeColor = System.Drawing.Color.Black;
            this.PrsNummerHeimat1.Location = new System.Drawing.Point(248, 39);
            this.PrsNummerHeimat1.Multiline = true;
            this.PrsNummerHeimat1.Name = "PrsNummerHeimat1";
            this.PrsNummerHeimat1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PrsNummerHeimat1.ParentStyleUsing.UseBackColor = false;
            this.PrsNummerHeimat1.ParentStyleUsing.UseBorderColor = false;
            this.PrsNummerHeimat1.ParentStyleUsing.UseBorders = false;
            this.PrsNummerHeimat1.ParentStyleUsing.UseBorderWidth = false;
            this.PrsNummerHeimat1.ParentStyleUsing.UseFont = false;
            this.PrsNummerHeimat1.ParentStyleUsing.UseForeColor = false;
            this.PrsNummerHeimat1.Size = new System.Drawing.Size(149, 19);
            this.PrsNummerHeimat1.Text = "PrsNummerHeimat";
            // 
            // PrsNummerKanton1
            // 
            this.PrsNummerKanton1.Font = new System.Drawing.Font("Arial", 10F);
            this.PrsNummerKanton1.ForeColor = System.Drawing.Color.Black;
            this.PrsNummerKanton1.Location = new System.Drawing.Point(248, 19);
            this.PrsNummerKanton1.Multiline = true;
            this.PrsNummerKanton1.Name = "PrsNummerKanton1";
            this.PrsNummerKanton1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PrsNummerKanton1.ParentStyleUsing.UseBackColor = false;
            this.PrsNummerKanton1.ParentStyleUsing.UseBorderColor = false;
            this.PrsNummerKanton1.ParentStyleUsing.UseBorders = false;
            this.PrsNummerKanton1.ParentStyleUsing.UseBorderWidth = false;
            this.PrsNummerKanton1.ParentStyleUsing.UseFont = false;
            this.PrsNummerKanton1.ParentStyleUsing.UseForeColor = false;
            this.PrsNummerKanton1.Size = new System.Drawing.Size(149, 19);
            this.PrsNummerKanton1.Text = "PrsNummerKanton";
            // 
            // Label16
            // 
            this.Label16.Font = new System.Drawing.Font("Arial", 10F);
            this.Label16.ForeColor = System.Drawing.Color.Black;
            this.Label16.Location = new System.Drawing.Point(12, 19);
            this.Label16.Name = "Label16";
            this.Label16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label16.ParentStyleUsing.UseBackColor = false;
            this.Label16.ParentStyleUsing.UseBorderColor = false;
            this.Label16.ParentStyleUsing.UseBorders = false;
            this.Label16.ParentStyleUsing.UseBorderWidth = false;
            this.Label16.ParentStyleUsing.UseFont = false;
            this.Label16.ParentStyleUsing.UseForeColor = false;
            this.Label16.Size = new System.Drawing.Size(236, 19);
            this.Label16.Text = "Personennummer d. Kantons";
            // 
            // Label8
            // 
            this.Label8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(12, 0);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(114, 19);
            this.Label8.Text = "Verrechnungsart";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.xrLabel9.ForeColor = System.Drawing.Color.Black;
            this.xrLabel9.Location = new System.Drawing.Point(127, 0);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.ParentStyleUsing.UseBackColor = false;
            this.xrLabel9.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel9.ParentStyleUsing.UseBorders = false;
            this.xrLabel9.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.ParentStyleUsing.UseForeColor = false;
            this.xrLabel9.Size = new System.Drawing.Size(126, 19);
            this.xrLabel9.Text = "NRM_KontoNummer_und_Name";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel8.Location = new System.Drawing.Point(253, 0);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.Size = new System.Drawing.Size(333, 20);
            this.xrLabel8.Text = "xrLabel1";
            // 
            // txtNRM_VerrechnungBis
            // 
            this.txtNRM_VerrechnungBis.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNRM_VerrechnungBis.ForeColor = System.Drawing.Color.Black;
            this.txtNRM_VerrechnungBis.Location = new System.Drawing.Point(587, 39);
            this.txtNRM_VerrechnungBis.Multiline = true;
            this.txtNRM_VerrechnungBis.Name = "txtNRM_VerrechnungBis";
            this.txtNRM_VerrechnungBis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNRM_VerrechnungBis.ParentStyleUsing.UseBackColor = false;
            this.txtNRM_VerrechnungBis.ParentStyleUsing.UseBorderColor = false;
            this.txtNRM_VerrechnungBis.ParentStyleUsing.UseBorders = false;
            this.txtNRM_VerrechnungBis.ParentStyleUsing.UseBorderWidth = false;
            this.txtNRM_VerrechnungBis.ParentStyleUsing.UseFont = false;
            this.txtNRM_VerrechnungBis.ParentStyleUsing.UseForeColor = false;
            this.txtNRM_VerrechnungBis.Size = new System.Drawing.Size(113, 19);
            xrSummary5.FormatString = "{0:dd.MM.yyyy}";
            this.txtNRM_VerrechnungBis.Summary = xrSummary5;
            this.txtNRM_VerrechnungBis.Text = "NRM_VerrechnungBis";
            // 
            // txtNRM_VerrechnungVon
            // 
            this.txtNRM_VerrechnungVon.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNRM_VerrechnungVon.ForeColor = System.Drawing.Color.Black;
            this.txtNRM_VerrechnungVon.Location = new System.Drawing.Point(587, 19);
            this.txtNRM_VerrechnungVon.Multiline = true;
            this.txtNRM_VerrechnungVon.Name = "txtNRM_VerrechnungVon";
            this.txtNRM_VerrechnungVon.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNRM_VerrechnungVon.ParentStyleUsing.UseBackColor = false;
            this.txtNRM_VerrechnungVon.ParentStyleUsing.UseBorderColor = false;
            this.txtNRM_VerrechnungVon.ParentStyleUsing.UseBorders = false;
            this.txtNRM_VerrechnungVon.ParentStyleUsing.UseBorderWidth = false;
            this.txtNRM_VerrechnungVon.ParentStyleUsing.UseFont = false;
            this.txtNRM_VerrechnungVon.ParentStyleUsing.UseForeColor = false;
            this.txtNRM_VerrechnungVon.Size = new System.Drawing.Size(113, 19);
            xrSummary6.FormatString = "{0:dd.MM.yyyy}";
            this.txtNRM_VerrechnungVon.Summary = xrSummary6;
            this.txtNRM_VerrechnungVon.Text = "NRM_VerrechnungVon";
            // 
            // txtVerrechnungsanteil
            // 
            this.txtVerrechnungsanteil.Font = new System.Drawing.Font("Arial", 10F);
            this.txtVerrechnungsanteil.ForeColor = System.Drawing.Color.Black;
            this.txtVerrechnungsanteil.Location = new System.Drawing.Point(248, 59);
            this.txtVerrechnungsanteil.Multiline = true;
            this.txtVerrechnungsanteil.Name = "txtVerrechnungsanteil";
            this.txtVerrechnungsanteil.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtVerrechnungsanteil.ParentStyleUsing.UseBackColor = false;
            this.txtVerrechnungsanteil.ParentStyleUsing.UseBorderColor = false;
            this.txtVerrechnungsanteil.ParentStyleUsing.UseBorders = false;
            this.txtVerrechnungsanteil.ParentStyleUsing.UseBorderWidth = false;
            this.txtVerrechnungsanteil.ParentStyleUsing.UseFont = false;
            this.txtVerrechnungsanteil.ParentStyleUsing.UseForeColor = false;
            this.txtVerrechnungsanteil.Size = new System.Drawing.Size(149, 19);
            this.txtVerrechnungsanteil.Text = "Verrechnungsanteil";
            // 
            // Label15
            // 
            this.Label15.Font = new System.Drawing.Font("Arial", 10F);
            this.Label15.ForeColor = System.Drawing.Color.Black;
            this.Label15.Location = new System.Drawing.Point(410, 39);
            this.Label15.Name = "Label15";
            this.Label15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label15.ParentStyleUsing.UseBackColor = false;
            this.Label15.ParentStyleUsing.UseBorderColor = false;
            this.Label15.ParentStyleUsing.UseBorders = false;
            this.Label15.ParentStyleUsing.UseBorderWidth = false;
            this.Label15.ParentStyleUsing.UseFont = false;
            this.Label15.ParentStyleUsing.UseForeColor = false;
            this.Label15.Size = new System.Drawing.Size(180, 19);
            this.Label15.Text = "Zu Lasten Heimat bis";
            // 
            // Label14
            // 
            this.Label14.Font = new System.Drawing.Font("Arial", 10F);
            this.Label14.ForeColor = System.Drawing.Color.Black;
            this.Label14.Location = new System.Drawing.Point(410, 19);
            this.Label14.Name = "Label14";
            this.Label14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label14.ParentStyleUsing.UseBackColor = false;
            this.Label14.ParentStyleUsing.UseBorderColor = false;
            this.Label14.ParentStyleUsing.UseBorders = false;
            this.Label14.ParentStyleUsing.UseBorderWidth = false;
            this.Label14.ParentStyleUsing.UseFont = false;
            this.Label14.ParentStyleUsing.UseForeColor = false;
            this.Label14.Size = new System.Drawing.Size(180, 19);
            this.Label14.Text = "Zu Lasten Heimat von";
            // 
            // txtPrsNummerHeimat
            // 
            this.txtPrsNummerHeimat.Font = new System.Drawing.Font("Arial", 10F);
            this.txtPrsNummerHeimat.ForeColor = System.Drawing.Color.Black;
            this.txtPrsNummerHeimat.Location = new System.Drawing.Point(248, 39);
            this.txtPrsNummerHeimat.Multiline = true;
            this.txtPrsNummerHeimat.Name = "txtPrsNummerHeimat";
            this.txtPrsNummerHeimat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtPrsNummerHeimat.ParentStyleUsing.UseBackColor = false;
            this.txtPrsNummerHeimat.ParentStyleUsing.UseBorderColor = false;
            this.txtPrsNummerHeimat.ParentStyleUsing.UseBorders = false;
            this.txtPrsNummerHeimat.ParentStyleUsing.UseBorderWidth = false;
            this.txtPrsNummerHeimat.ParentStyleUsing.UseFont = false;
            this.txtPrsNummerHeimat.ParentStyleUsing.UseForeColor = false;
            this.txtPrsNummerHeimat.Size = new System.Drawing.Size(149, 19);
            this.txtPrsNummerHeimat.Text = "PrsNummerHeimat";
            // 
            // txtPrsNummerKanton
            // 
            this.txtPrsNummerKanton.Font = new System.Drawing.Font("Arial", 10F);
            this.txtPrsNummerKanton.ForeColor = System.Drawing.Color.Black;
            this.txtPrsNummerKanton.Location = new System.Drawing.Point(248, 19);
            this.txtPrsNummerKanton.Multiline = true;
            this.txtPrsNummerKanton.Name = "txtPrsNummerKanton";
            this.txtPrsNummerKanton.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtPrsNummerKanton.ParentStyleUsing.UseBackColor = false;
            this.txtPrsNummerKanton.ParentStyleUsing.UseBorderColor = false;
            this.txtPrsNummerKanton.ParentStyleUsing.UseBorders = false;
            this.txtPrsNummerKanton.ParentStyleUsing.UseBorderWidth = false;
            this.txtPrsNummerKanton.ParentStyleUsing.UseFont = false;
            this.txtPrsNummerKanton.ParentStyleUsing.UseForeColor = false;
            this.txtPrsNummerKanton.Size = new System.Drawing.Size(149, 19);
            this.txtPrsNummerKanton.Text = "PrsNummerKanton";
            // 
            // Label13
            // 
            this.Label13.Font = new System.Drawing.Font("Arial", 10F);
            this.Label13.ForeColor = System.Drawing.Color.Black;
            this.Label13.Location = new System.Drawing.Point(12, 19);
            this.Label13.Name = "Label13";
            this.Label13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label13.ParentStyleUsing.UseBackColor = false;
            this.Label13.ParentStyleUsing.UseBorderColor = false;
            this.Label13.ParentStyleUsing.UseBorders = false;
            this.Label13.ParentStyleUsing.UseBorderWidth = false;
            this.Label13.ParentStyleUsing.UseFont = false;
            this.Label13.ParentStyleUsing.UseForeColor = false;
            this.Label13.Size = new System.Drawing.Size(236, 19);
            this.Label13.Text = "Personennummer d. Kantons";
            // 
            // Label12
            // 
            this.Label12.Font = new System.Drawing.Font("Arial", 10F);
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(12, 39);
            this.Label12.Name = "Label12";
            this.Label12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label12.ParentStyleUsing.UseBackColor = false;
            this.Label12.ParentStyleUsing.UseBorderColor = false;
            this.Label12.ParentStyleUsing.UseBorders = false;
            this.Label12.ParentStyleUsing.UseBorderWidth = false;
            this.Label12.ParentStyleUsing.UseFont = false;
            this.Label12.ParentStyleUsing.UseForeColor = false;
            this.Label12.Size = new System.Drawing.Size(236, 19);
            this.Label12.Text = "Personennummer d. Heimatkantons";
            // 
            // Label11
            // 
            this.Label11.Font = new System.Drawing.Font("Arial", 10F);
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(12, 59);
            this.Label11.Name = "Label11";
            this.Label11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label11.ParentStyleUsing.UseBackColor = false;
            this.Label11.ParentStyleUsing.UseBorderColor = false;
            this.Label11.ParentStyleUsing.UseBorders = false;
            this.Label11.ParentStyleUsing.UseBorderWidth = false;
            this.Label11.ParentStyleUsing.UseFont = false;
            this.Label11.ParentStyleUsing.UseForeColor = false;
            this.Label11.Size = new System.Drawing.Size(236, 19);
            this.Label11.Text = "Verrechnungsanteil";
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(12, 0);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(114, 19);
            this.Label7.Text = "Verrechnungsart";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel1.Location = new System.Drawing.Point(253, 0);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(333, 20);
            this.xrLabel1.Text = "xrLabel1";
            // 
            // TextBox10
            // 
            this.TextBox10.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.TextBox10.ForeColor = System.Drawing.Color.Black;
            this.TextBox10.Location = new System.Drawing.Point(126, 0);
            this.TextBox10.Multiline = true;
            this.TextBox10.Name = "TextBox10";
            this.TextBox10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TextBox10.ParentStyleUsing.UseBackColor = false;
            this.TextBox10.ParentStyleUsing.UseBorderColor = false;
            this.TextBox10.ParentStyleUsing.UseBorders = false;
            this.TextBox10.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox10.ParentStyleUsing.UseFont = false;
            this.TextBox10.ParentStyleUsing.UseForeColor = false;
            this.TextBox10.Size = new System.Drawing.Size(126, 19);
            this.TextBox10.Text = "NRM_KontoNummer_und_Name";
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(12, 0);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(114, 19);
            this.Label6.Text = "Verrechnungsart";
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
                        this.PageHeader,
                        this.GroupHeader1,
                        this.GroupHeader2,
                        this.GroupHeader3a,
                        this.GroupHeader3b,
                        this.GroupHeader3c,
                        this.GroupHeader3d,
                        this.GroupHeader3e,
                        this.GroupFooter3e,
                        this.GroupFooter3d,
                        this.GroupFooter3c,
                        this.GroupFooter3b,
                        this.GroupFooter3a,
                        this.GroupFooter2,
                        this.GroupFooter1,
                        this.PageFooter,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(0, 14, 100, 100);
            this.Name = "Report";
            this.PageHeight = 1300;
            this.PageWidth = 720;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ScriptReferencesString = "System.Windows.Forms.dll";
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'SELECT [Titel]              = ''Unterstützte Personen, ihre Kostenstellen und Bankverbindungen'',
       [Name]               = PRS.Name,
       [Vorname]            = PRS.Vorname,
       [FullName]           = PRS.Name + IsNull('', '' + PRS.Vorname,'''') +  CASE LEN(IsNull(PRS.Vorname2, '''')) WHEN 0 THEN '''' ELSE '' '' + PRS.Vorname2 END,
       [Geburtsdatum]       = PRS.Geburtsdatum,
       [AHVNummer]          = PRS.AHVNummer,
       [Heimatort]          = PRS.Heimatort,
       [IstUnterstuetzt]    = SPP.IstUnterstuetzt
FROM BgFinanzplan                             SFP
     INNER JOIN BgFinanzplan_BaPerson         SPP ON SPP.BgFinanzplanID           = SFP.BgFinanzplanID
     INNER JOIN vwPerson                      PRS ON PRS.BaPersonID              = SPP.BaPersonID
WHERE SFP.BgFinanzplanID = {BgFinanzplanID} AND (SPP.IstUnterstuetzt = 1)

UNION ALL       -- now all the persons who are not unterstuetzt

SELECT [Titel]              = ''Nicht unterstützte Personen'',
       [Name]               = PRS.Name,
       [Vorname]            = PRS.Vorname,
       [FullName]           = PRS.Name + IsNull('', '' + PRS.Vorname,'''') +  CASE LEN(IsNull(PRS.Vorname2, '''')) WHEN 0 THEN '''' ELSE '' '' + PRS.Vorname2 END,
       [Geburtsdatum]       = PRS.Geburtsdatum,
       [AHVNummer]          = PRS.AhvNummer,
       [Heimatort]          = PRS.Heimatort,
       [IstUnterstuetzt]    = SPP.IstUnterstuetzt
FROM BgFinanzplan                      SFP
     INNER JOIN BgFinanzplan_BaPerson  SPP ON SPP.BgFinanzplanID           = SFP.BgFinanzplanID
     INNER JOIN vwPerson               PRS ON PRS.BaPersonID              = SPP.BaPersonID
WHERE SFP.BgFinanzplanID = {BgFinanzplanID} AND (SPP.IstUnterstuetzt=0)

ORDER BY IstUnterstuetzt desc -- first unterstuetzt ones, rest: DESC puts NULL last' ,  null ,  N'ShDetaillierterFinanzplanStandard' ,  null ,  1 );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'ShDetaillierterFinanzplanStandard_Sil' ,  N'SiL' , 1,  N'<!--
AssemblyName=DevExpress%2EXtraReports%2C%20Version%3D1%2E7%2E9%2E0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4
AssemblyLocation=c:\windows\assembly\gac\devexpress.xtrareports\1.7.9.0__79868b8147b5eae4\devexpress.xtrareports.dll
TypeName=DevExpress.XtraReports.UI.XtraReport
Localization=de-CH
-->
<SOAP-ENV:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:SOAP-ENC="http://schemas.xmlsoap.org/soap/encoding/" xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/" xmlns:clr="http://schemas.microsoft.com/soap/encoding/clr/1.0" SOAP-ENV:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
<SOAP-ENV:Body>
<a1:ReportStorage id="ref-1" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<BandCount>5</BandCount>
<Band0 href="#ref-6"/>
<Band1 href="#ref-7"/>
<Band2 href="#ref-8"/>
<Band3 href="#ref-9"/>
<Band4 href="#ref-10"/>
<Visible>true</Visible>
<Tag id="ref-11"></Tag>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-12">Report</Name>
<Style_X_Font id="ref-13">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor id="ref-14">ControlText</Style_X_ForeColor>
<Style_X_BackColor id="ref-15">Transparent</Style_X_BackColor>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>100</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<DataSource id="ref-16">dataSource</DataSource>
<UseDefaultPrinterSettings>false</UseDefaultPrinterSettings>
<ReportUnit xsi:type="a2:ReportUnit" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">HundredthsOfAnInch</ReportUnit>
<Landscape>false</Landscape>
<PaperKind xsi:type="a5:PaperKind" xmlns:a5="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Printing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">A4</PaperKind>
<PaperName href="#ref-11"/>
<Margins xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>39</x>
<y>39</y>
<width>47</width>
<height>39</height>
</Margins>
<HtmlCompressed>false</HtmlCompressed>
<PageSize xsi:type="a4:Size" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<width>827</width>
<height>1169</height>
</PageSize>
<StyleSheet_X_StyleCount>0</StyleSheet_X_StyleCount>
<ShowPreviewMarginLines>true</ShowPreviewMarginLines>
<ScriptLanguage xsi:type="a6:ScriptLanguage" xmlns:a6="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">CSharp</ScriptLanguage>
<ScriptReferences id="ref-17">System.Windows.Forms.dll</ScriptReferences>
<Watermark_X_Text href="#ref-11"/>
<Watermark_X_Font id="ref-18">Verdana, 36pt</Watermark_X_Font>
<Watermark_X_ForeColor id="ref-19">Red</Watermark_X_ForeColor>
<Watermark_X_Transparency>50</Watermark_X_Transparency>
<Watermark_X_TextDirection xsi:type="a7:DirectionMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">ForwardDiagonal</Watermark_X_TextDirection>
<Watermark_X_Image xsi:type="xsd:anyType" xsi:null="1"/>
<Watermark_X_ImageAlign xsi:type="a4:ContentAlignment" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">MiddleCenter</Watermark_X_ImageAlign>
<Watermark_X_ImageViewMode xsi:type="a7:ImageViewMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Clip</Watermark_X_ImageViewMode>
<Watermark_X_ImageTiling>false</Watermark_X_ImageTiling>
<Watermark_X_PageRange href="#ref-11"/>
<Watermark_X_ShowBehind>true</Watermark_X_ShowBehind>
<DefaultPrinterSettingsUsing_X_UseMargins>false</DefaultPrinterSettingsUsing_X_UseMargins>
<DefaultPrinterSettingsUsing_X_UsePaperKind>false</DefaultPrinterSettingsUsing_X_UsePaperKind>
<DefaultPrinterSettingsUsing_X_UseLandscape>false</DefaultPrinterSettingsUsing_X_UseLandscape>
<ShrinkSubReportIconArea>true</ShrinkSubReportIconArea>
</a1:ReportStorage>
<a1:ObjectStorage id="ref-6" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName id="ref-20">DevExpress.XtraReports, Version=1.7.9.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</Type_X_AssemblyName>
<Type_X_TypeName id="ref-21">DevExpress.XtraReports.UI.DetailBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-22">Detail</Name>
<Style_X_Font id="ref-23">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>40</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<PrintOnEmptyDataSource>true</PrintOnEmptyDataSource>
<MultiColumn_X_ColumnCount>1</MultiColumn_X_ColumnCount>
<MultiColumn_X_Direction xsi:type="a2:ColumnDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">DownThenAcross</MultiColumn_X_Direction>
<MultiColumn_X_ColumnWidth>0</MultiColumn_X_ColumnWidth>
<MultiColumn_X_ColumnSpacing>0</MultiColumn_X_ColumnSpacing>
<MultiColumn_X_Mode xsi:type="a2:MultiColumnMode" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">UseColumnCount</MultiColumn_X_Mode>
<RepeatCountOnEmptyDataSource>1</RepeatCountOnEmptyDataSource>
<ItemCount>5</ItemCount>
<Item0 href="#ref-24"/>
<Item1 href="#ref-25"/>
<Item2 href="#ref-26"/>
<Item3 href="#ref-27"/>
<Item4 href="#ref-28"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-7" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-29">DevExpress.XtraReports.UI.PageHeaderBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-30">PageHeader</Name>
<Style_X_Font id="ref-31">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>27</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>1</ItemCount>
<Item0 href="#ref-32"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-8" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-33">DevExpress.XtraReports.UI.GroupHeaderBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-34">GroupHeader1</Name>
<Style_X_Font id="ref-35">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>70</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<Level>0</Level>
<RepeatEveryPage>false</RepeatEveryPage>
<GroupFieldCount>1</GroupFieldCount>
<GroupField0_X_FieldName id="ref-36">SilTypName</GroupField0_X_FieldName>
<GroupField0_X_SortOrder xsi:type="a2:XRColumnSortOrder" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Ascending</GroupField0_X_SortOrder>
<GroupUnion xsi:type="a2:GroupUnion" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</GroupUnion>
<ItemCount>6</ItemCount>
<Item0 href="#ref-37"/>
<Item1 href="#ref-38"/>
<Item2 href="#ref-39"/>
<Item3 href="#ref-40"/>
<Item4 href="#ref-41"/>
<Item5 href="#ref-42"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-9" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-43">DevExpress.XtraReports.UI.GroupFooterBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-44">GroupFooter1</Name>
<Style_X_Font id="ref-45">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>78</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<Level>0</Level>
<RepeatEveryPage>false</RepeatEveryPage>
<GroupUnion xsi:type="a2:GroupFooterUnion" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</GroupUnion>
<PrintAtBottom>false</PrintAtBottom>
<ItemCount>8</ItemCount>
<Item0 href="#ref-46"/>
<Item1 href="#ref-47"/>
<Item2 href="#ref-48"/>
<Item3 href="#ref-49"/>
<Item4 href="#ref-50"/>
<Item5 href="#ref-51"/>
<Item6 href="#ref-52"/>
<Item7 href="#ref-53"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-10" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-54">DevExpress.XtraReports.UI.PageFooterBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-55">PageFooter</Name>
<Style_X_Font id="ref-56">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>0</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-24" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-57">DevExpress.XtraReports.UI.XRLabel</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-58">txtBemerkungRTF</Name>
<Style_X_Font id="ref-59">Arial, 10pt, style=Italic</Style_X_Font>
<Style_X_ForeColor id="ref-60">Black</Style_X_ForeColor>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName id="ref-61">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-62">BemerkungRTF</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>15</y>
<width>680</width>
<height>19</height>
</Bounds>
<Text id="ref-63">BemerkungRTF</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-25" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-57"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-64">txtPersonName</Name>
<Style_X_Font id="ref-65">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-60"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-61"/>
<BindingItem0_X_DataMember id="ref-66">PersonName</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>0</y>
<width>244</width>
<height>19</height>
</Bounds>
<Text id="ref-67">PersonName</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-26" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-57"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-68">txtAbzug</Name>
<Style_X_Font id="ref-69">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-60"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-61"/>
<BindingItem0_X_DataMember id="ref-70">Abzug</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-71">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>613</x>
<y>0</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-72">Abzug</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-73">{0:#,##0.00}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-27" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-57"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-74">txtBetrag</Name>
<Style_X_Font id="ref-75">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-60"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-61"/>
<BindingItem0_X_DataMember id="ref-76">Betrag</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-77">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>520</x>
<y>0</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-78">Betrag</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-79">{0:#,##0.00}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-28" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-57"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-80">txtSilName</Name>
<Style_X_Font id="ref-81">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-60"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-61"/>
<BindingItem0_X_DataMember id="ref-82">SilName</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>251</x>
<y>0</y>
<width>260</width>
<height>19</height>
</Bounds>
<Text id="ref-83">SilName</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-32" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-84">DevExpress.XtraReports.UI.XRPanel</Type_X_TypeName>
<Visible>false</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-85">hiderPanel</Name>
<Style_X_Font id="ref-86">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>160</x>
<y>0</y>
<width>347</width>
<height>27</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<ItemCount>1</ItemCount>
<Item0 href="#ref-87"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-37" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-88">DevExpress.XtraReports.UI.XRLine</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-89">xrLine1</Name>
<Style_X_Font id="ref-90">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-60"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>7</x>
<y>47</y>
<width>686</width>
<height>3</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-38" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-57"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-91">Label4</Name>
<Style_X_Font id="ref-92">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-60"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<x>613</x>
<y>27</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-93">Reduktion</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-39" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-57"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-94">Label3</Name>
<Style_X_Font id="ref-95">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-60"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<x>520</x>
<y>27</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-96">Betrag</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-40" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-57"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-97">Label2</Name>
<Style_X_Font id="ref-98">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-60"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>251</x>
<y>27</y>
<width>153</width>
<height>19</height>
</Bounds>
<Text id="ref-99">Art der Leistung</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-41" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-57"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-100">Label1</Name>
<Style_X_Font id="ref-101">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-60"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>7</x>
<y>27</y>
<width>118</width>
<height>19</height>
</Bounds>
<Text id="ref-102">Betrifft</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-42" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-57"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-103">txtSilTypName</Name>
<Style_X_Font id="ref-104">Arial, 10pt, style=Bold, Underline</Style_X_Font>
<Style_X_ForeColor href="#ref-60"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-61"/>
<BindingItem0_X_DataMember id="ref-105">SilTypName</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>693</width>
<height>19</height>
</Bounds>
<Text id="ref-106">SilTypName</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-46" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-88"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-107">Line5</Name>
<Style_X_Font id="ref-108">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-60"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>7</x>
<y>0</y>
<width>686</width>
<height>3</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-47" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-88"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-109">Line4</Name>
<Style_X_Font id="ref-110">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-60"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>613</x>
<y>54</y>
<width>78</width>
<height>2</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-48" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-88"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-111">Line3</Name>
<Style_X_Font id="ref-112">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-60"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>613</x>
<y>51</y>
<width>78</width>
<height>2</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-49" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-88"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-113">Line2</Name>
<Style_X_Font id="ref-114">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-60"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>7</x>
<y>26</y>
<width>680</width>
<height>3</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-50" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-57"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-115">BetragMINUSReduktion</Name>
<Style_X_Font id="ref-116">Arial, 10pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-60"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName id="ref-117">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-118">BetragMinusAbzug</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>613</x>
<y>31</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-119">BetragMINUSReduktion</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-120">{0:n2}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Group</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-51" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-57"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-121">totReduktion</Name>
<Style_X_Font id="ref-122">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-60"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName id="ref-123">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-124">Abzug</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-125">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>613</x>
<y>3</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-126">totReduktion</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-127">{0:n2}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Group</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-52" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-57"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-128">totBetrag</Name>
<Style_X_Font id="ref-129">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-60"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-123"/>
<BindingItem0_X_DataMember id="ref-130">Betrag</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-131">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>520</x>
<y>3</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-132">totBetrag</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-133">{0:n2}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Group</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-53" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-57"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-134">TextBox1</Name>
<Style_X_Font id="ref-135">Arial, 10pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-60"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName id="ref-136">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-137">SilTypName</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-138">Total {0}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>31</y>
<width>593</width>
<height>19</height>
</Bounds>
<Text id="ref-139">Total SiL</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-87" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-57"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-140">hiderSilTypName</Name>
<Style_X_Font id="ref-141">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-142">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-143">SilTypName</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>100</width>
<height>27</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<EventsScript_X_OnAfterPrint id="ref-144">private void OnAfterPrint(object sender, System.EventArgs e) {
  GroupHeader1.Visible = hiderSilTypName.Text != String.Empty;
  GroupFooter1.Visible = hiderSilTypName.Text != String.Empty;
}</EventsScript_X_OnAfterPrint>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
</SOAP-ENV:Body>
</SOAP-ENV:Envelope>' ,  null ,  N'DECLARE @BgBudgetID int

SELECT @BgBudgetID = BgBudgetID
FROM BgBudget
WHERE BgFinanzplanID = {BgFinanzplanID} AND MasterBudget = 1

SELECT
  [SilTypName] = dbo.fnLOVText(''BgGruppe'', SPT.BgGruppeCode),
  [PersonName] = PRS.Name + '', '' + PRS.Vorname,
  [SilName]    = SPT.Name,
  BPO.Betrag,
  BPO.Abzug,
  BPO.Bemerkung,
  BetragMinusAbzug = BPO.Betrag - BPO.Abzug
FROM WhPositionsart      SPT
  INNER JOIN BgPosition  BPO ON BPO.BgPositionsartID = SPT.BgPositionsartID
  LEFT  JOIN BaPerson    PRS ON PRS.BaPersonID = BPO.BaPersonID
WHERE SPT.BgGruppeCode = 99 AND BPO.BgBudgetID = @BgBudgetID
  AND BPO.DatumVon IS NULL' ,  null ,  N'ShDetaillierterFinanzplanStandard' ,  null ,  1 );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'ShDetaillierterFinanzplanStandard_Uebersicht' ,  N'Budget Übersicht' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4.2.07\KiSS4.DB.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4.2.07\log4net.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4.2.07\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel Betrag1;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtBezeichnung;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel Label1;
        private DevExpress.XtraReports.UI.GroupHeaderBand grp1H;
        private DevExpress.XtraReports.UI.XRLabel txtGrp1Text;
        private DevExpress.XtraReports.UI.GroupFooterBand grp1F;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel lblTotGrp1;
        private DevExpress.XtraReports.UI.XRLabel Grp1Betrag;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
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
                        "AAAAZgXREVDTEFSRSBAQmdCdWRnZXRJRCBpbnQNCkRFQ0xBUkUgQEdldERhdGUgICAgIGRhdGV0aW1lD" +
                        "QpTRVQgQEdldERhdGUgPSBHZXREYXRlKCkNCg0KU0VMRUNUIEBCZ0J1ZGdldElEID0gQmdCdWRnZXRJR" +
                        "A0KRlJPTSBCZ0J1ZGdldA0KV0hFUkUgQmdGaW5hbnpwbGFuSUQgPSBudWxsIEFORCBNYXN0ZXJCdWRnZ" +
                        "XQgPSAxDQoNClNFTEVDVCBCUE8uQmdQb3NpdGlvbklELCBCUE8uQmdQb3NpdGlvbnNhcnRJRCwgQlBPL" +
                        "kJldHJhZ0ZpbmFuenBsYW4NCklOVE8gI0JnUG9zaXRpb24NCkZST00gdndCZ1Bvc2l0aW9uICAgICAgI" +
                        "CAgICAgQlBPDQogIElOTkVSIEpPSU4gV2hQb3NpdGlvbnNhcnQgIFNQVCBPTiBTUFQuQmdQb3NpdGlvb" +
                        "nNhcnRJRCA9IEJQTy5CZ1Bvc2l0aW9uc2FydElEDQpXSEVSRSBCUE8uQmdCdWRnZXRJRCA9IEBCZ0J1Z" +
                        "GdldElEIEFORCBCUE8uQmdLYXRlZ29yaWVDb2RlIElOICgxLCAyKQ0KICBBTkQgKCAoQlBPLkRhdHVtV" +
                        "m9uIElTIE5VTEwgIEFORCBCUE8uQmdQb3NpdGlvbnNhcnRJRCBOT1QgSU4gKDIwLCAyMSkgQU5EIEJQT" +
                        "y5CZ1Bvc2l0aW9uc2FydElEIE5PVCBCRVRXRUVOIDYwIEFORCA5OSkgT1INCiAgICAgICAgKChCUE8uQ" +
                        "mdQb3NpdGlvbnNhcnRJRCBJTiAoMjAsIDIxKSBPUiBCUE8uQmdQb3NpdGlvbnNhcnRJRCBCRVRXRUVOI" +
                        "DYwIEFORCA5OSkNCiAgICAgICAgICAgQU5EIEdldERhdGUoKSBCRVRXRUVOIElzTnVsbChCUE8uRGF0d" +
                        "W1Wb24sICcxOTAwMDEwMScpIEFORCBJc051bGwoQlBPLkRhdHVtQmlzLCBHZXREYXRlKCkpKQ0KICAgI" +
                        "CAgKQ0KDQpERUNMQVJFIEBUb3RJbiBtb25leSwgQFRvdE91dCBtb25leSwgQFRvdEt1ZXJ6IG1vbmV5D" +
                        "QoNClNFTEVDVCBAVG90SW4gPSBTVU0oQmV0cmFnKQ0KRlJPTSBkYm8uZm5XaEdldEZpbmFuenBsYW4oQ" +
                        "EJnQnVkZ2V0SUQsIEBHZXREYXRlKSAgVE1QDQogIElOTkVSIEpPSU4gWExPVkNvZGUgIFhQQyBPTiBYU" +
                        "EMuTE9WTmFtZSA9ICdCZ0thdGVnb3JpZScgQU5EIFhQQy5Db2RlID0gVE1QLkJnS2F0ZWdvcmllQ29kZ" +
                        "Q0KV0hFUkUgQmdLYXRlZ29yaWVDb2RlID0gMQ0KDQpTRUxFQ1QgQFRvdE91dCA9IFNVTShCZXRyYWcpD" +
                        "QpGUk9NIGRiby5mbldoR2V0RmluYW56cGxhbihAQmdCdWRnZXRJRCwgQEdldERhdGUpICBUTVANCiAgS" +
                        "U5ORVIgSk9JTiBYTE9WQ29kZSAgWFBDIE9OIFhQQy5MT1ZOYW1lID0gJ0JnS2F0ZWdvcmllJyBBTkQgW" +
                        "FBDLkNvZGUgPSBUTVAuQmdLYXRlZ29yaWVDb2RlDQpXSEVSRSBCZ0thdGVnb3JpZUNvZGUgPSAyDQoNC" +
                        "lNFTEVDVCBAVG90S3VlcnogPSBTVU0oQmV0cmFnKQ0KRlJPTSBkYm8uZm5XaEdldEZpbmFuenBsYW4oQ" +
                        "EJnQnVkZ2V0SUQsIEBHZXREYXRlKSAgVE1QDQogIElOTkVSIEpPSU4gWExPVkNvZGUgIFhQQyBPTiBYU" +
                        "EMuTE9WTmFtZSA9ICdCZ0thdGVnb3JpZScgQU5EIFhQQy5Db2RlID0gVE1QLkJnS2F0ZWdvcmllQ29kZ" +
                        "Q0KV0hFUkUgQmdLYXRlZ29yaWVDb2RlID0gNA0KDQpTRUxFQ1QgU1BULkJnS2F0ZWdvcmllQ29kZSwgT" +
                        "UFYKFhQQy5UZXh0KSBBUyBCZ0thdGVnb3JpZVRleHQsDQogIEJnUG9zaXRpb25zYXJ0VGV4dCA9IE1BW" +
                        "ChDQVNFDQogICAgICAgICAgICAgV0hFTiBTUFQuQmdHcnVwcGVDb2RlID0gMzIwMSAgICAgIFRIRU4gJ" +
                        "0dydW5kYmVkYXJmJw0KDQogICAgICAgICAgICAgV0hFTiBTUFQuQmdQb3NpdGlvbnNhcnRJRCA9IDMyM" +
                        "DIwIFRIRU4gJ0tWRyBQcsOkbWllbicNCiAgICAgICAgICAgICBXSEVOIFNQVC5CZ1Bvc2l0aW9uc2Fyd" +
                        "ElEID0gMzIwMjEgVEhFTiAnVlZHIFByw6RtaWVuJw0KICAgICAgICAgICAgIFdIRU4gU1BULkJnUG9za" +
                        "XRpb25zYXJ0SUQgPSAzMjAyMiBUSEVOICdWVkcgUHLDpG1pZW4nDQoNCiAgICAgICAgICAgICBXSEVOI" +
                        "FNQVC5CZ1Bvc2l0aW9uc2FydElEID0gMzIwMzAgVEhFTiBTUFQuTmFtZQ0KICAgICAgICAgICAgIFdIR" +
                        "U4gU1BULkJnUG9zaXRpb25zYXJ0SUQgPSAzMjAzMSBUSEVOIFNQVC5OYW1lDQoNCiAgICAgICAgICAgI" +
                        "CBFTFNFIFhQVC5UZXh0DQogICAgICAgICAgIEVORCksDQogIEJldHJhZyA9IFNVTShJc051bGwoQlBPL" +
                        "kJldHJhZ0ZpbmFuenBsYW4sICQwLjAwKSksDQogIEZlaGxiZXRyYWcgPSBpc051bGwoQFRvdE91dCwwK" +
                        "SAtIGlzTnVsbChAVG90SW4sMCkgLSBpc051bGwoQFRvdEt1ZXJ6LDApDQpGUk9NIFdoUG9zaXRpb25zY" +
                        "XJ0ICAgICAgIFNQVA0KICBJTk5FUiBKT0lOIFhMT1ZDb2RlICAgICBYUEMgT04gWFBDLkxPVk5hbWUgP" +
                        "SAnQmdLYXRlZ29yaWUnIEFORCBYUEMuQ29kZSA9IFNQVC5CZ0thdGVnb3JpZUNvZGUNCiAgSU5ORVIgS" +
                        "k9JTiBYTE9WQ29kZSAgICAgWFBUIE9OIFhQVC5MT1ZOYW1lID0gJ0JnR3J1cHBlJyAgICBBTkQgWFBUL" +
                        "kNvZGUgPSBTUFQuQmdHcnVwcGVDb2RlDQogIExFRlQgIEpPSU4gI0JnUG9zaXRpb24gIEJQTyBPTiBCU" +
                        "E8uQmdQb3NpdGlvbnNhcnRJRCA9IFNQVC5CZ1Bvc2l0aW9uc2FydElEDQpXSEVSRSBTUFQuQmdLYXRlZ" +
                        "29yaWVDb2RlIElOICgxLCAyKQ0KICBBTkQgQlBPLkJldHJhZ0ZpbmFuenBsYW4gSVMgTk9UIE5VTEwNC" +
                        "kdST1VQIEJZIFNQVC5CZ0thdGVnb3JpZUNvZGUsIFNQVC5CZ0thdGVnb3JpZUNvZGUsIFNQVC5CZ0dyd" +
                        "XBwZUNvZGUsDQogIENBU0UNCiAgICBXSEVOIFNQVC5CZ0dydXBwZUNvZGUgPSAzMjAxICAgICAgVEhFT" +
                        "iAxDQoNCiAgICBXSEVOIFNQVC5CZ1Bvc2l0aW9uc2FydElEID0gMzIwMjAgVEhFTiAyMA0KICAgIFdIR" +
                        "U4gU1BULkJnUG9zaXRpb25zYXJ0SUQgPSAzMjAyMSBUSEVOIDIxDQogICAgV0hFTiBTUFQuQmdQb3Npd" +
                        "GlvbnNhcnRJRCA9IDMyMDIyIFRIRU4gMjENCg0KICAgIFdIRU4gU1BULkJnUG9zaXRpb25zYXJ0SUQgP" +
                        "SAzMjAzMCBUSEVOIDMwDQogICAgV0hFTiBTUFQuQmdQb3NpdGlvbnNhcnRJRCA9IDMyMDMxIFRIRU4gM" +
                        "zENCg0KICAgIEVMU0UgMA0KICBFTkQNCk9SREVSIEJZIE1BWChYUEMuU29ydEtleSksIE1BWChYUFQuU" +
                        "29ydEtleSkNCg0KRFJPUCBUQUJMRSAjQmdQb3NpdGlvbg==";
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
            this.grp1F = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.Betrag1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBezeichnung = new DevExpress.XtraReports.UI.XRLabel();
            this.Label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGrp1Text = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.lblTotGrp1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Grp1Betrag = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Betrag1,
                        this.txtBezeichnung});
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
                        this.Label1});
            this.ReportHeader.Height = 31;
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
            this.grp1H.Height = 19;
            this.grp1H.Name = "grp1H";
            this.grp1H.ParentStyleUsing.UseBackColor = false;
            this.grp1H.ParentStyleUsing.UseBorderColor = false;
            this.grp1H.ParentStyleUsing.UseBorders = false;
            this.grp1H.ParentStyleUsing.UseBorderWidth = false;
            this.grp1H.ParentStyleUsing.UseFont = false;
            this.grp1H.ParentStyleUsing.UseForeColor = false;
            // 
            // grp1F
            // 
            this.grp1F.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel1,
                        this.Line2,
                        this.Line1,
                        this.lblTotGrp1,
                        this.Grp1Betrag});
            this.grp1F.Height = 40;
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
                        this.xrLine1,
                        this.xrLabel3,
                        this.xrLabel2});
            this.ReportFooter.Height = 39;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
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
            this.Betrag1.Size = new System.Drawing.Size(97, 19);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.Betrag1.Summary = xrSummary1;
            this.Betrag1.Text = "Betrag";
            this.Betrag1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtBezeichnung
            // 
            this.txtBezeichnung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BgPositionsartText", "")});
            this.txtBezeichnung.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBezeichnung.ForeColor = System.Drawing.Color.Black;
            this.txtBezeichnung.Location = new System.Drawing.Point(47, 0);
            this.txtBezeichnung.Multiline = true;
            this.txtBezeichnung.Name = "txtBezeichnung";
            this.txtBezeichnung.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBezeichnung.ParentStyleUsing.UseBackColor = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorderColor = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorders = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorderWidth = false;
            this.txtBezeichnung.ParentStyleUsing.UseFont = false;
            this.txtBezeichnung.ParentStyleUsing.UseForeColor = false;
            this.txtBezeichnung.Size = new System.Drawing.Size(375, 19);
            this.txtBezeichnung.Text = "txtBezeichnung";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(0, 12);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(685, 19);
            this.Label1.Text = "Übersicht über das Budget";
            // 
            // txtGrp1Text
            // 
            this.txtGrp1Text.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BgKategorieText", "")});
            this.txtGrp1Text.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
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
            this.txtGrp1Text.Size = new System.Drawing.Size(708, 19);
            this.txtGrp1Text.Text = "txtGrp1Text";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BgKategorieText", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
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
            this.lblTotGrp1.Size = new System.Drawing.Size(40, 19);
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
            this.Grp1Betrag.Size = new System.Drawing.Size(97, 19);
            xrSummary2.FormatString = "{0:#,##0.00}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.Grp1Betrag.Summary = xrSummary2;
            this.Grp1Betrag.Text = "Grp1Betrag";
            this.Grp1Betrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.Location = new System.Drawing.Point(0, 33);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(564, 2);
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Fehlbetrag", "{0:n2}")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(417, 8);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(147, 19);
            xrSummary3.FormatString = "{0:#,##0.00}";
            this.xrLabel3.Summary = xrSummary3;
            this.xrLabel3.Text = "xrLabel3";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.Location = new System.Drawing.Point(0, 8);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseBackColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorders = false;
            this.xrLabel2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.ParentStyleUsing.UseForeColor = false;
            this.xrLabel2.Size = new System.Drawing.Size(125, 19);
            this.xrLabel2.Text = "Fehlbetrag";
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
                        this.grp1F,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'DECLARE @BgBudgetID int
DECLARE @GetDate     datetime
SET @GetDate = GetDate()

SELECT @BgBudgetID = BgBudgetID
FROM BgBudget
WHERE BgFinanzplanID = {BgFinanzplanID} AND MasterBudget = 1

SELECT BPO.BgPositionID, BPO.BgPositionsartID, BPO.BetragFinanzplan
INTO #BgPosition
FROM vwBgPosition            BPO
  INNER JOIN WhPositionsart  SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
WHERE BPO.BgBudgetID = @BgBudgetID 
  AND BPO.BgKategorieCode IN (1, 2)
  AND @GetDate BETWEEN IsNull(BPO.DatumVon, ''19000101'') AND IsNull(BPO.DatumBis, @GetDate)

DECLARE @TotIn money, @TotOut money, @TotKuerz money

SELECT @TotIn = SUM(Betrag)
FROM dbo.fnWhGetFinanzplan(@BgBudgetID, @GetDate)  TMP
  INNER JOIN XLOVCode  XPC ON XPC.LOVName = ''BgKategorie'' AND XPC.Code = TMP.BgKategorieCode
WHERE BgKategorieCode = 1

SELECT @TotOut = SUM(Betrag)
FROM dbo.fnWhGetFinanzplan(@BgBudgetID, @GetDate)  TMP
  INNER JOIN XLOVCode  XPC ON XPC.LOVName = ''BgKategorie'' AND XPC.Code = TMP.BgKategorieCode
WHERE BgKategorieCode = 2

SELECT @TotKuerz = SUM(Betrag)
FROM dbo.fnWhGetFinanzplan(@BgBudgetID, @GetDate)  TMP
  INNER JOIN XLOVCode  XPC ON XPC.LOVName = ''BgKategorie'' AND XPC.Code = TMP.BgKategorieCode
WHERE BgKategorieCode = 4

SELECT SPT.BgKategorieCode, MAX(XPC.Text) AS BgKategorieText,
  BgPositionsartText = MAX(CASE
             WHEN SPT.BgGruppeCode = 3201      THEN ''Grundbedarf''

             WHEN SPT.BgPositionsartCode = 32020 THEN ''KVG Prämien''
             WHEN SPT.BgPositionsartCode = 32021 THEN ''VVG Prämien''
             WHEN SPT.BgPositionsartCode = 32022 THEN ''VVG Prämien''

             WHEN SPT.BgPositionsartCode = 32030 THEN SPT.Name
             WHEN SPT.BgPositionsartCode = 32031 THEN SPT.Name

             ELSE XPT.Text
           END),
  Betrag = SUM(IsNull(BPO.BetragFinanzplan, $0.00)),
  Fehlbetrag = isNull(@TotOut,0) - isNull(@TotIn,0) - isNull(@TotKuerz,0)
FROM WhPositionsart       SPT
  INNER JOIN XLOVCode     XPC ON XPC.LOVName = ''BgKategorie'' AND XPC.Code = SPT.BgKategorieCode
  INNER JOIN XLOVCode     XPT ON XPT.LOVName = ''BgGruppe''    AND XPT.Code = SPT.BgGruppeCode
  LEFT  JOIN #BgPosition  BPO ON BPO.BgPositionsartID = SPT.BgPositionsartID
WHERE SPT.BgKategorieCode IN (1, 2)
  AND BPO.BetragFinanzplan IS NOT NULL
GROUP BY SPT.BgKategorieCode, SPT.BgKategorieCode, SPT.BgGruppeCode,
  CASE
    WHEN SPT.BgGruppeCode = 3201      THEN 1

    WHEN SPT.BgPositionsartCode = 32020 THEN 20
    WHEN SPT.BgPositionsartCode = 32021 THEN 21
    WHEN SPT.BgPositionsartCode = 32022 THEN 21

    WHEN SPT.BgPositionsartCode = 32030 THEN 30
    WHEN SPT.BgPositionsartCode = 32031 THEN 31

    ELSE 0
  END
ORDER BY MAX(XPC.SortKey), MAX(XPT.SortKey)

DROP TABLE #BgPosition' ,  null ,  N'ShDetaillierterFinanzplanStandard' ,  null ,  1 );


--SQLCHECK_IGNORE--
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey, System)
VALUES ( N'ShDetaillierterFinanzplanStandard_Vermoegen' ,  N'Vermögen' , 1,  N'<!--
AssemblyName=DevExpress%2EXtraReports%2C%20Version%3D1%2E7%2E9%2E0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4
AssemblyLocation=c:\windows\assembly\gac\devexpress.xtrareports\1.7.9.0__79868b8147b5eae4\devexpress.xtrareports.dll
TypeName=DevExpress.XtraReports.UI.XtraReport
Localization=de-CH
-->
<SOAP-ENV:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:SOAP-ENC="http://schemas.xmlsoap.org/soap/encoding/" xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/" xmlns:clr="http://schemas.microsoft.com/soap/encoding/clr/1.0" SOAP-ENV:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
<SOAP-ENV:Body>
<a1:ReportStorage id="ref-1" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<BandCount>5</BandCount>
<Band0 href="#ref-6"/>
<Band1 href="#ref-7"/>
<Band2 href="#ref-8"/>
<Band3 href="#ref-9"/>
<Band4 href="#ref-10"/>
<Visible>true</Visible>
<Tag id="ref-11"></Tag>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-12">Report</Name>
<Style_X_Font id="ref-13">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor id="ref-14">ControlText</Style_X_ForeColor>
<Style_X_BackColor id="ref-15">Transparent</Style_X_BackColor>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>100</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<DataSource id="ref-16">dataSource</DataSource>
<UseDefaultPrinterSettings>false</UseDefaultPrinterSettings>
<ReportUnit xsi:type="a2:ReportUnit" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">HundredthsOfAnInch</ReportUnit>
<Landscape>false</Landscape>
<PaperKind xsi:type="a5:PaperKind" xmlns:a5="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Printing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">A4</PaperKind>
<PaperName href="#ref-11"/>
<Margins xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>39</x>
<y>39</y>
<width>92</width>
<height>39</height>
</Margins>
<HtmlCompressed>false</HtmlCompressed>
<PageSize xsi:type="a4:Size" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<width>827</width>
<height>1169</height>
</PageSize>
<StyleSheet_X_StyleCount>0</StyleSheet_X_StyleCount>
<ShowPreviewMarginLines>true</ShowPreviewMarginLines>
<ScriptLanguage xsi:type="a6:ScriptLanguage" xmlns:a6="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">CSharp</ScriptLanguage>
<Watermark_X_Text href="#ref-11"/>
<Watermark_X_Font id="ref-17">Verdana, 36pt</Watermark_X_Font>
<Watermark_X_ForeColor id="ref-18">Red</Watermark_X_ForeColor>
<Watermark_X_Transparency>50</Watermark_X_Transparency>
<Watermark_X_TextDirection xsi:type="a7:DirectionMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">ForwardDiagonal</Watermark_X_TextDirection>
<Watermark_X_Image xsi:type="xsd:anyType" xsi:null="1"/>
<Watermark_X_ImageAlign xsi:type="a4:ContentAlignment" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">MiddleCenter</Watermark_X_ImageAlign>
<Watermark_X_ImageViewMode xsi:type="a7:ImageViewMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Clip</Watermark_X_ImageViewMode>
<Watermark_X_ImageTiling>false</Watermark_X_ImageTiling>
<Watermark_X_PageRange href="#ref-11"/>
<Watermark_X_ShowBehind>true</Watermark_X_ShowBehind>
<DefaultPrinterSettingsUsing_X_UseMargins>false</DefaultPrinterSettingsUsing_X_UseMargins>
<DefaultPrinterSettingsUsing_X_UsePaperKind>false</DefaultPrinterSettingsUsing_X_UsePaperKind>
<DefaultPrinterSettingsUsing_X_UseLandscape>false</DefaultPrinterSettingsUsing_X_UseLandscape>
<ShrinkSubReportIconArea>true</ShrinkSubReportIconArea>
</a1:ReportStorage>
<a1:ObjectStorage id="ref-6" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName id="ref-19">DevExpress.XtraReports, Version=1.7.9.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</Type_X_AssemblyName>
<Type_X_TypeName id="ref-20">DevExpress.XtraReports.UI.DetailBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-21">Detail</Name>
<Style_X_Font id="ref-22">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>40</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<PrintOnEmptyDataSource>true</PrintOnEmptyDataSource>
<MultiColumn_X_ColumnCount>1</MultiColumn_X_ColumnCount>
<MultiColumn_X_Direction xsi:type="a2:ColumnDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">DownThenAcross</MultiColumn_X_Direction>
<MultiColumn_X_ColumnWidth>0</MultiColumn_X_ColumnWidth>
<MultiColumn_X_ColumnSpacing>0</MultiColumn_X_ColumnSpacing>
<MultiColumn_X_Mode xsi:type="a2:MultiColumnMode" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">UseColumnCount</MultiColumn_X_Mode>
<RepeatCountOnEmptyDataSource>1</RepeatCountOnEmptyDataSource>
<ItemCount>5</ItemCount>
<Item0 href="#ref-23"/>
<Item1 href="#ref-24"/>
<Item2 href="#ref-25"/>
<Item3 href="#ref-26"/>
<Item4 href="#ref-27"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-7" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-28">DevExpress.XtraReports.UI.PageHeaderBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-29">PageHeader</Name>
<Style_X_Font id="ref-30">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>75</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>1</ItemCount>
<Item0 href="#ref-31"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-8" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-32">DevExpress.XtraReports.UI.GroupHeaderBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-33">GroupHeader1</Name>
<Style_X_Font id="ref-34">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>70</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<Level>0</Level>
<RepeatEveryPage>false</RepeatEveryPage>
<GroupFieldCount>1</GroupFieldCount>
<GroupField0_X_FieldName id="ref-35">SilTypName</GroupField0_X_FieldName>
<GroupField0_X_SortOrder xsi:type="a2:XRColumnSortOrder" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Ascending</GroupField0_X_SortOrder>
<GroupUnion xsi:type="a2:GroupUnion" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</GroupUnion>
<ItemCount>6</ItemCount>
<Item0 href="#ref-36"/>
<Item1 href="#ref-37"/>
<Item2 href="#ref-38"/>
<Item3 href="#ref-39"/>
<Item4 href="#ref-40"/>
<Item5 href="#ref-41"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-9" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-42">DevExpress.XtraReports.UI.GroupFooterBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-43">GroupFooter1</Name>
<Style_X_Font id="ref-44">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>90</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<Level>0</Level>
<RepeatEveryPage>false</RepeatEveryPage>
<GroupUnion xsi:type="a2:GroupFooterUnion" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</GroupUnion>
<PrintAtBottom>false</PrintAtBottom>
<ItemCount>10</ItemCount>
<Item0 href="#ref-45"/>
<Item1 href="#ref-46"/>
<Item2 href="#ref-47"/>
<Item3 href="#ref-48"/>
<Item4 href="#ref-49"/>
<Item5 href="#ref-50"/>
<Item6 href="#ref-51"/>
<Item7 href="#ref-52"/>
<Item8 href="#ref-53"/>
<Item9 href="#ref-54"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-10" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-55">DevExpress.XtraReports.UI.PageFooterBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-56">PageFooter</Name>
<Style_X_Font id="ref-57">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>0</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-23" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-58">DevExpress.XtraReports.UI.XRLabel</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-59">txtVerbrauch</Name>
<Style_X_Font id="ref-60">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor id="ref-61">Black</Style_X_ForeColor>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName id="ref-62">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-63">Verbrauch</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-64">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>613</x>
<y>0</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-65">Verbrauch</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-66">{0:#,##0.00}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-24" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-58"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-67">txtVermoegensTyp</Name>
<Style_X_Font id="ref-68">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-61"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-62"/>
<BindingItem0_X_DataMember id="ref-69">VermoegensTyp</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>216</x>
<y>0</y>
<width>313</width>
<height>19</height>
</Bounds>
<Text id="ref-70">VermoegensTyp</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-25" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-58"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-71">txtBetrag</Name>
<Style_X_Font id="ref-72">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-61"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-62"/>
<BindingItem0_X_DataMember id="ref-73">Betrag</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-74">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>533</x>
<y>0</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-75">Betrag</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-76">{0:#,##0.00}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-26" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-58"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-77">txtNamePerson</Name>
<Style_X_Font id="ref-78">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-61"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-62"/>
<BindingItem0_X_DataMember id="ref-79">NamePerson</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>0</y>
<width>208</width>
<height>19</height>
</Bounds>
<Text id="ref-80">NamePerson</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-27" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-58"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-81">txtBemerkungRTF</Name>
<Style_X_Font id="ref-82">Arial, 10pt, style=Italic</Style_X_Font>
<Style_X_ForeColor href="#ref-61"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-62"/>
<BindingItem0_X_DataMember id="ref-83">BemerkungRTF</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>15</y>
<width>680</width>
<height>19</height>
</Bounds>
<Text id="ref-84">BemerkungRTF</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-31" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-85">DevExpress.XtraReports.UI.XRPanel</Type_X_TypeName>
<Visible>false</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-86">hiderPanel</Name>
<Style_X_Font id="ref-87">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>240</x>
<y>0</y>
<width>300</width>
<height>73</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<ItemCount>1</ItemCount>
<Item0 href="#ref-88"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-36" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-58"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-89">Label5</Name>
<Style_X_Font id="ref-90">Arial, 10pt, style=Bold, Underline</Style_X_Font>
<Style_X_ForeColor href="#ref-61"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<width>366</width>
<height>19</height>
</Bounds>
<Text id="ref-91">Vermögen und Vermögensverbrauch</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-37" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName id="ref-92">DevExpress.XtraReports.UI.XRLine</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-93">Line1</Name>
<Style_X_Font id="ref-94">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-61"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>7</x>
<y>47</y>
<width>686</width>
<height>3</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-38" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-58"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-95">Label3</Name>
<Style_X_Font id="ref-96">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-61"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<x>613</x>
<y>27</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-97">Verbrauch</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-39" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-58"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-98">Label2</Name>
<Style_X_Font id="ref-99">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-61"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>216</x>
<y>27</y>
<width>313</width>
<height>19</height>
</Bounds>
<Text id="ref-100">Art des Vermögens</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-40" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-58"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-101">Label1</Name>
<Style_X_Font id="ref-102">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-61"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>7</x>
<y>27</y>
<width>208</width>
<height>19</height>
</Bounds>
<Text id="ref-103">Betrifft</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-41" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-58"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-104">Label7</Name>
<Style_X_Font id="ref-105">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-61"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>533</x>
<y>27</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-106">Vermögen</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-45" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-92"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-107">Line7</Name>
<Style_X_Font id="ref-108">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-61"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>7</x>
<y>62</y>
<width>686</width>
<height>3</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-46" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-92"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-109">Line6</Name>
<Style_X_Font id="ref-110">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-61"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>7</x>
<y>43</y>
<width>680</width>
<height>4</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-47" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-58"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-111">txtSumVerbrauch</Name>
<Style_X_Font id="ref-112">Arial, 10pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-61"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName id="ref-113">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-114">Verbrauch</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>613</x>
<y>43</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-115">txtSumVerbrauch</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-116">{0:n2}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Group</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-48" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-58"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-117">txtFreibetrag</Name>
<Style_X_Font id="ref-118">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-61"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-62"/>
<BindingItem0_X_DataMember id="ref-119">Freibetrag</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-120">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>533</x>
<y>23</y>
<width>78</width>
<height>20</height>
</Bounds>
<Text id="ref-121">Freibetrag</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-122">{0:#,##0.00}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-49" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-58"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-123">Label9</Name>
<Style_X_Font id="ref-124">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-61"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<x>307</x>
<y>23</y>
<width>220</width>
<height>19</height>
</Bounds>
<Text id="ref-125">abzüglich Freibetrag</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-50" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-58"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-126">Label8</Name>
<Style_X_Font id="ref-127">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-61"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<x>307</x>
<y>3</y>
<width>220</width>
<height>19</height>
</Bounds>
<Text id="ref-128">Gesamtes Vermögen</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-51" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-92"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-129">Line5</Name>
<Style_X_Font id="ref-130">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-61"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>7</x>
<y>0</y>
<width>680</width>
<height>3</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-52" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-58"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-131">totBetragMINUSFreibetrag</Name>
<Style_X_Font id="ref-132">Arial, 10pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-61"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName id="ref-133">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-134">TotBetragMinusFreibetrag</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>533</x>
<y>43</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-135">totBetragMINUSFreibetrag</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-136">{0:n2}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Group</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-53" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-58"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-137">totBetrag</Name>
<Style_X_Font id="ref-138">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-61"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-62"/>
<BindingItem0_X_DataMember id="ref-139">Betrag</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-140">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>533</x>
<y>3</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-141">totBetrag</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-142">{0:#,##0.00}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Group</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-54" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-58"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-143">TextBox1</Name>
<Style_X_Font id="ref-144">Arial, 10pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-61"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<x>7</x>
<y>43</y>
<width>520</width>
<height>19</height>
</Bounds>
<Text id="ref-145">Angerechnetes Vermögen und Vermögensverbrauch</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-88" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-19"/>
<Type_X_TypeName href="#ref-58"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-146">hiderTxtBemerkungRTF</Name>
<Style_X_Font id="ref-147">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-148">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-149">BemerkungRTF</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>53</x>
<y>13</y>
<width>100</width>
<height>27</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<EventsScript_X_OnAfterPrint id="ref-150">private void OnAfterPrint(object sender, System.EventArgs e) {
   txtBemerkungRTF.Visible = hiderTxtBemerkungRTF.Text != String.Empty;
}</EventsScript_X_OnAfterPrint>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.9.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
</SOAP-ENV:Body>
</SOAP-ENV:Envelope>' ,  null ,  N'DECLARE @BgBudgetID int

SELECT @BgBudgetID = BgBudgetID
FROM BgBudget
WHERE BgFinanzplanID = {BgFinanzplanID} AND MasterBudget = 1

DECLARE @RefDate     datetime,
        @Freibetrag  money

SELECT @RefDate = dbo.fnDateSerial(Jahr, Monat, 1)
FROM BgBudget
WHERE BgBudgetID = @BgBudgetID

SELECT @Freibetrag = SUM(CASE WHEN dbo.fnGetAge(PRS.Geburtsdatum, @RefDate) >= 18
                           THEN CONVERT(money, dbo.fnXConfig(''System\Sozialhilfe\SKOS\E2\Erwachsene'' , @RefDate))
                           ELSE CONVERT(money, dbo.fnXConfig(''System\Sozialhilfe\SKOS\E2\Minderjährige'' , @RefDate))
                         END)
FROM BgBudget                       BBG
  INNER JOIN BgFinanzplan_BaPerson  SPP ON SPP.BgFinanzplanID = BBG.BgFinanzplanID
  INNER JOIN BaPerson               PRS ON PRS.BaPersonID = SPP.BaPersonID
WHERE BBG.BgBudgetID = @BgBudgetID AND SPP.IstUnterstuetzt = 1

IF (@Freibetrag > CONVERT(money, dbo.fnXConfig(''System\Sozialhilfe\SKOS\E2\Maximal'' , @RefDate)))
  SET @Freibetrag = CONVERT(money, dbo.fnXConfig(''System\Sozialhilfe\SKOS\E2\Maximal'' , @RefDate))

SELECT BPO.*,
  NamePerson     = PRS.Name + IsNull('', '' + PRS.Vorname, ''''),
  VermoegensTyp  = SPT.Name,
  Verbrauch      = PVV.Betrag,
  Freibetrag     = @Freibetrag,
  TotBetragMinusFreibetrag = BPO.Betrag-@Freibetrag
FROM BgPosition              BPO
  INNER JOIN WhPositionsart  SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
  LEFT  JOIN BaPerson        PRS ON PRS.BaPersonID = BPO.BaPersonID
  LEFT  JOIN BgPosition      PVV ON PVV.BgPositionID_Parent = BPO.BgPositionID
WHERE BPO.BgBudgetID = @BgBudgetID AND SPT.BgGruppeCode = 3104 AND SPT.BgKategorieCode = 5
  AND BPO.DatumVon IS NULL' ,  null ,  N'ShDetaillierterFinanzplanStandard' ,  null ,  1 );


