-- Insert Script for ShVerzeichnisErlassfälle
DELETE FROM XQuery WHERE QueryName LIKE 'ShVerzeichnisErlassfälle' OR ParentReportName LIKE 'ShVerzeichnisErlassfälle'
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShVerzeichnisErlassfälle' ,  N'SH - Verzeichnis der Erlassfälle' , 1,  N'/// <XRTypeInfo>
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
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel27;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLine xrLine23;
        private DevExpress.XtraReports.UI.XRLine xrLine22;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel26;
        private DevExpress.XtraReports.UI.XRLabel xrLabel24;
        private DevExpress.XtraReports.UI.XRLabel xrLabel23;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRLine xrLine16;
        private DevExpress.XtraReports.UI.XRLine xrLine15;
        private DevExpress.XtraReports.UI.XRLine xrLine14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLine xrLine6;
        private DevExpress.XtraReports.UI.XRLine xrLine4;
        private DevExpress.XtraReports.UI.XRLine xrLine2;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLine xrLine21;
        private DevExpress.XtraReports.UI.XRLine xrLine7;
        private DevExpress.XtraReports.UI.XRLine xrLine13;
        private DevExpress.XtraReports.UI.XRLine xrLine12;
        private DevExpress.XtraReports.UI.XRLine xrLine11;
        private DevExpress.XtraReports.UI.XRLine xrLine10;
        private DevExpress.XtraReports.UI.XRLine xrLine9;
        private DevExpress.XtraReports.UI.XRLine xrLine8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLine xrLine20;
        private DevExpress.XtraReports.UI.XRLine xrLine19;
        private DevExpress.XtraReports.UI.XRLine xrLine18;
        private DevExpress.XtraReports.UI.XRLine xrLine17;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
        private DevExpress.XtraReports.UI.XRLabel xrLabel20;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel25;
        private DevExpress.XtraReports.UI.XRLine xrLine5;
        private DevExpress.XtraReports.UI.XRLine xrLine24;
        private DevExpress.XtraReports.UI.XRLabel xrLabel19;
        private DevExpress.XtraReports.UI.XRLine xrLine3;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel28;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAACAAAAAAAAAFBBRFBBRFATtE6ki" +
                        "IttcAAAAAA3AAAAGgEAADJzAHEAbABRAHUAZQByAHkAMQAuAFMAZQBsAGUAYwB0AFMAdABhAHQAZQBtA" +
                        "GUAbgB0AAAAAAAaeAByAEwAYQBiAGUAbAAyAC4AVABlAHgAdAC8DAAAAbkZREVDTEFSRSBAUGVyc29uI" +
                        "FRhYmxlICgNCiAgQmFQZXJzb25JRCBpbnQsDQogIEZhTGVpc3R1bmdJRCAgICBpbnQsDQogIEVpbmtvb" +
                        "W1lbiAgIG1vbmV5LA0KICBbQWx0ZXJdICAgICAgIGludA0KKQ0KDQpJTlNFUlQgSU5UTyBAUGVyc29uD" +
                        "QpTRUxFQ1QgUFJTLkJhUGVyc29uSUQsDQogICAgICAgTUFYKEZBTC5GYUxlaXN0dW5nSUQpLA0KICAgI" +
                        "CAgIEVpbmtvbW1lbiA9IENBU0UgV0hFTiBNQVgoUFJTLlppdmlsc3RhbmRDb2RlKSA9IDIgVEhFTg0KI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICBJc051bGwoZGJvLmZuV2hHZXRFaW5rb21tZW4oUFJTL" +
                        "kJhUGVyc29uSUQsIDEsIENPTlZFUlQoZGF0ZXRpbWUsIENPTlZFUlQodmFyY2hhciwgbnVsbCkgICsnM" +
                        "DEwMScsIDEwNCksIENPTlZFUlQoZGF0ZXRpbWUsIENPTlZFUlQodmFyY2hhciwgbnVsbCkgICsnMTIzM" +
                        "ScsIDEwNCkpLCAwKQ0KICAgICAgICAgICAgICAgICAgICAgICAgRUxTRQ0KICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICBJc051bGwoZGJvLmZuV2hHZXRFaW5rb21tZW4oUFJTLkJhUGVyc29uSUQsIDAsI" +
                        "ENPTlZFUlQoZGF0ZXRpbWUsIENPTlZFUlQodmFyY2hhciwgbnVsbCkgICsnMDEwMScsIDEwNCksIENPT" +
                        "lZFUlQoZGF0ZXRpbWUsIENPTlZFUlQodmFyY2hhciwgbnVsbCkgICsnMTIzMScsIDEwNCkpLCAwKQ0KI" +
                        "CAgICAgICAgICAgICAgICAgIEVORCwNCiAgICAgICBbQWx0ZXJdICAgPSBkYm8uZm5HZXRBZ2UoUFJTL" +
                        "kdlYnVydHNkYXR1bSwgQ09OVkVSVChkYXRldGltZSwgQ09OVkVSVCh2YXJjaGFyLCBZRUFSKEdFVERBV" +
                        "EUoKSkpKycxMjMxJywgMTA0KSkNCkZST00gRmFMZWlzdHVuZyAgICAgICAgICAgICAgICAgICBGQUwNC" +
                        "iAgSU5ORVIgSk9JTiBCYVBlcnNvbiAgICAgICAgUFJTICBPTiBQUlMuQmFQZXJzb25JRCA9IEZBTC5CY" +
                        "VBlcnNvbklEDQpXSEVSRSBGQUwuTW9kdWxJRCA9IDMgLS1Tb3ppYWxoaWxmZQ0KICBBTkQgZGJvLmZuR" +
                        "2V0QWdlKFBSUy5HZWJ1cnRzZGF0dW0sIENPTlZFUlQoZGF0ZXRpbWUsIENPTlZFUlQodmFyY2hhciwgW" +
                        "UVBUihHRVREQVRFKCkpKSsnMTIzMScsIDEwNCkpIEJFVFdFRU4gMjEgQU5EIENBU0UgV0hFTiBQUlMuR" +
                        "2VzY2hsZWNodENvZGUgPSAyIFRIRU4gNjQgRUxTRSA2NSBFTkQNCi0tIEFsdGVyIHp3aXNjaGVuIDIxI" +
                        "HVuZCBSZW50ZW5hbHRlciwgRnJhdWVuOiA2NCwgTcOkbm5lciA2NQ0KICBBTkQgKEZBTC5HZW1laW5kZ" +
                        "UNvZGUgPSBudWxsIE9SIG51bGwgSVMgTlVMTCkNCiAgQU5EIEVYSVNUUyAoU0VMRUNUICogDQogICAgI" +
                        "CAgICAgICAgIEZST00gQmdGaW5hbnpwbGFuDQogICAgICAgICAgICAgIFdIRVJFIEZhTGVpc3R1bmdJR" +
                        "CA9IEZBTC5GYUxlaXN0dW5nSUQNCiAgICAgICAgICAgICAgICBBTkQgbnVsbCBCRVRXRUVOIFlFQVIoS" +
                        "XNOdWxsKERhdHVtVm9uLCBHZXBsYW50Vm9uKSkgQU5EIFlFQVIoSVNOVUxMKElzTnVsbChEYXR1bUJpc" +
                        "ywgR2VwbGFudEJpcyksIEdFVERBVEUoKSkpKSAtLSBGUCB2b3JoYW5kZW4NCkdST1VQIEJZIFBSUy5CY" +
                        "VBlcnNvbklELCBQUlMuR2VidXJ0c2RhdHVtDQoNCg0KU0VMRUNUIERJU1RJTkNUIA0KICAgICAgIFBlc" +
                        "nNvbiAgICAgICAgICAgID0gUFJTLk5hbWUgKyBpc051bGwoJywgJyArIFBSUy5Wb3JuYW1lLCcnKSwNC" +
                        "iAgICAgICBBSFYgICAgICAgICAgICAgICA9IFBSUy5BSFZOdW1tZXIsDQogICAgICAgVmVyc2ljaGVyd" +
                        "GVubnIgICAgPSBQUlMuVmVyc2ljaGVydGVubnVtbWVyLA0KICAgICAgIFppdmlsc3RhbmQgICAgICAgI" +
                        "D0gWklWLlRleHQsDQogICAgICAgV29obnNpdHogICAgICAgICAgPSBpc051bGwoQURSLlBMWiArICcgJ" +
                        "ywgJycpICsgaXNOdWxsKEFEUi5PcnQsICcnKSwNCiAgICAgICBBdWZlbnRoYWx0c29ydCAgICA9IGlzT" +
                        "nVsbChBRFIyLlBMWiArICcgJywgJycpICsgaXNOdWxsKEFEUjIuT3J0LCAnJyksDQogICAgICAgVW50Z" +
                        "XJzdHVldHpPcnQgICAgPSBpc051bGwoUFJTLlVudFdvaG5zaXR6UExaICsgJyAnLCAnJykgKyBpc051b" +
                        "GwoUFJTLlVudFdvaG5zaXR6T3J0LCAnJyksDQogICAgICAgW0FsdGVyXSAgICAgICAgICAgPSBUTVAuW" +
                        "0FsdGVyXSwNCiAgICAgICBbVG90YWxBSFZCZWl0csOkZ2VdPSBDT05WRVJUKG1vbmV5LCBudWxsKSwNC" +
                        "iAgICAgICBFaW5rb21tZW4gICAgICAgICA9IFRNUC5FaW5rb21tZW4sDQogICAgICAgSmFociAgICAgI" +
                        "CAgICAgICAgPSBudWxsLA0KICAgICAgIEdlbWVpbmRlICAgICAgICAgID0gR01ELlRleHQNCkZST00gQ" +
                        "FBlcnNvbiAgICAgICAgICAgICAgICAgIFRNUA0KICBJTk5FUiBKT0lOIEJhUGVyc29uICAgICAgICBQU" +
                        "lMgIE9OIFBSUy5CYVBlcnNvbklEID0gVE1QLkJhUGVyc29uSUQNCiAgSU5ORVIgSk9JTiBCYUFkcmVzc" +
                        "2UgRFdPICBPTiBEV08uQmFQZXJzb25JRCA9IFRNUC5CYVBlcnNvbklEDQogICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgQU5EIERXTy5BZHJlc3NlQ29kZSA9IDEgIC0tV29obnNpdHoNCiAgSU5OR" +
                        "VIgSk9JTiBCYUFkcmVzc2UgICAgICAgQURSICBPTiBBRFIuQmFBZHJlc3NlSUQgPSBEV08uQmFBZHJlc" +
                        "3NlSUQNCiAgSU5ORVIgSk9JTiBGYUxlaXN0dW5nICAgICAgICAgICBGQUwgIE9OIEZBTC5GYUxlaXN0d" +
                        "W5nSUQgPSBUTVAuRmFMZWlzdHVuZ0lEDQogIExFRlQgIEpPSU4gQmFBZHJlc3NlIERXTzIgT04gRFdPM" +
                        "i5CYVBlcnNvbklEID0gVE1QLkJhUGVyc29uSUQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICBBTkQgRFdPMi5BZHJlc3NlQ29kZSA9IDMgLS1BdWZlbnRoYWx0c29ydA0KICBMRUZUICBKT0lOI" +
                        "EJhQWRyZXNzZSAgICAgICBBRFIyIG9uIEFEUjIuQmFBZHJlc3NlSUQgPSBEV08yLkJhQWRyZXNzZUlED" +
                        "QogIExFRlQgIEpPSU4gWExPVkNvZGUgICAgICAgICBaSVYgIE9OIFpJVi5Mb3ZOYW1lID0gJ1ppdmlsc" +
                        "3RhbmQnDQogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIFpJVi5Db2RlID0gUFJTL" +
                        "lppdmlsc3RhbmRDb2RlDQogIExFRlQgIEpPSU4gWExPVkNvZGUgICAgICAgICBHTUQgIE9OIEdNRC5Mb" +
                        "3ZOYW1lID0gJ0dlbWVpbmRlJw0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFORCBHT" +
                        "UQuQ29kZSA9IEZBTC5HZW1laW5kZUNvZGUNCldIRVJFIENBU0UgV0hFTiBQUlMuWml2aWxzdGFuZENvZ" +
                        "GUgPSAyIFRIRU4NCiAgICAgICAgVE1QLkVpbmtvbW1lbiAvIDINCiAgICAgIEVMU0UNCiAgICAgICAgR" +
                        "Wlua29tbWVuDQogICAgICBFTkQgPD0gQ09OVkVSVChtb25leSwgbnVsbCApDQpPUkRFUiBCWSBQZXJzb" +
                        "24B3gJXaXIgYml0dGVuIFNpZSwgZGFzIEZvcm11bGFyIHVudGVyIEJlcsO8Y2tzaWNodGlndW5nIGRlc" +
                        "iBCZW1lcmt1bmdlbiBhdWYgZGVyIFLDvGNrc2VpdGUgYXVzenVmw7xsbGVuLiBEZXIgSmFocmVzYmVpd" +
                        "HJhZyBmw7xyIGRpZSBBSFYvSVYvRU8gYmV0csOkZ3QgNDI1Li0uIEVyIGlzdCB2b2xsc3TDpG5kaWcge" +
                        "nUgYmV6YWhsZW4gZsO8ciBhbGxlIFZlcnNpY2hlcnRlbiwgZGllIGFtIDMxLiBEZXplbWJlciBkZXMgR" +
                        "XJsYXNzamFocmVzIGJlaSBkZXIgR2VtZWluZGUgYW5nZW1lbGRldCBzaW5kLg0KDQpBYiBlaW5lbSBKY" +
                        "WhyZXNsb2huIHZvbiBGci4gNDIwOCBpc3QgZGVyIEJldHJhZyBuaWNodCBnZXNjaHVsZGV0Lg==";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine23 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine22 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine16 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine15 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine14 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine6 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine21 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine7 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine13 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine12 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine11 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine10 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine9 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine8 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine20 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine19 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine18 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine17 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine5 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine24 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // ReportHeader
            // 
            this.ReportHeader.BorderWidth = 0;
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel27,
                        this.xrLabel4,
                        this.xrLine23,
                        this.xrLine22,
                        this.xrLabel8,
                        this.xrLabel6,
                        this.xrLabel26,
                        this.xrLabel24,
                        this.xrLabel23,
                        this.xrLabel22,
                        this.xrLine16,
                        this.xrLine15,
                        this.xrLine14,
                        this.xrLabel5,
                        this.xrLabel10,
                        this.xrLabel7,
                        this.xrLine6,
                        this.xrLine4,
                        this.xrLine2,
                        this.xrLine1,
                        this.xrLabel3,
                        this.xrLabel2,
                        this.xrLabel1});
            this.ReportHeader.Height = 310;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.ParentStyleUsing.UseBorderWidth = false;
            // 
            // Detail
            // 
            this.Detail.BorderWidth = 0;
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLine21,
                        this.xrLine7,
                        this.xrLine13,
                        this.xrLine12,
                        this.xrLine11,
                        this.xrLine10,
                        this.xrLine9,
                        this.xrLine8,
                        this.xrLabel16,
                        this.xrLabel15,
                        this.xrLabel14,
                        this.xrLabel13,
                        this.xrLabel12,
                        this.xrLabel11});
            this.Detail.Height = 40;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBorderWidth = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLine20,
                        this.xrLine19,
                        this.xrLine18,
                        this.xrLine17,
                        this.xrLabel21,
                        this.xrLabel20,
                        this.xrLabel18,
                        this.xrLabel17});
            this.ReportFooter.Name = "ReportFooter";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel25,
                        this.xrLine5,
                        this.xrLine24,
                        this.xrLabel19,
                        this.xrLine3});
            this.GroupFooter1.Height = 67;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageInfo2,
                        this.xrLabel28,
                        this.xrLabel9,
                        this.xrPageInfo1});
            this.PageFooter.Height = 34;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrLabel27
            // 
            this.xrLabel27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Gemeinde", "")});
            this.xrLabel27.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel27.ForeColor = System.Drawing.Color.Black;
            this.xrLabel27.Location = new System.Drawing.Point(558, 100);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.ParentStyleUsing.UseBackColor = false;
            this.xrLabel27.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel27.ParentStyleUsing.UseBorders = false;
            this.xrLabel27.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel27.ParentStyleUsing.UseFont = false;
            this.xrLabel27.ParentStyleUsing.UseForeColor = false;
            this.xrLabel27.Size = new System.Drawing.Size(134, 15);
            this.xrLabel27.Text = "Fürsorgebehörde:";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 12F);
            this.xrLabel4.Location = new System.Drawing.Point(425, 0);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.Size = new System.Drawing.Size(284, 33);
            this.xrLabel4.Text = "Ausgleichskasse des Kantons Bern";
            // 
            // xrLine23
            // 
            this.xrLine23.Location = new System.Drawing.Point(425, 117);
            this.xrLine23.Name = "xrLine23";
            this.xrLine23.Size = new System.Drawing.Size(365, 4);
            // 
            // xrLine22
            // 
            this.xrLine22.Location = new System.Drawing.Point(425, 83);
            this.xrLine22.Name = "xrLine22";
            this.xrLine22.Size = new System.Drawing.Size(365, 2);
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel8.ForeColor = System.Drawing.Color.Black;
            this.xrLabel8.Location = new System.Drawing.Point(425, 100);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseBackColor = false;
            this.xrLabel8.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel8.ParentStyleUsing.UseBorders = false;
            this.xrLabel8.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.ParentStyleUsing.UseForeColor = false;
            this.xrLabel8.Size = new System.Drawing.Size(134, 15);
            this.xrLabel8.Text = "Fürsorgebehörde:";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel6.ForeColor = System.Drawing.Color.Black;
            this.xrLabel6.Location = new System.Drawing.Point(425, 67);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseBackColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorders = false;
            this.xrLabel6.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.ParentStyleUsing.UseForeColor = false;
            this.xrLabel6.Size = new System.Drawing.Size(134, 15);
            this.xrLabel6.Text = "Abrechnungsnummer:";
            // 
            // xrLabel26
            // 
            this.xrLabel26.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel26.ForeColor = System.Drawing.Color.Black;
            this.xrLabel26.Location = new System.Drawing.Point(8, 250);
            this.xrLabel26.Name = "xrLabel26";
            this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel26.ParentStyleUsing.UseBackColor = false;
            this.xrLabel26.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel26.ParentStyleUsing.UseBorders = false;
            this.xrLabel26.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel26.ParentStyleUsing.UseFont = false;
            this.xrLabel26.ParentStyleUsing.UseForeColor = false;
            this.xrLabel26.Size = new System.Drawing.Size(142, 16);
            this.xrLabel26.Text = "Name und Vorname";
            // 
            // xrLabel24
            // 
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel24.ForeColor = System.Drawing.Color.Black;
            this.xrLabel24.Location = new System.Drawing.Point(250, 250);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.ParentStyleUsing.UseBackColor = false;
            this.xrLabel24.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel24.ParentStyleUsing.UseBorders = false;
            this.xrLabel24.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel24.ParentStyleUsing.UseFont = false;
            this.xrLabel24.ParentStyleUsing.UseForeColor = false;
            this.xrLabel24.Size = new System.Drawing.Size(75, 15);
            this.xrLabel24.Text = "Zivilstand";
            // 
            // xrLabel23
            // 
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel23.ForeColor = System.Drawing.Color.Black;
            this.xrLabel23.Location = new System.Drawing.Point(336, 250);
            this.xrLabel23.Multiline = true;
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.ParentStyleUsing.UseBackColor = false;
            this.xrLabel23.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel23.ParentStyleUsing.UseBorders = false;
            this.xrLabel23.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel23.ParentStyleUsing.UseFont = false;
            this.xrLabel23.ParentStyleUsing.UseForeColor = false;
            this.xrLabel23.Size = new System.Drawing.Size(135, 50);
            this.xrLabel23.Text = "Polizeiliche \r\nWohnsitzgemeinde";
            // 
            // xrLabel22
            // 
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel22.ForeColor = System.Drawing.Color.Black;
            this.xrLabel22.Location = new System.Drawing.Point(480, 250);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.ParentStyleUsing.UseBackColor = false;
            this.xrLabel22.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel22.ParentStyleUsing.UseBorders = false;
            this.xrLabel22.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel22.ParentStyleUsing.UseFont = false;
            this.xrLabel22.ParentStyleUsing.UseForeColor = false;
            this.xrLabel22.Size = new System.Drawing.Size(135, 19);
            this.xrLabel22.Text = "Aufenthaltsort";
            // 
            // xrLine16
            // 
            this.xrLine16.ForeColor = System.Drawing.Color.Black;
            this.xrLine16.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine16.Location = new System.Drawing.Point(476, 242);
            this.xrLine16.Name = "xrLine16";
            this.xrLine16.ParentStyleUsing.UseBackColor = false;
            this.xrLine16.ParentStyleUsing.UseBorderColor = false;
            this.xrLine16.ParentStyleUsing.UseBorders = false;
            this.xrLine16.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine16.ParentStyleUsing.UseFont = false;
            this.xrLine16.ParentStyleUsing.UseForeColor = false;
            this.xrLine16.Size = new System.Drawing.Size(2, 68);
            // 
            // xrLine15
            // 
            this.xrLine15.ForeColor = System.Drawing.Color.Black;
            this.xrLine15.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine15.Location = new System.Drawing.Point(618, 242);
            this.xrLine15.Name = "xrLine15";
            this.xrLine15.ParentStyleUsing.UseBackColor = false;
            this.xrLine15.ParentStyleUsing.UseBorderColor = false;
            this.xrLine15.ParentStyleUsing.UseBorders = false;
            this.xrLine15.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine15.ParentStyleUsing.UseFont = false;
            this.xrLine15.ParentStyleUsing.UseForeColor = false;
            this.xrLine15.Size = new System.Drawing.Size(2, 68);
            // 
            // xrLine14
            // 
            this.xrLine14.ForeColor = System.Drawing.Color.Black;
            this.xrLine14.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine14.Location = new System.Drawing.Point(709, 242);
            this.xrLine14.Name = "xrLine14";
            this.xrLine14.ParentStyleUsing.UseBackColor = false;
            this.xrLine14.ParentStyleUsing.UseBorderColor = false;
            this.xrLine14.ParentStyleUsing.UseBorders = false;
            this.xrLine14.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine14.ParentStyleUsing.UseFont = false;
            this.xrLine14.ParentStyleUsing.UseForeColor = false;
            this.xrLine14.Size = new System.Drawing.Size(2, 68);
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel5.ForeColor = System.Drawing.Color.Black;
            this.xrLabel5.Location = new System.Drawing.Point(714, 250);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseBackColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorders = false;
            this.xrLabel5.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.ParentStyleUsing.UseForeColor = false;
            this.xrLabel5.Size = new System.Drawing.Size(75, 58);
            this.xrLabel5.Text = "IK-Eintrag durch die Zweigstelle anzugeben";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel10.ForeColor = System.Drawing.Color.Black;
            this.xrLabel10.Location = new System.Drawing.Point(158, 250);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.ParentStyleUsing.UseBackColor = false;
            this.xrLabel10.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel10.ParentStyleUsing.UseBorders = false;
            this.xrLabel10.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel10.ParentStyleUsing.UseFont = false;
            this.xrLabel10.ParentStyleUsing.UseForeColor = false;
            this.xrLabel10.Size = new System.Drawing.Size(84, 41);
            this.xrLabel10.Text = "Versicherten-Nr.";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel7.ForeColor = System.Drawing.Color.Black;
            this.xrLabel7.Location = new System.Drawing.Point(623, 250);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseBackColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorders = false;
            this.xrLabel7.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.ParentStyleUsing.UseForeColor = false;
            this.xrLabel7.Size = new System.Drawing.Size(83, 58);
            this.xrLabel7.Text = "Total AHV/IV/EO\r\nBeiträge";
            // 
            // xrLine6
            // 
            this.xrLine6.ForeColor = System.Drawing.Color.Black;
            this.xrLine6.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine6.Location = new System.Drawing.Point(332, 242);
            this.xrLine6.Name = "xrLine6";
            this.xrLine6.ParentStyleUsing.UseBackColor = false;
            this.xrLine6.ParentStyleUsing.UseBorderColor = false;
            this.xrLine6.ParentStyleUsing.UseBorders = false;
            this.xrLine6.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine6.ParentStyleUsing.UseFont = false;
            this.xrLine6.ParentStyleUsing.UseForeColor = false;
            this.xrLine6.Size = new System.Drawing.Size(2, 68);
            // 
            // xrLine4
            // 
            this.xrLine4.BorderWidth = 0;
            this.xrLine4.ForeColor = System.Drawing.Color.Black;
            this.xrLine4.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine4.Location = new System.Drawing.Point(245, 242);
            this.xrLine4.Name = "xrLine4";
            this.xrLine4.ParentStyleUsing.UseBackColor = false;
            this.xrLine4.ParentStyleUsing.UseBorderColor = false;
            this.xrLine4.ParentStyleUsing.UseBorders = false;
            this.xrLine4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine4.ParentStyleUsing.UseFont = false;
            this.xrLine4.ParentStyleUsing.UseForeColor = false;
            this.xrLine4.Size = new System.Drawing.Size(2, 68);
            // 
            // xrLine2
            // 
            this.xrLine2.ForeColor = System.Drawing.Color.Black;
            this.xrLine2.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine2.Location = new System.Drawing.Point(0, 242);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.ParentStyleUsing.UseBackColor = false;
            this.xrLine2.ParentStyleUsing.UseBorderColor = false;
            this.xrLine2.ParentStyleUsing.UseBorders = false;
            this.xrLine2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine2.ParentStyleUsing.UseFont = false;
            this.xrLine2.ParentStyleUsing.UseForeColor = false;
            this.xrLine2.Size = new System.Drawing.Size(2, 67);
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine1.Location = new System.Drawing.Point(153, 242);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(2, 68);
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Jahr", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.Location = new System.Drawing.Point(221, 80);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(100, 25);
            this.xrLabel3.Text = "xrLabel3";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 9.75F);
            this.xrLabel2.Location = new System.Drawing.Point(0, 142);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(783, 92);
            this.xrLabel2.Text = resources.GetString("xrLabel2.Text");
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.Location = new System.Drawing.Point(0, 58);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(225, 50);
            this.xrLabel1.Text = "Verzeichnis der Erlassfälle für das Jahr";
            // 
            // xrLine21
            // 
            this.xrLine21.ForeColor = System.Drawing.Color.Black;
            this.xrLine21.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine21.Location = new System.Drawing.Point(0, 0);
            this.xrLine21.Name = "xrLine21";
            this.xrLine21.ParentStyleUsing.UseBackColor = false;
            this.xrLine21.ParentStyleUsing.UseBorderColor = false;
            this.xrLine21.ParentStyleUsing.UseBorders = false;
            this.xrLine21.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine21.ParentStyleUsing.UseFont = false;
            this.xrLine21.ParentStyleUsing.UseForeColor = false;
            this.xrLine21.Size = new System.Drawing.Size(2, 40);
            // 
            // xrLine7
            // 
            this.xrLine7.BorderWidth = 0;
            this.xrLine7.ForeColor = System.Drawing.Color.Black;
            this.xrLine7.Location = new System.Drawing.Point(0, 0);
            this.xrLine7.Name = "xrLine7";
            this.xrLine7.ParentStyleUsing.UseBackColor = false;
            this.xrLine7.ParentStyleUsing.UseBorderColor = false;
            this.xrLine7.ParentStyleUsing.UseBorders = false;
            this.xrLine7.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine7.ParentStyleUsing.UseFont = false;
            this.xrLine7.ParentStyleUsing.UseForeColor = false;
            this.xrLine7.Size = new System.Drawing.Size(785, 2);
            // 
            // xrLine13
            // 
            this.xrLine13.ForeColor = System.Drawing.Color.Black;
            this.xrLine13.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine13.Location = new System.Drawing.Point(618, 0);
            this.xrLine13.Name = "xrLine13";
            this.xrLine13.ParentStyleUsing.UseBackColor = false;
            this.xrLine13.ParentStyleUsing.UseBorderColor = false;
            this.xrLine13.ParentStyleUsing.UseBorders = false;
            this.xrLine13.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine13.ParentStyleUsing.UseFont = false;
            this.xrLine13.ParentStyleUsing.UseForeColor = false;
            this.xrLine13.Size = new System.Drawing.Size(2, 40);
            // 
            // xrLine12
            // 
            this.xrLine12.ForeColor = System.Drawing.Color.Black;
            this.xrLine12.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine12.Location = new System.Drawing.Point(245, 0);
            this.xrLine12.Name = "xrLine12";
            this.xrLine12.ParentStyleUsing.UseBackColor = false;
            this.xrLine12.ParentStyleUsing.UseBorderColor = false;
            this.xrLine12.ParentStyleUsing.UseBorders = false;
            this.xrLine12.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine12.ParentStyleUsing.UseFont = false;
            this.xrLine12.ParentStyleUsing.UseForeColor = false;
            this.xrLine12.Size = new System.Drawing.Size(2, 40);
            // 
            // xrLine11
            // 
            this.xrLine11.ForeColor = System.Drawing.Color.Black;
            this.xrLine11.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine11.Location = new System.Drawing.Point(476, 0);
            this.xrLine11.Name = "xrLine11";
            this.xrLine11.ParentStyleUsing.UseBackColor = false;
            this.xrLine11.ParentStyleUsing.UseBorderColor = false;
            this.xrLine11.ParentStyleUsing.UseBorders = false;
            this.xrLine11.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine11.ParentStyleUsing.UseFont = false;
            this.xrLine11.ParentStyleUsing.UseForeColor = false;
            this.xrLine11.Size = new System.Drawing.Size(2, 40);
            // 
            // xrLine10
            // 
            this.xrLine10.ForeColor = System.Drawing.Color.Black;
            this.xrLine10.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine10.Location = new System.Drawing.Point(332, 0);
            this.xrLine10.Name = "xrLine10";
            this.xrLine10.ParentStyleUsing.UseBackColor = false;
            this.xrLine10.ParentStyleUsing.UseBorderColor = false;
            this.xrLine10.ParentStyleUsing.UseBorders = false;
            this.xrLine10.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine10.ParentStyleUsing.UseFont = false;
            this.xrLine10.ParentStyleUsing.UseForeColor = false;
            this.xrLine10.Size = new System.Drawing.Size(2, 40);
            // 
            // xrLine9
            // 
            this.xrLine9.ForeColor = System.Drawing.Color.Black;
            this.xrLine9.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine9.Location = new System.Drawing.Point(709, 0);
            this.xrLine9.Name = "xrLine9";
            this.xrLine9.ParentStyleUsing.UseBackColor = false;
            this.xrLine9.ParentStyleUsing.UseBorderColor = false;
            this.xrLine9.ParentStyleUsing.UseBorders = false;
            this.xrLine9.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine9.ParentStyleUsing.UseFont = false;
            this.xrLine9.ParentStyleUsing.UseForeColor = false;
            this.xrLine9.Size = new System.Drawing.Size(2, 40);
            // 
            // xrLine8
            // 
            this.xrLine8.BorderWidth = 0;
            this.xrLine8.ForeColor = System.Drawing.Color.Black;
            this.xrLine8.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.xrLine8.Location = new System.Drawing.Point(153, 0);
            this.xrLine8.Name = "xrLine8";
            this.xrLine8.ParentStyleUsing.UseBackColor = false;
            this.xrLine8.ParentStyleUsing.UseBorderColor = false;
            this.xrLine8.ParentStyleUsing.UseBorders = false;
            this.xrLine8.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine8.ParentStyleUsing.UseFont = false;
            this.xrLine8.ParentStyleUsing.UseForeColor = false;
            this.xrLine8.Size = new System.Drawing.Size(2, 40);
            // 
            // xrLabel16
            // 
            this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TotalAHVBeiträge", "{0:n2}")});
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 7F);
            this.xrLabel16.Location = new System.Drawing.Point(623, 8);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.ParentStyleUsing.UseFont = false;
            this.xrLabel16.Size = new System.Drawing.Size(83, 25);
            this.xrLabel16.Text = "6";
            this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel15
            // 
            this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "UnterstuetzOrt", "")});
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 7F);
            this.xrLabel15.Location = new System.Drawing.Point(480, 8);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.ParentStyleUsing.UseFont = false;
            this.xrLabel15.Size = new System.Drawing.Size(135, 25);
            this.xrLabel15.Text = "xrLabel15";
            // 
            // xrLabel14
            // 
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Wohnsitz", "")});
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 7F);
            this.xrLabel14.Location = new System.Drawing.Point(336, 8);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.ParentStyleUsing.UseFont = false;
            this.xrLabel14.Size = new System.Drawing.Size(135, 25);
            this.xrLabel14.Text = "xrLabel14";
            // 
            // xrLabel13
            // 
            this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Zivilstand", "")});
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 7F);
            this.xrLabel13.Location = new System.Drawing.Point(250, 8);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.ParentStyleUsing.UseFont = false;
            this.xrLabel13.Size = new System.Drawing.Size(75, 25);
            this.xrLabel13.Text = "xrLabel13";
            // 
            // xrLabel12
            // 
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AHV", "")});
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 7F);
            this.xrLabel12.Location = new System.Drawing.Point(158, 8);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.ParentStyleUsing.UseFont = false;
            this.xrLabel12.Size = new System.Drawing.Size(84, 25);
            this.xrLabel12.Text = "xrLabel12";
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Person", "")});
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 7F);
            this.xrLabel11.Location = new System.Drawing.Point(8, 8);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.ParentStyleUsing.UseFont = false;
            this.xrLabel11.Size = new System.Drawing.Size(142, 25);
            this.xrLabel11.Text = "xrLabel11";
            // 
            // xrLine20
            // 
            this.xrLine20.Location = new System.Drawing.Point(500, 70);
            this.xrLine20.Name = "xrLine20";
            this.xrLine20.Size = new System.Drawing.Size(233, 2);
            // 
            // xrLine19
            // 
            this.xrLine19.Location = new System.Drawing.Point(500, 29);
            this.xrLine19.Name = "xrLine19";
            this.xrLine19.Size = new System.Drawing.Size(233, 2);
            // 
            // xrLine18
            // 
            this.xrLine18.Location = new System.Drawing.Point(67, 70);
            this.xrLine18.Name = "xrLine18";
            this.xrLine18.Size = new System.Drawing.Size(125, 2);
            // 
            // xrLine17
            // 
            this.xrLine17.Location = new System.Drawing.Point(67, 29);
            this.xrLine17.Name = "xrLine17";
            this.xrLine17.Size = new System.Drawing.Size(125, 2);
            // 
            // xrLabel21
            // 
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel21.Location = new System.Drawing.Point(8, 58);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.ParentStyleUsing.UseFont = false;
            this.xrLabel21.Size = new System.Drawing.Size(50, 25);
            this.xrLabel21.Text = "Datum:";
            // 
            // xrLabel20
            // 
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel20.Location = new System.Drawing.Point(8, 17);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.ParentStyleUsing.UseFont = false;
            this.xrLabel20.Size = new System.Drawing.Size(50, 25);
            this.xrLabel20.Text = "Datum:";
            // 
            // xrLabel18
            // 
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel18.Location = new System.Drawing.Point(267, 58);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.ParentStyleUsing.UseFont = false;
            this.xrLabel18.Size = new System.Drawing.Size(225, 25);
            this.xrLabel18.Text = "Unterschrift der AHV-Zweigstelle:";
            // 
            // xrLabel17
            // 
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel17.Location = new System.Drawing.Point(267, 17);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.ParentStyleUsing.UseFont = false;
            this.xrLabel17.Size = new System.Drawing.Size(225, 25);
            this.xrLabel17.Text = "Unterschrift der Fürsorgebehörde:";
            // 
            // xrLabel25
            // 
            this.xrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "TotalAHVBeiträge", "")});
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel25.Location = new System.Drawing.Point(623, 25);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.ParentStyleUsing.UseFont = false;
            this.xrLabel25.Size = new System.Drawing.Size(83, 25);
            xrSummary1.FormatString = "{0:n2}";
            xrSummary1.IgnoreNullValues = true;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel25.Summary = xrSummary1;
            this.xrLabel25.Text = "6";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLine5
            // 
            this.xrLine5.Location = new System.Drawing.Point(620, 8);
            this.xrLine5.Name = "xrLine5";
            this.xrLine5.Size = new System.Drawing.Size(166, 4);
            // 
            // xrLine24
            // 
            this.xrLine24.BorderWidth = 0;
            this.xrLine24.ForeColor = System.Drawing.Color.Black;
            this.xrLine24.Location = new System.Drawing.Point(0, 0);
            this.xrLine24.Name = "xrLine24";
            this.xrLine24.ParentStyleUsing.UseBackColor = false;
            this.xrLine24.ParentStyleUsing.UseBorderColor = false;
            this.xrLine24.ParentStyleUsing.UseBorders = false;
            this.xrLine24.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine24.ParentStyleUsing.UseFont = false;
            this.xrLine24.ParentStyleUsing.UseForeColor = false;
            this.xrLine24.Size = new System.Drawing.Size(785, 2);
            // 
            // xrLabel19
            // 
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel19.Location = new System.Drawing.Point(492, 25);
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.ParentStyleUsing.UseFont = false;
            this.xrLabel19.Size = new System.Drawing.Size(108, 25);
            this.xrLabel19.Text = "Total od. Übertrag";
            // 
            // xrLine3
            // 
            this.xrLine3.Location = new System.Drawing.Point(0, 50);
            this.xrLine3.Name = "xrLine3";
            this.xrLine3.Size = new System.Drawing.Size(785, 17);
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 9F);
            this.xrPageInfo2.Format = "{0:dd.MM.yyyy}";
            this.xrPageInfo2.Location = new System.Drawing.Point(83, 8);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            this.xrPageInfo2.Size = new System.Drawing.Size(100, 20);
            // 
            // xrLabel28
            // 
            this.xrLabel28.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel28.Location = new System.Drawing.Point(0, 8);
            this.xrLabel28.Name = "xrLabel28";
            this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel28.ParentStyleUsing.UseFont = false;
            this.xrLabel28.Size = new System.Drawing.Size(100, 20);
            this.xrLabel28.Text = "Druckdatum";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel9.Location = new System.Drawing.Point(333, 8);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.Size = new System.Drawing.Size(100, 20);
            this.xrLabel9.Text = "Seite";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 9F);
            this.xrPageInfo1.Location = new System.Drawing.Point(375, 8);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(100, 20);
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.ReportHeader,
                        this.Detail,
                        this.ReportFooter,
                        this.GroupFooter1,
                        this.PageFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(30, 30, 66, 100);
            this.Name = "Report";
            this.PageHeight = 1100;
            this.PageWidth = 850;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
' ,  N'<?xml version="1.0" standalone="yes"?>
<NewDataSet>
    <Table>
        <FieldName>-</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Jahr</DisplayText>
        <TabPosition>1</TabPosition>
        <X>10</X>
        <Y>40</Y>
    </Table>
    <Table>
        <FieldName>-</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>AHV-Mindestbeitrag</DisplayText>
        <TabPosition>1</TabPosition>
        <X>10</X>
        <Y>70</Y>
    </Table>
    <Table>
        <FieldName>-</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Maximal-Lohn</DisplayText>
        <TabPosition>1</TabPosition>
        <X>10</X>
        <Y>100</Y>
    </Table>
    <Table>
        <FieldName>-</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Gemeinde</DisplayText>
        <TabPosition>1</TabPosition>
        <X>10</X>
        <Y>130</Y>
    </Table>
    <Table>
        <FieldName>Jahr</FieldName>
        <FieldCode>4</FieldCode>
        <TabPosition>20</TabPosition>
        <X>150</X>
        <Y>40</Y>
        <Width>200</Width>
        <Height>24</Height>
        <DefaultValue>2007</DefaultValue>
        <Mandatory>true</Mandatory>
    </Table>
    <Table>
        <FieldName>AHVBeitrag</FieldName>
        <FieldCode>4</FieldCode>
        <TabPosition>21</TabPosition>
        <X>150</X>
        <Y>70</Y>
        <Width>200</Width>
        <Height>24</Height>
        <DefaultValue>425.00</DefaultValue>
        <Mandatory>true</Mandatory>
    </Table>
    <Table>
        <FieldName>MaxBetrag</FieldName>
        <FieldCode>4</FieldCode>
        <TabPosition>22</TabPosition>
        <X>150</X>
        <Y>100</Y>
        <Width>200</Width>
        <Height>24</Height>
        <DefaultValue>4208.00</DefaultValue>
        <Mandatory>true</Mandatory>
    </Table>
    <Table>
        <FieldName>GemeindeCode</FieldName>
        <FieldCode>8</FieldCode>
        <TabPosition>23</TabPosition>
        <X>150</X>
        <Y>130</Y>
        <Width>200</Width>
        <Height>24</Height>
        <LOVName>GemeindeSozialdienst</LOVName>
        <Mandatory>false</Mandatory>
    </Table>
</NewDataSet>' ,  N'DECLARE @Person Table (
  BaPersonID int,
  FaLeistungID    int,
  Einkommen   money,
  [Alter]       int
)

INSERT INTO @Person
SELECT PRS.BaPersonID,
       MAX(FAL.FaLeistungID),
       Einkommen = CASE WHEN MAX(PRS.ZivilstandCode) = 2 THEN
                             IsNull(dbo.fnWhGetEinkommen(PRS.BaPersonID, 1, CONVERT(datetime, CONVERT(varchar, {Jahr})  +''0101'', 104), CONVERT(datetime, CONVERT(varchar, {Jahr})  +''1231'', 104)), 0)
                        ELSE
                             IsNull(dbo.fnWhGetEinkommen(PRS.BaPersonID, 0, CONVERT(datetime, CONVERT(varchar, {Jahr})  +''0101'', 104), CONVERT(datetime, CONVERT(varchar, {Jahr})  +''1231'', 104)), 0)
                   END,
       [Alter]   = dbo.fnGetAge(PRS.Geburtsdatum, CONVERT(datetime, CONVERT(varchar, YEAR(GETDATE()))+''1231'', 104))
FROM FaLeistung                   FAL
  INNER JOIN BaPerson        PRS  ON PRS.BaPersonID = FAL.BaPersonID
WHERE FAL.ModulID = 3 --Sozialhilfe
  AND dbo.fnGetAge(PRS.Geburtsdatum, CONVERT(datetime, CONVERT(varchar, YEAR(GETDATE()))+''1231'', 104)) BETWEEN 21 AND CASE WHEN PRS.GeschlechtCode = 2 THEN 64 ELSE 65 END
-- Alter zwischen 21 und Rentenalter, Frauen: 64, Männer 65
  AND (FAL.GemeindeCode = {GemeindeCode} OR {GemeindeCode} IS NULL)
  AND EXISTS (SELECT * 
              FROM BgFinanzplan
              WHERE FaLeistungID = FAL.FaLeistungID
                AND {Jahr} BETWEEN YEAR(IsNull(DatumVon, GeplantVon)) AND YEAR(ISNULL(IsNull(DatumBis, GeplantBis), GETDATE()))) -- FP vorhanden
GROUP BY PRS.BaPersonID, PRS.Geburtsdatum


SELECT DISTINCT 
       Person            = PRS.Name + isNull('', '' + PRS.Vorname,''''),
       AHV               = PRS.AHVNummer,
       Versichertennr    = PRS.Versichertennummer,
       Zivilstand        = ZIV.Text,
       Wohnsitz          = isNull(ADR.PLZ + '' '', '''') + isNull(ADR.Ort, ''''),
       Aufenthaltsort    = isNull(ADR2.PLZ + '' '', '''') + isNull(ADR2.Ort, ''''),
       UnterstuetzOrt    = isNull(PRS.UntWohnsitzPLZ + '' '', '''') + isNull(PRS.UntWohnsitzOrt, ''''),
       [Alter]           = TMP.[Alter],
       [TotalAHVBeiträge]= CONVERT(money, {AHVBeitrag}),
       Einkommen         = TMP.Einkommen,
       Jahr              = {Jahr},
       Gemeinde          = GMD.Text
FROM @Person                  TMP
  INNER JOIN BaPerson        PRS  ON PRS.BaPersonID = TMP.BaPersonID
  INNER JOIN BaAdresse DWO  ON DWO.BaPersonID = TMP.BaPersonID
                                  AND DWO.AdresseCode = 1  --Wohnsitz
  INNER JOIN BaAdresse       ADR  ON ADR.BaAdresseID = DWO.BaAdresseID
  INNER JOIN FaLeistung           FAL  ON FAL.FaLeistungID = TMP.FaLeistungID
  LEFT  JOIN BaAdresse DWO2 ON DWO2.BaPersonID = TMP.BaPersonID
                                  AND DWO2.AdresseCode = 3 --Aufenthaltsort
  LEFT  JOIN BaAdresse       ADR2 on ADR2.BaAdresseID = DWO2.BaAdresseID
  LEFT  JOIN XLOVCode         ZIV  ON ZIV.LovName = ''Zivilstand''
                                  AND ZIV.Code = PRS.ZivilstandCode
  LEFT  JOIN XLOVCode         GMD  ON GMD.LovName = ''Gemeinde''
                                  AND GMD.Code = FAL.GemeindeCode
WHERE CASE WHEN PRS.ZivilstandCode = 2 THEN
        TMP.Einkommen / 2
      ELSE
        Einkommen
      END <= CONVERT(money, {MaxBetrag} )
ORDER BY Person' ,  null ,  null ,  null )

