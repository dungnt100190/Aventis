/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Skript um das Inkasso-Modul zu lizenzieren.
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
PRINT ('Info: Start of script: [' + CONVERT(VARCHAR, GETDATE(), 113) + ']');
GO

-------------------------------------------------------------------------------
-- Step: XModul (Inkasso-Modul lizenzieren)
-------------------------------------------------------------------------------
PRINT ('Info: XModul (Inkasso-Modul lizenzieren)');
UPDATE MDL
  SET Licensed = 1, ModulTree = 1
FROM dbo.XModul MDL
WHERE ModulID = 4
GO


---------------------------------------------------------------------------------
---- Step: XIcon (Inkasso-Icons hinzufügen)
---------------------------------------------------------------------------------
--PRINT ('Info: XIcon (Inkasso-Icons hinzufügen)');
--SET NOCOUNT ON
--BEGIN TRANSACTION
--GO
--DELETE FROM [XIcon] WHERE XIconID IN (1400, 1401, 1402, 1403, 1410, 1411, 1412, 1413)
--GO
--INSERT INTO [XIcon] ([XIconID], [Name], [Icon]) VALUES (1400, N'0016_Fallführung', 0x0000010001001010100000000000280100001600000028000000100000002000000001000400000000008000000000000000000000001000000010000000ffd7ff00ffffb900cacaff00d5f8d100ffcccc00b0d8ff00800080006a6a00000000ff00008e0000ff0000000080ff00b5b5b500ff00ff0000000000ffffff00ccccccccccccccccceeeeeeeeeeeeeecceeeeecccceeeeecceeeeecccceeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeecccceeeeecceeeeecccceeeeecceeeeeeeeeeeeeeccccccccccccccccc000000007ffe00007c3e00007c3e00007e7e00007e7e00007e7e00007e7e00007e7e00007e7e00007e7e00007e7e00007c3e00007c3e00007ffe000000000000)
--INSERT INTO [XIcon] ([XIconID], [Name], [Icon]) VALUES (1401, N'0006_Fallführung', 0x0000010001001010100000000000280100001600000028000000100000002000000001000400000000008000000000000000000000001000000010000000ffd7ff00ffffb900cacaff00d5f8d100ffcccc00b0d8ff00800080006a6a00000000ff00008e0000ff0000000080ff00ffd2d200ff00ff0000000000ffffff0099999999999999999eeeeeeeeeeeeee99eeeee9999eeeee99eeeee9999eeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeee9999eeeee99eeeee9999eeeee99eeeeeeeeeeeeee99999999999999999000000007ffe00007c3e00007c3e00007e7e00007e7e00007e7e00007e7e00007e7e00007e7e00007e7e00007e7e00007c3e00007c3e00007ffe000000000000)
--INSERT INTO [XIcon] ([XIconID], [Name], [Icon]) VALUES (1402, N'0136_Modul_A_closed.ico', 0x000001000100101010000000000028010000160000002800000010000000200000000100040000000000c000000000000000000000001000000010000000ffd7ff00ffffb900cacaff00d5f8d100ffcccc00b0d8ff00800080006a6a00000000ff00008e0000ff0000000080ff00b5b5b500ff00ff0000000000ffffff0099999999999e999e9eeeeeeeeeeeeeee9eeeeecccceeeee99eeeeecccceeeee99eeeeeecceeeeeee9eeeeeecceeeeeee9eeeeeecceeeeee99eeeeeecceeeeee99eeeeeecceeeeee99eeeeeecceeeeee99eeeeeecceeeeee99eeeeeecceeeeee99eeeeecccceeeee99eeeeecccceeeee99eeeeeeeeeeeeee99999999999999999000000007fe400007c3000007c3000007e6400007e6e00007e7e00007e7e00007e7e00007e7e00007e7e00007e7e00007c3e00007c3e00007ffe000000000000)
--INSERT INTO [XIcon] ([XIconID], [Name], [Icon]) VALUES (1403, N'0146_Modul_A_archived.ico', 0x000001000100101010000000000028010000160000002800000010000000200000000100040000000000c000000000000000000000001000000010000000ffd7ff00ffffb900cacaff00d5f8d100ffcccc00b0d8ff00800080006a6a00000000ff00008e0000ff0000000080ff00b5b5b500ff00ff0000000000ffffff0099999999999e999e9eeeeeeeeeeeeeee9eeeeecccceeeeee9eeeeecccceeeeee9eeeeeecceeeeeee9eeeeeecceeeeee99eeeeeecceeeeee99eeeeeecceeeeee99eeeeeecceeeeee99eeeeeecceeeeee99eeeeeecceeeeee99eeeeeecceeeeee99eeeeecccceeeee99eeeeecccceeeee99eeeeeeeeeeeeee99999999999999999000000007fee00007c2000007c2e00007e6e00007e7400007e7a00007e7e00007e7e00007e7e00007e7e00007e7e00007c3e00007c3e00007ffe000000000000)
--INSERT INTO [XIcon] ([XIconID], [Name], [Icon]) VALUES (1410, N'0014_Fallführung', 0x0000010001001010100000000000280100001600000028000000100000002000000001000400000000008000000000000000000000001000000010000000ffd7ff00ffffb900cacaff00d5f8d100ffcccc00b0d8ff00800080006a6a00000000ff00008e0000ff0000000080ff00b5b5b500ff00ff0000000000ffffff00ccccccccccccccccceeeeeeeeeeeeeecceeeeecccceeeeecceeeeecccceeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeeecceeeeecccceeeeecceeeeecccceeeeecceeeeeeeeeeeeeeccccccccccccccccc000000007ffe00007c3e00007c3e00007e7e00007e7e00007e7e00007e7e00007e7e00007e7e00007e7e00007e7e00007c3e00007c3e00007ffe000000000000)
--INSERT INTO [XIcon] ([XIconID], [Name], [Icon]) VALUES (1411, N'0004_Fallführung', 0x0000010001001010100000000000280100001600000028000000100000002000000001000400000000008000000000000000000000001000000010000000ffd7ff00ffffb900cacaff00d5f8d100ffcccc00b0d8ff00800080006a6a00000000ff00008e0000ff0000000080ff00ffd2d200ff00ff0000000000ffffff0099999999999999999eeeeeeeeeeeeee99eeeee9999eeeee99eeeee9999eeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeeee99eeeee9999eeeee99eeeee9999eeeee99eeeeeeeeeeeeee99999999999999999000000007ffe00007c3e00007c3e00007e7e00007e7e00007e7e00007e7e00007e7e00007e7e00007e7e00007e7e00007c3e00007c3e00007ffe000000000000)
--INSERT INTO [XIcon] ([XIconID], [Name], [Icon]) VALUES (1412, N'0133_Fallführung', 0x000001000100101010000000000028010000160000002800000010000000200000000100040000000000c000000000000000000000001000000010000000ffd7ff00ffffb900cacaff00d5f8d100ffcccc00b0d8ff00800080006a6a00000000ff00008e0000ff0000000080ff00b5b5b500ff00ff0000000000ffffff0099999999999e999e9eeeeeeeeeeeeeee9eeeeecccceeeee99eeeeecccceeeee99eeeeeecceeeeeee9eeeeeecceeeeeee9eeeeeecceeeeee99eeeeeecceeeeee99eeeeeecceeeeee99eeeeeecceeeeee99eeeeeecceeeeee99eeeeeecceeeeee99eeeeecccceeeee99eeeeecccceeeee99eeeeeeeeeeeeee99999999999999999000000007fe400007c3000007c3000007e6400007e6e00007e7e00007e7e00007e7e00007e7e00007e7e00007e7e00007c3e00007c3e00007ffe000000000000)
--INSERT INTO [XIcon] ([XIconID], [Name], [Icon]) VALUES (1413, N'0139_Fallführung', 0x000001000100101010000000000028010000160000002800000010000000200000000100040000000000c000000000000000000000001000000010000000ffd7ff00ffffb900cacaff00d5f8d100ffcccc00b0d8ff00800080006a6a00000000ff00008e0000ff0000000080ff00b5b5b500ff00ff0000000000ffffff0099999999999e999e9eeeeeeeeeeeeeee9eeeeecccceeeeee9eeeeecccceeeeee9eeeeeecceeeeeee9eeeeeecceeeeee99eeeeeecceeeeee99eeeeeecceeeeee99eeeeeecceeeeee99eeeeeecceeeeee99eeeeeecceeeeee99eeeeeecceeeeee99eeeeecccceeeee99eeeeecccceeeee99eeeeeeeeeeeeee99999999999999999000000007fee00007c2000007c2e00007e6e00007e7400007e7a00007e7e00007e7e00007e7e00007e7e00007e7e00007c3e00007c3e00007ffe000000000000)
--GO
--COMMIT
--GO


-------------------------------------------------------------------------------
-- Step: XClass (Inkasso-Masken hinzufügen)
-------------------------------------------------------------------------------
PRINT ('Info: XClass (fehlende Inkasso-Masken hinzufügen)');
SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XClass] WHERE ClassName IN ('DlgLandesindexWertErfassen', 'DlgLandesindexKopieren')
GO

--INSERT INTO [XClass] ([ClassName], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (N'CtlIkAbklaerungen', 4, N'Abklärung / Abklärungen', N'KiSS4.Gui.KissUserControl', 2100, NULL, NULL, 0, N'Inkasso-Abklärungen', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
--INSERT INTO [XClass] ([ClassName], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (N'CtlIkBetreibungenVerlustscheine', 4, N'Betreibungen, Verlustscheine', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
--  <Property name="Size">633, 445</Property>
--  <Property name="ActiveSQLQuery">
--    <Reference name="qryBetreibung" />
--</Property>
--</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
--INSERT INTO [XClass] ([ClassName], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (N'CtlIkForderungen', 4, N'Inkasso Forderungen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
--  <Property name="Size">831, 737</Property>
--  <Property name="ActiveSQLQuery">
--    <Reference name="qryIkForderung" />
--</Property>
--</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
--INSERT INTO [XClass] ([ClassName], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (N'CtlIkGlaeubiger', 4, N'Gläubiger', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
--  <Property name="Size">831, 737</Property>
--</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
--INSERT INTO [XClass] ([ClassName], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (N'CtlIkKontoauszug', 4, N'Kontoauszug', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
--  <Property name="Size">831, 737</Property>
--</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
--INSERT INTO [XClass] ([ClassName], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (N'CtlIkLandesindex', 4, N'System / Modul Konfiguration / Inkasso / Landesindex', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
--  <Property name="Size">627, 455</Property>
--  <Property name="ActiveSQLQuery">
--    <Reference name="qryLandesindex" />
--</Property>
--</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
--INSERT INTO [XClass] ([ClassName], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (N'CtlIkLeistung', 4, N'Inkassoleistung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
--  <Property name="Size">831, 737</Property>
--  <Property name="ActiveSQLQuery">
--    <Reference name="qryFaLeistung" />
--</Property>
--</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
--INSERT INTO [XClass] ([ClassName], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (N'CtlIkModulTree', 4, N'Inkasso ModulTree', N'KiSS4.Common.KissModulTree', 2120, NULL, N'<Object>
--  <Property name="Size">265, 618</Property>
--  <Property name="ActiveSQLQuery">
--    <Reference name="qryModulTree" />
--</Property>
--</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
--INSERT INTO [XClass] ([ClassName], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (N'CtlIkMonatszahlen', 4, N'Alimente / Rechtstitel und Gläubiger / Monatszahlen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
--  <Property name="Size">831, 737</Property>
--  <Property name="ActiveSQLQuery">
--    <Reference name="qryMonatszahlen" />
--</Property>
--</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
--INSERT INTO [XClass] ([ClassName], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (N'CtlIkMonatszahlenEinmalig', 4, N'Inkasso Forderungen - Monatszahlen Einmalig', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
--  <Property name="Size">815, 671</Property>
--  <Property name="ActiveSQLQuery">
--    <Reference name="qryIkPosition" />
--</Property>
--</Object>', 0, N'Wird nicht im Rechtstitel gebraucht -- nur in den Monatszahlen', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
--INSERT INTO [XClass] ([ClassName], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (N'CtlIkMonatszahlenSaldo', 4, N'Inkasso Forderungen - Monatszahlen Saldo', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
--  <Property name="Size">824, 679</Property>
--</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
--INSERT INTO [XClass] ([ClassName], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (N'CtlIkMonatszahlenVerrechnung', 4, N'Inkasso Forderungen - Monatszahlen Verrechnung', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
--  <Property name="Size">1388, 799</Property>
--  <Property name="ActiveSQLQuery">
--    <Reference name="qryVerrechnung" />
--</Property>
--</Object>', 0, N'Wird nicht im Rechtstitel gebraucht', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
--INSERT INTO [XClass] ([ClassName], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (N'CtlIkRechtlicheMassnahmenInkassofall', 4, N'Rechtliche Massnahmen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
--  <Property name="Size">831, 737</Property>
--  <Property name="ActiveSQLQuery">
--    <Reference name="qryIkAnzeige" />
--</Property>
--</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
--INSERT INTO [XClass] ([ClassName], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (N'CtlIkRechtlicheMassnahmenSchuldner', 4, N'Rechtliche Massnahmen Übersicht', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
--  <Property name="Size">1218, 857</Property>
--  <Property name="ActiveSQLQuery">
--    <Reference name="qryIkAnzeige" />
--</Property>
--</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
--INSERT INTO [XClass] ([ClassName], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (N'CtlIkRechtstitel', 4, N'Alimente / Rechtstitel und Gläubiger', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
--  <Property name="Size">831, 737</Property>
--  <Property name="ActiveSQLQuery">
--    <Reference name="qryIkRechtstitel" />
--</Property>
--</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
--INSERT INTO [XClass] ([ClassName], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (N'CtlIkRechtstitelForderung', 4, N'Alimente / Rechtstitel und Gläubiger / Periodische Forderungen', N'KiSS4.Gui.KissUserControl', 2100, NULL, N'<Object>
--  <Property name="Size">815, 654</Property>
--  <Property name="ActiveSQLQuery">
--    <Reference name="qryIkForderung" />
--</Property>
--</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([ClassName], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (N'DlgLandesindexKopieren', 4, N'System / Modul Konfiguration / Inkasso / Landesindex / Neuer Landesindex', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Landesindex erfassen</Property>
  <Property name="ClientSize">321, 207</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
INSERT INTO [XClass] ([ClassName], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (N'DlgLandesindexWertErfassen', 4, N'System / Modul Konfiguration / Inkasso / Landesindex / Neue Monatswerte erfassen', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
  <Property name="Text">Indexwerte erfassen</Property>
  <Property name="ClientSize">294, 272</Property>
</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL)
--INSERT INTO [XClass] ([ClassName], [ModulID], [MaskName], [BaseType], [ClassCode], [ClassTID], [PropertiesXML], [Designer], [Description], [CodeGenerated], [Resource], [Assembly], [Branch], [BuildNr], [System], [CheckOut_UserID], [CheckOut_Date], [NamespaceExtension]) VALUES (N'DlgZahlungenErfassen', 4, N'Kontoauszug / neue Zahlung', N'KiSS4.Gui.KissDialog', 3200, NULL, N'<Object>
--  <Property name="Text">Zahlung erfassen</Property>
--  <Property name="ClientSize">894, 548</Property>
--</Object>', 0, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL)
GO
COMMIT
GO

-------------------------------------------------------------------------------
-- Step: XClass (Inkasso-Abfragen-Masken hinzufügen)
-------------------------------------------------------------------------------
PRINT ('Info: XClass (Inkasso-Abfragen-Masken hinzufügen) --> bereits vorhanden');
--DELETE FROM dbo.XClass WHERE ClassName = 'CtlQueryIKVerlustscheinVerjährung';

--INSERT INTO dbo.XClass (ClassName, ModulID, MaskName, BaseType, ClassCode, [Description])
--  SELECT 'CtlQueryIKVerlustscheinVerjährung', 12, 'QU - CtlQueryIKVerlustscheinVerjährung', 'KiSS4.Common.KissQueryControl', 2111, NULL
GO

-------------------------------------------------------------------------------
-- Step: XRight (Inkasso-Spezialrecht hinzufügen)
-------------------------------------------------------------------------------
PRINT ('Info: XRight (Inkasso-Spezialrecht hinzufügen) --> bereits vorhanden');
--DELETE FROM dbo.XRight WHERE ClassName = 'CtlIkModulTree';

--DECLARE @Creator VARCHAR(50);
--SET @Creator = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID())

--INSERT INTO dbo.XRight (ClassName, RightName, UserText, [Description], Creator, Created, Modifier, Modified)
--  SELECT 'CtlIkModulTree', 'CtlIkModulTree_IkNeueRueckerstattung', 'Inkasso Neue Rückerstattung', '', @Creator, GETDATE(), @Creator, GETDATE() UNION ALL
--  SELECT 'CtlIkModulTree', 'CtlIkModulTree_IkRueckerstattungLoeschen', 'Inkasso Rückerstattung Löschen', '', @Creator, GETDATE(), @Creator, GETDATE() UNION ALL
--  SELECT 'CtlIkModulTree', 'CtlIkModulTree_IkNeuerRechtstitel', 'Inkasso Neue Rechtstitel', '', @Creator, GETDATE(), @Creator, GETDATE() 
GO


-------------------------------------------------------------------------------
-- Step: XModulTree (Inkasso-Tree bauen)
-------------------------------------------------------------------------------
PRINT ('Info: XModulTree (Inkasso-Tree bauen) --> bereits vorhanden');
--SET NOCOUNT ON
--BEGIN TRANSACTION
--GO
--DELETE FROM [XModulTree] WHERE ModulID = 4
--GO
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40002, NULL, 4, 2, 1431, N'Rechtliche Massnahmen', N'CtlIkRechtlicheMassnahmenSchuldner', NULL, N'Alter table #Tree add 
--    Datum datetime,
--    RechtstitelID int', 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40004, NULL, 4, 5, 83, N'Abklärung', N'CtlIkLeistung', NULL, N'Alter table #Tree add 
--  SchuldnerName   varchar(200),
--  InkassoGesperrt bit,
--  FaProzessCode   int,
--  Geburtsdatum datetime', 3, N'DELETE TRE
--FROM #Tree                TRE
--  INNER JOIN FaLeistung   FLE ON FLE.FaLeistungID = TRE.FaLeistungID
--WHERE TRE.ModulTreeID IN (1, @ModulTreeID) AND FLE.FaProzessCode <> 400

--UPDATE #Tree SET FaProzessCode = 400', 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (41000, NULL, 4, 6, 1401, N'Alimente', N'CtlIkLeistung', NULL, NULL, 3, N'DELETE TRE
--FROM #Tree                TRE
--  INNER JOIN FaLeistung   FLE ON FLE.FaLeistungID = TRE.FaLeistungID
--WHERE TRE.ModulTreeID IN (1, @ModulTreeID) AND FLE.FaProzessCode = 400

--UPDATE TRE
--  SET ModulTreeID = CASE FLE.FaProzessCode
--        WHEN 400   THEN 40004 -- Abklärung
--        WHEN 401   THEN 41000 -- Alimente
--        WHEN 402   THEN 40000 -- Elternbeitrag
--        WHEN 403   THEN 40005 -- Rückerstattung
--        WHEN 404   THEN 40006 -- Verwandtenbeitrag
--        WHEN 405   THEN 40008 -- Tagesheim/Krippe
--        WHEN 406   THEN 40009 -- Nachlass
--        WHEN 407   THEN 40044 -- Rückerstattung POM
--        ELSE 41000            -- Alimente
--    END,
--    FaProzessCode = FLE.FaProzessCode
--FROM #Tree                TRE
--  INNER JOIN FaLeistung   FLE ON FLE.FaLeistungID = TRE.FaLeistungID
--WHERE TRE.ModulTreeID = @ModulTreeID

--UPDATE TRE
--  SET Name = isNull(FLE.Bezeichnung + '' '', '''') + COALESCE(TRE.Name COLLATE DATABASE_DEFAULT, LAN.Text, MTR.Name)
--FROM #Tree                TRE
--  INNER JOIN FaLeistung   FLE ON FLE.FaLeistungID = TRE.FaLeistungID
--  INNER JOIN XModulTree   MTR ON MTR.ModulTreeID = TRE.ModulTreeID
--  LEFT  JOIN XLangText    LAN ON LAN.TID = MTR.NameTID AND LAN.LanguageCode = @LanguageCode', 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40000, NULL, 4, 7, 1401, N'Elternbeitrag', N'CtlIkLeistung', NULL, NULL, 999, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40005, NULL, 4, 8, 1401, N'Rückerstattung', N'CtlIkLeistung', NULL, NULL, 999, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40006, NULL, 4, 9, 1411, N'Verwandtenbeitrag', N'CtlIkLeistung', NULL, NULL, 999, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40008, NULL, 4, 10, 1401, N'Tagesheim/Krippe', N'CtlIkLeistung', NULL, NULL, 999, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40009, NULL, 4, 11, 1401, N'Nachlass', N'CtlIkLeistung', NULL, NULL, 999, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40044, NULL, 4, 12, 1401, N'Rückerstattung POM', N'CtlIkLeistung', NULL, NULL, 999, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40036, NULL, 4, 13, 2117, N'Kontoauszug', N'CtlIkKontoauszug', NULL, NULL, 999, N'IF (EXISTS (SELECT TOP 1 1 
--            FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
--            WHERE LEI.BaPersonID = @BaPersonID 
--              AND LEI.ModulID = 4
--              AND LEI.FaProzessCode IS NOT NULL))
--BEGIN
--  INSERT INTO #Tree (ModulTreeID, ID, BaPersonID)
--  VALUES (@ModulTreeID, IsNull(@ClassName, CONVERT(VARCHAR, @ModulTreeID)), @BaPersonID);
--END;', 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40001, 40000, 4, 1, 1431, N'Rechtliche Massnahmen', N'CtlIkRechtlicheMassnahmenInkassofall', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40003, 40000, 4, 2, 137, N'Gläubiger', N'CtlIkGlaeubiger', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40011, 40000, 4, 4, 1419, N'Inkasso Forderungen', N'CtlIkForderungen', NULL, NULL, 999, N'IF @ModulTreeID_Parent IS NULL
--  INSERT INTO #Tree (ModulTreeID, ID, ParentID, BaPersonID)
--    SELECT @ModulTreeID, IsNull(@ClassName, CONVERT(varchar, @ModulTreeID)), NULL, @BaPersonID
--ELSE
--  INSERT INTO #Tree (ModulTreeID, ID, ParentID, @FieldList)
--    SELECT @ModulTreeID, IsNull(TRE.ID + ''/'', '''') + IsNull(@ClassName, CONVERT(varchar, @ModulTreeID)), TRE.ID, @FieldList
--    FROM #Tree  TRE
--    WHERE ModulTreeID = @ModulTreeID_Parent

--UPDATE TRE
--  SET FaProzessCode = FLE.FaProzessCode
--FROM #Tree                TRE
--  INNER JOIN FaLeistung   FLE ON FLE.FaLeistungID = TRE.FaLeistungID
--WHERE TRE.ModulTreeID = @ModulTreeID', 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40007, 40000, 4, 5, 164, N'Ratenplan', N'CtlIkMonatszahlenVerrechnung', NULL, N'-- Alter table #Tree add RechtstitelID int', 1, N'/*
--Update #Tree set RechtstitelID = (
--  select IkRechtsTitelID from IkRechtstitel
--  where FaLeistungID = #Tree.FaLeistungID )
--WHERE ModulTreeID = @ModulTreeID
--*/', 0)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40025, 40000, 4, 6, 73, N'Gläubiger', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, Name, Datum, BaPersonID, FaLeistungID, FaProzessCode)
--SELECT ModulTreeID = @ModulTreeID, 
--       ID          = TRE.ID + ''\Glaeubiger'' + convert(varchar,GLA.IkGlaeubigerID), 
--       ParentID    = TRE.ID,
--       IconID      = CASE WHEN GLA.Aktiv = 0 THEN @IconID ELSE 72 END,
--       Name        = ''G: '' + PRS.NameVorname + '' ('' + convert(varchar, PRS.Geburtsdatum, 104) + '')'', 
--       Datum       = null,
--       BaPersonID  = PRS.BaPersonID,
--       LEI.FaLeistungID,
--       LEI.FaProzessCode
--FROM #Tree                 TRE
--  INNER JOIN FaLeistung    LEI ON LEI.FaLeistungID = TRE.FaLeistungID
--  INNER JOIN IkGlaeubiger  GLA ON GLA.FaLeistungID = LEI.FaLeistungID 
--  INNER JOIN vwPerson      PRS ON PRS.BaPersonID = GLA.BaPersonID
--WHERE  TRE.ModulTreeID = @ModulTreeID_Parent 
--ORDER BY PRS.Geburtsdatum DESC', 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40037, 40000, 4, 7, 133, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, Name, Datum, FaProzessCode)
--SELECT @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID,@IconID,
--       LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
--       Name = ''S: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''), null, LEI.FaProzessCode 
--FROM   #Tree TRE
--       INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = TRE.FaLeistungID
--       INNER JOIN BaPerson   PRS ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
--WHERE  TRE.ModulTreeID = @ModulTreeID_Parent', 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40014, 40000, 4, 8, 1424, N'Betreibungen, Verlustscheine', N'CtlIkBetreibungenVerlustscheine', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40043, 40004, 4, 1, 83, N'Abklärungen', N'CtlIkAbklaerungen', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40015, 40005, 4, 1, 1431, N'Rechtliche Massnahmen', N'CtlIkRechtlicheMassnahmenInkassofall', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40052, 40005, 4, 2, 137, N'Gläubiger', N'CtlIkGlaeubiger', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40016, 40005, 4, 4, 1419, N'Inkasso Forderungen', N'CtlIkForderungen', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40017, 40005, 4, 5, 164, N'Ratenplan', N'CtlIkMonatszahlenVerrechnung', NULL, NULL, 1, NULL, 0)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40051, 40005, 4, 6, 133, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, Name, Datum, FaProzessCode)
--SELECT @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID,@IconID,
--       LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
--       Name = ''S: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''), null, LEI.FaProzessCode 
--FROM   #Tree TRE
--       INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = TRE.FaLeistungID
--       INNER JOIN BaPerson   PRS ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
--WHERE  TRE.ModulTreeID = @ModulTreeID_Parent', 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40019, 40005, 4, 7, 1424, N'Betreibungen, Verlustscheine', N'CtlIkBetreibungenVerlustscheine', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40021, 40006, 4, 1, 1431, N'Rechtliche Massnahmen', N'CtlIkRechtlicheMassnahmenInkassofall', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40010, 40006, 4, 2, 137, N'Gläubiger', N'CtlIkGlaeubiger', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40022, 40006, 4, 4, 1419, N'Inkasso Forderungen', N'CtlIkForderungen', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40023, 40006, 4, 5, 164, N'Ratenplan', N'CtlIkMonatszahlenVerrechnung', NULL, NULL, 1, NULL, 0)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40030, 40006, 4, 6, 73, N'Gläubiger', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, Name, Datum, BaPersonID, FaLeistungID, FaProzessCode)
--SELECT ModulTreeID = @ModulTreeID, 
--       ID          = TRE.ID + ''\Glaeubiger'' + convert(varchar,GLA.IkGlaeubigerID), 
--       ParentID    = TRE.ID,
--       IconID      = CASE WHEN GLA.Aktiv = 0 THEN @IconID ELSE 72 END,
--       Name        = ''G: '' + PRS.NameVorname + '' ('' + convert(varchar, PRS.Geburtsdatum, 104) + '')'', 
--       Datum       = null,
--       BaPersonID  = PRS.BaPersonID,
--       LEI.FaLeistungID,
--       LEI.FaProzessCode
--FROM #Tree                 TRE
--  INNER JOIN FaLeistung    LEI ON LEI.FaLeistungID = TRE.FaLeistungID
--  INNER JOIN IkGlaeubiger  GLA ON GLA.FaLeistungID = LEI.FaLeistungID 
--  INNER JOIN vwPerson      PRS ON PRS.BaPersonID = GLA.BaPersonID
--WHERE  TRE.ModulTreeID = @ModulTreeID_Parent 
--ORDER BY PRS.Geburtsdatum DESC', 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40039, 40006, 4, 7, 133, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, Name, Datum, FaProzessCode)
--SELECT @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID,@IconID,
--       LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
--       Name = ''S: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''), null, LEI.FaProzessCode 
--FROM   #Tree TRE
--       INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = TRE.FaLeistungID
--       INNER JOIN BaPerson   PRS ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
--WHERE  TRE.ModulTreeID = @ModulTreeID_Parent', 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40024, 40006, 4, 8, 1424, N'Betreibungen, Verlustscheine', N'CtlIkBetreibungenVerlustscheine', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40026, 40008, 4, 1, 1431, N'Rechtliche Massnahmen', N'CtlIkRechtlicheMassnahmenInkassofall', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40013, 40008, 4, 2, 137, N'Gläubiger', N'CtlIkGlaeubiger', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40027, 40008, 4, 4, 1419, N'Inkasso Forderungen', N'CtlIkForderungen', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40028, 40008, 4, 5, 164, N'Ratenplan', N'CtlIkMonatszahlenVerrechnung', NULL, NULL, 1, NULL, 0)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40038, 40008, 4, 6, 73, N'Gläubiger', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, Name, Datum, BaPersonID, FaLeistungID, FaProzessCode)
--SELECT ModulTreeID = @ModulTreeID, 
--       ID          = TRE.ID + ''\Glaeubiger'' + convert(varchar,GLA.IkGlaeubigerID), 
--       ParentID    = TRE.ID,
--       IconID      = CASE WHEN GLA.Aktiv = 0 THEN @IconID ELSE 72 END,
--       Name        = ''G: '' + PRS.NameVorname + '' ('' + convert(varchar, PRS.Geburtsdatum, 104) + '')'', 
--       Datum       = null,
--       BaPersonID  = PRS.BaPersonID,
--       LEI.FaLeistungID,
--       LEI.FaProzessCode
--FROM #Tree                 TRE
--  INNER JOIN FaLeistung    LEI ON LEI.FaLeistungID = TRE.FaLeistungID
--  INNER JOIN IkGlaeubiger  GLA ON GLA.FaLeistungID = LEI.FaLeistungID 
--  INNER JOIN vwPerson      PRS ON PRS.BaPersonID = GLA.BaPersonID
--WHERE  TRE.ModulTreeID = @ModulTreeID_Parent 
--ORDER BY PRS.Geburtsdatum DESC', 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40040, 40008, 4, 7, 133, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, Name, Datum, FaProzessCode)
--SELECT @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID,@IconID,
--       LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
--       Name = ''S: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''), null, LEI.FaProzessCode 
--FROM   #Tree TRE
--       INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = TRE.FaLeistungID
--       INNER JOIN BaPerson   PRS ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
--WHERE  TRE.ModulTreeID = @ModulTreeID_Parent', 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40029, 40008, 4, 8, 1424, N'Betreibungen, Verlustscheine', N'CtlIkBetreibungenVerlustscheine', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40031, 40009, 4, 1, 1431, N'Rechtliche Massnahmen', N'CtlIkRechtlicheMassnahmenInkassofall', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40020, 40009, 4, 2, 137, N'Gläubiger', N'CtlIkGlaeubiger', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40032, 40009, 4, 4, 1419, N'Inkasso Forderungen', N'CtlIkForderungen', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40033, 40009, 4, 5, 164, N'Ratenplan', N'CtlIkMonatszahlenVerrechnung', NULL, NULL, 1, NULL, 0)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40050, 40009, 4, 6, 73, N'Gläubiger', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, Name, Datum, BaPersonID, FaLeistungID, FaProzessCode)
--SELECT ModulTreeID = @ModulTreeID, 
--       ID          = TRE.ID + ''\Glaeubiger'' + convert(varchar,GLA.IkGlaeubigerID), 
--       ParentID    = TRE.ID,
--       IconID      = CASE WHEN GLA.Aktiv = 0 THEN @IconID ELSE 72 END,
--       Name        = ''G: '' + PRS.NameVorname + '' ('' + convert(varchar, PRS.Geburtsdatum, 104) + '')'', 
--       Datum       = null,
--       BaPersonID  = PRS.BaPersonID,
--       LEI.FaLeistungID,
--       LEI.FaProzessCode
--FROM #Tree                 TRE
--  INNER JOIN FaLeistung    LEI ON LEI.FaLeistungID = TRE.FaLeistungID
--  INNER JOIN IkGlaeubiger  GLA ON GLA.FaLeistungID = LEI.FaLeistungID 
--  INNER JOIN vwPerson      PRS ON PRS.BaPersonID = GLA.BaPersonID
--WHERE  TRE.ModulTreeID = @ModulTreeID_Parent 
--ORDER BY PRS.Geburtsdatum DESC', 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40041, 40009, 4, 7, 133, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, Name, Datum, FaProzessCode)
--SELECT @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID,@IconID,
--       LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
--       Name = ''S: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''), null, LEI.FaProzessCode
--FROM   #Tree TRE
--       INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = TRE.FaLeistungID
--       INNER JOIN BaPerson   PRS ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
--WHERE  TRE.ModulTreeID = @ModulTreeID_Parent', 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40034, 40009, 4, 8, 1424, N'Betreibungen, Verlustscheine', N'CtlIkBetreibungenVerlustscheine', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40045, 40044, 4, 1, 1431, N'Rechtliche Massnahmen', N'CtlIkRechtlicheMassnahmenInkassofall', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40053, 40044, 4, 2, 137, N'Gläubiger', N'CtlIkGlaeubiger', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40046, 40044, 4, 4, 1419, N'Inkasso Forderungen', N'CtlIkForderungen', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40047, 40044, 4, 5, 164, N'Ratenplan', N'CtlIkMonatszahlenVerrechnung', NULL, NULL, 1, NULL, 0)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40048, 40044, 4, 6, 133, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, Name, Datum, FaProzessCode)
--SELECT @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID,@IconID,
--       LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
--       Name = ''S: '' + PRS.Name+IsNull('' '' + PRS.Vorname,''''), null, LEI.FaProzessCode 
--FROM   #Tree TRE
--       INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = TRE.FaLeistungID
--       INNER JOIN BaPerson   PRS ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
--WHERE  TRE.ModulTreeID = @ModulTreeID_Parent', 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40049, 40044, 4, 7, 1424, N'Betreibungen, Verlustscheine', N'CtlIkBetreibungenVerlustscheine', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40012, 41000, 4, 4, 1431, N'Rechtliche Massnahmen', N'CtlIkRechtlicheMassnahmenInkassofall', NULL, NULL, 1, NULL, 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (41002, 41000, 4, 5, 1421, N'Rechtstitel und Gläubiger', N'CtlIkRechtstitel', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, FaFallID, FaLeistungID, Datum, RechtstitelID)
--SELECT @ModulTreeID, TRE.ID + ''\Rechtstitel'' + convert(varchar,RTI.IkRechtstitelID ), 
--       TRE.ID, LEI.FaFallID, LEI.FaLeistungID, RTI.IkRechtstitelGueltigVon,
--       RTI.IkRechtstitelID
--FROM   #Tree TRE
--  INNER JOIN FaLeistung    LEI ON LEI.FaLeistungID = TRE.FaLeistungID
--  INNER JOIN IkRechtstitel RTI ON RTI.FaLeistungID = LEI.FaLeistungID
--WHERE  TRE.ModulTreeID = @ModulTreeID_Parent 
--ORDER BY RTI.IkRechtstitelGueltigVon desc', 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (41010, 41000, 4, 6, 73, N'Gläubiger', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, Name, Datum, BaPersonID, FaLeistungID, FaProzessCode, Geburtsdatum)
--SELECT DISTINCT 
--       ModulTreeID = @ModulTreeID, 
--       ID          = TRE.ID + ''\Glaeubiger'' + convert(varchar, GLA.IkGlaeubigerID), 
--       ParentID    = TRE.ID,
--       IconID      = CASE WHEN GLA.Aktiv = 0 THEN @IconID ELSE 72 END,
--       Name        = ''G: '' + PRS.NameVorname + '' ('' + convert(varchar, PRS.Geburtsdatum, 104) + '')'' + ISNULL('' - '' + dbo.fnIkGetBaPersonForderungTyp(GLA.IkGlaeubigerID), ''''), 
--       Datum       = null,
--       BaPersonID  = PRS.BaPersonID,
--       LEI.FaLeistungID,
--       LEI.FaProzessCode,
--       PRS.Geburtsdatum
--FROM #Tree                 TRE
--  INNER JOIN FaLeistung    LEI ON LEI.FaLeistungID = TRE.FaLeistungID
--  INNER JOIN IkRechtstitel RTI ON RTI.FaLeistungID = LEI.FaLeistungID
--  INNER JOIN IkGlaeubiger  GLA ON GLA.IkRechtstitelID = RTI.IkRechtstitelID 
--  INNER JOIN vwPerson      PRS ON PRS.BaPersonID = GLA.BaPersonID
--WHERE  TRE.ModulTreeID = @ModulTreeID_Parent 
--ORDER BY PRS.Geburtsdatum DESC', 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40035, 41000, 4, 7, 133, N'Schuldner', N'CtlIkKontoauszug', NULL, NULL, 999, N'INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, Name, FaProzessCode)
--SELECT @ModulTreeID, TRE.ID + ''\Schuldner'', TRE.ID,@IconID,
--       LEI.SchuldnerBaPersonID, LEI.FaFallID, LEI.FaLeistungID,
--       Name = ''S: '' + PRS.NameVorname, LEI.FaProzessCode
--FROM   #Tree TRE
--  INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = TRE.FaLeistungID
--  INNER JOIN vwPerson   PRS ON PRS.BaPersonID = LEI.SchuldnerBaPersonID
--WHERE  TRE.ModulTreeID = @ModulTreeID_Parent
--  AND EXISTS(SELECT * FROM IkRechtstitel WHERE FaLeistungID = LEI.FaLeistungID)', 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40042, 41000, 4, 8, 1424, N'Betreibungen, Verlustscheine', N'CtlIkBetreibungenVerlustscheine', NULL, NULL, 1, N'/*
--INSERT INTO #Tree (ModulTreeID, ID, ParentID, IconID, BaPersonID, FaFallID, FaLeistungID, RechtstitelID)
--SELECT @ModulTreeID, 
--       TRE.ID + ''\BetreibungenVerlustscheine'', 
--       TRE.ID,@IconID,
--       LEI.SchuldnerBaPersonID, 
--       LEI.FaFallID, 
--       LEI.FaLeistungID, 
--       RTT.IkRechtstitelID
--FROM   #Tree TRE
--  INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = TRE.FaLeistungID
--  INNER JOIN IkRechtstitel RTT ON RTT.FaLeistungID = LEI.FaLeistungID
--WHERE  TRE.ModulTreeID = @ModulTreeID_Parent
----  AND EXISTS(SELECT * FROM IkRechtstitel WHERE FaLeistungID = LEI.FaLeistungID)
--*/', 1)
--INSERT INTO [XModulTree] ([ModulTreeID], [ModulTreeID_Parent], [ModulID], [SortKey], [XIconID], [Name], [ClassName], [MaskName], [sqlPreExecute], [ModulTreeCode], [sqlInsertTreeItem], [Active]) VALUES (40018, 41002, 4, 1, 1417, N'Monatszahlen', N'CtlIkMonatszahlen', NULL, NULL, 1, N'UPDATE #Tree SET SchuldnerName = NULL
--WHERE ModulTreeID = @ModulTreeID', 1)
--GO
--COMMIT
GO


-------------------------------------------------------------------------------
-- Step: XLOV und XLOVCode (Inkasso-Wertelisten erstellen)
-------------------------------------------------------------------------------
PRINT ('Info: XLOV und XLOVCode (Inkasso-Wertelisten erstellen)');
SET NOCOUNT ON
BEGIN TRANSACTION
GO
UPDATE dbo.XLOV
  SET ModulID = 4
WHERE LOVName = 'IkInkassoBemuehung';
GO
--DELETE FROM [XLOVCode] WHERE LOVName IN (SELECT LOVName
--                  FROM dbo.xlov WITH (READUNCOMMITTED)
--                  WHERE ModulID = 4)
--  OR LOVName = 'FaProzess' AND Code BETWEEN 400 AND 499
--  OR LOVName = 'AbschlussGrund' AND Code BETWEEN 40001 AND 40004
--GO
--DELETE FROM [XLOV] WHERE ModulID = 4
--GO
--SET IDENTITY_INSERT XLOV ON
--GO
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (125, 'IkAbklaerungArt', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (126, 'IkAbklaerungAuswertung', NULL, 1, 0, 4, NULL, 1, 'Codes aus IkAbklaerungArt, welche diese Auswertung zulassen.', NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (128, 'IkAnpassungsGrund', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (129, 'IkAnpassungsRegel', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (130, 'IkAnzeigeAbschlussGrund', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (131, 'IkAnzeigeEroeffnungGrund', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (132, 'IkAnzeigeTyp', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (133, 'IkAufenthaltsart', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (134, 'IkBetreibungStatus', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (135, 'IkBetreibungVerlustschein', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (136, 'IkBezugKinderzulagen', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (137, 'IkEinnahmenQuote', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (138, 'IkElterlicheSorge', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (139, 'IkErreichungsGrad', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (140, 'IkForderungEinmalig', NULL, 1, 0, 4, NULL, 1, NULL, NULL, 'FaProzessCodes')
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (141, 'IkForderungPeriodisch', NULL, 1, 0, 4, NULL, 1, 'VerlangtIndexierung', NULL, 'FaProzessCodes')
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (142, 'IkForderungTitel', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (143, 'IkIndexRunden', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (144, 'IkIndexTyp', 'Werteliste für die Inkasso-Landesindexe und das Mapping auf die Landesindex-Tabelle', 0, 1, 4, CONVERT(datetime, '2011-10-19 12:09:01', 120), 1, 'Mapping auf IkLandesindexID', NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (145, 'IkInkassoBemuehung', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (146, 'IkKbForderungArt', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (147, 'IkLeistungStatus', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (148, 'IkRatenplanVereinbarung', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (149, 'IkRechtstitelTyp', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (150, 'IkRueckerstattungTyp', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (151, 'IkSchuldnerStatus', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (152, 'IkVerlustscheinStatus', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (153, 'IkVerlustscheinTyp', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--INSERT INTO XLOV (XLOVID, LOVName, Description, System, Expandable, ModulID, LastUpdated, Translatable, NameValue1, NameValue2, NameValue3) VALUES (154, 'IkVerrechnungsart', NULL, 1, 0, 4, NULL, 1, NULL, NULL, NULL)
--SET IDENTITY_INSERT XLOV OFF
--GO


--SET IDENTITY_INSERT XLOVCode ON
--GO
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (5, 1, 'AbschlussGrund', 40001, 'Bezahlt', 40001, 'Bez', NULL, NULL, NULL, 'I', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (6, 1, 'AbschlussGrund', 40002, 'Gestorben', 40002, 'Gest.', NULL, NULL, NULL, 'I', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (7, 1, 'AbschlussGrund', 40003, 'Nur noch Verlustscheinkontrolle', 40003, 'VsKont.', NULL, NULL, NULL, 'I', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (8, 1, 'AbschlussGrund', 40004, 'Abgeschrieben', 40004, 'Abgeschr.', NULL, NULL, NULL, 'I', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (583, 87, 'FaProzess', 400, 'Abklärung', 400, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (584, 87, 'FaProzess', 401, 'Alimente', 401, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (585, 87, 'FaProzess', 402, 'Elternbeitrag', 402, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (586, 87, 'FaProzess', 403, 'Rückerstattung', 403, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (587, 87, 'FaProzess', 404, 'Verwandtenbeitrag', 404, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (588, 87, 'FaProzess', 405, 'Tagesheim/Krippe', 405, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (589, 87, 'FaProzess', 406, 'Nachlass', 406, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (590, 87, 'FaProzess', 407, 'Rückerstattung POM', 407, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3721, 125, 'IkAbklaerungArt', 1, 'Gesuch Alimentenbevorschussung', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3722, 125, 'IkAbklaerungArt', 2, 'Alimenteninkasso Unterstützungsfall', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3723, 125, 'IkAbklaerungArt', 3, 'Alimenteninkasso Vermittlung', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3724, 125, 'IkAbklaerungArt', 4, 'Elternbeiträge', 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3725, 125, 'IkAbklaerungArt', 5, 'Verwandtenbeiträge', 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3726, 125, 'IkAbklaerungArt', 6, 'Nachlass', 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3727, 125, 'IkAbklaerungArt', 7, 'Rückerstattung', 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3728, 125, 'IkAbklaerungArt', 8, 'finanzielle Situation allgemein', 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3729, 125, 'IkAbklaerungArt', 9, 'Konkurseingaben', 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3730, 125, 'IkAbklaerungArt', 10, 'andere Inkassoabklärungen', 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3731, 125, 'IkAbklaerungArt', 11, 'Systematische Rückerstattung', 11, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3732, 126, 'IkAbklaerungAuswertung', 1, 'Alimentenbevorschussung bewilligt', 1, NULL, NULL, NULL, NULL, '1,8,9,10,11', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3733, 126, 'IkAbklaerungAuswertung', 2, 'Alimentenbevorschussung nicht bewilligt', 2, NULL, NULL, NULL, NULL, '1,8,9,10,11', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3734, 126, 'IkAbklaerungAuswertung', 3, 'Alimenteninkasso Unterstützungsfall übernommen', 3, NULL, NULL, NULL, NULL, '2,8,9,10,11', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3735, 126, 'IkAbklaerungAuswertung', 4, 'Alimenteninkasso Unterstützungsfall nicht übernommen', 4, NULL, NULL, NULL, NULL, '2,8,9,10,11', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3736, 126, 'IkAbklaerungAuswertung', 5, 'Alimenteninkasso Vermittlung übernommen', 5, NULL, NULL, NULL, NULL, '3,8,9,10,11', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3737, 126, 'IkAbklaerungAuswertung', 6, 'Alimenteninkasso Vermittlung nicht übernommen', 6, NULL, NULL, NULL, NULL, '3,8,9,10,11', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3738, 126, 'IkAbklaerungAuswertung', 7, 'KlientIn zu Elternbeiträgen verpflichtet', 7, NULL, NULL, NULL, NULL, '4,8,9,10,11', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3739, 126, 'IkAbklaerungAuswertung', 8, 'KlientIn nicht zu Elternbeiträgen verpflichtet', 8, NULL, NULL, NULL, NULL, '4,8,9,10,11', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3740, 126, 'IkAbklaerungAuswertung', 9, 'KlientIn zu Verwandtenbeiträgen verpflichtet', 9, NULL, NULL, NULL, NULL, '5,8,9,10,11', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3741, 126, 'IkAbklaerungAuswertung', 10, 'KlientIn nicht zu Verwandtenbeiträgen verpflichtet', 10, NULL, NULL, NULL, NULL, '5,8,9,10,11', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3742, 126, 'IkAbklaerungAuswertung', 11, 'Nachlass vorhanden', 11, NULL, NULL, NULL, NULL, '6,8,9,10,11', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3743, 126, 'IkAbklaerungAuswertung', 12, 'kein Nachlass vorhanden', 12, NULL, NULL, NULL, NULL, '6,8,9,10,11', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3744, 126, 'IkAbklaerungAuswertung', 13, 'KlientIn zu Rückerstattungen verpflichtet', 13, NULL, NULL, NULL, NULL, '7,8,9,10,11', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3745, 126, 'IkAbklaerungAuswertung', 14, 'KlientIn nicht zu Rückerstattungen verpflichtet', 14, NULL, NULL, NULL, NULL, '7,8,9,10,11', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3749, 128, 'IkAnpassungsGrund', 1, 'Beginn / Fallübernahme', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3750, 128, 'IkAnpassungsGrund', 2, 'Index Anpassung', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3751, 128, 'IkAnpassungsGrund', 3, 'Revision', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3752, 128, 'IkAnpassungsGrund', 4, 'Altersstufe', 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3753, 128, 'IkAnpassungsGrund', 5, 'Reduktion Betrag', 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3754, 128, 'IkAnpassungsGrund', 6, 'Einstellung / Fallabschluss', 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3755, 128, 'IkAnpassungsGrund', 7, 'Anderer Grund', 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3756, 128, 'IkAnpassungsGrund', 8, 'gemäss Migration', 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3757, 129, 'IkAnpassungsRegel', 1, 'Novemberindex, Basisbetrag Anpassung auf 1. Januar', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3758, 129, 'IkAnpassungsRegel', 2, 'Novemberindex, letzter Forderungsbetrag Anpassung auf 1. Januar', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3759, 129, 'IkAnpassungsRegel', 4, 'Dezemberindex, Basisbetrag Anpassung auf 1. Februar', 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3760, 129, 'IkAnpassungsRegel', 5, 'Dezemberindex, letzter Forderungsbetrag Anpassung auf 1. Februar', 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3761, 129, 'IkAnpassungsRegel', 6, 'Manuelle Indexierung', 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3762, 129, 'IkAnpassungsRegel', 7, 'Keine Indexierung', 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3763, 130, 'IkAnzeigeAbschlussGrund', 1, 'Verurteilung', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3764, 130, 'IkAnzeigeAbschlussGrund', 2, 'Freispruch', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3765, 130, 'IkAnzeigeAbschlussGrund', 3, 'Rückzug', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3766, 130, 'IkAnzeigeAbschlussGrund', 4, 'Verjährung', 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3767, 130, 'IkAnzeigeAbschlussGrund', 5, 'Angeklagter ist verstorben', 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3768, 131, 'IkAnzeigeEroeffnungGrund', 1, '???', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3769, 132, 'IkAnzeigeTyp', 1, 'Strafanzeige nach StGB Artikel 217', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3770, 132, 'IkAnzeigeTyp', 2, 'Strafanzeige nach ZGB (Schuldneranweisung)', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3771, 132, 'IkAnzeigeTyp', 3, 'Lohnabtretung', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3772, 132, 'IkAnzeigeTyp', 4, 'Andere', 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3773, 133, 'IkAufenthaltsart', 1, 'Aufenthaltsort bekannt (in der Schweiz)', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3774, 133, 'IkAufenthaltsart', 2, 'Aufenthaltsort bekannt (im Ausland)', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3775, 133, 'IkAufenthaltsart', 3, 'unbekannter Aufenthalt', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3776, 134, 'IkBetreibungStatus', 1, '(Keine Betreibung)', 1, NULL, NULL, '0', '0', NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3777, 134, 'IkBetreibungStatus', 2, 'Betreibungsverfahren laufend', 2, NULL, NULL, '1', '0', NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3778, 134, 'IkBetreibungStatus', 3, 'Abgeschlossen und bezahlt', 3, NULL, NULL, '1', '1', NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3779, 134, 'IkBetreibungStatus', 4, 'Abgeschlossen mit Verlustschein', 4, NULL, NULL, '1', '1', NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3780, 134, 'IkBetreibungStatus', 5, 'Betreibung als Verjährungsunterbruch', 5, NULL, NULL, '1', '0', NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3781, 135, 'IkBetreibungVerlustschein', 1, 'Alle Betreibungen u. Verlustscheine', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3782, 135, 'IkBetreibungVerlustschein', 2, 'Nur aktive Betreibungen', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3783, 135, 'IkBetreibungVerlustschein', 3, 'Nur aktive Verlustscheine', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3784, 135, 'IkBetreibungVerlustschein', 4, 'Alle aktiven Betreibungen u. Verlustscheine', 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3785, 136, 'IkBezugKinderzulagen', 1, 'durch Gläubiger', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3786, 136, 'IkBezugKinderzulagen', 2, 'durch Zahlungspflichtigen', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3787, 136, 'IkBezugKinderzulagen', 3, 'kein Bezug möglich', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3788, 137, 'IkEinnahmenQuote', 1, 'über 50%', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3789, 137, 'IkEinnahmenQuote', 2, 'unter 50%', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3790, 138, 'IkElterlicheSorge', 1, 'nur Mutter', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3791, 138, 'IkElterlicheSorge', 2, 'nur Vater', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3792, 138, 'IkElterlicheSorge', 3, 'Mutter und Vater', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3793, 138, 'IkElterlicheSorge', 4, 'Vormund', 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3794, 138, 'IkElterlicheSorge', 5, 'Beistand', 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3795, 138, 'IkElterlicheSorge', 6, 'Andere Person', 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3796, 139, 'IkErreichungsGrad', 1, 'unbekannten Aufenthaltes im In- oder Ausland', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3797, 139, 'IkErreichungsGrad', 2, 'im Ausland mit bekanntem Aufenthalt', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3798, 139, 'IkErreichungsGrad', 3, 'unterstützt von einem Sozialdienst', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3799, 139, 'IkErreichungsGrad', 4, 'Rentenbezüger', 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3800, 139, 'IkErreichungsGrad', 5, 'zu tiefes Einkommen', 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3801, 139, 'IkErreichungsGrad', 6, 'eingeleitete rechtliche Massnahmen noch nicht erfolgreich', 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3802, 139, 'IkErreichungsGrad', 7, 'eingeleitete rechtliche Massnahmen nicht erfolgreich', 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3803, 140, 'IkForderungEinmalig', 1, 'Kinderalimente (Unterstützungsfall)', 1, NULL, NULL, NULL, NULL, '401', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3804, 140, 'IkForderungEinmalig', 2, 'Kinderalimente (Bevorschussung)', 2, NULL, NULL, NULL, NULL, '401', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3805, 140, 'IkForderungEinmalig', 3, 'Kinderalimente (über max. Bevorschussung)', 3, NULL, NULL, NULL, NULL, '401', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3806, 140, 'IkForderungEinmalig', 4, 'Kinderalimente (Vermittlungsfall)', 4, NULL, NULL, NULL, NULL, '401', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3807, 140, 'IkForderungEinmalig', 5, 'Erwachsenenalimente (Unterstützungsfall)', 5, NULL, NULL, NULL, NULL, '401', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3808, 140, 'IkForderungEinmalig', 6, 'Erwachsenenalimente', 6, NULL, NULL, NULL, NULL, '401', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3809, 140, 'IkForderungEinmalig', 7, 'Kinderzulagen (Unterstützungsfall)', 7, NULL, NULL, NULL, NULL, '401', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3810, 140, 'IkForderungEinmalig', 8, 'Kinderzulagen (Vermittlungsfall)', 8, NULL, NULL, NULL, NULL, '401', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3811, 140, 'IkForderungEinmalig', 9, 'Kinderzulagen (Vermittlung bei Bevorschussungsfall)', 9, NULL, NULL, NULL, NULL, '401', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3812, 140, 'IkForderungEinmalig', 10, 'Zins', 10, NULL, NULL, NULL, NULL, '404,402,403,407', NULL, NULL, 0, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3813, 140, 'IkForderungEinmalig', 11, 'Inkassokosten (Bevorschussung)', 11, NULL, NULL, NULL, NULL, '401', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3814, 140, 'IkForderungEinmalig', 12, 'Inkassokosten (Vermittlung bei Bevorschussung)', 13, NULL, NULL, NULL, NULL, '401', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3815, 140, 'IkForderungEinmalig', 13, 'Inkassokosten (Vermittlungsfall)', 12, NULL, NULL, NULL, NULL, '401', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3816, 140, 'IkForderungEinmalig', 14, 'Inkassokosten (Unterstützungsfall)', 10, NULL, NULL, NULL, NULL, '401', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3817, 140, 'IkForderungEinmalig', 15, 'Zins (Bevorschussung)', 20, NULL, NULL, NULL, NULL, '401', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3818, 140, 'IkForderungEinmalig', 16, 'Zins (Unterstützung)', 19, NULL, NULL, NULL, NULL, '401', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3819, 140, 'IkForderungEinmalig', 30, 'Nachlass', 27, NULL, NULL, NULL, NULL, '406', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3820, 140, 'IkForderungEinmalig', 31, 'Inkassokosten', 31, NULL, NULL, NULL, NULL, '406,404,402,403,407', NULL, NULL, 0, 1)
--INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (244, 'IkForderungEinmalig', 32, 'Inkassokosten (Nachlass)', 14, NULL, NULL, NULL, NULL, '406', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (244, 'IkForderungEinmalig', 33, 'Zins (Nachlass)', 22, NULL, NULL, NULL, NULL, '406', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (244, 'IkForderungEinmalig', 34, 'Zins (Vermittlungsfall)', 21, NULL, NULL, NULL, NULL, '401', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3821, 140, 'IkForderungEinmalig', 40, 'Verwandtenbeitrag', 28, NULL, NULL, NULL, NULL, '404', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (244, 'IkForderungEinmalig', 41, 'Inkassokosten (Verwandtenbeiträge)', 15, NULL, NULL, NULL, NULL, '404', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (244, 'IkForderungEinmalig', 42, 'Zins (Verwandtenbeiträge)', 23, NULL, NULL, NULL, NULL, '404', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3822, 140, 'IkForderungEinmalig', 50, 'Elternbeitrag', 29, NULL, NULL, NULL, NULL, '402', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (244, 'IkForderungEinmalig', 51, 'Inkassokosten (Elternbeiträge)', 16, NULL, NULL, NULL, NULL, '402', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (244, 'IkForderungEinmalig', 52, 'Zins (Elternbeiträge)', 24, NULL, NULL, NULL, NULL, '402', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3823, 140, 'IkForderungEinmalig', 60, 'Rückerstattung', 30, NULL, NULL, NULL, NULL, '403,407', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3824, 140, 'IkForderungEinmalig', 61, 'Rückerstattung POM', 31, NULL, NULL, NULL, NULL, '407', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (244, 'IkForderungEinmalig', 62, 'Inkassokosten (Rückerstattungen)', 17, NULL, NULL, NULL, NULL, '403,407', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (244, 'IkForderungEinmalig', 63, 'Zins (Rückerstattungen)', 25, NULL, NULL, NULL, NULL, '403,407', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (244, 'IkForderungEinmalig', 64, 'Inkassokosten (Rückerstattungen POM)', 18, NULL, NULL, NULL, NULL, '407', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (244, 'IkForderungEinmalig', 65, 'Zins (Rückerstattungen POM)', 26, NULL, NULL, NULL, NULL, '407', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3825, 140, 'IkForderungEinmalig', 99, 'Tagesheim/Krippe', 32, NULL, NULL, NULL, NULL, '405', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3826, 141, 'IkForderungPeriodisch', 1, 'Kinderalimente', 1, NULL, NULL, '1', NULL, '401', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3827, 141, 'IkForderungPeriodisch', 2, 'Erwachsenenalimente', 2, NULL, NULL, '1', NULL, '401', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3828, 141, 'IkForderungPeriodisch', 3, 'Kinder- Ausbildungszulagen', 3, NULL, NULL, '0', NULL, '401', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3829, 141, 'IkForderungPeriodisch', 4, 'Erstbrief', 4, NULL, NULL, '0', NULL, '404', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3830, 141, 'IkForderungPeriodisch', 5, 'Elternbeitrag', 5, NULL, NULL, '0', NULL, '402', NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3831, 142, 'IkForderungTitel', 1, 'Rückerstattungsvereinbarung', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3832, 142, 'IkForderungTitel', 2, 'Verfügung', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3833, 142, 'IkForderungTitel', 3, 'Darlehen', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3834, 143, 'IkIndexRunden', 1, 'Kaufmännisch runden auf 1 Fr.', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3835, 143, 'IkIndexRunden', 2, 'Abrunden auf 1 Fr.', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3836, 143, 'IkIndexRunden', 3, 'Aufrunden auf 1 Fr.', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3837, 143, 'IkIndexRunden', 4, 'Aufrunden auf 5 Fr.', 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3838, 143, 'IkIndexRunden', 5, 'Kaufmännisch auf 5 Fr.', 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3839, 143, 'IkIndexRunden', 6, 'Kaufmännisch auf 10 Fr.', 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3840, 143, 'IkIndexRunden', 7, 'Kaufmännisch auf 5 Rp.', 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3841, 144, 'IkIndexTyp', 1, 'BFS Dez 2005', 1, NULL, NULL, '6', NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3842, 144, 'IkIndexTyp', 2, 'BFS Mai 2000', 2, NULL, NULL, '5', NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3843, 144, 'IkIndexTyp', 3, 'BFS Mai 1993', 3, NULL, NULL, '4', NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3844, 144, 'IkIndexTyp', 4, 'BFS Dez 1982', 4, NULL, NULL, '3', NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3845, 144, 'IkIndexTyp', 5, 'BFS Sep 1977', 5, NULL, NULL, '2', NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3846, 144, 'IkIndexTyp', 6, 'BFS Sep 1966', 6, NULL, NULL, '1', NULL, NULL, NULL, NULL, 1, 1)


INSERT INTO XLOVCode (XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (217, 'IkIndexTyp', 7, 'BFS Dez 2010', 0, NULL, NULL, '7', NULL, NULL, NULL, NULL, 1, 0)

--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3847, 145, 'IkInkassoBemuehung', 1, 'Intensiv', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3848, 145, 'IkInkassoBemuehung', 2, 'Extensiv', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3854, 146, 'IkKbForderungArt', 1, 'ALBV Details', 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3855, 146, 'IkKbForderungArt', 2, 'ALV Details', 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3856, 146, 'IkKbForderungArt', 3, 'KiZu / AZu Details', 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3857, 146, 'IkKbForderungArt', 4, 'Verrechnung +/- ALBV Details', 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3852, 146, 'IkKbForderungArt', 6, 'Sollstellung Detail pro Gläubiger', 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3850, 146, 'IkKbForderungArt', 8, 'Sollstellung Alimente ganze Familie', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3851, 146, 'IkKbForderungArt', 9, 'Sollstellung Alimente pro Gläubiger', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3849, 146, 'IkKbForderungArt', 10, 'ALBV Auszahlung netto', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3853, 146, 'IkKbForderungArt', 31, 'Andere Forderungen', 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3858, 147, 'IkLeistungStatus', 1, 'Laufende Beiträge', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3859, 147, 'IkLeistungStatus', 2, 'Restanz', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3860, 148, 'IkRatenplanVereinbarung', 1, 'Telefonische Vereinbarung', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3861, 148, 'IkRatenplanVereinbarung', 2, 'Persönliche Vereinbarung', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3862, 149, 'IkRechtstitelTyp', 1, 'Gerichtlich genehmigte Scheidungskonvention', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3863, 149, 'IkRechtstitelTyp', 2, 'Unterhaltsregelgung im Rahmen einer aussergerichtlichen Trennungsvereinbarung', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3864, 149, 'IkRechtstitelTyp', 3, 'Scheidungsurteil', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3865, 149, 'IkRechtstitelTyp', 4, 'Trennungsurteil', 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3866, 149, 'IkRechtstitelTyp', 5, 'Unterhaltsvertrag unter Mündigen', 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3867, 149, 'IkRechtstitelTyp', 6, 'Unterhaltsvertrag, nach Art. 287 Abs. 1 ZGB genehmigt', 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3868, 149, 'IkRechtstitelTyp', 7, 'Richt. Unterhaltsverf. im Rahmen eines Unterhaltsprozesses', 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3869, 149, 'IkRechtstitelTyp', 8, 'Unterhaltsurteil', 8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3870, 149, 'IkRechtstitelTyp', 9, 'Richt. Unterhaltsverf. im Rahmen eines Eheschutzverfahrens', 9, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3871, 149, 'IkRechtstitelTyp', 10, 'Richt. Unterhaltsverf. im Rahmen eines Trennungsverfahrens', 10, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3872, 149, 'IkRechtstitelTyp', 11, 'Gerichtlich genehmigte Trennungsvereinbarung', 11, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3873, 149, 'IkRechtstitelTyp', 12, 'Richt. Unterhaltsverf. im Rahemen eines Scheidungsprozesses', 12, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3874, 150, 'IkRueckerstattungTyp', 1, 'unrechtmässig bezogen', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3875, 150, 'IkRueckerstattungTyp', 2, 'in günstige Verhältnisse gelangt', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3876, 150, 'IkRueckerstattungTyp', 3, 'Vorschuss f. Versicherungsleistungen', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3877, 150, 'IkRueckerstattungTyp', 4, 'Freiwillige Rückerstattung', 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3878, 150, 'IkRueckerstattungTyp', 5, 'selbstverschuldete Notlage', 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3879, 150, 'IkRueckerstattungTyp', 6, 'Vorschuss auf nicht realisierbare Vermögenswerte', 6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3880, 151, 'IkSchuldnerStatus', 1, 'Arbeitslos', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3881, 151, 'IkSchuldnerStatus', 2, 'Ausgesteuert', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3882, 151, 'IkSchuldnerStatus', 3, 'Selbständig', 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3883, 151, 'IkSchuldnerStatus', 4, 'Angestellt', 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3884, 152, 'IkVerlustscheinStatus', 1, '(Kein Verlustschein)', 1, NULL, NULL, '0', '0', NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3885, 152, 'IkVerlustscheinStatus', 2, 'Aktiver Verlustschein', 2, NULL, NULL, '1', '0', NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3886, 152, 'IkVerlustscheinStatus', 3, 'Abgetreten an Dritte', 3, NULL, NULL, '1', '1', NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3887, 152, 'IkVerlustscheinStatus', 4, 'Neu betrieben', 4, NULL, NULL, '1', '1', NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3888, 152, 'IkVerlustscheinStatus', 5, 'Bezahlt / gelöscht', 5, NULL, NULL, '1', '1', NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3889, 152, 'IkVerlustscheinStatus', 6, 'Abgeschrieben', 6, NULL, NULL, '1', '1', NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3890, 152, 'IkVerlustscheinStatus', 7, 'An Gläubiger/in übergeben', 7, NULL, NULL, '1', '1', NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3891, 153, 'IkVerlustscheinTyp', 1, 'Aus Betreibung', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3892, 153, 'IkVerlustscheinTyp', 2, 'Aus Konkurs', 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3893, 154, 'IkVerrechnungsart', 1, 'Nachzahlung an Gläubiger', 1, NULL, NULL, '1', NULL, NULL, NULL, NULL, 1, 1)
--INSERT INTO XLOVCode (XLOVCodeID, XLOVID, LOVName, Code, Text, SortKey, ShortText, BFSCode, Value1, Value2, Value3, Description, LOVCodeName, IsActive, System) VALUES (3894, 154, 'IkVerrechnungsart', 2, 'Rückforderung von Gläubiger', 2, NULL, NULL, '2', NULL, NULL, NULL, NULL, 1, 1)
--SET IDENTITY_INSERT XLOVCode OFF
--GO
COMMIT
GO



-------------------------------------------------------------------------------
-- Step: XMenuItem "Modul Konfiguration" (Landesindex)
-------------------------------------------------------------------------------
PRINT ('Info: XMenuItem "Modul Konfiguration" (Landesindex) --> bereits vorhanden');
--IF NOT EXISTS(SELECT TOP 1 1 FROM dbo.XMenuItem WHERE ClassName = 'CtlIkLandesindex')
--BEGIN
--  DECLARE @ParentMenuItemID INT;
--  SELECT @ParentMenuItemID = MenuItemID
--  FROM dbo.XMenuItem MNU WITH (READUNCOMMITTED)
--  WHERE Caption = 'Modul Konfiguration'
--    AND ParentMenuItemID = 6;
    
--  INSERT INTO dbo.XMenuItem(ParentMenuItemID, Caption, ImageIndex, SortKey, ClassName)
--    VALUES  (@ParentMenuItemID, 'Inkasso', 1411, 2, NULL);
    
--  SELECT @ParentMenuItemID = SCOPE_IDENTITY();

--  INSERT INTO dbo.XMenuItem(ParentMenuItemID, Caption, ImageIndex, SortKey, ClassName)
--    VALUES  (@ParentMenuItemID, 'Landesxindex', 1328, 0, 'CtlIkLandesindex');
--END;
GO

-------------------------------------------------------------------------------
-- Step: XMenuItem "Belegimport aus Inkasso" in Klibu
-------------------------------------------------------------------------------
PRINT ('Info: XMenuItem "Belegimport aus Inkasso" in Klibu --> bereits vorhanden');
UPDATE MNU 
  SET [Enabled] = 1, Visible = 1
FROM dbo.XMenuItem MNU
WHERE MenuItemID = (SELECT TOP 1 ParentMenuItemID
                    FROM dbo.XMenuItem MNU WITH (READUNCOMMITTED)
                    WHERE ControlName = 'navBarItemCtlKbBelegImportIK');
GO


-------------------------------------------------------------------------------
-- Step: XMenuItem "Inkasso-Abfragen" (Daten-Explorer)
-------------------------------------------------------------------------------
PRINT ('Info: XMenuItem "Inkasso-Abfragen" (Daten-Explorer)');
DECLARE @MenuItemID_DatenExplorer INT;

SELECT @MenuItemID_DatenExplorer = MenuItemID
FROM dbo.XMenuItem MNU2 WITH (READUNCOMMITTED)
WHERE Caption = 'Daten-Explorer'
  AND ParentMenuItemID = 4 -- Anwendung


IF EXISTS(SELECT TOP 1 1 FROM dbo.XMenuItem WHERE ParentMenuItemID = @MenuItemID_DatenExplorer AND Caption = 'Inkasso')
BEGIN
  UPDATE MNU
    SET Visible = 1
  FROM dbo.XMenuItem MNU
  WHERE ParentMenuItemID = @MenuItemID_DatenExplorer AND Caption = 'Inkasso'
END
--ELSE
--BEGIN
--  DECLARE @MenuItemID_Inkasso INT;
--  INSERT INTO dbo.XMenuItem(ParentMenuItemID, Caption, ImageIndex, SortKey, ClassName)
--    VALUES  (@MenuItemID_DatenExplorer, 'Inkasso', 166, 8, NULL);
    
--  SELECT @MenuItemID_Inkasso = SCOPE_IDENTITY();

--  INSERT INTO dbo.XMenuItem(ParentMenuItemID, Caption, ClassName, ImageIndex, SortKey, [Description])
--    SELECT @MenuItemID_Inkasso, 'Fallführung', 'CtlQueryIkFallführung', 210, 1, NULL UNION ALL
--    SELECT @MenuItemID_Inkasso, 'Fallführung Gesamt', 'CtlQueryIkFallfuehrungGesamt', 210, 2, 'Abfrage Ik Fallführung Gesamt' UNION ALL
--    SELECT @MenuItemID_Inkasso, 'Auswertung Alimenteninkassoführung', 'CtlQueryIkAuswertungAlimenteninkassofuehrung', 210, 3, NULL UNION ALL
--    SELECT @MenuItemID_Inkasso, 'Rückerstattungsgründe', 'CtlQueryIkRueckerstattungsgruende', 210, 4, 'Statistische Auswertung der Forderungen und Zahlungen bezüglich der verschiedenen Rückerstattungsgründe' UNION ALL
--    SELECT @MenuItemID_Inkasso, 'Abklärungen', 'CtlQueryIkAbklaerungen', 210, 5, NULL UNION ALL
--    SELECT @MenuItemID_Inkasso, 'Inkasso Quote', 'CtlQueryIkInkassoquote', 210, 6, NULL UNION ALL
--    SELECT @MenuItemID_Inkasso, 'Rechtliche Massnahmen', 'CtlQueryIkRechtlicheMassnahmen', 210, 8, NULL UNION ALL
--    SELECT @MenuItemID_Inkasso, 'Mahnlauf', 'CtlQueryIkMahnlauf', 210, 8, NULL UNION ALL
--    SELECT @MenuItemID_Inkasso, 'Betreibungs-, Forts.-,Verw.- und Rechtsöff.begehren', 'CtlQueryIkBetreibungsBegehren', 210, 9, NULL UNION ALL
--    SELECT @MenuItemID_Inkasso, 'Aktive Verlustscheine', 'CtlQueryIkAktiveVerlustscheine', 210, 10, NULL UNION ALL
--    SELECT @MenuItemID_Inkasso, 'Anteil Schuldner nach Nationalität', 'CtlQueryIkAnteilSchuldnerNationalitaet', 210, 11, NULL UNION ALL
--    SELECT @MenuItemID_Inkasso, 'Geburtsdatum Gläubiger', 'CtlQueryIkGeburtsdatumGlaeubiger', 210, 12, NULL UNION ALL
--    SELECT @MenuItemID_Inkasso, 'Gläubiger Personalien', 'CtlQueryIkGlaeubigerpersonPersonalien', 210, 12, NULL UNION ALL
--    SELECT @MenuItemID_Inkasso, 'Indexbrief', 'CtlQueryIkIndexbrief', 210, 14, NULL UNION ALL
--    SELECT @MenuItemID_Inkasso, 'Verlustschein Verjährung am', 'CtlQueryIKVerlustscheinVerjährung', 210, 14, NULL UNION ALL
--    SELECT @MenuItemID_Inkasso, 'Archivierung', 'CtlQueryIkInkassoArchivierung', 210, 15, NULL 
--END;
GO

-------------------------------------------------------------------------------
-- Step: KbKonto und BgKostenart hinzufügen
-------------------------------------------------------------------------------
PRINT ('Info: KbKonto und BgKostenart hinzufügen');

BEGIN TRAN
-- KbKonto
DECLARE @KbPeriodeID INT;
SELECT @KbPeriodeID = KbPeriodeID
FROM dbo.KbPeriode
WHERE GETDATE() BETWEEN PeriodeVon AND PeriodeBis;

PRINT ('    Info: KbPeriodeID = ' + CONVERT(VARCHAR(MAX), @KbPeriodeID));

DECLARE @KbKonto TABLE
(
  ID INT IDENTITY (1, 1) NOT NULL,
  GruppeKontoID INT NOT NULL,
  KontoNr VARCHAR(10) NOT NULL,
  KontoName VARCHAR(100) NOT NULL,
  KbKontoklasseCode INT NOT NULL,
  SortKey INT,
  KontoExists BIT NOT NULL,
  KostenartName VARCHAR(100) NOT NULL,
  Quoting BIT NOT NULL,
  BgSplittingArtCode INT NOT NULL,
  BaWVZeileCode INT,
  KoaExists BIT NOT NULL
);

;WITH kontoCte (GruppeKontoNr, KontoNr, KontoName, KbKontoklasseCode, SortKey, KostenartName, Quoting, BgSplittingArtCode, BaWVZeileCode) AS
(
  SELECT '3660.312', '680', 'Bevorschussung Kinderalimente', 3, 601, 'Bevorschussung Kinderalimente', 0, 2, -1 UNION ALL 
  SELECT '3660.322', '681', 'Ablieferung Kinderalimente u. KiZu', 3, 701, 'Ablieferung Kinderalimente u. KiZu', 0, 2, -1 UNION ALL 
  SELECT '3660.312', '682', 'Inkassokosten Bevorschussung', 3, 602, 'Inkassokosten Bevorschussung', 0, 2, -1 UNION ALL 
  SELECT '3660.310', '683', 'Zins Alimentenbevorschussung', 3, 15, 'Zins Alimentenbevorschussung', 0, 2, -1 UNION ALL 
  SELECT '3660.322', '684', 'Ablieferung Erwachsenenalimente', 3, 702, 'Ablieferung Erwachsenenalimente', 1, 2, -1 UNION ALL 
  SELECT '3660.322', '685', 'Inkassokosten Alimentenvermittlung', 3, 703, 'Inkassokosten Alimentenvermittlung', 1, 2, -1 UNION ALL 
  SELECT '4360.301', '700', 'Persönliche Rückerstattungen', 4, 1, 'Persönliche Rückerstattungen', 0, 2, 13 UNION ALL
  SELECT '4360.301', '701', 'Rückerstattungen aus Hinterlassenschaften', 4, 2, 'Rückerstattungen aus Hinterlassenschaften', 0, 2, 13 UNION ALL
  SELECT '4360.304', '720', 'Prämienverbilligung ASV', 4, 401, 'Prämienverbilligung ASV', 0, 2, 11 UNION ALL 
  SELECT '4360.302', '780', 'Rückerst. Bevorschussung Kinderalimente', 4, 201, 'Rückerst. Bevorschussung Kinderalimente', 0, 2, -1 UNION ALL 
  SELECT '4360.309', '781', 'Vermittlung Kinderalimente u. KiZu', 4, 501, 'Vermittlung Kinderalimente u. KiZu', 0, 2, -1 UNION ALL 
  SELECT '4360.302', '783', 'Zins Bevorschussung', 4, 203, 'Zins Bevorschussung', 0, 2, -1 UNION ALL 
  SELECT '4360.309', '784', 'Vermittlung Erwachsenenalimente', 4, 502, 'Vermittlung Erwachsenenalimente', 1, 2, -1 UNION ALL 
  SELECT '4360.309', '785', 'Zins Alimentenvermittlung', 4, 503, 'Zins Alimentenvermittlung', 1, 2, -1 UNION ALL 
  SELECT '4360.304', '852', 'Inkassokosten Rückerstattungen, inkl. POM, Nachlass', 4, 408, 'Inkassokosten Rückerstattungen, inkl. POM, Nachlass', 1, 2, -1 UNION ALL 
  SELECT '4360.304', '853', 'Zins Rückerstattung, inkl. POM, Nachlass', 4, 11, 'Zins Rückerstattung, inkl. POM, Nachlass', 0, 2, NULL UNION ALL
  SELECT '4360.301', '856', 'Inkassokosten Elternbeiträge (EB)', 4, 103, 'Inkassokosten Elternbeiträge (EB)', 1, 2, -1 UNION ALL 
  SELECT '4360.301', '857', 'Inkassokosten Verwandtenbeiträge (VB)', 4, 104, 'Inkassokosten Verwandtenbeiträge (VB)', 1, 2, -1 UNION ALL 
  SELECT '4360.301', '870', 'Erwachsenenalimente im Unterstützungsfall', 4, 105, 'Erwachsenenalimente im Unterstützungsfall', 0, 2, 12 UNION ALL 
  SELECT '4360.301', '871', 'Elternbeiträge', 4, 6, 'Elternbeiträge', 1, 2, 12 UNION ALL
  SELECT '4360.301', '872', 'Kinderalimente u. KiZu im Unterstützungsfall', 4, 107, 'Kinderalimente u. KiZu im Unterstützungsfall', 0, 2, 12 UNION ALL 
  SELECT '4360.301', '873', 'Inkassokosten Alimente im Unterstützungsfall', 4, 108, 'Inkassokosten Alimente im Unterstützungsfall', 1, 2, -1 UNION ALL 
  SELECT '4360.301', '874', 'Zins Alimente im Unterstützungsfall', 4, 109, 'Zins Alimente im Unterstützungsfall', 1, 2, -1 UNION ALL 
  SELECT '4360.301', '875', 'Zins Elternbeiträge (EB)', 4, 110, 'Zins Elternbeiträge (EB)', 1, 2, -1 UNION ALL 
  SELECT '4360.301', '876', 'Zins Verwandtenbeiträge (VB)', 4, 111, 'Zins Verwandtenbeiträge (VB)', 1, 2, -1 UNION ALL 
  SELECT '4360.301', '880', 'Verwandtenbeiträge', 4, 12, 'Verwandtenbeiträge', 0, 2, 12 UNION ALL
  SELECT '4360.304', '904', 'Sozialversicherungsleistungen POM u. and. kant. Behörden', 4, 16, 'Sozialversicherungsleistungen POM u. and. kant. Behörden', 0, 2, NULL
)


INSERT INTO @KbKonto(GruppeKontoID, KontoNr, KontoName, KbKontoklasseCode, SortKey, KontoExists, KostenartName, Quoting, BgSplittingArtCode, BaWVZeileCode, KoaExists)
  SELECT 
    KTOP.KbKontoID, 
    CTE.KontoNr, 
    CTE.KontoName, 
    CTE.KbKontoklasseCode, 
    CTE.SortKey, 
    KontoExists = CASE WHEN KTO.KbKontoID IS NOT NULL THEN 1 ELSE 0 END,
    CTE.KostenartName, 
    CTE.Quoting, 
    CTE.BgSplittingArtCode, 
    CTE.BaWVZeileCode, 
    KoaExists = CASE WHEN KOA.BgKostenartID IS NOT NULL THEN 1 ELSE 0 END
  FROM kontoCte CTE
    LEFT JOIN dbo.KbKonto     KTOP WITH (READUNCOMMITTED) ON KTOP.KbPeriodeID = @KbPeriodeID
                                                         AND KTOP.KontoNr = CTE.GruppeKontoNr
    LEFT JOIN dbo.KbKonto     KTO  WITH (READUNCOMMITTED) ON KTO.KbPeriodeID = @KbPeriodeID
                                                         AND KTO.KontoNr = CTE.KontoNr
    LEFT JOIN dbo.BgKostenart KOA  WITH (READUNCOMMITTED) ON KOA.KontoNr = CTE.KontoNr

UPDATE KTO
  SET GruppeKontoID = TMP.GruppeKontoID, 
      KontoNr = TMP.KontoNr, 
      KontoName = TMP.KontoName, 
      KbKontoklasseCode = TMP.KbKontoklasseCode
FROM dbo.KbKonto KTO
  INNER JOIN @KbKonto TMP ON TMP.KontoNr = KTO.KontoNr
WHERE KTO.KbPeriodeID = @KbPeriodeID;
PRINT ('    Info: ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' KbKonto angepasst');

INSERT INTO dbo.KbKonto(KbPeriodeID, GruppeKontoID, KontoNr, KontoName, KbKontoklasseCode, SortKey, Kontogruppe)
  SELECT  @KbPeriodeID,
          GruppeKontoID,
          KontoNr,
          KontoName,
          KbKontoklasseCode,
          SortKey,
          Kontogruppe = 0
  FROM @KbKonto 
  WHERE KontoExists = 0;
PRINT ('    Info: ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' KbKonto hinzugefügt');

-- BgKostenart
UPDATE KOA
  SET Name = TMP.KostenartName,
      Quoting = TMP.Quoting, 
      BgSplittingArtCode = TMP.BgSplittingArtCode, 
      BaWVZeileCode = TMP.BaWVZeileCode
FROM dbo.BgKostenart KOA
  INNER JOIN @KbKonto TMP ON TMP.KontoNr = KOA.KontoNr
PRINT ('    Info: ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' BgKostenart angepasst');

INSERT INTO dbo.BgKostenart(ModulID, Name, KontoNr, Quoting, BgSplittingArtCode, BaWVZeileCode)
  SELECT 3, KostenartName, KontoNr, Quoting, BgSplittingArtCode, BaWVZeileCode
  FROM @KbKonto
  WHERE KoaExists = 0
PRINT ('    Info: ' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + ' BgKostenart hinzugefügt');
COMMIT
GO


-------------------------------------------------------------------------------
-- Step: Konto in Kontoplan sortieren
-------------------------------------------------------------------------------
PRINT('Info: Konto in Kontoplan sortieren');

DECLARE @KbPeriodeID INT;
SELECT @KbPeriodeID = KbPeriodeID
FROM dbo.KbPeriode
WHERE GETDATE() BETWEEN PeriodeVon AND PeriodeBis;

DECLARE @KbKontoCTE TABLE(
  KbKontoID INT NOT NULL,
  KontoNr   VARCHAR(10),
  [Level]   INT
);

-- get account with level
WITH KontoCTE (KbKontoID, KontoNr, [Level]) AS -- common table expression 
(
  SELECT 
    KbKontoID,
    KontoNr,
    [Level] = 0
  FROM KbKonto
  WHERE KbPeriodeID = @KbPeriodeID
    AND GruppeKontoID IS NULL

  UNION ALL

  SELECT 
    KTO.KbKontoID,
    KTO.KontoNr,
    [Level] = [Level] + 1
  FROM KbKonto KTO
    INNER JOIN KontoCTE CTE ON CTE.KbKontoID = KTO.GruppeKontoID
  WHERE KbPeriodeID = @KbPeriodeID
)

INSERT INTO @KbKontoCTE
SELECT *
FROM KontoCTE CTE
ORDER BY CTE.Level, CTE.KontoNr

DECLARE @MaxLevel      INT,
        @LevelIterator INT,
        @KontoCount    INT,
        @KontoIterator INT;

DECLARE @GruppeKontoID INT;

DECLARE @Konto TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  KbKontoID INT
);

DECLARE @SortKonto TABLE
(
  KbKontoID INT,
  SortKey   INT
);


SELECT @MaxLevel = MAX([Level])
FROM @KbKontoCTE;

SET @LevelIterator = 0;
SET @KontoIterator = 0;

-- foreach level but last
WHILE(@LevelIterator < @MaxLevel)
BEGIN
  -- get account at this level
  INSERT INTO @Konto(KbKontoID)
  SELECT KbKontoID
  FROM @KbKontoCTE
  WHERE [Level] = @LevelIterator;

  SELECT @KontoCount = COUNT(1) FROM @Konto
  
  -- foreach account at this level
  WHILE (@KontoIterator <= @KontoCount)
  BEGIN
    -- get current entry
    SELECT @GruppeKontoID = TMP.KbKontoID
    FROM @Konto TMP
    WHERE TMP.ID = @KontoIterator;
    
    -- order by KontoNr
    INSERT INTO @SortKonto(KbKontoID, SortKey)
      SELECT 
        KbKontoID,
        SortKey = ROW_NUMBER() OVER (ORDER BY KontoNr)
      FROM KbKonto
      WHERE GruppeKontoID = @GruppeKontoID
      ORDER BY KontoNr;
    
    -- Set the new SortKey
    UPDATE KTO
    SET SortKey = KTOS.SortKey
    FROM KbKonto KTO
      INNER JOIN @SortKonto KTOS ON KTOS.KbKontoID = KTO.KbKontoID;
    
    
    -- prepare for next account entry
    SET @KontoIterator = @KontoIterator + 1;
  END;  

  -- prepare for next level entry
  SET @LevelIterator = @LevelIterator + 1;
END;
GO


-------------------------------------------------------------------------------
-- Step: Daten in IkForderungBgKostenartHist erfassen
-------------------------------------------------------------------------------
PRINT ('Info: Daten in IkForderungBgKostenartHist erfassen');
/*
SELECT  KOA.KontoNr,
        IkForderungPeriodischCode,
        IstAlbvBerechtigt,
        IstAlbvUeberMax,
        IstUnterstuetzungsfall,
        IkForderungEinmaligCode,
        IkForderungsartFilterCode,
        DatumVon,
        DatumBis,
        '  SELECT ''' + KOA.KontoNr + ''', ' + ISNULL(CONVERT(VARCHAR(MAX), IkForderungPeriodischCode), 'NULL') + ', ' + CONVERT(VARCHAR(MAX), IstAlbvBerechtigt) + ', ' + CONVERT(VARCHAR(MAX), IstAlbvUeberMax) + ', ' + CONVERT(VARCHAR(MAX), IstUnterstuetzungsfall) + ', '+ ISNULL(CONVERT(VARCHAR(MAX), IkForderungEinmaligCode), 'NULL') + ', ' + ISNULL(CONVERT(VARCHAR(MAX), IkForderungsartFilterCode), 'NULL') + ' UNION ALL' 
FROM dbo.IkForderungBgKostenartHist FKH WITH (READUNCOMMITTED)
  INNER JOIN dbo.BgKostenart KOA WITH (READUNCOMMITTED) ON KOA.BgKostenartID = FKH.BgKostenartID
WHERE DatumBis IS NULL
ORDER BY CASE WHEN IkForderungPeriodischCode IS NULL THEN 1 ELSE 0 END, IkForderungPeriodischCode, IstAlbvBerechtigt, IstAlbvUeberMax, IstUnterstuetzungsfall, IkForderungEinmaligCode, DatumVon, KontoNr
*/

DELETE FROM dbo.IkForderungBgKostenartHist;

DECLARE @Creator VARCHAR(50);
SET @Creator = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID())

;WITH ForderungKoaCte (KontoNr, IkForderungPeriodischCode, IstAlbvBerechtigt, IstAlbvUeberMax, IstUnterstuetzungsfall, IkForderungEinmaligCode, IkForderungsartFilterCode) AS
(
  SELECT '781', 1, 0, 0, 0, NULL, 4 UNION ALL
  SELECT '872', 1, 0, 0, 1, NULL, 1 UNION ALL
  SELECT '780', 1, 1, 0, 0, NULL, 2 UNION ALL
  SELECT '781', 1, 1, 1, 0, NULL, 3 UNION ALL
  SELECT '784', 2, 0, 0, 0, NULL, 6 UNION ALL
  SELECT '870', 2, 0, 0, 1, NULL, 5 UNION ALL
  SELECT '781', 3, 0, 0, 0, NULL, 8 UNION ALL
  SELECT '872', 3, 0, 0, 1, NULL, 7 UNION ALL
  SELECT '781', 3, 1, 0, 0, NULL, 9 UNION ALL
  SELECT '880', 4, 0, 0, 0, NULL, 40 UNION ALL
  SELECT '871', 5, 0, 0, 0, NULL, 50 UNION ALL
  SELECT '872', NULL, 0, 0, 0, 1, 1 UNION ALL
  SELECT '780', NULL, 0, 0, 0, 2, 2 UNION ALL
  SELECT '781', NULL, 0, 0, 0, 3, 3 UNION ALL
  SELECT '781', NULL, 0, 0, 0, 4, 4 UNION ALL
  SELECT '870', NULL, 0, 0, 0, 5, 5 UNION ALL
  SELECT '784', NULL, 0, 0, 0, 6, 6 UNION ALL
  SELECT '872', NULL, 0, 0, 0, 7, 7 UNION ALL
  SELECT '781', NULL, 0, 0, 0, 8, 8 UNION ALL
  SELECT '781', NULL, 0, 0, 0, 9, 9 UNION ALL
  SELECT '682', NULL, 0, 0, 0, 11, 11 UNION ALL
  SELECT '685', NULL, 0, 0, 0, 12, 12 UNION ALL
  SELECT '685', NULL, 0, 0, 0, 13, 13 UNION ALL
  SELECT '873', NULL, 0, 0, 0, 14, 14 UNION ALL
  SELECT '783', NULL, 0, 0, 0, 15, 15 UNION ALL
  SELECT '874', NULL, 0, 0, 0, 16, 16 UNION ALL
  SELECT '701', NULL, 0, 0, 0, 30, 30 UNION ALL
  SELECT '852', NULL, 0, 0, 0, 32, 32 UNION ALL
  SELECT '853', NULL, 0, 0, 0, 33, 33 UNION ALL
  SELECT '785', NULL, 0, 0, 0, 34, 34 UNION ALL
  SELECT '880', NULL, 0, 0, 0, 40, 40 UNION ALL
  SELECT '857', NULL, 0, 0, 0, 41, 41 UNION ALL
  SELECT '876', NULL, 0, 0, 0, 42, 42 UNION ALL
  SELECT '871', NULL, 0, 0, 0, 50, 50 UNION ALL
  SELECT '856', NULL, 0, 0, 0, 51, 51 UNION ALL
  SELECT '875', NULL, 0, 0, 0, 52, 52 UNION ALL
  SELECT '700', NULL, 0, 0, 0, 60, 60 UNION ALL
  SELECT '904', NULL, 0, 0, 0, 61, 61 UNION ALL
  SELECT '852', NULL, 0, 0, 0, 62, 62 UNION ALL
  SELECT '853', NULL, 0, 0, 0, 63, 63 UNION ALL
  SELECT '852', NULL, 0, 0, 0, 64, 64 UNION ALL
  SELECT '853', NULL, 0, 0, 0, 65, 65 
)

INSERT INTO dbo.IkForderungBgKostenartHist (BgKostenartID, IkForderungPeriodischCode, IstAlbvBerechtigt, IstAlbvUeberMax, IstUnterstuetzungsfall, 
                                            IkForderungEinmaligCode, IkForderungsartFilterCode, Creator, Created, Modifier, Modified)
  SELECT 
    BgKostenartID = KOA.BgKostenartID, 
    IkForderungPeriodischCode = CTE.IkForderungPeriodischCode, 
    IstAlbvBerechtigt         = CTE.IstAlbvBerechtigt, 
    IstAlbvUeberMax           = CTE.IstAlbvUeberMax, 
    IstUnterstuetzungsfall    = CTE.IstUnterstuetzungsfall, 
    IkForderungEinmaligCode   = CTE.IkForderungEinmaligCode, 
    IkForderungsartFilterCode = CTE.IkForderungsartFilterCode, 
    Creator  = @Creator, 
    Created  = GETDATE(), 
    Modifier = @Creator, 
    Modified = GETDATE()
  FROM ForderungKoaCte CTE
    LEFT JOIN dbo.BgKostenart KOA WITH (READUNCOMMITTED) ON KOA.KontoNr = CTE.KontoNr
GO


-------------------------------------------------------------------------------
-- Step: Daten in IkForderung_BgKostenart erfassen
-------------------------------------------------------------------------------
PRINT ('Info: Daten in IkForderung_BgKostenart erfassen');
/*
SELECT  Forderung = KOAF.KontoNr,
        Auszahlung =  KOAF.KontoNr,
        IkForderungEinmaligCode,
        IkForderungPeriodischCode,
        '  SELECT ''' + KOAF.KontoNr + ''', ''' + KOAA.KontoNr + ''', ' + ISNULL(CONVERT(VARCHAR(MAX), IkForderungEinmaligCode), 'NULL') + ', ' + ISNULL(CONVERT(VARCHAR(MAX), IkForderungPeriodischCode), 'NULL') + ' UNION ALL'
FROM dbo.IkForderung_BgKostenart IFK WITH (READUNCOMMITTED)
  LEFT JOIN dbo.BgKostenart KOAF WITH (READUNCOMMITTED) ON KOAF.BgKostenartID = IFK.BgKostenartID_Forderung
  LEFT JOIN dbo.BgKostenart KOAA WITH (READUNCOMMITTED) ON KOAA.BgKostenartID = IFK.BgKostenartID_Auszahlung
WHERE 1=1
*/

DELETE FROM dbo.IkForderung_BgKostenart;

DECLARE @Creator VARCHAR(50);
SET @Creator = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID())

;WITH ForderungKoaCte (ForderungKontoNr, AuszahlungKontoNr, IkForderungEinmaligCode, IkForderungPeriodischCode) AS
(
  SELECT '780', '680', NULL, 1 UNION ALL
  SELECT '780', '680', 2, NULL UNION ALL
  SELECT '781', '681', NULL, 1 UNION ALL
  SELECT '781', '681', 3, NULL UNION ALL
  SELECT '781', '681', NULL, 3 UNION ALL
  SELECT '781', '681', 9, NULL UNION ALL
  SELECT '781', '681', 4, NULL UNION ALL
  SELECT '784', '684', NULL, 2 UNION ALL
  SELECT '784', '684', 6, NULL UNION ALL
  SELECT '781', '681', 8, NULL 
)

INSERT INTO dbo.IkForderung_BgKostenart(BgKostenartID_Forderung, BgKostenartID_Auszahlung, IkForderungEinmaligCode, IkForderungPeriodischCode, Creator, Created, Modifier, Modified)
  SELECT 
    BgKostenartID_Forderung   = KOAF.BgKostenartID, 
    BgKostenartID_Auszahlung  = KOAA.BgKostenartID, 
    IkForderungEinmaligCode   = CTE.IkForderungEinmaligCode, 
    IkForderungPeriodischCode = CTE.IkForderungPeriodischCode, 
    Creator  = @Creator, 
    Created  = GETDATE(), 
    Modifier = @Creator, 
    Modified = GETDATE()
  FROM ForderungKoaCte CTE
    LEFT JOIN dbo.BgKostenart KOAF WITH (READUNCOMMITTED) ON KOAF.KontoNr = CTE.ForderungKontoNr
    LEFT JOIN dbo.BgKostenart KOAA WITH (READUNCOMMITTED) ON KOAA.KontoNr = CTE.AuszahlungKontoNr
GO


-------------------------------------------------------------------------------
-- Step: Konto als Zahlungseingang Inkasso markieren
-------------------------------------------------------------------------------
PRINT ('Info: Konto als Zahlungseingang Inkasso markieren --> ist bereits angepasst');
--DECLARE @KontoNr VARCHAR(20);
--SET @KontoNr = '1001.01';

--DECLARE @KbPeriodeID INT;
--SELECT @KbPeriodeID = KbPeriodeID
--FROM dbo.KbPeriode
--WHERE GETDATE() BETWEEN PeriodeVon AND PeriodeBis;

--IF NOT EXISTS(SELECT TOP 1 1 
--              FROM dbo.KbKonto 
--              WHERE KbPeriodeID = @KbPeriodeID 
--                AND KontoNr = @KontoNr 
--                AND ',' + KbKontoartCodes + ',' LIKE '%,50,%')
--BEGIN
--  UPDATE dbo.KbKonto
--    SET KbKontoartCodes = KbKontoartCodes + ',50'
--  WHERE KbPeriodeID = @KbPeriodeID
--    AND KontoNr = @KontoNr;
--  PRINT ('      KontoNr: ' + @KontoNr);
--END;
GO


-------------------------------------------------------------------------------
-- Step: Inkasso-Benutzergruppe erstellen und Maskenrecht setzen
-------------------------------------------------------------------------------
PRINT ('Info: Inkasso-Benutzergruppe erstellen und Maskenrecht setzen');
IF EXISTS(SELECT TOP 1 1 FROM dbo.XUserGroup WHERE UserGroupName = 'Inkasso')
BEGIN
  PRINT ('    Info: Inkasso-Benutzergruppe ist bereits vorhanden');
END
ELSE
BEGIN
  DECLARE @Creator VARCHAR(50);
  SET @Creator = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID())
  
  -- Benutzergruppe
  INSERT INTO dbo.XUserGroup(UserGroupName, OnlyAdminVisible, [Description], Creator, Created, Modifier, Modified)
    VALUES  ('Inkasso', 0, 'Inkasso', @Creator, GETDATE(), @Creator, GETDATE());
    
  DECLARE @UserGroupID INT;
  SELECT @UserGroupID = SCOPE_IDENTITY();
  
  -- zugeteilte Rechte
  INSERT INTO dbo.XUserGroup_Right (UserGroupID, ClassName, RightID, QueryName, MaskName, MayInsert, MayUpdate, MayDelete)
    SELECT @UserGroupID, 'CtlIkAbklaerungen', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlIkBetreibungenVerlustscheine', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlIkForderungen', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlIkGlaeubiger', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlIkKontoauszug', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlIkLandesindex', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlIkLeistung', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlIkModulTree', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlIkMonatszahlen', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlIkMonatszahlenEinmalig', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlIkMonatszahlenSaldo', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlIkMonatszahlenVerrechnung', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlIkRechtlicheMassnahmenInkassofall', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlIkRechtlicheMassnahmenSchuldner', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlIkRechtstitel', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlIkRechtstitelForderung', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlQueryIkAbklaerungen', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlQueryIkAktiveVerlustscheine', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlQueryIkAnteilSchuldnerNationalitaet', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlQueryIkAuswertungAlimenteninkassofuehrung', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlQueryIkBetreibungsBegehren', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlQueryIkFallfuehrungGesamt', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlQueryIkFallführung', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlQueryIkGeburtsdatumGlaeubiger', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlQueryIkGlaeubigerpersonPersonalien', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlQueryIkIndexbrief', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlQueryIkInkassoArchivierung', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlQueryIkInkassoquote', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlQueryIkKinderzulagen', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlQueryIkMahnlauf', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlQueryIkRechtlicheMassnahmen', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlQueryIkRueckerstattungsgruende', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlQueryIKVerlustscheinVerjährung', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'DlgLandesindexWertErfassen', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'DlgLandesindexKopieren', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'DlgZahlungenErfassen', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, 'CtlKbBelegImportIK', NULL, NULL, NULL, 1, 1, 1 UNION ALL
    SELECT @UserGroupID, ClassName, RightID, NULL, NULL, 1, 1, 1 
    FROM dbo.XRight RGT
    WHERE ClassName = 'CtlIkModulTree'
    
  ---- Benutzer TODO?
  --INSERT INTO dbo.XUser_UserGroup (UserID, UserGroupID)
  --  SELECT UserID, @UserGroupID
  --  FROM dbo.XUser USR WITH (READUNCOMMITTED)
  --  WHERE LogonName IN ('usercabe28', 'usercabe42')
END;
GO


-------------------------------------------------------------------------------
-- Step: Daten in XConfig erfassen
-------------------------------------------------------------------------------
PRINT ('Info: Daten in XConfig erfassen');
--TODO: XConfig in "System\KliBu\Sozialhilferechnung\%" auch prüfen
SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XConfig] WHERE KeyPath LIKE 'System\Inkasso\%'
GO
INSERT INTO [XConfig] ([XNamespaceExtensionID], [KeyPath], [System], [DatumVon], [ValueCode], [LOVName], [Description], [ValueBit], [OriginalValueBit], [ValueDateTime], [OriginalValueDateTime], [ValueDecimal], [OriginalValueDecimal], [ValueInt], [OriginalValueInt], [ValueMoney], [OriginalValueMoney], [ValueVarchar], [OriginalValueVarchar], [Creator], [Created], [Modifier], [Modified]) VALUES (NULL, N'System\Inkasso\ALBVMaximalBetrag', 0, CONVERT(datetime, '20010101', 112), 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 824.0000, 824.0000, NULL, NULL, N'System', CONVERT(datetime, '2013-06-28 16:20:28', 120), N'System', CONVERT(datetime, '2013-06-28 16:20:28', 120))
INSERT INTO [XConfig] ([XNamespaceExtensionID], [KeyPath], [System], [DatumVon], [ValueCode], [LOVName], [Description], [ValueBit], [OriginalValueBit], [ValueDateTime], [OriginalValueDateTime], [ValueDecimal], [OriginalValueDecimal], [ValueInt], [OriginalValueInt], [ValueMoney], [OriginalValueMoney], [ValueVarchar], [OriginalValueVarchar], [Creator], [Created], [Modifier], [Modified]) VALUES (NULL, N'System\Inkasso\ALBVMaximalBetrag', 0, CONVERT(datetime, '20030101', 112), 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 844.0000, 824.0000, NULL, NULL, N'System', CONVERT(datetime, '2013-06-28 16:20:28', 120), N'System', CONVERT(datetime, '2013-06-28 16:20:28', 120))
INSERT INTO [XConfig] ([XNamespaceExtensionID], [KeyPath], [System], [DatumVon], [ValueCode], [LOVName], [Description], [ValueBit], [OriginalValueBit], [ValueDateTime], [OriginalValueDateTime], [ValueDecimal], [OriginalValueDecimal], [ValueInt], [OriginalValueInt], [ValueMoney], [OriginalValueMoney], [ValueVarchar], [OriginalValueVarchar], [Creator], [Created], [Modifier], [Modified]) VALUES (NULL, N'System\Inkasso\ALBVMaximalBetrag', 0, CONVERT(datetime, '20050101', 112), 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 860.0000, 824.0000, NULL, NULL, N'System', CONVERT(datetime, '2013-06-28 16:20:28', 120), N'System', CONVERT(datetime, '2013-06-28 16:20:28', 120))
INSERT INTO [XConfig] ([XNamespaceExtensionID], [KeyPath], [System], [DatumVon], [ValueCode], [LOVName], [Description], [ValueBit], [OriginalValueBit], [ValueDateTime], [OriginalValueDateTime], [ValueDecimal], [OriginalValueDecimal], [ValueInt], [OriginalValueInt], [ValueMoney], [OriginalValueMoney], [ValueVarchar], [OriginalValueVarchar], [Creator], [Created], [Modifier], [Modified]) VALUES (NULL, N'System\Inkasso\ALBVMaximalBetrag', 0, CONVERT(datetime, '20070101', 112), 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 884.0000, 824.0000, NULL, NULL, N'System', CONVERT(datetime, '2013-06-28 16:20:28', 120), N'System', CONVERT(datetime, '2013-06-28 16:20:28', 120))
INSERT INTO [XConfig] ([XNamespaceExtensionID], [KeyPath], [System], [DatumVon], [ValueCode], [LOVName], [Description], [ValueBit], [OriginalValueBit], [ValueDateTime], [OriginalValueDateTime], [ValueDecimal], [OriginalValueDecimal], [ValueInt], [OriginalValueInt], [ValueMoney], [OriginalValueMoney], [ValueVarchar], [OriginalValueVarchar], [Creator], [Created], [Modifier], [Modified]) VALUES (NULL, N'System\Inkasso\ALBVMaximalBetrag', 0, CONVERT(datetime, '20090101', 112), 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 912.0000, 824.0000, NULL, NULL, N'System', CONVERT(datetime, '2013-06-28 16:20:28', 120), N'System', CONVERT(datetime, '2013-06-28 16:20:28', 120))
INSERT INTO [XConfig] ([XNamespaceExtensionID], [KeyPath], [System], [DatumVon], [ValueCode], [LOVName], [Description], [ValueBit], [OriginalValueBit], [ValueDateTime], [OriginalValueDateTime], [ValueDecimal], [OriginalValueDecimal], [ValueInt], [OriginalValueInt], [ValueMoney], [OriginalValueMoney], [ValueVarchar], [OriginalValueVarchar], [Creator], [Created], [Modifier], [Modified]) VALUES (NULL, N'System\Inkasso\ALBVMaximalBetrag', 0, CONVERT(datetime, '20110101', 112), 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 928.0000, 824.0000, NULL, NULL, N'System', CONVERT(datetime, '2013-06-28 16:20:28', 120), N'System', CONVERT(datetime, '2013-06-28 16:20:28', 120))
INSERT INTO [XConfig] ([XNamespaceExtensionID], [KeyPath], [System], [DatumVon], [ValueCode], [LOVName], [Description], [ValueBit], [OriginalValueBit], [ValueDateTime], [OriginalValueDateTime], [ValueDecimal], [OriginalValueDecimal], [ValueInt], [OriginalValueInt], [ValueMoney], [OriginalValueMoney], [ValueVarchar], [OriginalValueVarchar], [Creator], [Created], [Modifier], [Modified]) VALUES (NULL, N'System\Inkasso\ALBVMaximalBetrag', 0, CONVERT(datetime, '20130101', 112), 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 936.0000, 824.0000, NULL, NULL, N'System', CONVERT(datetime, '2013-06-28 16:20:28', 120), N'System', CONVERT(datetime, '2013-06-28 16:20:28', 120))
INSERT INTO [XConfig] ([XNamespaceExtensionID], [KeyPath], [System], [DatumVon], [ValueCode], [LOVName], [Description], [ValueBit], [OriginalValueBit], [ValueDateTime], [OriginalValueDateTime], [ValueDecimal], [OriginalValueDecimal], [ValueInt], [OriginalValueInt], [ValueMoney], [OriginalValueMoney], [ValueVarchar], [OriginalValueVarchar], [Creator], [Created], [Modifier], [Modified]) VALUES (NULL, N'System\Inkasso\MonatszahlenMonateVergangenheit', 0, CONVERT(datetime, '19000101', 112), 2, NULL, N'Anzahl Monate ', NULL, NULL, NULL, NULL, NULL, NULL, 2, 2, NULL, NULL, NULL, NULL, N'System', CONVERT(datetime, '2013-06-28 16:20:28', 120), N'System', CONVERT(datetime, '2013-06-28 16:20:28', 120))
INSERT INTO [XConfig] ([XNamespaceExtensionID], [KeyPath], [System], [DatumVon], [ValueCode], [LOVName], [Description], [ValueBit], [OriginalValueBit], [ValueDateTime], [OriginalValueDateTime], [ValueDecimal], [OriginalValueDecimal], [ValueInt], [OriginalValueInt], [ValueMoney], [OriginalValueMoney], [ValueVarchar], [OriginalValueVarchar], [Creator], [Created], [Modifier], [Modified]) VALUES (NULL, N'System\Inkasso\MonatszahlenMonateZukunft', 0, CONVERT(datetime, '19000101', 112), 2, NULL, N'Anzahl Monate', NULL, NULL, NULL, NULL, NULL, NULL, 4, 4, NULL, NULL, NULL, NULL, N'System', CONVERT(datetime, '2013-06-28 16:20:28', 120), N'System', CONVERT(datetime, '2013-06-28 16:20:28', 120))
INSERT INTO [XConfig] ([XNamespaceExtensionID], [KeyPath], [System], [DatumVon], [ValueCode], [LOVName], [Description], [ValueBit], [OriginalValueBit], [ValueDateTime], [OriginalValueDateTime], [ValueDecimal], [OriginalValueDecimal], [ValueInt], [OriginalValueInt], [ValueMoney], [OriginalValueMoney], [ValueVarchar], [OriginalValueVarchar], [Creator], [Created], [Modifier], [Modified]) VALUES (NULL, N'System\Inkasso\PendenzgruppeID', 1, CONVERT(datetime, '2011-01-28 16:31:11', 120), 2, NULL, N'FaPendenzgruppeID der Inkassodienst-Pendenzgruppe', NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, NULL, NULL, N'System', CONVERT(datetime, '2013-06-28 16:20:28', 120), N'System', CONVERT(datetime, '2013-06-28 16:20:28', 120))
GO
COMMIT
GO

-------------------------------------------------------------------------------
-- Step: Daten in FaPendenzgruppe erfassen
-------------------------------------------------------------------------------
PRINT ('Info: Daten in FaPendenzgruppe erfassen');
IF (NOT EXISTS(SELECT TOP 1 1
               FROM dbo.FaPendenzgruppe WITH (READUNCOMMITTED)
               WHERE Name = 'Inkassodienst'))
BEGIN
  INSERT INTO dbo.FaPendenzgruppe(Name, Beschreibung)
    VALUES ('Inkassodienst', 'Gruppe für den Inkassodienst');
END;

UPDATE CNF
  SET ValueInt = PGR.FaPendenzgruppeID
FROM dbo.XConfig CNF
  LEFT JOIN dbo.FaPendenzgruppe PGR WITH (READUNCOMMITTED) ON PGR.Name = 'Inkassodienst'
WHERE CNF.KeyPath = 'System\Inkasso\PendenzgruppeID'
GO



-------------------------------------------------------------------------------
-- Step: Daten in IkLandesindex erfassen
-------------------------------------------------------------------------------
PRINT ('Info: Daten in IkLandesindex erfassen');
-- LOV IkIndexTyp
BEGIN TRAN

-- bereits vorhanden
--DELETE dbo.XLOVCode WHERE LOVName = 'IkIndexTyp';

----set identity_insert XLOVCode on
--INSERT [XLOVCode]([LOVName], [Code], [Text], [TextTID], [SortKey], [ShortText], [ShortTextTID], [BFSCode], [Value1], [Value1TID], [Value2], [Value2TID], [Value3], [Value3TID], [Description], [System], [LOVCodeName], [IsActive])
--  VALUES ( N'IkIndexTyp' , 7,  N'BFS Dez 2010' ,  null , 0,  null ,  null ,  null ,  N'7' ,  null ,  null ,  null ,  null ,  null ,  null ,  0 ,  null ,  1 )
--INSERT [XLOVCode]([LOVName], [Code], [Text], [TextTID], [SortKey], [ShortText], [ShortTextTID], [BFSCode], [Value1], [Value1TID], [Value2], [Value2TID], [Value3], [Value3TID], [Description], [System], [LOVCodeName], [IsActive])
--  VALUES ( N'IkIndexTyp' , 1,  N'BFS Dez 2005' ,  null , 1,  null ,  null ,  null ,  N'6' ,  null ,  null ,  null ,  null ,  null ,  null ,  1 ,  null ,  1 )
--INSERT [XLOVCode]([LOVName], [Code], [Text], [TextTID], [SortKey], [ShortText], [ShortTextTID], [BFSCode], [Value1], [Value1TID], [Value2], [Value2TID], [Value3], [Value3TID], [Description], [System], [LOVCodeName], [IsActive])
--  VALUES ( N'IkIndexTyp' , 2,  N'BFS Mai 2000' ,  null , 2,  null ,  null ,  null ,  N'5' ,  null ,  null ,  null ,  null ,  null ,  null ,  1 ,  null ,  1 )
--INSERT [XLOVCode]([LOVName], [Code], [Text], [TextTID], [SortKey], [ShortText], [ShortTextTID], [BFSCode], [Value1], [Value1TID], [Value2], [Value2TID], [Value3], [Value3TID], [Description], [System], [LOVCodeName], [IsActive])
--  VALUES ( N'IkIndexTyp' , 3,  N'BFS Mai 1993' ,  null , 3,  null ,  null ,  null ,  N'4' ,  null ,  null ,  null ,  null ,  null ,  null ,  1 ,  null ,  1 )
--INSERT [XLOVCode]([LOVName], [Code], [Text], [TextTID], [SortKey], [ShortText], [ShortTextTID], [BFSCode], [Value1], [Value1TID], [Value2], [Value2TID], [Value3], [Value3TID], [Description], [System], [LOVCodeName], [IsActive])
--  VALUES ( N'IkIndexTyp' , 4,  N'BFS Dez 1982' ,  null , 4,  null ,  null ,  null ,  N'3' ,  null ,  null ,  null ,  null ,  null ,  null ,  1 ,  null ,  1 )
--INSERT [XLOVCode]([LOVName], [Code], [Text], [TextTID], [SortKey], [ShortText], [ShortTextTID], [BFSCode], [Value1], [Value1TID], [Value2], [Value2TID], [Value3], [Value3TID], [Description], [System], [LOVCodeName], [IsActive])
--  VALUES ( N'IkIndexTyp' , 5,  N'BFS Sep 1977' ,  null , 5,  null ,  null ,  null ,  N'2' ,  null ,  null ,  null ,  null ,  null ,  null ,  1 ,  null ,  1 )
--INSERT [XLOVCode]([LOVName], [Code], [Text], [TextTID], [SortKey], [ShortText], [ShortTextTID], [BFSCode], [Value1], [Value1TID], [Value2], [Value2TID], [Value3], [Value3TID], [Description], [System], [LOVCodeName], [IsActive])
--  VALUES ( N'IkIndexTyp' , 6,  N'BFS Sep 1966' ,  null , 6,  null ,  null ,  null ,  N'1' ,  null ,  null ,  null ,  null ,  null ,  null ,  1 ,  null ,  1 )
----set identity_insert XLOVCode off

-- IkLandesindex
DELETE FROM IkLandesindexWert;
DELETE FROM IkLandesindex;

set identity_insert IkLandesindex on
INSERT INTO [IkLandesindex] ([IkLandesindexID], [Name], [Creator], [Created], [Modifier], [Modified]) VALUES (1, N'BFS1966', N'System', CONVERT(datetime, '2011-10-07 16:47:27', 120), N'System', CONVERT(datetime, '2011-10-07 16:47:27', 120))
INSERT INTO [IkLandesindex] ([IkLandesindexID], [Name], [Creator], [Created], [Modifier], [Modified]) VALUES (2, N'BFS1977', N'System', CONVERT(datetime, '2011-10-07 16:47:27', 120), N'System', CONVERT(datetime, '2011-10-07 16:47:27', 120))
INSERT INTO [IkLandesindex] ([IkLandesindexID], [Name], [Creator], [Created], [Modifier], [Modified]) VALUES (3, N'BFS1982', N'System', CONVERT(datetime, '2011-10-07 16:47:27', 120), N'System', CONVERT(datetime, '2011-10-07 16:47:27', 120))
INSERT INTO [IkLandesindex] ([IkLandesindexID], [Name], [Creator], [Created], [Modifier], [Modified]) VALUES (4, N'BFS1993', N'System', CONVERT(datetime, '2011-10-07 16:47:27', 120), N'System', CONVERT(datetime, '2011-10-07 16:47:27', 120))
INSERT INTO [IkLandesindex] ([IkLandesindexID], [Name], [Creator], [Created], [Modifier], [Modified]) VALUES (5, N'BFS2000', N'System', CONVERT(datetime, '2011-10-07 16:47:27', 120), N'System', CONVERT(datetime, '2011-10-07 16:47:27', 120))
INSERT INTO [IkLandesindex] ([IkLandesindexID], [Name], [Creator], [Created], [Modifier], [Modified]) VALUES (6, N'BFS2005', N'System', CONVERT(datetime, '2011-10-07 16:47:27', 120), N'System', CONVERT(datetime, '2011-10-07 16:47:27', 120))
INSERT INTO [IkLandesindex] ([IkLandesindexID], [Name], [Creator], [Created], [Modifier], [Modified]) VALUES (7, N'BFS2010', N'System', CONVERT(datetime, '2011-10-10 10:10:08', 120), N'System', CONVERT(datetime, '2011-10-10 10:10:08', 120))
set identity_insert IkLandesindex off


-- IkLandesindexWert
set identity_insert IkLandesindexWert on
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1, 1, 1976, 12, 167.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (2, 1, 1977, 1, 167.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (3, 1, 1977, 2, 167.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (4, 1, 1977, 3, 167.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (5, 1, 1977, 4, 167.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (6, 1, 1977, 5, 167.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (7, 1, 1977, 6, 168.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (8, 1, 1977, 7, 168.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (9, 1, 1977, 8, 168.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (10, 1, 1977, 9, 168.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (11, 1, 1977, 10, 169.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (12, 1, 1977, 11, 168.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (13, 1, 1977, 12, 169.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (14, 1, 1978, 1, 169.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (15, 1, 1978, 2, 169.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (16, 1, 1978, 3, 169.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (17, 1, 1978, 4, 169.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (18, 1, 1978, 5, 170.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (19, 1, 1978, 6, 170.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (20, 1, 1978, 7, 170.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (21, 1, 1978, 8, 170.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (22, 1, 1978, 9, 170.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (23, 1, 1978, 10, 169.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (24, 1, 1978, 11, 169.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (25, 1, 1978, 12, 170.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (26, 1, 1979, 1, 170.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (27, 1, 1979, 2, 172.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (28, 1, 1979, 3, 173.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (29, 1, 1979, 4, 174.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (30, 1, 1979, 5, 174.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (31, 1, 1979, 6, 177.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (32, 1, 1979, 7, 177.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (33, 1, 1979, 8, 177.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (34, 1, 1979, 9, 178.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (35, 1, 1979, 10, 178.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (36, 1, 1979, 11, 178.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (37, 1, 1979, 12, 179.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (38, 1, 1980, 1, 179.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (39, 1, 1980, 2, 179.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (40, 1, 1980, 3, 180.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (41, 1, 1980, 4, 181.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (42, 1, 1980, 5, 182.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (43, 1, 1980, 6, 183.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (44, 1, 1980, 7, 183.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (45, 1, 1980, 8, 184.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (46, 1, 1980, 9, 184.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (47, 1, 1980, 10, 184.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (48, 1, 1980, 11, 186.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (49, 1, 1980, 12, 187.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (50, 1, 1981, 1, 188.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (51, 1, 1981, 2, 190.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (52, 1, 1981, 3, 191.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (53, 1, 1981, 4, 191.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (54, 1, 1981, 5, 193.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (55, 1, 1981, 6, 194.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (56, 1, 1981, 7, 195.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (57, 1, 1981, 8, 198.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (58, 1, 1981, 9, 198.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (59, 1, 1981, 10, 198.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (60, 1, 1981, 11, 199.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (61, 1, 1981, 12, 199.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (62, 1, 1982, 1, 200.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (63, 1, 1982, 2, 200.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (64, 1, 1982, 3, 201.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (65, 1, 1982, 4, 202.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (66, 1, 1982, 5, 204.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (67, 1, 1982, 6, 206.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (68, 1, 1982, 7, 207.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (69, 1, 1982, 8, 208.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (70, 1, 1982, 9, 209.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (71, 1, 1982, 10, 210.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (72, 1, 1982, 11, 210.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (73, 1, 1982, 12, 210.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (74, 1, 1983, 1, 209.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (75, 1, 1983, 2, 210.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (76, 1, 1983, 3, 210.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (77, 1, 1983, 4, 211.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (78, 1, 1983, 5, 211.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (79, 1, 1983, 6, 212.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (80, 1, 1983, 7, 211.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (81, 1, 1983, 8, 212.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (82, 1, 1983, 9, 212.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (83, 1, 1983, 10, 213.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (84, 1, 1983, 11, 214.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (85, 1, 1983, 12, 214.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (86, 1, 1984, 1, 215.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (87, 1, 1984, 2, 216.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (88, 1, 1984, 3, 217.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (89, 1, 1984, 4, 218.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (90, 1, 1984, 5, 217.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (91, 1, 1984, 6, 218.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (92, 1, 1984, 7, 217.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (93, 1, 1984, 8, 218.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (94, 1, 1984, 9, 218.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (95, 1, 1984, 10, 219.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (96, 1, 1984, 11, 221.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (97, 1, 1984, 12, 220.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (98, 1, 1985, 1, 223.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (99, 1, 1985, 2, 224.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (100, 1, 1985, 3, 226.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (101, 1, 1985, 4, 225.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (102, 1, 1985, 5, 225.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (103, 1, 1985, 6, 225.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (104, 1, 1985, 7, 225.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (105, 1, 1985, 8, 225.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (106, 1, 1985, 9, 225.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (107, 1, 1985, 10, 226.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (108, 1, 1985, 11, 227.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (109, 1, 1985, 12, 228.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (110, 1, 1986, 1, 228.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (111, 1, 1986, 2, 227.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (112, 1, 1986, 3, 228.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (113, 1, 1986, 4, 228.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (114, 1, 1986, 5, 227.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (115, 1, 1986, 6, 227.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (116, 1, 1986, 7, 226.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (117, 1, 1986, 8, 226.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (118, 1, 1986, 9, 227.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (119, 1, 1986, 10, 227.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (120, 1, 1986, 11, 227.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (121, 1, 1986, 12, 228.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (122, 1, 1987, 1, 229.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (123, 1, 1987, 2, 230.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (124, 1, 1987, 3, 230.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (125, 1, 1987, 4, 230.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (126, 1, 1987, 5, 229.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (127, 1, 1987, 6, 230.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (128, 1, 1987, 7, 230.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (129, 1, 1987, 8, 231.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (130, 1, 1987, 9, 230.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (131, 1, 1987, 10, 231.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (132, 1, 1987, 11, 232.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (133, 1, 1987, 12, 232.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (134, 1, 1988, 1, 233.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (135, 1, 1988, 2, 234.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (136, 1, 1988, 3, 234.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (137, 1, 1988, 4, 235.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (138, 1, 1988, 5, 234.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (139, 1, 1988, 6, 235.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (140, 1, 1988, 7, 234.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (141, 1, 1988, 8, 235.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (142, 1, 1988, 9, 235.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (143, 1, 1988, 10, 235.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (144, 1, 1988, 11, 236.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (145, 1, 1988, 12, 237.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (146, 1, 1989, 1, 238.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (147, 1, 1989, 2, 239.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (148, 1, 1989, 3, 240.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (149, 1, 1989, 4, 241.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (150, 1, 1989, 5, 241.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (151, 1, 1989, 6, 242.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (152, 1, 1989, 7, 241.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (153, 1, 1989, 8, 242.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (154, 1, 1989, 9, 243.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (155, 1, 1989, 10, 244.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (156, 1, 1989, 11, 247.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (157, 1, 1989, 12, 248.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (158, 1, 1990, 1, 250.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (159, 1, 1990, 2, 251.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (160, 1, 1990, 3, 252.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (161, 1, 1990, 4, 252.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (162, 1, 1990, 5, 253.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (163, 1, 1990, 6, 254.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (164, 1, 1990, 7, 254.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (165, 1, 1990, 8, 257.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (166, 1, 1990, 9, 258.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (167, 1, 1990, 10, 259.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (168, 1, 1990, 11, 262.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (169, 1, 1990, 12, 262.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (170, 1, 1991, 1, 264.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (171, 1, 1991, 2, 266.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (172, 1, 1991, 3, 266.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (173, 1, 1991, 4, 267.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (174, 1, 1991, 5, 269.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (175, 1, 1991, 6, 270.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (176, 1, 1991, 7, 270.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (177, 1, 1991, 8, 272.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (178, 1, 1991, 9, 272.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (179, 1, 1991, 10, 273.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (180, 1, 1991, 11, 276.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (181, 1, 1991, 12, 275.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (182, 1, 1992, 1, 277.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (183, 1, 1992, 2, 279.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (184, 1, 1992, 3, 279.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (185, 1, 1992, 4, 280.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (186, 1, 1992, 5, 281.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (187, 1, 1992, 6, 282.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (188, 1, 1992, 7, 281.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (189, 1, 1992, 8, 282.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (190, 1, 1992, 9, 282.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (191, 1, 1992, 10, 282.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (192, 1, 1992, 11, 285.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (193, 1, 1992, 12, 285.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (194, 1, 1993, 1, 286.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (195, 1, 1993, 2, 288.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (196, 1, 1993, 3, 290.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (197, 1, 1993, 4, 290.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (198, 1, 1993, 5, 291.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (199, 1, 1993, 6, 291.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (200, 1, 1993, 7, 290.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (201, 1, 1993, 8, 292.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (202, 1, 1993, 9, 292.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (203, 1, 1993, 10, 292.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (204, 1, 1993, 11, 291.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (205, 1, 1993, 12, 292.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (206, 1, 1994, 1, 292.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (207, 1, 1994, 2, 293.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (208, 1, 1994, 3, 293.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (209, 1, 1994, 4, 293.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (210, 1, 1994, 5, 292.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (211, 1, 1994, 6, 292.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (212, 1, 1994, 7, 292.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (213, 1, 1994, 8, 293.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (214, 1, 1994, 9, 293.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (215, 1, 1994, 10, 293.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (216, 1, 1994, 11, 293.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (217, 1, 1994, 12, 293.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (218, 1, 1995, 1, 295.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (219, 1, 1995, 2, 298.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (220, 1, 1995, 3, 298.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (221, 1, 1995, 4, 298.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (222, 1, 1995, 5, 298.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (223, 1, 1995, 6, 298.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (224, 1, 1995, 7, 298.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (225, 1, 1995, 8, 299.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (226, 1, 1995, 9, 299.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (227, 1, 1995, 10, 299.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (228, 1, 1995, 11, 299.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (229, 1, 1995, 12, 299.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (230, 1, 1996, 1, 300.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (231, 1, 1996, 2, 300.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (232, 1, 1996, 3, 301.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (233, 1, 1996, 4, 301.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (234, 1, 1996, 5, 300.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (235, 1, 1996, 6, 300.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (236, 1, 1996, 7, 300.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (237, 1, 1996, 8, 301.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (238, 1, 1996, 9, 301.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (239, 1, 1996, 10, 301.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (240, 1, 1996, 11, 301.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (241, 1, 1996, 12, 301.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (242, 1, 1997, 1, 302.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (243, 1, 1997, 2, 303.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (244, 1, 1997, 3, 302.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (245, 1, 1997, 4, 302.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (246, 1, 1997, 5, 302.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (247, 1, 1997, 6, 302.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (248, 1, 1997, 7, 302.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (249, 1, 1997, 8, 302.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (250, 1, 1997, 9, 302.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (251, 1, 1997, 10, 302.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (252, 1, 1997, 11, 302.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (253, 1, 1997, 12, 302.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (254, 1, 1998, 1, 302.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (255, 1, 1998, 2, 303.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (256, 1, 1998, 3, 302.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (257, 1, 1998, 4, 302.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (258, 1, 1998, 5, 302.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (259, 1, 1998, 6, 302.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (260, 1, 1998, 7, 302.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (261, 1, 1998, 8, 303.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (262, 1, 1998, 9, 302.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (263, 1, 1998, 10, 302.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (264, 1, 1998, 11, 302.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (265, 1, 1998, 12, 302.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (266, 1, 1999, 1, 302.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (267, 1, 1999, 2, 303.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (268, 1, 1999, 3, 304.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (269, 1, 1999, 4, 304.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (270, 1, 1999, 5, 304.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (271, 1, 1999, 6, 304.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (272, 1, 1999, 7, 304.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (273, 1, 1999, 8, 305.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (274, 1, 1999, 9, 306.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (275, 1, 1999, 10, 306.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (276, 1, 1999, 11, 306.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (277, 1, 1999, 12, 307.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (278, 1, 2000, 1, 307.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (279, 1, 2000, 2, 308.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (280, 1, 2000, 3, 308.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (281, 1, 2000, 4, 308.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (282, 1, 2000, 5, 308.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (283, 1, 2000, 6, 309.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (284, 1, 2000, 7, 310.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (285, 1, 2000, 8, 309.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (286, 1, 2000, 9, 310.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (287, 1, 2000, 10, 310.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (288, 1, 2000, 11, 312.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (289, 1, 2000, 12, 311.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (290, 1, 2001, 1, 311.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (291, 1, 2001, 2, 311.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (292, 1, 2001, 3, 311.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (293, 1, 2001, 4, 312.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (294, 1, 2001, 5, 314.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (295, 1, 2001, 6, 314.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (296, 1, 2001, 7, 314.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (297, 1, 2001, 8, 312.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (298, 1, 2001, 9, 313.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (299, 1, 2001, 10, 312.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (300, 1, 2001, 11, 312.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (301, 1, 2001, 12, 312.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (302, 1, 2002, 1, 313.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (303, 1, 2002, 2, 313.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (304, 1, 2002, 3, 313.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (305, 1, 2002, 4, 316.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (306, 1, 2002, 5, 316.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (307, 1, 2002, 6, 315.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (308, 1, 2002, 7, 314.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (309, 1, 2002, 8, 314.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (310, 1, 2002, 9, 314.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (311, 1, 2002, 10, 316.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (312, 1, 2002, 11, 315.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (313, 1, 2002, 12, 315.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (314, 1, 2003, 1, 315.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (315, 1, 2003, 2, 316.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (316, 1, 2003, 3, 317.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (317, 1, 2003, 4, 318.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (318, 1, 2003, 5, 317.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (319, 1, 2003, 6, 317.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (320, 1, 2003, 7, 315.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (321, 1, 2003, 8, 315.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (322, 1, 2003, 9, 316.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (323, 1, 2003, 10, 317.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (324, 1, 2003, 11, 317.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (325, 1, 2003, 12, 317.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (326, 1, 2004, 1, 316.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (327, 1, 2004, 2, 316.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (328, 1, 2004, 3, 317.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (329, 1, 2004, 4, 319.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (330, 1, 2004, 5, 320.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (331, 1, 2004, 6, 321.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (332, 1, 2004, 7, 317.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (333, 1, 2004, 8, 318.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (334, 1, 2004, 9, 318.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (335, 1, 2004, 10, 321.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (336, 1, 2004, 11, 322.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (337, 1, 2004, 12, 321.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (338, 1, 2005, 1, 320.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (339, 1, 2005, 2, 320.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (340, 1, 2005, 3, 321.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (341, 1, 2005, 4, 324.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (342, 1, 2005, 5, 324.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (343, 1, 2005, 6, 323.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (344, 1, 2005, 7, 321.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (345, 1, 2005, 8, 322.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (346, 1, 2005, 9, 323.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (347, 1, 2005, 10, 326.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (348, 1, 2005, 11, 325.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (349, 1, 2005, 12, 325.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (350, 1, 2006, 1, 324.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (351, 1, 2006, 2, 325.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (352, 1, 2006, 3, 325.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (353, 1, 2006, 4, 327.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (354, 1, 2006, 5, 328.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (355, 1, 2006, 6, 328.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (356, 1, 2006, 7, 326.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (357, 1, 2006, 8, 326.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (358, 1, 2006, 9, 326.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (359, 1, 2006, 10, 327.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (360, 1, 2006, 11, 326.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (361, 1, 2006, 12, 327.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (362, 1, 2007, 1, 324.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (363, 1, 2007, 2, 325.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (364, 1, 2007, 3, 325.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (365, 1, 2007, 4, 329.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (366, 1, 2007, 5, 330.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (367, 1, 2007, 6, 330.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (368, 1, 2007, 7, 328.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (369, 1, 2007, 8, 328.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (370, 1, 2007, 9, 328.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (371, 1, 2007, 10, 331.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (372, 1, 2007, 11, 332.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (373, 1, 2007, 12, 333.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (374, 1, 2008, 1, 332.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (375, 1, 2008, 2, 333.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (376, 1, 2008, 3, 334.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (377, 1, 2008, 4, 336.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (378, 1, 2008, 5, 339.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (379, 1, 2008, 6, 340.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (380, 1, 2008, 7, 338.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (381, 1, 2008, 8, 337.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (382, 1, 2008, 9, 338.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (383, 1, 2008, 10, 339.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (384, 1, 2008, 11, 337.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (385, 1, 2008, 12, 335.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (386, 1, 2009, 1, 333.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (387, 1, 2009, 2, 333.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (388, 1, 2009, 3, 332.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (389, 1, 2009, 4, 335.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (390, 1, 2009, 5, 336.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (391, 1, 2009, 6, 336.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (392, 1, 2009, 7, 334.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (393, 1, 2009, 8, 334.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (394, 1, 2009, 9, 334.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (395, 1, 2009, 10, 337.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (396, 1, 2009, 11, 337.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (397, 1, 2009, 12, 336.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (398, 1, 2010, 11, 338.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (399, 2, 1976, 12, 99.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (400, 2, 1977, 1, 99.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (401, 2, 1977, 2, 99.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (402, 2, 1977, 3, 99.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (403, 2, 1977, 4, 99.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (404, 2, 1977, 5, 99.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (405, 2, 1977, 6, 99.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (406, 2, 1977, 7, 99.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (407, 2, 1977, 8, 99.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (408, 2, 1977, 9, 100.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (409, 2, 1977, 10, 100.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (410, 2, 1977, 11, 100.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (411, 2, 1977, 12, 100.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (412, 2, 1978, 1, 100.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (413, 2, 1978, 2, 100.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (414, 2, 1978, 3, 100.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (415, 2, 1978, 4, 100.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (416, 2, 1978, 5, 100.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (417, 2, 1978, 6, 101.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (418, 2, 1978, 7, 101.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (419, 2, 1978, 8, 101.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (420, 2, 1978, 9, 100.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (421, 2, 1978, 10, 100.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (422, 2, 1978, 11, 100.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (423, 2, 1978, 12, 101.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (424, 2, 1979, 1, 101.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (425, 2, 1979, 2, 102.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (426, 2, 1979, 3, 103.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (427, 2, 1979, 4, 103.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (428, 2, 1979, 5, 103.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (429, 2, 1979, 6, 105.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (430, 2, 1979, 7, 105.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (431, 2, 1979, 8, 105.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (432, 2, 1979, 9, 105.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (433, 2, 1979, 10, 105.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (434, 2, 1979, 11, 106.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (435, 2, 1979, 12, 106.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (436, 2, 1980, 1, 106.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (437, 2, 1980, 2, 106.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (438, 2, 1980, 3, 107.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (439, 2, 1980, 4, 107.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (440, 2, 1980, 5, 108.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (441, 2, 1980, 6, 108.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (442, 2, 1980, 7, 108.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (443, 2, 1980, 8, 109.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (444, 2, 1980, 9, 109.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (445, 2, 1980, 10, 109.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (446, 2, 1980, 11, 110.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (447, 2, 1980, 12, 110.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (448, 2, 1981, 1, 112.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (449, 2, 1981, 2, 113.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (450, 2, 1981, 3, 113.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (451, 2, 1981, 4, 113.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (452, 2, 1981, 5, 114.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (453, 2, 1981, 6, 115.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (454, 2, 1981, 7, 116.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (455, 2, 1981, 8, 117.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (456, 2, 1981, 9, 117.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (457, 2, 1981, 10, 117.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (458, 2, 1981, 11, 118.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (459, 2, 1981, 12, 118.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (460, 2, 1982, 1, 118.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (461, 2, 1982, 2, 119.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (462, 2, 1982, 3, 119.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (463, 2, 1982, 4, 119.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (464, 2, 1982, 5, 121.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (465, 2, 1982, 6, 122.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (466, 2, 1982, 7, 123.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (467, 2, 1982, 8, 123.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (468, 2, 1982, 9, 124.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (469, 2, 1982, 10, 124.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (470, 2, 1982, 11, 125.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (471, 2, 1982, 12, 124.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (472, 2, 1983, 1, 124.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (473, 2, 1983, 2, 124.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (474, 2, 1983, 3, 124.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (475, 2, 1983, 4, 125.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (476, 2, 1983, 5, 125.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (477, 2, 1983, 6, 125.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (478, 2, 1983, 7, 125.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (479, 2, 1983, 8, 126.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (480, 2, 1983, 9, 126.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (481, 2, 1983, 10, 126.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (482, 2, 1983, 11, 127.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (483, 2, 1983, 12, 127.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (484, 2, 1984, 1, 127.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (485, 2, 1984, 2, 128.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (486, 2, 1984, 3, 129.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (487, 2, 1984, 4, 129.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (488, 2, 1984, 5, 129.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (489, 2, 1984, 6, 129.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (490, 2, 1984, 7, 129.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (491, 2, 1984, 8, 129.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (492, 2, 1984, 9, 129.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (493, 2, 1984, 10, 130.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (494, 2, 1984, 11, 131.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (495, 2, 1984, 12, 131.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (496, 2, 1985, 1, 132.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (497, 2, 1985, 2, 133.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (498, 2, 1985, 3, 134.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (499, 2, 1985, 4, 134.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (500, 2, 1985, 5, 133.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (501, 2, 1985, 6, 133.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (502, 2, 1985, 7, 133.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (503, 2, 1985, 8, 133.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (504, 2, 1985, 9, 133.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (505, 2, 1985, 10, 134.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (506, 2, 1985, 11, 135.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (507, 2, 1985, 12, 135.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (508, 2, 1986, 1, 135.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (509, 2, 1986, 2, 135.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (510, 2, 1986, 3, 135.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (511, 2, 1986, 4, 135.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (512, 2, 1986, 5, 134.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (513, 2, 1986, 6, 134.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (514, 2, 1986, 7, 134.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (515, 2, 1986, 8, 134.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (516, 2, 1986, 9, 134.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (517, 2, 1986, 10, 134.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (518, 2, 1986, 11, 135.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (519, 2, 1986, 12, 135.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (520, 2, 1987, 1, 136.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (521, 2, 1987, 2, 136.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (522, 2, 1987, 3, 136.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (523, 2, 1987, 4, 136.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (524, 2, 1987, 5, 136.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (525, 2, 1987, 6, 136.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (526, 2, 1987, 7, 136.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (527, 2, 1987, 8, 137.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (528, 2, 1987, 9, 136.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (529, 2, 1987, 10, 137.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (530, 2, 1987, 11, 137.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (531, 2, 1987, 12, 137.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (532, 2, 1988, 1, 138.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (533, 2, 1988, 2, 138.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (534, 2, 1988, 3, 139.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (535, 2, 1988, 4, 139.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (536, 2, 1988, 5, 139.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (537, 2, 1988, 6, 139.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (538, 2, 1988, 7, 139.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (539, 2, 1988, 8, 139.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (540, 2, 1988, 9, 139.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (541, 2, 1988, 10, 139.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (542, 2, 1988, 11, 140.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (543, 2, 1988, 12, 140.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (544, 2, 1989, 1, 141.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (545, 2, 1989, 2, 142.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (546, 2, 1989, 3, 142.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (547, 2, 1989, 4, 143.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (548, 2, 1989, 5, 143.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (549, 2, 1989, 6, 143.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (550, 2, 1989, 7, 143.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (551, 2, 1989, 8, 143.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (552, 2, 1989, 9, 144.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (553, 2, 1989, 10, 144.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (554, 2, 1989, 11, 146.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (555, 2, 1989, 12, 147.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (556, 2, 1990, 1, 148.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (557, 2, 1990, 2, 149.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (558, 2, 1990, 3, 149.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (559, 2, 1990, 4, 149.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (560, 2, 1990, 5, 150.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (561, 2, 1990, 6, 150.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (562, 2, 1990, 7, 150.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (563, 2, 1990, 8, 152.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (564, 2, 1990, 9, 153.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (565, 2, 1990, 10, 154.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (566, 2, 1990, 11, 155.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (567, 2, 1990, 12, 155.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (568, 2, 1991, 1, 156.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (569, 2, 1991, 2, 158.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (570, 2, 1991, 3, 158.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (571, 2, 1991, 4, 158.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (572, 2, 1991, 5, 160.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (573, 2, 1991, 6, 160.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (574, 2, 1991, 7, 160.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (575, 2, 1991, 8, 161.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (576, 2, 1991, 9, 161.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (577, 2, 1991, 10, 162.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (578, 2, 1991, 11, 163.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (579, 2, 1991, 12, 163.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (580, 2, 1992, 1, 164.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (581, 2, 1992, 2, 165.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (582, 2, 1992, 3, 166.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (583, 2, 1992, 4, 166.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (584, 2, 1992, 5, 166.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (585, 2, 1992, 6, 167.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (586, 2, 1992, 7, 166.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (587, 2, 1992, 8, 167.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (588, 2, 1992, 9, 167.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (589, 2, 1992, 10, 167.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (590, 2, 1992, 11, 169.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (591, 2, 1992, 12, 169.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (592, 2, 1993, 1, 170.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (593, 2, 1993, 2, 171.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (594, 2, 1993, 3, 172.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (595, 2, 1993, 4, 172.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (596, 2, 1993, 5, 172.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (597, 2, 1993, 6, 172.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (598, 2, 1993, 7, 172.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (599, 2, 1993, 8, 173.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (600, 2, 1993, 9, 173.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (601, 2, 1993, 10, 173.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (602, 2, 1993, 11, 173.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (603, 2, 1993, 12, 173.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (604, 2, 1994, 1, 173.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (605, 2, 1994, 2, 174.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (606, 2, 1994, 3, 174.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (607, 2, 1994, 4, 174.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (608, 2, 1994, 5, 173.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (609, 2, 1994, 6, 173.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (610, 2, 1994, 7, 173.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (611, 2, 1994, 8, 174.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (612, 2, 1994, 9, 174.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (613, 2, 1994, 10, 174.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (614, 2, 1994, 11, 174.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (615, 2, 1994, 12, 174.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (616, 2, 1995, 1, 175.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (617, 2, 1995, 2, 176.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (618, 2, 1995, 3, 177.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (619, 2, 1995, 4, 177.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (620, 2, 1995, 5, 176.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (621, 2, 1995, 6, 177.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (622, 2, 1995, 7, 177.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (623, 2, 1995, 8, 177.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (624, 2, 1995, 9, 177.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (625, 2, 1995, 10, 177.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (626, 2, 1995, 11, 177.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (627, 2, 1995, 12, 177.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (628, 2, 1996, 1, 178.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (629, 2, 1996, 2, 178.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (630, 2, 1996, 3, 178.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (631, 2, 1996, 4, 178.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (632, 2, 1996, 5, 178.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (633, 2, 1996, 6, 178.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (634, 2, 1996, 7, 178.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (635, 2, 1996, 8, 178.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (636, 2, 1996, 9, 178.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (637, 2, 1996, 10, 179.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (638, 2, 1996, 11, 178.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (639, 2, 1996, 12, 178.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (640, 2, 1997, 1, 179.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (641, 2, 1997, 2, 179.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (642, 2, 1997, 3, 179.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (643, 2, 1997, 4, 179.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (644, 2, 1997, 5, 179.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (645, 2, 1997, 6, 179.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (646, 2, 1997, 7, 179.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (647, 2, 1997, 8, 179.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (648, 2, 1997, 9, 179.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (649, 2, 1997, 10, 179.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (650, 2, 1997, 11, 179.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (651, 2, 1997, 12, 179.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (652, 2, 1998, 1, 179.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (653, 2, 1998, 2, 179.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (654, 2, 1998, 3, 179.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (655, 2, 1998, 4, 179.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (656, 2, 1998, 5, 179.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (657, 2, 1998, 6, 179.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (658, 2, 1998, 7, 179.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (659, 2, 1998, 8, 179.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (660, 2, 1998, 9, 179.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (661, 2, 1998, 10, 179.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (662, 2, 1998, 11, 179.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (663, 2, 1998, 12, 179.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (664, 2, 1999, 1, 179.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (665, 2, 1999, 2, 180.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (666, 2, 1999, 3, 180.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (667, 2, 1999, 4, 180.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (668, 2, 1999, 5, 180.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (669, 2, 1999, 6, 180.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (670, 2, 1999, 7, 180.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (671, 2, 1999, 8, 181.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (672, 2, 1999, 9, 181.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (673, 2, 1999, 10, 181.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (674, 2, 1999, 11, 181.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (675, 2, 1999, 12, 182.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (676, 2, 2000, 1, 182.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (677, 2, 2000, 2, 183.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (678, 2, 2000, 3, 183.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (679, 2, 2000, 4, 183.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (680, 2, 2000, 5, 183.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (681, 2, 2000, 6, 183.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (682, 2, 2000, 7, 184.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (683, 2, 2000, 8, 183.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (684, 2, 2000, 9, 184.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (685, 2, 2000, 10, 184.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (686, 2, 2000, 11, 185.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (687, 2, 2000, 12, 185.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (688, 2, 2001, 1, 184.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (689, 2, 2001, 2, 184.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (690, 2, 2001, 3, 184.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (691, 2, 2001, 4, 185.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (692, 2, 2001, 5, 186.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (693, 2, 2001, 6, 186.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (694, 2, 2001, 7, 186.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (695, 2, 2001, 8, 185.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (696, 2, 2001, 9, 185.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (697, 2, 2001, 10, 185.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (698, 2, 2001, 11, 185.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (699, 2, 2001, 12, 185.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (700, 2, 2002, 1, 185.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (701, 2, 2002, 2, 185.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (702, 2, 2002, 3, 185.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (703, 2, 2002, 4, 187.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (704, 2, 2002, 5, 187.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (705, 2, 2002, 6, 187.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (706, 2, 2002, 7, 186.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (707, 2, 2002, 8, 186.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (708, 2, 2002, 9, 186.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (709, 2, 2002, 10, 187.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (710, 2, 2002, 11, 187.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (711, 2, 2002, 12, 187.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (712, 2, 2003, 1, 187.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (713, 2, 2003, 2, 187.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (714, 2, 2003, 3, 188.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (715, 2, 2003, 4, 188.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (716, 2, 2003, 5, 188.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (717, 2, 2003, 6, 188.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (718, 2, 2003, 7, 186.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (719, 2, 2003, 8, 187.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (720, 2, 2003, 9, 187.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (721, 2, 2003, 10, 188.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (722, 2, 2003, 11, 188.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (723, 2, 2003, 12, 188.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (724, 2, 2004, 1, 187.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (725, 2, 2004, 2, 187.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (726, 2, 2004, 3, 188.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (727, 2, 2004, 4, 189.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (728, 2, 2004, 5, 190.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (729, 2, 2004, 6, 190.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (730, 2, 2004, 7, 188.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (731, 2, 2004, 8, 189.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (732, 2, 2004, 9, 189.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (733, 2, 2004, 10, 191.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (734, 2, 2004, 11, 191.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (735, 2, 2004, 12, 190.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (736, 2, 2005, 1, 189.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (737, 2, 2005, 2, 190.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (738, 2, 2005, 3, 190.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (739, 2, 2005, 4, 192.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (740, 2, 2005, 5, 192.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (741, 2, 2005, 6, 191.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (742, 2, 2005, 7, 190.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (743, 2, 2005, 8, 191.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (744, 2, 2005, 9, 191.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (745, 2, 2005, 10, 193.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (746, 2, 2005, 11, 193.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (747, 2, 2005, 12, 192.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (748, 2, 2006, 1, 192.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (749, 2, 2006, 2, 193.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (750, 2, 2006, 3, 192.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (751, 2, 2006, 4, 194.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (752, 2, 2006, 5, 194.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (753, 2, 2006, 6, 194.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (754, 2, 2006, 7, 193.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (755, 2, 2006, 8, 193.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (756, 2, 2006, 9, 193.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (757, 2, 2006, 10, 194.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (758, 2, 2006, 11, 193.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (759, 2, 2006, 12, 193.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (760, 2, 2007, 1, 192.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (761, 2, 2007, 2, 193.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (762, 2, 2007, 3, 193.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (763, 2, 2007, 4, 195.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (764, 2, 2007, 5, 195.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (765, 2, 2007, 6, 196.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (766, 2, 2007, 7, 194.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (767, 2, 2007, 8, 194.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (768, 2, 2007, 9, 194.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (769, 2, 2007, 10, 196.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (770, 2, 2007, 11, 197.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (771, 2, 2007, 12, 197.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (772, 2, 2008, 1, 197.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (773, 2, 2008, 2, 197.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (774, 2, 2008, 3, 198.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (775, 2, 2008, 4, 199.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (776, 2, 2008, 5, 201.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (777, 2, 2008, 6, 201.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (778, 2, 2008, 7, 200.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (779, 2, 2008, 8, 200.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (780, 2, 2008, 9, 200.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (781, 2, 2008, 10, 201.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (782, 2, 2008, 11, 200.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (783, 2, 2008, 12, 199.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (784, 2, 2009, 1, 197.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (785, 2, 2009, 2, 198.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (786, 2, 2009, 3, 197.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (787, 2, 2009, 4, 199.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (788, 2, 2009, 5, 199.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (789, 2, 2009, 6, 199.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (790, 2, 2009, 7, 198.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (791, 2, 2009, 8, 198.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (792, 2, 2009, 9, 198.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (793, 2, 2009, 10, 199.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (794, 2, 2009, 11, 200.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (795, 2, 2009, 12, 199.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (796, 2, 2010, 11, 200.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (797, 3, 1982, 1, 95.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (798, 3, 1982, 2, 95.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (799, 3, 1982, 3, 95.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (800, 3, 1982, 4, 96.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (801, 3, 1982, 5, 97.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (802, 3, 1982, 6, 98.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (803, 3, 1982, 7, 98.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (804, 3, 1982, 8, 99.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (805, 3, 1982, 9, 99.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (806, 3, 1982, 10, 100.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (807, 3, 1982, 11, 100.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (808, 3, 1982, 12, 100.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (809, 3, 1983, 1, 99.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (810, 3, 1983, 2, 100.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (811, 3, 1983, 3, 100.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (812, 3, 1983, 4, 100.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (813, 3, 1983, 5, 100.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (814, 3, 1983, 6, 101.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (815, 3, 1983, 7, 100.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (816, 3, 1983, 8, 101.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (817, 3, 1983, 9, 101.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (818, 3, 1983, 10, 101.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (819, 3, 1983, 11, 102.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (820, 3, 1983, 12, 102.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (821, 3, 1984, 1, 102.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (822, 3, 1984, 2, 102.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (823, 3, 1984, 3, 103.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (824, 3, 1984, 4, 103.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (825, 3, 1984, 5, 103.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (826, 3, 1984, 6, 103.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (827, 3, 1984, 7, 103.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (828, 3, 1984, 8, 104.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (829, 3, 1984, 9, 103.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (830, 3, 1984, 10, 104.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (831, 3, 1984, 11, 105.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (832, 3, 1984, 12, 105.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (833, 3, 1985, 1, 106.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (834, 3, 1985, 2, 107.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (835, 3, 1985, 3, 107.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (836, 3, 1985, 4, 107.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (837, 3, 1985, 5, 107.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (838, 3, 1985, 6, 107.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (839, 3, 1985, 7, 107.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (840, 3, 1985, 8, 107.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (841, 3, 1985, 9, 107.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (842, 3, 1985, 10, 107.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (843, 3, 1985, 11, 108.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (844, 3, 1985, 12, 108.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (845, 3, 1986, 1, 108.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (846, 3, 1986, 2, 108.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (847, 3, 1986, 3, 108.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (848, 3, 1986, 4, 108.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (849, 3, 1986, 5, 108.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (850, 3, 1986, 6, 108.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (851, 3, 1986, 7, 107.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (852, 3, 1986, 8, 107.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (853, 3, 1986, 9, 108.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (854, 3, 1986, 10, 108.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (855, 3, 1986, 11, 108.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (856, 3, 1986, 12, 108.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (857, 3, 1987, 1, 109.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (858, 3, 1987, 2, 109.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (859, 3, 1987, 3, 109.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (860, 3, 1987, 4, 109.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (861, 3, 1987, 5, 109.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (862, 3, 1987, 6, 109.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (863, 3, 1987, 7, 109.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (864, 3, 1987, 8, 110.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (865, 3, 1987, 9, 109.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (866, 3, 1987, 10, 110.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (867, 3, 1987, 11, 110.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (868, 3, 1987, 12, 110.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (869, 3, 1988, 1, 110.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (870, 3, 1988, 2, 111.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (871, 3, 1988, 3, 111.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (872, 3, 1988, 4, 111.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (873, 3, 1988, 5, 111.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (874, 3, 1988, 6, 111.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (875, 3, 1988, 7, 111.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (876, 3, 1988, 8, 111.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (877, 3, 1988, 9, 112.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (878, 3, 1988, 10, 112.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (879, 3, 1988, 11, 112.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (880, 3, 1988, 12, 112.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (881, 3, 1989, 1, 113.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (882, 3, 1989, 2, 113.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (883, 3, 1989, 3, 114.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (884, 3, 1989, 4, 114.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (885, 3, 1989, 5, 114.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (886, 3, 1989, 6, 115.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (887, 3, 1989, 7, 114.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (888, 3, 1989, 8, 115.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (889, 3, 1989, 9, 115.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (890, 3, 1989, 10, 116.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (891, 3, 1989, 11, 117.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (892, 3, 1989, 12, 118.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (893, 3, 1990, 1, 119.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (894, 3, 1990, 2, 119.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (895, 3, 1990, 3, 119.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (896, 3, 1990, 4, 120.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (897, 3, 1990, 5, 120.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (898, 3, 1990, 6, 120.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (899, 3, 1990, 7, 121.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (900, 3, 1990, 8, 122.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (901, 3, 1990, 9, 122.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (902, 3, 1990, 10, 123.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (903, 3, 1990, 11, 124.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (904, 3, 1990, 12, 124.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (905, 3, 1991, 1, 125.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (906, 3, 1991, 2, 126.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (907, 3, 1991, 3, 126.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (908, 3, 1991, 4, 127.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (909, 3, 1991, 5, 128.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (910, 3, 1991, 6, 128.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (911, 3, 1991, 7, 128.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (912, 3, 1991, 8, 129.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (913, 3, 1991, 9, 129.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (914, 3, 1991, 10, 129.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (915, 3, 1991, 11, 131.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (916, 3, 1991, 12, 131.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (917, 3, 1992, 1, 131.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (918, 3, 1992, 2, 132.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (919, 3, 1992, 3, 133.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (920, 3, 1992, 4, 133.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (921, 3, 1992, 5, 133.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (922, 3, 1992, 6, 134.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (923, 3, 1992, 7, 133.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (924, 3, 1992, 8, 134.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (925, 3, 1992, 9, 134.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (926, 3, 1992, 10, 134.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (927, 3, 1992, 11, 135.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (928, 3, 1992, 12, 135.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (929, 3, 1993, 1, 136.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (930, 3, 1993, 2, 137.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (931, 3, 1993, 3, 138.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (932, 3, 1993, 4, 138.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (933, 3, 1993, 5, 138.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (934, 3, 1993, 6, 138.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (935, 3, 1993, 7, 138.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (936, 3, 1993, 8, 139.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (937, 3, 1993, 9, 138.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (938, 3, 1993, 10, 139.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (939, 3, 1993, 11, 138.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (940, 3, 1993, 12, 139.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (941, 3, 1994, 1, 139.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (942, 3, 1994, 2, 139.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (943, 3, 1994, 3, 139.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (944, 3, 1994, 4, 139.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (945, 3, 1994, 5, 139.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (946, 3, 1994, 6, 139.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (947, 3, 1994, 7, 139.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (948, 3, 1994, 8, 139.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (949, 3, 1994, 9, 139.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (950, 3, 1994, 10, 139.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (951, 3, 1994, 11, 139.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (952, 3, 1994, 12, 139.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (953, 3, 1995, 1, 140.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (954, 3, 1995, 2, 141.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (955, 3, 1995, 3, 141.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (956, 3, 1995, 4, 142.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (957, 3, 1995, 5, 141.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (958, 3, 1995, 6, 142.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (959, 3, 1995, 7, 142.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (960, 3, 1995, 8, 142.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (961, 3, 1995, 9, 142.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (962, 3, 1995, 10, 142.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (963, 3, 1995, 11, 142.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (964, 3, 1995, 12, 142.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (965, 3, 1996, 1, 142.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (966, 3, 1996, 2, 143.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (967, 3, 1996, 3, 143.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (968, 3, 1996, 4, 143.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (969, 3, 1996, 5, 142.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (970, 3, 1996, 6, 143.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (971, 3, 1996, 7, 142.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (972, 3, 1996, 8, 143.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (973, 3, 1996, 9, 143.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (974, 3, 1996, 10, 143.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (975, 3, 1996, 11, 143.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (976, 3, 1996, 12, 143.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (977, 3, 1997, 1, 143.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (978, 3, 1997, 2, 144.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (979, 3, 1997, 3, 144.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (980, 3, 1997, 4, 144.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (981, 3, 1997, 5, 143.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (982, 3, 1997, 6, 143.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (983, 3, 1997, 7, 143.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (984, 3, 1997, 8, 144.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (985, 3, 1997, 9, 144.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (986, 3, 1997, 10, 144.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (987, 3, 1997, 11, 143.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (988, 3, 1997, 12, 144.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (989, 3, 1998, 1, 144.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (990, 3, 1998, 2, 144.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (991, 3, 1998, 3, 144.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (992, 3, 1998, 4, 144.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (993, 3, 1998, 5, 143.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (994, 3, 1998, 6, 144.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (995, 3, 1998, 7, 143.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (996, 3, 1998, 8, 144.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (997, 3, 1998, 9, 144.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (998, 3, 1998, 10, 144.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (999, 3, 1998, 11, 143.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1000, 3, 1998, 12, 143.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1001, 3, 1999, 1, 144.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1002, 3, 1999, 2, 144.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1003, 3, 1999, 3, 144.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1004, 3, 1999, 4, 144.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1005, 3, 1999, 5, 144.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1006, 3, 1999, 6, 144.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1007, 3, 1999, 7, 144.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1008, 3, 1999, 8, 145.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1009, 3, 1999, 9, 145.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1010, 3, 1999, 10, 145.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1011, 3, 1999, 11, 145.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1012, 3, 1999, 12, 146.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1013, 3, 2000, 1, 146.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1014, 3, 2000, 2, 146.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1015, 3, 2000, 3, 146.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1016, 3, 2000, 4, 147.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1017, 3, 2000, 5, 146.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1018, 3, 2000, 6, 147.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1019, 3, 2000, 7, 147.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1020, 3, 2000, 8, 147.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1021, 3, 2000, 9, 147.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1022, 3, 2000, 10, 147.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1023, 3, 2000, 11, 148.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1024, 3, 2000, 12, 148.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1025, 3, 2001, 1, 148.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1026, 3, 2001, 2, 148.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1027, 3, 2001, 3, 148.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1028, 3, 2001, 4, 148.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1029, 3, 2001, 5, 149.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1030, 3, 2001, 6, 149.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1031, 3, 2001, 7, 149.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1032, 3, 2001, 8, 148.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1033, 3, 2001, 9, 148.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1034, 3, 2001, 10, 148.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1035, 3, 2001, 11, 148.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1036, 3, 2001, 12, 148.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1037, 3, 2002, 1, 149.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1038, 3, 2002, 2, 149.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1039, 3, 2002, 3, 149.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1040, 3, 2002, 4, 150.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1041, 3, 2002, 5, 150.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1042, 3, 2002, 6, 150.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1043, 3, 2002, 7, 149.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1044, 3, 2002, 8, 149.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1045, 3, 2002, 9, 149.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1046, 3, 2002, 10, 150.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1047, 3, 2002, 11, 150.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1048, 3, 2002, 12, 150.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1049, 3, 2003, 1, 150.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1050, 3, 2003, 2, 150.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1051, 3, 2003, 3, 151.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1052, 3, 2003, 4, 151.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1053, 3, 2003, 5, 151.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1054, 3, 2003, 6, 151.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1055, 3, 2003, 7, 149.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1056, 3, 2003, 8, 150.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1057, 3, 2003, 9, 150.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1058, 3, 2003, 10, 151.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1059, 3, 2003, 11, 151.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1060, 3, 2003, 12, 151.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1061, 3, 2004, 1, 150.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1062, 3, 2004, 2, 150.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1063, 3, 2004, 3, 150.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1064, 3, 2004, 4, 152.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1065, 3, 2004, 5, 152.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1066, 3, 2004, 6, 152.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1067, 3, 2004, 7, 151.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1068, 3, 2004, 8, 151.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1069, 3, 2004, 9, 151.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1070, 3, 2004, 10, 153.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1071, 3, 2004, 11, 153.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1072, 3, 2004, 12, 153.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1073, 3, 2005, 1, 152.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1074, 3, 2005, 2, 152.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1075, 3, 2005, 3, 153.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1076, 3, 2005, 4, 154.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1077, 3, 2005, 5, 154.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1078, 3, 2005, 6, 153.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1079, 3, 2005, 7, 153.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1080, 3, 2005, 8, 153.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1081, 3, 2005, 9, 153.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1082, 3, 2005, 10, 155.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1083, 3, 2005, 11, 154.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1084, 3, 2005, 12, 154.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1085, 3, 2006, 1, 154.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1086, 3, 2006, 2, 154.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1087, 3, 2006, 3, 154.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1088, 3, 2006, 4, 155.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1089, 3, 2006, 5, 156.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1090, 3, 2006, 6, 156.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1091, 3, 2006, 7, 155.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1092, 3, 2006, 8, 155.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1093, 3, 2006, 9, 155.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1094, 3, 2006, 10, 155.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1095, 3, 2006, 11, 155.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1096, 3, 2006, 12, 155.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1097, 3, 2007, 1, 154.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1098, 3, 2007, 2, 154.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1099, 3, 2007, 3, 154.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1100, 3, 2007, 4, 156.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1101, 3, 2007, 5, 157.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1102, 3, 2007, 6, 157.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1103, 3, 2007, 7, 156.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1104, 3, 2007, 8, 156.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1105, 3, 2007, 9, 156.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1106, 3, 2007, 10, 157.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1107, 3, 2007, 11, 158.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1108, 3, 2007, 12, 158.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1109, 3, 2008, 1, 158.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1110, 3, 2008, 2, 158.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1111, 3, 2008, 3, 159.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1112, 3, 2008, 4, 160.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1113, 3, 2008, 5, 161.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1114, 3, 2008, 6, 161.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1115, 3, 2008, 7, 161.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1116, 3, 2008, 8, 160.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1117, 3, 2008, 9, 160.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1118, 3, 2008, 10, 161.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1119, 3, 2008, 11, 160.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1120, 3, 2008, 12, 159.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1121, 3, 2009, 1, 158.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1122, 3, 2009, 2, 158.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1123, 3, 2009, 3, 158.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1124, 3, 2009, 4, 159.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1125, 3, 2009, 5, 159.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1126, 3, 2009, 6, 160.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1127, 3, 2009, 7, 159.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1128, 3, 2009, 8, 159.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1129, 3, 2009, 9, 159.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1130, 3, 2009, 10, 160.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1131, 3, 2009, 11, 160.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1132, 3, 2009, 12, 160.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1133, 3, 2010, 11, 161.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1134, 4, 1993, 1, 98.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1135, 4, 1993, 2, 99.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1136, 4, 1993, 3, 99.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1137, 4, 1993, 4, 99.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1138, 4, 1993, 5, 100.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1139, 4, 1993, 6, 100.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1140, 4, 1993, 7, 99.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1141, 4, 1993, 8, 100.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1142, 4, 1993, 9, 100.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1143, 4, 1993, 10, 100.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1144, 4, 1993, 11, 100.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1145, 4, 1993, 12, 100.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1146, 4, 1994, 1, 100.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1147, 4, 1994, 2, 100.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1148, 4, 1994, 3, 100.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1149, 4, 1994, 4, 101.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1150, 4, 1994, 5, 100.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1151, 4, 1994, 6, 100.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1152, 4, 1994, 7, 100.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1153, 4, 1994, 8, 100.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1154, 4, 1994, 9, 100.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1155, 4, 1994, 10, 100.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1156, 4, 1994, 11, 100.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1157, 4, 1994, 12, 100.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1158, 4, 1995, 1, 101.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1159, 4, 1995, 2, 102.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1160, 4, 1995, 3, 102.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1161, 4, 1995, 4, 102.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1162, 4, 1995, 5, 102.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1163, 4, 1995, 6, 102.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1164, 4, 1995, 7, 102.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1165, 4, 1995, 8, 102.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1166, 4, 1995, 9, 103.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1167, 4, 1995, 10, 102.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1168, 4, 1995, 11, 102.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1169, 4, 1995, 12, 102.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1170, 4, 1996, 1, 103.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1171, 4, 1996, 2, 103.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1172, 4, 1996, 3, 103.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1173, 4, 1996, 4, 103.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1174, 4, 1996, 5, 103.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1175, 4, 1996, 6, 103.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1176, 4, 1996, 7, 103.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1177, 4, 1996, 8, 103.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1178, 4, 1996, 9, 103.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1179, 4, 1996, 10, 103.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1180, 4, 1996, 11, 103.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1181, 4, 1996, 12, 103.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1182, 4, 1997, 1, 103.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1183, 4, 1997, 2, 104.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1184, 4, 1997, 3, 104.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1185, 4, 1997, 4, 104.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1186, 4, 1997, 5, 103.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1187, 4, 1997, 6, 103.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1188, 4, 1997, 7, 103.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1189, 4, 1997, 8, 104.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1190, 4, 1997, 9, 104.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1191, 4, 1997, 10, 104.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1192, 4, 1997, 11, 103.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1193, 4, 1997, 12, 104.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1194, 4, 1998, 1, 104.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1195, 4, 1998, 2, 104.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1196, 4, 1998, 3, 104.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1197, 4, 1998, 4, 104.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1198, 4, 1998, 5, 103.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1199, 4, 1998, 6, 104.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1200, 4, 1998, 7, 103.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1201, 4, 1998, 8, 104.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1202, 4, 1998, 9, 104.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1203, 4, 1998, 10, 104.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1204, 4, 1998, 11, 103.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1205, 4, 1998, 12, 103.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1206, 4, 1999, 1, 104.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1207, 4, 1999, 2, 104.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1208, 4, 1999, 3, 104.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1209, 4, 1999, 4, 104.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1210, 4, 1999, 5, 104.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1211, 4, 1999, 6, 104.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1212, 4, 1999, 7, 104.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1213, 4, 1999, 8, 105.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1214, 4, 1999, 9, 105.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1215, 4, 1999, 10, 105.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1216, 4, 1999, 11, 105.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1217, 4, 1999, 12, 105.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1218, 4, 2000, 1, 105.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1219, 4, 2000, 2, 106.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1220, 4, 2000, 3, 106.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1221, 4, 2000, 4, 106.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1222, 4, 2000, 5, 106.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1223, 4, 2000, 6, 106.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1224, 4, 2000, 7, 106.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1225, 4, 2000, 8, 106.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1226, 4, 2000, 9, 106.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1227, 4, 2000, 10, 106.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1228, 4, 2000, 11, 107.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1229, 4, 2000, 12, 107.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1230, 4, 2001, 1, 107.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1231, 4, 2001, 2, 106.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1232, 4, 2001, 3, 107.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1233, 4, 2001, 4, 107.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1234, 4, 2001, 5, 108.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1235, 4, 2001, 6, 108.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1236, 4, 2001, 7, 108.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1237, 4, 2001, 8, 107.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1238, 4, 2001, 9, 107.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1239, 4, 2001, 10, 107.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1240, 4, 2001, 11, 107.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1241, 4, 2001, 12, 107.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1242, 4, 2002, 1, 107.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1243, 4, 2002, 2, 107.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1244, 4, 2002, 3, 107.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1245, 4, 2002, 4, 108.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1246, 4, 2002, 5, 108.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1247, 4, 2002, 6, 108.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1248, 4, 2002, 7, 107.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1249, 4, 2002, 8, 107.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1250, 4, 2002, 9, 108.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1251, 4, 2002, 10, 108.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1252, 4, 2002, 11, 108.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1253, 4, 2002, 12, 108.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1254, 4, 2003, 1, 108.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1255, 4, 2003, 2, 108.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1256, 4, 2003, 3, 109.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1257, 4, 2003, 4, 109.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1258, 4, 2003, 5, 109.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1259, 4, 2003, 6, 109.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1260, 4, 2003, 7, 108.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1261, 4, 2003, 8, 108.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1262, 4, 2003, 9, 108.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1263, 4, 2003, 10, 109.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1264, 4, 2003, 11, 109.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1265, 4, 2003, 12, 109.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1266, 4, 2004, 1, 108.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1267, 4, 2004, 2, 108.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1268, 4, 2004, 3, 109.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1269, 4, 2004, 4, 109.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1270, 4, 2004, 5, 110.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1271, 4, 2004, 6, 110.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1272, 4, 2004, 7, 109.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1273, 4, 2004, 8, 109.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1274, 4, 2004, 9, 109.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1275, 4, 2004, 10, 110.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1276, 4, 2004, 11, 110.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1277, 4, 2004, 12, 110.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1278, 4, 2005, 1, 110.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1279, 4, 2005, 2, 110.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1280, 4, 2005, 3, 110.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1281, 4, 2005, 4, 111.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1282, 4, 2005, 5, 111.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1283, 4, 2005, 6, 111.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1284, 4, 2005, 7, 110.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1285, 4, 2005, 8, 110.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1286, 4, 2005, 9, 111.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1287, 4, 2005, 10, 112.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1288, 4, 2005, 11, 111.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1289, 4, 2005, 12, 111.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1290, 4, 2006, 1, 111.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1291, 4, 2006, 2, 111.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1292, 4, 2006, 3, 111.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1293, 4, 2006, 4, 112.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1294, 4, 2006, 5, 112.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1295, 4, 2006, 6, 112.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1296, 4, 2006, 7, 112.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1297, 4, 2006, 8, 112.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1298, 4, 2006, 9, 112.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1299, 4, 2006, 10, 112.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1300, 4, 2006, 11, 112.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1301, 4, 2006, 12, 112.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1302, 4, 2007, 1, 111.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1303, 4, 2007, 2, 111.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1304, 4, 2007, 3, 111.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1305, 4, 2007, 4, 113.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1306, 4, 2007, 5, 113.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1307, 4, 2007, 6, 113.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1308, 4, 2007, 7, 112.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1309, 4, 2007, 8, 112.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1310, 4, 2007, 9, 112.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1311, 4, 2007, 10, 113.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1312, 4, 2007, 11, 114.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1313, 4, 2007, 12, 114.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1314, 4, 2008, 1, 114.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1315, 4, 2008, 2, 114.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1316, 4, 2008, 3, 114.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1317, 4, 2008, 4, 115.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1318, 4, 2008, 5, 116.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1319, 4, 2008, 6, 116.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1320, 4, 2008, 7, 116.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1321, 4, 2008, 8, 116.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1322, 4, 2008, 9, 116.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1323, 4, 2008, 10, 116.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1324, 4, 2008, 11, 116.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1325, 4, 2008, 12, 115.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1326, 4, 2009, 1, 114.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1327, 4, 2009, 2, 114.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1328, 4, 2009, 3, 114.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1329, 4, 2009, 4, 115.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1330, 4, 2009, 5, 115.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1331, 4, 2009, 6, 115.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1332, 4, 2009, 7, 114.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1333, 4, 2009, 8, 115.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1334, 4, 2009, 9, 115.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1335, 4, 2009, 10, 115.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1336, 4, 2009, 11, 116.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1337, 4, 2009, 12, 115.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1338, 4, 2010, 11, 116.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1339, 5, 2000, 1, 99.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1340, 5, 2000, 2, 100.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1341, 5, 2000, 3, 100.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1342, 5, 2000, 4, 100.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1343, 5, 2000, 5, 100.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1344, 5, 2000, 6, 100.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1345, 5, 2000, 7, 100.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1346, 5, 2000, 8, 100.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1347, 5, 2000, 9, 100.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1348, 5, 2000, 10, 100.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1349, 5, 2000, 11, 101.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1350, 5, 2000, 12, 101.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1351, 5, 2001, 1, 100.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1352, 5, 2001, 2, 100.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1353, 5, 2001, 3, 100.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1354, 5, 2001, 4, 101.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1355, 5, 2001, 5, 101.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1356, 5, 2001, 6, 102.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1357, 5, 2001, 7, 101.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1358, 5, 2001, 8, 101.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1359, 5, 2001, 9, 101.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1360, 5, 2001, 10, 101.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1361, 5, 2001, 11, 101.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1362, 5, 2001, 12, 101.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1363, 5, 2002, 1, 101.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1364, 5, 2002, 2, 101.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1365, 5, 2002, 3, 101.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1366, 5, 2002, 4, 102.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1367, 5, 2002, 5, 102.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1368, 5, 2002, 6, 102.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1369, 5, 2002, 7, 101.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1370, 5, 2002, 8, 101.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1371, 5, 2002, 9, 101.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1372, 5, 2002, 10, 102.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1373, 5, 2002, 11, 102.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1374, 5, 2002, 12, 102.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1375, 5, 2003, 1, 102.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1376, 5, 2003, 2, 102.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1377, 5, 2003, 3, 102.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1378, 5, 2003, 4, 103.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1379, 5, 2003, 5, 102.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1380, 5, 2003, 6, 102.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1381, 5, 2003, 7, 102.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1382, 5, 2003, 8, 102.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1383, 5, 2003, 9, 102.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1384, 5, 2003, 10, 102.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1385, 5, 2003, 11, 102.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1386, 5, 2003, 12, 102.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1387, 5, 2004, 1, 102.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1388, 5, 2004, 2, 102.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1389, 5, 2004, 3, 102.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1390, 5, 2004, 4, 103.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1391, 5, 2004, 5, 103.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1392, 5, 2004, 6, 104.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1393, 5, 2004, 7, 102.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1394, 5, 2004, 8, 103.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1395, 5, 2004, 9, 103.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1396, 5, 2004, 10, 104.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1397, 5, 2004, 11, 104.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1398, 5, 2004, 12, 104.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1399, 5, 2005, 1, 103.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1400, 5, 2005, 2, 103.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1401, 5, 2005, 3, 104.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1402, 5, 2005, 4, 105.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1403, 5, 2005, 5, 104.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1404, 5, 2005, 6, 104.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1405, 5, 2005, 7, 104.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1406, 5, 2005, 8, 104.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1407, 5, 2005, 9, 104.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1408, 5, 2005, 10, 105.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1409, 5, 2005, 11, 105.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1410, 5, 2005, 12, 105.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1411, 5, 2006, 1, 105.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1412, 5, 2006, 2, 105.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1413, 5, 2006, 3, 105.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1414, 5, 2006, 4, 106.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1415, 5, 2006, 5, 106.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1416, 5, 2006, 6, 106.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1417, 5, 2006, 7, 105.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1418, 5, 2006, 8, 105.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1419, 5, 2006, 9, 105.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1420, 5, 2006, 10, 105.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1421, 5, 2006, 11, 105.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1422, 5, 2006, 12, 105.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1423, 5, 2007, 1, 105.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1424, 5, 2007, 2, 105.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1425, 5, 2007, 3, 105.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1426, 5, 2007, 4, 106.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1427, 5, 2007, 5, 106.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1428, 5, 2007, 6, 107.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1429, 5, 2007, 7, 106.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1430, 5, 2007, 8, 106.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1431, 5, 2007, 9, 106.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1432, 5, 2007, 10, 107.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1433, 5, 2007, 11, 107.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1434, 5, 2007, 12, 108.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1435, 5, 2008, 1, 107.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1436, 5, 2008, 2, 107.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1437, 5, 2008, 3, 108.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1438, 5, 2008, 4, 109.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1439, 5, 2008, 5, 109.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1440, 5, 2008, 6, 110.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1441, 5, 2008, 7, 109.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1442, 5, 2008, 8, 109.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1443, 5, 2008, 9, 109.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1444, 5, 2008, 10, 110.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1445, 5, 2008, 11, 109.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1446, 5, 2008, 12, 108.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1447, 5, 2009, 1, 107.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1448, 5, 2009, 2, 108.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1449, 5, 2009, 3, 107.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1450, 5, 2009, 4, 108.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1451, 5, 2009, 5, 108.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1452, 5, 2009, 6, 109.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1453, 5, 2009, 7, 108.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1454, 5, 2009, 8, 108.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1455, 5, 2009, 9, 108.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1456, 5, 2009, 10, 109.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1457, 5, 2009, 11, 109.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1458, 5, 2009, 12, 109.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1459, 5, 2010, 11, 109.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1460, 6, 2005, 1, 98.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1461, 6, 2005, 2, 98.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1462, 6, 2005, 3, 99.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1463, 6, 2005, 4, 99.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1464, 6, 2005, 5, 99.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1465, 6, 2005, 6, 99.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1466, 6, 2005, 7, 98.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1467, 6, 2005, 8, 99.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1468, 6, 2005, 9, 99.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1469, 6, 2005, 10, 100.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1470, 6, 2005, 11, 100.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1471, 6, 2005, 12, 100.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1472, 6, 2006, 1, 99.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1473, 6, 2006, 2, 100.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1474, 6, 2006, 3, 100.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1475, 6, 2006, 4, 100.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1476, 6, 2006, 5, 101.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1477, 6, 2006, 6, 101.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1478, 6, 2006, 7, 100.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1479, 6, 2006, 8, 100.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1480, 6, 2006, 9, 100.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1481, 6, 2006, 10, 100.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1482, 6, 2006, 11, 100.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1483, 6, 2006, 12, 100.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1484, 6, 2007, 1, 99.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1485, 6, 2007, 2, 100.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1486, 6, 2007, 3, 100.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1487, 6, 2007, 4, 101.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1488, 6, 2007, 5, 101.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1489, 6, 2007, 6, 101.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1490, 6, 2007, 7, 101.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1491, 6, 2007, 8, 101.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1492, 6, 2007, 9, 101.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1493, 6, 2007, 10, 101.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1494, 6, 2007, 11, 102.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1495, 6, 2007, 12, 102.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1496, 6, 2008, 1, 102.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1497, 6, 2008, 2, 102.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1498, 6, 2008, 3, 102.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1499, 6, 2008, 4, 103.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1500, 6, 2008, 5, 104.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1501, 6, 2008, 6, 104.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1502, 6, 2008, 7, 104.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1503, 6, 2008, 8, 103.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1504, 6, 2008, 9, 104.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1505, 6, 2008, 10, 104.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1506, 6, 2008, 11, 103.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1507, 6, 2008, 12, 103.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1508, 6, 2009, 1, 102.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1509, 6, 2009, 2, 102.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1510, 6, 2009, 3, 102.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1511, 6, 2009, 4, 103.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1512, 6, 2009, 5, 103.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1513, 6, 2009, 6, 103.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1514, 6, 2009, 7, 103.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1515, 6, 2009, 8, 103.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1516, 6, 2009, 9, 103.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1517, 6, 2009, 10, 103.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1518, 6, 2009, 11, 103.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1519, 6, 2009, 12, 103.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1520, 6, 2010, 11, 104.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-07 16:47:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1521, 7, 2011, 1, 99.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-20 13:34:45', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-20 13:34:45', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1522, 7, 2011, 2, 100.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-20 13:35:02', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-20 13:35:02', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1523, 7, 2011, 3, 100.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-20 13:35:13', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-20 13:35:13', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1524, 7, 2011, 4, 100.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-20 13:35:24', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-20 13:35:24', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1525, 7, 2011, 5, 100.8000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-20 13:35:37', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-20 13:35:37', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1526, 7, 2011, 6, 100.5000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-20 13:35:46', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-20 13:35:46', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1527, 7, 2011, 7, 99.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-20 13:36:06', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-20 13:36:06', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1528, 7, 2011, 8, 99.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-20 13:36:15', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-20 13:36:15', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1529, 7, 2011, 9, 99.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-20 13:36:27', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-10-20 13:36:27', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1530, 1, 2011, 11, 336.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-11-02 14:53:02', 120) ,  N'Kilchhofer, Véronique (2407)' ,  CONVERT(DATETIME, '2011-12-06 14:21:28', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1531, 2, 2011, 11, 199.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-11-02 14:53:27', 120) ,  N'Kilchhofer, Véronique (2407)' ,  CONVERT(DATETIME, '2011-12-06 14:21:17', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1532, 3, 2011, 11, 160.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-11-02 14:54:25', 120) ,  N'Kilchhofer, Véronique (2407)' ,  CONVERT(DATETIME, '2011-12-06 14:21:10', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1533, 4, 2011, 11, 115.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-11-02 14:55:34', 120) ,  N'Kilchhofer, Véronique (2407)' ,  CONVERT(DATETIME, '2011-12-06 14:21:00', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1534, 5, 2011, 11, 109.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-11-02 14:55:54', 120) ,  N'Kilchhofer, Véronique (2407)' ,  CONVERT(DATETIME, '2011-12-06 14:22:04', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1535, 6, 2011, 11, 103.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-11-02 14:56:09', 120) ,  N'Kilchhofer, Véronique (2407)' ,  CONVERT(DATETIME, '2011-12-06 14:22:14', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1536, 7, 2011, 11, 99.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-11-02 14:56:37', 120) ,  N'Kilchhofer, Véronique (2407)' ,  CONVERT(DATETIME, '2011-12-06 14:13:40', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1537, 7, 2011, 10, 99.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-11-03 11:46:19', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-11-08 08:58:28', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1538, 7, 2010, 11, 100.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2011-11-08 08:57:43', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2011-11-08 08:57:43', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1539, 1, 2012, 11, 335.4000,  N'System (2290)' ,  CONVERT(DATETIME, '2012-12-06 11:10:52', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2012-12-06 11:10:52', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1540, 2, 2012, 11, 198.9000,  N'System (2290)' ,  CONVERT(DATETIME, '2012-12-06 11:10:53', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2012-12-06 11:10:53', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1541, 3, 2012, 11, 159.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2012-12-06 11:10:53', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2012-12-06 11:10:53', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1542, 4, 2012, 11, 115.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2012-12-06 11:10:53', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2012-12-06 11:10:53', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1543, 5, 2012, 11, 108.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2012-12-06 11:10:53', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2012-12-06 11:10:53', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1544, 6, 2012, 11, 103.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2012-12-06 11:10:53', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2012-12-06 11:10:53', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1545, 7, 2012, 11, 99.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2012-12-06 11:10:53', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2012-12-06 11:10:53', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1546, 1, 2013, 11, 335.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2013-11-12 12:08:04', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2013-11-12 12:08:04', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1547, 2, 2013, 11, 199.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2013-11-12 12:08:04', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2013-11-12 12:08:04', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1548, 3, 2013, 11, 159.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2013-11-12 12:08:04', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2013-11-12 12:08:04', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1549, 4, 2013, 11, 115.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2013-11-12 12:08:04', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2013-11-12 12:08:04', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1550, 5, 2013, 11, 108.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2013-11-12 12:08:04', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2013-11-12 12:08:04', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1551, 6, 2013, 11, 103.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2013-11-12 12:08:04', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2013-11-12 12:08:04', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1552, 7, 2013, 11, 99.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2013-11-12 12:08:04', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2013-11-12 12:08:04', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1553, 1, 2013, 12, 335.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2013-12-06 10:03:52', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2013-12-06 10:03:52', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1560, 3, 2014, 11, 159.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2014-12-08 10:05:54', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2014-12-08 10:06:15', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1561, 4, 2014, 11, 115.3000,  N'System (2290)' ,  CONVERT(DATETIME, '2014-12-08 10:06:22', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2014-12-08 10:06:34', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1562, 5, 2014, 11, 108.6000,  N'System (2290)' ,  CONVERT(DATETIME, '2014-12-08 10:06:39', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2014-12-08 10:06:52', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1563, 6, 2014, 11, 103.2000,  N'System (2290)' ,  CONVERT(DATETIME, '2014-12-08 10:06:56', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2014-12-08 10:07:08', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1564, 7, 2014, 11, 99.1000,  N'System (2290)' ,  CONVERT(DATETIME, '2014-12-08 10:07:14', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2014-12-08 10:07:26', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1565, 2, 2014, 11, 199.0000,  N'System (2290)' ,  CONVERT(DATETIME, '2014-12-09 06:20:07', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2014-12-09 06:20:35', 120) )
--SQLCHECK_IGNORE--
INSERT [IkLandesindexWert]([IkLandesindexWertID], [IkLandesindexID], [Jahr], [Monat], [Wert], [Creator], [Created], [Modifier], [Modified])
values (1566, 1, 2014, 11, 335.7000,  N'System (2290)' ,  CONVERT(DATETIME, '2014-12-09 07:59:08', 120) ,  N'System (2290)' ,  CONVERT(DATETIME, '2014-12-09 07:59:23', 120) )
set identity_insert IkLandesindexWert off
COMMIT
GO










