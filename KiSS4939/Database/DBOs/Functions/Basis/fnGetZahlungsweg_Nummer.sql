SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnGetZahlungsweg_Nummer
GO
/*
  KiSS 4.0
  --------
  DB-Object: fnGetZahlungsweg_Nummer
  Branch   : KiSS_PROD
  BuildNr  : 1
  Datum    : 15.07.2008 17:25
*/
-- =====================================================================================
-- Author:      RH (R. Hesterberg)
-- Create date: 01.12.2007
-- Description: Darstellung des Zahlungswegs
-- =====================================================================================
-- History:
-- 01.12.2007 : RH : neu
-- =====================================================================================

CREATE FUNCTION dbo.fnGetZahlungsweg_Nummer (
  @Typ INT,
  @BankKontoNr varchar(50),
  @IBANNummer varchar(50),
  @PostKontoNummer varchar(20)
)
 RETURNS varchar(50)
AS BEGIN
  DECLARE @Result varchar(50)
  SET @Result = CASE
    WHEN @Typ IN (1,2) THEN dbo.fnTnToPc(@PostKontoNummer)
    WHEN @Typ IN (3,5) AND NOT @BankKontoNr IS NULL THEN @BankKontoNr
    WHEN @Typ IN (3,4,5) AND NOT @IBANNummer IS NULL THEN @IBANNummer
    ELSE ''
  END
  RETURN @Result
END
 