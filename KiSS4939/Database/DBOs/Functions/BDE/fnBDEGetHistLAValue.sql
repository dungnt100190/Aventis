SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetHistLAValue;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/BDE/fnBDEGetHistLAValue.sql $
  $Author: Cjaeggi $
  $Modtime: 11.06.10 11:07 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Get named history values for any LA as defined in history table
    @ValueString:       The name of the value to retrieve for given user id
                        - 'KTRStandard': The default KTR
    @BDELeistungsartID: The id of the LA to get value for
    @Date:              The date to use within history to get value
  -
  RETURNS: The history value depending on given parameters for given LA or NULL if no value found
           or invalid parameters given.
  -
  TEST:    SELECT dbo.fnBDEGetHistLAValue('KTRStandard', 158, GETDATE());
           SELECT dbo.fnBDEGetHistLAValue('KTRStandard', 158, '2009-01-01');
           SELECT dbo.fnBDEGetHistLAValue('KTRStandard', 158, '2007-01-01');
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/BDE/fnBDEGetHistLAValue.sql $
 * 
 * 1     11.06.10 11:07 Cjaeggi
 * #6108: Added new function
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetHistLAValue
(
  @ValueString VARCHAR(50),
  @BDELeistungsartID INT,
  @Date DATETIME
)
RETURNS SQL_VARIANT
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@ValueString NOT IN ('KTRStandard') 
   OR ISNULL(@BDELeistungsartID, -1) < 1
   OR @Date IS NULL)
  BEGIN
    -- invalid parameters, do not continue
    RETURN NULL;
  END;
  
  -----------------------------------------------------------------------------
  -- get value depending on requested string
  -----------------------------------------------------------------------------
  IF (@ValueString = 'KTRStandard')
  BEGIN
    ---------------------------------------------------------------------------
    -- KTRStandard:
    ---------------------------------------------------------------------------
    -- init vars
    DECLARE @KTRStandard VARCHAR(20);
    
    -- get value
    SELECT TOP 1 @KTRStandard = HLA.KTRStandard
    FROM dbo.Hist_BDELeistungsart HLA WITH (READUNCOMMITTED)
      INNER JOIN dbo.HistoryVersion VER WITH (READUNCOMMITTED) ON VER.VerID = HLA.VerID
    WHERE HLA.BDELeistungsartID = @BDELeistungsartID 
      AND DATEADD(d, 0, DATEDIFF(d, 0, VER.VersionDate)) <= @Date
    ORDER BY VER.VersionDate DESC, VER.VerID DESC;
    
    -- return value
    RETURN @KTRStandard;
    ---------------------------------------------------------------------------
  END;
  
  -----------------------------------------------------------------------------
  -- done, if we are here, something is wrong
  -----------------------------------------------------------------------------
  RETURN NULL;
END;
GO
