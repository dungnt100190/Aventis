 SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE dbo.spDropObject fnGetTextAtPosition
GO

/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnGetTextAtPosition.sql $
  $Author: Nweber $
  $Modtime: 26.11.09 11:46 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: This functions splits a given string to its values and returns a table
    @String    The varchar string to split
    @Delimiter The delimiter between given values
    @PosToGet  The position form the value to get in the string
  -
  RETURNS: The string from the value at the given position
  -
  TEST:    SELECT dbo.fnGetTextAtPosition('a,b,c,d,e', ',', 1) -- returns 'a'
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnGetTextAtPosition.sql $
 * 
 * 1     26.11.09 14:34 Nweber
 * #4644: Funktionen um die aktualisierte Banken anzuzeigen.
 * 
=================================================================================================*/
CREATE FUNCTION dbo.fnGetTextAtPosition
(
  @String VARCHAR(MAX),
  @Delimiter VARCHAR(10),
  @PosToGet INT
)
RETURNS VARCHAR(MAX)
AS BEGIN
  DECLARE @Text VARCHAR(MAX)
  DECLARE @Position INT
  DECLARE @NextString VARCHAR(MAX)
  DECLARE @Pos INT
  DECLARE @NextPos INT
  DECLARE @CommaCheck VARCHAR(1)

  --Initialize
  SET @Text = ''
  SET @Position = 0
  SET @CommaCheck = RIGHT(@String, 1) 

  --Check for trailing Comma, if not exists, INSERT
  --if (@CommaCheck <> @Delimiter )
  SET @String = @String + @Delimiter

  --Get position of first Comma
  SET @Pos = CHARINDEX(@Delimiter, @String)
  SET @NextPos = 1

  --Loop while there is still a comma in the String of levels
  WHILE (@Position < @PosToGet)
  BEGIN
    SET @Text = SUBSTRING(@String, 1, @Pos - 1)

    SET @String = SUBSTRING(@String, @pos + 1, LEN(@String))
    SET @NextPos = @Pos
    SET @pos  = CHARINDEX(@Delimiter, @String)

    SET @Position = @Position + 1
  END


  RETURN @Text
END
