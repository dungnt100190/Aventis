CREATE TABLE [dbo].[KgOpAusgleich](
	[KgOpAusgleichID] [int] IDENTITY(1,1) NOT NULL,
	[OpBuchungID] [int] NOT NULL,
	[AusgleichBuchungID] [int] NOT NULL,
	[Betrag] [money] NOT NULL,
	[KbAusgleichGrundCode] [int] NULL,
	[KgBuchungAusgleichTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KgOpAusgleich] PRIMARY KEY CLUSTERED 
(
	[KgOpAusgleichID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
) ON [DATEN2]

GO

/****** Object:  Index [IX_KgOpAusgleich_AusgleichBuchungID]    Script Date: 11/23/2011 16:02:37 ******/
CREATE NONCLUSTERED INDEX [IX_KgOpAusgleich_AusgleichBuchungID] ON [dbo].[KgOpAusgleich] 
(
	[AusgleichBuchungID] ASC
)
INCLUDE ( [OpBuchungID],
[Betrag]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_KgOpAusgleich_OpBuchungID]    Script Date: 11/23/2011 16:02:37 ******/
CREATE NONCLUSTERED INDEX [IX_KgOpAusgleich_OpBuchungID] ON [dbo].[KgOpAusgleich] 
(
	[OpBuchungID] ASC
)
INCLUDE ( [Betrag]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO
ALTER TABLE [dbo].[KgOpAusgleich]  WITH CHECK ADD  CONSTRAINT [FK_KgBuchungAusgleich_KgBuchung] FOREIGN KEY([OpBuchungID])
REFERENCES [dbo].[KgBuchung] ([KgBuchungID])
GO
ALTER TABLE [dbo].[KgOpAusgleich] CHECK CONSTRAINT [FK_KgBuchungAusgleich_KgBuchung]
GO
ALTER TABLE [dbo].[KgOpAusgleich]  WITH CHECK ADD  CONSTRAINT [FK_KgBuchungAusgleich_KgBuchung1] FOREIGN KEY([AusgleichBuchungID])
REFERENCES [dbo].[KgBuchung] ([KgBuchungID])
GO
ALTER TABLE [dbo].[KgOpAusgleich] CHECK CONSTRAINT [FK_KgBuchungAusgleich_KgBuchung1]