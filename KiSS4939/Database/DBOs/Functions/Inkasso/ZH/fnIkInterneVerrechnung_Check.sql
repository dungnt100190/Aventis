SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnIkInterneVerrechnung_Check
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description 
-------------------------------------------------------------------------------------------------
  SUMMARY: Definition interne Verrechnugn checken
  -
  RETURNS: 
  -
=================================================================================================
  TEST:    
=================================================================================================*/

CREATE FUNCTION dbo.fnIkInterneVerrechnung_Check
(
  -- FaLeistungID
  @FaLeistungID INT,
  -- BaPersonID
  @BaPersonID INT,
  -- PeriodeDatum
  @PeriodeDatum DATETIME,
  -- BaPersonID
  @IkForderungArtCode INT,
  -- BaPersonID
  @IkForderungEinmaligCode INT,
  @PersonName VARCHAR(200),
  @FaFallIDString VARCHAR(20),
  @Username VARCHAR(200)
)
RETURNS VARCHAR(200)
AS BEGIN
  DECLARE
    @Result VARCHAR(200),
    @TestIkInterneVerrechnungID INT,
    @TestGlaeubiger_ZahlungswegID INT,
    @TestZusatzBaZahlungswegID INT,
    @TestUnterstuetzungsfall BIT,
    @TestZwBetrag MONEY,
    @TestZwZusatzBetrag MONEY

  SET @Result = NULL

  SELECT
    @TestIkInterneVerrechnungID = IkInterneVerrechnungID,
    @TestGlaeubiger_ZahlungswegID = BaZahlungswegID,
    @TestZusatzBaZahlungswegID = BaZahlungswegIDZusatz,
    @TestUnterstuetzungsfall = InterneVerrechnung,
    @TestZwBetrag = Betrag,
    @TestZwZusatzBetrag = BetragZusatz
  FROM dbo.fnIkInterneVerrechnung_Get(
    @FaLeistungID, @BaPersonID, @PeriodeDatum,
    @IkForderungArtCode, @IkForderungEinmaligCode
  )

  -- Kontrolle, ob ein Datensatz vorhanden ist
  IF @TestIkInterneVerrechnungID IS NULL OR @TestUnterstuetzungsfall IS NULL
  BEGIN
    SET @Result =
      'Beim Glaeubiger ' + @PersonName + ' sind die interne Verrechnung und der Zahlunsgweg ' +
      CASE
        WHEN @IkForderungArtCode = 10 THEN 'ALBV '
        WHEN @IkForderungArtCode = 11 THEN 'ÜbH '
        WHEN @IkForderungArtCode = 12 THEN 'KKBB '
        WHEN @IkForderungArtCode = 1 THEN 'ALBV '
        WHEN @IkForderungArtCode = 2 THEN 'ALV '
        WHEN @IkForderungArtCode = 3 THEN 'KiZu '
        WHEN @IkForderungArtCode = 4 THEN 'ALV '
        ELSE ''
      END + 'nicht definiert (' +
      @FaFallIDString + ', ' + @Username + ').'
    RETURN @Result
  END

  -- Kontrolle, ob der Zahlungsweg gültig ist
  IF @TestGlaeubiger_ZahlungswegID IS NOT NULL
  BEGIN
    SET @Result = dbo.fnBaZahlungsweg_Check(@TestGlaeubiger_ZahlungswegID, @PeriodeDatum)
    IF ISNULL(@Result, '') != '' 
    BEGIN
      RETURN @Result
    END
  END

  -- Kontrolle, ob der Zusatz-Zahlungsweg gültig ist
  IF @TestZusatzBaZahlungswegID IS NOT NULL
  BEGIN
    SET @Result = dbo.fnBaZahlungsweg_Check(@TestZusatzBaZahlungswegID, @PeriodeDatum)
    IF ISNULL(@Result, '') != '' 
    BEGIN
      RETURN @Result
    END
  END

  RETURN NULL
END
