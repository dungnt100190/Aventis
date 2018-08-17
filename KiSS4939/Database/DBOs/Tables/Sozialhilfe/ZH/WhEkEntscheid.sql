CREATE TABLE [dbo].[WhEkEntscheid](
	[WhEkEntscheidID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[Datum] [datetime] NOT NULL,
	[WhVerfuegungGrundCode] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[DocumentID] [int] NULL,
	[Bemerkung] [varchar](500) NULL,
	[WhEkStatusCode] [int] NULL,
	[EntscheidJahr] [int] NULL,
	[EntscheidKW] [int] NULL,
	[EntscheidLaufNr] [int] NULL,
	[VisumUserID] [int] NULL,
	[VisumDatum] [datetime] NULL,
	[ErstelltUserID] [int] NOT NULL,
	[ErstelltDatum] [datetime] NOT NULL,
	[MutiertUserID] [int] NOT NULL,
	[MutiertDatum] [datetime] NOT NULL,
	[WhEkEntscheidTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_WhEkEntscheid] PRIMARY KEY CLUSTERED 
(
	[WhEkEntscheidID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_WhEkEntscheid_ErstelltUserID]    Script Date: 03/22/2012 10:39:10 ******/
CREATE NONCLUSTERED INDEX [IX_WhEkEntscheid_ErstelltUserID] ON [dbo].[WhEkEntscheid] 
(
	[ErstelltUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_WhEkEntscheid_MutiertUserID]    Script Date: 03/22/2012 10:39:10 ******/
CREATE NONCLUSTERED INDEX [IX_WhEkEntscheid_MutiertUserID] ON [dbo].[WhEkEntscheid] 
(
	[MutiertUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_WhEkEntscheid_VisumUserID]    Script Date: 03/22/2012 10:39:10 ******/
CREATE NONCLUSTERED INDEX [IX_WhEkEntscheid_VisumUserID] ON [dbo].[WhEkEntscheid] 
(
	[VisumUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_WhEkEntscheid_FaLeistungID]    Script Date: 03/22/2012 10:39:10 ******/
CREATE NONCLUSTERED INDEX [IX_WhEkEntscheid_FaLeistungID] ON [dbo].[WhEkEntscheid] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_WhEkEntscheid_Sicherung]    Script Date: 03/22/2012 10:39:10 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_WhEkEntscheid_Sicherung] ON [dbo].[WhEkEntscheid] 
(
	[WhVerfuegungGrundCode] ASC,
	[BaPersonID] ASC,
	[EntscheidJahr] ASC,
	[EntscheidKW] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

ALTER TABLE [dbo].[WhEkEntscheid]  WITH CHECK ADD  CONSTRAINT [FK_WhEkEntscheid_FaFall] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[WhEkEntscheid] CHECK CONSTRAINT [FK_WhEkEntscheid_FaFall]
GO

ALTER TABLE [dbo].[WhEkEntscheid]  WITH CHECK ADD  CONSTRAINT [FK_WhEkEntscheid_XUser1] FOREIGN KEY([VisumUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[WhEkEntscheid] CHECK CONSTRAINT [FK_WhEkEntscheid_XUser1]
GO

ALTER TABLE [dbo].[WhEkEntscheid]  WITH CHECK ADD  CONSTRAINT [FK_WhEkEntscheid_XUser2] FOREIGN KEY([ErstelltUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[WhEkEntscheid] CHECK CONSTRAINT [FK_WhEkEntscheid_XUser2]
GO

ALTER TABLE [dbo].[WhEkEntscheid]  WITH CHECK ADD  CONSTRAINT [FK_WhEkEntscheid_XUser3] FOREIGN KEY([MutiertUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[WhEkEntscheid] CHECK CONSTRAINT [FK_WhEkEntscheid_XUser3]
GO

