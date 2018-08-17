SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spIkMonatszahlen_Detail
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spIkMonatszahlen_Detail.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 11:21 $
  $Revision: 21 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Updaten der Tabelle IkPosition, Erstellen von neuen Monatszahlen.
    @Param1: ID Leistung.
    @Param2: Jahr.
    @Param3: Monat.
  -
  RETURNS: Errorcode oder Anzahl korrigieter Zeilen.
  -
  TEST: exec dbo.spIkMonatszahlen_Detail -1, 2009, 1 
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spIkMonatszahlen_Detail.sql $
 * 
 * 20    11.12.09 11:57 Lloreggia
 * Header aktualisiert
 * 
 * 19    8.08.09 18:09 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 18    23.07.09 10:25 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 17    13.07.09 2:20 Rhesterberg
 *  * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 16    12.07.09 19:05 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 15    7.07.09 0:45 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 14    2.07.09 4:54 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 13    28.06.09 16:56 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 12    27.06.09 18:06 Rhesterberg
 * #32: Monatszahlen übergeordnet
 * 
 * 11    26.06.09 18:45 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 10    26.06.09 13:29 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 9     25.06.09 17:29 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 8     25.06.09 16:23 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 7     25.06.09 14:21 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 6     24.06.09 16:13 Rhesterberg
 * #32: ALIM5 Monatszahlen übgeordnet
 * 
 * 5     28.02.09 18:02 Rhesterberg
 * 
 * 4     19.01.09 16:08 Rhesterberg
 * 
 * 3     18.01.09 20:35 Rhesterberg
 * 
 * 2     6.01.09 13:15 Rhesterberg
 * 
 * 1     9.09.08 14:59 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

/*
===================================================================================================
Author:      sozheo
Create date: 11.09.2007
Description: Updaten der Tabelle IkPosition, Erstellen von neuen Monatszahlen
TESTS: 

exec dbo.spIkMonatszahlen_Detail 6222, 2008, 3 -- Tumonika Makiese
exec dbo.spIkMonatszahlen_Detail 6257, 2008, 1 -- Gruber Ena, UeBH
exec dbo.spIkMonatszahlen_Detail 6258, 2008, 1 -- Gruber Otto, KKBB

select * from baperson where name like 'Gruber' -- 209128: 209086
select * from IkGlaeubiger where bapersonID = 209128
select * from IkForderung where bapersonID = 209086

===================================================================================================
History:
11.09.2007 : sozheo : neu erstellt
23.09.2007 : sozheo : Weitere Berechnungen eingefügt
24.09.2007 : sozheo : Wenn Anspruchsberechnung.DefinitivAbDatum leer ist,
                      dann keine Berücksichtigung
26.09.2007 : sozheo : Speichern Punkt und Punktedatum korrigiert
10.10.2007 : sozheo : Fehlermeldung besser zurückgeben, keine Excpetion, wenn Monat abgeschlossen
11.10.2007 : sozheo : Fehler bei Kontrolle erledigter Monat korrigiert
30.10.2007 : sozheo : Neu BerechnungDatumAb statt DefinitivAbDatum
01.11.2007 : sozheo : Neu Unterstützungsfall vom Vormonat
01.11.2007 : sozheo : Umbau für mehrere Rechsttitel pro Leistung
05.11.2007 : sozheo : Korrektur, dass neue Daten hinzugefügt oder entfernt werden
07.11.2007 : sozheo : Korrektur, dass neue Daten hinzugefügt oder entfernt werden
13.11.2007 : sozheo : Korrektur, Unterstützungsfall soll nur bei Insert von Vormonat übernommen werden
23.11.2007 : sozheo : Korrektur, erledigte nicht updaten, alle Beträge null löschen
23.11.2007 : sozheo : Korrektur, DatumBis berücksichtigen
26.11.2007 : sozheo : Korrektur, Kontrolle erledigter Monat angepasst
08.01.2008 : sozheo : Änderungen von Namen
30.01.2008 : sozheo : Änderungen von IkRatenplan -> IkVerrechnungskonto
02.02.2008 : sozheo : Tabellen umbennen
06.02.2008 : sozheo : Datum setzen
11.02.2008 : sozheo : Zeile löschen wenn leer
13.02.2008 : sozheo : Korrekturen Performance
14.02.2008 : sozheo : Korrektur für 4. Typ Periodisch
25.02.2008 : sozheo : Berechnung für DatumBis korrigiert
28.02.2008 : sozheo : +/- bei Verrechnungskonto jetzt mit LOV
28.02.2008 : sozheo : IndexStandPunkte korrigiert
28.02.2008 : sozheo : n:m-Beziehung Forderung-Position implementiert
01.03.2008 : sozheo : ForderungPeriodischCode implementiert
03.03.2008 : sozheo : IstKind implementiert
05.03.2008 : sozheo : Neues Feld Zahlung
06.03.2008 : sozheo : Indexberechnung korrigiert
07.03.2008 : sozheo : neu ALBV Betrag von Gläubiger
13.03.2008 : sozheo : Berechnung ALBV Betrag korrigiert
17.03.2008 : sozheo : neu jetzt auch mit FaLeistung
18.03.2008 : sozheo : Verlagerung der Berechnung mit FaLeistung
19.03.2008 : sozheo : Korrektur Berechnung IkForderung.DatumGueltigBis
23.03.2008 : sozheo : Korrektur Anspruchsberechnung: gestoppte -> Betrag 0
25.03.2008 : sozheo : Umbau Bewilligung
27.03.2008 : sozheo : Einbau @RechtstitelID von AmAbKind
06.05.2008 : sozheo : Rundung KiZulagen korrigiert
07.05.2008 : sozheo : Nur aktive Gläubiger
08.05.2008 : sozheo : Korrektur N-M-Beziehung speichern
13.05.2008 : sozheo : Filtern auf IkForderung.Aktiv entfernt, weil nicht auf Maske
14.05.2008 : sozheo : Berechnung Index korrigiert
01.06.2008 : sozheo : Glauebiger eingestellt, dann keine Monatszahlen erstellen
09.06.2008 : sozheo : Berechnung Index korrigiert
19.06.2008 : sozheo : Berechnung Index korrigiert
20.06.2008 : sozheo : Stornierte Buchungen berücksichtigen
25.06.2008 : sozheo : Berechnung Index korrigiert
26.06.2008 : sozheo : Neue Spalte BetragZahlungSoll
01.07.2008 : sozheo : Neu Status "ersetzt" in Tab. AmAnspruchsberechnung
03.07.2008 : sozheo : FehlerInfos hinzugefügt
17.07.2008 : sozheo : Rundung korrigiert
05.08.2008 : sozheo : IkPosition.ErledigterMonat eliminiert
21.08.2008 : sozheo : Korrekturen SQL Performance
29.09.2008 : sozheo : Berechnung korrigiert, letzter vom Monat wird nun auch berücksichtigt
29.10.2008 : sozheo : Löschen korrigiert, @IkPositionID auf NULL gesetzt
19.01.2009 : sozheo : Änderungen SQL Performance
27.02.2009 : sozheo : Elimination von IkPosition.Unterstuetzungsfall
31.03.2009 : sozheo : Neu über LeistungID
02.04.2009 : sozheo : Neu über LeistungID
08.04.2009 : sozheo : Neu überspielt von Backup
23.06.2009 : sozheo : Neue Logik Monatszahlen umgesetzt
26.06.2009 : sozheo : Neue Tabelle IkRechtstitelPosition
01.07.2009 : sozheo : Alte Daten immer erhalten
07.07.2009 : sozheo : Rundung korrigiert
22.07.2009 : sozheo : Sortierung Berechnung Forderung korrigiert
22.07.2009 : sozheo : Totalaliment begrenzt

SUCHE MEHRFACHE MONATE
select L.fafallid, L.FaLeistungID, L.FaProzessCode, P.bapersonid, P.jahr, P.monat, Anz = count(*) from IkPosition P
left join FaLeistung L on L.FaLeistungID = P.FaLeistungID
where P.IkRechtstitelID is not null
and P.Einmalig = 0
group by L.fafallid, L.FaLeistungID, L.FaProzessCode, P.bapersonid, P.monat, P.jahr
having count(*) > 1
order by L.fafallid, L.FaLeistungID, P.bapersonid, P.jahr, P.monat 

--declare @res int
EXEC dbo.spIkMonatszahlen_Detail_Test 7024443, 2008, 6
--print convert(varchar, @res)

===================================================================================================
*/

CREATE PROCEDURE [dbo].[spIkMonatszahlen_Detail] 
  -- ID Leistung :
  @ParamFaLeistungID INT = 0,
  -- Jahr:
  @ParamBisJahr INT = 0,
  -- Monat:
  @ParamBisMonat INT = 0
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON

  -- ---------------------------------------------------
  -- Kontrollen der Parameter
  -- ---------------------------------------------------
  IF @ParamFaLeistungID is NULL OR @ParamFaLeistungID = 0 BEGIN
    RETURN -1
  END
  IF @ParamBisJahr is NULL OR @ParamBisJahr < 1900 OR @ParamBisJahr > 9999 BEGIN
    RETURN -2
  END
  IF @ParamBisMonat is NULL OR @ParamBisMonat < 1 OR @ParamBisMonat > 12 BEGIN
    RETURN -3
  END


  -- ---------------------------------------------------
  -- Start-Datum und EndDatum holen:
  -- ---------------------------------------------------
  DECLARE @DateBeg DATETIME
  SET @DateBeg = dbo.fnDateSerial(@ParamBisJahr, @ParamBisMonat, 1)
  -- Ende-Datum
  DECLARE @DateEnd DATETIME
  DECLARE @DaysInMonth INT
  SET @DaysInMonth = dbo.fnDaysInMonthOf(@DateBeg)
  SET @DateEnd = dbo.fnDateSerial(@ParamBisJahr,  @ParamBisMonat, @DaysInMonth)


  -- ---------------------------------------------------
  -- Angaben von Rechsttitel holen
  -- ---------------------------------------------------
  --DECLARE @RechtstitelID INT
  DECLARE 
    --@LeistungID INT,
    @RundungNeu INT,
    @ProzessCodeRT INT,
    @IndexStandBerechnungRT MONEY,
    @IndexStandVom DATETIME,
    @FallID1 INT,
    @IkIndexTypCodeNeu INT

  SELECT TOP 1
    @FallID1 = L.FaFallID,
    --@LeistungID = L.FaLeistungID,
    @ProzessCodeRT = L.FaProzessCode
    --@Rundung = Q.IkIndexRundenCode, 
    --@IndexStandBeiBerechnungRT = Q.IndexStandPunkte,
    --@IndexStandVom = Q.IndexStandVom,
    --@IkIndexTypCode = ISNULL(Q.IkIndexTypCode, 99)
  --FROM dbo.IkRechtstitel Q WITH(READUNCOMMITTED)
  --LEFT JOIN dbo.FaLeistung L WITH(READUNCOMMITTED) ON L.FaLeistungID = Q.FaLeistungID
  FROM dbo.FaLeistung L WITH(READUNCOMMITTED) 
  WHERE L.FaLeistungID = @ParamFaLeistungID

/*
  SELECT TOP 1 
    @Rundung = Q.IkIndexRundenCode,
    @IkIndexTypCode = ISNULL(Q.IkIndexTypCode, 99)
  FROM dbo.IkRechtstitel Q WITH(READUNCOMMITTED)
  WHERE Q.FaLeistungID = @ParamFaLeistungID
  ORDER BY Q.IkRechtstitelGueltigVon DESC

  IF @Rundung IS NULL SET @Rundung = 1
*/

  -- ---------------------------------------------------
  -- temp Tabelle erstellen:
  -- ---------------------------------------------------
  DECLARE @TmpValues TABLE  (
    IkRechtstitelID INT NULL,
    IkForderungID INT NULL,
    ActDate DATETIME NULL,
    BaPersonID INT NULL,
    Days INT NULL,
    TotalAliment MONEY NULL,
    BetragALBV MONEY NULL,
    BetragKiZulage MONEY NULL,
    BetragALBVRaten MONEY NULL,
    Punkte MONEY NULL,
    PunkteDatum DATETIME NULL,
    IkAnpassungsRegelCode INT NULL,
    IndexStandBeiBerechnungRT MONEY NULL,
    Rundung INT NULL, 
    IkIndexTypCode INT NULL,
    Bemerkung VARCHAR(500)
  )

  -- ---------------------------------------------------
  -- Berechnung erstellen, 
  -- ---------------------------------------------------
  -- Daten in Variabeln setzen
  DECLARE 
    @PersonFill INT,
    @DateTmpFrom DATETIME,
    @DateTmpTo DATETIME,
    @DateTmpMax DATETIME,
    @Betrag MONEY,
    @IndexStand MONEY,
    @IndexStandDatum DATETIME, 
    @Bermerkung VARCHAR(500),
    @LoopCountDays INT,
    @KinderzulagenCode INT,
    @IkForderungID INT,
    @IkAnpassungsRegelCodeTmp INT,
    @IstElternteil BIT,
    @FehlerInfos VARCHAR(200),
    @IkRechtstitelID_Frd INT

  SET @KinderzulagenCode = 3 -- Code für Kinderzulage in IkForderungPeriodisch

  DECLARE CursorPersonFill CURSOR FAST_FORWARD FOR
    SELECT DISTINCT G.BaPersonID
    FROM dbo.IkGlaeubiger G WITH(READUNCOMMITTED)
    LEFT JOIN dbo.IkRechtstitel R WITH(READUNCOMMITTED) ON R.IkRechtstitelID = G.IkRechtstitelID 
    WHERE R.FaLeistungID = @ParamFaLeistungID
      AND G.IkGlaeubigerStatusCode in (1,2) -- nur aktive und in Vorbereitung
  OPEN CursorPersonFill

  WHILE 1=1 BEGIN
    FETCH NEXT FROM CursorPersonFill INTO @PersonFill
    IF @@FETCH_STATUS != 0 BREAK

    SELECT TOP 1 @IstElternteil = G.IstElternteil
    FROM dbo.IkGlaeubiger G WITH(READUNCOMMITTED) 
    LEFT JOIN dbo.IkRechtstitel R WITH(READUNCOMMITTED) ON R.IkRechtstitelID = G.IkRechtstitelID
    WHERE R.FaLeistungID = @ParamFaLeistungID
      AND G.BaPersonID = @PersonFill
      -- zuerst den aktiven, dann in Vorbereitung, dann prov eingestellt, dann ungültig alle anderen
    ORDER BY CASE G.IkGlaeubigerStatusCode WHEN 2 THEN 1 WHEN 1 THEN 2 WHEN 3 THEN 3 ELSE 4 END ASC


    -- Alle Kinderalimente (IkForderung) 
    -- --------------------------------------
    IF @ProzessCodeRT = 405 AND @IstElternteil = 0 BEGIN -- ALBV
      DECLARE CursorForderungen CURSOR FAST_FORWARD FOR
        SELECT 
          F.IkRechtstitelID,
          F.IkForderungID,
          CASE WHEN F.DatumAnpassenAb < @DateBeg THEN @DateBeg ELSE F.DatumAnpassenAb END,
          F.DatumGueltigBis,
          F.Betrag,
          CASE WHEN ISNULL(R.IkIndexTypCode, 99) = 99  
                 OR ISNULL(F.IkAnpassungsRegelCode, 7) = 7
            THEN 100
            ELSE ISNULL(F.IndexStandBeiBerechnung,100)
          END,
          IsNull(F.IndexStandDatum, @DateEnd),
          F.IkAnpassungsRegelCode,
          CONVERT(VARCHAR(500), F.Bemerkung),
          R.IndexStandPunkte,
          IsNull(R.IkIndexRundenCode, 1),
          R.IkIndexTypCode
        FROM dbo.IkForderung F WITH(READUNCOMMITTED)
        LEFT JOIN dbo.IkRechtstitel R ON R.IkRechtstitelID = F.IkRechtstitelID 
        LEFT JOIN dbo.IkRechtstitelInfos I ON I.IkRechtstitelInfosID = (
          SELECT TOP 1 IX.IkRechtstitelInfosID FROM dbo.IkRechtstitelInfos IX
          WHERE IX.IkRechtstitelID = R.IkRechtstitelID
          ORDER BY IX.RechtstitelRechtskraeftig DESC
        )
        LEFT JOIN dbo.IkGlaeubiger G ON G.IkRechtstitelID = F.IkRechtstitelID AND G.BaPersonID = @PersonFill
        WHERE F.FaLeistungID = @ParamFaLeistungID
          AND F.BaPersonID = @PersonFill
          AND F.IkForderungPeriodischCode = 1 -- Kinderalimente
          AND F.DatumAnpassenAb <= @DateEnd
          AND G.IkGlaeubigerStatusCode in (1,2) -- nur aktive und in Vorbereitung
        ORDER BY F.DatumAnpassenAb DESC, I.RechtstitelRechtskraeftig DESC, F.IkForderungID DESC
      OPEN CursorForderungen

      SET @DateTmpTo = @DateEnd
      WHILE 1=1 BEGIN
        FETCH NEXT FROM CursorForderungen INTO 
          @IkRechtstitelID_Frd, @IkForderungID, @DateTmpFrom, @DateTmpMax, @Betrag, 
          @IndexStand, @IndexStandDatum, @IkAnpassungsRegelCodeTmp, @Bermerkung, 
          @IndexStandBerechnungRT, @RundungNeu, @IkIndexTypCodeNeu
        IF @@FETCH_STATUS != 0 BREAK

        IF (@DateTmpTo > ISNULL(@DateTmpMax, @DateTmpTo)) SET @DateTmpTo = @DateTmpMax
        IF (@DateTmpTo < @DateBeg) SET @DateTmpTo = @DateBeg
        SET @LoopCountDays = CONVERT(INT, DATEDIFF(DAY, @DateTmpFrom, @DateTmpTo)) + 1
        
        IF ISNULL(@DateTmpMax, @DateTmpTo) >= @DateTmpFrom BEGIN
          INSERT INTO @TmpValues (
            IkRechtstitelID, IkForderungID, ActDate, Days, BaPersonID, TotalAliment, 
            Punkte, PunkteDatum, IkAnpassungsRegelCode, Bemerkung, 
            IndexStandBeiBerechnungRT, Rundung, IkIndexTypCode)
          VALUES (
            @IkRechtstitelID_Frd, @IkForderungID, @DateTmpFrom, @LoopCountDays, @PersonFill, @Betrag, 
            @IndexStand, @IndexStandDatum, @IkAnpassungsRegelCodeTmp, @Bermerkung, 
            @IndexStandBerechnungRT, @RundungNeu, @IkIndexTypCodeNeu)
        END
        SET @DateTmpTo = DATEADD(DAY, -1, @DateTmpFrom)
        IF (@DateTmpTo < @DateBeg) BREAK
      END
      CLOSE CursorForderungen
      DEALLOCATE CursorForderungen
    END

    -- Alle Erwachsenenalimente (IkForderung) 
    -- --------------------------------------
    IF @ProzessCodeRT = 405 AND @IstElternteil = 1 BEGIN -- ALBV
      DECLARE CursorForderungen CURSOR FAST_FORWARD FOR
        SELECT 
          F.IkRechtstitelID,
          F.IkForderungID,
          CASE WHEN F.DatumAnpassenAb < @DateBeg THEN @DateBeg ELSE F.DatumAnpassenAb END,
          F.DatumGueltigBis,
          F.Betrag,
          CASE WHEN ISNULL(R.IkIndexTypCode, 99) = 99  
                 OR ISNULL(F.IkAnpassungsRegelCode, 7) = 7
            THEN 100
            ELSE ISNULL(F.IndexStandBeiBerechnung,100)
          END,
          ISNULL(F.IndexStandDatum, @DateEnd),
          F.IkAnpassungsRegelCode,
          CONVERT(VARCHAR(500), F.Bemerkung),
          R.IndexStandPunkte,
          IsNull(R.IkIndexRundenCode, 1),
          R.IkIndexTypCode
        FROM dbo.IkForderung F WITH(READUNCOMMITTED)
        LEFT JOIN dbo.IkRechtstitel R ON R.IkRechtstitelID = F.IkRechtstitelID 
        LEFT JOIN dbo.IkRechtstitelInfos I ON I.IkRechtstitelInfosID = (
          SELECT TOP 1 IX.IkRechtstitelInfosID FROM dbo.IkRechtstitelInfos IX
          WHERE IX.IkRechtstitelID = R.IkRechtstitelID
          ORDER BY IX.RechtstitelRechtskraeftig DESC
        )
        LEFT JOIN dbo.IkGlaeubiger G ON G.IkRechtstitelID = F.IkRechtstitelID AND G.BaPersonID = @PersonFill
        WHERE F.FaLeistungID = @ParamFaLeistungID
          AND F.BaPersonID = @PersonFill
          AND F.IkForderungPeriodischCode = 2 -- Erwachsenenalimente
          AND F.DatumAnpassenAb <= @DateEnd
          AND G.IkGlaeubigerStatusCode in (1,2) -- nur aktive und in Vorbereitung
        ORDER BY F.DatumAnpassenAb DESC, I.RechtstitelRechtskraeftig DESC, F.IkForderungID DESC
      OPEN CursorForderungen

      SET @DateTmpTo = @DateEnd
      WHILE 1=1 BEGIN
        FETCH NEXT FROM CursorForderungen INTO 
          @IkRechtstitelID_Frd, @IkForderungID, @DateTmpFrom, @DateTmpMax, @Betrag, 
          @IndexStand, @IndexStandDatum, @IkAnpassungsRegelCodeTmp, @Bermerkung, 
          @IndexStandBerechnungRT, @RundungNeu, @IkIndexTypCodeNeu
        IF @@FETCH_STATUS != 0 BREAK
        IF (@DateTmpTo > ISNULL(@DateTmpMax, @DateTmpTo)) SET @DateTmpTo = @DateTmpMax
        IF (@DateTmpTo < @DateBeg) SET @DateTmpTo = @DateBeg
        SET @LoopCountDays = CONVERT(INT, DATEDIFF(DAY, @DateTmpFrom, @DateTmpTo)) + 1
        IF ISNULL(@DateTmpMax, @DateTmpTo) >= @DateTmpFrom BEGIN
          INSERT INTO @TmpValues (
            IkRechtstitelID, IkForderungID, ActDate, Days, BaPersonID, TotalAliment, 
            Punkte, PunkteDatum, IkAnpassungsRegelCode, Bemerkung, 
            IndexStandBeiBerechnungRT, Rundung, IkIndexTypCode)
          VALUES (
            @IkRechtstitelID_Frd, @IkForderungID, @DateTmpFrom, @LoopCountDays, @PersonFill, @Betrag, 
            @IndexStand, @IndexStandDatum, @IkAnpassungsRegelCodeTmp, @Bermerkung, 
            @IndexStandBerechnungRT, @RundungNeu, @IkIndexTypCodeNeu)
        END
        SET @DateTmpTo = DATEADD(DAY, -1, @DateTmpFrom)
        IF (@DateTmpTo < @DateBeg) BREAK
      END
      CLOSE CursorForderungen
      DEALLOCATE CursorForderungen
    END

    -- Alle Kinderzulagen (IkForderung) 
    -- --------------------------------------
    IF @ProzessCodeRT = 405 AND @IstElternteil = 0 BEGIN -- Kinderzulagen
      DECLARE CursorForderungen CURSOR FAST_FORWARD FOR
        SELECT 
           F.IkRechtstitelID,
          F.IkForderungID,
          CASE WHEN F.DatumAnpassenAb < @DateBeg THEN @DateBeg ELSE F.DatumAnpassenAb END,
          F.DatumGueltigBis,
          F.Betrag,
          R.IndexStandPunkte,
          IsNull(R.IkIndexRundenCode, 1),
          R.IkIndexTypCode
        FROM dbo.IkForderung F WITH(READUNCOMMITTED)
        LEFT JOIN dbo.IkRechtstitel R ON R.IkRechtstitelID = F.IkRechtstitelID 
        LEFT JOIN dbo.IkRechtstitelInfos I ON I.IkRechtstitelInfosID = (
          SELECT TOP 1 IX.IkRechtstitelInfosID FROM dbo.IkRechtstitelInfos IX
          WHERE IX.IkRechtstitelID = R.IkRechtstitelID
          ORDER BY IX.RechtstitelRechtskraeftig DESC
        )
        LEFT JOIN dbo.IkGlaeubiger G ON G.IkRechtstitelID = F.IkRechtstitelID AND G.BaPersonID = @PersonFill
        WHERE F.FaLeistungID = @ParamFaLeistungID
          AND F.BaPersonID = @PersonFill
          AND F.IkForderungPeriodischCode = 3 -- 3 = Kinderzulagen
          AND F.DatumAnpassenAb <= @DateEnd
          AND G.IkGlaeubigerStatusCode in (1,2) -- nur aktive und in Vorbereitung
        ORDER BY F.DatumAnpassenAb DESC, I.RechtstitelRechtskraeftig DESC, F.IkForderungID DESC
      OPEN CursorForderungen

      SET @DateTmpTo = @DateEnd
      WHILE 1=1 BEGIN
        FETCH NEXT FROM CursorForderungen INTO 
          @IkRechtstitelID_Frd, @IkForderungID, @DateTmpFrom, @DateTmpMax, @Betrag, 
          @IndexStandBerechnungRT, @RundungNeu, @IkIndexTypCodeNeu
        IF @@FETCH_STATUS != 0 BREAK
        IF (@DateTmpTo > ISNULL(@DateTmpMax, @DateTmpTo)) SET @DateTmpTo = @DateTmpMax
        IF (@DateTmpTo < @DateBeg) SET @DateTmpTo = @DateBeg
        SET @LoopCountDays = CONVERT(INT, DATEDIFF(DAY, @DateTmpFrom, @DateTmpTo)) + 1
        IF ISNULL(@DateTmpMax, @DateTmpTo) >= @DateTmpFrom BEGIN
          INSERT INTO @TmpValues 
            (IkRechtstitelID, IkForderungID, ActDate, Days, BaPersonID, BetragKiZulage, 
             IndexStandBeiBerechnungRT, Rundung, IkIndexTypCode)
          VALUES 
            (@IkRechtstitelID_Frd, @IkForderungID, @DateTmpFrom, @LoopCountDays, @PersonFill, @Betrag, 
             @IndexStandBerechnungRT, @RundungNeu, @IkIndexTypCodeNeu)
        END
        SET @DateTmpTo = DATEADD(DAY, -1, @DateTmpFrom)
        IF (@DateTmpTo < @DateBeg) BREAK
      END
      CLOSE CursorForderungen
      DEALLOCATE CursorForderungen
    END


    -- Alle ALBV, UeBH, KKBB (AmAnspruchsberechnung) 
    -- ---------------------------------------------
    -- Der Rechtstitel liegt in einem ALBV oder UebH Inkasso
    -- Wenn Rechtstitel definiert ist
    IF (
      (@ProzessCodeRT = 405 AND @IstElternteil = 0) OR -- ALBV
      (@ProzessCodeRT IN (406, 407)) -- UEBH, KKBB
    ) 
    BEGIN 
      -- ALBV Betrag bei Gläubiger ist leer, also ALBVBetrag aus Anspruchsberechnung holen
      DECLARE CursorForderungen CURSOR FAST_FORWARD FOR
        SELECT 
          K.IkRechtstitelID,
          CASE WHEN A.BerechnungDatumAb < @DateBeg THEN @DateBeg ELSE A.BerechnungDatumAb END,
          K.DatumBis,
          Wert3 = CASE 
            WHEN V.AmVerfuegungStatusCode = 4 
              THEN $0.0 -- gestoppt, also Betrag 0
            WHEN (L.FaProzessCode = 404 AND @ProzessCodeRT = 407 AND A.BedingungKKBBErfuellt = 0) 
              THEN $0.0 -- KKBB Bedingung nicht erfüllt, also Betrag 0
            WHEN @ProzessCodeRT IN (405, 406) 
              THEN ( -- ALBV, UeBH
              SELECT ISNULL(Wert3, $0.0) FROM AmAbPosition P
              WHERE P.AmAnspruchsberechnungID = K.AmAnspruchsberechnungID
                AND P.AmAbKindID = K.AmAbKindID
                AND P.AmAbPositionsartID = 730) -- ALBV, UeBH
            ELSE ( -- KKBB
              SELECT ISNULL(Wert3, $0.0)  FROM AmAbPosition P
              WHERE P.AmAnspruchsberechnungID = K.AmAnspruchsberechnungID
                AND P.AmAbPositionsartID = 3290) -- KKBB
          END 
        FROM dbo.AmAbKind K WITH(READUNCOMMITTED)
        LEFT OUTER JOIN dbo.IkRechtstitel R WITH(READUNCOMMITTED) ON R.IkRechtstitelID = K.IkRechtstitelID
        LEFT OUTER JOIN dbo.AmAnspruchsberechnung A WITH(READUNCOMMITTED) ON A.AmAnspruchsberechnungID = K.AmAnspruchsberechnungID
        LEFT OUTER JOIN dbo.AmVerfuegung V WITH(READUNCOMMITTED) ON V.AmVerfuegungID = A.AmVerfuegungID
        LEFT OUTER JOIN dbo.FaLeistung L WITH(READUNCOMMITTED) ON L.FaLeistungID = A.FaLeistungID
        WHERE L.FaFallID = @FallID1
          --AND K.IkRechtstitelID = @RechtstitelID
          AND R.FaLeistungID = @ParamFaLeistungID
          AND K.BaPersonID = @PersonFill
          AND ( (L.FaProzessCode = 402 AND @ProzessCodeRT IN (405, 406)) OR -- nur ALBV, UeBH
                (L.FaProzessCode = 404 AND @ProzessCodeRT = (407))  )        -- nur KKBB
          AND V.AmVerfuegungStatusCode IN (3,4) -- Bewilligt, gestoppt
          AND A.AmBerechnungsStatusCode != 6  -- ignorieren, wenn Stats "ersetzt"
          AND (
             -- Nur ALBV berechtigt: 
            (L.FaProzessCode = 402 AND K.BerechtigtCode = 1 AND @ProzessCodeRT = 405) OR
            -- Nur UebH berechtigt:
            (L.FaProzessCode = 402 AND K.BerechtigtCode = 2 AND @ProzessCodeRT = 406) OR 
            -- Nur KKBB berechtigt:
            (L.FaProzessCode = 404 AND K.BerechtigtCode = 3 AND @ProzessCodeRT = 407) -- AND A.BedingungKKBBErfuellt = 1)    
          )
          AND A.BerechnungDatumAb <= @DateEnd
        ORDER BY A.BerechnungDatumAb DESC, A.AmAnspruchsberechnungID DESC
      OPEN CursorForderungen

      SET @DateTmpTo = @DateEnd
      WHILE 1=1 BEGIN
        FETCH NEXT FROM CursorForderungen INTO @IkRechtstitelID_Frd, @DateTmpFrom, @DateTmpMax, @Betrag
        IF @@FETCH_STATUS != 0 BREAK
        IF (@DateTmpTo > ISNULL(@DateTmpMax, @DateTmpTo)) SET @DateTmpTo = @DateTmpMax
        IF (@DateTmpTo < @DateBeg) SET @DateTmpTo = @DateBeg
        SET @LoopCountDays = CONVERT(INT, DATEDIFF(DAY, @DateTmpFrom, @DateTmpTo)) + 1
        IF ISNULL(@DateTmpMax, @DateTmpTo) >= @DateTmpFrom BEGIN
          INSERT INTO @TmpValues 
            (IkRechtstitelID, ActDate, Days, BaPersonID, BetragALBV)
            VALUES (@IkRechtstitelID_Frd, @DateTmpFrom, @LoopCountDays, @PersonFill, @Betrag)
        END
        SET @DateTmpTo = DATEADD(DAY, -1, @DateTmpFrom);
        IF (@DateTmpTo < @DateBeg) BREAK
      END
      CLOSE CursorForderungen
      DEALLOCATE CursorForderungen
    END
  END
  CLOSE CursorPersonFill
  DEALLOCATE CursorPersonFill

  -- ---------------------------------------------------
  -- Verrechnungen
  -- Daten einfügen: IkVerrechnungskonto, aber nur einmal!!!
  -- select R.*, CASE WHEN R.DatumBis = convert(DateTime,'20071101') THEN R.LetzterMonat ELSE R.BetragProMonat END from IkRatenplan R where convert(DateTime,'20071101') BETWEEN R.DatumVon AND R.DatumBis
  -- select * from IkPosition where IkRechtstitelID = 6009 and Jahr = 2007 and Monat = 11
  -- ---------------------------------------------------
  INSERT INTO @TmpValues 
    (IkRechtstitelID, ActDate, BaPersonID, BetragALBVRaten)
  SELECT 
    R.IkRechtstitelID,
    @DateBeg,
    R.BaPersonID, 
    CASE 
      WHEN R.DatumBis = @DateBeg THEN CASE 
        WHEN X.Value1 = '1' THEN -R.LetzterMonat -- Rückforderung, also Betrag negativ 
        ELSE R.LetzterMonat 
      END
      ELSE CASE 
        WHEN X.Value1 = '1' THEN -R.BetragProMonat -- Rückforderung, also Betrag negativ
        ELSE R.BetragProMonat
      END
    END
  FROM dbo.IkVerrechnungskonto R WITH(READUNCOMMITTED)
  LEFT OUTER JOIN dbo.IkRechtstitel RT WITH(READUNCOMMITTED) ON RT.IkRechtstitelID = R.IkRechtstitelID
  LEFT OUTER JOIN dbo.XLOVCode X WITH(READUNCOMMITTED) ON X.LOVName = 'IkVerrechnungsArt' AND X.Code = R.IkVerrechnungsArtCode
  WHERE RT.FaLeistungID = @ParamFaLeistungID
    AND @DateBeg BETWEEN R.DatumVon AND R.DatumBis
    AND R.IstAnnulliert = 0

-- NUR FUER TESTS:
--SELECT V.* FROM @TmpValues V --where BaPersonID =  205488

--SELECT V.* FROM @TmpValues V where BaPersonID = 209086 --'Tumonika' -- 
-- NUR FUER TESTS:

/*
SELECT 
  V.BaPersonID,
  Tage = @DaysInMonth,
  Punkte = V.Punkte,
  IndexStandBeiBerechnungRT = @IndexStandBeiBerechnungRT,
  TotalAlimentNeu = dbo.fnIkAlimenteRunden(@Rundung, ISNULL(SUM(
        (V.TotalAliment*Days*ISNULL(V.Punkte,100)) / ISNULL(@IndexStandBeiBerechnungRT,100)
      )/@DaysInMonth, 0)),
  TotalAliment1 = dbo.fnIkAlimenteRunden(@Rundung, ISNULL(SUM(V.TotalAliment), 0)),
  BetragALBV1 = ROUND(ISNULL(SUM(V.BetragALBV), 0), 0),
  BetragKinderzulage = ROUND(ISNULL(SUM(V.BetragKiZulage)/@DaysInMonth, 0), 0),
  BetragVerrechg = ISNULL(SUM(V.BetragALBVRaten), 0)
FROM @TmpValues V
GROUP BY BaPersonID, V.Punkte
*/



  -- ---------------------------------------------------
  -- Nicht notwendige Daten löschen:
  -- ---------------------------------------------------
  -- IkForderungPosition
  -- IkPosition
  DELETE dbo.IkPosition
  WHERE FaLeistungID = @ParamFaLeistungID 
    AND Jahr = @ParamBisJahr 
    AND Monat = @ParamBisMonat 
    AND Einmalig = 0
    AND (NOT EXISTS(
      SELECT TOP 1 BUC.KbBuchungID FROM dbo.KbBuchung BUC WITH(READUNCOMMITTED)
      WHERE BUC.IkPositionID = IkPosition.IkPositionID
    ))
    -- 07.05.2008 : sozheo :
    -- AND NOT BaPersonID IN (SELECT BaPersonID FROM @TmpValues)
    AND (
      (BaPersonID NOT IN (SELECT BaPersonID FROM @TmpValues)) OR
      (BaPersonID NOT IN (
         SELECT G.BaPersonID FROM dbo.IkGlaeubiger G WITH(READUNCOMMITTED) 
         LEFT JOIN dbo.IkRechtstitel R on R.IkRechtstitelID = G.IkRechtstitelID
         WHERE R.FaLeistungID = @ParamFaLeistungID
           AND G.IkGlaeubigerStatusCode IN (1,2) ))
    )


  DECLARE 
    @PersonID INT,
    @TotalAliment MONEY,
    @BetragALBV MONEY,
    @BetragALBVVerrechnung MONEY,
    @BetragKiZulage MONEY,
    @IndexStandBeiBerechnungPos MONEY,
    @MonatIstErledigt BIT,
    @IkPositionID INT,
    @HasErrorMaxBetrag INT,
    @LineCounts INT,
    @HatStornierteBuchungen BIT,
    @BetragALBVMaxKonfig MONEY,
    @MaxTotalAliment MONEY,
    @HatMehrereAlteRT BIT

  SET @HasErrorMaxBetrag = 0
  SET @LineCounts = 0

  SET @BetragALBVMaxKonfig = 0
  IF (@ProzessCodeRT = 405)
  BEGIN 
    -- ALBV Maximalwert
    SELECT TOP 1 @BetragALBVMaxKonfig = ValueMoney FROM XCONFIG C1
    WHERE C1.KeyPath='System\Alimente\Anspruchsberechnung\ALBV\maxBetragALBV'
    AND C1.DatumVon <= dbo.fnDateSerial(@ParamBisJahr, @ParamBisMonat, 1) 
    ORDER BY C1.DatumVon DESC
  END

  DECLARE CursorPersons CURSOR FAST_FORWARD FOR
    -- Schlaufe über alle Personen
    SELECT DISTINCT tmp.BaPersonID
    FROM @TmpValues tmp
    UNION ALL
    SELECT DISTINCT P.BaPersonID FROM dbo.IkPosition P WITH(READUNCOMMITTED)
    WHERE P.FaLeistungID = @ParamFaLeistungID 
      AND P.Einmalig = 0 
      AND P.Monat = @ParamBisMonat 
      AND P.Jahr = @ParamBisJahr
      AND P.IkRechtstitelID IS NULL  -- nur neue Daten
      AND NOT EXISTS(SELECT DISTINCT tmp.BaPersonID FROM @TmpValues tmp)
    
  OPEN CursorPersons
  WHILE 1=1 BEGIN
    FETCH NEXT FROM CursorPersons INTO @PersonID
    IF @@FETCH_STATUS <> 0 BREAK

    -- istElternteil holen aus IkGlaeubiger
    SELECT TOP 1 @IstElternteil = G.IstElternteil FROM dbo.IkGlaeubiger G WITH(READUNCOMMITTED)
    LEFT JOIN dbo.IkRechtstitel R ON R.IkRechtstitelID = G.IkRechtstitelID
    WHERE R.FaLeistungID = @ParamFaLeistungID AND G.BaPersonID = @PersonID
      AND G.IkGlaeubigerStatusCode != 9
    -- zuerst den aktiven, dann in Vorbereitung, dann prov eingestellt, dann ungültig alle anderen
    ORDER BY CASE G.IkGlaeubigerStatusCode WHEN 2 THEN 1 WHEN 1 THEN 2 WHEN 3 THEN 3 ELSE 4 END ASC

    -- ---------------------------------------------------
    -- jede Person einzeln updaten:
    -- ---------------------------------------------------
    -- IndexStand holen
    SELECT TOP 1
      @IndexStandBeiBerechnungPos = ISNULL(Q.Punkte, 100),
      @IndexStandVom = ISNULL(Q.PunkteDatum, @DateEnd - 1)
    FROM @TmpValues Q
    WHERE Q.BaPersonID = @PersonID
      AND Q.Punkte IS NOT NULL
      AND Q.PunkteDatum IS NOT NULL
    ORDER BY Q.ActDate DESC

    -- Summen holen:
    SELECT TOP 1
      /*
      @TotalAliment = CASE 
        WHEN (ISNULL(tmp.IkAnpassungsRegelCode, 7) = 7 OR @IkIndexTypCode = 99)
          THEN dbo.fnIkAlimenteRunden(@Rundung, ISNULL( SUM(tmp.TotalAliment*Days)/@DaysInMonth, 0))
        ELSE dbo.fnIkAlimenteRunden(@Rundung, ISNULL( SUM(
          (tmp.TotalAliment*Days*ISNULL(tmp.Punkte,100)) / ISNULL(@IndexStandBeiBerechnungRT,100)
        )/@DaysInMonth, 0))
      END,
      */
      -- Alimente
      @TotalAliment = ISNULL(SUM(dbo.fnIkAlimenteRunden(tmp.Rundung, 
        ISNULL(CASE 
        WHEN (ISNULL(tmp.IkAnpassungsRegelCode, 7) = 7 OR tmp.IkIndexTypCode = 9)
          THEN tmp.TotalAliment*Days
          ELSE tmp.TotalAliment*Days*ISNULL(tmp.Punkte,100) / ISNULL(tmp.IndexStandBeiBerechnungRT,100)
        END, 0)/@DaysInMonth
      )), 0),
      -- Alimente
      @MaxTotalAliment = ISNULL(MAX(dbo.fnIkAlimenteRunden(tmp.Rundung, 
        ISNULL(CASE 
        WHEN (ISNULL(tmp.IkAnpassungsRegelCode, 7) = 7 OR tmp.IkIndexTypCode = 9)
          THEN tmp.TotalAliment
          ELSE tmp.TotalAliment*ISNULL(tmp.Punkte,100) / ISNULL(tmp.IndexStandBeiBerechnungRT,100)
        END, 0)
      )), 0),

      -- ALBV Berechnung
      /*@BetragALBV = CASE WHEN @IkGlaeubigerALBVBetrag IS NULL
        THEN ISNULL(SUM(tmp.BetragALBV*Days)/@DaysInMonth, 0)
        ELSE ISNULL(SUM(tmp.BetragALBV), 0)
      END,*/
      @BetragALBV = SUM(ROUND(ISNULL((tmp.BetragALBV*Days)/@DaysInMonth, 0), 0)),

      -- Verrechnung
      @BetragALBVVerrechnung  = ISNULL(SUM(tmp.BetragALBVRaten), 0),
      -- Kinderzulage
      @BetragKiZulage = ROUND(ISNULL(SUM(tmp.BetragKiZulage*Days)/@DaysInMonth, 0), 2)
    FROM @TmpValues tmp
    WHERE tmp.BaPersonID = @PersonID

    -- Alimente pro Monat ausrechnen
    -- Rundung ist hier nicht merh nötig, da alle Rundungen bei der Summierung angewandt werden
    --SET @TotalAliment = dbo.fnIkAlimenteRunden(@Rundung, ISNULL(@TotalAliment/@DaysInMonth, 0))
    --SET @BetragALBV = ROUND(IsNull(@BetragALBV, 0), 0)

    SET @FehlerInfos = NULL

    IF (@BetragALBV > @BetragALBVMaxKonfig AND @ProzessCodeRT = 405)
    BEGIN
      -- ALBV darf nie grösser als 650.-- sein, Wert ist in konfiguration gespeichert
      SET @BetragALBV = @BetragALBVMaxKonfig
      SET @FehlerInfos = 'ALBV-Total ist grösser als Konfigurationswert'

    END

    IF (@TotalAliment > @MaxTotalAliment AND @ProzessCodeRT = 405)
    BEGIN
      -- Totalaliment soll nie grösser als Maximum werden
      SET @TotalAliment = @MaxTotalAliment
      SET @FehlerInfos = 'Aliment-Total ist grösser als Maximum Pro-Rata'
    END

    IF @TotalAliment<@BetragALBV AND @ProzessCodeRT = 405 BEGIN -- nur bei ALBV
      -- Das Totalaliment ist kleiner als der Betrag ALBV, also ALBV-Betrag gleich Totalaliment setzen
      SET @BetragALBV = @TotalAliment
      SET @HasErrorMaxBetrag = @HasErrorMaxBetrag + 1
      SET @FehlerInfos = 'Das Totalaliment ist kleiner als der Betrag ALBV'
    END 

    SET @IkPositionID = NULL
    SET @HatMehrereAlteRT = NULL
    
    -- Datensatz nach neuem Konzept suchen
    SELECT TOP 1 
      @IkPositionID = P.IkPositionID, 
      @HatMehrereAlteRT = ISNULL(P.HatMehrereAlteRT, 0)
    FROM dbo.IkPosition P 
    WHERE P.FaLeistungID = @ParamFaLeistungID
      AND P.IkRechtstitelID IS NULL
      AND P.BaPersonID = @PersonID
      AND P.Monat = @ParamBisMonat
      AND P.Jahr = @ParamBisJahr
      AND P.Einmalig = 0 


    IF @IkPositionID IS NULL 
    BEGIN
      -- Es gibt keine Datensätze im neuen Konzept
      -- also müssen wir hier alles bereinigen:
      -- Zuerst schauen wir, ob es für diese Person, in diesem Monat mehrere Daten hat
      DECLARE @AnzRT INT
      SELECT @AnzRT = COUNT(*) FROM dbo.IkPosition P 
      WHERE P.FaLeistungID = @ParamFaLeistungID
        AND P.IkRechtstitelID IS NOT NULL
        AND P.BaPersonID = @PersonID
        AND P.Monat = @ParamBisMonat
        AND P.Jahr = @ParamBisJahr
        AND P.Einmalig = 0 

      IF @AnzRT = 0 BEGIN
        -- es gibt auch im alten Konzept keine Daten, 
        -- also muss der Monat einfach neu erstellt werden, keine Korrekturen notwendig
        SET @IkPositionID = NULL
        -- es gibt genau einen Datensatz im neuen Konzept
        SET @HatMehrereAlteRT = NULL
      END ELSE IF @AnzRT = 1
      BEGIN
        -- es gibt genau einen Datensatz im alten Konzept
        -- also kann dieser einfach zum neuen Konzept umgewandelt werden
        SELECT TOP 1 @IkPositionID = P.IkPositionID FROM dbo.IkPosition P 
        WHERE P.FaLeistungID = @ParamFaLeistungID
          AND P.IkRechtstitelID IS NOT NULL
          AND P.BaPersonID = @PersonID
          AND P.Monat = @ParamBisMonat
          AND P.Jahr = @ParamBisJahr
          AND P.Einmalig = 0 
        -- zum neuen Konzept umwandeln
        UPDATE dbo.IkPosition SET IkRechtstitelID = NULL 
        WHERE IkPositionID = @IkPositionID
        
        -- es gibt genau einen Datensatz im neuen Konzept
        SET @HatMehrereAlteRT = NULL
      END ELSE 
      BEGIN
        -- es gibt mehrere Datensätze im alten Konzept
        -- also muss ein neuer Datensatz für das neue Konzept erstellt werden ...
        SET @IkPositionID = NULL
        SET @HatMehrereAlteRT = 1

        -- ... und alle anderen, alten Daten werden so belassen, wie sie sind
        --SELECT TOP 1 @IkPositionID = P.IkPositionID FROM dbo.IkPosition P 
        --LEFT JOIN dbo.IkRechtstitel R ON R.IkRechtstitelID = P.IkRechtstitelID
        --WHERE P.FaLeistungID = @ParamFaLeistungID
        --  AND P.IkRechtstitelID IS NOT NULL
        --  AND P.BaPersonID = @PersonID
        --  AND P.Monat = @ParamBisMonat
        --  AND P.Jahr = @ParamBisJahr
        --  AND P.Einmalig = 0 
        --ORDER BY R.IkRechtstitelGueltigVon DESC

        -- zum neuen Konzept
        --UPDATE dbo.IkPosition SET 
        --  IkRechtstitelID = NULL
        --WHERE IkPositionID = @IkPositionID

        -- alte Daten bereinigen
        UPDATE dbo.IkPosition SET
          --TotalAlimentSoll = 0.0,
          --BetragALBVSoll = 0.0,
          --BetragKiZulageSoll = 0.0,
          --BetragALBVVerrechnungSoll = 0.0
          --BetragZahlungSoll = 0.0
          HatMehrereAlteRT = 1
        WHERE FaLeistungID = @ParamFaLeistungID
          AND IkRechtstitelID IS NOT NULL
          AND BaPersonID = @PersonID
          AND Monat = @ParamBisMonat
          AND Jahr = @ParamBisJahr
          AND Einmalig = 0

      END
    --END ELSE 
    --BEGIN
      -- select Test = 'Es gibt Datensätze im neuen Konzept'
    --END
    END
    
    -- wenn es mehrere RT gibt, soll die Summe der Ist-Werte im neuen Datensatz gespeichert werden
    DECLARE 
      @sumAlimIst MONEY, 
      @sumAlbvIst MONEY, 
      @sumKiZuIst MONEY, 
      @sumVerrech MONEY, 
      @sumZahlung MONEY
      --@sumZahlungSOLL MONEY
      
    IF ISNULL(@HatMehrereAlteRT, 0) = 1
    BEGIN
      -- Summen holen, um Daten des alten Konzepts ins neue zu speichern
      SET @sumAlimIst = 0.0
      SET @sumAlbvIst = 0.0
      SET @sumKiZuIst = 0.0
      SET @sumVerrech = 0.0
      SET @sumZahlung = 0.0
      -- @sumZahlungSOLL = 0.0
      
      SELECT 
        @sumAlimIst = ISNULL(SUM(TotalAliment), 0.0),
        @sumAlbvIst = ISNULL(SUM(BetragALBV), 0.0),
        @sumKiZuIst = ISNULL(SUM(BetragKiZulage), 0.0),
        @sumVerrech = ISNULL(SUM(BetragALBVverrechnung), 0.0),
        @sumZahlung = ISNULL(SUM(BetragZahlung), 0.0)
        --@sumZahlungSOLL = ISNULL(SUM(BetragZahlungSoll), 0.0)
      FROM dbo.IkPosition
      WHERE FaLeistungID = @ParamFaLeistungID
        AND IkRechtstitelID IS NOT NULL
        AND BaPersonID = @PersonID
        AND Monat = @ParamBisMonat
        AND Jahr = @ParamBisJahr
        AND Einmalig = 0
        AND ISNULL(HatMehrereAlteRT, 0) = 1  -- nur zur Sicherheit
    END

        
    -- kontrollieren, ob Monat bereits erledigt ist
    -- --------------------------------------------
    SET @MonatIstErledigt = CONVERT(BIT, CASE WHEN EXISTS(
      SELECT TOP 1 BUC.KbBuchungID FROM dbo.KbBuchung BUC WITH(READUNCOMMITTED)
      WHERE BUC.IkPositionID = @IkPositionID
       AND BUC.KbBuchungStatusCode != 8 
    ) THEN 1 ELSE 0 END)


    -- Stornierte Buchungen suchen
    -- ---------------------------
    SET @HatStornierteBuchungen = CONVERT(BIT, CASE WHEN EXISTS(
      SELECT TOP 1 1 FROM dbo.KbBuchung B WITH(READUNCOMMITTED)
      WHERE B.IkPositionID = @IkPositionID 
        AND B.KbBuchungStatusCode = 8 -- storniert
    ) THEN 1 ELSE 0 END)


    IF (@MonatIstErledigt = 0) 
    BEGIN
      -- -----------------------------
      -- Monat ist noch nicht erledigt  
      -- -----------------------------
      IF @HatStornierteBuchungen = 0 AND 
      ((
        (@ProzessCodeRT = 405) AND -- ALBV
        (@TotalAliment = 0 OR @TotalAliment IS NULL) AND 
        (@BetragALBV = 0 OR @BetragALBV IS NULL) AND 
        (@BetragALBVVerrechnung = 0 OR @BetragALBVVerrechnung IS NULL) AND 
        (@BetragKiZulage = 0 OR @BetragKiZulage IS NULL)
       ) OR
       (
        (@ProzessCodeRT IN (406, 407)) AND --UeBH, KKBB
        (@BetragALBVVerrechnung = 0 OR @BetragALBVVerrechnung IS NULL) AND 
        (@BetragALBV = 0 OR @BetragALBV IS NULL) 
      ))
      BEGIN
        -- Alles null, also löschen
        -- IkPosition
        DELETE dbo.IkPosition
        WHERE IkPositionID = @IkPositionID
        SET @IkPositionID = NULL
      END ELSE 
      BEGIN 
        -- ---------------------------------------------------
        -- Summen speichern:
        -- ---------------------------------------------------
        IF NOT @IkPositionID IS NULL 
        BEGIN
          -- Zeile updaten
          SET @LineCounts = @LineCounts + 1
          UPDATE dbo.IkPosition SET 
            TotalAliment = CASE 
              WHEN ISNULL(@HatMehrereAlteRT, 0) = 1 THEN @sumAlimIst 
              ELSE @TotalAliment 
            END,
            TotalAlimentSoll = @TotalAliment,
            BetragALBV = CASE 
              WHEN @IstElternteil = 1 THEN NULL 
              WHEN ISNULL(@HatMehrereAlteRT, 0) = 1 THEN @sumAlbvIst 
              ELSE @BetragALBV 
            END,
            BetragALBVSoll = CASE 
              WHEN @IstElternteil = 1 THEN NULL 
              ELSE @BetragALBV 
            END,
            BetragALBVVerrechnung = CASE 
              WHEN ISNULL(@HatMehrereAlteRT, 0) = 1 THEN @sumVerrech 
              ELSE @BetragALBVVerrechnung 
            END,
            -- TODO : @BetragALBVVerrechnung ev summe nehmen? wie weiss man, ob es alt oder neu ist
            BetragALBVVerrechnungSoll = CASE
              WHEN ISNULL(@HatMehrereAlteRT, 0) = 1 THEN @sumVerrech
              ELSE @BetragALBVVerrechnung
            END,
            BetragKiZulage = CASE 
              WHEN @IstElternteil = 1 THEN NULL 
              WHEN ISNULL(@HatMehrereAlteRT, 0) = 1 THEN @sumKiZuIst 
              ELSE @BetragKiZulage 
            END,
            BetragKiZulageSoll = CASE 
              WHEN @IstElternteil = 1 THEN NULL 
              ELSE @BetragKiZulage 
            END,
            BetragZahlung = CASE 
              WHEN @IstElternteil = 1 THEN NULL
              WHEN ISNULL(@HatMehrereAlteRT, 0) = 1 THEN @sumZahlung 
              WHEN ISNULL(@BetragALBV,0) + ISNULL(@BetragALBVVerrechnung,0) > 0 
                THEN ISNULL(@BetragALBV,0) + ISNULL(@BetragALBVVerrechnung,0)
              ELSE 0
            END,
            BetragZahlungSoll = CASE 
              WHEN @IstElternteil = 1 THEN NULL
              WHEN ISNULL(@HatMehrereAlteRT, 0) = 1 THEN ISNULL(@BetragALBV,0) 
              WHEN ISNULL(@BetragALBV,0) + ISNULL(@BetragALBVVerrechnung,0) > 0 
                THEN ISNULL(@BetragALBV,0) + ISNULL(@BetragALBVVerrechnung,0)
              ELSE 0
            END,
            IndexStandBeiBerechnung = @IndexStandBeiBerechnungPos, 
            IndexStandDatum = @IndexStandVom,
            FehlerInfos = @FehlerInfos,
            IkRechtstitelID = NULL  -- neues Konzept
          WHERE IkPositionID = @IkPositionID
        END ELSE 
        BEGIN
          -- Neue Zeile einfügen
          SET @LineCounts = @LineCounts + 1
          INSERT INTO dbo.IkPosition (
            FaLeistungID, IkRechtstitelID, Einmalig, 
            Datum, Monat, Jahr, BaPersonID, 
            TotalAliment, BetragALBV, BetragALBVVerrechnung, BetragKiZulage,
            TotalAlimentSoll, BetragALBVSoll, BetragALBVVerrechnungSoll, BetragKiZulageSoll,
            BetragZahlung, BetragZahlungSoll,
            IndexStandBeiBerechnung, IndexStandDatum, FehlerInfos, HatMehrereAlteRT
          ) VALUES (
            @ParamFaLeistungID, NULL, 0,
            dbo.fnDateSerial(@ParamBisJahr, @ParamBisMonat, 1),
            @ParamBisMonat, @ParamBisJahr, @PersonID,
            -- IST-Werte
            CASE 
              WHEN ISNULL(@HatMehrereAlteRT, 0) = 1 THEN @sumAlimIst 
              ELSE @TotalAliment 
            END, 
            CASE 
              WHEN @IstElternteil = 1 THEN NULL 
              WHEN ISNULL(@HatMehrereAlteRT, 0) = 1 THEN @sumAlbvIst 
              ELSE @BetragALBV 
            END, 
            CASE 
              WHEN ISNULL(@HatMehrereAlteRT, 0) = 1 THEN @sumVerrech 
              ELSE @BetragALBVVerrechnung
            END, 
            CASE 
              WHEN @IstElternteil = 1 THEN NULL 
              WHEN ISNULL(@HatMehrereAlteRT, 0) = 1 THEN @sumKiZuIst
              ELSE @BetragKiZulage 
            END,
            -- SOLL-Werte
            @TotalAliment, 
            CASE 
              WHEN @IstElternteil = 1 THEN NULL 
              ELSE @BetragALBV 
            END, 
            CASE 
              WHEN ISNULL(@HatMehrereAlteRT, 0) = 1 THEN @sumVerrech 
              ELSE @BetragALBVVerrechnung 
            END, 
            CASE 
              WHEN @IstElternteil = 1 THEN NULL 
              ELSE @BetragKiZulage 
            END,
            -- Zahlung IST
            CASE
              WHEN @IstElternteil = 1 THEN NULL
              WHEN ISNULL(@HatMehrereAlteRT, 0) = 1 THEN @sumZahlung
              WHEN ISNULL(@BetragALBV,0) + ISNULL(@BetragALBVVerrechnung,0) > 0 
                THEN ISNULL(@BetragALBV,0) + ISNULL(@BetragALBVVerrechnung,0)
              ELSE 0
            END,
            -- Zahlung SOLL
            CASE 
              WHEN @IstElternteil = 1 THEN NULL
              WHEN ISNULL(@HatMehrereAlteRT, 0) = 1 THEN ISNULL(@BetragALBV,0)
              WHEN ISNULL(@BetragALBV,0) + ISNULL(@BetragALBVVerrechnung,0) > 0 
                THEN ISNULL(@BetragALBV,0) + ISNULL(@BetragALBVVerrechnung,0)
              ELSE 0
            END,
            @IndexStandBeiBerechnungPos, @IndexStandVom, @FehlerInfos, ISNULL(@HatMehrereAlteRT, 0)
          )
          SET @IkPositionID = SCOPE_IDENTITY()
        END
      END
    END ELSE BEGIN
      -- -------------------------------------------------------------------------------------
      -- Wenn der Monat bereits erledigt ist, dann sollen nur die Soll-Werte korrigiert werden
      -- Monat ist erledigt  
      -- Zeile updaten
      -- -------------------------------------------------------------------------------------
      SET @LineCounts = @LineCounts + 1
      UPDATE dbo.IkPosition SET 
        TotalAlimentSoll = @TotalAliment,
        BetragALBVSoll = CASE 
          WHEN @IstElternteil = 1 THEN NULL 
          ELSE @BetragALBV 
        END,
        BetragKiZulageSoll = CASE 
          WHEN @IstElternteil = 1 THEN NULL 
          ELSE @BetragKiZulage 
        END,
        BetragALBVVerrechnungSoll = @BetragALBVVerrechnung, 
        BetragZahlungSoll = CASE 
          WHEN @IstElternteil = 1 THEN NULL
          WHEN ISNULL(@HatMehrereAlteRT, 0) = 1 THEN ISNULL(@BetragALBV,0)
          WHEN ISNULL(@BetragALBV,0) + ISNULL(@BetragALBVVerrechnung,0) > 0 
            THEN ISNULL(@BetragALBV,0) + ISNULL(@BetragALBVVerrechnung,0)
          ELSE 0
        END,
        FehlerInfos = @FehlerInfos,
        IkRechtstitelID = NULL  -- neues Konzept
      WHERE IkPositionID = @IkPositionID
    END

    -- Alte n:m-Beziehung löschen:
    DELETE dbo.IkForderungPosition 
    WHERE IkPositionID = @IkPositionID
      AND NOT IkForderungID IN (
        SELECT DISTINCT IkForderungID FROM @TmpValues 
        WHERE IkForderungID IS NOT NULL AND BaPersonID = @PersonID
      )

    DELETE dbo.IkRechtstitelPosition 
    WHERE IkPositionID = @IkPositionID
      AND NOT IkRechtstitelID IN (
        SELECT DISTINCT IkRechtstitelID FROM @TmpValues 
        WHERE IkRechtstitelID IS NOT NULL AND BaPersonID = @PersonID
      )


    IF @IkPositionID IS NOT NULL BEGIN
      -- Jetzt noch n:m-Beziehung füllen: IkForderungPosition
      -- ----------------------------------------------------
      DECLARE crsFordPos CURSOR FAST_FORWARD FOR
        SELECT DISTINCT IkForderungID FROM @TmpValues 
        WHERE IkForderungID IS NOT NULL AND BaPersonID = @PersonID
      OPEN crsFordPos
      WHILE 1=1 BEGIN
        FETCH NEXT FROM crsFordPos INTO @IkForderungID
        IF @@FETCH_STATUS <> 0 BREAK
        -- neue einfügen
        IF NOT EXISTS(
          SELECT IkForderungID FROM dbo.IkForderungPosition WITH(READUNCOMMITTED)
          WHERE IkForderungID = @IkForderungID AND IkPositionID = @IkPositionID)
        BEGIN
          INSERT INTO dbo.IkForderungPosition (IkForderungID, IkPositionID)
            VALUES (@IkForderungID, @IkPositionID)
        END
      END
      CLOSE crsFordPos
      DEALLOCATE crsFordPos

      -- Jetzt noch n:m-Beziehung füllen: IkRechtstitelPosition
      -- ----------------------------------------------------
      DECLARE crsRTPos CURSOR FAST_FORWARD FOR
        SELECT DISTINCT IkRechtstitelID FROM @TmpValues 
        WHERE IkRechtstitelID IS NOT NULL AND BaPersonID = @PersonID
      OPEN crsRTPos
      WHILE 1=1 BEGIN
        FETCH NEXT FROM crsRTPos INTO @IkRechtstitelID_Frd
        IF @@FETCH_STATUS <> 0 BREAK
        -- neue einfügen
        IF NOT EXISTS(
          SELECT IkRechtstitelID FROM dbo.IkRechtstitelPosition WITH(READUNCOMMITTED)
          WHERE IkRechtstitelID = @IkRechtstitelID_Frd AND IkPositionID = @IkPositionID)
        BEGIN
          INSERT INTO dbo.IkRechtstitelPosition (IkRechtstitelID, IkPositionID)
            VALUES (@IkRechtstitelID_Frd, @IkPositionID)
        END
      END
      CLOSE crsRTPos
      DEALLOCATE crsRTPos
    END

  END
  CLOSE CursorPersons
  DEALLOCATE CursorPersons


  -- ---------------------------------------------------
  -- temporäre Tabellen löschen:
  -- ---------------------------------------------------
  --DROP TABLE #TmpDates
  --DROP TABLE @TmpValues

-- NUR FUER TESTS:
--SELECT V.* FROM IkPosition V 
--WHERE IkRechtstitelID = @RechtstitelID AND Jahr = @ParamBisJahr AND Monat = @ParamBisMonat

  -- Resultate zurückliefern
  --SELECT 0 AS HasErrors, @HasErrorMaxBetrag AS HasErrorMaxBetrag, @LineCounts AS LineCounts
  RETURN @LineCounts

END

GO