SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spXNightJobs
GO
CREATE PROCEDURE [dbo].spXNightJobs
AS
BEGIN
DECLARE @ProcedureName varchar(100)
DECLARE @JobID int
DECLARE @LogException varchar(max)

Set @ProcedureName = 'KiSS Nachtjob'
Set @JobID = 0

EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'Start der Nachtjob-Verarbeitung', '', '', 0

-- ----------------------------------------------------
-- #5820: Nächtlicher Job, der die automatischen IK-Auszügen 2 Jahre und 5 Jahre nach dem ersten Finanzplan anfordert.
-- ----------------------------------------------------
SET @JobID = @JobID + 1
BEGIN TRY
	EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'EXEC dbo.spSstIKAuszugGeneriereAutomatischeAnforderungen', '', '', 0
	EXEC dbo.spSstIKAuszugGeneriereAutomatischeAnforderungen
END TRY
BEGIN CATCH
	-- Fehler-Log
    SET @LogException = ERROR_MESSAGE()
	EXEC spXLogAddEntry @ProcedureName, @JobID, 3, 'Fehler bei EXEC dbo.spSstIKAuszugGeneriereAutomatischeAnforderungen', @LogException, '', 0
END CATCH

-- ----------------------------------------------------
-- #6491: Erstellen der SoStat-Anfangszustands-Dossiers
-- ----------------------------------------------------
SET @JobID = @JobID + 1
BEGIN TRY
	EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'EXEC dbo.spBFSCheckAndCreateAnfangsdossiers', '', '', 0
	EXEC dbo.spBFSCheckAndCreateAnfangsdossiers 0	-- 0 = Erstelle direkt die Dossiers (keine Pendenzen)
END TRY
BEGIN CATCH
	-- Fehler-Log
    SET @LogException = ERROR_MESSAGE()
	EXEC spXLogAddEntry @ProcedureName, @JobID, 3, 'Fehler bei EXEC dbo.spBFSCheckAndCreateAnfangsdossiers', @LogException, '', 0
END CATCH

-- ----------------------------------------------------
-- #7729: Daten-UnitTests
-- ----------------------------------------------------
SET @JobID = @JobID + 1
BEGIN TRY
	EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'EXEC dbo.spXCheckDataConsistency', '', '', 0
	EXEC dbo.spXCheckDataConsistency
END TRY
BEGIN CATCH
	-- Fehler-Log
    SET @LogException = ERROR_MESSAGE()
	EXEC spXLogAddEntry @ProcedureName, @JobID, 3, 'Fehler bei EXEC dbo.spXCheckDataConsistency', @LogException, '', 0
END CATCH


SET @JobID = @JobID + 1
EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'Ende der Nachtjob-Verarbeitung', '', '', 0

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
