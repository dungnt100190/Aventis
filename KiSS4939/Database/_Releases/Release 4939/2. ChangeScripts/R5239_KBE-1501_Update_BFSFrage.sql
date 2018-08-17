/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to update BFSFrage (Change all call to fnBFSConcatDossierNr)
=================================================================================================*/


PRINT 'Tabelle BFSFrage aktualisieren'
GO

UPDATE dbo.BFSFrage
  SET HerkunftSQL = N'SELECT @value = dbo.fnBFSConcatDossierNr(PER.BaPersonID, DOS.ZustaendigeGemeinde, DOS.LaufNr, DOS.BFSLeistungsartCode, DOS.Stichtag)  FROM dbo.BFSDossier               DOS WITH (READUNCOMMITTED)     INNER JOIN dbo.BFSDossierPerson PER WITH (READUNCOMMITTED) ON PER.BFSDossierID = DOS.BFSDossierID                                                              AND PER.BFSPersonCode = 1 --1: Antragsteller  WHERE DOS.BFSDossierID = @BFSDossierID'
  WHERE BFSFrageID = (SELECT TOP 1 BFSFrageID FROM dbo.BFSFrage WHERE VariableExpandiert = '001.0000b' ORDER BY BFSKatalogVersionID DESC);
GO

PRINT 'fnBFSConcatDossierNr anrufen wurden aktualisiert'
GO
