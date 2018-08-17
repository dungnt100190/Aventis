SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spIkPosition_InsertZahlung
GO
/*===============================================================================================
  $Revision: 6 $
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

CREATE PROCEDURE dbo.spIkPosition_InsertZahlung
  -- Leistung
  @FaLeistungID INT,
  -- Rechtstitel
  @IkRechtstitelID INT,
  -- BaPersonID
  @BaPersonID INT,
  -- BetragEinmalig
  @BetragEinmalig MONEY,
  -- ProzessCode
  @ProzessCode INT,
  -- @IstZusatzBetrag
  @IstZusatzBetrag BIT,
  -- VerwPeriodeVon
  @VerwPeriodeVon DATETIME,
  -- VerwPeriodeBis
  @VerwPeriodeBis DATETIME
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON


  -- ---------------------------------------------------
  -- Kontrollen der Parameter
  -- ---------------------------------------------------
  IF (@FaLeistungID IS NULL OR @FaLeistungID = 0) BEGIN
    RAISERROR ('Der Aufruf-Parameter @LeistungID ist null.', 18, 1)
    RETURN -1
  END
  IF (@IkRechtstitelID IS NULL OR @IkRechtstitelID = 0) AND (@FaLeistungID IS NULL OR @FaLeistungID = 0) BEGIN
    RAISERROR ('Der Aufruf-Parameter @LeistungID oder @RechtstitelID ist null.', 18, 1)
    RETURN -1
  END
  IF (@BetragEinmalig IS NULL OR @BetragEinmalig = 0) BEGIN
    RAISERROR ('Der Aufruf-Parameter @BetragEinmalig ist null oeder 0.--.', 18, 1)
    RETURN -1
  END
  IF @ProzessCode NOT IN (405,406,407) BEGIN
    RAISERROR ('Der Aufruf-Parameter @ProzessCode ist ungültig.', 18, 1)
    RETURN -1
  END

  DECLARE
    @NewID INT,
    @ErrorMsg VARCHAR(200),
    @Datum DATETIME


  SELECT TOP 1 @Datum = Datum FROM dbo.fnIkZahlungslaufvaluta(GETDATE())
  IF @Datum IS NULL BEGIN
    RAISERROR ('Es konnte kein Zahlungsavaluta-Datum gefunden werden.', 18, 1)
    RETURN -1
  END


  BEGIN TRANSACTION
  BEGIN TRY
    -- Neue einmalige Zahlung erstellen lov einmalig
    -- --------------------------------
    INSERT INTO dbo.IkPosition (
      FaLeistungID, IkRechtstitelID, Einmalig, Datum, Monat, Jahr, BaPersonID,
      BetragEinmalig, IkForderungEinmaligCode, BetragIstNegativ,
      Bemerkung, VerwPeriodeVon, VerwPeriodeBis, IkBuchungsartCode
    )
    VALUES (
      @FaLeistungID, @IkRechtstitelID, 1, @Datum, MONTH(@Datum), YEAR(@Datum), @BaPersonID,
      @BetragEinmalig, CASE
        -- normale Zahlung
        WHEN @ProzessCode = 405 AND @IstZusatzBetrag = 0 THEN 151  -- ALBV, normale Zahlung
        WHEN @ProzessCode = 406 AND @IstZusatzBetrag = 0 THEN 161  -- UebH, normale Zahlung
        WHEN @ProzessCode = 407 AND @IstZusatzBetrag = 0 THEN 171  -- KKBB, normale Zahlung
        -- Zusatzzahlung
        WHEN @ProzessCode = 405 AND @IstZusatzBetrag = 1 THEN 152  -- ALBV, Zusatzzahlung
        WHEN @ProzessCode = 406 AND @IstZusatzBetrag = 1 THEN 162  -- UebH, Zusatzzahlung
        WHEN @ProzessCode = 407 AND @IstZusatzBetrag = 1 THEN 172  -- KKBB, Zusatzzahlung
        ELSE -1
      END, 1,
      NULL,
      dbo.fnFirstDayOf(@VerwPeriodeVon),
      dbo.fnLastDayOf(@VerwPeriodeBis),
      CASE WHEN @IstZusatzBetrag = 0 THEN 2 ELSE 3 END
    )
    SET @NewID = SCOPE_IDENTITY()

    -- Speichern
    -- ---------
    COMMIT TRANSACTION
  END TRY
  BEGIN CATCH

    -- Bei Fehler
    -- ----------
    ROLLBACK TRANSACTION
    SET @ErrorMsg = ERROR_MESSAGE()
    RAISERROR (@ErrorMsg, 18, 1)
    RETURN -1
  END CATCH

  RETURN 1
END

GO