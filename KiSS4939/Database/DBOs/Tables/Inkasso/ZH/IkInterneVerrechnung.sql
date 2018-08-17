CREATE TABLE [dbo].[IkInterneVerrechnung](
	[IkInterneVerrechnungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[HatALBV] [bit] NOT NULL,
	[HatKiZu] [bit] NOT NULL,
	[IntVerrechnung_ALBV] [bit] NULL,
	[IntVerrechnung_ALV] [bit] NOT NULL,
	[IntVerrechnung_KiZu] [bit] NULL,
	[BaZahlungswegID_ALBV] [int] NULL,
	[BaZahlungswegID_ALBVZusatz] [int] NULL,
	[BaZahlungswegID_ALV] [int] NULL,
	[BaZahlungswegID_KiZu] [int] NULL,
	[Betrag] [money] NULL,
	[BetragZusatz] [money] NULL,
	[IkInterneVerrechnungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_IkInterneVerrechnung] PRIMARY KEY CLUSTERED 
(
	[IkInterneVerrechnungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Index [IX_IkInterneVerrechnung_BaPersonID]    Script Date: 03/22/2012 10:26:57 ******/
CREATE NONCLUSTERED INDEX [IX_IkInterneVerrechnung_BaPersonID] ON [dbo].[IkInterneVerrechnung] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_IkInterneVerrechnung_BaZahlungswegID_ALBV]    Script Date: 03/22/2012 10:26:57 ******/
CREATE NONCLUSTERED INDEX [IX_IkInterneVerrechnung_BaZahlungswegID_ALBV] ON [dbo].[IkInterneVerrechnung] 
(
	[BaZahlungswegID_ALBV] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_IkInterneVerrechnung_BaZahlungswegID_ALBVZusatz]    Script Date: 03/22/2012 10:26:57 ******/
CREATE NONCLUSTERED INDEX [IX_IkInterneVerrechnung_BaZahlungswegID_ALBVZusatz] ON [dbo].[IkInterneVerrechnung] 
(
	[BaZahlungswegID_ALBVZusatz] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_IkInterneVerrechnung_BaZahlungswegID_ALV]    Script Date: 03/22/2012 10:26:57 ******/
CREATE NONCLUSTERED INDEX [IX_IkInterneVerrechnung_BaZahlungswegID_ALV] ON [dbo].[IkInterneVerrechnung] 
(
	[BaZahlungswegID_ALV] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_IkInterneVerrechnung_BaZahlungswegID_KiZu]    Script Date: 03/22/2012 10:26:57 ******/
CREATE NONCLUSTERED INDEX [IX_IkInterneVerrechnung_BaZahlungswegID_KiZu] ON [dbo].[IkInterneVerrechnung] 
(
	[BaZahlungswegID_KiZu] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_IkInterneVerrechnung_FaLeistungID]    Script Date: 03/22/2012 10:26:57 ******/
CREATE NONCLUSTERED INDEX [IX_IkInterneVerrechnung_FaLeistungID] ON [dbo].[IkInterneVerrechnung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

ALTER TABLE [dbo].[IkInterneVerrechnung]  WITH CHECK ADD  CONSTRAINT [FK_IkInterneVerrechnung_BaPersonID] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[IkInterneVerrechnung] CHECK CONSTRAINT [FK_IkInterneVerrechnung_BaPersonID]
GO

ALTER TABLE [dbo].[IkInterneVerrechnung]  WITH CHECK ADD  CONSTRAINT [FK_IkInterneVerrechnung_BaZahlungswegID_ALBV] FOREIGN KEY([BaZahlungswegID_ALBV])
REFERENCES [dbo].[BaZahlungsweg] ([BaZahlungswegID])
GO

ALTER TABLE [dbo].[IkInterneVerrechnung] CHECK CONSTRAINT [FK_IkInterneVerrechnung_BaZahlungswegID_ALBV]
GO

ALTER TABLE [dbo].[IkInterneVerrechnung]  WITH CHECK ADD  CONSTRAINT [FK_IkInterneVerrechnung_BaZahlungswegID_ALV] FOREIGN KEY([BaZahlungswegID_ALV])
REFERENCES [dbo].[BaZahlungsweg] ([BaZahlungswegID])
GO

ALTER TABLE [dbo].[IkInterneVerrechnung] CHECK CONSTRAINT [FK_IkInterneVerrechnung_BaZahlungswegID_ALV]
GO

ALTER TABLE [dbo].[IkInterneVerrechnung]  WITH CHECK ADD  CONSTRAINT [FK_IkInterneVerrechnung_BaZahlungswegID_ALVBZusatz] FOREIGN KEY([BaZahlungswegID_ALBVZusatz])
REFERENCES [dbo].[BaZahlungsweg] ([BaZahlungswegID])
GO

ALTER TABLE [dbo].[IkInterneVerrechnung] CHECK CONSTRAINT [FK_IkInterneVerrechnung_BaZahlungswegID_ALVBZusatz]
GO

ALTER TABLE [dbo].[IkInterneVerrechnung]  WITH CHECK ADD  CONSTRAINT [FK_IkInterneVerrechnung_BaZahlungswegID_KiZu] FOREIGN KEY([BaZahlungswegID_KiZu])
REFERENCES [dbo].[BaZahlungsweg] ([BaZahlungswegID])
GO

ALTER TABLE [dbo].[IkInterneVerrechnung] CHECK CONSTRAINT [FK_IkInterneVerrechnung_BaZahlungswegID_KiZu]
GO

ALTER TABLE [dbo].[IkInterneVerrechnung]  WITH CHECK ADD  CONSTRAINT [FK_IkInterneVerrechnung_FaLeistungID] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[IkInterneVerrechnung] CHECK CONSTRAINT [FK_IkInterneVerrechnung_FaLeistungID]
GO

