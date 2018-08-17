/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: use this script to alter Kes-tables
=================================================================================================*/


-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- step 1: KesMassnahme
-------------------------------------------------------------------------------

--IsDeleted
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMassnahme')
             AND C.name = 'IsDeleted'))
BEGIN
  PRINT ('Info: Die Spalte IsDeleted ist auf KesMassnahme bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMassnahme ADD IsDeleted bit NOT NULL CONSTRAINT DF_KesMassnahme_IsDeleted DEFAULT 0
  PRINT ('Info: Spalte KesMassnahme.IsDeleted wurde hinzugefügt');
END;

--FuersorgerischeUnterbringung
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMassnahme')
             AND C.name = 'FuersorgerischeUnterbringung'))
BEGIN
  PRINT ('Info: Die Spalte FuersorgerischeUnterbringung ist auf KesMassnahme bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMassnahme ADD FuersorgerischeUnterbringung bit NOT NULL CONSTRAINT DF_KesMassnahme_FuersorgerischeUnterbringung DEFAULT 0
  PRINT ('Info: Spalte KesMassnahme.FuersorgerischeUnterbringung wurde hinzugefügt');
END;

--Platzierung_BaInstitutionID
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMassnahme')
             AND C.name = 'Platzierung_BaInstitutionID'))
BEGIN
  PRINT ('Info: Die Spalte Platzierung_BaInstitutionID ist auf KesMassnahme bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMassnahme ADD Platzierung_BaInstitutionID int NULL;

  CREATE NONCLUSTERED INDEX [IX_KesMassnahme_Platzierung_BaInstitutionID] ON [dbo].[KesMassnahme] 
  (
    [Platzierung_BaInstitutionID] ASC
  )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY];

  ALTER TABLE [dbo].[KesMassnahme]  WITH CHECK ADD  CONSTRAINT [FK_KesMassnahme_Platzierung_BaInstitutionID] FOREIGN KEY([Platzierung_BaInstitutionID])
  REFERENCES [dbo].[BaInstitution] ([BaInstitutionID]);

  ALTER TABLE [dbo].[KesMassnahme] CHECK CONSTRAINT [FK_KesMassnahme_Platzierung_BaInstitutionID]

  EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Platzierung in einer Institution (Fremdschlüssel FK_KesMassnahme_Platzierung_BaInstitutionID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'Platzierung_BaInstitutionID';

  PRINT ('Info: Spalte KesMassnahme.Platzierung_BaInstitutionID wurde hinzugefügt');
END;

--KesGrundlageCode
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMassnahme')
             AND C.name = 'KesGrundlageCode'))
BEGIN
  PRINT ('Info: Die Spalte KesGrundlageCode ist auf KesMassnahme bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMassnahme ADD KesGrundlageCode int NULL;

  EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Grundlage (LOV KesGrundlage)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahme', @level2type=N'COLUMN',@level2name=N'KesGrundlageCode'

  PRINT ('Info: Spalte KesMassnahme.KesGrundlageCode wurde hinzugefügt');
END;

GO

-------------------------------------------------------------------------------
-- step 2: KesMandatsfuehrendePerson
-------------------------------------------------------------------------------
-- IsDeleted
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMandatsfuehrendePerson')
             AND C.name = 'IsDeleted'))
BEGIN
  PRINT ('Info: Die Spalte IsDeleted ist auf KesMandatsfuehrendePerson bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMandatsfuehrendePerson ADD IsDeleted bit NOT NULL CONSTRAINT DF_KesMandatsfuehrendePerson_IsDeleted DEFAULT 0
  PRINT ('Info: Spalte KesMandatsfuehrendePerson.IsDeleted wurde hinzugefügt');
END;

-- DatumErnennungsurkunde
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMandatsfuehrendePerson')
             AND C.name = 'DatumErnennungsurkunde'))
BEGIN
  PRINT ('Info: Die Spalte DatumErnennungsurkunde ist auf KesMandatsfuehrendePerson bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMandatsfuehrendePerson ADD DatumErnennungsurkunde DATETIME NULL;
  EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Ernennungsurkunde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson', @level2type=N'COLUMN',@level2name=N'DatumErnennungsurkunde'

  PRINT ('Info: Spalte KesMandatsfuehrendePerson.DatumErnennungsurkunde wurde hinzugefügt');
END;


GO

-------------------------------------------------------------------------------
-- step 3: KesMassnahmeAuftrag
-------------------------------------------------------------------------------
-- IsDeleted
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMassnahmeAuftrag')
             AND C.name = 'IsDeleted'))
BEGIN
  PRINT ('Info: Die Spalte IsDeleted ist auf KesMassnahmeAuftrag bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMassnahmeAuftrag ADD IsDeleted bit NOT NULL CONSTRAINT DF_KesMassnahmeAuftrag_IsDeleted DEFAULT 0
  PRINT ('Info: Spalte KesMassnahmeAuftrag.IsDeleted wurde hinzugefügt');
END;

-- DatumVersand
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMassnahmeAuftrag')
             AND C.name = 'DatumVersand'))
BEGIN
  PRINT ('Info: Die Spalte DatumVersand ist auf KesMassnahmeAuftrag bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMassnahmeAuftrag ADD DatumVersand DATETIME NULL;
  EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Versand' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag', @level2type=N'COLUMN',@level2name=N'DatumVersand'

  PRINT ('Info: Spalte KesMassnahmeAuftrag.DatumVersand wurde hinzugefügt');
END;

GO

-------------------------------------------------------------------------------
-- step 4: KesMassnahmeBericht
-------------------------------------------------------------------------------
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMassnahmeBericht')
             AND C.name = 'IsDeleted'))
BEGIN
  PRINT ('Info: Die Spalte IsDeleted ist auf KesMassnahmeBericht bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMassnahmeBericht ADD IsDeleted bit NOT NULL CONSTRAINT DF_KesMassnahmeBericht_IsDeleted DEFAULT 0
  PRINT ('Info: Spalte KesMassnahmeBericht.IsDeleted wurde hinzugefügt');
END;

IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMassnahmeBericht')
             AND C.name = 'DatumVersand'))
BEGIN
  PRINT ('Info: Die Spalte DatumVersand ist auf KesMassnahmeBericht bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMassnahmeBericht ADD DatumVersand DATETIME NULL;

  EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Versands' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'DatumVersand'

  PRINT ('Info: Spalte KesMassnahmeBericht.DatumVersand wurde hinzugefügt');
END;

IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesMassnahmeBericht')
             AND C.name = 'DatumBelegeZurueck'))
BEGIN
  PRINT ('Info: Die Spalte DatumBelegeZurueck ist auf KesMassnahmeBericht bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesMassnahmeBericht ADD DatumBelegeZurueck DATETIME NULL;

  EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Belege zurück am' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeBericht', @level2type=N'COLUMN',@level2name=N'DatumBelegeZurueck'

  PRINT ('Info: Spalte KesMassnahmeBericht.DatumBelegeZurueck wurde hinzugefügt');
END;

GO


-------------------------------------------------------------------------------
-- step 5: KesDokument
-------------------------------------------------------------------------------
IF (EXISTS(SELECT TOP 1 1
           FROM sys.columns C
           WHERE c.object_id = OBJECT_ID('KesDokument')
             AND C.name = 'IsDeleted'))
BEGIN
  PRINT ('Info: Die Spalte IsDeleted ist auf KesDokument bereits vorhanden');
END
ELSE
BEGIN
  ALTER TABLE dbo.KesDokument ADD IsDeleted bit NOT NULL CONSTRAINT DF_KesDokument_IsDeleted DEFAULT 0
  PRINT ('Info: Spalte KesDokument.IsDeleted wurde hinzugefügt');
END;

GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO