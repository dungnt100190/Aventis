{DISPATCHER}
/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to list all items which are used to migrate the XUser and Hist_XUser table.
=================================================================================================*/

Drop_vwKreditor_vwInstitution_vwPerson_DependingFNs  --drop vwPerson, vwKreditor...

--TODO: Richtiges Changescript referenzieren
R0000_0000_Mig__Hist_XUser -- Trigger auf XUser aus und einschalten
R0000_0000_Mig__XUser -- Trigger auf XUser löschen, aus und einschalten

vwKreditor_vwInstitution_vwPerson_DependingFNs  --re-create vwPerson, vwKreditor...
