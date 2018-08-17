{DISPATCHER}
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Include this script in every dispatcher to enable restore databases from teamcity
           build tasks
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- handle pre-restore tasks
-------------------------------------------------------------------------------------------------
Rxxxx_Restore_Disable_CDC_OnDatabase:IFNSE=RESTORE

-------------------------------------------------------------------------------------------------
-- handle restore
-------------------------------------------------------------------------------------------------
-- include restore scripts in case of matching NSE
Rxxxx_Restore_Database:IFNSE=RESTORE
Rxxxx_Restore_DocDatabase:IFNSE=RESTORE&SepDocDB

-------------------------------------------------------------------------------------------------
-- ZH specific: Change Prod informations
-------------------------------------------------------------------------------------------------
Rxxxx_Use_Database:IFNSE=RESTORE&ZH
Rxxxx_Restore_ZH_DeleteProdInfos:IFNSE=RESTORE&ZH

-------------------------------------------------------------------------------------------------
-- remove passwords on restore
-------------------------------------------------------------------------------------------------
-- we need to switch to current database
Rxxxx_Use_Database

-- remove passwords on XUser table
Rxxxx_Restore_XUserRemovePasswords:IFNSE=RESTORE
Rxxxx_Restore_EnableBiagAdmin:IFNSE=RESTORE

-- for security purpose, switch back to origin database
Rxxxx_Use_Database