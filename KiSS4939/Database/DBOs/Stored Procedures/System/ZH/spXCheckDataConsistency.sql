SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXCheckDataConsistency;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description		
-------------------------------------------------------------------------------------------------
  SUMMARY: spXCheckDataConsistency runs UnitTests on the Data in the DB and logs all found problems.
					 This script is written so that it can be run each night from spXNightJob, but also on demand
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spXCheckDataConsistency
AS 
BEGIN
	DECLARE @ProcedureName varchar(100)
	DECLARE @JobID int
	DECLARE @LogException varchar(max)
	DECLARE @Message varchar(max)
	DECLARE @Comment varchar(max)
  DECLARE @Count int

  Set @ProcedureName = 'Daten-Konsistenz Checks'
  Set @JobID = 0

  EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'Start der Daten-Konsistenz Checks', '', '', 0

  -- ----------------------------------------------------
  -- #7729-1: Prüfen, ob es Nettobelege gibt, die zwar ausgeglichen wurden, aber deren Status kleiner als 6 ("ausgeglichen") ist
  -- ----------------------------------------------------
  SET @JobID = @JobID + 1
  BEGIN TRY

	  EXEC spXLogAddEntry @ProcedureName, @JobID, 1, '#7729-1: Prüfen, ob es Nettobelege gibt, die zwar ausgeglichen wurden, aber deren Status kleiner als 6 ("ausgeglichen") ist', '', '', 0

    SELECT @Count = COUNT(BelegNr), @Comment = dbo.Conc(BelegNr) FROM
      (SELECT DISTINCT BUC.BelegNr
              FROM KbBuchung BUC WITH (READUNCOMMITTED)
              INNER JOIN PSCDAusgleich AUG1 WITH (READUNCOMMITTED) ON AUG1.OPBEL = BUC.BelegNr AND AUG1.Verarbeitet = 1
              LEFT  JOIN PSCDAusgleich AUG2 WITH (READUNCOMMITTED) ON AUG2.OPBEL = AUG1.AUGBL AND ABS(AUG2.AUGBT) = ABS(AUG1.AUGBT) AND AUG2.Verarbeitet = 1
              WHERE BUC.KbBuchungStatusCode < 6
              GROUP BY BUC.KbBuchungID, BUC.BelegNr, BUC.Betrag
              HAVING ABS(SUM(AUG1.AUGBT) + SUM(ISNULL(AUG2.AUGBT, 0)))= ABS(BUC.Betrag)
			) TEMP
             
    IF @Count > 0 BEGIN
      SET @Message = '#7729-1: ' + CONVERT(varchar, @Count) + ' nicht ausgeglichene Nettobelege gefunden'
	    EXEC spXLogAddEntry @ProcedureName, @JobID, 2, @Message, @Comment, '', 0
    END
	END TRY
	BEGIN CATCH
		-- Fehler-Log
		SET @LogException = ERROR_MESSAGE()
		EXEC spXLogAddEntry @ProcedureName, @JobID, 3, 'Fehler bei #7729-1', @LogException, '', 0
	END CATCH 

  -- ----------------------------------------------------
  -- #7729-2: Prüfen, ob es Bruttobelege gibt, die zwar ausgeglichen wurden, aber deren Status kleiner als 6 ("ausgeglichen") ist
  -- ----------------------------------------------------
  SET @JobID = @JobID + 1
  BEGIN TRY

	  EXEC spXLogAddEntry @ProcedureName, @JobID, 1, '#7729-2: Prüfen, ob es Bruttobelege gibt, die zwar ausgeglichen wurden, aber deren Status kleiner als 6 ("ausgeglichen") ist', '', '', 0

    SELECT @Count = COUNT(BelegNr), @Comment = dbo.Conc(BelegNr) FROM
      (SELECT DISTINCT BUC.BelegNr
              FROM KbBuchungBrutto BUC WITH (READUNCOMMITTED)
              INNER JOIN PSCDAusgleich AUG1 WITH (READUNCOMMITTED) ON AUG1.OPBEL = BUC.BelegNr AND AUG1.Verarbeitet = 1
              LEFT  JOIN PSCDAusgleich AUG2 WITH (READUNCOMMITTED) ON AUG2.OPBEL = AUG1.AUGBL AND ABS(AUG2.AUGBT) = ABS(AUG1.AUGBT) AND AUG2.Verarbeitet = 1
              WHERE BUC.KbBuchungStatusCode < 6
              GROUP BY BUC.KbBuchungBruttoID, BUC.BelegNr, BUC.Betrag
              HAVING ABS(SUM(AUG1.AUGBT) + SUM(ISNULL(AUG2.AUGBT, 0)))= ABS(BUC.Betrag)
			) TEMP
             
    IF @Count > 0 BEGIN
      SET @Message = '#7729-2: ' + CONVERT(varchar, @Count) + ' nicht ausgeglichene Bruttobelege gefunden'
	    EXEC spXLogAddEntry @ProcedureName, @JobID, 2, @Message, @Comment, '', 0
    END    

	END TRY
	BEGIN CATCH
		-- Fehler-Log
		SET @LogException = ERROR_MESSAGE()
		EXEC spXLogAddEntry @ProcedureName, @JobID, 3, 'Fehler bei #7729-2', @LogException, '', 0
	END CATCH 


	-- ----------------------------------------------------
  -- #????-1: Prüfen, ob es storniert K-Belege gibt, die nicht im Status 8 (=storniert) sind
  -- ----------------------------------------------------
  SET @JobID = @JobID + 1
  BEGIN TRY

	  EXEC spXLogAddEntry @ProcedureName, @JobID, 1, '#7774-2: Prüfen, ob es storniert K-Belege gibt, die nicht im Status 8 (=storniert) sind', '', '', 0

    SELECT @Count = COUNT(KgBuchungID), @Comment = dbo.Conc(KgBuchungID) FROM
      (SELECT ORIG.KgBuchungID FROM KgBuchung ORIG
				INNER JOIN KgBuchung STO ON STO.StorniertKgBuchungID = ORIG.KgBuchungID 
				WHERE ORIG.KgBuchungStatusCode <> 8) TEMP
             
    IF @Count > 0 BEGIN
      SET @Message = '#7774-1: ' + CONVERT(varchar, @Count) + ' stornierte K-Belege mit falschem Status gefunden (Status ist nicht 8)'
	    EXEC spXLogAddEntry @ProcedureName, @JobID, 2, @Message, @Comment, '', 0
    END    

	END TRY
	BEGIN CATCH
		-- Fehler-Log
		SET @LogException = ERROR_MESSAGE()
		EXEC spXLogAddEntry @ProcedureName, @JobID, 3, 'Fehler bei #7774-2', @LogException, '', 0
	END CATCH 

	-- ----------------------------------------------------
  -- #????-2: Prüfen, ob es mehrfach stornierte K-Belege gibt
  -- ----------------------------------------------------
  SET @JobID = @JobID + 1
  BEGIN TRY

	  EXEC spXLogAddEntry @ProcedureName, @JobID, 1, '#7774-2: Prüfen, ob es mehrfach stornierte K-Belege gibt', '', '', 0

    SELECT @Count = COUNT(KgBuchungID), @Comment = dbo.Conc(KgBuchungID) FROM
      (SELECT ORIG.KgBuchungID FROM KgBuchung ORIG
				INNER JOIN KgBuchung STO ON STO.StorniertKgBuchungID = ORIG.KgBuchungID 
				GROUP BY ORIG.KgBuchungID
				HAVING Count(STO.KgBuchungID) > 1) TEMP
             
    IF @Count > 0 BEGIN
      SET @Message = '#7774-2: ' + CONVERT(varchar, @Count) + ' mehrfach stornierte K-Belege gefunden'
	    EXEC spXLogAddEntry @ProcedureName, @JobID, 2, @Message, @Comment, '', 0
    END    

	END TRY
	BEGIN CATCH
		-- Fehler-Log
		SET @LogException = ERROR_MESSAGE()
		EXEC spXLogAddEntry @ProcedureName, @JobID, 3, 'Fehler bei #7774-2', @LogException, '', 0
	END CATCH 

  -- ----------------------------------------------------
  -- #7981: Prüfen, ob es nicht richtig zurückgenommene Ausgleichsbuchungen gibt
  -- ----------------------------------------------------
  SET @JobID = @JobID + 1
  BEGIN TRY

    EXEC spXLogAddEntry @ProcedureName, @JobID, 1, '#7774-2: Prüfen, ob es nicht richtig zurückgenommene Ausgleichsbuchungen gibt', '', '', 0

    SELECT @Count = COUNT(KbBuchungID), @Comment = dbo.Conc(KbBuchungID)
    FROM KbBuchung KBU
      INNER JOIN (SELECT AusgleichbuchungID, Summe = SUM(Betrag)
                  FROM KbOpAusgleich
                  GROUP BY AusgleichbuchungID) AKT on AKT.AusgleichbuchungID = KBU.KbBuchungID
      INNER JOIN (SELECT OpBuchungID, Summe = SUM(Betrag)
                  FROM KbOpAusgleich
                  WHERE KbAusgleichGrundCode <> 15 -- Brutto-/Nettoverrechnung
                  GROUP BY OpBuchungID) STO ON STO.OpBuchungID = KBU.KbBuchungID
    WHERE STO.Summe = KBU.Betrag -- Ganzer Ausgleichsbeleg muss storniert sein
      AND AKT.Summe <> 0         -- zu einem stornierter Ausgleichsbeleg müssten negative Ausgleiche erstellt werden, welche die bestehenden Ausgleich aufheben -> Summe 0.-
             
    IF @Count > 0 BEGIN
      SET @Message = '#7981: ' + CONVERT(varchar, @Count) + ' nicht richtig zurückgenommene Ausgleichsbuchungen gefunden'
	    EXEC spXLogAddEntry @ProcedureName, @JobID, 2, @Message, @Comment, '', 0
    END    

  END TRY
  BEGIN CATCH
    -- Fehler-Log
    SET @LogException = ERROR_MESSAGE()
    EXEC spXLogAddEntry @ProcedureName, @JobID, 3, 'Fehler bei #7981', @LogException, '', 0
  END CATCH 

  -- ----------------------------------------------------
  -- End Job
  -- ----------------------------------------------------
  SET @JobID = @JobID + 1
  EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'Ende der Daten-Konsistenz Checks', '', '', 0

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
