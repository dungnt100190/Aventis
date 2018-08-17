SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spIkSollstellung_KbBuchung_Undo
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spIkSollstellung_KbBuchung_Undo
  -- IkPositionID:
  @IkPositionID INT
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON


  -- ==========================
  -- Kontrolle der Parameter:
  -- ==========================
  IF @IkPositionID IS NULL BEGIN
    SELECT 1 AS HasErrors, 'Fehler in Parameter: Der Parameter @IkPositionID ist ungültig.' AS ErrorText
    RETURN
  END


  -- =======================================================
  -- Kontrolle, ob rückgängig gemacht werden darf:
  -- =======================================================
  DECLARE @AnzahlGesperrt INT
  -- Hier kein WITH(READUNCOMMITTED), wir wollen nur committete Buchungen sehen
  SELECT @AnzahlGesperrt = COUNT(*) FROM dbo.KbBuchung B
  WHERE B.IkPositionID = @IkPositionID
    AND B.KbBuchungStatusCode NOT IN (2,5,8)
  IF @AnzahlGesperrt > 0 BEGIN
    SELECT 1 AS HasErrors, 'Diese Position ist gesperrt und kann nicht mehr rückgängig gemacht werden.' AS ErrorText
    RETURN
  END


  -- =======================================================
  -- RechtstitelID, PersonID und Anzahl holen:
  -- =======================================================
  DECLARE @UndoCount INT
  -- Hier kein WITH(READUNCOMMITTED), wir wollen nur committete Buchungen sehen
  SELECT @UndoCount = COUNT(*) FROM dbo.KbBuchung
  WHERE IkPositionID = @IkPositionID
    AND KbBuchungStatusCode != 8


  -- =======================================================
  -- Löschen KbBuchung
  -- =======================================================
  BEGIN TRANSACTION
  BEGIN TRY
    -- Buchungen löschen 
    DELETE dbo.KbBuchung
    WHERE IkPositionID = @IkPositionID
      AND KbBuchungStatusCode != 8
    COMMIT TRANSACTION
  END TRY
  BEGIN CATCH
    -- Fehlerbehandlung
    ROLLBACK TRANSACTION
    DECLARE @Msg varchar(200)
    SET @Msg = ERROR_MESSAGE()
    SELECT 1 AS HasErrors, @Msg AS ErrorText
    RETURN
  END CATCH

  -- Alles ok, Anzahl Buchung zurückgeben
  SELECT 0 AS HasErrors, @UndoCount AS UndoCount

END
