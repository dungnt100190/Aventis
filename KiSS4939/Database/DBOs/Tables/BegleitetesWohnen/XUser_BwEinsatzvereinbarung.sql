CREATE TABLE [dbo].[XUser_BwEinsatzvereinbarung](
	[XUser_BwEinsatzvereinbarungID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[BwEinsatzvereinbarungID] [int] NOT NULL,
	[SortKey] [int] NOT NULL,
	[Bemerkungen] [varchar](2000) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_XUser_BwEinsatzvereinbarung_Created]  DEFAULT (getdate()),
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL CONSTRAINT [DF_XUser_BwEinsatzvereinbarung_Modified]  DEFAULT (getdate()),
	[XUser_BwEinsatzvereinbarungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XUser_BwEinsatzvereinbarung] PRIMARY KEY CLUSTERED 
(
	[XUser_BwEinsatzvereinbarungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_XUser_BwEinsatzvereinbarung_UserID_EdEinsatzvereinbarungID] UNIQUE NONCLUSTERED 
(
	[UserID] ASC,
	[BwEinsatzvereinbarungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

/****** Object:  Index [IX_XUser_BwEinsatzvereinbarung_BwEinsatzvereinbarungID]    Script Date: 11/20/2009 13:31:51 ******/
CREATE NONCLUSTERED INDEX [IX_XUser_BwEinsatzvereinbarung_BwEinsatzvereinbarungID] ON [dbo].[XUser_BwEinsatzvereinbarung] 
(
	[BwEinsatzvereinbarungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_XUser_BwEinsatzvereinbarung_UserID]    Script Date: 11/20/2009 13:31:51 ******/
CREATE NONCLUSTERED INDEX [IX_XUser_BwEinsatzvereinbarung_UserID] ON [dbo].[XUser_BwEinsatzvereinbarung] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel nach KiSS Naming convention.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'XUser_BwEinsatzvereinbarungID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des betroffenen Users. Fremdschlüssel auf XUser Tabelle.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID der Einsatzvereinbarung im Modul BegleitetesWohnen. Fremdschlüssel auf BwEinsatzvereinbarung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'BwEinsatzvereinbarungID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sortkey der Einträge um eine Reihenfolge der User fest zu legen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'SortKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungen zu dieser Beziehung zwischen User und Einsatzvereinbarung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Bemerkungen'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer hat den Eintrag erstellt.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann wurde der Eintrag erstellt.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer hat den Eintrag als letzter modifiziert.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann wurde der Eintrag als letztes Modifiziert.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'Modified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für Konsistenzprüfungen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUser_BwEinsatzvereinbarung', @level2type=N'COLUMN',@level2name=N'XUser_BwEinsatzvereinbarungTS'
GO
ALTER TABLE [dbo].[XUser_BwEinsatzvereinbarung]  WITH CHECK ADD  CONSTRAINT [FK_XUser_BwEinsatzvereinbarung_BwEinsatzvereinbarung] FOREIGN KEY([BwEinsatzvereinbarungID])
REFERENCES [dbo].[BwEinsatzvereinbarung] ([BwEinsatzvereinbarungID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[XUser_BwEinsatzvereinbarung] CHECK CONSTRAINT [FK_XUser_BwEinsatzvereinbarung_BwEinsatzvereinbarung]
GO
ALTER TABLE [dbo].[XUser_BwEinsatzvereinbarung]  WITH CHECK ADD  CONSTRAINT [FK_XUser_BwEinsatzvereinbarung_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[XUser_BwEinsatzvereinbarung] CHECK CONSTRAINT [FK_XUser_BwEinsatzvereinbarung_XUser]