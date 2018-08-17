SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetHistKSTOrgUnitItemName;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/BDE/fnBDEGetHistKSTOrgUnitItemName.sql $
  $Author: Cjaeggi $
  $Modtime: 11.06.10 9:54 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Get cost center number with orgunit item name from history cost center value
    @HistKostenstelle: The number of the historical cost center value, used to get orgunit item
    @Date:             The date to use within history entries for finding matching entry
  -
  RETURNS: The cost center number including the orgunit item name matching in history.
           In case of invalid values, return default string as defined in dbo.fnCombineKSTOrgUnitItemName.
  -
  TEST:    SELECT dbo.fnBDEGetHistKSTOrgUnitItemName(160, GETDATE());
           SELECT dbo.fnBDEGetHistKSTOrgUnitItemName(160, '2009-01-01');
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/BDE/fnBDEGetHistKSTOrgUnitItemName.sql $
 * 
 * 1     11.06.10 9:55 Cjaeggi
 * #6108: Added new function
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetHistKSTOrgUnitItemName
(
  @HistKostenstelle INT,
  @Date DATETIME
)
RETURNS VARCHAR(150)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- init vars
  -----------------------------------------------------------------------------
  DECLARE @HistOrgUnitItemName VARCHAR(100);
  
  -----------------------------------------------------------------------------
  -- get history item name
  -----------------------------------------------------------------------------
  SELECT TOP 1 @HistOrgUnitItemName = HOU.ItemName
  FROM dbo.Hist_XOrgUnit HOU WITH (READUNCOMMITTED)
    INNER JOIN dbo.HistoryVersion VER WITH (READUNCOMMITTED) ON VER.VerID = HOU.VerID
  WHERE HOU.Kostenstelle = @HistKostenstelle 
    AND DATEADD(d, 0, DATEDIFF(d, 0, VER.VersionDate)) <= @Date
  ORDER BY VER.VersionDate DESC, VER.VerID DESC;
  
  -----------------------------------------------------------------------------
  -- done, return value from function call
  -----------------------------------------------------------------------------
  RETURN dbo.fnCombineKSTOrgUnitItemName(@HistKostenstelle, @HistOrgUnitItemName);
END;
GO
