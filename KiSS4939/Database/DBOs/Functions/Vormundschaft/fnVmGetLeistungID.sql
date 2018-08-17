SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnVmGetLeistungID
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Gibt die aktuellste V- oder KES-Leistung einer Person zurück
    @BaPersonID: ID der Person
  -
  RETURNS: FaLeistungID 
  -
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnVmGetLeistungID
(
  @BaPersonID INT
)
RETURNS INT
AS
BEGIN
  -- Select FaLeistungID FaLeistung
  -- If open VormundschaftlicheMassnahme exists take DateFrom this
  -- If VormundschaftlicheMassnahme doesn't exist take current DateFrom

  DECLARE @rslt INT

  SELECT @rslt = FaLeistungID
  FROM dbo.FaLeistung WITH (READUNCOMMITTED) 
  WHERE BaPersonID = @BaPersonID
    AND ModulID IN (5, 29)
    AND FaProzessCode IN (501, 2900)
    AND DatumBis IS NULL;

  IF (@rslt IS NULL OR @rslt < 0) 
  BEGIN
    SELECT TOP 1 @rslt = FaLeistungID
    FROM dbo.FaLeistung WITH (READUNCOMMITTED) 
    WHERE BaPersonID = @BaPersonID
      AND ModulID IN (5, 29)
    ORDER BY DatumVon DESC;
  END;

  RETURN @rslt;
END
GO