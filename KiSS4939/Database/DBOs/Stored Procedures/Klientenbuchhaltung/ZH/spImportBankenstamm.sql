SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spImportBankenstamm
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.spImportBankenstamm
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  --Banken löschen, die nicht mehr im Clearingstamm sind (natürlich nur, falls sie nicht verwendet werden)
  DELETE BaBank
  FROM BaBank BNK
    LEFT JOIN dbo.Import_BC_Bankenstamm BCL ON BCL.BC_Nummer = BNK.ClearingNr AND CAST(BCL.Filial_ID AS int) = BNK.FilialeNr
  WHERE BC_Nummer IS NULL AND (BNK.BaBankID NOT IN(SELECT DISTINCT BaBankID FROM BaZahlungsweg WHERE BaBankID IS NOT NULL))

-- neue Banken einfügen
INSERT INTO BaBank ([Name], Zusatz, Strasse, PLZ, Ort, ClearingNr, FilialeNr, PCKontoNr, GueltigAb, LandCode)
SELECT Bank_Institut, NULL, Domizil_Quartier, BCL.PLZ, BCL.Ort, BC_Nummer, CAST(Filial_ID AS int), Postkonto, Datum, 8100
FROM dbo.Import_BC_Bankenstamm BCL 
  LEFT JOIN BaBank             BNK ON BCL.BC_Nummer = CAST(BNK.ClearingNr AS int) AND BCL.Filial_ID = BNK.FilialeNr
WHERE ClearingNr IS NULL

-- Asterisk entfernen: '*80-2-2' -> '80-2-2'
UPDATE BaBank
SET PCKontoNr = SubString(PCKontoNr,2,len(PCKontoNr)-1)
WHERE PCKontoNr LIKE '*%'

--PCNummer in Teilnehmernummer konvertieren: '80-2-2' -> '800000022'
UPDATE BaBank
SET PCKontoNr = (
       CAST(SUBSTRING(PCKontoNr,1,CHARINDEX('-',PCKontoNr)-1) AS int) * 10000000 + 
       CAST(SUBSTRING(PCKontoNr,CHARINDEX('-',PCKontoNr) + 1, CHARINDEX('-',PCKontoNr,CHARINDEX('-',PCKontoNr)+1) - CHARINDEX('-',PCKontoNr)-1) AS int) * 10 +
       CAST(SUBSTRING(PCKontoNr,CHARINDEX('-',PCKontoNr, CHARINDEX('-',PCKontoNr)+1) + 1, len(PCKontoNr)-1) AS int))
WHERE PCKontoNr LIKE '%-%-%'

END
