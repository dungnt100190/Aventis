SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE dbo.spDropObject vwTmAbrechnung
GO
/*===============================================================================================
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
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE VIEW dbo.vwTmAbrechnung
AS

SELECT 
  ABR.WhAbrechnungID, 
  ABR.DatumBis, 
  ABR.DatumVon
FROM dbo.WhAbrechnung ABR WITH (READUNCOMMITTED);
GO