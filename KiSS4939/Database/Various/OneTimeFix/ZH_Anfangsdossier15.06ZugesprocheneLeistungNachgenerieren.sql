-- =============================================
-- Script Template
-- =============================================
--BEGIN TRAN
--ROLLBACK
--COMMIT

DECLARE @BFSFrageIDZugespLeist INT
SELECT 
  @BFSFrageIDZugespLeist = BFSFrageID 
FROM BFSFrage WHERE Variable = '15.052'
/*
SELECT *
FROM BFSDossier DOS
  INNER JOIN BFSWert WRT ON WRT.BFSDossierID = DOS.BFSDossierID
WHERE Jahr = 2011
  AND Stichtag = 0
  AND WRT.BFSFrageID = @BFSFrageIDZugespLeist
*/
INSERT INTO BFSWert (BFSDossierID, BFSDossierPersonID, BFSFrageID, Wert)
SELECT 
  DOS.BFSDossierID,
  DOP.BFSDossierPersonID,
  BFSFrageID = @BFSFrageIDZugespLeist,
  Wert = (SELECT 
                           SUM(Betrag) 
                           FROM dbo.fnBFSGetMonatlicheZahlung(DOP.BaPersonID, 
                                                              DOS.BFSLeistungsartCode, NULL, Jahr, MONTH(DOS.DatumBis), 
                                                              0, DatumVon, DatumBis))
FROM BFSDossier DOS
  INNER JOIN BFSDossierPerson DOP ON DOP.BFSDossierID = DOS.BFSDossierID AND BFSPersonCode = 1
WHERE Jahr = 2011
  AND Stichtag = 0
  AND NOT EXISTS (SELECT 1 FROM BFSWert WHERE BFSDossierID = DOS.BFSDossierID AND BFSFrageID = @BFSFrageIDZugespLeist)
  
