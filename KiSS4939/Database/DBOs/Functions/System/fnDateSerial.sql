SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnDateSerial;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnDateSerial.sql $
  $Author: Cjaeggi $
  $Modtime: 16.03.10 17:09 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Convert year, month and date parts to datetime value
    @Year:  The year part to use for datetime value
    @Month: The month part to use for datetime value
    @Day:   The day part to use for datetime value
  -
  RETURNS: The datetime value of the given parts. If day does not exist for given month, the day
           will be the last day of the given month.
  -
  TEST:    SELECT dbo.fnDateSerial(2010, 5, 20);
           SELECT dbo.fnDateSerial(2010, 12, 32);
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/fnDateSerial.sql $
 * 
 * 3     16.03.10 17:09 Cjaeggi
 * Revised to fit guidelines
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnDateSerial
(
  @Year INT,
  @Month INT,
  @Day INT
)
RETURNS DATETIME
AS BEGIN
  DECLARE @OutDate DATETIME;
  
  SET @OutDate = CONVERT(DATETIME, CAST(@Year AS VARCHAR) + RIGHT('0' + CAST(@Month AS VARCHAR), 2) + '01', 112);
  
  IF (@Month <> MONTH(DATEADD(d, @Day - 1, @OutDate)))
  BEGIN
    SET @OutDate = DATEADD(d, -1, DATEADD(m, 1, @OutDate));
  END 
  ELSE 
  BEGIN
    SET @OutDate = DATEADD(d, @Day - 1, @OutDate);
  END;
  
  RETURN @OutDate;
END;
GO