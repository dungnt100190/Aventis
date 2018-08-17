CREATE TABLE [dbo].[FaAssessment](
	[FaAssessmentID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[EroeffnungDatum] [datetime] NOT NULL,
	[EroeffnungUserID] [int] NOT NULL,
	[EroeffnungOrgUnitID] [int] NULL,
	[FaUeberbrueckungGrundCode] [int] NULL,
	[AbschlussDatum] [datetime] NULL,
	[AbschlussUserID] [int] NULL,
	[FaAssessmentAbschlussGrundCode] [int] NULL,
	[FaRessourcenPaketCode] [int] NULL,
	[FaKriteriumCode] [int] NULL,
	[QTUebergabeOrgUnitID] [int] NULL,
	[QTUebergabeDatum] [datetime] NULL,
	[DatumBericht] [datetime] NULL,
	[UnterschriftKlientDatum] [datetime] NULL,
	[UserID] [int] NULL,
	[Anlass] [text] NULL,
	[Situation] [text] NULL,
	[Thema1] [varchar](500) NULL,
	[Thema2] [varchar](500) NULL,
	[Thema1Zustaendig] [varchar](200) NULL,
	[Thema2Zustaendig] [varchar](200) NULL,
	[ThemaAnpacken] [text] NULL,
	[ThemaAnpackenKeinInteresse] [bit] NULL,
	[ThemaAnpackenKeinInteresseGrund] [text] NULL,
	[KeinSoDThema] [bit] NULL,
	[AndereStellen] [text] NULL,
	[FaAuflageCode] [int] NULL,
	[Auflage] [text] NULL,
	[Auftrag] [text] NULL,
	[AuftragFrist] [datetime] NULL,
	[RPBedarfCode] [int] NULL,
	[DeutschUngenuegend] [bit] NULL,
	[Muttersprache] [varchar](100) NULL,
	[Uebersetzer] [bit] NULL,
	[Bemerkung] [text] NULL,
	[BerichtUserID] [int] NULL,
	[BerichtDokID] [int] NULL,
	[UnterschriebenDurchKlient] [datetime] NULL,
	[TaskID] [int] NULL,
	[FaAssessmentTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaAssessment] PRIMARY KEY CLUSTERED 
(
	[FaAssessmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_FaAssessment_AbschlussUserID]    Script Date: 11/23/2011 14:42:43 ******/
CREATE NONCLUSTERED INDEX [IX_FaAssessment_AbschlussUserID] ON [dbo].[FaAssessment] 
(
	[AbschlussUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaAssessment_BerichtUserID]    Script Date: 11/23/2011 14:42:43 ******/
CREATE NONCLUSTERED INDEX [IX_FaAssessment_BerichtUserID] ON [dbo].[FaAssessment] 
(
	[BerichtUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaAssessment_EroeffnungOrgUnitID]    Script Date: 11/23/2011 14:42:43 ******/
CREATE NONCLUSTERED INDEX [IX_FaAssessment_EroeffnungOrgUnitID] ON [dbo].[FaAssessment] 
(
	[EroeffnungOrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaAssessment_EroeffnungUserID]    Script Date: 11/23/2011 14:42:43 ******/
CREATE NONCLUSTERED INDEX [IX_FaAssessment_EroeffnungUserID] ON [dbo].[FaAssessment] 
(
	[EroeffnungUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaAssessment_FaLeistungID]    Script Date: 11/23/2011 14:42:43 ******/
CREATE NONCLUSTERED INDEX [IX_FaAssessment_FaLeistungID] ON [dbo].[FaAssessment] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaAssessment_QTUebergabeOrgUnitID]    Script Date: 11/23/2011 14:42:43 ******/
CREATE NONCLUSTERED INDEX [IX_FaAssessment_QTUebergabeOrgUnitID] ON [dbo].[FaAssessment] 
(
	[QTUebergabeOrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaAssessment_TaskID]    Script Date: 11/23/2011 14:42:43 ******/
CREATE NONCLUSTERED INDEX [IX_FaAssessment_TaskID] ON [dbo].[FaAssessment] 
(
	[TaskID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaAssessment_UserID]    Script Date: 11/23/2011 14:42:43 ******/
CREATE NONCLUSTERED INDEX [IX_FaAssessment_UserID] ON [dbo].[FaAssessment] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FaAssessment]  WITH CHECK ADD  CONSTRAINT [FK_FaAssessment_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO
ALTER TABLE [dbo].[FaAssessment] CHECK CONSTRAINT [FK_FaAssessment_FaLeistung]
GO
ALTER TABLE [dbo].[FaAssessment]  WITH CHECK ADD  CONSTRAINT [FK_FaAssessment_XOrgUnit_Eroeffnung] FOREIGN KEY([EroeffnungOrgUnitID])
REFERENCES [dbo].[XOrgUnit] ([OrgUnitID])
GO
ALTER TABLE [dbo].[FaAssessment] CHECK CONSTRAINT [FK_FaAssessment_XOrgUnit_Eroeffnung]
GO
ALTER TABLE [dbo].[FaAssessment]  WITH CHECK ADD  CONSTRAINT [FK_FaAssessment_XOrgUnit_QTUebergabe] FOREIGN KEY([QTUebergabeOrgUnitID])
REFERENCES [dbo].[XOrgUnit] ([OrgUnitID])
GO
ALTER TABLE [dbo].[FaAssessment] CHECK CONSTRAINT [FK_FaAssessment_XOrgUnit_QTUebergabe]
GO
ALTER TABLE [dbo].[FaAssessment]  WITH CHECK ADD  CONSTRAINT [FK_FaAssessment_XTask] FOREIGN KEY([TaskID])
REFERENCES [dbo].[XTask] ([XTaskID])
GO
ALTER TABLE [dbo].[FaAssessment] CHECK CONSTRAINT [FK_FaAssessment_XTask]
GO
ALTER TABLE [dbo].[FaAssessment]  WITH CHECK ADD  CONSTRAINT [FK_FaAssessment_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaAssessment] CHECK CONSTRAINT [FK_FaAssessment_XUser]
GO
ALTER TABLE [dbo].[FaAssessment]  WITH CHECK ADD  CONSTRAINT [FK_FaAssessment_XUser_Abschluss] FOREIGN KEY([AbschlussUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaAssessment] CHECK CONSTRAINT [FK_FaAssessment_XUser_Abschluss]
GO
ALTER TABLE [dbo].[FaAssessment]  WITH CHECK ADD  CONSTRAINT [FK_FaAssessment_XUser_Bericht] FOREIGN KEY([BerichtUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaAssessment] CHECK CONSTRAINT [FK_FaAssessment_XUser_Bericht]
GO
ALTER TABLE [dbo].[FaAssessment]  WITH CHECK ADD  CONSTRAINT [FK_FaAssessment_XUser_Eroeffnung] FOREIGN KEY([EroeffnungUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaAssessment] CHECK CONSTRAINT [FK_FaAssessment_XUser_Eroeffnung]