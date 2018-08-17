BEGIN TRANSACTION
/*===============================================================================================
  $Revision: 2$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this Update Fonds
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO


-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------

DECLARE @KbZahlungskontoIDneu int;
DECLARE @KbZahlungskontoIDalt int;
DECLARE @Zahlungskonto varchar(50);
DECLARE @GvFondsID int;
DECLARE @NameKurz varchar(200);
DECLARE @NameLang varchar(500);
DECLARE @BemerkungTIDNeu int;
DECLARE @BemerkungTIDold int;
DECLARE @BemerkungD varchar(max);
DECLARE @BemerkungF varchar(max);
DECLARE @BemerkungI varchar(max);
DECLARE @GvFondsTypeCode int;
DECLARE @IstCH bit;
DECLARE @Abteilungen varchar(max);
DECLARE @Abteilung varchar(100);
DECLARE @DatumBis datetime;
DECLARE @OrgUnitID INT;


DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @GvFondsToUpdate TABLE
(
  GvFondsToInsertID INT IDENTITY(1, 1) NOT NULL, -- ID für die Ausführung in diesem Script
  GvFondsID INT, -- GvFonds.GvFondsID
  Zahlungskonto varchar(50) NULL,  -- KbZahlungskonto.Name
  NameKurz varchar(200) NOT NULL, -- GvFonds.NameKurz
  NameLang varchar(500) NOT NULL, -- GvFonds.NameLang
  BemerkungD varchar(max) NULL, -- GvFonds.Bemerkung, XLangText.Text durch BemerkungTID verknüpft falls mehrsprachig
  BemerkungF varchar(max) NULL, -- GvFonds.Bemerkung, XLangText.Text durch BemerkungTID verknüpft falls mehrsprachig
  BemerkungI varchar(max) NULL, -- GvFonds.Bemerkung, XLangText.Text durch BemerkungTID verknüpft falls mehrsprachig
  GvFondsTypCode int NOT NULL, -- GvFonds.GvFondsTypCode (LOVCode=1 intern oder 2 extern)
  IstCH bit NOT NULL, -- GvFonds.IstCH (Schweiz oder Kant.)
  Abteilungen varchar(MAX) NULL, -- GvFonds_XOrgUnit.ItemName
  DatumBis datetime NULL -- GültigBis Datum (31.12.14)
);



-- TODO select aus Excel hinzufügen
INSERT INTO @GvFondsToUpdate(GvFondsID, Zahlungskonto, NameKurz, NameLang, BemerkungD, BemerkungF, BemerkungI, GvFondsTypCode, IstCH,  Abteilungen, DatumBis )
SELECT 1,NULL,'Ausserordentliche Direkthilfe/aide directe extraordinaire PI HS/SP','Fonds für ausserordentliche Direkthilfe, fonds pour les situations extraordinaires PI HS/SP','Für komplizierte Fälle, die nicht mit FLB und externen Stiftungen gelöst werden können.','Pour les situations complexes, qui ne peuvent pas être résolues à l''aide des PAH et de fonds externes.','Per casi complicati che non possono essere risolti con le PAH e fondazioni esterne.',1,1,'Mosaik',NULL
UNION ALL SELECT 2,NULL,'Autofonds/fonds véhicules PI HS/SP','Autofonds/fonds véhicules PI HS/SP','Behinderungsbedingte Autoanschaffungen. Max. Fr. 5''000.-. Erst, wenn FLB und externe Quellen ausgeschöpft.','Acquisitions de véhicules nécessaires en raison du handicap. Au max. Fr. 5''000.-. A solliciter seulement une fois que les possibilités de recourir aux PAH et aux fonds externes sont épuisées.','Acquisto di un veicolo a causa dall’handicap. Massimo 5000 franchi. Soltanto quando PAH e fonti esterne esaurite.',1,1,'Mosaik',NULL
UNION ALL SELECT 3,'FLB-Schweiz','FLB-PAH Suisse','FLB-PAH Suisse','FLB Gesuche über Fr. 10''000.- pro Fall/Jahr. Unabhängig vom Betrag alle Gesuche für autismusspezifische Behandlungsmethoden, Autoanschaffung und -Umbau, E-hockey-Sportgeräte, Hörgeräte, medizinische Massnahmen: Beiträge an alternative Behandlungsmethoden ab dem 2. Unterstützungsjahr','Demandes PAH de plus de Fr. 10''000.- par situation/an. Egalement, indépendamment du montant demandé, toutes les demandes pour des mesures thérapeutiques spécifiques pour personnes autistes, pour l''acquisition ou la transformation de véhicules, pour du matériel de e-hockey, pour des appareils auditifs et, à partir de la 2e année, pour des thérapies alternatives (mesures médicales).','Domande PAH superiori ai 10''000 franchi per caso/anno. A prescindere dall’importo, tutte le domande per metodi di trattamento specifici dell’autismo, acquisti e modifiche di veicoli, attrezzature sportive per l’hockey in carrozzina elettrica, apparecchi acustici, provvedimenti medici: contributi a metodi di trattamento alternativi a partire dal 2° anno di sostegno.',1,1,'Mosaik',NULL
UNION ALL SELECT 4,NULL,'Göhner-Stiftung, Ernst','Ernst Göhner-Stiftung',NULL,NULL,NULL,1,0,'Mosaik','2014-12-31'
UNION ALL SELECT 5,NULL,'Love Ride Switzerland','Love Ride Switzerland','Alle Behinderungen. Prioritär Muskelerkrankung. Unterstützung zu Themen Mobilität (Autoanschaffung) und Lebensfreude. Max. Fr. 2''500.-. ','Tous types de handicap, mais la priorité est donnée aux maladies musculaires. Soutien visant à accroître la mobilité (acquisition de véhicules) et la joie de vivre. Au max. Fr. 2''500.-. ','Tutti i tipi di handicap. Priorità malattie muscolari. Sostegno alla mobilità (acquisto di un veicolo) e alla gioia di vivere. Massimo 2500 franchi. ',1,1,'Mosaik',NULL
UNION ALL SELECT 6,NULL,'Ältere Behinderte, Fonds für','Fonds für "ältere" Behinderte',NULL,NULL,NULL,1,0,'KGS ZH',NULL
UNION ALL SELECT 7,'FLB-Kanton ZH','FLB Kanton ZH','FLB Kanton ZH',NULL,NULL,NULL,1,0,'KGS ZH',NULL
UNION ALL SELECT 8,NULL,'Patenschaften ZH','Patenschaften ZH',NULL,NULL,NULL,1,0,'KGS ZH',NULL
UNION ALL SELECT 9,NULL,'Loisirs, fonds','Fonds loisirs',NULL,NULL,NULL,1,0,'DCN VD',NULL
UNION ALL SELECT 10,'PAH-Canton VD','PAH canton VD','PAH canton VD',NULL,NULL,NULL,1,0,'DCN VD',NULL
UNION ALL SELECT 11,NULL,'Parrainages VD','Parrainages VD',NULL,NULL,NULL,1,0,'DCN VD',NULL
UNION ALL SELECT 12,NULL,'Arnold, Erbengemeinschaft, für CM-Kinder','Erbengemeinschaft Arnold für CM-Kinder',NULL,NULL,NULL,1,0,'ehemalige KGS Uri/Schwyz,KGS ZG-UR-SZ',NULL
UNION ALL SELECT 13,'FLB-Kanton UR/SZ/ZG','FLB Kanton UR/SZ/ZG','FLB Kanton UR/SZ/ZG',NULL,NULL,NULL,1,0,'ehemalige KGS Uri/Schwyz,KGS ZG-UR-SZ',NULL
UNION ALL SELECT 14,NULL,'Nothilfefonds Inner- Ausserschwyz','Nothilfefonds Inner- Ausserschwyz',NULL,NULL,NULL,1,0,'ehemalige KGS Uri/Schwyz,KGS ZG-UR-SZ',NULL
UNION ALL SELECT 15,NULL,'Patenschaftsfonds UR SZ ZG','Patenschaftsfonds UR SZ ZG',NULL,NULL,NULL,1,0,'ehemalige KGS Uri/Schwyz,KGS ZG-UR-SZ',NULL
UNION ALL SELECT 16,NULL,'Audiolesi, fondo','Fondo audiolesi',NULL,NULL,NULL,1,0,'DCN TI',NULL
UNION ALL SELECT 17,NULL,'Bambini Cerebolesi, fondo','Fondo Bambini Cerebolesi',NULL,NULL,NULL,1,0,'DCN TI',NULL
UNION ALL SELECT 18,NULL,'Nessi, fondo','Fondo nessi',NULL,NULL,NULL,1,0,'DCN TI',NULL
UNION ALL SELECT 19,NULL,'Padrinati TI','Padrinati TI',NULL,NULL,NULL,1,0,'DCN TI',NULL
UNION ALL SELECT 20,'PAH-Cantone TI','PAH Cantone TI','PAH Cantone TI',NULL,NULL,NULL,1,0,'DCN TI',NULL
UNION ALL SELECT 21,NULL,'Peretti, fondo','Fondo Peretti',NULL,NULL,NULL,1,0,'DCN TI',NULL
UNION ALL SELECT 22,NULL,'Brantomyfonds','Brantomyfonds',NULL,NULL,NULL,1,0,'Mosaik','2014-12-31'
UNION ALL SELECT 23,'FLB-Kanton TG/SH','FLB Kanton TG/SH','FLB Kanton TG/SH',NULL,NULL,NULL,1,0,'KGS TG-SH',NULL
UNION ALL SELECT 24,NULL,'Patenschaften TG/SH','Patenschaften TG/SH',NULL,NULL,NULL,1,0,'KGS TG-SH',NULL
UNION ALL SELECT 25,'FLB-Kanton SO','FLB-Kanton SO','FLB-Kanton SO',NULL,NULL,NULL,1,0,'KGS Solothurn','2014-12-31'
UNION ALL SELECT 26,NULL,'Patenschaften SO','Patenschaften SO',NULL,NULL,NULL,1,0,'KGS Solothurn','2014-12-31'
UNION ALL SELECT 27,NULL,'CP Klienten AI','CP Klienten AI',NULL,NULL,NULL,1,0,'KGS SG-AI-AR',NULL
UNION ALL SELECT 28,'FLB-Kanton SG/AI/AR','FLB Kanton SG/AI/AR','FLB Kanton SG/AI/AR',NULL,NULL,NULL,1,0,'KGS SG-AI-AR',NULL
UNION ALL SELECT 29,NULL,'Maier J. und W.','Maier J. und W.',NULL,NULL,NULL,1,0,'KGS SG-AI-AR',NULL
UNION ALL SELECT 30,NULL,'Patenschaften SG','Patenschaften SG',NULL,NULL,NULL,1,0,'KGS SG-AI-AR',NULL
UNION ALL SELECT 31,NULL,'Adultes, fonds','Fonds Adultes',NULL,'montant unique',NULL,1,0,'DCN JU-NE',NULL
UNION ALL SELECT 32,NULL,'Jérémie, fonds','Fonds Jérémie',NULL,'montant unique',NULL,1,0,'DCN JU-NE',NULL
UNION ALL SELECT 33,NULL,'Jeunesse, fonds','Fonds Jeunesse',NULL,'montant unique',NULL,1,0,'DCN JU-NE',NULL
UNION ALL SELECT 34,'PAH-Canton JU/NE','PAH canton JU/NE','PAH canton JU/NE',NULL,NULL,NULL,1,0,'DCN JU-NE',NULL
UNION ALL SELECT 35,NULL,'Parrainages JU/NE','Parrainages JU/NE',NULL,NULL,NULL,1,0,'DCN JU-NE',NULL
UNION ALL SELECT 36,NULL,'Prêts, fonds','Fonds Prêts',NULL,'montant unique',NULL,1,0,'DCN JU-NE',NULL
UNION ALL SELECT 37,'FLB-Kanton LU/NW/OW','FLB Kanton LU/NW/OW','FLB Kanton LU/NW/OW',NULL,NULL,NULL,1,0,'KGS LU-OW-NW',NULL
UNION ALL SELECT 38,NULL,'Patenschaften LU-NW-OW','Patenschaften LU-NW-OW',NULL,NULL,NULL,1,0,'KGS LU-OW-NW',NULL
UNION ALL SELECT 39,NULL,'Accompagnement à domicile, fonds','Fonds Accompagnement à domicile',NULL,NULL,NULL,1,0,'DCN JU/NE',NULL
UNION ALL SELECT 40,NULL,'Hofstetter, fonds','Fonds Hofstetter',NULL,'montant unique',NULL,1,0,'DCN JU/NE',NULL
UNION ALL SELECT 41,'PAH-Canton JU','PAH-Canton JU','PAH-Canton JU',NULL,NULL,NULL,1,0,'DCN Jura','2014-12-31'
UNION ALL SELECT 42,NULL,'Parrainages JU','Parrainages JU',NULL,NULL,NULL,1,0,'DCN Jura','2014-12-31'
UNION ALL SELECT 43,NULL,'Rhumatisme, ligue jurassienne contre le','Ligue jurassienne contre le rhumatisme',NULL,NULL,NULL,1,0,'DCN JU/NE',NULL
UNION ALL SELECT 44,NULL,'Caflisch Stiftung, C.+E.','C. und E. Caflisch Stiftung',NULL,NULL,NULL,1,0,'KGS GR',NULL
UNION ALL SELECT 45,NULL,'Coray, Legat','Legat Coray',NULL,NULL,NULL,1,0,'KGS GR',NULL
UNION ALL SELECT 46,'FLB-Kanton GR','FLB Kanton GR','FLB Kanton GR',NULL,NULL,NULL,1,0,'KGS GR',NULL
UNION ALL SELECT 47,NULL,'Patenschaften GR','Patenschaften GR',NULL,NULL,NULL,1,0,'KGS GR',NULL
UNION ALL SELECT 48,'FLB-Kanton GL','FLB Kanton GL','FLB Kanton GL',NULL,NULL,NULL,1,0,'KGS GL',NULL
UNION ALL SELECT 49,NULL,'GGG Kinder und Jugendliche, Fonds für','GGG Fonds für Kinder und Jugendliche',NULL,NULL,NULL,1,0,'KGS GL',NULL
UNION ALL SELECT 50,NULL,'Patenschaften GL','Patenschaften GL',NULL,NULL,NULL,1,0,'KGS GL',NULL
UNION ALL SELECT 51,NULL,'Meuron, fonds','Fonds Meuron',NULL,NULL,NULL,1,0,'DCN GE',NULL
UNION ALL SELECT 52,'PAH-Canton GE','PAH canton GE','PAH canton GE',NULL,NULL,NULL,1,0,'DCN GE',NULL
UNION ALL SELECT 53,NULL,'Parrainages GE','Parrainages GE',NULL,NULL,NULL,1,0,'DCN GE',NULL
UNION ALL SELECT 54,NULL,'Scolarité spéciale, fonds','Fonds scolarité spéciale',NULL,NULL,NULL,1,0,'DCN GE',NULL
UNION ALL SELECT 55,'PAH-FLB FR','PAH FLB canton FR','PAH-FLB canton FR',NULL,NULL,NULL,1,0,'DCN FR',NULL
UNION ALL SELECT 56,NULL,'Parrainages FR','Parrainages FR',NULL,NULL,NULL,1,0,'DCN FR',NULL
UNION ALL SELECT 57,NULL,'Drei-König-Fonds','Drei-König-Fonds',NULL,NULL,NULL,1,0,'KGS BS',NULL
UNION ALL SELECT 58,'FLB-Kanton BS','FLB Kanton BS','FLB Kanton BS',NULL,NULL,NULL,1,0,'KGS BS',NULL
UNION ALL SELECT 59,NULL,'Patenschaften BS','Patenschaften BS',NULL,NULL,NULL,1,0,'KGS BS',NULL
UNION ALL SELECT 60,NULL,'Schaub-Fonds, Emma','Emma Schaub-Fonds',NULL,NULL,NULL,1,0,'KGS BS',NULL
UNION ALL SELECT 61,'FLB-Kanton BL','FLB Kanton BL','FLB Kanton BL',NULL,NULL,NULL,1,0,'Mosaik',NULL
UNION ALL SELECT 62,NULL,'Mosaik, Fonds, Stiftung','Fonds Stiftung Mosaik','Für Familien (mindestens 2 Generationen im gleichen Haushalt, eine davon minderjährig oder in Ausbildung).',NULL,NULL,1,0,'Mosaik',NULL
UNION ALL SELECT 63,'FLB-PAH BE','FLB-PAH canton BE','FLB-PAH canton BE',NULL,NULL,NULL,1,0,'KGS BE',NULL
UNION ALL SELECT 64,NULL,'Hilfskredit','Hilfskredit',NULL,NULL,NULL,1,0,'KGS BE',NULL
UNION ALL SELECT 65,NULL,'MpB, Fonds','Fonds für Menschen mit psychischer Behinderung','Behinderung: Psychische Erkrankung',NULL,NULL,1,0,'KGS BE',NULL
UNION ALL SELECT 66,NULL,'Patenschaften BE','Patenschaften BE',NULL,NULL,NULL,1,0,'KGS BE',NULL
UNION ALL SELECT 67,NULL,'Rheumaliga Bern','Rheumaliga Bern',NULL,NULL,NULL,1,0,'KGS BE',NULL
UNION ALL SELECT 68,NULL,'Rosa Roth Fonds','Rosa Roth Fonds',NULL,NULL,NULL,1,0,'KGS BE',NULL
UNION ALL SELECT 69,NULL,'Familienfonds','Familienfonds der Pro Infirmis Aargau',NULL,NULL,NULL,1,0,'KGS AG-SO',NULL
UNION ALL SELECT 70,'FLB-Kanton AG','FLB Kanton AG/SO','FLB Kanton AG/SO',NULL,NULL,NULL,1,0,'KGS AG-SO',NULL
UNION ALL SELECT 71,NULL,'Patenschaften AG/SO','Patenschaften AG/SO',NULL,NULL,NULL,1,0,'KGS AG-SO',NULL

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table


DECLARE @AbteilungenEntriesCount INT;
DECLARE @AbteilungenEntriesIterator INT;
DECLARE @AbteilungenTable TABLE
(
  ID INT IDENTITY(1, 1) NOT NULL, -- ID für die Ausführung in diesem Script
  Abteilung varchar(100) NOT NULL,
  GvFondsID INT NOT NULL
);

SET @AbteilungenEntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table


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
          @DatumBis = TMP.DatumBis
  FROM @GvFondsToUpdate TMP
  WHERE TMP.GvFondsToInsertID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- do something
  -----------------------------------------------------------------------------
  BEGIN TRY
    BEGIN TRAN;
             
    SET @KbZahlungskontoIDneu = NULL;
    SET @KbZahlungskontoIDalt  = NULL;
       
    -- GvFonds finden
    IF NOT EXISTS (SELECT TOP 1 1 FROM dbo.GvFonds WHERE GvFondsID = @GvFondsID)
      PRINT 'ERROR der Fonds mit GvFonds=' + CONVERT(VARCHAR, @GvFondsID) + ' wurde im dbo.GvFonds nicht gefunden. Dieser Eintrag könnte nicht aktualisiert werden.';
    ELSE
    BEGIN    
    
       PRINT 'BEGIN UPDATE GvFondsID=' + CONVERT(VARCHAR,@GvFondsID)       
      
       -- dbo.GvFonds, Daten aktualisieren
       UPDATE dbo.GvFonds
       SET  NameKurz = @NameKurz, 
            NameLang = @NameLang,
            GvFondsTypCode = @GvFondsTypeCode,
            IstCH = @IstCH,
            DatumBis =  dbo.fnDateOf(@DatumBis)
      WHERE GvFondsID = @GvFondsID;
      
      PRINT 'dbo.gvFonds aktualisiert   NameKurz=' + @NameKurz 
                                    + ' NameLang=' + @NameLang 
                                    + ' GvFondsTypCode=' + CONVERT(VARCHAR,@GvFondsTypeCode) 
                                    + ' IstCH=' + CONVERT(VARCHAR,@IstCH)
                                    + ' DatumBis=' + COALESCE(CONVERT(VARCHAR,@DatumBis,104),'NULL')
       
       -- Zahlungskonto
       SELECT @KbZahlungskontoIDalt = KbZahlungskontoID FROM dbo.GvFonds WHERE GvFondsID = @GvFondsID;   
       SELECT @KbZahlungskontoIDneu = KbZahlungskontoID FROM dbo.KbZahlungskonto WHERE Name = @Zahlungskonto;           
       
       IF @Zahlungskonto IS NOT NULL AND @KbZahlungskontoIDneu IS NULL
        -- neue ZahlungsKonto nicht gefunden
        PRINT 'ERROR Das Zahlungskonto ' + @Zahlungskonto + ' könnte nicht gefunden werden und wurde an den Fonds GvFondsID=' + CONVERT(VARCHAR,@GvFondsID) + ' NameKurz=' + @NameKurz +  'nicht zugewiesen';
       
       IF COALESCE(@KbZahlungskontoIDneu,0) != COALESCE(@KbZahlungskontoIDalt,0) 
       BEGIN
          -- KbZahlungsKontoID aktualisieren
         UPDATE dbo.GvFonds SET KbZahlungskontoID = @KbZahlungskontoIDneu WHERE GvFondsID = @GvFondsID; 
         PRINT 'GvFonds mit GvFondsID= ' + CONVERT(VARCHAR,@GvFondsID) + ' aktualisert KbZahlungskontoID=' + COALESCE(CONVERT(VARCHAR,@KbZahlungskontoIDneu),'NULL');
       END;
       


      /*

      SELECT @KbZahlungskontoIDalt = KbZahlungskontoID FROM dbo.GvFonds WHERE GvFondsID = @GvFondsID;   
          
      IF @Zahlungskonto is NULL AND @KbZahlungskontoIDalt IS NOT NULL
      BEGIN
        PRINT 'dbo.GvFonds GvFondsID=' + CONVERT(VARCHAR,@gvFondsID) + ' hatte bis jetzt KbZahlungskontoID=' + ISNULL(CONVERT(VARCHAR,@KbZahlungskontoIDalt),'NULL');
        UPDATE dbo.GvFonds SET KbZahlungskontoID = NULL WHERE GvFondsID = @gvFondsID;
        PRINT 'dbo.GvFonds.KbZahlungskontoID auf NULL aktualisiert für GvFondsID=' + CONVERT(VARCHAR,@gvFondsID);
      END
      ELSE IF @Zahlungskonto IS NOT NULL
      BEGIN
        -- @Zahlungskonto schon im DB ?
        SELECT @KbZahlungskontoID = KbZahlungskontoID FROM dbo.KbZahlungskonto WHERE Name = @Zahlungskonto;           
        IF @KbZahlungskontoID is null 
        BEGIN
        
          -- Neue Zahlung im DB
          INSERT INTO dbo.KbZahlungskonto (Name, VertragNr, KontoNr, KbFinanzInstitutCode) -- TODO : BankID
          SELECT @Zahlungskonto, @VertragNr, @KontoNr, @KbFinanzInstitutCode;

          SET @KbZahlungskontoID = SCOPE_IDENTITY();
          PRINT 'Neue KbZahlungskonto KbZahlungskontoID=' + CONVERT(VARCHAR,@KbZahlungskontoID);
        END;
        
         -- alte Zahlung gleich?
        IF @KbZahlungskontoIDalt != @KbZahlungskontoID
        BEGIN
          -- KbZahlungsKontoID aktualisieren
          UPDATE dbo.GvFonds SET KbZahlungskontoID = @KbZahlungskontoID WHERE GvFondsID = @GvFondsID;              
          PRINT 'GvFonds mit GvFondsID= ' + CONVERT(VARCHAR,@GvFondsID) + ' aktualisert KbZahlungskontoID=' + CONVERT(VARCHAR,@KbZahlungskontoID);
        END;      
      
      END;*/
          
      -- Bemerkungen für gvFondsID aktualisieren
      -- xLangText Tabelle für Bemerkung aktualisieren
      SET @BemerkungTIDold = NULL;
      SELECT @BemerkungTIDold = BemerkungTID FROM dbo.GvFonds WHERE GvFondsID = @GvFondsID;      
      PRINT 'für GvFondsID=' + CONVERT(VARCHAR,@GvFondsID) + ' hatte bis jetzt BemerkungTID=' + ISNULL(CONVERT(VARCHAR,@BemerkungTIDold),'NULL');
      
      SET @BemerkungTIDNeu = NULL;
      IF @BemerkungD IS NOT NULL  
      BEGIN
        EXEC dbo.spXSetXLangText @BemerkungTIDNeu, 1, @BemerkungD, NULL, NULL, NULL, NULL, @BemerkungTIDNeu OUT;      
      END ;
      IF @BemerkungF IS NOT NULL 
      BEGIN
        EXEC dbo.spXSetXLangText @BemerkungTIDNeu, 2,@BemerkungF,  NULL, NULL, NULL, NULL, @BemerkungTIDNeu OUT;
      END;
      IF @BemerkungI IS NOT NULL 
      BEGIN
        EXEC dbo.spXSetXLangText @BemerkungTIDNeu, 3, @BemerkungI,  NULL, NULL, NULL, NULL, @BemerkungTIDNeu OUT;
      END;
    
      -- BemerkungTID und Bemerkung im GvFonds aktualisieren
      UPDATE dbo.GvFonds
      SET BemerkungTID = @BemerkungTIDNeu, 
          Bemerkung = COALESCE(@BemerkungD,COALESCE(@BemerkungF,@BemerkungI))
      WHERE GvFondsID = @GvFondsID;    
    
      PRINT 'Bemerkungen für GvFondsID=' + CONVERT(VARCHAR,@GvFondsID) + ' aktualisiert';
           
                
      -- Abteilungen
      -- Liste der Abteilungenin der Temp Tabelle vom String füllen
      INSERT INTO @AbteilungenTable (Abteilung, GvFondsID)
      SELECT Abteilung = SplitValue,
			 GvFondsID = @GvFondsID
      FROM dbo.fnSplitStringToValues(@Abteilungen,',',1);


      SELECT @AbteilungenEntriesCount=COUNT(*) FROM @AbteilungenTable;

	  --Bestehende Abteilungs-Zuweisungen entfernen, falls sie nicht mehr in der Excel-Datei erwünscht sind

	  DELETE FOU 
	  FROM dbo.GvFonds_XOrgUnit FOU 
	    INNER JOIN dbo.XOrgUnit ORG ON ORG.OrgUnitID = FOU.OrgUnitID
	  WHERE FOU.GvFondsID = @GvFondsID
	    AND NOT EXISTS (SELECT TOP 1 1 FROM @AbteilungenTable WHERE Abteilung = ORG.ItemName
															    AND GvFondsID = @GvFondsID);

      WHILE (@AbteilungenEntriesIterator <= @AbteilungenEntriesCount)
      BEGIN
  
        SET @Abteilung = NULL;
        SELECT @Abteilung=Abteilung
        FROM @AbteilungenTable
        WHERE ID = @AbteilungenEntriesIterator;

       
        -- Abteilung da ?
        SET @OrgUnitID = NULL
        SELECT @OrgUnitID = OrgUnitID FROM dbo.XOrgUnit WHERE ItemName = @Abteilung;    
        IF @OrgUnitID IS NULL
        BEGIN
          -- Abteilung nicht gefunden      
          PRINT 'ERROR Die Abeilung XOrgUnit.ItemName=''' + @Abteilung + ''' wurde für den Fonds mit GvFondsID=' + CONVERT(VARCHAR,@GvFondsID) + ' nicht gefunden. Eintrag in dbo.GvFonds_XOrgUnit könnte nicht eingefügt werden. Bitte Abteilung im Excel analog KiSS eintragen, das Script aktualisieren, und dann wieder ausführen.';
        END;        
        ELSE
        BEGIN
          -- Abteilung schon zugewiesen ?
           IF EXISTS (SELECT TOP 1 1 FROM dbo.GvFonds_XOrgUnit WHERE GvFondsID = @GvFondsID AND OrgUnitID = @OrgUnitID)
           BEGIN
              -- Falls ja : Info Abteilung schon zugewiesen       
              PRINT 'Für den Fonds mit GvFondsID=' + CONVERT(VARCHAR,@GvFondsID) + ' und XOrgUnit.OrgUnitID=' + CONVERT(VARCHAR,@OrgUnitID) + ' mit XOrgUnit.ItemName=''' + @Abteilung + ''' gibt es schon einen Eintrag im dbo.GvFonds_XOrgUnit .';
           END;
           ELSE
           BEGIN        
              -- Falls nein : neue Verknüpfung
              INSERT INTO dbo.GvFonds_XOrgUnit(GvFondsID, OrgUnitID, Creator, Modifier )
              SELECT @GvFondsID, @OrgUnitID, dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID()), dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID());
              PRINT 'Neue Eintrag im GvFonds_XOrgUnit mit XOrgUnit.ItemName=' + @Abteilung + ' GvFondsID=' + CONVERT(VARCHAR,@GvFondsID);
           END;
        END;  
        
        PRINT '----';
        
        -- prepare for next entry
        SET @AbteilungenEntriesIterator = @AbteilungenEntriesIterator + 1;    
  
      END;    
         
    END;
    
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


--COMMIT
--ROLLBACK