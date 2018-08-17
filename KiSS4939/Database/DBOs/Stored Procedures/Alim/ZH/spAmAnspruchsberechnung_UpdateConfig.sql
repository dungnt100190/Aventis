SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAmAnspruchsberechnung_UpdateConfig
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
-- Create date: 29.08.2007
-- Description:	Updaten der Tabelle AbAmPosition
-- wird in CtlAmAbAnspruchsberechnung verwendet
-- History:
-- 29.08.2007 : sozheo : neu erstellt
-- ===================================================================================================

CREATE PROCEDURE [dbo].[spAmAnspruchsberechnung_UpdateConfig] 
  -- Feld Nummer 1, 2, oder 3
  @Field INT = 1,
  -- Schlüssel Anspruchsberechnung:
  @AnspruchsberechnungID INT,
  -- Schlüssel Anspruchsberechnung:
  @PositionsartID INT,
  -- Typ Berechnung, Alleinstehend / Verheiratet:
  @ConfigName VARCHAR(200),
  -- Stichdatum
  @ActualDate DATETIME = NULL
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON;

  IF @Field = 1 BEGIN 

    -- Wert1 updaten
    UPDATE AmAbPosition
    SET Wert1 = (SELECT TOP 1 C1.ValueMoney
                 FROM XConfig C1
                 WHERE C1.KeyPath = @ConfigName
                   AND C1.DatumVon <= @ActualDate
                 ORDER BY C1.DatumVon DESC)
    WHERE AmAbPosition.AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbPosition.AmAbPositionsartID = @PositionsartID

  END ELSE IF @Field = 2 BEGIN 

    -- Wert2 updaten
    UPDATE AmAbPosition
    SET Wert2 = (SELECT TOP 1 C1.ValueMoney
                 FROM XConfig C1
                 WHERE C1.KeyPath = @ConfigName
                   AND C1.DatumVon <= @ActualDate
                 ORDER BY C1.DatumVon DESC)
    WHERE AmAbPosition.AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbPosition.AmAbPositionsartID = @PositionsartID

  END ELSE BEGIN

    -- Wert3 updaten
    UPDATE AmAbPosition
    SET Wert3 = (SELECT TOP 1 C1.ValueMoney
                 FROM XConfig C1
                 WHERE C1.KeyPath = @ConfigName
                   AND C1.DatumVon <= @ActualDate
                 ORDER BY C1.DatumVon DESC)
    WHERE AmAbPosition.AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbPosition.AmAbPositionsartID = @PositionsartID

  END
END

