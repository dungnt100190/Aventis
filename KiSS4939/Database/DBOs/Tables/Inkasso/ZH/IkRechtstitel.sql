CREATE TABLE [dbo].[IkRechtstitel](
	[IkRechtstitelID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[Bezeichnung] [varchar](200) NULL,
	[IkBezugKinderzulagenCode] [int] NULL CONSTRAINT [DF_FaLeistung_IkBezugKinderzulagenCode]  DEFAULT ((1)),
	[ElterlicheSorgeCode] [int] NULL,
	[ElterlicheSorgeBemerkung] [varchar](200) NULL,
	[BaPersonID] [int] NULL,
	[IkIndexTypCode] [int] NULL,
	[IndexStandPunkte] [money] NULL,
	[IndexStandVom] [datetime] NULL,
	[IkIndexRundenCode] [int] NULL,
	[BasisKinderalimente] [money] NULL,
	[BasisEhegattenalimente] [money] NULL,
	[VerjaehrungAm] [datetime] NULL,
	[Bemerkung] [text] NULL,
	[Mahnlauf] [bit] NOT NULL CONSTRAINT [DF_FaLeistung_Mahnlauf]  DEFAULT ((1)),
	[IkRechtstitelGueltigVon] [datetime] NULL,
	[IkRechtstitelGueltigBis] [datetime] NULL,
	[BeantragtAm] [datetime] NULL,
	[WohnhaftImKantonSeit] [datetime] NULL,
	[IkRechtstitelTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_IkRechtstitel] PRIMARY KEY CLUSTERED 
(
	[IkRechtstitelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_IkRechtstitel_BaPersonID]    Script Date: 11/23/2011 15:49:13 ******/
CREATE NONCLUSTERED INDEX [IX_IkRechtstitel_BaPersonID] ON [dbo].[IkRechtstitel] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_IkRechtstitel_FaLeistungID]    Script Date: 11/23/2011 15:49:13 ******/
CREATE NONCLUSTERED INDEX [IX_IkRechtstitel_FaLeistungID] ON [dbo].[IkRechtstitel] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IkRechtstitel]  WITH CHECK ADD  CONSTRAINT [FK_IkRechtstitel_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[IkRechtstitel] CHECK CONSTRAINT [FK_IkRechtstitel_BaPerson]
GO
ALTER TABLE [dbo].[IkRechtstitel]  WITH CHECK ADD  CONSTRAINT [FK_IkRechtstitel_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO
ALTER TABLE [dbo].[IkRechtstitel] CHECK CONSTRAINT [FK_IkRechtstitel_FaLeistung]