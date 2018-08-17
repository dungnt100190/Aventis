SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnDateAsVarchar;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnDateAsVarchar.sql $
  $Author: Cjaeggi $
  $Modtime: 16.03.10 16:56 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Convert datetime to varchar with given format
    @DateValue:    .
    @FormatString: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/fnDateAsVarchar.sql $
 * 
 * 3     16.03.10 16:58 Cjaeggi
 * Revised to fit guidelines
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:33 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnDateAsVarchar
(
  @DateValue DATETIME,
  @FormatString VARCHAR(50)
)
RETURNS VARCHAR(255)
AS BEGIN
  -- validate
  IF (@DateValue IS NULL)
  BEGIN
    RETURN NULL;
  END;
  
  -- define vars
  DECLARE @day VARCHAR(2);
  DECLARE @month VARCHAR(2);
  DECLARE @year VARCHAR(4);
  
  -- set vars
  SET @day = CONVERT(VARCHAR(2), DATEPART(dd, @DateValue));
  SET @month = CONVERT(VARCHAR(2), DATEPART(mm, @DateValue));
  SET @year = CONVERT(VARCHAR(4), DATEPART(yyyy, @DateValue));
  
  -- depending on format string
  IF (@FormatString = 'd.m.yyyy')
  BEGIN
    RETURN @day + '.' + @month + '.' + @year;
  END;

  IF (@FormatString = 'dd.mm.yyyy')
  BEGIN
    RETURN CONVERT(VARCHAR(10), @DateValue, 104);
  END;
  
  IF (@FormatString = 'yyyy.mm')
  BEGIN
    RETURN SUBSTRING(CONVERT(VARCHAR(8), @DateValue, 102), 1, 7); --converts @DateValue to yyyy.mm.dd and then takes the first 7 characters
  END;

  -- if we are here, the pattern did not match
  RETURN NULL;
END;
GO