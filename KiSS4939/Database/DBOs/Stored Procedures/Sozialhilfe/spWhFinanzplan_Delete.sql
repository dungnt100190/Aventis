SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhFinanzplan_Delete
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spWhFinanzplan_Delete.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:11 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spWhFinanzplan_Delete.sql $
 * 
 * 2     25.06.09 8:47 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spWhFinanzplan_Delete
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:55
*/
CREATE PROCEDURE dbo.spWhFinanzplan_Delete
 (@BgFinanzplanID     int)
AS BEGIN
  IF EXISTS (
    SELECT *
    FROM BgBudget                 BBG
      LEFT  JOIN KbBuchung        NET ON NET.BgBudgetID = BBG.BgBudgetID AND NET.KbBuchungStatusCode NOT IN (1, 2, 7)
-- BSS!      LEFT  JOIN KbBuchungBrutto  BRT ON BRT.BgBudgetID = BBG.BgBudgetID AND BRT.KbBuchungStatusCode NOT IN (1, 2, 7)
    WHERE BBG.BgFinanzplanID = @BgFinanzplanID
      AND (NET.BgBudgetID IS NOT NULL) -- BSS! OR BRT.BgBudgetID IS NOT NULL)
  ) BEGIN
    RAISERROR('Der Finanzplan kann nicht gelöscht werden: mindestens ein Monatsbudget enthält verbuchte Belege', 18, 1)
    RETURN -1
  END

  DECLARE @BgBudgetID  int

  DECLARE cur_Budget CURSOR FAST_FORWARD FOR
    SELECT BgBudgetID
    FROM BgBudget
    WHERE BgFinanzplanID = @BgFinanzplanID
    ORDER BY MasterBudget DESC

  OPEN cur_Budget


  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM cur_Budget INTO @BgBudgetID
    IF @@FETCH_STATUS < 0 BREAK

    EXECUTE dbo.spWhBudget_Delete @BgBudgetID
    IF EXISTS (SELECT * FROM BgPosition WHERE BgBudgetID = @BgBudgetID) BREAK
    DELETE BgBudget WHERE BgBudgetID = @BgBudgetID
  END
  CLOSE cur_Budget
  DEALLOCATE cur_Budget
END
GO