﻿{DISPATCHER}
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to list all items to deploy for next release.

  ACHTUNG: Release-Scripts nicht hier sondern in R4xxx_Dispatcher einfügen!
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-recurring items (insert in every dispatcher!)
-------------------------------------------------------------------------------
Rxxxx_1_PreReleaseDispatcher

-------------------------------------------------------------------------------
-- KiSS4-Changes-Dispatcher
-------------------------------------------------------------------------------
R4939_Dispatcher

-------------------------------------------------------------------------------
-- common work
-------------------------------------------------------------------------------
R4939_xxxx_Add_NewDBVersion

-------------------------------------------------------------------------------
-- post-recurring items (insert in every dispatcher!)
-------------------------------------------------------------------------------
Rxxxx_2_PostReleaseDispatcher
