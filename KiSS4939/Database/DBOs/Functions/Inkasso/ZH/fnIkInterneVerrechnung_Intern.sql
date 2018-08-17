SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnIkInterneVerrechnung_Intern
GO
/*
===================================================================================================
Author:      sozheo
Create date: 28.02.2009
Description: Bestimmt die Interne Verrechnung aus IkInterneVerrechnung
===================================================================================================
History:
--------
28.02.2009 : sozheo : neu erstellt
===================================================================================================
*/

CREATE FUNCTION [dbo].[fnIkInterneVerrechnung_Intern] (
  @ALBV_ALV_KiZu_Code INT,
  @IntVerrechnung_ALBV BIT,
  @IntVerrechnung_ALV BIT,
  @IntVerrechnung_KiZu BIT
)
RETURNS BIT
AS BEGIN
  DECLARE @Intern BIT

  SET @Intern = CASE
    -- periodische
    WHEN @ALBV_ALV_KiZu_Code = 1 THEN @IntVerrechnung_ALBV   -- ALBV: Auszahlung
    WHEN @ALBV_ALV_KiZu_Code = 2 THEN @IntVerrechnung_ALV    -- ALV: Weitervermittlung
    WHEN @ALBV_ALV_KiZu_Code = 3 THEN @IntVerrechnung_KiZu   -- KiZu: Weitervermittlung
    WHEN @ALBV_ALV_KiZu_Code = 4 THEN CONVERT(BIT, 1)   -- W-Modul: immer interne Verrechnung
    ELSE CONVERT(BIT, 1)
  END

  RETURN @Intern
END
