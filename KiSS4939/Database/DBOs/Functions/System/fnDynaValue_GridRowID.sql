SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnDynaValue_GridRowID
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnDynaValue_GridRowID.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 15:55 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnDynaValue_GridRowID.sql $
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
  DB-Object: fnDynaValue_GridRowID
  Branch   : KiSS_40_CORE
  BuildNr  : 1
  Datum    : 21.06.2008 19:27
*/
CREATE FUNCTION dbo.fnDynaValue_GridRowID (
  @MaskName         varchar(100),
  @FaLeistungID     int,
  @FaPhaseID        int)
RETURNS @OUTPUT TABLE (
  FaLeistungID      int NOT NULL,
  FaPhaseID     int NOT NULL,
  GridRowID     int NOT NULL,
  PRIMARY KEY (FaLeistungID, FaPhaseID, GridRowID))
AS 

BEGIN
  INSERT INTO @OUTPUT
    SELECT DISTINCT IsNull(VAL.FaLeistungID, 0), IsNull(VAL.FaPhaseID, 0), VAL.GridRowID
    FROM dbo.DynaValue          VAL WITH (READUNCOMMITTED) 
      INNER JOIN dbo.DynaField  FLD WITH (READUNCOMMITTED) ON FLD.DynaFieldID = VAL.DynaFieldID
    WHERE (@FaLeistungID IS NULL  OR VAL.FaLeistungID  = @FaLeistungID)
      AND (@FaPhaseID IS NULL OR VAL.FaPhaseID = @FaPhaseID)
      AND FLD.MaskName = @MaskName

  RETURN
END

GO