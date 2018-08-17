SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnFaGetFallIDOfDLDatumBis;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Fallführung/fnFaGetFallIDOfDLDatumBis.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:27 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get the DatumBis of fall id of current Dienstleistung
    @FaLeistungID:    The id of the Dienstleistung to get fall id from
    @Flags:           The flags from dbo.fnFaGetFallIDOfDL()
  -
  RETURNS: DatumBis from FaLeistung of FallID or NULL if closed or invalid
  -
  TEST:    SELECT [dbo].[fnFaGetFallIDOfDLDatumBis](3910, NULL)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Fallführung/fnFaGetFallIDOfDLDatumBis.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 15:34 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnFaGetFallIDOfDLDatumBis
(
  @FaLeistungID INT,
  @Flags varchar(50)
)
RETURNS datetime
AS BEGIN
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @FallID INT
  DECLARE @DatumBis datetime

  -----------------------------------------------------------------------------
  -- get value from function
  -----------------------------------------------------------------------------
  SET @FallID = dbo.fnFaGetFallIDOfDL(@FaLeistungID, @Flags)

  -----------------------------------------------------------------------------
  -- get DatumBis from table
  -----------------------------------------------------------------------------
  SELECT @DatumBis = LEI.DatumBis
  FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
  WHERE LEI.FaLeistungID = @FallID

  -----------------------------------------------------------------------------
  -- return value (even if null)
  ----------------------------------------------------------------------------- 
  RETURN @DatumBis
END
GO