SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnGetDate
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

CREATE FUNCTION dbo.fnGetDate
(
	@ExportDBDate numeric(8,0)
)
RETURNS datetime
AS
BEGIN
  IF( @ExportDBDate < 17530101 OR @ExportDBDate > 99991231)
    RETURN NULL

  IF( @ExportDBDate % 10000 = 0)
    SET @ExportDBDate = @ExportDBDate + 101

  RETURN CAST(CAST(@ExportDBDate AS varchar(8)) AS datetime)

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
