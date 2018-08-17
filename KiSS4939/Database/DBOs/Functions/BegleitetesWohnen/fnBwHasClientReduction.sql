SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBwHasClientReduction;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BegleitetesWohnen/fnBwHasClientReduction.sql $
  $Author: Cjaeggi $
  $Modtime: 17.11.09 8:11 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to check if client has specific Bw reduction assigned for given id.
           This way we can prevent joining table and having the BwReduktionID spread in code.
    @BwEinsatzvereinbarungID: The id of the entry used for checking reduction assignment
    @Reduction:               The reduction to check (used to prevent having the BwReduktionID used)
                              - 'insieme':  used for "Mitglied insieme"
                              - 'cerebral': used for "Mitglied cerebral"
                              - 'brantomy': used for "Reduktion Brantomy"
  -
  RETURNS: 1 if client has specific reduction assigned for given BwEinsatzvereinbarungID, otherwise 0
  -
  TEST:    SELECT dbo.fnBwHasClientReduction(487, 'insieme')
           SELECT dbo.fnBwHasClientReduction(487, 'cerebral')
           SELECT dbo.fnBwHasClientReduction(487, 'brantomy')
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BegleitetesWohnen/fnBwHasClientReduction.sql $
 * 
 * 1     17.11.09 10:20 Cjaeggi
=================================================================================================*/

CREATE FUNCTION dbo.fnBwHasClientReduction
(
  @BwEinsatzvereinbarungID INT,
  @Reduction VARCHAR(50)
)
RETURNS BIT
AS BEGIN
  -----------------------------------------------------------------------------
  -- check assignment
  -----------------------------------------------------------------------------
  IF (EXISTS(SELECT TOP 1 1
             FROM dbo.BwEinsatzvereinbarung_BwReduktion BER WITH (READUNCOMMITTED)
             WHERE BER.BwEinsatzvereinbarungID = ISNULL(@BwEinsatzvereinbarungID, -1)
               AND BER.BwReduktionID = CASE @Reduction
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
