SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XClass]
GO
SET IDENTITY_INSERT [XClass] ON
GO
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (1, N'CtlAbaKlientenStammdaten', NULL, 14, N'Klientenstammdaten Schnittstelle', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1386, 753</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'KlientenStammdaten')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (2, N'CtlAbaLeistungsdaten', NULL, 14, N'Leistungsdaten Schnittstelle', N'KiSS4.Abacus.CtlAbaASCIIBase', NULL, NULL, N'<Object xsi:type="KiSS4.Alpi.CtlAbaASCIIBase" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryNichtVisiertVerbucht" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlAbaLeistungsdaten</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">800, 600</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'ASCII')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (3, N'CtlAbaLogView', NULL, 14, N'Logbuch Schnittstellen', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryXAbaLog" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlAbaLogView</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (4, N'CtlAbaMitarbeiter', NULL, 14, N'Mitarbeiter Schnittstelle', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">860, 561</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'Mitarbeiter')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (5, N'CtlAbaStundenlohn', NULL, 14, N'Stundenlohn Schnittstelle', N'KiSS4.Abacus.CtlAbaASCIIBase', NULL, NULL, N'<Object xsi:type="KiSS4.Alpi.CtlAbaASCIIBase" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryNichtVisiert" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlAbaStundenlohn</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">800, 600</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'ASCII')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (6, N'CtlAdBeziehungen', NULL, 10, N'Beziehungen ML', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBeziehungen" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlAdBeziehungen</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">777, 544</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (7, N'CtlAdEinsatzRegionVerwaltung', NULL, 10, N'Verwaltung Einsatzregionen ED', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">792, 569</Property>
  <Property name="Name" xsi:type="System.String">CtlAdEinsatzRegionVerwaltung</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryEdEinsatzRegion" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (8, N'CtlAdInstitutionsTypen', NULL, 10, N'Institutionstypen verwalten', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (9, N'CtlAdKantonaleZuschuesse', NULL, 10, N'Kantonale Zuschüsse verwalten', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBaKantonalerZuschuss" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlAdKantonaleZuschuesse</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">792, 569</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (10, N'CtlAdKursverwaltung', NULL, 10, N'Kursverwaltung ED', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">792, 569</Property>
  <Property name="Name" xsi:type="System.String">CtlAdKursverwaltung</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryEdKurs" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (11, N'CtlAdProzessBearbeiten', NULL, 10, N'Prozesse bearbeiten', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1083, 694</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (12, N'CtlAdTranslateColumn', NULL, 10, N'Tabellenspalten übersetzen', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (13, N'CtlBaInstitutionenFachpersonen', NULL, 1, N'Beziehungen des Klienten zu Institutionen und Fachpersonen verwalten', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1199, 954</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBaPersonInstitution" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (14, N'CtlBaKlientensystem', NULL, 1, N'Klientensystem', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">722, 596</Property>
  <Property name="Name" xsi:type="System.String">CtlBaKlientensystem</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryPersonRelation" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (15, N'CtlEdEinsatzvereinbarung', NULL, 6, N'Einsatzvereinbarung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">722, 596</Property>
  <Property name="Name" xsi:type="System.String">CtlEdEinsatzvereinbarung</Property>
  <Property name="AutoRefresh" xsi:type="System.Boolean">False</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryEdEinsatzvereinbarung" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (16, N'CtlEinsatz', NULL, -7, N'ED/BW Einsätze', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (17, N'CtlFaAbmachungen', NULL, 2, N'Abmachungen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">739, 596</Property>
  <Property name="Name" xsi:type="System.String">CtlFaAbmachungen</Property>
  <Property name="AutoSizeMode" xsi:type="System.Windows.Forms.AutoSizeMode">GrowAndShrink</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaAbmachungen" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (18, N'CtlFaAktennotizen', NULL, 2, N'Aktennotizen', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">739, 596</Property>
  <Property name="Name" xsi:type="System.String">CtlFaAktennotizen</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaAktennotizen" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (19, N'CtlFaBegleiterEntlaster', NULL, -7, N'Begleiter/innen und Entlaster/innen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1185, 782</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryMitarbeiter" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (20, N'CtlFaBeratungsperiode', NULL, 2, N'Beratungsperiode', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">722, 596</Property>
  <Property name="Name" xsi:type="System.String">CtlFaBeratungsperiode</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaLeistung" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (21, N'CtlFaBetreuungsinfo', NULL, 2, N'Betreuungsinfo', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaBetreuungsinfo" />
  </Property>
  <Property name="AutoRefresh" xsi:type="System.Boolean">False</Property>
  <Property name="Name" xsi:type="System.String">CtlFaBetreuungsinfo</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">722, 596</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (22, N'CtlFaDokumentation', NULL, 2, N'Node Dokumentation', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlFaDokumentation</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">404, 164</Property>
</Object>', 0, N'Empty control for empty node Dokumentation', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (23, N'CtlFaDokumente', NULL, 2, N'Dokumente', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">739, 596</Property>
  <Property name="Name" xsi:type="System.String">CtlFaDokumente</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaDokumente" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (24, N'CtlFaFinanzgesuche', NULL, 2, N'Dokumente Gesuchverwaltung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">739, 596</Property>
  <Property name="Name" xsi:type="System.String">CtlFaFinanzgesuche</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaFinanzgesuche" />
  </Property>
</Object>', 0, N'- TODO: Excel-Textmarken für FLB', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (25, N'CtlFaIntake', NULL, 7, N'Intake', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaLeistung" />
  </Property>
  <Property name="AutoRefresh" xsi:type="System.Boolean">False</Property>
  <Property name="Name" xsi:type="System.String">CtlFaIntake</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">722, 596</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (26, N'CtlFaJournal', NULL, 2, N'Journal', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">739, 596</Property>
  <Property name="Name" xsi:type="System.String">CtlFaJournal</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryJournal" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (27, N'CtlFaLeistungKlient', NULL, 2, N'Leistungen Klient', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryLeistungKlient" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlFaLeistungKlient</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">739, 596</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (28, N'CtlFall', NULL, -1, N'Fallbearbeitung Control', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlFall</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">823, 496</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (29, N'CtlFallInfo', NULL, -7, N'FallInfo Control', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">734, 532</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFallInfo" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (30, N'CtlFallZugriff', NULL, 10, N'Fallzugriff', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaLeistung" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlFallZugriff</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">750, 550</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (31, N'CtlQueryBaPerson', NULL, 12, N'BA Personen suchen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">800, 500</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage: Basis- und Kontrollabfragen - Personen suchen', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (32, N'CtlQueryBDEAdminLeistungsartenGruppen', NULL, 12, N'ZLE LeistungsartenGruppen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">800, 500</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage: Zeit-/Leistungserfassung - Leistungsarten / Gruppen', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (33, N'CtlQueryBDEAdminLeistungsdaten', NULL, 12, N'ZLE Leistungsdaten', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">800, 500</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage: Rechnungswesen - Leistungsdaten (Zusatz für die Abacus-Schnittstelle)', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (34, N'CtlQueryBDEAdminStundenlohn', NULL, 12, N'ZLE Stundenlohn', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">800, 500</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage: Rechnungswesen - Stundenlohn (Zusatz für die Abacus-Schnittstelle)', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (35, N'CtlQueryBDEAdminZLEKontrolleVisum', NULL, 12, N'ZLE Visum', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">800, 500</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage: Zeit-/Leistungserfassung - Kontrolle Monatsvisum', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (36, N'CtlQueryBDEFakturaBWED', NULL, 12, N'ZLE Faktura BW/ED', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">800, 500</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage: Rechnungswesen - Faktura', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (37, N'CtlQueryBDEMaAustritt', NULL, 12, N'ZLE MA-Austritt', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, N'Abfrage: Rechnungswesen - Listet ausgetretene Benutzer mit unausgeglichenem Gleitzeit-/Feriensaldo auf.', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (38, N'CtlQueryBDEStundenProLA', NULL, 12, N'ZLE Stunden pro LA', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">800, 500</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage: Zeit-/Leistungserfassung - Stunden pro Leistungsart', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (39, N'CtlQueryFaAbgeschlosseneDossiers', NULL, 12, N'FA Abgeschlossene Dossiers', N'KiSS4.Query.PI.CtlQueryFaLaufendeAbgeschlosseneDossiersBase', NULL, NULL, N'<Object>
  <Property name="Size">800, 500</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage: Dossierverwaltung - Abgeschlossene Dossiers', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (40, N'CtlQueryFaAktiveDossiersBSV', NULL, 12, N'FA Aktive Dossiers BSV', N'KiSS4.Query.PI.CtlQueryFaAktiveNeueDossiersBase', NULL, NULL, N'<Object>
  <Property name="Size">800, 500</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage: Dossierverwaltung - Aktive Dossiers BSV', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (41, N'CtlQueryFaAktiveDossiersBW', NULL, 12, N'Abfrage Aktive Dossiers BW', N'KiSS4.Query.PI.CtlQueryFaAktiveDossiersBase', 2110, NULL, N'<Object>
  <Property name="Size">1653, 1055</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage Aktive Dossiers Begleitetes Wohnen', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (42, N'CtlQueryFaAktiveDossiersED', NULL, 12, N'Abfrage Aktive Dossiers ED', N'KiSS4.Query.PI.CtlQueryFaAktiveDossiersBase', 2110, NULL, N'<Object>
  <Property name="Size">1234, 997</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage Aktive Dossiers Entlastungsdienst', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (43, N'CtlQueryFaAktiveDossiersSozialdaten', NULL, 12, N'FA Aktive Dossiers Sozialdaten', N'KiSS4.Query.PI.CtlQueryFaAktiveDossiersBase', 2111, NULL, N'<Object>
  <Property name="Size">800, 500</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage: Dossierverwaltung - Aktive Dossiers Sozialdaten', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (44, N'CtlQueryFaAktiveNeueDossiersBase', NULL, 12, N'FA Aktive/Neue Dossiers Basisklasse', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, N'Abfrage: Dossierverwaltung - Neue Dossiers / Aktive Dossiers BSV (Basisklasse)', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (45, N'CtlFaModulTree', NULL, 2, N'ModulTree', N'KiSS4.Common.KissModulTree', 2120, NULL, N'<Object xsi:type="KiSS4.Common.KissModulTree" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">265, 500</Property>
  <Property name="Name" xsi:type="System.String">CtlFaModulTree</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (46, N'CtlFaSituationsbeschreibung', NULL, 2, N'Situationsbeschreibung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaSituationsbeschreibung" />
  </Property>
  <Property name="AutoRefresh" xsi:type="System.Boolean">False</Property>
  <Property name="Name" xsi:type="System.String">CtlFaSituationsbeschreibung</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">722, 596</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (47, N'CtlFaSozialsystemContainer', NULL, 2, N'Uebersichtsgrafik', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">570, 382</Property>
  <Property name="Name" xsi:type="System.String">CtlFaSozialsystemContainer</Property>
  <Property name="BorderStyle" xsi:type="System.Windows.Forms.BorderStyle">FixedSingle</Property>
  <Property name="AutoSizeMode" xsi:type="System.Windows.Forms.AutoSizeMode">GrowAndShrink</Property>
  <Property name="BackColor" xsi:type="System.Drawing.Color">White</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (48, N'CtlFaUebersichtsgrafik', NULL, 2, N'Uebersichtsgrafik', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlFaUebersichtsgrafik</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">490, 60</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (49, N'CtlGotoFall', NULL, -7, N'Gehe zu-Iconcontrol', N'KiSS4.Gui.KissComplexControl', 200, NULL, N'<Object>
  <Property name="Size">80, 20</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (50, N'CtlGvAbklaerendeStelle', NULL, 27, N'Gv - CtlGvAbklaerendeStelle', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (51, N'CtlGvAntrag', NULL, 27, N'Gv - CtlGvAntrag', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (52, N'CtlGvAuflagen', NULL, 27, N'Gv - CtlGvAuflagen', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (53, N'CtlGvAuszahlung', NULL, 27, N'Gv - CtlGvAuszahlung', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (54, N'CtlGvBegruendung', NULL, 27, N'Gv - CtlGvBegruendung', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (55, N'CtlGvBeilagenDokumente', NULL, 27, N'Gv - CtlGvBeilagenDokumente', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (56, N'CtlGvBewilligung', NULL, 27, N'Gv - CtlGvBewilligung', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (57, N'CtlGvGesuch', NULL, 27, NULL, N'KiSS4.Gesuchverwaltung.GvBaseControl', NULL, NULL, N'<Object>
  <Property name="Size">745, 292</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="_qryGvGesuch" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (58, N'CtlGvGesuchverwaltung', NULL, 27, N'Gv - CtlGvGesuchverwaltung', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">842, 651</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryGvGesuch" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (59, N'CtlHyperlink', NULL, 10, N'Links', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">819, 612</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryHyperlink" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (60, N'CtlHyperlinkContext', NULL, 10, N'Linkskontext', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">819, 609</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryHyperlinkContext" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (61, N'CtlIcon', NULL, 11, N'Symbole', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1459, 854</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryIcon" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (62, N'CtlKbAuszahlungVerbuchen', NULL, 17, N'KB - CtlKbAuszahlungVerbuchen', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (63, N'CtlKbBankPost', NULL, 17, N'Bankenstamm', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, N'Bankenstamm für die Verwaltung der Bank/Post-Stammdaten', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (64, N'CtlKbBelegeKorrigieren', NULL, 17, N'KB - CtlKbBelegeKorrigieren', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (65, N'CtlKbBelegImportGv', NULL, 17, N'KB - CtlKbBelegImportGv', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (66, N'CtlKbBelegkreise', NULL, 17, N'KB - CtlKbBelegkreise', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1495, 831</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBelegKreis" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (67, N'CtlKbBuchung', NULL, 17, N'KB - CtlKbBuchung', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (68, N'CtlKbDummy', NULL, 17, N'KB - CtlKbDummy', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (69, N'CtlKbKonto', NULL, 17, N'KB - CtlKbKonto', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1495, 831</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryKbKonto" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (70, N'CtlKbKostenstelleErfassung', NULL, 17, N'KB - CtlKbKostenstelleErfassung', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (71, N'CtlKbKostenstellen', NULL, 17, N'KB - CtlKbKostenstellen', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (72, N'CtlKbKostenstelleZuweisung', NULL, 17, N'KB - CtlKbKostenstelleZuweisung', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (73, N'CtlKbKreditor', NULL, 17, N'KB - CtlKbKreditor', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (74, N'CtlKbMandant', NULL, 17, N'KB - CtlKbMandant', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (75, N'CtlKbPeriode', NULL, 17, N'KB - CtlKbPeriode', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1495, 831</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryPeriode" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (76, N'CtlKbTransfer', NULL, 17, N'KB - CtlKbTransfer', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (77, N'CtlKbWVEinzelposten', NULL, 17, N'KB - CtlKbWVEinzelposten', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (78, N'CtlKbZahlungseingang', NULL, 17, N'KB - CtlKbZahlungseingang', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">835, 701</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryZahlungseingang" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (79, N'CtlKbZahlungskonto', NULL, 17, N'Kb - CtlKbZahlungskonto', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (80, N'CtlKbZahlungslauf', NULL, 17, N'CtlKbZahlungslauf', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (81, N'CtlKGSKostenstelleSAR', NULL, -7, NULL, N'KiSS4.Gui.KissComplexControl', 200, NULL, NULL, 0, N'Control für KGS, Kostenstelle, SAR', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (82, N'CtlLOV', NULL, 11, N'Wertelisten', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1245, 808</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXLOV" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (83, N'CtlLOVCode', NULL, 11, N'Werteliste Details', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1459, 854</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXLOVCode" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (84, N'CtlMenuEditor', NULL, 11, N'Menueditor', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">600, 527</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXMenuItem" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (85, N'CtlMessage', NULL, 10, N'Meldungen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">845, 508</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryMessage" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (86, N'CtlMitarbeiter', NULL, -7, N'Mitarbeiter/innen BW/ED', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">800, 600</Property>
  <Property name="Name" xsi:type="System.String">CtlEdMitarbeiter</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryEdMitarbeiter" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (87, N'CtlModul', NULL, 11, N'Module', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1459, 854</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXModul" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (88, N'CtlOrgUnit', NULL, 10, N'Abteilungen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryOrgUnit" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlOrgUnit</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">750, 550</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (89, N'CtlPersonenStamm', NULL, 1, N'PersonenStamm', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <InstanceDescriptor xsi:type="KiSS4.DB.SqlQuery">
      <Property name="SelectStatement" xsi:type="System.String">SELECT PRS.*, 
       Strasse = PRS.WohnsitzStrasse + ISNULL('' '' + PRS.WohnsitzHausNr, ''''), 
       PLZOrt  = ISNULL(PRS.WohnsitzPLZ + '' '', '''') + isNull(PRS.WohnsitzOrt, ''''), 
       Heimatort = HEI.Text + IsNull('' '' + HEI.Value2, ''''), 
       [Alter] = dbo.fnGetAge(Geburtsdatum, GETDATE()), 
       Geschlecht = CASE GeschlechtCode 
                    WHEN 1 THEN ''m'' 
                    WHEN 2 THEN ''f'' 
                    ELSE '''' END, 
       LT = CONVERT(BIT, CASE WHEN EXISTS(SELECT 1 FROM FaLeistung WHERE BaPersonID = PRS.BaPersonID) THEN 1 ELSE 0 END)
FROM   BaPerson PRS
LEFT JOIN XLOVCode HEI ON HEI.LovName = ''Gemeinde'' AND 
                   HEI.Code = PRS.HeimatgemeindeCode
WHERE 1 = 1
--- AND PRS.Name LIKE {edtSucheName} + ''%''
--- AND PRS.Vorname LIKE {edtSucheVorname} + ''%''
--- AND PRS.WohnsitzStrasse LIKE {edtSucheStrasse} + ''%''
--- AND PRS.WohnsitzPLZ LIKE {edtSuchePLZ} + ''%''
--- AND PRS.WohnsitzOrt LIKE {edtSucheOrt} + ''%''
--- AND PRS.BaPersonID = {edtSucheDmgPersonID}
--- AND PRS.Geburtsdatum &gt;= {edtSucheGeburtVon}
--- AND PRS.Geburtsdatum &lt;= {edtSucheGeburtBis}
--- AND PRS.NationalitaetCode = {edtSucheNationalitaet}
--- AND PRS.AHVNummer = {edtSucheAHVNummer}
--- AND ({chkSucheLT} = 0 OR EXISTS(SELECT 1 FROM FaLeistung WHERE BaPersonID = PRS.BaPersonID))
ORDER BY Name, Vorname, Geburtsdatum</Property>
      <Property name="TableName" xsi:type="System.String">BaPerson</Property>
      <Property name="HostControl">
        <Reference name="CtlPersonenStamm" />
      </Property>
    </InstanceDescriptor>
  </Property>
  <Property name="Name" xsi:type="System.String">CtlPersonenStamm</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">971, 524</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (90, N'CtlProfile', NULL, 10, N'ADM - CtlProfile', N'KiSS4.Gui.KissUserControl', 2110, NULL, NULL, 0, N'Profile', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (91, N'CtlProfileTagsControl', NULL, -7, NULL, N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">799, 186</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (92, N'CtlProfileTagsVerwalten', NULL, 10, N'ADM - CtlProfileTagsVerwalten', N'KiSS4.Gui.KissUserControl', 2110, NULL, NULL, 0, N'Profiletags Verwalten', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (93, N'CtlQueryAdmAngemeldeteBenutzer', NULL, 12, N'AD Angemeldete Benutzer', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">800, 500</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage: Administration - Angemeldete Benutzer', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (94, N'CtlQueryAdmBenutzergruppenRechte', NULL, 12, N'AD Benutzergruppen Rechte', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (95, N'DlgReportMenu', NULL, 12, N'Report-Menu', N'KiSS4.Gui.KissDialog', 3200, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (96, N'DlgReportParameter', NULL, 12, N'Report-Paremeter - DlgReportParameter', N'KiSS4.Gui.KissDialog', 3200, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (97, N'DlgRTFEdit', NULL, -8, N'RTF editieren', N'KiSS4.Gui.KissDialog', 3200, 191, N'<Object>
  <Property name="Text">Memo editieren (formatiert)</Property>
  <Property name="ClientSize">658, 399</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (98, N'DlgSelectNewTemplate', NULL, 13, N'Neue Vorlage auswaehlen', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Neue Vorlage auswählen</Property>
  <Property name="ClientSize">494, 371</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (99, N'DlgSelectTranslation', NULL, -8, N'Übersetzungselement wählen', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Maske wählen</Property>
  <Property name="ClientSize">473, 266</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (100, N'DlgTextEditorControl', NULL, 11, NULL, N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Code editieren</Property>
  <Property name="ClientSize">1616, 927</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (101, N'DlgTranslateMask', NULL, -8, N'Maske übersetzen', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Übersetzung</Property>
  <Property name="ClientSize">896, 358</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (102, N'DlgTranslateMemoEdit', NULL, -8, N'ML Memo editieren', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Memo editieren</Property>
  <Property name="ClientSize">640, 425</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryText" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (103, N'DlgUserBDEDetails', NULL, 20, N'Benutzer BDE-Details', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object xsi:type="KiSS4.Gui.KissDialog" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">894, 473</Property>
  <Property name="FormBorderStyle" xsi:type="System.Windows.Forms.FormBorderStyle">Sizable</Property>
  <Property name="Name" xsi:type="System.String">DlgUserBDEDetails</Property>
  <Property name="Text" xsi:type="System.String">Benutzer - BDE-Details</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (104, N'DlgVSSCheckin', NULL, 11, NULL, N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">VSS Check-in</Property>
  <Property name="ClientSize">494, 221</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (105, N'DlgWebCheckin', NULL, 11, NULL, N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Web Check-in</Property>
  <Property name="ClientSize">494, 221</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (106, N'FavoritesView', NULL, -1, N'Favoritenverwaltung', N'KiSS4.Gui.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (107, N'FrmAdAnwendungsdatenVerwalten', NULL, 10, N'Anwendungsdaten verwalten', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object xsi:type="KiSS4.Common.KissNavBarForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">892, 569</Property>
  <Property name="Name" xsi:type="System.String">FrmAdAnwendungsdatenVerwalten</Property>
  <Property name="Text" xsi:type="System.String">Anwendungsdaten verwalten</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (108, N'FrmArchiveManagement', NULL, 10, N'Archivverwaltung', N'KiSS4.Gui.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (109, N'FrmBDEVisumKostenstelle', NULL, 20, N'Visum Kostenstelle', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object>
  <Property name="Text">Visum Kostenstelle</Property>
  <Property name="ClientSize">1916, 1126</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (110, N'FrmBDEZeiterfassung', NULL, 20, N'Zeiterfassung', N'KiSS4.Gui.KissChildForm', 3100, 195, N'<Object xsi:type="KiSS4.Gui.KissChildForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Text" xsi:type="System.String">Zeiterfassung</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryData" />
  </Property>
  <Property name="Name" xsi:type="System.String">FrmBDEZeiterfassung</Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">982, 601</Property>
  <Event name="KeyDown" xsi:type="System.String">FrmBDEZeiterfassung_KeyDown</Event>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (111, N'FrmConfig', NULL, 10, N'Konfiguration', N'KiSS4.Gui.KissChildForm', 3100, 7980, N'<Object>
  <Property name="Text">Konfiguration</Property>
  <Property name="ClientSize">881, 399</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryValue" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (112, N'FrmDataCorrection', NULL, 10, N'Datenbereinigung', N'KiSS4.Common.KissNavBarForm', 3120, 10350, N'<Object xsi:type="KiSS4.Common.KissNavBarForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">992, 651</Property>
  <Property name="Name" xsi:type="System.String">FrmDataCorrection</Property>
  <Property name="Text" xsi:type="System.String">Datenbereinigung</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (113, N'FrmDataEditor', NULL, 10, N'Dateneditor', N'KiSS4.Gui.KissChildForm', 3100, 7968, N'<Object>
  <Property name="Text">Dateneditor</Property>
  <Property name="ClientSize">772, 491</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (114, N'FrmDataExplorer', NULL, 12, N'Daten-Explorer', N'KiSS4.Gui.KissChildForm', 3100, 196, N'<Object>
  <Property name="Text">Daten-Explorer</Property>
  <Property name="ClientSize">884, 562</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (115, N'FrmDesigner', NULL, 11, N'BusinessDesigner', N'KiSS4.Common.KissNavTreeForm', 3130, NULL, N'<Object>
  <Property name="Text">Business Designer</Property>
  <Property name="ClientSize">800, 556</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (116, N'FrmDocTemplate', NULL, 10, N'Vorlagenverwaltung', N'KiSS4.Common.KissNavBarForm', 3120, 10346, N'<Object>
  <Property name="Text">Vorlagenverwaltung</Property>
  <Property name="ClientSize">992, 643</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (117, N'FrmFall', NULL, -1, N'Fallführungsfenster', N'KiSS4.Gui.KissChildForm', 3100, 197, N'<Object xsi:type="KiSS4.Gui.KissChildForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Text" xsi:type="System.String">Fallbearbeitung</Property>
  <Property name="Name" xsi:type="System.String">FrmFall</Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">1012, 666</Property>
  <Event name="KeyDown" xsi:type="System.String">FrmFall_KeyDown</Event>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (118, N'FrmFallInfo', NULL, -7, N'Fallinfo', N'KiSS4.Gui.KissForm', 300, 10330, N'<Object>
  <Property name="Text">Fallinfo</Property>
  <Property name="ClientSize">952, 484</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFall" />
</Property>
</Object>', 0, N'Wird nicht verwendet...', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (119, N'FrmFallNavigator', NULL, -1, N'Fallnavigator', N'KiSS4.Gui.KissChildForm', 3100, 198, N'<Object xsi:type="KiSS4.Gui.KissChildForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">672, 499</Property>
  <Property name="Name" xsi:type="System.String">FrmFallNavigator</Property>
  <Property name="Text" xsi:type="System.String">Fall-Navigator</Property>
  <Event name="RefreshData" xsi:type="System.String">FrmFallNavigator_RefreshData</Event>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (120, N'FrmFallVerwaltung', NULL, 10, N'Fallverwaltung', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object>
  <Property name="Text">Fallverwaltung</Property>
  <Property name="ClientSize">800, 522</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (121, N'FrmFallZugriff', NULL, -7, N'Fallzugriff', N'KiSS4.Gui.KissForm', 300, 10307, N'<Object>
  <Property name="Text">Fallzugriff</Property>
  <Property name="ClientSize">589, 383</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFall" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (122, N'FrmGvGesuchverwaltung', NULL, 27, N'Gesuchverwaltung', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">Gesuchverwaltung</Property>
  <Property name="ClientSize">1211, 807</Property>
</Object>', 0, N'Form, die CtlGvGesuchverwaltung beinhaltet', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (123, N'FrmHelpFileOpenerBase', NULL, -1, N'Hilfe Basisklasse', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object xsi:type="KiSS4.Gui.KissChildForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">144, 0</Property>
  <Property name="FormBorderStyle" xsi:type="System.Windows.Forms.FormBorderStyle">FixedToolWindow</Property>
  <Property name="Location" xsi:type="System.Drawing.Point">-100, -100</Property>
  <Property name="MaximizeBox" xsi:type="System.Boolean">False</Property>
  <Property name="MinimizeBox" xsi:type="System.Boolean">False</Property>
  <Property name="Name" xsi:type="System.String">FrmHelpFileOpenerBase</Property>
  <Property name="ShowInTaskbar" xsi:type="System.Boolean">False</Property>
  <Property name="StartPosition" xsi:type="System.Windows.Forms.FormStartPosition">CenterScreen</Property>
  <Property name="Text" xsi:type="System.String">Helpfile Opener</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (124, N'FrmInstitutionenStamm', NULL, 1, N'Institutionenstamm', N'KiSS4.Common.KissSearchForm', 3110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBaInstitution" />
  </Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">928, 582</Property>
  <Property name="Name" xsi:type="System.String">FrmInstitutionenStamm</Property>
  <Property name="Text" xsi:type="System.String">Institutionen, Fachpersonen-Stamm</Property>
  <Event name="Layout" xsi:type="System.String">FrmInstitutionenStamm_Layout</Event>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (125, N'FrmKbKlientenbuchhaltung', NULL, 17, N'KB - FrmKbKlientenbuchhaltung', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object>
  <Property name="Text">Klientenbuchhaltung</Property>
  <Property name="ClientSize">1668, 862</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (126, N'FrmLinkManagement', NULL, 10, N'Linkverwaltung', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object xsi:type="KiSS4.Common.KissNavBarForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">775, 524</Property>
  <Property name="Name" xsi:type="System.String">FrmLinkManagement</Property>
  <Property name="Text" xsi:type="System.String">Linkverwaltung</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (127, N'FrmMain', NULL, -1, N'Hauptfenster', N'KiSS4.Gui.KissMainForm', NULL, NULL, N'<Object>
  <Property name="Text">KiSS 4.0.0033 Beta -  Administrator (Admin)</Property>
  <Property name="ClientSize">1012, 734</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (128, N'FrmManualAllgemein', NULL, -1, N'MAN - FrmManualAllgemein', N'KiSS4.GUI.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (129, N'FrmManualBenutzerrechte', NULL, -1, N'MAN - FrmManualBenutzerrechte', N'KiSS4.GUI.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (130, N'FrmManualFibu', NULL, -1, N'MAN - FrmManualFibu', N'KiSS4.GUI.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (131, N'FrmManualInkasso', NULL, -1, N'MAN - FrmManualInkasso', N'KiSS4.GUI.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (132, N'FrmManualKlibu', NULL, -1, N'MAN - FrmManualKlibu', N'KiSS4.GUI.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (133, N'FrmManualSostat', NULL, -1, N'MAN - FrmManualSostat', N'KiSS4.GUI.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (134, N'FrmManualSozialhilfe', NULL, -1, N'MAN - FrmManualSozialhilfe', N'KiSS4.GUI.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (135, N'FrmManualSystem', NULL, -1, N'MAN - FrmManualSystem', N'KiSS4.GUI.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (136, N'FrmMitarbeiterverwaltung', NULL, -7, N'Anwendung Mitarbeiterverwaltung BW/ED', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object xsi:type="KiSS4.Common.KissNavBarForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">962, 666</Property>
  <Property name="Name" xsi:type="System.String">FrmEdEntlastungsdienst</Property>
  <Property name="Text" xsi:type="System.String">Entlastungsdienst</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (137, N'FrmMultilanguage', NULL, 10, N'Meldungen', N'KiSS4.Common.KissNavBarForm', 3120, 10347, N'<Object>
  <Property name="Text">Meldungen</Property>
  <Property name="ClientSize">1032, 539</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (138, N'FrmMyKiSS', NULL, 2, N'MyKiSS', N'KiSS4.Gui.KissChildForm', 3100, 13347, N'<Object xsi:type="KiSS4.Gui.KissChildForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Text" xsi:type="System.String">My KiSS</Property>
  <Property name="Name" xsi:type="System.String">FrmMyKiSS</Property>
  <Property name="StartPosition" xsi:type="System.Windows.Forms.FormStartPosition">CenterParent</Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">792, 629</Property>
</Object>', 0, N'MyKiSS - it strongly depends on Fallverlauf, therefore its within this module', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (139, N'FrmPersonenStamm', NULL, 1, N'Personenstamm', N'KiSS4.Gui.KissChildForm', 3100, 192, N'<Object xsi:type="KiSS4.Gui.KissChildForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">842, 651</Property>
  <Property name="Name" xsi:type="System.String">FrmPersonenStamm</Property>
  <Property name="Text" xsi:type="System.String">Personen-Stamm</Property>
  <Event name="Shown" xsi:type="System.String">FrmPersonenStamm_Shown</Event>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (140, N'FrmQueryManagement', NULL, 12, N'Report- und Abfragenverwaltung', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object>
  <Property name="Text">Report- und Abfrageverwaltung</Property>
  <Property name="ClientSize">990, 641</Property>
</Object>', 0, N'Is Kiss core for old query editor', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (141, N'FrmReportViewer', NULL, 12, N'Reportansicht', N'KiSS4.Gui.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (142, N'FrmSchnittstellenAbacus', NULL, 14, N'Schnittstellen Abacus', N'KiSS4.Common.KissNavBarForm', 3120, 12022, N'<Object xsi:type="KiSS4.Common.KissNavBarForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">850, 440</Property>
  <Property name="Name" xsi:type="System.String">FrmSchnittstellenAbacus</Property>
  <Property name="Text" xsi:type="System.String">Schnittstellen zu Abacus</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (143, N'FrmUserManagement', NULL, 10, N'Benutzerverwaltung', N'KiSS4.Common.KissNavBarForm', 3120, 10345, N'<Object>
  <Property name="Text">Benutzerverwaltung</Property>
  <Property name="ClientSize">842, 643</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (144, N'Kiss.UI.View.Ad.AdPasswortAendernView.xaml', NULL, 1, N'Passwort ändern', N'Kiss.UI.View', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (145, N'Kiss.UI.View.Ba.BaGemeindeView.xaml', NULL, 1, N'BaGemeinde Update', N'Kiss.UI.View', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (146, N'Kiss.UI.View.Ba.BaLandView.xaml', NULL, 1, N'BaLand Update', N'Kiss.UI.View', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (147, N'Kiss.UI.View.Ba.BaPlzView.xaml', NULL, 1, N'BaPLZ Update', N'Kiss.UI.View', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (148, N'KissBfsDtpSeitGeburt', NULL, -7, N'Control Seit Geburt', N'KiSS4.Gui.KissComplexControl', 200, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (149, N'KissLookupDialog', NULL, -8, N'Auswahldialog', N'KiSS4.Gui.KissDialog', 3200, 199, N'<Object>
  <Property name="Text">Auswahl</Property>
  <Property name="ClientSize">272, 306</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (150, N'KissMemoEditML', NULL, -8, N'Control Memo editieren ML', N'KiSS4.Gui.KissComplexControl', 200, NULL, N'<Object>
  <Property name="Size">709, 96</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (151, N'KissModulTree', NULL, -7, N'Control ModulTree', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (152, N'KissNavBarForm', NULL, -7, N'Form NavBar', N'KiSS4.Gui.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (153, N'KissNavTreeForm', NULL, -7, N'Form NavTree', N'KiSS4.Gui.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (154, N'KissPickList', NULL, -8, N'Mehrfachauswahl-Listen', N'KiSS4.Gui.KissComplexControl', 200, NULL, N'<Object>
  <Property name="Size">573, 734</Property>
</Object>', 0, N'Generisches Control, welches in einer Listenansicht die Mehrfachauswahl von Einträgen ermöglicht', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (155, N'KissPLZOrt', NULL, -7, N'Control PLZOrt', N'KiSS4.Gui.KissComplexControl', 200, NULL, N'<Object>
  <Property name="Size">270, 47</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (156, N'KissQueryControl', NULL, -7, N'Control Query', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (157, N'KissSearchDialog', NULL, -1, N'Suchdialog des Hauptfensters', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>    <Property name="Text">KiSS Suchergebnisse</Property>    <Property name="ClientSize">1916, 1086</Property>    <Property name="ActiveSQLQuery">      <Reference name="qry" />  </Property>  </Object>', 0, N'Suchdialog des Hauptfensters', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (158, N'KissSearchForm', NULL, -7, N'Form Search', N'KiSS4.Gui.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (159, N'KissSearchTitel', NULL, -8, N'Control Suchtitel', N'KiSS4.Gui.KissComplexControl', 200, NULL, N'<Object>
  <Property name="Size">1239, 24</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (160, N'KissSearchUserControl', NULL, -7, N'Control SucheListe', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">760, 263</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (161, N'CtlTableForeignKeysEditor', NULL, 11, N'Fremdschlüssel', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1457, 768</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXForeignKeys" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (162, N'CtlTableIndicesEditor', NULL, 11, N'PKs/Indizes', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">596, 457</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXIndex" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (163, N'CtlTableStructureEditor', NULL, 11, N'Tabellenstruktur', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1459, 836</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (164, N'CtlTranslateMask', NULL, -8, N'Maske übersetzen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">864, 312</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (165, N'CtlTreeEditor', NULL, 11, N'Tree-Editor', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1459, 854</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXModulTree" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (166, N'CtlUser', NULL, 10, N'Benutzer', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">750, 550</Property>
  <Property name="Name" xsi:type="System.String">CtlUser</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryUser" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (167, N'CtlUserGroup', NULL, 10, N'Rollen/Benutzergruppen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryUserGroup" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlUserGroup</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">750, 550</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (168, N'CtlVerfuegbarkeit', NULL, -7, N'Verfügbarkeit BW/ED', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">800, 600</Property>
  <Property name="Name" xsi:type="System.String">CtlEdVerfuegbarkeit</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryEdVerfuegbarkeit" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (169, N'CtlWpfMask', NULL, -8, NULL, N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (170, N'CtlXRight', NULL, 11, N'Rechte', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">598, 499</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXRight" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (171, N'DlgAbout', NULL, -1, N'Hilfe Über Dialog', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Über</Property>
  <Property name="ClientSize">593, 317</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (172, N'DlgAuswahl', NULL, -7, N'Auswahldialog', N'KiSS4.Gui.KissDialog', 3200, 189, N'<Object>
  <Property name="Text">Auswahl</Property>
  <Property name="ClientSize">670, 306</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (173, N'DlgBaIVBerechtigung', NULL, 1, N'IV-Berechtigung bearbeiten', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object xsi:type="KiSS4.Gui.KissDialog" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="CancelButton">
    <Reference name="btnCloseDialog" />
  </Property>
  <Property name="Text" xsi:type="System.String">IV-Berechtigung</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBaIVBerechtigung" />
  </Property>
  <Property name="Name" xsi:type="System.String">DlgBaIVBerechtigung</Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">642, 419</Property>
  <Property name="AcceptButton">
    <Reference name="btnCloseDialog" />
  </Property>
  <Property name="FormBorderStyle" xsi:type="System.Windows.Forms.FormBorderStyle">Sizable</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (174, N'DlgBankenabgleich', NULL, 0, N'Dialog für Bankenstamm-Aktualisierung', N'KiSS4.Gui.KissDialog', 3200, NULL, NULL, 0, N'Dialog, welcher für die Aktualisierung des Bankenstamms verwendet wird', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (175, N'DlgFallInfo', NULL, -7, N'Dialog FallInfo', N'KiSS4.Gui.KissDialog', 3200, 12803, N'<Object xsi:type="KiSS4.Gui.KissDialog" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryFallInfo" />
  </Property>
  <Property name="CancelButton">
    <Reference name="btnClose" />
  </Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">734, 571</Property>
  <Property name="FormBorderStyle" xsi:type="System.Windows.Forms.FormBorderStyle">Sizable</Property>
  <Property name="Name" xsi:type="System.String">DlgFallInfo</Property>
  <Property name="Text" xsi:type="System.String">Fall-Informationen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (176, N'DlgFaSituationsbeschreibungHist', NULL, 2, N'Situationsbeschr.Historisieren', N'KiSS4.Gui.KissDialog', 3200, 193, N'<Object xsi:type="KiSS4.Gui.KissDialog" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryHistFaSituationsbeschreibung" />
  </Property>
  <Property name="CancelButton">
    <Reference name="btnClose" />
  </Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">988, 636</Property>
  <Property name="FormBorderStyle" xsi:type="System.Windows.Forms.FormBorderStyle">Sizable</Property>
  <Property name="Name" xsi:type="System.String">DlgFaSituationsbeschreibungHist</Property>
  <Property name="Text" xsi:type="System.String">Verlauf - {0}</Property>
  <Event name="Shown" xsi:type="System.String">DlgFaSituationsbeschreibungHist_Shown</Event>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (177, N'DlgGeheZu', NULL, -1, N'Gehe zu', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object xsi:type="KiSS4.Gui.KissDialog" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="CancelButton">
    <Reference name="btnCancel" />
  </Property>
  <Property name="Text" xsi:type="System.String">Gehe zu</Property>
  <Property name="Name" xsi:type="System.String">DlgGeheZu</Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">291, 275</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (178, N'DlgKissUserControl', NULL, -7, N'Dialog', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Vorschau</Property>
  <Property name="ClientSize">420, 210</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (179, N'DlgMehrfacheintrag', NULL, -7, N'Mehrfachauswahl', N'KiSS4.Gui.KissDialog', 3200, 200, N'<Object xsi:type="KiSS4.Gui.KissDialog" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="CancelButton">
    <Reference name="btnAbbrechen" />
  </Property>
  <Property name="Text" xsi:type="System.String">Mehrfacheintrag</Property>
  <Property name="Name" xsi:type="System.String">DlgMehrfacheintrag</Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">354, 310</Property>
  <Property name="AcceptButton">
    <Reference name="btnOk" />
  </Property>
  <Event name="Layout" xsi:type="System.String">DlgMehrfacheintrag_Layout</Event>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (180, N'DlgMemoEdit', NULL, -8, N'Memo editieren', N'KiSS4.Gui.KissDialog', 3200, 190, N'<Object>
  <Property name="Text">Memo editieren</Property>
  <Property name="ClientSize">669, 474</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (181, N'DlgNeuePerson', NULL, 1, N'Neue Person', N'KiSS4.Common.DlgPersonSucheNeu', NULL, 10302, N'<Object xsi:type="KiSS4.Common.DlgPersonSucheNeu" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">707, 594</Property>
  <Property name="Name" xsi:type="System.String">DlgNeuePerson</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (182, N'DlgNeuerFall', NULL, -1, N'Neuer Fall', N'KiSS4.Common.DlgPersonSucheNeu', NULL, 10301, N'<Object xsi:type="KiSS4.Common.DlgPersonSucheNeu" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">699, 598</Property>
  <Property name="Name" xsi:type="System.String">DlgNeuerFall</Property>
  <Property name="Text" xsi:type="System.String">Neuer Fall</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (183, N'DlgNewDocument', NULL, 13, N'Neues Dokument', N'KiSS4.Gui.KissDialog', 3200, 9378, N'<Object>
  <Property name="Text">Neues Dokument erstellen</Property>
  <Property name="ClientSize">412, 426</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (184, N'DlgPersonenStammHist', NULL, 1, N'Historisiere PersStamm', N'KiSS4.Gui.KissDialog', 3200, 194, N'<Object xsi:type="KiSS4.Gui.KissDialog" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryHistBaPerson" />
  </Property>
  <Property name="CancelButton">
    <Reference name="btnClose" />
  </Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">988, 636</Property>
  <Property name="FormBorderStyle" xsi:type="System.Windows.Forms.FormBorderStyle">Sizable</Property>
  <Property name="Name" xsi:type="System.String">DlgPersonenStammHist</Property>
  <Property name="Text" xsi:type="System.String">Verlauf - {0}</Property>
  <Event name="Shown" xsi:type="System.String">DlgPersonenStammHist_Shown</Event>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (185, N'DlgPersonSucheNeu', NULL, -7, N'DlgPersonSucheNeu', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object xsi:type="KiSS4.Gui.KissDialog" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">699, 560</Property>
  <Property name="Name" xsi:type="System.String">DlgPersonSucheNeu</Property>
  <Property name="Text" xsi:type="System.String">Neue Person</Property>
  <Event name="Activated" xsi:type="System.String">DlgPersonSucheNeu_Activated</Event>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (186, N'CtlRenameBookmarks', NULL, 10, N'Textmarken umbenennen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1080, 803</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (187, N'CtlReportDefinition', NULL, 12, N'Report-Definition', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">896, 592</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXQuery" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (188, N'CtlSbEvaluation', NULL, 3, N'Evaluation', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">722, 596</Property>
  <Property name="Name" xsi:type="System.String">CtlSbEvaluation</Property>
  <Property name="AutoRefresh" xsi:type="System.Boolean">False</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qrySbSozialberatungMain" />
  </Property>
</Object>', 0, N'INFO: Almost same class as CtlCmEvalution', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (189, N'CtlSbZielvereinbarung', NULL, 3, N'Zielvereinbarung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">722, 596</Property>
  <Property name="Name" xsi:type="System.String">CtlSbZielvereinbarung</Property>
  <Property name="AutoRefresh" xsi:type="System.Boolean">False</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qrySbSozialberatungMain" />
  </Property>
</Object>', 0, N'INFO: Almost same class as CtlCmZielvereinbarung', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (190, N'CtlSozialsystem', NULL, 0, NULL, N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1164, 705</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (191, N'CtlSozialsystemPI', NULL, 0, NULL, N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">962, 761</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (192, N'CtlTableColumnEditor', NULL, 11, N'Spalteneditor', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1457, 768</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXTableColumn" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (193, N'CtlTableEditor', NULL, 11, N'Tabelleneditor', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">888, 560</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXTable" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (194, N'CtlQueryAdmDatenMengen', NULL, 12, NULL, N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">800, 500</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (195, N'CtlQueryAdmDatentypKonsistenz', NULL, 12, NULL, N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">800, 500</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (196, N'CtlQueryAdmDoppeltErfassteBeziehungen', NULL, 12, NULL, N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (197, N'CtlQueryAdmDoppeltErfassteInstitutionen', NULL, 12, NULL, N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
GO
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (198, N'CtlQueryAdmDoppeltErfasstePersonen', NULL, 12, NULL, N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (199, N'CtlQueryAdmDossiersLoeschen', NULL, 12, N'Dossiers löschen', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, N'Löscht eine Person (deren Fall längere Zeit inaktiv ist) inklusive abhängiger Daten.', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (200, N'CtlQueryAdmKinderMitMehrerenMuetternVaeter', NULL, 12, NULL, N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">800, 500</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (201, N'CtlQueryAdmMaskenUebersicht', NULL, 12, N'AD Maskenübersicht', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">800, 500</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage: Administration - Maskenübersicht', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (202, N'CtlQueryAdmMitgliedInMehrerenAbteilungen', NULL, 12, N'AD Mehrfache Mitgliedschaften', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">800, 500</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage: Administration - Mehrfache Mitgliedschaften', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (203, N'CtlQueryBaInstitutionKontaktpersonen', NULL, 12, N'QU - CtlQueryBaInstitutionKontaktpersonen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">1653, 1055</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (204, N'CtlQueryBaOffeneMussFelder', NULL, 12, N'BA Offene Muss-Felder', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">800, 500</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage: Basis- und Kontrollabfragen - Offene Muss-Felder', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (205, N'CtlQueryFaKeinFallverlauf', NULL, 12, N'FA Kein Fallverlauf', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">1217, 814</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage: Basis- und Kontrollabfragen - Kein Fallverlauf', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (206, N'CtlQueryFaLaufendeAbgeschlosseneDossiersBase', NULL, 12, N'FA Laufende/Abgeschlossene Dossiers Basisklasse', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, N'Abfrage: Dossierverwaltung - Laufende / Abgeschlossene Dossiers (Basisklasse)', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (207, N'CtlQueryFaLaufendeDossiers', NULL, 12, N'FA Laufende Dossiers', N'KiSS4.Query.PI.CtlQueryFaLaufendeAbgeschlosseneDossiersBase', NULL, NULL, N'<Object>
  <Property name="Size">800, 500</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage: Dossierverwaltung - Laufende Dossiers', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (208, N'CtlQueryFaNeueDossiersBSV', NULL, 12, N'FA Neue Dossiers BSV', N'KiSS4.Query.PI.CtlQueryFaAktiveNeueDossiersBase', NULL, NULL, N'<Object>
  <Property name="Size">800, 500</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage: Dossierverwaltung - Neue Dossiers BSV', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (209, N'CtlQueryGeplanteEinsaetze', NULL, -7, N'Geplante Einsätze BW/ED', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">800, 600</Property>
  <Property name="Name" xsi:type="System.String">CtlQueryEdGeplanteEinsaetze</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryEdEinsatz" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (210, N'CtlQueryGvExterneFonds', NULL, 12, N'GV - Abfrage Gesuche an externe Fonds', N'KiSS4.Query.CtlQueryGvFondsBase', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (211, N'CtlQueryGvExterneFondsIks', NULL, 12, N'GV - CtlQueryGvExterneFondsIks', N'KiSS4.Query.CtlQueryGvFondsBase', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (212, N'CtlQueryGvFondsBase', NULL, 12, NULL, N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (213, N'CtlQueryGvGesuchAbschliessen', NULL, 12, N'GV - Abfrage Gesuch abschliessen', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (214, N'CtlQueryGvHaengigeAuflagenInterneFonds', NULL, 12, N'GV - Abfrage hängige Auflagen interne Fonds', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (215, N'CtlQueryGvInterneFonds', NULL, 12, N'GV - Abfrage Gesuche an interne Fonds', N'KiSS4.Query.CtlQueryGvFondsBase', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (216, N'CtlQueryKbAbrechnungASVS', NULL, 17, N'KB - CtlQueryKbAbrechnungASVS', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (217, N'CtlQueryKbBilanzErfolg', NULL, 17, N'KB - CtlQueryKbBilanzErfolg', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (218, N'CtlQueryKbBilanzkonti', NULL, 17, N'KB - CtlQueryKbBilanzkonti', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (219, N'CtlQueryKbBuchungsjournal', NULL, 17, N'KB - CtlQueryKbBuchungsjournal', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (220, N'CtlQueryKbKlientenkonto', NULL, 17, N'KB - CtlQueryKbKlientenkonto', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (221, N'CtlQueryKbKostenarten', NULL, 17, N'KB - CtlQueryKbKostenarten', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (222, N'CtlQueryKbKostenstellenjournal', NULL, 17, N'KB - CtlQueryKbKostenstellenjournal', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (223, N'CtlQueryKbSaldolisteKreditoren', NULL, 17, N'KB - CtlQueryKbSaldolisteKreditoren', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (224, N'CtlQueryKbSozialhilferechnung', NULL, 17, N'KB - CtlQueryKbSozialhilferechnung', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (225, N'CtlQueryKbSozialhilferechnungDifferenziert', NULL, 17, N'KB - CtlQueryKbSozialhilferechnungDifferenziert', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (226, N'CtlQueryKontiOhneBgKostenart', NULL, 17, N'KB - CtlQueryKontiOhneBgKostenart', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, N'Abfrage um alle Konti ohne BgKostenart auszudrucken', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (227, N'CtlBaModulTree', NULL, 1, N'ModulTree', N'KiSS4.Common.KissModulTree', 2120, NULL, N'<Object xsi:type="KiSS4.Common.KissModulTree" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">265, 453</Property>
  <Property name="Name" xsi:type="System.String">CtlBaModulTree</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (228, N'CtlBaPersonAdresse', NULL, 1, N'Adressen erfassen, mutieren und löschen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1197, 796</Property>
</Object>', 0, N'Generisches Control, um Adressen von Person, Institutionen, etc. zu erfassen, mutieren und löschen', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (229, N'CtlBaStammdaten', NULL, 1, N'Stammdaten', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">722, 596</Property>
  <Property name="Name" xsi:type="System.String">CtlBaStammdaten</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBaPerson" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (230, N'CtlBaZahlungsweg', NULL, 1, N'Zahlungsweg - Bank, Post', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1604, 767</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBaZahlungsweg" />
</Property>
</Object>', 0, N'Zahlungswege erfassen, mutieren und löschen', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (231, N'CtlBDEGruppen', NULL, 20, N'BDE-Gruppen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBDEUserGroup" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlBDEGruppen</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">750, 550</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (232, N'CtlBDEGruppenzuteilung', NULL, 20, N'BDE-Gruppenzuteilung', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryUser" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlBDEGruppenzuteilung</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">750, 550</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (233, N'CtlBDELeistungsart', NULL, 20, N'BDE-Leistungsarten', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryData" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlBDELeistungsart</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">900, 600</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (234, N'CtlBDEVisumKostenstelle', NULL, 20, N'Visum Kostenstelle', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">627, 493</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryAuswahl" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (235, N'CtlBookmarkStandard', NULL, 10, N'Textmarken', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">819, 609</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBookmark" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (236, N'CtlBwAuswertungOrganisation', NULL, 5, N'Auswertung und Organisation', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (237, N'CtlBwEinsatzvereinbarung', NULL, 5, N'Einsatzvereinbarung', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (238, N'CtlClass', NULL, 11, N'Control Klasse', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1459, 854</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXClass" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (239, N'CtlCmEvaluation', NULL, 4, N'Evaluation', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">722, 596</Property>
  <Property name="Name" xsi:type="System.String">CtlCmEvaluation</Property>
  <Property name="AutoRefresh" xsi:type="System.Boolean">False</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaCaseManagementMain" />
  </Property>
</Object>', 0, N'INFO: Almost same class as CtlSbEvaluation', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (240, N'CtlCmZielvereinbarung', NULL, 4, N'Zielvereinbarung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">722, 596</Property>
  <Property name="Name" xsi:type="System.String">CtlCmZielvereinbarung</Property>
  <Property name="AutoRefresh" xsi:type="System.Boolean">False</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaCaseManagementMain" />
  </Property>
</Object>', 0, N'INFO: Almost same class as CtlSbZielvereinbarung', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (241, N'CtlDBObject', NULL, 11, N'DBObjekt', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">786, 595</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXdbObject" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (242, N'CtlDesigner', NULL, 11, N'Designer', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1366, 854</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXClass" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (243, N'CtlDesignerLayout', NULL, 11, N'DesignerLayout', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1364, 826</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (244, N'CtlDesignerRule', NULL, 11, N'DesignerRule', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1362, 824</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXClassRule" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (245, N'CtlDocContext', NULL, 10, N'Dokumentenkontext', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">819, 609</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryDocContext" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (246, N'CtlDocTemplate', NULL, 10, N'Dokumentenvorlage', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">819, 614</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryTemplate" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (247, N'CtlDoubleInstitution', NULL, 10, N'Bereinigung doppelte Institutionen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">787, 614</Property>
  <Property name="Name" xsi:type="System.String">CtlDoubleOrganisation</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (248, N'CtlDoublePerson', NULL, 10, N'Doppelte Personen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlDoublePerson</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">787, 614</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (249, N'CtlEdAuswertungsdaten', NULL, 6, N'Auswertungsdaten', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">722, 596</Property>
  <Property name="Name" xsi:type="System.String">CtlEdAuswertungsdaten</Property>
  <Property name="AutoRefresh" xsi:type="System.Boolean">False</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryEdAuswertungsdaten" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [XClass] OFF
GO
COMMIT
GO