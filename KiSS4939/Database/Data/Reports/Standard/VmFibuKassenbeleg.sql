-- Insert Script for VmFibuKassenbeleg
-- MD5:0XCB0ED5F9064E2AB0239E7FB5C79B215A_0X3D5994CFA3DC34A08E51DE33473E61A7_0X05CCE3C8F4F8A2B7AD85CFF8C8E0735F
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
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4.2.07\KiSS4.DB.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4.2.07\log4net.dll" />
///     <Reference Path="C:\Program Files (x86)\Born Informatik AG\KiSS4.2.07\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRRichText xrRichText2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel25;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRRichText xrRichText1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.DetailBand Detail;
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
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAAEAAAAAgAAAGhTeXN0ZW0uRHJhd" +
                        "2luZy5CaXRtYXAsIFN5c3RlbS5EcmF3aW5nLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhb" +
                        "CwgUHVibGljS2V5VG9rZW49YjAzZjVmN2YxMWQ1MGEzYYwBRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VS" +
                        "S5TZXJpYWxpemFibGVTdHJpbmcsIERldkV4cHJlc3MuWHRyYVJlcG9ydHMudjYuMiwgVmVyc2lvbj02L" +
                        "jIuNi4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPTc5ODY4YjgxNDdiNWVhZTQTtE6kg" +
                        "G2btk4GIBpDDrpRAAAAAGIAAAA3AAAAjQAAAHwCAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlA" +
                        "GMAdABTAHQAYQB0AGUAbQBlAG4AdAAAAAAAJngAcgBQAGkAYwB0AHUAcgBlAEIAbwB4ADEALgBJAG0AY" +
                        "QBnAGUA1AgAACZ4AHIAUgBpAGMAaABUAGUAeAB0ADEALgBSAHQAZgBUAGUAeAB0AMQxAAAmeAByAFIAa" +
                        "QBjAGgAVABlAHgAdAAyAC4AUgB0AGYAVABlAHgAdABlNAAAAdERREVDTEFSRSBARmJCdWNodW5nSUQga" +
                        "W50LCBAQXVmdHJhZ0lEIGludCwgQEJhUGVyc29uSUQgaW50LCBAU3RpY2h0YWcgZGF0ZXRpbWUNClNFV" +
                        "CBARmJCdWNodW5nSUQgPSBudWxsDQpTRVQgQEF1ZnRyYWdJRCA9IG51bGwNClNFVCBAQmFQZXJzb25JR" +
                        "CA9IG51bGwNClNFVCBAU3RpY2h0YWcgPSBudWxsDQoNCkRFQ0xBUkUgQEFuVm9ybmFtZU5hY2huYW1lI" +
                        "HZhcmNoYXIoNTApLAlAQW5TdHJhc3NlIHZhcmNoYXIoMjUpLAlAQW5QTFogdmFyY2hhcig4KSwNCglAQ" +
                        "W5PcnQgdmFyY2hhcigyNSksCUBFcmhhbHRlbkFtIGRhdGV0aW1lLAlAQmV0cmFnIG1vbmV5LAlAQmVsZ" +
                        "WdOciB2YXJjaGFyKDI1KSwNCglAQXVzYmV6RHVyY2ggdmFyY2hhcig1MCksCUBNYW5kYXRzdHJhZWdlc" +
                        "iB2YXJjaGFyKDUwKSwJQEJld2lsbGlndER1cmNoIHZhcmNoYXIoNTApLA0KCUBTb2xsS3RvIHZhcmNoY" +
                        "XIoNTApLCBATWFuZGFudE5hbWUgdmFyY2hhcig1MCksIEBNYW5kYW50QWRyZXNzZU1laHJ6ZWlsaWcgd" +
                        "mFyY2hhcig4MCksDQogICAgICAgIEBKb3VybmFsYWJsYWdlb3J0IHZhcmNoYXIoMjUpDQoNCg0KDQoNC" +
                        "lNFTEVDVA0KICBAQmVsZWdOciA9IEZCQi5CZWxlZ05yLA0KICBARXJoYWx0ZW5BbSA9IEZCQi5CdWNod" +
                        "W5nc0RhdHVtLA0KICBAQmV0cmFnID0gRkJCLkJldHJhZywNCiAgQEFuVm9ybmFtZU5hY2huYW1lID0gR" +
                        "kJCLk5hbWUsDQogIEBBblN0cmFzc2UgPSBGQkIuU3RyYXNzZSwNCiAgQEFuUExaID0gRkJCLlBMWiwNC" +
                        "iAgQEFuT3J0ID0gRkJCLk9ydCwNCiAgQEF1c2JlekR1cmNoID0gZGJvLmZuR2V0TGFzdEZpcnN0TmFtZ" +
                        "ShGQkIuVXNlcklELCBOVUxMLCBOVUxMKSwNCiAgQFNvbGxLdG8gPSBDT05WRVJUKHZhcmNoYXIsIEZCQ" +
                        "i5Tb2xsS3RvTnIpICsgJyAnICsgS1RPLktvbnRvTmFtZSwNCiAgQEpvdXJuYWxhYmxhZ2VvcnQgPSBMT" +
                        "1YuVGV4dA0KRlJPTSBGYkJ1Y2h1bmcgRkJCDQogIElOTkVSIEpPSU4gRmJLb250byBLVE8gV0lUSCAoU" +
                        "kVBRFVOQ09NTUlUVEVEKSBPTiBLVE8uS29udG9OciA9IEZCQi5Tb2xsS3RvTnIgQU5EIEtUTy5GYlBlc" +
                        "mlvZGVJRCA9IEZCQi5GYlBlcmlvZGVJRA0KICBJTk5FUiBKT0lOIEZiUGVyaW9kZSBQRVIgV0lUSCAoU" +
                        "kVBRFVOQ09NTUlUVEVEKSBPTiBQRVIuRmJQZXJpb2RlSUQgPSBGQkIuRmJQZXJpb2RlSUQNCiAgTEVGV" +
                        "CAgSk9JTiBYTE9WQ29kZSBMT1YgV0lUSCAoUkVBRFVOQ09NTUlUVEVEKSBPTiBMT1YuTE9WTmFtZSA9I" +
                        "CdWbUpvdXJuYWxhYmxhZ2VvcnQnIEFORCBMT1YuQ29kZSA9IFBFUi5Kb3VybmFsYWJsYWdlb3J0Q29kZ" +
                        "Q0KV0hFUkUgRmJCdWNodW5nSUQgPSBARmJCdWNodW5nSUQNCg0KDQoNClNFTEVDVA0KICBATWFuZGFud" +
                        "E5hbWUgPSBQUlMuVm9ybmFtZU5hbWUsDQogIEBNYW5kYW50QWRyZXNzZU1laHJ6ZWlsaWcgPSBQUlMuV" +
                        "29obnNpdHpNZWhyemVpbGlnDQpGUk9NIHZ3UGVyc29uIFBSUw0KV0hFUkUgUFJTLkJhUGVyc29uSUQgP" +
                        "SBAQmFQZXJzb25JRA0KDQpTRUxFQ1QNCiAgQEJld2lsbGlndER1cmNoID0gZGJvLmZuR2V0TGFzdEZpc" +
                        "nN0TmFtZShGQkEuVXNlcklEX01vZGlmaWVyLCBOVUxMLCBOVUxMKSwNCiAgQE1hbmRhdHN0cmFlZ2VyI" +
                        "D0gZGJvLmZuR2V0TGFzdEZpcnN0TmFtZShMRUkuVXNlcklELCBOVUxMLCBOVUxMKQ0KRlJPTSBkYm8uR" +
                        "mJCYXJhdXN6YWhsdW5nQXVmdHJhZyBGQkENCiAgSU5ORVIgSk9JTiBGYUxlaXN0dW5nIExFSSBPTiBMR" +
                        "UkuRmFMZWlzdHVuZ0lEID0gRkJBLkZhTGVpc3R1bmdJRA0KV0hFUkUgRkJBLkZiQmFyYXVzemFobHVuZ" +
                        "0F1ZnRyYWdJRCA9IEBBdWZ0cmFnSUQNCg0KDQoNClNFTEVDVCBAQW5Wb3JuYW1lTmFjaG5hbWUgQVMgR" +
                        "W1wZmFlbmdlck5hbWUsIEBBblN0cmFzc2UgQVMgRW1wZmFlbmdlclN0cmFzc2UsIEBBblBMWiBBUyBFb" +
                        "XBmYWVuZ2VyUExaLA0KQEFuT3J0IEFTIEVtcGZhZW5nZXJPcnQsCUBFcmhhbHRlbkFtIEFTIEVyaGFsd" +
                        "GVuQW0sIEBCZXRyYWcgQVMgQmV0cmFnLCBAQmVsZWdOciBBUyBCZWxlZ05yLAkNCkBBdXNiZXpEdXJja" +
                        "CBBUyBBdXNiZXphaGx0RHVyY2gsIEBNYW5kYXRzdHJhZWdlciBBUyBNYW5kYXRzdHJhZWdlciwgQEJld" +
                        "2lsbGlndER1cmNoIEFTIEJld2lsbGlndER1cmNoLAkNCkBTb2xsS3RvIEFTIFNvbGxLb250bywgQFN0a" +
                        "WNodGFnIEFTIFN0aWNodGFnLCBATWFuZGFudE5hbWUgQVMgTWFuZGFudE5hbWUsIA0KQE1hbmRhbnRBZ" +
                        "HJlc3NlTWVocnplaWxpZyBBUyBBZHJlc3NlTWVocnplaWxpZywgQEpvdXJuYWxhYmxhZ2VvcnQgQVMgS" +
                        "m91cm5hbGFibGFnZW9ydEAAAQAAAP////8BAAAAAAAAAAwCAAAAUVN5c3RlbS5EcmF3aW5nLCBWZXJza" +
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49YjAzZjVmN2YxMWQ1MGEzY" +
                        "QUBAAAAFVN5c3RlbS5EcmF3aW5nLkJpdG1hcAEAAAAERGF0YQcCAgAAAAkDAAAADwMAAABNKAAAAolQT" +
                        "kcNChoKAAAADUlIRFIAAAEbAAABxwgGAAAAj9H8dQAAAAFzUkdCAK7OHOkAAAAEZ0FNQQAAsY8L/GEFA" +
                        "AAAIGNIUk0AAHomAACAhAAA+gAAAIDoAAB1MAAA6mAAADqYAAAXcJy6UTwAACfLSURBVHhe7Z3blhs5r" +
                        "kT7/3+6x+Vp2SqVlIjAjSAzvNZ5Slw3wBAz7Z7zzz/6IwIiIAKNBP79leuE/2tE9juVmPHExezmzE5Yg" +
                        "K8euv+cwE3M+B8NMQswO+HQSGz4BRAzMes6+38EuithdR794vCHR8zErPpcfvtR60jWkUMHRwdHe8bvQ" +
                        "CuzjmQdOSQ2/KKJmZi1ns2OZB05dHB0cLRn/A60MutI1pFDYsMvmpiJWevZ7EjWkUMHRwdHe8bvQCuzj" +
                        "mQdOSQ2/KKJmZi1nk0m2eTlnFrb1Lom/zsbMftLAD2fWzBDm5m8nJNr22IJmopEd62pHNe/NZta29S63" +
                        "P/OZouGmorUweFBi9nNmaELMPn2MLk2fr1iHifMM0aA9xazJmYngJbY8O/4YiZmvMQEmUlsfMhRbr7of" +
                        "i+0LolN8OD4R0R5ovOkgiYYo3Xpm00j7IRUVAjXElAZ/MZobf4MPk+0Lgl0UKBPAK0lCC6B74zSXuiu0" +
                        "YGDDmhd2rPgnp0AWksQXILgYUXd0V1D42XZoXVpz4J7dgJoLUFwCbJOrREH3bWmcv6kQevSngX37ATQW" +
                        "oLgEjSdbnTXmsqR2ARAo7PUB+IA5IcrCjshFRUCrUsCLYGmFuvF2LVnLqdIlYTvCbUR7aaYihmPUcyam" +
                        "J0AWr/S+pXmj4uYtTOT2PiQo9x80f1eaF0SaImNf8u4/2mOoz6O6eDo4LQfnEhCwhf98SBCppiidekDc" +
                        "QJuFHZCKioEWpcEWgJNLZY+EP+9zkXAeXzRQ+2JHfFB65LYSGza9+yE5dTB0cFpPziRhIQvej6JkCmma" +
                        "F16jUrAjcJOSEWFQOuSQEugqcXSa5Reo14XRmLDHyExa2J2Amj9SutXmj8uYtbOTGLjQ45y80X3e6F1S" +
                        "aAlNv4t07+zibCjfdFDTQcOOqB1SWwkNpFVc+2ZyylSJeF7Qm1EuymmYsZjFLMmZieA1q+0fqX54yJm7" +
                        "cwkNj7kKDdfdL8XWpcEWmLj3zJ9s4mwo33RQ00HDjqgdUlsJDaRVXPtmcspUiXhe0JtRLsppmLGYxSzJ" +
                        "mYngNavtH6l+eMiZu3MJDY+5Cg3X3S/F1qXBFpi498yfbOJsKN90UNNBw46oHVJbCQ2kVVz7ZnLKVIl4" +
                        "XtCbUS7KaZixmMUsyZmJ4DWr7R+pfnjImbtzCQ2PuQoN190vxdalwRaYuPfMn2zibCjfdFDTQcOOqB1S" +
                        "WwkNpFVc+2ZyylSJeF7Qm1EuymmYsZjFLMmZieA1q+0fqX54yJm7cwkNj7kKDdfdL8XWpcEWmLj3zJ9s" +
                        "4mwo33RQ00HDjqgdUlsJDaRVXPtmcspUiXhe0JtRLsppmLGYxSzJmYngNavtH6l+eMiZu3MJDY+5Cg3X" +
                        "3S/F1qXBFpi498yfbOJsKN90UNNBw46oHVJbCQ2kVVz7ZnLKVIl4XtCbUS7KaZixmMUsyZmJ4DWr7R+p" +
                        "fnjImbtzCQ2PuQoN190vxdalwRaYuPfMn2zibCjfdFDTQcOOqB1SWwkNpFVc+2ZyylSJeF7Qm1EuymmY" +
                        "sZjFLMmZieA1q+0fqX54yJm7cwkNj7kKDdfdL8XWpcEWmLj3zJ9s4mwo33RQ00HDjqgdUlsJDaRVXPtm" +
                        "cspUiXhe0JtRLsppmLGYxSzJmYngNavtH6l+eMiZu3MThEbpo9O28hAPb6dvVXl8vQd8anqozNupH+PL" +
                        "9Pbn/guJ091Dh+mtqm2jrZDLlM5MHWFADicmdqm2jraDrkwHCQ2vwgwwLy2oYk6nL11TvJztB1ymdS7t" +
                        "5YQAIczU6fERmLTIrbMUj5sHbsfcvHUOM0nBMDhzPQvsZHYSGz+OwXMwZlq69CLkAvDQWIjsZHYSGzcg" +
                        "iOxaRIQF2j3WDlHpraptlzHceupHJi64hS4CK7aXE5cXW5rpraptu7mnY5TOTB1OVt3uzG1TbV1N+90Z" +
                        "DjoNarpFuScpduNWYKptu7mnY5TOTB1OVt3u7lqczm5S+Qcmdqm2nIdx62ncmDqilPgIjC1TbXlOo5bM" +
                        "xzi2RRBBERABERABERABERABERABERABERABERABERABERABERABERABERABERABERABERABERABERAB" +
                        "ERABERABERABERABERABERABERABERABERABERABERABERABERABERABERABERABERABERABERABERAB" +
                        "ERABERABERABERABERABERABERABERABERABERABERABERABERABERABERABERABERABERABERABERAB" +
                        "ERABERABERABERABERABERABERABERABERABERABERABERABERABHYk8O+vovV/YqAd0A5U7cAfXaxKo" +
                        "LhaXu2AduBrByQ2utHpRqsdaNkBiY0WrWXRdLvR7UZiI7GR2GgHWnZAYqNFa1k03Wx0s5HYSGwkNtqBl" +
                        "h2Q2GjRWhZNNxvdbCQ2EhuJjXagZQckNlq0lkXTzUY3G5fY7PgvpJGasw4Ekks2InAKAfTcSGxeJo6CQ" +
                        "+xOWSb1IQJXBJCz4P4XxHdAjwK07O7ASj3em4B1Bh7PdbO52BMUImJ373VU9ycTQPZfNxtwA1CYlh2YT" +
                        "mYisBUBa+91syHHiQJF7MjUMheB0QSQndfNxjFCFKxl50gtFxEYScDadd1sAmND4SJ2gTLkKgIjCCB7r" +
                        "ptNcFQoZMsuWIbcRWApAWu/dbNJGg8KGrFLKklhRKCVALLbutkkjgQFbtkllqRQItBCwNpp3WwKxoBCR" +
                        "+wKylNIESghgOyzbjYl6PP+g7ui8hRWBFIJSGxScfLB0AEgdnx2eYhAHwFkh3WzaZgHOgjLrqFUpRABF" +
                        "wFrd/XNxoXV54QOA7HzVSAvEagjgOytbjZ1/N9GRodi2TWXrXQicEnA2lfdbBYtEDoYxG5RC0orAt8II" +
                        "Luqm83CpUEHZNktbEGpReA3AWtHdbMZsCjokBC7Ae2ohJsSQPZTN5shy4EOy7Ib0o7KuBkBay91sxm2E" +
                        "OjAELthramcwwkgO6mbzcAlQAdn2Q1sTSUdSsDaRd1sBg8eHR5iN7hNlXYIAWQPdbMZPmx0iJbd8DZV3" +
                        "uYErP3TzWaTAaODROw2aVllbkYA2T3dbDYaKjpQy26jllXqJgSsndPNZpNBPpeJDhWx27B9lTyUALJvu" +
                        "tkMHZ5VFjpcy87Ko+cigBCw9kw3G4TiYBt0wIjd4DZV2gYEkB3TzWaDQVolooO27Kw8ei4CnwhYu6Wbz" +
                        "UG7gw4bsTsIi1ppIoDslW42TcPoSoMO3bLrqld5ziBg7ZNuNmfM+UcX6OARu0MRqa1kAsgu6WaTDH1SO" +
                        "HQBLLtJPamWmQSsHbr1zeabys6cX0pV6BIgdikFKciRBJD9Oepm865h5Ov5kdN/aQpdBsvuDqzUI0/A2" +
                        "pvtbzZWgxayV3/LfvfnFi/m+e4sVH8uAXR3/mRFHSa8gli1IiiZmxASbxcbix36fJd+VWc9AXpnUIfVY" +
                        "mPViaK9ioPG2NXOYsg835WB6s4jgO7LVjcbqykGnxVrtagyvXhtEQaIjTe//M4ggOzIdh+IraaY0Vmxn" +
                        "p8zcXezZThYtrv1rnpzCFh78Xi+zc3GaojFZsW72zcdD4+7MWJ37C726O5IbH4RQGGd/mrFcLBs73LQ1" +
                        "Cd+fiQ2pNj8uBIeuG2WkKDPD0Sjlt4QoPcBdVj1627Vx26BFQ99zubdxR7tH7HbpWfV6SOA7MBWH4ith" +
                        "lhMVjz2OZt/F3uWwyf7XfpVnTwBdEf0GuV8jbrToUKXCbHjV1ke0wkgc9/qZvMF/KopdiAoII8dUsuO3" +
                        "348LN75IHxksw8BdC+2udlYYsN+S0IBRezercvuN6IIj1fffY6TKr0igO7EVmKTKTgooAy750FZ8TLWu" +
                        "kPQrD7Q5xn9KsZaAvSsUQf2BlGBIeN1iuk3wxYRyuc8Hm5onZ7YzC0NrSPab1YfihMjgM57u5vNo+Co4" +
                        "KCAVtuha8DWicZF7NjcHTcvpG7Z5BBA57+t2Fg3BRQjCmq1ndUPW58Vj33O5o/+WLD1yb6OADr7rcXGE" +
                        "hz0lQ+Ftdru07p466pYP28tr34VtSlmDQF05tuLTdZrFSJcKNRqu9eV8earWT38v5VB6q6qUXHzCCBz/" +
                        "PbDjzqgt4W8VvBIGVdzhsNqW0RorRpxuryllRt9zmeWRycBeo6ow2SxQQ4fOgSGh8f2XR3eOB6/hw/Kw" +
                        "2sXqU2vVl7qvX7ojI95jWJeLdBRoBBZu6v8nlisz7M9yiJqF6lxRb3Rfu/kj872WLGZfMvJFBt00J/sO" +
                        "g9FtFaJTue08FzoXI8Xm68GJ33LQUaIDi9qh9RSYROtu+sVsKL3E2Oi87yF2Fi3HGYBULBegcuIj8Zg+" +
                        "s62RWtE7LJrUzyOADKjL5tbic2UW86U1yhupWqs0UW17GqqU1SEgDWbHzdR1OGbQiGVDLTx3jq84vwu3" +
                        "zsszAyitpPGEu1F33LWThOd3+1uNohgMKNDQU+yY/rrtM1i1FmzcuH/iPPWYjPltSrrkHniTDssnh4++" +
                        "Uzr7dR60JndXmweAKILiwKfajftIGRxmtbXifWgs5LYPE3/7oIz7XscusSI3YmHfEpPCP9b/m0UMiCv6" +
                        "KDQd7BDOHXZZPHqqvduedD56GbzYTM8goNC38luysHJZDalp1PqQGdza7F5QLoa+juQn+xR6DvaTTkYW" +
                        "eym9HNCHehMJDa/CFjfKlDBQaHvbDfhcGTym9DP7jWg85DY/Cc2luB8gXqGesfbDXIT7Dw46JJbdp01n" +
                        "5jL4vtjb1AH5FDuAhS9sTz3c3XgGIYn2E6YcybHCf3sWAM6A91sXm4skV9vFPppdhMOSBbTCb3sVgPKX" +
                        "mLzQWxY0UGBn2y3+pBksl3dy075Ue4SG0NskNdGFPZd7FYflCzOq/vYJT/KW2IDiI2+0+D/sR17I6w6U" +
                        "OgBQOyqajwlLsLw24826oD80u8CkelZtrzgTNiVrLntstMr6kQZ3/pm89U8Ckp2flYrDsC7v0HMmOHqX" +
                        "ibmR7neXmwkOH4RoZds8UlB67XsFrcxLr3F68erNeow4Wr8EIhs6gwD2XIilT0rb7zMuXlrOM0PZbr1z" +
                        "ea5yawBouBkt6fYPPYka35Ze7dzHJTl1mLz+gqUNTAUnuxwwcmaTWaczPll1rVbLJTjUWLz490wODUUo" +
                        "uxs0QmOotQ9a36lRQ4OjvLbQmys70Tvms2aDQpSdp8FJ2sWlXEy51dZ58TYKLstxOb5dekT7ErBeX1dQ" +
                        "+HKbuLRuK4pa2b7de6vGGW2ndhcvSpJcOzXGXQxsu38q9zvmdl7f/X9GVFe24jNp9vFM9rXpquwo3Bl9" +
                        "1P8qmZSETdrfhW1TYqJchonNtHvM5Z/1pBQwLJ7f9vKmkN1nMz5Vde6Kj7KaJzYTPg+gw4NhSy7vQUn8" +
                        "5sduls72aH7PVJs3g336nXp6jvOw6/yxoPClt3eopM5v53ExKoV5TJWbFjBuQLyDMMC532OApfd3oKjW" +
                        "87PE4Lu9FKxsW4b1t8uoTeaDrF5vkGh8GW37wfkzNl5f+Cm+KEslopN5feZKwDVQ0Lhy063HOQHs3pfo" +
                        "/HRPV4uNq/X0neNWzecVx+r+Shc1N+qQ8/3/lfHFbdZdLcm2aF7PEJsqr7PrLzdVCwiOtST7CYdKquWL" +
                        "O5WnmnP0b7His3r9RK5bqJNW9+KsofJ1CXbfb/jZH487t7RyM6jO9suNlcQPxWNgEAbRkQLyeexYWuUP" +
                        "fb/hdQzi2qfrNlV15kRH+11idg8F4d8b7kCgjbKfvfJGAL6/SnSw918q+ZSETdzNhX1ZcVE+2wXmxXfZ" +
                        "yI3pqyBIKKKDk12VVOpiZs1r5rq4lHR/paIDSo4VTeala9Szz2hQ5Kd/or86m0gLhexCOh+jhEbRgDQ5" +
                        "iy7GOI8b6tOPb/+n87Im0R9pKxZ1leKZ0B7WiY27243iOCgjSF2OM56S6Re2ejf5bzuQP1m2hnQvVwqN" +
                        "tbrVPV3DhtjrwU6NNlJdCa9VqH7OEZsqr/PvAPSKyV4NnR4stO3nAmig+7hcrGxjiDaiMfOyr3yuacf+" +
                        "ejf5azYWXTvRosN2oTXbsVgmJzevuT3V3QY3qttM+fW2Qta91ixQRuI2HUO5FOur/pXvEJGuO3oO2HWa" +
                        "A1ZfNF8UTu03pFigxYftYtC9vh/qvlKjKJ9yv//N52d/mTOrLpvtNZxYoMWnmFXPYSv+EydEhyOF8N2w" +
                        "odUz755e3z18+RGfdAax4kNe0DRRt/ZoTAZu0g9V7++0bjy18fjqtsdulsSG0ZJ3tiioFE73W56bjePe" +
                        "QTH3+qO7pBll120le8Ha9ShSh1fATD1eGy9wD25WB8JjgSnYwe8Z8B7VkfebB5FsYeUsUdBMzEzbTuWL" +
                        "bPeE2KhOzHBLot3Ri9oLaPFpvL7zfTDPL0+dMF2s8s4fF0xMtlGakbruKXYPINFQa2we7cAK+q4W87Iw" +
                        "VvhmzUfb+1o/vFiU3G7qYiJAmfsJDa9325eZ+M9fCv8mL2ybNn6rXjjPxB7P0Khje9gp1eptWLT9Zch7" +
                        "OG+ss/aa6YmNOcWN5tdbiIodMZOt5v1grOb6DD7ZdkiomPF2O5mc1fBkdjMEJvdBCfzvFiCc6TYZAJEA" +
                        "a2206vUHLH58QttncIBzzP3N7qL27xG7fI3SJnDvfo1zc6jeJyoDdARqoSs+UZu2hKbXwSyBlERJ/prU" +
                        "lGTYup/L8fz47+l2NzpdUpiM/vHQN9y8PlsKzZ3ERyJDb7Mq29c1HvNYuMVrCQ2eo0a/Rq54lBEci7WE" +
                        "Dp9pFfWd2uxucPtRjebfW42z4ePPvULHVjR8NpvLzanC47EZk+xufO3nE9iJLHRa5Reo4p3YOGlhU7tv" +
                        "bUgfkeIzcm3G91s9r3Z7PpaVXWejhGbKkCIYlfaSGzOEJu7/+vjb6+VzIGh72aNDkwfO9hKbM4Smzt/y" +
                        "znqZnPi7UZic57Y3FVwjhOb0wRHYnOm2Oz4WhU9W0eKTRTKpNcric3ZYnOnW86xYnOK4Ehszhebu9xyj" +
                        "habR3OTbipsLRKb+4jN6becW4jNzqIjsbmX2Ox4y0F/QG8lNu8OLgpqlZ3E5p5is9MtBz0btxeb6Yd5e" +
                        "n3oosnOJ5qN/0TNnQqdrcSGRIyCzbKT2PgOaRb/KXHINW01RxlJbBLHgkJn7CQ2Epvp33HQfZbYJIpNh" +
                        "TBUxESXQ3bzhK5hXekU6J5IbGi0eQ7IkCQ28w48MrdKm7wNzImE9iqxyeGdGuV5eBIbic27w5y6cMFgE" +
                        "psgwOnu6IBld65YTdlRdMd0s5kyMbIOdMCyO1dspvxbHHTHJDbkIZ9ijg5YdhKb6p1Fd8wlNlMUtRri5" +
                        "PjogGV3tthMOIvojrnFZvrf/U8Wioza0AHL7nyxWS046I6FxWZ1oxkHd8cY6IBlJ7Gp3m90x1LERrec6" +
                        "nH+jI8OuNvuq9LunMrXv3/PGVH+qWKjW07f0NEBd9pJaNYJbd/m+X/40sVGt5yesXeKCJIL6RqJIxu/Y" +
                        "CEzqLBBZ1YmNne55XwCXTFUz9UVXYSondVvNL78bRGyZlD1HJ1NqdicestB4L4O9tknY+hIDV02SD9dt" +
                        "dw5DzKHChuUeYvYnHLLQaG+6zf7BsTUUmmLLG80/5VwR2Of5I/MosIGZdgmNne75bAHhF0CdMCVdkjNm" +
                        "fmtfJm5doxl8al6jrJqF5tTbjns4JCBMDGReNU2SL3ZNSA5J3/byuaR/XrO8v2yR3taIjan3nKuBoUOB" +
                        "BVjJl6FLbKUFXkrdqeyzs7YyEwqbNAeXWLDqJlVSEXznTHf9fcuv8Xh9bnVAxsv096q7fE8M+enWGgtn" +
                        "+w6auzMEeXh8Uf7c4tN9kJ5mlzpcwU4Q2ysGw464Gw7hnl27grB6aqxKw8znyxbtLew2NzplkNDfZom6" +
                        "lt1U4rkf/ZlFjQrJxqHqS1zb9H6OuxYBhn2aF8pYnO3W44FN+tmc3XIrRoqnjOLWZEfjYnWicbbyQ7tP" +
                        "dMO5ZMqNpm/FpkwJsRCB4K+nmXEY2KwDJnYFbZWvRU5J8S0+q54jvadLjZ3u+Wgw0MHMlFs0B6f7TL6z" +
                        "YjxqfaM2BNjeGYV9UE5lInN3W451ncNdCCWXbaYW/m+nnv+IHG7bCpea7tqZ/N4ZhX1QWssFZvMgxEFk" +
                        "u2P3kAyGTxyVsT81I+XG7qAHXYniA06c++8In7oDFvE5qRbDgK2Y7kzmWYLTUdtyBxexXniax7ahyUG1" +
                        "s3a8o88p3tAHbzXalSZkToiYLy+SF13Wm6LI8Or0rZD+CvrXyki1ozZM912s6n4VUFhdNhZS9G1kFl5M" +
                        "phl1RKJI7HJmOR1DHQ+S8SGVUT2+0g9Xj4DOpAJdnx37z2m9jKhLk8NWXPJjoP2slRsMt/tswGy8U652" +
                        "bB9X9mjS1hpp5tN5kRjPyrLxWbXWw5726o8UFmxK9YyqzZvHIlNxVS/x0RnM0ZsdrnlIGB3XfCKtUR4V" +
                        "drsOot3TCrmkxETnd8osZkqOCjMh92OC56xdBP7nlgTu09Xe1U1NyYu2s84scl8rfqCUPnnE+TdFrySU" +
                        "eYPCLrUp3w/e+23ek7e+OhcxopN5pJ6IWb6oQPptsvs8SpWd1873zLZ74FdM/yUB53taLHZ6ZZjDRwdS" +
                        "LedVXfW8+6+JDZZk7PjoLPdQmwm3nLYXx90IJ129hrlWnT2JrHJnV3GrXUbsZlyy0EOzA7fbPpW8W8mh" +
                        "F22TfTqn11PNN6KuVk50Z62E5tVtxwU6LuP0oxvh621PJXPO/pDPqyuqCMjZ+VsvLHRvrYUm+m3nNeho" +
                        "cPosvMuVZZfV58nvkplzSAzDjrPrcVm1S2HHRQ6jA47tvYK+44+n3Ps8FqLMqmYRzQmXTvq8O41IVpsh" +
                        "j9T/5VtRi1TbzYVvXljZs0LiXPSdxsv70o/ZAbfdAN1mCo2u9xyVglR5bJ5YzM7F7U95XbjZV3ph85m+" +
                        "9eoyiWqHBASGx0iYofk67ZB6s6y0e2mbrrojI4Um11vOeg6oMO9+kCK5qq2Y3vx2kts6iaJzuRYsXk0h" +
                        "oKw7OpGde/IFvfM56cIzrSNQWd0vNicfsuZtnieetBljdpJbDzTsX3QudxCbHTLsRdmtQW6sBG7qx4jc" +
                        "bt9V8/qNT/a/63ERrecaWv6tx50YaN2J9xupk0RncntxEa3nGmr2is4J9xupk1QYgNMBIVk2QGpjjR55" +
                        "RJt0uKc9Xz3202Uc7Y/OpdveV1O2ZUviIf2bdktKL095RWDd8Wwf/1uMc54vvvtpn3oRkJ0JhKb/wigw" +
                        "Cy7aYuQUY/V85WgeG4/aL6I3c63m4yZZsZA5yCxeaGOgmN/4TOHuzrWp96vbjaM6GTMAInB1IvE67JZP" +
                        "f/X/GjfEps3k0PhWXbTlmJFPV5Gll/Gc91ucjYCnYXE5oI3CvHOtxxrXRmG3l9MJgd6w4rE7PC1uHc+R" +
                        "/uV2CR9/LKAdw6/M9dz3xmvJc8xLKYZz3e93XTO2MqFzkFiY5H89RyFadkBqbYwyfhmg94GLaYZz3cUn" +
                        "CmLwvCX2BBTY8Cih4lIv9QU6T3jZvPI84iF5I3aXIGNxq7yX7oMT8mZ/iQ25NQYuCcIDtNvpth85e0QH" +
                        "Gv8TP+dtlbdXc+ZniU2zqkwkE8QHURIEBuWW7XgIONna+6wR+rusGF6ldgEJsKAPlVwLHwZjL5yZMR5F" +
                        "8OqvzJ3pCek7g4bpgeJTcJEGOB3E51MNlmxXr8LISuQnTsaD6m5w4bpQ2KTNBEG+u6C86n+iteo51zZt" +
                        "wx29FkzzojD1l5lz/TiEpvnj3dVTewal4G/k+ggfe0kNp79Qhh02nh6yPZB+/2RF3WU2FyPjOE4XXCYX" +
                        "qrF5rF3TE3MLQw5iBm5s2Ig9VbboL1IbIongQ7Csisukw7PHGCrt1XP6ab/c1hV77u83h4y/VAeb3OGn" +
                        "DO7OCQWytOy2xGH1dOq51GWq+p+zRvtI8MfZSGxyaANxkCHYtmB6UaYWb2sep4BZ1Xtz3kz+ojGQDlIb" +
                        "KKkSX90MJYdmTbdHH2NsvpY8TwLxorap91sGAYSm6zNI+MwQ7qyJdOGza26XxNY9iuehyE8BVhR/6SbD" +
                        "dN/SGy+EumPnwAzqNWCg9Yqsan7l87vZuDfvhxPdC8+akU4QE4ft4nC8F4pOkid08WmYqkQLlU2Ff0wM" +
                        "dG+PsZEA+hmw4zl2pZhvlJw2I6z+sqKw9aP2mfVx8ZB66uyQ+u9zJ8SpKrDg+Oi3C27KYisOjufVzLp7" +
                        "OM1V2VfVmy0b4mNRXLRc3SAll11+cjSWzV2Pu/m0dVbdV+f4jP9SWxWTQnMywyz69WKzZPVQ0YcEHvIL" +
                        "KNONkao4IAzU6fEJgC6y5UZKCsEaA9oDe/iob7VdmivUbvqPt7Fj9bs9Wd6TRGbr4T6U0+AGewq0ZHY/" +
                        "J9A1qzQOPXb9z5DWn1oIIlN36iZmVQJzpWgTBWbvglJbNw3L3S5u4d593zoXCy7Do5WDR3PO/p8zdHR1" +
                        "yPH9P6g+hhgUEAZpRFgZtN5y0EazKodiYPUU2WD1JdhU1X/VVymbqi+9IBQVhmhBJj5TBOcrEW2GKAsq" +
                        "+ys+jKeV9WeNSOoPgYEFFBGJQSYOe0kOtFvQCWwHUGz5vMpjqOksAvaE5WoJChVgYwRAuicLDskl2x4A" +
                        "hb3yHO+mpgHUyuVqSwwVYWMUQLMvHa/5aBMpthlzeY1Tnd/TB9UbWWBqSpkzBBgZibBYcjGbbNm8xwnX" +
                        "hUXgemBilwWmKpCxh4CzOwkOh7Cfp+s2XzF6fzD1O2qC03gCi6nUgLo7Cy70iI3D26xsz7sev0ffp34m" +
                        "FpddZUncFUlJ4YAM0PdcmyyWTyjcexKcy2Yel2ZyxO4qpITS4CZowTnPd0shllx2B2I2qN1u/OgCbrfH" +
                        "90N3dyRmadE5++yZHHLitO9xkzdodraEoWqlDNKgJnn3QUni1VmHHTOmXZM/aG8bYlCVcqZJcDM9Y6ik" +
                        "8UnOw475wx7podQvrZEoSrl7CHAzPZOgpPFJTuOZ8ZRH6aHaK7f/u0JU6pWEJQAM9/TRSeLRXYcdJbZd" +
                        "kwfKbnbE6ZUrSAMAWbGJwtOFofMOMwcs22ZPtJyL0maVr0CoQSYOZ8mOlm9Z8dBZ5dtx/SRmntZ4tQuF" +
                        "AwhwMz6JMHJ6jszDjKvKhumj9QaliVO7ULBGALMzE8RnayeM+Iws8q2ZerPzv073vICSrpS0CsCzMxPE" +
                        "Rx217MYPcdZvZVMTyW1Li+gpCsFRQgwsz9FdLJ6ZuMg86i2YWouqWV5ASVdKShKgJn/DoLzqNHqP6tvN" +
                        "I5VT/VztM4vu9I/Ywop7VLBT3+1et1ja+LM3kdsrTo6njP1l9YzppDSLhXcIsDswcRbzruarJ6rv+Ug+" +
                        "att2LmW1jOqmNJOFdwiwO7CJNHxik2V4Fisu54zM22paVxBLV0ryScCzD5MEJwroXl+Zk18t76z+7Hip" +
                        "TxnIackVZDRBNidWCk6V99rVnzLmTJYZoatNY8trJWCkr0SYPZileB8ur2seLWaskHs3FrrHl1cKwkl2" +
                        "01wHrtr1f38/JOPFWOVoLJbyZxnNnaK/fgCU7pUEC8BZj86DyUrNhWvVl6mFX7snCpqMGNuUaTZhQwqC" +
                        "bA78sk+s8avHO/+ZL9edQpohA8zo0iesO82hYY7VYAIAWZPKg9pptB8ivXu9euTkEWYZviyc8nI6Y6xV" +
                        "bHuLuWYQYDdlY5bzqMv9NXqITCseKDffDI4MzGYmTBxy2y3K7iMhAIjBJh9qbzlvLuBvNb/6XvNu7qQ3" +
                        "ifZsHMYUfuWRY8gd98i2J2pvuVkvl7tMlVmBqN6YgpH3nVHNadiygiwe1MtOp9uNuh3mKmvS9aNzZpD2" +
                        "QJ4AlvFfrqOenLJ5ywC7O50Cs67H8arXd5lzxnmI7eNaUC3m5EjXFoUuz/VovPplrL7dxyW89Kl+JT8i" +
                        "CZGkr1PUewOVQpO9DvOxKmxfCf28Kemo5oZTfrs4tg9qhSd6HecSZNiuU6q/W0txzU0nviZBbJ71CU47" +
                        "HecKdNheU6p+7KOI5vagvyZRbL7VCk67KvVlImwDKfUDdVxdHMQARllEmD3qVJw3vX16WNyJoNILJZfJ" +
                        "Fe7L9uc/naqfURbJvTs1Tuf7OYn7y/LLJtNS7xbNNlCUkmeCbB71XHLmSo2Hlbbbhvb7LaNqvB2Auxud" +
                        "YhOOwQjIctoWv1UPWyzU38hqKZl3EbAs18dr1VtAC4SsWwm1ByugW1aghNGfrsAnh07WXQ8PI5YGk/jE" +
                        "pwjRt/ahHfPXv1aiy5KxrIoKmNNWLb5h/2aapV1VwLePTvplsMy2HXWl3WzEHS7OXINWpry7NoJguPpu" +
                        "2UgK5IIxgrq98zp2bWd/8bK0+/Rm+EBohvO0StR3px353b6luPpsRz8hAQeMBKcCZPbtwbvzu3wauXpb" +
                        "d9JOir3AJLgOEDL5RsB795NveV4+7ndWgjU7UY+omHv3k285Xh6GTGE7iI8oHS76Z7Sufm8+zflluOp/" +
                        "9xpAp15gElwALAygQh492+14HjqhoCcbuQBJ8E5fSt6+/Pu4ArR8dbaS3RwNgEcPJyblObdwU7B8dZ4k" +
                        "xHibQokzkqWdQS8e1gtOt666khtHtkDdPOWVf5AAp49rPzbKm89A9HOKUlQ58xClfzzj3cfM2853ho0P" +
                        "4CAF64+GgNwZUITiOzjsy+d+JeDN7cn1219vJAlOLddmfLGIzvpER1vvnIQJybwwpbgnLgNM3qK7CQjO" +
                        "N48MyhtWoUXugRn04FvUnZkLy3RicTeBN/cMiPwJTpz57p7ZdG9fPg/c4jE3J3nmPojQ5DgjBnjkYVEd" +
                        "zPD/0iwK5uKDmVl7cp9NoHobkb8zya7sLvIUHTDWTi4m6SO7ifrfxOs69pkB/Jqv65yZb4Dgeh+ov53Y" +
                        "DmiR3QgV3YjGlERxxLI2NFPMY6FNrWxjGFO7U11nUEgY0etvyo/g9QGXWQMc4M2VeLGBDJ2VN8bhyxAx" +
                        "jCHtKIyDiUQ3dFDsezblga67+xOrTy6k7rRDN4MDXfwcG5WmnbxBgPXkG8w5MEtZuyfbjSDB/xamga+0" +
                        "bAOKTVr5yQ0Gy5E1vA3bF0lNxPQrjUDn5pOizB1MvvXlbVbus3svwt/OtBSHDTMIa1op4YMYmIZWo6JU" +
                        "9mvJu3RfjNbVrGWZRn6rRNn7o1em7ZeBa54LQ7H6+7W2pe7b0Cw/+wF0q9VcCDD3LUfwwZyQjlaqhOmm" +
                        "NdDxT7ohyhvPkdEqliyI8DcpImK+UtkbrI8nja1cB5q+/pUzVsis+9OtFeuJWxH3pqwcr4SmtZRnpNMS" +
                        "3nOLL860TzPmudx3VQvqH4Ja1dG86vlq+gFBDqWVsKTNzjNK4+lIi0i0LXEEh5uwJ1z0Wy42cg6SKB7u" +
                        "bXg3wcm/sEFlvt+BFYs/SPnfrT8FYuzn508DyOw8jCceOtZzfNEpocdObUz4ZC81rDDVCZx24GXahSBP" +
                        "wQmHZ6rWipGtkvvO4pyxbwU8yACux6+O9R90JqpFRFY/7codxANtkftpQjcigB7QGQf+08ObrVcalYE3" +
                        "hGQiMREpPublLZYBI4gIOGJC88Ri6AmRKCbgMTHFp/umSifCNyCgMTnFmNWkyIwj8BdxGceeVUkAiLwm" +
                        "8COIqTRiYAIHEZgtRAdhlPtiIAIiIAIiIAIiIAI3IfA/wApuuh7UU5lUQAAAABJRU5ErkJgggtBAAEAA" +
                        "AD/////AQAAAAAAAAAMAgAAABtEZXZFeHByZXNzLlh0cmFSZXBvcnRzLnY2LjIFAQAAACxEZXZFeHByZ" +
                        "XNzLlh0cmFSZXBvcnRzLlVJLlNlcmlhbGl6YWJsZVN0cmluZwEAAAAFVmFsdWUBAgAAAAYDAAAApQR7X" +
                        "HJ0ZjFcYW5zaVxhbnNpY3BnMTI1MlxkZWZmMHtcZm9udHRibHtcZjBcZm5pbCBBcmlhbDt9e1xmMVxmb" +
                        "mlsXGZjaGFyc2V0MCBBcmlhbDt9e1xmMlxmbmlsIFRpbWVzIE5ldyBSb21hbjt9fQ0Ke1xjb2xvcnRib" +
                        "CA7XHJlZDBcZ3JlZW4wXGJsdWUwO30NClx2aWV3a2luZDRcdWMxXHBhcmRcY2YxXGxhbmcyMDU3XGYwX" +
                        "GZzMTggQW10IGZcZjFcJ2ZjXGYwIHIgRXJ3YWNoc2VuZVxsYW5nMjA1NVxmMSBuXGxhbmcyMDU3XGYwI" +
                        "C0gdW5kIEtpbmRlc3NjaHV0elxjZjBcZjJcZnMyNFxwYXINClxjZjFcZjBcZnMxOCBQcmVkaWdlcmdhc" +
                        "3NlIDEwXGNmMFxmMlxmczI0XHBhcg0KXGNmMVxmMFxmczE4IFBvc3RmYWNoIDE1NFxjZjBcZjJcZnMyN" +
                        "FxwYXINClxjZjFcZjBcZnMxOCAzMDAwIEJlcm4gN1xjZjBcZjJcZnMyNFxwYXINClxjZjFcZjBcZnMxO" +
                        "CBUZWxlZm9uIDAzMSAzMjEgNjMgMTZcY2YwXGYyXGZzMjRccGFyDQpcY2YxXGYwXGZzMTggZWtzQGJlc" +
                        "m4uY2hcY2YwXGYyXGZzMjRccGFyDQpcY2YxXGYwXGZzMTggd3d3LmJlcm4uY2hcY2YwXGYyXGZzMjRcc" +
                        "GFyDQp9DQoLQQABAAAA/////wEAAAAAAAAADAIAAAAbRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy52Ni4yB" +
                        "QEAAAAsRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy5VSS5TZXJpYWxpemFibGVTdHJpbmcBAAAABVZhbHVlA" +
                        "QIAAAAGAwAAAIQCe1xydGYxXGFuc2lcYW5zaWNwZzEyNTJcZGVmZjB7XGZvbnR0Ymx7XGYwXGZuaWxcZ" +
                        "mNoYXJzZXQwIEFyaWFsO317XGYxXGZuaWwgVGltZXMgTmV3IFJvbWFuO319DQp7XGNvbG9ydGJsIDtcc" +
                        "mVkMFxncmVlbjBcYmx1ZTA7fQ0KXHZpZXdraW5kNFx1YzFccGFyZFxjZjFcbGFuZzIwNTVcYlxmczE4I" +
                        "FN0YWR0IEJlcm5cYjBccGFyDQpEaXJla3Rpb24gZlwnZmNyIFNpY2hlcmhlaXRccGFyDQpVbXdlbHQgd" +
                        "W5kIEVuZXJnaWVcY2YwXGYxXGZzMjRccGFyDQp9DQoL";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrRichText2 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
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
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPictureBox1,
                        this.xrRichText2,
                        this.xrLabel25,
                        this.xrRichText1,
                        this.xrLabel1});
            this.PageHeader.Height = 381;
            this.PageHeader.Name = "PageHeader";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
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
            this.Detail.Height = 530;
            this.Detail.Name = "Detail";
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.Location = new System.Drawing.Point(367, 0);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.Size = new System.Drawing.Size(32, 58);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // xrRichText2
            // 
            this.xrRichText2.Location = new System.Drawing.Point(408, 36);
            this.xrRichText2.Name = "xrRichText2";
            this.xrRichText2.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichText2.RtfText")));
            this.xrRichText2.Size = new System.Drawing.Size(242, 92);
            // 
            // xrLabel25
            // 
            this.xrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AdresseMehrzeilig", "")});
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel25.Location = new System.Drawing.Point(408, 158);
            this.xrLabel25.Multiline = true;
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.ParentStyleUsing.UseFont = false;
            this.xrLabel25.Size = new System.Drawing.Size(242, 67);
            this.xrLabel25.Text = "xrLabel25";
            // 
            // xrRichText1
            // 
            this.xrRichText1.Font = new System.Drawing.Font("Arial", 9F);
            this.xrRichText1.Location = new System.Drawing.Point(0, 142);
            this.xrRichText1.Name = "xrRichText1";
            this.xrRichText1.ParentStyleUsing.UseFont = false;
            this.xrRichText1.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichText1.RtfText")));
            this.xrRichText1.Size = new System.Drawing.Size(258, 108);
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "MandantName", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel1.Location = new System.Drawing.Point(408, 142);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(242, 16);
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel24
            // 
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel24.Location = new System.Drawing.Point(0, 475);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.ParentStyleUsing.UseFont = false;
            this.xrLabel24.Size = new System.Drawing.Size(250, 17);
            this.xrLabel24.Text = ".......................................................";
            // 
            // xrLabel23
            // 
            this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "EmpfaengerName", "")});
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel23.Location = new System.Drawing.Point(0, 500);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.ParentStyleUsing.UseFont = false;
            this.xrLabel23.Size = new System.Drawing.Size(216, 17);
            this.xrLabel23.Text = "xrLabel23";
            // 
            // xrLabel22
            // 
            this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ErhaltenAm", "{0:dd/MM/yyyy}")});
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel22.Location = new System.Drawing.Point(125, 375);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.ParentStyleUsing.UseFont = false;
            this.xrLabel22.Size = new System.Drawing.Size(116, 17);
            this.xrLabel22.Text = "xrLabel22";
            // 
            // xrLabel21
            // 
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel21.Location = new System.Drawing.Point(0, 375);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.ParentStyleUsing.UseFont = false;
            this.xrLabel21.Size = new System.Drawing.Size(125, 17);
            this.xrLabel21.Text = "Betrag erhalten am";
            // 
            // xrLabel20
            // 
            this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "EmpfaengerOrt", "")});
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel20.Location = new System.Drawing.Point(188, 317);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.ParentStyleUsing.UseFont = false;
            this.xrLabel20.Size = new System.Drawing.Size(195, 17);
            this.xrLabel20.Text = "xrLabel20";
            // 
            // xrLabel19
            // 
            this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "EmpfaengerPLZ", "")});
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel19.Location = new System.Drawing.Point(150, 317);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.ParentStyleUsing.UseFont = false;
            this.xrLabel19.Size = new System.Drawing.Size(38, 17);
            this.xrLabel19.Text = "xrLabel19";
            // 
            // xrLabel18
            // 
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "EmpfaengerStrasse", "")});
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel18.Location = new System.Drawing.Point(150, 300);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.ParentStyleUsing.UseFont = false;
            this.xrLabel18.Size = new System.Drawing.Size(233, 17);
            this.xrLabel18.Text = "xrLabel18";
            // 
            // xrLabel17
            // 
            this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "EmpfaengerName", "")});
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel17.Location = new System.Drawing.Point(150, 283);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.ParentStyleUsing.UseFont = false;
            this.xrLabel17.Size = new System.Drawing.Size(233, 17);
            this.xrLabel17.Text = "xrLabel17";
            // 
            // xrLabel16
            // 
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel16.Location = new System.Drawing.Point(0, 283);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.ParentStyleUsing.UseFont = false;
            this.xrLabel16.Size = new System.Drawing.Size(150, 17);
            this.xrLabel16.Text = "Ausbezahlt an:";
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:CHF #.00}")});
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel15.Location = new System.Drawing.Point(433, 233);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.ParentStyleUsing.UseFont = false;
            this.xrLabel15.Size = new System.Drawing.Size(217, 25);
            this.xrLabel15.Text = "xrLabel15";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.Location = new System.Drawing.Point(0, 233);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(217, 25);
            this.xrLabel2.Text = "Ausbezahlter Betrag";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // xrLine1
            // 
            this.xrLine1.Location = new System.Drawing.Point(0, 258);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(650, 9);
            // 
            // xrLabel14
            // 
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Journalablageort", "")});
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel14.Location = new System.Drawing.Point(150, 133);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.ParentStyleUsing.UseFont = false;
            this.xrLabel14.Size = new System.Drawing.Size(304, 17);
            this.xrLabel14.Text = "xrLabel14";
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SollKonto", "")});
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel13.Location = new System.Drawing.Point(150, 154);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.ParentStyleUsing.UseFont = false;
            this.xrLabel13.Size = new System.Drawing.Size(304, 17);
            this.xrLabel13.Text = "xrLabel13";
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BewilligtDurch", "")});
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel12.Location = new System.Drawing.Point(150, 92);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.ParentStyleUsing.UseFont = false;
            this.xrLabel12.Size = new System.Drawing.Size(184, 16);
            this.xrLabel12.Text = "xrLabel12";
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Stichtag", "{0:dd/MM/yyyy}")});
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel11.Location = new System.Drawing.Point(150, 112);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.ParentStyleUsing.UseFont = false;
            this.xrLabel11.Size = new System.Drawing.Size(184, 17);
            this.xrLabel11.Text = "xrLabel11";
            // 
            // xrLabel10
            // 
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Mandatstraeger", "")});
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel10.Location = new System.Drawing.Point(150, 71);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.ParentStyleUsing.UseFont = false;
            this.xrLabel10.Size = new System.Drawing.Size(184, 17);
            this.xrLabel10.Text = "xrLabel10";
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AusbezahltDurch", "")});
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel9.Location = new System.Drawing.Point(150, 50);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.Size = new System.Drawing.Size(184, 17);
            this.xrLabel9.Text = "xrLabel9";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel8.Location = new System.Drawing.Point(0, 133);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.Size = new System.Drawing.Size(150, 17);
            this.xrLabel8.Text = "Journalablageort:";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel7.Location = new System.Drawing.Point(0, 154);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.Size = new System.Drawing.Size(150, 17);
            this.xrLabel7.Text = "Soll-Konto:";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel6.Location = new System.Drawing.Point(0, 92);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.Size = new System.Drawing.Size(150, 17);
            this.xrLabel6.Text = "Bewilligt durch:";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel5.Location = new System.Drawing.Point(0, 112);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(150, 17);
            this.xrLabel5.Text = "Stichtag:";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel4.Location = new System.Drawing.Point(0, 71);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(150, 17);
            this.xrLabel4.Text = "Mandatsträger:";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel3.Location = new System.Drawing.Point(0, 50);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(150, 17);
            this.xrLabel3.Text = "Ausbezahlt durch:";
            // 
            // xrPanel1
            // 
            this.xrPanel1.BackColor = System.Drawing.Color.LightGray;
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblBelegNr,
                        this.lblTitel});
            this.xrPanel1.Location = new System.Drawing.Point(0, 0);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.ParentStyleUsing.UseBackColor = false;
            this.xrPanel1.Size = new System.Drawing.Size(650, 20);
            // 
            // lblBelegNr
            // 
            this.lblBelegNr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BelegNr", "")});
            this.lblBelegNr.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblBelegNr.Location = new System.Drawing.Point(500, 0);
            this.lblBelegNr.Name = "lblBelegNr";
            this.lblBelegNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblBelegNr.ParentStyleUsing.UseFont = false;
            this.lblBelegNr.Size = new System.Drawing.Size(150, 20);
            this.lblBelegNr.Text = "lblBelegNr";
            this.lblBelegNr.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblTitel
            // 
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitel.Location = new System.Drawing.Point(0, 0);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTitel.ParentStyleUsing.UseFont = false;
            this.lblTitel.Size = new System.Drawing.Size(217, 20);
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
            this.Margins = new System.Drawing.Printing.Margins(100, 77, 100, 100);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).EndInit();
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
        @Journalablageort varchar(25)




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
  @Journalablageort = LOV.Text
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



SELECT @AnVornameNachname AS EmpfaengerName, @AnStrasse AS EmpfaengerStrasse, @AnPLZ AS EmpfaengerPLZ,
@AnOrt AS EmpfaengerOrt,	@ErhaltenAm AS ErhaltenAm, @Betrag AS Betrag, @BelegNr AS BelegNr,	
@AusbezDurch AS AusbezahltDurch, @Mandatstraeger AS Mandatstraeger, @BewilligtDurch AS BewilligtDurch,	
@SollKto AS SollKonto, @Stichtag AS Stichtag, @MandantName AS MandantName, 
@MandantAdresseMehrzeilig AS AdresseMehrzeilig, @Journalablageort AS Journalablageort' , ContextForms =  N'FrmVmKasse' , ParentReportName =  null , ReportSortKey =  null 
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'VmFibuKassenbeleg' ;


