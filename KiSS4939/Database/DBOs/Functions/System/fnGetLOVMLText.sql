SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetLOVMLText;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/System/fnGetLOVMLText.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:39 $
  $Revision: 2 $
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
  $Log: /Database/KiSS4_PI_MasterDev/Functions/System/fnGetLOVMLText.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 16:41 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnGetLOVMLText
(
  @LOVName varchar(100),
  @LOVCode int,
  @LanguageCode int
)
RETURNS varchar(2000)
AS
BEGIN
  DECLARE @output VARCHAR(2000)

  SELECT @output = ISNULL(dbo.fnGetMLText(LOV.TextTID, @LanguageCode), LOV.Text)
  FROM dbo.XLOVCode LOV WITH (READUNCOMMITTED)
  WHERE LOV.LOVName = @LOVName AND LOV.Code = @LOVCode

  RETURN @output
END
GO