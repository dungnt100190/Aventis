SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spPscdUpdateWvStatus
GO
/*===============================================================================================
  $Revision: 4 $
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

CREATE PROCEDURE dbo.spPscdUpdateWvStatus
(
  @ID int,
  @OPBelegNr bigint,
  @WVSTATUS varchar(1),
  @FUBANAME varchar(50),
  @TIMESTAMP varchar(50),
  @MANDT varchar(50),
  @OPUPK varchar(50),
  @OPUPW varchar(50),
  @OPUPZ varchar(50)
)
AS

BEGIN TRY
	BEGIN TRANSACTION    
	--INIT
	DECLARE 
	@StatusCodeALT int,
	@StatusCodeNEU int,
	@WvEinzelpostenID int,
	@PscdWvStatusLogID int,
	@count int,
	@Source varchar(20),
	@msg varchar(200),
	@valid bit
	SET @valid = 0
	SET @count = 0


	--wenn schon als verarbeitet vorhanden, abbrechen
	IF @ID IS NOT NULL BEGIN
		SELECT @count = count(*)
		FROM dbo.PscdWvStatusLog WITH (READUNCOMMITTED)
		WHERE PscdWvStatusLogID = @ID
		AND Verarbeitet = 1

		IF @count > 0 BEGIN
			SET @msg = 'id  ' + CAST(@ID AS varchar) + ' wurde bereits erfolgreich verarbeitet!'
			RAISERROR(@msg,18,1)
			RETURN
		END
	END

	--Datensatz lesen
	SELECT @WvEinzelpostenID = KbWVEinzelpostenID, @StatusCodeALT = KbWVEinzelpostenStatusCode 
	FROM dbo.KbWVEinzelposten WITH (READUNCOMMITTED)
	WHERE PscdBelegNr = @OPBelegNr

	SET @Source = 'KbWVEinzelposten'

	--falls nicht vorhanden, in MigWVEinzelposten lesen
	IF @WvEinzelpostenID IS NULL BEGIN
		SELECT @WvEinzelpostenID = MigWVEinzelpostenID, @StatusCodeALT = KbWVEinzelpostenStatusCode  
		FROM dbo.MigWVEinzelposten WITH (READUNCOMMITTED)
		WHERE PscdBelegNr = @OPBelegNr

		SET @Source = 'MigWVEinzelposten'
	END

	--falls nicht vorhanden, in KbBuchungBrutto lesen
	IF @WvEinzelpostenID IS NULL BEGIN
		SELECT @WvEinzelpostenID = KbBuchungBruttoID
		FROM dbo.KbBuchungBrutto WITH (READUNCOMMITTED)
		WHERE BelegNr = @OPBelegNr

		SET @Source = 'KbBuchungBrutto'
	END

	IF @WvEinzelpostenID IS NULL BEGIN
		SET @Source = ''
	END

	--Status-ShortText -> Code (LOV kbwv: L=1, V=2, F=3, usw.)
	SELECT @StatusCodeNEU = Code 
	FROM dbo.XLOVCode WITH (READUNCOMMITTED)
	WHERE LOVName = 'KbWVEinzelpostenStatus' 
	AND ShortText = @WVSTATUS

	--Validierungen: @StatusCodeALT -> @StatusCodeNEU	
	IF @WvEinzelpostenID IS NOT NULL BEGIN
		--keine Statusaenderung bei KbBuchungBrutto
		IF @Source = 'KbBuchungBrutto' BEGIN
			SET @valid = 1
		END
	    -- Status hat nicht geändert => Wir akzeptieren dies auch
		IF @StatusCodeALT = @StatusCodeNEU BEGIN
			SET @valid = 1
		END
		-- L->V
		IF @StatusCodeALT = 1 AND @StatusCodeNEU = 2 BEGIN
			SET @valid = 1
		END
		-- V->F
		IF @StatusCodeALT = 2 AND @StatusCodeNEU = 3 BEGIN
			SET @valid = 1
		END
		-- F->B
		IF @StatusCodeALT = 3 AND @StatusCodeNEU = 4 BEGIN
			SET @valid = 1
		END
		-- F->A
		IF @StatusCodeALT = 3 AND @StatusCodeNEU = 5 BEGIN
			SET @valid = 1
		END
		-- A->N
		IF @StatusCodeALT = 5 AND @StatusCodeNEU = 6 BEGIN
			SET @valid = 1
		END
		-- A->S
		IF @StatusCodeALT = 5 AND @StatusCodeNEU = 7 BEGIN
			SET @valid = 1
		END
		-- A->F
		IF @StatusCodeALT = 5 AND @StatusCodeNEU = 3 BEGIN
			SET @valid = 1
		END	END

	--Log-Eintrag-initial, oder schon vorhanden
	IF @ID IS NOT NULL BEGIN
		SET @PscdWvStatusLogID = @ID
	END
	ELSE IF @ID IS NULL BEGIN
		INSERT INTO PscdWvStatusLog(Source, WvEinzelpostenID, OPBEL, WvStatusCodeAlt, WvStatusCodeNeu, WVSTATUS, FUBANAME, [TIMESTAMP], MANDT, OPUPK, OPUPW, OPUPZ)
		VALUES (@Source, @WvEinzelpostenID, @OPBelegNr, @StatusCodeALT, @StatusCodeNEU, @WVSTATUS, @FUBANAME, @TIMESTAMP, @MANDT, @OPUPK, @OPUPW, @OPUPZ)
		SET @PscdWvStatusLogID = SCOPE_IDENTITY()
	END

	--Update
	IF @valid = 1 BEGIN
		IF @Source = 'KbWVEinzelposten' BEGIN
			UPDATE KbWVEinzelposten
			SET KbWVEinzelpostenStatusCode = @StatusCodeNEU
			WHERE PscdBelegNr = @OPBelegNr
		END

		IF @Source = 'MigWVEinzelposten' BEGIN
			UPDATE MigWVEinzelposten
			SET KbWVEinzelpostenStatusCode = @StatusCodeNEU
			WHERE PscdBelegNr = @OPBelegNr
		END

		IF @Source = 'KbBuchungBrutto' BEGIN
			UPDATE KbBuchungBrutto
			SET Fakturiert = 1
			WHERE BelegNr = @OPBelegNr
		END

		--Log
		UPDATE PscdWvStatusLog
		SET Verarbeitet = 1
		WHERE PscdWvStatusLogID = @PscdWvStatusLogID
	END

	--Fehler
	IF @WvEinzelpostenID IS NULL BEGIN
		SET @msg = 'Keinen Einzelposten/Buchung mit der Belegnummer ' + CAST(@OPBelegNr AS varchar) + ' gefunden!'
		--Log
		UPDATE PscdWvStatusLog
		SET Fehlermeldung = @msg
		WHERE PscdWvStatusLogID = @PscdWvStatusLogID
		
		RAISERROR(@msg,18,1)
	END
	ELSE IF @valid = 0 BEGIN
		SET @msg = 'Belegnummer ' + CAST(@OPBelegNr AS varchar) + ': Statusänderung von ' + dbo.fnLOVShortText('KbWVEinzelpostenStatus',@StatusCodeALT)+ ' nach ' + @WVSTATUS + ' unzulässig!'
		--Log
		UPDATE PscdWvStatusLog
		SET Fehlermeldung = @msg
		WHERE PscdWvStatusLogID = @PscdWvStatusLogID
		
		RAISERROR(@msg,18,1)
	END

	COMMIT
END TRY

BEGIN CATCH  
	IF @@TRANCOUNT > 0
		ROLLBACK

	SET @msg = 'Line ' + CAST(ERROR_LINE() AS varchar) + ': ' + ERROR_MESSAGE()
	--Log
	IF @ID IS NOT NULL BEGIN
		UPDATE PscdWvStatusLog SET Fehlermeldung = @msg WHERE PscdWvStatusLogID = @ID AND Verarbeitet = 0
	END
	ELSE IF @ID IS NULL BEGIN
		INSERT INTO PscdWvStatusLog(Source, WvEinzelpostenID, OPBEL, WvStatusCodeAlt, WvStatusCodeNeu, WVSTATUS, FUBANAME, [TIMESTAMP], MANDT, OPUPK, OPUPW, OPUPZ, Fehlermeldung)
		VALUES (@Source, @WvEinzelpostenID, @OPBelegNr, @StatusCodeALT, @StatusCodeNEU, @WVSTATUS, @FUBANAME, @TIMESTAMP, @MANDT, @OPUPK, @OPUPW, @OPUPZ, @msg)
	END

	RAISERROR(@msg,18,1)
END CATCH

