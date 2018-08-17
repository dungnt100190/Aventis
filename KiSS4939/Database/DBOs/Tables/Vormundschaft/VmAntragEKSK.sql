CREATE TABLE [dbo].[VmAntragEKSK](
	[VmAntragEKSKID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[UserID] [int] NULL,
	[DocumentID] [int] NULL,
	[Antrag] [varchar](max) NULL,
	[Begruendung] [varchar](max) NULL,
	[DatumAntrag] [datetime] NULL,
	[DatumGenehmigtEKSK] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Titel] [varchar](255) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VmAntragEKSKTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmAntragEKSK] PRIMARY KEY CLUSTERED 
(
	[VmAntragEKSKID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_VmAntragEKSK_DocumentID] ON [dbo].[VmAntragEKSK] 
(
	[DocumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_VmAntragEKSK_FaLeistungsID] ON [dbo].[VmAntragEKSK] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_VmAntragEKSK_UserId] ON [dbo].[VmAntragEKSK] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel von VmAntragEKSK' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAntragEKSK', @level2type=N'COLUMN',@level2name=N'VmAntragEKSKID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf die Leistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAntragEKSK', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fredmschlüssel auf XDocument' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAntragEKSK', @level2type=N'COLUMN',@level2name=N'DocumentID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text des Antrages' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAntragEKSK', @level2type=N'COLUMN',@level2name=N'Antrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Begründung des Antrages' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAntragEKSK', @level2type=N'COLUMN',@level2name=N'Begruendung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Antrages' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAntragEKSK', @level2type=N'COLUMN',@level2name=N'DatumAntrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Genehmigung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAntragEKSK', @level2type=N'COLUMN',@level2name=N'DatumGenehmigtEKSK'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag für das logisches Löschen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAntragEKSK', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Titel des Antrages' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAntragEKSK', @level2type=N'COLUMN',@level2name=N'Titel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz  erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAntragEKSK', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAntragEKSK', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAntragEKSK', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAntragEKSK', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für optimistic Locking' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAntragEKSK', @level2type=N'COLUMN',@level2name=N'VmAntragEKSKTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Nicolas Weber' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAntragEKSK'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Um Anträge EKSK in Vormundschaftliche Massnahme zu handeln' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmAntragEKSK'
GO

ALTER TABLE [dbo].[VmAntragEKSK]  WITH CHECK ADD  CONSTRAINT [FK_VmAntragEKSK_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[VmAntragEKSK] CHECK CONSTRAINT [FK_VmAntragEKSK_FaLeistung]
GO

ALTER TABLE [dbo].[VmAntragEKSK]  WITH CHECK ADD  CONSTRAINT [FK_VmAntragEKSK_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[VmAntragEKSK] CHECK CONSTRAINT [FK_VmAntragEKSK_XUser]
GO

ALTER TABLE [dbo].[VmAntragEKSK] ADD  CONSTRAINT [DF_VmAntragEKSK_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[VmAntragEKSK] ADD  CONSTRAINT [DF_VmAntragEKSK_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[VmAntragEKSK] ADD  CONSTRAINT [DF_VmAntragEKSK_Modified]  DEFAULT (getdate()) FOR [Modified]
GO