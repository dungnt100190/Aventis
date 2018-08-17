SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
---------------------------------------------------------------------------------
---- we need to drop constraint first
---------------------------------------------------------------------------------
--IF (EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_XLOVCode_DataIntegrity]') AND parent_object_id = OBJECT_ID(N'[dbo].[XLOVCode]')))
--BEGIN
--  ALTER TABLE [dbo].[XLOVCode] DROP CONSTRAINT [CK_XLOVCode_DataIntegrity];
  
--  PRINT ('Info: Dropped constraint "CK_XLOVCode_DataIntegrity"');
--END
-------------------------------------------------------------------------------
GO
EXECUTE dbo.spDropObject fnCKXLovCodeIntegrity;
GO

/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Check data integrity for table XLOVCode. This function only performs any checks
    @XLOVCodeID: The primary key id of the datarow to insert/update
    @XLOVID:     The foreign key on XLOV
    @LOVName:    The LOVName of XLOV
  -
  RETURNS: "0" if data is valid
           "1" if invalid parameters are provided
           "2" if LOVName on XLOVCode is different as on XLOV
=================================================================================================
  TEST:    
=================================================================================================*/

CREATE FUNCTION dbo.fnCKXLovCodeIntegrity
(
  @XLOVCodeID INT,
  @XLOVID INT,
  @LOVName VARCHAR(100)
)
RETURNS INT
AS
BEGIN

  -----------------------------------------------------------------------------
  -- validate parameter
  -----------------------------------------------------------------------------
  IF (@XLOVID IS NULL OR @LOVName IS NULL)
  BEGIN
    -- invalid parameter
    RETURN 1;
  END;

  -----------------------------------------------------------------------------
  -- LOVName muss mit LOVName auf XLOV übereinstimmen
  -----------------------------------------------------------------------------
  IF NOT EXISTS(SELECT TOP 1 1
                FROM dbo.XLOV
                WHERE XLOVID = @XLOVID
                  AND LOVName = @LOVName)
  BEGIN
    RETURN 2;
  END;

  -----------------------------------------------------------------------------
  -- if we are here, everything is alright
  -----------------------------------------------------------------------------
  RETURN 0;
END;
GO

---------------------------------------------------------------------------------
---- we need to recreate constraint
---------------------------------------------------------------------------------
--IF (EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[XLOVCode]') AND type in (N'U')))
--BEGIN
--  ALTER TABLE [dbo].[XLOVCode] WITH NOCHECK 
--  ADD CONSTRAINT [CK_XLOVCode_DataIntegrity] 
--  CHECK (([dbo].[fnCKXLovCodeIntegrity]([XLOVCodeID],[XLOVID],[LOVName])=(0)));
  
--  ALTER TABLE [dbo].[XLOVCode] CHECK CONSTRAINT [CK_XLOVCode_DataIntegrity];

--  EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Checks for valid XLOVCode records' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'CONSTRAINT',@level2name=N'CK_XLOVCode_DataIntegrity';
  
--  PRINT ('Info: Recreated constraint "CK_XLOVCode_DataIntegrity"');
--END;
--GO
-------------------------------------------------------------------------------

