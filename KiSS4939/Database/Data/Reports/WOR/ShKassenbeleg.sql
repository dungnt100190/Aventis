-- Insert Script for ShKassenbeleg
-- MD5:0X5703A306FB92B762729B90E1816F4FAA_0XB4C8772B5FDC602B7B6ACD41A694CD9C_0X9B4B25EB758EE3AB95D06D5533F9ACBE
IF NOT EXISTS(SELECT TOP 1 1 FROM XQuery WHERE QueryName LIKE 'ShKassenbeleg') BEGIN
INSERT INTO XQuery(QueryName, QueryCode) VALUES('ShKassenbeleg', 1)
END;

DELETE FROM XQuery WHERE ParentReportName LIKE 'ShKassenbeleg';
UPDATE QRY
SET QueryName =  N'ShKassenbeleg' , UserText =  N'SH - Kassenbeleg' , QueryCode = 1, LayoutXML =  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>C:\Program Files\Born Informatik AG\KiSS Release 4.2.33\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>de-DE</Localization>
///   <References>
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS Release 4.2.33\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS Release 4.2.33\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Drawing\2.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System\2.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Configuration\2.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Xml\2.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Data.SqlXml\2.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\Windows\assembly\GAC_MSIL\System.Security\2.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS Release 4.2.33\DevExpress.Utils.v6.2.dll" />
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
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS Release 4.2.33\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS Release 4.2.33\DevExpress.Data.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS Release 4.2.33\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS Release 4.2.33\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS Release 4.2.33\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS Release 4.2.33\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS Release 4.2.33\KiSS4.DB.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS Release 4.2.33\log4net.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS Release 4.2.33\SharpLibrary.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS Release 4.2.33\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="C:\Program Files\Born Informatik AG\KiSS Release 4.2.33\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtNameFbKostenstelle;
        private DevExpress.XtraReports.UI.XRLabel txtIntern;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel Label18;
        private DevExpress.XtraReports.UI.XRLabel Label17;
        private DevExpress.XtraReports.UI.XRLabel Label16;
        private DevExpress.XtraReports.UI.XRLabel txtNameFbKostenart;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel17;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel15;
        private DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRLabel xrLabel13;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.XRLabel xrLabel9;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel Label15;
        private DevExpress.XtraReports.UI.XRLabel txtStrasse;
        private DevExpress.XtraReports.UI.XRLabel FullName1;
        private DevExpress.XtraReports.UI.XRLabel Label14;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.XRLabel Label3;
        private DevExpress.XtraReports.UI.XRLabel Label2;
        private DevExpress.XtraReports.UI.XRLabel Label1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel25;
        private DevExpress.XtraReports.UI.XRLabel xrLabel24;
        private DevExpress.XtraReports.UI.XRLabel xrLabel23;
        private DevExpress.XtraReports.UI.XRLabel xrLabel22;
        private DevExpress.XtraReports.UI.XRLabel xrLabel21;
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
                        "AAAAeUeREVDTEFSRSBAS2JCdWNodW5nSUQgSU5UOw0KU0VUIEBLYkJ1Y2h1bmdJRCA9IG51bGw7IC0tI" +
                        "ChUZXN0Q2FzZSkxMzQ0MQ0KDQpTRUxFQ1QgRElTVElOQ1QNCiAgT3JnX05hbWUgICAgICAgICAgICAgP" +
                        "SBJU05VTEwoQ09OVkVSVChWQVJDSEFSKDEwMDApLCBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZ" +
                        "VxTb3ppYWxoaWxmZVxPcmdhbmlzYXRpb24nLCBHRVREQVRFKCkpKSwgJycpLA0KICBPcmdfQWRyZXNzZ" +
                        "SAgICAgICAgICA9IElTTlVMTChDT05WRVJUKFZBUkNIQVIoMTAwMCksIGRiby5mblhDb25maWcoJ1N5c" +
                        "3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlXEFkcmVzc2UnLCBHRVREQVRFKCkpKSwgJycpLA0KICBPcmdfU" +
                        "ExaICAgICAgICAgICAgICA9IElTTlVMTChDT05WRVJUKFZBUkNIQVIoMTAwMCksIGRiby5mblhDb25ma" +
                        "WcoJ1N5c3RlbVxBZHJlc3NlXFNvemlhbGhpbGZlXFBMWicsIEdFVERBVEUoKSkpLCAnJyksDQogIE9yZ" +
                        "19PcnQgICAgICAgICAgICAgID0gSVNOVUxMKENPTlZFUlQoVkFSQ0hBUigxMDAwKSwgZGJvLmZuWENvb" +
                        "mZpZygnU3lzdGVtXEFkcmVzc2VcU296aWFsaGlsZmVcT3J0JywgR0VUREFURSgpKSksICcnKSwNCiAgT" +
                        "3JnX1BMWk9ydCAgICAgICAgICAgPSBJU05VTEwoQ09OVkVSVChWQVJDSEFSKDEwMDApLCBkYm8uZm5YQ" +
                        "29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxQTFonLCBHRVREQVRFKCkpKSArICcgJywgJ" +
                        "ycpICsNCiAgICAgICAgICAgICAgICAgICAgICAgICBJU05VTEwoQ09OVkVSVChWQVJDSEFSKDEwMDApL" +
                        "CBkYm8uZm5YQ29uZmlnKCdTeXN0ZW1cQWRyZXNzZVxTb3ppYWxoaWxmZVxPcnQnLCBHRVREQVRFKCkpK" +
                        "SwgJycpLA0KICBLYkF1c3phaGx1bmdzYXJ0Q29kZSA9IEJVQy5LYkF1c3phaGx1bmdzYXJ0Q29kZSwNC" +
                        "iAgS2JCdWNodW5nSUQgICAgICAgICAgPSBCVUMuS2JCdWNodW5nSUQsDQogIEtiQnVjaHVuZ1N0YXR1c" +
                        "0NvZGUgID0gQlVDLktiQnVjaHVuZ1N0YXR1c0NvZGUsDQogIE5hbWVLYkJ1Y2h1bmdzU3RhdHVzID0gZ" +
                        "GJvLmZuTE9WVGV4dCgnS2JCdWNodW5nc1N0YXR1cycsIEJVQy5LYkJ1Y2h1bmdTdGF0dXNDb2RlKSwNC" +
                        "iAgTmFtZUtiQXVzemFobHVuZ3NBcnQgPSBkYm8uZm5MT1ZUZXh0KCdLYkF1c3phaGx1bmdzQXJ0JywgQ" +
                        "lVDLktiQXVzemFobHVuZ3NhcnRDb2RlKSwNCiAgTmFtZVllYXJNb250aCAgICAgICAgPSBkYm8uZm5YT" +
                        "W9uYXQoQkRHLk1vbmF0KSArICcgJyArIENPTlZFUlQoVkFSQ0hBUiwgQkRHLkphaHIpLA0KICBWZXJmY" +
                        "WxsZGF0dW0gICAgICAgICA9IERBVEVBREQoREFZLCA1LCBCVUMuVmFsdXRhRGF0dW0pLA0KICBLYkJ1Y" +
                        "2h1bmdLb3N0ZW5zcnRJRCA9IEtCSy5LYkJ1Y2h1bmdLb3N0ZW5hcnRJRCwNCiAgQnVjaHVuZ3N0ZXh0I" +
                        "CAgICAgICAgPSBLQksuQnVjaHVuZ3N0ZXh0LA0KICBCZXRyYWcgICAgICAgICAgICAgICA9IEtCSy5CZ" +
                        "XRyYWcsDQogIE5hbWVLb3N0ZW5hcnQgICAgICAgID0gQkdLLk5hbWUsDQogIE5hbWVLb3N0ZW5zdGVsb" +
                        "GUgICAgID0gSVNOVUxMKEtTVC5OciwgS1BSLk5yKSwNCiAgS0JLUGVyc29uSUQgICAgICAgICAgPSBLQ" +
                        "ksuQmFQZXJzb25JRCwNCiAgS2JLb3N0ZW5zdGVsbGVJRCAgICAgPSBLQksuS2JLb3N0ZW5zdGVsbGVJR" +
                        "CwNCiAgTmFtZUthc3NpZXIgICAgICAgICAgPSBLVVNSLkxhc3ROYW1lICsgSVNOVUxMKCcsICcgKyBLV" +
                        "VNSLkZpcnN0TmFtZSwgJycpICsgSVNOVUxMKCcgKCcgKyBLVVNSLlBob25lICsgJyknLCAnJyksDQogI" +
                        "EZ1bGxOYW1lICAgICAgICAgICAgID0gUFJTLk5hbWVWb3JuYW1lLA0KICBBdXN6dXphaGxlbkFuICAgI" +
                        "CAgICA9IElTTlVMTChOVUxMSUYoQlVDLkJlZ3VlbnN0aWd0TmFtZSwgJycpLCBQUlMuTmFtZVZvcm5hb" +
                        "WUpLA0KICBTdHJhc3NlICAgICAgICAgICAgICA9IElTTlVMTChOVUxMSUYoQlVDLkJlZ3VlbnN0aWd0U" +
                        "3RyYXNzZSwgJycpLCBQUlMuV29obnNpdHpTdHJhc3NlSGF1c05yKSwNCiAgUExaT3J0ICAgICAgICAgI" +
                        "CAgICAgPSBJU05VTEwoTlVMTElGKEJVQy5CZWd1ZW5zdGlndE9ydCwgJycpLCBQUlMuV29obnNpdHpQT" +
                        "FpPcnQpLA0KICBQTFogICAgICAgICAgICAgICAgICA9IFBSUy5Xb2huc2l0elBMWiwNCiAgT3J0ICAgI" +
                        "CAgICAgICAgICAgICAgPSBQUlMuV29obnNpdHpPcnQsDQogIEJlbGVnTnIgICAgICAgICAgICAgID0gQ" +
                        "lVDLkJlbGVnTnIsDQogIEVtcGxveWVlTmFtZSAgICAgICAgID0gVVNSLkxhc3ROYW1lICsgSVNOVUxMK" +
                        "CcsICcgKyBVU1IuRmlyc3ROYW1lLCAnJykgKyBJU05VTEwoJyAoJyArIFVTUi5QaG9uZSArICcpJywgJ" +
                        "ycpLA0KICBSZW1hcmsgICAgICAgICAgICAgICA9IEJVQy5SZW1hcmssDQogIFZhbHV0YURhdHVtICAgI" +
                        "CAgICAgID0gQlVDLlZhbHV0YURhdHVtLA0KICBCYXJiZWxlZ0RhdHVtICAgICAgICA9IEJVQy5CYXJiZ" +
                        "WxlZ0RhdHVtDQpGUk9NIGRiby5GYUxlaXN0dW5nICAgICAgICAgICAgICAgICAgICAgIEZBTCAgV0lUS" +
                        "ChSRUFEVU5DT01NSVRURUQpDQogIElOTkVSIEpPSU4gZGJvLnZ3UGVyc29uICAgICAgICAgICAgICAgI" +
                        "FBSUyAgV0lUSChSRUFEVU5DT01NSVRURUQpIE9OIFBSUy5CYVBlcnNvbklEID0gRkFMLkJhUGVyc29uS" +
                        "UQNCiAgSU5ORVIgSk9JTiBkYm8uQmdGaW5hbnpwbGFuICAgICAgICAgICAgRlBMICBXSVRIKFJFQURVT" +
                        "kNPTU1JVFRFRCkgT04gRlBMLkZhTGVpc3R1bmdJRCA9IEZBTC5GYUxlaXN0dW5nSUQNCiAgSU5ORVIgS" +
                        "k9JTiBkYm8uQmdGaW5hbnpwbGFuX0JhUGVyc29uICAgRkJQICBXSVRIKFJFQURVTkNPTU1JVFRFRCkgT" +
                        "04gRkJQLkJnRmluYW56cGxhbklEID0gRlBMLkJnRmluYW56cGxhbklEDQogICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEZCUC5Jc" +
                        "3RVbnRlcnN0dWV0enQgPSAxDQogIElOTkVSIEpPSU4gZGJvLkJnQnVkZ2V0ICAgICAgICAgICAgICAgI" +
                        "EJERyAgV0lUSChSRUFEVU5DT01NSVRURUQpIE9OIEJERy5CZ0ZpbmFuenBsYW5JRCA9IEZQTC5CZ0Zpb" +
                        "mFuenBsYW5JRA0KICBJTk5FUiBKT0lOIGRiby5LYkJ1Y2h1bmcgICAgICAgICAgICAgICBCVUMgIFdJV" +
                        "EgoUkVBRFVOQ09NTUlUVEVEKSBPTiBCVUMuQmdCdWRnZXRJRCA9IEJERy5CZ0J1ZGdldElEDQogIElOT" +
                        "kVSIEpPSU4gZGJvLktiQnVjaHVuZ0tvc3RlbmFydCAgICAgIEtCSyAgV0lUSChSRUFEVU5DT01NSVRUR" +
                        "UQpIE9OIEtCSy5LYkJ1Y2h1bmdJRCA9IEJVQy5LYkJ1Y2h1bmdJRA0KICBJTk5FUiBKT0lOIGRiby5YV" +
                        "XNlciAgICAgICAgICAgICAgICAgICBVU1IgIFdJVEgoUkVBRFVOQ09NTUlUVEVEKSBPTiBVU1IuVXNlc" +
                        "klEID0gRkFMLlVzZXJJRA0KICBMRUZUICBKT0lOIGRiby5YVXNlciAgICAgICAgICAgICAgICAgICBLV" +
                        "VNSIFdJVEgoUkVBRFVOQ09NTUlUVEVEKSBPTiBLVVNSLlVzZXJJRCA9IEJVQy5CYXJiZWxlZ1VzZXJJR" +
                        "A0KICBMRUZUICBKT0lOIGRiby5CZ0tvc3RlbmFydCAgICAgICAgICAgICBCR0sgIFdJVEgoUkVBRFVOQ" +
                        "09NTUlUVEVEKSBPTiBCR0suQmdLb3N0ZW5hcnRJRCA9IEtCSy5CZ0tvc3RlbmFydElEDQogIExFRlQgI" +
                        "EpPSU4gZGJvLktiS29zdGVuc3RlbGxlCSAgICAgICAgIEtTVCAgV0lUSChSRUFEVU5DT01NSVRURUQpI" +
                        "E9OIEtTVC5LYktvc3RlbnN0ZWxsZUlEID0gS0JLLktiS29zdGVuc3RlbGxlSUQNCiAgTEVGVCAgSk9JT" +
                        "iBkYm8uS2JLb3N0ZW5zdGVsbGVfQmFQZXJzb24gS1NQICBXSVRIKFJFQURVTkNPTU1JVFRFRCkgT04gS" +
                        "1NQLkJhUGVyc29uSUQgPSBQUlMuQmFQZXJzb25JRA0KICBMRUZUICBKT0lOIGRiby5LYktvc3RlbnN0Z" +
                        "WxsZSAgICAgICAgICBLUFIgIFdJVEgoUkVBRFVOQ09NTUlUVEVEKSBPTiBLUFIuS2JLb3N0ZW5zdGVsb" +
                        "GVJRCA9IEtTUC5LYktvc3RlbnN0ZWxsZUlEDQpXSEVSRSBCVUMuS2JCdWNodW5nSUQgPSBAS2JCdWNod" +
                        "W5nSUQNCk9SREVSIEJZIE5hbWVLb3N0ZW5hcnQgQVNDLCBCZXRyYWcgREVTQzs=";
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
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNameFbKostenstelle = new DevExpress.XtraReports.UI.XRLabel();
            this.txtIntern = new DevExpress.XtraReports.UI.XRLabel();
            this.Label18 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label17 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label16 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNameFbKostenart = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label15 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtStrasse = new DevExpress.XtraReports.UI.XRLabel();
            this.FullName1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label14 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtBetrag,
                        this.txtNameFbKostenstelle,
                        this.txtIntern});
            this.Detail.Height = 35;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBackColor = false;
            this.Detail.ParentStyleUsing.UseBorderColor = false;
            this.Detail.ParentStyleUsing.UseBorders = false;
            this.Detail.ParentStyleUsing.UseBorderWidth = false;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.ParentStyleUsing.UseForeColor = false;
            this.Detail.PrintOnEmptyDataSource = false;
            this.Detail.Visible = false;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Label18,
                        this.Label17,
                        this.Label16,
                        this.txtNameFbKostenart});
            this.GroupHeader1.Height = 66;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            this.GroupHeader1.Visible = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel4,
                        this.xrLabel5,
                        this.xrLabel1,
                        this.xrLabel17,
                        this.Label6});
            this.ReportFooter.Height = 161;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.PrintAtBottom = true;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel16,
                        this.xrLabel15,
                        this.xrLabel14,
                        this.xrLabel13,
                        this.xrLabel12,
                        this.xrLabel11,
                        this.xrLabel10,
                        this.xrLabel9,
                        this.xrLabel8,
                        this.xrLabel7,
                        this.xrLabel3,
                        this.xrLabel2,
                        this.Label15,
                        this.txtStrasse,
                        this.FullName1,
                        this.Label14,
                        this.Label4,
                        this.Label3,
                        this.Label2,
                        this.Label1});
            this.ReportHeader.Height = 421;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLine1,
                        this.xrLabel25,
                        this.xrLabel24,
                        this.xrLabel23,
                        this.xrLabel22,
                        this.xrLabel21});
            this.GroupFooter1.Height = 85;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "")});
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(667, 0);
            this.txtBetrag.Multiline = true;
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(83, 20);
            xrSummary1.FormatString = "{0:0.00}";
            this.txtBetrag.Summary = xrSummary1;
            this.txtBetrag.Text = "txtBetrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtNameFbKostenstelle
            // 
            this.txtNameFbKostenstelle.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameKostenstelle", "")});
            this.txtNameFbKostenstelle.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNameFbKostenstelle.ForeColor = System.Drawing.Color.Black;
            this.txtNameFbKostenstelle.Location = new System.Drawing.Point(433, 0);
            this.txtNameFbKostenstelle.Multiline = true;
            this.txtNameFbKostenstelle.Name = "txtNameFbKostenstelle";
            this.txtNameFbKostenstelle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBackColor = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBorderColor = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBorders = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBorderWidth = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseFont = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseForeColor = false;
            this.txtNameFbKostenstelle.Size = new System.Drawing.Size(234, 20);
            this.txtNameFbKostenstelle.Text = "txtNameFbKostenstelle";
            // 
            // txtIntern
            // 
            this.txtIntern.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Buchungstext", "")});
            this.txtIntern.Font = new System.Drawing.Font("Arial", 10F);
            this.txtIntern.ForeColor = System.Drawing.Color.Black;
            this.txtIntern.Location = new System.Drawing.Point(33, 0);
            this.txtIntern.Multiline = true;
            this.txtIntern.Name = "txtIntern";
            this.txtIntern.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtIntern.ParentStyleUsing.UseBackColor = false;
            this.txtIntern.ParentStyleUsing.UseBorderColor = false;
            this.txtIntern.ParentStyleUsing.UseBorders = false;
            this.txtIntern.ParentStyleUsing.UseBorderWidth = false;
            this.txtIntern.ParentStyleUsing.UseFont = false;
            this.txtIntern.ParentStyleUsing.UseForeColor = false;
            this.txtIntern.Size = new System.Drawing.Size(400, 20);
            this.txtIntern.Text = "txtIntern";
            // 
            // Label18
            // 
            this.Label18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Buchungstext", "")});
            this.Label18.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label18.ForeColor = System.Drawing.Color.Black;
            this.Label18.Location = new System.Drawing.Point(667, 42);
            this.Label18.Name = "Label18";
            this.Label18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label18.ParentStyleUsing.UseBackColor = false;
            this.Label18.ParentStyleUsing.UseBorderColor = false;
            this.Label18.ParentStyleUsing.UseBorders = false;
            this.Label18.ParentStyleUsing.UseBorderWidth = false;
            this.Label18.ParentStyleUsing.UseFont = false;
            this.Label18.ParentStyleUsing.UseForeColor = false;
            this.Label18.Size = new System.Drawing.Size(83, 19);
            xrSummary2.FormatString = "{0}";
            this.Label18.Summary = xrSummary2;
            this.Label18.Text = "Betrag";
            this.Label18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label17
            // 
            this.Label17.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label17.ForeColor = System.Drawing.Color.Black;
            this.Label17.Location = new System.Drawing.Point(433, 42);
            this.Label17.Name = "Label17";
            this.Label17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label17.ParentStyleUsing.UseBackColor = false;
            this.Label17.ParentStyleUsing.UseBorderColor = false;
            this.Label17.ParentStyleUsing.UseBorders = false;
            this.Label17.ParentStyleUsing.UseBorderWidth = false;
            this.Label17.ParentStyleUsing.UseFont = false;
            this.Label17.ParentStyleUsing.UseForeColor = false;
            this.Label17.Size = new System.Drawing.Size(234, 19);
            this.Label17.Text = "Kostenstelle";
            // 
            // Label16
            // 
            this.Label16.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.Label16.ForeColor = System.Drawing.Color.Black;
            this.Label16.Location = new System.Drawing.Point(33, 42);
            this.Label16.Name = "Label16";
            this.Label16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label16.ParentStyleUsing.UseBackColor = false;
            this.Label16.ParentStyleUsing.UseBorderColor = false;
            this.Label16.ParentStyleUsing.UseBorders = false;
            this.Label16.ParentStyleUsing.UseBorderWidth = false;
            this.Label16.ParentStyleUsing.UseFont = false;
            this.Label16.ParentStyleUsing.UseForeColor = false;
            this.Label16.Size = new System.Drawing.Size(400, 19);
            this.Label16.Text = "Buchungstext";
            // 
            // txtNameFbKostenart
            // 
            this.txtNameFbKostenart.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameKostenart", "")});
            this.txtNameFbKostenart.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNameFbKostenart.ForeColor = System.Drawing.Color.Black;
            this.txtNameFbKostenart.Location = new System.Drawing.Point(17, 17);
            this.txtNameFbKostenart.Multiline = true;
            this.txtNameFbKostenart.Name = "txtNameFbKostenart";
            this.txtNameFbKostenart.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNameFbKostenart.ParentStyleUsing.UseBackColor = false;
            this.txtNameFbKostenart.ParentStyleUsing.UseBorderColor = false;
            this.txtNameFbKostenart.ParentStyleUsing.UseBorders = false;
            this.txtNameFbKostenart.ParentStyleUsing.UseBorderWidth = false;
            this.txtNameFbKostenart.ParentStyleUsing.UseFont = false;
            this.txtNameFbKostenart.ParentStyleUsing.UseForeColor = false;
            this.txtNameFbKostenart.Size = new System.Drawing.Size(733, 20);
            this.txtNameFbKostenart.Text = "txtNameFbKostenart";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.Location = new System.Drawing.Point(258, 25);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.ParentStyleUsing.UseForeColor = false;
            this.xrLabel4.Size = new System.Drawing.Size(492, 19);
            this.xrLabel4.Text = "Für die Sozialdienste Worb   ...................................................." +
                "........................";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel5
            // 
            this.xrLabel5.CanShrink = true;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.Location = new System.Drawing.Point(17, 25);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(83, 25);
            this.xrLabel5.Text = "[Org_Ort],";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ValutaDatum", "{0:dd.MM.yyyy}")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.Location = new System.Drawing.Point(100, 25);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(100, 25);
            this.xrLabel1.Text = "xrLabel1";
            // 
            // xrLabel17
            // 
            this.xrLabel17.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel17.ForeColor = System.Drawing.Color.Black;
            this.xrLabel17.Location = new System.Drawing.Point(317, 142);
            this.xrLabel17.Name = "xrLabel17";
            this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel17.ParentStyleUsing.UseBackColor = false;
            this.xrLabel17.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel17.ParentStyleUsing.UseBorders = false;
            this.xrLabel17.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel17.ParentStyleUsing.UseFont = false;
            this.xrLabel17.ParentStyleUsing.UseForeColor = false;
            this.xrLabel17.Size = new System.Drawing.Size(433, 19);
            this.xrLabel17.Text = "Unterschrift  ..................................................................." +
                ".....................";
            this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 10F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(317, 83);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(433, 19);
            this.Label6.Text = "Betrag erhalten am  ............................................................." +
                "...............";
            this.Label6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel16
            // 
            this.xrLabel16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel16.ForeColor = System.Drawing.Color.Black;
            this.xrLabel16.Location = new System.Drawing.Point(8, 158);
            this.xrLabel16.Name = "xrLabel16";
            this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel16.ParentStyleUsing.UseBackColor = false;
            this.xrLabel16.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel16.ParentStyleUsing.UseBorders = false;
            this.xrLabel16.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel16.ParentStyleUsing.UseFont = false;
            this.xrLabel16.ParentStyleUsing.UseForeColor = false;
            this.xrLabel16.Size = new System.Drawing.Size(62, 27);
            this.xrLabel16.Text = "Beleg :";
            // 
            // xrLabel15
            // 
            this.xrLabel15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel15.ForeColor = System.Drawing.Color.Black;
            this.xrLabel15.Location = new System.Drawing.Point(8, 183);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.ParentStyleUsing.UseBackColor = false;
            this.xrLabel15.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel15.ParentStyleUsing.UseBorders = false;
            this.xrLabel15.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel15.ParentStyleUsing.UseFont = false;
            this.xrLabel15.ParentStyleUsing.UseForeColor = false;
            this.xrLabel15.Size = new System.Drawing.Size(62, 27);
            this.xrLabel15.Text = "Klient :";
            // 
            // xrLabel14
            // 
            this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "FullName", "")});
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel14.ForeColor = System.Drawing.Color.Black;
            this.xrLabel14.Location = new System.Drawing.Point(75, 183);
            this.xrLabel14.Multiline = true;
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.ParentStyleUsing.UseBackColor = false;
            this.xrLabel14.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel14.ParentStyleUsing.UseBorders = false;
            this.xrLabel14.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel14.ParentStyleUsing.UseFont = false;
            this.xrLabel14.ParentStyleUsing.UseForeColor = false;
            this.xrLabel14.Size = new System.Drawing.Size(269, 27);
            this.xrLabel14.Text = "xrLabel14";
            // 
            // xrLabel13
            // 
            this.xrLabel13.BackColor = System.Drawing.Color.PeachPuff;
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel13.ForeColor = System.Drawing.Color.Black;
            this.xrLabel13.Location = new System.Drawing.Point(358, 158);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.ParentStyleUsing.UseBackColor = false;
            this.xrLabel13.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel13.ParentStyleUsing.UseBorders = false;
            this.xrLabel13.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel13.ParentStyleUsing.UseFont = false;
            this.xrLabel13.ParentStyleUsing.UseForeColor = false;
            this.xrLabel13.Size = new System.Drawing.Size(134, 19);
            this.xrLabel13.Text = "Auszahlungsmonat";
            // 
            // xrLabel12
            // 
            this.xrLabel12.BackColor = System.Drawing.Color.PeachPuff;
            this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameYearMonth", "")});
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel12.ForeColor = System.Drawing.Color.Black;
            this.xrLabel12.Location = new System.Drawing.Point(492, 158);
            this.xrLabel12.Multiline = true;
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.ParentStyleUsing.UseBackColor = false;
            this.xrLabel12.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel12.ParentStyleUsing.UseBorders = false;
            this.xrLabel12.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel12.ParentStyleUsing.UseFont = false;
            this.xrLabel12.ParentStyleUsing.UseForeColor = false;
            this.xrLabel12.Size = new System.Drawing.Size(258, 20);
            this.xrLabel12.Text = "xrLabel12";
            // 
            // xrLabel11
            // 
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KbBuchungID", "")});
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.ForeColor = System.Drawing.Color.Black;
            this.xrLabel11.Location = new System.Drawing.Point(75, 158);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.ParentStyleUsing.UseBackColor = false;
            this.xrLabel11.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel11.ParentStyleUsing.UseBorders = false;
            this.xrLabel11.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel11.ParentStyleUsing.UseFont = false;
            this.xrLabel11.ParentStyleUsing.UseForeColor = false;
            this.xrLabel11.Size = new System.Drawing.Size(269, 27);
            this.xrLabel11.Text = "xrLabel11";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel10.ForeColor = System.Drawing.Color.Black;
            this.xrLabel10.Location = new System.Drawing.Point(358, 179);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.ParentStyleUsing.UseBackColor = false;
            this.xrLabel10.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel10.ParentStyleUsing.UseBorders = false;
            this.xrLabel10.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel10.ParentStyleUsing.UseFont = false;
            this.xrLabel10.ParentStyleUsing.UseForeColor = false;
            this.xrLabel10.Size = new System.Drawing.Size(134, 17);
            this.xrLabel10.Text = "Valutadatum";
            // 
            // xrLabel9
            // 
            this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ValutaDatum", "{0:dd.MM.yyyy}")});
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel9.ForeColor = System.Drawing.Color.Black;
            this.xrLabel9.Location = new System.Drawing.Point(492, 179);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.ParentStyleUsing.UseBackColor = false;
            this.xrLabel9.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel9.ParentStyleUsing.UseBorders = false;
            this.xrLabel9.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel9.ParentStyleUsing.UseFont = false;
            this.xrLabel9.ParentStyleUsing.UseForeColor = false;
            this.xrLabel9.Size = new System.Drawing.Size(258, 17);
            xrSummary3.FormatString = "{0:dd.MM.yyyy}";
            this.xrLabel9.Summary = xrSummary3;
            this.xrLabel9.Text = "xrLabel9";
            // 
            // xrLabel8
            // 
            this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "EmployeeName", "")});
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel8.ForeColor = System.Drawing.Color.Black;
            this.xrLabel8.Location = new System.Drawing.Point(492, 200);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.ParentStyleUsing.UseBackColor = false;
            this.xrLabel8.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel8.ParentStyleUsing.UseBorders = false;
            this.xrLabel8.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel8.ParentStyleUsing.UseFont = false;
            this.xrLabel8.ParentStyleUsing.UseForeColor = false;
            this.xrLabel8.Size = new System.Drawing.Size(258, 16);
            this.xrLabel8.Text = "xrLabel8";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel7.ForeColor = System.Drawing.Color.Black;
            this.xrLabel7.Location = new System.Drawing.Point(358, 200);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseBackColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorders = false;
            this.xrLabel7.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.ParentStyleUsing.UseForeColor = false;
            this.xrLabel7.Size = new System.Drawing.Size(134, 16);
            this.xrLabel7.Text = "Sozialarbeiter";
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Remark", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(492, 242);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(258, 17);
            this.xrLabel3.Text = "xrLabel3";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.Location = new System.Drawing.Point(358, 242);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseBackColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel2.ParentStyleUsing.UseBorders = false;
            this.xrLabel2.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.ParentStyleUsing.UseForeColor = false;
            this.xrLabel2.Size = new System.Drawing.Size(134, 17);
            this.xrLabel2.Text = "Bemerkung";
            // 
            // Label15
            // 
            this.Label15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "PLZOrt", "")});
            this.Label15.Font = new System.Drawing.Font("Arial", 10F);
            this.Label15.ForeColor = System.Drawing.Color.Black;
            this.Label15.Location = new System.Drawing.Point(33, 392);
            this.Label15.Name = "Label15";
            this.Label15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label15.ParentStyleUsing.UseBackColor = false;
            this.Label15.ParentStyleUsing.UseBorderColor = false;
            this.Label15.ParentStyleUsing.UseBorders = false;
            this.Label15.ParentStyleUsing.UseBorderWidth = false;
            this.Label15.ParentStyleUsing.UseFont = false;
            this.Label15.ParentStyleUsing.UseForeColor = false;
            this.Label15.Size = new System.Drawing.Size(717, 19);
            this.Label15.Text = "Label15";
            // 
            // txtStrasse
            // 
            this.txtStrasse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Strasse", "")});
            this.txtStrasse.Font = new System.Drawing.Font("Arial", 10F);
            this.txtStrasse.ForeColor = System.Drawing.Color.Black;
            this.txtStrasse.Location = new System.Drawing.Point(33, 367);
            this.txtStrasse.Multiline = true;
            this.txtStrasse.Name = "txtStrasse";
            this.txtStrasse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtStrasse.ParentStyleUsing.UseBackColor = false;
            this.txtStrasse.ParentStyleUsing.UseBorderColor = false;
            this.txtStrasse.ParentStyleUsing.UseBorders = false;
            this.txtStrasse.ParentStyleUsing.UseBorderWidth = false;
            this.txtStrasse.ParentStyleUsing.UseFont = false;
            this.txtStrasse.ParentStyleUsing.UseForeColor = false;
            this.txtStrasse.Size = new System.Drawing.Size(717, 19);
            this.txtStrasse.Text = "Strasse";
            // 
            // FullName1
            // 
            this.FullName1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AuszuzahlenAn", "")});
            this.FullName1.Font = new System.Drawing.Font("Arial", 10F);
            this.FullName1.ForeColor = System.Drawing.Color.Black;
            this.FullName1.Location = new System.Drawing.Point(33, 342);
            this.FullName1.Multiline = true;
            this.FullName1.Name = "FullName1";
            this.FullName1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.FullName1.ParentStyleUsing.UseBackColor = false;
            this.FullName1.ParentStyleUsing.UseBorderColor = false;
            this.FullName1.ParentStyleUsing.UseBorders = false;
            this.FullName1.ParentStyleUsing.UseBorderWidth = false;
            this.FullName1.ParentStyleUsing.UseFont = false;
            this.FullName1.ParentStyleUsing.UseForeColor = false;
            this.FullName1.Size = new System.Drawing.Size(717, 19);
            this.FullName1.Text = "FullName1";
            // 
            // Label14
            // 
            this.Label14.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.Label14.ForeColor = System.Drawing.Color.Black;
            this.Label14.Location = new System.Drawing.Point(17, 317);
            this.Label14.Name = "Label14";
            this.Label14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label14.ParentStyleUsing.UseBackColor = false;
            this.Label14.ParentStyleUsing.UseBorderColor = false;
            this.Label14.ParentStyleUsing.UseBorders = false;
            this.Label14.ParentStyleUsing.UseBorderWidth = false;
            this.Label14.ParentStyleUsing.UseFont = false;
            this.Label14.ParentStyleUsing.UseForeColor = false;
            this.Label14.Size = new System.Drawing.Size(125, 23);
            this.Label14.Text = "Auszahlung an:";
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Gainsboro;
            this.Label4.BorderColor = System.Drawing.Color.Black;
            this.Label4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
                        | DevExpress.XtraPrinting.BorderSide.Right) 
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Label4.Font = new System.Drawing.Font("Arial", 18F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(0, 98);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(750, 40);
            this.Label4.Text = "Kassenbeleg / Barzahlung";
            this.Label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // Label3
            // 
            this.Label3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_PLZOrt", "")});
            this.Label3.Font = new System.Drawing.Font("Arial", 11F);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(542, 25);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(200, 23);
            this.Label3.Text = "Org_PLZOrt";
            // 
            // Label2
            // 
            this.Label2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Adresse", "")});
            this.Label2.Font = new System.Drawing.Font("Arial", 11F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(542, 0);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(200, 23);
            this.Label2.Text = "Org_Adresse";
            // 
            // Label1
            // 
            this.Label1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Org_Name", "")});
            this.Label1.Font = new System.Drawing.Font("Arial", 12F);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(492, 39);
            this.Label1.Text = "Org_Name";
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Black;
            this.xrLine1.LineWidth = 2;
            this.xrLine1.Location = new System.Drawing.Point(0, 8);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(750, 4);
            // 
            // xrLabel25
            // 
            this.xrLabel25.BackColor = System.Drawing.Color.PeachPuff;
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel25.ForeColor = System.Drawing.Color.Black;
            this.xrLabel25.Location = new System.Drawing.Point(383, 17);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.ParentStyleUsing.UseBackColor = false;
            this.xrLabel25.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel25.ParentStyleUsing.UseBorders = false;
            this.xrLabel25.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel25.ParentStyleUsing.UseFont = false;
            this.xrLabel25.ParentStyleUsing.UseForeColor = false;
            this.xrLabel25.Size = new System.Drawing.Size(267, 27);
            this.xrLabel25.Text = "Auszuzahlender Betrag ";
            // 
            // xrLabel24
            // 
            this.xrLabel24.BackColor = System.Drawing.Color.PeachPuff;
            this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "")});
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.xrLabel24.ForeColor = System.Drawing.Color.Black;
            this.xrLabel24.Location = new System.Drawing.Point(650, 17);
            this.xrLabel24.Multiline = true;
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.ParentStyleUsing.UseBackColor = false;
            this.xrLabel24.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel24.ParentStyleUsing.UseBorders = false;
            this.xrLabel24.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel24.ParentStyleUsing.UseFont = false;
            this.xrLabel24.ParentStyleUsing.UseForeColor = false;
            this.xrLabel24.Size = new System.Drawing.Size(100, 27);
            xrSummary4.FormatString = "{0:0.00}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrLabel24.Summary = xrSummary4;
            this.xrLabel24.Text = "xrLabel24";
            this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel23
            // 
            this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameKostenstelle", "")});
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel23.Location = new System.Drawing.Point(475, 50);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.ParentStyleUsing.UseFont = false;
            this.xrLabel23.Size = new System.Drawing.Size(175, 17);
            this.xrLabel23.Text = "xrLabel23";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel22
            // 
            this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "FullName", "")});
            this.xrLabel22.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel22.Location = new System.Drawing.Point(200, 50);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel22.ParentStyleUsing.UseFont = false;
            this.xrLabel22.Size = new System.Drawing.Size(267, 17);
            this.xrLabel22.Text = "xrLabel22";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel21
            // 
            this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Verfalldatum", "{0:dd.MM.yyyy}")});
            this.xrLabel21.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel21.Location = new System.Drawing.Point(650, 50);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.ParentStyleUsing.UseFont = false;
            this.xrLabel21.Size = new System.Drawing.Size(100, 17);
            this.xrLabel21.Text = "xrLabel21";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail,
                        this.GroupHeader1,
                        this.ReportFooter,
                        this.ReportHeader,
                        this.GroupFooter1});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(39, 34, 39, 39);
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
		<DisplayText>Belegnummer:</DisplayText>
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
		<FieldName>KbBuchungID</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>Belegnummer</DisplayText>
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
</NewDataSet>' , SQLquery =  N'DECLARE @KbBuchungID INT;
SET @KbBuchungID = {KbBuchungID}; -- (TestCase)13441

SELECT DISTINCT
  Org_Name             = ISNULL(CONVERT(VARCHAR(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Organisation'', GETDATE())), ''''),
  Org_Adresse          = ISNULL(CONVERT(VARCHAR(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Adresse'', GETDATE())), ''''),
  Org_PLZ              = ISNULL(CONVERT(VARCHAR(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', GETDATE())), ''''),
  Org_Ort              = ISNULL(CONVERT(VARCHAR(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', GETDATE())), ''''),
  Org_PLZOrt           = ISNULL(CONVERT(VARCHAR(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', GETDATE())) + '' '', '''') +
                         ISNULL(CONVERT(VARCHAR(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', GETDATE())), ''''),
  KbAuszahlungsartCode = BUC.KbAuszahlungsartCode,
  KbBuchungID          = BUC.KbBuchungID,
  KbBuchungStatusCode  = BUC.KbBuchungStatusCode,
  NameKbBuchungsStatus = dbo.fnLOVText(''KbBuchungsStatus'', BUC.KbBuchungStatusCode),
  NameKbAuszahlungsArt = dbo.fnLOVText(''KbAuszahlungsArt'', BUC.KbAuszahlungsartCode),
  NameYearMonth        = dbo.fnXMonat(BDG.Monat) + '' '' + CONVERT(VARCHAR, BDG.Jahr),
  Verfalldatum         = DATEADD(DAY, 5, BUC.ValutaDatum),
  KbBuchungKostensrtID = KBK.KbBuchungKostenartID,
  Buchungstext         = KBK.Buchungstext,
  Betrag               = KBK.Betrag,
  NameKostenart        = BGK.Name,
  NameKostenstelle     = KST.Nr,
  KBKPersonID          = KBK.BaPersonID,
  KbKostenstelleID     = KBK.KbKostenstelleID,
  NameKassier          = KUSR.LastName + ISNULL('', '' + KUSR.FirstName, '''') + ISNULL('' ('' + KUSR.Phone + '')'', ''''),
  FullName             = PRS.NameVorname,
  AuszuzahlenAn        = ISNULL(NULLIF(BUC.BeguenstigtName, ''''), PRS.NameVorname),
  Strasse              = ISNULL(NULLIF(BUC.BeguenstigtStrasse, ''''), PRS.WohnsitzStrasseHausNr),
  PLZOrt               = ISNULL(NULLIF(BUC.BeguenstigtOrt, ''''), PRS.WohnsitzPLZOrt),
  PLZ                  = PRS.WohnsitzPLZ,
  Ort                  = PRS.WohnsitzOrt,
  BelegNr              = BUC.BelegNr,
  EmployeeName         = USR.LastName + ISNULL('', '' + USR.FirstName, '''') + ISNULL('' ('' + USR.Phone + '')'', ''''),
  Remark               = BUC.Remark,
  ValutaDatum          = BUC.ValutaDatum,
  BarbelegDatum        = BUC.BarbelegDatum
FROM dbo.FaLeistung                      FAL  WITH(READUNCOMMITTED)
  INNER JOIN dbo.vwPerson                PRS  WITH(READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID
  INNER JOIN dbo.BgFinanzplan            FPL  WITH(READUNCOMMITTED) ON FPL.FaLeistungID = FAL.FaLeistungID
  INNER JOIN dbo.BgFinanzplan_BaPerson   FBP  WITH(READUNCOMMITTED) ON FBP.BgFinanzplanID = FPL.BgFinanzplanID
                                                                   AND FBP.IstUnterstuetzt = 1
  INNER JOIN dbo.BgBudget                BDG  WITH(READUNCOMMITTED) ON BDG.BgFinanzplanID = FPL.BgFinanzplanID
  INNER JOIN dbo.KbBuchung               BUC  WITH(READUNCOMMITTED) ON BUC.BgBudgetID = BDG.BgBudgetID
  INNER JOIN dbo.KbBuchungKostenart      KBK  WITH(READUNCOMMITTED) ON KBK.KbBuchungID = BUC.KbBuchungID
  INNER JOIN dbo.XUser                   USR  WITH(READUNCOMMITTED) ON USR.UserID = FAL.UserID
  LEFT  JOIN dbo.XUser                   KUSR WITH(READUNCOMMITTED) ON KUSR.UserID = BUC.BarbelegUserID
  LEFT  JOIN dbo.BgKostenart             BGK  WITH(READUNCOMMITTED) ON BGK.BgKostenartID = KBK.BgKostenartID
  LEFT  JOIN dbo.KbKostenstelle	         KST  WITH(READUNCOMMITTED) ON KST.KbKostenstelleID = KBK.KbKostenstelleID
WHERE BUC.KbBuchungID = @KbBuchungID
ORDER BY NameKostenart ASC, Betrag DESC;' , ContextForms =  N'FrmKasse' , ParentReportName =  null , ReportSortKey = 10
FROM XQuery QRY
WHERE QRY.QueryName LIKE  N'ShKassenbeleg' ;


