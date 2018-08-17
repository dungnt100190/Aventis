SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnDynaValue_Value
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnDynaValue_Value.sql $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnDynaValue_Value.sql $
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
  DB-Object: fnDynaValue_Value
  Branch   : KiSS_40_CORE
  BuildNr  : 1
  Datum    : 21.06.2008 19:27
*/
CREATE FUNCTION dbo.fnDynaValue_Value (
  @FieldName        varchar(100),
  @FaLeistungID     int,
  @FaPhaseID        int)
RETURNS @OUTPUT TABLE (
  FaLeistungID      int NOT NULL,
  FaPhaseID     int NOT NULL,
  GridRowID     int NOT NULL,
  Value         sql_variant NULL,
  PRIMARY KEY (FaLeistungID, FaPhaseID, GridRowID))
AS 

BEGIN
  DECLARE @DynaFieldID  int,
          @FieldCode    int

  SELECT TOP 1 @DynaFieldID = DynaFieldID, @FieldCode = FieldCode
  FROM dbo.DynaField         FLD WITH (READUNCOMMITTED) 
  WHERE DynaFieldID = dbo.fnDynaFieldID(@FieldName)

  INSERT INTO @OUTPUT
    SELECT IsNull(VAL.FaLeistungID, 0), IsNull(VAL.FaPhaseID, 0), VAL.GridRowID,
      CASE
        WHEN @FieldCode = 5 AND SQL_VARIANT_PROPERTY(VAL.Value, 'BaseType') NOT IN ('datetime', 'smalldatetime') THEN
          CASE
            WHEN CONVERT(varchar, VAL.Value) LIKE '%[^0-9. ]%'             THEN NULL
            WHEN CONVERT(varchar, VAL.Value) LIKE '%[0-9].%[0-9].175[3-9]' THEN CONVERT(datetime, VAL.Value, 104)
            WHEN CONVERT(varchar, VAL.Value) LIKE '%[0-9].%[0-9].17[6-9]_' THEN CONVERT(datetime, VAL.Value, 104)
            WHEN CONVERT(varchar, VAL.Value) LIKE '%[0-9].%[0-9].1[8-9]__' THEN CONVERT(datetime, VAL.Value, 104)
            WHEN CONVERT(varchar, VAL.Value) LIKE '%[0-9].%[0-9].[2-9]___' THEN CONVERT(datetime, VAL.Value, 104)
            WHEN CONVERT(varchar, VAL.Value) LIKE '%[0-9].%[0-9].__'       THEN CONVERT(datetime, VAL.Value,   4)
            WHEN CONVERT(varchar, VAL.Value) LIKE '%[0-9].%[0-9]._'        THEN CONVERT(datetime, VAL.Value,   4)
            ELSE NULL
          END
        WHEN @FieldCode = 15 THEN '*** ValueText NOT SUPPORTED (' + @FieldName + ') ***'
        ELSE VAL.Value
      END
    FROM dbo.DynaValue          VAL WITH (READUNCOMMITTED) 
    WHERE (@FaLeistungID IS NULL  OR VAL.FaLeistungID  = @FaLeistungID)
      AND (@FaPhaseID IS NULL OR VAL.FaPhaseID = @FaPhaseID)
      AND VAL.DynaFieldID = @DynaFieldID

  RETURN
END

GO