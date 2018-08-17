{DISPATCHER}
/*===============================================================================================
  $Revision: 2$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to list all items which are used to migrate the BaPerson table.
=================================================================================================*/

Drop_vwKreditor_vwInstitution_vwPerson_DependingFNs  --drop vwPerson, vwKreditor...

--TODO: Richtige Changescripts referenzieren
R0000_0000_Mig__Hist_BaPerson
R0000_0000_Mig__BaPerson

Rxxxx_ZH_Reseed_BaPersonID:IFNSE=ZH -- only ZH
--Rxxxx_Drop_HistoryTrigger_BaPerson:IFNSE=ZH  -- only ZH --> wird in Rxxxx_2_PostReleaseDispatcher gemacht
vwKreditor_vwInstitution_vwPerson_DependingFNs  --re-create vwPerson, vwKreditor...
