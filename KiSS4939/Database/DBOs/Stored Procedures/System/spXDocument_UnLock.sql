SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXDocument_UnLock;
GO
/*===============================================================================================
  $Revision: 11 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this sp to access-unlock specific document for other users
    @DocumentID: ID of either XDocument or XDocTemplate
    @IsTemplate: Is it a template? TRUE = unlocks XDocTemplate, FALSE = unlocks XDocument-
  RETURNS: Nothing or in case of error the errormessage
=================================================================================================
  TEST:    EXEC dbo.spXDocument_UnLock -1, 1;
=================================================================================================*/

CREATE PROCEDURE dbo.spXDocument_UnLock
(
  @DocumentID INT,
  @IsTemplate BIT
)
AS
BEGIN
  -----------------------------------------------------------------------------
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (ISNULL(@DocumentID, -1) < 1 OR @IsTemplate IS NULL)
  BEGIN
    -- invalid paramters, do not continue, throw back error to caller
    -- do not change error message without changing error Message in XDocFileHandler and others
    RAISERROR('UnLockInvalidParameters' , 18, 1);
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- unlock documents
  -----------------------------------------------------------------------------
  IF (@IsTemplate = 1)
  BEGIN
    ---------------------------------------------------------------------------
    -- using XDocTemplate
    -- 
    -- ATTENTION: 
    -- never change the DB for different customers (e.g. KISS4_BSS_MasterDev_DOC.dbo.XDocTemplate)
    -- XDocTemplate is always stored in the main DB, never in the document DB, for any customer
    ---------------------------------------------------------------------------
    UPDATE dbo.XDocTemplate 
    SET CheckOut_UserID = NULL, 
        CheckOut_Date = NULL, 
        CheckOut_Filename = NULL, 
        CheckOut_Machine = NULL
    WHERE DocTemplateID = @DocumentID;
  END 
  ELSE
  BEGIN
    ---------------------------------------------------------------------------
    -- using XDocument (updating using view or table)
    ---------------------------------------------------------------------------
    UPDATE dbo.XDocument 
    SET CheckOut_UserID = NULL, 
        CheckOut_Date = NULL, 
        CheckOut_Filename = NULL, 
        CheckOut_Machine = NULL
    WHERE DocumentID = @DocumentID;
  END;
END;
GO