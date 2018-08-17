CREATE TABLE [dbo].[FaRessourcenkarte](
	[FaRessourcenkarteID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[StatusCode] [int] NULL,
	[RessourcenPersoenlich] [text] NULL,
	[RessourcenSozial] [text] NULL,
	[RessourcenMateriell] [text] NULL,
	[RessourcenInfrastrukturell] [text] NULL,
	[UnterschriebenDatum] [datetime] NULL,
	[ErstelltUserID] [int] NOT NULL,
	[ErstelltDatum] [datetime] NOT NULL,
	[MutiertUserID] [int] NOT NULL,
	[MutiertDatum] [datetime] NOT NULL,
	[FaRessourcenkarteTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaRessourcenkarte] PRIMARY KEY CLUSTERED 
(
	[FaRessourcenkarteID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Index [IX_FaRessourcenkarte_BaPersonID]    Script Date: 11/23/2011 15:03:30 ******/
CREATE NONCLUSTERED INDEX [IX_FaRessourcenkarte_BaPersonID] ON [dbo].[FaRessourcenkarte] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaRessourcenkarte_ErstelltUserID]    Script Date: 11/23/2011 15:03:30 ******/
CREATE NONCLUSTERED INDEX [IX_FaRessourcenkarte_ErstelltUserID] ON [dbo].[FaRessourcenkarte] 
(
	[ErstelltUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaRessourcenkarte_FaLeistungID]    Script Date: 11/23/2011 15:03:30 ******/
CREATE NONCLUSTERED INDEX [IX_FaRessourcenkarte_FaLeistungID] ON [dbo].[FaRessourcenkarte] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaRessourcenkarte_MutiertUserID]    Script Date: 11/23/2011 15:03:30 ******/
CREATE NONCLUSTERED INDEX [IX_FaRessourcenkarte_MutiertUserID] ON [dbo].[FaRessourcenkarte] 
(
	[MutiertUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FaRessourcenkarte]  WITH CHECK ADD  CONSTRAINT [FK_FaRessourcenkarte_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[FaRessourcenkarte] CHECK CONSTRAINT [FK_FaRessourcenkarte_BaPerson]
GO
ALTER TABLE [dbo].[FaRessourcenkarte]  WITH CHECK ADD  CONSTRAINT [FK_FaRessourcenkarte_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO
ALTER TABLE [dbo].[FaRessourcenkarte] CHECK CONSTRAINT [FK_FaRessourcenkarte_FaLeistung]
GO
ALTER TABLE [dbo].[FaRessourcenkarte]  WITH CHECK ADD  CONSTRAINT [FK_FaRessourcenkarte_XUser_Erstellt] FOREIGN KEY([ErstelltUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaRessourcenkarte] CHECK CONSTRAINT [FK_FaRessourcenkarte_XUser_Erstellt]
GO
ALTER TABLE [dbo].[FaRessourcenkarte]  WITH CHECK ADD  CONSTRAINT [FK_FaRessourcenkarte_XUser_Mutiert] FOREIGN KEY([MutiertUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaRessourcenkarte] CHECK CONSTRAINT [FK_FaRessourcenkarte_XUser_Mutiert]