CREATE TABLE [dbo].[FaAbmachung](
	[FaAbmachungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[AuflageVon] [datetime] NULL,
	[Betreff] [varchar](200) NULL,
	[Klient1ID] [int] NULL,
	[Klient2ID] [int] NULL,
	[Ausgangslage] [text] NULL,
	[Auflagentext] [text] NULL,
	[ErfuellenBis] [datetime] NULL,
	[AngedrohtFaAbmachungSanktionenCode] [int] NULL,
	[AuflageErfuelltCode] [int] NULL,
	[EKBeschluss] [datetime] NULL,
	[Zulagen] [varchar](100) NULL,
	[GBL] [varchar](5) NULL,
	[FaAbmachungSanktionenCode] [int] NULL,
	[SanktionAb] [datetime] NULL,
	[SanktionBis] [datetime] NULL,
	[DokumentID] [int] NULL,
	[ErstelltUserID] [int] NULL,
	[ErstelltDatum] [datetime] NULL,
	[MutiertUserID] [int] NULL,
	[MutiertDatum] [datetime] NULL,
	[AuflageErstelltUserID] [int] NULL,
	[AuflageErstelltDatum] [datetime] NULL,
	[AuflageMutiertUserID] [int] NULL,
	[AuflageMutiertDatum] [datetime] NULL,
	[FaAbmachungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaAbmachung] PRIMARY KEY CLUSTERED 
(
	[FaAbmachungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FaAbmachung_AuflageMutiertUserID]    Script Date: 03/22/2012 10:24:39 ******/
CREATE NONCLUSTERED INDEX [IX_FaAbmachung_AuflageMutiertUserID] ON [dbo].[FaAbmachung] 
(
	[AuflageMutiertUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaAbmachung_AuflageErstelltUserID]    Script Date: 03/22/2012 10:24:39 ******/
CREATE NONCLUSTERED INDEX [IX_FaAbmachung_AuflageErstelltUserID] ON [dbo].[FaAbmachung] 
(
	[AuflageErstelltUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaAbmachung_ErstellKUserID]    Script Date: 03/22/2012 10:24:39 ******/
CREATE NONCLUSTERED INDEX [IX_FaAbmachung_ErstellKUserID] ON [dbo].[FaAbmachung] 
(
	[ErstelltUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaAbmachung_FaLeistungID]    Script Date: 03/22/2012 10:24:39 ******/
CREATE NONCLUSTERED INDEX [IX_FaAbmachung_FaLeistungID] ON [dbo].[FaAbmachung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaAbmachung_Lient1ID]    Script Date: 03/22/2012 10:24:39 ******/
CREATE NONCLUSTERED INDEX [IX_FaAbmachung_Lient1ID] ON [dbo].[FaAbmachung] 
(
	[Klient1ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaAbmachung_Lient2ID]    Script Date: 03/22/2012 10:24:39 ******/
CREATE NONCLUSTERED INDEX [IX_FaAbmachung_Lient2ID] ON [dbo].[FaAbmachung] 
(
	[Klient2ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaAbmachung_MutiertUserID]    Script Date: 03/22/2012 10:24:39 ******/
CREATE NONCLUSTERED INDEX [IX_FaAbmachung_MutiertUserID] ON [dbo].[FaAbmachung] 
(
	[MutiertUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FaAbmachung]  WITH CHECK ADD  CONSTRAINT [FK_FaAbmachung_BaPerson] FOREIGN KEY([Klient1ID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[FaAbmachung] CHECK CONSTRAINT [FK_FaAbmachung_BaPerson]
GO

ALTER TABLE [dbo].[FaAbmachung]  WITH CHECK ADD  CONSTRAINT [FK_FaAbmachung_BaPerson1] FOREIGN KEY([Klient2ID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[FaAbmachung] CHECK CONSTRAINT [FK_FaAbmachung_BaPerson1]
GO

ALTER TABLE [dbo].[FaAbmachung]  WITH CHECK ADD  CONSTRAINT [FK_FaAbmachung_FaFall] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[FaAbmachung] CHECK CONSTRAINT [FK_FaAbmachung_FaFall]
GO

ALTER TABLE [dbo].[FaAbmachung]  WITH CHECK ADD  CONSTRAINT [FK_FaAbmachung_XUser] FOREIGN KEY([ErstelltUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaAbmachung] CHECK CONSTRAINT [FK_FaAbmachung_XUser]
GO

ALTER TABLE [dbo].[FaAbmachung]  WITH CHECK ADD  CONSTRAINT [FK_FaAbmachung_XUser1] FOREIGN KEY([AuflageErstelltUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaAbmachung] CHECK CONSTRAINT [FK_FaAbmachung_XUser1]
GO

ALTER TABLE [dbo].[FaAbmachung]  WITH CHECK ADD  CONSTRAINT [FK_FaAbmachung_XUser2] FOREIGN KEY([MutiertUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaAbmachung] CHECK CONSTRAINT [FK_FaAbmachung_XUser2]
GO

ALTER TABLE [dbo].[FaAbmachung]  WITH CHECK ADD  CONSTRAINT [FK_FaAbmachung_XUser3] FOREIGN KEY([AuflageMutiertUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaAbmachung] CHECK CONSTRAINT [FK_FaAbmachung_XUser3]
GO

