CREATE TABLE [dbo].[KesMandatsfuehrendePerson](
	[KesMandatsfuehrendePersonID] [int] IDENTITY(1,1) NOT NULL,
	[KesMassnahmeID] [int] NOT NULL,
	[DatumMandatVon] [datetime] NULL,
	[DatumMandatBis] [datetime] NULL,
	[DocumentID_Ernennungsurkunde] [int] NULL,
	[DatumErnennungsurkunde] [datetime] NULL,
	[UserID] [int] NULL,
	[BaInstitutionID] [int] NULL,
	[KesBeistandsartCode] [int] NULL,
	[DatumVorgeschlagenAm] [datetime] NULL,
	[DatumRechnungsfuehrungVon] [datetime] NULL,
	[DatumRechnungsfuehrungBis] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KesMandatsfuehrendePersonTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KesMandatsfuehrendePerson] PRIMARY KEY CLUSTERED 
(
	[KesMandatsfuehrendePersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_KesMandatsfuehrendePerson_KesMassnahmeID] ON [dbo].[KesMandatsfuehrendePerson] 
(
	[KesMassnahmeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_KesMandatsfuehrendePerson_UserID] ON [dbo].[KesMandatsfuehrendePerson] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel KesMandatsfuehrendePerson' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson', @level2type=N'COLUMN',@level2name=N'KesMandatsfuehrendePersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zur Tabelle KesMassnahme' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson', @level2type=N'COLUMN',@level2name=N'KesMassnahmeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mandat von Datum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson', @level2type=N'COLUMN',@level2name=N'DatumMandatVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mandat bis Datum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson', @level2type=N'COLUMN',@level2name=N'DatumMandatBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument der Ernennungsurkunde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson', @level2type=N'COLUMN',@level2name=N'DocumentID_Ernennungsurkunde'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Ernennungsurkunde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson', @level2type=N'COLUMN',@level2name=N'DatumVorgeschlagenAm'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'UserID der mandatsführenden Person' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BaInstitutionID der mandatsführenden Fachperson' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beistandsart der mandatsführenden Person' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson', @level2type=N'COLUMN',@level2name=N'KesBeistandsartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum von SD vorgeschlagen am' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson', @level2type=N'COLUMN',@level2name=N'DatumVorgeschlagenAm'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Rechnungsführung durch SD vom' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson', @level2type=N'COLUMN',@level2name=N'DatumRechnungsfuehrungVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Rechnungsführung durch SD bis' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson', @level2type=N'COLUMN',@level2name=N'DatumRechnungsfuehrungBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson', @level2type=N'COLUMN',@level2name=N'KesMandatsfuehrendePersonTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Corinne Meuwly' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle zum Tab ''Mandatsführende Person'' welche der Massnahme angehängt ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMandatsfuehrendePerson'
GO

ALTER TABLE [dbo].[KesMandatsfuehrendePerson]  WITH CHECK ADD  CONSTRAINT [FK_KesMandatsfuehrendePerson_KesMassnahme] FOREIGN KEY([KesMassnahmeID])
REFERENCES [dbo].[KesMassnahme] ([KesMassnahmeID])
GO

ALTER TABLE [dbo].[KesMandatsfuehrendePerson] CHECK CONSTRAINT [FK_KesMandatsfuehrendePerson_KesMassnahme]
GO

ALTER TABLE [dbo].[KesMandatsfuehrendePerson]  WITH CHECK ADD  CONSTRAINT [FK_KesMandatsfuehrendePerson_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[KesMandatsfuehrendePerson] CHECK CONSTRAINT [FK_KesMandatsfuehrendePerson_XUser]
GO

ALTER TABLE [dbo].[KesMandatsfuehrendePerson]  WITH CHECK ADD  CONSTRAINT [FK_KesMandatsfuehrendePerson_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[KesMandatsfuehrendePerson] CHECK CONSTRAINT [FK_KesMandatsfuehrendePerson_BaInstitution]
GO

ALTER TABLE [dbo].[KesMandatsfuehrendePerson] ADD  CONSTRAINT [DF_KesMandatsfuehrendePerson_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[KesMandatsfuehrendePerson] ADD  CONSTRAINT [DF_KesMandatsfuehrendePerson_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KesMandatsfuehrendePerson] ADD  CONSTRAINT [DF_KesMandatsfuehrendePerson_Modified]  DEFAULT (getdate()) FOR [Modified]
GO