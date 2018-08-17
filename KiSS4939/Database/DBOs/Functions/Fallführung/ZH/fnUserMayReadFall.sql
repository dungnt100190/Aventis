SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnUserMayReadFall
GO
/*
===================================================================================================
Author:      ??????
Create date: 11.09.2007
Description: Funktion zum Ermitteln, ob ein User eine Leistung lesen darf
===================================================================================================
History:
??.??.???? : ?????? : neu erstellt
06.10.2008 : sozheo : Rekursivität entfernt
===================================================================================================
*/

CREATE FUNCTION [dbo].[fnUserMayReadFall]
 (@UserID        int,
  @FaLeistungID  int)
  RETURNS bit
AS BEGIN
  DECLARE @ModulID        int,
          @FaFallID       int,
          @FaProzessCode  int,
          @OwnerID        int,
          @IsUserAdmin    bit,
          @IsUserGuest    bit,
          @IsUserMember   bit

  SELECT TOP 1
    @ModulID       = FLE.ModulID,
    @FaFallID      = FLE.FaFallID,
    @FaProzessCode = FLE.FaProzessCode,
    @OwnerID       = FLE.UserID,
    @IsUserAdmin   = USR.IsUserAdmin,
    @IsUserGuest   = CASE WHEN FLZ.FaLeistungID IS NOT NULL THEN 1 ELSE 0 END,
    @IsUserMember  = CASE WHEN MEM.UserID       IS NOT NULL THEN 1 ELSE 0 END
  FROM dbo.FaLeistung                 FLE WITH (READUNCOMMITTED) 
    INNER JOIN dbo.XUser              USR WITH (READUNCOMMITTED) ON USR.UserID = @UserID

    LEFT  JOIN dbo.FaLeistungZugriff  FLZ WITH (READUNCOMMITTED) ON FLZ.FaLeistungID = FLE.FaLeistungID AND FLZ.UserID = @UserID
    LEFT  JOIN dbo.XOrgUnit_User      ORG WITH (READUNCOMMITTED) ON ORG.UserID = FLE.UserID       AND ORG.OrgUnitMemberCode = 2 -- Abteilung of Owner
    LEFT  JOIN dbo.XOrgUnit_User      MEM WITH (READUNCOMMITTED) ON MEM.OrgUnitID = ORG.OrgUnitID AND MEM.UserID = @UserID -- Abteilung of User
  WHERE FLE.FaLeistungID = @FaLeistungID

  IF (@IsUserAdmin = 1 OR @OwnerID = @UserID OR @IsUserGuest = 1 OR @IsUserMember = 1)
       OR (@ModulID = 2 AND @FaProzessCode = 201) -- Fallführung Alim
  BEGIN
    RETURN 1
  END

  -- FAMOZ Spezial: Zugriff auf Alimentinkassi (405, 406, 407), 
  -- falls im selben Fall ein aktives W (300) oder aktives K (500)
  -- vorhanden ist auf welches der User Zugriff hat
  -- 06.10.2008 : sozheo : Ergibt Endlos-Schlaufe, da sich dbo.fnUserMayReadFall rekursiv aufruft 
  /*
  IF @FaProzessCode in (405,406,407) AND
     EXISTS (SELECT 1 
             FROM   dbo.FaLeistung FLE WITH (READUNCOMMITTED) 
             WHERE  FLE.FaFallID = @FaFallID AND
                    FLE.FaProzessCode IN (300,500) AND
                    FLE.DatumBis IS NULL AND
                    dbo.fnUserMayReadFall(@UserID,FLE.FaLeistungID) = 1)
  BEGIN
    RETURN 1  
  END
  */
  IF @FaProzessCode IN (405,406,407) 
  BEGIN
    SELECT TOP 1 
      @OwnerID       = FLE.UserID,
      @IsUserGuest   = CASE WHEN FLZ.FaLeistungID IS NOT NULL THEN 1 ELSE 0 END,
      @IsUserMember  = CASE WHEN MEM.UserID       IS NOT NULL THEN 1 ELSE 0 END
    FROM dbo.FaLeistung FLE WITH (READUNCOMMITTED) 
    INNER JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = @UserID
    LEFT JOIN dbo.FaLeistungZugriff  FLZ WITH (READUNCOMMITTED) ON FLZ.FaLeistungID = FLE.FaLeistungID AND FLZ.UserID = @UserID
    LEFT  JOIN dbo.XOrgUnit_User ORG WITH (READUNCOMMITTED) ON ORG.UserID = FLE.UserID AND ORG.OrgUnitMemberCode = 2 -- Abteilung of Owner
    LEFT JOIN dbo.XOrgUnit_User MEM WITH (READUNCOMMITTED) ON MEM.OrgUnitID = ORG.OrgUnitID AND MEM.UserID = @UserID -- Abteilung of User
    WHERE FLE.FaFallID = @FaFallID 
      AND FLE.FaProzessCode IN (300, 500) 
      AND FLE.DatumBis IS NULL 
    IF (@OwnerID = @UserID OR @IsUserGuest = 1 OR @IsUserMember = 1) 
    BEGIN
      RETURN 1
    END
  END

  RETURN 0
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
