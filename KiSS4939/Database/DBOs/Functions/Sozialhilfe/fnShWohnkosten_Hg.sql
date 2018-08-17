SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE dbo.spDropObject fnShWohnkosten_Hg
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnShWohnkosten_Hg.sql $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnShWohnkosten_Hg.sql $
 * 
 * 2     25.06.09 8:14 Ckaeser
 * Alter2Create
 * 
 * 1     16.12.08 14:32 Ckaeser
 * 
 * 1     10.09.08 12:25 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnShWohnkosten_Hg
 (@BgFinanzPlanID   int,
  @RefDate          datetime)
 RETURNS money
AS
BEGIN

  RETURN (SELECT Betrag = dbo.fnShWohnkosten_Person(KZ.HgGrundbedarf, IsNull(@RefDate, KZ.RefDate))
          FROM   dbo.fnWhKennzahlen(@BgFinanzPlanID) KZ)
END
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

