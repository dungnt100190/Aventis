SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnImage2VarChar;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnImage2VarChar.sql $
  $Author: Cjaeggi $
  $Modtime: 17.03.10 13:35 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/fnImage2VarChar.sql $
 * 
 * 3     17.03.10 13:36 Cjaeggi
 * Revised for coding rules
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
=================================================================================================*/

CREATE FUNCTION dbo.fnImage2VarChar
(
  @InputImage IMAGE
)
RETURNS VARCHAR(8000)
AS BEGIN
  DECLARE @inputLen INT;
  DECLARE @Pos INT;
  DECLARE @retText VARCHAR(8000);
  
  SET @inputLen = DATALENGTH(@InputImage);
  
  IF (@inputLen = 0)
  BEGIN
    RETURN '';
  END;

  SET @Pos = 1;
  SET @retText = '';
  
  WHILE (@Pos <= @inputLen)
  BEGIN
    SET @retText = @retText + CHAR(SUBSTRING(@InputImage, @Pos, 1));
    SET @Pos = @Pos + 1;
  END;
  
  RETURN @retText;
END;
GO