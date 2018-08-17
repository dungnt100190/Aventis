SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetSQLMLText;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnGetSQLMLText.sql $
  $Author: Cjaeggi $
  $Modtime: 17.03.10 13:30 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/fnGetSQLMLText.sql $
 * 
 * 3     17.03.10 13:30 Cjaeggi
 * Revised for coding rules
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
=================================================================================================*/

CREATE FUNCTION dbo.fnGetSQLMLText
(
  @SpFnName VARCHAR(100),
  @TextName VARCHAR(100),
  @DefaultText VARCHAR(2000),
  @LanguageCode INT
)
RETURNS VARCHAR(2000)
AS BEGIN
  RETURN ISNULL((SELECT dbo.fnGetMLText(MessageTID, @LanguageCode)
                 FROM dbo.XMessage WITH (READUNCOMMITTED)
                 WHERE MessageName = @TextName 
                   AND MaskName = @SpFnName), @DefaultText);
END;
GO