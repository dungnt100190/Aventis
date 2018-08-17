SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spWhBudget_Runden
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Stored Procedures/Sozialhilfe/spWhBudget_Runden.sql $
  $Author: Tabegglen $
  $Modtime: 6.09.10 10:28 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Rundet die Positionen eines Budgets auf 0.05 Beträge.
    @BgBudgetID   Das zu rundende Budget.
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Stored Procedures/Sozialhilfe/spWhBudget_Runden.sql $
 * 
 * 1     6.09.10 10:58 Tabegglen
 * #6411 neue SP, die das Budget rundet.
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spWhBudget_Runden
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:55
*/
CREATE PROCEDURE dbo.spWhBudget_Runden
 (@BgBudgetID        int)
AS BEGIN
  UPDATE BPO
    SET
      Betrag       = Round(Betrag               * 2, 1) / 2,
      Reduktion    = Round((Reduktion - 0.0001) * 2, 1) / 2,
      Abzug        = Round((Abzug - 0.0001)     * 2, 1) / 2,
      MaxBeitragSD = Round(MaxBeitragSD         * 2, 1) / 2
  FROM BgPosition  BPO
  WHERE BPO.BgBudgetID = @BgBudgetID
    AND (Betrag       != (Round(Betrag               * 2, 1) / 2)
      OR Reduktion    != (Round((Reduktion - 0.0001) * 2, 1) / 2)
      OR Abzug        != (Round((Abzug - 0.0001)     * 2, 1) / 2)
      OR MaxBeitragSD != (Round(MaxBeitragSD         * 2, 1) / 2))
END
GO