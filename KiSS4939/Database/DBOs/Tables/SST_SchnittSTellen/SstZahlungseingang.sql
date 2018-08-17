CREATE TABLE [dbo].[SstZahlungseingang](
	[SstZahlungseingangID] [int] IDENTITY(1,1) NOT NULL,
	[SstZahlungseingangLaufID] [int] NOT NULL,
	[KbuZahlungseingangID] [int] NULL,
	[PAYMENT_LOT] [varchar](12) NOT NULL,
	[PAYMENT_LOT_POS] [varchar](6) NOT NULL,
	[BANK_ACCOUNT] [varchar](18) NULL,
	[AMOUNT_LOC_CURR] [money] NULL,
	[POST_DATE] [datetime] NULL,
	[PAY_DATE_ESR] [datetime] NULL,
	[PAYMENT_TEXT] [varchar](800) NULL,
	[ValidierungsFehler] [varchar](1000) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[SstZahlungseingangTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_SstZahlungseingang] PRIMARY KEY CLUSTERED 
(
	[SstZahlungseingangID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1],
 CONSTRAINT [UK_SstZahlungseingang_PAYMENT_LOT_PAYMENT_LOT_POS] UNIQUE NONCLUSTERED 
(
	[PAYMENT_LOT] ASC,
	[PAYMENT_LOT_POS] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_SstZahlungseingang_KbuZahlungseingangID] ON [dbo].[SstZahlungseingang] 
(
	[KbuZahlungseingangID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_SstZahlungseingang_SstZahlungseingangLaufID] ON [dbo].[SstZahlungseingang] 
(
	[SstZahlungseingangLaufID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang', @level2type=N'COLUMN',@level2name=N'SstZahlungseingangID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK zu SstZahlungseingangLauf. Der Lauf, mit dem dieser Datensatz vom Fremdsystem abgeholt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang', @level2type=N'COLUMN',@level2name=N'SstZahlungseingangLaufID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK zu KbuZahlungseingang. Der aus diesem Datensatz erzeugte KiSS-Zahlungseingang' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang', @level2type=N'COLUMN',@level2name=N'KbuZahlungseingangID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zahlstapel (entspricht einer Gruppierung von Zahlungseingängen, z.B. Zahlungseingänge auf Postkonto X von heute)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang', @level2type=N'COLUMN',@level2name=N'PAYMENT_LOT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Position im Zahlstapel. Alle Zahlungseingänge eines Zahlstapels sind von 1-n durchnummeriert' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang', @level2type=N'COLUMN',@level2name=N'PAYMENT_LOT_POS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Konto, auf das die Zahlung einbezahlt wurde (z.B. ESR 01-69759-1 oder 80-2036-3)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang', @level2type=N'COLUMN',@level2name=N'BANK_ACCOUNT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag des Zahlungseingangs (in Lokalwährung, also CHF)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang', @level2type=N'COLUMN',@level2name=N'AMOUNT_LOC_CURR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Zahlungseingangs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang', @level2type=N'COLUMN',@level2name=N'POST_DATE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zahlungsdatum des ESR-Einzahlungsscheins' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang', @level2type=N'COLUMN',@level2name=N'PAY_DATE_ESR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mitteilungstext der Einzahlung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang', @level2type=N'COLUMN',@level2name=N'PAYMENT_TEXT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'allfälliger Fehler beim Übertragen in KbuZahlungseingang' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang', @level2type=N'COLUMN',@level2name=N'ValidierungsFehler'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang', @level2type=N'COLUMN',@level2name=N'SstZahlungseingangTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Mathias Minder' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Übernimmt 1:1 die vom Fremdsystem (in ELUSA: PSCD) erhaltenen Daten' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'SST' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique Key für Zahlstapel und -position, um mehrfaches Importieren der gleichen Einzahlung zu verhindern' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang', @level2type=N'CONSTRAINT',@level2name=N'UK_SstZahlungseingang_PAYMENT_LOT_PAYMENT_LOT_POS'
GO

ALTER TABLE [dbo].[SstZahlungseingang]  WITH CHECK ADD  CONSTRAINT [FK_SstZahlungseingang_KbuZahlungseingang] FOREIGN KEY([KbuZahlungseingangID])
REFERENCES [dbo].[KbuZahlungseingang] ([KbuZahlungseingangID])
GO

ALTER TABLE [dbo].[SstZahlungseingang] CHECK CONSTRAINT [FK_SstZahlungseingang_KbuZahlungseingang]
GO

ALTER TABLE [dbo].[SstZahlungseingang]  WITH CHECK ADD  CONSTRAINT [FK_SstZahlungseingang_SstZahlungseingangLauf] FOREIGN KEY([SstZahlungseingangLaufID])
REFERENCES [dbo].[SstZahlungseingangLauf] ([SstZahlungseingangLaufID])
GO

ALTER TABLE [dbo].[SstZahlungseingang] CHECK CONSTRAINT [FK_SstZahlungseingang_SstZahlungseingangLauf]
GO

ALTER TABLE [dbo].[SstZahlungseingang]  WITH CHECK ADD  CONSTRAINT [CK_SstZahlungseingang_KbuZahlungseingangID] CHECK  (([dbo].[fnSstCKSstZahlungseingang_KbuZahlungseingangID_UniqueOrNull]([SstZahlungseingangID],[KbuZahlungseingangID])=(0)))
GO

ALTER TABLE [dbo].[SstZahlungseingang] CHECK CONSTRAINT [CK_SstZahlungseingang_KbuZahlungseingangID]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ensure KbuZahlungseingangID is either NULL or UNIQUE within table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SstZahlungseingang', @level2type=N'CONSTRAINT',@level2name=N'CK_SstZahlungseingang_KbuZahlungseingangID'
GO

ALTER TABLE [dbo].[SstZahlungseingang] ADD  CONSTRAINT [DF_SstZahlungseingang_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[SstZahlungseingang] ADD  CONSTRAINT [DF_SstZahlungseingang_Modified]  DEFAULT (getdate()) FOR [Modified]
GO