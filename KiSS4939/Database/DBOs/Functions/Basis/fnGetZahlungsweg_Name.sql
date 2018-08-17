SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnGetZahlungsweg_Name
GO
/*
  KiSS 4.0
  --------
  DB-Object: fnGetZahlungsweg_Name
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

CREATE FUNCTION dbo.fnGetZahlungsweg_Name (
  @Typ INT,
  @BankName varchar(50)
)
 RETURNS varchar(50)
AS BEGIN
  DECLARE @Result varchar(50)
  SET @Result = CASE
    WHEN @Typ IN (3,5) THEN @BankName
    WHEN @Typ IN (4) THEN 'Bank Ausland'
    WHEN @Typ IN (1,2) THEN 'PC Konto'
    WHEN @Typ IN (6) THEN 'Postmandant/Check'
    ELSE ''
  END
  RETURN @Result
END
 