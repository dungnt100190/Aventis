SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnDynaValue_LOVList
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnDynaValue_LOVList.sql $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnDynaValue_LOVList.sql $
 * 
 * 2     24.06.09 16:19 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: fnDynaValue_LOVList
  Branch   : KiSS_40_CORE
  BuildNr  : 1
  Datum    : 21.06.2008 19:27
*/
CREATE FUNCTION dbo.fnDynaValue_LOVList (
  @FieldName        varchar(100),
  @FaLeistungID     int,
  @FaPhaseID        int)
RETURNS @OUTPUT TABLE (
  FaLeistungID  int NOT NULL,
  FaPhaseID     int NOT NULL,
  GridRowID     int NOT NULL,
  Codes         varchar(100),
  Text          varchar(1000) NULL,
  PRIMARY KEY (FaLeistungID, FaPhaseID, GridRowID))
AS 

BEGIN
  DECLARE @LOVName      varchar(100)

  SELECT TOP 1 @LOVName = LOVName
  FROM dbo.DynaField         FLD WITH (READUNCOMMITTED) 
  WHERE DynaFieldID = dbo.fnDynaFieldID(@FieldName)

  INSERT INTO @OUTPUT
    SELECT VAL.FaLeistungID, VAL.FaPhaseID, VAL.GridRowID, CONVERT(varchar(100), VAL.Value),
      dbo.fnLOVColumnListe(@LOVName, CONVERT(varchar(100), VAL.Value), NULL)
    FROM dbo.fnDynaValue_Value(@FieldName, @FaLeistungID, @FaPhaseID)  VAL

  RETURN
END

GO