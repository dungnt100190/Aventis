SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEConvertMoneyToHHMM;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEConvertMoneyToHHMM.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:12 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get convert money value to time value (hours, minutes, ...)
    @Value:  The value to convert
    @Format: The format or convertion to use ('hh:mm'=hours and minutes, 'hours'=only hours, 'minutes'=only minutes)
  -
  RETURNS: Converted value as varchar
  -
  TEST:    SELECT [dbo].[fnBDEConvertMoneyToHHMM](-3.5, 'hh:mm')
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEConvertMoneyToHHMM.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEConvertMoneyToHHMM
(
  @Value money,
  @Format varchar(10)
)
RETURNS varchar(50)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not value is passed, invalid value
  IF (@Value IS NULL)
  BEGIN
    RETURN ''
  END

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @OUTPUT varchar(50)
  DECLARE @ValueAsFloat float

  SET @ValueAsFloat = CONVERT(float, @Value)

  -----------------------------------------------------------------------------
  -- format depending convertion
  -----------------------------------------------------------------------------
  IF (@Format = 'hh:mm')
  BEGIN
    -- hours and minutes, handle negative value separated
    IF (@Value < 0)
    BEGIN
      -- negative
      SET @OUTPUT = '-' + CONVERT(varchar(100), FLOOR(-@ValueAsFloat)) + ':' + RIGHT('0' + CONVERT(varchar(100), ROUND((-@ValueAsFloat-FLOOR(-@ValueAsFloat))*60, 0)), 2)
    END
    ELSE
    BEGIN
      -- positive
      SET @OUTPUT = CONVERT(varchar(100), FLOOR(@ValueAsFloat)) + ':' + RIGHT('0' + CONVERT(varchar(100), ROUND((@ValueAsFloat-FLOOR(@ValueAsFloat))*60, 0)), 2)
    END
  END
  ELSE IF (@Format = 'hours')
  BEGIN
    -- only hours, negative has to be handled specially
    SET @OUTPUT = CASE WHEN @ValueAsFloat < 0 THEN -FLOOR(-@ValueAsFloat)
                       ELSE FLOOR(@ValueAsFloat)
                  END
  END
  ELSE IF (@Format = 'minutes')
  BEGIN
    -- only minutes, minutes can never be negative but handled specially due to calculation
    SET @OUTPUT = CASE WHEN @ValueAsFloat < 0 THEN ROUND((-@ValueAsFloat-FLOOR(-@ValueAsFloat))*60, 0)
                       ELSE ROUND((@ValueAsFloat-FLOOR(@ValueAsFloat))*60, 0)
                  END
  END

  -----------------------------------------------------------------------------
  -- check and return value
  ----------------------------------------------------------------------------- 
  RETURN IsNull(@OUTPUT, '')
END
GO