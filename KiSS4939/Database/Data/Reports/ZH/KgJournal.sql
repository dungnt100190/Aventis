insert [XQuery]([QueryName], [UserText], [QueryCode], [LayoutXML], [ParameterXML], [SQLquery], [ContextForms], [ParentReportName], [ReportSortKey], [RelationColumnName])
values ( N'KgJournal' ,  N'K - Journal' , 1,  N'/// <XRTypeInfo>
///   <AssemblyFullName>DevExpress.XtraReports.v6.2, Version=6.2.6.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</AssemblyFullName>
///   <AssemblyLocation>D:\Program Files\Born Informatik AG\KiSS4_Integration\DevExpress.XtraReports.v6.2.dll</AssemblyLocation>
///   <TypeName>DevExpress.XtraReports.UI.XtraReport</TypeName>
///   <Localization>en-US</Localization>
///   <References>
///     <Reference Path="D:\Program Files\Born Informatik AG\KiSS4_Integration\DevExpress.XtraReports.v6.2.dll" />
///     <Reference Path="D:\Program Files\Born Informatik AG\KiSS4_Integration\DevExpress.XtraPrinting.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Drawing\2.0.0.0__b03f5f7f11d50a3a\System.Drawing.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System\2.0.0.0__b77a5c561934e089\System.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Configuration\2.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Xml\2.0.0.0__b77a5c561934e089\System.Xml.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Data.SqlXml\2.0.0.0__b77a5c561934e089\System.Data.SqlXml.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Security\2.0.0.0__b03f5f7f11d50a3a\System.Security.dll" />
///     <Reference Path="D:\Program Files\Born Informatik AG\KiSS4_Integration\DevExpress.Utils.v6.2.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Windows.Forms\2.0.0.0__b77a5c561934e089\System.Windows.Forms.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\Accessibility\2.0.0.0__b03f5f7f11d50a3a\Accessibility.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Runtime.Serialization.Formatters.Soap\2.0.0.0__b03f5f7f11d50a3a\System.Runtime.Serialization.Formatters.Soap.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Deployment\2.0.0.0__b03f5f7f11d50a3a\System.Deployment.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Design\2.0.0.0__b03f5f7f11d50a3a\System.Design.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_64\System.Data\2.0.0.0__b77a5c561934e089\System.Data.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\Microsoft.VisualC\8.0.0.0__b03f5f7f11d50a3a\Microsoft.VisualC.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_64\System.Transactions\2.0.0.0__b77a5c561934e089\System.Transactions.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_64\System.EnterpriseServices\2.0.0.0__b03f5f7f11d50a3a\System.EnterpriseServices.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.DirectoryServices\2.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Runtime.Remoting\2.0.0.0__b77a5c561934e089\System.Runtime.Remoting.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_64\System.Web\2.0.0.0__b03f5f7f11d50a3a\System.Web.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Web.Services\2.0.0.0__b03f5f7f11d50a3a\System.Web.Services.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.DirectoryServices.Protocols\2.0.0.0__b03f5f7f11d50a3a\System.DirectoryServices.Protocols.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.ServiceProcess\2.0.0.0__b03f5f7f11d50a3a\System.ServiceProcess.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Configuration.Install\2.0.0.0__b03f5f7f11d50a3a\System.Configuration.Install.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Web.RegularExpressions\2.0.0.0__b03f5f7f11d50a3a\System.Web.RegularExpressions.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_MSIL\System.Drawing.Design\2.0.0.0__b03f5f7f11d50a3a\System.Drawing.Design.dll" />
///     <Reference Path="C:\WINDOWS\assembly\GAC_64\System.Data.OracleClient\2.0.0.0__b77a5c561934e089\System.Data.OracleClient.dll" />
///     <Reference Path="D:\Program Files\Born Informatik AG\KiSS4_Integration\DevExpress.XtraEditors.v6.2.dll" />
///     <Reference Path="D:\Program Files\Born Informatik AG\KiSS4_Integration\DevExpress.Data.v6.2.dll" />
///     <Reference Path="D:\Program Files\Born Informatik AG\KiSS4_Integration\DevExpress.XtraBars.v6.2.dll" />
///     <Reference Path="D:\Program Files\Born Informatik AG\KiSS4_Integration\DevExpress.XtraNavBar.v6.2.dll" />
///     <Reference Path="D:\Program Files\Born Informatik AG\KiSS4_Integration\DevExpress.XtraCharts.v6.2.dll" />
///     <Reference Path="D:\Program Files\Born Informatik AG\KiSS4_Integration\DevExpress.XtraRichTextEdit.v6.2.dll" />
///     <Reference Path="D:\Program Files\Born Informatik AG\KiSS4_Integration\KiSS4.DB.dll" />
///     <Reference Path="D:\Program Files\Born Informatik AG\KiSS4_Integration\SharpLibrary.dll" />
///     <Reference Path="D:\Program Files\Born Informatik AG\KiSS4_Integration\DevExpress.XtraTreeList.v6.2.dll" />
///     <Reference Path="D:\Program Files\Born Informatik AG\KiSS4_Integration\DevExpress.XtraGrid.v6.2.dll" />
///   </References>
/// </XRTypeInfo>
namespace XtraReportSerialization {
    
    public class Report : DevExpress.XtraReports.UI.XtraReport {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private DevExpress.XtraReports.UI.XRLabel txtText;
        private DevExpress.XtraReports.UI.XRLabel txtHabenKtoNr;
        private DevExpress.XtraReports.UI.XRLabel txtSollKtoNr;
        private DevExpress.XtraReports.UI.XRLabel txtBelegNr;
        private DevExpress.XtraReports.UI.XRLabel txtBuchungsDatum;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel TextBox7;
        private DevExpress.XtraReports.UI.XRLabel TextBox6;
        private DevExpress.XtraReports.UI.XRLabel TextBox5;
        private DevExpress.XtraReports.UI.XRLabel TextBox8;
        private DevExpress.XtraReports.UI.XRLabel TextBox3;
        private DevExpress.XtraReports.UI.XRLabel TextBox2;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLabel Label1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel txtGeburtsdatum;
        private DevExpress.XtraReports.UI.XRLabel TextBox12;
        private DevExpress.XtraReports.UI.XRLabel txtDatumBereich;
        private DevExpress.XtraReports.UI.XRLabel txtMandant;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
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
                        "CwgUHVibGljS2V5VG9rZW49YjAzZjVmN2YxMWQ1MGEzYVBBRFBBRBO0TqROBiAaAAAAADcAAACOAQAAM" +
                        "nMAcQBsAFEAdQBlAHIAeQAxAC4AUwBlAGwAZQBjAHQAUwB0AGEAdABlAG0AZQBuAHQAAAAAACZ4AHIAU" +
                        "ABpAGMAdAB1AHIAZQBCAG8AeAAxAC4ASQBtAGEAZwBlAOYDAAAB4wdzZWxlY3QgdG9wIDMwMDANCiAgI" +
                        "CAgICBNYW5kYW50ICAgICAgPSBQUlMuTmFtZVZvcm5hbWUsDQogICAgICAgUE4gICAgICAgICAgID0gU" +
                        "FJTLkJhUGVyc29uSUQsDQogICAgICAgR2VidXJ0c2RhdHVtID0gY29udmVydCh2YXJjaGFyLFBSUy5HZ" +
                        "WJ1cnRzZGF0dW0sMTA0KSwNCiAgICAgICBEYXR1bUJlcmVpY2ggPSBjb252ZXJ0KHZhcmNoYXIsbnVsb" +
                        "CwxMDQpICsgJyAtICcgKyANCiAgICAgICAgICAgICAgICAgICAgICBjb252ZXJ0KHZhcmNoYXIsbnVsb" +
                        "CwxMDQpLA0KICAgICAgIERhdHVtICAgICAgICA9IGNvbnZlcnQodmFyY2hhcixCVUMuQnVjaHVuZ3NEY" +
                        "XR1bSwxMDQpLA0KICAgICAgIFZhbHV0YSAgICAgICA9IGNvbnZlcnQodmFyY2hhcixCVUMuVmFsdXRhR" +
                        "GF0dW0sMTA0KSwNCiAgICAgICBCZWxlZyAgICAgICAgPSBCVUMuS2dCdWNodW5nSUQsDQogICAgICAgU" +
                        "29sbCAgICAgICAgID0gQlVDLlNvbGxLdG9OciwNCiAgICAgICBIYWJlbiAgICAgICAgPSBCVUMuSGFiZ" +
                        "W5LdG9OciwNCiAgICAgICBUZXh0ICAgICAgICAgPSBCVUMuVGV4dCwNCiAgICAgICBCZXRyYWcgICAgI" +
                        "CAgPSBCVUMuQmV0cmFnDQpmcm9tICAgS2dCdWNodW5nIEJVQw0KICAgICAgIGlubmVyIGpvaW4gS2dQZ" +
                        "XJpb2RlICAgUEVSICBvbiBQRVIuS2dQZXJpb2RlSUQgPSBCVUMuS2dQZXJpb2RlSUQNCiAgICAgICBpb" +
                        "m5lciBqb2luIEZhTGVpc3R1bmcgIExFSSAgb24gTEVJLkZhTGVpc3R1bmdJRCA9IFBFUi5GYUxlaXN0d" +
                        "W5nSUQgDQogICAgICAgaW5uZXIgam9pbiB2d1BlcnNvbiAgICBQUlMgIG9uIFBSUy5CYVBlcnNvbklEI" +
                        "D0gTEVJLkJhUGVyc29uSUQNCndoZXJlIExFSS5CYVBlcnNvbklEID0gbnVsbA0KICAgICAgYW5kIEJVQ" +
                        "y5CdWNodW5nc0RhdHVtID49IG51bGwNCiAgICAgIGFuZCBCVUMuQnVjaHVuZ3NEYXR1bSA8PSBkYXRlY" +
                        "WRkKG1zLC0xMCxkYXRlYWRkKGQsMSxudWxsKSkgIA0Kb3JkZXIgYnkgQlVDLkJ1Y2h1bmdzZGF0dW0sI" +
                        "EJVQy5LZ0J1Y2h1bmdJREAAAQAAAP////8BAAAAAAAAAAwCAAAAUVN5c3RlbS5EcmF3aW5nLCBWZXJza" +
                        "W9uPTIuMC4wLjAsIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49YjAzZjVmN2YxMWQ1MGEzY" +
                        "QUBAAAAFVN5c3RlbS5EcmF3aW5nLkJpdG1hcAEAAAAERGF0YQcCAgAAAAkDAAAADwMAAABcEwAAAv/Y/" +
                        "+AAEEpGSUYAAQABAGAAYAAA//4AH0xFQUQgVGVjaG5vbG9naWVzIEluYy4gVjEuMDEA/9sAQwAIBgYHB" +
                        "gUIBwcHCgkICg0WDg0MDA0bExQQFiAcIiEfHB8eIygzKyMmMCYeHyw9LTA1Njk6OSIrP0M+OEMzODk3/" +
                        "9sAQwEJCgoNCw0aDg4aNyQfJDc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3Nzc3N" +
                        "zc3Nzc3Nzc3/8AAEQgAMgDbAwERAAIRAQMRAf/EAB8AAAEFAQEBAQEBAAAAAAAAAAABAgMEBQYHCAkKC" +
                        "//EALUQAAIBAwMCBAMFBQQEAAABfQECAwAEEQUSITFBBhNRYQcicRQygZGhCCNCscEVUtHwJDNicoIJC" +
                        "hYXGBkaJSYnKCkqNDU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6g4SFhoeIiYqSk" +
                        "5SVlpeYmZqio6Slpqeoqaqys7S1tre4ubrCw8TFxsfIycrS09TV1tfY2drh4uPk5ebn6Onq8fLz9PX29" +
                        "/j5+v/EAB8BAAMBAQEBAQEBAQEAAAAAAAABAgMEBQYHCAkKC//EALURAAIBAgQEAwQHBQQEAAECdwABA" +
                        "gMRBAUhMQYSQVEHYXETIjKBCBRCkaGxwQkjM1LwFWJy0QoWJDThJfEXGBkaJicoKSo1Njc4OTpDREVGR" +
                        "0hJSlNUVVZXWFlaY2RlZmdoaWpzdHV2d3h5eoKDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t" +
                        "7i5usLDxMXGx8jJytLT1NXW19jZ2uLj5OXm5+jp6vLz9PX29/j5+v/aAAwDAQACEQMRAD8A9s1zxBpnh" +
                        "yx+16nciKMnaihSzyNjO1VHLHjtQBieFfiLo3i+8W106G9jkaA3A+0Q7AUDbfU9z/OgC3rnjrw/oDeXc" +
                        "3omnDlGgtR50iEKWO5V5XgHrQBkN8WvDabg0epDbnObGTjGc9v9lvyNAC/8LZ8N5wI9SJ5/5cZO2fb2P" +
                        "5UAb+h+K9F8QxI2n30Zmbd/o7sFmXaxU5Q8jkHtQBhaz8VNA0LWJdMu4NQaWGdIHeK23qGYZHQ5PHoPX" +
                        "GaAOt03UrLV9Phv9PuUuLWYZSRDkH/PpQBaoA4XxH8XfCfhnVJNMubie5vIjiWO1i3+WfRjwM+1AG54e" +
                        "8ZaD4o0eXVNKv1ltoM+duBVosDPzA8jigC/o+t6br9gL7SbyO7tSxUSRnjI6igC/QAUAYTeLtITxgvhY" +
                        "zP/AGq0PnCPyzt24z97p2oAt6d4g0nVr29s9Pv4ri5sX2XEaHmNskYP5H8qAHa3rNl4e0a51bUXZLS2U" +
                        "NIyqWIGQOg9zQBwn/C+PAf/AD/3P/gK/wDhQB0P/CxPDv8Awhg8V/aJf7JL7A/ktuzu2/d69aALmm+Md" +
                        "G1bX5tEtJpGvobdbllaJlGxgpByeM/MOKAN6gDDs/Fuk33im98OW8sh1KyQSTIYyFA46N0P3hQBuUAYW" +
                        "qeLtI0bxBpmiXkzpfakcW6rGSG5xyR0oA3aACgAoAKAOL1dreD4oaVJqhC2k+nyW9kznCrcFgXGezMmA" +
                        "PXBAoA5vUPA7+DTD4gWR9ZsdMiAktdvlSiFDlWDKQJCgzww5FAHEDQp5JdO1i3gWL+zbvF1NCG3PJcFp" +
                        "HVpEBYiNWRSeeWIoA1ItOaOW3Y6zuEV1JcEbr0ZDhvl/wBXx94896AC0sHtWsnOslzatMx+e9G/eSf+e" +
                        "fGM/jQBmaRYN4Sg0/UNR08zTBv7VwE2XE8UqmKSLccElWZG2nqG9RQB6HoHw3mt7qLVdSvVtB9ojvGsY" +
                        "hvEfl5McZmcliFJJPQZoA2PAjQz6h4nvNOA/se41DdbMv3HYIoldPYuDyOpBNAHZ0AeDw6N408BeLNc1" +
                        "jwxp9l4j03UZzJJscNKmWLbeDkHk9Mg8UAHhe70XxBo3i6DQLS68KeIWjM19HkyhlXJYKrYCjJIIwMZ4" +
                        "oAs/BS31ay+Gl/qttq0ZTEy29pdAJBDIOfMZ+uPWgDmda8b61o2kJqlt8Rm1TWlnHm2lrb77RVJPG4qB" +
                        "6fn+NAHaeIfFHiTxN420Pwhoepf2P59il7d3KJubld21c+g/n7UAYmm6Xrdp+0Aun6nrH2u8/suRIb8R" +
                        "BX2lG2sV6bgc/XFAD/hJo+qr8R/FLHxBMVsrzF0piXF6cuMt/d554oA91nSGSB1uFRocfMJACuPfNAHz" +
                        "9rrf8Lf8bL4b8N28Nr4d09w93exwqPMI4yDj6hR36n2AOr8e3dz4Hl8D6H4dl+xadLdiCWJVBEibk65H" +
                        "Xk8+9AF3xZ4h1XTfjH4T0ezuzFYXsZNxEFGJMFupxnsKAOY0/UvH/jDxt4r0HTPES6fZWN2379owzxqH" +
                        "IVFx64OT7UAbVn4y1Oz+KnjC2vLpptL0nTjcJBtAwVVCecZ55/OgDK0JPiT408MP4vsPFH2W5lkY2mmr" +
                        "EohKq2MEn6Hrn/AAp/EA+ILrx78PBILey194yrE/vI4pNwBbHcd8UAbXh7VfFPhv4yR+EtY199Zs721M" +
                        "6SSxhShwx4A6cqRjpyKAPYaACgAoA85+IOo32oajdeGrWDTWt7fS21O5N+jOJFDFQq4I2kbSd3UcYoA4" +
                        "6XxPrEeiS2h1K7h0iCK2YX8gEsls08WRBMp5lQBgNw+YZB5xQBz00usaHbeHrTT/wC1reyit9pWwndot" +
                        "Um37mMckZ6shJBI424PSgD1Tw7omj+J9LW+sPEviUYOyWGTVJVkhcdUdc8EUAa//CA2/wD0MXiP/wAGs" +
                        "v8AjQB5JrG+6W/c3l99g0/VknsNZ1KRpI41jAV1XJ3SszqRsA5wPSgDQ1PxBrGpaUbG/lnNiLa3uLWO6" +
                        "kAOoLNNsEk5Q/KgJz5a9iATQB6V4I1S9kn1fw/qEdn5+iyRxCSyj8uJ0ZNygL/CR0I+lAHXUAeRL8NfF" +
                        "/hPWtQuvA2vWkFjfyeY9reR5CHJ6cHOPwoA1/B3w1utHm1zVNd1YX2tazE0U00SbUjU9cDv29OgoAy/D" +
                        "vwt8QaZ4P1nwlfa5ayaTdxMLcwxEOkhIO5s9uOme9AGbcfCvxtqPgmLwpc6zo9vp1qVMfkQPvmIPG9vx" +
                        "J4HJ60Ab3iD4cazJqWheIfDuqW9nr2m2iW0vmqTFMoXH17n8MdMUAJ4f+HfiS1+JEPjDXdbtL2Y27Ryx" +
                        "xRFNpKkAL7Dj9aAJ9C8A+IPDnxE1PWrHWLU6Pqk5mubd4z5hHJAB6cFuvpQB0fjzQNS8TeEbvR9Kv1sZ" +
                        "7gqrStnBTPzLxzyOKAPNtA+FnxE8L2DWWjeLtPtIGcuyrASS3HJJXJ6UAbPiH4beJ/EXhXSEvfEMEviL" +
                        "S7pp47ooQjAkEDgcEYHOKAEt/h14svvHOh+KfEGvWVzPYcPDDEUVV5wF45PJJJxQBveDPA954Z8W+KNY" +
                        "uLuGaLV5/NiSMEMg3McHP8AvDp6UAQWfw8mT4h+ItfvLmGXT9XtDbG3UEOAQoOT0/hNAHNwfDPxzpWj3" +
                        "HhfSPFNpH4fmclZHiYXEaE5Kgj/AB/KgDcvfhncN4i8HXtpqCta+H0CyfaNzSzc5Jz6nmgC/eeB7y4+L" +
                        "lh4xW7gW0trUwNAQd5JDjPp/EPyoA7igAoAKAPKvjRBaSWNgLW4dPEU5NtbW8LhXuYXIEsZ/wBnHOexo" +
                        "A5TQPEMP2u01G6s2bToLk6tfIsi7oDIfJtyVPLLGi5OOmQe1AGp8TPCumaZ4i0K402xOy9e4MlvHHLNH" +
                        "vCgh1ijYEN1yVx70AYWnjWvDGqDWPD+n3ccyjbNZRaRdIl4M9GLs2G64agD2/wx4nsPFOl/a7PfHLG3l" +
                        "3FtKNstvIOqOvY/zoA4nwnpmhWMPiLxfqEAYWmo3skJclkgjVjny0ztBODyOTQB53rF1dLaLp0OlyLcr" +
                        "5lta2fmqZEt7oeZArEcBkkQcHkDFAHrvwqbTJvBsd1ZXxvb25fzdRmc5kNyQC4b0xwAPQCgDt6AOVPir" +
                        "Ur+7u00DQf7QtrSZoJLiW6WBXkXhlTglsHjJwMigDS8PeIYNft7gi3ltLu0lMN1azY3wvgHBxwQQQQRw" +
                        "QaANigAoAqXd3NbXVlFFZSTpcSFJJEIxCNpO5vbIA/GgC3QBmX2sx2Ot6TpjQs76i0oVwRhNibjn60Aa" +
                        "dABQBy974p1FfEd5o2l6A9+9pFHLLJ9qSIDfnAAPX7poAn0zxV9p1ZdI1TTLjStRkQvDHMVdJ1H3tjqS" +
                        "CR3HB9qANawu5rsXJmspLXyp3iQSEHzFB4cY7HtQBboAKACgBksiwxPI2dqKWOPQUAVtK1K31jSbXUrX" +
                        "d9nuo1lj3jB2kZGRQBcoAKAOO+I8Vlb+GLnVTZwSarFGbaxmdQXjkmIjG09vvZ/CgDhZxbPd2t7NaIfB" +
                        "lpaP4fF2vDDcAjTn1j3Lsz2PNAFfxLdHVvhxpM1zLDNqPhq7EGpxMC5RFzE0hRWDEH5W6jrQBkrpodQy" +
                        "aaWUjII0K8wR/3+oAgNxfeDrg+JNNWWxe2T9/ENHnhiulyPkkZ3bHsexoA6ySeK28D6F4b1OeK3uNQnf" +
                        "UdVjZxm3tt7XDhx1GcqnPXJoAz7ue/XR9ZnudPFlFr0zavo7P8A6xZoiriNz2Z0QMB7sKAPXfDdvpMej" +
                        "xXmj2cFtb6gBdkQoFDs4B3HHegDXoA4bT9J1S2Se/8ABeu2U2l3k8k4tLyEvGrsx37JFIYDdngg4OaAK" +
                        "WoeK7+PQ9ftnsItJ8RW728U0sRDoVmYIkytgE4G7g9CKAJvEvhix8L+GbrXNHknt9U06PzxcvcO7T7eW" +
                        "WTJwwYZB+vGKAJfF9npEjW8y6dJd6/qYCWsH2mVBkLy7hWACKOSce3U0AQvo7+F5PA+lRXtxNjUJPPle" +
                        "RiZWMEpOcnpnoO2BQBUltNJ1m91WU2Gq+Irlp5FW6hJhit8HAjjcuANuOWXPOaAE0K/utT/AOFa3l7K0" +
                        "tzLFcGR2OSx8kjJ9TxQBm6Q9v4j0x9W1bw/r99f3ckjJdWzALAochFixINoUAdsk5zQB6L4Sm1SbwtYN" +
                        "rUTx6iEKzCTAYkEgMcEjJABP1oAytH/AOSoeJv+vS0/k9AB432/2j4TEf8Ax9f2xH5eOu3Y/mfhtzQBy" +
                        "15q99Dol7axSXr/AG7xRNZubVszCLLMVjJIwSEx14yaAL1hA+n+INKl8PeGtZ06JphFfLcEeS8JB+Y5k" +
                        "PzKcEEDJ5zQA/wr4WsfEWj6hcazJcXkjX90kJadx9nUSsAEweDxnPWgCtCmsa74H8LXUsc+rW0Jf+0LW" +
                        "Ofy5bpVyitnI3YIBKkjJoAt6RaaHeQ6/pdv/aFpA1uskmj3YeNoSM/vEOc7WIH3TjK0AZVsDoPwk8PR6" +
                        "Ul2kurvbQztbOWmwwy/l7jhWIUgYxjNAF+0t2sNb0qbw74Z1rTv9IWK8+0EeTJAcglsyHLA4IPXr60Ae" +
                        "l0AYfirw83iPS4reK8NpcW9xHcwS7A6iRDkblPDD2oAi0Dwna6R4UOg3Un2+GXzDP5iBVfzCSwCjhV5O" +
                        "AOlAGP4c+HEeia217c6kb6GO1ezgieBVPlMQSJWH+tIAAGewoAyrr4N6dDeSz6PNDHDIc/Zb2Fp44/9w" +
                        "h1ZR7ZNAFnRPhHpNlq0Wp6m6Xk0JDRW8UXlW6MOh2EksR7n8KALFx8MoLvxPdX9xqHmaZd3K3c9mYF3y" +
                        "SAABTL1MeVB2dOKANjxd4Vl8Rpp8trqH2G7sJWkidoRKh3IUOUPBODwexoA09A0eLw/4fsdIhleWO0iW" +
                        "IPJ95sdzQBpUAcmnhC+0y5uG8P+IJdNtbiRpWtHt0njR2OWKZwVBOTjOMmgCa08FWK6bqlvqVxNqVxqo" +
                        "AvLmYhWcAYUKFwEC9gOh5oAgfwdfXsUNlrHiO41DS4mVjbtCiNNtOVEjjlhkDOAM45oALjwhqLeJb3W7" +
                        "TxJNbz3KLGFNrHIIox/ApYcDPJ9TQBdHhu4uJdJn1LVpby4026a4STyUj35jZNpC8YG4nNAFG38G3lkk" +
                        "1jZeIbi30eWV5PsqwqXQOSzIsvUAkntkZ4NAEukeCYdIXQ41v5pY9Gab7Orqo+R1KhSR12g9e9ADP8Ah" +
                        "EL+ya6g0XxFPp2n3MjSG3ECSGJmOW8tj90EknHOCeKAOg0rTLXRdKttNs1K29ugRNxyT7k9yTyTQBh3v" +
                        "hS+k8R3es6Z4gn06S7ijiljW3jkU7M4PzDjqaAJ9L8KpZ6qurajqN1qupIhjjmuNoWFT1CIoCrnAyepo" +
                        "Aik8F2culX1k11OrXN++oRzoQrwSltwKn2Pr1FAC23hi9l1S0vdb1uTUvsRL28IgWFFcjG9gPvMATjsM" +
                        "nigDS0LRYtBsJLSKV5Ve4ln3MACC7liPwzigDGTwOtrpWk2+n6pPa3ulGT7PdbFbIcksrKeGB4/IYoAu" +
                        "aZ4Zkt9QutS1TUpNRv7iAW2/wAsRJHFnO1VHTJOSSSelAFS18EpH4V/4R+71Se5t4WQ2coRY5bbYQUww" +
                        "6lSByaAJYPC99PqNnda3rsmpJYv5sEIgWFPMwQHbb94gE46DvigDpqACgAoAKACgAoAKACgAoAKACgAo" +
                        "AKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgD//2Qs=";
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
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtText = new DevExpress.XtraReports.UI.XRLabel();
            this.txtHabenKtoNr = new DevExpress.XtraReports.UI.XRLabel();
            this.txtSollKtoNr = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBelegNr = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBuchungsDatum = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.TextBox7 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox6 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox5 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox8 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox3 = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.Label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.Label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGeburtsdatum = new DevExpress.XtraReports.UI.XRLabel();
            this.TextBox12 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtDatumBereich = new DevExpress.XtraReports.UI.XRLabel();
            this.txtMandant = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel7,
                        this.txtBetrag,
                        this.txtText,
                        this.txtHabenKtoNr,
                        this.txtSollKtoNr,
                        this.txtBelegNr,
                        this.txtBuchungsDatum});
            this.Detail.Dpi = 254F;
            this.Detail.Height = 51;
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
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel6,
                        this.Line1,
                        this.TextBox7,
                        this.TextBox6,
                        this.TextBox5,
                        this.TextBox8,
                        this.TextBox3,
                        this.TextBox2});
            this.PageHeader.Dpi = 254F;
            this.PageHeader.Height = 77;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.ParentStyleUsing.UseBackColor = false;
            this.PageHeader.ParentStyleUsing.UseBorderColor = false;
            this.PageHeader.ParentStyleUsing.UseBorders = false;
            this.PageHeader.ParentStyleUsing.UseBorderWidth = false;
            this.PageHeader.ParentStyleUsing.UseFont = false;
            this.PageHeader.ParentStyleUsing.UseForeColor = false;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageInfo2,
                        this.xrLabel1,
                        this.xrPageInfo1,
                        this.Label6,
                        this.Line2,
                        this.Label1});
            this.PageFooter.Dpi = 254F;
            this.PageFooter.Height = 99;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.ParentStyleUsing.UseBackColor = false;
            this.PageFooter.ParentStyleUsing.UseBorderColor = false;
            this.PageFooter.ParentStyleUsing.UseBorders = false;
            this.PageFooter.ParentStyleUsing.UseBorderWidth = false;
            this.PageFooter.ParentStyleUsing.UseFont = false;
            this.PageFooter.ParentStyleUsing.UseForeColor = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel5,
                        this.xrLabel4,
                        this.xrLabel3,
                        this.xrLabel2,
                        this.txtGeburtsdatum,
                        this.TextBox12,
                        this.txtDatumBereich,
                        this.txtMandant,
                        this.xrPictureBox1});
            this.ReportHeader.Dpi = 254F;
            this.ReportHeader.Height = 672;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Valuta", "")});
            this.xrLabel7.Dpi = 254F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel7.ForeColor = System.Drawing.Color.Black;
            this.xrLabel7.Location = new System.Drawing.Point(198, 0);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel7.ParentStyleUsing.UseBackColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel7.ParentStyleUsing.UseBorders = false;
            this.xrLabel7.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.ParentStyleUsing.UseForeColor = false;
            this.xrLabel7.Size = new System.Drawing.Size(198, 51);
            this.xrLabel7.Text = "BelegNr";
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Dpi = 254F;
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 9F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(1539, 0);
            this.txtBetrag.Multiline = true;
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(219, 51);
            xrSummary1.FormatString = "{0:#,##0.00}";
            this.txtBetrag.Summary = xrSummary1;
            this.txtBetrag.Text = "txtBetrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtText
            // 
            this.txtText.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Text", "")});
            this.txtText.Dpi = 254F;
            this.txtText.Font = new System.Drawing.Font("Arial", 9F);
            this.txtText.ForeColor = System.Drawing.Color.Black;
            this.txtText.Location = new System.Drawing.Point(795, 0);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtText.ParentStyleUsing.UseBackColor = false;
            this.txtText.ParentStyleUsing.UseBorderColor = false;
            this.txtText.ParentStyleUsing.UseBorders = false;
            this.txtText.ParentStyleUsing.UseBorderWidth = false;
            this.txtText.ParentStyleUsing.UseFont = false;
            this.txtText.ParentStyleUsing.UseForeColor = false;
            this.txtText.Size = new System.Drawing.Size(721, 51);
            this.txtText.Text = "Text";
            // 
            // txtHabenKtoNr
            // 
            this.txtHabenKtoNr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Haben", "")});
            this.txtHabenKtoNr.Dpi = 254F;
            this.txtHabenKtoNr.Font = new System.Drawing.Font("Arial", 9F);
            this.txtHabenKtoNr.ForeColor = System.Drawing.Color.Black;
            this.txtHabenKtoNr.Location = new System.Drawing.Point(686, 0);
            this.txtHabenKtoNr.Multiline = true;
            this.txtHabenKtoNr.Name = "txtHabenKtoNr";
            this.txtHabenKtoNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtHabenKtoNr.ParentStyleUsing.UseBackColor = false;
            this.txtHabenKtoNr.ParentStyleUsing.UseBorderColor = false;
            this.txtHabenKtoNr.ParentStyleUsing.UseBorders = false;
            this.txtHabenKtoNr.ParentStyleUsing.UseBorderWidth = false;
            this.txtHabenKtoNr.ParentStyleUsing.UseFont = false;
            this.txtHabenKtoNr.ParentStyleUsing.UseForeColor = false;
            this.txtHabenKtoNr.Size = new System.Drawing.Size(106, 51);
            this.txtHabenKtoNr.Text = "HabenKtoNr";
            // 
            // txtSollKtoNr
            // 
            this.txtSollKtoNr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Soll", "")});
            this.txtSollKtoNr.Dpi = 254F;
            this.txtSollKtoNr.Font = new System.Drawing.Font("Arial", 9F);
            this.txtSollKtoNr.ForeColor = System.Drawing.Color.Black;
            this.txtSollKtoNr.Location = new System.Drawing.Point(572, 0);
            this.txtSollKtoNr.Multiline = true;
            this.txtSollKtoNr.Name = "txtSollKtoNr";
            this.txtSollKtoNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtSollKtoNr.ParentStyleUsing.UseBackColor = false;
            this.txtSollKtoNr.ParentStyleUsing.UseBorderColor = false;
            this.txtSollKtoNr.ParentStyleUsing.UseBorders = false;
            this.txtSollKtoNr.ParentStyleUsing.UseBorderWidth = false;
            this.txtSollKtoNr.ParentStyleUsing.UseFont = false;
            this.txtSollKtoNr.ParentStyleUsing.UseForeColor = false;
            this.txtSollKtoNr.Size = new System.Drawing.Size(106, 51);
            this.txtSollKtoNr.Text = "SollKtoNr";
            // 
            // txtBelegNr
            // 
            this.txtBelegNr.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Beleg", "")});
            this.txtBelegNr.Dpi = 254F;
            this.txtBelegNr.Font = new System.Drawing.Font("Arial", 9F);
            this.txtBelegNr.ForeColor = System.Drawing.Color.Black;
            this.txtBelegNr.Location = new System.Drawing.Point(396, 0);
            this.txtBelegNr.Multiline = true;
            this.txtBelegNr.Name = "txtBelegNr";
            this.txtBelegNr.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtBelegNr.ParentStyleUsing.UseBackColor = false;
            this.txtBelegNr.ParentStyleUsing.UseBorderColor = false;
            this.txtBelegNr.ParentStyleUsing.UseBorders = false;
            this.txtBelegNr.ParentStyleUsing.UseBorderWidth = false;
            this.txtBelegNr.ParentStyleUsing.UseFont = false;
            this.txtBelegNr.ParentStyleUsing.UseForeColor = false;
            this.txtBelegNr.Size = new System.Drawing.Size(170, 51);
            this.txtBelegNr.Text = "BelegNr";
            // 
            // txtBuchungsDatum
            // 
            this.txtBuchungsDatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Datum", "")});
            this.txtBuchungsDatum.Dpi = 254F;
            this.txtBuchungsDatum.Font = new System.Drawing.Font("Arial", 9F);
            this.txtBuchungsDatum.ForeColor = System.Drawing.Color.Black;
            this.txtBuchungsDatum.Location = new System.Drawing.Point(0, 0);
            this.txtBuchungsDatum.Multiline = true;
            this.txtBuchungsDatum.Name = "txtBuchungsDatum";
            this.txtBuchungsDatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtBuchungsDatum.ParentStyleUsing.UseBackColor = false;
            this.txtBuchungsDatum.ParentStyleUsing.UseBorderColor = false;
            this.txtBuchungsDatum.ParentStyleUsing.UseBorders = false;
            this.txtBuchungsDatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtBuchungsDatum.ParentStyleUsing.UseFont = false;
            this.txtBuchungsDatum.ParentStyleUsing.UseForeColor = false;
            this.txtBuchungsDatum.Size = new System.Drawing.Size(198, 51);
            xrSummary2.FormatString = "{0:dd/MM/yyyy}";
            this.txtBuchungsDatum.Summary = xrSummary2;
            this.txtBuchungsDatum.Text = "BuchungsDatum";
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 254F;
            this.xrLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.xrLabel6.ForeColor = System.Drawing.Color.Black;
            this.xrLabel6.Location = new System.Drawing.Point(198, 0);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel6.ParentStyleUsing.UseBackColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel6.ParentStyleUsing.UseBorders = false;
            this.xrLabel6.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.ParentStyleUsing.UseForeColor = false;
            this.xrLabel6.Size = new System.Drawing.Size(198, 51);
            this.xrLabel6.Text = "Valuta";
            // 
            // Line1
            // 
            this.Line1.Dpi = 254F;
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.LineWidth = 3;
            this.Line1.Location = new System.Drawing.Point(0, 53);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(1758, 5);
            // 
            // TextBox7
            // 
            this.TextBox7.Dpi = 254F;
            this.TextBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox7.ForeColor = System.Drawing.Color.Black;
            this.TextBox7.Location = new System.Drawing.Point(1524, 0);
            this.TextBox7.Multiline = true;
            this.TextBox7.Name = "TextBox7";
            this.TextBox7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.TextBox7.ParentStyleUsing.UseBackColor = false;
            this.TextBox7.ParentStyleUsing.UseBorderColor = false;
            this.TextBox7.ParentStyleUsing.UseBorders = false;
            this.TextBox7.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox7.ParentStyleUsing.UseFont = false;
            this.TextBox7.ParentStyleUsing.UseForeColor = false;
            this.TextBox7.Size = new System.Drawing.Size(234, 51);
            this.TextBox7.Text = "Betrag";
            this.TextBox7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TextBox6
            // 
            this.TextBox6.Dpi = 254F;
            this.TextBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox6.ForeColor = System.Drawing.Color.Black;
            this.TextBox6.Location = new System.Drawing.Point(685, 0);
            this.TextBox6.Multiline = true;
            this.TextBox6.Name = "TextBox6";
            this.TextBox6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.TextBox6.ParentStyleUsing.UseBackColor = false;
            this.TextBox6.ParentStyleUsing.UseBorderColor = false;
            this.TextBox6.ParentStyleUsing.UseBorders = false;
            this.TextBox6.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox6.ParentStyleUsing.UseFont = false;
            this.TextBox6.ParentStyleUsing.UseForeColor = false;
            this.TextBox6.Size = new System.Drawing.Size(106, 53);
            this.TextBox6.Text = "Haben";
            // 
            // TextBox5
            // 
            this.TextBox5.Dpi = 254F;
            this.TextBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox5.ForeColor = System.Drawing.Color.Black;
            this.TextBox5.Location = new System.Drawing.Point(572, 0);
            this.TextBox5.Multiline = true;
            this.TextBox5.Name = "TextBox5";
            this.TextBox5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.TextBox5.ParentStyleUsing.UseBackColor = false;
            this.TextBox5.ParentStyleUsing.UseBorderColor = false;
            this.TextBox5.ParentStyleUsing.UseBorders = false;
            this.TextBox5.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox5.ParentStyleUsing.UseFont = false;
            this.TextBox5.ParentStyleUsing.UseForeColor = false;
            this.TextBox5.Size = new System.Drawing.Size(106, 53);
            this.TextBox5.Text = "Soll";
            // 
            // TextBox8
            // 
            this.TextBox8.Dpi = 254F;
            this.TextBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox8.ForeColor = System.Drawing.Color.Black;
            this.TextBox8.Location = new System.Drawing.Point(791, 0);
            this.TextBox8.Multiline = true;
            this.TextBox8.Name = "TextBox8";
            this.TextBox8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.TextBox8.ParentStyleUsing.UseBackColor = false;
            this.TextBox8.ParentStyleUsing.UseBorderColor = false;
            this.TextBox8.ParentStyleUsing.UseBorders = false;
            this.TextBox8.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox8.ParentStyleUsing.UseFont = false;
            this.TextBox8.ParentStyleUsing.UseForeColor = false;
            this.TextBox8.Size = new System.Drawing.Size(722, 51);
            this.TextBox8.Text = "Text";
            // 
            // TextBox3
            // 
            this.TextBox3.Dpi = 254F;
            this.TextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox3.ForeColor = System.Drawing.Color.Black;
            this.TextBox3.Location = new System.Drawing.Point(397, 0);
            this.TextBox3.Multiline = true;
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.TextBox3.ParentStyleUsing.UseBackColor = false;
            this.TextBox3.ParentStyleUsing.UseBorderColor = false;
            this.TextBox3.ParentStyleUsing.UseBorders = false;
            this.TextBox3.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox3.ParentStyleUsing.UseFont = false;
            this.TextBox3.ParentStyleUsing.UseForeColor = false;
            this.TextBox3.Size = new System.Drawing.Size(160, 53);
            this.TextBox3.Text = "Beleg";
            // 
            // TextBox2
            // 
            this.TextBox2.Dpi = 254F;
            this.TextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TextBox2.ForeColor = System.Drawing.Color.Black;
            this.TextBox2.Location = new System.Drawing.Point(0, 3);
            this.TextBox2.Multiline = true;
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.TextBox2.ParentStyleUsing.UseBackColor = false;
            this.TextBox2.ParentStyleUsing.UseBorderColor = false;
            this.TextBox2.ParentStyleUsing.UseBorders = false;
            this.TextBox2.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox2.ParentStyleUsing.UseFont = false;
            this.TextBox2.ParentStyleUsing.UseForeColor = false;
            this.TextBox2.Size = new System.Drawing.Size(198, 51);
            this.TextBox2.Text = "Datum";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 254F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 8F);
            this.xrPageInfo2.Format = "{0:dd.MM.yyyy}";
            this.xrPageInfo2.Location = new System.Drawing.Point(203, 30);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.ParentStyleUsing.UseFont = false;
            this.xrPageInfo2.Size = new System.Drawing.Size(254, 51);
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8F);
            this.xrLabel1.Location = new System.Drawing.Point(0, 30);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.Size = new System.Drawing.Size(254, 51);
            this.xrLabel1.Text = "Druckdatum";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 254F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8F);
            this.xrPageInfo1.Location = new System.Drawing.Point(831, 30);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(254, 69);
            // 
            // Label6
            // 
            this.Label6.Dpi = 254F;
            this.Label6.Font = new System.Drawing.Font("Arial", 8F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(1638, 30);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(120, 59);
            this.Label6.Text = "KISS 4";
            this.Label6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Line2
            // 
            this.Line2.Dpi = 254F;
            this.Line2.ForeColor = System.Drawing.Color.Black;
            this.Line2.LineWidth = 3;
            this.Line2.Location = new System.Drawing.Point(0, 18);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(1758, 5);
            // 
            // Label1
            // 
            this.Label1.Dpi = 254F;
            this.Label1.Font = new System.Drawing.Font("Arial", 8F);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(729, 30);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(94, 46);
            this.Label1.Text = "Seite";
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "PN", "")});
            this.xrLabel5.Dpi = 254F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel5.ForeColor = System.Drawing.Color.Black;
            this.xrLabel5.Location = new System.Drawing.Point(190, 550);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel5.ParentStyleUsing.UseBackColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel5.ParentStyleUsing.UseBorders = false;
            this.xrLabel5.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.ParentStyleUsing.UseForeColor = false;
            this.xrLabel5.Size = new System.Drawing.Size(379, 51);
            this.xrLabel5.Text = "DatumBereich";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 9F);
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.Location = new System.Drawing.Point(0, 550);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.ParentStyleUsing.UseForeColor = false;
            this.xrLabel4.Size = new System.Drawing.Size(170, 46);
            this.xrLabel4.Text = "Pers.-Nr.";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.Location = new System.Drawing.Point(1334, 0);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.Size = new System.Drawing.Size(380, 318);
            this.xrLabel3.Text = "Stadt Zürich\r\nSoziale Dienste\r\nVerwaltungszentrum Werd\r\nPostfach\r\n8036 Zürich\r\n\r\n" +
                "044 412 61 11\r\n044 412 09 89\r\nwww.stadt-zuerich.ch/sd\r\n\r\n";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 12F);
            this.xrLabel2.Location = new System.Drawing.Point(0, 384);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(678, 63);
            this.xrLabel2.Text = "Buchungsjournal";
            // 
            // txtGeburtsdatum
            // 
            this.txtGeburtsdatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Geburtsdatum", "")});
            this.txtGeburtsdatum.Dpi = 254F;
            this.txtGeburtsdatum.Font = new System.Drawing.Font("Arial", 9F);
            this.txtGeburtsdatum.ForeColor = System.Drawing.Color.Black;
            this.txtGeburtsdatum.Location = new System.Drawing.Point(190, 598);
            this.txtGeburtsdatum.Multiline = true;
            this.txtGeburtsdatum.Name = "txtGeburtsdatum";
            this.txtGeburtsdatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtGeburtsdatum.ParentStyleUsing.UseBackColor = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorderColor = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorders = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseFont = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseForeColor = false;
            this.txtGeburtsdatum.Size = new System.Drawing.Size(254, 51);
            xrSummary3.FormatString = "{0:dd/MM/yyyy}";
            this.txtGeburtsdatum.Summary = xrSummary3;
            this.txtGeburtsdatum.Text = "Geburtsdatum";
            // 
            // TextBox12
            // 
            this.TextBox12.Dpi = 254F;
            this.TextBox12.Font = new System.Drawing.Font("Arial", 9F);
            this.TextBox12.ForeColor = System.Drawing.Color.Black;
            this.TextBox12.Location = new System.Drawing.Point(0, 598);
            this.TextBox12.Multiline = true;
            this.TextBox12.Name = "TextBox12";
            this.TextBox12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.TextBox12.ParentStyleUsing.UseBackColor = false;
            this.TextBox12.ParentStyleUsing.UseBorderColor = false;
            this.TextBox12.ParentStyleUsing.UseBorders = false;
            this.TextBox12.ParentStyleUsing.UseBorderWidth = false;
            this.TextBox12.ParentStyleUsing.UseFont = false;
            this.TextBox12.ParentStyleUsing.UseForeColor = false;
            this.TextBox12.Size = new System.Drawing.Size(178, 46);
            this.TextBox12.Text = "Geburtstag";
            // 
            // txtDatumBereich
            // 
            this.txtDatumBereich.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "DatumBereich", "")});
            this.txtDatumBereich.Dpi = 254F;
            this.txtDatumBereich.Font = new System.Drawing.Font("Arial", 9F);
            this.txtDatumBereich.ForeColor = System.Drawing.Color.Black;
            this.txtDatumBereich.Location = new System.Drawing.Point(1334, 392);
            this.txtDatumBereich.Multiline = true;
            this.txtDatumBereich.Name = "txtDatumBereich";
            this.txtDatumBereich.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtDatumBereich.ParentStyleUsing.UseBackColor = false;
            this.txtDatumBereich.ParentStyleUsing.UseBorderColor = false;
            this.txtDatumBereich.ParentStyleUsing.UseBorders = false;
            this.txtDatumBereich.ParentStyleUsing.UseBorderWidth = false;
            this.txtDatumBereich.ParentStyleUsing.UseFont = false;
            this.txtDatumBereich.ParentStyleUsing.UseForeColor = false;
            this.txtDatumBereich.Size = new System.Drawing.Size(378, 51);
            this.txtDatumBereich.Text = "DatumBereich";
            // 
            // txtMandant
            // 
            this.txtMandant.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Mandant", "")});
            this.txtMandant.Dpi = 254F;
            this.txtMandant.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.txtMandant.ForeColor = System.Drawing.Color.Black;
            this.txtMandant.Location = new System.Drawing.Point(0, 487);
            this.txtMandant.Multiline = true;
            this.txtMandant.Name = "txtMandant";
            this.txtMandant.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtMandant.ParentStyleUsing.UseBackColor = false;
            this.txtMandant.ParentStyleUsing.UseBorderColor = false;
            this.txtMandant.ParentStyleUsing.UseBorders = false;
            this.txtMandant.ParentStyleUsing.UseBorderWidth = false;
            this.txtMandant.ParentStyleUsing.UseFont = false;
            this.txtMandant.ParentStyleUsing.UseForeColor = false;
            this.txtMandant.Size = new System.Drawing.Size(1758, 58);
            this.txtMandant.Text = "Person m. zivilr. Massn.";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Dpi = 254F;
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.Location = new System.Drawing.Point(0, 3);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.Size = new System.Drawing.Size(592, 127);
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
                        this.PageFooter,
                        this.ReportHeader});
            this.DataSource = this.sqlQuery1;
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(201, 99, 99, 79);
            this.Name = "Report";
            this.PageHeight = 2969;
            this.PageWidth = 2101;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}' ,  N'<NewDataSet>
	<Table>
		<FieldName>labelFbPeriodeID</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>FbPeriodeID:</DisplayText>
		<TabPosition>0</TabPosition>
		<X>10</X>
		<Y>40</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName>LOV Name</LOVName>
		<DefaultValue>DefaultValue1</DefaultValue>
		<Mandatory>false</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>
		<FieldName>FbPeriodeID</FieldName>
		<FieldCode>4</FieldCode>
		<DisplayText>Periode</DisplayText>
		<TabPosition>1</TabPosition>
		<X>100</X>
		<Y>40</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>10</Length>
		<LOVName>LOV Name</LOVName>
		<DefaultValue>1</DefaultValue>
		<Mandatory>false</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>
		<FieldName>labelDatumVon</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Datum von:</DisplayText>
		<TabPosition>0</TabPosition>
		<X>10</X>
		<Y>70</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName>LOV Name</LOVName>
		<DefaultValue>DefaultValue1</DefaultValue>
		<Mandatory>false</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>
		<FieldName>DatumVon</FieldName>
		<FieldCode>5</FieldCode>
		<DisplayText>Datum von</DisplayText>
		<TabPosition>4</TabPosition>
		<X>100</X>
		<Y>70</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>10</Length>
		<LOVName>LOV Name</LOVName>
		<DefaultValue>1</DefaultValue>
		<Mandatory>true</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>
		<FieldName>labelDatumBis</FieldName>
		<FieldCode>1</FieldCode>
		<DisplayText>Datum bis:</DisplayText>
		<TabPosition>0</TabPosition>
		<X>10</X>
		<Y>100</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName>LOV Name</LOVName>
		<DefaultValue>DefaultValue1</DefaultValue>
		<Mandatory>false</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>
		<FieldName>DatumBis</FieldName>
		<FieldCode>5</FieldCode>
		<DisplayText>Datum bis</DisplayText>
		<TabPosition>5</TabPosition>
		<X>100</X>
		<Y>100</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>10</Length>
		<LOVName>LOV Name</LOVName>
		<DefaultValue>1</DefaultValue>
		<Mandatory>true</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
</NewDataSet>' ,  N'select top 3000
       Mandant      = PRS.NameVorname,
       PN           = PRS.BaPersonID,
       Geburtsdatum = convert(varchar,PRS.Geburtsdatum,104),
       DatumBereich = convert(varchar,{edtDatumVon},104) + '' - '' + 
                      convert(varchar,{edtDatumBis},104),
       Datum        = convert(varchar,BUC.BuchungsDatum,104),
       Valuta       = convert(varchar,BUC.ValutaDatum,104),
       Beleg        = BUC.KgBuchungID,
       Soll         = BUC.SollKtoNr,
       Haben        = BUC.HabenKtoNr,
       Text         = BUC.Text,
       Betrag       = BUC.Betrag
from   KgBuchung BUC
       inner join KgPeriode   PER  on PER.KgPeriodeID = BUC.KgPeriodeID
       inner join FaLeistung  LEI  on LEI.FaLeistungID = PER.FaLeistungID 
       inner join vwPerson    PRS  on PRS.BaPersonID = LEI.BaPersonID
where LEI.BaPersonID = {edtBaPersonID}
      and BUC.BuchungsDatum >= {edtDatumVon}
      and BUC.BuchungsDatum <= dateadd(ms,-10,dateadd(d,1,{edtDatumBis}))  
order by BUC.Buchungsdatum, BUC.KgBuchungID' ,  N'CtlKgJournal' ,  null , 1,  null )
