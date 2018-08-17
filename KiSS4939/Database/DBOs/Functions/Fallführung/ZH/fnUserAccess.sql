SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnUserAccess
GO
/*===============================================================================================
  $Revision: 4 $
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

CREATE FUNCTION dbo.fnUserAccess
 (@UserID        int,
  @FaLeistungID  int)
  RETURNS TABLE
AS RETURN (
  SELECT TOP 1
    USR.IsUserAdmin,

    IsOwner    = CONVERT(bit, CASE WHEN FLE.UserID = @UserID         THEN 1 ELSE 0 END),
    IsGuest    = CONVERT(bit, CASE WHEN FLZ.FaLeistungID IS NOT NULL THEN 1 ELSE 0 END),
    IsMember   = CONVERT(bit, CASE WHEN MEM.UserID IS NOT NULL       THEN 1 ELSE 0 END),

    MayRead    = CONVERT(bit,
      CASE
        WHEN FLE.UserID = @UserID          THEN 1 -- Besitzer
        WHEN FLZ.FaLeistungID IS NOT NULL  THEN 1 -- Gastzugriff auf FaLeistung
        WHEN MEM.UserID IS NOT NULL        THEN 1 -- Gastzugriff auf Gruppenbasis
        WHEN USR.IsUserAdmin = 1           THEN 1 -- Administrator
        ELSE dbo.fnUserMayReadFall(@UserID, @FaLeistungID)
      END),
    MayInsert  = CONVERT(bit,
      CASE
        WHEN ARC.FaLeistungID IS NOT NULL  THEN 0 -- Archiviert
        WHEN FLE.UserID = @UserID          THEN 1 -- Besitzer
        WHEN FLZ.DarfMutieren = 1          THEN 1 -- Gastzugriff auf FaLeistung
        WHEN MEM.MayInsert = 1             THEN 1 -- Gastzugriff auf Gruppenbasis
        WHEN USR.IsUserAdmin = 1           THEN 1 -- Administrator
        ELSE 0
      END),
    MayUpdate  = CONVERT(bit,
      CASE
        WHEN ARC.FaLeistungID IS NOT NULL  THEN 0 -- Archiviert
        WHEN FLE.UserID = @UserID          THEN 1 -- Besitzer
        WHEN FLZ.DarfMutieren = 1          THEN 1 -- Gastzugriff auf FaLeistung
        WHEN MEM.MayUpdate = 1             THEN 1 -- Gastzugriff auf Gruppenbasis
        WHEN USR.IsUserAdmin = 1           THEN 1 -- Administrator
        ELSE 0
      END),
    MayDelete  = CONVERT(bit,
      CASE
        WHEN ARC.FaLeistungID IS NOT NULL  THEN 0 -- Archiviert
        WHEN FLE.UserID = @UserID          THEN 1 -- Besitzer
        WHEN FLZ.DarfMutieren = 1          THEN 1 -- Gastzugriff auf FaLeistung
        WHEN MEM.MayDelete = 1             THEN 1 -- Gastzugriff auf Gruppenbasis
        WHEN USR.IsUserAdmin = 1           THEN 1 -- Administrator
        ELSE 0
      END),

    FLE.ModulID,
    Closed     = CONVERT(bit, CASE WHEN FLE.DatumBis IS NULL     THEN 0 ELSE 1 END),
    Archived   = CONVERT(bit, CASE WHEN ARC.FaLeistungID IS NULL THEN 0 ELSE 1 END)
  FROM dbo.FaLeistung                 FLE WITH (READUNCOMMITTED) 
    INNER JOIN dbo.XUser              USR WITH (READUNCOMMITTED) ON USR.UserID = @UserID

    LEFT  JOIN dbo.FaLeistungZugriff  FLZ WITH (READUNCOMMITTED) ON FLZ.FaLeistungID = FLE.FaLeistungID AND FLZ.UserID = @UserID
    LEFT  JOIN dbo.XOrgUnit_User      ORG WITH (READUNCOMMITTED) ON ORG.UserID = FLE.UserID       AND ORG.OrgUnitMemberCode = 2 -- Abteilung of Owner
    LEFT  JOIN dbo.XOrgUnit_User      MEM WITH (READUNCOMMITTED) ON MEM.OrgUnitID = ORG.OrgUnitID AND MEM.UserID = @UserID -- Abteilung of User

    LEFT  JOIN dbo.FaLeistungArchiv   ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = FLE.FaLeistungID AND ARC.CheckOut IS NULL
  WHERE FLE.FaLeistungID = @FaLeistungID
)
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
