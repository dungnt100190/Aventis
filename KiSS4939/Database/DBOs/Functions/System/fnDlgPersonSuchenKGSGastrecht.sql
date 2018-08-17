SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnDlgPersonSuchenKGSGastrecht;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnDlgPersonSuchenKGSGastrecht.sql $
  $Author: Cjaeggi $
  $Modtime: 6.08.10 17:30 $
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get all clients of users KGS prepared for dialog.
           This function includes also those clients who are not within allowed KGS but the
           given user has guestrights to either one process or orgunit.
    @UserID:           The user to get data from
    @OnlyWithLeistung: Get only persons who have Leistungen
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
  -
  TEST:    SELECT * FROM dbo.fnDlgPersonSuchenKGSGastrecht(2, 1, NULL)
           SELECT * FROM dbo.fnDlgPersonSuchenKGSGastrecht(22, 1, NULL)
=================================================================================================*/

CREATE FUNCTION dbo.fnDlgPersonSuchenKGSGastrecht
(
  @UserID INT,
  @OnlyWithLeistung BIT,
  @PersonNameVornameSearchString VARCHAR(255)
  )
RETURNS @Result TABLE
(
  [BaPersonID$] INT NOT NULL,
  [Nr.] INT NOT NULL,
  [Name] VARCHAR(255) NOT NULL,
  [Strasse] VARCHAR(255),
  [Ort] VARCHAR(255),
  [Geburt] DATETIME
)
AS BEGIN
  -----------------------------------------------------------------------------
  -- define temporary table
  -----------------------------------------------------------------------------
  DECLARE @tmpPreResult TABLE
  (
    BaPersonID INT NOT NULL PRIMARY KEY,
    BaAdresseID INT
  );
  
  -----------------------------------------------------------------------------
  -- add values from canton (including orgunit-guestright) and process-guestright
  -----------------------------------------------------------------------------
  INSERT INTO @tmpPreResult (BaPersonID, BaAdresseID)
    -- insert all person from allowed KGSs and get the corresponding address id
    SELECT BaPersonID  = FCN.BaPersonID, 
           BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', FCN.BaPersonID, 1, NULL)
    FROM dbo.fnGetCantonsOrgUnitsPersons(@UserID, @OnlyWithLeistung, @PersonNameVornameSearchString) FCN
    
    UNION
    
    -- insert from process-guestright
    SELECT BaPersonID  = LEI.BaPersonID, 
           BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', LEI.BaPersonID, 1, NULL)
    FROM dbo.FaLeistungZugriff  LEZ WITH (READUNCOMMITTED)
      INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = LEZ.FaLeistungID
    WHERE LEZ.UserID = @UserID;
  
  -----------------------------------------------------------------------------
  -- fill result with sorted data
  -----------------------------------------------------------------------------
  INSERT INTO @Result ([BaPersonID$], [Nr.], [Name], [Strasse], [Ort], [Geburt])
    SELECT [BaPersonID$] = PRS.[BaPersonID], 
           [Nr.]         = PRS.[BaPersonID], 
           [Name]        = dbo.fnGetLastFirstName(NULL, PRS.[Name], PRS.[Vorname]),
           [Strasse]     = ADRW.[Strasse] + ISNULL(' ' + ADRW.[HausNr], ''),
           [Ort]         = ISNULL(ADRW.[PLZ] + ' ', '') + ISNULL(ADRW.[Ort], ''),
           [Geburt]      = PRS.[Geburtsdatum]
    FROM @tmpPreResult        TMP
      INNER JOIN dbo.BaPerson PRS  WITH (READUNCOMMITTED) ON PRS.[BaPersonID] = TMP.[BaPersonID]
            
      -- wohnsitz
      LEFT JOIN dbo.BaAdresse ADRW WITH (READUNCOMMITTED) ON ADRW.[BaAdresseID] = TMP.[BaAdresseID]
    ORDER BY [Name], [Ort], [BaPersonID$];
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN;
END;
GO
