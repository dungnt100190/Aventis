
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spTpSaveConfigData
GO

/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Speichert Konfigurationswerte von der Datenbank in die CROSS_DB_DATEN Datenbank ab.
  Siehe auch spTpLoadConfigData.

  Folgende Konfigurationswerte werden gespeichert:
  - Einge Einträge aus XConfig (z.B. Webservice URLs). Die zu speichernden Werte sind
    definiert in der Tabelle ConfigKeyPathToKeep.
  - Alle Werte der Tabellen PscdKeySource, PscdSentBaAdresse, PscdSentBaInstitution,
    PscdSentBaPerson, PscdSentBaZahlungsweg, PscdSentFaLeistung, PscdSentFaLeistung_Person

  RETURNS: Kein Rückgabewert
  -
  TEST: exec spTpSaveConfigData;
=================================================================================================
*/

CREATE PROCEDURE dbo.spTpSaveConfigData
AS
BEGIN TRY
  BEGIN TRAN

  DECLARE @DBName varchar(50);
  SET @DBName = DB_NAME();

  -- Werte aus XConfig löschen und neu laden. Die zu löschenden Konfigurationswerte sind definiert in ConfigKeyPathToKeep.
  DELETE FROM CROSS_DB_DATEN.dbo.XConfig
  WHERE DBName = @DBName;

  INSERT INTO CROSS_DB_DATEN.dbo.XConfig(
    DBName,
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
      @DBName,
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
    FROM XConfig
    WHERE KeyPath IN (SELECT KeyPath COLLATE DATABASE_DEFAULT
                      FROM CROSS_DB_DATEN.dbo.ConfigKeyPathToKeep);

  -- PscdKeySource Einträge in Crossdatenbank löschen und neu laden.
  DELETE FROM CROSS_DB_DATEN.dbo.PscdKeySource
  WHERE DBName = @DBName;
  INSERT INTO CROSS_DB_DATEN.dbo.PscdKeySource(DBName,KeyName,NextID,FirstID,LastID,NumberCategory)
    SELECT @DBName,KeyName,NextID,FirstID,LastID,NumberCategory
    FROM PscdKeySource;

  -- PscdSentBaAdresse Einträge in Crossdatenbank löschen und neu laden.
  DELETE FROM CROSS_DB_DATEN.dbo.PscdSentBaAdresse
  WHERE DBName = @DBName;
  INSERT INTO CROSS_DB_DATEN.dbo.PscdSentBaAdresse(DBName,BaAdresseID,BaAdresseTS_Sent,SentToPscd)
    SELECT @DBName,BaAdresseID,BaAdresseTS_Sent,SentToPscd
    FROM PscdSentBaAdresse;

  -- PscdSentBaInstitution Einträge in Crossdatenbank löschen und neu laden.
  DELETE FROM CROSS_DB_DATEN.dbo.PscdSentBaInstitution
  WHERE DBName = @DBName;
  INSERT INTO CROSS_DB_DATEN.dbo.PscdSentBaInstitution(DBName,BaInstitutionID,BaInstitutionTS_Sent,SentToPscd)
    SELECT @DBName,BaInstitutionID,BaInstitutionTS_Sent,SentToPscd
    FROM PscdSentBaInstitution;

  -- PscdSentBaPerson Einträge in Crossdatenbank löschen und neu laden.
  DELETE FROM CROSS_DB_DATEN.dbo.PscdSentBaPerson
  WHERE DBName = @DBName;
  INSERT INTO CROSS_DB_DATEN.dbo.PscdSentBaPerson(DBName,BaPersonID,BaPersonTS_Sent,SentToPscd)
    SELECT @DBName,BaPersonID,BaPersonTS_Sent,SentToPscd
    FROM PscdSentBaPerson;

  -- PscdSentBaZahlungsweg Einträge in Crossdatenbank löschen und neu laden.
  DELETE FROM CROSS_DB_DATEN.dbo.PscdSentBaZahlungsweg
  WHERE DBName = @DBName;
  INSERT INTO CROSS_DB_DATEN.dbo.PscdSentBaZahlungsweg(DBName,BaZahlungswegID,BaZahlungswegTS_Sent,SentToPscd,SapID)
    SELECT @DBName,BaZahlungswegID,BaZahlungswegTS_Sent,SentToPscd,SapID
    FROM PscdSentBaZahlungsweg;

   -- PscdSentFaLeistung Einträge in Crossdatenbank löschen und neu laden.
  DELETE FROM CROSS_DB_DATEN.dbo.PscdSentFaLeistung
  WHERE DBName = @DBName;
  INSERT INTO CROSS_DB_DATEN.dbo.PscdSentFaLeistung(DBName,FaLeistungID,FaLeistungTS_Sent,SentToPscd)
    SELECT @DBName,FaLeistungID,FaLeistungTS_Sent,SentToPscd
    FROM PscdSentFaLeistung;

  -- PscdSentFaLeistung Einträge in Crossdatenbank löschen und neu laden.
  DELETE FROM CROSS_DB_DATEN.dbo.PscdSentFaLeistung_Person
  WHERE DBName = @DBName;
  INSERT INTO CROSS_DB_DATEN.dbo.PscdSentFaLeistung_Person(DBName,FaLeistungID,BaPersonID,SentToPscd)
    SELECT @DBName,FaLeistungID,BaPersonID,SentToPscd
    FROM PscdSentFaLeistung_Person;

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
