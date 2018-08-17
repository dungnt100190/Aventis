/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to reseed the BaPersonID. Was a problem in #7999.
           Has to be done after every BaPerson table migration
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- step 1
-------------------------------------------------------------------------------
DECLARE @NextBaPersonID INT;

SELECT @NextBaPersonID = MAX(BaPersonID) + 1
FROM dbo.BaPerson
WHERE BaPersonID <> 499998; -- Stadt Z�rich (InvMDAS)

DBCC CHECKIDENT(BaPerson, RESEED, @NextBaPersonID)
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
