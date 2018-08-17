SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spLOV
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Stored Procedures/System/spLOV.sql $
  $Author: Lloreggia $
  $Modtime: 6.01.10 18:05 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @LOVName: The name of the LOV to display
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Stored Procedures/System/spLOV.sql $
 * 
 * 3     6.01.10 18:21 Lloreggia
 * Alter to Create
 * 
 * 2     22.01.09 11:41 Cjaeggi
 * Renamed
 * 
 * 1     3.09.08 17:54 Aklopfenstein
 * 
 * 1     3.09.08 11:13 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE PROCEDURE dbo.spLOV
(
  @LOVName VARCHAR(200)
)
AS BEGIN
  -- the query to execute (do not change anything here)
  SELECT Code, Text 
  FROM dbo.XLOVCode WITH (READUNCOMMITTED)
  WHERE LOVName = @LOVName
  ORDER BY SortKey

  -- return value
  RETURN CASE @@ROWCOUNT WHEN 0 THEN 0 ELSE 1 END
END
GO