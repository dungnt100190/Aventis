SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spTpLoadConfigData
GO

/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Lädt die Konfiguration von der CROSS_DB_DATEN in die Datenbank.  Siehe auch
    spTpSaveConfigData. 

  Folgende Daten werden von der CROSS_DB_DATEN übernommen:
   - Einge Einträge aus XConfig (z.B. Webservice URLs).
     - Alle Werte der Tabellen PscdKeySource, PscdSentBaAdresse, PscdSentBaInstitution,
       PscdSentBaPerson, PscdSentBaZahlungsweg, PscdSentFaLeistung, PscdSentFaLeistung_Person


    @LeavePSCDCounter: Wenn dieser Parameter 1 ist, dann werden nur die XConfig Werte geladen.
                     Um auch die PSCD Counter zu laden, muss dieser Parameter 0 sein.
  -
  RETURNS: Kein Rückgabewert.
  -
  TEST:    exec spTpLoadConfigData 0;
=================================================================================================
*/

CREATE PROCEDURE dbo.spTpLoadConfigData
(
  @LeavePSCDCounter bit = 0
)
AS
BEGIN TRY
  BEGIN TRAN

  DECLARE @DBName varchar(50);
  SET @DBName = DB_NAME();

  -- Konfigurationswerte (PSCD-Server, Alpha-DSN, KIS-URL etc. laden)
  DELETE FROM XConfig
  WHERE KeyPath IN (SELECT KeyPath COLLATE DATABASE_DEFAULT
                    FROM CROSS_DB_DATEN.dbo.ConfigKeyPathToKeep);

  SET IDENTITY_INSERT XConfig ON;

  INSERT INTO XConfig(
    XConfigID,
    XNamespaceExtensionID,
    KeyPath,
    [System],
    DatumVon,
    ValueCode,
    LOVName,
    [Description],
    ValueBit,
    OriginalValueBit,
    ValueDateTime,
    OriginalValueDateTime,
    ValueDecimal,
    OriginalValueDecimal,
    ValueInt,
    OriginalValueInt,
    ValueMoney,
    OriginalValueMoney,
    ValueVarchar,
    OriginalValueVarchar,
    Creator,
    Created,
    Modifier,
    Modified)
    SELECT
      XConfigID,
      XNamespaceExtensionID,
      KeyPath,
      [System],
      DatumVon,
      ValueCode,
      LOVName,
      [Description],
      ValueBit,
      OriginalValueBit,
      ValueDateTime,
      OriginalValueDateTime,
      ValueDecimal,
      OriginalValueDecimal,
      ValueInt,
      OriginalValueInt,
      ValueMoney,
      OriginalValueMoney,
      ValueVarchar,
      OriginalValueVarchar,
      Creator,
      Created,
      Modifier,
      Modified
    FROM CROSS_DB_DATEN.dbo.XConfig
    WHERE DBName = @DBName;

  SET IDENTITY_INSERT XConfig OFF;

  -- Alte Nummernstände wieder laden
  IF @LeavePSCDCounter = 0 
  BEGIN
    -- Einträge aus PscdKeySource.
    DELETE FROM PscdKeySource
    INSERT INTO PscdKeySource(KeyName,NextID,FirstID,LastID,NumberCategory)
    SELECT KeyName,NextID,FirstID,LastID,NumberCategory
    FROM CROSS_DB_DATEN.dbo.PscdKeySource
    WHERE DBName = @DBName

  -- Einträge aus PscdSentBaAdresse.
    DELETE FROM PscdSentBaAdresse
    INSERT INTO PscdSentBaAdresse(BaAdresseID,BaAdresseTS_Sent,SentToPscd)
    SELECT BaAdresseID,BaAdresseTS_Sent,SentToPscd
    FROM CROSS_DB_DATEN.dbo.PscdSentBaAdresse
    WHERE DBName = @DBName

  -- Einträge aus PscdSentBaInstitution.
    DELETE FROM PscdSentBaInstitution
    INSERT INTO PscdSentBaInstitution(BaInstitutionID,BaInstitutionTS_Sent,SentToPscd)
    SELECT BaInstitutionID,BaInstitutionTS_Sent,SentToPscd
    FROM CROSS_DB_DATEN.dbo.PscdSentBaInstitution
    WHERE DBName = @DBName

  -- Einträge aus PscdSentBaPerson.
    DELETE FROM PscdSentBaPerson
    INSERT INTO PscdSentBaPerson(BaPersonID,BaPersonTS_Sent,SentToPscd)
    SELECT BaPersonID,BaPersonTS_Sent,SentToPscd
    FROM CROSS_DB_DATEN.dbo.PscdSentBaPerson
    WHERE DBName = @DBName

  -- Einträge aus PscdSentBaZahlungsweg.
    DELETE FROM PscdSentBaZahlungsweg
    INSERT INTO PscdSentBaZahlungsweg(BaZahlungswegID,BaZahlungswegTS_Sent,SentToPscd,SapID)
    SELECT BaZahlungswegID,BaZahlungswegTS_Sent,SentToPscd,SapID
    FROM CROSS_DB_DATEN.dbo.PscdSentBaZahlungsweg
    WHERE DBName = @DBName

  -- Einträge aus PscdSentFaLeistung.
    DELETE FROM PscdSentFaLeistung
    INSERT INTO PscdSentFaLeistung(FaLeistungID,FaLeistungTS_Sent,SentToPscd)
    SELECT FaLeistungID,FaLeistungTS_Sent,SentToPscd
    FROM CROSS_DB_DATEN.dbo.PscdSentFaLeistung
    WHERE DBName = @DBName

  -- Einträge aus PscdSentFaLeistung_Person.
    DELETE FROM PscdSentFaLeistung_Person
    INSERT INTO PscdSentFaLeistung_Person(FaLeistungID,BaPersonID,SentToPscd)
    SELECT FaLeistungID,BaPersonID,SentToPscd
    FROM CROSS_DB_DATEN.dbo.PscdSentFaLeistung_Person
    WHERE DBName = @DBName
  END;

  COMMIT;
  PRINT 'COMMITED';
END TRY
BEGIN CATCH
  ROLLBACK;
  PRINT 'ROLLED BACK';
    
  DECLARE @ErrorMessage NVARCHAR(4000);
  DECLARE @ErrorState INT;
    
  SELECT @ErrorMessage = ERROR_MESSAGE(),
          @ErrorState = ERROR_STATE();
    
  -- Use RAISERROR inside the CATCH block to return 
  -- error information about the original error that 
  -- caused execution to jump to the CATCH block.
  RAISERROR (@ErrorMessage, -- Message text.
              18, -- Severity. Muss hoch sein, sonst wird der error nicht rot im Management Studio angezeigt.
              @ErrorState -- State.
              );
END CATCH;
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
