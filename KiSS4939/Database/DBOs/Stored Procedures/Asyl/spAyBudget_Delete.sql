SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAyBudget_Delete
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spAyBudget_Delete.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:35 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spAyBudget_Delete.sql $
 * 
 * 2     25.06.09 11:42 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spAyBudget_Delete
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:53
*/
CREATE PROCEDURE dbo.spAyBudget_Delete
 (@BgBudgetID   int)
AS BEGIN
  IF EXISTS (SELECT * FROM BgBudget WHERE BgBudgetID = @BgBudgetID AND MasterBudget = 1 AND BgBewilligungStatusCode >= 5) BEGIN
    RAISERROR('Das Masterbudget kann nicht geändert werden', 18, 1)
    RETURN -1
  END

  DECLARE @BudgetMonat  varchar(100)
  SELECT @BudgetMonat = dbo.fnXMonatJahr(dbo.fnDateSerial(Jahr, IsNull(Monat, 1), 1))
  FROM BgBudget WHERE BgBudgetID = @BgBudgetID

  IF EXISTS (SELECT * FROM BgBudget WHERE BgBudgetID = @BgBudgetID AND MasterBudget = 0 AND BgBewilligungStatusCode >= 5) BEGIN
    RAISERROR('Das Monatsbudget ''%s'' kann nicht geändert werden, es ist zur Zahlung freigegeben', 18, 1, @BudgetMonat)
    RETURN -1
  END

  IF EXISTS (SELECT *
             FROM KbBuchung
             WHERE BgBudgetID = @BgBudgetID
               AND KbBuchungStatusCode NOT IN (1, 2, 7)
  ) BEGIN
    RAISERROR('Das Monatsbudget ''%s'' kann nicht gelöscht werden, es enthält verbuchte Belege', 18, 1, @BudgetMonat)
    RETURN -1
  END

  -- KbBuchung / KbBuchungKostenart
  DELETE KBK
  FROM KbBuchung                   BUC
    INNER JOIN KbBuchungKostenart  KBK ON KBK.KbBuchungID = BUC.KbBuchungID
  WHERE BUC.BgBudgetID = @BgBudgetID

  DELETE FROM KbBuchung
  WHERE BgBudgetID = @BgBudgetID

  -- BgPosition
  DELETE FROM BgPosition
  WHERE BgBudgetID = @BgBudgetID
END
GO