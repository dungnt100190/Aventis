-------------------------------------------------------------------------------
-- init vars
-------------------------------------------------------------------------------
DECLARE @LOVName VARCHAR(100)
DECLARE @System BIT
DECLARE @Expandable BIT

-------------------------------------------------------------------------------
-- set vars
-------------------------------------------------------------------------------
SET @LOVName    = 'xxx'
SET @System     = 1
--
SET @Expandable = NULL  -- if NULL, then inverting @System

-------------------------------------------------------------------------------
-- security lock!
-------------------------------------------------------------------------------
--RETURN

-------------------------------------------------------------------------------
-- do update
-------------------------------------------------------------------------------
IF (@Expandable IS NULL)
BEGIN
  SET @Expandable = CASE WHEN @System = 0 THEN 1
                         ELSE 0
                    END
END

--lov
UPDATE XLOV 
SET System = @System, 
    Expandable = @Expandable
WHERE LOVName = @LOVName

-- lovcode
UPDATE XLOVCode
SET System = @System 
WHERE LOVName = @LOVName