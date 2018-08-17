SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAyFinanzplan_Delete
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spAyFinanzplan_Delete.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:33 $
  $Revision: 2 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spAyFinanzplan_Delete.sql $
 * 
 * 2     25.06.09 11:40 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spAyFinanzplan_Delete
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:53
*/
CREATE PROCEDURE dbo.spAyFinanzplan_Delete
 (@BgFinanzPlanID     int)
AS BEGIN
  IF EXISTS ( SELECT *
    FROM BgBudget           BBG
      INNER JOIN KbBuchung  FLB ON FLB.BgBudgetID = BBG.BgBudgetID
    WHERE BBG.BgFinanzPlanID = @BgFinanzPlanID
      AND FLB.KbBuchungStatusCode NOT IN (10)
  ) BEGIN
    RAISERROR('Das Masterbudget kann nicht gelöscht werden: mindestens ein Monatsbudget enthält verbuchte Belege', 18, 1)
    RETURN -1
  END

  DECLARE @BgBudgetID  int

  DECLARE cur_Budget CURSOR FAST_FORWARD FOR
    SELECT BgBudgetID
    FROM dbo.BgBudget WITH (READUNCOMMITTED) 
    WHERE BgFinanzPlanID = @BgFinanzPlanID

  OPEN cur_Budget

  FETCH NEXT FROM cur_Budget INTO @BgBudgetID
  WHILE @@FETCH_STATUS = 0 BEGIN
    EXECUTE dbo.spAyBudget_Delete @BgBudgetID
    DELETE BgBudget WHERE BgBudgetID = @BgBudgetID

    FETCH NEXT FROM cur_Budget INTO @BgBudgetID
  END
  CLOSE cur_Budget
  DEALLOCATE cur_Budget
END
GO