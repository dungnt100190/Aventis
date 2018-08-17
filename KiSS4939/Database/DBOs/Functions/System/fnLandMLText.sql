SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnLandMLText;
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Get the translated name of a country from table BaLand
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
   @BaLandID:     The id of the country as defined in table BaLand
   @LanguageCode: The id of language to use (default is german)
  -
  RETURNS: The multilanguage name of the desired country or '' if none found
=================================================================================================
  TEST:    SELECT dbo.fnLandMLText(147, 1)
           SELECT dbo.fnLandMLText(147, 2)
=================================================================================================*/

CREATE FUNCTION dbo.fnLandMLText
(
  @BaLandID INT,
  @LanguageCode	INT
)
RETURNS VARCHAR(200) WITH SCHEMABINDING
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  SELECT @BaLandID     = ISNULL(@BaLandID, -1),      -- default is invalid number
         @LanguageCode = ISNULL(@LanguageCode, 1);   -- default is german
  
  -----------------------------------------------------------------------------
  -- init vars
  -----------------------------------------------------------------------------
  DECLARE @Text VARCHAR(200);
  
  -----------------------------------------------------------------------------
  -- get text from BaLand table
  -----------------------------------------------------------------------------
  SELECT @Text = ISNULL(CASE @LanguageCode 
                          WHEN 2 THEN LAN.TextFR    -- french
                          WHEN 3 THEN LAN.TextIT    -- italian
                          WHEN 4 THEN LAN.TextEN    -- english
                        END, LAN.Text)              -- german and any others
  FROM dbo.BaLand	LAN WITH (READUNCOMMITTED) 
  WHERE LAN.BaLandID = @BaLandID;
  
  -----------------------------------------------------------------------------
  -- done, return validated value
  -----------------------------------------------------------------------------
  RETURN ISNULL(@Text, '');
END;
GO