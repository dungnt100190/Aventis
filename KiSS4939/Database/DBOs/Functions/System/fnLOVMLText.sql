SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnLOVMLText;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnLOVMLText.sql $
  $Author: Cjaeggi $
  $Modtime: 18.03.10 16:29 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: returns value in desired language, if not exists in default language
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/fnLOVMLText.sql $
 * 
 * 3     18.03.10 16:30 Cjaeggi
 * Revised for coding rules
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 16:41 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnLOVMLText
(
  @LOVName VARCHAR(100),
  @Code INT,
  @LanguageCode INT
)
RETURNS VARCHAR(200)
AS BEGIN
  DECLARE @Text VARCHAR(200);
  
  SELECT @Text = ISNULL(TXT.Text, LOV.Text)
  FROM dbo.XLOVCode         LOV WITH (READUNCOMMITTED)
    LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = LOV.TextTID 
                                                      AND TXT.LanguageCode = @LanguageCode
  WHERE LOV.LOVName = @LOVName
    AND LOV.Code = @Code;
  
  RETURN ISNULL(@Text, '');
END;
GO