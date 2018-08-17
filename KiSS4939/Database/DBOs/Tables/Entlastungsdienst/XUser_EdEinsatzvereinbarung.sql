CREATE TABLE [dbo].[XUser_EdEinsatzvereinbarung](
	[XUser_EdEinsatzvereinbarungID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[EdEinsatzvereinbarungID] [int] NOT NULL,
	[SortKey] [int] NOT NULL,
	[Bemerkungen] [varchar](2000) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[XUser_EdEinsatzvereinbarungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XUser_EdEinsatzvereinbarung] PRIMARY KEY CLUSTERED 
(
	[XUser_EdEinsatzvereinbarungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_XUser_EdEinsatzvereinbarung_UserID_EdEinsatzvereinbarungID] UNIQUE NONCLUSTERED 
(
	[UserID] ASC,
	[EdEinsatzvereinbarungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_XUser_EdEinsatzvereinbarung_EdEinsatzvereinbarungID] ON [dbo].[XUser_EdEinsatzvereinbarung] 
(
	[EdEinsatzvereinbarungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_XUser_EdEinsatzvereinbarung_UserID] ON [dbo].[XUser_EdEinsatzvereinbarung] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PrimaryKey, wird als ID benutzt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'XUser_EdEinsatzvereinbarungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf EdEinsatzvereinbarung.EdEinsatzvereinbarungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'EdEinsatzvereinbarungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sortierung innerhalb von EdEinsatzvereinbarungID je UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'SortKey'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungen zum gemachten Eintrag/Entlaster' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Bemerkungen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer welcher den Eintrag als letzer verändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann wurde der Eintrag zum letzten mal verändert.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_EdEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'XUser_EdEinsatzvereinbarungTS'
GO

ALTER TABLE [dbo].[XUser_EdEinsatzvereinbarung]  WITH CHECK ADD  CONSTRAINT [FK_XUser_EdEinsatzvereinbarung_EdEinsatzvereinbarung] FOREIGN KEY([EdEinsatzvereinbarungID])
REFERENCES [dbo].[EdEinsatzvereinbarung] ([EdEinsatzvereinbarungID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[XUser_EdEinsatzvereinbarung] CHECK CONSTRAINT [FK_XUser_EdEinsatzvereinbarung_EdEinsatzvereinbarung]
GO

ALTER TABLE [dbo].[XUser_EdEinsatzvereinbarung]  WITH CHECK ADD  CONSTRAINT [FK_XUser_EdEinsatzvereinbarung_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[XUser_EdEinsatzvereinbarung] CHECK CONSTRAINT [FK_XUser_EdEinsatzvereinbarung_XUser]
GO

ALTER TABLE [dbo].[XUser_EdEinsatzvereinbarung] ADD  CONSTRAINT [DF_XUser_EdEinsatzvereinbarung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[XUser_EdEinsatzvereinbarung] ADD  CONSTRAINT [DF_XUser_EdEinsatzvereinbarung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO