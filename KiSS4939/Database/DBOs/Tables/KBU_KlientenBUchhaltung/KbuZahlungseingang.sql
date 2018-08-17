CREATE TABLE [dbo].[KbuZahlungseingang](
	[KbuZahlungseingangID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID_Debitor] [int] NULL,
	[BaInstitutionID_Debitor] [int] NULL,
	[FaFallID] [int] NULL,
	[BaPersonID_Betrifft] [int] NULL,
	[KbuKontoID] [int] NULL,
	[DatumZahlungseingang] [datetime] NULL,
	[Betrag] [money] NULL,
	[Mitteilung] [varchar](800) NULL,
	[Bemerkung] [varchar](1000) NULL,
	[KbuZahlungseingangTeamCode] [int] NULL,
	[Ausgeglichen] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KbuZahlungseingangTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbuZahlungseingang] PRIMARY KEY CLUSTERED 
(
	[KbuZahlungseingangID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KbuZahlungseingang_BaInstitutionID_Debitor] ON [dbo].[KbuZahlungseingang] 
(
	[BaInstitutionID_Debitor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_KbuZahlungseingang_BaPersonID_Debitor] ON [dbo].[KbuZahlungseingang] 
(
	[BaPersonID_Debitor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_KbuZahlungseingang_FaFallID] ON [dbo].[KbuZahlungseingang] 
(
	[FaFallID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_KbuZahlungseingang_BaPersonID_Betrifft] ON [dbo].[KbuZahlungseingang] 
(
	[BaPersonID_Betrifft] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_KbuZahlungseingang_KbuKontoID] ON [dbo].[KbuZahlungseingang] 
(
	[KbuKontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuZahlungseingang', @level2type=N'COLUMN',@level2name=N'KbuZahlungseingangID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Person, von der die Zahlung kommt (Debitor)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuZahlungseingang', @level2type=N'COLUMN',@level2name=N'BaPersonID_Debitor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Institution, von der die Zahlung kommt (Debitor)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuZahlungseingang', @level2type=N'COLUMN',@level2name=N'BaInstitutionID_Debitor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu FaFall. Innerhalb dieses Falls werden erwartete Einnahmen zum Ausgleich angeboten.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuZahlungseingang', @level2type=N'COLUMN',@level2name=N'FaFallID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu BaPerson. Die Person, welcher (innerhalb der Leistung) die Einnahme zugeteilt ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuZahlungseingang', @level2type=N'COLUMN',@level2name=N'BaPersonID_Betrifft'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bilanzkonto, auf welches der Zahlungseingang gebucht wird (z.B. PC-Konto)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuZahlungseingang', @level2type=N'COLUMN',@level2name=N'KbuKontoID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Eingangsdatum der Zahlung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuZahlungseingang', @level2type=N'COLUMN',@level2name=N'DatumZahlungseingang'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag des Zahlungseingangs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuZahlungseingang', @level2type=N'COLUMN',@level2name=N'Betrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mitteilungstext, wird für die Verarbeitung benötigt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuZahlungseingang', @level2type=N'COLUMN',@level2name=N'Mitteilung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Team, welchem der Zahlungseingang zugeordnet ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuZahlungseingang', @level2type=N'COLUMN',@level2name=N'KbuZahlungseingangTeamCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'true, falls der Zahlungseingang vollständig ausgeglichen ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuZahlungseingang', @level2type=N'COLUMN',@level2name=N'Ausgeglichen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuZahlungseingang', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuZahlungseingang', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuZahlungseingang', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuZahlungseingang', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuZahlungseingang', @level2type=N'COLUMN',@level2name=N'KbuZahlungseingangTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Mathias Minder' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuZahlungseingang'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zahlungseingänge, die mit OPs verbucht werden können bzw. bereits verbucht wurden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuZahlungseingang'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'KBU' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuZahlungseingang'
GO

ALTER TABLE [dbo].[KbuZahlungseingang]  WITH CHECK ADD  CONSTRAINT [FK_KbuZahlungseingang_BaInstitution_Debitor] FOREIGN KEY([BaInstitutionID_Debitor])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO
ALTER TABLE [dbo].[KbuZahlungseingang] CHECK CONSTRAINT [FK_KbuZahlungseingang_BaInstitution_Debitor]
GO

ALTER TABLE [dbo].[KbuZahlungseingang]  WITH CHECK ADD  CONSTRAINT [FK_KbuZahlungseingang_BaPerson_Debitor] FOREIGN KEY([BaPersonID_Debitor])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[KbuZahlungseingang] CHECK CONSTRAINT [FK_KbuZahlungseingang_BaPerson_Debitor]
GO

-- FK auf FaFall ist nur auf Tabelle möglich
IF EXISTS(SELECT TOP 1 1
          FROM sysobjects
          WHERE Name = 'FaFall' and xtype = 'U') BEGIN
  ALTER TABLE [dbo].[KbuZahlungseingang]  WITH CHECK ADD  CONSTRAINT [FK_KbuZahlungseingang_FaFall] FOREIGN KEY([FaFallID])
  REFERENCES [dbo].[FaFall] ([FaFallID])
END
GO
IF EXISTS(SELECT TOP 1 1
          FROM sysobjects
          WHERE Name = 'FaFall' and xtype = 'U') BEGIN
  ALTER TABLE [dbo].[KbuZahlungseingang] CHECK CONSTRAINT [FK_KbuZahlungseingang_FaFall]
END
GO

ALTER TABLE [dbo].[KbuZahlungseingang]  WITH CHECK ADD  CONSTRAINT [FK_KbuZahlungseingang_BaPersonID_Betrifft] FOREIGN KEY([BaPersonID_Betrifft])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[KbuZahlungseingang] CHECK CONSTRAINT [FK_KbuZahlungseingang_BaPersonID_Betrifft]
GO

ALTER TABLE [dbo].[KbuZahlungseingang]  WITH CHECK ADD  CONSTRAINT [FK_KbuZahlungseingang_KbuKonto] FOREIGN KEY([KbuKontoID])
REFERENCES [dbo].[KbuKonto] ([KbuKontoID])
GO
ALTER TABLE [dbo].[KbuZahlungseingang] CHECK CONSTRAINT [FK_KbuZahlungseingang_KbuKonto]
GO

ALTER TABLE [dbo].[KbuZahlungseingang] ADD  CONSTRAINT [Df_KbuZahlungseingang_Ausgeglichen]  DEFAULT ((0)) FOR [Ausgeglichen]
GO

ALTER TABLE [dbo].[KbuZahlungseingang] ADD  CONSTRAINT [DF_KbuZahlungseingang_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KbuZahlungseingang] ADD  CONSTRAINT [DF_KbuZahlungseingang_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
