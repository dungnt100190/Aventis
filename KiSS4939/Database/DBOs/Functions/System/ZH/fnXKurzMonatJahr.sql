SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnXKurzMonatJahr
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

CREATE FUNCTION dbo.fnXKurzMonatJahr
 (@DATE datetime)
 RETURNS varchar(16)
AS 

BEGIN
  DECLARE @FormatDate varchar(16)

  SET @FormatDate = dbo.fnXKurzMonat(DatePart(mm, @DATE)) + ' ' +
                    CONVERT(varchar, DatePart(YYYY, @DATE))

  RETURN(@FormatDate)
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
