SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAyBudget_Abzahlungskonto
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spAyBudget_Abzahlungskonto.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:35 $
  $Revision: 3 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spAyBudget_Abzahlungskonto.sql $
 * 
 * 3     25.06.09 11:42 Ckaeser
 * Alter2Create
 * 
 * 2     4.11.08 18:44 dmast
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spAyBudget_Abzahlungskonto
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:53
*/
CREATE PROCEDURE dbo.spAyBudget_Abzahlungskonto
 (@BgBudgetID     int,
  @BgSpezkontoID  int = NULL)
AS BEGIN
  DECLARE @FaLeistungID  int,
          @DatumBudget   datetime

  SELECT
    @FaLeistungID = SFP.FaLeistungID,
    @DatumBudget  = dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1)
  FROM dbo.BgBudget              BBG WITH (READUNCOMMITTED) 
    INNER JOIN dbo.BgFinanzplan  SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
  WHERE BBG.BgBudgetID = @BgBudgetID AND BBG.MasterBudget = 0 AND BBG.BgBewilligungStatusCode < 5

  IF @FaLeistungID IS NULL RETURN

  -- Abzahlungskonto
  DECLARE @BetragProMonat   money,
          @SpezKontoSaldo   money,
          @BudgetBetrag     money,
          @DatumVon         datetime,
          @DatumBis         datetime

  DECLARE cAbzahlungen CURSOR FAST_FORWARD FOR
    SELECT
      SSK.BgSpezkontoID,
      SSK.BetragProMonat,
      dbo.fnBgSpezkonto(SSK.BgSpezkontoID, 3, @BgBudgetID, default),
      BPO.BetragRechnung,
      SSK.DatumVon,
      SSK.DatumBis
    FROM dbo.BgSpezkonto          SSK WITH (READUNCOMMITTED) 
      LEFT JOIN dbo.vwBgPosition  BPO ON BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode = 3
                                 AND BPO.BgSpezkontoID = SSK.BgSpezkontoID
    WHERE SSK.FaLeistungID = @FaLeistungID
      AND SSK.BgSpezkontoID = IsNull(@BgSpezkontoID, SSK.BgSpezkontoID)
      AND SSK.BgSpezkontoTypCode = 3
      AND SSK.DatumVon <= @DatumBudget

  OPEN cAbzahlungen
  WHILE (1 = 1) BEGIN
  FETCH NEXT FROM cAbzahlungen INTO @BgSpezkontoID, @BetragProMonat, @SpezKontoSaldo, @BudgetBetrag, @DatumVon, @DatumBis
    IF @@FETCH_STATUS < 0 BREAK

    IF @DatumBudget BETWEEN @DatumVon AND IsNull(@DatumBis, @DatumBudget) BEGIN
      DECLARE @Betrag  money
      SET @Betrag = CONVERT(money, dbo.fnMIN(@SpezKontoSaldo + IsNull(@BudgetBetrag, $0.00), @BetragProMonat))

      IF @Betrag <= 0 BEGIN
        DELETE FROM BgPosition WHERE BgBudgetID = @BgBudgetID AND BgKategorieCode = 3 AND BgSpezkontoID = @BgSpezkontoID

      END ELSE IF @BudgetBetrag IS NULL BEGIN
        INSERT INTO BgPosition (BgBudgetID, BgKategorieCode, BgSpezkontoID, Betrag)
          SELECT @BgBudgetID, 3, @BgSpezkontoID, @Betrag
      END ELSE BEGIN
        UPDATE BPO
          SET
            Betrag = @Betrag
        FROM BgPosition           BPO
        WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode = 3
          AND BPO.BgSpezkontoID = @BgSpezkontoID
      END
    END ELSE BEGIN
        -- inaktiv
      DELETE BPO
      FROM BgPosition           BPO
      WHERE BPO.BgBudgetID = @BgBudgetID AND BPO.BgKategorieCode = 3
        AND BPO.BgSpezkontoID = @BgSpezkontoID
    END
  END

  CLOSE cAbzahlungen
  DEALLOCATE cAbzahlungen
END
GO