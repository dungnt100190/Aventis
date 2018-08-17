CREATE TABLE [dbo].[GvDokumenteInformation](
	[GvDokumenteInformationID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[Information] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[GvDokumenteInformationTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_GvDokumenteInformation] PRIMARY KEY CLUSTERED 
(
	[GvDokumenteInformationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_GvDokumenteInformation_BaPersonID]    Script Date: 06/12/2013 16:43:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_GvDokumenteInformation_BaPersonID] ON [dbo].[GvDokumenteInformation] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvDokumenteInformation', @level2type=N'COLUMN',@level2name=N'GvDokumenteInformationID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf BaPerson (Unique Index: IX_GvDokumenteInformation_BaPersonID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvDokumenteInformation', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Informationstext' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvDokumenteInformation', @level2type=N'COLUMN',@level2name=N'Information'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvDokumenteInformation', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvDokumenteInformation', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvDokumenteInformation', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvDokumenteInformation', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvDokumenteInformation', @level2type=N'COLUMN',@level2name=N'GvDokumenteInformationTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvDokumenteInformation'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Information auf CtlFaFinanzgesuche' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvDokumenteInformation'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Fa,Gv' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvDokumenteInformation'
GO

ALTER TABLE [dbo].[GvDokumenteInformation]  WITH CHECK ADD  CONSTRAINT [FK_GvDokumenteInformation_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[GvDokumenteInformation] CHECK CONSTRAINT [FK_GvDokumenteInformation_BaPerson]
GO

ALTER TABLE [dbo].[GvDokumenteInformation] ADD  CONSTRAINT [DF_GvDokumenteInformation_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[GvDokumenteInformation] ADD  CONSTRAINT [DF_GvDokumenteInformation_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

