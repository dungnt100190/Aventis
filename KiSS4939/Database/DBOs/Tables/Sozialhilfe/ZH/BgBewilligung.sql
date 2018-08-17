CREATE TABLE [dbo].[BgBewilligung](
	[BgBewilligungID] [int] IDENTITY(1,1) NOT NULL,
	[BgFinanzplanID] [int] NULL,
	[BgBudgetID] [int] NULL,
	[BgPositionID] [int] NULL,
	[UserID] [int] NOT NULL,
	[UserID_An] [int] NULL,
	[UserID_Erstellt] [int] NULL,
	[ClassName] [varchar](255) NULL,
	[Datum] [datetime] NOT NULL,
	[BgBewilligungCode] [int] NOT NULL,
	[Bemerkung] [text] NULL,
	[PerDatum] [datetime] NULL,
	[BgBewilligungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BgBewilligung] PRIMARY KEY CLUSTERED 
(
	[BgBewilligungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN2]
) ON [DATEN2] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_BgBewilligung_BgBudgetID]    Script Date: 04/18/2012 13:31:31 ******/
CREATE NONCLUSTERED INDEX [IX_BgBewilligung_BgBudgetID] ON [dbo].[BgBewilligung] 
(
	[BgBudgetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN2]
GO


/****** Object:  Index [IX_BgBewilligung_BgFinanzplanID]    Script Date: 04/18/2012 13:31:31 ******/
CREATE NONCLUSTERED INDEX [IX_BgBewilligung_BgFinanzplanID] ON [dbo].[BgBewilligung] 
(
	[BgFinanzplanID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN2]
GO


/****** Object:  Index [IX_BgBewilligung_BgPositionID]    Script Date: 04/18/2012 13:31:31 ******/
CREATE NONCLUSTERED INDEX [IX_BgBewilligung_BgPositionID] ON [dbo].[BgBewilligung] 
(
	[BgPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN2]
GO


/****** Object:  Index [IX_BgBewilligung_ClassName]    Script Date: 04/18/2012 13:31:31 ******/
CREATE NONCLUSTERED INDEX [IX_BgBewilligung_ClassName] ON [dbo].[BgBewilligung] 
(
	[ClassName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_BgBewilligung_UserID]    Script Date: 04/18/2012 13:31:31 ******/
CREATE NONCLUSTERED INDEX [IX_BgBewilligung_UserID] ON [dbo].[BgBewilligung] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN2]
GO


/****** Object:  Index [IX_BgBewilligung_UserID_An]    Script Date: 04/18/2012 13:31:31 ******/
CREATE NONCLUSTERED INDEX [IX_BgBewilligung_UserID_An] ON [dbo].[BgBewilligung] 
(
	[UserID_An] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN2]
GO


/****** Object:  Index [IX_BgBewilligung_UserID_Erstellt]    Script Date: 04/18/2012 13:31:31 ******/
CREATE NONCLUSTERED INDEX [IX_BgBewilligung_UserID_Erstellt] ON [dbo].[BgBewilligung] 
(
	[UserID_Erstellt] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Benutzer, der für die Bewilligung zuständig ist (FaLeistung)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgBewilligung', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Benutzer, der die Bewilligungsanfrage erhält' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgBewilligung', @level2type=N'COLUMN',@level2name=N'UserID_An'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Benutzer, der den Bewilligungseintrag erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgBewilligung', @level2type=N'COLUMN',@level2name=N'UserID_Erstellt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DESCRIPTION', @value=N'Herkunft (von welcher Maske)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgBewilligung', @level2type=N'COLUMN',@level2name=N'ClassName'
GO

ALTER TABLE [dbo].[BgBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_BgBewilligung_BgBewilligung] FOREIGN KEY([BgBewilligungID])
REFERENCES [dbo].[BgBewilligung] ([BgBewilligungID])
GO

ALTER TABLE [dbo].[BgBewilligung] CHECK CONSTRAINT [FK_BgBewilligung_BgBewilligung]
GO

ALTER TABLE [dbo].[BgBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_BgBewilligung_BgBudget] FOREIGN KEY([BgBudgetID])
REFERENCES [dbo].[BgBudget] ([BgBudgetID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BgBewilligung] CHECK CONSTRAINT [FK_BgBewilligung_BgBudget]
GO

ALTER TABLE [dbo].[BgBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_BgBewilligung_BgFinanzplan] FOREIGN KEY([BgFinanzplanID])
REFERENCES [dbo].[BgFinanzplan] ([BgFinanzplanID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BgBewilligung] CHECK CONSTRAINT [FK_BgBewilligung_BgFinanzplan]
GO

ALTER TABLE [dbo].[BgBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_BgBewilligung_BgPosition] FOREIGN KEY([BgPositionID])
REFERENCES [dbo].[BgPosition] ([BgPositionID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BgBewilligung] CHECK CONSTRAINT [FK_BgBewilligung_BgPosition]
GO

ALTER TABLE [dbo].[BgBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_BgBewilligung_XClass] FOREIGN KEY([ClassName])
REFERENCES [dbo].[XClass] ([ClassName])
GO

ALTER TABLE [dbo].[BgBewilligung] CHECK CONSTRAINT [FK_BgBewilligung_XClass]
GO

ALTER TABLE [dbo].[BgBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_BgBewilligung_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[BgBewilligung] CHECK CONSTRAINT [FK_BgBewilligung_XUser]
GO

ALTER TABLE [dbo].[BgBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_BgBewilligung_XUser__An] FOREIGN KEY([UserID_An])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[BgBewilligung] CHECK CONSTRAINT [FK_BgBewilligung_XUser__An]
GO

ALTER TABLE [dbo].[BgBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_BgBewilligung_XUser__Erstellt] FOREIGN KEY([UserID_Erstellt])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[BgBewilligung] CHECK CONSTRAINT [FK_BgBewilligung_XUser__Erstellt]
GO

ALTER TABLE [dbo].[BgBewilligung] ADD  CONSTRAINT [DF_BgBewilligung_Datum]  DEFAULT (getdate()) FOR [Datum]
GO

