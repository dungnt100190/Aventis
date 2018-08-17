SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXDocument_Lock;
GO
/*===============================================================================================
  $Revision: 15 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Use this sp to access-lock specific document for other users
    @DocumentID:          ID of either XDocument or XDocTemplate
    @CheckOutUserID:      The user id who locks the document
    @CheckoutFilename:    The local filename including path of locked document
    @CheckoutMachinename: The name of the computer of the user who locks the document
    @IsTemplate:          Is it a template? TRUE = locks XDocTemplate, FALSE = locks XDocument
  -
  RETURNS: Nothing or in case of error the error-code used for mulitlanguage message
=================================================================================================
  TEST:    EXEC dbo.spXDocument_Lock -1, -1, NULL, NULL, 1;
=================================================================================================*/

CREATE PROCEDURE dbo.spXDocument_Lock
(
  @DocumentID INT,
  @CheckoutUserID INT,
  @CheckoutFilename VARCHAR(MAX),
  @CheckoutMachinename VARCHAR(MAX),
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
  IF (ISNULL(@DocumentID, -1) < 1 OR ISNULL(@CheckOutUserID, -1) < 1 
      OR @CheckoutFilename IS NULL OR @CheckoutMachinename IS NULL
      OR @IsTemplate IS NULL)
  BEGIN
    -- invalid paramters, do not continue, throw back error to caller
    -- do not change error message without changing error Message in XDocFileHandler and others
    RAISERROR('LockInvalidParameters' , 18, 1);
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- vars II.
  -----------------------------------------------------------------------------
  -- declare vars
  DECLARE @tmpCheckoutUserID INT;
  DECLARE @tmpCheckoutDate DATETIME;
  DECLARE @tmpUserName VARCHAR(200);
  DECLARE @tmpCheckoutFilename VARCHAR(MAX);
  DECLARE @tmpCheckoutMachinename VARCHAR(MAX);
  
  -----------------------------------------------------------------------------
  -- get current checked-out values
  -- ensure transaction was started from outer call of stored procedure
  -----------------------------------------------------------------------------
  IF (@IsTemplate = 1)
  BEGIN
    -- using XDocTemplate
    SELECT @tmpCheckoutUserID      = DOC.CheckOut_UserID,
           @tmpCheckoutDate        = DOC.CheckOut_Date,
           @tmpCheckoutFilename    = DOC.CheckOut_Filename,
           @tmpCheckoutMachinename = DOC.CheckOut_Machine,
           @tmpUserName            = USR.LastName + ISNULL(' ' + USR.FirstName, '')
    FROM dbo.XDocTemplate DOC
      LEFT JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = DOC.CheckOut_UserID
    WHERE DOC.DocTemplateID = @DocumentID;
  END 
  ELSE
  BEGIN
    -- using table XDocument by using view XDocument
    SELECT @tmpCheckoutUserID      = DOC.CheckOut_UserID,
           @tmpCheckoutDate        = DOC.CheckOut_Date,
           @tmpCheckoutFilename    = DOC.CheckOut_Filename,
           @tmpCheckoutMachinename = DOC.CheckOut_Machine,
           @tmpUserName            = USR.LastName + ISNULL(' ' + USR.FirstName, '')
    FROM dbo.XDocument DOC
      LEFT JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = DOC.CheckOut_UserID
    WHERE DOC.DocumentID = @DocumentID;
  END;
  
  -----------------------------------------------------------------------------
  -- check for existing chekcouts
  -----------------------------------------------------------------------------
  IF (@tmpCheckoutUserID IS NOT NULL AND @tmpCheckoutUserID != @CheckoutUserID)
  BEGIN
    -- file locked by other user
    -- do not change error message without changing error Message in XDocFileHandler and others
    RAISERROR('FileIsLockedByAnotherUser' , 18, 1);
    RETURN;
  END
  IF (@tmpCheckoutUserID IS NOT NULL AND @tmpCheckoutUserID = @CheckoutUserID)
  BEGIN
    -- file locked by the actual user
    -- do not change error message without changing error Message in XDocFileHandler and others
    RAISERROR('FileIsLockedByActualUser' , 18, 1);
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- no error occured, lock the document
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
    SET CheckOut_UserID = @CheckoutUserID, 
        CheckOut_Date = GETDATE(), 
        CheckOut_Filename = @CheckoutFilename, 
        CheckOut_Machine = @CheckoutMachinename
    WHERE DocTemplateID = @DocumentID;
  END 
  ELSE
  BEGIN
    ---------------------------------------------------------------------------
    -- using XDocument (updating using view or table)
    ---------------------------------------------------------------------------
    UPDATE dbo.XDocument 
    SET CheckOut_UserID = @CheckoutUserID, 
        CheckOut_Date = GETDATE(), 
        CheckOut_Filename = @CheckoutFilename, 
        CheckOut_Machine = @CheckoutMachinename
    WHERE DocumentID = @DocumentID;
  END;
END;
GO