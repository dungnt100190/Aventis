SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAmAnspruchsberechnung_UpdateConfigAll
GO
/*===============================================================================================
  $Revision: 5$
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
-- Author:		sozheo
-- Create date: 07.10.2007
-- Description:	Updaten der Tabelle AbAmPosition aus der Konfiguration
-- wird in CtlAmAbAnspruchsberechnung verwendet
-- ===================================================================================================
-- History:
-- 07.10.2007 : sozheo : neu erstellt
-- 04.11.2007 : sozheo : Anpassungen für KKBB
-- 14.11.2007 : sozheo : Anpassungen für KKBB
-- 20.11.2007 : sozheo : Anpassungen für Zusammmenzug ALBV und UeBH
-- 26.11.2007 : sozheo : Anpassungen für ALBV/UeBH
-- 10.01.2008 : sozheo : Feld K511 jetzt bei ALBV aus den Monatszahlen, bei UeBH immer 520.-- 
-- 29.01.2008 : sozheo : Feld K511 korrigiert
-- 13.03.2008 : sozheo : Feld H3272 korrigiert
-- 25.03.2008 : sozheo : Korrekturen ALBV: 144 -> 185, 183 -> 188, 184 -> 189
-- 31.03.2008 : sozheo : für K511 soll es bei Uebh keinen Vorschlag-Wert mehr geben
-- ===================================================================================================

CREATE PROCEDURE [dbo].[spAmAnspruchsberechnung_UpdateConfigAll]
  -- Typ: 1 = ALBV/üBH, 3 = KKBB
  @Typ INT,
  -- Schlüssel Anspruchsberechnung:
  @AnspruchsberechnungID INT,
  -- ZivilstandCode:
  @ZivilstandCode INT,
  -- Stichdatum:
  @ActualDate DATETIME
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON

  -- Fallschlüssel holen:
  DECLARE @FallId INT
  SELECT TOP 1 @FallId = LT.FaFallID FROM AmAnspruchsberechnung AB
  LEFT OUTER JOIN FaLeistung LT ON LT.FaLeistungID = AB.FaLeistungID
  WHERE AB.AmAnspruchsberechnungID = @AnspruchsberechnungID

  -- Neues Holen der Konfigurationswerte:
  DECLARE @ConfigPath varchar(200)
  SET @ConfigPath = 'System\Alimente\Anspruchsberechnung\ALBV\'
  --IF @Typ = 2 SET @ConfigPath = 'System\Alimente\Anspruchsberechnung\UeBH\'
  IF @Typ = 3 SET @ConfigPath = 'System\Alimente\Anspruchsberechnung\KKBB\'


  DECLARE @ConfigFullName varchar(200)
  DECLARE @ConfigText varchar(200)
  SET @ConfigText = 'Alleinstehend'
  IF @ZivilstandCode IN (1, 3) SET @ConfigText = 'Verheiratet'  -- verheiratet, Partnerschaft
  IF @ZivilstandCode = 4 SET @ConfigText = 'Jugend'


  IF @Typ = 1 OR @Typ = 2 BEGIN
    -- Konfigurationswerte holen: Feld 1
    SET @ConfigFullName = @ConfigPath+'PauschaleProKind'
    EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 1, @AnspruchsberechnungID, 12,
         @ConfigFullName, @ActualDate

    -- 26.11.2007 : sozheo : Wird nicht mehr vwerwendet
    --SET @ConfigFullName = @ConfigPath+'VersicherungsabzugKind'
    --EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 1, @AnspruchsberechnungID, 221, 
    --     @ConfigFullName, @ActualDate

    -- 26.11.2007 : sozheo : Wird nicht mehr vwerwendet
    --SET @ConfigFullName = @ConfigPath+'VersicherungsabzugEltern'
    --EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 1, @AnspruchsberechnungID, 222, 
    --     @ConfigFullName, @ActualDate

    SET @ConfigFullName = @ConfigPath+'EinkommenKind'
    EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 1, @AnspruchsberechnungID, 525,
         @ConfigFullName, @ActualDate

    -- Konfigurationswerte holen: Feld 2
    SET @ConfigFullName = @ConfigPath+'AHVAbzug'
    EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 2, @AnspruchsberechnungID, 40,
         @ConfigFullName, @ActualDate

    SET @ConfigFullName = @ConfigPath+'AHVAbzug'
    EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 2, @AnspruchsberechnungID, 140,
         @ConfigFullName, @ActualDate


    SET @ConfigFullName = @ConfigPath+'VermoegenFamilie'+@ConfigText
    EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 2, @AnspruchsberechnungID, 272,
         @ConfigFullName, @ActualDate

    --SET @ConfigFullName = @ConfigPath+'AnteilEinkommenVermoegen'
    --EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 2, @AnspruchsberechnungID, 275, 
    --    @ConfigFullName, @ActualDate

    --SET @ConfigFullName = @ConfigPath+'EinkommenKindFaktor'
    --EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 2, @AnspruchsberechnungID, 527, 
    --     @ConfigFullName, @ActualDate
    UPDATE AmAbPosition SET Wert2 = NULL
    WHERE AmAbPosition.AmAnspruchsberechnungID=@AnspruchsberechnungID
    AND AmAbPosition.AmAbPositionsartID = 527

    -- Konfigurationswerte holen: Feld 3
    SET @ConfigFullName = @ConfigPath+'Elterngrenze'+@ConfigText
    EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 3, @AnspruchsberechnungID, 11,
         @ConfigFullName, @ActualDate

    SET @ConfigFullName = @ConfigPath+'GrenzeAuszahlung'
    EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 3, @AnspruchsberechnungID, 305,
         @ConfigFullName, @ActualDate


    -- TODO : muss jetzt weg 304
    --SET @ConfigFullName = @ConfigPath+'maxBetrag'
    --EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 3, @AnspruchsberechnungID, 304, 
    --     @ConfigFullName, @ActualDate

    -- 20.11.2007 : muss jetzt für ALBV und UeBH verschieden genommen werden
    --SET @ConfigFullName = @ConfigPath+'maxBetrag'
    --EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 3, @AnspruchsberechnungID, 512, 
    --     @ConfigFullName, @ActualDate

    SET @ConfigFullName = @ConfigPath+'maxBetragALBV'
    UPDATE AmAbPosition SET Wert3 = (
      SELECT TOP 1 C1.ValueMoney FROM XConfig C1
      WHERE C1.KeyPath=@ConfigFullName
      AND C1.DatumVon <= @ActualDate
      ORDER BY C1.DatumVon DESC)
    WHERE AmAbPosition.AmAnspruchsberechnungID=@AnspruchsberechnungID
    AND AmAbPosition.AmAbPositionsartID = 512
    AND AmAbPosition.AmAbKindID IN (
      SELECT K.AmAbKindID FROM AmAbKind K
      WHERE K.AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND K.BerechtigtCode = 1
    )

    -- K511 ist bei ALBV aus Monatszahlen, bei UeBH aus Config
    DECLARE @MaxBetragUeBH money
    SET @ConfigFullName = @ConfigPath+'maxBetragUeBH'
    SELECT TOP 1 @MaxBetragUeBH = C1.ValueMoney FROM XConfig C1
    WHERE C1.KeyPath=@ConfigFullName
    AND C1.DatumVon <= @ActualDate
    ORDER BY C1.DatumVon DESC
    IF @MaxBetragUeBH IS NULL SET @MaxBetragUeBH = 0

    UPDATE AmAbPosition SET Wert3 = @MaxBetragUeBH
    WHERE AmAbPosition.AmAnspruchsberechnungID=@AnspruchsberechnungID
    AND AmAbPosition.AmAbPositionsartID = 512
    AND AmAbPosition.AmAbKindID IN (
      SELECT K.AmAbKindID FROM AmAbKind K
      WHERE K.AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND K.BerechtigtCode = 2
    )

    -- 29.01.2008 : K511 soll aus Config genommen werden
    -- 31.03.2008 : für K511 soll es bei Uebh keinen Vorschlag-Wert mehr geben
/* 
    UPDATE AmAbPosition SET Wert1 = @MaxBetragUeBH
    WHERE AmAbPosition.AmAnspruchsberechnungID=@AnspruchsberechnungID
    AND AmAbPosition.AmAbPositionsartID = 511
    AND AmAbPosition.AmAbKindID IN (
      SELECT K.AmAbKindID FROM AmAbKind K 
      WHERE K.AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND K.BerechtigtCode = 2
    )
*/



    SET @ConfigFullName = @ConfigPath+'AbzugDoppelverdiener'
    EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 3, @AnspruchsberechnungID, 185,
         @ConfigFullName, @ActualDate

    -- 14.11.2007 : sozheo : neu
    SET @ConfigFullName = @ConfigPath+'VermoegenEltern'+@ConfigText
    EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 3, @AnspruchsberechnungID, 276,
         @ConfigFullName, @ActualDate

  END ELSE IF @Typ = 3 BEGIN

    -- ------------------
    -- KKBB
    -- ------------------

    -- bei Anzeige zusätzlich "alleinstehend" oder "verheiratet" oder "Konkubinat", ebenso bei ConfigName1
    SET @ConfigFullName = @ConfigPath+'Elterngrenze'+@ConfigText
    EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 3, @AnspruchsberechnungID, 3011,
         @ConfigFullName, @ActualDate

    SET @ConfigFullName = @ConfigPath+'PauschaleProKind'
    EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 1, @AnspruchsberechnungID, 3012,
         @ConfigFullName, @ActualDate

    SET @ConfigFullName = @ConfigPath+'MaxJahresmiete'
    EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 1, @AnspruchsberechnungID, 3014,
         @ConfigFullName, @ActualDate

    SET @ConfigFullName = @ConfigPath+'VersicherungsabzugKind'
    EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 1, @AnspruchsberechnungID, 3221,
         @ConfigFullName, @ActualDate

    SET @ConfigFullName = @ConfigPath+'VersicherungsabzugEltern'
    EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 1, @AnspruchsberechnungID, 3222,
         @ConfigFullName, @ActualDate

    -- verschieden für verheiratet, alleinstehend und Konkubinat
    SET @ConfigFullName = @ConfigPath+'VermoegenFamilie'+@ConfigText
    EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 2, @AnspruchsberechnungID, 3271,
         @ConfigFullName, @ActualDate

    SET @ConfigFullName = @ConfigPath+'AnteilEinkommenVermoegen'
    EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 2, @AnspruchsberechnungID, 3275,
         @ConfigFullName, @ActualDate

    SET @ConfigFullName = @ConfigPath+'VermoegenEltern'+@ConfigText
    EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 3, @AnspruchsberechnungID, 3276,
         @ConfigFullName, @ActualDate

    SET @ConfigFullName = @ConfigPath+'maxBetrag'
    EXEC dbo.spAmAnspruchsberechnung_UpdateConfig 1, @AnspruchsberechnungID, 3289,
         @ConfigFullName, @ActualDate

    UPDATE AmAbPosition SET Wert3 = 5000
    WHERE AmAnspruchsberechnungID = @AnspruchsberechnungID
      AND AmAbPositionsartID = 3033

  END
END

