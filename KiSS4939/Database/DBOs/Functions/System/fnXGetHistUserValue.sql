SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXGetHistUserValue;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnXGetHistUserValue.sql $
  $Author: Cjaeggi $
  $Modtime: 11.06.10 10:28 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Get named history values for any user as defined in history table
    @ValueString: The name of the value to retrieve for given user id
                  - 'MitarbeiterNr': The number of the user as defined in external BDE tool
                  - 'LohntypCode':   The type of wages of the user (see lov: BenutzerLohnTyp)
                  - 'KeinBDEExport':  Erfasste Leistungen werden nicht ans ABAKUS übermittelt.
    @UserID:      The id of the user to get value for
    @Date:        The date to use within history to get value
  -
  RETURNS: The history value depending on given parameters for given user or NULL if no value found
           or invalid parameters given.
  -
  TEST:    SELECT dbo.fnXGetHistUserValue('MitarbeiterNr', 350, GETDATE());
           SELECT dbo.fnXGetHistUserValue('MitarbeiterNr', 350, '2009-01-01');
           --
           SELECT dbo.fnXGetHistUserValue('LohntypCode', 350, GETDATE());
           SELECT dbo.fnXGetHistUserValue('LohntypCode', 350, '2009-01-01');
           SELECT dbo.fnXGetHistUserValue('LohntypCode', 2567, GETDATE());
           SELECT dbo.fnXGetHistUserValue('LohntypCode', 2567, '2009-11-08');
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/fnXGetHistUserValue.sql $
 * 
 * 1     11.06.10 10:29 Cjaeggi
 * #6108: Added new function
=================================================================================================*/

CREATE FUNCTION dbo.fnXGetHistUserValue
(
  @ValueString VARCHAR(50),
  @UserID INT,
  @Date DATETIME
)
RETURNS SQL_VARIANT
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@ValueString NOT IN ('MitarbeiterNr', 'LohntypCode', 'KeinBDEExport') 
   OR ISNULL(@UserID, -1) < 1
   OR @Date IS NULL)
  BEGIN
    -- invalid parameters, do not continue
    RETURN NULL;
  END;
  
  -----------------------------------------------------------------------------
  -- get value depending on requested string
  -----------------------------------------------------------------------------
  IF (@ValueString = 'MitarbeiterNr')
  BEGIN
    ---------------------------------------------------------------------------
    -- MitarbeiterNr:
    ---------------------------------------------------------------------------
    -- init vars
    DECLARE @MitarbeiterNr VARCHAR(50);
    
    -- get value
    SELECT TOP 1 @MitarbeiterNr = HUS.MitarbeiterNr
    FROM dbo.Hist_XUser HUS WITH (READUNCOMMITTED)
      INNER JOIN dbo.HistoryVersion VER WITH (READUNCOMMITTED) ON VER.VerID = HUS.VerID
    WHERE HUS.UserID = @UserID 
      AND DATEADD(d, 0, DATEDIFF(d, 0, VER.VersionDate)) <= @Date
    ORDER BY VER.VersionDate DESC, VER.VerID DESC;
    
    -- return value
    RETURN @MitarbeiterNr;
    ---------------------------------------------------------------------------
  END
  ELSE IF (@ValueString = 'LohntypCode')
  BEGIN
    ---------------------------------------------------------------------------
    -- LohntypCode:
    ---------------------------------------------------------------------------
    -- init vars
    DECLARE @LohntypCode INT;
    
    -- get value
    SELECT TOP 1 @LohntypCode = HUS.LohntypCode
    FROM dbo.Hist_XUser HUS WITH (READUNCOMMITTED)
      INNER JOIN dbo.HistoryVersion VER WITH (READUNCOMMITTED) ON VER.VerID = HUS.VerID
    WHERE HUS.UserID = @UserID 
      AND DATEADD(d, 0, DATEDIFF(d, 0, VER.VersionDate)) <= @Date
    ORDER BY VER.VersionDate DESC, VER.VerID DESC;
    
    -- return value
    RETURN @LohntypCode;
    ---------------------------------------------------------------------------
  END
  ELSE IF (@ValueString = 'KeinBDEExport')
  BEGIN
  
    ---------------------------------------------------------------------------
    -- KeinBDEExport:
    ---------------------------------------------------------------------------
    -- init vars
    DECLARE @KeinBDEExport BIT;
    
    -- get value
    SELECT TOP 1 @KeinBDEExport = HUS.KeinBDEExport
    FROM dbo.Hist_XUser HUS WITH (READUNCOMMITTED)
      INNER JOIN dbo.HistoryVersion VER WITH (READUNCOMMITTED) ON VER.VerID = HUS.VerID
    WHERE HUS.UserID = @UserID 
      AND DATEADD(d, 0, DATEDIFF(d, 0, VER.VersionDate)) <= @Date
    ORDER BY VER.VersionDate DESC, VER.VerID DESC;
    
    -- return value
    RETURN @KeinBDEExport;    
  
  END
  
  -----------------------------------------------------------------------------
  -- done, if we are here, something is wrong
  -----------------------------------------------------------------------------
  RETURN NULL;
END;
GO
