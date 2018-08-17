/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to copy a group or account to recreate it with a new ID.
           GruppeKontoID is needed in spKbGetBilanzErfolg for sorting
=================================================================================================*/

BEGIN TRAN

DECLARE @KontoNr VARCHAR(50);
DECLARE @KbPeriodeID INT;
DECLARE @KbKontoID INT;
DECLARE @KbKontoID_Neu INT;

SET @KontoNr = '1015.301';
SET @KbPeriodeID = 28;

SELECT @KbKontoID = KbKontoID
FROM dbo.KbKonto
WHERE KbPeriodeID = @KbPeriodeID
  AND KontoNr = @KontoNr;
  
-- create new konto
INSERT INTO dbo.KbKonto
        (KbPeriodeID,
         GruppeKontoID,
         Kontogruppe,
         KbKontoklasseCode,
         KbKontoartCodes,
         KontoNr,
         KontoName,
         Vorsaldo,
         SaldoGruppeName,
         Saldovortrag,
         SortKey,
         KbZahlungskontoID)
SELECT KbPeriodeID,
         GruppeKontoID,
         Kontogruppe,
         KbKontoklasseCode,
         KbKontoartCodes,
         KontoNr + '.',
         KontoName,
         Vorsaldo,
         SaldoGruppeName,
         Saldovortrag,
         SortKey,
         KbZahlungskontoID
FROM KbKonto
WHERE KbKontoID = @KbKontoID

SELECT @KbKontoID_Neu = SCOPE_IDENTITY();
  
UPDATE KTO 
  SET GruppeKontoID = @KbKontoID_Neu
FROM dbo.KbKonto KTO
WHERE GruppeKontoID = @KbKontoID;

DELETE FROM dbo.KbKonto WHERE KbKontoID = @KbKontoID;

UPDATE KTO
  SET KontoNr = @KontoNr
FROM dbo.KbKonto KTO
WHERE KbKontoID = @KbKontoID_Neu;

--rollback
--commit
