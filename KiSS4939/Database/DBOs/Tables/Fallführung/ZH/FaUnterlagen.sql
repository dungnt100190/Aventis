CREATE TABLE [dbo].[FaUnterlagen](
	[FaUnterlagenID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[ErstelltUserID] [int] NOT NULL,
	[ErstelltDatum] [datetime] NOT NULL,
	[MutiertUserID] [int] NOT NULL,
	[MutiertDatum] [datetime] NOT NULL,
	[FaUnterlagenTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaUnterlagen] PRIMARY KEY CLUSTERED 
(
	[FaUnterlagenID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [IX_FaUnterlagen_ErstelltUserID]    Script Date: 11/23/2011 15:04:33 ******/
CREATE NONCLUSTERED INDEX [IX_FaUnterlagen_ErstelltUserID] ON [dbo].[FaUnterlagen] 
(
	[ErstelltUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaUnterlagen_FaLeistungID]    Script Date: 11/23/2011 15:04:33 ******/
CREATE NONCLUSTERED INDEX [IX_FaUnterlagen_FaLeistungID] ON [dbo].[FaUnterlagen] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaUnterlagen_MutiertUserID]    Script Date: 11/23/2011 15:04:33 ******/
CREATE NONCLUSTERED INDEX [IX_FaUnterlagen_MutiertUserID] ON [dbo].[FaUnterlagen] 
(
	[MutiertUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FaUnterlagen]  WITH CHECK ADD  CONSTRAINT [FK_FaUnterlagen_FaUnterlagen] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO
ALTER TABLE [dbo].[FaUnterlagen] CHECK CONSTRAINT [FK_FaUnterlagen_FaUnterlagen]
GO
ALTER TABLE [dbo].[FaUnterlagen]  WITH CHECK ADD  CONSTRAINT [FK_FaUnterlagen_XUser_Erstellt] FOREIGN KEY([ErstelltUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaUnterlagen] CHECK CONSTRAINT [FK_FaUnterlagen_XUser_Erstellt]
GO
ALTER TABLE [dbo].[FaUnterlagen]  WITH CHECK ADD  CONSTRAINT [FK_FaUnterlagen_XUser_Mutiert] FOREIGN KEY([MutiertUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaUnterlagen] CHECK CONSTRAINT [FK_FaUnterlagen_XUser_Mutiert]