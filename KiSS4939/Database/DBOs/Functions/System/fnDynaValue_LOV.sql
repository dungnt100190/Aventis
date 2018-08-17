SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnDynaValue_LOV
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnDynaValue_LOV.sql $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnDynaValue_LOV.sql $
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
  DB-Object: fnDynaValue_LOV
  Branch   : KiSS_40_CORE
  BuildNr  : 1
  Datum    : 21.06.2008 19:27
*/
CREATE FUNCTION dbo.fnDynaValue_LOV (
  @FieldName        varchar(100),
  @FaLeistungID     int,
  @FaPhaseID        int)
RETURNS @OUTPUT TABLE (
  FaLeistungID  int NOT NULL,
  FaPhaseID     int NOT NULL,
  GridRowID     int NOT NULL,
  Code          int,
  Text          varchar(200) NULL,
  PRIMARY KEY (FaLeistungID, FaPhaseID, GridRowID))
AS 

BEGIN
  DECLARE @LOVName      varchar(100)

  SELECT TOP 1 @LOVName = LOVName
  FROM dbo.DynaField         FLD WITH (READUNCOMMITTED) 
  WHERE DynaFieldID = dbo.fnDynaFieldID(@FieldName)

  INSERT INTO @OUTPUT
    SELECT VAL.FaLeistungID, VAL.FaPhaseID, VAL.GridRowID, CONVERT(int, VAL.Value), XLC.Text
    FROM dbo.fnDynaValue_Value(@FieldName, @FaLeistungID, @FaPhaseID)  VAL
      LEFT  JOIN dbo.XLOVCode       XLC WITH (READUNCOMMITTED) ON XLC.LOVName = @LOVName AND XLC.Code = CONVERT(int, VAL.Value)

  RETURN
END

GO