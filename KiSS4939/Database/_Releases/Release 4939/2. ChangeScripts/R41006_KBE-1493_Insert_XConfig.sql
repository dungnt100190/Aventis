/*===================================================================================================
  $Revision: 1 $
=====================================================================================================
  Description
-----------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to insert configuration for KBE-1493 (BackColor of barMainMenu in FrmMain)
=====================================================================================================*/
SET NOCOUNT ON;
GO


EXEC dbo.spAddXConfig @KeyPath = 'System\GUI\MenubalkenRotEinfaerben',
                      @DatumVon = '20180101',
                      @ValueVar = 0,
                      @ValueCode = 5, 
                      @Description = NULL,
                      @OriginalValue = 0,
                      @System = 0

PRINT ('Info: Konfiguration für Menubalken rot einfärben erstellt.');
GO

SET NOCOUNT OFF;
GO