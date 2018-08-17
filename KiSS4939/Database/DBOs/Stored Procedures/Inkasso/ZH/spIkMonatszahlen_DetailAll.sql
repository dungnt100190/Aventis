SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spIkMonatszahlen_DetailAll
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spIkMonatszahlen_DetailAll.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 11:21 $
  $Revision: 11 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spIkMonatszahlen_DetailAll.sql $
 * 
 * 11    11.12.09 11:57 Lloreggia
 * Header aktualisiert
 * 
 * 10    8.08.09 18:09 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 9     28.06.09 16:56 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 8     25.06.09 14:21 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 7     24.06.09 16:13 Rhesterberg
 * #32: ALIM5 Monatszahlen übgeordnet
 * 
 * 6     22.06.09 14:38 Rhesterberg
 * #4534: Sollgestellte einmalige Forderungen mit falscher LA-Nummer
 * (Sicherung nach Umstellung DB->Core)
 * 
 * 5     10.04.09 12:08 Rhesterberg
 * Sicherung vor Umbau Monatszahlen
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
Create date: 25.02.2008
Description: Updaten der Tabelle IkMonatszahlen, für alle Daten
TESTS: 
EXEC dbo.spIkMonatszahlen_Detail 49697, 14766, 2007, 11
Tests von Walter:
EXEC dbo.spIkMonatszahlen_Detail 51191, 6145, 2008, 3


Tests Kiss4_BSS_Master:
select * from FaFall
select * from IkPosition
select * from IkRechtstitel where IkRechtstitelID = 6145
select * from FaLeistung where FaLeistungID = 65300

declare @res int
EXEC @res = dbo.spIkMonatszahlen_DetailAll NULL, 6145, 1
print convert(varchar, @res)

===================================================================================================
History:
17.03.2008 : sozheo : neu erstellt
18.03.2008 : sozheo : Verlagerung der Berechnung mit FaLeistung
27.03.2008 : sozheo : Korrektur Minmaldatum ALBV/Uebh/KKBB
11.04.2008 : sozheo : Löschen hinzugefügt
15.04.2008 : sozheo : Löschen korrigiert
20.06.2008 : sozheo : Stornierte Buchungen berücksichtigen
05.08.2008 : sozheo : IkPosition.ErledigterMonat eliminiert
12.01.2009 : sozheo : Korrekturen SQL Performance
18.01.2009 : sozheo : Korrekturen Rückgabewert
19.01.2009 : sozheo : Änderungen SQL Performance
02.04.2009 : sozheo : Neu über LeistungID
09.04.2009 : sozheo : Neu überspielt von Backup
10.04.2009 : sozheo : Neu umgebaut für Tests
23.06.2009 : sozheo : Neue Logik Monatszahlen umgesetzt
24.06.2009 : sozheo : Parameter RT entfernt
===================================================================================================
*/

CREATE PROCEDURE [dbo].[spIkMonatszahlen_DetailAll]
  -- Leistung
  @LeistungID INT,
  -- Modus: 
  -- 1 = Alle Daten eines Rechtstitels
  -- 2 = Nur fehlende Monate am ergänzen
  @Modus INT
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON

  -- ---------------------------------------------------
  -- Kontrollen der Parameter
  -- ---------------------------------------------------
  --IF (@RechtstitelID IS NULL OR @RechtstitelID = 0) AND (@LeistungID IS NULL OR @LeistungID = 0) BEGIN
  IF (@LeistungID IS NULL OR @LeistungID = 0) BEGIN
    RETURN -1
  END
  IF @Modus IS NULL OR @Modus < 1 OR @Modus > 2 BEGIN
    RETURN -2
  END

  DECLARE
    @MaxDatum DATETIME,
    @MinDatum DATETIME,
    @MinDatumForderung DATETIME,
    @MinDatumPosition DATETIME,
    @MinDatumVerrechg DATETIME,
    @MinDatumAB DATETIME,
    @ActDate DATETIME,
    @Month INT, 
    @Year INT,
    @LineCounts INT,
    @ErrorCounts INT,
    @ErrorResult INT,
    @Result INT,
    @ProzessCode INT

  -- ProzessCode holen    
  SELECT TOP 1 @ProzessCode = FaProzessCode FROM dbo.FaLeistung
  WHERE FaLeistungID = @LeistungID

  -- Maximum holen    
  SET @MaxDatum = GETDATE()
  SET @MaxDatum = DATEADD(MONTH, 3, @MaxDatum)
  SET @MaxDatum = dbo.fnDateSerial(YEAR(@MaxDatum), MONTH(@MaxDatum), 1)

  IF @Modus = 1 BEGIN
    -- ---------------------------------
    -- 1 = Alle Daten eines Rechtstitels
    -- ---------------------------------
    -- alle Daten eines Rechtstitel neu berechnen, 
    -- also zuerst das Minimum aller Daten suchen:
    -- Forderungen
    -- Mininum holen    
    SET @MinDatum = GETDATE()

    -- IkForderung
    SELECT @MinDatumForderung = MIN(F.DatumAnpassenAb) 
    FROM dbo.IkForderung F WITH(READUNCOMMITTED)
    WHERE F.FaLeistungID = @LeistungID
    IF (@MinDatumForderung IS NOT NULL AND @MinDatum > @MinDatumForderung) 
      SET @MinDatum = @MinDatumForderung

    -- IkPosition
    SELECT @MinDatumPosition = MIN(P.Datum) 
    FROM dbo.IkPosition P WITH(READUNCOMMITTED)
    WHERE P.FaLeistungID = @LeistungID
      AND P.Einmalig = 0
    IF (@MinDatumPosition IS NOT NULL AND @MinDatum > @MinDatumPosition) 
      SET @MinDatum = @MinDatumPosition

    IF @ProzessCode IN (405, 406, 407) BEGIN
      -- Verrechnungskonto und ALBV/UeBH/KKBB Berechnung gibt es nur mit Rechtstitel
      -- Verrechnungskonto
      SELECT @MinDatumVerrechg = MIN(V.DatumVon) 
      FROM dbo.IkVerrechnungskonto V WITH(READUNCOMMITTED)
      LEFT JOIN IkRechtstitel R ON R.IkRechtstitelID = V.IkRechtstitelID 
      WHERE R.FaLeistungID = @LeistungID
      IF (@MinDatumVerrechg IS NOT NULL AND @MinDatum > @MinDatumVerrechg) 
        SET @MinDatum = @MinDatumVerrechg
        
      -- ALBV/UeBH/KKBB Berechnung
      SELECT @MinDatumAB = MIN(A.BerechnungDatumAb)
      FROM dbo.AmAnspruchsberechnung A WITH(READUNCOMMITTED)
      LEFT JOIN dbo.AmAbKind K WITH(READUNCOMMITTED) ON K.AmAnspruchsberechnungID = A.AmAnspruchsberechnungID
      LEFT JOIN dbo.IkRechtstitel R WITH(READUNCOMMITTED) ON R.IkRechtstitelID = K.IkRechtstitelID
      WHERE R.FaLeistungID = @LeistungID
      IF (@MinDatumAB IS NOT NULL AND @MinDatum > @MinDatumAB) 
        SET @MinDatum = @MinDatumAB
    END
  END ELSE 
  BEGIN
    -- -----------------------------------
    -- 2 = Nur fehlende Monate am ergänzen
    -- -----------------------------------
    -- also zuerst zuletzt gespeicherter Monat suchen
    SELECT @MinDatum = MAX(P.Datum) 
    FROM dbo.IkPosition P WITH(READUNCOMMITTED)
    WHERE P.FaLeistungID = @LeistungID
      AND P.Einmalig = 0
    IF @MinDatum IS NULL BEGIN
      SET @MinDatum = GETDATE()
      SET @MinDatum = dbo.fnDateSerial(YEAR(@MinDatum), MONTH(@MinDatum), 1)
      SET @MinDatum = DATEADD(MONTH, -1, @MinDatum) 
    END
  END

  SET @Month = MONTH(@MinDatum)
  SET @Year = YEAR(@MinDatum)
  SET @ActDate = dbo.fnDateSerial(@Year, @Month, 1)
  SET @LineCounts = 0
  SET @ErrorCounts = 0
  SET @ErrorResult = 0

  -- 11.04.2008 : sozheo :
  -- alle älteren Monate löschen, falls nicht verbucht
  -- -------------------------------------------------
  IF @Modus = 1 BEGIN
    DELETE dbo.IkPosition 
    WHERE FaLeistungID = @LeistungID
      AND Datum < @MinDatum
      AND Einmalig = 0
      AND NOT EXISTS (
        SELECT B.KbBuchungID FROM dbo.KbBuchung B WITH(READUNCOMMITTED)
        WHERE B.IkPositionID = IkPosition.IkPositionID 
      )
  END

  -- für alle Monate berechnen
  -- -------------------------
  WHILE @ActDate <= @MaxDatum 
  BEGIN

    SET @Month = MONTH(@ActDate)
    SET @Year = YEAR(@ActDate)
    IF @ProzessCode IN (405, 406, 407) BEGIN
      -- Berechnung eines Rechtstitels
      -- -----------------------------
      EXEC @Result = dbo.spIkMonatszahlen_Detail @LeistungID, @Year, @Month 
    END ELSE BEGIN
      -- Berechnung einer Leistung
      -- -------------------------
      EXEC @Result = dbo.spIkMonatszahlen_DetailLeistung @LeistungID, @Year, @Month
    END
    IF @Result >= 0 BEGIN
      SET @LineCounts = @LineCounts + @Result
    END ELSE BEGIN
      SET @ErrorCounts = @ErrorCounts + 1
      SET @ErrorResult = @Result - 1000
    END
    SET @ActDate = DATEADD(MONTH, 1, @ActDate)
  END

  -- Resultat
  -- --------
  --SELECT 0 AS HasErrors, 'Berechnung fertig.' AS ErrorText
  IF @ErrorCounts > 0 BEGIN
    RETURN @ErrorResult
  END ELSE BEGIN
    RETURN @LineCounts
  END

END

GO