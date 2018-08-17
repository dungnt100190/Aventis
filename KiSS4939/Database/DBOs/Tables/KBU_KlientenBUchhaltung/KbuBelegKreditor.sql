CREATE TABLE [dbo].[KbuBelegKreditor](
	[KbuBelegKreditorID] [int] IDENTITY(1,1) NOT NULL,
	[KbuBelegID] [int] NOT NULL,
	[BaZahlungswegID] [int] NULL,
	[BaBankID] [int] NULL,
	[BaLandID_Beguenstigt] [int] NULL,
	[BaLandID_Bank] [int] NULL,
	[KbuAuszahlungArtCode] [int] NULL,
	[ReferenzNummer] [varchar](50) NULL,
	[MitteilungZeile1] [varchar](35) NULL,
	[MitteilungZeile2] [varchar](35) NULL,
	[MitteilungZeile3] [varchar](35) NULL,
	[MitteilungZeile4] [varchar](35) NULL,
	[BgEinzahlungsscheinCode] [int] NULL,
	[PCKontoNr] [varchar](50) NULL,
	[BankKontoNr] [varchar](50) NULL,
	[IBAN] [varchar](50) NULL,
	[Zahlungsgrund] [varchar](200) NULL,
	[BeguenstigtName] [varchar](100) NULL,
	[Beguenstigtname2] [varchar](100) NULL,
	[BeguenstigtStrasse] [varchar](100) NULL,
	[BeguenstigtHausNr] [varchar](10) NULL,
	[BeguenstigtPostfach] [varchar](40) NULL,
	[BeguenstigtOrt] [varchar](100) NULL,
	[BeguenstigtPLZ] [varchar](10) NULL,
	[BankName] [varchar](70) NULL,
	[BankStrasse] [varchar](50) NULL,
	[BankPLZ] [varchar](10) NULL,
	[BankOrt] [varchar](60) NULL,
	[BankBCN] [varchar](10) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KbuBelegKreditorTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbuBelegKreditor] PRIMARY KEY CLUSTERED 
(
	[KbuBelegKreditorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_KbuBelegKreditor_BaBankID]    Script Date: 06/29/2011 08:57:30 ******/
CREATE NONCLUSTERED INDEX [IX_KbuBelegKreditor_BaBankID] ON [dbo].[KbuBelegKreditor] 
(
	[BaBankID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbuBelegKreditor_BaLandID_Bank]    Script Date: 06/29/2011 08:57:30 ******/
CREATE NONCLUSTERED INDEX [IX_KbuBelegKreditor_BaLandID_Bank] ON [dbo].[KbuBelegKreditor] 
(
	[BaLandID_Bank] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbuBelegKreditor_BaLandID_Beguenstigt]    Script Date: 06/29/2011 08:57:30 ******/
CREATE NONCLUSTERED INDEX [IX_KbuBelegKreditor_BaLandID_Beguenstigt] ON [dbo].[KbuBelegKreditor] 
(
	[BaLandID_Beguenstigt] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbuBelegKreditor_BaZahlungswegID]    Script Date: 06/29/2011 08:57:30 ******/
CREATE NONCLUSTERED INDEX [IX_KbuBelegKreditor_BaZahlungswegID] ON [dbo].[KbuBelegKreditor] 
(
	[BaZahlungswegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_KbuBelegKreditor_KbuBelegID]    Script Date: 06/29/2011 08:57:30 ******/
CREATE NONCLUSTERED INDEX [IX_KbuBelegKreditor_KbuBelegID] ON [dbo].[KbuBelegKreditor] 
(
	[KbuBelegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'KbuBelegKreditorID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel des Belegs, zu welcher die Kreditor-Informationen gehören' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'KbuBelegID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel des Zahlungswegs.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'BaZahlungswegID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DESCRIPTION', @value=N'Fremdschlüssel zur Tabelle BaBank.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'BaBankID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DESCRIPTION', @value=N'Fremdschlüssel zur Tabelle BaLand.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'BaLandID_Beguenstigt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlussel zu BaLand. Land der Bank.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'BaLandID_Bank'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Auszahlungsart LOV. Z.b. elektronisch.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'KbuAuszahlungArtCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Referenznummer für die Auszahlung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'ReferenzNummer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die erste Mitteilungszeile der Auszahlung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'MitteilungZeile1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die zweite Mitteilungszeile der Auszahlung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'MitteilungZeile2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die dritte Mitteilungszeile der Auszahlung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'MitteilungZeile3'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die vierte Mitteilungszeile der Auszahlung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'MitteilungZeile4'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DESCRIPTION', @value=N'Bestimmt, auf welche Art ausbezahlt wird (siehe LOV Einzahlungsschein)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'BgEinzahlungsscheinCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DESCRIPTION', @value=N'Die PC-Kontonummer, an die der Beleg ausbezahlt wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'PCKontoNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DESCRIPTION', @value=N'Die Bankontonummer, an die der Beleg ausbezahlt wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'BankKontoNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'International Bank Account Number.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'IBAN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Grund der Zahlung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'Zahlungsgrund'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name1 des Begünstigten.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'BeguenstigtName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name2 des Begünstigten.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'Beguenstigtname2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Strasse des Begünstigten. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'BeguenstigtStrasse'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Hausnummer des Begünstigten.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'BeguenstigtHausNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Postfach des Begünstigten.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'BeguenstigtPostfach'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ort der Adresse des Begünstigten.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'BeguenstigtOrt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PLZ der Adresse des Begünstigten' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'BeguenstigtPLZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name der Bank.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'BankName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Strasse (Adresse der Bank)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'BankStrasse'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Postleitzahl der Bank.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'BankPLZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ort der Bank.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'BankOrt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bank Clearing Number (identifiziert eine Bank).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'BankBCN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor', @level2type=N'COLUMN',@level2name=N'KbuBelegKreditorTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Claude Glauser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die Kreditor-Informationen des zugehörigen KbuBelegs ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'WSH, KBU' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuBelegKreditor'
GO

ALTER TABLE [dbo].[KbuBelegKreditor]  WITH CHECK ADD  CONSTRAINT [FK_KbuBelegKreditor_BaBank] FOREIGN KEY([BaBankID])
REFERENCES [dbo].[BaBank] ([BaBankID])
GO

ALTER TABLE [dbo].[KbuBelegKreditor] CHECK CONSTRAINT [FK_KbuBelegKreditor_BaBank]
GO

ALTER TABLE [dbo].[KbuBelegKreditor]  WITH CHECK ADD  CONSTRAINT [FK_KbuBelegKreditor_BaLand_Bank] FOREIGN KEY([BaLandID_Bank])
REFERENCES [dbo].[BaLand] ([BaLandID])
GO

ALTER TABLE [dbo].[KbuBelegKreditor] CHECK CONSTRAINT [FK_KbuBelegKreditor_BaLand_Bank]
GO

ALTER TABLE [dbo].[KbuBelegKreditor]  WITH CHECK ADD  CONSTRAINT [FK_KbuBelegKreditor_BaLand_Beguenstigt] FOREIGN KEY([BaLandID_Beguenstigt])
REFERENCES [dbo].[BaLand] ([BaLandID])
GO

ALTER TABLE [dbo].[KbuBelegKreditor] CHECK CONSTRAINT [FK_KbuBelegKreditor_BaLand_Beguenstigt]
GO

ALTER TABLE [dbo].[KbuBelegKreditor]  WITH CHECK ADD  CONSTRAINT [FK_KbuBelegKreditor_BaZahlungsweg] FOREIGN KEY([BaZahlungswegID])
REFERENCES [dbo].[BaZahlungsweg] ([BaZahlungswegID])
GO

ALTER TABLE [dbo].[KbuBelegKreditor] CHECK CONSTRAINT [FK_KbuBelegKreditor_BaZahlungsweg]
GO

ALTER TABLE [dbo].[KbuBelegKreditor]  WITH CHECK ADD  CONSTRAINT [FK_KbuBelegKreditor_KbuBelegKreditor] FOREIGN KEY([KbuBelegID])
REFERENCES [dbo].[KbuBeleg] ([KbuBelegID])
GO

ALTER TABLE [dbo].[KbuBelegKreditor] CHECK CONSTRAINT [FK_KbuBelegKreditor_KbuBelegKreditor]
GO

ALTER TABLE [dbo].[KbuBelegKreditor] ADD  CONSTRAINT [DF_KbuBelegKreditor_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KbuBelegKreditor] ADD  CONSTRAINT [DF_KbuBelegKreditor_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


