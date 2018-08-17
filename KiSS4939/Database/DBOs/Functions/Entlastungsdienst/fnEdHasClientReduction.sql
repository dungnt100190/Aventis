SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnEdHasClientReduction;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Entlastungsdienst/fnEdHasClientReduction.sql $
  $Author: Cjaeggi $
  $Modtime: 22.12.09 11:55 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to check if client has specific Ed reduction assigned for given id.
           This way we can prevent joining table and having the EdReduktionID spread in code.
    @EdEinsatzvereinbarungID: The id of the entry used for checking reduction assignment
    @Reduction:               The reduction to check (used to prevent having the EdReduktionID used)
                              - 'insieme':  used for "Mitglied insieme"
                              - 'cerebral': used for "Mitglied cerebral"
                              - 'brantomy': used for "Reduktion Brantomy"
  -
  RETURNS: 1 if client has specific reduction assigned for given EdEinsatzvereinbarungID, otherwise 0
  -
  TEST:    SELECT dbo.fnEdHasClientReduction(487, 'insieme')
           SELECT dbo.fnEdHasClientReduction(487, 'cerebral')
           SELECT dbo.fnEdHasClientReduction(487, 'brantomy')
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Entlastungsdienst/fnEdHasClientReduction.sql $
 * 
 * 1     22.12.09 11:57 Cjaeggi
 * #5185: Added function
 * 
 * 1     17.11.09 10:20 Cjaeggi
=================================================================================================*/

CREATE FUNCTION dbo.fnEdHasClientReduction
(
  @EdEinsatzvereinbarungID INT,
  @Reduction VARCHAR(50)
)
RETURNS BIT
AS BEGIN
  -----------------------------------------------------------------------------
  -- check assignment
  -----------------------------------------------------------------------------
  IF (EXISTS(SELECT TOP 1 1
             FROM dbo.EdEinsatzvereinbarung_EdReduktion EER WITH (READUNCOMMITTED)
             WHERE EER.EdEinsatzvereinbarungID = ISNULL(@EdEinsatzvereinbarungID, -1)
               AND EER.EdReduktionID = CASE @Reduction
                                         WHEN 'insieme' THEN 1  -- Mitglied insieme
                                         WHEN 'cerebral' THEN 2 -- Mitglied Cerebral
                                         WHEN 'brantomy' THEN 3 -- Reduktion Brantomy
                                         ELSE -1
                                       END))
  BEGIN
    -- client has reduction assigned for given id
    RETURN 1;
  END
  ELSE
  BEGIN
    -- reduction is not assigned for given id
    RETURN 0;
  END;
  
  -----------------------------------------------------------------------------
  -- if we are here, something was wrong
  -----------------------------------------------------------------------------
  RETURN 0;
END;
GO
