SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnKbBuchung_GetBuchungstext_Alim
GO
/*===============================================================================================
  $Revision: 9 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Buchungstext bestimmen für Alimentewesen
    @VermittelteZahlungen    : 1 = Vermittlete Zahlungen, 0 = Forderungen und Zahlungen
    @ProzessCode             : ProzessCode
    @IstEinmalig             : es ist eine einmalige Forderung/Zahlung
    @IstInterneVerrechnung   : es ist eine interne Verrechnung
    @IkForderungArtCode      : IkForderung periodisch, bzw. LOV IkForderungArt
    @IkForderungEinmaligCode : IkForderung einmalig
    @IstElternteil           : es ist Elternteil
    @Verfahrensnummer        : Verfahrensnummer
    @VerwPeriodeVon          : Datum von der Verwendungsperiode der Buchung
    @VerwPeriodeBis          : Datum bis der Verwendungsperiode der Buchung
  -
  RETURNS: Buchungstext
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnKbBuchung_GetBuchungstext_Alim
(
  -- 1 = Vermittlete Zahlungen, 0 = Forderungen und Zahlungen
  @VermittelteZahlungen BIT,
  -- ProzessCode
  @ProzessCode INT,
  -- es ist eine einmalige Forderung/Zahlung
  @IstEinmalig BIT,
  -- es ist eine interne Verrechnung
  @IstInterneVerrechnung BIT,
  -- IkForderung periodisch, bzw. LOV IkForderungArt
  @IkForderungArtCode INT,
  -- IkForderung einmalig
  @IkForderungEinmaligCode INT,
  -- es ist Elternteil
  @IstElternteil BIT,
  -- Verfahrensnummer
  @Verfahrensnummer VARCHAR(20),
  -- Verwendungsperiode der Buchung
  @VerwPeriodeVon DATETIME,
  @VerwPeriodeBis DATETIME
)
RETURNS VARCHAR(200)
AS BEGIN
  DECLARE 
    @Text VARCHAR(200),
    @VorText VARCHAR(50),
    @MonatJahr VARCHAR(10),
    @MonatJahrBis VARCHAR(10),
    @ForderungsTitel VARCHAR(200)

  SET @Text = ''
  -- Datum im Format MM.YYYY holen
  SET @MonatJahr = ' ' + ISNULL(dbo.fnXMonatJahrString(@VerwPeriodeVon), 'MM.JJJJ')
  SET @MonatJahrBis = '-' + ISNULL(dbo.fnXMonatJahrString(@VerwPeriodeBis), 'MM.JJJJ')

  -- Text holen
  SET @ForderungsTitel = '[Titel nicht definiert]'
  
  IF @IstEinmalig = 1 BEGIN
    -- Text aus den einmaligen Forderungen holen
    -- lov IkForderungEinmalig
    SET @ForderungsTitel = dbo.fnLOVText('IkForderungEinmalig', @IkForderungEinmaligCode) -- + ' (einmalig)'
  END ELSE IF @ProzessCode BETWEEN 400 AND 499 
  BEGIN
    -- Für A
    -- Text aus den periodischen Forderungen holen
    -- lov IkForderungPeriodisch
    SET @ForderungsTitel = dbo.fnLOVText('IkForderungArt', @IkForderungArtCode) -- + ' (periodisch)'
    -- Bei diesen Texten ist in der LOV jeweils "[Bev./Verm] " vorangestellt, damit übersichtlicher ist,
    -- was noch speziell zusammengefügt ist
    -- "[Bev./Verm] " muss hier also wieder entfernt werden
    IF @IkForderungArtCode BETWEEN 100 AND 199 BEGIN
      SET @ForderungsTitel = SUBSTRING(@ForderungsTitel, 15, LEN(@ForderungsTitel))
    END
  --END ELSE IF @ProzessCode BETWEEN 300 AND 399 
  --BEGIN
    -- Für W
    -- Text fix, siehe weiter unten
  END


  -- Leerschlag vor Verfahrennummer setzen
  IF @Verfahrensnummer IS NULL 
  BEGIN
    SET @Verfahrensnummer = ''
  END ELSE IF @Verfahrensnummer != '' 
  BEGIN
    SET @Verfahrensnummer = ISNULL(@Verfahrensnummer, '')
  END

  -- Spezieller Text bei vermittelten/abgetretenen Zahlungen
  SET @VorText = CASE 
    -- W:
    WHEN @ProzessCode BETWEEN 300 AND 399 THEN ''
    -- A:
    WHEN @VermittelteZahlungen = 1 AND @IstInterneVerrechnung = 1 
     AND (@IstEinmalig = 0 OR @IkForderungEinmaligCode IN (1,3,5))
      -- Vermittelte Zahlungen bei interner Verrechnung
      THEN 'Abgetretene '
    WHEN @VermittelteZahlungen = 1 AND @IstInterneVerrechnung = 0 
     AND (@IstEinmalig = 0 OR @IkForderungEinmaligCode IN (1,3,5))
      -- Vermittelte Zahlungen nicht bei interner Verrechnung, also Auszahlung
      THEN 'Vermittelte '
    ELSE ''
  END

  -- ---------------------------------------------
  -- Buchungstext erstellen
  -- ---------------------------------------------
  SET @Text = CASE
    -- W:
    -- Periodische und Einmalige Forderungen:
    WHEN @ProzessCode BETWEEN 300 AND 399 AND @Verfahrensnummer != '' THEN @Verfahrensnummer
    -- Einmalige Forderungen
    WHEN @ProzessCode BETWEEN 300 AND 399 AND @IstEinmalig = 1 THEN @ForderungsTitel
    -- Periodische Forderungen:
    WHEN @ProzessCode = 301 THEN 'Verwandtenunterstützung' + @MonatJahr
    WHEN @ProzessCode = 302 THEN 'Rückerstattung' + @MonatJahr
    WHEN @ProzessCode = 304 THEN 'Unterhaltsbeiträge' + @MonatJahr
    WHEN @ProzessCode BETWEEN 300 AND 399 THEN NULL
    -- A:
    -- Periodische Forderungen:
    WHEN @IstEinmalig = 0 THEN @VorText + @ForderungsTitel + @MonatJahr
    -- speziell bei Nachzahlungen soll die Verwendungsperiode eingefügt werden
    -- lov einmalig
    WHEN @IstEinmalig = 1 AND @IkForderungEinmaligCode IN (10, 121, 122, 151, 152, 161, 162, 171, 172) 
      THEN @VorText + @ForderungsTitel + @MonatJahr + @MonatJahrBis
    -- Einmalige Forderungen
    WHEN @IstEinmalig = 1 AND @Verfahrensnummer != '' THEN @VorText + @ForderungsTitel + ' ' + @Verfahrensnummer
    WHEN @IstEinmalig = 1 THEN @VorText + @ForderungsTitel
    -- sonst leer
    ELSE NULL
  END
  
  SET @Text = LEFT(@Text, 200)
  RETURN @Text

END

GO