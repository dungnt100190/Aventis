SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE dbo.spDropObject fnShGrundbedarfIZuschlag
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnShGrundbedarfIZuschlag.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 16:04 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnShGrundbedarfIZuschlag.sql $
 * 
 * 2     25.06.09 8:14 Ckaeser
 * Alter2Create
 * 
 * 1     16.12.08 14:29 Ckaeser
 * 
 * 1     10.09.08 12:25 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnShGrundbedarfIZuschlag
 (@BgFinanzPlanID   int)
 RETURNS money
AS
BEGIN

  RETURN (SELECT Betrag = CASE WHEN KZ.GBUseHgUeFactor = 1
                          THEN KZ.HgZuschlagI * KZ.GBHgUeFactor * KZ.B23Amount
                          ELSE KZ.UeZuschlagI * KZ.B23Amount
                          END
          FROM   dbo.fnWhKennzahlen(@BgFinanzPlanID) KZ)
END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

