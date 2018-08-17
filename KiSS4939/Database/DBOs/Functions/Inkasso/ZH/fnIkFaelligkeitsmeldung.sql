SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnIkFaelligkeitsmeldung
GO
/*===============================================================================================
  $Revision: 11 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Fälligkeitsmeldung für die verschiedene Leistungsart
    @uebersichtFaelle:	
    @leiFaFallID:		FaFallID
    @leiFaLeistungID:	FaLeistungID
    @leiFaProzessCode:	FaProzessCode
    @leiDatumVon:		Datum von
    @leiDatumBis:		Datum bis
  -
  RETURNS: Fälligkeitsmeldung
  -
-- Remarks:     - Index auf AmAnspruchsberechnung(FaLeistungID, AmBerechnungsStatusCode, BerechnungDatumAb)
--                dass die Fälligkeitsmeldung für A-Anspruchsberechnung ALBV/ÜbH und KKBB schneller ist

=================================================================================================
  TEST:    dbo.fnIkFaelligkeitsmeldung(0, 51, 7048501, 405, '2009.01.01', '2009.06.01', NULL)
=================================================================================================*/

CREATE FUNCTION dbo.fnIkFaelligkeitsmeldung
(
  -- Übersicht Fälle ist gewählt wenn es den Wert 1 hat
  @uebersichtFaelle bit,
  -- Leistungen Werte
  @leiFaFallID int, 
  @leiFaLeistungID int, 
  @leiFaProzessCode int, 
  @leiDatumVon datetime, 
  @leiDatumBis datetime
)
RETURNS VARCHAR(MAX)
AS BEGIN
  DECLARE @Result VARCHAR(MAX)
  SET @Result = ''

-- Faelligkeitsmeldung fuer FA-Fallfuehrung Alimentenstelle
 IF @leiFaProzessCode = 201
 BEGIN
   -- -----------------------------------------------------------------------------
   -- das FA-FF ist offen, also kontrollieren, ob alle A-Leistungen abgeschlossen sind
   IF @leiDatumBis IS NULL
     AND not exists(
       -- schauen, ob es offene A-Leistungen hat
       SELECT TOP 1 1 FROM dbo.FaLeistung L
       WHERE L.FaFallID = @leiFaFallID
         AND L.FaProzessCode BETWEEN 400 AND 499 
         AND L.DatumBis is NULL
     )
     -- nur dann, wenn es auch wirklich A-Leistungen hat
     AND exists(
       SELECT TOP 1 1 FROM dbo.FaLeistung L
       WHERE L.FaFallID = @leiFaFallID
         AND L.FaProzessCode BETWEEN 400 AND 499 
     )
   BEGIN
     SET @Result = 'Modul A abgeschlossen' + CHAR(13) + CHAR(10) 
   END

   -- -----------------------------------------------------------------------------
   -- das FA-FF ist offen, also kontrollieren ob 3 Monaten nach eröffnung des FA-FF kein ALIM erfasst wurde
   IF @leiDatumBis IS NULL
     AND not exists(
       -- schauen, ob es A-Leistungen hat
       SELECT TOP 1 1 FROM dbo.FaLeistung L
       WHERE L.FaFallID = @leiFaFallID
         AND L.FaProzessCode BETWEEN 400 AND 499 
     )
     AND DateAdd(m, 3, @leiDatumVon) < getdate() 
   BEGIN
     SET @Result = @Result + 'kein Modul A eröffnet' + CHAR(13) + CHAR(10) 
   END
 END

 -- A-Anspruchsberechnung ALBV/ÜbH, A-Anspruchsberechnung KKBB
 IF @leiFaProzessCode in (402,404) 
 BEGIN
   DECLARE @AmAbPositionsartID INT
   IF  @leiFaProzessCode = 402
   BEGIN
     SET @AmAbPositionsartID =  531 -- Effektiver Anspruch
   END
   IF  @leiFaProzessCode = 404
   BEGIN
     SET @AmAbPositionsartID =  3290 -- Total Anspruch
   END
   -- Faelligkeitsmeldung fuer nicht abgeschlossenen Anspruchsberechnungen
   -- die Anspruchsberechnungen ist offen, also kontrollieren ob ein Kind in die 2 letzten Monaten berechtigt war
   IF @leiDatumBis is null
     and DateAdd(m, 2, (
       -- das kleinste Endedatum von alle Kinder suchen
       SELECT min(A.Datumbis) FROM dbo.AmAbKind A
         INNER JOIN dbo.AmAbPosition P ON P.AmAbKindID = A.AmAbKindID
       WHERE  A.BerechtigtCode in (1,2,3)
        and P.Wert3 > 0
        and P.AmAbPositionsartID = @AmAbPositionsartID
        and A.AmAnspruchsberechnungID = (
          -- suche die aktuelste Anspruchsberechnung der Leistung
          SELECT TOP 1 B.AmAnspruchsberechnungID FROM dbo.AmAnspruchsberechnung B
          WHERE B.FaLeistungID = @leiFaLeistungID
            and B.AmBerechnungsStatusCode in (1,2,3) -- BerechnungStatus "in Vorbereitung", "angefragt" und "bewilligt"
            and B.BerechnungDatumAb <= getdate()
          ORDER BY B.BerechnungDatumAb DESC
        )
     )) < getdate()
   BEGIN
    SET @Result = 'Frist überschritten' + CHAR(13) + CHAR(10) 
   END

  -- Faelligkeitsmeldung fuer migrierte Dokumente
   -- kontrollieren ob es nur migrierte Dokumente hat
   IF not exists (
     SELECT top 1 1 FROM dbo.AmAnspruchsberechnung B
     WHERE @leiFaLeistungID = B.FaLeistungID
       and (B.AmBerechnungsStatusCode is null or B.AmBerechnungsStatusCode != 5) -- migriert
     )
   BEGIN
     SET @Result = @Result + 'Frist überschritten (Migration)' + CHAR(13) + CHAR(10) 
   END
 END

 -- A-KKBB
 IF @leiFaProzessCode=407
 BEGIN
  -- Faelligkeitsmeldung fuer nicht abgeschlossenen KKBB
   -- das A-KKBB ist offen, kontrollieren ob es innert 14 Monaten nach Abschluss Anspruchsberechnungen KKBB noch offen ist
   IF @leiDatumBis is null
      and DateAdd(m, 14, (
        -- suche das grösste Abschlussdatum der Anspruchsberechnungen KKBB
        SELECT max(A.Datumbis) FROM dbo.AmAbKind A
        left join dbo.AmAnspruchsberechnung B ON B.AmAnspruchsberechnungID = A.AmAnspruchsberechnungID
        left join dbo.FaLeistung L ON L.FaLeistungID = B.FaLeistungID
        WHERE L.FaFallID = @leiFaFallID
         and L.FaProzessCode = 404 
         and A.BerechtigtCode = 3
      )) < getdate()
      and not exists(
        select top 1 1 from FaLeistung L
        where L.FaFallID = @leiFaFallID
          and L.FaProzessCode = 410
          and L.DatumBis is not null
      )
   BEGIN
     SET @Result = 'Frist überschritten' + CHAR(13) + CHAR(10) 
   END

  -- Faelligkeitsmeldung fuer Rückforderung KKBB aktiv und Saldo = 0 auf KKBB Kontenblatt
   IF exists(
      select top 1 1 from FaLeistung L
      where L.FaFallID = @leiFaFallID
        and L.FaProzessCode = 410
        and L.DatumBis is null
        -- Rückforderung KKBB Saldo = 0
        and (
          select Saldo =
          (
            (select Soll = case when sum(BU.Betrag) is null then 0 else sum(BU.Betrag) end from KbBuchung BU where BU.HabenKtoNr is null and BU.FaLeistungID = L.FaLeistungID) +
            (select Soll = case when sum(BU.Betrag) is null then 0 else sum(BU.Betrag) end from KbBuchung BU where BU.HabenKtoNr is null and BU.KbBuchungID in (
              SELECT AUS.AusgleichBuchungid FROM KbOpAusgleich AUS
                LEFT JOIN KbBuchung B ON b.KbBuchungID = AUS.OpBuchungID
              WHERE L.FaLeistungID = B.FaLeistungID)
            )
          )
          - 
          (
            (select Haben = case when sum(BU.Betrag) is null then 0 else sum(BU.Betrag) end from KbBuchung BU where BU.SollKtoNr is null and BU.FaLeistungID = L.FaLeistungID) +
            (select Haben = case when sum(BU.Betrag) is null then 0 else sum(BU.Betrag) end from KbBuchung BU where BU.SollKtoNr is null and BU.KbBuchungID in (
              SELECT AUS.AusgleichBuchungid FROM KbOpAusgleich AUS
                LEFT JOIN KbBuchung B ON b.KbBuchungID = AUS.OpBuchungID
              WHERE L.FaLeistungID = B.FaLeistungID)
            )
          )
        ) = 0
      )
   BEGIN
     SET @Result = 'Frist überschritten' + CHAR(13) + CHAR(10) 
   END
 END

 -- A-ÜbH
 IF @leiFaProzessCode=406
 BEGIN
  -- Faelligkeitsmeldung fuer nicht abgeschlossenen ALBV/UebH
   -- das A-ÜbH ist offen, kontrollieren ob für gleichen Glaeubiger ein Alimenteninkasso ALBV/ALV eröffnet worden ist
   -- und melden wenn innert 2 Monaten das A-ÜbH nicht abgeschlossen ist
   IF @leiDatumBis is null
      and exists(
        -- schauen ob es in die offenen Alimenteninkasso ALBV/ALV Leistungen ein Glaeubiger noch eine UebH hat
        select top 1 1 
        from dbo.IkGlaeubiger G
          left join dbo.IkRechtstitel R on R.IkRechtstitelID = G.IkRechtstitelID
          left join dbo.FaLeistung L on L.FaLeistungID = R.FaLeistungID
        where L.FaProzessCode = 405
          and L.FaFallID = @leiFaFallID
          and L.DatumBis is NULL
          and G.IkGlaeubigerStatusCode in (1,2,3) -- IkGlaeubigerStatus = "Vorbereitung", "Aktiv" oder "prov. eingestellt"
          and exists(
            -- UeBH
            select top 1 1 from dbo.IkGlaeubiger G2
              left join dbo.IkRechtstitel R2 on R2.IkRechtstitelID = G2.IkRechtstitelID
            where R2.FaLeistungID = @leiFaLeistungID
              and G2.BaPersonID = G.BaPersonID
              and G.IkGlaeubigerStatusCode in (1,2,3) -- IkGlaeubigerStatus = "Vorbereitung", "Aktiv" oder "prov. eingestellt"
          )
          and getdate() > DateAdd(m, 2, L.DatumVon) 
      )
      and not exists(
        select top 1 1 from FaLeistung L
        where L.FaFallID = @leiFaFallID
          and L.FaProzessCode = 409
          and L.DatumBis is not null
      )
    
   BEGIN
     SET @Result = 'Frist überschritten' + CHAR(13) + CHAR(10) 
   END

  -- Faelligkeitsmeldung fuer Rückforderung ÜbH aktiv und Saldo = 0 auf KKBB Kontenblatt
   IF exists(
        select top 1 1 from FaLeistung L
          left join IkPosition POS on POS.FaLeistungID = L.FaLeistungID
        where L.FaFallID = @leiFaFallID
          and L.FaProzessCode = 409
          and L.DatumBis is null
          -- Rückforderung ÜbH Saldo = 0
          and (
            select Saldo =
            (
              (select Soll = case when sum(BU.Betrag) is null then 0 else sum(BU.Betrag) end from KbBuchung BU where BU.HabenKtoNr is null and BU.FaLeistungID = L.FaLeistungID) +
              (select Soll = case when sum(BU.Betrag) is null then 0 else sum(BU.Betrag) end from KbBuchung BU where BU.HabenKtoNr is null and BU.KbBuchungID in (
                SELECT AUS.AusgleichBuchungid FROM KbOpAusgleich AUS
                  LEFT JOIN KbBuchung B ON b.KbBuchungID = AUS.OpBuchungID
                WHERE L.FaLeistungID = B.FaLeistungID)
              )
            )
            - 
            (
              (select Haben = case when sum(BU.Betrag) is null then 0 else sum(BU.Betrag) end from KbBuchung BU where BU.SollKtoNr is null and BU.FaLeistungID = L.FaLeistungID) +
              (select Haben = case when sum(BU.Betrag) is null then 0 else sum(BU.Betrag) end from KbBuchung BU where BU.SollKtoNr is null and BU.KbBuchungID in (
                SELECT AUS.AusgleichBuchungid FROM KbOpAusgleich AUS
                  LEFT JOIN KbBuchung B ON b.KbBuchungID = AUS.OpBuchungID
                WHERE L.FaLeistungID = B.FaLeistungID)
              )
            )
          ) = 0
        )
    BEGIN
     SET @Result = 'Frist überschritten' + CHAR(13) + CHAR(10) 
   END
END

-- -- Wenn die Übersicht gewählt wurde, dann müssen die Filterkriterium Anzeige nicht gemacht werdeb
-- IF @uebersichtFaelle = 0
-- BEGIN
--  -- Filterkriterium
--   -- Faelligkeitsmeldung fuer Anspruch ALBV/UebH > 0
--   IF @leiFaProzessCode = 402
--   BEGIN
--     IF exists(
--       SELECT TOP 1 1 FROM dbo.AmAbPosition P with(readuncommitted)
--         left join dbo.AmAbKind K on K.AmAbKindID = P.AmAbKindID
--         left join dbo.AmAnspruchsberechnung B ON B.AmAnspruchsberechnungID = K.AmAnspruchsberechnungID
--       where P.AmAbPositionsartID = 531 -- Effektiver Anspruch
--         and B.FaLeistungID = @leiFaLeistungID
--         and B.AmBerechnungsStatusCode in (1,2,3) -- BerechnungStatus "bewilligt", "in Vorbereitung" und "angefragt"
--         and B.BerechnungDatumAb <= getdate()
--         and getdate() <= K.DatumBis
--         and P.Wert3 > 0
--     )
--     BEGIN
--      SET @Result = @Result + 'Anspruch ALBV/UebH > 0' + CHAR(13) + CHAR(10) 
--     END
--   END
--
--
--  -- Filterkriterium
--   -- Faelligkeitsmeldung fuer Anspruch KKBB > 0
--   IF @leiFaProzessCode = 404
--   BEGIN
--     IF exists(
--       SELECT TOP 1 1 FROM dbo.AmAbPosition P with(readuncommitted)
--         left join dbo.AmAbKind K on K.AmAnspruchsberechnungID = P.AmAnspruchsberechnungID
--         left join dbo.AmAnspruchsberechnung B ON B.AmAnspruchsberechnungID = K.AmAnspruchsberechnungID
--       WHERE P.AmAbPositionsartID = 3290 -- Total Anspruch
--         and B.FaLeistungID = @leiFaLeistungID
--         and B.AmBerechnungsStatusCode in (1,2,3) -- BerechnungStatus "bewilligt", "in Vorbereitung" und "angefragt"
--         and B.BerechnungDatumAb <= getdate()
--         and getdate() <= K.DatumBis
--         and P.Wert3 > 0
--     )
--     BEGIN
--      SET @Result = @Result + 'Anspruch KKBB > 0' + CHAR(13) + CHAR(10) 
--     END
--   END
-- END

  IF @Result = ''
  BEGIN
    SET @Result = NULL
  END

  RETURN @Result;
END

