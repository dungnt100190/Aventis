SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgBudget_CreatePosition
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
  Erstellt eine neue Position im angegebenen Monatsbudget aufgrund der angegebenen Masterbudget-Position
  Falls das Monatsbudget grün ist, wird auch die neu erstellte Position grün gestellt.
  Falls das Monatsbudget gesperrt ist, wird auch die neu erstellte Position gesperrt gestellt.
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
CREATE PROCEDURE dbo.spKgBudget_CreatePosition
(
  @KgPositionID int,  -- Masterbudget-Position, die in das Monatsbudget @KgBudgetID kopiert werden soll
  @KgBudgetID   int, 
  @UserID int   
)
AS BEGIN

  DECLARE @NewKgPositionID         int,
          @KgAuszahlungsTerminCode int,
          @KgWochentagCodes        varchar(200),
          @AnzahlValuta            int,
          @MasterBudgetID          int,
          @DateMonatsbudget        datetime,
          @BewilligtVon            datetime,
          @MonatsDifferenz         int,
          @BudgetBewilligungCode   int

  DECLARE @ValutaTermine table (
    KgAuszahlungsTerminCode int,
    Datum                   datetime)
  
  SELECT @MasterBudgetID = POS.KgBudgetID, 
         @KgAuszahlungsTerminCode = POS.KgAuszahlungsTerminCode, 
         @KgWochentagCodes = POS.KgWochentagCodes,
         @BewilligtVon = ISNULL(convert(datetime,dbo.fnMax(POS.DatumVon,BDG.BewilligtVon)), BDG.BewilligtVon)
  FROM   dbo.KgPosition POS WITH (READUNCOMMITTED) 
         inner join KgBudget BDG on BDG.KgBudgetID = POS.KgBudgetID
  WHERE  KgPositionID = @KgPositionID 

  SELECT @DateMonatsbudget = dbo.fnDateSerial(Jahr, Monat, 1), 
         @BudgetBewilligungCode = KgBewilligungCode 
  FROM   dbo.KgBudget WITH (READUNCOMMITTED) 
  WHERE  KgBudgetID = @KgBudgetID
  
  SET @MonatsDifferenz = DateDiff(m,@BewilligtVon,@DateMonatsbudget)

	INSERT KgPosition
	  (KgBudgetID,KgPositionsKategorieCode,MasterbudgetPositionID,KontoNr,Buchungstext,Betrag,
	   Bemerkung,BuchungDatum,BaInstitutionID,
	   KgAuszahlungsArtCode,KgAuszahlungsTerminCode,KgWochentagCodes,BaZahlungswegID,ReferenzNummer,
	   MitteilungZeile1,MitteilungZeile2,MitteilungZeile3,MitteilungZeile4,
	   ErstelltUserID,ErstelltDatum,MutiertUserID,MutiertDatum, DatumVon, DatumBis)
	SELECT
	   @KgBudgetID,POS.KgPositionsKategorieCode,POS.KgPositionID,POS.KontoNr,POS.Buchungstext,POS.Betrag,
	   POS.Bemerkung,
	   BuchungDatum = dbo.fnDateSerial(Year(@DateMonatsbudget),Month(@DateMonatsbudget),Day(BuchungDatum)),
	   POS.BaInstitutionID,
	   POS.KgAuszahlungsArtCode,POS.KgAuszahlungsTerminCode,POS.KgWochentagCodes,POS.BaZahlungswegID,POS.ReferenzNummer,
	   POS.MitteilungZeile1,POS.MitteilungZeile2,POS.MitteilungZeile3,POS.MitteilungZeile4,
	   ErstelltUserID = IsNull(POS.ErstelltUserID,LEI.UserID),
	   ErstelltDatum  = GetDate(),
	   MutiertUserID  = IsNull(POS.MutiertUserID,LEI.UserID),
	   MutiertDatum   = GetDate(),
	   DatumVon       = POS.DatumVon,
	   DatumBis       = POS.DatumBis
	FROM dbo.KgPosition POS WITH (READUNCOMMITTED)
	   INNER JOIN dbo.KgBudget   BDG WITH (READUNCOMMITTED) on BDG.KgBudgetID = POS.KgBudgetID
	   INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) on LEI.FaLeistungID = BDG.FaLeistungID
	WHERE KgPositionID = @KgPositionID

	SET @NewKgPositionID = @@identity

	-- KgPositionValuta
	IF @KgAuszahlungsTerminCode in (1,2,3,5) BEGIN
	  -- monatlich, 2 x monatlich, wöchentlich, 14-täglich
	  INSERT KgPositionValuta (KgPositionID,Datum)
	  SELECT @NewKgPositionID, T.Datum
	  FROM   fnKgAuszahlTermine(Year(@DateMonatsbudget),Month(@DateMonatsbudget)) T
	  WHERE  T.KgAuszahlungsTerminCode = @KgAuszahlungsTerminCode
	END ELSE IF @KgAuszahlungsTerminCode = 4 BEGIN
	  -- Valuta
	  INSERT KgPositionValuta (KgPositionID,Datum)
	  SELECT TOP 1 @NewKgPositionID, DateAdd(m,@MonatsDifferenz,Datum)
	  FROM   dbo.KgPositionValuta WITH (READUNCOMMITTED)
	  WHERE  KgPositionID = @KgPositionID
	END ELSE IF @KgAuszahlungsTerminCode = 6 BEGIN
	  -- Wochentage
	  INSERT KgPositionValuta (KgPositionID,Datum)
	  SELECT @NewKgPositionID, T.Datum
	  FROM   fnKgAuszahlTermine(Year(@DateMonatsbudget),Month(@DateMonatsbudget)) T
	  WHERE  T.KgAuszahlungsTerminCode = @KgAuszahlungsTerminCode AND
			 @KgWochentagCodes like '%' + CONVERT(varchar,T.KgWochentagCode) + '%'
	END
	-- individuell: keine Einträge

	-- Auszahlungstermin wöchentlich, 14-täglich oder Wochentage: eventuell Monatsbetrag an Anzahl Valutatermine anpassen
	IF @KgAuszahlungsTerminCode in (3,5,6) BEGIN
	  SELECT @AnzahlValuta = COUNT(*) FROM KgPositionValuta WHERE KgPositionID = @NewKgPositionID

	  IF @KgAuszahlungsTerminCode = 3 AND @AnzahlValuta = 5 -- wöchentlich mit 5 Valutaterminen
		  UPDATE KgPosition
		  SET    Betrag = Betrag * 5 / 4
		  WHERE  KgPositionID = @NewKgPositionID

	  IF @KgAuszahlungsTerminCode = 5 AND @AnzahlValuta = 3 -- 14-täglich mit 3 Valutaterminen
		  UPDATE KgPosition
		  SET    Betrag = Betrag * 3 / 2
		  WHERE  KgPositionID = @NewKgPositionID

	  IF @KgAuszahlungsTerminCode = 6 BEGIN -- Wochentage mit 5 Valutaterminen
		  DECLARE @AnzahlWochentage INT

		  SELECT @AnzahlWochentage = COUNT(*)
		  FROM   dbo.XLOVCode WITH (READUNCOMMITTED)
		  WHERE  LOVName = 'KgWochentag' AND
			     CHARINDEX(CONVERT(varchar,Code),@KgWochentagCodes) > 0

		  IF @AnzahlValuta <> (@AnzahlWochentage * 4)
		    UPDATE KgPosition
		    SET    Betrag = Betrag * @AnzahlValuta / (@AnzahlWochentage * 4)
		    WHERE  KgPositionID = @NewKgPositionID
	  END
	END
	
	-- Prüfe den aktuellen Status
	IF @BudgetBewilligungCode = 5 OR @BudgetBewilligungCode = 9 BEGIN
	  -- Budget ist bewilligt oder beendet (resp. gesperrt), d.h. wir müssen die Buchung zur Position erstellen. 
	  -- Die Prozedur stellt sicher, dass die Buchung gesperrt wird, falls das Budget gesperrt ist
	  EXEC spKgBudget_KgBuchung_Create @KgBudgetID, @NewKgPositionID,  @UserID, 1  
  END
END
