CREATE TABLE [dbo].[IkVerrechnungskonto](
	[IkVerrechnungskontoID] [int] IDENTITY(1,1) NOT NULL,
	[IkRechtstitelID] [int] NULL,
	[BaPersonID] [int] NULL,
	[Grundforderung] [money] NOT NULL,
	[VereinbarungVom] [datetime] NULL,
	[BetragProMonat] [money] NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NOT NULL,
	[LetzterMonat] [money] NOT NULL,
	[Bemerkung] [text] NULL,
	[_old_IstErledigt] [bit] NOT NULL CONSTRAINT [DF_IkRatenplan_IstErledigt]  DEFAULT ((0)),
	[IstAnnulliert] [bit] NOT NULL CONSTRAINT [DF_IkRatenplan_IstAnnuliert]  DEFAULT ((0)),
	[AnnulliertAm] [datetime] NULL,
	[IstAnPscdGesendet] [bit] NOT NULL CONSTRAINT [DF_IkRatenplan_IstVonPscdVerwendet]  DEFAULT ((0)),
	[IkVerrechnungsartCode] [int] NULL,
	[IkVerrechnungskontoTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_IkVerrechnungskonto] PRIMARY KEY CLUSTERED 
(
	[IkVerrechnungskontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Index [IX_IkVerrechnungskonto_BaPersonID]    Script Date: 11/23/2011 15:50:13 ******/
CREATE NONCLUSTERED INDEX [IX_IkVerrechnungskonto_BaPersonID] ON [dbo].[IkVerrechnungskonto] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_IkVerrechnungskonto_IkRechtstitelID]    Script Date: 11/23/2011 15:50:13 ******/
CREATE NONCLUSTERED INDEX [IX_IkVerrechnungskonto_IkRechtstitelID] ON [dbo].[IkVerrechnungskonto] 
(
	[IkRechtstitelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IkVerrechnungskonto]  WITH CHECK ADD  CONSTRAINT [FK_IkVerrechnungskonto_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[IkVerrechnungskonto] CHECK CONSTRAINT [FK_IkVerrechnungskonto_BaPerson]
GO
ALTER TABLE [dbo].[IkVerrechnungskonto]  WITH CHECK ADD  CONSTRAINT [FK_IkVerrechnungskonto_IkRechtstitel] FOREIGN KEY([IkRechtstitelID])
REFERENCES [dbo].[IkRechtstitel] ([IkRechtstitelID])
GO
ALTER TABLE [dbo].[IkVerrechnungskonto] CHECK CONSTRAINT [FK_IkVerrechnungskonto_IkRechtstitel]