SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnDlgMitarbeiterSuchenKGS;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnDlgMitarbeiterSuchenKGS.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:07 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get all users of user's KGS for dialog
    @UserID: The user to get data from
  -
  RETURNS: Table containing all data found of all orgunits of current user's canton
  -
  TEST:    SELECT * FROM [dbo].[fnDlgMitarbeiterSuchenKGS](1007)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnDlgMitarbeiterSuchenKGS.sql $
 * 
 * 2     7.01.10 10:45 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 15:34 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnDlgMitarbeiterSuchenKGS
(
  @UserID INT
)
RETURNS @Result TABLE
(
  UserID$ INT NOT NULL,
  [Nr.] INT NOT NULL,
  [Name] varchar(255) NOT NULL,
  [Kürzel] varchar(10),
  [Abteilung] varchar(255)
)
AS BEGIN
  -----------------------------------------------------------------------------
  -- get all persons
  -----------------------------------------------------------------------------
  INSERT INTO @Result
    SELECT DISTINCT
           USR.UserID,
           USR.UserID,
           USR.Name,
           USR.[Kürzel],
           USR.Abteilung
    FROM dbo.fnGetCantonsOrgUnitsUsers(@UserID) USR
    ORDER BY [Name], [Abteilung]

  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN
END
GO