SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnIkAlbvAnspruch0
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Functions/fnIkAlbvAnspruch0.sql $
  $Author: Nweber $
  $Modtime: 26.06.09 11:12 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: FaFallID suchen die ein ALBV Anspruch = 0 haben
  -
  RETURNS: .
  -
  TEST:    SELECT * FROM dbo.fnIkAlbvAnspruch0(xx)
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Functions/fnIkAlbvAnspruch0.sql $
 * 
 * 2     26.06.09 11:14 Nweber
 * #72: Änderung von der Abfrage wenn nur migrierte Berechnungen vorhanden
  
=================================================================================================*/

CREATE FUNCTION dbo.fnIkAlbvAnspruch0
(
)

RETURNS @Result TABLE
(
  FaFallID INT
)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
        INSERT @Result (FaFallID)
        (
            -- keine Anspruchsberechnung vorhanden
            SELECT L.FaFallID 
            FROM FaLeistung L
            WHERE L.DatumBis is null
              and L.FaProzessCode = 405 -- Alimenteninkasso ALVB / ALV
              -- nur migriert
              and not exists (
                 SELECT top 1 1 FROM FaLeistung L402
                 WHERE L402.FaProzessCode = 402
                   and L402.FaFallID = L.FaFallID
                 )

            UNION

            -- nur migrierte Berechnungen vorhanden
            SELECT L.FaFallID 
            FROM FaLeistung L
            WHERE L.DatumBis is null
              and L.FaProzessCode = 402 -- Anspruchsberechnung ALVB+ÜbH
              -- nur migriert
              and not exists (
                 SELECT top 1 1 FROM dbo.AmAnspruchsberechnung B
                 WHERE L.FaLeistungID = B.FaLeistungID
                   and (B.AmBerechnungsStatusCode is null or B.AmBerechnungsStatusCode != 5) -- migriert
                 )

            UNION

            -- ALBV Anspruch = 0 (Gültiger Monatsanspruch Total = 0 in der aktuelste Berechnung)
            SELECT L.FaFallID 
            FROM FaLeistung L
              LEFT JOIN dbo.AmAbPosition P with(readuncommitted) ON
              P.AmAbPositionsartID = 740 -- Gültiger Monatsanspruch Total
              and P.AmAnspruchsberechnungID = (
                -- Aktuelle Anspruchsberechnung suchen
                SELECT TOP 1 B.AmAnspruchsberechnungID FROM dbo.AmAnspruchsberechnung B
                WHERE L.FaProzessCode = 402 -- Anspruchsberechnung ALVB+ÜbH
                and B.FaLeistungID = L.FaLeistungID
                and B.AmBerechnungsStatusCode in (1,2,3) -- BerechnungStatus "in Vorbereitung", "angefragt" und "bewilligt"
                and B.BerechnungDatumAb <= getdate()
                ORDER BY B.BerechnungDatumAb DESC
              )
            WHERE P.Wert3 = 0
              and L.FaProzessCode = 402 -- Anspruchsberechnung ALVB+ÜbH
              and L.DatumBis is null

            UNION

            -- Anspruchsberechnung abgeschlossen
            SELECT L.FaFallID 
            FROM FaLeistung L
            WHERE L.DatumBis is not null
              and L.FaProzessCode = 402 -- Anspruchsberechnung ALVB+ÜbH
        )

  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN
END