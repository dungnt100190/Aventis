-------------------------------------------------------------------------------
-- XDeleteRule abfüllen
-------------------------------------------------------------------------------
SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XDeleteRule]
GO
DECLARE @CreatorModifier VARCHAR(50);
SELECT @CreatorModifier = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID());

INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BaAdresse', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BaAdresse', N'VmMandantID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BaGesundheit', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BaArbeitAusbildung', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BaKopfquote', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BaMietvertrag', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BaPerson_BaInstitution', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BaPerson_Relation', N'BaPersonID_1', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BaPerson_Relation', N'BaPersonID_2', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BaRechnungsadresse', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BaWVCode', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BFSDossier', N'FaLeistungID', 2, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BFSDossierPerson', N'BaPersonID', 2, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'DynaValue', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'DynaValue', N'FaPhaseID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaAbmachungen', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaAktennotizen', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaAktennotizen', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaDokumentAblage_BaPerson', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaDokumentAblage_BaPerson', N'FaDokumentAblageID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaDokumentAblage', N'DocumentID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaDokumentAblage', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaDokumente', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaDokumente', N'BaPersonID_LT', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaDokumente', N'BaPersonID_Adressat', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaDokumente', N'DocumentID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaDokumente', N'DocumentID_Merkblatt', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaLeistungArchiv', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaLeistungBewertung', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaLeistungUserHist', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaLeistungZugriff', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaPhase', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaWeisung_BaPerson', N'FaWeisungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaWeisung_BaPerson', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaWeisungProtokoll', N'FaWeisungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaZeitlichePlanung', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaWeisung', N'XDocumentID_Mahnung1', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaWeisung', N'XDocumentID_Mahnung2', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaWeisung', N'XDocumentID_Mahnung3', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaWeisung', N'XDocumentID_Verfuegung', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaWeisung', N'XDocumentID_Weisung', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaWeisung', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkAnzeige', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkAbklaerung', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkBetreibungAusgleich', N'IkBetreibungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkBetreibung', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkBetreibung', N'IkRechtstitelID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkForderungPosition', N'IkForderungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkForderungPosition', N'IkPositionID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkForderung', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkForderung', N'IkRechtstitelID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkForderung', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkForderung_BgKostenart', N'BgKostenartID_Auszahlung', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkForderung_BgKostenart', N'BgKostenartID_Forderung', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkForderungBgKostenartHist', N'BgKostenartID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkGlaeubiger', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkGlaeubiger', N'IkRechtstitelID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkGlaeubiger', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkGlaeubiger', N'BaZahlungswegID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkRatenplan', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkRatenplanForderung', N'IkRechtstitelID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkRatenplanForderung', N'IkRatenplanID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkRatenplanForderung', N'IkPositionID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkRatenplanForderung', N'IkForderungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkVerrechnungskonto', N'IkRechtstitelID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkVerrechnungskonto', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkRechtstitel', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkRechtstitel', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgAuszahlungPersonTermin', N'BgAuszahlungPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgAuszahlungPerson', N'BgPositionID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgAuszahlungPerson', N'BgZahlungsmodusID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgAuszahlungPerson', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgAuszahlungPerson', N'BaZahlungswegID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgBewilligung', N'BgFinanzplanID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgBewilligung', N'BgBudgetID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgBewilligung', N'BgPositionID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgDokument', N'BgDokumentID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgDokument', N'BgFinanzplanID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgDokument', N'BgBudgetID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgDokument', N'BgPositionID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgDokument', N'DocumentID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'KbBuchungKostenart', N'BaPersonID', 2, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'KbBuchungKostenart', N'BgPositionID', 2, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'KbBuchung', N'BaZahlungswegID', 2, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'KbBuchung', N'BgBudgetID', 2, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'KbBuchung', N'KbKostenstelleID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'KbBuchung', N'IkPositionID', 2, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'KbBuchung', N'Schuldner_BaPersonID', 2, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'KbBuchung', N'FaLeistungID', 2, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'KbKostenstelle_BaPerson', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'KbKostenstelle', N'KbKostenstelleID', 2, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'KbZahlungseingang', N'BaPersonID', 2, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkPosition', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkPosition', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkPosition', N'IkRechtstitelID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgPosition', N'BgPositionID_AutoForderung', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgPosition', N'BgPositionID_Parent', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgPosition', N'BgPositionID_CopyOf', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgPosition', N'BgBudgetID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgPosition', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgPosition', N'DebitorBaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgPosition', N'BgSpezkontoID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgBudget', N'BgFinanzplanID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgFinanzplan_BaPerson', N'BgFinanzplanID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgFinanzplan_BaPerson', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgFinanzplan_BaPerson', N'BaZahlungswegID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgFinanzplan_BaPerson', N'KbKostenstelleID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgFinanzplan_BaPerson', N'KbKostenstelleID_KVG', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgFinanzplan', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgSpezkontoAbschluss', N'BgSpezkontoID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgSpezkonto', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgSpezkonto', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgZahlungsmodusTermin', N'BgZahlungsmodusID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgZahlungsmodus', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgZahlungsmodus', N'BaZahlungswegID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BaZahlungsweg', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'SstASVSExport_Eintrag', N'WhASVSEintragID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'WhASVSEintrag', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'WhASVSEintrag', N'FaLeistungID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'XTask', N'BaPersonID', 2, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'XTask', N'FaLeistungID', 2, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaLeistung', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaLeistung', N'SchuldnerBaPersonID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BaPerson', N'BaPersonID', 1, @CreatorModifier, @CreatorModifier)

INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BaAdresse', N'UserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BFSDossier', N'UserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgBewilligung', N'UserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgBewilligung', N'UserID_An', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgBewilligung', N'UserID_Zustaendig', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgPosition', N'ErstelltUserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'BgPosition', N'MutiertUserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaAktennotizen', N'UserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaDokumentAblage', N'UserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaDokumente', N'UserID_Absender', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaDokumente', N'UserID_EkVisumUser', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaDokumente', N'UserID_VisiertDurch', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaDokumente', N'UserID_VisumBeantragtBei', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaDokumente', N'UserID_VisumBeantragtDurch', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaLeistung', N'SachbearbeiterID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaLeistung', N'UserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaLeistungArchiv', N'CheckInUserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaLeistungArchiv', N'CheckOutUserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaLeistungBewertung', N'UserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaLeistungUserHist', N'UserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaLeistungZugriff', N'UserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaPendenzgruppe_User', N'UserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaPhase', N'UserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaWeisung', N'UserID_Creator', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaWeisung', N'UserID_VerantwortlichRD', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'FaWeisung', N'UserID_VerantwortlichSAR', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'IkAbklaerung', N'UserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'KbBuchung', N'BarbelegUserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'KbBuchung', N'ErstelltUserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'KbBuchung', N'MutiertUserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'KbPeriode_User', N'UserID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'KbWVLauf', N'UserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'KbZahlungseingang', N'ErstelltUserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'KbZahlungseingang', N'MutiertUserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'KbZahlungseingang', N'ZugeteiltUserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'KbZahlungslauf', N'UserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'XDocTemplate', N'CheckOut_UserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'XOrgUnit', N'ChiefID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'XOrgUnit', N'RechtsdienstUserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'XOrgUnit', N'RepresentativeID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'XOrgUnit_User', N'UserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'XSearchControlTemplate', N'UserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'XTask', N'UserID_Erledigt', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'XTask', N'UserID_InBearbeitung', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'XUser', N'ChiefID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'XUser', N'PrimaryUserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'XUser', N'SachbearbeiterID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'XUser_Archive', N'UserID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'XUser_UserGroup', N'UserID', 1, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'XUser_XDocTemplate', N'UserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'XUserStundenansatz', N'UserID', 4, @CreatorModifier, @CreatorModifier)
INSERT INTO [XDeleteRule] ([TableName], [ColumnName], [XDeleteRuleCode], [Creator], [Modifier]) VALUES (N'XUser', N'UserID', 1, @CreatorModifier, @CreatorModifier)
GO
SET IDENTITY_INSERT [XDeleteRule] OFF
GO
COMMIT
GO


-------------------------------------------------------------------------------
-- SP erstellen
-------------------------------------------------------------------------------

EXEC dbo.spDropObject spXGetDeleteStatements;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description: Generiert DELETE-Statements (abhängige Daten werden gelöscht/FK=NULL gesetzt,
                                            bestimmt durch die Daten in XDeleteRule)
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @PkTableName: Name der Tabelle der zu löschenden Daten (Default: BaPerson).
    @PkTableId: ID des zu löschenden Datensatzes.
    @DefaultDeleteRuleCode: Aktion, falls nichts in XDeleteRule angegeben (LOV XDeleteRule).
  -
  RETURNS: Eine Liste von DELETE-Statements.
  -
  TEST: EXEC dbo.spXGetDeleteStatements 'BaPerson', '1', 0;

=================================================================================================*/
CREATE PROCEDURE dbo.spXGetDeleteStatements
(
  @PkTableName VARCHAR(128),
  @PkTableId VARCHAR(50),
  @DefaultDeleteRuleCode INT = 0,
  @ReplacementId VARCHAR(50) = NULL
)
AS BEGIN
  -- XDeleteRuleCode
  -- 0: No Action
  -- 1: Cascade
  -- 2: Set to @ReplacementId (default = NULL)
  -- 3: Set default --> NOT IMPLEMENTED
  -- 4: Set to @ReplacementId

  --PRINT('PkTableName: ' + @PkTableName);
  --PRINT('PkTableId: ' + CONVERT(VARCHAR, @PkTableId));
  --PRINT('DefaultDeleteRuleCode: ' + CONVERT(VARCHAR, @DefaultDeleteRuleCode));
  --PRINT('ReplacementId: ' + CONVERT(VARCHAR, @ReplacementId));

  DECLARE @ReplacementString NVARCHAR(32);
  SET @ReplacementString = ISNULL(CONVERT(NVARCHAR(32), @ReplacementId), 'NULL');

  CREATE TABLE #EntriesToDelete
  (
    ID INT IDENTITY (1,1) NOT NULL,
    PkTableName     VARCHAR(128),
    PkColumnName    VARCHAR(128),
    PkTableObjectId INT,
    PkColumnId      INT,
    FkTableName     VARCHAR(128),
    FkColumnName    VARCHAR(128),
    FkTableObjectId INT,
    FkColumnId      INT,
    FkName          VARCHAR(128),
    FkObjectId      INT,
    tableLevel      INT,
    fkPath          VARCHAR(MAX),
    XDeleteRuleCode INT,
    SqlSelectPkIds  VARCHAR(MAX),
    SqlDeleteAction VARCHAR(MAX),
    CONSTRAINT [PK_EntriesToDelete] PRIMARY KEY CLUSTERED (ID)
  );

  ;WITH FKTmp
  AS
  (
    -- select all FK from other tables that uses BaPerson
    SELECT
      PkTableName     = OBJECT_NAME(FKC.referenced_object_id),
      PkColumnName    = COLPK.name,
      PkTableObjectId = FKC.referenced_object_id,
      PkColumnId      = FKC.referenced_column_id,
      FkTableName     = OBJECT_NAME(FKC.parent_object_id),
      FkColumnName    = COLFK.name,
      FkTableObjectId = FKC.parent_object_id,
      FkColumnId      = FKC.parent_column_id,
      FkName          = OBJECT_NAME(FKC.constraint_object_id),
      FkObjectId      = FKC.constraint_object_id,
      tableLevel      = 1,
      fkPath          = CONVERT(VARCHAR(MAX), OBJECT_NAME(FKC.referenced_object_id)) + '.' + COLPK.name + '/' + OBJECT_NAME(FKC.parent_object_id) + '.' + COLFK.name,
      XDeleteRuleCode = ISNULL(DAC.XDeleteRuleCode, @DefaultDeleteRuleCode),
      SqlSelectPkIds  = CONVERT(NVARCHAR(MAX), @PkTableId)
    FROM sys.foreign_key_columns FKC
      INNER JOIN sys.columns     COLPK ON COLPK.object_id = FKC.referenced_object_id
                                      AND COLPK.column_id = FKC.referenced_column_id
      INNER JOIN sys.columns     COLFK ON COLFK.object_id = FKC.parent_object_id
                                      AND COLFK.column_id = FKC.parent_column_id
      LEFT  JOIN dbo.XDeleteRule DAC ON DAC.TableName = OBJECT_NAME(FKC.parent_object_id)
                                    AND DAC.ColumnName = COLFK.name
    WHERE OBJECT_NAME(referenced_object_id) = @PkTableName

    UNION ALL

    -- recursion on other tables
    SELECT
      PkTableName     = OBJECT_NAME(FKC.referenced_object_id),
      PkColumnName    = COLPK.name,
      PkTableObjectId = FKC.referenced_object_id,
      PkColumnId      = FKC.referenced_column_id,
      FkTableName     = OBJECT_NAME(FKC.parent_object_id),
      FkColumnName    = COLFK.name,
      FkTableObjectId = FKC.parent_object_id,
      FkColumnId      = FKC.parent_column_id,
      FkName          = OBJECT_NAME(FKC.constraint_object_id),
      FkObjectId      = FKC.constraint_object_id,
      tableLevel      = CTE.tableLevel + 1,
      fkPath          = CTE.fkPath + '/' + OBJECT_NAME(FKC.parent_object_id) + '.' + COLFK.name,
      XDeleteRuleCode = ISNULL((SELECT DAC.XDeleteRuleCode
                                FROM dbo.XDeleteRule DAC
                                WHERE DAC.TableName = OBJECT_NAME(FKC.parent_object_id)
                                  AND DAC.ColumnName = COLFK.name), @DefaultDeleteRuleCode),
      SqlSelectPkIds  = N'SELECT ' + COLPK.name + N' FROM ' + CTE.FkTableName + N' WHERE ' + CTE.FkColumnName + N' IN (' + CTE.SqlSelectPkIds + N')'
    FROM sys.foreign_key_columns FKC
      INNER JOIN sys.columns     COLPK ON COLPK.object_id = FKC.referenced_object_id
                                      AND COLPK.column_id = FKC.referenced_column_id
      INNER JOIN sys.columns     COLFK ON COLFK.object_id = FKC.parent_object_id
                                      AND COLFK.column_id = FKC.parent_column_id
      INNER JOIN FKTmp           CTE   ON CTE.FkTableName = OBJECT_NAME(FKC.referenced_object_id)
                                      AND CTE.PkTableObjectId <> FKC.referenced_object_id
                                      AND CTE.XDeleteRuleCode = 1 -- delete
  )

  -- insert entries to delete that have FKs on the PK table
  INSERT INTO #EntriesToDelete(PkTableName, PkColumnName, PkTableObjectId, PkColumnId,
                               FkTableName, FkColumnName, FkTableObjectId, FkColumnId, FkName, FkObjectId,
                               tableLevel, fkPath, XDeleteRuleCode, SqlSelectPkIds)
    SELECT
      PkTableName,
      PkColumnName,
      PkTableObjectId,
      PkColumnId,
      FkTableName,
      FkColumnName,
      FkTableObjectId,
      FkColumnId,
      FkName,
      FkObjectId,
      tableLevel,
      fkPath,
      XDeleteRuleCode,
      SqlSelectPkIds
    FROM FKTmp CTE;

  -- insert PK table to delete
  INSERT INTO #EntriesToDelete(PkTableName, PkColumnName, PkTableObjectId, PkColumnId,
                               FkTableName, FkColumnName, FkTableObjectId, FkColumnId,
                               tableLevel, fkPath, XDeleteRuleCode, SqlSelectPkIds)
    SELECT
      PkTableName     = OBJECT_NAME(SKEY.parent_object_id),
      PkColumnName    = COL.name,
      PkTableObjectId = SKEY.parent_object_id,
      PkColumnId      = COL.column_id,
      FkTableName     = OBJECT_NAME(SKEY.parent_object_id),
      FkColumnName    = COL.name,
      FkTableObjectId = SKEY.parent_object_id,
      FkColumnId      = COL.column_id,
      tableLevel      = 0,
      fkPath          = CONVERT(VARCHAR(MAX), OBJECT_NAME(SKEY.parent_object_id)) + '.' + COL.name,
      XDeleteRuleCode = 1, -- delete
      SqlSelectPkIds  = CONVERT(NVARCHAR(MAX), @PkTableId)
    FROM sys.columns                 COL
      INNER JOIN sys.key_constraints SKEY ON SKEY.type = 'PK'
                                         AND SKEY.parent_object_id = COL.OBJECT_ID
                                         AND OBJECT_NAME(SKEY.parent_object_id) = @PkTableName
      INNER JOIN sys.index_columns   SIXC ON SIXC.object_id = SKEY.parent_object_id
                                         AND SIXC.index_id = SKEY.unique_index_id
                                         AND SIXC.column_id = COL.column_id;

  -- insert XDocument entries to delete as they don't have a FK
  INSERT INTO #EntriesToDelete(PkTableName, PkColumnName, PkTableObjectId, PkColumnId,
                               FkTableName, FkColumnName, FkTableObjectId, FkColumnId,
                               tableLevel, fkPath, XDeleteRuleCode, SqlSelectPkIds, SqlDeleteAction)
    SELECT
      PkTableName     = OBJECT_NAME(OBJ.object_id),
      PkColumnName    = DOCPK.name,
      PkTableObjectId = OBJ.object_id,
      PkColumnId      = DOCPK.column_id,
      FkTableName     = DEL.FkTableName,
      FkColumnName    = COLFK.name,
      FkTableObjectId = DEL.FkTableObjectId,
      FkColumnId      = COLFK.column_id,
      tableLevel      = (SELECT MAX(tableLevel) + 1
                         FROM #EntriesToDelete),
      fkPath          = DEL.fkPath + '/' + DEL.FkTableName + '.' + COLFK.name,
      XDeleteRuleCode = ISNULL(DAC.XDeleteRuleCode, @DefaultDeleteRuleCode),
      SqlSelectPkIds  = N'SELECT ' + COLFK.name + N' FROM ' + DEL.FkTableName + N' WHERE ' + DEL.FkColumnName + N' IN (' + DEL.SqlSelectPkIds + N')',
      SqlDeleteAction = CASE ISNULL(DAC.XDeleteRuleCode, @DefaultDeleteRuleCode)
                          WHEN 1
                            THEN N'DELETE T FROM ' + OBJECT_NAME(OBJ.object_id) + ' T WHERE ' + DOCPK.name + ' IN (' +
                                 N'SELECT ' + COLFK.name + N' FROM ' + DEL.FkTableName + N' WHERE ' + DEL.FkColumnName + N' IN (' + DEL.SqlSelectPkIds + N')'
                                 + ');'
                          WHEN 2
                            THEN N'UPDATE T SET ' + COLFK.name + N' = NULL FROM ' + DEL.FkTableName + N' T WHERE ' + DEL.FkColumnName + N' IN (' + DEL.SqlSelectPkIds + N')'
                          WHEN 4
                            THEN N'UPDATE T SET ' + COLFK.name + N' = ' + @ReplacementString + N' FROM ' + DEL.FkTableName + N' T WHERE ' + DEL.FkColumnName + N' IN (' + DEL.SqlSelectPkIds + N')'
                          ELSE N'-- ' + DEL.FkTableName + N'.' + COLFK.name + N' - ' + OBJECT_NAME(OBJ.object_id) + N'.' + DOCPK.name
                        END

    FROM #EntriesToDelete            DEL
      INNER JOIN sys.columns         COLPK ON OBJECT_NAME(COLPK.object_id) = DEL.FkTableName
      INNER JOIN sys.key_constraints KEYPK ON KEYPK.type = 'PK'
                                          AND KEYPK.parent_object_id = COLPK.object_id
      INNER JOIN sys.index_columns   IXCPK ON IXCPK.object_id = KEYPK.parent_object_id
                                          AND IXCPK.index_id = KEYPK.unique_index_id
                                          AND IXCPK.column_id = COLPK.column_id

      INNER JOIN sys.columns         COLFK ON OBJECT_NAME(COLFK.object_id) = DEL.FkTableName
                                          AND (COLFK.name LIKE '%Do_umentID%' OR COLFK.name LIKE '%DocID%')

      INNER JOIN sys.objects         OBJ   ON OBJECT_NAME(OBJ.object_id) = 'XDocument'
      INNER JOIN sys.columns         DOCPK ON DOCPK.object_id = OBJ.object_id
      INNER JOIN sys.key_constraints SKEY  ON SKEY.type = 'PK'
                                          AND SKEY.parent_object_id = OBJ.object_id
      INNER JOIN sys.index_columns   SIXC  ON SIXC.object_id = SKEY.parent_object_id
                                          AND SIXC.index_id = SKEY.unique_index_id
                                          AND SIXC.column_id = DOCPK.column_id
      LEFT  JOIN dbo.XDeleteRule     DAC   ON DAC.TableName COLLATE DATABASE_DEFAULT = DEL.FkTableName COLLATE DATABASE_DEFAULT
                                          AND DAC.ColumnName COLLATE DATABASE_DEFAULT = COLFK.name COLLATE DATABASE_DEFAULT;

  SELECT
    SqlDeleteAction = ISNULL(
                        SqlDeleteAction,
                        CASE ISNULL(DEL.XDeleteRuleCode, 1)
                          WHEN 1
                            THEN 'DELETE T'
                          WHEN 2
                            THEN 'UPDATE T SET ' + DEL.FkColumnName + ' = NULL'
                          WHEN 4
                            THEN 'UPDATE T SET ' + DEL.FkColumnName + ' = ' + @ReplacementString + ''
                          ELSE '--'
                        END + ' FROM ' + DEL.FkTableName + ' T WHERE ' + DEL.FkColumnName + ' IN (' + DEL.SqlSelectPkIds + ')')
  FROM #EntriesToDelete DEL
  ORDER BY ISNULL(DEL.XDeleteRuleCode, 1)DESC, tableLevel DESC, PkTableName, PkColumnName, FkTableName, FkColumnName;

  DROP TABLE #EntriesToDelete;
END;
