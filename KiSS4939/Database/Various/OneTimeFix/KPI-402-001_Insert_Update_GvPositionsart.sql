/*===============================================================================================
  SUMMARY: Use this script to <description>.
=================================================================================================*/

SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------

DECLARE @Stichtag DATETIME;
DECLARE @StichtagMinus1 DATETIME;

SET @StichtagMinus1 = dbo.fnLastDayOf(GETDATE());
SET @Stichtag = DATEADD(DAY, 1, @StichtagMinus1);
PRINT('Positionsarten per ' + CONVERT(VARCHAR, @Stichtag, 104) + ' aktualisieren/terminieren.');

DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @GvPositionsartID INT;
DECLARE @BgKostenartID INT;
DECLARE @BezeichnungD VARCHAR(MAX);
DECLARE @BezeichnungF VARCHAR(MAX);
DECLARE @BezeichnungI VARCHAR(MAX);
DECLARE @HSOnly BIT;
DECLARE @IsFLB BIT;
DECLARE @Mode INT;

DECLARE @Positionsarten TABLE
(
  ID INT NOT NULL IDENTITY(1,1),
  GvPositionsartID INT,
  BgKostenartID INT,
  BezeichnungD VARCHAR(MAX),
  BezeichnungF VARCHAR(MAX),
  BezeichnungI VARCHAR(MAX),
  HSOnly BIT,
  IsFLB BIT,
  Mode INT
);

DECLARE @Creator VARCHAR(50);
SET @Creator = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID());

-- Copied from Excel:
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (91, 18, 'Brillen', 'lunettes', 'Occhiali', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (92, 18, 'Ferien-/Entlastungsaufenthalt', 'vacances/séjour de relève', 'Vacanze/soggiorno di sgravio', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 18, 'Heiz-/Nebenkosten', 'charges et frais de chauffage', 'Spese riscaldamento/accessorie', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (93, 18, 'Mietkaution', 'caution pour l''appartement', 'Deposito garanzia appartamento', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (94, 18, 'Mobiliar', 'Mobilier', 'Mobilio', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (95, 18, 'Schuldensanierung-klein (max. Fr. 3.000)', 'assainiss. sit. d''endettem.-petit (max. Fr. 3''000.-)', 'assainiss. sit. d''endettem.-petit (max. Fr. 3''000.-)', 0, 1, 2);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (96, 18, 'Schuldensanierung-mittel/gross (ab Fr. 3001)', 'assainiss. sit. d''endettem.-moyen, grand (dès Fr. 3''001.-)', 'assainiss. sit. d''endettem.-moyen, grand (dès Fr. 3''001.-)', 0, 1, 2);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (97, 18, 'zz-Übrige ausserordentliche Auslagen', 'zz-autres dépenses extraordinaires', 'zz-Altre spese straordinarie', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (98, 19, 'Ausserordentliche Auslagen, periodisch', 'Autres dépenses. extraord. périodiques', 'Spese straordinarie periodiche', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (99, 20, 'Brillen', 'lunettes', 'Occhiali', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (100, 20, 'Ferien-/Entlastungsaufenthalt', 'vacances/séjour de relève', 'Vacanze/soggiorno di sgravio', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 20, 'Heiz-/Nebenkosten', 'charges et frais de chauffage', 'Spese riscaldamento/accessorie', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (101, 20, 'Mietkaution', 'caution pour l''appartement', 'Deposito garanzia appartamento', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (102, 20, 'Mobiliar', 'Mobilier', 'Mobilio', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (103, 20, 'Schuldensanierung-klein (max. Fr. 3.000)', 'assainiss. sit. d''endettem.-petit (max. Fr. 3''000.-)', 'Risanamento debiti - piccoli (mass. fr. 3000.-)', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (104, 20, 'Schuldensanierung-mittel/gross (ab Fr. 3001)', 'assainiss. sit. d''endettem.-moyen, grand (dès Fr. 3''001.-)', 'Risanamento debiti - medi/grandi (da fr. 3001.-)', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (105, 20, 'zz-Übrige Auslagen', 'zz-autres dépenses extraordinaires', 'zz-Altre spese', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (106, 21, 'Aus-/Weiterbildung', 'mesures de formation', 'Formazione/perfezionamento', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (107, 21, 'IPT, Wintegra oder ähnl. Org.', 'IPT, Wintegra ou autres org. similaires', 'IPT, Wintegra od org. simili', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 21, 'Profil', 'Profil', 'Profil', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (108, 21, 'zz-Übrige berufliche Massnahmen', 'zz-autres mesures professionnelles', 'zz-Altri provvedimenti professionali', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (109, 22, 'Aus-/Weiterbildung', 'mesures de formation', 'Formazione/perfezionamento', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (110, 22, 'IPT, Wintegra oder ähnl. Org.', 'IPT, Wintegra ou autres org. similaires', 'IPT, Wintegra od org. simili', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 22, 'Profil', 'Profil', 'Profil', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (111, 22, 'zz-Übrige berufliche Massnahmen', 'zz-autres mesures professionnelles', 'zz-Altri provvedimenti professionali', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (112, 23, 'Aus-/Weiterbildung', 'mesures de formation', 'Formazione/perfezionamento', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (113, 23, 'IPT, Wintegra oder ähnl. Org.', 'IPT, Wintegra ou autres org. similaires', 'IPT, Wintegra od org. simili', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 23, 'Profil', 'Profil', 'Profil', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (114, 23, 'zz-Übrige berufliche Massnahmen', 'zz-autres mesures professionnelles', 'zz-Altri provvedimenti professionali', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (115, 24, 'Assistenz, Betreuung, Pflege', 'frais d''assistance, soins, relève des proches', 'Sgravio, assistenza, cure', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (116, 24, 'Assistenzberatung Externe', 'conseil spécialisé en assistance externes', 'Consulenza spec. assistenza domicilio esterni', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 24, 'Assistenzberatung PI', 'conseil spécialisé en assistance PI', 'Consulenza spec. assistenza domicilio PI', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 24, 'Begleitetes Wohnen Externe', 'accompagnement à domicile externes', 'Accompagnamento a domicilio esterni', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 24, 'Begleitetes Wohnen PI', 'accompagnement à domicile PI', 'Accompagnamento a domicilio PI', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (117, 24, 'Behindertentransport Externe', 'transport handicap externes', 'Servizio trasporto esterni', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 24, 'Behindertentransport PI', 'transport handicap PI', 'Servizio trasporto PI', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 24, 'Besuchs-/Begleitdienst Externe', 'service de visite et d''accompagnement externes', 'Servizio visite/accompagnamento esterni', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 24, 'Besuchs-/Begleitdienst PI', 'service de visite et d''accompagnement PI', 'Servizio visite/accompagnamento PI', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 24, 'Bildungsklub Externe', 'centre de formation continue externes', 'Circoli formazione esterni', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 24, 'Bildungsklub PI', 'centre de formation continue PI', 'Circoli formazione PI', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (118, 24, 'Entlastung im Aufgabenbereich (z.B. Kinderbetreuung)', 'relève dans le champ d''activité (par ex. prise en charge des enfants)', 'Sgravio mansioni consuete (p.es. custodia bambini)', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 24, 'Entlastungsdienst Externe', 'service de relève externes', 'Servizio sostegno esterni', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 24, 'Entlastungsdienst PI', 'service de relève externes', 'Servizio sostegno PI', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (119, 24, 'Tagestruktur-soziokulturelle Aktivitäten', 'structure journalière-activités socioculturelles', 'Struttura diurna - attività socioculturali', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (120, 24, 'Tagestruktur-Reisekosten ÖV: z.B. Swisspass', 'structure journalière-frais de voyage transport publ. (par ex. SwissPass)', 'Struttura diurna - spese trasferta mezzi pubblici (p.es. Swisspass)', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 24, 'Treuhanddienst Externe', 'soutien administratif externes', 'Servizio fiduciario esterni', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 24, 'Treuhanddienst PI', 'soutien administratif PI', 'Servizio fiduciario PI', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (121, 24, 'Umzugkosten', 'déménagement', 'Spese trasloco', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (122, 24, 'zz-Übrige Dienstleistungen', 'zz-autres prestations en services', 'zz-Altre prestazioni', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (123, 25, 'Assistenz, Betreuung, Pflege', 'frais d''assistance, soins, relève des proches', 'Sgravio, assistenza, cure', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (124, 25, 'Assistenzberatung Externe', 'conseil spécialisé en assistance externes', 'Consulenza spec. assistenza domicilio esterni', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 25, 'Assistenzberatung PI', 'conseil spécialisé en assistance PI', 'Consulenza spec. assistenza domicilio PI', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 25, 'Begleitetes Wohnen Externe', 'accompagnement à domicile externes', 'Accompagnamento a domicilio esterni', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 25, 'Begleitetes Wohnen PI', 'accompagnement à domicile PI', 'Accompagnamento a domicilio PI', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (125, 25, 'Behindertentransport Externe', 'transport handicap externes', 'Servizio trasporto esterni', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 25, 'Behindertentransport PI', 'transport handicap PI', 'Servizio trasporto PI', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 25, 'Besuchs-/Begleitdienst Externe', 'service de visite et d''accompagnement externes', 'Servizio visite/accompagnamento esterni', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 25, 'Besuchs-/Begleitdienst PI', 'service de visite et d''accompagnement PI', 'Servizio visite/accompagnamento PI', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 25, 'Bildungsklub Externe', 'centre de formation continue externes', 'Circoli formazione esterni', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 25, 'Bildungsklub PI', 'centre de formation continue PI', 'Circoli formazione PI', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (126, 25, 'Entlastung im Aufgabenbereich (z.B. Kinderbetreuung)', 'relève dans le champ d''activité (par ex. prise en charge des enfants)', 'Sgravio mansioni consuete (p.es. custodia bambini)', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 25, 'Entlastungsdienst Externe', 'service de relève externes', 'Servizio sostegno esterni', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 25, 'Entlastungsdienst PI', 'service de relève PI', 'Servizio sostegno PI', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (127, 25, 'Tagestruktur-soziokulturelle Aktivitäten', 'structure journalière-activités socioculturelles', 'Struttura diurna - attività socioculturali', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (128, 25, 'Tagestruktur-Reisekosten ÖV: z.B. Swisspass', 'structure journalière-frais de voyage transport publ. (par ex. SwissPass)', 'Struttura diurna - spese trasferta mezzi pubblici (p.es. Swisspass)', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 25, 'Treuhanddienst Externe', 'soutien administratif externes', 'Servizio fiduciario esterni', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 25, 'Treuhanddienst PI', 'soutien administratif PI', 'Servizio fiduciario PI', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (129, 25, 'zz-Übrige Dienstleistungen', 'zz-autres prestations en services', 'zz-Altre prestazioni', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (130, 26, 'Assistenz, Betreuung, Pflege', 'frais d''assistance, soins, relève des proches', 'Sgravio, assistenza, cure', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (131, 26, 'Assistenzberatung Externe', 'conseil spécialisé en assistance externes', 'Consulenza spec. assistenza domicilio esterni', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 26, 'Assistenzberatung PI', 'conseil spécialisé en assistance PI', 'Consulenza spec. assistenza domicilio PI', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 26, 'Begleitetes Wohnen Externe', 'accompagnement à domicile externes', 'Accompagnamento a domicilio esterni', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 26, 'Begleitetes Wohnen PI', 'accompagnement à domicile PI', 'Accompagnamento a domicilio PI', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (132, 26, 'Behindertentransport Externe', 'transport handicap externes', 'Servizio trasporto esterni', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 26, 'Behindertentransport PI', 'transport handicap PI', 'Servizio trasporto PI', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 26, 'Besuchs-/Begleitdienst Externe', 'service de visite et d''accompagnement externes', 'Servizio visite/accompagnamento esterni', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 26, 'Besuchs-/Begleitdienst PI', 'service de visite et d''accompagnement PI', 'Servizio visite/accompagnamento PI', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 26, 'Bildungsklub Externe', 'centre de formation continue externes', 'Circoli formazione esterni', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 26, 'Bildungsklub PI', 'centre de formation continue PI', 'Circoli formazione PI', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (133, 26, 'Entlastung im Aufgabenbereich (z.B. Kinderbetreuung)', 'relève dans le champ d''activité (par ex. prise en charge des enfants)', 'Sgravio mansioni consuete (p.es. custodia bambini)', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 26, 'Entlastungsdienst Externe', 'service de relève externes', 'Servizio sostegno esterni', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 26, 'Entlastungsdienst PI', 'service de relève PI', 'Servizio sostegno PI', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (134, 26, 'Tagestruktur-soziokulturelle Aktivitäten', 'structure journalière-activités socioculturelles', 'Struttura diurna - attività socioculturali', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (135, 26, 'Tagestruktur-Reisekosten ÖV: z.B. Swisspass', 'structure journalière-frais de voyage transport publ. (par ex. swisspass)', 'Struttura diurna - spese trasferta mezzi pubblici (p.es. Swisspass)', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 26, 'Treuhanddienst Externe', 'soutien administratif externes', 'Servizio fiduciario esterni', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 26, 'Treuhanddienst PI', 'soutien administratif PI', 'Servizio fiduciario PI', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (136, 26, 'Umzugkosten', 'déménagement', 'Spese trasloco', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (137, 26, 'zz-Übrige Dienstleistungen', 'zz-autres prestations en services', 'zz-Altre prestazioni', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (138, 27, 'Kinderkrippe-Spielgruppe', 'crèche, groupe de jeux', 'Asilo nido, gruppo di gioco', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (139, 27, 'zz-Übrige Frühberatung', 'zz-autre prise en charge préscolaire', 'zz-Altra presa a carico precoce', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (140, 28, 'Kinderkrippe-Spielgruppe', 'crèche, groupe de jeux', 'Asilo nido, gruppo di gioco', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (141, 28, 'zz-Übrige Frühberatung', 'zz-autre prise en charge préscolaire', 'zz-Altra presa a carico precoce', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (142, 29, 'Kinderkrippe-Spielgruppe', 'crèche, groupe de jeux', 'Asilo nido, gruppo di gioco', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (143, 29, 'zz-Übrige Frühberatung', 'zz-autre prise en charge préscolaire', 'zz-Altra presa a carico precoce', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (144, 30, 'Bevorschussung Renten/EL', 'avance rentes/PC', 'avance rentes/PC', 0, 1, 2);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (145, 30, 'zz-Übriger gewöhnlicher Lebensbedarf', 'zz-autres contributions aux nécessités de la vie courante', 'zz-autres contributions aux nécessités de la vie courante', 0, 1, 2);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (146, 31, 'Bevorschussung Renten/EL', 'avance rentes/PC', 'Anticipo rendite/PC', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (147, 31, 'zz-Übriger gewöhnlicher Lebensbedarf', 'zz-autres contributions aux nécessités de la vie courante', 'zz-Altri contributi al fabbisogno vitale', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (148, 32, 'Bevorschussung Renten/EL', 'avance rentes/PC', 'Anticipo rendite/PC', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (149, 32, 'zz-Übriger gewöhnlicher Lebensbedarf', 'zz-autres contributions aux nécessités de la vie courante', 'zz-Altri contributi al fabbisogno vitale', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (150, 33, 'Autoanschaffung', 'véhicules à moteur, achat', 'Veicolo a motore, acquisto', 1, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (151, 33, 'Autobevorschussung', 'véhicules à moteur, avance achat', 'Veicolo a motore, anticipo acquisto', 1, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (152, 33, 'Autoumbau', 'véhicules à moteur, transformation', 'Veicolo a motore, modifica', 1, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (153, 33, 'Bauliche Massnahmen', 'mesures architecturales', 'Misure architettoniche', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (154, 33, 'E-hockey-Sportgerät', 'e-hockey-moyens aux. de sport', 'e-hockey - mezzi ausiliari sport', 1, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 33, 'Expertisen Bauberatung PI', 'expertises Conseil en construction PI', 'Perizie consulenza architettonica PI', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 33, 'Expertisen SAHB', 'expertises FSCMA', 'Perizie FSCMA', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 33, 'Expertisen Übrige', 'expertises autres', 'Perizie altri', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 33, 'Expertisen Bauberatung Übrige', 'expertises Conseil en construction autres', 'Perizie consulenza architettonica altri', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (155, 33, 'Hörgerät', 'appareil auditif', 'Apparecchio acustico', 1, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (156, 33, 'Kommunikationshilfsmittel', 'appareil de communiquation', 'Mezzo ausiliario per la comunicazione', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (157, 33, 'Rollstuhl-Elektrorollstuhl', 'chaise roulante-ch. r. électrique', 'Sedia a rotelle - sedia a rotelle elettrica', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (158, 33, 'Treppenlift', 'lift d''escalier', 'Montascale', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (159, 33, 'zz-Übrige Hilfsmittel', 'zz-autres moyens aux.', 'zz-Altri mezzi ausiliari', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (160, 34, 'Hilfsmittel/bauliche Massnahmen', 'moyens aux./mesures architect.', 'Mezzi ausiliari/misure architettoniche', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (161, 35, 'Autoanschaffung', 'véhicules à moteur, achat', 'Veicolo a motore, acquisto', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (162, 35, 'Autobevorschussung', 'véhicules à moteur, avance achat', 'Veicolo a motore, anticipo acquisto', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (163, 35, 'Autoumbau', 'véhicules à moteur, transformation', 'Veicolo a motore, modifica', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (164, 35, 'Bauliche Massnahmen', 'mesures architecturales', 'Misure architettoniche', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (165, 35, 'E-hockey-Sportgerät', 'e-hockey-moyens aux. de sport', 'e-hockey - mezzi ausiliari sport', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 35, 'Expertisen Bauberatung PI', 'expertises Conseil en construction PI', 'Perizie consulenza architettonica PI', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 35, 'Expertisen SAHB', 'expertises FSCMA', 'Perizie FSCMA', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 35, 'Expertisen Übrige', 'expertises autres', 'Perizie altri', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 35, 'Expertisen Bauberatung Übrige', 'expertises Conseil en construction autres', 'Perizie consulenza architettonica altri', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (166, 35, 'Hörgerät', 'appareil auditif', 'Apparecchio acustico', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (167, 35, 'Kommunikationshilfsmittel', 'appareil de communiquation', 'Mezzo ausiliario per la comunicazione', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (168, 35, 'Rollstuhl-Elektrorollstuhl', 'chaise roulante-ch. r. électrique', 'Sedia a rotelle - sedia a rotelle elettrica', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (169, 35, 'Treppenlift', 'lift d''escalier', 'Montascale', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (170, 35, 'zz-Übrige Hilfsmittel', 'zz-autres moyens aux.', 'zz-Altri mezzi ausiliari', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (171, 36, 'Altern. Behandlungsmethoden/-Therapien', 'méthodes de traitement alternatives (-thérapies)', 'Trattamenti/terapie alternativi', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (172, 36, 'Alternative Medikamente', 'médicaments alternatifs', 'Farmaci alternativi', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (173, 36, 'Autismus-Behandlungsmethoden', 'autisme-méthodes de traitement', 'Autismo - metodi di trattamento', 1, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (174, 36, 'Kur-/Erholungsaufenthalt', 'cure ou séjour de relève ordonné par le médecin', 'Soggiorno di cura o convalescenza', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (175, 36, 'Medikamente', 'médicaments', 'Farmaci', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (176, 36, 'Med. Behandlungsgeräte', 'appareils de soins médicaux', 'Apparecchiature mediche', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (177, 36, 'Med. Verbrauchsmaterial (Pflaster, Salben etc.)', 'matériel pour soins quotidiens (pansements, pommade etc.)', 'Materiale medico di consumo (cerotti, pomate ecc.)', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (178, 36, 'Selbstbehalte, Franchise', 'quote-part, franchise', 'Aliquota percentuale, franchigia', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (179, 36, 'Zahnbehandlung', 'traitements dentaires', 'Cure dentarie', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (180, 36, 'zz-Übrige medizinische Massnahmen', 'zz-autres mesures médicales', 'zz-Altri provvedimenti medici', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 37, 'Altern. Behandlungsmethoden/-Therapien', 'méthodes de traitement alternatives (-thérapies)', 'Trattamenti/terapie alternativi', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 37, 'Alternative Medikamente', 'médicaments alternatifs', 'Farmaci alternativi', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 37, 'Autismus-Behandlungsmethoden', 'autisme-méthodes de traitement', 'Autismo - metodi di trattamento', 1, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (181, 37, 'Medikamente', 'médicaments', 'Farmaci', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (182, 37, 'Miete med. Behandlungsgeräte', 'location appareils de soins médicaux', 'Affitto apparecchiature mediche', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (183, 37, 'Med. Verbrauchsmaterial (Pflaster, Salben etc.)', 'matériel pour soins quotidiens (pansements, pommade etc.)', 'Materiale medico di consumo (cerotti, pomate ecc.)', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (NULL, 37, 'Selbstbehalte, Franchise', 'quote-part, franchise', 'Aliquota percentuale, franchigia', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (184, 37, 'zz-Übrige medizinische Massnahmen', 'zz-autres mesures médicales', 'zz-Altri provvedimenti medici', 0, 1, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (185, 38, 'Altern. Behandlungsmethoden/-Therapien', 'méthodes de traitement alternatives (-thérapies)', 'Trattamenti/terapie alternativi', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (186, 38, 'Alternative Medikamente', 'médicaments alternatifs', 'Farmaci alternativi', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (187, 38, 'Autismus-Behandlungsmethoden', 'autisme-méthodes de traitement', 'Autismo - metodi di trattamento', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (188, 38, 'Kur- oder ärztlich verordneter Erholungsaufenthalt', 'cure ou séjour de relève ordonné par le médecin', 'Soggiorno cura/convalescenza prescritto dal medico', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (189, 38, 'Medikamente', 'médicaments', 'Farmaci', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (190, 38, 'Miete med. Behandlungsgeräte', 'location appareils de soins médicaux', 'Affitto apparecchiature mediche', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (191, 38, 'Med. Verbrauchsmaterial (Pflaster, Salben etc.)', 'matériel pour soins quotidiens (pansements, pommade etc.)', 'Materiale medico di consumo (cerotti, pomate ecc.)', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (192, 38, 'Selbstbehalte, Franchise', 'quote-part, franchise', 'Aliquota percentuale, franchigia', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (193, 38, 'Zahnbehandlung', 'traitements dentaires', 'Cure dentarie', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (194, 38, 'zz-Übrige medizinische Massnahmen', 'zz-autres mesures médicales', 'zz-Altri provvedimenti medici', 0, 0, 1);
INSERT INTO @Positionsarten (GvPositionsartID, BgKostenartID, BezeichnungD, BezeichnungF, BezeichnungI, HSOnly, IsFLB, Mode) VALUES (195, 39, 'Versorgerbeiträge Sonderschule', 'école spéciale, participation parents', 'Scuola speciale, partecipazione genitori', 0, 0, 1);


-- prepare vars for loop
SELECT @EntriesCount = COUNT(1)
FROM @Positionsarten;
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
BEGIN TRY
  BEGIN TRAN;
    WHILE (@EntriesIterator <= @EntriesCount)
    BEGIN    
      -- get current entry
      SELECT
        @GvPositionsartID = TMP.GvPositionsartID,
        @BgKostenartID = TMP.BgKostenartID,
        @BezeichnungD = TMP.BezeichnungD,
        @BezeichnungF = TMP.BezeichnungF,
        @BezeichnungI = TMP.BezeichnungI,
        @HSOnly = TMP.HSOnly,
        @IsFLB = TMP.IsFLB,
        @Mode = TMP.Mode
      FROM @Positionsarten TMP
      WHERE TMP.ID = @EntriesIterator;
      
      PRINT '----------------------'
      PRINT 'GvPositionartID=' + CONVERT(VARCHAR,@GvPositionsartID)
      
      -----------------------------------------------------------------------------
      -- do something
      -----------------------------------------------------------------------------

      -- bereits migriert?
      IF (EXISTS (SELECT TOP 1 1
                  FROM dbo.GvPositionsart
                  WHERE BgKostenartID = @BgKostenartID
                    AND Bezeichnung = @BezeichnungD
                    AND dbo.fnGetMLText(BezeichnungTID, 1) = @BezeichnungD
                    AND dbo.fnGetMLText(BezeichnungTID, 2) = @BezeichnungF
                    AND dbo.fnGetMLText(BezeichnungTID, 3) = @BezeichnungI
                    AND HSOnly = @HSOnly
                    AND IsFLB = @IsFLB
                    AND ( @Mode = 1 OR 
                          @Mode = 2 AND DatumBis IS NOT NULL)))
      BEGIN
        PRINT('GvPositionsart wurde schon migriert: Bezeichnung=' + @BezeichnungD) 
                       + ' BgKostenartID=' + CONVERT(VARCHAR,@BgKostenartID)
                       + ' HSOnly=' + CONVERT(VARCHAR,@HSOnly)
                       + ' IsFLB=' + CONVERT(VARCHAR,@IsFLB)
                       + ' Mode=' + CONVERT(VARCHAR,@Mode);
        SET @EntriesIterator = @EntriesIterator + 1;
        CONTINUE;
      END;
      PRINT 'Migration von ' + CONVERT(VARCHAR,@GvPositionsartID) + ' beginnt';

      -- GvPositionsartID ist gesetzt -> wenn nichts geändert hat überspringen, ansonsten terminieren
      IF (@GvPositionsartID IS NOT NULL)
      BEGIN
        IF (NOT EXISTS (SELECT TOP 1 1
                        FROM dbo.GvPositionsart
                        WHERE GvPositionsartID = @GvPositionsartID))
        BEGIN
          PRINT('ERROR: Positionsart mit ID=' + CONVERT(VARCHAR, @GvPositionsartID) + ' existiert nicht!');
          SET @EntriesIterator = @EntriesIterator + 1;
          CONTINUE;
        END;
      END
      ELSE BEGIN
        PRINT('Neue GvPositionsart einfügen: ' + @BezeichnungD);

          -- Neue Positionsart erstellen
          INSERT INTO dbo.GvPositionsart (
              BgKostenartID,
              Bezeichnung,
              DatumVon,
              HSOnly,
              IsFLB,
              Creator,
              Modifier
            )
            SELECT
              @BgKostenartID, -- BgKostenartID - int
              @BezeichnungD, -- Bezeichnung - varchar(max)
              @Stichtag, -- DatumVon - datetime
              @HSOnly, -- HSOnly - bit
              @IsFLB, -- IsFLB - bit
              @Creator, -- Creator - varchar(50)
              @Creator; -- Modifier - varchar(50)
          SET @GvPositionsartID = SCOPE_IDENTITY();

          PRINT('GvPositionsart ''' + @BezeichnungD + ''' mit ID=' + CONVERT(VARCHAR, @GvPositionsartID) + ' eingefügt');

      END;
      
      PRINT('GvPositionsart mit ID=' + CONVERT(VARCHAR, @GvPositionsartID) + ' - Bezeichnungen aktualisieren');      
            
      -- Übersetzung
      DECLARE @BezeichnungTID INT;
      SELECT @BezeichnungTID = BezeichnungTID
      FROM GvPositionsart
      WHERE GvPositionsartID = @GvPositionsartID;

      IF (@BezeichnungD IS NOT NULL)
      BEGIN 
        EXEC dbo.spXSetXLangText @BezeichnungTID, 1, @BezeichnungD, NULL, NULL, NULL, NULL, @BezeichnungTID OUT;
      END;
      IF (@BezeichnungF IS NOT NULL)
      BEGIN 
        EXEC dbo.spXSetXLangText @BezeichnungTID, 2,@BezeichnungF,  NULL, NULL, NULL, NULL, @BezeichnungTID OUT;
      END;
      IF (@BezeichnungI IS NOT NULL)
      BEGIN 
        EXEC dbo.spXSetXLangText @BezeichnungTID, 3, @BezeichnungI,  NULL, NULL, NULL, NULL, @BezeichnungTID OUT;
      END;
      
      IF (@BezeichnungTID IS NOT NULL)
      BEGIN
        UPDATE dbo.GvPositionsart
          SET BezeichnungTID = @BezeichnungTID,
              Modifier       = @Creator,
              Modified       = GETDATE()
        WHERE GvPositionsartID = @GvPositionsartID;
      END;
      
      UPDATE dbo.GvPositionsart
        SET Bezeichnung = @BezeichnungD,
            Modifier    = @Creator,
            Modified    = GETDATE()
      WHERE GvPositionsartID = @GvPositionsartID;
      
      PRINT('GvPositionsart mit ID=' + CONVERT(VARCHAR, @GvPositionsartID) + ' - HSOnly und @IsFLB aktualisieren');      
      UPDATE dbo.GvPositionsart
        SET HSOnly   = @HSOnly,
            IsFLB    = @IsFLB,
            Modifier = @Creator,
            Modified = GETDATE()
      WHERE GvPositionsartID = @GvPositionsartID;      
        
      IF (@Mode = 2)
      BEGIN
        -- Nur terminieren
        PRINT('GvPositionsart mit ID=' + CONVERT(VARCHAR, @GvPositionsartID) + ' wird terminiert --> DatumBis setzten');

        UPDATE dbo.GvPositionsart
          SET DatumBis = @StichtagMinus1,
              Modifier = @Creator,
              Modified = GETDATE()
        WHERE GvPositionsartID = @GvPositionsartID;
      END;  

      PRINT('GvPositionsart ''' + @BezeichnungD + ''' mit ID=' + CONVERT(VARCHAR, @GvPositionsartID) + ' aktualisiert');
        
      -- prepare for next entry
      SET @EntriesIterator = @EntriesIterator + 1;
    END;

  --DEBUG
  --ROLLBACK

  COMMIT;
END TRY
BEGIN CATCH
  ROLLBACK;

  DECLARE @ErrorMessage VARCHAR(MAX);
  DECLARE @ErrorSeverity INT;
  DECLARE @ErrorState INT;

  SELECT @ErrorMessage = ERROR_MESSAGE(),
         @ErrorSeverity = ERROR_SEVERITY(),
         @ErrorState = ERROR_STATE();

  RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
END CATCH;

GO

SET NOCOUNT OFF;
GO
