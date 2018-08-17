SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spAddReplaceLOVCodeExt;
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

CREATE PROCEDURE dbo.spAddReplaceLOVCodeExt
(
  @LOVName VARCHAR(100),
  @Code INT,
  @Text VARCHAR(200),
  @SortKey VARCHAR(100),
  @ShortText VARCHAR(20),
  @BFSCode INT,
  @Value1 VARCHAR(200) = NULL,
  @Value2 VARCHAR(100) = NULL,
  @Value3 VARCHAR(100) = NULL,
  @Description VARCHAR(500) = NULL,
  @System BIT = 1
)
AS 
BEGIN
  IF (EXISTS (SELECT TOP 1 1 
              FROM dbo.XLOVCode WITH (READUNCOMMITTED) 
              WHERE LOVName = @LOVName 
                AND Code = @Code))
  BEGIN
    UPDATE dbo.XLOVCode
    SET [Text]        = @Text,
        SortKey       = @SortKey,
        ShortText     = @ShortText,
        BFSCode       = @BFSCode,
        Value1        = @Value1,
        Value2        = @Value2,
        Value3        = @Value3,
        [Description] = @Description,
        [System]      = @System
    WHERE LOVName = @LOVName 
      AND Code = @Code;
  END
  ELSE
  BEGIN
    INSERT INTO dbo.XLOVCode (LOVName, Code, [Text], SortKey, ShortText, BFSCode, Value1, Value2, Value3, [Description], [System])
    VALUES (@LOVName, @Code, @Text, @SortKey, @ShortText, @BFSCode, @Value1, @Value2, @Value3, @Description, @System);
  END;
END;
GO
