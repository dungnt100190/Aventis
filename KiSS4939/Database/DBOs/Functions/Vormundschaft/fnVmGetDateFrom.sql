SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnVmGetDateFrom
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Functions/fnVmGetDateFrom.sql $
  $Author: Ckaeser $
  $Modtime: 24.06.09 16:05 $
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
  $Log: /Database/KISS4_BSS_MasterDev/Functions/fnVmGetDateFrom.sql $
 * 
 * 2     25.06.09 8:15 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: fnVmGetDateFrom
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:56
*/
CREATE FUNCTION dbo.fnVmGetDateFrom
 (@BaPersonID int)
 RETURNS datetime
AS 

BEGIN
	-- Select DateFrom FaLeistung
	-- If open VormundschaftlicheMassnahme exists take DateFrom this
	-- If VormundschaftlicheMassnahme doesn't exist take current DateFrom

	DECLARE @rslt datetime
	DECLARE @cnt INT

	SELECT @cnt = COUNT(*)
	FROM dbo.FaLeistung WITH (READUNCOMMITTED) 
	WHERE BaPersonID = @BaPersonID
	AND ModulID = 5
	AND FaProzessCode = 501
	AND DatumBis IS NULL

	SELECT @rslt = MAX(DatumVon)
	FROM   dbo.FaLeistung WITH (READUNCOMMITTED) 
	WHERE  BaPersonID = @BaPersonID
	AND ModulID = 5
	AND (@cnt = 0 OR FaProzessCode = 501)

	RETURN @rslt
END
GO