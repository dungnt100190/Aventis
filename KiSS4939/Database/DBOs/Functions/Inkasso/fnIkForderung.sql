SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnIkForderung;
GO
/*===============================================================================================
  $Revision: 1
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Um die Forderung einer Inkasso-Buchung zu finden
    @IkPositionID:       ID der Position zu finden
    @KbForderungArtCode: Forderungsart der Kostenart-Buchung (LOV IkKbForderungArt)
  -
  RETURNS: Die Forderung für welche die Buchung erstellt wurde
  -
  TEST:    SELECT * FROM dbo.fnIkForderung(1, 10);
=================================================================================================*/

CREATE FUNCTION dbo.fnIkForderung
(
  @IkPositionID       INT,
  @KbForderungArtCode INT
)
RETURNS TABLE
AS
RETURN
  SELECT 
    IkPositionID              = IPO.IkPositionID,
    IkForderungID             = FRD.IkForderungID,
    FaLeistungID              = FRD.FaLeistungID,
    IkRechtstitelID           = FRD.IkRechtstitelID,
    BaPersonID                = FRD.BaPersonID,
    IkForderungPeriodischCode = FRD.IkForderungPeriodischCode,
    DatumAnpassenAb           = FRD.DatumAnpassenAb,
    DatumGueltigBis           = FRD.DatumGueltigBis,
    Betrag                    = FRD.Betrag,
    IkAnpassungsGrundCode     = FRD.IkAnpassungsGrundCode,
    IkAnpassungsRegelCode     = FRD.IkAnpassungsRegelCode,
    IndexStandBeiBerechnung   = FRD.IndexStandBeiBerechnung,
    IndexStandDatum           = FRD.IndexStandDatum,
    Bemerkung                 = FRD.Bemerkung,
    Sollgestellt              = FRD.Sollgestellt,
    ALBVBerechtigt            = FRD.ALBVBerechtigt,
    Teuerungseinsprache       = FRD.Teuerungseinsprache,
    Unterstuetzungsfall       = FRD.Unterstuetzungsfall
  FROM dbo.IkForderungPosition IFP
    INNER JOIN dbo.IkPosition  IPO WITH (READUNCOMMITTED)
                                   ON IPO.IkPositionID = IFP.IkPositionID
    INNER JOIN dbo.IkForderung FRD WITH (READUNCOMMITTED)
                                   ON FRD.IkForderungID = IFP.IkForderungID 
                                   AND ((IPO.Einmalig = 0 AND @KbForderungArtCode IN (10, 1, 2) AND FRD.IkForderungPeriodischCode = 1) -- Kinderalimenten (periodisch)
                                    OR (IPO.Einmalig = 0 AND @KbForderungArtCode IN (1) AND FRD.IkForderungPeriodischCode = 2)         -- Erwachsenenalimenten (periodisch)
                                    OR (IPO.Einmalig = 0 AND @KbForderungArtCode IN (3) AND FRD.IkForderungPeriodischCode = 3))        -- Kinderzulagen (periodisch)
  WHERE IFP.IkPositionID = @IkPositionID
GO
