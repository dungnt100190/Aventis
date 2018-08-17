/*===================================================================================================
  $Revision: 1 $
=====================================================================================================
  Description
-----------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to insert configuration for KBE-1493 (BackColor of barMainMenu in FrmMain)
=====================================================================================================*/
SET NOCOUNT ON;
GO

IF(N'{Env}' = N'Int')
BEGIN
EXEC dbo.spAddXConfig @KeyPath = 'System\GUI\MenubalkenRotEinfaerben',
                      @DatumVon = '20180101',
                      @ValueVar = 1,
                      @ValueCode = 5, 
                      @Description = NULL,
                      @OriginalValue = 0,
                      @System = 0
PRINT ('Info: Konfiguration für Menubalken auf Integration rot einfärben wurde angepasst.');
END

GO

SET NOCOUNT OFF;
GO