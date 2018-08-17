CREATE TABLE [dbo].[FbBuchung](
	[FbBuchungID] [int] IDENTITY(1,1) NOT NULL,
	[FbPeriodeID] [int] NOT NULL,
	[BuchungTypCode] [int] NOT NULL,
	[Code] [varchar](10) NULL,
	[BelegNr] [varchar](15) NOT NULL,
	[BelegNrPos] [int] NOT NULL,
	[BuchungsDatum] [datetime] NOT NULL,
	[SollKtoNr] [int] NULL,
	[HabenKtoNr] [int] NULL,
	[Betrag] [money] NOT NULL,
	[Text] [varchar](200) NOT NULL,
	[ValutaDatum] [datetime] NULL,
	[ValutaDatumOriginal] [datetime] NULL,
	[Zahlungsfrist] [int] NULL,
	[BuchungStatusCode] [int] NULL,
	[FbDauerauftragID] [int] NULL,
	[ErfassungsDatum] [datetime] NULL,
	[UserID] [int] NULL,
	[FbZahlungswegID] [int] NULL,
	[PCKontoNr] [varchar](50) NULL,
	[BankKontoNr] [varchar](50) NULL,
	[IBAN] [varchar](50) NULL,
	[ZahlungsArtCode] [int] NULL,
	[ReferenzNummer] [varchar](50) NULL,
	[Zahlungsgrund] [varchar](200) NULL,
	[Name] [varchar](100) NULL,
	[Zusatz] [varchar](50) NULL,
	[Strasse] [varchar](200) NULL,
	[PLZ] [varchar](8) NULL,
	[Ort] [varchar](50) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FbBuchungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FbBuchung] PRIMARY KEY CLUSTERED 
(
	[FbBuchungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FbBuchung_FbDauerauftragID]    Script Date: 01/15/2014 16:55:21 ******/
CREATE NONCLUSTERED INDEX [IX_FbBuchung_FbDauerauftragID] ON [dbo].[FbBuchung] 
(
	[FbDauerauftragID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FbBuchung_FbPeriodeID]    Script Date: 01/15/2014 16:55:21 ******/
CREATE NONCLUSTERED INDEX [IX_FbBuchung_FbPeriodeID] ON [dbo].[FbBuchung] 
(
	[FbPeriodeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FbBuchung_FbPeriodeID_HabenKtoNr]    Script Date: 01/15/2014 16:55:21 ******/
CREATE NONCLUSTERED INDEX [IX_FbBuchung_FbPeriodeID_HabenKtoNr] ON [dbo].[FbBuchung] 
(
	[FbPeriodeID] ASC,
	[HabenKtoNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FbBuchung_FbPeriodeID_SollKtoNr]    Script Date: 01/15/2014 16:55:21 ******/
CREATE NONCLUSTERED INDEX [IX_FbBuchung_FbPeriodeID_SollKtoNr] ON [dbo].[FbBuchung] 
(
	[FbPeriodeID] ASC,
	[SollKtoNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FbBuchung_FbZahlungswegID]    Script Date: 01/15/2014 16:55:21 ******/
CREATE NONCLUSTERED INDEX [IX_FbBuchung_FbZahlungswegID] ON [dbo].[FbBuchung] 
(
	[FbZahlungswegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FbBuchung_UserID]    Script Date: 01/15/2014 16:55:21 ******/
CREATE NONCLUSTERED INDEX [IX_FbBuchung_UserID] ON [dbo].[FbBuchung] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für FbBuchung Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'FbBuchungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FBBUCHUN_REFERENCE_FBPERIOD) => FbPeriode.FbPeriodeID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'FbPeriodeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Buchungstyp gemäss LOV FbBuchungTyp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'BuchungTypCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Buchungscode - Template für Buchung (KtoNr und Text) - FbBuchungCode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'Code'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BelegNr mit Präfix - FbBelegNr (Impliziter Zusammenhang mit BuchungTypCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'BelegNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Position der Buchung für diese BelegNr. Immer 0. Obsolete??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'BelegNrPos'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zeitpunkt zu welchem die Buchung verbucht wird.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'BuchungsDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FBBUCHUN_REFERENCE_FBKONTO2) => FbKonto.KontoNr' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'SollKtoNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FBBUCHUN_REFERENCE_FBKONTO) => FbKonto.KontoNr' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'HabenKtoNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag der Buchung in CHF.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'Betrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Buchungstext' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'Text'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zeitpunkt zu welchem der Betrag ausbezahlt wird.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'ValutaDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'das originale Valutadatum, dass fürs erstellen von Buchungen via Dauerautrag verwendet wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'ValutaDatumOriginal'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Auszahlung möglich bis ende Zahlungsfrist. Tage nach ValutaDatum?? Obsolete??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'Zahlungsfrist'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Status der Buchung. LOV FbBuchungStatus. Obsolete??' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'BuchungStatusCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FBBUCHUN_REFERENCE_FBDAUERA) => FbDauerauftrag.FbDauerauftragID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'FbDauerauftragID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zeitpunkt zu welchem die Buchung erfasst wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'ErfassungsDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FbBuchung_XUser) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FBBUCHUN_REFERENCE_FBZAHLUN) => FbZahlungsweg.FbZahlungswegID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'FbZahlungswegID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Post Konto Nr' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'PCKontoNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bank Konto Nr' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'BankKontoNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Konto-Nr des Kreditors im internationalen Format.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'IBAN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zahlungsart. Zahlungsart für Buchungen mit Kreditor.  LOV FbZahlungsartCode.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'ZahlungsArtCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Referenznummer für Buchungen mit ESR.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'ReferenzNummer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Feld auf Einzahlungsschein.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'Zahlungsgrund'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Empfänger: Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Empfänger: Adresszusatz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'Zusatz'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Empfänger: Strasse und Nr' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'Strasse'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Empfänger: PLZ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'PLZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Empfänger: Ort' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'Ort'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbBuchung', @level2type=N'COLUMN',@level2name=N'Modified'
GO

ALTER TABLE [dbo].[FbBuchung]  WITH CHECK ADD  CONSTRAINT [FK_FBBUCHUN_REFERENCE_FBDAUERA] FOREIGN KEY([FbDauerauftragID])
REFERENCES [dbo].[FbDauerauftrag] ([FbDauerauftragID])
GO

ALTER TABLE [dbo].[FbBuchung] CHECK CONSTRAINT [FK_FBBUCHUN_REFERENCE_FBDAUERA]
GO

ALTER TABLE [dbo].[FbBuchung]  WITH NOCHECK ADD  CONSTRAINT [FK_FBBUCHUN_REFERENCE_FBKONTO] FOREIGN KEY([FbPeriodeID], [HabenKtoNr])
REFERENCES [dbo].[FbKonto] ([FbPeriodeID], [KontoNr])
GO

ALTER TABLE [dbo].[FbBuchung] CHECK CONSTRAINT [FK_FBBUCHUN_REFERENCE_FBKONTO]
GO

ALTER TABLE [dbo].[FbBuchung]  WITH NOCHECK ADD  CONSTRAINT [FK_FBBUCHUN_REFERENCE_FBKONTO2] FOREIGN KEY([FbPeriodeID], [HabenKtoNr])
REFERENCES [dbo].[FbKonto] ([FbPeriodeID], [KontoNr])
GO

ALTER TABLE [dbo].[FbBuchung] CHECK CONSTRAINT [FK_FBBUCHUN_REFERENCE_FBKONTO2]
GO

ALTER TABLE [dbo].[FbBuchung]  WITH NOCHECK ADD  CONSTRAINT [FK_FBBUCHUN_REFERENCE_FBPERIOD] FOREIGN KEY([FbPeriodeID])
REFERENCES [dbo].[FbPeriode] ([FbPeriodeID])
GO

ALTER TABLE [dbo].[FbBuchung] CHECK CONSTRAINT [FK_FBBUCHUN_REFERENCE_FBPERIOD]
GO

ALTER TABLE [dbo].[FbBuchung]  WITH NOCHECK ADD  CONSTRAINT [FK_FBBUCHUN_REFERENCE_FBZAHLUN] FOREIGN KEY([FbZahlungswegID])
REFERENCES [dbo].[FbZahlungsweg] ([FbZahlungswegID])
GO

ALTER TABLE [dbo].[FbBuchung] CHECK CONSTRAINT [FK_FBBUCHUN_REFERENCE_FBZAHLUN]
GO

ALTER TABLE [dbo].[FbBuchung]  WITH NOCHECK ADD  CONSTRAINT [FK_FbBuchung_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FbBuchung] CHECK CONSTRAINT [FK_FbBuchung_XUser]
GO

ALTER TABLE [dbo].[FbBuchung] ADD  CONSTRAINT [DF_FbBuchung_ErfassungsDatum]  DEFAULT (getdate()) FOR [ErfassungsDatum]
GO

ALTER TABLE [dbo].[FbBuchung] ADD  CONSTRAINT [DF_FbBuchung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FbBuchung] ADD  CONSTRAINT [DF_FbBuchung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


