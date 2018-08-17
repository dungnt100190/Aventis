SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnUserAccessGastrechtGueltigkeitZeitbereich
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
    Formel um die Gastrechtgültigkeit zu prüfen. Gib 1 zurück fast Gastrecht gültig.
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnUserAccessGastrechtGueltigkeitZeitbereich
(
  @StichDatum	 DATETIME,
  @DatumVon		 DATETIME,
  @DatumBis		 DATETIME
)
RETURNS BIT
AS BEGIN
RETURN CASE WHEN (@StichDatum >= @DatumVon AND @StichDatum < ISNULL(@DatumBis,'99991231')) THEN 1 ELSE 0 END;
END
GO
