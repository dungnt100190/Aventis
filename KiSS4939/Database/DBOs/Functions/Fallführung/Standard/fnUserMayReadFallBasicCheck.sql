SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnUserMayReadFallBasicCheck
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
    Grundprüfung : darf der Benutzer eine Leistung lesen?
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnUserMayReadFallBasicCheck
(
  @UserID        INT,
  @FaLeistungID  INT
)
RETURNS BIT
AS 

BEGIN
  DECLARE @OwnerID                  INT,
          @IsUserAdmin              BIT,
          @IsUserGuest              BIT,
          @IsUserMember             BIT,
		  @MyGetDate	        	DATETIME;

  SET @MyGetDate = dbo.fnDateSerial(YEAR(GETDATE()),MONTH(GETDATE()),DAY(GETDATE()));
		  
  SELECT TOP 1
    @OwnerID      = FLE.UserID,
    @IsUserAdmin  = USR.IsUserAdmin,
    @IsUserGuest  = CASE WHEN FLZ.FaLeistungID IS NOT NULL THEN 1 ELSE 0 END,
    @IsUserMember = CASE WHEN MEM.UserID       IS NOT NULL THEN 1 ELSE 0 END
  FROM dbo.FaLeistung                 FLE WITH (READUNCOMMITTED) 
    INNER JOIN dbo.XUser              USR WITH (READUNCOMMITTED) ON USR.UserID = @UserID
    LEFT  JOIN dbo.FaLeistungZugriff  FLZ WITH (READUNCOMMITTED) ON FLZ.FaLeistungID = FLE.FaLeistungID 
                                                                AND FLZ.UserID = @UserID
                                                                AND dbo.fnUserAccessGastrechtGueltigkeitZeitbereich(@MyGetDate, FLZ.DatumVon, FLZ.DatumBis) = 1
    LEFT  JOIN dbo.XOrgUnit_User      ORG WITH (READUNCOMMITTED) ON ORG.UserID = FLE.UserID
                                                                AND ORG.OrgUnitMemberCode = 2 -- Abteilung of Owner
    LEFT  JOIN dbo.XOrgUnit_User      MEM WITH (READUNCOMMITTED) ON MEM.OrgUnitID = ORG.OrgUnitID 
                                                                AND MEM.UserID = @UserID -- Abteilung of User
  WHERE FLE.FaLeistungID = @FaLeistungID

  IF (@IsUserAdmin = 1 OR @OwnerID = @UserID OR @IsUserGuest = 1 OR @IsUserMember = 1)
  BEGIN
    RETURN 1;
  END;


    RETURN 0;
END

GO