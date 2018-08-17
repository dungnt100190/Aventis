SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XClass]
GO
SET IDENTITY_INSERT [XClass] ON
GO
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (4, N'CtlAdBgKostenartWhGefKategorie', NULL, 10, N'ADM - CtlAdBgKostenartWhGefKategorie', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">    <Property name="ActiveSQLQuery">      <Reference name="qryBgKostenart" />    </Property>    <Property name="Name" xsi:type="System.String">CtlKostenart</Property>    <Property name="Size" xsi:type="System.Drawing.Size">1020, 627</Property>  </Object>', 0, N'', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (5, N'CtlAdInstitutionsTypen', NULL, 10, N'Institutionstypen verwalten', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1743, 1055</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryInstTypen" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (6, N'CtlAlimentenbevorschussung', NULL, 1, N'B - CtlAlimentenbevorschussung', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (7, N'CtlArbeit', NULL, 1, N'Arbeit', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">960, 771</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryArbeit" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (8, N'CtlAyBudget', NULL, 6, N'Finanzielle Unterstützung / Budget', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">335, 793</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgBudget" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (9, N'CtlAyEinzelzahlung', NULL, 6, N'Finanzielle Unterstützung / Budget / Budgetposition einfügen / Einzelzahlung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">888, 335</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgPosition" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (10, N'CtlAyFall', NULL, 6, N'Asyl Übersicht', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">335, 793</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaLeistung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (11, N'CtlAyModulTree', NULL, 6, N'Asyl ModulTree', N'KiSS4.Common.KissModulTree', 2120, NULL, N'<Object>
  <Property name="Size">320, 472</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryModulTree" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (12, N'CtlAyPeriode', NULL, 6, N'Finanzielle Unterstützung / Periode', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">335, 793</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgFinanzplan" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (13, N'CtlAyPerioden', NULL, 6, N'Finanzielle Unterstützung / Übersicht über die Masterbudgets', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">335, 793</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgFinanzplan" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (14, N'CtlAyPerson', NULL, 6, N'Finanzielle Unterstützung / Personen im Haushalt / Person', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">335, 793</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgFinanzplan_BaPerson" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (15, N'CtlAyPersonen', NULL, 6, N'Finanzielle Unterstützung / Personen im Haushalt', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">335, 793</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryKlientensystem" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (486, N'CtlAySpezialkonto', NULL, 6, N'Finanzielle Unterstützung / Spezialkonto', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">335, 793</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgSpezkonto" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (487, N'CtlAyZahlungsmodus', NULL, 6, N'Finanzielle Unterstützung / Zahlungsmodus', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">335, 793</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgZahlungsmodus" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (488, N'CtlBaHaushalt', NULL, 1, N'Klientensystem', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1004, 687</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (489, N'CtlBaInstitutionenFachpersonen', NULL, 1, N'Beziehungen des Klienten zu Institutionen und Fachpersonen verwalten', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1192, 787</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBaPersonInstitution" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (490, N'CtlBaModulTree', NULL, 1, N'Basis ModulTree', N'KiSS4.Common.KissModulTree', 2120, NULL, N'<Object xsi:type="KiSS4.Common.KissModulTree" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlBaModulTree</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (491, N'CtlBaPerson', NULL, 1, N'Person Demographie', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">719, 660</Property>
  <Property name="Name" xsi:type="System.String">CtlBaPerson</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBaPerson" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'BSS')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (492, N'CtlBaPersonAdresse', NULL, 1, N'Adressen Demographie', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">745, 601</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'BSS')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (494, N'CtlBaPersonWV', NULL, 1, N'Person Weiterverrechnung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1390, 816</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBaWVCode" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (495, N'CtlBaPersonZUG', NULL, 1, N'B - CtlBaPersonZUG', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">705, 323</Property>
  <Property name="Name" xsi:type="System.String">CtlBaPersonZUG</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBaWVCode" />
  </Property>
</Object>', 0, N'Bern: im Basis nur readonly - Buchhalter erfasst Daten in Klientenbuchhaltung (Maske CtlKbKostenstellen)
200308 mar: Maske i.O.', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (496, N'CtlBaZahlungsweg', NULL, 1, N'Zahlungsverbindung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBaZahlungsweg" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlBaZahlungsweg</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">691, 426</Property>
</Object>', 0, N'Bern: im Basis nur readonly - Buchhalter erfasst Daten in Klientenbuchhaltung (Maske CtlKbKreditor)
200308 mar: Maske i.O.', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (497, N'CtlBDEGruppen', NULL, 20, N'System / Benutzerverwaltung / BDE Verwaltung / BDE-Gruppen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1137, 868</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBDEUserGroup" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (16, N'CtlBDEGruppenzuteilung', NULL, 20, N'System / Benutzerverwaltung / BDE Verwaltung / Gruppenzuteilung', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">669, 614</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryUser" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (17, N'CtlBDELeistungsart', NULL, 20, N'System / Benutzerverwaltung / BDE Verwaltung / Leistungsarten', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">669, 614</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryData" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (18, N'CtlBDEVisumKostenstelle', NULL, 20, N'Anwendung / Visum Kostenstelle / Visum Kostenstelle / Visum Kostenstelle', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (19, N'CtlBfsAbfrageDummy', NULL, 16, NULL, N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlBfsAbfrageDummy</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (20, N'CtlBfsDokumente', NULL, 16, N'System / Sostat / Hilfe / Dokumente', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (21, N'CtlBfsDossier', NULL, 16, N'System / Sostat / Bearbeiten / Dossiers / Dossier', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBFSDossierPerson" />
  </Property>
  <Property name="Location" xsi:type="System.Drawing.Point">5, 0</Property>
  <Property name="Name" xsi:type="System.String">CtlBfsDossier</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">722, 497</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (22, N'CtlBfsDossiers', NULL, 16, N'System / Sostat / Bearbeiten / Dossiers', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">875, 433</Property>
  <Property name="Name" xsi:type="System.String">CtlBfsDossiers</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryClientTree" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (23, N'CtlBfsExport', NULL, 16, N'System / Sostat / Bearbeiten / Plausib./Export', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlBfsExport</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryDossier" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (24, N'CtlBfsFragenkatalog', NULL, 16, N'System / Sostat / Stammdaten / Fragenkatalog', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">988, 745</Property>
  <Property name="Name" xsi:type="System.String">CtlBfsFragenkatalog</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBFSFrage" />
  </Property>
  <Property name="Location" xsi:type="System.Drawing.Point">12, 0</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (25, N'CtlBfsImport', NULL, 16, N'System / Sostat / Bearbeiten / Import', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlBfsImport</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaLeistung" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (26, N'CtlBfsKonfiguration', NULL, 16, N'System / Sostat / Stammdaten / Konfiguration', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlBfsKonfiguration</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">681, 550</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (27, N'CtlBfsQueryKennzahlen', NULL, 16, N'System / Sostat / Abfragen / Kennzahlen', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (28, N'CtlBfsQueryPlausiFehler', NULL, 16, N'System / Sostat / Abfragen / Plausifehler', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>    <Property name="Size">1276, 491</Property>    <Property name="ActiveSQLQuery">      <Reference name="qryQuery" />  </Property>  </Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (29, N'CtlBfsQueryVariablen', NULL, 16, N'System / Sostat / Abfragen / BFS Variablen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>    <Property name="Size">1014, 780</Property>    <Property name="ActiveSQLQuery">      <Reference name="qryQuery" />  </Property>  </Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (30, N'CtlBfsWertelisten', NULL, 16, N'System / Sostat / Stammdaten / Wertelisten', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBFSLOVCode" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlBfsWertelisten</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">744, 523</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (31, N'CtlBgAlgErwerbsunkosten', NULL, 3, N'S - CtlBgAlgErwerbsunkosten', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (32, N'CtlBgAlimente', NULL, 3, N'Finanzplan / Alimentenguthaben', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">995, 840</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgPosition" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (33, N'CtlBgColors', NULL, 10, N'ADM - CtlBgColors', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1103, 867</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryColor" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (34, N'CtlBgErwerbseinkommen', NULL, 3, N'Finanzplan / Erwerbseinkommen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">847, 643</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgPosition" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (35, N'CtlBgGrundbedarf', NULL, 3, N'Finanzplan / Grundbedarf', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">847, 643</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgPosition" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (36, N'CtlBgKrankenkasse', NULL, 3, N'Finanzplan / Med. Grundversorgung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">847, 643</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgPosition" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (37, N'CtlBgPositionsart', NULL, 10, N'ADM - CtlBgPositionsart', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgPositionsart" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlBgPositionsart</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">800, 600</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (38, N'CtlBgSilAHVBeitrag', NULL, 3, N'Finanzplan / Situationsbedingte Leistungen / AHV Beiträge', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgPosition" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlBgSilAHVBeitrag</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">713, 520</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (39, N'CtlBgSilKrankheitBehinderungLeistung', NULL, 3, N'Finanzplan / Situationsbedingte Leistungen / Krankheits- und behinderungsbedingte Leistungen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgPosition" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlBgSilKrankheitBehinderungLeistung</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">713, 520</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (40, N'CtlBgSilSituationsbedingteLeistungen', NULL, 3, N'Finanzplan / Situationsbedingte Leistungen / Situationsbedingte Leistungen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgPosition" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlBgSilSituationsbedingteLeistungen</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">713, 520</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (41, N'CtlBgSilTherapieEntzug', NULL, 3, N'Finanzplan / Situationsbedingte Leistungen / Kosten von Therapie und Entzugsmassnahmen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgPosition" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlBgSilTherapieEntzug</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">713, 520</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (42, N'CtlBgSilWiedereingliederung', NULL, 3, N'Finanzplan / Situationsbedingte Leistungen / Wiedereingliederung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgPosition" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlBgSilWiedereingliederung</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">713, 520</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (43, N'CtlBgUebersicht', NULL, 3, N'Finanzplan Übersicht', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">804, 670</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgPosition" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (44, N'CtlBgVermoegen', NULL, 3, N'Finanzplan / Vermögen und Vermögensverbrauch', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">995, 840</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgPosition" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (45, N'CtlBgVersicherung', NULL, 3, N'Finanzplan / Einkommen aus Versicherungsleistungen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">995, 840</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgPosition" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (46, N'CtlBgWohnkosten', NULL, 3, N'Finanzplan / Wohnkosten', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">847, 643</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgPosition" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (47, N'CtlBgZulagenEFB', NULL, 3, N'Finanzplan / Zulagen/EFB', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">847, 643</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgPosition" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (48, N'CtlBookmarkDyna', NULL, 10, N'ADM - CtlBookmarkDyna', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">835, 655</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryDynaField" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (440, N'CtlBookmarkStandard', NULL, 10, N'ADM - CtlBookmarkStandard', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">819, 607</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBookmark" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (441, N'CtlClass', NULL, 11, N'DSGN - CtlClass', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1077, 692</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXClass" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (442, N'CtlCreationModification', NULL, -7, NULL, N'KiSS4.Gui.KissComplexControl', 200, NULL, N'<Object>
  <Property name="Size">376, 44</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (443, N'CtlDBObject', NULL, 11, N'DSGN - CtlDBObject', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">930, 672</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXdbObject" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (444, N'CtlDemographieH', NULL, 1, N'Person Demographie Historisiert', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">719, 620</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBaPerson" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (445, N'CtlDesigner', NULL, 11, N'DSGN - CtlDesigner', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1109, 665</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXClass" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (446, N'CtlDesignerLayout', NULL, 11, N'DSGN - CtlDesignerLayout', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1107, 637</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (447, N'CtlDesignerRule', NULL, 11, N'DSGN - CtlDesignerRule', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1105, 635</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXClassRule" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (448, N'CtlDocContext', NULL, 10, N'ADM - CtlDocContext', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">974, 639</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryDocContext" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (449, N'CtlDocTemplate', NULL, 10, N'ADM - CtlDocTemplate', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">819, 614</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryDocTemplate" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (450, N'CtlDoubleInstitution', NULL, 10, N'Bereinigung doppelte Institutionen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1116, 885</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (451, N'CtlDoublePerson', NULL, 10, N'ADM - CtlDoublePerson', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">832, 614</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (452, N'CtlDynaMask', NULL, -7, NULL, N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">679, 301</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryData" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (453, N'CtlErfassungMutation', NULL, -7, N'Erfassung/Mutation', N'KiSS4.Gui.KissComplexControl', 200, NULL, N'<Object xsi:type="KiSS4.Gui.KissComplexControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlErfassungMutation</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">222, 38</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (454, N'CtlFaAktennotiz', NULL, 2, N'Besprechung / Aktennotiz', N'KiSS4.Common.KissSearchLogischesLoeschenUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1192, 787</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaAktennotiz" />
</Property>
</Object>', 0, N'Besprechung', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (455, N'CtlFaBeratungsperiode', NULL, 2, N'Beratungsperiode', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">847, 643</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaLeistung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (49, N'CtlFaBeratungsphase', NULL, 2, N'Intake / Beratungsphase', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">335, 793</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryPhase" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (50, N'CtlFaDokumentAblage', NULL, 2, N'Dokumentablage', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (51, N'CtlFaDokumente', NULL, 2, N'Korrespondenz / Dokumente', N'KiSS4.Common.KissSearchLogischesLoeschenUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1192, 787</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaDokumente" />
</Property>
</Object>', 0, N'Korrespondenz', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (52, N'CtlFall', NULL, -1, N'Fallbearbeitung Control', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1126, 677</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (53, N'CtlFallLeistungBetrifftPerson', NULL, 21, N'Anwendung / (Teil der) Pendenzverwaltung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">446, 114</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="_dataSource" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (54, N'CtlFallZugriff', NULL, 10, N'ADM - CtlFallZugriff', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1103, 869</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaLeistung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (55, N'CtlFaModulTree', NULL, 2, N'Fallführung ModulTree', N'KiSS4.Common.KissModulTree', 2120, NULL, N'<Object>
  <Property name="Size">269, 645</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryModulTree" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (56, N'CtlFaSozialSystem', NULL, 2, N'Sozialsystem', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">847, 643</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (57, N'CtlFaUebersichtsgrafik', NULL, 2, N'F - CtlFaUebersichtsgrafik', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (58, N'CtlFaWeisung', NULL, 2, N'Weisung', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>    <Property name="Size">863, 598</Property>  </Object>', 0, N'Klasse um Weisungen zu handeln', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (59, N'CtlFaZeitlichePlanung', NULL, 2, N'CtlFaZeitlichePlanung', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, N'Zeitliche Planung', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (60, N'CtlFibuBankPost', NULL, 14, N'Anwendung / Mandatsbuchhaltung / Stammdaten / Banken/Post', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1114, 869</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFbBank" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (61, N'CtlFibuBelegNr', NULL, 14, N'Anwendung / Mandatsbuchhaltung / Stammdaten / Belegnummern', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1114, 869</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFbBelegNr" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (62, N'CtlFibuBilanzErfolg', NULL, 14, N'Anwendung / Mandatsbuchhaltung / Auswerten / Bilanz/Erfolg', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">454, 838</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBilanz" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (63, N'CtlFibuBuchung', NULL, 14, N'Anwendung / Mandatsbuchhaltung / Bearbeiten / Buchen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">842, 550</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryLetzteBelegNr" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (64, N'CtlFibuBuchungCode', NULL, 14, N'Anwendung / Mandatsbuchhaltung / Stammdaten / Buchungscodes', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">454, 838</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFbBuchungCode" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (65, N'CtlFibuBuchungskreis', NULL, 14, N'Anwendung / Mandatsbuchhaltung / Stammdaten / Buchungskreise', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">454, 838</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFbBuchungskreis" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (346, N'CtlFibuDauerauftrag', NULL, 14, N'Anwendung / Mandatsbuchhaltung / Stammdaten / Daueraufträge', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1114, 869</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFbDauerauftrag" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (347, N'CtlFibuDTATransfer', NULL, 14, N'Anwendung / Mandatsbuchhaltung / e-Banking / e-Journal', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1114, 869</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryDTATransfered" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (348, N'CtlFibuDTAZahlungsLauf', NULL, 14, N'Anwendung / Mandatsbuchhaltung / e-Banking / e-Zahlungslauf', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1114, 869</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryDTABuchungErwartung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (349, N'CtlFibuDTAZugang', NULL, 14, N'Anwendung / Mandatsbuchhaltung / e-Banking / e-Zugang', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1114, 869</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFbDTAZugang" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (350, N'CtlFibuIbanGenerieren', NULL, 14, N'Anwendung / Mandatsbuchhaltung / Stammdaten / IBAN generieren', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1754, 1057</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFbZahlungsweg" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (351, N'CtlFibuJournal', NULL, 14, N'Anwendung / Mandatsbuchhaltung / Auswerten / Journal', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">454, 838</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (352, N'CtlFibuKonto', NULL, 14, N'Anwendung / Mandatsbuchhaltung / Bearbeiten / Kontenplan', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1114, 869</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryKonto" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (353, N'CtlFibuKontoblatt', NULL, 14, N'Anwendung / Mandatsbuchhaltung / Auswerten / Kontoblatt', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">454, 838</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryKontoblaetter" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (354, N'CtlFibuKreditor', NULL, 14, N'Anwendung / Mandatsbuchhaltung / Stammdaten / Kreditoren', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">454, 838</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFbKreditor" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (355, N'CtlFibuPeriode', NULL, 14, N'Anwendung / Mandatsbuchhaltung / Bearbeiten / Perioden', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1114, 869</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryPeriode" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (356, N'CtlFibuTeam', NULL, 14, N'Anwendung / Mandatsbuchhaltung / Stammdaten / Teams', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1114, 869</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFbTeam" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (357, N'CtlFibuZahlungsWeg', NULL, 14, N'Anwendung / Mandatsbuchhaltung / Stammdaten / Daueraufträge (unterer Abschnitt)', N'KiSS4.Gui.KissComplexControl', 200, NULL, N'<Object>
  <Property name="Size">904, 188</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (358, N'CtlFinanzen', NULL, 1, N'B - CtlFinanzen', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (359, N'CtlGesundheit', NULL, 1, N'Gesundheit', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">995, 840</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryGesundheit" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (360, N'CtlGotoFall', NULL, -7, NULL, N'KiSS4.Gui.KissComplexControl', 200, NULL, N'<Object>
  <Property name="Size">146, 24</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (361, N'CtlGvAbklaerendeStelle', NULL, 27, N'Fallverlauf / Aktenführung / Dokumentation / Gesuchverwaltung / Abklärende Stelle', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (362, N'CtlGvAntrag', NULL, 27, N'Fallverlauf / Aktenführung / Dokumentation / Gesuchverwaltung / Antrag', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (363, N'CtlGvAuflagen', NULL, 27, N'Fallverlauf / Aktenführung / Dokumentation / Gesuchverwaltung / Auflagen', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (364, N'CtlGvAuszahlung', NULL, 27, N'Fallverlauf / Aktenführung / Dokumentation / Gesuchverwaltung / Auszahlung', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (365, N'CtlGvBegruendung', NULL, 27, N'Fallverlauf / Aktenführung / Dokumentation / Gesuchverwaltung / Begründung', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (66, N'CtlGvBeilagenDokumente', NULL, 27, N'Fallverlauf / Aktenführung / Dokumentation / Gesuchverwaltung / Beilagen/Dokumente', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (67, N'CtlGvBewilligung', NULL, 27, N'Fallverlauf / Aktenführung / Dokumentation / Gesuchverwaltung / Bewilligung', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (68, N'CtlGvGesuchverwaltung', NULL, 27, N'Fallverlauf / Aktenführung / Dokumentation / Gesuchverwaltung', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (69, N'CtlHyperlink', NULL, 10, N'ADM - CtlHyperlink', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">819, 612</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryHyperlink" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (70, N'CtlHyperlinkContext', NULL, 10, N'ADM - CtlHyperlinkContext', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">819, 612</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryHyperlinkContext" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (71, N'CtlIcon', NULL, 11, N'DSGN - CtlIcon', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">930, 672</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryIcon" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (72, N'CtlIkAbklaerungen', NULL, 4, N'Abklärung / Abklärungen', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, N'Inkasso-Abklärungen', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (73, N'CtlIkBetreibungenVerlustscheine', NULL, 4, N'Betreibungen, Verlustscheine', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBetreibung" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlIkBetreibungenVerlustscheine</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">808, 568</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (74, N'CtlIkForderungen', NULL, 4, N'Inkasso Forderungen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryIkForderung" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlIkForderungen</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">706, 589</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (75, N'CtlIkGlaeubiger', NULL, 4, N'Gläubiger', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">695, 561</Property>
  <Property name="Name" xsi:type="System.String">CtlIkGlaeubiger</Property>
  <Property name="Location" xsi:type="System.Drawing.Point">3, 0</Property>
  <Event name="SaveData" xsi:type="System.String">CtlIkRechtstitelGlaeubiger_SaveData</Event>
  <Event name="MoveNext" xsi:type="System.String">CtlIkRechtstitelGlaeubiger_MoveNext</Event>
  <Event name="MoveLast" xsi:type="System.String">CtlIkRechtstitelGlaeubiger_MoveLast</Event>
  <Event name="UndoDataChanges" xsi:type="System.String">CtlIkRechtstitelGlaeubiger_UndoDataChanges</Event>
  <Event name="MoveFirst" xsi:type="System.String">CtlIkRechtstitelGlaeubiger_MoveFirst</Event>
  <Event name="RefreshData" xsi:type="System.String">CtlIkRechtstitelGlaeubiger_RefreshData</Event>
  <Event name="MovePrevious" xsi:type="System.String">CtlIkRechtstitelGlaeubiger_MovePrevious</Event>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (631, N'CtlIkKontoauszug', NULL, 4, N'Kontoauszug', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <InstanceDescriptor xsi:type="KiSS4.DB.SqlQuery">
      <Property name="HostControl">
        <Reference name="CtlIkKontoauszug" />
      </Property>
      <Property name="SelectStatement" xsi:type="System.String">SELECT DISTINCT 
      FAL.FaFallID, 
      FAL.SchuldnerBaPersonID, 
      Schuldner = PRS1.Name + isNull('', '' + PRS1.Vorname, ''''), 
      PRS.Name, 
      PRS.Vorname
FROM  FaLeistung FAL
          LEFT JOIN  BaPerson PRS ON FAL.BaPersonID = PRS.BaPersonID 
          LEFT JOIN  BaPerson PRS1 ON FAL.SchuldnerBaPersonID = PRS1.BaPersonID
WHERE (FAL.FaFallID = {0})</Property>
    </InstanceDescriptor>
  </Property>
  <Property name="Name" xsi:type="System.String">CtlIkKontoauszug</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">715, 584</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (632, N'CtlIkLandesindex', NULL, 4, N'System / Modul Konfiguration / Inkasso / Landesindex', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryLandesindex" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlIkLandesIndex</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">824, 506</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (633, N'CtlIkLeistung', NULL, 4, N'Inkassoleistung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaLeistung" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlIkLeistung</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">646, 649</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (634, N'CtlIkModulTree', NULL, 4, N'Inkasso ModulTree', N'KiSS4.Common.KissModulTree', 2120, NULL, N'<Object xsi:type="KiSS4.Common.KissModulTree" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlIkModulTree</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">265, 618</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (635, N'CtlIkMonatszahlen', NULL, 4, N'Alimente / Rechtstitel und Gläubiger / Monatszahlen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryMonatszahlen" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlIkMonatszahlen</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">720, 588</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (636, N'CtlIkMonatszahlenEinmalig', NULL, 4, N'Inkasso Forderungen - Monatszahlen Einmalig', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryIkPosition" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlIkMonatszahlenEinmalig</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">706, 421</Property>
</Object>', 0, N'Wird nicht im Rechtstitel gebraucht -- nur in den Monatszahlen', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (637, N'CtlIkMonatszahlenSaldo', NULL, 4, N'Inkasso Forderungen - Monatszahlen Saldo', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlIkMonatszahlenSaldo</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">719, 505</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (638, N'CtlIkMonatszahlenVerrechnung', NULL, 4, N'Inkasso Forderungen - Monatszahlen Verrechnung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryVerrechnung" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlIkMonatszahlenVerrechnung</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">690, 468</Property>
</Object>', 0, N'Wird nicht im Rechtstitel gebraucht', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (76, N'CtlIkRechtlicheMassnahmenInkassofall', NULL, 4, N'Rechtliche Massnahmen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryIkAnzeige" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlIkRechtlicheMassnahmenInkassofall</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">680, 552</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (77, N'CtlIkRechtlicheMassnahmenSchuldner', NULL, 4, N'Rechtliche Massnahmen Übersicht', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryIkAnzeige" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlIkRechtlicheMassnahmenSchuldner</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">680, 760</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (78, N'CtlIkRechtstitel', NULL, 4, N'Alimente / Rechtstitel und Gläubiger', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryIkRechtstitel" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlIkRechtstitel</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">710, 580</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (79, N'CtlIkRechtstitelForderung', NULL, 4, N'Alimente / Rechtstitel und Gläubiger / Periodische Forderungen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryIkForderung" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlIkRechtstitelForderung</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">687, 514</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (80, N'CtlKaAKPhasen', NULL, 7, N'Abklärung / Phasen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1095, 725</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryPhasen" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (81, N'CtlKaAKZuweiser', NULL, 7, N'Abklärung / ZuweiserIn', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">946, 740</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryZuweiser" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (82, N'CtlKaAnweisung', NULL, 7, N'Allgemein / Zuteilung Fachbereich / Zu-/Anweisungen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">855, 844</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryAnweisung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (83, N'CtlKaAssistenz', NULL, 7, N'Assistenz / Prozess As', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (84, N'CtlKaBetriebe', NULL, 7, N'KA / KA Einsatzorte / Einsatzorte / Betriebe', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryKaBetrieb" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKaBetriebe</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">793, 635</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (85, N'CtlKaEinsatzplaetze', NULL, 7, N'KA / KA Einsatzorte / Einsatzorte / Einsatzplätze', N'KiSS4.Arbeit.CtlKaEinsatzplaetzeDetail', NULL, NULL, N'<Object xsi:type="KiSS4.Arbeit.CtlKaEinsatzplaetzeDetail" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlKaEinsatzplaetze</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (498, N'CtlKaEinsatzplaetzeDetail', NULL, 7, N'KA / KA Einsatzorte / Vermittlung / Einsatzplätze suchen', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">809, 579</Property>
  <Property name="Name" xsi:type="System.String">CtlKaEinsatzplaetzeDetail</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryKaEinsatzplatz" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (499, N'CtlKaExterneBildung', NULL, 7, N'Allgemein / Bildung/Kurse / externe Bildung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryExterneBildung" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKaExterneBildung</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">718, 624</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (500, N'CtlKaInizioEinsaetze', NULL, 7, N'Inizio / Einsätze', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryInizioVorschlag" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKaInizioEinsaetze</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">750, 558</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (501, N'CtlKaInizioUebersicht', NULL, 7, N'Inizio / Übersicht', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryInizioUebersicht" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKaInizioUebersicht</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">618, 481</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (502, N'CtlKaInizioVermittlungsprofil', NULL, 7, N'Inizio / Vermittlungsprofil', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryInizioVermittlung" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKaInizioVermittlungsprofil</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">675, 574</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (503, N'CtlKaIntegBildung', NULL, 7, N'Allgemein / Bildung/Kurse / interne Bildung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">855, 844</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryIntegBildung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (504, N'CtlKaLehrberufe', NULL, 7, N'KA / Lehrberufe', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object xsi:type="KiSS4.Gui.KissChildForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryLehrberufe" />
  </Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">684, 368</Property>
  <Property name="Name" xsi:type="System.String">CtlKaLehrberufe</Property>
  <Property name="Text" xsi:type="System.String">Lehrberufe</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (505, N'CtlKaModulTree', NULL, 7, N'Arbeit Modultree', N'KiSS4.Common.KissModulTree', 2120, NULL, N'<Object xsi:type="KiSS4.Common.KissModulTree" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlKaModulTree</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (506, N'CtlKaPraesenzAllgemein', NULL, 7, N'Allgemein / Präsenzverwaltung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">855, 844</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryPraesenz" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (507, N'CtlKaProzess', NULL, 7, N'K - CtlKaProzess', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (508, N'CtlKaProzessAK', NULL, 7, N'Abklärung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">855, 844</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (86, N'CtlKaProzessAS', NULL, 7, N'Assistenz', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">946, 740</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (87, N'CtlKaProzessBIBIP', NULL, 7, N'Vermittlung BI/BIP', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaLeistung" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKaProzessBIBIP</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">574, 337</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (88, N'CtlKaProzessInizio', NULL, 7, N'Inizio', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaLeistung" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKaProzessInizio</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">574, 337</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (89, N'CtlKaProzessQE', NULL, 7, N'Qualifizierung Erwachsene', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">946, 740</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFall" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (90, N'CtlKaProzessQJ', NULL, 7, N'Qualifizierung Jugend', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">946, 740</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (91, N'CtlKaProzessSI', NULL, 7, N'Vermittlung SI', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaLeistung" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKaProzessSI</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">574, 337</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (92, N'CtlKaQEEPQ', NULL, 7, N'Qualifizierung Erwachsene / EPQ', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">990, 735</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryEPQ" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (93, N'CtlKaQEJobtimum', NULL, 7, N'Qualifizierung Erwachsene / Jobtimum', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">946, 740</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryJobtimum" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (94, N'CtlKaQJBildung', NULL, 7, N'Qualifizierung Jugend / Bildung', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, N'', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (95, N'CtlKaQJExtern', NULL, 7, NULL, N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (96, N'CtlKaQJExterneEinsaetze', NULL, 7, N'Qualifizierung Jugend / Extern', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryQJVorschlag" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKaQJExterneEinsaetze</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">718, 586</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (97, N'CtlKaQJExternVermittlungsprofil', NULL, 7, N'Qualifizierung Jugend / Extern / Vermittlungsprofil', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryQJVermittlung" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKaQJExternVermittlungsprofil</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">675, 574</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (426, N'CtlKaQJIntake', NULL, 7, N'Qualifizierung Jugend / Intake', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">946, 740</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryIntake" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (427, N'CtlKaQJProzess', NULL, 7, N'Qualifizierung Jugend / Prozess', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">946, 740</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryProzess" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (428, N'CtlKaQJPZAssessment', NULL, 7, N'Qualifizierung Jugend / Prozess / Assessment', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">916, 803</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQJAssessment" />
</Property>
</Object>', 0, N'', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (429, N'CtlKaQJPZSchlussbericht', NULL, 7, N'Qualifizierung Jugend / Prozess / Schlussbericht', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">946, 740</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qrySchlussbericht" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (430, N'CtlKaQJPZZielvereinbarung', NULL, 7, N'Qualifizierung Jugend / Prozess / Zielvereinbarung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">946, 740</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryZielvereinbarung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (431, N'CtlKaQJUebersicht', NULL, 7, N'Qualifizierung Jugend / Übersicht', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">946, 740</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (432, N'CtlKaQJVereinbarung', NULL, 7, N'Qualifizierung Jugend / Vereinbarung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">946, 740</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVereinbarung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (433, N'CtlKaTransfer', NULL, 7, N'Transfer', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">995, 668</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFall" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (434, N'CtlKaTransferProzess', NULL, 7, N'Transfer / Prozess', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1635, 1012</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryTransfer" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (435, N'CtlKaVerlauf', NULL, 7, N'KA / Verlauf', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, N'KA - Allgemein - Verlauf', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (436, N'CtlKaVermittlungBIBIPEinsaetzeBIP', NULL, 7, N'Vermittlung BI/BIP / Einsätze BIP', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">726, 558</Property>
  <Property name="Name" xsi:type="System.String">CtlKaVermittlungBIBIPEinsaetzeBIP</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBIPVorschlag" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (437, N'CtlKaVermittlungBIBIPProzess', NULL, 7, N'Vermittlung BI/BIP / Prozess', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryVermittlungBIBIP" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKaVermittlungBIBIPProzess</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">682, 524</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (438, N'CtlKaVermittlungBIBIPStellenBI', NULL, 7, N'Vermittlung BI/BIP / Stellen BI', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBIBewerbung" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKaVermittlungBIBIPStellenBI</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">722, 557</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (439, N'CtlKaVermittlungBIBIPUebersicht', NULL, 7, N'Vermittlung BI/BIP / Übersicht', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryVermittlungBIBIP" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKaVermittlungBIBIPUebersicht</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">714, 590</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (98, N'CtlKaVermittlungBIBIPVermittlungsprofil', NULL, 7, N'Vermittlung BI/BIP / Vermittlungsprofil', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBIBIPVermittlung" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKaVermittlungBIBIPVermittlungsprofil</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">681, 542</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (99, N'CtlKaVermittlungEinsatzplatzSuchen', NULL, 7, N'KA / KA Einsatzorte / Vermittlung / Einsatzplätze suchen', N'KiSS4.Arbeit.CtlKaEinsatzplaetzeDetail', NULL, NULL, N'<Object xsi:type="KiSS4.Arbeit.CtlKaEinsatzplaetzeDetail" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlKaVermittlungEinsatzplatzSuchen</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">809, 605</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (100, N'CtlKaVermittlungKandidatenSuchen', NULL, 7, N'KA / KA Einsatzorte / Vermittlung / Kandidat/innen suchen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlKaVermittlungKandidatenSuchen</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">793, 473</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (101, N'CtlKaVermittlungResultatVorschlag', NULL, 7, N'KA / KA Einsatzorte / Vermittlung / Resultat Vorschlag', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryKandidaten" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKaVermittlungResultatVorschlag</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">561, 446</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (102, N'CtlKaVermittlungSIEinsaetze', NULL, 7, N'Vermittlung SI / Einsätze', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qrySIVorschlag" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKaVermittlungSIEinsaetze</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">722, 557</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (103, N'CtlKaVermittlungSIUebersicht', NULL, 7, N'Vermittlung SI / Übersicht', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryVermittlungSI" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKaVermittlungSIUebersicht</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">618, 497</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (104, N'CtlKaVermittlungSIVermittlungsprofil', NULL, 7, N'Vermittlung SI / Vermittlungsprofil', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qrySIVermittlung" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKaVermittlungSIVermittlungsprofil</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">681, 617</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (105, N'CtlKaZuteilFachbereich', NULL, 7, N'Allgemein / Zuteilung Fachbereich', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">930, 635</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryZuteilung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (509, N'CtlKbAuszahlungVerbuchen', NULL, 17, N'Anwendung / Klientenbuchhaltung / Bearbeiten / Auszahlungen manuell verbuchen', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlKbAuszahlungVerbuchen</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">800, 503</Property>
</Object>', 0, N'stabil ist KiSS4_BSS_Master (40)
ab 28.10.08 stabil: KiSS4_BSS_Master (56)', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (510, N'CtlKbBankPost', NULL, 17, N'Anwendung / Klientenbuchhaltung / Stammdaten / Bankenstamm', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBaBank" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKbBankPost</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">759, 425</Property>
</Object>', 0, N'Bankenstamm', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (511, N'CtlKbBelegeKorrigieren', NULL, 17, N'Anwendung / Klientenbuchhaltung / Bearbeiten / Beleg Korrektur', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryKbBuchungSuche" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKbBelegeKorrigieren</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">818, 581</Property>
</Object>', 0, N'Build Nr. 210->211: Anpassung label von Leistungart (ZH) in Kostenart (BernerStandard)', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (512, N'CtlKbBelegImportIK', NULL, 17, N'Anwendung / Klientenbuchhaltung / Inkasso / Belegimport aus Inkasso', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryListe" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKbBelegImportIK</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">768, 630</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (513, N'CtlKbBelegImportSH', NULL, 17, N'Anwendung / Klientenbuchhaltung / Budget / Belegimport aus Budgets', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">778, 675</Property>
  <Property name="Name" xsi:type="System.String">CtlKbBelegImportSH</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBeleg" />
  </Property>
  <Property name="MinimumSize" xsi:type="System.Drawing.Size">778, 0</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (514, N'CtlKbBelegkreise', NULL, 17, N'Anwendung / Klientenbuchhaltung / Stammdaten / Belegkreise', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBelegKreis" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKbBelegkreise</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">825, 535</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
GO
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (515, N'CtlKbBuchung', NULL, 17, N'Anwendung / Klientenbuchhaltung / Bearbeiten / Buchungen erfassen', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">738, 651</Property>
  <Property name="Name" xsi:type="System.String">CtlKbBuchung</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryKbBuchung" />
  </Property>
  <Property name="MinimumSize" xsi:type="System.Drawing.Size">738, 651</Property>
</Object>', 0, N'Stabil ist 623
Weitere Felder erfasst durch Rahel (630) 15.10.08, Prüfung+Anpassung von Christoph 16.10.08 , danach Freigabe durch Alain 17.10.08
Wurde getestet und 20.10.08 Produktiv in Bern', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (516, N'CtlKbDummy', NULL, 17, N'KB - CtlKbDummy', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlKbDummy</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (106, N'CtlKbIbanGenerieren', NULL, 17, N'Anwendung / Klientenbuchhaltung / Stammdaten / IBAN generieren', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">    <Property name="ActiveSQLQuery">      <Reference name="qryIBAN" />    </Property>    <Property name="Name" xsi:type="System.String">CtlKbIbanGenerieren</Property>    <Property name="Size" xsi:type="System.Drawing.Size">970, 703</Property>  </Object>', 0, N'Klasse um IBAN Nummern zu generieren', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (107, N'CtlKbKonto', NULL, 17, N'Anwendung / Klientenbuchhaltung / Stammdaten / Kontenplan', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryKbKonto" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKbKonto</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">842, 728</Property>
</Object>', 0, N'mar: i.O. im Test', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (108, N'CtlKbKostenstelleErfassung', NULL, 17, N'Anwendung / Klientenbuchhaltung / Stammdaten / Kostenstelle erfassen', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (109, N'CtlKbKostenstellen', NULL, 17, N'Anwendung / Klientenbuchhaltung / Stammdaten / Kostenstelle WV erfassen', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBaPerson" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKbKostenstellen</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">840, 535</Property>
</Object>', 0, N'Bern: Kostenstellen werden automatisch angelegt (Personen-ID + Name). Keine manuelles Erstellen von Kostenstellen 
Standard: noch offen 
iBE: Kostenstelle wird automatisch angelegt, jedoch anderer Nummernkreis als Bern (800''000)', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (110, N'CtlKbKostenstelleZuweisung', NULL, 17, N'Anwendung / Klientenbuchhaltung / Stammdaten / Kostenstelle zuweisen', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (111, N'CtlKbKreditor', NULL, 17, N'Anwendung / Klientenbuchhaltung / Stammdaten / Kreditoren', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryKreditor" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKbKreditor</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">699, 685</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (112, N'CtlKbMandant', NULL, 17, N'Anwendung / Klientenbuchhaltung / Stammdaten / Mandanten', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryMandant" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKbMandant</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">842, 550</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (113, N'CtlKbPeriode', NULL, 17, N'Anwendung / Klientenbuchhaltung / Bearbeiten / Geschäftsperioden', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">842, 550</Property>
  <Property name="Name" xsi:type="System.String">CtlKbPeriode</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryPeriode" />
  </Property>
</Object>', 0, N'Test
TODO: btnVerbuchen ist zurzeit immer ReadOnly', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (394, N'CtlKbTransfer', NULL, 17, N'Anwendung / Klientenbuchhaltung / el. Zahlungsverkehr / Zahlungsjournal', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">830, 545</Property>
  <Property name="Name" xsi:type="System.String">CtlKbTransfer</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryZahlungslauf" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (395, N'CtlKbWVEinzelposten', NULL, 17, N'Anwendung / Klientenbuchhaltung / Weiterverrechnung / WV-Abrechnung', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryKbWVEinzelposten" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKbWVEinzelposten</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">1000, 650</Property>
</Object>', 0, N'Maske für ZUG-Abrechnung', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (396, N'CtlKbZahlungseingang', NULL, 17, N'Anwendung / Klientenbuchhaltung / Bearbeiten / Zahlungseingang erfassen', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">825, 596</Property>
  <Property name="Name" xsi:type="System.String">CtlKbZahlungseingang</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryZahlungseingang" />
  </Property>
  <Property name="Location" xsi:type="System.Drawing.Point">0, 270</Property>
</Object>', 0, N'Test
TODO alv-Buchungen noch nicht fertig: kontennr. noch richtig setzen. weiteres?

INFO: BuildNr. 550 checked in by cjaeggi because of changes made for KbBuchungKostenart-extensions', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (397, N'CtlKbZahlungskonto', NULL, 17, N'Anwendung / Klientenbuchhaltung / el. Zahlungsverkehr / Zahlungskonten', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryKbZahlungskonten" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKbZahlungskonto</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">825, 535</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (398, N'CtlKbZahlungslauf', NULL, 17, N'Anwendung / Klientenbuchhaltung / el. Zahlungsverkehr / Zahlungslauf', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBuchung" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKbZahlungslauf</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">834, 569</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (399, N'CtlKbZahlungslaufValuta', NULL, 10, N'ADM - CtlKbZahlungslaufValuta', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryZahlungslauf" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKbZahlungslaufValuta</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">808, 523</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (400, N'CtlKesMassnahme', NULL, 5, N'Vormundschaftliche Massnahme / KES-Massnahmen', N'KiSS4.Common.KissSearchLogischesLoeschenUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1635, 1052</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryKesMassnahme" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (401, N'CtlKGSKostenstelleSAR', NULL, -7, NULL, N'KiSS4.Gui.KissComplexControl', 200, NULL, NULL, 0, N'Control für KGS, Kostenstelle, SAR', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (402, N'CtlKiSSNewodManuellerImport', NULL, 25, N'SST - CtlKiSSNewodManuellerImport', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>    <Property name="Size">627, 493</Property>    </Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'Newod')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (403, N'CtlKiSSNewodMapping', NULL, 25, N'Anwendung / NEWOD Schnittstelle / Mapping / KiSS-Newod Mapping', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
		  <Property name="Size">627, 493</Property>
		</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'Newod')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (404, N'CtlKiSSNewodMarkierungen', NULL, 25, N'Anwendung / NEWOD Schnittstelle / Mapping / Markierungen setzen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
		<Property name="Size">627, 493</Property>
		</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'Newod')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (405, N'CtlKiSSNewodMutationen', NULL, 25, N'Anwendung / NEWOD Schnittstelle / Mapping / Mutationen abholen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
		<Property name="Size">627, 493</Property>
		</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'Newod')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (406, N'CtlKiSSNewodProtokolle', NULL, 25, N'Anwendung / NEWOD Schnittstelle / Mapping / Protokolle', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
		<Property name="Size">627, 493</Property>
		</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'Newod')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (114, N'CtlKostenart', NULL, 10, N'ADM - CtlKostenart', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgKostenart" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlKostenart</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">1020, 627</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (115, N'CtlLogischesLoeschen', NULL, -7, NULL, N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1166, 58</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (116, N'CtlLOV', NULL, 11, N'DSGN - CtlLOV', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">974, 682</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXLOV" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (117, N'CtlLOVCode', NULL, 11, N'DSGN - CtlLOVCode', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">885, 715</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXLOVCode" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (118, N'CtlMassnahmen', NULL, 1, N'B - CtlMassnahmen', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (119, N'CtlMenuEditor', NULL, 11, N'DSGN - CtlMenuEditor', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">600, 527</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXMenuItem" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (120, N'CtlMessage', NULL, 10, N'ADM - CtlMessage', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">845, 512</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryMessage" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (121, N'CtlModul', NULL, 11, N'DSGN - CtlModul', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1463, 841</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXModul" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (122, N'CtlOrgUnit', NULL, 10, N'ADM - CtlOrgUnit', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryOrgUnit" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlOrgUnit</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">703, 516</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (123, N'CtlPendenzBenutzerGruppen', NULL, 21, N'System / Pendenzenadministration / Definition / Pendenzengruppen', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">627, 493</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaPendenzgruppe" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (124, N'CtlPendenzenVerwaltung', NULL, 21, N'Anwendung / Pendenzverwaltung', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">722, 639</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXTask" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (125, N'CtlPendenzVorlagentexte', NULL, 21, N'System / Pendenzenadministration / Vorlagentexte bearbeiten', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, N'Maske zur Administration von Standardwerten für Betreff und Beschreibung anhand des Pendenztyps', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (126, N'CtlPermissionGroup', NULL, 10, N'ADM - CtlPermissionGroup', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1103, 869</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryPermissionGroup" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (127, N'CtlPerson', NULL, 3, N'S - CtlPerson', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (128, N'CtlPersonenStamm', NULL, 1, N'B - CtlPersonenStamm', N'KiSS4.Basis.CtlBaPerson', NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (129, N'CtlProfile', NULL, 10, N'ADM - CtlProfile', N'KiSS4.Gui.KissUserControl', 2110, NULL, NULL, 0, N'Profile', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (518, N'CtlProfileTagsVerwalten', NULL, 10, N'ADM - CtlProfileTagsVerwalten', N'KiSS4.Gui.KissUserControl', 2110, NULL, NULL, 0, N'Profiletags Verwalten', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (520, N'CtlQueryAdKompetenzen', NULL, 12, N'Anwendung / Daten-Explorer / Administration / AD - Kompetenzen', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (521, N'CtlQueryAdmAngemeldeteBenutzer', NULL, 12, N'Anwendung / Daten-Explorer / Administration / AD - Angemeldete Benutzer', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryAdmAngemeldeteBenutzer</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 37, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (522, N'CtlQueryAdmArchiv', NULL, 12, N'Anwendung / Daten-Explorer / Administration / AD - Archiv', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryAdmArchiv</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 7, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (523, N'CtlQueryAdmBenutzergruppenRechte', NULL, 12, N'Anwendung / Daten-Explorer / Administration / AD - Benutzerverwaltung', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryAdmBenutzergruppenRechte</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 7, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (524, N'CtlQueryAdmDatenMengen', NULL, 12, N'Anwendung / Daten-Explorer / Administration / AD - Datenmengen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryAdmDatenMengen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 2, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (525, N'CtlQueryAdmDatentypKonsistenz', NULL, 12, N'Anwendung / Daten-Explorer / Administration / AD - Datentyp-Konsistenz', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryAdmDatentypKonsistenz</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 3, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (526, N'CtlQueryAdmDoppeltErfassteBeziehungen', NULL, 12, N'Anwendung / Daten-Explorer / Administration / AD - Doppelt erfasste Beziehungen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryAdmDoppeltErfassteBeziehungen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 2, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (527, N'CtlQueryAdmDoppeltErfassteInstitutionen', NULL, 12, N'Anwendung / Daten-Explorer / Administration / AD - Doppelt erfasste Institutionen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryAdmDoppeltErfassteInstitutionen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 5, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (528, N'CtlQueryAdmDoppeltErfasstePersonen', NULL, 12, N'Anwendung / Daten-Explorer / Administration / AD - Doppelt erfasste Personen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryAdmDoppeltErfasstePersonen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 11, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (529, N'CtlQueryAdmDoppeltErfassteWohnsituationenen', NULL, 12, N'QU - CtlQueryAdmDoppeltErfassteWohnsituationenen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryAdmDoppeltErfassteWohnsituationenen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 1, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (130, N'CtlQueryAdmEtikettenabfrage', NULL, 12, N'Anwendung / Daten-Explorer / Administration / AD - Etikettenabfrage (Serienbrief)', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmEtikettenabfrage</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 6, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (131, N'CtlQueryAdmKinderMitMehrerenMuetternVaeter', NULL, 12, N'QU - CtlQueryAdmKinderMitMehrerenMuetternVaeter', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryAdmKinderMitMehrerenMuetternVaeter</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 2, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (132, N'CtlQueryAdmMitgliedInMehrerenAbteilungen', NULL, 12, N'Anwendung / Daten-Explorer / Administration / AD - Mitglied in mehreren Abteilungen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryAdmMitgliedInMehrerenAbteilungen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 3, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (133, N'CtlQueryAyEinsatzmoeglichkeiten', NULL, 12, NULL, N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryAyEinsatzmoeglichkeiten</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 5, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (134, N'CtlQueryAyFallstatistik', NULL, 12, NULL, N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryAyFallstatistik</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 6, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (135, N'CtlQueryAyKostenarten', NULL, 12, N'Anwendung / Daten-Explorer / Asyl / Kostenarten', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryAyKostenarten</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 11, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (136, N'CtlQueryAyLeistungen', NULL, 12, N'Anwendung / Daten-Explorer / Asyl / Leistungen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryAyLeistungen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 7, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (137, N'CtlQueryAyPraesenzliste', NULL, 12, N'Anwendung / Daten-Explorer / Asyl / Präsenzliste Quartalsabrechnung', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryAyPraesenzliste</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 10, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (138, N'CtlQueryAyTagesstrukturUebersicht', NULL, 12, N'Anwendung / Daten-Explorer / Asyl / Tagesstruktur Übersicht', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryAyTagesstrukturUebersicht</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 5, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (139, N'CtlQueryAyUebersichtKlientinnen', NULL, 12, N'Anwendung / Daten-Explorer / Asyl / Übersicht Klient/-innen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryAyUebersichtKlientinnen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 8, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (140, N'CtlQueryAyUnterkunftsbewegungen', NULL, 12, N'Anwendung / Daten-Explorer / Asyl / Unterkunftsbewegungen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryAyUnterkunftsbewegungen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 4, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (530, N'CtlQueryBaBerufMassnahmeIBE', NULL, 12, N'QU - CtlQueryBaBerufMassnahmeIBE', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryBaBerufMassnahmeIBE</Property>
</Object>', 0, N'Integration BE', NULL, NULL, NULL, NULL, 9, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (531, N'CtlQueryBaInstitutionKontaktpersonen', NULL, 12, N'Anwendung / Daten-Explorer / Basis / BA - Institution suchen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">1653, 975</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (532, N'CtlQueryBaKlientenlisteIBE', NULL, 12, N'Anwendung / Daten-Explorer / Basis / BA - Klientenliste', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryBaKlientenlisteIBE</Property>
</Object>', 0, N'Integration BE', NULL, NULL, NULL, NULL, 9, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (533, N'CtlQueryBaKopfquotenlisteIBE', NULL, 12, N'Anwendung / Daten-Explorer / Basis / BA - Kopfquotenliste', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryBaKopfquotenlisteIBE</Property>
</Object>', 0, N'Integration BE', NULL, NULL, NULL, NULL, 8, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (534, N'CtlQueryBaKrankenkassenIBE', NULL, 12, N'Anwendung / Daten-Explorer / Basis / BA - Krankenkasse', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryBaKrankenkassenIBE</Property>
</Object>', 0, N'Integration BE', NULL, NULL, NULL, NULL, 4, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (535, N'CtlQueryBaPersonenadressen', NULL, 12, N'Anwendung / Daten-Explorer / Basis / BA - Personenadressen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryBaPersonenadressen</Property>
</Object>', 0, N'Focus auf erstes Feld fehlt', NULL, NULL, NULL, NULL, 38, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (536, N'CtlQueryBaPersonenadressen2', NULL, 12, N'QU - CtlQueryBaPersonenadressen2', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryBaPersonenadressen2</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 1, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (537, N'CtlQueryBaPersonenSuchen', NULL, 12, N'Anwendung / Daten-Explorer / Basis / BA - Personen suchen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryBaPersonenSuchen</Property>
</Object>', 0, N'Focus auf erstes Feld fehlt', NULL, NULL, NULL, NULL, 41, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (538, N'CtlQueryBaPersonenSuchenHist', NULL, 12, N'Anwendung / Daten-Explorer / Basis / BA - Personen suchen (Hist.)', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryBaPersonenSuchenHist</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 13, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (539, N'CtlQueryBaUebersichtKrankenkassen', NULL, 12, N'Anwendung / Daten-Explorer / Basis / BA - Übersicht Krankenkassen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryBaUebersichtKrankenkassen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 25, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (540, N'CtlQueryBaZugehoerigeGemeinde', NULL, 12, N'Anwendung / Daten-Explorer / Basis / BA - Zugehörige Gemeinde', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryBaZugehoerigeGemeinde</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 12, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (541, N'CtlQueryBDEMaAustritt', NULL, 12, N'Anwendung / Daten-Explorer / Rechnungswesen / MA-Austritt', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, N'Abfrage: Rechnungswesen - Listet ausgetretene Benutzer mit unausgeglichenem Gleitzeit-/Feriensaldo auf.', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (141, N'CtlQueryBDEStundenProLA', NULL, 12, N'Anwendung / Daten-Explorer / Zeit-/Leistungserfassung / Std. pro Leistungsart', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">924, 493</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage: Zeit-/Leistungserfassung - Stunden pro Leistungsart', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'PI')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (142, N'CtlQueryBFSGemeinde', NULL, 16, N'System / Sostat / Abfragen / BFS Gemeinde Code', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (143, N'CtlQueryFaAbschlussgruende', NULL, 12, N'Anwendung / Daten-Explorer / Fallführung / FF - Abschlussgründe', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryFaAbschlussgruende</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 11, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (144, N'CtlQueryFaAktiveModulbesitzer', NULL, 12, N'Anwendung / Daten-Explorer / Fallführung / FF - aktive Modulbesitzer', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryFaAktiveModulbesitzer</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 7, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (145, N'CtlQueryFaDokumentAblage', NULL, 12, N'Abfrage Dokumentablage', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (146, N'CtlQueryFaDossierarchivierung', NULL, 12, N'Anwendung / Daten-Explorer / Fallführung / FF - Dossierarchivierung', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryFaDossierarchivierung</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 2, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (147, N'CtlQueryFaFaelleProMitarbeiter', NULL, 12, N'Anwendung / Daten-Explorer / Fallführung / FF - Fälle pro Mitarbeiter', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryFaFaelleProMitarbeiter</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 22, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (148, N'CtlQueryFaFaelleProMitarbeiterInklIntake', NULL, 12, N'Anwendung / Daten-Explorer / Fallführung / FF - Fälle pro Mitarbeiter (inkl. Intake)', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryFaFaelleProMitarbeiterInklIntake</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 14, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (149, N'CtlQueryFaFallnavigator', NULL, 12, N'Anwendung / Daten-Explorer / Fallführung / FF - Fallnavigator', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryFaFallnavigator</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 31, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (150, N'CtlQueryFaFallsteuerung', NULL, 12, N'Anwendung / Daten-Explorer / Fallführung / FF - Fallsteuerung', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryFaFallsteuerung</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 4, 0, 2004, CONVERT(datetime, '2009-01-08 11:38:37', 120), NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (151, N'CtlQueryFaFalltraegerÜbersicht', NULL, 12, N'Anwendung / Daten-Explorer / Fallführung / FF - Fallträger Übersicht', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryFaFalltraegerÜbersicht</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 13, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (542, N'CtlQueryFaUnterstuezungsvertraege', NULL, 12, N'Anwendung / Daten-Explorer / Fallführung / FF - Unterstützungsverträge', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryFaUnterstuezungsvertraege</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 8, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (543, N'CtlQueryFaWeisung', NULL, 12, N'Anwendung / Daten-Explorer / Fallführung / FF - Weisungen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">    <Property name="Name" xsi:type="System.String">CtlQueryFaWeisung</Property>  </Object>', 0, N'Klasse um Abfragen auf Weisungen zu machen', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (544, N'CtlQueryGvExterneFonds', NULL, 12, N'Anwendung / Daten-Explorer / Gesuchverwaltung / Externe Fonds', N'KiSS4.Query.CtlQueryGvFondsBase', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (545, N'CtlQueryGvFondsBase', NULL, 12, N'Anwendung / Daten-Explorer / Gesuchverwaltung / Fonds', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (546, N'CtlQueryGvGesuchAbschliessen', NULL, 12, N'Anwendung / Daten-Explorer / Gesuchverwaltung / Interne Gesuche abschliessen', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (547, N'CtlQueryGvInterneFonds', NULL, 12, N'Anwendung / Daten-Explorer / Gesuchverwaltung / Interne Fonds', N'KiSS4.Query.CtlQueryGvFondsBase', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (548, N'CtlQueryIkAbklaerungen', NULL, 12, N'Anwendung / Daten-Explorer / Inkasso / Abklärungen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryIkAbklaerungen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 38, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (549, N'CtlQueryIkAktiveVerlustscheine', NULL, 12, N'Anwendung / Daten-Explorer / Inkasso / Aktive Verlustscheine', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryIkAktiveVerlustscheine</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 21, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (550, N'CtlQueryIkAnteilSchuldnerNationalitaet', NULL, 12, N'Anwendung / Daten-Explorer / Inkasso / Anteil Schuldner nach Nationalität', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryIkAnteilSchuldnerNationalitaet</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 116, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (551, N'CtlQueryIkAuswertungAlimenteninkassofuehrung', NULL, 12, N'Anwendung / Daten-Explorer / Inkasso / Auswertung Alimenteninkassoführung', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryIkAuswertungAlimenteninkassofuehrung</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 6, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (552, N'CtlQueryIkBetreibungsBegehren', NULL, 12, N'Anwendung / Daten-Explorer / Inkasso / Betreibungs-, Forts-, ...', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryIkBetreibungsBegehren</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 13, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (553, N'CtlQueryIkFallfuehrungGesamt', NULL, 12, N'Anwendung / Daten-Explorer / Inkasso / Fallführung Gesamt', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">1567, 1055</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage Ik Fallführung Gesamt', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (554, N'CtlQueryIkFallführung', NULL, 12, N'Anwendung / Daten-Explorer / Inkasso / Fallführung', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryIkFallführung</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">800, 539</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 135, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (555, N'CtlQueryIkGeburtsdatumGlaeubiger', NULL, 12, N'Anwendung / Daten-Explorer / Inkasso / Geburtsdatum Gläubiger', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryIkGeburtsdatumGlaeubiger</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 39, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (152, N'CtlQueryIkGlaeubigerpersonPersonalien', NULL, 12, N'Anwendung / Daten-Explorer / Inkasso / Gläubiger Personalien', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryIkGlaeubigerpersonPersonalien</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 69, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (153, N'CtlQueryIkIndexbrief', NULL, 12, N'Anwendung / Daten-Explorer / Inkasso / Indexbrief', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryIkIndexbrief</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 155, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (154, N'CtlQueryIkInkassoArchivierung', NULL, 12, N'Anwendung / Daten-Explorer / Inkasso / Archivierung', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryIkInkassoArchivierung</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 38, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (155, N'CtlQueryIkInkassoquote', NULL, 12, N'Anwendung / Daten-Explorer / Inkasso / Inkasso Quote', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryIkInkassoquote</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 37, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (156, N'CtlQueryIkKinderzulagen', NULL, 12, N'CtlQueryIkKinderzulagen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryIkKinderzulagen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 26, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (157, N'CtlQueryIkMahnlauf', NULL, 12, N'Anwendung / Daten-Explorer / Inkasso / Mahnlauf', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryIkMahnlauf</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 19, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (158, N'CtlQueryIkRechtlicheMassnahmen', NULL, 12, N'Anwendung / Daten-Explorer / Inkasso / Rechtliche Massnahmen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryIkRechtlicheMassnahmen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 12, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (159, N'CtlQueryIkRueckerstattungsgruende', NULL, 12, N'Anwendung / Daten-Explorer / Inkasso / Rückerstattungsgründe', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">659, 651</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Statistische Auswertung der Forderungen und Zahlkungen bezüglich der verschiedenen Rückerstattungsgründe', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (160, N'CtlQueryKaAbklDossierrueckgabe', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Abklärung / KA - Auswertung Dossierrückgabe', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaAbklDossierrueckgabe</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 20, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (161, N'CtlQueryKaAbklListeAbklaerung', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Abklärung / KA - Liste Abklärung', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaAbklListeAbklaerung</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 11, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (162, N'CtlQueryKaAbklStatistikSektion', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Abklärung / KA - Statistik Sektion Abklärung', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaAbklStatistikSektion</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 16, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (556, N'CtlQueryKaAbklWiederbeurteilung', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Abklärung / KA - Wiederbeurteilung Abklärung', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaAbklWiederbeurteilung</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 3, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (557, N'CtlQueryKaAdrListeAktStage', NULL, 12, N'QU - CtlQueryKaAdrListeAktStage', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaAdrListeAktStage</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 6, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (558, N'CtlQueryKaAnreizSDBern', NULL, 12, N'QU - CtlQueryKaAnreizSDBern', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaAnreizSDBern</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 6, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (559, N'CtlQueryKaBelegMotivation', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Qualifizierung Jugend / KA - Beleg Motivationssemester', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaBelegMotivation</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 4, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (560, N'CtlQueryKaBetriebeAdressen', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Einsatzorte / KA - Betriebe Adressen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">    <Property name="Name" xsi:type="System.String">CtlQueryKaBetriebeAdressen</Property>  </Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (561, N'CtlQueryKaCasemanagementlisteBin', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Jobtimum / KA - Casemeanagementliste BIN', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, N'Abfrage zum Auswerten der Stellensuchenden, welche aktuell im Programm Jobtimum teilnehmen', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (562, N'CtlQueryKaControllingBIBIP', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Vermittlung / KA - Controlling BI/BIP', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaControllingBIBIP</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 24, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (563, N'CtlQueryKaControllingSI', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Vermittlung / KA - Controlling SI', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaControllingSI</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 18, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (564, N'CtlQueryKaEingangAsD', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Abklärung / KA - Eingang AsD', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaEingangAsD</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 6, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (565, N'CtlQueryKaEinsaetzeBIPStellenBI', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Vermittlung / KA - Einsätze BIP/Stellen BI', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaEinsaetzeBIPStellenBI</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 12, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (566, N'CtlQueryKaEinsaetzeSI', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Vermittlung / KA - Einsätze SI', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaEinsaetzeSI</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 11, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (567, N'CtlQueryKaEPQStesListe', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Qualifizierung Erwachsene / KA - STES Liste (EPQ)', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaEPQStesListe</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 8, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (163, N'CtlQueryKaFehlendeAngaben', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Administration/Statistik / KA - Fehlende Angaben', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaFehlendeAngaben</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 11, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (164, N'CtlQueryKaIntegrationszulagen', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Qualifizierung Jugend / KA - Integrationszulagen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">    <Property name="Name" xsi:type="System.String">CtlQueryKaIntegrationszulagen</Property>  </Object>', 0, N'', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (165, N'CtlQueryKaKontrolleAnweisungen', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Administration/Statistik / KA - Kontr. Zu-/Anweisungen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaKontrolleAnweisungen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 11, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (166, N'CtlQueryKaKurseBIBIPSI', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Vermittlung / KA - Kurse BI/BIP/SI', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaKurseBIBIPSI</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 7, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (167, N'CtlQueryKaLehrstellenInizio', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Inizio / KA - Lehrstellen Inizio', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaLehrstellenInizio</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 6, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (168, N'CtlQueryKaListeSTOB', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Abklärung / KA - Liste STOB', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaListeSTOB</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 4, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (169, N'CtlQueryKaMigrationInfonet', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / KA - Migration Infonet', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaMigrationInfonet</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 2, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (170, N'CtlQueryKaMigrationKlientDB', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / KA - Migration Klient DB', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaMigrationKlientDB</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 2, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (171, N'CtlQueryKaPendentStage', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Qualifizierung Jugend / KA - Pendent für Stage', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaPendentStage</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 6, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (172, N'CtlQueryKaProzessVermittlung', NULL, 12, N'KA - Prozess Vermittlung BI/BIP', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (173, N'CtlQueryKaQJStatistik', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Qualifizierung Jugend / KA - Statistik QJ', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaQJStatistik</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 5, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (568, N'CtlQueryKaReporting', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Administration/Statistik / KA - Reporting', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaReporting</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 7, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (569, N'CtlQueryKaSerienbrief', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Administration/Statistik / KA - Serienbrief', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, N'Abfrage zum Erstellen von Serienbriefen', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (570, N'CtlQueryKaStagesQJExtern', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Qualifizierung Jugend / KA - Stages extern', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaStagesQJExtern</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 24, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (571, N'CtlQueryKaStatistikGEF', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Administration/Statistik / KA - Statistik GEF', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaStatistikGEF</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 16, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (572, N'CtlQueryKaStatistikInizio', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Inizio / KA - Statistik Inizio', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaStatistikInizio</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 5, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (573, N'CtlQueryKaSTESListe', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Qualifizierung Jugend / KA - STES-Liste (QJ)', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaSTESListe</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 15, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (574, N'CtlQueryKaTeilnehmendenlisteSi', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Vermittlung / KA - Teilnehmendenliste SI', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">1431, 711</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage zum Auswerten der Teilnehmenden mit offener Leistung Vermittlung SI', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (575, N'CtlQueryKaTeilnehmerstruktur', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Administration/Statistik / KA - Teilnehmerstruktur', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaTeilnehmerstruktur</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 23, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (576, N'CtlQueryKaUebersichtAssistenz', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Administration/Statistik / KA - Übersicht Assistenzproj.', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaUebersichtAssistenz</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 4, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (577, N'CtlQueryKaUebersichtStages', NULL, 12, N'QU - CtlQueryKaUebersichtStages', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaUebersichtStages</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 3, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (578, N'CtlQueryKaWartelisteSemo', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / Qualifizierung Jugend / KA - Warteliste SEMO', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaWartelisteSemo</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 6, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (579, N'CtlQueryKaZuweisungen', NULL, 12, N'Anwendung / Daten-Explorer / Arbeit (KA) / KA - Zuweisungen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKaZuweisungen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 6, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (580, N'CtlQueryKbAbrechnungASVS', NULL, 17, N'Anwendung / Klientenbuchhaltung / Auswerten / Abrechnung ASV', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKbAbrechnungASVS</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (174, N'CtlQueryKbBilanzErfolg', NULL, 17, N'Anwendung / Klientenbuchhaltung / Auswerten / Bilanz/Erfolg', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKbBilanzErfolg</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBilanz" />
  </Property>
  <Property name="Size" xsi:type="System.Drawing.Size">841, 411</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (175, N'CtlQueryKbBilanzkonti', NULL, 17, N'Anwendung / Klientenbuchhaltung / Auswerten / Bilanzkonti', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKbBilanzkonti</Property>
  <Property name="ActiveSQLQuery">
    <InstanceDescriptor xsi:type="KiSS4.DB.SqlQuery">
      <Property name="TableName" xsi:type="System.String">FbBuchungCode</Property>
    </InstanceDescriptor>
  </Property>
  <Property name="Size" xsi:type="System.Drawing.Size">807, 428</Property>
</Object>', 0, N'noch im Test durch Marino', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (176, N'CtlQueryKbBuchungsjournal', NULL, 17, N'Anwendung / Klientenbuchhaltung / Auswerten / Buchungsjournal Fibu', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKbBuchungsjournal</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (177, N'CtlQueryKbControlling', NULL, 12, N'Anwendung / Daten-Explorer / Klientenbuchhaltung / KB - Controlling', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">    <Property name="Name" xsi:type="System.String">CtlQueryKbControlling</Property>  </Object>', 0, N'Controlling-Maske für die Klientenbuchhaltung.', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (178, N'CtlQueryKbKlientenkonto', NULL, 17, N'Anwendung / Klientenbuchhaltung / Auswerten / Klientenkonto', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKbKlientenkonto</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (179, N'CtlQueryKbKostenarten', NULL, 17, N'Anwendung / Klientenbuchhaltung / Auswerten / Kostenarten', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <InstanceDescriptor xsi:type="KiSS4.DB.SqlQuery">
      <Property name="TableName" xsi:type="System.String">FbBuchungCode</Property>
    </InstanceDescriptor>
  </Property>
  <Property name="Name" xsi:type="System.String">CtlQueryKbKostenarten</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">784, 428</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (180, N'CtlQueryKbKostenstellenjournal', NULL, 17, N'Anwendung / Klientenbuchhaltung / Auswerten / Kostenstellenjournal Bebu', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKbKostenstellenjournal</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (181, N'CtlQueryKbSaldolisteKreditoren', NULL, 17, N'Anwendung / Klientenbuchhaltung / Auswerten / Kreditoren, Saldoliste', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKbSaldolisteKreditoren</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (182, N'CtlQueryKbSozialhilferechnung', NULL, 17, N'Anwendung / Klientenbuchhaltung / Auswerten / Sozialhilferechnung', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryKbSozialhilferechnung</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (581, N'CtlQueryKbSozialhilferechnungDifferenziert', NULL, 17, N'Anwendung / Klientenbuchhaltung / Auswerten / Differenzierung Sozialhilferechnung', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">    <Property name="Name" xsi:type="System.String">CtlQueryKbSozialhilferechnungDifferenziert</Property>  </Object>', 0, N'', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (582, N'CtlQueryKontiOhneBgKostenart', NULL, 17, N'Anwendung / Klientenbuchhaltung / Auswerten / Konti', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">1589, 946</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, N'Abfrage um alle Konti ohne BgKostenart auszudrucken', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (583, N'CtlQueryShAbschlussgruende', NULL, 12, N'Anwendung / Daten-Explorer / Sozialhilfe / SH - Abschlussgründe', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryShAbschlussgruende</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 7, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (584, N'CtlQueryShAbzahlungskontoAbschluss', NULL, 12, N'Anwendung / Daten-Explorer / Sozialhilfe / SH - Abzahlungskonto Abschluss', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">    <Property name="Name" xsi:type="System.String">CtlQueryShAbzahlungskontoAbschluss</Property>  </Object>', 0, N'Controlling-Maske für das Abschliessen von Abzahlungskonti.', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (585, N'CtlQueryShAbzahlungskontoIBE', NULL, 12, N'QU - CtlQueryShAbzahlungskontoIBE', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryShAbzahlungskontoIBE</Property>
</Object>', 0, N'Integration BE', NULL, NULL, NULL, NULL, 14, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (586, N'CtlQueryShEinzelzahlungen', NULL, 12, N'Anwendung / Daten-Explorer / Sozialhilfe / SH - Einzelzahlungen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryShEinzelzahlungen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 13, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (587, N'CtlQueryShEroeffnungsgruende', NULL, 12, N'Anwendung / Daten-Explorer / Sozialhilfe / SH - Eröffnungsgründe', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryShEroeffnungsgruende</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 21, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (588, N'CtlQueryShFinanzplaene', NULL, 12, N'Anwendung / Daten-Explorer / Sozialhilfe / SH - Finanzpläne', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryShFinanzplaene</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 13, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (589, N'CtlQueryShKlientenlisteSD', NULL, 12, N'Anwendung / Daten-Explorer / Sozialhilfe / SH - Klientenliste SD', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryShKlientenlisteSD</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 26, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (590, N'CtlQueryShKrankenkasse', NULL, 12, N'Anwendung / Daten-Explorer / Sozialhilfe / SH - Krankenkasse', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryShKrankenkasse</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 6, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (591, N'CtlQueryShPapierverfuegung', NULL, 12, N'Anwendung / Daten-Explorer / Sozialhilfe / SH - Papierverfügung', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">962, 645</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (183, N'CtlQueryShStatusMonatsbudgets', NULL, 12, N'Anwendung / Daten-Explorer / Sozialhilfe / SH - Status Monatsbudget', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryShStatusMonatsbudgets</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 13, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (184, N'CtlQueryShStatusMonatsbudgetsZulagen', NULL, 12, N'Anwendung / Daten-Explorer / Sozialhilfe / SH - Status Monatsbudget (Zulagen)', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryShStatusMonatsbudgetsZulagen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 12, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (185, N'CtlQueryShZulagenBrutto', NULL, 12, N'Anwendung / Daten-Explorer / Sozialhilfe / SH - Zulagen Brutto', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (186, N'CtlQueryStatBaIntegrationsstand', NULL, 12, N'Anwendung / Daten-Explorer / Statistik / STAT - Ba-integrationsstand', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryStatBaIntegrationsstand</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 8, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (187, N'CtlQueryStatBFSKernvariablen', NULL, 12, N'QU - CtlQueryStatBFSKernvariablen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryStatBFSKernvariablen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 10, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (188, N'CtlQueryStatFallentwicklungNachModulen', NULL, 12, N'Anwendung / Daten-Explorer / Statistik / STAT - Fallentwicklung nach Modulen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryStatFallentwicklungNachModulen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 13, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (189, N'CtlQueryStatShFallzahlen', NULL, 12, N'Anwendung / Daten-Explorer / Statistik / STAT - SH Fallzahlen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryStatShFallzahlen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 16, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (190, N'CtlQueryStatShFallzahlenDetail', NULL, 12, N'QU - CtlQueryStatShFallzahlenDetail', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (191, N'CtlQueryStatShFallzahlenTotal', NULL, 12, N'QU - CtlQueryStatShFallzahlenTotal', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (192, N'CtlQueryStatSozialraum', NULL, 12, N'Anwendung / Daten-Explorer / Statistik / STAT - Sozialraum', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, N'Abfrage Statistik - Sozialraum', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (193, N'CtlQueryVmAbklaerungsfristIntake', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Abklärungsfrist Intake 60 Tage', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmAbklaerungsfristIntake</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 12, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (194, N'CtlQueryVmAbschluesseOhneAufhebungsdatum', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Abschlüsse ohne Aufhebungsdatum', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmAbschluesseOhneAufhebungsdatum</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 11, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (195, N'CtlQueryVmAHVMindestbeitraege', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - AHV Mindestbeiträge', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmAHVMindestbeitraege</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 8, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (592, N'CtlQueryVmBearbeitungsfristenJA', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Jugendamt / VM - Bearbeitungsfristen JA', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (593, N'CtlQueryVmBerichtsaufforderung', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Berichtsaufforderung', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmBerichtsaufforderung</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 14, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (594, N'CtlQueryVmBerichtseinladung', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Berichtseinladung', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmBerichtseinladung</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 15, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (595, N'CtlQueryVmBerichtsverlauf', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Berichtsverlauf', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmBerichtsverlauf</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 12, 0, NULL, NULL, N'BSS')
GO
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (596, N'CtlQueryVmDauerauftraege', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Mandatsbuchhaltung / VM - Daueraufträge', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmDauerauftraege</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 10, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (597, N'CtlQueryVmDauerauftragBuchungen', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Mandatsbuchhaltung / VM - Dauerauftrag Buchungen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmDauerauftragBuchungen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 7, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (598, N'CtlQueryVmDienstleistungen', NULL, 12, N'QU - CtlQueryVmDienstleistungen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmDienstleistungen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 6, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (599, N'CtlQueryVmEingangsbestaetigungEksIc', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Eingangsbestätigung EKS IC', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmEingangsbestaetigungEksIc</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 10, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (600, N'CtlQueryVmElKrankheitskosten', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - EL-Krankheitskosten', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmElKrankheitskosten</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 6, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (601, N'CtlQueryVmElternrechteFamilienform', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Jugendamt / VM - Elternrechte/Familienform', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmElternrechteFamilienform</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 13, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (602, N'CtlQueryVmErbschaftKontrolleEA', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Erbschaft / VM - Kontrolle EA', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmErbschaftKontrolleEA</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 4, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (603, N'CtlQueryVmErbschaftKontrolleTestament', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Erbschaft / VM - Kontrolle Testamentsdienst', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryAdmAngemeldeteBenutzer</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (196, N'CtlQueryVmErbschaftSiegelungskontrolle', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Erbschaft / VM - Siegelungskontrolle', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmErbschaftSiegelungskontrolle</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 6, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (197, N'CtlQueryVmErfasstePeriodenDetail', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Mandatsbuchhaltung / VM - Erfasste Perioden (Detail)', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmErfasstePeriodenDetail</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 7, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (198, N'CtlQueryVmErfasstePeriodenTotal', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Mandatsbuchhaltung / VM - Erfasste Perioden (Total)', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmErfasstePeriodenTotal</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 3, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (199, N'CtlQueryVmEroeffnungsbilanzUngleich0', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Mandatsbuchhaltung / VM - Eröffnungsbilanz <> 0', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmEroeffnungsbilanzUngleich0</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 6, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (200, N'CtlQueryVmEroeffnungssaldiDetail', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Mandatsbuchhaltung / VM - Eröffnungssaldi (Detail)', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmEroeffnungssaldiDetail</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 4, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (201, N'CtlQueryVmEroeffnungssaldiTotal', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Mandatsbuchhaltung / VM - Eröffnungssaldi (Total)', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmEroeffnungssaldiTotal</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 2, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (202, N'CtlQueryVmFaelleOhneDokuEintrag2Wochen', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Fälle ohne Doku. Eintrag (2 Wochen)', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmFaelleOhneDokuEintrag2Wochen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 3, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (203, N'CtlQueryVmFallabschluss', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Jugendamt / VM - Fallabschluss', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmFallabschluss</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 11, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (204, N'CtlQueryVmFalleroeffnung', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Jugendamt / VM - Falleröffnung', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmFalleroeffnung</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 11, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (205, N'CtlQueryVmFallgewichtungAktuell', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Fallgewichtung aktuell', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmFallgewichtungAktuell</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 10, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (206, N'CtlQueryVmFallgewichtungVerlauf', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Fallgewichtung Verlauf', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmFallgewichtungVerlauf</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 7, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (604, N'CtlQueryVmFibuAblageJournal', NULL, 12, N'QU - CtlQueryVmFibuAblageJournal', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmFibuAblageJournal</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 3, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (605, N'CtlQueryVmFibuBilanzErfolg', NULL, 12, N'QU - CtlQueryVmFibuBilanzErfolg', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmFibuBilanzErfolg</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 4, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (606, N'CtlQueryVmFibuDauerauftraege', NULL, 12, N'QU - CtlQueryVmFibuDauerauftraege', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmFibuDauerauftraege</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 2, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (607, N'CtlQueryVmFibuJournal', NULL, 12, N'QU - CtlQueryVmFibuJournal', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmFibuJournal</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 3, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (608, N'CtlQueryVmFibuKontoblatt', NULL, 12, N'QU - CtlQueryVmFibuKontoblatt', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmFibuKontoblatt</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 4, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (642, N'CtlQueryVmFristKategorisierung', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Jugendamt / VM - Frist Kategorisierung', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">    <Property name="Name" xsi:type="System.String">CtlQueryVmFristKategorisierung</Property>  </Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (609, N'CtlQueryVmGefaehrdungsmeldungen', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Jugendamt / VM - Gefährdungsmeldungen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmGefaehrdungsmeldungen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 13, 0, NULL, NULL, N'BSS')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (610, N'CtlQueryVmInkonsistenteBuchungen', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Mandatsbuchhaltung / VM - Inkonsistente Buchungen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmInkonsistenteBuchungen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 3, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (611, N'CtlQueryVmInventarfristen', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Inventarfristen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmInventarfristen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 13, 0, NULL, NULL, N'BSS')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (612, N'CtlQueryVmKennzahl2005Berichte', NULL, 12, N'QU - CtlQueryVmKennzahl2005Berichte', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmKennzahl2005Berichte</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 1, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (613, N'CtlQueryVmKennzahlen', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Kennzahlen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmKennzahlen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 12, 0, NULL, NULL, N'BSS')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (614, N'CtlQueryVmKesKennzahlen', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - KES-Kennzahlen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object>
  <Property name="Size">1653, 1055</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryQuery" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (615, N'CtlQueryVmKlientenbudget', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Budget nach Status', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, N'Abfrage für Budget in Vormundschaftliche Massnahmen', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (207, N'CtlQueryVmKlientenliste', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Klientenliste', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmKlientenliste</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 6, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (208, N'CtlQueryVmPlatzierung', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Jugendamt / VM - Platzierung', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmPlatzierung</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 9, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (209, N'CtlQueryVmPriMaMandateEks', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - PriMa Mandate EKS', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmPriMaMandateEks</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 12, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (210, N'CtlQueryVmProduktegruppeNSB', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Jugendamt / VM - Produktgruppe NSB', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmProduktegruppeNSB</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 22, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (211, N'CtlQueryVmPruefungMuendelvermoegen', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Mandatsbuchhaltung / VM - Prüfung Mündelvermögen', N'KiSS4.Common.KissQueryControl', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (212, N'CtlQueryVmSachversicherungen', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Sachversicherungen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmSachversicherungen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 9, 0, NULL, NULL, N'BSS')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (213, N'CtlQueryVmSaldoabfrage', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Mandatsbuchhaltung / VM - Saldoabfrage', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmSaldoabfrage</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 12, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (214, N'CtlQueryVmSozialversicherungen', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Sozialversicherungen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmSozialversicherungen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 6, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (215, N'CtlQueryVmStatusMonatsbudgets', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Status Monatsbudget', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmStatusMonatsbudgets</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 14, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (216, N'CtlQueryVmStatusVaterschaften', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Status Vaterschaften', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmStatusVaterschaften</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 7, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (217, N'CtlQueryVmSteuern', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Steuern', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmSteuern</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 16, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (218, N'CtlQueryVmSteuerungszahlenEksIc', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Steuerungszahlungen', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmSteuerungszahlenEksIc</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 6, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (616, N'CtlQueryVmVerlaufVaterschaften', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Verlauf Vaterschaften', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmVerlaufVaterschaften</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 17, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (617, N'CtlQueryVmVermoegensuebersicht', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / Mandatsbuchhaltung / VM - Vermögungsübersicht', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmVermoegensuebersicht</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 11, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (618, N'CtlQueryVmVormundschaftsregister', NULL, 12, N'Anwendung / Daten-Explorer / Vormundschaft / VM - Vormundschaftsregister', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlQueryVmVormundschaftsregister</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 21, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (619, N'CtlQueryWhZahlungseingaenge', NULL, 12, N'Anwendung / Daten-Explorer / Sozialhilfe / SH - Zahlungseingänge Dritter', N'KiSS4.Common.KissQueryControl', 2111, NULL, N'<Object xsi:type="KiSS4.Common.KissQueryControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">    <Property name="Name" xsi:type="System.String">CtlQueryWhZahlungseingaenge</Property>  </Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (620, N'CtlRenameBookmarks', NULL, 10, N'Textmarken umbenennen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1080, 803</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (621, N'CtlReportDefinition', NULL, 12, N'QU - CtlReportDefinition', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">817, 612</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXQuery" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (622, N'CtlSozialhilfe', NULL, 1, N'B - CtlSozialhilfe', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (623, N'CtlStdZahlungsmodi', NULL, 10, N'ADM - CtlStdZahlungsmodi', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1049, 598</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryZahlungsmodus" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (624, N'CtlSuchePerson', NULL, -1, N'BA - Neue Person erfassen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">929, 528</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, N'BSS')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (625, N'CtlTableColumnEditor', NULL, 11, N'DSGN - CtlTableColumnEditor', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">832, 653</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXTableColumn" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (626, N'CtlTableEditor', NULL, 11, N'DSGN - CtlTableEditor', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">888, 560</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXTable" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (627, N'CtlTableForeignKeysEditor', NULL, 11, N'DSGN - CtlTableForeignKeysEditor', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">832, 653</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXForeignKeys" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (628, N'CtlTableIndicesEditor', NULL, 11, N'DSGN - CtlTableIndicesEditor', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">1072, 815</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXIndex" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (629, N'CtlTableStructureEditor', NULL, 11, N'DSGN - CtlTableStructureEditor', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">834, 721</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (630, N'CtlTranslateMask', NULL, -8, N'Maske übersetzen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">794, 247</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (219, N'CtlTreeEditor', NULL, 11, N'DSGN - CtlTreeEditor', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">930, 672</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXModulTree" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (220, N'CtlUser', NULL, 10, N'ADM - CtlUser', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>
  <Property name="Size">788, 614</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryUser" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (221, N'CtlUserGroup', NULL, 10, N'Rollen/Benutzergruppen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">857, 674</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryUserGroup" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (222, N'CtlVmAHVMindestbeitraege', NULL, 5, N'Vormundschaftliche Massnahme / Administration / AHV Mindestbeiträge', N'KiSS4.Common.KissSearchLogischesLoeschenUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1635, 1012</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryAHVMindestbeitraege" />
</Property>
</Object>', 0, N'AHV Mindestbeiträge', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (223, N'CtlVmAntragEksk', NULL, 5, N'Vormundschaftliche Massnahme / Mandatsführung / Anträge EKSK', N'KiSS4.Common.KissSearchLogischesLoeschenUserControl', 2110, NULL, N'<Object>
  <Property name="Size">808, 749</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmAntragEksk" />
</Property>
</Object>', 0, N'Antrag EKSK', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (224, N'CtlVmBarauszahlungErfolgt', NULL, 5, N'Vormundschaftliche Massnahme / Finanzen / Barauszahlungen / erfolgt', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>    <Property name="Size">1114, 869</Property>    <Property name="ActiveSQLQuery">      <Reference name="qryFbBarauszahlungAuftrag" />  </Property>  </Object>', 0, N'Klasse um die erfolgten Barauszahlungen zu handeln', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (225, N'CtlVmBarauszahlungGeplant', NULL, 5, N'Vormundschaftliche Massnahme / Finanzen / Barauszahlungen / geplant', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object>    <Property name="Size">1114, 869</Property>    <Property name="ActiveSQLQuery">      <Reference name="qryFbBarauszahlungAuftrag" />  </Property>  </Object>', 0, N'Klasse um die geplanten Barauszahlungen zu handeln', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (226, N'CtlVmBeschwerdeAnfrage', NULL, 5, N'Vormundschaftliche Massnahme / V-Massnahmen / Beschwerden/Anfragen', N'KiSS4.Common.KissSearchLogischesLoeschenUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1125, 738</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmBeschwerdeAnfrage" />
</Property>
</Object>', 0, N'BeschwerdeAnfrage', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (227, N'CtlVmBewertung', NULL, 5, N'Vormundschaftliche Massnahme / Typisierung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">335, 793</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (228, N'CtlVmBudget', NULL, 5, N'Vormundschaftliche Massnahme / Finanzen / Budget / Budget (alt)', N'KiSS4.Common.KissSearchLogischesLoeschenUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1635, 1052</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmBudget" />
</Property>
</Object>', 0, N'Berichte', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (229, N'CtlVmELKrankheitskosten', NULL, 5, N'Vormundschaftliche Massnahme / Administration / EL Krankheitskosten', N'KiSS4.Common.KissSearchLogischesLoeschenUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1635, 1012</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmElKrankheitskosten" />
</Property>
</Object>', 0, N'EL Krankheitskosten', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (230, N'CtlVmErbe', NULL, 5, N'Dienst / Erben', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">335, 793</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmErbe" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (471, N'CtlVmErblasser', NULL, 5, N'Erbschaftsamt / ErblasserIn', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">335, 793</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmErblasser" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (472, N'CtlVmErblasserInfo', NULL, 5, N'Erbschaftsamt / Dienst / Infobox Erblasser/-in', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">705, 120</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmErblasserInfo" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (473, N'CtlVmErbschaftsdienst', NULL, 5, N'Erbschaftsamt / Erbschaftsdienst', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">335, 793</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmErbschaftsdienst" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (474, N'CtlVmGefaehrdungsmeldung', NULL, 5, N'Auftrag Jugendamt / Gefährdungsmeldungen', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, N'Gefaehrdungsmeldung', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (475, N'CtlVmInventar', NULL, 5, N'Vormundschaftliche Massnahme / V-Massnahmen / Inventar', N'KiSS4.Common.KissSearchLogischesLoeschenUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1635, 1012</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmInventar" />
</Property>
</Object>', 0, N'Inventar', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (476, N'CtlVmKriterien', NULL, 5, N'Vormundschaftliche Massnahme / Typisierung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">326, 762</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmBewertung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (477, N'CtlVmMandant', NULL, 5, N'Vormundschaftliche Massnahme / V-Massnahmen / Mandant', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">335, 610</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmMandant" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (478, N'CtlVmMandBericht', NULL, 5, N'Vormundschaftliche Massnahme / Mandatsführung / Berichte', N'KiSS4.Common.KissSearchLogischesLoeschenUserControl', 2110, NULL, N'<Object>
  <Property name="Size">800, 767</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmMandBericht" />
</Property>
</Object>', 0, N'Berichte', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (479, N'CtlVmMassnahmen', NULL, 5, N'Vormundschaftliche Massnahme / V-Massnahmen / Massnahmen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">335, 610</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmMassnahme" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (480, N'CtlVmModulTree', NULL, 5, N'Vormundschaft ModulTree', N'KiSS4.Common.KissModulTree', 2120, NULL, N'<Object>
  <Property name="Size">320, 472</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryModulTree" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (481, N'CtlVmProzess', NULL, 5, N'Übersicht', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">335, 610</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaLeistung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (482, N'CtlVmRevisionen', NULL, 5, N'Vormundschaftliche Massnahme / V-Massnahmen / Register, Kontrolle', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">919, 659</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmBericht" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (483, N'CtlVmRevisionen2', NULL, 5, N'Vormundschaftliche Massnahme / V-Massnahmen / Register, Kontrolle (2)', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">335, 610</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmBericht" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (484, N'CtlVmSachversicherung', NULL, 5, N'Vormundschaftliche Massnahme / Administration / Sachversicherungen', N'KiSS4.Common.KissSearchLogischesLoeschenUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1635, 1012</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmSachversicherung" />
</Property>
</Object>', 0, N'Sachversicherung', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (485, N'CtlVmSchulden', NULL, 5, N'Vormundschaftliche Massnahme / Finanzen / Schulden', N'KiSS4.Common.KissSearchLogischesLoeschenUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1635, 1012</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmSchulden" />
</Property>
</Object>', 0, N'Schulden', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (231, N'CtlVmSiegelung', NULL, 5, N'Erbschaftsamt / Siegelungsdienst', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">335, 793</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmSiegelung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (232, N'CtlVmSituationsbericht', NULL, 5, N'Vormundschaftliche Massnahme / Mandatsführung / Situationsberichte SH', N'KiSS4.Common.KissSearchLogischesLoeschenUserControl', 2110, NULL, N'<Object>
  <Property name="Size">808, 749</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmSituationsbericht" />
</Property>
</Object>', 0, N'Situationsbericht', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (233, N'CtlVmSozialversicherung', NULL, 5, N'Vormundschaftliche Massnahme / Administration / Sozialversicherungen', N'KiSS4.Common.KissSearchLogischesLoeschenUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1635, 1012</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmSozialversicherung" />
</Property>
</Object>', 0, N'Sozialversicherungen', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (234, N'CtlVmSteuern', NULL, 5, N'Vormundschaftliche Massnahme / Administration / Steuern', N'KiSS4.Common.KissSearchLogischesLoeschenUserControl', 2110, NULL, N'<Object>
  <Property name="Size">1635, 1012</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmSteuern" />
</Property>
</Object>', 0, N'Steuern', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (235, N'CtlVmTestament', NULL, 5, N'Erbschaftsamt / Testamentsdienst', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">995, 824</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmTestament" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (236, N'CtlVmTestamentBescheinigung', NULL, 5, N'Erbschaftsamt / Testamentsdienst / Bescheinigungen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">995, 824</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmTestamentBescheinigung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (237, N'CtlVmTestamentVerfuegung', NULL, 5, N'Erbschaftsamt / Testamentsdienst / letztwillige Verfügung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">995, 824</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmTestamentVerfuegung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (238, N'CtlVmVaterschaftVerlauf', NULL, 5, N'Vaterschaftsabklärung / Verlauf', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">335, 793</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmVaterschaft" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (239, N'CtlWhASVSErfassung', NULL, 3, N'ASV', N'KiSS4.Gui.KissUserControl', NULL, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
    <Property name="Name" xsi:type="System.String">CtlWhASVSErfassung</Property>
  </Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (240, N'CtlWhBudget', NULL, 3, N'Master- und Monatsbudget', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Size" xsi:type="System.Drawing.Size">836, 554</Property>
  <Property name="Name" xsi:type="System.String">CtlWhBudget</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgPosition" />
  </Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (241, N'CtlWhFinanzplan', NULL, 3, N'Regulärer Finanzplan Übersicht', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">847, 643</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgFinanzplan" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (242, N'CtlWhKlientenabrechnung', NULL, 3, N'S - CtlWhKlientenabrechnung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlWhKlientenabrechnung</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">842, 697</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (243, N'CtlWhKontoauszug', NULL, 3, N'Kontoauszug', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryKontoauszug" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlWhKontoauszug</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">852, 664</Property>
</Object>', 0, N'TODO: logger wieder einschalten!', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (244, N'CtlWhLeistung', NULL, 3, N'Sozialhilfeleistung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">847, 643</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaLeistung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (245, N'CtlWhModulTree', NULL, 3, N'Wirtschaftliche Hilfe ModulTree', N'KiSS4.Common.KissModulTree', 2120, NULL, N'<Object xsi:type="KiSS4.Common.KissModulTree" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlWhModulTree</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (246, N'CtlWhPersonen', NULL, 3, N'Personen im Haushalt', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">847, 643</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryHaushalt" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (247, N'CtlWhSpezialkonto', NULL, 3, N'Spezialkonti', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgSpezkonto" />
  </Property>
  <Property name="Name" xsi:type="System.String">CtlWhSpezialkonto</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">680, 586</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (248, N'CtlWpfMask', NULL, -8, NULL, N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">627, 493</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (249, N'CtlXRight', NULL, 11, N'DSGN - CtlXRight', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
  <Property name="Size">598, 499</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXRight" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (250, N'CtlZahlungsweg', NULL, -7, NULL, N'KiSS4.Gui.KissComplexControl', 200, NULL, N'<Object>
  <Property name="Size">616, 120</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (251, N'CtlZuordnungKreditor', NULL, 10, N'ADM - CtlZuordnungKreditor', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">CtlZuordnungKreditor</Property>
  <Property name="Size" xsi:type="System.Drawing.Size">1014, 614</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (252, N'CtlZusatzleistungenZH', NULL, 1, NULL, N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (253, N'DlgAbout', NULL, -1, N'Hilfe Über Dialog', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Über</Property>
  <Property name="ClientSize">593, 317</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (254, N'DlgAbzahlungskontoAbschliessen', NULL, 3, NULL, N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Abzahlungskonto abschliessen</Property>
  <Property name="ClientSize">398, 75</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (255, N'DlgAuswahl', NULL, -7, NULL, N'KiSS4.Gui.KissLookupDialog', NULL, NULL, N'<Object>
  <Property name="Text">Auswahl</Property>
  <Property name="ClientSize">424, 366</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (256, N'DlgAuswahlBank', NULL, 14, N'FIB - DlgAuswahlBank', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Auswahl</Property>
  <Property name="ClientSize">1142, 401</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (257, N'DlgAuswahlBaZahlungsweg', NULL, -7, N'BA - DlgAuswahlBaZahlungsweg', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object xsi:type="KiSS4.Gui.KissDialog" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="AcceptButton">
    <Reference name="btnOK" />
  </Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBaZahlungsweg" />
  </Property>
  <Property name="CancelButton">
    <Reference name="btnAbbruch" />
  </Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">778, 507</Property>
  <Property name="Name" xsi:type="System.String">DlgAuswahlBaZahlungsweg</Property>
  <Property name="Text" xsi:type="System.String">Auswahl Zahlungsweg</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (258, N'DlgAuswahlFbZahlungsweg', NULL, 14, N'Anwendung / Mandatsbuchhaltung / Stammdaten / Daueraufträge / KontoNr/Kreditor/IBAN', N'KiSS4.Gui.KissForm', 300, NULL, N'<Object>
  <Property name="Text">Auswahl Zahlungsweg</Property>
  <Property name="ClientSize">923, 487</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (259, N'DlgAuswahlKbKostenstelle', NULL, 17, N'Anwendung / Klientenbuchhaltung / Bearbeiten / Buchungen erfassen / Kostenarten', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object xsi:type="KiSS4.Gui.KissDialog" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="AcceptButton">
    <Reference name="btnOK" />
  </Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryKbKostenstelle" />
  </Property>
  <Property name="CancelButton">
    <Reference name="btnAbbruch" />
  </Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">778, 507</Property>
  <Property name="Name" xsi:type="System.String">DlgAuswahlKbKostenstelle</Property>
  <Property name="Text" xsi:type="System.String">Auswahl Kostenstelle</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (260, N'DlgAyBewilligung', NULL, 6, N'Finanzielle Unterstützung / Budget / Bewilligung erteilen', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Masterbudget beenden</Property>
  <Property name="ClientSize">488, 270</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (261, N'DlgAyPosition', NULL, 6, N'Finanzielle Unterstützung / Budget / Budgetposition einfügen', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Budget - Ausgaben</Property>
  <Property name="ClientSize">458, 416</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgPosition" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (262, N'DlgAyVerlaufBudget', NULL, 6, N'Finanzielle Unterstützung / Budget / Verlauf anzeigen', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Verlauf des Monatsbudget #276575</Property>
  <Property name="ClientSize">800, 312</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgBewilligung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (263, N'DlgAyVerlaufFinanzplan', NULL, 6, N'Finanzielle Unterstützung / Budget / Masterbudget Verlauf', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Bewilligung Masterbudget</Property>
  <Property name="ClientSize">800, 328</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgBewilligung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (264, N'DlgBankenabgleich', NULL, 0, N'Dialog für Bankenstamm-Aktualisierung', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Bankenstamm-History</Property>
  <Property name="ClientSize">702, 470</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBaBank" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (265, N'DlgBelegLeser', NULL, -7, NULL, N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Frage</Property>
  <Property name="ClientSize">340, 88</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (266, N'DlgBewilligung', NULL, 3, N'Regulärer Finanzplan Übersicht / Bewilligung', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Bestehende Bewilligung aufheben</Property>
  <Property name="ClientSize">488, 270</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgBewilligung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (456, N'DlgBfsNeuesDossier', NULL, 16, N'System / Sostat / Bearbeiten / Dossiers / Dossier / Neues Dossier', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object xsi:type="KiSS4.Gui.KissDialog" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">407, 178</Property>
  <Property name="Name" xsi:type="System.String">DlgBfsNeuesDossier</Property>
  <Property name="Text" xsi:type="System.String">Neues Dossier</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (457, N'DlgDemographieH', NULL, 1, N'Dialog Person Demographie Historisiert', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">History</Property>
  <Property name="ClientSize">958, 500</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (458, N'DlgErfassungPerson', NULL, -1, NULL, N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Person suchen</Property>
  <Property name="ClientSize">929, 603</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (459, N'DlgEzagInfo', NULL, 0, NULL, N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">EBanking Auftrag Informationen</Property>
  <Property name="ClientSize">550, 392</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (460, N'DlgFaTransferPhase', NULL, 2, N'F - DlgFaTransferPhase', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Daten kopieren aus der Vorphase (27.04.2008 - 28.04.2008)</Property>
  <Property name="ClientSize">770, 472</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryEinzelfeld" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (461, N'DlgFileDelete', NULL, -8, NULL, N'KiSS4.Gui.KissDialog', 3200, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (462, N'DlgGeheZu', NULL, -1, N'Gehe zu', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Gehe zu ...</Property>
  <Property name="ClientSize">306, 266</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (463, N'DlgInputBox', NULL, 11, NULL, N'KiSS4.Gui.KissDialog', 3200, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (464, N'DlgKbWVJournal', NULL, 17, N'Anwendung / Klientenbuchhaltung / Weiterverrechnung / WV-Abrechnung / Journal anzeigen', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object xsi:type="KiSS4.Gui.KissDialog" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="CancelButton">
    <Reference name="btnCloseDialog" />
  </Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">712, 370</Property>
  <Property name="FormBorderStyle" xsi:type="System.Windows.Forms.FormBorderStyle">Sizable</Property>
  <Property name="Name" xsi:type="System.String">DlgKbWVJournal</Property>
  <Property name="Text" xsi:type="System.String">WV - Journal</Property>
</Object>', 0, N'Dialog für das WV-Journal (Ansicht des Ausdrucks als Liste mit Personen und Beträgen)', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (465, N'DlgKissUserControl', NULL, -7, N'Dialog', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Vorschau</Property>
  <Property name="ClientSize">816, 546</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (466, N'DlgLandesindexKopieren', NULL, 4, N'System / Modul Konfiguration / Inkasso / Landesindex / Neuer Landesindex', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Landesindex erfassen</Property>
  <Property name="ClientSize">321, 207</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (467, N'DlgLandesindexWertErfassen', NULL, 4, N'System / Modul Konfiguration / Inkasso / Landesindex / Neue Monatswerte erfassen', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Indexwerte erfassen</Property>
  <Property name="ClientSize">294, 272</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (468, N'DlgMehrfacheintrag', NULL, -7, N'Mehrfachauswahl', N'KiSS4.Gui.KissDialog', 3200, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (469, N'DlgMemoEdit', NULL, -8, N'DlgMemoEdit', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Memo editieren</Property>
  <Property name="ClientSize">989, 729</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (470, N'DlgNeuePerson', NULL, 1, N'B - DlgNeuePerson', N'KiSS4.Common.DlgPersonSucheNeu', NULL, NULL, N'<Object xsi:type="KiSS4.Common.DlgPersonSucheNeu, DlgPersonSucheNeu, Version=4.0.3120.25663, Culture=neutral, PublicKeyToken=null" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">692, 579</Property>
  <Property name="Name" xsi:type="System.String">DlgNeuePerson</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (267, N'DlgNeuerFall', NULL, -1, N'Dialog Neuer Fall', N'KiSS4.Common.DlgPersonSucheNeu', NULL, NULL, N'<Object xsi:type="KiSS4.Common.DlgPersonSucheNeu" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">693, 573</Property>
  <Property name="Name" xsi:type="System.String">DlgNeuerFall</Property>
  <Property name="Text" xsi:type="System.String">Neuer Fall</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (268, N'DlgNewDocument', NULL, 13, N'DOC - DlgNewDocument', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Neues Dokument erstellen</Property>
  <Property name="ClientSize">412, 426</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (269, N'DlgPendenzErfassen', NULL, 21, N'Anwendung / Pendenz erfassen', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Pendenz erfassen</Property>
  <Property name="ClientSize">561, 308</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (270, N'DlgPendenzSelektionVerarbeiten', NULL, 21, N'Anwendung / Pendenzverwaltung / Verarbeiten', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Pendenzen verarbeiten</Property>
  <Property name="ClientSize">576, 278</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (271, N'DlgPendenzWeiterleiten', NULL, 21, N'Anwendung / Pendenzverwaltung / Weiterleiten', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Pendenz weiterleiten</Property>
  <Property name="ClientSize">532, 226</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (272, N'DlgPersonSucheNeu', NULL, -7, N'BA - Neue Person', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object xsi:type="KiSS4.Gui.KissDialog" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">692, 544</Property>
  <Property name="Name" xsi:type="System.String">DlgPersonSucheNeu</Property>
  <Property name="Text" xsi:type="System.String">Neue Person</Property>
  <Event name="Activated" xsi:type="System.String">DlgPersonSucheNeu_Activated</Event>
  <Event name="Search" xsi:type="System.String">DlgPersonSucheNeu_Search</Event>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (273, N'DlgReportMenu', NULL, 12, N'QU - DlgReportMenu', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Report Auswahl</Property>
  <Property name="ClientSize">338, 344</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (274, N'DlgReportParameter', NULL, 12, N'QU - DlgReportParameter', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Report Parameter</Property>
  <Property name="ClientSize">482, 248</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (275, N'DlgRTFEdit', NULL, -8, N'DlgRTFEdit', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Memo editieren (formatiert)</Property>
  <Property name="ClientSize">658, 399</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (276, N'DlgSelectHyperlink', NULL, -8, N'DlgSelectHyperlink', N'KiSS4.Gui.KissDialog', 3200, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (277, N'DlgSelectNewTemplate', NULL, 13, NULL, N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Neue Vorlage auswählen</Property>
  <Property name="ClientSize">680, 388</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (278, N'DlgSelectTranslation', NULL, -8, NULL, N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Maske wählen</Property>
  <Property name="ClientSize">473, 266</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (279, N'DlgShKopfteilung', NULL, 3, NULL, N'KiSS4.Gui.KissDialog', 3200, NULL, NULL, 0, N'wird in kiss4 nicht mehr benutzt', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (280, N'DlgTextEditorControl', NULL, 11, N'DSGN - DlgTextEditorControl', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Code editieren</Property>
  <Property name="ClientSize">1067, 625</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (281, N'DlgTranslateMask', NULL, -8, N'DlgTranslateMask', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Übersetzung - FrmKasse</Property>
  <Property name="ClientSize">794, 288</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (282, N'DlgTranslateMemoEdit', NULL, -8, N'DlgTranslateMemoEdit', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Memo editieren</Property>
  <Property name="ClientSize">640, 425</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryText" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (283, N'DlgUserBDEDetails', NULL, 20, N'System / Benutzerverwaltung / Benutzer / Benutzer / Personaldaten / Werte ändern', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Benutzer - BDE-Details</Property>
  <Property name="ClientSize">894, 562</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBDEPensum_XUser" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (284, N'DlgVmBewertungAdmin', NULL, 5, N'Anwendung / VM Fallgewichtung / Admin', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">VM Fallgewichtung Administration</Property>
  <Property name="ClientSize">370, 128</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (285, N'DlgVmErbeTransfer', NULL, 5, N'Erbschaftsamt / Erbschaftsdienst / Erben / Erben übernehmen', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Erben übernehmen</Property>
  <Property name="ClientSize">846, 412</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryVmErbe" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (287, N'DlgWhBudgetVerlauf', NULL, 3, N'Monatsbudget / Bewilligungsverlauf des Masterbudgets', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Verlauf des Monatsbudget #260610</Property>
  <Property name="ClientSize">800, 406</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgBewilligung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (288, N'DlgWhFinanzplanBeenden', NULL, 3, N'Regulärer Finanzplan Übersicht / Finanzplan beenden', N'KiSS4.Sozialhilfe.DlgBewilligung', 3200, NULL, N'<Object>
  <Property name="Text">Finanzplan vorzeitig beenden</Property>
  <Property name="ClientSize">488, 361</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (289, N'DlgWhFinanzplanVerlauf', NULL, 3, N'Regulärer Finanzplan Übersicht / Finanzplan Verlauf', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Bewilligung Finanzplan</Property>
  <Property name="ClientSize">800, 406</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgBewilligung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (290, N'DlgWhPositionAnpassen', NULL, 3, N'Finanzplan / Position / Position anpassen', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object xsi:type="KiSS4.Gui.KissDialog" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="CancelButton">
    <Reference name="btnAbbrechen" />
  </Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">442, 139</Property>
  <Property name="Name" xsi:type="System.String">DlgWhPositionAnpassen</Property>
  <Property name="Text" xsi:type="System.String">Anpassung {0}</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (291, N'DlgWhWeitereKOA', NULL, 3, N'Anwendung / SH - Auszahlungen / Position / Weitere KoA', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object xsi:type="KiSS4.Gui.KissDialog" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgPosition" />
  </Property>
  <Property name="CancelButton">
    <Reference name="btnAbbrechen" />
  </Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">807, 355</Property>
  <Property name="Name" xsi:type="System.String">DlgWhWeitereKOA</Property>
  <Property name="Text" xsi:type="System.String">Weitere LA</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (292, N'DlgWhWeitereZahlinfo', NULL, 3, N'Monatsbudget / Position / Bemerkung / weitere Zahlinfos', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object xsi:type="KiSS4.Gui.KissDialog" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgAuszahlungPerson" />
  </Property>
  <Property name="CancelButton">
    <Reference name="btnAbbrechen" />
  </Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">541, 515</Property>
  <Property name="Name" xsi:type="System.String">DlgWhWeitereZahlinfo</Property>
  <Property name="Text" xsi:type="System.String">Weitere Zahlinfos</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (293, N'DlgYellownetValutaDatum', NULL, 14, N'FIB - DlgYellownetValutaDatum', N'KiSS4.Gui.KissForm', 300, NULL, N'<Object>
  <Property name="Text">Ausführungsdatum für EZAG-Aufträge</Property>
  <Property name="ClientSize">292, 86</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (294, N'DlgZahlungenErfassen', NULL, 4, N'Kontoauszug / neue Zahlung', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object xsi:type="KiSS4.Gui.KissDialog" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="CancelButton">
    <Reference name="btnCancel" />
  </Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">894, 548</Property>
  <Property name="Name" xsi:type="System.String">DlgZahlungenErfassen</Property>
  <Property name="Text" xsi:type="System.String">Zahlung erfassen</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (295, N'FavoritesView', NULL, 0, NULL, N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">Favoritenverwaltung</Property>
  <Property name="ClientSize">592, 469</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (296, N'FrmArchiveManagement', NULL, 10, N'ADM - FrmArchiveManagement', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">Archivverwaltung</Property>
  <Property name="ClientSize">1128, 906</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (297, N'FrmAyKasse', NULL, 6, N'Anwendung / AY - Kasse', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object xsi:type="KiSS4.Gui.KissChildForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">820, 490</Property>
  <Property name="Name" xsi:type="System.String">FrmAyKasse</Property>
  <Property name="Text" xsi:type="System.String">AY Kasse</Property>
  <Event name="Search" xsi:type="System.String">FrmAyKasse_Search</Event>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (298, N'FrmBatchKVG', NULL, 3, N'Anwendung / SH - Krankenkassenprämien', N'KiSS4.Common.KissSearchForm', 3110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryFall" />
  </Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">1192, 571</Property>
  <Property name="Name" xsi:type="System.String">FrmBatchKVG</Property>
  <Property name="Text" xsi:type="System.String">Krankenkassenprämien</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (299, N'FrmBDEVisumKostenstelle', NULL, 20, N'Anwendung / Visum Kostenstelle', N'KiSS4.Common.KissNavBarForm', 3120, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (300, N'FrmBDEZeiterfassung', NULL, 20, N'Anwendung / Zeiterfassung', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">Zeiterfassung</Property>
  <Property name="ClientSize">982, 601</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryData" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (301, N'FrmConfig', NULL, 10, N'ADM - FrmConfig', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">Konfiguration</Property>
  <Property name="ClientSize">881, 399</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryValue" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (302, N'FrmDataCorrection', NULL, 10, N'ADM - FrmDataCorrection', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object>
  <Property name="Text">Datenbereinigung</Property>
  <Property name="ClientSize">992, 643</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (303, N'FrmDataEditor', NULL, 10, N'ADM - FrmDataEditor', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">Dateneditor</Property>
  <Property name="ClientSize">772, 491</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qry" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (304, N'FrmDataExplorer', NULL, 12, N'Anwendung / Daten-Explorer', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">Daten-Explorer</Property>
  <Property name="ClientSize">884, 562</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (305, N'FrmDesigner', NULL, 11, N'DSGN - FrmDesigner', N'KiSS4.Common.KissNavTreeForm', 3130, NULL, N'<Object>
  <Property name="Text">Business Designer</Property>
  <Property name="ClientSize">800, 556</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (306, N'FrmDocTemplate', NULL, 10, N'ADM - FrmDocTemplate', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object>
  <Property name="Text">Vorlagenverwaltung</Property>
  <Property name="ClientSize">992, 643</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (307, N'FrmDynaMask', NULL, 10, N'ADM - FrmDynaMask', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">Eigene Masken</Property>
  <Property name="ClientSize">992, 626</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (308, N'FrmFall', NULL, -1, N'Fallführungsfenster', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">Fallbearbeitung</Property>
  <Property name="ClientSize">914, 519</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (309, N'FrmFallInfo', NULL, -7, N'Fallinfo', N'KiSS4.Gui.KissForm', 300, NULL, N'<Object>
  <Property name="Text">Fallinfo</Property>
  <Property name="ClientSize">952, 484</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFaLeistung" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (310, N'FrmFallNavigator', NULL, -1, N'Fallnavigator', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object xsi:type="KiSS4.Gui.KissChildForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">615, 547</Property>
  <Property name="Name" xsi:type="System.String">FrmFallNavigator</Property>
  <Property name="Text" xsi:type="System.String">Fall-Navigator</Property>
  <Event name="RefreshData" xsi:type="System.String">FrmFallNavigator_RefreshData</Event>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (311, N'FrmFallZugriff', NULL, -7, N'Fallzugriff', N'KiSS4.Gui.KissForm', 300, NULL, N'<Object>
  <Property name="Text">Fallzugriff</Property>
  <Property name="ClientSize">589, 383</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryFall" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (312, N'FrmFaZeitachse', NULL, 28, N'Klient / Zeitachse', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">Zeitachse</Property>
  <Property name="ClientSize">1410, 768</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (313, N'FrmFibu', NULL, 14, N'Anwendung / Mandatsbuchhaltung', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">Mandatsbuchhaltung</Property>
  <Property name="ClientSize">1004, 579</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (314, N'FrmFsFallsteuerung', NULL, 26, N'Anwendung / Fallsteuerung', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object>
  <Property name="Text">Fallsteuerung</Property>
  <Property name="ClientSize">800, 522</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (315, N'FrmGvGesuchverwaltung', NULL, 27, N'Anwendung / Gesuchverwaltung', N'KiSS4.Gui.KissChildForm', 3100, NULL, NULL, 0, N'Form, die CtlGvGesuchverwaltung beinhaltet', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (317, N'FrmInstitutionenStamm', NULL, 1, N'Institutionenstamm', N'KiSS4.Common.KissSearchForm', 3110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ActiveSQLQuery">
    <Reference name="qryBaInstitution" />
  </Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">746, 638</Property>
  <Property name="Name" xsi:type="System.String">FrmInstitutionenStamm</Property>
  <Property name="Text" xsi:type="System.String">Institutionen-Stamm</Property>
</Object>', 0, N'Bern: Zahlungsverbindung wird nur in Klientenbuchhaltung erfasst (KbKreditor), im Institutionenstamm Read-only.
  --> 20.06.2008 ck: Ob Read-Only oder nicht wird über Rechte geregelt!

Kreditor/Debitor muss nicht zwingend erfasst werden
200308 mar: Maske i.O.', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (318, N'FrmKaAMMBescheinigung', NULL, 7, N'KA / AMM Bescheinigung', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">AMM Bescheinigung</Property>
  <Property name="ClientSize">1273, 914</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryAMMBesch" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (319, N'FrmKaEinsatzorte', NULL, 7, N'KA / KA Einsatzorte', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object xsi:type="KiSS4.Common.KissNavBarForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">872, 553</Property>
  <Property name="Name" xsi:type="System.String">FrmKaEinsatzorte</Property>
  <Property name="Text" xsi:type="System.String">KA Einsatzorte</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (320, N'FrmKaEinsatzplatz', NULL, 7, N'KA / Einsatzplatz', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">KA Einsatzplatz</Property>
  <Property name="ClientSize">864, 506</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryEinsatzplatz" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (321, N'FrmKaKurs', NULL, 7, N'KA / Kurse', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">Kurs</Property>
  <Property name="ClientSize">847, 506</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryKurs" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
GO
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (322, N'FrmKaKurserfassung', NULL, 7, N'KA / Kurserfassung', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">Kurserfassung</Property>
  <Property name="ClientSize">662, 436</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryKurse" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (323, N'FrmKaPraesenzzeit', NULL, 7, N'KA / Präsenzzeiterfassung', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">KA Präsenzzeiterfassung</Property>
  <Property name="ClientSize">1216, 616</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryPraesenz" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (324, N'FrmKaSequenzen', NULL, 7, N'KA / Sequenzen', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">KA Sequenzen</Property>
  <Property name="ClientSize">1080, 606</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qrySequenzen" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (325, N'FrmKasse', NULL, 3, N'Anwendung / SH - Kasse', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object xsi:type="KiSS4.Gui.KissChildForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">820, 562</Property>
  <Property name="Name" xsi:type="System.String">FrmKasse</Property>
  <Property name="Text" xsi:type="System.String">SH Kasse</Property>
  <Event name="Search" xsi:type="System.String">FrmKasse_Search</Event>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (407, N'FrmKbAuswKlientenkonto', NULL, 17, N'Anwendung / Kontenabfrage aus KiSS', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object xsi:type="KiSS4.Gui.KissChildForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">811, 589</Property>
  <Property name="Name" xsi:type="System.String">FrmKbAuswKlientenkonto</Property>
  <Property name="Text" xsi:type="System.String">Kontenabfrage aus KiSS</Property>
</Object>', 0, N'gleiches Control wie CtlQueryKbKlientenkonto', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (408, N'FrmKbKlientenbuchhaltung', NULL, 17, N'Anwendung / Klientenbuchhaltung', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object xsi:type="KiSS4.Common.KissNavBarForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">954, 694</Property>
  <Property name="Name" xsi:type="System.String">FrmKbKlientenbuchhaltung</Property>
  <Property name="Text" xsi:type="System.String">Klientenbuchhaltung</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (409, N'FrmLinkManagement', NULL, 10, N'ADM - FrmLinkManagement', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object>
  <Property name="Text">Linkverwaltung</Property>
  <Property name="ClientSize">992, 643</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (410, N'FrmLogin', NULL, -1, N'Anmeldungsfenster', N'KiSS4.Gui.KissForm', 300, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (411, N'FrmMain', NULL, -1, N'Hauptfenster', N'KiSS4.Gui.KissMainForm', NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (412, N'FrmManualAllgemein', NULL, -1, N'Benutzerhandbuch', N'KiSS4.Main.ManualBaseForm', 3100, NULL, N'<Object>
  <Property name="Text">FrmManualAllgemein</Property>
  <Property name="ClientSize">116, 0</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (413, N'FrmManualBenutzerrechte', NULL, -1, N'Handbuch Benutzerrechte', N'KiSS4.GUI.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (414, N'FrmManualFibu', NULL, -1, N'Handbuch Mandatsbuchhaltung', N'KiSS4.GUI.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (415, N'FrmManualInkasso', NULL, -1, N'Handbuch Inkasso', N'KiSS4.Main.ManualBaseForm', 3100, NULL, N'<Object>
  <Property name="Text">FrmManualInkasso</Property>
  <Property name="ClientSize">1916, 1086</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (416, N'FrmManualKlibu', NULL, -1, N'Handbuch Klientenbuchhaltung', N'KiSS4.Main.ManualBaseForm', 3100, NULL, N'<Object>
  <Property name="Text">FrmManualInkasso</Property>
  <Property name="ClientSize">116, 0</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (417, N'FrmManualPendenzenverwaltung', NULL, -1, N'Handbuch Pendenzenverwaltung', N'KiSS4.Main.ManualBaseForm', 3100, NULL, N'<Object>    <Property name="Text">FrmManualPendenzenverwaltung</Property>    <Property name="ClientSize">1008, 682</Property>  </Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (418, N'FrmManualSostat', NULL, -1, N'Handbuch Sostat', N'KiSS4.Main.ManualBaseForm', 3100, NULL, N'<Object>
  <Property name="Text">FrmManualInkasso</Property>
  <Property name="ClientSize">1008, 682</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (419, N'FrmManualSozialhilfe', NULL, -1, N'Handbuch Sozialhilfe', N'KiSS4.GUI.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (420, N'FrmManualSystem', NULL, -1, N'Handbuch Systemadministration', N'KiSS4.Main.ManualBaseForm', 3100, NULL, N'<Object>
  <Property name="Text">FrmManualInkasso</Property>
  <Property name="ClientSize">116, 0</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (421, N'FrmMaskDesigner', NULL, 11, N'DSGN - FrmMaskDesigner', N'KiSS4.Gui.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (422, N'FrmMassendruckPapierVerfuegung', NULL, 3, N'S - FrmMassendruckPapierVerfuegung', N'KiSS4.Gui.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (423, N'FrmModulConfig', NULL, 10, N'ADM - FrmModulConfig', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object xsi:type="KiSS4.Common.KissNavBarForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">800, 486</Property>
  <Property name="Name" xsi:type="System.String">FrmModulConfig</Property>
  <Property name="Text" xsi:type="System.String">Modul Konfiguration</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (424, N'FrmMultilanguage', NULL, 10, N'ADM - FrmMultilanguage', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object>
  <Property name="Text">Meldungen</Property>
  <Property name="ClientSize">1276, 898</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (425, N'FrmNewodAdmin', NULL, 25, N'Anwendung / NEWOD Schnittstelle', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object>
		  <Property name="Text">KissNavBarForm</Property>
		  <Property name="ClientSize">800, 522</Property>
		</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, N'Newod')
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (326, N'FrmPendenzenAdmin', NULL, 21, N'System / Pendenzenadministration', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object>
  <Property name="Text">Pendenzenadministration</Property>
  <Property name="ClientSize">800, 522</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (327, N'FrmPendenzenVerwaltung', NULL, 21, N'Anwendung / Pendenzverwaltung', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object>
  <Property name="Text">Pendenzenverwaltung</Property>
  <Property name="ClientSize">920, 670</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryXTask" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (328, N'FrmPersonenStamm', NULL, 1, N'Personenstamm', N'KiSS4.Common.KissSearchForm', 3110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Text" xsi:type="System.String">Personen-Stamm</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBaPerson" />
  </Property>
  <Property name="Name" xsi:type="System.String">FrmPersonenStamm</Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">840, 526</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (329, N'FrmPriMa', NULL, 5, N'Stammdaten / VM Private Mandatsträger', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">Private Mandatsträger</Property>
  <Property name="ClientSize">1011, 687</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryPriMa" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (330, N'FrmQueryManagement', NULL, 12, N'QU - FrmQueryManagement', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object>
  <Property name="Text">Report- und Abfrageverwaltung</Property>
  <Property name="ClientSize">1252, 819</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (331, N'FrmRavBerater', NULL, 1, N'B - FrmRavBerater', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">KA externe Berater</Property>
  <Property name="ClientSize">722, 566</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryKontakt" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (332, N'FrmReportViewer', NULL, 12, N'QU - FrmReportViewer', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">Report Vorschau</Property>
  <Property name="ClientSize">864, 590</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (333, N'FrmSostat', NULL, 16, N'System / Sostat', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object xsi:type="KiSS4.Common.KissNavBarForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">800, 522</Property>
  <Property name="Name" xsi:type="System.String">FrmSostat</Property>
  <Property name="Text" xsi:type="System.String">Sostat</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (334, N'FrmUserManagement', NULL, 10, N'ADM - FrmUserManagement', N'KiSS4.Common.KissNavBarForm', 3120, NULL, N'<Object xsi:type="KiSS4.Common.KissNavBarForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="ClientSize" xsi:type="System.Drawing.Size">842, 643</Property>
  <Property name="Name" xsi:type="System.String">FrmUserManagement</Property>
  <Property name="Text" xsi:type="System.String">Benutzerverwaltung</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (335, N'FrmVmBewertung', NULL, 5, N'Anwendung / VM Fallgewichtung', N'KiSS4.Gui.KissChildForm', 3100, NULL, N'<Object>
  <Property name="Text">VM Fallgewichtung</Property>
  <Property name="ClientSize">1276, 918</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryMandant" />
</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (336, N'FrmVmKasse', NULL, 5, N'Anwendung / VM - Kasse', N'KiSS4.Common.KissSearchForm', 3110, NULL, N'<Object>    <Property name="Size">1114, 869</Property>  </Object>', 0, N'Klasse um die VM-Kasse zu handeln', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (366, N'FrmWhASVSExport', NULL, 3, N'System / ASV Export', N'KiSS4.Gui.KissUserControl', NULL, NULL, N'<Object xsi:type="KiSS4.Gui.KissUserControl" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Name" xsi:type="System.String">FrmWhASVSExport</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (367, N'FrmWhAuszahlungen', NULL, 3, N'Anwendung / SH - Auszahlungen', N'KiSS4.Common.KissSearchForm', 3110, NULL, N'<Object xsi:type="KiSS4.Common.KissSearchForm" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <Property name="Text" xsi:type="System.String">WH Einzelzahlungen</Property>
  <Property name="ActiveSQLQuery">
    <Reference name="qryBgPosition" />
  </Property>
  <Property name="Name" xsi:type="System.String">FrmWhAuszahlungen</Property>
  <Property name="ClientSize" xsi:type="System.Drawing.Size">831, 631</Property>
</Object>', 0, N'IntegrationBE: Produktiv Build KiSS_PROD! 554 mit DlgWhWeitereKOA Build 184 
(wegen Ticket 4121)
Bern: Produktiv Build 516 mit DlgWhWeitereKOA Build 149

WICHTIG: Build ab 554 sind nicht produktivreif!!!!!!', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (368, N'Kiss.UI.View.Ad.AdPasswortAendernView.xaml', NULL, 1, N'Passwort ändern', N'Kiss.UI.View', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (369, N'Kiss.UI.View.Ba.BaGemeindeView.xaml', NULL, 1, N'BaGemeinde Update', N'Kiss.UI.View', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (370, N'Kiss.UI.View.Ba.BaLandView.xaml', NULL, 1, N'BaLand Update', N'Kiss.UI.View', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (371, N'Kiss.UI.View.Ba.BaPlzView.xaml', NULL, 1, N'BaPLZ Update', N'Kiss.UI.View', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (372, N'Kiss.UI.View.Fa.FaKategorisierungView.xaml', NULL, 2, N'Fallführung - Kategorisierung', N'Kiss.UI.View', 10006, NULL, NULL, 0, N'Verwendet Konfig-Wert "System\Fallfuehrung\Kategorisierung\NurFallfuehrerDarfMutieren"', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (374, N'Kiss.UI.View.Fs.FsAbfrageAuslastungMaView.xaml', NULL, 26, N'Anwendung / Fallsteuerung / Abfragen / Auslastung Mitarbeiter', N'Kiss.UI.View', 10006, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (375, N'Kiss.UI.View.Fs.FsDienstleistungspaketView.xaml', NULL, 26, N'Anwendung / Fallsteuerung / Administration / Dienstleistungspakete', N'Kiss.UI.View', 10006, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (376, N'Kiss.UI.View.Fs.FsDienstleistungView.xaml', NULL, 26, N'Anwendung / Fallsteuerung / Administration / Dienstleistungen', N'Kiss.UI.View', 10006, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (377, N'Kiss.UI.View.Fs.FsReduktionView.xaml', NULL, 26, N'Anwendung / Fallsteuerung / Administration / Reduktionen', N'Kiss.UI.View', 10006, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (378, N'Kiss.UI.View.Fs.FsVerfuegbareArbeitszeitView.xaml', NULL, 26, N'Anwendung / Fallsteuerung / Abfragen / Verfügbare Arbeitszeit', N'Kiss.UI.View', 10006, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (379, N'Kiss.UI.View.Vm.VmKlientenbudgetKategorieView.xaml', NULL, 5, N'Vormundschaftliche Massnahme / Finanzen / Budget (Kategorie)', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, N'VM - Maske zum Verwlaten von Budget-Kategorien', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (380, N'Kiss.UI.View.Vm.VmKlientenbudgetView.xaml', NULL, 5, N'Vormundschaftliche Massnahme / Finanzen / Budget', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, N'VM - Maske zum Verwlaten vom Budget', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (640, N'Kiss.UserInterface.View.Fa.FaAbfrageDokumentAblageView,Kiss.UserInterface.View', N'Kiss.UserInterface.ViewModel.Fa.FaAbfrageDokumentAblageVM,Kiss.UserInterface.ViewModel', 12, N'Anwendung / Daten-Explorer / Fallführung / FF - Dokumente', N'Kiss.UI.View', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (641, N'Kiss.UserInterface.View.Fa.FaDokumentAblageView,Kiss.UserInterface.View', N'Kiss.UserInterface.ViewModel.Fa.FaDokumentAblageVM,Kiss.UserInterface.ViewModel', 12, N'Fallführung / Dokumentation / Dokumentenablage', N'Kiss.UI.View', 2111, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (639, N'Kiss.UserInterface.View.Fa.Timeline.FaTimelineContainerView,Kiss.UserInterface.View', N'Kiss.UserInterface.ViewModel.Fa.Timeline.FaTimelineVM,Kiss.UserInterface.ViewModel', 28, N'Klient / Zeitachse', N'Kiss.UserInterface.View,Kiss.UserInterface.View', NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (373, N'Kiss.UserInterface.View.Fs.FsAbfrageAuslastungGesamtView,Kiss.UserInterface.View', N'Kiss.UserInterface.ViewModel.Fs.FsAbfrageAuslastungGesamtVM,Kiss.UserInterface.ViewModel', 26, N'Anwendung / Fallsteuerung / Abfragen / Auslastung Team', N'Kiss.UI.View', 10006, NULL, NULL, 0, N'FS - Abfrage Auslastung Gesamt', NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (381, N'KissBfsDtpSeitGeburt', NULL, -7, N'Control Seit Geburt', N'KiSS4.Gui.KissComplexControl', 200, NULL, N'<Object>
  <Property name="Size">225, 24</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (382, N'KissChildForm', NULL, -8, NULL, N'KiSS4.Gui.KissForm', 300, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (383, N'KissDialog', NULL, -8, NULL, N'KiSS4.Gui.KissForm', 300, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (384, N'KissForm', NULL, -8, NULL, N'System.Windows.Forms.Form', 3, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (385, N'KissHeimatortEdit', NULL, -7, NULL, N'KiSS4.Gui.KissComplexControl', 200, NULL, N'<Object>
  <Property name="Size">192, 24</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (386, N'KissHelpDialog', NULL, -8, NULL, N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Hilfe</Property>
  <Property name="ClientSize">318, 156</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (387, N'KissLookupDialog', NULL, -8, N'KissLookupDialog', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Auswahl</Property>
  <Property name="ClientSize">361, 318</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (388, N'KissMainForm', NULL, -8, NULL, N'KiSS4.Gui.KissForm', 300, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (389, N'KissMemoEditML', NULL, -8, N'KissMemoEditML', N'KiSS4.Gui.KissComplexControl', 200, NULL, N'<Object>
  <Property name="Size">709, 96</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (390, N'KissModulTree', NULL, -7, N'Control ModulTree', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (391, N'KissMultiCheckEdit', NULL, -8, NULL, N'KiSS4.Gui.KissComplexControl', 200, NULL, N'<Object>
  <Property name="Size">257, 115</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (392, N'KissNavBarForm', NULL, -7, N'Form NavBar', N'KiSS4.Gui.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (393, N'KissNavTreeForm', NULL, -7, N'Form NavTree', N'KiSS4.Gui.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (338, N'KissPickList', NULL, -8, NULL, N'KiSS4.Gui.KissComplexControl', 200, NULL, N'<Object>
  <Property name="Size">573, 654</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (339, N'KissPLZOrt', NULL, -7, N'Control PLZOrt', N'KiSS4.Gui.KissComplexControl', 200, NULL, N'<Object>
  <Property name="Size">265, 24</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (340, N'KissQueryControl', NULL, -7, N'Control Query', N'KiSS4.Common.KissSearchUserControl', 2110, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (341, N'KissSearchDialog', NULL, -1, N'Suchdialog des Hauptfensters', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>    <Property name="Text">KiSS Suchergebnisse</Property>    <Property name="ClientSize">1916, 1086</Property>    <Property name="ActiveSQLQuery">      <Reference name="qry" />  </Property>  </Object>', 0, N'Suchdialog des Hauptfensters', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (342, N'KissSearchForm', NULL, -7, N'Form Search', N'KiSS4.Gui.KissChildForm', 3100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (343, N'KissSearchTitel', NULL, -8, N'KissSearchTitel', N'KiSS4.Gui.KissComplexControl', 200, NULL, N'<Object>
  <Property name="Size">1057, 24</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (344, N'KissSearchUserControl', NULL, -7, N'Control SucheListe', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
INSERT INTO [XClass] ([XClassID], [ClassName], [ClassNameViewModel], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (345, N'KissUserControl', NULL, -8, NULL, N'KiSS4.Gui.KissComplexControl', 200, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [XClass] OFF
GO
COMMIT
GO