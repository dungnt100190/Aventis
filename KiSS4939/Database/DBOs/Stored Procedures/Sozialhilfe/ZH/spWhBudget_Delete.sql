SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_Delete
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

CREATE PROCEDURE dbo.spWhBudget_Delete
 (@BgBudgetID   int)
AS BEGIN
  IF EXISTS (SELECT BgBudgetID FROM dbo.BgBudget WITH (READUNCOMMITTED) WHERE BgBudgetID = @BgBudgetID AND MasterBudget = 1 AND BgBewilligungStatusCode >= 5) BEGIN
    RAISERROR('Das Masterbudget kann nicht gelöscht werden', 18, 1)
    RETURN -1
  END

  DECLARE @BudgetMonat  varchar(100)
  SELECT @BudgetMonat = dbo.fnXMonatJahr(dbo.fnDateSerial(Jahr, IsNull(Monat, 1), 1))
  FROM BgBudget WHERE BgBudgetID = @BgBudgetID

  IF EXISTS (SELECT BgBudgetID FROM dbo.BgBudget WITH (READUNCOMMITTED) WHERE BgBudgetID = @BgBudgetID AND MasterBudget = 0 AND BgBewilligungStatusCode >= 5) BEGIN
    RAISERROR('Das Monatsbudget ''%s'' kann nicht gelöscht/zurückgesetzt werden, es ist zur Zahlung freigegeben', 18, 1, @BudgetMonat)
    RETURN -1
  END

  IF EXISTS (
    SELECT *
    FROM dbo.BgBudget                 BBG WITH (READUNCOMMITTED) 
      LEFT OUTER JOIN dbo.KbBuchung        NET WITH (READUNCOMMITTED) ON NET.BgBudgetID = BBG.BgBudgetID AND NET.KbBuchungStatusCode NOT IN (1, 2, 7)
      LEFT OUTER JOIN dbo.KbBuchungBrutto  BRT WITH (READUNCOMMITTED) ON BRT.BgBudgetID = BBG.BgBudgetID AND BRT.KbBuchungStatusCode NOT IN (1, 2, 7)
    WHERE BBG.BgBudgetID = @BgBudgetID
      AND (NET.BgBudgetID IS NOT NULL OR BRT.BgBudgetID IS NOT NULL)
  ) BEGIN
    RAISERROR('Das Monatsbudget ''%s'' kann nicht gelöscht/zurückgesetzt werden, es enthält verbuchte Belege', 18, 1, @BudgetMonat)
    RETURN -1
  END

  -- KbBuchung
  DELETE FROM dbo.KbBuchung        WHERE BgBudgetID = @BgBudgetID
  DELETE FROM dbo.KbBuchungBrutto  WHERE BgBudgetID = @BgBudgetID

  -- BgPosition
  DELETE FROM dbo.BgPosition       WHERE BgBudgetID = @BgBudgetID
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
