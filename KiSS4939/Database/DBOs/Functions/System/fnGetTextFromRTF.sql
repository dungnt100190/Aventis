SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER OFF;
GO
EXECUTE dbo.spDropObject fnGetTextFromRTF;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/System/fnGetTextFromRTF.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:42 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get text from rtf-text (using Microsoft richtx32.ocx)
           Source: http://www.experts-exchange.com/Microsoft/Development/MS-SQL-Server/Q_21192936.html
    @RtfText: The text containing rtf-flags
  -
  RETURNS: Text only from rtf-text
  -
  TEST:    SELECT [dbo].[fnGetTextFromRTF]('{\rtf1\ansi\ansicpg1252\uc1 aaa}')
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/System/fnGetTextFromRTF.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     15.12.08 14:06 Cjaeggi
 * First version
=================================================================================================*/

CREATE FUNCTION dbo.fnGetTextFromRTF
(
  @RtfText VARCHAR(8000)
)
RETURNS VARCHAR(8000)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if no text is passed, return null
  IF (@RtfText IS NULL)
  BEGIN
    -- invalid value
    RETURN NULL
  END
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @Object INT
  DECLARE @Hr INT
  DECLARE @TextOut VARCHAR(8000)
  DECLARE @Src VARCHAR(255)
  DECLARE @Desc VARCHAR(255)
  
  -----------------------------------------------------------------------------
  -- Create an object that points to the SQL Server
  -----------------------------------------------------------------------------
  EXEC @Hr = sp_OACreate 'RICHTEXT.RichtextCtrl', @Object OUT
  
  IF (@Hr <> 0)
  BEGIN
     EXEC sp_OAGetErrorInfo @Object, @Src OUT, @Desc OUT 
     --RAISERROR('Error Creating COM Component 0x%x, %s, %s', 16, 1, @Hr, @Src, @Desc)
     RETURN 'ERROR: Error Creating COM Component: ' + ISNULL(@Desc, '??')
  END
  
  EXEC @Hr = sp_OASetProperty @Object, 'TextRTF', @RtfText
  EXEC @Hr = sp_OAGetProperty @Object, 'Text', @TextOut OUT
  EXEC @Hr = sp_OADestroy @Object
  
  -----------------------------------------------------------------------------
  -- check and return value
  ----------------------------------------------------------------------------- 
  RETURN @TextOut
END 