CREATE TABLE [dbo].[IkPosition](
	[IkPositionID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[IkRechtstitelID] [int] NULL,
	[Einmalig] [bit] NOT NULL,
	[Datum] [datetime] NULL,
	[Monat] [int] NOT NULL,
	[Jahr] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[TotalAliment] [money] NULL,
	[TotalAlimentSoll] [money] NULL,
	[BetragALBV] [money] NULL,
	[BetragALBVSoll] [money] NULL,
	[BetragKiZulage] [money] NULL,
	[BetragKiZulageSoll] [money] NULL,
	[BetragALBVverrechnung] [money] NULL,
	[BetragZahlung] [money] NULL,
	[BetragEinmalig] [money] NULL,
	[IkForderungEinmaligCode] [int] NULL,
	[BetragIstNegativ] [bit] NOT NULL CONSTRAINT [DF_IkPosition_BetragIstNegativ]  DEFAULT ((0)),
	[IndexStandBeiBerechnung] [money] NULL,
	[IndexStandDatum] [datetime] NULL,
	[_old_ErledigterMonat] [bit] NULL,
	[_old_ErledigterMonatForderung] [bit] NULL,
	[_old_Unterstuetzungsfall] [bit] NULL,
	[Bemerkung] [varchar](500) NULL,
	[Forderung_DocumentID] [int] NULL,
	[MigResoKonto] [int] NULL,
	[MigResoSaldoID] [int] NULL,
	[VerwPeriodeVon] [datetime] NULL,
	[VerwPeriodeBis] [datetime] NULL,
	[IkPositionTS] [timestamp] NOT NULL,
	[BetragZahlungSoll] [money] NULL,
	[IkBuchungsartCode] [int] NULL,
	[FehlerInfos] [varchar](200) NULL,
	[Buchungstext] [varchar](200) NULL,
	[DossierNummer] [varchar](10) NULL,
	[VerfahrensNummer] [varchar](20) NULL,
	[BetragALBVverrechnungSoll] [money] NULL,
	[IkRechtstitelID_Alt] [int] NULL,
	[HatMehrereAlteRT] [bit] NULL
) ON [PRIMARY]
SET ANSI_PADDING OFF
ALTER TABLE [dbo].[IkPosition] ADD [ErstellungsGrund] [varchar](40) NULL
/****** Object:  Index [PK_IkPosition]    Script Date: 11/23/2011 15:48:22 ******/
ALTER TABLE [dbo].[IkPosition] ADD  CONSTRAINT [PK_IkPosition] PRIMARY KEY CLUSTERED 
(
	[IkPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_IkPosition_BaPersonID]    Script Date: 11/23/2011 15:48:22 ******/
CREATE NONCLUSTERED INDEX [IX_IkPosition_BaPersonID] ON [dbo].[IkPosition] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_IkPosition_FaLeistungID]    Script Date: 11/23/2011 15:48:22 ******/
CREATE NONCLUSTERED INDEX [IX_IkPosition_FaLeistungID] ON [dbo].[IkPosition] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_IkPosition_IkRechtstitelID]    Script Date: 11/23/2011 15:48:22 ******/
CREATE NONCLUSTERED INDEX [IX_IkPosition_IkRechtstitelID] ON [dbo].[IkPosition] 
(
	[IkRechtstitelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IkPosition]  WITH CHECK ADD  CONSTRAINT [FK_IkPosition_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[IkPosition] CHECK CONSTRAINT [FK_IkPosition_BaPerson]
GO
ALTER TABLE [dbo].[IkPosition]  WITH CHECK ADD  CONSTRAINT [FK_IkPosition_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO
ALTER TABLE [dbo].[IkPosition] CHECK CONSTRAINT [FK_IkPosition_FaLeistung]
GO
ALTER TABLE [dbo].[IkPosition]  WITH CHECK ADD  CONSTRAINT [FK_IkPosition_IkRechtstitel] FOREIGN KEY([IkRechtstitelID])
REFERENCES [dbo].[IkRechtstitel] ([IkRechtstitelID])
GO
ALTER TABLE [dbo].[IkPosition] CHECK CONSTRAINT [FK_IkPosition_IkRechtstitel]