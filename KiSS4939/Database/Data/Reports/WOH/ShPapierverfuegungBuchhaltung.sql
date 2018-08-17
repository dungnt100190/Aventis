-- Insert Script for ShPapierverfuegungBuchhaltung
DELETE FROM XQuery WHERE QueryName LIKE 'ShPapierverfuegungBuchhaltung' OR ParentReportName LIKE 'ShPapierverfuegungBuchhaltung'
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShPapierverfuegungBuchhaltung' ,  N'SH - Papierverfügung an die Buchhaltung' , 1,  N'<!--
AssemblyName=DevExpress%2EXtraReports%2C%20Version%3D1%2E7%2E10%2E0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4
AssemblyLocation=c:\windows\assembly\gac\devexpress.xtrareports\1.7.10.0__79868b8147b5eae4\devexpress.xtrareports.dll
TypeName=DevExpress.XtraReports.UI.XtraReport
Localization=de-DE
-->
<SOAP-ENV:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:SOAP-ENC="http://schemas.xmlsoap.org/soap/encoding/" xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/" xmlns:clr="http://schemas.microsoft.com/soap/encoding/clr/1.0" SOAP-ENV:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
<SOAP-ENV:Body>
<a1:ReportStorage id="ref-1" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<BandCount>5</BandCount>
<Band0 href="#ref-6"/>
<Band1 href="#ref-7"/>
<Band2 href="#ref-8"/>
<Band3 href="#ref-9"/>
<Band4 href="#ref-10"/>
<Visible>true</Visible>
<Tag id="ref-11"></Tag>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-12">Report</Name>
<Style_X_Font id="ref-13">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor id="ref-14">ControlText</Style_X_ForeColor>
<Style_X_BackColor id="ref-15">Transparent</Style_X_BackColor>
<Style_X_BorderColor href="#ref-14"/>
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
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>100</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<DataSource id="ref-16">dataSource</DataSource>
<UseDefaultPrinterSettings>false</UseDefaultPrinterSettings>
<ReportUnit xsi:type="a2:ReportUnit" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">HundredthsOfAnInch</ReportUnit>
<Landscape>false</Landscape>
<PaperKind xsi:type="a5:PaperKind" xmlns:a5="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Printing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Custom</PaperKind>
<PaperName href="#ref-11"/>
<Margins xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>39</x>
<y>39</y>
<width>92</width>
<height>39</height>
</Margins>
<HtmlCompressed>false</HtmlCompressed>
<PageSize xsi:type="a4:Size" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<width>928</width>
<height>1178</height>
</PageSize>
<StyleSheet_X_StyleCount>0</StyleSheet_X_StyleCount>
<ShowPreviewMarginLines>true</ShowPreviewMarginLines>
<ScriptLanguage xsi:type="a6:ScriptLanguage" xmlns:a6="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">CSharp</ScriptLanguage>
<ScriptReferences id="ref-17">System.Windows.Forms.dll</ScriptReferences>
<Watermark_X_Text href="#ref-11"/>
<Watermark_X_Font id="ref-18">Verdana, 36pt</Watermark_X_Font>
<Watermark_X_ForeColor id="ref-19">Red</Watermark_X_ForeColor>
<Watermark_X_Transparency>50</Watermark_X_Transparency>
<Watermark_X_TextDirection xsi:type="a7:DirectionMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">ForwardDiagonal</Watermark_X_TextDirection>
<Watermark_X_Image xsi:type="xsd:anyType" xsi:null="1"/>
<Watermark_X_ImageAlign xsi:type="a4:ContentAlignment" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">MiddleCenter</Watermark_X_ImageAlign>
<Watermark_X_ImageViewMode xsi:type="a7:ImageViewMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Clip</Watermark_X_ImageViewMode>
<Watermark_X_ImageTiling>false</Watermark_X_ImageTiling>
<Watermark_X_PageRange href="#ref-11"/>
<Watermark_X_ShowBehind>true</Watermark_X_ShowBehind>
<DefaultPrinterSettingsUsing_X_UseMargins>false</DefaultPrinterSettingsUsing_X_UseMargins>
<DefaultPrinterSettingsUsing_X_UsePaperKind>false</DefaultPrinterSettingsUsing_X_UsePaperKind>
<DefaultPrinterSettingsUsing_X_UseLandscape>false</DefaultPrinterSettingsUsing_X_UseLandscape>
<ShrinkSubReportIconArea>true</ShrinkSubReportIconArea>
</a1:ReportStorage>
<a1:ObjectStorage id="ref-6" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName id="ref-20">DevExpress.XtraReports, Version=1.7.10.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</Type_X_AssemblyName>
<Type_X_TypeName id="ref-21">DevExpress.XtraReports.UI.DetailBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-22">Detail</Name>
<Style_X_Font id="ref-23">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>100</width>
<height>23</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>80</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<PrintOnEmptyDataSource>true</PrintOnEmptyDataSource>
<MultiColumn_X_ColumnCount>1</MultiColumn_X_ColumnCount>
<MultiColumn_X_Direction xsi:type="a2:ColumnDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">DownThenAcross</MultiColumn_X_Direction>
<MultiColumn_X_ColumnWidth>0</MultiColumn_X_ColumnWidth>
<MultiColumn_X_ColumnSpacing>0</MultiColumn_X_ColumnSpacing>
<MultiColumn_X_Mode xsi:type="a2:MultiColumnMode" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">UseColumnCount</MultiColumn_X_Mode>
<RepeatCountOnEmptyDataSource>1</RepeatCountOnEmptyDataSource>
<ItemCount>2</ItemCount>
<Item0 href="#ref-24"/>
<Item1 href="#ref-25"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-7" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-26">DevExpress.XtraReports.UI.PageHeaderBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-27">PageHeader</Name>
<Style_X_Font id="ref-28">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>100</width>
<height>23</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>247</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>22</ItemCount>
<Item0 href="#ref-29"/>
<Item1 href="#ref-30"/>
<Item2 href="#ref-31"/>
<Item3 href="#ref-32"/>
<Item4 href="#ref-33"/>
<Item5 href="#ref-34"/>
<Item6 href="#ref-35"/>
<Item7 href="#ref-36"/>
<Item8 href="#ref-37"/>
<Item9 href="#ref-38"/>
<Item10 href="#ref-39"/>
<Item11 href="#ref-40"/>
<Item12 href="#ref-41"/>
<Item13 href="#ref-42"/>
<Item14 href="#ref-43"/>
<Item15 href="#ref-44"/>
<Item16 href="#ref-45"/>
<Item17 href="#ref-46"/>
<Item18 href="#ref-47"/>
<Item19 href="#ref-48"/>
<Item20 href="#ref-49"/>
<Item21 href="#ref-50"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-8" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-51">DevExpress.XtraReports.UI.GroupHeaderBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-52">GroupHeader1</Name>
<Style_X_Font id="ref-53">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>100</width>
<height>23</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>31</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<Level>0</Level>
<RepeatEveryPage>false</RepeatEveryPage>
<GroupFieldCount>0</GroupFieldCount>
<GroupUnion xsi:type="a2:GroupUnion" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</GroupUnion>
<ItemCount>2</ItemCount>
<Item0 href="#ref-54"/>
<Item1 href="#ref-55"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-9" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-56">DevExpress.XtraReports.UI.GroupFooterBand</Type_X_TypeName>
<Visible>false</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-57">GroupFooter1</Name>
<Style_X_Font id="ref-58">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>100</width>
<height>23</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>0</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<Level>0</Level>
<RepeatEveryPage>false</RepeatEveryPage>
<GroupUnion xsi:type="a2:GroupFooterUnion" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</GroupUnion>
<PrintAtBottom>false</PrintAtBottom>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-10" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-59">DevExpress.XtraReports.UI.PageFooterBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-60">PageFooter</Name>
<Style_X_Font id="ref-61">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>100</width>
<height>23</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>47</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>4</ItemCount>
<Item0 href="#ref-62"/>
<Item1 href="#ref-63"/>
<Item2 href="#ref-64"/>
<Item3 href="#ref-65"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-24" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-66">DevExpress.XtraReports.UI.Subreport</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-67">ShPapierverfuegungBuchhaltung_Belege</Name>
<Style_X_Font id="ref-68">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<y>47</y>
<width>29</width>
<height>33</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-25" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-66"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-69">ShPapierverfuegungBuchhaltung_Personen</Name>
<Style_X_Font id="ref-70">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<width>29</width>
<height>33</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-29" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-71">DevExpress.XtraReports.UI.XRLabel</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-72">txtEmployeeName</Name>
<Style_X_Font id="ref-73">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor id="ref-74">Black</Style_X_ForeColor>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-75">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-76">EmployeeName</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>196</x>
<y>218</y>
<width>511</width>
<height>19</height>
</Bounds>
<Text id="ref-77">EmployeeName</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
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
<a1:ObjectStorage id="ref-30" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-78">txtBezugsmonat</Name>
<Style_X_Font id="ref-79">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-80">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-81">Bezugsmonat</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>196</x>
<y>202</y>
<width>511</width>
<height>19</height>
</Bounds>
<Text id="ref-82">Bezugsmonat</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
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
<a1:ObjectStorage id="ref-31" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-83">DevExpress.XtraReports.UI.XRLine</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-84">Line2</Name>
<Style_X_Font id="ref-85">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>129</y>
<width>748</width>
<height>2</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>2</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-32" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-83"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-86">Line1</Name>
<Style_X_Font id="ref-87">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>88</y>
<width>748</width>
<height>2</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>2</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-33" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-88">txtMbStatus</Name>
<Style_X_Font id="ref-89">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-90">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-91">MbStatus</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>196</x>
<y>186</y>
<width>511</width>
<height>19</height>
</Bounds>
<Text id="ref-92">MbStatus</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
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
<a1:ObjectStorage id="ref-34" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-93">txtDatumBis</Name>
<Style_X_Font id="ref-94">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-95">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-96">DatumBis</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-97">{0:dd.MM.yyyy}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>303</x>
<y>170</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-98">DatumBis</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-99">{0:dd.MM.yyyy}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-35" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-100">txtDatumVon</Name>
<Style_X_Font id="ref-101">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-102">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-103">DatumVon</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-104">{0:dd.MM.yyyy}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>196</x>
<y>170</y>
<width>78</width>
<height>19</height>
</Bounds>
<Text id="ref-105">DatumVon</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-106">{0:dd.MM.yyyy}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-36" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-107">txtFpTyp</Name>
<Style_X_Font id="ref-108">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-109">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-110">FpTyp</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>196</x>
<y>155</y>
<width>511</width>
<height>20</height>
</Bounds>
<Text id="ref-111">FpTyp</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
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
<a1:ObjectStorage id="ref-37" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-112">Label11</Name>
<Style_X_Font id="ref-113">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>218</y>
<width>173</width>
<height>19</height>
</Bounds>
<Text id="ref-114">Zuständiger Sozialarbeiter</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
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
<a1:ObjectStorage id="ref-38" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-115">Label10</Name>
<Style_X_Font id="ref-116">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>202</y>
<width>173</width>
<height>19</height>
</Bounds>
<Text id="ref-117">Bezugsmonat</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
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
<a1:ObjectStorage id="ref-39" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-118">Label9</Name>
<Style_X_Font id="ref-119">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>186</y>
<width>173</width>
<height>19</height>
</Bounds>
<Text id="ref-120">Status Monatsbudget</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
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
<a1:ObjectStorage id="ref-40" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-121">Label8</Name>
<Style_X_Font id="ref-122">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>170</y>
<width>173</width>
<height>19</height>
</Bounds>
<Text id="ref-123">Gültig von</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
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
<a1:ObjectStorage id="ref-41" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-124">Label7</Name>
<Style_X_Font id="ref-125">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>155</y>
<width>173</width>
<height>19</height>
</Bounds>
<Text id="ref-126">Typ Finanzplan</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
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
<a1:ObjectStorage id="ref-42" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-127">txtFpStatus</Name>
<Style_X_Font id="ref-128">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-129">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-130">FpStatus</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>196</x>
<y>139</y>
<width>511</width>
<height>19</height>
</Bounds>
<Text id="ref-131">FpStatus</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
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
<a1:ObjectStorage id="ref-43" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-132">Label6</Name>
<Style_X_Font id="ref-133">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>7</x>
<y>139</y>
<width>173</width>
<height>19</height>
</Bounds>
<Text id="ref-134">Status Finanzplan</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
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
<a1:ObjectStorage id="ref-44" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-135">txtKlientName</Name>
<Style_X_Font id="ref-136">Arial, 11pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-137">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-138">KlientName</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>118</x>
<y>110</y>
<width>590</width>
<height>19</height>
</Bounds>
<Text id="ref-139">KlientName</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
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
<a1:ObjectStorage id="ref-45" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-140">Label5</Name>
<Style_X_Font id="ref-141">Arial, 11pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>110</y>
<width>118</width>
<height>19</height>
</Bounds>
<Text id="ref-142">Klient/Klientin</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
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
<a1:ObjectStorage id="ref-46" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-143">Label4</Name>
<Style_X_Font id="ref-144">Arial, 11pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>64</y>
<width>708</width>
<height>23</height>
</Bounds>
<Text id="ref-145">Zahlungsverfügung an die Buchhaltung (Papierschnitsttstelle)</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
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
<a1:ObjectStorage id="ref-47" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-146">OrgPLZOrt</Name>
<Style_X_Font id="ref-147">Arial, 11pt</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-148">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-149">Org_PLZOrt</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>509</x>
<y>29</y>
<width>181</width>
<height>23</height>
</Bounds>
<Text id="ref-150">&#60;OrgPlzOrt&#62;</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
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
<a1:ObjectStorage id="ref-48" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-151">OrgAdresse</Name>
<Style_X_Font id="ref-152">Arial, 11pt</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName href="#ref-148"/>
<BindingItem0_X_DataMember id="ref-153">Org_Adresse</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>509</x>
<y>6</y>
<width>181</width>
<height>23</height>
</Bounds>
<Text id="ref-154">&#60;OrgAdresse&#62;</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
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
<a1:ObjectStorage id="ref-49" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-155">OrgName</Name>
<Style_X_Font id="ref-156">Arial, 14pt</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName href="#ref-148"/>
<BindingItem0_X_DataMember id="ref-157">Org_Name</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-16"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>492</width>
<height>31</height>
</Bounds>
<Text id="ref-158">&#60;OrgName&#62;</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
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
<a1:ObjectStorage id="ref-50" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-159">Label12</Name>
<Style_X_Font id="ref-160">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>275</x>
<y>170</y>
<width>27</width>
<height>19</height>
</Bounds>
<Text id="ref-161">bis</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
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
<a1:ObjectStorage id="ref-54" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-83"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-162">Line3</Name>
<Style_X_Font id="ref-163">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>25</y>
<width>746</width>
<height>2</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>2</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-55" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-164">Label13</Name>
<Style_X_Font id="ref-165">Arial, 10pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>4</y>
<width>456</width>
<height>23</height>
</Bounds>
<Text id="ref-166">Personen im Haushalt und in der Unterstützungseinheit</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
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
<a1:ObjectStorage id="ref-62" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-71"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-167">xrLabel2</Name>
<Style_X_Font id="ref-168">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>660</x>
<y>7</y>
<width>40</width>
<height>20</height>
</Bounds>
<Text id="ref-169">Seite</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
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
<a1:ObjectStorage id="ref-63" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-170">DevExpress.XtraReports.UI.XRPageInfo</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-171">xrPageInfo2</Name>
<Style_X_Font id="ref-172">Arial, 10pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>707</x>
<y>7</y>
<width>53</width>
<height>20</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<PageInfo xsi:type="a3:PageInfo" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">NumberOfTotal</PageInfo>
<Format href="#ref-11"/>
<StartPageNumber>1</StartPageNumber>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-64" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-170"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-173">piOrgOrtDatum</Name>
<Style_X_Font id="ref-174">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>8</x>
<y>7</y>
<width>259</width>
<height>20</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<EventsScript_X_OnBeforePrint id="ref-175">private void OnBeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
  piOrgOrtDatum.Format = piOrgOrtDatum.Format.Replace(&#34;&#60;OrgOrt&#62;&#34;,Report.GetCurrentColumnValue(&#34;Org_Ort&#34;).ToString());
}</EventsScript_X_OnBeforePrint>
<PageInfo xsi:type="a3:PageInfo" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">DateTime</PageInfo>
<Format id="ref-176">&#60;OrgOrt&#62;, {0:dd.MM.yyyy}</Format>
<StartPageNumber>1</StartPageNumber>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-65" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-83"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-177">Line4</Name>
<Style_X_Font id="ref-178">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-74"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>100</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>746</width>
<height>2</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
</SOAP-ENV:Body>
</SOAP-ENV:Envelope>' ,  N'<?xml version="1.0" standalone="yes"?>  <NewDataSet>      <Table>          <FieldName>label</FieldName>          <FieldCode>1</FieldCode>          <DisplayText>Budget ID:</DisplayText>          <TabPosition>0</TabPosition>          <X>10</X>          <Y>60</Y>          <Width>80</Width>          <Height>25</Height>          <Length>7</Length>          <LOVName>          </LOVName>          <DefaultValue>          </DefaultValue>          <Mandatory>false</Mandatory>          <TabName>          </TabName>          <AppCode>          </AppCode>      </Table>      <Table>          <FieldName>BgBudgetID</FieldName>          <FieldCode>4</FieldCode>          <DisplayText>Budget ID</DisplayText>          <TabPosition>1</TabPosition>          <X>240</X>          <Y>60</Y>          <Width>80</Width>          <Height>25</Height>          <Length>7</Length>          <LOVName>          </LOVName>          <DefaultValue>          </DefaultValue>          <Mandatory>true</Mandatory>          <TabName>          </TabName>          <AppCode>          </AppCode>      </Table>      <Table>          <FieldName>PrintAll</FieldName>          <FieldCode>7</FieldCode>          <DisplayText>Alle Belege ausdrucken</DisplayText>          <TabPosition>3</TabPosition>          <X>10</X>          <Y>90</Y>          <Width>180</Width>          <Height>25</Height>          <Length>7</Length>          <LOVName>          </LOVName>          <DefaultValue>          </DefaultValue>          <Mandatory>true</Mandatory>          <TabName>          </TabName>          <AppCode>          </AppCode>      </Table>      <Table>          <FieldName>label</FieldName>          <FieldCode>1</FieldCode>          <DisplayText>Nur Belege ab diesem Datum ausdrucken:</DisplayText>          <TabPosition>4</TabPosition>          <X>10</X>          <Y>120</Y>          <Width>180</Width>          <Height>25</Height>          <Length>7</Length>          <LOVName>          </LOVName>          <DefaultValue>          </DefaultValue>          <Mandatory>false</Mandatory>          <TabName>          </TabName>          <AppCode>          </AppCode>      </Table>      <Table>          <FieldName>DateGeneriert</FieldName>          <FieldCode>5</FieldCode>          <DisplayText>Nur Belege ab diesem Datum ausdrucken</DisplayText>          <TabPosition>5</TabPosition>          <X>240</X>          <Y>120</Y>          <Width>96</Width>          <Height>25</Height>          <Length>7</Length>          <LOVName>          </LOVName>          <DefaultValue>today</DefaultValue>          <Mandatory>false</Mandatory>          <TabName>          </TabName>          <AppCode>          </AppCode>      </Table>      <Table>          <FieldName>OnlyUnverbuchteBelege</FieldName>          <FieldCode>7</FieldCode>          <DisplayText>Nur unverbuchte Belege</DisplayText>          <TabPosition>7</TabPosition>          <X>10</X>          <Y>150</Y>          <Width>180</Width>          <Height>25</Height>          <Length>7</Length>          <LOVName>          </LOVName>          <DefaultValue>1</DefaultValue>          <Mandatory>true</Mandatory>          <TabName>          </TabName>          <AppCode>          </AppCode>      </Table>  </NewDataSet>' ,  N'declare @BgBudgetID            int
declare @PrintAll              bit
declare @DateGeneriert         datetime
declare @OnlyUnverbuchteBelege bit
declare @sMonth                varchar(20)

set @BgBudgetID            = {BgBudgetID}
set @PrintAll              = {PrintAll}
set @DateGeneriert         = {DateGeneriert}
set @OnlyUnverbuchteBelege = {OnlyUnverbuchteBelege}

SELECT @sMonth = dbo.fnXMonat(Monat) + '' '' + STR(Jahr,4)
FROM BgBudget WHERE BgBudgetID = @BgBudgetID


SELECT
  Org_Name    = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Organisation'', GetDate())), ''''),
  Org_Adresse = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Adresse'', GetDate())), ''''),
  Org_PLZ     = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', GetDate())), ''''),
  Org_Ort     = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', GetDate())), ''''),
  Org_PLZOrt  = IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\PLZ'', GetDate())) + '' '', '''')
              + IsNull(CONVERT(varchar(1000), dbo.fnXConfig(''System\Adresse\Sozialhilfe\Ort'', GetDate())), ''''),

  OrgUnitAdresse = Org.Text1,
  PRS.Name + '', '' + PRS.Vorname + IsNull('' '' + PRS.Vorname2, '''') AS KlientName,
  LVS.Text AS FpStatus,
  LVT.Text AS FpTyp,
  LVT.Value2 AS IsUrgent, -- 2.0 DB: IsUrgent
  SFP.GeplantVon,
  SFP.GeplantBis,
  SFP.DatumVon,
  SFP.DatumBis,
  SFP.Bemerkung AS ShFpBemerkung,
  BBG.Jahr,
  BBG.Monat,
  @sMonth AS Bezugsmonat,
  LVB.Text AS MbStatus,
  USR.LastName+ISNULL('', ''+USR.FirstName,'''')+ISNULL('' (''+Org.ItemName+'')'','''')+ISNULL('', Tel. ''+USR.Phone,'''') AS EmployeeName,
  -- Must provide parameters as variables to parent in special form so that subreports can read them
  @BgBudgetID AS BgBudgetID,
  CAST (@PrintAll AS int) AS PrintAll,
  '''''''' + IsNull(CONVERT(VARCHAR, @DateGeneriert, 112), ''19000101'') + '''''''' AS DateGeneriert,
  CAST (@OnlyUnverbuchteBelege AS int)  AS OnlyUnverbuchteBelege
FROM BgBudget                               BBG
  INNER JOIN BgFinanzplan                SFP ON BBG.BgFinanzplanID = SFP.BgFinanzplanID -- INNER JOIN intended: get nothing if BBG.BgFinanzplanID is null
  INNER JOIN FaLeistung                  LEI ON LEI.FaLeistungID = SFP.FaLeistungID
  INNER JOIN FaFall                      FAL ON FAL.FaFallID = LEI.FaFallID
  INNER JOIN BaPerson                    PRS ON FAL.BaPersonID = PRS.BaPersonID
  LEFT  JOIN XLOVCode                    LVS ON LVS.Code = SFP.BgBewilligungStatusCode AND LVS.LOVName = ''BgBewilligungStatus''
  LEFT  JOIN XLOVCode                    LVT ON LVT.Code = SFP.WhHilfeTypCode AND LVT.LOVName = ''WhHilfeTyp''
  LEFT  JOIN XLOVCode                    LVB ON LVB.Code = BBG.BgBewilligungStatusCode AND LVB.LOVName = ''BgBewilligungStatus''
  INNER JOIN XUser                       USR ON FAL.UserID = USR.UserID
  LEFT  JOIN XOrgUnit     Org on Org.OrgUnitID = (
    SELECT TOP 1 OU.OrgUnitID FROM XOrgUnit_User OU
    WHERE OU.UserID = FAL.UserID
      AND OU.OrgUnitMemberCode = 2 )

WHERE BBG.BgBudgetID = @BgBudgetID
  --AND BBG.BgBewilligungStatusCode = 5 -- nur bewilligte' ,  N'WhMonatsbudget,CtlWhBudget' ,  null , 1)

INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShPapierverfuegungBuchhaltung_Personen' ,  N'Personen' , 1,  N'/// <XRTypeInfo>
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
        private DevExpress.XtraReports.UI.XRCheckBox CheckBox1;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtNameKst;
        private DevExpress.XtraReports.UI.XRLabel txtNummerNrmKonto;
        private DevExpress.XtraReports.UI.XRLabel txtHeimatort;
        private DevExpress.XtraReports.UI.XRLabel txtAHVNummer;
        private DevExpress.XtraReports.UI.XRLabel txtGeburtsdatum;
        private DevExpress.XtraReports.UI.XRLabel txtNameKomplett;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel Label8;
        private DevExpress.XtraReports.UI.XRLabel Label6;
        private DevExpress.XtraReports.UI.XRLabel Label5;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.XRLabel Label3;
        private DevExpress.XtraReports.UI.XRLabel Label2;
        private DevExpress.XtraReports.UI.XRLabel Label1;
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
                        "AAAAdYQZGVjbGFyZSBAQmdCdWRnZXRJRCBpbnQNCmRlY2xhcmUgQFByaW50QWxsIGJpdA0KZGVjbGFyZ" +
                        "SBARGF0ZUdlbmVyaWVydCBkYXRldGltZQ0KZGVjbGFyZSBAT25seVVudmVyYnVjaHRlQmVsZWdlIGJpd" +
                        "A0KDQpzZXQgQEJnQnVkZ2V0SUQgICAgICAgICAgICA9IG51bGwNCnNldCBAUHJpbnRBbGwgICAgICAgI" +
                        "CAgICAgID0gbnVsbA0Kc2V0IEBEYXRlR2VuZXJpZXJ0ICAgICAgICAgPSBudWxsDQpzZXQgQE9ubHlVb" +
                        "nZlcmJ1Y2h0ZUJlbGVnZSA9IG51bGwNCg0KU0VMRUNUDQogIE5hbWUgPSBQUlMuTmFtZSArIGlzTnVsb" +
                        "CgnLCAnICsgUFJTLlZvcm5hbWUsJycpLA0KICBQUlMuR2VidXJ0c2RhdHVtLA0KICBQUlMuQUhWTnVtb" +
                        "WVyLA0KICBIRUkuTmFtZSArIElzTnVsbCgnICcgKyBIRUkuS2FudG9uLCAnJykgQVMgSGVpbWF0b3J0L" +
                        "A0KICBTUFAuSXN0VW50ZXJzdHVldHp0LA0KICBOdW1tZXJOcm1Lb250byA9IExWTi5WYWx1ZTEsDQogI" +
                        "E5hbWVLc3QgPSBkYm8uZm5LYkdldEtvc3RlbnN0ZWxsZShQUlMuQmFQZXJzb25JRCkNCg0KRlJPTSBCZ" +
                        "0J1ZGdldCAgICAgICAgICAgICAgICAgICAgICAgIEJCRw0KICBJTk5FUiBKT0lOIEJnRmluYW56cGxhb" +
                        "iAgICAgICAgICAgIFNGUCBPTiBTRlAuQmdGaW5hbnpwbGFuSUQgPSBCQkcuQmdGaW5hbnpwbGFuSUQNC" +
                        "iAgSU5ORVIgSk9JTiBCZ0ZpbmFuenBsYW5fQmFQZXJzb24gICBTUFAgT04gU1BQLkJnRmluYW56cGxhb" +
                        "klEID0gU0ZQLkJnRmluYW56cGxhbklEDQogIElOTkVSIEpPSU4gQmFQZXJzb24gICAgICAgICAgICAgI" +
                        "CAgUFJTIE9OIFBSUy5CYVBlcnNvbklkID0gU1BQLkJhUGVyc29uSWQNCiAgTEVGVCAgSk9JTiBCYUdlb" +
                        "WVpbmRlICAgICAgICAgICAgICBIRUkgT04gSEVJLkJhR2VtZWluZGVJRCA9IFBSUy5IZWltYXRnZW1la" +
                        "W5kZUJhR2VtZWluZGVJRA0KICBMRUZUICBKT0lOIEJhV1ZDb2RlICAgICAgICAgICAgICAgIFdWQyBPT" +
                        "iBXVkMuQmFQZXJzb25JRCA9IFBSUy5CYVBlcnNvbklEDQogIExFRlQgIEpPSU4gWExPVkNvZGUgICAgI" +
                        "CAgICAgICAgICAgTFZOIE9OIExWTi5Db2RlID0gV1ZDLkJhV1ZDb2RlIEFORCBMVk4uTE9WTmFtZSA9I" +
                        "CdCYVdWQ29kZScNCldIRVJFIEJCRy5CZ0J1ZGdldElEPUBCZ0J1ZGdldElEDQogIEFORCAoU1BQLklzd" +
                        "FVudGVyc3R1ZXR6dD0xKQ0KDQpVTklPTiBBTEwNCg0KLS0gbm93IGFsbCB0aGUgcGVyc29ucyB3aG8gY" +
                        "XJlIG5vdCB1bnRlcnN0dWV0enQNClNFTEVDVA0KICBOYW1lID0gUFJTLk5hbWUgKyBpc051bGwoJywgJ" +
                        "yArIFBSUy5Wb3JuYW1lLCcnKSwNCiAgUFJTLkdlYnVydHNkYXR1bSwNCiAgUFJTLkFIVk51bW1lciwNC" +
                        "iAgSEVJLk5hbWUgKyBJc051bGwoJyAnICsgSEVJLkthbnRvbiwgJycpIEFTIEhlaW1hdG9ydCwNCiAgU" +
                        "1BQLklzdFVudGVyc3R1ZXR6dCwNCiAgTnVtbWVyTnJtS29udG8gPSBMVk4uVmFsdWUxLA0KICBOYW1lS" +
                        "3N0ID0gZGJvLmZuS2JHZXRLb3N0ZW5zdGVsbGUoUFJTLkJhUGVyc29uSUQpDQoNCkZST00gQmdCdWRnZ" +
                        "XQgICAgICAgICAgICAgICAgICAgICAgICBCQkcNCiAgSU5ORVIgSk9JTiBCZ0ZpbmFuenBsYW4gICAgI" +
                        "CAgICAgICBTRlAgT04gU0ZQLkJnRmluYW56cGxhbklEICA9IEJCRy5CZ0ZpbmFuenBsYW5JRA0KICBJT" +
                        "k5FUiBKT0lOIEJnRmluYW56cGxhbl9CYVBlcnNvbiAgIFNQUCBPTiBTUFAuQmdGaW5hbnpwbGFuSUQgI" +
                        "D0gU0ZQLkJnRmluYW56cGxhbklEDQogIElOTkVSIEpPSU4gQmFQZXJzb24gICAgICAgICAgICAgICAgU" +
                        "FJTIE9OIFBSUy5CYVBlcnNvbklkICAgICAgPSBTUFAuQmFQZXJzb25JZA0KICBMRUZUICBKT0lOIEJhR" +
                        "2VtZWluZGUgICAgICAgICAgICAgIEhFSSBPTiBIRUkuQmFHZW1laW5kZUlEICAgID0gUFJTLkhlaW1hd" +
                        "GdlbWVpbmRlQmFHZW1laW5kZUlEDQogIExFRlQgIEpPSU4gQmFXVkNvZGUgICAgICAgICAgICAgICAgV" +
                        "1ZDIE9OIFdWQy5CYVBlcnNvbklEID0gUFJTLkJhUGVyc29uSUQNCiAgTEVGVCAgSk9JTiBYTE9WQ29kZ" +
                        "SAgICAgICAgICAgICAgICBMVk4gT04gTFZOLkNvZGUgPSBXVkMuQmFXVkNvZGUgQU5EIExWTi5MT1ZOY" +
                        "W1lID0gJ0JhV1ZDb2RlJw0KV0hFUkUgQkJHLkJnQnVkZ2V0SUQgPSBAQmdCdWRnZXRJRA0KICBBTkQgU" +
                        "1BQLklzdFVudGVyc3R1ZXR6dCA9IDANCg0KT1JERVIgQlkgTmFtZQ==";
                    this._resources = new DevExpress.XtraReports.Serialization.XRResourceManager(resourceString);
                }
                return this._resources;
            }
        }
        private void InitializeComponent() {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.CheckBox1 = new DevExpress.XtraReports.UI.XRCheckBox();
            this.txtNameKst = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNummerNrmKonto = new DevExpress.XtraReports.UI.XRLabel();
            this.txtHeimatort = new DevExpress.XtraReports.UI.XRLabel();
            this.txtAHVNummer = new DevExpress.XtraReports.UI.XRLabel();
            this.txtGeburtsdatum = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNameKomplett = new DevExpress.XtraReports.UI.XRLabel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.Label8 = new DevExpress.XtraReports.UI.XRLabel();
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
                        this.CheckBox1,
                        this.txtNameKst,
                        this.txtNummerNrmKonto,
                        this.txtHeimatort,
                        this.txtAHVNummer,
                        this.txtGeburtsdatum,
                        this.txtNameKomplett});
            this.Detail.Height = 22;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBackColor = false;
            this.Detail.ParentStyleUsing.UseBorderColor = false;
            this.Detail.ParentStyleUsing.UseBorders = false;
            this.Detail.ParentStyleUsing.UseBorderWidth = false;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.Line1,
                        this.Label8,
                        this.Label6,
                        this.Label5,
                        this.Label4,
                        this.Label3,
                        this.Label2,
                        this.Label1});
            this.GroupHeader1.Height = 22;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            // 
            // CheckBox1
            // 
            this.CheckBox1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("CheckState", this.sqlQuery1, "IstUnterstuetzt", "")});
            this.CheckBox1.Font = new System.Drawing.Font("Arial", 10F);
            this.CheckBox1.ForeColor = System.Drawing.Color.Black;
            this.CheckBox1.Location = new System.Drawing.Point(470, 0);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.ParentStyleUsing.UseBackColor = false;
            this.CheckBox1.ParentStyleUsing.UseBorderColor = false;
            this.CheckBox1.ParentStyleUsing.UseBorders = false;
            this.CheckBox1.ParentStyleUsing.UseBorderWidth = false;
            this.CheckBox1.ParentStyleUsing.UseFont = false;
            this.CheckBox1.ParentStyleUsing.UseForeColor = false;
            this.CheckBox1.Size = new System.Drawing.Size(19, 19);
            this.CheckBox1.WordWrap = false;
            // 
            // txtNameKst
            // 
            this.txtNameKst.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameKst", "")});
            this.txtNameKst.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.txtNameKst.ForeColor = System.Drawing.Color.Black;
            this.txtNameKst.Location = new System.Drawing.Point(575, 0);
            this.txtNameKst.Name = "txtNameKst";
            this.txtNameKst.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNameKst.ParentStyleUsing.UseBackColor = false;
            this.txtNameKst.ParentStyleUsing.UseBorderColor = false;
            this.txtNameKst.ParentStyleUsing.UseBorders = false;
            this.txtNameKst.ParentStyleUsing.UseBorderWidth = false;
            this.txtNameKst.ParentStyleUsing.UseFont = false;
            this.txtNameKst.ParentStyleUsing.UseForeColor = false;
            this.txtNameKst.Size = new System.Drawing.Size(175, 19);
            this.txtNameKst.Text = "NameKst";
            this.txtNameKst.WordWrap = false;
            // 
            // txtNummerNrmKonto
            // 
            this.txtNummerNrmKonto.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NummerNrmKonto", "")});
            this.txtNummerNrmKonto.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.txtNummerNrmKonto.ForeColor = System.Drawing.Color.Black;
            this.txtNummerNrmKonto.Location = new System.Drawing.Point(492, 0);
            this.txtNummerNrmKonto.Multiline = true;
            this.txtNummerNrmKonto.Name = "txtNummerNrmKonto";
            this.txtNummerNrmKonto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNummerNrmKonto.ParentStyleUsing.UseBackColor = false;
            this.txtNummerNrmKonto.ParentStyleUsing.UseBorderColor = false;
            this.txtNummerNrmKonto.ParentStyleUsing.UseBorders = false;
            this.txtNummerNrmKonto.ParentStyleUsing.UseBorderWidth = false;
            this.txtNummerNrmKonto.ParentStyleUsing.UseFont = false;
            this.txtNummerNrmKonto.ParentStyleUsing.UseForeColor = false;
            this.txtNummerNrmKonto.Size = new System.Drawing.Size(83, 19);
            this.txtNummerNrmKonto.Text = "NummerNrmKonto";
            // 
            // txtHeimatort
            // 
            this.txtHeimatort.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Heimatort", "")});
            this.txtHeimatort.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.txtHeimatort.ForeColor = System.Drawing.Color.Black;
            this.txtHeimatort.Location = new System.Drawing.Point(397, 0);
            this.txtHeimatort.Name = "txtHeimatort";
            this.txtHeimatort.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtHeimatort.ParentStyleUsing.UseBackColor = false;
            this.txtHeimatort.ParentStyleUsing.UseBorderColor = false;
            this.txtHeimatort.ParentStyleUsing.UseBorders = false;
            this.txtHeimatort.ParentStyleUsing.UseBorderWidth = false;
            this.txtHeimatort.ParentStyleUsing.UseFont = false;
            this.txtHeimatort.ParentStyleUsing.UseForeColor = false;
            this.txtHeimatort.Size = new System.Drawing.Size(70, 19);
            this.txtHeimatort.Text = "Heimatort";
            this.txtHeimatort.WordWrap = false;
            // 
            // txtAHVNummer
            // 
            this.txtAHVNummer.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "AHVNummer", "")});
            this.txtAHVNummer.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.txtAHVNummer.ForeColor = System.Drawing.Color.Black;
            this.txtAHVNummer.Location = new System.Drawing.Point(311, 0);
            this.txtAHVNummer.Multiline = true;
            this.txtAHVNummer.Name = "txtAHVNummer";
            this.txtAHVNummer.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtAHVNummer.ParentStyleUsing.UseBackColor = false;
            this.txtAHVNummer.ParentStyleUsing.UseBorderColor = false;
            this.txtAHVNummer.ParentStyleUsing.UseBorders = false;
            this.txtAHVNummer.ParentStyleUsing.UseBorderWidth = false;
            this.txtAHVNummer.ParentStyleUsing.UseFont = false;
            this.txtAHVNummer.ParentStyleUsing.UseForeColor = false;
            this.txtAHVNummer.Size = new System.Drawing.Size(86, 19);
            this.txtAHVNummer.Text = "AHVNummer";
            // 
            // txtGeburtsdatum
            // 
            this.txtGeburtsdatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Geburtsdatum", "{0:dd.MM.yyyy}")});
            this.txtGeburtsdatum.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.txtGeburtsdatum.ForeColor = System.Drawing.Color.Black;
            this.txtGeburtsdatum.Location = new System.Drawing.Point(233, 0);
            this.txtGeburtsdatum.Multiline = true;
            this.txtGeburtsdatum.Name = "txtGeburtsdatum";
            this.txtGeburtsdatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtGeburtsdatum.ParentStyleUsing.UseBackColor = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorderColor = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorders = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseFont = false;
            this.txtGeburtsdatum.ParentStyleUsing.UseForeColor = false;
            this.txtGeburtsdatum.Size = new System.Drawing.Size(77, 19);
            xrSummary1.FormatString = "{0:dd.MM.yyyy}";
            this.txtGeburtsdatum.Summary = xrSummary1;
            this.txtGeburtsdatum.Text = "Geburtsdatum";
            this.txtGeburtsdatum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.txtGeburtsdatum.WordWrap = false;
            // 
            // txtNameKomplett
            // 
            this.txtNameKomplett.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Name", "")});
            this.txtNameKomplett.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.txtNameKomplett.ForeColor = System.Drawing.Color.Black;
            this.txtNameKomplett.Location = new System.Drawing.Point(7, 0);
            this.txtNameKomplett.Name = "txtNameKomplett";
            this.txtNameKomplett.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNameKomplett.ParentStyleUsing.UseBackColor = false;
            this.txtNameKomplett.ParentStyleUsing.UseBorderColor = false;
            this.txtNameKomplett.ParentStyleUsing.UseBorders = false;
            this.txtNameKomplett.ParentStyleUsing.UseBorderWidth = false;
            this.txtNameKomplett.ParentStyleUsing.UseFont = false;
            this.txtNameKomplett.ParentStyleUsing.UseForeColor = false;
            this.txtNameKomplett.Size = new System.Drawing.Size(209, 19);
            this.txtNameKomplett.Text = "Name, Vorname";
            this.txtNameKomplett.WordWrap = false;
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Gray;
            this.Line1.Location = new System.Drawing.Point(0, 19);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(748, 2);
            // 
            // Label8
            // 
            this.Label8.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(575, 0);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(175, 19);
            this.Label8.Text = "KST";
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.Location = new System.Drawing.Point(492, 0);
            this.Label6.Name = "Label6";
            this.Label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label6.ParentStyleUsing.UseBackColor = false;
            this.Label6.ParentStyleUsing.UseBorderColor = false;
            this.Label6.ParentStyleUsing.UseBorders = false;
            this.Label6.ParentStyleUsing.UseBorderWidth = false;
            this.Label6.ParentStyleUsing.UseFont = false;
            this.Label6.ParentStyleUsing.UseForeColor = false;
            this.Label6.Size = new System.Drawing.Size(83, 19);
            this.Label6.Text = "NRM-Kto.";
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.Location = new System.Drawing.Point(468, 0);
            this.Label5.Name = "Label5";
            this.Label5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label5.ParentStyleUsing.UseBackColor = false;
            this.Label5.ParentStyleUsing.UseBorderColor = false;
            this.Label5.ParentStyleUsing.UseBorders = false;
            this.Label5.ParentStyleUsing.UseBorderWidth = false;
            this.Label5.ParentStyleUsing.UseFont = false;
            this.Label5.ParentStyleUsing.UseForeColor = false;
            this.Label5.Size = new System.Drawing.Size(23, 19);
            this.Label5.Text = "UE";
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(398, 0);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(70, 19);
            this.Label4.Text = "Heimatort";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(311, 0);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(86, 19);
            this.Label3.Text = "AHV-Nummer";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(248, 0);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(62, 19);
            this.Label2.Text = "Geb.datum";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(7, 0);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(69, 19);
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
                        this.GroupHeader1});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(39, 39, 39, 39);
            this.Name = "Report";
            this.PageHeight = 1178;
            this.PageWidth = 928;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
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
		<FieldName>PrintAll</FieldName>
		<FieldCode>7</FieldCode>
		<DisplayText>Alle Belege ausdrucken</DisplayText>
		<TabPosition>3</TabPosition>
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
		<DisplayText>Nur Belege ab diesem Datum ausdrucken:</DisplayText>
		<TabPosition>4</TabPosition>
		<X>10</X>
		<Y>180</Y>
		<Width>210</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>DateGeneriert</FieldName>
		<FieldCode>5</FieldCode>
		<DisplayText>Nur Belege ab diesem Datum ausdrucken</DisplayText>
		<TabPosition>5</TabPosition>
		<X>220</X>
		<Y>180</Y>
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
		<FieldName>OnlyUnverbuchteBelege</FieldName>
		<FieldCode>7</FieldCode>
		<DisplayText>Nur unverbuchte Belege</DisplayText>
		<TabPosition>7</TabPosition>
		<X>220</X>
		<Y>240</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>true</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
</NewDataSet>' ,  N'declare @BgBudgetID int
declare @PrintAll bit
declare @DateGeneriert datetime
declare @OnlyUnverbuchteBelege bit

set @BgBudgetID            = {BgBudgetID}
set @PrintAll              = {PrintAll}
set @DateGeneriert         = {DateGeneriert}
set @OnlyUnverbuchteBelege = {OnlyUnverbuchteBelege}

SELECT
  Name = PRS.Name + isNull('', '' + PRS.Vorname,''''),
  PRS.Geburtsdatum,
  PRS.AHVNummer,
  HEI.Name + IsNull('' '' + HEI.Kanton, '''') AS Heimatort,
  SPP.IstUnterstuetzt,
  NummerNrmKonto = LVN.Value1,
  NameKst = dbo.fnKbGetKostenstelle(PRS.BaPersonID)

FROM BgBudget                        BBG
  INNER JOIN BgFinanzplan            SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
  INNER JOIN BgFinanzplan_BaPerson   SPP ON SPP.BgFinanzplanID = SFP.BgFinanzplanID
  INNER JOIN BaPerson                PRS ON PRS.BaPersonId = SPP.BaPersonId
  LEFT  JOIN BaGemeinde              HEI ON HEI.BaGemeindeID = PRS.HeimatgemeindeBaGemeindeID
  LEFT  JOIN BaWVCode                WVC ON WVC.BaPersonID = PRS.BaPersonID
  LEFT  JOIN XLOVCode                LVN ON LVN.Code = WVC.BaWVCode AND LVN.LOVName = ''BaWVCode''
WHERE BBG.BgBudgetID=@BgBudgetID
  AND (SPP.IstUnterstuetzt=1)

UNION ALL

-- now all the persons who are not unterstuetzt
SELECT
  Name = PRS.Name + isNull('', '' + PRS.Vorname,''''),
  PRS.Geburtsdatum,
  PRS.AHVNummer,
  HEI.Name + IsNull('' '' + HEI.Kanton, '''') AS Heimatort,
  SPP.IstUnterstuetzt,
  NummerNrmKonto = LVN.Value1,
  NameKst = dbo.fnKbGetKostenstelle(PRS.BaPersonID)

FROM BgBudget                        BBG
  INNER JOIN BgFinanzplan            SFP ON SFP.BgFinanzplanID  = BBG.BgFinanzplanID
  INNER JOIN BgFinanzplan_BaPerson   SPP ON SPP.BgFinanzplanID  = SFP.BgFinanzplanID
  INNER JOIN BaPerson                PRS ON PRS.BaPersonId      = SPP.BaPersonId
  LEFT  JOIN BaGemeinde              HEI ON HEI.BaGemeindeID    = PRS.HeimatgemeindeBaGemeindeID
  LEFT  JOIN BaWVCode                WVC ON WVC.BaPersonID = PRS.BaPersonID
  LEFT  JOIN XLOVCode                LVN ON LVN.Code = WVC.BaWVCode AND LVN.LOVName = ''BaWVCode''
WHERE BBG.BgBudgetID = @BgBudgetID
  AND SPP.IstUnterstuetzt = 0

ORDER BY Name' ,  null ,  N'ShPapierverfuegungBuchhaltung' ,  null )

INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShPapierverfuegungBuchhaltung_Belege' ,  N'Belege' , 1,  N'/// <XRTypeInfo>
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
        private DevExpress.XtraReports.UI.XRLabel txtBetrag;
        private KiSS4.DB.SqlQuery sqlQuery1;
        private DevExpress.XtraReports.UI.XRLabel txtNameFbKostenstelle;
        private DevExpress.XtraReports.UI.XRLabel txtNummerNrmKonto;
        private DevExpress.XtraReports.UI.XRLabel txtIntern;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRLabel group2HiderOnESR;
        private DevExpress.XtraReports.UI.XRLabel group3HiderOnKreditorName;
        private DevExpress.XtraReports.UI.XRLine Line1;
        private DevExpress.XtraReports.UI.XRLabel txtBelegBezeichnung;
        private DevExpress.XtraReports.UI.XRLabel txtExtern;
        private DevExpress.XtraReports.UI.XRLabel txtBuchungstext;
        private DevExpress.XtraReports.UI.XRLabel txtVerfallDatum;
        private DevExpress.XtraReports.UI.XRLabel txtBuchungsdatum;
        private DevExpress.XtraReports.UI.XRLabel Label4;
        private DevExpress.XtraReports.UI.XRLabel Label3;
        private DevExpress.XtraReports.UI.XRLabel Label2;
        private DevExpress.XtraReports.UI.XRLabel Label1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader2;
        private DevExpress.XtraReports.UI.XRLabel txtESR;
        private DevExpress.XtraReports.UI.XRLabel lblESR;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3;
        private DevExpress.XtraReports.UI.XRLabel txtBankName;
        private DevExpress.XtraReports.UI.XRLabel Label8;
        private DevExpress.XtraReports.UI.XRLabel Label7;
        private DevExpress.XtraReports.UI.XRLabel txtKreditorOrt;
        private DevExpress.XtraReports.UI.XRLabel txtKreditorStrasse;
        private DevExpress.XtraReports.UI.XRLabel txtKreditorName;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLine Line2;
        private DevExpress.XtraReports.UI.XRLabel Label13;
        private DevExpress.XtraReports.UI.XRLabel Label12;
        private DevExpress.XtraReports.UI.XRLabel Label11;
        private DevExpress.XtraReports.UI.XRLabel Label10;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter4;
        private DevExpress.XtraReports.UI.XRPageBreak xrPageBreak1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter3;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter2;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
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
                        "AAAAcU0ZGVjbGFyZSAgQEJnQnVkZ2V0SUQgICAgICAgICAgICBpbnQNCmRlY2xhcmUgIEBQcmludEFsb" +
                        "CAgICAgICAgICAgICAgYml0DQpkZWNsYXJlICBARGF0ZUdlbmVyaWVydCAgICAgICAgIGRhdGV0aW1lD" +
                        "QpkZWNsYXJlICBAT25seVVudmVyYnVjaHRlQmVsZWdlIGJpdA0KDQpzZXQgQEJnQnVkZ2V0SUQgICAgI" +
                        "CAgICAgID0gbnVsbA0Kc2V0IEBQcmludEFsbCAgICAgICAgICAgICA9IG51bGwNCnNldCBARGF0ZUdlb" +
                        "mVyaWVydCAgICAgICAgPSBudWxsDQpzZXQgQE9ubHlVbnZlcmJ1Y2h0ZUJlbGVnZT0gbnVsbA0KDQogI" +
                        "C8qDQogIERFQ0xBUkUgQGFEYXRlICAgICAgICBEQVRFVElNRQ0KICBJRiBAUHJpbnRBbGwgPSAxIEJFR" +
                        "0lODQogICAgU0VUIEBhRGF0ZSA9ICcxOTAwMDEwMScNCiAgRU5EIEVMU0UgQkVHSU4NCiAgICBTRVQgQ" +
                        "GFEYXRlID0gQERhdGVHZW5lcmllcnQNCiAgRU5EDQogICovDQoNCiAgU0VMRUNUDQogICAgQmVsZWdCZ" +
                        "XplaWNobnVuZyA9ICdCZWxlZyAjICcgKyBDQVNUKEZCTC5LYkJ1Y2h1bmdJRCBBUyBWQVJDSEFSKSArI" +
                        "CcsICcgKw0KICAgICAgZGJvLmZuTE9WVGV4dCgnS2JCdWNodW5nU3RhdHVzJyxGQkwuS2JCdWNodW5nU" +
                        "3RhdHVzQ29kZSksDQogICAgSWRHcm91cCA9IDEsDQogICAgTmFtZUdyb3VwID0gQ09OVkVSVChWQVJDS" +
                        "EFSKDIwKSwnQnVkZ2V0cG9zaXRpb25lbicpLA0KICAgIEZCTC5LYkJ1Y2h1bmdJRCwNCiAgICBGS0EuS" +
                        "2JCdWNodW5nS29zdGVuYXJ0SUQsDQogICAgRktTLktiS29zdGVuc3RlbGxlSUQsDQogICAgR2VuZXJpZ" +
                        "XJ0QW0gPSBGQkwuRXJzdGVsbHREYXR1bSwNCiAgICBWZXJidWNodEFtID0gRkJMLkJlbGVnRGF0dW0sD" +
                        "QogICAgQnVjaHVuZ3NkYXR1bSA9IEZCTC5CZWxlZ0RhdHVtLA0KICAgIFZlcmZhbGxEYXR1bSA9IEZCT" +
                        "C5WYWx1dGFEYXR1bSwNCiAgICBCdWNodW5nc3RleHQgPSBGQkwuVGV4dCwNCiAgICBFeHRlcm4gPSBJc" +
                        "051bGwoUFIyLk5hbWUsJycpICsgSXNOdWxsKCcgJytQUjIuVm9ybmFtZSwnJyksDQogICAgRVNSID0gR" +
                        "kJMLlJlZmVyZW56TnVtbWVyLA0KICAgIEJlbGVnbnVtbWVyID0gRkJMLkJlbGVnTnIsDQogICAgSW50Z" +
                        "XJuID0gRktBLkJ1Y2h1bmdzdGV4dCArICcsICcgKyBJc051bGwoUFJTLk5hbWUsJycpICsgSXNOdWxsK" +
                        "CcgJytQUlMuVm9ybmFtZSwnJyksDQogICAgRktBLkJldHJhZywNCiAgICBOYW1lQmVsZWdTdGF0dXMgP" +
                        "SBkYm8uZm5MT1ZUZXh0KCdLYkJ1Y2h1bmdTdGF0dXMnLCBGQkwuS2JCdWNodW5nU3RhdHVzQ29kZSksD" +
                        "QogICAgSWRGaWJ1S29zdGVuYXJ0ID0gS09BLkV4dEZpYnVLb3N0ZW5hcnROciwNCiAgICBOYW1lRmJLb" +
                        "3N0ZW5hcnQgPSBLT0EuTmFtZSwNCiAgICBOYW1lRmJLb3N0ZW5zdGVsbGUgPSBLU1QuTnIsDQogICAgT" +
                        "mFtZUluaGFiZXIgPSBLU1QuTmFtZSwgLS1LU1QuTmFtZUluaGFiZXIgQVMgTmFtZUluaGFiZXIsDQogI" +
                        "CAgTnVtbWVyTnJtS29udG8gPSBMVk4uVmFsdWUxLA0KICAgIE5hbWVOcm1Lb250byA9IExWTi5UZXh0L" +
                        "A0KICAgIEtyZWRpdG9yTmFtZSA9IEZCTC5CZWd1ZW5zdGlndE5hbWUsDQogICAgS3JlZGl0b3JTdHJhc" +
                        "3NlID0gRkJMLkJlZ3VlbnN0aWd0U3RyYXNzZSwNCiAgICBLcmVkaXRvck9ydCA9IElTTlVMTChGQkwuQ" +
                        "mVndWVuc3RpZ3RQTForJyAnLCcnKSArSVNOVUxMKEZCTC5CZWd1ZW5zdGlndE9ydCwnJyksDQogICAgS" +
                        "VNOVUxMKEZCTC5CYW5rTmFtZSsnLCAnLCcnKSArDQogICAgQ0FTRQ0KICAgICAgV0hFTiBMRU4oSVNOV" +
                        "UxMKEZCTC5CYW5rS29udG9OciwnJykpID4gMA0KICAgICAgVEhFTiAnS3RvOiAnK0JhbmtLb250b05yI" +
                        "EVMU0UgJycNCiAgICBFTkQgKw0KICAgIENBU0UNCiAgICAgIFdIRU4gTEVOKElTTlVMTChGQkwuUENLb" +
                        "250b05yLCcnKSkgPiAwDQogICAgICBUSEVOICdQQzogJytkYm8uZm5UblRvUGMoRkJMLlBDS29udG9Oc" +
                        "ikgRUxTRSAnJw0KICAgIEVORCBBUyBCYW5rTmFtZQ0KICBGUk9NIEtiQnVjaHVuZyBGQkwNCiAgICBMR" +
                        "UZUIEpPSU4gS2JCdWNodW5nS29zdGVuYXJ0IEZLQSBPTiBGQkwuS2JCdWNodW5nSUQgICAgICAgICAgP" +
                        "SBGS0EuS2JCdWNodW5nSUQNCiAgICBMRUZUIEpPSU4gS2JLb3N0ZW5zdGVsbGUgICAgIEZLUyBPTiBGS" +
                        "0EuS2JLb3N0ZW5zdGVsbGVJRCA9IEZLUy5LYktvc3RlbnN0ZWxsZUlEDQogICAgTEVGVCBKT0lOIEJnS" +
                        "29zdGVuYXJ0ICAgICAgICBLT0EgT04gS09BLkJnS29zdGVuYXJ0SUQgICAgICA9IEZLQS5CZ0tvc3Rlb" +
                        "mFydElEDQogICAgTEVGVCBKT0lOIEtiS29zdGVuc3RlbGxlICAgICBLU1QgT04gS1NULktiS29zdGVuc" +
                        "3RlbGxlSUQgICA9IEZLUy5LYktvc3RlbnN0ZWxsZUlEDQogICAgTEVGVCBKT0lOIFhMT1ZDb2RlICAgI" +
                        "CAgICAgICBMVk4gT04gTFZOLkNvZGUgPSBGS0EuTnJtS29udG9Db2RlIEFORCBMVk4uTE9WTmFtZSA9I" +
                        "CdOcm1Lb250bycNCiAgICBMRUZUIEpPSU4gQmFQZXJzb24gICAgICAgICAgIFBSUyBPTiBQUlMuQmFQZ" +
                        "XJzb25JRCA9IEZLQS5CYVBlcnNvbklEDQogICAgTEVGVCBKT0lOIEtiS29zdGVuc3RlbGxlX0JhUGVyc" +
                        "29uIEtTUCBPTiBLU1AuS2JLb3N0ZW5zdGVsbGVJRCA9IEtTVC5LYktvc3RlbnN0ZWxsZUlEDQogICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgIEFORCAoS1NQLkRhdHVtQmlzIElTIE5VTEwgT1IgR2V0RGF0ZSgpI" +
                        "EJFVFdFRU4gS1NQLkRhdHVtVm9uIEFORCBLU1AuRGF0dW1CaXMpDQogICAgTEVGVCBKT0lOIEJhUGVyc" +
                        "29uICAgICAgICAgICBQUjIgT04gUFIyLkJhUGVyc29uSUQgPSBLU1AuQmFQZXJzb25JRA0KIFdIRVJFI" +
                        "EZCTC5CZ0J1ZGdldElEID0gQEJnQnVkZ2V0SUQNCiAgICBBTkQgRkJMLktiQXVzemFobHVuZ3NhcnRDb" +
                        "2RlIElOICgxMDIsIDEwNCkgICAtLSBQYXBpZXJ2ZXJmw7xndW5nIHp1ciBCdWNoaGFsdHVuZw0KICAgI" +
                        "C0tQU5EIEZCTC5LYkJ1Y2h1bmdTdGF0dXNDb2RlIGluICgxLDIpIC0tIHZvcmJlcmVpdGV0LCBmcmVpZ" +
                        "2VnZWJlbg0KICAgIEFORCBGQkwuS2JCdWNodW5nVHlwQ29kZT0xDQogICAgQU5EICgNCiAgICAgIChAT" +
                        "25seVVudmVyYnVjaHRlQmVsZWdlPTEgQU5EIEZCTC5LYkJ1Y2h1bmdTdGF0dXNDb2RlID0gMikgT1INC" +
                        "iAgICAgIChAT25seVVudmVyYnVjaHRlQmVsZWdlPTApDQogICAgKQ0KICAgIEFORCAoDQogICAgICAoQ" +
                        "FByaW50QWxsID0gMCBBTkQgKEBEYXRlR2VuZXJpZXJ0IDw9IEZCTC5FcnN0ZWxsdERhdHVtKSApIE9SD" +
                        "QogICAgICAoQFByaW50QWxsID0gMSkNCiAgICApDQoNCi8qDQogIFVOSU9OIEFMTA0KDQogIFNFTEVDV" +
                        "CAnQmVsZWcgIyAnICsgQ0FTVChGQkwuS2JCdWNodW5nSUQgQVMgVkFSQ0hBUikgKyAnLCAnICsgRkJTL" +
                        "lRleHQgQVMgQmVsZWdCZXplaWNobnVuZywNCiAgICAyICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgQVMgSWRHcm91cCwNCiAgICBDT05WRVJUKFZBUkNIQVIoMjApLCdFaW56ZWx6Y" +
                        "WhsdW5nZW4nKSAgICAgQVMgTmFtZUdyb3VwLA0KICAgIEZCTC5LYkJ1Y2h1bmdJRCAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICBBUyBLYkJ1Y2h1bmdJRCwNCiAgICBGS0EuS2JCdWNodW5nS29zdGVuYXJ0S" +
                        "UQgICAgICAgICAgICAgICAgICAgQVMgS2JCdWNodW5nS29zdGVuYXJ0SUQsDQogICAgRktTLktiS29zd" +
                        "GVuc3RlbGxlSUQgICAgICAgICAgICAgICAgICAgICAgIEFTIEZsQmVsZWdLb3N0ZW5zdGVsbGVJRCwNC" +
                        "iAgICBGQkwuRXJzdGVsbHREYXR1bSAgICAgICAgICAgICAgICAgICAgICAgICAgQVMgR2VuZXJpZXJ0Q" +
                        "W0sDQogICAgRkJMLkJlbGVnRGF0dW0gICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFTIFZlcmJ1Y" +
                        "2h0QW0sDQogICAgRkJMLkJlbGVnRGF0dW0gICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFTIEJ1Y" +
                        "2h1bmdzZGF0dW0sDQogICAgRkJMLlZhbHV0YURhdHVtICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "EFTIFZlcmZhbGxEYXR1bSwNCiAgICBGQkwuVGV4dCAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgQVMgQnVjaHVuZ3N0ZXh0LA0KICAgIEV4dGVybiA9IElzTnVsbChQUjIuTmFtZSwnJykgKyBJc" +
                        "051bGwoJyAnK1BSMi5Wb3JuYW1lLCcnKSwNCiAgICBGQkwuUmVmZXJlbnpOdW1tZXIgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgQVMgRVNSLA0KICAgIEZCTC5CZWxlZ05yICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICBBUyBCZWxlZ251bW1lciwNCiAgICBJbnRlcm4gPSBGS0EuQnVjaHVuZ3N0ZXh0ICsgJ" +
                        "ywgJyArIElzTnVsbChQUlMuTmFtZSwnJykgKyBJc051bGwoJyAnK1BSUy5Wb3JuYW1lLCcnKSwNCiAgI" +
                        "CBGS0EuQmV0cmFnICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQVMgQmV0cmFnLA0KICAgI" +
                        "EZCUy5UZXh0ICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBBUyBOYW1lQmVsZWdTdGF0d" +
                        "XMsDQogICAgS09BLkV4dEZpYnVLb3N0ZW5hcnROciAgICAgICAgICAgICAgICAgICAgIEFTIElkRmlid" +
                        "Utvc3RlbmFydCwNCiAgICBLT0EuTmFtZSAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQ" +
                        "VMgTmFtZUZiS29zdGVuYXJ0LA0KICAgIEZLUy5OciAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICBBUyBOYW1lRmJLb3N0ZW5zdGVsbGUsDQogICAgRktTLk5hbWUgICAgICAgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgIEFTIE5hbWVJbmhhYmVyLA0KICAgIExWTi5WYWx1ZTEgICAgICAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICBBUyBOdW1tZXJOcm1Lb250bywNCiAgICBMVk4uVGV4dCAgICAgI" +
                        "CAgICAgICAgICAgICAgICAgICAgICAgICAgICAgQVMgTmFtZU5ybUtvbnRvLA0KICAgIEZCTC5CZWd1Z" +
                        "W5zdGlndE5hbWUgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIEFTIEtyZWRpdG9yTmFtZ" +
                        "SwNCiAgICBGQkwuQmVndWVuc3RpZ3RTdHJhc3NlICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgI" +
                        "CBBUyBLcmVkaXRvclN0cmFzc2UsDQogICAgSVNOVUxMKEZCTC5CZWd1ZW5zdGlndFBMWisnICcsJycpI" +
                        "CtJU05VTEwoRkJMLkJlZ3VlbnN0aWd0T3J0LCcnKSBBUyBLcmVkaXRvck9ydCwNCg0KICAgIElTTlVMT" +
                        "ChGQkwuQmFua05hbWUrJywgJywnJykgKw0KICAgIENBU0UNCiAgICAgIFdIRU4gTEVOKElTTlVMTChGQ" +
                        "kwuQmFua0tvbnRvTnIsJycpKSA+IDANCiAgICAgIFRIRU4gJ0t0bzogJytCYW5rS29udG9OciBFTFNFI" +
                        "CcnDQogICAgRU5EICsNCiAgICBDQVNFDQogICAgICBXSEVOIExFTihJU05VTEwoRkJMLlBDS29udG9Oc" +
                        "iwnJykpID4gMA0KICAgICAgVEhFTiAnUEM6ICcrZGJvLmZuVG5Ub1BjKEZCTC5QQ0tvbnRvTnIpIEVMU" +
                        "0UgJycNCiAgICBFTkQgQVMgQmFua05hbWUNCg0KICBGUk9NIEJnUG9zaXRpb24gU0VaIC0tIFNoRWlue" +
                        "mVsemFobHVuZyBTRVoNCiAgICBMRUZUIEpPSU4gS2JCdWNodW5nICAgICAgICAgICAgRkJMIE9OIFNFW" +
                        "i5CZ0J1ZGdldElEID0gRkJMLkJnQnVkZ2V0SUQgQU5EIEZCTC5CdWNodW5nVHlwQ29kZSA9IDEgIC0tI" +
                        "D8/Pz8gPSBGQkwuSWRTb3VyY2UgQU5EIEZCTC5GbFR5cFNvdXJjZUNvZGU9MTA1ICAtLSBFaW56ZWx2Z" +
                        "XJmw7xndW5nZW4gYXVzIEVpbnplbHphaGx1bmdlbg0KICAgIExFRlQgSk9JTiBLYkJ1Y2h1bmdLb3N0Z" +
                        "W5hcnQgICBGS0EgT04gRkJMLktiQnVjaHVuZ0lEID0gRktBLktiQnVjaHVuZ0lEDQogICAgTEVGVCBKT" +
                        "0lOIEtiS29zdGVuc3RlbGxlICAgICAgIEZLUyBPTiBGS0EuS2JLb3N0ZW5zdGVsbGVJRCA9IEZLUy5LY" +
                        "ktvc3RlbnN0ZWxsZUlEDQogICAgTEVGVCBKT0lOIFhMT1ZDb2RlICAgICAgICAgICAgIEZCUyBPTiBGQ" +
                        "lMuQ29kZSA9IEZCTC5LYkJ1Y2h1bmdTdGF0dXNDb2RlIEFORCBGQlMuTE9WTmFtZSA9ICdLYkJ1Y2h1b" +
                        "mdTdGF0dXMnDQogICAgTEVGVCBKT0lOIEJnS29zdGVuYXJ0ICAgICAgICAgIEtPQSBPTiBLT0EuQmdLb" +
                        "3N0ZW5hcnRJRCAgICAgID0gRktBLkJnS29zdGVuYXJ0SUQNCiAgICBMRUZUIEpPSU4gWExPVkNvZGUgI" +
                        "CAgICAgICAgICAgTFZOIE9OIExWTi5Db2RlID0gRktBLk5ybUtvbnRvQ29kZSBBTkQgTFZOLkxPVk5hb" +
                        "WUgPSAnTnJtS29udG8nDQogICAgTEVGVCBKT0lOIEJhUGVyc29uICAgICAgICAgICAgIFBSUyBPTiBQU" +
                        "lMuQmFQZXJzb25JRCA9IEZLQS5CYVBlcnNvbklEDQogICAgTEVGVCBKT0lOIEJhUGVyc29uICAgICAgI" +
                        "CAgICAgIFBSMiBPTiBQUjIuQmFQZXJzb25JRCA9IEZLUy5CYVBlcnNvbklEDQogIFdIRVJFIFNFWi5CZ" +
                        "0J1ZGdldElEID0gQEJnQnVkZ2V0SUQNCiAgICBBTkQgRkJMLktiQXVzemFobHVuZ3NhcnRDb2RlID0gM" +
                        "TAyICAgLS0gUGFwaWVydmVyZsO8Z3VuZyB6dXIgQnVjaGhhbHR1bmcNCiAgICBBTkQgRkJMLktiQnVja" +
                        "HVuZ1N0YXR1c0NvZGUgaW4gKDEsMikgLS0gdm9yYmVyZWl0ZXQsIGZyZWlnZWdlYmVuDQogICAgQU5EI" +
                        "EZCTC5LYkJ1Y2h1bmdUeXBDb2RlPTENCiAgICBBTkQgU0VaLkJnS2F0ZWdvcmllQ29kZSA9IDEwMSAgL" +
                        "S0gRWluemVsemFobHVuZw0KICAgIEFORCAoDQogICAgICAoQE9ubHlVbnZlcmJ1Y2h0ZUJlbGVnZT0xI" +
                        "EFORCBGQkwuS2JCdWNodW5nU3RhdHVzQ29kZSA9IDMgKSBPUg0KICAgICAgKEBPbmx5VW52ZXJidWNod" +
                        "GVCZWxlZ2U9MCkNCiAgICApDQogICAgQU5EICgNCiAgICAgIChAUHJpbnRBbGwgPSAwIEFORCAoQERhd" +
                        "GVHZW5lcmllcnQgPD0gRkJMLkVyc3RlbGx0RGF0dW0pICkgT1INCiAgICAgIChAUHJpbnRBbGwgPSAxK" +
                        "Q0KICAgICkNCiovDQogIE9SREVSIEJZIElkR3JvdXAsIEZCTC5LYkJ1Y2h1bmdJRCwgS2JCdWNodW5nS" +
                        "29zdGVuYXJ0SUQ=";
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
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter4 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter3 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.txtBetrag = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNameFbKostenstelle = new DevExpress.XtraReports.UI.XRLabel();
            this.txtNummerNrmKonto = new DevExpress.XtraReports.UI.XRLabel();
            this.txtIntern = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.Line1 = new DevExpress.XtraReports.UI.XRLine();
            this.txtBelegBezeichnung = new DevExpress.XtraReports.UI.XRLabel();
            this.txtExtern = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBuchungstext = new DevExpress.XtraReports.UI.XRLabel();
            this.txtVerfallDatum = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBuchungsdatum = new DevExpress.XtraReports.UI.XRLabel();
            this.Label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label1 = new DevExpress.XtraReports.UI.XRLabel();
            this.group2HiderOnESR = new DevExpress.XtraReports.UI.XRLabel();
            this.group3HiderOnKreditorName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtESR = new DevExpress.XtraReports.UI.XRLabel();
            this.lblESR = new DevExpress.XtraReports.UI.XRLabel();
            this.txtBankName = new DevExpress.XtraReports.UI.XRLabel();
            this.Label8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKreditorOrt = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKreditorStrasse = new DevExpress.XtraReports.UI.XRLabel();
            this.txtKreditorName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Line2 = new DevExpress.XtraReports.UI.XRLine();
            this.Label13 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label12 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label11 = new DevExpress.XtraReports.UI.XRLabel();
            this.Label10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageBreak1 = new DevExpress.XtraReports.UI.XRPageBreak();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.sqlQuery1 = new KiSS4.DB.SqlQuery();
            ((System.ComponentModel.ISupportInitialize)(this.sqlQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtBetrag,
                        this.txtNameFbKostenstelle,
                        this.txtNummerNrmKonto,
                        this.txtIntern});
            this.Detail.Height = 23;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            this.Detail.ParentStyleUsing.UseBackColor = false;
            this.Detail.ParentStyleUsing.UseBorderColor = false;
            this.Detail.ParentStyleUsing.UseBorders = false;
            this.Detail.ParentStyleUsing.UseBorderWidth = false;
            this.Detail.ParentStyleUsing.UseFont = false;
            this.Detail.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPanel1,
                        this.Line1,
                        this.txtBelegBezeichnung,
                        this.txtExtern,
                        this.txtBuchungstext,
                        this.txtVerfallDatum,
                        this.txtBuchungsdatum,
                        this.Label4,
                        this.Label3,
                        this.Label2,
                        this.Label1});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("FlBelegID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 113;
            this.GroupHeader1.Level = 3;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader1.ParentStyleUsing.UseBorders = false;
            this.GroupHeader1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader1.ParentStyleUsing.UseFont = false;
            this.GroupHeader1.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtESR,
                        this.lblESR});
            this.GroupHeader2.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("FlBelegID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader2.Height = 23;
            this.GroupHeader2.Level = 2;
            this.GroupHeader2.Name = "GroupHeader2";
            this.GroupHeader2.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader2.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader2.ParentStyleUsing.UseBorders = false;
            this.GroupHeader2.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader2.ParentStyleUsing.UseFont = false;
            this.GroupHeader2.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.txtBankName,
                        this.Label8,
                        this.Label7,
                        this.txtKreditorOrt,
                        this.txtKreditorStrasse,
                        this.txtKreditorName});
            this.GroupHeader3.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("FlBelegID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader3.Height = 74;
            this.GroupHeader3.Level = 1;
            this.GroupHeader3.Name = "GroupHeader3";
            this.GroupHeader3.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader3.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader3.ParentStyleUsing.UseBorders = false;
            this.GroupHeader3.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader3.ParentStyleUsing.UseFont = false;
            this.GroupHeader3.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel7,
                        this.xrLabel6,
                        this.Line2,
                        this.Label13,
                        this.Label12,
                        this.Label11,
                        this.Label10});
            this.GroupHeader4.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
                        new DevExpress.XtraReports.UI.GroupField("IdFibuKostenart", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader4.Height = 81;
            this.GroupHeader4.Name = "GroupHeader4";
            this.GroupHeader4.ParentStyleUsing.UseBackColor = false;
            this.GroupHeader4.ParentStyleUsing.UseBorderColor = false;
            this.GroupHeader4.ParentStyleUsing.UseBorders = false;
            this.GroupHeader4.ParentStyleUsing.UseBorderWidth = false;
            this.GroupHeader4.ParentStyleUsing.UseFont = false;
            this.GroupHeader4.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter4
            // 
            this.GroupFooter4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrPageBreak1,
                        this.xrLabel4,
                        this.xrLabel3});
            this.GroupFooter4.Height = 45;
            this.GroupFooter4.Level = 3;
            this.GroupFooter4.Name = "GroupFooter4";
            this.GroupFooter4.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter4.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter4.ParentStyleUsing.UseBorders = false;
            this.GroupFooter4.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter4.ParentStyleUsing.UseFont = false;
            this.GroupFooter4.ParentStyleUsing.UseForeColor = false;
            // 
            // GroupFooter3
            // 
            this.GroupFooter3.Height = 0;
            this.GroupFooter3.Level = 2;
            this.GroupFooter3.Name = "GroupFooter3";
            this.GroupFooter3.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter3.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter3.ParentStyleUsing.UseBorders = false;
            this.GroupFooter3.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter3.ParentStyleUsing.UseFont = false;
            this.GroupFooter3.ParentStyleUsing.UseForeColor = false;
            this.GroupFooter3.Visible = false;
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Height = 0;
            this.GroupFooter2.Level = 1;
            this.GroupFooter2.Name = "GroupFooter2";
            this.GroupFooter2.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter2.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter2.ParentStyleUsing.UseBorders = false;
            this.GroupFooter2.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter2.ParentStyleUsing.UseFont = false;
            this.GroupFooter2.ParentStyleUsing.UseForeColor = false;
            this.GroupFooter2.Visible = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.xrLabel5,
                        this.xrLabel2,
                        this.xrLine1,
                        this.xrLabel1});
            this.GroupFooter1.Height = 48;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.ParentStyleUsing.UseBackColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderColor = false;
            this.GroupFooter1.ParentStyleUsing.UseBorders = false;
            this.GroupFooter1.ParentStyleUsing.UseBorderWidth = false;
            this.GroupFooter1.ParentStyleUsing.UseFont = false;
            this.GroupFooter1.ParentStyleUsing.UseForeColor = false;
            // 
            // txtBetrag
            // 
            this.txtBetrag.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.txtBetrag.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBetrag.ForeColor = System.Drawing.Color.Black;
            this.txtBetrag.Location = new System.Drawing.Point(606, 0);
            this.txtBetrag.Multiline = true;
            this.txtBetrag.Name = "txtBetrag";
            this.txtBetrag.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBetrag.ParentStyleUsing.UseBackColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorderColor = false;
            this.txtBetrag.ParentStyleUsing.UseBorders = false;
            this.txtBetrag.ParentStyleUsing.UseBorderWidth = false;
            this.txtBetrag.ParentStyleUsing.UseFont = false;
            this.txtBetrag.ParentStyleUsing.UseForeColor = false;
            this.txtBetrag.Size = new System.Drawing.Size(84, 19);
            xrSummary1.FormatString = "{0:0.00}";
            this.txtBetrag.Summary = xrSummary1;
            this.txtBetrag.Text = "Betrag";
            this.txtBetrag.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // txtNameFbKostenstelle
            // 
            this.txtNameFbKostenstelle.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameFbKostenstelle", "")});
            this.txtNameFbKostenstelle.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNameFbKostenstelle.ForeColor = System.Drawing.Color.Black;
            this.txtNameFbKostenstelle.Location = new System.Drawing.Point(472, 0);
            this.txtNameFbKostenstelle.Multiline = true;
            this.txtNameFbKostenstelle.Name = "txtNameFbKostenstelle";
            this.txtNameFbKostenstelle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBackColor = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBorderColor = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBorders = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseBorderWidth = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseFont = false;
            this.txtNameFbKostenstelle.ParentStyleUsing.UseForeColor = false;
            this.txtNameFbKostenstelle.Size = new System.Drawing.Size(133, 19);
            this.txtNameFbKostenstelle.Text = "NameFbKostenstelle";
            // 
            // txtNummerNrmKonto
            // 
            this.txtNummerNrmKonto.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NummerNrmKonto", "")});
            this.txtNummerNrmKonto.Font = new System.Drawing.Font("Arial", 10F);
            this.txtNummerNrmKonto.ForeColor = System.Drawing.Color.Black;
            this.txtNummerNrmKonto.Location = new System.Drawing.Point(330, 0);
            this.txtNummerNrmKonto.Multiline = true;
            this.txtNummerNrmKonto.Name = "txtNummerNrmKonto";
            this.txtNummerNrmKonto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtNummerNrmKonto.ParentStyleUsing.UseBackColor = false;
            this.txtNummerNrmKonto.ParentStyleUsing.UseBorderColor = false;
            this.txtNummerNrmKonto.ParentStyleUsing.UseBorders = false;
            this.txtNummerNrmKonto.ParentStyleUsing.UseBorderWidth = false;
            this.txtNummerNrmKonto.ParentStyleUsing.UseFont = false;
            this.txtNummerNrmKonto.ParentStyleUsing.UseForeColor = false;
            this.txtNummerNrmKonto.Size = new System.Drawing.Size(141, 19);
            this.txtNummerNrmKonto.Text = "NummerNrmKonto";
            // 
            // txtIntern
            // 
            this.txtIntern.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Intern", "")});
            this.txtIntern.Font = new System.Drawing.Font("Arial", 10F);
            this.txtIntern.ForeColor = System.Drawing.Color.Black;
            this.txtIntern.Location = new System.Drawing.Point(39, 0);
            this.txtIntern.Name = "txtIntern";
            this.txtIntern.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtIntern.ParentStyleUsing.UseBackColor = false;
            this.txtIntern.ParentStyleUsing.UseBorderColor = false;
            this.txtIntern.ParentStyleUsing.UseBorders = false;
            this.txtIntern.ParentStyleUsing.UseBorderWidth = false;
            this.txtIntern.ParentStyleUsing.UseFont = false;
            this.txtIntern.ParentStyleUsing.UseForeColor = false;
            this.txtIntern.Size = new System.Drawing.Size(287, 19);
            this.txtIntern.Text = "Intern";
            this.txtIntern.WordWrap = false;
            // 
            // xrPanel1
            // 
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                        this.group2HiderOnESR,
                        this.group3HiderOnKreditorName});
            this.xrPanel1.Location = new System.Drawing.Point(600, 25);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.Size = new System.Drawing.Size(93, 67);
            this.xrPanel1.Visible = false;
            // 
            // Line1
            // 
            this.Line1.ForeColor = System.Drawing.Color.Black;
            this.Line1.Location = new System.Drawing.Point(0, 21);
            this.Line1.Name = "Line1";
            this.Line1.ParentStyleUsing.UseBackColor = false;
            this.Line1.ParentStyleUsing.UseBorderColor = false;
            this.Line1.ParentStyleUsing.UseBorders = false;
            this.Line1.ParentStyleUsing.UseBorderWidth = false;
            this.Line1.ParentStyleUsing.UseFont = false;
            this.Line1.ParentStyleUsing.UseForeColor = false;
            this.Line1.Size = new System.Drawing.Size(747, 3);
            // 
            // txtBelegBezeichnung
            // 
            this.txtBelegBezeichnung.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BelegBezeichnung", "")});
            this.txtBelegBezeichnung.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.txtBelegBezeichnung.ForeColor = System.Drawing.Color.Black;
            this.txtBelegBezeichnung.Location = new System.Drawing.Point(0, 0);
            this.txtBelegBezeichnung.Multiline = true;
            this.txtBelegBezeichnung.Name = "txtBelegBezeichnung";
            this.txtBelegBezeichnung.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBelegBezeichnung.ParentStyleUsing.UseBackColor = false;
            this.txtBelegBezeichnung.ParentStyleUsing.UseBorderColor = false;
            this.txtBelegBezeichnung.ParentStyleUsing.UseBorders = false;
            this.txtBelegBezeichnung.ParentStyleUsing.UseBorderWidth = false;
            this.txtBelegBezeichnung.ParentStyleUsing.UseFont = false;
            this.txtBelegBezeichnung.ParentStyleUsing.UseForeColor = false;
            this.txtBelegBezeichnung.Size = new System.Drawing.Size(547, 20);
            this.txtBelegBezeichnung.Text = "BelegBezeichnung";
            // 
            // txtExtern
            // 
            this.txtExtern.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Extern", "")});
            this.txtExtern.Font = new System.Drawing.Font("Arial", 10F);
            this.txtExtern.ForeColor = System.Drawing.Color.Black;
            this.txtExtern.Location = new System.Drawing.Point(173, 90);
            this.txtExtern.Multiline = true;
            this.txtExtern.Name = "txtExtern";
            this.txtExtern.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtExtern.ParentStyleUsing.UseBackColor = false;
            this.txtExtern.ParentStyleUsing.UseBorderColor = false;
            this.txtExtern.ParentStyleUsing.UseBorders = false;
            this.txtExtern.ParentStyleUsing.UseBorderWidth = false;
            this.txtExtern.ParentStyleUsing.UseFont = false;
            this.txtExtern.ParentStyleUsing.UseForeColor = false;
            this.txtExtern.Size = new System.Drawing.Size(374, 19);
            this.txtExtern.Text = "Extern";
            // 
            // txtBuchungstext
            // 
            this.txtBuchungstext.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Buchungstext", "")});
            this.txtBuchungstext.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBuchungstext.ForeColor = System.Drawing.Color.Black;
            this.txtBuchungstext.Location = new System.Drawing.Point(173, 70);
            this.txtBuchungstext.Multiline = true;
            this.txtBuchungstext.Name = "txtBuchungstext";
            this.txtBuchungstext.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBuchungstext.ParentStyleUsing.UseBackColor = false;
            this.txtBuchungstext.ParentStyleUsing.UseBorderColor = false;
            this.txtBuchungstext.ParentStyleUsing.UseBorders = false;
            this.txtBuchungstext.ParentStyleUsing.UseBorderWidth = false;
            this.txtBuchungstext.ParentStyleUsing.UseFont = false;
            this.txtBuchungstext.ParentStyleUsing.UseForeColor = false;
            this.txtBuchungstext.Size = new System.Drawing.Size(374, 19);
            this.txtBuchungstext.Text = "Buchungstext";
            // 
            // txtVerfallDatum
            // 
            this.txtVerfallDatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "VerfallDatum", "")});
            this.txtVerfallDatum.Font = new System.Drawing.Font("Arial", 10F);
            this.txtVerfallDatum.ForeColor = System.Drawing.Color.Black;
            this.txtVerfallDatum.Location = new System.Drawing.Point(173, 51);
            this.txtVerfallDatum.Multiline = true;
            this.txtVerfallDatum.Name = "txtVerfallDatum";
            this.txtVerfallDatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtVerfallDatum.ParentStyleUsing.UseBackColor = false;
            this.txtVerfallDatum.ParentStyleUsing.UseBorderColor = false;
            this.txtVerfallDatum.ParentStyleUsing.UseBorders = false;
            this.txtVerfallDatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtVerfallDatum.ParentStyleUsing.UseFont = false;
            this.txtVerfallDatum.ParentStyleUsing.UseForeColor = false;
            this.txtVerfallDatum.Size = new System.Drawing.Size(374, 19);
            xrSummary2.FormatString = "{0:dd.MM.yyyy}";
            this.txtVerfallDatum.Summary = xrSummary2;
            this.txtVerfallDatum.Text = "VerfallDatum";
            // 
            // txtBuchungsdatum
            // 
            this.txtBuchungsdatum.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Buchungsdatum", "")});
            this.txtBuchungsdatum.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBuchungsdatum.ForeColor = System.Drawing.Color.Black;
            this.txtBuchungsdatum.Location = new System.Drawing.Point(173, 31);
            this.txtBuchungsdatum.Multiline = true;
            this.txtBuchungsdatum.Name = "txtBuchungsdatum";
            this.txtBuchungsdatum.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBuchungsdatum.ParentStyleUsing.UseBackColor = false;
            this.txtBuchungsdatum.ParentStyleUsing.UseBorderColor = false;
            this.txtBuchungsdatum.ParentStyleUsing.UseBorders = false;
            this.txtBuchungsdatum.ParentStyleUsing.UseBorderWidth = false;
            this.txtBuchungsdatum.ParentStyleUsing.UseFont = false;
            this.txtBuchungsdatum.ParentStyleUsing.UseForeColor = false;
            this.txtBuchungsdatum.Size = new System.Drawing.Size(374, 19);
            xrSummary3.FormatString = "{0:dd.MM.yyyy}";
            this.txtBuchungsdatum.Summary = xrSummary3;
            this.txtBuchungsdatum.Text = "Buchungsdatum";
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial", 10F);
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(39, 90);
            this.Label4.Name = "Label4";
            this.Label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label4.ParentStyleUsing.UseBackColor = false;
            this.Label4.ParentStyleUsing.UseBorderColor = false;
            this.Label4.ParentStyleUsing.UseBorders = false;
            this.Label4.ParentStyleUsing.UseBorderWidth = false;
            this.Label4.ParentStyleUsing.UseFont = false;
            this.Label4.ParentStyleUsing.UseForeColor = false;
            this.Label4.Size = new System.Drawing.Size(125, 19);
            this.Label4.Text = "Extern";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Arial", 10F);
            this.Label3.ForeColor = System.Drawing.Color.Black;
            this.Label3.Location = new System.Drawing.Point(39, 70);
            this.Label3.Name = "Label3";
            this.Label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label3.ParentStyleUsing.UseBackColor = false;
            this.Label3.ParentStyleUsing.UseBorderColor = false;
            this.Label3.ParentStyleUsing.UseBorders = false;
            this.Label3.ParentStyleUsing.UseBorderWidth = false;
            this.Label3.ParentStyleUsing.UseFont = false;
            this.Label3.ParentStyleUsing.UseForeColor = false;
            this.Label3.Size = new System.Drawing.Size(125, 19);
            this.Label3.Text = "Buchungstext";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 10F);
            this.Label2.ForeColor = System.Drawing.Color.Black;
            this.Label2.Location = new System.Drawing.Point(39, 51);
            this.Label2.Name = "Label2";
            this.Label2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label2.ParentStyleUsing.UseBackColor = false;
            this.Label2.ParentStyleUsing.UseBorderColor = false;
            this.Label2.ParentStyleUsing.UseBorders = false;
            this.Label2.ParentStyleUsing.UseBorderWidth = false;
            this.Label2.ParentStyleUsing.UseFont = false;
            this.Label2.ParentStyleUsing.UseForeColor = false;
            this.Label2.Size = new System.Drawing.Size(125, 19);
            this.Label2.Text = "Verfalldatum";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 10F);
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(39, 31);
            this.Label1.Name = "Label1";
            this.Label1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label1.ParentStyleUsing.UseBackColor = false;
            this.Label1.ParentStyleUsing.UseBorderColor = false;
            this.Label1.ParentStyleUsing.UseBorders = false;
            this.Label1.ParentStyleUsing.UseBorderWidth = false;
            this.Label1.ParentStyleUsing.UseFont = false;
            this.Label1.ParentStyleUsing.UseForeColor = false;
            this.Label1.Size = new System.Drawing.Size(125, 19);
            this.Label1.Text = "Buchungsdatum";
            // 
            // group2HiderOnESR
            // 
            this.group2HiderOnESR.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ESR", "")});
            this.group2HiderOnESR.Location = new System.Drawing.Point(8, 8);
            this.group2HiderOnESR.Name = "group2HiderOnESR";
            this.group2HiderOnESR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.group2HiderOnESR.Scripts.OnAfterPrint = "private void OnAfterPrint(object sender, System.EventArgs e) {\r\n   GroupHeader2.V" +
                "isible = group2HiderOnESR.Text != String.Empty;\r\n}";
            this.group2HiderOnESR.Size = new System.Drawing.Size(100, 20);
            this.group2HiderOnESR.Visible = false;
            // 
            // group3HiderOnKreditorName
            // 
            this.group3HiderOnKreditorName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KreditorName", "")});
            this.group3HiderOnKreditorName.Location = new System.Drawing.Point(8, 42);
            this.group3HiderOnKreditorName.Name = "group3HiderOnKreditorName";
            this.group3HiderOnKreditorName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.group3HiderOnKreditorName.Scripts.OnAfterPrint = "private void OnAfterPrint(object sender, System.EventArgs e) {\r\n   GroupHeader3.V" +
                "isible = group3HiderOnKreditorName.Text != String.Empty;\r\n}";
            this.group3HiderOnKreditorName.Size = new System.Drawing.Size(100, 21);
            this.group3HiderOnKreditorName.Visible = false;
            // 
            // txtESR
            // 
            this.txtESR.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "ESR", "")});
            this.txtESR.Font = new System.Drawing.Font("Arial", 10F);
            this.txtESR.ForeColor = System.Drawing.Color.Black;
            this.txtESR.Location = new System.Drawing.Point(173, 0);
            this.txtESR.Multiline = true;
            this.txtESR.Name = "txtESR";
            this.txtESR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtESR.ParentStyleUsing.UseBackColor = false;
            this.txtESR.ParentStyleUsing.UseBorderColor = false;
            this.txtESR.ParentStyleUsing.UseBorders = false;
            this.txtESR.ParentStyleUsing.UseBorderWidth = false;
            this.txtESR.ParentStyleUsing.UseFont = false;
            this.txtESR.ParentStyleUsing.UseForeColor = false;
            this.txtESR.Size = new System.Drawing.Size(547, 19);
            this.txtESR.Text = "ESR";
            // 
            // lblESR
            // 
            this.lblESR.Font = new System.Drawing.Font("Arial", 10F);
            this.lblESR.ForeColor = System.Drawing.Color.Black;
            this.lblESR.Location = new System.Drawing.Point(39, 0);
            this.lblESR.Name = "lblESR";
            this.lblESR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblESR.ParentStyleUsing.UseBackColor = false;
            this.lblESR.ParentStyleUsing.UseBorderColor = false;
            this.lblESR.ParentStyleUsing.UseBorders = false;
            this.lblESR.ParentStyleUsing.UseBorderWidth = false;
            this.lblESR.ParentStyleUsing.UseFont = false;
            this.lblESR.ParentStyleUsing.UseForeColor = false;
            this.lblESR.Size = new System.Drawing.Size(125, 19);
            this.lblESR.Text = "ESR";
            // 
            // txtBankName
            // 
            this.txtBankName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "BankName", "")});
            this.txtBankName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBankName.ForeColor = System.Drawing.Color.Black;
            this.txtBankName.Location = new System.Drawing.Point(173, 51);
            this.txtBankName.Multiline = true;
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtBankName.ParentStyleUsing.UseBackColor = false;
            this.txtBankName.ParentStyleUsing.UseBorderColor = false;
            this.txtBankName.ParentStyleUsing.UseBorders = false;
            this.txtBankName.ParentStyleUsing.UseBorderWidth = false;
            this.txtBankName.ParentStyleUsing.UseFont = false;
            this.txtBankName.ParentStyleUsing.UseForeColor = false;
            this.txtBankName.Size = new System.Drawing.Size(547, 19);
            this.txtBankName.Text = "BankName";
            // 
            // Label8
            // 
            this.Label8.Font = new System.Drawing.Font("Arial", 10F);
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.Location = new System.Drawing.Point(39, 51);
            this.Label8.Name = "Label8";
            this.Label8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label8.ParentStyleUsing.UseBackColor = false;
            this.Label8.ParentStyleUsing.UseBorderColor = false;
            this.Label8.ParentStyleUsing.UseBorders = false;
            this.Label8.ParentStyleUsing.UseBorderWidth = false;
            this.Label8.ParentStyleUsing.UseFont = false;
            this.Label8.ParentStyleUsing.UseForeColor = false;
            this.Label8.Size = new System.Drawing.Size(125, 19);
            this.Label8.Text = "Zahlungsweg";
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Arial", 10F);
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.Location = new System.Drawing.Point(39, 0);
            this.Label7.Name = "Label7";
            this.Label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label7.ParentStyleUsing.UseBackColor = false;
            this.Label7.ParentStyleUsing.UseBorderColor = false;
            this.Label7.ParentStyleUsing.UseBorders = false;
            this.Label7.ParentStyleUsing.UseBorderWidth = false;
            this.Label7.ParentStyleUsing.UseFont = false;
            this.Label7.ParentStyleUsing.UseForeColor = false;
            this.Label7.Size = new System.Drawing.Size(125, 19);
            this.Label7.Text = "Kreditor";
            // 
            // txtKreditorOrt
            // 
            this.txtKreditorOrt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KreditorOrt", "")});
            this.txtKreditorOrt.Font = new System.Drawing.Font("Arial", 10F);
            this.txtKreditorOrt.ForeColor = System.Drawing.Color.Black;
            this.txtKreditorOrt.Location = new System.Drawing.Point(173, 31);
            this.txtKreditorOrt.Multiline = true;
            this.txtKreditorOrt.Name = "txtKreditorOrt";
            this.txtKreditorOrt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKreditorOrt.ParentStyleUsing.UseBackColor = false;
            this.txtKreditorOrt.ParentStyleUsing.UseBorderColor = false;
            this.txtKreditorOrt.ParentStyleUsing.UseBorders = false;
            this.txtKreditorOrt.ParentStyleUsing.UseBorderWidth = false;
            this.txtKreditorOrt.ParentStyleUsing.UseFont = false;
            this.txtKreditorOrt.ParentStyleUsing.UseForeColor = false;
            this.txtKreditorOrt.Size = new System.Drawing.Size(547, 19);
            this.txtKreditorOrt.Text = "KreditorOrt";
            // 
            // txtKreditorStrasse
            // 
            this.txtKreditorStrasse.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KreditorStrasse", "")});
            this.txtKreditorStrasse.Font = new System.Drawing.Font("Arial", 10F);
            this.txtKreditorStrasse.ForeColor = System.Drawing.Color.Black;
            this.txtKreditorStrasse.Location = new System.Drawing.Point(173, 15);
            this.txtKreditorStrasse.Multiline = true;
            this.txtKreditorStrasse.Name = "txtKreditorStrasse";
            this.txtKreditorStrasse.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKreditorStrasse.ParentStyleUsing.UseBackColor = false;
            this.txtKreditorStrasse.ParentStyleUsing.UseBorderColor = false;
            this.txtKreditorStrasse.ParentStyleUsing.UseBorders = false;
            this.txtKreditorStrasse.ParentStyleUsing.UseBorderWidth = false;
            this.txtKreditorStrasse.ParentStyleUsing.UseFont = false;
            this.txtKreditorStrasse.ParentStyleUsing.UseForeColor = false;
            this.txtKreditorStrasse.Size = new System.Drawing.Size(547, 19);
            this.txtKreditorStrasse.Text = "KreditorStrasse";
            // 
            // txtKreditorName
            // 
            this.txtKreditorName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "KreditorName", "")});
            this.txtKreditorName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtKreditorName.ForeColor = System.Drawing.Color.Black;
            this.txtKreditorName.Location = new System.Drawing.Point(173, 0);
            this.txtKreditorName.Multiline = true;
            this.txtKreditorName.Name = "txtKreditorName";
            this.txtKreditorName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.txtKreditorName.ParentStyleUsing.UseBackColor = false;
            this.txtKreditorName.ParentStyleUsing.UseBorderColor = false;
            this.txtKreditorName.ParentStyleUsing.UseBorders = false;
            this.txtKreditorName.ParentStyleUsing.UseBorderWidth = false;
            this.txtKreditorName.ParentStyleUsing.UseFont = false;
            this.txtKreditorName.ParentStyleUsing.UseForeColor = false;
            this.txtKreditorName.Size = new System.Drawing.Size(547, 19);
            this.txtKreditorName.Text = "KreditorName";
            // 
            // xrLabel7
            // 
            this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameFbKostenart", "")});
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel7.Location = new System.Drawing.Point(140, 17);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.ParentStyleUsing.UseFont = false;
            this.xrLabel7.Size = new System.Drawing.Size(507, 20);
            this.xrLabel7.Text = "xrLabel7";
            // 
            // xrLabel6
            // 
            this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "IdFibuKostenart", "Kostenart {0} :")});
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel6.Location = new System.Drawing.Point(40, 17);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.ParentStyleUsing.UseFont = false;
            this.xrLabel6.Size = new System.Drawing.Size(180, 20);
            this.xrLabel6.Text = "xrLabel6";
            // 
            // Line2
            // 
            this.Line2.ForeColor = System.Drawing.Color.Gray;
            this.Line2.Location = new System.Drawing.Point(39, 58);
            this.Line2.Name = "Line2";
            this.Line2.ParentStyleUsing.UseBackColor = false;
            this.Line2.ParentStyleUsing.UseBorderColor = false;
            this.Line2.ParentStyleUsing.UseBorders = false;
            this.Line2.ParentStyleUsing.UseBorderWidth = false;
            this.Line2.ParentStyleUsing.UseFont = false;
            this.Line2.ParentStyleUsing.UseForeColor = false;
            this.Line2.Size = new System.Drawing.Size(653, 2);
            // 
            // Label13
            // 
            this.Label13.Font = new System.Drawing.Font("Arial", 10F);
            this.Label13.ForeColor = System.Drawing.Color.Black;
            this.Label13.Location = new System.Drawing.Point(598, 38);
            this.Label13.Name = "Label13";
            this.Label13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label13.ParentStyleUsing.UseBackColor = false;
            this.Label13.ParentStyleUsing.UseBorderColor = false;
            this.Label13.ParentStyleUsing.UseBorders = false;
            this.Label13.ParentStyleUsing.UseBorderWidth = false;
            this.Label13.ParentStyleUsing.UseFont = false;
            this.Label13.ParentStyleUsing.UseForeColor = false;
            this.Label13.Size = new System.Drawing.Size(94, 19);
            this.Label13.Text = "Betrag";
            this.Label13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Label12
            // 
            this.Label12.Font = new System.Drawing.Font("Arial", 10F);
            this.Label12.ForeColor = System.Drawing.Color.Black;
            this.Label12.Location = new System.Drawing.Point(472, 38);
            this.Label12.Name = "Label12";
            this.Label12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label12.ParentStyleUsing.UseBackColor = false;
            this.Label12.ParentStyleUsing.UseBorderColor = false;
            this.Label12.ParentStyleUsing.UseBorders = false;
            this.Label12.ParentStyleUsing.UseBorderWidth = false;
            this.Label12.ParentStyleUsing.UseFont = false;
            this.Label12.ParentStyleUsing.UseForeColor = false;
            this.Label12.Size = new System.Drawing.Size(94, 19);
            this.Label12.Text = "Kostenstelle";
            // 
            // Label11
            // 
            this.Label11.Font = new System.Drawing.Font("Arial", 10F);
            this.Label11.ForeColor = System.Drawing.Color.Black;
            this.Label11.Location = new System.Drawing.Point(330, 38);
            this.Label11.Name = "Label11";
            this.Label11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label11.ParentStyleUsing.UseBackColor = false;
            this.Label11.ParentStyleUsing.UseBorderColor = false;
            this.Label11.ParentStyleUsing.UseBorders = false;
            this.Label11.ParentStyleUsing.UseBorderWidth = false;
            this.Label11.ParentStyleUsing.UseFont = false;
            this.Label11.ParentStyleUsing.UseForeColor = false;
            this.Label11.Size = new System.Drawing.Size(110, 19);
            this.Label11.Text = "NRM-Konto";
            // 
            // Label10
            // 
            this.Label10.Font = new System.Drawing.Font("Arial", 10F);
            this.Label10.ForeColor = System.Drawing.Color.Black;
            this.Label10.Location = new System.Drawing.Point(39, 38);
            this.Label10.Name = "Label10";
            this.Label10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Label10.ParentStyleUsing.UseBackColor = false;
            this.Label10.ParentStyleUsing.UseBorderColor = false;
            this.Label10.ParentStyleUsing.UseBorders = false;
            this.Label10.ParentStyleUsing.UseBorderWidth = false;
            this.Label10.ParentStyleUsing.UseFont = false;
            this.Label10.ParentStyleUsing.UseForeColor = false;
            this.Label10.Size = new System.Drawing.Size(157, 19);
            this.Label10.Text = "Buchungstext intern";
            // 
            // xrPageBreak1
            // 
            this.xrPageBreak1.Location = new System.Drawing.Point(0, 33);
            this.xrPageBreak1.Name = "xrPageBreak1";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.Location = new System.Drawing.Point(432, 13);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ParentStyleUsing.UseBackColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel4.ParentStyleUsing.UseBorders = false;
            this.xrLabel4.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel4.ParentStyleUsing.UseFont = false;
            this.xrLabel4.ParentStyleUsing.UseForeColor = false;
            this.xrLabel4.Size = new System.Drawing.Size(157, 19);
            this.xrLabel4.Text = "Total für Beleg";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.Location = new System.Drawing.Point(592, 13);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ParentStyleUsing.UseBackColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel3.ParentStyleUsing.UseBorders = false;
            this.xrLabel3.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel3.ParentStyleUsing.UseFont = false;
            this.xrLabel3.ParentStyleUsing.UseForeColor = false;
            this.xrLabel3.Size = new System.Drawing.Size(100, 19);
            xrSummary4.FormatString = "{0:0.00}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel3.Summary = xrSummary4;
            this.xrLabel3.Text = "xrLabel3";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel5
            // 
            this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "IdFibuKostenart", "Kostenart {0} :")});
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel5.Location = new System.Drawing.Point(307, 22);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.ParentStyleUsing.UseFont = false;
            this.xrLabel5.Size = new System.Drawing.Size(180, 20);
            this.xrLabel5.Text = "xrLabel6";
            // 
            // xrLabel2
            // 
            this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "NameFbKostenart", "")});
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel2.Location = new System.Drawing.Point(400, 22);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ParentStyleUsing.UseFont = false;
            this.xrLabel2.Size = new System.Drawing.Size(195, 20);
            this.xrLabel2.Text = "xrLabel7";
            // 
            // xrLine1
            // 
            this.xrLine1.ForeColor = System.Drawing.Color.Gray;
            this.xrLine1.Location = new System.Drawing.Point(98, 8);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.ParentStyleUsing.UseBackColor = false;
            this.xrLine1.ParentStyleUsing.UseBorderColor = false;
            this.xrLine1.ParentStyleUsing.UseBorders = false;
            this.xrLine1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLine1.ParentStyleUsing.UseFont = false;
            this.xrLine1.ParentStyleUsing.UseForeColor = false;
            this.xrLine1.Size = new System.Drawing.Size(620, 4);
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
                        new DevExpress.XtraReports.UI.XRBinding("Text", this.sqlQuery1, "Betrag", "{0:n2}")});
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.Location = new System.Drawing.Point(591, 22);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ParentStyleUsing.UseBackColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorderColor = false;
            this.xrLabel1.ParentStyleUsing.UseBorders = false;
            this.xrLabel1.ParentStyleUsing.UseBorderWidth = false;
            this.xrLabel1.ParentStyleUsing.UseFont = false;
            this.xrLabel1.ParentStyleUsing.UseForeColor = false;
            this.xrLabel1.Size = new System.Drawing.Size(100, 19);
            xrSummary5.FormatString = "{0:0.00}";
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrLabel1.Summary = xrSummary5;
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
                        this.GroupHeader2,
                        this.GroupHeader3,
                        this.GroupHeader4,
                        this.GroupFooter4,
                        this.GroupFooter3,
                        this.GroupFooter2,
                        this.GroupFooter1});
            this.DataSource = this.sqlQuery1;
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 39, 39);
            this.Name = "Report";
            this.PageHeight = 1178;
            this.PageWidth = 760;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
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
		<FieldName>PrintAll</FieldName>
		<FieldCode>7</FieldCode>
		<DisplayText>Alle Belege ausdrucken</DisplayText>
		<TabPosition>3</TabPosition>
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
		<DisplayText>Nur Belege ab diesem Datum ausdrucken:</DisplayText>
		<TabPosition>4</TabPosition>
		<X>10</X>
		<Y>180</Y>
		<Width>210</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>false</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
	<Table>	
		<FieldName>DateGeneriert</FieldName>
		<FieldCode>5</FieldCode>
		<DisplayText>Nur Belege ab diesem Datum ausdrucken</DisplayText>
		<TabPosition>5</TabPosition>
		<X>220</X>
		<Y>180</Y>
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
		<FieldName>OnlyUnverbuchteBelege</FieldName>
		<FieldCode>7</FieldCode>
		<DisplayText>Nur unverbuchte Belege</DisplayText>
		<TabPosition>7</TabPosition>
		<X>220</X>
		<Y>240</Y>
		<Width>80</Width>
		<Height>25</Height>
		<Length>7</Length>
		<LOVName></LOVName>
		<DefaultValue></DefaultValue>
		<Mandatory>true</Mandatory>
		<TabName></TabName>
		<AppCode></AppCode>
	</Table>
</NewDataSet>' ,  N'declare  @BgBudgetID            int
declare  @PrintAll              bit
declare  @DateGeneriert         datetime
declare  @OnlyUnverbuchteBelege bit

set @BgBudgetID           = {BgBudgetID}
set @PrintAll             = {PrintAll}
set @DateGeneriert        = {DateGeneriert}
set @OnlyUnverbuchteBelege= {OnlyUnverbuchteBelege}

  /*
  DECLARE @aDate        DATETIME
  IF @PrintAll = 1 BEGIN
    SET @aDate = ''19000101''
  END ELSE BEGIN
    SET @aDate = @DateGeneriert
  END
  */

  SELECT
    BelegBezeichnung = ''Beleg # '' + CAST(FBL.KbBuchungID AS VARCHAR) + '', '' +
      dbo.fnLOVText(''KbBuchungStatus'',FBL.KbBuchungStatusCode),
    IdGroup = 1,
    NameGroup = CONVERT(VARCHAR(20),''Budgetpositionen''),
    FBL.KbBuchungID,
    FKA.KbBuchungKostenartID,
    FKS.KbKostenstelleID,
    GeneriertAm = FBL.ErstelltDatum,
    VerbuchtAm = FBL.BelegDatum,
    Buchungsdatum = FBL.BelegDatum,
    VerfallDatum = FBL.ValutaDatum,
    Buchungstext = FBL.Text,
    Extern = IsNull(PR2.Name,'''') + IsNull('' ''+PR2.Vorname,''''),
    ESR = FBL.ReferenzNummer,
    Belegnummer = FBL.BelegNr,
    Intern = FKA.Buchungstext + '', '' + IsNull(PRS.Name,'''') + IsNull('' ''+PRS.Vorname,''''),
    FKA.Betrag,
    NameBelegStatus = dbo.fnLOVText(''KbBuchungStatus'', FBL.KbBuchungStatusCode),
    IdFibuKostenart = KOA.KontoNr,
    NameFbKostenart = KOA.Name,
    NameFbKostenstelle = KST.Nr,
    NameInhaber = KST.Name, --KST.NameInhaber AS NameInhaber,
    NummerNrmKonto = LVN.Value1,
    NameNrmKonto = LVN.Text,
    KreditorName = FBL.BeguenstigtName,
    KreditorStrasse = FBL.BeguenstigtStrasse,
    KreditorOrt = ISNULL(FBL.BeguenstigtPLZ+'' '','''') +ISNULL(FBL.BeguenstigtOrt,''''),
    ISNULL(FBL.BankName+'', '','''') +
    CASE
      WHEN LEN(ISNULL(FBL.BankKontoNr,'''')) > 0
      THEN ''Kto: ''+BankKontoNr ELSE ''''
    END +
    CASE
      WHEN LEN(ISNULL(FBL.PCKontoNr,'''')) > 0
      THEN ''PC: ''+dbo.fnTnToPc(FBL.PCKontoNr) ELSE ''''
    END AS BankName
  FROM KbBuchung FBL
    LEFT JOIN KbBuchungKostenart FKA ON FBL.KbBuchungID          = FKA.KbBuchungID
    LEFT JOIN KbKostenstelle     FKS ON FKA.KbKostenstelleID = FKS.KbKostenstelleID
    LEFT JOIN BgKostenart        KOA ON KOA.BgKostenartID      = FKA.BgKostenartID
    LEFT JOIN KbKostenstelle     KST ON KST.KbKostenstelleID   = FKS.KbKostenstelleID
    LEFT JOIN XLOVCode           LVN ON LVN.Code = FKA.NrmKontoCode AND LVN.LOVName = ''NrmKonto''
    LEFT JOIN BaPerson           PRS ON PRS.BaPersonID = FKA.BaPersonID
    LEFT JOIN KbKostenstelle_BaPerson KSP ON KSP.KbKostenstelleID = KST.KbKostenstelleID
                          AND (KSP.DatumBis IS NULL OR GetDate() BETWEEN KSP.DatumVon AND KSP.DatumBis)
    LEFT JOIN BaPerson           PR2 ON PR2.BaPersonID = KSP.BaPersonID
 WHERE FBL.BgBudgetID = @BgBudgetID
    AND FBL.KbAuszahlungsartCode IN (102, 104)   -- Papierverfügung zur Buchhaltung
    --AND FBL.KbBuchungStatusCode in (1,2) -- vorbereitet, freigegeben
    AND FBL.KbBuchungTypCode=1
    AND (
      (@OnlyUnverbuchteBelege=1 AND FBL.KbBuchungStatusCode = 2) OR
      (@OnlyUnverbuchteBelege=0)
    )
    AND (
      (@PrintAll = 0 AND (@DateGeneriert <= FBL.ErstelltDatum) ) OR
      (@PrintAll = 1)
    )

/*
  UNION ALL

  SELECT ''Beleg # '' + CAST(FBL.KbBuchungID AS VARCHAR) + '', '' + FBS.Text AS BelegBezeichnung,
    2                                          AS IdGroup,
    CONVERT(VARCHAR(20),''Einzelzahlungen'')     AS NameGroup,
    FBL.KbBuchungID                            AS KbBuchungID,
    FKA.KbBuchungKostenartID                   AS KbBuchungKostenartID,
    FKS.KbKostenstelleID                       AS FlBelegKostenstelleID,
    FBL.ErstelltDatum                          AS GeneriertAm,
    FBL.BelegDatum                             AS VerbuchtAm,
    FBL.BelegDatum                             AS Buchungsdatum,
    FBL.ValutaDatum                            AS VerfallDatum,
    FBL.Text                                   AS Buchungstext,
    Extern = IsNull(PR2.Name,'''') + IsNull('' ''+PR2.Vorname,''''),
    FBL.ReferenzNummer                         AS ESR,
    FBL.BelegNr                                AS Belegnummer,
    Intern = FKA.Buchungstext + '', '' + IsNull(PRS.Name,'''') + IsNull('' ''+PRS.Vorname,''''),
    FKA.Betrag                                 AS Betrag,
    FBS.Text                                   AS NameBelegStatus,
    KOA.KontoNr                                AS IdFibuKostenart,
    KOA.Name                                   AS NameFbKostenart,
    FKS.Nr                                     AS NameFbKostenstelle,
    FKS.Name                                   AS NameInhaber,
    LVN.Value1                                 AS NummerNrmKonto,
    LVN.Text                                   AS NameNrmKonto,
    FBL.BeguenstigtName                                   AS KreditorName,
    FBL.BeguenstigtStrasse                                AS KreditorStrasse,
    ISNULL(FBL.BeguenstigtPLZ+'' '','''') +ISNULL(FBL.BeguenstigtOrt,'''') AS KreditorOrt,

    ISNULL(FBL.BankName+'', '','''') +
    CASE
      WHEN LEN(ISNULL(FBL.BankKontoNr,'''')) > 0
      THEN ''Kto: ''+BankKontoNr ELSE ''''
    END +
    CASE
      WHEN LEN(ISNULL(FBL.PCKontoNr,'''')) > 0
      THEN ''PC: ''+dbo.fnTnToPc(FBL.PCKontoNr) ELSE ''''
    END AS BankName

  FROM BgPosition SEZ -- ShEinzelzahlung SEZ
    LEFT JOIN KbBuchung            FBL ON SEZ.BgBudgetID = FBL.BgBudgetID AND FBL.BuchungTypCode = 1  -- ???? = FBL.IdSource AND FBL.FlTypSourceCode=105  -- Einzelverfügungen aus Einzelzahlungen
    LEFT JOIN KbBuchungKostenart   FKA ON FBL.KbBuchungID = FKA.KbBuchungID
    LEFT JOIN KbKostenstelle       FKS ON FKA.KbKostenstelleID = FKS.KbKostenstelleID
    LEFT JOIN XLOVCode             FBS ON FBS.Code = FBL.KbBuchungStatusCode AND FBS.LOVName = ''KbBuchungStatus''
    LEFT JOIN BgKostenart          KOA ON KOA.BgKostenartID      = FKA.BgKostenartID
    LEFT JOIN XLOVCode             LVN ON LVN.Code = FKA.NrmKontoCode AND LVN.LOVName = ''NrmKonto''
    LEFT JOIN BaPerson             PRS ON PRS.BaPersonID = FKA.BaPersonID
    LEFT JOIN BaPerson             PR2 ON PR2.BaPersonID = FKS.BaPersonID
  WHERE SEZ.BgBudgetID = @BgBudgetID
    AND FBL.KbAuszahlungsartCode = 102   -- Papierverfügung zur Buchhaltung
    AND FBL.KbBuchungStatusCode in (1,2) -- vorbereitet, freigegeben
    AND FBL.KbBuchungTypCode=1
    AND SEZ.BgKategorieCode = 101  -- Einzelzahlung
    AND (
      (@OnlyUnverbuchteBelege=1 AND FBL.KbBuchungStatusCode = 3 ) OR
      (@OnlyUnverbuchteBelege=0)
    )
    AND (
      (@PrintAll = 0 AND (@DateGeneriert <= FBL.ErstelltDatum) ) OR
      (@PrintAll = 1)
    )
*/
  ORDER BY IdGroup, FBL.KbBuchungID, KbBuchungKostenartID' ,  null ,  N'ShPapierverfuegungBuchhaltung' ,  null )

