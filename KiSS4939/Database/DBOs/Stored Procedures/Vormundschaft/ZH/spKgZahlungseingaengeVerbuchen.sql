SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgZahlungseingaengeVerbuchen
GO
/*===============================================================================================
  $Revision: 4$
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
CREATE PROCEDURE dbo.spKgZahlungseingaengeVerbuchen
AS 

EXEC dbo.spKgZahlungseingaengeVerbuchenSVA;
EXEC dbo.spKgZahlungseingaengeVerbuchenAZL;

GO

