SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKbBuchung_StornoAll
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

CREATE PROCEDURE dbo.spKbBuchung_StornoAll
(
  @KbBuchungID INT,
  @UserID INT,
  @StornoAll BIT = NULL
)
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON

  -- Kontrolle Parameter
  -- -------------------
  IF @KbBuchungID IS NULL BEGIN
    RAISERROR ('Der Aufruf-Parameter @KbBuchungID ist null!', 18, 1)
    RETURN -1
  END
  IF @UserID IS NULL BEGIN
    RAISERROR ('Der Aufruf-Parameter @UserID ist null!', 18, 1)
    RETURN -1
  END
  IF @StornoAll IS NULL SET @StornoAll = 0

  DECLARE
    @KbBuchungStatusCode INT,
    @ModulID INT,
    @IkPositionID INT,
    @ActID INT,
    @StornoKbBuchungID INT,
    @StornoDatum DATETIME,
    @ErrorOfOneStorno varchar(200)


  -- Kontrolle Buchungsstaus
  -- -----------------------
  SELECT
    @KbBuchungStatusCode = B.KbBuchungStatusCode,
    @IkPositionID = B.IkPositionID,
    @ModulID = B.ModulID
  FROM dbo.KbBuchung B WITH (READUNCOMMITTED)
  WHERE B.KbBuchungID = @KbBuchungID

  IF @KbBuchungStatusCode IS NULL BEGIN
    RAISERROR ('Buchung nicht gefunden.', 18, 1)
    RETURN -1
  END
  IF @StornoAll = 0 AND @KbBuchungStatusCode != 3 BEGIN
    RAISERROR ('Diese Buchung hat nicht Buchungsstatus 3 (Zahlauftrag erstellt).', 18, 1)
    RETURN -1
  END

  -- Kontrolle Alimente
  -- ------------------
  IF @ModulID = 4 AND @StornoAll = 1 AND @IkPositionID IS NULL
  BEGIN
    DECLARE @Msg varchar(200)
    SET @Msg = 'IkPosition nicht gefunden ('+CONVERT(varchar, IsNull(@IkPositionID, 0))+').'
    RAISERROR (@Msg, 18, 1)
    RETURN -1
  END
  IF @ModulID = 4 AND @StornoAll = 1 AND EXISTS(
    SELECT KbBuchungID FROM dbo.KbBuchung WITH (READUNCOMMITTED)
    WHERE IkPositionID = @IkPositionID
      AND IkForderungArtCode IN (10,11,12,13,14,15) )
  BEGIN
    RAISERROR ('Alimenteninkassi mit Verpflichtungen können nicht als Ganzes storniert werden.', 18, 1)
    RETURN -1
  END
  IF @ModulID = 4 AND @StornoAll = 1 AND EXISTS(
    SELECT KbBuchungID FROM dbo.KbBuchung WITH (READUNCOMMITTED)
    WHERE IkPositionID = @IkPositionID
      AND KbBuchungStatusCode NOT in (3,8)
      AND StorniertKbBuchungID IS NULL
    )
  BEGIN
    RAISERROR ('Diese Position hat Buchungen, welche nicht den Status 3 (Zahlauftrag erstellt) haben.', 18, 1)
    RETURN -1
  END


  SET @StornoDatum = GetDate()
  SET @ErrorOfOneStorno = NULL
  BEGIN TRANSACTION
  BEGIN TRY

    IF @ModulID = 4 AND @StornoAll = 1
    BEGIN
      -- A Inkassomodul, wenn alle Buchungen storniert werden sollen
      -- darf nur gemacht werden, wenn keine Verpflichtungen existieren
      -- --------------------------------------------------------------
      DECLARE crs CURSOR FAST_FORWARD FOR
        SELECT KbBuchungID FROM dbo.KbBuchung WITH (READUNCOMMITTED)
        WHERE IkPositionID = @IkPositionID
          AND StorniertKbBuchungID IS NULL
          AND KbBuchungStatusCode != 8

      OPEN crs
      -- Spezielles TRY CATCH darf nicht entfernt werden, 
      -- da sonst bei Fehler der CURSOR nicht freigegeben wird:
      BEGIN TRY
        WHILE 1 = 1 BEGIN
          FETCH NEXT FROM crs INTO @ActID
          IF @@FETCH_STATUS != 0 BREAK
          EXEC dbo.spKbBuchung_Storno @ActID, @UserID, @StornoDatum, @StornoKbBuchungID
        END
      END TRY
      BEGIN CATCH
        SET @ErrorOfOneStorno = ERROR_MESSAGE()
      END CATCH
      CLOSE crs
      DEALLOCATE crs
      IF @ErrorOfOneStorno IS NOT NULL BEGIN
        -- Fehler beim Stronieren einer Buchung:
        RAISERROR(@ErrorOfOneStorno,18,1)
        RETURN -1
      END
      -- 25.02.2008 : sozheo : IkPosition.ErledigterMonat eliminiert
      /*ELSE BEGIN
        -- Stronieren aller Zeilen war erfolgreich, also:
        -- IkPosition updaten, damit diese Position wieder verbucht werden kann
        UPDATE IkPosition SET ErledigterMonat = 0
        WHERE IkPositionID = @IkPositionID
      END*/
    END
    --ELSE IF @ModulID = 4 AND @StornoAll = 0 
    --BEGIN
      -- A Inkassomodul, wenn nur eine Buchungen storniert werden soll
      -- darf nur gemacht werden, wenn keine Verpflichtungen existieren
      -- --------------------------------------------------------------
-- TODO: vorerst nicht möglich, da zuerst Sollstellung korrigiert werden müsste
      --EXEC dbo.spKbBuchung_Storno @KbBuchungID, @UserID, @StornoDatum, @StornoKbBuchungID
    --END
    ELSE IF @ModulID = 3 AND @IkPositionID IS NOT NULL
    BEGIN
      -- W Inkassomodul, wenn nur eine Buchungen storniert werden soll
      -- --------------------------------------------------------------
      EXEC dbo.spKbBuchung_Storno @KbBuchungID, @UserID, @StornoDatum, @StornoKbBuchungID

      -- IkPosition updaten, damit diese Position wieder verbucht werden kann
      -- 25.02.2008 : sozheo : IkPosition.ErledigterMonat eliminiert
      --UPDATE IkPosition SET ErledigterMonat = 0
      --WHERE IkPositionID = @IkPositionID
    END

    COMMIT TRANSACTION
  END TRY

  BEGIN CATCH
    -- Fehlermeldung
    -- -------------
    ROLLBACK TRANSACTION
    SET @ErrorOfOneStorno = ERROR_MESSAGE()
    RAISERROR(@ErrorOfOneStorno,18,1)
    RETURN -1
  END CATCH

  -- OK zurückgeben
  -- --------------
  RETURN 1
END

GO