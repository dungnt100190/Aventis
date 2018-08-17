CREATE TABLE [dbo].[IkForderung](
	[IkForderungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[IkRechtstitelID] [int] NULL,
	[BaPersonID] [int] NULL,
	[IkForderungPeriodischCode] [int] NOT NULL,
	[DatumAnpassenAb] [datetime] NOT NULL,
	[DatumGueltigBis] [datetime] NULL,
	[Betrag] [money] NULL,
	[IkAnpassungsGrundCode] [int] NULL,
	[IkAnpassungsRegelCode] [int] NULL,
	[IndexStandBeiBerechnung] [money] NULL,
	[IndexStandDatum] [datetime] NULL,
	[Bemerkung] [text] NULL,
	[Aktiv] [bit] NOT NULL CONSTRAINT [DF_IkForderung_ForderungAktiv]  DEFAULT ((1)),
	[Sollgestellt] [bit] NOT NULL CONSTRAINT [DF_IkForderung_ForderungSollgest]  DEFAULT ((0)),
	[Forderung_DocumentID] [int] NULL,
	[Teuerungseinsprache] [bit] NOT NULL CONSTRAINT [DF_IkForderung_Teuerungseinsprache]  DEFAULT ((0)),
	[VerwPeriodeVon] [datetime] NULL,
	[VerwPeriodeBis] [datetime] NULL,
	[IkForderungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_IkForderung] PRIMARY KEY CLUSTERED 
(
	[IkForderungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Index [IX_IkForderung_BaPerson]    Script Date: 11/23/2011 15:40:06 ******/
CREATE NONCLUSTERED INDEX [IX_IkForderung_BaPerson] ON [dbo].[IkForderung] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_IkForderung_FaLeistungID]    Script Date: 11/23/2011 15:40:06 ******/
CREATE NONCLUSTERED INDEX [IX_IkForderung_FaLeistungID] ON [dbo].[IkForderung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_IkForderung_IkRechtstitelID]    Script Date: 11/23/2011 15:40:06 ******/
CREATE NONCLUSTERED INDEX [IX_IkForderung_IkRechtstitelID] ON [dbo].[IkForderung] 
(
	[IkRechtstitelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IkForderung]  WITH CHECK ADD  CONSTRAINT [FK_IkForderung_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[IkForderung] CHECK CONSTRAINT [FK_IkForderung_BaPerson]
GO
ALTER TABLE [dbo].[IkForderung]  WITH CHECK ADD  CONSTRAINT [FK_IkForderung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO
ALTER TABLE [dbo].[IkForderung] CHECK CONSTRAINT [FK_IkForderung_FaLeistung]
GO
ALTER TABLE [dbo].[IkForderung]  WITH CHECK ADD  CONSTRAINT [FK_IkForderung_IkRechtstitel] FOREIGN KEY([IkRechtstitelID])
REFERENCES [dbo].[IkRechtstitel] ([IkRechtstitelID])
GO
ALTER TABLE [dbo].[IkForderung] CHECK CONSTRAINT [FK_IkForderung_IkRechtstitel]