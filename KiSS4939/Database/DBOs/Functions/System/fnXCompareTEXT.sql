SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXCompareTEXT;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnXCompareTEXT.sql $
  $Author: Cjaeggi $
  $Modtime: 18.03.10 17:24 $
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
  $Log: /KiSS4/Database/DBOs/Functions/System/fnXCompareTEXT.sql $
 * 
 * 3     18.03.10 17:24 Cjaeggi
 * Revised for coding rules
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
=================================================================================================*/

CREATE FUNCTION dbo.fnXCompareTEXT
(
  @Value_A TEXT,
  @Value_B TEXT
)
RETURNS BIT
AS BEGIN
  IF (@Value_A IS NULL AND @Value_B IS NULL) 
  BEGIN 
    RETURN 1;
  END;
  
  IF (@Value_A IS NULL AND @Value_B IS NOT NULL) 
  BEGIN 
    RETURN 0;
  END;
  
  IF (@Value_A IS NOT NULL AND @Value_B IS NULL) 
  BEGIN 
    RETURN 0;
  END;
  
  IF (DATALENGTH(@Value_A) <> DATALENGTH(@Value_A))
  BEGIN
    RETURN 0;
  END;

  DECLARE @Index INT;
  DECLARE @MaxIndex INT;
  
  SELECT @Index = 1, 
         @MaxIndex = DATALENGTH(@Value_A);
  
  WHILE (@Index <= @MaxIndex)
  BEGIN
    IF (SUBSTRING(@Value_A, @Index, 8000) <> SUBSTRING(@Value_B, @Index, 8000))
    BEGIN
      RETURN 0;
    END;
    
    SET @Index = @Index + 8000;
  END;
  
  RETURN 1;
END;
GO