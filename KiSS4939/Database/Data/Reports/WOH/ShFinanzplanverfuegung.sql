-- Insert Script for ShFinanzplanverfuegung
DELETE FROM XQuery WHERE QueryName LIKE 'ShFinanzplanverfuegung' OR ParentReportName LIKE 'ShFinanzplanverfuegung'
INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShFinanzplanverfuegung' ,  N'SH - Finanzplanverfügung' , 1,  N'<!--
AssemblyName=DevExpress%2EXtraReports%2C%20Version%3D1%2E7%2E10%2E0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4
AssemblyLocation=c:\programme\born informatik ag\kiss30\devexpress.xtrareports.dll
TypeName=DevExpress.XtraReports.UI.XtraReport
Localization=de-DE
-->
<SOAP-ENV:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:SOAP-ENC="http://schemas.xmlsoap.org/soap/encoding/" xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/" xmlns:clr="http://schemas.microsoft.com/soap/encoding/clr/1.0" SOAP-ENV:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
<SOAP-ENV:Body>
<a1:ReportStorage id="ref-1" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<BandCount>2</BandCount>
<Band0 href="#ref-6"/>
<Band1 href="#ref-7"/>
<Visible>true</Visible>
<Tag id="ref-8"></Tag>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-9">Report</Name>
<Style_X_Font id="ref-10">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor id="ref-11">ControlText</Style_X_ForeColor>
<Style_X_BackColor id="ref-12">Transparent</Style_X_BackColor>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>254</width>
<height>58</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>254</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<DataSource id="ref-13">dataSource</DataSource>
<UseDefaultPrinterSettings>false</UseDefaultPrinterSettings>
<ReportUnit xsi:type="a2:ReportUnit" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TenthsOfAMillimeter</ReportUnit>
<Landscape>false</Landscape>
<PaperKind xsi:type="a5:PaperKind" xmlns:a5="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Printing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">A4</PaperKind>
<PaperName href="#ref-8"/>
<Margins xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>250</x>
<y>150</y>
<width>140</width>
<height>100</height>
</Margins>
<HtmlCompressed>false</HtmlCompressed>
<PageSize xsi:type="a4:Size" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<width>2101</width>
<height>2969</height>
</PageSize>
<StyleSheet_X_StyleCount>0</StyleSheet_X_StyleCount>
<ShowPreviewMarginLines>true</ShowPreviewMarginLines>
<ScriptLanguage xsi:type="a6:ScriptLanguage" xmlns:a6="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">CSharp</ScriptLanguage>
<Watermark_X_Text href="#ref-8"/>
<Watermark_X_Font id="ref-14">Verdana, 36pt</Watermark_X_Font>
<Watermark_X_ForeColor id="ref-15">Red</Watermark_X_ForeColor>
<Watermark_X_Transparency>50</Watermark_X_Transparency>
<Watermark_X_TextDirection xsi:type="a7:DirectionMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">ForwardDiagonal</Watermark_X_TextDirection>
<Watermark_X_Image xsi:type="xsd:anyType" xsi:null="1"/>
<Watermark_X_ImageAlign xsi:type="a4:ContentAlignment" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">MiddleCenter</Watermark_X_ImageAlign>
<Watermark_X_ImageViewMode xsi:type="a7:ImageViewMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Clip</Watermark_X_ImageViewMode>
<Watermark_X_ImageTiling>false</Watermark_X_ImageTiling>
<Watermark_X_PageRange href="#ref-8"/>
<Watermark_X_ShowBehind>true</Watermark_X_ShowBehind>
<DefaultPrinterSettingsUsing_X_UseMargins>false</DefaultPrinterSettingsUsing_X_UseMargins>
<DefaultPrinterSettingsUsing_X_UsePaperKind>false</DefaultPrinterSettingsUsing_X_UsePaperKind>
<DefaultPrinterSettingsUsing_X_UseLandscape>false</DefaultPrinterSettingsUsing_X_UseLandscape>
<ShrinkSubReportIconArea>true</ShrinkSubReportIconArea>
</a1:ReportStorage>
<a1:ObjectStorage id="ref-6" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName id="ref-16">DevExpress.XtraReports, Version=1.7.10.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</Type_X_AssemblyName>
<Type_X_TypeName id="ref-17">DevExpress.XtraReports.UI.DetailBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-18">Detail</Name>
<Style_X_Font id="ref-19">Tahoma, 9pt</Style_X_Font>
<Style_X_ForeColor href="#ref-11"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>254</width>
<height>58</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>1924</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<PrintOnEmptyDataSource>true</PrintOnEmptyDataSource>
<MultiColumn_X_ColumnCount>1</MultiColumn_X_ColumnCount>
<MultiColumn_X_Direction xsi:type="a2:ColumnDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">DownThenAcross</MultiColumn_X_Direction>
<MultiColumn_X_ColumnWidth>0</MultiColumn_X_ColumnWidth>
<MultiColumn_X_ColumnSpacing>0</MultiColumn_X_ColumnSpacing>
<MultiColumn_X_Mode xsi:type="a2:MultiColumnMode" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">UseColumnCount</MultiColumn_X_Mode>
<RepeatCountOnEmptyDataSource>1</RepeatCountOnEmptyDataSource>
<ItemCount>41</ItemCount>
<Item0 href="#ref-20"/>
<Item1 href="#ref-21"/>
<Item2 href="#ref-22"/>
<Item3 href="#ref-23"/>
<Item4 href="#ref-24"/>
<Item5 href="#ref-25"/>
<Item6 href="#ref-26"/>
<Item7 href="#ref-27"/>
<Item8 href="#ref-28"/>
<Item9 href="#ref-29"/>
<Item10 href="#ref-30"/>
<Item11 href="#ref-31"/>
<Item12 href="#ref-32"/>
<Item13 href="#ref-33"/>
<Item14 href="#ref-34"/>
<Item15 href="#ref-35"/>
<Item16 href="#ref-36"/>
<Item17 href="#ref-37"/>
<Item18 href="#ref-38"/>
<Item19 href="#ref-39"/>
<Item20 href="#ref-40"/>
<Item21 href="#ref-41"/>
<Item22 href="#ref-42"/>
<Item23 href="#ref-43"/>
<Item24 href="#ref-44"/>
<Item25 href="#ref-45"/>
<Item26 href="#ref-46"/>
<Item27 href="#ref-47"/>
<Item28 href="#ref-48"/>
<Item29 href="#ref-49"/>
<Item30 href="#ref-50"/>
<Item31 href="#ref-51"/>
<Item32 href="#ref-52"/>
<Item33 href="#ref-53"/>
<Item34 href="#ref-54"/>
<Item35 href="#ref-55"/>
<Item36 href="#ref-56"/>
<Item37 href="#ref-57"/>
<Item38 href="#ref-58"/>
<Item39 href="#ref-59"/>
<Item40 href="#ref-60"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-7" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName id="ref-61">DevExpress.XtraReports.UI.ReportFooterBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-62">ReportFooter</Name>
<Style_X_Font id="ref-63">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-11"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>254</width>
<height>58</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>733</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<PrintAtBottom>false</PrintAtBottom>
<ItemCount>2</ItemCount>
<Item0 href="#ref-64"/>
<Item1 href="#ref-65"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-20" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName id="ref-66">DevExpress.XtraReports.UI.XRPictureBox</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-67">xrPictureBox1</Name>
<Style_X_Font id="ref-68">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-11"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>1700</width>
<height>120</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<Image href="#ref-69"/>
<Sizing xsi:type="a3:ImageSizeMode" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">StretchImage</Sizing>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-21" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName id="ref-70">DevExpress.XtraReports.UI.XRLine</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-71">xrLine6</Name>
<Style_X_Font id="ref-72">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-11"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>2</Style_X_BorderWidth>
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
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>1900</y>
<width>1700</width>
<height>5</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a10:DashStyle" xmlns:a10="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>5</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-22" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-70"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-73">xrLine4</Name>
<Style_X_Font id="ref-74">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-11"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>2</Style_X_BorderWidth>
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
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>1730</y>
<width>1700</width>
<height>5</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a10:DashStyle" xmlns:a10="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>5</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-23" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName id="ref-75">DevExpress.XtraReports.UI.XRLabel</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-76">xrLabel3</Name>
<Style_X_Font id="ref-77">Arial, 11.25pt, style=Bold, Italic</Style_X_Font>
<Style_X_ForeColor id="ref-78">Black</Style_X_ForeColor>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>1680</y>
<width>579</width>
<height>50</height>
</Bounds>
<Text id="ref-79">Rechtsmittelbelehrung</Text>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
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
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-70"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-80">xrLine5</Name>
<Style_X_Font id="ref-81">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-11"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>2</Style_X_BorderWidth>
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
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>1290</y>
<width>1700</width>
<height>5</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a10:DashStyle" xmlns:a10="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>5</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-25" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-70"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-82">xrLine3</Name>
<Style_X_Font id="ref-83">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-11"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>2</Style_X_BorderWidth>
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
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>790</y>
<width>1700</width>
<height>5</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a10:DashStyle" xmlns:a10="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>5</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-26" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-70"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-84">xrLine2</Name>
<Style_X_Font id="ref-85">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-11"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>2</Style_X_BorderWidth>
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
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>440</y>
<width>1700</width>
<height>5</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a10:DashStyle" xmlns:a10="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>5</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-27" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName id="ref-86">DevExpress.XtraReports.UI.XRPageBreak</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-87">xrPageBreak1</Name>
<Style_X_Font id="ref-88">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-11"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>1913</y>
<width>79</width>
<height>5</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-28" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName id="ref-89">DevExpress.XtraReports.UI.XRPanel</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-90">xrPanel1</Name>
<Style_X_Font id="ref-91">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-11"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>true</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>850</x>
<y>1350</y>
<width>852</width>
<height>42</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<ItemCount>1</ItemCount>
<Item0 href="#ref-92"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-29" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-75"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-93">xrLabel2</Name>
<Style_X_Font id="ref-94">Arial, 11.25pt, style=Bold, Italic</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>1240</y>
<width>579</width>
<height>50</height>
</Bounds>
<Text id="ref-95">Empfangsbestätigung</Text>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
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
<a1:ObjectStorage id="ref-30" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName id="ref-96">DevExpress.XtraReports.UI.XRRichTextBox</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-97">rtfRechsmittel</Name>
<Style_X_Font id="ref-98">Arial, 9pt</Style_X_Font>
<Style_X_ForeColor href="#ref-11"/>
<Style_X_BackColor id="ref-99">White</Style_X_BackColor>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">All</Style_X_Borders>
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
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>true</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>1740</y>
<width>1700</width>
<height>150</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Rtf id="ref-100">{\rtf1\ansi\ansicpg1252\deff0\deflang2055\deflangfe2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\nowidctlpar\fs18 Gegen diese Verf\&#39;fcgung kann innert 30 Tagen seit der Er\&#39;f6ffnung beim zust\&#39;e4ndigen Regierungsstatthalteramt II, Amtshaus, Hodlerstr. 7, 3001 Bern, Verwaltungsbeschwerde gef\&#39;fchrt werden. Die Beschwerde ist im Doppel einzureichen, muss einen Antrag, die Angaben von Tatsachen, eine Begr\&#39;fcndung sowie eine Unterschrift enthalten. \par
\par
}
&#0;</Rtf>
<Multiline>true</Multiline>
<DetectUrls>true</DetectUrls>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-31" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-75"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-101">xrLabel1</Name>
<Style_X_Font id="ref-102">Arial Narrow, 9pt</Style_X_Font>
<Style_X_ForeColor href="#ref-11"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-103">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-104">BemerkungRTF</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-8"/>
<BindingItem0_X_DataSource href="#ref-13"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>1130</y>
<width>1700</width>
<height>50</height>
</Bounds>
<Text href="#ref-101"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
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
<a1:ObjectStorage id="ref-32" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-70"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-105">xrLine1</Name>
<Style_X_Font id="ref-106">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>845</x>
<y>590</y>
<width>5</width>
<height>50</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Vertical</LineDirection>
<LineStyle xsi:type="a10:DashStyle" xmlns:a10="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>2</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-33" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName id="ref-107">DevExpress.XtraReports.UI.Subreport</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-108">ShFinanzplanverfuegung_EinAus</Name>
<Style_X_Font id="ref-109">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-11"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>505</y>
<width>74</width>
<height>85</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-34" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-107"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-110">ShFinanzplanverfuegung_Personen</Name>
<Style_X_Font id="ref-111">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-11"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>260</y>
<width>74</width>
<height>85</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-35" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-75"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-112">txtFehlbetrag</Name>
<Style_X_Font id="ref-113">Arial, 9.75pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>254</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-114">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-115">Fehlbetrag</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-116">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-13"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>1460</x>
<y>645</y>
<width>240</width>
<height>45</height>
</Bounds>
<Text id="ref-117">Fehlbetrag</Text>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-118">{0:#,##0.00}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-36" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-75"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-119">Label25</Name>
<Style_X_Font id="ref-120">Arial, 9.75pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>850</x>
<y>645</y>
<width>600</width>
<height>45</height>
</Bounds>
<Text id="ref-121">Fehlbetrag</Text>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
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
<a1:ObjectStorage id="ref-37" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-75"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-122">Label24</Name>
<Style_X_Font id="ref-123">Arial, 9.75pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>850</x>
<y>595</y>
<width>610</width>
<height>45</height>
</Bounds>
<Text id="ref-124">Total Ausgaben</Text>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
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
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-75"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-125">Label23</Name>
<Style_X_Font id="ref-126">Arial, 9.75pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>595</y>
<width>600</width>
<height>45</height>
</Bounds>
<Text id="ref-127">Total Einnahmen</Text>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
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
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-75"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-128">txtTotOut</Name>
<Style_X_Font id="ref-129">Arial, 9.75pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>254</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-130">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-131">TotOut</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-132">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-13"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>1460</x>
<y>595</y>
<width>240</width>
<height>45</height>
</Bounds>
<Text id="ref-133">TotOut</Text>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-134">{0:#,##0.00}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-40" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-75"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-135">txtTotIn</Name>
<Style_X_Font id="ref-136">Arial, 9.75pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>254</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-137">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-138">TotIn</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-139">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-13"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>600</x>
<y>595</y>
<width>240</width>
<height>45</height>
</Bounds>
<Text id="ref-140">TotIn</Text>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-141">{0:#,##0.00}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-41" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-70"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-142">Line13</Name>
<Style_X_Font id="ref-143">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>640</y>
<width>1700</width>
<height>5</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a10:DashStyle" xmlns:a10="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>3</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-42" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-70"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-144">Line12</Name>
<Style_X_Font id="ref-145">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>590</y>
<width>1700</width>
<height>5</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a10:DashStyle" xmlns:a10="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>3</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-43" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-70"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-146">Line11</Name>
<Style_X_Font id="ref-147">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>845</x>
<y>440</y>
<width>5</width>
<height>60</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Vertical</LineDirection>
<LineStyle xsi:type="a10:DashStyle" xmlns:a10="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>2</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-44" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-70"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-148">Line10</Name>
<Style_X_Font id="ref-149">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>500</y>
<width>1700</width>
<height>5</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a10:DashStyle" xmlns:a10="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>1</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-45" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-75"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-150">Label12</Name>
<Style_X_Font id="ref-151">Arial, 9.75pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>850</x>
<y>450</y>
<width>610</width>
<height>45</height>
</Bounds>
<Text id="ref-152">Ausgaben</Text>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
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
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-75"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-153">Label11</Name>
<Style_X_Font id="ref-154">Arial, 9.75pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>450</y>
<width>600</width>
<height>45</height>
</Bounds>
<Text id="ref-155">Einnahmen</Text>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
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
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-70"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-156">Line8</Name>
<Style_X_Font id="ref-157">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>2</Style_X_BorderWidth>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>1190</y>
<width>1700</width>
<height>5</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a10:DashStyle" xmlns:a10="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>5</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-48" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-70"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-158">Line7</Name>
<Style_X_Font id="ref-159">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>2</Style_X_BorderWidth>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>1120</y>
<width>1700</width>
<height>5</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a10:DashStyle" xmlns:a10="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>5</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-49" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-70"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-160">Line6</Name>
<Style_X_Font id="ref-161">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>690</y>
<width>1700</width>
<height>5</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a10:DashStyle" xmlns:a10="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>3</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-50" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-70"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-162">Line4</Name>
<Style_X_Font id="ref-163">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>850</x>
<y>1600</y>
<width>800</width>
<height>5</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a10:DashStyle" xmlns:a10="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Dot</LineStyle>
<LineWidth>3</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-51" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-75"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-164">Label9</Name>
<Style_X_Font id="ref-165">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>1605</y>
<width>620</width>
<height>45</height>
</Bounds>
<Text id="ref-166">Unterschrift</Text>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
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
<a1:ObjectStorage id="ref-52" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-70"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-167">Line2</Name>
<Style_X_Font id="ref-168">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>1600</y>
<width>800</width>
<height>5</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a10:DashStyle" xmlns:a10="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Dot</LineStyle>
<LineWidth>3</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-53" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-75"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-169">Label7</Name>
<Style_X_Font id="ref-170">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>850</x>
<y>1605</y>
<width>620</width>
<height>45</height>
</Bounds>
<Text id="ref-171">Für die Sozialen Dienste</Text>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
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
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-70"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-172">Line1</Name>
<Style_X_Font id="ref-173">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>1400</y>
<width>800</width>
<height>5</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a10:DashStyle" xmlns:a10="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Dot</LineStyle>
<LineWidth>3</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-55" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-75"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-174">Label6</Name>
<Style_X_Font id="ref-175">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>3</x>
<y>1400</y>
<width>800</width>
<height>45</height>
</Bounds>
<Text id="ref-176">Ort und Datum</Text>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
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
<a1:ObjectStorage id="ref-56" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-75"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-177">Label4</Name>
<Style_X_Font id="ref-178">Arial, 11.25pt, style=Bold, Italic</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>1070</y>
<width>400</width>
<height>50</height>
</Bounds>
<Text id="ref-179">Bemerkungen</Text>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
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
<a1:ObjectStorage id="ref-57" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-75"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-180">Label3</Name>
<Style_X_Font id="ref-181">Arial, 11.25pt, style=Bold, Italic</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>740</y>
<width>400</width>
<height>50</height>
</Bounds>
<Text id="ref-182">Hinweis</Text>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
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
<a1:ObjectStorage id="ref-58" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-75"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-183">Label2</Name>
<Style_X_Font id="ref-184">Arial, 11.25pt, style=Bold, Italic</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>390</y>
<width>500</width>
<height>50</height>
</Bounds>
<Text id="ref-185">Budgetübersicht</Text>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
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
<a1:ObjectStorage id="ref-59" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-75"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-186">txtTitle</Name>
<Style_X_Font id="ref-187">Arial, 12pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor id="ref-188">Silver</Style_X_BackColor>
<Style_X_BorderColor href="#ref-11"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">MiddleLeft</Style_X_TextAlignment>
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
<Dpi>254</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-189">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-190">Title</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-8"/>
<BindingItem0_X_DataSource href="#ref-13"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>180</y>
<width>1700</width>
<height>60</height>
</Bounds>
<Text id="ref-191">Title</Text>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
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
<a1:ObjectStorage id="ref-60" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-96"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-192">rtfHinweis</Name>
<Style_X_Font id="ref-193">Arial Narrow, 9pt</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-99"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>800</y>
<width>1700</width>
<height>220</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Rtf id="ref-194">{\rtf1\ansi\ansicpg1252\deff0\deflang1031\deflangfe1031\deftab708{\fonttbl{\f0\fnil\fcharset0 Arial Narrow;}}
\viewkind4\uc1\pard\lang1033\f0\fs18 Das Budget ist nach Richtlinien der SKOS berechnet. Es gilt als Rahmenbudget. Einnahmen und Ausgaben k\&#39;f6nnen monatlich \&#39;e4ndern. Bewilligte Situationsbedingte Leistungen werden nach tats\&#39;e4chlichen Aufw\&#39;e4nden \&#39;fcbernommen. \par
Die Bez\&#39;fcgerinnen und Bez\&#39;fcger sind verpflichtet, \&#39;c4nderungen der finanziellen Situation umgehend dem Sozialdienst zu melden. Eine Verheimlichung oder die Angabe falscher Tatsachen kann eine sofortige R\&#39;fcckzahlungspflicht ausl\&#39;f6sen und strafrechtliche Folgen nach sich ziehen. \par
Sozialhilfeleistungen sind r\&#39;fcckerstattungspflichtig.\par
}
&#0;</Rtf>
<Multiline>true</Multiline>
<DetectUrls>true</DetectUrls>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-64" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-75"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-195">xrLabel4</Name>
<Style_X_Font id="ref-196">Arial, 11.25pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-11"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>420</y>
<width>424</width>
<height>50</height>
</Bounds>
<Text id="ref-197">Einschreiben</Text>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
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
<a1:ObjectStorage id="ref-65" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName href="#ref-75"/>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-198">txtAnrede</Name>
<Style_X_Font id="ref-199">Arial, 11pt</Style_X_Font>
<Style_X_ForeColor href="#ref-78"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-200">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-201">Adresse</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-8"/>
<BindingItem0_X_DataSource href="#ref-13"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>500</y>
<width>910</width>
<height>233</height>
</Bounds>
<Text id="ref-202">Anrede</Text>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>false</CanGrow>
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
<a9:Metafile id="ref-69" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Imaging/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<Data href="#ref-203"/>
</a9:Metafile>
<a1:ObjectStorage id="ref-92" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-16"/>
<Type_X_TypeName id="ref-204">DevExpress.XtraReports.UI.XRPageInfo</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-8"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-205">xrPageInfo1</Name>
<Style_X_Font id="ref-206">Arial, 9pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-11"/>
<Style_X_BackColor href="#ref-12"/>
<Style_X_BorderColor href="#ref-11"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>318</width>
<height>50</height>
</Bounds>
<Text href="#ref-8"/>
<NavigateUrl href="#ref-8"/>
<Target href="#ref-8"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<PageInfo xsi:type="a3:PageInfo" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">DateTime</PageInfo>
<Format id="ref-207">Wohlen, {0}</Format>
<StartPageNumber>1</StartPageNumber>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<SOAP-ENC:Array id="ref-203" xsi:type="SOAP-ENC:base64">iVBORw0KGgoAAAANSUhEUgAAD9kAAAEmCAYAAAB89cHIAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAzStJREFUeF7t3QtyazmOINDZ/6pyZz3Wy1an0mkJAAnyUvJxREVMzAXxOaQkP7dY9f/+nx8CBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAIGDBP7nq5d3/s9BlD+08j9+CBAgQIAAAQIECBAgQIAAAQIECBAgkBA4+y+duiNAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIfIzAO1+uv/d+9mYkvjsrhAABAgQIECBAgAABAgQIECBAgAABArc/ePohQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBBYL/Dnovpff/31dv+59f2//1mvNFPBd4MJECBAgAABAgQIECBAgAABAgQIECCQEZj5O6S1BAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECaQGX7NNUg4GZL8+KIUCAAAECBAgQIECAAAECBAgQIECAwOCfIC0jQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBCoCbhkX/OqR/tqMAECBAgQIECAAAECBAgQIECAAAECBDIC9b8+WkGAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIDAg4JL9AFppSebLs2IIECBAgAABAgQIECBAgAABAgQIECBQ+sOjYAIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAgVEBl+xH5bLrfDWYAAECBAgQIECAAAECBAgQIECAAAECGYHs3xzFESBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQITAm4ZD/Fl1ic+fKsGAIECBAgQIAAAQIECBAgQIAAAQIECCT+3CiEAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIEBgXsAl+3nD1xl8NZgAAQIECBAgQIAAAQIECBAgQIAAAQIZgdV/q5SfAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIEDgj4BL9qsPQubLs2IIECBAgAABAgQI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5ILdq/k7e670Vpltdv8qfX2PXVV7Ju/Mns2sHTlHP/2XO1T2fvR1PzJndk3lPM3s823tiT2NnoPIbZdVpU7U8+j5zPSQ3ftMrnvMipyV+lFsxbvyPhLVXemzwrzi9NN78Iqenhm7ZJ89faNxv/ULweYmQIAAAQIECBAgQIAAAQIECBAgQKAmMPo3SOsIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgcKRJfsrmx55cXT2bkit+yl8Nk+rP9ZINqflW7Vi6c7zvmJPWX3INrLd3utfdo82X28Im7Ha+uKuVbUPN3KJfsVu/6Ys/Y1WtEECBAgQIAAAQIECBAgQIAAAQIECPxWgdV/q5SfAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAIG3FaheaN8x6Ik97ZhbDQIEPkPAJfvV+/hbvxBsbgIECBAgQIAAAQIECBAgQIAAAQIEagKr/1YpPwECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECbytw4oX2E3t62w3WOAEC2wVcsl9NXvsarWgCBAgQIECAAAECBAgQIECAAAECBH6rwOq/VcpPgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgMDbCpx4of3Ent52gzVOgMB2AZfsV5P/1i8Em5sAAQIECBAgQIAAAQIECBAgQIAAgZrA6r9Vyk+AAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAwNsKnHih/cSe3naDNU6AwHYBl+y3kytIgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIEMgLnHih/cSe8qIiCRD47QIu2f/2E2B+AgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBA4GiBEy+0n9jT0ZuoOQIEjhJwyf6o7dAMAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQODfAideaD+xJ+eGAAECWQGX7LNS4ggQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECFwiceKH9xJ4u2BolCRB4UwGX7N9047RNgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQI/A6BEy+0n9jT7zgNpiRAoEPAJfsORTkIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAosETrzQfmJPi/ilJUDgAwVcsv/ATTUSAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAg8DkCJ15oP7Gnz9lxkxAgsFrAJfvVwvITIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIEDgQoFnX3S9//9f2NrlpdlcvgV/Goj2YfXzExSiGU/oUQ8EVgt4HTwXZrP69MlPgACBvQLe1/d6q0aAAIFPEjjxQvuJPX3SnpuFAIG1Ai7Zr/WVnQABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABApcKuMDxnJ/NpUfz/4pH+3DF890y0Yy7+1GPwBUCXgc+r644d2oSIEDgCgGfeVeoq0mAAAECBAgQIEDgvwIu2TsVBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQ+GABFzieby6bMw5+tA9XPt8lFM24qw91CFQF7me3uu6neK8Dn1cz56jzLM70YS0BAgQyAj7zMkpiCBAgQIAAAQIECKwXcMl+vbEKBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQuEzABY7n9GwuO5b/KhztwwnPV0tFM66uLz+BqsD3M1td/1O814HPq5FztOIsjvRhDQECBCoCPvMqWmIJECBAgAABAgQIrBNwyX6drcwECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBC4XMAFjudbwOby4/mngWgfTnq+SiyacVVdeQmMCPx0XkfyfF/jdeDzqnqOVp3Fah/iCRAgUBXwmVcVE0+AAAECBAgQIEBgjYBL9mtcZSVAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgMARAi5wPN8GNkcc0be6ZH87Myt+nMUVqnJ2C7w6px21vA58XmXP0eqzmO1DHAECBEYFfOaNyllHgAABAgQIECBAoFfAJfteT9kIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBwlIALHM+3g80ZRzXahxOfd8tFM3bXk49AVWDHGd1Rozr3KfFs/tkJFqecSn0QIDAj4L1sRs9aAgQIECBAgAABAn0CLtn3WcpEgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgACB4wRc4Hi+JWzOOK7RPpz6vFMvmrGzllwERgR2nNEdNUZmP2ENm392gcUJJ1IPBAjMCngvmxW0ngABAgQIECBAgECPgEv2PY6yECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgMCbCbjccsaGRftwe77qJ1P7VcyqvuQlcJpA9Frp6HdHjY4+5bhWwDm51l91AgQIECBAgAABAgQIECDwSQIu2X/SbpqFAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBNICLuqlqZYGRvuw8pL998EyvXyPWYojOYFDBKLXRkebO2p09CnHtQLOybX+qhMgQIAAAQIECBAgQIAAgU8ScMn+k3bTLAQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECCQFnBRL021NDDah52X7O+DZnp6jFkKJDmBAwSi10RHiztqdPQpx7UCzsm1/qoTIECAAAECBAgQIECAAIFPEnDJ/pN20ywECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgkBZwUS9NtTQw2ocrLtnfBs705aL90qMh+UEC0euho9UdNTr6lONaAefkWn/VCRAgQIAAAQIECBAgQIDAJwm4ZP9Ju2kWAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIEEgLuKiXploaGO3DVZfsb0NnervHLEWSnMDFAtFroaO9HTU6+pTjWgHn5Fp/1QkQIECAAAECBAgQIECAwCcJuGT/SbtpFgIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBBIC7iol6Za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gAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECDw3gJXXnKPat+e+yFAgAABAgQIECBwqsDj77OdPbpg36kp19UCLtlfvQPqEyBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAv8RuPKi+5W1HQUCBAgQIECAAAECswKrLsOvyjs7r/UERgRcsh9Rs4YAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBBYKnDVRfer6i7FlJwAAQIECBAgQOBXCbz6nXYUYkXO0V6sI9Ah4JJ9h6IcBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAQLvA7gvvmXq3GD8ECBAgQIAAAQIEThbovhDfne9kO739HgGX7H/PXpuUAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAi8lUD20vvsxfdddd4KX7MECBAgQIAAAQJvLZD5HTcasCNHVMNzAlcJuGR/lby6BAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAwEuBzKWen2IyrCtzZ+qLIUCAAAECBAgQILBSYPT33cq6lf3LTWC1gEv2q4XlJ0CAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBIYFKpd8VscOD2EhAQIECBAgQIAAgQsEVv5+fME4ShJoFXDJvpVTMgIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQKBbYOXloGzu7pnkI0CAAAECBAgQILBDIPv7biVuR99qEFgt4JL9amH5CRAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAgSmByoWfFbFTzVtMgAABAgQIECBA4GKBzt+RLx5FeQJtAi7Zt1FKRIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECKwU6LwclM21ch65CRAgQIAAAQIECOwUyP4O/FPczj7VIrBDwCX7HcpqECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAi0CMxeDqmtbGpaEAAECBAgQIECAwIECmd+ND2xbSwTaBFyyb6OUiAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIENglkLkUNBqzawZ1CBAgQIAAAQIECBAgQOAaAZfsr3FXlQABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIEGgQGL1I/9O6hnakIECAAAECBAgQIECAAIE3EHDJ/g02SYsECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIBALFC9cB9nFEGAAAECBAgQIECAAAECnyjgkv0n7qqZCBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQOBHAZfsHQwCBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQ+DUCLtn/mq02KAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAi4ZO8MECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgMCvEXDJ/tdstUEJECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAwCV7Z4AAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIEfo2AS/a/ZqsNSoAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIu2TsDBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIPBrBFyy/zVbbVACBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQcMneGSBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgACBXyPgkv2v2WqDEiBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgIBL9s4AAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECPwaAZfsf81WG5QAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIEXLJ3BggQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIEDg1wi4ZP9rttqgBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIOCSvTNAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAr9GwCX7X7PVBiVAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABl+ydAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBD4NQIu2f+arTYoAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECLhk7wwQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAwK8RcMn+12y1QQkQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIEDAJXtngAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBwsMCfL3f4DwNnwBlwBpwBZ8AZcAacAWfAGXAGnAFnwBlwBpwBZ8AZcAacAWfAGXAGnAFnwBlwBpyBhzNw8P+ZW2sECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAgTEBF+v9lws4A86AM+AMOAPOgDPgDDgDzoAz4Aw4A86AM+AMOAPOgDPgDDgDzoAz4Aw4A86AM+AMZM7A2P9V2ioCBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAwEECmS9JiPFlGmfAGXAGnAFnwBlwBpwBZ8AZcAacAWfAGXAGnAFnwBlwBpwBZ8AZcAacAWfAGXAGnIHbGfBDgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIEHh7AV+E8UUYZ8AZcAacAWfAGXAGnAFnwBlwBpwBZ8AZcAacAWfAGXAGnAFnwBlwBpwBZ8AZcAacgcoZePv/Q7kBCBAgQIAAAQIECBAgQIAAAQIECBAgQIAAAQIECBAgQIAAgd8rUPmShFhfqnEGnAFnwBlwBpwBZ8AZcAacAWfAGXAGnAFnwBlwBpwBZ8AZcAacAWfAGXAGnAFnwBm4nQE/BAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAIG3FvAlGF+CcQacAWfAGXAGnAFnwBlwBpwBZ8AZcAacAWfAGXAGnAFnwBlwBpwBZ8AZcAacAWfAGaicgbf+P5JrngABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBQ+aKEWF+scQacAWfAGXAGnAFnwBlwBpwBZ8AZcAacAWfAGXAGnAFnwBlwBpwBZ8AZcAacAWfgd58B/1d2AgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgMDbC/gCzO/+Aoz9t//OgDPgDDgDzoAz4Aw4A86AM+AMOAPOgDPgDDgDzoAz4Aw4A86AM+AMOAPOgDNQOQNv/38kNwABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBA4CZQ+cKEWF7OgDPgDDgDzoAz4Aw4A86AM+AMOAPOgDPgDDgDzoAz4Aw4A86AM+AMOAPOgDPgDPzeM+D/yk6AAAECBAgQIECAAAECBAgQIECAAAECBAgQIECAAAECBAgQ+CgBX4T5vV+Esff23hlwBpwBZ8AZcAacAWfAGXAGnAFnwBlwBpwBZ8AZcAacAWfAGXAGnAFnwBlwBp6dgY/6P4wbhgABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIECBAgAABAgQIjAj8f4GfML4q09TZAAAAAElFTkSuQmCC</SOAP-ENC:Array>
</SOAP-ENV:Body>
</SOAP-ENV:Envelope>' ,  N'<?xml version="1.0" standalone="yes" ?>
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
</NewDataSet>' ,  N'DECLARE @BgBudgetID  int,
        @GetDate     datetime
SELECT @BgBudgetID = BgBudgetID, @GetDate = GetDate()
FROM BgBudget
WHERE BgFinanzPlanID = {BgFinanzPlanID} AND MasterBudget = 1


DECLARE @TotIn money
DECLARE @TotOut money

SELECT @TotIn = SUM(Betrag)
FROM dbo.fnWhGetFinanzplan(@BgBudgetID, @GetDate)  TMP
  INNER JOIN XLOVCode  XPC ON XPC.LOVName = ''BgKategorie'' AND XPC.Code = TMP.BgKategorieCode
WHERE BgKategorieCode = 1

SELECT @TotOut = SUM(CASE WHEN BgKategorieCode = 2 THEN TMP.Betrag ELSE -TMP.Betrag END)
FROM dbo.fnWhGetFinanzplan(@BgBudgetID, @GetDate)  TMP
  INNER JOIN XLOVCode  XPC ON XPC.LOVName = ''BgKategorie'' AND XPC.Code = TMP.BgKategorieCode
WHERE BgKategorieCode IN (2, 4)



DECLARE @BemerkungRTF varchar(8000),
        @ItemText     varchar(8000)

DECLARE cBemerkungRTF CURSOR FAST_FORWARD FOR
  SELECT ''- '' + XLC.Text + '' ('' + PRS.NameVorname + ''): '' + Convert(varchar(2000), BPO.Bemerkung)
  FROM BgPosition             BPO
    INNER JOIN vwPerson      PRS ON PRS.BaPersonID = BPO.BaPersonID
    INNER JOIN BgPositionsart  SPT ON SPT.BgPositionsartID = BPO.BgPositionsartID
    INNER JOIN XLOVCode       XLC ON XLC.LOVName = ''BgGruppe'' AND XLC.Code = SPT.BgGruppeCode
  WHERE BPO.BgBudgetID = @BgBudgetID
    AND BPO.BgPositionsartID BETWEEN 39000 AND 39999
    AND NOT (BPO.Bemerkung IS NULL OR Convert(varchar, BPO.Bemerkung) = '''')
    AND GetDate() BETWEEN IsNull(BPO.DatumVon, ''19000101'') AND IsNull(BPO.DatumBis, GetDate())
  ORDER BY PRS.NameVorname

OPEN cBemerkungRTF
WHILE (1 = 1) BEGIN
  FETCH NEXT FROM cBemerkungRTF INTO @ItemText
  IF @@FETCH_STATUS != 0 BREAK

  SET @BemerkungRTF = IsNull(@BemerkungRTF + char(10) + char(13), '''') + @ItemText
END
CLOSE cBemerkungRTF
DEALLOCATE cBemerkungRTF



SELECT BBG.BgBudgetID,
       Title        = ''Verfügung vom '' + IsNull(CONVERT(varchar, (SELECT MAX(Datum) FROM BgBewilligung BBW
                                                                  WHERE BBW.BgFinanzPlanID=SFP.BgFinanzPlanID AND BBW.BgBewilligungCode = 2), 104), ''???'') +
                      '': Sozialhilfe vom '' + CONVERT(varchar, SFP.DatumVon, 104) + '' bis '' + CONVERT(varchar, SFP.DatumBis, 104),
       Adresse      = IsNull(CASE PRS.GeschlechtCode WHEN 1 THEN ''Herr'' WHEN 2 THEN ''Frau'' END + char(13) + char(10),'''') +
                      PRS.NameVorname + char(13) + char(10) +
                      PRS.WohnsitzStrasseHausNr + char(13) + char(10) +
                      PRS.WohnsitzPLZOrt,
       BemerkungRTF = IsNull(CONVERT(varchar(8000), SFP.Bemerkung) + char(10) + char(13), '''') + IsNull(@BemerkungRTF, ''''),
       TotIn        = IsNull(@TotIn, $0.00),
       TotOut       = IsNull(@TotOut, $0.00),
       Fehlbetrag   = IsNull(@TotOut, $0.00) - IsNull(@TotIn, $0.00)
FROM   BgBudget BBG
       INNER JOIN BgFinanzPlan  SFP on SFP.BgFinanzPlanID = BBG.BgFinanzPlanID
       INNER JOIN FaLeistung    FAL on FAL.FaLeistungID = SFP.FaLeistungID
       INNER JOIN vwPerson      PRS on PRS.BaPersonID = FAL.BaPersonID
WHERE FAL.ModulID = 3 AND BBG.BgBudgetID = @BgBudgetID
--  AND SFP.BgBewilligungStatusCode in (5, 9) -- nur bewilligte' ,  N'WhFinanzplan,CtlBgUebersicht,WhMonatsbudget,WhMasterbudget' ,  null , 3)

INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShFinanzplanverfuegung_Personen' ,  N'Personen' , 1,  N'<!--
AssemblyName=DevExpress%2EXtraReports%2C%20Version%3D1%2E7%2E10%2E0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4
AssemblyLocation=c:\programme\born informatik ag\kiss30\devexpress.xtrareports.dll
TypeName=DevExpress.XtraReports.UI.XtraReport
Localization=de-DE
-->
<SOAP-ENV:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:SOAP-ENC="http://schemas.xmlsoap.org/soap/encoding/" xmlns:SOAP-ENV="http://schemas.xmlsoap.org/soap/envelope/" xmlns:clr="http://schemas.microsoft.com/soap/encoding/clr/1.0" SOAP-ENV:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
<SOAP-ENV:Body>
<a1:ReportStorage id="ref-1" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<BandCount>3</BandCount>
<Band0 href="#ref-6"/>
<Band1 href="#ref-7"/>
<Band2 href="#ref-8"/>
<Visible>true</Visible>
<Tag id="ref-9"></Tag>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-10">Report</Name>
<Style_X_Font id="ref-11">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor id="ref-12">ControlText</Style_X_ForeColor>
<Style_X_BackColor id="ref-13">Transparent</Style_X_BackColor>
<Style_X_BorderColor href="#ref-12"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>254</width>
<height>58</height>
</Bounds>
<Text href="#ref-9"/>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>254</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<DataSource id="ref-14">dataSource</DataSource>
<UseDefaultPrinterSettings>false</UseDefaultPrinterSettings>
<ReportUnit xsi:type="a2:ReportUnit" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TenthsOfAMillimeter</ReportUnit>
<Landscape>false</Landscape>
<PaperKind xsi:type="a5:PaperKind" xmlns:a5="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Printing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">A4</PaperKind>
<PaperName href="#ref-9"/>
<Margins xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>254</x>
<y>254</y>
<width>140</width>
<height>254</height>
</Margins>
<HtmlCompressed>false</HtmlCompressed>
<PageSize xsi:type="a4:Size" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<width>2101</width>
<height>2969</height>
</PageSize>
<StyleSheet_X_StyleCount>0</StyleSheet_X_StyleCount>
<ShowPreviewMarginLines>true</ShowPreviewMarginLines>
<ScriptLanguage xsi:type="a6:ScriptLanguage" xmlns:a6="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">CSharp</ScriptLanguage>
<Watermark_X_Text href="#ref-9"/>
<Watermark_X_Font id="ref-15">Verdana, 36pt</Watermark_X_Font>
<Watermark_X_ForeColor id="ref-16">Red</Watermark_X_ForeColor>
<Watermark_X_Transparency>50</Watermark_X_Transparency>
<Watermark_X_TextDirection xsi:type="a7:DirectionMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">ForwardDiagonal</Watermark_X_TextDirection>
<Watermark_X_Image xsi:type="xsd:anyType" xsi:null="1"/>
<Watermark_X_ImageAlign xsi:type="a4:ContentAlignment" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">MiddleCenter</Watermark_X_ImageAlign>
<Watermark_X_ImageViewMode xsi:type="a7:ImageViewMode" xmlns:a7="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting.Drawing/DevExpress.XtraPrinting%2C%20Version%3D1.9.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Clip</Watermark_X_ImageViewMode>
<Watermark_X_ImageTiling>false</Watermark_X_ImageTiling>
<Watermark_X_PageRange href="#ref-9"/>
<Watermark_X_ShowBehind>true</Watermark_X_ShowBehind>
<DefaultPrinterSettingsUsing_X_UseMargins>false</DefaultPrinterSettingsUsing_X_UseMargins>
<DefaultPrinterSettingsUsing_X_UsePaperKind>false</DefaultPrinterSettingsUsing_X_UsePaperKind>
<DefaultPrinterSettingsUsing_X_UseLandscape>false</DefaultPrinterSettingsUsing_X_UseLandscape>
<ShrinkSubReportIconArea>true</ShrinkSubReportIconArea>
</a1:ReportStorage>
<a1:ObjectStorage id="ref-6" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName id="ref-17">DevExpress.XtraReports, Version=1.7.10.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4</Type_X_AssemblyName>
<Type_X_TypeName id="ref-18">DevExpress.XtraReports.UI.DetailBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-19">Detail</Name>
<Style_X_Font id="ref-20">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-12"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>254</width>
<height>58</height>
</Bounds>
<Text href="#ref-9"/>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>50</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<PrintOnEmptyDataSource>true</PrintOnEmptyDataSource>
<MultiColumn_X_ColumnCount>1</MultiColumn_X_ColumnCount>
<MultiColumn_X_Direction xsi:type="a2:ColumnDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">DownThenAcross</MultiColumn_X_Direction>
<MultiColumn_X_ColumnWidth>0</MultiColumn_X_ColumnWidth>
<MultiColumn_X_ColumnSpacing>0</MultiColumn_X_ColumnSpacing>
<MultiColumn_X_Mode xsi:type="a2:MultiColumnMode" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">UseColumnCount</MultiColumn_X_Mode>
<RepeatCountOnEmptyDataSource>1</RepeatCountOnEmptyDataSource>
<ItemCount>4</ItemCount>
<Item0 href="#ref-21"/>
<Item1 href="#ref-22"/>
<Item2 href="#ref-23"/>
<Item3 href="#ref-24"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-7" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName id="ref-25">DevExpress.XtraReports.UI.ReportHeaderBand</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-26">ReportHeader</Name>
<Style_X_Font id="ref-27">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-12"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>254</width>
<height>58</height>
</Bounds>
<Text href="#ref-9"/>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>105</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<ItemCount>5</ItemCount>
<Item0 href="#ref-28"/>
<Item1 href="#ref-29"/>
<Item2 href="#ref-30"/>
<Item3 href="#ref-31"/>
<Item4 href="#ref-32"/>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-8" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName id="ref-33">DevExpress.XtraReports.UI.ReportFooterBand</Type_X_TypeName>
<Visible>false</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-34">ReportFooter</Name>
<Style_X_Font id="ref-35">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-12"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>254</width>
<height>58</height>
</Bounds>
<Text href="#ref-9"/>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>0</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<PrintAtBottom>false</PrintAtBottom>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-21" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName id="ref-36">DevExpress.XtraReports.UI.XRLine</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-37">xrLine2</Name>
<Style_X_Font id="ref-38">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-12"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>1700</width>
<height>5</height>
</Bounds>
<Text href="#ref-9"/>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>3</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-22" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName id="ref-39">DevExpress.XtraReports.UI.XRLabel</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-40">txtHeimatort</Name>
<Style_X_Font id="ref-41">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor id="ref-42">Black</Style_X_ForeColor>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>254</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-43">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-44">Nationalitaet</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-9"/>
<BindingItem0_X_DataSource href="#ref-14"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>1140</x>
<y>5</y>
<width>560</width>
<height>45</height>
</Bounds>
<Text id="ref-45">Heimatort</Text>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>true</CanShrink>
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
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-39"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-46">txtGebDat</Name>
<Style_X_Font id="ref-47">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-42"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopCenter</Style_X_TextAlignment>
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
<Dpi>254</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName href="#ref-43"/>
<BindingItem0_X_DataMember id="ref-48">Geburtsdatum</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-49">{0:dd.MM.yyyy}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-14"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>760</x>
<y>5</y>
<width>380</width>
<height>45</height>
</Bounds>
<Text id="ref-50">GebDat</Text>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>true</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_FormatString id="ref-51">{0:dd.MM.yyyy}</Summary_X_FormatString>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-24" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-39"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-52">txtName</Name>
<Style_X_Font id="ref-53">Arial, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-42"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
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
<Dpi>254</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName href="#ref-43"/>
<BindingItem0_X_DataMember id="ref-54">Name</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-9"/>
<BindingItem0_X_DataSource href="#ref-14"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>5</y>
<width>760</width>
<height>45</height>
</Bounds>
<Text id="ref-55">Name</Text>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>true</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Multiline>true</Multiline>
<Angle>0</Angle>
<Summary_X_Func xsi:type="a2:SummaryFunc" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Sum</Summary_X_Func>
<Summary_X_Running xsi:type="a2:SummaryRunning" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Summary_X_Running>
<Summary_X_IgnoreNullValues>false</Summary_X_IgnoreNullValues>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-28" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-39"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-56">xrLabel4</Name>
<Style_X_Font id="ref-57">Arial, 11.25pt, style=Bold, Italic</Style_X_Font>
<Style_X_ForeColor href="#ref-42"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>762</width>
<height>50</height>
</Bounds>
<Text id="ref-58">Unterstützte Personen</Text>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
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
<a1:ObjectStorage id="ref-29" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-36"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-59">xrLine1</Name>
<Style_X_Font id="ref-60">Times New Roman, 9.75pt</Style_X_Font>
<Style_X_ForeColor href="#ref-42"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopLeft</Style_X_TextAlignment>
<Style_X_BorderWidth>2</Style_X_BorderWidth>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>50</y>
<width>1700</width>
<height>5</height>
</Bounds>
<Text href="#ref-9"/>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>true</KeepTogether>
<LineDirection xsi:type="a2:LineDirection" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">Horizontal</LineDirection>
<LineStyle xsi:type="a9:DashStyle" xmlns:a9="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Drawing2D/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Solid</LineStyle>
<LineWidth>5</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-30" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-39"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-61">xrLabel3</Name>
<Style_X_Font id="ref-62">Arial, 9.75pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-42"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
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
<ParentStyleUsing_X_UseForeColor>false</ParentStyleUsing_X_UseForeColor>
<ParentStyleUsing_X_UseBackColor>false</ParentStyleUsing_X_UseBackColor>
<ParentStyleUsing_X_UseBorderColor>false</ParentStyleUsing_X_UseBorderColor>
<ParentStyleUsing_X_UseBorders>false</ParentStyleUsing_X_UseBorders>
<ParentStyleUsing_X_UseBorderWidth>false</ParentStyleUsing_X_UseBorderWidth>
<ParentStyleUsing_X_UseTextAlignment>false</ParentStyleUsing_X_UseTextAlignment>
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>1140</x>
<y>55</y>
<width>560</width>
<height>50</height>
</Bounds>
<Text id="ref-63">Nationalität</Text>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
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
<a1:ObjectStorage id="ref-31" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-39"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-64">xrLabel2</Name>
<Style_X_Font id="ref-65">Arial, 9.75pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-42"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
<Style_X_Borders xsi:type="a3:BorderSide" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Style_X_Borders>
<Style_X_TextAlignment xsi:type="a3:TextAlignment" xmlns:a3="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraPrinting/DevExpress.Utils%2C%20Version%3D2.2.0.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TopCenter</Style_X_TextAlignment>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>760</x>
<y>55</y>
<width>380</width>
<height>50</height>
</Bounds>
<Text id="ref-66">Geburtsdatum</Text>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
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
<a1:ObjectStorage id="ref-32" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-17"/>
<Type_X_TypeName href="#ref-39"/>
<Visible>true</Visible>
<Tag href="#ref-9"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-67">xrLabel1</Name>
<Style_X_Font id="ref-68">Arial, 9.75pt, style=Bold</Style_X_Font>
<Style_X_ForeColor href="#ref-42"/>
<Style_X_BackColor href="#ref-13"/>
<Style_X_BorderColor href="#ref-12"/>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>55</y>
<width>760</width>
<height>50</height>
</Bounds>
<Text id="ref-69">Name</Text>
<NavigateUrl href="#ref-9"/>
<Target href="#ref-9"/>
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
</SOAP-ENV:Body>
</SOAP-ENV:Envelope>' ,  null ,  N'SELECT
  Name              = PRS.NameVorname,
  PRS.Geburtsdatum,
  Nationalitaet     = PRS.Nationalitaet
FROM BgFinanzPlan_BaPerson   SPP
  INNER JOIN vwPerson        PRS ON PRS.BaPersonID = SPP.BaPersonID
WHERE SPP.BgFinanzPlanID = {BgFinanzPlanID}
AND SPP.IstUnterstuetzt = 1' ,  null ,  N'ShFinanzplanverfuegung' ,  null )

INSERT INTO XQuery(QueryName, UserText, QueryCode, LayoutXML, ParameterXML, SQLquery, ContextForms, ParentReportName, ReportSortKey)
VALUES ( N'ShFinanzplanverfuegung_EinAus' ,  N'Einnahmen, Ausgaben' , 1,  N'<!--
AssemblyName=DevExpress%2EXtraReports%2C%20Version%3D1%2E7%2E10%2E0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4
AssemblyLocation=c:\programme\born informatik ag\kiss30\devexpress.xtrareports.dll
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>254</width>
<height>58</height>
</Bounds>
<Text href="#ref-7"/>
<NavigateUrl href="#ref-7"/>
<Target href="#ref-7"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<Height>254</Height>
<PageBreak xsi:type="a2:PageBreak" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</PageBreak>
<DataSource id="ref-12">dataSource</DataSource>
<UseDefaultPrinterSettings>false</UseDefaultPrinterSettings>
<ReportUnit xsi:type="a2:ReportUnit" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">TenthsOfAMillimeter</ReportUnit>
<Landscape>false</Landscape>
<PaperKind xsi:type="a5:PaperKind" xmlns:a5="http://schemas.microsoft.com/clr/nsassem/System.Drawing.Printing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">Letter</PaperKind>
<PaperName href="#ref-7"/>
<Margins xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>254</x>
<y>254</y>
<width>204</width>
<height>254</height>
</Margins>
<HtmlCompressed>false</HtmlCompressed>
<PageSize xsi:type="a4:Size" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<width>2159</width>
<height>2794</height>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>0</y>
<width>254</width>
<height>58</height>
</Bounds>
<Text href="#ref-7"/>
<NavigateUrl href="#ref-7"/>
<Target href="#ref-7"/>
<CanGrow>true</CanGrow>
<CanShrink>false</CanShrink>
<WordWrap>true</WordWrap>
<KeepTogether>false</KeepTogether>
<EventsScript_X_OnBeforePrint id="ref-19">private void OnBeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e) {
  xrLine1.Height = Detail.Height;
}</EventsScript_X_OnBeforePrint>
<Height>50</Height>
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
<Dpi>254</Dpi>
<BindingItemCount>0</BindingItemCount>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>845</x>
<y>0</y>
<width>5</width>
<height>50</height>
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
<LineWidth>3</LineWidth>
<ItemCount>0</ItemCount>
</a1:ObjectStorage>
<a1:ObjectStorage id="ref-21" xmlns:a1="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.Serialization/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">
<Type_X_AssemblyName href="#ref-15"/>
<Type_X_TypeName id="ref-28">DevExpress.XtraReports.UI.XRLabel</Type_X_TypeName>
<Visible>true</Visible>
<Tag href="#ref-7"/>
<Dock xsi:type="a2:XRDockStyle" xmlns:a2="http://schemas.microsoft.com/clr/nsassem/DevExpress.XtraReports.UI/DevExpress.XtraReports%2C%20Version%3D1.7.10.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3D79868b8147b5eae4">None</Dock>
<Name id="ref-29">xrLabel4</Name>
<Style_X_Font id="ref-30">Arial, 9pt</Style_X_Font>
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
<Dpi>254</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-31">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-32">BetragAus</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-33">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-12"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>1460</x>
<y>5</y>
<width>240</width>
<height>45</height>
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
<Style_X_Font id="ref-36">Arial, 9pt</Style_X_Font>
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
<Dpi>254</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-37">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-38">TextAus</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-7"/>
<BindingItem0_X_DataSource href="#ref-12"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>850</x>
<y>5</y>
<width>610</width>
<height>45</height>
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
<Style_X_Font id="ref-41">Arial, 9pt</Style_X_Font>
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
<Dpi>254</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName id="ref-42">Text</BindingItem0_X_PropertyName>
<BindingItem0_X_DataMember id="ref-43">BetragEin</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString id="ref-44">{0:n2}</BindingItem0_X_FormatString>
<BindingItem0_X_DataSource href="#ref-12"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>600</x>
<y>5</y>
<width>240</width>
<height>45</height>
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
<Style_X_Font id="ref-46">Arial, 9pt</Style_X_Font>
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
<Dpi>254</Dpi>
<BindingItemCount>1</BindingItemCount>
<BindingItem0_X_PropertyName href="#ref-42"/>
<BindingItem0_X_DataMember id="ref-47">TextEin</BindingItem0_X_DataMember>
<BindingItem0_X_FormatString href="#ref-7"/>
<BindingItem0_X_DataSource href="#ref-12"/>
<Bounds xsi:type="a4:Rectangle" xmlns:a4="http://schemas.microsoft.com/clr/nsassem/System.Drawing/System.Drawing%2C%20Version%3D1.0.5000.0%2C%20Culture%3Dneutral%2C%20PublicKeyToken%3Db03f5f7f11d50a3a">
<x>0</x>
<y>5</y>
<width>600</width>
<height>45</height>
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
  FROM dbo.fnWhGetFinanzplan(@BgBudgetID, @GetDate)  TMP
    INNER JOIN XLOVCode     XPC ON XPC.LOVName = ''BgKategorie''    AND XPC.Code = TMP.BgKategorieCode
  WHERE BgKategorieCode = 1
    AND (TMP.Betrag != $0.00 OR (BgKategorieCode = 1 AND BgGruppeCode LIKE ''[0-9]%''))

-- Ausgaben / Kürzungen
INSERT INTO @Ausgaben (Text, Betrag)
  SELECT
    CASE
      WHEN TMP.Bezeichnung LIKE ''Med. Grund%(KVG)'' THEN ''KVG Prämien''
      WHEN TMP.Bezeichnung LIKE ''Med. Grund%(VVG)'' THEN ''VVG Prämien''
      ELSE TMP.Bezeichnung
    END,
    CASE
      WHEN BgKategorieCode = 2 THEN TMP.Betrag
      ELSE -TMP.Betrag
    END
  FROM dbo.fnWhGetFinanzplan(@BgBudgetID, @GetDate)  TMP
    INNER JOIN XLOVCode     XPC ON XPC.LOVName = ''BgKategorie''    AND XPC.Code = TMP.BgKategorieCode
  WHERE BgKategorieCode IN (2, 4) -- Ausgaben / Kürzungen
    AND (TMP.Betrag != $0.00 OR (BgKategorieCode = 2 AND BgGruppeCode LIKE ''[0-9]%''))

SELECT
  TextEin = EIN.Text, BetragEin = EIN.Betrag,
  TextAus = AUS.Text, BetragAus = AUS.Betrag
FROM @Einnahmen         EIN
  FULL  JOIN @Ausgaben  AUS ON AUS.id = EIN.id' ,  null ,  N'ShFinanzplanverfuegung' ,  null )

