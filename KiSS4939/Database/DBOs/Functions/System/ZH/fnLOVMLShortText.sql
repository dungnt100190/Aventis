SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnLOVMLShortText
GO
/*===============================================================================================
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
=================================================================================================
  TEST:    .
=================================================================================================*/

------- returns value in desired language, if not exists in default language
CREATE FUNCTION dbo.fnLOVMLShortText
 (@LOVName      varchar(100),
  @Code         int,
  @LanguageCode int)
 RETURNS varchar(20)
AS 

BEGIN
  DECLARE @ShortText varchar(20)

  SELECT @ShortText = IsNull(TXT.Text, LOV.ShortText)
  FROM   dbo.XLOVCode        LOV WITH (READUNCOMMITTED) 
    LEFT  JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = LOV.ShortTextTID AND TXT.LanguageCode = @LanguageCode
  WHERE  LOV.LOVName = @LOVName
     AND LOV.Code = @Code

  IF @ShortText IS NULL SET @ShortText = ''

  RETURN (@ShortText)
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
