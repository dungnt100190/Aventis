SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spGetDynaFldIDfromTextmarke
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spGetDynaFldIDfromTextmarke.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:25 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spGetDynaFldIDfromTextmarke.sql $
 * 
 * 2     25.06.09 11:38 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spGetDynaFldIDfromTextmarke
  Branch   : KiSS_40_CORE
  BuildNr  : 1
  Datum    : 21.06.2008 19:28
*/
CREATE PROCEDURE dbo.spGetDynaFldIDfromTextmarke
(@Textmarke varchar(200),
 @FldID int OUTPUT)
AS BEGIN
  SET @FldID = NULL

  SELECT @FldID = DynaFieldID FROM dbo.DynaField WITH (READUNCOMMITTED) WHERE FieldName = @Textmarke

  IF @FldID IS NULL
    RAISERROR('Das Feld mit der Textmarke [%s] existiert nicht (oder mehr als einmal)',18,1,@Textmarke)

  PRINT 'FldID of Textmarke [' + @Textmarke + '] :' + IsNull(CONVERT(varchar,@FldID),'null')
END

GO