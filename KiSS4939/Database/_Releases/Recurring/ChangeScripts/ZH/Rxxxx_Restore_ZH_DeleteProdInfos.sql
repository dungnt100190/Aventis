/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to prod infos for ZH restore DBs. Steps copied from restore job.
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- Schnittstellen-Config-Werte ungültig setzen
-------------------------------------------------------------------------------
UPDATE dbo.XConfig
  SET DatumVon = CONVERT(DATETIME, '30000101')
WHERE KeyPath IN ('System\Schnittstellen\PSCD\PSCDNotificationWebServiceURL',
                  'System\Schnittstellen\PSCD\PSCDWebServiceURL',
                  'System\Schnittstellen\BackgroundWorkerService\BackgroundWorkerWebServiceURL',
                  'System\Allgemein\Benutzername_TechnischerBenutzer',
                  'System\Allgemein\Passwort_TechnischerBenutzer');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
