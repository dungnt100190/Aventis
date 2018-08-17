SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXSetXLangText;
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

CREATE PROCEDURE dbo.spXSetXLangText
(
  @TID INT,
  @LanguageCode INT,
  @Text VARCHAR(2000),
  @ClassName VARCHAR(255) = NULL,   -- LOV: use lovname
  @ControlName VARCHAR(255) = NULL,
  @TypeCode INT,                    -- 0: control, 1: component, 2: class, 3: menu, 4: LOVText, 5: LOVShortText, 6: LOVValue1, 7: LOVValue2, 8: LOVValue3
  @Index INT,                       -- indentify datarow to update; for LOV: code
  @rslt INT OUT
)
AS 
BEGIN
  IF (@TID IS NULL AND @ClassName IS NOT NULL AND @ControlName IS NOT NULL)
  BEGIN
    -- XClass, XClassControl, XClassComponent
    INSERT INTO dbo.XLangText (LanguageCode, Text) 
    VALUES (@LanguageCode, @Text);
    
    SET @TID = SCOPE_IDENTITY();
    
    IF (@TypeCode = 0)
    BEGIN
       UPDATE dbo.XClassControl
       SET ControlTID = @TID
       WHERE ClassName = @ClassName 
         AND ControlName = @ControlName;
    END
    ELSE IF (@TypeCode = 1)
    BEGIN
       UPDATE dbo.XClassComponent
       SET ComponentTID = @TID
       WHERE ClassName = @ClassName 
         AND ComponentName = @ControlName;
    END
    ELSE IF (@TypeCode = 2)
    BEGIN
       UPDATE dbo.XClass
       SET ClassTID = @TID
       WHERE ClassName = @ClassName;
    END;
  END
  ELSE IF (@TID IS NULL AND @Index IS NOT NULL AND @TypeCode = 3)
  BEGIN
    -- XMenuItem
    INSERT INTO dbo.XLangText (LanguageCode, Text)
    VALUES (@LanguageCode, @Text);
    
    SET @TID = SCOPE_IDENTITY();
    
    UPDATE dbo.XMenuItem
    SET MenuTID = @TID
    WHERE MenuItemID = @Index;
  END
  ELSE IF (@TID IS NULL AND @Index IS NOT NULL AND @ClassName IS NOT NULL AND @TypeCode = 4)
  BEGIN
    -- XLOVCode (Text)
    INSERT INTO dbo.XLangText (LanguageCode, Text) 
    VALUES (@LanguageCode, @Text);
    
    SET @TID = SCOPE_IDENTITY();
    
    UPDATE dbo.XLOVCode
    SET TextTID = @TID
    WHERE LOVName = @ClassName 
      AND Code = @Index;
  END
  ELSE IF (@TID IS NULL AND @Index IS NOT NULL AND @ClassName IS NOT NULL AND @TypeCode = 5)
  BEGIN
    -- XLOVCode (ShortText)
    INSERT INTO dbo.XLangText (LanguageCode, Text) 
    VALUES (@LanguageCode, @Text);
    
    SET @TID = SCOPE_IDENTITY();
    
    UPDATE dbo.XLOVCode
    SET ShortTextTID = @TID
    WHERE LOVName = @ClassName 
      AND Code = @Index;
  END
  ELSE IF (@TID IS NULL AND @Index IS NOT NULL AND @ClassName IS NOT NULL AND @TypeCode = 6)
  BEGIN
    -- XLOVCode (Value1)
    INSERT INTO dbo.XLangText (LanguageCode, Text) 
    VALUES (@LanguageCode, @Text);
    
    SET @TID = SCOPE_IDENTITY();
    
    UPDATE dbo.XLOVCode
    SET Value1TID = @TID
    WHERE LOVName = @ClassName 
      AND Code = @Index;
  END
  ELSE IF (@TID IS NULL AND @Index IS NOT NULL AND @ClassName IS NOT NULL AND @TypeCode = 7)
  BEGIN
    -- XLOVCode (Value2)
    INSERT INTO dbo.XLangText (LanguageCode, Text) 
    VALUES (@LanguageCode, @Text);
    
    SET @TID = SCOPE_IDENTITY();
    
    UPDATE XLOVCode
    SET Value2TID = @TID
    WHERE LOVName = @ClassName 
      AND Code = @Index;
  END
  ELSE IF (@TID IS NULL AND @Index IS NOT NULL AND @ClassName IS NOT NULL AND @TypeCode = 8)
  BEGIN
    -- XLOVCode (Value3)
    INSERT INTO dbo.XLangText (LanguageCode, Text)
    VALUES (@LanguageCode, @Text);
    
    SET @TID = SCOPE_IDENTITY();
    
    UPDATE dbo.XLOVCode
    SET Value3TID = @TID
    WHERE LOVName = @ClassName 
      AND Code = @Index;
  END
  ELSE IF (EXISTS(SELECT TOP 1 1 
                  FROM dbo.XLangText WITH (READUNCOMMITTED)
                  WHERE TID = @TID 
                    AND LanguageCode = @LanguageCode))
  BEGIN
    -- XLangText
    UPDATE dbo.XLangText
    SET Text = @Text
    WHERE TID = @TID 
      AND LanguageCode = @LanguageCode;
  END
  ELSE IF (@TID IS NOT NULL)
  BEGIN
    -- XLangText
    SET IDENTITY_INSERT XLangText ON;

    INSERT INTO dbo.XLangText (TID, LanguageCode, Text)
    VALUES (@TID, @LanguageCode, @Text);
    
    SET IDENTITY_INSERT XLangText OFF;
  END
  ELSE IF (@TID IS NULL AND @ClassName IS NULL AND @ControlName IS NULL AND @Text IS NOT NULL)
  BEGIN
    -- XLangText
    INSERT INTO dbo.XLangText (LanguageCode, Text) 
    VALUES (@LanguageCode, @Text);
    
    SET @TID = SCOPE_IDENTITY();
  END
  ELSE
  BEGIN
    -- invalid
    SET @TID = NULL;
  END;
  
  -----------------------------------------------------------------------------
  -- done, return TID (OUT parameter)
  -----------------------------------------------------------------------------
  SET @rslt = @TID;
END;
GO