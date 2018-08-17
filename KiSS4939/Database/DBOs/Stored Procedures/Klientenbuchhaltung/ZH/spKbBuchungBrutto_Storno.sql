SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKbBuchungBrutto_Storno
GO
/*===============================================================================================
  $Revision: 6 $
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
CREATE PROCEDURE dbo.spKbBuchungBrutto_Storno
(
	@KbBuchungBruttoID INT,
	@UserID INT,
	@MinimumStornoDatum DATETIME, -- Frühestes Stornodatum. Wenn das Original-Buchungsdatum neuer ist, dann wird das Original-Buchungsdatum verwendet
	@StornoGruppierung varchar(10) OUTPUT
)
AS BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON

	-- Kontrolle Parameter
	-- -------------------
	IF @KbBuchungBruttoID IS NULL BEGIN
		RAISERROR ('Der Aufruf-Parameter @KbBuchungBruttoID ist null!', 18, 1)
		RETURN -1
	END

	IF @UserID IS NULL BEGIN
		RAISERROR ('Der Aufruf-Parameter @UserID ist null!', 18, 1)
		RETURN -1
	END

	DECLARE @errorMsg varchar(200)

	-- Return-Wert bei erfolgreichem Storno. Ist Null bei Fehler, oder wenn es nichts zu tun gab
	SET @StornoGruppierung = NULL

	BEGIN TRY

		-- Brutto-Storno erstellen
		--------------------------
		DECLARE @KbBuchungBruttoID_new int

		-- Neue Gruppierungs-Nummer lösen
		DECLARE @GruppierungNr bigint
		DECLARE @Temp varchar(8)

		SET @GruppierungNr = NULL
		EXEC dbo.spKbGetBelegNr_out 'PYGRP', @GruppierungNr OUT
		SET @Temp = CONVERT(varchar, @GruppierungNr)
		SET @StornoGruppierung = 'S' + SubString('00000000', 1, 8-LEN(@Temp)) + @Temp

		--Kopf einfügen mit umgekehrtem Betrag
		INSERT INTO KbBuchungBrutto (
					[KbPeriodeID], [BgKostenartID], [KbBuchungTypCode], [Code], [BelegDatum], [Zahlungsfrist],
					[BetragEffektiv], [DatumEffektiv], [BgBudgetID], [ModulID], 
					[Kostenstelle], [Hauptvorgang], [Teilvorgang], [FaLeistungID], BgSplittingArtCode, Weiterverrechenbar, Quoting, Abgetreten,
					-- Geänderte Felder
					[BelegNr], 
					[Belegart],
					[TransferDatum],
					[ValutaDatum],
					[PscdFehlermeldung],
					[UserID], [ErfassungsDatum],
					[Betrag],
					[StorniertKbBuchungBruttoID],
					[KbBuchungStatusCode],
					[Text],
					[GruppierungUmbuchung],
					PscdKennzeichen
				)
			SELECT	[KbPeriodeID], [BgKostenartID], [KbBuchungTypCode], [Code], [BelegDatum], [Zahlungsfrist],
					[BetragEffektiv], [DatumEffektiv], [BgBudgetID], [ModulID], 
					[Kostenstelle], [Hauptvorgang], [Teilvorgang], [FaLeistungID], BgSplittingArtCode, Weiterverrechenbar, Quoting, Abgetreten,
					-- Geänderte Felder
					CASE WHEN [TransferDatum] IS NULL THEN NULL ELSE BelegNr END, -- Falls das Original-TransferDatum definiert ist kopieren wir hier die PSCD Beleg-Nummer. Das Feld wird im KiSS-Server verwendet, um den übermittelten Original-Beleg zu stornieren. Die STO-Belegnummer wird dann hier abgelegt
					'UB',   -- Belegart ist UB bei Umbuchungen und Stornos
					CASE WHEN [TransferDatum] IS NULL THEN NULL ELSE GetDate() END, -- Falls das Original-TransferDatum definiert ist, wird das aktuelle Tagesdatum als TransferDatum des STO-Belegs verwendet, sonst Null.
					CONVERT(DateTime, dbo.fnMAX(@MinimumStornoDatum, ValutaDatum)),
					NULL,
					@UserID, GetDate(),
					-Betrag,	-- negativer Betrag
					@KbBuchungBruttoID,
					8, -- 8 = Storniert
					'STO ' + CONVERT(varchar, COALESCE(BelegNr, @KbBuchungBruttoID)) + ' ' + [Text],
					@StornoGruppierung,
					'U'
		  FROM KbBuchungBrutto
		  WHERE KbBuchungBruttoID = @KbBuchungBruttoID

		-- Neue STO-Brutto-Beleg-ID holen
		SELECT @KbBuchungBruttoID_new = SCOPE_IDENTITY()

		-- Update der Storno-Gruppierung und des Status = Storno beim Original-Bruttobeleg
		UPDATE KbBuchungBrutto
		SET GruppierungUmbuchung = @StornoGruppierung,
			KbBuchungStatusCode = 8
		WHERE KbBuchungBruttoID = @KbBuchungBruttoID

		-- Detailpositionen einfügen
		INSERT INTO KbBuchungBruttoPerson (
					[BgPositionID], [BaPersonID], [Schuldner_BaInstitutionID], [Schuldner_BaPersonID], [VerwPeriodeVon], [VerwPeriodeBis], [PositionImBeleg], [GesperrtFuerWV], [SpezBgKostenartID], [SpezHauptvorgang], [SpezTeilvorgang], [Zinsperiode],
					-- Geänderte Felder:
					[Buchungstext],
					[KbBuchungBruttoID],
					[Betrag]
				)
			SELECT 	KBP.BgPositionID, KBP.BaPersonID, KBP.Schuldner_BaInstitutionID, KBP.Schuldner_BaPersonID, KBP.VerwPeriodeVon, KBP.VerwPeriodeBis, KBP.PositionImBeleg, KBP.GesperrtFuerWV, KBP.SpezBgKostenartID, KBP.SpezHauptvorgang, KBP.SpezTeilvorgang, KBP.Zinsperiode,
					-- Geänderte Felder:
					'STO ' + CONVERT(varchar, COALESCE(KBB.BelegNr, @KbBuchungBruttoID)) + ' ' + KBP.Buchungstext,
					@KbBuchungBruttoID_new,
					-KBP.Betrag		-- negativer Betrag
			FROM KbBuchungBruttoPerson KBP WITH (READUNCOMMITTED)
				INNER JOIN KbBuchungBrutto KBB WITH (READUNCOMMITTED) ON KBB.KbBuchungBruttoID = KBP.KbBuchungBruttoID
			WHERE KBP.KbBuchungBruttoID = @KbBuchungBruttoID

	END TRY
	BEGIN CATCH
		SET @errormsg = ERROR_MESSAGE()
		--ROLLBACK
		RAISERROR(@errormsg,18,1)
	END CATCH
END



