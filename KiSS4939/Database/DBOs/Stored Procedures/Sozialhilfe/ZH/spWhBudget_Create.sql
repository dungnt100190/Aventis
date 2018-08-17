SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_Create
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhBudget_Create.sql $
  $Author: Mminder $
  $Modtime: 2.09.10 14:41 $
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
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spWhBudget_Create.sql $
 * 
 * 4     24.09.10 17:35 Mminder
 * #???? Enddatumsberechnung Abzahlungskonto verbessert
 * 
 * 3     11.12.09 11:58 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 17:58 Rstahel
 * Abgleich der Stored Procedures aus KISS4_MASTER_ZH
=================================================================================================*/

CREATE PROCEDURE [dbo].[spWhBudget_Create]
 (@BgFinanzplanID   int,
  @BgBudgetID       int = NULL)
AS BEGIN
  DECLARE @BgBudget_Copy       int,
          @DatumVon_SFP        datetime,
          @DatumBis_SFP        datetime,
          @DateMonatsbudget    datetime,
          @MonatsDifferenz     int,
          @BgBewilligungStatusCode int

  -- Get Masterbudget
  SELECT TOP 1
    @BgBudget_Copy        = BBG.BgBudgetID,
    @DatumVon_SFP         = SFP.DatumVon,
    @DatumBis_SFP         = SFP.DatumBis,
    @DateMonatsbudget     = dbo.fnFirstDayOf(SFP.DatumVon),
    @BgBewilligungStatusCode = SFP.BgBewilligungStatusCode
  FROM dbo.BgFinanzplan      SFP
    LEFT OUTER JOIN dbo.BgBudget  BBG ON BBG.BgFinanzplanID = SFP.BgFinanzplanID AND BBG.MasterBudget = 1
  WHERE SFP.BgFinanzplanID = @BgFinanzplanID

  IF @BgBewilligungStatusCode IS NULL OR @BgBewilligungStatusCode <> 5 /*bewilligt*/  BEGIN
    RETURN
  END

  IF EXISTS (SELECT BgBudgetID FROM dbo.BgBudget WITH (REPEATABLEREAD) WHERE BgFinanzplanID = @BgFinanzplanID AND BgBudgetID = @BgBudgetID) BEGIN
    SELECT @DateMonatsbudget = dbo.fnDateSerial(Jahr, Monat, 1) FROM dbo.BgBudget WHERE BgBudgetID = @BgBudgetID
  END ELSE BEGIN
    -- Find Next Monatsbudget
    WHILE EXISTS (SELECT BgBudgetID FROM dbo.BgBudget WITH (SERIALIZABLE)
                  WHERE BgFinanzplanID = @BgFinanzplanID AND MasterBudget = 0
                    AND Jahr = Year(@DateMonatsbudget) AND Monat = month(@DateMonatsbudget)
    ) BEGIN
      SET @DateMonatsbudget = DateAdd(m, 1, @DateMonatsbudget)
    END

    -- Check Datum Next Monatsbudget
    IF @DateMonatsbudget > @DatumBis_SFP BEGIN
      RETURN
    END ELSE BEGIN
      -- BgBudget (Masterbutget)
      INSERT INTO BgBudget (MasterBudget, BgBewilligungStatusCode, BgFinanzplanID, Jahr, Monat)
        VALUES (0, 1, @BgFinanzplanID, Year(@DateMonatsbudget), MONTH(@DateMonatsbudget))

      SET @BgBudgetID = @@IDENTITY
    END
  END

  SET @MonatsDifferenz = DateDiff(m,@DatumVon_SFP,@DateMonatsbudget)

  IF EXISTS (SELECT BgBudgetID FROM dbo.BgBudget WITH (REPEATABLEREAD) WHERE BgBudgetID = @BgBudgetID AND MasterBudget = 0 AND BgBewilligungStatusCode < 5) BEGIN

    DECLARE @BgPositionID int
    DECLARE @BgAuszahlungPersonID int
    DECLARE @BgAuszahlungsTerminCode int
    DECLARE @BgWochentagCodes varchar(20)
    DECLARE @NewBgPositionID int
    DECLARE @NewBgAuszahlungPersonID int
    DECLARE @NewVerwPeriodeVon datetime
    DECLARE @NewVerwPeriodeBis datetime
    DECLARE @WhereClause varchar(200)

    DECLARE cPosition CURSOR STATIC FOR
    SELECT BgPositionID
    FROM   dbo.BgPosition BPO
           LEFT OUTER JOIN dbo.WhPositionsart  BPT ON BPT.BgPositionsartID = BPO.BgPositionsartID
    WHERE BgBudgetID = @BgBudget_Copy AND
          IsNull(BPO.DatumVon, '19000101') < IsNull(BPO.DatumBis, '99991231') AND
          (BPO.Betrag > $0.00 OR (BPT.Monatsbudget_EditMask & 0x6 != 0)) AND
          (BPO.BgKategorieCode <> 2 OR BPO.BgBewilligungStatusCode = 5) AND
          (IsNull(BPO.DatumVon, '19000101') < dbo.fnLastDayOf(@DateMonatsbudget) AND
           IsNull(BPO.DatumBis, '99991231') > dbo.fnFirstDayOf(@DateMonatsbudget))

    OPEN cPosition
    FETCH NEXT FROM cPosition INTO @BgPositionID
    WHILE @@FETCH_STATUS = 0 BEGIN
      SET @NewVerwPeriodeVon = dbo.fnDateSerial(CONVERT(varchar, Year(@DateMonatsbudget)),CONVERT(varchar, MONTH(@DateMonatsbudget)),1)
      SET @NewVerwPeriodeBis = dbo.fnLastDayOf(@NewVerwPeriodeVon)

      -- BgPosition
      SET @WhereClause = 'BgPositionID = ' + CONVERT(varchar,@BgPositionID)

      EXEC spDuplicateRows 'BgPosition',@WhereClause,
                           'BgBudgetID',@BgBudgetID,
                           'BgPositionID_CopyOf',@BgPositionID,
                           'BgPositionID_Parent', 'null'

      SET @NewBgPositionID = @@IDENTITY

      UPDATE BgPosition
      SET    VerwPeriodeVon          = @NewVerwPeriodeVon,
             VerwPeriodeBis          = @NewVerwPeriodeBis,
             BgBewilligungStatusCode = 1,
             FaelligAm               = DateAdd(m,@MonatsDifferenz,FaelligAm)
      WHERE  BgPositionID = @NewBgPositionID

      DECLARE cAuszahlung CURSOR STATIC FOR
      SELECT BgAuszahlungPersonID, BgAuszahlungsTerminCode, BgWochentagCodes
      FROM   dbo.BgAuszahlungPerson WITH (READUNCOMMITTED)
      WHERE  BgPositionID = @BgPositionID

      OPEN cAuszahlung
      FETCH NEXT FROM cAuszahlung INTO @BgAuszahlungPersonID, @BgAuszahlungsTerminCode, @BgWochentagCodes
      WHILE @@FETCH_STATUS = 0 BEGIN

        -- BgAuszahlungPerson
        SET @WhereClause = 'BgAuszahlungPersonID = ' + CONVERT(varchar,@BgAuszahlungPersonID)
        EXEC spDuplicateRows 'BgAuszahlungPerson',@WhereClause,'BgPositionID',@NewBgPositionID

        SET @NewBgAuszahlungPersonID = @@IDENTITY

        -- BgAuszahlungPersonTermin
        IF @BgAuszahlungsTerminCode in (1,2,3,5) BEGIN
          -- monatlich, 2 x monatlich, wöchentlich, 14-täglich
          INSERT BgAuszahlungPersonTermin (BgAuszahlungPersonID,Datum)
          SELECT @NewBgAuszahlungPersonID, T.Datum
          FROM   fnKbAuszahlTermine(Year(@DateMonatsbudget),Month(@DateMonatsbudget)) T
          WHERE  T.BgAuszahlungsTerminCode = @BgAuszahlungsTerminCode
        END ELSE IF @BgAuszahlungsTerminCode = 4 BEGIN
          -- Valuta
          INSERT BgAuszahlungPersonTermin (BgAuszahlungPersonID,Datum)
          SELECT TOP 1 @NewBgAuszahlungPersonID, DateAdd(m,@MonatsDifferenz,Datum)
          FROM   dbo.BgAuszahlungPersonTermin WITH (READUNCOMMITTED)
          WHERE  BgAuszahlungPersonID = @BgAuszahlungPersonID
        END ELSE IF @BgAuszahlungsTerminCode = 6 BEGIN
          -- Wochentage
          INSERT BgAuszahlungPersonTermin (BgAuszahlungPersonID,Datum)
          SELECT @NewBgAuszahlungPersonID, T.Datum
          FROM   fnKbAuszahlTermine(Year(@DateMonatsbudget),Month(@DateMonatsbudget)) T
          WHERE  T.BgAuszahlungsTerminCode = @BgAuszahlungsTerminCode AND
                 @BgWochentagCodes like '%' + CONVERT(varchar,T.BgWochentagCode) + '%'
        END

        FETCH NEXT FROM cAuszahlung INTO @BgAuszahlungPersonID, @BgAuszahlungsTerminCode, @BgWochentagCodes
      END
      CLOSE cAuszahlung
      DEALLOCATE cAuszahlung

      FETCH NEXT FROM cPosition INTO @BgPositionID
    END
    CLOSE cPosition
    DEALLOCATE cPosition

    -- adjust BgPositionID_Parent
    UPDATE BPO
    SET    BgPositionID_Parent = BPO4.BgPositionID
    FROM   dbo.BgPosition BPO                                 -- start 
           INNER JOIN dbo.BgPosition BPO2 ON BPO2.BgPositionID = BPO.BgPositionID_CopyOf   -- Masterbudget-Position
           INNER JOIN dbo.BgPosition BPO3 ON BPO3.BgPositionID = BPO2.BgPositionID_Parent  -- Parent innerhalb Masterbudget
           INNER JOIN dbo.BgPosition BPO4 ON BPO4.BgPositionID_CopyOf = BPO3.BgPositionID  -- neues Child im neuen Monatsbudget
    WHERE  BPO.BgBudgetID = @BgBudgetID AND BPO4.BgBudgetID = @BgBudgetID

    -- Update Budget
    EXECUTE spWhBudget_Update @BgBudgetID

    -- Spezialkonto
    -- Fügt eine Verrechnungsposition ins neue Budget UND aktualisiert die nachfolgenden; Verrechnungen könnten durch das neu erstellte Budget überflüssig geworden sein
    DECLARE @BgBudgetID_Cursor INT
    DECLARE cAbzahlungskonto CURSOR LOCAL STATIC FOR
      SELECT BBG_ZUK.BgBudgetID
      FROM BgBudget         BBG_NEU
        INNER JOIN BgBudget BBG_ZUK ON BBG_ZUK.BgFinanzplanID = BBG_NEU.BgFinanzplanID AND
                                       dbo.fnDateSerial(BBG_ZUK.Jahr, BBG_ZUK.Monat, 1) >= dbo.fnDateSerial(BBG_NEU.Jahr, BBG_NEU.Monat, 1)
      WHERE BBG_NEU.BgBudgetID = @BgBudgetID AND
            BBG_ZUK.MasterBudget = 0 AND
            BBG_ZUK.BgBewilligungStatusCode < 5
      ORDER BY dbo.fnDateSerial(BBG_ZUK.Jahr, BBG_ZUK.Monat, 1)

    OPEN cAbzahlungskonto
    WHILE 1 = 1 BEGIN
      FETCH NEXT FROM cAbzahlungskonto INTO @BgBudgetID_Cursor
      IF @@FETCH_STATUS != 0 BREAK
      EXECUTE spWhBudget_Abzahlungskonto @BgBudgetID_Cursor
    END
    CLOSE cAbzahlungskonto
    DEALLOCATE cAbzahlungskonto
  END

  -- Output
  SELECT BgBudgetID = @BgBudgetID
END

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
