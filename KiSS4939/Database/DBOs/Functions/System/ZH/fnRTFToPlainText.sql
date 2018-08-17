SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnRTFToPlainText
GO
/*===============================================================================================
  $Revision: 8 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnRTFToPlainText
 (@inRTF text)
 RETURNS varchar(MAX)
AS BEGIN
  DECLARE @RTF  varchar(MAX)
  DECLARE @Text varchar(MAX)
  DECLARE @Idx   int
  DECLARE @Level int
  DECLARE @InsideFormat bit
  DECLARE @char varchar

  SET @Idx = 1
  SET @Level = 0
  SET @InsideFormat = 0
  SET @Text = ''

  SET @RTF = CONVERT(varchar(MAX),@inRTF)
  SET @RTF = replace(@RTF,'\par','')

  -- Ersetze Umlaute
  SET @RTF = replace(@RTF,'\''e4','ä')
  SET @RTF = replace(@RTF,'\''f6','ö')
  SET @RTF = replace(@RTF,'\''fc','ü')
  SET @RTF = replace(@RTF,'\''c4','Ä')
  SET @RTF = replace(@RTF,'\''d6','Ö')
  SET @RTF = replace(@RTF,'\''dc','Ü')
  SET @RTF = replace(@RTF,'\''e8','è')
  SET @RTF = replace(@RTF,'\''e9','é')
  SET @RTF = replace(@RTF,'\''e0','à')
  SET @RTF = replace(@RTF,'\''c8','È')
  SET @RTF = replace(@RTF,'\''c9','É')
  SET @RTF = replace(@RTF,'\''c0','À')

  IF SubString(@RTF,1,1) = '{' BEGIN
    SET @RTF = SubString(@RTF,2,len(@RTF)-2)
  END

  WHILE @Idx <= LEN(@RTF) BEGIN

    SET @char = SubString(@RTF,@Idx,1)

    IF @char = '{' BEGIN
      SET @Level = @Level + 1
    END ELSE IF @char = '}' BEGIN
      SET @Level = @Level - 1
      SET @InsideFormat = 0
    END ELSE IF @char = '\' BEGIN
      IF @Level = 0 SET @InsideFormat = 1
    END ELSE IF @char = ' ' BEGIN
      IF @InsideFormat = 1 OR @Level > 0 BEGIN
        SET @InsideFormat = 0
      END ELSE BEGIN
        SET @Text = @Text + @char
      END
    END ELSE BEGIN
      IF @InsideFormat = 0 AND @Level = 0 BEGIN
        SET @Text = @Text + @char
      END
    END
    SET @Idx = @Idx + 1
  END

  RETURN @Text
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
