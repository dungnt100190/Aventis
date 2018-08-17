SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFaGetFallZugriff
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Stored Procedures/Fallführung/spFaGetFallZugriff.sql $
  $Author: Cjaeggi $
  $Modtime: 1.10.09 14:31 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Get case permissions for specific user
    @UserID:       The id of the user who want to get access to case
    @FaLeistungID: The id within FaLeistung to check for access
  -
  RETURNS: Various permission-flags for given user and case
  -
  TEST:    EXEC dbo.spFaGetFallZugriff 2, 3000
           EXEC dbo.spFaGetFallZugriff 333, 3000
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Stored Procedures/Fallführung/spFaGetFallZugriff.sql $
 * 
 * 4     1.10.09 14:34 Cjaeggi
 * #4394: BIAGAdmin has admin rights, use function call
 * 
 * 3     12.03.09 8:02 Cjaeggi
 * Fixed bug with bit>>int
 * 
 * 2     11.03.09 8:28 Cjaeggi
 * Reviewed and added some WITH (READUNCOMMITTED)
 * 
 * 1     3.09.08 17:54 Aklopfenstein
 * 
 * 1     3.09.08 11:13 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE PROCEDURE dbo.spFaGetFallZugriff
(
  @UserID INT, 
  @FaLeistungID INT
)
AS 
BEGIN
  -------------------------------------------------------------------------------
  -- start call
  -------------------------------------------------------------------------------
  SET NOCOUNT ON
  
  -------------------------------------------------------------------------------
  -- init vars
  -------------------------------------------------------------------------------
  DECLARE @MayRead   BIT
  DECLARE @MayInsert BIT
  DECLARE @MayUpdate BIT
  DECLARE @MayDelete BIT
  DECLARE @MayClose  BIT
  DECLARE @MayReopen BIT
  
  DECLARE @ModulID      BIT
  DECLARE @IsUserAdmin  BIT
  DECLARE @OwnerID      INT
  DECLARE @Closed       BIT
  DECLARE @Archived     BIT
  DECLARE @DarfMutieren BIT
  
  DECLARE @Ins BIT
  DECLARE @Upd BIT
  DECLARE @Del BIT
  
  SET @MayRead   = NULL
  SET @MayInsert = NULL
  SET @MayUpdate = NULL
  SET @MayDelete = NULL
  
  -------------------------------------------------------------------------------
  -- get values from database for given FaLeistungID
  -------------------------------------------------------------------------------
  SELECT TOP 1
         @ModulID      = FAL.ModulID,
         @IsUserAdmin  = dbo.fnIsUserAdmin(@UserID),
         @OwnerID      = FAL.UserID,
         @Closed       = CONVERT(BIT, CASE WHEN FAL.DatumBis IS NULL THEN 0 
                                           ELSE 1 
                                      END),
         @Archived     = CONVERT(BIT, CASE WHEN ARC.FaLeistungID IS NULL THEN 0 
                                           ELSE 1 
                                      END),
         @DarfMutieren = FAZ.DarfMutieren,
         @Ins          = B.MayInsert,
         @Upd          = B.MayUpdate,
         @Del          = B.MayDelete
  FROM dbo.FaLeistung FAL WITH (READUNCOMMITTED)
    INNER JOIN dbo.XUser             USR WITH (READUNCOMMITTED) ON USR.UserID = FAL.UserID
    LEFT  JOIN dbo.FaLeistungArchiv  ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = FAL.FaLeistungID AND
                                                                   ARC.CheckOut IS NULL
    LEFT  JOIN dbo.FaLeistungZugriff FAZ WITH (READUNCOMMITTED) ON FAZ.FaLeistungID = FAL.FaLeistungID AND
                                                                   FAZ.UserID = @UserID
    LEFT  JOIN dbo.XOrgUnit_User     A   WITH (READUNCOMMITTED) ON A.UserID = FAL.UserID AND     -- Abteilung of Owner
                                                                   A.OrgUnitMemberCode = 2       -- member
    LEFT  JOIN dbo.XOrgUnit_User     B   WITH (READUNCOMMITTED) ON B.OrgUnitID = A.OrgUnitID AND -- Abteilung of User
                                                                   B.UserID = @UserID
  WHERE  FAL.FaLeistungID = @FaLeistungID
  
  -------------------------------------------------------------------------------
  -- set flags depending on given values
  -------------------------------------------------------------------------------
  IF (@Closed = 1)
  BEGIN
    -- closed or archived: no access
    SET @MayInsert = 0
    SET @MayUpdate = 0
    SET @MayDelete = 0
  END 
  ELSE IF (@IsUserAdmin = 1 OR @OwnerID = @UserID)
  BEGIN
    -- Administrator or Owner: full access
    SET @MayRead   = 1
    SET @MayInsert = 1
    SET @MayUpdate = 1
    SET @MayDelete = 1
  END 
  ELSE IF (@Ins IS NOT NULL)
  BEGIN
    -- Member/Guest in Abteilung of Owner
    SET @MayRead   = 1
    SET @MayInsert = @Ins
    SET @MayUpdate = @Upd
    SET @MayDelete = @Del
  END
  
  -- Fallführung: alle dürfen lesen (falls Maskenrecht auch vorhanden)
  IF (@ModulID = 2) -- FV
  BEGIN
    SET @MayRead = 1
  END
  
  -- Einzelgastrecht für diesen Fall
  IF (@Closed <> 1 AND @DarfMutieren IS NOT NULL)
  BEGIN
    SET @MayRead = 1
    
    IF (@MayInsert = 0)
    BEGIN
      SET @MayInsert = @DarfMutieren
    END
    
    IF (@MayUpdate = 0)
    BEGIN
      SET @MayUpdate = @DarfMutieren
    END
  END
  
  -- Fall/Phase öffnen/Schliessen, falls Admin,Owner,Gastrecht
  IF (@IsUserAdmin = 1 OR @OwnerID = @UserID OR ISNULL(@Upd, 0) = 1 OR ISNULL(@DarfMutieren, 0) = 1)
  BEGIN
    SET @MayClose   = 1
    SET @MayReopen  = 1
  END 
  ELSE 
  BEGIN
    SET @MayClose   = 0
    SET @MayReopen  = 0
  END
  
  -------------------------------------------------------------------------------
  -- set flags depending on given values
  -------------------------------------------------------------------------------
  SELECT MayRead   = ISNULL(@MayRead, CONVERT(BIT, 0)),
         MayInsert = ISNULL(@MayInsert, CONVERT(BIT, 0)),
         MayUpdate = ISNULL(@MayUpdate, CONVERT(BIT, 0)),
         MayDelete = ISNULL(@MayDelete, CONVERT(BIT, 0)),
         Closed    = @Closed,
         Archived  = @Archived,
         MayClose  = @MayClose,
         MayReopen = @MayReopen
END
GO
