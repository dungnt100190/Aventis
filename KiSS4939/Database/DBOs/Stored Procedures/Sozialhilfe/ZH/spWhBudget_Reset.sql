SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_Reset
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
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spWhBudget_Reset
(
  @BgFinanzplanID INT,
  @BgBudgetID     INT
)
AS BEGIN
  IF EXISTS (SELECT BgBudgetID
             FROM dbo.BgBudget
             WHERE BgBudgetID = @BgBudgetID
              AND MasterBudget = 1
              AND BgBewilligungStatusCode = 5)
  BEGIN  -- Masterbudget
    UPDATE BPO
      SET BgPositionID_CopyOf = MAS.BgPositionID_CopyOf
    FROM dbo.BgPosition          MAS 
      INNER JOIN dbo.BgPosition  BPO ON BPO.BgPositionID_CopyOf = MAS.BgPositionID
    WHERE MAS.BgBudgetID = @BgBudgetID
      AND MAS.DatumVon = '19000102'

    DELETE dbo.BgPosition
    WHERE BgBudgetID = @BgBudgetID AND DatumVon = '19000102'

    UPDATE dbo.BgPosition
      SET DatumBis = NULL
    WHERE BgBudgetID = @BgBudgetID AND DatumBis = '19000101'

    -- Spzialkonto
    DECLARE @BgSpezkontoID  int

    DECLARE cShSpezkonto CURSOR FAST_FORWARD LOCAL FOR
      SELECT BgSpezkontoID
      FROM dbo.BgFinanzplan        SFP
        INNER JOIN dbo.BgSpezkonto SSK ON SSK.FaLeistungID = SFP.FaLeistungID
      WHERE SFP.BgFinanzplanID = @BgFinanzplanID

    OPEN cShSpezkonto
    WHILE 1 = 1 BEGIN
      FETCH NEXT FROM cShSpezkonto INTO @BgSpezkontoID
      IF @@FETCH_STATUS != 0 BREAK

      EXECUTE spWhSpezkonto_UpdateBudget @BgSpezkontoID, @BgFinanzplanID, @BgBudgetID
    END
    CLOSE cShSpezkonto
    DEALLOCATE cShSpezkonto
  END

  IF EXISTS (SELECT BgBudgetID
             FROM dbo.BgBudget
             WHERE BgBudgetID = @BgBudgetID AND MasterBudget = 0 AND BgBewilligungStatusCode < 5)
  BEGIN  -- Monatsbudget
    DECLARE @BgPosition TABLE (
      BgPositionID int PRIMARY KEY
    )

    INSERT INTO @BgPosition
      SELECT BgPositionID
      FROM dbo.BgPosition    BPO WITH (SERIALIZABLE)
      WHERE BPO.BgBudgetID = @BgBudgetID
        AND (BgPositionID_CopyOf IS NOT NULL 
          OR BgKategorieCode = 6 -- Vorabzug
          OR BgKategorieCode = 3 AND BgPositionID_Parent IS NULL) -- Verrechnung die nicht von einer ZL kommen

    DELETE APT
    FROM @BgPosition                          TMP
      INNER JOIN dbo.BgAuszahlungPerson       BAP ON BAP.BgPositionID = TMP.BgPositionID
      INNER JOIN dbo.BgAuszahlungPersonTermin APT ON APT.BgAuszahlungPersonID = BAP.BgAuszahlungPersonID

    DELETE BAP
    FROM @BgPosition                    TMP
      INNER JOIN dbo.BgAuszahlungPerson BAP ON BAP.BgPositionID = TMP.BgPositionID

    DELETE BPO
    FROM @BgPosition            TMP
      INNER JOIN dbo.BgPosition BPO ON BPO.BgPositionID = TMP.BgPositionID

    EXECUTE spWhBudget_Create @BgFinanzplanID, @BgBudgetID
  END
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
