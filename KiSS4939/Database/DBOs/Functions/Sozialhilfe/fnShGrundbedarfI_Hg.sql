SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE dbo.spDropObject fnShGrundbedarfI_Hg
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnShGrundbedarfI_Hg.sql $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnShGrundbedarfI_Hg.sql $
 * 
 * 2     24.06.09 16:23 Ckaeser
 * Alter2Create
 * 
 * 1     16.12.08 14:28 Ckaeser
 * 
 * 1     10.09.08 12:25 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnShGrundbedarfI_Hg
 (@BgFinanzPlanID   int)
 RETURNS money
AS
BEGIN

  RETURN (SELECT Betrag = dbo.fnShGrundbedarfI_Person(KZ.HgGrundbedarf, KZ.RefDate)
          FROM   dbo.fnWhKennzahlen(@BgFinanzPlanID) KZ)

END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

