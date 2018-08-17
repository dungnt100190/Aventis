SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spNeufakturierungAbgesetzterMigWVEinzelposten
GO
/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spNeufakturierungAbgesetzterMigWVEinzelposten
(
  @Test bit,--1=test, 0=scharf
  @KbWVLaufID int,
  @FilterWVCodes varchar(2000) = NULL,
  @FilterBEDCodes varchar(2000) = NULL

)
AS

BEGIN TRY
	BEGIN TRANSACTION
	--INIT
	DECLARE
	@msg varchar(500),
	@Betrag money,
	@DatumVon Datetime,
	@DatumBis Datetime,
	@MigBaPersonID int,
	@LATextProleist varchar(200),
	@UnterstuetzungstraegerBaPersonID int,
	@WVCode int,
	@BED int,
	@WohnHeimatKanton varchar(1),
	@Hauptvorgang int,
	@Teilvorgang int,
	@WhWVEinheitID int,
	@SKZNummer varchar(50),
	@HeimatkantonNr varchar(50),
	@KbWVEinzelpostenStatusCode int,
	@MigWVEinzelpostenID int,
	@count int,
	@WhWVEinheitMitgliedID int,
	@NewPscdBelegNr bigint

	SET @KbWVEinzelpostenStatusCode = 100 --TEST(100) as default , 101 is DEV-dummy

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


	--PROCESS
	DECLARE cStornierteMigWVEinzelposten CURSOR FAST_FORWARD FOR
	SELECT MWV.MigWVEinzelpostenID, MWV.Betrag, MWV.VonDatum, MWV.BisDatum, MWV.BaPersonID, MWV.LATextProleist, ALT.BaPersonID,
           WVC.WVCode, WVC.BaBedID, LOVX.WohnHeimatKanton, LOVX.Hauptvorgang, LOVX.Teilvorgang, NULL, WVC.SKZNummer,
           WVC.HeimatkantonNr, NULL
	FROM MigWVEinzelposten              MWV
      INNER JOIN BaAlteFallNr ALT ON ALT.MigHerkunftCode = 1 AND ALT.PersonNrAlt = MWV.UnterTraegerProleist
      INNER JOIN BaWVCode WVC ON WVC.BaWVCodeID = (SELECT TOP 1 BaWVCodeID
                                                   FROM BaWVCode                       WVCI
                                                     INNER JOIN XLOVCode               LOVI  ON LOVI.LOVName = 'BaWVCode' AND LOVI.Code = WVCI.WVCode
                                                     INNER JOIN BaWVCodeLOVEx          LOVXI ON LOVXI.BaWVCodeLOVExID = LOVI.Code
                                                   WHERE WVCI.BaWVStatusCode = 1 AND WVCI.BaPersonID = MWV.BaPersonID  AND (MWV.VonDatum BETWEEN WVCI.DatumVon AND IsNull(WVCI.DatumBis,'9999-12-31') OR MWV.BisDatum BETWEEN WVCI.DatumVon AND IsNull(WVCI.DatumBis,'9999-12-31'))
                                                   ORDER BY DateDiff(d,CASE WHEN WVCI.DatumVon > MWV.VonDatum THEN WVCI.DatumVon ELSE MWV.VonDatum END,CASE WHEN WVCI.DatumBis < MWV.BisDatum THEN WVCI.DatumBis ELSE MWV.BisDatum END) DESC, CASE WHEN LOVXI.Hauptvorgang IS NULL THEN 2 ELSE 1 END) -- falls sich codes überschneiden, den nehmen, der weiterverrechenbar ist
--      INNER JOIN BaWVCode               WVC  ON WVC.BaPersonID = MWV.BaPersonID AND WVC.BaWVStatusCode = 1 AND (MWV.VonDatum BETWEEN WVC.DatumVon AND IsNull(WVC.DatumBis,'9999-12-31') OR MWV.BisDatum BETWEEN WVC.DatumVon AND IsNull(WVC.DatumBis,'9999-12-31'))
      INNER JOIN XLOVCode               LOV  ON LOVName = 'BaWVCode' AND LOV.Code = WVC.WVCode
      INNER JOIN BaWVCodeLOVEx          LOVX ON LOVX.BaWVCodeLOVExID = LOV.Code
--      LEFT  JOIN WhWVEinheit                  WVE  ON WVE.BEDCode = MWV.BED AND LOV.Code = WVE.WVCode AND WVE.BaPersonID = MWV.BaPersonID AND WVE.Ungueltig = 0 AND (MWV.VonDatum BETWEEN WVE.DatumVon AND IsNull(WVE.DatumBis,'9999-12-31') OR MWV.BisDatum BETWEEN WVE.DatumVon AND IsNull(WVE.DatumBis,'9999-12-31'))
--      LEFT  JOIN WhWVEinheitMitglied          WVM  ON WVM.WhWVEinheitID = WVE.WhWVEinheitID AND WVM.BaPersonID = MWV.BaPersonID--mehere Mitglieder pro Einheit
      LEFT  JOIN KbWVEinzelposten       EIP  ON EIP.KbWVEinzelpostenID = MWV.KbWVEinzelpostenID
	WHERE MWV.KbWVEinzelpostenStatusCode = 7 /*storniert*/
      AND (EIP.KbWVEinzelpostenID IS NULL /*entweder es gibt noch keinen EP*/ OR
           EIP.KbWVEinzelpostenStatusCode IN (100,7) /*oder es ist nur ein Testposten bzw einen bereits wieder stornierten Echt-Posten*/)
      AND WVC.WVCode  IN (SELECT WVCode  FROM @WVCodesToKeep)
      AND WVC.BaBedID IN (SELECT BEDCode FROM @BEDCodesToKeep)

	SET @Count = 0

	OPEN cStornierteMigWVEinzelposten
	WHILE 1=1
	BEGIN
	  FETCH NEXT FROM cStornierteMigWVEinzelposten
	  INTO @MigWVEinzelpostenID, @Betrag, @DatumVon, @DatumBis, @MigBaPersonID, @LATextProleist, @UnterstuetzungstraegerBaPersonID,
			@WVCode, @BED, @WohnHeimatKanton, @Hauptvorgang, @Teilvorgang, @WhWVEinheitID, @SKZNummer, @HeimatkantonNr, @WhWVEinheitMitgliedID
	  IF @@FETCH_STATUS <> 0 BREAK


		IF @Test = 0 BEGIN
        SET @KbWVEinzelpostenStatusCode = 1 --(bei Test=100)
        SET @NewPscdBelegNr = NULL
        EXEC dbo.spKbGetBelegNr_out 'WV', @NewPscdBelegNr OUT
		END
		--Falls die Buchung schon scharf existiert, kein Insert machen (weiter loopen)
		/*IF (SELECT count(*) 
			FROM KbWVEinzelposten 
			WHERE KbWvEinzelpostenStatusCode = 1
			AND KbWVLaufID = @KbWVLaufID
			AND UnterstuetzungstraegerBaPersonID = @UnterstuetzungstraegerBaPersonID
			AND WVCode = @WVCode
			AND BEDCode = @BED
			AND WhWVEinheitMitgliedID = @WhWVEinheitMitgliedID
			AND BeguenstigterBaPersonID = @UnterstuetzungstraegerBaPersonID
			AND Betrag = @Betrag
			AND Hauptvorgang = @Hauptvorgang
			AND Teilvorgang = @Teilvorgang
			AND SKZNummer = @SKZNummer) > 0
		  CONTINUE*/

		INSERT INTO [KbWVEinzelposten]
           ([KbWVLaufID]
           ,[UnterstuetzungstraegerBaPersonID]
           ,[WVCode]
           ,[BEDCode]
			,[WhWVEinheitMitgliedID]
           ,[BeguenstigterBaPersonID]
           ,[Betrag]
           ,[DatumVon]
           ,[DatumBis]
           ,[SplittingDurchWVLaufDatumBis]
           ,[PscdBelegNr]
           ,[KbWVEinzelpostenStatusCode]
           ,[Ungueltig]
           ,[Hauptvorgang]
           ,[Teilvorgang]
           ,[WohnHeimatKanton]
           ,[Buchungstext]
           ,[SKZNummer]
           ,[HeimatkantonNr]
			)
       VALUES
           (@KbWVLaufID
           ,@UnterstuetzungstraegerBaPersonID
           ,@WVCode
           ,@BED
		   ,@WhWVEinheitMitgliedID
           ,@MigBaPersonID
           ,@Betrag
           ,@DatumVon
           ,@DatumBis
           ,0
           ,@NewPscdBelegNr
           ,@KbWVEinzelpostenStatusCode--Bei Test 100 (Paramter in sp), echt: 1(Lieferbar)
           ,0
           ,@Hauptvorgang
           ,@Teilvorgang
           ,@WohnHeimatKanton
           ,@LATextProleist
           ,@SKZNummer
           ,@HeimatkantonNr
			)

	    UPDATE MigWVEinzelposten
	    SET KbWVEinzelpostenID = SCOPE_IDENTITY()
	    WHERE MigWVEinzelpostenID = @MigWVEinzelpostenID

		--Log
		SET @msg = 'erfolgreich' --TODO: später ev. erfolgreiche nicht mehr loggen

		--Fehlende WV-Einheit, Warnung loggen
--		IF @WhWvEinheitID IS NULL
--			SET @msg = @msg + ', ACHTUNG: Keine passende WV-Einheit gefunden!'
		--Fehlende Felder, nur Warnen
		IF @Hauptvorgang IS NULL
			SET @msg = @msg + ', ACHTUNG: Hauptvorgang fehlt!'
		IF @Teilvorgang IS NULL
			SET @msg = @msg + ', ACHTUNG: Teilvorgang fehlt!'
		IF @WohnHeimatKanton IS NULL
			SET @msg = @msg + ', ACHTUNG: WohnHeimatKanton fehlt!'
		IF @HeimatkantonNr IS NULL
			SET @msg = @msg + ', ACHTUNG: HeimatkantonNr fehlt!'

		INSERT INTO [NeufakturierungAbgesetzterMigWVEinzelpostenLog]
		(KbWVLaufID,MigWVEinzelpostenID,KbWVEinzelpostenID,Neufakturiert, KbWVEinzelpostenStatusCode,Fehlermeldung)
		VALUES (@KbWVLaufID, @MigWVEinzelpostenID, SCOPE_IDENTITY(), 1, @KbWVEinzelpostenStatusCode, @msg)

	    SET @Count = @Count + 1
	END

	CLOSE cStornierteMigWVEinzelposten
	DEALLOCATE cStornierteMigWVEinzelposten

	SELECT @count, @KbWVEinzelpostenStatusCode
	COMMIT
END TRY

BEGIN CATCH
	IF @@TRANCOUNT > 0
		ROLLBACK
	--Log
	SET @msg = 'Line ' + CAST(ERROR_LINE() AS varchar) + ': ' + ERROR_MESSAGE()
	INSERT INTO [NeufakturierungAbgesetzterMigWVEinzelpostenLog]
	(KbWVLaufID,MigWVEinzelpostenID,Neufakturiert, KbWVEinzelpostenStatusCode,Fehlermeldung)
	VALUES (@KbWVLaufID, @MigWVEinzelpostenID, 0, @KbWVEinzelpostenStatusCode, @msg)

	CLOSE cStornierteMigWVEinzelposten
	DEALLOCATE cStornierteMigWVEinzelposten


	RAISERROR(@msg,18,1)
END CATCH
