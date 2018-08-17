SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnOrgUnitsOfTeam
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

CREATE FUNCTION dbo.fnOrgUnitsOfTeam
(
  @OrgGruppeID int,
  @TeamID  int
)
RETURNS @OUTPUT TABLE (OrgUnitID int)
AS

BEGIN

  DECLARE @OrgGruppeFilter varchar(500)

  IF @TeamID IS NULL AND @OrgGruppeID IS NOT NULL BEGIN
    SELECT @OrgGruppeFilter = CONVERT(varchar(500),Value1) FROM XLOVCode WHERE LOVName = 'QuOrgUnitGroup' AND Code = @OrgGruppeID

    INSERT @OUTPUT (OrgUnitID)
    SELECT ORG.OrgUnitID
    FROM   dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
           LEFT JOIN dbo.XOrgUnit ORG1 WITH (READUNCOMMITTED) ON ORG1.OrgUnitID = ORG.ParentID
           LEFT JOIN dbo.XOrgUnit ORG2 WITH (READUNCOMMITTED) ON ORG2.OrgUnitID = ORG1.ParentID
           LEFT JOIN dbo.XOrgUnit ORG3 WITH (READUNCOMMITTED) ON ORG3.OrgUnitID = ORG2.ParentID
           LEFT JOIN dbo.XOrgUnit ORG4 WITH (READUNCOMMITTED) ON ORG4.OrgUnitID = ORG3.ParentID
           LEFT JOIN dbo.XOrgUnit ORG5 WITH (READUNCOMMITTED) ON ORG5.OrgUnitID = ORG4.ParentID,
           (SELECT Code
            FROM   dbo.XLOVCode
            WHERE  LOVName = 'QuOrgUnitTeam' AND
                   ',' + CONVERT(varchar(500),Value3) + ',' LIKE '%,' + @OrgGruppeFilter + ',%') T
    WHERE T.Code IN (ORG5.OrgUnitID,ORG4.OrgUnitID,ORG3.OrgUnitID,ORG2.OrgUnitID,ORG1.OrgUnitID,ORG.OrgUnitID)
  END

  IF @TeamID IS NOT NULL BEGIN
    INSERT @OUTPUT (OrgUnitID)
    SELECT ORG.OrgUnitID
    FROM   dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
           LEFT JOIN dbo.XOrgUnit ORG1 WITH (READUNCOMMITTED) ON ORG1.OrgUnitID = ORG.ParentID
           LEFT JOIN dbo.XOrgUnit ORG2 WITH (READUNCOMMITTED) ON ORG2.OrgUnitID = ORG1.ParentID
           LEFT JOIN dbo.XOrgUnit ORG3 WITH (READUNCOMMITTED) ON ORG3.OrgUnitID = ORG2.ParentID
           LEFT JOIN dbo.XOrgUnit ORG4 WITH (READUNCOMMITTED) ON ORG4.OrgUnitID = ORG3.ParentID
           LEFT JOIN dbo.XOrgUnit ORG5 WITH (READUNCOMMITTED) ON ORG5.OrgUnitID = ORG4.ParentID
    WHERE @TeamID IN (ORG5.OrgUnitID,ORG4.OrgUnitID,ORG3.OrgUnitID,ORG2.OrgUnitID,ORG1.OrgUnitID,ORG.OrgUnitID)
  END

  RETURN
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
