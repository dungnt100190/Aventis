/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Periode in der Mandatsbuchhaltung wiedereröffnen / aktivieren.
=================================================================================================*/

-- TODO: BaPersonID und FbPeriodeID setzen

-- Periode wiedereröffnen
SELECT *
-- UPDATE FPR SET PeriodeStatusCode = 1
FROM FbPeriode FPR
WHERE BaPersonID = 2066
  AND FbPeriodeID IN (146)

-- Abschlussbuchung löschen
SELECT *
-- DELETE
FROM FbBuchung
WHERE FbPeriodeID IN (146)
  AND BelegNr = 'Abschluss' 

GO
