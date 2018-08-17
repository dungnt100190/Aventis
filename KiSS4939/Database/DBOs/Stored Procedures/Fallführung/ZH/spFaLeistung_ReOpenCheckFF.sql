SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFaLeistung_ReOpenCheckFF
GO
/*
===================================================================================================
Author:      sozheo
Create date: 15.07.2008
Description: Kontrollen für Wiedereröffnen und einfügen eines F oder Fa
===================================================================================================
History:
15.07.2008 : sozheo : Neu
21.08.2008 : sozheo : Korrekturen SQL Performance


===================================================================================================
*/

CREATE PROCEDURE [dbo].[spFaLeistung_ReOpenCheckFF]
  -- FaFallID
  @FaFallID INT,
  -- FaLeistungID
  @FaLeistungID INT,
  -- BaBersonID
  @BaPersonID INT,
  -- FaProzessCode
  @FaProzessCode INT
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
  IF @BaPersonID IS NULL BEGIN
    --RAISERROR ('Die Person konnte nicht gefunden werden!', 18, 1)
    SELECT Error = 'Die Person konnte nicht gefunden werden!'
    RETURN -1
  END
  IF @FaProzessCode NOT IN (200,201) BEGIN
    --RAISERROR ('Der Aufruf dieser gespeicherten Prozedur ist nur für Fallführungen zulässig!', 18, 1)
    SELECT Error = 'Der Aufruf dieser gespeicherten Prozedur ist nur für Fallführungen zulässig!'
    RETURN -1
  END


  DECLARE
    @OtherFallID INT,
    @Fallname varchar(50),
    @Message varchar(500)

  SET @Fallname = CASE WHEN @FaProzessCode = 201
    THEN 'Alimenten-Fallführung'
    ELSE 'Fallführung'
  END


  -- zuerst kontrollieren, ob diese Leistung wieder eröffnet werden darf
  -- Also im aktiven Fall suchen, ob ein F/FA aktiv ist
  IF EXISTS(
    SELECT FaLeistungID FROM dbo.FaLeistung WITH(READUNCOMMITTED)
    WHERE FaFallID = @FaFallID
      AND FaLeistungID != @FaLeistungID
      AND FaProzessCode = @FaProzessCode
      AND DatumBis IS NULL
  )
  BEGIN
    SET @Message =
      'Diese ' + @Fallname + ' kann nicht wiedereröffnet werden,' + char(13) + char(10) +
      'weil bereits ein andere ' + @Fallname + ' aktiviert oder eröffnet wurde.'
    --RAISERROR (@Message, 18, 1)
    SELECT Error = @Message
    RETURN -1
  END


  -- Jetzt noch in allen Fällen suchen, ob die Person irgendwo ein aktives F/FA hat
  SELECT @OtherFallID = FaFallID FROM dbo.FaLeistung WITH(READUNCOMMITTED)
  WHERE FaFallID != @FaFallID
    AND FaLeistungID != @FaLeistungID
    AND BaPersonID = @BaPersonID
    AND FaProzessCode = @FaProzessCode
    AND DatumBis IS NULL

  IF @OtherFallID IS NOT NULL
  BEGIN
    SET @Message =
      'Diese ' + @Fallname + ' kann nicht wieder eröffnet werden,' + char(13) + char(10) +
      'weil diese Person bereits in einem anderen Fall eine ' + @Fallname + ' hat.' + char(13) + char(10) +
      'Schliessen Sie zuerst diese ' + @Fallname + ' (Fall ' + CONVERT(varchar(20), @OtherFallID) + ').'
    --RAISERROR (@Message, 18, 1)
    SELECT Error = @Message
    RETURN -1
  END

  -- Alles ok
  SELECT Error = NULL
  RETURN 1
END
