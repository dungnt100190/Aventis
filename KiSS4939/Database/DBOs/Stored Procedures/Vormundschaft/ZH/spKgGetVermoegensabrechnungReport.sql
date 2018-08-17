SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKgGetVermoegensabrechnungReport
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spKgGetVermoegensabrechnungReport.sql $
  $Author: Mmarghitola $
  $Modtime: 23.09.10 11:00 $
  $Revision: 12 $
=================================================================================================
  Description: Aggregierte Sicht der Buchungen für den Vermögensabrechnungsreport
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spKgGetVermoegensabrechnungReport.sql $
 * 
 * 11    23.09.10 21:45 Mmarghitola
 * #6513: Anpassungen an der Vermögensabrechnung
 * 
 * 10    27.08.10 7:53 Nweber
 * null char
 * 
 * 9     24.08.10 18:00 Mmarghitola
 * #6513: Parameter und Rückgabewerte hinzugefügt, Layout aktualisieren
 * 
 * 8     24.08.10 10:44 Mmarghitola
 * #6513: zusätzliche Angaben hinzugefügt
 * 
 * 7     2.07.10 16:37 Mmarghitola
 * #5611: Korrekturen
 * 
 * 6     7.06.10 12:45 Mmarghitola
 * #5611: Betrags-Korrektur
 * 
 * 5     31.05.10 17:15 Mmarghitola
 * #5611: Korrektur Berechnung, Gruppierung
 * 
 * 4     31.05.10 11:35 Mmarghitola
 * #5611: Berechnungsfehler korrigieren
 * 
 * 3     28.05.10 17:24 Mmarghitola
 * #5611: Erweiterung spKgGetVermoegensabrechnungReport
 * 
 * 2     28.05.10 13:23 Mmarghitola
 * #5611: Zusatzinfos zurückgeben
 * 
 * 1     28.05.10 11:40 Mmarghitola
 * #5611: spKgGetVermoegensabrechnungReport
 * 

=================================================================================================*/

CREATE PROCEDURE [dbo].[spKgGetVermoegensabrechnungReport]
(
  @KgPeriodeID  int,
  @UserID       int,
  @vmBerichtID  int
)
AS
  -- TEST
--  set @KgPeriodeID         = 2763
--  set @UserID              = -1 -- nobody
--  set @vmBerichtID         = 9149
  -- TEST

  DECLARE @Uebertrag money, @Einnahmen money, @Ausgaben money, @neuerSaldo money, @Ueberschuss money,
    @Datumsbereich nvarchar(30), @ShortName nvarchar(10), @Briefkopf nvarchar(600),
    @MandantenName nvarchar(200), @BerichtsName nvarchar(200), @LeiUserNameVorname nvarchar(200),
    @Geburtsdatum datetime, @DatumEnde datetime, @DatumAnfang datetime, @DatumTagVorAnfang datetime,
    @LeiUserID int, @PersonenNr int, @UmsatzAktiven money, @UmsatzPassiven money
    
  SELECT @BerichtsName = CASE WHEN Berichtsart like 'Rechenschaftsbericht%' THEN 'Vermögensabrechnung' 
                              WHEN Berichtsart like 'Schlussbericht%' THEN 'Schlussabrechnung' END
  FROM VmBericht
  WHERE VmBerichtID = @vmBerichtID

  SELECT @LeiUserID = LEI.UserID, @LeiUserNameVorname = USR.NameVorname
  FROM KgPeriode PER
    INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = PER.FaLeistungID
    INNER JOIN VwUser USR ON USR.UserID = LEI.UserID
  WHERE PER.KgPeriodeID = @KgPeriodeID

  SELECT @Briefkopf = Convert(varchar(500), OrgEinheitAdresseFeld) + '

' + OrgEinheitTelFaxWWW
  FROM   vwTmUser
  WHERE  BenutzerNr = @LeiUserID

  SELECT @ShortName = ShortName FROM vwUser WHERE UserID = @UserID

  SELECT @Uebertrag = $0.00, @Einnahmen = $0.00, @Ausgaben = $0.00, @neuerSaldo = $0.00, @UmsatzAktiven = $0.00, @UmsatzPassiven = $0.00
  
  SELECT @Ausgaben = @Ausgaben + CASE WHEN BUC.HabenKtoNr = KON.KontoNr THEN BUC.Betrag ELSE $0.00 END +
                                 CASE WHEN BUC.SollKtoNr = KON.KontoNr THEN -BUC.Betrag ELSE $0.00 END
  FROM KgKonto KON
    LEFT JOIN KgBuchung BUC ON (BUC.HabenKtoNr = KON.KontoNr OR BUC.SollKtoNr = KON.KontoNr) AND BUC.KgPeriodeID = KON.KgPeriodeID
  WHERE KON.KgPeriodeID = @KgPeriodeID AND KON.KgKontoKlasseCode = 3  AND KontoGruppe = 0 AND KgKontoArtCode IS NULL -- Aufwand

  SELECT @Einnahmen = @Einnahmen + CASE WHEN BUC.HabenKtoNr = KON.KontoNr THEN BUC.Betrag ELSE $0.00 END +
                                   CASE WHEN BUC.SollKtoNr = KON.KontoNr THEN -BUC.Betrag ELSE $0.00 END
  FROM KgKonto KON
    LEFT JOIN KgBuchung BUC ON (BUC.HabenKtoNr = KON.KontoNr OR BUC.SollKtoNr = KON.KontoNr) AND BUC.KgPeriodeID = @KgPeriodeID
  WHERE KON.KgPeriodeID = @KgPeriodeID AND KON.KgKontoKlasseCode = 4  AND KontoGruppe = 0 AND KgKontoArtCode IS NULL -- Ertrag
  
  SELECT @UmsatzAktiven = @UmsatzAktiven + CASE WHEN BUC.HabenKtoNr = KON.KontoNr THEN -BUC.Betrag ELSE $0.00 END +
                                 CASE WHEN BUC.SollKtoNr = KON.KontoNr THEN BUC.Betrag ELSE $0.00 END
  FROM KgKonto KON
    INNER JOIN KgBuchung BUC ON (BUC.HabenKtoNr = KON.KontoNr OR BUC.SollKtoNr = KON.KontoNr) AND BUC.KgPeriodeID = KON.KgPeriodeID
  WHERE KON.KgPeriodeID = @KgPeriodeID AND KON.KgKontoKlasseCode = 1 /*Aktiven*/  AND KontoGruppe = 0 AND (KgKontoArtCode IS NULL OR KgKontoArtCode = 1) 
  
  SELECT @UmsatzPassiven = @UmsatzPassiven + CASE WHEN BUC.HabenKtoNr = KON.KontoNr THEN -BUC.Betrag ELSE $0.00 END +
                                 CASE WHEN BUC.SollKtoNr = KON.KontoNr THEN BUC.Betrag ELSE $0.00 END
  FROM KgKonto KON
    INNER JOIN KgBuchung BUC ON (BUC.HabenKtoNr = KON.KontoNr OR BUC.SollKtoNr = KON.KontoNr) AND BUC.KgPeriodeID = KON.KgPeriodeID
  WHERE KON.KgPeriodeID = @KgPeriodeID AND KON.KgKontoKlasseCode = 2 /*Passiven*/  AND KontoGruppe = 0 AND KgKontoArtCode IS NULL

  SELECT @Ueberschuss = @Einnahmen + @Ausgaben
  

  SELECT @Geburtsdatum = PER.Geburtsdatum,
    @Datumsbereich = CONVERT(Varchar(30), KGP.PeriodeVon, 104) + ' - ' + Convert(Varchar(30), KGP.PeriodeBis, 104),
    @MandantenName = PER.NameVorname, @PersonenNr = PER.BaPersonID,
    @DatumEnde = KGP.PeriodeBis, @DatumAnfang = KGP.PeriodeVon, @DatumTagVorAnfang = DateAdd(day, -1 , KGP.PeriodeVon)
  FROM KgPeriode KGP
    LEFT JOIN FaLeistung LEI ON LEI.FaLeistungID = KGP.FaLeistungID
    LEFT JOIN vwPerson PER ON PER.BaPersonID = LEI.BaPersonID
  WHERE KGP.KgPeriodeID = @KgPeriodeID

  DECLARE @tmp table
  (
    KontoNr varchar(30),
    KgKontoartCode int,
    Klasse varchar(100),
    KontoName varchar(200),
    Vorsaldo money,
    Umsatz money,
    KgKontoKlasseCode int
  )


  DECLARE @KontoNr_Mit_ZeitPeriode table
  (
    KontoNr int
  )
  INSERT INTO @KontoNr_Mit_ZeitPeriode
  SELECT CONVERT(int,SplitValue)
  FROM [dbo].[fnSplitStringToValues](
    (
      SELECT ValueVarchar
      FROM XConfig
      WHERE KeyPath = 'System\Vormundschaft\KontoNr_mit_Zeitperiode_in_Vermoegensabrechnung'
    ), ',', 0)

  INSERT INTO @tmp (KontoNr, KgKontoartCode, Klasse, KontoName, Vorsaldo, Umsatz, KgKontoKlasseCode)
  (
    SELECT
      KontoNr,
      KgKontoartCode = MAX(KON.KgKontoartCode),
      Klasse    = MAX(KLA.Text),
      KontoName = MAX(KontoName) + CASE WHEN EXISTS (SELECT KontoNr FROM @KontoNr_Mit_ZeitPeriode KMZ WHERE KON.KontoNr = KMZ.KontoNr) THEN ' ' + dbo.[fnKgGetVerwPeriode](@KgPeriodeID, KON.KontoNr) ELSE '' END,
      Vorsaldo  = MAX(Vorsaldo),
      Umsatz    = CASE WHEN MAX(KON.KgKontoKlasseCode) IN (4) /*Erfolgskonto Ertrag*/ THEN
                    SUM(IsNull(CASE WHEN BUC.SollKtoNr = Kon.KontoNr THEN -Betrag END,$0.00)) +
                    SUM(IsNull(CASE WHEN BUC.HabenKtoNr = Kon.KontoNr THEN Betrag END,$0.00))
                  WHEN MAX(KON.KgKontoKlasseCode) IN (1,2,3) /*Bestandskonten Aktiv/Passiv, Erfolgskonto Aufwand*/ THEN
                    SUM(IsNull(CASE WHEN BUC.SollKtoNr = Kon.KontoNr THEN Betrag END,$0.00)) +
                    SUM(IsNull(CASE WHEN BUC.HabenKtoNr = Kon.KontoNr THEN -Betrag END,$0.00))
                  END,
      KgKontoKlasseCode = MAX(KON.KgKontoKlasseCode)
    FROM          dbo.KgKonto   KON
      LEFT JOIN   dbo.KgBuchung BUC ON (KON.KontoNr = BUC.SollKtoNr OR KON.KontoNr = BUC.HabenKtoNr) AND BUC.KgPeriodeID = @KgPeriodeID
      LEFT JOIN   dbo.XLOVCode  KLA WITH (READUNCOMMITTED) ON KLA.LOVName = 'KgKontoKlasse' AND KLA.Code = KON.KgKontoKlasseCode
    WHERE KON.KgPeriodeID = @KgPeriodeID AND KontoGruppe = 0
    GROUP BY KontoNr
  )

  SELECT @Uebertrag = SUM(ISNULL(KON.Vorsaldo, $0.00))
  FROM KgKonto KON
  WHERE KON.KgPeriodeid = @KgPeriodeID AND KgKontoKlasseCode IN (1,2) AND KontoGruppe = 0 -- Aktive, Passive, Keine Überschriften
    AND (KgKontoArtCode = 1 /* Verkehrskonto */ OR KgKontoArtCode IS NULL)

  SELECT @neuerSaldo = @Uebertrag + @UmsatzAktiven + @UmsatzPassiven -- UmsatezPassiven ist negativ

  SELECT
    KontoNr,
    KontoName,
    Klasse,
    Vorsaldo = CASE WHEN KgKontoKlasseCode IN (1 /*Aktiven*/, 2 /*Passiven*/) THEN Vorsaldo END,
    Umsatz = CASE WHEN KgKontoKlasseCode IN (1 /*Aktiven*/, 2 /*Passiven*/) THEN Umsatz END,
    NeuerSaldo = Vorsaldo + Umsatz,
    TotalUebertrag = @Uebertrag,
    TotalEinnahmen = @Einnahmen,
    TotalAusgaben = @Ausgaben,
    TotalUmsatzAktiven = @UmsatzAktiven,
    TotalUmsatzPassiven = @UmsatzPassiven,
    TotalNeuerSaldo = @neuerSaldo,
    Geburtsdatum = @Geburtsdatum,
    DatumsBereich = @Datumsbereich,
    DatumTagVorAnfang = @DatumTagVorAnfang,
    DatumAnfang = @DatumAnfang,
    DatumEnde = @DatumEnde,
    NameVorname = @MandantenName,
    BaPersonID = @PersonenNr,
    GroupFooterText = CASE WHEN KgKontoKlasseCode IN (1,2) THEN N'Total'
                           WHEN KgKontoKlasseCode IN (3) THEN N'Total Aufwand'
                           WHEN KgKontoKlasseCode IN (4) THEN N'Total Ertrag'
                    END,
    UeberschussArt = CASE WHEN -@Ausgaben > @Einnahmen THEN N'Aufwandüberschuss' ELSE N'Ertragsüberschuss' END,
    TotalUeberschuss = @Ueberschuss,
    ShortName = @ShortName,
    Briefkopf = @Briefkopf,
    Berichtsname = @Berichtsname,
    UebertragZeile = N'Übertrag aus der letzten ' + @Berichtsname + N' per ' + CONVERT(NVARCHAR(10), @DatumTagVorAnfang, 104),
    Titel = @Berichtsname + char(13) + char(10) + @Datumsbereich,
    LeiUserNameVorname = @LeiUserNameVorname,
    KgKontoKlasseCode -- zur Sortierung
  FROM @tmp
  WHERE (KgKontoArtCode IS NULL OR KgKontoArtCode NOT IN (4,5,6)) -- Vermögen Klient darf nicht erscheinen
    AND (KgKontoKlasseCode IN (1,2) AND (Vorsaldo IS NOT NULL AND Vorsaldo <> $0.00 OR Umsatz IS NOT NULL AND Umsatz <> $0.00)
    OR (KgKontoKlasseCode IN (3,4) AND Umsatz IS NOT NULL AND Umsatz <> $0.00))

  SELECT KontoNr = SollKtoNr, Text, BetragSoll = Betrag, BetragHaben = $0.00
  FROM KgBuchung
  WHERE KgPeriodeID = @KgPeriodeID AND SollKtoNr IN (3500, 3501)
  UNION
  SELECT KontoNr = HabenKtoNr, Text, BetragSoll = $0.00, BetragHaben = Betrag
  FROM KgBuchung
  WHERE KgPeriodeID = @KgPeriodeID AND HabenKtoNr IN (3500, 3501)
  ORDER BY 1

GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
