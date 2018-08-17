SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnSortLOVList;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnSortLOVList.sql $
  $Author: Cjaeggi $
  $Modtime: 18.03.10 17:03 $
  $Revision: 4 $
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
  $Log: /KiSS4/Database/DBOs/Functions/System/fnSortLOVList.sql $
 * 
 * 4     18.03.10 17:04 Cjaeggi
 * Fixed bug with sorting AZ to INT
 * 
 * 3     18.03.10 16:51 Cjaeggi
 * Revised for coding rules
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
=================================================================================================*/

CREATE FUNCTION dbo.fnSortLOVList
(
  @Codes VARCHAR(100)
)
RETURNS VARCHAR(100)
AS BEGIN
  IF (@Codes IS NULL)
  BEGIN
    RETURN NULL;
  END;
  
  DECLARE @LOV TABLE 
  (
    Code INT
  );
  
  DECLARE @Code VARCHAR(5);
  DECLARE @CodeInt INT;
  DECLARE @Idx INT;
  DECLARE @Liste VARCHAR(1000);
  
  SET @Idx = 1;
  
  WHILE (@Idx <= LEN(@Codes))
  BEGIN
    -- nicht numerische Zeichen überspringen
    WHILE (@Idx <= LEN(@Codes) AND NOT SUBSTRING(@Codes, @Idx, 1) BETWEEN '0' AND '9')
    BEGIN
      SET @Idx = @Idx + 1;
    END;
    
    -- Code aufbauen
    SET @Code = '';
    
    WHILE (@Idx <= LEN(@Codes) AND SUBSTRING(@Codes,@Idx,1) BETWEEN '0' AND '9')
    BEGIN
      SET @Code = @Code + SUBSTRING(@Codes, @Idx, 1);
      SET @Idx = @Idx + 1;
    END;

    IF (@Code <> '')
    BEGIN
      INSERT INTO @LOV (Code)
      VALUES (CONVERT(INT, @Code));
    END;
  END;

  DECLARE cLOVList CURSOR FAST_FORWARD FOR
    SELECT DISTINCT Code
    FROM @LOV
    ORDER BY Code ASC;
  
  SET @Liste = '';
  
  OPEN cLOVList;
  
  WHILE (1 = 1)
  BEGIN
    FETCH NEXT 
    FROM cLOVList 
    INTO @CodeInt;
    
    IF (@@FETCH_STATUS != 0)
    BEGIN
      BREAK;
    END;
    
    IF (@Liste <> '')
    BEGIN
      SET @Liste = @Liste + ',';
    END;
    
    SET @Liste = @Liste + CONVERT(VARCHAR, @CodeInt);
  END;
  
  CLOSE cLOVList;
  DEALLOCATE cLOVList;
  
  RETURN @Liste;
END;
GO