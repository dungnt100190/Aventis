/*===============================================================================================
  $Revision: 2$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this insert Fonds
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

PRINT ('Info: Zahlungskonto umbenennen');
UPDATE dbo.KbZahlungskonto
  SET Name = 'FLB-PAH Schweiz'
WHERE Name = 'FLB-Schweiz'

UPDATE dbo.KbZahlungskonto
  SET Name = 'PAH-FLB VS'
WHERE Name = 'PAH-Canton VS'


-- Spezialfall für GvFondsID = 42 Parrainages JU
UPDATE dbo.GvFonds
  SET DatumBis = NULL
WHERE GvFondsID = 42
  AND NameKurz = 'Parrainages JU'
  
IF (@@ROWCOUNT <> 1)
BEGIN
  PRINT ('Error: Spezialfall für GvFondsID = 42 Parrainages JU konnte nicht korrigiert werden');
END;


PRINT 'Script INSERT/UPDATE GvFonds startet'

-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;

DECLARE @KbZahlungskontoID int;
DECLARE @Zahlungskonto varchar(50);
DECLARE @GvFondsID int;
DECLARE @NameKurz varchar(200);
DECLARE @NameLang varchar(500);
DECLARE @BemerkungTID int;
DECLARE @BemerkungD varchar(max);
DECLARE @BemerkungF varchar(max);
DECLARE @BemerkungI varchar(max);
DECLARE @GvFondsTypeCode int;
DECLARE @IstCH bit;
DECLARE @Abteilungen varchar(max);

DECLARE @OrgUnitID INT;
DECLARE @Result VARCHAR(100);
DECLARE @IsNeu BIT;
DECLARE @MustTerminateIt BIT;
DECLARE @IsWithChangeText BIT;

DECLARE @CreatorModifier VARCHAR(50);
SET @CreatorModifier = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID());

DECLARE @DatumVon datetime;
DECLARE @DatumBis datetime;

SET @DatumBis = dbo.fnLastDayOf(GETDATE());;
SET @DatumVon = DATEADD(DAY, 1, @DatumBis);


DECLARE @GvFonds_XOrgUnitInsertResult TABLE
(
  ResultMessage VARCHAR(1000)
);

DECLARE @TmpGvFonds_XOrgUnit TABLE
(
  OrgUnitID INT
);

DECLARE @GvFondsToInsert TABLE
(
  GvFondsToInsertID INT IDENTITY(1, 1) NOT NULL, -- ID für die Ausführung in diesem Script
  GvFondsID INT NULL,  -- GvFonds.GvFondsID
  Zahlungskonto varchar(50) NULL,  -- KbZahlungskonto.Name
  NameKurz varchar(200) NOT NULL, -- GvFonds.NameKurz
  NameLang varchar(500) NOT NULL, -- GvFonds.NameLang
  BemerkungD varchar(max) NULL, -- GvFonds.Bemerkung, XLangText.Text durch BemerkungTID verknüpft falls mehrsprachig
  BemerkungF varchar(max) NULL, -- GvFonds.Bemerkung, XLangText.Text durch BemerkungTID verknüpft falls mehrsprachig
  BemerkungI varchar(max) NULL, -- GvFonds.Bemerkung, XLangText.Text durch BemerkungTID verknüpft falls mehrsprachig
  GvFondsTypCode int NOT NULL, -- GvFonds.GvFondsTypCode (LOVCode=1 intern oder 2 extern)
  IstCH bit NOT NULL, -- GvFonds.IstCH (Schweiz oder Kant.)
  Abteilungen varchar(MAX) NOT NULL, -- GvFonds_XOrgUnit.ItemName
  MustTerminateIt BIT NOT NULL,
  IsWithChangeText BIT NOT NULL
);


-- TODO select aus Excel hinzufügen
INSERT INTO @GvFondsToInsert(   GvFondsID,
                                Zahlungskonto, 
                                NameKurz, 
                                NameLang, 
                                BemerkungD, 
                                BemerkungF, 
                                BemerkungI, 
                                GvFondsTypCode, 
                                IstCH,  
                                Abteilungen, 
                                MustTerminateIt,
                                IsWithChangeText )
SELECT 1,NULL,'Ausserordentliche Direkthilfe/aide directe extraordinaire PI HS/SP','Fonds für ausserordentliche Direkthilfe, fonds pour les situations extraordinaires PI HS/SP','Für komplizierte Fälle, die nicht mit FLB und externen Stiftungen gelöst werden können.','Pour les situations complexes, qui ne peuvent pas être résolues à l''aide des PAH et de fonds externes.','Per casi complicati che non possono essere risolti con le PAH e fondazioni esterne.',1,1,'ganze Schweiz',0,0
UNION ALL SELECT NULL,NULL,'Autoabklärungsdienst/Service véhicule PI HS/SP','Autoabklärungsdienst/Service véhicule PI HS/SP','Einreichung eines Autoabklärungsmandats an PI HS, Abteilung Direkthilfe. Starten sie die Vorlage im Register Beilagen/Dokumente und füllen sie sie aus. Es sind die gleichen Beilagen zu den Finanzen einzureichen, wie für ein Gesuch. ','Remise d''un mandat d''enquête automobile au service Aide directe du Siège principal de PI. Ouvrez le modèle depuis l''onglet Annexes/Doc. et remplissez-le. Il faut joindre les mêmes justificatifs relatifs à la situation financière que pour une demande.','Conferimento di un mandato di accertamento auto alla sede principale PI, settore Aiuti diretti. Aprite il modello sotto Allegati/documenti e compilatelo. Vanno presentati gli stessi allegati relativi alla situazione finanziaria come per una domanda. ',1,1,'ganze Schweiz',0,1
UNION ALL SELECT 2,NULL,'Autofonds/fonds véhicules PI HS/SP','Autofonds/fonds véhicules PI HS/SP','Behinderungsbedingte Autoanschaffungen. Max. Fr. 5''000.-. Erst, wenn FLB und externe Quellen ausgeschöpft.','Acquisitions de véhicules nécessaires en raison du handicap. Au max. Fr. 5''000.-. A solliciter seulement une fois que les possibilités de recourir aux PAH et aux fonds externes sont épuisées.','Acquisto di un veicolo a causa dall’handicap. Massimo 5000 franchi. Soltanto quando PAH e fonti esterne esaurite.',1,1,'ganze Schweiz',0,0
UNION ALL SELECT 3,'FLB-PAH Schweiz','FLB-PAH Suisse','FLB-PAH Suisse','FLB Gesuche über Fr. 10''000.- pro Fall/Jahr. Unabhängig vom Betrag alle Gesuche für autismusspezifische Behandlungsmethoden, Autoanschaffung und -Umbau, E-hockey-Sportgeräte, Hörgeräte, medizinische Massnahmen: Beiträge an alternative Behandlungsmethoden ab dem 2. Unterstützungsjahr','Demandes PAH de plus de Fr. 10''000.- par situation/an. Egalement, indépendamment du montant demandé, toutes les demandes pour des mesures thérapeutiques spécifiques pour personnes autistes, pour l''acquisition ou la transformation de véhicules, pour du matériel de e-hockey, pour des appareils auditifs et, à partir de la 2e année, pour des thérapies alternatives (mesures médicales).','Domande PAH superiori ai 10''000 franchi per caso/anno. A prescindere dall’importo, tutte le domande per metodi di trattamento specifici dell’autismo, acquisti e modifiche di veicoli, attrezzature sportive per l’hockey in carrozzina elettrica, apparecchi acustici, provvedimenti medici: contributi a metodi di trattamento alternativi a partire dal 2° anno di sostegno.',1,1,'ganze Schweiz',0,0
UNION ALL SELECT 5,NULL,'Love Ride Switzerland','Love Ride Switzerland','Alle Behinderungen. Prioritär Muskelerkrankung. Unterstützung zu Themen Mobilität (Autoanschaffung) und Lebensfreude. Max. Fr. 2''500.-. ','Tous types de handicap, mais la priorité est donnée aux maladies musculaires. Soutien visant à accroître la mobilité (acquisition de véhicules) et la joie de vivre. Au max. Fr. 2''500.-. ','Tutti i tipi di handicap. Priorità malattie muscolari. Sostegno alla mobilità (acquisto di un veicolo) e alla gioia di vivere. Massimo 2500 franchi. ',1,1,'ganze Schweiz',0,0
UNION ALL SELECT NULL,NULL,'Paraplegiker-Stiftung, Schweizerische-nur/uniquement e-hockey','Schweizerische Paraplegiker-Stiftung-nur/uniquement E-hockey','Aufgrund einer speziellen Abmachungen werden Gesuche für e-hockey-Stühle via die Abteilung Direkthilfe, HS eingereicht. Max. Fr. 5''000.-.','Convention spéciale concernant les fauteuils roulants de e-hockey. Les demandes sont déposées par l''intermédiaire du service Aide directe du Siège principal de PI. Au max. Fr. 5''000.-.','A seguito di uno speciale accordo, le domande per le carrozzine per l’hockey vanno presentate tramite il settore Aiuti diretti, sede principale. Massimo 5000 franchi.',1,1,'ganze Schweiz',0,1
UNION ALL SELECT NULL,NULL,'Pro Audito, Fonds Irma Wigert','Pro Audito, Fonds Irma Wigert','Nur für Hörbehinderte und Gehörlose. Vorwiegend Hörgeräte. Da nur sporadische Entscheidsitzungen stattfinden, wird das Gesuch in der Regel via FLB-Schweiz oder anderer interner Fonds HS vorfinanziert.','Seulement pour personnes malentendantes ou sourdes. Surtout pour appareils auditifs. Etant donné que la fondation ne tient pas de séances régulières pour statuer sur les demandes, l''Office national PAH ou un autre fonds interne du Siège principal avancent en général un montant.','Soltanto per deboli d’udito e non udenti. Soprattutto apparecchi acustici. Poiché le riunioni decisionali hanno luogo solo sporadicamente, la domanda è in genere pre-finanziata tramite PAH Svizzera o altri fondi interni della sede principale.',1,1,'ganze Schweiz',0,1


UNION ALL SELECT 6,NULL,'Ältere Behinderte, Fonds für','Fonds für "ältere" Behinderte',NULL,NULL,NULL,1,0,'KGS ZH,HS Zürich',0,0
UNION ALL SELECT 7,'FLB-Kanton ZH','FLB Kanton ZH','FLB Kanton ZH',NULL,NULL,NULL,1,0,'KGS ZH,HS Zürich',0,0
UNION ALL SELECT 8,NULL,'Patenschaften ZH','Patenschaften ZH',NULL,NULL,NULL,1,0,'KGS ZH,HS Zürich',0,0
UNION ALL SELECT 9,NULL,'Loisirs, fonds','Fonds loisirs',NULL,NULL,NULL,1,0,'DCN VD,HS Zürich',0,0
UNION ALL SELECT 10,'PAH-Canton VD','PAH canton VD','PAH canton VD',NULL,NULL,NULL,1,0,'DCN VD,HS Zürich',0,0
UNION ALL SELECT 11,NULL,'Parrainages VD','Parrainages VD',NULL,NULL,NULL,1,0,'DCN VD,HS Zürich',0,0
UNION ALL SELECT 12,NULL,'Arnold, Erbengemeinschaft, für CM-Kinder','Erbengemeinschaft Arnold für CM-Kinder',NULL,NULL,NULL,1,0,'ehemalige KGS Uri/Schwyz,KGS ZG-UR-SZ,HS Zürich',0,0
UNION ALL SELECT 13,'FLB-Kanton UR/SZ/ZG','FLB Kanton UR/SZ/ZG','FLB Kanton UR/SZ/ZG',NULL,NULL,NULL,1,0,'ehemalige KGS Uri/Schwyz,KGS ZG-UR-SZ,HS Zürich',0,0
UNION ALL SELECT 14,NULL,'Nothilfefonds Inner- Ausserschwyz','Nothilfefonds Inner- Ausserschwyz',NULL,NULL,NULL,1,0,'ehemalige KGS Uri/Schwyz,KGS ZG-UR-SZ,HS Zürich',0,0
UNION ALL SELECT 15,NULL,'Patenschaftsfonds UR SZ ZG','Patenschaftsfonds UR SZ ZG',NULL,NULL,NULL,1,0,'ehemalige KGS Uri/Schwyz,KGS ZG-UR-SZ,HS Zürich',0,0
UNION ALL SELECT 16,NULL,'Audiolesi, fondo','Fondo audiolesi',NULL,NULL,NULL,1,0,'DCN TI,HS Zürich',0,0
UNION ALL SELECT 17,NULL,'Bambini Cerebolesi, fondo','Fondo Bambini Cerebolesi',NULL,NULL,NULL,1,0,'DCN TI,HS Zürich',0,0
UNION ALL SELECT 18,NULL,'Nessi, fondo','Fondo nessi',NULL,NULL,NULL,1,0,'DCN TI,HS Zürich',0,0
UNION ALL SELECT 19,NULL,'Padrinati TI','Padrinati TI',NULL,NULL,NULL,1,0,'DCN TI,HS Zürich',0,0
UNION ALL SELECT 20,'PAH-Cantone TI','PAH Cantone TI','PAH Cantone TI',NULL,NULL,NULL,1,0,'DCN TI,HS Zürich',0,0
UNION ALL SELECT 21,NULL,'Peretti, fondo','Fondo Peretti',NULL,NULL,NULL,1,0,'DCN TI,HS Zürich',0,0
UNION ALL SELECT 22,NULL,'Brantomy, Fonds','Fonds Brantomy','Finanzierung Dienstleistungen (ED)',NULL,NULL,1,0,'KGS TG-SH,HS Zürich',0,1
UNION ALL SELECT 23,'FLB-Kanton TG/SH','FLB Kanton TG/SH','FLB Kanton TG/SH',NULL,NULL,NULL,1,0,'KGS TG-SH,HS Zürich',0,0
UNION ALL SELECT 24,NULL,'Patenschaften TG/SH','Patenschaften TG/SH',NULL,NULL,NULL,1,0,'KGS TG-SH,HS Zürich',0,0
UNION ALL SELECT NULL,NULL,'Fonds Luciana Bonazza Simonato','Fonds Luciana Bonazza Simonato','Finanzierung Dienstleistungen',NULL,NULL,1,0,'KGS TG-SH,HS Zürich',0,1
UNION ALL SELECT NULL,NULL,'Aeschlimann, Fonds Alfred','Fonds Alfred Aeschlimann','Finanzierung Dienstleistungen (Einkommensverwaltung, Mandate ZGB, BeWo)',NULL,NULL,1,0,'KGS TG-SH,HS Zürich',0,1
UNION ALL SELECT NULL,NULL,'Neff, Fonds','Fonds Neff-TG','für sprachgestörte Kinder im Kt. TG',NULL,NULL,1,0,'KGS TG-SH,HS Zürich',0,1
UNION ALL SELECT 25,'FLB-Kanton SO','FLB-Kanton SO','FLB-Kanton SO',NULL,NULL,NULL,1,0,'KGS Solothurn',1,0
UNION ALL SELECT 26,NULL,'Patenschaften SO','Patenschaften SO',NULL,NULL,NULL,1,0,'KGS Solothurn',1,0
UNION ALL SELECT 27,NULL,'CP Klienten AI','CP Klienten AI',NULL,NULL,NULL,1,0,'KGS SG-AI-AR,HS Zürich',0,0
UNION ALL SELECT 28,'FLB-Kanton SG/AI/AR','FLB Kanton SG/AI/AR','FLB Kanton SG/AI/AR',NULL,NULL,NULL,1,0,'KGS SG-AI-AR,HS Zürich',0,0
UNION ALL SELECT 29,NULL,'Maier J. und W.','Maier J. und W.',NULL,NULL,NULL,1,0,'KGS SG-AI-AR,HS Zürich',0,0
UNION ALL SELECT 30,NULL,'Patenschaften SG','Patenschaften SG',NULL,NULL,NULL,1,0,'KGS SG-AI-AR,HS Zürich',0,0
UNION ALL SELECT 31,NULL,'Adultes, fonds','Fonds Adultes',NULL,'montant unique',NULL,1,0,'DCN JU-NE,HS Zürich',0,0
UNION ALL SELECT 32,NULL,'Jérémie, fonds','Fonds Jérémie',NULL,'montant unique',NULL,1,0,'DCN JU-NE,HS Zürich',0,0
UNION ALL SELECT 33,NULL,'Jeunesse, fonds','Fonds Jeunesse',NULL,'montant unique',NULL,1,0,'DCN JU-NE,HS Zürich',0,0
UNION ALL SELECT 34,'PAH-Canton JU/NE','PAH canton JU/NE','PAH canton JU/NE',NULL,NULL,NULL,1,0,'DCN JU-NE,HS Zürich',0,0
UNION ALL SELECT 42,NULL,'Parrainages JU','Parrainages JU',NULL,NULL,NULL,1,0,'DCN JU-NE,HS Zürich',0,1
UNION ALL SELECT 35,NULL,'Parrainages NE','Parrainages NE',NULL,NULL,NULL,1,0,'DCN JU-NE,HS Zürich',0,1
UNION ALL SELECT 36,NULL,'Prêts, fonds','Fonds Prêts',NULL,'montant unique',NULL,1,0,'DCN JU-NE,HS Zürich',0,0
UNION ALL SELECT 37,'FLB-Kanton LU/NW/OW','FLB Kanton LU/NW/OW','FLB Kanton LU/NW/OW',NULL,NULL,NULL,1,0,'KGS LU-OW-NW,HS Zürich',0,0
UNION ALL SELECT 38,NULL,'Patenschaften LU-NW-OW','Patenschaften LU-NW-OW',NULL,NULL,NULL,1,0,'KGS LU-OW-NW,HS Zürich',0,0
UNION ALL SELECT 39,NULL,'Accompagnement à domicile, fonds','Fonds Accompagnement à domicile',NULL,NULL,NULL,1,0,'DCN JU-NE,HS Zürich',0,0
UNION ALL SELECT 40,NULL,'Hofstetter, fonds','Fonds Hofstetter',NULL,'montant unique',NULL,1,0,'DCN JU-NE,HS Zürich',0,0
UNION ALL SELECT 43,NULL,'Rhumatisme, ligue jurassienne contre le','Ligue jurassienne contre le rhumatisme',NULL,NULL,NULL,1,0,'DCN JU-NE,HS Zürich',0,0
UNION ALL SELECT 44,NULL,'Caflisch Stiftung, C.+E.','C. und E. Caflisch Stiftung',NULL,NULL,NULL,1,0,'KGS GR,HS Zürich',0,0
UNION ALL SELECT 45,NULL,'Coray, Legat','Legat Coray',NULL,NULL,NULL,1,0,'KGS GR,HS Zürich',0,0
UNION ALL SELECT 46,'FLB-Kanton GR','FLB Kanton GR','FLB Kanton GR',NULL,NULL,NULL,1,0,'KGS GR,HS Zürich',0,0
UNION ALL SELECT 47,NULL,'Patenschaften GR','Patenschaften GR',NULL,NULL,NULL,1,0,'KGS GR,HS Zürich',0,0
UNION ALL SELECT 48,'FLB-Kanton GL','FLB Kanton GL','FLB Kanton GL',NULL,NULL,NULL,1,0,'KGS GL,HS Zürich',0,0
UNION ALL SELECT 49,NULL,'GGG Kinder und Jugendliche, Fonds für','GGG Fonds für Kinder und Jugendliche',NULL,NULL,NULL,1,0,'KGS GL,HS Zürich',0,0
UNION ALL SELECT 50,NULL,'Patenschaften GL','Patenschaften GL',NULL,NULL,NULL,1,0,'KGS GL,HS Zürich',0,0
UNION ALL SELECT 51,NULL,'Meuron, fonds','Fonds Meuron',NULL,NULL,NULL,1,0,'DCN GE,HS Zürich',0,0
UNION ALL SELECT 52,'PAH-Canton GE','PAH canton GE','PAH canton GE',NULL,NULL,NULL,1,0,'DCN GE,HS Zürich',0,0
UNION ALL SELECT 53,NULL,'Parrainages GE','Parrainages GE',NULL,NULL,NULL,1,0,'DCN GE,HS Zürich',0,0
UNION ALL SELECT 54,NULL,'Scolarité spéciale, fonds','Fonds scolarité spéciale',NULL,NULL,NULL,1,0,'DCN GE,HS Zürich',0,0
UNION ALL SELECT NULL,NULL,'Golaz, fonds','Fonds Golaz',NULL,NULL,NULL,1,0,'DCN GE,HS Zürich',0,1
UNION ALL SELECT 55,'PAH-FLB FR','PAH FLB canton FR','PAH-FLB canton FR',NULL,NULL,NULL,1,0,'DCN FR,HS Zürich',0,0
UNION ALL SELECT 56,NULL,'Parrainages FR','Parrainages FR',NULL,NULL,NULL,1,0,'DCN FR,HS Zürich',0,0
UNION ALL SELECT 57,NULL,'Drei-König-Fonds','Drei-König-Fonds',NULL,NULL,NULL,1,0,'KGS BS,HS Zürich',0,0
UNION ALL SELECT 58,'FLB-Kanton BS','FLB Kanton BS','FLB Kanton BS',NULL,NULL,NULL,1,0,'KGS BS,HS Zürich',0,0
UNION ALL SELECT 59,NULL,'Patenschaften BS','Patenschaften BS',NULL,NULL,NULL,1,0,'KGS BS,HS Zürich',0,0
UNION ALL SELECT 60,NULL,'Schaub-Fonds, Emma','Emma Schaub-Fonds',NULL,NULL,NULL,1,0,'KGS BS,HS Zürich',0,0
UNION ALL SELECT 61,'FLB-Kanton BL','FLB Kanton BL','FLB Kanton BL',NULL,NULL,NULL,1,0,'KGS BL,HS Zürich',0,1
UNION ALL SELECT 62,NULL,'Mosaik, Fonds Stiftung','Fonds Stiftung Mosaik','Für Familien (mindestens 2 Generationen im gleichen Haushalt, eine davon minderjährig oder in Ausbildung).',NULL,NULL,1,0,'KGS BL,HS Zürich',0,1
UNION ALL SELECT 63,'FLB-PAH BE','FLB-PAH canton BE','FLB-PAH canton BE',NULL,NULL,NULL,1,0,'KGS BE,HS Zürich',0,1
UNION ALL SELECT 64,NULL,'Hilfskredit','Hilfskredit',NULL,NULL,NULL,1,0,'KGS BE,HS Zürich',0,1
UNION ALL SELECT 65,NULL,'MpB, Fonds/fonds Phpsy','Fonds für Menschen mit psychischer Behinderung/Fonds pour personnes en situation de handicap par suite de troubles psychiques','Behinderung: Psychische Erkrankung','handicap : maladie psychique',NULL,1,0,'KGS BE,HS Zürich',0,1
UNION ALL SELECT 66,NULL,'Patenschaften/Parrainages BE','Patenschaften/Parrainages BE',NULL,NULL,NULL,1,0,'KGS BE,HS Zürich',0,1
UNION ALL SELECT 67,NULL,'Rheumaliga Bern/Ligue bernoise contre le rhumatisme','Fonds Rheumaliga Bern/Fonds Ligue bernoise contre le rhumatisme',NULL,NULL,NULL,1,0,'KGS BE,HS Zürich',0,1
UNION ALL SELECT 68,NULL,'Rosa Roth Fonds','Rosa Roth Fonds',NULL,NULL,NULL,1,0,'KGS BE,HS Zürich',0,0
UNION ALL SELECT 69,NULL,'Familienfonds','Familienfonds der Pro Infirmis Aargau',NULL,NULL,NULL,1,0,'KGS AG-SO,HS Zürich',0,0
UNION ALL SELECT 70,'FLB-Kanton AG','FLB Kanton AG/SO','FLB Kanton AG/SO',NULL,NULL,NULL,1,0,'KGS AG-SO,HS Zürich',0,0
UNION ALL SELECT 71,NULL,'Patenschaften AG/SO','Patenschaften AG/SO',NULL,NULL,NULL,1,0,'KGS AG-SO,HS Zürich',0,0
UNION ALL SELECT NULL,'PAH-FLB VS','PAH-FLB canton VS','PAH-FLB canton VS',NULL,NULL,NULL,1,0,'KGS Emera Valais,HS Zürich',0,1
UNION ALL SELECT NULL,NULL,'Emera Valais, fonds interne','Fonds interne Eméra Valais fonds interne',NULL,NULL,NULL,1,0,'KGS Emera Valais,HS Zürich',0,1
UNION ALL SELECT 72,NULL,'à Porta-Stiftung, Dr. Stephan','Dr. Stephan à Porta-Stiftung','Unterstützung von wohltätigen und gemeinnützigen Institutionen',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 73,NULL,'Abraham-Stiftung, Kurt','Kurt Abraham-Stiftung','Hilfe an Körperbehinderte in der Ostschweiz. Der Zweck der Stiftung besteht im besonderen in der Unterstützung mittelloser Patienten der Gebiete Orthopädie und Querschnittlähmung, von geistig Behinderten.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 74,NULL,'Aladdin-Stiftung','Aladdin-Stiftung','Familien mit schwerkranken und behinderten Kindern',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 75,NULL,'Albisser-Stiftung, H.P.','H.P. Albisser-Stiftung','Kommunikationsmittel für körperlich und geistig Behinderte',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 76,NULL,'Anker Verein für Psychisch Kranke Aargau','Anker Verein für Psychisch Kranke Aargau','Unterstützung und Koordination aller Bestrebungen und Projekte zur gesellschaftlichen und  beruflichen Integration v. Menschein mit einer psychischen Krankheit oder Behinderung',NULL,NULL,2,0,'KGS AG-SO',0,0
UNION ALL SELECT 77,NULL,'Appuis aux Ainés, association','Association Appuis aux Ainés',NULL,'personnes de plus de 60 ans ou en préretraite, suisse ou permis C, revenus modestes',NULL,2,0,'DCN GE',0,0
UNION ALL SELECT 78,NULL,'ASRIM','Association de la Suisse Romande et italienne contre les Myopathies',NULL,'maladies neuromusculaires',NULL,2,0,'DCN GE,DCN VD,DCN FR,DCN JU-NE,DCN Jura,KGS BE,DCN TI',0,0
UNION ALL SELECT 79,NULL,'Aubry-Kappeler-Stiftung, Louise','Louise Aubry-Kappeler-Stiftung',NULL,NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 80,NULL,'Autismus, Stiftung','Stiftung Autismus','Behinderung: Autismus. Ferien, Therapie, Einzelhilfe.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 81,NULL,'Barbour, fondation','Fondation Barbour',NULL,'aide pour les personnes de conditions modestes, formation pour les jeunes',NULL,2,0,'DCN GE',0,0
UNION ALL SELECT 82,NULL,'Barell-Stiftung, C.','C. Barell-Stiftung',NULL,NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 83,NULL,'Bäuerlicher Solidaritätsfonds Bern, Stiftung','Stiftung bäuerlicher Solidaritätsfonds Bern','soll der Landwirtschaft dienen, insbesondere der Entschuldung, Darlehenshilfe','s''engage en faveur de l''agriculture. Elle intervient dans le domaine du désendettement et de l''aide au crédit.',NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 84,NULL,'Baumann Stiftung, Stefanie und Wolfgang','Stefanie und Wolfgang Baumann Stiftung',NULL,NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 85,NULL,'BAZ hilft Not lindern','Basler Zeitung hilft Not lindern',NULL,NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 86,NULL,'Bebié Stiftung','Bebié Stiftung','zh. Fischer Recht/Law Rechtsanwalt, Casinoplatz 8, 3011 Bern.Unterstützung von mittellosen, bedürftigen Menschen in der Stadt Bern',NULL,NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 87,NULL,'Beer Stiftung, Geschwister Albert und Ida','Geschwister Albert und Ida Beer Stiftung','Unterstützung bedürftiger, im Kanton Zürich wohnender Einzelpersonen',NULL,NULL,2,0,'KGS ZH',0,0
UNION ALL SELECT 88,NULL,'Benes Fonds, Maria','Maria Benes Fonds','Für bedürftige Familien im Kanton Luzern',NULL,NULL,2,0,'DCN Jura',0,0
UNION ALL SELECT 89,NULL,'Berghilfe, Schweizer','Schweizer Berghilfe','Alle Behinderungen. Beschränkt auf Menschen im Berggebiet, besonders Landwirtschaft, Gewerbe',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 90,NULL,'Bernays-Richard Stiftung, Alfred und Gertrud','Alfred und Gertrud Bernays-Richard-Stiftung','Körperliche und geistige Behinderungen, Leistungen an berufliche Eingliederung',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 91,NULL,'Bersinger Stiftung','Bersinger Stiftung','von der Frauenzentrale des Kantons St. Gallen verwaltet',NULL,NULL,2,0,'DCN JU-NE',0,0
UNION ALL SELECT 92,NULL,'Bischofberger Stiftung, Jacques','Stiftung Jacques Bischofberger','Unterstützung und Förderung wohltätiger Institutionen',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 93,NULL,'Bloch-Hauser-Stiftung, Felix','Felix Bloch-Hauser-Stiftung',NULL,NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 94,NULL,'Blüchert Stiftung, Walter F.','Walter F. Blüchert Stiftung','Ausschliesslich und direkte Unterstützung von minderbemittelten Einzelpers. auch in Alters- und Pflegeheimen, die infolge ihres körpelichen oder geistigen Zustandes oder ihrer wirtschaftlichen Not dringend der Hilfe bedürfen.',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 95,NULL,'Bock Stiftung, Martha','Martha Bock Stiftung','Unterstützung von im Kanton Zürich wohnhaften bedürftigen reformierten Betagten und Behinderten',NULL,NULL,2,0,'KGS ZH',0,0
UNION ALL SELECT 96,NULL,'Bolle Stiftung, Martin und Agnes','Martin & Agnes Bolle Stiftung','Beitrag an Institutionen, die sich mit Blinden, CP, Geistigbehinderten und verhaltensauffälligen Kindern befassen',NULL,NULL,2,0,'HS Zürich',0,0
UNION ALL SELECT 97,NULL,'Boner Stiftung','Boner Stiftung für Kunst und Kultur','u.a. Unterstützung von sozialen Werken und notleidenden Personen im Kanton Graubünden',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 98,NULL,'Bonna-Rapin fondation, Berthe','Fondation Berthe Bonna-Rapin',NULL,'Personnes dès 55 ans, se trouvant, par suite de revers de fortune, de suppression totale ou partielle de revenus, dans l''impossibilité de terminer décemment leur vie. Nationalité genevoise ou confédérée, religion protestante, habitant le canton de Genève',NULL,2,0,'DCN GE',0,0
UNION ALL SELECT 99,NULL,'Brändli-Stiftung, Walter, Ruedi und Emma','Walter, Ruedi und Emma Brändli-Stiftung','Behinderung: Ohne geistige oder psych. Behinderung. Bis 30jährig.',NULL,NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 100,NULL,'Brenn-Buri, Stiftung, Dr. Hans und Lydia','Stiftung Dr. Hans und Lydia Brenn-Buri','Für Parkinsonpatienten',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 101,NULL,'Brennwald-Schmid Fonds, Emil','Emil Brennwald-Schmid Fonds','Beiträge an Kinder schweizerischer Nationalität, für welche infolge geistiger, psychischer oder körperlicher Invalidität, Krankheit oder Unfall besondere ärztlich oder heilpädagogisch allgemein anerkannte Auslagen entstehen,... Dabei sind in erster Linie die Bewohner der Berggemeinden zu berücksichtigen.',NULL,NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 102,NULL,'Bruderer-Schwendener, U., Nachlass','Nachlass U. Bruderer-Schwendener','Finanzierung nur von konkreten Projekten für körperlich oder geistig behinderte Kinder und Jugendliche, so auch für Aus- und Weiterbildungen',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 103,NULL,'Bucher-Gossweiler-Stiftung, Anna und Paul','Anna und Paul Bucher-Gossweiler-Stiftung','In erster Linie soll landwirtschaftliches Dienstpersonal unterstützt werden, das durch Alter, Krankheit, Invalidität oder sonstwie in der Erwerbsfähigkeit beschränkt ist, sowie frühere selbständige Landwirte, betagte und bedürftigte Kleinbauern und deren Familien, welche durch unverschuldete Ereignisse in Bedrängnis geraten sind.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 104,NULL,'Bucher-Stiftung, Margarite','Margarite Bucher-Stiftung','Unterstützung von wohltätigen Institutionen',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 105,NULL,'Buchmann-Kollbrunner-Stiftung','Buchmann-Kollbrunner-Stiftung','Unterstützung von körperlich oder geistig behinderten Personen im Kanton Zürich',NULL,NULL,2,0,'KGS ZH',0,0
UNION ALL SELECT 106,NULL,'Burkhard-Stiftung, Marianne','Marianne Burkhard-Stiftung','Schwer kranke/geschädigte Kinder und deren Eltern oder Betreuer',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 107,NULL,'Büttner-Stiftung, Franz und Verena','Franz und Verena Büttner-Stiftung','Bezweckt die Unterstützung von Schwergeschädigten',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 108,NULL,'Caritas, Region','Caritas, Region','Alle Behinderungen. Sich an die zuständige Regionalstelle wenden. Regional unterschiedliche Direkthilfe-Leistungen. Einzelne Regionen leisten keine finanzielle Direkthilfe.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 109,NULL,'Casal Bernard, Stiftung','Stiftung Casal Bernhard','Nur Bündner',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 110,NULL,'Cassinelli-Vogel-Stiftung','Cassinelli-Vogel-Stiftung','Einmalige Beiträge zur Überbrückung vorübergehender Notlage',NULL,NULL,2,0,'KGS ZH',0,0
UNION ALL SELECT 111,NULL,'Casty-Buchmann, Stiftung','Stiftung Casty-Buchmann','Nur ganz definierte Vergabungen',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 112,NULL,'Cattori-Stuern, fondazioni, Lorenzo e Elsa','Fondazione Lorenzo e Elsa Cattori e Stuern',NULL,NULL,NULL,2,0,'DCN TI',0,0
UNION ALL SELECT 113,NULL,'Cerebral Gelähmte Basel, Stiftung für','Stiftung für cerebral Gelähmte Basel',NULL,NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 114,NULL,'Cerebral, Stiftung','Stiftung Cerebral','Behinderungen: Cerebral, spina bifida, Muskeldystrophie. Nur, wenn 40% eigene PI Mittel eingesetzt werden. Autos max. Fr. 3000.-',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 115,NULL,'Comedia Schweiz','Comedia Schweiz','Für Mitglieder der Gewerkschaft. Max. Fr. 1''500.-',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 116,NULL,'Conférences de St-Vincent de Paul','Conférences de St-Vincent de Paul',NULL,NULL,NULL,2,0,'DCN FR',0,0
UNION ALL SELECT 117,NULL,'Coop Patenschaft für Berggebiete','Patenschaft Coop für Berggebiete','Bergbevölkerung Zonen I - IV',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 118,NULL,'Coray-Stiftung, Dr. med. Albert','Dr. med. Albert Coray-Stiftung','Unterstützung von kranken und pflegebedürftigen Kindern bei auswärtiger Hospitalisation',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 119,NULL,'das behinderte Kind, Stiftung für','Stiftung für das behinderte Kind','www.behinderteskind.ch. Förderung und Unterstützung aller Art im Interesse und zum Nutzen von geistig und organisch behinderten Kindern in der CH',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 120,NULL,'Das Leben meistern, Stiftung','Stiftung "Das Leben meistern"','Schweizer Familien ab 3 Kindern',NULL,NULL,2,0,'KGS BE,DCN FR,KGS Solothurn',0,0
UNION ALL SELECT 121,NULL,'Dätwyler Stiftung','Dätwyler Stiftung',NULL,NULL,NULL,2,0,'ehemalige KGS Uri/Schwyz,KGS ZG-UR-SZ',0,0
UNION ALL SELECT 122,NULL,'Denk an mich, Stiftung','Stiftung "Denk an mich"','Ferien für geistig / körperlich behinderte und ihre Angehörigen',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 123,NULL,'Désendettement, fondation genevoise de,','Fondation genevoise de désendettement',NULL,'prêts d''honneur, domicilié à Genève, 18 ans revenus',NULL,2,0,'DCN GE',0,0
UNION ALL SELECT 124,NULL,'Diakonie-Rappen','Diakonie-Rappen','Unterstützung in Notsituationen',NULL,NULL,2,0,'KGS AG-SO',0,0
UNION ALL SELECT 125,NULL,'Dreifuss-Stiftung, Theodor und Bernhard','Theodor und Bernhard Dreifuss-Stiftung','Unterstützung von bedürftigen alten und/oder gebrechlichen Menschen; Unterstützung in der Erziehung von Not leidenden und bedürftigen Kindern; Förderung der Weiterbildung von jungen Leuten',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 126,NULL,'Duvillard, fondation','Fondation Duvillard',NULL,'personnes domiciliées en Gruyère, jusqu''à l''âge de 20 ans',NULL,2,0,'DCN FR',0,0
UNION ALL SELECT 127,NULL,'Elsener-Gut Stiftung, Carl und Elise','Carl und Elise Elsener-Gut Stiftung','Unterstützung von psychich kranken, körperlich und geistig behinderten Menschen.',NULL,NULL,2,0,'KGS Solothurn',0,0
UNION ALL SELECT 128,NULL,'Evangelische Bürgschaftsgenossenschaft','Evangelische Bürgschaftsgenossenschaft','Gewähren Darlehen; auch für Schulden',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 129,NULL,'Evangelischer Kirchenrat des Kantons GR','Evangelischer Kirchenrat des Kantons GR','Angehörige der evang. Landeskirche',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 130,NULL,'Evangelischer Waisenhilfsverein, Bündner','Bündner evangelischer Waisenhilfsverein',NULL,NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 131,NULL,'Familienhilfe Bern, Stiftung','Stiftung Familienhilfe Bern','Unterstützung bedrängter Familien mit Kind(ern), minderjährig oder in Ausbildung. Z.B. Überbrückung von Notsituationen (Erholungsaufent-halte, Familienferien, Spitex, Kinderbetreuung), Verbesserung der Lebensqualität (Waschmaschinen, Kinderbetten), Beiträge an Aus- oder Weiterbildungen, soweit Stipendien fehlen. Wenn es um behinderungsbedingte Auslagen geht, muss gut begründet sein, weshalb nicht PI finanzieren kann. Entscheidsitzungen alle 2 Monate; es ist wenig Geld vorhanden.',NULL,NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 132,NULL,'Fischer-Stiftung, Roman','Roman-Fischer-Stiftung','Für Menschen mit Behinderung, Hilfsmittel für Sehbehinderte  (v.a. Brillen oder med. Kosten)',NULL,NULL,2,0,'KGS LU-OW-NW',0,0
UNION ALL SELECT 133,NULL,'Fontheim-Stiftung, Kurt','Kurt Fontheim-Stiftung','Förderung der Ausbilung junger Menschen durch Gewähr von Stipendien.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 134,NULL,'Förderung der sozialen Wohnungsvermittlung, Stiftung zur','Stiftung zur Förderung der sozialen Wohnungsvermittlung',NULL,NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 135,NULL,'Förderung körperbehinderter Hochbegabter, Stiftung zur','Stiftung zur Förderung körperbehinderter Hochbegabter','Körper- und sinnesbehinderte Personen, welche nach objektiven Kriterien als begabt gelten. Nur Ausbildungskosten.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 136,NULL,'Fossati fondazione filatropica, Danilo e Luca','Fondazione filatropica Danilo e Luca Fossati',NULL,NULL,'a favore di persone svantaggiate in ragione di condizione fisiche, psichiche, economiche',2,0,'DCN TI',0,0
UNION ALL SELECT 137,NULL,'Fram Stiftung','Fram Stiftung','Finanzielle Unterstützung von Kindern und deren Familien in akuten Notlagen, insbesondere zur Entlastung bei schwerstbehinderten Kindern und deren Familie. Wohnsitz in erster Linie der Kanton Bern.','Soutien financier aux enfants et leurs familles qui sont confrontées à des difficultés aigües, en particulier les enfants très gravement handicapés et leur famille. Les familles domiciliées à Berne ont la priorité.',NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 138,NULL,'Frauen in Not, Fonds, Frauenzentrale Zug','Fonds Frauen in Not der Frauenzentrale Zug',NULL,NULL,NULL,2,0,'KGS ZG-UR-SZ',0,0
UNION ALL SELECT 139,NULL,'Freibettenfond der verschiedenen Spitäler','Freibettenfond der verschiedenen Spitäler',NULL,NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 140,NULL,'Fürsorgefonds Militärpatienten, des Bundes Schweizerischer','Fürsorgefonds des Bundes Schweizerischer Militärpatienten','Unterstützt bedürftigte Militärpatienten',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 141,NULL,'Gademann-Bircher-Stiftung, Lilli','Lilli-Gademann-Bircher-Stiftung','Unterstützung von Institutionen im erzieherischen, therapeutischen und bildnerischen Bereich',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 142,NULL,'Galvanone, fondazione, Elia','Fondazione Elia Galvanone',NULL,NULL,'Aiutare persone disabili e le loro famiglie in particolare bambini cerebolesi e strutture che operano in loro favore.',2,0,'DCN TI',0,0
UNION ALL SELECT 143,NULL,'Ganz-Murkowsky-Fonds, Ella','Ella Ganz-Murkowsky-Fonds','Unterstützungs- und Ausbildungskosten an benachteiligte Kinder und Jugendliche bis zum 20. Altersjahr im Kanton Bern',NULL,NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 144,NULL,'Gemeinnützige Gesellschaft, kantonale Organisation','Gemeinnützige Gesellschaft, kantonale Organisation','Kantonal unterschiedliche Leistungen, zum Teil sogar nach Bezirk',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 145,NULL,'Gemeinnützige Gesellschaft, Schweizerische','Schweizerische Gemeinnützige Gesellschaft','Alle Behinderungen. Diverse Fonds/Stiftungen. Nur für EL- oder Sozialhilfebezüger/innen. Da sonst zur Bedingung gestellt wird, dass Gemeinde/Kanton einen Steuererlass gewährt, bevor das bewilligte Gesuch ausbezahlt wird.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 146,NULL,'Gialdini, fondation, Giovanni et Mariora','Fondation Giovanni et Mariora Gialdini',NULL,'Octroi de subsides, de secours, de dons ou de prêts sans intérêts en faveur d''aveugles, d''enfants jusqu''à 20 ans, de vieillards, de personnes infirmes, malades, délaissées ou indigentes.uniquement pour frais en Suisse',NULL,2,0,'DCN FR,DCN GE,DCN JU-NE,DCN Jura,DCN VD',0,0
UNION ALL SELECT 147,NULL,'Girod, fondation, Dr. Renée','Fondation Dr Renée Girod',NULL,'Femmes vivant seules ou avec des ascendants ou descendants à leur charge et ne disposant que d''un revenu modeste. Dans l''ordre de préférence : genevoises, confédérées, étrangères',NULL,2,0,'DCN GE',0,0
UNION ALL SELECT 148,NULL,'Glückskette','Glückskette','Alle Behinderungen. Pro Person max. Fr. 600.-',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 149,NULL,'Gotthelfverein, Ämter Aarberg und Erlach','Gotthelfverein und Verein für Familienschutz der Ämter Aarberg und Erlach und angrenzenden Gemeinden','Kinder, Jugendliche, Familien, welche sich in einem finanziellen Engpass befinden',NULL,NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 150,NULL,'Graber-Brack Stiftung','Graber-Brack Stiftung','Soziale Stiftung nur für Bezirk Aarau',NULL,NULL,2,0,'KGS AG-SO',0,0
UNION ALL SELECT 151,NULL,'Gschwend-Fonds, Norbert','Nobert Gschwend-Fonds','für Rheumapatienten Hilfsmittel, ergotherapeutische Massnahmen, Therapien, Erholungsurlaub, Transporthilfe',NULL,NULL,2,0,'DCN FR',0,0
UNION ALL SELECT 152,NULL,'Gürtler-Stiftung, Emil und Beatrice, Schnyder von Wartensee','Emil und Beatrice Gürtler-Schnyder von Wartensee Stiftung','Einreichen via KGS Bern (Antrag KGL). Alle Behinderungen, ohne Alterseinschränkung',NULL,NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 153,NULL,'Hatt Bucher Stiftung','Hatt Bucher Stiftung','Senioren ab 60 Jahren',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 154,NULL,'Häuptli Stiftung, Fanny','Fanny Häuptli Stiftung','Auszahlungen an Unbemittelte für Gesundheitskuren, welche nicht von der Krankenkasse übernommen werden.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 155,NULL,'Heimgartner-Stiftung, Christian','Christian Heimgartner-Stiftung','Unterstützung von Jugendlichen in Ausbildung aus bedürftigen Familien bis zur Vollendung ihrer beruflichen Ausbildung (Erstausbildung)',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 156,NULL,'Helfer und Schlüter-Stiftung','Helfer und Schlüter-Stiftung','Körperbehinderte, insbesondere MS und neurologische Krankheiten. Max. Fr. 5''000.-, bei MS bis 8''000.-',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 157,NULL,'Hertner-Strasser Stiftung, Wilhelm und Jda','Wilhelm und Jda Hertner-Strasser Stiftung',NULL,NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 158,NULL,'Herzog-Theler Stiftung','Herzog-Theler Stiftung','Für bedürftige Kinder im Kanton Luzern',NULL,NULL,2,0,'DCN Jura',0,0
UNION ALL SELECT 159,NULL,'Hilfe für Mutter und Kind, Stiftung','Stiftung "Hilfe für Mutter und Kind"','Unterstützung von Familien, Müttern oder Vätern und ihrer Kinder in Notsituatonen.',NULL,NULL,2,0,'KGS AG-SO',0,0
UNION ALL SELECT 160,NULL,'Hilfsbund, Bernischer','Bernischer Hilfsbund zur Bekämpfung der extrathorakalen Tuberkulose','Finanzielle Hilfe bei Tuberkulose und anderen langdauerenden Krankheiten mit Ausnahme der Lungenleiden.',NULL,NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 161,NULL,'Hilfsverein für psychisch kranke Menschen','Hilfsverein für psychisch kranke Menschen','Nur für psychisch Kranke',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 162,NULL,'Hören & Verstehen, Stiftung, pro audito','Stiftung Hören und Verstehen, pro audito','Für Schwerhörige und Spätertaubte. Beiträge an Hörgeräte und Weiterbildung. Ebenfalls an Massnahmen zur Hebung der Versorgungsqualität Schwerhöriger mit Hörgeräten.',NULL,NULL,2,0,'KGS BE,KGS Solothurn,KGS AG-SO',0,0
UNION ALL SELECT 163,NULL,'Horizonte Stiftung, Basel','Stiftung Horizonte, Basel',NULL,NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 164,NULL,'Huber-Graf und Billeter-Graf-Stiftung','Huber-Graf und Billeter-Graf-Stiftung','Fürsorge für blinde, taubstumme, behinderte und gebrechliche Personen mit Wohnsitz im Kt. Zürich',NULL,NULL,2,0,'KGS ZH',0,0
UNION ALL SELECT 165,NULL,'Hülfsgesellschaft in Zürich','Hülfsgesellschaft in Zürich','In Notlage Geratene mit Wohnsitz im Kanton Zürich ohne Bezirk Winterthur',NULL,NULL,2,0,'KGS ZH',0,0
UNION ALL SELECT 166,NULL,'Hülfsgesellschaft Winterthur, Stiftung','Stiftung "Hülfsgesellschaft Winterthur"','Nur Region Winterthur. Unterstützung zur Linderung materieller Not oder zur Förderung der Ausbildung',NULL,NULL,2,0,'KGS ZH',0,0
UNION ALL SELECT 167,NULL,'Humanitas Stiftung','Stiftung Humanitas','Beiträge zur Vermeidung von Notfällen. Geschäftsführung: Seehofstrasse 6, 8008 Zürich. Präsidentin: E. Ringier.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 168,NULL,'Internationale Stiftung der Familie','Internationale Stiftung der Familie','Förderung und Unterstützung von Initiativen zugunsten der Familie. Im Rahmen dieses Zwecks verfolgt die Stiftung verschiedene Tätigkeiten mit dem Ziele, die Ausbildung der Eltern in ihrer Erzieherrolle zu verbessern.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 169,NULL,'Ja zum Leben, Regionalstelle','Ja zum Leben, Regionalstelle','finanzielle Unterstützung von Schwangeren oder Müttern v. Neugeborenen',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 170,NULL,'Jenner-Stiftung Bern','Jenner-Stiftung Bern','Kinder, Krankheit, Behinderung',NULL,NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 171,NULL,'Jenni-Stiftung, Paul Josef','Paul Josef Jenni-Stiftung',NULL,NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 172,NULL,'Johnson Stiftung, Sir Stanley Thomas','Sir Stanley Thomas Johnson Stiftung','Förderbereich Stipendien: Unterstützung von bedürftigen, in der Regel jungen Menschen in Erst- und Zweitausbildung mit stipendienrechtlichem Wohnsitz im Kanton Bern. Die gewählte Ausbildung sollte zu verbesserten Berufschancen und besseren Existenzmöglichkeiten führen.',NULL,NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 173,NULL,'Jugendtag, Bärner','Bärner Jugendtag','Der BärnerJugendTag vergibt Ausbildungsbeiträge an junge Erwachsene unter 25 Jahren. Bei der Verwendung der Beiträge wirken die Jugendlichen aktiv mit.',NULL,NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 174,NULL,'Kaiser-Stiftung, Giuseppe','Giuseppe Kaiser-Stiftung','Körperlich und geistig behinderte Menschen. Stipendien für Kinder.',NULL,NULL,2,0,'HS Zürich',0,0
UNION ALL SELECT 175,NULL,'Kappeler Stiftung','Kappeler Stiftung','Unterstützung von körperlich und geistig Behinderten im Bezirk Baden',NULL,NULL,2,0,'KGS AG-SO',0,0
UNION ALL SELECT 176,NULL,'Katholischer Frauenbund GR','Katholischer Frauenbund GR','Einmalige Unterstützung bei gesundheitlichen und familiären Engpässen',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 177,NULL,'Katholischer Waisenunterstützungsverein GR','Katholischer Waisenunterstützungsverein GR',NULL,NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 178,NULL,'Katzenhilfe Bern, Verein','Verein Katzenhilfe Bern','Für ausserordentliche Katzenhaltungskosten (z.B. Operation nach Unfall oder Erkrankung). Keine ordentlichen Kosten, wie Impfen, Kastration, Medikamente oder Futter. Die eigenen Gesuchsformulare dürfen verwendet werden. Es ist wenig Geld vorhanden.',NULL,NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 179,NULL,'Kinder im Schatten, Verein','Verein Kinder im Schatten',NULL,NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 180,NULL,'Kinder und Jugendliche, Stiftung für','Schweizerische Stiftung für Kinder und Jugendliche','Alle Behinderungen. Kinder bis 18 Jahre und ihre Eltern.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 181,NULL,'Kirchliche Liebestätigkeit, Stiftung für','Stiftung für kirchliche Liebestätigkeit','Für Menschen mit einer Behinderung, die in einer Notlage sind. Grundsätzlich keine Einschränkungen','Pour les personnes handicapées qui se trouvent en difficulté. Par principe, pas de restriction.',NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 182,NULL,'Kirsch Marian & Zofia Stiftung','Marian und Zofia Kirsch Stiftung','Alle Behinderungen. Menschen mit polnischer Abstammung in der CH oder in Polen',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 183,NULL,'Kolping Stiftung','Kolping Stiftung','Einzelhilfe bei sozialen Härtefällen',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 184,NULL,'Kommission für Mütterferien Katholischer Frauenbund Basel-Stadt','Kommission für Mütterferien Katholischer Frauenbund Basel-Stadt',NULL,NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 185,NULL,'Kommission zur Mitfinanzierung von Erziehungshilfen, ggg Basel','Kommission zur Mitfinanzierung von Erziehungshilfen, ggg Basel',NULL,NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 186,NULL,'kranke Kinder in Basel, Stiftung für','Stiftung für kranke Kinder in Basel','Kranken Kindern, wohnhaft in Basel und Umgebung, zur Heilung zu verhelfen und ihnen ärztliche Hilfe und leibliche und geistige Pflege zu gewähren.',NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 187,NULL,'Krebsliga, regionale Organisation','Regionale Krebsliga','Nur für Krebspatienten',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 188,NULL,'Kunigunde + Heinrich Stiftung','Kunigunde + Heinrich Stiftung',NULL,NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 189,NULL,'Ledermann Stiftung, Peter','Stiftung Peter Ledermann','Personen im In- und Ausland, die durch Krankheit, Krieg, Naturkatastrophen, Unfall, Epidemien und dergleichen in finanzielle Not geraten sind. Keine Ausbildungsbeiträge.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 190,NULL,'Lienhard-Hunger, Stiftung, Ernst und Reta','Stiftung Ernst und Reta Lienhard-Hunger','Für Einzelpers. und Familien. Stiftung ist im christl. Sinne tätig, weshalb die Gesuche über die Landeskirchen behandelt werden.',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 191,NULL,'Lions Club','Lions Club','Alle Behinderungen. Sich an die zuständige Regionalstelle wenden. Regional unterschiedliche Leistungen.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 192,NULL,'LOBAG','LOBAG','Unterstützung aller Bauern (mit Vorteil Mitglied der LOBAG), die in einer Notlage sind. Starthilfe auch möglich. Bauer muss das Gesuch immer selber stellen.',NULL,NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 193,NULL,'Lord Michelham of Hellingly, fondation','Fondation Lord Michelham of Hellingly',NULL,'aide à la vieillesse dans le besoin et aux personnes handicapées; aide à la formation et à la recherche en matière technologique, dans tous les secteurs de l''économie, de manière à assister les efforts de développement des pays sous-développés',NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 194,NULL,'Lorétan-Pasquier, fondation, Rose','Fondation Rose-Lorétan-Pasquier',NULL,'personnes domiciliées à La Tour-de-Trême, Le Pâquier, Gruyère, Enney, Villars-sous-Mont, Estavannens, Grandvillard, Lessoc, Neirivue, Albeuve, Montbovon',NULL,2,0,'DCN FR',0,0
UNION ALL SELECT 195,NULL,'Loris, fondo','Fondo Loris',NULL,NULL,'persone bisognose o disabili residenti in Ticino',2,0,'DCN TI',0,0
UNION ALL SELECT 196,NULL,'Luchsinger Haggenmacher-Stiftung, SGG','Luchsinger Haggenmacher-Stiftung, SGG','Stiftung der Schweiz. Gemeinnützigen Gesellschaft. Alle Behinderungen, Alter bis 26 Jahre in der CH. Keine Beiträge an Ferien im Ausland.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 197,NULL,'Lungenliga, Kantonale Organisation','Lungenliga, Kantonale Organisation','Regional unterschiedliche Leistungen für die Zielgruppe.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 198,NULL,'Malamoud, Stiftung, Valentin','Stiftung Valentin Malamoud','Unterstützung von bedürftigen behinderten und/oder notleidenden Menschen, Flüchtlingen, wohltätigen Institutionen oder Einzelpersonen in ihren Bemühungen zur Linderung sozialer oder gesundheitlicher Notlagen',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 199,NULL,'Mano Stiftung','Stiftung Mano','Unterstützung der Erziehung, Ausbildung und Weiterbildung von hilfsbedürftigen Menschen, insbesondere von Alleinerziehenden und ihren Kindern',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 200,NULL,'Milchsuppe-Stiftung','Milchsuppe-Stiftung',NULL,NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 201,NULL,'Mimosa fonds, Croix-Rouge','Fonds Mimosa, Croix-Rouge',NULL,'S''adresser au service cantonal de la Croix Rouge. Par ex. camps de vacances pour mineurs et traitements orthodontiques',NULL,2,0,'DCN FR,DCN GE,DCN JU-NE,DCN Jura,DCN VD',0,0
UNION ALL SELECT 202,NULL,'Misteli-Stiftung, Louise','Louise Misteli-Stiftung','Alle Behinderungen, Witwen, Waisen. Beiträge für Erziehungs-, Ausbildungs- und andere öffentliche Zwecke',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 203,NULL,'Morath-Stiftung, Catherine und Harry','Catherine+Harry Morath-Stiftung',NULL,NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 204,NULL,'Multiple Sklerose Gesellschaft, Schweizerische','Schweizerische Multiple Sklerose Gesellschaft','MS, Amytrophe Lateralsklerose, Friedreichsche Ataxie. Autoanschaffung max. Fr. 5''000.-','MS, Amytrophe Lateralsklerose, Friedreichsche Ataxie. Autoanschaffung max. Fr. 5''000.-',NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 205,NULL,'Mundaun Stiftung, gemeinnützige','Gemeinnützige Stiftung Mundaun','Beiträge à Fonds perdu oder Darlehen für Einzelpers. oder Familien in Notlagen in finanzschwachen Gemeinden unter 200 Einwohner',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 206,NULL,'Mütter in Not, katholischer Frauenbund SG/AI/AR','katholischer Frauenbund St. Gallen-Appenzell',NULL,NULL,NULL,2,0,'KGS SG-AI-AR',0,0
UNION ALL SELECT 207,NULL,'Mütterhilfe Stiftung','Stiftung Mütterhilfe','Unterstützung in der neuen Lebensphase der Elternschaft',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 208,NULL,'Nene Fondazione','Fondazione Nene',NULL,NULL,'aver esaurito gli aiuti degli enti pubblici',2,0,'DCN TI',0,0
UNION ALL SELECT 209,NULL,'Nussbaumer-Simonin-Stiftung','Nussbaumer-Simonin-Stiftung','Geistig behinderte, insbesondere Trisomie 21 und deren Familien',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 210,NULL,'Ochsner-Stiftung, Max','Max Ochsner-Stiftung','Förderung der gesellschaftlichen Eingliederung behinderter und sozial benachteiligter Menschen durch Unterstützung ihrer beruflichen und persönlichen Weiterbildung.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 211,NULL,'OHOm, Ostschweizer helfen Ostschweizern','Ostschweizer helfen Ostschweizern','vom St. Galler Tagblatt jährliche Sammelaktion auf Weihnachten hin',NULL,NULL,2,0,'KGS SG-AI-AR,KGS GR,KGS TG-SH',0,0
UNION ALL SELECT 212,NULL,'OPOS Stiftung, zugunsten von Wahrnehmungsbehinderten','Stiftung OPOS zugunsten von Wahrnehmungsbehinderten',NULL,NULL,NULL,2,0,'DCN JU-NE',0,0
UNION ALL SELECT 213,NULL,'Ordòdy-König Stiftung, Ellionor','Ellionor von Ordòdy-König Stiftung','Die Stiftung bezweckt, Personen, die im Kanton St. Gallen oder in benachbarten Kantonen wohnen und die unverschuldet in Not geraten sind, mit angemessenen Unterstützungsbeiträgen beizustehen.',NULL,NULL,2,0,'KGS SG-AI-AR,KGS GR,KGS ZH,KGS TG-SH',0,0
UNION ALL SELECT 214,NULL,'Orphelina-Stifung','Orphelina-Stifung','Stiftung der Schweiz. Gemeinnützigen Gesellschaft. bezweckt die Förderung der Wohlfahrt von in der Schweiz sich dauernd oder vorübergehend aufhaltenden hilfsbedürftigen Kindern ohne Ansehen der Religion oder Nationalität. Eltern auf EL oder Sozialhilfeniveau. Mindestens Fr. 2''000.- beantragen.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 215,NULL,'Orthodoxe philanthropische Stiftung','Orthodoxe philanthropische Stiftung','Mit Rücksicht auf ihre Satzung und aufgrund ihrer beschränkten Mittel bearbeitet diese Stiftung nur Anträge von orthodoxen Christen mit Wohnsitz in der Schweiz.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 216,NULL,'Padella-Stiftung','Padella-Stiftung','Unterstützungsbeiträge an Einzelpersonen in Notsituationen',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 217,NULL,'Paraplegiker-Stiftung, Schweizerische','Schweizerische Paraplegiker-Stiftung','Behinderung: Praplegie, Tetraplegie. Betrag unbeschränkt. Uebrige Behinderungen: Rollstuhlbenutzer. Max. Fr. 4''000.-',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 218,NULL,'Pasquier fondation, Joseph','Fondation Joseph Pasquier',NULL,'enfants (parfois adultes) originaires de la Gruyère, pour études, formation, loisirs',NULL,2,0,'DCN FR',0,0
UNION ALL SELECT 219,NULL,'Patenschaft für Berggemeinden','Schweizerische Patenschaft für Berggemeinden','Alle Behinderungen, für Menschen im CH-Berggebiet.',NULL,NULL,2,0,'KGS BE,DCN FR,KGS LU-OW-NW,DCN FR,ehemalige KGS Uri/Schwyz,HS Zürich,DCN Jura,DCN TI,KGS SG-AI-AR,DCN VD,DCN JU-NE,KGS BS',0,0
UNION ALL SELECT 220,NULL,'Paulz-Stiftung','Paulz-Stiftung','Hilfeleistung eher in der Ausrichtung einmaliger Beiträge (z.B. für aussergewöhnliche Aufwendungen) als in monatlichen bzw. dauernden Unterstützungen für über 60 Jährige.',NULL,NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 221,NULL,'Pestalozzi Fonds, Bernischer','Bernischer Pestalozzi-Fonds','Finanzierung von Schulung, Erziehung, Ausbildung, Anlehre, Berufslehre und Eingliederung sowie Beiträge an Untersuchungen, Beratungen und Therapie für physisch, psychisch oder geistig behinderte oder sozial benachteiligte Kinder und Jugendliche bis 25-jährig mit Wohnsitz im Kanton Bern.',NULL,NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 222,NULL,'Pflegekinderaktion GR','Pflegekinderaktion GR','Für Kinder in Pflege',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 223,NULL,'Plussport Behindertensport','Plussport Behindertensport','Beiträge an Sporthilfsmittel und sportl. Aktivitäten',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 224,NULL,'Poletti fondation, Paul','Fondation Paul Poletti',NULL,'pour les enfants',NULL,2,0,'DCN GE',0,0
UNION ALL SELECT 225,NULL,'Post/Swisscom Personal, Wohlfahrtsfonds','Wohlfahrtsfonds des Post- und Swisscom-Personals','Alle Behinderungen, für Post- und Swisscom Mitarbeitende und Pensionierte',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 226,NULL,'Pro Aegrotis Stiftung','Stiftung Pro Aegrotis','Hilft Menschen, die zur Behandlung einer Krankheit, Behebung von Unfallfolgen, Verbesserung ihres Gesundheitszustandes oder für die Pflege zu Hause zusätzlicher, finanzieller Hilfe bedürfen. Keine Beiträge an Zahnbehandlung, Wohn-, Umzugs-, oder Ausbildungskosten.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 227,NULL,'Pro Juventute Kanton','Pro Juventute Kanton','Alle Behinderungen, für Familien, Kinder und Jugendliche bis 20 Jahre (in Ausbildung bis 25)',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 228,NULL,'Pro Juventute Schweiz, ZLWWW','Pro Juventute Schweiz, Zusatzleistungen an Witwer, Witwer und Waisen (ZLWWW)','Personen mit Witwen-, Witwer- oder Waisenrente. Personen mit Behinderung und Hinterlassenenleistung via PI CH, Direkthilfe',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 229,NULL,'Pro Senectute','Pro Senectute, Individuelle Finanzhilfe','Bundesmittel für Bezüger/innen von AHV-Leistungen. Auch für Personen, die die AHV vorbezogen haben (aktuell 62/63 Jahre). Sich bei der kantonalen PS-Organisation melden.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 230,NULL,'Quadri Stiftung, Franco, Marianne, Cristina und Gianni','Stiftung Franco, Marianne, Cristina und Gianni Quadri','Geistig behinderte Kinder, insbesondere Trisomie 21',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 231,NULL,'REKA, Schweizer Reisekasse, Jubiläumsstiftung','Jubiläumsstiftung der Schweizerischen Reisekasse','Alle Behinderungen. Ferien für wirtschaftlich und sozial Benachteiligte in der Schweiz.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 232,NULL,'Renfer-Stiftung, Dr. Eugen','Dr. Eugen Renfer-Stiftung','Alle Behinderungen, für medizinische und kieferorthopädische Behandlungen, max. Fr. 3''000.-',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 233,NULL,'Reuma Ticino, Lega','Lega ticinese per la lotta contro il reumatismo',NULL,NULL,'sussidi per evtl. Mezzi ausiliari, scarpe ortopediche, cure termali, corsi ginnastica.',2,0,'DCN TI',0,0
UNION ALL SELECT 234,NULL,'Rhumatisants, Fondation genevoise pour l''aide aux','Fondation genevoise pour l''aide aux rhumatisants',NULL,'pour tout rhumatisant aux revenus modestes',NULL,2,0,'DCN GE',0,0
UNION ALL SELECT 235,NULL,'Ronus-Schaufenbühl Stiftung, Peter und Johanna','Peter und Johanna Ronus-Schaufelbühl-Stiftung c/o Evangelisch-reformierte Kirche Basel-Stadt','Finanzielle Unterstützung von notleidenden alleinerziehenden Müttern mit vorschulpflichtigen, schulpflichtigen oder sich in Ausbildung befindlichen Kindern.',NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 236,NULL,'Roos-Fonds, Geschwister','Geschwister Roos-Fonds','Berufsausbildung hörbehinderter Menschen',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 237,NULL,'Rosenburger-Stiftung, Alphons','Alphons Rosenburger-Stiftung','Beiträge an hilfsbedürftige EpileptikerInnen',NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 238,NULL,'Rotary Club','Rotary Club','Alle Behinderungen. Sich an die zuständige Regionalstelle wenden. Regional unterschiedliche Leistungen.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 239,NULL,'Rotes Kreuz, Schweizerisches','Schweizerisches Rotes Kreuz','Alle Behinderungen, Beiträge an Krankheitskosten, Abgabe von Kleidern, Bettwäsche usw. Sich an die Regionalstelle wenden. Regional unterschiedliche Leistungen.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 240,NULL,'Rüegg-Stiftung, Gertrud','Gertrud Rüegg-Stiftung','Unterstützung für Mensch in einer Notsituation während der ersten Ausbildung in der Schweiz. Beiträge für Zweitausbildungen werden nur in Ausnahmefällen gewährt.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 241,NULL,'Sandoz-Peter Stiftung, Lore','Stiftung Lore Sandoz-Peter','Leistung von gemeinnützigen und wohltätigen Unterstützungsbeiträgen an Bedürftigte mit Wohnsitz in Biel sowie die Unterstützung der Armen- und Krankenpflege der Gemeinde Biel',NULL,NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 242,NULL,'Sanitas Stiftung, Davos','Stiftung Sanitas Davos','Für Kranke und Behinderte.',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 243,NULL,'Säuberli-Kühn Stiftung','Säuberli-Kühn Stiftung','Hilfe für Einwohner i. Kt. AG, spez. aber Bez. Aarau u. Kulm, die durch körperliche oder geistige Krankheiten in finanzielle Not geraten sind.',NULL,NULL,2,0,'KGS AG-SO',0,0
UNION ALL SELECT 244,NULL,'SBB Personalfonds','Personalfonds SBB','Alle Behinderungen. Für SBB Mitarbeitende.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 245,NULL,'Schaad-Keller-Stiftung','Schaad-Keller-Stiftung','Alle Behinderungen.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 246,NULL,'Schmid Fonds, Christian','Christian Schmid Fonds','Schulkinder, Lehrlinge und Studierende, männlich, evang., wohnhaft in bündnerischen Ortschaften über 800 m.',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 247,NULL,'Schmid Stiftung, Gisella G.','Gisella G. Schmid Stiftung','Cererbral, Spina Bifida, Muskeldystrophie und Blinde. Autofinanzierung Höchstbetrag Fr. 3''000.-. Telefonische Vorbesprechung mit Stiftung Cerebral.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 248,NULL,'Schwendener Stiftung, H.','H. Schwendener Stiftung','Nur für Ausbildungen für reformierte Bündner',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 249,NULL,'Schwyzer hälfed Schwyzer, Stiftung','Stiftung Schwyzer hälfed Schwyzer','Alle Behinderungen. Eher kleinere Beiträge. Auch Autoanschaffung.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 250,NULL,'Seraphisches Liebeswerk','Schwesterngemeinschaft Seraphisches Liebeswerk Solothurn (SLS)','Alle Behinderungen. Nur an Kinder und Jugendliche oder an deren Eltern.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 251,NULL,'Service social de la Ville de Genève','Service social de la Ville de Genève',NULL,'Commune de Genève, afin d''éviter la détérioration d''une situation difficile. Prend aussi en charge les cusines scolaires.',NULL,2,0,'DCN GE',0,0
UNION ALL SELECT 252,NULL,'Sieber-Stiftung, Sylvia und Oskar','Sylvia und Oskar Sieber-Stiftung','Stiftung der Schweiz. Gemeinnützigen Gesellschaft. Für in Not geratene Kinder und Mütter. Schweiz oder Aufenthaltsbew. C.',NULL,NULL,2,0,'KGS ZH,KGS TG-SH,KGS AG-SO,KGS SG-AI-AR,ehemalige KGS Uri/Schwyz',0,0
UNION ALL SELECT 253,NULL,'Solari, fondazione, Dott. Andrea','Fondazione Dott. Andrea Solari',NULL,NULL,'residenti in Ticino, per alleviare la sofferenza delle persone',2,0,'DCN TI',0,0
UNION ALL SELECT 254,NULL,'Solidaritätsfonds für Mutter und Kind, Schweizerischer Katholischer Fraubenbund','Solidaritätsfonds für Mutter und Kind, Schweizerischer Katholischer Fraubenbund','Hilfe für Mütter, die durch die Geburt eines Kindes in finanzielle Bedrängnis geraten. Spez. Formular ausfüllen.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 255,NULL,'SOS Beobachter Stiftung','Stiftung SOS Beobachter','Alle Behinderungen. Zur Zeit keine Autofinanzierung',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 256,NULL,'Sozialdienst der Armee','Sozialdienst der Armee','Angehörige von Armee und Zivilschutz. Muss sich im Dienst befinden, in der Regel RS oder Durchdiener.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 257,NULL,'Spielhagen fondazione, Erich e Clara','Fondazione Erich e Clara Spielhagen',NULL,NULL,'Operare in favore di enti assistenziali e di persone bisognose domiciliati nel Cantone Ticino',2,0,'DCN TI',0,0
UNION ALL SELECT 258,NULL,'SSBL, Stiftung','Stiftung SSBL','Für Menschen mit Behinderung, die in dieser Institution leben',NULL,NULL,2,0,'DCN Jura',0,0
UNION ALL SELECT 259,NULL,'SSSB, Stiftung für Selbst- und Sozialhilfe in der Landwirtschaft, insbes. Berggebiete','SSSB, Stiftung für Selbst- und Sozialhilfe in der Landwirtschaft, insbesonder Berggebiete','Alle Behinderungen, nur für Bauernbetriebe, insbesondere in Berggebieten.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 260,NULL,'Steiger-Stiftung','Steiger-Stiftung','Für Sehbehindert, Erblindete, Parkinson, Alzheimer, Demenz, Multiple Sklerose oder schweres Rheuma. Abgabe von medizinischen Geräten und Hilfsmitteln, finanzielle Beiträgen an Therapien und Erholungsaufenthalte sowie finanzielle Beträge an die Lebenshaltungskosten.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 261,NULL,'Strozzi fondazione, A+E+M','Fondazione A+E+M Strozzi',NULL,NULL,NULL,2,0,'DCN TI',0,0
UNION ALL SELECT 262,NULL,'Sunnesyte, Stiftung','Stiftung Sunnesyte','Einreichen via KGS Bern (Antrag KGL). Finanzielle Beiträge an von Krankheit und Behinderung betroffene Kinder und Jugendliche bzw. deren Erziehungsberechtigte','contributions financières aux enfants et adolescents malades ou handicapés ou à leurs répondants',NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 263,NULL,'SVVB, Verbesserungen in der Berglandschaft','Schweizerische Vereinigung für betriebliche Verbesserungen in der Berglandschaft (SVVB)','Bergbauern.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 264,NULL,'TCS','Touring Club der Schweiz','Alle Behinderungen - Beitrag an behinderungsbed. notwendige Autoanschaffung. Je nach Sektion unterschiedliche Leistungen. Einzelne Sektionen geben keine Beiträge.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 265,NULL,'Téléthon fondation','Fondation Téléthon','Genetische Erkrankungen, seltene Erkrankungen.',NULL,NULL,2,0,'DCN GE,DCN VD,DCN FR,DCN JU-NE,DCN Jura,KGS BE,DCN TI,HS Zürich',0,0
UNION ALL SELECT 266,NULL,'Tierschutz, Schweizer, STS','Schweizer Tierschutz STS','Für ausserordentliche Tierhaltungskosten (z.B. Operation nach Unfall oder Erkrankung). Keine ordentlichen Kosten, wie Impfen, Kastration, Medikamente oder Futter. Gesuche sind an die regionale Tierschutz-Organisation zurichten und werden von dieser an den Schweizer Tierschutz weitergeleitet. Beschränkte Mittel.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 267,NULL,'Tierspital Bern','Tierspital Bern','Ermöglicht Tierhaltern mit einem begrenzten finanziellen Budget die Kosten der Behandlung im Tierspital Bern mitzutragen. Stiftung verfügt über ein begrenztes Kapital und kann deshalb nicht automatisch jeden Antrag bewilligen.',NULL,NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 268,NULL,'Tilber Stiftung','Tilber Stiftung','Alle Behinderungen. Nur wenige Vergabungen im Jahr.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 269,NULL,'Tissot fondation, Willy','Fondation Willy Tissot',NULL,'pour personnes aveugles, jeunes (jusqu''à 20 ans), personnes âgées, handicapées, malades, délaissées ou indigentes',NULL,2,0,'DCN FR,DCN GE,DCN JU-NE,DCN Jura,DCN VD',0,0
UNION ALL SELECT 270,NULL,'Trio-Stiftung','Trio-Stiftung','Körperlich behinderte Menschen, vorwiegend Kinder und Jugendliche.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 271,NULL,'UKBB','Universitäts-Kinderspital beider Basel',NULL,NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 272,NULL,'Unterstützungs-Gesellschaft, Bündner','Bündner Unterstützungs-Gesellschaft','Bedürftige, vornehmlich Bündner',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 273,NULL,'Volontarie Vincenziane, Associazione','Associazione Volontarie Vincenziane',NULL,NULL,'Ogni persone in situazione di sofferenza.',2,0,'DCN TI',0,0
UNION ALL SELECT 274,NULL,'Von Kuffner-Stiftung, Moritz und Elsa','Moritz und Elsa von Kuffner-Stiftung','Alle Behinderungen. Nur wenn Schweizerbürgerrecht.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 275,NULL,'von Paul Stiftung, Vinzenz','Vinzenz von Paul Stiftung','Rasche Hilfe bei Notlagen vielfältiger Art',NULL,NULL,2,0,'DCN JU-NE',0,0
UNION ALL SELECT 276,NULL,'Von Tscharner-Stiftung, Albert','Albert von Tscharner-Stiftung','Bündner Bürger. körperlich Behinderte, Suchtgeschädigte',NULL,NULL,2,0,'KGS GR',0,0
UNION ALL SELECT 277,NULL,'Vontobel Familienstiftung, Bank','Familienstiftung Bank Vontobel','Bedürftige natürliche Personen in der Schweiz. Maximal Fr. 30''000.-',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 278,NULL,'Weidmann Stiftung, August','August Weidmann Fürsorge-Stiftung','Unterstützung an in Not geratene Menschen, in bescheidenen Verhältnissen lebende behinderte Jugendliche und Erwachsene',NULL,NULL,2,0,'KGS ZH',0,0
UNION ALL SELECT 279,NULL,'Weihnachtsaktion Luzerner Zeitung','Weihnachtsaktion Luzerner Zeitung','Für Einzelpersonen und Familien in schwierigen Situationen',NULL,NULL,2,0,'KGS LU-OW-NW,ehemalige KGS Uri/Schwyz,KGS ZG-UR-SZ',0,0
UNION ALL SELECT 280,NULL,'Wiederkehr-Stiftung, Max','Max Wiederkehr-Stiftung','Unterstützung und Förderung sozial beachteiligter Kinder und Jugendlicher',NULL,NULL,2,0,'KGS ZH',0,0
UNION ALL SELECT 281,NULL,'Wigert-Stiftung, Irma','Irma Wigert-Stiftung','Alle Behinderungen, insbesondere Hörprobleme',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 282,NULL,'Wilsdorf fondation, Hans','Fondation Hans Wilsdorf',NULL,'aides multiples',NULL,2,0,'DCN GE',0,0
UNION ALL SELECT 283,NULL,'Winterhilfe','Winterhilfe','Alle Behinderungen. Sich an die zuständige Regionalstelle wenden. Regional unterschiedliche Leistungen.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 284,NULL,'Wittmann-Spiess-Stiftung, Alice und Walter','Alice und Walter Wittmann-Spiess-Stiftung',NULL,NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 285,NULL,'Ziegler Fonds','Ziegler Fonds','Der Ziegler Fonds unterstützt Personen mit Wohnsitz in der Stadt Bern mit Beiträgen, die ausgewiesene, in der Regel medizinisch indizierte Gesundheitskosten nicht mit eigenen Mitteln und auch nicht anderswie finanzieren können.',NULL,NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 286,NULL,'Zingg Stiftung, Susanne und Ernst','Stiftung Suzanne und Ernst Zingg','Die Stiftung unterstützt kranke und hilfsbedürftige Menschen im Kanton Bern mit Wiedereingliederungsmassnahmen sowie der Finanzierung von Wohnerleichterungen und Spezialgeräten.',NULL,NULL,2,0,'KGS BE',0,0
UNION ALL SELECT 287,NULL,'zmittsdrin, Verein','Verein zmittsdrin',NULL,NULL,NULL,2,0,'KGS BS',0,0
UNION ALL SELECT 288,NULL,'Zonta Club','Zonta Club','Zu den Zielen von Zonta Intern. gehört die berufliche Förderung junger Frauen. Hierzu werden jährlich weltweit Stipendien und Preise vergeben.',NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT 289,NULL,'Übrige / Autres / Altri','Übrige / Autres / Altri',NULL,NULL,NULL,2,1,'ganze Schweiz',0,0
UNION ALL SELECT NULL,NULL,'Rheumaliga AG','Rheumaliga AG','www.rheumaliga.ch/ag',NULL,NULL,1,0,'KGS AG-SO,HS Zürich',0,1

UNION ALL SELECT NULL,NULL,'WNN, fondo','Fondo WNN',NULL,NULL,NULL,1,0,'DCN TI,HS Zürich',0,1
UNION ALL SELECT NULL,NULL,'Malattie Genetiche Rare, associazione','Associazione Malattie Genetiche Rare',NULL,NULL,NULL,1,0,'DCN TI,HS Zürich',0,1


-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-------------------------------------------------------------------------------
-- loop all entries 
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT  @GvFondsID = TMP.GvFondsID,
          @Zahlungskonto = TMP.Zahlungskonto,
          @NameKurz = TMP.NameKurz,
          @NameLang = TMP.NameLang,
          @BemerkungD = TMP.BemerkungD,
          @BemerkungF = TMP.BemerkungF,
          @BemerkungI = TMP.BemerkungI,
          @GvFondsTypeCode = TMP.GvFondsTypCode,
          @IstCH = TMP.IstCH,
          @Abteilungen = TMP.Abteilungen,
          @MustTerminateIt = TMP.MustTerminateIt,
          @IsWithChangeText = TMP.IsWithChangeText
  FROM @GvFondsToInsert TMP
  WHERE TMP.GvFondsToInsertID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- do something
  -----------------------------------------------------------------------------
  BEGIN TRY
    BEGIN TRAN;
           
    PRINT CONVERT(VARCHAR(MAX), @EntriesIterator) + ' BEGIN Fonds NameKurz="' + @NameKurz + '"';
           
    SET @KbZahlungskontoID = NULL;
    SET @BemerkungTID = NULL;
       
    -- KbZahlungskonto 
    -- Zahlungskonto nötig ?
    IF @Zahlungskonto IS NOT NULL
    BEGIN  
      -- KbZahlungskonto schon da ?
      SELECT @KbZahlungskontoID = KbZahlungskontoID
      FROM dbo.KbZahlungskonto
      WHERE Name = @Zahlungskonto
      
      IF @KbZahlungskontoID IS NULL 
      BEGIN
        PRINT '    ERROR Das Zahlungskonto "' + @Zahlungskonto + '" konnte in der DB nicht gefunden werden und wurde nicht an den Fonds "' + @NameKurz + '" zugewiesen. Bitte das Zahlungskonto im KiSS eintragen oder der NameKurz des Kontos korrigieren, und dann das Script wieder ausführen.';                                    
      END
    END;
    
    
    IF @GvFondsID IS NULL
    BEGIN
      -- Neues Fonds mit dieser NameKurz schon da ?    
      PRINT '    Fonds Namekurz="' + @NameKurz + '" suchen';
      SELECT @GvFondsID = GvFondsID FROM dbo.GvFonds WHERE NameKurz = @NameKurz;

      SET @IsNeu = 1;
    END
    ELSE
    BEGIN
      SET @IsNeu = 0;
    END

    IF @GvFondsID IS NOT NULL
    BEGIN
      PRINT '    Fonds mit dbo.GvFonds.NameKurz="' + @NameKurz + '" schon in der DB GvFondsID=' + CONVERT(VARCHAR,@GvFondsID);      
      
      UPDATE dbo.GvFonds
        SET  KbZahlungskontoID = @KbZahlungskontoID,
             NameKurz = CASE WHEN @IsWithChangeText = 1 THEN @NameKurz ELSE NameKurz END,
             NameLang = CASE WHEN @IsWithChangeText = 1 THEN @NameLang ELSE NameLang END,
             GvFondsTypCode =  CASE WHEN @IsNeu = 1 THEN CONVERT(VARCHAR, @GvFondsTypeCode) ELSE GvFondsTypCode END ,
             IstCH = CASE WHEN @IsNeu = 1 THEN CONVERT(VARCHAR,@IstCH) ELSE IstCH END,
             DatumVon = CASE WHEN @IsNeu = 1 THEN dbo.fnDateOf(@DatumVon) ELSE DatumVon END,
             DatumBis = CASE WHEN @MustTerminateIt = 1 AND @DatumBis < DatumBis THEN dbo.fnDateOf(@DatumBis) ELSE DatumBis END,
             Modifier = @CreatorModifier,	
             Modified = GETDATE()
      WHERE GvFondsID = @GvFondsID;
      
      SELECT @BemerkungTID = BemerkungTID FROM dbo.GvFonds WHERE GvFondsID = @GvFondsID;   
      
      PRINT '    dbo.gvFonds aktualisiert KbZahlungskontoID=' + COALESCE(CONVERT(VARCHAR,@KbZahlungskontoID),'NULL') 
                                    + ' KbZahlungskonto.Name=' + COALESCE('"' + @Zahlungskonto + '"','NULL') 
                                    + ' NameKurz=' + CASE WHEN @IsWithChangeText = 1 THEN '"' + @NameKurz + '"' ELSE 'unverändert' END 
                                    + ' NameLang=' + CASE WHEN @IsWithChangeText = 1 THEN '"' + @NameLang + '"' ELSE 'unverändert' END
                                    + ' GvFondsTypCode=' + CASE WHEN @IsNeu = 1 THEN CONVERT(VARCHAR, @GvFondsTypeCode) ELSE 'unverändert' END
                                    + ' IstCH=' + CASE WHEN @IsNeu = 1 THEN CONVERT(VARCHAR,@IstCH) ELSE 'unverändert' END
                                    + ' DatumVon=' +  CASE WHEN @IsNeu = 1 THEN COALESCE(CONVERT(VARCHAR,@DatumVon,104),'NULL') ELSE 'unverändert' END 
                                    + ' DatumBis=' +  CASE WHEN @MustTerminateIt = 1 THEN COALESCE(CONVERT(VARCHAR,@DatumBis,104),'NULL') ELSE 'unverändert' END; 

      
    END;
    ELSE
    BEGIN    
       -- Neue Fonds      
       INSERT INTO dbo.GvFonds(KbZahlungskontoID, DatumVon, NameKurz, NameLang,GvFondsTypCode, IstCH, Creator, Created, Modifier, Modified)
        SELECT @KbZahlungskontoID, @DatumVon, @NameKurz, @NameLang, @GvFondsTypeCode, @IstCH, @CreatorModifier, GETDATE(), @CreatorModifier, GETDATE();      
       
       SET @GvFondsID = SCOPE_IDENTITY();
       PRINT '    Neuer Fonds GvFondsID=' + CONVERT(VARCHAR,@GvFondsID) + ' NameKurz="' + @NameKurz + '" KbZahlungskontoID=' + COALESCE(CONVERT(VARCHAR,@KbZahlungskontoID),'NULL') 
    
    END;    
       
    -- Bemerkungen für gvFondsID aktualisieren
    IF @IsWithChangeText = 1
    BEGIN
      IF @BemerkungD IS NOT NULL  
      BEGIN 
        EXEC dbo.spXSetXLangText @BemerkungTID, 1, @BemerkungD, NULL, NULL, NULL, NULL, @BemerkungTID OUT;
      END;
      IF @BemerkungF IS NOT NULL 
      BEGIN 
        EXEC dbo.spXSetXLangText @BemerkungTID, 2,@BemerkungF,  NULL, NULL, NULL, NULL, @BemerkungTID OUT;
      END;
      IF @BemerkungI IS NOT NULL 
      BEGIN 
        EXEC dbo.spXSetXLangText @BemerkungTID, 3, @BemerkungI,  NULL, NULL, NULL, NULL, @BemerkungTID OUT;
      END;
      
      IF @BemerkungTID IS NOT NULL
      BEGIN
        UPDATE dbo.GvFonds
          SET BemerkungTID = @BemerkungTID,
              Modifier = @CreatorModifier,	
              Modified = GETDATE()
        WHERE GvFondsID = @GvFondsID;
      END
      
      UPDATE dbo.GvFonds
        SET Bemerkung = COALESCE(@BemerkungD,@BemerkungF,@BemerkungI),
            Modifier = @CreatorModifier,	
            Modified = GETDATE()
      WHERE GvFondsID = @GvFondsID;
      
      PRINT '    Bemerkungen für GvFondsID=' + CONVERT(VARCHAR,@GvFondsID) + ' aktualisiert.'
    END
    
    -- Abteilungen
    PRINT '    Abteilungen und angegliederten - Zuweisung'

    DELETE FROM @TmpGvFonds_XOrgUnit;
    DELETE FROM @GvFonds_XOrgUnitInsertResult;    
    
    IF @Abteilungen = 'ganze Schweiz'
    BEGIN 
      PRINT '    Für die ganze Schweiz'
    
      INSERT INTO @TmpGvFonds_XOrgUnit
        SELECT OrgUnitID FROM dbo.XOrgUnit ORG;    
    END
    ELSE
    BEGIN

      -- Error in der Resulttabelle einfügen
      INSERT INTO @GvFonds_XOrgUnitInsertResult(ResultMessage)
        SELECT  ResultMessage = '    ERROR Abteilung "' + ABTs.SplitValue + '" nicht gefunden und konnte an das Fonds ' +  CONVERT(VARCHAR,@GvFondsID) + ' nicht zugewiesen werden.'
        FROM dbo.fnSplitStringToValues(@Abteilungen,',',1) ABTs
          LEFT JOIN dbo.XOrgUnit ORG ON ORG.ItemName = ABTs.SplitValue
        WHERE ORG.OrgUnitID IS NULL;    
 
      -- Liste aller Kandidaten OrgUnits generieren - Recursives INNER JOIN nötig wegen der Hierarchie       
      ;WITH GvFonds_XOrgUnitInsertH( OrgUnitID, 
                                    ParentID)
      AS
      (
        SELECT ORG.OrgUnitID, 
               ORG.ParentID
        FROM dbo.fnSplitStringToValues(@Abteilungen,',',1) AS ABTs
        INNER JOIN dbo.XOrgUnit ORG ON ORG.ItemName = ABTs.SplitValue
        
        UNION ALL
        SELECT ORG.OrgUnitID, 
              ORG.ParentID
        FROM dbo.XOrgUnit ORG
        INNER JOIN GvFonds_XOrgUnitInsertH AS ORGH ON ORGH.OrgUnitID = ORG.ParentID
      )
      -- Die Liste wird mehr mal verwendet, dann im Temp nötig
      INSERT INTO @TmpGvFonds_XOrgUnit
        SELECT OrgUnitID FROM GvFonds_XOrgUnitInsertH;
    
    END

    -- Warnung in der ResultMessageListe einfügen
    INSERT INTO @GvFonds_XOrgUnitInsertResult(ResultMessage)
      SELECT '    WARNUNG Abteilung ''' + ORG.ItemName + ''' OrgUnitID=''' + CONVERT(VARCHAR,GFOH.OrgUnitID) + ' an das Fonds GvFondsID=' + CONVERT(VARCHAR,@GvFondsID) + ' schon zugewiesen'
      FROM @TmpGvFonds_XOrgUnit GFOH 
        INNER JOIN (SELECT OrgUnitID
                   FROM dbo.GvFonds_XOrgUnit 
                   WHERE GvFondsID = @GvFondsID) GFO ON GFO.OrgUnitID = GFOH.OrgUnitID
        LEFT JOIN dbo.XOrgUnit ORG ON ORG.OrgUnitID = GFOH.OrgUnitID ;
           
    -- Info in der ResultMessageListe einfügen
    INSERT INTO @GvFonds_XOrgUnitInsertResult(ResultMessage)
      SELECT '    INFO Abeteilung "' + ORG.ItemName + '" OrgUnitID=' + CONVERT(VARCHAR,GFOH.OrgUnitID) + ' an das Fonds GvFondsID=' + CONVERT(VARCHAR,@GvFondsID) + ' zuweisen'
      FROM @TmpGvFonds_XOrgUnit GFOH
        LEFT JOIN (SELECT OrgUnitID
                   FROM dbo.GvFonds_XOrgUnit 
                   WHERE GvFondsID = @GvFondsID) GFO ON GFO.OrgUnitID = GFOH.OrgUnitID
        LEFT JOIN dbo.XOrgUnit ORG ON ORG.OrgUnitID = GFOH.OrgUnitID           
      WHERE GFO.OrgUnitID IS NULL;

    -- Tabelle GvFonds_XOrgUnit füllen
    PRINT '    Tabelle GvFonds_XOrgUnit füllen';
    INSERT INTO dbo.GvFonds_XOrgUnit
            (GvFondsID,
             OrgUnitID,
             Creator,
             Created,
             Modifier,
             Modified)    
      SELECT @GvFondsID,
             GFOH.OrgUnitID, -- OrgUnitID - int
             @CreatorModifier, -- Creator - varchar(50)
             GETDATE(), -- Created - datetime
             @CreatorModifier, -- Modifier - varchar(50)
             GETDATE() -- Modified - datetime 
      FROM @TmpGvFonds_XOrgUnit GFOH
        LEFT JOIN (SELECT OrgUnitID
                   FROM dbo.GvFonds_XOrgUnit 
                   WHERE GvFondsID = @GvFondsID) GFO ON GFO.OrgUnitID = GFOH.OrgUnitID
      WHERE GFO.OrgUnitID IS NULL;

    -- Resultmessage anezeigen
    PRINT '    Resultmessage anezeigen';
    DECLARE cur CURSOR FOR
    SELECT ResultMessage FROM @GvFonds_XOrgUnitInsertResult

    OPEN cur

    FETCH NEXT FROM cur INTO @Result;
    WHILE @@FETCH_STATUS = 0
    BEGIN   
      PRINT @Result
    FETCH NEXT FROM cur INTO  @Result;
    END

    CLOSE cur;
    DEALLOCATE cur;
    
    PRINT '-----------------'
    
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
  -----------------------------------------------------------------------------
  
  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO

