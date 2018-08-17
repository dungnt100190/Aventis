CREATE TABLE [dbo].[FaPhase](
	[FaPhaseID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[UserID] [int] NULL,
	[FsDienstleistungspaketID_Zugewiesen] [int] NULL,
	[FsDienstleistungspaketID_Bedarf] [int] NULL,
	[FaPhaseCode] [int] NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[AbschlussGrundCode] [int] NULL,
	[Bemerkung] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FaPhaseTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaPhase] PRIMARY KEY CLUSTERED 
(
	[FaPhaseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_FaPhase_FaLeistungID] ON [dbo].[FaPhase] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_FaPhase_FsDienstleistungspaketID_Bedarf] ON [dbo].[FaPhase] 
(
	[FsDienstleistungspaketID_Bedarf] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_FaPhase_FsDienstleistungspaketID_Zugewiesen] ON [dbo].[FaPhase] 
(
	[FsDienstleistungspaketID_Zugewiesen] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_FaPhase_UserID] ON [dbo].[FaPhase] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für FaPhase Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaPhase', @level2type=N'COLUMN',@level2name=N'FaPhaseID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FaPhase_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaPhase', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FaPhase_XUser) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaPhase', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FaPhase_FsDienstleistungspaket) => FsDienstleistungspaket.FsDienstleistungspaketID. Rolle ist Zugewiesen (siehe auch Bedarf).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaPhase', @level2type=N'COLUMN',@level2name=N'FsDienstleistungspaketID_Zugewiesen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FaPhase_FsDienstleistungspaket) => FsDienstleistungspaket.FsDienstleistungspaketID. Rolle ist Bedarf (siehe auch Zugewiesen).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaPhase', @level2type=N'COLUMN',@level2name=N'FsDienstleistungspaketID_Bedarf'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Typ der Phase (LOV FaPhase)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaPhase', @level2type=N'COLUMN',@level2name=N'FaPhaseCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum VON der Phase' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaPhase', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum BIS der Phase' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaPhase', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Abschlussgrund der Phase (LOV AbschlussGrund)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaPhase', @level2type=N'COLUMN',@level2name=N'AbschlussGrundCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaPhase', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz angelegt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaPhase', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz angelegt wroden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaPhase', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt mutiert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaPhase', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt modifiziert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaPhase', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Records, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaPhase', @level2type=N'COLUMN',@level2name=N'FaPhaseTS'
GO

ALTER TABLE [dbo].[FaPhase]  WITH CHECK ADD  CONSTRAINT [FK_FaPhase_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[FaPhase] CHECK CONSTRAINT [FK_FaPhase_FaLeistung]
GO

ALTER TABLE [dbo].[FaPhase]  WITH CHECK ADD  CONSTRAINT [FK_FaPhase_FsDienstleistungspaket_Bedarf] FOREIGN KEY([FsDienstleistungspaketID_Bedarf])
REFERENCES [dbo].[FsDienstleistungspaket] ([FsDienstleistungspaketID])
GO

ALTER TABLE [dbo].[FaPhase] CHECK CONSTRAINT [FK_FaPhase_FsDienstleistungspaket_Bedarf]
GO

ALTER TABLE [dbo].[FaPhase]  WITH CHECK ADD  CONSTRAINT [FK_FaPhase_FsDienstleistungspaket_Zugewiesen] FOREIGN KEY([FsDienstleistungspaketID_Zugewiesen])
REFERENCES [dbo].[FsDienstleistungspaket] ([FsDienstleistungspaketID])
GO

ALTER TABLE [dbo].[FaPhase] CHECK CONSTRAINT [FK_FaPhase_FsDienstleistungspaket_Zugewiesen]
GO

ALTER TABLE [dbo].[FaPhase]  WITH CHECK ADD  CONSTRAINT [FK_FaPhase_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaPhase] CHECK CONSTRAINT [FK_FaPhase_XUser]
GO

ALTER TABLE [dbo].[FaPhase] ADD  CONSTRAINT [DF_FaPhase_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FaPhase] ADD  CONSTRAINT [DF_FaPhase_Modified]  DEFAULT (getdate()) FOR [Modified]
GO