/*===============================================================================================
  $Revision: 2$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to verify that the DB has the same collation as the server.
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- Check collation
-------------------------------------------------------------------------------
DECLARE @ServerCollation VARCHAR(50);
DECLARE @DBCollation VARCHAR(50);

SELECT
  @ServerCollation = CONVERT(VARCHAR(50), SERVERPROPERTY('Collation')),
  @DBCollation = CONVERT(VARCHAR(50), DATABASEPROPERTYEX(DB_NAME(), 'Collation'));

IF (@ServerCollation != @DBCollation)
BEGIN
  PRINT ('Warning: Different Server/Database collation! Server: ' + @ServerCollation + ', Database: ' + @DBCollation);
END;
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
