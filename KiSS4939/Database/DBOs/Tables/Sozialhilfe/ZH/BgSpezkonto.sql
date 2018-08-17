CREATE TABLE [dbo].[BgSpezkonto](
	[BgSpezkontoID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[BgSpezkontoTypCode] [int] NOT NULL,
	[NameSpezkonto] [varchar](100) NOT NULL,
	[StartSaldo] [money] NOT NULL CONSTRAINT [DF_BgSpezkonto_StartSaldo]  DEFAULT ((0.00)),
	[OhneEinzelzahlung] [bit] NOT NULL CONSTRAINT [DF_BgSpezkonto_OhneEinzelzahlung]  DEFAULT ((0)),
	[BetragProMonat] [money] NULL,
	[BgPositionsartID] [int] NULL,
	[ErsterMonat] [datetime] NULL,
	[BgKostenartID] [int] NULL,
	[DatumVon] [datetime] NOT NULL CONSTRAINT [DF_BgSpezkonto_DatumVon]  DEFAULT (getdate()),
	[DatumBis] [datetime] NULL,
	[Bemerkung] [text] NULL,
	[BgSpezkontoTS] [timestamp] NOT NULL,
	[BaInstitutionID] [int] NULL,
	[BaPersonID] [int] NULL,
	[Inaktiv] [bit] NOT NULL CONSTRAINT [DF_BgSpezkonto_Inaktiv]  DEFAULT ((0)),
 CONSTRAINT [PK_BgSpezkonto] PRIMARY KEY CLUSTERED 
(
	[BgSpezkontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_BgSpezkonto_BgPositionsartID]    Script Date: 11/23/2011 13:25:54 ******/
CREATE NONCLUSTERED INDEX [IX_BgSpezkonto_BgPositionsartID] ON [dbo].[BgSpezkonto] 
(
	[BgPositionsartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BgSpezkonto_FaLeistungID]    Script Date: 11/23/2011 13:25:54 ******/
CREATE NONCLUSTERED INDEX [IX_BgSpezkonto_FaLeistungID] ON [dbo].[BgSpezkonto] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BgSpezkonto_KostenartID]    Script Date: 11/23/2011 13:25:54 ******/
CREATE NONCLUSTERED INDEX [IX_BgSpezkonto_KostenartID] ON [dbo].[BgSpezkonto] 
(
	[BgKostenartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BgSpezkonto]  WITH CHECK ADD  CONSTRAINT [FK_BgSpezkonto_BgKostenart] FOREIGN KEY([BgKostenartID])
REFERENCES [dbo].[BgKostenart] ([BgKostenartID])
GO
ALTER TABLE [dbo].[BgSpezkonto] CHECK CONSTRAINT [FK_BgSpezkonto_BgKostenart]
GO
ALTER TABLE [dbo].[BgSpezkonto]  WITH CHECK ADD  CONSTRAINT [FK_BgSpezkonto_BgPositionsart] FOREIGN KEY([BgPositionsartID])
REFERENCES [dbo].[BgPositionsart] ([BgPositionsartID])
GO
ALTER TABLE [dbo].[BgSpezkonto] CHECK CONSTRAINT [FK_BgSpezkonto_BgPositionsart]
GO
ALTER TABLE [dbo].[BgSpezkonto]  WITH CHECK ADD  CONSTRAINT [FK_BgSpezkonto_FaFall] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BgSpezkonto] CHECK CONSTRAINT [FK_BgSpezkonto_FaFall]