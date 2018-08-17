SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spZGetIDs
GO
/*===============================================================================================
  $Revision: 5 $
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

CREATE  PROCEDURE dbo.spZGetIDs
AS
SELECT BaPersonID = IDENT_CURRENT('BaPerson'), round(IDENT_CURRENT('BaPerson'),-2) + 100
SELECT BaInstitutionID = IDENT_CURRENT('BaInstitution'), round(IDENT_CURRENT('BaInstitution'),-2) + 100
SELECT KgBuchungID = IDENT_CURRENT('KgBuchung'), round(IDENT_CURRENT('KgBuchung'),-2) + 100

SELECT KeyName, CASE WHEN NextID = FirstID THEN NextID ELSE round(NextID,-2) + 100 END, NextID
FROM PscdKeySource

SELECT
  CNF.KeyPath,
  ValueVar = dbo.fnXConfig(CNF.KeyPath, GETDATE())
FROM dbo.XConfig CNF WITH(READUNCOMMITTED)
WHERE KeyPath LIKE 'System\Schnittstellen\%';
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
