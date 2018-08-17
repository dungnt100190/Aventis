CREATE TABLE [dbo].[FaAbklaerung](
	[FaAbklaerungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[UserID] [int] NULL,
	[CoUserID] [int] NULL,
	[AuftragDatum] [datetime] NULL,
	[AusloeserCode] [int] NULL,
	[AbklaerungsberichtBeendetDatum] [datetime] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FaAbklaerungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaAbklaerung] PRIMARY KEY CLUSTERED 
(
	[FaAbklaerungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_FaAbklaerung_BaPersonID] ON [dbo].[FaAbklaerung] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_FaAbklaerung_FaLeistungID] ON [dbo].[FaAbklaerung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_FaAbklaerung_UserID] ON [dbo].[FaAbklaerung] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAbklaerung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAbklaerung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAbklaerung', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAbklaerung', @level2type=N'COLUMN',@level2name=N'Modified'
GO

ALTER TABLE [dbo].[FaAbklaerung]  WITH CHECK ADD  CONSTRAINT [FK_FaAbklaerung_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[FaAbklaerung] CHECK CONSTRAINT [FK_FaAbklaerung_BaPerson]
GO

ALTER TABLE [dbo].[FaAbklaerung]  WITH CHECK ADD  CONSTRAINT [FK_FaAbklaerung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[FaAbklaerung] CHECK CONSTRAINT [FK_FaAbklaerung_FaLeistung]
GO

ALTER TABLE [dbo].[FaAbklaerung]  WITH CHECK ADD  CONSTRAINT [FK_FaAbklaerung_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaAbklaerung] CHECK CONSTRAINT [FK_FaAbklaerung_XUser]
GO

ALTER TABLE [dbo].[FaAbklaerung]  WITH CHECK ADD  CONSTRAINT [FK_FaAbklaerung_XUser_CoUserID] FOREIGN KEY([CoUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaAbklaerung] CHECK CONSTRAINT [FK_FaAbklaerung_XUser_CoUserID]
GO

ALTER TABLE [dbo].[FaAbklaerung] ADD  CONSTRAINT [DF_FaAbklaerung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FaAbklaerung] ADD  CONSTRAINT [DF_FaAbklaerung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


