SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnGetZahlungsweg_Name_ML
GO
/*
  KiSS 4.0
  --------
  DB-Object: fnGetZahlungsweg_Name_ML
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
-- 24.12.2007 : RH : neu mit mehreren Sprachen
-- =====================================================================================

CREATE FUNCTION dbo.fnGetZahlungsweg_Name_ML (
  @Typ INT,
  @BankName varchar(50),
  @SprachCode INT
)
 RETURNS varchar(50)
AS BEGIN
  DECLARE @Result varchar(50)
  SET @Result = CASE
    WHEN @Typ IN (3,5) THEN @BankName
    WHEN @Typ IN (4) THEN CASE @SprachCode
      WHEN 1 THEN 'Bank Ausland'
      WHEN 2 THEN 'Banque étranger'
    END
    WHEN @Typ IN (1,2) THEN CASE @SprachCode
      WHEN 1 THEN 'PC Konto'
      WHEN 2 THEN 'PC conte'
    END
    WHEN @Typ IN (6) THEN CASE @SprachCode
      WHEN 1 THEN 'Postmandant/Check'
      WHEN 2 THEN 'Cheque'
    END
    ELSE ''
  END
  RETURN @Result
END
 