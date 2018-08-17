SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXConfigChild;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/System/fnXConfigChild.sql $
  $Author: Cjaeggi $
  $Modtime: 18.02.10 10:33 $
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Get all config child values for given key path.
    @KeyPath:  The identification key of the config value
    @DatumVon: The date to get date critical config value if multiple entries are defined
  -
  RETURNS: If a config value has a matching date, return its ValueVar value, otherwise
           the original value will be returned if config value exists
  -
  TEST:    SELECT * FROM dbo.fnXConfigChild('System\Basis', GETDATE());
           SELECT * FROM dbo.fnXConfigChild('System\Basis', '2009-01-01');
           SELECT * FROM dbo.fnXConfigChild('System\Basis', '1753-01-01');
           SELECT * FROM dbo.fnXConfigChild('System\Basis\Bankenstamm', GETDATE());
           SELECT * FROM dbo.fnXConfigChild('System\Basis\Bankenstamm', '1753-01-01');
=================================================================================================
  WARNING: This object is shared in Visual SourceSafe, beware of changes!
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/System/fnXConfigChild.sql $
 * 
 * 5     18.02.10 10:33 Cjaeggi
 * #5521: Added shared-warning
 * 
 * 4     18.02.10 10:29 Cjaeggi
 * #5521: Fixed functions to fit default behaviour as in C# code (show
 * config entries even if no matching date with its default original
 * value)
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     18.09.08 13:59 Cjaeggi
 * Comment and format
 * 
 * 1     3.09.08 17:51 Aklopfenstein
=================================================================================================*/

CREATE FUNCTION dbo.fnXConfigChild
(
  @KeyPath VARCHAR(500),
  @DatumVon DATETIME = NULL
)
RETURNS @Result TABLE 
(
  KeyPath VARCHAR(500) COLLATE DATABASE_DEFAULT,
  Child VARCHAR(500) COLLATE DATABASE_DEFAULT,
  ValueVar SQL_VARIANT
)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate first
  -----------------------------------------------------------------------------
  IF (@KeyPath IS NULL OR @DatumVon IS NULL)
  BEGIN
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- fix path if needed
  -----------------------------------------------------------------------------
  IF (RIGHT(@KeyPath, 1) != '\') 
  BEGIN
    SET @KeyPath = @KeyPath + '\';
  END;
  
  -----------------------------------------------------------------------------
  -- get all keys with its current value
  -----------------------------------------------------------------------------
  INSERT INTO @Result
    SELECT DISTINCT  -- each key only once
           KeyPath  = CNF.KeyPath, 
           Child    = CAST(SUBSTRING(CNF.KeyPath, LEN(@KeyPath) + 1, 500) AS VARCHAR),
           ValueVar = dbo.fnXConfig(CNF.KeyPath, @DatumVon)
    FROM dbo.XConfig CNF WITH (READUNCOMMITTED)
    WHERE CNF.KeyPath LIKE @KeyPath + '%' 
      AND CNF.KeyPath NOT LIKE @KeyPath + '%\%'
    ORDER BY CNF.KeyPath;
  
  -----------------------------------------------------------------------------
  -- done, return result
  -----------------------------------------------------------------------------
  RETURN;
END;
GO