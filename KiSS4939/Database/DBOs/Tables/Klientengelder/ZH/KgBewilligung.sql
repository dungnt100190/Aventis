CREATE TABLE [dbo].[KgBewilligung](
	[KgBewilligungID] [int] IDENTITY(1,1) NOT NULL,
	[KgBudgetID] [int] NULL,
	[UserID] [int] NOT NULL,
	[UserID_An] [int] NULL,
	[KgPositionID] [int] NULL,
	[ClassName] [varchar](255) NULL,
	[Datum] [datetime] NOT NULL,
	[KgBewilligungCode] [int] NOT NULL,
	[Bemerkung] [text] NULL,
	[PerDatum] [datetime] NULL,
	[KgBewilligungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KgBewilligung] PRIMARY KEY CLUSTERED 
(
	[KgBewilligungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KgBewilligung_ClassName]    Script Date: 04/19/2012 14:01:51 ******/
CREATE NONCLUSTERED INDEX [IX_KgBewilligung_ClassName] ON [dbo].[KgBewilligung] 
(
	[ClassName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KgBewilligung_KgBudgetID]    Script Date: 04/19/2012 14:01:51 ******/
CREATE NONCLUSTERED INDEX [IX_KgBewilligung_KgBudgetID] ON [dbo].[KgBewilligung] 
(
	[KgBudgetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_KgBewilligung_KgPositionID]    Script Date: 04/19/2012 14:01:51 ******/
CREATE NONCLUSTERED INDEX [IX_KgBewilligung_KgPositionID] ON [dbo].[KgBewilligung] 
(
	[KgPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KgBewilligung_UserID]    Script Date: 04/19/2012 14:01:51 ******/
CREATE NONCLUSTERED INDEX [IX_KgBewilligung_UserID] ON [dbo].[KgBewilligung] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_KgBewilligung_UserID_An]    Script Date: 04/19/2012 14:01:51 ******/
CREATE NONCLUSTERED INDEX [IX_KgBewilligung_UserID_An] ON [dbo].[KgBewilligung] 
(
	[UserID_An] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Peter Salajan' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KgBewilligung'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bewilligungs-History von KgPosition.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KgBewilligung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK auf KgPosition' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KgBewilligung', @level2type=N'COLUMN',@level2name=N'KgPositionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Herkunft (von welcher Maske)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KgBewilligung', @level2type=N'COLUMN',@level2name=N'ClassName'
GO

ALTER TABLE [dbo].[KgBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_KgBewilligung_KgBudget] FOREIGN KEY([KgBudgetID])
REFERENCES [dbo].[KgBudget] ([KgBudgetID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[KgBewilligung] CHECK CONSTRAINT [FK_KgBewilligung_KgBudget]
GO

ALTER TABLE [dbo].[KgBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_KgBewilligung_KgPosition] FOREIGN KEY([KgPositionID])
REFERENCES [dbo].[KgPosition] ([KgPositionID])
GO

ALTER TABLE [dbo].[KgBewilligung] CHECK CONSTRAINT [FK_KgBewilligung_KgPosition]
GO

ALTER TABLE [dbo].[KgBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_KgBewilligung_XClass] FOREIGN KEY([ClassName])
REFERENCES [dbo].[XClass] ([ClassName])
GO

ALTER TABLE [dbo].[KgBewilligung] CHECK CONSTRAINT [FK_KgBewilligung_XClass]
GO

ALTER TABLE [dbo].[KgBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_KgBewilligung_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[KgBewilligung] CHECK CONSTRAINT [FK_KgBewilligung_XUser]
GO

ALTER TABLE [dbo].[KgBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_KgBewilligung_XUser__An] FOREIGN KEY([UserID_An])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[KgBewilligung] CHECK CONSTRAINT [FK_KgBewilligung_XUser__An]
GO

ALTER TABLE [dbo].[KgBewilligung] ADD  CONSTRAINT [DF_KgBewilligung_Datum]  DEFAULT (getdate()) FOR [Datum]
GO


