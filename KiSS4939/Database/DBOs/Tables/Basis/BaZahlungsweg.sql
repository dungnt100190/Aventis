CREATE TABLE [dbo].[BaZahlungsweg](
	[BaZahlungswegID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NULL,
	[BaInstitutionID] [int] NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[EinzahlungsscheinCode] [int] NULL,
	[BaBankID] [int] NULL,
	[BankKontoNummer] [varchar](50) NULL,
	[IBANNummer] [varchar](50) NULL,
	[PostKontoNummer] [varchar](20) NULL,
	[ReferenzNummer] [varchar](50) NULL,
	[AdresseName] [varchar](35) NULL,
	[AdresseName2] [varchar](35) NULL,
	[AdresseStrasse] [varchar](35) NULL,
	[AdresseHausNr] [varchar](35) NULL,
	[AdressePostfach] [varchar](35) NULL,
	[AdressePLZ] [varchar](10) NULL,
	[AdresseOrt] [varchar](25) NULL,
	[AdresseLandCode] [int] NULL,
	[BaZahlwegModulStdCodes] [varchar](20) NULL,
	[BaZahlungswegTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaZahlungsweg] PRIMARY KEY CLUSTERED 
(
	[BaZahlungswegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_BaZahlungsweg_AdresseLandCode] ON [dbo].[BaZahlungsweg] 
(
	[AdresseLandCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_BaZahlungsweg_BaBankID] ON [dbo].[BaZahlungsweg] 
(
	[BaBankID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_BaZahlungsweg_BaInstitutionID] ON [dbo].[BaZahlungsweg] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_BaZahlungsweg_BaInstitutionID_BaPersonID__AddCols] ON [dbo].[BaZahlungsweg] 
(
	[BaInstitutionID] ASC,
	[BaPersonID] ASC
)
INCLUDE ( [BaZahlungswegID],
[DatumVon],
[DatumBis],
[EinzahlungsscheinCode],
[BaBankID],
[BankKontoNummer],
[IBANNummer],
[PostKontoNummer],
[ReferenzNummer],
[AdresseName],
[AdresseName2],
[AdresseStrasse],
[AdresseHausNr],
[AdressePostfach],
[AdressePLZ],
[AdresseOrt]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_BaZahlungsweg_BankKontoNummer] ON [dbo].[BaZahlungsweg] 
(
	[BankKontoNummer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_BaZahlungsweg_BaPersonID] ON [dbo].[BaZahlungsweg] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_BaZahlungsweg_IBANNummer] ON [dbo].[BaZahlungsweg] 
(
	[IBANNummer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_BaZahlungsweg_PostKontoNummer] ON [dbo].[BaZahlungsweg] 
(
	[PostKontoNummer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BaZahlungsweg Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaZahlungsweg', @level2type=N'COLUMN',@level2name=N'BaZahlungswegID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BaZahlungsweg_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaZahlungsweg', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BaZahlungsweg_BaInstitution) => BaInstitution.BaInstitutionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaZahlungsweg', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beginn der Gültigkeit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaZahlungsweg', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ende der Gültigkeit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaZahlungsweg', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Art der Überweisung, auf Maske Zahlwegtyp genannt (LOV: BgEinzahlungsschein)  @@TODO Konsistenz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaZahlungsweg', @level2type=N'COLUMN',@level2name=N'EinzahlungsscheinCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BaZahlungsweg_BaBank) => BaBank.BaBankID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaZahlungsweg', @level2type=N'COLUMN',@level2name=N'BaBankID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nummer des Bankkontos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaZahlungsweg', @level2type=N'COLUMN',@level2name=N'BankKontoNummer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IBAN-Nummer des Kontos. Bei neu erfassten Kreditoren, wird die IBAN-Nummer von KiSS automatisch errechnet. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaZahlungsweg', @level2type=N'COLUMN',@level2name=N'IBANNummer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nummer des Postkontos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaZahlungsweg', @level2type=N'COLUMN',@level2name=N'PostKontoNummer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zur Erfassung von Zahlungswegen einer Person oder Institution' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaZahlungsweg'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'Basis, KliBu, Sozialhilfe, Inkasso, Asyl' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaZahlungsweg'
GO

ALTER TABLE [dbo].[BaZahlungsweg]  WITH CHECK ADD  CONSTRAINT [FK_BaZahlungsweg_BaBank] FOREIGN KEY([BaBankID])
REFERENCES [dbo].[BaBank] ([BaBankID])
GO

ALTER TABLE [dbo].[BaZahlungsweg] CHECK CONSTRAINT [FK_BaZahlungsweg_BaBank]
GO

ALTER TABLE [dbo].[BaZahlungsweg]  WITH CHECK ADD  CONSTRAINT [FK_BaZahlungsweg_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[BaZahlungsweg] CHECK CONSTRAINT [FK_BaZahlungsweg_BaInstitution]
GO

ALTER TABLE [dbo].[BaZahlungsweg]  WITH CHECK ADD  CONSTRAINT [FK_BaZahlungsweg_BaLand] FOREIGN KEY([AdresseLandCode])
REFERENCES [dbo].[BaLand] ([BaLandID])
GO

ALTER TABLE [dbo].[BaZahlungsweg] CHECK CONSTRAINT [FK_BaZahlungsweg_BaLand]
GO

ALTER TABLE [dbo].[BaZahlungsweg]  WITH CHECK ADD  CONSTRAINT [FK_BaZahlungsweg_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[BaZahlungsweg] CHECK CONSTRAINT [FK_BaZahlungsweg_BaPerson]
GO