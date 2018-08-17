/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to perform security check before installing release script.
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 5 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- check 1: check that current identity for BaPerson ist < 500'000
-------------------------------------------------------------------------------
DECLARE @NextBaPersonID INT;
DECLARE @ErrorMessage VARCHAR(MAX);

SET @NextBaPersonID = IDENT_CURRENT('BaPerson');
IF (@NextBaPersonID >= 499000)
BEGIN
  -- setup error message
  -- setup error message
  SET @ErrorMessage = 'Prerequisites-Check fehlgeschlagen: BaPerson: IDENT_CURRENT >= 499000! (IDENT_CURRENT:' + CONVERT(VARCHAR,@NextBaPersonID) + '). ReleaseScript kann nicht ausgeführt werden. Abhilfe: Mittels "DBCC CHECKIDENT(BaPerson, RESEED, <Neuer Wert für BaPersonID>)" Seed korrigieren und ReleaseScript erneut ausführen.';
  
  -- show error message
  RAISERROR(@ErrorMessage, 20, -1) WITH LOG;
END

GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
