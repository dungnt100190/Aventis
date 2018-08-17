SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spKbRecycleBelegNr
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spKbRecycleBelegNr.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:18 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spKbRecycleBelegNr.sql $
 * 
 * 2     25.06.09 11:35 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spKbRecycleBelegNr
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:55
*/
CREATE PROCEDURE dbo.spKbRecycleBelegNr
 (@KbPeriodeID       int,
  @KbBelegKreisCode  int,
  @KontoNr           varchar(10),
  @KbBelegNr         int
  )
AS BEGIN
  DECLARE @KbBelegKreisID INT

  SELECT @KbBelegKreisID = KbBelegKreisID
  FROM dbo.KbBelegKreis WITH (READUNCOMMITTED) 
  WHERE KbPeriodeID = @KbPeriodeID
    AND KbBelegKreisCode = @KbBelegKreisCode
    AND IsNull(KontoNr, '') = IsNull(@KontoNr, '')

  INSERT INTO [KbFreieBelegNummer] (KbBelegKreisID,  BelegNr)  VALUES (@KbBelegKreisID, @KbBelegNr)
END
GO