-- Insert Script for ShEsilVerfuegung
DELETE FROM XQuery WHERE QueryName LIKE 'ShEsilVerfuegung' OR ParentReportName LIKE 'ShEsilVerfuegung'
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShEsilVerfuegung' ,  N'SH - ESIL Verfügung' , 1,  N'/// <XRTypeInfo>
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
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.Subreport ShEsilVerfuegung_Unterst;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRPageBreak xrPageBreak1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRRichTextBox xrRichTextBox2;
        private DevExpress.XtraReports.UI.XRPageInfo piOrgOrtDatum;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel txtEmployeeName;
        private DevExpress.XtraReports.UI.XRLabel txtBezugsmonat;
        private DevExpress.XtraReports.UI.XRLabel txtMbStatus;
        private DevExpress.XtraReports.UI.XRLabel txtDatumBis;
        private DevExpress.XtraReports.UI.XRLabel txtDatumVon;
        private DevExpress.XtraReports.UI.XRLabel txtFpTyp;
        private DevExpress.XtraReports.UI.XRLabel Label11;
        private DevExpress.XtraReports.UI.XRLabel Label10;
        private DevExpress.XtraReports.UI.XRLabel Label9;
        private DevExpress.XtraReports.UI.XRLabel Label8;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.XRLabel txtFpStatus;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.XRLabel txtKlientName;
        private DevExpress.XtraReports.UI.XRLabel Label5;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.XRLabel OrgPLZOrt;
        private DevExpress.XtraReports.UI.XRLabel OrgAdresse;
        private DevExpress.XtraReports.UI.XRLabel OrgName;
        private DevExpress.XtraReports.UI.XRLabel Label12;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAAEAAAAAQAAAIwBRGV2RXhwcmVzc" +
                        "y5YdHJhUmVwb3J0cy5VSS5TZXJpYWxpemFibGVTdHJpbmcsIERldkV4cHJlc3MuWHRyYVJlcG9ydHMud" +
                        "jYuMiwgVmVyc2lvbj02LjIuNi4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPTc5ODY4Y" +
                        "jgxNDdiNWVhZTRQlgpmhZM0kYYTtE6k1iF9SIIAAAAAAAAASwAAAMkAAABWAgAARnAAaQBPAHIAZwBPA" +
                        "HIAdABEAGEAdAB1AG0ALgBTAGMAcgBpAHAAdABzAC4ATwBuAEIAZQBmAG8AcgBlAFAAcgBpAG4AdAAAA" +
                        "AAAMnMAcQBsAFEAdQBlAHIAeQAxAC4AUwBlAGwAZQBjAHQAUwB0AGEAdABlAG0AZQBuAHQA0gAAAEJ4A" +
                        "HIAUABhAGcAZQBJAG4AZgBvADEALgBTAGMAcgBpAHAAdABzAC4ATwBuAEIAZQBmAG8AcgBlAFAAcgBpA" +
                        "G4AdAB6DgAALHgAcgBSAGkAYwBoAFQAZQB4AHQAQgBvAHgAMgAuAFIAdABmAFQAZQB4AHQATA8AAAHPA" +
                        "XByaXZhdGUgdm9pZCBPbkJlZm9yZVByaW50KG9iamVjdCBzZW5kZXIsIFN5c3RlbS5EcmF3aW5nLlBya" +
                        "W50aW5nLlByaW50RXZlbnRBcmdzIGUpIHsNCiAgcGlPcmdPcnREYXR1bS5Gb3JtYXQgPSBwaU9yZ09yd" +
                        "ERhdHVtLkZvcm1hdC5SZXBsYWNlKCI8T3JnT3J0PiIsUmVwb3J0LkdldEN1cnJlbnRDb2x1bW5WYWx1Z" +
                        "SgiT3JnX09ydCIpLlRvU3RyaW5nKCkpOw0KfQGlG1NFTEVDVCBUT1AgMQ0KICAgICAgICAgUE9TLkJnU" +
                        "G9zaXRpb25JRCwNCiAgICAgICAgIFBPUy5CZXRyYWcsDQogICAgICAgICBOYW1lRWluemVsemFobHVuZ" +
                        "yA9IFBPUy5CdWNodW5nc3RleHQsDQogICAgICAgICBQT1MuQmVtZXJrdW5nLA0KICAgICAgICAgS29zd" +
                        "GVuYXJ0ICAgICA9IElTTlVMTChLU1QuTmFtZSwgSVNOVUxMKEtTVDEuTmFtZSwgJycpKSwNCiAgICAgI" +
                        "CAgIE9yZ19OYW1lICAgICAgPSBJc051bGwoQ09OVkVSVCh2YXJjaGFyKDEwMDApLCBkYm8uZm5YQ29uZ" +
                        "mlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxPcmdhbmlzYXRpb24nLCBHZXRkYXRlKCkpKSwgJ" +
                        "ycpLA0KICAgICAgICAgT3JnX0FkcmVzc2UgICA9IElzTnVsbChDT05WRVJUKHZhcmNoYXIoMTAwMCksI" +
                        "GRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlXEFkcmVzc2UnLCBHZXRkYXRlK" +
                        "CkpKSwgJycpLA0KICAgICAgICAgT3JnX1BMWiAgICAgICA9IElzTnVsbChDT05WRVJUKHZhcmNoYXIoM" +
                        "TAwMCksIGRiby5mblhDb25maWcoJ1N5c3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlXFBMWicsIEdldGRhd" +
                        "GUoKSkpLCAnJyksDQogICAgICAgICBPcmdfT3J0ICAgICAgID0gSXNOdWxsKENPTlZFUlQodmFyY2hhc" +
                        "igxMDAwKSwgZGJvLmZuWENvbmZpZygnU3lzdGVtXEFkcmVzc2VcU296aWFsaGlsZmVcT3J0JywgR2V0Z" +
                        "GF0ZSgpKSksICcnKSwNCiAgICAgICAgIE9yZ19QTFpPcnQgICAgPSBJc051bGwoQ09OVkVSVCh2YXJja" +
                        "GFyKDEwMDApLCBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxQTFonLCBHZ" +
                        "XRkYXRlKCkpKSArICcgJywgJycpICsNCiAgICAgICAgICAgICAgICAgICAgICAgICBJc051bGwoQ09OV" +
                        "kVSVCh2YXJjaGFyKDEwMDApLCBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZ" +
                        "VxPcnQnLCBHZXRkYXRlKCkpKSwgJycpLA0KICAgICAgICAgS2xpZW50TmFtZSAgICA9IFBSUy5OYW1lI" +
                        "CsgJywgJyArIFBSUy5Wb3JuYW1lICsgSXNOdWxsKCcgJyArIFBSUy5Wb3JuYW1lMiwgJycpLA0KICAgI" +
                        "CAgICAgRnBTdGF0dXMgICAgICA9IExWUy5UZXh0LA0KICAgICAgICAgRnBUeXAgICAgICAgICA9IExWV" +
                        "C5UZXh0LA0KICAgICAgICAgSXNVcmdlbnQgICAgICA9IExWVC5WYWx1ZTIsIC0tIDIuMCBEQjogSXNVc" +
                        "mdlbnQNCiAgICAgICAgIEdlcGxhbnRWb24gICAgPSBTRlAuR2VwbGFudFZvbiwNCiAgICAgICAgIEdlc" +
                        "GxhbnRCaXMgICAgPSBTRlAuR2VwbGFudEJpcywNCiAgICAgICAgIERhdHVtVm9uICAgICAgPSBTRlAuR" +
                        "GF0dW1Wb24sDQogICAgICAgICBEYXR1bUJpcyAgICAgID0gU0ZQLkRhdHVtQmlzLA0KICAgICAgICAgU" +
                        "2hGcEJlbWVya3VuZyA9IFNGUC5CZW1lcmt1bmcsDQogICAgICAgICBKYWhyICAgICAgICAgID0gQkJHL" +
                        "kphaHIsDQogICAgICAgICBNb25hdCAgICAgICAgID0gQkJHLk1vbmF0LA0KICAgICAgICAgQmV6dWdzb" +
                        "W9uYXQgICA9IGRiby5mblhNb25hdChCQkcuTW9uYXQpICsgJyAnICsgU1RSKEJCRy5KYWhyLDQpLA0KI" +
                        "CAgICAgICAgQkJHLkJnQmV3aWxsaWd1bmdTdGF0dXNDb2RlLA0KICAgICAgICAgTWJTdGF0dXMgICAgI" +
                        "CA9IExWQi5UZXh0LA0KICAgICAgICAgRW1wbG95ZWVOYW1lICA9IFVTUi5MYXN0TmFtZStJU05VTEwoJ" +
                        "ywgJytVU1IuRmlyc3ROYW1lLCcnKStJU05VTEwoJyAoJytYT1IuSXRlbU5hbWUrJyknLCcnKStJU05VT" +
                        "EwoJywgVGVsLiAnK1VTUi5QaG9uZSwnJyksDQogICAgICAgICBBZHJlc3NlICAgICAgID0gaXNudWxsK" +
                        "GNhc2UgUFJTLkdlc2NobGVjaHRDb2RlIHdoZW4gMSB0aGVuICdIZXJyJyB3aGVuIDIgdGhlbiAnRnJhd" +
                        "ScgZW5kICsgY2hhcigxMykgKyBjaGFyKDEwKSwnJykgKw0KICAgICAgICAgICAgICAgICAgICAgIGlzb" +
                        "nVsbChQUlMuVm9ybmFtZSsnICcsJycpICsgUFJTLk5hbWUgKyBjaGFyKDEzKSArIGNoYXIoMTApICsNC" +
                        "iAgICAgICAgICAgICAgICAgICAgICBpc251bGwoQURSLlN0cmFzc2UgKyAnICcsJycpICsgaXNudWxsK" +
                        "EFEUi5IYXVzTnIsJycpICsgY2hhcigxMykgKyBjaGFyKDEwKSArDQogICAgICAgICAgICAgICAgICAgI" +
                        "CAgaXNudWxsKEFEUi5QTFogKyAnICcsJycpICsgaXNudWxsKEFEUi5PcnQsJycpDQpGUk9NIEJnUG9za" +
                        "XRpb24gUE9TDQpMRUZUIEpPSU4gQmdQb3NpdGlvbnNhcnQgQVJUIE9OIEFSVC5CZ1Bvc2l0aW9uc2Fyd" +
                        "ElEID0gUE9TLkJnUG9zaXRpb25zYXJ0SUQNCkxFRlQgSk9JTiBCZ0tvc3RlbmFydCBLU1QgT04gS1NUL" +
                        "kJnS29zdGVuYXJ0SUQgPSBBUlQuQmdLb3N0ZW5hcnRJRA0KTEVGVCBKT0lOIEJnU3BlemtvbnRvIFNQW" +
                        "iBPTiBTUFouQmdTcGV6a29udG9JRCA9IFBPUy5CZ1NwZXprb250b0lEDQpMRUZUIEpPSU4gQmdLb3N0Z" +
                        "W5hcnQgS1NUMSBPTiBLU1QxLkJnS29zdGVuYXJ0SUQgPSBTUFouQmdLb3N0ZW5hcnRJRA0KSU5ORVIgS" +
                        "k9JTiBCZ0J1ZGdldCAgICAgICAgQkJHIE9OIEJCRy5CZ0J1ZGdldElEID0gUE9TLkJnQnVkZ2V0SUQNC" +
                        "klOTkVSIEpPSU4gQmdGaW5hbnpwbGFuICAgIFNGUCBPTiBCQkcuQmdGaW5hbnpwbGFuSUQgPSBTRlAuQ" +
                        "mdGaW5hbnpwbGFuSUQNCklOTkVSIEpPSU4gRmFMZWlzdHVuZyAgICAgICBMRUkgT04gU0ZQLkZhTGVpc" +
                        "3R1bmdJRCA9IExFSS5GYUxlaXN0dW5nSUQNCklOTkVSIEpPSU4gQmFQZXJzb24gICAgICAgUFJTIE9OI" +
                        "ExFSS5CYVBlcnNvbklEID0gUFJTLkJhUGVyc29uSUQNCklOTkVSIEpPSU4gQmFBZHJlc3NlICAgICAgQ" +
                        "URSIG9uIEFEUi5CYUFkcmVzc2VJRD0oc2VsZWN0IE1BWChCYUFkcmVzc2VJRCkgZnJvbSBCYUFkcmVzc" +
                        "2Ugd2hlcmUgQmFQZXJzb25JRD1QUlMuQmFQZXJzb25JRCBhbmQgQWRyZXNzZUNvZGU9MSAvKndvaG5za" +
                        "XR6Ki8pDQpMRUZUICBKT0lOIFhMT1ZDb2RlICAgICAgICBMVlMgT04gTFZTLkNvZGUgPSBTRlAuQmdCZ" +
                        "XdpbGxpZ3VuZ1N0YXR1c0NvZGUgQU5EIExWUy5MT1ZOYW1lID0gJ0JnQmV3aWxsaWd1bmdTdGF0dXMnD" +
                        "QpMRUZUICBKT0lOIFhMT1ZDb2RlICAgICAgICBMVlQgT04gTFZULkNvZGUgPSBTRlAuV2hIaWxmZVR5c" +
                        "ENvZGUgQU5EIExWVC5MT1ZOYW1lID0gJ1doSGlsZmVUeXAnDQpMRUZUICBKT0lOIFhMT1ZDb2RlICAgI" +
                        "CAgICBMVkIgT04gTFZCLkNvZGUgPSBCQkcuQmdCZXdpbGxpZ3VuZ1N0YXR1c0NvZGUgQU5EIExWQi5MT" +
                        "1ZOYW1lID0gJ0JnQmV3aWxsaWd1bmdTdGF0dXMnDQpJTk5FUiBKT0lOIFhVc2VyICAgICAgICAgICBVU" +
                        "1IgT04gTEVJLlVzZXJJRCA9IFVTUi5Vc2VySUQNCkxFRlQgIEpPSU4gWE9yZ1VuaXRfVVNFUiAgIFhPV" +
                        "SBPTiBVU1IuVXNlcklEID0gWE9VLlVzZXJJRA0KLS1JTk5FUiBKT0lOIFhMT1ZDb2RlICAgICAgICBMV" +
                        "lUgT04gTFZVLkNvZGUgPSBYT1UuT3JnVW5pdE1lbWJlckNvZGUgQU5EIExWVS5MT1ZOYW1lID0gJ09yZ" +
                        "1VuaXRNZW1iZXInDQpJTk5FUiBKT0lOIFhPcmdVbml0ICAgICAgICBYT1IgT04gWE9VLk9yZ1VuaXRJR" +
                        "CA9IFhPUi5PcmdVbml0SUQNCldIRVJFIEJnUG9zaXRpb25JRCA9IG51bGwBzwFwcml2YXRlIHZvaWQgT" +
                        "25CZWZvcmVQcmludChvYmplY3Qgc2VuZGVyLCBTeXN0ZW0uRHJhd2luZy5QcmludGluZy5QcmludEV2Z" +
                        "W50QXJncyBlKSB7DQogIHBpT3JnT3J0RGF0dW0uRm9ybWF0ID0gcGlPcmdPcnREYXR1bS5Gb3JtYXQuU" +
                        "mVwbGFjZSgiPE9yZ09ydD4iLFJlcG9ydC5HZXRDdXJyZW50Q29sdW1uVmFsdWUoIk9yZ19PcnQiKS5Ub" +
                        "1N0cmluZygpKTsNCn1AAAEAAAD/////AQAAAAAAAAAMAgAAABtEZXZFeHByZXNzLlh0cmFSZXBvcnRzL" +
                        "nY2LjIFAQAAACxEZXZFeHByZXNzLlh0cmFSZXBvcnRzLlVJLlNlcmlhbGl6YWJsZVN0cmluZwEAAAAFV" +
                        "mFsdWUBAgAAAAYDAAAAyAV7XHJ0ZjFcYW5zaVxhbnNpY3BnMTI1MlxkZWZmMFxkZWZsYW5nMjA1NXtcZ" +
                        "m9udHRibHtcZjBcZm5pbFxmY2hhcnNldDAgVGFob21hO319DQpcdmlld2tpbmQ0XHVjMVxwYXJkXG5vd" +
                        "2lkY3RscGFyXGlcZjBcZnMyMCBHZWdlbiBkaWVzZSBWZXJmXCdmY2d1bmcga2FubiBpbm5lcnQgMzAgV" +
                        "GFnZW4gc2VpdCBkZXIgRXJcJ2Y2ZmZudW5nIGJlaW0genVzdFwnZTRuZGlnZW4gUmVnaWVydW5nc3N0Y" +
                        "XR0aGFsdGVyYW10IFZlcndhbHR1bmdzLWJlc2Nod2VyZGUgZ2VmXCdmY2hydCB3ZXJkZW4uIERpZSBCZ" +
                        "XNjaHdlcmRlIGlzdCBpbSBEb3BwZWwgZWluenVyZWljaGVuLCBtdXNzIGVpbmVuIEFudHJhZywgZGllI" +
                        "EFuZ2FiZW4gdm9uIFRhdHNhY2hlbiwgZWluZSBCZWdyXCdmY25kdW5nIHNvd2llIGVpbmUgVW50ZXJzY" +
                        "2hyaWZ0IGVudGhhbHRlbi4gQWxsZlwnZTRsbGlnZSBCZXdlaXNtaXR0ZWwgc2luZCBiZWl6dWxlZ2VuL" +
                        "iBccGFyDQpKZSBuYWNoIFdvaG5zaXR6IGlzdCBkaWUgQmVzY2h3ZXJkZSB6dSByaWNodGVuIGFuOlxwY" +
                        "XINCi0gR2VtZWluZGVuIFdvaGxlbiB1bmQgS2lyY2hsaW5kYWNoOyBSZWdpZXJ1bmdzc3RhdHRoYWx0Z" +
                        "XJhbXQgSUksIEFtdHNoYXVzLCBIb2RsZXJzdHIuIDcsIDMwMDEgQmVyblxwYXINClxwYXJkIC0gR2VtZ" +
                        "WluZGUgRnJhdWVua2FwcGVsZW47IFJlZ2llcnVuZ3NzdGF0dGhhbHRlcmFtdCwgMzE3NyBMYXVwZW4uX" +
                        "HBhcg0KfQ0KCw==";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ShEsilVerfuegung_Unterst = new DevExpress.XtraReports.UI.Subreport();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageBreak1 = new DevExpress.XtraReports.UI.XRPageBreak();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrRichTextBox2 = new DevExpress.XtraReports.UI.XRRichTextBox();
            this.piOrgOrtDatum = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.txtEmployeeName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBezugsmonat = new DevExpress.XtraReports.UI.XRLabel();
            this.txtMbStatus = new DevExpress.XtraReports.UI.XRLabel();
            this.txtDatumBis = new DevExpress.XtraReports.UI.XRLabel();
            this.txtDatumVon = new DevExpress.XtraReports.UI.XRLabel();
            this.txtFpTyp = new DevExpress.XtraReports.UI.XRLabel();
            this.Label11 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label10 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label9 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtFpStatus = new DevExpress.XtraReports.UI.XRLabel();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKlientName = new DevExpress.XtraReports.UI.XRLabel();
            this.Label5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.OrgPLZOrt = new DevExpress.XtraReports.UI.XRLabel();
            this.OrgAdresse = new DevExpress.XtraReports.UI.XRLabel();
            this.OrgName = new DevExpress.XtraReports.UI.XRLabel();
            this.Label12 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel16,
                        this.xrLabel15,
                        this.xrLabel14,
                        this.xrLabel13,
                        this.xrLabel12,
                        this.xrLabel9,
                        this.xrLabel5,
                        this.xrLabel3,
                        this.xrLabel2,
                        this.xrLabel4,
                        this.xrLabel1,
                        this.ShEsilVerfuegung_Unterst});
            this.Detail.Height = 216;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBackColor = false;
            this.Detail.ParentStyleUsing.UseBorderColor = false;
            this.Detail.ParentStyleUsing.UseBorders = false;
            this.Detail.ParentStyleUsing.UseBorderWidth = false;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel21,
                        this.xrLabel20,
                        this.xrPageBreak1,
                        this.xrLabel17,
                        this.xrRichTextBox2,
                        this.piOrgOrtDatum,
                        this.xrLabel11,
                        this.xrLabel10,
                        this.xrLabel8,
                        this.xrLabel7,
                        this.xrLabel6});
            this.ReportFooter.Height = 694;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLine1,
                        this.xrPageInfo1,
                        this.txtEmployeeName,
                        this.txtBezugsmonat,
                        this.txtMbStatus,
                        this.txtDatumBis,
                        this.txtDatumVon,
                        this.txtFpTyp,
                        this.Label11,
                        this.Label10,
                        this.Label9,
                        this.Label8,
                        this.Label7,
                        this.txtFpStatus,
                        this.Label6,
                        this.txtKlientName,
                        this.Label5,
                        this.Label4,
                        this.OrgPLZOrt,
                        this.OrgAdresse,
                        this.OrgName,
                        this.Label12});
            this.ReportHeader.Height = 292;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel16
            // 
            this.xrLabel16.CanGrow = false;
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bemerkung", "")});
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel16.ForeColor = System.Drawing.Color.Black;
            this.xrLabel16.Location = new System.Drawing.Point(117, 183);
            this.xrLabel16.Multiline = true;
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.ParentStyleUsing.UseBackColor = false;
            this.xrLabel16.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel16.ParentStyleUsing.UseBorders = false;
            this.xrLabel16.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel16.ParentStyleUsing.UseFont = false;
            this.xrLabel16.ParentStyleUsing.UseForeColor = false;
            this.xrLabel16.Size = new System.Drawing.Size(591, 19);
            this.xrLabel16.Text = "xrLabel16";
            // 
            // xrLabel15
            // 
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel15.ForeColor = System.Drawing.Color.Black;
            this.xrLabel15.Location = new System.Drawing.Point(0, 184);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.ParentStyleUsing.UseBackColor = false;
            this.xrLabel15.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel15.ParentStyleUsing.UseBorders = false;
            this.xrLabel15.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel15.ParentStyleUsing.UseFont = false;
            this.xrLabel15.ParentStyleUsing.UseForeColor = false;
            this.xrLabel15.Size = new System.Drawing.Size(94, 19);
            this.xrLabel15.Text = "Bemerkung";
            // 
            // xrLabel14
            // 
            this.xrLabel14.CanGrow = false;
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BgPositionID", "")});
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.ForeColor = System.Drawing.Color.Black;
            this.xrLabel14.Location = new System.Drawing.Point(117, 158);
            this.xrLabel14.Multiline = true;
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.ParentStyleUsing.UseBackColor = false;
            this.xrLabel14.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel14.ParentStyleUsing.UseBorders = false;
            this.xrLabel14.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel14.ParentStyleUsing.UseFont = false;
            this.xrLabel14.ParentStyleUsing.UseForeColor = false;
            this.xrLabel14.Size = new System.Drawing.Size(100, 19);
            this.xrLabel14.Text = "xrLabel14";
            // 
            // xrLabel13
            // 
            this.xrLabel13.CanGrow = false;
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameEinzelzahlung", "")});
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.ForeColor = System.Drawing.Color.Black;
            this.xrLabel13.Location = new System.Drawing.Point(117, 83);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.ParentStyleUsing.UseBackColor = false;
            this.xrLabel13.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel13.ParentStyleUsing.UseBorders = false;
            this.xrLabel13.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel13.ParentStyleUsing.UseFont = false;
            this.xrLabel13.ParentStyleUsing.UseForeColor = false;
            this.xrLabel13.Size = new System.Drawing.Size(591, 19);
            this.xrLabel13.Text = "Beschreibung";
            this.xrLabel13.WordWrap = false;
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel12.ForeColor = System.Drawing.Color.Black;
            this.xrLabel12.Location = new System.Drawing.Point(117, 108);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.ParentStyleUsing.UseBackColor = false;
            this.xrLabel12.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel12.ParentStyleUsing.UseBorders = false;
            this.xrLabel12.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel12.ParentStyleUsing.UseFont = false;
            this.xrLabel12.ParentStyleUsing.UseForeColor = false;
            this.xrLabel12.Size = new System.Drawing.Size(100, 19);
            this.xrLabel12.Text = "Betrag";
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Kostenart", "")});
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel9.ForeColor = System.Drawing.Color.Black;
            this.xrLabel9.Location = new System.Drawing.Point(117, 133);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.ParentStyleUsing.UseBackColor = false;
            this.xrLabel9.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel9.ParentStyleUsing.UseBorders = false;
            this.xrLabel9.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.ParentStyleUsing.UseForeColor = false;
            this.xrLabel9.Size = new System.Drawing.Size(591, 19);
            this.xrLabel9.Text = "Valuta";
            this.xrLabel9.WordWrap = false;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel5.ForeColor = System.Drawing.Color.Black;
            this.xrLabel5.Location = new System.Drawing.Point(0, 108);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseBackColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorders = false;
            this.xrLabel5.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.ParentStyleUsing.UseForeColor = false;
            this.xrLabel5.Size = new System.Drawing.Size(100, 19);
            this.xrLabel5.Text = "Betrag CHF";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(0, 133);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(100, 19);
            this.xrLabel3.Text = "Kostenart";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.Location = new System.Drawing.Point(0, 50);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseBackColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorders = false;
            this.xrLabel2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.ParentStyleUsing.UseForeColor = false;
            this.xrLabel2.Size = new System.Drawing.Size(92, 19);
            this.xrLabel2.Text = "Leistung";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.Location = new System.Drawing.Point(0, 83);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.ParentStyleUsing.UseForeColor = false;
            this.xrLabel4.Size = new System.Drawing.Size(100, 19);
            this.xrLabel4.Text = "Beschreibung";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.Location = new System.Drawing.Point(0, 158);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseBackColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.ParentStyleUsing.UseForeColor = false;
            this.xrLabel1.Size = new System.Drawing.Size(94, 19);
            this.xrLabel1.Text = "Pos-ID";
            // 
            // ShEsilVerfuegung_Unterst
            // 
            this.ShEsilVerfuegung_Unterst.Location = new System.Drawing.Point(0, 0);
            this.ShEsilVerfuegung_Unterst.Name = "ShEsilVerfuegung_Unterst";
            // 
            // xrLabel21
            // 
            this.xrLabel21.CanGrow = false;
            this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Adresse", "")});
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 11F);
            this.xrLabel21.ForeColor = System.Drawing.Color.Black;
            this.xrLabel21.Location = new System.Drawing.Point(0, 602);
            this.xrLabel21.Multiline = true;
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.ParentStyleUsing.UseBackColor = false;
            this.xrLabel21.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel21.ParentStyleUsing.UseBorders = false;
            this.xrLabel21.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel21.ParentStyleUsing.UseFont = false;
            this.xrLabel21.ParentStyleUsing.UseForeColor = false;
            this.xrLabel21.Size = new System.Drawing.Size(358, 92);
            this.xrLabel21.Text = "Anrede";
            // 
            // xrLabel20
            // 
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.xrLabel20.Location = new System.Drawing.Point(0, 569);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.ParentStyleUsing.UseFont = false;
            this.xrLabel20.Size = new System.Drawing.Size(208, 26);
            this.xrLabel20.Text = "Einschreiben";
            this.xrLabel20.Visible = false;
            // 
            // xrPageBreak1
            // 
            this.xrPageBreak1.Location = new System.Drawing.Point(0, 402);
            this.xrPageBreak1.Name = "xrPageBreak1";
            // 
            // xrLabel17
            // 
            this.xrLabel17.Font = new System.Drawing.Font("Tahoma", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.xrLabel17.ForeColor = System.Drawing.Color.Black;
            this.xrLabel17.Location = new System.Drawing.Point(0, 267);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.ParentStyleUsing.UseBackColor = false;
            this.xrLabel17.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel17.ParentStyleUsing.UseBorders = false;
            this.xrLabel17.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel17.ParentStyleUsing.UseFont = false;
            this.xrLabel17.ParentStyleUsing.UseForeColor = false;
            this.xrLabel17.Size = new System.Drawing.Size(228, 20);
            this.xrLabel17.Text = "Rechtsmittelbelehrung";
            // 
            // xrRichTextBox2
            // 
            this.xrRichTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.xrRichTextBox2.BorderColor = System.Drawing.Color.Transparent;
            this.xrRichTextBox2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrRichTextBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrRichTextBox2.Location = new System.Drawing.Point(0, 292);
            this.xrRichTextBox2.Name = "xrRichTextBox2";
            this.xrRichTextBox2.ParentStyleUsing.UseBackColor = false;
            this.xrRichTextBox2.ParentStyleUsing.UseBorderColor = false;
            this.xrRichTextBox2.ParentStyleUsing.UseBorders = false;
            this.xrRichTextBox2.ParentStyleUsing.UseFont = false;
            this.xrRichTextBox2.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichTextBox2.RtfText")));
            this.xrRichTextBox2.Size = new System.Drawing.Size(709, 108);
            // 
            // piOrgOrtDatum
            // 
            this.piOrgOrtDatum.Font = new System.Drawing.Font("Arial", 9.75F);
            this.piOrgOrtDatum.Format = "Wohlen,";
            this.piOrgOrtDatum.Location = new System.Drawing.Point(0, 142);
            this.piOrgOrtDatum.Name = "piOrgOrtDatum";
            this.piOrgOrtDatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.piOrgOrtDatum.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.piOrgOrtDatum.ParentStyleUsing.UseFont = false;
            this.piOrgOrtDatum.Scripts.OnBeforePrint = resources.GetString("piOrgOrtDatum.Scripts.OnBeforePrint");
            this.piOrgOrtDatum.Size = new System.Drawing.Size(259, 20);
            // 
            // xrLabel11
            // 
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel11.ForeColor = System.Drawing.Color.Black;
            this.xrLabel11.Location = new System.Drawing.Point(542, 200);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.ParentStyleUsing.UseBackColor = false;
            this.xrLabel11.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel11.ParentStyleUsing.UseBorders = false;
            this.xrLabel11.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel11.ParentStyleUsing.UseFont = false;
            this.xrLabel11.ParentStyleUsing.UseForeColor = false;
            this.xrLabel11.Size = new System.Drawing.Size(167, 42);
            this.xrLabel11.Text = "Brigitte Ryter\r\nKoordination Sozialarbeit";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel10.ForeColor = System.Drawing.Color.Black;
            this.xrLabel10.Location = new System.Drawing.Point(367, 200);
            this.xrLabel10.Multiline = true;
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.ParentStyleUsing.UseBackColor = false;
            this.xrLabel10.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel10.ParentStyleUsing.UseBorders = false;
            this.xrLabel10.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel10.ParentStyleUsing.UseFont = false;
            this.xrLabel10.ParentStyleUsing.UseForeColor = false;
            this.xrLabel10.Size = new System.Drawing.Size(158, 42);
            this.xrLabel10.Text = "Sandro Stettler\r\nLeiter Soziale Dienste";
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel8.ForeColor = System.Drawing.Color.Black;
            this.xrLabel8.Location = new System.Drawing.Point(367, 108);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseBackColor = false;
            this.xrLabel8.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel8.ParentStyleUsing.UseBorders = false;
            this.xrLabel8.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.ParentStyleUsing.UseForeColor = false;
            this.xrLabel8.Size = new System.Drawing.Size(241, 19);
            this.xrLabel8.Text = "Ausschuss individuelle Sozialhilfe";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel7.ForeColor = System.Drawing.Color.Black;
            this.xrLabel7.Location = new System.Drawing.Point(0, 58);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseBackColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorders = false;
            this.xrLabel7.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.ParentStyleUsing.UseForeColor = false;
            this.xrLabel7.Size = new System.Drawing.Size(433, 19);
            this.xrLabel7.Text = "Die beantragte einmalige situationsbedingte Leistung wird genehmigt";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.xrLabel6.ForeColor = System.Drawing.Color.Black;
            this.xrLabel6.Location = new System.Drawing.Point(0, 33);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseBackColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorders = false;
            this.xrLabel6.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.ParentStyleUsing.UseForeColor = false;
            this.xrLabel6.Size = new System.Drawing.Size(157, 19);
            this.xrLabel6.Text = "Beschluss";
            // 
            // xrLine1
            // 
            this.xrLine1.Location = new System.Drawing.Point(0, 66);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(708, 8);
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrPageInfo1.Format = "{0:dd.MM.yyyy}";
            this.xrPageInfo1.Location = new System.Drawing.Point(542, 4);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Scripts.OnBeforePrint = resources.GetString("xrPageInfo1.Scripts.OnBeforePrint");
            this.xrPageInfo1.Size = new System.Drawing.Size(158, 20);
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "EmployeeName", "")});
            this.txtEmployeeName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtEmployeeName.ForeColor = System.Drawing.Color.Black;
            this.txtEmployeeName.Location = new System.Drawing.Point(183, 262);
            this.txtEmployeeName.Multiline = true;
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtEmployeeName.ParentStyleUsing.UseBackColor = false;
            this.txtEmployeeName.ParentStyleUsing.UseBorderColor = false;
            this.txtEmployeeName.ParentStyleUsing.UseBorders = false;
            this.txtEmployeeName.ParentStyleUsing.UseBorderWidth = false;
            this.txtEmployeeName.ParentStyleUsing.UseFont = false;
            this.txtEmployeeName.ParentStyleUsing.UseForeColor = false;
            this.txtEmployeeName.Size = new System.Drawing.Size(511, 19);
            this.txtEmployeeName.Text = "EmployeeName";
            // 
            // txtBezugsmonat
            // 
            this.txtBezugsmonat.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bezugsmonat", "")});
            this.txtBezugsmonat.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBezugsmonat.ForeColor = System.Drawing.Color.Black;
            this.txtBezugsmonat.Location = new System.Drawing.Point(183, 247);
            this.txtBezugsmonat.Multiline = true;
            this.txtBezugsmonat.Name = "txtBezugsmonat";
            this.txtBezugsmonat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBezugsmonat.ParentStyleUsing.UseBackColor = false;
            this.txtBezugsmonat.ParentStyleUsing.UseBorderColor = false;
            this.txtBezugsmonat.ParentStyleUsing.UseBorders = false;
            this.txtBezugsmonat.ParentStyleUsing.UseBorderWidth = false;
            this.txtBezugsmonat.ParentStyleUsing.UseFont = false;
            this.txtBezugsmonat.ParentStyleUsing.UseForeColor = false;
            this.txtBezugsmonat.Size = new System.Drawing.Size(511, 19);
            this.txtBezugsmonat.Text = "Bezugsmonat";
            // 
            // txtMbStatus
            // 
            this.txtMbStatus.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "MbStatus", "")});
            this.txtMbStatus.Font = new System.Drawing.Font("Arial", 10F);
            this.txtMbStatus.ForeColor = System.Drawing.Color.Black;
            this.txtMbStatus.Location = new System.Drawing.Point(183, 232);
            this.txtMbStatus.Multiline = true;
            this.txtMbStatus.Name = "txtMbStatus";
            this.txtMbStatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtMbStatus.ParentStyleUsing.UseBackColor = false;
            this.txtMbStatus.ParentStyleUsing.UseBorderColor = false;
            this.txtMbStatus.ParentStyleUsing.UseBorders = false;
            this.txtMbStatus.ParentStyleUsing.UseBorderWidth = false;
            this.txtMbStatus.ParentStyleUsing.UseFont = false;
            this.txtMbStatus.ParentStyleUsing.UseForeColor = false;
            this.txtMbStatus.Size = new System.Drawing.Size(511, 19);
            this.txtMbStatus.Text = "MbStatus";
            // 
            // txtDatumBis
            // 
            this.txtDatumBis.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "DatumBis", "{0:dd.MM.yyyy}")});
            this.txtDatumBis.Font = new System.Drawing.Font("Arial", 10F);
            this.txtDatumBis.ForeColor = System.Drawing.Color.Black;
            this.txtDatumBis.Location = new System.Drawing.Point(286, 217);
            this.txtDatumBis.Multiline = true;
            this.txtDatumBis.Name = "txtDatumBis";
            this.txtDatumBis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtDatumBis.ParentStyleUsing.UseBackColor = false;
            this.txtDatumBis.ParentStyleUsing.UseBorderColor = false;
            this.txtDatumBis.ParentStyleUsing.UseBorders = false;
            this.txtDatumBis.ParentStyleUsing.UseBorderWidth = false;
            this.txtDatumBis.ParentStyleUsing.UseFont = false;
            this.txtDatumBis.ParentStyleUsing.UseForeColor = false;
            this.txtDatumBis.Size = new System.Drawing.Size(78, 19);
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
            this.txtDatumVon.Location = new System.Drawing.Point(183, 217);
            this.txtDatumVon.Multiline = true;
            this.txtDatumVon.Name = "txtDatumVon";
            this.txtDatumVon.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtDatumVon.ParentStyleUsing.UseBackColor = false;
            this.txtDatumVon.ParentStyleUsing.UseBorderColor = false;
            this.txtDatumVon.ParentStyleUsing.UseBorders = false;
            this.txtDatumVon.ParentStyleUsing.UseBorderWidth = false;
            this.txtDatumVon.ParentStyleUsing.UseFont = false;
            this.txtDatumVon.ParentStyleUsing.UseForeColor = false;
            this.txtDatumVon.Size = new System.Drawing.Size(78, 19);
            xrSummary2.FormatString = "{0:dd.MM.yyyy}";
            this.txtDatumVon.Summary = xrSummary2;
            this.txtDatumVon.Text = "DatumVon";
            // 
            // txtFpTyp
            // 
            this.txtFpTyp.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "FpTyp", "")});
            this.txtFpTyp.Font = new System.Drawing.Font("Arial", 10F);
            this.txtFpTyp.ForeColor = System.Drawing.Color.Black;
            this.txtFpTyp.Location = new System.Drawing.Point(183, 202);
            this.txtFpTyp.Multiline = true;
            this.txtFpTyp.Name = "txtFpTyp";
            this.txtFpTyp.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtFpTyp.ParentStyleUsing.UseBackColor = false;
            this.txtFpTyp.ParentStyleUsing.UseBorderColor = false;
            this.txtFpTyp.ParentStyleUsing.UseBorders = false;
            this.txtFpTyp.ParentStyleUsing.UseBorderWidth = false;
            this.txtFpTyp.ParentStyleUsing.UseFont = false;
            this.txtFpTyp.ParentStyleUsing.UseForeColor = false;
            this.txtFpTyp.Size = new System.Drawing.Size(511, 19);
            this.txtFpTyp.Text = "FpTyp";
            // 
            // Label11
            // 
            this.Label11.Font = new System.Drawing.Font("Arial", 10F);
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(0, 262);
            this.Label11.Name = "Label11";
            this.Label11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label11.ParentStyleUsing.UseBackColor = false;
            this.Label11.ParentStyleUsing.UseBorderColor = false;
            this.Label11.ParentStyleUsing.UseBorders = false;
            this.Label11.ParentStyleUsing.UseBorderWidth = false;
            this.Label11.ParentStyleUsing.UseFont = false;
            this.Label11.ParentStyleUsing.UseForeColor = false;
            this.Label11.Size = new System.Drawing.Size(173, 19);
            this.Label11.Text = "Zuständiger Sozialarbeiter";
            // 
            // Label10
            // 
            this.Label10.Font = new System.Drawing.Font("Arial", 10F);
            this.Label10.ForeColor = System.Drawing.Color.Black;
            this.Label10.Location = new System.Drawing.Point(0, 247);
            this.Label10.Name = "Label10";
            this.Label10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label10.ParentStyleUsing.UseBackColor = false;
            this.Label10.ParentStyleUsing.UseBorderColor = false;
            this.Label10.ParentStyleUsing.UseBorders = false;
            this.Label10.ParentStyleUsing.UseBorderWidth = false;
            this.Label10.ParentStyleUsing.UseFont = false;
            this.Label10.ParentStyleUsing.UseForeColor = false;
            this.Label10.Size = new System.Drawing.Size(173, 19);
            this.Label10.Text = "Bezugsmonat";
            // 
            // Label9
            // 
            this.Label9.Font = new System.Drawing.Font("Arial", 10F);
            this.Label9.ForeColor = System.Drawing.Color.Black;
            this.Label9.Location = new System.Drawing.Point(0, 232);
            this.Label9.Name = "Label9";
            this.Label9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label9.ParentStyleUsing.UseBackColor = false;
            this.Label9.ParentStyleUsing.UseBorderColor = false;
            this.Label9.ParentStyleUsing.UseBorders = false;
            this.Label9.ParentStyleUsing.UseBorderWidth = false;
            this.Label9.ParentStyleUsing.UseFont = false;
            this.Label9.ParentStyleUsing.UseForeColor = false;
            this.Label9.Size = new System.Drawing.Size(173, 19);
            this.Label9.Text = "Status Monatsbudget";
            // 
            // Label8
            // 
            this.Label8.Font = new System.Drawing.Font("Arial", 10F);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(0, 217);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(173, 19);
            this.Label8.Text = "Gültig von";
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Arial", 10F);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(0, 202);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(173, 19);
            this.Label7.Text = "Typ Finanzplan";
            // 
            // txtFpStatus
            // 
            this.txtFpStatus.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "FpStatus", "")});
            this.txtFpStatus.Font = new System.Drawing.Font("Arial", 10F);
            this.txtFpStatus.ForeColor = System.Drawing.Color.Black;
            this.txtFpStatus.Location = new System.Drawing.Point(183, 188);
            this.txtFpStatus.Multiline = true;
            this.txtFpStatus.Name = "txtFpStatus";
            this.txtFpStatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtFpStatus.ParentStyleUsing.UseBackColor = false;
            this.txtFpStatus.ParentStyleUsing.UseBorderColor = false;
            this.txtFpStatus.ParentStyleUsing.UseBorders = false;
            this.txtFpStatus.ParentStyleUsing.UseBorderWidth = false;
            this.txtFpStatus.ParentStyleUsing.UseFont = false;
            this.txtFpStatus.ParentStyleUsing.UseForeColor = false;
            this.txtFpStatus.Size = new System.Drawing.Size(511, 19);
            this.txtFpStatus.Text = "FpStatus";
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 10F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(0, 188);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(173, 19);
            this.Label6.Text = "Status Finanzplan";
            // 
            // txtKlientName
            // 
            this.txtKlientName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KlientName", "")});
            this.txtKlientName.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.txtKlientName.ForeColor = System.Drawing.Color.Black;
            this.txtKlientName.Location = new System.Drawing.Point(118, 154);
            this.txtKlientName.Multiline = true;
            this.txtKlientName.Name = "txtKlientName";
            this.txtKlientName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKlientName.ParentStyleUsing.UseBackColor = false;
            this.txtKlientName.ParentStyleUsing.UseBorderColor = false;
            this.txtKlientName.ParentStyleUsing.UseBorders = false;
            this.txtKlientName.ParentStyleUsing.UseBorderWidth = false;
            this.txtKlientName.ParentStyleUsing.UseFont = false;
            this.txtKlientName.ParentStyleUsing.UseForeColor = false;
            this.txtKlientName.Size = new System.Drawing.Size(590, 19);
            this.txtKlientName.Text = "KlientName";
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(0, 154);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(118, 19);
            this.Label5.Text = "Klient/Klientin";
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(0, 112);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(708, 23);
            this.Label4.Text = "Verfügung: Einmalige situationsbedingte Leistung";
            // 
            // OrgPLZOrt
            // 
            this.OrgPLZOrt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_PLZOrt", "")});
            this.OrgPLZOrt.Font = new System.Drawing.Font("Arial", 10F);
            this.OrgPLZOrt.ForeColor = System.Drawing.Color.Black;
            this.OrgPLZOrt.Location = new System.Drawing.Point(0, 46);
            this.OrgPLZOrt.Name = "OrgPLZOrt";
            this.OrgPLZOrt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.OrgPLZOrt.ParentStyleUsing.UseBackColor = false;
            this.OrgPLZOrt.ParentStyleUsing.UseBorderColor = false;
            this.OrgPLZOrt.ParentStyleUsing.UseBorders = false;
            this.OrgPLZOrt.ParentStyleUsing.UseBorderWidth = false;
            this.OrgPLZOrt.ParentStyleUsing.UseFont = false;
            this.OrgPLZOrt.ParentStyleUsing.UseForeColor = false;
            this.OrgPLZOrt.Size = new System.Drawing.Size(181, 18);
            this.OrgPLZOrt.Text = "<OrgPlzOrt>";
            // 
            // OrgAdresse
            // 
            this.OrgAdresse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Adresse", "")});
            this.OrgAdresse.Font = new System.Drawing.Font("Arial", 10F);
            this.OrgAdresse.ForeColor = System.Drawing.Color.Black;
            this.OrgAdresse.Location = new System.Drawing.Point(0, 24);
            this.OrgAdresse.Name = "OrgAdresse";
            this.OrgAdresse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.OrgAdresse.ParentStyleUsing.UseBackColor = false;
            this.OrgAdresse.ParentStyleUsing.UseBorderColor = false;
            this.OrgAdresse.ParentStyleUsing.UseBorders = false;
            this.OrgAdresse.ParentStyleUsing.UseBorderWidth = false;
            this.OrgAdresse.ParentStyleUsing.UseFont = false;
            this.OrgAdresse.ParentStyleUsing.UseForeColor = false;
            this.OrgAdresse.Size = new System.Drawing.Size(181, 18);
            this.OrgAdresse.Text = "<OrgAdresse>";
            // 
            // OrgName
            // 
            this.OrgName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Name", "")});
            this.OrgName.Font = new System.Drawing.Font("Arial Black", 10F);
            this.OrgName.ForeColor = System.Drawing.Color.Black;
            this.OrgName.Location = new System.Drawing.Point(0, 4);
            this.OrgName.Name = "OrgName";
            this.OrgName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.OrgName.ParentStyleUsing.UseBackColor = false;
            this.OrgName.ParentStyleUsing.UseBorderColor = false;
            this.OrgName.ParentStyleUsing.UseBorders = false;
            this.OrgName.ParentStyleUsing.UseBorderWidth = false;
            this.OrgName.ParentStyleUsing.UseFont = false;
            this.OrgName.ParentStyleUsing.UseForeColor = false;
            this.OrgName.Size = new System.Drawing.Size(342, 20);
            this.OrgName.Text = "<OrgName>";
            // 
            // Label12
            // 
            this.Label12.Font = new System.Drawing.Font("Arial", 10F);
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(258, 217);
            this.Label12.Name = "Label12";
            this.Label12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label12.ParentStyleUsing.UseBackColor = false;
            this.Label12.ParentStyleUsing.UseBorderColor = false;
            this.Label12.ParentStyleUsing.UseBorders = false;
            this.Label12.ParentStyleUsing.UseBorderWidth = false;
            this.Label12.ParentStyleUsing.UseFont = false;
            this.Label12.ParentStyleUsing.UseForeColor = false;
            this.Label12.Size = new System.Drawing.Size(27, 19);
            this.Label12.Text = "bis";
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail,
                        this.ReportFooter,
                        this.ReportHeader});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(60, 10, 39, 39);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ScriptReferencesString = "System.Windows.Forms.dll";
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' ,  N'<?xml version="1.0" standalone="yes"?>
<NewDataSet>
    <Table>
        <FieldName>label</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Einzelzahlung ID:</DisplayText>
        <TabPosition>0</TabPosition>
        <X>10</X>
        <Y>60</Y>
        <Width>80</Width>
        <Height>25</Height>
        <Length>7</Length>
        <LOVName>
        </LOVName>
        <DefaultValue>
        </DefaultValue>
        <Mandatory>false</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>BgPositionID</FieldName>
        <FieldCode>4</FieldCode>
        <DisplayText>Position ID</DisplayText>
        <TabPosition>1</TabPosition>
        <X>240</X>
        <Y>60</Y>
        <Width>80</Width>
        <Height>25</Height>
        <Length>7</Length>
        <LOVName>
        </LOVName>
        <DefaultValue>
        </DefaultValue>
        <Mandatory>true</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
    </Table>
</NewDataSet>' ,  N'SELECT TOP 1
         POS.BgPositionID,
         POS.Betrag,
         NameEinzelzahlung = POS.Buchungstext,
         POS.Bemerkung,
         Kostenart     = ISNULL(KST.Name, ISNULL(KST1.Name, '''')),
         Org_Name      = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Organisation'', Getdate())), ''''),
         Org_Adresse   = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Adresse'', Getdate())), ''''),
         Org_PLZ       = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', Getdate())), ''''),
         Org_Ort       = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', Getdate())), ''''),
         Org_PLZOrt    = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', Getdate())) + '' '', '''') +
                         IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', Getdate())), ''''),
         KlientName    = PRS.Name + '', '' + PRS.Vorname + IsNull('' '' + PRS.Vorname2, ''''),
         FpStatus      = LVS.Text,
         FpTyp         = LVT.Text,
         IsUrgent      = LVT.Value2, -- 2.0 DB: IsUrgent
         GeplantVon    = SFP.GeplantVon,
         GeplantBis    = SFP.GeplantBis,
         DatumVon      = SFP.DatumVon,
         DatumBis      = SFP.DatumBis,
         ShFpBemerkung = SFP.Bemerkung,
         Jahr          = BBG.Jahr,
         Monat         = BBG.Monat,
         Bezugsmonat   = dbo.fnXMonat(BBG.Monat) + '' '' + STR(BBG.Jahr,4),
         BBG.BgBewilligungStatusCode,
         MbStatus      = LVB.Text,
         EmployeeName  = USR.LastName+ISNULL('', ''+USR.FirstName,'''')+ISNULL('' (''+XOR.ItemName+'')'','''')+ISNULL('', Tel. ''+USR.Phone,''''),
         Adresse       = isnull(case PRS.GeschlechtCode when 1 then ''Herr'' when 2 then ''Frau'' end + char(13) + char(10),'''') +
                      isnull(PRS.Vorname+'' '','''') + PRS.Name + char(13) + char(10) +
                      isnull(ADR.Strasse + '' '','''') + isnull(ADR.HausNr,'''') + char(13) + char(10) +
                      isnull(ADR.PLZ + '' '','''') + isnull(ADR.Ort,'''')
FROM BgPosition POS
LEFT JOIN BgPositionsart ART ON ART.BgPositionsartID = POS.BgPositionsartID
LEFT JOIN BgKostenart KST ON KST.BgKostenartID = ART.BgKostenartID
LEFT JOIN BgSpezkonto SPZ ON SPZ.BgSpezkontoID = POS.BgSpezkontoID
LEFT JOIN BgKostenart KST1 ON KST1.BgKostenartID = SPZ.BgKostenartID
INNER JOIN BgBudget        BBG ON BBG.BgBudgetID = POS.BgBudgetID
INNER JOIN BgFinanzplan    SFP ON BBG.BgFinanzplanID = SFP.BgFinanzplanID
INNER JOIN FaLeistung       LEI ON SFP.FaLeistungID = LEI.FaLeistungID
INNER JOIN BaPerson       PRS ON LEI.BaPersonID = PRS.BaPersonID
INNER JOIN BaAdresse      ADR on ADR.BaAdresseID=(select MAX(BaAdresseID) from BaAdresse where BaPersonID=PRS.BaPersonID and AdresseCode=1 /*wohnsitz*/)
LEFT  JOIN XLOVCode        LVS ON LVS.Code = SFP.BgBewilligungStatusCode AND LVS.LOVName = ''BgBewilligungStatus''
LEFT  JOIN XLOVCode        LVT ON LVT.Code = SFP.WhHilfeTypCode AND LVT.LOVName = ''WhHilfeTyp''
LEFT  JOIN XLOVCode        LVB ON LVB.Code = BBG.BgBewilligungStatusCode AND LVB.LOVName = ''BgBewilligungStatus''
INNER JOIN XUser           USR ON LEI.UserID = USR.UserID
LEFT  JOIN XOrgUnit_USER   XOU ON USR.UserID = XOU.UserID
--INNER JOIN XLOVCode        LVU ON LVU.Code = XOU.OrgUnitMemberCode AND LVU.LOVName = ''OrgUnitMember''
INNER JOIN XOrgUnit        XOR ON XOU.OrgUnitID = XOR.OrgUnitID
WHERE BgPositionID = {BgPositionID}' ,  N'FrmWhEinzelzahlungen' ,  null , 10)

INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShEsilVerfuegung_Unterst' ,  N'ESIL Verfügung - Unterst' , 1,  N'/// <XRTypeInfo>
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
        private DevExpress.XtraReports.UI.XRLabel txtBank;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtHeimatort;
        private DevExpress.XtraReports.UI.XRLabel txtAHV;
        private DevExpress.XtraReports.UI.XRLabel txtName;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel Label4;
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
                    string resourceString = @"zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJzaW9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4OSNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kAAAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAAAAAAbAEU0VMRUNUDQogIE5hbWUgICAgICAgPSBQUlMuTmFtZSArICcsICcgKyBQUlMuVm9ybmFtZSwNCiAgQUhWICAgICAgICA9IElzTnVsbChQUlMuQUhWTnVtbWVyLCcnKSwNCiAgSGVpbWF0b3J0ICA9IFBSUy5IZWltYXRvcnQsDQogIFphaGx1bmdzd2VnID0gS1JELlphaGx1bmdzd2VnDQoNCkZST00gQmdQb3NpdGlvbiBQT1MNCiAgSU5ORVIgSk9JTiBCZ0J1ZGdldCAgICAgICAgICAgICAgICBCQkcgT04gQkJHLkJnQnVkZ2V0SUQgPSBQT1MuQmdCdWRnZXRJRA0KICBJTk5FUiBKT0lOIEJnRmluYW56cGxhbl9CYVBlcnNvbiAgIFNQUCBPTiBTUFAuQmdGaW5hbnpwbGFuSUQgPSBCQkcuQmdGaW5hbnpwbGFuSUQNCiAgSU5ORVIgSk9JTiB2d1BlcnNvbiAgICAgICAgICAgICAgICBQUlMgT04gUFJTLkJhUGVyc29uSUQgPSBTUFAuQmFQZXJzb25JRA0KICBMRUZUICBKT0lOIHZ3a3JlZGl0b3IgICAgICAgICAgICAgIEtSRCBPTiBLUkQuQmFQZXJzb25JRCA9IFNQUC5CYVBlcnNvbklEDQpXSEVSRSBTUFAuSXN0VW50ZXJzdHVldHp0ID0gMQ0KICBBTkQgUE9TLkJnUG9zaXRpb25JRCA9IG51bGw=";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.txtBank = new DevExpress.XtraReports.UI.XRLabel();
            this.txtHeimatort = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAHV = new DevExpress.XtraReports.UI.XRLabel();
            this.txtName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
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
                        this.txtBank,
                        this.txtHeimatort,
                        this.txtAHV,
                        this.txtName});
            this.Detail.Height = 16;
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
                        this.xrLine1,
                        this.xrLabel1,
                        this.Label4,
                        this.Label3,
                        this.Label2,
                        this.Label1});
            this.ReportHeader.Height = 51;
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
            this.ReportFooter.Height = 9;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
            this.ReportFooter.Visible = false;
            // 
            // txtBank
            // 
            this.txtBank.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Zahlungsweg", "")});
            this.txtBank.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBank.ForeColor = System.Drawing.Color.Black;
            this.txtBank.Location = new System.Drawing.Point(458, 0);
            this.txtBank.Name = "txtBank";
            this.txtBank.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBank.ParentStyleUsing.UseBackColor = false;
            this.txtBank.ParentStyleUsing.UseBorderColor = false;
            this.txtBank.ParentStyleUsing.UseBorders = false;
            this.txtBank.ParentStyleUsing.UseBorderWidth = false;
            this.txtBank.ParentStyleUsing.UseFont = false;
            this.txtBank.ParentStyleUsing.UseForeColor = false;
            this.txtBank.Size = new System.Drawing.Size(275, 15);
            this.txtBank.Text = "txtBank";
            this.txtBank.WordWrap = false;
            // 
            // txtHeimatort
            // 
            this.txtHeimatort.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Heimatort", "")});
            this.txtHeimatort.Font = new System.Drawing.Font("Arial", 10F);
            this.txtHeimatort.ForeColor = System.Drawing.Color.Black;
            this.txtHeimatort.Location = new System.Drawing.Point(342, 0);
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
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AHV", "")});
            this.txtAHV.Font = new System.Drawing.Font("Arial", 10F);
            this.txtAHV.ForeColor = System.Drawing.Color.Black;
            this.txtAHV.Location = new System.Drawing.Point(225, 0);
            this.txtAHV.Name = "txtAHV";
            this.txtAHV.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtAHV.ParentStyleUsing.UseBackColor = false;
            this.txtAHV.ParentStyleUsing.UseBorderColor = false;
            this.txtAHV.ParentStyleUsing.UseBorders = false;
            this.txtAHV.ParentStyleUsing.UseBorderWidth = false;
            this.txtAHV.ParentStyleUsing.UseFont = false;
            this.txtAHV.ParentStyleUsing.UseForeColor = false;
            this.txtAHV.Size = new System.Drawing.Size(117, 15);
            this.txtAHV.Text = "AHV";
            this.txtAHV.WordWrap = false;
            // 
            // txtName
            // 
            this.txtName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.txtName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(0, 0);
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
            this.txtName.WordWrap = false;
            // 
            // xrLine1
            // 
            this.xrLine1.Location = new System.Drawing.Point(0, 44);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(708, 2);
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
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
            this.xrLabel1.Size = new System.Drawing.Size(242, 23);
            this.xrLabel1.Text = "Unterstützte Personen";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial", 10F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(458, 28);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(117, 15);
            this.Label4.Text = "Zahlungsweg";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Arial", 10F);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(342, 28);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(67, 15);
            this.Label3.Text = "Heimatort";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 10F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(225, 28);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(50, 15);
            this.Label2.Text = "AHV";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 10F);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(0, 28);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(67, 15);
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
            this.Margins = new System.Drawing.Printing.Margins(60, 30, 0, 39);
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
		<FieldName>BgPositionID</FieldName>
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
  Name       = PRS.Name + '', '' + PRS.Vorname,
  AHV        = IsNull(PRS.AHVNummer,''''),
  Heimatort  = PRS.Heimatort,
  Zahlungsweg = KRD.Zahlungsweg

FROM BgPosition POS
  INNER JOIN BgBudget                BBG ON BBG.BgBudgetID = POS.BgBudgetID
  INNER JOIN BgFinanzplan_BaPerson   SPP ON SPP.BgFinanzplanID = BBG.BgFinanzplanID
  INNER JOIN vwPerson                PRS ON PRS.BaPersonID = SPP.BaPersonID
  LEFT  JOIN vwkreditor              KRD ON KRD.BaPersonID = SPP.BaPersonID
WHERE SPP.IstUnterstuetzt = 1
  AND POS.BgPositionID = {BgPositionID}' ,  null ,  N'ShEsilVerfuegung' ,  null )

