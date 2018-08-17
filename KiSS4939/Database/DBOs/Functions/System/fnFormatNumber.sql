SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnFormatNumber;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/System/fnFormatNumber.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:36 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Format the given number with various options to varchar
   @Number:        The number to format
   @DecimalPlaces: Amount of decimal places for rounding a number
   @Format:        Some format options are available (valid @Format arguments (space between args is ignored)):
                   - nothing -  returns the number unformatted
                   - $: return the number preceded by a '$' sign 
                   - %: return the number followed by a '%' sign 
                   - ,: place a , every 3 zeros in the whole number portion (thousands)
                   - c: divide the number by 100 - intended to calc percent values
                   - i: returns integer portion only with no formatting except commas if requested
                   - d: returns the decimal portion only with no formatting except commas if requested
                   - b: returns a blank string for 0 values
                   - (: encloses negative numbers in brackets
                   - l: use leading zero
                   - r[int]r: rounds number outside of the decimal context
                   - z[int]z: zero fills to [int] width
   @IfZero:        The value to return if @Number = 0
  -
  RETURNS: Formated VARCHAR from given number and parameters
  -
  INFO:    Source: http://www.novicksoftware.com/UDFofWeek/Vol1/T-SQL-UDF-Volume-1-Number-48-formatnumber.htm
  -
  TEST:    SELECT dbo.fnFormatNumber(450, 0, 'z12z', '-1')
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/System/fnFormatNumber.sql $
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     19.03.09 13:23 Cjaeggi
 * Added advanced IfZero-handling
 * 
 * 1     19.03.09 13:20 Cjaeggi
 * New cool function
=================================================================================================*/

CREATE FUNCTION dbo.fnFormatNumber
(
  @Number DECIMAL(38, 15), 
  @DecimalPlaces INT = 0, 
  @Format VARCHAR(115) = '',
  @IfZero VARCHAR(115) = ''
)
RETURNS VARCHAR(256)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- a little error checking is in order
  IF (@Number IS NULL)
  BEGIN
    RETURN  '{ERR-null passed}'
  END
  ELSE IF (@DecimalPlaces < 0)
  BEGIN
    RETURN  '{ERR-decimal spec < 0}' 
  END
  ELSE IF (@DecimalPlaces > 15)
  BEGIN
    RETURN '{ERR-decimal spec > 15}'
  END
  
  -- handle zero values first
  IF (@Number = 0 AND @IfZero <> '')
  BEGIN
    RETURN @IfZero 
  END
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @FmTxt VARCHAR(25)
  DECLARE @ParseTxt VARCHAR(50)
  DECLARE @DecptLoc INT
  DECLARE @IntPart VARCHAR(25)
  DECLARE @DecPart VARCHAR(25)
  DECLARE @RoundTo VARCHAR(2)
  DECLARE @FillTo VARCHAR(50)
  DECLARE @FillTo# VARCHAR(2)
  
  -----------------------------------------------------------------------------
  -- do formatting
  -----------------------------------------------------------------------------
  -- now 'C'alculate the percentage if requested using the '%c' arg.
  IF (CHARINDEX('%c', @Format) > 0)
  BEGIN
    SET @Number = @Number * 100
  END
  
  -- do rounding outside if applicable
  IF (CHARINDEX('r', @Format) > 0)
  BEGIN
    SET @RoundTo = SUBSTRING(@Format, CHARINDEX('r', @Format) + 1, 115)
    SET @RoundTo = LEFT(@RoundTo, CHARINDEX('r', @RoundTo) - 1)
    SET @Number  = ROUND(@Number, CAST(@RoundTo AS INTEGER))
  END
   
  -- get the parsetext variable
  IF (CHARINDEX(',', @Format) > 0)
  BEGIN
    SET @ParseTxt = CONVERT(VARCHAR(100), CAST(@Number AS MONEY), 1)
  END
  ELSE
  BEGIN
    SET @ParseTxt = CONVERT(VARCHAR(100), @Number)
  END
   
  -- grab some basic stuff
  SET @DecptLoc = ISNULL(CHARINDEX('.', @ParseTxt), 0)
   
  IF (@DecptLoc = 0)
  BEGIN
    RETURN @ParseTxt
  END
  ELSE
  BEGIN
    SET @IntPart = SUBSTRING(@ParseTxt, 1, @DecptLoc - 1)
  END
   
  -- handle leading zeros
  IF (CHARINDEX('l', @Format) = 0 AND @IntPart = '0')
  BEGIN
    SET @IntPart = ''
  END
   
  -- now build the decimal portion of the result
  SET @ParseTxt = CONVERT(VARCHAR(100), ROUND(@Number, @DecimalPlaces), 2)
  SET @DecptLoc = ISNULL(CHARINDEX('.', @ParseTxt), 0)
  
  IF (@DecimalPlaces = 0)
  BEGIN
     SET @DecPart = ''
  END
  ELSE
  BEGIN
     SET @DecPart = LEFT(SUBSTRING(@ParseTxt + REPLICATE('0', @DecimalPlaces), @DecptLoc, @DecptLoc+50), @DecimalPlaces + 1)
  END
  
  -----------------------------------------------------------------------------
  -- assemble the results
  -----------------------------------------------------------------------------
  -- for just integer portion
  IF (CHARINDEX('i', @Format) > 0)
  BEGIN
    RETURN @IntPart
  END
  
  -- for just decimal portion
  IF (CHARINDEX('d', @Format) > 0)
  BEGIN
     RETURN  + @DecPart
  END
  
  SET @FmTxt = @IntPart + @DecPart
   
  -- handle brackets if requested
  IF (CHARINDEX('(', @Format) > 0 AND @Number < 0)
  BEGIN
    SET @FmTxt = '(' + RIGHT(@FmTxt, LEN(@FmTxt) - 1) + ')'
  END
  
  -- add the symbols
  IF (CHARINDEX('$', @Format) > 0)
  BEGIN
    SET @FmTxt = '$' + @FmTxt
  END
  ELSE IF (CHARINDEX('%', @Format) > 0)
  BEGIN
    SET @FmTxt = @FmTxt + '%'
  END
  
  -- handle zero filling
  IF (CHARINDEX('z', @Format) > 0)
  BEGIN
    SET @FillTo = SUBSTRING(@Format, CHARINDEX('z', @Format) + 1, 115)
    SET @FillTo# = CAST(LEFT(@FillTo, CHARINDEX('z', @FillTo) - 1) AS INT)
    SET @FmTxt = RIGHT(REPLICATE('0', @FillTo#) + @FmTxt, @FillTo#)
  END
  
  -----------------------------------------------------------------------------
  -- done, return value
  -----------------------------------------------------------------------------
  RETURN @FmTxt
END
