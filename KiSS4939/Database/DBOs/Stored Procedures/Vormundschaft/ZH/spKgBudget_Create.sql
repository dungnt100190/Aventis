SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgBudget_Create
GO
/*===============================================================================================
  $Revision: 8 $
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
CREATE PROCEDURE dbo.spKgBudget_Create
 (
  @MasterBudgetID   int,
  @UserID int
  )
AS BEGIN
  DECLARE @BewilligtVon            datetime,
          @BewilligtBis            datetime,
          @DateMonatsbudget        datetime,
          @MonatsDifferenz         int,
          @FaLeistungID            int,
          @KgBudgetID              int,
          @KgPositionID            int


  -- Get Masterbudget dates
  SELECT @BewilligtVon     = BewilligtVon,
         @BewilligtBis     = BewilligtBis,
         @DateMonatsbudget = dbo.fnFirstDayOf(BewilligtVon),
         @FaLeistungID     = FaLeistungID
  FROM dbo.KgBudget WITH (READUNCOMMITTED)
  WHERE KgBudgetID = @MasterBudgetID

  -- Find Next Monatsbudget
  WHILE EXISTS (SELECT * FROM dbo.KgBudget WITH (READUNCOMMITTED)
                WHERE KgMasterBudgetID = @MasterBudgetID AND
                      Jahr  = Year(@DateMonatsbudget) AND
                      Monat = month(@DateMonatsbudget)
  ) BEGIN
    SET @DateMonatsbudget = DateAdd(m, 1, @DateMonatsbudget)
  END

  -- Check Datum Next Monatsbudget
  IF @DateMonatsbudget > @BewilligtBis BEGIN
     SELECT KgBudgetID = NULL, Error = 'Es sind bereits alle Monatsbudgets im bewilligten Zeitraum erzeugt!'
     RETURN
  END

  SET @MonatsDifferenz = DateDiff(m,@BewilligtVon,@DateMonatsbudget)

  -- Check KgZahlungslaufValuta
  IF NOT EXISTS (SELECT 1
                 FROM   dbo.KgZahlungslaufValuta  WITH (READUNCOMMITTED)
                 WHERE  Jahr = Year(@DateMonatsbudget) AND Monat = Month(@DateMonatsbudget) AND
                        DatMonatlich IS NOT NULL AND
                        DatTeil1 IS NOT NULL AND
                        DatTeil2 IS NOT NULL AND
                        Dat14Tage1 IS NOT NULL AND
                        Dat14Tage2 IS NOT NULL AND
                        DatWoche1 IS NOT NULL AND
                        DatWoche2 IS NOT NULL AND
                        DatWoche3 IS NOT NULL AND
                        DatWoche4 IS NOT NULL)
  BEGIN
     SELECT KgBudgetID = NULL, Error = 'Es sind keine korrekten Auszahlungs-Valuta für den Monat ' +
                                       CONVERT(varchar,Month(@DateMonatsbudget)) + '/' +
                                       CONVERT(varchar,Year(@DateMonatsbudget)) + ' vorhanden!'
     RETURN
  END

  -- KgBudget 
  INSERT INTO KgBudget (FaLeistungID, KgMasterBudgetID, KgBewilligungCode, Jahr, Monat)
    VALUES (@FaLeistungID, @MasterBudgetID, 1,Year(@DateMonatsbudget), Month(@DateMonatsbudget))

  SET @KgBudgetID = @@IDENTITY

  --KgPosition
  DECLARE C CURSOR FOR
  SELECT KgPositionID 
  FROM KgPosition
  WHERE KgBudgetID = @MasterBudgetID
	   AND KgBewilligungCode = 5	-- Nur bewilligte Masterbudget-Positionen
	   AND IsNull(DatumBis, @DateMonatsbudget) >=@DateMonatsbudget	-- Nur Positionen, die nicht terminiert sind oder immer noch gültig sind im neuen Budget
	   AND IsNull(DatumVon, @DateMonatsbudget) <=@DateMonatsbudget

  OPEN C
  FETCH NEXT FROM C INTO @KgPositionID
  WHILE @@fetch_status = 0 BEGIN
	  EXEC spKgBudget_CreatePosition @KgPositionID, @KgBudgetID, @UserID  -- Kreiere neue Monatsbudget-Position
    FETCH NEXT FROM C INTO @KgPositionID
  END
  CLOSE C
  DEALLOCATE C

  SELECT KgBudgetID = @KgBudgetID, Error = ''
END
