CREATE TABLE [dbo].[IkRechtstitelPosition](
	[IkRechtstitelPositionID] [int] IDENTITY(1,1) NOT NULL,
	[IkRechtstitelID] [int] NOT NULL,
	[IkPositionID] [int] NOT NULL,
	[IkRechtstitelPositionTS] [timestamp] NULL,
 CONSTRAINT [PK_IkRechtstitelPosition] PRIMARY KEY CLUSTERED 
(
	[IkRechtstitelPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Index [IX_IkRechtstitelPosition_IkPositionID]    Script Date: 03/22/2012 10:27:20 ******/
CREATE NONCLUSTERED INDEX [IX_IkRechtstitelPosition_IkPositionID] ON [dbo].[IkRechtstitelPosition] 
(
	[IkPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

ALTER TABLE [dbo].[IkRechtstitelPosition]  WITH CHECK ADD  CONSTRAINT [FK_IkRechtstitelPosition_IkPosition] FOREIGN KEY([IkPositionID])
REFERENCES [dbo].[IkPosition] ([IkPositionID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[IkRechtstitelPosition] CHECK CONSTRAINT [FK_IkRechtstitelPosition_IkPosition]
GO

ALTER TABLE [dbo].[IkRechtstitelPosition]  WITH CHECK ADD  CONSTRAINT [FK_IkRechtstitelPosition_IkRechtstitel] FOREIGN KEY([IkRechtstitelID])
REFERENCES [dbo].[IkRechtstitel] ([IkRechtstitelID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[IkRechtstitelPosition] CHECK CONSTRAINT [FK_IkRechtstitelPosition_IkRechtstitel]
GO

