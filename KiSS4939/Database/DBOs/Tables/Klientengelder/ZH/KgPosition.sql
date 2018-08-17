CREATE TABLE [dbo].[KgPosition](
	[KgPositionID] [int] IDENTITY(1,1) NOT NULL,
	[KgBudgetID] [int] NOT NULL,
	[KgPositionsKategorieCode] [int] NOT NULL,
	[MasterbudgetPositionID] [int] NULL,
	[KontoNr] [varchar](10) NULL,
	[Buchungstext] [varchar](100) NULL,
	[Betrag] [money] NOT NULL CONSTRAINT [DF_KgBudgetPosition_Betrag]  DEFAULT ((0)),
	[Bemerkung] [text] NULL,
	[BuchungDatum] [datetime] NULL,
	[BaInstitutionID] [int] NULL,
	[KgAuszahlungsArtCode] [int] NULL,
	[KgAuszahlungsTerminCode] [int] NULL,
	[KgWochentagCodes] [varchar](20) NULL,
	[BaZahlungswegID] [int] NULL,
	[MitteilungZeile1] [varchar](35) NULL,
	[MitteilungZeile2] [varchar](35) NULL,
	[MitteilungZeile3] [varchar](35) NULL,
	[MitteilungZeile4] [varchar](35) NULL,
	[ReferenzNummer] [varchar](50) NULL,
	[ErstelltUserID] [int] NULL,
	[ErstelltDatum] [datetime] NULL,
	[MutiertUserID] [int] NULL,
	[MutiertDatum] [datetime] NULL,
	[KgPositionTS] [timestamp] NOT NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[KgBewilligungCode] [int] NULL,
 CONSTRAINT [PK_KgPosition] PRIMARY KEY CLUSTERED 
(
	[KgPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
) ON [DATEN1] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_KgPosition_BaZahlungswegID]    Script Date: 11/23/2011 16:03:34 ******/
CREATE NONCLUSTERED INDEX [IX_KgPosition_BaZahlungswegID] ON [dbo].[KgPosition] 
(
	[BaZahlungswegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KgPosition_Erstellt_User_und_Datum]    Script Date: 11/23/2011 16:03:34 ******/
CREATE NONCLUSTERED INDEX [IX_KgPosition_Erstellt_User_und_Datum] ON [dbo].[KgPosition] 
(
	[ErstelltUserID] ASC,
	[ErstelltDatum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

/****** Object:  Index [IX_KgPosition_KgBudgetID]    Script Date: 11/23/2011 16:03:34 ******/
CREATE NONCLUSTERED INDEX [IX_KgPosition_KgBudgetID] ON [dbo].[KgPosition] 
(
	[KgBudgetID] ASC
)
INCLUDE ( [MasterbudgetPositionID],
[KgPositionsKategorieCode]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

/****** Object:  Index [IX_KgPosition_MasterbudgetPositionID]    Script Date: 11/23/2011 16:03:34 ******/
CREATE NONCLUSTERED INDEX [IX_KgPosition_MasterbudgetPositionID] ON [dbo].[KgPosition] 
(
	[MasterbudgetPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

/****** Object:  Index [IX_KgPosition_Mutiert_User_und_Datum]    Script Date: 11/23/2011 16:03:34 ******/
CREATE NONCLUSTERED INDEX [IX_KgPosition_Mutiert_User_und_Datum] ON [dbo].[KgPosition] 
(
	[MutiertUserID] ASC,
	[MutiertDatum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO
ALTER TABLE [dbo].[KgPosition]  WITH CHECK ADD  CONSTRAINT [FK_KgPosition_BaZahlungswegID] FOREIGN KEY([BaZahlungswegID])
REFERENCES [dbo].[BaZahlungsweg] ([BaZahlungswegID])
GO
ALTER TABLE [dbo].[KgPosition] CHECK CONSTRAINT [FK_KgPosition_BaZahlungswegID]
GO
ALTER TABLE [dbo].[KgPosition]  WITH CHECK ADD  CONSTRAINT [FK_KgPosition_KgBudget] FOREIGN KEY([KgBudgetID])
REFERENCES [dbo].[KgBudget] ([KgBudgetID])
GO
ALTER TABLE [dbo].[KgPosition] CHECK CONSTRAINT [FK_KgPosition_KgBudget]
GO
ALTER TABLE [dbo].[KgPosition]  WITH CHECK ADD  CONSTRAINT [FK_KgPosition_KgPosition] FOREIGN KEY([MasterbudgetPositionID])
REFERENCES [dbo].[KgPosition] ([KgPositionID])
GO
ALTER TABLE [dbo].[KgPosition] CHECK CONSTRAINT [FK_KgPosition_KgPosition]