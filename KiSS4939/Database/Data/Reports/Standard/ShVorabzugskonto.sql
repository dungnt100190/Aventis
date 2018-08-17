-- Insert Script for ShVorabzugskonto
-- MD5:0X9FF7A71F6A5980D486890FB2DB4BA520_0XC4384DD799A92A099F3FAE5B5BEAB99D_0XEE0B052CAD2F9E54B6DD7DA91FB06564
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'ShVorabzugskonto') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('ShVorabzugskonto', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'ShVorabzugskonto';
--SQLCHECK_IGNORE--
UPDATE QRY
SET QueryName =  N'ShVorabzugskonto' , UserText =  N'SH - Spezialkonto' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
/// <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
/// <AssemblyLocation>C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
/// <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
/// <Localization>en-US</Localization>
/// <References>
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraReports.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraReports.v6.2.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraPrinting.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraPrinting.v6.2.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Drawing\2.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System\2.0.0.0__b77a5c561934e089\System.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Configuration\2.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Xml\2.0.0.0__b77a5c561934e089\System.Xml.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Data.SqlXml\2.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Security\2.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.Utils.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Utils.v6.2.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Windows.Forms\2.0.0.0__b77a5c561934e089\System.Windows.Forms.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\Accessibility\2.0.0.0__b03f5f7f11d50a3a\Accessibility.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Runtime.Serialization.Formatters.Soap\2.0.0.0__b03f5f7f11d50a3a\System.Runtime.Serialization.Formatters.Soap.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Deployment\2.0.0.0__b03f5f7f11d50a3a\System.Deployment.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Design\2.0.0.0__b03f5f7f11d50a3a\System.Design.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_32\System.Data\2.0.0.0__b77a5c561934e089\System.Data.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\Microsoft.VisualC\8.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualC.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_32\System.Transactions\2.0.0.0__b77a5c561934e089\System.Transactions.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_32\System.EnterpriseServices\2.0.0.0__b03f5f7f11d50a3a\System.EnterpriseServices.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.DirectoryServices\2.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Runtime.Remoting\2.0.0.0__b77a5c561934e089\System.Runtime.Remoting.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_32\System.Web\2.0.0.0__b03f5f7f11d50a3a\System.Web.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Web.Services\2.0.0.0__b03f5f7f11d50a3a\System.Web.Services.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.DirectoryServices.Protocols\2.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.Protocols.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.ServiceProcess\2.0.0.0__b03f5f7f11d50a3a\System.ServiceProcess.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Configuration.Install\2.0.0.0__b03f5f7f11d50a3a\System.Configuration.Install.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Web.RegularExpressions\2.0.0.0__b03f5f7f11d50a3a\System.Web.RegularExpressions.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Drawing.Design\2.0.0.0__b03f5f7f11d50a3a\System.Drawing.Design.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_32\System.Data.OracleClient\2.0.0.0__b77a5c561934e089\System.Data.OracleClient.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraEditors.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraEditors.v6.2.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.Data.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.Data.v6.2.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraBars.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraBars.v6.2.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraNavBar.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraNavBar.v6.2.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraCharts.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraCharts.v6.2.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraRichTextEdit.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraRichTextEdit.v6.2.dll" />
/// <Reference Path="C:\Projects\KiSS40\KiSS4.NET\KiSS4.Main\bin\Debug\KiSS4.DB.dll" />
/// <Reference Path="C:\Projects\KiSS40\KiSS4.NET\KiSS4.Main\bin\Debug\SharpLibrary.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
/// <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
/// </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel lblNameVorname;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel lblTitel;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        private DevExpress.XtraReports.UI.XRLabel txtText;
        private DevExpress.XtraReports.UI.XRLabel txtSaldo;
        private DevExpress.XtraReports.UI.XRLabel txtBelastung;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel txtMonatJahr;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLabel lblText;
        private DevExpress.XtraReports.UI.XRLabel lblSaldo;
        private DevExpress.XtraReports.UI.XRLabel lblBelastung;
        private DevExpress.XtraReports.UI.XRLabel lblGutschrift;
        private DevExpress.XtraReports.UI.XRLabel lblMonat;
        private DevExpress.XtraReports.UI.XRLabel lblNameKonto;
        private DevExpress.XtraReports.UI.XRLabel txtStartsaldo;
        private DevExpress.XtraReports.UI.XRLabel lblStartsaldo;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRLabel lblSeite;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel txtUnterschrift;
        private DevExpress.XtraReports.UI.XRLabel lblDatum;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel txtOrgPlzOrt;
        private DevExpress.XtraReports.UI.XRLabel txtOrgAdresse;
        private DevExpress.XtraReports.UI.XRLabel txtOrgName;
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
                        "AAAAf8VREVDTEFSRSBARmFMZWlzdHVuZ0lEICAgICAgICBpbnQsDQogICAgICAgIEBCZ1NwZXprb250b" +
                        "1R5cENvZGUgIGludCwNCiAgICAgICAgQERhdGVGcm9tICAgICAgICAgICAgZGF0ZXRpbWUsDQogICAgI" +
                        "CAgIEBEYXRlVG8gICAgICAgICAgICAgIGRhdGV0aW1lDQoNClNFVCBAQmdTcGV6a29udG9UeXBDb2RlI" +
                        "D0gbnVsbA0KU0VUIEBGYUxlaXN0dW5nSUQgPSBudWxsDQpTRVQgQERhdGVGcm9tID0gSVNOVUxMKG51b" +
                        "GwsICcwMS4wMS4xOTAwJykNClNFVCBARGF0ZVRvID0gSVNOVUxMKG51bGwsIEdldERhdGUoKSkNCg0KR" +
                        "EVDTEFSRSBAQmdQb3NpdGlvbiBUQUJMRSAoDQogIEJnUG9zaXRpb25JRCAgIGludCwNCiAgQmdTcGV6a" +
                        "29udG9JRCAgaW50LA0KICBKYWhyICAgICAgICAgICBpbnQsDQogIE1vbmF0ICAgICAgICAgIGludCwNC" +
                        "iAgTW9uYXRUZXh0ICAgICAgdmFyY2hhcig1MCksDQogIEd1dHNjaHJpZnQgICAgIG1vbmV5LA0KICBCZ" +
                        "Wxhc3R1bmcgICAgICBtb25leSwNCiAgQnVjaHVuZ3N0ZXh0ICAgdmFyY2hhcigxMDApLA0KICBTYWxkb" +
                        "yAgICAgICAgICBtb25leQ0KKQ0KDQpJTlNFUlQgSU5UTyBAQmdQb3NpdGlvbg0KICBTRUxFQ1QgQlBPL" +
                        "kJnUG9zaXRpb25JRCwgQlBPLkJnU3BlemtvbnRvSUQsDQogICAgQkJHLkphaHIsIEJCRy5Nb25hdCwgT" +
                        "W9uYXRUZXh0ID0gZGJvLmZuWEt1cnpNb25hdChCQkcuTW9uYXQpICsgJyAnICsgY29udmVydCh2YXJja" +
                        "GFyLCBCQkcuSmFociksDQogICAgR3V0c2NocmlmdCA9IENBU0UgV0hFTiBCUE8uQmdLYXRlZ29yaWVDb" +
                        "2RlID0gMTAxIFRIRU4gJDAuMDAgRUxTRSBCUE8uQmV0cmFnQnVkZ2V0IEVORCwNCiAgICBCZWxhc3R1b" +
                        "mcgID0gQ0FTRSBXSEVOIEJQTy5CZ0thdGVnb3JpZUNvZGUgPSAxMDEgVEhFTiBCUE8uQmV0cmFnQnVkZ" +
                        "2V0IEVMU0UgJDAuMDAgRU5ELA0KICAgIEJQTy5CdWNodW5nc3RleHQsDQogICAgU2FsZG8gPSBkYm8uZ" +
                        "m5CZ1NwZXprb250byhCUE8uQmdTcGV6a29udG9JRCwgMywgQkJHLkJnQnVkZ2V0SUQsIGRlZmF1bHQpD" +
                        "QogIEZST00gQmdTcGV6a29udG8gICAgICAgICAgIEJTSw0KICAgIElOTkVSIEpPSU4gQmdGaW5hbnpwb" +
                        "GFuICBCRlAgT04gQkZQLkZhTGVpc3R1bmdJRCA9IEJTSy5GYUxlaXN0dW5nSUQNCiAgICBJTk5FUiBKT" +
                        "0lOIEJnQnVkZ2V0ICAgICAgQkJHIE9OIEJCRy5CZ0ZpbmFuenBsYW5JRCA9IEJGUC5CZ0ZpbmFuenBsY" +
                        "W5JRCBBTkQgQkJHLk1hc3RlckJ1ZGdldCA9IDANCiAgICBJTk5FUiBKT0lOIHZ3QmdQb3NpdGlvbiAgQ" +
                        "lBPIE9OIEJQTy5CZ0J1ZGdldElEID0gQkJHLkJnQnVkZ2V0SUQgQU5EIEJQTy5CZ1NwZXprb250b0lEI" +
                        "D0gQlNLLkJnU3BlemtvbnRvSUQNCiAgV0hFUkUgQlNLLkZhTGVpc3R1bmdJRCA9IEBGYUxlaXN0dW5nS" +
                        "UQgQU5EIEJTSy5CZ1NwZXprb250b1R5cENvZGUgPSBAQmdTcGV6a29udG9UeXBDb2RlDQogICAgQU5EI" +
                        "EJCRy5CZ0Jld2lsbGlndW5nU3RhdHVzQ29kZSA9IDUNCg0KREVMRVRFIEZST00gQEJnUG9zaXRpb24gV" +
                        "0hFUkUgR3V0c2NocmlmdCA9ICQwLjAwIEFORCBCZWxhc3R1bmcgPSAkMC4wMA0KDQpTRUxFQ1QNCiAgT" +
                        "3JnX05hbWUgICAgPSBJc051bGwoQ09OVkVSVCh2YXJjaGFyKDEwMDApLCBkYm8uZm5YQ29uZmlnKCdTe" +
                        "XN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxPcmdhbmlzYXRpb24nLCBHZXREYXRlKCkpKSwgJycpLA0KI" +
                        "CBPcmdfQWRyZXNzZSA9IElzTnVsbChDT05WRVJUKHZhcmNoYXIoMTAwMCksIGRiby5mblhDb25maWcoJ" +
                        "1N5c3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlXEFkcmVzc2UnLCBHZXREYXRlKCkpKSwgJycpLA0KICBPc" +
                        "mdfUExaICAgICA9IElzTnVsbChDT05WRVJUKHZhcmNoYXIoMTAwMCksIGRiby5mblhDb25maWcoJ1N5c" +
                        "3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlXFBMWicsIEdldERhdGUoKSkpLCAnJyksDQogIE9yZ19PcnQgI" +
                        "CAgID0gSXNOdWxsKENPTlZFUlQodmFyY2hhcigxMDAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkc" +
                        "mVzc2VcU296aWFsaGlsZmVcT3J0JywgR2V0RGF0ZSgpKSksICcnKSwNCiAgT3JnX1BMWk9ydCAgPSBJc" +
                        "051bGwoQ09OVkVSVCh2YXJjaGFyKDEwMDApLCBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb" +
                        "3ppYWxoaWxmZVxQTFonLCBHZXREYXRlKCkpKSArICcgJywgJycpDQogICAgICAgICAgICAgICsgSXNOd" +
                        "WxsKENPTlZFUlQodmFyY2hhcigxMDAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc2VcU296a" +
                        "WFsaGlsZmVcT3J0JywgR2V0RGF0ZSgpKSksICcnKSwNCg0KICBQUlMuTmFtZVZvcm5hbWUsDQoNCiAgQ" +
                        "lNLLkJnU3BlemtvbnRvSUQsDQogIFNwZXprb250b1R5cCAgPSBkYm8uZm5MT1ZUZXh0KCdCZ1NwZXprb" +
                        "250b1R5cCcsIEJTSy5CZ1NwZXprb250b1R5cENvZGUpLA0KICBCU0suTmFtZVNwZXprb250bywNCiAgQ" +
                        "lNLLlN0YXJ0U2FsZG8sDQoNCiAgQlBPLioNCkZST00gRmFMZWlzdHVuZyAgICAgICAgICAgIEZMRQ0KI" +
                        "CBJTk5FUiBKT0lOIHZ3UGVyc29uICAgICAgUFJTIE9OIFBSUy5CYVBlcnNvbklEID0gRkxFLkJhUGVyc" +
                        "29uSUQNCiAgSU5ORVIgSk9JTiBCZ1NwZXprb250byAgIEJTSyBPTiBCU0suRmFMZWlzdHVuZ0lEID0gR" +
                        "kxFLkZhTGVpc3R1bmdJRA0KICBMRUZUICBKT0lOIEBCZ1Bvc2l0aW9uICAgQlBPIE9OIEJQTy5CZ1NwZ" +
                        "Xprb250b0lEID0gQlNLLkJnU3BlemtvbnRvSUQNCldIRVJFIEZMRS5GYUxlaXN0dW5nSUQgPSBARmFMZ" +
                        "WlzdHVuZ0lEIEFORCBCU0suQmdTcGV6a29udG9UeXBDb2RlID0gQEJnU3BlemtvbnRvVHlwQ29kZQ0KT" +
                        "1JERVIgQlkgQlNLLkRhdHVtVm9uLCBCU0suQmdTcGV6a29udG9JRCwgQlBPLkphaHIsIEJQTy5Nb25hd" +
                        "A==";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.lblNameVorname = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTitel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.txtText = new DevExpress.XtraReports.UI.XRLabel();
            this.txtSaldo = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBelastung = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtMonatJahr = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.lblText = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSaldo = new DevExpress.XtraReports.UI.XRLabel();
            this.lblBelastung = new DevExpress.XtraReports.UI.XRLabel();
            this.lblGutschrift = new DevExpress.XtraReports.UI.XRLabel();
            this.lblMonat = new DevExpress.XtraReports.UI.XRLabel();
            this.lblNameKonto = new DevExpress.XtraReports.UI.XRLabel();
            this.txtStartsaldo = new DevExpress.XtraReports.UI.XRLabel();
            this.lblStartsaldo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.lblSeite = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.txtUnterschrift = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDatum = new DevExpress.XtraReports.UI.XRLabel();
            this.txtOrgPlzOrt = new DevExpress.XtraReports.UI.XRLabel();
            this.txtOrgAdresse = new DevExpress.XtraReports.UI.XRLabel();
            this.txtOrgName = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblNameVorname,
                        this.lblTitel});
            this.PageHeader.Dpi = 254F;
            this.PageHeader.Height = 90;
            this.PageHeader.Name = "PageHeader";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLine3,
                        this.txtText,
                        this.txtSaldo,
                        this.txtBelastung,
                        this.xrLabel7,
                        this.txtMonatJahr});
            this.Detail.Dpi = 254F;
            this.Detail.Height = 53;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBorders = false;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLine2,
                        this.lblText,
                        this.lblSaldo,
                        this.lblBelastung,
                        this.lblGutschrift,
                        this.lblMonat,
                        this.lblNameKonto,
                        this.txtStartsaldo,
                        this.lblStartsaldo});
            this.GroupHeader1.Dpi = 254F;
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("NameSpezkonto", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 212;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.RepeatEveryPage = true;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageInfo2,
                        this.lblSeite,
                        this.xrPageInfo1});
            this.PageFooter.Dpi = 254F;
            this.PageFooter.Height = 59;
            this.PageFooter.Name = "PageFooter";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtUnterschrift,
                        this.lblDatum});
            this.GroupFooter1.Dpi = 254F;
            this.GroupFooter1.Height = 150;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtOrgPlzOrt,
                        this.txtOrgAdresse,
                        this.txtOrgName});
            this.ReportHeader.Dpi = 254F;
            this.ReportHeader.Height = 124;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // lblNameVorname
            // 
            this.lblNameVorname.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameVorname", "")});
            this.lblNameVorname.Dpi = 254F;
            this.lblNameVorname.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblNameVorname.Location = new System.Drawing.Point(995, 21);
            this.lblNameVorname.Name = "lblNameVorname";
            this.lblNameVorname.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblNameVorname.ParentStyleUsing.UseFont = false;
            this.lblNameVorname.Size = new System.Drawing.Size(849, 50);
            this.lblNameVorname.Text = "lblNameVorname";
            this.lblNameVorname.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblTitel
            // 
            this.lblTitel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SpezKontoTyp", "")});
            this.lblTitel.Dpi = 254F;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitel.Location = new System.Drawing.Point(21, 21);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblTitel.ParentStyleUsing.UseFont = false;
            this.lblTitel.Size = new System.Drawing.Size(974, 64);
            this.lblTitel.Text = "lblTitel";
            // 
            // xrLine3
            // 
            this.xrLine3.Dpi = 254F;
            this.xrLine3.LineWidth = 3;
            this.xrLine3.Location = new System.Drawing.Point(21, 32);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.Size = new System.Drawing.Size(1821, 21);
            // 
            // txtText
            // 
            this.txtText.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Buchungstext", "")});
            this.txtText.Dpi = 254F;
            this.txtText.Font = new System.Drawing.Font("Arial", 8F);
            this.txtText.Location = new System.Drawing.Point(868, 0);
            this.txtText.Name = "txtText";
            this.txtText.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtText.ParentStyleUsing.UseBorders = false;
            this.txtText.ParentStyleUsing.UseFont = false;
            this.txtText.Size = new System.Drawing.Size(974, 37);
            this.txtText.Text = "txtText";
            // 
            // txtSaldo
            // 
            this.txtSaldo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Saldo", "{0:n2}")});
            this.txtSaldo.Dpi = 254F;
            this.txtSaldo.Font = new System.Drawing.Font("Arial", 8F);
            this.txtSaldo.Location = new System.Drawing.Point(678, 0);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtSaldo.ParentStyleUsing.UseBorders = false;
            this.txtSaldo.ParentStyleUsing.UseFont = false;
            this.txtSaldo.Size = new System.Drawing.Size(178, 38);
            this.txtSaldo.Text = "txtSaldo";
            this.txtSaldo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtBelastung
            // 
            this.txtBelastung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Belastung", "{0:n2}")});
            this.txtBelastung.Dpi = 254F;
            this.txtBelastung.Font = new System.Drawing.Font("Arial", 8F);
            this.txtBelastung.Location = new System.Drawing.Point(488, 0);
            this.txtBelastung.Name = "txtBelastung";
            this.txtBelastung.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtBelastung.ParentStyleUsing.UseBorders = false;
            this.txtBelastung.ParentStyleUsing.UseFont = false;
            this.txtBelastung.Size = new System.Drawing.Size(177, 38);
            this.txtBelastung.Text = "txtBelastung";
            this.txtBelastung.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Gutschrift", "{0:n2}")});
            this.xrLabel7.Dpi = 254F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel7.Location = new System.Drawing.Point(297, 0);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel7.ParentStyleUsing.UseBorders = false;
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.Size = new System.Drawing.Size(178, 38);
            this.xrLabel7.Text = "xrLabel7";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtMonatJahr
            // 
            this.txtMonatJahr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "MonatText", "")});
            this.txtMonatJahr.Dpi = 254F;
            this.txtMonatJahr.Font = new System.Drawing.Font("Arial", 8F);
            this.txtMonatJahr.Location = new System.Drawing.Point(20, 0);
            this.txtMonatJahr.Name = "txtMonatJahr";
            this.txtMonatJahr.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtMonatJahr.ParentStyleUsing.UseBorders = false;
            this.txtMonatJahr.ParentStyleUsing.UseFont = false;
            this.txtMonatJahr.Size = new System.Drawing.Size(254, 38);
            this.txtMonatJahr.Text = "txtMonatJahr";
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 254F;
            this.xrLine2.LineWidth = 5;
            this.xrLine2.Location = new System.Drawing.Point(21, 190);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.Size = new System.Drawing.Size(1821, 22);
            // 
            // lblText
            // 
            this.lblText.Dpi = 254F;
            this.lblText.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblText.Location = new System.Drawing.Point(869, 147);
            this.lblText.Name = "lblText";
            this.lblText.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblText.ParentStyleUsing.UseFont = false;
            this.lblText.Size = new System.Drawing.Size(254, 51);
            this.lblText.Text = "Buchungstext";
            // 
            // lblSaldo
            // 
            this.lblSaldo.Dpi = 254F;
            this.lblSaldo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblSaldo.Location = new System.Drawing.Point(698, 148);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblSaldo.ParentStyleUsing.UseFont = false;
            this.lblSaldo.Size = new System.Drawing.Size(158, 51);
            this.lblSaldo.Text = "Saldo";
            this.lblSaldo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblBelastung
            // 
            this.lblBelastung.Dpi = 254F;
            this.lblBelastung.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblBelastung.Location = new System.Drawing.Point(488, 147);
            this.lblBelastung.Name = "lblBelastung";
            this.lblBelastung.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblBelastung.ParentStyleUsing.UseFont = false;
            this.lblBelastung.Size = new System.Drawing.Size(177, 51);
            this.lblBelastung.Text = "Belastung";
            this.lblBelastung.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblGutschrift
            // 
            this.lblGutschrift.Dpi = 254F;
            this.lblGutschrift.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblGutschrift.Location = new System.Drawing.Point(297, 147);
            this.lblGutschrift.Name = "lblGutschrift";
            this.lblGutschrift.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblGutschrift.ParentStyleUsing.UseFont = false;
            this.lblGutschrift.Size = new System.Drawing.Size(181, 51);
            this.lblGutschrift.Text = "Gutschrift";
            this.lblGutschrift.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblMonat
            // 
            this.lblMonat.Dpi = 254F;
            this.lblMonat.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblMonat.Location = new System.Drawing.Point(20, 147);
            this.lblMonat.Name = "lblMonat";
            this.lblMonat.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblMonat.ParentStyleUsing.UseFont = false;
            this.lblMonat.Size = new System.Drawing.Size(254, 51);
            this.lblMonat.Text = "Monat";
            // 
            // lblNameKonto
            // 
            this.lblNameKonto.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameSpezkonto", "")});
            this.lblNameKonto.Dpi = 254F;
            this.lblNameKonto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblNameKonto.Location = new System.Drawing.Point(20, 20);
            this.lblNameKonto.Name = "lblNameKonto";
            this.lblNameKonto.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblNameKonto.ParentStyleUsing.UseFont = false;
            this.lblNameKonto.Size = new System.Drawing.Size(1631, 51);
            this.lblNameKonto.Text = "lblNameKonto";
            // 
            // txtStartsaldo
            // 
            this.txtStartsaldo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "StartSaldo", "{0:c2}")});
            this.txtStartsaldo.Dpi = 254F;
            this.txtStartsaldo.Font = new System.Drawing.Font("Arial", 9F);
            this.txtStartsaldo.Location = new System.Drawing.Point(234, 64);
            this.txtStartsaldo.Name = "txtStartsaldo";
            this.txtStartsaldo.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtStartsaldo.ParentStyleUsing.UseFont = false;
            this.txtStartsaldo.Size = new System.Drawing.Size(718, 50);
            this.txtStartsaldo.Text = "txtStartsaldo";
            // 
            // lblStartsaldo
            // 
            this.lblStartsaldo.Dpi = 254F;
            this.lblStartsaldo.Font = new System.Drawing.Font("Arial", 9F);
            this.lblStartsaldo.Location = new System.Drawing.Point(20, 64);
            this.lblStartsaldo.Name = "lblStartsaldo";
            this.lblStartsaldo.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblStartsaldo.ParentStyleUsing.UseFont = false;
            this.lblStartsaldo.Size = new System.Drawing.Size(211, 50);
            this.lblStartsaldo.Text = "Startsaldo = ";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 254F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 8F);
            this.xrPageInfo2.Format = "{0:dd.MMMM.yyyy}";
            this.xrPageInfo2.Location = new System.Drawing.Point(20, 20);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            this.xrPageInfo2.Size = new System.Drawing.Size(404, 38);
            // 
            // lblSeite
            // 
            this.lblSeite.Dpi = 254F;
            this.lblSeite.Font = new System.Drawing.Font("Arial", 8F);
            this.lblSeite.Location = new System.Drawing.Point(1566, 21);
            this.lblSeite.Name = "lblSeite";
            this.lblSeite.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblSeite.ParentStyleUsing.UseFont = false;
            this.lblSeite.Size = new System.Drawing.Size(170, 38);
            this.lblSeite.Text = "Seite";
            this.lblSeite.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 254F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8F);
            this.xrPageInfo1.Location = new System.Drawing.Point(1736, 21);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(107, 38);
            // 
            // txtUnterschrift
            // 
            this.txtUnterschrift.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameVorname", "eingesehen von {0} ________________________________")});
            this.txtUnterschrift.Dpi = 254F;
            this.txtUnterschrift.Font = new System.Drawing.Font("Arial", 8F);
            this.txtUnterschrift.Location = new System.Drawing.Point(423, 42);
            this.txtUnterschrift.Name = "txtUnterschrift";
            this.txtUnterschrift.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtUnterschrift.ParentStyleUsing.UseFont = false;
            this.txtUnterschrift.Size = new System.Drawing.Size(1419, 64);
            this.txtUnterschrift.Text = "xrLabel4";
            // 
            // lblDatum
            // 
            this.lblDatum.Dpi = 254F;
            this.lblDatum.Font = new System.Drawing.Font("Arial", 8F);
            this.lblDatum.Location = new System.Drawing.Point(20, 43);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblDatum.ParentStyleUsing.UseFont = false;
            this.lblDatum.Size = new System.Drawing.Size(381, 64);
            this.lblDatum.Text = "Datum _______________";
            // 
            // txtOrgPlzOrt
            // 
            this.txtOrgPlzOrt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_PLZOrt", "")});
            this.txtOrgPlzOrt.Dpi = 254F;
            this.txtOrgPlzOrt.Font = new System.Drawing.Font("Arial", 9F);
            this.txtOrgPlzOrt.Location = new System.Drawing.Point(1143, 42);
            this.txtOrgPlzOrt.Name = "txtOrgPlzOrt";
            this.txtOrgPlzOrt.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtOrgPlzOrt.ParentStyleUsing.UseFont = false;
            this.txtOrgPlzOrt.Size = new System.Drawing.Size(677, 43);
            this.txtOrgPlzOrt.Text = "txtOrgPlzOrt";
            // 
            // txtOrgAdresse
            // 
            this.txtOrgAdresse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Adresse", "")});
            this.txtOrgAdresse.Dpi = 254F;
            this.txtOrgAdresse.Font = new System.Drawing.Font("Arial", 9F);
            this.txtOrgAdresse.Location = new System.Drawing.Point(1143, 0);
            this.txtOrgAdresse.Name = "txtOrgAdresse";
            this.txtOrgAdresse.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtOrgAdresse.ParentStyleUsing.UseFont = false;
            this.txtOrgAdresse.Size = new System.Drawing.Size(677, 42);
            this.txtOrgAdresse.Text = "txtOrgAdresse";
            // 
            // txtOrgName
            // 
            this.txtOrgName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Name", "")});
            this.txtOrgName.Dpi = 254F;
            this.txtOrgName.Font = new System.Drawing.Font("Arial", 9F);
            this.txtOrgName.Location = new System.Drawing.Point(21, 0);
            this.txtOrgName.Name = "txtOrgName";
            this.txtOrgName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtOrgName.ParentStyleUsing.UseFont = false;
            this.txtOrgName.Size = new System.Drawing.Size(1101, 42);
            this.txtOrgName.Text = "txtOrgName";
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.PageHeader,
                        this.Detail,
                        this.GroupHeader1,
                        this.PageFooter,
                        this.GroupFooter1,
                        this.ReportHeader});
            this.DataSource = this.sqlQuery1;
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(140, 95, 203, 102);
            this.Name = "Report";
            this.PageHeight = 2969;
            this.PageWidth = 2101;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' , ParameterXML =  N'<?xml version="1.0" standalone="yes" ?>
<NewDataSet>
    <Table>
        <FieldName>label</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Fall ID:</DisplayText>
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
        <FieldName>FaLeistungID</FieldName>
        <FieldCode>4</FieldCode>
        <DisplayText>Fall ID</DisplayText>
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
        <Table>
        <FieldName>label</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Spezkonto Typ:</DisplayText>
        <TabPosition>2</TabPosition>
        <X>10</X>
        <Y>90</Y>
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
        <FieldName>BgSpezkontoTypCode</FieldName>
        <FieldCode>8</FieldCode>
        <DisplayText>Spezkonto Typ</DisplayText>
        <TabPosition>3</TabPosition>
        <X>120</X>
        <Y>90</Y>
        <Width>200</Width>
        <Height>25</Height>
        <Length>7</Length>
        <LOVName>BgSpezkontoTyp</LOVName>
        <DefaultValue></DefaultValue>
        <Mandatory>true</Mandatory>
        <TabName></TabName>
        <AppCode></AppCode>
    </Table>

    <Table>
        <FieldName>NurAktive</FieldName>
        <FieldCode>7</FieldCode>
        <DisplayText>Nur Aktive</DisplayText>
        <TabPosition>4</TabPosition>
        <X>120</X>
        <Y>120</Y>
        <Width>80</Width>
        <Height>25</Height>
        <Length>7</Length>
        <LOVName>BgSpezkontoTyp</LOVName>
        <DefaultValue></DefaultValue>
        <Mandatory>true</Mandatory>
        <TabName></TabName>
        <AppCode></AppCode>
    </Table>

    <Table>
        <FieldName>label</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>von Datum:</DisplayText>
        <TabPosition>5</TabPosition>
        <X>10</X>
        <Y>150</Y>
        <Width>100</Width>
        <Height>25</Height>
        <Length>7</Length>
        <LOVName></LOVName>
        <DefaultValue></DefaultValue>
        <Mandatory>false</Mandatory>
        <TabName></TabName>
        <AppCode></AppCode>
    </Table>
    <Table>	
        <FieldName>DateFrom</FieldName>
        <FieldCode>5</FieldCode>
        <DisplayText>von Datum</DisplayText>
        <TabPosition>6</TabPosition>
        <X>120</X>
        <Y>150</Y>
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
        <FieldName>label</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>bis Datum:</DisplayText>
        <TabPosition>7</TabPosition>
        <X>10</X>
        <Y>180</Y>
        <Width>100</Width>
        <Height>25</Height>
        <Length>7</Length>
        <LOVName></LOVName>
        <DefaultValue></DefaultValue>
        <Mandatory>false</Mandatory>
        <TabName></TabName>
        <AppCode></AppCode>
    </Table>
    <Table>	
        <FieldName>DateTo</FieldName>
        <FieldCode>5</FieldCode>
        <DisplayText>bis Datum</DisplayText>
        <TabPosition>8</TabPosition>
        <X>120</X>
        <Y>180</Y>
        <Width>80</Width>
        <Height>25</Height>
        <Length>7</Length>
        <LOVName></LOVName>
        <DefaultValue></DefaultValue>
        <Mandatory>false</Mandatory>
        <TabName></TabName>
        <AppCode></AppCode>
    </Table>	
</NewDataSet>' , SQLquery =  N'DECLARE @BgSpezkontoTypCode int
DECLARE @FaLeistungID int
DECLARE @DateFrom datetime
DECLARE @DateTo datetime
DECLARE @NurAktive bit

SET @BgSpezkontoTypCode = {BgSpezkontoTypCode}
SET @FaLeistungID = {FaLeistungID}
SET @DateFrom = ISNULL({DateFrom}, ''01.01.1900'')
SET @DateTo = ISNULL({DateTo}, GetDate())
SET @NurAktive = {NurAktive}

DECLARE @BgPosition TABLE (
  BgPositionID int,
  BgSpezkontoID int,
  Jahr int,
  Monat int,
  MonatText varchar(50),
  Gutschrift money,
  Belastung money,
  Buchungstext varchar(100),
  Saldo money
)

INSERT INTO @BgPosition
  SELECT BPO.BgPositionID, BPO.BgSpezkontoID,
    BBG.Jahr, BBG.Monat, MonatText = dbo.fnXKurzMonat(BBG.Monat) + '' '' + convert(varchar, BBG.Jahr),
    Gutschrift = CASE WHEN BPO.BgKategorieCode = 101 THEN $0.00 ELSE BPO.BetragBudget END,
    Belastung = CASE WHEN BPO.BgKategorieCode = 101 THEN BPO.BetragBudget ELSE $0.00 END,
    BPO.Buchungstext,
    Saldo = dbo.fnBgSpezkonto(BPO.BgSpezkontoID, 3, BBG.BgBudgetID, default)
  FROM BgSpezkonto BSK
    INNER JOIN BgFinanzplan BFP ON BFP.FaLeistungID = BSK.FaLeistungID
    INNER JOIN BgBudget BBG ON BBG.BgFinanzplanID = BFP.BgFinanzplanID AND BBG.MasterBudget = 0
    INNER JOIN vwBgPosition BPO ON BPO.BgBudgetID = BBG.BgBudgetID AND BPO.BgSpezkontoID = BSK.BgSpezkontoID
  WHERE BSK.FaLeistungID = @FaLeistungID AND BSK.BgSpezkontoTypCode = @BgSpezkontoTypCode
    AND BBG.BgBewilligungStatusCode = 5
UNION ALL 
    SELECT 
    NULL,
    BgSpezkontoID,
    YEAR(Created),
    MONTH(Created),
    MonatText = dbo.fnXKurzMonat(MONTH(Created)) + '' '' + convert(varchar, YEAR(Created)),
    Gutschrift = Betrag,
    Belastung = 0,
    Buchungstext = [Text], 
    Saldo = NULL
    FROM dbo.BgSpezkontoAbschluss WITH (READUNCOMMITTED)
WHERE BgSpezkontoID in (SELECT BSK.BgSpezkontoID 
							FROM BgSpezkonto BSK
							INNER JOIN BgFinanzplan BFP ON BFP.FaLeistungID = BSK.FaLeistungID
							INNER JOIN BgBudget BBG ON BBG.BgFinanzplanID = BFP.BgFinanzplanID AND BBG.MasterBudget = 0
							INNER JOIN vwBgPosition BPO ON BPO.BgBudgetID = BBG.BgBudgetID AND BPO.BgSpezkontoID = BSK.BgSpezkontoID
						  WHERE BSK.FaLeistungID = @FaLeistungID AND BSK.BgSpezkontoTypCode = @BgSpezkontoTypCode
							AND BBG.BgBewilligungStatusCode = 5) 
    
  
DELETE FROM @BgPosition
WHERE (Gutschrift = $0.00 AND Belastung = $0.00)
  OR NOT dbo.fnDateSerial(Jahr, Monat, 1) BETWEEN @DateFrom AND @DateTo

SELECT
  Org_Name = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Organisation'', GetDate())), ''''),
  Org_Adresse = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Adresse'', GetDate())), ''''),
  Org_PLZ = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', GetDate())), ''''),
  Org_Ort = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', GetDate())), ''''),
  Org_PLZOrt = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', GetDate())) + '' '', '''')
              + IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', GetDate())), ''''),

  PRS.NameVorname,

  BSK.BgSpezkontoID,
  SpezkontoTyp = dbo.fnLOVText(''BgSpezkontoTyp'', BSK.BgSpezkontoTypCode),
  BSK.NameSpezkonto,
  BSK.StartSaldo,

  BPO.*
FROM FaLeistung FLE
  INNER JOIN vwPerson PRS ON PRS.BaPersonID = FLE.BaPersonID
  INNER JOIN BgSpezkonto BSK ON BSK.FaLeistungID = FLE.FaLeistungID
  LEFT JOIN @BgPosition BPO ON BPO.BgSpezkontoID = BSK.BgSpezkontoID
WHERE FLE.FaLeistungID = @FaLeistungID AND BSK.BgSpezkontoTypCode = @BgSpezkontoTypCode
  AND BSK.DatumVon < @DateTo
  AND (BSK.DatumBis IS NULL OR BSK.DatumBis > @DateFrom)
  AND (@NurAktive = 0 OR isNull(BSK.DatumBis,getdate()) >= getdate())
ORDER BY BSK.DatumVon, BSK.BgSpezkontoID, BPO.Jahr, BPO.Monat' , ContextForms =  N'CtlWhSpezialkonto' , ParentReportName =  null , ReportSortKey =  null , System =  0 
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'ShVorabzugskonto' ;


