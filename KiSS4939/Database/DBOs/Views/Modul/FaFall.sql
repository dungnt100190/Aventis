SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject FaFall;
GO
/*===============================================================================================
  $Revision: 5 $
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

CREATE VIEW dbo.FaFall
AS
SELECT
  FaFallID   = PRS.BaPersonID,
  UserID     = LEI.UserID,
  BaPersonID = PRS.BaPersonID,
  DatumVon   = CONVERT(DATETIME, NULL),
  DatumBis   = CONVERT(DATETIME, NULL)
FROM dbo.BaPerson            PRS WITH (READUNCOMMITTED) 
  CROSS APPLY (
    SELECT TOP 1 LEI1.FaLeistungID, UserID
    FROM FaLeistung LEI1
    WHERE LEI1.ModulID IN (2, 7)
      AND LEI1.BaPersonID = PRS.BaPersonID
    ORDER BY LEI1.ModulID, LEI1.DatumVon ASC, LEI1.FaLeistungID DESC
  ) LEI
GO