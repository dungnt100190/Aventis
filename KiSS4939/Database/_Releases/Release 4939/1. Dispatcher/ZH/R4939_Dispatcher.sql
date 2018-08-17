{DISPATCHER}

/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to list all items to deploy for next release.
=================================================================================================*/

-- Cleanup migration tables
R4939_xxxx_Cleanup_OldMigrationTables

-------------------------------------------------------------------------------
-- release changes
-------------------------------------------------------------------------------

-------------------------------------------------------------------------------
--Achtung:
--In diesen Dispatcher sollten keine Changescripts eingetragen werden.
--Der 4.9.39 Release wurde bei ZH bereits als 4.9.33 Release installiert.
--Sollte trotzdem noch eine DB-Anpassung ausgeliefert werden, muss das mittels
--4.10.06 Dispatcher geschehen (ist ja im _Release41006-Verzeichnis schon vorbereitet).
-------------------------------------------------------------------------------
