-- Insert Script for KbZUGAbrechnung
DELETE FROM XQuery WHERE QueryName LIKE 'KbZUGAbrechnung' OR ParentReportName LIKE 'KbZUGAbrechnung'
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'KbZUGAbrechnung' ,  N'KB - ZUG Abrechnung' , 1,  N'/// <XRTypeInfo>
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
///     <Reference Path="C:\Temp\KiSS4_Migration\KiSS4.DB.dll" />
///     <Reference Path="C:\Temp\KiSS4_Migration\SharpLibrary.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraTreeList.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\DevExpress.XtraGrid.v6.2\6.2.6.0__79868b8147b5eae4\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell11;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell13;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell16;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell17;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell18;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell19;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRPictureBox picLogo;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell20;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell21;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRTable tabAbzuege;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow26;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell73;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell74;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell75;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow27;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell76;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell77;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell78;
        private DevExpress.XtraReports.UI.XRTable tabEinnahmen;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow20;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell55;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell56;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell57;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow21;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell58;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell59;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell60;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow22;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell61;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell62;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell63;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow23;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell64;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell65;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell66;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow24;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell67;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell68;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell69;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow25;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell70;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell71;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell72;
        private DevExpress.XtraReports.UI.XRLabel lblEinnahmen;
        private DevExpress.XtraReports.UI.XRTable tabAusgaben;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell25;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell26;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell27;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow11;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell28;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell29;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell30;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow12;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell31;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell32;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell33;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow13;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell34;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell35;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell36;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell37;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell38;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell39;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow15;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell40;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell41;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell42;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow16;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell43;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell44;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell45;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow17;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell46;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell47;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell48;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow18;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell49;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell50;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell51;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow19;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell52;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell53;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell54;
        private DevExpress.XtraReports.UI.XRLabel lblAusgaben;
        private DevExpress.XtraReports.UI.XRTable tabAnteilHeimatKanton;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow9;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell15;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell22;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell23;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell24;
        private DevExpress.XtraReports.UI.XRLabel lblAbzuege;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAACAAAAAQAAAGhTeXN0ZW0uRHJhd" +
                        "2luZy5CaXRtYXAsIFN5c3RlbS5EcmF3aW5nLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhb" +
                        "CwgUHVibGljS2V5VG9rZW49YjAzZjVmN2YxMWQ1MGEzYVBBRFBBRBO0TqSd/hLEHwAAAAAAAACCAQAAG" +
                        "nAAaQBjAEwAbwBnAG8ALgBJAG0AYQBnAGUAAAAAADJzAHEAbABRAHUAZQByAHkAMQAuAFMAZQBsAGUAY" +
                        "wB0AFMAdABhAHQAZQBtAGUAbgB0ANkLAABAAAEAAAD/////AQAAAAAAAAAMAgAAAFFTeXN0ZW0uRHJhd" +
                        "2luZywgVmVyc2lvbj0yLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1Z" +
                        "jdmMTFkNTBhM2EFAQAAABVTeXN0ZW0uRHJhd2luZy5CaXRtYXABAAAABERhdGEHAgIAAAAJAwAAAA8DA" +
                        "AAANgsAAAJHSUY4OWGNAPUA9wAAAAAAgAAAAIAAgIAAAACAgACAAICAgICAwMDA/wAAAP8A//8AAAD//" +
                        "wD/AP//////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                        "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAzAABmAACZAADMAAD/ADMAADMzADNmADOZADPMADP/AGYAA" +
                        "GYzAGZmAGaZAGbMAGb/AJkAAJkzAJlmAJmZAJnMAJn/AMwAAMwzAMxmAMyZAMzMAMz/AP8AAP8zAP9mA" +
                        "P+ZAP/MAP//MwAAMwAzMwBmMwCZMwDMMwD/MzMAMzMzMzNmMzOZMzPMMzP/M2YAM2YzM2ZmM2aZM2bMM" +
                        "2b/M5kAM5kzM5lmM5mZM5nMM5n/M8wAM8wzM8xmM8yZM8zMM8z/M/8AM/8zM/9mM/+ZM//MM///ZgAAZ" +
                        "gAzZgBmZgCZZgDMZgD/ZjMAZjMzZjNmZjOZZjPMZjP/ZmYAZmYzZmZmZmaZZmbMZmb/ZpkAZpkzZplmZ" +
                        "pmZZpnMZpn/ZswAZswzZsxmZsyZZszMZsz/Zv8AZv8zZv9mZv+ZZv/MZv//mQAAmQAzmQBmmQCZmQDMm" +
                        "QD/mTMAmTMzmTNmmTOZmTPMmTP/mWYAmWYzmWZmmWaZmWbMmWb/mZkAmZkzmZlmmZmZmZnMmZn/mcwAm" +
                        "cwzmcxmmcyZmczMmcz/mf8Amf8zmf9mmf+Zmf/Mmf//zAAAzAAzzABmzACZzADMzAD/zDMAzDMzzDNmz" +
                        "DOZzDPMzDP/zGYAzGYzzGZmzGaZzGbMzGb/zJkAzJkzzJlmzJmZzJnMzJn/zMwAzMwzzMxmzMyZzMzMz" +
                        "Mz/zP8AzP8zzP9mzP+ZzP/MzP///wAA/wAz/wBm/wCZ/wDM/wD//zMA/zMz/zNm/zOZ/zPM/zP//2YA/" +
                        "2Yz/2Zm/2aZ/2bM/2b//5kA/5kz/5lm/5mZ/5nM/5n//8wA/8wz/8xm/8yZ/8zM/8z///8A//8z//9m/" +
                        "/+Z///M////IfkEAQAAEAAsAAAAAI0A9QAACP8A/wkcSLCgwYMIEypcyLChw4cQI0qcSLGixYsYM2rcy" +
                        "LGjx48gQ4ocSbKkyZMoU6pkiGKlRhQwXV6E2VJmxZgxbUqkmVPnQ57/gPpsyJPmUKJAix5dWNTo0oNNW" +
                        "zZ9CjVqT6pBo2adinWr1ZpUv3pVGlYp16dix5I9evbs0K81k67V6VYtW7gC4V51WTfvXL5ThZrtm5KwX" +
                        "ZlaySo2XJIxY5Jax/p1qhZsYaEJH4eMLLnzZMoo/1bFfJKzZ9KHQ6NGqNljXdJ/RY9snbqxaNioZYvUb" +
                        "ZD2xr64QX+2DHl1ZuObjQff69m2cIW8P8peTrx58efHmc9WDno69t3feyP/T46d+ujq28MTjO76tvmCv" +
                        "jPSNg1+9Vz38SfihZ62/vP79lklnV5M7deegOu9NxCB/LGnV3gPopegZgwuqKB4hlWIYX4T8qZhh+oBq" +
                        "F5lG/YHonY7ERbheSha2N14LgoXIXMcNvjfjPCx15yOO3KF4HAS3iSiYK/BGKNlPA5JI3VBUuQWfpTNd" +
                        "2F2UXL3opEpTjnckU0eCaJDa3mHGY9Z9qTimElqyRqa5YWJpX5stlnlm0qCGSd6bb1ZJpJWmpnmlS3mO" +
                        "OeNgHbppJZ50qlmiSfyyeSBVxV5p6E9jrhloz8C2dGTMzpqaaWBairohzUWSOiHta1ZKEtimsjlb61m/" +
                        "/qqqZEa6ZirXFLKqm4Glhhonap6iGuua1rIIoTD5kpcXAquGKysmNLXKZXQKuvmqta26OyzruJIrajHJ" +
                        "lproTBG9tiD4Qq7WHQmAjsrteOWW21loZpGn6+e5ovvXrLOC6S29yo7aqwyqtkpwZM6mBa6Ax9cnbsNM" +
                        "8ytt7s6jKLF2kEccbLRcpwuqvsmq3HIn2ZL5sYBT5zypSxXPJO/P/UKEcxe1tzVzXZii/PONurL888sf" +
                        "gn00DZbRzTPIx+Nc9JKd8V002XpDPXSi0691NNWv8Ukxlx37fXXYMcb9thkl012x2anrfbaSrLt9ttpo" +
                        "w333HRPm/XdeOet99589//tt0p1By64w3IPbnjghR+u+NuJL+543CY/LrnZQg9YKtRYY+Sx3plrvvndn" +
                        "ctHc9ahiz465lVbfvnOpcN6OtGtcySz1bHL/jnQtW96O+upO7cy7r2bNPvQuYM0/M/Fr2f761cH76Kgr" +
                        "v+OVemnLr864M4HqCdSzNsUuvYnVxw+YFJTSfJLu5Mvds4k+ymk9N47PxnKx4s/vvDyz994bPLCj335u" +
                        "6KfgX5Xv5XkrmAYI1HP7kee9WXpfP/yXwFLk79RoSxyocqWT5KnP0xFcHzpM14FR9M+ieXMfyIEIJyW9" +
                        "bWIhNB6PvNcvrjmwheazoE3SRAGKXZCBlqEg35R3gf/aRiz7r1MhTM71dmKeL0kIpGJflKbE5vYw8q9r" +
                        "241ROEVY/jDwU3Rh1UsGkvgBbc9bS+LOLQTGdd2KC1+0YqZ0aHKpNhGKg4MjsfJC60YV0cwBk2MvTFWD" +
                        "922xTP2DI/i0eOC9kjIPhryWYhUZFY6ZD+2FbJk3wLk87i4Rjqu8HpY49fJsPjJyzEtLtb6oiUdiUkr8" +
                        "mqGhqTbJVsJqiCBBWSMXGUpz9g5E0KxkbvUU+a2Zaodjm2WlBomLj84RE+a0VbBQ9W2vMjKX0VzPxZrJ" +
                        "hurebHsUU6b2wxmxrxZNmNCTpyifKIAE0gvUqLzlvn75uOQySx1lvBg4CwjPWu3/8R2Cm6f9vwY4fI5t" +
                        "y726n7HJKgsuZnGX7LTn4czKKdoac4fTW51mfIjRAd4UT9ONIOq5GhHwQjESg5qpBRtmUbRWFHF7SmS+" +
                        "EOpEUt6RJlyiKYStWn42oYYnbqxbbqCFA8N98ZU3rCD+4NlQaHYMdWxkIftvOdAuSc2N1K1qt1aZtiYi" +
                        "sEjRpCg61wS2LgKViF9daNi9WVCr/qlCQ7SKMSsaEuZ5y63WhCtIrMbXm1Yy6bWUKEZ0msLXwpIuwpUq" +
                        "4L1WikRaVinELGT4npoUVtGP1oBNoOJ7dpiNalBh/pyjtd67GSNFrIGXdazPlIsYSkL2jzuFaQ7vCwDW" +
                        "3c7vf+ilkiaXS1pIRvMd0ZRsmTd7QJTesOF5RaNnHwrcWtq0eMGl6RGRB82nRtG1oZ0uaoSpDbnCltXP" +
                        "rK0DYwcd3W7Un+mMCcSE+1Vk4tM0xErvdlUJUzf6VXZJrW74BJue6Nn29fi1zrlhSCc5hpWEObmu+t9Z" +
                        "MJANtXqxsg/TYyvVPELHAQrl8K/jWtSf8mo9KDwpJ/dH4fveB2rAjaXdO1TUGUoPRC7tb/wgmRMCZjhZ" +
                        "SZukDKmYIpDDNqSBRa7DC0kcj88Hjs+E8gMTSa7LMzcAA9ZUf37r+5MfOTTKYzJLDbyhEHaGifvl78a5" +
                        "pb4tBbdHmvxT0iWLhWBG2O23qX/zBt2MCPRAucb4zi4ZLYqVnfKZyw7lZcPS99NvQxmRQVRYCOWr9NGx" +
                        "6ygkPjOT76ZXXHy1CE7knfwQ6WjhcxKTEvw0LvM6YrV56AgSnnNhP4zlhod0ixL2YCvG3WqLgm8Ore5u" +
                        "K8mtZ8bBcNcw9rWJxKqr/9H5YadN806LrYChT1sYpdK2QmWNV1CCG3lKq2xWkZx0yYI7Otum2PdfrK0N" +
                        "4ircB8Zdf0xtzinhhd1V5Pd+CR3tXvK419nWzWGxXeqZ7xvNfe7gf/29659d2+AD/zYAVc1snudcIM3P" +
                        "NoLp7e7xR3xadt4ynyt9cWTXPFFx/u6G+fbRf92YX2SnOLnEzx5k8eqcgiHueUwj7nMZ06VgAAAOwsBg" +
                        "gstLSBpbml0IHZhcg0KREVDTEFSRSBAS2JXVkVpbnplbHBvc3RlbklEcyBWQVJDSEFSKE1BWCkNCkRFQ" +
                        "0xBUkUgQExhbmd1YWdlQ29kZSBJTlQNCkRFQ0xBUkUgQEhlYWRlckRhdHVtVm9uIERBVEVUSU1FDQpER" +
                        "UNMQVJFIEBIZWFkZXJEYXR1bUJpcyBEQVRFVElNRQ0KDQpTRVQgQEtiV1ZFaW56ZWxwb3N0ZW5JRHMgP" +
                        "SBudWxsDQpTRVQgQExhbmd1YWdlQ29kZSA9IG51bGwNClNFVCBASGVhZGVyRGF0dW1Wb24gPSBudWxsD" +
                        "QpTRVQgQEhlYWRlckRhdHVtQmlzID0gbnVsbA0KDQotLSBnZXQgZGF0YSB1c2luZyBkYiBmdW5jdGlvb" +
                        "g0KU0VMRUNUIEZDTi5JZCQsDQogICAgICAgRkNOLkZhTGVpc3R1bmdJRCwNCiAgICAgICBGQ04uQmFQZ" +
                        "XJzb25JRCwNCiAgICAgICBGQ04uS29zdGVuc3RlbGxlTnIsDQogICAgICAgSGVhZGVyX0RhdHVtVm9uI" +
                        "D0gSVNOVUxMKENPTlZFUlQoVkFSQ0hBUiwgQEhlYWRlckRhdHVtVm9uLCAxMDQpLCAnPycpLA0KICAgI" +
                        "CAgIEhlYWRlcl9EYXR1bUJpcyA9IElTTlVMTChDT05WRVJUKFZBUkNIQVIsIEBIZWFkZXJEYXR1bUJpc" +
                        "ywgMTA0KSwgJz8nKSwNCiAgICAgICBGQ04uSGVhZGVyX1BlcnNvbk5hbWUsDQogICAgICAgRkNOLkhlY" +
                        "WRlcl9QZXJzb25HZWJ1cnRzZGF0dW0sDQogICAgICAgRkNOLkhlYWRlcl9IZWltYXRnZW1laW5kZW4sD" +
                        "QogICAgICAgRkNOLkhlYWRlcl9LYW50b25lLA0KICAgICAgIEZDTi5IZWFkZXJfV29obm9ydCwNCiAgI" +
                        "CAgICBGQ04uSGVhZGVyX1dvaG5rYW50b25OciwNCiAgICAgICBGQ04uSGVhZGVyX0hlaW1hdGthbnRvb" +
                        "k5yLA0KICAgICAgIEZDTi5IZWFkZXJfQmVtZXJrdW5nLA0KICAgICAgIEZDTi5TdWJfQmV0cmFnMSwNC" +
                        "iAgICAgICBGQ04uU3ViX0JldHJhZzIsDQogICAgICAgRkNOLlN1Yl9CZXRyYWczLA0KICAgICAgIEZDT" +
                        "i5TdWJfQmV0cmFnNCwNCiAgICAgICBGQ04uU3ViX0JldHJhZzUsDQogICAgICAgRkNOLlN1Yl9CZXRyY" +
                        "Wc1YSwNCiAgICAgICBGQ04uU3ViX0JldHJhZzViLA0KICAgICAgIEZDTi5TdWJfQmV0cmFnNWMsDQogI" +
                        "CAgICAgRkNOLlN1Yl9CZXRyYWc2LA0KICAgICAgIEZDTi5TdWJfVG90YWxBdXNnYWJlbiwNCiAgICAgI" +
                        "CBGQ04uU3ViX0JldHJhZzgsDQogICAgICAgRkNOLlN1Yl9CZXRyYWc4YSwNCiAgICAgICBGQ04uU3ViX" +
                        "0JldHJhZzksDQogICAgICAgRkNOLlN1Yl9CZXRyYWcxMCwNCiAgICAgICBGQ04uU3ViX0JldHJhZzExL" +
                        "A0KICAgICAgIEZDTi5TdWJfVG90YWxFaW5uYWhtZW4sDQogICAgICAgRkNOLlN1Yl9CZXRyYWcxNCwNC" +
                        "iAgICAgICBGQ04uU3ViX0JldHJhZzE1VG90YWwNCkZST00gZGJvLmZuS2JHZXRXVlJlcG9ydERhdGEoQ" +
                        "EtiV1ZFaW56ZWxwb3N0ZW5JRHMsIEBMYW5ndWFnZUNvZGUpIEZDTg0KT1JERVIgQlkgRkNOLkhlYWRlc" +
                        "l9QZXJzb25OYW1lLCBGQ04uS29zdGVuc3RlbGxlTnI=";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.picLogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.tabAbzuege = new DevExpress.XtraReports.UI.XRTable();
            this.tabEinnahmen = new DevExpress.XtraReports.UI.XRTable();
            this.lblEinnahmen = new DevExpress.XtraReports.UI.XRLabel();
            this.tabAusgaben = new DevExpress.XtraReports.UI.XRTable();
            this.lblAusgaben = new DevExpress.XtraReports.UI.XRLabel();
            this.tabAnteilHeimatKanton = new DevExpress.XtraReports.UI.XRTable();
            this.lblAbzuege = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrTableRow26 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow27 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell73 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell74 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell75 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell76 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell77 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell78 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow20 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow21 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow22 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow23 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow24 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow25 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell55 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell56 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell57 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell58 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell59 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell60 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell61 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell62 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell63 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell64 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell65 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell67 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell68 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell69 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell70 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell71 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell72 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow12 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow13 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow14 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow15 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow16 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow17 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow18 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableRow19 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell53 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell54 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabAbzuege)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabEinnahmen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabAusgaben)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabAnteilHeimatKanton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLine2,
                        this.xrTable1,
                        this.xrLabel2,
                        this.xrLabel1,
                        this.picLogo,
                        this.xrTable2,
                        this.xrLine1,
                        this.tabAbzuege,
                        this.tabEinnahmen,
                        this.lblEinnahmen,
                        this.tabAusgaben,
                        this.lblAusgaben,
                        this.tabAnteilHeimatKanton,
                        this.lblAbzuege});
            this.Detail.Dpi = 254F;
            this.Detail.Height = 2619;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 254F;
            this.xrLine2.LineWidth = 3;
            this.xrLine2.Location = new System.Drawing.Point(0, 762);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.Size = new System.Drawing.Size(1592, 21);
            // 
            // xrTable1
            // 
            this.xrTable1.Dpi = 254F;
            this.xrTable1.Location = new System.Drawing.Point(0, 233);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow1,
                        this.xrTableRow2,
                        this.xrTableRow3,
                        this.xrTableRow4,
                        this.xrTableRow5,
                        this.xrTableRow6});
            this.xrTable1.Size = new System.Drawing.Size(1592, 510);
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.Location = new System.Drawing.Point(254, 42);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(1354, 41);
            this.xrLabel2.Text = "Bundesgesetz über die Zuständigkeit für die Unterstützung Bedürftiger";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.Location = new System.Drawing.Point(254, 0);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(254, 41);
            this.xrLabel1.Text = "Kanton Bern";
            // 
            // picLogo
            // 
            this.picLogo.Dpi = 254F;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(170, 170);
            this.picLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // xrTable2
            // 
            this.xrTable2.Dpi = 254F;
            this.xrTable2.Location = new System.Drawing.Point(0, 2413);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow7,
                        this.xrTableRow8});
            this.xrTable2.Size = new System.Drawing.Size(1592, 200);
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 254F;
            this.xrLine1.LineWidth = 3;
            this.xrLine1.Location = new System.Drawing.Point(0, 2392);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(1592, 21);
            // 
            // tabAbzuege
            // 
            this.tabAbzuege.Dpi = 254F;
            this.tabAbzuege.Location = new System.Drawing.Point(0, 2074);
            this.tabAbzuege.Name = "tabAbzuege";
            this.tabAbzuege.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow26,
                        this.xrTableRow27});
            this.tabAbzuege.Size = new System.Drawing.Size(1592, 120);
            // 
            // tabEinnahmen
            // 
            this.tabEinnahmen.Dpi = 254F;
            this.tabEinnahmen.Location = new System.Drawing.Point(0, 1588);
            this.tabEinnahmen.Name = "tabEinnahmen";
            this.tabEinnahmen.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow20,
                        this.xrTableRow21,
                        this.xrTableRow22,
                        this.xrTableRow23,
                        this.xrTableRow24,
                        this.xrTableRow25});
            this.tabEinnahmen.Size = new System.Drawing.Size(1592, 380);
            // 
            // lblEinnahmen
            // 
            this.lblEinnahmen.Dpi = 254F;
            this.lblEinnahmen.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEinnahmen.Location = new System.Drawing.Point(0, 1524);
            this.lblEinnahmen.Name = "lblEinnahmen";
            this.lblEinnahmen.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblEinnahmen.ParentStyleUsing.UseFont = false;
            this.lblEinnahmen.Size = new System.Drawing.Size(1588, 40);
            this.lblEinnahmen.Text = "Einnahmen";
            // 
            // tabAusgaben
            // 
            this.tabAusgaben.Dpi = 254F;
            this.tabAusgaben.Location = new System.Drawing.Point(0, 868);
            this.tabAusgaben.Name = "tabAusgaben";
            this.tabAusgaben.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow10,
                        this.xrTableRow11,
                        this.xrTableRow12,
                        this.xrTableRow13,
                        this.xrTableRow14,
                        this.xrTableRow15,
                        this.xrTableRow16,
                        this.xrTableRow17,
                        this.xrTableRow18,
                        this.xrTableRow19});
            this.tabAusgaben.Size = new System.Drawing.Size(1592, 620);
            // 
            // lblAusgaben
            // 
            this.lblAusgaben.Dpi = 254F;
            this.lblAusgaben.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAusgaben.Location = new System.Drawing.Point(0, 804);
            this.lblAusgaben.Name = "lblAusgaben";
            this.lblAusgaben.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblAusgaben.ParentStyleUsing.UseFont = false;
            this.lblAusgaben.Size = new System.Drawing.Size(1592, 40);
            this.lblAusgaben.Text = "Ausgaben";
            // 
            // tabAnteilHeimatKanton
            // 
            this.tabAnteilHeimatKanton.Dpi = 254F;
            this.tabAnteilHeimatKanton.Location = new System.Drawing.Point(0, 2244);
            this.tabAnteilHeimatKanton.Name = "tabAnteilHeimatKanton";
            this.tabAnteilHeimatKanton.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
                        this.xrTableRow9});
            this.tabAnteilHeimatKanton.Size = new System.Drawing.Size(1592, 60);
            // 
            // lblAbzuege
            // 
            this.lblAbzuege.Dpi = 254F;
            this.lblAbzuege.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbzuege.Location = new System.Drawing.Point(0, 2011);
            this.lblAbzuege.Name = "lblAbzuege";
            this.lblAbzuege.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblAbzuege.ParentStyleUsing.UseFont = false;
            this.lblAbzuege.Size = new System.Drawing.Size(1592, 40);
            this.lblAbzuege.Text = "Abzüge";
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell1,
                        this.xrTableCell2});
            this.xrTableRow1.Dpi = 254F;
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Size = new System.Drawing.Size(1592, 40);
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell3});
            this.xrTableRow2.Dpi = 254F;
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Size = new System.Drawing.Size(1592, 150);
            this.xrTableRow2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell4,
                        this.xrTableCell5,
                        this.xrTableCell6,
                        this.xrTableCell7});
            this.xrTableRow3.Dpi = 254F;
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Size = new System.Drawing.Size(1592, 80);
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell8,
                        this.xrTableCell9,
                        this.xrTableCell10,
                        this.xrTableCell11});
            this.xrTableRow4.Dpi = 254F;
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Size = new System.Drawing.Size(1592, 80);
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell12,
                        this.xrTableCell13});
            this.xrTableRow5.Dpi = 254F;
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Size = new System.Drawing.Size(1592, 80);
            // 
            // xrTableRow6
            // 
            this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell16,
                        this.xrTableCell17,
                        this.xrTableCell18,
                        this.xrTableCell19});
            this.xrTableRow6.Dpi = 254F;
            this.xrTableRow6.Name = "xrTableRow6";
            this.xrTableRow6.Size = new System.Drawing.Size(1592, 80);
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Dpi = 254F;
            this.xrTableCell1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell1.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell1.ParentStyleUsing.UseFont = false;
            this.xrTableCell1.Size = new System.Drawing.Size(234, 40);
            this.xrTableCell1.Text = "Rechnung";
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Dpi = 254F;
            this.xrTableCell2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell2.Location = new System.Drawing.Point(234, 0);
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell2.ParentStyleUsing.UseFont = false;
            this.xrTableCell2.Size = new System.Drawing.Size(1358, 40);
            this.xrTableCell2.Text = "für den Zeitraum von [Header_DatumVon!dd.MM.yyyy] bis [Header_DatumBis!dd.MM.yyyy" +
                "]";
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Dpi = 254F;
            this.xrTableCell3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell3.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell3.ParentStyleUsing.UseFont = false;
            this.xrTableCell3.Size = new System.Drawing.Size(1592, 150);
            this.xrTableCell3.Text = "\r\nan die Direktion des Fürsorgewesens des Kantons Bern\r\nzuhanden der Heimatbehörd" +
                "e betreffend:\r\n";
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Dpi = 254F;
            this.xrTableCell4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell4.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell4.ParentStyleUsing.UseFont = false;
            this.xrTableCell4.Size = new System.Drawing.Size(466, 80);
            this.xrTableCell4.Text = "Name des Unterstützten.";
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Header_PersonName", "")});
            this.xrTableCell5.Dpi = 254F;
            this.xrTableCell5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell5.Location = new System.Drawing.Point(466, 0);
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell5.ParentStyleUsing.UseFont = false;
            this.xrTableCell5.Size = new System.Drawing.Size(595, 80);
            this.xrTableCell5.Text = "xrTableCell5";
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Dpi = 254F;
            this.xrTableCell6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell6.Location = new System.Drawing.Point(1061, 0);
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell6.ParentStyleUsing.UseFont = false;
            this.xrTableCell6.Size = new System.Drawing.Size(265, 80);
            this.xrTableCell6.Text = "Geburtsdatum:";
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Header_PersonGeburtsdatum", "{0:dd.MM.yyyy}")});
            this.xrTableCell7.Dpi = 254F;
            this.xrTableCell7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell7.Location = new System.Drawing.Point(1326, 0);
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell7.ParentStyleUsing.UseFont = false;
            this.xrTableCell7.Size = new System.Drawing.Size(266, 80);
            this.xrTableCell7.Text = "xrTableCell7";
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Dpi = 254F;
            this.xrTableCell8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell8.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell8.ParentStyleUsing.UseFont = false;
            this.xrTableCell8.Size = new System.Drawing.Size(466, 80);
            this.xrTableCell8.Text = "Heimatgemeinde(n):";
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Header_Heimatgemeinden", "")});
            this.xrTableCell9.Dpi = 254F;
            this.xrTableCell9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell9.Location = new System.Drawing.Point(466, 0);
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell9.ParentStyleUsing.UseFont = false;
            this.xrTableCell9.Size = new System.Drawing.Size(596, 80);
            this.xrTableCell9.Text = "xrTableCell9";
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Dpi = 254F;
            this.xrTableCell10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell10.Location = new System.Drawing.Point(1062, 0);
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell10.ParentStyleUsing.UseFont = false;
            this.xrTableCell10.Size = new System.Drawing.Size(264, 80);
            this.xrTableCell10.Text = "Kanton(e):";
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Header_Kantone", "")});
            this.xrTableCell11.Dpi = 254F;
            this.xrTableCell11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell11.Location = new System.Drawing.Point(1326, 0);
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell11.ParentStyleUsing.UseFont = false;
            this.xrTableCell11.Size = new System.Drawing.Size(266, 80);
            this.xrTableCell11.Text = "xrTableCell11";
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Dpi = 254F;
            this.xrTableCell12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell12.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell12.ParentStyleUsing.UseFont = false;
            this.xrTableCell12.Size = new System.Drawing.Size(466, 80);
            this.xrTableCell12.Text = "Wohnort:";
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Header_Wohnort", "")});
            this.xrTableCell13.Dpi = 254F;
            this.xrTableCell13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell13.Location = new System.Drawing.Point(466, 0);
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell13.ParentStyleUsing.UseFont = false;
            this.xrTableCell13.Size = new System.Drawing.Size(1126, 80);
            this.xrTableCell13.Text = "xrTableCell13";
            // 
            // xrTableCell16
            // 
            this.xrTableCell16.Dpi = 254F;
            this.xrTableCell16.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell16.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell16.Name = "xrTableCell16";
            this.xrTableCell16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell16.ParentStyleUsing.UseFont = false;
            this.xrTableCell16.Size = new System.Drawing.Size(466, 80);
            this.xrTableCell16.Text = "Nummer des Wohnkantons:";
            // 
            // xrTableCell17
            // 
            this.xrTableCell17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Header_WohnkantonNr", "")});
            this.xrTableCell17.Dpi = 254F;
            this.xrTableCell17.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell17.Location = new System.Drawing.Point(466, 0);
            this.xrTableCell17.Name = "xrTableCell17";
            this.xrTableCell17.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell17.ParentStyleUsing.UseFont = false;
            this.xrTableCell17.Size = new System.Drawing.Size(596, 80);
            this.xrTableCell17.Text = "xrTableCell17";
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Dpi = 254F;
            this.xrTableCell18.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell18.Location = new System.Drawing.Point(1062, 0);
            this.xrTableCell18.Multiline = true;
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell18.ParentStyleUsing.UseFont = false;
            this.xrTableCell18.Size = new System.Drawing.Size(264, 80);
            this.xrTableCell18.Text = "Nummer des\r\nHeimatkantons:";
            // 
            // xrTableCell19
            // 
            this.xrTableCell19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Header_HeimatkantonNr", "")});
            this.xrTableCell19.Dpi = 254F;
            this.xrTableCell19.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell19.Location = new System.Drawing.Point(1326, 0);
            this.xrTableCell19.Name = "xrTableCell19";
            this.xrTableCell19.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell19.ParentStyleUsing.UseFont = false;
            this.xrTableCell19.Size = new System.Drawing.Size(266, 80);
            this.xrTableCell19.Text = "xrTableCell19";
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell14});
            this.xrTableRow7.Dpi = 254F;
            this.xrTableRow7.Name = "xrTableRow7";
            this.xrTableRow7.Size = new System.Drawing.Size(1592, 120);
            // 
            // xrTableRow8
            // 
            this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell20,
                        this.xrTableCell21});
            this.xrTableRow8.Dpi = 254F;
            this.xrTableRow8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableRow8.Name = "xrTableRow8";
            this.xrTableRow8.ParentStyleUsing.UseFont = false;
            this.xrTableRow8.Size = new System.Drawing.Size(1592, 80);
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.Dpi = 254F;
            this.xrTableCell14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell14.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell14.Multiline = true;
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell14.ParentStyleUsing.UseFont = false;
            this.xrTableCell14.Size = new System.Drawing.Size(1592, 120);
            this.xrTableCell14.Text = "Bemerkung: [Header_Bemerkung]";
            // 
            // xrTableCell20
            // 
            this.xrTableCell20.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageInfo1});
            this.xrTableCell20.Dpi = 254F;
            this.xrTableCell20.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell20.Name = "xrTableCell20";
            this.xrTableCell20.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell20.Size = new System.Drawing.Size(1062, 80);
            this.xrTableCell20.Text = "xrTableCell20";
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Dpi = 254F;
            this.xrTableCell21.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell21.Location = new System.Drawing.Point(1062, 0);
            this.xrTableCell21.Multiline = true;
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell21.ParentStyleUsing.UseFont = false;
            this.xrTableCell21.Size = new System.Drawing.Size(530, 80);
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 254F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.Format = "Wohlen, {0:dd.MM.yyyy}";
            this.xrPageInfo1.Location = new System.Drawing.Point(0, 0);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(1062, 80);
            // 
            // xrTableRow26
            // 
            this.xrTableRow26.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell73,
                        this.xrTableCell74,
                        this.xrTableCell75});
            this.xrTableRow26.Dpi = 254F;
            this.xrTableRow26.Name = "xrTableRow26";
            this.xrTableRow26.Size = new System.Drawing.Size(1592, 60);
            // 
            // xrTableRow27
            // 
            this.xrTableRow27.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell76,
                        this.xrTableCell77,
                        this.xrTableCell78});
            this.xrTableRow27.Dpi = 254F;
            this.xrTableRow27.Name = "xrTableRow27";
            this.xrTableRow27.Size = new System.Drawing.Size(1592, 60);
            // 
            // xrTableCell73
            // 
            this.xrTableCell73.Dpi = 254F;
            this.xrTableCell73.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell73.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell73.Name = "xrTableCell73";
            this.xrTableCell73.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell73.ParentStyleUsing.UseFont = false;
            this.xrTableCell73.Size = new System.Drawing.Size(1291, 60);
            this.xrTableCell73.Text = "14. Pflichtleistungen";
            this.xrTableCell73.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell74
            // 
            this.xrTableCell74.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell74.Dpi = 254F;
            this.xrTableCell74.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell74.Location = new System.Drawing.Point(1291, 0);
            this.xrTableCell74.Name = "xrTableCell74";
            this.xrTableCell74.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell74.ParentStyleUsing.UseBorders = false;
            this.xrTableCell74.ParentStyleUsing.UseFont = false;
            this.xrTableCell74.Size = new System.Drawing.Size(72, 60);
            this.xrTableCell74.Text = "SFr.";
            this.xrTableCell74.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell75
            // 
            this.xrTableCell75.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell75.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Sub_Betrag14", "{0:n2}")});
            this.xrTableCell75.Dpi = 254F;
            this.xrTableCell75.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell75.Location = new System.Drawing.Point(1363, 0);
            this.xrTableCell75.Name = "xrTableCell75";
            this.xrTableCell75.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell75.ParentStyleUsing.UseBorders = false;
            this.xrTableCell75.ParentStyleUsing.UseFont = false;
            this.xrTableCell75.Size = new System.Drawing.Size(229, 60);
            this.xrTableCell75.Text = "xrTableCell75";
            this.xrTableCell75.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCell76
            // 
            this.xrTableCell76.Dpi = 254F;
            this.xrTableCell76.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell76.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell76.Name = "xrTableCell76";
            this.xrTableCell76.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell76.ParentStyleUsing.UseFont = false;
            this.xrTableCell76.Size = new System.Drawing.Size(1289, 60);
            this.xrTableCell76.Text = "15. Zu verrechnende Ausgaben";
            this.xrTableCell76.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell77
            // 
            this.xrTableCell77.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell77.Dpi = 254F;
            this.xrTableCell77.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell77.Location = new System.Drawing.Point(1289, 0);
            this.xrTableCell77.Multiline = true;
            this.xrTableCell77.Name = "xrTableCell77";
            this.xrTableCell77.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell77.ParentStyleUsing.UseBorders = false;
            this.xrTableCell77.ParentStyleUsing.UseFont = false;
            this.xrTableCell77.Size = new System.Drawing.Size(71, 60);
            this.xrTableCell77.Text = "SFr.";
            this.xrTableCell77.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell78
            // 
            this.xrTableCell78.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell78.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Sub_Betrag15Total", "{0:n2}")});
            this.xrTableCell78.Dpi = 254F;
            this.xrTableCell78.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell78.Location = new System.Drawing.Point(1360, 0);
            this.xrTableCell78.Name = "xrTableCell78";
            this.xrTableCell78.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell78.ParentStyleUsing.UseBorders = false;
            this.xrTableCell78.ParentStyleUsing.UseFont = false;
            this.xrTableCell78.Size = new System.Drawing.Size(232, 60);
            this.xrTableCell78.Text = "xrTableCell78";
            this.xrTableCell78.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableRow20
            // 
            this.xrTableRow20.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell55,
                        this.xrTableCell56,
                        this.xrTableCell57});
            this.xrTableRow20.Dpi = 254F;
            this.xrTableRow20.Name = "xrTableRow20";
            this.xrTableRow20.Size = new System.Drawing.Size(1592, 60);
            // 
            // xrTableRow21
            // 
            this.xrTableRow21.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell58,
                        this.xrTableCell59,
                        this.xrTableCell60});
            this.xrTableRow21.Dpi = 254F;
            this.xrTableRow21.Name = "xrTableRow21";
            this.xrTableRow21.Size = new System.Drawing.Size(1592, 60);
            // 
            // xrTableRow22
            // 
            this.xrTableRow22.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell61,
                        this.xrTableCell62,
                        this.xrTableCell63});
            this.xrTableRow22.Dpi = 254F;
            this.xrTableRow22.Name = "xrTableRow22";
            this.xrTableRow22.Size = new System.Drawing.Size(1592, 60);
            // 
            // xrTableRow23
            // 
            this.xrTableRow23.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell64,
                        this.xrTableCell65,
                        this.xrTableCell66});
            this.xrTableRow23.Dpi = 254F;
            this.xrTableRow23.Name = "xrTableRow23";
            this.xrTableRow23.Size = new System.Drawing.Size(1592, 60);
            // 
            // xrTableRow24
            // 
            this.xrTableRow24.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell67,
                        this.xrTableCell68,
                        this.xrTableCell69});
            this.xrTableRow24.Dpi = 254F;
            this.xrTableRow24.Name = "xrTableRow24";
            this.xrTableRow24.Size = new System.Drawing.Size(1592, 60);
            // 
            // xrTableRow25
            // 
            this.xrTableRow25.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell70,
                        this.xrTableCell71,
                        this.xrTableCell72});
            this.xrTableRow25.Dpi = 254F;
            this.xrTableRow25.Name = "xrTableRow25";
            this.xrTableRow25.Size = new System.Drawing.Size(1592, 80);
            // 
            // xrTableCell55
            // 
            this.xrTableCell55.Dpi = 254F;
            this.xrTableCell55.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell55.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell55.Name = "xrTableCell55";
            this.xrTableCell55.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell55.ParentStyleUsing.UseFont = false;
            this.xrTableCell55.Size = new System.Drawing.Size(1291, 60);
            this.xrTableCell55.Text = "8. Versicherungsleistungen von AHV/IV/EO/Krankenassen UVG";
            this.xrTableCell55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell56
            // 
            this.xrTableCell56.Dpi = 254F;
            this.xrTableCell56.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell56.Location = new System.Drawing.Point(1291, 0);
            this.xrTableCell56.Name = "xrTableCell56";
            this.xrTableCell56.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell56.ParentStyleUsing.UseFont = false;
            this.xrTableCell56.Size = new System.Drawing.Size(72, 60);
            this.xrTableCell56.Text = "SFr.";
            this.xrTableCell56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell57
            // 
            this.xrTableCell57.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Sub_Betrag8", "{0:n2}")});
            this.xrTableCell57.Dpi = 254F;
            this.xrTableCell57.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell57.Location = new System.Drawing.Point(1363, 0);
            this.xrTableCell57.Name = "xrTableCell57";
            this.xrTableCell57.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell57.ParentStyleUsing.UseFont = false;
            this.xrTableCell57.Size = new System.Drawing.Size(229, 60);
            this.xrTableCell57.Text = "xrTableCell57";
            this.xrTableCell57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCell58
            // 
            this.xrTableCell58.Dpi = 254F;
            this.xrTableCell58.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell58.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell58.Name = "xrTableCell58";
            this.xrTableCell58.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell58.ParentStyleUsing.UseFont = false;
            this.xrTableCell58.Size = new System.Drawing.Size(1289, 60);
            this.xrTableCell58.Text = "    Versicherungsleistungen von Krankenkassen";
            this.xrTableCell58.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell59
            // 
            this.xrTableCell59.Dpi = 254F;
            this.xrTableCell59.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell59.Location = new System.Drawing.Point(1289, 0);
            this.xrTableCell59.Multiline = true;
            this.xrTableCell59.Name = "xrTableCell59";
            this.xrTableCell59.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell59.ParentStyleUsing.UseFont = false;
            this.xrTableCell59.Size = new System.Drawing.Size(71, 60);
            this.xrTableCell59.Text = "SFr.";
            this.xrTableCell59.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell60
            // 
            this.xrTableCell60.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Sub_Betrag8a", "{0:n2}")});
            this.xrTableCell60.Dpi = 254F;
            this.xrTableCell60.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell60.Location = new System.Drawing.Point(1360, 0);
            this.xrTableCell60.Name = "xrTableCell60";
            this.xrTableCell60.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell60.ParentStyleUsing.UseFont = false;
            this.xrTableCell60.Size = new System.Drawing.Size(232, 60);
            this.xrTableCell60.Text = "xrTableCell60";
            this.xrTableCell60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCell61
            // 
            this.xrTableCell61.Dpi = 254F;
            this.xrTableCell61.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell61.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell61.Name = "xrTableCell61";
            this.xrTableCell61.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell61.ParentStyleUsing.UseFont = false;
            this.xrTableCell61.Size = new System.Drawing.Size(1289, 60);
            this.xrTableCell61.Text = "9. Verwandtenbeiträge";
            this.xrTableCell61.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell62
            // 
            this.xrTableCell62.Dpi = 254F;
            this.xrTableCell62.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell62.Location = new System.Drawing.Point(1289, 0);
            this.xrTableCell62.Name = "xrTableCell62";
            this.xrTableCell62.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell62.ParentStyleUsing.UseFont = false;
            this.xrTableCell62.Size = new System.Drawing.Size(71, 60);
            this.xrTableCell62.Text = "SFr.";
            this.xrTableCell62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell63
            // 
            this.xrTableCell63.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Sub_Betrag9", "{0:n2}")});
            this.xrTableCell63.Dpi = 254F;
            this.xrTableCell63.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell63.Location = new System.Drawing.Point(1360, 0);
            this.xrTableCell63.Name = "xrTableCell63";
            this.xrTableCell63.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell63.ParentStyleUsing.UseFont = false;
            this.xrTableCell63.Size = new System.Drawing.Size(232, 60);
            this.xrTableCell63.Text = "xrTableCell63";
            this.xrTableCell63.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCell64
            // 
            this.xrTableCell64.Dpi = 254F;
            this.xrTableCell64.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell64.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell64.Name = "xrTableCell64";
            this.xrTableCell64.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell64.ParentStyleUsing.UseFont = false;
            this.xrTableCell64.Size = new System.Drawing.Size(1289, 60);
            this.xrTableCell64.Text = "10. Rückerstattungen";
            this.xrTableCell64.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell65
            // 
            this.xrTableCell65.Dpi = 254F;
            this.xrTableCell65.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell65.Location = new System.Drawing.Point(1289, 0);
            this.xrTableCell65.Name = "xrTableCell65";
            this.xrTableCell65.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell65.ParentStyleUsing.UseFont = false;
            this.xrTableCell65.Size = new System.Drawing.Size(71, 60);
            this.xrTableCell65.Text = "SFr.";
            this.xrTableCell65.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell66
            // 
            this.xrTableCell66.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Sub_Betrag10", "{0:n2}")});
            this.xrTableCell66.Dpi = 254F;
            this.xrTableCell66.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell66.Location = new System.Drawing.Point(1360, 0);
            this.xrTableCell66.Name = "xrTableCell66";
            this.xrTableCell66.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell66.ParentStyleUsing.UseFont = false;
            this.xrTableCell66.Size = new System.Drawing.Size(232, 60);
            this.xrTableCell66.Text = "xrTableCell66";
            this.xrTableCell66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCell67
            // 
            this.xrTableCell67.Dpi = 254F;
            this.xrTableCell67.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell67.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell67.Name = "xrTableCell67";
            this.xrTableCell67.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell67.ParentStyleUsing.UseFont = false;
            this.xrTableCell67.Size = new System.Drawing.Size(1289, 60);
            this.xrTableCell67.Text = "11. Bundes- und andere Beiträge";
            this.xrTableCell67.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell68
            // 
            this.xrTableCell68.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell68.Dpi = 254F;
            this.xrTableCell68.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell68.Location = new System.Drawing.Point(1289, 0);
            this.xrTableCell68.Name = "xrTableCell68";
            this.xrTableCell68.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell68.ParentStyleUsing.UseBorders = false;
            this.xrTableCell68.ParentStyleUsing.UseFont = false;
            this.xrTableCell68.Size = new System.Drawing.Size(71, 60);
            this.xrTableCell68.Text = "SFr.";
            this.xrTableCell68.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell69
            // 
            this.xrTableCell69.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell69.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Sub_Betrag11", "{0:n2}")});
            this.xrTableCell69.Dpi = 254F;
            this.xrTableCell69.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell69.Location = new System.Drawing.Point(1360, 0);
            this.xrTableCell69.Name = "xrTableCell69";
            this.xrTableCell69.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell69.ParentStyleUsing.UseBorders = false;
            this.xrTableCell69.ParentStyleUsing.UseFont = false;
            this.xrTableCell69.Size = new System.Drawing.Size(232, 60);
            this.xrTableCell69.Text = "xrTableCell69";
            this.xrTableCell69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCell70
            // 
            this.xrTableCell70.Dpi = 254F;
            this.xrTableCell70.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell70.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell70.Name = "xrTableCell70";
            this.xrTableCell70.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell70.ParentStyleUsing.UseFont = false;
            this.xrTableCell70.Size = new System.Drawing.Size(1289, 80);
            this.xrTableCell70.Text = "Total    Einnahmen";
            this.xrTableCell70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell71
            // 
            this.xrTableCell71.Dpi = 254F;
            this.xrTableCell71.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell71.Location = new System.Drawing.Point(1289, 0);
            this.xrTableCell71.Name = "xrTableCell71";
            this.xrTableCell71.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell71.ParentStyleUsing.UseFont = false;
            this.xrTableCell71.Size = new System.Drawing.Size(71, 80);
            this.xrTableCell71.Text = "SFr.";
            this.xrTableCell71.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell72
            // 
            this.xrTableCell72.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Sub_TotalEinnahmen", "{0:n2}")});
            this.xrTableCell72.Dpi = 254F;
            this.xrTableCell72.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell72.Location = new System.Drawing.Point(1360, 0);
            this.xrTableCell72.Name = "xrTableCell72";
            this.xrTableCell72.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell72.ParentStyleUsing.UseFont = false;
            this.xrTableCell72.Size = new System.Drawing.Size(232, 80);
            this.xrTableCell72.Text = "xrTableCell72";
            this.xrTableCell72.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableRow10
            // 
            this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell25,
                        this.xrTableCell26,
                        this.xrTableCell27});
            this.xrTableRow10.Dpi = 254F;
            this.xrTableRow10.Name = "xrTableRow10";
            this.xrTableRow10.Size = new System.Drawing.Size(1592, 60);
            // 
            // xrTableRow11
            // 
            this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell28,
                        this.xrTableCell29,
                        this.xrTableCell30});
            this.xrTableRow11.Dpi = 254F;
            this.xrTableRow11.Name = "xrTableRow11";
            this.xrTableRow11.Size = new System.Drawing.Size(1592, 60);
            // 
            // xrTableRow12
            // 
            this.xrTableRow12.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell31,
                        this.xrTableCell32,
                        this.xrTableCell33});
            this.xrTableRow12.Dpi = 254F;
            this.xrTableRow12.Name = "xrTableRow12";
            this.xrTableRow12.Size = new System.Drawing.Size(1592, 60);
            // 
            // xrTableRow13
            // 
            this.xrTableRow13.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell34,
                        this.xrTableCell35,
                        this.xrTableCell36});
            this.xrTableRow13.Dpi = 254F;
            this.xrTableRow13.Name = "xrTableRow13";
            this.xrTableRow13.Size = new System.Drawing.Size(1592, 60);
            // 
            // xrTableRow14
            // 
            this.xrTableRow14.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell37,
                        this.xrTableCell38,
                        this.xrTableCell39});
            this.xrTableRow14.Dpi = 254F;
            this.xrTableRow14.Name = "xrTableRow14";
            this.xrTableRow14.Size = new System.Drawing.Size(1592, 60);
            // 
            // xrTableRow15
            // 
            this.xrTableRow15.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell40,
                        this.xrTableCell41,
                        this.xrTableCell42});
            this.xrTableRow15.Dpi = 254F;
            this.xrTableRow15.Name = "xrTableRow15";
            this.xrTableRow15.Size = new System.Drawing.Size(1592, 60);
            // 
            // xrTableRow16
            // 
            this.xrTableRow16.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell43,
                        this.xrTableCell44,
                        this.xrTableCell45});
            this.xrTableRow16.Dpi = 254F;
            this.xrTableRow16.Name = "xrTableRow16";
            this.xrTableRow16.Size = new System.Drawing.Size(1592, 60);
            // 
            // xrTableRow17
            // 
            this.xrTableRow17.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell46,
                        this.xrTableCell47,
                        this.xrTableCell48});
            this.xrTableRow17.Dpi = 254F;
            this.xrTableRow17.Name = "xrTableRow17";
            this.xrTableRow17.Size = new System.Drawing.Size(1592, 60);
            // 
            // xrTableRow18
            // 
            this.xrTableRow18.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell49,
                        this.xrTableCell50,
                        this.xrTableCell51});
            this.xrTableRow18.Dpi = 254F;
            this.xrTableRow18.Name = "xrTableRow18";
            this.xrTableRow18.Size = new System.Drawing.Size(1592, 60);
            // 
            // xrTableRow19
            // 
            this.xrTableRow19.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell52,
                        this.xrTableCell53,
                        this.xrTableCell54});
            this.xrTableRow19.Dpi = 254F;
            this.xrTableRow19.Name = "xrTableRow19";
            this.xrTableRow19.Size = new System.Drawing.Size(1592, 80);
            // 
            // xrTableCell25
            // 
            this.xrTableCell25.Dpi = 254F;
            this.xrTableCell25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell25.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell25.Name = "xrTableCell25";
            this.xrTableCell25.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell25.ParentStyleUsing.UseFont = false;
            this.xrTableCell25.Size = new System.Drawing.Size(1291, 60);
            this.xrTableCell25.Text = "1. Lebensunterhalt (Bar- und Naturalunterstützungen)";
            this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell26
            // 
            this.xrTableCell26.Dpi = 254F;
            this.xrTableCell26.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell26.Location = new System.Drawing.Point(1291, 0);
            this.xrTableCell26.Name = "xrTableCell26";
            this.xrTableCell26.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell26.ParentStyleUsing.UseFont = false;
            this.xrTableCell26.Size = new System.Drawing.Size(72, 60);
            this.xrTableCell26.Text = "SFr.";
            this.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Sub_Betrag1", "{0:n2}")});
            this.xrTableCell27.Dpi = 254F;
            this.xrTableCell27.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell27.Location = new System.Drawing.Point(1363, 0);
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell27.ParentStyleUsing.UseFont = false;
            this.xrTableCell27.Size = new System.Drawing.Size(229, 60);
            this.xrTableCell27.Text = "xrTableCell27";
            this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCell28
            // 
            this.xrTableCell28.Dpi = 254F;
            this.xrTableCell28.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell28.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell28.Name = "xrTableCell28";
            this.xrTableCell28.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell28.ParentStyleUsing.UseFont = false;
            this.xrTableCell28.Size = new System.Drawing.Size(1289, 60);
            this.xrTableCell28.Text = "2. Wohnung (Miete, Heizung, Hypothekarzinsen, Liegenschaftsunterhalt)";
            this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell29
            // 
            this.xrTableCell29.Dpi = 254F;
            this.xrTableCell29.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell29.Location = new System.Drawing.Point(1289, 0);
            this.xrTableCell29.Multiline = true;
            this.xrTableCell29.Name = "xrTableCell29";
            this.xrTableCell29.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell29.ParentStyleUsing.UseFont = false;
            this.xrTableCell29.Size = new System.Drawing.Size(71, 60);
            this.xrTableCell29.Text = "SFr.";
            this.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell30
            // 
            this.xrTableCell30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Sub_Betrag2", "{0:n2}")});
            this.xrTableCell30.Dpi = 254F;
            this.xrTableCell30.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell30.Location = new System.Drawing.Point(1360, 0);
            this.xrTableCell30.Name = "xrTableCell30";
            this.xrTableCell30.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell30.ParentStyleUsing.UseFont = false;
            this.xrTableCell30.Size = new System.Drawing.Size(232, 60);
            this.xrTableCell30.Text = "xrTableCell30";
            this.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Dpi = 254F;
            this.xrTableCell31.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell31.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell31.ParentStyleUsing.UseFont = false;
            this.xrTableCell31.Size = new System.Drawing.Size(1289, 60);
            this.xrTableCell31.Text = "3. Ärztliche und zahnärtzliche Behandlung, Arzneien und Selbstbehalte aus Versich" +
                "erungen";
            this.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.Dpi = 254F;
            this.xrTableCell32.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell32.Location = new System.Drawing.Point(1289, 0);
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell32.ParentStyleUsing.UseFont = false;
            this.xrTableCell32.Size = new System.Drawing.Size(71, 60);
            this.xrTableCell32.Text = "SFr.";
            this.xrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell33
            // 
            this.xrTableCell33.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Sub_Betrag3", "{0:n2}")});
            this.xrTableCell33.Dpi = 254F;
            this.xrTableCell33.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell33.Location = new System.Drawing.Point(1360, 0);
            this.xrTableCell33.Name = "xrTableCell33";
            this.xrTableCell33.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell33.ParentStyleUsing.UseFont = false;
            this.xrTableCell33.Size = new System.Drawing.Size(232, 60);
            this.xrTableCell33.Text = "xrTableCell33";
            this.xrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCell34
            // 
            this.xrTableCell34.Dpi = 254F;
            this.xrTableCell34.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell34.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell34.Name = "xrTableCell34";
            this.xrTableCell34.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell34.ParentStyleUsing.UseFont = false;
            this.xrTableCell34.Size = new System.Drawing.Size(1289, 60);
            this.xrTableCell34.Text = "4. Anschaffungen";
            this.xrTableCell34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell35
            // 
            this.xrTableCell35.Dpi = 254F;
            this.xrTableCell35.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell35.Location = new System.Drawing.Point(1289, 0);
            this.xrTableCell35.Name = "xrTableCell35";
            this.xrTableCell35.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell35.ParentStyleUsing.UseFont = false;
            this.xrTableCell35.Size = new System.Drawing.Size(71, 60);
            this.xrTableCell35.Text = "SFr.";
            this.xrTableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell36
            // 
            this.xrTableCell36.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Sub_Betrag4", "{0:n2}")});
            this.xrTableCell36.Dpi = 254F;
            this.xrTableCell36.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell36.Location = new System.Drawing.Point(1360, 0);
            this.xrTableCell36.Name = "xrTableCell36";
            this.xrTableCell36.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell36.ParentStyleUsing.UseFont = false;
            this.xrTableCell36.Size = new System.Drawing.Size(232, 60);
            this.xrTableCell36.Text = "xrTableCell36";
            this.xrTableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCell37
            // 
            this.xrTableCell37.Dpi = 254F;
            this.xrTableCell37.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell37.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell37.Name = "xrTableCell37";
            this.xrTableCell37.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell37.ParentStyleUsing.UseFont = false;
            this.xrTableCell37.Size = new System.Drawing.Size(1289, 60);
            this.xrTableCell37.Text = "5. Spital-, Kur- und andere Versorgungskosten   Anstalt:";
            this.xrTableCell37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell38
            // 
            this.xrTableCell38.Dpi = 254F;
            this.xrTableCell38.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell38.Location = new System.Drawing.Point(1289, 0);
            this.xrTableCell38.Name = "xrTableCell38";
            this.xrTableCell38.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell38.ParentStyleUsing.UseFont = false;
            this.xrTableCell38.Size = new System.Drawing.Size(71, 60);
            this.xrTableCell38.Text = "SFr.";
            this.xrTableCell38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell39
            // 
            this.xrTableCell39.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Sub_Betrag5", "{0:n2}")});
            this.xrTableCell39.Dpi = 254F;
            this.xrTableCell39.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell39.Location = new System.Drawing.Point(1360, 0);
            this.xrTableCell39.Name = "xrTableCell39";
            this.xrTableCell39.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell39.ParentStyleUsing.UseFont = false;
            this.xrTableCell39.Size = new System.Drawing.Size(232, 60);
            this.xrTableCell39.Text = "xrTableCell39";
            this.xrTableCell39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCell40
            // 
            this.xrTableCell40.Dpi = 254F;
            this.xrTableCell40.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell40.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell40.Name = "xrTableCell40";
            this.xrTableCell40.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell40.ParentStyleUsing.UseFont = false;
            this.xrTableCell40.Size = new System.Drawing.Size(1289, 60);
            this.xrTableCell40.Text = "   a) Kostgelder";
            this.xrTableCell40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell41
            // 
            this.xrTableCell41.Dpi = 254F;
            this.xrTableCell41.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell41.Location = new System.Drawing.Point(1289, 0);
            this.xrTableCell41.Name = "xrTableCell41";
            this.xrTableCell41.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell41.ParentStyleUsing.UseFont = false;
            this.xrTableCell41.Size = new System.Drawing.Size(71, 60);
            this.xrTableCell41.Text = "SFr.";
            this.xrTableCell41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell42
            // 
            this.xrTableCell42.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Sub_Betrag5a", "{0:n2}")});
            this.xrTableCell42.Dpi = 254F;
            this.xrTableCell42.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell42.Location = new System.Drawing.Point(1360, 0);
            this.xrTableCell42.Name = "xrTableCell42";
            this.xrTableCell42.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell42.ParentStyleUsing.UseFont = false;
            this.xrTableCell42.Size = new System.Drawing.Size(232, 60);
            this.xrTableCell42.Text = "xrTableCell42";
            this.xrTableCell42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCell43
            // 
            this.xrTableCell43.Dpi = 254F;
            this.xrTableCell43.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell43.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell43.Name = "xrTableCell43";
            this.xrTableCell43.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell43.ParentStyleUsing.UseFont = false;
            this.xrTableCell43.Size = new System.Drawing.Size(1289, 60);
            this.xrTableCell43.Text = "   b) Taschengelder";
            this.xrTableCell43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell44
            // 
            this.xrTableCell44.Dpi = 254F;
            this.xrTableCell44.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell44.Location = new System.Drawing.Point(1289, 0);
            this.xrTableCell44.Name = "xrTableCell44";
            this.xrTableCell44.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell44.ParentStyleUsing.UseFont = false;
            this.xrTableCell44.Size = new System.Drawing.Size(71, 60);
            this.xrTableCell44.Text = "SFr.";
            this.xrTableCell44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell45
            // 
            this.xrTableCell45.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Sub_Betrag5b", "{0:n2}")});
            this.xrTableCell45.Dpi = 254F;
            this.xrTableCell45.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell45.Location = new System.Drawing.Point(1360, 0);
            this.xrTableCell45.Name = "xrTableCell45";
            this.xrTableCell45.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell45.ParentStyleUsing.UseFont = false;
            this.xrTableCell45.Size = new System.Drawing.Size(232, 60);
            this.xrTableCell45.Text = "xrTableCell45";
            this.xrTableCell45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCell46
            // 
            this.xrTableCell46.Dpi = 254F;
            this.xrTableCell46.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell46.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell46.Name = "xrTableCell46";
            this.xrTableCell46.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell46.ParentStyleUsing.UseFont = false;
            this.xrTableCell46.Size = new System.Drawing.Size(1289, 60);
            this.xrTableCell46.Text = "   c) Nebenauslagen";
            this.xrTableCell46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell47
            // 
            this.xrTableCell47.Dpi = 254F;
            this.xrTableCell47.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell47.Location = new System.Drawing.Point(1289, 0);
            this.xrTableCell47.Name = "xrTableCell47";
            this.xrTableCell47.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell47.ParentStyleUsing.UseFont = false;
            this.xrTableCell47.Size = new System.Drawing.Size(71, 60);
            this.xrTableCell47.Text = "SFr.";
            this.xrTableCell47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell48
            // 
            this.xrTableCell48.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Sub_Betrag5c", "{0:n2}")});
            this.xrTableCell48.Dpi = 254F;
            this.xrTableCell48.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell48.Location = new System.Drawing.Point(1360, 0);
            this.xrTableCell48.Name = "xrTableCell48";
            this.xrTableCell48.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell48.ParentStyleUsing.UseFont = false;
            this.xrTableCell48.Size = new System.Drawing.Size(232, 60);
            this.xrTableCell48.Text = "xrTableCell48";
            this.xrTableCell48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCell49
            // 
            this.xrTableCell49.Dpi = 254F;
            this.xrTableCell49.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell49.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell49.Name = "xrTableCell49";
            this.xrTableCell49.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell49.ParentStyleUsing.UseFont = false;
            this.xrTableCell49.Size = new System.Drawing.Size(1289, 60);
            this.xrTableCell49.Text = "6. Andere Aufwendungen";
            this.xrTableCell49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell50
            // 
            this.xrTableCell50.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell50.Dpi = 254F;
            this.xrTableCell50.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell50.Location = new System.Drawing.Point(1289, 0);
            this.xrTableCell50.Name = "xrTableCell50";
            this.xrTableCell50.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell50.ParentStyleUsing.UseBorders = false;
            this.xrTableCell50.ParentStyleUsing.UseFont = false;
            this.xrTableCell50.Size = new System.Drawing.Size(71, 60);
            this.xrTableCell50.Text = "SFr.";
            this.xrTableCell50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell51
            // 
            this.xrTableCell51.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell51.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Sub_Betrag6", "{0:n2}")});
            this.xrTableCell51.Dpi = 254F;
            this.xrTableCell51.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell51.Location = new System.Drawing.Point(1360, 0);
            this.xrTableCell51.Name = "xrTableCell51";
            this.xrTableCell51.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell51.ParentStyleUsing.UseBorders = false;
            this.xrTableCell51.ParentStyleUsing.UseFont = false;
            this.xrTableCell51.Size = new System.Drawing.Size(232, 60);
            this.xrTableCell51.Text = "xrTableCell51";
            this.xrTableCell51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCell52
            // 
            this.xrTableCell52.Dpi = 254F;
            this.xrTableCell52.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell52.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell52.Name = "xrTableCell52";
            this.xrTableCell52.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell52.ParentStyleUsing.UseFont = false;
            this.xrTableCell52.Size = new System.Drawing.Size(1289, 80);
            this.xrTableCell52.Text = "Total    Ausgaben";
            this.xrTableCell52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell53
            // 
            this.xrTableCell53.Dpi = 254F;
            this.xrTableCell53.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell53.Location = new System.Drawing.Point(1289, 0);
            this.xrTableCell53.Name = "xrTableCell53";
            this.xrTableCell53.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell53.ParentStyleUsing.UseFont = false;
            this.xrTableCell53.Size = new System.Drawing.Size(71, 80);
            this.xrTableCell53.Text = "SFr.";
            this.xrTableCell53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell54
            // 
            this.xrTableCell54.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Sub_TotalAusgaben", "{0:n2}")});
            this.xrTableCell54.Dpi = 254F;
            this.xrTableCell54.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell54.Location = new System.Drawing.Point(1360, 0);
            this.xrTableCell54.Name = "xrTableCell54";
            this.xrTableCell54.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell54.ParentStyleUsing.UseFont = false;
            this.xrTableCell54.Size = new System.Drawing.Size(232, 80);
            this.xrTableCell54.Text = "xrTableCell54";
            this.xrTableCell54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableRow9
            // 
            this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
                        this.xrTableCell15,
                        this.xrTableCell22,
                        this.xrTableCell23,
                        this.xrTableCell24});
            this.xrTableRow9.Dpi = 254F;
            this.xrTableRow9.Name = "xrTableRow9";
            this.xrTableRow9.Size = new System.Drawing.Size(1592, 60);
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.Dpi = 254F;
            this.xrTableCell15.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell15.Location = new System.Drawing.Point(0, 0);
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell15.ParentStyleUsing.UseFont = false;
            this.xrTableCell15.Size = new System.Drawing.Size(646, 60);
            this.xrTableCell15.Text = "Anteil Heimatkanton";
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell22
            // 
            this.xrTableCell22.Dpi = 254F;
            this.xrTableCell22.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell22.Location = new System.Drawing.Point(646, 0);
            this.xrTableCell22.Name = "xrTableCell22";
            this.xrTableCell22.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell22.ParentStyleUsing.UseFont = false;
            this.xrTableCell22.Size = new System.Drawing.Size(643, 60);
            this.xrTableCell22.Text = "100%";
            this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell23
            // 
            this.xrTableCell23.Dpi = 254F;
            this.xrTableCell23.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell23.Location = new System.Drawing.Point(1289, 0);
            this.xrTableCell23.Name = "xrTableCell23";
            this.xrTableCell23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell23.ParentStyleUsing.UseFont = false;
            this.xrTableCell23.Size = new System.Drawing.Size(72, 60);
            this.xrTableCell23.Text = "SFr.";
            this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableCell24
            // 
            this.xrTableCell24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Sub_Betrag15Total", "{0:n2}")});
            this.xrTableCell24.Dpi = 254F;
            this.xrTableCell24.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell24.Location = new System.Drawing.Point(1361, 0);
            this.xrTableCell24.Name = "xrTableCell24";
            this.xrTableCell24.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrTableCell24.ParentStyleUsing.UseFont = false;
            this.xrTableCell24.Size = new System.Drawing.Size(231, 60);
            this.xrTableCell24.Text = "xrTableCell24";
            this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margins = new System.Drawing.Printing.Margins(244, 246, 132, 206);
            this.Name = "Report";
            this.PageHeight = 2969;
            this.PageWidth = 2101;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabAbzuege)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabEinnahmen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabAusgaben)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabAnteilHeimatKanton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' ,  N'<NewDataSet>
  <Table>
    <FieldName>KbWVEinzelpostenIDsLbl</FieldName>
    <FieldCode>1</FieldCode>
    <DisplayText>KbWVEinzelpostenIDs.</DisplayText>
    <TabPosition>0</TabPosition>
    <X>9</X>
    <Y>35</Y>
    <Width>147</Width>
    <Height>24</Height>
  </Table>
  <Table>
    <FieldName>KbWVEinzelpostenIDs</FieldName>
    <FieldCode>2</FieldCode>
    <DisplayText>KbWVEinzelpostenIDs</DisplayText>
    <TabPosition>1</TabPosition>
    <X>150</X>
    <Y>35</Y>
    <Width>239</Width>
    <Height>24</Height>
    <Length>2000</Length>
  </Table>
  <Table>
    <FieldName>LanguageCodeLbl</FieldName>
    <FieldCode>1</FieldCode>
    <DisplayText>LanguageCode.</DisplayText>
    <TabPosition>2</TabPosition>
    <X>9</X>
    <Y>66</Y>
    <Width>147</Width>
    <Height>24</Height>
  </Table>
  <Table>
    <FieldName>LanguageCode</FieldName>
    <FieldCode>4</FieldCode>
    <DisplayText>LanguageCode</DisplayText>
    <TabPosition>3</TabPosition>
    <X>150</X>
    <Y>66</Y>
    <Width>50</Width>
    <Height>24</Height>
    <Length>1</Length>
    <DefaultValue>1</DefaultValue>
  </Table>
  <Table>
    <FieldName>DatumVonLbl</FieldName>
    <FieldCode>1</FieldCode>
    <DisplayText>Datum von</DisplayText>
    <TabPosition>4</TabPosition>
    <X>9</X>
    <Y>97</Y>
    <Width>140</Width>
    <Height>24</Height>
  </Table>
  <Table>
    <FieldName>HeaderDatumVon</FieldName>
    <FieldCode>5</FieldCode>
    <DisplayText>HeaderDatumVon</DisplayText>
    <TabPosition>5</TabPosition>
    <X>150</X>
    <Y>97</Y>
    <Width>100</Width>
    <Height>24</Height>
    <Length>10</Length>
  </Table>
  <Table>
    <FieldName>DatumBisLbl</FieldName>
    <FieldCode>1</FieldCode>
    <DisplayText>bis</DisplayText>
    <TabPosition>6</TabPosition>
    <X>256</X>
    <Y>97</Y>
    <Width>30</Width>
    <Height>24</Height>
  </Table>
  <Table>
    <FieldName>HeaderDatumBis</FieldName>
    <FieldCode>5</FieldCode>
    <DisplayText>HeaderDatumBis</DisplayText>
    <TabPosition>7</TabPosition>
    <X>289</X>
    <Y>97</Y>
    <Width>100</Width>
    <Height>24</Height>
    <Length>10</Length>
    <DefaultValue>today</DefaultValue>
  </Table>
</NewDataSet>' ,  N'-- init var
DECLARE @KbWVEinzelpostenIDs VARCHAR(MAX)
DECLARE @LanguageCode INT
DECLARE @HeaderDatumVon DATETIME
DECLARE @HeaderDatumBis DATETIME

SET @KbWVEinzelpostenIDs = {KbWVEinzelpostenIDs}
SET @LanguageCode = {LanguageCode}
SET @HeaderDatumVon = {HeaderDatumVon}
SET @HeaderDatumBis = {HeaderDatumBis}

-- get data using db function
SELECT FCN.Id$,
       FCN.FaLeistungID,
       FCN.BaPersonID,
       FCN.KostenstelleNr,
       Header_DatumVon = ISNULL(CONVERT(VARCHAR, @HeaderDatumVon, 104), ''?''),
       Header_DatumBis = ISNULL(CONVERT(VARCHAR, @HeaderDatumBis, 104), ''?''),
       FCN.Header_PersonName,
       FCN.Header_PersonGeburtsdatum,
       FCN.Header_Heimatgemeinden,
       FCN.Header_Kantone,
       FCN.Header_Wohnort,
       FCN.Header_WohnkantonNr,
       FCN.Header_HeimatkantonNr,
       FCN.Header_Bemerkung,
       FCN.Sub_Betrag1,
       FCN.Sub_Betrag2,
       FCN.Sub_Betrag3,
       FCN.Sub_Betrag4,
       FCN.Sub_Betrag5,
       FCN.Sub_Betrag5a,
       FCN.Sub_Betrag5b,
       FCN.Sub_Betrag5c,
       FCN.Sub_Betrag6,
       FCN.Sub_TotalAusgaben,
       FCN.Sub_Betrag8,
       FCN.Sub_Betrag8a,
       FCN.Sub_Betrag9,
       FCN.Sub_Betrag10,
       FCN.Sub_Betrag11,
       FCN.Sub_TotalEinnahmen,
       FCN.Sub_Betrag14,
       FCN.Sub_Betrag15Total
FROM dbo.fnKbGetWVReportData(@KbWVEinzelpostenIDs, @LanguageCode) FCN
ORDER BY FCN.Header_PersonName, FCN.KostenstelleNr' ,  N'KbZUGAbrechnung' ,  null ,  null )

