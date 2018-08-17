SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnFaGetLastFaLeistungID;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Fallführung/fnFaGetLastFaLeistungID.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:28 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get open or last closed entry in FaLeistung
    @BaPersonID: The id of the person to get last value
    @ModulID:    The id of the modul to get last entry from
  -
  RETURNS: FaLeistungID of desired entry or NULL if invalid or nothing found
  -
  TEST:    SELECT [dbo].[fnFaGetLastFaLeistungID](2, 2) -- FV
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Fallführung/fnFaGetLastFaLeistungID.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 15:34 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnFaGetLastFaLeistungID
(
  @BaPersonID INT,
  @ModulID INT
)
RETURNS INT
AS BEGIN
  -----------------------------------------------------------------------------
  -- debug: validate function
  -----------------------------------------------------------------------------
  /*
  -- vars
  DECLARE @ModulID INT
  SET @ModulID = 7

  -- get some entries to debug
  SELECT TOP 10 
         ID = CONVERT(INT, dbo.fnFaGetLastFaLeistungID(LEI.BaPersonID, @ModulID)), 
         LEI.*
  FROM FaLeistung LEI
  WHERE LEI.FaLeistungID = dbo.fnFaGetLastFaLeistungID(LEI.BaPersonID, @ModulID) AND
        LEI.DatumBis IS NULL AND
        5 < (SELECT COUNT(1) 
             FROM FaLeistung SUB
             WHERE SUB.ModulID = LEI.ModulID AND SUB.BaPersonID = LEI.BaPersonID)

  -- validate
  SELECT *
  FROM FaLeistung LEI
  WHERE LEI.ModulID = @ModulID AND 
        LEI.BaPersonid = 57966
  ORDER BY CASE WHEN LEI.DatumBis IS NULL THEN GETDATE()
                ELSE LEI.DatumBis
           END DESC, 
           LEI.DatumVon DESC,
           LEI.FaLeistungID DESC
  */

  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@BaPersonID IS NULL OR @ModulID IS NULL OR @ModulID < 1)
  BEGIN
    -- invalid value
    RETURN NULL
  END

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @FaLeistungID INT

  -----------------------------------------------------------------------------
  -- get value
  -----------------------------------------------------------------------------
  -- if: DatumBis is NULL, take these first and order first by DatumBis
  -- then: newest DatumVon
  -- then: newest FaLeistungID
  SELECT TOP 1 
         @FaLeistungID = LEI.FaLeistungID
  FROM dbo.FaLeistung LEI WITH(READUNCOMMITTED)
  WHERE LEI.BaPersonID = @BaPersonID AND
        LEI.ModulID = @ModulID
  ORDER BY CASE WHEN LEI.DatumBis IS NULL THEN dbo.fnGetDateFromInts(1, 1, 9999) -- take an impossible date
                ELSE LEI.DatumBis
           END DESC, 
           LEI.DatumVon DESC,
           LEI.FaLeistungID DESC

  -----------------------------------------------------------------------------
  -- return value
  -----------------------------------------------------------------------------  
  RETURN @FaLeistungID
END
GO