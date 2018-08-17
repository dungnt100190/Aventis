SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnFaGetFallIDOfDL;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Fallführung/fnFaGetFallIDOfDL.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:26 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get fall id of current Dienstleistung
    @FaLeistungID: The id of the Dienstleistung to get fall id from
    @Flags:        'onlyopen' = only open fall ids, otherwise all items are handled
  -
  RETURNS: Fall id found (FaLeistungID of FV) or -1 if invalid or nothing found
  -
  TEST:    SELECT [dbo].[fnFaGetFallIDOfDL](3910, NULL)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Fallführung/fnFaGetFallIDOfDL.sql $
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     6.11.08 8:49 Cjaeggi
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 15:34 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnFaGetFallIDOfDL
(
  @FaLeistungID INT,
  @Flags varchar(50)
)
RETURNS INT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not value is passed, invalid value
  IF (@FaLeistungID IS NULL OR @FaLeistungID < 1)
  BEGIN
    -- invalid value
    RETURN -1
  END

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @OUTPUT INT
  DECLARE @BaPersonID INT
  DECLARE @DatumVon datetime

  -----------------------------------------------------------------------------
  -- get person of current id
  -----------------------------------------------------------------------------
  SELECT TOP 1
         @BaPersonID = LEI.BaPersonID,
         @DatumVon = LEI.DatumVon
  FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
  WHERE LEI.FaLeistungID = @FaLeistungID

  -----------------------------------------------------------------------------
  -- get id of item ordered by date
  -----------------------------------------------------------------------------
  BEGIN
    SELECT TOP 1
           @OUTPUT = LEI.FaLeistungID
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
    WHERE LEI.BaPersonID = @BaPersonID AND        -- only for same person
          LEI.ModulID = 2 AND                     -- only FallVerlauf
          LEI.DatumVon <= @DatumVon AND           -- filter by DatumVon, we do not want newer ones!
          LEI.FaLeistungID <= @FaLeistungID AND   -- items are ordered by id and we do not want newer ones!
          (@Flags IS NULL OR
           (@Flags = 'onlyopen' AND LEI.DatumBis IS NULL)
          )
    ORDER BY LEI.DatumVon DESC, LEI.FaLeistungID DESC
  END

  -----------------------------------------------------------------------------
  -- get id of item ordered by id (only if none found yet)
  -----------------------------------------------------------------------------
  IF (@OUTPUT IS NULL)
  BEGIN
    SELECT TOP 1
           @OUTPUT = LEI.FaLeistungID
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
    WHERE LEI.BaPersonID = @BaPersonID AND        -- only for same person
          LEI.ModulID = 2 AND                     -- only FallVerlauf
          LEI.FaLeistungID <= @FaLeistungID AND   -- items are ordered by id and we do not want newer ones!
          (@Flags IS NULL OR
           (@Flags = 'onlyopen' AND LEI.DatumBis IS NULL)
          )
    ORDER BY LEI.DatumVon DESC, LEI.FaLeistungID DESC
  END

  -----------------------------------------------------------------------------
  -- get id of item without filter (only if none found yet)
  -----------------------------------------------------------------------------
  IF (@OUTPUT IS NULL)
  BEGIN
    SELECT TOP 1
           @OUTPUT = LEI.FaLeistungID
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
    WHERE LEI.BaPersonID = @BaPersonID AND        -- only for same person
          LEI.ModulID = 2 AND                     -- only FallVerlauf
          (@Flags IS NULL OR
           (@Flags = 'onlyopen' AND LEI.DatumBis IS NULL)
          )
    ORDER BY LEI.DatumVon DESC, LEI.FaLeistungID DESC
  END

  -----------------------------------------------------------------------------
  -- check and return value
  ----------------------------------------------------------------------------- 
  RETURN IsNull(@OUTPUT, -1)
END
GO