SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFaLeistung_ReOpenCheck
GO
/*
===================================================================================================
Author:      sozheo
Create date: 15.07.2008
Description: Checks für Wiedereröffnen einer Lesitung (nicht F oder FA)
===================================================================================================
History:
15.07.2008 : sozheo : Neu
21.08.2008 : sozheo : Korrekturen SQL Performance

===================================================================================================
*/

CREATE PROCEDURE dbo.spFaLeistung_ReOpenCheck
  -- FaLeistungID
  @FaLeistungID INT
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON

  -- Kontrolle der Parameter
  -- -----------------------
  IF @FaLeistungID IS NULL BEGIN
    --RAISERROR ('Der Aufruf-Parameter @FaLeistungID ist null!', 18, 1)
    SELECT Error = 'Der Aufruf-Parameter @FaLeistungID ist null!'
    RETURN -1
  END

  DECLARE
    @FaFallID INT,
    @ProzessCode INT,
    @LName varchar(200),
    @Fallname varchar(200),
    @DatumVon DATETIME,
    @DatumVonFall DATETIME,
    @Message varchar(500)

  SELECT
    @FaFallID = FaFallID,
    @ProzessCode = FaProzessCode,
    @LName = dbo.fnLOVText('FaProzess', FaProzessCode),
    @Fallname = CASE WHEN FaProzessCode BETWEEN 400 AND 499
      THEN 'Alimenten-Fallführung'
      ELSE 'Fallführung'
    END,
    @DatumVon = DatumVon
  FROM dbo.FaLeistung WITH(READUNCOMMITTED)
  WHERE FaLeistungID = @FaLeistungID

  IF @FaFallID IS NULL BEGIN
    --RAISERROR ('Der Fall konnte nicht gefunden werden!', 18, 1)
    SELECT Error = 'Der Fall konnte nicht gefunden werden!'
    RETURN -1
  END
  IF @ProzessCode IN (200,201) BEGIN
    --RAISERROR ('Der Aufruf dieser gespeicherten Prozedur ist nicht für Fallführungen zulässig!', 18, 1)
    SELECT Error = 'Der Aufruf dieser gespeicherten Prozedur ist nicht für Fallführungen zulässig!'
    RETURN -1
  END


  SELECT TOP 1
    @DatumVonFall = DatumVon
  FROM dbo.FaLeistung WITH(READUNCOMMITTED)
  WHERE FaFallID = @FaFallID
    AND FaProzessCode = CASE WHEN @ProzessCode BETWEEN 400 AND 499 THEN 201 ELSE 200 END
    AND DatumBis IS NULL
  ORDER BY DatumVon DESC


  -- zuerst kontrollieren, ob diese Leistung wieder eröffnet werden darf
  -- --------------------------------------------------------------------------------
  IF NOT EXISTS(
    SELECT FaLeistungID FROM dbo.FaLeistung WITH(READUNCOMMITTED)
    WHERE FaFallID = @FaFallID
      AND FaProzessCode = CASE WHEN @ProzessCode BETWEEN 400 AND 499 THEN 201 ELSE 200 END
      AND DatumBis IS NULL
  )
  BEGIN
    SET @Message =
      'Diese Leistung (' + @LName + ') kann nicht wieder eröffnet werden,' + char(13) + char(10) +
      'weil keine aktive ' + @Fallname + ' vorhanden ist.' + char(13) + char(10) +
      'Erstellen Sie zuerst eine neue oder reaktivieren Sie eine bestehende ' + @Fallname + '.'
    --RAISERROR (@Message, 18, 1)
    SELECT Error = @Message
    RETURN -1
  END


  -- Anspruchsberechnungen dürfen pro Fall nur einmal aktiv sein
  -- deshalb muss beim wiedereröffnen kontrolliert werden
  -- --------------------------------------------------------------------------------
  IF @ProzessCode IN (402,404) AND EXISTS(
    SELECT FaLeistungID FROM dbo.FaLeistung WITH(READUNCOMMITTED)
    WHERE FaFallID = @FaFallID
      AND FaProzessCode = @ProzessCode
      AND FaLeistungID !=  @FaLeistungID
      AND DatumBis IS NULL
  )
  BEGIN
    SET @Message =
      'Diese Leistung (' + @LName + ') kann nicht wieder eröffnet werden,' + char(13) + char(10) +
      'weil bereits eine andere ' + @LName + ' aktiv ist.' + char(13) + char(10) +
      'Schliessen Sie zuerst die offene ' + @LName + ' ab.'
    --RAISERROR (@Message, 18, 1)
    SELECT Error = @Message
    RETURN -1
  END

  -- Wenn die Daten inkosistent sind, kann kein Post ausgeführt werden
  -- deshalb hier die Kontrolle
  -- --------------------------------------------------------------------------------
  IF @DatumVonFall > @DatumVon
  BEGIN
    SET @Message =
      'Diese Leistung (' + @LName + ') kann nicht wieder eröffnet werden,' + char(13) + char(10) +
      'weil das Von-Datum (' + CONVERT(varchar(10), @DatumVon, 104) + ') kleiner als das Datum der ' + @Fallname + ' ist (' +
      CONVERT(varchar(10), @DatumVonFall, 104)+ ').' + char(13) + char(10) +
      'Korrigieren Sie zuerst das Datum der ' + @Fallname + '.'
    --RAISERROR (@Message, 18, 1)
    SELECT Error = @Message
    RETURN -2
  END

  -- Alles ok
  SELECT Error = NULL
  RETURN 1
END
