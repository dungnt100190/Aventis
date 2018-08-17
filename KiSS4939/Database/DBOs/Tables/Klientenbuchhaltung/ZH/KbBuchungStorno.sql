CREATE TABLE [dbo].[KbBuchungStorno](
	[KbBuchungStornoID] [int] IDENTITY(1,1) NOT NULL,
	[KbBuchungID] [int] NOT NULL,
	[StornoKbBuchungID] [int] NULL,
	[StornoBelegNr] [bigint] NULL,
	[StornierungVermerktUserID] [int] NOT NULL,
	[StornierungVermerktDatum] [datetime] NOT NULL,
	[StornoUserID] [int] NULL,
	[StornoDatum] [datetime] NULL,
	[StornoFehlermeldung] [varchar](300) NULL,
 CONSTRAINT [PK_KbBuchungBruttoStorno] PRIMARY KEY CLUSTERED 
(
	[KbBuchungStornoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KbBuchungStorno_StornierungVermerktUserID]    Script Date: 03/22/2012 10:27:58 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungStorno_StornierungVermerktUserID] ON [dbo].[KbBuchungStorno] 
(
	[StornierungVermerktUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchungStorno_StornoUserID]    Script Date: 03/22/2012 10:27:58 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungStorno_StornoUserID] ON [dbo].[KbBuchungStorno] 
(
	[StornoUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbBuchungStorno_KbBuchungID]    Script Date: 03/22/2012 10:27:58 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungStorno_KbBuchungID] ON [dbo].[KbBuchungStorno] 
(
	[KbBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN1]
GO


/****** Object:  Index [IX_KbBuchungStorno_StornoKbBuchungID]    Script Date: 03/22/2012 10:27:58 ******/
CREATE NONCLUSTERED INDEX [IX_KbBuchungStorno_StornoKbBuchungID] ON [dbo].[KbBuchungStorno] 
(
	[StornoKbBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK zur Netto-Buchung, die storniert werden soll oder storniert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchungStorno', @level2type=N'COLUMN',@level2name=N'KbBuchungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK zur neuen Storno-Netto-Buchung, die für die Nettobuchung KbBuchungID erstellt wurde. Wenn dieser FK abgefüllt ist, dann ist der Storno erfolgreich in KiSS und PSCD erfolgt.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchungStorno', @level2type=N'COLUMN',@level2name=N'StornoKbBuchungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PSCD Beleg Nummer des Storno-Belegs, der von PSCD erstellt wurde für diese Buchung. Wenn dieser Wert gesetzt ist, dann ist der Storno zumindest in PSCD erfolgt, d.h. StornoKbBuchungID = null, dann gibt es eine Beleg-Inkonsistenz zwischen KiSS und PSCD' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchungStorno', @level2type=N'COLUMN',@level2name=N'StornoBelegNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK nach XUser: Zeigt den User an, der diese Netto-Buchung zu stornieren markiert hat für den nächsten Stornolauf' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchungStorno', @level2type=N'COLUMN',@level2name=N'StornierungVermerktUserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum, an dem diese Netto-Buchung als zu stornieren markiert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchungStorno', @level2type=N'COLUMN',@level2name=N'StornierungVermerktDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK nach XUser: Zeigt den User an, der Stornolauf gestartet hat und diese Buchung storniert hat. Dieses Feld wird erst gefüllt, wenn der Storno komplett geglückt ist (PSCD und KiSS)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchungStorno', @level2type=N'COLUMN',@level2name=N'StornoUserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Zahllaufs.  Dieses Feld wird erst gefüllt, wenn der Storno komplett geglückt ist (PSCD und KiSS)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchungStorno', @level2type=N'COLUMN',@level2name=N'StornoDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Falls der Stornolauf misslingt für diese Buchungen, wird die Fehlermeldung hier abgefüllt. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbBuchungStorno', @level2type=N'COLUMN',@level2name=N'StornoFehlermeldung'
GO

ALTER TABLE [dbo].[KbBuchungStorno]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungStorno_KbBuchungID] FOREIGN KEY([KbBuchungID])
REFERENCES [dbo].[KbBuchung] ([KbBuchungID])
GO

ALTER TABLE [dbo].[KbBuchungStorno] CHECK CONSTRAINT [FK_KbBuchungStorno_KbBuchungID]
GO

ALTER TABLE [dbo].[KbBuchungStorno]  WITH CHECK ADD  CONSTRAINT [FK_KbBuchungStorno_StornoKbBuchungID] FOREIGN KEY([StornoKbBuchungID])
REFERENCES [dbo].[KbBuchung] ([KbBuchungID])
GO

ALTER TABLE [dbo].[KbBuchungStorno] CHECK CONSTRAINT [FK_KbBuchungStorno_StornoKbBuchungID]
GO

ALTER TABLE [dbo].[KbBuchungStorno]  WITH CHECK ADD  CONSTRAINT [FK_StornierungUserID_XUser] FOREIGN KEY([StornoUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[KbBuchungStorno] CHECK CONSTRAINT [FK_StornierungUserID_XUser]
GO

ALTER TABLE [dbo].[KbBuchungStorno]  WITH CHECK ADD  CONSTRAINT [FK_StornierungVermerktUserID_XUser] FOREIGN KEY([StornierungVermerktUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[KbBuchungStorno] CHECK CONSTRAINT [FK_StornierungVermerktUserID_XUser]
GO

