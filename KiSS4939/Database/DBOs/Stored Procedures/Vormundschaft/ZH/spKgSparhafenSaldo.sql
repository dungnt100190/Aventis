SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgSparhafenSaldo
GO

CREATE PROCEDURE [dbo].[spKgSparhafenSaldo](
 @KgSparhafenSaldoImportID int
)
AS

-- Finde die Person
-- Ganze Kontonummer
UPDATE KgSparhafenSaldo
SET BaPersonID = 
(
  SELECT MAX(BaPersonID)
  FROM vwSparhafenNamenAbgleich ABG
  WHERE ABG.NameVorname = SAL.NameVorname AND
    ABG.TeilKontoNr LIKE '%' + Substring(SAL.KontoNr, 1, 1) + '.' + Substring(SAL.KontoNr, 2, 3) + '.' + Substring(SAL.KontoNr, 5, 3) + '.' + Substring(SAL.KontoNr, 8, 2) + '%'
  HAVING Count(DISTINCT BaPersonID) = 1
)
FROM KgSparhafenSaldo SAL
WHERE KgSparhafenSaldoImportID = @KgSparhafenSaldoImportID AND BaPersonID IS NULL

-- Teil-Konto-Nummer
UPDATE KgSparhafenSaldo
SET BaPersonID = 
(
  SELECT MAX(BaPersonID)
  FROM vwSparhafenNamenAbgleich ABG
  WHERE ABG.NameVorname = SAL.NameVorname AND
    ABG.TeilKontoNr LIKE '%' + Substring(SAL.KontoNr, 2, 3) + '.' + Substring(SAL.KontoNr, 5, 3) + '%'
  HAVING Count(DISTINCT BaPersonID) = 1
)
FROM KgSparhafenSaldo SAL
WHERE KgSparhafenSaldoImportID = @KgSparhafenSaldoImportID AND BaPersonID IS NULL

-- Über den Namen
UPDATE KgSparhafenSaldo
SET BaPersonID = 
(
  SELECT MAX(BaPersonID)
  FROM BaPerson PER
  WHERE Per.Name LIKE Substring(SAL.NameVorname, 1, CharIndex(',', SAL.NameVorname) - 1) AND PER.Vorname LIKE Substring(SAL.NameVorname, CharIndex(',', SAL.NameVorname) + 1, Len(SAL.NameVorname) - CharIndex(',', SAL.NameVorname) + 1)
  HAVING Count(DISTINCT BaPersonID) = 1
)
FROM KgSparhafenSaldo SAL
WHERE KgSparhafenSaldoImportID = @KgSparhafenSaldoImportID AND BaPersonID IS NULL AND CharIndex(',', SAL.NameVorname) > 0

-- KontoNr
-- ganze kontennummer
UPDATE KgSparhafenSaldo
SET KissKontoNr = 
(
  SELECT KissKontoNr = MAX(KontoNr)
  FROM dbo.FaLeistung       LEI
    LEFT JOIN dbo.KgPeriode PER on PER.faleistungid = LEI.faleistungid and KSI.DatumSaldo between PER.PeriodeVon and PER.PeriodeBis
    LEFT JOIN dbo.KgKonto   KON on KON.kgperiodeid = PER.kgperiodeid and KON.KontoNr IN ('1111', '1112', '1113') AND
      KON.KontoName LIKE ('%' + Substring(SAL.KontoNr, 1, 1) + '.' +  Substring(SAL.KontoNr, 2, 3)  + '.' + Substring(SAL.KontoNr, 5, 3)  + '.' + Substring(SAL.KontoNr, 8, 2) + '%')
  WHERE LEI.BaPersonID = SAL.BaPersonID AND LEI.FaProzessCode = 500
  HAVING Count(DISTINCT KontoNr) = 1
)
FROM KgSparhafenSaldo SAL
  LEFT JOIN KgSparhafenSaldoImport KSI ON KSI.KgSparhafenSaldoImportID = SAL.KgSparhafenSaldoImportID
WHERE SAL.KgSparhafenSaldoImportID = @KgSparhafenSaldoImportID AND BaPersonID IS NOT NULL AND KissKontoNr IS NULL

-- Teilkontonummer und Kontoart
UPDATE KgSparhafenSaldo
SET KissKontoNr = 
(
  SELECT KissKontoNr = MAX(KontoNr)
  FROM dbo.FaLeistung LEI
    LEFT JOIN dbo.KgPeriode PER on PER.faleistungid = LEI.faleistungid and KSI.datumsaldo between PER.PeriodeVon and PER.PeriodeBis
    LEFT JOIN dbo.KgKonto KON on KON.kgperiodeid = PER.kgperiodeid and KON.KontoNr IN ('1111', '1112', '1113') AND
      KON.KontoName like ('%' + Substring(SAL.KontoNr, 2, 3)  + '.' + Substring(SAL.KontoNr, 5, 3)  + '.' + '%') AND
      (
        Substring(SAL.KontoNr, 1, 1) = '9' AND KON.KontoNr = '1111' OR
        Substring(SAL.KontoNr, 1, 1) = '7' AND KON.KontoNr = '1112' OR
        Substring(SAL.KontoNr, 1, 1) = '6' AND KON.KontoNr = '1113'
      )
  WHERE LEI.BaPersonID = SAL.BaPersonID AND LEI.FaProzessCode = 500
  HAVING Count(DISTINCT KontoNr) = 1
)
FROM KgSparhafenSaldo SAL
  LEFT JOIN KgSparhafenSaldoImport KSI ON KSI.KgSparhafenSaldoImportID = SAL.KgSparhafenSaldoImportID
WHERE SAL.KgSparhafenSaldoImportID = @KgSparhafenSaldoImportID AND BaPersonID IS NOT NULL AND KissKontoNr IS NULL


-- Teilkontonummer
UPDATE KgSparhafenSaldo
SET KissKontoNr = 
(
  SELECT KissKontoNr = MAX(KontoNr)
  FROM dbo.FaLeistung LEI
    LEFT JOIN dbo.KgPeriode PER on PER.faleistungid = LEI.faleistungid and KSI.datumsaldo between PER.PeriodeVon and PER.PeriodeBis
    LEFT JOIN dbo.KgKonto KON on KON.kgperiodeid = PER.kgperiodeid and KON.KontoNr IN ('1111', '1112', '1113') AND
      KON.KontoName like ('%' + Substring(SAL.KontoNr, 2, 3)  + '.' + Substring(SAL.KontoNr, 5, 3)  + '.' + '%')
  WHERE LEI.BaPersonID = SAL.BaPersonID AND LEI.FaProzessCode = 500
  HAVING Count(DISTINCT KontoNr) = 1
)
FROM KgSparhafenSaldo SAL
  LEFT JOIN KgSparhafenSaldoImport KSI ON KSI.KgSparhafenSaldoImportID = SAL.KgSparhafenSaldoImportID
WHERE SAL.KgSparhafenSaldoImportID = @KgSparhafenSaldoImportID AND BaPersonID IS NOT NULL AND KissKontoNr IS NULL




