SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBFSConcatDossierNr;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Konkateniert die übergebenen Werte nach dem BFS DossierNr Format:
           '<BaPersonID><GemeindeCode:4><Laufnummer:2><LeistungsartCode:2><Stichtag:1>'.
    @BaPersonID:       BaPersonID des BFS Dossierträgers
    @GemeindeCode:     BFSCode der zuständigen Gemeinde
    @Laufnummer:       Aufsteigende Nummer innerhalb einer Person und gleicher GemeindeCode.
    @LeistungsartCode: BFSCode der zuständigen Leistungsart
    @Stichtag:         Zum definieren ob es ein Stichtag- oder ein Anfangszustand-Dossier ist
  -
  RETURNS: Die BFS Dossier Nr des übergebenen Dossierträgers im Format: 
           '<BaPersonID><ZuständigeGemeinde:4><Laufnummer:2><LeistungsartCode:2><Stichtag:1>'. 
           Die ZuständigeGemeinde wird mit führenden Nullen auf 4 Stellen, die Laufnummer auf 
           2 Stellen formatiert, die Leistungsart auf 2 Stellen und der Stichtag auf 1. 
=================================================================================================
  TEST:    SELECT dbo.fnBFSConcatDossierNr(12345, 351, 1, 25, 1) --> 12345'0351'01'25'1;
           SELECT dbo.fnBFSConcatDossierNr(3, 2, 1, 25, 0) --> 3'0002'01'25'0;
=================================================================================================*/

CREATE FUNCTION dbo.fnBFSConcatDossierNr
(
  @BaPersonID INT,
  @GemeindeCode INT,
  @Laufnummer INT,
  @LeistungsartCode INT, 
  @Stichtag BIT
)
RETURNS BIGINT
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- Parameter überprüfen
  -----------------------------------------------------------------------------
  IF(@BaPersonID IS NULL OR @GemeindeCode IS NULL OR @Laufnummer IS NULL OR @LeistungsartCode IS NULL OR @Stichtag IS NULL)
  BEGIN
    RETURN NULL;
  END;
  
  -- Wenn Werte -1 sind, auf 0 initialisiere, so dass beim konkatenieren der Default-Wert formatiert wird
  IF(@GemeindeCode = -1)
  BEGIN
    SET @GemeindeCode = 0;
  END;

  IF(@Laufnummer = -1)
  BEGIN
    SET @Laufnummer = 0;
  END;

  -----------------------------------------------------------------------------
  -- DossierNr konkatenieren: <BaPersonID><GemeindeCode:4><Laufnummer:2><LeistungsartCode:2><Stichtag:1>
  -----------------------------------------------------------------------------
  RETURN CONVERT(BIGINT, CONVERT(VARCHAR(10), @BaPersonID) +
                         dbo.fnFormatNumber(@GemeindeCode, 0, 'z4z', '0000') + 
                         dbo.fnFormatNumber(@Laufnummer, 0, 'z2z', '00') +
                         dbo.fnFormatNumber(@LeistungsartCode, 0, 'z2z', '00') +
                         CONVERT(VARCHAR(1), @Stichtag));
END;
GO