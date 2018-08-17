/*===============================================================================================
  $Revision: 1$
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
DECLARE @Abteilung varchar(max);
DECLARE @DatumVon datetime;
DECLARE @OrgUnitID INT;

DECLARE @GvFondsToInsert TABLE
(
  GvFondsToInsertID INT IDENTITY(1, 1) NOT NULL, -- ID für die Ausführung in diesem Script
  Zahlungskonto varchar(50) NULL,  -- KbZahlungskonto.Name
  NameKurz varchar(200) NOT NULL, -- GvFonds.NameKurz
  NameLang varchar(500) NOT NULL, -- GvFonds.NameLang
  BemerkungD varchar(max) NULL, -- GvFonds.Bemerkung, XLangText.Text durch BemerkungTID verknüpft falls mehrsprachig
  BemerkungF varchar(max) NULL, -- GvFonds.Bemerkung, XLangText.Text durch BemerkungTID verknüpft falls mehrsprachig
  BemerkungI varchar(max) NULL, -- GvFonds.Bemerkung, XLangText.Text durch BemerkungTID verknüpft falls mehrsprachig
  GvFondsTypCode int NOT NULL, -- GvFonds.GvFondsTypCode (LOVCode=1 intern oder 2 extern)
  IstCH bit NOT NULL, -- GvFonds.IstCH (Schweiz oder Kant.)
  Abteilung varchar(MAX) NOT NULL, -- GvFonds_XOrgUnit.ItemName
  DatumVon datetime NOT NULL -- GvFonds.DatumVon GültigAb Datum (01.01.15)
);


-- TODO select aus Excel hinzufügen
INSERT INTO @GvFondsToInsert( Zahlungskonto, NameKurz, NameLang, BemerkungD, BemerkungF, BemerkungI, GvFondsTypCode, IstCH,  Abteilung, DatumVon )
SELECT NULL,'Autoabklärungsdienst/Service véhicule PI HS/SP','Autoabklärungsdienst/Service véhicule PI HS/SP','Einreichung eines Autoabklärungsmandats an PI HS, Abteilung Direkthilfe. Starten sie die Vorlage im Register Beilagen/Dokumente und füllen sie sie aus. Es sind die gleichen Beilagen zu den Finanzen einzureichen, wie für ein Gesuch. ','Remise d''un mandat d''enquête automobile au service Aide directe du Siège principal de PI. Ouvrez le modèle depuis l''onglet Annexes/Doc. et remplissez-le. Il faut joindre les mêmes justificatifs relatifs à la situation financière que pour une demande.','Conferimento di un mandato di accertamento auto alla sede principale PI, settore Aiuti diretti. Aprite il modello sotto Allegati/documenti e compilatelo. Vanno presentati gli stessi allegati relativi alla situazione finanziaria come per una domanda. ',1,1,'HS Zürich','2015-01-01'
UNION ALL SELECT NULL,'Paraplegiker-Stiftung, Schweizerische-nur/uniquement e-hockey','Schweizerische Paraplegiker-Stiftung-nur/uniquement E-hockey','Aufgrund einer speziellen Abmachungen werden Gesuche für e-hockey-Stühle via die Abteilung Direkthilfe, HS eingereicht. Max. Fr. 5''000.-.','Convention spéciale concernant les fauteuils roulants de e-hockey. Les demandes sont déposées par l''intermédiaire du service Aide directe du Siège principal de PI. Au max. Fr. 5''000.-.','A seguito di uno speciale accordo, le domande per le carrozzine per l’hockey vanno presentate tramite il settore Aiuti diretti, sede principale. Massimo 5000 franchi.',1,1,'HS Zürich','2015-01-01'
UNION ALL SELECT NULL,'Pro Audito, Fonds Irma Wigert','Pro Audito, Fonds Irma Wigert','Nur für Hörbehinderte und Gehörlose. Vorwiegend Hörgeräte. Da nur sporadische Entscheidsitzungen stattfinden, wird das Gesuch in der Regel via FLB-Schweiz oder anderer interner Fonds HS vorfinanziert.','Seulement pour personnes malentendantes ou sourdes. Surtout pour appareils auditifs. Etant donné que la fondation ne tient pas de séances régulières pour statuer sur les demandes, l''Office national PAH ou un autre fonds interne du Siège principal avancent en général un montant.','Soltanto per deboli d’udito e non udenti. Soprattutto apparecchi acustici. Poiché le riunioni decisionali hanno luogo solo sporadicamente, la domanda è in genere pre-finanziata tramite PAH Svizzera o altri fondi interni della sede principale.',1,1,'HS Zürich','2015-01-01'
-- KGS VS existiert erst ab Release 4.7.09: 
--UNION ALL SELECT 'PAH-FLB VS','PAH-FLB canton VS','PAH-FLB canton VS',NULL,NULL,NULL,1,0,'KGS VS','2015-01-01'

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT  @Zahlungskonto = TMP.Zahlungskonto,
          @NameKurz = TMP.NameKurz,
          @NameLang = TMP.NameLang,
          @BemerkungD = TMP.BemerkungD,
          @BemerkungF = TMP.BemerkungF,
          @BemerkungI = TMP.BemerkungI,
          @GvFondsTypeCode = TMP.GvFondsTypCode,
          @IstCH = TMP.IstCH,
          @Abteilung = TMP.Abteilung,
          @DatumVon = TMP.DatumVon
  FROM @GvFondsToInsert TMP
  WHERE TMP.GvFondsToInsertID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- do something
  -----------------------------------------------------------------------------
  BEGIN TRY
    BEGIN TRAN;
           
    PRINT 'INSERT BEGIN Fonds NameKurz=' + @NameKurz;
           
    SET @gvFondsID = NULL;    
    SET @KbZahlungskontoID = NULL;
       
    -- KbZahlungskonto 
    -- Zahlungskonto nötig ?
    IF @Zahlungskonto IS NOT NULL
    BEGIN  
        
        -- KbZahlungskonto schon da ?
          SELECT @KbZahlungskontoID = KbZahlungskontoID
          FROM dbo.KbZahlungskonto
          WHERE 1=1
          AND Name = @Zahlungskonto
          
          IF @KbZahlungskontoID IS NULL 
          PRINT 'ERROR Das Zahlungskonto' + @Zahlungskonto + ' könnte in der DB nicht gefunden werden und wurde nicht an den Fonds ' + @NameKurz + ' zugewiesen. Bitte das Zahlungskonto im KiSS eintragen oder der NameKurz des Kontos korrigieren, und dann das Script wieder ausführen.';                                    
         

    END;
    
    -- Fonds schon da ?    
    SELECT @gvFondsID = GvFondsID FROM dbo.GvFonds WHERE NameKurz = @NameKurz;
    IF @gvFondsID IS NOT NULL
    BEGIN
      PRINT 'Fonds mit dbo.GvFonds.NameKurz=' + @NameKurz + ' schon in der DB GvFondsID=' + CONVERT(VARCHAR,@GvFondsID);
      
       UPDATE dbo.GvFonds
       SET  KbZahlungskontoID = @KbZahlungskontoID,
            NameKurz = @NameKurz, 
            NameLang = @NameLang,
            GvFondsTypCode = @GvFondsTypeCode,
            IstCH = @IstCH,
            DatumVon =  dbo.fnDateOf(@DatumVon)
      WHERE GvFondsID = @GvFondsID;
      
      PRINT 'dbo.gvFonds aktualisiert KbZahlungskontoID=' + COALESCE(CONVERT(VARCHAR,@KbZahlungskontoID),'NULL') + ' KbZahlungskonto.Name=' + COALESCE(@Zahlungskonto,'NULL')
                                    + ' NameKurz=' + @NameKurz 
                                    + ' NameLang=' + @NameLang 
                                    + ' GvFondsTypCode=' + CONVERT(VARCHAR,@GvFondsTypeCode) 
                                    + ' IstCH=' + CONVERT(VARCHAR,@IstCH)
                                    + ' DatumVon=' + COALESCE(CONVERT(VARCHAR,@DatumVon,104),'NULL'); 

      
    END;
    ELSE
    BEGIN    
       -- Neue Fonds      
       INSERT INTO dbo.GvFonds(KbZahlungskontoID, DatumVon, NameKurz, NameLang,GvFondsTypCode, IstCH, Creator, Modifier)
       SELECT @KbZahlungskontoID, @DatumVon, @NameKurz, @NameLang, @GvFondsTypeCode, @IstCH, dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID()), dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID());      
       
       SET @GvFondsID = SCOPE_IDENTITY();
       PRINT 'Neuer Fonds GvFondsID=' + CONVERT(VARCHAR,@GvFondsID) + ' NameKurz=' + @NameKurz + ' KbZahlungskontoID=' + COALESCE(CONVERT(VARCHAR,@KbZahlungskontoID),'NULL') 
    
    END;    
       
    -- Bemerkungen für gvFondsID aktualisieren
    SET @BemerkungTID = NULL
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
      SET BemerkungTID = @BemerkungTID
      WHERE GvFondsID = @GvFondsID;
    END
    
    UPDATE dbo.GvFonds
    SET Bemerkung = COALESCE(@BemerkungD,COALESCE(@BemerkungF,@BemerkungI))
    WHERE GvFondsID = @GvFondsID;
    
    PRINT 'Bemerkungen für GvFondsID=' + CONVERT(VARCHAR,@GvFondsID) + ' aktualisiert.'
    
    -- Abteilung 
    
    -- Abteilung da ?
    SET @OrgUnitID = NULL
    SELECT @OrgUnitID = OrgUnitID FROM dbo.XOrgUnit WHERE ItemName = @Abteilung;    
    IF @OrgUnitID IS NULL
    BEGIN
      -- Abteilung nicht gefunden      
      PRINT 'ERROR Die Abeilung XOrgUnit.ItemName=''' + @Abteilung + ''' wurde nicht gefunden für das Fonds GvFondsID=' + CONVERT(VARCHAR,@GvFondsID) + '. Eintrag im dbo.GvFonds_XOrgUnit könnte nicht eingefügt werden. Bitte den Namen der Abteilung im Excel korrigieren und wieder ausführen.';
    END;
    ELSE
    BEGIN
      -- Abteilung schon zugewiesen ?
       IF EXISTS (SELECT TOP 1 1 FROM dbo.GvFonds_XOrgUnit WHERE GvFondsID = @GvFondsID AND OrgUnitID = @OrgUnitID)
       BEGIN
          -- Falls ja : Info Abteilung schon zugewiesen       
          PRINT 'Für den Fonds mit GvFondsID=' + CONVERT(VARCHAR,@GvFondsID) + ' mit OrgUnitID=' + CONVERT(VARCHAR,@OrgUnitID) + ' XOrgUnit.ItemName=''' + @Abteilung + ''' gibt es schon einen Eintrag im dbo.GvFonds_XOrgUnit .';
       END;
       ELSE
       BEGIN        
          -- Falls nein : neue Verknüpfung
          INSERT INTO dbo.GvFonds_XOrgUnit(GvFondsID, OrgUnitID, Creator, Modifier )
          SELECT @GvFondsID, @OrgUnitID, dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID()), dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID());
          PRINT 'Neuer Eintrag im GvFonds_XOrgUnit mit XOrgUnit.ItemName=' + @Abteilung + ' GvFondsID=' + CONVERT(VARCHAR,@GvFondsID);
       END;
    END;
    
    PRINT '----'
    
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

