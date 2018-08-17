{DISPATCHER}
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to include all required recurring scripts into dispatcher before
           running the other change scripts!
=================================================================================================*/

-------------------------------------------------------------------------------
-- optional internal restore scripts
-------------------------------------------------------------------------------
Rxxxx_Restore_PreReleaseDispatcher:IFNSE=RESTORE

-------------------------------------------------------------------------------
-- origin database
-------------------------------------------------------------------------------
-- use
Rxxxx_Use_Database

-- check prerequisites
Rxxxx_Check_Prerequisites_For_ReleaseScript

-- recurring scripts default database
Rxxxx_Update_DocumentHandling
Rxxxx_Update_AggregateFunc_x86_x64
Rxxxx_PI_Fix_RestoreOnlyDbUser:IFNSE=RESTORE&PI
Rxxxx_Apply_DatabaseUser
Rxxxx_Apply_BookmarkUser

-------------------------------------------------------------------------------
-- document database
-------------------------------------------------------------------------------
-- use
Rxxxx_Use_DocDatabase:IFNSE=SepDocDB

-- recurring scripts document database
Rxxxx_Apply_DatabaseUser:IFNSE=SepDocDB

-------------------------------------------------------------------------------
-- database objects
-------------------------------------------------------------------------------
-- use
Rxxxx_Use_Database

-- recurring database objects
spDropObject

-------------------------------------------------------------------------------
-- origin database
-------------------------------------------------------------------------------
-- use
Rxxxx_Use_Database