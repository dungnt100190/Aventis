SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBFSALBVZahlungen;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnBFSALBVZahlungen
(
  @BFSDossierID INT,
  @DatumVon DATETIME = NULL,
  @DatumBis DATETIME = NULL
)
RETURNS @Zahlung TABLE 
(
  KontoNr VARCHAR(10),
  Datum DATETIME,
  Betrag MONEY,
  BaPersonID INT
)
AS 
BEGIN
  INSERT INTO @Zahlung
    SELECT BKA.KontoNr, 
           BUC2.BelegDatum, 
           BUK.Betrag, 
           BUK.BaPersonID
    FROM dbo.BFSDossier                 DOS
      INNER JOIN dbo.FaLeistung         LEI  ON LEI.FaLeistungID = DOS.FaLeistungID   -- Leistung des Schuldners
      INNER JOIN dbo.FaLeistung         LEI2 ON LEI2.BaPersonID = LEI.BaPersonID      -- Alle ALBV-Leistungen dieses Schuldners
                                            AND LEI2.FaProzessCode = 405              -- ALBV
      INNER JOIN dbo.KbBuchung          BUC  ON BUC.FaLeistungID = LEI2.FaLeistungID
      INNER JOIN dbo.KbBuchungKostenart BUK  ON BUK.KbBuchungId = BUC.KbBuchungId 
                                            AND BUK.KontoNr IN (610, 612)
      INNER JOIN dbo.BgKostenart        BKA  ON BKA.BgKostenartID = BUK.BgKostenartId 
      INNER JOIN dbo.KbOpAusgleich      AUS  ON AUS.OpBuchungId = BUC.KbBuchungId 
      INNER JOIN dbo.KbBuchung          BUC2 ON BUC2.KbBuchungId = AUS.AusgleichBuchungId 
                                            AND BUC2.BelegDatum BETWEEN ISNULL(@DatumVon, DOS.DatumVon) AND ISNULL(@DatumBis, DOS.DatumBis) 
                                            AND BUC2.BelegDatum BETWEEN DOS.DatumVon AND DOS.DatumBis
    WHERE DOS.BFSDossierID = @BFSDossierID
  
  RETURN;
END;
GO