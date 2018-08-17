SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spFbGetLastBookings
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spFbGetLastBookings.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:27 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:
    @UserID
    @BaPersonID
  -
  RETURNS: Last bookings of User, Person
  -
  TEST: EXEC spFBGetLastBookings 2075, 64805;
=================================================================================================*/
/*
  KiSS 4.0
  --------
  DB-Object: spFbGetLastBookings
  Branch   : KiSS4_BSS_Master
  BuildNr  : 1
  Datum    : 23.06.2008 10:54
*/
CREATE PROCEDURE dbo.spFbGetLastBookings
 (
    @UserID     INT,
    @BaPersonID INT
 )
AS BEGIN
  DECLARE @Praefix VARCHAR(10)

  SELECT TOP 1 @Praefix = Praefix 
  FROM dbo.FbBelegNr WITH (READUNCOMMITTED) 
  WHERE UserID = @UserID

  SELECT DISTINCT FBU.*
  FROM viewFbBuchungen  FBU
  WHERE FBU.FbBuchungID IN (SELECT TOP 50 FbBuchungID
                            FROM dbo.FbBuchung WITH (READUNCOMMITTED) 
                            WHERE UserID = @UserID
                              AND BelegNr LIKE ISNULL(@Praefix, '') + '%'
                            ORDER BY FbBuchungID DESC)
    AND (@BaPersonID = 0 OR FBU.BaPersonID = @BaPersonID)
  ORDER BY FBU.BelegNr, FBU.BuchungsDatum
END
GO