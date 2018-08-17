SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhKontoauszug
GO
/*===============================================================================================
  $Revision: 13 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST: EXEC dbo.spWhKontoauszug 64805, NULL, 1, '20120101', '20121231', NULL, 0, 0, NULL, 0, 0, 1, 1
=================================================================================================*/

CREATE PROCEDURE dbo.spWhKontoauszug
(
  @FallBaPersonID INT,
  @BaPersonIDsString VARCHAR(200),
  @KbKontoZeitraumCode INT,  -- 1 Buchungsdatum (= BelegDatum), 3 Verwendungsperiode
  @DatumVon DATETIME,
  @DatumBis DATETIME,
  @LAList VARCHAR(2000),
  @Verdichtet BIT,
  @BetraegeAnpassen BIT,
  @FaLeistungIDsString VARCHAR(200),
  @AlleKlienten BIT = 0,
  @NeueSeite BIT = 0,
  @SaldoVortragKiss BIT = 0,
  @SaldoVortragFremdsystem BIT = 0
)
AS 
BEGIN
  SELECT
    OrgName,
    OrgAdresse,
    OrgPLZOrt,
    NeueSeite,
    DruckDatum,
    Auswertungszeitraum,
    KbBuchungID,
    BelegDatum,
    ValutaDatum,
    BaPersonID,
    Klient,
    BelegNr,
    LA,
    LAText,
    Buchungstext,
    VerwPeriodeVon,
    VerwPeriodeBis,
    BgSplittingArtCode,
    Betrag,
    BetragSaldo,
    Betrag100,
    EA,
    KbBuchungStatusCode,
    Doc,
    Auszahlart,
    KreditorDebitor,
    Einnahme,
    Ausgabe,
    Saldo
  FROM dbo.fnWhKontoauszug(
    @FallBaPersonID,
    @BaPersonIDsString,
    @KbKontoZeitraumCode,
    @DatumVon,
    @DatumBis,
    @LAList,
    @Verdichtet,
    @BetraegeAnpassen,
    @FaLeistungIDsString,
    @AlleKlienten,
    @NeueSeite,
    @SaldoVortragKiss,
    @SaldoVortragFremdsystem)
    ORDER BY SortKey, BelegDatum;
END;
GO
