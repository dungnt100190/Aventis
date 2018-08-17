CREATE TABLE [dbo].[IkGlaeubiger](
	[IkGlaeubigerID] [int] IDENTITY(1,1) NOT NULL,
	[IkRechtstitelID] [int] NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[IstElternteil] [bit] NOT NULL CONSTRAINT [DF_IkGlaeubiger_IstKind]  DEFAULT ((0)),
	[_old_InterneVerrechnung] [bit] NOT NULL CONSTRAINT [DF_IkGlaeubiger_InterneVerrechnung]  DEFAULT ((0)),
	[_old_BaZahlungswegID] [int] NULL,
	[_old_Betrag] [money] NULL,
	[_old_ZusatzBaZahlungswegID] [int] NULL,
	[_old_ZusatzBetrag] [money] NULL,
	[BetragALBV] [money] NULL,
	[ALBVDatumVon] [datetime] NULL,
	[ALBVDatumBis] [datetime] NULL,
	[IkGlaeubigerTS] [timestamp] NOT NULL,
	[IkGlaeubigerStatusCode] [int] NOT NULL CONSTRAINT [DF_IkGlaeubiger_IkGlaeubigerStatusCode]  DEFAULT ((1)),
	[VorSaldo] [money] NULL,
 CONSTRAINT [PK_IkGlaeubiger] PRIMARY KEY CLUSTERED 
(
	[IkGlaeubigerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [IX_IkGlaeubiger_BaPersonID]    Script Date: 11/23/2011 15:40:39 ******/
CREATE NONCLUSTERED INDEX [IX_IkGlaeubiger_BaPersonID] ON [dbo].[IkGlaeubiger] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_IkGlaeubiger_BaZahlungswegID]    Script Date: 11/23/2011 15:40:39 ******/
CREATE NONCLUSTERED INDEX [IX_IkGlaeubiger_BaZahlungswegID] ON [dbo].[IkGlaeubiger] 
(
	[_old_BaZahlungswegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_IkGlaeubiger_Sicherung]    Script Date: 11/23/2011 15:40:39 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_IkGlaeubiger_Sicherung] ON [dbo].[IkGlaeubiger] 
(
	[IkRechtstitelID] ASC,
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_IkGlaeubiger_ZusatzBaZahlungswegID]    Script Date: 11/23/2011 15:40:39 ******/
CREATE NONCLUSTERED INDEX [IX_IkGlaeubiger_ZusatzBaZahlungswegID] ON [dbo].[IkGlaeubiger] 
(
	[_old_ZusatzBaZahlungswegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IkGlaeubiger]  WITH CHECK ADD  CONSTRAINT [FK_IkGlaeubiger_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[IkGlaeubiger] CHECK CONSTRAINT [FK_IkGlaeubiger_BaPerson]
GO
ALTER TABLE [dbo].[IkGlaeubiger]  WITH CHECK ADD  CONSTRAINT [FK_IkGlaeubiger_BaZahlungsweg] FOREIGN KEY([_old_BaZahlungswegID])
REFERENCES [dbo].[BaZahlungsweg] ([BaZahlungswegID])
GO
ALTER TABLE [dbo].[IkGlaeubiger] CHECK CONSTRAINT [FK_IkGlaeubiger_BaZahlungsweg]
GO
ALTER TABLE [dbo].[IkGlaeubiger]  WITH CHECK ADD  CONSTRAINT [FK_IkGlaeubiger_BaZahlungswegZusatz] FOREIGN KEY([_old_ZusatzBaZahlungswegID])
REFERENCES [dbo].[BaZahlungsweg] ([BaZahlungswegID])
GO
ALTER TABLE [dbo].[IkGlaeubiger] CHECK CONSTRAINT [FK_IkGlaeubiger_BaZahlungswegZusatz]
GO
ALTER TABLE [dbo].[IkGlaeubiger]  WITH CHECK ADD  CONSTRAINT [FK_IkGlaeubiger_IkRechtstitel] FOREIGN KEY([IkRechtstitelID])
REFERENCES [dbo].[IkRechtstitel] ([IkRechtstitelID])
GO
ALTER TABLE [dbo].[IkGlaeubiger] CHECK CONSTRAINT [FK_IkGlaeubiger_IkRechtstitel]