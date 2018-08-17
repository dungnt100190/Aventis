SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXDbObjectMLMsg;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Run this stored procedure to insert multilanguage text for database objects into database 
           and let it translate in KiSS
    @DbObjectName:   The name of the db-object to which this message belongs
    @MessageName:    The name of the message within the db-object
    @DefaultMessage: The default text to use if no other is defined for other language
    @MessageCode:    The code for the message where 4="Text"
  -
  RETURNS: 1=success, -1=failure
=================================================================================================
  TEST:    EXEC dbo.spXDbObjectMLMsg 'hello', 'world', 'hi there', 4;
=================================================================================================*/

CREATE PROCEDURE dbo.spXDbObjectMLMsg
(
  @DbObjectName VARCHAR(100),
  @MessageName VARCHAR(100),
  @DefaultMessage VARCHAR(2000),
  @MessageCode INT = 4 		-- 4 = "Text" as default code
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@DbObjectName IS NULL OR @DbObjectName = '' OR @MessageName IS NULL OR @MessageName = '')
  BEGIN
    RETURN -1;
  END;
  
  -----------------------------------------------------------------------------
  -- declare vars
  -----------------------------------------------------------------------------
  DECLARE @actTID INT;
  
  -----------------------------------------------------------------------------
  -- insert data if not yet in database (insert only in "Deutsch"!)  
  -----------------------------------------------------------------------------
  -- get tid of message if already in database
  SELECT @actTID = MessageTID
  FROM dbo.XMessage WITH (READUNCOMMITTED)
  WHERE MaskName = @DbObjectName 
    AND MessageName = @MessageName;
  
  -- check if tid is already defined
  IF (@actTID IS NOT NULL)
  BEGIN
    -- we already have a tid, check if it is still valid
    IF (NOT EXISTS(SELECT TOP 1 1 
                   FROM dbo.XLangText WITH (READUNCOMMITTED) 
                   WHERE LanguageCode = 1 
                     AND TID = @actTID))
    BEGIN
      -- tid is no more valid, insert new text as new tid
      INSERT INTO dbo.XLangText (LanguageCode, Text) 
      VALUES (1, @DefaultMessage);
      
      -- get new tid
      SET @actTID = SCOPE_IDENTITY();
      
      -- update message
      UPDATE dbo.XMessage 
      SET MessageTID = @actTID 
      WHERE MaskName = @DbObjectName 
        AND MessageName = @MessageName;
    END;
  END 
  ELSE 
  BEGIN
    -- no tid available, insert new text as new tid
    INSERT INTO dbo.XLangText (LanguageCode, Text) 
    VALUES (1, @DefaultMessage)
    
    -- get new tid
    SET @actTID = SCOPE_IDENTITY();
    
    -- insert new message
    INSERT INTO dbo.XMessage (MessageName, MaskName, MessageTID, MessageCode)
    VALUES (@MessageName, @DbObjectName, @actTID, @MessageCode);
  END;
  
  -----------------------------------------------------------------------------
  -- Done
  -----------------------------------------------------------------------------
  RETURN 1;
END;
GO