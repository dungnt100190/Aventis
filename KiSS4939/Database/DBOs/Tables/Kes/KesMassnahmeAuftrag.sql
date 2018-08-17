CREATE TABLE [dbo].[KesMassnahmeAuftrag](
	[KesMassnahmeAuftragID] [int] IDENTITY(1,1) NOT NULL,
	[KesMassnahmeID] [int] NOT NULL,
	[DocumentID_Beschluss] [int] NULL,
	[BeschlussVom] [datetime] NULL,
	[ErledigungBis] [datetime] NULL,
	[Auftrag] [varchar](max) NULL,
	[KesMassnahmeGeschaeftsartCode] [int] NULL,
	[DocumentID_Bericht] [int] NULL,
	[DocumentID_Versand] [int] NULL,
	[DatumVersand] [datetime] NULL,
	[DocumentID_VerfuegungKESB] [int] NULL,
	[DatumVerfuegungKESB] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KesMassnahmeAuftragTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KesMassnahmeAuftrag] PRIMARY KEY CLUSTERED 
(
	[KesMassnahmeAuftragID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_KesMassnahmeAuftrag_KesMassnahmeID] ON [dbo].[KesMassnahmeAuftrag] 
(
	[KesMassnahmeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag', @level2type=N'COLUMN',@level2name=N'KesMassnahmeAuftragID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KesMassnahmeAuftrag_KesMassnahme) => KesMassnahmeID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag', @level2type=N'COLUMN',@level2name=N'KesMassnahmeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument Beschluss' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag', @level2type=N'COLUMN',@level2name=N'DocumentID_Beschluss'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschlussdatum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag', @level2type=N'COLUMN',@level2name=N'BeschlussVom'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Erledigungsdatum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag', @level2type=N'COLUMN',@level2name=N'ErledigungBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Auftrag in Textform' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag', @level2type=N'COLUMN',@level2name=N'Auftrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV KesMassnahmeGeschaeftsart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag', @level2type=N'COLUMN',@level2name=N'KesMassnahmeGeschaeftsartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument Bericht/Antrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag', @level2type=N'COLUMN',@level2name=N'DocumentID_Bericht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument Versand' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag', @level2type=N'COLUMN',@level2name=N'DocumentID_Versand'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Versand' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag', @level2type=N'COLUMN',@level2name=N'DatumVersand'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dokument Verfügung KESB' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag', @level2type=N'COLUMN',@level2name=N'DocumentID_VerfuegungKESB'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Verfügung KESB' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag', @level2type=N'COLUMN',@level2name=N'DatumVerfuegungKESB'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag', @level2type=N'COLUMN',@level2name=N'KesMassnahmeAuftragTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Corinne Meuwly' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle zum Tab ''Auftrag'', welche der Massnahme angehängt ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Kes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KesMassnahmeAuftrag'
GO

ALTER TABLE [dbo].[KesMassnahmeAuftrag]  WITH CHECK ADD  CONSTRAINT [FK_KesMassnahmeAuftrag_KesMassnahme] FOREIGN KEY([KesMassnahmeID])
REFERENCES [dbo].[KesMassnahme] ([KesMassnahmeID])
GO

ALTER TABLE [dbo].[KesMassnahmeAuftrag] CHECK CONSTRAINT [FK_KesMassnahmeAuftrag_KesMassnahme]
GO

ALTER TABLE [dbo].[KesMassnahmeAuftrag] ADD  CONSTRAINT [DF_KesMassnahmeAuftrag_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[KesMassnahmeAuftrag] ADD  CONSTRAINT [DF_KesMassnahmeAuftrag_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KesMassnahmeAuftrag] ADD  CONSTRAINT [DF_KesMassnahmeAuftrag_Modified]  DEFAULT (getdate()) FOR [Modified]
GO