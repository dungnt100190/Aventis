SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnWhGetBetragKontoauszug;
GO
/*===============================================================================================
  $Revision: 9 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Berechnet aus einem Betrag mit zugehöriger Verwendungsperiode den
      Teilbetrag innerhalb der Suchperiode gemäss den Regeln des SplittingArtCodes
      (z.B. tag- oder monatsgenaue Abrechnung). Die Verwendungs- und Suchperiode müssen sich
      überschneiden.
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnWhGetBetragKontoauszug
(
  @SplittingArtCode INT,
  @Betrag           MONEY,
  @PeriodeVon       DATETIME,
  @PeriodeBis       DATETIME,
  @DatSucheVon      DATETIME,
  @DatSucheBis      DATETIME
)
RETURNS MONEY
AS
BEGIN
  DECLARE @BetragReal REAL;
  DECLARE @BetragNeu MONEY;
  DECLARE @BerechnungsDatumVon DATETIME;
  DECLARE @BerechnungsDatumBis DATETIME;

  -- Die Verwendungs- und Suchperiode müssen sich überschneiden
  IF (dbo.fnDatumUeberschneidung(@PeriodeVon, @PeriodeBis, @DatSucheVon, @DatSucheBis) = 0)
  BEGIN
    SET @BetragNeu = 0.0;
    RETURN @BetragNeu;
  END;

  SELECT
    @BerechnungsDatumVon = Convert(datetime, dbo.fnMax(@PeriodeVon, @DatSucheVon)),
    @BerechnungsDatumBis = Convert(datetime, dbo.fnMin(@PeriodeBis, @DatSucheBis));

  SET @BetragReal = CAST(@Betrag AS REAL)
  SET @BetragNeu = ROUND (20.0 *
  
    CASE @SplittingArtCode
    -- Taggenau
    WHEN 1 THEN
      -- Periodengerechtes Runden für die Klientenkontoabrechnung
      -- Betrag für Periode von Verwendungsbeginn bis Berechnungsdatumende minus gerundeten Betrag für Periode von Verwendungsbegin bis Berechnungsanfang
      @BetragReal /
        (DateDiff(day, @PeriodeVon, @PeriodeBis) + 1) * (DateDiff(day, @PeriodeVon, @BerechnungsdatumBis) + 1)
      - CASE WHEN @PeriodeVon <> @BerechnungsdatumVon THEN ROUND(20 * @BetragReal / (DateDiff(day, @PeriodeVon, @PeriodeBis) + 1) *
        (DateDiff(day, @PeriodeVon, @BerechnungsDatumVon)), 0) / 20 ELSE $0.00 END
    -- Monat
    WHEN 2 THEN
      -- Periodengerechtes Runden für die Klientenkontoabrechnung
      -- Betrag für Periode von Verwendungsbeginn bis Berechnungsdatumende minus gerundeten Betrag für Periode von Verwendungsbegin bis Berechnungsanfang
      @BetragReal /
        (DateDiff(month, @PeriodeVon, @PeriodeBis) + 1) * (DateDiff(month, @PeriodeVon, @BerechnungsdatumBis) + 1)
      - CASE WHEN @PeriodeVon <> @BerechnungsdatumVon THEN ROUND(20 * @BetragReal / (DateDiff(month, @PeriodeVon, @PeriodeBis) + 1) *
        (DateDiff(month, @PeriodeVon, @BerechnungsDatumVon)), 0) / 20 ELSE $0.00 END
    -- Valuta
    WHEN 3 THEN
      CASE WHEN @PeriodeVon BETWEEN @DatSucheVon AND @DatSucheBis THEN
        @Betrag
      ELSE
        CONVERT(money, 0)
      END

    -- Entscheid
    WHEN 4 THEN
      CASE WHEN @PeriodeVon BETWEEN @DatSucheVon AND @DatSucheBis THEN
        @Betrag
      ELSE
        CONVERT(money, 0)
      END
    ELSE
      @Betrag
    END, 0) / 20.0

  RETURN @BetragNeu;

END;
GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
