SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAyEinzelzahlung_Delete
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spAyEinzelzahlung_Delete.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:34 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spAyEinzelzahlung_Delete.sql $
 * 
 * 2     25.06.09 11:42 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spAyEinzelzahlung_Delete
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:53
*/
CREATE PROCEDURE dbo.spAyEinzelzahlung_Delete
 (@BgPositionID  int)
AS BEGIN
  IF EXISTS (SELECT *
             FROM KbBuchung                   FBL
               INNER JOIN KbBuchungKostenart  FLK ON FLK.KbBuchungID = FBL.KbBuchungID
             WHERE FLK.BgPositionID = @BgPositionID
               AND FBL.KbBuchungStatusCode NOT IN (1, 2, 7)
  ) BEGIN
    RETURN -1
  END

  DECLARE @KbBuchung TABLE (
    KbBuchungID     int PRIMARY KEY
  )

  INSERT INTO @KbBuchung
    SELECT DISTINCT KbBuchungID
    FROM KbBuchungKostenart
    WHERE BgPositionID = @BgPositionID

  DELETE KbBuchungKostenart
  WHERE BgPositionID = @BgPositionID

  DELETE BUC
  FROM KbBuchung           BUC
    INNER JOIN @KbBuchung  TMP ON TMP.KbBuchungID = BUC.KbBuchungID
  WHERE NOT EXISTS (SELECT * FROM KbBuchungKostenart WHERE KbBuchungID = BUC.KbBuchungID)

  DELETE FROM BgPosition
  WHERE BgPositionID = @BgPositionID
    AND BgKategorieCode IN (100, 101)
END
GO