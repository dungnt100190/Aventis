SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGvGesuchAbschliessbar;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: This function handles the possible termination (Abschluss) of a Gesuch 
    @GvGesuchID: The ID of Gesuch
    @GvStatusCode: StatusCode of Gesuch
  -
  RETURNS: 1 if the Gesuch can be terminated.
=================================================================================================
  TEST:    SELECT dbo.fnGvGesuchAbschliessbar(7, 1);
=================================================================================================*/

CREATE FUNCTION dbo.fnGvGesuchAbschliessbar
(
  @GvGesuchID INT,
  @GvStatusCode INT
)
RETURNS BIT
AS 
BEGIN

  -- Das Gesuch darf nur in Status Beurteilt geschlossen werden
  IF (@GvStatusCode NOT IN (5))
  BEGIN
    RETURN 0;
  END;

  -- externe Fonds können nicht abgeschlossen werden
  IF EXISTS(SELECT TOP 1 1
            FROM dbo.GvGesuch GGE WITH (READUNCOMMITTED)
              INNER JOIN dbo.GvFonds GFD WITH (READUNCOMMITTED) ON GFD.GvFondsID = GGE.GvFondsID
                                                               AND GFD.GvFondsTypCode = 2 -- extern
            WHERE GGE.GvGesuchID = @GvGesuchID)
  BEGIN
    RETURN 0;
  END;

  -- Es darf keine Auszahlung die nicht im Status 7 (Beleg importiert) oder 9 (Gesperrt) vorhanden sein
  IF EXISTS(SELECT TOP 1 1
            FROM dbo.GvAuszahlungPosition GAP WITH(READUNCOMMITTED) 
            WHERE GAP.GvGesuchID = @GvGesuchID
              AND GAP.GvAuszahlungPositionStatusCode NOT IN (7,9)
            )
  BEGIN
    RETURN 0;
  END;

  -- Es darf kein Datensatz existieren welcher die Auflagen nicht erlassen und nicht erledigt hat
  IF EXISTS(SELECT TOP 1 1
            FROM dbo.GvAuflage GAL WITH(READUNCOMMITTED)
            WHERE GAL.GvGesuchID = @GvGesuchID
              AND GAL.Erlassen = 0
              AND GAL.Erledigt = 0
           )
  BEGIN
    RETURN 0;
  END;

  -- Bei Gesuche mit Bewilligtem Betrag > 0 muss mindestens eine Auszahlung vorhanden sein
  IF (EXISTS(SELECT TOP 1 1
             FROM dbo.GvGesuch GGE WITH (READUNCOMMITTED)
             WHERE GvGesuchID = @GvGesuchID
               AND BetragBewilligt > 0)
      AND NOT EXISTS(SELECT TOP 1 1
                     FROM dbo.GvAuszahlungPosition WITH (READUNCOMMITTED)
                     WHERE GvGesuchID = @GvGesuchID))
  BEGIN
    RETURN 0;
  END;

RETURN 1;
END;
GO