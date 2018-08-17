SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFaFall_Close
GO
/*
===================================================================================================
Author:      sozheo
Create date: 17.07.2008
Description: Fall automatisch schliessen, wenn alle F und FA geschlossen sind

===================================================================================================
History:
16.07.2008 : sozheo : Neu
17.07.2008 : sozheo : Neuer User setzen korrigiert
21.08.2008 : sozheo : Korrekturen SQL Performance
29.01.2009 : sozheo : Übernommen aus DB vom Sommer 2008

===================================================================================================
*/

CREATE PROCEDURE dbo.spFaFall_Close
  -- @FaFallID
  @FaFallID INT,
  -- @ProzessCode
  @ProzessCode INT,
  -- UserID
  @UserID INT
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON

  -- Kontrolle der Parameter
  -- -----------------------
  IF @FaFallID IS NULL BEGIN
    --RAISERROR ('Der Aufruf-Parameter @FaFallID ist null!', 18, 1)
    SELECT Error = 'Der Aufruf-Parameter @FaFallID ist null!'
    RETURN -1
  END
  IF @ProzessCode IS NULL BEGIN
    --RAISERROR ('Der Aufruf-Parameter @FaFallID ist null!', 18, 1)
    SELECT Error = 'Der Aufruf-Parameter @ProzessCode ist null!'
    RETURN -1
  END
  IF @ProzessCode NOT IN (200,201) BEGIN
    --RAISERROR ('Der Fall kann nur für Prozesse 200 und 201 abgeschlossen werden!', 18, 1)
    SELECT Error = 'Der Fall kann nur für Prozesse 200 und 201 abgeschlossen werden!'
    RETURN -1
  END
  IF @UserID IS NULL BEGIN
    --RAISERROR ('Der Aufruf-Parameter @UserID ist null!', 18, 1)
    SELECT Error = 'Der Aufruf-Parameter @UserID ist null!'
    RETURN -1
  END

  DECLARE
    @OldUserID INT,
    @NewUserID INT,
    @OldUserLogon varchar(50),
    @NewUserLogon varchar(50),
    @UserMsg varchar(500)

  SELECT
    @OldUserID = F.UserID,
    @OldUserLogon = LogonName
  FROM dbo.FaFall F WITH(READUNCOMMITTED)
  LEFT JOIN XUser U ON U.UserID = F.UserID
  WHERE F.FaFallID = @FaFallID

  IF NOT EXISTS(
    SELECT FaLeistungID FROM dbo.FaLeistung WITH(READUNCOMMITTED)
    WHERE FaFallID = @FaFallID
      AND DatumBis IS NULL
  )
  BEGIN
    -- der Fall ist offen, also autoamtisch schliessen, 
    -- wenn keine offenen Leistungen mehr existieren
    -- -----------------------------------------------------
    -- update
    UPDATE dbo.FaFall SET
      DatumBis = (
        SELECT IsNull(MAX(DatumBis), GetDate())
        FROM dbo.FaLeistung WITH(READUNCOMMITTED)
        WHERE FaFallID = @FaFallID)
    WHERE FaFallID = @FaFallID
    -- Fall-Protokoll
    EXEC dbo.spFaJournal_Insert @FaFallID, NULL, NULL, @UserID, 0, 'Abschluss Fall automatisch'
  END
  ELSE
  BEGIN
    -- wenn noch offenen Leistungen F existieren, 
    -- dann soll ev. der FaFall.User gewechselt werden
    -- -----------------------------------------------------
    SELECT TOP 1
      @NewUserID = L.UserID,
      @NewUserLogon = U.LogonName
    FROM dbo.FaLeistung L WITH(READUNCOMMITTED)
    LEFT JOIN dbo.XUser U WITH(READUNCOMMITTED) ON U.UserID = L.UserID
    WHERE L.FaFallID = @FaFallID
      AND L.FaProzessCode IN (200, 201)
      AND L.DatumBis IS NULL
    ORDER BY L.FaProzessCode ASC

    -- neuer User setzen
    IF @OldUserID != @NewUserID AND @NewUserID IS NOT NULL
    BEGIN
      -- Update
      UPDATE dbo.FaFall SET UserID = @NewUserID WHERE FaFallID = @FaFallID
      -- Protokoll
      SET @UserMsg = 'Falllverantwortlicher geändert (' +
        CONVERT(varchar(20), IsNull(@OldUserLogon,0)) + '->' +
        CONVERT(varchar(20), IsNull(@NewUserLogon,0)) + ')'
      EXEC dbo.spFaJournal_Insert @FaFallID, NULL, NULL, @UserID, 0, @UserMsg
    END
  END

  SELECT Error = ''
  RETURN 2
END
