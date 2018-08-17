{DISPATCHER}
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to include all required recurring scripts into dispatcher after
           running the change scripts!
=================================================================================================*/

-------------------------------------------------------------------------------
-- origin database
-------------------------------------------------------------------------------

-- use
Rxxxx_Use_Database

-- Set Db-Name (in X-Config Value)
Rxxxx_SetDbNameConfigValue

-- cleanup and fix (main-db)
Rxxxx_CleanUp_EmptyExtendedProperties
Rxxxx_Fix_ConstraintsNewWITHCHECK
Rxxxx_Restore_Delete_BaEinwohnerregisterEmpfangeneEreignisse:IFNSE=ZH&RESTORE

-- <customerfixes>
Rxxxx_PI_Fix_BSVBehinderungsartCode_Inconsistent:IFNSE=PI  -- only PI
Rxxxx_Drop_HistoryTrigger_BaPerson:IFNSE=ZH  -- only ZH
Rxxxx_Drop_HistoryTrigger_BaAdresse:IFNSE=ZH  -- only ZH
Rxxxx_Drop_HistoryTrigger_XUser:IFNSE=ZH  -- only ZH
Rxxxx_Drop_HistoryTrigger_XOrgUnit:IFNSE=ZH  -- only ZH
Rxxxx_Drop_HistoryTrigger_XOrgUnit_User:IFNSE=ZH  -- only ZH
-- </customerfixes>

-- re-create all views to prevent wrong output
Rxxxx_RebuildAllViewsDispatcher

-- recurring database objects
spXValidateDBO
spXExtendedProperty
spFaInsertFaFall:IFNSE=!PI
spDBO
TBL
LOV
USR

-- db-server-version
Rxxxx_Update_XDBServerVersion

-- settings
Rxxxx_Apply_DatabaseSettings
Rxxxx_KissUsersDefaultLanguage
Rxxxx_KBE-1493_Update_XConfig_Int:IFNSE=BSS

-------------------------------------------------------------------------------
-- document database
-------------------------------------------------------------------------------

-- use
Rxxxx_Use_DocDatabase:IFNSE=SepDocDB

-- cleanup and fix (doc-db)
Rxxxx_CleanUp_EmptyExtendedProperties:IFNSE=SepDocDB
Rxxxx_Fix_ConstraintsNewWITHCHECK:IFNSE=SepDocDB

-- settings
Rxxxx_Apply_DatabaseSettings:IFNSE=SepDocDB

-------------------------------------------------------------------------------
-- Anonymize
-------------------------------------------------------------------------------
Rxxxx_JUR_Anonymize:IFNSE=JUR

-------------------------------------------------------------------------------
-- Create users for each member of GF SOZ
-------------------------------------------------------------------------------
Rxxxx_Create_KiSS_TeamUsers:IFNSE=RESTORE

-------------------------------------------------------------------------------
-- security checks
-------------------------------------------------------------------------------
-- use
Rxxxx_Use_Database

-- !security checks!
Rxxxx_SecurityChecks
Rxxxx_ZH_SecurityChecks:IFNSE=ZH
Rxxxx_Update_XConfig_Omega:IFNSE=ZH&RESTORE

-------------------------------------------------------------------------------
-- optional backup
-------------------------------------------------------------------------------
--Rxxxx_Backup_Database_NextRelease:IFNSE=RESTORE
--Rxxxx_Backup_Database_KiSS5:IFNSE=BACKUP

-------------------------------------------------------------------------------
-- origin database
-------------------------------------------------------------------------------
-- use
Rxxxx_Use_Database

-------------------------------------------------------------------------------
-- print the content of log.UserSession to the output
-------------------------------------------------------------------------------
Rxxxx_Select_UserSession:IFNSE=!BSS&!ZH&!PI
