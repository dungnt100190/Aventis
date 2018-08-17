SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnEdGetEinsatzregionenFromCSV;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Entlastungsdienst/fnEdGetEinsatzregionenFromCSV.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:25 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to convert the csv-@EdEinsatzRegionIDs to text as csv
   @EdEinsatzRegionIDCVSCodes: The ids as csv to convert to text
   @LanguageCode:              The language to use for output
  -
  RETURNS: The names of the EdEinsatzRegionIDs with given language
  -
  TEST:    SELECT [dbo].[fnEdGetEinsatzregionenFromCSV]('4,5,6', 1)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Entlastungsdienst/fnEdGetEinsatzregionenFromCSV.sql $
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     28.01.09 13:54 Cjaeggi
 * 
 * 1     28.01.09 13:14 Cjaeggi
 * New function
=================================================================================================*/

CREATE FUNCTION dbo.fnEdGetEinsatzregionenFromCSV
(
  @EdEinsatzRegionIDCVSCodes VARCHAR(100),
  @LanguageCode INT
)
RETURNS VARCHAR(2000)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@EdEinsatzRegionIDCVSCodes IS NULL OR @LanguageCode IS NULL)
  BEGIN
    -- invalid value
    RETURN NULL
  END
  
  -----------------------------------------------------------------------------
  -- init temp table
  -----------------------------------------------------------------------------
  DECLARE @EdEinsatzRegions TABLE
  (
    BezeichnungML VARCHAR(255)
  )
  
  -----------------------------------------------------------------------------
  -- split csv-values to temp table
  -----------------------------------------------------------------------------
  INSERT INTO @EdEinsatzRegions
    SELECT BezeichnungML = dbo.fnGetMLTextByDefault(EDR.BezeichnungTID, @LanguageCode, EDR.Bezeichnung)
    FROM dbo.fnSplitStringToValues(@EdEinsatzRegionIDCVSCodes, ',', 1) FCN
      INNER JOIN dbo.EdEinsatzRegion EDR WITH (READUNCOMMITTED) ON EDR.EdEinsatzRegionID = CONVERT(INT, FCN.SplitValue)
    ORDER BY BezeichnungML, EdEinsatzRegionID
  
  -----------------------------------------------------------------------------
  -- convert to one varchar value
  -----------------------------------------------------------------------------
  -- init var
  DECLARE @ReturnValue VARCHAR(2000)
  
  -- do convert using cool function calls with some xml stuff 
  -- (source: http://www.sqlservercurry.com/2008/06/combine-multiple-rows-into-one-row.html)
  SELECT DISTINCT 
         @ReturnValue = STUFF((SELECT ';' + BezeichnungML 
                               FROM @EdEinsatzRegions FOR XML PATH('')), 1, 1, '')
  FROM @EdEinsatzRegions
  
  -----------------------------------------------------------------------------
  -- done, return value
  -----------------------------------------------------------------------------
  RETURN @ReturnValue
END
