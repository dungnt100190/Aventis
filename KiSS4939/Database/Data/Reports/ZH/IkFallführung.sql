insert [XQuery]([QueryName], [UserText], [QueryCode], [LayoutXML], [ParameterXML], [SQLquery], [ContextForms], [ParentReportName], [ReportSortKey], [RelationColumnName])
values ( N'IkFallführung' ,  N'IK - Fallführung' , 1,  N'<!--
AssemblyName=DevExpress%2EXtraReports%2C%20Version%3D1%2E7%2E7%2E0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4
AssemblyLocation=c:\windows\assembly\gac\devexpress.xtrareports\1.7.7.0__79868b8147b5eae4\devexpress.xtrareports.dll
TypeName=DevExpress.XtraReports.UI.XtraReport
Localization=de-CH
-->
<SOAP-ENV:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:SOAP-ENC="http://schemas.xmlsoap.org/soap/encoding/" xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/" xmlns:clr="http://schemas.microsoft.com/soap/encoding/clr/1.0" SOAP-ENV:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
<SOAP-ENV:Body>
<a1:ReportStorage id="ref-1" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<BandCount>5</BandCount>
<Band0 href="#ref-6"/>
<Band1 href="#ref-7"/>
<Band2 href="#ref-8"/>
<Band3 href="#ref-9"/>
<Band4 href="#ref-10"/>
<Visible>true</Visible>
<Tag id="ref-11"></Tag>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-12">Report</Name>
<Style_X_Font id="ref-13">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor id="ref-14">ControlText</Style_X_ForeColor>
<Style_X_BackColor id="ref-15">Transparent</Style_X_BackColor>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<EventsScript_X_OnBeforePrint id="ref-16">// Forced to render late by setting SummaryType to GrandTotal for txtTotalInkassoFaelle and/or txtTotalGlaeubiger
private void OnBeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
  txtTotalInkassoFaelle.Text = &#34;inkassofälleCount&#34;;//System.Convert.ToString(htInkassoFaelle.Count);
  txtTotalGlaeubiger.Text = &#34;gläubigerCount&#34;;//System.Convert.ToString(htGlaeubiger.Count);
}</EventsScript_X_OnBeforePrint>
<Height>100</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<DataSource id="ref-17">dataSource</DataSource>
<UseDefaultPrinterSettings>false</UseDefaultPrinterSettings>
<ReportUnit xsi:type="a2:ReportUnit" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">HundredthsOfAnInch</ReportUnit>
<Landscape>false</Landscape>
<PaperKind xsi:type="a5:PaperKind" xmlns:a5="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Printing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">A4Rotated</PaperKind>
<PaperName href="#ref-11"/>
<Margins xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>39</x>
<y>39</y>
<width>39</width>
<height>39</height>
</Margins>
<HtmlCompressed>false</HtmlCompressed>
<PageSize xsi:type="a4:Size" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<width>1169</width>
<height>827</height>
</PageSize>
<StyleSheet_X_StyleCount>0</StyleSheet_X_StyleCount>
<ShowPreviewMarginLines>true</ShowPreviewMarginLines>
<ScriptLanguage xsi:type="a6:ScriptLanguage" xmlns:a6="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">CSharp</ScriptLanguage>
<Watermark_X_Text href="#ref-11"/>
<Watermark_X_Font id="ref-18">Verdana, 36pt</Watermark_X_Font>
<Watermark_X_ForeColor id="ref-19">Red</Watermark_X_ForeColor>
<Watermark_X_Transparency>50</Watermark_X_Transparency>
<Watermark_X_TextDirection xsi:type="a7:DirectionMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">ForwardDiagonal</Watermark_X_TextDirection>
<Watermark_X_Image xsi:type="xsd:anyType" xsi:null="1"/>
<Watermark_X_ImageAlign xsi:type="a4:ContentAlignment" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">MiddleCenter</Watermark_X_ImageAlign>
<Watermark_X_ImageViewMode xsi:type="a7:ImageViewMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Clip</Watermark_X_ImageViewMode>
<Watermark_X_ImageTiling>false</Watermark_X_ImageTiling>
<Watermark_X_PageRange href="#ref-11"/>
<Watermark_X_ShowBehind>true</Watermark_X_ShowBehind>
<DefaultPrinterSettingsUsing_X_UseMargins>false</DefaultPrinterSettingsUsing_X_UseMargins>
<DefaultPrinterSettingsUsing_X_UsePaperKind>false</DefaultPrinterSettingsUsing_X_UsePaperKind>
<DefaultPrinterSettingsUsing_X_UseLandscape>false</DefaultPrinterSettingsUsing_X_UseLandscape>
<ShrinkSubReportIconArea>true</ShrinkSubReportIconArea>
</a1:ReportStorage>
<a1:ObjectStorage id="ref-6" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName id="ref-20">DevExpress.XtraReports, Version=1.7.7.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</Type_X_AssemblyName>
<Type_X_TypeName id="ref-21">DevExpress.XtraReports.UI.DetailBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-22">Detail</Name>
<Style_X_Font id="ref-23">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Height>36</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<PrintOnEmptyDataSource>true</PrintOnEmptyDataSource>
<MultiColumn_X_ColumnCount>1</MultiColumn_X_ColumnCount>
<MultiColumn_X_Direction xsi:type="a2:ColumnDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">DownThenAcross</MultiColumn_X_Direction>
<MultiColumn_X_ColumnWidth>0</MultiColumn_X_ColumnWidth>
<MultiColumn_X_ColumnSpacing>0</MultiColumn_X_ColumnSpacing>
<MultiColumn_X_Mode xsi:type="a2:MultiColumnMode" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">UseColumnCount</MultiColumn_X_Mode>
<RepeatCountOnEmptyDataSource>1</RepeatCountOnEmptyDataSource>
<ItemCount>13</ItemCount>
<Item0 href="#ref-24"/>
<Item1 href="#ref-25"/>
<Item2 href="#ref-26"/>
<Item3 href="#ref-27"/>
<Item4 href="#ref-28"/>
<Item5 href="#ref-29"/>
<Item6 href="#ref-30"/>
<Item7 href="#ref-31"/>
<Item8 href="#ref-32"/>
<Item9 href="#ref-33"/>
<Item10 href="#ref-34"/>
<Item11 href="#ref-35"/>
<Item12 href="#ref-36"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-7" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-37">DevExpress.XtraReports.UI.ReportHeaderBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-38">ReportHeader</Name>
<Style_X_Font id="ref-39">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Height>78</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>8</ItemCount>
<Item0 href="#ref-40"/>
<Item1 href="#ref-41"/>
<Item2 href="#ref-42"/>
<Item3 href="#ref-43"/>
<Item4 href="#ref-44"/>
<Item5 href="#ref-45"/>
<Item6 href="#ref-46"/>
<Item7 href="#ref-47"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-8" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-48">DevExpress.XtraReports.UI.PageHeaderBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-49">PageHeader</Name>
<Style_X_Font id="ref-50">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Height>70</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>11</ItemCount>
<Item0 href="#ref-51"/>
<Item1 href="#ref-52"/>
<Item2 href="#ref-53"/>
<Item3 href="#ref-54"/>
<Item4 href="#ref-55"/>
<Item5 href="#ref-56"/>
<Item6 href="#ref-57"/>
<Item7 href="#ref-58"/>
<Item8 href="#ref-59"/>
<Item9 href="#ref-60"/>
<Item10 href="#ref-61"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-9" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-62">DevExpress.XtraReports.UI.PageFooterBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-63">PageFooter</Name>
<Style_X_Font id="ref-64">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<Height>28</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>4</ItemCount>
<Item0 href="#ref-65"/>
<Item1 href="#ref-66"/>
<Item2 href="#ref-67"/>
<Item3 href="#ref-68"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-10" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-69">DevExpress.XtraReports.UI.ReportFooterBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-70">ReportFooter</Name>
<Style_X_Font id="ref-71">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<PrintAtBottom>false</PrintAtBottom>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-24" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-72">DevExpress.XtraReports.UI.XRLabel</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-73">txtTypUnterart</Name>
<Style_X_Font id="ref-74">Arial, 8pt</Style_X_Font>
<Style_X_ForeColor id="ref-75">Black</Style_X_ForeColor>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>618</x>
<y>11</y>
<width>244</width>
<height>15</height>
</Bounds>
<Text id="ref-76">Inkasso-Typ / Unterart</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>false</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-25" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-77">txtVerjaehrungAm</Name>
<Style_X_Font id="ref-78">Arial, 8pt</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName id="ref-79">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-80">VerjaehrungAm</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-81">{0:dd.MM.yyyy}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-17"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>860</x>
<y>0</y>
<width>70</width>
<height>15</height>
</Bounds>
<Text id="ref-82">VerjaehrungAm</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-83">{0:dd.MM.yyyy}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-26" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-84">txtArchiv</Name>
<Style_X_Font id="ref-85">Arial, 8pt</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopCenter</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-79"/>
<BindingItem0_X_DataMember id="ref-86">Archiv</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-17"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>925</x>
<y>0</y>
<width>39</width>
<height>15</height>
</Bounds>
<Text id="ref-87">Archiv</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-27" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-88">txtSARName</Name>
<Style_X_Font id="ref-89">Arial, 8pt</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-79"/>
<BindingItem0_X_DataMember id="ref-90">SARName</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-17"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>964</x>
<y>11</y>
<width>125</width>
<height>15</height>
</Bounds>
<Text id="ref-91">SARName</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>false</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-28" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-92">txtSAR</Name>
<Style_X_Font id="ref-93">Arial, 8pt</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-79"/>
<BindingItem0_X_DataMember id="ref-94">SAR</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-17"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>964</x>
<y>0</y>
<width>122</width>
<height>15</height>
</Bounds>
<Text id="ref-95">SAR</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-29" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-96">txtInkassoFallName</Name>
<Style_X_Font id="ref-97">Arial, 8pt</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-79"/>
<BindingItem0_X_DataMember id="ref-98">InkassoFallName</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-17"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>618</x>
<y>0</y>
<width>244</width>
<height>15</height>
</Bounds>
<Text id="ref-99">InkassoFallName</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>false</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-30" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-100">txtElterlicheGewalt</Name>
<Style_X_Font id="ref-101">Arial, 8pt</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-79"/>
<BindingItem0_X_DataMember id="ref-102">ElterlicheGewalt</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-17"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>503</x>
<y>11</y>
<width>114</width>
<height>15</height>
</Bounds>
<Text id="ref-103">ElterlicheGewalt</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>false</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-31" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-104">txtBemuehungText</Name>
<Style_X_Font id="ref-105">Arial, 8pt</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-79"/>
<BindingItem0_X_DataMember id="ref-106">BemuehungText</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-17"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>503</x>
<y>0</y>
<width>114</width>
<height>15</height>
</Bounds>
<Text id="ref-107">BemuehungText</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-32" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-108">txtStatus</Name>
<Style_X_Font id="ref-109">Arial, 8pt</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-79"/>
<BindingItem0_X_DataMember id="ref-110">Status</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-17"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>452</x>
<y>0</y>
<width>51</width>
<height>15</height>
</Bounds>
<Text id="ref-111">Status</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-33" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-112">txtMonatsBevorschussung</Name>
<Style_X_Font id="ref-113">Arial, 8pt</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-79"/>
<BindingItem0_X_DataMember id="ref-114">MonatsBevorschussung</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-115">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-17"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>385</x>
<y>0</y>
<width>55</width>
<height>15</height>
</Bounds>
<Text id="ref-116">MonatsBevorschussung</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-117">{0:0.00}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-34" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-118">txtSchuldner</Name>
<Style_X_Font id="ref-119">Arial, 8pt</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-79"/>
<BindingItem0_X_DataMember id="ref-120">Schuldner</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-17"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>236</x>
<y>0</y>
<width>161</width>
<height>15</height>
</Bounds>
<Text id="ref-121">Schuldner</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-35" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-122">txtGeburtsdatum</Name>
<Style_X_Font id="ref-123">Arial, 8pt</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-79"/>
<BindingItem0_X_DataMember id="ref-124">Geburtsdatum</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-125">{0:dd.MM.yyyy}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-17"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>165</x>
<y>0</y>
<width>70</width>
<height>15</height>
</Bounds>
<Text id="ref-126">Geburtsdatum</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-127">{0:dd.MM.yyyy}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-36" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-128">txtGlaeubiger</Name>
<Style_X_Font id="ref-129">Arial, 8pt</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName href="#ref-79"/>
<BindingItem0_X_DataMember id="ref-130">Glaeubiger</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-17"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>3</x>
<y>0</y>
<width>161</width>
<height>15</height>
</Bounds>
<Text id="ref-131">Glaeubiger</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-40" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-132">txtTotalGlaeubiger</Name>
<Style_X_Font id="ref-133">Arial, 10pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName id="ref-134">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-135">Glaeubiger</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-17"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>542</x>
<y>51</y>
<width>161</width>
<height>19</height>
</Bounds>
<Text id="ref-136">Total Glaeubiger</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-137">{0}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">DCount</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Report</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-41" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-138">txtTotalInkassoFaelle</Name>
<Style_X_Font id="ref-139">Arial, 10pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<BindingItem0_X_PropertyName id="ref-140">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-141">AiInkassoFallID</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-11"/>
<BindingItem0_X_DataSource href="#ref-17"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>542</x>
<y>27</y>
<width>161</width>
<height>19</height>
</Bounds>
<Text id="ref-142">Total InkassoFaelle</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-143">{0}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">DCount</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Report</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-42" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-144">Label16</Name>
<Style_X_Font id="ref-145">Arial, 10pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<x>439</x>
<y>51</y>
<width>94</width>
<height>19</height>
</Bounds>
<Text id="ref-146">Gläubiger:</Text>
<NavigateUrl xsi:type="xsd:anyType" xsi:null="1"/>
<Target href="#ref-11"/>
<CanGrow>false</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-43" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-147">Label15</Name>
<Style_X_Font id="ref-148">Arial, 10pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<x>439</x>
<y>27</y>
<width>94</width>
<height>19</height>
</Bounds>
<Text id="ref-149">Inkassofälle:</Text>
<NavigateUrl xsi:type="xsd:anyType" xsi:null="1"/>
<Target href="#ref-11"/>
<CanGrow>false</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-44" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-150">Label4</Name>
<Style_X_Font id="ref-151">Arial, 14pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<y>47</y>
<width>188</width>
<height>27</height>
</Bounds>
<Text id="ref-152">Fallführung</Text>
<NavigateUrl xsi:type="xsd:anyType" xsi:null="1"/>
<Target href="#ref-11"/>
<CanGrow>false</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-45" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-153">Label3</Name>
<Style_X_Font id="ref-154">Arial, 9pt</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>921</x>
<y>19</y>
<width>102</width>
<height>19</height>
</Bounds>
<Text id="ref-155">3000 Bern</Text>
<NavigateUrl xsi:type="xsd:anyType" xsi:null="1"/>
<Target href="#ref-11"/>
<CanGrow>false</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-46" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-156">Label2</Name>
<Style_X_Font id="ref-157">Arial, 9pt</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>921</x>
<y>0</y>
<width>102</width>
<height>19</height>
</Bounds>
<Text id="ref-158">Predigerstr. 10</Text>
<NavigateUrl xsi:type="xsd:anyType" xsi:null="1"/>
<Target href="#ref-11"/>
<CanGrow>false</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-47" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-159">Label1</Name>
<Style_X_Font id="ref-160">Arial, 12pt</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<width>322</width>
<height>27</height>
</Bounds>
<Text id="ref-161">Inkassodienst der Stadt Bern</Text>
<NavigateUrl xsi:type="xsd:anyType" xsi:null="1"/>
<Target href="#ref-11"/>
<CanGrow>false</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-51" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-162">Label14</Name>
<Style_X_Font id="ref-163">Arial, 8pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>964</x>
<y>24</y>
<width>55</width>
<height>19</height>
</Bounds>
<Text id="ref-164">SAR</Text>
<NavigateUrl xsi:type="xsd:anyType" xsi:null="1"/>
<Target href="#ref-11"/>
<CanGrow>false</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-52" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-165">Label13</Name>
<Style_X_Font id="ref-166">Arial, 8pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>925</x>
<y>24</y>
<width>39</width>
<height>19</height>
</Bounds>
<Text id="ref-167">Archiv</Text>
<NavigateUrl xsi:type="xsd:anyType" xsi:null="1"/>
<Target href="#ref-11"/>
<CanGrow>false</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-53" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-168">Label12</Name>
<Style_X_Font id="ref-169">Arial, 8pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>860</x>
<y>24</y>
<width>62</width>
<height>35</height>
</Bounds>
<Text id="ref-170">Verjährung am</Text>
<NavigateUrl xsi:type="xsd:anyType" xsi:null="1"/>
<Target href="#ref-11"/>
<CanGrow>false</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-54" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-171">Label11</Name>
<Style_X_Font id="ref-172">Arial, 8pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>618</x>
<y>24</y>
<width>125</width>
<height>35</height>
</Bounds>
<Text id="ref-173">Inkassofall Inkasso-Typ / Unterart</Text>
<NavigateUrl xsi:type="xsd:anyType" xsi:null="1"/>
<Target href="#ref-11"/>
<CanGrow>false</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-55" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-174">Label10</Name>
<Style_X_Font id="ref-175">Arial, 8pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>503</x>
<y>24</y>
<width>98</width>
<height>35</height>
</Bounds>
<Text id="ref-176">Bemühung elterliche Gewalt</Text>
<NavigateUrl xsi:type="xsd:anyType" xsi:null="1"/>
<Target href="#ref-11"/>
<CanGrow>false</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-56" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-177">Label9</Name>
<Style_X_Font id="ref-178">Arial, 8pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>452</x>
<y>24</y>
<width>51</width>
<height>19</height>
</Bounds>
<Text id="ref-179">Status</Text>
<NavigateUrl xsi:type="xsd:anyType" xsi:null="1"/>
<Target href="#ref-11"/>
<CanGrow>false</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-57" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-180">Label8</Name>
<Style_X_Font id="ref-181">Arial, 8pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopRight</Style_X_TextAlignment>
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
<x>385</x>
<y>24</y>
<width>55</width>
<height>35</height>
</Bounds>
<Text id="ref-182">monatl. Betrag</Text>
<NavigateUrl xsi:type="xsd:anyType" xsi:null="1"/>
<Target href="#ref-11"/>
<CanGrow>false</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-58" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-183">Label7</Name>
<Style_X_Font id="ref-184">Arial, 8pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>236</x>
<y>24</y>
<width>161</width>
<height>19</height>
</Bounds>
<Text id="ref-185">Schuldner</Text>
<NavigateUrl xsi:type="xsd:anyType" xsi:null="1"/>
<Target href="#ref-11"/>
<CanGrow>false</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-59" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-186">Label6</Name>
<Style_X_Font id="ref-187">Arial, 8pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>165</x>
<y>24</y>
<width>70</width>
<height>19</height>
</Bounds>
<Text id="ref-188">Geb. Datum</Text>
<NavigateUrl xsi:type="xsd:anyType" xsi:null="1"/>
<Target href="#ref-11"/>
<CanGrow>false</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-60" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-189">Label5</Name>
<Style_X_Font id="ref-190">Arial, 8pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-75"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>3</x>
<y>24</y>
<width>161</width>
<height>19</height>
</Bounds>
<Text id="ref-191">Gläubiger</Text>
<NavigateUrl xsi:type="xsd:anyType" xsi:null="1"/>
<Target href="#ref-11"/>
<CanGrow>false</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-61" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-192">DevExpress.XtraReports.UI.XRControl</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-193">Shape1</Name>
<Style_X_Font id="ref-194">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-75"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">All</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<y>16</y>
<width>1086</width>
<height>43</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-65" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-195">xrLabel2</Name>
<Style_X_Font id="ref-196">Arial, 9pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>472</x>
<y>4</y>
<width>100</width>
<height>20</height>
</Bounds>
<Text id="ref-197">Seite</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-66" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName id="ref-198">DevExpress.XtraReports.UI.XRPageInfo</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-199">xrPageInfo2</Name>
<Style_X_Font id="ref-200">Arial, 9pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>519</x>
<y>4</y>
<width>100</width>
<height>20</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<PageInfo xsi:type="a3:PageInfo" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">NumberOfTotal</PageInfo>
<Format href="#ref-11"/>
<StartPageNumber>1</StartPageNumber>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-67" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-198"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-201">xrPageInfo1</Name>
<Style_X_Font id="ref-202">Arial, 9pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>87</x>
<y>4</y>
<width>100</width>
<height>20</height>
</Bounds>
<Text href="#ref-11"/>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<PageInfo xsi:type="a3:PageInfo" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">DateTime</PageInfo>
<Format id="ref-203">{0:dd.MM.yyyy}</Format>
<StartPageNumber>1</StartPageNumber>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-68" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-20"/>
<Type_X_TypeName href="#ref-72"/>
<Visible>true</Visible>
<Tag href="#ref-11"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-204">xrLabel1</Name>
<Style_X_Font id="ref-205">Arial, 9pt</Style_X_Font>
<Style_X_ForeColor href="#ref-14"/>
<Style_X_BackColor href="#ref-15"/>
<Style_X_BorderColor href="#ref-14"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.1.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
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
<x>0</x>
<y>4</y>
<width>100</width>
<height>20</height>
</Bounds>
<Text id="ref-206">Druckdatum</Text>
<NavigateUrl href="#ref-11"/>
<Target href="#ref-11"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>false</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.7.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
</SOAP-ENV:Body>
</SOAP-ENV:Envelope>' ,  N'<NewDataSet>
    <Table>
        <FieldName>-</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>SAR</DisplayText>
        <TabPosition>0</TabPosition>
        <X>10</X>
        <Y>40</Y>
    </Table>
    <Table>
        <FieldName>SAR_ID</FieldName>
        <FieldCode>14</FieldCode>
        <TabPosition>1</TabPosition>
        <X>184</X>
        <Y>40</Y>
        <Width>264</Width>
        <Height>24</Height>
        <Mandatory>false</Mandatory>
        <SQL>select ID = UserID, SAR = LastName + isNull('', '' + FirstName,''''), [Kürzel] = LogonName
from   XUser 
where LastName + isNull('', '' + FirstName,'''') like {0} + ''%'' 
order by SAR
		</SQL>
    </Table>
    <Table>
        <FieldName>lblInkassoTyp</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Inkasso-Typ</DisplayText>
        <TabPosition>2</TabPosition>
        <X>10</X>
        <Y>70</Y>
        <Width>128</Width>
        <Height>24</Height>
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
        <FieldName>InkassoTyp</FieldName>
        <FieldCode>8</FieldCode>
        <DisplayText>Inkasso-Typ</DisplayText>
        <TabPosition>3</TabPosition>
        <X>184</X>
        <Y>70</Y>
        <Width>264</Width>
        <Height>24</Height>
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
        <SQL>
	select [Code] = AiInkassoTypID, [Text] = InkassoTypText from AiInkassoTyp order by AiInkassoTypID
        </SQL>
    </Table>
    <Table>
        <FieldName>lblInkassoTypUnterart</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Inkasso-Typ Unterart</DisplayText>
        <TabPosition>4</TabPosition>
        <X>10</X>
        <Y>100</Y>
        <Width>128</Width>
        <Height>24</Height>
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
        <FieldName>InkassoTypUnterart</FieldName>
        <FieldCode>8</FieldCode>
        <DisplayText>Inkasso-Typ Unterart</DisplayText>
        <TabPosition>5</TabPosition>
        <X>184</X>
        <Y>100</Y>
        <Width>264</Width>
        <Height>24</Height>
        <Length>7</Length>
        <LOVName>AiInkassofallUnterart</LOVName>
        <DefaultValue>
        </DefaultValue>
        <Mandatory>false</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>lblNurLaufendeBevorschussung</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>nur laufende Bevorschussungen</DisplayText>
        <TabPosition>6</TabPosition>
        <X>10</X>
        <Y>130</Y>
        <Width>166</Width>
        <Height>24</Height>
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
        <FieldName>NurLaufendeBevorschussung</FieldName>
        <FieldCode>7</FieldCode>
        <DisplayText>
        </DisplayText>
        <TabPosition>7</TabPosition>
        <X>184</X>
        <Y>130</Y>
        <Width>24</Width>
        <Height>24</Height>
        <Length>7</Length>
        <LOVName>
        </LOVName>
        <DefaultValue>0</DefaultValue>
        <Mandatory>false</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>lblInkassofallStatus</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Status</DisplayText>
        <TabPosition>8</TabPosition>
        <X>10</X>
        <Y>160</Y>
        <Width>128</Width>
        <Height>24</Height>
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
        <FieldName>InkassofallStatus</FieldName>
        <FieldCode>8</FieldCode>
        <DisplayText>Status</DisplayText>
        <TabPosition>10</TabPosition>
        <X>184</X>
        <Y>160</Y>
        <Width>200</Width>
        <Height>24</Height>
        <Length>7</Length>
        <LOVName>AiInkassofallStatus</LOVName>
        <DefaultValue>
        </DefaultValue>
        <Mandatory>false</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>lblNurExtensive</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>nur extensive Fälle</DisplayText>
        <TabPosition>11</TabPosition>
        <X>10</X>
        <Y>190</Y>
        <Width>128</Width>
        <Height>24</Height>
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
        <FieldName>NurExtensive</FieldName>
        <FieldCode>7</FieldCode>
        <DisplayText>
        </DisplayText>
        <TabPosition>12</TabPosition>
        <X>184</X>
        <Y>190</Y>
        <Width>24</Width>
        <Height>24</Height>
        <Length>7</Length>
        <LOVName>
        </LOVName>
        <DefaultValue>0</DefaultValue>
        <Mandatory>false</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>lblVerjaehrung</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Verjährung</DisplayText>
        <TabPosition>13</TabPosition>
        <X>10</X>
        <Y>220</Y>
        <Width>128</Width>
        <Height>24</Height>
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
        <FieldName>lblVerjaehrungVon</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>von</DisplayText>
        <TabPosition>14</TabPosition>
        <X>184</X>
        <Y>220</Y>
        <Width>24</Width>
        <Height>24</Height>
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
        <FieldName>VerjaehrungVon</FieldName>
        <FieldCode>5</FieldCode>
        <DisplayText>Verjährung von</DisplayText>
        <TabPosition>15</TabPosition>
        <X>216</X>
        <Y>220</Y>
        <Width>96</Width>
        <Height>24</Height>
        <Length>10</Length>
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
        <FieldName>lblVerjaehrungBis</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>bis</DisplayText>
        <TabPosition>16</TabPosition>
        <X>328</X>
        <Y>220</Y>
        <Width>24</Width>
        <Height>24</Height>
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
        <FieldName>VerjaehrungBis</FieldName>
        <FieldCode>5</FieldCode>
        <DisplayText>Verjährung bis</DisplayText>
        <TabPosition>17</TabPosition>
        <X>352</X>
        <Y>220</Y>
        <Width>96</Width>
        <Height>24</Height>
        <Length>10</Length>
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
        <FieldName>lblInklAbgeschlossene</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>inklusive abgeschlossene Fälle</DisplayText>
        <TabPosition>18</TabPosition>
        <X>10</X>
        <Y>250</Y>
        <Width>128</Width>
        <Height>24</Height>
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
        <FieldName>InklAbgeschlossene</FieldName>
        <FieldCode>7</FieldCode>
        <DisplayText>
        </DisplayText>
        <TabPosition>19</TabPosition>
        <X>184</X>
        <Y>250</Y>
        <Width>24</Width>
        <Height>24</Height>
        <Length>7</Length>
        <LOVName>
        </LOVName>
        <DefaultValue>0</DefaultValue>
        <Mandatory>false</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>lblInklArchivierte</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>inklusive archivierte Fälle</DisplayText>
        <TabPosition>20</TabPosition>
        <X>10</X>
        <Y>280</Y>
        <Width>128</Width>
        <Height>24</Height>
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
        <FieldName>InklArchivierte</FieldName>
        <FieldCode>7</FieldCode>
        <DisplayText>
        </DisplayText>
        <TabPosition>21</TabPosition>
        <X>184</X>
        <Y>280</Y>
        <Width>24</Width>
        <Height>24</Height>
        <Length>7</Length>
        <LOVName>
        </LOVName>
        <DefaultValue>0</DefaultValue>
        <Mandatory>false</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
    </Table>
    <Table>
        <FieldName>lblSortierung</FieldName>
        <FieldCode>1</FieldCode>
        <DisplayText>Sortierreihenfolge</DisplayText>
        <TabPosition>22</TabPosition>
        <X>10</X>
        <Y>310</Y>
        <Width>128</Width>
        <Height>24</Height>
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
        <FieldName>Sortierung</FieldName>
        <FieldCode>8</FieldCode>
        <DisplayText>Sortierreihenfolge</DisplayText>
        <TabPosition>23</TabPosition>
        <X>184</X>
        <Y>310</Y>
        <Width>200</Width>
        <Height>24</Height>
        <Length>7</Length>
        <LOVName>
        </LOVName>
        <DefaultValue>2</DefaultValue>
        <Mandatory>true</Mandatory>
        <TabName>
        </TabName>
        <AppCode>
        </AppCode>
        <SQL>
        select [Code] = 1, [Text] = ''Gläubiger''
		union
	select [Code] = 2, [Text] = ''Schuldner''
		union
	select [Code] = 3, [Text] = ''Verjährung''
	</SQL>
    </Table>
</NewDataSet>' ,  N'declare @InkassoTyp                integer  -- null: alle, sonst LOV AiInkassoTyp_REPORT (identisch AiInkassoTyp)
declare @InkassoTypUnterart        integer  -- null: alle, sonst LOV AiInkassofallUnterart
declare @SAR_ID                    integer  -- UserID des SAR, der den Report aufruft
declare @NurLaufendeBevorschussung bit
declare @InkassofallStatus         integer  -- null: alle, 1: Laufende Beiträge, 2: Restanz
declare @NurExtensive              bit
declare @VerjaehrungVon            datetime -- null: nach unten offen (past unlimited)
declare @VerjaehrungBis            datetime -- null: nach oben offen (future unlimited)
declare @InklAbgeschlossene        bit
declare @InklArchivierte           bit
declare @Sortierung                integer  -- null oder 1: Gläubiger, 2: Schuldner, 3: Verjährung

set @InkassoTyp = {InkassoTyp}
set @InkassoTypUnterart = {InkassoTypUnterart}
set @SAR_ID = {SAR_ID}
set @NurLaufendeBevorschussung = {NurLaufendeBevorschussung}
set @InkassofallStatus = {InkassofallStatus}
set @NurExtensive = {NurExtensive}
set @VerjaehrungVon = {VerjaehrungVon}
set @VerjaehrungBis = {VerjaehrungBis}
set @InklAbgeschlossene = {InklAbgeschlossene}
set @InklArchivierte = {InklArchivierte}
set @Sortierung = {Sortierung}

/*
  Erstellt durch     :  M. Weber
  Erstellt am        :  30.03.2003
  Version            :  3.0
  History            :  14. Juli, Portierung und Erweiterung fuer V3.0
*/
declare @TODAY_NOTIME datetime
set @TODAY_NOTIME = CONVERT(datetime, CONVERT(VARCHAR, current_timestamp, 112))
select
  PRSG.Name + isNull('', '' + PRSG.Vorname1,'''') +
    case len(isNull(PRSG.Vorname2, '''')) when 0 then '''' else '' '' + PRSG.Vorname2 end Glaeubiger,
  PRSG.Geburtsdatum,
  AGL.AiGlaeubigerID,
  AGL.ElterlicheGewalt,
  AIF.AiInkassoFallID,
  AIF.InkassoFallName,
  PRSS.Name + isNull('', '' + PRSS.Vorname1,'''') +
    case len(isNull(PRSS.Vorname2, '''')) when 0 then '''' else '' '' + PRSS.Vorname2 end Schuldner,
  AFO.AiForderungID,
  AFP.AiForderungPeriodischID,
  AFP.DatumVon,
  AFP.Betrag MonatsBevorschussung,
  ISA.Text Status,
  IBE.Text BemuehungText,
  IUA.Text Unterart,
  AIF.VerjaehrungAm,
  AIT.InkassoTypText InkassoTyp,
  case when FFA.FaFallID is null then '''' else ''x'' end Archiv,
  USR.LogonName SAR,
  USR.LastName + isNull('', '' + USR.FirstName,'''') SARName
from
  AiInkassoFall                    AIF
  inner join FaFall                FAL  on FAL.FaFallID = AIF.FaFallID -- Fälle mit Inkasso
  left  join AiGlaeubiger          AGL  on AGL.FaFallID = FAL.FaFallID -- alle Gläubiger der Fälle mit Inkasso
  inner join XUser                 USR  on USR.UserID = FAL.UserID
  inner join DmgPerson             PRSS on PRSS.DmgPersonID = FAL.DmgPersonID -- Schuldner
  inner join XLOVCode              ISA  on AIF.AiInkassofallStatusCode = ISA.Code and ISA.LOVName = ''AiInkassofallStatus''
  inner join XLOVCode              IBE  on AIF.AiInkassoBemuehungCode = IBE.Code and IBE.LOVName = ''AiInkassoBemuehung''
  left  join XLOVCode              IUA  on AIF.AiInkassofallUnterartCode = IUA.Code and IUA.LOVName = ''AiInkassofallUnterart''
  inner join AiInkassoTyp          AIT  on AIT.AiInkassoTypID = AIF.AiInkassoTypID
  left  join AiForderung           AFO  on AFO.AiInkassoFallID = AIF.AiInkassoFallID and
                                                  AFO.AiForderungTypID = 3 and -- Kinderalimente (Bevorschussung)
                                                  AFO.BvAktiv = 1 and
                                                  (AFO.AiGlaeubigerID = AGL.AiGlaeubigerID or AFO.AiGlaeubigerID is null or AGL.AiGlaeubigerID is null)
  left  join AiForderungPeriodisch AFP  on AFP.AiForderungID = AFO.AiForderungID and
                                                  AFP.DatumVon =
                                                    (select Max(DatumVon)
                                                     from   AiForderungPeriodisch
                                                     where  AiForderungID = AFO.AiForderungID and
                                                            DatumVon <= getDate())
  left  join DmgPerson             PRSG on PRSG.DmgPersonID = AGL.DmgPersonID -- Gläubiger
  left  join FaFallArchiv          FFA  on FFA.FaFallID = FAL.FaFallID and FFA.CheckOut is NULL
where
  (@InkassoTyp is null or @InkassoTyp = AIF.AiInkassoTypID) and
  (@InkassoTypUnterart is null or @InkassoTypUnterart = AIF.AiInkassofallUnterartCode) and
  (@SAR_ID is null or @SAR_ID = USR.UserID) and
  (isNull(@NurLaufendeBevorschussung,0) = 0 or AFP.Betrag is not null) and
  (@InkassofallStatus is null or @InkassofallStatus = AIF.AiInkassofallStatusCode) and
  (isNull(@NurExtensive,0) = 0 or AIF.AiInkassoBemuehungCode = 2) and  -- 2 = Extensiv
  ((AIF.VerjaehrungAm >= @VerjaehrungVon AND AIF.VerjaehrungAm <= @VerjaehrungBis)
    OR (AIF.VerjaehrungAm >= @VerjaehrungVon AND @VerjaehrungBis IS NULL)
    OR (@VerjaehrungVon IS NULL AND AIF.VerjaehrungAm <= @VerjaehrungBis)
    OR (@VerjaehrungVon IS NULL AND @VerjaehrungBis IS NULL)) and
  (isNull(@InklAbgeschlossene,0) = 1 or (AIF.DatumBis is null or AIF.DatumBis > @TODAY_NOTIME)) and
  (isNull(@InklArchivierte,0) = 1 or FFA.FaFallID is null)
order by
  case isNull(@Sortierung,1)
  when 1 then PRSG.Name + isNull('', '' + PRSG.Vorname1,'''') + isNull('', '' + PRSG.Vorname2,'''')  -- Gläubiger
  when 2 then PRSS.Name + isNull('', '' + PRSS.Vorname1,'''') + isNull('', '' + PRSS.Vorname2,'''')  -- Schuldner
  when 3 then convert(varchar,AIF.VerjaehrungAm,112)
  else PRSG.Name + isNull('', '' + PRSG.Vorname1,'''') + isNull('', '' + PRSG.Vorname2,'''')  -- Gläubiger
  end' ,  N'Ai' ,  null , 1,  null )
