SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnQryGetKantZuschuesseForBaPerson;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Query/fnQryGetKantZuschuesseForBaPerson.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:30 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get all assigned Kant.Zuschuesse for given BaPersonID as sorted 
           text-output
   @BaPersonID:   The id of the BaPerson to get Kant.Zuschuesse for it
   @LanguageCode: The language to use for output
  -
  RETURNS: The titles of all assigned Kant.Zuschuesse for given BaPersonID
  -
  TEST:    SELECT [dbo].[fnQryGetKantZuschuesseForBaPerson](1, 1) 
           SELECT [dbo].[fnQryGetKantZuschuesseForBaPerson](77923, 1) 
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Query/fnQryGetKantZuschuesseForBaPerson.sql $
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     28.01.09 13:53 Cjaeggi
 * Format changes
 * 
 * 1     28.01.09 13:52 Cjaeggi
 * New function
=================================================================================================*/

CREATE FUNCTION dbo.fnQryGetKantZuschuesseForBaPerson
(
  @BaPersonID INT,
  @LanguageCode INT
)
RETURNS VARCHAR(2000)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@BaPersonID IS NULL OR @LanguageCode IS NULL)
  BEGIN
    -- invalid value
    RETURN NULL
  END
  
  -----------------------------------------------------------------------------
  -- init temp table
  -----------------------------------------------------------------------------
  DECLARE @KantZuschuesse TABLE
  (
    BezeichnungML VARCHAR(255)
  )
  
  -----------------------------------------------------------------------------
  -- split csv-values to temp table
  -----------------------------------------------------------------------------
  INSERT INTO @KantZuschuesse
    SELECT BezeichnungML = dbo.fnGetMLTextByDefault(KZS.BezeichnungTID, @LanguageCode, KZS.Bezeichnung)
    FROM dbo.BaPerson_KantonalerZuschuss BKZ WITH (READUNCOMMITTED)
      INNER JOIN dbo.BaKantonalerZuschuss KZS WITH (READUNCOMMITTED) ON KZS.BaKantonalerZuschussID = BKZ.BaKantonalerZuschussID
    WHERE BKZ.BaPersonID = @BaPersonID
    ORDER BY BezeichnungML, KZS.BaKantonalerZuschussID
  
  -----------------------------------------------------------------------------
  -- convert to one varchar value
  -----------------------------------------------------------------------------
  -- init var
  DECLARE @ReturnValue VARCHAR(2000)
  
  -- do convert using cool function call with some xml stuff 
  -- (source: http://www.sqlservercurry.com/2008/06/combine-multiple-rows-into-one-row.html)
  SELECT DISTINCT 
         @ReturnValue = STUFF((SELECT ';' + BezeichnungML 
                               FROM @KantZuschuesse FOR XML PATH('')), 1, 1, '')
  FROM @KantZuschuesse
  
  -----------------------------------------------------------------------------
  -- done, return value
  -----------------------------------------------------------------------------
  RETURN @ReturnValue
END
