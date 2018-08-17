SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnIkInterneVerrechnung_Zahlweg
GO
/*
===================================================================================================
Author:      sozheo
Create date: 28.02.2009
Description: Bestimmt Zahlweg aus IkInterneVerrechnung
===================================================================================================
History:
--------
28.02.2009 : sozheo : neu erstellt
===================================================================================================
*/

CREATE FUNCTION [dbo].[fnIkInterneVerrechnung_Zahlweg] (
  @ALBV_ALV_KiZu_Code INT,
  @IntVerrechnung_ALBV BIT,
  @IntVerrechnung_ALV BIT,
  @IntVerrechnung_KiZu BIT,
  @BaZahlungswegID_ALBV INT,
  @BaZahlungswegID_ALV INT,
  @BaZahlungswegID_KiZu INT
)
RETURNS INT
AS BEGIN
  DECLARE  @BaZahlungswegID INT

  SET @BaZahlungswegID = CASE
    -- periodische
    WHEN @ALBV_ALV_KiZu_Code = 1 AND @IntVerrechnung_ALBV = 0
      THEN @BaZahlungswegID_ALBV -- ALBV: Auszahlung
    WHEN @ALBV_ALV_KiZu_Code = 2 AND @IntVerrechnung_ALV = 0
      THEN @BaZahlungswegID_ALV   -- ALV: Weitervermittlung
    WHEN @ALBV_ALV_KiZu_Code = 3 AND @IntVerrechnung_KiZu = 0
      THEN @BaZahlungswegID_KiZu  -- KiZu: Weitervermittlung
    WHEN @ALBV_ALV_KiZu_Code = 4
      THEN NULL   -- W-Modul: immer interne Verrechnung
    ELSE NULL
  END

  RETURN @BaZahlungswegID
END
