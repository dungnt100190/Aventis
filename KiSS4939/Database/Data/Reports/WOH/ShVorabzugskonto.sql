-- Insert Script for ShVorabzugskonto
-- MD5:0XED65108581010BCD0ACBCEED9DF2588F_0XBA4036A16D375AD031C7BD6F40B9A854_0X138B70D38D637D46D619C7BC6E0ECDE3
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'ShVorabzugskonto') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('ShVorabzugskonto', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'ShVorabzugskonto';
--SQLCHECK_IGNORE--
UPDATE QRY
SET QueryName =  N'ShVorabzugskonto' , UserText =  N'SH - Vorabzugskonto' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
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
                        "AAAAak4REVDTEFSRSBAQmdTcGV6a29udG9UeXBDb2RlIGludA0KREVDTEFSRSBARmFMZWlzdHVuZ0lEI" +
                        "GludA0KREVDTEFSRSBARGF0ZUZyb20gZGF0ZXRpbWUNCkRFQ0xBUkUgQERhdGVUbyBkYXRldGltZQ0KD" +
                        "QpTRVQgQEJnU3BlemtvbnRvVHlwQ29kZSA9IG51bGwNClNFVCBARmFMZWlzdHVuZ0lEID0gbnVsbA0KU" +
                        "0VUIEBEYXRlRnJvbSA9IElTTlVMTChudWxsLCAnMDEuMDEuMTkwMCcpDQpTRVQgQERhdGVUbyA9IElTT" +
                        "lVMTChudWxsLCBHZXREYXRlKCkpDQoNCkNSRUFURSBUQUJMRSAjc3BlemtvbnRvIChPcmRlcklEIGlud" +
                        "CBpZGVudGl0eSgxLDEpIHByaW1hcnkga2V5LCBCZ1NwZXprb250b0lEIGludCwNCiAgRmFMZWlzdHVuZ" +
                        "0lEIGludCwgTmFtZVNwZXprb250byB2YXJjaGFyKDEwMCksIFN0YXJ0U2FsZG8gbW9uZXksIFNhbGRvI" +
                        "G1vbmV5LA0KICBHdWVsdGlnVm9uIHZhcmNoYXIoMTYpLCBHdWVsdGlnQmlzIHZhcmNoYXIoMTYpLCBOY" +
                        "W1lVm9ybmFtZSB2YXJjaGFyKDIwMCkpDQoNCkNSRUFURSBUQUJMRSAjdGVtcCAoT3JkZXJJRCBpbnQga" +
                        "WRlbnRpdHkoMSwxKSBwcmltYXJ5IGtleSwgQmdTcGV6S29udG9JRCBpbnQsIFNvcnRLZXkgaW50LA0KI" +
                        "CBKYWhyIHNtYWxsaW50LCBNb25hdCB0aW55aW50LCBNb25hdFRleHQgdmFyY2hhcigxMDApLCBHdXRzY" +
                        "2hyaWZ0IG1vbmV5LCBCZWxhc3R1bmcgbW9uZXksDQogIGZyZWlnZWdlYmVuIGJpdCwgdmVyYnVjaHQgY" +
                        "ml0LCBUZXh0IHZhcmNoYXIoMTAwKSwgU2FsZG8gbW9uZXksDQogIE5hbWVWb3JuYW1lIHZhcmNoYXIoM" +
                        "jAwKSwgU3RhcnRTYWxkbyBtb25leSwgU3BlektvbnRvVHlwIHZhcmNoYXIoMTAwKSwgTmFtZVNwZXprb" +
                        "250byB2YXJjaGFyKDEwMCksIFdoZXJlRGF0ZSBkYXRldGltZSkNCg0KLS0gRmlsbCB0aGUgI3NwZXprb" +
                        "250byB0YWJsZSB3aXRoIHRoZSByaWdodCBhY2NvdW50cyBmb3IgdGhlIHNlbGVjdGVkIEZhRmFsbElED" +
                        "QpJTlNFUlQgSU5UTyAjc3BlemtvbnRvIChCZ1NwZXprb250b0lELCBGYUxlaXN0dW5nSUQsIE5hbWVTc" +
                        "GV6a29udG8sIFN0YXJ0U2FsZG8sIFNhbGRvLCBHdWVsdGlnVm9uLCBHdWVsdGlnQmlzLCBOYW1lVm9yb" +
                        "mFtZSkNCiAgU0VMRUNUCQ0KICAgIFNTSy5CZ1NwZXprb250b0lELA0KICAgIFNTSy5GYUxlaXN0dW5nS" +
                        "UQsDQogICAgU1NLLk5hbWVTcGV6a29udG8sDQogICAgU1NLLlN0YXJ0U2FsZG8sDQogICAgU2FsZG8gI" +
                        "CAgICAgICA9IGRiby5mbkJnU3BlemtvbnRvKFNTSy5CZ1NwZXprb250b0lELDMsZGVmYXVsdCxkZWZhd" +
                        "Wx0KSwNCiAgICBHdWVsdGlnVm9uICAgID0gZGJvLmZuWEt1cnpNb25hdEphaHIoU1NLLkRhdHVtVm9uK" +
                        "SwNCiAgICBHdWVsdGlnQmlzICAgID0gZGJvLmZuWEt1cnpNb25hdEphaHIoU1NLLkRhdHVtQmlzKSwNC" +
                        "iAgICBOYW1lVm9ybmFtZQk9IFBSUy5OYW1lICsgJyAnICsgUFJTLlZvcm5hbWUNCiAgRlJPTSBCZ1NwZ" +
                        "Xprb250byBTU0sNCiAgICBMRUZUIEpPSU4gQmdLb3N0ZW5hcnQgIEZMSyBPTiBGTEsuQmdLb3N0ZW5hc" +
                        "nRJRCA9IFNTSy5CZ0tvc3RlbmFydElEDQogICAgTEVGVCBKT0lOIEJhUGVyc29uICAgIFBSUyBPTiBQU" +
                        "lMuQmFQZXJzb25JRCA9IChTRUxFQ1QgRkFMLkJhUGVyc29uSUQgRlJPTSBGYUxlaXN0dW5nIEZBTCBXS" +
                        "EVSRSBGQUwuRmFMZWlzdHVuZ0lEID0gQEZhTGVpc3R1bmdJRCkNCiAgV0hFUkUgU1NLLkZhTGVpc3R1b" +
                        "mdJRCA9IEBGYUxlaXN0dW5nSUQNCiAgICBBTkQgU1NLLkJnU3BlektvbnRvVHlwQ29kZSA9IEBCZ1NwZ" +
                        "Xprb250b1R5cENvZGUNCiAgICBBTkQgaXNOdWxsKFNTSy5EYXR1bUJpcyxnZXRkYXRlKCkpID49IGdld" +
                        "GRhdGUoKQ0KICBPUkRFUiBCWSBTU0suRGF0dW1Wb24gREVTQywgU1NLLk5hbWVTcGV6a29udG8NCg0KL" +
                        "S0gRmlsbCB0aGUgI3RlbXAgdGFibGUgd2l0aCB0aGUgY29ycmVjdCB2YWx1ZXMNCkRFQ0xBUkUgYyBDV" +
                        "VJTT1IgRk9SV0FSRF9PTkxZDQpGT1INCiAgU0VMRUNUIEJnU3BlemtvbnRvSUQsIE5hbWVWb3JuYW1lL" +
                        "CBTdGFydFNhbGRvLCBOYW1lU3BlemtvbnRvICBGUk9NICNzcGV6a29udG8gT1JERVIgQlkgT3JkZXJJR" +
                        "A0KDQpERUNMQVJFIEBCZ1NwZXprb250b0lEICBpbnQNCkRFQ0xBUkUgQE5hbWVWb3JuYW1lIHZhcmNoY" +
                        "XIoMjAwKQ0KREVDTEFSRSBAU3RhcnRTYWxkbyBtb25leQ0KREVDTEFSRSBATmFtZVNwZXprb250byB2Y" +
                        "XJjaGFyKDEwMCkNCg0KT1BFTiBjDQoNCkZFVENIIE5FWFQgRlJPTSBjIElOVE8gQEJnU3BlemtvbnRvS" +
                        "UQsIEBOYW1lVm9ybmFtZSwgQFN0YXJ0U2FsZG8sIEBOYW1lU3BlemtvbnRvDQoNCldISUxFIChAQEZFV" +
                        "ENIX1NUQVRVUz0wKSBCRUdJTg0KDQogIElOU0VSVCBJTlRPICN0ZW1wIChCZ1NwZXprb250b0lELCBTb" +
                        "3J0S2V5LCBKYWhyLCBNb25hdCwgTW9uYXRUZXh0LCBHdXRzY2hyaWZ0LCBCZWxhc3R1bmcsDQogIGZyZ" +
                        "WlnZWdlYmVuLCB2ZXJidWNodCwgVGV4dCwgU2FsZG8sIE5hbWVWb3JuYW1lLCBTdGFydFNhbGRvLCBTc" +
                        "GV6S29udG9UeXAsIE5hbWVTcGV6a29udG8sIFdoZXJlRGF0ZSkNCg0KICBTRUxFQ1QNCiAgICBCZ1NwZ" +
                        "Xprb250b0lEID0gQEJnU3BlemtvbnRvSUQsDQogICAgU29ydEtleSAgICAgPSBjYXNlIHdoZW4gQEJnU" +
                        "3BlemtvbnRvVHlwQ29kZSA9IDMgdGhlbiAyIGVsc2UgMSBlbmQsDQogICAgSmFociAgICAgICAgPSBCR" +
                        "EcuSmFociwNCiAgICBNb25hdCAgICAgICA9IEJERy5Nb25hdCwNCiAgICBNb25hdFRleHQgICA9IGRib" +
                        "y5mblhLdXJ6TW9uYXQoQkRHLk1vbmF0KSArICcgJyArIGNvbnZlcnQodmFyY2hhcixCREcuSmFociksD" +
                        "QogICAgR3V0c2NocmlmdCAgPSBCUE8uQmV0cmFnUmVjaG51bmcsDQogICAgQmVsYXN0dW5nICAgPSBjb" +
                        "252ZXJ0KG1vbmV5LG51bGwpLA0KICAgIGZyZWlnZWdlYmVuID0gY29udmVydChiaXQsY2FzZSB3aGVuI" +
                        "EJERy5CZ0Jld2lsbGlndW5nU3RhdHVzQ29kZSA9IDIgdGhlbiAxIGVsc2UgMCBlbmQpLA0KICAgIHZlc" +
                        "mJ1Y2h0ICAgID0gY29udmVydChiaXQsMCksDQogICAgVGV4dCAgICAgICAgPSAnJywNCiAgICBTYWxkb" +
                        "wk9IGNvbnZlcnQobW9uZXksbnVsbCksDQogICAgTmFtZVZvcm5hbWUgPSBATmFtZVZvcm5hbWUsDQogI" +
                        "CAgU3RhcnRTYWxkbwk9IEBTdGFydFNhbGRvLA0KICAgIFNwZXpLb250b1R5cCAgPSBkYm8uZm5MT1ZUZ" +
                        "Xh0KCdCZ1NwZXprb250b1R5cCcsIEBCZ1NwZXprb250b1R5cENvZGUpLA0KICAgIE5hbWVTcGV6a29ud" +
                        "G8gPSBATmFtZVNwZXprb250bywNCiAgICBXaGVyZURhdGUJPSBDT05WRVJUKGRhdGV0aW1lLCAnMDEuJ" +
                        "yArIENPTlZFUlQoVkFSQ0hBUiwgQkRHLk1vbmF0KSArICcuJyArIENPTlZFUlQoVkFSQ0hBUiwgQkRHL" +
                        "kphaHIpLDEwNCkNCiAgRlJPTSB2d0JnUG9zaXRpb24gQlBPDQogICAgSU5ORVIgSk9JTiBCZ0J1ZGdld" +
                        "CBCREcgb24gQkRHLkJnQnVkZ2V0SUQgPSBCUE8uQmdCdWRnZXRJRA0KICBXSEVSRSBCUE8uQmdTcGV6a" +
                        "29udG9JRCA9IEBCZ1NwZXprb250b0lEDQogICAgQU5EIEJERy5NYXN0ZXJCdWRnZXQgPSAwDQogICAgQ" +
                        "U5EIEJQTy5CZ0thdGVnb3JpZUNvZGUgPD4gMTAxDQoNCiAgVU5JT04gQUxMDQogIA0KICBTRUxFQ1QNC" +
                        "iAgICBCZ1NwZXprb250b0lEID0gQEJnU3BlemtvbnRvSUQsDQogICAgU29ydEtleSAgICAgPSBjYXNlI" +
                        "HdoZW4gQEJnU3BlemtvbnRvVHlwQ29kZSA9IDMgdGhlbiAyIGVsc2UgMSBlbmQsDQogICAgSmFociAgI" +
                        "CAgICAgPSBCREcuSmFociwNCiAgICBNb25hdCAgICAgICA9IEJERy5Nb25hdCwNCiAgICBNb25hdFRle" +
                        "HQgICA9IGRiby5mblhLdXJ6TW9uYXQoQkRHLk1vbmF0KSArICcgJyArIGNvbnZlcnQodmFyY2hhcixCR" +
                        "EcuSmFociksDQogICAgR3V0c2NocmlmdCAgPSBjb252ZXJ0KG1vbmV5LG51bGwpLA0KICAgIEJlbGFzd" +
                        "HVuZyAgID0gQlBPLkJldHJhZywNCiAgICBmcmVpZ2VnZWJlbiA9IGNvbnZlcnQoYml0LGNhc2Ugd2hlb" +
                        "iBCREcuQmdCZXdpbGxpZ3VuZ1N0YXR1c0NvZGUgPSAyIHRoZW4gMSBlbHNlIDAgZW5kKSwNCiAgICB2Z" +
                        "XJidWNodCAgICA9IGNvbnZlcnQoYml0LDApLA0KICAgIFRleHQgICAgICAgID0gQlBPLkJ1Y2h1bmdzd" +
                        "GV4dCwNCiAgICBTYWxkbwk9IGNvbnZlcnQobW9uZXksbnVsbCksDQogICAgTmFtZVZvcm5hbWUgPSBAT" +
                        "mFtZVZvcm5hbWUsDQogICAgU3RhcnRTYWxkbwk9IEBTdGFydFNhbGRvLA0KICAgIFNwZXpLb250b1R5c" +
                        "CAgPSBkYm8uZm5MT1ZUZXh0KCdCZ1NwZXprb250b1R5cCcsIEBCZ1NwZXprb250b1R5cENvZGUpLA0KI" +
                        "CAgIE5hbWVTcGV6a29udG8gPSBATmFtZVNwZXprb250bywNCiAgICBXaGVyZURhdGUJPSBDT05WRVJUK" +
                        "GRhdGV0aW1lLCAnMDEuJyArIENPTlZFUlQoVkFSQ0hBUiwgQkRHLk1vbmF0KSArICcuJyArIENPTlZFU" +
                        "lQoVkFSQ0hBUiwgQkRHLkphaHIpLDEwNCkNCiAgRlJPTSB2d0JnUG9zaXRpb24gQlBPDQogICAgSU5OR" +
                        "VIgSk9JTiBCZ0J1ZGdldCBCREcgb24gQkRHLkJnQnVkZ2V0SUQgPSBCUE8uQmdCdWRnZXRJRA0KICBXS" +
                        "EVSRSBCUE8uQmdTcGV6a29udG9JRCA9IEBCZ1NwZXprb250b0lEDQogICAgQU5EIEJERy5NYXN0ZXJCd" +
                        "WRnZXQgPSAwDQogICAgQU5EIEJQTy5CZ0thdGVnb3JpZUNvZGUgPSAxMDEgLS0gRWluemVsemFobHVuZ" +
                        "w0KDQogIE9SREVSIEJZIEphaHIgZGVzYywgTW9uYXQgZGVzYywgU29ydEtleSBkZXNjLCBCZWxhc3R1b" +
                        "mcgZGVzYw0KDQogIEZFVENIIE5FWFQgRlJPTSBjIElOVE8gQEJnU3BlemtvbnRvSUQsIEBOYW1lVm9yb" +
                        "mFtZSwgQFN0YXJ0U2FsZG8sIEBOYW1lU3BlemtvbnRvDQpFTkQNCg0KQ0xPU0UgYw0KREVBTExPQ0FUR" +
                        "SBjDQoNCi0tc2VsZWN0ICogZnJvbSAjdGVtcA0KDQotLSBDYWxjdWxhdGluZyB0aGUgU2FsZG8gYW5kI" +
                        "HVwZGF0ZSB0aGUgI3RlbXAgdGFibGUNCkRFQ0xBUkUgY2FsY1NhbGRvIENVUlNPUiBGT1JXQVJEX09OT" +
                        "FkNCkZPUg0KICBTRUxFQ1QgT3JkZXJJRCwgQmdTcGV6S29udG9JRCwgR3V0c2NocmlmdCwgQmVsYXN0d" +
                        "W5nICBGUk9NICN0ZW1wIE9SREVSIEJZIE9yZGVySUQNCg0KREVDTEFSRSBAY2FsY0JnU3BlemtvbnRvS" +
                        "UQgIGludA0KREVDTEFSRSBAY2FsY0d1dHNjaHJpZnQgbW9uZXkNCkRFQ0xBUkUgQGNhbGNCZWxhc3R1b" +
                        "mcgbW9uZXkNCkRFQ0xBUkUgQHByZXZHdXRzY2hyaWZ0IG1vbmV5DQpERUNMQVJFIEBwcmV2QmVsYXN0d" +
                        "W5nIG1vbmV5DQpERUNMQVJFIEBjYWxjQWN0U2FsZG8gbW9uZXkNCkRFQ0xBUkUgQG9sZEJnU3Blemtvb" +
                        "nRvSUQgaW50DQpERUNMQVJFIEBvcmRlcklEIGludA0KDQpPUEVOIGNhbGNTYWxkbw0KDQpGRVRDSCBOR" +
                        "VhUIEZST00gY2FsY1NhbGRvIElOVE8gQG9yZGVySUQsIEBjYWxjQmdTcGV6a29udG9JRCwgQGNhbGNHd" +
                        "XRzY2hyaWZ0LCBAY2FsY0JlbGFzdHVuZw0KDQpTRVQgQG9sZEJnU3BlemtvbnRvSUQgPSBAY2FsY0JnU" +
                        "3BlemtvbnRvSUQNClNFVCBAY2FsY0FjdFNhbGRvID0gQ09OVkVSVChtb25leSwgKFNFTEVDVCBkYm8uZ" +
                        "m5CZ1NwZXprb250byhAY2FsY0JnU3BlemtvbnRvSUQsMyxkZWZhdWx0LGRlZmF1bHQpKSkNClNFVCBAc" +
                        "HJldkd1dHNjaHJpZnQgPSBJU05VTEwoQGNhbGNHdXRzY2hyaWZ0LCAwKQ0KU0VUIEBwcmV2QmVsYXN0d" +
                        "W5nID0gSVNOVUxMKEBjYWxjQmVsYXN0dW5nLCAwKQ0KDQpXSElMRSAoQEBGRVRDSF9TVEFUVVM9MCkgQ" +
                        "kVHSU4NCiAgSUYgQE9yZGVySUQgPiAxIEJFR0lODQogICAgIElGIEBvbGRCZ1NwZXprb250b0lEID0gQ" +
                        "GNhbGNCZ1NwZXprb250b0lEIEJFR0lODQogICAgICAgIFNFVCBAY2FsY0FjdFNhbGRvID0gQGNhbGNBY" +
                        "3RTYWxkbyAtIElTTlVMTChAcHJldkd1dHNjaHJpZnQsIDApICsgSVNOVUxMKEBwcmV2QmVsYXN0dW5nL" +
                        "CAwKQ0KICAgICBFTkQgRUxTRSBCRUdJTg0KICAgICAgICBTRVQgQG9sZEJnU3BlemtvbnRvSUQgPSBAY" +
                        "2FsY0JnU3BlemtvbnRvSUQNCiAgICAgICAgU0VUIEBjYWxjQWN0U2FsZG8gPSBDT05WRVJUKG1vbmV5L" +
                        "CAoU0VMRUNUIGRiby5mbkJnU3BlemtvbnRvKEBjYWxjQmdTcGV6a29udG9JRCwzLGRlZmF1bHQsZGVmY" +
                        "XVsdCkpKQ0KICAgICBFTkQNCiAgRU5EDQoNCiAgU0VUIEBwcmV2R3V0c2NocmlmdCA9IElTTlVMTChAY" +
                        "2FsY0d1dHNjaHJpZnQsIDApDQogIFNFVCBAcHJldkJlbGFzdHVuZyA9IElTTlVMTChAY2FsY0JlbGFzd" +
                        "HVuZywgMCkNCg0KICBVUERBVEUgI3RlbXANCiAgU0VUIFNhbGRvID0gQGNhbGNBY3RTYWxkbw0KICBXS" +
                        "EVSRSBPcmRlcklEID0gQG9yZGVySUQNCg0KICBGRVRDSCBORVhUIEZST00gY2FsY1NhbGRvIElOVE8gQ" +
                        "G9yZGVySUQsIEBjYWxjQmdTcGV6a29udG9JRCwgQGNhbGNHdXRzY2hyaWZ0LCBAY2FsY0JlbGFzdHVuZ" +
                        "w0KRU5EDQoNCkNMT1NFIGNhbGNTYWxkbw0KREVBTExPQ0FURSBjYWxjU2FsZG8NCg0KLS0gU2VsZWN0I" +
                        "GFsbCB2YWx1ZXMgZm9yIHRoZSByZXBvcnQNClNFTEVDVA0KICAgIE9yZ19OYW1lICAgID0gSXNOdWxsK" +
                        "ENPTlZFUlQodmFyY2hhcigxMDAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc2VcU296aWFsa" +
                        "GlsZmVcT3JnYW5pc2F0aW9uJywgR2V0ZGF0ZSgpKSksICcnKSwNCiAgICBPcmdfQWRyZXNzZSA9IElzT" +
                        "nVsbChDT05WRVJUKHZhcmNoYXIoMTAwMCksIGRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlXFNve" +
                        "mlhbGhpbGZlXEFkcmVzc2UnLCBHZXRkYXRlKCkpKSwgJycpLA0KICAgIE9yZ19QTFogICAgID0gSXNOd" +
                        "WxsKENPTlZFUlQodmFyY2hhcigxMDAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc2VcU296a" +
                        "WFsaGlsZmVcUExaJywgR2V0ZGF0ZSgpKSksICcnKSwNCiAgICBPcmdfT3J0ICAgICA9IElzTnVsbChDT" +
                        "05WRVJUKHZhcmNoYXIoMTAwMCksIGRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlXFNvemlhbGhpb" +
                        "GZlXE9ydCcsIEdldGRhdGUoKSkpLCAnJyksDQogICAgT3JnX1BMWk9ydCAgPSBJc051bGwoQ09OVkVSV" +
                        "Ch2YXJjaGFyKDEwMDApLCBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxQT" +
                        "FonLCBHZXRkYXRlKCkpKSArICcgJywgJycpDQogICAgICAgICAgICAgICAgKyBJc051bGwoQ09OVkVSV" +
                        "Ch2YXJjaGFyKDEwMDApLCBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxPc" +
                        "nQnLCBHZXRkYXRlKCkpKSwgJycpLA0KICAgICoNCkZST00gI3RlbXANCldIRVJFIERBVEVBREQoREFZL" +
                        "CAtMSwgREFURUFERChNT05USCwgMSwgV2hlcmVEYXRlKSkgPj0gIEBEYXRlRnJvbSBBTkQgV2hlcmVEY" +
                        "XRlIDw9IEBEYXRlVG8NCk9SREVSIEJZIE9yZGVySUQNCg0KRFJPUCBUQUJMRSAjc3BlemtvbnRvDQpEU" +
                        "k9QIFRBQkxFICN0ZW1w";
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
            this.ReportHeader.Height = 164;
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
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text", "")});
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
            this.lblSaldo.Location = new System.Drawing.Point(698, 147);
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
            this.txtOrgPlzOrt.Location = new System.Drawing.Point(21, 85);
            this.txtOrgPlzOrt.Name = "txtOrgPlzOrt";
            this.txtOrgPlzOrt.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtOrgPlzOrt.ParentStyleUsing.UseFont = false;
            this.txtOrgPlzOrt.Size = new System.Drawing.Size(741, 42);
            this.txtOrgPlzOrt.Text = "txtOrgPlzOrt";
            // 
            // txtOrgAdresse
            // 
            this.txtOrgAdresse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Adresse", "")});
            this.txtOrgAdresse.Dpi = 254F;
            this.txtOrgAdresse.Font = new System.Drawing.Font("Arial", 9F);
            this.txtOrgAdresse.Location = new System.Drawing.Point(21, 42);
            this.txtOrgAdresse.Name = "txtOrgAdresse";
            this.txtOrgAdresse.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtOrgAdresse.ParentStyleUsing.UseFont = false;
            this.txtOrgAdresse.Size = new System.Drawing.Size(741, 43);
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
		<DisplayText>Leistung ID</DisplayText>
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

CREATE TABLE #spezkonto (OrderID int identity(1,1) primary key, BgSpezkontoID int,
  FaLeistungID int, NameSpezkonto varchar(100), StartSaldo money, Saldo money,
  GueltigVon varchar(16), GueltigBis varchar(16), NameVorname varchar(200))

CREATE TABLE #temp (OrderID int identity(1,1) primary key, BgSpezKontoID int, SortKey int,
  Jahr smallint, Monat tinyint, MonatText varchar(100), Gutschrift money, Belastung money,
  freigegeben bit, verbucht bit, Text varchar(100), Saldo money,
  NameVorname varchar(200), StartSaldo money, SpezKontoTyp varchar(100), NameSpezkonto varchar(100), WhereDate datetime)

-- Fill the #spezkonto table with the right accounts for the selected FaFallID
INSERT INTO #spezkonto (BgSpezkontoID, FaLeistungID, NameSpezkonto, StartSaldo, Saldo, GueltigVon, GueltigBis, NameVorname)
  SELECT	
    SSK.BgSpezkontoID,
    SSK.FaLeistungID,
    SSK.NameSpezkonto,
    SSK.StartSaldo,
    Saldo         = dbo.fnBgSpezkonto(SSK.BgSpezkontoID,3,default,default),
    GueltigVon    = dbo.fnXKurzMonatJahr(SSK.DatumVon),
    GueltigBis    = dbo.fnXKurzMonatJahr(SSK.DatumBis),
    NameVorname	= PRS.Name + '' '' + PRS.Vorname
  FROM BgSpezkonto SSK
    LEFT JOIN BgKostenart  FLK ON FLK.BgKostenartID = SSK.BgKostenartID
    LEFT JOIN BaPerson    PRS ON PRS.BaPersonID = (SELECT FAL.BaPersonID FROM FaLeistung FAL WHERE FAL.FaLeistungID = @FaLeistungID)
  WHERE SSK.FaLeistungID = @FaLeistungID
    AND SSK.BgSpezKontoTypCode = @BgSpezkontoTypCode
    AND (@NurAktive = 0 OR ISNULL(SSK.DatumBis,getdate()) >= getdate())
  ORDER BY SSK.DatumVon DESC, SSK.NameSpezkonto

-- Fill the #temp table with the correct values
DECLARE c CURSOR FORWARD_ONLY
FOR
  SELECT BgSpezkontoID, NameVorname, StartSaldo, NameSpezkonto  FROM #spezkonto ORDER BY OrderID

DECLARE @BgSpezkontoID  int
DECLARE @NameVorname varchar(200)
DECLARE @StartSaldo money
DECLARE @NameSpezkonto varchar(100)

OPEN c

FETCH NEXT FROM c INTO @BgSpezkontoID, @NameVorname, @StartSaldo, @NameSpezkonto

WHILE (@@FETCH_STATUS=0) BEGIN

  INSERT INTO #temp (BgSpezkontoID, SortKey, Jahr, Monat, MonatText, Gutschrift, Belastung,
  freigegeben, verbucht, Text, Saldo, NameVorname, StartSaldo, SpezKontoTyp, NameSpezkonto, WhereDate)

  SELECT
    BgSpezkontoID = @BgSpezkontoID,
    SortKey     = case when @BgSpezkontoTypCode = 3 then 2 else 1 end,
    Jahr        = BDG.Jahr,
    Monat       = BDG.Monat,
    MonatText   = dbo.fnXKurzMonat(BDG.Monat) + '' '' + convert(varchar,BDG.Jahr),
    Gutschrift  = BPO.BetragRechnung,
    Belastung   = convert(money,null),
    freigegeben = convert(bit,case when BDG.BgBewilligungStatusCode = 2 then 1 else 0 end),
    verbucht    = convert(bit,0),
    Text        = '''',
    Saldo	= convert(money,null),
    NameVorname = @NameVorname,
    StartSaldo	= @StartSaldo,
    SpezKontoTyp  = dbo.fnLOVText(''BgSpezkontoTyp'', @BgSpezkontoTypCode),
    NameSpezkonto = @NameSpezkonto,
    WhereDate	= CONVERT(datetime, ''01.'' + CONVERT(VARCHAR, BDG.Monat) + ''.'' + CONVERT(VARCHAR, BDG.Jahr),104)
  FROM vwBgPosition BPO
    INNER JOIN BgBudget BDG on BDG.BgBudgetID = BPO.BgBudgetID
  WHERE BPO.BgSpezkontoID = @BgSpezkontoID
    AND BDG.MasterBudget = 0
    AND BPO.BgKategorieCode <> 101

  UNION ALL
  
  SELECT
    BgSpezkontoID = @BgSpezkontoID,
    SortKey     = case when @BgSpezkontoTypCode = 3 then 2 else 1 end,
    Jahr        = BDG.Jahr,
    Monat       = BDG.Monat,
    MonatText   = dbo.fnXKurzMonat(BDG.Monat) + '' '' + convert(varchar,BDG.Jahr),
    Gutschrift  = convert(money,null),
    Belastung   = BPO.Betrag,
    freigegeben = convert(bit,case when BDG.BgBewilligungStatusCode = 2 then 1 else 0 end),
    verbucht    = convert(bit,0),
    Text        = BPO.Buchungstext,
    Saldo	= convert(money,null),
    NameVorname = @NameVorname,
    StartSaldo	= @StartSaldo,
    SpezKontoTyp  = dbo.fnLOVText(''BgSpezkontoTyp'', @BgSpezkontoTypCode),
    NameSpezkonto = @NameSpezkonto,
    WhereDate	= CONVERT(datetime, ''01.'' + CONVERT(VARCHAR, BDG.Monat) + ''.'' + CONVERT(VARCHAR, BDG.Jahr),104)
  FROM vwBgPosition BPO
    INNER JOIN BgBudget BDG on BDG.BgBudgetID = BPO.BgBudgetID
  WHERE BPO.BgSpezkontoID = @BgSpezkontoID
    AND BDG.MasterBudget = 0
    AND BPO.BgKategorieCode = 101 -- Einzelzahlung

  ORDER BY Jahr desc, Monat desc, SortKey desc, Belastung desc

  FETCH NEXT FROM c INTO @BgSpezkontoID, @NameVorname, @StartSaldo, @NameSpezkonto
END

CLOSE c
DEALLOCATE c

--select * from #temp

-- Calculating the Saldo and update the #temp table
DECLARE calcSaldo CURSOR FORWARD_ONLY
FOR
  SELECT OrderID, BgSpezKontoID, Gutschrift, Belastung  FROM #temp ORDER BY OrderID

DECLARE @calcBgSpezkontoID  int
DECLARE @calcGutschrift money
DECLARE @calcBelastung money
DECLARE @prevGutschrift money
DECLARE @prevBelastung money
DECLARE @calcActSaldo money
DECLARE @oldBgSpezkontoID int
DECLARE @orderID int

OPEN calcSaldo

FETCH NEXT FROM calcSaldo INTO @orderID, @calcBgSpezkontoID, @calcGutschrift, @calcBelastung

SET @oldBgSpezkontoID = @calcBgSpezkontoID
SET @calcActSaldo = CONVERT(money, (SELECT dbo.fnBgSpezkonto(@calcBgSpezkontoID,3,default,default)))
SET @prevGutschrift = ISNULL(@calcGutschrift, 0)
SET @prevBelastung = ISNULL(@calcBelastung, 0)

WHILE (@@FETCH_STATUS=0) BEGIN
  IF @OrderID > 1 BEGIN
     IF @oldBgSpezkontoID = @calcBgSpezkontoID BEGIN
        SET @calcActSaldo = @calcActSaldo - ISNULL(@prevGutschrift, 0) + ISNULL(@prevBelastung, 0)
     END ELSE BEGIN
        SET @oldBgSpezkontoID = @calcBgSpezkontoID
        SET @calcActSaldo = CONVERT(money, (SELECT dbo.fnBgSpezkonto(@calcBgSpezkontoID,3,default,default)))
     END
  END

  SET @prevGutschrift = ISNULL(@calcGutschrift, 0)
  SET @prevBelastung = ISNULL(@calcBelastung, 0)

  UPDATE #temp
  SET Saldo = @calcActSaldo
  WHERE OrderID = @orderID

  FETCH NEXT FROM calcSaldo INTO @orderID, @calcBgSpezkontoID, @calcGutschrift, @calcBelastung
END

CLOSE calcSaldo
DEALLOCATE calcSaldo

-- Select all values for the report
SELECT
    Org_Name    = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Organisation'', Getdate())), ''''),
    Org_Adresse = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Adresse'', Getdate())), ''''),
    Org_PLZ     = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', Getdate())), ''''),
    Org_Ort     = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', Getdate())), ''''),
    Org_PLZOrt  = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', Getdate())) + '' '', '''')
                + IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', Getdate())), ''''),
    *
FROM #temp
WHERE DATEADD(DAY, -1, DATEADD(MONTH, 1, WhereDate)) >=  @DateFrom AND WhereDate <= @DateTo
ORDER BY OrderID

DROP TABLE #spezkonto
DROP TABLE #temp' , ContextForms =  N'CtlWhSpezialkonto' , ParentReportName =  null , ReportSortKey =  null , System =  0 
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'ShVorabzugskonto' ;


