SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spXGetRightsAssignedUnassigned
GO
/*===============================================================================================
  $Revision: 9 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get all rights that  are defined in KiSS (Class rights and special rights).
           Only rights of licensed modules will be displayed to filter non-important rights
    @UserGroupID:    The ID of the usergroup, used for filtering with assigned/unassigned
    @OnlyAssigned:   If flag = 1, then only the assigned rights for given UserGroupID will be returned
    @OnlyUnassigned: If flag = 1, then only the unassigned rights for given UserGroupID will be returned
    @LanguageCode:   The language code, used for multilanguage content
  -
  RETURNS: All allowed assigned or unassigned rights prepared for showing in KiSS
  -
  TEST:    EXEC dbo.spXGetRightsAssignedUnassigned NULL, 0, 0, 1
           EXEC dbo.spXGetRightsAssignedUnassigned 13, 0, 0, 1
           EXEC dbo.spXGetRightsAssignedUnassigned 13, 1, 0, 1
           EXEC dbo.spXGetRightsAssignedUnassigned 13, 0, 1, 1
           EXEC dbo.spXGetRightsAssignedUnassigned 13, 1, 1, 1
=================================================================================================*/

CREATE PROCEDURE dbo.spXGetRightsAssignedUnassigned
(
  @UserGroupID INT,
  @OnlyAssigned BIT,
  @OnlyUnassigned BIT,
  @LanguageCode INT
)
AS 
BEGIN
  -------------------------------------------------------------------------------
  -- start call
  -------------------------------------------------------------------------------
  SET NOCOUNT ON
  
  -----------------------------------------------------------------------------
  -- validate and set defaults
  -----------------------------------------------------------------------------
  SET @UserGroupID    = ISNULL(@UserGroupID, -1)
  SET @OnlyAssigned   = ISNULL(@OnlyAssigned, 0)
  SET @OnlyUnassigned = ISNULL(@OnlyUnassigned, 0)
  SET @LanguageCode   = ISNULL(@LanguageCode, 1)
  
  -----------------------------------------------------------------------------
  -- init temporary table
  -----------------------------------------------------------------------------
  DECLARE @Rights TABLE
  (
    ID INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    UserGroup_RightID INT,
    UserGroupID INT,
    MayInsert BIT, 
    MayUpdate BIT, 
    MayDelete BIT,
    XUserGroup_RightTS BINARY(8),     -- cannot use TIMESTAMP here
    UserText VARCHAR(765) NOT NULL,   -- calculated amount of chars!
    XClassID INT NULL,
    ClassName VARCHAR(255) NULL,
    RightID INT,
    MaskName VARCHAR(100)
  )
  
  -----------------------------------------------------------------------------
  -- collect data
  -----------------------------------------------------------------------------
  INSERT INTO @Rights
    -- rights of table XClass
    SELECT UserGroup_RightID  = GRR.UserGroup_RightID,
           UserGroupID        = GRR.UserGroupID,
           MayInsert          = GRR.MayInsert,
           MayUpdate          = GRR.MayUpdate,
           MayDelete          = GRR.MayDelete,
           XUserGroup_RightTS = GRR.XUserGroup_RightTS,
           UserText           = ISNULL(MDL.ShortName + ' - ', '') + ISNULL(CLS.MaskName, '') + ISNULL(' (' + CLS.ClassName + ')', ''),
           XClassID           = CLS.XClassID,
           ClassName          = CLS.ClassName,
           RightID            = NULL,
           MaskName           = NULL
    FROM dbo.XClass CLS WITH (READUNCOMMITTED)
      LEFT JOIN dbo.XModul           MDL WITH (READUNCOMMITTED) ON MDL.ModulID = CLS.ModulID
      LEFT JOIN dbo.XUserGroup_Right GRR WITH (READUNCOMMITTED) ON GRR.XClassID = CLS.XClassID AND
                                                                   GRR.RightID IS NULL AND
                                                                   (@UserGroupID < 1 OR GRR.UserGroupID = @UserGroupID)
    WHERE CLS.MaskName IS NOT NULL AND
          (MDL.ModulID IS NULL OR MDL.System = 1 OR MDL.Licensed = 1) AND   -- filter: use only system and licensed modules
          ((@OnlyAssigned = 1 AND GRR.UserGroupID = @UserGroupID) OR
           (@OnlyUnassigned = 1 AND GRR.UserGroupID IS NULL) OR
           (@OnlyAssigned = 0 AND @OnlyUnassigned = 0))
    
    UNION ALL
    
    -- special rights of table XRight
    SELECT UserGroup_RightID  = GRR.UserGroup_RightID,
           UserGroupID        = GRR.UserGroupID,
           MayInsert          = GRR.MayInsert,
           MayUpdate          = GRR.MayUpdate,
           MayDelete          = GRR.MayDelete,
           XUserGroup_RightTS = GRR.XUserGroup_RightTS,
           UserText           = ISNULL(MDL.ShortName + ' - ', '') + ISNULL(RGT.UserText, '') + ISNULL(' (' + CLS.ClassName + '.' + RGT.RightName + ')', ''),
           XClassID           = RGT.XClassID,
           ClassName          = RGT.ClassName,
           RightID            = RGT.RightID,
           MaskName           = NULL
    FROM dbo.XRight RGT WITH (READUNCOMMITTED)
      LEFT JOIN dbo.XClass           CLS WITH (READUNCOMMITTED) ON CLS.XClassID = RGT.XClassID
      LEFT JOIN dbo.XModul           MDL WITH (READUNCOMMITTED) ON MDL.ModulID = CLS.ModulID
      LEFT JOIN dbo.XUserGroup_Right GRR WITH (READUNCOMMITTED) ON GRR.RightID = RGT.RightID AND
                                                                   (@UserGroupID < 1 OR GRR.UserGroupID = @UserGroupID)
    WHERE (MDL.ModulID IS NULL OR MDL.System = 1 OR MDL.Licensed = 1) AND   -- filter: use only system and licensed modules
          ((@OnlyAssigned = 1 AND GRR.UserGroupID = @UserGroupID) OR
           (@OnlyUnassigned = 1 AND GRR.UserGroupID IS NULL) OR
           (@OnlyAssigned = 0 AND @OnlyUnassigned = 0))
  
  -----------------------------------------------------------------------------
  -- check if need to append data from dynamasks
  -----------------------------------------------------------------------------
  IF ((SELECT OBJECT_ID('DynaMask')) IS NOT NULL)
  BEGIN
    INSERT INTO @Rights
      -- rights of table DynaMask
      SELECT UserGroup_RightID  = GRR.UserGroup_RightID,
             UserGroupID        = GRR.UserGroupID,
             MayInsert          = GRR.MayInsert,
             MayUpdate          = GRR.MayUpdate,
             MayDelete          = GRR.MayDelete,
             XUserGroup_RightTS = GRR.XUserGroup_RightTS,
             UserText           = 'EM ' + CASE MSK.ModulID WHEN 2 THEN CASE MSK.FaPhaseCode WHEN 1 THEN 'FF-INT-'
                                                                                            WHEN 2 THEN 'FF-BER-'
                                                                                            ELSE 'FF-DOK-'
                                                                       END
                                                           WHEN 5 THEN CASE MSK.VmProzessCode WHEN 1  THEN 'VM-MAS-'
                                                                                              WHEN 2  THEN 'VM-VAT-'
                                                                                              WHEN 3  THEN 'VM-EA-'
                                                                                              WHEN 31 THEN 'VM-EA-SIE-'
                                                                                              WHEN 32 THEN 'VM-EA-TES-'
                                                                                              WHEN 33 THEN 'VM-EA-ERB-'
                                                                                              WHEN 4  THEN 'VM-PFL-'
                                                                                              ELSE 'VM-'
                                                                       END
                                                           ELSE ''
                                          END + ISNULL(MSK.DisplayText, '<???>'),
             XClassID           = NULL,
             ClassName          = NULL,
             RightID            = NULL,
             MaskName           = MSK.MaskName
      FROM dbo.DynaMask MSK WITH (READUNCOMMITTED)
        LEFT JOIN dbo.XUserGroup_Right GRR WITH (READUNCOMMITTED) ON GRR.MaskName = MSK.MaskName AND 
                                                                     (@UserGroupID < 1 OR GRR.UserGroupID = @UserGroupID)
      WHERE ((@OnlyAssigned = 1 AND GRR.UserGroupID = @UserGroupID) OR
             (@OnlyUnassigned = 1 AND GRR.UserGroupID IS NULL AND MSK.Active = 1) OR
             (@OnlyAssigned = 0 AND @OnlyUnassigned = 0))
  END
  
  -----------------------------------------------------------------------------
  -- do output
  -----------------------------------------------------------------------------   
  SELECT UserGroup_RightID  = TMP.UserGroup_RightID,
         UserGroupID        = TMP.UserGroupID,
         MayInsert          = TMP.MayInsert, 
         MayUpdate          = TMP.MayUpdate, 
         MayDelete          = TMP.MayDelete,
         XUserGroup_RightTS = CONVERT(TIMESTAMP, TMP.XUserGroup_RightTS),
         UserText           = TMP.UserText,
         XClassID           = TMP.XClassID,
         ClassName          = TMP.ClassName,
         RightID            = TMP.RightID,
         MaskName           = TMP.MaskName
  FROM @Rights TMP
  ORDER BY TMP.UserText, TMP.ClassName
END

GO
