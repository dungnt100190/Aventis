SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
-------------------------------------------------------------------------------
-- we need to drop constraint first
-------------------------------------------------------------------------------
IF (EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_IkForderung_BgKostenart_DataIntegrity]') AND parent_object_id = OBJECT_ID(N'[dbo].[IkForderung_BgKostenart]')))
BEGIN
  ALTER TABLE [dbo].[IkForderung_BgKostenart] DROP CONSTRAINT [CK_IkForderung_BgKostenart_DataIntegrity];
  
  PRINT ('Info: Dropped constraint "CK_IkForderung_BgKostenart_DataIntegrity"');
END
-------------------------------------------------------------------------------

GO
EXECUTE dbo.spDropObject fnIkCKIkForderung_BgKostenartIntegrity;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Check data integrity for table IkForderung_BgKostenart. This function only performs any checks
    @IkForderung_BgKostenartID: The primary key id of the datarow to insert/update
  -
  RETURNS: "0" if data is valid or was not checked (for any IkForderung_BgKostenartStatusCode <> 13)
           "1" if invalid parameters are provided
           "2" if the combination of BgKostenartID_Auszahlung, BgKostenartID_Forderung, IkForderungEinmaligCode and IkForderungPeriodischCode exists more than once in the table
=================================================================================================
  TEST:    select dbo.fnIkCKIkForderung_BgKostenartIntegrity(1);
=================================================================================================*/

CREATE FUNCTION dbo.fnIkCKIkForderung_BgKostenartIntegrity
(
  @IkForderung_BgKostenartID INT
)
RETURNS INT
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate parameter
  -----------------------------------------------------------------------------
  IF (@IkForderung_BgKostenartID IS NULL)
  BEGIN
    -- invalid parameter
    RETURN 1;
  END;
  
  DECLARE @BgKostenartID_Auszahlung INT;
  DECLARE @BgKostenartID_Forderung INT;
  DECLARE @IkForderungEinmaligCode INT;
  DECLARE @IkForderungPeriodischCode INT;
  
  SELECT @BgKostenartID_Auszahlung  = BgKostenartID_Auszahlung,
         @BgKostenartID_Forderung   = BgKostenartID_Forderung,
         @IkForderungEinmaligCode   = IkForderungEinmaligCode,
         @IkForderungPeriodischCode = IkForderungPeriodischCode
  FROM dbo.IkForderung_BgKostenart FKA
  WHERE IkForderung_BgKostenartID = @IkForderung_BgKostenartID;

  -----------------------------------------------------------------------------
  -- the combination of BgKostenartID_Auszahlung, BgKostenartID_Forderung, IkForderungEinmaligCode and IkForderungPeriodischCode exists more than once in the table
  -----------------------------------------------------------------------------
  IF EXISTS(SELECT TOP 1 1
            FROM dbo.IkForderung_BgKostenart FKA
            WHERE IkForderung_BgKostenartID <> @IkForderung_BgKostenartID
              AND BgKostenartID_Auszahlung = @BgKostenartID_Auszahlung
              AND BgKostenartID_Forderung = @BgKostenartID_Forderung
              AND ISNULL(IkForderungEinmaligCode, -1) = ISNULL(@IkForderungEinmaligCode, -1)
              AND ISNULL(IkForderungPeriodischCode, -1) = ISNULL(@IkForderungPeriodischCode, -1))
  BEGIN
    RETURN 2;
  END;
  
  -----------------------------------------------------------------------------
  -- if we are here, everything is alright
  -----------------------------------------------------------------------------
  RETURN 0;
END;
GO

-------------------------------------------------------------------------------
-- we need to recreate constraint
-------------------------------------------------------------------------------
IF (EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IkForderung_BgKostenart]') AND type in (N'U')))
BEGIN
  ALTER TABLE [dbo].[IkForderung_BgKostenart] WITH NOCHECK 
  ADD CONSTRAINT [CK_IkForderung_BgKostenart_DataIntegrity] 
  CHECK (([dbo].[fnIkCKIkForderung_BgKostenartIntegrity]([IkForderung_BgKostenartID])=(0)));
  
  ALTER TABLE [dbo].[IkForderung_BgKostenart] CHECK CONSTRAINT [CK_IkForderung_BgKostenart_DataIntegrity];

  EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Checks for valid IkForderung_BgKostenart records' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderung_BgKostenart', @level2type=N'CONSTRAINT',@level2name=N'CK_IkForderung_BgKostenart_DataIntegrity';
  
  PRINT ('Info: ReCreated constraint "CK_IkForderung_BgKostenart_DataIntegrity"');
END;
GO
-------------------------------------------------------------------------------
 