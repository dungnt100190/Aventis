SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spKbGetBelegNr;
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @KbPeriodeID:         .
    @KbBelegKreisCode:    .
    @KontoNr:             .
    @ReturnWithoutSelect: .
  -
  RETURNS: The BelegNr or -1 in case no available BelegNr could be found
  -
=================================================================================================
  TEST:    EXEC dbo.spKbGetBelegNr 30, 4, NULL, 0
=================================================================================================*/

CREATE PROCEDURE dbo.spKbGetBelegNr
(
  @KbPeriodeID INT,
  @KbBelegKreisCode INT,
  @KontoNr VARCHAR(10),
  @ReturnWithoutSelect BIT = 0
)
AS BEGIN
  -------------------------------------------------------------------------------
  -- declare and init vars
  -------------------------------------------------------------------------------
  DECLARE @KbBelegKreisID INT;
  DECLARE @FreieBelegNr INT;
  DECLARE @NaechsteBelegNr INT;
  
  DECLARE @TryNr TINYINT;
  DECLARE @BelegNrFound BIT;
  
  SET @TryNr = 0;
  SET @BelegNrFound = 0;

  -- hole die Anzahl von letzte Belegnummern die wieder verwendet werden können
  DECLARE @NumOfBelegNrToReuse INT;
  SELECT @NumOfBelegNrToReuse = CONVERT(VARCHAR, dbo.fnXConfig('System\KliBu\AnzahlBelegNrZuWiederVerwenden', GETDATE()));
  
  -------------------------------------------------------------------------------
  -- loop five time to get next belegnr
  -------------------------------------------------------------------------------
  WHILE (@TryNr < 5)
  BEGIN
    -- first, count up
    SET @TryNr = @TryNr + 1;
    
    -- reset vars
    SET @KbBelegKreisID = NULL;
    SET @FreieBelegNr = NULL;
    SET @NaechsteBelegNr = NULL;
    
    -- hole die nächst höhere BelegNummer basierend auf der Tabelle 'KbBelegKreis'
    SELECT @KbBelegKreisID  = BLK.KbBelegKreisID,
           @NaechsteBelegNr = BLK.NaechsteBelegNr
    FROM dbo.KbBelegKreis BLK
    WHERE BLK.KbPeriodeID = @KbPeriodeID
      AND BLK.KbBelegKreisCode = @KbBelegKreisCode
      AND ISNULL(BLK.KontoNr, '') = ISNULL(@KontoNr, '');
    
    -- hole die kleinste freie BelegNummer innerhalb des gültigen Bereiches
    SELECT TOP 1 
           @FreieBelegNr = BelegNr
    FROM dbo.KbFreieBelegNummer FBL
      INNER JOIN KbBelegKreis   BLK ON BLK.KbBelegKreisID = FBL.KbBelegKreisID
    WHERE FBL.KbBelegKreisID = @KbBelegKreisID
      AND FBL.BelegNr >= (@NaechsteBelegNr - @NumOfBelegNrToReuse)  -- ältere BelegNummern sollen nicht mehr verwendet werden!
      AND FBL.BelegNr BETWEEN BLK.BelegNrVon AND BLK.BelegNrBis 
    ORDER BY FBL.BelegNr;
    
    IF (@KbBelegKreisID IS NOT NULL AND @FreieBelegNr IS NOT NULL)
    BEGIN
      -- remove free entry that was found above (this process is atomar and therefore concurrency safe)
      DELETE FROM dbo.KbFreieBelegNummer
      WHERE KbBelegKreisID = @KbBelegKreisID 
        AND BelegNr = @FreieBelegNr;
      
      -- check if successfully removed entry
      IF (@@ROWCOUNT <> 1)
      BEGIN
        -- failed, retry again
        CONTINUE;
      END
      ELSE
      BEGIN
        -- success, set flag and discontinue loop
        SET @BelegNrFound = 1;
        BREAK;
      END;
    END
    ELSE
    BEGIN
      -- update and set next entry (this process is atomar and therefore concurrency safe)
      UPDATE dbo.KbBelegKreis
      SET NaechsteBelegNr = NaechsteBelegNr + 1
      WHERE KbPeriodeID = @KbPeriodeID
        AND KbBelegKreisID = @KbBelegKreisID    -- exact matching entry (periode is just for security reason)
        AND NaechsteBelegNr = @NaechsteBelegNr;
      
      -- check if successfully updated entry
      IF (@@ROWCOUNT <> 1)
      BEGIN
        -- failed, retry again
        CONTINUE;
      END
      ELSE
      BEGIN
        -- success, set flag and discontinue loop
        SET @BelegNrFound = 1;
        BREAK;
      END;
    END;
  END; -- [while]
  
  -------------------------------------------------------------------------------
  -- validate success
  -------------------------------------------------------------------------------
  IF (@BelegNrFound = 0)
  BEGIN
    DECLARE @ErrMsg VARCHAR(500)
    SET @ErrMsg = 'Failed getting next free number for KbPeriodeID=''' + CONVERT(VARCHAR(50), @KbPeriodeID) + ''' and KbBelegKreisCode=''' + CONVERT(VARCHAR(50), @KbBelegKreisCode) + '''';
    
    -- break with error
    RAISERROR(@ErrMsg, 18, 1);
    RETURN -1; --rather return a defined value than e.g. -8
  END;
  
  -------------------------------------------------------------------------------
  -- select/return next free number
  -------------------------------------------------------------------------------
  -- TODO für migration entfernt! (???)
  IF (@ReturnWithoutSelect = 0)
  BEGIN
    SELECT COALESCE(@FreieBelegNr, @NaechsteBelegNr, -1);
  END;
  
  RETURN COALESCE(@FreieBelegNr, @NaechsteBelegNr, -1);
END;
GO