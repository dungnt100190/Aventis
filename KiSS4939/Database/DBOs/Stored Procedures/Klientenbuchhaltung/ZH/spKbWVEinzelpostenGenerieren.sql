SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKbWVEinzelpostenGenerieren
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spKbWVEinzelpostenGenerieren.sql $
  $Author: Mminder $
  $Modtime: 20.08.10 12:42 $
  $Revision: 42 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:    Use this sp to create and handle and fill WV-Einzelposten
    @UserID:         User who runs the stored procecure
    @Testlauf:       1 (default) = the data will be used only for testing,
                     0 = the data is used for real processing
    @DatumBisWVLauf: Date for the limit of Verwendungsperiode to handle
    @FilterWVCodes:  If not NULL, only the given codes as csv-values will be handles for
                     new WV entries (hint: reversal will not handle any filter!)
    @FilterBEDCodes: If not NULL, only the given codes as csv-values will be handles for
                     new BED entries (hint: reversal will not handle any filter!)
    @KbWVLaufID:     The id of the KbWVLauf where the new entries have to be attached to
  -
  RETURNS:    Entry within KbWVLauf, where any output means: everything is ok.
              Otherwise, an error has occured!
  -
  EXCEPTIONS: Stored procedure raises an error in case of bad error!
  -
  TEST:       wrong entries (expect error):
              EXEC spKbWVEinzelpostenGenerieren NULL, 1, '2008-06-30'
              EXEC spKbWVEinzelpostenGenerieren -1, 1, NULL
              
              good entries:
              EXEC spKbWVEinzelpostenGenerieren 7140, 1, '2008-06-30'
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spKbWVEinzelpostenGenerieren.sql $
 * 
 * 41    20.08.10 12:52 Mminder
 * #6348 SKZNummer/HeimatkantonNr nach einfacherer Regel bestimmen
 * 
 * 40    20.08.10 12:36 Mminder
 * #6348 SKZNummer/HeimatkantonNr nach einfacherer Regel bestimmen
 * 
 * 39    9.08.10 11:51 Mminder
 * #6486: Die Neubuchung einer Altdatenumbuchung wird nicht mehr
 * weiterverrechnet, obwohl sie storniert ist (wegen einer Umbuchung der
 * Umbuchung)
 * 
 * 38    20.07.10 8:04 Rstahel
 * #6438: Kommentar angepasst
 * 
 * 37    16.07.10 16:19 Rstahel
 * #6438: Schreibfehler
 * 
 * 36    16.07.10 16:13 Mmarghitola
 * #6438: Korrektur
 * 
 * 35    16.07.10 15:54 Mmarghitola
 * #6438: Performance-Verbesserung
 * 
 * 33    16.07.10 12:57 Rstahel
 * #6438: Peformance-Änderungen und Statusmeldungen
 * 
 * 32    1.07.10 18:52 Mminder
 * #5819: Dauer des WV-Codes wird neu vom B-WV-Code geholt statt von der
 * WV-Einheit
 * 
 * 31    26.01.10 11:40 Mminder
 * #5776: Auch HeimatkantonNr muss pro Rechnung eindeutig sein
 * 
 * 30    20.01.10 15:18 Mminder
 * #5762: Rundungsfehler bei der WV-Aufbereitung korrigiert
 * 
 * 29    15.12.09 17:20 Mminder
 * #5614: Wird ein Storno-EP abgesetzt und storniert, wird nun im nächsten
 * WV-Lauf ein neuer Storno-EP erzeugt
 * 
 * 28    11.12.09 11:58 Lloreggia
 * Header aktualisiert
 * 
 * 27    1.12.09 11:14 Mminder
 * #5098: Auch wenn ein UT keine aktuelle SKZNummer hat wird pro UT nur
 * eine SKZ-Nummer erzeugt
 * 
 * 26    26.11.09 15:15 Mminder
 * #5098: Aktuelle SKZ-Nummer auch übernehmen wenn diese NULL ist
 * 
 * 25    24.11.09 13:24 Mminder
 * #5508: Nicht abgetretene Einnahmen werden nur noch weiterverrechnet,
 * wenn der (Auszahl-)Nettobeleg auch ausgeglichen ist
 * 
 * 24    24.11.09 13:20 Mminder
 * #5098: Storno-EPs werden auch mit der aktuellen SKZ-Nummer erzeugt
 * 
 * 24    17.11.09 17:48 Mminder
 * #5098: Lookup aktuelle SKZ-Nummer korrigiert
 * 
 * 23    17.11.09 13:08 Mminder
 * #5098: Einzelposten mit Betrag 0.- werden nicht mehr erzeugt (z.B. wenn
 * eine Forderung mit 2 Rappen ausgeglichen ist)
 * 
 * 21    21.10.09 16:25 Mminder
 * #5098: Immer aktuelle SKZ-Nummer des Leistungsträgers nehmen
 * 
 * 20    15.09.09 15:34 Mminder
 * 
 * 19    27.08.09 1:25 Mminder
 * #5097: EPs werden wieder gutgeschrieben, wenn Bruttobelege doch nicht
 * weiterverrechnbar sind.
 * 
 * 18    14.05.09 21:46 Rstahel
 * Fehlermeldung optimiert
 * 
 * 17    23.04.09 0:03 Mminder
 * #4306: Korrektur der WV-Code-Gültigkeit
 * 
 * 16    21.04.09 19:53 Mminder
 * 
 * 15    21.04.09 18:37 Mminder
 * #4306: Dauer der WV-Einheit wird auf zeitlich benachbarte, gleichartige
 * WV-Einheiten verlängert
 * 
 * 14    20.04.09 10:11 Mminder
 * ##4353: Umgebuchte Ausgaben aus Proleist werden nun auch
 * weiterverrechnet
 * 
 * 13    16.04.09 21:15 Mminder
 * Buchungstext bei Storno-Einzelposten hat neu Präfix 'STO [BelegNr]'
 * 
 * 12    16.04.09 15:24 Mminder
 * Konstante @KbWVEinzelpostenStatus_Bezahlt war falsch deklariert
 * 
 * 11    16.04.09 12:59 Rstahel
 * #113: Weiterer Check eingebaut: Kostenstelle eines EP darf nicht NULL
 * sein
 * 
 * 10    13.04.09 15:47 Rstahel
 * ##4179: UnterstuetzungstraegerBaPersonID wird nun auf NULL geprüft und
 * es wird eine entsprechende Fehlermeldung generiert.
 * 
 * 9     10.03.09 17:59 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
 * 
 * 6     15.10.08 0:30 Mminder
 * 
 * 5     19.09.08 17:17 Cjaeggi
 * Remove Debug Stuff
 * 
 * 4     19.09.08 17:08 Cjaeggi
 * Debug Stuff
 * 
 * 3     19.09.08 13:54 Cjaeggi
 * Corrected comment
 * 
 * 2     17.09.08 15:29 Cjaeggi
 * Gruppierung entfernt, überarbeitet
 * 
 * 1     9.09.08 14:59 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE PROCEDURE [dbo].[spKbWVEinzelpostenGenerieren]
(
  @UserID INT,
  @Testlauf BIT = 1,
  @DatumBisWVLauf DATETIME,
  @FilterWVCodes varchar(2000) = NULL,
  @FilterBEDCodes varchar(2000) = NULL,
  @KbWVLaufID INT
)
AS BEGIN
  -- ============================================================================
  -- INIT
  -- ============================================================================
  -------------------------------------------------------------------------------
  -- don't count events, it's not required!
  -------------------------------------------------------------------------------
  SET NOCOUNT ON


  -------------------------------------------------------------------------------
  -- Vars
  -------------------------------------------------------------------------------
  -- declare vars
  DECLARE @KbBelegArt varchar(2)
  DECLARE @KbWVEinzelpostenStatus_TestLauf INT
  DECLARE @KbWVEinzelpostenStatus_Lieferbar INT
  DECLARE @KbWVEinzelpostenStatus_Bezahlt INT
  DECLARE @KbWVEinzelpostenStatus_Storniert INT
  DECLARE @KbBuchungStatusCode_ausgeglichen INT
  DECLARE @KbBuchungStatusCode_teilausgeglichen INT
  DECLARE @KbBuchungStatusCode_sent INT
  DECLARE @KbBuchungStatusCode_storniert INT

  DECLARE @ErrorMessage varchar(MAX)
  DECLARE @KbWVEinzelpostenStatusCode INT

  DECLARE @NewPscdBelegNr bigint
  DECLARE @StorniertKbWVEinzelpostenID INT
  DECLARE @NewKbWVEinzelpostenID INT

  -- set vars
  -- ...

  -- set static vars
  SET @KbBelegArt = 'WV'                          -- from LOV 'KbBelegart', where Code=9 and Text='WV'
  SET @KbWVEinzelpostenStatus_Lieferbar = 1       -- from LOV 'KbWVEinzelpostenStatus', where Code=1 and Text='Lieferbar' (default for real run)
  SET @KbWVEinzelpostenStatus_Bezahlt = 4         -- from LOV 'KbWVEinzelpostenStatus', where Code=4 and Text='Bezahlt'
  SET @KbWVEinzelpostenStatus_Storniert = 7       -- from LOV 'KbWVEinzelpostenStatus', where Code=7 and Text='Storniert'
  SET @KbWVEinzelpostenStatus_TestLauf = 100      -- from LOV 'KbWVEinzelpostenStatus', where Code=100 and Text='Testlauf' (default for test run)
  SET @KbBuchungStatusCode_ausgeglichen = 6       -- from LOV 'KbBuchungStatus', where Code=6 and Text='ausgeglichen'
  SET @KbBuchungStatusCode_teilausgeglichen = 10  -- from LOV 'KbBuchungStatus', where Code=10 and Text='teilausgeglichen'
  SET @KbBuchungStatusCode_sent = 3               -- from LOV 'KbBuchungStatus', where Code=3 and Text='ZahlauftragErstellt'
  SET @KbBuchungStatusCode_storniert = 8          -- from LOV 'KbBuchungStatus', where Code=8 and Text='storniert'

	-- Prepare Log
	DECLARE @ProcedureName varchar(50)
	DECLARE @JobID int
	DECLARE @Message varchar(max)

	SET @ProcedureName = 'spKbWVEinzelpostenGenerieren'

  -------------------------------------------------------------------------------
  -- Validate parameters
  -------------------------------------------------------------------------------
  IF (IsNull(@UserID, -1) < 1 OR @DatumBisWVLauf IS NULL OR @KbWVLaufID IS NULL)
  BEGIN
    -- invalid value, set error part
    SET @ErrorMessage = CONVERT(varchar, @DatumBisWVLauf, 104)

    -- do not continue
    RAISERROR ('Error: Invalid UserID (''%d'') and/or DatumBis (''%s'') and/or WVLaufID (''%d'') parameter, cannot continue!', 18, 1, @UserID, @ErrorMessage, @KbWVLaufID)
    RETURN
  END

  -- setup flags
  SET @Testlauf = IsNull(@Testlauf, 1) -- by default, only testing

  -- default value for statuscode
  IF (@Testlauf = 1)
  BEGIN
    -- running in test mode
    SET @KbWVEinzelpostenStatusCode = @KbWVEinzelpostenStatus_TestLauf   -- 'Testlauf'
  END
  ELSE
  BEGIN
    -- running in real mode
    SET @KbWVEinzelpostenStatusCode = @KbWVEinzelpostenStatus_Lieferbar  -- 'Lieferbar'
  END

  -- Status-Update
	SET @JobID = 1
  UPDATE WVL SET WVL.Text = 'Schritt ' + CONVERT(varchar, @JobID) + ' von 14: ' + CONVERT(varchar, GetDate(), 121) + ': Lauf gestartet...' FROM dbo.KbWVLauf WVL WHERE KbWVLaufID = @KbWVLaufID
	SET @Message = 'WV-Einzelposten-Generieren: Lauf ' + CONVERT(varchar, @KbWVLaufID) + ' gestartet (UserID=' + CONVERT(varchar, @UserID) + ', Testlauf=' + CONVERT(varchar, @Testlauf) + ', DatumBisWVLauf=' + CONVERT(varchar, @DatumBisWVLauf) + ', FilterWVCodes=' + CONVERT(varchar, @FilterWVCodes) + ', @FilterBEDCodes=' + CONVERT(varchar, @FilterBEDCodes) + ')'
	EXEC spXLogAddEntry @ProcedureName, @JobID, 1, @Message, '', 'KbWVLauf', @KbWVLaufID


  -- ============================================================================
  -- INIT FILTER HANDLING
  -- ============================================================================
  PRINT('start init filter handling: ' + CONVERT(varchar, GetDate(), 121))
  -------------------------------------------------------------------------------
  -- INFO/HINT:
  -- We apply the filter after generating the new WV-Einzelposten because it's
  --   easier this way for the moment.
  -- 
  -- For better performance, it would be possible to filter the entries while
  --   collecting all candidates within this stored procedure and also within 
  --   the calculation function. Therefore, you would have to hand over the 
  --   filter again to the function and integrate the filter there as well.
  -------------------------------------------------------------------------------
  -------------------------------------------------------------------------------
  -- create temporary containing filter codes (if any defined)
  -------------------------------------------------------------------------------
  -- table for WVCodes
  DECLARE @WVCodesToKeep TABLE
  (
    WVCode INT NOT NULL                 -- the WVCode to keep, other new entries that do not match will be removed
  )

  -- table for BEDCodes
  DECLARE @BEDCodesToKeep TABLE
  (
    BEDCode INT NOT NULL                -- the BEDCode to keep, other new entries that do not match will be removed
  )

  -------------------------------------------------------------------------------
  -- fill temporary tables with values given as parameter
  -------------------------------------------------------------------------------
  -- WVCodes
  INSERT INTO @WVCodesToKeep
    SELECT WVCode = FCN.SplitValue
    FROM dbo.fnSplitStringToValues(@FilterWVCodes, ',', 1) FCN

  -- BEDCodes
  INSERT INTO @BEDCodesToKeep
    SELECT BEDCode = FCN.SplitValue
    FROM dbo.fnSplitStringToValues(@FilterBEDCodes, ',', 1) FCN

  PRINT('done init filter handling: ' + CONVERT(varchar, GetDate(), 121))
  -- ============================================================================

  -- ============================================================================
  -- DATA CORRECTIONS (REVERSAL)
  -- ============================================================================
  PRINT('start data corrections: ' + CONVERT(varchar, GetDate(), 121))
  -------------------------------------------------------------------------------
  -- We do reversal on entries within KbWVEinzelposten depending on status of
  --   corresponding data for each current entry. As one entry can only be
  --   reversed once, we can combine the result and do reversal only once.
  -------------------------------------------------------------------------------
  -- Reversal: WhWVEinheit
  -------------------------------------------------------------------------------
  -- do reversal on KbWVEinzelposten where corresponding entry within WhWVEinheit
  --   has gone invalid (KhVWEinheit.Ungueltig = true)
  -- 
  -- info: any further changes in WhWVEinheit are not allowed and therefore
  --       not handled
  -------------------------------------------------------------------------------
  -- Reversal: KbBuchungBrutto
  -------------------------------------------------------------------------------
  -- do reversal on KbWVEinzelposten where corresponding entry within KbBuchungBrutto
  --   has reversal-flag (KbBuchungStatusCode = 8)
  -- 
  -- info: any further changes in KbBuchungBrutto are not allowed and therefore
  --       not handled
  -------------------------------------------------------------------------------

  -- Status-Update
	SET @JobID = @JobID + 1
  UPDATE WVL SET WVL.Text = 'Schritt ' + CONVERT(varchar, @JobID) + ' von 14: ' + CONVERT(varchar, GetDate(), 121) + ': Erstelle Storno-Einzelposten...' FROM dbo.KbWVLauf WVL WHERE KbWVLaufID = @KbWVLaufID
	EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'Suchen und Einfügen der Storno-Posten', '', 'KbWVLauf', @KbWVLaufID

	-----------------------------------------------------------------------------
	-- create temporary tables for collecting data and later processing
	-----------------------------------------------------------------------------
	-- init temporary table for entries that have to reversed
	DECLARE @Storno_KbWVEinzelposten TABLE
	(
	  KbWVEinzelpostenID               INT NOT NULL,
	  WVCode                           INT NOT NULL,
	  BEDCode                          INT NOT NULL,
	  UnterstuetzungstraegerBaPersonID INT NOT NULL
	)

	-- init temporary table for new reversal-entries for inserting into KbWVEinzelposten
	--   store unique KbWVEinzelpostenID that have to be reversed and get per KbWVEinzelpostenID
	--   a new PscdBelegNr if not 'Testlauf'
	DECLARE @NewStorno_KbWVEinzelposten TABLE
	(
	  StorniertKbWVEinzelpostenID      INT NOT NULL PRIMARY KEY,
	  WVCode                           INT NOT NULL,
	  BEDCode                          INT NOT NULL,
	  UnterstuetzungstraegerBaPersonID INT NOT NULL,
	  PscdBelegNr                      BIGINT
	)

	-----------------------------------------------------------------------------
	-- get all ids to do reversal  (double entries do not matter)
	--
	-- hint: only those who are non-testing entries!
	-----------------------------------------------------------------------------

	INSERT INTO @Storno_KbWVEinzelposten
	  -- get all as 'invalid' marked entries within WhWVEinheit 
	  SELECT WEP.KbWVEinzelpostenID, WEP.WVCode, WEP.BEDCode, WEP.UnterstuetzungstraegerBaPersonID
	  FROM dbo.KbWVEinzelposten            WEP WITH (READUNCOMMITTED)
		INNER JOIN dbo.KbWVLauf            WVL WITH (READUNCOMMITTED) ON WVL.KbWVLaufID = WEP.KbWVLaufID AND
																		 WVL.Testlauf = 0   -- only non-testing entries

		INNER JOIN dbo.WhWVEinheitMitglied WEM WITH (READUNCOMMITTED) ON WEM.WhWVEinheitMitgliedID = WEP.WhWVEinheitMitgliedID
		INNER JOIN dbo.WhWVEinheit         WEH WITH (READUNCOMMITTED) ON WEH.WhWVEinheitID = WEM.WhWVEinheitID AND
																		 WEH.Ungueltig = 1  -- only those who are marked as invalid by now

		LEFT  JOIN (SELECT StorniertKbWVEinzelpostenID
					FROM dbo.KbWVEinzelposten WITH (READUNCOMMITTED)
					WHERE KbWVEinzelpostenStatusCode IN (1,2,3,4,5,6)
					GROUP BY StorniertKbWVEinzelpostenID) STP         ON STP.StorniertKbWVEinzelpostenID = WEP.KbWVEinzelpostenID
	  WHERE WEP.StorniertKbWVEinzelpostenID IS NULL AND                                     -- only those who are non-reversed-entries
			STP.StorniertKbWVEinzelpostenID IS NULL AND                                     -- only those who are not marked as invalid (already processed as reversed)
			WEP.KbWVEinzelpostenStatusCode = @KbWVEinzelpostenStatus_Bezahlt                -- only invert those who are paid. others may not be paid at all and thus must not yet be inverted

	  -- add more entries
	  UNION ALL

	  -- get all reversal entries within KbBuchungBrutto (entries with GesperrtFuerWV=true will be handled the same as GesperrtFuerWV=false)
	  SELECT WEP.KbWVEinzelpostenID, WEP.WVCode, WEP.BEDCode, WEP.UnterstuetzungstraegerBaPersonID
	  FROM dbo.KbWVEinzelposten              WEP WITH (READUNCOMMITTED)
		INNER JOIN dbo.KbWVLauf              WVL WITH (READUNCOMMITTED) ON WVL.KbWVLaufID = WEP.KbWVLaufID AND
																		   WVL.Testlauf = 0                                              -- only non-testing entries
		INNER JOIN dbo.KbBuchungBruttoPerson BBP WITH (READUNCOMMITTED) ON BBP.KbBuchungBruttoPersonID = WEP.KbBuchungBruttoPersonID
		INNER JOIN dbo.KbBuchungBrutto       BBO WITH (READUNCOMMITTED) ON BBO.KbBuchungBruttoID = BBP.KbBuchungBruttoID AND
																		   (
                                                                             (
																			   BBO.KbBuchungStatusCode = @KbBuchungStatusCode_storniert AND     -- inzwischen stornierte werden wieder zurückbezahlt
                                                                               NOT (BBO.StorniertKbBuchungBruttoID IS NOT NULL OR               -- ...die Stornos aber ausschliessen, sonst werden die unendlich storniert und wieder verrechnet, da sie immer Satus 'storniert' haben
                                                                                    BBO.MigDetailBuchungID IS NOT NULL AND BBO.Belegart = 'UB') -- , ebenfalls die Stornos von Altdaten
                                                                             ) OR
                                                                             BBO.Weiterverrechenbar = 0
																		   )                                        -- LA has changed
		LEFT  JOIN (SELECT StorniertKbWVEinzelpostenID
					FROM dbo.KbWVEinzelposten WITH (READUNCOMMITTED)
					WHERE KbWVEinzelpostenStatusCode IN (1,2,3,4,5,6)
					GROUP BY StorniertKbWVEinzelpostenID) STP           ON STP.StorniertKbWVEinzelpostenID = WEP.KbWVEinzelpostenID
	  WHERE WEP.StorniertKbWVEinzelpostenID IS NULL AND                            -- only those who are non-reversed-entries
			STP.StorniertKbWVEinzelpostenID IS NULL AND                            -- only those who are not marked as invalid (already processed as reversed)
			WEP.KbWVEinzelpostenStatusCode = @KbWVEinzelpostenStatus_Bezahlt       -- only invert those who are paid. others may not be paid at all and thus must not yet be inverted

	  -- add more entries
	  UNION ALL

	  -- if the processed storno-entries have been refused by the BED, create them again
	  SELECT WEP.KbWVEinzelpostenID, WEP.WVCode, WEP.BEDCode, WEP.UnterstuetzungstraegerBaPersonID
	  FROM   dbo.KbWVEinzelposten                         WEP
		LEFT  JOIN (SELECT StorniertKbWVEinzelpostenID
					FROM dbo.KbWVEinzelposten WITH (READUNCOMMITTED)
					WHERE KbWVEinzelpostenStatusCode IN (1,2,3,4,5,6)
					GROUP BY StorniertKbWVEinzelpostenID) STP ON STP.StorniertKbWVEinzelpostenID = WEP.KbWVEinzelpostenID
	  WHERE  WEP.Ungueltig = 1 AND STP.StorniertKbWVEinzelpostenID IS NULL

	-----------------------------------------------------------------------------
	-- insert unique reversal entries into temporary table for new reversal entries
	-----------------------------------------------------------------------------
	INSERT INTO @NewStorno_KbWVEinzelposten (StorniertKbWVEinzelpostenID, WVCode, BEDCode, UnterstuetzungstraegerBaPersonID)
	  SELECT DISTINCT TMP.KbWVEinzelpostenID, WVCode, BEDCode, UnterstuetzungstraegerBaPersonID
	  FROM @Storno_KbWVEinzelposten TMP

	-------------------------------------------------------------------------------
	-- FILTER:
	-- remove any entries that are filtered by WVCodes or BEDCodes (if any defined)
	-------------------------------------------------------------------------------
	-- WVCodes
	IF (EXISTS(SELECT TOP 1 1 FROM @WVCodesToKeep))
	BEGIN
	  -- filter is defined, remove all entries that do not match the filter criteria
	  DELETE FROM @NewStorno_KbWVEinzelposten
	  WHERE WVCode NOT IN (SELECT SUB.WVCode FROM @WVCodesToKeep SUB)
	END

	-- BEDCodes
	IF (EXISTS(SELECT TOP 1 1 FROM @BEDCodesToKeep))
	BEGIN
	  -- filter is defined, remove all entries that do not match the filter criteria
	  DELETE FROM @NewStorno_KbWVEinzelposten
	  WHERE BEDCode NOT IN (SELECT SUB.BEDCode FROM @BEDCodesToKeep SUB)
	END

  -- Status-Update
	SET @JobID = @JobID + 1
	UPDATE WVL SET WVL.Text = 'Schritt ' + CONVERT(varchar, @JobID) + ' von 14: ' + CONVERT(varchar, GetDate(), 121) + ': Speichere erstellte Storno-Einzelposten...' FROM dbo.KbWVLauf WVL WHERE KbWVLaufID = @KbWVLaufID
	EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'Speichern der erstellten Storno-Posten', '', 'KbWVLauf', @KbWVLaufID

  BEGIN TRY
    -----------------------------------------------------------------------------
    -- Now we are going to change Table Data: init new transaction
    -----------------------------------------------------------------------------
    BEGIN TRANSACTION

    -----------------------------------------------------------------------------
    -- update current entries and mark them as invalid
    --
    -- hint: if current run is 'Testlauf', we do not update these entries!
    -----------------------------------------------------------------------------
    IF (@Testlauf = 0)
    BEGIN
      UPDATE WEP
      SET WEP.Ungueltig = 1
      FROM dbo.KbWVEinzelposten WEP
      WHERE WEP.KbWVEinzelpostenID IN (SELECT TMP.StorniertKbWVEinzelpostenID
                                       FROM @NewStorno_KbWVEinzelposten TMP)
    END

    -----------------------------------------------------------------------------
    -- generate for each reversal entry a PscdBelegNr using stored procedure
    --   spKbGetBelegNr_out
    --
    -- hint: if current run is 'Testlauf', we do not handle PscdBelegNr!
    -----------------------------------------------------------------------------
    IF (@Testlauf = 0)
    BEGIN
      -- setup cursor
      DECLARE curReversalEntries CURSOR FAST_FORWARD FOR
        SELECT TMP.StorniertKbWVEinzelpostenID
        FROM @NewStorno_KbWVEinzelposten TMP

      OPEN curReversalEntries
      WHILE 1=1
      BEGIN
        FETCH NEXT FROM curReversalEntries INTO @StorniertKbWVEinzelpostenID
        IF @@FETCH_STATUS <> 0 BREAK

        -- get new PscdBelegNr from stored procedure
        SET @NewPscdBelegNr = NULL
        EXEC dbo.spKbGetBelegNr_out @KbBelegArt, @NewPscdBelegNr OUT

        -- update current entry with new PscdBelegNr
        UPDATE TMP
        SET TMP.PscdBelegNr = @NewPscdBelegNr
        FROM @NewStorno_KbWVEinzelposten TMP
        WHERE TMP.StorniertKbWVEinzelpostenID = @StorniertKbWVEinzelpostenID
      END

      -- close cursor
      CLOSE curReversalEntries
      DEALLOCATE curReversalEntries

      ---------------------------------------------------------------------------
      -- check if every reversal entry has a valid PscdBelegNr
      ---------------------------------------------------------------------------
      IF (EXISTS(SELECT TOP 1 1 FROM @NewStorno_KbWVEinzelposten WHERE IsNull(PscdBelegNr, -1) < 0))
      BEGIN
        -- invalid case, cannot continue
        RAISERROR ('Error: Not every reversal entry has a valid PscdBelegNr value, cannot continue!', 18, 1)
      END
    END --[IF (@Testlauf = 0)]

    -----------------------------------------------------------------------------
    -- insert reversal entries into KbWVEinzelposten
    --
    -- WARNING: remember to update these columns, when adding or removing some
    --          columns on KbWVEinzelposten!
    -----------------------------------------------------------------------------
    INSERT INTO dbo.KbWVEinzelposten (StorniertKbWVEinzelpostenID, KbWVLaufID, UnterstuetzungstraegerBaPersonID, WVCode, BEDCode,
                                      WhWVEinheitMitgliedID, BeguenstigterBaPersonID, KbBuchungBruttoPersonID, BgSplittingArtCode,
                                      Betrag, DatumVon, DatumBis, SplittingDurchWVLaufDatumBis, PscdBelegNr, KbWVEinzelpostenStatusCode,
                                      Ungueltig, UnterstuetzungsanzeigeDocumentID, TransferDatum, Hauptvorgang, Teilvorgang,
                                      Buchungstext, PscdFehlermeldung, WohnHeimatKanton, WVCodeVon, WVCodeBis)
      SELECT DISTINCT -- security, each entry only once!
             StorniertKbWVEinzelpostenID      = TMP.StorniertKbWVEinzelpostenID,      -- get from temporary table (same as WEP.KbWVEinzelpostenID)
             KbWVLaufID                       = @KbWVLaufID,                          -- current WV-Lauf number
             UnterstuetzungstraegerBaPersonID = WEP.UnterstuetzungstraegerBaPersonID,
             WVCode                           = WEP.WVCode,
             BEDCode                          = WEP.BEDCode,
             WhWVEinheitMitgliedID            = WEP.WhWVEinheitMitgliedID,
             BeguenstigterBaPersonID          = WEP.BeguenstigterBaPersonID,
             KbBuchungBruttoPersonID          = WEP.KbBuchungBruttoPersonID,
             BgSplittingArtCode               = WEP.BgSplittingArtCode,
             Betrag                           = -WEP.Betrag,                          -- flip sign because it's a reversal entry based on KbWVEinzelposten-entry!
             DatumVon                         = WEP.DatumVon,
             DatumBis                         = WEP.DatumBis,
             SplittingDurchWVLaufDatumBis     = WEP.SplittingDurchWVLaufDatumBis,
             PscdBelegNr                      = TMP.PscdBelegNr,                      -- get from temporary table
             KbWVEinzelpostenStatusCode       = @KbWVEinzelpostenStatusCode,          -- current status
             Ungueltig                        = 0,                                    -- entry is valid by default!
             UnterstuetzungsanzeigeDocumentID = WEP.UnterstuetzungsanzeigeDocumentID,
             TransferDatum                    = NULL,                                 -- no value, will be updated from pscd-interface
             Hauptvorgang                     = WEP.Hauptvorgang,
             Teilvorgang                      = WEP.Teilvorgang,
             Buchungstext                     = 'STO ' + IsNull(CAST(KBB.BelegNr AS varchar) + ' ','' ) + WEP.Buchungstext,
             PscdFehlermeldung                = NULL,                                 -- no value, will be updated from pscd-interface
             WohnHeimatKanton                 = WEP.WohnHeimatKanton,
             WVCodeVon                        = IsNull(WEP.WVCodeVon,WVE.DatumVon),
             WVCodeBis                        = IsNull(WEP.WVCodeBis,WVE.DatumBis)
      FROM dbo.KbWVEinzelposten WEP WITH (READUNCOMMITTED)
        INNER JOIN @NewStorno_KbWVEinzelposten TMP ON TMP.StorniertKbWVEinzelpostenID = WEP.KbWVEinzelpostenID -- connect entry that has to be reversed with its origin data
        LEFT  JOIN KbBuchungBruttoPerson       KBP ON KBP.KbBuchungBruttoPersonID     = WEP.KbBuchungBruttoPersonID
        LEFT  JOIN KbBuchungBrutto             KBB ON KBP.KbBuchungBruttoID           = KBB.KbBuchungBruttoID
        LEFT  JOIN WhWVEinheitMitglied         WVM ON WVM.WhWVEinheitMitgliedID       = WEP.WhWVEinheitMitgliedID
        LEFT  JOIN WhWVEinheit                 WVE ON WVE.WhWVEinheitID               = WVM.WhWVEinheitID

    -----------------------------------------------------------------------------
    -- everything ok, commit changes now
    -----------------------------------------------------------------------------
    COMMIT TRANSACTION
  END TRY

  BEGIN CATCH
    -- error occured, do undo reversal
    ROLLBACK TRANSACTION

    -- set error part
    SET @ErrorMessage = ERROR_MESSAGE()

    -- do not continue
    RAISERROR ('Error: Could not process reversal on table KbWVEinzelposten. Database error was: %s.', 18, 1, @ErrorMessage)
    RETURN
  END CATCH

  PRINT('done data corrections: ' + CONVERT(varchar, GetDate(), 121))
  -- ============================================================================


  -- Status-Update
	SET @JobID = @JobID + 1
  UPDATE WVL SET WVL.Text = 'Schritt ' + CONVERT(varchar, @JobID) + ' von 14: ' + CONVERT(varchar, GetDate(), 121) + ': Erstelle neue Einzelposten Step 1 von 8 ...' FROM dbo.KbWVLauf WVL WHERE KbWVLaufID = @KbWVLaufID
	EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'Erstelle neue Einzelposten Step 1 von 8', '', 'KbWVLauf', @KbWVLaufID


  -- ============================================================================
  -- CREATE NEW DATA (INSERTS ON KbWVEinzelposten)
  -- ============================================================================
  PRINT('start create new data: ' + CONVERT(varchar, GetDate(), 121))
  -------------------------------------------------------------------------------
  -- INIT:
  -- create temporary tables for collecting data and later processing
  -------------------------------------------------------------------------------
  -- collect possible WV-entries within KbBuchungBruttoPerson
  CREATE TABLE #KbBuchungBruttoPersonIDs 
  (
    KbBuchungBruttoPersonID INT NOT NULL,            -- from KbBuchungBruttoPerson.KbBuchungBruttoPersonID
    KbBuchungBruttoPersonIDForDelete INT NOT NULL,   -- from KbBuchungBruttoPerson.KbBuchungBruttoPersonID (used to have unique name for DELETE statment)
    FaFallID INT NOT NULL,                           -- from FaLeistung.FaFallID = WhWVEinheit.FaFallID
    BgSplittingArtCode INT NOT NULL,                 -- from KbBuchungBrutto.BgSplittingArtCode
    BetragEffektiv money NOT NULL,                   -- from KbBuchungBrutto.BetragEffektiv
    Buchungstext varchar(200),                       -- from KbBuchungBruttoPerson.Buchungstext
    AmountOfDaysVerwPeriode INT NOT NULL             -- calculated using KbBuchungBruttoPerson.VerwPeriodeVon/Bis
  )

  -- store entries for KbWVEinzelposten
  CREATE TABLE #NewKbWVEinzelposten 
  (
    NewKbWVEinzelpostenID INT NOT NULL IDENTITY (1, 1) PRIMARY KEY,   -- used to identify any entry
	UnterstuetzungstraegerBaPersonID INT,                             -- from WhWVEinheit.BaPersonID
	WVCode INT,                                                       -- from WhWVEinheit.WVCode
	BEDCode INT,                                                      -- from WhWVEinheit.BEDCode
	WhWVEinheitMitgliedID INT,                                        -- from WhWVEinheitMitglied.WHWVEinheitMitgliedID
	BeguenstigterBaPersonID INT,                                      -- from WhWVEinheitMitglied.BaPersonID = KbBuchungBruttoPerson.BaPersonID
	KbBuchungBruttoPersonID INT NOT NULL,                             -- from KbBuchungBruttoPerson.KbBuchungBruttoPersonID
	BgSplittingArtCode INT NOT NULL,                                  -- from KbBuchungBrutto.BgSplittingArtCode
    Betrag money,                                                     -- calculated depending on KbBuchungBruttoPerson.Betrag, WhWVEinheit.DatumVon/Bis, KbBuchungBruttoPerson.VerwPeriodeVon/Bis and KbBuchungBruttoPerson.BgSplittingArtCode
	DatumVon DATETIME,                                                -- calculated (same as Betrag)
	DatumBis DATETIME,                                                -- calculated (same as Betrag)
    SplittingDurchWVLaufDatumBis BIT,                                 -- calculated depending on @DatumBisWVLauf and given entries
    PscdBelegNr bigint,                                               -- calculated using spKbGetBelegNr_out (only non-testing-runs!)
    Hauptvorgang INT,                                                 -- from BaWVCodeLOVEx.Hauptvorgang
    Teilvorgang INT,                                                  -- from BaWVCodeLOVEx.Teilvorgang
    Buchungstext varchar(200),                                        -- from KbBuchungBruttoPerson.Buchungstext
    WohnHeimatKanton varchar(1),                                      -- from BaWVCodeLOVEx.WohnHeimatKanton
    EintragStatus varchar(2000),                                      -- status from function-call: NULL = good, otherwise an error occured - showing error!
    WVCodeVon datetime,                                               -- includes neighbours with same WV-Code, BED, FaFallID and WV-Einheitsträger
    WVCodeBis datetime,                                               -- includes neighbours with same WV-Code, BED, FaFallID and WV-Einheitsträger
    FaFallID int,
    WhWVEinheitID int
  )

  -------------------------------------------------------------------------------
  -- BgPositionIDExclude:
  -- collect entries from BgPosition that do not have to be handled
  -------------------------------------------------------------------------------
  -- Status-Update
	SET @JobID = @JobID + 1
  UPDATE WVL SET WVL.Text = 'Schritt ' + CONVERT(varchar, @JobID) + ' von 14: ' + CONVERT(varchar, GetDate(), 121) + ': Erstelle neue Einzelposten Step 2 von 8 ...' FROM dbo.KbWVLauf WVL WHERE KbWVLaufID = @KbWVLaufID
	EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'Erstelle neue Einzelposten Step 2 von 8', '', 'KbWVLauf', @KbWVLaufID

  PRINT('... create new data (BgPositionIDExclude): ' + CONVERT(varchar, GetDate(), 121))
  -------------------------------------------------------------------------------
  -- COLLECT ALL CANDIDATES:
  -- collect all possible entries within KbBuchungBruttoPerson and store ids in
  --   temporary table
  -------------------------------------------------------------------------------
  --   > only those where VerwPeriodeVon <= @DatumBisWVLauf
  --   > corresponding entry for WhWVEinheitMitglied.BaPerson (to KbBuchungBruttoPerson.BaPersonID)
  --   > corresponding entry for WhWVEinheit.FaFallID (to FaLeistung.FaFallID)
  --   > valid for WV (KbBuchungBrutto.Weiterverrechenbar = true)
  --   > valid for WV (WhWVEinheit.WVCode <> 16 AND WhWVEinheit.BEDCode <> (16031, 16032))
  --   > only those with KbBuchungBrutto.KbBuchungStatusCode = 6 ('ausgeglichen')
  -------------------------------------------------------------------------------
  -- Status-Update
	SET @JobID = @JobID + 1
  UPDATE WVL SET WVL.Text = 'Schritt ' + CONVERT(varchar, @JobID) + ' von 14: ' + CONVERT(varchar, GetDate(), 121) + ': Erstelle neue Einzelposten Step 3 von 8 ...' FROM dbo.KbWVLauf WVL WHERE KbWVLaufID = @KbWVLaufID
	EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'Erstelle neue Einzelposten Step 3 von 8', '', 'KbWVLauf', @KbWVLaufID

  PRINT('... create new data (collect all candidates): ' + CONVERT(varchar, GetDate(), 121))

  INSERT INTO #KbBuchungBruttoPersonIDs
    SELECT DISTINCT                         -- unique only!
           KbBuchungBruttoPersonID          = BBP.KbBuchungBruttoPersonID,                                             -- from KbBuchungBruttoPerson.KbBuchungBruttoPersonID
           KbBuchungBruttoPersonIDForDelete = BBP.KbBuchungBruttoPersonID,                                             -- from KbBuchungBruttoPerson.KbBuchungBruttoPersonID (used to delete entries)
           FaFallID                         = LEI.FaFallID,                                                            -- from FaLeistung.FaFallID = WhWVEinheit.FaFallID
           BgSplittingArtCode               = BBO.BgSplittingArtCode,                                                  -- from KbBuchungBrutto.BgSplittingArtCode
           BetragEffektiv                   = CASE WHEN BBO.Betrag > 0 AND
                                                        BBO.Abgetreten = 1 AND
                                                        BBO.StorniertKbBuchungBruttoID IS NULL AND
                                                        BBO.NeubuchungVonKbBuchungBruttoID IS NULL THEN CAST(CAST(BBO.BetragEffektiv AS REAL) * BBP.Betrag / BBO.Betrag AS MONEY)
                                                   ELSE BBP.Betrag
                                              END,                                                                     -- from KbBuchungBrutto and KbBuchungBruttoPerson
           Buchungstext                     = BBP.Buchungstext,                                                        -- from KbBuchungBruttoPerson.Buchungstext
           AmountOfDaysVerwPeriode          = (DateDiff(DAY, BBP.VerwPeriodeVon, BBP.VerwPeriodeBis) + 1)              -- amount of days (including border >> +1)
    FROM dbo.KbBuchungBruttoPerson BBP WITH (READUNCOMMITTED)
      INNER JOIN dbo.KbBuchungBrutto BBO WITH (READUNCOMMITTED) ON BBO.KbBuchungBruttoID = BBP.KbBuchungBruttoID AND
                                                                   BBO.ValutaDatum <= @DatumBisWVLauf AND              -- only those whose ValutaDatum is within current date limit
                                                                   BBO.StorniertKbBuchungBruttoID IS NULL AND          -- only those who are not reversed entries (that means, the original ones)
                                                                   BBO.BgSplittingArtCode IS NOT NULL AND              -- SplittingArtCode must be given
                                                                   IsNull(BBO.Weiterverrechenbar, 0) = 1 AND           -- only those who are true and therefore have to be handled
                                                                   /* BBO.KbBuchungstatusCode_Netto IS NULL AND */     -- mim: because KbBuchungBrutto does not receive Feedback from PSCD about being settled we have to rely on this field
                                                                   (
                                                                    BBO.KbBuchungStatusCode = @KbBuchungStatusCode_ausgeglichen OR                                                    -- only those who are 'ausgeglichen'
                                                                    BBO.KbBuchungStatusCode = @KbBuchungStatusCode_sent AND (BBO.Betrag < 0.00  OR                                    -- expenses
                                                                                                                             BBO.Abgetreten = 0 OR                                    -- incomes that don't come in and therefore won't ever be 'ausgegelichen'
                                                                                                                             BBO.NeubuchungVonKbBuchungBruttoID IS NOT NULL) OR       -- rebookings don't need to be 'ausgeglichen' (the job in PSCD doesn't work yet)
                                                                    BBO.KbBuchungStatusCode = @KbBuchungStatusCode_teilausgeglichen AND BBO.Betrag > 0 AND                            -- incomes that are partially paid
                                                                                                                                        BBO.StorniertKbBuchungBruttoID IS NULL AND    -- exclude rebookings
                                                                                                                                        BBO.NeubuchungVonKbBuchungBruttoID IS NULL OR -- exclude rebookings
                                                                    BBO.KbBuchungStatusCode = @KbBuchungStatusCode_storniert AND MigDetailBuchungID IS NOT NULL AND Belegart = 'UB'   -- include storno of legacy bookings (ProLeist) - aber stornierte Neubuchungen ausschliessen
                                                                   )

      INNER JOIN dbo.FaLeistung      LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = BBO.FaLeistungID                 -- required to get corresponding FaLeistung.FaFallID

    WHERE BBP.VerwPeriodeVon <= @DatumBisWVLauf AND        -- only those who are within current date limit
          BBP.GesperrtFuerWV = 0 AND                       -- only those who are marked as false and therefore valid for WV
          (
           (BBO.Betrag > 0 AND BBO.Abgetreten = 1) OR                             -- abgetretene Einnahme
           BBO.NeubuchungVonKbBuchungBruttoID IS NOT NULL OR
           (BBP.BgPositionID IS NULL AND BBO.GruppierungUmbuchung LIKE 'UA%') OR   -- Neubuchung einer Altdaten-Umbuchung einer Ausgabe (Betrag <0)
		   (BBP.BgPositionID IS NOT NULL AND NOT EXISTS (SELECT TOP 1 1 FROM dbo.KbBuchungKostenart KBK WITH (READUNCOMMITTED) -- link to KbBuchung (where we know exactly the status); for payments (betrag < 0) there must not be any KbBuchung with another status than 'ausgeglichen'
				INNER JOIN dbo.KbBuchung KBU WITH (READUNCOMMITTED) ON KBU.KbBuchungID = KBK.KbBuchungID AND
                                                             KBU.KbBuchungStatusCode <> 6  -- Look for any Netto-Buchung which is not 'ausgeglichen'
				WHERE KBK.BgPositionID = BBP.BgPositionID)
			)
          )                                                

  /*
    -- DEBUG ONLY FOR WHERE CLAUSE:
    -- AND LEI.FaFallID = 10558
    AND KbBuchungBruttoPersonID = 476830
  --*/

  /*
  -- DEBUG ONLY: Show output of temporary table
  SELECT *
  FROM #KbBuchungBruttoPersonIDs
  */

  /*
  -- DEBUG ONLY: Show those entries that will be deleted
  SELECT * FROM #KbBuchungBruttoPersonIDs
  WHERE 1 = (SELECT CASE WHEN SUM(WEP.Betrag) = -BetragEffektiv AND                                             -- total amount of 'Betrag' has to be equal to '-BetragEffektiv' then: no more money has to be handled
                              SUM((DATEDIFF(DAY, WEP.DatumVon, WEP.DatumBis) + 1)) >= AmountOfDaysVerwPeriode   -- compare if sum(valid inserted entries - DatumVon/Bis) is >= amount of given days of VerwPeriodeVon/Bis: 
                                                                                                                --   if sum is ">", this would be invalid (not handled here as error, but handled as equal!)
                                                                                                                --   if sum is "=", then this entry is fully handled and completed, no further processing required
                                                                                                                --   otherwise entry is not complete and needs further processing
                         THEN 1     -- this entry can be removed from temp-table, its completely done
                         ELSE 0     -- this entry cannot be removed, total days and money of existing valid entries do not match!
                    END
             FROM dbo.KbWVEinzelposten WEP WITH (READUNCOMMITTED)
               INNER JOIN dbo.KbWVLauf WVL WITH (READUNCOMMITTED) ON WVL.KbWVLaufID = WEP.KbWVLaufID AND
                                                                     WVL.Testlauf = 0                                               -- only non-testing entries
             WHERE WEP.KbBuchungBruttoPersonID = KbBuchungBruttoPersonIDForDelete AND                                               -- sum only entries for current KbBuchungBruttoPersonID
                   WEP.StorniertKbWVEinzelpostenID IS NULL AND                                                                      -- only those who are non-reversed-entries
                   WEP.Ungueltig = 0 AND                                                                                            -- only those who are not marked as invalid (already processed as reversed)
                   WEP.KbWVEinzelpostenStatusCode NOT IN (@KbWVEinzelpostenStatus_Storniert, @KbWVEinzelpostenStatus_TestLauf))     -- we handle statuscode 7='Storniert' and 100='Testlauf' as not existing
  */

  -------------------------------------------------------------------------------
  -- REMOVE FINISHED ONES:
  -- remove entries from temporary table that are already fully handled within
  --   KbWVEinzelposten and any further processing is not required.
  -- 
  -- to find out if an entry is already done, we have to sum up all days of all
  --   valid existing entries within KbWVEinzelposten. 
  -- if an entry does not have a matching id KbWVEinzelposten.KbBuchungBruttoPersonID, 
  --   this one is not handled yet and therefore cannot be removed from temporary table.
  -------------------------------------------------------------------------------
  -- Status-Update
	SET @JobID = @JobID + 1
  UPDATE WVL SET WVL.Text = 'Schritt ' + CONVERT(varchar, @JobID) + ' von 14: ' + CONVERT(varchar, GetDate(), 121) + ': Erstelle neue Einzelposten Step 4 von 8 ...' FROM dbo.KbWVLauf WVL WHERE KbWVLaufID = @KbWVLaufID
	EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'Erstelle neue Einzelposten Step 4 von 8', '', 'KbWVLauf', @KbWVLaufID

  PRINT('... create new data (remove finished ones): ' + CONVERT(varchar, GetDate(), 121))

  DELETE FROM #KbBuchungBruttoPersonIDs
  WHERE 1 = (SELECT CASE WHEN SUM(WEP.Betrag) = -BetragEffektiv AND                                             -- total amount of 'Betrag' has to be equal to '-BetragEffektiv' then: no more money has to be handled
--  WHERE 1 = (SELECT CASE WHEN (BetragEffektiv <  0 AND  SUM(WEP.Betrag) >= -BetragEffektiv OR
--                               BetragEffektiv >= 0 AND -SUM(WEP.Betrag) >=  BetragEffektiv) AND                  -- total amount of 'Betrag' has to be equal to '-BetragEffektiv' then: no more money has to be handled
                              SUM((DateDiff(DAY, WEP.DatumVon, WEP.DatumBis) + 1)) >= AmountOfDaysVerwPeriode   -- compare if sum(valid inserted entries - DatumVon/Bis) is >= amount of given days of VerwPeriodeVon/Bis: 
                                                                                                                --   if sum is ">", this would be invalid (not handled here as error, but handled as equal!)
                                                                                                                --   if sum is "=", then this entry is fully handled and completed, no further processing required
                                                                                                                --   otherwise entry is not complete and needs further processing
                         THEN 1     -- this entry can be removed from temp-table, its completely done
                         ELSE 0     -- this entry cannot be removed, total days and money of existing valid entries do not match!
                    END
             FROM dbo.KbWVEinzelposten WEP WITH (READUNCOMMITTED)
               INNER JOIN dbo.KbWVLauf WVL WITH (READUNCOMMITTED) ON WVL.KbWVLaufID = WEP.KbWVLaufID AND
                                                                     WVL.Testlauf = 0                                               -- only non-testing entries
             WHERE WEP.KbBuchungBruttoPersonID = KbBuchungBruttoPersonIDForDelete AND                                               -- sum only entries for current KbBuchungBruttoPersonID
                   WEP.StorniertKbWVEinzelpostenID IS NULL AND                                                                      -- only those who are non-reversed-entries
                   WEP.Ungueltig = 0 AND                                                                                            -- only those who are not marked as invalid (already processed as reversed)
                   WEP.KbWVEinzelpostenStatusCode NOT IN (@KbWVEinzelpostenStatus_Storniert, @KbWVEinzelpostenStatus_TestLauf))     -- we handle statuscode 7='Storniert' and 100='Testlauf' as not existing

  -------------------------------------------------------------------------------
  -- CREATE TEMP WVEinzelposten-ENTRIES:
  -- combine possible new entries with calculated new KbWVEinzelposten entries
  --   use a cursor because direct call won't work
  -- 
  -- the function will do all required calculation and validation for given values
  -------------------------------------------------------------------------------
  DECLARE @CountEntries INT
  SELECT @CountEntries = COUNT(1)
  FROM #KbBuchungBruttoPersonIDs

  -- Status-Update
	SET @JobID = @JobID + 1
  UPDATE WVL SET WVL.Text = 'Schritt ' + CONVERT(varchar, @JobID) + ' von 14: ' + CONVERT(varchar, GetDate(), 121) + ': Erstelle neue Einzelposten Step 5 von 8 ...' FROM dbo.KbWVLauf WVL WHERE KbWVLaufID = @KbWVLaufID
	EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'Erstelle neue Einzelposten Step 5 von 8', '', 'KbWVLauf', @KbWVLaufID

  PRINT('... create new data (create temp WVEinzelposten-entries): ' + CONVERT(varchar, GetDate(), 121) + ', COUNT() of #KbBuchungBruttoPersonIDs= ' + CONVERT(varchar, @CountEntries))

  /*
  -- DEBUG ONLY: Fake BetragEffektiv!!
  UPDATE TMP
  SET TMP.BetragEffektiv = TMP.BetragEffektiv * 2
  FROM #KbBuchungBruttoPersonIDs TMP  
  --*/

  /*
  -- DEBUG ONLY: Show output of temporary table
  SELECT *
  FROM #KbBuchungBruttoPersonIDs
  --*/

  -- setup vars
  DECLARE @InsKbBuchungBruttoPersonID INT
  DECLARE @InsFaFallID INT
  DECLARE @InsBaPersonID INT
  DECLARE @InsBgSplittingArtCode INT
  DECLARE @InsBetrag money
  DECLARE @InsVerwPeriodeVon DATETIME
  DECLARE @InsVerwPeriodeBis DATETIME
  DECLARE @InsBuchungstext varchar(200)

  -- setup cursor
  DECLARE curInsertsNewKbWhEinzelposten CURSOR FAST_FORWARD FOR
    SELECT TBP.KbBuchungBruttoPersonID,
           TBP.FaFallID,
           BBP.BaPersonID,
           CASE TBP.BgSplittingArtCode WHEN 2 THEN 1 ELSE TBP.BgSplittingArtCode END,  -- #8976: Splittingart M wird neu wie T verarbeitet-> die neu erzeugten EPs sollen Splittingart T erhalten
           -TBP.BetragEffektiv,            -- (was: -BBP.Betrag, now -TBP.BetragEffektiv) !!! flip the sign because we claim from the BED what we paid - and vice versa
           BBP.VerwPeriodeVon,
           BBP.VerwPeriodeBis,
           TBP.Buchungstext
    FROM #KbBuchungBruttoPersonIDs TBP
      INNER JOIN dbo.KbBuchungBruttoPerson BBP WITH (READUNCOMMITTED) ON BBP.KbBuchungBruttoPersonID = TBP.KbBuchungBruttoPersonID

  -- loop for each entry
  OPEN curInsertsNewKbWhEinzelposten
  WHILE 1=1
  BEGIN
    FETCH NEXT FROM curInsertsNewKbWhEinzelposten INTO @InsKbBuchungBruttoPersonID, @InsFaFallID, @InsBaPersonID,
                                                       @InsBgSplittingArtCode, @InsBetrag, @InsVerwPeriodeVon,
                                                       @InsVerwPeriodeBis, @InsBuchungstext
    IF @@FETCH_STATUS <> 0 BREAK

    -- try..catch to capture sql-errors from function!
    BEGIN TRY
      -- insert entries for current row
      INSERT INTO #NewKbWVEinzelposten (UnterstuetzungstraegerBaPersonID, WVCode, BEDCode, WhWVEinheitMitgliedID,
                                        BeguenstigterBaPersonID, KbBuchungBruttoPersonID, BgSplittingArtCode,
                                        Betrag, DatumVon, DatumBis, SplittingDurchWVLaufDatumBis, PscdBelegNr,
                                        Hauptvorgang, Teilvorgang, Buchungstext,
                                        WohnHeimatKanton, EintragStatus, WVCodeVon, WVCodeBis, FaFallID, WhWVEinheitID)
        SELECT UnterstuetzungstraegerBaPersonID  = WEH.BaPersonID,                                  -- from WhWVEinheit.BaPersonID
	           WVCode                            = WEH.WVCode,                                      -- from WhWVEinheit.WVCode
	           BEDCode                           = WEH.BEDCode,                                     -- from WhWVEinheit.BEDCode
	           WhWVEinheitMitgliedID             = FCN.WhWVEinheitMitgliedID,                       -- from WhWVEinheitMitglied.WHWVEinheitMitgliedID
	           BeguenstigterBaPersonID           = WEM.BaPersonID,                                  -- from WhWVEinheitMitglied.BaPersonID = KbBuchungBruttoPerson.BaPersonID
               KbBuchungBruttoPersonID           = @InsKbBuchungBruttoPersonID,                     -- from KbBuchungBruttoPerson.KbBuchungBruttoPersonID
	           BgSplittingArtCode                = FCN.WEPBgSplittingArtCode,                       -- from KbBuchungBrutto.BgSplittingArtCode
               Betrag                            = FCN.WEPBetrag,                                   -- calculated depending on KbBuchungBruttoPerson.Betrag, WhWVEinheit.DatumVon/Bis, KbBuchungBruttoPerson.VerwPeriodeVon/Bis and KbBuchungBruttoPerson.BgSplittingArtCode
	           DatumVon                          = FCN.WEPDatumVon,                                 -- calculated (same as Betrag)
	           DatumBis                          = FCN.WEPDatumBis,                                 -- calculated (same as Betrag)
               SplittingDurchWVLaufDatumBis      = IsNull(FCN.WEPSplittingDurchWVLaufDatumBis, 0),  -- calculated depending on @DatumBisWVLauf and given entries
               PscdBelegNr                       = NULL,                                            -- do update later
               Hauptvorgang                      = WVC.Hauptvorgang,                                -- from BaWVCodeLOVEx.Hauptvorgang
               Teilvorgang                       = WVC.Teilvorgang,                                 -- from BaWVCodeLOVEx.Teilvorgang
               Buchungstext                      = @InsBuchungstext,                                -- from KbBuchungBruttoPerson.Buchungstext
               WohnHeimatKanton                  = WVC.WohnHeimatKanton,                            -- from BaWVCodeLOVEx.WohnHeimatKanton  
               EintragStatus                     = FCN.WEPStatus,                                   -- status from function-call: NULL = good, otherwise an error occured - showing error!
               WVCodeVon                         = ISNULL(WCO.DatumVon,WEH.DatumVon),
               WVCodeBis                         = ISNULL(WCO.DatumBis,WEH.DatumBis),
               FaFallID                          = WEH.FaFallID,
               WhWVEinheitID                     = WEH.WhWVEinheitID
       FROM dbo.fnKbWVEinzelposten_WVEinheitenProBuchung(@DatumBisWVLauf,
                                                         @InsKbBuchungBruttoPersonID,
                                                         @InsFaFallID,
                                                         @InsBaPersonID,
                                                         @InsBgSplittingArtCode,
                                                         @InsBetrag,
                                                         @InsVerwPeriodeVon,
                                                         @InsVerwPeriodeBis) FCN
         LEFT JOIN dbo.WhWVEinheitMitglied WEM WITH (READUNCOMMITTED) ON WEM.WhWVEinheitMitgliedID = FCN.WhWVEinheitMitgliedID  -- left join to capture wrong entries, error will follow later on
         LEFT JOIN dbo.WhWVEinheit         WEH WITH (READUNCOMMITTED) ON WEH.WhWVEinheitID         = WEM.WhWVEinheitID          -- left join to capture wrong entries, error will follow later on
         LEFT JOIN dbo.BaWVCode            WCO WITH (READUNCOMMITTED) ON WEM.BaWVCodeID            = WCO.BaWVCodeID
         LEFT JOIN dbo.BaWVCodeLOVEx       WVC WITH (READUNCOMMITTED) ON WVC.BaWVCodeLOVExID       = WEH.WVCode

    END TRY

    BEGIN CATCH
      -- error occured (high possibly in dbo.fnKbWVEinzelposten_WVEinheitenProBuchung() call), get error message
      SET @ErrorMessage = ERROR_MESSAGE()

      -- append error
      SET @ErrorMessage = 'Error in function-call, entry is invalid! Database error was: ' + IsNull(@ErrorMessage, '<none>')

      -- insert entry with current @InsKbBuchungBruttoPersonID and error message into result
      INSERT INTO #NewKbWVEinzelposten (KbBuchungBruttoPersonID, BgSplittingArtCode, EintragStatus)
        SELECT KbBuchungBruttoPersonID           = @InsKbBuchungBruttoPersonID,                     -- from KbBuchungBruttoPerson.KbBuchungBruttoPersonID
	           BgSplittingArtCode                = -1,                                              -- cannot be NULL
               EintragStatus                     = @ErrorMessage                                    -- error-status: NULL = good, otherwise an error occured - showing error!

      -- do continue with next entry!
    END CATCH
  END -- [while loop cursor]

  -- close cursor
  CLOSE curInsertsNewKbWhEinzelposten
  DEALLOCATE curInsertsNewKbWhEinzelposten

  /*
  -- DEBUG ONLY: Show output of temporary table
  SELECT *
  FROM #NewKbWVEinzelposten
  
  --RETURN -- stop here because of debugging
  --*/

  -- Status-Update
	SET @JobID = @JobID + 1
  UPDATE WVL SET WVL.Text = 'Schritt ' + CONVERT(varchar, @JobID) + ' von 14: ' + CONVERT(varchar, GetDate(), 121) + ': Erstelle neue Einzelposten Step 6 von 8 ...' FROM dbo.KbWVLauf WVL WHERE KbWVLaufID = @KbWVLaufID
	EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'Erstelle neue Einzelposten Step 6 von 8', '', 'KbWVLauf', @KbWVLaufID

  -------------------------------------------------------------------------------
  -- FILTER:
  -- remove any entries that are filtered by WVCodes or BEDCodes (if any defined)
  -------------------------------------------------------------------------------
  -- WVCodes
  IF (EXISTS(SELECT TOP 1 1 FROM @WVCodesToKeep))
  BEGIN
    -- filter is defined, remove all entries that do not match the filter criteria
    DELETE FROM #NewKbWVEinzelposten
    WHERE WVCode NOT IN (SELECT SUB.WVCode FROM @WVCodesToKeep SUB)
  END

  -- BEDCodes
  IF (EXISTS(SELECT TOP 1 1 FROM @BEDCodesToKeep))
  BEGIN
    -- filter is defined, remove all entries that do not match the filter criteria
    DELETE FROM #NewKbWVEinzelposten
    WHERE BEDCode NOT IN (SELECT SUB.BEDCode FROM @BEDCodesToKeep SUB)
  END

  -- Check that UnterstuetzungstraegerBaPersonID is not null. If it is, issue an error message
  UPDATE #NewKbWVEinzelposten
  SET EintragStatus = IsNull(EintragStatus, '') + 'WV-Einheitsträger ist nicht definiert!'
  WHERE UnterstuetzungstraegerBaPersonID IS NULL AND (EintragStatus IS NULL OR EintragStatus = '')

  -- Prüfe, dass die Kostenstelle definiert ist
  UPDATE #NewKbWVEinzelposten
  SET EintragStatus = IsNull(EintragStatus, '') + 'Kostenstelle ist nicht definiert!'
  WHERE NewKbWVEinzelpostenID IN
	(SELECT NewKbWVEinzelpostenID FROM #NewKbWVEinzelposten EP
		INNER JOIN KbBuchungBruttoPerson KBP ON KBP.KbBuchungBruttoPersonID = EP.KbBuchungBruttoPersonID
		INNER JOIN KbBuchungBrutto KBB ON KBB.KbBuchungBruttoID = KBP.KbBuchungBruttoID
	WHERE KBB.Kostenstelle IS NULL AND (EP.EintragStatus IS NULL OR EP.EintragStatus = ''))

  -------------------------------------------------------------------------------
  -- stretch WV-Units:
  -- Merge together WV-Units with the same FallID, WVCode, BED and Einheitsträger
  -------------------------------------------------------------------------------
  DECLARE @MaxDate datetime
  SET @MaxDate = '9999-12-31'

  DECLARE @ChangesDone bit
  DECLARE @WatchdogCounter int
  SET @WatchdogCounter = 0

  DECLARE @WvEinheitGruppiert TABLE
  (
    FaFallID      int,
    WhWVEinheitID int,
    WVCode        int,
    BEDCode       int,
    BaPersonID    int,
    MinVon        datetime,
    MaxBis        datetime,
    Updated       bit
  )

  -- only check wv-units that we are interested in
  INSERT INTO @WvEinheitGruppiert
  SELECT FaFallID, WhWVEinheitID, WVCode, BEDCode, BaPersonID, MinVon = DatumVon, MaxBis = IsNull(DatumBis,@MaxDate), 0
  FROM dbo.WhWVEinheit
  WHERE WhWVEinheitID IN (SELECT DISTINCT WhWVEinheitID
                          FROM #NewKbWVEinzelposten
                          WHERE WhWVEinheitID IS NOT NULL)

  -- Status-Update
	SET @JobID = @JobID + 1
  UPDATE WVL SET WVL.Text = 'Schritt ' + CONVERT(varchar, @JobID) + ' von 14: ' + CONVERT(varchar, GetDate(), 121) + ': Erstelle neue Einzelposten Step 7 von 8 ...' FROM dbo.KbWVLauf WVL WHERE KbWVLaufID = @KbWVLaufID
	EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'Erstelle neue Einzelposten Step 7 von 8', '', 'KbWVLauf', @KbWVLaufID

  -- search for neighbours
  WHILE 1=1 BEGIN
    SET @ChangesDone = 0
    SET @WatchdogCounter = @WatchdogCounter + 1

    UPDATE GRP
    SET MaxBis  = WVE.DatumBis,
        Updated = 1
    FROM @WvEinheitGruppiert GRP
      INNER JOIN dbo.WhWVEinheit WVE ON GRP.FaFallID   = WVE.FaFallID   AND
                                        GRP.WVCode     = WVE.WVCode     AND
                                        GRP.BEDCode    = WVE.BEDCode    AND
                                        GRP.BaPersonID = WVE.BaPersonID AND
                                        GRP.MaxBis     = DateAdd(D,-1,WVE.DatumVon)

    SET @ChangesDone = CASE WHEN @@ROWCOUNT > 0 THEN 1 ELSE 0 END

    UPDATE GRP
    SET MinVon  = WVE.DatumVon,
        Updated = 1
    FROM @WvEinheitGruppiert GRP
      INNER JOIN dbo.WhWVEinheit WVE ON GRP.FaFallID   = WVE.FaFallID   AND
                                        GRP.WVCode     = WVE.WVCode     AND
                                        GRP.BEDCode    = WVE.BEDCode    AND
                                        GRP.BaPersonID = WVE.BaPersonID AND
                                        DateAdd(D,-1,GRP.MinVon) = WVE.DatumBis

    IF @ChangesDone = 0 AND @@ROWCOUNT = 0 OR @WatchdogCounter > 1000 BREAK
  END

  -- now update the KbWVEinzelposten
  UPDATE NEW
  SET WVCodeVon = GRP.MinVon,
      WVCodeBis = CASE WHEN GRP.MaxBis = @MaxDate THEN NULL ELSE GRP.MaxBis END
  FROM #NewKbWVEinzelposten        NEW
    INNER JOIN @WvEinheitGruppiert GRP ON GRP.WhWVEinheitID = NEW.WhWVEinheitID AND GRP.Updated = 1

  -------------------------------------------------------------------------------
  -- HANDLE ERRORS:
  -- validate new entries using the given state returned from function
  --
  -- insert wrong entries into KbWVEinzelpostenFehler and delete them afterwards
  --   from temporary table to prevent wrong data in KbWVEinzelposten
  -------------------------------------------------------------------------------
  -- Status-Update
	SET @JobID = @JobID + 1
  UPDATE WVL SET WVL.Text = 'Schritt ' + CONVERT(varchar, @JobID) + ' von 14: ' + CONVERT(varchar, GetDate(), 121) + ': Erstelle neue Einzelposten Step 8 von 8 ...' FROM dbo.KbWVLauf WVL WHERE KbWVLaufID = @KbWVLaufID
	EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'Erstelle neue Einzelposten Step 8 von 8', '', 'KbWVLauf', @KbWVLaufID

  -- insert wrong entries int KbWVEinzelpostenFehler
  INSERT INTO dbo.KbWVEinzelpostenFehler (KbWVLaufID, KbBuchungBruttoPersonID, FaFallID, WVFehlermeldung)
    SELECT DISTINCT
           KbWVLaufID               = @KbWVLaufID,                            -- static var, created above
           KbBuchungBruttoPersonID  = NEP.KbBuchungBruttoPersonID,
           FaFallID                 = TBP.FaFallID,
           WVFehlermeldung          = NEP.EintragStatus
    FROM #NewKbWVEinzelposten NEP
      LEFT JOIN #KbBuchungBruttoPersonIDs TBP ON TBP.KbBuchungBruttoPersonID = NEP.KbBuchungBruttoPersonID
    WHERE NEP.EintragStatus IS NOT NULL

  -- remove wrong entries and continue with valid ones
  DELETE FROM #NewKbWVEinzelposten
  WHERE EintragStatus IS NOT NULL

  -------------------------------------------------------------------------------
  -- TESTLAUF:
  -- clear WhWVEinheitMitgliedID for 'Testlauf' to prevent problems when
  --   WhWVEinheitMitgliedID gets deleted on KiSS-GUI
  -------------------------------------------------------------------------------
  IF (@Testlauf = 1)
  BEGIN
    -- clear value
    UPDATE TMP
    SET TMP.WhWVEinheitMitgliedID = NULL
    FROM #NewKbWVEinzelposten TMP
  END

  -------------------------------------------------------------------------------
  -- PSCD-BELEG-NR / INSERT INTO KbWVEinzelposten:
  -- handle PscdBelegNr and inserts within transaction
  -------------------------------------------------------------------------------
  -- Status-Update
	SET @JobID = @JobID + 1
  UPDATE WVL SET WVL.Text = 'Schritt ' + CONVERT(varchar, @JobID) + ' von 14: ' + CONVERT(varchar, GetDate(), 121) + ': Speichere die erstellten Einzelposten ...' FROM dbo.KbWVLauf WVL WHERE KbWVLaufID = @KbWVLaufID
	EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'Speichere die erstellten Einzelposten', '', 'KbWVLauf', @KbWVLaufID

  BEGIN TRY
    -----------------------------------------------------------------------------
    -- init new transaction
    -----------------------------------------------------------------------------
    BEGIN TRANSACTION

    -----------------------------------------------------------------------------
    -- generate for each new entry a PscdBelegNr using stored procedure
    --   spKbGetBelegNr_out
    --
    -- hint: if current run is a 'Testlauf', we do not grab new PscdBelegNr!
    -----------------------------------------------------------------------------
    IF (@Testlauf = 0)
    BEGIN
      -- setup cursor
      DECLARE curNewKbWhEinzelposten CURSOR FAST_FORWARD FOR
        SELECT TMP.NewKbWVEinzelpostenID
        FROM #NewKbWVEinzelposten TMP

      OPEN curNewKbWhEinzelposten
      WHILE 1=1
      BEGIN
        FETCH NEXT FROM curNewKbWhEinzelposten INTO @NewKbWVEinzelpostenID
        IF @@FETCH_STATUS <> 0 BREAK

        -- get new PscdBelegNr from stored procedure
        SET @NewPscdBelegNr = NULL
        EXEC dbo.spKbGetBelegNr_out @KbBelegArt, @NewPscdBelegNr OUT

        -- update current entry with new PscdBelegNr
        UPDATE TMP
        SET TMP.PscdBelegNr = @NewPscdBelegNr
        FROM #NewKbWVEinzelposten TMP
        WHERE TMP.NewKbWVEinzelpostenID = @NewKbWVEinzelpostenID
      END

      -- close cursor
      CLOSE curNewKbWhEinzelposten
      DEALLOCATE curNewKbWhEinzelposten

      ---------------------------------------------------------------------------
      -- check if every new entry has a valid PscdBelegNr
      ---------------------------------------------------------------------------
      IF (EXISTS(SELECT TOP 1 1 FROM #NewKbWVEinzelposten WHERE IsNull(PscdBelegNr, -1) < 0))
      BEGIN
        -- invalid case, cannot continue
        RAISERROR ('Error: Not every new entry has a valid PscdBelegNr value, cannot continue!', 18, 1)
      END
    END --[IF (@Testlauf = 0)]

    -----------------------------------------------------------------------------
    -- insert all calculated and prepared entries from temp-table 
    --   into KbWVEinzelposten
    -----------------------------------------------------------------------------
    INSERT INTO dbo.KbWVEinzelposten (KbWVLaufID, UnterstuetzungstraegerBaPersonID, WVCode, BEDCode, WhWVEinheitMitgliedID,
                                      BeguenstigterBaPersonID, KbBuchungBruttoPersonID, BgSplittingArtCode, Betrag, DatumVon,
                                      DatumBis, SplittingDurchWVLaufDatumBis, PscdBelegNr, KbWVEinzelpostenStatusCode,
                                      Hauptvorgang, Teilvorgang, WohnHeimatKanton, Buchungstext, WVCodeVon, WVCodeBis)
      SELECT KbWVLaufID                       = @KbWVLaufID,                                -- static var, created above
             UnterstuetzungstraegerBaPersonID = NEP.UnterstuetzungstraegerBaPersonID,
	         WVCode                           = NEP.WVCode,
	         BEDCode                          = NEP.BEDCode,
	         WhWVEinheitMitgliedID            = NEP.WhWVEinheitMitgliedID,
	         BeguenstigterBaPersonID          = NEP.BeguenstigterBaPersonID,
	         KbBuchungBruttoPersonID          = NEP.KbBuchungBruttoPersonID,
             BgSplittingArtCode               = NEP.BgSplittingArtCode,
	         Betrag                           = (FLOOR(NEP.Betrag * 20.0 + 0.5) / 20.0),    -- round up/down to 0.05 CHF (if you change something here, remember to change dbo.fnKbWVEinzelposten_WVEinheitenProBuchung as well for 'Teilausgleich'!)
	         DatumVon                         = NEP.DatumVon,
	         DatumBis                         = NEP.DatumBis,
             SplittingDurchWVLaufDatumBis     = NEP.SplittingDurchWVLaufDatumBis,
             PscdBelegNr                      = NEP.PscdBelegNr,
	         KbWVEinzelpostenStatusCode       = @KbWVEinzelpostenStatusCode,                -- static var, created above
             Hauptvorgang                     = NEP.Hauptvorgang,
             Teilvorgang                      = NEP.Teilvorgang,
             WohnHeimatKanton                 = NEP.WohnHeimatKanton,
             Buchungstext                     = NEP.Buchungstext,
             WVCodeVon                        = NEP.WVCodeVon,
             WVCodeBis                        = NEP.WVCodeBis
      FROM #NewKbWVEinzelposten NEP
      WHERE ABS(FLOOR(NEP.Betrag * 20.0 + 0.5) / 20.0) >= 0.05

    -----------------------------------------------------------------------------
    -- Insert are done, commit changes now
    -----------------------------------------------------------------------------
    COMMIT TRANSACTION
  END TRY

  BEGIN CATCH
    -- error occured, do undo PscdBelegNr and inserts
    ROLLBACK TRANSACTION

    -- set error part
    SET @ErrorMessage = ERROR_MESSAGE()

	-- Drop temporary Tables
	DROP TABLE #KbBuchungBruttoPersonIDs
	DROP TABLE #NewKbWVEinzelposten
	
    -- do not continue
    RAISERROR ('Error: Could not process generating PscdBelegNr and inserts into KbWVEinzelposten. Database error was: %s.', 18, 1, @ErrorMessage)
    RETURN
  END CATCH
  
  -- Drop temporary Tables
  DROP TABLE #KbBuchungBruttoPersonIDs
  DROP TABLE #NewKbWVEinzelposten
  
    -- Status-Update
	SET @JobID = @JobID + 1
  UPDATE WVL SET WVL.Text = 'Schritt ' + CONVERT(varchar, @JobID) + ' von 14: ' + CONVERT(varchar, GetDate(), 121) + ': Update der erstellten und gespeicherten Einzelposten Step 1 von 2...' FROM dbo.KbWVLauf WVL WHERE KbWVLaufID = @KbWVLaufID
	EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'Update der erstellten und gespeicherten Einzelposten Step 1 von 2', '', 'KbWVLauf', @KbWVLaufID

  BEGIN TRY  

  -------------------------------------------------------------------------------
  -- Determine correct SKZ-Number:
  -- Look up current Number for WV-Einheitsträger
  -------------------------------------------------------------------------------
/*
  UPDATE WEP
  SET SKZNummer = SKZ.SKZNummer
  FROM #NewKbWVEinzelposten WEP
    INNER JOIN (SELECT BaPersonID, SKZNummer = MAX(SKZNummer)
                FROM WhWVEinheit
                WHERE Ungueltig = 0 AND
                      --SKZNummer IS NOT NULL AND
                      @DatumBisWVLauf BETWEEN DatumVon AND IsNull(DatumBis,'9999-12-31')
                GROUP BY BaPersonID) SKZ ON SKZ.BaPersonID = WEP.UnterstuetzungstraegerBaPersonID

*/
  CREATE TABLE #UT2SKZ
  (
    BaPersonID INT NOT NULL PRIMARY KEY CLUSTERED,
    SKZNummer  VARCHAR(50)
  )

  CREATE TABLE #UT2Heimatkanton
  (
    BaPersonID     INT,
    BEDCode        INT,
    HeimatKantonNr VARCHAR(50)
    CONSTRAINT [UT2Heimatkanton_PK] PRIMARY KEY CLUSTERED 
    (
	  BaPersonID,
      BEDCode
    )
  )

  INSERT INTO #UT2SKZ (BaPersonID)
  SELECT DISTINCT UnterstuetzungstraegerBaPersonID
  FROM KbWvEinzelposten
  WHERE KbWVLaufID = @KbWVLaufID
  
  INSERT INTO #UT2Heimatkanton (BaPersonID, BEDCode)
  SELECT DISTINCT UnterstuetzungstraegerBaPersonID, BEDCode
  FROM KbWvEinzelposten 
  WHERE KbWVLaufID = @KbWVLaufID


  UPDATE MAP
  SET SKZNummer = WVE.SKZNummer
  FROM #UT2SKZ MAP
    CROSS APPLY(SELECT TOP 1 SKZNummer
                FROM WhWVEinheit
                WHERE BaPersonID = MAP.BaPersonID
                ORDER BY CASE WHEN SKZNummer IS NULL OR SKZNummer = 0 THEN 1 ELSE 0 END ASC, -- Leere interessieren uns nicht
                         Ungueltig ASC,
                         DatumBis DESC) WVE

  UPDATE MAP
  SET HeimatKantonNr = WVE.HeimatKantonNr
  FROM #UT2Heimatkanton MAP
    CROSS APPLY(SELECT TOP 1 HeimatKantonNr
                FROM WhWVEinheit
                WHERE BaPersonID = MAP.BaPersonID AND BEDCode = MAP.BEDCode
                ORDER BY CASE WHEN HeimatKantonNr IS NULL OR LTRIM(HeimatKantonNr) = '' THEN 1 ELSE 0 END ASC, -- Leere interessieren uns nicht
                         Ungueltig ASC,
                         DatumBis DESC) WVE

	SET @JobID = @JobID + 1
  UPDATE WVL SET WVL.Text = 'Schritt ' + CONVERT(varchar, @JobID) + ' von 14: ' + CONVERT(varchar, GetDate(), 121) + ': Update der erstellten und gespeicherten Einzelposten Step 2 von 2...' FROM dbo.KbWVLauf WVL WHERE KbWVLaufID = @KbWVLaufID
	EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'Update der erstellten und gespeicherten Einzelposten Step 2 von 2', '', 'KbWVLauf', @KbWVLaufID

    -----------------------------------------------------------------------------
    -- ensure that a person has only one SKZNummer and one Heimatkanton
    -----------------------------------------------------------------------------
    UPDATE WEP
    SET SKZNummer = MAP.SKZNummer
    FROM KbWVEinzelposten WEP
      INNER JOIN #UT2SKZ  MAP ON MAP.BaPersonID = WEP.UnterstuetzungstraegerBaPersonID
    WHERE WEP.KbWVLaufID = @KbWVLaufID

    UPDATE WEP
    SET HeimatkantonNr = MAP.HeimatkantonNr
    FROM KbWVEinzelposten         WEP
      INNER JOIN #UT2Heimatkanton MAP ON MAP.BaPersonID = WEP.UnterstuetzungstraegerBaPersonID AND
                                         MAP.BEDCode    = WEP.BEDCode
    WHERE WEP.KbWVLaufID = @KbWVLaufID

    DROP TABLE #UT2SKZ
    DROP TABLE #UT2Heimatkanton

  END TRY

  BEGIN CATCH
    -- set error part
    SET @ErrorMessage = ERROR_MESSAGE()
    DROP TABLE #UT2SKZ
    DROP TABLE #UT2Heimatkanton
    -- do not continue
    RAISERROR ('Error: Could not update the generated KbWVEinzelposten. Database error was: %s.', 18, 1, @ErrorMessage)
    RETURN
  END CATCH

  PRINT('done create new data: ' + CONVERT(varchar, GetDate(), 121))
  -- ============================================================================




  -- ============================================================================
  -- DONE: IF WE ARE HERE, EVERYTHING WORKED AS EXPECTED
  -- ============================================================================
  -------------------------------------------------------------------------------
  -- update entry within KbWVLauf to determine duration
  -------------------------------------------------------------------------------
  UPDATE WVL
  SET 
  WVL.EndDatum = GetDate(),
  WVL.Text = 'Lauf ist erfolgreich aufbereitet worden'
  FROM dbo.KbWVLauf WVL
  WHERE KbWVLaufID = @KbWVLaufID

	SET @JobID = @JobID + 1
	EXEC spXLogAddEntry @ProcedureName, @JobID, 1, 'Lauf ist erfolgreich aufbereitet worden', '', 'KbWVLauf', @KbWVLaufID

  -------------------------------------------------------------------------------
  -- return current entry from KbWVLauf 
  --   (used to find corresponding entries within KbWVEinzelposten)
  -------------------------------------------------------------------------------
  SELECT *
  FROM dbo.KbWVLauf WVL WITH (READUNCOMMITTED)
  WHERE WVL.KbWVLaufID = @KbWVLaufID
  -- ============================================================================
  
  
END