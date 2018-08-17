SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnIkInterneVerrechnung_GetCode
GO
/*
===================================================================================================
Author:      sozheo
Create date: 28.02.2009
Description: Bestimmt den Code zur Bestimmung von Zahlweg und Interne Verrechnung
===================================================================================================
History:
--------
28.02.2009 : sozheo : neu erstellt
28.05.2009 : sozheo : für Codes 102, 103, 104 und 130 ergänzt
===================================================================================================
*/

CREATE FUNCTION [dbo].[fnIkInterneVerrechnung_GetCode] (
  @IkForderungArtCode INT, 
  @IkForderungEinmaligCode INT
)
RETURNS INT
AS BEGIN
  DECLARE  @ALBV_ALV_KiZu_Code INT

  SET @ALBV_ALV_KiZu_Code = CASE

    -- periodische A und W
    -- -------------------
    -- ALBV Auszahlungen, immer bevorschusst
    WHEN @IkForderungArtCode IN (10,11,12,13,14,15) THEN 1 -- ALBV, UEBH, KKBB
    -- ALV Kinder, nie bevorschusst, immer vermittelt
    WHEN @IkForderungArtCode IN (2, 102) THEN 2 -- ALV Hauptzahlweg
    -- ALV Erwachsene, nie bevorschusst, immer vermittelt
    WHEN @IkForderungArtCode IN (4, 104) THEN 2 -- ALV Hauptzahlweg
    -- KiZu, nie bevorschusst, immer vermittelt
    WHEN @IkForderungArtCode IN (3, 103) THEN 3 -- KiZu
      -- periodische W
    WHEN @IkForderungArtCode > 1000 THEN 4 -- W-Modul: immer interne Verrechnung

    -- einmalige A
    -- -----------
    -- lov IkForderungEinmalig
    -- einmalige A: Codes über 200 sind immer Gläubiger Stadt, also immer intern
    WHEN @IkForderungArtCode IN (30, 130) AND @IkForderungEinmaligCode BETWEEN 200 AND 299 THEN 4 -- interne Verrechnung
    -- einmalige A: ALV Kinder, interne Verrechnung wird von ALV genommen
    WHEN @IkForderungArtCode IN (30, 130) AND @IkForderungEinmaligCode IN (1,3) THEN 2 -- ALV Hauptzahlweg
    -- einmalige A: KiZu
    WHEN @IkForderungArtCode IN (30, 130) AND @IkForderungEinmaligCode IN (5) THEN 3 -- KiZu
    -- einmalige A: Abgetretene: immer interne Verrechnung
    WHEN @IkForderungArtCode IN (30, 130) AND @IkForderungEinmaligCode IN (2, 4, 6) THEN 4 -- interne Verrechnung
    -- 09.07.2009 : Korrektur gemäss Spez: #30, interne Verrechnung
    -- Code 12, 13, 14, 16: Sollstellungen von einmaligen Forderungen „Verfahrenskosten“ Zahlweg immer Hauptzahlweg 
    -- Konto Gläubiger (nicht durch User veränderbar).    
    WHEN @IkForderungArtCode IN (30, 130) AND @IkForderungEinmaligCode IN (12, 13, 14, 16) THEN 2 -- ALV Hauptzahlweg
    -- der Rest immer intern
    ELSE 4 -- interne Verrechnung
  END

  RETURN @ALBV_ALV_KiZu_Code
END

