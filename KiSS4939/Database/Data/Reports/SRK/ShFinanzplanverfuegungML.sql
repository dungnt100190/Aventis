-- Insert Script for ShFinanzplanverfuegungML
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'ShFinanzplanverfuegungML') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('ShFinanzplanverfuegungML', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'ShFinanzplanverfuegungML';
UPDATE QRY
SET QueryName =  N'ShFinanzplanverfuegungML' , UserText =  N'SH - Finanzplanverfügung (mehrsprachig)' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.Subreport ShFinanzplanverfuegungML_EinAus;
        private DevExpress.XtraReports.UI.Subreport ShFinanzplanverfuegungML_Personen;
        private DevExpress.XtraReports.UI.XRRichTextBox xrRichTextBox1;
        private DevExpress.XtraReports.UI.XRLabel txtFehlbetrag;
        private DevExpress.XtraReports.UI.XRLabel Label25;
        private DevExpress.XtraReports.UI.XRLabel Label24;
        private DevExpress.XtraReports.UI.XRLabel Label23;
        private DevExpress.XtraReports.UI.XRLabel txtTotOut;
        private DevExpress.XtraReports.UI.XRLabel txtTotIn;
        private DevExpress.XtraReports.UI.XRLine Line13;
        private DevExpress.XtraReports.UI.XRLine Line12;
        private DevExpress.XtraReports.UI.XRLine Line11;
        private DevExpress.XtraReports.UI.XRLine Line10;
        private DevExpress.XtraReports.UI.XRLabel Label12;
        private DevExpress.XtraReports.UI.XRLabel Label11;
        private DevExpress.XtraReports.UI.XRLabel txtAnrede;
        private DevExpress.XtraReports.UI.XRLine Line8;
        private DevExpress.XtraReports.UI.XRLine Line7;
        private DevExpress.XtraReports.UI.XRLine Line6;
        private DevExpress.XtraReports.UI.XRLine Line4;
        private DevExpress.XtraReports.UI.XRLabel Label9;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLabel Label8;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.XRLabel Label5;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.XRLabel Label3;
        private DevExpress.XtraReports.UI.XRLabel Label2;
        private DevExpress.XtraReports.UI.XRLabel txtTitle;
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
                        "AAAAf03REVDTEFSRSBAQmdCdWRnZXRJRCAgaW50LA0KICAgICAgICBAR2V0RGF0ZSAgICAgZGF0ZXRpb" +
                        "WUNClNFTEVDVCBAQmdCdWRnZXRJRCA9IEJnQnVkZ2V0SUQsIEBHZXREYXRlID0gR2V0RGF0ZSgpDQpGU" +
                        "k9NIEJnQnVkZ2V0DQpXSEVSRSBCZ0ZpbmFuelBsYW5JRCA9IG51bGwgQU5EIE1hc3RlckJ1ZGdldCA9I" +
                        "DENCg0KDQpERUNMQVJFIEBUb3RJbiBtb25leQ0KREVDTEFSRSBAVG90T3V0IG1vbmV5DQoNClNFTEVDV" +
                        "CBAVG90SW4gPSBTVU0oQmV0cmFnKQ0KRlJPTSBkYm8uZm5XaEdldEZpbmFuenBsYW5NTChAQmdCdWRnZ" +
                        "XRJRCwgQEdldERhdGUpIFRNUA0KV0hFUkUgVE1QLkJnS2F0ZWdvcmllQ29kZSA9IDENCg0KU0VMRUNUI" +
                        "EBUb3RPdXQgPSBTVU0oQ0FTRSBXSEVOIEJnS2F0ZWdvcmllQ29kZSA9IDIgVEhFTiBUTVAuQmV0cmFnI" +
                        "EVMU0UgLVRNUC5CZXRyYWcgRU5EKQ0KRlJPTSBkYm8uZm5XaEdldEZpbmFuenBsYW5NTChAQmdCdWRnZ" +
                        "XRJRCwgQEdldERhdGUpICBUTVANCldIRVJFIFRNUC5CZ0thdGVnb3JpZUNvZGUgSU4gKDIsIDQpDQoNC" +
                        "kRFQ0xBUkUgQFNwcmFjaENvZGUgSU5UDQpTRUxFQ1QgQFNwcmFjaENvZGUgPSBQLlZlcnN0YWVuZGlnd" +
                        "W5nU3ByYWNoQ29kZSANCkZST00gQmdCdWRnZXQgQg0KICBMRUZUIE9VVEVSIEpPSU4gQmdGaW5hbnpwb" +
                        "GFuIEZQIE9OIEZQLkJnRmluYW56cGxhbklEID0gQi5CZ0ZpbmFuenBsYW5JRA0KICBMRUZUIE9VVEVSI" +
                        "EpPSU4gRmFMZWlzdHVuZyBMRUkgT04gTEVJLkZhTGVpc3R1bmdJRCA9IEZQLkZhTGVpc3R1bmdJRA0KI" +
                        "CBMRUZUIE9VVEVSIEpPSU4gRmFGYWxsIEZBTCBPTiBGQUwuRmFGYWxsSUQgPSBMRUkuRmFGYWxsSUQNC" +
                        "iAgTEVGVCBPVVRFUiBKT0lOIEJhUGVyc29uIFAgT04gUC5CYVBlcnNvbklEID0gRkFMLkJhUGVyc29uS" +
                        "UQNCldIRVJFIEIuQmdCdWRnZXRJRCA9IEBCZ0J1ZGdldElEDQpJRiBAU3ByYWNoQ29kZSBJUyBOVUxMI" +
                        "FNFVCBAU3ByYWNoQ29kZSA9IDENCg0KDQpERUNMQVJFIEBUZXh0X1ZlcmZ1ZWd1bmdWb20gVkFSQ0hBU" +
                        "igyMDApDQpTRUxFQ1QgQFRleHRfVmVyZnVlZ3VuZ1ZvbSA9IGRiby5mbkdldE1MVGV4dEZyb21OYW1lK" +
                        "CdSZXBvcnRfQnVkZ2V0JywgJ1ZlcmZ1ZWd1bmdWb20nLCBAU3ByYWNoQ29kZSkgIC0tICJWZXJmw7xnd" +
                        "W5nIHZvbSINCkRFQ0xBUkUgQFRleHRfU296aWFsaGlsZmVWb20gVkFSQ0hBUigyMDApDQpTRUxFQ1QgQ" +
                        "FRleHRfU296aWFsaGlsZmVWb20gPSBkYm8uZm5HZXRNTFRleHRGcm9tTmFtZSgnUmVwb3J0X0J1ZGdld" +
                        "CcsICdTb3ppYWxoaWxmZVZvbScsIEBTcHJhY2hDb2RlKSAgLS0gIlNvemlhbGhpbGZlIHZvbSINCkRFQ" +
                        "0xBUkUgQFRleHRfQmlzIFZBUkNIQVIoMjAwKQ0KU0VMRUNUIEBUZXh0X0JpcyA9IGRiby5mbkdldE1MV" +
                        "GV4dEZyb21OYW1lKCdSZXBvcnRfQnVkZ2V0JywgJ2JpcycsIEBTcHJhY2hDb2RlKSAgLS0gImJpcyINC" +
                        "g0KREVDTEFSRSBAVGV4dF9CdWRnZXRVZWJlcnNpY2h0IFZBUkNIQVIoMjAwKQ0KU0VMRUNUIEBUZXh0X" +
                        "0J1ZGdldFVlYmVyc2ljaHQgPSBkYm8uZm5HZXRNTFRleHRGcm9tTmFtZSgnUmVwb3J0X0J1ZGdldCcsI" +
                        "CdCdWRnZXRVZWJlcnNpY2h0JywgQFNwcmFjaENvZGUpICAtLSAiQnVkZ2V0w7xiZXJzaWNodCINCkRFQ" +
                        "0xBUkUgQFRleHRfRWlubmFobWVuIFZBUkNIQVIoMjAwKQ0KU0VMRUNUIEBUZXh0X0Vpbm5haG1lbiA9I" +
                        "GRiby5mbkdldE1MVGV4dEZyb21OYW1lKCdSZXBvcnRfQnVkZ2V0JywgJ0Vpbm5haG1lbicsIEBTcHJhY" +
                        "2hDb2RlKSAgLS0gIkVpbm5haG1lbiINCkRFQ0xBUkUgQFRleHRfQXVzZ2FiZW4gVkFSQ0hBUigyMDApD" +
                        "QpTRUxFQ1QgQFRleHRfQXVzZ2FiZW4gPSBkYm8uZm5HZXRNTFRleHRGcm9tTmFtZSgnUmVwb3J0X0J1Z" +
                        "GdldCcsICdBdXNnYWJlbicsIEBTcHJhY2hDb2RlKSAgLS0gIkF1c2dhYmVuIg0KREVDTEFSRSBAVGV4d" +
                        "F9Ub3RhbCBWQVJDSEFSKDIwMCkNClNFTEVDVCBAVGV4dF9Ub3RhbCA9IGRiby5mbkdldE1MVGV4dEZyb" +
                        "21OYW1lKCdSZXBvcnRfQnVkZ2V0JywgJ1RvdGFsJywgQFNwcmFjaENvZGUpICAtLSAiVG90YWwiDQpER" +
                        "UNMQVJFIEBUZXh0X0ZlaGxiZXRyYWcgVkFSQ0hBUigyMDApDQpTRUxFQ1QgQFRleHRfRmVobGJldHJhZ" +
                        "yA9IGRiby5mbkdldE1MVGV4dEZyb21OYW1lKCdSZXBvcnRfQnVkZ2V0JywgJ0ZlaGxiZXRyYWcnLCBAU" +
                        "3ByYWNoQ29kZSkgIC0tICJGZWhsYmV0cmFnIg0KREVDTEFSRSBAVGV4dF9IaW53ZWlzIFZBUkNIQVIoM" +
                        "jAwKQ0KU0VMRUNUIEBUZXh0X0hpbndlaXMgPSBkYm8uZm5HZXRNTFRleHRGcm9tTmFtZSgnUmVwb3J0X" +
                        "0J1ZGdldCcsICdIaW53ZWlzJywgQFNwcmFjaENvZGUpICAtLSAiSGlud2VpcyINCkRFQ0xBUkUgQFRle" +
                        "HRfSGlud2Vpc1RleHQgVkFSQ0hBUigyMDAwKQ0KU0VMRUNUIEBUZXh0X0hpbndlaXNUZXh0ID0gZGJvL" +
                        "mZuR2V0TUxUZXh0RnJvbU5hbWUoJ1JlcG9ydF9CdWRnZXQnLCAnUmVwb3J0X0ZpbmFuelBsYW5fSGlud" +
                        "2Vpc1RleHQnLCBAU3ByYWNoQ29kZSkgIC0tICJIaW53ZWlzIGxhbmdlciBUZXh0IC4uLi4iDQpERUNMQ" +
                        "VJFIEBUZXh0X0JlbWVya3VuZyBWQVJDSEFSKDIwMCkNClNFTEVDVCBAVGV4dF9CZW1lcmt1bmcgPSBkY" +
                        "m8uZm5HZXRNTFRleHRGcm9tTmFtZSgnUmVwb3J0X0J1ZGdldCcsICdCZW1lcmt1bmcnLCBAU3ByYWNoQ" +
                        "29kZSkgIC0tICJCZW1lcmt1bmciDQpERUNMQVJFIEBUZXh0X1NvemlhbGhpbGZlQmV3aWxsaWd0IFZBU" +
                        "kNIQVIoMjAwKQ0KU0VMRUNUIEBUZXh0X1NvemlhbGhpbGZlQmV3aWxsaWd0ID0gZGJvLmZuR2V0TUxUZ" +
                        "Xh0RnJvbU5hbWUoJ1JlcG9ydF9CdWRnZXQnLCAnU296aWFsaGlsZmVCZXdpbGxpZ3QnLCBAU3ByYWNoQ" +
                        "29kZSkgIC0tICJTb3ppYWxoaWxmZSBiZXdpbGxpZ3QiDQpERUNMQVJFIEBUZXh0X0VtcGZhbmdzQmVzd" +
                        "GFldGlndW5nIFZBUkNIQVIoMjAwKQ0KU0VMRUNUIEBUZXh0X0VtcGZhbmdzQmVzdGFldGlndW5nID0gZ" +
                        "GJvLmZuR2V0TUxUZXh0RnJvbU5hbWUoJ1JlcG9ydF9CdWRnZXQnLCAnRW1wZmFuZ3NCZXN0YWV0aWd1b" +
                        "mcnLCBAU3ByYWNoQ29kZSkgIC0tICJFbXBmYW5nc2Jlc3TDpHRpZ3VuZyINCkRFQ0xBUkUgQFRleHRfT" +
                        "3J0RGF0dW0gVkFSQ0hBUigyMDApDQpTRUxFQ1QgQFRleHRfT3J0RGF0dW0gPSBkYm8uZm5HZXRNTFRle" +
                        "HRGcm9tTmFtZSgnUmVwb3J0X0J1ZGdldCcsICdPcnREYXR1bScsIEBTcHJhY2hDb2RlKSAgLS0gIk9yd" +
                        "CwgRGF0dW0iDQpERUNMQVJFIEBUZXh0X1VudGVyc2NocmlmdCBWQVJDSEFSKDIwMCkNClNFTEVDVCBAV" +
                        "GV4dF9VbnRlcnNjaHJpZnQgPSBkYm8uZm5HZXRNTFRleHRGcm9tTmFtZSgnUmVwb3J0X0J1ZGdldCcsI" +
                        "CdVbnRlcnNjaHJpZnRLbGllbnQnLCBAU3ByYWNoQ29kZSkgIC0tICJVbnRlcnNjaHJpZnQiDQpERUNMQ" +
                        "VJFIEBUZXh0X1JlY2h0c21pdHRlbEJlbGVocnVuZyBWQVJDSEFSKDIwMDApDQpTRUxFQ1QgQFRleHRfU" +
                        "mVjaHRzbWl0dGVsQmVsZWhydW5nID0gZGJvLmZuR2V0TUxUZXh0RnJvbU5hbWUoJ1JlcG9ydF9CdWRnZ" +
                        "XQnLCAnUmVwb3J0X0ZpbmFuelBsYW5fUmVjaHRzbWl0dGVsQmVsZWhydW5nJywgQFNwcmFjaENvZGUpI" +
                        "CAtLSAiUmVjaHRzbWl0dGVsQmVsZWhydW5nIg0KREVDTEFSRSBAVGV4dF9VbnRlcnNjaHJpZnRTRCBWQ" +
                        "VJDSEFSKDIwMCkNClNFTEVDVCBAVGV4dF9VbnRlcnNjaHJpZnRTRCA9IGRiby5mbkdldE1MVGV4dEZyb" +
                        "21OYW1lKCdSZXBvcnRfQnVkZ2V0JywgJ1VudGVyc2NocmlmdFNvemlhbGRpZW5zdCcsIEBTcHJhY2hDb" +
                        "2RlKSAgLS0gIkbDvHIgZGVuIFNvemlhbGRpZW5zdCIgKFVudGVyc2NocmlmdCkNCg0KDQpERUNMQVJFI" +
                        "EBCZW1lcmt1bmcgdmFyY2hhcig4MDAwKSwNCiAgICAgICAgQEl0ZW1UZXh0ICAgICB2YXJjaGFyKDgwM" +
                        "DApDQoNCkRFQ0xBUkUgY0JlbWVya3VuZyBDVVJTT1IgRkFTVF9GT1JXQVJEIEZPUg0KICBTRUxFQ1QgJ" +
                        "y0gJyArIA0KICAgIC0tIFhMQy5UZXh0ICsgDQogICAgZGJvLmZuTE9WTUxUZXh0KCdCZ0dydXBwZScsI" +
                        "FNQVC5CZ0dydXBwZUNvZGUsIEBTcHJhY2hDb2RlKSArIA0KICAgICcgKCcgKyBQUlMuTmFtZVZvcm5hb" +
                        "WUgKyAnKTogJyArIENvbnZlcnQodmFyY2hhcigyMDAwKSwgQlBPLkJlbWVya3VuZykNCiAgRlJPTSBCZ" +
                        "1Bvc2l0aW9uICAgICAgICAgICAgQlBPDQogICAgTEVGVCBKT0lOIHZ3UGVyc29uICAgICAgIFBSUyBPT" +
                        "iBQUlMuQmFQZXJzb25JRCA9IEJQTy5CYVBlcnNvbklEDQogICAgTEVGVCBKT0lOIEJnUG9zaXRpb25zY" +
                        "XJ0IFNQVCBPTiBTUFQuQmdQb3NpdGlvbnNhcnRJRCA9IEJQTy5CZ1Bvc2l0aW9uc2FydElEDQogICAgL" +
                        "S0gTEVGVCBKT0lOIFhMT1ZDb2RlICAgICAgIFhMQyBPTiBYTEMuTE9WTmFtZSA9ICdCZ0dydXBwZScgQ" +
                        "U5EIFhMQy5Db2RlID0gU1BULkJnR3J1cHBlQ29kZQ0KICBXSEVSRSBCUE8uQmdCdWRnZXRJRCA9IEBCZ" +
                        "0J1ZGdldElEDQogICAgQU5EIEJQTy5CZ1Bvc2l0aW9uc2FydElEIEJFVFdFRU4gMzkwMDAgQU5EIDM5O" +
                        "Tk5DQogICAgQU5EIE5PVCAoQlBPLkJlbWVya3VuZyBJUyBOVUxMIE9SIENvbnZlcnQodmFyY2hhciwgQ" +
                        "lBPLkJlbWVya3VuZykgPSAnJykNCiAgICBBTkQgR2V0RGF0ZSgpIEJFVFdFRU4gSXNOdWxsKEJQTy5EY" +
                        "XR1bVZvbiwgJzE5MDAwMTAxJykgQU5EIElzTnVsbChCUE8uRGF0dW1CaXMsIEdldERhdGUoKSkNCiAgT" +
                        "1JERVIgQlkgUFJTLk5hbWVWb3JuYW1lDQoNCk9QRU4gY0JlbWVya3VuZw0KV0hJTEUgKDEgPSAxKSBCR" +
                        "UdJTg0KICBGRVRDSCBORVhUIEZST00gY0JlbWVya3VuZyBJTlRPIEBJdGVtVGV4dA0KICBJRiBAQEZFV" +
                        "ENIX1NUQVRVUyAhPSAwIEJSRUFLDQogIFNFVCBAQmVtZXJrdW5nID0gSXNOdWxsKEBCZW1lcmt1bmcgK" +
                        "yBjaGFyKDEwKSArIGNoYXIoMTMpLCAnJykgKyBASXRlbVRleHQNCkVORA0KQ0xPU0UgY0JlbWVya3VuZ" +
                        "w0KREVBTExPQ0FURSBjQmVtZXJrdW5nDQoNCg0KU0VMRUNUIA0KICBUZXh0X0J1ZGdldFVlYmVyc2lja" +
                        "HQgPSBAVGV4dF9CdWRnZXRVZWJlcnNpY2h0LA0KICBUZXh0X0Vpbm5haG1lbiA9IEBUZXh0X0Vpbm5ha" +
                        "G1lbiwNCiAgVGV4dF9BdXNnYWJlbiA9IEBUZXh0X0F1c2dhYmVuLA0KICBUZXh0X1RvdGFsRWlubmFob" +
                        "WVuID0gQFRleHRfVG90YWwgKyAnICcgKyBAVGV4dF9FaW5uYWhtZW4sDQogIFRleHRfVG90YWxBdXNnY" +
                        "WJlbiA9IEBUZXh0X1RvdGFsICsgJyAnICsgQFRleHRfQXVzZ2FiZW4sDQogIFRleHRfRmVobGJldHJhZ" +
                        "yA9IEBUZXh0X0ZlaGxiZXRyYWcsDQogIFRleHRfSGlud2VpcyA9IEBUZXh0X0hpbndlaXMsDQogIFRle" +
                        "HRfSGlud2Vpc1RleHQgPSBAVGV4dF9IaW53ZWlzVGV4dCwNCiAgVGV4dF9CZW1lcmt1bmcgPSBAVGV4d" +
                        "F9CZW1lcmt1bmcsDQogIFRleHRfU296aWFsaGlsZmVCZXdpbGxpZ3QgPSBAVGV4dF9Tb3ppYWxoaWxmZ" +
                        "UJld2lsbGlndCwNCiAgVGV4dF9FbXBmYW5nc0Jlc3RhZXRpZ3VuZyA9IEBUZXh0X0VtcGZhbmdzQmVzd" +
                        "GFldGlndW5nLA0KICBUZXh0X09ydERhdHVtID0gQFRleHRfT3J0RGF0dW0sDQogIFRleHRfVW50ZXJzY" +
                        "2hyaWZ0ID0gQFRleHRfVW50ZXJzY2hyaWZ0LA0KICBUZXh0X1JlY2h0c21pdHRlbEJlbGVocnVuZyA9I" +
                        "EBUZXh0X1JlY2h0c21pdHRlbEJlbGVocnVuZywNCiAgVGV4dF9VbnRlcnNjaHJpZnRTRCA9IEBUZXh0X" +
                        "1VudGVyc2NocmlmdFNELA0KDQogIEJCRy5CZ0J1ZGdldElELA0KICAgICAgIE9yZ1VuaXRBZHJlc3NlI" +
                        "D0gT1JHLlRleHQxLA0KICAgICAgIFRpdGxlICAgICAgICA9IEBUZXh0X1ZlcmZ1ZWd1bmdWb20gKyAnI" +
                        "CcgKyBJc051bGwoQ09OVkVSVCh2YXJjaGFyLCAoDQogICAgICAgICAgICAgICAgICAgICAgICBTRUxFQ" +
                        "1QgTUFYKERhdHVtKSBGUk9NIEJnQmV3aWxsaWd1bmcgQkJXDQogICAgICAgICAgICAgICAgICAgICAgI" +
                        "CBXSEVSRSBCQlcuQmdGaW5hbnpQbGFuSUQ9U0ZQLkJnRmluYW56UGxhbklEIEFORCBCQlcuQmdCZXdpb" +
                        "GxpZ3VuZ0NvZGUgPSAyKSwgMTA0KSwgJz8/PycpICsNCiAgICAgICAgICAgICAgICAgICAgICAnOiAnI" +
                        "CsgQFRleHRfU296aWFsaGlsZmVWb20gKyAnICcgKyBDT05WRVJUKHZhcmNoYXIsIFNGUC5EYXR1bVZvb" +
                        "iwgMTA0KSArICcgJyArIEBUZXh0X0JpcyArICcgJyArIENPTlZFUlQodmFyY2hhciwgU0ZQLkRhdHVtQ" +
                        "mlzLCAxMDQpLA0KICAgICAgIEFkcmVzc2UgICAgICA9IElzTnVsbChQUlMuQW5yZWRlICsgY2hhcigxM" +
                        "ykgKyBjaGFyKDEwKSwnJykgKyANCiAgICAgICAgICAgICAgICAgICAgICBQUlMuTmFtZVZvcm5hbWUgK" +
                        "yBjaGFyKDEzKSArIGNoYXIoMTApICsNCiAgICAgICAgICAgICAgICAgICAgICBQUlMuV29obnNpdHpTd" +
                        "HJhc3NlSGF1c05yICsgY2hhcigxMykgKyBjaGFyKDEwKSArDQogICAgICAgICAgICAgICAgICAgICAgU" +
                        "FJTLldvaG5zaXR6UExaT3J0LA0KICAgICAgIEJlbWVya3VuZyA9IElzTnVsbChDT05WRVJUKHZhcmNoY" +
                        "XIoODAwMCksIFNGUC5CZW1lcmt1bmcpICsgY2hhcigxMCkgKyBjaGFyKDEzKSwgJycpICsgSXNOdWxsK" +
                        "EBCZW1lcmt1bmcsICcnKSwNCiAgICAgICBUb3RJbiAgICAgICAgPSBJc051bGwoQFRvdEluLCAkMC4wM" +
                        "CksDQogICAgICAgVG90T3V0ICAgICAgID0gSXNOdWxsKEBUb3RPdXQsICQwLjAwKSwNCiAgICAgICBGZ" +
                        "WhsYmV0cmFnICAgPSBJc051bGwoQFRvdE91dCwgJDAuMDApIC0gSXNOdWxsKEBUb3RJbiwgJDAuMDApD" +
                        "QpGUk9NICAgQmdCdWRnZXQgQkJHDQogICAgICAgTEVGVCBKT0lOIEJnRmluYW56UGxhbiAgU0ZQIG9uI" +
                        "FNGUC5CZ0ZpbmFuelBsYW5JRCA9IEJCRy5CZ0ZpbmFuelBsYW5JRA0KICAgICAgIExFRlQgSk9JTiBGY" +
                        "UxlaXN0dW5nICAgIExFSSBvbiBMRUkuRmFMZWlzdHVuZ0lEID0gU0ZQLkZhTGVpc3R1bmdJRA0KICAgI" +
                        "CAgIExFRlQgSk9JTiBYT3JnVW5pdCAgICAgIE9SRyBvbiBPUkcuT3JnVW5pdElEID0gKA0KICAgICAgI" +
                        "CAgU0VMRUNUIFRPUCAxIE9VLk9yZ1VuaXRJRCBGUk9NIFhPcmdVbml0X1VzZXIgT1UNCiAgICAgICAgI" +
                        "FdIRVJFIE9VLlVzZXJJRCA9IExFSS5Vc2VySUQNCiAgICAgICAgICAgQU5EIE9VLk9yZ1VuaXRNZW1iZ" +
                        "XJDb2RlID0gMiApDQogICAgICAgTEVGVCBKT0lOIHZ3UGVyc29uIFBSUyBvbiBQUlMuQmFQZXJzb25JR" +
                        "CA9IExFSS5CYVBlcnNvbklEDQpXSEVSRSBMRUkuTW9kdWxJRCA9IDMgQU5EIEJCRy5CZ0J1ZGdldElEI" +
                        "D0gQEJnQnVkZ2V0SUQNCiAgQU5EIFNGUC5CZ0Jld2lsbGlndW5nU3RhdHVzQ29kZSBpbiAoNSwgOSkgL" +
                        "S0gbnVyIGJld2lsbGlndGUgdW5kIGdlc3BlcnJ0ZQ==";
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
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.ShFinanzplanverfuegungML_EinAus = new DevExpress.XtraReports.UI.Subreport();
            this.ShFinanzplanverfuegungML_Personen = new DevExpress.XtraReports.UI.Subreport();
            this.xrRichTextBox1 = new DevExpress.XtraReports.UI.XRRichTextBox();
            this.txtFehlbetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.Label25 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label24 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label23 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTotOut = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTotIn = new DevExpress.XtraReports.UI.XRLabel();
            this.Line13 = new DevExpress.XtraReports.UI.XRLine();
            this.Line12 = new DevExpress.XtraReports.UI.XRLine();
            this.Line11 = new DevExpress.XtraReports.UI.XRLine();
            this.Line10 = new DevExpress.XtraReports.UI.XRLine();
            this.Label12 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label11 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAnrede = new DevExpress.XtraReports.UI.XRLabel();
            this.Line8 = new DevExpress.XtraReports.UI.XRLine();
            this.Line7 = new DevExpress.XtraReports.UI.XRLine();
            this.Line6 = new DevExpress.XtraReports.UI.XRLine();
            this.Line4 = new DevExpress.XtraReports.UI.XRLine();
            this.Label9 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.Label8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.Label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel4,
                        this.xrLabel3,
                        this.xrPanel1,
                        this.xrLabel2,
                        this.xrLabel1,
                        this.xrLine1,
                        this.ShFinanzplanverfuegungML_EinAus,
                        this.ShFinanzplanverfuegungML_Personen,
                        this.xrRichTextBox1,
                        this.txtFehlbetrag,
                        this.Label25,
                        this.Label24,
                        this.Label23,
                        this.txtTotOut,
                        this.txtTotIn,
                        this.Line13,
                        this.Line12,
                        this.Line11,
                        this.Line10,
                        this.Label12,
                        this.Label11,
                        this.txtAnrede,
                        this.Line8,
                        this.Line7,
                        this.Line6,
                        this.Line4,
                        this.Label9,
                        this.Line3,
                        this.Label8,
                        this.Line2,
                        this.Label7,
                        this.Line1,
                        this.Label6,
                        this.Label5,
                        this.Label4,
                        this.Label3,
                        this.Label2,
                        this.txtTitle});
            this.Detail.Dpi = 254F;
            this.Detail.Height = 1916;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBackColor = false;
            this.Detail.ParentStyleUsing.UseBorderColor = false;
            this.Detail.ParentStyleUsing.UseBorders = false;
            this.Detail.ParentStyleUsing.UseBorderWidth = false;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.ParentStyleUsing.UseForeColor = false;
            // 
            // xrLabel4
            // 
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_RechtsmittelBelehrung", "")});
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.Location = new System.Drawing.Point(0, 1778);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(1842, 127);
            this.xrLabel4.Text = "xrLabel4";
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_HinweisText", "")});
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.Location = new System.Drawing.Point(402, 952);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(1440, 212);
            this.xrLabel3.Text = "xrLabel3";
            // 
            // xrPanel1
            // 
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageInfo1});
            this.xrPanel1.Dpi = 254F;
            this.xrPanel1.Location = new System.Drawing.Point(0, 1460);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.ParentStyleUsing.UseBorders = false;
            this.xrPanel1.Size = new System.Drawing.Size(444, 106);
            // 
            // xrLabel2
            // 
            this.xrLabel2.BackColor = System.Drawing.Color.Silver;
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_EmpfangsBestaetigung", "")});
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.Location = new System.Drawing.Point(804, 1397);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.ParentStyleUsing.UseBackColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorders = false;
            this.xrLabel2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.ParentStyleUsing.UseForeColor = false;
            this.xrLabel2.Size = new System.Drawing.Size(373, 38);
            this.xrLabel2.Text = "xrLabel2";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bemerkung", "")});
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel1.Location = new System.Drawing.Point(402, 1206);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(1458, 149);
            this.xrLabel1.Text = "xrLabel1";
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 254F;
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine1.LineWidth = 3;
            this.xrLine1.Location = new System.Drawing.Point(937, 719);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(10, 134);
            // 
            // ShFinanzplanverfuegungML_EinAus
            // 
            this.ShFinanzplanverfuegungML_EinAus.Dpi = 254F;
            this.ShFinanzplanverfuegungML_EinAus.Location = new System.Drawing.Point(0, 660);
            this.ShFinanzplanverfuegungML_EinAus.Name = "ShFinanzplanverfuegungML_EinAus";
            // 
            // ShFinanzplanverfuegungML_Personen
            // 
            this.ShFinanzplanverfuegungML_Personen.Dpi = 254F;
            this.ShFinanzplanverfuegungML_Personen.Location = new System.Drawing.Point(0, 429);
            this.ShFinanzplanverfuegungML_Personen.Name = "ShFinanzplanverfuegungML_Personen";
            // 
            // xrRichTextBox1
            // 
            this.xrRichTextBox1.CanShrink = true;
            this.xrRichTextBox1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Rtf", this.sqlQuery1, "OrgUnitAdresse", "")});
            this.xrRichTextBox1.Dpi = 254F;
            this.xrRichTextBox1.ForeColor = System.Drawing.Color.Black;
            this.xrRichTextBox1.Location = new System.Drawing.Point(0, 21);
            this.xrRichTextBox1.Name = "xrRichTextBox1";
            this.xrRichTextBox1.ParentStyleUsing.UseBackColor = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorderColor = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorders = false;
            this.xrRichTextBox1.ParentStyleUsing.UseBorderWidth = false;
            this.xrRichTextBox1.ParentStyleUsing.UseFont = false;
            this.xrRichTextBox1.ParentStyleUsing.UseForeColor = false;
            this.xrRichTextBox1.Size = new System.Drawing.Size(910, 233);
            // 
            // txtFehlbetrag
            // 
            this.txtFehlbetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Fehlbetrag", "{0:n2}")});
            this.txtFehlbetrag.Dpi = 254F;
            this.txtFehlbetrag.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.txtFehlbetrag.ForeColor = System.Drawing.Color.Black;
            this.txtFehlbetrag.Location = new System.Drawing.Point(1588, 874);
            this.txtFehlbetrag.Multiline = true;
            this.txtFehlbetrag.Name = "txtFehlbetrag";
            this.txtFehlbetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtFehlbetrag.ParentStyleUsing.UseBackColor = false;
            this.txtFehlbetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtFehlbetrag.ParentStyleUsing.UseBorders = false;
            this.txtFehlbetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtFehlbetrag.ParentStyleUsing.UseFont = false;
            this.txtFehlbetrag.ParentStyleUsing.UseForeColor = false;
            this.txtFehlbetrag.Size = new System.Drawing.Size(254, 38);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtFehlbetrag.Summary = xrSummary1;
            this.txtFehlbetrag.Text = "Fehlbetrag";
            this.txtFehlbetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label25
            // 
            this.Label25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_Fehlbetrag", "")});
            this.Label25.Dpi = 254F;
            this.Label25.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.Label25.ForeColor = System.Drawing.Color.Black;
            this.Label25.Location = new System.Drawing.Point(970, 874);
            this.Label25.Name = "Label25";
            this.Label25.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label25.ParentStyleUsing.UseBackColor = false;
            this.Label25.ParentStyleUsing.UseBorderColor = false;
            this.Label25.ParentStyleUsing.UseBorders = false;
            this.Label25.ParentStyleUsing.UseBorderWidth = false;
            this.Label25.ParentStyleUsing.UseFont = false;
            this.Label25.ParentStyleUsing.UseForeColor = false;
            this.Label25.Size = new System.Drawing.Size(612, 43);
            this.Label25.Text = "Label25";
            this.Label25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label24
            // 
            this.Label24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_TotalAusgaben", "")});
            this.Label24.Dpi = 254F;
            this.Label24.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label24.ForeColor = System.Drawing.Color.Black;
            this.Label24.Location = new System.Drawing.Point(970, 787);
            this.Label24.Name = "Label24";
            this.Label24.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label24.ParentStyleUsing.UseBackColor = false;
            this.Label24.ParentStyleUsing.UseBorderColor = false;
            this.Label24.ParentStyleUsing.UseBorders = false;
            this.Label24.ParentStyleUsing.UseBorderWidth = false;
            this.Label24.ParentStyleUsing.UseFont = false;
            this.Label24.ParentStyleUsing.UseForeColor = false;
            this.Label24.Size = new System.Drawing.Size(612, 39);
            this.Label24.Text = "Label24";
            this.Label24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label23
            // 
            this.Label23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_TotalEinnahmen", "")});
            this.Label23.Dpi = 254F;
            this.Label23.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label23.ForeColor = System.Drawing.Color.Black;
            this.Label23.Location = new System.Drawing.Point(3, 787);
            this.Label23.Name = "Label23";
            this.Label23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label23.ParentStyleUsing.UseBackColor = false;
            this.Label23.ParentStyleUsing.UseBorderColor = false;
            this.Label23.ParentStyleUsing.UseBorders = false;
            this.Label23.ParentStyleUsing.UseBorderWidth = false;
            this.Label23.ParentStyleUsing.UseFont = false;
            this.Label23.ParentStyleUsing.UseForeColor = false;
            this.Label23.Size = new System.Drawing.Size(655, 39);
            this.Label23.Text = "Label23";
            this.Label23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtTotOut
            // 
            this.txtTotOut.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TotOut", "{0:n2}")});
            this.txtTotOut.Dpi = 254F;
            this.txtTotOut.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtTotOut.ForeColor = System.Drawing.Color.Black;
            this.txtTotOut.Location = new System.Drawing.Point(1588, 787);
            this.txtTotOut.Multiline = true;
            this.txtTotOut.Name = "txtTotOut";
            this.txtTotOut.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtTotOut.ParentStyleUsing.UseBackColor = false;
            this.txtTotOut.ParentStyleUsing.UseBorderColor = false;
            this.txtTotOut.ParentStyleUsing.UseBorders = false;
            this.txtTotOut.ParentStyleUsing.UseBorderWidth = false;
            this.txtTotOut.ParentStyleUsing.UseFont = false;
            this.txtTotOut.ParentStyleUsing.UseForeColor = false;
            this.txtTotOut.Size = new System.Drawing.Size(254, 39);
            xrSummary2.FormatString = "{0:#,##0.00}";
            this.txtTotOut.Summary = xrSummary2;
            this.txtTotOut.Text = "TotOut";
            this.txtTotOut.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtTotIn
            // 
            this.txtTotIn.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TotIn", "{0:n2}")});
            this.txtTotIn.Dpi = 254F;
            this.txtTotIn.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtTotIn.ForeColor = System.Drawing.Color.Black;
            this.txtTotIn.Location = new System.Drawing.Point(665, 787);
            this.txtTotIn.Multiline = true;
            this.txtTotIn.Name = "txtTotIn";
            this.txtTotIn.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtTotIn.ParentStyleUsing.UseBackColor = false;
            this.txtTotIn.ParentStyleUsing.UseBorderColor = false;
            this.txtTotIn.ParentStyleUsing.UseBorders = false;
            this.txtTotIn.ParentStyleUsing.UseBorderWidth = false;
            this.txtTotIn.ParentStyleUsing.UseFont = false;
            this.txtTotIn.ParentStyleUsing.UseForeColor = false;
            this.txtTotIn.Size = new System.Drawing.Size(254, 39);
            xrSummary3.FormatString = "{0:#,##0.00}";
            this.txtTotIn.Summary = xrSummary3;
            this.txtTotIn.Text = "TotIn";
            this.txtTotIn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line13
            // 
            this.Line13.Dpi = 254F;
            this.Line13.ForeColor = System.Drawing.Color.Black;
            this.Line13.LineWidth = 3;
            this.Line13.Location = new System.Drawing.Point(3, 843);
            this.Line13.Name = "Line13";
            this.Line13.ParentStyleUsing.UseBackColor = false;
            this.Line13.ParentStyleUsing.UseBorderColor = false;
            this.Line13.ParentStyleUsing.UseBorders = false;
            this.Line13.ParentStyleUsing.UseBorderWidth = false;
            this.Line13.ParentStyleUsing.UseFont = false;
            this.Line13.ParentStyleUsing.UseForeColor = false;
            this.Line13.Size = new System.Drawing.Size(1854, 5);
            // 
            // Line12
            // 
            this.Line12.Dpi = 254F;
            this.Line12.ForeColor = System.Drawing.Color.Black;
            this.Line12.LineWidth = 3;
            this.Line12.Location = new System.Drawing.Point(3, 767);
            this.Line12.Name = "Line12";
            this.Line12.ParentStyleUsing.UseBackColor = false;
            this.Line12.ParentStyleUsing.UseBorderColor = false;
            this.Line12.ParentStyleUsing.UseBorders = false;
            this.Line12.ParentStyleUsing.UseBorderWidth = false;
            this.Line12.ParentStyleUsing.UseFont = false;
            this.Line12.ParentStyleUsing.UseForeColor = false;
            this.Line12.Size = new System.Drawing.Size(1854, 5);
            // 
            // Line11
            // 
            this.Line11.Dpi = 254F;
            this.Line11.ForeColor = System.Drawing.Color.Black;
            this.Line11.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line11.LineWidth = 3;
            this.Line11.Location = new System.Drawing.Point(937, 589);
            this.Line11.Name = "Line11";
            this.Line11.ParentStyleUsing.UseBackColor = false;
            this.Line11.ParentStyleUsing.UseBorderColor = false;
            this.Line11.ParentStyleUsing.UseBorders = false;
            this.Line11.ParentStyleUsing.UseBorderWidth = false;
            this.Line11.ParentStyleUsing.UseFont = false;
            this.Line11.ParentStyleUsing.UseForeColor = false;
            this.Line11.Size = new System.Drawing.Size(10, 84);
            // 
            // Line10
            // 
            this.Line10.Dpi = 254F;
            this.Line10.ForeColor = System.Drawing.Color.Black;
            this.Line10.LineWidth = 3;
            this.Line10.Location = new System.Drawing.Point(3, 640);
            this.Line10.Name = "Line10";
            this.Line10.ParentStyleUsing.UseBackColor = false;
            this.Line10.ParentStyleUsing.UseBorderColor = false;
            this.Line10.ParentStyleUsing.UseBorders = false;
            this.Line10.ParentStyleUsing.UseBorderWidth = false;
            this.Line10.ParentStyleUsing.UseFont = false;
            this.Line10.ParentStyleUsing.UseForeColor = false;
            this.Line10.Size = new System.Drawing.Size(1854, 5);
            // 
            // Label12
            // 
            this.Label12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_Ausgaben", "")});
            this.Label12.Dpi = 254F;
            this.Label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(971, 590);
            this.Label12.Name = "Label12";
            this.Label12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label12.ParentStyleUsing.UseBackColor = false;
            this.Label12.ParentStyleUsing.UseBorderColor = false;
            this.Label12.ParentStyleUsing.UseBorders = false;
            this.Label12.ParentStyleUsing.UseBorderWidth = false;
            this.Label12.ParentStyleUsing.UseFont = false;
            this.Label12.ParentStyleUsing.UseForeColor = false;
            this.Label12.Size = new System.Drawing.Size(508, 37);
            this.Label12.Text = "Label12";
            // 
            // Label11
            // 
            this.Label11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_Einnahmen", "")});
            this.Label11.Dpi = 254F;
            this.Label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(3, 590);
            this.Label11.Name = "Label11";
            this.Label11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label11.ParentStyleUsing.UseBackColor = false;
            this.Label11.ParentStyleUsing.UseBorderColor = false;
            this.Label11.ParentStyleUsing.UseBorders = false;
            this.Label11.ParentStyleUsing.UseBorderWidth = false;
            this.Label11.ParentStyleUsing.UseFont = false;
            this.Label11.ParentStyleUsing.UseForeColor = false;
            this.Label11.Size = new System.Drawing.Size(719, 37);
            this.Label11.Text = "Label11";
            // 
            // txtAnrede
            // 
            this.txtAnrede.CanGrow = false;
            this.txtAnrede.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Adresse", "")});
            this.txtAnrede.Dpi = 254F;
            this.txtAnrede.Font = new System.Drawing.Font("Arial", 11F);
            this.txtAnrede.ForeColor = System.Drawing.Color.Black;
            this.txtAnrede.Location = new System.Drawing.Point(1291, 21);
            this.txtAnrede.Multiline = true;
            this.txtAnrede.Name = "txtAnrede";
            this.txtAnrede.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtAnrede.ParentStyleUsing.UseBackColor = false;
            this.txtAnrede.ParentStyleUsing.UseBorderColor = false;
            this.txtAnrede.ParentStyleUsing.UseBorders = false;
            this.txtAnrede.ParentStyleUsing.UseBorderWidth = false;
            this.txtAnrede.ParentStyleUsing.UseFont = false;
            this.txtAnrede.ParentStyleUsing.UseForeColor = false;
            this.txtAnrede.Size = new System.Drawing.Size(540, 232);
            this.txtAnrede.Text = "Anrede";
            // 
            // Line8
            // 
            this.Line8.Dpi = 254F;
            this.Line8.ForeColor = System.Drawing.Color.Black;
            this.Line8.LineWidth = 3;
            this.Line8.Location = new System.Drawing.Point(0, 1378);
            this.Line8.Name = "Line8";
            this.Line8.ParentStyleUsing.UseBackColor = false;
            this.Line8.ParentStyleUsing.UseBorderColor = false;
            this.Line8.ParentStyleUsing.UseBorders = false;
            this.Line8.ParentStyleUsing.UseBorderWidth = false;
            this.Line8.ParentStyleUsing.UseFont = false;
            this.Line8.ParentStyleUsing.UseForeColor = false;
            this.Line8.Size = new System.Drawing.Size(1854, 6);
            // 
            // Line7
            // 
            this.Line7.Dpi = 254F;
            this.Line7.ForeColor = System.Drawing.Color.Black;
            this.Line7.LineWidth = 3;
            this.Line7.Location = new System.Drawing.Point(0, 1185);
            this.Line7.Name = "Line7";
            this.Line7.ParentStyleUsing.UseBackColor = false;
            this.Line7.ParentStyleUsing.UseBorderColor = false;
            this.Line7.ParentStyleUsing.UseBorders = false;
            this.Line7.ParentStyleUsing.UseBorderWidth = false;
            this.Line7.ParentStyleUsing.UseFont = false;
            this.Line7.ParentStyleUsing.UseForeColor = false;
            this.Line7.Size = new System.Drawing.Size(1854, 6);
            // 
            // Line6
            // 
            this.Line6.Dpi = 254F;
            this.Line6.ForeColor = System.Drawing.Color.Black;
            this.Line6.LineWidth = 3;
            this.Line6.Location = new System.Drawing.Point(0, 931);
            this.Line6.Name = "Line6";
            this.Line6.ParentStyleUsing.UseBackColor = false;
            this.Line6.ParentStyleUsing.UseBorderColor = false;
            this.Line6.ParentStyleUsing.UseBorders = false;
            this.Line6.ParentStyleUsing.UseBorderWidth = false;
            this.Line6.ParentStyleUsing.UseFont = false;
            this.Line6.ParentStyleUsing.UseForeColor = false;
            this.Line6.Size = new System.Drawing.Size(1854, 5);
            // 
            // Line4
            // 
            this.Line4.Dpi = 254F;
            this.Line4.ForeColor = System.Drawing.Color.Black;
            this.Line4.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.Line4.LineWidth = 3;
            this.Line4.Location = new System.Drawing.Point(799, 1680);
            this.Line4.Name = "Line4";
            this.Line4.ParentStyleUsing.UseBackColor = false;
            this.Line4.ParentStyleUsing.UseBorderColor = false;
            this.Line4.ParentStyleUsing.UseBorders = false;
            this.Line4.ParentStyleUsing.UseBorderWidth = false;
            this.Line4.ParentStyleUsing.UseFont = false;
            this.Line4.ParentStyleUsing.UseForeColor = false;
            this.Line4.Size = new System.Drawing.Size(620, 5);
            // 
            // Label9
            // 
            this.Label9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_Unterschrift", "")});
            this.Label9.Dpi = 254F;
            this.Label9.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(799, 1699);
            this.Label9.Name = "Label9";
            this.Label9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label9.ParentStyleUsing.UseBackColor = false;
            this.Label9.ParentStyleUsing.UseBorderColor = false;
            this.Label9.ParentStyleUsing.UseBorders = false;
            this.Label9.ParentStyleUsing.UseBorderWidth = false;
            this.Label9.ParentStyleUsing.UseFont = false;
            this.Label9.ParentStyleUsing.UseForeColor = false;
            this.Label9.Size = new System.Drawing.Size(620, 38);
            this.Label9.Text = "Label9";
            // 
            // Line3
            // 
            this.Line3.Dpi = 254F;
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.Line3.LineWidth = 3;
            this.Line3.Location = new System.Drawing.Point(799, 1553);
            this.Line3.Name = "Line3";
            this.Line3.ParentStyleUsing.UseBackColor = false;
            this.Line3.ParentStyleUsing.UseBorderColor = false;
            this.Line3.ParentStyleUsing.UseBorders = false;
            this.Line3.ParentStyleUsing.UseBorderWidth = false;
            this.Line3.ParentStyleUsing.UseFont = false;
            this.Line3.ParentStyleUsing.UseForeColor = false;
            this.Line3.Size = new System.Drawing.Size(620, 5);
            // 
            // Label8
            // 
            this.Label8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_OrtDatum", "")});
            this.Label8.Dpi = 254F;
            this.Label8.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(799, 1572);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(620, 38);
            this.Label8.Text = "Label8";
            // 
            // Line2
            // 
            this.Line2.Dpi = 254F;
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.Line2.LineWidth = 3;
            this.Line2.Location = new System.Drawing.Point(3, 1680);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(620, 5);
            // 
            // Label7
            // 
            this.Label7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_UnterschriftSD", "")});
            this.Label7.Dpi = 254F;
            this.Label7.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(3, 1699);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(620, 38);
            this.Label7.Text = "Label7";
            // 
            // Line1
            // 
            this.Line1.Dpi = 254F;
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.Line1.LineWidth = 3;
            this.Line1.Location = new System.Drawing.Point(3, 1553);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(620, 5);
            // 
            // Label6
            // 
            this.Label6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_OrtDatum", "")});
            this.Label6.Dpi = 254F;
            this.Label6.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(3, 1572);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(620, 38);
            this.Label6.Text = "Label6";
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.Color.Silver;
            this.Label5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_SozialhilfeBewilligt", "")});
            this.Label5.Dpi = 254F;
            this.Label5.Font = new System.Drawing.Font("Arial", 10F);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(0, 1397);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(373, 38);
            this.Label5.Text = "Label5";
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Silver;
            this.Label4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_Bemerkung", "")});
            this.Label4.Dpi = 254F;
            this.Label4.Font = new System.Drawing.Font("Arial", 10F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(0, 1206);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(373, 38);
            this.Label4.Text = "Label4";
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.Silver;
            this.Label3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_Hinweis", "")});
            this.Label3.Dpi = 254F;
            this.Label3.Font = new System.Drawing.Font("Arial", 10F);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(0, 952);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(373, 38);
            this.Label3.Text = "Label3";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Silver;
            this.Label2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_BudgetUebersicht", "")});
            this.Label2.Dpi = 254F;
            this.Label2.Font = new System.Drawing.Font("Arial", 10F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(3, 526);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(373, 38);
            this.Label2.Text = "Label2";
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.Silver;
            this.txtTitle.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Title", "")});
            this.txtTitle.Dpi = 254F;
            this.txtTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txtTitle.ForeColor = System.Drawing.Color.Black;
            this.txtTitle.Location = new System.Drawing.Point(0, 325);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtTitle.ParentStyleUsing.UseBackColor = false;
            this.txtTitle.ParentStyleUsing.UseBorderColor = false;
            this.txtTitle.ParentStyleUsing.UseBorders = false;
            this.txtTitle.ParentStyleUsing.UseBorderWidth = false;
            this.txtTitle.ParentStyleUsing.UseFont = false;
            this.txtTitle.ParentStyleUsing.UseForeColor = false;
            this.txtTitle.Size = new System.Drawing.Size(1854, 59);
            this.txtTitle.Text = "Title";
            this.txtTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 254F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 11F);
            this.xrPageInfo1.Format = "{0:dd.MM.yyyy}";
            this.xrPageInfo1.KeepTogether = false;
            this.xrPageInfo1.Location = new System.Drawing.Point(0, 42);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(423, 50);
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail});
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
		<FieldName>BgFinanzPlanID</FieldName>
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
</NewDataSet>' , SQLquery =  N'DECLARE @BgBudgetID  int,
        @GetDate     datetime
SELECT @BgBudgetID = BgBudgetID, @GetDate = GetDate()
FROM BgBudget
WHERE BgFinanzPlanID = {BgFinanzPlanID} AND MasterBudget = 1


DECLARE @TotIn money
DECLARE @TotOut money

SELECT @TotIn = SUM(Betrag)
FROM dbo.fnWhGetFinanzplanML(@BgBudgetID, @GetDate) TMP
WHERE TMP.BgKategorieCode = 1

SELECT @TotOut = SUM(CASE WHEN BgKategorieCode = 2 THEN TMP.Betrag ELSE -TMP.Betrag END)
FROM dbo.fnWhGetFinanzplanML(@BgBudgetID, @GetDate)  TMP
WHERE TMP.BgKategorieCode IN (2, 4)

DECLARE @SprachCode INT
SELECT @SprachCode = P.VerstaendigungSprachCode
FROM BgBudget B
  LEFT OUTER JOIN BgFinanzplan FP ON FP.BgFinanzplanID = B.BgFinanzplanID
  LEFT OUTER JOIN FaLeistung LEI ON LEI.FaLeistungID = FP.FaLeistungID
  LEFT OUTER JOIN FaFall FAL ON FAL.FaFallID = LEI.FaFallID
  LEFT OUTER JOIN BaPerson P ON P.BaPersonID = FAL.BaPersonID
WHERE B.BgBudgetID = @BgBudgetID
IF @SprachCode IS NULL SET @SprachCode = 1


DECLARE @Text_VerfuegungVom VARCHAR(200)
SELECT @Text_VerfuegungVom = dbo.fnGetMLTextFromName(''Report_Budget'', ''VerfuegungVom'', @SprachCode)  -- "Verfügung vom"
DECLARE @Text_SozialhilfeVom VARCHAR(200)
SELECT @Text_SozialhilfeVom = dbo.fnGetMLTextFromName(''Report_Budget'', ''SozialhilfeVom'', @SprachCode)  -- "Sozialhilfe vom"
DECLARE @Text_Bis VARCHAR(200)
SELECT @Text_Bis = dbo.fnGetMLTextFromName(''Report_Budget'', ''bis'', @SprachCode)  -- "bis"

DECLARE @Text_BudgetUebersicht VARCHAR(200)
SELECT @Text_BudgetUebersicht = dbo.fnGetMLTextFromName(''Report_Budget'', ''BudgetUebersicht'', @SprachCode)  -- "Budgetübersicht"
DECLARE @Text_Einnahmen VARCHAR(200)
SELECT @Text_Einnahmen = dbo.fnGetMLTextFromName(''Report_Budget'', ''Einnahmen'', @SprachCode)  -- "Einnahmen"
DECLARE @Text_Ausgaben VARCHAR(200)
SELECT @Text_Ausgaben = dbo.fnGetMLTextFromName(''Report_Budget'', ''Ausgaben'', @SprachCode)  -- "Ausgaben"
DECLARE @Text_Total VARCHAR(200)
SELECT @Text_Total = dbo.fnGetMLTextFromName(''Report_Budget'', ''Total'', @SprachCode)  -- "Total"
DECLARE @Text_Fehlbetrag VARCHAR(200)
SELECT @Text_Fehlbetrag = dbo.fnGetMLTextFromName(''Report_Budget'', ''Fehlbetrag'', @SprachCode)  -- "Fehlbetrag"
DECLARE @Text_Hinweis VARCHAR(200)
SELECT @Text_Hinweis = dbo.fnGetMLTextFromName(''Report_Budget'', ''Hinweis'', @SprachCode)  -- "Hinweis"
DECLARE @Text_HinweisText VARCHAR(2000)
SELECT @Text_HinweisText = dbo.fnGetMLTextFromName(''Report_Budget'', ''Report_FinanzPlan_HinweisText'', @SprachCode)  -- "Hinweis langer Text ...."
DECLARE @Text_Bemerkung VARCHAR(200)
SELECT @Text_Bemerkung = dbo.fnGetMLTextFromName(''Report_Budget'', ''Bemerkung'', @SprachCode)  -- "Bemerkung"
DECLARE @Text_SozialhilfeBewilligt VARCHAR(200)
SELECT @Text_SozialhilfeBewilligt = dbo.fnGetMLTextFromName(''Report_Budget'', ''SozialhilfeBewilligt'', @SprachCode)  -- "Sozialhilfe bewilligt"
DECLARE @Text_EmpfangsBestaetigung VARCHAR(200)
SELECT @Text_EmpfangsBestaetigung = dbo.fnGetMLTextFromName(''Report_Budget'', ''EmpfangsBestaetigung'', @SprachCode)  -- "Empfangsbestätigung"
DECLARE @Text_OrtDatum VARCHAR(200)
SELECT @Text_OrtDatum = dbo.fnGetMLTextFromName(''Report_Budget'', ''OrtDatum'', @SprachCode)  -- "Ort, Datum"
DECLARE @Text_Unterschrift VARCHAR(200)
SELECT @Text_Unterschrift = dbo.fnGetMLTextFromName(''Report_Budget'', ''UnterschriftKlient'', @SprachCode)  -- "Unterschrift"
DECLARE @Text_RechtsmittelBelehrung VARCHAR(2000)
SELECT @Text_RechtsmittelBelehrung = dbo.fnGetMLTextFromName(''Report_Budget'', ''Report_FinanzPlan_RechtsmittelBelehrung'', @SprachCode)  -- "RechtsmittelBelehrung"
DECLARE @Text_UnterschriftSD VARCHAR(200)
SELECT @Text_UnterschriftSD = dbo.fnGetMLTextFromName(''Report_Budget'', ''UnterschriftSozialdienst'', @SprachCode)  -- "Für den Sozialdienst" (Unterschrift)


DECLARE @Bemerkung varchar(8000),
        @ItemText     varchar(8000)

DECLARE cBemerkung CURSOR FAST_FORWARD FOR
  SELECT ''- '' +
    -- XLC.Text +
    dbo.fnLOVMLText(''BgGruppe'', SPT.BgGruppeCode, @SprachCode) +
    '' ('' + PRS.NameVorname + ''): '' + Convert(varchar(2000), BPO.Bemerkung)
  FROM BgPosition            BPO
    LEFT JOIN vwPerson       PRS ON PRS.BaPersonID = BPO.BaPersonID
    LEFT JOIN BgPositionsart SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
    -- LEFT JOIN XLOVCode       XLC ON XLC.LOVName = ''BgGruppe'' AND XLC.Code = SPT.BgGruppeCode
  WHERE BPO.BgBudgetID = @BgBudgetID
    AND BPO.BgPositionsartID BETWEEN 39000 AND 39999
    AND NOT (BPO.Bemerkung IS NULL OR Convert(varchar, BPO.Bemerkung) = '''')
    AND GetDate() BETWEEN IsNull(BPO.DatumVon, ''19000101'') AND IsNull(BPO.DatumBis, GetDate())
  ORDER BY PRS.NameVorname

OPEN cBemerkung
WHILE (1 = 1) BEGIN
  FETCH NEXT FROM cBemerkung INTO @ItemText
  IF @@FETCH_STATUS != 0 BREAK
  SET @Bemerkung = IsNull(@Bemerkung + char(10) + char(13), '''') + @ItemText
END
CLOSE cBemerkung
DEALLOCATE cBemerkung


SELECT
  Text_BudgetUebersicht = @Text_BudgetUebersicht,
  Text_Einnahmen = @Text_Einnahmen,
  Text_Ausgaben = @Text_Ausgaben,
  Text_TotalEinnahmen = @Text_Total + '' '' + @Text_Einnahmen,
  Text_TotalAusgaben = @Text_Total + '' '' + @Text_Ausgaben,
  Text_Fehlbetrag = @Text_Fehlbetrag,
  Text_Hinweis = @Text_Hinweis,
  Text_HinweisText = @Text_HinweisText,
  Text_Bemerkung = @Text_Bemerkung,
  Text_SozialhilfeBewilligt = @Text_SozialhilfeBewilligt,
  Text_EmpfangsBestaetigung = @Text_EmpfangsBestaetigung,
  Text_OrtDatum = @Text_OrtDatum,
  Text_Unterschrift = @Text_Unterschrift,
  Text_RechtsmittelBelehrung = @Text_RechtsmittelBelehrung,
  Text_UnterschriftSD = @Text_UnterschriftSD,

  BBG.BgBudgetID,
       OrgUnitAdresse = ORG.Text1,
       Title        = @Text_VerfuegungVom + '' '' + IsNull(CONVERT(varchar, (
                        SELECT MAX(Datum) FROM BgBewilligung BBW
                        WHERE BBW.BgFinanzPlanID=SFP.BgFinanzPlanID AND BBW.BgBewilligungCode = 2), 104), ''???'') +
                      '': '' + @Text_SozialhilfeVom + '' '' + CONVERT(varchar, SFP.DatumVon, 104) + '' '' + @Text_Bis + '' '' + CONVERT(varchar, SFP.DatumBis, 104),
       Adresse      = IsNull(PRS.Anrede + char(13) + char(10),'''') +
                      PRS.NameVorname + char(13) + char(10) +
                      PRS.WohnsitzStrasseHausNr + char(13) + char(10) +
                      PRS.WohnsitzPLZOrt,
       Bemerkung = IsNull(CONVERT(varchar(8000), SFP.Bemerkung) + char(10) + char(13), '''') + IsNull(@Bemerkung, ''''),
       TotIn        = IsNull(@TotIn, $0.00),
       TotOut       = IsNull(@TotOut, $0.00),
       Fehlbetrag   = IsNull(@TotOut, $0.00) - IsNull(@TotIn, $0.00)
FROM   BgBudget BBG
       LEFT JOIN BgFinanzPlan  SFP on SFP.BgFinanzPlanID = BBG.BgFinanzPlanID
       LEFT JOIN FaLeistung    LEI on LEI.FaLeistungID = SFP.FaLeistungID
       LEFT JOIN XOrgUnit      ORG on ORG.OrgUnitID = (
         SELECT TOP 1 OU.OrgUnitID FROM XOrgUnit_User OU
         WHERE OU.UserID = LEI.UserID
           AND OU.OrgUnitMemberCode = 2 )
       LEFT JOIN vwPerson PRS on PRS.BaPersonID = LEI.BaPersonID
WHERE LEI.ModulID = 3 AND BBG.BgBudgetID = @BgBudgetID
  AND SFP.BgBewilligungStatusCode in (5, 9) -- nur bewilligte und gesperrte' , ContextForms =  N'CtlBgUebersicht,CtlWhBudget' , ParentReportName =  null , ReportSortKey = 2
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'ShFinanzplanverfuegungML' ;


INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShFinanzplanverfuegungML_EinAus' ,  N'Einnahmen, Ausgaben' , 1,  N'<!--
AssemblyName=DevExpress%2EXtraReports%2C%20Version%3D1%2E7%2E10%2E0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4
AssemblyLocation=c:\windows\assembly\gac\devexpress.xtrareports\1.7.10.0__79868b8147b5eae4\devexpress.xtrareports.dll
TypeName=DevExpress.XtraReports.UI.XtraReport
Localization=de-DE
-->
<SOAP-ENV:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:SOAP-ENC="http://schemas.xmlsoap.org/soap/encoding/" xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/" xmlns:clr="http://schemas.microsoft.com/soap/encoding/clr/1.0" SOAP-ENV:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
<SOAP-ENV:Body>
<a1:ReportStorage id="ref-1" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<BandCount>1</BandCount>
<Band0 href="#ref-6"/>
<Visible>true</Visible>
<Tag id="ref-7"></Tag>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-8">Report</Name>
<Style_X_Font id="ref-9">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor id="ref-10">ControlText</Style_X_ForeColor>
<Style_X_BackColor id="ref-11">Transparent</Style_X_BackColor>
<Style_X_BorderColor href="#ref-10"/>
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
<Text href="#ref-7"/>
<NavigateUrl href="#ref-7"/>
<Target href="#ref-7"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>100</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<DataSource id="ref-12">dataSource</DataSource>
<UseDefaultPrinterSettings>false</UseDefaultPrinterSettings>
<ReportUnit xsi:type="a2:ReportUnit" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">HundredthsOfAnInch</ReportUnit>
<Landscape>false</Landscape>
<PaperKind xsi:type="a5:PaperKind" xmlns:a5="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Printing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Letter</PaperKind>
<PaperName href="#ref-7"/>
<Margins xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>100</x>
<y>100</y>
<width>10</width>
<height>100</height>
</Margins>
<HtmlCompressed>false</HtmlCompressed>
<PageSize xsi:type="a4:Size" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<width>850</width>
<height>1100</height>
</PageSize>
<StyleSheet_X_StyleCount>0</StyleSheet_X_StyleCount>
<ShowPreviewMarginLines>true</ShowPreviewMarginLines>
<ScriptLanguage xsi:type="a6:ScriptLanguage" xmlns:a6="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">CSharp</ScriptLanguage>
<Watermark_X_Text href="#ref-7"/>
<Watermark_X_Font id="ref-13">Verdana, 36pt</Watermark_X_Font>
<Watermark_X_ForeColor id="ref-14">Red</Watermark_X_ForeColor>
<Watermark_X_Transparency>50</Watermark_X_Transparency>
<Watermark_X_TextDirection xsi:type="a7:DirectionMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">ForwardDiagonal</Watermark_X_TextDirection>
<Watermark_X_Image xsi:type="xsd:anyType" xsi:null="1"/>
<Watermark_X_ImageAlign xsi:type="a4:ContentAlignment" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">MiddleCenter</Watermark_X_ImageAlign>
<Watermark_X_ImageViewMode xsi:type="a7:ImageViewMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Clip</Watermark_X_ImageViewMode>
<Watermark_X_ImageTiling>false</Watermark_X_ImageTiling>
<Watermark_X_PageRange href="#ref-7"/>
<Watermark_X_ShowBehind>true</Watermark_X_ShowBehind>
<DefaultPrinterSettingsUsing_X_UseMargins>false</DefaultPrinterSettingsUsing_X_UseMargins>
<DefaultPrinterSettingsUsing_X_UsePaperKind>false</DefaultPrinterSettingsUsing_X_UsePaperKind>
<DefaultPrinterSettingsUsing_X_UseLandscape>false</DefaultPrinterSettingsUsing_X_UseLandscape>
<ShrinkSubReportIconArea>true</ShrinkSubReportIconArea>
</a1:ReportStorage>
<a1:ObjectStorage id="ref-6" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName id="ref-15">DevExpress.XtraReports, Version=1.7.10.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</Type_X_AssemblyName>
<Type_X_TypeName id="ref-16">DevExpress.XtraReports.UI.DetailBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-7"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-17">Detail</Name>
<Style_X_Font id="ref-18">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-10"/>
<Style_X_BackColor href="#ref-11"/>
<Style_X_BorderColor href="#ref-10"/>
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
<Text href="#ref-7"/>
<NavigateUrl href="#ref-7"/>
<Target href="#ref-7"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<EventsScript_X_OnBeforePrint id="ref-19">private void OnBeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
  //xrLine1.Height = Detail.Height = 444;
}</EventsScript_X_OnBeforePrint>
<Height>18</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<PrintOnEmptyDataSource>true</PrintOnEmptyDataSource>
<MultiColumn_X_ColumnCount>1</MultiColumn_X_ColumnCount>
<MultiColumn_X_Direction xsi:type="a2:ColumnDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">DownThenAcross</MultiColumn_X_Direction>
<MultiColumn_X_ColumnWidth>0</MultiColumn_X_ColumnWidth>
<MultiColumn_X_ColumnSpacing>0</MultiColumn_X_ColumnSpacing>
<MultiColumn_X_Mode xsi:type="a2:MultiColumnMode" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</MultiColumn_X_Mode>
<RepeatCountOnEmptyDataSource>1</RepeatCountOnEmptyDataSource>
<ItemCount>5</ItemCount>
<Item0 href="#ref-20"/>
<Item1 href="#ref-21"/>
<Item2 href="#ref-22"/>
<Item3 href="#ref-23"/>
<Item4 href="#ref-24"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-20" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-15"/>
<Type_X_TypeName id="ref-25">DevExpress.XtraReports.UI.XRLine</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-7"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-26">xrLine1</Name>
<Style_X_Font id="ref-27">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-10"/>
<Style_X_BackColor href="#ref-11"/>
<Style_X_BorderColor href="#ref-10"/>
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
<x>367</x>
<y>0</y>
<width>8</width>
<height>18</height>
</Bounds>
<Text href="#ref-7"/>
<NavigateUrl href="#ref-7"/>
<Target href="#ref-7"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Vertical</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-21" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-15"/>
<Type_X_TypeName id="ref-28">DevExpress.XtraReports.UI.XRLabel</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-7"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-29">xrLabel4</Name>
<Style_X_Font id="ref-30">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-10"/>
<Style_X_BackColor href="#ref-11"/>
<Style_X_BorderColor href="#ref-10"/>
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
<ParentStyleUsing_X_UseForeColor>true</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>true</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>true</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>true</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>true</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-31">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-32">BetragAus</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-33">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-12"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>622</x>
<y>0</y>
<width>100</width>
<height>18</height>
</Bounds>
<Text id="ref-34">xrLabel2</Text>
<NavigateUrl href="#ref-7"/>
<Target href="#ref-7"/>
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
<a1:ObjectStorage id="ref-22" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-15"/>
<Type_X_TypeName href="#ref-28"/>
<Visible>true</Visible>
<Tag href="#ref-7"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-35">xrLabel3</Name>
<Style_X_Font id="ref-36">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-10"/>
<Style_X_BackColor href="#ref-11"/>
<Style_X_BorderColor href="#ref-10"/>
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
<ParentStyleUsing_X_UseForeColor>true</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>true</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>true</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>true</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>true</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-37">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-38">TextAus</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-7"/>
<BindingItem0_X_DataSource href="#ref-12"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>379</x>
<y>0</y>
<width>258</width>
<height>18</height>
</Bounds>
<Text id="ref-39">xrLabel1</Text>
<NavigateUrl href="#ref-7"/>
<Target href="#ref-7"/>
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
<a1:ObjectStorage id="ref-23" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-15"/>
<Type_X_TypeName href="#ref-28"/>
<Visible>true</Visible>
<Tag href="#ref-7"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-40">xrLabel2</Name>
<Style_X_Font id="ref-41">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-10"/>
<Style_X_BackColor href="#ref-11"/>
<Style_X_BorderColor href="#ref-10"/>
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
<ParentStyleUsing_X_UseForeColor>true</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>true</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>true</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>true</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>true</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-42">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-43">BetragEin</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-44">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-12"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>259</x>
<y>0</y>
<width>100</width>
<height>18</height>
</Bounds>
<Text href="#ref-40"/>
<NavigateUrl href="#ref-7"/>
<Target href="#ref-7"/>
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
<a1:ObjectStorage id="ref-24" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-15"/>
<Type_X_TypeName href="#ref-28"/>
<Visible>true</Visible>
<Tag href="#ref-7"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-45">xrLabel1</Name>
<Style_X_Font id="ref-46">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-10"/>
<Style_X_BackColor href="#ref-11"/>
<Style_X_BorderColor href="#ref-10"/>
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
<ParentStyleUsing_X_UseForeColor>true</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>true</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>true</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>true</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>true</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName href="#ref-42"/>
<BindingItem0_X_DataMember id="ref-47">TextEin</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-7"/>
<BindingItem0_X_DataSource href="#ref-12"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>1</x>
<y>0</y>
<width>275</width>
<height>18</height>
</Bounds>
<Text href="#ref-45"/>
<NavigateUrl href="#ref-7"/>
<Target href="#ref-7"/>
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
</SOAP-ENV:Body>
</SOAP-ENV:Envelope>' ,  null ,  N'DECLARE @BgBudgetID  int,
        @GetDate     datetime

SELECT @BgBudgetID = BgBudgetID, @GetDate = GetDate()
FROM BgBudget
WHERE BgFinanzPlanID = {BgFinanzPlanID}
  AND MasterBudget = 1

DECLARE @Einnahmen TABLE (id int identity, Text varchar(100), Betrag money)
DECLARE @Ausgaben  TABLE (id int identity, Text varchar(100), Betrag money)

-- Einnahmen
INSERT INTO @Einnahmen (Text, Betrag)
  SELECT TMP.Bezeichnung, TMP.Betrag
  FROM dbo.fnWhGetFinanzplanML(@BgBudgetID, @GetDate)  TMP
  WHERE BgKategorieCode = 1

-- Ausgaben / Kürzungen
INSERT INTO @Ausgaben (Text, Betrag)
  SELECT
    /* CASE
      WHEN TMP.Bezeichnung LIKE ''Med. Grund%(KVG)'' THEN ''KVG Prämien''
      WHEN TMP.Bezeichnung LIKE ''Med. Grund%(VVG)'' THEN ''VVG Prämien''
      ELSE TMP.Bezeichnung
    END, */
    TMP.Bezeichnung,
    CASE
      WHEN BgKategorieCode = 2 THEN TMP.Betrag
      ELSE -TMP.Betrag
    END
  FROM dbo.fnWhGetFinanzplanML(@BgBudgetID, @GetDate)  TMP
  WHERE BgKategorieCode IN (2, 4) -- Ausgaben / Kürzungen
    AND (TMP.Betrag != $0.00 OR (BgKategorieCode = 2 AND BgGruppeCode LIKE ''[0-9]%''))

SELECT
  TextEin = EIN.Text, BetragEin = EIN.Betrag,
  TextAus = AUS.Text, BetragAus = AUS.Betrag
FROM @Einnahmen EIN
  FULL JOIN @Ausgaben AUS ON AUS.id = EIN.id' ,  null ,  N'ShFinanzplanverfuegungML' ,  null );


INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShFinanzplanverfuegungML_Personen' ,  N'Personen' , 1,  N'/// <XRTypeInfo>
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
        private DevExpress.XtraReports.UI.XRLabel txtHeimatort;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtGebDat;
        private DevExpress.XtraReports.UI.XRLabel txtName;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
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
                        "AAAAYYLREVDTEFSRSBAU3ByYWNoQ29kZSBJTlQNClNFTEVDVCBAU3ByYWNoQ29kZSA9IFAuVmVyc3RhZ" +
                        "W5kaWd1bmdTcHJhY2hDb2RlIA0KRlJPTSBCZ0J1ZGdldCBCDQogIExFRlQgT1VURVIgSk9JTiBCZ0Zpb" +
                        "mFuenBsYW4gRlAgT04gRlAuQmdGaW5hbnpwbGFuSUQgPSBCLkJnRmluYW56cGxhbklEDQogIExFRlQgT" +
                        "1VURVIgSk9JTiBGYUxlaXN0dW5nIExFSSBPTiBMRUkuRmFMZWlzdHVuZ0lEID0gRlAuRmFMZWlzdHVuZ" +
                        "0lEDQogIExFRlQgT1VURVIgSk9JTiBGYUZhbGwgRkFMIE9OIEZBTC5GYUZhbGxJRCA9IExFSS5GYUZhb" +
                        "GxJRA0KICBMRUZUIE9VVEVSIEpPSU4gQmFQZXJzb24gUCBPTiBQLkJhUGVyc29uSUQgPSBGQUwuQmFQZ" +
                        "XJzb25JRA0KV0hFUkUgRlAuQmdGaW5hbnpQbGFuSUQgPSBudWxsIEFORCBCLk1hc3RlckJ1ZGdldCA9I" +
                        "DENCklGIEBTcHJhY2hDb2RlIElTIE5VTEwgU0VUIEBTcHJhY2hDb2RlID0gMQ0KDQoNCkRFQ0xBUkUgQ" +
                        "FRleHRfVW50ZXJzdHVldHp0ZVBlcnNvbmVuIFZBUkNIQVIoMjAwKQ0KU0VMRUNUIEBUZXh0X1VudGVyc" +
                        "3R1ZXR6dGVQZXJzb25lbiA9IGRiby5mbkdldE1MVGV4dCgxMDI2LCBAU3ByYWNoQ29kZSkgIC0tICJVb" +
                        "nRlcnN0w7x0enRlIFBlcnNvbmVuIg0KREVDTEFSRSBAVGV4dF9OYW1lIFZBUkNIQVIoMjAwKQ0KU0VMR" +
                        "UNUIEBUZXh0X05hbWUgPSBkYm8uZm5HZXRNTFRleHQoMTAyNywgQFNwcmFjaENvZGUpICAtLSAiTmFtZ" +
                        "SINCkRFQ0xBUkUgQFRleHRfR2ViRGF0dW0gVkFSQ0hBUigyMDApDQpTRUxFQ1QgQFRleHRfR2ViRGF0d" +
                        "W0gPSBkYm8uZm5HZXRNTFRleHQoMTYzMywgQFNwcmFjaENvZGUpICANCkRFQ0xBUkUgQFRleHRfTmF0a" +
                        "W9uYWxpdGFldCBWQVJDSEFSKDIwMCkNClNFTEVDVCBAVGV4dF9OYXRpb25hbGl0YWV0ID0gZGJvLmZuR" +
                        "2V0TUxUZXh0KDE2MzQsIEBTcHJhY2hDb2RlKQ0KICANCg0KU0VMRUNUDQogIFRleHRfVW50ZXJzdHVld" +
                        "Hp0ZVBlcnNvbmVuID0gQFRleHRfVW50ZXJzdHVldHp0ZVBlcnNvbmVuLA0KICBUZXh0X05hbWUgPSBAV" +
                        "GV4dF9OYW1lLA0KICBUZXh0X0dlYkRhdHVtID0gQFRleHRfR2ViRGF0dW0sDQogIFRleHRfTmF0aW9uY" +
                        "WxpdGFldCA9IEBUZXh0X05hdGlvbmFsaXRhZXQsDQogIE5hbWUgPSBQUlMuTmFtZSArIElzTnVsbCgnL" +
                        "CAnICsgUFJTLlZvcm5hbWUsICcnKSwNCiAgUFJTLkdlYnVydHNkYXR1bSwNCiAgTmF0aW9uYWxpdGFld" +
                        "CA9IGRiby5mbkxPVk1MVGV4dCgnQmFMYW5kJywgUFJTLk5hdGlvbmFsaXRhZXRDb2RlLCBAU3ByYWNoQ" +
                        "29kZSkNCkZST00gQmdGaW5hbnpQbGFuX0JhUGVyc29uIFNQUA0KICBMRUZUIEpPSU4gQmFQZXJzb24gU" +
                        "FJTIE9OIFBSUy5CYVBlcnNvbklEID0gU1BQLkJhUGVyc29uSUQNCldIRVJFIFNQUC5CZ0ZpbmFuelBsY" +
                        "W5JRCA9IG51bGwNCkFORCBTUFAuSXN0VW50ZXJzdHVldHp0ID0gMQ==";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.txtHeimatort = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGebDat = new DevExpress.XtraReports.UI.XRLabel();
            this.txtName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtHeimatort,
                        this.txtGebDat,
                        this.txtName});
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
                        this.xrLabel4,
                        this.xrLine1,
                        this.xrLabel3,
                        this.xrLabel2,
                        this.xrLabel1});
            this.ReportHeader.Height = 22;
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
            this.ReportFooter.Height = 2;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
            this.ReportFooter.Visible = false;
            // 
            // txtHeimatort
            // 
            this.txtHeimatort.CanShrink = true;
            this.txtHeimatort.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Nationalitaet", "")});
            this.txtHeimatort.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtHeimatort.ForeColor = System.Drawing.Color.Black;
            this.txtHeimatort.Location = new System.Drawing.Point(572, 0);
            this.txtHeimatort.Multiline = true;
            this.txtHeimatort.Name = "txtHeimatort";
            this.txtHeimatort.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtHeimatort.ParentStyleUsing.UseBackColor = false;
            this.txtHeimatort.ParentStyleUsing.UseBorderColor = false;
            this.txtHeimatort.ParentStyleUsing.UseBorders = false;
            this.txtHeimatort.ParentStyleUsing.UseBorderWidth = false;
            this.txtHeimatort.ParentStyleUsing.UseFont = false;
            this.txtHeimatort.ParentStyleUsing.UseForeColor = false;
            this.txtHeimatort.Size = new System.Drawing.Size(152, 15);
            this.txtHeimatort.Text = "Heimatort";
            // 
            // txtGebDat
            // 
            this.txtGebDat.CanShrink = true;
            this.txtGebDat.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Geburtsdatum", "{0:dd.MM.yyyy}")});
            this.txtGebDat.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtGebDat.ForeColor = System.Drawing.Color.Black;
            this.txtGebDat.Location = new System.Drawing.Point(464, 0);
            this.txtGebDat.Multiline = true;
            this.txtGebDat.Name = "txtGebDat";
            this.txtGebDat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGebDat.ParentStyleUsing.UseBackColor = false;
            this.txtGebDat.ParentStyleUsing.UseBorderColor = false;
            this.txtGebDat.ParentStyleUsing.UseBorders = false;
            this.txtGebDat.ParentStyleUsing.UseBorderWidth = false;
            this.txtGebDat.ParentStyleUsing.UseFont = false;
            this.txtGebDat.ParentStyleUsing.UseForeColor = false;
            this.txtGebDat.Size = new System.Drawing.Size(109, 15);
            xrSummary1.FormatString = "{0:dd.MM.yyyy}";
            this.txtGebDat.Summary = xrSummary1;
            this.txtGebDat.Text = "GebDat";
            // 
            // txtName
            // 
            this.txtName.CanShrink = true;
            this.txtName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.txtName.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(155, 0);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtName.ParentStyleUsing.UseBackColor = false;
            this.txtName.ParentStyleUsing.UseBorderColor = false;
            this.txtName.ParentStyleUsing.UseBorders = false;
            this.txtName.ParentStyleUsing.UseBorderWidth = false;
            this.txtName.ParentStyleUsing.UseFont = false;
            this.txtName.ParentStyleUsing.UseForeColor = false;
            this.txtName.Size = new System.Drawing.Size(307, 15);
            this.txtName.Text = "Name";
            // 
            // xrLabel4
            // 
            this.xrLabel4.BackColor = System.Drawing.Color.Silver;
            this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_UnterstuetztePersonen", "")});
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.Location = new System.Drawing.Point(0, 2);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.ParentStyleUsing.UseForeColor = false;
            this.xrLabel4.Size = new System.Drawing.Size(147, 15);
            this.xrLabel4.Text = "xrLabel4";
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.Location = new System.Drawing.Point(155, 16);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(570, 2);
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_Nationalitaet", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(572, 0);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(152, 15);
            this.xrLabel3.Text = "xrLabel3";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_GebDatum", "")});
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.Location = new System.Drawing.Point(464, 0);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseBackColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorders = false;
            this.xrLabel2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.ParentStyleUsing.UseForeColor = false;
            this.xrLabel2.Size = new System.Drawing.Size(101, 15);
            this.xrLabel2.Text = "xrLabel2";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_Name", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.Location = new System.Drawing.Point(155, 0);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseBackColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.ParentStyleUsing.UseForeColor = false;
            this.xrLabel1.Size = new System.Drawing.Size(307, 15);
            this.xrLabel1.Text = "xrLabel1";
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
            this.Margins = new System.Drawing.Printing.Margins(100, 5, 100, 100);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  null ,  N'DECLARE @SprachCode INT
SELECT @SprachCode = P.VerstaendigungSprachCode
FROM BgBudget B
  LEFT OUTER JOIN BgFinanzplan FP ON FP.BgFinanzplanID = B.BgFinanzplanID
  LEFT OUTER JOIN FaLeistung LEI ON LEI.FaLeistungID = FP.FaLeistungID
  LEFT OUTER JOIN FaFall FAL ON FAL.FaFallID = LEI.FaFallID
  LEFT OUTER JOIN BaPerson P ON P.BaPersonID = FAL.BaPersonID
WHERE FP.BgFinanzPlanID = {BgFinanzPlanID} AND B.MasterBudget = 1
IF @SprachCode IS NULL SET @SprachCode = 1


DECLARE @Text_UnterstuetztePersonen VARCHAR(200)
SELECT @Text_UnterstuetztePersonen = dbo.fnGetMLTextFromName(''Report_Budget'', ''UnterstuetztePersonen'', @SprachCode)
DECLARE @Text_Name VARCHAR(200)
SELECT @Text_Name = dbo.fnGetMLTextFromName(''Report_Budget'', ''Name'', @SprachCode)
DECLARE @Text_GebDatum VARCHAR(200)
SELECT @Text_GebDatum = dbo.fnGetMLTextFromName(''Report_Budget'', ''Geburtsdatum'', @SprachCode)
DECLARE @Text_Nationalitaet VARCHAR(200)
SELECT @Text_Nationalitaet = dbo.fnGetMLTextFromName(''Report_Budget'', ''Nationalitaet'', @SprachCode)


SELECT
  Text_UnterstuetztePersonen = @Text_UnterstuetztePersonen,
  Text_Name = @Text_Name,
  Text_GebDatum = @Text_GebDatum,
  Text_Nationalitaet = @Text_Nationalitaet,
  Name = PRS.Name + IsNull('', '' + PRS.Vorname, ''''),
  PRS.Geburtsdatum,
  Nationalitaet = dbo.fnLOVMLText(''BaLand'', PRS.NationalitaetCode, @SprachCode)
FROM BgFinanzPlan_BaPerson SPP
  LEFT JOIN BaPerson PRS ON PRS.BaPersonID = SPP.BaPersonID
WHERE SPP.BgFinanzPlanID = {BgFinanzPlanID}
AND SPP.IstUnterstuetzt = 1' ,  null ,  N'ShFinanzplanverfuegungML' ,  null );


