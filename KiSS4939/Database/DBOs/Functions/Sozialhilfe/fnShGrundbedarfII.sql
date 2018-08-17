SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE dbo.spDropObject fnShGrundbedarfII
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnShGrundbedarfII.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 16:03 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnShGrundbedarfII.sql $
 * 
 * 2     25.06.09 8:14 Ckaeser
 * Alter2Create
 * 
 * 1     16.12.08 14:28 Ckaeser
 * 
 * 1     10.09.08 12:25 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnShGrundbedarfII
 (@BgFinanzPlanID   int,
  @WGemeinschaft    bit = 1)
 RETURNS money
AS
BEGIN

  RETURN (SELECT Betrag = CASE WHEN @WGemeinschaft = 1
                          THEN CASE WHEN KZ.GBUseHgUeFactor = 1
                               THEN KZ.GBHgUeFactor * dbo.fnShGrundbedarfII_Person(KZ.HgGrundbedarf, KZ.RefDate)
                               ELSE dbo.fnShGrundbedarfII_Person(KZ.UeGrundbedarf, KZ.RefDate)
                               END
                          ELSE dbo.fnShGrundbedarfII_Person(1, KZ.RefDate) * KZ.UeGrundbedarf
                          END
          FROM   dbo.fnWhKennzahlen(@BgFinanzPlanID) KZ)
END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

