SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnSplit
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnSplit.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 16:04 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: This functions splits a given string to its values and returns a table
    @String    The varchar string to split
    @Delimiter The delimiter between given values
  -
  RETURNS: The splitted values from string
  -
  TEST:    SELECT * FROM dbo.fnSplit('a,b,c,d,e', ',')
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnSplit.sql $
 * 
 * 3     25.06.09 8:15 Ckaeser
 * Alter2Create
 * 
 * 2     24.10.08 11:39 Cjaeggi
 * VARCHAR(MAX) because of missing entries on large string, casefix
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE FUNCTION dbo.fnSplit
(
  @String VARCHAR(MAX),
  @Delimiter VARCHAR(10)
)
RETURNS @ValueTable TABLE ([Value] VARCHAR(MAX))
BEGIN
  DECLARE @NextString VARCHAR(MAX)
  DECLARE @Pos INT
  DECLARE @NextPos INT
  DECLARE @CommaCheck VARCHAR(1)

  --Initialize
  SET @NextString = ''
  SET @CommaCheck = RIGHT(@String, 1) 

  --Check for trailing Comma, if not exists, INSERT
  --if (@CommaCheck <> @Delimiter )
  SET @String = @String + @Delimiter

  --Get position of first Comma
  SET @Pos = CHARINDEX(@Delimiter, @String)
  SET @NextPos = 1

  --Loop while there is still a comma in the String of levels
  WHILE (@pos <> 0)
  BEGIN
    SET @NextString = SUBSTRING(@String, 1, @Pos - 1)

    INSERT INTO @ValueTable ([Value]) 
    VALUES (@NextString)

    SET @String = SUBSTRING(@String, @pos + 1, LEN(@String))

    SET @NextPos = @Pos
    SET @pos  = CHARINDEX(@Delimiter, @String)
  END

  -- done
  RETURN
END
GO