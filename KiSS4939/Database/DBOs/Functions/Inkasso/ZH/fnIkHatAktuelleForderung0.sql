SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE dbo.spDropObject fnIkHatAktuelleForderung0
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description 
-------------------------------------------------------------------------------------------------
  SUMMARY: Um zu wissen ob die Leistung eine aktuelle Forderung = 0 hat
    @leiFaLeistungID:   FaLeistungID
  -
  RETURNS: 0 wenn die Leistung eine aktuelle Forderung = 0 hat, 0 wenn es > 0 ist
  -
=================================================================================================
  TEST:    dbo.fnIkHatAktuelleForderung0(7048501)
=================================================================================================*/

CREATE FUNCTION dbo.fnIkHatAktuelleForderung0
(
  @leiFaLeistungID int
)
RETURNS INT
AS BEGIN
  DECLARE @Result bit
  SET @Result = 0

  IF NOT EXISTS(
    SELECT TOP 1 1 FROM dbo.IkForderung F
    WHERE F.FaLeistungID = @leiFaLeistungID
      AND F.IkForderungID = (
        SELECT TOP 1 FAK.IkForderungID FROM dbo.IkForderung FAK
        WHERE FAK.FaLeistungID = F.FaLeistungID
          AND FAK.IkForderungPeriodischCode in (1,2) -- Kinderalimente, Erwachsenenalimente
          AND FAK.DatumAnpassenAb <= GetDate()
          AND (FAK.DatumGueltigBis IS NULL OR GetDate() <= FAK.DatumGueltigBis)
          AND F.Betrag > 0
        ORDER BY FAK.DatumAnpassenAb DESC, FAK.Betrag DESC
      )
  )
  BEGIN
    SET @Result = 1
  END

  RETURN @Result;
END -- Function
