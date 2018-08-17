CREATE TABLE [dbo].[IkRatenplanForderung](
	[IkRatenplanForderungID] [int] IDENTITY(1,1) NOT NULL,
	[IkRatenplanID] [int] NULL,
	[IkRechtstitelID] [int] NULL,
	[IkPositionID] [int] NULL,
	[IkForderungID] [int] NULL,
	[IkRatenplanForderunglTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_IkRatenplanForderung] PRIMARY KEY CLUSTERED 
(
	[IkRatenplanForderungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [IX_IkRatenplanForderung_IkForderungID]    Script Date: 11/23/2011 15:48:53 ******/
CREATE NONCLUSTERED INDEX [IX_IkRatenplanForderung_IkForderungID] ON [dbo].[IkRatenplanForderung] 
(
	[IkForderungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_IkRatenplanForderung_IkPositionID]    Script Date: 11/23/2011 15:48:53 ******/
CREATE NONCLUSTERED INDEX [IX_IkRatenplanForderung_IkPositionID] ON [dbo].[IkRatenplanForderung] 
(
	[IkPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_IkRatenplanForderung_IkRatenplanID]    Script Date: 11/23/2011 15:48:53 ******/
CREATE NONCLUSTERED INDEX [IX_IkRatenplanForderung_IkRatenplanID] ON [dbo].[IkRatenplanForderung] 
(
	[IkRatenplanID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_IkRatenplanForderung_IkRechtstitelID]    Script Date: 11/23/2011 15:48:53 ******/
CREATE NONCLUSTERED INDEX [IX_IkRatenplanForderung_IkRechtstitelID] ON [dbo].[IkRatenplanForderung] 
(
	[IkRechtstitelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IkRatenplanForderung]  WITH CHECK ADD  CONSTRAINT [FK_IkRatenplanForderung_IkForderung] FOREIGN KEY([IkForderungID])
REFERENCES [dbo].[IkForderung] ([IkForderungID])
GO
ALTER TABLE [dbo].[IkRatenplanForderung] CHECK CONSTRAINT [FK_IkRatenplanForderung_IkForderung]
GO
ALTER TABLE [dbo].[IkRatenplanForderung]  WITH CHECK ADD  CONSTRAINT [FK_IkRatenplanForderung_IkPosition] FOREIGN KEY([IkPositionID])
REFERENCES [dbo].[IkPosition] ([IkPositionID])
GO
ALTER TABLE [dbo].[IkRatenplanForderung] CHECK CONSTRAINT [FK_IkRatenplanForderung_IkPosition]
GO
ALTER TABLE [dbo].[IkRatenplanForderung]  WITH CHECK ADD  CONSTRAINT [FK_IkRatenplanForderung_IkRatenplan] FOREIGN KEY([IkRatenplanID])
REFERENCES [dbo].[IkRatenplan] ([IkRatenplanID])
GO
ALTER TABLE [dbo].[IkRatenplanForderung] CHECK CONSTRAINT [FK_IkRatenplanForderung_IkRatenplan]
GO
ALTER TABLE [dbo].[IkRatenplanForderung]  WITH CHECK ADD  CONSTRAINT [FK_IkRatenplanForderung_IkRechtstitel] FOREIGN KEY([IkRechtstitelID])
REFERENCES [dbo].[IkRechtstitel] ([IkRechtstitelID])
GO
ALTER TABLE [dbo].[IkRatenplanForderung] CHECK CONSTRAINT [FK_IkRatenplanForderung_IkRechtstitel]