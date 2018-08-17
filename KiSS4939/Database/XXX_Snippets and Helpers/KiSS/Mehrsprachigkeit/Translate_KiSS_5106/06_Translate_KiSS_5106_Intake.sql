/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Intake übersetzen
=================================================================================================*/
-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-- Intake ModulTree
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree MNU WHERE MaskName = 'Fa_Intake_Anmeldung' AND  Name = 'Anmeldung'       
EXEC spXSetXLangText @tid,1, 'Anmeldung',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Inscription',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE MaskName = 'Fa_Intake_Anmeldung' AND  Name = 'Anmeldung'
GO
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree MNU WHERE MaskName = 'Fa_Intake_Beratungsplan' AND  Name = 'Ausstattung'       
EXEC spXSetXLangText @tid,1, 'Ausstattung',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Inventaire',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE MaskName = 'Fa_Intake_Beratungsplan' AND  Name = 'Ausstattung'
GO
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree MNU WHERE MaskName = 'Fa_Intake_Zielvereinbarungen' AND  Name = 'Zielvereinbarungen'       
EXEC spXSetXLangText @tid,1, 'Zielvereinbarungen',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Accords Objectifs',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE MaskName = 'Fa_Intake_Zielvereinbarungen' AND  Name = 'Zielvereinbarungen'
GO
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree MNU WHERE MaskName = 'Fa_Intake_AuswertungKlient' AND  Name = 'Auswertung Prozess'       
EXEC spXSetXLangText @tid,1, 'Auswertung Prozess',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Processus d''évaluation',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE MaskName = 'Fa_Intake_AuswertungKlient' AND  Name = 'Auswertung Prozess'
GO
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree MNU WHERE MaskName = 'Fa_Intake_AuswertungZiele' AND  Name = 'Auswertung Ziele'       
EXEC spXSetXLangText @tid,1, 'Auswertung Ziele',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Evaluation des objectifs',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE MaskName = 'Fa_Intake_AuswertungZiele' AND  Name = 'Auswertung Ziele'
GO
DECLARE @tid AS INTEGER;         
SELECT TOP 1 @tid= NameTID FROM dbo.XModulTree MNU WHERE MaskName = 'Fa_Intake_KantonalesReporting' AND  Name = 'Ressourcenerschliessung'       
EXEC spXSetXLangText @tid,1, 'Ressourcenerschliessung',NULL,NULL,NULL,NULL,@tid out
EXEC spXSetXLangText @tid,2, 'Mise en valeur des ressources',NULL,NULL,NULL,NULL,@tid out
UPDATE dbo.XModulTree SET NameTID = @tid WHERE MaskName = 'Fa_Intake_KantonalesReporting' AND  Name = 'Ressourcenerschliessung'
GO

-- Add translation for intake tabs
EXEC spXSetMsgBox 1, 'Ressourcen','Fa_Intake_Beratungsplan','tabPage0',4,1
EXEC spXSetMsgBox 2, 'Ressources','Fa_Intake_Beratungsplan','tabPage0',4,1

EXEC spXSetMsgBox 1, 'Ressourcen 2','Fa_Intake_Beratungsplan','tabPage1',4,1
EXEC spXSetMsgBox 2, 'Ressources 2','Fa_Intake_Beratungsplan','tabPage1',4,1

EXEC spXSetMsgBox 1, 'Vertrag','Fa_Intake_Beratungsplan','tabPage2',4,1
EXEC spXSetMsgBox 2, 'Accord','Fa_Intake_Beratungsplan','tabPage2',4,1

EXEC spXSetMsgBox 1, 'Subsidiarität','Fa_Intake_Beratungsplan','tabPage3',4,1
EXEC spXSetMsgBox 2, 'Subsidiarité','Fa_Intake_Beratungsplan','tabPage3',4,1

EXEC spXSetMsgBox 1, 'Ziel','Fa_Intake_Zielvereinbarungen','tabPage0',4,1
EXEC spXSetMsgBox 2, 'Objectif','Fa_Intake_Zielvereinbarungen','tabPage0',4,1

EXEC spXSetMsgBox 1, 'Dienstleistungen','Fa_Intake_Zielvereinbarungen','tabPage1',4,1
EXEC spXSetMsgBox 2, 'Prestations','Fa_Intake_Zielvereinbarungen','tabPage1',4,1


-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO