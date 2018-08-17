CREATE TABLE [dbo].[FaZielvereinbarung](
	[FaZielvereinbarungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[DatumZielvereinbarung] [datetime] NOT NULL,
	[DatumAuswertungGeplant] [datetime] NULL,
	[DatumAuswertungDurchgefuehrt] [datetime] NULL,
	[DauerGeplant] [int] NULL,
	[DauerDurchgefuehrt] [int] NULL,
	[GespraecheGeplant] [int] NULL,
	[GespraecheDurchgefuehrt] [int] NULL,
	[SituationAuswertungCode] [int] NULL,
	[Thema] [varchar](2000) NULL,
	[Ziel1] [varchar](2000) NULL,
	[Ziel2] [varchar](2000) NULL,
	[Ziel3] [varchar](2000) NULL,
	[Ziel1AuswertungCode] [int] NULL,
	[Ziel2AuswertungCode] [int] NULL,
	[Ziel3AuswertungCode] [int] NULL,
	[Handlungsschritt1Wer] [varchar](200) NULL,
	[Handlungsschritt1Was] [varchar](2000) NULL,
	[Handlungsschritt1Wann] [datetime] NULL,
	[Handlungsschritt1AuswertungDatum] [datetime] NULL,
	[Handlungsschritt1Durchgefuehrt] [bit] NOT NULL,
	[Handlungsschritt1Hilfreich] [bit] NOT NULL,
	[Handlungsschritt2Wer] [varchar](200) NULL,
	[Handlungsschritt2Was] [varchar](2000) NULL,
	[Handlungsschritt2Wann] [datetime] NULL,
	[Handlungsschritt2AuswertungDatum] [datetime] NULL,
	[Handlungsschritt2Durchgefuehrt] [bit] NOT NULL,
	[Handlungsschritt2Hilfreich] [bit] NOT NULL,
	[Handlungsschritt3Wer] [varchar](200) NULL,
	[Handlungsschritt3Was] [varchar](2000) NULL,
	[Handlungsschritt3Wann] [datetime] NULL,
	[Handlungsschritt3AuswertungDatum] [datetime] NULL,
	[Handlungsschritt3Durchgefuehrt] [bit] NOT NULL,
	[Handlungsschritt3Hilfreich] [bit] NOT NULL,
	[AuftragAnKlient1Was] [varchar](2000) NULL,
	[AuftragAnKlient1Wann] [datetime] NULL,
	[AuftragAnKlient1AuswertungDatum] [datetime] NULL,
	[AuftragAnKlient1Erledigt] [bit] NOT NULL,
	[AuftragAnKlient1Hilfreich] [bit] NOT NULL,
	[AuftragAnKlient2Was] [varchar](2000) NULL,
	[AuftragAnKlient2Wann] [datetime] NULL,
	[AuftragAnKlient2AuswertungDatum] [datetime] NULL,
	[AuftragAnKlient2Erledigt] [bit] NOT NULL,
	[AuftragAnKlient2Hilfreich] [bit] NOT NULL,
	[ZielvereinbarungUserID] [int] NOT NULL,
	[AuswertungUserID] [int] NULL,
	[UnterschriftKlient] [datetime] NULL,
	[DokumentID] [int] NULL,
	[AuswertungDokumentID] [int] NULL,
	[ErstelltUserID] [int] NULL,
	[ErstelltDatum] [datetime] NULL,
	[MutiertUserID] [int] NULL,
	[MutiertDatum] [datetime] NULL,
	[FaZielvereinbarungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaZielvereinbarung] PRIMARY KEY CLUSTERED 
(
	[FaZielvereinbarungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FaZielvereinbarung_AuswertungUserID]    Script Date: 03/22/2012 10:25:29 ******/
CREATE NONCLUSTERED INDEX [IX_FaZielvereinbarung_AuswertungUserID] ON [dbo].[FaZielvereinbarung] 
(
	[AuswertungUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaZielvereinbarung_ErstelltUserID]    Script Date: 03/22/2012 10:25:29 ******/
CREATE NONCLUSTERED INDEX [IX_FaZielvereinbarung_ErstelltUserID] ON [dbo].[FaZielvereinbarung] 
(
	[ErstelltUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaZielvereinbarung_MutiertUserID]    Script Date: 03/22/2012 10:25:29 ******/
CREATE NONCLUSTERED INDEX [IX_FaZielvereinbarung_MutiertUserID] ON [dbo].[FaZielvereinbarung] 
(
	[MutiertUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaZielvereinbarung_ZielvereinbarungUserID]    Script Date: 03/22/2012 10:25:29 ******/
CREATE NONCLUSTERED INDEX [IX_FaZielvereinbarung_ZielvereinbarungUserID] ON [dbo].[FaZielvereinbarung] 
(
	[ZielvereinbarungUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaZielvereinbarung_BaPersonID]    Script Date: 03/22/2012 10:25:29 ******/
CREATE NONCLUSTERED INDEX [IX_FaZielvereinbarung_BaPersonID] ON [dbo].[FaZielvereinbarung] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaZielvereinbarung_FaLeistung]    Script Date: 03/22/2012 10:25:29 ******/
CREATE NONCLUSTERED INDEX [IX_FaZielvereinbarung_FaLeistung] ON [dbo].[FaZielvereinbarung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FaZielvereinbarung]  WITH CHECK ADD  CONSTRAINT [FK_FaZielvereinbarung_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[FaZielvereinbarung] CHECK CONSTRAINT [FK_FaZielvereinbarung_BaPerson]
GO

ALTER TABLE [dbo].[FaZielvereinbarung]  WITH CHECK ADD  CONSTRAINT [FK_FaZielvereinbarung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[FaZielvereinbarung] CHECK CONSTRAINT [FK_FaZielvereinbarung_FaLeistung]
GO

ALTER TABLE [dbo].[FaZielvereinbarung]  WITH CHECK ADD  CONSTRAINT [FK_FaZielvereinbarung_XUser] FOREIGN KEY([ZielvereinbarungUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaZielvereinbarung] CHECK CONSTRAINT [FK_FaZielvereinbarung_XUser]
GO

ALTER TABLE [dbo].[FaZielvereinbarung]  WITH CHECK ADD  CONSTRAINT [FK_FaZielvereinbarung_XUser_Auswertung] FOREIGN KEY([AuswertungUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaZielvereinbarung] CHECK CONSTRAINT [FK_FaZielvereinbarung_XUser_Auswertung]
GO

ALTER TABLE [dbo].[FaZielvereinbarung]  WITH CHECK ADD  CONSTRAINT [FK_FaZielvereinbarung_XUser_Erstellt] FOREIGN KEY([ErstelltUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaZielvereinbarung] CHECK CONSTRAINT [FK_FaZielvereinbarung_XUser_Erstellt]
GO

ALTER TABLE [dbo].[FaZielvereinbarung]  WITH CHECK ADD  CONSTRAINT [FK_FaZielvereinbarung_XUser_Mutiert] FOREIGN KEY([MutiertUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaZielvereinbarung] CHECK CONSTRAINT [FK_FaZielvereinbarung_XUser_Mutiert]
GO

ALTER TABLE [dbo].[FaZielvereinbarung] ADD  CONSTRAINT [DF_FaZielvereinbarung_Handlungsschritt1Durchgefuehrt]  DEFAULT ((0)) FOR [Handlungsschritt1Durchgefuehrt]
GO

ALTER TABLE [dbo].[FaZielvereinbarung] ADD  CONSTRAINT [DF_FaZielvereinbarung_Handlungsschritt1Hilfreich]  DEFAULT ((0)) FOR [Handlungsschritt1Hilfreich]
GO

ALTER TABLE [dbo].[FaZielvereinbarung] ADD  CONSTRAINT [DF_FaZielvereinbarung_Handlungsschritt2Durchgefuehrt]  DEFAULT ((0)) FOR [Handlungsschritt2Durchgefuehrt]
GO

ALTER TABLE [dbo].[FaZielvereinbarung] ADD  CONSTRAINT [DF_FaZielvereinbarung_Handlungsschritt2Hilfreich]  DEFAULT ((0)) FOR [Handlungsschritt2Hilfreich]
GO

ALTER TABLE [dbo].[FaZielvereinbarung] ADD  CONSTRAINT [DF_FaZielvereinbarung_Handlungsschritt3Durchgefuehrt]  DEFAULT ((0)) FOR [Handlungsschritt3Durchgefuehrt]
GO

ALTER TABLE [dbo].[FaZielvereinbarung] ADD  CONSTRAINT [DF_FaZielvereinbarung_Handlungsschritt3Hilfreich]  DEFAULT ((0)) FOR [Handlungsschritt3Hilfreich]
GO

ALTER TABLE [dbo].[FaZielvereinbarung] ADD  CONSTRAINT [DF_FaZielvereinbarung_AuftragAnKlientErledigt]  DEFAULT ((0)) FOR [AuftragAnKlient1Erledigt]
GO

ALTER TABLE [dbo].[FaZielvereinbarung] ADD  CONSTRAINT [DF_FaZielvereinbarung_AuftragAnKlientHilfreich]  DEFAULT ((0)) FOR [AuftragAnKlient1Hilfreich]
GO

ALTER TABLE [dbo].[FaZielvereinbarung] ADD  CONSTRAINT [DF_FaZielvereinbarung_AuftragAnKlient2Erledigt]  DEFAULT ((0)) FOR [AuftragAnKlient2Erledigt]
GO

ALTER TABLE [dbo].[FaZielvereinbarung] ADD  CONSTRAINT [DF_FaZielvereinbarung_AuftragAnKlient2Hilfreich]  DEFAULT ((0)) FOR [AuftragAnKlient2Hilfreich]
GO

