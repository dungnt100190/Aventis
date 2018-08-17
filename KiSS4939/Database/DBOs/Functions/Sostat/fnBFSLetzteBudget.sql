SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBFSLetzteBudget
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnBFSLetzteBudget.sql $Author: Lgreulich $
  $Modtime: 19.09.09 12:44 $
  $Revision: 1 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnBFSLetzteBudget.sql $
 * 
 * 1     19.09.09 16:01 Ckaeser
 * #5004 Übernahme/Abgleich ZH

6.5.2009 sozgns (Stéphane Grangier) Export letzte Budget

=================================================================================================*/
CREATE FUNCTION dbo.fnBFSLetzteBudget
  (@FaLeistungID  INT,
  @Jahr          INT)

  RETURNS INT
AS BEGIN

 RETURN (
   SELECT TOP 1 BUD.BgBudgetID
   FROM BgFinanzplan     BFP
     INNER JOIN BgBudget BUD ON BUD.BgFinanzplanID = BFP.BgFinanzplanID
   WHERE  FaLeistungID = @FaLeistungID AND BUD.Jahr <= @Jahr
   ORDER BY BUD.Jahr DESC, BUD.Monat DESC
   )
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
