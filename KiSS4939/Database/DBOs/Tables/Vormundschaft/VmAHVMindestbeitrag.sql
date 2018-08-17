CREATE TABLE [dbo].[VmAHVMindestbeitrag](
	[VmAHVMindestbeitragID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[DocumentID_IKAuszug] [int] NULL,
	[DocumentID_Neutral] [int] NULL,
	[DocumentID_NEAnmeldung] [int] NULL,
	[IKAuszugDatum] [datetime] NULL,
	[BeitragsRechnungsJahr] [varchar](200) NULL,
	[Bruttolohn] [money] NULL,
	[NEAnmeldungDatum] [datetime] NULL,
	[VmQuartalCode] [int] NULL,
	[Bemerkungen] [varchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VmAHVMindestbeitragTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmAHVMindestbeitrag] PRIMARY KEY CLUSTERED 
(
	[VmAHVMindestbeitragID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_VmAHVMindestbeitrag_DocumentID_IKAuszug]    Script Date: 11/25/2010 11:41:55 ******/
CREATE NONCLUSTERED INDEX [IX_VmAHVMindestbeitrag_DocumentID_IKAuszug] ON [dbo].[VmAHVMindestbeitrag] 
(
	[DocumentID_IKAuszug] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_VmAHVMindestbeitrag_DocumentID_NEAnmeldung]    Script Date: 11/25/2010 11:41:55 ******/
CREATE NONCLUSTERED INDEX [IX_VmAHVMindestbeitrag_DocumentID_NEAnmeldung] ON [dbo].[VmAHVMindestbeitrag] 
(
	[DocumentID_NEAnmeldung] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_VmAHVMindestbeitrag_DocumentID_Neutral]    Script Date: 11/25/2010 11:41:55 ******/
CREATE NONCLUSTERED INDEX [IX_VmAHVMindestbeitrag_DocumentID_Neutral] ON [dbo].[VmAHVMindestbeitrag] 
(
	[DocumentID_Neutral] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_VmAHVMindestbeitrag_FaLeistungID]    Script Date: 11/25/2010 11:41:55 ******/
CREATE NONCLUSTERED INDEX [IX_VmAHVMindestbeitrag_FaLeistungID] ON [dbo].[VmAHVMindestbeitrag] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAHVMindestbeitrag', @level2type=N'COLUMN',@level2name=N'VmAHVMindestbeitragID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf FaLeistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAHVMindestbeitrag', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zum Document, Rolle IK Auszug' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAHVMindestbeitrag', @level2type=N'COLUMN',@level2name=N'DocumentID_IKAuszug'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zum Document, Rolle "Neutral"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAHVMindestbeitrag', @level2type=N'COLUMN',@level2name=N'DocumentID_Neutral'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zum Document, Rolle "NEAnmeldung"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAHVMindestbeitrag', @level2type=N'COLUMN',@level2name=N'DocumentID_NEAnmeldung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IK Auszug Datum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAHVMindestbeitrag', @level2type=N'COLUMN',@level2name=N'IKAuszugDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beitrags Rechnugns Jahr' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAHVMindestbeitrag', @level2type=N'COLUMN',@level2name=N'BeitragsRechnungsJahr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bruttolohn' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAHVMindestbeitrag', @level2type=N'COLUMN',@level2name=N'Bruttolohn'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'NE Anmeldung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAHVMindestbeitrag', @level2type=N'COLUMN',@level2name=N'NEAnmeldungDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAHVMindestbeitrag', @level2type=N'COLUMN',@level2name=N'Bemerkungen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ob der Datensatz logisch gelöscht worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAHVMindestbeitrag', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz angelegt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAHVMindestbeitrag', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz angelegt worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAHVMindestbeitrag', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt modifiziert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAHVMindestbeitrag', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt modifiziert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAHVMindestbeitrag', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Descripiton', @value=N'Timestamp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAHVMindestbeitrag', @level2type=N'COLUMN',@level2name=N'VmAHVMindestbeitragTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Claude Glauser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAHVMindestbeitrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'AHV Mindestbeträge im Modul vormundschaftliche Massnahmen, Administration' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAHVMindestbeitrag'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'Vormundschaft' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAHVMindestbeitrag'
GO

ALTER TABLE [dbo].[VmAHVMindestbeitrag]  WITH CHECK ADD  CONSTRAINT [FK_VmAHVMindestbeitrag_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[VmAHVMindestbeitrag] CHECK CONSTRAINT [FK_VmAHVMindestbeitrag_FaLeistung]
GO

ALTER TABLE [dbo].[VmAHVMindestbeitrag] ADD  CONSTRAINT [DF_VmAHVMindestbeitrag_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[VmAHVMindestbeitrag] ADD  CONSTRAINT [DF_VmAHVMindestbeitrag_Creator]  DEFAULT (getdate()) FOR [Creator]
GO

ALTER TABLE [dbo].[VmAHVMindestbeitrag] ADD  CONSTRAINT [DF_VmAHVMindestbeitrag_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[VmAHVMindestbeitrag] ADD  CONSTRAINT [DF_VmAHVMindestbeitrag_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


