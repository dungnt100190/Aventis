SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXDbObjectMLMsg;
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get translateable text for database objects.
           This function expects a valid tid, otherwise it will return 'ERROR'.
           The function replaces any '\r\n' by CHAR(13) + CHAR(10), such that the newlines are
           displayed properly.
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    SELECT dbo.fnXDbObjectMLMsg('aa', 'bb', 1);
=================================================================================================*/

CREATE FUNCTION dbo.fnXDbObjectMLMsg
(
  @DBObjectName VARCHAR(100),
  @MessageName  VARCHAR(100),
  @LanguageCode INT
)
RETURNS VARCHAR(2000) WITH SCHEMABINDING
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@DbObjectName IS NULL OR @DbObjectName = '' OR @MessageName IS NULL OR @MessageName = '')
  BEGIN
   RETURN 'ERROR: Invalid parameters, cannot return a proper message (dbo.fnXDbObjectMLMsg).';
  END;
  
  -----------------------------------------------------------------------------
  -- declare vars
  -----------------------------------------------------------------------------
  DECLARE @ReturnMessage VARCHAR(2000);
  
  -----------------------------------------------------------------------------
  -- get message from database
  -----------------------------------------------------------------------------
  SELECT @ReturnMessage = REPLACE(dbo.fnGetMLText(MessageTID, @LanguageCode), '\r\n', CHAR(13) + CHAR(10))
  FROM dbo.XMessage WITH (READUNCOMMITTED)
  WHERE MaskName = @DBObjectName 
    AND MessageName = @MessageName;
  
  -----------------------------------------------------------------------------
  -- validate message
  -----------------------------------------------------------------------------
  RETURN ISNULL(@ReturnMessage, 'ERROR: Text not found (dbo.fnXDbObjectMLMsg: ' + 
                                ISNULL(@DbObjectName, '') + '.' + ISNULL(@MessageName, '') + ').');
END;
GO