SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnDatumUeberschneidung
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnDatumUeberschneidung.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 15:54 $
  $Revision: 2 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnDatumUeberschneidung.sql $
 * 
 * 2     24.06.09 16:17 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: fnDatumUeberschneidung
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:53
*/
CREATE FUNCTION dbo.fnDatumUeberschneidung
  (@DatumVon1 datetime,
   @DatumBis1 datetime,
   @DatumVon2 datetime,
   @DatumBis2 datetime)
  RETURNS bit
AS 

BEGIN
  IF @DatumVon1 BETWEEN @DatumVon2 AND @DatumBis2 OR         -- DatumVon1 innerhalb DatumVon2-DatumBis2
     @DatumBis1 BETWEEN @DatumVon2 AND @DatumBis2 OR         -- DatumBis1 innerhalb DatumVon2-DatumBis2
     (@DatumVon1 <= @DatumVon2 AND @DatumBis1 >= @DatumBis2) -- DatumVon1-DatumBis1 umfasst DatumVon2-DatumBis2   
    RETURN 1

  RETURN 0
END
GO