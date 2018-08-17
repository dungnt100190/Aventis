SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnGetPersonSichtbarFlag
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnGetPersonSichtbarFlag.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 15:58 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnGetPersonSichtbarFlag.sql $
 * 
 * 2     24.06.09 16:19 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: fnGetPersonSichtbarFlag
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:57
*/
CREATE FUNCTION dbo.fnGetPersonSichtbarFlag
 (@LogonName varchar(15))
 RETURNS INT
AS 

BEGIN
  DECLARE @IsPersonSichtbarSD INT
  DECLARE @IsUserKA INT

  SELECT @IsPersonSichtbarSD = CASE WHEN ORG.ModulID = 7 THEN 0 ELSE 1 END
  FROM dbo.XUser USR WITH (READUNCOMMITTED) 
	LEFT  JOIN dbo.XOrgUnit_User  ORU WITH (READUNCOMMITTED) ON ORU.UserID    = USR.UserID AND ORU.OrgUnitMemberCode = 2
	LEFT  JOIN dbo.XOrgUnit       ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = ORU.OrgUnitID
  WHERE USR.LogonName = @LogonName

  RETURN (@IsPersonSichtbarSD)
END
GO