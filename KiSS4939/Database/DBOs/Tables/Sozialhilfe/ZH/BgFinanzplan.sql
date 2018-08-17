CREATE TABLE [dbo].[BgFinanzplan](
	[BgFinanzplanID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[BgBewilligungStatusCode] [int] NOT NULL,
	[BgGrundEroeffnenCode] [int] NULL,
	[BgGrundAbschlussCode] [int] NULL,
	[WhHilfeTypCode] [int] NOT NULL CONSTRAINT [DF_BgFinanzplan_WhHilfeTypCode]  DEFAULT ((1)),
	[GeplantVon] [datetime] NOT NULL,
	[GeplantBis] [datetime] NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[UnterschriftAntrag] [datetime] NULL,
	[Bemerkung] [text] NULL,
	[BgFinanzplanTS] [timestamp] NOT NULL,
	[WhGrundbedarfTypCode] [int] NULL,
	[PscdVgID] [bigint] NULL,
	[XDocumentID_KiJuAmbulant] [int] NULL,
	[XDocumentID_Klaerungsphase] [int] NULL,
	[XDocumentID_Leistungsentscheid] [int] NULL,
 CONSTRAINT [PK_BgFinanzplan] PRIMARY KEY CLUSTERED 
(
	[BgFinanzplanID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Index [IX_BgFinanzplan_BgBewilligungStatusCode]    Script Date: 11/23/2011 11:46:07 ******/
CREATE NONCLUSTERED INDEX [IX_BgFinanzplan_BgBewilligungStatusCode] ON [dbo].[BgFinanzplan] 
(
	[BgBewilligungStatusCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BgFinanzplan_FaLeistungID]    Script Date: 11/23/2011 11:46:07 ******/
CREATE NONCLUSTERED INDEX [IX_BgFinanzplan_FaLeistungID] ON [dbo].[BgFinanzplan] 
(
	[FaLeistungID] ASC
)
INCLUDE ( [DatumVon],
[BgBewilligungStatusCode],
[WhHilfeTypCode],
[GeplantVon],
[GeplantBis],
[DatumBis]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO
ALTER TABLE [dbo].[BgFinanzplan]  WITH CHECK ADD  CONSTRAINT [FK_BgFinanzplan_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO
ALTER TABLE [dbo].[BgFinanzplan] CHECK CONSTRAINT [FK_BgFinanzplan_FaLeistung]