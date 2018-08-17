CREATE TABLE [dbo].[IkAbklaerung](
	[IkAbklaerungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[UserID] [int] NULL,
	[IkAbklaerungArtCode] [int] NULL,
	[IkAbklaerungAuswertungCode] [int] NULL,
	[DatumAbklaerung] [datetime] NULL,
	[DatumAuswertung] [datetime] NULL,
	[Bemerkung] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[IkAbklaerungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_IkAbklaerung] PRIMARY KEY CLUSTERED 
(
	[IkAbklaerungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_IkAbklaerung_FaLeistungID]    Script Date: 09/26/2012 17:27:30 ******/
CREATE NONCLUSTERED INDEX [IX_IkAbklaerung_FaLeistungID] ON [dbo].[IkAbklaerung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_IkAbklaerung_UserID]    Script Date: 09/26/2012 17:27:30 ******/
CREATE NONCLUSTERED INDEX [IX_IkAbklaerung_UserID] ON [dbo].[IkAbklaerung] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkAbklaerung', @level2type=N'COLUMN',@level2name=N'IkAbklaerungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf FaLeistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkAbklaerung', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf XUser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkAbklaerung', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Art der Abklärung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkAbklaerung', @level2type=N'COLUMN',@level2name=N'IkAbklaerungArtCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Art der Auswertung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkAbklaerung', @level2type=N'COLUMN',@level2name=N'IkAbklaerungAuswertungCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Das Stichdatum der Abklärung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkAbklaerung', @level2type=N'COLUMN',@level2name=N'DatumAbklaerung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Das Stichdatum der Auswertung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkAbklaerung', @level2type=N'COLUMN',@level2name=N'DatumAuswertung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Eine Bemerkung zur Auswertung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkAbklaerung', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkAbklaerung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkAbklaerung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkAbklaerung', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkAbklaerung', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkAbklaerung', @level2type=N'COLUMN',@level2name=N'IkAbklaerungTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkAbklaerung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle für die Inkasso-Art Abklärung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkAbklaerung'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Inkasso' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkAbklaerung'
GO

ALTER TABLE [dbo].[IkAbklaerung]  WITH CHECK ADD  CONSTRAINT [FK_IkAbklaerung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[IkAbklaerung] CHECK CONSTRAINT [FK_IkAbklaerung_FaLeistung]
GO

ALTER TABLE [dbo].[IkAbklaerung]  WITH CHECK ADD  CONSTRAINT [FK_IkAbklaerung_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[IkAbklaerung] CHECK CONSTRAINT [FK_IkAbklaerung_XUser]
GO

ALTER TABLE [dbo].[IkAbklaerung] ADD  CONSTRAINT [DF_IkAbklaerung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[IkAbklaerung] ADD  CONSTRAINT [DF_IkAbklaerung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

