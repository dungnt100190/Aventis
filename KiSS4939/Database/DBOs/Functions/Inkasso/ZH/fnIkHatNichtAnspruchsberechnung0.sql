SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

EXECUTE dbo.spDropObject fnIkHatNichtAnspruchsberechnung0
GO

/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description 
-------------------------------------------------------------------------------------------------
  SUMMARY: Um zu wissen ob eine Leistung (402, 404) nicht eine Anspruchsberechnung = 0 hat.
           d.h. die Leistung hat Eine Anspruchsberechnung > 0 order nur migrierte Daten
    @leiFaLeistungID:   FaLeistungID
    @leiFaProzessCode:  FaProzessCode
  -
  RETURNS: 1 wenn die Anspruchsberechnung nicht null ist, sonst 0
  -
=================================================================================================
  TEST:    dbo.fnIkHatNichtAnspruchsberechnung0(7012978, 402)
=================================================================================================*/

CREATE FUNCTION dbo.fnIkHatNichtAnspruchsberechnung0
(
  @leiFaLeistungID int,
  @leiFaProzessCode int
)
RETURNS bit
AS BEGIN
  DECLARE @Result bit
  SET @Result = 0

  IF @leiFaProzessCode != 402 AND @leiFaProzessCode != 404
  BEGIN
    RETURN @Result;
  END

  IF @leiFaProzessCode = 402
  BEGIN
    IF EXISTS(
      SELECT TOP 1 1 FROM dbo.AmAbPosition P WITH(readuncommitted)
        LEFT JOIN dbo.AmAbKind K ON K.AmAbKindID = P.AmAbKindID
        LEFT JOIN dbo.AmAnspruchsberechnung B ON B.AmAnspruchsberechnungID = K.AmAnspruchsberechnungID
      WHERE P.AmAbPositionsartID = 531 -- Effektiver Anspruch
        AND B.FaLeistungID = @leiFaLeistungID
        AND B.AmBerechnungsStatusCode in (1,2,3) -- BerechnungStatus "bewilligt", "in Vorbereitung" und "angefragt"
        AND B.BerechnungDatumAb <= GetDate()
        AND GetDate() <= K.DatumBis
        AND P.Wert3 > 0
    )
    BEGIN
      SET @Result = 1
    END
  END -- @leiFaProzessCode = 402

  IF @leiFaProzessCode = 404
  BEGIN
    IF EXISTS(
      SELECT TOP 1 1 FROM dbo.AmAbPosition P WITH(readuncommitted)
        LEFT JOIN dbo.AmAbKind K on K.AmAnspruchsberechnungID = P.AmAnspruchsberechnungID
        LEFT JOIN dbo.AmAnspruchsberechnung B ON B.AmAnspruchsberechnungID = K.AmAnspruchsberechnungID
      WHERE P.AmAbPositionsartID = 3290 -- Total Anspruch
        AND B.FaLeistungID = @leiFaLeistungID
        AND B.AmBerechnungsStatusCode in (1,2,3) -- BerechnungStatus "bewilligt", "in Vorbereitung" und "angefragt"
        AND B.BerechnungDatumAb <= GetDate()
        AND GetDate() <= K.DatumBis
        AND P.Wert3 > 0
    )
    BEGIN
      SET @Result = 1
    END
  END -- @leiFaProzessCode = 404

  IF @Result = 1 OR NOT EXISTS (
    SELECT TOP 1 1 FROM dbo.AmAnspruchsberechnung B
    WHERE @leiFaLeistungID = B.FaLeistungID
      AND (B.AmBerechnungsStatusCode IS NULL OR B.AmBerechnungsStatusCode != 5) -- migriert
  )
  BEGIN
    SET @Result = 1
  END

  RETURN @Result;
END -- Function
