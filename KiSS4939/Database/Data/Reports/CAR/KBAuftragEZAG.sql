-- Insert Script for KBAuftragEZAG
DELETE FROM XQuery WHERE QueryName LIKE 'KBAuftragEZAG' OR ParentReportName LIKE 'KBAuftragEZAG'
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'KBAuftragEZAG' ,  N'KB - Auftrag EZAG' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS4.NET\KiSS4.Main\bin\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Projects\KiSS4.NET\KiSS4.Main\bin\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRPageBreak xrPageBreak1;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRTable xrTable4;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell31;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell33;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRTable xrTable5;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell37;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow11;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell38;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow9;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell40;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell32;
        private DevExpress.XtraReports.UI.XRTable xrTable3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell23;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell24;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell26;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell25;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell27;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell28;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell29;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell30;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell13;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell15;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell16;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell17;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell18;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell19;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell20;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell21;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell22;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell11;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.Subreport KBAuftragEZAGDetail;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
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
                        "AAAAbQIREVDTEFSRSBAa2JaYWhsdW5nc2xhdWZJRCBJTlQNClNFVCBAa2JaYWhsdW5nc2xhdWZJRCA9I" +
                        "ElTTlVMTChudWxsLCAyKQ0KDQpTRUxFQ1QNCiAgIEtCWi5LYlphaGx1bmdzbGF1ZklELA0KICAgS0JaL" +
                        "kZpbGVQYXRoLA0KICAgS0JaLlRvdGFsQmV0cmFnLA0KICAgS0JaLlRyYW5zZmVyRGF0dW0sDQogICBLQ" +
                        "louS2JaYWhsdW5nc2tvbnRvSUQsDQogICBLQlouVXNlcklELA0KICAgS0JaLlRyYW5zZmVyaWVydCwNC" +
                        "g0KICAgLS0tIFNvemlhbGRpZW5zdA0KICAgU296aWFsRGllbnN0ID0gSVNOVUxMKChTRUxFQ1QgZGJvL" +
                        "mZuWENvbmZpZygnU296aWFsRGllbnN0L0FsbGdlbWVpbi9OYW1lJywgJzIwMDEwMTAxJykpLCAnJyksD" +
                        "QogICBTb3ppYWxBZHJlc3NlID0gSVNOVUxMKChTRUxFQ1QgZGJvLmZuWENvbmZpZygnU296aWFsRGllb" +
                        "nN0L0FsbGdlbWVpbi9BZHJlc3NlJywgJzIwMDEwMTAxJykpLCAnJyksDQogICBTb3ppYWxQbHogPSBJU" +
                        "05VTEwoKFNFTEVDVCBkYm8uZm5YQ29uZmlnKCdTb3ppYWxEaWVuc3QvQWxsZ2VtZWluL1BMWicsICcyM" +
                        "DAxMDEwMScpKSwgJycpLA0KICAgU296aWFsT3J0ID0gSVNOVUxMKChTRUxFQ1QgZGJvLmZuWENvbmZpZ" +
                        "ygnU296aWFsRGllbnN0L0FsbGdlbWVpbi9PcnQnLCAnMjAwMTAxMDEnKSksICcnKSwNCg0KICAgLS0tI" +
                        "EtvbnRvaW5mb3JtYXRpb24NCiAgIEtUTy5OYW1lLA0KICAgS1RPLlZlcnRyYWdOciwNCiAgIEtUTy5Lb" +
                        "250b05yLA0KICAgVGF4YmVsYXN0dW5nc0tvbnRvTnIgPSBLVE8uS29udG9OciwNCiAgIEtUTy5CYUJhb" +
                        "mtJRCwJDQoNCiAgIC0tLSBUcmFuc2ZlcmRhdGVuDQogICBBbnphaGxUcmFuc2FrdGlvbmVuID0gKFNFT" +
                        "EVDVCBDT1VOVCgqKSBGUk9NIEtiVHJhbnNmZXIgV0hFUkUgS2JaYWhsdW5nc2xhdWZJRCA9IEBrYlpha" +
                        "Gx1bmdzbGF1ZklEKQ0KDQpGUk9NIEtiWmFobHVuZ3NsYXVmICAgICAgICAgIEtCWg0KICAgTEVGVCBKT" +
                        "0lOIEtiWmFobHVuZ3Nrb250byBLVE8gT04gS1RPLktiWmFobHVuZ3Nrb250b0lEID0gS0JaLktiWmFob" +
                        "HVuZ3Nrb250b0lEDQoNCldIRVJFIEtCWi5LYlphaGx1bmdzbGF1ZklEID0gQGtiWmFobHVuZ3NsYXVmS" +
                        "UQ=";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrPageBreak1 = new DevExpress.XtraReports.UI.XRPageBreak();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.KBAuftragEZAGDetail = new DevExpress.XtraReports.UI.Subreport();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageBreak1,
                        this.xrLine2,
                        this.xrLine1,
                        this.xrTable4,
                        this.xrLabel6,
                        this.xrPanel1,
                        this.xrTable3,
                        this.xrTable2,
                        this.xrTable1,
                        this.xrLabel5,
                        this.xrLabel3,
                        this.xrLabel2,
                        this.xrLabel1});
            this.ReportHeader.Dpi = 254F;
            this.ReportHeader.Height = 2431;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // PageHeader
            // 
            this.PageHeader.Dpi = 254F;
            this.PageHeader.Height = 89;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.ParentStyleUsing.UseBorders = false;
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.KBAuftragEZAGDetail});
            this.Detail.Dpi = 254F;
            this.Detail.Height = 85;
            this.Detail.Name = "Detail";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Dpi = 254F;
            this.GroupHeader1.Height = 81;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrPageBreak1
            // 
            this.xrPageBreak1.Dpi = 254F;
            this.xrPageBreak1.Location = new System.Drawing.Point(0, 2352);
            this.xrPageBreak1.Name = "xrPageBreak1";
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 254F;
            this.xrLine2.LineWidth = 3;
            this.xrLine2.Location = new System.Drawing.Point(869, 2116);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.Size = new System.Drawing.Size(825, 20);
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 254F;
            this.xrLine1.LineWidth = 3;
            this.xrLine1.Location = new System.Drawing.Point(869, 2243);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(825, 20);
            // 
            // xrTable4
            // 
            this.xrTable4.Dpi = 254F;
            this.xrTable4.Location = new System.Drawing.Point(43, 2116);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow7});
            this.xrTable4.Size = new System.Drawing.Size(468, 114);
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 254F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel6.Location = new System.Drawing.Point(869, 1989);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.Size = new System.Drawing.Size(254, 114);
            this.xrLabel6.Text = "Unterschrift\r\nSignature\r\nFirma";
            // 
            // xrPanel1
            // 
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrTable5});
            this.xrPanel1.Dpi = 254F;
            this.xrPanel1.Location = new System.Drawing.Point(0, 339);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.ParentStyleUsing.UseBorders = false;
            this.xrPanel1.Size = new System.Drawing.Size(1100, 381);
            // 
            // xrTable3
            // 
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Dpi = 254F;
            this.xrTable3.Location = new System.Drawing.Point(0, 1249);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.ParentStyleUsing.UseBorders = false;
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow5,
                        this.xrTableRow6});
            this.xrTable3.Size = new System.Drawing.Size(1671, 178);
            // 
            // xrTable2
            // 
            this.xrTable2.Dpi = 254F;
            this.xrTable2.Location = new System.Drawing.Point(0, 974);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.ParentStyleUsing.UseBorders = false;
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow3,
                        this.xrTableRow4});
            this.xrTable2.Size = new System.Drawing.Size(1671, 241);
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Dpi = 254F;
            this.xrTable1.Location = new System.Drawing.Point(0, 762);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.ParentStyleUsing.UseBorders = false;
            this.xrTable1.ParentStyleUsing.UseBorderWidth = false;
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow1,
                        this.xrTableRow2});
            this.xrTable1.Size = new System.Drawing.Size(1671, 178);
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 254F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel5.Location = new System.Drawing.Point(1164, 318);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(487, 404);
            this.xrLabel5.Text = "einsenden unter dafür vorgesehenem\r\nUmschlag - an die folgende Adresse\r\n\r\nenvoyer" +
                " - sous l\''envelope prévus -\r\nà l\''adresse suivante\r\n\r\n\r\nDirektion Zahlungsverkehr" +
                " GD PTT\r\nBetrieb\r\n3002 Bern";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel3.Location = new System.Drawing.Point(677, 190);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(401, 127);
            this.xrLabel3.Text = "(gemäss Anmeldung)\r\n(salon demande d\''adhesion)\r\n(secondo domanda di adasione)";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrLabel2.Location = new System.Drawing.Point(0, 190);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(676, 127);
            this.xrLabel2.Text = "Adresse für die Rücksendung der Datenträger\r\nAdresse pour le renvoi des supports " +
                "de données\r\nAdresse par la rispdizione del supporti dai dati\r\n\r\n";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.Location = new System.Drawing.Point(0, 0);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(445, 150);
            this.xrLabel1.Text = "Auftrag EZAG\r\nOrdre OPAE\r\nOrdine OPAE";
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell31,
                        this.xrTableCell33});
            this.xrTableRow7.Dpi = 254F;
            this.xrTableRow7.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableRow7.Name = "xrTableRow7";
            this.xrTableRow7.ParentStyleUsing.UseFont = false;
            this.xrTableRow7.Size = new System.Drawing.Size(468, 114);
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Dpi = 254F;
            this.xrTableCell31.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell31.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell31.Multiline = true;
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell31.ParentStyleUsing.UseFont = false;
            this.xrTableCell31.Size = new System.Drawing.Size(170, 114);
            this.xrTableCell31.Text = "Datum\r\nDate\r\nData";
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TransferDatum", "{0:MM/dd/yyyy}")});
            this.xrTableCell33.Dpi = 254F;
            this.xrTableCell33.Location = new System.Drawing.Point(170, 0);
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell33.Size = new System.Drawing.Size(298, 114);
            this.xrTableCell33.Text = "xrTableCell33";
            this.xrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTable5
            // 
            this.xrTable5.Dpi = 254F;
            this.xrTable5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable5.Location = new System.Drawing.Point(64, 64);
            this.xrTable5.Name = "xrTable5";
            this.xrTable5.ParentStyleUsing.UseBorders = false;
            this.xrTable5.ParentStyleUsing.UseFont = false;
            this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow8,
                        this.xrTableRow11,
                        this.xrTableRow9});
            this.xrTable5.Size = new System.Drawing.Size(591, 152);
            this.xrTable5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow8
            // 
            this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell37});
            this.xrTableRow8.Dpi = 254F;
            this.xrTableRow8.Name = "xrTableRow8";
            this.xrTableRow8.Size = new System.Drawing.Size(591, 51);
            // 
            // xrTableRow11
            // 
            this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell38});
            this.xrTableRow11.Dpi = 254F;
            this.xrTableRow11.Name = "xrTableRow11";
            this.xrTableRow11.Size = new System.Drawing.Size(591, 51);
            // 
            // xrTableRow9
            // 
            this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell40,
                        this.xrTableCell32});
            this.xrTableRow9.Dpi = 254F;
            this.xrTableRow9.Name = "xrTableRow9";
            this.xrTableRow9.Size = new System.Drawing.Size(591, 50);
            // 
            // xrTableCell37
            // 
            this.xrTableCell37.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SozialDienst", "")});
            this.xrTableCell37.Dpi = 254F;
            this.xrTableCell37.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell37.Size = new System.Drawing.Size(591, 51);
            this.xrTableCell37.Text = "xrTableCell37";
            this.xrTableCell37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SozialAdresse", "")});
            this.xrTableCell38.Dpi = 254F;
            this.xrTableCell38.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell38.Size = new System.Drawing.Size(591, 51);
            this.xrTableCell38.Text = "xrTableCell38";
            this.xrTableCell38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SozialPlz", "")});
            this.xrTableCell40.Dpi = 254F;
            this.xrTableCell40.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell40.Size = new System.Drawing.Size(84, 50);
            this.xrTableCell40.Text = "xrTableCell40";
            this.xrTableCell40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SozialOrt", "")});
            this.xrTableCell32.Dpi = 254F;
            this.xrTableCell32.Location = new System.Drawing.Point(84, 0);
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell32.Size = new System.Drawing.Size(507, 50);
            this.xrTableCell32.Text = "xrTableCell32";
            this.xrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell23,
                        this.xrTableCell24,
                        this.xrTableCell26,
                        this.xrTableCell25});
            this.xrTableRow5.Dpi = 254F;
            this.xrTableRow5.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.ParentStyleUsing.UseFont = false;
            this.xrTableRow5.Size = new System.Drawing.Size(1671, 114);
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell27,
                        this.xrTableCell28,
                        this.xrTableCell29,
                        this.xrTableCell30});
            this.xrTableRow6.Dpi = 254F;
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Size = new System.Drawing.Size(1671, 64);
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Dpi = 254F;
            this.xrTableCell23.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell23.Multiline = true;
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell23.Size = new System.Drawing.Size(318, 114);
            this.xrTableCell23.Text = "Währungscode\r\nCode de monnaie\r\ncodica dalla valuta";
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.Dpi = 254F;
            this.xrTableCell24.Location = new System.Drawing.Point(318, 0);
            this.xrTableCell24.Multiline = true;
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell24.Size = new System.Drawing.Size(469, 114);
            this.xrTableCell24.Text = "Anzahl Transaktionen\r\nNombre de transactions\r\nNumero della transazioni";
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.Dpi = 254F;
            this.xrTableCell26.Location = new System.Drawing.Point(787, 0);
            this.xrTableCell26.Multiline = true;
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell26.Size = new System.Drawing.Size(379, 114);
            this.xrTableCell26.Text = "Totalbetrag\r\nMontent total\r\nImparto totale";
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Dpi = 254F;
            this.xrTableCell25.Location = new System.Drawing.Point(1166, 0);
            this.xrTableCell25.Multiline = true;
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell25.Size = new System.Drawing.Size(505, 114);
            this.xrTableCell25.Text = "Mitteilungen/Bemerkungen\r\nCommunications/Remarques\r\nCommunicazioni/Osservazioni";
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.Dpi = 254F;
            this.xrTableCell27.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell27.Size = new System.Drawing.Size(318, 64);
            this.xrTableCell27.Text = "01";
            this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AnzahlTransaktionen", "")});
            this.xrTableCell28.Dpi = 254F;
            this.xrTableCell28.Location = new System.Drawing.Point(318, 0);
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell28.Size = new System.Drawing.Size(469, 64);
            this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TotalBetrag", "{0:0.00}")});
            this.xrTableCell29.Dpi = 254F;
            this.xrTableCell29.Location = new System.Drawing.Point(787, 0);
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell29.Size = new System.Drawing.Size(379, 64);
            this.xrTableCell29.Text = "xrTableCell29";
            this.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.Dpi = 254F;
            this.xrTableCell30.Location = new System.Drawing.Point(1166, 0);
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell30.Size = new System.Drawing.Size(505, 64);
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell13,
                        this.xrTableCell14,
                        this.xrTableCell15,
                        this.xrTableCell16,
                        this.xrTableCell17});
            this.xrTableRow3.Dpi = 254F;
            this.xrTableRow3.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.ParentStyleUsing.UseFont = false;
            this.xrTableRow3.Size = new System.Drawing.Size(1671, 114);
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell18,
                        this.xrTableCell19,
                        this.xrTableCell20,
                        this.xrTableCell21,
                        this.xrTableCell22});
            this.xrTableRow4.Dpi = 254F;
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.ParentStyleUsing.UseBorders = false;
            this.xrTableRow4.Size = new System.Drawing.Size(1671, 127);
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell13.Dpi = 254F;
            this.xrTableCell13.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableCell13.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell13.Multiline = true;
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell13.ParentStyleUsing.UseBorders = false;
            this.xrTableCell13.ParentStyleUsing.UseFont = false;
            this.xrTableCell13.Size = new System.Drawing.Size(173, 114);
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell14.Dpi = 254F;
            this.xrTableCell14.Location = new System.Drawing.Point(173, 0);
            this.xrTableCell14.Multiline = true;
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell14.ParentStyleUsing.UseBorders = false;
            this.xrTableCell14.Size = new System.Drawing.Size(421, 114);
            this.xrTableCell14.Text = "Lastkontonummer\r\nNuméro du compte de débit\r\nNumero del conto d\''addabitamento";
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell15.Dpi = 254F;
            this.xrTableCell15.Location = new System.Drawing.Point(594, 0);
            this.xrTableCell15.Multiline = true;
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell15.ParentStyleUsing.UseBorders = false;
            this.xrTableCell15.Size = new System.Drawing.Size(595, 114);
            this.xrTableCell15.Text = "Taxbelastungskontonummer\r\nNuméro du compte de débit des taxes\r\nNumero del conto p" +
                "er d\''addabitamento della tasse";
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell16.Dpi = 254F;
            this.xrTableCell16.Location = new System.Drawing.Point(1189, 0);
            this.xrTableCell16.Multiline = true;
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell16.ParentStyleUsing.UseBorders = false;
            this.xrTableCell16.Size = new System.Drawing.Size(211, 114);
            this.xrTableCell16.Text = "SA - Nummer\r\nNuméro OG\r\nNumero OC";
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell17.Dpi = 254F;
            this.xrTableCell17.Location = new System.Drawing.Point(1400, 0);
            this.xrTableCell17.Multiline = true;
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell17.ParentStyleUsing.UseBorders = false;
            this.xrTableCell17.Size = new System.Drawing.Size(271, 114);
            this.xrTableCell17.Text = "Fälligkeitsdatum\r\nDate d\''échéance\r\nData di scadenza";
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell18.Dpi = 254F;
            this.xrTableCell18.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell18.Multiline = true;
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell18.Size = new System.Drawing.Size(173, 127);
            this.xrTableCell18.Text = "EZAG\r\nOPAE\r\nOPAE";
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KontoNr", "")});
            this.xrTableCell19.Dpi = 254F;
            this.xrTableCell19.Location = new System.Drawing.Point(173, 0);
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Padding = new DevExpress.XtraPrinting.PaddingInfo(13, 5, 0, 0, 254F);
            this.xrTableCell19.Size = new System.Drawing.Size(421, 127);
            this.xrTableCell19.Text = "xrTableCell19";
            this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KontoNr", "")});
            this.xrTableCell20.Dpi = 254F;
            this.xrTableCell20.Location = new System.Drawing.Point(594, 0);
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Padding = new DevExpress.XtraPrinting.PaddingInfo(13, 5, 0, 0, 254F);
            this.xrTableCell20.Size = new System.Drawing.Size(595, 127);
            this.xrTableCell20.Text = "[KontoNr]";
            this.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell21.Dpi = 254F;
            this.xrTableCell21.Location = new System.Drawing.Point(1189, 0);
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell21.Size = new System.Drawing.Size(211, 127);
            this.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TransferDatum", "{0:MM/dd/yyyy}")});
            this.xrTableCell22.Dpi = 254F;
            this.xrTableCell22.Location = new System.Drawing.Point(1400, 0);
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell22.Size = new System.Drawing.Size(271, 127);
            this.xrTableCell22.Text = "xrTableCell22";
            this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell1,
                        this.xrTableCell2,
                        this.xrTableCell5,
                        this.xrTableCell4,
                        this.xrTableCell6,
                        this.xrTableCell3});
            this.xrTableRow1.Dpi = 254F;
            this.xrTableRow1.Font = new System.Drawing.Font("Times New Roman", 8F);
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.ParentStyleUsing.UseFont = false;
            this.xrTableRow1.Size = new System.Drawing.Size(1671, 114);
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell7,
                        this.xrTableCell8,
                        this.xrTableCell9,
                        this.xrTableCell10,
                        this.xrTableCell11,
                        this.xrTableCell12});
            this.xrTableRow2.Dpi = 254F;
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Size = new System.Drawing.Size(1671, 64);
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Dpi = 254F;
            this.xrTableCell1.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell1.Multiline = true;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell1.Size = new System.Drawing.Size(432, 114);
            this.xrTableCell1.Text = "Datenträger-Identifikation\r\nIdentification du support de données";
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Dpi = 254F;
            this.xrTableCell2.Location = new System.Drawing.Point(432, 0);
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell2.Size = new System.Drawing.Size(383, 114);
            this.xrTableCell2.Text = "Magnetbandkassette\r\nCartouche à bande magnétique\r\nCassette e nastro magnetico";
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Dpi = 254F;
            this.xrTableCell5.Location = new System.Drawing.Point(815, 0);
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell5.Size = new System.Drawing.Size(231, 114);
            this.xrTableCell5.Text = "Magnetband\r\nBande magnétique\r\nNastro magnetico";
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Dpi = 254F;
            this.xrTableCell4.Location = new System.Drawing.Point(1046, 0);
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell4.Size = new System.Drawing.Size(160, 114);
            this.xrTableCell4.Text = "Diskette\r\nMinidisque\r\nMinidisco";
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Dpi = 254F;
            this.xrTableCell6.Location = new System.Drawing.Point(1206, 0);
            this.xrTableCell6.Multiline = true;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell6.Size = new System.Drawing.Size(237, 114);
            this.xrTableCell6.Text = "Kassette\r\nCassette\r\nCassetta";
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Dpi = 254F;
            this.xrTableCell3.Location = new System.Drawing.Point(1443, 0);
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell3.Size = new System.Drawing.Size(228, 114);
            this.xrTableCell3.Text = "Erstellungsdatum\r\nDate d\''émission\r\nData d\''emissione";
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Dpi = 254F;
            this.xrTableCell7.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell7.Size = new System.Drawing.Size(432, 64);
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Dpi = 254F;
            this.xrTableCell8.Location = new System.Drawing.Point(432, 0);
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell8.Size = new System.Drawing.Size(383, 64);
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Dpi = 254F;
            this.xrTableCell9.Location = new System.Drawing.Point(815, 0);
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell9.Size = new System.Drawing.Size(231, 64);
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Dpi = 254F;
            this.xrTableCell10.Location = new System.Drawing.Point(1046, 0);
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell10.Size = new System.Drawing.Size(160, 64);
            this.xrTableCell10.Text = "X";
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.Dpi = 254F;
            this.xrTableCell11.Location = new System.Drawing.Point(1206, 0);
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell11.Size = new System.Drawing.Size(237, 64);
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Transferdatum", "{0:MM/dd/yyyy}")});
            this.xrTableCell12.Dpi = 254F;
            this.xrTableCell12.Location = new System.Drawing.Point(1443, 0);
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell12.Size = new System.Drawing.Size(228, 64);
            this.xrTableCell12.Text = "xrTableCell12";
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // KBAuftragEZAGDetail
            // 
            this.KBAuftragEZAGDetail.Dpi = 254F;
            this.KBAuftragEZAGDetail.Location = new System.Drawing.Point(0, 0);
            this.KBAuftragEZAGDetail.Name = "KBAuftragEZAGDetail";
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.Position = 0;
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.ReportHeader,
                        this.PageHeader,
                        this.Detail,
                        this.GroupHeader1});
            this.DataSource = this.sqlQuery1;
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(203, 109, 102, 254);
            this.Name = "Report";
            this.PageHeight = 2969;
            this.PageWidth = 2101;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  N'<?xml version="1.0" standalone="yes" ?>
<NewDataSet>
	<Table>
		<FieldName>label</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Zahlungslauf ID:</DisplayText>
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
		<FieldName>ZahlungslaufID</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>Zahlungslauf ID</DisplayText>
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
</NewDataSet>' ,  N'DECLARE @kbZahlungslaufID INT
SET @kbZahlungslaufID = ISNULL({ZahlungslaufID}, 2)

SELECT
   KBZ.KbZahlungslaufID,
   KBZ.FilePath,
   KBZ.TotalBetrag,
   KBZ.TransferDatum,
   KBZ.KbZahlungskontoID,
   KBZ.UserID,
   KBZ.Transferiert,

   --- Sozialdienst
   SozialDienst = ISNULL((SELECT dbo.fnXConfig(''SozialDienst/Allgemein/Name'', ''20010101'')), ''''),
   SozialAdresse = ISNULL((SELECT dbo.fnXConfig(''SozialDienst/Allgemein/Adresse'', ''20010101'')), ''''),
   SozialPlz = ISNULL((SELECT dbo.fnXConfig(''SozialDienst/Allgemein/PLZ'', ''20010101'')), ''''),
   SozialOrt = ISNULL((SELECT dbo.fnXConfig(''SozialDienst/Allgemein/Ort'', ''20010101'')), ''''),

   --- Kontoinformation
   KTO.Name,
   KTO.VertragNr,
   KTO.KontoNr,
   TaxbelastungsKontoNr = KTO.KontoNr,
   KTO.BaBankID,	

   --- Transferdaten
   AnzahlTransaktionen = (SELECT COUNT(*) FROM KbTransfer WHERE KbZahlungslaufID = @kbZahlungslaufID)

FROM KbZahlungslauf          KBZ
   LEFT JOIN KbZahlungskonto KTO ON KTO.KbZahlungskontoID = KBZ.KbZahlungskontoID

WHERE KBZ.KbZahlungslaufID = @kbZahlungslaufID' ,  N'CtlKbTransfer' ,  null , 1)

INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'KBAuftragEZAGDetail' ,  N'KBAuftragEZAG - Detail' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Projects\KiSS4.NET\KiSS4.Main\bin\Debug\KiSS4.DB.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Projects\KiSS4.NET\KiSS4.Main\bin\Debug\SharpLibrary.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel23;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRTable xrTable3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
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
                        "AAAAdYSREVDTEFSRSBAa2JaYWhsdW5nc2xhdWZJRCBJTlQNClNFVCBAa2JaYWhsdW5nc2xhdWZJRCA9I" +
                        "ElTTlVMTChudWxsLCAyKQ0KDQotLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tL" +
                        "S0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tDQotLSBTb3ppYWxkaWVuc3QNCi0tL" +
                        "S0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tLS0tL" +
                        "S0tLS0tLS0tLS0tLS0tLS0NCkRFQ0xBUkUgQFNvemlhbERpZW5zdCBWQVJDSEFSKDUwKQ0KU0VUIEBTb" +
                        "3ppYWxEaWVuc3QgPSBDb252ZXJ0KFZBUkNIQVIoNTApLCBJU05VTEwoKFNFTEVDVCBkYm8uZm5YQ29uZ" +
                        "mlnKCdTb3ppYWxEaWVuc3QvQWxsZ2VtZWluL05hbWUnLCAnMjAwMTAxMDEnKSksICcnKSkNCg0KREVDT" +
                        "EFSRSBAU296aWFsQWRyZXNzZSBWQVJDSEFSKDUwKQ0KU0VUIEBTb3ppYWxBZHJlc3NlID0gQ29udmVyd" +
                        "ChWQVJDSEFSKDUwKSwgSVNOVUxMKChTRUxFQ1QgZGJvLmZuWENvbmZpZygnU296aWFsRGllbnN0L0Fsb" +
                        "GdlbWVpbi9BZHJlc3NlJywgJzIwMDEwMTAxJykpLCAnJykpDQoNCkRFQ0xBUkUgQFNvemlhbFBseiBWQ" +
                        "VJDSEFSKDEwKQ0KU0VUIEBTb3ppYWxQbHogPSBDb252ZXJ0KFZBUkNIQVIoMTApLCBJU05VTEwoKFNFT" +
                        "EVDVCBkYm8uZm5YQ29uZmlnKCdTb3ppYWxEaWVuc3QvQWxsZ2VtZWluL1BMWicsICcyMDAxMDEwMScpK" +
                        "SwgJycpKQ0KDQpERUNMQVJFIEBTb3ppYWxPcnQgVkFSQ0hBUig1MCkNClNFVCBAU296aWFsT3J0ID0gQ" +
                        "29udmVydChWQVJDSEFSKDUwKSwgSVNOVUxMKChTRUxFQ1QgZGJvLmZuWENvbmZpZygnU296aWFsRGllb" +
                        "nN0L0FsbGdlbWVpbi9PcnQnLCAnMjAwMTAxMDEnKSksICcnKSkNCg0KU0VMRUNUDQogICAtLS0gU296a" +
                        "WFsZGllbnN0DQogICBTb3ppYWxEaWVuc3QgPSBAU296aWFsRGllbnN0LA0KICAgU296aWFsQWRyZXNzZ" +
                        "SA9IEBTb3ppYWxBZHJlc3NlLA0KICAgU296aWFsUGx6ID0gQFNvemlhbFBseiwNCiAgIFNvemlhbE9yd" +
                        "CA9IEBTb3ppYWxPcnQsDQogICAgDQogICAtLS0gWmFobHVuZ3NsYXVmDQogICBLQlouS2JaYWhsdW5nc" +
                        "2xhdWZJRCwNCiAgIEtCWi5GaWxlUGF0aCwNCiAgIEtCWi5Ub3RhbEJldHJhZywNCiAgIEtCWi5UcmFuc" +
                        "2ZlckRhdHVtLA0KICAgS0JaLktiWmFobHVuZ3Nrb250b0lELA0KICAgS0JaLlVzZXJJRCwNCiAgIEtCW" +
                        "i5UcmFuc2ZlcmllcnQsDQoNCiAgIC0tLSBLb250b2luZm9ybWF0aW9uDQogICBLVE8uTmFtZSwNCiAgI" +
                        "EtUTy5WZXJ0cmFnTnIsDQogICBLVE8uS29udG9OciwNCiAgIFRheGJlbGFzdHVuZ3NLb250b05yID0gS" +
                        "1RPLktvbnRvTnIsDQogICBLVE8uQmFCYW5rSUQsCQ0KDQogICAtLS0gVHJhbnNmZXJkYXRlbg0KICAgL" +
                        "S1BbnphaGxUcmFuc2FrdGlvbmVuID0gKFNFTEVDVCBDT1VOVCgqKSBGUk9NIEtiVHJhbnNmZXIgV0hFU" +
                        "kUgS2JaYWhsdW5nc2xhdWZJRCA9IEBrYlphaGx1bmdzbGF1ZklEKQ0KDQogICAtLS0gQnVjaHVuZ2VuD" +
                        "QogICBCVUMuS2JCdWNodW5nSUQsDQogICBCVUMuQmVsZWdOciwNCiAgIEJhbmsgPSBJU05VTEwoQlVDL" +
                        "kJhbmtOYW1lICsgJywgJywgJycpICsgSVNOVUxMKEJVQy5CYW5rT3J0LCAnJyksDQogICBCZWd1ZW5zd" +
                        "GlndCA9IElTTlVMTChCVUMuQmVndWVuc3RpZ3ROYW1lMiArICcgJyAsJycpICsgSVNOVUxMKEJVQy5CZ" +
                        "Wd1ZW5zdGlndE5hbWUsICcnKSArIElTTlVMTCgnLCAnICsgQlVDLkJlZ3VlbnN0aWd0T3J0LCAnJyksD" +
                        "QogICBCZWd1ZW5zdGlndEtvbnRvID0gSVNOVUxMKEJVQy5QQ0tvbnRvTnIsIEJVQy5CYW5rS29udG9Oc" +
                        "iksDQogICBCcnV0dG9CZXRyYWcgPSBCVUMuQmV0cmFnLA0KICAgU2tvbnRvQmV0cmFnID0gJDAsDQogI" +
                        "CBOZXR0b0JldHJhZyA9IEJVQy5CZXRyYWcsDQogICANCiAgIC0tLSBaYWhsdW5nc3dlZw0KICAgWmFob" +
                        "HVuZ3N3ZWdJRCA9IENvYWxlc2NlKFdFRy5CYVBlcnNvbklELCBXRUcuQmFJbnN0aXR1dGlvbklEKQ0KD" +
                        "QpGUk9NIEtiWmFobHVuZ3NsYXVmICAgICAgICAgICBLQloNCiAgIExFRlQgSk9JTiBLYlRyYW5zZmVyI" +
                        "CAgICAgVFJBIE9OIFRSQS5LYlphaGx1bmdzbGF1ZklEID0gS0JaLktiWmFobHVuZ3NsYXVmSUQNCiAgI" +
                        "ExFRlQgSk9JTiBLYkJ1Y2h1bmcgICAgICAgQlVDIE9OIEJVQy5LYkJ1Y2h1bmdJRCA9IFRSQS5LYkJ1Y" +
                        "2h1bmdJRCANCiAgIExFRlQgSk9JTiBLYlphaGx1bmdza29udG8gS1RPIE9OIEtUTy5LYlphaGx1bmdza" +
                        "29udG9JRCA9IEtCWi5LYlphaGx1bmdza29udG9JRA0KICAgTEVGVCBKT0luIEJhWmFobHVuZ3N3ZWcgI" +
                        "CBXRUcgT04gV0VHLkJhWmFobHVuZ3N3ZWdJRCA9IEJVQy5CYVphaGx1bmdzd2VnSUQNCldIRVJFIEtCW" +
                        "i5LYlphaGx1bmdzbGF1ZklEID0gQGtiWmFobHVuZ3NsYXVmSUQNCk9SREVSIEJZIEJlbGVnTnI=";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.Height = 109;
            this.TopMargin.Name = "TopMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel18,
                        this.xrLabel17,
                        this.xrLabel15,
                        this.xrLabel14,
                        this.xrLabel12,
                        this.xrLabel11,
                        this.xrLabel19,
                        this.xrLabel16,
                        this.xrLabel13,
                        this.xrLabel10,
                        this.xrLabel9,
                        this.xrLabel8,
                        this.xrLabel7,
                        this.xrLabel6,
                        this.xrLabel4,
                        this.xrLabel2});
            this.Detail.Dpi = 254F;
            this.Detail.Height = 217;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBackColor = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel23,
                        this.xrLabel22,
                        this.xrLabel21,
                        this.xrLabel20});
            this.ReportFooter.Dpi = 254F;
            this.ReportFooter.Height = 79;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel5,
                        this.xrLine2,
                        this.xrPageInfo2,
                        this.xrPageInfo1});
            this.PageFooter.Dpi = 254F;
            this.PageFooter.Height = 297;
            this.PageFooter.Name = "PageFooter";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel3,
                        this.xrTable3,
                        this.xrLabel1,
                        this.xrLine1,
                        this.xrTable2});
            this.GroupHeader1.Dpi = 254F;
            this.GroupHeader1.Height = 391;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.RepeatEveryPage = true;
            // 
            // xrLabel18
            // 
            this.xrLabel18.BorderWidth = 2;
            this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NettoBetrag", "{0:0.00}")});
            this.xrLabel18.Dpi = 254F;
            this.xrLabel18.Location = new System.Drawing.Point(1561, 151);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel18.ParentStyleUsing.UseBorders = false;
            this.xrLabel18.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel18.Size = new System.Drawing.Size(212, 50);
            this.xrLabel18.Text = "xrLabel18";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel17
            // 
            this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NettoBetrag", "{0:0.00}")});
            this.xrLabel17.Dpi = 254F;
            this.xrLabel17.Location = new System.Drawing.Point(1561, 101);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel17.Size = new System.Drawing.Size(212, 50);
            this.xrLabel17.Text = "xrLabel17";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel15
            // 
            this.xrLabel15.BorderWidth = 2;
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SkontoBetrag", "{0:0.00}")});
            this.xrLabel15.Dpi = 254F;
            this.xrLabel15.Location = new System.Drawing.Point(1331, 151);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel15.ParentStyleUsing.UseBorders = false;
            this.xrLabel15.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel15.Size = new System.Drawing.Size(228, 50);
            this.xrLabel15.Text = "xrLabel15";
            this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel14
            // 
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SkontoBetrag", "{0:0.00}")});
            this.xrLabel14.Dpi = 254F;
            this.xrLabel14.Location = new System.Drawing.Point(1331, 50);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel14.Size = new System.Drawing.Size(228, 50);
            this.xrLabel14.Text = "xrLabel14";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel12
            // 
            this.xrLabel12.BorderWidth = 2;
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BruttoBetrag", "{0:0.00}")});
            this.xrLabel12.Dpi = 254F;
            this.xrLabel12.Location = new System.Drawing.Point(1101, 151);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel12.ParentStyleUsing.UseBorders = false;
            this.xrLabel12.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel12.Size = new System.Drawing.Size(228, 50);
            this.xrLabel12.Text = "xrLabel11";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BruttoBetrag", "{0:0.00}")});
            this.xrLabel11.Dpi = 254F;
            this.xrLabel11.Location = new System.Drawing.Point(1103, 101);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel11.Size = new System.Drawing.Size(228, 50);
            this.xrLabel11.Text = "xrLabel11";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 254F;
            this.xrLabel19.Location = new System.Drawing.Point(0, 0);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel19.ParentStyleUsing.UseBorders = false;
            this.xrLabel19.Size = new System.Drawing.Size(296, 201);
            this.xrLabel19.Text = "[BelegNr]";
            this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NettoBetrag", "{0:0.00}")});
            this.xrLabel16.Dpi = 254F;
            this.xrLabel16.Location = new System.Drawing.Point(1561, 50);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel16.Size = new System.Drawing.Size(212, 51);
            this.xrLabel16.Text = "xrLabel16";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SkontoBetrag", "{0:0.00}")});
            this.xrLabel13.Dpi = 254F;
            this.xrLabel13.Location = new System.Drawing.Point(1331, 101);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel13.Size = new System.Drawing.Size(228, 50);
            this.xrLabel13.Text = "xrLabel13";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel10
            // 
            this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BruttoBetrag", "{0:0.00}")});
            this.xrLabel10.Dpi = 254F;
            this.xrLabel10.Location = new System.Drawing.Point(1103, 50);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel10.Size = new System.Drawing.Size(228, 50);
            this.xrLabel10.Text = "xrLabel10";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 254F;
            this.xrLabel9.Location = new System.Drawing.Point(296, 151);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 51, 0, 0, 254F);
            this.xrLabel9.ParentStyleUsing.UseBorders = false;
            this.xrLabel9.Size = new System.Drawing.Size(800, 50);
            this.xrLabel9.Text = "Total Kreditor";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bank", "")});
            this.xrLabel8.Dpi = 254F;
            this.xrLabel8.Location = new System.Drawing.Point(452, 101);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel8.Size = new System.Drawing.Size(650, 50);
            this.xrLabel8.Text = "xrLabel8";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 254F;
            this.xrLabel7.Location = new System.Drawing.Point(302, 101);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel7.Size = new System.Drawing.Size(150, 50);
            this.xrLabel7.Text = "Total";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BeguenstigtKonto", "")});
            this.xrLabel6.Dpi = 254F;
            this.xrLabel6.Location = new System.Drawing.Point(302, 50);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel6.Size = new System.Drawing.Size(800, 50);
            this.xrLabel6.Text = "xrLabel6";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Beguenstigt", "")});
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.Location = new System.Drawing.Point(452, 0);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(650, 50);
            this.xrLabel4.Text = "xrLabel4";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ZahlungswegID", "")});
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.Location = new System.Drawing.Point(302, 0);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(150, 50);
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel23
            // 
            this.xrLabel23.BorderWidth = 2;
            this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TotalBetrag", "{0:0.00}")});
            this.xrLabel23.Dpi = 254F;
            this.xrLabel23.Location = new System.Drawing.Point(1561, 0);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel23.ParentStyleUsing.UseBorders = false;
            this.xrLabel23.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel23.Size = new System.Drawing.Size(212, 50);
            this.xrLabel23.Text = "xrLabel23";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel22
            // 
            this.xrLabel22.BorderWidth = 2;
            this.xrLabel22.Dpi = 254F;
            this.xrLabel22.Location = new System.Drawing.Point(1331, 0);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel22.ParentStyleUsing.UseBorders = false;
            this.xrLabel22.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel22.Size = new System.Drawing.Size(228, 50);
            this.xrLabel22.Text = "0.00";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel21
            // 
            this.xrLabel21.BorderWidth = 2;
            this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TotalBetrag", "{0:0.00}")});
            this.xrLabel21.Dpi = 254F;
            this.xrLabel21.Location = new System.Drawing.Point(1103, 0);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel21.ParentStyleUsing.UseBorders = false;
            this.xrLabel21.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel21.Size = new System.Drawing.Size(228, 50);
            this.xrLabel21.Text = "xrLabel21";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 254F;
            this.xrLabel20.Location = new System.Drawing.Point(487, 0);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 51, 0, 0, 254F);
            this.xrLabel20.Size = new System.Drawing.Size(615, 50);
            this.xrLabel20.Text = "Total Auftrag";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 254F;
            this.xrLabel5.Location = new System.Drawing.Point(1545, 127);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel5.Size = new System.Drawing.Size(123, 63);
            this.xrLabel5.Text = "Seite";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLine2
            // 
            this.xrLine2.BorderWidth = 2;
            this.xrLine2.Dpi = 254F;
            this.xrLine2.LineWidth = 3;
            this.xrLine2.Location = new System.Drawing.Point(0, 85);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine2.Size = new System.Drawing.Size(1778, 42);
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 254F;
            this.xrPageInfo2.Format = "{0:MM/dd/yyyy HH:mm}";
            this.xrPageInfo2.Location = new System.Drawing.Point(0, 127);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.Size = new System.Drawing.Size(1545, 63);
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 254F;
            this.xrPageInfo1.Location = new System.Drawing.Point(1672, 127);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrPageInfo1.Size = new System.Drawing.Size(107, 63);
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SozialDienst", "")});
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Location = new System.Drawing.Point(0, 193);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.Size = new System.Drawing.Size(805, 64);
            this.xrLabel3.Text = "xrLabel3";
            // 
            // xrTable3
            // 
            this.xrTable3.BackColor = System.Drawing.Color.Gainsboro;
            this.xrTable3.Dpi = 254F;
            this.xrTable3.Location = new System.Drawing.Point(0, 257);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.ParentStyleUsing.UseBackColor = false;
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow3});
            this.xrTable3.Size = new System.Drawing.Size(1778, 113);
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TransferDatum", "{0:\"Zahlungsprotokoll vom\" MM/dd/yyyy}")});
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.Location = new System.Drawing.Point(0, 130);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(805, 63);
            this.xrLabel1.Text = "xrLabel1";
            // 
            // xrLine1
            // 
            this.xrLine1.BorderWidth = 2;
            this.xrLine1.Dpi = 254F;
            this.xrLine1.LineWidth = 3;
            this.xrLine1.Location = new System.Drawing.Point(0, 85);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.Size = new System.Drawing.Size(1778, 42);
            // 
            // xrTable2
            // 
            this.xrTable2.Dpi = 254F;
            this.xrTable2.Location = new System.Drawing.Point(931, 0);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow2});
            this.xrTable2.Size = new System.Drawing.Size(846, 64);
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell6,
                        this.xrTableCell7,
                        this.xrTableCell10,
                        this.xrTableCell9,
                        this.xrTableCell8});
            this.xrTableRow3.Dpi = 254F;
            this.xrTableRow3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.ParentStyleUsing.UseFont = false;
            this.xrTableRow3.Size = new System.Drawing.Size(1778, 113);
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Dpi = 254F;
            this.xrTableCell6.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell6.Size = new System.Drawing.Size(298, 113);
            this.xrTableCell6.Text = "Belegnummer";
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Dpi = 254F;
            this.xrTableCell7.Location = new System.Drawing.Point(298, 0);
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell7.Size = new System.Drawing.Size(795, 113);
            this.xrTableCell7.Text = "Kreditor\r\nZahlungsverbindung\r\nTotal";
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Dpi = 254F;
            this.xrTableCell10.Location = new System.Drawing.Point(1093, 0);
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell10.Size = new System.Drawing.Size(228, 113);
            this.xrTableCell10.Text = "Brutto";
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Dpi = 254F;
            this.xrTableCell9.Location = new System.Drawing.Point(1321, 0);
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell9.Size = new System.Drawing.Size(228, 113);
            this.xrTableCell9.Text = "Skonto";
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Dpi = 254F;
            this.xrTableCell8.Location = new System.Drawing.Point(1549, 0);
            this.xrTableCell8.Multiline = true;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell8.Size = new System.Drawing.Size(229, 113);
            this.xrTableCell8.Text = "Netto";
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell4,
                        this.xrTableCell5});
            this.xrTableRow2.Dpi = 254F;
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Size = new System.Drawing.Size(846, 64);
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SozialDienst", "")});
            this.xrTableCell4.Dpi = 254F;
            this.xrTableCell4.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell4.Size = new System.Drawing.Size(554, 64);
            this.xrTableCell4.Text = "xrTableCell4";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "SozialOrt", "")});
            this.xrTableCell5.Dpi = 254F;
            this.xrTableCell5.Location = new System.Drawing.Point(554, 0);
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell5.Size = new System.Drawing.Size(292, 64);
            this.xrTableCell5.Text = "xrTableCell5";
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.Position = 0;
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.TopMargin,
                        this.Detail,
                        this.ReportFooter,
                        this.PageFooter,
                        this.GroupHeader1});
            this.DataSource = this.sqlQuery1;
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(201, 107, 109, 254);
            this.Name = "Report";
            this.PageHeight = 2969;
            this.PageWidth = 2101;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'DECLARE @kbZahlungslaufID INT
SET @kbZahlungslaufID = ISNULL({ZahlungslaufID}, 2)

-------------------------------------------------------------------------------
-- Sozialdienst
-------------------------------------------------------------------------------
DECLARE @SozialDienst VARCHAR(50)
SET @SozialDienst = Convert(VARCHAR(50), ISNULL((SELECT dbo.fnXConfig(''SozialDienst/Allgemein/Name'', ''20010101'')), ''''))

DECLARE @SozialAdresse VARCHAR(50)
SET @SozialAdresse = Convert(VARCHAR(50), ISNULL((SELECT dbo.fnXConfig(''SozialDienst/Allgemein/Adresse'', ''20010101'')), ''''))

DECLARE @SozialPlz VARCHAR(10)
SET @SozialPlz = Convert(VARCHAR(10), ISNULL((SELECT dbo.fnXConfig(''SozialDienst/Allgemein/PLZ'', ''20010101'')), ''''))

DECLARE @SozialOrt VARCHAR(50)
SET @SozialOrt = Convert(VARCHAR(50), ISNULL((SELECT dbo.fnXConfig(''SozialDienst/Allgemein/Ort'', ''20010101'')), ''''))

SELECT
   --- Sozialdienst
   SozialDienst = @SozialDienst,
   SozialAdresse = @SozialAdresse,
   SozialPlz = @SozialPlz,
   SozialOrt = @SozialOrt,

   --- Zahlungslauf
   KBZ.KbZahlungslaufID,
   KBZ.FilePath,
   KBZ.TotalBetrag,
   KBZ.TransferDatum,
   KBZ.KbZahlungskontoID,
   KBZ.UserID,
   KBZ.Transferiert,

   --- Kontoinformation
   KTO.Name,
   KTO.VertragNr,
   KTO.KontoNr,
   TaxbelastungsKontoNr = KTO.KontoNr,
   KTO.BaBankID,	

   --- Transferdaten
   --AnzahlTransaktionen = (SELECT COUNT(*) FROM KbTransfer WHERE KbZahlungslaufID = @kbZahlungslaufID)

   --- Buchungen
   BUC.KbBuchungID,
   BUC.BelegNr,
   Bank = ISNULL(BUC.BankName + '', '', '''') + ISNULL(BUC.BankOrt, ''''),
   Beguenstigt = ISNULL(BUC.BeguenstigtName2 + '' '' ,'''') + ISNULL(BUC.BeguenstigtName, '''') + ISNULL('', '' + BUC.BeguenstigtOrt, ''''),
   BeguenstigtKonto = ISNULL(BUC.PCKontoNr, BUC.BankKontoNr),
   BruttoBetrag = BUC.Betrag,
   SkontoBetrag = $0,
   NettoBetrag = BUC.Betrag,

   --- Zahlungsweg
   ZahlungswegID = Coalesce(WEG.BaPersonID, WEG.BaInstitutionID)

FROM KbZahlungslauf           KBZ
   LEFT JOIN KbTransfer      TRA ON TRA.KbZahlungslaufID = KBZ.KbZahlungslaufID
   LEFT JOIN KbBuchung       BUC ON BUC.KbBuchungID = TRA.KbBuchungID
   LEFT JOIN KbZahlungskonto KTO ON KTO.KbZahlungskontoID = KBZ.KbZahlungskontoID
   LEFT JOIn BaZahlungsweg   WEG ON WEG.BaZahlungswegID = BUC.BaZahlungswegID
WHERE KBZ.KbZahlungslaufID = @kbZahlungslaufID
ORDER BY Beguenstigt, BelegNr' ,  null ,  N'KBAuftragEZAG' , 2)

