SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spWhPositionsart_Terminieren;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Stored Procedures/Sozialhilfe/spWhPositionsart_Terminieren.sql $
  $Author: Tabegglen $
  $Modtime: 13.09.10 7:40 $
  $Revision: 16 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this sp to check if it is possible to terminate a Positionsart per a given date 
           (because there is unmodifiable depending data like green Monatsbudgets or existing
           Spezialkontos) and to update the depending data and eventually to terminate the Positionsart.
           
  CAUTION: This stored procedure has to be executed in a transaction, as several dependent tables
           are updated!

    @BgPositionsartID:             The Positionsart to terminate
    @DatumBis:                     The date to be used to terminate
    @BgPositionsartID_Nachfolge:   The following Positionsart (optional)
                                   If there are Budget-Positionen to update, we use this Positionsart 
                                   to create the new Positionen
    @PreviewMode:                  0 (default): no Preview (validierung + migration of data)
                                   1: Preview (only validation, no migration of data)
  -
  RETURNS: VOID
  -
  EXCEPTIONS: Stored procedure raises an error (msgid: 50000, sev: 18) with different states (1-5) in case of the following errors:
            0: invalid parameters (@BgPositionsartID, @DatumBis) given.
            1: Positionsart <positionsartID> is already terminated per a different date: <the current termination date>.
            2: Green Monatsbudgets exist after the termination date. Earliest termination date would be: <earliest termination date>.
            3: Gray Monatsbudgets exist after the termination date. Earliest termination date would be: <earliest termination date>.
            4: Spezialkontos exist which are open after the termination date.
            255: Could not terminate BgPositionsart <positionsartID>. Database error occurred: <db error message>.
  -
  TEST:    wrong entries (expect error):
           
           good entries:
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Stored Procedures/Sozialhilfe/spWhPositionsart_Terminieren.sql $
 * 
 * 16    13.09.10 7:42 Tabegglen
 * Beim Checkin ist ein fehlerhaftes Zeichen reingekommen... VSS sucks!
 * 
 * 15    10.09.10 15:46 Tabegglen
 * 
 * 16    10.09.10 15:45 Tabegglen
 * #3978 Ausführliche Meldung bei existierenden Monatsbudgets soll max. 20
 * Budgets auflisten und nicht bloss max. 10
 * 
 * 15    10.09.10 10:39 Tabegglen
 * #3978 Ausführlichere Fehlermeldung wenn Monatsbudgets oder Spezkonti
 * existieren
 * 
 * 14    10.09.10 10:23 Tabegglen
 * #3978 Ausführlichere Fehlermeldung wenn Monatsbudgets oder Spezkonti
 * existieren
 * 
 * 14    10.09.10 10:23 Tabegglen
 * #3978 Ausführlichere Fehlermeldung wenn Monatsbudgets oder Spezkonti
 * existieren
 * 
 * 13    24.08.10 17:17 Lloreggia
 * Null char.
 * 
 * 12    24.08.10 17:12 Tabegglen
 * #3978 Buchungstext nur anpassen an die neue Positionsart, wenn der
 * ursprüngliche Buchungstext unverändert blieb
 * 
 * 11    24.08.10 16:46 Tabegglen
 * #3978 Buchungstext der Position soll aus der neuen Positionsart kommen
 * 
 * 10    24.08.10 11:56 Tabegglen
 * #3978 Wenn nach Monatsbudgets gesucht wird (grau oder grün), muss mit
 * Masterbudget=0 eingeschränkt werden. Sonst werden auch Masterbudgets
 * gefunden
 * 
 * 9     18.08.10 16:56 Tabegglen
 * #3978 Übersetzbare Meldungen in CtlBgPositionsart,
 * Terminierungs-StoredProcedure
 * 
 * 8     12.08.10 18:16 Rstahel
 * #3978: Terminieren von Positionen im Masterbudget in separate SP
 * ausgegliedert, so dass diese SP auch beim Erstellen eines FP verwendet
 * werden kann
 * 
 * 7     12.08.10 14:44 Tabegglen
 * #3978 Die Abkürzung, wenn die StoredProcedure auf eine bereits auf das
 * gleiche Datum terminierte Positionsart aufgerufen wird, ist unnötig
 * 
 * 6     12.08.10 14:32 Tabegglen
 * #3978 Speichern des DatumBis auf der Vorgänger-BgPositionsart nach oben
 * verschoben, so dass gewisse Aktionen in eine gemeinsame StoredProcedure
 * extrahiert werden können
 * 
 * 5     12.08.10 11:31 Tabegglen
 * #3978 StoredProcedure WhPositionsart_Terminieren hat jetzt einen
 * PreviewMode zur Validierung
 * 
 * 4     10.08.10 15:12 Tabegglen
 * #3978 Wird eine Positionsart terminiert mit Nachfolgeposition, müssen
 * die Kostenarten "geklont" werden.
 * 
 * 3     9.08.10 16:04 Tabegglen
 * #3978 Wegen Problemen mit dem Timestamp nach einem Rollback können wir
 * nicht mit SQLQuery.Post() die DB updaten.
 * 
 * 2     5.08.10 16:23 Tabegglen
 * #3978 kleinere Korrektur in spWhPositionsart_Terminieren
 * 
 * 1     5.08.10 9:43 Tabegglen
 * #3978 StoredProcedure zum Terminieren von Positionsarten hinzugefügt
=================================================================================================*/

CREATE PROCEDURE [dbo].[spWhPositionsart_Terminieren]
(
  @BgPositionsartID           INT,
  @DatumBis                   DATETIME,
  @BgPositionsartID_Nachfolge INT,
  @PreviewMode                INT = 0,    -- 0: kein Preview (Validierung + Migration der Daten)
                                          -- 1: Preview (Validierung ohne Migration der Daten)
  @LanguageCode               INT = 1     -- 1: Deutsch
)
AS
  -- ============================================================================
  -- INIT
  -- ============================================================================
  -------------------------------------------------------------------------------
  -- don't count events, it's not required!
  -------------------------------------------------------------------------------
  SET NOCOUNT ON;

  -------------------------------------------------------------------------------
  -- Vars
  -------------------------------------------------------------------------------
  -- declare vars
  DECLARE @BgBewilligungStatus_Erteilt INT;

  DECLARE @DatumBis_DB DATETIME;

  DECLARE @Month INT;
  DECLARE @Year INT;
  
  DECLARE @DatumVon DATETIME;

  DECLARE @CountBudgets INT;
  DECLARE @FirstDayBudgetMonth DATETIME;
  DECLARE @LastDayBudgetMonth DATETIME;
	DECLARE @CountOpenSpezkontos INT;
	
  DECLARE @ErrorMessage varchar(MAX);
  DECLARE @ErrorParameterDate varchar(MAX);
  DECLARE @ErrorParameterBudgets varchar(MAX);
  
  DECLARE @BgPositionID INT;
  DECLARE @BgFinanzplanID INT;
  DECLARE @MasterBgPositionID_Nachfolge INT;
  
  -- set static vars
  SET @BgBewilligungStatus_Erteilt = 5;			  -- from LOV 'BgBewilligungStatus', where Code=5 and Text='Bewilligung erteilt'
  -------------------------------------------------------------------------------
  -- Validate parameters
  -------------------------------------------------------------------------------
  IF (IsNull(@BgPositionsartID, -1) < 1 OR @DatumBis IS NULL)
  BEGIN
    -- invalid value, set error part
    SET @ErrorMessage = dbo.fnXDbObjectMLMsg('spWhPositionsart_Terminieren', 'FehlerhafteParameter', @LanguageCode);

    -- do not continue
    -- raise error with state 0: invalid parameters (@BgPositionsartID, @DatumBis) given.
    RAISERROR (@ErrorMessage, 18, 0);
    RETURN;
  END;

  -------------------------------------------------------------------------------
  -- ist die Positionsart bereits auf dieses Datum terminiert?
  -------------------------------------------------------------------------------
  SELECT @DatumBis_DB = DatumBis
  FROM dbo.BgPositionsart
  WHERE BgPositionsartID = @BgPositionsartID;

  IF (@DatumBis_DB IS NOT NULL AND @DatumBis_DB <> @DatumBis)
  BEGIN
    -- raise error with state 1: Positionsart <positionsartID> is already terminated per a different date: <the current termination date>.
		SET @ErrorParameterDate = CONVERT(varchar, @DatumBis_DB, 104);
		SET @ErrorMessage = dbo.fnXDbObjectMLMsg('spWhPositionsart_Terminieren', 'PositionsartBereitsTerminiert', @LanguageCode);
		RAISERROR (@ErrorMessage, 18, 1, @ErrorParameterDate);
		RETURN;
  END
    
  SET @Month = MONTH(@DatumBis);
  SET @Year = YEAR(@DatumBis);

  -------------------------------------------------------------------------------
  -- gibt es grüne Budgets mit Positionen mit dieser Positionsart nach <datumBis>?
  -------------------------------------------------------------------------------
  SELECT 
    @CountBudgets = Count(1), 
    @FirstDayBudgetMonth = Max(dbo.fnDateSerial(Jahr, Monat, 01)),
    @ErrorParameterBudgets = dbo.ConcDistinct(char(13) + char(10) + ' - Finanzplan ID: ' + CONVERT(VARCHAR, BgFinanzplanID)  + ' Budget Monat: ' + CONVERT(varchar, Monat) + '.' + CONVERT(varchar, Jahr))
  FROM (SELECT TOP 20
          BDG.Jahr, 
          BDG.Monat, 
          BDG.BgFinanzplanID
        FROM dbo.BgBudget BDG
          INNER JOIN dbo.BgPosition POS ON POS.BgBudgetID = BDG.BgBudgetID
        WHERE BDG.BgBewilligungStatusCode = @BgBewilligungStatus_Erteilt
          AND ((BDG.Jahr = @Year AND BDG.Monat > @Month) OR (BDG.Jahr > @Year))
          AND BDG.Masterbudget = 0
          AND POS.BgPositionsartID = @BgPositionsartID
        ORDER BY BDG.Jahr DESC, BDG.Monat DESC) TMP;

  IF (@CountBudgets > 0)
  BEGIN
    -- ja
    SET @LastDayBudgetMonth = dbo.fnLastDayOf(@FirstDayBudgetMonth);
		SET @ErrorParameterDate = CONVERT(varchar, @LastDayBudgetMonth, 104);
    SET @ErrorMessage = dbo.fnXDbObjectMLMsg('spWhPositionsart_Terminieren', 'GrueneBudgetsExistieren', @LanguageCode);
    -- raise error with state 2: Green Monatsbudgets exist after the termination date. Earliest termination date would be: <earliest termination date>
		RAISERROR (@ErrorMessage, 18, 2, @ErrorParameterDate, @ErrorParameterBudgets);
		RETURN;
  END

  -------------------------------------------------------------------------------
  -- gibt es graue Budgets mit Positionen mit dieser Positionsart nach <datumBis>? Dies ist ein Problem, wenn keine Nachfolge-Positionsart definiert ist.
  -------------------------------------------------------------------------------
	IF (@BgPositionsartID_Nachfolge IS NULL)
  BEGIN
    SELECT
      @CountBudgets = Count(1), 
      @FirstDayBudgetMonth = Max(dbo.fnDateSerial(Jahr, Monat, 01)),
      @ErrorParameterBudgets = dbo.ConcDistinct(char(13) + char(10) + ' - Finanzplan ID: ' + CONVERT(VARCHAR, BgFinanzplanID)  + ' Budget Monat: ' + CONVERT(varchar, Monat) + '.' + CONVERT(varchar, Jahr))
    FROM (SELECT TOP 20
            BDG.Jahr, 
            BDG.Monat, 
            BDG.BgFinanzplanID
          FROM dbo.BgBudget BDG
            INNER JOIN dbo.BgPosition POS ON POS.BgBudgetID = BDG.BgBudgetID
          WHERE BDG.BgBewilligungStatusCode <> @BgBewilligungStatus_Erteilt
            AND ((BDG.Jahr = @Year AND BDG.Monat > @Month) OR (BDG.Jahr > @Year))
            AND BDG.Masterbudget = 0
            AND POS.BgPositionsartID = @BgPositionsartID
            ORDER BY BDG.Jahr DESC, BDG.Monat DESC) TMP;

    IF (@CountBudgets > 0)
    BEGIN
      -- ja
      SET @LastDayBudgetMonth = dbo.fnLastDayOf(@FirstDayBudgetMonth);
		  SET @ErrorParameterDate = CONVERT(varchar, @LastDayBudgetMonth, 104);
      SET @ErrorMessage = dbo.fnXDbObjectMLMsg('spWhPositionsart_Terminieren', 'GraueBudgetsExistieren', @LanguageCode);
      
      -- raise error with state 3: Gray Monatsbudgets exist after the termination date. Earliest termination date would be: <earliest termination date>
		  RAISERROR (@ErrorMessage, 18, 3, @ErrorParameterDate, @ErrorParameterBudgets);
		  RETURN;
    END
  END

  -------------------------------------------------------------------------------
  -- Gibt es noch aktive Abzahlungskonti, welche auf die zu terminierende BgPositionsart zeigen?
  -------------------------------------------------------------------------------
  SELECT 
    @CountOpenSpezkontos = Count(1),
    @ErrorParameterBudgets = dbo.ConcDistinct(char(13) + char(10) + ' - ' + NameSpezkonto + ' (Fallträger : ' + CONVERT(varchar, BaPersonID) + ')')  
  FROM (SELECT TOP 20
          SPZ.NameSpezkonto, 
          LEI.BaPersonID
        FROM dbo.BgSpezkonto			  SPZ
          INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = SPZ.FaLeistungID
        WHERE SPZ.BgPositionsartID = @BgPositionsartID
          AND SPZ.BgSpezkontoTypCode = 3 --Abzahlungskonti
          AND SPZ.DatumBis > @DatumBis
          ORDER BY SPZ.DatumBis DESC) TMP;

  IF (@CountOpenSpezkontos > 0)
  BEGIN
		-- ja
    -- raise error with state 4: Spezialkontos exist which are open after the termination date.
    SET @ErrorMessage = dbo.fnXDbObjectMLMsg('spWhPositionsart_Terminieren', 'SpezialkontiExistieren', @LanguageCode);
		RAISERROR (@ErrorMessage, 18, 4, @ErrorParameterBudgets);
		RETURN;
  END

  -------------------------------------------------------------------------------
  -- Ende der Preview-Checks. 
  -------------------------------------------------------------------------------
  IF @PreviewMode <> 0
  BEGIN
    RETURN;
  END

  -------------------------------------------------------------------------------
  -- Daten-Konversion
  -------------------------------------------------------------------------------

  -- start try catch block
  BEGIN TRY
  
  	-------------------------------------------------------------------------------
		-- datumBis zuweisen
		-------------------------------------------------------------------------------
		UPDATE dbo.BgPositionsart
		SET DatumBis = @DatumBis
		WHERE BgPositionsartID = @BgPositionsartID;


		-------------------------------------------------------------------------------
    -- Kompetenzen klonen
		-------------------------------------------------------------------------------
		IF (@BgPositionsartID_Nachfolge IS NOT NULL)
		BEGIN	
      INSERT INTO dbo.XPermissionValue (PermissionGroupID, PermissionCode, BgPositionsartID, Value)
        SELECT PermissionGroupID, PermissionCode, @BgPositionsartID_Nachfolge, Value
        FROM dbo.XPermissionValue
        WHERE BgPositionsartID = @BgPositionsartID;
    END;
    
		-- the new DatumVon is one day after the DatumBis
		SET @DatumVon = DATEADD(DAY, 1, @DatumBis);

		---------------------------------------------------------------------------------------------------------
		-- gibt es Masterbudgets in aktiven Finanzplänen mit Positionen mit dieser Positionsart nach <datumBis>?
		---------------------------------------------------------------------------------------------------------
		-- wenn ja: Position terminieren per datumBis und mit <nachfolgeBgPositionsartID> ein Duplikat erstellen
		DECLARE curUpdateMasterbudget CURSOR FAST_FORWARD FOR
			SELECT 
				FPL.BgFinanzplanID
			FROM dbo.BgPosition						POS
				INNER JOIN dbo.BgBudget			BDG ON BDG.BgBudgetID = POS.BgBudgetID AND BDG.MasterBudget = 1
				INNER JOIN dbo.BgFinanzplan FPL ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
			WHERE POS.BgPositionsartID = @BgPositionsartID
				AND ISNULL(FPL.DatumBis, FPL.GeplantBis) > @DatumBis;

		OPEN curUpdateMasterbudget;
		WHILE 1=1
		BEGIN
			FETCH NEXT FROM curUpdateMasterbudget INTO @BgFinanzplanID;
			
			IF @@FETCH_STATUS <> 0 BREAK;

			EXEC spWhPositionsart_Masterbudget_Terminieren @BgFinanzplanID, @BgPositionsartID;
			
		END; -- [while loop cursor]

		-- close cursor
		CLOSE curUpdateMasterbudget;
		DEALLOCATE curUpdateMasterbudget;

		---------------------------------------------------------------------------------------------------------
		-- gibt es Monatsbudget mit Positionen mit der zu terminierenden Positionsart nach <datumBis>?
		-- wenn ja: Position aktualisieren mit <nachfolgeBgPositionsartID>
		---------------------------------------------------------------------------------------------------------
		IF (@BgPositionsartID_Nachfolge IS NOT NULL)
		BEGIN	
			UPDATE POS
			SET BgPositionsartID = @BgPositionsartID_Nachfolge,
					Buchungstext = CASE WHEN POS.Buchungstext = POA.Name THEN POA_Nachfolge.Name ELSE POS.Buchungstext END
			FROM dbo.BgPosition							POS
				INNER JOIN dbo.BgBudget				BDG ON BDG.BgBudgetID = POS.BgBudgetID
				INNER JOIN dbo.BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
				INNER JOIN dbo.BgPositionsart POA_Nachfolge ON POA_Nachfolge.BgPositionsartID = @BgPositionsartID_Nachfolge
			WHERE BDG.MasterBudget = 0	-- Nonatsbudgets
				AND POS.BgPositionsartID = @BgPositionsartID
				AND ((BDG.Jahr = @Year AND BDG.Monat > @Month) OR (BDG.Jahr > @Year));
				
		END
		ELSE
		BEGIN
			-- es existiert keine Nachfolge-Positionsart, existierende Positionen löschen
			DELETE POS
			FROM dbo.BgPosition				POS
				INNER JOIN dbo.BgBudget BDG ON BDG.BgBudgetID = POS.BgBudgetID
			WHERE BDG.MasterBudget = 0	-- Nonatsbudgets
				AND POS.BgPositionsartID = @BgPositionsartID
				AND ((BDG.Jahr = @Year AND BDG.Monat > @Month) OR (BDG.Jahr > @Year));
		END;

  END TRY

  BEGIN CATCH
    -- set error part
    SET @ErrorParameterDate = ERROR_MESSAGE();
		SET @ErrorMessage = dbo.fnXDbObjectMLMsg('spWhPositionsart_Terminieren', 'AllgemeinerFehler', @LanguageCode);
    -- do not continue
    RAISERROR (@ErrorMessage, 18, 255, @ErrorParameterDate);
    RETURN;
  END CATCH;

GO
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
