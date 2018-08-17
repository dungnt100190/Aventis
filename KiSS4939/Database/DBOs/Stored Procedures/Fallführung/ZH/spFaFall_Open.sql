SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFaFall_Open
GO
/*
===================================================================================================
Author:      sozheo
Create date: 17.07.2008
Description: Fall autoamtisch oeffnen, wenn ein F/FA neu erstellt wird
             oder ein F/Fa wiedereröffnet wird

===================================================================================================
History:
17.07.2008 : sozheo : Neu
21.08.2008 : sozheo : Korrekturen SQL Performance
29.01.2009 : sozheo : Übernommen aus DB vom Sommer 2008

===================================================================================================
*/

CREATE PROCEDURE [dbo].[spFaFall_Open]
  -- FaFallID
  @FaFallID INT,
  -- @FaLeistungID
  @FaLeistungID INT,
  -- ProzessCode
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
    --RAISERROR ('Der Aufruf-Parameter @ProzessCode ist null!', 18, 1)
    SELECT Error = 'Der Aufruf-Parameter @ProzessCode ist null!'
    RETURN -1
  END
  IF @UserID IS NULL BEGIN
    --RAISERROR ('Der Aufruf-Parameter @UserID ist null!', 18, 1)
    SELECT Error = 'Der Aufruf-Parameter @UserID ist null!'
    RETURN -1
  END

  DECLARE
    @FallUserID INT,
    @LstUserID INT,
    @DatumBis DATETIME,
    @UserMsg varchar(500),
    @FallUserLogon varchar(50),
    @LstUserLogon varchar(50),
    @UserLogon varchar(50)

  SELECT
    @FallUserID = F.UserID,
    @DatumBis = F.DatumBis,
    @FallUserLogon = U.LogonName
  FROM dbo.FaFall F WITH(READUNCOMMITTED)
  LEFT JOIN dbo.XUser U WITH(READUNCOMMITTED) ON U.UserID = F.UserID
  WHERE FaFallID = @FaFallID

  SELECT
    @UserLogon = U.LogonName
  FROM dbo.XUser U WITH(READUNCOMMITTED)
  WHERE U.UserID = @UserID

  IF @DatumBis IS NOT NULL
  BEGIN
    -- Fall wiedereröffnen, wenn er geschlossen ist
    UPDATE dbo.FaFall SET DatumBis = NULL WHERE FaFallID = @FaFallID
    -- Protokoll
    EXEC dbo.spFaJournal_Insert @FaFallID, NULL, NULL, @UserID, 0, 'Wiedereröffnung Fall automatisch'
  END

  IF NOT @FaLeistungID IS NULL
  BEGIN
    -- Wenn eine Leistung F oder FA wieder eröffnet wird,
    -- soll ev. der User des Fall von einem F oder FA genommen werden
    -- Vorrang hat F
    SELECT TOP 1
      @LstUserID = L.UserID,
      @LstUserLogon = U.LogonName
    FROM dbo.FaLeistung L WITH(READUNCOMMITTED)
    LEFT JOIN dbo.XUser U WITH(READUNCOMMITTED) ON U.UserID = L.UserID
    WHERE L.FaFallID = @FaFallID
      AND (L.FaLeistungID = @FaLeistungID OR (L.FaProzessCode = 200 AND L.DatumBis IS NULL))
    ORDER BY L.FaProzessCode

    IF @FallUserID != @LstUserID
    BEGIN
      -- update
      UPDATE dbo.FaFall SET UserID = @LstUserID WHERE FaFallID = @FaFallID
      -- Protokoll
      SET @UserMsg = 'Falllverantwortlicher geändert (' +
        CONVERT(varchar(20), IsNull(@FallUserLogon,0)) + '->' +
        CONVERT(varchar(20), IsNull(@LstUserLogon,0)) + ')'
      EXEC dbo.spFaJournal_Insert @FaFallID, NULL, NULL, @UserID, 0, @UserMsg
    END
  END
  ELSE
  BEGIN
    -- Wenn eine neue Leistung F oder FA erstellt wird,
    -- soll ev. der User des Fall von einem F oder FA genommen werden
    -- Vorrang hat F
    IF @ProzessCode = 200 AND @FallUserID != @UserID
    BEGIN
      -- bei F soll der neue User der wichtige sein
      UPDATE dbo.FaFall SET UserID = @UserID WHERE FaFallID = @FaFallID
      -- Protokoll
      SET @UserMsg = 'Falllverantwortlicher geändert (' +
        CONVERT(varchar(20), IsNull(@FallUserLogon,0)) + '->' +
        CONVERT(varchar(20), IsNull(@UserLogon,0)) + ')'
      EXEC dbo.spFaJournal_Insert @FaFallID, NULL, NULL, @UserID, 0, @UserMsg
    END

    IF @ProzessCode = 201 AND @FallUserID != @UserID AND NOT EXISTS(
      SELECT FaLeistungID FROM dbo.FaLeistung WITH(READUNCOMMITTED)
      WHERE FaFallID = @FaFallID
        AND FaProzessCode = 200
        AND DatumBis IS NULL
    )
    BEGIN
      -- bei FA soll der neue User der wichtige sein,
      -- nur wenn kein F existiert
      UPDATE dbo.FaFall SET UserID = @UserID WHERE FaFallID = @FaFallID
      -- Protokoll
      SET @UserMsg = 'Falllverantwortlicher geändert (' +
        CONVERT(varchar(20), IsNull(@FallUserLogon,0)) + '->' +
        CONVERT(varchar(20), IsNull(@UserLogon,0)) + ')'
      EXEC dbo.spFaJournal_Insert @FaFallID, NULL, NULL, @UserID, 0, @UserMsg
    END
  END


  -- Alles ok
  SELECT Error = ''
  RETURN 1
END
