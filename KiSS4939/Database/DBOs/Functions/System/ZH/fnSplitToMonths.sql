SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnSplitToMonths
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Gibt jeweils den ersten Tag jedes Monats in der Periode zwischen DatumVon und DatumBis zurück
  -
  RETURNS: Table containing empty and non-empty values found in string with its index
  -
=================================================================================================
  TEST:    
=================================================================================================*/

CREATE FUNCTION dbo.fnSplitToMonths
(
  @DatumVon datetime, 
  @DatumBis datetime
)
RETURNS 
@Dates TABLE 
(
  FirstDayOfMonth datetime
)
AS
BEGIN
  IF @DatumVon IS NULL OR @DatumBis IS NULL OR @DatumVon > @DatumBis
  BEGIN
    RETURN
  END
  DECLARE @CurrentDate datetime
  SET @CurrentDate = dbo.fnFirstDayOf(@DatumVon)
  WHILE @CurrentDate <= @DatumBis
  BEGIN
    INSERT INTO @Dates VALUES (@currentDate)
    SET @CurrentDate = DATEADD(MONTH, 1, @CurrentDate)
  END
  RETURN 
END
GO