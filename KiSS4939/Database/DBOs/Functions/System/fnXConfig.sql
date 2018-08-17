SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXConfig;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/System/fnXConfig.sql $
  $Author: Cjaeggi $
  $Modtime: 18.02.10 9:52 $
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Get the specific XConfig.ValueVar value for given config entry
    @KeyPath:  The identification key of the config value
    @DatumVon: The date to get date critical config value if multiple entries are defined
  -
  RETURNS: If the config value has a matching date, return its ValueVar value, otherwise
           the original value will be returned if config value exists.
           
           !WARNING! SQL_VARIANT does not support VARCHAR bigger than 8000 bytes, so for long
           VARCHAR values, use the function fnXConfigVarchar!
  -
  TEST:    SELECT dbo.fnXConfig('System\Basis\BaLand_Schweiz', GETDATE());
           SELECT dbo.fnXConfig('System\Basis\BaLand_Schweiz', '2010-01-01');
           SELECT dbo.fnXConfig('System\Basis\BaLand_Schweiz', '2009-01-01');
           SELECT dbo.fnXConfig('System\Basis\BaLand_Schweiz', '1753-01-01');
=================================================================================================
  WARNING: This object is shared in Visual SourceSafe, beware of changes!
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/System/fnXConfig.sql $
 * 
 * 5     18.02.10 10:28 Cjaeggi
 * #5521: Fixed functions to fit default behaviour as in C# code (show
 * config entries even if no matching date with its default original
 * value)
 * 
 * 4     17.02.10 14:57 Cjaeggi
 * #5521: Added shared fnXConfig
 * 
 * 3     17.02.10 14:56 Cjaeggi
 * #5521: BugFix with date of config value, return OriginalValue
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
=================================================================================================*/

CREATE FUNCTION dbo.fnXConfig
(
  @KeyPath VARCHAR(500),
  @DatumVon DATETIME = NULL
)
RETURNS SQL_VARIANT
AS BEGIN
  -----------------------------------------------------------------------------
  -- init vars
  -----------------------------------------------------------------------------
  DECLARE @ConfigValue SQL_VARIANT;
  SET @ConfigValue = NULL;
  
  -----------------------------------------------------------------------------
  -- try to get value
  -----------------------------------------------------------------------------
  SELECT TOP 1
         @ConfigValue = CASE 
                          WHEN CNF.DatumVon IS NULL THEN -- if no date is given, entry is inactive > return default value
                                                      CASE CNF.ValueCode
                                                        WHEN 2 THEN CAST(CNF.OriginalValueInt AS SQL_VARIANT)
                                                        WHEN 3 THEN CAST(CNF.OriginalValueDecimal AS SQL_VARIANT)
                                                        WHEN 4 THEN CAST(CNF.OriginalValueMoney AS SQL_VARIANT)
                                                        WHEN 5 THEN CAST(CNF.OriginalValueBit AS SQL_VARIANT)
                                                        WHEN 6 THEN CAST(CNF.OriginalValueDateTime AS SQL_VARIANT)
                                                        ELSE CAST(CONVERT(VARCHAR(8000), CNF.OriginalValueVarchar) AS SQL_VARIANT)
                                                      END
                          ELSE -- if date is given, get corresponding value
                            CASE CNF.ValueCode
                              WHEN 2 THEN CAST(CNF.ValueInt AS SQL_VARIANT)
                              WHEN 3 THEN CAST(CNF.ValueDecimal AS SQL_VARIANT)
                              WHEN 4 THEN CAST(CNF.ValueMoney AS SQL_VARIANT)
                              WHEN 5 THEN CAST(CNF.ValueBit AS SQL_VARIANT)
                              WHEN 6 THEN CAST(CNF.ValueDateTime AS SQL_VARIANT)
                              ELSE CAST(CONVERT(VARCHAR(8000), CNF.ValueVarchar) AS SQL_VARIANT)
                            END
                        END
  FROM dbo.XConfig CNF WITH (READUNCOMMITTED)
  WHERE CNF.KeyPath = @KeyPath
    AND (ISNULL(CNF.DatumVon, '1753-01-01') <= ISNULL(@DatumVon, '1753-01-01'))
  ORDER BY DatumVon DESC;
  
  -----------------------------------------------------------------------------
  -- if no value is given, try to get any original value
  -----------------------------------------------------------------------------
  IF (@ConfigValue IS NULL)
  BEGIN
    SELECT TOP 1
           @ConfigValue = CASE CNF.ValueCode
                            WHEN 2 THEN CAST(CNF.OriginalValueInt AS SQL_VARIANT)
                            WHEN 3 THEN CAST(CNF.OriginalValueDecimal AS SQL_VARIANT)
                            WHEN 4 THEN CAST(CNF.OriginalValueMoney AS SQL_VARIANT)
                            WHEN 5 THEN CAST(CNF.OriginalValueBit AS SQL_VARIANT)
                            WHEN 6 THEN CAST(CNF.OriginalValueDateTime AS SQL_VARIANT)
                            ELSE CAST(CONVERT(VARCHAR(8000), CNF.OriginalValueVarchar) AS SQL_VARIANT)
                          END
    FROM dbo.XConfig CNF WITH (READUNCOMMITTED)
    WHERE CNF.KeyPath = @KeyPath
      AND (CNF.OriginalValueVarchar IS NOT NULL OR
           CNF.OriginalValueInt IS NOT NULL OR
           CNF.OriginalValueDecimal IS NOT NULL OR
           CNF.OriginalValueMoney IS NOT NULL OR
           CNF.OriginalValueBit IS NOT NULL OR
           CNF.OriginalValueDateTime IS NOT NULL)
    ORDER BY DatumVon DESC;
  END;
  
  -----------------------------------------------------------------------------
  -- return value
  -----------------------------------------------------------------------------
  RETURN (@ConfigValue);
END;
GO