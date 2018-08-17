CREATE TABLE [dbo].[KgPeriode](
	[KgPeriodeID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[PeriodeVon] [datetime] NOT NULL,
	[PeriodeBis] [datetime] NOT NULL,
	[AbgeschlossenBis] [datetime] NULL,
	[KgPeriodeStatusCode] [int] NOT NULL,
	[BaZahlungswegID] [int] NULL,
	[Vermittlungsfall] [bit] NOT NULL CONSTRAINT [DF_KgPeriode_Vermittlungsfall]  DEFAULT ((0)),
	[KgPeriodeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KgPeriode] PRIMARY KEY CLUSTERED 
(
	[KgPeriodeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [IX_KgPeriode_BaZahlungswegID]    Script Date: 11/23/2011 16:02:50 ******/
CREATE NONCLUSTERED INDEX [IX_KgPeriode_BaZahlungswegID] ON [dbo].[KgPeriode] 
(
	[BaZahlungswegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KgPeriode_FaLeistung_PeriodeVon]    Script Date: 11/23/2011 16:02:50 ******/
CREATE NONCLUSTERED INDEX [IX_KgPeriode_FaLeistung_PeriodeVon] ON [dbo].[KgPeriode] 
(
	[FaLeistungID] ASC,
	[PeriodeVon] DESC
)
INCLUDE ( [PeriodeBis],
[KgPeriodeStatusCode]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_KgPeriode_FaLeistungID]    Script Date: 11/23/2011 16:02:50 ******/
CREATE NONCLUSTERED INDEX [IX_KgPeriode_FaLeistungID] ON [dbo].[KgPeriode] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[KgPeriode]  WITH CHECK ADD  CONSTRAINT [FK_KgPeriode_BaZahlungsweg] FOREIGN KEY([BaZahlungswegID])
REFERENCES [dbo].[BaZahlungsweg] ([BaZahlungswegID])
GO
ALTER TABLE [dbo].[KgPeriode] CHECK CONSTRAINT [FK_KgPeriode_BaZahlungsweg]
GO
ALTER TABLE [dbo].[KgPeriode]  WITH CHECK ADD  CONSTRAINT [FK_KgPeriode_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO
ALTER TABLE [dbo].[KgPeriode] CHECK CONSTRAINT [FK_KgPeriode_FaLeistung]