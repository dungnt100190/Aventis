SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnKbGetKostenstelle
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnKbGetKostenstelle.sql $
  $Author: Ckaeser $
  $Modtime: 12.08.09 14:18 $
  $Revision: 5 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnKbGetKostenstelle.sql $
 * 
 * 5     12.08.09 14:27 Ckaeser
 * #4932 Alter2Create Bereinigung DBO's
 * 
 * 4     6.08.09 10:57 Ckaeser
 * 
 * 1     3.08.09 10:45 Nweber
 * #4932: Functions and Stored Procedures merged
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: fnKbGetKostenstelle
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:57
*/
CREATE    FUNCTION dbo.fnKbGetKostenstelle
 (@BaPersonID int)
 RETURNS varchar(100)
AS
BEGIN
  RETURN (
    SELECT PRS.NameVorname + ' ' +CONVERT(varchar, PRS.BaPersonID) 
    FROM dbo.vwPerson PRS 
    WHERE BaPersonID = @BaPersonID)
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
