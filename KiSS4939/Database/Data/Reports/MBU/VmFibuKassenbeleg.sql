-- Insert Script for VmFibuKassenbeleg
-- MD5:0X6CB5F12534D14CF2CDF586D860165EEA_0X3D5994CFA3DC34A08E51DE33473E61A7_0XE6B97A863E2F8142A0A46570B22A60B5
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'VmFibuKassenbeleg') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('VmFibuKassenbeleg', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'VmFibuKassenbeleg';
UPDATE QRY
SET QueryName =  N'VmFibuKassenbeleg' , UserText =  N'VM - Kassenbeleg' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS4\Build\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\Projects\KiSS4\Build\Debug\log4net.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Projects\KiSS4\Build\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel28;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel27;
        private DevExpress.XtraReports.UI.XRLabel xrLabel26;
        private DevExpress.XtraReports.UI.XRLabel xrLabel25;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel30;
        private DevExpress.XtraReports.UI.XRLabel xrLabel29;
        private DevExpress.XtraReports.UI.XRLabel xrLabel24;
        private DevExpress.XtraReports.UI.XRLabel xrLabel23;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRLabel lblBelegNr;
        private DevExpress.XtraReports.UI.XRLabel lblTitel;
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
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kA" +
                        "AAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAA" +
                        "AAAAZMYREVDTEFSRSBARmJCdWNodW5nSUQgaW50LCBAQXVmdHJhZ0lEIGludCwgQEJhUGVyc29uSUQga" +
                        "W50LCBAU3RpY2h0YWcgZGF0ZXRpbWUNClNFVCBARmJCdWNodW5nSUQgPSBudWxsDQpTRVQgQEF1ZnRyY" +
                        "WdJRCA9IG51bGwNClNFVCBAQmFQZXJzb25JRCA9IG51bGwNClNFVCBAU3RpY2h0YWcgPSBudWxsDQoNC" +
                        "kRFQ0xBUkUgQEFuVm9ybmFtZU5hY2huYW1lIHZhcmNoYXIoNTApLAlAQW5TdHJhc3NlIHZhcmNoYXIoM" +
                        "jUpLAlAQW5QTFogdmFyY2hhcig4KSwNCglAQW5PcnQgdmFyY2hhcigyNSksCUBFcmhhbHRlbkFtIGRhd" +
                        "GV0aW1lLAlAQmV0cmFnIG1vbmV5LAlAQmVsZWdOciB2YXJjaGFyKDI1KSwNCglAQXVzYmV6RHVyY2ggd" +
                        "mFyY2hhcig1MCksCUBNYW5kYXRzdHJhZWdlciB2YXJjaGFyKDUwKSwJQEJld2lsbGlndER1cmNoIHZhc" +
                        "mNoYXIoNTApLA0KCUBTb2xsS3RvIHZhcmNoYXIoNTApLCBATWFuZGFudE5hbWUgdmFyY2hhcig1MCksI" +
                        "EBNYW5kYW50QWRyZXNzZU1laHJ6ZWlsaWcgdmFyY2hhcig4MCksDQogICAgICAgIEBKb3VybmFsYWJsY" +
                        "Wdlb3J0IHZhcmNoYXIoMjUpLCBAQnVjaHVuZ3N0ZXh0IHZhcmNoYXIoMjAwKQ0KDQpTRUxFQ1QNCiAgQ" +
                        "EJlbGVnTnIgPSBGQkIuQmVsZWdOciwNCiAgQEVyaGFsdGVuQW0gPSBGQkIuQnVjaHVuZ3NEYXR1bSwNC" +
                        "iAgQEJldHJhZyA9IEZCQi5CZXRyYWcsDQogIEBBblZvcm5hbWVOYWNobmFtZSA9IEZCQi5OYW1lLA0KI" +
                        "CBAQW5TdHJhc3NlID0gRkJCLlN0cmFzc2UsDQogIEBBblBMWiA9IEZCQi5QTFosDQogIEBBbk9ydCA9I" +
                        "EZCQi5PcnQsDQogIEBBdXNiZXpEdXJjaCA9IGRiby5mbkdldExhc3RGaXJzdE5hbWUoRkJCLlVzZXJJR" +
                        "CwgTlVMTCwgTlVMTCksDQogIEBTb2xsS3RvID0gQ09OVkVSVCh2YXJjaGFyLCBGQkIuU29sbEt0b05yK" +
                        "SArICcgJyArIEtUTy5Lb250b05hbWUsDQogIEBKb3VybmFsYWJsYWdlb3J0ID0gTE9WLlRleHQsDQogI" +
                        "EBCdWNodW5nc3RleHQgPSBGQkIuVGV4dA0KRlJPTSBGYkJ1Y2h1bmcgRkJCDQogIElOTkVSIEpPSU4gR" +
                        "mJLb250byBLVE8gV0lUSCAoUkVBRFVOQ09NTUlUVEVEKSBPTiBLVE8uS29udG9OciA9IEZCQi5Tb2xsS" +
                        "3RvTnIgQU5EIEtUTy5GYlBlcmlvZGVJRCA9IEZCQi5GYlBlcmlvZGVJRA0KICBJTk5FUiBKT0lOIEZiU" +
                        "GVyaW9kZSBQRVIgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKSBPTiBQRVIuRmJQZXJpb2RlSUQgPSBGQkIuR" +
                        "mJQZXJpb2RlSUQNCiAgTEVGVCAgSk9JTiBYTE9WQ29kZSBMT1YgV0lUSCAoUkVBRFVOQ09NTUlUVEVEK" +
                        "SBPTiBMT1YuTE9WTmFtZSA9ICdGYkpvdXJuYWxhYmxhZ2VvcnQnIEFORCBMT1YuQ29kZSA9IFBFUi5Kb" +
                        "3VybmFsYWJsYWdlb3J0Q29kZQ0KV0hFUkUgRmJCdWNodW5nSUQgPSBARmJCdWNodW5nSUQNCg0KDQoNC" +
                        "lNFTEVDVA0KICBATWFuZGFudE5hbWUgPSBQUlMuVm9ybmFtZU5hbWUsDQogIEBNYW5kYW50QWRyZXNzZ" +
                        "U1laHJ6ZWlsaWcgPSBQUlMuV29obnNpdHpNZWhyemVpbGlnDQpGUk9NIHZ3UGVyc29uIFBSUw0KV0hFU" +
                        "kUgUFJTLkJhUGVyc29uSUQgPSBAQmFQZXJzb25JRA0KDQpTRUxFQ1QNCiAgQEJld2lsbGlndER1cmNoI" +
                        "D0gZGJvLmZuR2V0TGFzdEZpcnN0TmFtZShGQkEuVXNlcklEX01vZGlmaWVyLCBOVUxMLCBOVUxMKSwNC" +
                        "iAgQE1hbmRhdHN0cmFlZ2VyID0gZGJvLmZuR2V0TGFzdEZpcnN0TmFtZShMRUkuVXNlcklELCBOVUxML" +
                        "CBOVUxMKQ0KRlJPTSBkYm8uRmJCYXJhdXN6YWhsdW5nQXVmdHJhZyBGQkENCiAgSU5ORVIgSk9JTiBGY" +
                        "UxlaXN0dW5nIExFSSBPTiBMRUkuRmFMZWlzdHVuZ0lEID0gRkJBLkZhTGVpc3R1bmdJRA0KV0hFUkUgR" +
                        "kJBLkZiQmFyYXVzemFobHVuZ0F1ZnRyYWdJRCA9IEBBdWZ0cmFnSUQNCg0KDQoNClNFTEVDVCANCiAgQ" +
                        "EFuVm9ybmFtZU5hY2huYW1lIEFTIEVtcGZhZW5nZXJOYW1lLCANCiAgQEFuU3RyYXNzZSBBUyBFbXBmY" +
                        "WVuZ2VyU3RyYXNzZSwgDQogIEBBblBMWiBBUyBFbXBmYWVuZ2VyUExaLA0KICBAQW5PcnQgQVMgRW1wZ" +
                        "mFlbmdlck9ydCwJDQogIEBFcmhhbHRlbkFtIEFTIEVyaGFsdGVuQW0sIA0KICBAQmV0cmFnIEFTIEJld" +
                        "HJhZywgDQogIEBCZWxlZ05yIEFTIEJlbGVnTnIsCQ0KICBAQXVzYmV6RHVyY2ggQVMgQXVzYmV6YWhsd" +
                        "ER1cmNoLCANCiAgQE1hbmRhdHN0cmFlZ2VyIEFTIE1hbmRhdHN0cmFlZ2VyLCANCiAgQEJld2lsbGlnd" +
                        "ER1cmNoIEFTIEJld2lsbGlndER1cmNoLAkNCiAgQFNvbGxLdG8gQVMgU29sbEtvbnRvLCANCiAgQFN0a" +
                        "WNodGFnIEFTIFN0aWNodGFnLCANCiAgQE1hbmRhbnROYW1lIEFTIE1hbmRhbnROYW1lLCANCiAgQE1hb" +
                        "mRhbnRBZHJlc3NlTWVocnplaWxpZyBBUyBBZHJlc3NlTWVocnplaWxpZywgDQogIEBKb3VybmFsYWJsY" +
                        "Wdlb3J0IEFTIEpvdXJuYWxhYmxhZ2VvcnQsDQogIEBCdWNodW5nc3RleHQgQVMgQnVjaHVuZ3N0ZXh0L" +
                        "A0KICBPcmdfTmFtZSAgICA9IElzTnVsbChDT05WRVJUKHZhcmNoYXIoMTAwMCksIGRiby5mblhDb25ma" +
                        "WcoJ1N5c3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlXE9yZ2FuaXNhdGlvbicsIEdldGRhdGUoKSkpLCAnJ" +
                        "yksDQogIE9yZ19BZHJlc3NlID0gSXNOdWxsKENPTlZFUlQodmFyY2hhcigxMDAwKSwgZGJvLmZuWENvb" +
                        "mZpZygnU3lzdGVtXEFkcmVzc2VcU296aWFsaGlsZmVcQWRyZXNzZScsIEdldGRhdGUoKSkpLCAnJyksD" +
                        "QogIE9yZ19QTFogICAgID0gSXNOdWxsKENPTlZFUlQodmFyY2hhcigxMDAwKSwgZGJvLmZuWENvbmZpZ" +
                        "ygnU3lzdGVtXEFkcmVzc2VcU296aWFsaGlsZmVcUExaJywgR2V0ZGF0ZSgpKSksICcnKSwNCiAgT3JnX" +
                        "09ydCAgICAgPSBJc051bGwoQ09OVkVSVCh2YXJjaGFyKDEwMDApLCBkYm8uZm5YQ29uZmlnKCdTeXN0Z" +
                        "W1cQWRyZXNzZVxTb3ppYWxoaWxmZVxPcnQnLCBHZXRkYXRlKCkpKSwgJycpLA0KICBPcmdfUExaT3J0I" +
                        "CA9IElzTnVsbChDT05WRVJUKHZhcmNoYXIoMTAwMCksIGRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc" +
                        "3NlXFNvemlhbGhpbGZlXFBMWicsIEdldGRhdGUoKSkpICsgJyAnLCAnJykNCiAgICAgICAgICAgICAgI" +
                        "CsgSXNOdWxsKENPTlZFUlQodmFyY2hhcigxMDAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc" +
                        "2VcU296aWFsaGlsZmVcT3J0JywgR2V0ZGF0ZSgpKSksICcnKQ==";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.lblBelegNr = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTitel = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel28,
                        this.xrLabel27,
                        this.xrLabel26,
                        this.xrLabel25,
                        this.xrLabel1});
            this.PageHeader.Dpi = 254F;
            this.PageHeader.Height = 667;
            this.PageHeader.Name = "PageHeader";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel30,
                        this.xrLabel29,
                        this.xrLabel24,
                        this.xrLabel23,
                        this.xrLabel22,
                        this.xrLabel21,
                        this.xrLabel20,
                        this.xrLabel19,
                        this.xrLabel18,
                        this.xrLabel17,
                        this.xrLabel16,
                        this.xrLabel15,
                        this.xrLabel2,
                        this.xrLine1,
                        this.xrLabel14,
                        this.xrLabel13,
                        this.xrLabel12,
                        this.xrLabel11,
                        this.xrLabel10,
                        this.xrLabel9,
                        this.xrLabel8,
                        this.xrLabel7,
                        this.xrLabel6,
                        this.xrLabel5,
                        this.xrLabel4,
                        this.xrLabel3,
                        this.xrPanel1});
            this.Detail.Dpi = 254F;
            this.Detail.Height = 1346;
            this.Detail.Name = "Detail";
            // 
            // PageFooter
            // 
            this.PageFooter.Dpi = 254F;
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrLabel28
            // 
            this.xrLabel28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Name", "")});
            this.xrLabel28.Dpi = 254F;
            this.xrLabel28.Font = new System.Drawing.Font("Arial", 14F);
            this.xrLabel28.ForeColor = System.Drawing.Color.Black;
            this.xrLabel28.Location = new System.Drawing.Point(0, 0);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel28.ParentStyleUsing.UseBackColor = false;
            this.xrLabel28.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel28.ParentStyleUsing.UseBorders = false;
            this.xrLabel28.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel28.ParentStyleUsing.UseFont = false;
            this.xrLabel28.ParentStyleUsing.UseForeColor = false;
            this.xrLabel28.Size = new System.Drawing.Size(859, 99);
            this.xrLabel28.Text = "xrLabel28";
            // 
            // xrLabel27
            // 
            this.xrLabel27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Adresse", "")});
            this.xrLabel27.Dpi = 254F;
            this.xrLabel27.Font = new System.Drawing.Font("Arial", 11F);
            this.xrLabel27.ForeColor = System.Drawing.Color.Black;
            this.xrLabel27.Location = new System.Drawing.Point(1376, 0);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel27.ParentStyleUsing.UseBackColor = false;
            this.xrLabel27.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel27.ParentStyleUsing.UseBorders = false;
            this.xrLabel27.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel27.ParentStyleUsing.UseFont = false;
            this.xrLabel27.ParentStyleUsing.UseForeColor = false;
            this.xrLabel27.Size = new System.Drawing.Size(460, 58);
            this.xrLabel27.Text = "xrLabel27";
            // 
            // xrLabel26
            // 
            this.xrLabel26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_PLZOrt", "")});
            this.xrLabel26.Dpi = 254F;
            this.xrLabel26.Font = new System.Drawing.Font("Arial", 11F);
            this.xrLabel26.ForeColor = System.Drawing.Color.Black;
            this.xrLabel26.Location = new System.Drawing.Point(1376, 64);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel26.ParentStyleUsing.UseBackColor = false;
            this.xrLabel26.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel26.ParentStyleUsing.UseBorders = false;
            this.xrLabel26.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel26.ParentStyleUsing.UseFont = false;
            this.xrLabel26.ParentStyleUsing.UseForeColor = false;
            this.xrLabel26.Size = new System.Drawing.Size(460, 58);
            this.xrLabel26.Text = "xrLabel26";
            // 
            // xrLabel25
            // 
            this.xrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AdresseMehrzeilig", "")});
            this.xrLabel25.Dpi = 254F;
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel25.Location = new System.Drawing.Point(1143, 381);
            this.xrLabel25.Multiline = true;
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel25.ParentStyleUsing.UseFont = false;
            this.xrLabel25.Size = new System.Drawing.Size(615, 170);
            this.xrLabel25.Text = "xrLabel25";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "MandantName", "")});
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel1.Location = new System.Drawing.Point(1143, 339);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(615, 41);
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel30
            // 
            this.xrLabel30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Buchungstext", "")});
            this.xrLabel30.Dpi = 254F;
            this.xrLabel30.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel30.Location = new System.Drawing.Point(381, 447);
            this.xrLabel30.Name = "xrLabel30";
            this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel30.ParentStyleUsing.UseFont = false;
            this.xrLabel30.Size = new System.Drawing.Size(1058, 148);
            this.xrLabel30.Text = "xrLabel30";
            // 
            // xrLabel29
            // 
            this.xrLabel29.Dpi = 254F;
            this.xrLabel29.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel29.Location = new System.Drawing.Point(0, 448);
            this.xrLabel29.Name = "xrLabel29";
            this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel29.ParentStyleUsing.UseFont = false;
            this.xrLabel29.Size = new System.Drawing.Size(381, 43);
            this.xrLabel29.Text = "Buchungstext:";
            // 
            // xrLabel24
            // 
            this.xrLabel24.Dpi = 254F;
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel24.Location = new System.Drawing.Point(0, 1206);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel24.ParentStyleUsing.UseFont = false;
            this.xrLabel24.Size = new System.Drawing.Size(635, 44);
            this.xrLabel24.Text = ".......................................................";
            // 
            // xrLabel23
            // 
            this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "EmpfaengerName", "")});
            this.xrLabel23.Dpi = 254F;
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel23.Location = new System.Drawing.Point(0, 1270);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel23.ParentStyleUsing.UseFont = false;
            this.xrLabel23.Size = new System.Drawing.Size(549, 43);
            this.xrLabel23.Text = "xrLabel23";
            // 
            // xrLabel22
            // 
            this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ErhaltenAm", "{0:dd/MM/yyyy}")});
            this.xrLabel22.Dpi = 254F;
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel22.Location = new System.Drawing.Point(318, 952);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel22.ParentStyleUsing.UseFont = false;
            this.xrLabel22.Size = new System.Drawing.Size(294, 44);
            this.xrLabel22.Text = "xrLabel22";
            // 
            // xrLabel21
            // 
            this.xrLabel21.Dpi = 254F;
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel21.Location = new System.Drawing.Point(0, 952);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel21.ParentStyleUsing.UseFont = false;
            this.xrLabel21.Size = new System.Drawing.Size(318, 44);
            this.xrLabel21.Text = "Betrag erhalten am";
            // 
            // xrLabel20
            // 
            this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "EmpfaengerOrt", "")});
            this.xrLabel20.Dpi = 254F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel20.Location = new System.Drawing.Point(478, 805);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel20.ParentStyleUsing.UseFont = false;
            this.xrLabel20.Size = new System.Drawing.Size(495, 43);
            this.xrLabel20.Text = "xrLabel20";
            // 
            // xrLabel19
            // 
            this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "EmpfaengerPLZ", "")});
            this.xrLabel19.Dpi = 254F;
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel19.Location = new System.Drawing.Point(381, 805);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel19.ParentStyleUsing.UseFont = false;
            this.xrLabel19.Size = new System.Drawing.Size(97, 43);
            this.xrLabel19.Text = "xrLabel19";
            // 
            // xrLabel18
            // 
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "EmpfaengerStrasse", "")});
            this.xrLabel18.Dpi = 254F;
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel18.Location = new System.Drawing.Point(381, 762);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel18.ParentStyleUsing.UseFont = false;
            this.xrLabel18.Size = new System.Drawing.Size(592, 43);
            this.xrLabel18.Text = "xrLabel18";
            // 
            // xrLabel17
            // 
            this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "EmpfaengerName", "")});
            this.xrLabel17.Dpi = 254F;
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel17.Location = new System.Drawing.Point(381, 719);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel17.ParentStyleUsing.UseFont = false;
            this.xrLabel17.Size = new System.Drawing.Size(592, 43);
            this.xrLabel17.Text = "xrLabel17";
            // 
            // xrLabel16
            // 
            this.xrLabel16.Dpi = 254F;
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel16.Location = new System.Drawing.Point(0, 719);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel16.ParentStyleUsing.UseFont = false;
            this.xrLabel16.Size = new System.Drawing.Size(381, 43);
            this.xrLabel16.Text = "Ausbezahlt an:";
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:CHF #.00}")});
            this.xrLabel15.Dpi = 254F;
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel15.Location = new System.Drawing.Point(1334, 590);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel15.ParentStyleUsing.UseFont = false;
            this.xrLabel15.Size = new System.Drawing.Size(551, 63);
            this.xrLabel15.Text = "xrLabel15";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.Location = new System.Drawing.Point(0, 590);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(551, 63);
            this.xrLabel2.Text = "Ausbezahlter Betrag";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 254F;
            this.xrLine1.LineWidth = 3;
            this.xrLine1.Location = new System.Drawing.Point(0, 656);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(1884, 21);
            // 
            // xrLabel14
            // 
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Journalablageort", "")});
            this.xrLabel14.Dpi = 254F;
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel14.Location = new System.Drawing.Point(381, 338);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel14.ParentStyleUsing.UseFont = false;
            this.xrLabel14.Size = new System.Drawing.Size(772, 43);
            this.xrLabel14.Text = "xrLabel14";
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SollKonto", "")});
            this.xrLabel13.Dpi = 254F;
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel13.Location = new System.Drawing.Point(381, 391);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel13.ParentStyleUsing.UseFont = false;
            this.xrLabel13.Size = new System.Drawing.Size(772, 43);
            this.xrLabel13.Text = "xrLabel13";
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BewilligtDurch", "")});
            this.xrLabel12.Dpi = 254F;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel12.Location = new System.Drawing.Point(381, 234);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel12.ParentStyleUsing.UseFont = false;
            this.xrLabel12.Size = new System.Drawing.Size(467, 40);
            this.xrLabel12.Text = "xrLabel12";
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Stichtag", "{0:dd/MM/yyyy}")});
            this.xrLabel11.Dpi = 254F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel11.Location = new System.Drawing.Point(381, 284);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel11.ParentStyleUsing.UseFont = false;
            this.xrLabel11.Size = new System.Drawing.Size(467, 44);
            this.xrLabel11.Text = "xrLabel11";
            // 
            // xrLabel10
            // 
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Mandatstraeger", "")});
            this.xrLabel10.Dpi = 254F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel10.Location = new System.Drawing.Point(381, 180);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel10.ParentStyleUsing.UseFont = false;
            this.xrLabel10.Size = new System.Drawing.Size(467, 44);
            this.xrLabel10.Text = "xrLabel10";
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AusbezahltDurch", "")});
            this.xrLabel9.Dpi = 254F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel9.Location = new System.Drawing.Point(381, 127);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.Size = new System.Drawing.Size(467, 43);
            this.xrLabel9.Text = "xrLabel9";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 254F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel8.Location = new System.Drawing.Point(0, 338);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.Size = new System.Drawing.Size(381, 43);
            this.xrLabel8.Text = "Journalablageort:";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 254F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel7.Location = new System.Drawing.Point(0, 391);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.Size = new System.Drawing.Size(381, 43);
            this.xrLabel7.Text = "Soll-Konto:";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 254F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel6.Location = new System.Drawing.Point(0, 234);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.Size = new System.Drawing.Size(381, 43);
            this.xrLabel6.Text = "Bewilligt durch:";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 254F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel5.Location = new System.Drawing.Point(0, 284);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(381, 44);
            this.xrLabel5.Text = "Stichtag:";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel4.Location = new System.Drawing.Point(0, 180);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(381, 44);
            this.xrLabel4.Text = "Mandatsträger:";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel3.Location = new System.Drawing.Point(0, 127);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(381, 43);
            this.xrLabel3.Text = "Ausbezahlt durch:";
            // 
            // xrPanel1
            // 
            this.xrPanel1.BackColor = System.Drawing.Color.LightGray;
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblBelegNr,
                        this.lblTitel});
            this.xrPanel1.Dpi = 254F;
            this.xrPanel1.Location = new System.Drawing.Point(0, 0);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.ParentStyleUsing.UseBackColor = false;
            this.xrPanel1.Size = new System.Drawing.Size(1884, 50);
            // 
            // lblBelegNr
            // 
            this.lblBelegNr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BelegNr", "")});
            this.lblBelegNr.Dpi = 254F;
            this.lblBelegNr.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblBelegNr.Location = new System.Drawing.Point(1503, 0);
            this.lblBelegNr.Name = "lblBelegNr";
            this.lblBelegNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblBelegNr.ParentStyleUsing.UseFont = false;
            this.lblBelegNr.Size = new System.Drawing.Size(381, 51);
            this.lblBelegNr.Text = "lblBelegNr";
            this.lblBelegNr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblTitel
            // 
            this.lblTitel.Dpi = 254F;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitel.Location = new System.Drawing.Point(0, 0);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblTitel.ParentStyleUsing.UseFont = false;
            this.lblTitel.Size = new System.Drawing.Size(551, 51);
            this.lblTitel.Text = "Auszahlungsbeleg";
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
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(99, 99, 99, 99);
            this.Name = "Report";
            this.PageHeight = 2969;
            this.PageWidth = 2101;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
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
		<DisplayText>BuchungsID:</DisplayText>
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
		<FieldName>FbBuchungID</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>BuchungsId</DisplayText>
		<TabPosition>1</TabPosition>
		<X>220</X>
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
		<DisplayText>BarauszahlungAuftragID:</DisplayText>
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
		<FieldName>FbBarauszahlungAuftragID</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>BarauszahlungAuftragID</DisplayText>
		<TabPosition>3</TabPosition>
		<X>220</X>
		<Y>90</Y>
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
		<DisplayText>PersonID:</DisplayText>
		<TabPosition>4</TabPosition>
		<X>10</X>
		<Y>120</Y>
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
		<FieldName>BaPersonID</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>PersonID</DisplayText>
		<TabPosition>5</TabPosition>
		<X>220</X>
		<Y>120</Y>
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
		<DisplayText>Stichtag:</DisplayText>
		<TabPosition>6</TabPosition>
		<X>10</X>
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
		<FieldName>Stichtag</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>Stichtag</DisplayText>
		<TabPosition>7</TabPosition>
		<X>220</X>
		<Y>150</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>true</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
</NewDataSet>' , SQLquery =  N'DECLARE @FbBuchungID int, @AuftragID int, @BaPersonID int, @Stichtag datetime
SET @FbBuchungID = {FbBuchungID}
SET @AuftragID = {FbBarauszahlungAuftragID}
SET @BaPersonID = {BaPersonID}
SET @Stichtag = {Stichtag}

DECLARE @AnVornameNachname varchar(50),	@AnStrasse varchar(25),	@AnPLZ varchar(8),
	@AnOrt varchar(25),	@ErhaltenAm datetime,	@Betrag money,	@BelegNr varchar(25),
	@AusbezDurch varchar(50),	@Mandatstraeger varchar(50),	@BewilligtDurch varchar(50),
	@SollKto varchar(50), @MandantName varchar(50), @MandantAdresseMehrzeilig varchar(80),
        @Journalablageort varchar(25), @Buchungstext varchar(200)

SELECT
  @BelegNr = FBB.BelegNr,
  @ErhaltenAm = FBB.BuchungsDatum,
  @Betrag = FBB.Betrag,
  @AnVornameNachname = FBB.Name,
  @AnStrasse = FBB.Strasse,
  @AnPLZ = FBB.PLZ,
  @AnOrt = FBB.Ort,
  @AusbezDurch = dbo.fnGetLastFirstName(FBB.UserID, NULL, NULL),
  @SollKto = CONVERT(varchar, FBB.SollKtoNr) + '' '' + KTO.KontoName,
  @Journalablageort = LOV.Text,
  @Buchungstext = FBB.Text
FROM FbBuchung FBB
  INNER JOIN FbKonto KTO WITH (READUNCOMMITTED) ON KTO.KontoNr = FBB.SollKtoNr AND KTO.FbPeriodeID = FBB.FbPeriodeID
  INNER JOIN FbPeriode PER WITH (READUNCOMMITTED) ON PER.FbPeriodeID = FBB.FbPeriodeID
  LEFT  JOIN XLOVCode LOV WITH (READUNCOMMITTED) ON LOV.LOVName = ''FbJournalablageort'' AND LOV.Code = PER.JournalablageortCode
WHERE FbBuchungID = @FbBuchungID



SELECT
  @MandantName = PRS.VornameName,
  @MandantAdresseMehrzeilig = PRS.WohnsitzMehrzeilig
FROM vwPerson PRS
WHERE PRS.BaPersonID = @BaPersonID

SELECT
  @BewilligtDurch = dbo.fnGetLastFirstName(FBA.UserID_Modifier, NULL, NULL),
  @Mandatstraeger = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL)
FROM dbo.FbBarauszahlungAuftrag FBA
  INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = FBA.FaLeistungID
WHERE FBA.FbBarauszahlungAuftragID = @AuftragID



SELECT 
  @AnVornameNachname AS EmpfaengerName, 
  @AnStrasse AS EmpfaengerStrasse, 
  @AnPLZ AS EmpfaengerPLZ,
  @AnOrt AS EmpfaengerOrt,	
  @ErhaltenAm AS ErhaltenAm, 
  @Betrag AS Betrag, 
  @BelegNr AS BelegNr,	
  @AusbezDurch AS AusbezahltDurch, 
  @Mandatstraeger AS Mandatstraeger, 
  @BewilligtDurch AS BewilligtDurch,	
  @SollKto AS SollKonto, 
  @Stichtag AS Stichtag, 
  @MandantName AS MandantName, 
  @MandantAdresseMehrzeilig AS AdresseMehrzeilig, 
  @Journalablageort AS Journalablageort,
  @Buchungstext AS Buchungstext,
  Org_Name    = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Organisation'', Getdate())), ''''),
  Org_Adresse = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Adresse'', Getdate())), ''''),
  Org_PLZ     = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', Getdate())), ''''),
  Org_Ort     = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', Getdate())), ''''),
  Org_PLZOrt  = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', Getdate())) + '' '', '''')
               + IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', Getdate())), '''')' , ContextForms =  N'FrmVmKasse' , ParentReportName =  null , ReportSortKey =  null 
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'VmFibuKassenbeleg' ;


