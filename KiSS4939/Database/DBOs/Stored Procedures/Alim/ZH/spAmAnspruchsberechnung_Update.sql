SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAmAnspruchsberechnung_Update
GO
/*===============================================================================================
  $Revision: 4$
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
-- ===================================================================================================
-- Author:		sozheo
-- Create date: 06.08.2007
-- Description:	Updaten der Tabelle AmAbKind und AbAmPosition
-- wird in CtlAmAbAnspruchsberechnung verwendet
/*
select * from AmAnspruchsberechnung where AmAnspruchsberechnungID = 136
DECLARE dat1 DateTime
SET dat1 = GetDate()
EXEC dbo.spAmAnspruchsberechnung_Update 1, 136, 2, 4, '20080101'

select * from AmAbPosition where AmAnspruchsberechnungID = 136 order by AmAbPositionsartID

*/

-- ===================================================================================================
-- History:
-- 13.08.2007 : sozheo : SQL Doppelverdiener korrigiert
-- 13.08.2007 : sozheo : Typ als Parameter eingefügt
-- 16.08.2007 : sozheo : Block Kind nur einfügen, wenn ALBV berechtigt
-- 29.08.2007 : sozheo : Konfigurationswerte holen neu gemacht
-- 31.08.2007 : sozheo : Neue Zeile 305, ALBV
-- 06.09.2007 : sozheo : Neue Felder in AmAbPosition
-- 26.09.2007 : sozheo : Das Füllen der Nummer 281 ist nicht mehr notwendig
-- 04.11.2007 : sozheo : Anpassungen für KKBB
-- 20.11.2007 : sozheo : Anpassungen für Zusammmenzug ALBV und UeBH
-- 22.11.2007 : sozheo : Anpassungen für Zusammmenzug ALBV und UeBH
-- 23.11.2007 : sozheo : Anpassungen für neue Einkommensvarianten
-- 25.11.2007 : sozheo : Anpassungen für neue Einkommensvarianten
-- 26.11.2007 : sozheo : Anpassungen für neue Einkommensvarianten
-- 29.11.2007 : sozheo : Anpassungen für mündige Jugendliche
-- 01.02.2008 : sozheo : KKBB abhängig von Einkommensvariante gemacht
-- 02.02.2008 : sozheo : Tabellen umbennen
-- 21.02.2008 : sozheo : A80....A84 ausblenden bei "nur selbständig", "kein Einkommen"
-- 21.02.2008 : sozheo : H224 ausblenden bei "kein Einkommen"
-- 25.02.2008 : sozheo : Einkommensvariante 5 und 6 entfernt
-- 26.02.2008 : sozheo : Positionen für KKBB, selbständig angepasst
-- 07.03.2008 : sozheo : Positionen für KKBB, Kein Verdienst angepasst
-- 08.03.2008 : sozheo : Positionen für ALBV angepasst
-- 11.03.2008 : sozheo : Positionen für KKBB angepasst
-- 18.03.2008 : sozheo : Positionen für KKBB angepasst
-- 09.04.2008 : sozheo : Text für K511 angepasst
-- 15.04.2008 : sozheo : Text für K512 und UeBH angepasst
-- 16.05.2008 : sozheo : Korrekturen für Kind mit Vormundschaft
-- ===================================================================================================


CREATE PROCEDURE [dbo].[spAmAnspruchsberechnung_Update]
  -- Typ: 1 = ALBV, 2 = üBH, 3 = KKBB
  @Typ INT,
  -- Schlüssel Anspruchsberechnung:
  @AnspruchsberechnungID INT,
  -- Typ Berechnung, Alleinstehend / Verheiratet / Mündige Jugendliche / Kind mit VM :
  @ZivilstandCode INT = 0,
  -- Typ des Verdieners: 1 = Einverdiener, 2 = Doppelverdiener, 3 = Kein Einkommen, 4 = Kein Verdienst
  @EinkommensvarianteCode INT = 0,
  -- Stichdatum
  @ActualDate DATETIME = NULL
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON;

  IF @Typ IS NULL OR @Typ > 3 OR @Typ < 1  BEGIN
    RAISERROR('Fehler in Parameter: Der Parameter @Typ ist ungültig.',18,1)
    RETURN -1
  END
  IF @AnspruchsberechnungID IS NULL OR @AnspruchsberechnungID = 0 BEGIN
    RAISERROR('Fehler in Parameter: Der Parameter @AnspruchsberechnungID ist zwingend.',18,1)
    RETURN -1
  END
  IF @ActualDate IS NULL BEGIN
    RAISERROR('Fehler in Parameter: Das Datum @ActualDate ist zwingend.',18,1)
    RETURN -1
  END

  DECLARE
    @FaFallID INT,
    @BaClientID INT
  SELECT @FaFallID = L.FaFallID, @BaClientID = L.BaPersonID
  FROM AmAnspruchsberechnung A
    LEFT OUTER JOIN FaLeistung L ON L.FaLeistungID = A.FaLeistungID
    --LEFT OUTER JOIN FaFall F ON F.FaFallID = L.FaFallID
  WHERE A.AmAnspruchsberechnungID = @AnspruchsberechnungID

  -- Füllen der Tabelle AmAbPosition für Klient:
  IF @Typ = 1 BEGIN
    -- ALBV, UeBH
    INSERT INTO AmAbPosition
      (AmAnspruchsberechnungID, AmAbPositionsartID, ParentID, Text, Wert1, Wert2,
       Sortierung1, Sortierung2, Mengeneinheit1, Mengeneinheit2, Format1, Format2)
    SELECT
      @AnspruchsberechnungID, A.AmAbPositionsartID, A.ParentID, A.Text, A.Default1, A.Default2,
      A.Sortierung1, A.Sortierung2, A.Mengeneinheit1, A.Mengeneinheit2, A.Format1, A.Format2
    FROM AmAbPositionsart A
    WHERE A.Typ = @Typ
    AND A.Kind=0
    AND (
      (A.AmAbPositionsartID BETWEEN   0 AND  11) OR
      (A.AmAbPositionsartID BETWEEN  12 AND 13 AND @ZivilstandCode IN (1,2,3,5)) OR -- nicht bei mündige Jugendliche
      (A.AmAbPositionsartID BETWEEN  14 AND  29) OR
      (A.AmAbPositionsartID = 30 AND @EinkommensvarianteCode IN (1,2,7)) OR
      (A.AmAbPositionsartID BETWEEN  31 AND  40 AND @EinkommensvarianteCode IN (1,2)) OR

      (A.AmAbPositionsartID BETWEEN  41 AND  42 AND @EinkommensvarianteCode IN (1,2,7)) OR
      (A.AmAbPositionsartID BETWEEN  43 AND  44 AND @EinkommensvarianteCode IN (1,2)) OR
      (A.AmAbPositionsartID BETWEEN  45 AND  59 AND @EinkommensvarianteCode IN (1,2,7)) OR

      (A.AmAbPositionsartID BETWEEN  60 AND  69 AND @EinkommensvarianteCode IN (1,2)) OR
      (A.AmAbPositionsartID BETWEEN  70 AND  79 AND @EinkommensvarianteCode IN (1,2,7)) OR

      -- 21.02.2008 : sozheo : A80....A84 ausblenden bei "nur selbständig", "kein Einkommen"
      --(A.AmAbPositionsartID BETWEEN  80 AND  99) OR
      (A.AmAbPositionsartID BETWEEN  80 AND  99 AND @EinkommensvarianteCode IN (1,2)) OR -- nicht 3, 7 ("kein Einkommen, "nur selbständig")

      (A.AmAbPositionsartID BETWEEN 100 AND 199 AND @EinkommensvarianteCode IN (2)) OR

      -- 21.02.2008 : sozheo : H224 ausblenden bei "kein Einkommen"
      -- 09.03.2008 : sozheo : H221 ausblenden bei "Jugendlichen"
      (A.AmAbPositionsartID BETWEEN 200 AND 201 AND @EinkommensvarianteCode IN (1,2,4)) OR
      (A.AmAbPositionsartID = 202 AND @EinkommensvarianteCode IN (1,2,4) AND @ZivilstandCode != 4) OR
      (A.AmAbPositionsartID BETWEEN 203 AND 220 AND @EinkommensvarianteCode IN (1,2,4)) OR
      (A.AmAbPositionsartID = 221 AND @EinkommensvarianteCode IN (1,2,4) AND @ZivilstandCode != 4) OR
      (A.AmAbPositionsartID BETWEEN 222 AND 223 AND @EinkommensvarianteCode IN (1,2,4)) OR
      (A.AmAbPositionsartID = 224 AND @EinkommensvarianteCode IN (1,2) AND @ZivilstandCode IN (1,2,3,5)) OR

      (A.AmAbPositionsartID BETWEEN 225 AND 249 AND @EinkommensvarianteCode IN (1,2,4)) OR
      (A.AmAbPositionsartID = 250 AND @EinkommensvarianteCode IN (1,2,3,4)) OR
      (A.AmAbPositionsartID BETWEEN 251 AND 258 AND @EinkommensvarianteCode IN (1,2,4)) OR
      (A.AmAbPositionsartID = 259 AND @EinkommensvarianteCode IN (1,2,3,4)) OR

      (A.AmAbPositionsartID BETWEEN 260 AND 999)
    )
    AND NOT A.AmAbPositionsartID IN
      (SELECT AmAbPositionsartID FROM AmAbPosition
       WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
       AND AmAbKindID IS NULL)


    IF @ZivilstandCode = 4 BEGIN
      -- bei mündigen Jugendlichen gibt es A12 nicht (zuzgl. Bertag pro Kind)
      DELETE AmAbPosition
      WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND (
        (AmAbPositionsartID BETWEEN 12 AND 13) OR
        AmAbPositionsartID = 202 OR
        AmAbPositionsartID = 221 OR
        AmAbPositionsartID = 224
      )
    END


    -- Jetzt noch kontrollieren, ob der 2. Teil bei Doppelverdiener gelöscht werden mnuss 
    IF NOT @EinkommensvarianteCode = 2 BEGIN
      -- 2 Verdiener, also löschen falls Daten noch vorhanden 
      DELETE AmAbPosition
      WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbKindID IS NULL
      AND AmAbPositionsartID BETWEEN 100 AND 199
    END

    IF @EinkommensvarianteCode IN (3) BEGIN
      -- kein Einkommen, also löschen falls Daten noch vorhanden 
      DELETE AmAbPosition
      WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbKindID IS NULL
      -- 21.02.2008 : sozheo : A80....A84 ausblenden bei "nur selbständig", "kein Einkommen"
      --AND (AmAbPositionsartID BETWEEN  30 AND  69 OR AmAbPositionsartID BETWEEN 200 AND 259)
      AND (
        AmAbPositionsartID BETWEEN  30 AND  99 OR
        AmAbPositionsartID BETWEEN 200 AND 249 OR
        AmAbPositionsartID BETWEEN 251 AND 258
      )
    END

    IF @EinkommensvarianteCode = 4 BEGIN
      -- kein Verdienst, also löschen falls Daten noch vorhanden 
      DELETE AmAbPosition
      WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbKindID IS NULL
      AND (
        AmAbPositionsartID BETWEEN 30 AND 99  OR
        AmAbPositionsartID = 224
      )
    END

    IF @EinkommensvarianteCode = 7 BEGIN
      -- nur selbständig, also löschen falls Daten noch vorhanden 
      DELETE AmAbPosition
      WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbKindID IS NULL
      AND (
        AmAbPositionsartID BETWEEN 31 AND 40 OR
        AmAbPositionsartID BETWEEN 43 AND 44 OR
        AmAbPositionsartID BETWEEN 60 AND 69 OR
        -- 21.02.2008 : sozheo : A80....A84 ausblenden bei "nur selbständig", "kein Einkommen"
        AmAbPositionsartID BETWEEN 80 AND 99 OR
        -- 21.02.2008 : sozheo : H224 ausblenden bei "kein Einkommen"
        AmAbPositionsartID BETWEEN 200 AND 249
  )
    END


    IF @ZivilstandCode IN (4,5) -- bei mündigen Jugendlichen 
    BEGIN
      -- bei mündigen Jugendlichen dürfen keine anderen Personen/Kinder hinzugefügt sein
      DELETE AmAbPosition
      WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
        AND AmAbKindID IN (
          SELECT AmAbKindID FROM AmAbKind
          WHERE BaPersonID IN ( SELECT BaPersonID FROM FaFallPerson WHERE FaFallID = @FaFallID )
            AND NOT BaPersonID = @BaClientID)
      DELETE AmAbKind
      WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
        AND BaPersonID IN ( SELECT BaPersonID FROM FaFallPerson WHERE FaFallID = @FaFallID )
        AND NOT BaPersonID = @BaClientID
    END ELSE BEGIN
      -- bei allen anderen darf der Fallträger nicht enthalten sein
      DELETE AmAbPosition
      WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
        AND AmAbKindID IN (
          SELECT AmAbKindID FROM AmAbKind WHERE BaPersonID = @BaClientID )
      DELETE AmAbKind
      WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
        AND BaPersonID = @BaClientID
    END

    -- Füllen der Daten für Kinder:
    INSERT INTO AmAbPosition
      (AmAnspruchsberechnungID, AmAbPositionsartID, AmAbKindID, ParentID, Text, Wert1, Wert2,
       Sortierung1, Sortierung2, Mengeneinheit1, Mengeneinheit2, Format1, Format2)
    SELECT
      @AnspruchsberechnungID, A.AmAbPositionsartID, K.AmAbKindID, A.ParentID,
      CASE
        WHEN A.Sortierung1='Y' AND K.BerechtigtCode = 1 THEN A.Text + ' ' + N.Name + IsNull(' ' + N.Vorname,'') + ' ALBV'
        WHEN A.Sortierung1='Y' AND K.BerechtigtCode = 2 THEN A.Text + ' ' + N.Name + IsNull(' ' + N.Vorname,'') + ' UeBH'
        ELSE A.Text
      END,
      A.Default1, A.Default2,
      A.Sortierung1, A.Sortierung2, A.Mengeneinheit1, A.Mengeneinheit2, A.Format1, A.Format2
    FROM AmAbPositionsart A
    CROSS JOIN AmAbKind K
    LEFT OUTER JOIN BaPerson N on N.BaPersonID=K.BaPersonID
    WHERE A.Typ = @Typ
    AND A.Kind=1
    AND (
      (A.AmAbPositionsartID BETWEEN 500 AND 513) OR
      (A.AmAbPositionsartID BETWEEN 514 AND 527 AND @ZivilstandCode IN (1,2,3,5)) OR -- nicht bei Jugendlichen
      (A.AmAbPositionsartID BETWEEN 528 AND 999)
    )
    AND K.AmAnspruchsberechnungID=@AnspruchsberechnungID
    AND (K.BerechtigtCode=1 OR K.BerechtigtCode=2)
    AND NOT A.AmAbPositionsartID IN (
      SELECT Q.AmAbPositionsartID FROM AmAbPosition Q
      WHERE Q.AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND Q.AmAbKindID = K.AmAbKindID)

    --IF NOT @ZivilstandCode IN (1,2,3) BEGIN
    IF @ZivilstandCode = 4 BEGIN
      -- bei mündigen Jugendlichen
      DELETE AmAbPosition
        WHERE AmAnspruchsberechnungID = @AnspruchsberechnungID
        AND AmAbPositionsartID BETWEEN 514 AND 527
    END

    -- Spezielle Texte
    -- A10 : Speziell bei mündige Jugendliche 
    UPDATE AmAbPosition SET Text = CASE WHEN @ZivilstandCode = 4
      THEN 'Berechnung Anspruchsgrenze Mündige Jugendliche'
      ELSE 'Berechnung Anspruchsgrenze Elterneinkommen'
    END
    WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbPositionsartID = 10
    -- A11 : Speziell bei mündige Jugendliche 
    UPDATE AmAbPosition SET Text = CASE WHEN @ZivilstandCode = 4
      THEN 'Anspruchsgrenze Mündige Jugendliche'
      ELSE 'Elterngrenze'
    END
    WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbPositionsartID = 11

    -- A13 : Speziell bei mündige Jugendliche 
    UPDATE AmAbPosition SET Text = CASE WHEN @ZivilstandCode = 4
      THEN 'Anspruchsgrenze Mündige Jugendliche*'
      ELSE 'Anspruchsgrenze Elterneinkommen*'
    END
    WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbPositionsartID = 13

    -- A30 : Speziell bei mündigen Jugendliche 
    UPDATE AmAbPosition SET Text = CASE WHEN @EinkommensvarianteCode = 7
      THEN 'Einkommen aus selbständiger Erwerbstätigkeit'
      ELSE 'Verdienstabhängiges Einkommen'
    END
    WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbPositionsartID = 30

    -- H200 : Speziell bei mündige Jugendliche 
    UPDATE AmAbPosition SET Text = CASE WHEN @ZivilstandCode = 4
      THEN 'Berechnung der Einkünfte'
      ELSE 'Berechnung der Familieneinkünfte'
    END
    WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbPositionsartID = 200
    -- H200 : Speziell bei mündige Jugendliche 
    UPDATE AmAbPosition SET Text = CASE WHEN @ZivilstandCode = 4
      THEN 'Total Einkünfte*'
      ELSE 'Total Familieneinkünfte*'
    END
    WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbPositionsartID = 206

    -- H200 : Speziell bei mündige Jugendliche 
    UPDATE AmAbPosition SET Text = CASE WHEN @ZivilstandCode = 4
      THEN 'Berechnung der Abzüge'
      ELSE 'Berechnung der Familienabzüge'
    END
    WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbPositionsartID = 220

    -- H222 : Speziell bei mündige Jugendliche 
    UPDATE AmAbPosition SET Text = CASE WHEN @ZivilstandCode = 4
      THEN 'Versicherungsabzug'
      ELSE 'Versicherungsabzug Eltern'
    END
    WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbPositionsartID = 222

    -- 250 : Speziell bei mündige Jugendliche 
    UPDATE AmAbPosition SET Text = CASE WHEN @ZivilstandCode = 4
      THEN 'Total Einkünfte'
      ELSE 'Total Familieneinkünfte'
    END
    WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbPositionsartID = 250


    -- K511: Speziell K511, verschiedene Texte bei ALBV und UeBH
    UPDATE ABP SET
      ABP.Mengeneinheit2 = CASE
        WHEN K.BerechtigtCode = 1 THEN '0=man./1=Al.'
        WHEN K.BerechtigtCode = 2 THEN 'pro Monat'
        ELSE NULL
      END,
      ABP.Wert2 = CASE
        WHEN K.BerechtigtCode = 2 THEN 1 -- bei UebH immer 1
        WHEN ABP.Wert2 IS NULL THEN 1
        WHEN NOT ABP.Wert2 IN (0,1) THEN 1
        ELSE ABP.Wert2
      END
    FROM AmAbPosition ABP
    INNER JOIN AmAbKind K ON K.AmAbKindID = ABP.AmAbKindID
    WHERE ABP.AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND K.BerechtigtCode IN (1,2)
      AND ABP.AmAbPositionsartID = 511

    -- K512: Speziell K512, verschiedene Texte bei ALBV und UeBH
    UPDATE ABP SET
      ABP.Text = CASE
        WHEN K.BerechtigtCode = 2 THEN 'Maximale Überbrückungshilfe' -- beu UeBH
        ELSE 'Maximaler Bevorschussungsbetrag'
      END
    FROM AmAbPosition ABP
    INNER JOIN AmAbKind K ON K.AmAbKindID = ABP.AmAbKindID
    WHERE ABP.AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND K.BerechtigtCode IN (1,2)
      AND ABP.AmAbPositionsartID = 512

    -- Löschen der Kinder, falls die ALBV-Berechtigung entfernt wurde:
    DELETE AmAbPosition
    WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
    AND NOT AmAbKindID IS NULL
    AND AmAbKindID IN (
      SELECT L.AmAbKindID FROM AmAbKind L
      WHERE L.AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND NOT (L.BerechtigtCode = 1 OR L.BerechtigtCode = 2)
    )
  END ELSE IF @Typ = 3 BEGIN

    -- ------------------------
    -- KKBB
    -- ------------------------
    -- select * from AmAbPositionsart where Typ = 3
    INSERT INTO AmAbPosition
      (AmAnspruchsberechnungID, AmAbPositionsartID, ParentID, Text, Wert1, Wert2,
       Sortierung1, Sortierung2, Mengeneinheit1, Mengeneinheit2, Format1, Format2)
    SELECT
      @AnspruchsberechnungID, A.AmAbPositionsartID, A.ParentID, A.Text, A.Default1, A.Default2,
      A.Sortierung1, A.Sortierung2, A.Mengeneinheit1, A.Mengeneinheit2, A.Format1, A.Format2
    FROM AmAbPositionsart A
    WHERE A.Typ = @Typ
    AND A.Kind=0
    --AND ( (A.Sortierung1 <> 'E') OR ((@EinkommensvarianteCode = 2) AND (A.Sortierung1 = 'E')) )
    AND (
/*
AmEinkommensvariante	1	1 Verdiener
AmEinkommensvariante	2	2 Verdiener
AmEinkommensvariante	3	Kein Einkommen
AmEinkommensvariante	4	Kein Verdienst
AmEinkommensvariante	7	nur selbständig
*/

      (A.AmAbPositionsartID BETWEEN   3000 AND  3029) OR
      (A.AmAbPositionsartID = 3030 AND @EinkommensvarianteCode IN (1,2,7)) OR
      (A.AmAbPositionsartID = 3031 AND @EinkommensvarianteCode IN (1,2)) OR
      (A.AmAbPositionsartID = 3032 AND @EinkommensvarianteCode IN (1,2,7)) OR
      (A.AmAbPositionsartID = 3033 AND @EinkommensvarianteCode IN (1,2,7) AND @ZivilstandCode IN (2)) OR

      (A.AmAbPositionsartID BETWEEN 3034 AND 3059 AND @EinkommensvarianteCode IN (1,2,7)) OR
      (A.AmAbPositionsartID BETWEEN 3060 AND 3069 AND @EinkommensvarianteCode IN (1,2)) OR
      (A.AmAbPositionsartID BETWEEN 3070 AND 3074 AND @EinkommensvarianteCode IN (1,2,7)) OR
      (A.AmAbPositionsartID = 3075 AND @EinkommensvarianteCode IN (1,2)) OR
      (A.AmAbPositionsartID BETWEEN 3076 AND 3079 AND @EinkommensvarianteCode IN (1,2,7)) OR

      (A.AmAbPositionsartID BETWEEN 3080 AND 3081 AND @EinkommensvarianteCode IN (1,2,7)) OR
      (A.AmAbPositionsartID = 3082 AND @EinkommensvarianteCode IN (1,2)) OR
      (A.AmAbPositionsartID BETWEEN 3083 AND 3099 AND @EinkommensvarianteCode IN (1,2,7)) OR

      (A.AmAbPositionsartID BETWEEN 3100 AND 3199 AND @EinkommensvarianteCode IN (2)) OR
      (A.AmAbPositionsartID = 3200) OR
      (A.AmAbPositionsartID BETWEEN 3201 AND 3202 AND @EinkommensvarianteCode IN (1,2,7)) OR

      (A.AmAbPositionsartID BETWEEN 3203 AND 3214 AND @EinkommensvarianteCode IN (1,2,4,7)) OR
      (A.AmAbPositionsartID = 3215) OR
      (A.AmAbPositionsartID BETWEEN 3216 AND 3219 AND @EinkommensvarianteCode IN (1,2,4,7)) OR
      (A.AmAbPositionsartID = 3220) OR

      (A.AmAbPositionsartID BETWEEN 3221 AND 3222 AND @EinkommensvarianteCode IN (1,2,7)) OR
      (A.AmAbPositionsartID = 3223 AND @EinkommensvarianteCode IN (1,2,4,7)) OR
      (A.AmAbPositionsartID BETWEEN 3224 AND 3230 AND @EinkommensvarianteCode IN (1,2,7)) OR

      (A.AmAbPositionsartID BETWEEN 3231 AND 3232 AND @EinkommensvarianteCode IN (1,2,4,7)) OR
      (A.AmAbPositionsartID BETWEEN 3233 AND 3242 AND @EinkommensvarianteCode IN (1,2,7)) OR
      (A.AmAbPositionsartID BETWEEN 3243 AND 3248 AND @EinkommensvarianteCode IN (1,2,4,7)) OR
      (A.AmAbPositionsartID = 3249) OR
      (A.AmAbPositionsartID BETWEEN 3250 AND 3259 AND @EinkommensvarianteCode IN (1,2,4,7)) OR

      (A.AmAbPositionsartID BETWEEN 3260 AND 3999)
    )
    AND NOT A.AmAbPositionsartID IN
      (SELECT AmAbPositionsartID FROM AmAbPosition
       WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
       AND AmAbKindID IS NULL)

    -- Jetzt noch kontrollieren, ob der 2. Teil bei Doppelverdiener gelöscht werden mnuss 
    IF NOT @EinkommensvarianteCode = 2 BEGIN
      -- Alleinstehend, also löschen falls Daten noch vorhanden 
      DELETE AmAbPosition
      WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbPositionsartID BETWEEN 3101 AND 3199
    END

    IF NOT @ZivilstandCode IN (2) BEGIN
      -- 1 Alleinstehend
      DELETE AmAbPosition
      WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbPositionsartID = 3033  -- Anzug Erwerb alleinstehende 
    END

    IF @EinkommensvarianteCode IN (3) BEGIN
      -- 3 kein Einkommen, also löschen falls Daten noch vorhanden 
      DELETE AmAbPosition
      WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND (
        AmAbPositionsartID BETWEEN 3030 AND 3099 OR
        AmAbPositionsartID BETWEEN 3201 AND 3214 OR
        AmAbPositionsartID BETWEEN 3216 AND 3219 OR
        AmAbPositionsartID BETWEEN 3221 AND 3248 OR
        AmAbPositionsartID BETWEEN 3250 AND 3259
      )
    END
    IF @EinkommensvarianteCode IN (4) BEGIN
      -- 4 kein Verdienst, also löschen falls Daten noch vorhanden 
      DELETE AmAbPosition
      WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND (
        AmAbPositionsartID BETWEEN 3030 AND 3199 OR
        AmAbPositionsartID BETWEEN 3201 AND 3202 OR
        AmAbPositionsartID BETWEEN 3221 AND 3222 OR
        AmAbPositionsartID BETWEEN 3224 AND 3230 OR
        AmAbPositionsartID BETWEEN 3233 AND 3242
      )
    END
    IF @EinkommensvarianteCode IN (7) BEGIN
      -- nur selbständig, also löschen falls Daten noch vorhanden 
      DELETE AmAbPosition
      WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND (
        AmAbPositionsartID IN (3031,3082, 3075)  OR
        AmAbPositionsartID BETWEEN 3060 AND 3069
      )
    END

    -- Spezielle Texte
    -- ---------------    

    -- 3200 : alleinstehend
    UPDATE AmAbPosition SET Text = CASE
      WHEN @EinkommensvarianteCode = 3 THEN 'Total Familieneinkünfte'  -- kein Einkommen
      ELSE 'Verdienstunabhängige Einkünfte'
    END
    WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbPositionsartID = 3200

    -- 3215 : alleinstehend
    UPDATE AmAbPosition SET Text = CASE WHEN @EinkommensvarianteCode = 3
      THEN 'Total anrechenbares Einkommen*'
      ELSE 'Total Einkünfte*'
    END
    WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbPositionsartID = 3215

    -- 3250 : alleinstehend
    UPDATE AmAbPosition SET Text = CASE WHEN @ZivilstandCode = 2
      THEN 'Total Einkünfte*'
      ELSE 'Total Familieneinkünfte*'
    END
    WHERE AmAnspruchsberechnungID=@AnspruchsberechnungID
      AND AmAbPositionsartID = 3250

  END

  -- Daten aus der Konfiguration holen:
  EXEC dbo.spAmAnspruchsberechnung_UpdateConfigAll @Typ, @AnspruchsberechnungID,
       @ZivilstandCode, @ActualDate

END

