/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to drop the history trigger for BaAdresse.
=================================================================================================*/

IF EXISTS (SELECT TOP 1 1 FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trHist_BaAdresse]'))
BEGIN
  DROP TRIGGER dbo.trHist_BaAdresse;
END;
GO
