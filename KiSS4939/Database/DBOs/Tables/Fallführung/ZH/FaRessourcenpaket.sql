CREATE TABLE [dbo].[FaRessourcenpaket](
	[FaRessourcenpaketID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[RPBedarfBezeichnungCode] [int] NULL,
	[RPBedarfKriteriumCode] [int] NULL,
	[RPBedarfDatumVon] [datetime] NULL,
	[RPIstBezeichnungCode] [int] NULL,
	[RPIstKriteriumCode] [int] NULL,
	[RPIstProfilCode] [int] NULL,
	[RPIstDatumVon] [datetime] NULL,
	[FallfuehrenderID] [int] NULL,
	[CoFallfuehrenderID] [int] NULL,
	[SachbearbeiterID] [int] NULL,
	[RPIstDatumAbschluss] [datetime] NULL,
	[FaRessourcenpaketTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaRessourcenpaket] PRIMARY KEY CLUSTERED 
(
	[FaRessourcenpaketID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [IX_FaRessourcenpaket_BaPersonID]    Script Date: 11/23/2011 15:04:01 ******/
CREATE NONCLUSTERED INDEX [IX_FaRessourcenpaket_BaPersonID] ON [dbo].[FaRessourcenpaket] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaRessourcenpaket_CoFallfuehrenderID]    Script Date: 11/23/2011 15:04:01 ******/
CREATE NONCLUSTERED INDEX [IX_FaRessourcenpaket_CoFallfuehrenderID] ON [dbo].[FaRessourcenpaket] 
(
	[CoFallfuehrenderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaRessourcenpaket_FaLeistungID]    Script Date: 11/23/2011 15:04:01 ******/
CREATE NONCLUSTERED INDEX [IX_FaRessourcenpaket_FaLeistungID] ON [dbo].[FaRessourcenpaket] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaRessourcenpaket_FallfuehrenderID]    Script Date: 11/23/2011 15:04:01 ******/
CREATE NONCLUSTERED INDEX [IX_FaRessourcenpaket_FallfuehrenderID] ON [dbo].[FaRessourcenpaket] 
(
	[FallfuehrenderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaRessourcenpaket_SachbearbeiterID]    Script Date: 11/23/2011 15:04:01 ******/
CREATE NONCLUSTERED INDEX [IX_FaRessourcenpaket_SachbearbeiterID] ON [dbo].[FaRessourcenpaket] 
(
	[SachbearbeiterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FaRessourcenpaket]  WITH CHECK ADD  CONSTRAINT [FK_FaRessourcenpaket_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[FaRessourcenpaket] CHECK CONSTRAINT [FK_FaRessourcenpaket_BaPerson]
GO
ALTER TABLE [dbo].[FaRessourcenpaket]  WITH CHECK ADD  CONSTRAINT [FK_FaRessourcenpaket_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO
ALTER TABLE [dbo].[FaRessourcenpaket] CHECK CONSTRAINT [FK_FaRessourcenpaket_FaLeistung]
GO
ALTER TABLE [dbo].[FaRessourcenpaket]  WITH CHECK ADD  CONSTRAINT [FK_FaRessourcenpaket_XUser] FOREIGN KEY([FallfuehrenderID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaRessourcenpaket] CHECK CONSTRAINT [FK_FaRessourcenpaket_XUser]
GO
ALTER TABLE [dbo].[FaRessourcenpaket]  WITH CHECK ADD  CONSTRAINT [FK_FaRessourcenpaket_XUser1] FOREIGN KEY([CoFallfuehrenderID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaRessourcenpaket] CHECK CONSTRAINT [FK_FaRessourcenpaket_XUser1]
GO
ALTER TABLE [dbo].[FaRessourcenpaket]  WITH CHECK ADD  CONSTRAINT [FK_FaRessourcenpaket_XUser2] FOREIGN KEY([SachbearbeiterID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaRessourcenpaket] CHECK CONSTRAINT [FK_FaRessourcenpaket_XUser2]