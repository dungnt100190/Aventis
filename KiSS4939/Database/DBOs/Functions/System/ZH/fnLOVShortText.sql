SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnLOVShortText
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
--- returns fnLOVMLText with languageCode = 1

CREATE FUNCTION dbo.fnLOVShortText
 (@LOVName varchar(100),
  @Code    int)
 RETURNS varchar(20)
AS 

BEGIN
  RETURN dbo.fnLOVMLShortText(@LOVName, @Code, 1)
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
