-- Insert Script for ShUebersichtMonatsbudgetML
DELETE FROM XQuery WHERE QueryName LIKE 'ShUebersichtMonatsbudgetML' OR ParentReportName LIKE 'ShUebersichtMonatsbudgetML'
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShUebersichtMonatsbudgetML' ,  N'SH - Übersicht Monatsbudget (mehrsprachig)' , 1,  N'/// <XRTypeInfo>
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
        private DevExpress.XtraReports.UI.XRRichText xrRichText1;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel xrLabelTitel;
        private DevExpress.XtraReports.UI.Subreport ShUebersichtMonatsbudgetML_Zahlungen;
        private DevExpress.XtraReports.UI.Subreport ShUebersichtMonatsbudgetML_Uebersicht;
        private DevExpress.XtraReports.UI.Subreport ShUebersichtMonatsbudgetML_Budget;
        private DevExpress.XtraReports.UI.Subreport ShUebersichtMonatsbudgetML_Unterst;
        private DevExpress.XtraReports.UI.XRLabel txtZust;
        private DevExpress.XtraReports.UI.XRLabel txtOrt;
        private DevExpress.XtraReports.UI.XRLabel txtStrasse;
        private DevExpress.XtraReports.UI.XRLabel txtStatus;
        private DevExpress.XtraReports.UI.XRLabel txtName;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel lblSig;
        private DevExpress.XtraReports.UI.XRLabel lblSigLoc;
        private DevExpress.XtraReports.UI.XRLabel lblConf;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel lblFooterLeft;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAACAAAAAQAAAIwBRGV2RXhwcmVzc" +
                        "y5YdHJhUmVwb3J0cy5VSS5TZXJpYWxpemFibGVTdHJpbmcsIERldkV4cHJlc3MuWHRyYVJlcG9ydHMud" +
                        "jYuMiwgVmVyc2lvbj02LjIuNi4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPTc5ODY4Y" +
                        "jgxNDdiNWVhZTRQE7ROpIBtm7YAAAAANwAAAK4BAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlA" +
                        "GMAdABTAHQAYQB0AGUAbQBlAG4AdAAAAAAAJngAcgBSAGkAYwBoAFQAZQB4AHQAMQAuAFIAdABmAFQAZ" +
                        "QB4AHQAUwkAAAHQEkRFQ0xBUkUgQFNwcmFjaENvZGUgSU5UDQpTRUxFQ1QgQFNwcmFjaENvZGUgPSBQL" +
                        "lZlcnN0YWVuZGlndW5nU3ByYWNoQ29kZSANCkZST00gQmdCdWRnZXQgQg0KICBMRUZUIE9VVEVSIEpPS" +
                        "U4gQmdGaW5hbnpwbGFuIEZQIE9OIEZQLkJnRmluYW56cGxhbklEID0gQi5CZ0ZpbmFuenBsYW5JRA0KI" +
                        "CBMRUZUIE9VVEVSIEpPSU4gRmFMZWlzdHVuZyBMRUkgT04gTEVJLkZhTGVpc3R1bmdJRCA9IEZQLkZhT" +
                        "GVpc3R1bmdJRA0KICBMRUZUIE9VVEVSIEpPSU4gQmFQZXJzb24gUCBPTiBQLkJhUGVyc29uSUQgPSBMR" +
                        "UkuQmFQZXJzb25JRA0KV0hFUkUgQi5CZ0J1ZGdldElEID0gbnVsbA0KSUYgQFNwcmFjaENvZGUgSVMgT" +
                        "lVMTCBTRVQgQFNwcmFjaENvZGUgPSAxDQoNCg0KU0VMRUNUDQogIFRleHRfVGl0ZWwgPSBkYm8uZm5HZ" +
                        "XRNTFRleHRGcm9tTmFtZSgnUmVwb3J0X0J1ZGdldCcsICdNb25hdHNidWRnZXQnLCBAU3ByYWNoQ29kZ" +
                        "SkgKyAnICcgKyANCiAgICBDb252ZXJ0KHZhcmNoYXIsIEJCRy5KYWhyKSArICcgJyArIA0KICAgIGRib" +
                        "y5mblhNb25hdE1MKEJCRy5Nb25hdCwgQFNwcmFjaENvZGUpLA0KICBUZXh0X0Jlc3RhZXRpZ3VuZyA9I" +
                        "GRiby5mbkdldE1MVGV4dEZyb21OYW1lKCdSZXBvcnRfQnVkZ2V0JywgJ0Jlc3RhZXRpZ3VuZycsIEBTc" +
                        "HJhY2hDb2RlKSwNCiAgVGV4dF9VbnRlcnNjaHJpZnQgPSBkYm8uZm5HZXRNTFRleHRGcm9tTmFtZSgnU" +
                        "mVwb3J0X0J1ZGdldCcsICdVbnRlcnNjaHJpZnRLbGllbnQnLCBAU3ByYWNoQ29kZSksDQogIFRleHRfT" +
                        "3J0RGF0dW0gPSBkYm8uZm5HZXRNTFRleHRGcm9tTmFtZSgnUmVwb3J0X0J1ZGdldCcsICdPcnREYXR1b" +
                        "ScsIEBTcHJhY2hDb2RlKSwNCiAgQkJHLkJnQnVkZ2V0SWQsDQogIFN0YXR1c0NvZGUgPSBCQkcuQmdCZ" +
                        "XdpbGxpZ3VuZ1N0YXR1c0NvZGUsDQogIFN0YXR1cyA9IA0KICAgIGRiby5mbkdldE1MVGV4dEZyb21OY" +
                        "W1lKCdSZXBvcnRfQnVkZ2V0JywgJ1N0YXR1cycsIEBTcHJhY2hDb2RlKSArICc6ICcgKyANCiAgICBkY" +
                        "m8uZm5MT1ZNTFRleHQoJ0JnQmV3aWxsaWd1bmdTdGF0dXMnLCBCQkcuQmdCZXdpbGxpZ3VuZ1N0YXR1c" +
                        "0NvZGUsIEBTcHJhY2hDb2RlKSwNCiAgTmFtZSA9IGlzbnVsbChQUlMuVm9ybmFtZSsnICcsJycpK2lzb" +
                        "nVsbChQUlMuTmFtZSwnJykgKyBpc051bGwoJygnICsgUFJTLk5hdmlnYXRvclp1c2F0eiArICcpJywnJ" +
                        "yksDQogIFN0cmFzc2UgPSBpc251bGwoQURSLlN0cmFzc2UrJyAnLCcnKStpc251bGwoQURSLkhhdXNOc" +
                        "iwnJyksDQogIE9ydCA9IGlzbnVsbChBRFIuUExaKycgJywgJycpK2lzbnVsbChBRFIuT3J0LCcnKSwNC" +
                        "iAgWnVzdCA9IGlzbnVsbChVU1IuRmlyc3ROYW1lKycgJywgJycpICsgaXNudWxsKFVTUi5MYXN0TmFtZ" +
                        "SwgJycpLA0KICBPcmdVbml0QWRyZXNzZSA9IE9yZy5UZXh0MQ0KRlJPTSBCZ0J1ZGdldCAgICAgICAgI" +
                        "CAgICBCQkcNCiAgTEVGVCBKT0lOIEJnRmluYW56cGxhbiBTRlAgb24gU0ZQLkJnRmluYW56cGxhbklEP" +
                        "UJCRy5CZ0ZpbmFuenBsYW5JRA0KICBMRUZUIEpPSU4gRmFMZWlzdHVuZyBMRUkgb24gTEVJLkZhTGVpc" +
                        "3R1bmdJRD1TRlAuRmFMZWlzdHVuZ0lEDQogIExFRlQgSk9JTiBCYVBlcnNvbiBQUlMgb24gUFJTLkJhU" +
                        "GVyc29uSUQ9TEVJLkJhUGVyc29uSUQNCiAgbGVmdCBqb2luIEJhQWRyZXNzZSBBRFIgb24gQURSLkJhQ" +
                        "WRyZXNzZUlEPSgNCiAgICBzZWxlY3QgVE9QIDEgQmFBZHJlc3NlSUQgZnJvbSBCYUFkcmVzc2UgQQ0KI" +
                        "CAgIHdoZXJlIEEuQmFQZXJzb25JRD1QUlMuQmFQZXJzb25JRCBhbmQgQS5BZHJlc3NlQ29kZT0xICAtL" +
                        "SAgLyp3b2huc2l0eiovDQogICAgICBhbmQgR2V0RGF0ZSgpIGJldHdlZW4gSXNOdWxsKEEuRGF0dW1Wb" +
                        "24sR2V0RGF0ZSgpKSBhbmQgSXNOdWxsKEEuRGF0dW1CaXMsR2V0RGF0ZSgpKQ0KICAgIG9yZGVyIGJ5I" +
                        "ElzTnVsbChBLkRhdHVtVm9uLEdldERhdGUoKSkgZGVzYyApDQogIExFRlQgSk9JTiBYVXNlciBVU1Igb" +
                        "24gVVNSLlVzZXJJRD1MRUkuVXNlcklEDQogIExFRlQgSk9JTiBYTE9WQ29kZSBCQkdfTE9WIG9uIEJCR" +
                        "19MT1YuTE9WTmFtZT0nQmdCZXdpbGxpZ3VuZ1N0YXR1cycNCiAgICBhbmQgQkJHX0xPVi5Db2RlPUJCR" +
                        "y5CZ0Jld2lsbGlndW5nU3RhdHVzQ29kZQ0KICBMRUZUIEpPSU4gWE9yZ1VuaXQgT3JnIG9uIE9yZy5Pc" +
                        "mdVbml0SUQgPSAoDQogICAgU0VMRUNUIFRPUCAxIE9VLk9yZ1VuaXRJRCBGUk9NIFhPcmdVbml0X1VzZ" +
                        "XIgT1UNCiAgICBXSEVSRSBPVS5Vc2VySUQgPSBMRUkuVXNlcklEIEFORCBPVS5PcmdVbml0TWVtYmVyQ" +
                        "29kZSA9IDIgKQ0KV0hFUkUgTEVJLk1vZHVsSUQ9Mw0KICBBTkQgQkJHLk1vbmF0IElTIE5PVCBOVUxMD" +
                        "QogIEFORCBCQkcuTWFzdGVyQnVkZ2V0ID0gMA0KICBBTkQgQkJHLkJnQnVkZ2V0SUQgPSBudWxsQAABA" +
                        "AAA/////wEAAAAAAAAADAIAAAAbRGV2RXhwcmVzcy5YdHJhUmVwb3J0cy52Ni4yBQEAAAAsRGV2RXhwc" +
                        "mVzcy5YdHJhUmVwb3J0cy5VSS5TZXJpYWxpemFibGVTdHJpbmcBAAAABVZhbHVlAQIAAAAGAwAAAJIBe" +
                        "1xydGYxXGFuc2ljcGcxMjUyDQp7DQpcZm9udHRibA0Ke1xmMCBUaW1lcyBOZXcgUm9tYW47fQ0KfQ0Ke" +
                        "w0KXGNvbG9ydGJsDQo7DQpccmVkMFxncmVlbjBcYmx1ZTA7DQp9DQp7XHBhcmRccGxhaW57XGZzMThcY" +
                        "2YxIHhyUmljaFRleHQxfVxwYXJ9DQp9DQoL";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
            this.xrLabelTitel = new DevExpress.XtraReports.UI.XRLabel();
            this.ShUebersichtMonatsbudgetML_Zahlungen = new DevExpress.XtraReports.UI.Subreport();
            this.ShUebersichtMonatsbudgetML_Uebersicht = new DevExpress.XtraReports.UI.Subreport();
            this.ShUebersichtMonatsbudgetML_Budget = new DevExpress.XtraReports.UI.Subreport();
            this.ShUebersichtMonatsbudgetML_Unterst = new DevExpress.XtraReports.UI.Subreport();
            this.txtZust = new DevExpress.XtraReports.UI.XRLabel();
            this.txtOrt = new DevExpress.XtraReports.UI.XRLabel();
            this.txtStrasse = new DevExpress.XtraReports.UI.XRLabel();
            this.txtStatus = new DevExpress.XtraReports.UI.XRLabel();
            this.txtName = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSig = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSigLoc = new DevExpress.XtraReports.UI.XRLabel();
            this.lblConf = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblFooterLeft = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrRichText1,
                        this.xrLabelTitel,
                        this.ShUebersichtMonatsbudgetML_Zahlungen,
                        this.ShUebersichtMonatsbudgetML_Uebersicht,
                        this.ShUebersichtMonatsbudgetML_Budget,
                        this.ShUebersichtMonatsbudgetML_Unterst,
                        this.txtZust,
                        this.txtOrt,
                        this.txtStrasse,
                        this.txtStatus,
                        this.txtName});
            this.Detail.Height = 404;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBackColor = false;
            this.Detail.ParentStyleUsing.UseBorderColor = false;
            this.Detail.ParentStyleUsing.UseBorders = false;
            this.Detail.ParentStyleUsing.UseBorderWidth = false;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.ParentStyleUsing.UseForeColor = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Height = 0;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.ParentStyleUsing.UseBackColor = false;
            this.PageHeader.ParentStyleUsing.UseBorderColor = false;
            this.PageHeader.ParentStyleUsing.UseBorders = false;
            this.PageHeader.ParentStyleUsing.UseBorderWidth = false;
            this.PageHeader.ParentStyleUsing.UseFont = false;
            this.PageHeader.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("BgBudgetId", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 0;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            this.GroupHeader1.Visible = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblSig,
                        this.lblSigLoc,
                        this.lblConf});
            this.GroupFooter1.Height = 82;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorders = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter1.ParentStyleUsing.UseFont = false;
            this.GroupFooter1.ParentStyleUsing.UseForeColor = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLine1,
                        this.xrPageInfo1,
                        this.xrLabel5,
                        this.xrLabel3,
                        this.lblFooterLeft});
            this.PageFooter.Height = 54;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // xrRichText1
            // 
            this.xrRichText1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Rtf", this.sqlQuery1, "OrgUnitAdresse", "")});
            this.xrRichText1.Location = new System.Drawing.Point(467, 0);
            this.xrRichText1.Name = "xrRichText1";
            this.xrRichText1.RtfText = ((DevExpress.XtraReports.UI.SerializableString)(resources.GetObject("xrRichText1.RtfText")));
            this.xrRichText1.Size = new System.Drawing.Size(292, 58);
            // 
            // xrLabelTitel
            // 
            this.xrLabelTitel.CanShrink = true;
            this.xrLabelTitel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_Titel", "")});
            this.xrLabelTitel.Font = new System.Drawing.Font("Arial", 14F);
            this.xrLabelTitel.Location = new System.Drawing.Point(467, 67);
            this.xrLabelTitel.Name = "xrLabelTitel";
            this.xrLabelTitel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelTitel.ParentStyleUsing.UseFont = false;
            this.xrLabelTitel.Size = new System.Drawing.Size(275, 21);
            this.xrLabelTitel.Text = "xrLabelTitel";
            // 
            // ShUebersichtMonatsbudgetML_Zahlungen
            // 
            this.ShUebersichtMonatsbudgetML_Zahlungen.Location = new System.Drawing.Point(8, 358);
            this.ShUebersichtMonatsbudgetML_Zahlungen.Name = "ShUebersichtMonatsbudgetML_Zahlungen";
            // 
            // ShUebersichtMonatsbudgetML_Uebersicht
            // 
            this.ShUebersichtMonatsbudgetML_Uebersicht.Location = new System.Drawing.Point(8, 317);
            this.ShUebersichtMonatsbudgetML_Uebersicht.Name = "ShUebersichtMonatsbudgetML_Uebersicht";
            // 
            // ShUebersichtMonatsbudgetML_Budget
            // 
            this.ShUebersichtMonatsbudgetML_Budget.Location = new System.Drawing.Point(8, 275);
            this.ShUebersichtMonatsbudgetML_Budget.Name = "ShUebersichtMonatsbudgetML_Budget";
            // 
            // ShUebersichtMonatsbudgetML_Unterst
            // 
            this.ShUebersichtMonatsbudgetML_Unterst.Location = new System.Drawing.Point(8, 242);
            this.ShUebersichtMonatsbudgetML_Unterst.Name = "ShUebersichtMonatsbudgetML_Unterst";
            // 
            // txtZust
            // 
            this.txtZust.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Zust", "")});
            this.txtZust.Font = new System.Drawing.Font("Arial", 10F);
            this.txtZust.ForeColor = System.Drawing.Color.Black;
            this.txtZust.Location = new System.Drawing.Point(467, 117);
            this.txtZust.Multiline = true;
            this.txtZust.Name = "txtZust";
            this.txtZust.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtZust.ParentStyleUsing.UseBackColor = false;
            this.txtZust.ParentStyleUsing.UseBorderColor = false;
            this.txtZust.ParentStyleUsing.UseBorders = false;
            this.txtZust.ParentStyleUsing.UseBorderWidth = false;
            this.txtZust.ParentStyleUsing.UseFont = false;
            this.txtZust.ParentStyleUsing.UseForeColor = false;
            this.txtZust.Size = new System.Drawing.Size(283, 15);
            this.txtZust.Text = "Zust";
            // 
            // txtOrt
            // 
            this.txtOrt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Ort", "")});
            this.txtOrt.Font = new System.Drawing.Font("Arial", 10F);
            this.txtOrt.ForeColor = System.Drawing.Color.Black;
            this.txtOrt.Location = new System.Drawing.Point(58, 117);
            this.txtOrt.Multiline = true;
            this.txtOrt.Name = "txtOrt";
            this.txtOrt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtOrt.ParentStyleUsing.UseBackColor = false;
            this.txtOrt.ParentStyleUsing.UseBorderColor = false;
            this.txtOrt.ParentStyleUsing.UseBorders = false;
            this.txtOrt.ParentStyleUsing.UseBorderWidth = false;
            this.txtOrt.ParentStyleUsing.UseFont = false;
            this.txtOrt.ParentStyleUsing.UseForeColor = false;
            this.txtOrt.Size = new System.Drawing.Size(212, 15);
            this.txtOrt.Text = "Ort";
            // 
            // txtStrasse
            // 
            this.txtStrasse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Strasse", "")});
            this.txtStrasse.Font = new System.Drawing.Font("Arial", 10F);
            this.txtStrasse.ForeColor = System.Drawing.Color.Black;
            this.txtStrasse.Location = new System.Drawing.Point(58, 100);
            this.txtStrasse.Multiline = true;
            this.txtStrasse.Name = "txtStrasse";
            this.txtStrasse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtStrasse.ParentStyleUsing.UseBackColor = false;
            this.txtStrasse.ParentStyleUsing.UseBorderColor = false;
            this.txtStrasse.ParentStyleUsing.UseBorders = false;
            this.txtStrasse.ParentStyleUsing.UseBorderWidth = false;
            this.txtStrasse.ParentStyleUsing.UseFont = false;
            this.txtStrasse.ParentStyleUsing.UseForeColor = false;
            this.txtStrasse.Size = new System.Drawing.Size(212, 15);
            this.txtStrasse.Text = "Strasse";
            // 
            // txtStatus
            // 
            this.txtStatus.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Status", "")});
            this.txtStatus.Font = new System.Drawing.Font("Arial", 10F);
            this.txtStatus.ForeColor = System.Drawing.Color.Black;
            this.txtStatus.Location = new System.Drawing.Point(467, 92);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtStatus.ParentStyleUsing.UseBackColor = false;
            this.txtStatus.ParentStyleUsing.UseBorderColor = false;
            this.txtStatus.ParentStyleUsing.UseBorders = false;
            this.txtStatus.ParentStyleUsing.UseBorderWidth = false;
            this.txtStatus.ParentStyleUsing.UseFont = false;
            this.txtStatus.ParentStyleUsing.UseForeColor = false;
            this.txtStatus.Size = new System.Drawing.Size(283, 15);
            this.txtStatus.Text = "txtStatus";
            this.txtStatus.WordWrap = false;
            // 
            // txtName
            // 
            this.txtName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.txtName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(58, 83);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtName.ParentStyleUsing.UseBackColor = false;
            this.txtName.ParentStyleUsing.UseBorderColor = false;
            this.txtName.ParentStyleUsing.UseBorders = false;
            this.txtName.ParentStyleUsing.UseBorderWidth = false;
            this.txtName.ParentStyleUsing.UseFont = false;
            this.txtName.ParentStyleUsing.UseForeColor = false;
            this.txtName.Size = new System.Drawing.Size(212, 15);
            this.txtName.Text = "Name";
            // 
            // lblSig
            // 
            this.lblSig.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_Unterschrift", "")});
            this.lblSig.Font = new System.Drawing.Font("Arial", 10F);
            this.lblSig.ForeColor = System.Drawing.Color.Black;
            this.lblSig.Location = new System.Drawing.Point(502, 60);
            this.lblSig.Name = "lblSig";
            this.lblSig.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSig.ParentStyleUsing.UseBackColor = false;
            this.lblSig.ParentStyleUsing.UseBorderColor = false;
            this.lblSig.ParentStyleUsing.UseBorders = false;
            this.lblSig.ParentStyleUsing.UseBorderWidth = false;
            this.lblSig.ParentStyleUsing.UseFont = false;
            this.lblSig.ParentStyleUsing.UseForeColor = false;
            this.lblSig.Size = new System.Drawing.Size(228, 15);
            this.lblSig.Text = "lblSig";
            // 
            // lblSigLoc
            // 
            this.lblSigLoc.Font = new System.Drawing.Font("Arial", 10F);
            this.lblSigLoc.ForeColor = System.Drawing.Color.Black;
            this.lblSigLoc.Location = new System.Drawing.Point(6, 60);
            this.lblSigLoc.Name = "lblSigLoc";
            this.lblSigLoc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblSigLoc.ParentStyleUsing.UseBackColor = false;
            this.lblSigLoc.ParentStyleUsing.UseBorderColor = false;
            this.lblSigLoc.ParentStyleUsing.UseBorders = false;
            this.lblSigLoc.ParentStyleUsing.UseBorderWidth = false;
            this.lblSigLoc.ParentStyleUsing.UseFont = false;
            this.lblSigLoc.ParentStyleUsing.UseForeColor = false;
            this.lblSigLoc.Size = new System.Drawing.Size(480, 15);
            // 
            // lblConf
            // 
            this.lblConf.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_Bestaetigung", "")});
            this.lblConf.Font = new System.Drawing.Font("Arial", 10F);
            this.lblConf.ForeColor = System.Drawing.Color.Black;
            this.lblConf.Location = new System.Drawing.Point(6, 7);
            this.lblConf.Name = "lblConf";
            this.lblConf.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblConf.ParentStyleUsing.UseBackColor = false;
            this.lblConf.ParentStyleUsing.UseBorderColor = false;
            this.lblConf.ParentStyleUsing.UseBorders = false;
            this.lblConf.ParentStyleUsing.UseBorderWidth = false;
            this.lblConf.ParentStyleUsing.UseFont = false;
            this.lblConf.ParentStyleUsing.UseForeColor = false;
            this.lblConf.Size = new System.Drawing.Size(724, 40);
            this.lblConf.Text = "lblConf";
            // 
            // xrLine1
            // 
            this.xrLine1.Location = new System.Drawing.Point(0, 8);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Size = new System.Drawing.Size(742, 9);
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 10F);
            this.xrPageInfo1.Format = "{0:dd.MMMM.yyyy}";
            this.xrPageInfo1.Location = new System.Drawing.Point(0, 31);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(142, 17);
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel5.Location = new System.Drawing.Point(433, 31);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(309, 16);
            this.xrLabel5.Text = "xrLabel5";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_Titel", "")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel3.Location = new System.Drawing.Point(433, 17);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(309, 16);
            this.xrLabel3.Text = "xrLabel3";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblFooterLeft
            // 
            this.lblFooterLeft.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_OrtDatum", "")});
            this.lblFooterLeft.Font = new System.Drawing.Font("Arial", 10F);
            this.lblFooterLeft.ForeColor = System.Drawing.Color.Black;
            this.lblFooterLeft.Location = new System.Drawing.Point(0, 17);
            this.lblFooterLeft.Name = "lblFooterLeft";
            this.lblFooterLeft.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblFooterLeft.ParentStyleUsing.UseBackColor = false;
            this.lblFooterLeft.ParentStyleUsing.UseBorderColor = false;
            this.lblFooterLeft.ParentStyleUsing.UseBorders = false;
            this.lblFooterLeft.ParentStyleUsing.UseBorderWidth = false;
            this.lblFooterLeft.ParentStyleUsing.UseFont = false;
            this.lblFooterLeft.ParentStyleUsing.UseForeColor = false;
            this.lblFooterLeft.Size = new System.Drawing.Size(425, 15);
            this.lblFooterLeft.Text = "lblFooterLeft";
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail,
                        this.PageHeader,
                        this.GroupHeader1,
                        this.GroupFooter1,
                        this.PageFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(39, 28, 80, 40);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  N'<?xml version="1.0" standalone="yes" ?>
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
		<FieldName>BgBudgetID</FieldName>
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
</NewDataSet>' ,  N'DECLARE @SprachCode INT
SELECT @SprachCode = P.VerstaendigungSprachCode
FROM BgBudget B
  LEFT OUTER JOIN BgFinanzplan FP ON FP.BgFinanzplanID = B.BgFinanzplanID
  LEFT OUTER JOIN FaLeistung LEI ON LEI.FaLeistungID = FP.FaLeistungID
  LEFT OUTER JOIN BaPerson P ON P.BaPersonID = LEI.BaPersonID
WHERE B.BgBudgetID = {BgBudgetID}
IF @SprachCode IS NULL SET @SprachCode = 1


SELECT
  Text_Titel = dbo.fnGetMLTextFromName(''Report_Budget'', ''Monatsbudget'', @SprachCode) + '' '' +
    Convert(varchar, BBG.Jahr) + '' '' +
    dbo.fnXMonatML(BBG.Monat, @SprachCode),
  Text_Bestaetigung = dbo.fnGetMLTextFromName(''Report_Budget'', ''Bestaetigung'', @SprachCode),
  Text_Unterschrift = dbo.fnGetMLTextFromName(''Report_Budget'', ''UnterschriftKlient'', @SprachCode),
  Text_OrtDatum = dbo.fnGetMLTextFromName(''Report_Budget'', ''OrtDatum'', @SprachCode),
  BBG.BgBudgetId,
  StatusCode = BBG.BgBewilligungStatusCode,
  Status =
    dbo.fnGetMLTextFromName(''Report_Budget'', ''Status'', @SprachCode) + '': '' +
    dbo.fnLOVMLText(''BgBewilligungStatus'', BBG.BgBewilligungStatusCode, @SprachCode),
  Name = isnull(PRS.Vorname+'' '','''')+isnull(PRS.Name,'''') + isNull(''('' + PRS.NavigatorZusatz + '')'',''''),
  Strasse = isnull(ADR.Strasse+'' '','''')+isnull(ADR.HausNr,''''),
  Ort = isnull(ADR.PLZ+'' '', '''')+isnull(ADR.Ort,''''),
  Zust = isnull(USR.FirstName+'' '', '''') + isnull(USR.LastName, ''''),
  OrgUnitAdresse = Org.Text1
FROM BgBudget             BBG
  LEFT JOIN BgFinanzplan SFP on SFP.BgFinanzplanID=BBG.BgFinanzplanID
  LEFT JOIN FaLeistung LEI on LEI.FaLeistungID=SFP.FaLeistungID
  LEFT JOIN BaPerson PRS on PRS.BaPersonID=LEI.BaPersonID
  left join BaAdresse ADR on ADR.BaAdresseID=(
    select TOP 1 BaAdresseID from BaAdresse A
    where A.BaPersonID=PRS.BaPersonID and A.AdresseCode=1  --  /*wohnsitz*/
      and GetDate() between IsNull(A.DatumVon,GetDate()) and IsNull(A.DatumBis,GetDate())
    order by IsNull(A.DatumVon,GetDate()) desc )
  LEFT JOIN XUser USR on USR.UserID=LEI.UserID
  LEFT JOIN XLOVCode BBG_LOV on BBG_LOV.LOVName=''BgBewilligungStatus''
    and BBG_LOV.Code=BBG.BgBewilligungStatusCode
  LEFT JOIN XOrgUnit Org on Org.OrgUnitID = (
    SELECT TOP 1 OU.OrgUnitID FROM XOrgUnit_User OU
    WHERE OU.UserID = LEI.UserID AND OU.OrgUnitMemberCode = 2 )
WHERE LEI.ModulID=3
  AND BBG.Monat IS NOT NULL
  AND BBG.MasterBudget = 0
  AND BBG.BgBudgetID = {BgBudgetID}' ,  N'WhMonatsbudget,WhMasterbudget,CtlWhBudget' ,  null , 3)

INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShUebersichtMonatsbudgetML_Budget' ,  N'MonatsbudgetML-Budget' , 1,  N'/// <XRTypeInfo>
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
        private DevExpress.XtraReports.UI.XRLabel Betrag1;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtKOA;
        private DevExpress.XtraReports.UI.XRLabel txtBezeichnung;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel lblTitle;
        private DevExpress.XtraReports.UI.GroupHeaderBand grp1H;
        private DevExpress.XtraReports.UI.XRLabel txtGrp1Text;
        private DevExpress.XtraReports.UI.GroupHeaderBand grp2H;
        private DevExpress.XtraReports.UI.XRLabel txtGrp2Text;
        private DevExpress.XtraReports.UI.GroupHeaderBand grp3H;
        private DevExpress.XtraReports.UI.XRLabel txtGrp3Text;
        private DevExpress.XtraReports.UI.GroupFooterBand grp3F;
        private DevExpress.XtraReports.UI.GroupFooterBand grp2F;
        private DevExpress.XtraReports.UI.GroupFooterBand grp1F;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel lblTotGrp1;
        private DevExpress.XtraReports.UI.XRLabel Grp1Betrag;
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
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAACAAAAAAAAAFBBRFBBRFATtE6kz" +
                        "4L1rTsAAAAAAAAANgEAADZnAHIAcAAyAEgALgBTAGMAcgBpAHAAdABzAC4ATwBuAEIAZQBmAG8AcgBlA" +
                        "FAAcgBpAG4AdAAAAAAAMnMAcQBsAFEAdQBlAHIAeQAxAC4AUwBlAGwAZQBjAHQAUwB0AGEAdABlAG0AZ" +
                        "QBuAHQAPAEAAAG5AnByaXZhdGUgdm9pZCBPbkJlZm9yZVByaW50KG9iamVjdCBzZW5kZXIsIFN5c3Rlb" +
                        "S5EcmF3aW5nLlByaW50aW5nLlByaW50RXZlbnRBcmdzIGUpIHsNCiAgIHRyeSB7DQogICAgICAvLyBoa" +
                        "WRlIGdycDIgaWYgZW1wdHkNCiAgICAgIC8vIGdycDJILlZpc2libGUgPSBoaWRkZW5MYmxTaFBvc2l0a" +
                        "W9uVHlwSUQuVGV4dCAhPSBzdHJpbmcuRW1wdHk7DQogICB9Y2F0Y2ggKFN5c3RlbS5FeGNlcHRpb24gZ" +
                        "XgpIHsNCiAgICAgIFN5c3RlbS5XaW5kb3dzLkZvcm1zLk1lc3NhZ2VCb3guU2hvdyhleC5TdGFja1RyY" +
                        "WNlLCBleC5NZXNzYWdlKTsNCiAgIH0NCn0B+hxERUNMQVJFIEBSZWZEYXRlIERBVEVUSU1FDQpTRVQgQ" +
                        "FJlZkRhdGUgPSBHRVREQVRFKCkNCg0KREVDTEFSRSBAU3ByYWNoQ29kZSBJTlQNClNFTEVDVCBAU3ByY" +
                        "WNoQ29kZSA9IFAuVmVyc3RhZW5kaWd1bmdTcHJhY2hDb2RlIA0KRlJPTSBCZ0J1ZGdldCBCDQogIExFR" +
                        "lQgT1VURVIgSk9JTiBCZ0ZpbmFuenBsYW4gRlAgT04gRlAuQmdGaW5hbnpwbGFuSUQgPSBCLkJnRmluY" +
                        "W56cGxhbklEDQogIExFRlQgT1VURVIgSk9JTiBGYUxlaXN0dW5nIExFSSBPTiBMRUkuRmFMZWlzdHVuZ" +
                        "0lEID0gRlAuRmFMZWlzdHVuZ0lEDQogIExFRlQgT1VURVIgSk9JTiBGYUZhbGwgRkFMIE9OIEZBTC5GY" +
                        "UZhbGxJRCA9IExFSS5GYUZhbGxJRA0KICBMRUZUIE9VVEVSIEpPSU4gQmFQZXJzb24gUCBPTiBQLkJhU" +
                        "GVyc29uSUQgPSBGQUwuQmFQZXJzb25JRA0KV0hFUkUgQi5CZ0J1ZGdldElEID0gbnVsbA0KSUYgQFNwc" +
                        "mFjaENvZGUgSVMgTlVMTCBTRVQgQFNwcmFjaENvZGUgPSAxDQoNCg0KDQpERUNMQVJFIEBUZXh0X0J1Z" +
                        "GdldCBWQVJDSEFSKDIwMCkNClNFTEVDVCBAVGV4dF9CdWRnZXQgPSBkYm8uZm5HZXRNTFRleHRGcm9tT" +
                        "mFtZSgnUmVwb3J0X0J1ZGdldCcsICdCdWRnZXQnLCBAU3ByYWNoQ29kZSkNCkRFQ0xBUkUgQFRleHRfV" +
                        "G90YWwgVkFSQ0hBUigyMDApDQpTRUxFQ1QgQFRleHRfVG90YWwgPSBkYm8uZm5HZXRNTFRleHRGcm9tT" +
                        "mFtZSgnUmVwb3J0X0J1ZGdldCcsICdUb3RhbCcsIEBTcHJhY2hDb2RlKQ0KDQpERUNMQVJFIEBUZXh0X" +
                        "0Vpbm5haG1lbiBWQVJDSEFSKDIwMCkNClNFTEVDVCBAVGV4dF9FaW5uYWhtZW4gPSBkYm8uZm5HZXRNT" +
                        "FRleHRGcm9tTmFtZSgnUmVwb3J0X0J1ZGdldCcsICdFaW5uYWhtZW4nLCBAU3ByYWNoQ29kZSkNCkRFQ" +
                        "0xBUkUgQFRleHRfU0RWZXJ3YWx0ZXQgVkFSQ0hBUigyMDApDQpTRUxFQ1QgQFRleHRfU0RWZXJ3YWx0Z" +
                        "XQgPSBkYm8uZm5HZXRNTFRleHRGcm9tTmFtZSgnUmVwb3J0X0J1ZGdldCcsICdTb3ppYWxkaWVuc3RWZ" +
                        "XJ3YWx0ZXQnLCBAU3ByYWNoQ29kZSkNCkRFQ0xBUkUgQFRleHRfS2xpZW50VmVyd2FsdGV0IFZBUkNIQ" +
                        "VIoMjAwKQ0KU0VMRUNUIEBUZXh0X0tsaWVudFZlcndhbHRldCA9IGRiby5mbkdldE1MVGV4dEZyb21OY" +
                        "W1lKCdSZXBvcnRfQnVkZ2V0JywgJ0tsaWVudFZlcndhbHRldCcsIEBTcHJhY2hDb2RlKQ0KREVDTEFSR" +
                        "SBAVGV4dF9WZXJndWV0dW5nRHJpdHRlIFZBUkNIQVIoMjAwKQ0KU0VMRUNUIEBUZXh0X1Zlcmd1ZXR1b" +
                        "mdEcml0dGUgPSBkYm8uZm5HZXRNTFRleHRGcm9tTmFtZSgnUmVwb3J0X0J1ZGdldCcsICdWZXJndWV0d" +
                        "W5nRHJpdHRlJywgQFNwcmFjaENvZGUpDQpERUNMQVJFIEBUZXh0X1Zlcmd1ZXR1bmdLbGllbnQgVkFSQ" +
                        "0hBUigyMDApDQpTRUxFQ1QgQFRleHRfVmVyZ3VldHVuZ0tsaWVudCA9IGRiby5mbkdldE1MVGV4dEZyb" +
                        "21OYW1lKCdSZXBvcnRfQnVkZ2V0JywgJ1Zlcmd1ZXR1bmdLbGllbnQnLCBAU3ByYWNoQ29kZSkNCkRFQ" +
                        "0xBUkUgQFRleHRfR3V0c2NocmlmdEF1c2dhYmVLb250aSBWQVJDSEFSKDIwMCkNClNFTEVDVCBAVGV4d" +
                        "F9HdXRzY2hyaWZ0QXVzZ2FiZUtvbnRpID0gZGJvLmZuR2V0TUxUZXh0RnJvbU5hbWUoJ1JlcG9ydF9Cd" +
                        "WRnZXQnLCAnR3V0c2NocmlmdEF1c2dhYmVrb250aScsIEBTcHJhY2hDb2RlKQ0KREVDTEFSRSBAVGV4d" +
                        "F9GaW5hbnppZXJ1bmdEdXJjaCBWQVJDSEFSKDIwMCkNClNFTEVDVCBAVGV4dF9GaW5hbnppZXJ1bmdEd" +
                        "XJjaCA9IGRiby5mbkdldE1MVGV4dEZyb21OYW1lKCdSZXBvcnRfQnVkZ2V0JywgJ0ZpbmFuemllcnVuZ" +
                        "0R1cmNoJywgQFNwcmFjaENvZGUpDQpERUNMQVJFIEBUZXh0X0ZpbmFuemllcnVuZ1NJTCBWQVJDSEFSK" +
                        "DIwMCkNClNFTEVDVCBAVGV4dF9GaW5hbnppZXJ1bmdTSUwgPSBkYm8uZm5HZXRNTFRleHRGcm9tTmFtZ" +
                        "SgnUmVwb3J0X0J1ZGdldCcsICdGaW5hbnppZXJ1bmdTSUwnLCBAU3ByYWNoQ29kZSkNCkRFQ0xBUkUgQ" +
                        "FRleHRfRmluYW56aWVydW5nR3J1bmRiZWRhcmYgVkFSQ0hBUigyMDApDQpTRUxFQ1QgQFRleHRfRmluY" +
                        "W56aWVydW5nR3J1bmRiZWRhcmYgPSBkYm8uZm5HZXRNTFRleHRGcm9tTmFtZSgnUmVwb3J0X0J1ZGdld" +
                        "CcsICdGaW5hbnppZXJ1bmdHcnVuZGJlZGFyZicsIEBTcHJhY2hDb2RlKQ0KDQpTRUxFQ1QNCiAgVGV4d" +
                        "F9CdWRnZXQgPSBAVGV4dF9CdWRnZXQsDQogIFRleHRfVG90YWwgPSBAVGV4dF9Ub3RhbCwNCiAgVE1QL" +
                        "kJnS2F0ZWdvcmllQ29kZSwNCiAgQmdLYXRlZ29yaWVUZXh0ID0gZGJvLmZuTE9WTUxUZXh0KCdCZ0thd" +
                        "GVnb3JpZScsIFRNUC5CZ0thdGVnb3JpZUNvZGUsIEBTcHJhY2hDb2RlKSwNCiAgQmdQb3NpdGlvblRle" +
                        "HRfVG90YWwgPSANCiAgICBAVGV4dF9Ub3RhbCArICcgJyArIA0KICAgIGRiby5mbkxPVk1MVGV4dCgnQ" +
                        "mdLYXRlZ29yaWUnLCBUTVAuQmdLYXRlZ29yaWVDb2RlLCBAU3ByYWNoQ29kZSksDQogIFRNUC5CZ0dyd" +
                        "XBwZUNvZGUsDQogIEJnR3J1cHBlVGV4dCA9IGRiby5mbkxPVk1MVGV4dCgnQmdHcnVwcGUnLCBUTVAuQ" +
                        "mdHcnVwcGVDb2RlLCBAU3ByYWNoQ29kZSksDQogIFRNUC5CZ1Bvc2l0aW9uc2FydElELA0KICBUTVAuR" +
                        "HJpdHRlLCANCiAgVE1QLkJnU3BlemtvbnRvSUQsDQoNCiAgR3JvdXBUZXh0ID0gQ0FTRSBUTVAuQmdLY" +
                        "XRlZ29yaWVDb2RlDQogICAgICAgICAgICAgICAgV0hFTiAxIFRIRU4gQFRleHRfRWlubmFobWVuICsgJ" +
                        "ywgJyArIENBU0UgDQogICAgICAgICAgICAgICAgICBXSEVOIFRNUC5TdHlsZSA9IDEyIFRIRU4gQFRle" +
                        "HRfU0RWZXJ3YWx0ZXQNCiAgICAgICAgICAgICAgICAgIEVMU0UgQFRleHRfS2xpZW50VmVyd2FsdGV0I" +
                        "EVORA0KICAgICAgICAgICAgICAgIFdIRU4gMiBUSEVOIENBU0UgV0hFTiBUTVAuQmdTcGV6a29udG9JR" +
                        "CBJUyBOVUxMDQogICAgICAgICAgICAgICAgICBUSEVOIENBU0UgV0hFTiBUTVAuRHJpdHRlID0gMSBUS" +
                        "EVOIEBUZXh0X1Zlcmd1ZXR1bmdEcml0dGUgRUxTRSBAVGV4dF9WZXJndWV0dW5nS2xpZW50IEVORA0KI" +
                        "CAgICAgICAgICAgICAgICAgRUxTRSBAVGV4dF9HdXRzY2hyaWZ0QXVzZ2FiZUtvbnRpDQogICAgICAgI" +
                        "CAgICAgICAgRU5EDQogICAgICAgICAgICAgICAgV0hFTiAxMDAgVEhFTiBAVGV4dF9GaW5hbnppZXJ1b" +
                        "mdTSUwgKyAnICcgKyBTUFQuTmFtZQ0KICAgICAgICAgICAgICAgIEVMU0UgQ0FTRSBXSEVOIFRNUC5CZ" +
                        "1NwZXprb250b0lEIElTIE5PVCBOVUxMDQogICAgICAgICAgICAgICAgICBUSEVOIEBUZXh0X0ZpbmFue" +
                        "mllcnVuZ0R1cmNoICsgJyAnICsgZGJvLmZuTE9WTUxUZXh0KCdCZ1NwZXprb250b1R5cCcsIFNQSy5CZ" +
                        "1NwZXprb250b1R5cENvZGUsIEBTcHJhY2hDb2RlKQ0KICAgICAgICAgICAgICAgICAgRUxTRSBAVGV4d" +
                        "F9GaW5hbnppZXJ1bmdHcnVuZGJlZGFyZg0KICAgICAgICAgICAgICAgIEVORA0KICAgICAgICAgICAgI" +
                        "CBFTkQsDQoNCiAgQmV6ZWljaG51bmcgPSBMVHJpbShUTVAuQmV6ZWljaG51bmcpLCANCiAgVE1QLkJld" +
                        "HJhZywgDQogIFRNUC5LT0ENCkZST00gZGJvLmZuV2hHZXRCdWRnZXQobnVsbCwgQFJlZkRhdGUpIFRNU" +
                        "A0KICBMRUZUIEpPSU4gQmdQb3NpdGlvbnNhcnQgU1BUIE9OIFNQVC5CZ1Bvc2l0aW9uc2FydElEID0gV" +
                        "E1QLkJnUG9zaXRpb25zYXJ0SUQNCiAgTEVGVCBKT0lOIEJnU3BlemtvbnRvIFNQSyBPTiBTUEsuQmdTc" +
                        "GV6a29udG9JRCA9IFRNUC5CZ1NwZXprb250b0lEDQpXSEVSRSBUTVAuQmdLYXRlZ29yaWVDb2RlIE5PV" +
                        "CBJTiAoMTAwLCAxMDEp";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.grp1H = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.grp2H = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.grp3H = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.grp3F = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.grp2F = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.grp1F = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.Betrag1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKOA = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBezeichnung = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGrp1Text = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGrp2Text = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGrp3Text = new DevExpress.XtraReports.UI.XRLabel();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.lblTotGrp1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Grp1Betrag = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Betrag1,
                        this.txtKOA,
                        this.txtBezeichnung});
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
                        this.lblTitle});
            this.ReportHeader.Height = 25;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.ParentStyleUsing.UseBackColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorderColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorders = false;
            this.ReportHeader.ParentStyleUsing.UseBorderWidth = false;
            this.ReportHeader.ParentStyleUsing.UseFont = false;
            this.ReportHeader.ParentStyleUsing.UseForeColor = false;
            // 
            // grp1H
            // 
            this.grp1H.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtGrp1Text});
            this.grp1H.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("BgKategorieText", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.grp1H.Height = 25;
            this.grp1H.Level = 2;
            this.grp1H.Name = "grp1H";
            this.grp1H.ParentStyleUsing.UseBackColor = false;
            this.grp1H.ParentStyleUsing.UseBorderColor = false;
            this.grp1H.ParentStyleUsing.UseBorders = false;
            this.grp1H.ParentStyleUsing.UseBorderWidth = false;
            this.grp1H.ParentStyleUsing.UseFont = false;
            this.grp1H.ParentStyleUsing.UseForeColor = false;
            // 
            // grp2H
            // 
            this.grp2H.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtGrp2Text});
            this.grp2H.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("BgGruppeText", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.grp2H.Height = 25;
            this.grp2H.Level = 1;
            this.grp2H.Name = "grp2H";
            this.grp2H.ParentStyleUsing.UseBackColor = false;
            this.grp2H.ParentStyleUsing.UseBorderColor = false;
            this.grp2H.ParentStyleUsing.UseBorders = false;
            this.grp2H.ParentStyleUsing.UseBorderWidth = false;
            this.grp2H.ParentStyleUsing.UseFont = false;
            this.grp2H.ParentStyleUsing.UseForeColor = false;
            this.grp2H.Scripts.OnBeforePrint = resources.GetString("grp2H.Scripts.OnBeforePrint");
            // 
            // grp3H
            // 
            this.grp3H.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtGrp3Text});
            this.grp3H.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("GroupText", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.grp3H.Height = 15;
            this.grp3H.Name = "grp3H";
            this.grp3H.ParentStyleUsing.UseBackColor = false;
            this.grp3H.ParentStyleUsing.UseBorderColor = false;
            this.grp3H.ParentStyleUsing.UseBorders = false;
            this.grp3H.ParentStyleUsing.UseBorderWidth = false;
            this.grp3H.ParentStyleUsing.UseFont = false;
            this.grp3H.ParentStyleUsing.UseForeColor = false;
            this.grp3H.Scripts.OnBeforePrint = "private void OnBeforePrint(object sender, System.Drawing.Printing.PrintEventArgs " +
                "e) {\r\n      // hide grp3 if empty\r\n      //grp3H.Visible = hiddenLblGroupText.Te" +
                "xt != string.Empty;\r\n}";
            // 
            // grp3F
            // 
            this.grp3F.Height = 6;
            this.grp3F.Name = "grp3F";
            this.grp3F.ParentStyleUsing.UseBackColor = false;
            this.grp3F.ParentStyleUsing.UseBorderColor = false;
            this.grp3F.ParentStyleUsing.UseBorders = false;
            this.grp3F.ParentStyleUsing.UseBorderWidth = false;
            this.grp3F.ParentStyleUsing.UseFont = false;
            this.grp3F.ParentStyleUsing.UseForeColor = false;
            this.grp3F.Visible = false;
            // 
            // grp2F
            // 
            this.grp2F.Height = 7;
            this.grp2F.Level = 1;
            this.grp2F.Name = "grp2F";
            this.grp2F.ParentStyleUsing.UseBackColor = false;
            this.grp2F.ParentStyleUsing.UseBorderColor = false;
            this.grp2F.ParentStyleUsing.UseBorders = false;
            this.grp2F.ParentStyleUsing.UseBorderWidth = false;
            this.grp2F.ParentStyleUsing.UseFont = false;
            this.grp2F.ParentStyleUsing.UseForeColor = false;
            this.grp2F.Visible = false;
            // 
            // grp1F
            // 
            this.grp1F.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Line2,
                        this.Line1,
                        this.lblTotGrp1,
                        this.Grp1Betrag});
            this.grp1F.Height = 47;
            this.grp1F.Level = 2;
            this.grp1F.Name = "grp1F";
            this.grp1F.ParentStyleUsing.UseBackColor = false;
            this.grp1F.ParentStyleUsing.UseBorderColor = false;
            this.grp1F.ParentStyleUsing.UseBorders = false;
            this.grp1F.ParentStyleUsing.UseBorderWidth = false;
            this.grp1F.ParentStyleUsing.UseFont = false;
            this.grp1F.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Height = 11;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
            this.ReportFooter.Visible = false;
            // 
            // Betrag1
            // 
            this.Betrag1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.Betrag1.Font = new System.Drawing.Font("Arial", 10F);
            this.Betrag1.ForeColor = System.Drawing.Color.Black;
            this.Betrag1.Location = new System.Drawing.Point(469, 0);
            this.Betrag1.Multiline = true;
            this.Betrag1.Name = "Betrag1";
            this.Betrag1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Betrag1.ParentStyleUsing.UseBackColor = false;
            this.Betrag1.ParentStyleUsing.UseBorderColor = false;
            this.Betrag1.ParentStyleUsing.UseBorders = false;
            this.Betrag1.ParentStyleUsing.UseBorderWidth = false;
            this.Betrag1.ParentStyleUsing.UseFont = false;
            this.Betrag1.ParentStyleUsing.UseForeColor = false;
            this.Betrag1.Size = new System.Drawing.Size(97, 15);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.Betrag1.Summary = xrSummary1;
            this.Betrag1.Text = "Betrag";
            this.Betrag1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtKOA
            // 
            this.txtKOA.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KOA", "")});
            this.txtKOA.Font = new System.Drawing.Font("Arial", 10F);
            this.txtKOA.ForeColor = System.Drawing.Color.Black;
            this.txtKOA.Location = new System.Drawing.Point(422, 0);
            this.txtKOA.Multiline = true;
            this.txtKOA.Name = "txtKOA";
            this.txtKOA.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKOA.ParentStyleUsing.UseBackColor = false;
            this.txtKOA.ParentStyleUsing.UseBorderColor = false;
            this.txtKOA.ParentStyleUsing.UseBorders = false;
            this.txtKOA.ParentStyleUsing.UseBorderWidth = false;
            this.txtKOA.ParentStyleUsing.UseFont = false;
            this.txtKOA.ParentStyleUsing.UseForeColor = false;
            this.txtKOA.Size = new System.Drawing.Size(47, 15);
            this.txtKOA.Text = "KOA";
            // 
            // txtBezeichnung
            // 
            this.txtBezeichnung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bezeichnung", "")});
            this.txtBezeichnung.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBezeichnung.ForeColor = System.Drawing.Color.Black;
            this.txtBezeichnung.Location = new System.Drawing.Point(47, 0);
            this.txtBezeichnung.Multiline = true;
            this.txtBezeichnung.Name = "txtBezeichnung";
            this.txtBezeichnung.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBezeichnung.ParentStyleUsing.UseBackColor = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorderColor = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorders = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorderWidth = false;
            this.txtBezeichnung.ParentStyleUsing.UseFont = false;
            this.txtBezeichnung.ParentStyleUsing.UseForeColor = false;
            this.txtBezeichnung.Size = new System.Drawing.Size(375, 15);
            this.txtBezeichnung.Text = "Bezeichnung";
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Silver;
            this.lblTitle.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_Budget", "")});
            this.lblTitle.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTitle.ParentStyleUsing.UseBackColor = false;
            this.lblTitle.ParentStyleUsing.UseBorderColor = false;
            this.lblTitle.ParentStyleUsing.UseBorders = false;
            this.lblTitle.ParentStyleUsing.UseBorderWidth = false;
            this.lblTitle.ParentStyleUsing.UseFont = false;
            this.lblTitle.ParentStyleUsing.UseForeColor = false;
            this.lblTitle.Size = new System.Drawing.Size(724, 23);
            this.lblTitle.Text = "lblTitle";
            this.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtGrp1Text
            // 
            this.txtGrp1Text.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BgKategorieText", "")});
            this.txtGrp1Text.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtGrp1Text.ForeColor = System.Drawing.Color.Black;
            this.txtGrp1Text.Location = new System.Drawing.Point(0, 0);
            this.txtGrp1Text.Multiline = true;
            this.txtGrp1Text.Name = "txtGrp1Text";
            this.txtGrp1Text.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGrp1Text.ParentStyleUsing.UseBackColor = false;
            this.txtGrp1Text.ParentStyleUsing.UseBorderColor = false;
            this.txtGrp1Text.ParentStyleUsing.UseBorders = false;
            this.txtGrp1Text.ParentStyleUsing.UseBorderWidth = false;
            this.txtGrp1Text.ParentStyleUsing.UseFont = false;
            this.txtGrp1Text.ParentStyleUsing.UseForeColor = false;
            this.txtGrp1Text.Size = new System.Drawing.Size(640, 21);
            this.txtGrp1Text.Text = "txtGrp1Text";
            // 
            // txtGrp2Text
            // 
            this.txtGrp2Text.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BgGruppeText", "")});
            this.txtGrp2Text.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtGrp2Text.ForeColor = System.Drawing.Color.Black;
            this.txtGrp2Text.Location = new System.Drawing.Point(21, 0);
            this.txtGrp2Text.Multiline = true;
            this.txtGrp2Text.Name = "txtGrp2Text";
            this.txtGrp2Text.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGrp2Text.ParentStyleUsing.UseBackColor = false;
            this.txtGrp2Text.ParentStyleUsing.UseBorderColor = false;
            this.txtGrp2Text.ParentStyleUsing.UseBorders = false;
            this.txtGrp2Text.ParentStyleUsing.UseBorderWidth = false;
            this.txtGrp2Text.ParentStyleUsing.UseFont = false;
            this.txtGrp2Text.ParentStyleUsing.UseForeColor = false;
            this.txtGrp2Text.Size = new System.Drawing.Size(620, 15);
            this.txtGrp2Text.Text = "txtGrp2Text";
            // 
            // txtGrp3Text
            // 
            this.txtGrp3Text.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "GroupText", "")});
            this.txtGrp3Text.Font = new System.Drawing.Font("Arial", 10F);
            this.txtGrp3Text.ForeColor = System.Drawing.Color.Black;
            this.txtGrp3Text.Location = new System.Drawing.Point(37, 0);
            this.txtGrp3Text.Multiline = true;
            this.txtGrp3Text.Name = "txtGrp3Text";
            this.txtGrp3Text.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGrp3Text.ParentStyleUsing.UseBackColor = false;
            this.txtGrp3Text.ParentStyleUsing.UseBorderColor = false;
            this.txtGrp3Text.ParentStyleUsing.UseBorders = false;
            this.txtGrp3Text.ParentStyleUsing.UseBorderWidth = false;
            this.txtGrp3Text.ParentStyleUsing.UseFont = false;
            this.txtGrp3Text.ParentStyleUsing.UseForeColor = false;
            this.txtGrp3Text.Size = new System.Drawing.Size(606, 15);
            this.txtGrp3Text.Text = "GroupText";
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.Location = new System.Drawing.Point(0, 31);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(564, 2);
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.Location = new System.Drawing.Point(25, 0);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(541, 4);
            // 
            // lblTotGrp1
            // 
            this.lblTotGrp1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BgPositionText_Total", "")});
            this.lblTotGrp1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotGrp1.ForeColor = System.Drawing.Color.Black;
            this.lblTotGrp1.KeepTogether = true;
            this.lblTotGrp1.Location = new System.Drawing.Point(25, 7);
            this.lblTotGrp1.Name = "lblTotGrp1";
            this.lblTotGrp1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTotGrp1.ParentStyleUsing.UseBackColor = false;
            this.lblTotGrp1.ParentStyleUsing.UseBorderColor = false;
            this.lblTotGrp1.ParentStyleUsing.UseBorders = false;
            this.lblTotGrp1.ParentStyleUsing.UseBorderWidth = false;
            this.lblTotGrp1.ParentStyleUsing.UseFont = false;
            this.lblTotGrp1.ParentStyleUsing.UseForeColor = false;
            this.lblTotGrp1.Size = new System.Drawing.Size(433, 17);
            this.lblTotGrp1.Text = "lblTotGrp1";
            this.lblTotGrp1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Grp1Betrag
            // 
            this.Grp1Betrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.Grp1Betrag.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Grp1Betrag.ForeColor = System.Drawing.Color.Black;
            this.Grp1Betrag.Location = new System.Drawing.Point(469, 7);
            this.Grp1Betrag.Multiline = true;
            this.Grp1Betrag.Name = "Grp1Betrag";
            this.Grp1Betrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Grp1Betrag.ParentStyleUsing.UseBackColor = false;
            this.Grp1Betrag.ParentStyleUsing.UseBorderColor = false;
            this.Grp1Betrag.ParentStyleUsing.UseBorders = false;
            this.Grp1Betrag.ParentStyleUsing.UseBorderWidth = false;
            this.Grp1Betrag.ParentStyleUsing.UseFont = false;
            this.Grp1Betrag.ParentStyleUsing.UseForeColor = false;
            this.Grp1Betrag.Size = new System.Drawing.Size(97, 17);
            xrSummary2.FormatString = "{0:#,##0.00}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.Grp1Betrag.Summary = xrSummary2;
            this.Grp1Betrag.Text = "Grp1Betrag";
            this.Grp1Betrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
                        this.grp1H,
                        this.grp2H,
                        this.grp3H,
                        this.grp3F,
                        this.grp2F,
                        this.grp1F,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(100, 0, 100, 100);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ScriptReferencesString = "System.Windows.Forms.dll";
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  N'<?xml version="1.0" standalone="yes" ?>
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
		<FieldName>BgBudgetID</FieldName>
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
</NewDataSet>' ,  N'DECLARE @RefDate DATETIME
SET @RefDate = GETDATE()

DECLARE @SprachCode INT
SELECT @SprachCode = P.VerstaendigungSprachCode
FROM BgBudget B
  LEFT OUTER JOIN BgFinanzplan FP ON FP.BgFinanzplanID = B.BgFinanzplanID
  LEFT OUTER JOIN FaLeistung LEI ON LEI.FaLeistungID = FP.FaLeistungID
  LEFT OUTER JOIN FaFall FAL ON FAL.FaFallID = LEI.FaFallID
  LEFT OUTER JOIN BaPerson P ON P.BaPersonID = FAL.BaPersonID
WHERE B.BgBudgetID = {BgBudgetID}
IF @SprachCode IS NULL SET @SprachCode = 1



DECLARE @Text_Budget VARCHAR(200)
SELECT @Text_Budget = dbo.fnGetMLTextFromName(''Report_Budget'', ''Budget'', @SprachCode)
DECLARE @Text_Total VARCHAR(200)
SELECT @Text_Total = dbo.fnGetMLTextFromName(''Report_Budget'', ''Total'', @SprachCode)

DECLARE @Text_Einnahmen VARCHAR(200)
SELECT @Text_Einnahmen = dbo.fnGetMLTextFromName(''Report_Budget'', ''Einnahmen'', @SprachCode)
DECLARE @Text_SDVerwaltet VARCHAR(200)
SELECT @Text_SDVerwaltet = dbo.fnGetMLTextFromName(''Report_Budget'', ''SozialdienstVerwaltet'', @SprachCode)
DECLARE @Text_KlientVerwaltet VARCHAR(200)
SELECT @Text_KlientVerwaltet = dbo.fnGetMLTextFromName(''Report_Budget'', ''KlientVerwaltet'', @SprachCode)
DECLARE @Text_VerguetungDritte VARCHAR(200)
SELECT @Text_VerguetungDritte = dbo.fnGetMLTextFromName(''Report_Budget'', ''VerguetungDritte'', @SprachCode)
DECLARE @Text_VerguetungKlient VARCHAR(200)
SELECT @Text_VerguetungKlient = dbo.fnGetMLTextFromName(''Report_Budget'', ''VerguetungKlient'', @SprachCode)
DECLARE @Text_GutschriftAusgabeKonti VARCHAR(200)
SELECT @Text_GutschriftAusgabeKonti = dbo.fnGetMLTextFromName(''Report_Budget'', ''GutschriftAusgabekonti'', @SprachCode)
DECLARE @Text_FinanzierungDurch VARCHAR(200)
SELECT @Text_FinanzierungDurch = dbo.fnGetMLTextFromName(''Report_Budget'', ''FinanzierungDurch'', @SprachCode)
DECLARE @Text_FinanzierungSIL VARCHAR(200)
SELECT @Text_FinanzierungSIL = dbo.fnGetMLTextFromName(''Report_Budget'', ''FinanzierungSIL'', @SprachCode)
DECLARE @Text_FinanzierungGrundbedarf VARCHAR(200)
SELECT @Text_FinanzierungGrundbedarf = dbo.fnGetMLTextFromName(''Report_Budget'', ''FinanzierungGrundbedarf'', @SprachCode)

SELECT
  Text_Budget = @Text_Budget,
  Text_Total = @Text_Total,
  TMP.BgKategorieCode,
  BgKategorieText = dbo.fnLOVMLText(''BgKategorie'', TMP.BgKategorieCode, @SprachCode),
  BgPositionText_Total =
    @Text_Total + '' '' +
    dbo.fnLOVMLText(''BgKategorie'', TMP.BgKategorieCode, @SprachCode),
  TMP.BgGruppeCode,
  BgGruppeText = dbo.fnLOVMLText(''BgGruppe'', TMP.BgGruppeCode, @SprachCode),
  TMP.BgPositionsartID,
  TMP.Dritte,
  TMP.BgSpezkontoID,

  GroupText = CASE TMP.BgKategorieCode
                WHEN 1 THEN @Text_Einnahmen + '', '' + CASE
                  WHEN TMP.Style = 12 THEN @Text_SDVerwaltet
                  ELSE @Text_KlientVerwaltet END
                WHEN 2 THEN CASE WHEN TMP.BgSpezkontoID IS NULL
                  THEN CASE WHEN TMP.Dritte = 1 THEN @Text_VerguetungDritte ELSE @Text_VerguetungKlient END
                  ELSE @Text_GutschriftAusgabeKonti
                END
                WHEN 100 THEN @Text_FinanzierungSIL + '' '' + SPT.Name
                ELSE CASE WHEN TMP.BgSpezkontoID IS NOT NULL
                  THEN @Text_FinanzierungDurch + '' '' + dbo.fnLOVMLText(''BgSpezkontoTyp'', SPK.BgSpezkontoTypCode, @SprachCode)
                  ELSE @Text_FinanzierungGrundbedarf
                END
              END,

  Bezeichnung = LTrim(TMP.Bezeichnung),
  TMP.Betrag,
  TMP.KOA
FROM dbo.fnWhGetBudget({BgBudgetID}, @RefDate) TMP
  LEFT JOIN BgPositionsart SPT ON SPT.BgPositionsartID = TMP.BgPositionsartID
  LEFT JOIN BgSpezkonto SPK ON SPK.BgSpezkontoID = TMP.BgSpezkontoID
WHERE TMP.BgKategorieCode NOT IN (100, 101)
  AND TMP.BgPositionID IS NOT NULL' ,  null ,  N'ShUebersichtMonatsbudgetML' ,  null )

INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShUebersichtMonatsbudgetML_Uebersicht' ,  N'MonatsbudgetML-Uebersicht' , 1,  N'/// <XRTypeInfo>
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
        private DevExpress.XtraReports.UI.XRLabel txtBezeichnung;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel lblTitle;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel Betrag1;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel lblTot;
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
                        "AAAAbcTREVDTEFSRSBAUmVmRGF0ZSAgZGF0ZXRpbWUgIFNFVCBAUmVmRGF0ZSA9IEdldERhdGUoKQ0KD" +
                        "QpERUNMQVJFIEBTcHJhY2hDb2RlIElOVA0KU0VMRUNUIEBTcHJhY2hDb2RlID0gUC5WZXJzdGFlbmRpZ" +
                        "3VuZ1NwcmFjaENvZGUgDQpGUk9NIEJnQnVkZ2V0IEINCiAgTEVGVCBPVVRFUiBKT0lOIEJnRmluYW56c" +
                        "GxhbiBGUCBPTiBGUC5CZ0ZpbmFuenBsYW5JRCA9IEIuQmdGaW5hbnpwbGFuSUQNCiAgTEVGVCBPVVRFU" +
                        "iBKT0lOIEZhTGVpc3R1bmcgTEVJIE9OIExFSS5GYUxlaXN0dW5nSUQgPSBGUC5GYUxlaXN0dW5nSUQNC" +
                        "iAgTEVGVCBPVVRFUiBKT0lOIEZhRmFsbCBGQUwgT04gRkFMLkZhRmFsbElEID0gTEVJLkZhRmFsbElED" +
                        "QogIExFRlQgT1VURVIgSk9JTiBCYVBlcnNvbiBQIE9OIFAuQmFQZXJzb25JRCA9IEZBTC5CYVBlcnNvb" +
                        "klEDQpXSEVSRSBCLkJnQnVkZ2V0SUQgPSBudWxsDQoNCkRFQ0xBUkUgQFRleHRfTGVpc3R1bmdlblNEI" +
                        "FZBUkNIQVIoMjAwKQ0KU0VMRUNUIEBUZXh0X0xlaXN0dW5nZW5TRCA9IGRiby5mbkdldE1MVGV4dCgxM" +
                        "DI0LCBAU3ByYWNoQ29kZSkNCkRFQ0xBUkUgQFRleHRfVG90YWxMZWlzdHVuZ2VuU0QgVkFSQ0hBUigyM" +
                        "DApDQpTRUxFQ1QgQFRleHRfVG90YWxMZWlzdHVuZ2VuU0QgPSBkYm8uZm5HZXRNTFRleHQoMTAyNSwgQ" +
                        "FNwcmFjaENvZGUpDQoNCg0KREVDTEFSRSBAQmdQb3NpdGlvbiBUQUJMRSAoDQogIEJnS2F0ZWdvcmllQ" +
                        "29kZSBJTlQsIA0KICBCZ1Bvc2l0aW9uc2FydElEIElOVCwgDQogIERyaXR0ZSBCSVQsIA0KICBCZ1NwZ" +
                        "Xprb250b0lEIElOVCwgDQogIEJldHJhZyBNT05FWSwgDQogIFN0eWxlIElOVA0KKQ0KDQpJTlNFUlQgS" +
                        "U5UTyBAQmdQb3NpdGlvbiAoQmdLYXRlZ29yaWVDb2RlLCBCZ1Bvc2l0aW9uc2FydElELCBEcml0dGUsI" +
                        "EJnU3BlemtvbnRvSUQsIEJldHJhZywgU3R5bGUpDQogIFNFTEVDVCBCZ0thdGVnb3JpZUNvZGUsIEJnU" +
                        "G9zaXRpb25zYXJ0SUQsIERyaXR0ZSwgQmdTcGV6a29udG9JRCwgQmV0cmFnLCBTdHlsZQ0KICBGUk9NI" +
                        "GRiby5mbldoR2V0QnVkZ2V0TUwobnVsbCwgQFJlZkRhdGUpDQogIFdIRVJFIEJnUG9zaXRpb25JRCBJU" +
                        "yBOT1QgTlVMTA0KDQpkZWNsYXJlIEBvdXQgdGFibGUgKA0KICBTb3J0ICAgICAgICAgaW50IG5vdCBud" +
                        "WxsLA0KICBCZXplaWNobnVuZyAgdmFyY2hhcigxMDApIG5vdCBudWxsLA0KICBCZXRyYWcgICAgICAgb" +
                        "W9uZXkgbm90IG51bGwNCikNCg0KaW5zZXJ0IEBvdXQNCnNlbGVjdCAxLCBkYm8uZm5HZXRNTFRleHQoM" +
                        "TAxMiwgQFNwcmFjaENvZGUpLCBpc251bGwoc3VtKEJldHJhZyksIDApDQpmcm9tIEBCZ1Bvc2l0aW9uD" +
                        "Qp3aGVyZSBCZ0thdGVnb3JpZUNvZGUgPSAyIEFORCBEcml0dGUgPSAwIEFORCBCZ1NwZXprb250b0lEI" +
                        "ElTIE5VTEwNCg0KaW5zZXJ0IEBvdXQNCnNlbGVjdCAyLCBkYm8uZm5HZXRNTFRleHQoMTAxMSwgQFNwc" +
                        "mFjaENvZGUpLCBpc251bGwoc3VtKEJldHJhZyksIDApDQpmcm9tIEBCZ1Bvc2l0aW9uDQp3aGVyZSBCZ" +
                        "0thdGVnb3JpZUNvZGUgPSAyIEFORCBEcml0dGUgPSAxIEFORCBCZ1NwZXprb250b0lEIElTIE5VTEwNC" +
                        "g0KaW5zZXJ0IEBvdXQNCnNlbGVjdCAzLCBkYm8uZm5HZXRNTFRleHQoMTAxMywgQFNwcmFjaENvZGUpL" +
                        "CBpc251bGwoc3VtKEJldHJhZyksIDApDQpmcm9tIEBCZ1Bvc2l0aW9uDQp3aGVyZSBCZ0thdGVnb3JpZ" +
                        "UNvZGUgPSAyIEFORCBCZ1NwZXprb250b0lEIElTIE5PVCBOVUxMDQoNCmluc2VydCBAb3V0DQpzZWxlY" +
                        "3QgNCwgZGJvLmZuR2V0TUxUZXh0KDEwMTQsIEBTcHJhY2hDb2RlKSwgaXNudWxsKHN1bShiZXRyYWcpL" +
                        "CAwKQ0KZnJvbSBAQmdQb3NpdGlvbg0Kd2hlcmUgQmdLYXRlZ29yaWVDb2RlID0gMTAwIEFORCBCZ1NwZ" +
                        "Xprb250b0lEIElTIE5VTEwgQU5EIEJnUG9zaXRpb25zYXJ0SUQgSVMgTk9UIE5VTEwNCg0KaW5zZXJ0I" +
                        "EBvdXQNCnNlbGVjdCA1LCBkYm8uZm5HZXRNTFRleHQoMTAxNSwgQFNwcmFjaENvZGUpLCBpc251bGwoL" +
                        "XN1bShiZXRyYWcpLCAwKQ0KZnJvbSBAQmdQb3NpdGlvbg0Kd2hlcmUgQmdLYXRlZ29yaWVDb2RlID0gM" +
                        "SBBTkQgbm90IFN0eWxlID0gMTINCg0KaW5zZXJ0IEBvdXQNCnNlbGVjdCA2LCBkYm8uZm5HZXRNTFRle" +
                        "HQoMTAxNiwgQFNwcmFjaENvZGUpLCBpc251bGwoLXN1bShiZXRyYWcpLCAwKQ0KZnJvbSBAQmdQb3Npd" +
                        "Glvbg0Kd2hlcmUgQmdLYXRlZ29yaWVDb2RlID0gMSBBTkQgU3R5bGUgPSAxMg0KDQppbnNlcnQgQG91d" +
                        "A0Kc2VsZWN0IDcsIGRiby5mbkdldE1MVGV4dCgxMDE3LCBAU3ByYWNoQ29kZSksIGlzbnVsbCgtc3VtK" +
                        "GJldHJhZyksIDApDQpmcm9tIEBCZ1Bvc2l0aW9uDQp3aGVyZSBCZ0thdGVnb3JpZUNvZGUgPSA0DQoNC" +
                        "nNlbGVjdCANCiAgVGV4dF9MZWlzdHVuZ2VuU0QgPSBAVGV4dF9MZWlzdHVuZ2VuU0QsDQogIFRleHRfV" +
                        "G90YWxMZWlzdHVuZ2VuU0QgPSBAVGV4dF9Ub3RhbExlaXN0dW5nZW5TRCwNCiAgQmV6ZWljaG51bmcsI" +
                        "EJldHJhZyANCmZyb20gQG91dCBvcmRlciBieSBTb3J0";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.txtBezeichnung = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.Betrag1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.lblTot = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtBezeichnung,
                        this.txtBetrag});
            this.Detail.Dpi = 254F;
            this.Detail.Height = 38;
            this.Detail.KeepTogether = true;
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
                        this.lblTitle});
            this.ReportHeader.Dpi = 254F;
            this.ReportHeader.Height = 64;
            this.ReportHeader.KeepTogether = true;
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
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Betrag1,
                        this.Line1,
                        this.lblTot});
            this.ReportFooter.Dpi = 254F;
            this.ReportFooter.Height = 87;
            this.ReportFooter.KeepTogether = true;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // txtBezeichnung
            // 
            this.txtBezeichnung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bezeichnung", "")});
            this.txtBezeichnung.Dpi = 254F;
            this.txtBezeichnung.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBezeichnung.ForeColor = System.Drawing.Color.Black;
            this.txtBezeichnung.Location = new System.Drawing.Point(0, 0);
            this.txtBezeichnung.Multiline = true;
            this.txtBezeichnung.Name = "txtBezeichnung";
            this.txtBezeichnung.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtBezeichnung.ParentStyleUsing.UseBackColor = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorderColor = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorders = false;
            this.txtBezeichnung.ParentStyleUsing.UseBorderWidth = false;
            this.txtBezeichnung.ParentStyleUsing.UseFont = false;
            this.txtBezeichnung.ParentStyleUsing.UseForeColor = false;
            this.txtBezeichnung.Size = new System.Drawing.Size(1458, 38);
            this.txtBezeichnung.Text = "Bezeichnung";
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Dpi = 254F;
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(1458, 0);
            this.txtBetrag.Multiline = true;
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(338, 38);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtBetrag.Summary = xrSummary1;
            this.txtBetrag.Text = "txtBetrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Silver;
            this.lblTitle.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_LeistungenSD", "")});
            this.lblTitle.Dpi = 254F;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblTitle.ParentStyleUsing.UseBackColor = false;
            this.lblTitle.ParentStyleUsing.UseBorderColor = false;
            this.lblTitle.ParentStyleUsing.UseBorders = false;
            this.lblTitle.ParentStyleUsing.UseBorderWidth = false;
            this.lblTitle.ParentStyleUsing.UseFont = false;
            this.lblTitle.ParentStyleUsing.UseForeColor = false;
            this.lblTitle.Size = new System.Drawing.Size(1839, 58);
            this.lblTitle.Text = "lblTitle";
            this.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Betrag1
            // 
            this.Betrag1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.Betrag1.Dpi = 254F;
            this.Betrag1.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Betrag1.ForeColor = System.Drawing.Color.Black;
            this.Betrag1.Location = new System.Drawing.Point(1458, 18);
            this.Betrag1.Multiline = true;
            this.Betrag1.Name = "Betrag1";
            this.Betrag1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Betrag1.ParentStyleUsing.UseBackColor = false;
            this.Betrag1.ParentStyleUsing.UseBorderColor = false;
            this.Betrag1.ParentStyleUsing.UseBorders = false;
            this.Betrag1.ParentStyleUsing.UseBorderWidth = false;
            this.Betrag1.ParentStyleUsing.UseFont = false;
            this.Betrag1.ParentStyleUsing.UseForeColor = false;
            this.Betrag1.Size = new System.Drawing.Size(338, 38);
            xrSummary2.FormatString = "{0:#,##0.00}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.Betrag1.Summary = xrSummary2;
            this.Betrag1.Text = "Betrag1";
            this.Betrag1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line1
            // 
            this.Line1.Dpi = 254F;
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.LineWidth = 3;
            this.Line1.Location = new System.Drawing.Point(0, 0);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(1798, 5);
            // 
            // lblTot
            // 
            this.lblTot.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_TotalLeistungenSD", "")});
            this.lblTot.Dpi = 254F;
            this.lblTot.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTot.ForeColor = System.Drawing.Color.Black;
            this.lblTot.Location = new System.Drawing.Point(0, 18);
            this.lblTot.Name = "lblTot";
            this.lblTot.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblTot.ParentStyleUsing.UseBackColor = false;
            this.lblTot.ParentStyleUsing.UseBorderColor = false;
            this.lblTot.ParentStyleUsing.UseBorders = false;
            this.lblTot.ParentStyleUsing.UseBorderWidth = false;
            this.lblTot.ParentStyleUsing.UseFont = false;
            this.lblTot.ParentStyleUsing.UseForeColor = false;
            this.lblTot.Size = new System.Drawing.Size(1458, 38);
            this.lblTot.Text = "lblTot";
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.Position = 0;
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.Detail,
                        this.ReportHeader,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(254, 0, 254, 254);
            this.Name = "Report";
            this.PageHeight = 2969;
            this.PageWidth = 2101;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  N'<?xml version="1.0" standalone="yes" ?>
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
		<FieldName>BgBudgetID</FieldName>
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
</NewDataSet>' ,  N'DECLARE @RefDate  datetime  SET @RefDate = GetDate()

DECLARE @SprachCode INT
SELECT @SprachCode = P.VerstaendigungSprachCode
FROM BgBudget B
  LEFT OUTER JOIN BgFinanzplan FP ON FP.BgFinanzplanID = B.BgFinanzplanID
  LEFT OUTER JOIN FaLeistung LEI ON LEI.FaLeistungID = FP.FaLeistungID
  LEFT OUTER JOIN FaFall FAL ON FAL.FaFallID = LEI.FaFallID
  LEFT OUTER JOIN BaPerson P ON P.BaPersonID = FAL.BaPersonID
WHERE B.BgBudgetID = {BgBudgetID}
IF @SprachCode IS NULL SET @SprachCode = 1

DECLARE @Text_LeistungenSD VARCHAR(200)
SELECT @Text_LeistungenSD = dbo.fnGetMLTextFromName(''Report_Budget'', ''LeistungenSD'', @SprachCode)
DECLARE @Text_TotalLeistungenSD VARCHAR(200)
SELECT @Text_TotalLeistungenSD = dbo.fnGetMLTextFromName(''Report_Budget'', ''LeistungenSDTotal'', @SprachCode)


DECLARE @BgPosition TABLE (
  BgKategorieCode INT,
  BgPositionsartID INT,
  Dritte BIT,
  BgSpezkontoID INT,
  Betrag MONEY,
  Style INT
)

INSERT INTO @BgPosition (BgKategorieCode, BgPositionsartID, Dritte, BgSpezkontoID, Betrag, Style)
  SELECT BgKategorieCode, BgPositionsartID, Dritte, BgSpezkontoID, Betrag, Style
  FROM dbo.fnWhGetBudgetML({BgBudgetID}, @RefDate)
  WHERE BgPositionID IS NOT NULL

DECLARE @out TABLE (
  Sort         INT NOT NULL,
  Bezeichnung  VARCHAR(100) NOT NULL,
  Betrag       MONEY NOT NULL
)


INSERT @out
select 1, dbo.fnGetMLTextFromName(''Report_Budget'', ''AusgabenKlient'', @SprachCode), isnull(sum(Betrag), 0)
from @BgPosition
where BgKategorieCode = 2 AND Dritte = 0 AND BgSpezkontoID IS NULL

INSERT @out
select 2, dbo.fnGetMLTextFromName(''Report_Budget'', ''AusgabenDritte'', @SprachCode), isnull(sum(Betrag), 0)
from @BgPosition
where BgKategorieCode = 2 AND Dritte = 1 AND BgSpezkontoID IS NULL

INSERT @out
select 3, dbo.fnGetMLTextFromName(''Report_Budget'', ''AusgabenKonti'', @SprachCode), isnull(sum(Betrag), 0)
from @BgPosition
where BgKategorieCode = 2 AND BgSpezkontoID IS NOT NULL

INSERT @out
select 4, dbo.fnGetMLTextFromName(''Report_Budget'', ''LeistungenZusatz'', @SprachCode), isnull(sum(betrag), 0)
from @BgPosition
where BgKategorieCode = 100 AND BgSpezkontoID IS NULL AND BgPositionsartID IS NOT NULL

INSERT @out
select 5, dbo.fnGetMLTextFromName(''Report_Budget'', ''AbzglEinkommenKlient'', @SprachCode), isnull(-sum(betrag), 0)
from @BgPosition
where BgKategorieCode = 1 AND not Style = 12

INSERT @out
select 6, dbo.fnGetMLTextFromName(''Report_Budget'', ''AbzglEinkommenSD'', @SprachCode), isnull(-sum(betrag), 0)
from @BgPosition
where BgKategorieCode = 1 AND Style = 12

INSERT @out
select 7, dbo.fnGetMLTextFromName(''Report_Budget'', ''AbzglKuerzungen'', @SprachCode), isnull(-sum(betrag), 0)
from @BgPosition
where BgKategorieCode = 4

SELECT
  Text_LeistungenSD = @Text_LeistungenSD,
  Text_TotalLeistungenSD = @Text_TotalLeistungenSD,
  Bezeichnung, Betrag
FROM @out order by Sort' ,  null ,  N'ShUebersichtMonatsbudgetML' ,  null )

INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShUebersichtMonatsbudgetML_Unterst' ,  N'MonatsbudgetML-Unterst' , 1,  N'/// <XRTypeInfo>
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
        private DevExpress.XtraReports.UI.XRLabel txtKSTKVGName;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtKSTName;
        private DevExpress.XtraReports.UI.XRLabel txtKonto;
        private DevExpress.XtraReports.UI.XRLabel txtBank;
        private DevExpress.XtraReports.UI.XRLabel txtHeimatort;
        private DevExpress.XtraReports.UI.XRLabel txtAHV;
        private DevExpress.XtraReports.UI.XRLabel txtName;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.XRLabel Label5;
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
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAABAAAAAAAAAFBBRFBBRFATtE6kA" +
                        "AAAAPMAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAdABTAHQAYQB0AGUAbQBlAG4AdAAAA" +
                        "AAAAZYWREVDTEFSRSBAU3ByYWNoQ29kZSBJTlQNClNFTEVDVCBAU3ByYWNoQ29kZSA9IFAuVmVyc3RhZ" +
                        "W5kaWd1bmdTcHJhY2hDb2RlIA0KRlJPTSBCZ0J1ZGdldCBCDQogIExFRlQgT1VURVIgSk9JTiBCZ0Zpb" +
                        "mFuenBsYW4gRlAgT04gRlAuQmdGaW5hbnpwbGFuSUQgPSBCLkJnRmluYW56cGxhbklEDQogIExFRlQgT" +
                        "1VURVIgSk9JTiBGYUxlaXN0dW5nIExFSSBPTiBMRUkuRmFMZWlzdHVuZ0lEID0gRlAuRmFMZWlzdHVuZ" +
                        "0lEDQogIExFRlQgT1VURVIgSk9JTiBGYUZhbGwgRkFMIE9OIEZBTC5GYUZhbGxJRCA9IExFSS5GYUZhb" +
                        "GxJRA0KICBMRUZUIE9VVEVSIEpPSU4gQmFQZXJzb24gUCBPTiBQLkJhUGVyc29uSUQgPSBGQUwuQmFQZ" +
                        "XJzb25JRA0KV0hFUkUgQi5CZ0J1ZGdldElEID0gbnVsbA0KDQpERUNMQVJFIEBUZXh0X1VudGVyc3RQZ" +
                        "XJzb25lbiBWQVJDSEFSKDIwMCkNClNFTEVDVCBAVGV4dF9VbnRlcnN0UGVyc29uZW4gPSBkYm8uZm5HZ" +
                        "XRNTFRleHQoMTAyNiwgQFNwcmFjaENvZGUpDQpERUNMQVJFIEBUZXh0X05hbWUgVkFSQ0hBUigyMDApD" +
                        "QpTRUxFQ1QgQFRleHRfTmFtZSA9IGRiby5mbkdldE1MVGV4dCgxMDI3LCBAU3ByYWNoQ29kZSkNCkRFQ" +
                        "0xBUkUgQFRleHRfQUhWIFZBUkNIQVIoMjAwKQ0KU0VMRUNUIEBUZXh0X0FIViA9IGRiby5mbkdldE1MV" +
                        "GV4dCgxMDI4LCBAU3ByYWNoQ29kZSkNCkRFQ0xBUkUgQFRleHRfSGVpbWF0b3J0IFZBUkNIQVIoMjAwK" +
                        "Q0KU0VMRUNUIEBUZXh0X0hlaW1hdG9ydCA9IGRiby5mbkdldE1MVGV4dCgxMDI5LCBAU3ByYWNoQ29kZ" +
                        "SkNCkRFQ0xBUkUgQFRleHRfQmFuayBWQVJDSEFSKDIwMCkNClNFTEVDVCBAVGV4dF9CYW5rID0gZGJvL" +
                        "mZuR2V0TUxUZXh0KDEwMzAsIEBTcHJhY2hDb2RlKQ0KREVDTEFSRSBAVGV4dF9Lb250b05yIFZBUkNIQ" +
                        "VIoMjAwKQ0KU0VMRUNUIEBUZXh0X0tvbnRvTnIgPSBkYm8uZm5HZXRNTFRleHQoMTAzMSwgQFNwcmFja" +
                        "ENvZGUpDQpERUNMQVJFIEBUZXh0X0tTVE1pZXRlIFZBUkNIQVIoMjAwKQ0KU0VMRUNUIEBUZXh0X0tTV" +
                        "E1pZXRlID0gZGJvLmZuR2V0TUxUZXh0KDEwMzIsIEBTcHJhY2hDb2RlKQ0KREVDTEFSRSBAVGV4dF9LU" +
                        "1RLVkcgVkFSQ0hBUigyMDApDQpTRUxFQ1QgQFRleHRfS1NUS1ZHID0gZGJvLmZuR2V0TUxUZXh0KDEwM" +
                        "zMsIEBTcHJhY2hDb2RlKQ0KDQoNClNFTEVDVA0KICBUZXh0X1VudGVyc3RQZXJzb25lbiA9IEBUZXh0X" +
                        "1VudGVyc3RQZXJzb25lbiwNCiAgVGV4dF9OYW1lID0gQFRleHRfTmFtZSwNCiAgVGV4dF9BSFYgPSBAV" +
                        "GV4dF9BSFYsDQogIFRleHRfSGVpbWF0b3J0ID0gQFRleHRfSGVpbWF0b3J0LA0KICBUZXh0X0JhbmsgP" +
                        "SBAVGV4dF9CYW5rLA0KICBUZXh0X0tvbnRvTnIgPSBAVGV4dF9Lb250b05yLA0KICBUZXh0X0tTVE1pZ" +
                        "XRlID0gQFRleHRfS1NUTWlldGUsDQogIFRleHRfS1NUS1ZHID0gQFRleHRfS1NUS1ZHLA0KDQogIE5hb" +
                        "WUgICAgICAgPSBQUlMuTmFtZSArICcsICcgKyBQUlMuVm9ybmFtZSwNCiAgQUhWICAgICAgICA9IElzT" +
                        "nVsbChQUlMuQUhWTnVtbWVyLCcnKSwNCiAgSGVpbWF0b3J0ICA9IElzTnVsbChHRU0uTmFtZSArICcgJ" +
                        "yArIEdFTS5LYW50b24sICcnKSwNCiAgQmFuayA9IGRiby5mbkdldFphaGx1bmdzd2VnX05hbWVfTUwoR" +
                        "lpXLkVpbnphaGx1bmdzc2NoZWluQ29kZSwgQm5rLk5hbWUsIEBTcHJhY2hDb2RlKSwNCiAgS29udG8gP" +
                        "SBkYm8uZm5HZXRaYWhsdW5nc3dlZ19OdW1tZXIoDQogICAgRlpXLkVpbnphaGx1bmdzc2NoZWluQ29kZ" +
                        "SwgRlpXLkJhbmtLb250b051bW1lciwgRlpXLklCQU5OdW1tZXIsIEZaVy5Qb3N0S29udG9OdW1tZXIpL" +
                        "A0KICBLU1ROYW1lICAgID0gSXNOdWxsKEtTVC5OYW1lLCAnJyksDQogIEtTVEtWR05hbWUgPSBJc051b" +
                        "GwoS1NUS1ZHLk5hbWUsICcnKQ0KDQpGUk9NIEJnQnVkZ2V0ICAgICAgICAgICAgICAgICAgICAgICAgQ" +
                        "kJHDQogIElOTkVSIEpPSU4gQmdGaW5hbnpwbGFuX0JhUGVyc29uICAgU1BQIE9OIFNQUC5CZ0ZpbmFue" +
                        "nBsYW5JRCA9IEJCRy5CZ0ZpbmFuenBsYW5JRA0KICBMRUZUICBKT0lOIEJhUGVyc29uICAgICAgICAgI" +
                        "CAgICAgIFBSUyBPTiBQUlMuQmFQZXJzb25JRCA9IFNQUC5CYVBlcnNvbklEDQogIExFRlQgIEpPSU4gQ" +
                        "mFHZW1laW5kZSAgICAgICAgICAgICAgR0VNIE9OIEdFTS5CYUdlbWVpbmRlSUQgPSBQUlMuSGVpbWF0R" +
                        "2VtZWluZGVCYUdlbWVpbmRlSUQNCiAgTEVGVCAgSk9JTiBCYVphaGx1bmdzd2VnICAgICAgICAgICBGW" +
                        "lcgT04gRlpXLkJhWmFobHVuZ3N3ZWdJRCA9ICggLS0gU1BQLkZsWmFobHVuZ3N3ZWdJRA0KICAgIFNFT" +
                        "EVDVCBUT1AgMSBaLkJhWmFobHVuZ3N3ZWdJRCBmcm9tIEJhWmFobHVuZ3N3ZWcgWg0KICAgIHdoZXJlI" +
                        "FouQmFQZXJzb25JRCA9IFBSUy5CYVBlcnNvbklEDQogICAgICBhbmQgR2V0RGF0ZSgpIGJldHdlZW4gS" +
                        "XNOdWxsKFouRGF0dW1Wb24sIEdldERhdGUoKSkgYW5kIElzTnVsbChaLkRhdHVtQmlzLCBHZXREYXRlK" +
                        "CkpDQogICAgb3JkZXIgYnkgWi5EYXR1bVZvbiBkZXNjDQogICkNCiAgTEVGVCAgSk9JTiBCYUJhbmsgI" +
                        "CAgICAgICAgICAgICAgICBCbmsgT04gQm5rLkJhQmFua0lEID0gRlpXLkJhQmFua0lEDQogIExFRlQgI" +
                        "EpPSU4gS2JLb3N0ZW5zdGVsbGUgICAgICAgICAgS1NUIE9OIEtTVC5LYktvc3RlbnN0ZWxsZUlEID0gU" +
                        "1BQLktiS29zdGVuc3RlbGxlSUQNCiAgTEVGVCAgSk9JTiBLYktvc3RlbnN0ZWxsZSAgICAgICBLU1RLV" +
                        "kcgT04gS1NUS1ZHLktiS29zdGVuc3RlbGxlSUQgPSBTUFAuS2JLb3N0ZW5zdGVsbGVJRF9LVkcNCldIR" +
                        "VJFIFNQUC5Jc3RVbnRlcnN0dWV0enQgPSAxDQogIEFORCBCQkcuTWFzdGVyQnVkZ2V0ID0gMA0KICBBT" +
                        "kQgQkJHLkJnQnVkZ2V0SUQgPSBudWxs";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.txtKSTKVGName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKSTName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKonto = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBank = new DevExpress.XtraReports.UI.XRLabel();
            this.txtHeimatort = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAHV = new DevExpress.XtraReports.UI.XRLabel();
            this.txtName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.Label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label5 = new DevExpress.XtraReports.UI.XRLabel();
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
                        this.txtKSTKVGName,
                        this.txtKSTName,
                        this.txtKonto,
                        this.txtBank,
                        this.txtHeimatort,
                        this.txtAHV,
                        this.txtName});
            this.Detail.Height = 18;
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
                        this.xrLabel1,
                        this.Line2,
                        this.Label7,
                        this.Label6,
                        this.Label5,
                        this.Label4,
                        this.Label3,
                        this.Label2,
                        this.Label1});
            this.ReportHeader.Height = 55;
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
            this.ReportFooter.Height = 25;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
            this.ReportFooter.Visible = false;
            // 
            // txtKSTKVGName
            // 
            this.txtKSTKVGName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KSTKVGName", "")});
            this.txtKSTKVGName.Font = new System.Drawing.Font("Arial", 9F);
            this.txtKSTKVGName.ForeColor = System.Drawing.Color.Black;
            this.txtKSTKVGName.Location = new System.Drawing.Point(627, 0);
            this.txtKSTKVGName.Multiline = true;
            this.txtKSTKVGName.Name = "txtKSTKVGName";
            this.txtKSTKVGName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKSTKVGName.ParentStyleUsing.UseBackColor = false;
            this.txtKSTKVGName.ParentStyleUsing.UseBorderColor = false;
            this.txtKSTKVGName.ParentStyleUsing.UseBorders = false;
            this.txtKSTKVGName.ParentStyleUsing.UseBorderWidth = false;
            this.txtKSTKVGName.ParentStyleUsing.UseFont = false;
            this.txtKSTKVGName.ParentStyleUsing.UseForeColor = false;
            this.txtKSTKVGName.Size = new System.Drawing.Size(93, 15);
            this.txtKSTKVGName.Text = "KSTKVGName";
            // 
            // txtKSTName
            // 
            this.txtKSTName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KSTName", "")});
            this.txtKSTName.Font = new System.Drawing.Font("Arial", 9F);
            this.txtKSTName.ForeColor = System.Drawing.Color.Black;
            this.txtKSTName.Location = new System.Drawing.Point(527, 0);
            this.txtKSTName.Multiline = true;
            this.txtKSTName.Name = "txtKSTName";
            this.txtKSTName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKSTName.ParentStyleUsing.UseBackColor = false;
            this.txtKSTName.ParentStyleUsing.UseBorderColor = false;
            this.txtKSTName.ParentStyleUsing.UseBorders = false;
            this.txtKSTName.ParentStyleUsing.UseBorderWidth = false;
            this.txtKSTName.ParentStyleUsing.UseFont = false;
            this.txtKSTName.ParentStyleUsing.UseForeColor = false;
            this.txtKSTName.Size = new System.Drawing.Size(100, 15);
            this.txtKSTName.Text = "KSTName";
            // 
            // txtKonto
            // 
            this.txtKonto.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Konto", "")});
            this.txtKonto.Font = new System.Drawing.Font("Arial", 9F);
            this.txtKonto.ForeColor = System.Drawing.Color.Black;
            this.txtKonto.Location = new System.Drawing.Point(427, 0);
            this.txtKonto.Multiline = true;
            this.txtKonto.Name = "txtKonto";
            this.txtKonto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKonto.ParentStyleUsing.UseBackColor = false;
            this.txtKonto.ParentStyleUsing.UseBorderColor = false;
            this.txtKonto.ParentStyleUsing.UseBorders = false;
            this.txtKonto.ParentStyleUsing.UseBorderWidth = false;
            this.txtKonto.ParentStyleUsing.UseFont = false;
            this.txtKonto.ParentStyleUsing.UseForeColor = false;
            this.txtKonto.Size = new System.Drawing.Size(100, 15);
            this.txtKonto.Text = "Konto";
            // 
            // txtBank
            // 
            this.txtBank.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Bank", "")});
            this.txtBank.Font = new System.Drawing.Font("Arial", 9F);
            this.txtBank.ForeColor = System.Drawing.Color.Black;
            this.txtBank.Location = new System.Drawing.Point(333, 0);
            this.txtBank.Multiline = true;
            this.txtBank.Name = "txtBank";
            this.txtBank.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBank.ParentStyleUsing.UseBackColor = false;
            this.txtBank.ParentStyleUsing.UseBorderColor = false;
            this.txtBank.ParentStyleUsing.UseBorders = false;
            this.txtBank.ParentStyleUsing.UseBorderWidth = false;
            this.txtBank.ParentStyleUsing.UseFont = false;
            this.txtBank.ParentStyleUsing.UseForeColor = false;
            this.txtBank.Size = new System.Drawing.Size(94, 15);
            this.txtBank.Text = "Bank";
            // 
            // txtHeimatort
            // 
            this.txtHeimatort.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Heimatort", "")});
            this.txtHeimatort.Font = new System.Drawing.Font("Arial", 9F);
            this.txtHeimatort.ForeColor = System.Drawing.Color.Black;
            this.txtHeimatort.Location = new System.Drawing.Point(233, 0);
            this.txtHeimatort.Multiline = true;
            this.txtHeimatort.Name = "txtHeimatort";
            this.txtHeimatort.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtHeimatort.ParentStyleUsing.UseBackColor = false;
            this.txtHeimatort.ParentStyleUsing.UseBorderColor = false;
            this.txtHeimatort.ParentStyleUsing.UseBorders = false;
            this.txtHeimatort.ParentStyleUsing.UseBorderWidth = false;
            this.txtHeimatort.ParentStyleUsing.UseFont = false;
            this.txtHeimatort.ParentStyleUsing.UseForeColor = false;
            this.txtHeimatort.Size = new System.Drawing.Size(100, 15);
            this.txtHeimatort.Text = "Heimatort";
            // 
            // txtAHV
            // 
            this.txtAHV.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AHV", "")});
            this.txtAHV.Font = new System.Drawing.Font("Arial", 9F);
            this.txtAHV.ForeColor = System.Drawing.Color.Black;
            this.txtAHV.Location = new System.Drawing.Point(140, 0);
            this.txtAHV.Multiline = true;
            this.txtAHV.Name = "txtAHV";
            this.txtAHV.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtAHV.ParentStyleUsing.UseBackColor = false;
            this.txtAHV.ParentStyleUsing.UseBorderColor = false;
            this.txtAHV.ParentStyleUsing.UseBorders = false;
            this.txtAHV.ParentStyleUsing.UseBorderWidth = false;
            this.txtAHV.ParentStyleUsing.UseFont = false;
            this.txtAHV.ParentStyleUsing.UseForeColor = false;
            this.txtAHV.Size = new System.Drawing.Size(93, 15);
            this.txtAHV.Text = "AHV";
            // 
            // txtName
            // 
            this.txtName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.txtName.Font = new System.Drawing.Font("Arial", 9F);
            this.txtName.ForeColor = System.Drawing.Color.Black;
            this.txtName.Location = new System.Drawing.Point(0, 0);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtName.ParentStyleUsing.UseBackColor = false;
            this.txtName.ParentStyleUsing.UseBorderColor = false;
            this.txtName.ParentStyleUsing.UseBorders = false;
            this.txtName.ParentStyleUsing.UseBorderWidth = false;
            this.txtName.ParentStyleUsing.UseFont = false;
            this.txtName.ParentStyleUsing.UseForeColor = false;
            this.txtName.Size = new System.Drawing.Size(140, 15);
            this.txtName.Text = "Name";
            // 
            // xrLabel1
            // 
            this.xrLabel1.BackColor = System.Drawing.Color.Silver;
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_UnterstPersonen", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F);
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
            this.xrLabel1.Size = new System.Drawing.Size(724, 23);
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.Location = new System.Drawing.Point(0, 50);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(724, 2);
            // 
            // Label7
            // 
            this.Label7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_KSTKVG", "")});
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(627, 31);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(93, 15);
            this.Label7.Text = "Label7";
            // 
            // Label6
            // 
            this.Label6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_KSTMiete", "")});
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(527, 31);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(100, 15);
            this.Label6.Text = "Label6";
            // 
            // Label5
            // 
            this.Label5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_KontoNr", "")});
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(427, 31);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(100, 15);
            this.Label5.Text = "Label5";
            // 
            // Label4
            // 
            this.Label4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_Bank", "")});
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(333, 31);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(93, 15);
            this.Label4.Text = "Label4";
            // 
            // Label3
            // 
            this.Label3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_Heimatort", "")});
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(233, 31);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(100, 15);
            this.Label3.Text = "Label3";
            // 
            // Label2
            // 
            this.Label2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_AHV", "")});
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(140, 31);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(94, 15);
            this.Label2.Text = "Label2";
            // 
            // Label1
            // 
            this.Label1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_Name", "")});
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(0, 31);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(140, 15);
            this.Label1.Text = "Label1";
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
            this.Margins = new System.Drawing.Printing.Margins(100, 0, 100, 100);
            this.Name = "Report";
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  N'<?xml version="1.0" standalone="yes" ?>
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
		<FieldName>BgBudgetID</FieldName>
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
</NewDataSet>' ,  N'DECLARE @SprachCode INT
SELECT @SprachCode = P.VerstaendigungSprachCode
FROM BgBudget B
  LEFT OUTER JOIN BgFinanzplan FP ON FP.BgFinanzplanID = B.BgFinanzplanID
  LEFT OUTER JOIN FaLeistung LEI ON LEI.FaLeistungID = FP.FaLeistungID
  LEFT OUTER JOIN FaFall FAL ON FAL.FaFallID = LEI.FaFallID
  LEFT OUTER JOIN BaPerson P ON P.BaPersonID = FAL.BaPersonID
WHERE B.BgBudgetID = {BgBudgetID}
IF @SprachCode IS NULL SET @SprachCode = 1


DECLARE @Text_UnterstPersonen VARCHAR(200)
SELECT @Text_UnterstPersonen = dbo.fnGetMLTextFromName(''Report_Budget'', ''UnterstuetztePersonen'', @SprachCode)
DECLARE @Text_Name VARCHAR(200)
SELECT @Text_Name = dbo.fnGetMLTextFromName(''Report_Budget'', ''Name'', @SprachCode)
DECLARE @Text_AHV VARCHAR(200)
SELECT @Text_AHV = dbo.fnGetMLTextFromName(''Report_Budget'', ''AHV'', @SprachCode)
DECLARE @Text_Heimatort VARCHAR(200)
SELECT @Text_Heimatort = dbo.fnGetMLTextFromName(''Report_Budget'', ''Heimatort'', @SprachCode)
DECLARE @Text_Bank VARCHAR(200)
SELECT @Text_Bank = dbo.fnGetMLTextFromName(''Report_Budget'', ''Bank'', @SprachCode)
DECLARE @Text_KontoNr VARCHAR(200)
SELECT @Text_KontoNr = dbo.fnGetMLTextFromName(''Report_Budget'', ''KURZ_Kontonummer'', @SprachCode)
DECLARE @Text_KSTMiete VARCHAR(200)
SELECT @Text_KSTMiete = dbo.fnGetMLTextFromName(''Report_Budget'', ''KST_Miete'', @SprachCode)
DECLARE @Text_KSTKVG VARCHAR(200)
SELECT @Text_KSTKVG = dbo.fnGetMLTextFromName(''Report_Budget'', ''KST_KVG'', @SprachCode)


SELECT
  Text_UnterstPersonen = @Text_UnterstPersonen,
  Text_Name = @Text_Name,
  Text_AHV = @Text_AHV,
  Text_Heimatort = @Text_Heimatort,
  Text_Bank = @Text_Bank,
  Text_KontoNr = @Text_KontoNr,
  Text_KSTMiete = @Text_KSTMiete,
  Text_KSTKVG = @Text_KSTKVG,

  Name       = PRS.Name + '', '' + PRS.Vorname,
  AHV        = IsNull(PRS.AHVNummer,''''),
  Heimatort  = IsNull(GEM.Name + '' '' + GEM.Kanton, ''''),
  Bank = dbo.fnGetZahlungsweg_Name_ML(FZW.EinzahlungsscheinCode, Bnk.Name, @SprachCode),
  Konto = dbo.fnGetZahlungsweg_Nummer(
    FZW.EinzahlungsscheinCode, FZW.BankKontoNummer, FZW.IBANNummer, FZW.PostKontoNummer)

FROM BgBudget                        BBG
  INNER JOIN BgFinanzplan_BaPerson   SPP ON SPP.BgFinanzplanID = BBG.BgFinanzplanID
  LEFT  JOIN BaPerson                PRS ON PRS.BaPersonID = SPP.BaPersonID
  LEFT  JOIN BaGemeinde              GEM ON GEM.BaGemeindeID = PRS.HeimatGemeindeBaGemeindeID
  LEFT  JOIN BaZahlungsweg           FZW ON FZW.BaZahlungswegID = ( -- SPP.FlZahlungswegID
    SELECT TOP 1 Z.BaZahlungswegID from BaZahlungsweg Z
    where Z.BaPersonID = PRS.BaPersonID
      and GetDate() between IsNull(Z.DatumVon, GetDate()) and IsNull(Z.DatumBis, GetDate())
    order by Z.DatumVon desc
  )
  LEFT  JOIN BaBank                  Bnk ON Bnk.BaBankID = FZW.BaBankID
WHERE SPP.IstUnterstuetzt = 1
  AND BBG.MasterBudget = 0
  AND BBG.BgBudgetID = {BgBudgetID}' ,  null ,  N'ShUebersichtMonatsbudgetML' ,  null )

INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShUebersichtMonatsbudgetML_Zahlungen' ,  N'MonatsbudgetML-Zahlungen' , 1,  N'/// <XRTypeInfo>
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
        private DevExpress.XtraReports.UI.DetailBand DetailZahlungen;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLine Line6;
        private DevExpress.XtraReports.UI.XRLine Line5;
        private DevExpress.XtraReports.UI.XRLine Line4;
        private DevExpress.XtraReports.UI.XRLine Line3;
        private DevExpress.XtraReports.UI.XRLabel txtCashOrCheckAm;
        private DevExpress.XtraReports.UI.XRLabel txtVerfalldatum;
        private DevExpress.XtraReports.UI.XRLabel txtKOA;
        private DevExpress.XtraReports.UI.XRLabel txtBuchungstext;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel lblTitle;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeaderZahlungen;
        private DevExpress.XtraReports.UI.XRLine Line11;
        private DevExpress.XtraReports.UI.XRLine Line10;
        private DevExpress.XtraReports.UI.XRLine Line9;
        private DevExpress.XtraReports.UI.XRLine Line8;
        private DevExpress.XtraReports.UI.XRLine Line7;
        private DevExpress.XtraReports.UI.XRLabel Label5;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.XRLabel Label3;
        private DevExpress.XtraReports.UI.XRLabel Label2;
        private DevExpress.XtraReports.UI.XRLabel Label1;
        private DevExpress.XtraReports.UI.XRLabel txtEmpfänger;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel Betrag1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel Betrag2;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private System.Resources.ResourceManager _resources;
        public Report() {
            this.InitializeComponent();
        }
        private System.Resources.ResourceManager resources {
            get {
                if (_resources == null) {
                    string resourceString = "zsrvvgEAAACRAAAAbFN5c3RlbS5SZXNvdXJjZXMuUmVzb3VyY2VSZWFkZXIsIG1zY29ybGliLCBWZXJza" +
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49Yjc3YTVjNTYxOTM0ZTA4O" +
                        "SNTeXN0ZW0uUmVzb3VyY2VzLlJ1bnRpbWVSZXNvdXJjZVNldAIAAAACAAAAAAAAAFBBRFBBRFChz7yjE" +
                        "7ROpAAAAABJAAAARAEAAERSAGUAcABvAHIAdABIAGUAYQBkAGUAcgAuAFMAYwByAGkAcAB0AHMALgBPA" +
                        "G4AQgBlAGYAbwByAGUAUAByAGkAbgB0AAAAAAAycwBxAGwAUQB1AGUAcgB5ADEALgBTAGUAbABlAGMAd" +
                        "ABTAHQAYQB0AGUAbQBlAG4AdAAXAQAAAZQCcHJpdmF0ZSB2b2lkIE9uQmVmb3JlUHJpbnQob2JqZWN0I" +
                        "HNlbmRlciwgU3lzdGVtLkRyYXdpbmcuUHJpbnRpbmcuUHJpbnRFdmVudEFyZ3MgZSkgDQp7DQogIC8vI" +
                        "EJlaSBJbnRlZ3JhdGlvbkJFIHNvbGxlbiBrZWllbiBEZWF0aWxzIGRlciBaYWhsdW5nZW4gDQogIC8vI" +
                        "GdlZHJ1Y2t0IHdlcmRlbiwgbnVyIFRvdGFsZSBkZXIgRW1wZsOkbmdlcg0KICBHcm91cEhlYWRlclpha" +
                        "Gx1bmdlbi5WaXNpYmxlID0gZmFsc2U7DQogIERldGFpbFphaGx1bmdlbi5WaXNpYmxlID0gZmFsc2U7D" +
                        "Qp9AeYVREVDTEFSRSBAU3ByYWNoQ29kZSBJTlQNClNFTEVDVCBAU3ByYWNoQ29kZSA9IFAuVmVyc3RhZ" +
                        "W5kaWd1bmdTcHJhY2hDb2RlIA0KRlJPTSBCZ0J1ZGdldCBCDQogIExFRlQgT1VURVIgSk9JTiBCZ0Zpb" +
                        "mFuenBsYW4gRlAgT04gRlAuQmdGaW5hbnpwbGFuSUQgPSBCLkJnRmluYW56cGxhbklEDQogIExFRlQgT" +
                        "1VURVIgSk9JTiBGYUxlaXN0dW5nIExFSSBPTiBMRUkuRmFMZWlzdHVuZ0lEID0gRlAuRmFMZWlzdHVuZ" +
                        "0lEDQogIExFRlQgT1VURVIgSk9JTiBGYUZhbGwgRkFMIE9OIEZBTC5GYUZhbGxJRCA9IExFSS5GYUZhb" +
                        "GxJRA0KICBMRUZUIE9VVEVSIEpPSU4gQmFQZXJzb24gUCBPTiBQLkJhUGVyc29uSUQgPSBGQUwuQmFQZ" +
                        "XJzb25JRA0KV0hFUkUgQi5CZ0J1ZGdldElEID0gbnVsbA0KSUYgQFNwcmFjaENvZGUgSVMgTlVMTCBTR" +
                        "VQgQFNwcmFjaENvZGUgPSAxDQoNCkRFQ0xBUkUgQFRleHRfWmFobHVuZ2VuIFZBUkNIQVIoMjAwKQ0KU" +
                        "0VMRUNUIEBUZXh0X1phaGx1bmdlbiA9IGRiby5mbkdldE1MVGV4dEZyb21OYW1lKCdSZXBvcnRfQnVkZ" +
                        "2V0JywgJ1phaGx1bmdlbicsIEBTcHJhY2hDb2RlKQ0KREVDTEFSRSBAVGV4dF9Ub3RhbCBWQVJDSEFSK" +
                        "DIwMCkNClNFTEVDVCBAVGV4dF9Ub3RhbCA9IGRiby5mbkdldE1MVGV4dEZyb21OYW1lKCdSZXBvcnRfQ" +
                        "nVkZ2V0JywgJ1RvdGFsJywgQFNwcmFjaENvZGUpDQpERUNMQVJFIEBUZXh0X0FuS2xpZW50IFZBUkNIQ" +
                        "VIoMjAwKQ0KU0VMRUNUIEBUZXh0X0FuS2xpZW50ID0gZGJvLmZuR2V0TUxUZXh0RnJvbU5hbWUoJ1Jlc" +
                        "G9ydF9CdWRnZXQnLCAnQW4gS2xpZW50JywgQFNwcmFjaENvZGUpDQpERUNMQVJFIEBUZXh0X09obmVOY" +
                        "W1lbiBWQVJDSEFSKDIwMCkNClNFTEVDVCBAVGV4dF9PaG5lTmFtZW4gPSBkYm8uZm5HZXRNTFRleHRGc" +
                        "m9tTmFtZSgnUmVwb3J0X0J1ZGdldCcsICcoT2huZSBOYW1lbiknLCBAU3ByYWNoQ29kZSkNCg0KDQpER" +
                        "UNMQVJFIEBCZ0J1ZGdldElEICAgICBpbnQsDQogICAgICAgIEBCZ0ZpbmFuenBsYW5JRCBpbnQNCg0KU" +
                        "0VMRUNUDQogIEBCZ0J1ZGdldElEID0gQmdCdWRnZXRJRCwNCiAgQEJnRmluYW56cGxhbklEID0gQmdGa" +
                        "W5hbnpwbGFuSUQNCkZST00gQmdCdWRnZXQNCldIRVJFIEJnQnVkZ2V0SUQgPSBudWxsDQoNClNFTEVDV" +
                        "A0KICBUZXh0X1phaGx1bmdlbiA9IEBUZXh0X1phaGx1bmdlbiwNCiAgVGV4dF9aYWhsdW5nZW5Ub3Rhb" +
                        "CA9IEBUZXh0X1RvdGFsICsgJyAnICsgQFRleHRfWmFobHVuZ2VuLA0KICBQYXlUb0NsaWVudCA9IENBU" +
                        "0UNCiAgICAgIFdIRU4gS0JVLktiQXVzemFobHVuZ3NBcnRDb2RlIElOICgxMDMsIDEwNCkgICAgVEhFT" +
                        "iAxDQogICAgICBXSEVOIEtSRS5CYVBlcnNvbklEIElTIE5VTEwgICAgICAgICAgICAgICAgICAgIFRIR" +
                        "U4gMA0KICAgICAgV0hFTiBLUkUuQmFQZXJzb25JRCBJTiAoU0VMRUNUIEJGUC5CYVBlcnNvbklEDQogI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICBGUk9NIEJnRmluYW56cGxhbl9CYVBlcnNvbiAgQkZQD" +
                        "QogICAgICAgICAgICAgICAgICAgICAgICAgICAgICBXSEVSRSBCRlAuQmdGaW5hbnpwbGFuSUQgPSBAQ" +
                        "mdGaW5hbnpwbGFuSUQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQU5EIEJGUC5Jc3RVb" +
                        "nRlcnN0dWV0enQgPSAxKSBUSEVOIDENCi8qDQogICAgICBXSEVOIEtSRS5CYVBlcnNvbklEIElOIChTR" +
                        "UxFQ1QgQlpXLkJhUGVyc29uSUQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEZST00gQmdGa" +
                        "W5hbnpwbGFuX0JhUGVyc29uICBCRlANCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgSU5OR" +
                        "VIgSk9JTiBCYVphaGx1bmdzd2VnICBCWlcgT04gQlpXLkJhWmFobHVuZ3N3ZWdJRCA9IEJGUC5CYVpha" +
                        "Gx1bmdzd2VnSUQNCiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFdIRVJFIEJGUC5CZ0ZpbmFue" +
                        "nBsYW5JRCA9IEBCZ0ZpbmFuenBsYW5JRA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBT" +
                        "kQgQkZQLklzdFVudGVyc3R1ZXR6dCA9IDEpIFRIRU4gMQ0KKi8NCiAgICAgIEVMU0UgMA0KICAgIEVOR" +
                        "CwNCiAgRW1wZsOkbmdlciA9DQogICAgQ0FTRSBXSEVOIEtCVS5LYkF1c3phaGx1bmdzQXJ0Q29kZSBJT" +
                        "iAoMTAzLCAxMDQpDQogICAgICBUSEVOIEBUZXh0X0FuS2xpZW50DQogICAgICBFTFNFIElTTlVMTChLU" +
                        "kUuS3JlZGl0b3IsIEBUZXh0X09obmVOYW1lbikNCiAgICBFTkQgKyAnIC0gJyArIElTTlVMTChkYm8uZ" +
                        "m5MT1ZNTFRleHQoJ0tiQXVzemFobHVuZ3NBcnQnLCBLQlUuS2JBdXN6YWhsdW5nc0FydENvZGUsIEBTc" +
                        "HJhY2hDb2RlKSwgJycpLA0KICBLQksuQnVjaHVuZ3N0ZXh0LA0KICBLT0EgPSBGS0EuS29udG9OciwNC" +
                        "iAgS0JVLlZhbHV0YURhdHVtLA0KICBLQlUuQmFyYmVsZWdEYXR1bSwNCiAgS0JLLkJldHJhZw0KRlJPT" +
                        "SBLYkJ1Y2h1bmcgICAgICAgICAgICAgICAgICBLQlUNCiAgSU5ORVIgSk9JTiBLYkJ1Y2h1bmdLb3N0Z" +
                        "W5hcnQgS0JLIE9OIEtCSy5LYkJ1Y2h1bmdJRCA9IEtCVS5LYkJ1Y2h1bmdJRA0KICBJTk5FUiBKT0lOI" +
                        "EJnS29zdGVuYXJ0ICAgICAgICBGS0EgT04gRktBLkJnS29zdGVuYXJ0SUQgPSBLQksuQmdLb3N0ZW5hc" +
                        "nRJRA0KICBMRUZUICBKT0lOIHZ3S3JlZGl0b3IgICAgICAgICBLUkUgT04gS1JFLkJhWmFobHVuZ3N3Z" +
                        "WdJRCA9IEtCVS5CYVphaGx1bmdzd2VnSUQNCldIRVJFIEtCVS5CZ0J1ZGdldElEID0gQEJnQnVkZ2V0S" +
                        "UQNCk9SREVSIEJZDQogIFBheVRvQ2xpZW50IERFU0MsDQogIDQsIC8qIEVtcGbDpG5nZXIgKi8NCiAgS" +
                        "0JVLlZhbHV0YURhdHVtLA0KICBLQksuQnVjaHVuZ3N0ZXh0";
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
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            this.DetailZahlungen = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.GroupHeaderZahlungen = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.Line6 = new DevExpress.XtraReports.UI.XRLine();
            this.Line5 = new DevExpress.XtraReports.UI.XRLine();
            this.Line4 = new DevExpress.XtraReports.UI.XRLine();
            this.Line3 = new DevExpress.XtraReports.UI.XRLine();
            this.txtCashOrCheckAm = new DevExpress.XtraReports.UI.XRLabel();
            this.txtVerfalldatum = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKOA = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBuchungstext = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.Line11 = new DevExpress.XtraReports.UI.XRLine();
            this.Line10 = new DevExpress.XtraReports.UI.XRLine();
            this.Line9 = new DevExpress.XtraReports.UI.XRLine();
            this.Line8 = new DevExpress.XtraReports.UI.XRLine();
            this.Line7 = new DevExpress.XtraReports.UI.XRLine();
            this.Label5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtEmpfänger = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Betrag1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Betrag2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // DetailZahlungen
            // 
            this.DetailZahlungen.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtBetrag,
                        this.Line6,
                        this.Line5,
                        this.Line4,
                        this.Line3,
                        this.txtCashOrCheckAm,
                        this.txtVerfalldatum,
                        this.txtKOA,
                        this.txtBuchungstext});
            this.DetailZahlungen.Height = 20;
            this.DetailZahlungen.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.DetailZahlungen.Name = "DetailZahlungen";
            this.DetailZahlungen.ParentStyleUsing.UseBackColor = false;
            this.DetailZahlungen.ParentStyleUsing.UseBorderColor = false;
            this.DetailZahlungen.ParentStyleUsing.UseBorders = false;
            this.DetailZahlungen.ParentStyleUsing.UseBorderWidth = false;
            this.DetailZahlungen.ParentStyleUsing.UseFont = false;
            this.DetailZahlungen.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.lblTitle});
            this.ReportHeader.Height = 25;
            this.ReportHeader.Name = "ReportHeader";
            this.ReportHeader.ParentStyleUsing.UseBackColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorderColor = false;
            this.ReportHeader.ParentStyleUsing.UseBorders = false;
            this.ReportHeader.ParentStyleUsing.UseBorderWidth = false;
            this.ReportHeader.ParentStyleUsing.UseFont = false;
            this.ReportHeader.ParentStyleUsing.UseForeColor = false;
            this.ReportHeader.Scripts.OnBeforePrint = resources.GetString("ReportHeader.Scripts.OnBeforePrint");
            // 
            // GroupHeaderZahlungen
            // 
            this.GroupHeaderZahlungen.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Line11,
                        this.Line10,
                        this.Line9,
                        this.Line8,
                        this.Line7,
                        this.Label5,
                        this.Label4,
                        this.Label3,
                        this.Label2,
                        this.Label1,
                        this.txtEmpfänger});
            this.GroupHeaderZahlungen.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("Empfänger", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeaderZahlungen.Height = 58;
            this.GroupHeaderZahlungen.Name = "GroupHeaderZahlungen";
            this.GroupHeaderZahlungen.ParentStyleUsing.UseBackColor = false;
            this.GroupHeaderZahlungen.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeaderZahlungen.ParentStyleUsing.UseBorders = false;
            this.GroupHeaderZahlungen.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeaderZahlungen.ParentStyleUsing.UseFont = false;
            this.GroupHeaderZahlungen.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel1,
                        this.Betrag1});
            this.GroupFooter1.Height = 26;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorders = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter1.ParentStyleUsing.UseFont = false;
            this.GroupFooter1.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Betrag2,
                        this.Label7,
                        this.Line2,
                        this.Line1});
            this.ReportFooter.Height = 35;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.ParentStyleUsing.UseBackColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorderColor = false;
            this.ReportFooter.ParentStyleUsing.UseBorders = false;
            this.ReportFooter.ParentStyleUsing.UseBorderWidth = false;
            this.ReportFooter.ParentStyleUsing.UseFont = false;
            this.ReportFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(640, 0);
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(73, 18);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtBetrag.Summary = xrSummary1;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line6
            // 
            this.Line6.ForeColor = System.Drawing.Color.Black;
            this.Line6.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line6.Location = new System.Drawing.Point(520, 0);
            this.Line6.Name = "Line6";
            this.Line6.ParentStyleUsing.UseBackColor = false;
            this.Line6.ParentStyleUsing.UseBorderColor = false;
            this.Line6.ParentStyleUsing.UseBorders = false;
            this.Line6.ParentStyleUsing.UseBorderWidth = false;
            this.Line6.ParentStyleUsing.UseFont = false;
            this.Line6.ParentStyleUsing.UseForeColor = false;
            this.Line6.Size = new System.Drawing.Size(2, 20);
            // 
            // Line5
            // 
            this.Line5.ForeColor = System.Drawing.Color.Black;
            this.Line5.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line5.Location = new System.Drawing.Point(439, 0);
            this.Line5.Name = "Line5";
            this.Line5.ParentStyleUsing.UseBackColor = false;
            this.Line5.ParentStyleUsing.UseBorderColor = false;
            this.Line5.ParentStyleUsing.UseBorders = false;
            this.Line5.ParentStyleUsing.UseBorderWidth = false;
            this.Line5.ParentStyleUsing.UseFont = false;
            this.Line5.ParentStyleUsing.UseForeColor = false;
            this.Line5.Size = new System.Drawing.Size(2, 20);
            // 
            // Line4
            // 
            this.Line4.ForeColor = System.Drawing.Color.Black;
            this.Line4.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line4.Location = new System.Drawing.Point(641, 0);
            this.Line4.Name = "Line4";
            this.Line4.ParentStyleUsing.UseBackColor = false;
            this.Line4.ParentStyleUsing.UseBorderColor = false;
            this.Line4.ParentStyleUsing.UseBorders = false;
            this.Line4.ParentStyleUsing.UseBorderWidth = false;
            this.Line4.ParentStyleUsing.UseFont = false;
            this.Line4.ParentStyleUsing.UseForeColor = false;
            this.Line4.Size = new System.Drawing.Size(2, 20);
            // 
            // Line3
            // 
            this.Line3.ForeColor = System.Drawing.Color.Black;
            this.Line3.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line3.Location = new System.Drawing.Point(375, 0);
            this.Line3.Name = "Line3";
            this.Line3.ParentStyleUsing.UseBackColor = false;
            this.Line3.ParentStyleUsing.UseBorderColor = false;
            this.Line3.ParentStyleUsing.UseBorders = false;
            this.Line3.ParentStyleUsing.UseBorderWidth = false;
            this.Line3.ParentStyleUsing.UseFont = false;
            this.Line3.ParentStyleUsing.UseForeColor = false;
            this.Line3.Size = new System.Drawing.Size(2, 20);
            // 
            // txtCashOrCheckAm
            // 
            this.txtCashOrCheckAm.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BarbelegDatum", "")});
            this.txtCashOrCheckAm.Font = new System.Drawing.Font("Arial", 10F);
            this.txtCashOrCheckAm.ForeColor = System.Drawing.Color.Black;
            this.txtCashOrCheckAm.Location = new System.Drawing.Point(522, 0);
            this.txtCashOrCheckAm.Name = "txtCashOrCheckAm";
            this.txtCashOrCheckAm.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtCashOrCheckAm.ParentStyleUsing.UseBackColor = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseBorderColor = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseBorders = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseBorderWidth = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseFont = false;
            this.txtCashOrCheckAm.ParentStyleUsing.UseForeColor = false;
            this.txtCashOrCheckAm.Size = new System.Drawing.Size(116, 18);
            xrSummary2.FormatString = "{0:dd.MM.yyyy hh:mm}";
            this.txtCashOrCheckAm.Summary = xrSummary2;
            this.txtCashOrCheckAm.Text = "txtCashOrCheckAm";
            this.txtCashOrCheckAm.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // txtVerfalldatum
            // 
            this.txtVerfalldatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ValutaDatum", "{0:dd.MM.yyyy}")});
            this.txtVerfalldatum.Font = new System.Drawing.Font("Arial", 10F);
            this.txtVerfalldatum.ForeColor = System.Drawing.Color.Black;
            this.txtVerfalldatum.Location = new System.Drawing.Point(441, 0);
            this.txtVerfalldatum.Name = "txtVerfalldatum";
            this.txtVerfalldatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtVerfalldatum.ParentStyleUsing.UseBackColor = false;
            this.txtVerfalldatum.ParentStyleUsing.UseBorderColor = false;
            this.txtVerfalldatum.ParentStyleUsing.UseBorders = false;
            this.txtVerfalldatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtVerfalldatum.ParentStyleUsing.UseFont = false;
            this.txtVerfalldatum.ParentStyleUsing.UseForeColor = false;
            this.txtVerfalldatum.Size = new System.Drawing.Size(78, 18);
            xrSummary3.FormatString = "{0:dd.MM.yyyy}";
            this.txtVerfalldatum.Summary = xrSummary3;
            this.txtVerfalldatum.Text = "txtVerfalldatum";
            this.txtVerfalldatum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // txtKOA
            // 
            this.txtKOA.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KOA", "")});
            this.txtKOA.Font = new System.Drawing.Font("Arial", 10F);
            this.txtKOA.ForeColor = System.Drawing.Color.Black;
            this.txtKOA.Location = new System.Drawing.Point(375, 0);
            this.txtKOA.Name = "txtKOA";
            this.txtKOA.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKOA.ParentStyleUsing.UseBackColor = false;
            this.txtKOA.ParentStyleUsing.UseBorderColor = false;
            this.txtKOA.ParentStyleUsing.UseBorders = false;
            this.txtKOA.ParentStyleUsing.UseBorderWidth = false;
            this.txtKOA.ParentStyleUsing.UseFont = false;
            this.txtKOA.ParentStyleUsing.UseForeColor = false;
            this.txtKOA.Size = new System.Drawing.Size(65, 18);
            this.txtKOA.Text = "KOA";
            this.txtKOA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // txtBuchungstext
            // 
            this.txtBuchungstext.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Buchungstext", "")});
            this.txtBuchungstext.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBuchungstext.ForeColor = System.Drawing.Color.Black;
            this.txtBuchungstext.Location = new System.Drawing.Point(17, 0);
            this.txtBuchungstext.Name = "txtBuchungstext";
            this.txtBuchungstext.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBuchungstext.ParentStyleUsing.UseBackColor = false;
            this.txtBuchungstext.ParentStyleUsing.UseBorderColor = false;
            this.txtBuchungstext.ParentStyleUsing.UseBorders = false;
            this.txtBuchungstext.ParentStyleUsing.UseBorderWidth = false;
            this.txtBuchungstext.ParentStyleUsing.UseFont = false;
            this.txtBuchungstext.ParentStyleUsing.UseForeColor = false;
            this.txtBuchungstext.Size = new System.Drawing.Size(350, 18);
            this.txtBuchungstext.Text = "Buchungstext";
            this.txtBuchungstext.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Silver;
            this.lblTitle.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_Zahlungen", "")});
            this.lblTitle.Font = new System.Drawing.Font("Arial", 10F);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTitle.ParentStyleUsing.UseBackColor = false;
            this.lblTitle.ParentStyleUsing.UseBorderColor = false;
            this.lblTitle.ParentStyleUsing.UseBorders = false;
            this.lblTitle.ParentStyleUsing.UseBorderWidth = false;
            this.lblTitle.ParentStyleUsing.UseFont = false;
            this.lblTitle.ParentStyleUsing.UseForeColor = false;
            this.lblTitle.Size = new System.Drawing.Size(720, 23);
            this.lblTitle.Text = "lblTitle";
            this.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // Line11
            // 
            this.Line11.ForeColor = System.Drawing.Color.Black;
            this.Line11.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line11.Location = new System.Drawing.Point(641, 25);
            this.Line11.Name = "Line11";
            this.Line11.ParentStyleUsing.UseBackColor = false;
            this.Line11.ParentStyleUsing.UseBorderColor = false;
            this.Line11.ParentStyleUsing.UseBorders = false;
            this.Line11.ParentStyleUsing.UseBorderWidth = false;
            this.Line11.ParentStyleUsing.UseFont = false;
            this.Line11.ParentStyleUsing.UseForeColor = false;
            this.Line11.Size = new System.Drawing.Size(2, 31);
            // 
            // Line10
            // 
            this.Line10.ForeColor = System.Drawing.Color.Black;
            this.Line10.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line10.Location = new System.Drawing.Point(520, 25);
            this.Line10.Name = "Line10";
            this.Line10.ParentStyleUsing.UseBackColor = false;
            this.Line10.ParentStyleUsing.UseBorderColor = false;
            this.Line10.ParentStyleUsing.UseBorders = false;
            this.Line10.ParentStyleUsing.UseBorderWidth = false;
            this.Line10.ParentStyleUsing.UseFont = false;
            this.Line10.ParentStyleUsing.UseForeColor = false;
            this.Line10.Size = new System.Drawing.Size(2, 31);
            // 
            // Line9
            // 
            this.Line9.ForeColor = System.Drawing.Color.Black;
            this.Line9.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line9.Location = new System.Drawing.Point(439, 25);
            this.Line9.Name = "Line9";
            this.Line9.ParentStyleUsing.UseBackColor = false;
            this.Line9.ParentStyleUsing.UseBorderColor = false;
            this.Line9.ParentStyleUsing.UseBorders = false;
            this.Line9.ParentStyleUsing.UseBorderWidth = false;
            this.Line9.ParentStyleUsing.UseFont = false;
            this.Line9.ParentStyleUsing.UseForeColor = false;
            this.Line9.Size = new System.Drawing.Size(2, 31);
            // 
            // Line8
            // 
            this.Line8.ForeColor = System.Drawing.Color.Black;
            this.Line8.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical;
            this.Line8.Location = new System.Drawing.Point(375, 25);
            this.Line8.Name = "Line8";
            this.Line8.ParentStyleUsing.UseBackColor = false;
            this.Line8.ParentStyleUsing.UseBorderColor = false;
            this.Line8.ParentStyleUsing.UseBorders = false;
            this.Line8.ParentStyleUsing.UseBorderWidth = false;
            this.Line8.ParentStyleUsing.UseFont = false;
            this.Line8.ParentStyleUsing.UseForeColor = false;
            this.Line8.Size = new System.Drawing.Size(2, 31);
            // 
            // Line7
            // 
            this.Line7.ForeColor = System.Drawing.Color.Black;
            this.Line7.Location = new System.Drawing.Point(0, 55);
            this.Line7.Name = "Line7";
            this.Line7.ParentStyleUsing.UseBackColor = false;
            this.Line7.ParentStyleUsing.UseBorderColor = false;
            this.Line7.ParentStyleUsing.UseBorders = false;
            this.Line7.ParentStyleUsing.UseBorderWidth = false;
            this.Line7.ParentStyleUsing.UseFont = false;
            this.Line7.ParentStyleUsing.UseForeColor = false;
            this.Line7.Size = new System.Drawing.Size(720, 2);
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial", 10F);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(642, 25);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 5, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(73, 31);
            this.Label5.Text = "Betrag";
            this.Label5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight;
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial", 10F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(525, 17);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 5, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(116, 41);
            this.Label4.Text = "Ausbezahlt Kasse/Check";
            this.Label4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Arial", 10F);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(442, 25);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 5, 100F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(78, 33);
            this.Label3.Text = "Fällig am";
            this.Label3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 10F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(375, 25);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 5, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(68, 33);
            this.Label2.Text = "KOA";
            this.Label2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 10F);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(17, 25);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 5, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(350, 33);
            this.Label1.Text = "Buchungstext";
            this.Label1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // txtEmpfänger
            // 
            this.txtEmpfänger.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Empfänger", "")});
            this.txtEmpfänger.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.txtEmpfänger.ForeColor = System.Drawing.Color.Black;
            this.txtEmpfänger.Location = new System.Drawing.Point(0, 0);
            this.txtEmpfänger.Multiline = true;
            this.txtEmpfänger.Name = "txtEmpfänger";
            this.txtEmpfänger.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtEmpfänger.ParentStyleUsing.UseBackColor = false;
            this.txtEmpfänger.ParentStyleUsing.UseBorderColor = false;
            this.txtEmpfänger.ParentStyleUsing.UseBorders = false;
            this.txtEmpfänger.ParentStyleUsing.UseBorderWidth = false;
            this.txtEmpfänger.ParentStyleUsing.UseFont = false;
            this.txtEmpfänger.ParentStyleUsing.UseForeColor = false;
            this.txtEmpfänger.Size = new System.Drawing.Size(633, 20);
            this.txtEmpfänger.Text = "Empfänger";
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Empfänger", "")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.Location = new System.Drawing.Point(0, 0);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseBackColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.ParentStyleUsing.UseForeColor = false;
            this.xrLabel1.Size = new System.Drawing.Size(633, 20);
            this.xrLabel1.Text = "xrLabel1";
            // 
            // Betrag1
            // 
            this.Betrag1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.Betrag1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Betrag1.ForeColor = System.Drawing.Color.Black;
            this.Betrag1.Location = new System.Drawing.Point(642, 0);
            this.Betrag1.Name = "Betrag1";
            this.Betrag1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Betrag1.ParentStyleUsing.UseBackColor = false;
            this.Betrag1.ParentStyleUsing.UseBorderColor = false;
            this.Betrag1.ParentStyleUsing.UseBorders = false;
            this.Betrag1.ParentStyleUsing.UseBorderWidth = false;
            this.Betrag1.ParentStyleUsing.UseFont = false;
            this.Betrag1.ParentStyleUsing.UseForeColor = false;
            this.Betrag1.Size = new System.Drawing.Size(73, 18);
            xrSummary4.FormatString = "{0:#,##0.00}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.Betrag1.Summary = xrSummary4;
            this.Betrag1.Text = "Betrag";
            this.Betrag1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Betrag2
            // 
            this.Betrag2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.Betrag2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Betrag2.ForeColor = System.Drawing.Color.Black;
            this.Betrag2.Location = new System.Drawing.Point(641, 6);
            this.Betrag2.Name = "Betrag2";
            this.Betrag2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Betrag2.ParentStyleUsing.UseBackColor = false;
            this.Betrag2.ParentStyleUsing.UseBorderColor = false;
            this.Betrag2.ParentStyleUsing.UseBorders = false;
            this.Betrag2.ParentStyleUsing.UseBorderWidth = false;
            this.Betrag2.ParentStyleUsing.UseFont = false;
            this.Betrag2.ParentStyleUsing.UseForeColor = false;
            this.Betrag2.Size = new System.Drawing.Size(73, 18);
            xrSummary5.FormatString = "{0:#,##0.00}";
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.Betrag2.Summary = xrSummary5;
            this.Betrag2.Text = "Betrag";
            this.Betrag2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label7
            // 
            this.Label7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text_ZahlungenTotal", "")});
            this.Label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(17, 6);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(617, 18);
            this.Label7.Text = "Label7";
            this.Label7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.Location = new System.Drawing.Point(0, 31);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(720, 2);
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.Location = new System.Drawing.Point(0, 0);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(720, 2);
            // 
            // sqlQuery1
            // 
            this.sqlQuery1.SelectStatement = resources.GetString("sqlQuery1.SelectStatement");
            // 
            // Report
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
                        this.DetailZahlungen,
                        this.ReportHeader,
                        this.GroupHeaderZahlungen,
                        this.GroupFooter1,
                        this.ReportFooter});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(100, 0, 100, 100);
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
		<FieldName>BgBudgetID</FieldName>
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
</NewDataSet>' ,  N'DECLARE @SprachCode INT
SELECT @SprachCode = P.VerstaendigungSprachCode
FROM BgBudget B
  LEFT OUTER JOIN BgFinanzplan FP ON FP.BgFinanzplanID = B.BgFinanzplanID
  LEFT OUTER JOIN FaLeistung LEI ON LEI.FaLeistungID = FP.FaLeistungID
  LEFT OUTER JOIN FaFall FAL ON FAL.FaFallID = LEI.FaFallID
  LEFT OUTER JOIN BaPerson P ON P.BaPersonID = FAL.BaPersonID
WHERE B.BgBudgetID = {BgBudgetID}
IF @SprachCode IS NULL SET @SprachCode = 1

DECLARE @Text_Zahlungen VARCHAR(200)
SELECT @Text_Zahlungen = dbo.fnGetMLTextFromName(''Report_Budget'', ''Zahlungen'', @SprachCode)
DECLARE @Text_Total VARCHAR(200)
SELECT @Text_Total = dbo.fnGetMLTextFromName(''Report_Budget'', ''Total'', @SprachCode)
DECLARE @Text_AnKlient VARCHAR(200)
SELECT @Text_AnKlient = dbo.fnGetMLTextFromName(''Report_Budget'', ''An Klient'', @SprachCode)
DECLARE @Text_OhneNamen VARCHAR(200)
SELECT @Text_OhneNamen = dbo.fnGetMLTextFromName(''Report_Budget'', ''(Ohne Namen)'', @SprachCode)


DECLARE @BgBudgetID     int,
        @BgFinanzplanID int

SELECT
  @BgBudgetID = BgBudgetID,
  @BgFinanzplanID = BgFinanzplanID
FROM BgBudget
WHERE BgBudgetID = {BgBudgetID}

SELECT
  Text_Zahlungen = @Text_Zahlungen,
  Text_ZahlungenTotal = @Text_Total + '' '' + @Text_Zahlungen,
  PayToClient = CASE
      WHEN KBU.KbAuszahlungsArtCode IN (103, 104)    THEN 1
      WHEN KRE.BaPersonID IS NULL                    THEN 0
      WHEN KRE.BaPersonID IN (SELECT BFP.BaPersonID
                              FROM BgFinanzplan_BaPerson  BFP
                              WHERE BFP.BgFinanzplanID = @BgFinanzplanID
                                AND BFP.IstUnterstuetzt = 1) THEN 1
/*
      WHEN KRE.BaPersonID IN (SELECT BZW.BaPersonID
                              FROM BgFinanzplan_BaPerson  BFP
                                INNER JOIN BaZahlungsweg  BZW ON BZW.BaZahlungswegID = BFP.BaZahlungswegID
                              WHERE BFP.BgFinanzplanID = @BgFinanzplanID
                                AND BFP.IstUnterstuetzt = 1) THEN 1
*/
      ELSE 0
    END,
  Empfänger =
    CASE WHEN KBU.KbAuszahlungsArtCode IN (103, 104)
      THEN @Text_AnKlient
      ELSE ISNULL(KRE.Kreditor, @Text_OhneNamen)
    END + '' - '' + ISNULL(dbo.fnLOVMLText(''KbAuszahlungsArt'', KBU.KbAuszahlungsArtCode, @SprachCode), ''''),
  KBK.Buchungstext,
  KOA = FKA.KontoNr,
  KBU.ValutaDatum,
  KBU.BarbelegDatum,
  KBK.Betrag
FROM KbBuchung                  KBU
  INNER JOIN KbBuchungKostenart KBK ON KBK.KbBuchungID = KBU.KbBuchungID
  INNER JOIN BgKostenart        FKA ON FKA.BgKostenartID = KBK.BgKostenartID
  LEFT  JOIN vwKreditor         KRE ON KRE.BaZahlungswegID = KBU.BaZahlungswegID
WHERE KBU.BgBudgetID = @BgBudgetID
ORDER BY
  PayToClient DESC,
  4, /* Empfänger */
  KBU.ValutaDatum,
  KBK.Buchungstext' ,  null ,  N'ShUebersichtMonatsbudgetML' ,  null )

