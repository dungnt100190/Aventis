SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKbBuchung_Storno
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spKbBuchung_Storno.sql $
  $Author: Nweber $
  $Modtime: 14.07.10 10:40 $
  $Revision: 13 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spKbBuchung_Storno.sql $
 * 
 * 13    14.07.10 11:35 Nweber
 * #6064: Spalte KbPeriodeID von der Tabelle KbBuchungKostenart löschen
 * 
 * 12    11.12.09 11:57 Lloreggia
 * Header aktualisiert
 * 
 * 11    5.05.09 0:17 Rstahel
 * #4598: BelegNummer beim Brutto-Storno-Beleg muss vom Originalbeleg
 * kopiert werden, sonst kann die STO-BAPI nicht mit der korrekten
 * BelegNummer aufgerufen werden
 * 
 * 9     14.04.09 14:11 Rstahel
 * ##4567: Neu wird das TransferDatum mit GetDate() gefüllt
 * 
 * 8     3.04.09 18:08 Rstahel
 * ##4548: Storno von Inkasso-Forderungen funktionierte nicht. Dies sollte
 * nun behoben sein.
=================================================================================================*/

-- ===================================================================================================
-- Author:		sozheo
-- Create date: 20.06.2008
-- Description:	Stornieren einer Buchung für alle Module
-- ===================================================================================================
-- History:
-- 20.06.2008 : sozheo : neu erstellt
-- 20.02.2009 : sozseo : (Pendenz 79) SP neu erstellt, damit ganze Netto- und Brutto-Pärchen storniert werden. 
--						  Gibt bei Erfolg die Gruppierung der STO-Brutto-Belege zurück
-- ===================================================================================================
CREATE PROCEDURE [dbo].[spKbBuchung_Storno]
(
	@KbBuchungID INT,
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
	IF @KbBuchungID IS NULL BEGIN
		RAISERROR ('Der Aufruf-Parameter @KbBuchungID ist null!', 18, 1)
		RETURN -1
	END

	IF @UserID IS NULL BEGIN
		RAISERROR ('Der Aufruf-Parameter @UserID ist null!', 18, 1)
		RETURN -1
	END

	-- Return-Wert bei erfolgreichem Storno. Ist Null bei Fehler, oder wenn es nichts zu tun gab
	SET @StornoGruppierung = NULL

	-- Temporäre Tabelle mit allen verwandten Nettobelegen
	DECLARE @NettoBelege table (
		KbBuchungID			int,
		KbBuchungStatusCode int,
		TransferDatum		datetime,
		StornoKbBuchungID	int,
		StornoBelegNr		bigint,
		StornoDatum			dateTime)

	DECLARE @BruttoBelege table (
		KbBuchungBruttoID	int,
		Belegart			varchar(4))

	DECLARE @StornoBruttoBelege table (
		KbBuchungBruttoID	int)

	DECLARE @Count int
	DECLARE @StornoKbBuchungID int
	DECLARE @StornoBelegNr bigint
	DECLARE @errorMsg varchar(200)

	-- Hole alle verwandten Nettobuchungen (bei mehreren Auszahlwegen resp. Valutadaten) 
	-- ---------------------------------------------------------------------------------
	INSERT INTO @NettoBelege (	KbBuchungID,		KbBuchungStatusCode,		TransferDatum,			StornoKbBuchungID,		StornoBelegNr,		StornoDatum)
		SELECT DISTINCT			KBU.KbBuchungID,	KBU.KbBuchungStatusCode,	KBU.TransferDatum,		KBS.StornoKbBuchungID,	KBS.StornoBelegNr,	KBS.StornoDatum
		  FROM dbo.KbBuchung KBU WITH (READUNCOMMITTED)
			LEFT JOIN dbo.KbBuchungStorno		 KBS  WITH (READUNCOMMITTED)	ON KBS.KbBuchungID		= KBU.KbBuchungID
			-- Prüfe, ob es schon eine Storno-Buchung gibt für diesen Netto-Beleg
			LEFT JOIN dbo.KbBuchung				KBUSTO WITH (READUNCOMMITTED) ON KBUSTO.StorniertKbBuchungID = KBU.KbBuchungID
		WHERE KBU.KbBuchungID IN (SELECT * FROM dbo.fnGetAllDependendNettoBelegIDs(@KbBuchungID))
			AND KBUSTO.KbBuchungID IS NULL AND KBU.KbBuchungStatusCode <> 8 -- Selektiere nur die Netto-Belege, die nicht schon storniert sind, und bei denen es noch keine Stornobuchung gibt

	-- Kontrolle, ob es überhaupt noch was zu tun gibt hier
	-- ----------------------------------------------------
	SELECT @Count = COUNT(BUC.KbBuchungID)
	FROM @NettoBelege BUC

	IF @Count = 0 BEGIN
		-- Es gibt keine Netto-Belege mehr, die storniert werden müssten => Raus hier, wir sind fertig
		RETURN 0
	END

	-- Hole alle verwandten Bruttobuchungen für alle gefundenen Nettobelege
	-- -------------------------------------------------------------------
	INSERT INTO @BruttoBelege (	KbBuchungBruttoID,		Belegart)
		SELECT DISTINCT			KBB.KbBuchungBruttoID,	KBB.Belegart
			FROM @NettoBelege KBU
				INNER JOIN dbo.KbBuchungKostenart    KBK WITH (READUNCOMMITTED) ON KBK.KbBuchungID       = KBU.KbBuchungID
				INNER JOIN dbo.KbBuchungBruttoPerson KBP WITH (READUNCOMMITTED) ON KBP.BgPositionID      = KBK.BgPositionID
				INNER JOIN dbo.KbBuchungBrutto       KBB WITH (READUNCOMMITTED) ON KBB.KbBuchungBruttoID = KBP.KbBuchungBruttoID
				-- Prüfe, ob es schon eine Storno-Buchung gibt für diesen Brutto-Beleg
				LEFT JOIN dbo.KbBuchungBrutto		 KBBSTO WITH (READUNCOMMITTED) ON KBBSTO.StorniertKbBuchungBruttoID = KBB.KbBuchungBruttoID
			WHERE KBBSTO.KbBuchungBruttoID IS NULL AND KBB.KbBuchungStatusCode <> 8	-- Selektiere nur die Brutto-Belege, die nicht schon storniert sind, und bei denen es noch keine Stornobuchung gibt


	-- Kontrolle Buchungsstaus (Netto- und Bruttobelege)
	-- --------------------------------------------------
	EXECUTE dbo.spKbBuchung_StornoCheck @KbBuchungID	-- Diese Funktion wirft eine Exception wenn ein Beleg (alle abhängigen Netto- und Brutto-Belege) nicht mehr stornierbar wären

	-- Kontrolle, ob für alle transferierten Nettobuchungen eine PSCD-Beleg-Nummer erstellt wurde
	-- ---------------------------------------------------------------------------
	SELECT @Count = COUNT(BUC.KbBuchungID)
	FROM @NettoBelege BUC
	WHERE TransferDatum IS NOT NULL AND StornoBelegNr IS NULL

	IF @Count > 0 BEGIN
		SET @errorMsg = 'Storno vom bereits transferierten Nettobeleg ' + CONVERT(varchar, @KbBuchungID) + ' fehlgeschlagen, weil keine PSCD-Storno-Belegnummer in der Tabelle KbBuchungStorno gefunden wurde für diesen (oder für einen abhängigen) Netto-Beleg!'
		RAISERROR (@errorMsg, 18, 1)
		RETURN -1
	END

	-- Starte die Inserts 
	BEGIN TRY

		-- Netto-Storno erstellen (für die noch nicht stornierten Netto-Belege)
		-- --------------------------------------------------------------------
		DECLARE @cvar_KbBuchungID		int
		DECLARE @cvar_StornoBelegNr	bigint
		DECLARE @cvar_StornoDatum	datetime
		DECLARE @KbBuchungID_new	    int

		DECLARE cNetto CURSOR FAST_FORWARD FOR
			SELECT KbBuchungID, StornoBelegNr, StornoDatum
			FROM @NettoBelege
			WHERE StornoKbBuchungID IS NULL	-- Selektiere nur die Netto-Belege, die noch nicht storniert sind

		OPEN cNetto
		WHILE 1=1 BEGIN
			FETCH NEXT FROM cNetto INTO @cvar_KbBuchungID, @cvar_StornoBelegNr, @cvar_StornoDatum
			IF @@FETCH_STATUS <> 0 BREAK

			INSERT INTO KbBuchung (
				KbPeriodeID, FaLeistungID, IkPositionID, KbBuchungTypCode, Code,
				BelegDatum, Betrag,
				KbZahlungseingangID,
				BaZahlungswegID, KbAuszahlungsArtCode, PCKontoNr, BaBankID, BankKontoNr,
				IBAN, ReferenzNummer, Zahlungsgrund,
				MitteilungZeile1, MitteilungZeile2, MitteilungZeile3, MitteilungZeile4,
				BeguenstigtName, BeguenstigtName2, BeguenstigtStrasse, BeguenstigtHausNr,
				BeguenstigtPostfach, BeguenstigtOrt, BeguenstigtPLZ, BeguenstigtLandCode,
				BgBudgetID, BarbelegUserID, BarbelegDatum, CashOrCheckAm, PscdZahlwegArt,
				Schuldner_BaInstitutionID, Schuldner_BaPersonID, ModulID,
				KbForderungIstSH, Kostenstelle, BankName, BankStrasse, BankPLZ, BankOrt, BankBCN,
				IkForderungArtCode,
				-- speziell geänderte Felder
				ValutaDatum,
				TransferDatum, 
				PscdFehlermeldung,
				BelegNr, 
				SollKtoNr, HabenKtoNr,
				ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum,
				StorniertKbBuchungID, KbBuchungStatusCode,
				[Text] )
			SELECT
				KbPeriodeID, FaLeistungID, IkPositionID, KbBuchungTypCode, Code,
				BelegDatum, Betrag,
				KbZahlungseingangID,
				BaZahlungswegID, KbAuszahlungsArtCode, PCKontoNr, BaBankID, BankKontoNr,
				IBAN, ReferenzNummer, Zahlungsgrund,
				MitteilungZeile1, MitteilungZeile2, MitteilungZeile3, MitteilungZeile4,
				BeguenstigtName, BeguenstigtName2, BeguenstigtStrasse, BeguenstigtHausNr,
				BeguenstigtPostfach, BeguenstigtOrt, BeguenstigtPLZ, BeguenstigtLandCode,
				BgBudgetID, BarbelegUserID, BarbelegDatum, CashOrCheckAm, PscdZahlwegArt,
				Schuldner_BaInstitutionID, Schuldner_BaPersonID, ModulID,
				KbForderungIstSH, Kostenstelle, BankName, BankStrasse, BankPLZ, BankOrt, BankBCN,
				IkForderungArtCode,
				-- speziell geänderte Felder
				CONVERT(DateTime, dbo.fnMAX(@MinimumStornoDatum, ValutaDatum)),	-- Das Storno Datum darf nicht älter sein als @MinimumStornoDatum
				CASE WHEN [TransferDatum] IS NULL THEN NULL ELSE GetDate() END, -- Falls das Original-TransferDatum definiert ist, wird das aktuelle Tagesdatum als TransferDatum des STO-Belegs verwendet, sonst Null.
				NULL,	
				@cvar_StornoBelegNr, 
				HabenKtoNr, SollKtoNr, -- Konti vertauscht
				@UserID, GetDate(), @UserID, GetDate(),
				@cvar_KbBuchungID, 8, -- 8 = storniert,
				'STO ' + CONVERT(varchar, COALESCE(BelegNr, @cvar_KbBuchungID)) + ' ' + [Text]
			FROM dbo.KbBuchung WITH (READUNCOMMITTED)
			WHERE KbBuchungID = @cvar_KbBuchungID


			SELECT @KbBuchungID_new = SCOPE_IDENTITY()	-- ID der neuen STO-Netto-Buchung

			-- Update der Tabelle KbBuchungStorno mit MinimumStornoDatum, UserID und Sto-Netto-Buchung
			UPDATE dbo.KbBuchungStorno					-- Speichere die ID der Storno-Netto-Buchung auch in der Storno-Tabelle (zusammen mit User und Datum)
			SET StornoUserID = @UserID, StornoDatum = @MinimumStornoDatum, StornoKbBuchungID = @KbBuchungID_new
			WHERE KbBuchungID = @cvar_KbBuchungID

			-- Personenbezogene Netto-Stornos erstellen (KbBuchungKostenart)
			-- -------------------------------------------------------------
			INSERT INTO KbBuchungKostenart (
				KbBuchungID, BgPositionID, BgKostenartID, BaPersonID,
				Betrag, KontoNr, PositionImBeleg, Hauptvorgang, Teilvorgang, Belegart,
				VerwPeriodeVon, VerwPeriodeBis,
				-- speziell geänderte Felder
				Buchungstext
				)
			SELECT
				@KbBuchungID_new, KOA.BgPositionID, KOA.BgKostenartID, KOA.BaPersonID,
				KOA.Betrag, KOA.KontoNr, KOA.PositionImBeleg, KOA.Hauptvorgang, KOA.Teilvorgang, KOA.Belegart,
				KOA.VerwPeriodeVon, KOA.VerwPeriodeBis,
				-- speziell geänderte Felder
				'STO ' + CONVERT(varchar, COALESCE(BUC.BelegNr, @cvar_KbBuchungID)) + ' ' + KOA.Buchungstext
			FROM dbo.KbBuchungKostenart KOA
				INNER JOIN KbBuchung BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = KOA.KbBuchungID
			WHERE KOA.KbBuchungID = @cvar_KbBuchungID

		END	-- WHILE 1=1
		CLOSE cNetto
		DEALLOCATE cNetto

		-- Update des Buchungsstatus der Netto-Buchungen
		UPDATE KbBuchung
		SET KbBuchungStatusCode = 8
		WHERE KbBuchungID IN (SELECT KbBuchungID FROM @NettoBelege)

		-- Brutto-Storno erstellen
		--------------------------
		SELECT @Count = Count(KbBuchungBruttoID)
		FROM @BruttoBelege

		IF @Count > 0 BEGIN
			-- Es gibt mind. eine Brutto-Buchung
			DECLARE @cvar_KbBuchungBruttoID	int
			DECLARE @cvar_BelegArt varchar(4)
			DECLARE @KbBuchungBruttoID_new int

			DECLARE cBrutto CURSOR FAST_FORWARD FOR
				SELECT KbBuchungBruttoID, Belegart
				FROM   @BruttoBelege

			-- Neue Gruppierungs-Nummer lösen
			DECLARE @GruppierungNr bigint
			DECLARE @Temp varchar(8)

			SET @GruppierungNr = NULL
			EXEC dbo.spKbGetBelegNr_out 'PYGRP', @GruppierungNr OUT
			SET @Temp = CONVERT(varchar, @GruppierungNr)
			SET @StornoGruppierung = 'S' + SubString('00000000', 1, 8-LEN(@Temp)) + @Temp

			-- Iteriere über alle Brutto-Buchungen und erstelle je eine Storno-Buchung
			OPEN cBrutto
			WHILE 1=1 BEGIN
				FETCH NEXT FROM cBrutto INTO @cvar_KbBuchungBruttoID, @cvar_BelegArt
				IF @@FETCH_STATUS <> 0 BREAK

				--Kopf einfügen mit umgekehrtem Betrag
				INSERT INTO KbBuchungBrutto (
							[KbPeriodeID], [BgKostenartID], [KbBuchungTypCode], [Code], [BelegDatum], [Zahlungsfrist],
							[BetragEffektiv], [DatumEffektiv], [BgBudgetID], [ModulID], 
							[Kostenstelle], [Hauptvorgang], [Teilvorgang], [Belegart], [FaLeistungID], BgSplittingArtCode, Weiterverrechenbar, Quoting, Abgetreten,
							-- Geänderte Felder
							[BelegNr], 
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
							[Kostenstelle], [Hauptvorgang], [Teilvorgang], [Belegart], [FaLeistungID], BgSplittingArtCode, Weiterverrechenbar, Quoting, Abgetreten,
							-- Geänderte Felder
							CASE WHEN [TransferDatum] IS NULL THEN NULL ELSE BelegNr END, -- Falls das Original-TransferDatum definiert ist kopieren wir hier die PSCD Beleg-Nummer. Das Feld wird im KiSS-Server verwendet, um den übermittelten Original-Beleg zu stornieren. Die STO-Belegnummer wird dann hier abgelegt
							CASE WHEN [TransferDatum] IS NULL THEN NULL ELSE GetDate() END, -- Falls das Original-TransferDatum definiert ist, wird das aktuelle Tagesdatum als TransferDatum des STO-Belegs verwendet, sonst Null.
							CONVERT(DateTime, dbo.fnMAX(@MinimumStornoDatum, ValutaDatum)),
							NULL,
							@UserID, GetDate(),
							-Betrag,	-- negativer Betrag
							@cvar_KbBuchungBruttoID,
							8, -- 8 = Storniert
							'STO ' + CONVERT(varchar, COALESCE(BelegNr, @cvar_KbBuchungBruttoID)) + ' ' + [Text],
							@StornoGruppierung,
							'U'
				  FROM KbBuchungBrutto
				  WHERE KbBuchungBruttoID = @cvar_KbBuchungBruttoID

				-- Neue STO-Brutto-Beleg-ID holen
				SELECT @KbBuchungBruttoID_new = SCOPE_IDENTITY()

				-- Und Speichere die neue Brutto-Beleg-ID (wir geben am Schluss die Liste aller erstellen Brutto-Beleg-IDs zurück)
				INSERT INTO @StornoBruttoBelege (KbBuchungBruttoID)
				VALUES (@KbBuchungBruttoID_new)

				-- Update der Storno-Gruppierung und des Status = Storno beim Original-Bruttobeleg
				UPDATE KbBuchungBrutto
					SET GruppierungUmbuchung = @StornoGruppierung,
					KbBuchungStatusCode = 8
				WHERE KbBuchungBruttoID = @cvar_KbBuchungBruttoID

				-- Detailpositionen einfügen
				INSERT INTO KbBuchungBruttoPerson (
							[BgPositionID], [BaPersonID], [Schuldner_BaInstitutionID], [Schuldner_BaPersonID], [VerwPeriodeVon], [VerwPeriodeBis], [PositionImBeleg], [GesperrtFuerWV],
							-- Geänderte Felder:
							[Buchungstext],
							[KbBuchungBruttoID],
							[Betrag]
						)
					SELECT 	KBP.BgPositionID, KBP.BaPersonID, KBP.Schuldner_BaInstitutionID, KBP.Schuldner_BaPersonID, KBP.VerwPeriodeVon, KBP.VerwPeriodeBis, KBP.PositionImBeleg, KBP.GesperrtFuerWV,
							-- Geänderte Felder:
							'STO ' + CONVERT(varchar, COALESCE(KBB.BelegNr, @cvar_KbBuchungBruttoID)) + ' ' + KBP.Buchungstext,
							@KbBuchungBruttoID_new,
							-KBP.Betrag		-- negativer Betrag
					FROM KbBuchungBruttoPerson KBP WITH (READUNCOMMITTED)
						INNER JOIN KbBuchungBrutto KBB WITH (READUNCOMMITTED) ON KBB.KbBuchungBruttoID = KBP.KbBuchungBruttoID
					WHERE KBP.KbBuchungBruttoID = @cvar_KbBuchungBruttoID

			END	-- WHILE 1=1
			CLOSE cBrutto
			DEALLOCATE cBrutto

		END -- IF @Count > 0 

	END TRY
	BEGIN CATCH
		SET @errormsg = ERROR_MESSAGE()
		--ROLLBACK
		RAISERROR(@errormsg,18,1)
	END CATCH
END


-- Debugging

--Begin tran	
--	DECLARE @datum DATETIME
--	DECLARE @StornoGruppierung as varchar(10)
--	set @datum = CONVERT(DATETIME, '2008-02-20')
--
--	INSERT INTO KbBuchungStorno
--	(KbBuchungID, StornoBelegNr, StornierungVermerktUserID, StornierungVermerktDatum)
--	Values (534798, 1, -1, @datum)
--
--	INSERT INTO KbBuchungStorno
--	(KbBuchungID, StornoBelegNr, StornierungVermerktUserID, StornierungVermerktDatum)
--	Values (534799, 2, -1, @datum)
--
--	INSERT INTO KbBuchungStorno
--	(KbBuchungID, StornoBelegNr, StornierungVermerktUserID, StornierungVermerktDatum)
--	Values (534800, 3, -1, @datum)
--
--	INSERT INTO KbBuchungStorno
--	(KbBuchungID, StornoBelegNr, StornierungVermerktUserID, StornierungVermerktDatum)
--	Values (534801, 4, -1, @datum)
--
--	EXEC spKbBuchung_Storno 534798, -1, @datum, @StornoGruppierung OUTPUT
--	Select @StornoGruppierung
--	
--	-- Zeige alle erstellen Brutto-Buchungen an (anhand der StornoGruppierung)
--	SELECT KBU.*, PscdVertragsgegenstandID = LEI.PscdVertragsgegenstandID, 
--	  BaPersonID_LT = LEI.BaPersonID,
--	  UntPersonenImHaushalt = (select count(*) from BgBudget BDG, BgFinanzplan_BaPerson FPP where BDG.BgBudgetID = KBU.BgBudgetID AND BDG.BgFinanzplanID = FPP.BgFinanzplanID AND FPP.IstUnterstuetzt = 1)
--	FROM KbBuchungBrutto     KBU
--	  LEFT JOIN BgBudget     BUD ON BUD.BgBudgetID     = KBU.BgBudgetID
--	  LEFT JOIN BgFinanzplan FIP ON FIP.BgFinanzplanID = BUD.BgFinanzplanID
--	  LEFT JOIN FaLeistung   LEI ON LEI.FaLeistungID   = IsNull(FIP.FaLeistungID,KBU.FaLeistungID)
--	WHERE KBU.GruppierungUmbuchung = @StornoGruppierung
--
--	-- Führe die SP nochmals aus für alle Netto-Belege, um zu schauen, ob die SP auch richtig reagiert und keine neuen Buchungen mehr erstellt
--	EXEC spKbBuchung_Storno 534799, -1, @datum, @StornoGruppierung OUTPUT
--	Select @StornoGruppierung
--	EXEC spKbBuchung_Storno 534800, -1, @datum, @StornoGruppierung OUTPUT
--	Select @StornoGruppierung
--	EXEC spKbBuchung_Storno 534801, -1, @datum, @StornoGruppierung OUTPUT
--	Select @StornoGruppierung
--
--	-- Zeige alle Brutto-Buchungen inkl. Details 
--	SELECT Distinct KBB.*, KBP.*
--	  FROM dbo.KbBuchung KBU1 WITH (READUNCOMMITTED) 
--		INNER JOIN dbo.KbBuchungKostenart    KBK1 WITH (READUNCOMMITTED) ON KBK1.KbBuchungID      = KBU1.KbBuchungID
--		INNER JOIN dbo.KbBuchungKostenart    KBK2 WITH (READUNCOMMITTED) ON KBK2.BgPositionID      = KBK1.BgPositionID
--		INNER JOIN dbo.KbBuchung             KBU2 WITH (READUNCOMMITTED) ON KBU2.KbBuchungID       = KBK2.KbBuchungID 
--		INNER JOIN dbo.KbBuchungStorno		 STO  WITH (READUNCOMMITTED) ON STO.StornoKbBuchungID = KBU1.KbBuchungID
--
--		INNER JOIN dbo.KbBuchungKostenart    KBK  WITH (READUNCOMMITTED) ON KBK.KbBuchungID      = KBU2.KbBuchungID
--		INNER JOIN dbo.KbBuchungBruttoPerson KBP  WITH (READUNCOMMITTED) ON KBP.BgPositionID      = KBK.BgPositionID
--		INNER JOIN dbo.KbBuchungBrutto       KBB  WITH (READUNCOMMITTED) ON KBB.KbBuchungBruttoID       = KBP.KbBuchungBruttoID 
--	  WHERE KBU2.KbBuchungID = 534800
--
--	select * from KbBuchungStorno
--
--rollback
