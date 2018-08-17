-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @GvGesuchID INT;

DECLARE @GvGesuchToDelete TABLE
(
  ID INT IDENTITY(1, 1) NOT NULL,
  GvGesuchID INT NOT NULL
);

INSERT INTO @GvGesuchToDelete(GvGesuchID )
-- TODO select aus Excel hinzufügen (Funktion im Excel: =CONCATENATE("  SELECT ";A2;" UNION ALL"))
-- start insert from Excel
  SELECT ?
-- stop insert from Excel

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT @GvGesuchID = TMP.GvGesuchID
  FROM @GvGesuchToDelete TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- do something
  -----------------------------------------------------------------------------
  BEGIN TRY
    BEGIN TRAN;

    DELETE FROM dbo.GvAbklaerendeStelle WHERE GvGesuchID = @GvGesuchID
    DELETE FROM dbo.GvAntragPosition WHERE GvGesuchID = @GvGesuchID
    DELETE FROM dbo.GvAuflage WHERE GvGesuchID = @GvGesuchID
    DELETE FROM dbo.GvAuszahlungPosition WHERE GvGesuchID = @GvGesuchID
    DELETE FROM dbo.GvAuszahlungPositionValuta WHERE GvAuszahlungPositionID IN (SELECT GvAuszahlungPositionID
                                                                                FROM dbo.GvAuszahlungPosition 
                                                                                WHERE GvGesuchID = @GvGesuchID)
    DELETE FROM dbo.GvBewilligung WHERE GvGesuchID = @GvGesuchID
    DELETE FROM dbo.XDocument WHERE DocumentID IN (SELECT DocumentID
                                                   FROM dbo.GvDocument
                                                   WHERE GvGesuchID = @GvGesuchID)

    DELETE FROM dbo.GvDocument WHERE GvGesuchID = @GvGesuchID
    --nicht löschen: Information auf CtlFaFinanzgesuche
    --DELETE FROM dbo.GvDokumenteInformation WHERE GvGesuchID = @GvGesuchID
    DELETE FROM dbo.XDocument WHERE DocumentID IN (SELECT DocumentID
                                                   FROM dbo.GvGesuch
                                                   WHERE GvGesuchID = @GvGesuchID)
    DELETE FROM dbo.GvGesuch WHERE GvGesuchID = @GvGesuchID
    
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

