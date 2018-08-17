/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to delete BaEinwohnerregisterEmpfangeneEreignisse to save space on disk
=================================================================================================*/


PRINT ('Info: Tabellen l�schen');
DROP TABLE log.BaEinwohnerregisterEmpfangeneEreignisse
GO


DROP TABLE log.BaEinwohnerregisterEmpfangeneEreignisseRohdaten
GO


PRINT ('Info: Tabellen neu erstellen');
{Include:BaEinwohnerregisterEmpfangeneEreignisseRohdaten}

GO

{Include:BaEinwohnerregisterEmpfangeneEreignisse}

GO

