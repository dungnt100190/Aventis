SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spIkSollstellung_KbBuchung_Create
GO

/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spIkSollstellung_KbBuchung_Create.sql $
  $Author: Rstahel $
  $Modtime: 2.08.10 10:26 $
  $Revision: 23 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spIkSollstellung_KbBuchung_Create.sql $
 * 
 * 23    2.08.10 10:30 Rstahel
 * #6509: Bugfix: ClearingNr 9000 der Post muss als Varchar gesucht
 * werden, nicht als Int, sonst kommt es zu Conversion-Fehler
 * 
 * 22    14.07.10 11:35 Nweber
 * #6064: Spalte KbPeriodeID von der Tabelle KbBuchungKostenart löschen
 * 
 * 21    30.05.10 22:01 Rstahel
 * #5012: Anpassungen für  ClearingNr, die neu als VARCHAR(15) und nicht
 * mehr als INT definiert ist
 * 
 * 20    17.12.09 13:04 Nweber
 * #4644: Meldung für ungültige Banken angepasst
 * 
 * 19    1.12.09 14:03 Nweber
 * #4644: Fehlermeldung wenn eine Bank eine neue ClearingNr hat.
 * 
 * 18    14.08.09 17:31 Rhesterberg
 * #5155: Nachzahlung über Maske Saldo ALBV/ÜbH / Auswahl falscher Zahlweg
 * 
 * 17    23.07.09 16:46 Rhesterberg
 * #4767: Verwendungsperioden Interne Verrechnung W/A 
 * 
 * 16    23.07.09 10:25 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 15    16.07.09 20:02 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 14    12.07.09 19:05 Rhesterberg
 * #32: Monatszahlen übergeordnet (ALIM5)
 * 
 * 13    9.07.09 0:01 Rhesterberg
 * #32: Monatszahlen übergeordnet
 * 
 * 12    6.05.09 1:40 Rhesterberg
 * #30: Implmentierung der internen Verrechnung
 * 
 * 11    24.04.09 1:55 Rhesterberg
 * #4587: Bei UEBH- und KKBB- Nachzahlungen werden jetzt keine Forderungen
 * mehr erstellt
 * 
 * 10    12.03.09 15:21 Rhesterberg
 * #30: interne Verrechnung
 * 
 * 9     10.03.09 14:39 Rhesterberg
 * 
 * 8     28.02.09 18:02 Rhesterberg
 * 
 * 7     3.02.09 15:41 Rhesterberg
 * 
 * 6     3.02.09 15:36 Rhesterberg
 * 
 * 5     25.01.09 19:45 Rhesterberg
 * 
 * 4     19.01.09 16:08 Rhesterberg
 * 
 * 3     7.01.09 11:58 Rhesterberg
 * 
 * 2     6.01.09 13:15 Rhesterberg
 * 
 * 1     9.09.08 14:59 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

/*
===================================================================================================
Author:      sozheo
Create date: 06.10.2007
Description: Erstellen der Buchungen aus Forderungen

===================================================================================================
ZUM KONTROLLIEREN:
-----------------
EXEC dbo.spIkSollstellung_KbBuchung_Create 616, '20080219', '20080227', '20080226', 'Test', 7142 
EXEC dbo.spIkSollstellung_KbBuchung_Undo 616

select * from IkPosition where IkPositionID = 626  -- Laubacher Greta
select * from IkPosition where IkPositionID = 616  -- Tumonika Vladimir, uebh

EXEC dbo.spIkSollstellung_KbBuchung_Create 773, '20080101', '20080101', '20080304', 'Jan', 7138

select * from KbBuchung where IkPositionID = 434
select * from KbBuchungKostenart where KbBuchungID in (
  select KbBuchungID from KbBuchung where IkPositionID = 434)

===================================================================================================
ZUM LOESCHEN, RUECKGAENGIG:
---------------------------
EXEC dbo.spIkSollstellung_KbBuchung_Undo 431

===================================================================================================
History:
--------
06.10.2007 : sozheo : neu erstellt
08.10.2007 : sozheo : neu jetzt über alle Klienten, nicht nur eine Leistung
10.10.2007 : sozheo : Korrekturen für einmalige Beträge
11.10.2007 : sozheo : Korrekturen gemäass Besprechung mit Mathias Minder
31.10.2007 : sozheo : Neue Felder hinzugefügt
02.11.2007 : sozheo : Korrekturen
07.11.2007 : sozheo : Sperren von Tabelle IkRatenplan neu
12.11.2007 : sozheo : Kontrolle IBAN korrigiert
14.11.2007 : sozheo : Belegnummer korrigiert
16.11.2007 : sozheo : Kontonummern korrigiert
23.11.2007 : sozheo : Korrektur, damit noch unerledigte auch gemacht werden
25.11.2007 : sozheo : Korrektur, Buchungstext automatisch
07.12.2007 : sozheo : Korrektur, Bankname hinzugefügt
08.01.2008 : sozheo : Korrektur Tabelle IkGlaeubiger
04.02.2008 : sozheo : Korrektur Umbennenung Tabelle KbBuchung
08.02.2008 : sozheo : Korrektur neues Datenmodell
24.02.2008 : sozheo : Korrektur neues Datenmodell
27.02.2008 : sozheo : Umbau nur eine IkPosition-Zeile verarbeiten
28.02.2008 : sozheo : Korrektur Kontierungen
29.02.2008 : sozheo : Kontrolle Zahlungswege ergänzt
03.03.2008 : sozheo : Inkassohilfe entfernt
03.03.2008 : sozheo : Kontierung eingebaut
04.03.2008 : sozheo : Zusatzbetrag eingebaut
11.03.2008 : sozheo : Barzahlung eingebaut
11.03.2008 : sozheo : Negativer Betrag bei einmaligen eingbaut
13.03.2008 : sozheo : FaLeistungID neu in KbBuchung
13.03.2008 : sozheo : Institutionnamen werden jetzt abgefüllt
21.03.2008 : sozheo : Neu auch für W-Modul
26.03.2008 : sozheo : Einbau Fehlermeldung Teil/Hauptvorgang
27.03.2008 : sozheo : Buchung vermittelte korrigiert
04.04.2008 : sozheo : Korrektur Name Zahlungsweg
19.04.2008 : sozheo : Bei Rückforderungen soll der Schuldner in KbBuchungKostenart gefüllt werden
11.05.2008 : sozheo : Anpassungen für Splitting Periode W-Modul
14.05.2008 : sozheo : Buchungstexte korrigiert
15.05.2008 : sozheo : Kontrolle Zahlungsweg korrigiert
15.05.2008 : sozheo : Buchungstexte korrigiert
16.05.2008 : sozheo : Bei Zusatzzahlung nie Unterstützungsfall, also immer auszahlen
18.05.2008 : sozheo : FaLeistungID korrigiert
20.05.2008 : sozheo : Korrekturen für Storno Zusatzzahlungsweg
21.05.2008 : sozheo : Kontrolle Zahlungsweg korrigiert
21.05.2008 : sozheo : Kontrolle Kostenart korrigiert
21.05.2008 : sozheo : Speichern KbBuchungKostenart.BaPersonID korrigiert
21.05.2008 : sozheo : Forderungsartcode von KbBuchungKostenart nach KbBuchung
26.05.2008 : sozheo : Auch bei Debitoren Unterstützungsfall-Flag speichern
28.05.2008 : sozheo : ModulID korrigiert gemäss ProzessCode
01.06.2008 : sozheo : Buchungstexct jetzt mit Datum aus IkPosition
01.06.2008 : sozheo : Neu mit Barzahlung
01.06.2008 : sozheo : Splitting Verwendungsperiode programmiert
02.06.2008 : sozheo : Bei Unterstützungsfällen keine Barzahlungen 
03.06.2008 : sozheo : Glaeubiger-Anpassung für Barzahlung
09.06.2008 : sozheo : Schuldner-Wohnsitzadresse darf nicht leer sein
11.06.2008 : sozheo : Verwendungsperiode korrigiert, Monat: jetzt erster - letzter des Monats
11.06.2008 : sozheo : Mitteilungstexte gemacht
13.06.2008 : sozheo : Verwendungperiode korrigiert
16.06.2008 : sozheo : Speichern IkForderungArtCode korrigiert
18.06.2008 : sozheo : Fehlermeldungen verbessert
19.06.2008 : sozheo : Text Monat.Jahr korrigiert
27.06.2008 : sozheo : Einmalige Zahlungen eingebaut
01.07.2008 : sozheo : Einmalige Zahlungen korrigiert
02.07.2008 : sozheo : Kostenstelle hinzugefügt
03.07.2008 : sozheo : Neue Spalte IkBuchungsartCode implementiert
03.07.2008 : sozheo : Erstellung Text korrigiert
07.07.2008 : sozheo : Kontrolle Zahlungsweg bei Kreditoren angepasst
07.07.2008 : sozheo : Kontrolle Buchungsdatum korrigiert
11.07.2008 : sozheo : Für W-Daten gibt es jetzt eine neue IkForderungArt
15.07.2008 : sozheo : Verwendungsperiode (Splittung-Code 4) korrigiert
15.07.2008 : sozheo : Verwendungperiode korrigiert
17.07.2008 : sozheo : Belegart/Belegnummer neu
04.08.2008 : sozheo : Umbau einmalige Zahlungen, Beträge jetzt auch negativ
05.08.2008 : sozheo : IkPosition.ErledigterMonat eliminiert
05.08.2008 : sozheo : IkVerrechnungskonto.IstErledigt eliminiert
21.08.2008 : sozheo : Korrekturen SQL Performance
16.10.2008 : sozheo : Korrekturen SQL Performance
06.11.2008 : sozheo : Korrekturen Belegnummer holen
06.11.2008 : sozheo : Anpassung für Füllen Belegart
07.11.2008 : sozheo : Text Verwendungsperiode korrigiert
07.11.2008 : sozheo : Betrag darf nun auch negativ sein
10.11.2008 : sozheo : In ZH gemachte Korrekturen vom 07.11.2008 noch übernehmen
10.11.2008 : sozheo : Bei Verwendungsperiode immer 01 des Monats angeben
17.11.2008 : sozheo : Bei Verwendungsperiode BIS immer letzter des Monats angeben
06.01.2009 : sozheo : Check Zahlungsweg ausgelagert
10.01.2009 : sozheo : Anpassungen für bessere SQL Performance
03.02.2009 : sozheo : Anpassungen für Dossier- und Verfahrensnummer 
18.02.2009 : sozheo : Anpassungen für neue Tabelle interne Verrechnung
19.02.2009 : sozheo : Anpassungen für neue Tabelle interne Verrechnung
22.02.2009 : sozheo : Mitteilungszeile 1 korrigiert
22.02.2009 : sozheo : Mitteilungszeile 2 korrigiert
23.02.2009 : sozheo : AuszahlungsartCode und PSCDZahlwegArt neu aus Funktion
27.02.2009 : sozheo : Buchungstext angepasst
16.03.2009 : sozheo : Fehlermeldungen verbessert (Schuldner, Glb, Fall ergänzt)
17.03.2009 : sozheo : Fehlermeldungen verbessert (User)
01.04.2009 : sozheo : Suche nach interner Verrechnung korrigiert
02.04.2009 : sozheo : Kontrolle interne Verrechnung ergänzt/korrigiert
24.04.2009 : sozheo : Bei UeBH und KKBB werden jetzt bei Nachzahlungen keine Forderungen mehr erstellt
29.04.2009 : sozheo : Erstellung der Beträge DEBI1 korrigiert
05.05.2009 : sozheo : Verfahrensnummer für W korrigiert
07.07.2009 : sozheo : #32: Monatszahlen übergeordnet
16.07.2009 : sozheo : Verwendungsperiode korrigiert
22.07.2009 : sozheo : Verwendungsperiode korrigiert
23.07.2009 : sozheo : Verwendungsperiode korrigiert
===================================================================================================
*/

CREATE PROCEDURE [dbo].[spIkSollstellung_KbBuchung_Create] 
  -- IkPositionID:
  @IkPositionID INT,
  -- Valutadatum:
  @Valutadatum DATETIME,
  -- UserID:
  @UserID INT,
  -- Barzahlung wird erstellt
  @IstBarzahlung BIT
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON

  
  -- ==========================
  -- Kontrolle der Parameter:
  -- ==========================
  IF @IkPositionID is NULL OR @IkPositionID = 0 BEGIN
    SELECT 1 AS HasErrors, 'Fehler in Parameter: Der Parameter @IkPositionID ist ungültig.' AS ErrorText
    RETURN -1
  END
  --IF @Buchungsdatum is NULL BEGIN
  --  SELECT 1 AS HasErrors, 'Fehler in Parameter: Der Parameter @Buchungsdatum ist ungültig.' AS ErrorText
  --  RETURN -2
  --END
  IF @Valutadatum is NULL BEGIN
    SELECT 1 AS HasErrors, 'Fehler in Parameter: Der Parameter @Valutadatum ist ungültig.' AS ErrorText
    RETURN -3
  END

  -- ============================================
  -- Mandant holen
  -- SELECT * FROM KbMandant 
  -- ============================================
  DECLARE @KbMandantCode INT
  SET @KbMandantCode = 1 


  -- =======================================================
  -- Deklaration der Variablen:
  -- =======================================================
  DECLARE 
    @Result INT,
    @FaFallID INT,
    @FaLeistungID INT,
    @KbPeriodeID INT,
    @MonatJahrText VARCHAR(10),
    @ErrorText VARCHAR(5000),
    @KbBuchungNewID INT,
    @IkRechtstitelID INT,
    @Unterstuetzungsfall BIT,
    @BaPersonID INT,
    @BaPersonID_KA INT,
    @tmpBetragKredi MONEY,
    @tmpBetragKredi2 MONEY,
    @ZwZusatzBetrag MONEY,
    @ZwBetrag MONEY,
    @tmpBetragDebi1 MONEY,
    @tmpBetragDebi2 MONEY,
    @tmpBetragDebi3 MONEY,
    @BgKostenartIDDebi1 INT,
    @BgKostenartIDDebi2 INT,
    @BgKostenartIDDebi3 INT,
    @BgKostenartIDKredi INT,
    @BetragAlim MONEY,
    @BetragALBV MONEY,
    @BetragKiZu MONEY,
    @BetragVerr MONEY,
    @BetragEinmalig MONEY,
    @EimaligBgKostenartID VARCHAR(20),
    @IstEinmaligerBetrag BIT,
    @PeriodeDatum DATETIME,
    @BuchgTextDatum DATETIME,
    @ValutaDatumDefinitiv DATETIME,
    @DefinitivesBuchungsDatum DATETIME,
    @VerwPeriodeVon_Speichern DATETIME, 
    @VerwPVon DATETIME, 
    @VerwPeriodeBis_Speichern DATETIME,
    @VerwPBis DATETIME, 
    @IkForderungArtCode INT,
    @Glaeubiger_ZahlungswegID INT,
    @ZusatzBaZahlungswegID INT,
    @Glaeubiger_BaBankID INT,
    @Glaeubiger_BaPersonID INT,
    @Glaeubiger_BaInstitutionID INT,
    @Glaeubiger_PCKontoNr VARCHAR(200),
    @Glaeubiger_BankKontoNr VARCHAR(200),
    @Glaeubiger_BankName VARCHAR(200),
    @Glaeubiger_BankStrasse VARCHAR(200),
    @Glaeubiger_BankPLZ VARCHAR(20),
    @Glaeubiger_BankOrt VARCHAR(200),
    @Glaeubiger_IBAN VARCHAR(50),
    @Glaeubiger_Name VARCHAR(200),
    @Glaeubiger_Name2 VARCHAR(200),
    @Glaeubiger_Strasse VARCHAR(200),
    @Glaeubiger_HausNr VARCHAR(20),
    @Glaeubiger_PLZ VARCHAR(200),
    @Glaeubiger_Ort VARCHAR(200),
    @Glaeubiger_Postfach VARCHAR(100),
    @Glaeubiger_LandCode INT,
    @Glaeubiger_Bank_BCN INT,
    @ForderungsTitelName VARCHAR(200),
    @Glaeubiger_ESTyp INT,
    @Schuldner_BaPersonID INT,
    @Personname VARCHAR(200),
    @PSCDZahlwegArt CHAR(1),
    @DebiKtoNr VARCHAR(20),
    @KrediKtoNr VARCHAR(20),
    @ProzessCode INT,
    @AnzahlErstellteZeilen INT,
    @ErledigterMonat BIT,
    @IstElternteil BIT,
    @IkForderungEinmaligCode INT,
    @ResultKstArt INT,
    @Splitting INT,
    @BaPersonID_Barzahlung INT,
    @WohnsitzID INT,
    @MitteilungsZeile1 VARCHAR(200),
    @MitteilungsZeile2 VARCHAR(200),
    @GlbName VARCHAR(200),
    @GlbVorname VARCHAR(200),
    @IkBuchungsArtCode INT,
    @LeistgUserID INT,
    @Kostenstelle VARCHAR(20),
    @tmpBetrag MONEY,
    @ZusatzPosText VARCHAR(200),
    @DatumHeute DATETIME,
    @BelegNr_Debi1 BIGINT,
    @BelegArt VARCHAR(4),
    @BelegArt_KstArt VARCHAR(4),
    @Dossiernummer VARCHAR(10),
    @Verfahrensnummer VARCHAR(20),
    @IkInterneVerrechnungID INT,
    @MonatJahr VARCHAR(10),
    @MonatJahrBis VARCHAR(10),
    @KbAuszahlungsArtCode INT,
    @Buchungstext VARCHAR(200),
    @SchuldnerName VARCHAR(200),
    @FaFallIDString VARCHAR(20),
    @Username VARCHAR(50), 
    @ZahlungswegIstOK VARCHAR(200),

    @KreditorMehrZeilig VARCHAR(MAX),
    @ClearingNr VARCHAR(15),
    @ClearingNrNeu VARCHAR(15)



  -- ============================================
  -- Post-ID holen
  -- ============================================
  DECLARE @BaBankID_Post INT
  SELECT @BaBankID_Post = BaBankID
  FROM   dbo.BaBank WITH(READUNCOMMITTED)
  WHERE  ClearingNr = '9000'


  -- =======================================================
  -- SQL zum Suchen einer Position
  -- =======================================================
  -- Es wird eine Zeile IkPosition verarbeitet
  SELECT 
    @FaFallID = L.FaFallID,
    @FaLeistungID = L.FaLeistungID,
    @IkRechtstitelID = F.IkRechtstitelID,
    @BaPersonID_Barzahlung = F.BaPersonID,
    @BaPersonID = CASE 
      WHEN L.FaProzessCode = 407 THEN R.BaPersonID -- bei KKBB
      ELSE F.BaPersonID
    END,
    @BaPersonID_KA = CASE
      WHEN L.FaProzessCode IN (301,302,304,408,409,410) THEN L.SchuldnerBaPersonID
      WHEN L.FaProzessCode = 407 THEN R.BaPersonID -- bei KKBB
      ELSE F.BaPersonID
    END,
    @BetragAlim = ISNULL(F.TotalAliment, 0),
    @BetragALBV = ISNULL(F.BetragALBV, 0),
    @BetragKiZu = ISNULL(F.BetragKiZulage, 0),
    @BetragVerr = ISNULL(F.BetragALBVverrechnung, 0),
    @BetragEinmalig = ISNULL(F.BetragEinmalig, 0),
    @Personname = P.Name + ISNULL(' ' + P.Vorname, ''),
    @GlbName = P.Name,
    @GlbVorname = P.Vorname, 
    @Schuldner_BaPersonID = L.SchuldnerBaPersonID,
    @ForderungsTitelName = X.Text, 
    @EimaligBgKostenartID = X.Value2, 
    @IstEinmaligerBetrag = F.Einmalig,
    @PeriodeDatum = F.Datum,
    @ErledigterMonat = CONVERT(BIT, CASE 
      -- 07.07.2009 : sozheo : #32: Monatszahlen übergeordnet
      WHEN (F.IkRechtstitelID IS NULL AND IsNull(F.HatMehrereAlteRT, 0) = 1) THEN 1 
      WHEN EXISTS(
        SELECT TOP 1 BUC.KbBuchungID FROM KbBuchung BUC
        WHERE BUC.IkPositionID = F.IkPositionID
          AND BUC.KbBuchungStatusCode != 8
      ) THEN 1 ELSE 0 
    END),
    @ProzessCode = L.FaProzessCode,
    @IstElternteil = G.IstElternteil,
    @VerwPVon = ISNULL(F.VerwPeriodeVon, F.Datum),
    @VerwPBis = ISNULL(F.VerwPeriodeBis, F.Datum),
    @Splitting = KA.BgSplittingArtCode,
    @Belegart = KA.Belegart,
    @WohnsitzID = A.BaAdresseID,
    @IkForderungEinmaligCode = F.IkForderungEinmaligCode,
    @IkBuchungsArtCode = ISNULL(F.IkBuchungsArtCode, 0),
    @LeistgUserID = L.UserID,

/*
    @ZusatzPosText = CASE 
      -- nur bei Zusatzzahlungen und deren UmBuchung wird Verwendungsperiode eingefügt:
      WHEN F.Einmalig = 1 AND F.IkBuchungsartCode IN (2,3,4,5) 
        -- 07.11.2008 : sozheo : Text Verwendungsperiode korrigiert
        --THEN CONVERT(VARCHAR(20), F.VerwPeriodeVon, 104) + '-' + CONVERT(VARCHAR(20), F.VerwPeriodeVon, 104)
        THEN SUBSTRING(CONVERT(VARCHAR(20), dbo.fnFirstDayOf(F.VerwPeriodeVon), 104), 4, 7) + '-' + 
             SUBSTRING(CONVERT(VARCHAR(20), dbo.fnFirstDayOf(F.VerwPeriodeBis), 104), 4, 7)
      ELSE ''
    END,
*/
    @ValutaDatumDefinitiv = CASE WHEN F.Einmalig = 1 
      THEN @PeriodeDatum 
      ELSE @ValutaDatum 
    END,
    @DefinitivesBuchungsDatum = CASE WHEN F.Einmalig = 1 
      THEN @PeriodeDatum 
      ELSE dbo.fnDateSerial(YEAR(@PeriodeDatum), MONTH(@PeriodeDatum), 1) 
    END,
    @Dossiernummer = F.Dossiernummer,
    @Verfahrensnummer = ISNULL(F.Verfahrensnummer, ''),
    @SchuldnerName = SCH.Name + ISNULL(' ' + SCH.Vorname, ''),
    @Username = U.LogonName
  FROM dbo.IkPosition F WITH(READUNCOMMITTED)
    LEFT OUTER JOIN dbo.FaLeistung L WITH(READUNCOMMITTED) ON L.FaLeistungID = F.FaLeistungID
    LEFT OUTER JOIN dbo.XUser U WITH(READUNCOMMITTED) ON U.UserID = L.UserID
    LEFT OUTER JOIN dbo.IkGlaeubiger G WITH(READUNCOMMITTED) ON G.IkGlaeubigerID = (
      -- 07.07.2009 : sozheo : #32: Monatszahlen übergeordnet
      SELECT TOP 1 GX.IkGlaeubigerID FROM dbo.IkGlaeubiger GX WITH(READUNCOMMITTED) 
      LEFT OUTER JOIN dbo.IkRechtstitel RX WITH(READUNCOMMITTED) on RX.IkRechtstitelID = GX.IkRechtstitelID
      WHERE RX.FaLeistungID = L.FaLeistungID
        AND GX.BaPersonID = F.BaPersonID
      -- zuerst den aktiven, dann in Vorbereitung, dann prov eingestellt, dann ungültig alle anderen
      ORDER BY case GX.IkGlaeubigerStatusCode WHEN 2 THEN 1 WHEN 1 THEN 2 WHEN 3 THEN 3 ELSE 4 END ASC
    )
    LEFT OUTER JOIN dbo.IkRechtstitel R WITH(READUNCOMMITTED) ON R.IkRechtstitelID = G.IkRechtstitelID
    LEFT OUTER JOIN dbo.BaPerson P WITH(READUNCOMMITTED) ON P.BaPersonID = F.BaPersonID
    LEFT OUTER JOIN dbo.BaAdresse A WITH(READUNCOMMITTED) ON A.BaAdresseID = (
      SELECT TOP 1 AA.BaAdresseID FROM dbo.BaAdresse AA WITH(READUNCOMMITTED)
      WHERE AA.AdresseCode = 1 -- Wohnsitz
        AND AA.BaPersonID = CASE 
          WHEN L.FaProzessCode IN (301,302,304,405,408,409,410) THEN L.SchuldnerBaPersonID
          ELSE L.BaPersonID
        END 
    )
    LEFT OUTER JOIN dbo.XLOVCode X WITH(READUNCOMMITTED) ON X.LOVName = CASE 
      -- bei Positionen nur mit LeistungID wird der Code der periodischen Forderung 
      -- in IkPosition.IkForderungEinmalig gepseichert.
      -- deshalb muss hier der Text etwas kompliziert zusammengefügt werden
      -- 07.07.2009 : sozheo : #32: Monatszahlen übergeordnet
      WHEN (F.Einmalig = 1) THEN 'IkForderungEinmalig' 
      ELSE 'IkForderungPeriodisch' 
    END AND X.Code = F.IkForderungEinmaligCode
    LEFT OUTER JOIN dbo.BgKostenart KA WITH(READUNCOMMITTED) ON CONVERT(VARCHAR, KA.BgKostenartID) = X.Value2
    LEFT OUTER JOIN dbo.BaPerson SCH WITH(READUNCOMMITTED) ON SCH.BaPersonID = L.SchuldnerBaPersonID
  WHERE IkPositionID = @IkPositionID

  -- Zusatztexte bei Nachzahlungen und deren Umbuchungen 
  SET @ZusatzPosText = ''
  IF @IstEinmaligerBetrag = 1 AND @IkBuchungsArtCode IN (2,3,4,5) 
  BEGIN
    SET @MonatJahr = dbo.fnXMonatJahrString(@VerwPVon)
    SET @MonatJahrBis = dbo.fnXMonatJahrString(@VerwPBis)
    SET @ZusatzPosText = @MonatJahr + '-' + @MonatJahrBis
  END

  SET @FaFallIDString = 'Fall ' + CONVERT(VARCHAR,@FaFallID)

  -- spezielle Korrektur, wenn period. Forderungen vom 2007 erst im nächsten Jahr verbucht werden sollen
  IF YEAR(@ValutaDatumDefinitiv) != YEAR(@DefinitivesBuchungsDatum) 
     AND @ValutaDatumDefinitiv > @DefinitivesBuchungsDatum
  BEGIN
    SET @DefinitivesBuchungsDatum = dbo.fnDateSerial(YEAR(@ValutaDatumDefinitiv), 1, 1)
  END

  IF @ErledigterMonat = 1 BEGIN
    SELECT 1 AS HasErrors, 
      'Dieser Monat ist bereits verbucht (' + 
      @MonatJahr + ', ' + @FaFallIDString + ').' AS ErrorText
    RETURN -12
  END
  IF @WohnsitzID IS NULL BEGIN
    SELECT 1 AS HasErrors, 
      'Beim Schuldner ' + @SchuldnerName + ' konnte kein Wohnsitz gefunden werden (' + 
      @FaFallIDString + ', ' + @Username + ').' AS ErrorText
    RETURN -14
  END

  -- =======================================================
  -- Periode, Debitoren-Konto und Kreditoren-Konto finden
  -- =======================================================
  -- Periode finden
  SELECT @KbPeriodeID = KbPeriodeID FROM dbo.KbPeriode WITH(READUNCOMMITTED)
  WHERE KbMandantCode = @KbMandantCode
    AND @DefinitivesBuchungsDatum BETWEEN ISNULL(PeriodeVon, @DefinitivesBuchungsDatum) AND ISNULL(PeriodeBis, @DefinitivesBuchungsDatum)
    AND PeriodeStatusCode = 1
  IF @KbPeriodeID is NULL 
  BEGIN
    SELECT 1 AS HasErrors, 
      'Es konnte keine gültige Buchungsperiode gefunden werden (' + 
      CONVERT(VARCHAR, @DefinitivesBuchungsDatum, 104)+ ').' AS ErrorText
    RETURN -4
  END
  -- KREDI Kontierung finden
  -- select * from KbKonto where KbKontoArtCode = 3
  SET @KrediKtoNr = NULL
  SELECT TOP 1 @KrediKtoNr = KontoNr FROM dbo.KbKonto WITH(READUNCOMMITTED)
  WHERE KbPeriodeID = @KbPeriodeID
    AND ','+KbKontoArtCodes+',' LIKE '%,30,%' -- 3 = Kreditorenkonto, 2 = Debitorenkonto
  -- DEBI Kontierung finden
  -- select * from KbKonto where ','+KbKontoArtCodes+',' like '%,2,%'
  SET @DebiKtoNr = NULL
  SELECT TOP 1 @DebiKtoNr = KontoNr FROM dbo.KbKonto WITH(READUNCOMMITTED)
  WHERE KbPeriodeID = @KbPeriodeID
    AND ','+KbKontoArtCodes+',' LIKE '%,20,%' -- 3 = Kreditorenkonto, 2 = Debitorenkonto
  -- Wenn Fehler, dann abbrechen
  IF @KrediKtoNr IS NULL OR @DebiKtoNr IS NULL BEGIN
    SELECT 1 AS HasErrors, 
      'Es konnten keine gültigen Kreditoren- und/oder Debitorenkonti gefunden werden (' + 
      CONVERT(VARCHAR, @DefinitivesBuchungsDatum, 104) + ').' AS ErrorText
    RETURN -5
  END


  -- =======================================================
  -- Verwendungsperiode bestimmen
  -- =======================================================
  SET @VerwPeriodeVon_Speichern = NULL 
  SET @VerwPeriodeBis_Speichern = NULL

  IF @ProzessCode BETWEEN 300 AND 399 
  BEGIN
    IF @Splitting = 1 BEGIN 
      -- Taggenau
      SET @VerwPeriodeVon_Speichern = ISNULL(@VerwPVon, @PeriodeDatum) 
      SET @VerwPeriodeBis_Speichern = ISNULL(@VerwPBis, @PeriodeDatum) 
    END ELSE
    IF @Splitting = 2 BEGIN 
      -- Monat
      SET @VerwPeriodeVon_Speichern = dbo.fnFirstDayOf(ISNULL(@VerwPVon, @PeriodeDatum))
      SET @VerwPeriodeBis_Speichern = dbo.fnLastDayOf(ISNULL(@VerwPBis, @PeriodeDatum))
    END ELSE
    IF @Splitting = 3 BEGIN 
      -- Valuta
      SET @VerwPeriodeVon_Speichern = @Valutadatum
      SET @VerwPeriodeBis_Speichern = @Valutadatum
    END ELSE
    IF @Splitting = 4 BEGIN 
      -- Entscheid
      SET @VerwPeriodeVon_Speichern = ISNULL(@VerwPVon, @PeriodeDatum) 
      SET @VerwPeriodeBis_Speichern = @VerwPeriodeVon_Speichern
    END
  END ELSE BEGIN
    -- bei A Inkasso
    SET @VerwPeriodeVon_Speichern = CASE
      -- bei einmaligen Zahlungen
      WHEN @IstEinmaligerBetrag = 1 AND @IkBuchungsArtCode IN (2,3,4,5) THEN ISNULL(@VerwPVon, @PeriodeDatum) 
      
      -- 16.07.2009 : Verwendungsperiode korrigiert
      -- #4767 : Kinderzulagen, Kinderalimente und Erwachsenenalimente sind ebenfalls nicht 
      -- mit der erfassten Verwendungsperiode an PSCD übertragen worden.
      -- Das bis Datum entspricht dem 1. des Monats anstatt wie erfasst letzten des Monats.
      -- 1	Kinderalimente
      -- 2	Kinderalimente
      -- 3	Erwachsenenalimente
      -- 4	Erwachsenenalimente
      -- 5	Kinderzulagen
      -- 6	Kinderzulagen
      -- 7	ALBV
      -- 23.07.2009 : sozheo : Verwendungsperiode korrigiert
      -- 10	Uebh
      -- 11	KKBB
      WHEN @IstEinmaligerBetrag = 1 AND @IkForderungEinmaligCode IN (1, 2, 3, 4, 5, 6, 7, 10, 11) THEN ISNULL(@VerwPVon, @PeriodeDatum)

      -- 16.07.2009 : Verwendungsperiode korrigiert
      -- 22.07.2009 : #4767 : Verwendungsperiode korrigiert
      --WHEN @IstEinmaligerBetrag = 1 AND @IkForderungEinmaligCode IN (12, 212, 16, 216, 14, 214) THEN ISNULL(@VerwPVon, @PeriodeDatum)
      WHEN @IstEinmaligerBetrag = 1 AND @IkForderungEinmaligCode IN (13, 213) THEN ISNULL(@VerwPVon, @PeriodeDatum)
      
      -- bei einmaligen Forderungen
      WHEN @IstEinmaligerBetrag = 1 THEN @PeriodeDatum
      -- bei allen anderen/periodischen
      ELSE dbo.fnFirstDayOf(@PeriodeDatum)
    END
    SET @VerwPeriodeBis_Speichern = CASE
      -- bei einmaligen Zahlungen
      WHEN @IstEinmaligerBetrag = 1 AND @IkBuchungsArtCode IN (2,3,4,5) THEN ISNULL(@VerwPBis, @PeriodeDatum) 
      
      -- 16.07.2009 : Verwendungsperiode korrigiert
      -- #4767 : Kinderzulagen, Kinderalimente und Erwachsenenalimente sind ebenfalls nicht 
      -- mit der erfassten Verwendungsperiode an PSCD übertragen worden.
      -- Das bis Datum entspricht dem 1. des Monats anstatt wie erfasst letzten des Monats.
      -- 1	Kinderalimente
      -- 2	Kinderalimente
      -- 3	Erwachsenenalimente
      -- 4	Erwachsenenalimente
      -- 5	Kinderzulagen
      -- 6	Kinderzulagen
      -- 7	ALBV
      -- 23.07.2009 : sozheo : Verwendungsperiode korrigiert
      -- 10	Uebh
      -- 11	KKBB
      WHEN @IstEinmaligerBetrag = 1 AND @IkForderungEinmaligCode IN (1, 2, 3, 4, 5, 6, 7, 10, 11) THEN ISNULL(@VerwPBis, @PeriodeDatum)
      
      -- 16.07.2009 : Verwendungsperiode korrigiert
      -- 22.07.2009 : #4767 : Verwendungsperiode korrigiert
      --WHEN @IstEinmaligerBetrag = 1 AND @IkForderungEinmaligCode IN (12, 212, 16, 216, 14, 214) THEN ISNULL(@VerwPBis, @PeriodeDatum)
      WHEN @IstEinmaligerBetrag = 1 AND @IkForderungEinmaligCode IN (13, 213) THEN ISNULL(@VerwPBis, @PeriodeDatum)
      
      -- bei einmaligen Forderungen
      WHEN @IstEinmaligerBetrag = 1 THEN @PeriodeDatum
      -- bei allen anderen/periodischen
      ELSE dbo.fnLastDayOf(@PeriodeDatum)
    END
  END
  IF @VerwPeriodeVon_Speichern IS NULL OR @VerwPeriodeBis_Speichern IS NULL
  BEGIN
    SELECT 1 AS HasErrors, 
      'Die Verwendungsperiode ist nicht definiert (' + 
      ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
    RETURN -17
  END
  IF @VerwPeriodeVon_Speichern > @VerwPeriodeBis_Speichern
  BEGIN
    SELECT 1 AS HasErrors, 
      'Verwendungsperiode VON ist grösser als Verwendungsperiode BIS (' +
      ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
    RETURN -17
  END

  -- =======================================================
  -- Interne Verrechnugn und Zahlungsweg finden
  -- =======================================================
  SET @IkInterneVerrechnungID = NULL
  SET @Glaeubiger_ZahlungswegID = NULL
  SET @ZusatzBaZahlungswegID = NULL
  SET @Unterstuetzungsfall = NULL
  SET @ZwBetrag = NULL
  SET @ZwZusatzBetrag = NULL
  IF @ProzessCode BETWEEN 400 AND 499 AND @IstElternteil = 0
  BEGIN
    SELECT
      @IkInterneVerrechnungID = IkInterneVerrechnungID, 
      @Glaeubiger_ZahlungswegID = BaZahlungswegID,
      @ZusatzBaZahlungswegID = BaZahlungswegIDZusatz,
      @Unterstuetzungsfall = InterneVerrechnung, 
      @ZwBetrag = Betrag,
      @ZwZusatzBetrag = BetragZusatz
    -- 14.08.2009 : soll neu anahnd der Verwedungsperiode VON genommen werden, siehe:
    -- #5155: Nachzahlung über Maske Saldo ALBV/ÜbH / Auswahl falscher Zahlweg
    --FROM dbo.fnIkInterneVerrechnung_Get(@FaLeistungID, @BaPersonID, @PeriodeDatum, 10, 0)
    FROM dbo.fnIkInterneVerrechnung_Get(@FaLeistungID, @BaPersonID, @VerwPeriodeVon_Speichern, 10, 0)
  END

  -- =======================================================
  -- Buchungsart für Belegnummer holen
  -- =======================================================
  SET @BelegNr_Debi1 = NULL
  SET @BelegArt_KstArt = NULL
  IF @IkBuchungsArtCode IN (4,5)
  BEGIN
    -- Bei Umbuchungen soll immer Belegart UB verwendet werden
    SET @BelegArt_KstArt = 'UB'
    BEGIN TRY
      EXEC dbo.spKbGetBelegNr_out 'UB', @BelegNr_Debi1 out
    END TRY
    BEGIN CATCH
      SELECT 1 AS HasErrors, ERROR_MESSAGE() AS ErrorText
      RETURN -18
    END CATCH
    IF @BelegNr_Debi1 IS NULL OR @BelegNr_Debi1 = 0 BEGIN
      SELECT 1 AS HasErrors, 
        'Die UB-Belegnummer konnte nicht gelöst werden (' + 
        ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
      RETURN -18
    END
  END


  -- =======================================================
  -- Alle Buchungen erstellen:
  -- =======================================================

  -- Im Text soll immer Monat von IkPosition stehen
  SET @BuchgTextDatum = dbo.fnDateSerial(YEAR(@PeriodeDatum), MONTH(@PeriodeDatum), 1)

  -- Datum im Format MM.YYYY holen
  SET @MonatJahrText = dbo.fnXMonatJahrString(@BuchgTextDatum)


  SET @IkForderungArtCode = 0
  SET @tmpBetragDebi1 = 0
  SET @tmpBetragDebi2 = 0
  SET @tmpBetragDebi3 = 0
  SET @tmpBetragKredi = 0
  SET @tmpBetragKredi2 = 0

  SET @BgKostenartIDDebi1 = NULL
  SET @BgKostenartIDDebi2 = NULL
  SET @BgKostenartIDDebi3 = NULL
  SET @BgKostenartIDKredi = NULL


  -- Beträge berechnen
  IF @IstEinmaligerBetrag = 0 
  BEGIN

    -- nicht Einmalige Beträge, Monatszahlen
    -- -------------------------------------
    IF @ProzessCode = 405 AND @IstElternteil = 0 
    BEGIN
      -- DEBITOREN ALBV Kinder
      ------------------------

      -- 1. Kostenartbuchung
      SET @BgKostenartIDDebi1 = 427 -- ALBV Sollstellung
      SET @tmpBetragDebi1 = @BetragALBV + @BetragVerr -- ALBV, UEBH, KKBB
      IF @tmpBetragDebi1 < 0 SET @tmpBetragDebi1 =  0

      -- 2. Kostenartbuchung
      -- Text kann nicht mehr nach Unterstützungsfall unterschieden werden
      /*SET @EinzelBuchungstextDebi2 = CASE WHEN @Unterstuetzungsfall = 1
        THEN 'Abgetretene Kinderalimente '
        ELSE 'Vermittelte Kinderalimente '
      END + @Buchungstext1*/
      SET @BgKostenartIDDebi2 = 433 -- Total Alimente Sollstellung
      SET @tmpBetragDebi2 = @BetragAlim - @tmpBetragDebi1 
      IF @tmpBetragDebi2 < 0 SET @tmpBetragDebi2 =  0  -- kann nicht < 0 sein 

      -- 3. Kostenartbuchung
      -- Text kann nicht mehr nach Unterstützungsfall unterschieden werden
      /*SET @EinzelBuchungstextDebi3 = CASE WHEN @Unterstuetzungsfall = 1
        THEN 'Abgetretene Kinderzulagen '
        ELSE 'Vermittelte Kinderzulagen '
      END + @Buchungstext1*/
      SET @BgKostenartIDDebi3 = 432 -- Kinderzulagen
      SET @tmpBetragDebi3 = @BetragKiZu
      IF @tmpBetragDebi3 < 0 SET @tmpBetragDebi3 =  0


      -- KREDITOREN ALBV Kinder
      -------------------------
      --SET @EinzelBuchungstextKredi = 'Auszahlung ALBV ' + @Buchungstext1
      SET @BgKostenartIDKredi = 416 -- ALBV
      SET @tmpBetragKredi = @tmpBetragDebi1
      
      -- 2. Zahlungsweg berücksichtigen:
      IF NOT @ZusatzBaZahlungswegID IS NULL BEGIN
        SET @tmpBetragKredi2 = dbo.fnIkGetForderungBetrag(1, 0, @ZusatzBaZahlungswegID, @ZwBetrag, @ZwZusatzBetrag, 0, @tmpBetragKredi)
        SET @tmpBetragKredi = @tmpBetragKredi - ISNULL(@tmpBetragKredi2, 0)
        IF @tmpBetragKredi < 0 SET @tmpBetragKredi = 0
      END 

    END ELSE 
    IF @ProzessCode = 405 AND @IstElternteil = 1 
    BEGIN
      -- DEBITOREN ALBV Erwachsene
      ----------------------------
      -- 2. Kostenartbuchung
      -- Text kann nicht mehr nach Unterstützungsfall unterschieden werden
      /*SET @EinzelBuchungstextDebi1 = CASE WHEN @Unterstuetzungsfall = 1
        THEN 'Abgetretene Erwachsenenalimente '
        ELSE 'Vermittelte Erwachsenenalimente '
      END + @Buchungstext1*/
      SET @BgKostenartIDDebi1 = 434 -- Total Alimente Sollstellung
      SET @tmpBetragDebi1 = @BetragAlim
      IF @tmpBetragDebi1 < 0 SET @tmpBetragDebi1 =  0  -- kann nicht < 0 sein 

    END ELSE 
    IF @ProzessCode = 406 
    BEGIN
      -- KREDITOREN UEBH Kinder
      -------------------------
      --SET @EinzelBuchungstextKredi = 'Auszahlung ÜbH ' + @Buchungstext1
      SET @BgKostenartIDKredi = 417 -- UeBH
      SET @tmpBetragKredi = @BetragALBV + @BetragVerr
      IF @tmpBetragKredi < 0 SET @tmpBetragKredi = 0

      -- 2. Zahlungsweg berücksichtigen:
      IF NOT @ZusatzBaZahlungswegID IS NULL BEGIN
        SET @tmpBetragKredi2 = dbo.fnIkGetForderungBetrag(1, 0, @ZusatzBaZahlungswegID, @ZwBetrag, @ZwZusatzBetrag, 0, @tmpBetragKredi)
        SET @tmpBetragKredi = @tmpBetragKredi - ISNULL(@tmpBetragKredi2, 0)
        IF @tmpBetragKredi < 0 SET @tmpBetragKredi = 0
      END 
    END ELSE 
    IF @ProzessCode = 407 
    BEGIN
      -- KREDITOREN KKBB Kinder
      -------------------------
      --SET @EinzelBuchungstextKredi = 'Auszahlung KKBB ' + @Buchungstext1
      SET @BgKostenartIDKredi = 415 -- KKBB
      SET @tmpBetragKredi = @BetragALBV + @BetragVerr
      IF @tmpBetragKredi < 0 SET @tmpBetragKredi = 0

      -- 2. Zahlungsweg berücksichtigen:
      IF NOT @ZusatzBaZahlungswegID IS NULL BEGIN
        SET @tmpBetragKredi2 = dbo.fnIkGetForderungBetrag(1, 0, @ZusatzBaZahlungswegID, @ZwBetrag, @ZwZusatzBetrag, 0, @tmpBetragKredi)
        SET @tmpBetragKredi = @tmpBetragKredi - ISNULL(@tmpBetragKredi2, 0)
        IF @tmpBetragKredi < 0 SET @tmpBetragKredi = 0
      END 
    END  

    -- Rückforderungen (Debitorenbuchungen)
    -- ------------------------------------
    ELSE 
    IF @ProzessCode = 408 
    BEGIN
      -- DEBITOREN Rückforderung ALBV, UEBH, KKBB
      -- ----------------------------------------
      SET @BgKostenartIDDebi1 = 427
      SET @tmpBetragDebi1 = @BetragAlim
    END ELSE 
    IF @ProzessCode = 409 
    BEGIN
      -- DEBITOREN Rückforderung UEBH
      -- ----------------------------
      SET @BgKostenartIDDebi1 = 428
      SET @tmpBetragDebi1 = @BetragAlim
    END ELSE 
    IF @ProzessCode = 410 
    BEGIN
      -- DEBITOREN Rückforderung KKBB
      -- ----------------------------
      SET @BgKostenartIDDebi1 = 426
      SET @tmpBetragDebi1 = @BetragAlim

    END ELSE 

    IF @ProzessCode IN (301, 302, 304)   
    BEGIN
      -- DEBITOREN (W-Modul)
      -- -------------------
      IF ISNUMERIC(@EimaligBgKostenartID) = 1 BEGIN
        SET @BgKostenartIDDebi1 = CONVERT(INT, @EimaligBgKostenartID)  
      END ELSE BEGIN
        SET @BgKostenartIDDebi1 = NULL
        SELECT 1 AS HasErrors, 
          'Die BgKostenart-ID konnte nicht ermittelt werden (' + 
          ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
        RETURN -13
      END 
      SET @tmpBetragDebi1 = @BetragAlim
    END  


-- TODO: Walter  
    --WHEN @ProzessCode = 405 AND @Typ1 = 1 THEN 435 -- ALBV Verm. Alimenten Ausland
-- TODO: Walter:  @BgPositionID :
    --WHEN @ProzessCode = ?? THEN 429 -- RE Betreibungskosten
    --WHEN @ProzessCode = ?? THEN 430 -- RE Verzugszinsen
    --WHEN @ProzessCode = ?? THEN 431 -- RE Prozessentschädigung
  END ELSE 
  BEGIN

    -- Einmalige Forderungen (Debitoren und Debitorenminderung) und Zahlungen (Kreditoren)
    -- -----------------------------------------------------------------------------------

    -- Einmalige Forderungen (Debitoren und Debitorenminderung):
    -- 07.11.2008 : sozheo : Betrag darf nun auch negativ sein
    -- Bei UEBH und KKBB sollen bei Nachzahlungen keine FRorderungen erstellt werden
    -- 29.04.2009 : sozheo : Erstellung der Beträge DEBI1 korrigiert
    SET @tmpBetragDebi1 = CASE 
      WHEN @ProzessCode IN (406,407) AND @IkBuchungsArtCode IN (2,3) THEN 0
      ELSE @BetragEinmalig
    END


    -- Einmalige Zahlungen (Zahlungen und Zusatz-Zahlungen):
    SET @tmpBetragKredi = CASE 
      WHEN @IkBuchungsArtCode IN (2,3) THEN @BetragEinmalig 
      ELSE 0 
    END

    -- Dieser Typ ist eine Zusatzzahlung, also ZusatzBaZahlungsweg nehmen:
    IF @IkBuchungsArtCode = 3 SET @Glaeubiger_ZahlungswegID = @ZusatzBaZahlungswegID

    -- Kontrollen BgKostenartID Einmalige
    IF ISNUMERIC(@EimaligBgKostenartID) = 1 
    BEGIN
      IF @IkBuchungsArtCode IN (0,1,4,5) BEGIN
        SET @BgKostenartIDDebi1 = CONVERT(INT, @EimaligBgKostenartID)
      END 
      ELSE IF @IkBuchungsArtCode IN (2,3) 
      BEGIN
        SET @BgKostenartIDKredi = CONVERT(INT, @EimaligBgKostenartID)
        SET @BgKostenartIDDebi1 = CASE 
          WHEN @ProzessCode = 405 THEN 427  -- ALBV
          WHEN @ProzessCode = 406 THEN 428  -- UeBH
          WHEN @ProzessCode = 407 THEN 426  -- KKBB
          ELSE 0 
        END
      END ELSE BEGIN
        SELECT 1 AS HasErrors, 
          'Es wurde ein ungültiger BuchungsartCode gefunden (' + 
          ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
        RETURN -13
      END
    END ELSE BEGIN
      SELECT 1 AS HasErrors, 
        'Die BgKostenart-ID (einmalig) ist nicht numerisch (' + 
        ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
      RETURN -13
    END
  END

  -- Kontrolle der Kostenarten
  -- -------------------------
  IF @BgKostenartIDDebi1 IS NOT NULL AND NOT EXISTS (
    SELECT BgKostenartID FROM dbo.BgKostenart WITH(READUNCOMMITTED)
    WHERE BgKostenartID = @BgKostenartIDDebi1 ) 
  BEGIN
    SELECT 1 AS HasErrors, 
      'Die BgKostenart-ID für Debitoren konnte nicht gefunden werden ('+
      CONVERT(VARCHAR(15), ISNULL(@BgKostenartIDDebi1, 0)) + ', ' + 
      ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
    RETURN -14
  END
  IF @BgKostenartIDKredi IS NOT NULL AND NOT EXISTS (
    SELECT BgKostenartID FROM dbo.BgKostenart WITH(READUNCOMMITTED)
    WHERE BgKostenartID = @BgKostenartIDKredi ) 
  BEGIN
    SELECT 1 AS HasErrors, 
      'Die BgKostenart-ID für Kreditoren konnte nicht gefunden werden ('+
      CONVERT(VARCHAR(15), ISNULL(@BgKostenartIDKredi, 0)) + ', ' + 
      ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
    RETURN -14
  END

  -- Kostenstelle
  -- ------------
  SELECT TOP 1 
    @Kostenstelle = CONVERT(VARCHAR(20), ORG.Kostenstelle)
  FROM dbo.XOrgUnit_User O2U WITH(READUNCOMMITTED)
  INNER JOIN dbo.XOrgUnit ORG WITH(READUNCOMMITTED) ON ORG.OrgUnitID = O2U.OrgUnitID
  WHERE O2U.UserID = @LeistgUserID 
    AND O2U.OrgUnitMemberCode = 2 /*Mitglied*/


  SET @DatumHeute = GETDATE()
  SET @AnzahlErstellteZeilen = 0


-- Nur für TESTS:
/*
SELECT IstEinmaligerBetrag = @IstEinmaligerBetrag, 
  Text = @EinzelBuchungstextKredi, 
  EinmaligBetragTyp = @EinmaligBetragTyp,
  Kredi = @tmpBetragKredi, tmpBetrag1 = @tmpBetrag1, tmpBetrag2 = @tmpBetrag2, tmpBetrag3 = @tmpBetrag3
*/


  -- ====================================================================
  -- Jetzt noch alle Definitionen der interne Verrechnungen kontrollieren
  -- 18.02.2009 : sozheo : Neu Tabelle InterneVerrechnung verwenden
  -- 01.04.2009 : sozheo : Das wird aber nur bei Kinder verwendet
  -- ====================================================================
  SET @ZahlungswegIstOK = NULL
  IF @tmpBetragKredi > 0 OR (@tmpBetragKredi2 > 0 AND NOT @ZusatzBaZahlungswegID IS NULL) 
  BEGIN
    -- Bei Kinder oder bei UeBH/KKBB muss ein Zahlungsweg vorhanden sein
    -- Kontrolle, ob ein Datensatz vorhanden ist
    IF @IkInterneVerrechnungID IS NULL OR @Unterstuetzungsfall IS NULL
    BEGIN
      SELECT 1 AS HasErrors, 
        'Beim Glaeubiger ' + ISNULL(@PersonName, '[ohne Person]') + ' sind die interne Verrechnung und der Zahlunsgweg ALBV nicht definiert (' + 
        @FaFallIDString + ', ' + @Username + ').' AS ErrorText
      RETURN -15
    END
    IF @IstBarzahlung = 1 AND @Unterstuetzungsfall = 1 BEGIN
      SELECT 1 AS HasErrors, 'Bei Unterstützungsfällen können keine Barzahlungen erstellt werden (' + 
        ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
      RETURN -13
    END

    -- Kontrollieren, ob alle Zahlungswege OK sind:
    -- aber nur, wenn hier auch ein Zahlungsweg verwendet wird
    SET @ErrorText = ''
    -- erster Zahlungsweg kontrollieren
    IF @Glaeubiger_ZahlungswegID IS NOT NULL AND @IstBarzahlung = 0 BEGIN
      SET @ErrorText = dbo.fnBaZahlungsweg_Check(@Glaeubiger_ZahlungswegID, @Valutadatum)
      IF @ErrorText != '' BEGIN
        SELECT 1 AS HasErrors, @ErrorText AS ErrorText
        RETURN -11
      END
    END
    -- zweiter Zahlungsweg kontrollieren
    IF @ZusatzBaZahlungswegID IS NOT NULL AND @IstBarzahlung = 0 BEGIN
      SET @ErrorText = dbo.fnBaZahlungsweg_Check(@ZusatzBaZahlungswegID, @Valutadatum)
      IF @ErrorText != '' BEGIN
        SELECT 1 AS HasErrors, @ErrorText AS ErrorText
        RETURN -11
      END
    END
  END

  IF @tmpBetragDebi1 <> 0 AND @ProzessCode BETWEEN 400 AND 499 
  BEGIN
    -- Kontrolle ALV
    SET @ZahlungswegIstOK = dbo.fnIkInterneVerrechnung_Check(
      @FaLeistungID, @BaPersonID, @PeriodeDatum, 
      CASE WHEN @IstElternteil = 1 THEN 4 ELSE 1 END, 
      0, @PersonName, @FaFallIDString, @Username )
    IF @ZahlungswegIstOK IS NOT NULL 
    BEGIN
      SELECT 1 AS HasErrors, @ZahlungswegIstOK AS ErrorText
      RETURN -15
    END 
  END

  IF @tmpBetragDebi2 <> 0 AND @ProzessCode BETWEEN 400 AND 499 
  BEGIN
    -- Kontrolle ALV
    SET @ZahlungswegIstOK = dbo.fnIkInterneVerrechnung_Check(
      @FaLeistungID, @BaPersonID, @PeriodeDatum, 2, 0, @PersonName, @FaFallIDString, @Username )
    IF @ZahlungswegIstOK IS NOT NULL 
    BEGIN
      SELECT 1 AS HasErrors, @ZahlungswegIstOK AS ErrorText
      RETURN -15
    END 
  END

  IF @tmpBetragDebi3 <> 0 AND @ProzessCode BETWEEN 400 AND 499 
  BEGIN
    -- Kontrolle KiZu
    SET @ZahlungswegIstOK = dbo.fnIkInterneVerrechnung_Check(
      @FaLeistungID, @BaPersonID, @PeriodeDatum, 3, 0, @PersonName, @FaFallIDString, @Username )
    IF @ZahlungswegIstOK IS NOT NULL 
    BEGIN
      SELECT 1 AS HasErrors, @ZahlungswegIstOK AS ErrorText
      RETURN -15
    END 
  END


  -- =================
  -- Kreditorenbuchung
  -- =================
  SET @MitteilungsZeile1 = NULL
  IF @tmpBetragKredi > 0 OR (@tmpBetragKredi2 > 0 AND NOT @ZusatzBaZahlungswegID IS NULL) 
  BEGIN
    -- Die Mitteilungszeilen braucht es nur bei Kreditoren
    SET @MitteilungsZeile1 = dbo.fnKbBuchung_GetMitteilungstext1(@FaFallID, @Personname)
    IF @MitteilungsZeile1 IS NULL 
    BEGIN
      SELECT 1 AS HasErrors, 
        'Die erste Mitteilungszeile darf nicht leer sein (' + 
        ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
      RETURN -11
    END
  END

  -- Kreditorbuchung
  IF @tmpBetragKredi > 0 BEGIN
    -- Zahlungsweg suchen nur Kreditoren-Buchungen
    -- -------------------------------------------
    IF ISNULL(@Glaeubiger_ZahlungswegID, 0) = 0 AND @Unterstuetzungsfall = 0 AND @IstBarzahlung = 0
    BEGIN
      SELECT 1 AS HasErrors, 
        'Der Zahlungsweg ist nicht definiert ('+
        ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
      RETURN -16
    END

    -- Forderungsart setzen
    SET @IkForderungArtCode = CASE  
      WHEN @IstEinmaligerBetrag = 1 AND @IkBuchungsArtCode = 2 THEN 31
      WHEN @IstEinmaligerBetrag = 1 AND @IkBuchungsArtCode = 3 THEN 32
      WHEN @ProzessCode = 405 THEN 10
      WHEN @ProzessCode = 406 THEN 11
      WHEN @ProzessCode = 407 THEN 12
      ELSE 10
    END

    -- Buchungstext erstellen
    SET @Buchungstext = dbo.fnKbBuchung_GetBuchungstext_Alim(0, 
      @ProzessCode, @IstEinmaligerBetrag, @Unterstuetzungsfall, 
      @IkForderungArtCode, @IkForderungEinmaligCode, @IstElternteil, 
      @Verfahrensnummer, @VerwPeriodeVon_Speichern, @VerwPeriodeBis_Speichern)
    IF @Buchungstext IS NULL OR @Buchungstext = '' 
    BEGIN
      SELECT 1 AS HasErrors, 
        'Der Buchungstext darf nicht leer sein (10, ' + 
        ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
      RETURN -13
    END

    -- Für Zahlungen: Mitteilungstext 2 erstellen
    SET @Mitteilungszeile2 = dbo.fnKbBuchung_GetMitteilungstext2(0, 
      @IstEinmaligerBetrag, @Unterstuetzungsfall, @IkForderungArtCode, @IkForderungEinmaligCode,
      @IstElternteil, @Verfahrensnummer, @VerwPeriodeVon_Speichern, @VerwPeriodeBis_Speichern)
    IF @Mitteilungszeile2 IS NULL 
    BEGIN
      SELECT 1 AS HasErrors, 
        'Die zweite Mitteilungszeile darf nicht leer sein (10, ' + 
        ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
      RETURN -12
    END

    -- Gläubiger Angaben holen
    -- -----------------------
    SELECT TOP 1 
      @Glaeubiger_BaBankID = Z.Glaeubiger_BaBankID,
      @Glaeubiger_BaPersonID = Z.Glaeubiger_BaPersonID,
      @Glaeubiger_BaInstitutionID = Z.Glaeubiger_BaInstitutionID,
      @Glaeubiger_BankName = Z.Glaeubiger_BankName,
      @Glaeubiger_BankStrasse = Z.Glaeubiger_BankStrasse,
      @Glaeubiger_BankPLZ = Z.Glaeubiger_BankPLZ,
      @Glaeubiger_BankOrt = Z.Glaeubiger_BankOrt,
      @Glaeubiger_Bank_BCN = Z.Glaeubiger_Bank_BCN,
      @Glaeubiger_PCKontoNr = Z.Glaeubiger_PCKontoNr,
      @Glaeubiger_BankKontoNr = Z.Glaeubiger_BankKontoNr,
      @Glaeubiger_IBAN = Z.Glaeubiger_IBAN,
      @Glaeubiger_Name = Z.Glaeubiger_Name,
      @Glaeubiger_Name2 = Z.Glaeubiger_Name2,
      @Glaeubiger_Strasse = Z.Glaeubiger_Strasse,
      @Glaeubiger_HausNr = Z.Glaeubiger_HausNr,
      @Glaeubiger_PLZ = Z.Glaeubiger_PLZ,
      @Glaeubiger_Ort = Z.Glaeubiger_Ort,
      @Glaeubiger_Postfach = Z.Glaeubiger_Postfach,
      @Glaeubiger_LandCode = Z.Glaeubiger_LandCode,
      @PSCDZahlwegArt = Z.PSCDZahlwegArt,
      @KbAuszahlungsArtCode = Z.KbAuszahlungsArtCode
    FROM dbo.fnBaZahlungswegInfos(@Glaeubiger_ZahlungswegID, @IstBarzahlung, @BaPersonID_Barzahlung, @Unterstuetzungsfall) Z 

    SELECT
      @KreditorMehrZeilig        = KRE.KreditorMehrZeilig,
      @ClearingNr                = BNK.ClearingNr,
      @ClearingNrNeu             = BNK.ClearingNrNeu
    FROM dbo.vwKreditorInfo KRE
      LEFT  JOIN dbo.BaBank BNK ON BNK.BaBankID = KRE.BaBankID
    WHERE KRE.BaZahlungswegID = @Glaeubiger_ZahlungswegID

    -- #4644: Hat der Zalungsweg eine Bank mit einer neuen ClearingNr?
    IF @ClearingNrNeu IS NOT NULL BEGIN
      SELECT HasErrors = 1,
             ErrorText = 'Der Zahlungsweg mit der ID ' + CONVERT(VARCHAR, @Glaeubiger_ZahlungswegID) + 
                         ' hat eine Bank (ClearingNr ' + @ClearingNr + ') mit einer neuen ClearingNr.'  + CHAR(13) + CHAR(10) +
                         'Kreditor:' + CHAR(13) + CHAR(10) +
                         @KreditorMehrZeilig
      RETURN
    END


    -- Buchung erstellen:
    -- --------------------
    INSERT INTO dbo.KbBuchung (
      KbPeriodeID, FaLeistungID, IkPositionID, KbBuchungTypCode, 
      BelegDatum, ValutaDatum,  
      Betrag, Text, KbBuchungStatusCode,
      SollKtoNr, HabenKtoNr, 
      BaZahlungswegID, KbAuszahlungsArtCode,
      PCKontoNr, BaBankID, BankKontoNr, IBAN, 
      BankName, BankStrasse, BankPLZ, BankOrt, BankBCN, 
      BeguenstigtName,  BeguenstigtName2,  BeguenstigtStrasse, BeguenstigtHausNr,
      BeguenstigtPostfach, BeguenstigtOrt, BeguenstigtPLZ, BeguenstigtLandCode,
      Schuldner_BaPersonID, ModulID, PscdZahlwegArt, 
      ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum,
      IkForderungArtCode,
      MitteilungZeile1, MitteilungZeile2, Kostenstelle, Dossiernummer, KbForderungIstSH
    ) VALUES (
      -- KbPeriodeID, 
      @KbPeriodeID,
      -- FaLeistungID, 
      @FaLeistungID,
      -- IkPositionID, 
      @IkPositionID,
      -- BuchungTypCode, 
      --   1 = Budget
      --   2 = Manuell
      --   3 = Automat.
      --   4 = Ausgleich
      3,
      -- BelegDatum,
      @DefinitivesBuchungsDatum,
      -- ValutaDatum,
      @ValutaDatumDefinitiv,
      -- Betrag,
      @tmpBetragKredi,
      -- Text,
      @Buchungstext, -- @EinzelBuchungstextKredi,
      -- KbBuchungsStatusCode,
      2, -- freigegeben
      -- SollKtoNr
      NULL, 
      -- HabenKontoNr
      @KrediKtoNr, -- @HabenKtoNr,
      -- BaZahlungswegID,
      @Glaeubiger_ZahlungswegID,
      -- KbAuszahlungsArtCode,
      -- lov KbAuszahlungsArt
      --     101 : Elektronische Auszahlung
      --     103 : Cash / Barauszahlung
      --     105 : Interne Verrechnung
      -- hier ev. Auswahl bei Alimente LOV KbAuszahlungsart
-- TODO: Text kann nicht mehr nach Unterstützungsfall unterschieden werden
      /*
      CASE 
        WHEN @Unterstuetzungsfall = 1 THEN 105  -- Interne Verrechnung
        WHEN @IstBarzahlung = 1 THEN 103        -- Cash / Barauszahlung
        ELSE 101                                -- Elektronische Auszahlung
      END,
      */
      @KbAuszahlungsArtCode, 
      -- PCKontoNr,
      @Glaeubiger_PCKontoNr,
      -- BaBankID,
      @Glaeubiger_BaBankID,
      -- BankKontoNr,
      @Glaeubiger_BankKontoNr,
      -- IBAN
      @Glaeubiger_IBAN,
      -- Bank
      @Glaeubiger_BankName,
      @Glaeubiger_BankStrasse,
      @Glaeubiger_BankPLZ,
      @Glaeubiger_BankOrt,
      @Glaeubiger_Bank_BCN,
      -- Name,
      @Glaeubiger_Name,
      -- Name2,
      @Glaeubiger_Name2,
      -- Strasse,
      @Glaeubiger_Strasse,
      -- Hausnummer,
      @Glaeubiger_HausNr,
      -- Postfach,
      @Glaeubiger_Postfach,
      -- Ort,
      @Glaeubiger_Ort,
      -- PLZ,
      @Glaeubiger_PLZ,
      -- LandCode,
      @Glaeubiger_LandCode,
      -- Schuldner_BaPersonID
      @Schuldner_BaPersonID,
      -- ModulID
      CASE WHEN @ProzessCode BETWEEN 300 AND 399 THEN 3 ELSE 4 END,
      -- PscdZahlwegArt,
      /*
      CASE 
        WHEN @IstBarzahlung = 1 THEN 'C' 
        WHEN @Unterstuetzungsfall = 0 THEN @Glauebiger_Auszahlungsart 
        ELSE ' ' 
      END,
      */
      @PSCDZahlwegArt,

      -- ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum
      @UserID, @DatumHeute, @UserID, @DatumHeute,
      @IkForderungArtCode,
      @MitteilungsZeile1, @MitteilungsZeile2, @Kostenstelle, @Dossiernummer, 
      -- KbForderungIstSH:
      @Unterstuetzungsfall
    )
    SET @KbBuchungNewID = SCOPE_IDENTITY()

    -- KST-Buchung erstellen
    -- ---------------------
    -- Kostenart-Buchung
    EXEC @ResultKstArt = dbo.spIkSollstellung_KbBuchungKstArt_Create 
         @KbBuchungNewID, @IkForderungArtCode, @Buchungstext, @BaPersonID, @tmpBetragKredi,
         1, @BgKostenartIDKredi, 
         @VerwPeriodeVon_Speichern, @VerwPeriodeBis_Speichern, @BelegArt_KstArt

    IF @ResultKstArt < 0 BEGIN
      SELECT 1 AS HasErrors, CASE @ResultKstArt
        WHEN -1 THEN 'BgKostenartID ist nicht definiert' 
        WHEN -2 THEN 'Der Haupt- oder der Teilvorgang ist leer' 
        ELSE '[Nicht definierter Fehler]'
      END + ' (BgKostenartID = ' + CONVERT(VARCHAR, ISNULL(@BgKostenartIDKredi,0)) 
          + ', IkForderungArt = ' + CONVERT(VARCHAR, ISNULL(@IkForderungArtCode,0)) + ', ' +
        ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
      RETURN -10
    END
    SET @AnzahlErstellteZeilen = @AnzahlErstellteZeilen + 1
  END


  -- ====================================================
  -- Kreditorenbuchung auf 2. Zahlungsweg, wenn vorhanden
  -- ====================================================
  IF @tmpBetragKredi2 > 0 AND NOT @ZusatzBaZahlungswegID IS NULL 
  BEGIN

    -- Forderungsart setzen
    SET @IkForderungArtCode = CASE @ProzessCode 
      WHEN 405 THEN 13
      WHEN 406 THEN 14
      WHEN 407 THEN 15
      ELSE 13
    END

    -- Buchungstext erstellen
    SET @Buchungstext = dbo.fnKbBuchung_GetBuchungstext_Alim(0, 
      @ProzessCode, @IstEinmaligerBetrag, 0, 
      @IkForderungArtCode, @IkForderungEinmaligCode, @IstElternteil, 
      @Verfahrensnummer, @VerwPeriodeVon_Speichern, @VerwPeriodeBis_Speichern)
    IF @Buchungstext IS NULL OR @Buchungstext = '' 
    BEGIN
      SELECT 1 AS HasErrors, 
        'Der Buchungstext darf nicht leer sein (13, ' +
        ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
      RETURN -13
    END

    -- Für Zahlungen: Mitteilungstext 2 erstellen
    SET @Mitteilungszeile2 = dbo.fnKbBuchung_GetMitteilungstext2(0, 
      @IstEinmaligerBetrag, 0, @IkForderungArtCode, @IkForderungEinmaligCode,
      @IstElternteil, @Verfahrensnummer, @VerwPeriodeVon_Speichern, @VerwPeriodeBis_Speichern)
    IF @Mitteilungszeile2 IS NULL 
    BEGIN
      SELECT 1 AS HasErrors, 
        'Die zweite Mitteilungszeile darf nicht leer sein (13, ' + 
        ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
      RETURN -12
    END

    -- Gläubiger Angaben holen
    -- -----------------------
    SELECT TOP 1 
      @Glaeubiger_BaBankID = Z.Glaeubiger_BaBankID,
      @Glaeubiger_BaPersonID = Z.Glaeubiger_BaPersonID,
      @Glaeubiger_BaInstitutionID = Z.Glaeubiger_BaInstitutionID,
      @Glaeubiger_BankName = Z.Glaeubiger_BankName,
      @Glaeubiger_BankStrasse = Z.Glaeubiger_BankStrasse,
      @Glaeubiger_BankPLZ = Z.Glaeubiger_BankPLZ,
      @Glaeubiger_BankOrt = Z.Glaeubiger_BankOrt,
      @Glaeubiger_Bank_BCN = Z.Glaeubiger_Bank_BCN,
      @Glaeubiger_PCKontoNr = Z.Glaeubiger_PCKontoNr,
      @Glaeubiger_BankKontoNr = Z.Glaeubiger_BankKontoNr,
      @Glaeubiger_IBAN = Z.Glaeubiger_IBAN,
      @Glaeubiger_Name = Z.Glaeubiger_Name,
      @Glaeubiger_Name2 = Z.Glaeubiger_Name2,
      @Glaeubiger_Strasse = Z.Glaeubiger_Strasse,
      @Glaeubiger_HausNr = Z.Glaeubiger_HausNr,
      @Glaeubiger_PLZ = Z.Glaeubiger_PLZ,
      @Glaeubiger_Ort = Z.Glaeubiger_Ort,
      @Glaeubiger_Postfach = Z.Glaeubiger_Postfach,
      @Glaeubiger_LandCode = Z.Glaeubiger_LandCode,
      @PSCDZahlwegArt = Z.PSCDZahlwegArt,
      @KbAuszahlungsArtCode = Z.KbAuszahlungsArtCode
    FROM dbo.fnBaZahlungswegInfos(@ZusatzBaZahlungswegID, 0, 0, 0) Z 
    

    -- Buchung erstellen:
    -- --------------------
    INSERT INTO dbo.KbBuchung (
      KbPeriodeID, FaLeistungID, IkPositionID, KbBuchungTypCode, BelegDatum, ValutaDatum,  
      Betrag, Text, KbBuchungStatusCode, SollKtoNr, HabenKtoNr, 
      BaZahlungswegID, KbAuszahlungsArtCode,
      PCKontoNr, BaBankID, BankKontoNr, IBAN, 
      BankName, BankStrasse, BankPLZ, BankOrt, BankBCN,
      BeguenstigtName,  BeguenstigtName2,  BeguenstigtStrasse, BeguenstigtHausNr,
      BeguenstigtPostfach, BeguenstigtOrt, BeguenstigtPLZ, BeguenstigtLandCode,
      Schuldner_BaPersonID, ModulID, PscdZahlwegArt, 
      ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum,
      IkForderungArtCode,
      MitteilungZeile1, MitteilungZeile2, Kostenstelle, Dossiernummer, KbForderungIstSH
    ) VALUES (
      -- KbPeriodeID, 
      @KbPeriodeID,
      -- FaLeistungID
      @FaLeistungID, 
      -- IkPositionID, 
      @IkPositionID,
      -- BuchungTypCode, 
      --   1 = Budget
      --   2 = Manuell
      --   3 = Automat.
      --   4 = Ausgleich
      3,
      -- BelegDatum,
      @DefinitivesBuchungsDatum,
      -- ValutaDatum,
      @ValutaDatumDefinitiv,
      -- Betrag,
      @tmpBetragKredi2,
      -- Text,
      @Buchungstext, --@EinzelBuchungstextKredi,
      -- KbBuchungsStatusCode,
      2, -- freigegeben
      -- SollKtoNr
      NULL, 
      -- HabenKontoNr
      @KrediKtoNr, -- @HabenKtoNr,
      -- BaZahlungswegID,
      @ZusatzBaZahlungswegID,
      -- KbAuszahlungsArtCode,
      -- hier ev. Auswahl bei Alimente LOV KbAuszahlungsart
      -- Die Zusatzzahlung soll immer ausbezahlt werden, BAR nicht möglich
      /*
      CASE 
        WHEN @Unterstuetzungsfall = 1 THEN 105
        WHEN @ZwZusatzBarzahlung = 1 THEN 103
        ELSE 101
      END,
      */
      @KbAuszahlungsArtCode,  -- muss hier immer 101 sein, weil immer Auszahlung

      -- PCKontoNr,
      @Glaeubiger_PCKontoNr,
      -- BaBankID,
      @Glaeubiger_BaBankID,
      -- BankKontoNr,
      @Glaeubiger_BankKontoNr,
      -- IBAN
      @Glaeubiger_IBAN,
      -- Bank
      @Glaeubiger_BankName,
      @Glaeubiger_BankStrasse,
      @Glaeubiger_BankPLZ,
      @Glaeubiger_BankOrt,
      @Glaeubiger_Bank_BCN,
      -- Name,
      @Glaeubiger_Name,
      -- Name2,
      @Glaeubiger_Name2,
      -- Strasse,
      @Glaeubiger_Strasse,
      -- Hausnummer,
      @Glaeubiger_HausNr,
      -- Postfach,
      @Glaeubiger_Postfach,
      -- Ort,
      @Glaeubiger_Ort,
      -- PLZ,
      @Glaeubiger_PLZ,
      -- LandCode,
      @Glaeubiger_LandCode,
      -- Schuldner_BaPersonID
      @Schuldner_BaPersonID,
      -- ModulID
      CASE WHEN @ProzessCode BETWEEN 300 AND 399 THEN 3 ELSE 4 END,
      -- PscdZahlwegArt,
      -- Ist bei Zusatzzahlungswegen immer @Glauebiger_Auszahlungsart
      --CASE WHEN @Unterstuetzungsfall = 0 THEN @Glauebiger_Auszahlungsart ELSE ' ' END,
      @PSCDZahlwegArt,
      -- ErstelltUserID, ErstelltDatum,
      @UserID, @DatumHeute,
      -- MutiertUserID, MutiertDatum
      @UserID, @DatumHeute,
      @IkForderungArtCode,
      @MitteilungsZeile1, @MitteilungsZeile2, @Kostenstelle, @Dossiernummer, 
      -- Unterstuetzungsfall
      -- Zusatzzahlweg soll immer ausbezahlt werden
      0 -- ist nie interne Verrechnung -> KbForderungIstSH = 0
    )
    SET @KbBuchungNewID = SCOPE_IDENTITY()

    -- KST-Buchung erstellen
    -- ---------------------
    -- Kostenart-Buchung
    EXEC @ResultKstArt =  dbo.spIkSollstellung_KbBuchungKstArt_Create 
         @KbBuchungNewID, @IkForderungArtCode, @Buchungstext, @BaPersonID, @tmpBetragKredi2,
         1, @BgKostenartIDKredi, 
         @VerwPeriodeVon_Speichern, @VerwPeriodeBis_Speichern, @BelegArt_KstArt

    IF @ResultKstArt < 0 BEGIN
      SELECT 1 AS HasErrors, CASE @ResultKstArt
        WHEN -1 THEN 'BgKostenartID ist nicht definiert' 
        WHEN -2 THEN 'Der Haupt- oder der Teilvorgang ist leer' 
        ELSE '[Nicht definierter Fehler]'
      END + ' (BgKostenartID = ' + CONVERT(VARCHAR, ISNULL(@BgKostenartIDKredi,0)) 
          + ', IkForderungArt = ' + CONVERT(VARCHAR, ISNULL(@IkForderungArtCode,0)) + ', '+
      ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
      RETURN -10
    END
    SET @AnzahlErstellteZeilen = @AnzahlErstellteZeilen + 1
  END


  -- ================================================
  -- Normale Buchung erstellen (Debitorenbuchung)
  -- Es dürfen auch negative Beträge gebucht werden
  -- Zahlungsweg Infos werden nicht verwendet
  -- ================================================
  IF (@tmpBetragDebi1 <> 0) 
  BEGIN
    -- Forderungsart setzen
    SET @IkForderungArtCode = CASE 
      WHEN @ProzessCode BETWEEN 300 AND 399 AND @IstEinmaligerBetrag = 0 THEN 1000 
      WHEN @ProzessCode BETWEEN 300 AND 399 AND @IstEinmaligerBetrag = 1 THEN 1050 
      WHEN @IstEinmaligerBetrag = 1 THEN 30 
      WHEN @IstElternteil = 1 THEN 4
      ELSE 1 
    END

    -- Buchungstext erstellen
    SET @Buchungstext = dbo.fnKbBuchung_GetBuchungstext_Alim(0, 
      @ProzessCode, @IstEinmaligerBetrag, 0, 
      @IkForderungArtCode, @IkForderungEinmaligCode, @IstElternteil, 
      @Verfahrensnummer, @VerwPeriodeVon_Speichern, @VerwPeriodeBis_Speichern)
    IF @Buchungstext IS NULL OR @Buchungstext = '' 
    BEGIN
      SELECT 1 AS HasErrors, 
        'Der Buchungstext darf nicht leer sein (1, '+
        ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
      RETURN -13
    END

    INSERT INTO dbo.KbBuchung (
      KbPeriodeID, FaLeistungID, IkPositionID, KbBuchungTypCode, BelegDatum, ValutaDatum,  
      Betrag, Text, KbBuchungStatusCode, SollKtoNr, HabenKtoNr, 
      Schuldner_BaPersonID, ModulID, KbForderungIstSH, 
      ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum,
      IkForderungArtCode, Kostenstelle, BelegNr, Dossiernummer
    ) VALUES (
      -- KbPeriodeID, 
      @KbPeriodeID,
      -- FaLeistungID
      @FaLeistungID,
      -- IkPositionID, 
      @IkPositionID,
      -- BuchungTypCode, 
      3, -- Automatisch
      -- BelegDatum,
      @DefinitivesBuchungsDatum,
      -- ValutaDatum,
      @ValutaDatumDefinitiv,
      -- Betrag,

      -- 04.08.2008 : sozheo : Umbau einmalige Zahlungen
      --CASE WHEN @tmpBetragDebi1 > 0 THEN @tmpBetragDebi1 ELSE -@tmpBetragDebi1 END,
      @tmpBetragDebi1,
      -- Text,
      @Buchungstext, --@EinzelBuchungstextDebi1,
      -- KbBuchungsStatusCode,
      2,
      -- SollKtoNr,
      -- 04.08.2008 : sozheo : Umbau einmalige Zahlungen
      --CASE WHEN @tmpBetragDebi1 > 0 THEN @DebiKtoNr ELSE NULL END,
      @DebiKtoNr,

      -- HabenKtoNr,
      -- 04.08.2008 : sozheo : Umbau einmalige Zahlungen
      --CASE WHEN @tmpBetragDebi1 > 0 THEN NULL ELSE @DebiKtoNr END,
      NULL, --@HabenKtoNr,

      -- Schuldner_BaPersonID
      @Schuldner_BaPersonID,
      -- ModulID
      CASE WHEN @ProzessCode BETWEEN 300 AND 399 THEN 3 ELSE 4 END,
      -- KbForderungIstSH
      @Unterstuetzungsfall, -- KbForderungIstSH,
      -- ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum
      @UserID, @DatumHeute, @UserID, @DatumHeute,
      @IkForderungArtCode, @Kostenstelle, @BelegNr_Debi1, @Dossiernummer
    )
    SET @KbBuchungNewID = SCOPE_IDENTITY()


    -- Kostenarten-Buchungen erstellen
    -- -------------------------------
    -- Bei Kinderalimenten : ALBV Betrag = Spalte Auszahlung
    -- Bei Erwachsenenalimente :  Alim Vermittelt = Spalte Vermittelt - Spalte Auszahlung
    -- 04.08.2008 : sozheo : Umbau einmalige Zahlungen
    --SET @tmpBetrag = CASE WHEN @tmpBetragDebi1 > 0 THEN @tmpBetragDebi1 ELSE -@tmpBetragDebi1 END
    SET @tmpBetrag = @tmpBetragDebi1

    EXEC @ResultKstArt = dbo.spIkSollstellung_KbBuchungKstArt_Create 
         @KbBuchungNewID, @IkForderungArtCode, @Buchungstext, @BaPersonID_KA, @tmpBetrag,
         1, @BgKostenartIDDebi1, 
         @VerwPeriodeVon_Speichern, @VerwPeriodeBis_Speichern, @BelegArt_KstArt

    IF @ResultKstArt < 0 BEGIN
      SELECT 1 AS HasErrors, CASE @ResultKstArt
        WHEN -1 THEN 'BgKostenartID ist nicht definiert' 
        WHEN -2 THEN 'Der Haupt- oder der Teilvorgang ist leer' 
        ELSE '[Nicht definierter Fehler]'
      END + ' (BgKostenartID = ' + CONVERT(VARCHAR, ISNULL(@BgKostenartIDDebi1,0)) 
          + ', IkForderungArt = ' + CONVERT(VARCHAR, ISNULL(@IkForderungArtCode,0)) + ', '+
      ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
      RETURN -10
    END
    -- Anzahl erstellte Zeilen
    SET @AnzahlErstellteZeilen = @AnzahlErstellteZeilen + 1
  END

  IF (@tmpBetragDebi2 <> 0) 
  BEGIN
    -- Forderungsart setzen
    SET @IkForderungArtCode = 2

    -- Buchungstext erstellen
    SET @Buchungstext = dbo.fnKbBuchung_GetBuchungstext_Alim(0, 
      @ProzessCode, @IstEinmaligerBetrag, 0, 
      @IkForderungArtCode, @IkForderungEinmaligCode, @IstElternteil, 
      @Verfahrensnummer, @VerwPeriodeVon_Speichern, @VerwPeriodeBis_Speichern)
    IF @Buchungstext IS NULL OR @Buchungstext = '' 
    BEGIN
      SELECT 1 AS HasErrors, 
        'Der Buchungstext darf nicht leer sein (2, '+
        ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
      RETURN -13
    END

    INSERT INTO dbo.KbBuchung (
      KbPeriodeID, FaLeistungID, IkPositionID, KbBuchungTypCode, BelegDatum, ValutaDatum,  
      Betrag, Text, KbBuchungStatusCode, SollKtoNr, HabenKtoNr, 
      Schuldner_BaPersonID, ModulID, KbForderungIstSH, 
      ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum,
      IkForderungArtCode, Kostenstelle, Dossiernummer
    ) VALUES (
      -- KbPeriodeID, 
      @KbPeriodeID,
      -- FaLeistungID
      @FaLeistungID,
      -- IkPositionID, 
      @IkPositionID,
      -- BuchungTypCode, 
      3, -- Automatisch
      -- BelegDatum,
      @DefinitivesBuchungsDatum,
      -- ValutaDatum,
      @ValutaDatumDefinitiv,
      -- Betrag,
      -- 04.08.2008 : sozheo : Umbau einmalige Zahlungen
      --CASE WHEN @tmpBetragDebi2 > 0 THEN @tmpBetragDebi2 ELSE -@tmpBetragDebi2 END,
      @tmpBetragDebi2,
      -- Text,
      @Buchungstext, --@EinzelBuchungstextDebi2,
      -- KbBuchungsStatusCode,
      2,
      -- SollKtoNr,
      --@DebiKtoNr,
      -- 04.08.2008 : sozheo : Umbau einmalige Zahlungen
      --CASE WHEN @tmpBetragDebi2 > 0 THEN @DebiKtoNr ELSE NULL END,
      @DebiKtoNr,
      -- HabenKtoNr,
      -- 04.08.2008 : sozheo : Umbau einmalige Zahlungen
      --CASE WHEN @tmpBetragDebi2 > 0 THEN NULL ELSE @DebiKtoNr END,
      NULL, 
      -- Schuldner_BaPersonID
      @Schuldner_BaPersonID,
      -- ModulID
      CASE WHEN @ProzessCode BETWEEN 300 AND 399 THEN 3 ELSE 4 END,
      -- KbForderungIstSH
      @Unterstuetzungsfall, -- KbForderungIstSH,
      -- ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum
      @UserID, @DatumHeute, @UserID, @DatumHeute,
      @IkForderungArtCode, @Kostenstelle, @Dossiernummer
    )
    SET @KbBuchungNewID = SCOPE_IDENTITY()

    -- Kostenarten-Buchungen erstellen
    -- -------------------------------
    -- Bei Kinderalimenten :  Alim Vermittelt = Spalte Vermittelt - Spalte Auszahlung
    -- 04.08.2008 : sozheo : Umbau einmalige Zahlungen
    --SET @tmpBetrag = CASE WHEN @tmpBetragDebi2 > 0 THEN @tmpBetragDebi2 ELSE -@tmpBetragDebi2 END
    SET @tmpBetrag = @tmpBetragDebi2
    EXEC @ResultKstArt = dbo.spIkSollstellung_KbBuchungKstArt_Create 
         @KbBuchungNewID, @IkForderungArtCode, @Buchungstext, @BaPersonID_KA, @tmpBetrag,
         1, @BgKostenartIDDebi2, 
         @VerwPeriodeVon_Speichern, @VerwPeriodeBis_Speichern, @BelegArt_KstArt

    IF @ResultKstArt < 0 BEGIN
      SELECT 1 AS HasErrors, CASE @ResultKstArt
        WHEN -1 THEN 'BgKostenartID ist nicht definiert' 
        WHEN -2 THEN 'Der Haupt- oder der Teilvorgang ist leer' 
        ELSE '[Nicht definierter Fehler]'
      END + ' (BgKostenartID = ' + CONVERT(VARCHAR, ISNULL(@BgKostenartIDDebi2,0)) 
          + ', IkForderungArt = ' + CONVERT(VARCHAR, ISNULL(@IkForderungArtCode,0)) + ', ' +
      ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
      RETURN -10
    END
    -- Anzahl erstellte Zeilen
    SET @AnzahlErstellteZeilen = @AnzahlErstellteZeilen + 1
  END      

  IF (@tmpBetragDebi3 <> 0) 
  BEGIN
    -- Forderungsart setzen
    SET @IkForderungArtCode = 3

    -- Buchungstext erstellen
    SET @Buchungstext = dbo.fnKbBuchung_GetBuchungstext_Alim(0, 
      @ProzessCode, @IstEinmaligerBetrag, 0, 
      @IkForderungArtCode, @IkForderungEinmaligCode, @IstElternteil, 
      @Verfahrensnummer, @VerwPeriodeVon_Speichern, @VerwPeriodeBis_Speichern)
    IF @Buchungstext IS NULL OR @Buchungstext = '' 
    BEGIN
      SELECT 1 AS HasErrors, 
        'Der Buchungstext darf nicht leer sein (3, '+
        ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
      RETURN -13
    END

    INSERT INTO dbo.KbBuchung (
      KbPeriodeID, FaLeistungID, IkPositionID, KbBuchungTypCode, BelegDatum, ValutaDatum,  
      Betrag, Text, KbBuchungStatusCode, SollKtoNr, HabenKtoNr, 
      Schuldner_BaPersonID, ModulID, KbForderungIstSH, 
      ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum,
      IkForderungArtCode, Kostenstelle, Dossiernummer
    ) VALUES (
      -- KbPeriodeID, 
      @KbPeriodeID,
      -- FaLeistungID
      @FaLeistungID,
      -- IkPositionID, 
      @IkPositionID,
      -- BuchungTypCode, 
      3, -- Automatisch
      -- BelegDatum,
      @DefinitivesBuchungsDatum,
      -- ValutaDatum,
      @ValutaDatumDefinitiv,
      -- Betrag,
      -- 04.08.2008 : sozheo : Umbau einmalige Zahlungen
      --CASE WHEN @tmpBetragDebi3 > 0 THEN @tmpBetragDebi3 ELSE -@tmpBetragDebi3 END,
      @tmpBetragDebi3,
      -- Text,
      @Buchungstext, --@EinzelBuchungstextDebi3,
      -- KbBuchungsStatusCode,
      2,
      -- SollKtoNr,
      -- 04.08.2008 : sozheo : Umbau einmalige Zahlungen
      --CASE WHEN @tmpBetragDebi3 > 0 THEN @DebiKtoNr ELSE NULL END,
      @DebiKtoNr,

      -- HabenKtoNr,
      -- 04.08.2008 : sozheo : Umbau einmalige Zahlungen
      --CASE WHEN @tmpBetragDebi3 > 0 THEN NULL ELSE @DebiKtoNr END,
      NULL, --@HabenKtoNr,

      -- Schuldner_BaPersonID
      @Schuldner_BaPersonID,
      -- ModulID
      CASE WHEN @ProzessCode BETWEEN 300 AND 399 THEN 3 ELSE 4 END,
      -- KbForderungIstSH
      @Unterstuetzungsfall, -- KbForderungIstSH,
      -- ErstelltUserID, ErstelltDatum, MutiertUserID, MutiertDatum
      @UserID, @DatumHeute, @UserID, @DatumHeute,
      @IkForderungArtCode, @Kostenstelle, @Dossiernummer
    )
    SET @KbBuchungNewID = SCOPE_IDENTITY()


    -- Kostenarten-Buchungen erstellen
    -- -------------------------------
    -- @BetragKiZu
    -- Kinderzulagen
    -- 04.08.2008 : sozheo : Umbau einmalige Zahlungen
    --SET @tmpBetrag = CASE WHEN @tmpBetragDebi3 > 0 THEN @tmpBetragDebi3 ELSE -@tmpBetragDebi3 END
    SET @tmpBetrag = @tmpBetragDebi3
    EXEC @ResultKstArt = dbo.spIkSollstellung_KbBuchungKstArt_Create 
         @KbBuchungNewID, @IkForderungArtCode, @Buchungstext, @BaPersonID_KA, @tmpBetrag,
         1, @BgKostenartIDDebi3, 
         @VerwPeriodeVon_Speichern, @VerwPeriodeBis_Speichern, @BelegArt_KstArt

    IF @ResultKstArt < 0 BEGIN
      SELECT 1 AS HasErrors, CASE @ResultKstArt
        WHEN -1 THEN 'BgKostenartID ist nicht definiert' 
        WHEN -2 THEN 'Der Haupt- oder der Teilvorgang ist leer' 
        ELSE '[Nicht definierter Fehler]'
      END + ' (BgKostenartID = ' + CONVERT(VARCHAR, ISNULL(@BgKostenartIDDebi3,0)) 
          + ', IkForderungArt = ' + CONVERT(VARCHAR, ISNULL(@IkForderungArtCode,0)) + ', ' + 
      ISNULL(@PersonName, '[ohne Person]') + ', ' + @FaFallIDString + ', ' + @Username + ').' AS ErrorText
      RETURN -10
    END
    -- Anzahl erstellte Zeilen
    SET @AnzahlErstellteZeilen = @AnzahlErstellteZeilen + 1
  END

  -- Alles ok, Anzahl Buchung zurückgeben
  SELECT 0 AS HasErrors, @AnzahlErstellteZeilen AS AnzahlErstellt
END

GO