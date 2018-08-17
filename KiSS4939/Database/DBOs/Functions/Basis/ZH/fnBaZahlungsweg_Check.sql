SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBaZahlungsweg_Check
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Functions/fnBaZahlungsweg_Check.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 10:18 $
  $Revision: 4 $
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
  $Log: /Database/KiSS4_MASTER_ZH/Functions/fnBaZahlungsweg_Check.sql $
 * 
 * 4     11.12.09 10:20 Lloreggia
 * Header aktualisiert
 * 
 * 3     10.03.09 18:08 Rstahel
 * Abgleich der Functions aus KISS4_MASTER_ZH
 * 
 * 1     6.01.09 15:19 Rhesterberg
=================================================================================================*/

/*
=================================================================================================
Author:      R. Hesterberg
Create date: 12.12.2008
Description: Kontrolle der Zahlungsweg Angaben
=================================================================================================
History:
06.01.2009 : sozheo : neu erstellt
=================================================================================================
*/

CREATE FUNCTION [dbo].[fnBaZahlungsweg_Check]
(
  @BaZahlungswegID INT,
  @ValutaDatum DATETIME
)
RETURNS varchar(200)
AS BEGIN
  DECLARE
    @Result varchar(200),
    @Glaeubiger_BaPersonID INT,
    @Glaeubiger_BaInstitutionID INT,
    @Glaeubiger_IBAN varchar(50),
    @Glaeubiger_ESTyp INT,
    @FallPersonName varchar(200),
    @ZW_DatumVon DATETIME,
    @ZW_DatumBis DATETIME

  -- Default-Wert setzen
  SET @Result = ''

  IF @BaZahlungswegID IS NULL
  BEGIN
    -- Zahlungsweg ID nicht gefunden
    SET @Result = '@BaZahlungswegID ist leer.'
  END
  ELSE
  BEGIN
    -- Zahlungsweg ID gefunden, jetzt nach Gläubiger-Adresse kontrollieren:
    SELECT TOP 1
      @FallPersonName = CASE
        WHEN Z.BaPersonID IS NULL THEN I.Name
        ELSE P.Name + IsNull(' '+P.Vorname, '')
      END,
      @Glaeubiger_BaPersonID = Z.BaPersonID,
      @Glaeubiger_BaInstitutionID = Z.BaInstitutionID,
      @Glaeubiger_IBAN = Z.IBANNummer,
      @Glaeubiger_ESTyp = Z.EinzahlungsscheinCode,
      @ZW_DatumVon = Z.DatumVon,
      @ZW_DatumBis = Z.DatumBis
    FROM dbo.BaZahlungsweg Z WITH(READUNCOMMITTED)
    LEFT OUTER JOIN dbo.BaPerson P WITH(READUNCOMMITTED) ON P.BaPersonID = Z.BaPersonID
    LEFT OUTER JOIN dbo.BaInstitution I WITH(READUNCOMMITTED) ON I.BaInstitutionID = Z.BaInstitutionID
    WHERE Z.BaZahlungswegID = @BaZahlungswegID


    IF @Glaeubiger_BaPersonID IS NULL AND @Glaeubiger_BaInstitutionID IS NULL BEGIN
      -- Gläubiger Zahlungsweg konnte nicht gefunden werden
      SET @Result = 'Zahlungsweg-Gläubiger nicht gefunden (BaZahlungswegID=' +
          CONVERT(varchar, IsNull(@BaZahlungswegID, 0)) + ').' + char(13) + char(10)
    END

    IF @Glaeubiger_IBAN IS NULL AND @Glaeubiger_ESTyp IN (2,3,4,5) BEGIN
      -- IBAN-Nummer ist leer
      SET @Result = @Result + 'IBAN-Nummer des Zahlungswegs ist leer (BaZahlungswegID=' +
          CONVERT(varchar, IsNull(@BaZahlungswegID, 0)) + ', Person/Inst.="' +
          IsNull(@FallPersonName, '') + '").' + char(13) + char(10)
    END

    IF NOT @ValutaDatum BETWEEN IsNull(@ZW_DatumVon, @ValutaDatum) AND IsNull(@ZW_DatumBis, @ValutaDatum)
    BEGIN
      -- Zahlungsweg-Gültigkeit deckt Valuta nicht ab
      SET @Result = @Result + 'Der Zahlungsweg ist am Valuta-Datum nicht gültig (BaZahlungswegID=' +
          CONVERT(varchar, IsNull(@BaZahlungswegID, 0)) + ', Person/Inst.="' +
          IsNull(@FallPersonName, '') + '").' + char(13) + char(10)
    END
  END

  RETURN @Result
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
