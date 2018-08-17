SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAmAnspruchsberechnung_UpdateKind
GO
/*===============================================================================================
  $Revision: 4$
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
-- ===================================================================================================
-- Author:		R. Hesterberg
-- Create date: 11.07.2007
-- Description:	Updaten der Tabelle AmAbKind und AbAmPosition
-- wird in CtlAmAbAnspruchsberechnung verwendet
-- ===================================================================================================
-- History:
-- 11.07.2007 : sozheo : neu
-- 04.11.2007 : sozheo : Anpassungen für KKBB
-- 20.11.2007 : sozheo : Anpassungen für Zusammmenzug ALBV und UeBH
-- 22.11.2007 : sozheo : Anpassungen für Zusammmenzug ALBV und UeBH
-- 25.03.2008 : sozheo : neu Rechtstitel
-- 15.05.2008 : sozheo : Korrekturen für Kind mit Vormundschaft
-- ===================================================================================================

CREATE PROCEDURE [dbo].[spAmAnspruchsberechnung_UpdateKind]
  -- Schlüssel Anspruchsberechnung:
  @AnspruchsberechnungID int,
  -- ID auf BaPerson
  @BaPersonID int = 0,
  -- Dieses Kind soll zur Berechnung hinzugefügt werden:
  -- 0 = Kind soll aus Berechnung entfernt werden:
  -- 1 = Kind soll für Berechnung hinzugefügt werden:
  @AddChild bit = 0,
  -- Berechtigungscode: 1 = ALBV, 2 = UeBH, 3 = KKBB, 9 = Nein
  @BerechtigtCode int = 9,
  -- DatumBis als VARCHAR im Format yyyyMMdd
  @DatumBis DATETIME = NULL,
  -- Rechtstitel
  @IkRechtstitelID INT = NULL
AS
BEGIN
  SET NOCOUNT ON

  IF @AnspruchsberechnungID IS NULL OR @AnspruchsberechnungID = 0 BEGIN
    RAISERROR('Fehler in Parameter: Der Parameter @AnspruchsberechnungID ist zwingend.',18,1)
    RETURN -1
  END
  IF NOT @BerechtigtCode IN (0, 1, 2, 3, 9) BEGIN
    RAISERROR('Fehler in Parameter: Der Parameter @BerechtigtCode ist falsch.',18,1)
    RETURN -1
  END
  IF @BaPersonID IS NULL OR @BaPersonID = 0 BEGIN
    RAISERROR('Fehler in Parameter: Der Parameter @BaPersonID ist zwingend.',18,1)
    RETURN -1
  END

  DECLARE @KindID INT
  SET @KindID = NULL
  SELECT @KindID = AmAbKindID FROM AmAbKind
  WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
  AND BaPersonID = @BaPersonID

  IF @AddChild = 1
  BEGIN
    -- Dieses Kind soll zur Berechnung hinzugefügt werden:
    IF @KindID IS NULL BEGIN
      -- Das Kind exisitiert noch nicht, also einfügen:
      INSERT INTO AmAbKind
        (AmAnspruchsberechnungID, BaPersonID, BerechtigtCode, DatumBis, IkRechtstitelID)
      VALUES
        (@AnspruchsberechnungID, @BaPersonID, @BerechtigtCode, @DatumBis, @IkRechtstitelID)
    END ELSE BEGIN
      -- Das Kind exisitiert bereits, also nur updaten:
      UPDATE AmAbKind SET
        BerechtigtCode = @BerechtigtCode,
        DatumBis = @DatumBis,
        IkRechtstitelID = @IkRechtstitelID
      WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbKindID = @KindID
    END
  END ELSE
  BEGIN
    -- Dieses Kind soll von der Berechnung gelöscht werden:
    IF NOT @KindID IS NULL
    BEGIN
      -- Das Kind exisitiert, also muss alles gelöscht werden:
      -- Zuerst AmAbPosition löschen:
      DELETE AmAbPosition
      WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbKindID = @KindID
      -- Dann Kind löschen:
      DELETE AmAbKind
      WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbKindID = @KindID
    END
  END

END

