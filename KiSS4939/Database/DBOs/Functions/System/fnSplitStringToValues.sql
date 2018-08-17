SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnSplitStringToValues;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/System/fnSplitStringToValues.sql $
  $Author: Cjaeggi $
  $Modtime: 14.01.10 11:23 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to split given string with delimiter to its parts
    @SplitString:  The string value to split with given delimiter
    @Delimiter:    The delimiter char to split given string value
    @RemoveEmptys: Flag to remove or leave empty entries (0=leave, 1=remove empty entries)
  -
  RETURNS: Table containing empty and non-empty values found in string with its index
  -
  TEST:    SELECT * FROM dbo.fnSplitStringToValues(',a,b,,c,d', ',', 0)
           SELECT * FROM dbo.fnSplitStringToValues(',a,b,,c,d', ',', 1)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/System/fnSplitStringToValues.sql $
 * 
 * 3     14.01.10 11:24 Cjaeggi
 * #672: Updated to fit sql-coding rules
 * 
 * 2     10.08.09 9:05 Cjaeggi
 * Added new function
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 17:29 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnSplitStringToValues
(
  @SplitString VARCHAR(8000),
  @Delimiter VARCHAR(1),
  @RemoveEmptys BIT
)
RETURNS @Result TABLE
(
  OccurenceID INT IDENTITY(0, 1),
  SplitValue VARCHAR(200) NOT NULL
)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@SplitString IS NULL OR @Delimiter IS NULL)
  BEGIN
    -- do nothing due to invalid values
    RETURN;
  END;
  
  -- NULL for bit is false
  SET @RemoveEmptys = ISNULL(@RemoveEmptys, 0);
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @IndexCounter INT;
  DECLARE @SplitLength INT;
  
  -----------------------------------------------------------------------------
  -- parse string and retrieve values
  -----------------------------------------------------------------------------
  WHILE LEN(@SplitString) > 0
  BEGIN
    SELECT @SplitLength =  CASE CHARINDEX(@Delimiter, @SplitString) 
                             WHEN 0 THEN LEN(@SplitString)
                             ELSE CHARINDEX(@Delimiter, @SplitString) - 1
                           END;

    INSERT INTO @Result
      SELECT SUBSTRING(@SplitString, 1, @SplitLength)
      SELECT @SplitString = CASE (LEN(@SplitString) - @SplitLength)
                              WHEN 0 THEN ''
                              ELSE RIGHT(@SplitString, LEN(@SplitString) - @SplitLength - 1)
                            END;
  END;
  
  -----------------------------------------------------------------------------
  -- remove empty values
  -----------------------------------------------------------------------------
  IF (@RemoveEmptys = 1)
  BEGIN
    -- remove all entries without value
    DELETE FROM @Result
    WHERE ISNULL(SplitValue, '') = '';
  END;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN;
END;
GO