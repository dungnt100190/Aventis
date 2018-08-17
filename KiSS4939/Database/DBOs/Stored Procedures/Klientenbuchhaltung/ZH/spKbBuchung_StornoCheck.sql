SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spKbBuchung_StornoCheck;
GO
/*===============================================================================================
  $Revision: 12 $
=================================================================================================
  Description:	Diese Methode holt alle Netto- und Brutto-Belege und prüft via deren Status, 
				ob alle Belege noch stornierbar sind
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE [dbo].[spKbBuchung_StornoCheck]
(
	@KbBuchungID INT
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON

	DECLARE @msg varchar(200)

	-- Temporäre Tabelle mit allen verwandten Nettobelegen
	DECLARE @NettoBelege table (
		KbBuchungID int,
		KbBuchungStatusCode int,
		Betrag money)

	DECLARE @BruttoBelege table (
		KbBuchungBruttoID int,
		KbBuchungStatusCode int,
		Betrag money)

	-- Hole alle verwandten Nettobuchungen (bei mehrerne Auszahlwegen resp. Valutadaten) 
	INSERT INTO @NettoBelege (	KbBuchungID,		KbBuchungStatusCode,		Betrag)
		SELECT DISTINCT			KBU.KbBuchungID,	KBU.KbBuchungStatusCode,	KBU.Betrag
		  FROM dbo.KbBuchung KBU WITH (READUNCOMMITTED)
		WHERE KBU.KbBuchungID IN (SELECT * FROM dbo.fnGetAllDependendNettoBelegIDs(@KbBuchungID))

	-- Prüfe, ob alle noch stornierbar sind
	DECLARE @Count int

	SELECT @Count = count(KbBuchungID)
	FROM @NettoBelege
	WHERE KbBuchungStatusCode NOT in (1, 2, 3, 4, 7, 8, 9)	-- Nicht grau, grün, übertragen, ausgedruckt, gesperrt, bereits storniert oder Rückläufer

	IF @Count > 0 BEGIN
		SET @msg = 'Damit der Netto-Beleg ' + CONVERT(varchar, @KbBuchungID) + ' storniert werden kann, müssen auch die abhängigen Nettobelege storniert werden. Diese sind aber bereits (teil-)ausgeglichen und daher nicht mehr stornierbar.'

		RAISERROR (@msg, 18, 1)
		RETURN -1
	END

	-- Prüfe, falls ein Netto-Beleg ein Barbeleg ist, dass er nicht erst gedruckt wurde, d.h. noch gültig ist und allenfalls schon eingelöst worden ist
	SELECT @Count = count(BUC.KbBuchungID) FROM KBBuchung BUC
	INNER JOIN @NettoBelege BUC2 ON BUC2.KbBuchungID = BUC.KbBuchungID
	WHERE IsNull(BarbelegDatum, '1900-01-01') > DateAdd(day, -14, GetDate())  -- Der Barbeleg wurde in den letzten 14 Tagen gedruckt, d.h. potentiell ist der Barbeleg bereits ausgezahlt, aber noch nicht verbucht

	IF @Count > 0 BEGIN
		SET @msg = 'Der Barbeleg ' + CONVERT(varchar, @KbBuchungID) + ' kann nicht storniert werden, da der Barbeleg in den letzten 14 Tagen gedruckt und ev. schon eingelöst, aber noch nicht verbucht wurde. Versuchen Sie es in ein paar Tagen nochmals.'

		RAISERROR (@msg, 18, 1)
		RETURN -1
	END

	-- Hole alle verwandten Bruttobuchungen für alle gefundenen Nettobelege
	INSERT INTO @BruttoBelege (	KbBuchungBruttoID,		KbBuchungStatusCode,		Betrag)
		SELECT DISTINCT			KBB.KbBuchungBruttoID,	KBB.KbBuchungStatusCode,	KBB.Betrag
			FROM @NettoBelege KBU
				INNER JOIN dbo.KbBuchungKostenart    KBK WITH (READUNCOMMITTED) ON KBK.KbBuchungID       = KBU.KbBuchungID
				INNER JOIN dbo.KbBuchungBruttoPerson KBP WITH (READUNCOMMITTED) ON KBP.BgPositionID      = KBK.BgPositionID
				INNER JOIN dbo.KbBuchungBrutto       KBB WITH (READUNCOMMITTED) ON KBB.KbBuchungBruttoID = KBP.KbBuchungBruttoID
		WHERE KBB.StorniertKbBuchungBruttoID IS NULL AND KBB.NeuBuchungVonKbBuchungBruttoID IS NULL

	-- Prüfe, ob alle noch stornierbar sind
	SELECT @Count = count(KbBuchungBruttoID)
	FROM @BruttoBelege
	WHERE KbBuchungStatusCode NOT in (1, 2, 3, 4, 7, 8)	-- Nicht grau, grün, übertragen, ausgedruckt, gesperrt oder bereits storniert

	IF @Count > 0 BEGIN
		SET @msg = 'Damit der Netto-Beleg ' + CONVERT(varchar, @KbBuchungID) + ' storniert werden kann, müssen auch die abhängigen Bruttobelege storniert werden. Diese sind aber bereits (teil-)ausgeglichen und daher nicht mehr stornierbar.'

		RAISERROR (@msg, 18, 1)
		RETURN -1
	END
	

	-- Prüfe, ob die Summen Netto und Brutto übereinstimmen (Vorzeichen ist Glückssache, daher lassen wir das mal raus, die Chance ist verschwindend klein, das dies ein Problem ist)
	DECLARE @SumNetto money
	DECLARE @SumBrutto money

	SELECT @SumNetto = sum(Betrag)
	FROM @NettoBelege

	SELECT @SumBrutto = sum(Betrag)
	FROM @BruttoBelege

	IF abs(@SumBrutto) <> abs(@SumNetto) BEGIN
		SET @msg = 'Der Netto-Beleg ' + CONVERT(varchar, @KbBuchungID) + ' kann nicht storniert werden, weil die Summe aller Netto-Belege (= ' + CONVERT(varchar, abs(@SumNetto)) + ') nicht der Summe aller abhängigen Brutto-Belege (' + CONVERT(varchar, abs(@SumBrutto)) + ') entspricht.'

		RAISERROR (@msg, 18, 1)
		RETURN -1		
	END

	RETURN 0
END
GO