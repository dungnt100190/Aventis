SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spAddReplaceLOVExt;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spAddReplaceLOVExt
(
  @LOVName VARCHAR(100),
  @Description VARCHAR(500),
  @System BIT,
  @Expandable BIT,
  @ModulID INT,
  @NameValue1 VARCHAR(100) = NULL,
  @NameValue2 VARCHAR(100) = NULL,
  @NameValue3 VARCHAR(100) = NULL
)
AS
BEGIN
  IF (EXISTS (SELECT TOP 1 1 
              FROM dbo.XLOV WITH (READUNCOMMITTED) 
              WHERE LOVName = @LOVName))
  BEGIN
    UPDATE dbo.XLOV
    SET [Description] = @Description,
        [System]      = @System,
        Expandable    = @Expandable,
        ModulID       = @ModulID,
        NameValue1    = @NameValue1,
        NameValue2    = @NameValue2,
        NameValue3    = @NameValue3
    WHERE LOVName = @LOVName;
  END
  ELSE
  BEGIN
    INSERT INTO dbo.XLOV (LOVName, [Description], [System], Expandable, ModulID, NameValue1, NameValue2, NameValue3)
    VALUES (@LOVName, @Description, @System, @Expandable, @ModulID, @NameValue1, @NameValue2, @NameValue3);
  END;
END;
GO
