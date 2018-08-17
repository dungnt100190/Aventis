SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetOEUserList;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetOEUserList.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:22 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Is used to get all users within the ZLE relationship
           Info: Used from dbo.fnBDEGetOEUserList
    @UserID:     The user to get data from
    @AllowNull:  Set if an empty entry is possible
  -
  RETURNS: Table containing all data in LOV style
  -
  TEST:    SELECT * FROM [dbo].[fnBDEGetOEUserList](2, 1)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetOEUserList.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     27.03.09 13:07 Cjaeggi
 * ##4366: Added extended function to have possibility to show all users
 * even for non-admins
 * 
 * 2     18.09.08 12:22 Cjaeggi
 * Kleine Anpassungen
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetOEUserList
(
  @UserID  INT,
  @AllowNull BIT
)
RETURNS @Result TABLE
(
  [Code] INT,
  [Text] VARCHAR(255)
)
AS BEGIN
  -- ---------------------------------------------------------------------------------------------
  -- get data from extended function with default parameters
  -- ---------------------------------------------------------------------------------------------
  INSERT INTO @Result
    SELECT [Code],
           [Text]
    FROM dbo.fnBDEGetOEUserListExtended(@UserID, @AllowNull, 0)

  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN
END
GO 