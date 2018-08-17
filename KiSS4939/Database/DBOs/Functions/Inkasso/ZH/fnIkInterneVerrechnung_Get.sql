SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnIkInterneVerrechnung_Get
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Interne Verrechnung und Zahlungsweg suchen aus IkInterneVerrechnung
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    select * from dbo.fnIkInterneVerrechnung_Get(7024153, 180568, '20081001', 10, NULL)
=================================================================================================*/

CREATE FUNCTION dbo.fnIkInterneVerrechnung_Get
(
  @FaLeistungID INT,
  @BaPersonID INT,
  @StichDatum DATETIME,
  @IkForderungArtCode INT,
  @IkForderungEinmaligCode INT
)
RETURNS @OUTPUT TABLE (
  IkInterneVerrechnungID INT,
  InterneVerrechnung BIT,
  BaZahlungswegID INT,
  BaZahlungswegIDZusatz INT,
  Betrag MONEY,
  BetragZusatz MONEY
)
AS BEGIN

  DECLARE @ALBV_ALV_KiZu_Code INT
  SET @ALBV_ALV_KiZu_Code = dbo.fnIkInterneVerrechnung_GetCode(
    @IkForderungArtCode, @IkForderungEinmaligCode )


  INSERT @OUTPUT
  SELECT TOP 1
    IkInterneVerrechnungID = CASE
      -- wenn der Code nicht definiert ist, dann soll "kein" Datensatz zurückgegeben werden
      WHEN @ALBV_ALV_KiZu_Code = 0 THEN NULL ELSE V.IkInterneVerrechnungID
    END,
    InterneVerrechnung = dbo.fnIkInterneVerrechnung_Intern(@ALBV_ALV_KiZu_Code,
      V.IntVerrechnung_ALBV, V.IntVerrechnung_ALV, V.IntVerrechnung_KiZu),

    BaZahlungswegID = dbo.fnIkInterneVerrechnung_Zahlweg(
      @ALBV_ALV_KiZu_Code,
      V.IntVerrechnung_ALBV, V.IntVerrechnung_ALV, V.IntVerrechnung_KiZu,
      V.BaZahlungswegID_ALBV, V.BaZahlungswegID_ALV, V.BaZahlungswegID_KiZu),

    BaZahlungswegIDZusatz = CASE
      WHEN @IkForderungArtCode IN (10,11,12,13,14,15) THEN V.BaZahlungswegID_ALBVZusatz  -- ALBV, UebH, KKBB: Zahlung
      ELSE NULL
    END,
    Betrag = CASE WHEN @IkForderungArtCode IN (10,11,12,13,14,15) THEN V.Betrag ELSE NULL END,
    BetragZusatz = CASE WHEN @IkForderungArtCode IN (10,11,12,13,14,15) THEN V.BetragZusatz ELSE NULL END
  FROM dbo.IkInterneVerrechnung V
  WHERE V.FaLeistungID = @FaLeistungID
    AND V.BaPersonID = @BaPersonID
    AND V.DatumVon <= @StichDatum
  ORDER BY V.DatumVon DESC

  RETURN
END

GO