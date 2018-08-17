/*===============================================================================================
  $Revision: 2 
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to set diag_admin as BIAGAdmin.
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- check history version
-------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.tables
            WHERE name = 'Hist_XUser'))
BEGIN
  -- create new history entry if table is historised
  INSERT INTO dbo.HistoryVersion (AppUser) VALUES ('kiss_sys');
END;


-------------------------------------------------------------------------------
-- set diag_admin as BIAGAdmin
-------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1
            FROM sys.tables
            WHERE name = 'XUser'))
BEGIN
  -- set diag_admin as BIAGAdmin
  UPDATE USR 
    SET IsLocked = 0, IsUserAdmin = 1, IsUserBIAGAdmin = 1
  FROM XUser USR
  WHERE LogonName = 'diag_admin'
  
  -- info
  PRINT ('WARNING: Removed all passwords from table XUser!');
END;

GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
