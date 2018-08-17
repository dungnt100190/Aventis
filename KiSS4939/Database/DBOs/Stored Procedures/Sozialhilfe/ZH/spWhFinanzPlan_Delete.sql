SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhFinanzPlan_Delete
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

CREATE PROCEDURE dbo.spWhFinanzPlan_Delete
(
  @BgFinanzplanID     int
)
AS BEGIN
  IF EXISTS (
    SELECT *
    FROM dbo.BgBudget                 BBG WITH (READUNCOMMITTED) 
      LEFT  JOIN dbo.KbBuchung        NET WITH (READUNCOMMITTED) ON NET.BgBudgetID = BBG.BgBudgetID AND NET.KbBuchungStatusCode NOT IN (1, 2, 7)
      LEFT  JOIN dbo.KbBuchungBrutto  BRT WITH (READUNCOMMITTED) ON BRT.BgBudgetID = BBG.BgBudgetID AND BRT.KbBuchungStatusCode NOT IN (1, 2, 7)
    WHERE BBG.BgFinanzplanID = @BgFinanzplanID
      AND (NET.BgBudgetID IS NOT NULL OR BRT.BgBudgetID IS NOT NULL)
  )
  BEGIN
    RAISERROR('Der Finanzplan kann nicht gelöscht werden: mindestens ein Monatsbudget enthält verbuchte Belege', 18, 1)
    RETURN -1
  END

  DECLARE @BgBudgetID  int

  DECLARE cur_Budget CURSOR FAST_FORWARD FOR
    SELECT BgBudgetID
    FROM dbo.BgBudget WITH (READUNCOMMITTED) 
    WHERE BgFinanzplanID = @BgFinanzplanID
    ORDER BY MasterBudget DESC

  OPEN cur_Budget

  
  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM cur_Budget INTO @BgBudgetID
    IF @@FETCH_STATUS < 0 BREAK

    EXECUTE dbo.spWhBudget_Delete @BgBudgetID
    IF EXISTS (SELECT * FROM dbo.BgPosition WHERE BgBudgetID = @BgBudgetID) BREAK
    DELETE BgBudget WHERE BgBudgetID = @BgBudgetID
  END
  CLOSE cur_Budget
  DEALLOCATE cur_Budget
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
