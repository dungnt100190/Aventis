SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnXKurzMonat
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

CREATE FUNCTION dbo.fnXKurzMonat
 (@Monat int)
 RETURNS varchar(10)
AS 

BEGIN
  DECLARE @FormatDate varchar(10)

  SET @FormatDate = CASE @Monat
                      WHEN  1 THEN 'Jan'
                      WHEN  2 THEN 'Feb'
                      WHEN  3 THEN 'März'
                      WHEN  4 THEN 'Apr'
                      WHEN  5 THEN 'Mai'
                      WHEN  6 THEN 'Juni'
                      WHEN  7 THEN 'Juli'
                      WHEN  8 THEN 'Aug'
                      WHEN  9 THEN 'Sep'
                      WHEN 10 THEN 'Okt'
                      WHEN 11 THEN 'Nov'
                      WHEN 12 THEN 'Dez'
                      ELSE ''
                    END

   RETURN(@FormatDate)
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
