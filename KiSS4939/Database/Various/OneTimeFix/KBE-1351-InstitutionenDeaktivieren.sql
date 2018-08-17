/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Institutionen von der Liste deaktivieren

   Formel in der Exceldokument : =WENN(A3="Ja";VERKETTEN("UPDATE dbo.BaInstitution SET Aktiv = 0 WHERE BaInstitutionID = ";B3; "; PRINT 'BaInstitutionID=";B3;" wurde deaktiviert';");"")
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

/*Update-Statements hierhin kopieren*/
UPDATE dbo.BaInstitution SET Aktiv = 0 WHERE BaInstitutionID = 503571; PRINT 'BaInstitutionID=503571 wurde deaktiviert';
UPDATE dbo.BaInstitution SET Aktiv = 0 WHERE BaInstitutionID = 503578; PRINT 'BaInstitutionID=503578 wurde deaktiviert';
UPDATE dbo.BaInstitution SET Aktiv = 0 WHERE BaInstitutionID = 503588; PRINT 'BaInstitutionID=503588 wurde deaktiviert';



-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO
