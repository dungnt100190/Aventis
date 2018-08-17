CREATE TABLE [dbo].[IkForderungPosition](
	[IkForderungID] [int] NOT NULL,
	[IkPositionID] [int] NOT NULL,
	[IkForderungPositionTS] [timestamp] NULL,
	[IkForderungPositionID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_IkForderungPosition] PRIMARY KEY CLUSTERED 
(
	[IkForderungPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [IX_IkForderungPosition_IkForderungID]    Script Date: 11/23/2011 15:40:26 ******/
CREATE NONCLUSTERED INDEX [IX_IkForderungPosition_IkForderungID] ON [dbo].[IkForderungPosition] 
(
	[IkForderungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_IkForderungPosition_IkPositionID]    Script Date: 11/23/2011 15:40:26 ******/
CREATE NONCLUSTERED INDEX [IX_IkForderungPosition_IkPositionID] ON [dbo].[IkForderungPosition] 
(
	[IkPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IkForderungPosition]  WITH CHECK ADD  CONSTRAINT [FK_IkForderungPosition_IkForderung] FOREIGN KEY([IkForderungID])
REFERENCES [dbo].[IkForderung] ([IkForderungID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IkForderungPosition] CHECK CONSTRAINT [FK_IkForderungPosition_IkForderung]
GO
ALTER TABLE [dbo].[IkForderungPosition]  WITH CHECK ADD  CONSTRAINT [FK_IkForderungPosition_IkPosition] FOREIGN KEY([IkPositionID])
REFERENCES [dbo].[IkPosition] ([IkPositionID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[IkForderungPosition] CHECK CONSTRAINT [FK_IkForderungPosition_IkPosition]