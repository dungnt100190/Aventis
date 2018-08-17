SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnKbBuchung_GetMitteilungstext2
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Mitteilungstexte bestimmen 
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION [dbo].[fnKbBuchung_GetMitteilungstext2] (
  -- 1 = Vermittlete Zahlungen, 0 = Forderungen und Zahlungen
  @VermittelteZahlungen BIT,
  -- es ist eine einmalige Forderung/Zahlung
  @IstEinmalig BIT,
  -- es ist eine interne Verrechnung
  @IstInterneVerrechnung BIT,
  -- IkForderung periodisch, bzw. LOV IkForderungArt,
  @IkForderungArtCode INT,
  -- IkForderung einmalig 
  @IkForderungEinmaligCode INT,
  -- es ist Elternteil
  @IstElternteil BIT,
  -- Verfahrensnummer
  @Verfahrensnummer VARCHAR(20),
  -- Verwendunsperiode der Buchung
  @VerwPeriodeVon DATETIME,
  @VerwPeriodeBis DATETIME
)
RETURNS VARCHAR(35)
AS BEGIN
  DECLARE
    @Text VARCHAR(200),
    @VorText VARCHAR(20),
    @Forderungstitel VARCHAR(200),
    @MonatJahr VARCHAR(10),
    @MonatJahrBis VARCHAR(10)

  SET @Text = ''
  -- Datum im Format MM.YYYY holen
  SET @MonatJahr = ' ' + ISNULL(dbo.fnXMonatJahrString(@VerwPeriodeVon), 'MM.JJJJ')
  SET @MonatJahrBis = '-' + ISNULL(dbo.fnXMonatJahrString(@VerwPeriodeBis), 'MM.JJJJ')


  -- Mitteilungstext 2 aus LOV-Shorttext holen
  SELECT TOP 1 @Forderungstitel = ShortText
  FROM dbo.XLovCode 
  WHERE LOVName = CASE WHEN @IstEinmalig = 1 THEN 'IkForderungEinmalig' ELSE 'IkForderungArt' END
    AND Code = CASE WHEN @IstEinmalig = 1 THEN @IkForderungEinmaligCode ELSE @IkForderungArtCode END

  -- Spezieller Text bei vermittelten/abgetretenen Zahlungen
  SET @VorText = CASE
    -- A:
    WHEN @VermittelteZahlungen = 1 AND @IstInterneVerrechnung = 1
     AND (@IstEinmalig = 0 OR @IkForderungEinmaligCode IN (1,3,5))
      -- Vermittelte Zahlungen bei interner Verrechnung
      THEN 'Abg. '
    WHEN @VermittelteZahlungen = 1 AND @IstInterneVerrechnung = 0
     AND (@IstEinmalig = 0 OR @IkForderungEinmaligCode IN (1,3,5))
      -- Vermittelte Zahlungen nicht bei interner Verrechnung, also Auszahlung
      THEN 'Verm. '
    ELSE ''
  END


  -- Leerschlag vor Verfahrennummer setzen
  IF @Verfahrensnummer IS NULL 
  BEGIN
    SET @Verfahrensnummer = ''
  END ELSE IF @Verfahrensnummer != '' 
  BEGIN
    SET @Verfahrensnummer = ISNULL(' ' + @Verfahrensnummer, '')
  END


  -- ---------------------------------------------
  -- bei Zahlungen
  -- ---------------------------------------------
  SET @Text = CASE
    -- Periodische Forderungen:
    WHEN @IstEinmalig = 0 THEN @VorText + @ForderungsTitel + @MonatJahr
    -- speziell bei Nachzahlungen soll die Verwendungsperiode eingefügt werden
    -- lov einmalig
    WHEN @IstEinmalig = 1 AND @IkForderungEinmaligCode IN (121, 122, 151, 152, 161, 162, 171, 172)
      THEN @VorText + @ForderungsTitel + @MonatJahr + @MonatJahrBis
    -- Einmalige Forderungen
    WHEN @IstEinmalig = 1 THEN @VorText + @ForderungsTitel + @Verfahrensnummer  
    -- sonst leer
    ELSE NULL
  END
  SET @Text = LEFT(@Text, 35)
  RETURN @Text
END
GO