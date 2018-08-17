CREATE TABLE [dbo].[KbOpAusgleich](
	[KbOpAusgleichID] [int] IDENTITY(1,1) NOT NULL,
	[OpBuchungID] [int] NOT NULL,
	[OpBuchungPosition] [int] NULL,
	[AusgleichBuchungID] [int] NOT NULL,
	[KbAusgleichGrundCode] [int] NULL,
	[Betrag] [money] NOT NULL,
	[KbOpAusgleichTS] [timestamp] NOT NULL,
	[KbBuchungBruttoID] [int] NULL,
 CONSTRAINT [PK_KbOpAusgleich] PRIMARY KEY CLUSTERED 
(
	[KbOpAusgleichID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
) ON [DATEN1]

GO

/****** Object:  Index [IX_KbOpAusgleich_AusgleichBuchungID]    Script Date: 11/23/2011 15:57:45 ******/
CREATE NONCLUSTERED INDEX [IX_KbOpAusgleich_AusgleichBuchungID] ON [dbo].[KbOpAusgleich] 
(
	[AusgleichBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

/****** Object:  Index [IX_KbOpAusgleich_OpBuchungID]    Script Date: 11/23/2011 15:57:45 ******/
CREATE NONCLUSTERED INDEX [IX_KbOpAusgleich_OpBuchungID] ON [dbo].[KbOpAusgleich] 
(
	[OpBuchungID] ASC
)
INCLUDE ( [AusgleichBuchungID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO

/****** Object:  Index [IX_KbOpAusgleich_OpBuchungID_KbOpAusgleichID_AusgleichBuchungID]    Script Date: 11/23/2011 15:57:45 ******/
CREATE NONCLUSTERED INDEX [IX_KbOpAusgleich_OpBuchungID_KbOpAusgleichID_AusgleichBuchungID] ON [dbo].[KbOpAusgleich] 
(
	[OpBuchungID] ASC,
	[KbOpAusgleichID] ASC,
	[AusgleichBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO
ALTER TABLE [dbo].[KbOpAusgleich]  WITH CHECK ADD  CONSTRAINT [FK_KbOpAusgleich_KbBuchung] FOREIGN KEY([OpBuchungID])
REFERENCES [dbo].[KbBuchung] ([KbBuchungID])
GO
ALTER TABLE [dbo].[KbOpAusgleich] CHECK CONSTRAINT [FK_KbOpAusgleich_KbBuchung]
GO
ALTER TABLE [dbo].[KbOpAusgleich]  WITH CHECK ADD  CONSTRAINT [FK_KbOpAusgleich_KbBuchung1] FOREIGN KEY([AusgleichBuchungID])
REFERENCES [dbo].[KbBuchung] ([KbBuchungID])
GO
ALTER TABLE [dbo].[KbOpAusgleich] CHECK CONSTRAINT [FK_KbOpAusgleich_KbBuchung1]