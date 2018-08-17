SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBFSBudget
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Sostat/fnBFSBudget.sql $
  $Author: Tabegglen $
  $Modtime: 19.08.10 10:31 $
  $Revision: 5 $
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
  $Log: /KiSS4/Database/DBOs/Functions/Sostat/fnBFSBudget.sql $
 * 
 * 5     19.08.10 11:00 Tabegglen
 * #3978 Migration BgPositionsartID -> BgPositionsartCode. Viele Einträge
 * in BFSFrage haben im Feld HerkunftSQL Vergleichsoperationen auf
 * BgPositionsartID,
 * welche eigentlich auf BgPositionsartCode erfolgen sollten. 
 * - Anpassung fnBFSBudget + fnBFSMonatsBelege, so dass sie
 * BgPositionsartCode ebenfalls zurückgeben.
 * - Anpassung HerkunftSQL, so dass BgPositionsartCode für die
 * Vergleichsoperationen verwendet wird.
 * 
 * 4     24.06.09 16:16 Ckaeser
 * Alter2Create
 * 
 * 3     11.02.09 16:27 Lgreulich
 * 
 * 2     10.02.09 16:49 Ckaeser
 * 
 * 1     30.10.08 13:13 dmast
=================================================================================================*/
CREATE FUNCTION dbo.fnBFSBudget
 (@FaLeistungID  int,
  @Jahr          int,
  @MasterBudget  bit = 0)
  RETURNS @BgPosition TABLE (
    BgBudgetID         int NOT NULL,
    BgPositionID       int NOT NULL,
    BgKategorieCode    int NOT NULL,
    BgGruppeCode       int NULL,
    BgPositionsartID   int NULL,
    BgPositionsartCode int NULL, 
    BaPersonID         int NULL,
    Betrag             decimal NOT NULL,
    VarName            varchar(10)
  )
AS BEGIN
  DECLARE @BgBudgetID  int,
          @Datum       datetime
          
  IF @MasterBudget = 1 BEGIN
    SELECT TOP 1
      @BgBudgetID = BBG.BgBudgetID,
      @Datum      = CONVERT(datetime, dbo.fnMin(BFP.DatumBis, dbo.fnDateSerial(@Jahr, 12, 31)))
    FROM dbo.BgFinanzplan      BFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgBudget  BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = BFP.BgFinanzplanID
                                                         AND BBG.MasterBudget = 1
                                                         AND BBG.BgBewilligungStatusCode = 5 /* bewilligt */
    WHERE BFP.FaLeistungID = @FaLeistungID
      AND BFP.DatumVon < dbo.fnDateSerial(@Jahr, 12, 31)
    ORDER BY BFP.DatumVon DESC
  END ELSE BEGIN
    SELECT TOP 1
      @BgBudgetID = BBG.BgBudgetID,
      @Datum      = CASE WHEN BBG.MasterBudget = 1
                      THEN CONVERT(datetime, dbo.fnMin(BFP.DatumBis, dbo.fnDateSerial(@Jahr, 12, 31)))
                      ELSE dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 15)
                    END
    FROM dbo.BgFinanzplan      BFP WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgBudget  BBG WITH (READUNCOMMITTED) ON BBG.BgFinanzplanID = BFP.BgFinanzplanID
                                                         AND BBG.BgBewilligungStatusCode = 5 /* bewilligt */
                                                         AND BBG.Jahr <= @Jahr
    WHERE BFP.FaLeistungID = @FaLeistungID
      AND BFP.DatumVon < dbo.fnDateSerial(@Jahr, 12, 31)
    ORDER BY BFP.DatumVon DESC, CONVERT(int, BBG.MasterBudget), BBG.Jahr DESC, BBG.Monat DESC
  END

  INSERT INTO @BgPosition
    SELECT BPO.BgBudgetID, BPO.BgPositionID, BPO.BgKategorieCode, BPA.BgGruppeCode,
      BPO.BgPositionsartID, BPA.BgPositionsartCode, BPO.BaPersonID, BPO.BetragFinanzplan, BPA.VarName
    FROM dbo.vwBgPosition            BPO WITH (READUNCOMMITTED)
      INNER JOIN dbo.BgPositionsart  BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = BPO.BgPositionsartID
    WHERE BPO.BgBudgetID = @BgBudgetID
      AND IsNull(BPO.DatumVon, '19000101') < IsNull(BPO.DatumBis, '99991231')
      AND (IsNull(BPO.DatumVon, '19000101') < dbo.fnLastDayOf(@Datum)
            AND IsNull(BPO.DatumBis, '99991231') > dbo.fnFirstDayOf(@Datum))

  RETURN
END
GO