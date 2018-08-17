SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
EXECUTE dbo.spDropObject fnIkAlimenteninkassoErweiterung
GO
/*===============================================================================================
  $Revision: 9 $
=================================================================================================
  Description 
-------------------------------------------------------------------------------------------------
  SUMMARY: Filter für Alimenteninkasso Erweiterungen
    @alimErweiterung:   Alimenteninkasso Erweiterungen (1:Vermittlung, 2:Rückstände, 3:Abschreibungen)
    @leiFaLeistungID:   FaLeistungID
    @leiFaProzessCode:  FaProzessCode
    @ansFaFallID:       FaFallID wenn dieser Fall ein Anspruch ALBV = 0 hat, sonst NULL
  -
  RETURNS: 1 wenn die Leistung in der gegebene Alimenteninkasso Erweiterung vorhandet, sonst 0
  -
=================================================================================================
  TEST:    dbo.fnIkAlimenteninkassoErweiterung(1, 7048501, 405, NULL)
=================================================================================================*/

CREATE FUNCTION dbo.fnIkAlimenteninkassoErweiterung
(
  -- Alimenteninkasso Erweiterungen (1:Vermittlung, 2:Rückstände, 3:Abschreibungen)
  @alimErweiterung int,
  -- Leistungen Werte
  @leiFaLeistungID int,
  @leiFaProzessCode int,
  @ansFaFallID int
)
RETURNS INT
AS BEGIN
  DECLARE @Result bit
  SET @Result = 0

  IF @leiFaProzessCode = 405
  BEGIN
    -- -----------------------------------------------------------------------
    -- Alimenteninkasso ALBV / ALV, Vermittlung
    IF @alimErweiterung = 1
    BEGIN
      IF @ansFaFallID IS NOT NULL -- ALBV Anspruch = 0
        AND
        -- aktuelle monatliche Forderung > 0
        dbo.fnIkHatAktuelleForderung0(@leiFaLeistungID) = 0
      BEGIN
        SET @Result = 1
      END
    END -- alim Vermittlung

    -- -----------------------------------------------------------------------
    -- Alimenteninkasso ALBV / ALV, Rückstände
    IF @alimErweiterung = 2
    BEGIN
      IF (
        -- Aktuelle Forderung = 0
        dbo.fnIkHatAktuelleForderung0(@leiFaLeistungID) = 1
        AND (
          -- Zahlungseingänge in den letzten 12 Monaten vorhanden
          EXISTS(
            SELECT TOP 1 1 FROM dbo.KbBuchung BU
              LEFT JOIN dbo.KbZahlungseingang ZE ON ZE.KbZahlungseingangID = BU.KbZahlungseingangID
            WHERE @leiFaLeistungID = BU.FaLeistungID
              AND BU.KbZahlungseingangID IS NOT NULL
              AND DateAdd(m,12,ZE.Datum)>=GetDate()
            UNION ALL
            SELECT TOP 1 1 FROM dbo.KbBuchung BU
              LEFT JOIN dbo.KbZahlungseingang ZE ON ZE.KbZahlungseingangID = BU.KbZahlungseingangID
            WHERE BU.KbBuchungID in (
				  SELECT AUS.AusgleichBuchungID FROM KbOpAusgleich AUS
				  LEFT JOIN KbBuchung B ON b.KbBuchungID = AUS.OpBuchungID
				  WHERE @leiFaLeistungID = B.FaLeistungID)
              AND BU.KbZahlungseingangID IS NOT NULL
              AND DateAdd(m,12,ZE.Datum)>=GetDate()
          )
          OR
          -- Einmaligen Forderungen in den letzten 12 Monaten vorhanden
          EXISTS(
            SELECT TOP 1 1 FROM dbo.IkPosition POS
            WHERE POS.FaLeistungID = @leiFaLeistungID
              AND POS.Einmalig = 1
              -- Betrebungskosten, Gerichtskosten, Prozessentschädigungen, Verzugszinsen
              AND POS.IkForderungEinmaligCode in (12,212,16,216,14,214,13,213)
              AND DateAdd(m,12,POS.Datum)>=GetDate()
          )
        )
      )
      BEGIN
        SET @Result = 1
      END
    END -- alim Rückstände

    -- -----------------------------------------------------------------------
    -- Alimenteninkasso ALBV / ALV, Abschreibungen
    IF @alimErweiterung = 3
    BEGIN
      IF (
        -- Aktuelle Forderung = 0
        dbo.fnIkHatAktuelleForderung0(@leiFaLeistungID) = 1
        -- Keine Zahlungseingänge in den letzten 12 Monaten vorhanden
        AND NOT EXISTS(
          SELECT TOP 1 1 FROM dbo.KbBuchung BU
            LEFT JOIN dbo.KbZahlungseingang ZE ON ZE.KbZahlungseingangID = BU.KbZahlungseingangID
          WHERE @leiFaLeistungID = BU.FaLeistungID
            AND BU.KbZahlungseingangID IS NOT NULL
            AND DateAdd(m,12,ZE.Datum)>=GetDate()
          UNION ALL
          SELECT TOP 1 1 FROM dbo.KbBuchung BU
            LEFT JOIN dbo.KbZahlungseingang ZE ON ZE.KbZahlungseingangID = BU.KbZahlungseingangID
          WHERE BU.KbBuchungID in (
				SELECT AUS.AusgleichBuchungID FROM KbOpAusgleich AUS
				LEFT JOIN KbBuchung B ON B.KbBuchungID = AUS.OpBuchungID
				WHERE @leiFaLeistungID = B.FaLeistungID)
            AND BU.KbZahlungseingangID IS NOT NULL
            AND DateAdd(m,12,ZE.Datum)>=GetDate()
        )
        -- Keine Einmaligen Forderungen un den letzten 12 Monaten vorhanden
        AND NOT EXISTS(
          SELECT TOP 1 1 FROM dbo.IkPosition POS
          WHERE POS.FaLeistungID = @leiFaLeistungID
            AND POS.Einmalig = 1
            -- Betrebungskosten, Gerichtskosten, Prozessentschädigungen, Verzugszinsen
            AND POS.IkForderungEinmaligCode in (12,212,16,216,14,214,13,213)
            AND DateAdd(m,12,POS.Datum)>=GetDate()
        )
      )
      BEGIN
        SET @Result = 1
      END
    END -- alim Abschreibungen
  END -- @leiFaProzessCode = 405


  RETURN @Result;
END -- Function
