/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to remove a certain checkbox from the EditMask of a Positionsart.
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- Calculate the bit to be unset.
-- @BitToUnSet contains all bits set to 1 except the one to be unset. Then we can apply AND operation to set the bit to 0.
-- We achieve this by setting the bit to be unset to 1 and invert all bits by applying the NOT operator.
-------------------------------------------------------------------------------

-- For example, we want to unset the 10th checkbox in the "Green Masterbudget" section:
-- "Gray Masterbudget" means the bits 0-11
-- "Green Masterbudget" means the bits 12-31
-- The 10th checkbox represents the 9th bit in the section
-- Hence: the 10th checkbox in the "Green Masterbudget" section is the 12 + (10 - 1) = 21th bit

DECLARE @BitToUnset INT;
SET @BitToUnset = ~POWER(2, 21);

-------------------------------------------------------------------------------
-- Update the EditMask on every Wohnkosten-Ausgabe-Positionsart
-------------------------------------------------------------------------------
UPDATE BgPositionsart 
SET Masterbudget_EditMask &= @BitToUnset 
WHERE 1 <> 1 --Don't perform the update, as it is just an example!
  AND BgGruppeCode = 3206 --3206: Wohnkosten
  AND BgKategorieCode = 2 --2: Ausgaben
  AND ModulID = 3
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
