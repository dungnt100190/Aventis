CREATE TABLE [dbo].[VmInventar](
	[VmInventarID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[UserID] [int] NULL,
	[DocumentID] [int] NULL,
	[Eroeffnung] [datetime] NULL,
	[ErstKontakt] [datetime] NULL,
	[Mahnung] [datetime] NULL,
	[Genehmigung] [datetime] NULL,
	[Versand] [datetime] NULL,
	[InventarAufgenommen] [datetime] NULL,
	[Bemerkung] [varchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VmInventarTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmInventar] PRIMARY KEY CLUSTERED 
(
	[VmInventarID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_VmInventar_FaLeistungID] ON [dbo].[VmInventar] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_VmInventar_UserID] ON [dbo].[VmInventar] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmInventar', @level2type=N'COLUMN',@level2name=N'VmInventarID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zur Leistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmInventar', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zum Mitarbeiter' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmInventar', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zum Dokument' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmInventar', @level2type=N'COLUMN',@level2name=N'DocumentID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Eröffnung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmInventar', @level2type=N'COLUMN',@level2name=N'Eroeffnung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Erstkontakt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmInventar', @level2type=N'COLUMN',@level2name=N'ErstKontakt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Mahnung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmInventar', @level2type=N'COLUMN',@level2name=N'Mahnung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Genehmigung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmInventar', @level2type=N'COLUMN',@level2name=N'Genehmigung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Versand' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmInventar', @level2type=N'COLUMN',@level2name=N'Versand'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Inventar aufgenommen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmInventar', @level2type=N'COLUMN',@level2name=N'InventarAufgenommen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmInventar', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ob der Datensatz logisch gelöscht worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmInventar', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmInventar', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmInventar', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmInventar', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmInventar', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Adressrecords' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmInventar', @level2type=N'COLUMN',@level2name=N'VmInventarTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Claude Glauser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmInventar'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Vormundschaft Inventar' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmInventar'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Vormundschaft' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmInventar'
GO

ALTER TABLE [dbo].[VmInventar]  WITH CHECK ADD  CONSTRAINT [FK_VmInventar_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[VmInventar] CHECK CONSTRAINT [FK_VmInventar_FaLeistung]
GO

ALTER TABLE [dbo].[VmInventar]  WITH CHECK ADD  CONSTRAINT [FK_VmInventar_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[VmInventar] CHECK CONSTRAINT [FK_VmInventar_XUser]
GO

ALTER TABLE [dbo].[VmInventar] ADD  CONSTRAINT [DF_VmInventar_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[VmInventar] ADD  CONSTRAINT [DF_VmInventar_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[VmInventar] ADD  CONSTRAINT [DF_VmInventar_Modified]  DEFAULT (getdate()) FOR [Modified]
GO