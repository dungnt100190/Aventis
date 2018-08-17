/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to insert configuration for KBE-1519
=================================================================================================*/
SET NOCOUNT ON;
GO

----------------------------------------------------------------
-- Systemkonfiguration eintragen
----------------------------------------------------------------

EXEC dbo.spAddXConfig @KeyPath = 'System\Pendenzen\Person1\Aktiv',
                      @DatumVon = '20180101',
                      @ValueVar = 1,
                      @ValueCode = 5,
                      @Description = N'Wenn wahr wird AnzahlTage vor dem 1. Geburtstag an den zuständigen SAR (Modul F) eine Pendenz erstellt',
                      @OriginalValue = 1,
                      @System = 0

EXEC dbo.spAddXConfig @KeyPath = 'System\Pendenzen\Person1\AnzahlTage',
                      @DatumVon = '20180101',
                      @ValueVar = 30,
                      @ValueCode = 2,
                      @Description = N'Anzahl Tage vor dem 1. Geburtstag',
                      @OriginalValue = 30,
                      @System = 0

PRINT ('Info: Default-Konfiguration für Neue Pendenz: Kind wird 1-jährig erstellt.');
GO

SET NOCOUNT OFF;
GO
